using System.Collections.Generic;

namespace GameData.Domains.Combat;

public static class CombatDomainHelper
{
	public static class DataIds
	{
		public const ushort TimeScale = 0;

		public const ushort AutoCombat = 1;

		public const ushort CombatFrame = 2;

		public const ushort CombatType = 3;

		public const ushort CurrentDistance = 4;

		public const ushort DamageCompareData = 5;

		public const ushort SkillPowerAddInCombat = 6;

		public const ushort SkillPowerReduceInCombat = 7;

		public const ushort SkillPowerReplaceInCombat = 8;

		public const ushort BgmIndex = 9;

		public const ushort CombatCharacterDict = 10;

		public const ushort SelfTeam = 11;

		public const ushort SelfCharId = 12;

		public const ushort SelfTeamWisdomType = 13;

		public const ushort SelfTeamWisdomCount = 14;

		public const ushort EnemyTeam = 15;

		public const ushort EnemyCharId = 16;

		public const ushort EnemyTeamWisdomType = 17;

		public const ushort EnemyTeamWisdomCount = 18;

		public const ushort CombatStatus = 19;

		public const ushort ShowMercyOption = 20;

		public const ushort SelectedMercyOption = 21;

		public const ushort CarrierAnimalCombatCharId = 22;

		public const ushort SpecialShowCombatCharId = 23;

		public const ushort NotUsed = 24;

		public const ushort WaitingDelaySettlement = 25;

		public const ushort ShowUseGoldenWire = 26;

		public const ushort IsPuppetCombat = 27;

		public const ushort IsPlaygroundCombat = 28;

		public const ushort SkillDataDict = 29;

		public const ushort WeaponDataDict = 30;

		public const ushort ExpectRatioData = 31;

		public const ushort TaiwuSpecialGroupCharIds = 32;

		public const ushort LastTargetDistance = 33;

		public const ushort ChangeTrickIndex = 34;

		public const ushort ChangeTrickBodyPart = 35;

		public const ushort ChangeTrickIsFlaw = 36;

		public const ushort EnemyUnyieldingFallen = 37;

		public const ushort DisableEnemyAi = 38;

		public const ushort PreferWeaponIndex = 39;

		public const ushort CombatQuickUseItemSlotDataList = 40;

		public const ushort SkillDamageData = 41;

		public const ushort NextAvailableChickenPointAppearCd = 42;

		public const ushort ChickenPointZones = 43;
	}

	public static class MethodIds
	{
		public const ushort PlayMoveStepSound = 0;

		public const ushort ExecuteTeammateCommand = 1;

		public const ushort GetCombatCharDisplayData = 2;

		public const ushort SelectMercyOption = 3;

		public const ushort ChangeWeapon = 4;

		public const ushort NormalAttack = 5;

		public const ushort StartChangeTrick = 6;

		public const ushort SelectChangeTrick = 7;

		public const ushort ChangeTaiwuWeaponInnerRatio = 8;

		public const ushort GetWeaponInnerRatio = 9;

		public const ushort StartPrepareOtherAction = 10;

		public const ushort GetProactiveSkillList = 11;

		public const ushort StartPrepareSkill = 12;

		public const ushort GmCmd_ForceRecoverBreathAndStance = 13;

		public const ushort GmCmd_AddTrick = 14;

		public const ushort GmCmd_AddInjury = 15;

		public const ushort GmCmd_ForceHealAllInjury = 16;

		public const ushort GmCmd_AddPoison = 17;

		public const ushort GmCmd_ForceHealAllPoison = 18;

		public const ushort GmCmd_ForceEnemyUseSkill = 19;

		public const ushort GmCmd_ForceEnemyUseOtherAction = 20;

		public const ushort GmCmd_ForceEnemyDefeat = 21;

		public const ushort GmCmd_ForceSelfDefeat = 22;

		public const ushort GmCmd_SetNeiliAllocation = 23;

		public const ushort GmCmd_AddFlaw = 24;

		public const ushort GmCmd_HealAllFlaw = 25;

		public const ushort GmCmd_AddAcupoint = 26;

