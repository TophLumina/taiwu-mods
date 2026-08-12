using System.Collections.Generic;

namespace GameData.Domains.Organization;

public static class CivilianSettlementCharacterHelper
{
	/// <summary>
	/// 数据字段 ID 集合.
	/// 字段顺序: 档案字段, 缓存字段, 模板字段.
	/// </summary>
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort OrgTemplateId = 1;

		public const ushort SettlementId = 2;

		public const ushort ApprovedTaiwu = 3;

		public const ushort InfluencePower = 4;

		public const ushort InfluencePowerBonus = 5;
	}

	/// <summary>
	/// 档案数据字段数 (可能也是模板数据)
	/// </summary>
	public const ushort ArchiveFieldsCount = 6;

	/// <summary>
	/// 缓存数据字段数
	/// </summary>
	public const ushort CacheFieldsCount = 0;

	/// <summary>
	/// 纯模板数据字段数 (不同时是档案数据)
	/// </summary>
	public const ushort PureTemplateFieldsCount = 0;

	/// <summary>
	/// 可变数据字段数 (档案字段数与缓存字段数之和)
	/// </summary>
	public const ushort WritableFieldsCount = 6;

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
		{ "OrgTemplateId", 1 },
		{ "SettlementId", 2 },
		{ "ApprovedTaiwu", 3 },
		{ "InfluencePower", 4 },
		{ "InfluencePowerBonus", 5 }
	};

	/// <summary>
	/// 通过字段 ID 获取字段名
	/// </summary>
	public static readonly string[] FieldId2FieldName = new string[6] { "Id", "OrgTemplateId", "SettlementId", "ApprovedTaiwu", "InfluencePower", "InfluencePowerBonus" };
}
