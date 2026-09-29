using System.Collections.Generic;

namespace GameData.Domains.Organization;

public static class CivilianSettlementHelper
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

		public const ushort RandomNameId = 14;

		public const ushort MainMorality = 15;

		public const ushort ApprovingRateUpperLimitTempBonus = 16;
	}

	public const ushort ArchiveFieldsCount = 16;

	public const ushort CacheFieldsCount = 1;

	public const ushort PureTemplateFieldsCount = 0;

	public const ushort WritableFieldsCount = 17;

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
		{ "RandomNameId", 14 },
		{ "MainMorality", 15 },
		{ "ApprovingRateUpperLimitTempBonus", 16 }
	};

	public static readonly string[] FieldId2FieldName = new string[17]
	{
		"Id", "OrgTemplateId", "Location", "Culture", "MaxCulture", "Safety", "MaxSafety", "Population", "MaxPopulation", "StandardOnStagePopulation",
		"Members", "LackingCoreMembers", "ApprovingRateUpperLimitBonus", "InfluencePowerUpdateDate", "RandomNameId", "MainMorality", "ApprovingRateUpperLimitTempBonus"
	};
}
