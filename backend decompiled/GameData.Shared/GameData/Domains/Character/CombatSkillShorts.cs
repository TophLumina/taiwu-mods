using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Serializer;

namespace GameData.Domains.Character;

[Serializable]
public struct CombatSkillShorts : ISerializableGameData, ISerializable
{
	public unsafe fixed short Items[14];

	public unsafe ref short this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 14)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{14})");
			}
			return ref Items[index];
		}
	}

	public unsafe void Initialize()
	{
		fixed (short* items = Items)
		{
			*(long*)items = 0L;
			((long*)items)[1] = 0L;
			((long*)items)[2] = 0L;
			*(int*)((byte*)items + (nint)3 * (nint)8) = 0;
		}
	}

	public unsafe CombatSkillShorts(params short[] values)
	{
		for (int i = 0; i < 14; i++)
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
		return 28;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (short* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((long*)pData)[1] = ((long*)pItems)[1];
			((long*)pData)[2] = ((long*)pItems)[2];
			*(int*)(pData + (nint)3 * (nint)8) = *(int*)((byte*)pItems + (nint)3 * (nint)8);
		}
		return 28;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (short* items = Items)
		{
			*(long*)items = *(long*)pData;
			((long*)items)[1] = ((long*)pData)[1];
			((long*)items)[2] = ((long*)pData)[2];
			*(int*)((byte*)items + (nint)3 * (nint)8) = *(int*)(pData + (nint)3 * (nint)8);
		}
		return 28;
	}

	public unsafe CombatSkillShorts(SerializationInfo info, StreamingContext context)
	{
		fixed (short* items = Items)
		{
			*(ulong*)items = info.GetUInt64("0");
			((long*)items)[1] = (long)info.GetUInt64("1");
			((long*)items)[2] = (long)info.GetUInt64("2");
			*(uint*)((byte*)items + (nint)3 * (nint)8) = info.GetUInt32("3");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (short* pItems = Items)
		{
			info.AddValue("0", *(ulong*)pItems);
			info.AddValue("1", ((ulong*)pItems)[1]);
			info.AddValue("2", ((ulong*)pItems)[2]);
			info.AddValue("3", *(uint*)((byte*)pItems + (nint)3 * (nint)8));
		}
	}

	public unsafe int GetSum()
	{
		int sum = 0;
		for (int i = 0; i < 14; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	public unsafe CombatSkillShorts Subtract(ref CombatSkillShorts other)
	{
		CombatSkillShorts delta = default(CombatSkillShorts);
		for (int i = 0; i < 14; i++)
		{
			delta.Items[i] = (short)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	public unsafe CombatSkillShorts GetReversed()
	{
		CombatSkillShorts reversed = default(CombatSkillShorts);
		for (int i = 0; i < 14; i++)
		{
			reversed.Items[i] = (short)(-Items[i]);
		}
		return reversed;
	}

	public unsafe short GetMaxCombatSkillValue()
	{
		short max = short.MinValue;
		for (sbyte combatSkillType = 0; combatSkillType < 14; combatSkillType++)
		{
			if (Items[combatSkillType] > max)
			{
				max = Items[combatSkillType];
			}
		}
		return max;
	}

	public unsafe sbyte GetMaxCombatSkillType()
	{
		short max = short.MinValue;
		sbyte type = 0;
		for (sbyte combatSkillType = 0; combatSkillType < 14; combatSkillType++)
		{
			if (Items[combatSkillType] > max)
			{
				max = Items[combatSkillType];
				type = combatSkillType;
			}
		}
		return type;
	}
}
