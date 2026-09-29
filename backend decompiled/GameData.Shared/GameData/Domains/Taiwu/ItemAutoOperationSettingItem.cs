using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

[AutoGenerateSerializableGameData(IsExtensible = true)]
public class ItemAutoOperationSettingItem : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort TargetType = 0;

		public const ushort Grade = 1;

		public const ushort SubtypeList = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "TargetType", "Grade", "SubtypeList" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public EItemAutoOperationTargetType TargetType;

	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte Grade;

	[SerializableGameDataField(FieldIndex = 2)]
	public List<sbyte> SubtypeList = new List<sbyte>();

	public void Init(EItemAutoOperationTargetType targetType)
	{
		TargetType = targetType;
		Grade = 0;
		SubtypeList.Clear();
		int count = GetSubTypeCount(TargetType);
		for (sbyte i = 0; i < count; i++)
		{
			SubtypeList.Add(i);
		}
	}

	public bool Contains(ItemKey itemKey, EItemAutoOperationBookSubtype bookSubtype = EItemAutoOperationBookSubtype.Invalid)
	{
		List<sbyte> subtypeList = SubtypeList;
		if (subtypeList == null || subtypeList.Count <= 0)
		{
			return false;
		}
		sbyte subType = GetItemAutoOperationType(itemKey) switch
		{
			EItemAutoOperationTargetType.Weapon => (sbyte)GetItemAutoOperationWeaponSubtype(itemKey), 
			EItemAutoOperationTargetType.OtherEquipment => (sbyte)GetItemAutoOperationOtherEquipmentSubtype(itemKey), 
			EItemAutoOperationTargetType.Material => (sbyte)GetItemAutoOperationMaterialSubtype(itemKey), 
			EItemAutoOperationTargetType.RefineMaterial => (sbyte)GetItemAutoOperationRefineMaterialSubtype(itemKey), 
			EItemAutoOperationTargetType.Food => (sbyte)GetItemAutoOperationFoodSubtype(itemKey), 
			EItemAutoOperationTargetType.Medicine => (sbyte)GetItemAutoOperationMedicineSubtype(itemKey), 
			EItemAutoOperationTargetType.Tool => (sbyte)GetItemAutoOperationToolSubtype(itemKey), 
			EItemAutoOperationTargetType.Book => (sbyte)bookSubtype, 
			_ => -1, 
		};
		return SubtypeList.Contains(subType);
	}

	public void Reset()
	{
		Init(TargetType);
	}

	public static int GetSubTypeCount(EItemAutoOperationTargetType targetType)
	{
		return targetType switch
		{
			EItemAutoOperationTargetType.Food => 4, 
			EItemAutoOperationTargetType.Medicine => 8, 
			EItemAutoOperationTargetType.Weapon => 16, 
			EItemAutoOperationTargetType.OtherEquipment => 9, 
			EItemAutoOperationTargetType.Book => 3, 
			EItemAutoOperationTargetType.Tool => 7, 
			EItemAutoOperationTargetType.Material => 7, 
			EItemAutoOperationTargetType.RefineMaterial => 4, 
			_ => 0, 
		};
	}

	public static EItemAutoOperationTargetType GetItemAutoOperationType(ItemKey itemKey)
	{
		return itemKey.ItemType switch
		{
			0 => EItemAutoOperationTargetType.Weapon, 
			1 => EItemAutoOperationTargetType.OtherEquipment, 
			2 => EItemAutoOperationTargetType.OtherEquipment, 
			3 => EItemAutoOperationTargetType.OtherEquipment, 
			4 => EItemAutoOperationTargetType.OtherEquipment, 
			5 => (Material.Instance[itemKey.TemplateId].RefiningEffect >= 0) ? EItemAutoOperationTargetType.RefineMaterial : EItemAutoOperationTargetType.Material, 
			6 => EItemAutoOperationTargetType.Tool, 
			7 => EItemAutoOperationTargetType.Food, 
			9 => EItemAutoOperationTargetType.Food, 
			8 => EItemAutoOperationTargetType.Medicine, 
			10 => EItemAutoOperationTargetType.Book, 
			_ => EItemAutoOperationTargetType.Invalid, 
		};
	}

	public static EItemAutoOperationWeaponSubtype GetItemAutoOperationWeaponSubtype(ItemKey itemKey)
	{
		return ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) switch
		{
			0 => EItemAutoOperationWeaponSubtype.NeedleBox, 
			1 => EItemAutoOperationWeaponSubtype.DoubleDaggers, 
			2 => EItemAutoOperationWeaponSubtype.Hidden, 
			3 => EItemAutoOperationWeaponSubtype.Flute, 
			4 => EItemAutoOperationWeaponSubtype.Gloves, 
			5 => EItemAutoOperationWeaponSubtype.Pestle, 
			6 => EItemAutoOperationWeaponSubtype.Whisk, 
			7 => EItemAutoOperationWeaponSubtype.Whip, 
			8 => EItemAutoOperationWeaponSubtype.Sword, 
			9 => EItemAutoOperationWeaponSubtype.Blade, 
			10 => EItemAutoOperationWeaponSubtype.Polearm, 
			11 => EItemAutoOperationWeaponSubtype.Zither, 
			12 => EItemAutoOperationWeaponSubtype.MechanicWeapon, 
			13 => EItemAutoOperationWeaponSubtype.MagicSymbol, 
			14 => EItemAutoOperationWeaponSubtype.PoisonWeaponCream, 
			15 => EItemAutoOperationWeaponSubtype.PoisonWeaponSand, 
			_ => EItemAutoOperationWeaponSubtype.Invalid, 
		};
	}

	public static EItemAutoOperationOtherEquipmentSubtype GetItemAutoOperationOtherEquipmentSubtype(ItemKey itemKey)
	{
		short itemSubType = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
		if (itemKey.ItemType == 3)
		{
			return EItemAutoOperationOtherEquipmentSubtype.Clothing;
		}
		if (itemKey.ItemType == 4)
		{
			return EItemAutoOperationOtherEquipmentSubtype.Carrier;
		}
		return itemSubType switch
		{
			100 => EItemAutoOperationOtherEquipmentSubtype.Helm, 
			101 => EItemAutoOperationOtherEquipmentSubtype.TorsoArmor, 
			102 => EItemAutoOperationOtherEquipmentSubtype.Bracers, 
			103 => EItemAutoOperationOtherEquipmentSubtype.Boots, 
			104 => EItemAutoOperationOtherEquipmentSubtype.AnimalArmor, 
			200 => EItemAutoOperationOtherEquipmentSubtype.Accessory, 
			201 => EItemAutoOperationOtherEquipmentSubtype.Pocket, 
			_ => EItemAutoOperationOtherEquipmentSubtype.Invalid, 
		};
	}

	public static EItemAutoOperationMaterialSubtype GetItemAutoOperationMaterialSubtype(ItemKey itemKey)
	{
		return ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) switch
		{
			504 => EItemAutoOperationMaterialSubtype.Fabric, 
			501 => EItemAutoOperationMaterialSubtype.Wood, 
			503 => EItemAutoOperationMaterialSubtype.Jade, 
			502 => EItemAutoOperationMaterialSubtype.Metal, 
			505 => EItemAutoOperationMaterialSubtype.Herb, 
			506 => EItemAutoOperationMaterialSubtype.Poison, 
			500 => EItemAutoOperationMaterialSubtype.Food, 
			_ => EItemAutoOperationMaterialSubtype.Invalid, 
		};
	}

	public static EItemAutoOperationRefineMaterialSubtype GetItemAutoOperationRefineMaterialSubtype(ItemKey itemKey)
	{
		return ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) switch
		{
			504 => EItemAutoOperationRefineMaterialSubtype.Fabric, 
			501 => EItemAutoOperationRefineMaterialSubtype.Wood, 
			503 => EItemAutoOperationRefineMaterialSubtype.Jade, 
			502 => EItemAutoOperationRefineMaterialSubtype.Metal, 
			_ => EItemAutoOperationRefineMaterialSubtype.Invalid, 
		};
	}

	public static EItemAutoOperationToolSubtype GetItemAutoOperationToolSubtype(ItemKey itemKey)
	{
		return CraftTool.Instance[itemKey.TemplateId].RequiredLifeSkillTypes.First() switch
		{
			6 => EItemAutoOperationToolSubtype.Forging, 
			7 => EItemAutoOperationToolSubtype.Woodworking, 
			8 => EItemAutoOperationToolSubtype.Medicine, 
			9 => EItemAutoOperationToolSubtype.Toxicology, 
			10 => EItemAutoOperationToolSubtype.Weaving, 
			11 => EItemAutoOperationToolSubtype.Jade, 
			14 => EItemAutoOperationToolSubtype.Cooking, 
			_ => EItemAutoOperationToolSubtype.Invalid, 
		};
	}

	public static EItemAutoOperationFoodSubtype GetItemAutoOperationFoodSubtype(ItemKey itemKey)
	{
		return ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) switch
		{
			701 => EItemAutoOperationFoodSubtype.MeatFood, 
			700 => EItemAutoOperationFoodSubtype.VegetarianFood, 
			900 => EItemAutoOperationFoodSubtype.Tea, 
			901 => EItemAutoOperationFoodSubtype.Wine, 
			_ => EItemAutoOperationFoodSubtype.Invalid, 
		};
	}

	public static EItemAutoOperationMedicineSubtype GetItemAutoOperationMedicineSubtype(ItemKey itemKey)
	{
		MedicineItem config = Medicine.Instance[itemKey.TemplateId];
		if (config.BuffAndOtherMedicine == 1)
		{
			return EItemAutoOperationMedicineSubtype.Buff;
		}
		if (config.BuffAndOtherMedicine == 2)
		{
			return EItemAutoOperationMedicineSubtype.Other;
		}
		return config.EffectType switch
		{
			EMedicineEffectType.RecoverOuterInjury => EItemAutoOperationMedicineSubtype.Outer, 
			EMedicineEffectType.RecoverInnerInjury => EItemAutoOperationMedicineSubtype.Inner, 
			EMedicineEffectType.RecoverHealth => EItemAutoOperationMedicineSubtype.Health, 
			EMedicineEffectType.DetoxPoison => EItemAutoOperationMedicineSubtype.Detox, 
			EMedicineEffectType.ApplyPoison => EItemAutoOperationMedicineSubtype.Poison, 
			EMedicineEffectType.ChangeDisorderOfQi => EItemAutoOperationMedicineSubtype.Disorder, 
			_ => EItemAutoOperationMedicineSubtype.Invalid, 
		};
	}

	public ItemAutoOperationSettingItem()
	{
	}

	public ItemAutoOperationSettingItem(ItemAutoOperationSettingItem other)
	{
		TargetType = other.TargetType;
		Grade = other.Grade;
		SubtypeList = ((other.SubtypeList == null) ? null : new List<sbyte>(other.SubtypeList));
	}

	public void Assign(ItemAutoOperationSettingItem other)
	{
		TargetType = other.TargetType;
		Grade = other.Grade;
		SubtypeList = ((other.SubtypeList == null) ? null : new List<sbyte>(other.SubtypeList));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((SubtypeList == null) ? (totalSize + 2) : (totalSize + (2 + SubtypeList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		*pCurrData = (byte)(sbyte)TargetType;
		pCurrData++;
		*pCurrData = (byte)Grade;
		pCurrData++;
		if (SubtypeList != null)
		{
			int elementsCount = SubtypeList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = (byte)SubtypeList[i];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			TargetType = (EItemAutoOperationTargetType)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			Grade = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 2)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (SubtypeList == null)
				{
					SubtypeList = new List<sbyte>();
				}
				else
				{
					SubtypeList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					sbyte element = (sbyte)(*pCurrData);
					pCurrData++;
					SubtypeList.Add(element);
				}
			}
			else
			{
				SubtypeList?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
