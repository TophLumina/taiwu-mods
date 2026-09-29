using System;
using GameData.Domains.Item;

namespace GameData.Domains.Character;

public class EquipmentSlotHelper
{
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

	public static bool IsItemMeetSlot(sbyte slot, ItemKey itemKey)
	{
		return ItemTemplateHelper.IsItemMeetSlot(itemKey.ItemType, itemKey.TemplateId, slot);
	}
}
