using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using Config.ConfigCells;
using Config.ConfigCells.Character;
using GameData.Domains.Character;
using GameData.Domains.Combat;

namespace Config;

[Serializable]
public class CharacterItem : ConfigItem<CharacterItem, short>, IImmunityMaskProvider
{
	public readonly short TemplateId;

	public readonly string Surname;

	public readonly string GivenName;

	public readonly string AnonymousTitle;

	public readonly sbyte SpecialCombatSkeleton;

	public readonly string FixedAvatarName;

	public readonly string FixedAvatarSpineName;

	public readonly string FixedAvatarSpineSkin;

	public readonly byte CreatingType;

	public readonly short GroupId;

	public readonly int CombatAi;

	public readonly bool CanDefeat;

	public readonly bool CanMove;

	public readonly bool CanOpenCharacterMenu;

	public readonly bool IsFavorabilityDisplay;

	public readonly bool HideAge;

	public readonly bool AllowUseFreeWeapon;

	public readonly bool AllowEscape;

	public readonly bool CanSpeak;

	public readonly bool CanBeTaiwu;

	public readonly bool CanBePossessionBody;

	public readonly bool CanBePossessionSoul;

	public readonly string SpecialMuteBubbleSelf;

	public readonly string SpecialMuteBubbleEnemy;

	public readonly ECharacterSpecialTemmateType SpecialTemmateType;

	public readonly bool FixedCharacterShowNameOnMap;

	public readonly bool RandomAnimalAttack;

	public readonly bool XiangshuInfectedDemonBonus;

	public readonly bool AllowHeal;

	public readonly bool CanBeKidnapped;

	public readonly bool RandomFeaturesAtCreating;

	public readonly List<short> FeatureIds;

	public readonly short MinionGroupId;

	public readonly short ChallengeModeMinionGroupId;

	public readonly short RandomEnemyId;

	public readonly short LeadingEnemyNestId;

	public readonly bool AllowFavorabilitySkipCd;

	public readonly sbyte[] RandomEnemyFavorability;

	public readonly sbyte Gender;

	public readonly sbyte PresetBodyType;

	public readonly sbyte Race;

	public readonly bool Transgender;

	public readonly bool Bisexual;

	public readonly sbyte PresetFame;

	public readonly sbyte Happiness;

	public readonly short BaseAttraction;

	public readonly short BaseMorality;

	public readonly short ActualAge;

	public readonly short InitCurrAge;

	public readonly short Health;

	public readonly short BaseMaxHealth;

	public readonly sbyte BirthMonth;

	public readonly OrganizationInfo OrganizationInfo;

	public readonly string SpecialGradeName;

	public readonly sbyte IdealSect;

	public readonly List<sbyte> RandomIdealSects;

	public readonly sbyte XiangshuType;

	public readonly byte MonkType;

	public readonly sbyte LifeSkillTypeInterest;

	public readonly sbyte CombatSkillTypeInterest;

	public readonly sbyte MainAttributeInterest;

	public readonly int ExtraEquipmentLoad;

	public readonly short FixWeaponPower;

	public readonly short FixArmorPower;

	public readonly short FixCombatSkillPower;

	public readonly MainAttributes BaseMainAttributes;

	public readonly HitOrAvoidInts BaseHitValues;

	public readonly OuterAndInnerInts BasePenetrations;

	public readonly HitOrAvoidInts BaseAvoidValues;

	public readonly OuterAndInnerInts BasePenetrationResists;

	public readonly OuterAndInnerShorts BaseRecoveryOfStanceAndBreath;

	public readonly short BaseMoveSpeed;

	public readonly short BaseRecoveryOfFlaw;

	public readonly short BaseCastSpeed;

	public readonly short BaseRecoveryOfBlockedAcupoint;

	public readonly short BaseWeaponSwitchSpeed;

	public readonly short BaseAttackSpeed;

	public readonly short BaseInnerRatio;

	public readonly short BaseRecoveryOfQiDisorder;

	public readonly PoisonInts BasePoisonResists;

	public readonly bool InnerInjuryImmunity;

	public readonly bool OuterInjuryImmunity;

	public readonly bool MindImmunity;

	public readonly bool FlawImmunity;

	public readonly bool AcupointImmunity;

	public readonly bool FatalImmunity;

