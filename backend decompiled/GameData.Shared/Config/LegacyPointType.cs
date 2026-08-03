using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LegacyPointType : ConfigData<LegacyPointTypeItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 结缘
		/// </summary>
		public const sbyte Relation = 0;

		/// <summary>
		/// 战斗
		/// </summary>
		public const sbyte Combat = 1;

		/// <summary>
		/// 技艺
		/// </summary>
		public const sbyte LifeSkill = 2;

		/// <summary>
		/// 武学
		/// </summary>
		public const sbyte CombatSkill = 3;

		/// <summary>
		/// 产业
		/// </summary>
		public const sbyte Building = 4;

		/// <summary>
		/// 游历
		/// </summary>
		public const sbyte Journey = 5;

		/// <summary>
		/// 剑冢
		/// </summary>
		public const sbyte SwordTomb = 6;

		/// <summary>
		/// 志向
		/// </summary>
		public const sbyte Profession = 7;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 结缘
		/// </summary>
		public static LegacyPointTypeItem Relation => Instance[(sbyte)0];

		/// <summary>
		/// 战斗
		/// </summary>
		public static LegacyPointTypeItem Combat => Instance[(sbyte)1];

		/// <summary>
		/// 技艺
		/// </summary>
		public static LegacyPointTypeItem LifeSkill => Instance[(sbyte)2];

		/// <summary>
		/// 武学
		/// </summary>
		public static LegacyPointTypeItem CombatSkill => Instance[(sbyte)3];

		/// <summary>
		/// 产业
		/// </summary>
		public static LegacyPointTypeItem Building => Instance[(sbyte)4];

		/// <summary>
		/// 游历
		/// </summary>
		public static LegacyPointTypeItem Journey => Instance[(sbyte)5];

		/// <summary>
		/// 剑冢
		/// </summary>
		public static LegacyPointTypeItem SwordTomb => Instance[(sbyte)6];

		/// <summary>
		/// 志向
		/// </summary>
		public static LegacyPointTypeItem Profession => Instance[(sbyte)7];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static LegacyPointType Instance = new LegacyPointType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Group", "TemplateId" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new LegacyPointTypeItem(0, LocalStringManager.GetConfig("LegacyPointType_language", "Name_0"), 1));
		_dataArray.Add(new LegacyPointTypeItem(1, LocalStringManager.GetConfig("LegacyPointType_language", "Name_1"), 0));
		_dataArray.Add(new LegacyPointTypeItem(2, LocalStringManager.GetConfig("LegacyPointType_language", "Name_2"), 2));
		_dataArray.Add(new LegacyPointTypeItem(3, LocalStringManager.GetConfig("LegacyPointType_language", "Name_3"), 2));
		_dataArray.Add(new LegacyPointTypeItem(4, LocalStringManager.GetConfig("LegacyPointType_language", "Name_4"), 1));
		_dataArray.Add(new LegacyPointTypeItem(5, LocalStringManager.GetConfig("LegacyPointType_language", "Name_5"), 0));
		_dataArray.Add(new LegacyPointTypeItem(6, LocalStringManager.GetConfig("LegacyPointType_language", "Name_6"), 0));
		_dataArray.Add(new LegacyPointTypeItem(7, LocalStringManager.GetConfig("LegacyPointType_language", "Name_7"), 2));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LegacyPointTypeItem>(8);
		CreateItems0();
	}
}
