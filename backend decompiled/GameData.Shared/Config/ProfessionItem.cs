using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ProfessionItem : ConfigItem<ProfessionItem, int>
{
	public readonly int TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string TextureBig;

	public readonly string Texture;

	public readonly string TextureSmall;

	public readonly string NameSprite;

	public readonly int[] ProfessionSkills;

	public readonly int ExtraProfessionSkill;

	public readonly List<sbyte> BonusLifeSkills;

	public readonly List<sbyte> BonusCombatSkills;

	public readonly short BonusClothing;

	public readonly uint DlcAppId;

	public readonly List<int> ConflictingProfessions;

	public readonly List<int> CompatibleProfessions;

	public readonly bool ForbidWine;

	public readonly bool ForbidMeat;

	public readonly bool ForbidSex;

	public readonly bool ReinitOnCrossArchive;

	public readonly string[] SeniorityGainTips;

	public readonly uint[] SeniorityGainTipsDlcId;

	public readonly int[] ProfessionSeniorityPerMonth;

	public readonly string DemandTeachingText;

	public readonly string DemandTeachingFinishText;

	public ProfessionItem(int templateId, string name, string desc, string textureBig, string texture, string textureSmall, string nameSprite, int[] professionSkills, int extraProfessionSkill, List<sbyte> bonusLifeSkills, List<sbyte> bonusCombatSkills, short bonusClothing, uint dlcAppId, List<int> conflictingProfessions, List<int> compatibleProfessions, bool forbidWine, bool forbidMeat, bool forbidSex, bool reinitOnCrossArchive, string[] seniorityGainTips, uint[] seniorityGainTipsDlcId, int[] professionSeniorityPerMonth, string demandTeachingText, string demandTeachingFinishText)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		TextureBig = textureBig;
		Texture = texture;
		TextureSmall = textureSmall;
		NameSprite = nameSprite;
		ProfessionSkills = professionSkills;
		ExtraProfessionSkill = extraProfessionSkill;
		BonusLifeSkills = bonusLifeSkills;
		BonusCombatSkills = bonusCombatSkills;
		BonusClothing = bonusClothing;
		DlcAppId = dlcAppId;
		ConflictingProfessions = conflictingProfessions;
		CompatibleProfessions = compatibleProfessions;
		ForbidWine = forbidWine;
		ForbidMeat = forbidMeat;
		ForbidSex = forbidSex;
		ReinitOnCrossArchive = reinitOnCrossArchive;
		SeniorityGainTips = seniorityGainTips;
		SeniorityGainTipsDlcId = seniorityGainTipsDlcId;
		ProfessionSeniorityPerMonth = professionSeniorityPerMonth;
		DemandTeachingText = demandTeachingText;
		DemandTeachingFinishText = demandTeachingFinishText;
	}

	public ProfessionItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		TextureBig = null;
		Texture = null;
		TextureSmall = null;
		NameSprite = null;
		ProfessionSkills = new int[0];
		ExtraProfessionSkill = 0;
		BonusLifeSkills = new List<sbyte>();
		BonusCombatSkills = new List<sbyte>();
		BonusClothing = 0;
		DlcAppId = 0u;
		ConflictingProfessions = new List<int>();
		CompatibleProfessions = new List<int>();
		ForbidWine = false;
		ForbidMeat = false;
		ForbidSex = false;
		ReinitOnCrossArchive = true;
		SeniorityGainTips = new string[0];
		SeniorityGainTipsDlcId = new uint[0];
		ProfessionSeniorityPerMonth = null;
		DemandTeachingText = null;
		DemandTeachingFinishText = null;
	}

	public ProfessionItem(int templateId, ProfessionItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		TextureBig = other.TextureBig;
		Texture = other.Texture;
		TextureSmall = other.TextureSmall;
		NameSprite = other.NameSprite;
		ProfessionSkills = other.ProfessionSkills;
		ExtraProfessionSkill = other.ExtraProfessionSkill;
		BonusLifeSkills = other.BonusLifeSkills;
		BonusCombatSkills = other.BonusCombatSkills;
		BonusClothing = other.BonusClothing;
		DlcAppId = other.DlcAppId;
		ConflictingProfessions = other.ConflictingProfessions;
		CompatibleProfessions = other.CompatibleProfessions;
		ForbidWine = other.ForbidWine;
		ForbidMeat = other.ForbidMeat;
		ForbidSex = other.ForbidSex;
		ReinitOnCrossArchive = other.ReinitOnCrossArchive;
		SeniorityGainTips = other.SeniorityGainTips;
		SeniorityGainTipsDlcId = other.SeniorityGainTipsDlcId;
		ProfessionSeniorityPerMonth = other.ProfessionSeniorityPerMonth;
		DemandTeachingText = other.DemandTeachingText;
		DemandTeachingFinishText = other.DemandTeachingFinishText;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ProfessionItem Duplicate(int templateId)
	{
		return new ProfessionItem(templateId, this);
	}
}
