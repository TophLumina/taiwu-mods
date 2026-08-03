using System.Collections.Generic;

namespace GameData.Domains.Combat;

public static class CombatDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
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
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
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

		public const ushort GetWeaponEffects = 10;

		public const ushort StartPrepareOtherAction = 11;

		public const ushort GetProactiveSkillList = 12;

		public const ushort StartPrepareSkill = 13;

		public const ushort GmCmd_ForceRecoverBreathAndStance = 14;

		public const ushort GmCmd_AddTrick = 15;

		public const ushort GmCmd_AddInjury = 16;

		public const ushort GmCmd_ForceHealAllInjury = 17;

		public const ushort GmCmd_AddPoison = 18;

		public const ushort GmCmd_ForceHealAllPoison = 19;

		public const ushort GmCmd_ForceEnemyUseSkill = 20;

		public const ushort GmCmd_ForceEnemyUseOtherAction = 21;

		public const ushort GmCmd_ForceEnemyDefeat = 22;

		public const ushort GmCmd_ForceSelfDefeat = 23;

		public const ushort GmCmd_SetNeiliAllocation = 24;

		public const ushort GmCmd_AddFlaw = 25;

		public const ushort GmCmd_HealAllFlaw = 26;

		public const ushort GmCmd_AddAcupoint = 27;

		public const ushort GmCmd_HealAllAcupoint = 28;

		public const ushort GmCmd_FightBoss = 29;

		public const ushort GmCmd_FightAnimal = 30;

		public const ushort GmCmd_EnableEnemyAi = 31;

		public const ushort GmCmd_EnableSkillFreeCast = 32;

		public const ushort GetHealInjuryBanReason = 33;

		public const ushort GetHealPoisonBanReason = 34;

		public const ushort UseItem = 35;

		public const ushort PrepareCombat = 36;

		public const ushort StartCombat = 37;

		public const ushort SetTimeScale = 38;

		public const ushort SetPlayerAutoCombat = 39;

		public const ushort SetAiOptions = 40;

		public const ushort SetMoveState = 41;

		public const ushort GetCombatResultDisplayData = 42;

		public const ushort SelectGetItem = 43;

		public const ushort Surrender = 44;

		public const ushort EnterBossPuppetCombat = 45;

		public const ushort RepairItem = 46;

		public const ushort PrepareEnemyEquipments = 47;

		public const ushort EnableBulletTime = 48;

		public const ushort GmCmd_SetImmortal = 49;

		public const ushort CancelChangeTrick = 50;

		public const ushort ClearAllReserveAction = 51;

		public const ushort IsInCombat = 52;

		public const ushort GmCmd_FightTestOrgMember = 53;

		public const ushort GmCmd_FightRandomEnemy = 54;

		public const ushort GmCmd_ForceRecoverMobilityValue = 55;

		public const ushort GmCmd_UnitTestSetDistanceToTarget = 56;

		public const ushort GmCmd_UnitTestEquipSkill = 57;

		public const ushort GmCmd_UnitTestPrepare = 58;

		public const ushort GmCmd_UnitTestClearAllEquipSkill = 59;

		public const ushort GetFatalDamageStepDisplayData = 60;

		public const ushort GetMindDamageStepDisplayData = 61;

		public const ushort GetBodyPartDamageStepDisplayData = 62;

		public const ushort GetCompleteDamageStepDisplayData = 63;

		public const ushort GmCmd_ForceRecoverWugCount = 64;

		public const ushort GmCmd_FightCharacter = 65;

		public const ushort GetChangeTrickDisplayData = 66;

		public const ushort ClearAffectingDefenseSkillManual = 67;

		public const ushort ClearDefendInBlockAttackSkill = 68;

		public const ushort GmCmd_HealAllFatal = 69;

		public const ushort GmCmd_HealAllDefeatMark = 70;

		public const ushort GmCmd_AddAllDefeatMark = 71;

		public const ushort GmCmd_AddFatal = 72;

		public const ushort GmCmd_HealAllDie = 73;

		public const ushort GmCmd_AddDie = 74;

		public const ushort GmCmd_HealAllMind = 75;

		public const ushort GmCmd_HealInjury = 76;

		public const ushort GmCmd_AddMind = 77;

		public const ushort SetTargetDistance = 78;

		public const ushort ClearTargetDistance = 79;

		public const ushort SetJumpThreshold = 80;

		public const ushort GetPreviewAttackRange = 81;

		public const ushort SetPuppetUnyieldingFallen = 82;

		public const ushort SetPuppetDisableAi = 83;

		public const ushort InterruptSkillManual = 84;

		public const ushort ClearAffectingMoveSkillManual = 85;

		public const ushort UnlockAttack = 86;

		public const ushort IgnoreAllRawCreate = 87;

		public const ushort IgnoreRawCreate = 88;

		public const ushort DoRawCreate = 89;

		public const ushort GetAllCanRawCreateEquipmentSlots = 90;

		public const ushort GetUnlockSimulateResult = 91;

		public const ushort GetDefeatMarksCountOutOfCombat = 92;

		public const ushort ApplyCombatResultDataEffect = 93;

		public const ushort ClearReserveNormalAttack = 94;

		public const ushort ApplyVitalOnTeammate = 95;

		public const ushort RevertVitalOnTeammate = 96;

		public const ushort GmCmd_ForceRecoverTeammateCommand = 97;

		public const ushort RequestValidItemsInCombat = 98;

		public const ushort RequestSwordFragmentSkillIds = 99;

		public const ushort UseSpecialItem = 100;

		public const ushort NormalAttackImmediate = 101;

		public const ushort InterruptOtherActionManual = 102;

		public const ushort PrepareSimulate = 103;

		public const ushort PreparePreRandomTeammateCommands = 104;

		public const ushort GmCmd_FightNpc = 105;

		public const ushort SetCombatQuickUseItemSlotData = 106;

		public const ushort GetCombatQuickUseItemSlotData = 107;

		public const ushort GmCmd_FightBossInternal = 108;

		public const ushort ChangeTaiwuWeaponInnerRatioByWeaponKey = 109;

		public const ushort GetWeaponExpectInnerRatio = 110;

		public const ushort GetMarkDisplayData = 111;

		public const ushort GmCmd_FightTwelveImmortals = 112;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 42;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
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
		{ "SkillDamageData", 41 }
	};

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[42]
	{
		"TimeScale", "AutoCombat", "CombatFrame", "CombatType", "CurrentDistance", "DamageCompareData", "SkillPowerAddInCombat", "SkillPowerReduceInCombat", "SkillPowerReplaceInCombat", "BgmIndex",
		"CombatCharacterDict", "SelfTeam", "SelfCharId", "SelfTeamWisdomType", "SelfTeamWisdomCount", "EnemyTeam", "EnemyCharId", "EnemyTeamWisdomType", "EnemyTeamWisdomCount", "CombatStatus",
		"ShowMercyOption", "SelectedMercyOption", "CarrierAnimalCombatCharId", "SpecialShowCombatCharId", "NotUsed", "WaitingDelaySettlement", "ShowUseGoldenWire", "IsPuppetCombat", "IsPlaygroundCombat", "SkillDataDict",
		"WeaponDataDict", "ExpectRatioData", "TaiwuSpecialGroupCharIds", "LastTargetDistance", "ChangeTrickIndex", "ChangeTrickBodyPart", "ChangeTrickIsFlaw", "EnemyUnyieldingFallen", "DisableEnemyAi", "PreferWeaponIndex",
		"CombatQuickUseItemSlotDataList", "SkillDamageData"
	};

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName;

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId;

	public static readonly string[] MethodId2MethodName;

	static CombatDomainHelper()
	{
		string[][] array = new string[42][];
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
			{ "GetWeaponEffects", 10 },
			{ "StartPrepareOtherAction", 11 },
			{ "GetProactiveSkillList", 12 },
			{ "StartPrepareSkill", 13 },
			{ "GmCmd_ForceRecoverBreathAndStance", 14 },
			{ "GmCmd_AddTrick", 15 },
			{ "GmCmd_AddInjury", 16 },
			{ "GmCmd_ForceHealAllInjury", 17 },
			{ "GmCmd_AddPoison", 18 },
			{ "GmCmd_ForceHealAllPoison", 19 },
			{ "GmCmd_ForceEnemyUseSkill", 20 },
			{ "GmCmd_ForceEnemyUseOtherAction", 21 },
			{ "GmCmd_ForceEnemyDefeat", 22 },
			{ "GmCmd_ForceSelfDefeat", 23 },
			{ "GmCmd_SetNeiliAllocation", 24 },
			{ "GmCmd_AddFlaw", 25 },
			{ "GmCmd_HealAllFlaw", 26 },
			{ "GmCmd_AddAcupoint", 27 },
			{ "GmCmd_HealAllAcupoint", 28 },
			{ "GmCmd_FightBoss", 29 },
			{ "GmCmd_FightAnimal", 30 },
			{ "GmCmd_EnableEnemyAi", 31 },
			{ "GmCmd_EnableSkillFreeCast", 32 },
			{ "GetHealInjuryBanReason", 33 },
			{ "GetHealPoisonBanReason", 34 },
			{ "UseItem", 35 },
			{ "PrepareCombat", 36 },
			{ "StartCombat", 37 },
			{ "SetTimeScale", 38 },
			{ "SetPlayerAutoCombat", 39 },
			{ "SetAiOptions", 40 },
			{ "SetMoveState", 41 },
			{ "GetCombatResultDisplayData", 42 },
			{ "SelectGetItem", 43 },
			{ "Surrender", 44 },
			{ "EnterBossPuppetCombat", 45 },
			{ "RepairItem", 46 },
			{ "PrepareEnemyEquipments", 47 },
			{ "EnableBulletTime", 48 },
			{ "GmCmd_SetImmortal", 49 },
			{ "CancelChangeTrick", 50 },
			{ "ClearAllReserveAction", 51 },
			{ "IsInCombat", 52 },
			{ "GmCmd_FightTestOrgMember", 53 },
			{ "GmCmd_FightRandomEnemy", 54 },
			{ "GmCmd_ForceRecoverMobilityValue", 55 },
			{ "GmCmd_UnitTestSetDistanceToTarget", 56 },
			{ "GmCmd_UnitTestEquipSkill", 57 },
			{ "GmCmd_UnitTestPrepare", 58 },
			{ "GmCmd_UnitTestClearAllEquipSkill", 59 },
			{ "GetFatalDamageStepDisplayData", 60 },
			{ "GetMindDamageStepDisplayData", 61 },
			{ "GetBodyPartDamageStepDisplayData", 62 },
			{ "GetCompleteDamageStepDisplayData", 63 },
			{ "GmCmd_ForceRecoverWugCount", 64 },
			{ "GmCmd_FightCharacter", 65 },
			{ "GetChangeTrickDisplayData", 66 },
			{ "ClearAffectingDefenseSkillManual", 67 },
			{ "ClearDefendInBlockAttackSkill", 68 },
			{ "GmCmd_HealAllFatal", 69 },
			{ "GmCmd_HealAllDefeatMark", 70 },
			{ "GmCmd_AddAllDefeatMark", 71 },
			{ "GmCmd_AddFatal", 72 },
			{ "GmCmd_HealAllDie", 73 },
			{ "GmCmd_AddDie", 74 },
			{ "GmCmd_HealAllMind", 75 },
			{ "GmCmd_HealInjury", 76 },
			{ "GmCmd_AddMind", 77 },
			{ "SetTargetDistance", 78 },
			{ "ClearTargetDistance", 79 },
			{ "SetJumpThreshold", 80 },
			{ "GetPreviewAttackRange", 81 },
			{ "SetPuppetUnyieldingFallen", 82 },
			{ "SetPuppetDisableAi", 83 },
			{ "InterruptSkillManual", 84 },
			{ "ClearAffectingMoveSkillManual", 85 },
			{ "UnlockAttack", 86 },
			{ "IgnoreAllRawCreate", 87 },
			{ "IgnoreRawCreate", 88 },
			{ "DoRawCreate", 89 },
			{ "GetAllCanRawCreateEquipmentSlots", 90 },
			{ "GetUnlockSimulateResult", 91 },
			{ "GetDefeatMarksCountOutOfCombat", 92 },
			{ "ApplyCombatResultDataEffect", 93 },
			{ "ClearReserveNormalAttack", 94 },
			{ "ApplyVitalOnTeammate", 95 },
			{ "RevertVitalOnTeammate", 96 },
			{ "GmCmd_ForceRecoverTeammateCommand", 97 },
			{ "RequestValidItemsInCombat", 98 },
			{ "RequestSwordFragmentSkillIds", 99 },
			{ "UseSpecialItem", 100 },
			{ "NormalAttackImmediate", 101 },
			{ "InterruptOtherActionManual", 102 },
			{ "PrepareSimulate", 103 },
			{ "PreparePreRandomTeammateCommands", 104 },
			{ "GmCmd_FightNpc", 105 },
			{ "SetCombatQuickUseItemSlotData", 106 },
			{ "GetCombatQuickUseItemSlotData", 107 },
			{ "GmCmd_FightBossInternal", 108 },
			{ "ChangeTaiwuWeaponInnerRatioByWeaponKey", 109 },
			{ "GetWeaponExpectInnerRatio", 110 },
			{ "GetMarkDisplayData", 111 },
			{ "GmCmd_FightTwelveImmortals", 112 }
		};
		MethodId2MethodName = new string[113]
		{
			"PlayMoveStepSound", "ExecuteTeammateCommand", "GetCombatCharDisplayData", "SelectMercyOption", "ChangeWeapon", "NormalAttack", "StartChangeTrick", "SelectChangeTrick", "ChangeTaiwuWeaponInnerRatio", "GetWeaponInnerRatio",
			"GetWeaponEffects", "StartPrepareOtherAction", "GetProactiveSkillList", "StartPrepareSkill", "GmCmd_ForceRecoverBreathAndStance", "GmCmd_AddTrick", "GmCmd_AddInjury", "GmCmd_ForceHealAllInjury", "GmCmd_AddPoison", "GmCmd_ForceHealAllPoison",
			"GmCmd_ForceEnemyUseSkill", "GmCmd_ForceEnemyUseOtherAction", "GmCmd_ForceEnemyDefeat", "GmCmd_ForceSelfDefeat", "GmCmd_SetNeiliAllocation", "GmCmd_AddFlaw", "GmCmd_HealAllFlaw", "GmCmd_AddAcupoint", "GmCmd_HealAllAcupoint", "GmCmd_FightBoss",
			"GmCmd_FightAnimal", "GmCmd_EnableEnemyAi", "GmCmd_EnableSkillFreeCast", "GetHealInjuryBanReason", "GetHealPoisonBanReason", "UseItem", "PrepareCombat", "StartCombat", "SetTimeScale", "SetPlayerAutoCombat",
			"SetAiOptions", "SetMoveState", "GetCombatResultDisplayData", "SelectGetItem", "Surrender", "EnterBossPuppetCombat", "RepairItem", "PrepareEnemyEquipments", "EnableBulletTime", "GmCmd_SetImmortal",
			"CancelChangeTrick", "ClearAllReserveAction", "IsInCombat", "GmCmd_FightTestOrgMember", "GmCmd_FightRandomEnemy", "GmCmd_ForceRecoverMobilityValue", "GmCmd_UnitTestSetDistanceToTarget", "GmCmd_UnitTestEquipSkill", "GmCmd_UnitTestPrepare", "GmCmd_UnitTestClearAllEquipSkill",
			"GetFatalDamageStepDisplayData", "GetMindDamageStepDisplayData", "GetBodyPartDamageStepDisplayData", "GetCompleteDamageStepDisplayData", "GmCmd_ForceRecoverWugCount", "GmCmd_FightCharacter", "GetChangeTrickDisplayData", "ClearAffectingDefenseSkillManual", "ClearDefendInBlockAttackSkill", "GmCmd_HealAllFatal",
			"GmCmd_HealAllDefeatMark", "GmCmd_AddAllDefeatMark", "GmCmd_AddFatal", "GmCmd_HealAllDie", "GmCmd_AddDie", "GmCmd_HealAllMind", "GmCmd_HealInjury", "GmCmd_AddMind", "SetTargetDistance", "ClearTargetDistance",
			"SetJumpThreshold", "GetPreviewAttackRange", "SetPuppetUnyieldingFallen", "SetPuppetDisableAi", "InterruptSkillManual", "ClearAffectingMoveSkillManual", "UnlockAttack", "IgnoreAllRawCreate", "IgnoreRawCreate", "DoRawCreate",
			"GetAllCanRawCreateEquipmentSlots", "GetUnlockSimulateResult", "GetDefeatMarksCountOutOfCombat", "ApplyCombatResultDataEffect", "ClearReserveNormalAttack", "ApplyVitalOnTeammate", "RevertVitalOnTeammate", "GmCmd_ForceRecoverTeammateCommand", "RequestValidItemsInCombat", "RequestSwordFragmentSkillIds",
			"UseSpecialItem", "NormalAttackImmediate", "InterruptOtherActionManual", "PrepareSimulate", "PreparePreRandomTeammateCommands", "GmCmd_FightNpc", "SetCombatQuickUseItemSlotData", "GetCombatQuickUseItemSlotData", "GmCmd_FightBossInternal", "ChangeTaiwuWeaponInnerRatioByWeaponKey",
			"GetWeaponExpectInnerRatio", "GetMarkDisplayData", "GmCmd_FightTwelveImmortals"
		};
	}
}
