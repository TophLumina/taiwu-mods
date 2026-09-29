using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class MysteryEffectItem : ConfigItem<MysteryEffectItem, int>
{
	public readonly int TemplateId;

	public readonly int CompatibilityRequirement;

	public readonly List<int> PowerRequirements;

	public readonly List<List<PropertyAndValueAndModifyType>> BonusValues;

	public readonly List<short> BonusEffects;

	public MysteryEffectItem(int templateId, int compatibilityRequirement, List<int> powerRequirements, List<List<PropertyAndValueAndModifyType>> bonusValues, List<short> bonusEffects)
	{
		TemplateId = templateId;
		CompatibilityRequirement = compatibilityRequirement;
		PowerRequirements = powerRequirements;
		BonusValues = bonusValues;
		BonusEffects = bonusEffects;
	}

	public MysteryEffectItem()
	{
		TemplateId = 0;
		CompatibilityRequirement = 300;
		PowerRequirements = new List<int> { 100, 120, 140, 180 };
		BonusValues = null;
		BonusEffects = null;
	}

	public MysteryEffectItem(int templateId, MysteryEffectItem other)
	{
		TemplateId = templateId;
		CompatibilityRequirement = other.CompatibilityRequirement;
		PowerRequirements = other.PowerRequirements;
		BonusValues = other.BonusValues;
		BonusEffects = other.BonusEffects;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MysteryEffectItem Duplicate(int templateId)
	{
		return new MysteryEffectItem(templateId, this);
	}
}
