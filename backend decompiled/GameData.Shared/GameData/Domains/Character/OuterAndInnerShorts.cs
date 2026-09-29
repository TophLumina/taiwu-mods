using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

[Serializable]
public struct OuterAndInnerShorts : ISerializableGameData
{
	public short Outer;

	public short Inner;

	public short Average => (short)((Outer + Inner) / 2);

	public OuterAndInnerShorts(short outer, short inner)
	{
		Outer = outer;
		Inner = inner;
	}

	public readonly void Deconstruct(out short outer, out short inner)
	{
		outer = Outer;
		inner = Inner;
	}

	public int Get(bool inner)
	{
		if (!inner)
		{
			return Outer;
		}
		return Inner;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 4;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = Outer;
		((short*)pData)[1] = Inner;
		return 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		Outer = *(short*)pData;
		Inner = ((short*)pData)[1];
		return 4;
	}
}
