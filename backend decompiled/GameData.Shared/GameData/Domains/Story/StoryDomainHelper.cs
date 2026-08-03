using System.Collections.Generic;

namespace GameData.Domains.Story;

public static class StoryDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort SectMainStoryTaskStatus = 0;

		public const ushort Wordless = 1;

		public const ushort SectEmeiBreakBonusData = 2;

		public const ushort SectEmeiSkillBreakBonus = 3;

		public const ushort SectEmeiBreakBonusTemplateIds = 4;

		public const ushort ThreeVitalsReplaceTeammateRecord = 5;

		public const ushort ThreeVitalsReplaceTeammateRecordNew = 6;

		public const ushort SectMainStoryCombatTimesShaolin = 7;

		public const ushort AdvanceXiangshuAvatarIds = 8;

		public const ushort IronPlateData = 9;

		public const ushort NoMindGuyUsed = 10;

		public const ushort DivineFlameData = 11;

		public const ushort TwelveImmortalsStatuses = 12;

		public const ushort SectEmeiGuidance = 13;

		public const ushort SectEmeiGuidanceData = 14;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort GetSectMainStoryActiveStatus = 0;

		public const ushort SetSectMainStoryActiveStatus = 1;

		public const ushort NotifySectStoryActivated = 2;

		public const ushort GetBaihuaLifeLinkNeiliType = 3;

		public const ushort GetSectBaihuaLifeLinkDisplayData = 4;

		public const ushort SetLifeLinkCharacter = 5;

		public const ushort ShaolinInterruptDemonSlayerTrial = 6;

		public const ushort ShaolinRegenerateRestricts = 7;

		public const ushort ShaolinQueryRestrictsAreSatisfied = 8;

		public const ushort ShaolinStartDemonSlayerTrial = 9;

		public const ushort ShaolinGenerateTemporaryDemon = 10;

		public const ushort ShaolinClearTemporaryDemon = 11;

		public const ushort CreateMirrorCharacter = 12;

		public const ushort GetDefendHeavenlyTreeDisplayData = 13;

		public const ushort DefendHeavenlyTreeFeed = 14;

		public const ushort TryTriggerThiefCatch = 15;

		public const ushort CatchThief = 16;

		public const ushort GetSectZhujianGearMateAttributeDisplayData = 17;

		public const ushort GetSectZhujianGearMateSkillDisplayData = 18;

		public const ushort GetGearMateBreakoutDisplayData = 19;

		public const ushort GetSectZhujianGearMateFeatureDisplayData = 20;

		public const ushort GetSectZhujianGearMateConsummateDisplayData = 21;

		public const ushort JingangMonkSoulBtnShow = 22;

		public const ushort GetCurAreaValidCharactersForTripodVessel = 23;

		public const ushort ApplyKongsangSpecialInteract = 24;

		public const ushort GetEmeiBreakBonusCollection = 25;

		public const ushort AddEmeiSkillBreakBonus = 26;

		public const ushort GmCmd_SectEmeiAddSkillBreakBonus = 27;

		public const ushort GetEmeiBreakBonusDisplayData = 28;

		public const ushort GetSectEmeiSpecialBreakDisplayData = 29;

		public const ushort EmeiTransferBonusProgress = 30;

		public const ushort RemoveEmeiSkillBreakBonus = 31;

		public const ushort GmCmd_SectEmeiClearSkillBreakBonus = 32;

		public const ushort GetSectMainStoryTriggerConditions = 33;

		public const ushort DriveWugKing = 34;

		public const ushort RefiningWugKing = 35;

		public const ushort DropPoisonsToWugJug = 36;

		public const ushort GetWugKingDriveStatuses = 37;

		public const ushort GetThreeVitalsReplaceTeammateRecord = 38;

		public const ushort ThreeVitalsReplaceTeammateRecordRemove = 39;

		public const ushort ThreeVitalsReplaceTeammateRecordSet = 40;

		public const ushort DefendHeavenlyTreeClearEnemy = 41;

		public const ushort GmCmd_ClearIronPlateCooldown = 42;

		public const ushort GetIronPlateCombatCharId = 43;

		public const ushort GetIronPlateOptionCharIdList = 44;

		public const ushort SetIconPlateFollowingCharId = 45;

		public const ushort GmCmd_SetIconPlateIsUnlocked = 46;

		public const ushort GmCmd_ClearDivineFlameCooldown = 47;

		public const ushort GmCmd_SetDivineFlameIsUnlocked = 48;

		public const ushort UseDivineFlame = 49;

		public const ushort GetDivineFlameSelectTargetCharIdList = 50;

		public const ushort CheckDivineFlameTarget = 51;

		public const ushort GetDivineFlameSelectTargetLocationList = 52;

		public const ushort GetDivineFlameDisplayData = 53;

		public const ushort UpdateSectEmeiGuidanceData = 54;

		public const ushort OnClickEmeiGuidance = 55;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 15;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "SectMainStoryTaskStatus", 0 },
		{ "Wordless", 1 },
		{ "SectEmeiBreakBonusData", 2 },
		{ "SectEmeiSkillBreakBonus", 3 },
		{ "SectEmeiBreakBonusTemplateIds", 4 },
		{ "ThreeVitalsReplaceTeammateRecord", 5 },
		{ "ThreeVitalsReplaceTeammateRecordNew", 6 },
		{ "SectMainStoryCombatTimesShaolin", 7 },
		{ "AdvanceXiangshuAvatarIds", 8 },
		{ "IronPlateData", 9 },
		{ "NoMindGuyUsed", 10 },
		{ "DivineFlameData", 11 },
		{ "TwelveImmortalsStatuses", 12 },
		{ "SectEmeiGuidance", 13 },
		{ "SectEmeiGuidanceData", 14 }
	};

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[15]
	{
		"SectMainStoryTaskStatus", "Wordless", "SectEmeiBreakBonusData", "SectEmeiSkillBreakBonus", "SectEmeiBreakBonusTemplateIds", "ThreeVitalsReplaceTeammateRecord", "ThreeVitalsReplaceTeammateRecordNew", "SectMainStoryCombatTimesShaolin", "AdvanceXiangshuAvatarIds", "IronPlateData",
		"NoMindGuyUsed", "DivineFlameData", "TwelveImmortalsStatuses", "SectEmeiGuidance", "SectEmeiGuidanceData"
	};

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[15][];

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "GetSectMainStoryActiveStatus", 0 },
		{ "SetSectMainStoryActiveStatus", 1 },
		{ "NotifySectStoryActivated", 2 },
		{ "GetBaihuaLifeLinkNeiliType", 3 },
		{ "GetSectBaihuaLifeLinkDisplayData", 4 },
		{ "SetLifeLinkCharacter", 5 },
		{ "ShaolinInterruptDemonSlayerTrial", 6 },
		{ "ShaolinRegenerateRestricts", 7 },
		{ "ShaolinQueryRestrictsAreSatisfied", 8 },
		{ "ShaolinStartDemonSlayerTrial", 9 },
		{ "ShaolinGenerateTemporaryDemon", 10 },
		{ "ShaolinClearTemporaryDemon", 11 },
		{ "CreateMirrorCharacter", 12 },
		{ "GetDefendHeavenlyTreeDisplayData", 13 },
		{ "DefendHeavenlyTreeFeed", 14 },
		{ "TryTriggerThiefCatch", 15 },
		{ "CatchThief", 16 },
		{ "GetSectZhujianGearMateAttributeDisplayData", 17 },
		{ "GetSectZhujianGearMateSkillDisplayData", 18 },
		{ "GetGearMateBreakoutDisplayData", 19 },
		{ "GetSectZhujianGearMateFeatureDisplayData", 20 },
		{ "GetSectZhujianGearMateConsummateDisplayData", 21 },
		{ "JingangMonkSoulBtnShow", 22 },
		{ "GetCurAreaValidCharactersForTripodVessel", 23 },
		{ "ApplyKongsangSpecialInteract", 24 },
		{ "GetEmeiBreakBonusCollection", 25 },
		{ "AddEmeiSkillBreakBonus", 26 },
		{ "GmCmd_SectEmeiAddSkillBreakBonus", 27 },
		{ "GetEmeiBreakBonusDisplayData", 28 },
		{ "GetSectEmeiSpecialBreakDisplayData", 29 },
		{ "EmeiTransferBonusProgress", 30 },
		{ "RemoveEmeiSkillBreakBonus", 31 },
		{ "GmCmd_SectEmeiClearSkillBreakBonus", 32 },
		{ "GetSectMainStoryTriggerConditions", 33 },
		{ "DriveWugKing", 34 },
		{ "RefiningWugKing", 35 },
		{ "DropPoisonsToWugJug", 36 },
		{ "GetWugKingDriveStatuses", 37 },
		{ "GetThreeVitalsReplaceTeammateRecord", 38 },
		{ "ThreeVitalsReplaceTeammateRecordRemove", 39 },
		{ "ThreeVitalsReplaceTeammateRecordSet", 40 },
		{ "DefendHeavenlyTreeClearEnemy", 41 },
		{ "GmCmd_ClearIronPlateCooldown", 42 },
		{ "GetIronPlateCombatCharId", 43 },
		{ "GetIronPlateOptionCharIdList", 44 },
		{ "SetIconPlateFollowingCharId", 45 },
		{ "GmCmd_SetIconPlateIsUnlocked", 46 },
		{ "GmCmd_ClearDivineFlameCooldown", 47 },
		{ "GmCmd_SetDivineFlameIsUnlocked", 48 },
		{ "UseDivineFlame", 49 },
		{ "GetDivineFlameSelectTargetCharIdList", 50 },
		{ "CheckDivineFlameTarget", 51 },
		{ "GetDivineFlameSelectTargetLocationList", 52 },
		{ "GetDivineFlameDisplayData", 53 },
		{ "UpdateSectEmeiGuidanceData", 54 },
		{ "OnClickEmeiGuidance", 55 }
	};

	public static readonly string[] MethodId2MethodName = new string[56]
	{
		"GetSectMainStoryActiveStatus", "SetSectMainStoryActiveStatus", "NotifySectStoryActivated", "GetBaihuaLifeLinkNeiliType", "GetSectBaihuaLifeLinkDisplayData", "SetLifeLinkCharacter", "ShaolinInterruptDemonSlayerTrial", "ShaolinRegenerateRestricts", "ShaolinQueryRestrictsAreSatisfied", "ShaolinStartDemonSlayerTrial",
		"ShaolinGenerateTemporaryDemon", "ShaolinClearTemporaryDemon", "CreateMirrorCharacter", "GetDefendHeavenlyTreeDisplayData", "DefendHeavenlyTreeFeed", "TryTriggerThiefCatch", "CatchThief", "GetSectZhujianGearMateAttributeDisplayData", "GetSectZhujianGearMateSkillDisplayData", "GetGearMateBreakoutDisplayData",
		"GetSectZhujianGearMateFeatureDisplayData", "GetSectZhujianGearMateConsummateDisplayData", "JingangMonkSoulBtnShow", "GetCurAreaValidCharactersForTripodVessel", "ApplyKongsangSpecialInteract", "GetEmeiBreakBonusCollection", "AddEmeiSkillBreakBonus", "GmCmd_SectEmeiAddSkillBreakBonus", "GetEmeiBreakBonusDisplayData", "GetSectEmeiSpecialBreakDisplayData",
		"EmeiTransferBonusProgress", "RemoveEmeiSkillBreakBonus", "GmCmd_SectEmeiClearSkillBreakBonus", "GetSectMainStoryTriggerConditions", "DriveWugKing", "RefiningWugKing", "DropPoisonsToWugJug", "GetWugKingDriveStatuses", "GetThreeVitalsReplaceTeammateRecord", "ThreeVitalsReplaceTeammateRecordRemove",
		"ThreeVitalsReplaceTeammateRecordSet", "DefendHeavenlyTreeClearEnemy", "GmCmd_ClearIronPlateCooldown", "GetIronPlateCombatCharId", "GetIronPlateOptionCharIdList", "SetIconPlateFollowingCharId", "GmCmd_SetIconPlateIsUnlocked", "GmCmd_ClearDivineFlameCooldown", "GmCmd_SetDivineFlameIsUnlocked", "UseDivineFlame",
		"GetDivineFlameSelectTargetCharIdList", "CheckDivineFlameTarget", "GetDivineFlameSelectTargetLocationList", "GetDivineFlameDisplayData", "UpdateSectEmeiGuidanceData", "OnClickEmeiGuidance"
	};
}
