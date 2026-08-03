using System.Collections.Generic;

namespace GameData.Domains.Character;

public static class CharacterHelper
{
	/// <summary>
	/// 数据字段 ID 集合.
	/// 字段顺序: 档案字段, 缓存字段, 模板字段.
	/// </summary>
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

		public const ushort Surname = 118;

		public const ushort GivenName = 119;

		public const ushort AnonymousTitle = 120;

		public const ushort RandomFeaturesAtCreating = 121;

		public const ushort AllowUseFreeWeapon = 122;

		public const ushort AllowEscape = 123;

		public const ushort AllowHeal = 124;

		public const ushort CanDefeat = 125;

		public const ushort RandomEnemyId = 126;

		public const ushort LeadingEnemyNestId = 127;

		public const ushort FixedAvatarName = 128;

		public const ushort PresetBodyType = 129;

		public const ushort HideAge = 130;

		public const ushort Race = 131;

		public const ushort PresetFame = 132;

		public const ushort BaseAttraction = 133;

		public const ushort CanBeKidnapped = 134;

		public const ushort FixWeaponPower = 135;

		public const ushort FixArmorPower = 136;

		public const ushort FixCombatSkillPower = 137;

		public const ushort BaseHitValues = 138;

		public const ushort BasePenetrations = 139;

		public const ushort BaseAvoidValues = 140;

		public const ushort BasePenetrationResists = 141;

		public const ushort BaseRecoveryOfStanceAndBreath = 142;

		public const ushort BaseMoveSpeed = 143;

		public const ushort BaseRecoveryOfFlaw = 144;

		public const ushort BaseCastSpeed = 145;

		public const ushort BaseRecoveryOfBlockedAcupoint = 146;

		public const ushort BaseWeaponSwitchSpeed = 147;

		public const ushort BaseAttackSpeed = 148;

		public const ushort BaseInnerRatio = 149;

		public const ushort BaseRecoveryOfQiDisorder = 150;

		public const ushort BasePoisonResists = 151;

		public const ushort InnerInjuryImmunity = 152;

		public const ushort OuterInjuryImmunity = 153;

		public const ushort MindImmunity = 154;

		public const ushort FlawImmunity = 155;

		public const ushort AcupointImmunity = 156;

		public const ushort PoisonImmunities = 157;

		public const ushort PresetEquipment = 158;

		public const ushort PresetInventory = 159;

		public const ushort PresetCombatSkills = 160;

		public const ushort PresetNeiliProportionOfFiveElements = 161;

		public const ushort MinionGroupId = 162;

		public const ushort DamageSteps = 163;

		public const ushort IdeaAllocationProportion = 164;

		public const ushort ExtraEquipmentLoad = 165;

		public const ushort InitCurrAge = 166;

		public const ushort PresetTeammateCommands = 167;

		public const ushort IsFavorabilityDisplay = 168;

		public const ushort FixedCharacterShowNameOnMap = 169;

		public const ushort SpecialCombatSkeleton = 170;

		public const ushort DieImmunity = 171;

		public const ushort FatalImmunity = 172;

		public const ushort LearnedLifeSkillGrades = 173;

		public const ushort CombatAi = 174;

		public const ushort CanMove = 175;

		public const ushort CanOpenCharacterMenu = 176;

		public const ushort RandomAnimalAttack = 177;

		public const ushort DropResources = 178;

		public const ushort SpecialGradeName = 179;

		public const ushort PresetEatingItems = 180;

		public const ushort CanSpeak = 181;

		public const ushort RandomEnemyFavorability = 182;

		public const ushort GroupId = 183;

		public const ushort ExtraCombatSkillGrids = 184;

		public const ushort SpecialTemmateType = 185;

		public const ushort RandomIdealSects = 186;

		public const ushort AllowDropWugKing = 187;

		public const ushort AllowFavorabilitySkipCd = 188;

		public const ushort SpecialMuteBubbleEnemy = 189;

		public const ushort SpecialMuteBubbleSelf = 190;

		public const ushort DropRatePercentAsTeammate = 191;

