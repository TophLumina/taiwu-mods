namespace Taiwu.AdvanceMonthPipeline;

/// <summary>
/// 向单个并行工作槽提供只读快照、阶段专用暂存区和类型化输出接口。
/// </summary>
public sealed class StageWorkerContext<TState, TSnapshot, TScratch>
    where TSnapshot : IVersionedSnapshot
{
    private StageOutputBuffer<TState>? _output;

    internal StageWorkerContext(
        int workerSlot,
        TSnapshot snapshot,
        TScratch scratch,
        StageOutputBuffer<TState> output)
    {
        WorkerSlot = workerSlot;
        Snapshot = snapshot;
        Scratch = scratch;
        _output = output;
    }

    /// <summary>
    /// 获取本次执行使用的逻辑工作槽。它不等同于操作系统线程编号。
    /// </summary>
    public int WorkerSlot { get; }

    /// <summary>
    /// 获取当前阶段唯一允许读取的世界投影。
    /// </summary>
    public TSnapshot Snapshot { get; }

    /// <summary>
    /// 获取仅在当前工作槽和当前阶段中使用的暂存对象。
    /// </summary>
    public TScratch Scratch { get; }

    /// <summary>
    /// 记录字段或组件修改。
    /// </summary>
    public void EmitDelta(
        StageOrderKey orderKey,
        IStageDelta<TState> delta)
    {
        ArgumentNullException.ThrowIfNull(delta);
        GetOutput().Deltas.Add(new OrderedStageDelta<TState>(orderKey, delta));
    }

    /// <summary>
    /// 记录需要在字段修改之后执行的领域命令。
    /// </summary>
    public void EmitCommand(
        StageOrderKey orderKey,
        IStageCommand<TState> command)
    {
        ArgumentNullException.ThrowIfNull(command);
        GetOutput().Commands.Add(new OrderedStageCommand<TState>(orderKey, command));
    }

    /// <summary>
    /// 记录仅在成功提交后才对外可见的事件或通知。
    /// </summary>
    public void EmitEvent(
        StageOrderKey orderKey,
        IStageEvent stageEvent)
    {
        ArgumentNullException.ThrowIfNull(stageEvent);
        GetOutput().Events.Add(new OrderedStageEvent(orderKey, stageEvent));
    }

    internal void Seal()
    {
        _output = null;
    }

    private StageOutputBuffer<TState> GetOutput()
    {
        return _output ?? throw new InvalidOperationException(
            "阶段工作上下文已经结束，不能继续写入输出。");
    }
}

internal sealed class StageOutputBuffer<TState>
{
    public List<OrderedStageDelta<TState>> Deltas { get; } = [];

    public List<OrderedStageCommand<TState>> Commands { get; } = [];

    public List<OrderedStageEvent> Events { get; } = [];
}

internal readonly record struct OrderedStageDelta<TState>(
    StageOrderKey OrderKey,
    IStageDelta<TState> Value);

internal readonly record struct OrderedStageCommand<TState>(
    StageOrderKey OrderKey,
    IStageCommand<TState> Value);
