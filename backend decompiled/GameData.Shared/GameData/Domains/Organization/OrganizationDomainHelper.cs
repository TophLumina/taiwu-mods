using System.Collections.Generic;

namespace GameData.Domains.Organization;

public static class OrganizationDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort Sects = 0;

		public const ushort CivilianSettlements = 1;

		public const ushort NextSettlementId = 2;

		public const ushort SectCharacters = 3;

		public const ushort CivilianSettlementCharacters = 4;

		public const ushort Factions = 5;

		public const ushort LargeSectFavorabilities = 6;

		public const ushort MartialArtTournamentPreparationInfoList = 7;

		public const ushort PreviousMartialArtTournamentHosts = 8;

		public const ushort MaxApprovingRateTemporaryBonus = 9;

		public const ushort PrevMartialArtTournamentWinners = 10;

		public const ushort SettlementTreasuryRecordCollections = 11;

		public const ushort SettlementPrisonRecordCollections = 12;

		public const ushort SettlementMemberFeatures = 13;

		public const ushort SettlementPrisons = 14;

		public const ushort CityPunishmentSeverityCustomizeDict = 15;

		public const ushort CurrTournamentHost = 16;

		public const ushort LastTournamentFinishDate = 17;

		public const ushort TournamentPreparationEndDate = 18;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort GetDisplayData = 0;

		public const ushort GetSettlementNameRelatedData = 1;

		public const ushort GetSettlementMembers = 2;

		public const ushort GetOrganizationCombatSkillsDisplayData = 3;

		public const ushort GetSectPreparationForMartialArtTournament = 4;

		public const ushort GetMartialArtTournamentCurrentHostSettlementId = 5;

		public const ushort GmCmd_SetAllSettlementInformationVisited = 6;

		public const ushort GmCmd_GetAllFactionMembers = 7;

		public const ushort GetSettlementIdByAreaIdAndBlockId = 8;

		public const ushort GetCultureByAreaIdAndBlockId = 9;

		public const ushort CalcApprovingRateEffectAuthorityGain = 10;

		public const ushort GetSettlementTreasuryDisplayData = 11;

		public const ushort GetSettlementTreasuryRecordCollection = 12;

		public const ushort SetInscribedCharactersForCreation = 13;

		public const ushort GmCmd_UpdateSettlementTreasury = 14;

		public const ushort GmCmd_ClearSettlementTreasuryAlertTime = 15;

		public const ushort GmCmd_ClearSettlementTreasuryItemAndResource = 16;

		public const ushort GmCmd_ForceUpdateTreasuryGuards = 17;

		public const ushort AddSectBounty = 18;

		public const ushort AddSectPrisoner = 19;

		public const ushort GetSettlementPrisonDisplayData = 20;

		public const ushort GetSettlementBountyDisplayData = 21;

		public const ushort GetSettlementPrisonRecordCollection = 22;

		public const ushort GmCmd_ForceUpdateInfluencePower = 23;

		public const ushort GetBountyCharacterDisplayDataFromCharacterList = 24;

		public const ushort ForceUpdateTaiwuVillager = 25;

		public const ushort IsTaiwuSectFugitive = 26;

		public const ushort GetOrganizationTemplateIdOfTaiwuLocation = 27;

		public const ushort GetLastSettlementTreasuryOperationData = 28;

		public const ushort GmCmd_GetSettlementPrisoner = 29;

		public const ushort CheckSettlementGuardFavorabilityType = 30;

		public const ushort GmCmd_SetAllSettlementMemberApprovedTaiwu = 31;

		public const ushort GetSectFunctionStatus = 32;

		public const ushort GmCmd_SetSectFunctionStatus = 33;

		public const ushort UpdateCityPunishmentSeverityCustomizeData = 34;

		public const ushort GetCustomizePunishmentSeverityCost = 35;

		public const ushort WillCustomizePunishmentBreakWithoutVillagerHead = 36;

		public const ushort GetSettlementPopulationDisplayData = 37;

		public const ushort GetReversedSettlementPrisonRecordCollection = 38;

		public const ushort GetReversedSettlementTreasuryRecordCollection = 39;

		public const ushort GetSettlementApproveTaiwuMembers = 40;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 19;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "Sects", 0 },
		{ "CivilianSettlements", 1 },
		{ "NextSettlementId", 2 },
		{ "SectCharacters", 3 },
		{ "CivilianSettlementCharacters", 4 },
		{ "Factions", 5 },
		{ "LargeSectFavorabilities", 6 },
		{ "MartialArtTournamentPreparationInfoList", 7 },
		{ "PreviousMartialArtTournamentHosts", 8 },
		{ "MaxApprovingRateTemporaryBonus", 9 },
		{ "PrevMartialArtTournamentWinners", 10 },
		{ "SettlementTreasuryRecordCollections", 11 },
		{ "SettlementPrisonRecordCollections", 12 },
		{ "SettlementMemberFeatures", 13 },
		{ "SettlementPrisons", 14 },
		{ "CityPunishmentSeverityCustomizeDict", 15 },
		{ "CurrTournamentHost", 16 },
		{ "LastTournamentFinishDate", 17 },
		{ "TournamentPreparationEndDate", 18 }
	};

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[19]
	{
		"Sects", "CivilianSettlements", "NextSettlementId", "SectCharacters", "CivilianSettlementCharacters", "Factions", "LargeSectFavorabilities", "MartialArtTournamentPreparationInfoList", "PreviousMartialArtTournamentHosts", "MaxApprovingRateTemporaryBonus",
		"PrevMartialArtTournamentWinners", "SettlementTreasuryRecordCollections", "SettlementPrisonRecordCollections", "SettlementMemberFeatures", "SettlementPrisons", "CityPunishmentSeverityCustomizeDict", "CurrTournamentHost", "LastTournamentFinishDate", "TournamentPreparationEndDate"
	};

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[19][]
	{
		SectHelper.FieldId2FieldName,
		CivilianSettlementHelper.FieldId2FieldName,
		null,
		SectCharacterHelper.FieldId2FieldName,
		CivilianSettlementCharacterHelper.FieldId2FieldName,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null
	};

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "GetDisplayData", 0 },
		{ "GetSettlementNameRelatedData", 1 },
		{ "GetSettlementMembers", 2 },
		{ "GetOrganizationCombatSkillsDisplayData", 3 },
		{ "GetSectPreparationForMartialArtTournament", 4 },
		{ "GetMartialArtTournamentCurrentHostSettlementId", 5 },
		{ "GmCmd_SetAllSettlementInformationVisited", 6 },
		{ "GmCmd_GetAllFactionMembers", 7 },
		{ "GetSettlementIdByAreaIdAndBlockId", 8 },
		{ "GetCultureByAreaIdAndBlockId", 9 },
		{ "CalcApprovingRateEffectAuthorityGain", 10 },
		{ "GetSettlementTreasuryDisplayData", 11 },
		{ "GetSettlementTreasuryRecordCollection", 12 },
		{ "SetInscribedCharactersForCreation", 13 },
		{ "GmCmd_UpdateSettlementTreasury", 14 },
		{ "GmCmd_ClearSettlementTreasuryAlertTime", 15 },
		{ "GmCmd_ClearSettlementTreasuryItemAndResource", 16 },
		{ "GmCmd_ForceUpdateTreasuryGuards", 17 },
		{ "AddSectBounty", 18 },
		{ "AddSectPrisoner", 19 },
		{ "GetSettlementPrisonDisplayData", 20 },
		{ "GetSettlementBountyDisplayData", 21 },
		{ "GetSettlementPrisonRecordCollection", 22 },
		{ "GmCmd_ForceUpdateInfluencePower", 23 },
		{ "GetBountyCharacterDisplayDataFromCharacterList", 24 },
		{ "ForceUpdateTaiwuVillager", 25 },
		{ "IsTaiwuSectFugitive", 26 },
		{ "GetOrganizationTemplateIdOfTaiwuLocation", 27 },
		{ "GetLastSettlementTreasuryOperationData", 28 },
		{ "GmCmd_GetSettlementPrisoner", 29 },
		{ "CheckSettlementGuardFavorabilityType", 30 },
		{ "GmCmd_SetAllSettlementMemberApprovedTaiwu", 31 },
		{ "GetSectFunctionStatus", 32 },
		{ "GmCmd_SetSectFunctionStatus", 33 },
		{ "UpdateCityPunishmentSeverityCustomizeData", 34 },
		{ "GetCustomizePunishmentSeverityCost", 35 },
		{ "WillCustomizePunishmentBreakWithoutVillagerHead", 36 },
		{ "GetSettlementPopulationDisplayData", 37 },
		{ "GetReversedSettlementPrisonRecordCollection", 38 },
		{ "GetReversedSettlementTreasuryRecordCollection", 39 },
		{ "GetSettlementApproveTaiwuMembers", 40 }
	};

	public static readonly string[] MethodId2MethodName = new string[41]
	{
		"GetDisplayData", "GetSettlementNameRelatedData", "GetSettlementMembers", "GetOrganizationCombatSkillsDisplayData", "GetSectPreparationForMartialArtTournament", "GetMartialArtTournamentCurrentHostSettlementId", "GmCmd_SetAllSettlementInformationVisited", "GmCmd_GetAllFactionMembers", "GetSettlementIdByAreaIdAndBlockId", "GetCultureByAreaIdAndBlockId",
		"CalcApprovingRateEffectAuthorityGain", "GetSettlementTreasuryDisplayData", "GetSettlementTreasuryRecordCollection", "SetInscribedCharactersForCreation", "GmCmd_UpdateSettlementTreasury", "GmCmd_ClearSettlementTreasuryAlertTime", "GmCmd_ClearSettlementTreasuryItemAndResource", "GmCmd_ForceUpdateTreasuryGuards", "AddSectBounty", "AddSectPrisoner",
		"GetSettlementPrisonDisplayData", "GetSettlementBountyDisplayData", "GetSettlementPrisonRecordCollection", "GmCmd_ForceUpdateInfluencePower", "GetBountyCharacterDisplayDataFromCharacterList", "ForceUpdateTaiwuVillager", "IsTaiwuSectFugitive", "GetOrganizationTemplateIdOfTaiwuLocation", "GetLastSettlementTreasuryOperationData", "GmCmd_GetSettlementPrisoner",
		"CheckSettlementGuardFavorabilityType", "GmCmd_SetAllSettlementMemberApprovedTaiwu", "GetSectFunctionStatus", "GmCmd_SetSectFunctionStatus", "UpdateCityPunishmentSeverityCustomizeData", "GetCustomizePunishmentSeverityCost", "WillCustomizePunishmentBreakWithoutVillagerHead", "GetSettlementPopulationDisplayData", "GetReversedSettlementPrisonRecordCollection", "GetReversedSettlementTreasuryRecordCollection",
		"GetSettlementApproveTaiwuMembers"
	};
}
