using System;
using System.Collections.Concurrent;
using System.Threading;
using GameData.GameDataBridge;
using GameData.Utilities;
using NLog;

namespace GameData.Common.WorkerThread;

public static class WorkerThreadManager
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	private static readonly Thread[] Workers = new Thread[Math.Min(Environment.ProcessorCount, 32)];

	private static readonly DataContext[] Contexts = new DataContext[Math.Min(Environment.ProcessorCount, 32)];

	private static WorkerThreadTaskType _taskType;

	private static Action<DataContext, int> _workingMethod;

	private static ConcurrentQueue<int> _workIds;

	private static Semaphore _tasksCount;

	private static CountdownEvent _workingCount;

	public static void Initialize()
	{
		_workIds = new ConcurrentQueue<int>();
		_tasksCount = new Semaphore(0, Workers.Length);
		_workingCount = new CountdownEvent(0);
		CreateWorkerThreads();
	}

	public static void ReInitialize()
	{
		TerminateWorkerThreads();
		_tasksCount.Dispose();
		_workingCount.Dispose();
		Initialize();
	}

	public static void Run(Action<DataContext, int> workingMethod, int beginWorkId, int endWorkId, DataMonitorManager monitor = null, int monitorInterval = 0)
	{
		if (Program.AdvanceMonthSingleThread)
		{
			DataContext context = DataContextManager.GetCurrentThreadDataContext();
			RunSingleThread(context, workingMethod, beginWorkId, endWorkId, monitor);
			return;
		}
		Tester.Assert(_workingMethod == null);
		Tester.Assert(_workIds.IsEmpty);
		Tester.Assert(_workingCount.CurrentCount == 0);
		AddTask(workingMethod, beginWorkId, endWorkId);
		if (monitor == null || monitorInterval <= 0)
		{
			_workingCount.Wait();
		}
		else
		{
			while (!_workingCount.Wait(monitorInterval))
			{
				monitor.CheckMonitoredData();
				GameData.GameDataBridge.GameDataBridge.TransferPendingNotifications();
			}
		}
		while (_workingCount.CurrentCount > 0 || !_workIds.IsEmpty)
		{
		}
		int i = 0;
		for (int count = Workers.Length; i < count; i++)
		{
			DataContext context2 = Contexts[i];
			context2.ParallelModificationsRecorder.ApplyAll(context2);
		}
		_workingMethod = null;
		Tester.Assert(_workIds.IsEmpty);
		Tester.Assert(_workingCount.CurrentCount == 0);
	}

	private static void RunSingleThread(DataContext context, Action<DataContext, int> workingMethod, int beginWorkId, int endWorkId, DataMonitorManager monitor = null)
	{
		_workingMethod = workingMethod;
		for (int i = beginWorkId; i < endWorkId; i++)
		{
			workingMethod?.Invoke(context, i);
			if (monitor != null)
			{
				monitor.CheckMonitoredData();
				GameData.GameDataBridge.GameDataBridge.TransferPendingNotifications();
			}
		}
		context.ParallelModificationsRecorder.ApplyAll(context);
		_workingMethod = null;
	}

	public static void RunPostAction(Action<DataContext> postAction)
	{
		int i = 0;
		for (int count = Workers.Length; i < count; i++)
		{
			postAction(Contexts[i]);
		}
	}

	private static void CreateWorkerThreads()
	{
		int i = 0;
		for (int count = Workers.Length; i < count; i++)
		{
			Thread worker = new Thread(WorkerProc)
			{
				IsBackground = true,
				Name = $"Worker{i}",
				Priority = ThreadPriority.AboveNormal
			};
			Workers[i] = worker;
			worker.Start(i);
		}
	}

	private static void TerminateWorkerThreads()
	{
		_taskType = WorkerThreadTaskType.Exit;
		Tester.Assert(_workingMethod == null);
		Tester.Assert(_workIds.IsEmpty);
		_tasksCount.Release(Workers.Length);
		Tester.Assert(_workingCount.CurrentCount == 0);
		int i = 0;
		for (int count = Workers.Length; i < count; i++)
		{
			Workers[i].Join();
			Workers[i] = null;
			Contexts[i] = null;
		}
	}

	private static void WorkerProc(object index)
	{
		Logger.Info("Worker thread started.");
		try
		{
			DataContext context = DataContextManager.GetCurrentThreadDataContext();
			Contexts[(int)index] = context;
			while (true)
			{
				_tasksCount.WaitOne();
				if (_taskType != WorkerThreadTaskType.Invoke)
				{
					break;
				}
				int workId;
				while (_workIds.TryDequeue(out workId))
				{
					_workingMethod(context, workId);
				}
				_workingCount.Signal();
			}
			if (_taskType != WorkerThreadTaskType.Exit)
			{
				throw new Exception($"Unsupported WorkerThreadTaskType: {_taskType}");
			}
		}
		catch (Exception value)
		{
			Logger.Error(value);
		}
		Logger.Info("Worker thread is about to exit.");
		LogManager.Flush();
	}

	private static void AddTask(Action<DataContext, int> workingMethod, int beginWorkId, int endWorkId)
	{
		_taskType = WorkerThreadTaskType.Invoke;
		_workingMethod = workingMethod;
		for (int i = beginWorkId; i < endWorkId; i++)
		{
			_workIds.Enqueue(i);
		}
		_workingCount.Reset(Workers.Length);
		_tasksCount.Release(Workers.Length);
	}
}
