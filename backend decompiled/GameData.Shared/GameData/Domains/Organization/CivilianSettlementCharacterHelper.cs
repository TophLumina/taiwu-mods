using System.Collections.Generic;

namespace GameData.Domains.Organization;

public static class CivilianSettlementCharacterHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort OrgTemplateId = 1;

		public const ushort SettlementId = 2;

		public const ushort ApprovedTaiwu = 3;

		public const ushort InfluencePower = 4;

		public const ushort InfluencePowerBonus = 5;
	}

	public const ushort ArchiveFieldsCount = 6;

	public const ushort CacheFieldsCount = 0;

	public const ushort PureTemplateFieldsCount = 0;

	public const ushort WritableFieldsCount = 6;

	public const ushort ReadonlyFieldsCount = 0;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "OrgTemplateId", 1 },
		{ "SettlementId", 2 },
		{ "ApprovedTaiwu", 3 },
		{ "InfluencePower", 4 },
		{ "InfluencePowerBonus", 5 }
	};

	public static readonly string[] FieldId2FieldName = new string[6] { "Id", "OrgTemplateId", "SettlementId", "ApprovedTaiwu", "InfluencePower", "InfluencePowerBonus" };
}
