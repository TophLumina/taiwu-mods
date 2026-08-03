namespace GameData.Common.Binary;

public struct BinaryModification(sbyte type, int offset, int size)
{
	public sbyte Type = type;

	public int Offset = offset;

	public int Size = size;
}
