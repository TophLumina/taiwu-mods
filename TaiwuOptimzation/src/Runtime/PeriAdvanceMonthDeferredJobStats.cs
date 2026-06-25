namespace TaiwuOptimization.Runtime;

internal struct PeriAdvanceMonthDeferredJobStats
{
    // NPC 月结行动前的并行任务。
    public int CharacterParallelActionChunks;

    // 破损 map block 倒计时任务块。
    public int MapBrokenBlockUpdates;

    // 野生动物生态 area 更新。
    public int AnimalAreaDataUpdates;

    // 坟墓骷髅生成任务块。
    public int SkeletonGenerations;

    // 地图拾取物清理任务块。
    public int MapPickupCleanups;

    /// <summary>当前统计快照中的总 job 数。</summary>
    public readonly int Total =>
        CharacterParallelActionChunks +
        MapBrokenBlockUpdates +
        AnimalAreaDataUpdates +
        SkeletonGenerations +
        MapPickupCleanups;

    /// <summary>增加一种 job 类型的计数。</summary>
    /// <param name="kind">需要计数的 deferred job 类型。</param>
    public void Count(PeriAdvanceMonthDeferredJobKind kind)
    {
        switch (kind)
        {
            case PeriAdvanceMonthDeferredJobKind.CharacterParallelActionChunk:
                CharacterParallelActionChunks++;
                break;
            case PeriAdvanceMonthDeferredJobKind.MapBrokenBlockUpdate:
                MapBrokenBlockUpdates++;
                break;
            case PeriAdvanceMonthDeferredJobKind.AnimalAreaData:
                AnimalAreaDataUpdates++;
                break;
            case PeriAdvanceMonthDeferredJobKind.SkeletonGeneration:
                SkeletonGenerations++;
                break;
            case PeriAdvanceMonthDeferredJobKind.MapPickupCleanup:
                MapPickupCleanups++;
                break;
        }
    }

    /// <summary>将另一组计数合并到当前计数中。</summary>
    /// <param name="other">需要合并的计数。</param>
    public void Add(in PeriAdvanceMonthDeferredJobStats other)
    {
        CharacterParallelActionChunks += other.CharacterParallelActionChunks;
        MapBrokenBlockUpdates += other.MapBrokenBlockUpdates;
        AnimalAreaDataUpdates += other.AnimalAreaDataUpdates;
        SkeletonGenerations += other.SkeletonGenerations;
        MapPickupCleanups += other.MapPickupCleanups;
    }

    /// <summary>将分组计数格式化为紧凑的日志字段。</summary>
    public readonly string ToLogString() =>
        "CharacterParallelActionChunk=" + CharacterParallelActionChunks +
        ",MapBrokenBlockUpdate=" + MapBrokenBlockUpdates +
        ",AnimalAreaData=" + AnimalAreaDataUpdates +
        ",SkeletonGeneration=" + SkeletonGenerations +
        ",MapPickupCleanup=" + MapPickupCleanups;
}
