using System.Collections.Generic;

namespace GameData.Domains.Combat;

public static class CombatWeaponDataHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort WeaponTricks = 1;

		public const ushort CanChangeTo = 2;

		public const ushort Durability = 3;

		public const ushort CdFrame = 4;

		public const ushort AutoAttackEffect = 5;

		public const ushort PestleEffect = 6;

		public const ushort FixedCdLeftFrame = 7;

		public const ushort FixedCdTotalFrame = 8;

		public const ushort InnerRatio = 9;
	}

	public const ushort ArchiveFieldsCount = 9;

	public const ushort CacheFieldsCount = 1;

	public const ushort PureTemplateFieldsCount = 0;

	public const ushort WritableFieldsCount = 10;

	public const ushort ReadonlyFieldsCount = 0;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "WeaponTricks", 1 },
		{ "CanChangeTo", 2 },
		{ "Durability", 3 },
		{ "CdFrame", 4 },
		{ "AutoAttackEffect", 5 },
		{ "PestleEffect", 6 },
		{ "FixedCdLeftFrame", 7 },
		{ "FixedCdTotalFrame", 8 },
		{ "InnerRatio", 9 }
	};

	public static readonly string[] FieldId2FieldName = new string[10] { "Id", "WeaponTricks", "CanChangeTo", "Durability", "CdFrame", "AutoAttackEffect", "PestleEffect", "FixedCdLeftFrame", "FixedCdTotalFrame", "InnerRatio" };
}
