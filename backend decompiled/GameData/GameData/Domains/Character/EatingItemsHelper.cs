using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Character;

public static class EatingItemsHelper
{
	public static int IndexOfWug(this EatingItems eatingItems, MedicineItem wugConfig)
	{
		return eatingItems.IndexOfWug(wugConfig.WugType, wugConfig.WugGrowthType == 5);
	}

	public unsafe static int IndexOfWug(this EatingItems eatingItems, sbyte wugType, bool isKing = false)
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)eatingItems.ItemKeys[i];
			if (!(isKing ? itemKey.IsValid() : (!itemKey.IsValid())))
			{
				continue;
			}
			foreach (short wugTemplateId in ItemDomain.GetWugTemplateIdGroup(wugType, isKing))
			{
				if (itemKey.TemplateId == wugTemplateId)
				{
					return i;
				}
			}
		}
		return -1;
	}

	public unsafe static int IndexOfWug(this EatingItems eatingItems, short itemTemplateId)
	{
		for (int i = 0; i < 9; i++)
		{
			if (((ItemKey)eatingItems.ItemKeys[i]).TemplateId == itemTemplateId)
			{
				return i;
			}
		}
		return -1;
	}

	public static short GetWugDuration(this EatingItems eatingItems, short wugTemplateId)
	{
		int index = eatingItems.IndexOfWug(wugTemplateId);
		return (short)((index >= 0) ? eatingItems.GetDuration(index) : 0);
	}

	public unsafe static void ChangeDuration(this ref EatingItems eatingItems, DataContext context, int index, short deltaDuration, ref List<short> wugsToBeRemoved)
	{
		int duration = eatingItems.Durations[index] + deltaDuration;
		eatingItems.Durations[index] = (short)duration;
		if (duration > 0)
		{
			return;
		}
		ItemKey itemKey = (ItemKey)eatingItems.ItemKeys[index];
		eatingItems.ItemKeys[index] = (ulong)ItemKey.Invalid;
		if (itemKey.IsValid())
		{
			DomainManager.Item.RemoveItem(context, itemKey);
		}
		if (EatingItems.IsWug(itemKey))
		{
			if (wugsToBeRemoved == null)
			{
				wugsToBeRemoved = new List<short>();
			}
			wugsToBeRemoved.Add(itemKey.TemplateId);
		}
	}

	public unsafe static void ChangeDuration(this ref EatingItems eatingItems, DataContext context, int index, short deltaDuration)
	{
		int duration = eatingItems.Durations[index] + deltaDuration;
		eatingItems.Durations[index] = (short)duration;
		if (duration <= 0)
		{
			ItemKey itemKey = (ItemKey)eatingItems.ItemKeys[index];
			eatingItems.ItemKeys[index] = (ulong)ItemKey.Invalid;
			if (itemKey.IsValid())
			{
				DomainManager.Item.RemoveItem(context, itemKey);
			}
		}
	}

	public unsafe static CValueModify GetCharacterPropertyBonus(this EatingItems eatingItems, ECharacterPropertyReferencedType propertyType, bool isTaiwu = false)
	{
		int add = 0;
		int addPercent = 0;
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)eatingItems.ItemKeys[i];
			if (!EatingItems.IsValid(itemKey))
			{
				continue;
			}
			sbyte itemType = itemKey.ItemType;
			if (1 == 0)
			{
			}
			int num = itemType switch
			{
				7 => GameData.Domains.Item.Food.GetCharacterPropertyBonus(itemKey.TemplateId, propertyType), 
				8 => GameData.Domains.Item.Medicine.GetCharacterPropertyBonusValue(itemKey.TemplateId, propertyType), 
				9 => GameData.Domains.Item.TeaWine.GetCharacterPropertyBonus(itemKey.TemplateId, propertyType), 
				5 => GameData.Domains.Item.Material.GetCharacterPropertyBonus(itemKey.TemplateId, propertyType), 
				_ => throw new Exception($"Unsupported eating item type: {itemKey.ItemType}"), 
			};
			if (1 == 0)
			{
			}
			int valueA = num;
			sbyte itemType2 = itemKey.ItemType;
			if (1 == 0)
			{
			}
			num = itemType2 switch
			{
				8 => GameData.Domains.Item.Medicine.GetCharacterPropertyBonusPercentage(itemKey.TemplateId, propertyType), 
				7 => 0, 
				9 => 0, 
				5 => 0, 
				_ => throw new Exception($"Unsupported eating item type: {itemKey.ItemType}"), 
			};
			if (1 == 0)
			{
			}
			int valueB = num;
			if (isTaiwu)
			{
				short subType = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
				if (subType == 900 && DomainManager.Extra.IsProfessionalSkillUnlocked(16, 1))
				{
					valueA = Math.Max(valueA, 0);
					valueB = Math.Max(valueB, 0);
				}
				if (subType == 901)
				{
					if (DomainManager.Extra.IsProfessionalSkillUnlocked(7, 1))
					{
						valueA = Math.Max(valueA, 0);
						valueB = Math.Max(valueB, 0);
					}
					if (DomainManager.Extra.IsProfessionalSkillUnlocked(7, 2) && valueA > 0)
					{
						valueA += valueA * DomainManager.Taiwu.GetWineTasterBonusPercentage() / 100;
					}
				}
			}
			add += valueA;
			addPercent += valueB;
		}
		return new CValueModify(add, addPercent);
	}

	public unsafe static bool ContainsPoisonedItem(this EatingItems eatingItems, short poisonTemplateId)
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)eatingItems.ItemKeys[i];
			if (EatingItems.IsValid(itemKey) && ModificationStateHelper.IsActive(itemKey.ModificationState, 1))
			{
				FullPoisonEffects poisonEffects = DomainManager.Item.GetPoisonEffects(itemKey);
				if (poisonTemplateId == poisonEffects.GetMedicineTemplateId())
				{
					return true;
				}
			}
		}
		return false;
	}

	public unsafe static void GetMixedPoisonTypes(this EatingItems eatingItems, ref SpanList<sbyte> mixedPoisonTypes)
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)eatingItems.ItemKeys[i];
			if (EatingItems.IsValid(itemKey) && ModificationStateHelper.IsActive(itemKey.ModificationState, 1))
			{
				FullPoisonEffects poisonEffects = DomainManager.Item.GetPoisonEffects(itemKey);
				short poisonTemplateId = poisonEffects.GetMedicineTemplateId();
				sbyte mixedPoisonType = MixedPoisonType.FromMedicineTemplateId(poisonTemplateId);
				if (mixedPoisonType >= 0 && mixedPoisonType < 35)
				{
					mixedPoisonTypes.Add(mixedPoisonType);
				}
			}
		}
	}

	public unsafe static bool ContainsWine(this EatingItems eatingItems)
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)eatingItems.ItemKeys[i];
			if (itemKey.IsValid() && DomainManager.Item.GetBaseItem(itemKey).GetItemSubType() == 901)
			{
				return true;
			}
		}
		return false;
	}

	public static CValuePercentBonus CalcDamageStepBonus(this EatingItems eatingItems, EMarkType markType)
	{
		if (1 == 0)
		{
		}
		int num = markType switch
		{
			EMarkType.Outer => 16, 
			EMarkType.Inner => 17, 
			EMarkType.Fatal => 20, 
			EMarkType.Mind => 19, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		int expectBreakBonusEffect = num;
		if (expectBreakBonusEffect < 0)
		{
			return 0;
		}
		int result = 0;
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = eatingItems.Get(i);
			if (itemKey.IsValid() && itemKey.ItemType == 8)
			{
				MedicineItem medicineConfig = Config.Medicine.Instance[itemKey.TemplateId];
				if (medicineConfig.BreakBonusEffect == expectBreakBonusEffect)
				{
					result = Math.Max(result, medicineConfig.DamageStepBonus);
				}
			}
		}
		return result;
	}
}
