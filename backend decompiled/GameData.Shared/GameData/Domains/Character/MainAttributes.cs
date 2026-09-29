using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Serializer;

namespace GameData.Domains.Character;

[Serializable]
public struct MainAttributes : ISerializableGameData, ISerializable
{
	public unsafe fixed short Items[6];

	public unsafe ref short this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 6)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{6})");
			}
			return ref Items[index];
		}
	}

	public unsafe void Initialize()
	{
		fixed (short* items = Items)
		{
			*(long*)items = 0L;
			((int*)items)[2] = 0;
		}
	}

	public unsafe MainAttributes(params short[] attributes)
	{
		for (int i = 0; i < 6; i++)
		{
			Items[i] = attributes[i];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 12;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (short* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((int*)pData)[2] = ((int*)pItems)[2];
		}
		return 12;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (short* items = Items)
		{
			*(long*)items = *(long*)pData;
			((int*)items)[2] = ((int*)pData)[2];
		}
		return 12;
	}

	public unsafe MainAttributes(SerializationInfo info, StreamingContext context)
	{
		fixed (short* items = Items)
		{
			*(ulong*)items = info.GetUInt64("0");
			((int*)items)[2] = (int)info.GetUInt32("1");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (short* pItems = Items)
		{
			info.AddValue("0", *(ulong*)pItems);
			info.AddValue("1", ((uint*)pItems)[2]);
		}
	}

	public unsafe int GetSum()
	{
		int sum = 0;
		for (int i = 0; i < 6; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	public unsafe MainAttributes Subtract(MainAttributes other)
	{
		MainAttributes delta = default(MainAttributes);
		for (int i = 0; i < 6; i++)
		{
			delta.Items[i] = (short)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	public unsafe MainAttributes GetReversed()
	{
		MainAttributes reversed = default(MainAttributes);
		for (int i = 0; i < 6; i++)
		{
			reversed.Items[i] = (short)(-Items[i]);
		}
		return reversed;
	}

	public unsafe short Get(sbyte type)
	{
		return Items[type];
	}

	public unsafe bool CheckIsMeet(ref MainAttributes needMainAttributes)
	{
		for (int i = 0; i < 6; i++)
		{
			if (Items[i] < needMainAttributes.Items[i])
			{
				return false;
			}
		}
		return true;
	}

	public unsafe bool CheckIsMeet(sbyte type, int value)
	{
		return Items[type] >= value;
	}
}