	public readonly bool DieImmunity;

	public readonly bool[] PoisonImmunities;

	public readonly short DisorderOfQi;

	public readonly bool HaveLeftArm;

	public readonly bool HaveRightArm;

	public readonly bool HaveLeftLeg;

	public readonly bool HaveRightLeg;

	public readonly Injuries Injuries;

	public readonly DamageStepCollection DamageSteps;

	public readonly NeiliAllocation ExtraNeiliAllocation;

	public readonly int ExtraNeili;

	public readonly sbyte ConsummateLevel;

	public readonly PresetEquipmentItem[] PresetEquipment;

	public readonly bool[] EquipmentLock;

	public readonly List<PresetInventoryItem> PresetInventory;

	public readonly int DropRatePercentAsMainChar;

	public readonly int DropRatePercentAsTeammate;

	public readonly List<PresetItemTemplateId> PresetEatingItems;

	public readonly bool AllowDropWugKing;

	public readonly List<PresetCombatSkill> PresetCombatSkills;

	public readonly sbyte[] ExtraCombatSkillGrids;

	public readonly List<sbyte> DisableTeammateCommands;

	public readonly List<sbyte> PresetTeammateCommands;

	public readonly NeiliProportionOfFiveElements PresetNeiliProportionOfFiveElements;

	public readonly sbyte[] IdeaAllocationProportion;

	public readonly LifeSkillShorts BaseLifeSkillQualifications;

	public readonly sbyte LifeSkillQualificationGrowthType;

	public readonly List<GameData.Domains.Character.LifeSkillItem> LearnedLifeSkills;

	public readonly sbyte[] LearnedLifeSkillGrades;

	public readonly CombatSkillShorts BaseCombatSkillQualifications;

	public readonly sbyte CombatSkillQualificationGrowthType;

	public readonly ResourceInts Resources;

	public readonly ResourceInts DropResources;

	public readonly short LovingItemSubType;

	public readonly short HatingItemSubType;

	public readonly bool ShowLegendaryBookConsumedCloth;

	public readonly string AvatarDataPath;

	public readonly ECharacterGroupType GroupType;

	public readonly bool TaiwuAsXiangshuDelete;

	public readonly bool ConvertToIntelligent;

	public readonly string InfectedFixedAvatarName;

	public readonly string InfectedFixedAvatarSpineName;

	public readonly string InfectedFixedAvatarSpineSkin;

	public CharacterItem Group
	{
		[return: MaybeNull]
		get
		{
			return Character.Instance.GetItemOrDefault(GroupId);
		}
	}

	public MinionGroupItem MinionGroup
	{
		[return: MaybeNull]
		get
		{
			return Config.MinionGroup.Instance.GetItemOrDefault(MinionGroupId);
		}
	}

	public MinionGroupItem ChallengeModeMinionGroup
	{
		[return: MaybeNull]
		get
		{
			return Config.MinionGroup.Instance.GetItemOrDefault(ChallengeModeMinionGroupId);
		}
	}

	public RandomEnemyItem RandomEnemy
	{
		[return: MaybeNull]
		get
		{
			return Config.RandomEnemy.Instance.GetItemOrDefault(RandomEnemyId);
		}
	}

	public EnemyNestItem LeadingEnemyNest
	{
		[return: MaybeNull]
		get
		{
			return EnemyNest.Instance.GetItemOrDefault(LeadingEnemyNestId);
		}
	}

	bool IImmunityMaskProvider.InnerInjuryImmunity => InnerInjuryImmunity;

	bool IImmunityMaskProvider.OuterInjuryImmunity => OuterInjuryImmunity;

	bool IImmunityMaskProvider.MindImmunity => MindImmunity;

	bool IImmunityMaskProvider.FlawImmunity => FlawImmunity;

	bool IImmunityMaskProvider.AcupointImmunity => AcupointImmunity;

	bool IImmunityMaskProvider.FatalImmunity => FatalImmunity;

	bool IImmunityMaskProvider.DieImmunity => DieImmunity;

	IReadOnlyList<bool> IImmunityMaskProvider.PoisonImmunities => PoisonImmunities;

