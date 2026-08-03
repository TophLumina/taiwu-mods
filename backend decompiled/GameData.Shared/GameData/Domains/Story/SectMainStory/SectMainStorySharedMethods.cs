using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Math;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Story.SectMainStory;

/// <summary>
/// 地区主线共享的计算方法
/// </summary>
public static class SectMainStorySharedMethods
{
	/// <summary>
	/// 物品是否与指定独创心法突破格相宜
	/// </summary>
	public static bool IsEmeiBonusFit(short bonusTypeTemplateId, ItemKey itemKey)
	{
		SkillBreakPlateGridBonusTypeItem config = SkillBreakPlateGridBonusType.Instance[bonusTypeTemplateId];
		short subType = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
		short[] extraBonusFitItemSubTypes = config.ExtraBonusFitItemSubTypes;
		if (extraBonusFitItemSubTypes != null && Enumerable.Contains(extraBonusFitItemSubTypes, subType))
		{
			return true;
		}
		if (itemKey.ItemType != 10)
		{
			return false;
		}
		SkillBookItem itemConfig = SkillBook.Instance[itemKey.TemplateId];
		sbyte[] extraBonusFitCombatSkillTypes = config.ExtraBonusFitCombatSkillTypes;
		if (extraBonusFitCombatSkillTypes == null || !Enumerable.Contains(extraBonusFitCombatSkillTypes, itemConfig.CombatSkillType))
		{
			return config.ExtraBonusFitLifeSkillTypes?.Contains(itemConfig.LifeSkillType) ?? false;
		}
		return true;
	}

	/// <summary>
	/// 计算物品给指定独创心法突破格提供的进度值
	/// </summary>
	public static int CalcEmeiBonusItemProgress(short bonusTypeTemplateId, IItemData data)
	{
		ItemKey itemKey = data.Key;
		int value = data.Value;
		return Math.Max(IsEmeiBonusFit(bonusTypeTemplateId, itemKey) ? value : (value * (CValuePercent)GlobalConfig.Instance.SectStoryEmeiBonusNotFitProgressPercent), GlobalConfig.Instance.SectStoryEmeiBonusMinProgress);
	}

	/// <inheritdoc cref="M:GameData.Domains.Story.SectMainStory.SectMainStorySharedMethods.CalcEmeiBonusItemProgress(System.Int16,GameData.Domains.Item.IItemData)" />
	public static int CalcEmeiBonusItemProgress(short bonusTypeTemplateId, IEnumerable<IItemData> itemKeys)
	{
		return itemKeys?.Select((IItemData x) => CalcEmeiBonusItemProgress(bonusTypeTemplateId, x)).Sum() ?? 0;
	}

	/// <summary>
	/// 计算炼制王蛊总计需要消耗的毒素量
	/// </summary>
	/// <param name="jugData"></param>
	/// <returns></returns>
	public static int CalcWugJugRefiningCostPoisonValue(SectWuxianWugJugData jugData)
	{
		int wugJugRefiningCostPoison = GlobalConfig.Instance.WugJugRefiningCostPoison;
		int currDate = ExternalDataBridge.Context.CurrDate;
		int bonusPercent = GlobalConfig.Instance.WugJugRefiningCostPoisonBonusPercent;
		int monthPercent = GlobalConfig.Instance.WugJugRefiningCostPoisonMonthPercent;
		CValuePercentBonus bonus = ((jugData.LastRefiningDate >= 0) ? MathUtils.Max(bonusPercent + monthPercent * (currDate - jugData.LastRefiningDate), 0) : 0);
		return wugJugRefiningCostPoison * bonus;
	}

