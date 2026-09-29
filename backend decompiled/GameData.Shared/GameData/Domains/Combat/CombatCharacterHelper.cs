using System.Collections.Generic;

namespace GameData.Domains.Combat;

public static class CombatCharacterHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort BreathValue = 1;

		public const ushort StanceValue = 2;

		public const ushort NeiliAllocation = 3;

		public const ushort OriginNeiliAllocation = 4;

		public const ushort NeiliAllocationRecoverProgress = 5;

		public const ushort OldDisorderOfQi = 6;

		public const ushort NeiliType = 7;

		public const ushort AvoidToShow = 8;

		public const ushort CurrentPosition = 9;

		public const ushort DisplayPosition = 10;

		public const ushort MobilityValue = 11;

		public const ushort JumpPrepareProgress = 12;

		public const ushort JumpPreparedDistance = 13;

		public const ushort MobilityLockEffectCount = 14;

		public const ushort JumpChangeDistanceDuration = 15;

		public const ushort UsingWeaponIndex = 16;

		public const ushort WeaponTricks = 17;

		public const ushort WeaponTrickIndex = 18;

		public const ushort Weapons = 19;

		public const ushort AttackingTrickType = 20;

		public const ushort CanAttackOutRange = 21;

		public const ushort ChangeTrickProgress = 22;

		public const ushort ChangeTrickCount = 23;

		public const ushort CanChangeTrick = 24;

		public const ushort ChangingTrick = 25;

		public const ushort ChangeTrickAttack = 26;

		public const ushort IsFightBack = 27;

		public const ushort Tricks = 28;

		public const ushort Injuries = 29;

		public const ushort OldInjuries = 30;

		public const ushort InjuryAutoHealCollection = 31;

		public const ushort DamageStepCollection = 32;

		public const ushort OuterDamageValue = 33;

		public const ushort InnerDamageValue = 34;

		public const ushort MindDamageValue = 35;

		public const ushort FatalDamageValue = 36;

		public const ushort OuterDamageValueToShow = 37;

		public const ushort InnerDamageValueToShow = 38;

		public const ushort MindDamageValueToShow = 39;

		public const ushort FatalDamageValueToShow = 40;

		public const ushort FlawCount = 41;

		public const ushort FlawCollection = 42;

		public const ushort AcupointCount = 43;

		public const ushort AcupointCollection = 44;

		public const ushort MindMarkTime = 45;

		public const ushort Poison = 46;

		public const ushort OldPoison = 47;

		public const ushort PoisonResist = 48;

		public const ushort NewPoisonsToShow = 49;

		public const ushort DefeatMarkCollection = 50;

		public const ushort NeigongList = 51;

		public const ushort AttackSkillList = 52;

		public const ushort AgileSkillList = 53;

		public const ushort DefenceSkillList = 54;

		public const ushort AssistSkillList = 55;

		public const ushort PreparingSkillId = 56;

		public const ushort SkillPreparePercent = 57;

		public const ushort PerformingSkillId = 58;

		public const ushort AutoCastingSkill = 59;

		public const ushort AttackSkillAttackIndex = 60;

		public const ushort AttackSkillPower = 61;

		public const ushort AffectingMoveSkillId = 62;

		public const ushort AffectingDefendSkillId = 63;

		public const ushort DefendSkillTimePercent = 64;

		public const ushort WugCount = 65;

		public const ushort HealInjuryCount = 66;

		public const ushort HealPoisonCount = 67;

		public const ushort OtherActionCanUse = 68;

		public const ushort PreparingOtherAction = 69;

		public const ushort OtherActionPreparePercent = 70;

		public const ushort CanSurrender = 71;

		public const ushort CanUseItem = 72;

		public const ushort PreparingItem = 73;

		public const ushort UseItemPreparePercent = 74;

		public const ushort CombatReserveData = 75;

		public const ushort BuffCombatStateCollection = 76;

		public const ushort DebuffCombatStateCollection = 77;

		public const ushort SpecialCombatStateCollection = 78;

		public const ushort SkillEffectCollection = 79;

		public const ushort XiangshuEffectId = 80;

		public const ushort HazardValue = 81;

		public const ushort ShowEffectList = 82;

		public const ushort AnimationToLoop = 83;

		public const ushort AnimationToPlayOnce = 84;

		public const ushort ParticleToPlay = 85;

		public const ushort ParticleToLoop = 86;

		public const ushort SkillPetAnimation = 87;

		public const ushort PetParticle = 88;

		public const ushort AnimationTimeScale = 89;

		public const ushort AttackOutOfRange = 90;

		public const ushort AttackSoundToPlay = 91;

		public const ushort SkillSoundToPlay = 92;

		public const ushort HitSoundToPlay = 93;

		public const ushort ArmorHitSoundToPlay = 94;

		public const ushort WhooshSoundToPlay = 95;

		public const ushort ShockSoundToPlay = 96;

		public const ushort StepSoundToPlay = 97;

		public const ushort DieSoundToPlay = 98;

		public const ushort SoundToLoop = 99;

		public const ushort BossPhase = 100;

		public const ushort ShowTransferInjuryCommand = 101;

		public const ushort CurrTeammateCommands = 102;

		public const ushort ExecutingTeammateCommand = 103;

		public const ushort Visible = 104;

		public const ushort TeammateCommandPreparePercent = 105;

		public const ushort TeammateCommandTimePercent = 106;

		public const ushort AttackCommandWeaponKey = 107;

		public const ushort AttackCommandTrickType = 108;

		public const ushort DefendCommandSkillId = 109;

		public const ushort ShowEffectCommandIndex = 110;

		public const ushort AttackCommandSkillId = 111;

		public const ushort TeammateCommandBanReasons = 112;

		public const ushort TargetDistance = 113;

		public const ushort OldInjuryAutoHealCollection = 114;

		public const ushort MixPoisonAffectedCount = 115;

		public const ushort ParticleToLoopByCombatSkill = 116;

		public const ushort NeiliAllocationCd = 117;

		public const ushort ProportionDelta = 118;

		public const ushort ShowCommandList = 119;

		public const ushort UnlockPrepareValue = 120;

		public const ushort RawCreateEffects = 121;

		public const ushort RawCreateCollection = 122;

		public const ushort NormalAttackRecovery = 123;

		public const ushort ReserveNormalAttack = 124;

		public const ushort Gangqi = 125;

		public const ushort GangqiMax = 126;

		public const ushort MoveState = 127;

		public const ushort PlayerControllingMove = 128;

		public const ushort ScarMarkTime = 129;

		public const ushort MindRhythm = 130;

		public const ushort MindUpheavalTime = 131;

		public const ushort TeammateCommandCd = 132;

		public const ushort TeammateCommandCdSpeed = 133;

		public const ushort MaxTrickCount = 134;

		public const ushort MobilityLevel = 135;

		public const ushort TeammateCommandCanUse = 136;

		public const ushort ChangeDistanceDuration = 137;

		public const ushort AttackRange = 138;

		public const ushort Happiness = 139;

		public const ushort SilenceData = 140;

		public const ushort CombatStateTotalBuffPower = 141;

		public const ushort HeavyOrBreakInjuryData = 142;

		public const ushort MoveCd = 143;

		public const ushort MobilityRecoverSpeed = 144;

		public const ushort CanUnlockAttack = 145;

		public const ushort ValidItems = 146;

		public const ushort ValidItemAndCounts = 147;

		public const ushort UseItemCostNoWisdom = 148;

		public const ushort TeammateCommandBaseCdSpeed = 149;

		public const ushort PreparingOtherActionInterruptType = 150;

		public const ushort MixPoisonCanAffectCount = 151;
	}

	public const ushort ArchiveFieldsCount = 133;

	public const ushort CacheFieldsCount = 19;

	public const ushort PureTemplateFieldsCount = 0;

	public const ushort WritableFieldsCount = 152;

	public const ushort ReadonlyFieldsCount = 0;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "BreathValue", 1 },
		{ "StanceValue", 2 },
		{ "NeiliAllocation", 3 },
		{ "OriginNeiliAllocation", 4 },
		{ "NeiliAllocationRecoverProgress", 5 },
		{ "OldDisorderOfQi", 6 },
		{ "NeiliType", 7 },
		{ "AvoidToShow", 8 },
		{ "CurrentPosition", 9 },
		{ "DisplayPosition", 10 },
		{ "MobilityValue", 11 },
		{ "JumpPrepareProgress", 12 },
		{ "JumpPreparedDistance", 13 },
		{ "MobilityLockEffectCount", 14 },
		{ "JumpChangeDistanceDuration", 15 },
		{ "UsingWeaponIndex", 16 },
		{ "WeaponTricks", 17 },
		{ "WeaponTrickIndex", 18 },
		{ "Weapons", 19 },
		{ "AttackingTrickType", 20 },
		{ "CanAttackOutRange", 21 },
		{ "ChangeTrickProgress", 22 },
		{ "ChangeTrickCount", 23 },
		{ "CanChangeTrick", 24 },
		{ "ChangingTrick", 25 },
		{ "ChangeTrickAttack", 26 },
		{ "IsFightBack", 27 },
		{ "Tricks", 28 },
		{ "Injuries", 29 },
		{ "OldInjuries", 30 },
		{ "InjuryAutoHealCollection", 31 },
		{ "DamageStepCollection", 32 },
		{ "OuterDamageValue", 33 },
		{ "InnerDamageValue", 34 },
		{ "MindDamageValue", 35 },
		{ "FatalDamageValue", 36 },
		{ "OuterDamageValueToShow", 37 },
		{ "InnerDamageValueToShow", 38 },
		{ "MindDamageValueToShow", 39 },
		{ "FatalDamageValueToShow", 40 },
		{ "FlawCount", 41 },
		{ "FlawCollection", 42 },
		{ "AcupointCount", 43 },
		{ "AcupointCollection", 44 },
		{ "MindMarkTime", 45 },
		{ "Poison", 46 },
		{ "OldPoison", 47 },
		{ "PoisonResist", 48 },
		{ "NewPoisonsToShow", 49 },
		{ "DefeatMarkCollection", 50 },
		{ "NeigongList", 51 },
		{ "AttackSkillList", 52 },
		{ "AgileSkillList", 53 },
		{ "DefenceSkillList", 54 },
		{ "AssistSkillList", 55 },
		{ "PreparingSkillId", 56 },
		{ "SkillPreparePercent", 57 },
		{ "PerformingSkillId", 58 },
		{ "AutoCastingSkill", 59 },
		{ "AttackSkillAttackIndex", 60 },
		{ "AttackSkillPower", 61 },
		{ "AffectingMoveSkillId", 62 },
		{ "AffectingDefendSkillId", 63 },
		{ "DefendSkillTimePercent", 64 },
		{ "WugCount", 65 },
		{ "HealInjuryCount", 66 },
		{ "HealPoisonCount", 67 },
		{ "OtherActionCanUse", 68 },
		{ "PreparingOtherAction", 69 },
		{ "OtherActionPreparePercent", 70 },
		{ "CanSurrender", 71 },
		{ "CanUseItem", 72 },
		{ "PreparingItem", 73 },
		{ "UseItemPreparePercent", 74 },
		{ "CombatReserveData", 75 },
		{ "BuffCombatStateCollection", 76 },
		{ "DebuffCombatStateCollection", 77 },
		{ "SpecialCombatStateCollection", 78 },
		{ "SkillEffectCollection", 79 },
		{ "XiangshuEffectId", 80 },
		{ "HazardValue", 81 },
		{ "ShowEffectList", 82 },
		{ "AnimationToLoop", 83 },
		{ "AnimationToPlayOnce", 84 },
		{ "ParticleToPlay", 85 },
		{ "ParticleToLoop", 86 },
		{ "SkillPetAnimation", 87 },
		{ "PetParticle", 88 },
		{ "AnimationTimeScale", 89 },
		{ "AttackOutOfRange", 90 },
		{ "AttackSoundToPlay", 91 },
		{ "SkillSoundToPlay", 92 },
		{ "HitSoundToPlay", 93 },
		{ "ArmorHitSoundToPlay", 94 },
		{ "WhooshSoundToPlay", 95 },
		{ "ShockSoundToPlay", 96 },
		{ "StepSoundToPlay", 97 },
		{ "DieSoundToPlay", 98 },
		{ "SoundToLoop", 99 },
		{ "BossPhase", 100 },
		{ "ShowTransferInjuryCommand", 101 },
		{ "CurrTeammateCommands", 102 },
		{ "ExecutingTeammateCommand", 103 },
		{ "Visible", 104 },
		{ "TeammateCommandPreparePercent", 105 },
		{ "TeammateCommandTimePercent", 106 },
		{ "AttackCommandWeaponKey", 107 },
		{ "AttackCommandTrickType", 108 },
		{ "DefendCommandSkillId", 109 },
		{ "ShowEffectCommandIndex", 110 },
		{ "AttackCommandSkillId", 111 },
		{ "TeammateCommandBanReasons", 112 },
		{ "TargetDistance", 113 },
		{ "OldInjuryAutoHealCollection", 114 },
		{ "MixPoisonAffectedCount", 115 },
		{ "ParticleToLoopByCombatSkill", 116 },
		{ "NeiliAllocationCd", 117 },
		{ "ProportionDelta", 118 },
		{ "ShowCommandList", 119 },
		{ "UnlockPrepareValue", 120 },
		{ "RawCreateEffects", 121 },
		{ "RawCreateCollection", 122 },
		{ "NormalAttackRecovery", 123 },
		{ "ReserveNormalAttack", 124 },
		{ "Gangqi", 125 },
		{ "GangqiMax", 126 },
		{ "MoveState", 127 },
		{ "PlayerControllingMove", 128 },
		{ "ScarMarkTime", 129 },
		{ "MindRhythm", 130 },
		{ "MindUpheavalTime", 131 },
		{ "TeammateCommandCd", 132 },
		{ "TeammateCommandCdSpeed", 133 },
		{ "MaxTrickCount", 134 },
		{ "MobilityLevel", 135 },
		{ "TeammateCommandCanUse", 136 },
		{ "ChangeDistanceDuration", 137 },
		{ "AttackRange", 138 },
		{ "Happiness", 139 },
		{ "SilenceData", 140 },
		{ "CombatStateTotalBuffPower", 141 },
		{ "HeavyOrBreakInjuryData", 142 },
		{ "MoveCd", 143 },
		{ "MobilityRecoverSpeed", 144 },
		{ "CanUnlockAttack", 145 },
		{ "ValidItems", 146 },
		{ "ValidItemAndCounts", 147 },
		{ "UseItemCostNoWisdom", 148 },
		{ "TeammateCommandBaseCdSpeed", 149 },
		{ "PreparingOtherActionInterruptType", 150 },
		{ "MixPoisonCanAffectCount", 151 }
	};

	public static readonly string[] FieldId2FieldName = new string[152]
	{
		"Id", "BreathValue", "StanceValue", "NeiliAllocation", "OriginNeiliAllocation", "NeiliAllocationRecoverProgress", "OldDisorderOfQi", "NeiliType", "AvoidToShow", "CurrentPosition",
		"DisplayPosition", "MobilityValue", "JumpPrepareProgress", "JumpPreparedDistance", "MobilityLockEffectCount", "JumpChangeDistanceDuration", "UsingWeaponIndex", "WeaponTricks", "WeaponTrickIndex", "Weapons",
		"AttackingTrickType", "CanAttackOutRange", "ChangeTrickProgress", "ChangeTrickCount", "CanChangeTrick", "ChangingTrick", "ChangeTrickAttack", "IsFightBack", "Tricks", "Injuries",
		"OldInjuries", "InjuryAutoHealCollection", "DamageStepCollection", "OuterDamageValue", "InnerDamageValue", "MindDamageValue", "FatalDamageValue", "OuterDamageValueToShow", "InnerDamageValueToShow", "MindDamageValueToShow",
		"FatalDamageValueToShow", "FlawCount", "FlawCollection", "AcupointCount", "AcupointCollection", "MindMarkTime", "Poison", "OldPoison", "PoisonResist", "NewPoisonsToShow",
		"DefeatMarkCollection", "NeigongList", "AttackSkillList", "AgileSkillList", "DefenceSkillList", "AssistSkillList", "PreparingSkillId", "SkillPreparePercent", "PerformingSkillId", "AutoCastingSkill",
		"AttackSkillAttackIndex", "AttackSkillPower", "AffectingMoveSkillId", "AffectingDefendSkillId", "DefendSkillTimePercent", "WugCount", "HealInjuryCount", "HealPoisonCount", "OtherActionCanUse", "PreparingOtherAction",
		"OtherActionPreparePercent", "CanSurrender", "CanUseItem", "PreparingItem", "UseItemPreparePercent", "CombatReserveData", "BuffCombatStateCollection", "DebuffCombatStateCollection", "SpecialCombatStateCollection", "SkillEffectCollection",
		"XiangshuEffectId", "HazardValue", "ShowEffectList", "AnimationToLoop", "AnimationToPlayOnce", "ParticleToPlay", "ParticleToLoop", "SkillPetAnimation", "PetParticle", "AnimationTimeScale",
		"AttackOutOfRange", "AttackSoundToPlay", "SkillSoundToPlay", "HitSoundToPlay", "ArmorHitSoundToPlay", "WhooshSoundToPlay", "ShockSoundToPlay", "StepSoundToPlay", "DieSoundToPlay", "SoundToLoop",
		"BossPhase", "ShowTransferInjuryCommand", "CurrTeammateCommands", "ExecutingTeammateCommand", "Visible", "TeammateCommandPreparePercent", "TeammateCommandTimePercent", "AttackCommandWeaponKey", "AttackCommandTrickType", "DefendCommandSkillId",
		"ShowEffectCommandIndex", "AttackCommandSkillId", "TeammateCommandBanReasons", "TargetDistance", "OldInjuryAutoHealCollection", "MixPoisonAffectedCount", "ParticleToLoopByCombatSkill", "NeiliAllocationCd", "ProportionDelta", "ShowCommandList",
		"UnlockPrepareValue", "RawCreateEffects", "RawCreateCollection", "NormalAttackRecovery", "ReserveNormalAttack", "Gangqi", "GangqiMax", "MoveState", "PlayerControllingMove", "ScarMarkTime",
		"MindRhythm", "MindUpheavalTime", "TeammateCommandCd", "TeammateCommandCdSpeed", "MaxTrickCount", "MobilityLevel", "TeammateCommandCanUse", "ChangeDistanceDuration", "AttackRange", "Happiness",
		"SilenceData", "CombatStateTotalBuffPower", "HeavyOrBreakInjuryData", "MoveCd", "MobilityRecoverSpeed", "CanUnlockAttack", "ValidItems", "ValidItemAndCounts", "UseItemCostNoWisdom", "TeammateCommandBaseCdSpeed",
		"PreparingOtherActionInterruptType", "MixPoisonCanAffectCount"
	};
}
