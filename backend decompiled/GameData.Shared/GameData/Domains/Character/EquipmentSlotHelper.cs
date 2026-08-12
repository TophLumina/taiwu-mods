using System;
using GameData.Domains.Item;

namespace GameData.Domains.Character;

/// <summary>
/// 装备栏位的辅助方法 <see cref="T:GameData.Domains.Character.EquipmentSlot" />
/// </summary>
public class EquipmentSlotHelper
{
	/// <summary>
	/// 获取指定身体部位的装备栏位
	/// </summary>
	/// <param name="bodyPartType"></param>
	/// <returns></returns>
	public static sbyte GetSlotByBodyPartType(sbyte bodyPartType)
	{
		switch (bodyPartType)
		{
		case 0:
		case 1:
			return 5;
		case 2:
			return 3;
		case 3:
		case 4:
			return 6;
		case 5:
		case 6:
			return 7;
		default:
			return -1;
		}
	}

	/// <summary>
	/// 获取一个装备的装备位置，没有装备的话返回非法值
	/// </summary>
	/// <param name="itemKey"></param>
	/// <param name="equipment"></param>
	/// <returns>传入ItemKey的道具装备的位置，<see cref="T:GameData.Domains.Character.EquipmentSlot" /></returns>
	public static sbyte GetEquipmentSlot(ItemKey itemKey, ItemKey[] equipment)
	{
		for (sbyte i = 0; i < 17; i++)
		{
			if (equipment[i].Equals(itemKey))
			{
				return i;
			}
		}
		return -1;
	}

	/// <summary>
	/// 根据槽位获取装备类型
	/// </summary>
	/// <param name="slot"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
	public static sbyte GetSlotItemType(sbyte slot)
	{
		switch (slot)
		{
		case 0:
		case 1:
		case 2:
			return 0;
		case 3:
			return 1;
		case 4:
			return 3;
		case 5:
			return 1;
		case 6:
			return 1;
		case 7:
			return 1;
		case 8:
		case 9:
		case 10:
		case 14:
		case 15:
		case 16:
			return 2;
		case 11:
		case 12:
		case 13:
			return 4;
		default:
			throw new ArgumentOutOfRangeException("slot", slot, null);
		}
	}

	/// <summary>
	/// 物品是否符合槽位类型
	/// </summary>
	/// <param name="slot"></param>
	/// <param name="itemKey"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
	public static bool IsItemMeetSlot(sbyte slot, ItemKey itemKey)
	{
		return ItemTemplateHelper.IsItemMeetSlot(itemKey.ItemType, itemKey.TemplateId, slot);
	}
}
