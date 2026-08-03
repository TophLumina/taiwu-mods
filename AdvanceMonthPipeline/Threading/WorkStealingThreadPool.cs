namespace Taiwu.AdvanceMonthPipeline.Threading;

/// <summary>
/// 用于执行同步委托的固定大小工作窃取线程池。
/// </summary>
/// <remarks>
/// 每个工作线程拥有一个双端队列，并以后进先出的顺序执行本地任务；本地队列为空时，
/// 按先进先出的顺序从其他工作线程窃取最早提交的任务。工作线程内部提交的任务会进入
/// 当前线程的本地队列，外部线程提交的任务则以轮询方式分散到所有队列。
/// </remarks>
public sealed class WorkStealingThreadPool : IDisposable
{
    [ThreadStatic]
    private static WorkStealingThreadPool? s_currentPool;

    [ThreadStatic]
    private static int s_currentQueueIndex;

    private readonly WorkQueue[] _queues;
    private readonly Thread[] _workers;
    private readonly SemaphoreSlim _workAvailable = new(initialCount: 0);
    private readonly object _lifecycleGate = new();

    private int _nextSubmitQueue = -1;
    private volatile bool _stopping;
    private bool _disposed;

    /// <summary>
    /// 按逻辑处理器数量创建工作线程。
    /// </summary>
    public WorkStealingThreadPool()
        : this(Environment.ProcessorCount)
    {
    }

    /// <summary>
    /// 创建包含指定数量工作线程的线程池。
    /// </summary>
    /// <param name="workerCount">
    /// 工作线程数量。传入零时按一个工作线程处理。
    /// </param>
    public WorkStealingThreadPool(int workerCount)
    {
        if (workerCount < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(workerCount),
                workerCount,
                "Worker count cannot be negative.");
        }

        if (workerCount == 0)
        {
            workerCount = 1;
        }

        _queues = new WorkQueue[workerCount];
        _workers = new Thread[workerCount];

        for (int i = 0; i < workerCount; i++)
        {
            _queues[i] = new WorkQueue();
            _workers[i] = new Thread(WorkerRoutine)
            {
                IsBackground = true,
                Name = $"Taiwu.AdvanceMonthPipeline.Worker.{i}"
            };
        }