		public const ushort GmCmd_HealAllAcupoint = 27;

		public const ushort GmCmd_FightBoss = 28;

		public const ushort GmCmd_FightAnimal = 29;

		public const ushort GmCmd_EnableEnemyAi = 30;

		public const ushort GmCmd_EnableSkillFreeCast = 31;

		public const ushort GetHealInjuryBanReason = 32;

		public const ushort GetHealPoisonBanReason = 33;

		public const ushort UseItem = 34;

		public const ushort PrepareCombat = 35;

		public const ushort StartCombat = 36;

		public const ushort SetTimeScale = 37;

		public const ushort SetPlayerAutoCombat = 38;

		public const ushort SetAiOptions = 39;

		public const ushort SetMoveState = 40;

		public const ushort GetCombatResultDisplayData = 41;

		public const ushort SelectGetItem = 42;

		public const ushort Surrender = 43;

		public const ushort EnterBossPuppetCombat = 44;

		public const ushort RepairItem = 45;

		public const ushort PrepareEnemyEquipments = 46;

		public const ushort EnableBulletTime = 47;

		public const ushort GmCmd_SetImmortal = 48;

		public const ushort CancelChangeTrick = 49;

		public const ushort ClearAllReserveAction = 50;

		public const ushort IsInCombat = 51;

		public const ushort GmCmd_FightTestOrgMember = 52;

		public const ushort GmCmd_FightRandomEnemy = 53;

		public const ushort GmCmd_ForceRecoverMobilityValue = 54;

		public const ushort GmCmd_UnitTestSetDistanceToTarget = 55;

		public const ushort GmCmd_UnitTestEquipSkill = 56;

		public const ushort GmCmd_UnitTestPrepare = 57;

		public const ushort GmCmd_UnitTestClearAllEquipSkill = 58;

		public const ushort GetFatalDamageStepDisplayData = 59;

		public const ushort GetMindDamageStepDisplayData = 60;

		public const ushort GetBodyPartDamageStepDisplayData = 61;

		public const ushort GetCompleteDamageStepDisplayData = 62;

		public const ushort GmCmd_ForceRecoverWugCount = 63;

		public const ushort GmCmd_FightCharacter = 64;

		public const ushort GetChangeTrickDisplayData = 65;

		public const ushort ClearAffectingDefenseSkillManual = 66;

		public const ushort ClearDefendInBlockAttackSkill = 67;

		public const ushort GmCmd_HealAllFatal = 68;

		public const ushort GmCmd_HealAllDefeatMark = 69;

		public const ushort GmCmd_AddAllDefeatMark = 70;

		public const ushort GmCmd_AddFatal = 71;

		public const ushort GmCmd_HealAllDie = 72;

		public const ushort GmCmd_AddDie = 73;

		public const ushort GmCmd_HealAllMind = 74;

		public const ushort GmCmd_HealInjury = 75;

		public const ushort GmCmd_AddMind = 76;

		public const ushort SetTargetDistance = 77;

		public const ushort ClearTargetDistance = 78;

		public const ushort SetJumpThreshold = 79;

		public const ushort GetPreviewAttackRange = 80;

		public const ushort SetPuppetUnyieldingFallen = 81;

		public const ushort SetPuppetDisableAi = 82;

		public const ushort InterruptSkillManual = 83;

		public const ushort ClearAffectingMoveSkillManual = 84;

		public const ushort UnlockAttack = 85;

		public const ushort IgnoreAllRawCreate = 86;

		public const ushort IgnoreRawCreate = 87;

		public const ushort DoRawCreate = 88;

		public const ushort GetAllCanRawCreateEquipmentSlots = 89;

		public const ushort GetUnlockSimulateResult = 90;

		public const ushort GetDefeatMarksCountOutOfCombat = 91;

		public const ushort ApplyCombatResultDataEffect = 92;

		public const ushort ClearReserveNormalAttack = 93;

		public const ushort ApplyVitalOnTeammate = 94;

		public const ushort RevertVitalOnTeammate = 95;

