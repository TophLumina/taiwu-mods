using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item;

/// <summary>
/// 毒素的量以及等级
/// </summary>
[Serializable]
public struct PoisonsAndLevels : ISerializableGameData, ISerializable, IEquatable<PoisonsAndLevels>
{
	/// <summary>
	/// 最大下毒或解毒等级
	/// </summary>
	public const int MaxLevel = 3;

	/// <summary>
	/// 各种毒素的量.
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Combat.PoisonType" />
	/// </summary>
	public unsafe fixed short Values[6];

	/// <summary>
	/// 各种毒素的下毒或解毒等级.
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Combat.PoisonType" />
	/// </summary>
	public unsafe fixed sbyte Levels[6];

	public bool IsMixed => GetTotalPoisonCount() > 1;

	public bool IsThreeMixed => GetTotalPoisonCount() == FullPoisonEffects.MaxSlotCount;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe short GetValue(int index)
	{
		if (index < 0 || index >= 6)
		{
			throw new IndexOutOfRangeException($"index {index} is out of range [0,{(sbyte)6})");
		}
		return Values[index];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe sbyte GetLevel(int index)
	{
		if (index < 0 || index >= 6)
		{
			throw new IndexOutOfRangeException($"index {index} is out of range [0,{(sbyte)6})");
		}
		return Levels[index];
	}

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 PoisonType.Count == 6.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (short* values = Values)
		{
			*(long*)values = 0L;
			((int*)values)[2] = 0;
		}
		fixed (sbyte* levels = Levels)
		{
			*(int*)levels = 0;
			((short*)levels)[2] = 0;
		}
	}

