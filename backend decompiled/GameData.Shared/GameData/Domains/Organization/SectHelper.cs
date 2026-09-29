using System.Collections.Generic;

namespace GameData.Domains.Organization;

public static class SectHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort OrgTemplateId = 1;

		public const ushort Location = 2;

		public const ushort Culture = 3;

		public const ushort MaxCulture = 4;

		public const ushort Safety = 5;

		public const ushort MaxSafety = 6;

		public const ushort Population = 7;

		public const ushort MaxPopulation = 8;

		public const ushort StandardOnStagePopulation = 9;

		public const ushort Members = 10;

		public const ushort LackingCoreMembers = 11;

		public const ushort ApprovingRateUpperLimitBonus = 12;

		public const ushort InfluencePowerUpdateDate = 13;

		public const ushort MinSeniorityId = 14;

		public const ushort AvailableMonasticTitleSuffixIds = 15;

		public const ushort TaiwuExploreStatus = 16;

		public const ushort SpiritualDebtInteractionOccurred = 17;

		public const ushort TaiwuInvestmentForMartialArtTournament = 18;

		public const ushort FunctionStatuses = 19;

		public const ushort ApprovingRateUpperLimitTempBonus = 20;

		public const ushort MartialArtTournamentPreparations = 21;
	}

	public const ushort ArchiveFieldsCount = 20;

	public const ushort CacheFieldsCount = 2;

	public const ushort PureTemplateFieldsCount = 0;

	public const ushort WritableFieldsCount = 22;

	public const ushort ReadonlyFieldsCount = 0;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "OrgTemplateId", 1 },
		{ "Location", 2 },
		{ "Culture", 3 },
		{ "MaxCulture", 4 },
		{ "Safety", 5 },
		{ "MaxSafety", 6 },
		{ "Population", 7 },
		{ "MaxPopulation", 8 },
		{ "StandardOnStagePopulation", 9 },
		{ "Members", 10 },
		{ "LackingCoreMembers", 11 },
		{ "ApprovingRateUpperLimitBonus", 12 },
		{ "InfluencePowerUpdateDate", 13 },
		{ "MinSeniorityId", 14 },
		{ "AvailableMonasticTitleSuffixIds", 15 },
		{ "TaiwuExploreStatus", 16 },
		{ "SpiritualDebtInteractionOccurred", 17 },
		{ "TaiwuInvestmentForMartialArtTournament", 18 },
		{ "FunctionStatuses", 19 },
		{ "ApprovingRateUpperLimitTempBonus", 20 },
		{ "MartialArtTournamentPreparations", 21 }
	};

	public static readonly string[] FieldId2FieldName = new string[22]
	{
		"Id", "OrgTemplateId", "Location", "Culture", "MaxCulture", "Safety", "MaxSafety", "Population", "MaxPopulation", "StandardOnStagePopulation",
		"Members", "LackingCoreMembers", "ApprovingRateUpperLimitBonus", "InfluencePowerUpdateDate", "MinSeniorityId", "AvailableMonasticTitleSuffixIds", "TaiwuExploreStatus", "SpiritualDebtInteractionOccurred", "TaiwuInvestmentForMartialArtTournament", "FunctionStatuses",
		"ApprovingRateUpperLimitTempBonus", "MartialArtTournamentPreparations"
	};
}
