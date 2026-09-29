using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ProfessionSkillItem : ConfigItem<ProfessionSkillItem, int>
{
	public readonly int TemplateId;

	public readonly string Name;

	public readonly bool Instant;

	public readonly int Profession;

	public readonly string Icon;

	public readonly string BigIcon;

	public readonly string Desc;

	public readonly string FunctionalDesc;

	public readonly sbyte Level;

	public readonly short CharacterProperty;

	public readonly EProfessionSkillTriggerType TriggerType;

	public readonly bool IgnoreCanExecuteSkill;

	public readonly EProfessionSkillType Type;

	public readonly short SkillCoolDown;

	public readonly short TimeCost;

	public readonly bool CostTimeWhenFinished;

	public readonly short UnlockSeniority;

	public readonly short Exp;

	public readonly short FailExp;

	public readonly int ExpCost;

	public readonly List<ResourceInfo> ResourcesCost;

	public readonly short RequiredFavorability;

	public readonly string SkillUnlockDesc;

	public readonly string SkillUnlockExplain;

	public ProfessionSkillItem(int templateId, string name, bool instant, int profession, string icon, string bigIcon, string desc, string functionalDesc, sbyte level, short characterProperty, EProfessionSkillTriggerType triggerType, bool ignoreCanExecuteSkill, EProfessionSkillType type, short skillCoolDown, short timeCost, bool costTimeWhenFinished, short unlockSeniority, short exp, short failExp, int expCost, List<ResourceInfo> resourcesCost, short requiredFavorability, string skillUnlockDesc, string skillUnlockExplain)
	{
		TemplateId = templateId;
		Name = name;
		Instant = instant;
		Profession = profession;
		Icon = icon;
		BigIcon = bigIcon;
		Desc = desc;
		FunctionalDesc = functionalDesc;
		Level = level;
		CharacterProperty = characterProperty;
		TriggerType = triggerType;
		IgnoreCanExecuteSkill = ignoreCanExecuteSkill;
		Type = type;
		SkillCoolDown = skillCoolDown;
		TimeCost = timeCost;
		CostTimeWhenFinished = costTimeWhenFinished;
		UnlockSeniority = unlockSeniority;
		Exp = exp;
		FailExp = failExp;
		ExpCost = expCost;
		ResourcesCost = resourcesCost;
		RequiredFavorability = requiredFavorability;
		SkillUnlockDesc = skillUnlockDesc;
		SkillUnlockExplain = skillUnlockExplain;
	}

	public ProfessionSkillItem()
	{
		TemplateId = 0;
		Name = null;
		Instant = false;
		Profession = 0;
		Icon = null;
		BigIcon = null;
		Desc = null;
		FunctionalDesc = null;
		Level = 0;
		CharacterProperty = 0;
		TriggerType = EProfessionSkillTriggerType.Invalid;
		IgnoreCanExecuteSkill = false;
		Type = EProfessionSkillType.Invalid;
		SkillCoolDown = 0;
		TimeCost = 0;
		CostTimeWhenFinished = false;
		UnlockSeniority = 0;
		Exp = 0;
		FailExp = 0;
		ExpCost = 0;
		ResourcesCost = new List<ResourceInfo>();
		RequiredFavorability = 0;
		SkillUnlockDesc = null;
		SkillUnlockExplain = null;
	}

	public ProfessionSkillItem(int templateId, ProfessionSkillItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Instant = other.Instant;
		Profession = other.Profession;
		Icon = other.Icon;
		BigIcon = other.BigIcon;
		Desc = other.Desc;
		FunctionalDesc = other.FunctionalDesc;
		Level = other.Level;
		CharacterProperty = other.CharacterProperty;
		TriggerType = other.TriggerType;
		IgnoreCanExecuteSkill = other.IgnoreCanExecuteSkill;
		Type = other.Type;
		SkillCoolDown = other.SkillCoolDown;
		TimeCost = other.TimeCost;
		CostTimeWhenFinished = other.CostTimeWhenFinished;
		UnlockSeniority = other.UnlockSeniority;
		Exp = other.Exp;
		FailExp = other.FailExp;
		ExpCost = other.ExpCost;
		ResourcesCost = other.ResourcesCost;
		RequiredFavorability = other.RequiredFavorability;
		SkillUnlockDesc = other.SkillUnlockDesc;
		SkillUnlockExplain = other.SkillUnlockExplain;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ProfessionSkillItem Duplicate(int templateId)
	{
		return new ProfessionSkillItem(templateId, this);
	}
}