	/// <summary>
	/// 从配置表构造对象
	/// </summary>
	/// <param name="poisons"></param>
	public unsafe PoisonsAndLevels(params short[] poisons)
	{
		for (int i = 0; i < 6; i++)
		{
			Values[i] = poisons[i * 2];
			Levels[i] = (sbyte)poisons[i * 2 + 1];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 18;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (short* pValues = Values)
		{
			*(long*)pData = *(long*)pValues;
			((int*)pData)[2] = ((int*)pValues)[2];
		}
		fixed (sbyte* pLevels = Levels)
		{
			((int*)pData)[3] = *(int*)pLevels;
			((short*)pData)[8] = ((short*)pLevels)[2];
		}
		return 18;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (short* values = Values)
		{
			*(long*)values = *(long*)pData;
			((int*)values)[2] = ((int*)pData)[2];
		}
		fixed (sbyte* levels = Levels)
		{
			*(int*)levels = ((int*)pData)[3];
			((short*)levels)[2] = ((short*)pData)[8];
		}
		return 18;
	}

	public unsafe PoisonsAndLevels(SerializationInfo info, StreamingContext context)
	{
		fixed (short* values = Values)
		{
			*(ulong*)values = info.GetUInt64("0");
			((int*)values)[2] = (int)info.GetUInt32("1");
		}
		fixed (sbyte* levels = Levels)
		{
			*(uint*)levels = info.GetUInt32("2");
			((short*)levels)[2] = (short)info.GetUInt16("3");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (short* pValues = Values)
		{
			info.AddValue("0", *(ulong*)pValues);
			info.AddValue("1", ((uint*)pValues)[2]);
		}
		fixed (sbyte* pLevels = Levels)
		{
			info.AddValue("2", *(uint*)pLevels);
			info.AddValue("3", ((ushort*)pLevels)[2]);
		}
	}

	/// <summary>
	/// 根据毒素变化量、毒素级别、以及当前中毒量和毒抗计算毒素变化量.
	/// </summary>
	/// <param name="baseDelta">基础变化量</param>
	/// <param name="level">毒素等级, 1 为生毒, 2 为剧毒, 3 为奇毒</param>
	/// <param name="currPoisonedValue">当前中毒量</param>
	/// <param name="poisonResist">当前毒抗值</param>
	/// <returns>毒素变化量</returns>
	public static int CalcPoisonDelta(int baseDelta, sbyte level, int currPoisonedValue, int poisonResist)
	{
		sbyte currPoisonedLevel = CalcPoisonedLevel(currPoisonedValue);
		if (baseDelta <= 0)
		{
			if (level < currPoisonedLevel)
			{
				return 0;
			}
			return baseDelta;
		}
		int delta = 0;
		int effectiveDelta = baseDelta - baseDelta * poisonResist / 1000;
		effectiveDelta = CalcEffectivePoison(effectiveDelta, level, currPoisonedLevel);
		while (effectiveDelta > 0)
		{
			int threshold = ((currPoisonedLevel == 3) ? int.MaxValue : GlobalConfig.Instance.PoisonLevelThresholds[currPoisonedLevel]);
			if (effectiveDelta + currPoisonedValue > threshold)
			{
				int currDelta = threshold - currPoisonedValue;
				effectiveDelta -= currDelta;
				delta += currDelta;
				currPoisonedValue = threshold;
				if (currPoisonedLevel < 3)
				{
					currPoisonedLevel++;
				}
				if (currPoisonedLevel >= level)
				{
					if (currPoisonedLevel >= level + 3 - 1)
					{
						return delta;
					}
					effectiveDelta /= 3;
				}
				continue;
			}
			return delta + effectiveDelta;
		}
		return delta;
	}

	private static int CalcEffectivePoison(int poisonValue, int poisonLevel, int currPoisonedLevel)
	{
		return (currPoisonedLevel - poisonLevel) switch
		{
			0 => poisonValue / 3, 
			1 => poisonValue / 9, 
			2 => 0, 
			_ => poisonValue, 
		};
	}

	public static short CalcApplyItemPoisonAmount(short value, sbyte level)
	{
		return (short)(value * level * GlobalConfig.Instance.CalcApplyItemPoisonParam);
	}

	/// <summary>
	/// 计算指定中毒量对于该角色的中毒等级
	/// 事件代码中有调用
	/// </summary>
	/// <param name="poisoned"></param>
	/// <returns></returns>
	public static sbyte CalcPoisonedLevel(int poisoned)
	{
		short[] thresholds = GlobalConfig.Instance.PoisonLevelThresholds;
		if (poisoned >= thresholds[2])
		{
			return 3;
		}
		if (poisoned >= thresholds[1])
		{
			return 2;
		}
		if (poisoned >= thresholds[0])
		{
			return 1;
		}
		return 0;
	}

	/// <summary>
	/// 判断毒素值和等级对应的道具级别
	/// </summary>
	/// <returns><see cref="T:GameData.Domains.Character.Grade" /></returns>
	public static sbyte CalcGradeByPoisonAndLevel(short value, sbyte level)
	{
		int num = level - 1;
		int modResult = value / (10 * (1 << level - 1)) - 1;
		return (sbyte)MathUtils.Clamp(num * 3 + modResult, 0, 8);
	}

	/// <summary>
	/// 判断指定毒素类型的毒素值和等级对应的道具级别
	/// </summary>
	/// <returns><see cref="T:GameData.Domains.Character.Grade" /></returns>
	public unsafe sbyte GetGrade(sbyte poisonType)
	{
		if (Values[poisonType] <= 0 || Levels[poisonType] <= 0)
		{
			return -1;
		}
		return CalcGradeByPoisonAndLevel(Values[poisonType], Levels[poisonType]);
	}

	/// <summary>
	/// 获取混合毒的ID，不是三种混合时为-1
	/// </summary>
	/// <returns></returns>
	public short GetMixTemplateId()
	{
		if (!IsMixed)
		{
			return -1;
		}
		return MixedPoisonType.PoisonsAndLevelToMedicineTemplateId(ref this);
	}

	/// <summary>
	/// 是否含有非零值 (只检查值, 不检查等级)
	/// </summary>
	/// <returns></returns>
	public unsafe bool IsNonZero()
	{
		fixed (short* pValues = Values)
		{
			if (*(long*)pValues != 0L)
			{
				return true;
			}
			if (((uint*)pValues)[2] != 0)
			{
				return true;
			}
		}
		return false;
	}

	public unsafe void Add(PoisonsAndLevels other)
	{
		for (int i = 0; i < 6; i++)
		{
			if (Levels[i] == other.Levels[i])
			{
				int value = Values[i] + other.Values[i];
				if (value > 25000)
				{
					value = 25000;
				}
				Values[i] = (short)value;
			}
			else if (Levels[i] < other.Levels[i])
			{
				Levels[i] = other.Levels[i];
				Values[i] = other.Values[i];
			}
		}
	}

	public unsafe bool Equals(PoisonsAndLevels other)
	{
		for (int i = 0; i < 6; i++)
		{
			if (Values[i] != other.Values[i])
			{
				return false;
			}
			if (Levels[i] != other.Levels[i])
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 获取指定类型毒素的量与级别
	/// </summary>
	/// <param name="poisonType"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
	public unsafe readonly (short value, sbyte level) GetValueAndLevel(sbyte poisonType)
	{
		if ((poisonType < 0 || poisonType >= 6) ? true : false)
		{
			throw new ArgumentOutOfRangeException("poisonType");
		}
		return (value: Values[poisonType], level: Levels[poisonType]);
	}

	/// <summary>
	/// 获取毒的种类数量
	/// </summary>
	/// <returns></returns>
	public unsafe sbyte GetTotalPoisonCount()
	{
		sbyte poisonCount = 0;
		for (int i = 0; i < 6; i++)
		{
			if (Values[i] > 0)
			{
				poisonCount++;
			}
		}
		return poisonCount;
	}

	/// <summary>
	/// 获取毒素等级的总合
	/// </summary>
	/// <returns></returns>
	public unsafe sbyte GetTotalLevel()
	{
		sbyte totalLevel = 0;
		for (int i = 0; i < 6; i++)
		{
			totalLevel += Levels[i];
		}
		return totalLevel;
	}
}