	public CharacterItem(short templateId, string surname, string givenName, string anonymousTitle, sbyte specialCombatSkeleton, string fixedAvatarName, string fixedAvatarSpineName, string fixedAvatarSpineSkin, byte creatingType, short groupId, int combatAi, bool canDefeat, bool canMove, bool canOpenCharacterMenu, bool isFavorabilityDisplay, bool hideAge, bool allowUseFreeWeapon, bool allowEscape, bool canSpeak, bool canBeTaiwu, bool canBePossessionBody, bool canBePossessionSoul, string specialMuteBubbleSelf, string specialMuteBubbleEnemy, ECharacterSpecialTemmateType specialTemmateType, bool fixedCharacterShowNameOnMap, bool randomAnimalAttack, bool xiangshuInfectedDemonBonus, bool allowHeal, bool canBeKidnapped, bool randomFeaturesAtCreating, List<short> featureIds, short minionGroupId, short challengeModeMinionGroupId, short randomEnemyId, short leadingEnemyNestId, bool allowFavorabilitySkipCd, sbyte[] randomEnemyFavorability, sbyte gender, sbyte presetBodyType, sbyte race, bool transgender, bool bisexual, sbyte presetFame, sbyte happiness, short baseAttraction, short baseMorality, short actualAge, short initCurrAge, short health, short baseMaxHealth, sbyte birthMonth, OrganizationInfo organizationInfo, string specialGradeName, sbyte idealSect, List<sbyte> randomIdealSects, sbyte xiangshuType, byte monkType, sbyte lifeSkillTypeInterest, sbyte combatSkillTypeInterest, sbyte mainAttributeInterest, int extraEquipmentLoad, short fixWeaponPower, short fixArmorPower, short fixCombatSkillPower, MainAttributes baseMainAttributes, HitOrAvoidInts baseHitValues, OuterAndInnerInts basePenetrations, HitOrAvoidInts baseAvoidValues, OuterAndInnerInts basePenetrationResists, OuterAndInnerShorts baseRecoveryOfStanceAndBreath, short baseMoveSpeed, short baseRecoveryOfFlaw, short baseCastSpeed, short baseRecoveryOfBlockedAcupoint, short baseWeaponSwitchSpeed, short baseAttackSpeed, short baseInnerRatio, short baseRecoveryOfQiDisorder, PoisonInts basePoisonResists, bool innerInjuryImmunity, bool outerInjuryImmunity, bool mindImmunity, bool flawImmunity, bool acupointImmunity, bool fatalImmunity, bool dieImmunity, bool[] poisonImmunities, short disorderOfQi, bool haveLeftArm, bool haveRightArm, bool haveLeftLeg, bool haveRightLeg, Injuries injuries, DamageStepCollection damageSteps, NeiliAllocation extraNeiliAllocation, int extraNeili, sbyte consummateLevel, PresetEquipmentItem[] presetEquipment, bool[] equipmentLock, List<PresetInventoryItem> presetInventory, int dropRatePercentAsMainChar, int dropRatePercentAsTeammate, List<PresetItemTemplateId> presetEatingItems, bool allowDropWugKing, List<PresetCombatSkill> presetCombatSkills, sbyte[] extraCombatSkillGrids, List<sbyte> disableTeammateCommands, List<sbyte> presetTeammateCommands, NeiliProportionOfFiveElements presetNeiliProportionOfFiveElements, sbyte[] ideaAllocationProportion, LifeSkillShorts baseLifeSkillQualifications, sbyte lifeSkillQualificationGrowthType, List<GameData.Domains.Character.LifeSkillItem> learnedLifeSkills, sbyte[] learnedLifeSkillGrades, CombatSkillShorts baseCombatSkillQualifications, sbyte combatSkillQualificationGrowthType, ResourceInts resources, ResourceInts dropResources, short lovingItemSubType, short hatingItemSubType, bool showLegendaryBookConsumedCloth, string avatarDataPath, ECharacterGroupType groupType, bool taiwuAsXiangshuDelete, bool convertToIntelligent, string infectedFixedAvatarName, string infectedFixedAvatarSpineName, string infectedFixedAvatarSpineSkin)
	{
		TemplateId = templateId;
		Surname = surname;
		GivenName = givenName;
		AnonymousTitle = anonymousTitle;
		SpecialCombatSkeleton = specialCombatSkeleton;
		FixedAvatarName = fixedAvatarName;
		FixedAvatarSpineName = fixedAvatarSpineName;
		FixedAvatarSpineSkin = fixedAvatarSpineSkin;
		CreatingType = creatingType;
		GroupId = groupId;
		CombatAi = combatAi;
		CanDefeat = canDefeat;
		CanMove = canMove;
		CanOpenCharacterMenu = canOpenCharacterMenu;
		IsFavorabilityDisplay = isFavorabilityDisplay;
		HideAge = hideAge;
		AllowUseFreeWeapon = allowUseFreeWeapon;
		AllowEscape = allowEscape;
		CanSpeak = canSpeak;
		CanBeTaiwu = canBeTaiwu;
		CanBePossessionBody = canBePossessionBody;
		CanBePossessionSoul = canBePossessionSoul;
		SpecialMuteBubbleSelf = specialMuteBubbleSelf;
		SpecialMuteBubbleEnemy = specialMuteBubbleEnemy;
		SpecialTemmateType = specialTemmateType;
		FixedCharacterShowNameOnMap = fixedCharacterShowNameOnMap;
		RandomAnimalAttack = randomAnimalAttack;
		XiangshuInfectedDemonBonus = xiangshuInfectedDemonBonus;
		AllowHeal = allowHeal;
		CanBeKidnapped = canBeKidnapped;
		RandomFeaturesAtCreating = randomFeaturesAtCreating;
		FeatureIds = featureIds;
		MinionGroupId = minionGroupId;
		ChallengeModeMinionGroupId = challengeModeMinionGroupId;
		RandomEnemyId = randomEnemyId;
		LeadingEnemyNestId = leadingEnemyNestId;
		AllowFavorabilitySkipCd = allowFavorabilitySkipCd;
		RandomEnemyFavorability = randomEnemyFavorability;
		Gender = gender;
		PresetBodyType = presetBodyType;
		Race = race;
		Transgender = transgender;
		Bisexual = bisexual;
		PresetFame = presetFame;
		Happiness = happiness;
		BaseAttraction = baseAttraction;
		BaseMorality = baseMorality;
		ActualAge = actualAge;
		InitCurrAge = initCurrAge;
		Health = health;
		BaseMaxHealth = baseMaxHealth;
		BirthMonth = birthMonth;
		OrganizationInfo = organizationInfo;
		SpecialGradeName = specialGradeName;
		IdealSect = idealSect;
		RandomIdealSects = randomIdealSects;
		XiangshuType = xiangshuType;
		MonkType = monkType;
		LifeSkillTypeInterest = lifeSkillTypeInterest;
		CombatSkillTypeInterest = combatSkillTypeInterest;
		MainAttributeInterest = mainAttributeInterest;
		ExtraEquipmentLoad = extraEquipmentLoad;
		FixWeaponPower = fixWeaponPower;
		FixArmorPower = fixArmorPower;
		FixCombatSkillPower = fixCombatSkillPower;
		BaseMainAttributes = baseMainAttributes;
		BaseHitValues = baseHitValues;
		BasePenetrations = basePenetrations;
		BaseAvoidValues = baseAvoidValues;
		BasePenetrationResists = basePenetrationResists;
		BaseRecoveryOfStanceAndBreath = baseRecoveryOfStanceAndBreath;
		BaseMoveSpeed = baseMoveSpeed;
		BaseRecoveryOfFlaw = baseRecoveryOfFlaw;
		BaseCastSpeed = baseCastSpeed;
		BaseRecoveryOfBlockedAcupoint = baseRecoveryOfBlockedAcupoint;
		BaseWeaponSwitchSpeed = baseWeaponSwitchSpeed;
		BaseAttackSpeed = baseAttackSpeed;
		BaseInnerRatio = baseInnerRatio;
		BaseRecoveryOfQiDisorder = baseRecoveryOfQiDisorder;
		BasePoisonResists = basePoisonResists;
		InnerInjuryImmunity = innerInjuryImmunity;
		OuterInjuryImmunity = outerInjuryImmunity;
		MindImmunity = mindImmunity;
		FlawImmunity = flawImmunity;
		AcupointImmunity = acupointImmunity;
		FatalImmunity = fatalImmunity;
		DieImmunity = dieImmunity;
		PoisonImmunities = poisonImmunities;
		DisorderOfQi = disorderOfQi;
		HaveLeftArm = haveLeftArm;
		HaveRightArm = haveRightArm;
		HaveLeftLeg = haveLeftLeg;
		HaveRightLeg = haveRightLeg;
		Injuries = injuries;
		DamageSteps = damageSteps;
		ExtraNeiliAllocation = extraNeiliAllocation;
		ExtraNeili = extraNeili;
		ConsummateLevel = consummateLevel;
		PresetEquipment = presetEquipment;
		EquipmentLock = equipmentLock;
		PresetInventory = presetInventory;
		DropRatePercentAsMainChar = dropRatePercentAsMainChar;
		DropRatePercentAsTeammate = dropRatePercentAsTeammate;
		PresetEatingItems = presetEatingItems;
		AllowDropWugKing = allowDropWugKing;
		PresetCombatSkills = presetCombatSkills;
		ExtraCombatSkillGrids = extraCombatSkillGrids;
		DisableTeammateCommands = disableTeammateCommands;
		PresetTeammateCommands = presetTeammateCommands;
		PresetNeiliProportionOfFiveElements = presetNeiliProportionOfFiveElements;
		IdeaAllocationProportion = ideaAllocationProportion;
		BaseLifeSkillQualifications = baseLifeSkillQualifications;
		LifeSkillQualificationGrowthType = lifeSkillQualificationGrowthType;
		LearnedLifeSkills = learnedLifeSkills;
		LearnedLifeSkillGrades = learnedLifeSkillGrades;
		BaseCombatSkillQualifications = baseCombatSkillQualifications;
		CombatSkillQualificationGrowthType = combatSkillQualificationGrowthType;
		Resources = resources;
		DropResources = dropResources;
		LovingItemSubType = lovingItemSubType;
		HatingItemSubType = hatingItemSubType;
		ShowLegendaryBookConsumedCloth = showLegendaryBookConsumedCloth;
		AvatarDataPath = avatarDataPath;
		GroupType = groupType;
		TaiwuAsXiangshuDelete = taiwuAsXiangshuDelete;
		ConvertToIntelligent = convertToIntelligent;
		InfectedFixedAvatarName = infectedFixedAvatarName;
		InfectedFixedAvatarSpineName = infectedFixedAvatarSpineName;
		InfectedFixedAvatarSpineSkin = infectedFixedAvatarSpineSkin;
	}

