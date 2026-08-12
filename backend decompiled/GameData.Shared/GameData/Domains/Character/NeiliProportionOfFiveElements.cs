using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 内力五行属性
/// </summary>
[Serializable]
public struct NeiliProportionOfFiveElements : ISerializableGameData, ISerializable, IEquatable<NeiliProportionOfFiveElements>
{
	/// <summary>
	/// 五行最小值
	/// </summary>
	public const sbyte MinValue = 0;

	/// <summary>
	/// 五行最大值
	/// </summary>
	public const sbyte MaxValue = 100;

	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.CombatSkill.FiveElementsType" />
	/// </summary>
	public unsafe fixed sbyte Items[5];

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
	/// <param name="index">五行类型<see cref="T:GameData.Domains.CombatSkill.FiveElementsType" /></param>
	public unsafe ref sbyte this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 5)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{5})");
			}
			return ref Items[index];
		}
	}

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 FiveElementsType.Count == 5.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (sbyte* items = Items)
		{
			*(int*)items = 0;
			items[4] = 0;
		}
	}

	/// <summary>
	/// 用指定数据初始化对象，用于配置数据的添加
	/// </summary>
	/// <param name="proportions"></param>
	public unsafe NeiliProportionOfFiveElements(params sbyte[] proportions)
	{
		for (int i = 0; i < 5; i++)
		{
			Items[i] = proportions[i];
		}
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
		fixed (sbyte* pItems = Items)
		{
			*(int*)pData = *(int*)pItems;
			((int*)pData)[1] = pItems[4];
		}
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (sbyte* items = Items)
		{
			*(int*)items = *(int*)pData;
			items[4] = (sbyte)(byte)((int*)pData)[1];
		}
		return 8;
	}

	public unsafe NeiliProportionOfFiveElements(SerializationInfo info, StreamingContext context)
	{
		fixed (sbyte* items = Items)
		{
			*(uint*)items = info.GetUInt32("0");
			items[4] = (sbyte)info.GetByte("1");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (sbyte* pItems = Items)
		{
			info.AddValue("0", *(uint*)pItems);
			info.AddValue("1", (byte)pItems[4]);
		}
	}

	/// <inheritdoc />
	public bool Equals(NeiliProportionOfFiveElements other)
	{
		for (int i = 0; i < 5; i++)
		{
			if (this[i] != other[i])
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检查是否为有效值
	/// </summary>
	/// <returns></returns>
	public unsafe bool CheckValid()
	{
		int sum = 0;
		for (int i = 0; i < 5; i++)
		{
			sbyte b = Items[i];
			if ((b < 0 || b > 100) ? true : false)
			{
				return false;
			}
			sum += Items[i];
		}
		return sum == 100;
	}

	/// <summary>
	/// 转移内力五行属性
	/// </summary>
	/// <param name="destType">移入类型</param>
	/// <param name="transferType">转移方式. <see cref="T:GameData.Domains.Character.NeiliProportionTransferType" /></param>
	/// <param name="amount">转移量</param>
	public unsafe void Transfer(sbyte destType, sbyte transferType, int amount)
	{
		Tester.Assert(SumCheck() == 100);
		Tester.Assert(amount > 0);
		sbyte destMaxTransferAmount = (sbyte)(100 - Items[destType]);
		sbyte actualAmount = (sbyte)Math.Min(amount, destMaxTransferAmount);
		if (actualAmount <= 0)
		{
			return;
		}
		sbyte[] sources = GetTransferSources(transferType);
		sbyte currSrcType = destType;
		sbyte leftAmount = actualAmount;
		while (true)
		{
			currSrcType = sources[currSrcType];
			sbyte currAmount = Items[currSrcType];
			if (currAmount >= leftAmount)
			{
				break;
			}
			if (currAmount > 0)
			{
				Items[currSrcType] = 0;
				leftAmount -= currAmount;
			}
		}
		ref sbyte reference = ref Items[currSrcType];
		reference -= leftAmount;
		ref sbyte reference2 = ref Items[destType];
		reference2 += actualAmount;
	}

	/// <summary>
	/// 获取所有五行属性的和
	/// </summary>
	/// <returns></returns>
	public unsafe int Sum()
	{
		int sum = 0;
		for (int i = 0; i < 5; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	/// <summary>
	/// 获取所有五行属性的和，同时检查是否有超出范围的值
	/// </summary>
	/// <returns></returns>
	public unsafe int SumCheck()
	{
		for (int i = 0; i < 5; i++)
		{
			Tester.Assert(Items[i] >= 0 && Items[i] <= 100);
		}
		return Sum();
	}

	/// <summary>
	/// 根据不同的内力五行转移类型, 获取用转移目标类型索引转移来源类型的数组
	/// </summary>
	/// <param name="transferType"></param>
	/// <returns></returns>
	private static sbyte[] GetTransferSources(sbyte transferType)
	{
		return transferType switch
		{
			0 => FiveElementsType.Countered, 
			1 => FiveElementsType.Countering, 
			2 => FiveElementsType.Produced, 
			3 => FiveElementsType.Producing, 
			_ => throw new Exception($"Unsupported NeiliProportionTransferType: {transferType}"), 
		};
	}

	/// <summary>
	/// 根据不同的内力五行转移类型, 获取用转移目标类型索引转移来源类型
	/// </summary>
	/// <param name="transferType"></param>
	/// <param name="destFiveElementType"></param>
	/// <returns></returns>
	public static sbyte GetTransferSource(sbyte transferType, sbyte destFiveElementType)
	{
		return GetTransferSources(transferType)[destFiveElementType];
	}

	/// <summary>
	/// 获取汇总换算比例后的内力五行
	/// </summary>
	/// <param name="array"></param>
	/// <returns></returns>
	public static NeiliProportionOfFiveElements GetTotal(Span<NeiliProportionOfFiveElements> array)
	{
		NeiliProportionOfFiveElements totalElements = default(NeiliProportionOfFiveElements);
		totalElements.Initialize();
		Span<int> sumElements = stackalloc int[5];
		GetSum(array, sumElements);
		int totalValue = 0;
		Span<int> span = sumElements;
		for (int i = 0; i < span.Length; i++)
		{
			int element = span[i];
			totalValue += element;
		}
		if (totalValue > 0)
		{
			for (int j = 0; j < 5; j++)
			{
				totalElements[j] = (sbyte)(sumElements[j] * 100 / totalValue);
			}
		}
		return totalElements;
	}

	/// <summary>
	/// 获取单纯累加后的内力五行
	/// </summary>
	public static void GetSum(Span<NeiliProportionOfFiveElements> array, Span<int> sumElements)
	{
		for (int i = 0; i < sumElements.Length; i++)
		{
			sumElements[i] = 0;
		}
		Span<NeiliProportionOfFiveElements> span = array;
		for (int j = 0; j < span.Length; j++)
		{
			NeiliProportionOfFiveElements fiveElements = span[j];
			for (int k = 0; k < 5; k++)
			{
				sumElements[k] += fiveElements[k];
			}
		}
	}
}
