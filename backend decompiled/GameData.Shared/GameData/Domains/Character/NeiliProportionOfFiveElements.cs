using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

[Serializable]
public struct NeiliProportionOfFiveElements : ISerializableGameData, ISerializable, IEquatable<NeiliProportionOfFiveElements>
{
	public const sbyte MinValue = 0;

	public const sbyte MaxValue = 100;

	public unsafe fixed sbyte Items[5];

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

	public unsafe void Initialize()
	{
		fixed (sbyte* items = Items)
		{
			*(int*)items = 0;
			items[4] = 0;
		}
	}

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

	public unsafe int Sum()
	{
		int sum = 0;
		for (int i = 0; i < 5; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	public unsafe int SumCheck()
	{
		for (int i = 0; i < 5; i++)
		{
			Tester.Assert(Items[i] >= 0 && Items[i] <= 100);
		}
		return Sum();
	}

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

	public static sbyte GetTransferSource(sbyte transferType, sbyte destFiveElementType)
	{
		return GetTransferSources(transferType)[destFiveElementType];
	}

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
