using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 服食物品列表
/// </summary>
public struct EatingItems : ISerializableGameData
{
	/// <summary>
	/// 服食物品最小栏位数 (硬性限制)
	/// </summary>
	public const int MinCount = 3;

	/// <summary>
	/// 服食物品最大栏位数 (硬性限制)
	/// </summary>
	public const int MaxCount = 9;

	/// <summary>
	/// 服食物品 Key.
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// </summary>
	public unsafe fixed ulong ItemKeys[9];

	/// <summary>
	/// 服食物品的剩余持续时间.
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// </summary>
	public unsafe fixed short Durations[9];

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 判断指定栏位上的物品是否有效 (为实例物品或蛊虫).
	/// ItemKey.IsValid() 为 false, 但 TemplateId 大于等于 0 时, 表示蛊虫.
	/// </summary>
	/// <param name="itemKey"></param>
	/// <returns></returns>
	public static bool IsValid(ItemKey itemKey)
	{
		if (!itemKey.IsValid())
		{
			return itemKey.TemplateId >= 0;
		}
		return true;
	}

	/// <summary>
	/// 判断指定栏位上的物品是否蛊虫.
	/// </summary>
	/// <param name="itemKey"></param>
	/// <returns></returns>
	public static bool IsWug(ItemKey itemKey)
	{
		if (itemKey.ItemType == 8)
		{
			return Medicine.Instance[itemKey.TemplateId].ItemSubType == 802;
		}
		return false;
	}

	/// <summary>
	/// 判断指定栏位上的物品是否蛊王
	/// </summary>
	/// <param name="itemKey"></param>
	/// <returns></returns>
	public static bool IsWugKing(ItemKey itemKey)
	{
		if (IsWug(itemKey))
		{
			return Medicine.Instance[itemKey.TemplateId].WugGrowthType == 5;
		}
		return false;
	}

	/// <summary>
	/// 计算最大服食栏位
	/// </summary>
	/// <param name="maxVitality">体质值上限</param>
	/// <returns></returns>
	public static sbyte CalcMaxEatingSlotsCount(int maxVitality)
	{
		return (sbyte)MathUtils.Clamp(maxVitality / 10, 3, 9);
	}

	/// <summary>
	/// 获取可用的服食栏位数
	/// </summary>
	/// <param name="currMaxEatingSlotsCount"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取可用服食栏位 (按索引从小到大的顺序)
	/// </summary>
	/// <param name="currMaxEatingSlotsCount"></param>
	/// <returns>为 -1 表示无可用栏位</returns>
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

	/// <summary>
	/// 获取指定栏位上的已服食物品
	/// </summary>
	public ItemKey Get(int index)
	{
		return GetItem(index);
	}

	/// <summary>
	/// 获取指定栏位上的已服食物品
	/// </summary>
	public unsafe ItemKey GetItem(int index)
	{
		if ((index < 0 || index >= 9) ? true : false)
		{
			throw new IndexOutOfRangeException();
		}
		return (ItemKey)ItemKeys[index];
	}

	/// <summary>
	/// 获取指定栏位上的已服食物品的剩余持续时间
	/// </summary>
	public unsafe short GetDuration(int index)
	{
		if ((index < 0 || index >= 9) ? true : false)
		{
			throw new IndexOutOfRangeException();
		}
		return Durations[index];
	}

	/// <summary>
	/// 在指定位置设置新的服食物品.
	/// 若指定位置已有物品实例, 则会抛出异常 (仅蛊虫可以覆盖).
	/// </summary>
	/// <param name="index"></param>
	/// <param name="itemKey"></param>
	/// <param name="duration"></param>
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

	/// <summary>
	/// 获取所有药品的某个子效果数值之和
	/// 需注意，随机疗伤的效果不应该使用这个函数（因为这个函数无法返回每个部位伤口减少的数量）
	/// </summary>
	/// <param name="subType"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 更新服食物品的持续时间.
	/// 当持续时间到 0 之后, 会同时把服食物品从世界上移除.
	/// </summary>
	/// <param name="itemsToBeRemoved">被移除的物品实例</param>
	/// <param name="removedWugs">被移除的蛊虫</param>
	/// <param name="removedWugKings">被移除的王蛊</param>
	/// <returns>数据是否发生改变</returns>
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

	/// <summary>
	/// 服食栏位中是否有任意物品（不含蛊）
	/// </summary>
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

	/// <summary>
	/// 服食栏位中是否有任意蛊虫
	/// </summary>
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

	/// <summary>
	/// 服食栏位中是否有任意王蛊
	/// </summary>
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

	/// <summary>
	/// 服食栏位中的王蛊数量
	/// </summary>
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

	/// <summary>
	/// 是否包含指定类型的王蛊
	/// </summary>
	/// <param name="wugType"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取蛊王所在的栏位
	/// </summary>
	/// <returns>为 -1 表示不存在蛊王</returns>
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

	/// <summary>
	/// 获取蛊虫标记数量
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 获取新蛊虫应放置的栏位
	/// </summary>
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

	/// <summary>
	/// 将蛊虫向后移动填满空槽
	/// </summary>
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

	/// <summary>
	/// 清空指定位置.
	/// </summary>
	/// <param name="index"></param>
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
