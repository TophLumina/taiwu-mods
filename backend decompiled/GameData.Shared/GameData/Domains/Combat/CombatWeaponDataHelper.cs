using System.Collections.Generic;

namespace GameData.Domains.Combat;

public static class CombatWeaponDataHelper
{
	/// <summary>
	/// 数据字段 ID 集合.
	/// 字段顺序: 档案字段, 缓存字段, 模板字段.
	/// </summary>
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

	/// <summary>
	/// 档案数据字段数 (可能也是模板数据)
	/// </summary>
	public const ushort ArchiveFieldsCount = 9;

	/// <summary>
	/// 缓存数据字段数
	/// </summary>
	public const ushort CacheFieldsCount = 1;

	/// <summary>
	/// 纯模板数据字段数 (不同时是档案数据)
	/// </summary>
	public const ushort PureTemplateFieldsCount = 0;

	/// <summary>
	/// 可变数据字段数 (档案字段数与缓存字段数之和)
	/// </summary>
	public const ushort WritableFieldsCount = 10;

	/// <summary>
	/// 只读数据字段数 (模板字段数)
	/// </summary>
	public const ushort ReadonlyFieldsCount = 0;

	/// <summary>
	/// 通过字段名获取字段 ID
	/// </summary>
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

	/// <summary>
	/// 通过字段 ID 获取字段名
	/// </summary>
	public static readonly string[] FieldId2FieldName = new string[10] { "Id", "WeaponTricks", "CanChangeTo", "Durability", "CdFrame", "AutoAttackEffect", "PestleEffect", "FixedCdLeftFrame", "FixedCdTotalFrame", "InnerRatio" };
}
