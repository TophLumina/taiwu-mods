using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class PersonalNeed : ConfigData<PersonalNeedItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 需求-恢复心情
		/// </summary>
		public const sbyte IncreaseHappiness = 0;

		/// <summary>
		/// 需求-恢复健康
		/// </summary>
		public const sbyte IncreaseHealth = 1;

		/// <summary>
		/// 需求-调理内息
		/// </summary>
		public const sbyte RestoreDisorderOfQi = 2;

		/// <summary>
		/// 需求-恢复内力
		/// </summary>
		public const sbyte IncreaseNeili = 3;

		/// <summary>
		/// 需求-治疗伤势
		/// </summary>
		public const sbyte HealInjury = 4;

		/// <summary>
		/// 需求-驱除毒素
		/// </summary>
		public const sbyte HealPoison = 5;

		/// <summary>
		/// 需求-恢复属性
		/// </summary>
		public const sbyte RecoverMainAttribute = 6;

		/// <summary>
		/// 需求-杀灭蛊虫
		/// </summary>
		public const sbyte KillWug = 7;

		/// <summary>
		/// 需求-获取资源
		/// </summary>
		public const sbyte GainResource = 8;

		/// <summary>
		/// 需求-花费资源
		/// </summary>
		public const sbyte SpendResource = 9;

		/// <summary>
		/// 需求-需要道具
		/// </summary>
		public const sbyte GainItem = 10;

		/// <summary>
		/// 需求-修理道具
		/// </summary>
		public const sbyte RepairItem = 11;

		/// <summary>
		/// 需求-淬毒道具
		/// </summary>
		public const sbyte AddPoisonToItem = 12;

		/// <summary>
		/// 需求-花费道具
		/// </summary>
		public const sbyte SpendItem = 13;

		/// <summary>
		/// 需求-学习武学
		/// </summary>
		public const sbyte LearnCombatSkill = 14;

		/// <summary>
		/// 需求-学习技艺
		/// </summary>
		public const sbyte LearnLifeSkill = 15;

		/// <summary>
		/// 需求-需要历练
		/// </summary>
		public const sbyte GainExp = 16;

		/// <summary>
		/// 需求-请教研读
		/// </summary>
		public const sbyte AskForHelpOnReading = 17;

		/// <summary>
		/// 需求-请教突破
		/// </summary>
		public const sbyte AskForHelpOnBreakout = 18;

		/// <summary>
		/// 需求-关怀人物
		/// </summary>
		public const sbyte TakeCareOfOther = 19;

		/// <summary>
		/// 需求-组成队伍
		/// </summary>
		public const sbyte TeamUp = 20;

		/// <summary>
		/// 需求-寻仇报复
		/// </summary>
		public const sbyte GetRevenge = 21;

		/// <summary>
		/// 需求-祭拜故人
		/// </summary>
		public const sbyte MournForTheDead = 22;

		/// <summary>
		/// 需求-共度春宵
		/// </summary>
		public const sbyte MakeLove = 23;

		/// <summary>
		/// 需求-寻找宝藏
		/// </summary>
		public const sbyte FindTreasure = 24;

		/// <summary>
		/// 需求-结成关系
		/// </summary>
		public const sbyte CreateRelation = 25;

		/// <summary>
		/// 需求-加入组织
		/// </summary>
		public const sbyte JoinOrganization = 26;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 需求-恢复心情
		/// </summary>
		public static PersonalNeedItem IncreaseHappiness => Instance[(sbyte)0];

		/// <summary>
		/// 需求-恢复健康
		/// </summary>
		public static PersonalNeedItem IncreaseHealth => Instance[(sbyte)1];

		/// <summary>
		/// 需求-调理内息
		/// </summary>
		public static PersonalNeedItem RestoreDisorderOfQi => Instance[(sbyte)2];

		/// <summary>
		/// 需求-恢复内力
		/// </summary>
		public static PersonalNeedItem IncreaseNeili => Instance[(sbyte)3];

		/// <summary>
		/// 需求-治疗伤势
		/// </summary>
		public static PersonalNeedItem HealInjury => Instance[(sbyte)4];

		/// <summary>
		/// 需求-驱除毒素
		/// </summary>
		public static PersonalNeedItem HealPoison => Instance[(sbyte)5];

		/// <summary>
		/// 需求-恢复属性
		/// </summary>
		public static PersonalNeedItem RecoverMainAttribute => Instance[(sbyte)6];

		/// <summary>
		/// 需求-杀灭蛊虫
		/// </summary>
		public static PersonalNeedItem KillWug => Instance[(sbyte)7];

		/// <summary>
		/// 需求-获取资源
		/// </summary>
		public static PersonalNeedItem GainResource => Instance[(sbyte)8];

		/// <summary>
		/// 需求-花费资源
		/// </summary>
		public static PersonalNeedItem SpendResource => Instance[(sbyte)9];

		/// <summary>
		/// 需求-需要道具
		/// </summary>
		public static PersonalNeedItem GainItem => Instance[(sbyte)10];

		/// <summary>
		/// 需求-修理道具
		/// </summary>
		public static PersonalNeedItem RepairItem => Instance[(sbyte)11];

		/// <summary>
		/// 需求-淬毒道具
		/// </summary>
		public static PersonalNeedItem AddPoisonToItem => Instance[(sbyte)12];

		/// <summary>
		/// 需求-花费道具
		/// </summary>
		public static PersonalNeedItem SpendItem => Instance[(sbyte)13];

		/// <summary>
		/// 需求-学习武学
		/// </summary>
		public static PersonalNeedItem LearnCombatSkill => Instance[(sbyte)14];

		/// <summary>
		/// 需求-学习技艺
		/// </summary>
		public static PersonalNeedItem LearnLifeSkill => Instance[(sbyte)15];

		/// <summary>
		/// 需求-需要历练
		/// </summary>
		public static PersonalNeedItem GainExp => Instance[(sbyte)16];

		/// <summary>
		/// 需求-请教研读
		/// </summary>
		public static PersonalNeedItem AskForHelpOnReading => Instance[(sbyte)17];

		/// <summary>
		/// 需求-请教突破
		/// </summary>
		public static PersonalNeedItem AskForHelpOnBreakout => Instance[(sbyte)18];

		/// <summary>
		/// 需求-关怀人物
		/// </summary>
		public static PersonalNeedItem TakeCareOfOther => Instance[(sbyte)19];

		/// <summary>
		/// 需求-组成队伍
		/// </summary>
		public static PersonalNeedItem TeamUp => Instance[(sbyte)20];

		/// <summary>
		/// 需求-寻仇报复
		/// </summary>
		public static PersonalNeedItem GetRevenge => Instance[(sbyte)21];

		/// <summary>
		/// 需求-祭拜故人
		/// </summary>
		public static PersonalNeedItem MournForTheDead => Instance[(sbyte)22];

		/// <summary>
		/// 需求-共度春宵
		/// </summary>
		public static PersonalNeedItem MakeLove => Instance[(sbyte)23];

		/// <summary>
		/// 需求-寻找宝藏
		/// </summary>
		public static PersonalNeedItem FindTreasure => Instance[(sbyte)24];

		/// <summary>
		/// 需求-结成关系
		/// </summary>
		public static PersonalNeedItem CreateRelation => Instance[(sbyte)25];

		/// <summary>
		/// 需求-加入组织
		/// </summary>
		public static PersonalNeedItem JoinOrganization => Instance[(sbyte)26];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static PersonalNeed Instance = new PersonalNeed();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId" };

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
		_dataArray.Add(new PersonalNeedItem(0, LocalStringManager.GetConfig("PersonalNeed_language", "Name_0"), matchType: false, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(1, LocalStringManager.GetConfig("PersonalNeed_language", "Name_1"), matchType: false, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(2, LocalStringManager.GetConfig("PersonalNeed_language", "Name_2"), matchType: false, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(3, LocalStringManager.GetConfig("PersonalNeed_language", "Name_3"), matchType: false, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(4, LocalStringManager.GetConfig("PersonalNeed_language", "Name_4"), matchType: true, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(5, LocalStringManager.GetConfig("PersonalNeed_language", "Name_5"), matchType: true, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(6, LocalStringManager.GetConfig("PersonalNeed_language", "Name_6"), matchType: true, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(7, LocalStringManager.GetConfig("PersonalNeed_language", "Name_7"), matchType: true, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(8, LocalStringManager.GetConfig("PersonalNeed_language", "Name_8"), matchType: true, overwrite: false, combine: true, 3));
		_dataArray.Add(new PersonalNeedItem(9, LocalStringManager.GetConfig("PersonalNeed_language", "Name_9"), matchType: true, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(10, LocalStringManager.GetConfig("PersonalNeed_language", "Name_10"), matchType: true, overwrite: false, combine: false, 6));
		_dataArray.Add(new PersonalNeedItem(11, LocalStringManager.GetConfig("PersonalNeed_language", "Name_11"), matchType: true, overwrite: false, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(12, LocalStringManager.GetConfig("PersonalNeed_language", "Name_12"), matchType: true, overwrite: false, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(13, LocalStringManager.GetConfig("PersonalNeed_language", "Name_13"), matchType: false, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(14, LocalStringManager.GetConfig("PersonalNeed_language", "Name_14"), matchType: true, overwrite: false, combine: false, 12));
		_dataArray.Add(new PersonalNeedItem(15, LocalStringManager.GetConfig("PersonalNeed_language", "Name_15"), matchType: true, overwrite: false, combine: false, 12));
		_dataArray.Add(new PersonalNeedItem(16, LocalStringManager.GetConfig("PersonalNeed_language", "Name_16"), matchType: false, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(17, LocalStringManager.GetConfig("PersonalNeed_language", "Name_17"), matchType: false, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(18, LocalStringManager.GetConfig("PersonalNeed_language", "Name_18"), matchType: false, overwrite: true, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(19, LocalStringManager.GetConfig("PersonalNeed_language", "Name_19"), matchType: false, overwrite: false, combine: false, 36));
		_dataArray.Add(new PersonalNeedItem(20, LocalStringManager.GetConfig("PersonalNeed_language", "Name_20"), matchType: false, overwrite: false, combine: false, 6));
		_dataArray.Add(new PersonalNeedItem(21, LocalStringManager.GetConfig("PersonalNeed_language", "Name_21"), matchType: false, overwrite: false, combine: false, 9));
		_dataArray.Add(new PersonalNeedItem(22, LocalStringManager.GetConfig("PersonalNeed_language", "Name_22"), matchType: false, overwrite: false, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(23, LocalStringManager.GetConfig("PersonalNeed_language", "Name_23"), matchType: false, overwrite: false, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(24, LocalStringManager.GetConfig("PersonalNeed_language", "Name_24"), matchType: false, overwrite: false, combine: false, 6));
		_dataArray.Add(new PersonalNeedItem(25, LocalStringManager.GetConfig("PersonalNeed_language", "Name_25"), matchType: true, overwrite: false, combine: false, 3));
		_dataArray.Add(new PersonalNeedItem(26, LocalStringManager.GetConfig("PersonalNeed_language", "Name_26"), matchType: false, overwrite: false, combine: false, 12));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<PersonalNeedItem>(27);
		CreateItems0();
	}
}
