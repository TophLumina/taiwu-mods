using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class SecretInformationAppliedSelection : ConfigData<SecretInformationAppliedSelectionItem, short>
{
	public static class DefKey
	{
		public const short OtherTopics = 0;

		public const short Agree = 1;

		public const short Disagree = 2;

		public const short Comfort = 3;

		public const short Gloat = 4;

		public const short Criticize = 5;

		public const short Support = 6;

		public const short Praise = 7;

		public const short Mock = 8;

		public const short Angry = 9;

		public const short Hurt = 10;

		public const short Punish = 11;

		public const short KillForRevenge = 12;

		public const short Provoke = 13;

		public const short RequestKeepSecret = 14;

		public const short ArgeeKeepSecret = 15;

		public const short RefuseKeepSecret = 16;

		public const short RequestRelease = 17;

		public const short RequestPrisoner = 18;

		public const short AgreeRelease = 19;

		public const short RefuseRelease = 20;

		public const short AgreeTransfer = 21;

		public const short RefuseTransfer = 22;

		public const short PrisonerAbsent = 23;

		public const short PrisonerAbsent2 = 24;

		public const short RescueByStealing = 25;

		public const short RescueByScamming = 26;

		public const short RescueByRobbing = 27;

		public const short RobPrisonerByStealing = 28;

		public const short RobPrisonerByScamming = 29;

		public const short RobPrisonerByRobbing = 30;

		public const short MakeEnemy = 31;

		public const short BeMadeEnemy = 32;

		public const short BreakUp = 33;

		public const short SeverSworn = 34;

		public const short SeverFriend = 35;

		public const short StartCombatByCharacter = 36;

		public const short Relieved = 37;

		public const short NoOtherWay = 38;

		public const short Slient = 39;

		public const short KillForKeepSecret = 40;

		public const short CombatRefuseKeepSecret = 41;

		public const short RespondCombat = 42;

		public const short DirectKidnap = 43;

		public const short DirectKidnap2 = 44;

		public const short DirectPunishKidnap = 45;

		public const short DirectKill = 46;

		public const short GiveUp = 47;

		public const short KidnapWithRope = 48;

		public const short GiveUpKidnapByBeat = 49;

		public const short GiveUpKidnapByKill = 50;

		public const short GiveUpKidnapByPunish = 51;

		public const short BeKilled = 52;

		public const short TryEscapeRescue = 53;

		public const short TryEscapeRob = 54;

		public const short HandlePrisoner = 55;

		public const short KidnapInPublicByRob = 56;

		public const short KidnapInPrivateByRob = 57;

		public const short HandlePrisoner2 = 58;

		public const short KidnapInPublicByRob2 = 59;

		public const short KidnapInPrivateByRob2 = 60;

		public const short KillInPublicByRob = 61;

		public const short KillForPunishByRob = 62;

		public const short GiveUpByRob = 63;

		public const short KidnapDetainerInPublic = 64;

		public const short KidnapDetainerInPrivate = 65;

		public const short TaiwuEscape = 66;

		public const short CharEscape = 67;

		public const short KillInPublic = 68;

		public const short KillForPunish = 69;

		public const short KillInPrivate = 70;

		public const short KidnapInPublic = 71;

		public const short KidnapForPunish = 72;

		public const short KidnapInPrivate = 73;

		public const short ScamDebating = 74;

		public const short RescueByChar = 75;

		public const short RobByChar = 76;

		public const short ResistStealPrisoner = 77;

		public const short NotResistStealPrisoner = 78;

		public const short ResistScamPrisoner = 79;

		public const short NotResistScamPrisoner = 80;

		public const short NotResistRobPrisonerEnemy = 81;

		public const short NotResistRobPrisoner = 82;

		public const short HandInPrisoner = 83;

		public const short ResistRobPrisoner = 84;

		public const short PrisonerRobbed = 85;

		public const short Threaten = 86;

		public const short SectLeaderKnown = 87;

		public const short ThreadPointer = 88;

		public const short AskCharBreakUp = 89;

		public const short BreakUpChar = 90;

		public const short ForceBreakUpChar = 91;

		public const short GiveUpWithLove = 92;

		public const short Admonish = 93;
	}

	public static class DefValue
	{
		public static SecretInformationAppliedSelectionItem OtherTopics => Instance[(short)0];

		public static SecretInformationAppliedSelectionItem Agree => Instance[(short)1];

		public static SecretInformationAppliedSelectionItem Disagree => Instance[(short)2];

		public static SecretInformationAppliedSelectionItem Comfort => Instance[(short)3];

		public static SecretInformationAppliedSelectionItem Gloat => Instance[(short)4];

		public static SecretInformationAppliedSelectionItem Criticize => Instance[(short)5];

		public static SecretInformationAppliedSelectionItem Support => Instance[(short)6];

		public static SecretInformationAppliedSelectionItem Praise => Instance[(short)7];

		public static SecretInformationAppliedSelectionItem Mock => Instance[(short)8];

		public static SecretInformationAppliedSelectionItem Angry => Instance[(short)9];

		public static SecretInformationAppliedSelectionItem Hurt => Instance[(short)10];

		public static SecretInformationAppliedSelectionItem Punish => Instance[(short)11];

		public static SecretInformationAppliedSelectionItem KillForRevenge => Instance[(short)12];

		public static SecretInformationAppliedSelectionItem Provoke => Instance[(short)13];

		public static SecretInformationAppliedSelectionItem RequestKeepSecret => Instance[(short)14];

		public static SecretInformationAppliedSelectionItem ArgeeKeepSecret => Instance[(short)15];

		public static SecretInformationAppliedSelectionItem RefuseKeepSecret => Instance[(short)16];

		public static SecretInformationAppliedSelectionItem RequestRelease => Instance[(short)17];

		public static SecretInformationAppliedSelectionItem RequestPrisoner => Instance[(short)18];

		public static SecretInformationAppliedSelectionItem AgreeRelease => Instance[(short)19];

		public static SecretInformationAppliedSelectionItem RefuseRelease => Instance[(short)20];

		public static SecretInformationAppliedSelectionItem AgreeTransfer => Instance[(short)21];

		public static SecretInformationAppliedSelectionItem RefuseTransfer => Instance[(short)22];

		public static SecretInformationAppliedSelectionItem PrisonerAbsent => Instance[(short)23];

		public static SecretInformationAppliedSelectionItem PrisonerAbsent2 => Instance[(short)24];

		public static SecretInformationAppliedSelectionItem RescueByStealing => Instance[(short)25];

		public static SecretInformationAppliedSelectionItem RescueByScamming => Instance[(short)26];

		public static SecretInformationAppliedSelectionItem RescueByRobbing => Instance[(short)27];

		public static SecretInformationAppliedSelectionItem RobPrisonerByStealing => Instance[(short)28];

		public static SecretInformationAppliedSelectionItem RobPrisonerByScamming => Instance[(short)29];

		public static SecretInformationAppliedSelectionItem RobPrisonerByRobbing => Instance[(short)30];

		public static SecretInformationAppliedSelectionItem MakeEnemy => Instance[(short)31];

		public static SecretInformationAppliedSelectionItem BeMadeEnemy => Instance[(short)32];

		public static SecretInformationAppliedSelectionItem BreakUp => Instance[(short)33];

		public static SecretInformationAppliedSelectionItem SeverSworn => Instance[(short)34];

		public static SecretInformationAppliedSelectionItem SeverFriend => Instance[(short)35];

		public static SecretInformationAppliedSelectionItem StartCombatByCharacter => Instance[(short)36];

		public static SecretInformationAppliedSelectionItem Relieved => Instance[(short)37];

		public static SecretInformationAppliedSelectionItem NoOtherWay => Instance[(short)38];

		public static SecretInformationAppliedSelectionItem Slient => Instance[(short)39];

		public static SecretInformationAppliedSelectionItem KillForKeepSecret => Instance[(short)40];

		public static SecretInformationAppliedSelectionItem CombatRefuseKeepSecret => Instance[(short)41];

		public static SecretInformationAppliedSelectionItem RespondCombat => Instance[(short)42];

		public static SecretInformationAppliedSelectionItem DirectKidnap => Instance[(short)43];

		public static SecretInformationAppliedSelectionItem DirectKidnap2 => Instance[(short)44];

		public static SecretInformationAppliedSelectionItem DirectPunishKidnap => Instance[(short)45];

		public static SecretInformationAppliedSelectionItem DirectKill => Instance[(short)46];

		public static SecretInformationAppliedSelectionItem GiveUp => Instance[(short)47];

		public static SecretInformationAppliedSelectionItem KidnapWithRope => Instance[(short)48];

		public static SecretInformationAppliedSelectionItem GiveUpKidnapByBeat => Instance[(short)49];

		public static SecretInformationAppliedSelectionItem GiveUpKidnapByKill => Instance[(short)50];

		public static SecretInformationAppliedSelectionItem GiveUpKidnapByPunish => Instance[(short)51];

		public static SecretInformationAppliedSelectionItem BeKilled => Instance[(short)52];

		public static SecretInformationAppliedSelectionItem TryEscapeRescue => Instance[(short)53];

		public static SecretInformationAppliedSelectionItem TryEscapeRob => Instance[(short)54];

		public static SecretInformationAppliedSelectionItem HandlePrisoner => Instance[(short)55];

		public static SecretInformationAppliedSelectionItem KidnapInPublicByRob => Instance[(short)56];

		public static SecretInformationAppliedSelectionItem KidnapInPrivateByRob => Instance[(short)57];

		public static SecretInformationAppliedSelectionItem HandlePrisoner2 => Instance[(short)58];

		public static SecretInformationAppliedSelectionItem KidnapInPublicByRob2 => Instance[(short)59];

		public static SecretInformationAppliedSelectionItem KidnapInPrivateByRob2 => Instance[(short)60];

		public static SecretInformationAppliedSelectionItem KillInPublicByRob => Instance[(short)61];

		public static SecretInformationAppliedSelectionItem KillForPunishByRob => Instance[(short)62];

		public static SecretInformationAppliedSelectionItem GiveUpByRob => Instance[(short)63];

		public static SecretInformationAppliedSelectionItem KidnapDetainerInPublic => Instance[(short)64];

		public static SecretInformationAppliedSelectionItem KidnapDetainerInPrivate => Instance[(short)65];

		public static SecretInformationAppliedSelectionItem TaiwuEscape => Instance[(short)66];

		public static SecretInformationAppliedSelectionItem CharEscape => Instance[(short)67];

		public static SecretInformationAppliedSelectionItem KillInPublic => Instance[(short)68];

		public static SecretInformationAppliedSelectionItem KillForPunish => Instance[(short)69];

		public static SecretInformationAppliedSelectionItem KillInPrivate => Instance[(short)70];

		public static SecretInformationAppliedSelectionItem KidnapInPublic => Instance[(short)71];

		public static SecretInformationAppliedSelectionItem KidnapForPunish => Instance[(short)72];

		public static SecretInformationAppliedSelectionItem KidnapInPrivate => Instance[(short)73];

		public static SecretInformationAppliedSelectionItem ScamDebating => Instance[(short)74];

		public static SecretInformationAppliedSelectionItem RescueByChar => Instance[(short)75];

		public static SecretInformationAppliedSelectionItem RobByChar => Instance[(short)76];

		public static SecretInformationAppliedSelectionItem ResistStealPrisoner => Instance[(short)77];

		public static SecretInformationAppliedSelectionItem NotResistStealPrisoner => Instance[(short)78];

		public static SecretInformationAppliedSelectionItem ResistScamPrisoner => Instance[(short)79];

		public static SecretInformationAppliedSelectionItem NotResistScamPrisoner => Instance[(short)80];

		public static SecretInformationAppliedSelectionItem NotResistRobPrisonerEnemy => Instance[(short)81];

		public static SecretInformationAppliedSelectionItem NotResistRobPrisoner => Instance[(short)82];

		public static SecretInformationAppliedSelectionItem HandInPrisoner => Instance[(short)83];

		public static SecretInformationAppliedSelectionItem ResistRobPrisoner => Instance[(short)84];

		public static SecretInformationAppliedSelectionItem PrisonerRobbed => Instance[(short)85];

		public static SecretInformationAppliedSelectionItem Threaten => Instance[(short)86];

		public static SecretInformationAppliedSelectionItem SectLeaderKnown => Instance[(short)87];

		public static SecretInformationAppliedSelectionItem ThreadPointer => Instance[(short)88];

		public static SecretInformationAppliedSelectionItem AskCharBreakUp => Instance[(short)89];

		public static SecretInformationAppliedSelectionItem BreakUpChar => Instance[(short)90];

		public static SecretInformationAppliedSelectionItem ForceBreakUpChar => Instance[(short)91];

		public static SecretInformationAppliedSelectionItem GiveUpWithLove => Instance[(short)92];

		public static SecretInformationAppliedSelectionItem Admonish => Instance[(short)93];
	}

	public static SecretInformationAppliedSelection Instance = new SecretInformationAppliedSelection();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Text", "SelectionTexts", "MutexSelectionIds", "MainAttributeCost", "SpecialConditionId", "SpecialConditionId2", "PlayerBehaviorTypeIds", "ResultId1", "ResultId2", "TemplateId" };

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
		_dataArray.Add(new SecretInformationAppliedSelectionItem(0, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_0"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_0_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_0_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_0_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_0_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_0_4")
		}, new short[0], -1, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 0, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Esc));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(1, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_1"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_1_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_1_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_1_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_1_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_1_4")
		}, new short[0], 9001, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 1, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(2, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_2"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_2_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_2_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_2_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_2_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_2_4")
		}, new short[0], 9002, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 2, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(3, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_3"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_3_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_3_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_3_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_3_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_3_4")
		}, new short[0], 9003, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 3, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(4, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_4"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_4_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_4_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_4_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_4_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_4_4")
		}, new short[0], 9004, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[2] { 3, 4 }, -6, 4, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(5, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_5"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_5_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_5_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_5_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_5_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_5_4")
		}, new short[0], 9005, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 6, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(6, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_6"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_6_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_6_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_6_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_6_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_6_4")
		}, new short[0], 9006, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[2] { 3, 4 }, -6, 5, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(7, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_7"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_7_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_7_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_7_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_7_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_7_4")
		}, new short[0], 9007, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 7, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(8, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_8"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_8_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_8_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_8_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_8_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_8_4")
		}, new short[0], 9008, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[2] { 3, 4 }, -6, 8, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(9, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_9"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_9_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_9_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_9_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_9_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_9_4")
		}, new short[0], 9009, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 9, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(10, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_10"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_10_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_10_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_10_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_10_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_10_4")
		}, new short[0], 9010, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 10, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(11, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_11"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_11_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_11_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_11_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_11_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_11_4")
		}, new short[0], 7001, 3, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { 1, 0, 1, -1 }, new short[2] { 0, 1 }, -6, 16, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(12, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_12"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_12_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_12_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_12_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_12_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_12_4")
		}, new short[0], 7002, 3, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 17, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(13, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_13"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_13_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_13_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_13_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_13_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_13_4")
		}, new short[0], 7003, 3, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[2] { 3, 4 }, -6, 15, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(14, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_14"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_14_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_14_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_14_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_14_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_14_4")
		}, new short[0], 1001, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[3] { 2, 3, 4 }, -6, 263, 14, new sbyte[5] { 6, 5, 4, 5, 6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(15, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_15"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_15_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_15_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_15_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_15_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_15_4")
		}, new short[0], 1002, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[3] { 2, 3, 4 }, -6, 11, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(16, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_16"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_16_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_16_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_16_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_16_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_16_4")
		}, new short[0], 1003, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 12, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(17, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_17"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_17_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_17_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_17_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_17_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_17_4")
		}, new short[0], 5001, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(16, 1, 3)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 264, 209, new sbyte[5] { 5, 4, 4, 5, 6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(18, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_18"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_18_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_18_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_18_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_18_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_18_4")
		}, new short[0], 5002, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(16, 1, 3)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 265, 211, new sbyte[5] { 5, 4, 4, 5, 6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(19, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_19"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_19_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_19_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_19_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_19_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_19_4")
		}, new short[0], 5003, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(16, 1, 5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 152, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(20, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_20"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_20_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_20_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_20_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_20_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_20_4")
		}, new short[0], 5004, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(16, 1, 5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 153, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(21, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_21"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_21_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_21_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_21_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_21_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_21_4")
		}, new short[0], 5005, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(16, 1, 5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 154, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(22, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_22"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_22_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_22_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_22_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_22_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_22_4")
		}, new short[0], 5006, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(16, 1, 5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 155, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(23, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_23"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_23_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_23_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_23_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_23_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_23_4")
		}, new short[1], 5007, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(16, 1, 3, 5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 0, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(24, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_24"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_24_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_24_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_24_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_24_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_24_4")
		}, new short[1], 5007, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(16, 1, 5, 5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 0, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(25, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_25"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_25_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_25_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_25_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_25_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_25_4")
		}, new short[0], 5008, 3, new PropertyAndValue(1, 20), new List<ShortList>
		{
			new ShortList(16, 1, 3)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 75, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(26, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_26"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_26_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_26_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_26_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_26_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_26_4")
		}, new short[0], 5009, 3, new PropertyAndValue(2, 20), new List<ShortList>
		{
			new ShortList(16, 1, 3)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 90, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(27, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_27"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_27_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_27_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_27_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_27_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_27_4")
		}, new short[0], 5010, 3, new PropertyAndValue(0, 20), new List<ShortList>
		{
			new ShortList(16, 1, 3)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 99, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(28, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_28"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_28_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_28_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_28_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_28_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_28_4")
		}, new short[0], 5011, 3, new PropertyAndValue(1, 20), new List<ShortList>
		{
			new ShortList(16, 1, 3)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 111, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(29, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_29"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_29_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_29_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_29_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_29_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_29_4")
		}, new short[0], 5012, 3, new PropertyAndValue(2, 20), new List<ShortList>
		{
			new ShortList(16, 1, 3)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 137, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(30, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_30"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_30_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_30_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_30_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_30_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_30_4")
		}, new short[0], 5013, 3, new PropertyAndValue(0, 20), new List<ShortList>
		{
			new ShortList(16, 1, 3)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 146, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(31, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_31"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_31_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_31_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_31_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_31_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_31_4")
		}, new short[0], 8001, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(15, 5, 3, -16, 5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 215, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(32, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_32"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_32_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_32_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_32_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_32_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_32_4")
		}, new short[1], 8002, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(15, 3, 5, -16, 5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 224, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(33, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_33"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_33_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_33_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_33_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_33_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_33_4")
		}, new short[0], 8003, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(15, 5, 3, -12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 218, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(34, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_34"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_34_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_34_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_34_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_34_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_34_4")
		}, new short[0], 8004, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(15, 5, 3, -10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 219, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(35, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_35"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_35_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_35_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_35_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_35_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_35_4")
		}, new short[0], 8005, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(15, 5, 3, -14)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 216, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(36, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_36"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_36_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_36_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_36_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_36_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_36_4")
		}, new short[0], 2001, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 35, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(37, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_37"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_37_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_37_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_37_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_37_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_37_4")
		}, new short[0], 2002, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, -1, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(38, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_38"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_38_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_38_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_38_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_38_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_38_4")
		}, new short[0], 2003, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, -1, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(39, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_39"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_39_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_39_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_39_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_39_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_39_4")
		}, new short[0], 2004, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, -1, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(40, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_40"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_40_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_40_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_40_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_40_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_40_4")
		}, new short[0], 3001, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 17, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(41, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_41"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_41_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_41_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_41_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_41_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_41_4")
		}, new short[0], 3002, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 34, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(42, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_42"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_42_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_42_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_42_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_42_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_42_4")
		}, new short[0], 3003, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 33, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(43, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_43"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_43_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_43_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_43_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_43_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_43_4")
		}, new short[0], 6001, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 70, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(44, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_44"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_44_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_44_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_44_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_44_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_44_4")
		}, new short[0], 6002, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 71, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(45, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_45"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_45_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_45_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_45_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_45_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_45_4")
		}, new short[0], 6003, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 72, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(46, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_46"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_46_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_46_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_46_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_46_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_46_4")
		}, new short[0], 6004, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 22, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(47, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_47"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_47_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_47_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_47_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_47_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_47_4")
		}, new short[0], 6005, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 55, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(48, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_48"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_48_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_48_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_48_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_48_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_48_4")
		}, new short[0], 10001, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 73, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(49, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_49"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_49_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_49_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_49_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_49_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_49_4")
		}, new short[0], 10002, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 69, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(50, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_50"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_50_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_50_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_50_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_50_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_50_4")
		}, new short[0], 10003, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 68, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(51, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_51"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_51_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_51_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_51_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_51_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_51_4")
		}, new short[0], 10004, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 67, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(52, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_52"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_52_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_52_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_52_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_52_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_52_4")
		}, new short[0], 9999, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 64, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(53, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_53"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_53_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_53_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_53_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_53_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_53_4")
		}, new short[0], 8001, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 81, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(54, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_54"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_54_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_54_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_54_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_54_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_54_4")
		}, new short[0], 8002, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 117, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(55, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_55"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_55_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_55_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_55_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_55_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_55_4")
		}, new short[0], 8003, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 131, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(56, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_56"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_56_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_56_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_56_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_56_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_56_4")
		}, new short[0], 8004, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 128, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(57, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_57"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_57_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_57_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_57_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_57_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_57_4")
		}, new short[0], 8005, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 129, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(58, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_58"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_58_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_58_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_58_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_58_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_58_4")
		}, new short[0], 8006, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 134, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(59, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_59"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_59_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_59_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_59_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_59_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_59_4")
		}, new short[0], 8007, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 135, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new SecretInformationAppliedSelectionItem(60, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_60"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_60_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_60_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_60_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_60_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_60_4")
		}, new short[0], 8008, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 136, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(61, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_61"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_61_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_61_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_61_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_61_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_61_4")
		}, new short[0], 8009, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 126, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(62, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_62"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_62_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_62_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_62_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_62_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_62_4")
		}, new short[0], 8010, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 127, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(63, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_63"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_63_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_63_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_63_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_63_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_63_4")
		}, new short[0], 8011, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 130, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(64, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_64"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_64_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_64_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_64_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_64_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_64_4")
		}, new short[0], 8012, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 132, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(65, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_65"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_65_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_65_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_65_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_65_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_65_4")
		}, new short[0], 8013, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 133, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(66, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_66"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_66_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_66_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_66_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_66_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_66_4")
		}, new short[0], 8014, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 65, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(67, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_67"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_67_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_67_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_67_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_67_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_67_4")
		}, new short[0], 8015, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 66, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(68, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_68"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_68_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_68_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_68_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_68_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_68_4")
		}, new short[0], 8016, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 49, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(69, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_69"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_69_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_69_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_69_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_69_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_69_4")
		}, new short[0], 8017, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 51, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(70, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_70"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_70_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_70_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_70_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_70_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_70_4")
		}, new short[0], 8018, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 50, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(71, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_71"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_71_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_71_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_71_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_71_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_71_4")
		}, new short[0], 8019, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 52, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(72, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_72"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_72_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_72_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_72_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_72_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_72_4")
		}, new short[0], 8020, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 54, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(73, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_73"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_73_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_73_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_73_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_73_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_73_4")
		}, new short[0], 8021, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 53, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(74, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_74"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_74_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_74_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_74_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_74_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_74_4")
		}, new short[0], 8022, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 32, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(75, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_75"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_75_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_75_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_75_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_75_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_75_4")
		}, new short[0], 8023, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 156, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(76, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_76"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_76_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_76_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_76_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_76_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_76_4")
		}, new short[0], 8024, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 183, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(77, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_77"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_77_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_77_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_77_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_77_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_77_4")
		}, new short[0], 8025, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 157, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(78, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_78"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_78_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_78_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_78_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_78_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_78_4")
		}, new short[0], 8026, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 166, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(79, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_79"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_79_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_79_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_79_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_79_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_79_4")
		}, new short[0], 8027, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 32, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(80, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_80"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_80_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_80_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_80_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_80_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_80_4")
		}, new short[0], 8028, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 171, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(81, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_81"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_81_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_81_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_81_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_81_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_81_4")
		}, new short[0], 8029, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 196, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(82, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_82"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_82_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_82_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_82_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_82_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_82_4")
		}, new short[0], 8030, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 176, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(83, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_83"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_83_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_83_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_83_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_83_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_83_4")
		}, new short[0], 8031, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 201, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(84, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_84"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_84_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_84_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_84_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_84_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_84_4")
		}, new short[0], 8032, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 33, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(85, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_85"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_85_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_85_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_85_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_85_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_85_4")
		}, new short[0], 8033, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, -1, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(86, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_86"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_86_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_86_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_86_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_86_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_86_4")
		}, new short[0], 1004, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 230, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(87, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_87"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_87_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_87_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_87_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_87_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_87_4")
		}, new short[0], 9011, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, -1, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(88, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_88"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_88_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_88_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_88_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_88_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_88_4")
		}, new short[0], 1005, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(53, 0, 3),
			new ShortList(53, 1, 3),
			new ShortList(53, 2, 3)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 231, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(89, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_89"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_89_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_89_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_89_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_89_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_89_4")
		}, new short[0], 1006, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(15, 3, 0, -12),
			new ShortList(15, 3, 0, -11),
			new ShortList(15, 3, 1, -12),
			new ShortList(15, 3, 1, -11),
			new ShortList(15, 3, 2, -12),
			new ShortList(15, 3, 2, -11)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 267, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(90, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_90"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_90_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_90_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_90_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_90_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_90_4")
		}, new short[0], 1007, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(15, 5, 3, -10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 271, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(91, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_91"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_91_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_91_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_91_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_91_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_91_4")
		}, new short[0], 1008, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 275, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(92, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_92"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_92_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_92_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_92_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_92_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_92_4")
		}, new short[0], 1009, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, -1, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
		_dataArray.Add(new SecretInformationAppliedSelectionItem(93, LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "Text_93"), new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_93_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_93_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_93_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_93_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedSelection_language", "SelectionTexts_93_4")
		}, new short[0], 1010, 0, default(PropertyAndValue), new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new sbyte[4] { -1, -1, -1, -1 }, new short[0], -6, 287, -1, new sbyte[5] { -6, -6, -6, -6, -6 }, ESecretInformationAppliedSelectionHotKey.Unbound));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SecretInformationAppliedSelectionItem>(94);
		CreateItems0();
		CreateItems1();
	}
}
