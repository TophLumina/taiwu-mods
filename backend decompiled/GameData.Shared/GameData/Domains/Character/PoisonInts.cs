using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Character;

[Serializable]
public struct PoisonInts : ISerializableGameData, ISerializable, IEnumerable<(sbyte Type, int Amount)>, IEnumerable
{
	public const int DisplayAsImmune = -2;

	public const int DisplayAsResist = -1;

	public unsafe fixed int Items[6];

	public unsafe ref int this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 6)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{(sbyte)6})");
			}
			return ref Items[index];
		}
	}

	public unsafe void Initialize()
	{
		fixed (int* items = Items)
		{
			*(long*)items = 0L;
			((long*)items)[1] = 0L;
			((long*)items)[2] = 0L;
		}
	}

	public unsafe PoisonInts(params int[] poisons)
	{
		for (int i = 0; i < 6; i++)
		{
			Items[i] = poisons[i];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 24;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (int* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((long*)pData)[1] = ((long*)pItems)[1];
			((long*)pData)[2] = ((long*)pItems)[2];
		}
		return 24;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (int* items = Items)
		{
			*(long*)items = *(long*)pData;
			((long*)items)[1] = ((long*)pData)[1];
			((long*)items)[2] = ((long*)pData)[2];
		}
		return 24;
	}

	public unsafe PoisonInts(SerializationInfo info, StreamingContext context)
	{
		fixed (int* items = Items)
		{
			*(ulong*)items = info.GetUInt64("0");
			((long*)items)[1] = (long)info.GetUInt64("1");
			((long*)items)[2] = (long)info.GetUInt64("2");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (int* pItems = Items)
		{
			info.AddValue("0", *(ulong*)pItems);
			info.AddValue("1", ((ulong*)pItems)[1]);
			info.AddValue("2", ((ulong*)pItems)[2]);
		}
	}

	public IEnumerator<(sbyte, int)> GetEnumerator()
	{
		for (sbyte i = 0; i < 6; i++)
		{
			yield return (i, this[i]);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerable<string> GetDesc(LanguageKey key = LanguageKey.LK_CharacterMenu_PoisonAccumulator_EatPoisonedItem_Content_Detail, Func<sbyte, string> nameFunc = null)
	{
		if (nameFunc == null)
		{
			nameFunc = DefaultPoisonNameWithIcon;
		}
		return from item in this
			where item.Amount != 0
			select LocalStringManager.GetFormat(LanguageKey.LK_CharacterMenu_PoisonAccumulator_EatPoisonedItem_Content_Detail, nameFunc(item.Type), item.Amount);
	}

	private static string DefaultPoisonNameWithIcon(sbyte ty)
	{
		return $"<SpName=ui9_mousetip_icon_poison_{ty}_0>{LocalStringManager.Get($"LK_Poison_Name_{ty}")}";
	}

	public unsafe void Add(PoisonShorts delta)
	{
		for (int i = 0; i < 6; i++)
		{
			int value = Items[i] + delta.Items[i];
			if (value < 0)
			{
				value = 0;
			}
			Items[i] = value;
		}
	}

	public unsafe void Add(ref PoisonInts delta)
	{
		for (int i = 0; i < 6; i++)
		{
			int value = Items[i] + delta.Items[i];
			if (value < 0)
			{
				value = 0;
			}
			Items[i] = value;
		}
	}

	public unsafe PoisonInts Subtract(ref PoisonInts other)
	{
		PoisonInts delta = default(PoisonInts);
		for (int i = 0; i < 6; i++)
		{
			delta.Items[i] = Items[i] - other.Items[i];
		}
		return delta;
	}

	public unsafe PoisonInts GetReversed()
	{
		PoisonInts reversed = default(PoisonInts);
		for (int i = 0; i < 6; i++)
		{
			reversed.Items[i] = -Items[i];
		}
		return reversed;
	}

	public unsafe bool IsNonZero()
	{
		fixed (int* pItems = Items)
		{
			if (*(long*)pItems != 0L)
			{
				return true;
			}
			if (((long*)pItems)[1] != 0L)
			{
				return true;
			}
			if (((long*)pItems)[2] != 0L)
			{
				return true;
			}
		}
		return false;
	}

	public unsafe sbyte GetLightestType()
	{
		int count = 0;
		sbyte type = 0;
		for (sbyte i = 0; i < 6; i++)
		{
			if (Items[i] < count)
			{
				type = i;
				count = Items[i];
			}
		}
		return type;
	}

	public unsafe int Sum()
	{
		int sum = 0;
		for (int i = 0; i < 6; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	public unsafe int Max()
	{
		int max = 0;
		for (int i = 0; i < 6; i++)
		{
			max = Math.Max(max, Items[i]);
		}
		return max;
	}

	public unsafe bool Equals(PoisonInts other)
	{
		bool result = true;
		for (int i = 0; i < 6; i++)
		{
			if (Items[i] != other.Items[i])
			{
				result = false;
				break;
			}
		}
		return result;
	}

	public unsafe int Get(int index)
	{
		return Items[index];
	}

	public unsafe PoisonsAndLevels GetPoisonsAndLevels()
	{
		PoisonsAndLevels result = default(PoisonsAndLevels);
		result.Initialize();
		for (int i = 0; i < 6; i++)
		{
			result.Values[i] = (short)Items[i];
			result.Levels[i] = PoisonsAndLevels.CalcPoisonedLevel(Items[i]);
		}
		return result;
	}
}
