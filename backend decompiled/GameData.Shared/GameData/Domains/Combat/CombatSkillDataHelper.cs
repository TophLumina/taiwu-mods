using System.Collections.Generic;

namespace GameData.Domains.Combat;

public static class CombatSkillDataHelper
{
	/// <summary>
	/// 数据字段 ID 集合.
	/// 字段顺序: 档案字段, 缓存字段, 模板字段.
	/// </summary>
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

	/// <summary>
	/// 档案数据字段数 (可能也是模板数据)
	/// </summary>
	public const ushort ArchiveFieldsCount = 7;

	/// <summary>
	/// 缓存数据字段数
	/// </summary>
	public const ushort CacheFieldsCount = 3;

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

	/// <summary>
	/// 通过字段 ID 获取字段名
	/// </summary>
	public static readonly string[] FieldId2FieldName = new string[10] { "Id", "CanUse", "LeftCdFrame", "TotalCdFrame", "ConstAffecting", "ShowAffectTips", "Silencing", "BanReason", "EffectData", "CanAffect" };
}
