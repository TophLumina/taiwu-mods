using System;
using System.Collections.Generic;
using Config;
using Config.ConfigCells.Character;
using GameData.Combat.Math;
using GameData.Domains.Character;
using GameData.Domains.Taiwu.Profession;
using GameData.Utilities;

namespace GameData.Domains.Item;

public static class ItemPowerHelper
{
	public static bool IsSupport(sbyte itemType)
	{
		if ((uint)itemType <= 2u)
		{
			return true;
		}
		return false;
	}

	public static CValueModify CalcPowerModify(int charId, ItemKey itemKey)
	{
		CValueModify modify = DomainManager.SpecialEffect.GetModify(charId, 313, itemKey.Id);
		if (!DomainManager.Combat.IsCharInCombat(charId))
		{
			return modify;
		}
		int addValue = DomainManager.Combat.EquipmentPowerChangeInCombat.GetOrDefault(charId);
		return modify.ChangeA(addValue);
	}

	public static CValueModify CalcMaxPowerModify(int charId, ItemKey itemKey)
	{
		sbyte itemType = itemKey.ItemType;
		if (1 == 0)
		{
		}
		ushort num = itemType switch
		{
			0 => 27, 
			1 => 30, 
			_ => ushort.MaxValue, 
		};
		if (1 == 0)
		{
		}
		ushort fieldId = num;
		if (fieldId == ushort.MaxValue)
		{
			return CValueModify.Zero;
		}
		return DomainManager.SpecialEffect.GetModify(charId, fieldId, itemKey.Id);
	}

	public static CValueModify CalcRequirementModify(int charId, ItemKey itemKey)
	{
		sbyte itemType = itemKey.ItemType;
		if (1 == 0)
		{
		}
		ushort num = itemType switch
		{
			0 => 28, 
			1 => 31, 
			_ => ushort.MaxValue, 
		};
		if (1 == 0)
		{
		}
		ushort fieldId = num;
		if (fieldId == ushort.MaxValue)
		{
			return CValueModify.Zero;
		}
		return DomainManager.SpecialEffect.GetModify(charId, fieldId);
	}

	public static CValuePercent CalcRequirementPercent(int charId, ItemKey itemKey)
	{
		int percent = 100;
		if (itemKey.IsValid())
		{
			EquipmentBase equip = DomainManager.Item.GetBaseEquipment(itemKey);
			short equipmentEffectId = equip.GetEquipmentEffectId();
			if (equipmentEffectId >= 0)
			{
				percent += EquipmentEffect.Instance[equipmentEffectId].RequirementChange;
			}
			if (ModificationStateHelper.IsActive(equip.GetModificationState(), 2))
			{
				RefiningEffects refiningEffects = DomainManager.Item.GetRefinedEffects(itemKey);
				sbyte itemType = itemKey.ItemType;
				if (1 == 0)
				{
				}
				int num = itemType switch
				{
					0 => refiningEffects.GetWeaponPropertyBonus(ERefiningEffectWeaponType.UseRequirement), 
					1 => refiningEffects.GetArmorPropertyBonus(ERefiningEffectArmorType.UseRequirement), 
					_ => 0, 
				};
				if (1 == 0)
				{
				}
				int refineBonus = num;
				refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, equip.GetEquippedCharId());
				percent += refineBonus;
			}
		}
		return percent * CalcRequirementModify(charId, itemKey);
	}

	public static short CalcItemFixPower(this GameData.Domains.Character.Character character, ItemKey itemKey)
	{
		sbyte itemType = itemKey.ItemType;
		if (1 == 0)
		{
		}
		short result = itemType switch
		{
			0 => character.GetFixWeaponPower(), 
			1 => character.GetFixArmorPower(), 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static IReadOnlyList<PropertyAndValue> CalcRequirements(ItemKey itemKey)
	{
		sbyte itemType = itemKey.ItemType;
		if (1 == 0)
		{
		}
		List<PropertyAndValue> result = itemType switch
		{
			0 => Config.Weapon.Instance[itemKey.TemplateId].RequiredCharacterProperties, 
			1 => Config.Armor.Instance[itemKey.TemplateId].RequiredCharacterProperties, 
			2 => Config.Accessory.Instance[itemKey.TemplateId].RequiredCharacterProperties, 
			_ => throw new Exception($"Cannot get use power of item type {itemKey.ItemType}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
