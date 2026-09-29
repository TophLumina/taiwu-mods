using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SectApprovingEffectItem : ConfigItem<SectApprovingEffectItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string Icon;

	public readonly List<sbyte> RequirementSubstitutions;

	public readonly short[] CombatSkillDirectionBonuses;

	public readonly short[] BehaviorTypeBonuses;

	public readonly short[] PageBonusesOfMale;

	public readonly short[] PageBonusesOfFemale;

	public readonly short ActualCombatBonusOfMale;

	public readonly short ActualCombatBonusOfFemale;

	public SectApprovingEffectItem(sbyte templateId, string name, string desc, string icon, List<sbyte> requirementSubstitutions, short[] combatSkillDirectionBonuses, short[] behaviorTypeBonuses, short[] pageBonusesOfMale, short[] pageBonusesOfFemale, short actualCombatBonusOfMale, short actualCombatBonusOfFemale)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
		RequirementSubstitutions = requirementSubstitutions;
		CombatSkillDirectionBonuses = combatSkillDirectionBonuses;
		BehaviorTypeBonuses = behaviorTypeBonuses;
		PageBonusesOfMale = pageBonusesOfMale;
		PageBonusesOfFemale = pageBonusesOfFemale;
		ActualCombatBonusOfMale = actualCombatBonusOfMale;
		ActualCombatBonusOfFemale = actualCombatBonusOfFemale;
	}

	public SectApprovingEffectItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
		RequirementSubstitutions = new List<sbyte>();
		CombatSkillDirectionBonuses = new short[2] { 100, 100 };
		BehaviorTypeBonuses = new short[5] { 100, 100, 100, 100, 100 };
		PageBonusesOfMale = new short[5] { 100, 100, 100, 100, 100 };
		PageBonusesOfFemale = new short[5] { 100, 100, 100, 100, 100 };
		ActualCombatBonusOfMale = 100;
		ActualCombatBonusOfFemale = 100;
	}

	public SectApprovingEffectItem(sbyte templateId, SectApprovingEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
		RequirementSubstitutions = other.RequirementSubstitutions;
		CombatSkillDirectionBonuses = other.CombatSkillDirectionBonuses;
		BehaviorTypeBonuses = other.BehaviorTypeBonuses;
		PageBonusesOfMale = other.PageBonusesOfMale;
		PageBonusesOfFemale = other.PageBonusesOfFemale;
		ActualCombatBonusOfMale = other.ActualCombatBonusOfMale;
		ActualCombatBonusOfFemale = other.ActualCombatBonusOfFemale;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SectApprovingEffectItem Duplicate(int templateId)
	{
		return new SectApprovingEffectItem((sbyte)templateId, this);
	}
}
