using System.Collections.Generic;

namespace GameData.Domains.Combat;

public static class CombatSkillDataHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort CanUse = 1;

		public const ushort LeftCdFrame = 2;

		public const ushort TotalCdFrame = 3;

		public const ushort ConstAffecting = 4;

		public const ushort ShowAffectTips = 5;

		public const ushort Silencing = 6;

		public const ushort BanReason = 7;

		public const ushort EffectData = 8;

		public const ushort CanAffect = 9;
	}

	public const ushort ArchiveFieldsCount = 7;

	public const ushort CacheFieldsCount = 3;

	public const ushort PureTemplateFieldsCount = 0;

	public const ushort WritableFieldsCount = 10;

	public const ushort ReadonlyFieldsCount = 0;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "CanUse", 1 },
		{ "LeftCdFrame", 2 },
		{ "TotalCdFrame", 3 },
		{ "ConstAffecting", 4 },
		{ "ShowAffectTips", 5 },
		{ "Silencing", 6 },
		{ "BanReason", 7 },
		{ "EffectData", 8 },
		{ "CanAffect", 9 }
	};

	public static readonly string[] FieldId2FieldName = new string[10] { "Id", "CanUse", "LeftCdFrame", "TotalCdFrame", "ConstAffecting", "ShowAffectTips", "Silencing", "BanReason", "EffectData", "CanAffect" };
}
