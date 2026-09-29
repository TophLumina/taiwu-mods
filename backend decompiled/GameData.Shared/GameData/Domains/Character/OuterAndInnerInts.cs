using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

[Serializable]
public struct OuterAndInnerInts : ISerializableGameData
{
	public int Outer;

	public int Inner;

	public static OuterAndInnerInts Zero => new OuterAndInnerInts(0, 0);

	public bool IsNonZero
	{
		get
		{
			if (Outer == 0)
			{
				return Inner != 0;
			}
			return true;
		}
	}

	public int Sum => Outer + Inner;

	public OuterAndInnerInts(int outer, int inner)
	{
		Outer = outer;
		Inner = inner;
	}

	public readonly void Deconstruct(out int outer, out int inner)
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

	public static implicit operator OuterAndInnerInts((int outer, int inner) tup)
	{
		return new OuterAndInnerInts(tup.outer, tup.inner);
	}

	public static implicit operator OuterAndInnerInts(OuterAndInnerShorts shorts)
	{
		return new OuterAndInnerInts(shorts.Outer, shorts.Inner);
	}

	public static explicit operator OuterAndInnerShorts(OuterAndInnerInts ints)
	{
		short outer = (short)Math.Clamp(ints.Outer, -32768, 32767);
		short inner = (short)Math.Clamp(ints.Inner, -32768, 32767);
		return new OuterAndInnerShorts(outer, inner);
	}

	public static OuterAndInnerInts operator +(OuterAndInnerInts lhs, OuterAndInnerInts rhs)
	{
		return new OuterAndInnerInts(lhs.Outer + rhs.Outer, lhs.Inner + rhs.Inner);
	}

	public static OuterAndInnerInts operator -(OuterAndInnerInts lhs, OuterAndInnerInts rhs)
	{
		return new OuterAndInnerInts(lhs.Outer - rhs.Outer, lhs.Inner - rhs.Inner);
	}

	public static OuterAndInnerInts operator /(OuterAndInnerInts ints, int divisor)
	{
		return new OuterAndInnerInts(ints.Outer / divisor, ints.Inner / divisor);
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 8;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = Outer;
		((int*)pData)[1] = Inner;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		Outer = *(int*)pData;
		Inner = ((int*)pData)[1];
		return 8;
	}
}
