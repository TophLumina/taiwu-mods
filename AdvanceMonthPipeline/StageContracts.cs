namespace Taiwu.AdvanceMonthPipeline;

/// <summary>
/// 表示从某一已提交世界版本投影出的只读阶段快照。
/// </summary>
public interface IVersionedSnapshot
{
    /// <summary>
    /// 获取快照对应的已提交世界版本。
    /// </summary>
    long Version { get; }
}

/// <summary>
/// 标识一次字段或组件修改的唯一目标。
/// </summary>
/// <param name="Scope">修改所属的领域或组件。</param>
/// <param name="EntityId">被修改实体的稳定标识。</param>
/// <param name="Member">被修改的字段或组件名称。</param>
public readonly record struct StageMutationKey(
    string Scope,
    long EntityId,
    string Member) : IComparable<StageMutationKey>
{
    public int CompareTo(StageMutationKey other)
    {
        int result = StringComparer.Ordinal.Compare(Scope, other.Scope);
        if (result != 0)
        {
            return result;
        }

        result = EntityId.CompareTo(other.EntityId);
        return result != 0
            ? result
            : StringComparer.Ordinal.Compare(Member, other.Member);
    }

    public override string ToString() => $"{Scope}/{EntityId}/{Member}";
}

/// <summary>
/// 定义阶段输出的稳定提交顺序。
/// </summary>
/// <param name="EntityId">产生输出的实体标识。</param>
/// <param name="Sequence">该实体在当前阶段内的输出序号。</param>
public readonly record struct StageOrderKey(
    long EntityId,
    int Sequence) : IComparable<StageOrderKey>
{
    public int CompareTo(StageOrderKey other)
    {
        int result = EntityId.CompareTo(other.EntityId);
        return result != 0 ? result : Sequence.CompareTo(other.Sequence);
    }

    public override string ToString() => $"{EntityId}:{Sequence}";
}

/// <summary>
/// 表示可以合并并应用到提交候选状态的类型化字段或组件修改。
/// </summary>
public interface IStageDelta<TState>
{
    /// <summary>
    /// 获取该修改独占的字段或组件键。
    /// </summary>
    StageMutationKey MutationKey { get; }

    /// <summary>
    /// 尝试把同一修改键的后续修改合并到当前修改中。
    /// </summary>
    /// <remarks>
    /// 加法、集合并集等可交换修改应在此合并；两个不相容的 Set 修改应返回
    /// <see langword="false"/>，由阶段运行器报告写冲突。
    /// </remarks>
    bool TryMerge(
        IStageDelta<TState> later,
        out IStageDelta<TState>? merged);

    /// <summary>
    /// 将修改应用到提交候选状态，并返回后续提交操作应继续使用的状态。
    /// </summary>
    TState Apply(TState state, StageCommitContext context);
}

/// <summary>
/// 表示关系、移动、创建实体等不能简化为字段赋值的领域命令。
/// </summary>
public interface IStageCommand<TState>
{
    /// <summary>
    /// 执行领域命令，并返回后续提交操作应继续使用的状态。
    /// </summary>
    TState Execute(TState state, StageCommitContext context);
}

/// <summary>
/// 标记应在阶段成功提交后发布的事件或通知。
/// </summary>
public interface IStageEvent
{
}

/// <summary>
/// 提供提交期间的版本信息和事件发件箱。
/// </summary>
public sealed class StageCommitContext
{
    private readonly List<OrderedStageEvent> _events;

    internal StageCommitContext(
        string stageName,
        long sourceVersion,
        long targetVersion,
        List<OrderedStageEvent> events)
    {
        StageName = stageName;
        SourceVersion = sourceVersion;
        TargetVersion = targetVersion;
        _events = events;
    }

    /// <summary>
    /// 获取当前提交的阶段名称。
    /// </summary>
    public string StageName { get; }

    /// <summary>
    /// 获取阶段读取的快照版本。
    /// </summary>
    public long SourceVersion { get; }

    /// <summary>
    /// 获取提交成功后生成的版本。
    /// </summary>
    public long TargetVersion { get; }

    /// <summary>
    /// 将提交阶段产生的事件加入发件箱。
    /// </summary>
    public void EmitEvent(StageOrderKey orderKey, IStageEvent stageEvent)
    {
        ArgumentNullException.ThrowIfNull(stageEvent);
        _events.Add(new OrderedStageEvent(orderKey, stageEvent));
    }
}

/// <summary>
/// 表示同一阶段有两个不能合并的修改写入了同一字段或组件。
/// </summary>
public sealed class StageWriteConflictException : InvalidOperationException
{
    internal StageWriteConflictException(
        string stageName,
        StageMutationKey mutationKey,
        StageOrderKey firstWriter,
        StageOrderKey secondWriter)
        : base(
            $"阶段“{stageName}”中的修改 {mutationKey} 存在写冲突：" +
            $"{firstWriter} 与 {secondWriter} 无法合并。")
    {
        StageName = stageName;
        MutationKey = mutationKey;
        FirstWriter = firstWriter;
        SecondWriter = secondWriter;
    }

    public string StageName { get; }

    public StageMutationKey MutationKey { get; }

    public StageOrderKey FirstWriter { get; }

    public StageOrderKey SecondWriter { get; }
}

internal readonly record struct OrderedStageEvent(
    StageOrderKey OrderKey,
    IStageEvent Value);
