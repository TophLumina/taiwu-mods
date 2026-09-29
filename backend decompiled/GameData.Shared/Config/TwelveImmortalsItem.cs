using System;
using Config.Common;

namespace Config;

[Serializable]
public class TwelveImmortalsItem : ConfigItem<TwelveImmortalsItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly short Character;

	public readonly short CombatSkill;

	public readonly int ImpactRange;

	public readonly sbyte MapState;

	public readonly int Group;

	public readonly string TreasureDesc;

	public readonly string TreasureState1;

	public readonly string TreasureState0;

	public readonly string TreasureName;

	public readonly short BonusFeature;

	public readonly short BonusFeatureInDefeated;

	public readonly string TaiwuAsXiangshuEvent1;

	public readonly string TaiwuAsXiangshuEvent2;

	public readonly string TaiwuAsXiangshuEvent3;

	public TwelveImmortalsItem(sbyte templateId, short character, short combatSkill, int impactRange, sbyte mapState, int group, string treasureDesc, string treasureState1, string treasureState0, string treasureName, short bonusFeature, short bonusFeatureInDefeated, string taiwuAsXiangshuEvent1, string taiwuAsXiangshuEvent2, string taiwuAsXiangshuEvent3)
	{
		TemplateId = templateId;
		Character = character;
		CombatSkill = combatSkill;
		ImpactRange = impactRange;
		MapState = mapState;
		Group = group;
		TreasureDesc = treasureDesc;
		TreasureState1 = treasureState1;
		TreasureState0 = treasureState0;
		TreasureName = treasureName;
		BonusFeature = bonusFeature;
		BonusFeatureInDefeated = bonusFeatureInDefeated;
		TaiwuAsXiangshuEvent1 = taiwuAsXiangshuEvent1;
		TaiwuAsXiangshuEvent2 = taiwuAsXiangshuEvent2;
		TaiwuAsXiangshuEvent3 = taiwuAsXiangshuEvent3;
	}

	public TwelveImmortalsItem()
	{
		TemplateId = 0;
		Character = 0;
		CombatSkill = 0;
		ImpactRange = 0;
		MapState = 0;
		Group = 0;
		TreasureDesc = null;
		TreasureState1 = null;
		TreasureState0 = null;
		TreasureName = null;
		BonusFeature = 0;
		BonusFeatureInDefeated = 0;
		TaiwuAsXiangshuEvent1 = null;
		TaiwuAsXiangshuEvent2 = null;
		TaiwuAsXiangshuEvent3 = null;
	}

	public TwelveImmortalsItem(sbyte templateId, TwelveImmortalsItem other)
	{
		TemplateId = templateId;
		Character = other.Character;
		CombatSkill = other.CombatSkill;
		ImpactRange = other.ImpactRange;
		MapState = other.MapState;
		Group = other.Group;
		TreasureDesc = other.TreasureDesc;
		TreasureState1 = other.TreasureState1;
		TreasureState0 = other.TreasureState0;
		TreasureName = other.TreasureName;
		BonusFeature = other.BonusFeature;
		BonusFeatureInDefeated = other.BonusFeatureInDefeated;
		TaiwuAsXiangshuEvent1 = other.TaiwuAsXiangshuEvent1;
		TaiwuAsXiangshuEvent2 = other.TaiwuAsXiangshuEvent2;
		TaiwuAsXiangshuEvent3 = other.TaiwuAsXiangshuEvent3;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TwelveImmortalsItem Duplicate(int templateId)
	{
		return new TwelveImmortalsItem((sbyte)templateId, this);
	}
}
