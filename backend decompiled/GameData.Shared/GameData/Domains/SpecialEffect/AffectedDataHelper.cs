using System.Collections.Generic;

namespace GameData.Domains.SpecialEffect;

public static class AffectedDataHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort MaxStrength = 1;

		public const ushort MaxDexterity = 2;

		public const ushort MaxConcentration = 3;

		public const ushort MaxVitality = 4;

		public const ushort MaxEnergy = 5;

		public const ushort MaxIntelligence = 6;

		public const ushort RecoveryOfStance = 7;

		public const ushort RecoveryOfBreath = 8;

		public const ushort MoveSpeed = 9;

		public const ushort RecoveryOfFlaw = 10;

		public const ushort CastSpeed = 11;

		public const ushort RecoveryOfBlockedAcupoint = 12;

		public const ushort WeaponSwitchSpeed = 13;

		public const ushort AttackSpeed = 14;

		public const ushort InnerRatio = 15;

		public const ushort RecoveryOfQiDisorder = 16;

		public const ushort MinorAttributeFixMaxValue = 17;

		public const ushort MinorAttributeFixMinValue = 18;

		public const ushort ResistOfHotPoison = 19;

		public const ushort ResistOfGloomyPoison = 20;

		public const ushort ResistOfColdPoison = 21;

		public const ushort ResistOfRedPoison = 22;

		public const ushort ResistOfRottenPoison = 23;

		public const ushort ResistOfIllusoryPoison = 24;

		public const ushort DisplayAge = 25;

		public const ushort NeiliProportionOfFiveElements = 26;

		public const ushort WeaponMaxPower = 27;

		public const ushort WeaponUseRequirement = 28;

		public const ushort WeaponAttackRange = 29;

		public const ushort ArmorMaxPower = 30;

		public const ushort ArmorUseRequirement = 31;

		public const ushort HitStrength = 32;

		public const ushort HitTechnique = 33;

		public const ushort HitSpeed = 34;

		public const ushort HitMind = 35;

		public const ushort HitCanChange = 36;

		public const ushort HitChangeEffectPercent = 37;

		public const ushort AvoidStrength = 38;

		public const ushort AvoidTechnique = 39;

		public const ushort AvoidSpeed = 40;

		public const ushort AvoidMind = 41;

		public const ushort AvoidCanChange = 42;

		public const ushort AvoidChangeEffectPercent = 43;

		public const ushort PenetrateOuter = 44;

		public const ushort PenetrateInner = 45;

		public const ushort PenetrateResistOuter = 46;

		public const ushort PenetrateResistInner = 47;

		public const ushort NeiliAllocationAttack = 48;

		public const ushort NeiliAllocationAgile = 49;

		public const ushort NeiliAllocationDefense = 50;

		public const ushort NeiliAllocationAssist = 51;

		public const ushort Happiness = 52;

		public const ushort MaxHealth = 53;

		public const ushort HealthCost = 54;

		public const ushort MoveSpeedCanChange = 55;

		public const ushort AttackerHitStrength = 56;

		public const ushort AttackerHitTechnique = 57;

		public const ushort AttackerHitSpeed = 58;

		public const ushort AttackerHitMind = 59;

		public const ushort AttackerAvoidStrength = 60;

		public const ushort AttackerAvoidTechnique = 61;

		public const ushort AttackerAvoidSpeed = 62;

		public const ushort AttackerAvoidMind = 63;

		public const ushort AttackerPenetrateOuter = 64;

		public const ushort AttackerPenetrateInner = 65;

		public const ushort AttackerPenetrateResistOuter = 66;

		public const ushort AttackerPenetrateResistInner = 67;

		public const ushort AttackHitType = 68;

		public const ushort MakeDirectDamage = 69;

		public const ushort MakeBounceDamage = 70;

		public const ushort MakeFightBackDamage = 71;

		public const ushort MakePoisonLevel = 72;

		public const ushort MakePoisonValue = 73;

		public const ushort AttackerHitOdds = 74;

		public const ushort AttackerFightBackHitOdds = 75;

		public const ushort AttackerPursueOdds = 76;

		public const ushort CausedInjuryChangeToOld = 77;

		public const ushort CausedPoisonChangeToOld = 78;

		public const ushort MakeDamageType = 79;

		public const ushort CanMakeInjuryToNoInjuryPart = 80;

		public const ushort MakePoisonType = 81;

		public const ushort NormalAttackWeapon = 82;

		public const ushort NormalAttackTrick = 83;

		public const ushort ExtraFlawCount = 84;

		public const ushort AttackCanBounce = 85;

		public const ushort AttackCanFightBack = 86;

		public const ushort MakeFightBackInjuryMark = 87;

		public const ushort LegSkillUseShoes = 88;

		public const ushort AttackerFinalDamageValue = 89;

		public const ushort DefenderHitStrength = 90;

		public const ushort DefenderHitTechnique = 91;

		public const ushort DefenderHitSpeed = 92;

		public const ushort DefenderHitMind = 93;

		public const ushort DefenderAvoidStrength = 94;

		public const ushort DefenderAvoidTechnique = 95;

		public const ushort DefenderAvoidSpeed = 96;

		public const ushort DefenderAvoidMind = 97;

		public const ushort DefenderPenetrateOuter = 98;

		public const ushort DefenderPenetrateInner = 99;

		public const ushort DefenderPenetrateResistOuter = 100;

		public const ushort DefenderPenetrateResistInner = 101;

		public const ushort AcceptDirectDamage = 102;

		public const ushort AcceptBounceDamage = 103;

		public const ushort AcceptFightBackDamage = 104;

		public const ushort AcceptPoisonLevel = 105;

		public const ushort AcceptPoisonValue = 106;

		public const ushort DefenderHitOdds = 107;

		public const ushort DefenderFightBackHitOdds = 108;

		public const ushort DefenderPursueOdds = 109;

		public const ushort AcceptMaxInjuryCount = 110;

		public const ushort BouncePower = 111;

		public const ushort FightBackPower = 112;

		public const ushort DirectDamageInnerRatio = 113;

		public const ushort DefenderFinalDamageValue = 114;

		public const ushort DirectDamageValue = 115;

		public const ushort DirectInjuryMark = 116;

		public const ushort GoneMadInjury = 117;

		public const ushort HealInjurySpeed = 118;

		public const ushort HealInjuryBuff = 119;

		public const ushort HealInjuryDebuff = 120;

		public const ushort HealPoisonSpeed = 121;

		public const ushort HealPoisonBuff = 122;

		public const ushort HealPoisonDebuff = 123;

		public const ushort FleeSpeed = 124;

		public const ushort MaxFlawCount = 125;

		public const ushort CanAddFlaw = 126;

		public const ushort FlawLevel = 127;

		public const ushort FlawLevelCanReduce = 128;

		public const ushort FlawCount = 129;

		public const ushort MaxAcupointCount = 130;

		public const ushort CanAddAcupoint = 131;

		public const ushort AcupointLevel = 132;

		public const ushort AcupointLevelCanReduce = 133;

		public const ushort AcupointCount = 134;

		public const ushort AddNeiliAllocation = 135;

		public const ushort CostNeiliAllocation = 136;

		public const ushort CanChangeNeiliAllocation = 137;

		public const ushort CanGetTrick = 138;

		public const ushort GetTrickType = 139;

		public const ushort AttackBodyPart = 140;

		public const ushort WeaponEquipAttack = 141;

		public const ushort WeaponEquipDefense = 142;

		public const ushort ArmorEquipAttack = 143;

		public const ushort ArmorEquipDefense = 144;

		public const ushort AttackRangeForward = 145;

		public const ushort AttackRangeBackward = 146;

		public const ushort MoveCanBeStopped = 147;

		public const ushort CanForcedMove = 148;

		public const ushort MobilityCanBeRemoved = 149;

		public const ushort MobilityCostByEffect = 150;

		public const ushort MoveDistance = 151;

		public const ushort JumpPrepareFrame = 152;

		public const ushort BounceInjuryMark = 153;

		public const ushort SkillHasCost = 154;

		public const ushort CombatStateEffect = 155;

		public const ushort ChangeNeedUseSkill = 156;

		public const ushort ChangeDistanceIsMove = 157;

		public const ushort ReplaceCharHit = 158;

		public const ushort CanAddPoison = 159;

		public const ushort CanReducePoison = 160;

		public const ushort ReducePoisonValue = 161;

		public const ushort PoisonCanAffect = 162;

		public const ushort PoisonAffectCount = 163;

		public const ushort CostTricks = 164;

		public const ushort JumpMoveDistance = 165;

		public const ushort CombatStateToAdd = 166;

		public const ushort CombatStatePower = 167;

		public const ushort BreakBodyPartInjuryCount = 168;

		public const ushort BodyPartIsBroken = 169;

		public const ushort MaxTrickCount = 170;

		public const ushort MaxBreathPercent = 171;

		public const ushort MaxStancePercent = 172;

		public const ushort ExtraBreathPercent = 173;

		public const ushort ExtraStancePercent = 174;

		public const ushort MoveCostMobility = 175;

		public const ushort DefendSkillKeepTime = 176;

		public const ushort BounceRange = 177;

		public const ushort MindMarkKeepTime = 178;

		public const ushort SkillMobilityCostPerFrame = 179;

		public const ushort CanAddWug = 180;

		public const ushort HasGodWeaponBuff = 181;

		public const ushort HasGodArmorBuff = 182;

		public const ushort TeammateCmdRequireGenerateValue = 183;

		public const ushort TeammateCmdEffect = 184;

		public const ushort FlawRecoverSpeed = 185;

		public const ushort AcupointRecoverSpeed = 186;

		public const ushort MindMarkRecoverSpeed = 187;

		public const ushort InjuryAutoHealSpeed = 188;

		public const ushort CanRecoverBreath = 189;

		public const ushort CanRecoverStance = 190;

		public const ushort FatalDamageValue = 191;

		public const ushort FatalDamageMarkCount = 192;

		public const ushort CanFightBackDuringPrepareSkill = 193;

		public const ushort SkillPrepareSpeed = 194;

		public const ushort BreathRecoverSpeed = 195;

		public const ushort StanceRecoverSpeed = 196;

		public const ushort MobilityRecoverSpeed = 197;

		public const ushort ChangeTrickProgressAddValue = 198;

		public const ushort Power = 199;

		public const ushort MaxPower = 200;

		public const ushort PowerCanReduce = 201;

		public const ushort UseRequirement = 202;

		public const ushort CurrInnerRatio = 203;

		public const ushort CostBreathAndStance = 204;

		public const ushort CostBreath = 205;

		public const ushort CostStance = 206;

		public const ushort CostMobility = 207;

		public const ushort SkillCostTricks = 208;

		public const ushort EffectDirection = 209;

		public const ushort EffectDirectionCanChange = 210;

		public const ushort GridCost = 211;

		public const ushort PrepareTotalProgress = 212;

		public const ushort SpecificGridCount = 213;

		public const ushort GenericGridCount = 214;

		public const ushort CanInterrupt = 215;

		public const ushort InterruptOdds = 216;

		public const ushort CanSilence = 217;

		public const ushort SilenceOdds = 218;

		public const ushort CanCastWithBrokenBodyPart = 219;

		public const ushort AddPowerCanBeRemoved = 220;

		public const ushort SkillType = 221;

		public const ushort EffectCountCanChange = 222;

		public const ushort CanCastInDefend = 223;

		public const ushort HitDistribution = 224;

		public const ushort CanCastOnLackBreath = 225;

		public const ushort CanCastOnLackStance = 226;

		public const ushort CostBreathOnCast = 227;

		public const ushort CostStanceOnCast = 228;

		public const ushort CanUseMobilityAsBreath = 229;

		public const ushort CanUseMobilityAsStance = 230;

		public const ushort CastCostNeiliAllocation = 231;

		public const ushort AcceptPoisonResist = 232;

		public const ushort MakePoisonResist = 233;

		public const ushort CanCriticalHit = 234;

		public const ushort CanCostNeiliAllocationEffect = 235;

		public const ushort ConsummateLevelRelatedMainAttributesHitValues = 236;

		public const ushort ConsummateLevelRelatedMainAttributesAvoidValues = 237;

		public const ushort ConsummateLevelRelatedMainAttributesPenetrations = 238;

		public const ushort ConsummateLevelRelatedMainAttributesPenetrationResists = 239;

		public const ushort SkillAlsoAsFiveElements = 240;

		public const ushort InnerInjuryImmunity = 241;

		public const ushort OuterInjuryImmunity = 242;

		public const ushort PoisonAffectThreshold = 243;

		public const ushort LockDistance = 244;

		public const ushort ResistOfAllPoison = 245;

		public const ushort MakePoisonTarget = 246;

		public const ushort AcceptPoisonTarget = 247;

		public const ushort CertainCriticalHit = 248;

		public const ushort MindMarkCount = 249;

		public const ushort CanFightBackWithHit = 250;

		public const ushort InevitableHit = 251;

		public const ushort AttackCanPursue = 252;

		public const ushort CombatSkillDataEffectList = 253;

		public const ushort StanceCostByEffect = 254;

		public const ushort BreathCostByEffect = 255;

		public const ushort PowerAddRatio = 256;

		public const ushort PowerReduceRatio = 257;

		public const ushort PoisonAffectProduceValue = 258;

		public const ushort CanReadingOnMonthChange = 259;

		public const ushort MedicineEffect = 260;

		public const ushort XiangshuInfectionDelta = 261;

		public const ushort HealthDelta = 262;

		public const ushort WeaponSilenceFrame = 263;

		public const ushort SilenceFrame = 264;

		public const ushort CurrAgeDelta = 265;

		public const ushort GoneMadInAllBreak = 266;

		public const ushort MakeLoveRateOnMonthChange = 267;

		public const ushort CanAutoHealOnMonthChange = 268;

		public const ushort HappinessDelta = 269;

		public const ushort TeammateCmdCanUse = 270;

		public const ushort MixPoisonInfinityAffect = 271;

		public const ushort AttackRangeMaxAcupoint = 272;

		public const ushort MaxMobilityPercent = 273;

		public const ushort MakeMindDamage = 274;

		public const ushort AcceptMindDamage = 275;

		public const ushort HitAddByTempValue = 276;

		public const ushort AvoidAddByTempValue = 277;

		public const ushort IgnoreEquipmentOverload = 278;

		public const ushort CanCostEnemyUsableTricks = 279;

		public const ushort IgnoreArmor = 280;

		public const ushort UnyieldingFallen = 281;

		public const ushort NormalAttackPrepareFrame = 282;

		public const ushort CanCostUselessTricks = 283;

		public const ushort DefendSkillCanAffect = 284;

		public const ushort AssistSkillCanAffect = 285;

		public const ushort AgileSkillCanAffect = 286;

		public const ushort AllMarkChangeToMind = 287;

		public const ushort MindMarkChangeToFatal = 288;

		public const ushort CanCast = 289;

		public const ushort InevitableAvoid = 290;

		public const ushort PowerEffectReverse = 291;

		public const ushort FeatureBonusReverse = 292;

		public const ushort WugFatalDamageValue = 293;

		public const ushort CanRecoverHealthOnMonthChange = 294;

		public const ushort TakeRevengeRateOnMonthChange = 295;

		public const ushort ConsummateLevelBonus = 296;

		public const ushort NeiliDelta = 297;

		public const ushort CanMakeLoveSpecialOnMonthChange = 298;

		public const ushort HealAcupointSpeed = 299;

		public const ushort MaxChangeTrickCount = 300;

		public const ushort ConvertCostBreathAndStance = 301;

		public const ushort PersonalitiesAll = 302;

		public const ushort FinalFatalDamageMarkCount = 303;

		public const ushort CombatSkillAiScorePower = 304;

		public const ushort NormalAttackChangeToUnlockAttack = 305;

		public const ushort AttackBodyPartOdds = 306;

		public const ushort ChangeDurability = 307;

		public const ushort EquipmentBonus = 308;

		public const ushort EquipmentWeight = 309;

		public const ushort RawCreateEffectList = 310;

		public const ushort JiTrickAsWeaponTrickCount = 311;

		public const ushort UselessTrickAsJiTrickCount = 312;

		public const ushort EquipmentPower = 313;

		public const ushort HealFlawSpeed = 314;

		public const ushort UnlockSpeed = 315;

		public const ushort FlawBonusFactor = 316;

		public const ushort CanCostShaTricks = 317;

		public const ushort DefenderDirectFinalDamageValue = 318;

		public const ushort NormalAttackRecoveryFrame = 319;

		public const ushort FinalGoneMadInjury = 320;

		public const ushort AttackerDirectFinalDamageValue = 321;

		public const ushort CanCostTrickDuringPreparingSkill = 322;

		public const ushort ValidItemList = 323;

		public const ushort AcceptDamageCanAdd = 324;

		public const ushort MakeDamageCanReduce = 325;

		public const ushort NormalAttackGetTrickCount = 326;

		public const ushort StayEffectCountOnAddPhase = 327;

		public const ushort HealInjuryWithFatalRequireAttainment = 328;

		public const ushort UseItemCostNoWisdom = 329;

		public const ushort MindUpheavalTime = 330;

		public const ushort MakeHarmfulActionSuccessRate = 331;

		public const ushort AcceptHarmfulActionSuccessRate = 332;

		public const ushort MakeFatalDamage = 333;

		public const ushort AcceptFatalDamage = 334;

		public const ushort CausedInjuryChangeToOldOdds = 335;

		public const ushort CausedMindChangeToInfiniteOdds = 336;

		public const ushort HitReduceDurability = 337;

		public const ushort EquipmentMasteryAffectOdds = 338;

		public const ushort CriticalDamage = 339;

		public const ushort CanFightBackOutOfAttackRange = 340;

		public const ushort AttackerCriticalOdds = 341;

		public const ushort DefenderCriticalOdds = 342;

		public const ushort MixPoisonCanAffectCount = 343;

		public const ushort CastCostNeiliAllocationIsAbsorb = 344;

		public const ushort AcceptInjuryChangeToOldOdds = 345;
	}

	public const ushort ArchiveFieldsCount = 346;

	public const ushort CacheFieldsCount = 0;

	public const ushort PureTemplateFieldsCount = 0;

	public const ushort WritableFieldsCount = 346;

	public const ushort ReadonlyFieldsCount = 0;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "MaxStrength", 1 },
		{ "MaxDexterity", 2 },
		{ "MaxConcentration", 3 },
		{ "MaxVitality", 4 },
		{ "MaxEnergy", 5 },
		{ "MaxIntelligence", 6 },
		{ "RecoveryOfStance", 7 },
		{ "RecoveryOfBreath", 8 },
		{ "MoveSpeed", 9 },
		{ "RecoveryOfFlaw", 10 },
		{ "CastSpeed", 11 },
		{ "RecoveryOfBlockedAcupoint", 12 },
		{ "WeaponSwitchSpeed", 13 },
		{ "AttackSpeed", 14 },
		{ "InnerRatio", 15 },
		{ "RecoveryOfQiDisorder", 16 },
		{ "MinorAttributeFixMaxValue", 17 },
		{ "MinorAttributeFixMinValue", 18 },
		{ "ResistOfHotPoison", 19 },
		{ "ResistOfGloomyPoison", 20 },
		{ "ResistOfColdPoison", 21 },
		{ "ResistOfRedPoison", 22 },
		{ "ResistOfRottenPoison", 23 },
		{ "ResistOfIllusoryPoison", 24 },
		{ "DisplayAge", 25 },
		{ "NeiliProportionOfFiveElements", 26 },
		{ "WeaponMaxPower", 27 },
		{ "WeaponUseRequirement", 28 },
		{ "WeaponAttackRange", 29 },
		{ "ArmorMaxPower", 30 },
		{ "ArmorUseRequirement", 31 },
		{ "HitStrength", 32 },
		{ "HitTechnique", 33 },
		{ "HitSpeed", 34 },
		{ "HitMind", 35 },
		{ "HitCanChange", 36 },
		{ "HitChangeEffectPercent", 37 },
		{ "AvoidStrength", 38 },
		{ "AvoidTechnique", 39 },
		{ "AvoidSpeed", 40 },
		{ "AvoidMind", 41 },
		{ "AvoidCanChange", 42 },
		{ "AvoidChangeEffectPercent", 43 },
		{ "PenetrateOuter", 44 },
		{ "PenetrateInner", 45 },
		{ "PenetrateResistOuter", 46 },
		{ "PenetrateResistInner", 47 },
		{ "NeiliAllocationAttack", 48 },
		{ "NeiliAllocationAgile", 49 },
		{ "NeiliAllocationDefense", 50 },
		{ "NeiliAllocationAssist", 51 },
		{ "Happiness", 52 },
		{ "MaxHealth", 53 },
		{ "HealthCost", 54 },
		{ "MoveSpeedCanChange", 55 },
		{ "AttackerHitStrength", 56 },
		{ "AttackerHitTechnique", 57 },
		{ "AttackerHitSpeed", 58 },
		{ "AttackerHitMind", 59 },
		{ "AttackerAvoidStrength", 60 },
		{ "AttackerAvoidTechnique", 61 },
		{ "AttackerAvoidSpeed", 62 },
		{ "AttackerAvoidMind", 63 },
		{ "AttackerPenetrateOuter", 64 },
		{ "AttackerPenetrateInner", 65 },
		{ "AttackerPenetrateResistOuter", 66 },
		{ "AttackerPenetrateResistInner", 67 },
		{ "AttackHitType", 68 },
		{ "MakeDirectDamage", 69 },
		{ "MakeBounceDamage", 70 },
		{ "MakeFightBackDamage", 71 },
		{ "MakePoisonLevel", 72 },
		{ "MakePoisonValue", 73 },
		{ "AttackerHitOdds", 74 },
		{ "AttackerFightBackHitOdds", 75 },
		{ "AttackerPursueOdds", 76 },
		{ "CausedInjuryChangeToOld", 77 },
		{ "CausedPoisonChangeToOld", 78 },
		{ "MakeDamageType", 79 },
		{ "CanMakeInjuryToNoInjuryPart", 80 },
		{ "MakePoisonType", 81 },
		{ "NormalAttackWeapon", 82 },
		{ "NormalAttackTrick", 83 },
		{ "ExtraFlawCount", 84 },
		{ "AttackCanBounce", 85 },
		{ "AttackCanFightBack", 86 },
		{ "MakeFightBackInjuryMark", 87 },
		{ "LegSkillUseShoes", 88 },
		{ "AttackerFinalDamageValue", 89 },
		{ "DefenderHitStrength", 90 },
		{ "DefenderHitTechnique", 91 },
		{ "DefenderHitSpeed", 92 },
		{ "DefenderHitMind", 93 },
		{ "DefenderAvoidStrength", 94 },
		{ "DefenderAvoidTechnique", 95 },
		{ "DefenderAvoidSpeed", 96 },
		{ "DefenderAvoidMind", 97 },
		{ "DefenderPenetrateOuter", 98 },
		{ "DefenderPenetrateInner", 99 },
		{ "DefenderPenetrateResistOuter", 100 },
		{ "DefenderPenetrateResistInner", 101 },
		{ "AcceptDirectDamage", 102 },
		{ "AcceptBounceDamage", 103 },
		{ "AcceptFightBackDamage", 104 },
		{ "AcceptPoisonLevel", 105 },
		{ "AcceptPoisonValue", 106 },
		{ "DefenderHitOdds", 107 },
		{ "DefenderFightBackHitOdds", 108 },
		{ "DefenderPursueOdds", 109 },
		{ "AcceptMaxInjuryCount", 110 },
		{ "BouncePower", 111 },
		{ "FightBackPower", 112 },
		{ "DirectDamageInnerRatio", 113 },
		{ "DefenderFinalDamageValue", 114 },
		{ "DirectDamageValue", 115 },
		{ "DirectInjuryMark", 116 },
		{ "GoneMadInjury", 117 },
		{ "HealInjurySpeed", 118 },
		{ "HealInjuryBuff", 119 },
		{ "HealInjuryDebuff", 120 },
		{ "HealPoisonSpeed", 121 },
		{ "HealPoisonBuff", 122 },
		{ "HealPoisonDebuff", 123 },
		{ "FleeSpeed", 124 },
		{ "MaxFlawCount", 125 },
		{ "CanAddFlaw", 126 },
		{ "FlawLevel", 127 },
		{ "FlawLevelCanReduce", 128 },
		{ "FlawCount", 129 },
		{ "MaxAcupointCount", 130 },
		{ "CanAddAcupoint", 131 },
		{ "AcupointLevel", 132 },
		{ "AcupointLevelCanReduce", 133 },
		{ "AcupointCount", 134 },
		{ "AddNeiliAllocation", 135 },
		{ "CostNeiliAllocation", 136 },
		{ "CanChangeNeiliAllocation", 137 },
		{ "CanGetTrick", 138 },
		{ "GetTrickType", 139 },
		{ "AttackBodyPart", 140 },
		{ "WeaponEquipAttack", 141 },
		{ "WeaponEquipDefense", 142 },
		{ "ArmorEquipAttack", 143 },
		{ "ArmorEquipDefense", 144 },
		{ "AttackRangeForward", 145 },
		{ "AttackRangeBackward", 146 },
		{ "MoveCanBeStopped", 147 },
		{ "CanForcedMove", 148 },
		{ "MobilityCanBeRemoved", 149 },
		{ "MobilityCostByEffect", 150 },
		{ "MoveDistance", 151 },
		{ "JumpPrepareFrame", 152 },
		{ "BounceInjuryMark", 153 },
		{ "SkillHasCost", 154 },
		{ "CombatStateEffect", 155 },
		{ "ChangeNeedUseSkill", 156 },
		{ "ChangeDistanceIsMove", 157 },
		{ "ReplaceCharHit", 158 },
		{ "CanAddPoison", 159 },
		{ "CanReducePoison", 160 },
		{ "ReducePoisonValue", 161 },
		{ "PoisonCanAffect", 162 },
		{ "PoisonAffectCount", 163 },
		{ "CostTricks", 164 },
		{ "JumpMoveDistance", 165 },
		{ "CombatStateToAdd", 166 },
		{ "CombatStatePower", 167 },
		{ "BreakBodyPartInjuryCount", 168 },
		{ "BodyPartIsBroken", 169 },
		{ "MaxTrickCount", 170 },
		{ "MaxBreathPercent", 171 },
		{ "MaxStancePercent", 172 },
		{ "ExtraBreathPercent", 173 },
		{ "ExtraStancePercent", 174 },
		{ "MoveCostMobility", 175 },
		{ "DefendSkillKeepTime", 176 },
		{ "BounceRange", 177 },
		{ "MindMarkKeepTime", 178 },
		{ "SkillMobilityCostPerFrame", 179 },
		{ "CanAddWug", 180 },
		{ "HasGodWeaponBuff", 181 },
		{ "HasGodArmorBuff", 182 },
		{ "TeammateCmdRequireGenerateValue", 183 },
		{ "TeammateCmdEffect", 184 },
		{ "FlawRecoverSpeed", 185 },
		{ "AcupointRecoverSpeed", 186 },
		{ "MindMarkRecoverSpeed", 187 },
		{ "InjuryAutoHealSpeed", 188 },
		{ "CanRecoverBreath", 189 },
		{ "CanRecoverStance", 190 },
		{ "FatalDamageValue", 191 },
		{ "FatalDamageMarkCount", 192 },
		{ "CanFightBackDuringPrepareSkill", 193 },
		{ "SkillPrepareSpeed", 194 },
		{ "BreathRecoverSpeed", 195 },
		{ "StanceRecoverSpeed", 196 },
		{ "MobilityRecoverSpeed", 197 },
		{ "ChangeTrickProgressAddValue", 198 },
		{ "Power", 199 },
		{ "MaxPower", 200 },
		{ "PowerCanReduce", 201 },
		{ "UseRequirement", 202 },
		{ "CurrInnerRatio", 203 },
		{ "CostBreathAndStance", 204 },
		{ "CostBreath", 205 },
		{ "CostStance", 206 },
		{ "CostMobility", 207 },
		{ "SkillCostTricks", 208 },
		{ "EffectDirection", 209 },
		{ "EffectDirectionCanChange", 210 },
		{ "GridCost", 211 },
		{ "PrepareTotalProgress", 212 },
		{ "SpecificGridCount", 213 },
		{ "GenericGridCount", 214 },
		{ "CanInterrupt", 215 },
		{ "InterruptOdds", 216 },
		{ "CanSilence", 217 },
		{ "SilenceOdds", 218 },
		{ "CanCastWithBrokenBodyPart", 219 },
		{ "AddPowerCanBeRemoved", 220 },
		{ "SkillType", 221 },
		{ "EffectCountCanChange", 222 },
		{ "CanCastInDefend", 223 },
		{ "HitDistribution", 224 },
		{ "CanCastOnLackBreath", 225 },
		{ "CanCastOnLackStance", 226 },
		{ "CostBreathOnCast", 227 },
		{ "CostStanceOnCast", 228 },
		{ "CanUseMobilityAsBreath", 229 },
		{ "CanUseMobilityAsStance", 230 },
		{ "CastCostNeiliAllocation", 231 },
		{ "AcceptPoisonResist", 232 },
		{ "MakePoisonResist", 233 },
		{ "CanCriticalHit", 234 },
		{ "CanCostNeiliAllocationEffect", 235 },
		{ "ConsummateLevelRelatedMainAttributesHitValues", 236 },
		{ "ConsummateLevelRelatedMainAttributesAvoidValues", 237 },
		{ "ConsummateLevelRelatedMainAttributesPenetrations", 238 },
		{ "ConsummateLevelRelatedMainAttributesPenetrationResists", 239 },
		{ "SkillAlsoAsFiveElements", 240 },
		{ "InnerInjuryImmunity", 241 },
		{ "OuterInjuryImmunity", 242 },
		{ "PoisonAffectThreshold", 243 },
		{ "LockDistance", 244 },
		{ "ResistOfAllPoison", 245 },
		{ "MakePoisonTarget", 246 },
		{ "AcceptPoisonTarget", 247 },
		{ "CertainCriticalHit", 248 },
		{ "MindMarkCount", 249 },
		{ "CanFightBackWithHit", 250 },
		{ "InevitableHit", 251 },
		{ "AttackCanPursue", 252 },
		{ "CombatSkillDataEffectList", 253 },
		{ "StanceCostByEffect", 254 },
		{ "BreathCostByEffect", 255 },
		{ "PowerAddRatio", 256 },
		{ "PowerReduceRatio", 257 },
		{ "PoisonAffectProduceValue", 258 },
		{ "CanReadingOnMonthChange", 259 },
		{ "MedicineEffect", 260 },
		{ "XiangshuInfectionDelta", 261 },
		{ "HealthDelta", 262 },
		{ "WeaponSilenceFrame", 263 },
		{ "SilenceFrame", 264 },
		{ "CurrAgeDelta", 265 },
		{ "GoneMadInAllBreak", 266 },
		{ "MakeLoveRateOnMonthChange", 267 },
		{ "CanAutoHealOnMonthChange", 268 },
		{ "HappinessDelta", 269 },
		{ "TeammateCmdCanUse", 270 },
		{ "MixPoisonInfinityAffect", 271 },
		{ "AttackRangeMaxAcupoint", 272 },
		{ "MaxMobilityPercent", 273 },
		{ "MakeMindDamage", 274 },
		{ "AcceptMindDamage", 275 },
		{ "HitAddByTempValue", 276 },
		{ "AvoidAddByTempValue", 277 },
		{ "IgnoreEquipmentOverload", 278 },
		{ "CanCostEnemyUsableTricks", 279 },
		{ "IgnoreArmor", 280 },
		{ "UnyieldingFallen", 281 },
		{ "NormalAttackPrepareFrame", 282 },
		{ "CanCostUselessTricks", 283 },
		{ "DefendSkillCanAffect", 284 },
		{ "AssistSkillCanAffect", 285 },
		{ "AgileSkillCanAffect", 286 },
		{ "AllMarkChangeToMind", 287 },
		{ "MindMarkChangeToFatal", 288 },
		{ "CanCast", 289 },
		{ "InevitableAvoid", 290 },
		{ "PowerEffectReverse", 291 },
		{ "FeatureBonusReverse", 292 },
		{ "WugFatalDamageValue", 293 },
		{ "CanRecoverHealthOnMonthChange", 294 },
		{ "TakeRevengeRateOnMonthChange", 295 },
		{ "ConsummateLevelBonus", 296 },
		{ "NeiliDelta", 297 },
		{ "CanMakeLoveSpecialOnMonthChange", 298 },
		{ "HealAcupointSpeed", 299 },
		{ "MaxChangeTrickCount", 300 },
		{ "ConvertCostBreathAndStance", 301 },
		{ "PersonalitiesAll", 302 },
		{ "FinalFatalDamageMarkCount", 303 },
		{ "CombatSkillAiScorePower", 304 },
		{ "NormalAttackChangeToUnlockAttack", 305 },
		{ "AttackBodyPartOdds", 306 },
		{ "ChangeDurability", 307 },
		{ "EquipmentBonus", 308 },
		{ "EquipmentWeight", 309 },
		{ "RawCreateEffectList", 310 },
		{ "JiTrickAsWeaponTrickCount", 311 },
		{ "UselessTrickAsJiTrickCount", 312 },
		{ "EquipmentPower", 313 },
		{ "HealFlawSpeed", 314 },
		{ "UnlockSpeed", 315 },
		{ "FlawBonusFactor", 316 },
		{ "CanCostShaTricks", 317 },
		{ "DefenderDirectFinalDamageValue", 318 },
		{ "NormalAttackRecoveryFrame", 319 },
		{ "FinalGoneMadInjury", 320 },
		{ "AttackerDirectFinalDamageValue", 321 },
		{ "CanCostTrickDuringPreparingSkill", 322 },
		{ "ValidItemList", 323 },
		{ "AcceptDamageCanAdd", 324 },
		{ "MakeDamageCanReduce", 325 },
		{ "NormalAttackGetTrickCount", 326 },
		{ "StayEffectCountOnAddPhase", 327 },
		{ "HealInjuryWithFatalRequireAttainment", 328 },
		{ "UseItemCostNoWisdom", 329 },
		{ "MindUpheavalTime", 330 },
		{ "MakeHarmfulActionSuccessRate", 331 },
		{ "AcceptHarmfulActionSuccessRate", 332 },
		{ "MakeFatalDamage", 333 },
		{ "AcceptFatalDamage", 334 },
		{ "CausedInjuryChangeToOldOdds", 335 },
		{ "CausedMindChangeToInfiniteOdds", 336 },
		{ "HitReduceDurability", 337 },
		{ "EquipmentMasteryAffectOdds", 338 },
		{ "CriticalDamage", 339 },
		{ "CanFightBackOutOfAttackRange", 340 },
		{ "AttackerCriticalOdds", 341 },
		{ "DefenderCriticalOdds", 342 },
		{ "MixPoisonCanAffectCount", 343 },
		{ "CastCostNeiliAllocationIsAbsorb", 344 },
		{ "AcceptInjuryChangeToOldOdds", 345 }
	};

	public static readonly string[] FieldId2FieldName = new string[346]
	{
		"Id", "MaxStrength", "MaxDexterity", "MaxConcentration", "MaxVitality", "MaxEnergy", "MaxIntelligence", "RecoveryOfStance", "RecoveryOfBreath", "MoveSpeed",
		"RecoveryOfFlaw", "CastSpeed", "RecoveryOfBlockedAcupoint", "WeaponSwitchSpeed", "AttackSpeed", "InnerRatio", "RecoveryOfQiDisorder", "MinorAttributeFixMaxValue", "MinorAttributeFixMinValue", "ResistOfHotPoison",
		"ResistOfGloomyPoison", "ResistOfColdPoison", "ResistOfRedPoison", "ResistOfRottenPoison", "ResistOfIllusoryPoison", "DisplayAge", "NeiliProportionOfFiveElements", "WeaponMaxPower", "WeaponUseRequirement", "WeaponAttackRange",
		"ArmorMaxPower", "ArmorUseRequirement", "HitStrength", "HitTechnique", "HitSpeed", "HitMind", "HitCanChange", "HitChangeEffectPercent", "AvoidStrength", "AvoidTechnique",
		"AvoidSpeed", "AvoidMind", "AvoidCanChange", "AvoidChangeEffectPercent", "PenetrateOuter", "PenetrateInner", "PenetrateResistOuter", "PenetrateResistInner", "NeiliAllocationAttack", "NeiliAllocationAgile",
		"NeiliAllocationDefense", "NeiliAllocationAssist", "Happiness", "MaxHealth", "HealthCost", "MoveSpeedCanChange", "AttackerHitStrength", "AttackerHitTechnique", "AttackerHitSpeed", "AttackerHitMind",
		"AttackerAvoidStrength", "AttackerAvoidTechnique", "AttackerAvoidSpeed", "AttackerAvoidMind", "AttackerPenetrateOuter", "AttackerPenetrateInner", "AttackerPenetrateResistOuter", "AttackerPenetrateResistInner", "AttackHitType", "MakeDirectDamage",
		"MakeBounceDamage", "MakeFightBackDamage", "MakePoisonLevel", "MakePoisonValue", "AttackerHitOdds", "AttackerFightBackHitOdds", "AttackerPursueOdds", "CausedInjuryChangeToOld", "CausedPoisonChangeToOld", "MakeDamageType",
		"CanMakeInjuryToNoInjuryPart", "MakePoisonType", "NormalAttackWeapon", "NormalAttackTrick", "ExtraFlawCount", "AttackCanBounce", "AttackCanFightBack", "MakeFightBackInjuryMark", "LegSkillUseShoes", "AttackerFinalDamageValue",
		"DefenderHitStrength", "DefenderHitTechnique", "DefenderHitSpeed", "DefenderHitMind", "DefenderAvoidStrength", "DefenderAvoidTechnique", "DefenderAvoidSpeed", "DefenderAvoidMind", "DefenderPenetrateOuter", "DefenderPenetrateInner",
		"DefenderPenetrateResistOuter", "DefenderPenetrateResistInner", "AcceptDirectDamage", "AcceptBounceDamage", "AcceptFightBackDamage", "AcceptPoisonLevel", "AcceptPoisonValue", "DefenderHitOdds", "DefenderFightBackHitOdds", "DefenderPursueOdds",
		"AcceptMaxInjuryCount", "BouncePower", "FightBackPower", "DirectDamageInnerRatio", "DefenderFinalDamageValue", "DirectDamageValue", "DirectInjuryMark", "GoneMadInjury", "HealInjurySpeed", "HealInjuryBuff",
		"HealInjuryDebuff", "HealPoisonSpeed", "HealPoisonBuff", "HealPoisonDebuff", "FleeSpeed", "MaxFlawCount", "CanAddFlaw", "FlawLevel", "FlawLevelCanReduce", "FlawCount",
		"MaxAcupointCount", "CanAddAcupoint", "AcupointLevel", "AcupointLevelCanReduce", "AcupointCount", "AddNeiliAllocation", "CostNeiliAllocation", "CanChangeNeiliAllocation", "CanGetTrick", "GetTrickType",
		"AttackBodyPart", "WeaponEquipAttack", "WeaponEquipDefense", "ArmorEquipAttack", "ArmorEquipDefense", "AttackRangeForward", "AttackRangeBackward", "MoveCanBeStopped", "CanForcedMove", "MobilityCanBeRemoved",
		"MobilityCostByEffect", "MoveDistance", "JumpPrepareFrame", "BounceInjuryMark", "SkillHasCost", "CombatStateEffect", "ChangeNeedUseSkill", "ChangeDistanceIsMove", "ReplaceCharHit", "CanAddPoison",
		"CanReducePoison", "ReducePoisonValue", "PoisonCanAffect", "PoisonAffectCount", "CostTricks", "JumpMoveDistance", "CombatStateToAdd", "CombatStatePower", "BreakBodyPartInjuryCount", "BodyPartIsBroken",
		"MaxTrickCount", "MaxBreathPercent", "MaxStancePercent", "ExtraBreathPercent", "ExtraStancePercent", "MoveCostMobility", "DefendSkillKeepTime", "BounceRange", "MindMarkKeepTime", "SkillMobilityCostPerFrame",
		"CanAddWug", "HasGodWeaponBuff", "HasGodArmorBuff", "TeammateCmdRequireGenerateValue", "TeammateCmdEffect", "FlawRecoverSpeed", "AcupointRecoverSpeed", "MindMarkRecoverSpeed", "InjuryAutoHealSpeed", "CanRecoverBreath",
		"CanRecoverStance", "FatalDamageValue", "FatalDamageMarkCount", "CanFightBackDuringPrepareSkill", "SkillPrepareSpeed", "BreathRecoverSpeed", "StanceRecoverSpeed", "MobilityRecoverSpeed", "ChangeTrickProgressAddValue", "Power",
		"MaxPower", "PowerCanReduce", "UseRequirement", "CurrInnerRatio", "CostBreathAndStance", "CostBreath", "CostStance", "CostMobility", "SkillCostTricks", "EffectDirection",
		"EffectDirectionCanChange", "GridCost", "PrepareTotalProgress", "SpecificGridCount", "GenericGridCount", "CanInterrupt", "InterruptOdds", "CanSilence", "SilenceOdds", "CanCastWithBrokenBodyPart",
		"AddPowerCanBeRemoved", "SkillType", "EffectCountCanChange", "CanCastInDefend", "HitDistribution", "CanCastOnLackBreath", "CanCastOnLackStance", "CostBreathOnCast", "CostStanceOnCast", "CanUseMobilityAsBreath",
		"CanUseMobilityAsStance", "CastCostNeiliAllocation", "AcceptPoisonResist", "MakePoisonResist", "CanCriticalHit", "CanCostNeiliAllocationEffect", "ConsummateLevelRelatedMainAttributesHitValues", "ConsummateLevelRelatedMainAttributesAvoidValues", "ConsummateLevelRelatedMainAttributesPenetrations", "ConsummateLevelRelatedMainAttributesPenetrationResists",
		"SkillAlsoAsFiveElements", "InnerInjuryImmunity", "OuterInjuryImmunity", "PoisonAffectThreshold", "LockDistance", "ResistOfAllPoison", "MakePoisonTarget", "AcceptPoisonTarget", "CertainCriticalHit", "MindMarkCount",
		"CanFightBackWithHit", "InevitableHit", "AttackCanPursue", "CombatSkillDataEffectList", "StanceCostByEffect", "BreathCostByEffect", "PowerAddRatio", "PowerReduceRatio", "PoisonAffectProduceValue", "CanReadingOnMonthChange",
		"MedicineEffect", "XiangshuInfectionDelta", "HealthDelta", "WeaponSilenceFrame", "SilenceFrame", "CurrAgeDelta", "GoneMadInAllBreak", "MakeLoveRateOnMonthChange", "CanAutoHealOnMonthChange", "HappinessDelta",
		"TeammateCmdCanUse", "MixPoisonInfinityAffect", "AttackRangeMaxAcupoint", "MaxMobilityPercent", "MakeMindDamage", "AcceptMindDamage", "HitAddByTempValue", "AvoidAddByTempValue", "IgnoreEquipmentOverload", "CanCostEnemyUsableTricks",
		"IgnoreArmor", "UnyieldingFallen", "NormalAttackPrepareFrame", "CanCostUselessTricks", "DefendSkillCanAffect", "AssistSkillCanAffect", "AgileSkillCanAffect", "AllMarkChangeToMind", "MindMarkChangeToFatal", "CanCast",
		"InevitableAvoid", "PowerEffectReverse", "FeatureBonusReverse", "WugFatalDamageValue", "CanRecoverHealthOnMonthChange", "TakeRevengeRateOnMonthChange", "ConsummateLevelBonus", "NeiliDelta", "CanMakeLoveSpecialOnMonthChange", "HealAcupointSpeed",
		"MaxChangeTrickCount", "ConvertCostBreathAndStance", "PersonalitiesAll", "FinalFatalDamageMarkCount", "CombatSkillAiScorePower", "NormalAttackChangeToUnlockAttack", "AttackBodyPartOdds", "ChangeDurability", "EquipmentBonus", "EquipmentWeight",
		"RawCreateEffectList", "JiTrickAsWeaponTrickCount", "UselessTrickAsJiTrickCount", "EquipmentPower", "HealFlawSpeed", "UnlockSpeed", "FlawBonusFactor", "CanCostShaTricks", "DefenderDirectFinalDamageValue", "NormalAttackRecoveryFrame",
		"FinalGoneMadInjury", "AttackerDirectFinalDamageValue", "CanCostTrickDuringPreparingSkill", "ValidItemList", "AcceptDamageCanAdd", "MakeDamageCanReduce", "NormalAttackGetTrickCount", "StayEffectCountOnAddPhase", "HealInjuryWithFatalRequireAttainment", "UseItemCostNoWisdom",
		"MindUpheavalTime", "MakeHarmfulActionSuccessRate", "AcceptHarmfulActionSuccessRate", "MakeFatalDamage", "AcceptFatalDamage", "CausedInjuryChangeToOldOdds", "CausedMindChangeToInfiniteOdds", "HitReduceDurability", "EquipmentMasteryAffectOdds", "CriticalDamage",
		"CanFightBackOutOfAttackRange", "AttackerCriticalOdds", "DefenderCriticalOdds", "MixPoisonCanAffectCount", "CastCostNeiliAllocationIsAbsorb", "AcceptInjuryChangeToOldOdds"
	};
}