        int startedWorkerCount = 0;
        try
        {
            for (; startedWorkerCount < workerCount; startedWorkerCount++)
            {
                _workers[startedWorkerCount].Start(startedWorkerCount);
            }
        }
        catch
        {
            _stopping = true;
            if (startedWorkerCount > 0)
            {
                _workAvailable.Release(startedWorkerCount);
            }

            for (int i = 0; i < startedWorkerCount; i++)
            {
                _workers[i].Join();
            }

            _workAvailable.Dispose();
            throw;
        }
    }

    /// <summary>
    /// 获取线程池持有的固定工作线程数量。
    /// </summary>
    public int WorkerCount => _workers.Length;

    /// <summary>
    /// 将操作加入队列，并返回用于表示完成状态或保存异常的任务。
    /// </summary>
    public Task Submit(Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var workItem = new ActionWorkItem(action);
        Enqueue(workItem);
        return workItem.Completion;
    }

    /// <summary>
    /// 将函数加入队列，并返回用于保存执行结果或异常的任务。
    /// </summary>
    public Task<TResult> Submit<TResult>(Func<TResult> function)
    {
        ArgumentNullException.ThrowIfNull(function);

        var workItem = new FuncWorkItem<TResult>(function);
        Enqueue(workItem);
        return workItem.Completion;
    }

    /// <summary>
    /// 停止接收新任务，执行完队列中的已有任务，并等待所有工作线程退出。
    /// </summary>
    /// <remarks>
    /// 释放过程会等待已提交的任务完成，因此不能在线程池自身的工作线程中调用。
    /// </remarks>
    public void Dispose()
    {
        if (ReferenceEquals(s_currentPool, this))
        {
            throw new InvalidOperationException(
                "A thread pool cannot be disposed by one of its own workers.");
        }

        bool signalWorkers = false;
        lock (_lifecycleGate)
        {
            if (_disposed)
            {
                return;
            }

            if (!_stopping)
            {
                _stopping = true;
                signalWorkers = true;
            }
        }

        if (signalWorkers)
        {
            // 唤醒空闲的工作线程。线程会继续获取实际任务，直到所有队列清空，
            // 随后消费一个唤醒信号并检测到停止标记。
            _workAvailable.Release(_workers.Length);
        }

        foreach (Thread worker in _workers)
        {
            worker.Join();
        }

        lock (_lifecycleGate)
        {
            if (!_disposed)
            {
                _workAvailable.Dispose();
                _disposed = true;
            }
        }
    }

    private void Enqueue(IWorkItem workItem)
    {
        lock (_lifecycleGate)
        {
            ObjectDisposedException.ThrowIf(_stopping, this);

            int queueIndex;
            if (ReferenceEquals(s_currentPool, this))
            {
                queueIndex = s_currentQueueIndex;
            }
            else
            {
                uint next = unchecked((uint)Interlocked.Increment(ref _nextSubmitQueue));
                queueIndex = (int)(next % (uint)_queues.Length);
            }

            _queues[queueIndex].Enqueue(workItem);
            _workAvailable.Release();
        }
    }

    private void WorkerRoutine(object? state)
    {
        int queueIndex = (int)state!;
        s_currentPool = this;
        s_currentQueueIndex = queueIndex;

        try
        {
            while (true)
            {
                _workAvailable.Wait();

                if (TryTakeWork(queueIndex, out IWorkItem? workItem))
                {
                    workItem!.Execute();
                    continue;
                }

                if (_stopping)
                {
                    return;
                }

                // 非阻塞窃取可能跳过暂时被持有锁的队列。此时归还已消费的任务信号，
                // 防止队列中的任务失去唤醒机会，并让出时间片供锁持有线程继续运行。
                _workAvailable.Release();
                Thread.Yield();
            }
        }
        finally
        {
            s_currentQueueIndex = 0;
            s_currentPool = null;
        }
    }

    private bool TryTakeWork(int localQueueIndex, out IWorkItem? workItem)
    {
        if (_queues[localQueueIndex].TryTakeLocal(out workItem))
        {
            return true;
        }

        for (int offset = 1; offset < _queues.Length; offset++)
        {
            int stealQueueIndex = (localQueueIndex + offset) % _queues.Length;
            if (_queues[stealQueueIndex].TrySteal(out workItem))
            {
                return true;
            }
        }

        workItem = null;
        return false;
    }

    private interface IWorkItem
    {
        void Execute();
    }

    private sealed class ActionWorkItem(Action action) : IWorkItem
    {
        private readonly Action _action = action;
        private readonly TaskCompletionSource _completion = new(
            TaskCreationOptions.RunContinuationsAsynchronously);

        public Task Completion => _completion.Task;

        public void Execute()
        {
            try
            {
                _action();
                _completion.SetResult();
            }
            catch (Exception exception)
            {
                _completion.SetException(exception);
            }
        }
    }

    private sealed class FuncWorkItem<TResult>(Func<TResult> function) : IWorkItem
    {
        private readonly Func<TResult> _function = function;
        private readonly TaskCompletionSource<TResult> _completion = new(
            TaskCreationOptions.RunContinuationsAsynchronously);

        public Task<TResult> Completion => _completion.Task;

        public void Execute()
        {
            try
            {
                _completion.SetResult(_function());
            }
            catch (Exception exception)
            {
                _completion.SetException(exception);
            }
        }
    }

    private sealed class WorkQueue
    {
        private readonly LinkedList<IWorkItem> _items = new();
        private readonly object _gate = new();

        public void Enqueue(IWorkItem workItem)
        {
            lock (_gate)
            {
                _items.AddLast(workItem);
            }
        }

        public bool TryTakeLocal(out IWorkItem? workItem)
        {
            lock (_gate)
            {
                LinkedListNode<IWorkItem>? node = _items.Last;
                if (node is null)
                {
                    workItem = null;
                    return false;
                }

                _items.RemoveLast();
                workItem = node.Value;
                return true;
            }
        }

        public bool TrySteal(out IWorkItem? workItem)
        {
            // 窃取方只尝试获取一次锁，不在繁忙队列的锁持有线程之后等待。
            if (!Monitor.TryEnter(_gate))
            {
                workItem = null;
                return false;
            }

            try
            {
                LinkedListNode<IWorkItem>? node = _items.First;
                if (node is null)
                {
                    workItem = null;
                    return false;
                }

                _items.RemoveFirst();
                workItem = node.Value;
                return true;
            }
            finally
            {
                Monitor.Exit(_gate);
            }
        }
    }
}