	public CharacterItem()
	{
		TemplateId = 0;
		Surname = null;
		GivenName = null;
		AnonymousTitle = null;
		SpecialCombatSkeleton = 0;
		FixedAvatarName = null;
		FixedAvatarSpineName = null;
		FixedAvatarSpineSkin = null;
		CreatingType = 0;
		GroupId = 0;
		CombatAi = 0;
		CanDefeat = true;
		CanMove = true;
		CanOpenCharacterMenu = true;
		IsFavorabilityDisplay = false;
		HideAge = true;
		AllowUseFreeWeapon = true;
		AllowEscape = false;
		CanSpeak = true;
		CanBeTaiwu = true;
		CanBePossessionBody = true;
		CanBePossessionSoul = true;
		SpecialMuteBubbleSelf = null;
		SpecialMuteBubbleEnemy = null;
		SpecialTemmateType = ECharacterSpecialTemmateType.Invalid;
		FixedCharacterShowNameOnMap = true;
		RandomAnimalAttack = false;
		XiangshuInfectedDemonBonus = false;
		AllowHeal = true;
		CanBeKidnapped = true;
		RandomFeaturesAtCreating = false;
		FeatureIds = new List<short>();
		MinionGroupId = 0;
		ChallengeModeMinionGroupId = 0;
		RandomEnemyId = 0;
		LeadingEnemyNestId = 0;
		AllowFavorabilitySkipCd = true;
		RandomEnemyFavorability = new sbyte[4] { 10, 30, 50, 10 };
		Gender = -1;
		PresetBodyType = -1;
		Race = 0;
		Transgender = false;
		Bisexual = false;
		PresetFame = 0;
		Happiness = 0;
		BaseAttraction = -1;
		BaseMorality = 0;
		ActualAge = -1;
		InitCurrAge = -1;
		Health = 0;
		BaseMaxHealth = 0;
		BirthMonth = -1;
		OrganizationInfo = new OrganizationInfo(0, 0, principal: true, -1);
		SpecialGradeName = null;
		IdealSect = 0;
		RandomIdealSects = new List<sbyte>();
		XiangshuType = 0;
		MonkType = 0;
		LifeSkillTypeInterest = 0;
		CombatSkillTypeInterest = 0;
		MainAttributeInterest = -1;
		ExtraEquipmentLoad = 0;
		FixWeaponPower = -1;
		FixArmorPower = -1;
		FixCombatSkillPower = -1;
		BaseMainAttributes = new MainAttributes(30, 30, 30, 30, 30, 30);
		BaseHitValues = new HitOrAvoidInts(default(int), default(int), default(int), default(int));
		BasePenetrations = new OuterAndInnerInts(0, 0);
		BaseAvoidValues = new HitOrAvoidInts(default(int), default(int), default(int), default(int));
		BasePenetrationResists = new OuterAndInnerInts(0, 0);
		BaseRecoveryOfStanceAndBreath = new OuterAndInnerShorts(100, 100);
		BaseMoveSpeed = 100;
		BaseRecoveryOfFlaw = 100;
		BaseCastSpeed = 100;
		BaseRecoveryOfBlockedAcupoint = 100;
		BaseWeaponSwitchSpeed = 100;
		BaseAttackSpeed = 100;
		BaseInnerRatio = 100;
		BaseRecoveryOfQiDisorder = 100;
		BasePoisonResists = new PoisonInts(default(int), default(int), default(int), default(int), default(int), default(int));
		InnerInjuryImmunity = false;
		OuterInjuryImmunity = false;
		MindImmunity = false;
		FlawImmunity = false;
		AcupointImmunity = false;
		FatalImmunity = false;
		DieImmunity = false;
		PoisonImmunities = new bool[6];
		DisorderOfQi = 0;
		HaveLeftArm = true;
		HaveRightArm = true;
		HaveLeftLeg = true;
		HaveRightLeg = true;
		Injuries = new Injuries(default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte));
		DamageSteps = new DamageStepCollection(200, 200, 160, 180, 180, 180, 180, 200, 200, 160, 180, 180, 180, 180, 200, 160);
		ExtraNeiliAllocation = new NeiliAllocation(0, 0, 0, 0);
		ExtraNeili = 0;
		ConsummateLevel = 0;
		PresetEquipment = new PresetEquipmentItem[17]
		{
			new PresetEquipmentItem("Weapon", -1),
			new PresetEquipmentItem("Weapon", -1),
			new PresetEquipmentItem("Weapon", -1),
			new PresetEquipmentItem("Armor", -1),
			new PresetEquipmentItem("Clothing", -1),
			new PresetEquipmentItem("Armor", -1),
			new PresetEquipmentItem("Armor", -1),
			new PresetEquipmentItem("Armor", -1),
			new PresetEquipmentItem("Accessory", -1),
			new PresetEquipmentItem("Accessory", -1),
			new PresetEquipmentItem("Accessory", -1),
			new PresetEquipmentItem("Carrier", -1),
			new PresetEquipmentItem("Carrier", -1),
			new PresetEquipmentItem("Carrier", -1),
			new PresetEquipmentItem("Accessory", -1),
			new PresetEquipmentItem("Accessory", -1),
			new PresetEquipmentItem("Accessory", -1)
		};
		EquipmentLock = new bool[17];
		PresetInventory = new List<PresetInventoryItem>();
		DropRatePercentAsMainChar = 100;
		DropRatePercentAsTeammate = 25;
		PresetEatingItems = new List<PresetItemTemplateId>();
		AllowDropWugKing = true;
		PresetCombatSkills = new List<PresetCombatSkill>();
		ExtraCombatSkillGrids = new sbyte[5];
		DisableTeammateCommands = new List<sbyte>();
		PresetTeammateCommands = new List<sbyte>();
		PresetNeiliProportionOfFiveElements = new NeiliProportionOfFiveElements(default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte));
		IdeaAllocationProportion = new sbyte[4];
		BaseLifeSkillQualifications = new LifeSkillShorts(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short));
		LifeSkillQualificationGrowthType = 0;
		LearnedLifeSkills = new List<GameData.Domains.Character.LifeSkillItem>();
		LearnedLifeSkillGrades = new sbyte[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		BaseCombatSkillQualifications = new CombatSkillShorts(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short));
		CombatSkillQualificationGrowthType = 0;
		Resources = new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int));
		DropResources = new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int));
		LovingItemSubType = -1;
		HatingItemSubType = -1;
		ShowLegendaryBookConsumedCloth = false;
		AvatarDataPath = null;
		GroupType = ECharacterGroupType.Friend;
		TaiwuAsXiangshuDelete = false;
		ConvertToIntelligent = false;
		InfectedFixedAvatarName = null;
		InfectedFixedAvatarSpineName = null;
		InfectedFixedAvatarSpineSkin = null;
	}

	public CharacterItem(short templateId, CharacterItem other)
	{
		TemplateId = templateId;
		Surname = other.Surname;
		GivenName = other.GivenName;
		AnonymousTitle = other.AnonymousTitle;
		SpecialCombatSkeleton = other.SpecialCombatSkeleton;
		FixedAvatarName = other.FixedAvatarName;
		FixedAvatarSpineName = other.FixedAvatarSpineName;
		FixedAvatarSpineSkin = other.FixedAvatarSpineSkin;
		CreatingType = other.CreatingType;
		GroupId = other.GroupId;
		CombatAi = other.CombatAi;
		CanDefeat = other.CanDefeat;
		CanMove = other.CanMove;
		CanOpenCharacterMenu = other.CanOpenCharacterMenu;
		IsFavorabilityDisplay = other.IsFavorabilityDisplay;
		HideAge = other.HideAge;
		AllowUseFreeWeapon = other.AllowUseFreeWeapon;
		AllowEscape = other.AllowEscape;
		CanSpeak = other.CanSpeak;
		CanBeTaiwu = other.CanBeTaiwu;
		CanBePossessionBody = other.CanBePossessionBody;
		CanBePossessionSoul = other.CanBePossessionSoul;
		SpecialMuteBubbleSelf = other.SpecialMuteBubbleSelf;
		SpecialMuteBubbleEnemy = other.SpecialMuteBubbleEnemy;
		SpecialTemmateType = other.SpecialTemmateType;
		FixedCharacterShowNameOnMap = other.FixedCharacterShowNameOnMap;
		RandomAnimalAttack = other.RandomAnimalAttack;
		XiangshuInfectedDemonBonus = other.XiangshuInfectedDemonBonus;
		AllowHeal = other.AllowHeal;
		CanBeKidnapped = other.CanBeKidnapped;
		RandomFeaturesAtCreating = other.RandomFeaturesAtCreating;
		FeatureIds = other.FeatureIds;
		MinionGroupId = other.MinionGroupId;
		ChallengeModeMinionGroupId = other.ChallengeModeMinionGroupId;
		RandomEnemyId = other.RandomEnemyId;
		LeadingEnemyNestId = other.LeadingEnemyNestId;
		AllowFavorabilitySkipCd = other.AllowFavorabilitySkipCd;
		RandomEnemyFavorability = other.RandomEnemyFavorability;
		Gender = other.Gender;
		PresetBodyType = other.PresetBodyType;
		Race = other.Race;
		Transgender = other.Transgender;
		Bisexual = other.Bisexual;
		PresetFame = other.PresetFame;
		Happiness = other.Happiness;
		BaseAttraction = other.BaseAttraction;
		BaseMorality = other.BaseMorality;
		ActualAge = other.ActualAge;
		InitCurrAge = other.InitCurrAge;
		Health = other.Health;
		BaseMaxHealth = other.BaseMaxHealth;
		BirthMonth = other.BirthMonth;
		OrganizationInfo = other.OrganizationInfo;
		SpecialGradeName = other.SpecialGradeName;
		IdealSect = other.IdealSect;
		RandomIdealSects = other.RandomIdealSects;
		XiangshuType = other.XiangshuType;
		MonkType = other.MonkType;
		LifeSkillTypeInterest = other.LifeSkillTypeInterest;
		CombatSkillTypeInterest = other.CombatSkillTypeInterest;
		MainAttributeInterest = other.MainAttributeInterest;
		ExtraEquipmentLoad = other.ExtraEquipmentLoad;
		FixWeaponPower = other.FixWeaponPower;
		FixArmorPower = other.FixArmorPower;
		FixCombatSkillPower = other.FixCombatSkillPower;
		BaseMainAttributes = other.BaseMainAttributes;
		BaseHitValues = other.BaseHitValues;
		BasePenetrations = other.BasePenetrations;
		BaseAvoidValues = other.BaseAvoidValues;
		BasePenetrationResists = other.BasePenetrationResists;
		BaseRecoveryOfStanceAndBreath = other.BaseRecoveryOfStanceAndBreath;
		BaseMoveSpeed = other.BaseMoveSpeed;
		BaseRecoveryOfFlaw = other.BaseRecoveryOfFlaw;
		BaseCastSpeed = other.BaseCastSpeed;
		BaseRecoveryOfBlockedAcupoint = other.BaseRecoveryOfBlockedAcupoint;
		BaseWeaponSwitchSpeed = other.BaseWeaponSwitchSpeed;
		BaseAttackSpeed = other.BaseAttackSpeed;
		BaseInnerRatio = other.BaseInnerRatio;
		BaseRecoveryOfQiDisorder = other.BaseRecoveryOfQiDisorder;
		BasePoisonResists = other.BasePoisonResists;
		InnerInjuryImmunity = other.InnerInjuryImmunity;
		OuterInjuryImmunity = other.OuterInjuryImmunity;
		MindImmunity = other.MindImmunity;
		FlawImmunity = other.FlawImmunity;
		AcupointImmunity = other.AcupointImmunity;
		FatalImmunity = other.FatalImmunity;
		DieImmunity = other.DieImmunity;
		PoisonImmunities = other.PoisonImmunities;
		DisorderOfQi = other.DisorderOfQi;
		HaveLeftArm = other.HaveLeftArm;
		HaveRightArm = other.HaveRightArm;
		HaveLeftLeg = other.HaveLeftLeg;
		HaveRightLeg = other.HaveRightLeg;
		Injuries = other.Injuries;
		DamageSteps = other.DamageSteps;
		ExtraNeiliAllocation = other.ExtraNeiliAllocation;
		ExtraNeili = other.ExtraNeili;
		ConsummateLevel = other.ConsummateLevel;
		PresetEquipment = other.PresetEquipment;
		EquipmentLock = other.EquipmentLock;
		PresetInventory = other.PresetInventory;
		DropRatePercentAsMainChar = other.DropRatePercentAsMainChar;
		DropRatePercentAsTeammate = other.DropRatePercentAsTeammate;
		PresetEatingItems = other.PresetEatingItems;
		AllowDropWugKing = other.AllowDropWugKing;
		PresetCombatSkills = other.PresetCombatSkills;
		ExtraCombatSkillGrids = other.ExtraCombatSkillGrids;
		DisableTeammateCommands = other.DisableTeammateCommands;
		PresetTeammateCommands = other.PresetTeammateCommands;
		PresetNeiliProportionOfFiveElements = other.PresetNeiliProportionOfFiveElements;
		IdeaAllocationProportion = other.IdeaAllocationProportion;
		BaseLifeSkillQualifications = other.BaseLifeSkillQualifications;
		LifeSkillQualificationGrowthType = other.LifeSkillQualificationGrowthType;
		LearnedLifeSkills = other.LearnedLifeSkills;
		LearnedLifeSkillGrades = other.LearnedLifeSkillGrades;
		BaseCombatSkillQualifications = other.BaseCombatSkillQualifications;
		CombatSkillQualificationGrowthType = other.CombatSkillQualificationGrowthType;
		Resources = other.Resources;
		DropResources = other.DropResources;
		LovingItemSubType = other.LovingItemSubType;
		HatingItemSubType = other.HatingItemSubType;
		ShowLegendaryBookConsumedCloth = other.ShowLegendaryBookConsumedCloth;
		AvatarDataPath = other.AvatarDataPath;
		GroupType = other.GroupType;
		TaiwuAsXiangshuDelete = other.TaiwuAsXiangshuDelete;
		ConvertToIntelligent = other.ConvertToIntelligent;
		InfectedFixedAvatarName = other.InfectedFixedAvatarName;
		InfectedFixedAvatarSpineName = other.InfectedFixedAvatarSpineName;
		InfectedFixedAvatarSpineSkin = other.InfectedFixedAvatarSpineSkin;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CharacterItem Duplicate(int templateId)
	{
		return new CharacterItem((short)templateId, this);
	}
}
