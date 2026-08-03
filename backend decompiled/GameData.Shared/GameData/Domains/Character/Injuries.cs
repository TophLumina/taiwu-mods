using System;
using System.Runtime.Serialization;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 身体所有部位的伤势
/// </summary>
[Serializable]
public struct Injuries : ISerializableGameData, ISerializable
{
	/// <summary>
	/// 伤势最大等级
	/// </summary>
	public const sbyte MaxLevel = 6;

	/// <summary>
	/// 此对象可以容纳的部位数.
	/// 其实现依赖 BodyPartType.Count == 7.
	/// </summary>
	private const int Capacity = 8;

	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 每个部位占 2 字节, 按顺序为外伤, 内伤.
	/// 排列顺序参见 <see cref="T:GameData.Domains.Combat.BodyPartType" />
	/// </summary>
	public unsafe fixed sbyte Items[16];

	/// <summary>
	/// 是否有任意内伤
	/// </summary>
	public bool AnyInner => HasAnyInjury(isInnerInjury: true);

	/// <summary>
	/// 是否有任意外伤
	/// </summary>
	public bool AnyOuter => HasAnyInjury(isInnerInjury: false);

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 Capacity == 8.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = 0L;
			((long*)items)[1] = 0L;
		}
	}

	/// <summary>
	/// 从配置表构造对象.
	/// 配置格式: `{胸背外伤, 胸背内伤, 腰腹外伤, 腰腹内伤, ...}`.
	/// </summary>
	/// <param name="injuries"></param>
	public unsafe Injuries(params sbyte[] injuries)
	{
		for (int i = 0; i < 14; i++)
		{
			sbyte level = injuries[i];
			if (level > 6)
			{
				throw new Exception("Invalid injury levels: " + string.Join(", ", injuries));
			}
			Items[i] = level;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 16;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (sbyte* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((long*)pData)[1] = ((long*)pItems)[1];
		}
		return 16;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = *(long*)pData;
			((long*)items)[1] = ((long*)pData)[1];
		}
		return 16;
	}

	public unsafe Injuries(SerializationInfo info, StreamingContext context)
	{
		fixed (sbyte* items = Items)
		{
			*(ulong*)items = info.GetUInt64("0");
			((long*)items)[1] = (long)info.GetUInt64("1");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (sbyte* pItems = Items)
		{
			info.AddValue("0", *(ulong*)pItems);
			info.AddValue("1", ((ulong*)pItems)[1]);
		}
	}

	/// <summary>
	/// 获取指定部位的内外伤
	/// </summary>
	/// <param name="bodyPartType"><see cref="T:GameData.Domains.Combat.BodyPartType" /></param>
	/// <returns></returns>
	public unsafe (sbyte outer, sbyte inner) Get(sbyte bodyPartType)
	{
		int index = bodyPartType * 2;
		return (outer: Items[index], inner: Items[index + 1]);
	}

	/// <summary>
	/// 获取指定部位指定类型的伤势
	/// </summary>
	/// <param name="bodyPartType"><see cref="T:GameData.Domains.Combat.BodyPartType" /></param>
	/// <param name="isInnerInjury"></param>
	/// <returns></returns>
	public unsafe sbyte Get(sbyte bodyPartType, bool isInnerInjury)
	{
		return Items[bodyPartType * 2 + (isInnerInjury ? 1 : 0)];
	}

	/// <summary>
	/// 获取所有部位的伤势等级的总和
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
	/// 获取单个部位的伤势等级的总和
	/// </summary>
	/// <param name="bodyPart"></param>
	/// <returns></returns>
	public int GetSum(sbyte bodyPart)
	{
		var (outer, inner) = Get(bodyPart);
		return outer + inner;
	}

	/// <summary>
	/// 获取所有部位的最高级别伤势
	/// </summary>
	/// <returns></returns>
	public unsafe int GetMax()
	{
		int max = 0;
		for (int i = 0; i < 14; i++)
		{
			max = Math.Max(max, Items[i]);
		}
		return max;
	}

	/// <summary>
	/// 获取所有部位的内外伤势等级的总和
	/// </summary>
	/// <returns></returns>
	public (sbyte outer, sbyte inner) GetBothSum()
	{
		sbyte sumOuter = 0;
		sbyte sumInner = 0;
		for (sbyte i = 0; i < 7; i++)
		{
			(sbyte outer, sbyte inner) tuple = Get(i);
			sbyte outer = tuple.outer;
			sbyte inner = tuple.inner;
			sumOuter += outer;
			sumInner += inner;
		}
		return (outer: sumOuter, inner: sumInner);
	}

	/// <summary>
	/// 判断是否有任意伤势
	/// </summary>
	/// <returns></returns>
	public unsafe bool HasAnyInjury()
	{
		fixed (sbyte* pItems = Items)
		{
			if (*(long*)pItems == 0L)
			{
				return ((long*)pItems)[1] != 0;
			}
			return true;
		}
	}

	/// <summary>
	/// 判断是否有任意指定类型的伤势
	/// </summary>
	/// <returns></returns>
	public unsafe bool HasAnyInjury(bool isInnerInjury)
	{
		for (int i = (isInnerInjury ? 1 : 0); i < 14; i += 2)
		{
			if (Items[i] > 0)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 所有部位伤势均已达最大值
	/// </summary>
	public bool AllPartsFully(bool isInnerInjury)
	{
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			if (Get(bodyPart, isInnerInjury) < 6)
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 获取伤势最轻的部位
	/// </summary>
	public sbyte GetLightestPart(bool isInner, bool mustCanChanged = true)
	{
		sbyte lightestInjuryPart = -1;
		sbyte lightestInjuryValue = sbyte.MaxValue;
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			sbyte injuryValue = Get(bodyPart, isInner);
			if ((!mustCanChanged || injuryValue < 6) && injuryValue < lightestInjuryValue)
			{
				lightestInjuryPart = bodyPart;
				lightestInjuryValue = injuryValue;
			}
		}
		return lightestInjuryPart;
	}

	/// <summary>
	/// 设置指定部位和类型的伤势
	/// </summary>
	/// <param name="bodyPartType"></param>
	/// <param name="isInnerInjury"></param>
	/// <param name="value"></param>
	public unsafe void Set(sbyte bodyPartType, bool isInnerInjury, sbyte value)
	{
		int index = bodyPartType * 2 + (isInnerInjury ? 1 : 0);
		Items[index] = MathUtils.Clamp(value, (sbyte)0, (sbyte)6);
	}

	/// <summary>
	/// 改变指定部位和类型的伤势
	/// </summary>
	/// <param name="bodyPartType"></param>
	/// <param name="isInnerInjury"></param>
	/// <param name="delta"></param>
	public unsafe void Change(sbyte bodyPartType, bool isInnerInjury, int delta)
	{
		int index = bodyPartType * 2 + (isInnerInjury ? 1 : 0);
		Items[index] = (sbyte)MathUtils.Clamp(Items[index] + delta, 0, 6);
	}

	/// <summary>
	/// 改变指定部位和类型的伤势
	/// </summary>
	/// <param name="internalIndex">部位和类型的内部索引</param>
	/// <param name="delta"></param>
	public unsafe void Change(int internalIndex, sbyte delta)
	{
		Items[internalIndex] = (sbyte)MathUtils.Clamp(Items[internalIndex] + delta, 0, 6);
	}

	/// <summary>
	/// 直接改变所有伤势值, 忽略伤势免疫
	/// </summary>
	/// <param name="delta"></param>
	public unsafe void Change(Injuries delta)
	{
		for (int i = 0; i < 14; i++)
		{
			Items[i] = (sbyte)MathUtils.Clamp(Items[i] + delta.Items[i], 0, 6);
		}
	}

	/// <summary>
	/// 改变所有伤势值, 考虑伤势免疫
	/// </summary>
	/// <param name="delta"></param>
	/// <param name="outerInjuryImmunity"></param>
	/// <param name="innerInjuryImmunity"></param>
	public unsafe void Change(Injuries delta, bool outerInjuryImmunity, bool innerInjuryImmunity)
	{
		for (int i = 0; i < 7; i++)
		{
			int outerIndex = i * 2;
			if (!outerInjuryImmunity)
			{
				Items[outerIndex] = (sbyte)MathUtils.Clamp(Items[outerIndex] + delta.Items[outerIndex], 0, 6);
			}
			int innerIndex = outerIndex + 1;
			if (!innerInjuryImmunity)
			{
				Items[innerIndex] = (sbyte)MathUtils.Clamp(Items[innerIndex] + delta.Items[innerIndex], 0, 6);
			}
		}
	}

	/// <summary>
	/// 计算并返回两者的差值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public unsafe Injuries Subtract(Injuries other)
	{
		Injuries delta = default(Injuries);
		for (int i = 0; i < 14; i++)
		{
			delta.Items[i] = (sbyte)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	/// <summary>
	/// 获取倒转了正负号后的对象
	/// </summary>
	public unsafe Injuries GetReversed()
	{
		Injuries reversed = default(Injuries);
		for (int i = 0; i < 14; i++)
		{
			reversed.Items[i] = (sbyte)(-Items[i]);
		}
		return reversed;
	}

	/// <summary>
	/// 获取值最小为零的对象
	/// </summary>
	public unsafe Injuries MaxZero()
	{
		Injuries reversed = default(Injuries);
		for (int i = 0; i < 14; i++)
		{
			reversed.Items[i] = Math.Max(Items[i], 0);
		}
		return reversed;
	}

	public unsafe bool Equals(Injuries other)
	{
		bool result = true;
		for (int i = 0; i < 14; i++)
		{
			if (Items[i] != other.Items[i])
			{
				result = false;
				break;
			}
		}
		return result;
	}
}
