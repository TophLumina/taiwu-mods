using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Domains.Character;
using GameData.Domains.Item;

namespace Config;

[Serializable]
public class CombatSkillItem : ConfigItem<CombatSkillItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly sbyte Grade;

	public readonly string Desc;

	public readonly string Icon;

	public readonly sbyte EquipType;

	public readonly sbyte Type;

	public readonly ECombatSkillSubType SubType;

	public readonly sbyte GridCost;

	public readonly sbyte SectId;

	public readonly sbyte FiveElements;

	public readonly short BookId;

	public readonly bool CanObtainByAdventure;

	public readonly bool IsNonPublic;

	public readonly sbyte OrderIdInSect;

	public readonly List<PropertyAndValue> UsingRequirement;

	public readonly short DirectEffectID;

	public readonly short ReverseEffectID;

	public readonly byte InheritAttainmentAdiitionRate;

	public readonly sbyte PracticeType;

	public readonly sbyte SkillBreakPlateId;

	public readonly string BreakStart;

	public readonly string BreakEnd;

	public readonly bool GoneMadInnerInjury;

	public readonly List<sbyte> GoneMadInjuredPart;

	public readonly sbyte GoneMadInjuryValue;

	public readonly short GoneMadQiDisorder;

	public readonly short TotalObtainableNeili;

	public readonly short ObtainedNeiliPerLoop;

	public readonly sbyte DestTypeWhileLooping;

	public readonly sbyte TransferTypeWhileLooping;

	public readonly sbyte FiveElementChangePerLoop;

	public readonly sbyte[] SpecificGrids;

	public readonly sbyte GenericGrid;

	public readonly HitOrAvoidShorts HitValues;

	public readonly HitOrAvoidShorts AvoidValues;

	public readonly OuterAndInnerShorts Penetrations;

	public readonly OuterAndInnerShorts PenetrationResists;

	public readonly OuterAndInnerShorts RecoveryOfStanceAndBreath;

	public readonly short MoveSpeed;

	public readonly short RecoveryOfFlaw;

	public readonly short CastSpeed;

	public readonly short RecoveryOfBlockedAcupoint;

	public readonly short WeaponSwitchSpeed;

	public readonly short AttackSpeed;

	public readonly short InnerRatio;

	public readonly short RecoveryOfQiDisorder;

	public readonly PoisonShorts PoisonResists;

	public readonly string AssetFileName;

	public readonly string PrepareAnimation;

	public readonly string CastAnimation;

	public readonly string CastParticle;

	public readonly string CastPetAnimation;

	public readonly string CastPetParticle;

	public readonly short[] DistanceWhenFourStepAnimation;

	public readonly string CastSoundEffect;

	public readonly string PlayerCastBossSkillPrepareAni;

	public readonly string PlayerCastBossSkillAni;

	public readonly string PlayerCastBossSkillParticle;

	public readonly string PlayerCastBossSkillSound;

	public readonly short[] PlayerCastBossSkillDistance;

	public readonly int PrepareTotalProgress;

	public readonly List<sbyte> NeedBodyPartTypes;

	public readonly short MobilityCost;

	public readonly sbyte BreathStanceTotalCost;

	public readonly sbyte BaseInnerRatio;

	public readonly sbyte InnerRatioChangeRange;

	public readonly short Penetrate;

	public readonly short DistanceAdditionWhenCast;

	public readonly List<NeedTrick> TrickCost;

	public readonly sbyte WeaponDurableCost;

	public readonly sbyte WugCost;

	public readonly short MostFittingWeaponID;

	public readonly short FixedBestWeaponID;

	public readonly sbyte[] InjuryPartAtkRateDistribution;

	public readonly short TotalHit;

	public readonly sbyte[] PerHitDamageRateDistribution;

	public readonly bool HasAtkAcupointEffect;

	public readonly bool HasAtkFlawEffect;

	public readonly PoisonsAndLevels Poisons;

	public readonly sbyte EquipmentBreakOdds;

	public readonly sbyte AddWugType;

	public readonly short[] AddBreakBodyFeature;

	public readonly short AddMoveSpeedOnCast;

	public readonly short AddPercentMoveSpeedOnCast;

	public readonly short MoveCdBonus;

	public readonly short[] AddHitOnCast;

	public readonly int MobilityReduceSpeed;

	public readonly int MobilityAddSpeed;

	public readonly int MoveCostMobility;

	public readonly sbyte MaxJumpDistance;

	public readonly int JumpPrepareFrame;

	public readonly bool CanPartlyJump;

	public readonly string[] JumpAni;

	public readonly string[] JumpParticle;

	public readonly short JumpChangeDistanceFrame;

	public readonly short JumpChangeDistanceDuration;

	public readonly sbyte ScoreBonusType;

	public readonly short ScoreBonus;

	public readonly short AddOuterPenetrateResistOnCast;

	public readonly short AddInnerPenetrateResistOnCast;

	public readonly short[] AddAvoidOnCast;

	public readonly short FightBackDamage;

	public readonly short BounceRateOfOuterInjury;

	public readonly short BounceRateOfInnerInjury;

	public readonly short ContinuousFrames;

	public readonly short BounceDistance;

	public readonly string DefendAnimation;

	public readonly string DefendParticle;

	public readonly string DefendSound;

	public readonly string FightBackAnimation;

	public readonly string FightBackParticle;

	public readonly string FightBackSound;

	public readonly List<PropertyAndValue> PropertyAddList;

	public readonly int[] OuterDamageSteps;

	public readonly int[] InnerDamageSteps;

	public readonly int FatalDamageStep;

	public readonly int MindDamageStep;

	public readonly List<sbyte> PossibleQiArtStrategyList;

	public readonly sbyte[] ExtraNeiliAllocationProgress;

	public readonly List<short> LoopBonusSkillList;

	public readonly sbyte QiArtStrategyGenerateProbability;

	public readonly List<sbyte> InvalidBreakBonusTypes;

	public readonly string VideoName;

	public OrganizationItem Sect
	{
		[return: MaybeNull]
		get
		{
			return Organization.Instance.GetItemOrDefault(SectId);
		}
	}

	public SkillBookItem Book
	{
		[return: MaybeNull]
		get
		{
			return SkillBook.Instance.GetItemOrDefault(BookId);
		}
	}

	public SkillBreakPlateItem SkillBreakPlate
	{
		[return: MaybeNull]
		get
		{
			return Config.SkillBreakPlate.Instance.GetItemOrDefault(SkillBreakPlateId);
		}
	}

	public CombatSkillItem(short templateId, string name, sbyte grade, string desc, string icon, sbyte equipType, sbyte type, ECombatSkillSubType subType, sbyte gridCost, sbyte sectId, sbyte fiveElements, short bookId, bool canObtainByAdventure, bool isNonPublic, sbyte orderIdInSect, List<PropertyAndValue> usingRequirement, short directEffectID, short reverseEffectID, byte inheritAttainmentAdiitionRate, sbyte practiceType, sbyte skillBreakPlateId, string breakStart, string breakEnd, bool goneMadInnerInjury, List<sbyte> goneMadInjuredPart, sbyte goneMadInjuryValue, short goneMadQiDisorder, short totalObtainableNeili, short obtainedNeiliPerLoop, sbyte destTypeWhileLooping, sbyte transferTypeWhileLooping, sbyte fiveElementChangePerLoop, sbyte[] specificGrids, sbyte genericGrid, HitOrAvoidShorts hitValues, HitOrAvoidShorts avoidValues, OuterAndInnerShorts penetrations, OuterAndInnerShorts penetrationResists, OuterAndInnerShorts recoveryOfStanceAndBreath, short moveSpeed, short recoveryOfFlaw, short castSpeed, short recoveryOfBlockedAcupoint, short weaponSwitchSpeed, short attackSpeed, short innerRatio, short recoveryOfQiDisorder, PoisonShorts poisonResists, string assetFileName, string prepareAnimation, string castAnimation, string castParticle, string castPetAnimation, string castPetParticle, short[] distanceWhenFourStepAnimation, string castSoundEffect, string playerCastBossSkillPrepareAni, string playerCastBossSkillAni, string playerCastBossSkillParticle, string playerCastBossSkillSound, short[] playerCastBossSkillDistance, int prepareTotalProgress, List<sbyte> needBodyPartTypes, short mobilityCost, sbyte breathStanceTotalCost, sbyte baseInnerRatio, sbyte innerRatioChangeRange, short penetrate, short distanceAdditionWhenCast, List<NeedTrick> trickCost, sbyte weaponDurableCost, sbyte wugCost, short mostFittingWeaponID, short fixedBestWeaponID, sbyte[] injuryPartAtkRateDistribution, short totalHit, sbyte[] perHitDamageRateDistribution, bool hasAtkAcupointEffect, bool hasAtkFlawEffect, PoisonsAndLevels poisons, sbyte equipmentBreakOdds, sbyte addWugType, short[] addBreakBodyFeature, short addMoveSpeedOnCast, short addPercentMoveSpeedOnCast, short moveCdBonus, short[] addHitOnCast, int mobilityReduceSpeed, int mobilityAddSpeed, int moveCostMobility, sbyte maxJumpDistance, int jumpPrepareFrame, bool canPartlyJump, string[] jumpAni, string[] jumpParticle, short jumpChangeDistanceFrame, short jumpChangeDistanceDuration, sbyte scoreBonusType, short scoreBonus, short addOuterPenetrateResistOnCast, short addInnerPenetrateResistOnCast, short[] addAvoidOnCast, short fightBackDamage, short bounceRateOfOuterInjury, short bounceRateOfInnerInjury, short continuousFrames, short bounceDistance, string defendAnimation, string defendParticle, string defendSound, string fightBackAnimation, string fightBackParticle, string fightBackSound, List<PropertyAndValue> propertyAddList, int[] outerDamageSteps, int[] innerDamageSteps, int fatalDamageStep, int mindDamageStep, List<sbyte> possibleQiArtStrategyList, sbyte[] extraNeiliAllocationProgress, List<short> loopBonusSkillList, sbyte qiArtStrategyGenerateProbability, List<sbyte> invalidBreakBonusTypes, string videoName)
	{
		TemplateId = templateId;
		Name = name;
		Grade = grade;
		Desc = desc;
		Icon = icon;
		EquipType = equipType;
		Type = type;
		SubType = subType;
		GridCost = gridCost;
		SectId = sectId;
		FiveElements = fiveElements;
		BookId = bookId;
		CanObtainByAdventure = canObtainByAdventure;
		IsNonPublic = isNonPublic;
		OrderIdInSect = orderIdInSect;
		UsingRequirement = usingRequirement;
		DirectEffectID = directEffectID;
		ReverseEffectID = reverseEffectID;
		InheritAttainmentAdiitionRate = inheritAttainmentAdiitionRate;
		PracticeType = practiceType;
		SkillBreakPlateId = skillBreakPlateId;
		BreakStart = breakStart;
		BreakEnd = breakEnd;
		GoneMadInnerInjury = goneMadInnerInjury;
		GoneMadInjuredPart = goneMadInjuredPart;
		GoneMadInjuryValue = goneMadInjuryValue;
		GoneMadQiDisorder = goneMadQiDisorder;
		TotalObtainableNeili = totalObtainableNeili;
		ObtainedNeiliPerLoop = obtainedNeiliPerLoop;
		DestTypeWhileLooping = destTypeWhileLooping;
		TransferTypeWhileLooping = transferTypeWhileLooping;
		FiveElementChangePerLoop = fiveElementChangePerLoop;
		SpecificGrids = specificGrids;
		GenericGrid = genericGrid;
		HitValues = hitValues;
		AvoidValues = avoidValues;
		Penetrations = penetrations;
		PenetrationResists = penetrationResists;
		RecoveryOfStanceAndBreath = recoveryOfStanceAndBreath;
		MoveSpeed = moveSpeed;
		RecoveryOfFlaw = recoveryOfFlaw;
		CastSpeed = castSpeed;
		RecoveryOfBlockedAcupoint = recoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = weaponSwitchSpeed;
		AttackSpeed = attackSpeed;
		InnerRatio = innerRatio;
		RecoveryOfQiDisorder = recoveryOfQiDisorder;
		PoisonResists = poisonResists;
		AssetFileName = assetFileName;
		PrepareAnimation = prepareAnimation;
		CastAnimation = castAnimation;
		CastParticle = castParticle;
		CastPetAnimation = castPetAnimation;
		CastPetParticle = castPetParticle;
		DistanceWhenFourStepAnimation = distanceWhenFourStepAnimation;
		CastSoundEffect = castSoundEffect;
		PlayerCastBossSkillPrepareAni = playerCastBossSkillPrepareAni;
		PlayerCastBossSkillAni = playerCastBossSkillAni;
		PlayerCastBossSkillParticle = playerCastBossSkillParticle;
		PlayerCastBossSkillSound = playerCastBossSkillSound;
		PlayerCastBossSkillDistance = playerCastBossSkillDistance;
		PrepareTotalProgress = prepareTotalProgress;
		NeedBodyPartTypes = needBodyPartTypes;
		MobilityCost = mobilityCost;
		BreathStanceTotalCost = breathStanceTotalCost;
		BaseInnerRatio = baseInnerRatio;
		InnerRatioChangeRange = innerRatioChangeRange;
		Penetrate = penetrate;
		DistanceAdditionWhenCast = distanceAdditionWhenCast;
		TrickCost = trickCost;
		WeaponDurableCost = weaponDurableCost;
		WugCost = wugCost;
		MostFittingWeaponID = mostFittingWeaponID;
		FixedBestWeaponID = fixedBestWeaponID;
		InjuryPartAtkRateDistribution = injuryPartAtkRateDistribution;
		TotalHit = totalHit;
		PerHitDamageRateDistribution = perHitDamageRateDistribution;
		HasAtkAcupointEffect = hasAtkAcupointEffect;
		HasAtkFlawEffect = hasAtkFlawEffect;
		Poisons = poisons;
		EquipmentBreakOdds = equipmentBreakOdds;
		AddWugType = addWugType;
		AddBreakBodyFeature = addBreakBodyFeature;
		AddMoveSpeedOnCast = addMoveSpeedOnCast;
		AddPercentMoveSpeedOnCast = addPercentMoveSpeedOnCast;
		MoveCdBonus = moveCdBonus;
		AddHitOnCast = addHitOnCast;
		MobilityReduceSpeed = mobilityReduceSpeed;
		MobilityAddSpeed = mobilityAddSpeed;
		MoveCostMobility = moveCostMobility;
		MaxJumpDistance = maxJumpDistance;
		JumpPrepareFrame = jumpPrepareFrame;
		CanPartlyJump = canPartlyJump;
		JumpAni = jumpAni;
		JumpParticle = jumpParticle;
		JumpChangeDistanceFrame = jumpChangeDistanceFrame;
		JumpChangeDistanceDuration = jumpChangeDistanceDuration;
		ScoreBonusType = scoreBonusType;
		ScoreBonus = scoreBonus;
		AddOuterPenetrateResistOnCast = addOuterPenetrateResistOnCast;
		AddInnerPenetrateResistOnCast = addInnerPenetrateResistOnCast;
		AddAvoidOnCast = addAvoidOnCast;
		FightBackDamage = fightBackDamage;
		BounceRateOfOuterInjury = bounceRateOfOuterInjury;
		BounceRateOfInnerInjury = bounceRateOfInnerInjury;
		ContinuousFrames = continuousFrames;
		BounceDistance = bounceDistance;
		DefendAnimation = defendAnimation;
		DefendParticle = defendParticle;
		DefendSound = defendSound;
		FightBackAnimation = fightBackAnimation;
		FightBackParticle = fightBackParticle;
		FightBackSound = fightBackSound;
		PropertyAddList = propertyAddList;
		OuterDamageSteps = outerDamageSteps;
		InnerDamageSteps = innerDamageSteps;
		FatalDamageStep = fatalDamageStep;
		MindDamageStep = mindDamageStep;
		PossibleQiArtStrategyList = possibleQiArtStrategyList;
		ExtraNeiliAllocationProgress = extraNeiliAllocationProgress;
		LoopBonusSkillList = loopBonusSkillList;
		QiArtStrategyGenerateProbability = qiArtStrategyGenerateProbability;
		InvalidBreakBonusTypes = invalidBreakBonusTypes;
		VideoName = videoName;
	}

	public CombatSkillItem()
	{
		TemplateId = 0;
		Name = null;
		Grade = 0;
		Desc = null;
		Icon = null;
		EquipType = -1;
		Type = 0;
		SubType = ECombatSkillSubType.Invalid;
		GridCost = 0;
		SectId = 0;
		FiveElements = 5;
		BookId = 0;
		CanObtainByAdventure = true;
		IsNonPublic = false;
		OrderIdInSect = -1;
		UsingRequirement = new List<PropertyAndValue>();
		DirectEffectID = 0;
		ReverseEffectID = 0;
		InheritAttainmentAdiitionRate = 0;
		PracticeType = -1;
		SkillBreakPlateId = 0;
		BreakStart = null;
		BreakEnd = null;
		GoneMadInnerInjury = false;
		GoneMadInjuredPart = new List<sbyte>();
		GoneMadInjuryValue = 0;
		GoneMadQiDisorder = 0;
		TotalObtainableNeili = 0;
		ObtainedNeiliPerLoop = 0;
		DestTypeWhileLooping = -1;
		TransferTypeWhileLooping = -1;
		FiveElementChangePerLoop = 0;
		SpecificGrids = new sbyte[4];
		GenericGrid = 0;
		HitValues = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		AvoidValues = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		Penetrations = new OuterAndInnerShorts(0, 0);
		PenetrationResists = new OuterAndInnerShorts(0, 0);
		RecoveryOfStanceAndBreath = new OuterAndInnerShorts(0, 0);
		MoveSpeed = 0;
		RecoveryOfFlaw = 0;
		CastSpeed = 0;
		RecoveryOfBlockedAcupoint = 0;
		WeaponSwitchSpeed = 0;
		AttackSpeed = 0;
		InnerRatio = 0;
		RecoveryOfQiDisorder = 0;
		PoisonResists = new PoisonShorts(default(int), default(int), default(int), default(int), default(int), default(int));
		AssetFileName = null;
		PrepareAnimation = null;
		CastAnimation = null;
		CastParticle = null;
		CastPetAnimation = null;
		CastPetParticle = null;
		DistanceWhenFourStepAnimation = new short[5];
		CastSoundEffect = null;
		PlayerCastBossSkillPrepareAni = null;
		PlayerCastBossSkillAni = null;
		PlayerCastBossSkillParticle = null;
		PlayerCastBossSkillSound = null;
		PlayerCastBossSkillDistance = null;
		PrepareTotalProgress = 0;
		NeedBodyPartTypes = new List<sbyte>();
		MobilityCost = 0;
		BreathStanceTotalCost = 0;
		BaseInnerRatio = 0;
		InnerRatioChangeRange = 20;
		Penetrate = 0;
		DistanceAdditionWhenCast = 0;
		TrickCost = new List<NeedTrick>();
		WeaponDurableCost = 0;
		WugCost = 0;
		MostFittingWeaponID = 0;
		FixedBestWeaponID = 0;
		InjuryPartAtkRateDistribution = new sbyte[7] { 20, 20, 1, 20, 20, 20, 20 };
		TotalHit = 0;
		PerHitDamageRateDistribution = new sbyte[4];
		HasAtkAcupointEffect = false;
		HasAtkFlawEffect = false;
		Poisons = new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short));
		EquipmentBreakOdds = 0;
		AddWugType = -1;
		AddBreakBodyFeature = null;
		AddMoveSpeedOnCast = 0;
		AddPercentMoveSpeedOnCast = 0;
		MoveCdBonus = 0;
		AddHitOnCast = new short[4];
		MobilityReduceSpeed = 36;
		MobilityAddSpeed = 0;
		MoveCostMobility = 36;
		MaxJumpDistance = -1;
		JumpPrepareFrame = -1;
		CanPartlyJump = false;
		JumpAni = null;
		JumpParticle = null;
		JumpChangeDistanceFrame = -1;
		JumpChangeDistanceDuration = -1;
		ScoreBonusType = -1;
		ScoreBonus = 0;
		AddOuterPenetrateResistOnCast = 0;
		AddInnerPenetrateResistOnCast = 0;
		AddAvoidOnCast = new short[4];
		FightBackDamage = 0;
		BounceRateOfOuterInjury = 0;
		BounceRateOfInnerInjury = 0;
		ContinuousFrames = 0;
		BounceDistance = 0;
		DefendAnimation = null;
		DefendParticle = null;
		DefendSound = null;
		FightBackAnimation = null;
		FightBackParticle = null;
		FightBackSound = null;
		PropertyAddList = new List<PropertyAndValue>();
		OuterDamageSteps = new int[7];
		InnerDamageSteps = new int[7];
		FatalDamageStep = 0;
		MindDamageStep = 0;
		PossibleQiArtStrategyList = new List<sbyte>();
		ExtraNeiliAllocationProgress = new sbyte[5];
		LoopBonusSkillList = new List<short>();
		QiArtStrategyGenerateProbability = 0;
		InvalidBreakBonusTypes = new List<sbyte>();
		VideoName = null;
	}

	public CombatSkillItem(short templateId, CombatSkillItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Grade = other.Grade;
		Desc = other.Desc;
		Icon = other.Icon;
		EquipType = other.EquipType;
		Type = other.Type;
		SubType = other.SubType;
		GridCost = other.GridCost;
		SectId = other.SectId;
		FiveElements = other.FiveElements;
		BookId = other.BookId;
		CanObtainByAdventure = other.CanObtainByAdventure;
		IsNonPublic = other.IsNonPublic;
		OrderIdInSect = other.OrderIdInSect;
		UsingRequirement = other.UsingRequirement;
		DirectEffectID = other.DirectEffectID;
		ReverseEffectID = other.ReverseEffectID;
		InheritAttainmentAdiitionRate = other.InheritAttainmentAdiitionRate;
		PracticeType = other.PracticeType;
		SkillBreakPlateId = other.SkillBreakPlateId;
		BreakStart = other.BreakStart;
		BreakEnd = other.BreakEnd;
		GoneMadInnerInjury = other.GoneMadInnerInjury;
		GoneMadInjuredPart = other.GoneMadInjuredPart;
		GoneMadInjuryValue = other.GoneMadInjuryValue;
		GoneMadQiDisorder = other.GoneMadQiDisorder;
		TotalObtainableNeili = other.TotalObtainableNeili;
		ObtainedNeiliPerLoop = other.ObtainedNeiliPerLoop;
		DestTypeWhileLooping = other.DestTypeWhileLooping;
		TransferTypeWhileLooping = other.TransferTypeWhileLooping;
		FiveElementChangePerLoop = other.FiveElementChangePerLoop;
		SpecificGrids = other.SpecificGrids;
		GenericGrid = other.GenericGrid;
		HitValues = other.HitValues;
		AvoidValues = other.AvoidValues;
		Penetrations = other.Penetrations;
		PenetrationResists = other.PenetrationResists;
		RecoveryOfStanceAndBreath = other.RecoveryOfStanceAndBreath;
		MoveSpeed = other.MoveSpeed;
		RecoveryOfFlaw = other.RecoveryOfFlaw;
		CastSpeed = other.CastSpeed;
		RecoveryOfBlockedAcupoint = other.RecoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = other.WeaponSwitchSpeed;
		AttackSpeed = other.AttackSpeed;
		InnerRatio = other.InnerRatio;
		RecoveryOfQiDisorder = other.RecoveryOfQiDisorder;
		PoisonResists = other.PoisonResists;
		AssetFileName = other.AssetFileName;
		PrepareAnimation = other.PrepareAnimation;
		CastAnimation = other.CastAnimation;
		CastParticle = other.CastParticle;
		CastPetAnimation = other.CastPetAnimation;
		CastPetParticle = other.CastPetParticle;
		DistanceWhenFourStepAnimation = other.DistanceWhenFourStepAnimation;
		CastSoundEffect = other.CastSoundEffect;
		PlayerCastBossSkillPrepareAni = other.PlayerCastBossSkillPrepareAni;
		PlayerCastBossSkillAni = other.PlayerCastBossSkillAni;
		PlayerCastBossSkillParticle = other.PlayerCastBossSkillParticle;
		PlayerCastBossSkillSound = other.PlayerCastBossSkillSound;
		PlayerCastBossSkillDistance = other.PlayerCastBossSkillDistance;
		PrepareTotalProgress = other.PrepareTotalProgress;
		NeedBodyPartTypes = other.NeedBodyPartTypes;
		MobilityCost = other.MobilityCost;
		BreathStanceTotalCost = other.BreathStanceTotalCost;
		BaseInnerRatio = other.BaseInnerRatio;
		InnerRatioChangeRange = other.InnerRatioChangeRange;
		Penetrate = other.Penetrate;
		DistanceAdditionWhenCast = other.DistanceAdditionWhenCast;
		TrickCost = other.TrickCost;
		WeaponDurableCost = other.WeaponDurableCost;
		WugCost = other.WugCost;
		MostFittingWeaponID = other.MostFittingWeaponID;
		FixedBestWeaponID = other.FixedBestWeaponID;
		InjuryPartAtkRateDistribution = other.InjuryPartAtkRateDistribution;
		TotalHit = other.TotalHit;
		PerHitDamageRateDistribution = other.PerHitDamageRateDistribution;
		HasAtkAcupointEffect = other.HasAtkAcupointEffect;
		HasAtkFlawEffect = other.HasAtkFlawEffect;
		Poisons = other.Poisons;
		EquipmentBreakOdds = other.EquipmentBreakOdds;
		AddWugType = other.AddWugType;
		AddBreakBodyFeature = other.AddBreakBodyFeature;
		AddMoveSpeedOnCast = other.AddMoveSpeedOnCast;
		AddPercentMoveSpeedOnCast = other.AddPercentMoveSpeedOnCast;
		MoveCdBonus = other.MoveCdBonus;
		AddHitOnCast = other.AddHitOnCast;
		MobilityReduceSpeed = other.MobilityReduceSpeed;
		MobilityAddSpeed = other.MobilityAddSpeed;
		MoveCostMobility = other.MoveCostMobility;
		MaxJumpDistance = other.MaxJumpDistance;
		JumpPrepareFrame = other.JumpPrepareFrame;
		CanPartlyJump = other.CanPartlyJump;
		JumpAni = other.JumpAni;
		JumpParticle = other.JumpParticle;
		JumpChangeDistanceFrame = other.JumpChangeDistanceFrame;
		JumpChangeDistanceDuration = other.JumpChangeDistanceDuration;
		ScoreBonusType = other.ScoreBonusType;
		ScoreBonus = other.ScoreBonus;
		AddOuterPenetrateResistOnCast = other.AddOuterPenetrateResistOnCast;
		AddInnerPenetrateResistOnCast = other.AddInnerPenetrateResistOnCast;
		AddAvoidOnCast = other.AddAvoidOnCast;
		FightBackDamage = other.FightBackDamage;
		BounceRateOfOuterInjury = other.BounceRateOfOuterInjury;
		BounceRateOfInnerInjury = other.BounceRateOfInnerInjury;
		ContinuousFrames = other.ContinuousFrames;
		BounceDistance = other.BounceDistance;
		DefendAnimation = other.DefendAnimation;
		DefendParticle = other.DefendParticle;
		DefendSound = other.DefendSound;
		FightBackAnimation = other.FightBackAnimation;
		FightBackParticle = other.FightBackParticle;
		FightBackSound = other.FightBackSound;
		PropertyAddList = other.PropertyAddList;
		OuterDamageSteps = other.OuterDamageSteps;
		InnerDamageSteps = other.InnerDamageSteps;
		FatalDamageStep = other.FatalDamageStep;
		MindDamageStep = other.MindDamageStep;
		PossibleQiArtStrategyList = other.PossibleQiArtStrategyList;
		ExtraNeiliAllocationProgress = other.ExtraNeiliAllocationProgress;
		LoopBonusSkillList = other.LoopBonusSkillList;
		QiArtStrategyGenerateProbability = other.QiArtStrategyGenerateProbability;
		InvalidBreakBonusTypes = other.InvalidBreakBonusTypes;
		VideoName = other.VideoName;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CombatSkillItem Duplicate(int templateId)
	{
		return new CombatSkillItem((short)templateId, this);
	}

	public bool MatchBreakPlateBonusEffect(SkillBreakBonusEffectItem effect)
	{
		if (effect != null && effect.GetImplementId(EquipType) >= 0)
		{
			return !InvalidBreakBonusTypes.Contains(effect.TemplateId);
		}
		return false;
	}
}
