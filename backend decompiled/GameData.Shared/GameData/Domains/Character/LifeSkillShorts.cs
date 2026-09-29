using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Serializer;
using Redzen.Random;

namespace GameData.Domains.Character;

[Serializable]
public struct LifeSkillShorts : ISerializableGameData, ISerializable
{
	public unsafe fixed short Items[16];

	public unsafe ref short this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 16)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{16})");
			}
			return ref Items[index];
		}
	}

	public short Get(int index)
	{
		return this[index];
	}

	public short Set(int index, short value)
	{
		return this[index] = value;
	}

	public short Change(int index, short delta)
	{
		return this[index] += delta;
	}

	public unsafe void Initialize()
	{
		fixed (short* items = Items)
		{
			*(long*)items = 0L;
			((long*)items)[1] = 0L;
			((long*)items)[2] = 0L;
			((long*)items)[3] = 0L;
		}
	}

	public unsafe LifeSkillShorts(params short[] values)
	{
		for (int i = 0; i < 16; i++)
		{
			Items[i] = values[i];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 32;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (short* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((long*)pData)[1] = ((long*)pItems)[1];
			((long*)pData)[2] = ((long*)pItems)[2];
			((long*)pData)[3] = ((long*)pItems)[3];
		}
		return 32;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (short* items = Items)
		{
			*(long*)items = *(long*)pData;
			((long*)items)[1] = ((long*)pData)[1];
			((long*)items)[2] = ((long*)pData)[2];
			((long*)items)[3] = ((long*)pData)[3];
		}
		return 32;
	}

	public unsafe LifeSkillShorts(SerializationInfo info, StreamingContext context)
	{
		fixed (short* items = Items)
		{
			*(ulong*)items = info.GetUInt64("0");
			((long*)items)[1] = (long)info.GetUInt64("1");
			((long*)items)[2] = (long)info.GetUInt64("2");
			((long*)items)[3] = (long)info.GetUInt64("3");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (short* pItems = Items)
		{
			info.AddValue("0", *(ulong*)pItems);
			info.AddValue("1", ((ulong*)pItems)[1]);
			info.AddValue("2", ((ulong*)pItems)[2]);
			info.AddValue("3", ((ulong*)pItems)[3]);
		}
	}

	public unsafe int GetSum()
	{
		int sum = 0;
		for (int i = 0; i < 16; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	public unsafe LifeSkillShorts Subtract(ref LifeSkillShorts other)
	{
		LifeSkillShorts delta = default(LifeSkillShorts);
		for (int i = 0; i < 16; i++)
		{
			delta.Items[i] = (short)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	public unsafe LifeSkillShorts GetReversed()
	{
		LifeSkillShorts reversed = default(LifeSkillShorts);
		for (int i = 0; i < 16; i++)
		{
			reversed.Items[i] = (short)(-Items[i]);
		}
		return reversed;
	}

	public unsafe short GetMaxLifeSkillValue()
	{
		short max = short.MinValue;
		for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
		{
			if (Items[lifeSkillType] > max)
			{
				max = Items[lifeSkillType];
			}
		}
		return max;
	}

	public unsafe sbyte GetMaxLifeSkillType()
	{
		short max = Items[0];
		sbyte type = 0;
		for (sbyte i = 1; i < 16; i++)
		{
			if (Items[i] > max)
			{
				max = Items[i];
				type = i;
			}
		}
		return type;
	}

	public unsafe sbyte GetMaxLifeSkillType(IRandomSource random)
	{
		short max = short.MinValue;
		for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
		{
			if (Items[lifeSkillType] > max)
			{
				max = Items[lifeSkillType];
			}
		}
		sbyte* selectableTypes = stackalloc sbyte[16];
		int selectableCount = 0;
		for (sbyte lifeSkillType2 = 0; lifeSkillType2 < 16; lifeSkillType2++)
		{
			if (Items[lifeSkillType2] == max)
			{
				selectableTypes[selectableCount] = lifeSkillType2;
				selectableCount++;
			}
		}
		return selectableTypes[random.Next(0, selectableCount)];
	}
}
