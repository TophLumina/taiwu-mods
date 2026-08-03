using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.EvilSuper;

public class BaiDuGuiChao : MysteryEffectBase
{
	private const int RequireAttainment = 500;

	private const int RandomRangeMin = -33;

	private const int RandomRangeMax = 34;

	protected override short SpecialEffectId => 1779;

	private static int CalcWugFactor(sbyte wugGrowthType)
	{
		if (1 == 0)
		{
		}
		int result;
		switch (wugGrowthType)
		{
		case 5:
			result = 20;
			break;
		case 4:
			result = 15;
			break;
		case 2:
		case 3:
			result = 10;
			break;
		default:
			result = 5;
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}

	private static bool IsPoisonMatchWugType(sbyte poisonType, sbyte wugType)
	{
		foreach (WugKingItem config in (IEnumerable<WugKingItem>)WugKing.Instance)
		{
			MedicineItem kingMedicine = Config.Medicine.Instance[config.WugMedicine];
			if (kingMedicine.WugType == wugType)
			{
				return config.RefiningPoisons.Contains(poisonType);
			}
		}
		return false;
	}

	public BaiDuGuiChao()
	{
	}

	public BaiDuGuiChao(int charId, int itemId)
		: base(charId, itemId, 50111)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_ThrowPoison(OnThrowPoison);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_ThrowPoison(OnThrowPoison);
		base.OnDisable(context);
	}

	private void OnThrowPoison(DataContext context, int charId, ItemKey itemKey)
	{
		if (charId != base.CharacterId || CharObj.GetLifeSkillAttainment(9) < 500 || itemKey.ItemType != 8)
		{
			return;
		}
		MedicineItem medicineConfig = Config.Medicine.Instance[itemKey.TemplateId];
		int totalValue = 0;
		int baseValue = medicineConfig.EffectValue * medicineConfig.EffectThresholdValue;
		CombatCharacter enemyChar = base.EnemyChar;
		EatingItems enemyEatingItems = enemyChar.GetCharacter().GetEatingItems();
		sbyte poisonType = medicineConfig.PoisonType;
		for (int i = 0; i < 9; i++)
		{
			ItemKey eatingItemKey = enemyEatingItems.Get(i);
			if (EatingItems.IsWug(eatingItemKey))
			{
				MedicineItem wugConfig = Config.Medicine.Instance[eatingItemKey.TemplateId];
				if (IsPoisonMatchWugType(poisonType, wugConfig.WugType))
				{
					int value = baseValue * CalcWugFactor(wugConfig.WugGrowthType);
					CValuePercentBonus floatBonus = context.Random.Next(-33, 34);
					totalValue += value * floatBonus;
				}
			}
		}
		if (totalValue > 0)
		{
			enemyChar.AddFatalDamage(context, totalValue, -1, -1, -1);
			ShowSpecialEffect(0);
		}
	}
}
