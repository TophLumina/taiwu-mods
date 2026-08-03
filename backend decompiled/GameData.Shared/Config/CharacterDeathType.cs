using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterDeathType : ConfigData<CharacterDeathTypeItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 未知原因
		/// </summary>
		public const short Unknown = 0;

		/// <summary>
		/// 寿终正寝
		/// </summary>
		public const short NaturalDeath = 1;

		/// <summary>
		/// 健康过低
		/// </summary>
		public const short LowHealth = 2;

		/// <summary>
		/// 秘密处决
		/// </summary>
		public const short ExecutedInPrivate = 3;

		/// <summary>
		/// 公开处决
		/// </summary>
		public const short ExecutedInPublic = 4;

		/// <summary>
		/// 外道巢穴
		/// </summary>
		public const short EnemyNest = 5;

		/// <summary>
		/// 天灾
		/// </summary>
		public const short Disaster = 6;

		/// <summary>
		/// 界青暗杀
		/// </summary>
		public const short AssassinationByJieqing = 7;

		/// <summary>
		/// 无影令
		/// </summary>
		public const short WuYingOwner = 8;

		/// <summary>
		/// 石牢了断
		/// </summary>
		public const short KilledInStoneRoom = 9;

		/// <summary>
		/// 相枢爪牙
		/// </summary>
		public const short XiangshuMinion = 10;

		/// <summary>
		/// 龙语茯
		/// </summary>
		public const short LongYufu = 11;

		/// <summary>
		/// 大岳瑶常
		/// </summary>
		public const short DayueYaochang = 12;

		/// <summary>
		/// 小大岳瑶常
		/// </summary>
		public const short JuniorDayueYaochang = 13;

		/// <summary>
		/// 姬穸
		/// </summary>
		public const short Jixi = 14;

		/// <summary>
		/// 保卫神木
		/// </summary>
		public const short ProtectHeavenlyTree = 15;

		/// <summary>
		/// 玄灰绝命
		/// </summary>
		public const short DarkAshKill = 16;

		/// <summary>
		/// 绝念泥丸
		/// </summary>
		public const short BecomeNoMindGuy = 17;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 未知原因
		/// </summary>
		public static CharacterDeathTypeItem Unknown => Instance[(short)0];

		/// <summary>
		/// 寿终正寝
		/// </summary>
		public static CharacterDeathTypeItem NaturalDeath => Instance[(short)1];

		/// <summary>
		/// 健康过低
		/// </summary>
		public static CharacterDeathTypeItem LowHealth => Instance[(short)2];

		/// <summary>
		/// 秘密处决
		/// </summary>
		public static CharacterDeathTypeItem ExecutedInPrivate => Instance[(short)3];

		/// <summary>
		/// 公开处决
		/// </summary>
		public static CharacterDeathTypeItem ExecutedInPublic => Instance[(short)4];

		/// <summary>
		/// 外道巢穴
		/// </summary>
		public static CharacterDeathTypeItem EnemyNest => Instance[(short)5];

		/// <summary>
		/// 天灾
		/// </summary>
		public static CharacterDeathTypeItem Disaster => Instance[(short)6];

		/// <summary>
		/// 界青暗杀
		/// </summary>
		public static CharacterDeathTypeItem AssassinationByJieqing => Instance[(short)7];

		/// <summary>
		/// 无影令
		/// </summary>
		public static CharacterDeathTypeItem WuYingOwner => Instance[(short)8];

		/// <summary>
		/// 石牢了断
		/// </summary>
		public static CharacterDeathTypeItem KilledInStoneRoom => Instance[(short)9];

		/// <summary>
		/// 相枢爪牙
		/// </summary>
		public static CharacterDeathTypeItem XiangshuMinion => Instance[(short)10];

		/// <summary>
		/// 龙语茯
		/// </summary>
		public static CharacterDeathTypeItem LongYufu => Instance[(short)11];

		/// <summary>
		/// 大岳瑶常
		/// </summary>
		public static CharacterDeathTypeItem DayueYaochang => Instance[(short)12];

		/// <summary>
		/// 小大岳瑶常
		/// </summary>
		public static CharacterDeathTypeItem JuniorDayueYaochang => Instance[(short)13];

		/// <summary>
		/// 姬穸
		/// </summary>
		public static CharacterDeathTypeItem Jixi => Instance[(short)14];

		/// <summary>
		/// 保卫神木
		/// </summary>
		public static CharacterDeathTypeItem ProtectHeavenlyTree => Instance[(short)15];

		/// <summary>
		/// 玄灰绝命
		/// </summary>
		public static CharacterDeathTypeItem DarkAshKill => Instance[(short)16];

		/// <summary>
		/// 绝念泥丸
		/// </summary>
		public static CharacterDeathTypeItem BecomeNoMindGuy => Instance[(short)17];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CharacterDeathType Instance = new CharacterDeathType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "DefaultLifeRecord", "DefaultMonthlyNotification", "TemplateId" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new CharacterDeathTypeItem(0, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_0"), 0, 17, notifyTaiwuPeopleOnly: true, findUndertaker: false));
		_dataArray.Add(new CharacterDeathTypeItem(1, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_1"), 710, 298, notifyTaiwuPeopleOnly: true, findUndertaker: true));
		_dataArray.Add(new CharacterDeathTypeItem(2, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_2"), 711, 299, notifyTaiwuPeopleOnly: true, findUndertaker: true));
		_dataArray.Add(new CharacterDeathTypeItem(3, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_3"), -1, -1, notifyTaiwuPeopleOnly: true, findUndertaker: false));
		_dataArray.Add(new CharacterDeathTypeItem(4, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_4"), -1, 300, notifyTaiwuPeopleOnly: true, findUndertaker: true));
		_dataArray.Add(new CharacterDeathTypeItem(5, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_5"), 665, 270, notifyTaiwuPeopleOnly: true, findUndertaker: false));
		_dataArray.Add(new CharacterDeathTypeItem(6, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_6"), 430, 17, notifyTaiwuPeopleOnly: true, findUndertaker: true));
		_dataArray.Add(new CharacterDeathTypeItem(7, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_7"), 715, 15, notifyTaiwuPeopleOnly: false, findUndertaker: false));
		_dataArray.Add(new CharacterDeathTypeItem(8, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_8"), 429, 16, notifyTaiwuPeopleOnly: false, findUndertaker: false));
		_dataArray.Add(new CharacterDeathTypeItem(9, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_9"), 714, -1, notifyTaiwuPeopleOnly: false, findUndertaker: false));
		_dataArray.Add(new CharacterDeathTypeItem(10, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_10"), 716, 17, notifyTaiwuPeopleOnly: true, findUndertaker: true));
		_dataArray.Add(new CharacterDeathTypeItem(11, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_11"), 427, -1, notifyTaiwuPeopleOnly: false, findUndertaker: false));
		_dataArray.Add(new CharacterDeathTypeItem(12, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_12"), 386, -1, notifyTaiwuPeopleOnly: false, findUndertaker: false));
		_dataArray.Add(new CharacterDeathTypeItem(13, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_13"), 394, -1, notifyTaiwuPeopleOnly: false, findUndertaker: false));
		_dataArray.Add(new CharacterDeathTypeItem(14, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_14"), 630, 17, notifyTaiwuPeopleOnly: false, findUndertaker: false));
		_dataArray.Add(new CharacterDeathTypeItem(15, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_15"), 660, 263, notifyTaiwuPeopleOnly: true, findUndertaker: true));
		_dataArray.Add(new CharacterDeathTypeItem(16, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_16"), 1133, 394, notifyTaiwuPeopleOnly: true, findUndertaker: true));
		_dataArray.Add(new CharacterDeathTypeItem(17, LocalStringManager.GetConfig("CharacterDeathType_language", "Name_17"), 0, -1, notifyTaiwuPeopleOnly: false, findUndertaker: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CharacterDeathTypeItem>(18);
		CreateItems0();
	}
}
