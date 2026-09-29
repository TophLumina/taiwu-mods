using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterDeathType : ConfigData<CharacterDeathTypeItem, short>
{
	public static class DefKey
	{
		public const short Unknown = 0;

		public const short NaturalDeath = 1;

		public const short LowHealth = 2;

		public const short ExecutedInPrivate = 3;

		public const short ExecutedInPublic = 4;

		public const short EnemyNest = 5;

		public const short Disaster = 6;

		public const short AssassinationByJieqing = 7;

		public const short WuYingOwner = 8;

		public const short KilledInStoneRoom = 9;

		public const short XiangshuMinion = 10;

		public const short LongYufu = 11;

		public const short DayueYaochang = 12;

		public const short JuniorDayueYaochang = 13;

		public const short Jixi = 14;

		public const short ProtectHeavenlyTree = 15;

		public const short DarkAshKill = 16;

		public const short BecomeNoMindGuy = 17;
	}

	public static class DefValue
	{
		public static CharacterDeathTypeItem Unknown => Instance[(short)0];

		public static CharacterDeathTypeItem NaturalDeath => Instance[(short)1];

		public static CharacterDeathTypeItem LowHealth => Instance[(short)2];

		public static CharacterDeathTypeItem ExecutedInPrivate => Instance[(short)3];

		public static CharacterDeathTypeItem ExecutedInPublic => Instance[(short)4];

		public static CharacterDeathTypeItem EnemyNest => Instance[(short)5];

		public static CharacterDeathTypeItem Disaster => Instance[(short)6];

		public static CharacterDeathTypeItem AssassinationByJieqing => Instance[(short)7];

		public static CharacterDeathTypeItem WuYingOwner => Instance[(short)8];

		public static CharacterDeathTypeItem KilledInStoneRoom => Instance[(short)9];

		public static CharacterDeathTypeItem XiangshuMinion => Instance[(short)10];

		public static CharacterDeathTypeItem LongYufu => Instance[(short)11];

		public static CharacterDeathTypeItem DayueYaochang => Instance[(short)12];

		public static CharacterDeathTypeItem JuniorDayueYaochang => Instance[(short)13];

		public static CharacterDeathTypeItem Jixi => Instance[(short)14];

		public static CharacterDeathTypeItem ProtectHeavenlyTree => Instance[(short)15];

		public static CharacterDeathTypeItem DarkAshKill => Instance[(short)16];

		public static CharacterDeathTypeItem BecomeNoMindGuy => Instance[(short)17];
	}

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
