namespace TaiwuOptimization.Runtime;

internal readonly struct CompressedBlock
{
    public readonly byte[] Buffer;
    public readonly int Length;

    public CompressedBlock(byte[] buffer, int length)
    {
        Buffer = buffer;
        Length = length;
    }
}
