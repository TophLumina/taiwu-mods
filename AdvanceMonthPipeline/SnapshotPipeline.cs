using Taiwu.AdvanceMonthPipeline.Threading;

namespace Taiwu.AdvanceMonthPipeline;

/// <summary>
/// 描述一个“读取快照、并行计算、确定性提交、生成新快照”的阶段。
/// </summary>
public sealed class SnapshotStage<TState, TSnapshot, TWorkItem, TScratch>
    where TSnapshot : IVersionedSnapshot
{
    private readonly Func<TSnapshot, IReadOnlyList<TWorkItem>> _selectWorkItems;
    private readonly Func<int, TScratch> _createScratch;
    private readonly Action<
        StageWorkerContext<TState, TSnapshot, TScratch>,
        TWorkItem> _execute;
    private readonly Func<TState, TState> _prepareCommit;
    private readonly Func<TState, long, TSnapshot> _projectSnapshot;

    public SnapshotStage(
        string name,
        Func<TSnapshot, IReadOnlyList<TWorkItem>> selectWorkItems,
        Func<int, TScratch> createScratch,
        Action<StageWorkerContext<TState, TSnapshot, TScratch>, TWorkItem> execute,
        Func<TState, long, TSnapshot> projectSnapshot,
        Func<TState, TState>? prepareCommit = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(selectWorkItems);
        ArgumentNullException.ThrowIfNull(createScratch);
        ArgumentNullException.ThrowIfNull(execute);
        ArgumentNullException.ThrowIfNull(projectSnapshot);

        Name = name;
        _selectWorkItems = selectWorkItems;
        _createScratch = createScratch;
        _execute = execute;
        _projectSnapshot = projectSnapshot;
        _prepareCommit = prepareCommit ?? (static state => state);
    }

    public string Name { get; }

    internal IReadOnlyList<TWorkItem> SelectWorkItems(TSnapshot snapshot) =>
        _selectWorkItems(snapshot) ?? throw new InvalidOperationException(
            $"阶段“{Name}”返回了空的工作项集合引用。");

    internal TScratch CreateScratch(int workerSlot) => _createScratch(workerSlot);

    internal void Execute(
        StageWorkerContext<TState, TSnapshot, TScratch> context,
        TWorkItem item) => _execute(context, item);

    internal TState PrepareCommit(TState state) => _prepareCommit(state);

    internal TSnapshot ProjectSnapshot(TState state, long version) =>
        _projectSnapshot(state, version);
}

/// <summary>
/// 保存一次阶段提交后的新快照、写集合并统计和待发布事件。
/// </summary>
public sealed record StageRunResult<TSnapshot>(
    string StageName,
    long SourceVersion,
    TSnapshot Snapshot,
    int EmittedDeltaCount,
    int AppliedDeltaCount,
    int ExecutedCommandCount,
    IReadOnlyList<IStageEvent> Events)
    where TSnapshot : IVersionedSnapshot;

