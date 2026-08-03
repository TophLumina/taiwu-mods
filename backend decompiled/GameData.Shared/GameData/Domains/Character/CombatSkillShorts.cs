using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 各种武学类型对应的值
/// </summary>
[Serializable]
public struct CombatSkillShorts : ISerializableGameData, ISerializable
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.CombatSkill.CombatSkillType" />
	/// </summary>
	public unsafe fixed short Items[14];

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
	/// <param name="index">武学类型<see cref="T:GameData.Domains.CombatSkill.CombatSkillType" /></param>
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

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 CombatSkillType.Count == 14.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 从配置表构造对象
	/// </summary>
	/// <param name="values"></param>
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

	/// <summary>
	/// 计算所有值的总和
	/// </summary>
	/// <returns></returns>
	public unsafe int GetSum()
	{
		int sum = 0;
		for (int i = 0; i < 14; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	/// <summary>
	/// 计算并返回两者的差值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public unsafe CombatSkillShorts Subtract(ref CombatSkillShorts other)
	{
		CombatSkillShorts delta = default(CombatSkillShorts);
		for (int i = 0; i < 14; i++)
		{
			delta.Items[i] = (short)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	/// <summary>
	/// 获取倒转了正负号后的对象
	/// </summary>
	public unsafe CombatSkillShorts GetReversed()
	{
		CombatSkillShorts reversed = default(CombatSkillShorts);
		for (int i = 0; i < 14; i++)
		{
			reversed.Items[i] = (short)(-Items[i]);
		}
		return reversed;
	}

	/// <summary>
	/// 获取最大值
	/// </summary>
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

	/// <summary>
	/// 获取最大值的类型
	/// </summary>
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
