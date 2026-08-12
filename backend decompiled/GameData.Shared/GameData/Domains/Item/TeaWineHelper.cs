using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class TeaWineHelper
{
	/// <summary>
	/// 数据字段 ID 集合.
	/// 字段顺序: 档案字段, 缓存字段, 模板字段.
	/// </summary>
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort TemplateId = 1;

		public const ushort MaxDurability = 2;

		public const ushort CurrDurability = 3;

		public const ushort ModificationState = 4;

		public const ushort Name = 5;

		public const ushort ItemType = 6;

		public const ushort ItemSubType = 7;

		public const ushort Grade = 8;

		public const ushort Icon = 9;

		public const ushort Desc = 10;

		public const ushort Transferable = 11;

		public const ushort Stackable = 12;

		public const ushort Wagerable = 13;

		public const ushort Refinable = 14;

		public const ushort Poisonable = 15;

		public const ushort Repairable = 16;

		public const ushort BaseWeight = 17;

		public const ushort BaseValue = 18;

		public const ushort DropRate = 19;

		public const ushort ResourceType = 20;

		public const ushort PreservationDuration = 21;

		public const ushort Duration = 22;

		public const ushort DirectChangeOfQiDisorder = 23;

		public const ushort ConsumedFeatureMedals = 24;

		public const ushort HitRateStrength = 25;

		public const ushort HitRateTechnique = 26;

		public const ushort HitRateSpeed = 27;

		public const ushort HitRateMind = 28;

		public const ushort PenetrateOfOuter = 29;

		public const ushort PenetrateOfInner = 30;

		public const ushort AvoidRateStrength = 31;

		public const ushort AvoidRateTechnique = 32;

		public const ushort AvoidRateSpeed = 33;

		public const ushort AvoidRateMind = 34;

		public const ushort PenetrateResistOfOuter = 35;

		public const ushort PenetrateResistOfInner = 36;

		public const ushort InnerRatio = 37;

		public const ushort RecoveryOfQiDisorder = 38;

		public const ushort BaseFavorabilityChange = 39;

		public const ushort BaseHappinessChange = 40;

		public const ushort GiftLevel = 41;

		public const ushort SolarTermType = 42;

		public const ushort EatHappinessChange = 43;

		public const ushort GroupId = 44;

		public const ushort BreakBonusEffect = 45;

		public const ushort AllowRandomCreate = 46;

		public const ushort MerchantLevel = 47;

		public const ushort Inheritable = 48;

		public const ushort ActionPointRecover = 49;

		public const ushort IsSpecial = 50;

		public const ushort BigIcon = 51;

		public const ushort UseFrame = 52;

		public const ushort TaskLock = 53;

		public const ushort FunctionDesc = 54;
	}

	/// <summary>
	/// 档案数据字段数 (可能也是模板数据)
	/// </summary>
	public const ushort ArchiveFieldsCount = 5;

	/// <summary>
	/// 缓存数据字段数
	/// </summary>
	public const ushort CacheFieldsCount = 0;

	/// <summary>
	/// 纯模板数据字段数 (不同时是档案数据)
	/// </summary>
	public const ushort PureTemplateFieldsCount = 50;

	/// <summary>
	/// 可变数据字段数 (档案字段数与缓存字段数之和)
	/// </summary>
	public const ushort WritableFieldsCount = 5;

	/// <summary>
	/// 只读数据字段数 (模板字段数)
	/// </summary>
	public const ushort ReadonlyFieldsCount = 50;

	/// <summary>
	/// 通过字段名获取字段 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "TemplateId", 1 },
		{ "MaxDurability", 2 },
		{ "CurrDurability", 3 },
		{ "ModificationState", 4 },
		{ "Name", 5 },
		{ "ItemType", 6 },
		{ "ItemSubType", 7 },
		{ "Grade", 8 },
		{ "Icon", 9 },
		{ "Desc", 10 },
		{ "Transferable", 11 },
		{ "Stackable", 12 },
		{ "Wagerable", 13 },
		{ "Refinable", 14 },
		{ "Poisonable", 15 },
		{ "Repairable", 16 },
		{ "BaseWeight", 17 },
		{ "BaseValue", 18 },
		{ "DropRate", 19 },
		{ "ResourceType", 20 },
		{ "PreservationDuration", 21 },
		{ "Duration", 22 },
		{ "DirectChangeOfQiDisorder", 23 },
		{ "ConsumedFeatureMedals", 24 },
		{ "HitRateStrength", 25 },
		{ "HitRateTechnique", 26 },
		{ "HitRateSpeed", 27 },
		{ "HitRateMind", 28 },
		{ "PenetrateOfOuter", 29 },
		{ "PenetrateOfInner", 30 },
		{ "AvoidRateStrength", 31 },
		{ "AvoidRateTechnique", 32 },
		{ "AvoidRateSpeed", 33 },
		{ "AvoidRateMind", 34 },
		{ "PenetrateResistOfOuter", 35 },
		{ "PenetrateResistOfInner", 36 },
		{ "InnerRatio", 37 },
		{ "RecoveryOfQiDisorder", 38 },
		{ "BaseFavorabilityChange", 39 },
		{ "BaseHappinessChange", 40 },
		{ "GiftLevel", 41 },
		{ "SolarTermType", 42 },
		{ "EatHappinessChange", 43 },
		{ "GroupId", 44 },
		{ "BreakBonusEffect", 45 },
		{ "AllowRandomCreate", 46 },
		{ "MerchantLevel", 47 },
		{ "Inheritable", 48 },
		{ "ActionPointRecover", 49 },
		{ "IsSpecial", 50 },
		{ "BigIcon", 51 },
		{ "UseFrame", 52 },
		{ "TaskLock", 53 },
		{ "FunctionDesc", 54 }
	};

	/// <summary>
	/// 通过字段 ID 获取字段名
	/// </summary>
	public static readonly string[] FieldId2FieldName = new string[55]
	{
		"Id", "TemplateId", "MaxDurability", "CurrDurability", "ModificationState", "Name", "ItemType", "ItemSubType", "Grade", "Icon",
		"Desc", "Transferable", "Stackable", "Wagerable", "Refinable", "Poisonable", "Repairable", "BaseWeight", "BaseValue", "DropRate",
		"ResourceType", "PreservationDuration", "Duration", "DirectChangeOfQiDisorder", "ConsumedFeatureMedals", "HitRateStrength", "HitRateTechnique", "HitRateSpeed", "HitRateMind", "PenetrateOfOuter",
		"PenetrateOfInner", "AvoidRateStrength", "AvoidRateTechnique", "AvoidRateSpeed", "AvoidRateMind", "PenetrateResistOfOuter", "PenetrateResistOfInner", "InnerRatio", "RecoveryOfQiDisorder", "BaseFavorabilityChange",
		"BaseHappinessChange", "GiftLevel", "SolarTermType", "EatHappinessChange", "GroupId", "BreakBonusEffect", "AllowRandomCreate", "MerchantLevel", "Inheritable", "ActionPointRecover",
		"IsSpecial", "BigIcon", "UseFrame", "TaskLock", "FunctionDesc"
	};
}