/// <summary>
/// 按版本依次运行快照阶段，并在每个阶段结束后发布新的只读投影。
/// </summary>
public sealed class SnapshotPipeline<TState, TSnapshot> : IDisposable
    where TSnapshot : IVersionedSnapshot
{
    private readonly object _gate = new();
    private readonly WorkStealingThreadPool _threadPool;
    private readonly bool _ownsThreadPool;

    private TState _currentState;
    private TSnapshot _currentSnapshot;
    private bool _disposed;

    public SnapshotPipeline(
        TState initialState,
        TSnapshot initialSnapshot,
        WorkStealingThreadPool? threadPool = null)
    {
        ArgumentNullException.ThrowIfNull(initialSnapshot);
        if (initialSnapshot.Version < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(initialSnapshot),
                initialSnapshot.Version,
                "快照版本不能为负数。");
        }

        _currentState = initialState;
        _currentSnapshot = initialSnapshot;
        _threadPool = threadPool ?? new WorkStealingThreadPool();
        _ownsThreadPool = threadPool is null;
    }

    /// <summary>
    /// 获取最近一次成功提交后的状态。
    /// </summary>
    public TState CurrentState
    {
        get
        {
            lock (_gate)
            {
                return _currentState;
            }
        }
    }

    /// <summary>
    /// 获取最近一次成功提交后生成的只读快照。
    /// </summary>
    public TSnapshot CurrentSnapshot
    {
        get
        {
            lock (_gate)
            {
                return _currentSnapshot;
            }
        }
    }

    /// <summary>
    /// 运行一个完整阶段。并行计算失败或写集合并失败时不会开始提交。
    /// </summary>
    public StageRunResult<TSnapshot> RunStage<TWorkItem, TScratch>(
        SnapshotStage<TState, TSnapshot, TWorkItem, TScratch> stage)
    {
        ArgumentNullException.ThrowIfNull(stage);

        lock (_gate)
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            return RunStageCore(stage);
        }
    }

    public void Dispose()
    {
        lock (_gate)
        {
            if (_disposed)
            {
                return;
            }

            if (_ownsThreadPool)
            {
                _threadPool.Dispose();
            }

            _disposed = true;
        }
    }

    private StageRunResult<TSnapshot> RunStageCore<TWorkItem, TScratch>(
        SnapshotStage<TState, TSnapshot, TWorkItem, TScratch> stage)
    {
        TSnapshot sourceSnapshot = _currentSnapshot;
        IReadOnlyList<TWorkItem> workItems = stage.SelectWorkItems(sourceSnapshot);
        StageOutputBuffer<TState>[] workerOutputs = ExecuteParallel(
            stage,
            sourceSnapshot,
            workItems);

        List<OrderedStageDelta<TState>> emittedDeltas = CollectDeltas(workerOutputs);
        List<OrderedStageDelta<TState>> mergedDeltas = MergeDeltas(
            stage.Name,
            emittedDeltas);
        List<OrderedStageCommand<TState>> commands = CollectCommands(workerOutputs);
        List<OrderedStageEvent> events = CollectEvents(workerOutputs);

        EnsureUniqueOrderKeys(stage.Name, "领域命令", commands.Select(item => item.OrderKey));
        EnsureUniqueOrderKeys(stage.Name, "阶段事件", events.Select(item => item.OrderKey));

        long targetVersion = checked(sourceSnapshot.Version + 1);
        var commitContext = new StageCommitContext(
            stage.Name,
            sourceSnapshot.Version,
            targetVersion,
            events);

        TState candidateState = stage.PrepareCommit(_currentState);
        foreach (OrderedStageDelta<TState> delta in mergedDeltas)
        {
            candidateState = delta.Value.Apply(candidateState, commitContext);
        }

        foreach (OrderedStageCommand<TState> command in commands)
        {
            candidateState = command.Value.Execute(candidateState, commitContext);
        }

        TSnapshot nextSnapshot = stage.ProjectSnapshot(candidateState, targetVersion);
        ArgumentNullException.ThrowIfNull(nextSnapshot);
        if (nextSnapshot.Version != targetVersion)
        {
            throw new InvalidOperationException(
                $"阶段“{stage.Name}”投影出的快照版本为 {nextSnapshot.Version}，" +
                $"预期版本为 {targetVersion}。");
        }

        SortEventsAndEnsureUniqueKeys(stage.Name, events);

        _currentState = candidateState;
        _currentSnapshot = nextSnapshot;

        return new StageRunResult<TSnapshot>(
            stage.Name,
            sourceSnapshot.Version,
            nextSnapshot,
            emittedDeltas.Count,
            mergedDeltas.Count,
            commands.Count,
            events.Select(item => item.Value).ToArray());
    }

    private StageOutputBuffer<TState>[] ExecuteParallel<TWorkItem, TScratch>(
        SnapshotStage<TState, TSnapshot, TWorkItem, TScratch> stage,
        TSnapshot snapshot,
        IReadOnlyList<TWorkItem> workItems)
    {
        if (workItems.Count == 0)
        {
            return [];
        }

        int slotCount = Math.Min(_threadPool.WorkerCount, workItems.Count);
        var outputs = new StageOutputBuffer<TState>[slotCount];
        var tasks = new Task[slotCount];
        int nextWorkItem = -1;

        for (int slot = 0; slot < slotCount; slot++)
        {
            int workerSlot = slot;
            var output = new StageOutputBuffer<TState>();
            outputs[workerSlot] = output;
            tasks[workerSlot] = _threadPool.Submit(
                () =>
                {
                    TScratch scratch = stage.CreateScratch(workerSlot);
                    var context = new StageWorkerContext<TState, TSnapshot, TScratch>(
                        workerSlot,
                        snapshot,
                        scratch,
                        output);

                    try
                    {
                        while (true)
                        {
                            int index = Interlocked.Increment(ref nextWorkItem);
                            if (index >= workItems.Count)
                            {
                                break;
                            }

                            stage.Execute(context, workItems[index]);
                        }
                    }
                    finally
                    {
                        context.Seal();
                        if (scratch is IDisposable disposable)
                        {
                            disposable.Dispose();
                        }
                    }
                });
        }

        Task.WhenAll(tasks).GetAwaiter().GetResult();
        return outputs;
    }

    private static List<OrderedStageDelta<TState>> CollectDeltas(
        StageOutputBuffer<TState>[] outputs)
    {
        var result = new List<OrderedStageDelta<TState>>(
            outputs.Sum(output => output.Deltas.Count));
        foreach (StageOutputBuffer<TState> output in outputs)
        {
            result.AddRange(output.Deltas);
        }

        result.Sort(CompareDeltas);
        return result;
    }

    private static List<OrderedStageCommand<TState>> CollectCommands(
        StageOutputBuffer<TState>[] outputs)
    {
        var result = new List<OrderedStageCommand<TState>>(
            outputs.Sum(output => output.Commands.Count));
        foreach (StageOutputBuffer<TState> output in outputs)
        {
            result.AddRange(output.Commands);
        }

        result.Sort(static (left, right) => left.OrderKey.CompareTo(right.OrderKey));
        return result;
    }

    private static List<OrderedStageEvent> CollectEvents(
        StageOutputBuffer<TState>[] outputs)
    {
        var result = new List<OrderedStageEvent>(
            outputs.Sum(output => output.Events.Count));
        foreach (StageOutputBuffer<TState> output in outputs)
        {
            result.AddRange(output.Events);
        }

        return result;
    }

    private static List<OrderedStageDelta<TState>> MergeDeltas(
        string stageName,
        List<OrderedStageDelta<TState>> emittedDeltas)
    {
        var table = new Dictionary<StageMutationKey, OrderedStageDelta<TState>>();
        foreach (OrderedStageDelta<TState> emission in emittedDeltas)
        {
            StageMutationKey key = emission.Value.MutationKey;
            if (!table.TryGetValue(key, out OrderedStageDelta<TState> existing))
            {
                table.Add(key, emission);
                continue;
            }

            if (!existing.Value.TryMerge(emission.Value, out IStageDelta<TState>? merged) ||
                merged is null)
            {
                throw new StageWriteConflictException(
                    stageName,
                    key,
                    existing.OrderKey,
                    emission.OrderKey);
            }

            if (merged.MutationKey != key)
            {
                throw new InvalidOperationException(
                    $"阶段“{stageName}”合并修改 {key} 后返回了不同的修改键 " +
                    $"{merged.MutationKey}。");
            }

            table[key] = new OrderedStageDelta<TState>(existing.OrderKey, merged);
        }

        List<OrderedStageDelta<TState>> result = table.Values.ToList();
        result.Sort(CompareDeltas);
        return result;
    }

    private static int CompareDeltas(
        OrderedStageDelta<TState> left,
        OrderedStageDelta<TState> right)
    {
        int result = left.OrderKey.CompareTo(right.OrderKey);
        return result != 0
            ? result
            : left.Value.MutationKey.CompareTo(right.Value.MutationKey);
    }

    private static void SortEventsAndEnsureUniqueKeys(
        string stageName,
        List<OrderedStageEvent> events)
    {
        events.Sort(static (left, right) => left.OrderKey.CompareTo(right.OrderKey));
        EnsureUniqueOrderKeys(stageName, "阶段事件", events.Select(item => item.OrderKey));
    }

    private static void EnsureUniqueOrderKeys(
        string stageName,
        string outputKind,
        IEnumerable<StageOrderKey> keys)
    {
        var seen = new HashSet<StageOrderKey>();
        foreach (StageOrderKey key in keys)
        {
            if (!seen.Add(key))
            {
                throw new InvalidOperationException(
                    $"阶段“{stageName}”的{outputKind}使用了重复的稳定顺序键 {key}。");
            }
        }
    }
}
