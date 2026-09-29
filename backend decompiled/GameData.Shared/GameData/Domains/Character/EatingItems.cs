using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

public struct EatingItems : ISerializableGameData
{
	public const int MinCount = 3;

	public const int MaxCount = 9;

	public unsafe fixed ulong ItemKeys[9];

	public unsafe fixed short Durations[9];

	public unsafe void Initialize()
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKeys[i] = (ulong)ItemKey.Invalid;
			Durations[i] = 0;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 90;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		for (int i = 0; i < 9; i++)
		{
			((long*)pCurrData)[i] = (long)ItemKeys[i];
		}
		pCurrData += 72;
		for (int j = 0; j < 9; j++)
		{
			((short*)pCurrData)[j] = Durations[j];
		}
		return 90;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		for (int i = 0; i < 9; i++)
		{
			ItemKeys[i] = ((ulong*)pCurrData)[i];
		}
		pCurrData += 72;
		for (int j = 0; j < 9; j++)
		{
			Durations[j] = ((short*)pCurrData)[j];
		}
		return 90;
	}

	public static bool IsValid(ItemKey itemKey)
	{
		if (!itemKey.IsValid())
		{
			return itemKey.TemplateId >= 0;
		}
		return true;
	}

	public static bool IsWug(ItemKey itemKey)
	{
		if (itemKey.ItemType == 8)
		{
			return Medicine.Instance[itemKey.TemplateId].ItemSubType == 802;
		}
		return false;
	}

	public static bool IsWugKing(ItemKey itemKey)
	{
		if (IsWug(itemKey))
		{
			return Medicine.Instance[itemKey.TemplateId].WugGrowthType == 5;
		}
		return false;
	}

	public static sbyte CalcMaxEatingSlotsCount(int maxVitality)
	{
		return (sbyte)MathUtils.Clamp(maxVitality / 10, 3, 9);
	}

	public unsafe int GetAvailableEatingSlotsCount(sbyte currMaxEatingSlotsCount)
	{
		Tester.Assert(currMaxEatingSlotsCount <= 9);
		int count = 0;
		for (int i = 0; i < currMaxEatingSlotsCount; i++)
		{
			if (!IsValid((ItemKey)ItemKeys[i]))
			{
				count++;
			}
		}
		return count;
	}

	public unsafe sbyte GetAvailableEatingSlot(sbyte currMaxEatingSlotsCount)
	{
		Tester.Assert(currMaxEatingSlotsCount <= 9);
		for (sbyte i = 0; i < currMaxEatingSlotsCount; i++)
		{
			if (!IsValid((ItemKey)ItemKeys[i]))
			{
				return i;
			}
		}
		return -1;
	}

	public unsafe bool Equals(EatingItems other)
	{
		bool result = true;
		for (int i = 0; i < 9; i++)
		{
			if (!ItemKeys[i].Equals(other.ItemKeys[i]) || Durations[i] != other.Durations[i])
			{
				result = false;
				break;
			}
		}
		return result;
	}

	public unsafe int GetValidCount()
	{
		int sum = 0;
		for (int i = 0; i < 9; i++)
		{
			if (IsValid((ItemKey)ItemKeys[i]))
			{
				sum++;
			}
		}
		return sum;
	}

	public ItemKey Get(int index)
	{
		return GetItem(index);
	}

	public unsafe ItemKey GetItem(int index)
	{
		if ((index < 0 || index >= 9) ? true : false)
		{
			throw new IndexOutOfRangeException();
		}
		return (ItemKey)ItemKeys[index];
	}

	public unsafe short GetDuration(int index)
	{
		if ((index < 0 || index >= 9) ? true : false)
		{
			throw new IndexOutOfRangeException();
		}
		return Durations[index];
	}

	public unsafe void Set(int index, ItemKey itemKey, short duration)
	{
		Tester.Assert(IsValid(itemKey));
		ItemKey oriItemKey = (ItemKey)ItemKeys[index];
		if (oriItemKey.IsValid() && !IsWug(oriItemKey))
		{
			throw new Exception("Overwrite item instance");
		}
		ItemKeys[index] = (ulong)itemKey;
		Durations[index] = duration;
	}

	public int GetTotalMedicineEffectValue(EMedicineEffectSubType subType)
	{
		int effectValue = 0;
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = Get(i);
			if (itemKey.IsValid() && itemKey.ItemType == 8)
			{
				MedicineItem config = Medicine.Instance[itemKey.TemplateId];
				if (config.EffectSubType == subType)
				{
					effectValue += config.EffectValue;
				}
			}
		}
		return effectValue;
	}

	public static short GetDeltaWugDuration(sbyte medicineGrade)
	{
		return (short)(-(medicineGrade + 1) * 12);
	}

	public unsafe bool UpdateDurations(List<ItemKey> itemsToBeRemoved, ref List<short> removedWugs, ref List<ItemKey> removedWugKings)
	{
		bool changed = false;
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)ItemKeys[i];
			if (!IsValid(itemKey))
			{
				continue;
			}
			short duration = Durations[i];
			duration = (Durations[i] = (short)(duration - 1));
			changed = true;
			if (duration > 0)
			{
				continue;
			}
			ItemKeys[i] = (ulong)ItemKey.Invalid;
			if (itemKey.IsValid())
			{
				itemsToBeRemoved.Add(itemKey);
			}
			if (IsWug(itemKey))
			{
				if (removedWugs == null)
				{
					removedWugs = new List<short>();
				}
				removedWugs.Add(itemKey.TemplateId);
			}
			if (IsWugKing(itemKey))
			{
				if (removedWugKings == null)
				{
					removedWugKings = new List<ItemKey>();
				}
				removedWugKings.Add(itemKey);
			}
		}
		return SortWugs() || changed;
	}

	public unsafe bool ContainsAny()
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)ItemKeys[i];
			if (itemKey.IsValid() && !IsWug(itemKey))
			{
				return true;
			}
		}
		return false;
	}

	public unsafe bool ContainsWug()
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)ItemKeys[i];
			if (itemKey.IsValid() && IsWug(itemKey))
			{
				return true;
			}
		}
		return false;
	}

	public unsafe bool ContainsWugKing()
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)ItemKeys[i];
			if (itemKey.IsValid() && IsWugKing(itemKey))
			{
				return true;
			}
		}
		return false;
	}

	public unsafe int GetWugKingCount()
	{
		int count = 0;
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)ItemKeys[i];
			if (itemKey.IsValid() && IsWugKing(itemKey))
			{
				count++;
			}
		}
		return count;
	}

	public unsafe bool ContainsWugKing(sbyte wugType)
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)ItemKeys[i];
			if (IsWugKing(itemKey) && Medicine.Instance[itemKey.TemplateId].WugType == wugType)
			{
				return true;
			}
		}
		return false;
	}

	public unsafe int IndexOfWugKing()
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)ItemKeys[i];
			if (itemKey.ItemType == 8 && Medicine.Instance[itemKey.TemplateId].WugGrowthType == 5)
			{
				return i;
			}
		}
		return -1;
	}

	public unsafe sbyte CountOfWugMark()
	{
		int count = 0;
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)ItemKeys[i];
			if (IsWug(itemKey) && !WugGrowthType.IsGood(Medicine.Instance[itemKey.TemplateId].WugGrowthType))
			{
				count++;
			}
		}
		return (sbyte)count;
	}

	public unsafe sbyte GetSlotForNewWug()
	{
		for (sbyte i = 8; i >= 0; i--)
		{
			if (!IsWug((ItemKey)ItemKeys[i]))
			{
				return i;
			}
		}
		return -1;
	}

	public unsafe bool SortWugs()
	{
		bool changed = false;
		SpanList<int> indexes = stackalloc int[9];
		indexes.Clear();
		for (int i = 0; i < 9; i++)
		{
			if (IsWug(Get(i)))
			{
				indexes.Push(i);
			}
		}
		int i2 = 8;
		while (i2 >= 0 && indexes.Count != 0)
		{
			if (!Get(i2).IsValid() || IsWug(Get(i2)))
			{
				int index = indexes.Pop();
				if (index != i2)
				{
					Set(i2, Get(index), Durations[index]);
					Clear(index);
					changed = true;
				}
			}
			i2--;
		}
		return changed;
	}

	public unsafe void Clear(int index)
	{
		ItemKeys[index] = (ulong)ItemKey.Invalid;
		Durations[index] = 0;
	}

	public int IndexOf(ItemKey itemKey)
	{
		for (int i = 0; i < 9; i++)
		{
			if (Get(i).Equals(itemKey))
			{
				return i;
			}
		}
		return -1;
	}

	public int GetDuration(ItemKey itemKey)
	{
		int index = IndexOf(itemKey);
		if (index < 0)
		{
			return 0;
		}
		return GetDuration(index);
	}
}
