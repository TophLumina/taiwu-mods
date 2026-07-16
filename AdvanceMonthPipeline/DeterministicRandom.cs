namespace Taiwu.AdvanceMonthPipeline;

/// <summary>
/// 提供不依赖任务调度顺序的实体级随机数流。
/// </summary>
public sealed class DeterministicRandom
{
    private ulong _state;

    public DeterministicRandom(ulong seed)
    {
        _state = seed;
    }

    /// <summary>
    /// 生成下一个 64 位无符号随机数。
    /// </summary>
    public ulong NextUInt64()
    {
        _state += 0x9E3779B97F4A7C15UL;
        return Mix(_state);
    }

    /// <summary>
    /// 生成一个位于零和指定上界之间的整数。
    /// </summary>
    public int NextInt32(int exclusiveMax)
    {
        if (exclusiveMax <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(exclusiveMax),
                exclusiveMax,
                "随机数上界必须大于零。");
        }

        ulong bound = (uint)exclusiveMax;
        ulong threshold = unchecked(0UL - bound) % bound;
        ulong value;
        do
        {
            value = NextUInt64();
        }
        while (value < threshold);

        return (int)(value % bound);
    }

    /// <summary>
    /// 生成一个位于指定半开区间内的整数。
    /// </summary>
    public int NextInt32(int inclusiveMin, int exclusiveMax)
    {
        if (exclusiveMax <= inclusiveMin)
        {
            throw new ArgumentOutOfRangeException(
                nameof(exclusiveMax),
                exclusiveMax,
                "随机数上界必须大于下界。");
        }

        long width = (long)exclusiveMax - inclusiveMin;
        if (width > int.MaxValue)
        {
            throw new ArgumentOutOfRangeException(
                nameof(exclusiveMax),
                exclusiveMax,
                "当前原型仅支持不超过 Int32.MaxValue 的随机区间。");
        }

        return inclusiveMin + NextInt32((int)width);
    }

    /// <summary>
    /// 为指定月份、阶段和实体派生独立随机种子。
    /// </summary>
    public static ulong DeriveSeed(
        ulong worldSeed,
        long month,
        int stageId,
        long entityId)
    {
        ulong value = Mix(worldSeed ^ 0xA0761D6478BD642FUL);
        value ^= Mix(unchecked((ulong)month) + 0xE7037ED1A0B428DBUL);
        value ^= Mix(unchecked((uint)stageId) + 0x8EBC6AF09C88C6E3UL);
        value ^= Mix(unchecked((ulong)entityId) + 0x589965CC75374CC3UL);
        return Mix(value);
    }

    private static ulong Mix(ulong value)
    {
        value = (value ^ (value >> 30)) * 0xBF58476D1CE4E5B9UL;
        value = (value ^ (value >> 27)) * 0x94D049BB133111EBUL;
        return value ^ (value >> 31);
    }
}
