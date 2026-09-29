using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

public struct NeiliAllocation : ISerializableGameData
{
	public unsafe fixed short Items[4];

	public unsafe ref short this[int neiliAllocationType]
	{
		get
		{
			if ((neiliAllocationType < 0 || neiliAllocationType >= 4) ? true : false)
			{
				throw new IndexOutOfRangeException("neiliAllocationType");
			}
			return ref Items[neiliAllocationType];
		}
	}

	public unsafe void Initialize()
	{
		fixed (short* items = Items)
		{
			*(long*)items = 0L;
		}
	}

	public unsafe NeiliAllocation(short val0, short val1, short val2, short val3)
	{
		Items[0] = val0;
		Items[1] = val1;
		Items[2] = val2;
		Items[3] = val3;
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
		fixed (short* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
		}
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (short* items = Items)
		{
			*(long*)items = *(long*)pData;
		}
		return 8;
	}

	public unsafe static bool Equals(NeiliAllocation lhs, NeiliAllocation rhs)
	{
		return *(long*)(&lhs) == *(long*)(&rhs);
	}

	public unsafe short GetTotal()
	{
		return (short)(Items[0] + Items[1] + Items[2] + Items[3]);
	}

	public unsafe NeiliAllocation Subtract(NeiliAllocation other)
	{
		NeiliAllocation delta = default(NeiliAllocation);
		for (int i = 0; i < 4; i++)
		{
			delta.Items[i] = (short)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	public unsafe NeiliAllocation GetReversed()
	{
		NeiliAllocation reversed = default(NeiliAllocation);
		for (int i = 0; i < 4; i++)
		{
			reversed.Items[i] = (short)(-Items[i]);
		}
		return reversed;
	}

	public unsafe NeiliAllocation GetHalf()
	{
		NeiliAllocation half = default(NeiliAllocation);
		for (int i = 0; i < 4; i++)
		{
			half.Items[i] = (short)(Items[i] / 2);
		}
		return half;
	}

	public unsafe byte GetMaxType()
	{
		byte maxType = 0;
		short maxValue = Items[(int)maxType];
		for (byte type = 1; type < 4; type++)
		{
			if (Items[(int)type] > maxValue)
			{
				maxType = type;
				maxValue = Items[(int)type];
			}
		}
		return maxType;
	}

	public unsafe int Sum()
	{
		int sum = 0;
		for (int i = 0; i < 4; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	public unsafe override string ToString()
	{
		return $"NeiliAllocation{{{Items[0]}, {Items[1]}, {Items[2]}, {Items[3]}}}";
	}
}
