using System;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class AgeEffectItem : ConfigItem<AgeEffectItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly sbyte SkillQualificationAverage;

	public readonly sbyte SkillQualificationPrecocious;

	public readonly sbyte SkillQualificationLateBlooming;

	public readonly MainAttributes MainAttributes;

	public readonly MainAttributes MainAttributesRecoveries;

	public readonly short FertilityMale;

	public readonly short FertilityFemale;

	public AgeEffectItem(sbyte templateId, sbyte skillQualificationAverage, sbyte skillQualificationPrecocious, sbyte skillQualificationLateBlooming, MainAttributes mainAttributes, MainAttributes mainAttributesRecoveries, short fertilityMale, short fertilityFemale)
	{
		TemplateId = templateId;
		SkillQualificationAverage = skillQualificationAverage;
		SkillQualificationPrecocious = skillQualificationPrecocious;
		SkillQualificationLateBlooming = skillQualificationLateBlooming;
		MainAttributes = mainAttributes;
		MainAttributesRecoveries = mainAttributesRecoveries;
		FertilityMale = fertilityMale;
		FertilityFemale = fertilityFemale;
	}

	public AgeEffectItem()
	{
		TemplateId = 0;
		SkillQualificationAverage = 0;
		SkillQualificationPrecocious = 0;
		SkillQualificationLateBlooming = 0;
		MainAttributes = new MainAttributes(100, 100, 100, 100, 100, 100);
		MainAttributesRecoveries = new MainAttributes(100, 100, 100, 100, 100, 100);
		FertilityMale = 0;
		FertilityFemale = 0;
	}

	public AgeEffectItem(sbyte templateId, AgeEffectItem other)
	{
		TemplateId = templateId;
		SkillQualificationAverage = other.SkillQualificationAverage;
		SkillQualificationPrecocious = other.SkillQualificationPrecocious;
		SkillQualificationLateBlooming = other.SkillQualificationLateBlooming;
		MainAttributes = other.MainAttributes;
		MainAttributesRecoveries = other.MainAttributesRecoveries;
		FertilityMale = other.FertilityMale;
		FertilityFemale = other.FertilityFemale;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AgeEffectItem Duplicate(int templateId)
	{
		return new AgeEffectItem((sbyte)templateId, this);
	}
}
