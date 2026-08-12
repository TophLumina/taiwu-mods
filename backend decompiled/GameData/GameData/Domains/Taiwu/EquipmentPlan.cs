using System;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true)]
public class EquipmentPlan : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Slots = 0;

		public const ushort WeaponInnerRatios = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Slots", "WeaponInnerRatios" };
	}

	[SerializableGameDataField]
	public ItemKey[] Slots;

	[SerializableGameDataField]
	public sbyte[] WeaponInnerRatios;

	public EquipmentPlan()
	{
		Slots = new ItemKey[17];
		WeaponInnerRatios = new sbyte[3];
		for (int i = 0; i < 17; i++)
		{
			Slots[i] = ItemKey.Invalid;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((Slots == null) ? (totalSize + 2) : (totalSize + (2 + 8 * Slots.Length)));
		totalSize = ((WeaponInnerRatios == null) ? (totalSize + 2) : (totalSize + (2 + WeaponInnerRatios.Length)));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		if (Slots != null)
		{
			int elementsCount = Slots.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Slots[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (WeaponInnerRatios != null)
		{
			int elementsCount2 = WeaponInnerRatios.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData[j] = (byte)WeaponInnerRatios[j];
			}
			pCurrData += elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (Slots == null || Slots.Length != elementsCount)
				{
					Slots = new ItemKey[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ItemKey element = default(ItemKey);
					pCurrData += element.Deserialize(pCurrData);
					Slots[i] = element;
				}
			}
			else
			{
				Slots = null;
			}
		}
		if (fieldCount > 1)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (WeaponInnerRatios == null || WeaponInnerRatios.Length != elementsCount2)
				{
					WeaponInnerRatios = new sbyte[elementsCount2];
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					WeaponInnerRatios[j] = (sbyte)pCurrData[j];
				}
				pCurrData += (int)elementsCount2;
			}
			else
			{
				WeaponInnerRatios = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public void Record(GameData.Domains.Character.Character character)
	{
		ItemKey[] equipment = character.GetEquipment();
		sbyte[] weaponInnerRatios = DomainManager.Taiwu.GetWeaponInnerRatios();
		for (int i = 0; i < 17; i++)
		{
			Slots[i] = equipment[i];
		}
		for (int j = 0; j < WeaponInnerRatios.Length; j++)
		{
			WeaponInnerRatios[j] = weaponInnerRatios[j];
		}
	}

	public bool Apply(DataContext context, GameData.Domains.Character.Character character, bool skipInvalid)
	{
		Inventory inventory = character.GetInventory();
		ItemKey[] equipment = character.GetEquipment();
		ItemKey[] newEquipments = new ItemKey[17];
		Array.Fill(newEquipments, ItemKey.Invalid);
		for (int i = 0; i < 17; i++)
		{
			ItemKey itemKey = GetEquipmentAtSlot(i);
			ItemKey prevEquippedItemKey = equipment[i];
			if (prevEquippedItemKey.ItemType == 3 && Config.Clothing.Instance[prevEquippedItemKey.TemplateId].AgeGroup != 2)
			{
				newEquipments[i] = prevEquippedItemKey;
				continue;
			}
			if (!itemKey.IsValid() && skipInvalid)
			{
				itemKey = prevEquippedItemKey;
			}
			if (itemKey.IsValid() && newEquipments.Exist(itemKey))
			{
				itemKey = ItemKey.Invalid;
			}
			newEquipments[i] = itemKey;
		}
		bool isModified = !CollectionUtils.Equals(equipment, newEquipments, 17);
		character.ChangeEquipment(context, newEquipments);
		if (character.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
		{
			sbyte[] weaponInnerRatios = DomainManager.Taiwu.GetWeaponInnerRatios();
			for (int j = 0; j < WeaponInnerRatios.Length; j++)
			{
				weaponInnerRatios[j] = WeaponInnerRatios[j];
			}
			DomainManager.Taiwu.SetWeaponInnerRatios(weaponInnerRatios, context);
		}
		return isModified;
		ItemKey GetEquipmentAtSlot(int index)
		{
			ItemKey itemKeyInPlan = Slots[index];
			if (!itemKeyInPlan.IsValid())
			{
				return ItemKey.Invalid;
			}
			if (!DomainManager.Item.ItemExists(itemKeyInPlan))
			{
				return ItemKey.Invalid;
			}
			EquipmentBase equipmentBase = DomainManager.Item.GetBaseEquipment(itemKeyInPlan);
			ItemKey itemKey2 = equipmentBase.GetItemKey();
			if (!inventory.Items.ContainsKey(itemKey2) && !equipment.Exist(itemKey2))
			{
				return ItemKey.Invalid;
			}
			return itemKey2;
		}
	}
}
