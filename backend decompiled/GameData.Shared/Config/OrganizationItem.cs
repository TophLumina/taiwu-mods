using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using Config.ConfigCells.Character;
using GameData.Utilities;

namespace Config;

[Serializable]
public class OrganizationItem : ConfigItem<OrganizationItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string TaiwuVillageSteleDesc;

	public readonly string Icon;

	public readonly string MousetipIcon;

	public readonly short Culture;

	public readonly short Safety;

	public readonly int Population;

	public readonly short[] CharTemplateIds;

	public readonly short[] RandomEnemyTemplateIds;

	public readonly EOrganizationSettlementType SettlementType;

	public readonly bool IsSect;

	public readonly bool IsCivilian;

	public readonly sbyte SeniorityGroupId;

	public readonly sbyte Goodness;

	public readonly short MainMorality;

	public readonly sbyte GenderRestriction;

	public readonly sbyte TeachingOutsiderProb;

	public readonly bool Hereditary;

	public readonly bool AllowPoisoning;

	public readonly bool NoMeatEating;

	public readonly bool NoDrinking;

	public readonly sbyte MerchantTendency;

	public readonly sbyte MerchantLevel;

	public readonly sbyte LegendaryBookTendency;

	public readonly List<sbyte> AbandonedBabyOrganizations;

	public readonly short PunishmentFeature;

	public readonly List<short> TaiwuPunishementFeature;

	public readonly List<sbyte> LearnLifeSkillTypes;

	public readonly List<sbyte> CombatSkillTypes;

	public readonly sbyte FiveElementsType;

	public readonly short InfluencePowerUpdateInterval;

	public readonly sbyte[] LargeSectFavorabilities;

	public readonly short[] Members;

	public readonly sbyte RetireGrade;

	public readonly short MemberFeature;

	public readonly string OrganizationExtraDesc;

	public readonly short PrisonBuilding;

	public readonly short[] MartialArtistItemBonus;

	public readonly string VowSpecialHint;

	public readonly short TaiwuBeHunted;

	public readonly ShortPair[] SkillBreakBonusWeights;

	public readonly List<LifeSkillCombatBriberyItemTypeWeight> LifeSkillCombatBriberyItemTypeWeight;

	public readonly List<LifeSkillCombatBriberyItemSubTypeWeight> LifeSkillCombatBriberyItemSubTypeWeight;

	public readonly List<PresetInventoryItem> VowFixedRewardItems;

	public readonly List<PresetInventoryItem> VowRandomRewardItems;

	public readonly int VowRandomRewardItemsCount;

	public readonly int PopulationThreshold;

	public SectMainStoryItem SectMainStory
	{
		get
		{
			if (!IsSect)
			{
				return null;
			}
			return Config.SectMainStory.Instance[TemplateId - 1];
		}
	}

	public OrganizationItem(sbyte templateId, string name, string desc, string taiwuVillageSteleDesc, string icon, string mousetipIcon, short culture, short safety, int population, short[] charTemplateIds, short[] randomEnemyTemplateIds, EOrganizationSettlementType settlementType, bool isSect, bool isCivilian, sbyte seniorityGroupId, sbyte goodness, short mainMorality, sbyte genderRestriction, sbyte teachingOutsiderProb, bool hereditary, bool allowPoisoning, bool noMeatEating, bool noDrinking, sbyte merchantTendency, sbyte merchantLevel, sbyte legendaryBookTendency, List<sbyte> abandonedBabyOrganizations, short punishmentFeature, List<short> taiwuPunishementFeature, List<sbyte> learnLifeSkillTypes, List<sbyte> combatSkillTypes, sbyte fiveElementsType, short influencePowerUpdateInterval, sbyte[] largeSectFavorabilities, short[] members, sbyte retireGrade, short memberFeature, string organizationExtraDesc, short prisonBuilding, short[] martialArtistItemBonus, string vowSpecialHint, short taiwuBeHunted, ShortPair[] skillBreakBonusWeights, List<LifeSkillCombatBriberyItemTypeWeight> lifeSkillCombatBriberyItemTypeWeight, List<LifeSkillCombatBriberyItemSubTypeWeight> lifeSkillCombatBriberyItemSubTypeWeight, List<PresetInventoryItem> vowFixedRewardItems, List<PresetInventoryItem> vowRandomRewardItems, int vowRandomRewardItemsCount, int populationThreshold)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		TaiwuVillageSteleDesc = taiwuVillageSteleDesc;
		Icon = icon;
		MousetipIcon = mousetipIcon;
		Culture = culture;
		Safety = safety;
		Population = population;
		CharTemplateIds = charTemplateIds;
		RandomEnemyTemplateIds = randomEnemyTemplateIds;
		SettlementType = settlementType;
		IsSect = isSect;
		IsCivilian = isCivilian;
		SeniorityGroupId = seniorityGroupId;
		Goodness = goodness;
		MainMorality = mainMorality;
		GenderRestriction = genderRestriction;
		TeachingOutsiderProb = teachingOutsiderProb;
		Hereditary = hereditary;
		AllowPoisoning = allowPoisoning;
		NoMeatEating = noMeatEating;
		NoDrinking = noDrinking;
		MerchantTendency = merchantTendency;
		MerchantLevel = merchantLevel;
		LegendaryBookTendency = legendaryBookTendency;
		AbandonedBabyOrganizations = abandonedBabyOrganizations;
		PunishmentFeature = punishmentFeature;
		TaiwuPunishementFeature = taiwuPunishementFeature;
		LearnLifeSkillTypes = learnLifeSkillTypes;
		CombatSkillTypes = combatSkillTypes;
		FiveElementsType = fiveElementsType;
		InfluencePowerUpdateInterval = influencePowerUpdateInterval;
		LargeSectFavorabilities = largeSectFavorabilities;
		Members = members;
		RetireGrade = retireGrade;
		MemberFeature = memberFeature;
		OrganizationExtraDesc = organizationExtraDesc;
		PrisonBuilding = prisonBuilding;
		MartialArtistItemBonus = martialArtistItemBonus;
		VowSpecialHint = vowSpecialHint;
		TaiwuBeHunted = taiwuBeHunted;
		SkillBreakBonusWeights = skillBreakBonusWeights;
		LifeSkillCombatBriberyItemTypeWeight = lifeSkillCombatBriberyItemTypeWeight;
		LifeSkillCombatBriberyItemSubTypeWeight = lifeSkillCombatBriberyItemSubTypeWeight;
		VowFixedRewardItems = vowFixedRewardItems;
		VowRandomRewardItems = vowRandomRewardItems;
		VowRandomRewardItemsCount = vowRandomRewardItemsCount;
		PopulationThreshold = populationThreshold;
	}

	public OrganizationItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		TaiwuVillageSteleDesc = null;
		Icon = null;
		MousetipIcon = null;
		Culture = 0;
		Safety = 0;
		Population = 0;
		CharTemplateIds = new short[2] { -1, -1 };
		RandomEnemyTemplateIds = new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
		SettlementType = EOrganizationSettlementType.Invalid;
		IsSect = false;
		IsCivilian = true;
		SeniorityGroupId = -1;
		Goodness = 0;
		MainMorality = short.MinValue;
		GenderRestriction = -1;
		TeachingOutsiderProb = 30;
		Hereditary = true;
		AllowPoisoning = true;
		NoMeatEating = false;
		NoDrinking = false;
		MerchantTendency = 0;
		MerchantLevel = 1;
		LegendaryBookTendency = 0;
		AbandonedBabyOrganizations = new List<sbyte>();
		PunishmentFeature = 0;
		TaiwuPunishementFeature = null;
		LearnLifeSkillTypes = new List<sbyte>();
		CombatSkillTypes = new List<sbyte>();
		FiveElementsType = -1;
		InfluencePowerUpdateInterval = -1;
		LargeSectFavorabilities = new sbyte[15];
		Members = null;
		RetireGrade = 0;
		MemberFeature = 0;
		OrganizationExtraDesc = null;
		PrisonBuilding = 0;
		MartialArtistItemBonus = null;
		VowSpecialHint = null;
		TaiwuBeHunted = 0;
		SkillBreakBonusWeights = null;
		LifeSkillCombatBriberyItemTypeWeight = new List<LifeSkillCombatBriberyItemTypeWeight>();
		LifeSkillCombatBriberyItemSubTypeWeight = new List<LifeSkillCombatBriberyItemSubTypeWeight>();
		VowFixedRewardItems = null;
		VowRandomRewardItems = null;
		VowRandomRewardItemsCount = 0;
		PopulationThreshold = -1;
	}

	public OrganizationItem(sbyte templateId, OrganizationItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		TaiwuVillageSteleDesc = other.TaiwuVillageSteleDesc;
		Icon = other.Icon;
		MousetipIcon = other.MousetipIcon;
		Culture = other.Culture;
		Safety = other.Safety;
		Population = other.Population;
		CharTemplateIds = other.CharTemplateIds;
		RandomEnemyTemplateIds = other.RandomEnemyTemplateIds;
		SettlementType = other.SettlementType;
		IsSect = other.IsSect;
		IsCivilian = other.IsCivilian;
		SeniorityGroupId = other.SeniorityGroupId;
		Goodness = other.Goodness;
		MainMorality = other.MainMorality;
		GenderRestriction = other.GenderRestriction;
		TeachingOutsiderProb = other.TeachingOutsiderProb;
		Hereditary = other.Hereditary;
		AllowPoisoning = other.AllowPoisoning;
		NoMeatEating = other.NoMeatEating;
		NoDrinking = other.NoDrinking;
		MerchantTendency = other.MerchantTendency;
		MerchantLevel = other.MerchantLevel;
		LegendaryBookTendency = other.LegendaryBookTendency;
		AbandonedBabyOrganizations = other.AbandonedBabyOrganizations;
		PunishmentFeature = other.PunishmentFeature;
		TaiwuPunishementFeature = other.TaiwuPunishementFeature;
		LearnLifeSkillTypes = other.LearnLifeSkillTypes;
		CombatSkillTypes = other.CombatSkillTypes;
		FiveElementsType = other.FiveElementsType;
		InfluencePowerUpdateInterval = other.InfluencePowerUpdateInterval;
		LargeSectFavorabilities = other.LargeSectFavorabilities;
		Members = other.Members;
		RetireGrade = other.RetireGrade;
		MemberFeature = other.MemberFeature;
		OrganizationExtraDesc = other.OrganizationExtraDesc;
		PrisonBuilding = other.PrisonBuilding;
		MartialArtistItemBonus = other.MartialArtistItemBonus;
		VowSpecialHint = other.VowSpecialHint;
		TaiwuBeHunted = other.TaiwuBeHunted;
		SkillBreakBonusWeights = other.SkillBreakBonusWeights;
		LifeSkillCombatBriberyItemTypeWeight = other.LifeSkillCombatBriberyItemTypeWeight;
		LifeSkillCombatBriberyItemSubTypeWeight = other.LifeSkillCombatBriberyItemSubTypeWeight;
		VowFixedRewardItems = other.VowFixedRewardItems;
		VowRandomRewardItems = other.VowRandomRewardItems;
		VowRandomRewardItemsCount = other.VowRandomRewardItemsCount;
		PopulationThreshold = other.PopulationThreshold;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override OrganizationItem Duplicate(int templateId)
	{
		return new OrganizationItem((sbyte)templateId, this);
	}
}
