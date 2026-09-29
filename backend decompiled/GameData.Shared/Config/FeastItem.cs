using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class FeastItem : ConfigItem<FeastItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string ConditionDesc;

	public readonly string EffectDesc;

	public readonly int Priority;

	public readonly EFeastType Type;

	public readonly string Icon;

	public readonly int HappinessPercent;

	public readonly int FavorPercent;

	public readonly sbyte GiftBonus;

	public readonly int ExpPercent;

	public readonly int OtherFavorPercent;

	public readonly int ReadCombatSkillBook;

	public readonly int ReadLifeSkillBook;

	public readonly int Loop;

	public readonly bool IgnoreHate;

	public readonly bool ForceLove;

	public readonly List<EFeastRequirementType> RequirementType;

	public readonly List<int[]> RequirementData;

	public FeastItem(short templateId, string name, string desc, string conditionDesc, string effectDesc, int priority, EFeastType type, string icon, int happinessPercent, int favorPercent, sbyte giftBonus, int expPercent, int otherFavorPercent, int readCombatSkillBook, int readLifeSkillBook, int loop, bool ignoreHate, bool forceLove, List<EFeastRequirementType> requirementType, List<int[]> requirementData)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		ConditionDesc = conditionDesc;
		EffectDesc = effectDesc;
		Priority = priority;
		Type = type;
		Icon = icon;
		HappinessPercent = happinessPercent;
		FavorPercent = favorPercent;
		GiftBonus = giftBonus;
		ExpPercent = expPercent;
		OtherFavorPercent = otherFavorPercent;
		ReadCombatSkillBook = readCombatSkillBook;
		ReadLifeSkillBook = readLifeSkillBook;
		Loop = loop;
		IgnoreHate = ignoreHate;
		ForceLove = forceLove;
		RequirementType = requirementType;
		RequirementData = requirementData;
	}

	public FeastItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		ConditionDesc = null;
		EffectDesc = null;
		Priority = 0;
		Type = EFeastType.Invalid;
		Icon = null;
		HappinessPercent = 0;
		FavorPercent = 0;
		GiftBonus = 0;
		ExpPercent = 0;
		OtherFavorPercent = 0;
		ReadCombatSkillBook = 0;
		ReadLifeSkillBook = 0;
		Loop = 0;
		IgnoreHate = false;
		ForceLove = false;
		RequirementType = null;
		RequirementData = null;
	}

	public FeastItem(short templateId, FeastItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		ConditionDesc = other.ConditionDesc;
		EffectDesc = other.EffectDesc;
		Priority = other.Priority;
		Type = other.Type;
		Icon = other.Icon;
		HappinessPercent = other.HappinessPercent;
		FavorPercent = other.FavorPercent;
		GiftBonus = other.GiftBonus;
		ExpPercent = other.ExpPercent;
		OtherFavorPercent = other.OtherFavorPercent;
		ReadCombatSkillBook = other.ReadCombatSkillBook;
		ReadLifeSkillBook = other.ReadLifeSkillBook;
		Loop = other.Loop;
		IgnoreHate = other.IgnoreHate;
		ForceLove = other.ForceLove;
		RequirementType = other.RequirementType;
		RequirementData = other.RequirementData;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override FeastItem Duplicate(int templateId)
	{
		return new FeastItem((short)templateId, this);
	}
}
