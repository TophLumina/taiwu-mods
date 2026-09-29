using System.Collections.Generic;

namespace GameData.Domains.Character;

public static class GraveHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort Location = 1;

		public const ushort Level = 2;

		public const ushort Durability = 3;

		public const ushort Inventory = 4;

		public const ushort Resources = 5;

		public const ushort SkeletonCharId = 6;
	}

	public const ushort ArchiveFieldsCount = 7;

	public const ushort CacheFieldsCount = 0;

	public const ushort PureTemplateFieldsCount = 0;

	public const ushort WritableFieldsCount = 7;

	public const ushort ReadonlyFieldsCount = 0;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "Location", 1 },
		{ "Level", 2 },
		{ "Durability", 3 },
		{ "Inventory", 4 },
		{ "Resources", 5 },
		{ "SkeletonCharId", 6 }
	};

	public static readonly string[] FieldId2FieldName = new string[7] { "Id", "Location", "Level", "Durability", "Inventory", "Resources", "SkeletonCharId" };
}