		public const ushort GmCmd_ForceRecoverTeammateCommand = 96;

		public const ushort RequestValidItemsInCombat = 97;

		public const ushort RequestSwordFragmentSkillIds = 98;

		public const ushort UseSpecialItem = 99;

		public const ushort NormalAttackImmediate = 100;

		public const ushort InterruptOtherActionManual = 101;

		public const ushort PrepareSimulate = 102;

		public const ushort PreparePreRandomTeammateCommands = 103;

		public const ushort GmCmd_FightNpc = 104;

		public const ushort SetCombatQuickUseItemSlotData = 105;

		public const ushort GetCombatQuickUseItemSlotData = 106;

		public const ushort GmCmd_FightBossInternal = 107;

		public const ushort ChangeTaiwuWeaponInnerRatioByWeaponKey = 108;

		public const ushort GetWeaponExpectInnerRatio = 109;

		public const ushort GetMarkDisplayData = 110;

		public const ushort GmCmd_FightTwelveImmortals = 111;

		public const ushort InvokeChickenPoints = 112;

		public const ushort FinishChickenPhase = 113;

		public const ushort ApplyChickenEffect = 114;
	}

	public const ushort DataCount = 44;

	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "TimeScale", 0 },
		{ "AutoCombat", 1 },
		{ "CombatFrame", 2 },
		{ "CombatType", 3 },
		{ "CurrentDistance", 4 },
		{ "DamageCompareData", 5 },
		{ "SkillPowerAddInCombat", 6 },
		{ "SkillPowerReduceInCombat", 7 },
		{ "SkillPowerReplaceInCombat", 8 },
		{ "BgmIndex", 9 },
		{ "CombatCharacterDict", 10 },
		{ "SelfTeam", 11 },
		{ "SelfCharId", 12 },
		{ "SelfTeamWisdomType", 13 },
		{ "SelfTeamWisdomCount", 14 },
		{ "EnemyTeam", 15 },
		{ "EnemyCharId", 16 },
		{ "EnemyTeamWisdomType", 17 },
		{ "EnemyTeamWisdomCount", 18 },
		{ "CombatStatus", 19 },
		{ "ShowMercyOption", 20 },
		{ "SelectedMercyOption", 21 },
		{ "CarrierAnimalCombatCharId", 22 },
		{ "SpecialShowCombatCharId", 23 },
		{ "NotUsed", 24 },
		{ "WaitingDelaySettlement", 25 },
		{ "ShowUseGoldenWire", 26 },
		{ "IsPuppetCombat", 27 },
		{ "IsPlaygroundCombat", 28 },
		{ "SkillDataDict", 29 },
		{ "WeaponDataDict", 30 },
		{ "ExpectRatioData", 31 },
		{ "TaiwuSpecialGroupCharIds", 32 },
		{ "LastTargetDistance", 33 },
		{ "ChangeTrickIndex", 34 },
		{ "ChangeTrickBodyPart", 35 },
		{ "ChangeTrickIsFlaw", 36 },
		{ "EnemyUnyieldingFallen", 37 },
		{ "DisableEnemyAi", 38 },
		{ "PreferWeaponIndex", 39 },
		{ "CombatQuickUseItemSlotDataList", 40 },
		{ "SkillDamageData", 41 },
		{ "NextAvailableChickenPointAppearCd", 42 },
		{ "ChickenPointZones", 43 }
	};

	public static readonly string[] DataId2FieldName = new string[44]
	{
		"TimeScale", "AutoCombat", "CombatFrame", "CombatType", "CurrentDistance", "DamageCompareData", "SkillPowerAddInCombat", "SkillPowerReduceInCombat", "SkillPowerReplaceInCombat", "BgmIndex",
		"CombatCharacterDict", "SelfTeam", "SelfCharId", "SelfTeamWisdomType", "SelfTeamWisdomCount", "EnemyTeam", "EnemyCharId", "EnemyTeamWisdomType", "EnemyTeamWisdomCount", "CombatStatus",
		"ShowMercyOption", "SelectedMercyOption", "CarrierAnimalCombatCharId", "SpecialShowCombatCharId", "NotUsed", "WaitingDelaySettlement", "ShowUseGoldenWire", "IsPuppetCombat", "IsPlaygroundCombat", "SkillDataDict",
		"WeaponDataDict", "ExpectRatioData", "TaiwuSpecialGroupCharIds", "LastTargetDistance", "ChangeTrickIndex", "ChangeTrickBodyPart", "ChangeTrickIsFlaw", "EnemyUnyieldingFallen", "DisableEnemyAi", "PreferWeaponIndex",
		"CombatQuickUseItemSlotDataList", "SkillDamageData", "NextAvailableChickenPointAppearCd", "ChickenPointZones"
	};

	public static readonly string[][] DataId2ObjectFieldId2FieldName;

	public static readonly Dictionary<string, ushort> MethodName2MethodId;

	public static readonly string[] MethodId2MethodName;

	static CombatDomainHelper()
	{
		string[][] array = new string[44][];
		array[10] = CombatCharacterHelper.FieldId2FieldName;
		array[29] = CombatSkillDataHelper.FieldId2FieldName;
		array[30] = CombatWeaponDataHelper.FieldId2FieldName;
		DataId2ObjectFieldId2FieldName = array;
		MethodName2MethodId = new Dictionary<string, ushort>
		{
			{ "PlayMoveStepSound", 0 },
			{ "ExecuteTeammateCommand", 1 },
			{ "GetCombatCharDisplayData", 2 },
			{ "SelectMercyOption", 3 },
			{ "ChangeWeapon", 4 },
			{ "NormalAttack", 5 },
			{ "StartChangeTrick", 6 },
			{ "SelectChangeTrick", 7 },
			{ "ChangeTaiwuWeaponInnerRatio", 8 },
			{ "GetWeaponInnerRatio", 9 },
			{ "StartPrepareOtherAction", 10 },
			{ "GetProactiveSkillList", 11 },
			{ "StartPrepareSkill", 12 },
			{ "GmCmd_ForceRecoverBreathAndStance", 13 },
			{ "GmCmd_AddTrick", 14 },
			{ "GmCmd_AddInjury", 15 },
			{ "GmCmd_ForceHealAllInjury", 16 },
			{ "GmCmd_AddPoison", 17 },
			{ "GmCmd_ForceHealAllPoison", 18 },
			{ "GmCmd_ForceEnemyUseSkill", 19 },
			{ "GmCmd_ForceEnemyUseOtherAction", 20 },
			{ "GmCmd_ForceEnemyDefeat", 21 },
			{ "GmCmd_ForceSelfDefeat", 22 },
			{ "GmCmd_SetNeiliAllocation", 23 },
			{ "GmCmd_AddFlaw", 24 },
			{ "GmCmd_HealAllFlaw", 25 },
			{ "GmCmd_AddAcupoint", 26 },
			{ "GmCmd_HealAllAcupoint", 27 },
			{ "GmCmd_FightBoss", 28 },
			{ "GmCmd_FightAnimal", 29 },
			{ "GmCmd_EnableEnemyAi", 30 },
			{ "GmCmd_EnableSkillFreeCast", 31 },
			{ "GetHealInjuryBanReason", 32 },
			{ "GetHealPoisonBanReason", 33 },
			{ "UseItem", 34 },
			{ "PrepareCombat", 35 },
			{ "StartCombat", 36 },
			{ "SetTimeScale", 37 },
			{ "SetPlayerAutoCombat", 38 },
			{ "SetAiOptions", 39 },
			{ "SetMoveState", 40 },
			{ "GetCombatResultDisplayData", 41 },
			{ "SelectGetItem", 42 },
			{ "Surrender", 43 },
			{ "EnterBossPuppetCombat", 44 },
			{ "RepairItem", 45 },
			{ "PrepareEnemyEquipments", 46 },
			{ "EnableBulletTime", 47 },
			{ "GmCmd_SetImmortal", 48 },
			{ "CancelChangeTrick", 49 },
			{ "ClearAllReserveAction", 50 },
			{ "IsInCombat", 51 },
			{ "GmCmd_FightTestOrgMember", 52 },
			{ "GmCmd_FightRandomEnemy", 53 },
			{ "GmCmd_ForceRecoverMobilityValue", 54 },
			{ "GmCmd_UnitTestSetDistanceToTarget", 55 },
			{ "GmCmd_UnitTestEquipSkill", 56 },
			{ "GmCmd_UnitTestPrepare", 57 },
			{ "GmCmd_UnitTestClearAllEquipSkill", 58 },
			{ "GetFatalDamageStepDisplayData", 59 },
			{ "GetMindDamageStepDisplayData", 60 },
			{ "GetBodyPartDamageStepDisplayData", 61 },
			{ "GetCompleteDamageStepDisplayData", 62 },
			{ "GmCmd_ForceRecoverWugCount", 63 },
			{ "GmCmd_FightCharacter", 64 },
			{ "GetChangeTrickDisplayData", 65 },
			{ "ClearAffectingDefenseSkillManual", 66 },
			{ "ClearDefendInBlockAttackSkill", 67 },
			{ "GmCmd_HealAllFatal", 68 },
			{ "GmCmd_HealAllDefeatMark", 69 },
			{ "GmCmd_AddAllDefeatMark", 70 },
			{ "GmCmd_AddFatal", 71 },
			{ "GmCmd_HealAllDie", 72 },
			{ "GmCmd_AddDie", 73 },
			{ "GmCmd_HealAllMind", 74 },
			{ "GmCmd_HealInjury", 75 },
			{ "GmCmd_AddMind", 76 },
			{ "SetTargetDistance", 77 },
			{ "ClearTargetDistance", 78 },
			{ "SetJumpThreshold", 79 },
			{ "GetPreviewAttackRange", 80 },
			{ "SetPuppetUnyieldingFallen", 81 },
			{ "SetPuppetDisableAi", 82 },
			{ "InterruptSkillManual", 83 },
			{ "ClearAffectingMoveSkillManual", 84 },
			{ "UnlockAttack", 85 },
			{ "IgnoreAllRawCreate", 86 },
			{ "IgnoreRawCreate", 87 },
			{ "DoRawCreate", 88 },
			{ "GetAllCanRawCreateEquipmentSlots", 89 },
			{ "GetUnlockSimulateResult", 90 },
			{ "GetDefeatMarksCountOutOfCombat", 91 },
			{ "ApplyCombatResultDataEffect", 92 },
			{ "ClearReserveNormalAttack", 93 },
			{ "ApplyVitalOnTeammate", 94 },
			{ "RevertVitalOnTeammate", 95 },
			{ "GmCmd_ForceRecoverTeammateCommand", 96 },
			{ "RequestValidItemsInCombat", 97 },
			{ "RequestSwordFragmentSkillIds", 98 },
			{ "UseSpecialItem", 99 },
			{ "NormalAttackImmediate", 100 },
			{ "InterruptOtherActionManual", 101 },
			{ "PrepareSimulate", 102 },
			{ "PreparePreRandomTeammateCommands", 103 },
			{ "GmCmd_FightNpc", 104 },
			{ "SetCombatQuickUseItemSlotData", 105 },
			{ "GetCombatQuickUseItemSlotData", 106 },
			{ "GmCmd_FightBossInternal", 107 },
			{ "ChangeTaiwuWeaponInnerRatioByWeaponKey", 108 },
			{ "GetWeaponExpectInnerRatio", 109 },
			{ "GetMarkDisplayData", 110 },
			{ "GmCmd_FightTwelveImmortals", 111 },
			{ "InvokeChickenPoints", 112 },
			{ "FinishChickenPhase", 113 },
			{ "ApplyChickenEffect", 114 }
		};
		MethodId2MethodName = new string[115]
		{
			"PlayMoveStepSound", "ExecuteTeammateCommand", "GetCombatCharDisplayData", "SelectMercyOption", "ChangeWeapon", "NormalAttack", "StartChangeTrick", "SelectChangeTrick", "ChangeTaiwuWeaponInnerRatio", "GetWeaponInnerRatio",
			"StartPrepareOtherAction", "GetProactiveSkillList", "StartPrepareSkill", "GmCmd_ForceRecoverBreathAndStance", "GmCmd_AddTrick", "GmCmd_AddInjury", "GmCmd_ForceHealAllInjury", "GmCmd_AddPoison", "GmCmd_ForceHealAllPoison", "GmCmd_ForceEnemyUseSkill",
			"GmCmd_ForceEnemyUseOtherAction", "GmCmd_ForceEnemyDefeat", "GmCmd_ForceSelfDefeat", "GmCmd_SetNeiliAllocation", "GmCmd_AddFlaw", "GmCmd_HealAllFlaw", "GmCmd_AddAcupoint", "GmCmd_HealAllAcupoint", "GmCmd_FightBoss", "GmCmd_FightAnimal",
			"GmCmd_EnableEnemyAi", "GmCmd_EnableSkillFreeCast", "GetHealInjuryBanReason", "GetHealPoisonBanReason", "UseItem", "PrepareCombat", "StartCombat", "SetTimeScale", "SetPlayerAutoCombat", "SetAiOptions",
			"SetMoveState", "GetCombatResultDisplayData", "SelectGetItem", "Surrender", "EnterBossPuppetCombat", "RepairItem", "PrepareEnemyEquipments", "EnableBulletTime", "GmCmd_SetImmortal", "CancelChangeTrick",
			"ClearAllReserveAction", "IsInCombat", "GmCmd_FightTestOrgMember", "GmCmd_FightRandomEnemy", "GmCmd_ForceRecoverMobilityValue", "GmCmd_UnitTestSetDistanceToTarget", "GmCmd_UnitTestEquipSkill", "GmCmd_UnitTestPrepare", "GmCmd_UnitTestClearAllEquipSkill", "GetFatalDamageStepDisplayData",
			"GetMindDamageStepDisplayData", "GetBodyPartDamageStepDisplayData", "GetCompleteDamageStepDisplayData", "GmCmd_ForceRecoverWugCount", "GmCmd_FightCharacter", "GetChangeTrickDisplayData", "ClearAffectingDefenseSkillManual", "ClearDefendInBlockAttackSkill", "GmCmd_HealAllFatal", "GmCmd_HealAllDefeatMark",
			"GmCmd_AddAllDefeatMark", "GmCmd_AddFatal", "GmCmd_HealAllDie", "GmCmd_AddDie", "GmCmd_HealAllMind", "GmCmd_HealInjury", "GmCmd_AddMind", "SetTargetDistance", "ClearTargetDistance", "SetJumpThreshold",
			"GetPreviewAttackRange", "SetPuppetUnyieldingFallen", "SetPuppetDisableAi", "InterruptSkillManual", "ClearAffectingMoveSkillManual", "UnlockAttack", "IgnoreAllRawCreate", "IgnoreRawCreate", "DoRawCreate", "GetAllCanRawCreateEquipmentSlots",
			"GetUnlockSimulateResult", "GetDefeatMarksCountOutOfCombat", "ApplyCombatResultDataEffect", "ClearReserveNormalAttack", "ApplyVitalOnTeammate", "RevertVitalOnTeammate", "GmCmd_ForceRecoverTeammateCommand", "RequestValidItemsInCombat", "RequestSwordFragmentSkillIds", "UseSpecialItem",
			"NormalAttackImmediate", "InterruptOtherActionManual", "PrepareSimulate", "PreparePreRandomTeammateCommands", "GmCmd_FightNpc", "SetCombatQuickUseItemSlotData", "GetCombatQuickUseItemSlotData", "GmCmd_FightBossInternal", "ChangeTaiwuWeaponInnerRatioByWeaponKey", "GetWeaponExpectInnerRatio",
			"GetMarkDisplayData", "GmCmd_FightTwelveImmortals", "InvokeChickenPoints", "FinishChickenPhase", "ApplyChickenEffect"
		};
	}
}
