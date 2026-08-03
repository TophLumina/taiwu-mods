using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat.Ai.Selector;

public static class ItemSelectorHelper
{
	private static readonly Dictionary<sbyte, List<ItemKey>> GradeCache = new Dictionary<sbyte, List<ItemKey>>();

	public static readonly Dictionary<EItemSelectorType, ItemSelectorPredicate> Predicates = new Dictionary<EItemSelectorType, ItemSelectorPredicate>
	{
		{
			EItemSelectorType.HealInjury,
			HealInjury
		},
		{
			EItemSelectorType.HealPoison,
			HealPoison
		},
		{
			EItemSelectorType.HealQiDisorder,
			HealQiDisorder
		},
		{
			EItemSelectorType.Buff,
			Buff
		},
		{
			EItemSelectorType.ThrowPoison,
			ThrowPoison
		},
		{
			EItemSelectorType.Neili,
			Neili
		},
		{
			EItemSelectorType.Wine,
			Wine
		}
	};

	public static ItemKey SelectBestGradeItem(IRandomSource random, IEnumerable<ItemKey> pool)
	{
		List<sbyte> gradeList = ObjectPool<List<sbyte>>.Instance.Get();
		gradeList.Clear();
		foreach (List<ItemKey> itemKeyList in GradeCache.Values)
		{
			itemKeyList.Clear();
		}
		foreach (ItemKey key in pool)
		{
			sbyte grade = ItemTemplateHelper.GetGrade(key.ItemType, key.TemplateId);
			if (!gradeList.Contains(grade))
			{
				gradeList.Add(grade);
			}
			if (!GradeCache.ContainsKey(grade))
			{
				GradeCache.Add(grade, new List<ItemKey>());
			}
			GradeCache[grade].Add(key);
		}
		gradeList.Sort();
		sbyte num;
		if (DomainManager.Combat.GetCombatType() != 1)
		{
			num = gradeList[gradeList.Count - 1];
		}
		else
		{
			num = gradeList[Math.Max(gradeList.Count - 1, 0) / 2];
		}
		sbyte targetGrade = num;
		ObjectPool<List<sbyte>>.Instance.Return(gradeList);
		return GradeCache[targetGrade].GetRandom(random);
	}

	private static bool HealInjury(CombatCharacter combatChar, ItemKey itemKey)
	{
		if (itemKey.ItemType != 8)
		{
			return false;
		}
		MedicineItem config = Config.Medicine.Instance[itemKey.TemplateId];
		EMedicineEffectType effectType = config.EffectType;
		if ((uint)effectType > 1u)
		{
			return false;
		}
		bool inner = config.EffectType == EMedicineEffectType.RecoverInnerInjury;
		Injuries injuries = combatChar.GetInjuries();
		int partCount = 0;
		int maxInjuryValue = 0;
		for (sbyte i = 0; i < 7; i++)
		{
			sbyte value = injuries.Get(i, inner);
			if (value > 0 && value <= config.EffectThresholdValue)
			{
				partCount++;
				maxInjuryValue = Math.Max(maxInjuryValue, value);
			}
		}
		if (DomainManager.Combat.IsCharacterHalfFallen(combatChar))
		{
			return partCount > 0;
		}
		return partCount >= config.InjuryRecoveryTimes / 2 && maxInjuryValue >= config.EffectValue / 2;
	}

	private static bool HealPoison(CombatCharacter combatChar, ItemKey itemKey)
	{
		if (itemKey.ItemType != 8)
		{
			return false;
		}
		MedicineItem config = Config.Medicine.Instance[itemKey.TemplateId];
		if (config.EffectType != EMedicineEffectType.DetoxPoison)
		{
			return false;
		}
		sbyte detoxPoisonType = config.DetoxPoisonType;
		if (detoxPoisonType < 0)
		{
			return false;
		}
		PoisonInts poisoned = combatChar.GetCharacter().GetPoisoned();
		sbyte level = PoisonsAndLevels.CalcPoisonedLevel(poisoned[detoxPoisonType]);
		return level <= config.EffectThresholdValue;
	}

	private static bool HealQiDisorder(CombatCharacter combatChar, ItemKey itemKey)
	{
		if (itemKey.ItemType != 8)
		{
			return false;
		}
		MedicineItem config = Config.Medicine.Instance[itemKey.TemplateId];
		return config.EffectType == EMedicineEffectType.ChangeDisorderOfQi;
	}

	private static bool Buff(CombatCharacter combatChar, ItemKey itemKey)
	{
		if (itemKey.ItemType != 8)
		{
			return false;
		}
		MedicineItem config = Config.Medicine.Instance[itemKey.TemplateId];
		return GameData.Domains.Character.Character.BonusPropertyTypes.Any((ECharacterPropertyReferencedType type) => config.GetCharacterPropertyBonusInt(type) > 0);
	}

	private static bool ThrowPoison(CombatCharacter combatChar, ItemKey itemKey)
	{
		if (itemKey.ItemType != 8)
		{
			return false;
		}
		short currDistance = DomainManager.Combat.GetCurrentDistance();
		MedicineItem config = Config.Medicine.Instance[itemKey.TemplateId];
		if (config.MaxUseDistance < currDistance)
		{
			return false;
		}
		GameData.Domains.Character.Character character = combatChar.GetCharacter();
		if (EatingItems.IsWugKing(itemKey))
		{
			return !character.GetLearnedCombatSkills().Contains(WugKing.Instance.First((WugKingItem x) => x.WugMedicine == itemKey.TemplateId).WugFinger);
		}
		return config.ItemSubType == 801 && config.EffectType == EMedicineEffectType.ApplyPoison;
	}

	private static bool Neili(CombatCharacter combatChar, ItemKey itemKey)
	{
		if (itemKey.ItemType != 12)
		{
			return false;
		}
		return Config.Misc.Instance[itemKey.TemplateId].Neili > 0;
	}

	private static bool Wine(CombatCharacter combatChar, ItemKey itemKey)
	{
		if (itemKey.ItemType != 9)
		{
			return false;
		}
		return Config.TeaWine.Instance[itemKey.TemplateId].ItemSubType == 901;
	}
}