		public const ushort DropRatePercentAsMainChar = 192;

		public const ushort FixedAvatarSpineSkin = 193;

		public const ushort FixedAvatarSpineName = 194;

		public const ushort CanBeTaiwu = 195;

		public const ushort CanBePossessionBody = 196;

		public const ushort EquipmentLock = 197;

		public const ushort CanBePossessionSoul = 198;

		public const ushort XiangshuInfectedDemonBonus = 199;
	}

	/// <summary>
	/// 档案数据字段数 (可能也是模板数据)
	/// </summary>
	public const ushort ArchiveFieldsCount = 75;

	/// <summary>
	/// 缓存数据字段数
	/// </summary>
	public const ushort CacheFieldsCount = 43;

	/// <summary>
	/// 纯模板数据字段数 (不同时是档案数据)
	/// </summary>
	public const ushort PureTemplateFieldsCount = 82;

	/// <summary>
	/// 可变数据字段数 (档案字段数与缓存字段数之和)
	/// </summary>
	public const ushort WritableFieldsCount = 118;

	/// <summary>
	/// 只读数据字段数 (模板字段数)
	/// </summary>
	public const ushort ReadonlyFieldsCount = 82;

	/// <summary>
	/// 通过字段名获取字段 ID
	/// </summary>
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
		{ "Surname", 118 },
		{ "GivenName", 119 },
		{ "AnonymousTitle", 120 },
		{ "RandomFeaturesAtCreating", 121 },
		{ "AllowUseFreeWeapon", 122 },
		{ "AllowEscape", 123 },
		{ "AllowHeal", 124 },
		{ "CanDefeat", 125 },
		{ "RandomEnemyId", 126 },
		{ "LeadingEnemyNestId", 127 },
		{ "FixedAvatarName", 128 },
		{ "PresetBodyType", 129 },
		{ "HideAge", 130 },
		{ "Race", 131 },
		{ "PresetFame", 132 },
		{ "BaseAttraction", 133 },
		{ "CanBeKidnapped", 134 },
		{ "FixWeaponPower", 135 },
		{ "FixArmorPower", 136 },
		{ "FixCombatSkillPower", 137 },
		{ "BaseHitValues", 138 },
		{ "BasePenetrations", 139 },
		{ "BaseAvoidValues", 140 },
		{ "BasePenetrationResists", 141 },
		{ "BaseRecoveryOfStanceAndBreath", 142 },
		{ "BaseMoveSpeed", 143 },
		{ "BaseRecoveryOfFlaw", 144 },
		{ "BaseCastSpeed", 145 },
		{ "BaseRecoveryOfBlockedAcupoint", 146 },
		{ "BaseWeaponSwitchSpeed", 147 },
		{ "BaseAttackSpeed", 148 },
		{ "BaseInnerRatio", 149 },
		{ "BaseRecoveryOfQiDisorder", 150 },
		{ "BasePoisonResists", 151 },
		{ "InnerInjuryImmunity", 152 },
		{ "OuterInjuryImmunity", 153 },
		{ "MindImmunity", 154 },
		{ "FlawImmunity", 155 },
		{ "AcupointImmunity", 156 },
		{ "PoisonImmunities", 157 },
		{ "PresetEquipment", 158 },
		{ "PresetInventory", 159 },
		{ "PresetCombatSkills", 160 },
		{ "PresetNeiliProportionOfFiveElements", 161 },
		{ "MinionGroupId", 162 },
		{ "DamageSteps", 163 },
		{ "IdeaAllocationProportion", 164 },
		{ "ExtraEquipmentLoad", 165 },
		{ "InitCurrAge", 166 },
		{ "PresetTeammateCommands", 167 },
		{ "IsFavorabilityDisplay", 168 },
		{ "FixedCharacterShowNameOnMap", 169 },
		{ "SpecialCombatSkeleton", 170 },
		{ "DieImmunity", 171 },
		{ "FatalImmunity", 172 },
		{ "LearnedLifeSkillGrades", 173 },
		{ "CombatAi", 174 },
		{ "CanMove", 175 },
		{ "CanOpenCharacterMenu", 176 },
		{ "RandomAnimalAttack", 177 },
		{ "DropResources", 178 },
		{ "SpecialGradeName", 179 },
		{ "PresetEatingItems", 180 },
		{ "CanSpeak", 181 },
		{ "RandomEnemyFavorability", 182 },
		{ "GroupId", 183 },
		{ "ExtraCombatSkillGrids", 184 },
		{ "SpecialTemmateType", 185 },
		{ "RandomIdealSects", 186 },
		{ "AllowDropWugKing", 187 },
		{ "AllowFavorabilitySkipCd", 188 },
		{ "SpecialMuteBubbleEnemy", 189 },
		{ "SpecialMuteBubbleSelf", 190 },
		{ "DropRatePercentAsTeammate", 191 },
		{ "DropRatePercentAsMainChar", 192 },
		{ "FixedAvatarSpineSkin", 193 },
		{ "FixedAvatarSpineName", 194 },
		{ "CanBeTaiwu", 195 },
		{ "CanBePossessionBody", 196 },
		{ "EquipmentLock", 197 },
		{ "CanBePossessionSoul", 198 },
		{ "XiangshuInfectedDemonBonus", 199 }
	};

	/// <summary>
	/// 通过字段 ID 获取字段名
	/// </summary>
	public static readonly string[] FieldId2FieldName = new string[200]
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
		"NeiliProportionOfFiveElements", "NeiliType", "CombatPower", "AttackTendencyOfInnerAndOuter", "AllocatedNeiliEffects", "MaxConsummateLevel", "CombatSkillEquipment", "DarkAshProtector", "Surname", "GivenName",
		"AnonymousTitle", "RandomFeaturesAtCreating", "AllowUseFreeWeapon", "AllowEscape", "AllowHeal", "CanDefeat", "RandomEnemyId", "LeadingEnemyNestId", "FixedAvatarName", "PresetBodyType",
		"HideAge", "Race", "PresetFame", "BaseAttraction", "CanBeKidnapped", "FixWeaponPower", "FixArmorPower", "FixCombatSkillPower", "BaseHitValues", "BasePenetrations",
		"BaseAvoidValues", "BasePenetrationResists", "BaseRecoveryOfStanceAndBreath", "BaseMoveSpeed", "BaseRecoveryOfFlaw", "BaseCastSpeed", "BaseRecoveryOfBlockedAcupoint", "BaseWeaponSwitchSpeed", "BaseAttackSpeed", "BaseInnerRatio",
		"BaseRecoveryOfQiDisorder", "BasePoisonResists", "InnerInjuryImmunity", "OuterInjuryImmunity", "MindImmunity", "FlawImmunity", "AcupointImmunity", "PoisonImmunities", "PresetEquipment", "PresetInventory",
		"PresetCombatSkills", "PresetNeiliProportionOfFiveElements", "MinionGroupId", "DamageSteps", "IdeaAllocationProportion", "ExtraEquipmentLoad", "InitCurrAge", "PresetTeammateCommands", "IsFavorabilityDisplay", "FixedCharacterShowNameOnMap",
		"SpecialCombatSkeleton", "DieImmunity", "FatalImmunity", "LearnedLifeSkillGrades", "CombatAi", "CanMove", "CanOpenCharacterMenu", "RandomAnimalAttack", "DropResources", "SpecialGradeName",
		"PresetEatingItems", "CanSpeak", "RandomEnemyFavorability", "GroupId", "ExtraCombatSkillGrids", "SpecialTemmateType", "RandomIdealSects", "AllowDropWugKing", "AllowFavorabilitySkipCd", "SpecialMuteBubbleEnemy",
		"SpecialMuteBubbleSelf", "DropRatePercentAsTeammate", "DropRatePercentAsMainChar", "FixedAvatarSpineSkin", "FixedAvatarSpineName", "CanBeTaiwu", "CanBePossessionBody", "EquipmentLock", "CanBePossessionSoul", "XiangshuInfectedDemonBonus"
	};
}
