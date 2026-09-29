using System.Collections.Generic;

namespace GameData.Domains.Character;

public static class CharacterHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort TemplateId = 1;

		public const ushort CreatingType = 2;

		public const ushort Gender = 3;

		public const ushort ActualAge = 4;

		public const ushort BirthMonth = 5;

		public const ushort Happiness = 6;

		public const ushort BaseMorality = 7;

		public const ushort OrganizationInfo = 8;

		public const ushort IdealSect = 9;

		public const ushort LifeSkillTypeInterest = 10;

		public const ushort CombatSkillTypeInterest = 11;

		public const ushort MainAttributeInterest = 12;

		public const ushort Transgender = 13;

		public const ushort Bisexual = 14;

		public const ushort XiangshuType = 15;

		public const ushort MonkType = 16;

		public const ushort FeatureIds = 17;

		public const ushort BaseMainAttributes = 18;

		public const ushort Health = 19;

		public const ushort BaseMaxHealth = 20;

		public const ushort DisorderOfQi = 21;

		public const ushort HaveLeftArm = 22;

		public const ushort HaveRightArm = 23;

		public const ushort HaveLeftLeg = 24;

		public const ushort HaveRightLeg = 25;

		public const ushort Injuries = 26;

		public const ushort ExtraNeili = 27;

		public const ushort ConsummateLevel = 28;

		public const ushort LearnedLifeSkills = 29;

		public const ushort BaseLifeSkillQualifications = 30;

		public const ushort LifeSkillQualificationGrowthType = 31;

		public const ushort BaseCombatSkillQualifications = 32;

		public const ushort CombatSkillQualificationGrowthType = 33;

		public const ushort Resources = 34;

		public const ushort LovingItemSubType = 35;

		public const ushort HatingItemSubType = 36;

		public const ushort FullName = 37;

		public const ushort MonasticTitle = 38;

		public const ushort Avatar = 39;

		public const ushort PotentialFeatureIds = 40;

		public const ushort FameActionRecords = 41;

		public const ushort Genome = 42;

		public const ushort CurrMainAttributes = 43;

		public const ushort Poisoned = 44;

		public const ushort CurrNeili = 45;

		public const ushort LoopingNeigong = 46;

		public const ushort BaseNeiliAllocation = 47;

		public const ushort ExtraNeiliAllocation = 48;

		public const ushort BaseNeiliProportionOfFiveElements = 49;

		public const ushort HobbyExpirationDate = 50;

		public const ushort LovingItemRevealed = 51;

		public const ushort HatingItemRevealed = 52;

		public const ushort LegitimateBoysCount = 53;

		public const ushort BirthLocation = 54;

		public const ushort Location = 55;

		public const ushort Equipment = 56;

		public const ushort Inventory = 57;

		public const ushort EatingItems = 58;

		public const ushort LearnedCombatSkills = 59;

		public const ushort EquippedCombatSkills = 60;

		public const ushort CombatSkillAttainmentPanels = 61;

		public const ushort SkillQualificationBonuses = 62;

		public const ushort PreexistenceCharIds = 63;

		public const ushort XiangshuInfection = 64;

		public const ushort CurrAge = 65;

		public const ushort Exp = 66;

		public const ushort ExternalRelationState = 67;

		public const ushort KidnapperId = 68;

		public const ushort LeaderId = 69;

		public const ushort FactionId = 70;

		public const ushort NpcTravelTargets = 71;

		public const ushort ExtraNeiliAllocationProgress = 72;

		public const ushort UsedQualificationPotential = 73;

		public const ushort WugKingDriveDataEx = 74;

		public const ushort PhysiologicalAge = 75;

		public const ushort Fame = 76;

		public const ushort Morality = 77;

		public const ushort Attraction = 78;

		public const ushort MaxMainAttributes = 79;

		public const ushort HitValues = 80;

		public const ushort Penetrations = 81;

		public const ushort AvoidValues = 82;

		public const ushort PenetrationResists = 83;

		public const ushort RecoveryOfStanceAndBreath = 84;

		public const ushort MoveSpeed = 85;

		public const ushort RecoveryOfFlaw = 86;

		public const ushort CastSpeed = 87;

		public const ushort RecoveryOfBlockedAcupoint = 88;

		public const ushort WeaponSwitchSpeed = 89;

		public const ushort AttackSpeed = 90;

		public const ushort InnerRatio = 91;

		public const ushort RecoveryOfQiDisorder = 92;

		public const ushort PoisonResists = 93;

		public const ushort MaxHealth = 94;

		public const ushort Fertility = 95;

		public const ushort LifeSkillQualifications = 96;

		public const ushort LifeSkillAttainments = 97;

		public const ushort CombatSkillQualifications = 98;

		public const ushort CombatSkillAttainments = 99;

		public const ushort Personalities = 100;

		public const ushort HobbyChangingPeriod = 101;

		public const ushort FavorabilityChangingFactor = 102;

		public const ushort MaxInventoryLoad = 103;

		public const ushort CurrInventoryLoad = 104;

		public const ushort MaxEquipmentLoad = 105;

		public const ushort CurrEquipmentLoad = 106;

		public const ushort InventoryTotalValue = 107;

		public const ushort MaxNeili = 108;

		public const ushort NeiliAllocation = 109;

		public const ushort NeiliProportionOfFiveElements = 110;

		public const ushort NeiliType = 111;

		public const ushort CombatPower = 112;

		public const ushort AttackTendencyOfInnerAndOuter = 113;

		public const ushort AllocatedNeiliEffects = 114;

		public const ushort MaxConsummateLevel = 115;

		public const ushort CombatSkillEquipment = 116;

		public const ushort DarkAshProtector = 117;

		public const ushort ImmunityMask = 118;

		public const ushort Surname = 119;

		public const ushort GivenName = 120;

		public const ushort AnonymousTitle = 121;

		public const ushort RandomFeaturesAtCreating = 122;

		public const ushort AllowUseFreeWeapon = 123;

		public const ushort AllowEscape = 124;

		public const ushort AllowHeal = 125;

		public const ushort CanDefeat = 126;

		public const ushort RandomEnemyId = 127;

		public const ushort LeadingEnemyNestId = 128;

		public const ushort FixedAvatarName = 129;

		public const ushort PresetBodyType = 130;

		public const ushort HideAge = 131;

		public const ushort Race = 132;

		public const ushort PresetFame = 133;

		public const ushort BaseAttraction = 134;

		public const ushort CanBeKidnapped = 135;

		public const ushort FixWeaponPower = 136;

		public const ushort FixArmorPower = 137;

		public const ushort FixCombatSkillPower = 138;

		public const ushort BaseHitValues = 139;

		public const ushort BasePenetrations = 140;

		public const ushort BaseAvoidValues = 141;

		public const ushort BasePenetrationResists = 142;

		public const ushort BaseRecoveryOfStanceAndBreath = 143;

		public const ushort BaseMoveSpeed = 144;

		public const ushort BaseRecoveryOfFlaw = 145;

		public const ushort BaseCastSpeed = 146;

		public const ushort BaseRecoveryOfBlockedAcupoint = 147;

		public const ushort BaseWeaponSwitchSpeed = 148;

		public const ushort BaseAttackSpeed = 149;

		public const ushort BaseInnerRatio = 150;

		public const ushort BaseRecoveryOfQiDisorder = 151;

		public const ushort BasePoisonResists = 152;

		public const ushort InnerInjuryImmunity = 153;

		public const ushort OuterInjuryImmunity = 154;

		public const ushort MindImmunity = 155;

		public const ushort FlawImmunity = 156;

		public const ushort AcupointImmunity = 157;

		public const ushort PoisonImmunities = 158;

		public const ushort PresetEquipment = 159;

		public const ushort PresetInventory = 160;

		public const ushort PresetCombatSkills = 161;

		public const ushort PresetNeiliProportionOfFiveElements = 162;

		public const ushort MinionGroupId = 163;

		public const ushort DamageSteps = 164;

		public const ushort IdeaAllocationProportion = 165;

		public const ushort ExtraEquipmentLoad = 166;

		public const ushort InitCurrAge = 167;

		public const ushort PresetTeammateCommands = 168;

		public const ushort IsFavorabilityDisplay = 169;

		public const ushort FixedCharacterShowNameOnMap = 170;

		public const ushort SpecialCombatSkeleton = 171;

		public const ushort DieImmunity = 172;

		public const ushort FatalImmunity = 173;

		public const ushort LearnedLifeSkillGrades = 174;

		public const ushort CombatAi = 175;

		public const ushort CanMove = 176;

		public const ushort CanOpenCharacterMenu = 177;

		public const ushort RandomAnimalAttack = 178;

		public const ushort DropResources = 179;

		public const ushort SpecialGradeName = 180;

		public const ushort PresetEatingItems = 181;

		public const ushort CanSpeak = 182;

		public const ushort RandomEnemyFavorability = 183;

		public const ushort GroupId = 184;

		public const ushort ExtraCombatSkillGrids = 185;

		public const ushort SpecialTemmateType = 186;

		public const ushort RandomIdealSects = 187;

		public const ushort AllowDropWugKing = 188;

		public const ushort AllowFavorabilitySkipCd = 189;

		public const ushort SpecialMuteBubbleEnemy = 190;

		public const ushort SpecialMuteBubbleSelf = 191;

		public const ushort DropRatePercentAsTeammate = 192;

		public const ushort DropRatePercentAsMainChar = 193;

		public const ushort FixedAvatarSpineSkin = 194;

		public const ushort FixedAvatarSpineName = 195;

		public const ushort CanBeTaiwu = 196;

		public const ushort CanBePossessionBody = 197;

		public const ushort EquipmentLock = 198;

		public const ushort CanBePossessionSoul = 199;

		public const ushort XiangshuInfectedDemonBonus = 200;

		public const ushort InfectedFixedAvatarSpineName = 201;

		public const ushort InfectedFixedAvatarSpineSkin = 202;

		public const ushort DisableTeammateCommands = 203;

		public const ushort ShowLegendaryBookConsumedCloth = 204;

		public const ushort AvatarDataPath = 205;

		public const ushort GroupType = 206;

		public const ushort TaiwuAsXiangshuDelete = 207;

		public const ushort ConvertToIntelligent = 208;

		public const ushort InfectedFixedAvatarName = 209;

		public const ushort ChallengeModeMinionGroupId = 210;
	}

	public const ushort ArchiveFieldsCount = 75;

	public const ushort CacheFieldsCount = 44;

	public const ushort PureTemplateFieldsCount = 92;

	public const ushort WritableFieldsCount = 119;

	public const ushort ReadonlyFieldsCount = 92;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "TemplateId", 1 },
		{ "CreatingType", 2 },
		{ "Gender", 3 },
		{ "ActualAge", 4 },
		{ "BirthMonth", 5 },
		{ "Happiness", 6 },
		{ "BaseMorality", 7 },
		{ "OrganizationInfo", 8 },
		{ "IdealSect", 9 },
		{ "LifeSkillTypeInterest", 10 },
		{ "CombatSkillTypeInterest", 11 },
		{ "MainAttributeInterest", 12 },
		{ "Transgender", 13 },
		{ "Bisexual", 14 },
		{ "XiangshuType", 15 },
		{ "MonkType", 16 },
		{ "FeatureIds", 17 },
		{ "BaseMainAttributes", 18 },
		{ "Health", 19 },
		{ "BaseMaxHealth", 20 },
		{ "DisorderOfQi", 21 },
		{ "HaveLeftArm", 22 },
		{ "HaveRightArm", 23 },
		{ "HaveLeftLeg", 24 },
		{ "HaveRightLeg", 25 },
		{ "Injuries", 26 },
		{ "ExtraNeili", 27 },
		{ "ConsummateLevel", 28 },
		{ "LearnedLifeSkills", 29 },
		{ "BaseLifeSkillQualifications", 30 },
		{ "LifeSkillQualificationGrowthType", 31 },
		{ "BaseCombatSkillQualifications", 32 },
		{ "CombatSkillQualificationGrowthType", 33 },
		{ "Resources", 34 },
		{ "LovingItemSubType", 35 },
		{ "HatingItemSubType", 36 },
		{ "FullName", 37 },
		{ "MonasticTitle", 38 },
		{ "Avatar", 39 },
		{ "PotentialFeatureIds", 40 },
		{ "FameActionRecords", 41 },
		{ "Genome", 42 },
		{ "CurrMainAttributes", 43 },
		{ "Poisoned", 44 },
		{ "CurrNeili", 45 },
		{ "LoopingNeigong", 46 },
		{ "BaseNeiliAllocation", 47 },
		{ "ExtraNeiliAllocation", 48 },
		{ "BaseNeiliProportionOfFiveElements", 49 },
		{ "HobbyExpirationDate", 50 },
		{ "LovingItemRevealed", 51 },
		{ "HatingItemRevealed", 52 },
		{ "LegitimateBoysCount", 53 },
		{ "BirthLocation", 54 },
		{ "Location", 55 },
		{ "Equipment", 56 },
		{ "Inventory", 57 },
		{ "EatingItems", 58 },
		{ "LearnedCombatSkills", 59 },
		{ "EquippedCombatSkills", 60 },
		{ "CombatSkillAttainmentPanels", 61 },
		{ "SkillQualificationBonuses", 62 },
		{ "PreexistenceCharIds", 63 },
		{ "XiangshuInfection", 64 },
		{ "CurrAge", 65 },
		{ "Exp", 66 },
		{ "ExternalRelationState", 67 },
		{ "KidnapperId", 68 },
		{ "LeaderId", 69 },
		{ "FactionId", 70 },
		{ "NpcTravelTargets", 71 },
		{ "ExtraNeiliAllocationProgress", 72 },
		{ "UsedQualificationPotential", 73 },
		{ "WugKingDriveDataEx", 74 },
		{ "PhysiologicalAge", 75 },
		{ "Fame", 76 },
		{ "Morality", 77 },
		{ "Attraction", 78 },
		{ "MaxMainAttributes", 79 },
		{ "HitValues", 80 },
		{ "Penetrations", 81 },
		{ "AvoidValues", 82 },
		{ "PenetrationResists", 83 },
		{ "RecoveryOfStanceAndBreath", 84 },
		{ "MoveSpeed", 85 },
		{ "RecoveryOfFlaw", 86 },
		{ "CastSpeed", 87 },
		{ "RecoveryOfBlockedAcupoint", 88 },
		{ "WeaponSwitchSpeed", 89 },
		{ "AttackSpeed", 90 },
		{ "InnerRatio", 91 },
		{ "RecoveryOfQiDisorder", 92 },
		{ "PoisonResists", 93 },
		{ "MaxHealth", 94 },
		{ "Fertility", 95 },
		{ "LifeSkillQualifications", 96 },
		{ "LifeSkillAttainments", 97 },
		{ "CombatSkillQualifications", 98 },
		{ "CombatSkillAttainments", 99 },
		{ "Personalities", 100 },
		{ "HobbyChangingPeriod", 101 },
		{ "FavorabilityChangingFactor", 102 },
		{ "MaxInventoryLoad", 103 },
		{ "CurrInventoryLoad", 104 },
		{ "MaxEquipmentLoad", 105 },
		{ "CurrEquipmentLoad", 106 },
		{ "InventoryTotalValue", 107 },
		{ "MaxNeili", 108 },
		{ "NeiliAllocation", 109 },
		{ "NeiliProportionOfFiveElements", 110 },
		{ "NeiliType", 111 },
		{ "CombatPower", 112 },
		{ "AttackTendencyOfInnerAndOuter", 113 },
		{ "AllocatedNeiliEffects", 114 },
		{ "MaxConsummateLevel", 115 },
		{ "CombatSkillEquipment", 116 },
		{ "DarkAshProtector", 117 },
		{ "ImmunityMask", 118 },
		{ "Surname", 119 },
		{ "GivenName", 120 },
		{ "AnonymousTitle", 121 },
		{ "RandomFeaturesAtCreating", 122 },
		{ "AllowUseFreeWeapon", 123 },
		{ "AllowEscape", 124 },
		{ "AllowHeal", 125 },
		{ "CanDefeat", 126 },
		{ "RandomEnemyId", 127 },
		{ "LeadingEnemyNestId", 128 },
		{ "FixedAvatarName", 129 },
		{ "PresetBodyType", 130 },
		{ "HideAge", 131 },
		{ "Race", 132 },
		{ "PresetFame", 133 },
		{ "BaseAttraction", 134 },
		{ "CanBeKidnapped", 135 },
		{ "FixWeaponPower", 136 },
		{ "FixArmorPower", 137 },
		{ "FixCombatSkillPower", 138 },
		{ "BaseHitValues", 139 },
		{ "BasePenetrations", 140 },
		{ "BaseAvoidValues", 141 },
		{ "BasePenetrationResists", 142 },
		{ "BaseRecoveryOfStanceAndBreath", 143 },
		{ "BaseMoveSpeed", 144 },
		{ "BaseRecoveryOfFlaw", 145 },
		{ "BaseCastSpeed", 146 },
		{ "BaseRecoveryOfBlockedAcupoint", 147 },
		{ "BaseWeaponSwitchSpeed", 148 },
		{ "BaseAttackSpeed", 149 },
		{ "BaseInnerRatio", 150 },
		{ "BaseRecoveryOfQiDisorder", 151 },
		{ "BasePoisonResists", 152 },
		{ "InnerInjuryImmunity", 153 },
		{ "OuterInjuryImmunity", 154 },
		{ "MindImmunity", 155 },
		{ "FlawImmunity", 156 },
		{ "AcupointImmunity", 157 },
		{ "PoisonImmunities", 158 },
		{ "PresetEquipment", 159 },
		{ "PresetInventory", 160 },
		{ "PresetCombatSkills", 161 },
		{ "PresetNeiliProportionOfFiveElements", 162 },
		{ "MinionGroupId", 163 },
		{ "DamageSteps", 164 },
		{ "IdeaAllocationProportion", 165 },
		{ "ExtraEquipmentLoad", 166 },
		{ "InitCurrAge", 167 },
		{ "PresetTeammateCommands", 168 },
		{ "IsFavorabilityDisplay", 169 },
		{ "FixedCharacterShowNameOnMap", 170 },
		{ "SpecialCombatSkeleton", 171 },
		{ "DieImmunity", 172 },
		{ "FatalImmunity", 173 },
		{ "LearnedLifeSkillGrades", 174 },
		{ "CombatAi", 175 },
		{ "CanMove", 176 },
		{ "CanOpenCharacterMenu", 177 },
		{ "RandomAnimalAttack", 178 },
		{ "DropResources", 179 },
		{ "SpecialGradeName", 180 },
		{ "PresetEatingItems", 181 },
		{ "CanSpeak", 182 },
		{ "RandomEnemyFavorability", 183 },
		{ "GroupId", 184 },
		{ "ExtraCombatSkillGrids", 185 },
		{ "SpecialTemmateType", 186 },
		{ "RandomIdealSects", 187 },
		{ "AllowDropWugKing", 188 },
		{ "AllowFavorabilitySkipCd", 189 },
		{ "SpecialMuteBubbleEnemy", 190 },
		{ "SpecialMuteBubbleSelf", 191 },
		{ "DropRatePercentAsTeammate", 192 },
		{ "DropRatePercentAsMainChar", 193 },
		{ "FixedAvatarSpineSkin", 194 },
		{ "FixedAvatarSpineName", 195 },
		{ "CanBeTaiwu", 196 },
		{ "CanBePossessionBody", 197 },
		{ "EquipmentLock", 198 },
		{ "CanBePossessionSoul", 199 },
		{ "XiangshuInfectedDemonBonus", 200 },
		{ "InfectedFixedAvatarSpineName", 201 },
		{ "InfectedFixedAvatarSpineSkin", 202 },
		{ "DisableTeammateCommands", 203 },
		{ "ShowLegendaryBookConsumedCloth", 204 },
		{ "AvatarDataPath", 205 },
		{ "GroupType", 206 },
		{ "TaiwuAsXiangshuDelete", 207 },
		{ "ConvertToIntelligent", 208 },
		{ "InfectedFixedAvatarName", 209 },
		{ "ChallengeModeMinionGroupId", 210 }
	};

	public static readonly string[] FieldId2FieldName = new string[211]
	{
		"Id", "TemplateId", "CreatingType", "Gender", "ActualAge", "BirthMonth", "Happiness", "BaseMorality", "OrganizationInfo", "IdealSect",
		"LifeSkillTypeInterest", "CombatSkillTypeInterest", "MainAttributeInterest", "Transgender", "Bisexual", "XiangshuType", "MonkType", "FeatureIds", "BaseMainAttributes", "Health",
		"BaseMaxHealth", "DisorderOfQi", "HaveLeftArm", "HaveRightArm", "HaveLeftLeg", "HaveRightLeg", "Injuries", "ExtraNeili", "ConsummateLevel", "LearnedLifeSkills",
		"BaseLifeSkillQualifications", "LifeSkillQualificationGrowthType", "BaseCombatSkillQualifications", "CombatSkillQualificationGrowthType", "Resources", "LovingItemSubType", "HatingItemSubType", "FullName", "MonasticTitle", "Avatar",
		"PotentialFeatureIds", "FameActionRecords", "Genome", "CurrMainAttributes", "Poisoned", "CurrNeili", "LoopingNeigong", "BaseNeiliAllocation", "ExtraNeiliAllocation", "BaseNeiliProportionOfFiveElements",
		"HobbyExpirationDate", "LovingItemRevealed", "HatingItemRevealed", "LegitimateBoysCount", "BirthLocation", "Location", "Equipment", "Inventory", "EatingItems", "LearnedCombatSkills",
		"EquippedCombatSkills", "CombatSkillAttainmentPanels", "SkillQualificationBonuses", "PreexistenceCharIds", "XiangshuInfection", "CurrAge", "Exp", "ExternalRelationState", "KidnapperId", "LeaderId",
		"FactionId", "NpcTravelTargets", "ExtraNeiliAllocationProgress", "UsedQualificationPotential", "WugKingDriveDataEx", "PhysiologicalAge", "Fame", "Morality", "Attraction", "MaxMainAttributes",
		"HitValues", "Penetrations", "AvoidValues", "PenetrationResists", "RecoveryOfStanceAndBreath", "MoveSpeed", "RecoveryOfFlaw", "CastSpeed", "RecoveryOfBlockedAcupoint", "WeaponSwitchSpeed",
		"AttackSpeed", "InnerRatio", "RecoveryOfQiDisorder", "PoisonResists", "MaxHealth", "Fertility", "LifeSkillQualifications", "LifeSkillAttainments", "CombatSkillQualifications", "CombatSkillAttainments",
		"Personalities", "HobbyChangingPeriod", "FavorabilityChangingFactor", "MaxInventoryLoad", "CurrInventoryLoad", "MaxEquipmentLoad", "CurrEquipmentLoad", "InventoryTotalValue", "MaxNeili", "NeiliAllocation",
		"NeiliProportionOfFiveElements", "NeiliType", "CombatPower", "AttackTendencyOfInnerAndOuter", "AllocatedNeiliEffects", "MaxConsummateLevel", "CombatSkillEquipment", "DarkAshProtector", "ImmunityMask", "Surname",
		"GivenName", "AnonymousTitle", "RandomFeaturesAtCreating", "AllowUseFreeWeapon", "AllowEscape", "AllowHeal", "CanDefeat", "RandomEnemyId", "LeadingEnemyNestId", "FixedAvatarName",
		"PresetBodyType", "HideAge", "Race", "PresetFame", "BaseAttraction", "CanBeKidnapped", "FixWeaponPower", "FixArmorPower", "FixCombatSkillPower", "BaseHitValues",
		"BasePenetrations", "BaseAvoidValues", "BasePenetrationResists", "BaseRecoveryOfStanceAndBreath", "BaseMoveSpeed", "BaseRecoveryOfFlaw", "BaseCastSpeed", "BaseRecoveryOfBlockedAcupoint", "BaseWeaponSwitchSpeed", "BaseAttackSpeed",
		"BaseInnerRatio", "BaseRecoveryOfQiDisorder", "BasePoisonResists", "InnerInjuryImmunity", "OuterInjuryImmunity", "MindImmunity", "FlawImmunity", "AcupointImmunity", "PoisonImmunities", "PresetEquipment",
		"PresetInventory", "PresetCombatSkills", "PresetNeiliProportionOfFiveElements", "MinionGroupId", "DamageSteps", "IdeaAllocationProportion", "ExtraEquipmentLoad", "InitCurrAge", "PresetTeammateCommands", "IsFavorabilityDisplay",
		"FixedCharacterShowNameOnMap", "SpecialCombatSkeleton", "DieImmunity", "FatalImmunity", "LearnedLifeSkillGrades", "CombatAi", "CanMove", "CanOpenCharacterMenu", "RandomAnimalAttack", "DropResources",
		"SpecialGradeName", "PresetEatingItems", "CanSpeak", "RandomEnemyFavorability", "GroupId", "ExtraCombatSkillGrids", "SpecialTemmateType", "RandomIdealSects", "AllowDropWugKing", "AllowFavorabilitySkipCd",
		"SpecialMuteBubbleEnemy", "SpecialMuteBubbleSelf", "DropRatePercentAsTeammate", "DropRatePercentAsMainChar", "FixedAvatarSpineSkin", "FixedAvatarSpineName", "CanBeTaiwu", "CanBePossessionBody", "EquipmentLock", "CanBePossessionSoul",
		"XiangshuInfectedDemonBonus", "InfectedFixedAvatarSpineName", "InfectedFixedAvatarSpineSkin", "DisableTeammateCommands", "ShowLegendaryBookConsumedCloth", "AvatarDataPath", "GroupType", "TaiwuAsXiangshuDelete", "ConvertToIntelligent", "InfectedFixedAvatarName",
		"ChallengeModeMinionGroupId"
	};
}