	/// <summary>
	/// 计算蛊王类型与消耗的毒素量
	/// </summary>
	/// <param name="costPoisons">消耗的毒素量，<see cref="T:GameData.Domains.Combat.PoisonType" /> 作为索引</param>
	/// <param name="jugData">万蛊坛数据</param>
	/// <returns>蛊王类型，-1 代表未知类型</returns>
	public static sbyte CalcWugKingType(List<int> costPoisons, SectWuxianWugJugData jugData)
	{
		costPoisons.Clear();
		for (int i = 0; i < 6; i++)
		{
			costPoisons.Add(0);
		}
		int require = CalcWugJugRefiningCostPoisonValue(jugData);
		int jugPoison = jugData.Poisons.Sum();
		if (jugPoison < require)
		{
			return -1;
		}
		for (int j = 0; j < 6; j++)
		{
			costPoisons[j] = (int)MathUtils.Clamp((long)require * (long)jugData.Poisons[j] / jugPoison, 0L, require);
		}
		int adjustPoison = costPoisons.Sum() - require;
		for (int k = 0; k < 6; k++)
		{
			if (costPoisons[k] > 0)
			{
				int adjust = MathUtils.Min(costPoisons[k], adjustPoison);
				costPoisons[k] -= adjust;
				adjustPoison -= adjust;
			}
		}
		foreach (WugKingItem wugKing in (IEnumerable<WugKingItem>)WugKing.Instance)
		{
			int minPoison = require * wugKing.PoisonMinPercent / 100;
			int maxPoison = require * wugKing.PoisonMaxPercent / 100;
			bool match = true;
			for (sbyte i2 = 0; i2 < 6; i2++)
			{
				if (wugKing.RefiningPoisons.Contains(i2))
				{
					match = match && Match(i2);
				}
				else if (wugKing.PoisonUnique)
				{
					match = match && !Match(i2);
				}
			}
			if (match)
			{
				return wugKing.TemplateId;
			}
			bool Match(sbyte type)
			{
				if (costPoisons[type] >= minPoison)
				{
					return costPoisons[type] <= maxPoison;
				}
				return false;
			}
		}
		return -1;
	}

	/// <summary>
	/// 计算毒物投入万蛊坛提供的毒素量
	/// </summary>
	public static PoisonInts CalcDropPoisonValue(IItemData data)
	{
		PoisonInts values = default(PoisonInts);
		values.Initialize();
		ItemKey itemKey = data.Key;
		sbyte itemType = itemKey.ItemType;
		if ((uint)(itemType - 4) > 1u)
		{
			return values;
		}
		PoisonsAndLevels poisons = itemKey.ItemType switch
		{
			5 => Material.Instance[itemKey.TemplateId].InnatePoisons, 
			4 => Carrier.Instance[itemKey.TemplateId].InnatePoisons, 
			_ => throw new ArgumentOutOfRangeException($"{itemKey} {itemKey.ItemType}"), 
		};
		short durability = data.Durability;
		short maxDurability = data.MaxDurability;
		short durability2 = durability;
		CValuePercent percent = ((itemKey.ItemType == 4 && maxDurability > 0) ? ItemFormula.FormulaCalcDurabilityEffect(durability2, maxDurability) : ((CValuePercent)100));
		int ratio = GlobalConfig.Instance.WugJugPoisonDropRatio;
		for (sbyte i = 0; i < 6; i++)
		{
			(short, sbyte) valueAndLevel = poisons.GetValueAndLevel(i);
			values[i] = valueAndLevel.Item1 * valueAndLevel.Item2 * percent * ratio;
		}
		return values;
	}

	/// <summary>
	/// 计算投入一批物品万蛊坛提供的毒素量
	/// </summary>
	public static PoisonInts CalcDropPoisonValue(SectWuxianWugJugData jugData, IEnumerable<IItemData> items)
	{
		PoisonInts addPoisons = default(PoisonInts);
		addPoisons.Initialize();
		foreach (IItemData item in items)
		{
			PoisonInts poisons = CalcDropPoisonValue(item);
			addPoisons.Add(ref poisons);
		}
		return addPoisons;
	}
}
