using System.Collections.Generic;

namespace GameData.Domains.Information;

public static class SecretInformationMetaDataHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort Offset = 1;

		public const ushort DisseminationData = 2;

		public const ushort RelevanceSecretInformationMetaDataId = 3;

		public const ushort SecretInformationCharacterRelationshipSnapshotCollection = 4;

		public const ushort SecretInformationCharacterExtraInfoCollection = 5;
	}

	public const ushort ArchiveFieldsCount = 6;

	public const ushort CacheFieldsCount = 0;

	public const ushort PureTemplateFieldsCount = 0;

	public const ushort WritableFieldsCount = 6;

	public const ushort ReadonlyFieldsCount = 0;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "Offset", 1 },
		{ "DisseminationData", 2 },
		{ "RelevanceSecretInformationMetaDataId", 3 },
		{ "SecretInformationCharacterRelationshipSnapshotCollection", 4 },
		{ "SecretInformationCharacterExtraInfoCollection", 5 }
	};

	public static readonly string[] FieldId2FieldName = new string[6] { "Id", "Offset", "DisseminationData", "RelevanceSecretInformationMetaDataId", "SecretInformationCharacterRelationshipSnapshotCollection", "SecretInformationCharacterExtraInfoCollection" };
}
