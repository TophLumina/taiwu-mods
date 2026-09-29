using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterTitle : ConfigData<CharacterTitleItem, short>
{
	public static class DefKey
	{
		public const short XiangshuAvatar = 0;

		public const short XiangshuCore = 1;

		public const short PurpleBambooAvatar = 2;

		public const short LegendaryBook0 = 3;

		public const short LegendaryBook1 = 4;

		public const short LegendaryBook2 = 5;

		public const short LegendaryBook3 = 6;

		public const short LegendaryBook4 = 7;

		public const short LegendaryBook5 = 8;

		public const short LegendaryBook6 = 9;

		public const short LegendaryBook7 = 10;

		public const short LegendaryBook8 = 11;

		public const short LegendaryBook9 = 12;

		public const short LegendaryBook10 = 13;

		public const short LegendaryBook11 = 14;

		public const short LegendaryBook12 = 15;

		public const short LegendaryBook13 = 16;

		public const short LeaderOfMartialWorld = 17;

		public const short ChampionOfCricketFighting = 18;

		public const short ChampionOfFistAndPalmConference = 19;

		public const short ChampionOfFingerConference = 20;

		public const short ChampionOfLegConference = 21;

		public const short ChampionOfThrowConference = 22;

		public const short ChampionOfSwordConference = 23;

		public const short ChampionOfBladeConference = 24;

		public const short ChampionOfPolearmConference = 25;

		public const short ChampionOfSpecialConference = 26;

		public const short ChampionOfWhipConference = 27;

		public const short ChampionOfControllableShotConference = 28;

		public const short ChampionOfCombatMusicConference = 29;

		public const short ChampionOfForgingConference = 30;

		public const short ChampionOfWoodworkingConference = 31;

		public const short ChampionOfWeavingConference = 32;

		public const short ChampionOfJadeConference = 33;

		public const short ChampionOfMedicineConference = 34;

		public const short ChampionOfToxicologyConference = 35;

		public const short ChampionOfCookingConference = 36;

		public const short DukeTitle0 = 37;

		public const short DukeTitle1 = 38;

		public const short DukeTitle2 = 39;

		public const short DukeTitle3 = 40;

		public const short DukeTitle4 = 41;

		public const short DukeTitle5 = 42;
	}

	public static class DefValue
	{
		public static CharacterTitleItem XiangshuAvatar => Instance[(short)0];

		public static CharacterTitleItem XiangshuCore => Instance[(short)1];

		public static CharacterTitleItem PurpleBambooAvatar => Instance[(short)2];

		public static CharacterTitleItem LegendaryBook0 => Instance[(short)3];

		public static CharacterTitleItem LegendaryBook1 => Instance[(short)4];

		public static CharacterTitleItem LegendaryBook2 => Instance[(short)5];

		public static CharacterTitleItem LegendaryBook3 => Instance[(short)6];

		public static CharacterTitleItem LegendaryBook4 => Instance[(short)7];

		public static CharacterTitleItem LegendaryBook5 => Instance[(short)8];

		public static CharacterTitleItem LegendaryBook6 => Instance[(short)9];

		public static CharacterTitleItem LegendaryBook7 => Instance[(short)10];

		public static CharacterTitleItem LegendaryBook8 => Instance[(short)11];

		public static CharacterTitleItem LegendaryBook9 => Instance[(short)12];

		public static CharacterTitleItem LegendaryBook10 => Instance[(short)13];

		public static CharacterTitleItem LegendaryBook11 => Instance[(short)14];

		public static CharacterTitleItem LegendaryBook12 => Instance[(short)15];

		public static CharacterTitleItem LegendaryBook13 => Instance[(short)16];

		public static CharacterTitleItem LeaderOfMartialWorld => Instance[(short)17];

		public static CharacterTitleItem ChampionOfCricketFighting => Instance[(short)18];

		public static CharacterTitleItem ChampionOfFistAndPalmConference => Instance[(short)19];

		public static CharacterTitleItem ChampionOfFingerConference => Instance[(short)20];

		public static CharacterTitleItem ChampionOfLegConference => Instance[(short)21];

		public static CharacterTitleItem ChampionOfThrowConference => Instance[(short)22];

		public static CharacterTitleItem ChampionOfSwordConference => Instance[(short)23];

		public static CharacterTitleItem ChampionOfBladeConference => Instance[(short)24];

		public static CharacterTitleItem ChampionOfPolearmConference => Instance[(short)25];

		public static CharacterTitleItem ChampionOfSpecialConference => Instance[(short)26];

		public static CharacterTitleItem ChampionOfWhipConference => Instance[(short)27];

		public static CharacterTitleItem ChampionOfControllableShotConference => Instance[(short)28];

		public static CharacterTitleItem ChampionOfCombatMusicConference => Instance[(short)29];

		public static CharacterTitleItem ChampionOfForgingConference => Instance[(short)30];

		public static CharacterTitleItem ChampionOfWoodworkingConference => Instance[(short)31];

		public static CharacterTitleItem ChampionOfWeavingConference => Instance[(short)32];

		public static CharacterTitleItem ChampionOfJadeConference => Instance[(short)33];

		public static CharacterTitleItem ChampionOfMedicineConference => Instance[(short)34];

		public static CharacterTitleItem ChampionOfToxicologyConference => Instance[(short)35];

		public static CharacterTitleItem ChampionOfCookingConference => Instance[(short)36];

		public static CharacterTitleItem DukeTitle0 => Instance[(short)37];

		public static CharacterTitleItem DukeTitle1 => Instance[(short)38];

		public static CharacterTitleItem DukeTitle2 => Instance[(short)39];

		public static CharacterTitleItem DukeTitle3 => Instance[(short)40];

		public static CharacterTitleItem DukeTitle4 => Instance[(short)41];

		public static CharacterTitleItem DukeTitle5 => Instance[(short)42];
	}

	public static CharacterTitle Instance = new CharacterTitle();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Misc", "TemplateId" };

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
		_dataArray.Add(new CharacterTitleItem(0, LocalStringManager.GetConfig("CharacterTitle_language", "Name_0"), -1, -1));
		_dataArray.Add(new CharacterTitleItem(1, LocalStringManager.GetConfig("CharacterTitle_language", "Name_1"), -1, -1));
		_dataArray.Add(new CharacterTitleItem(2, LocalStringManager.GetConfig("CharacterTitle_language", "Name_2"), -1, -1));
		_dataArray.Add(new CharacterTitleItem(3, LocalStringManager.GetConfig("CharacterTitle_language", "Name_3"), 240, -1));
		_dataArray.Add(new CharacterTitleItem(4, LocalStringManager.GetConfig("CharacterTitle_language", "Name_4"), 241, -1));
		_dataArray.Add(new CharacterTitleItem(5, LocalStringManager.GetConfig("CharacterTitle_language", "Name_5"), 242, -1));
		_dataArray.Add(new CharacterTitleItem(6, LocalStringManager.GetConfig("CharacterTitle_language", "Name_6"), 243, -1));
		_dataArray.Add(new CharacterTitleItem(7, LocalStringManager.GetConfig("CharacterTitle_language", "Name_7"), 244, -1));
		_dataArray.Add(new CharacterTitleItem(8, LocalStringManager.GetConfig("CharacterTitle_language", "Name_8"), 245, -1));
		_dataArray.Add(new CharacterTitleItem(9, LocalStringManager.GetConfig("CharacterTitle_language", "Name_9"), 246, -1));
		_dataArray.Add(new CharacterTitleItem(10, LocalStringManager.GetConfig("CharacterTitle_language", "Name_10"), 247, -1));
		_dataArray.Add(new CharacterTitleItem(11, LocalStringManager.GetConfig("CharacterTitle_language", "Name_11"), 248, -1));
		_dataArray.Add(new CharacterTitleItem(12, LocalStringManager.GetConfig("CharacterTitle_language", "Name_12"), 249, -1));
		_dataArray.Add(new CharacterTitleItem(13, LocalStringManager.GetConfig("CharacterTitle_language", "Name_13"), 250, -1));
		_dataArray.Add(new CharacterTitleItem(14, LocalStringManager.GetConfig("CharacterTitle_language", "Name_14"), 251, -1));
		_dataArray.Add(new CharacterTitleItem(15, LocalStringManager.GetConfig("CharacterTitle_language", "Name_15"), 252, -1));
		_dataArray.Add(new CharacterTitleItem(16, LocalStringManager.GetConfig("CharacterTitle_language", "Name_16"), 253, -1));
		_dataArray.Add(new CharacterTitleItem(17, LocalStringManager.GetConfig("CharacterTitle_language", "Name_17"), -1, -1));
		_dataArray.Add(new CharacterTitleItem(18, LocalStringManager.GetConfig("CharacterTitle_language", "Name_18"), -1, 36));
		_dataArray.Add(new CharacterTitleItem(19, LocalStringManager.GetConfig("CharacterTitle_language", "Name_19"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(20, LocalStringManager.GetConfig("CharacterTitle_language", "Name_20"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(21, LocalStringManager.GetConfig("CharacterTitle_language", "Name_21"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(22, LocalStringManager.GetConfig("CharacterTitle_language", "Name_22"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(23, LocalStringManager.GetConfig("CharacterTitle_language", "Name_23"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(24, LocalStringManager.GetConfig("CharacterTitle_language", "Name_24"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(25, LocalStringManager.GetConfig("CharacterTitle_language", "Name_25"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(26, LocalStringManager.GetConfig("CharacterTitle_language", "Name_26"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(27, LocalStringManager.GetConfig("CharacterTitle_language", "Name_27"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(28, LocalStringManager.GetConfig("CharacterTitle_language", "Name_28"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(29, LocalStringManager.GetConfig("CharacterTitle_language", "Name_29"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(30, LocalStringManager.GetConfig("CharacterTitle_language", "Name_30"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(31, LocalStringManager.GetConfig("CharacterTitle_language", "Name_31"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(32, LocalStringManager.GetConfig("CharacterTitle_language", "Name_32"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(33, LocalStringManager.GetConfig("CharacterTitle_language", "Name_33"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(34, LocalStringManager.GetConfig("CharacterTitle_language", "Name_34"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(35, LocalStringManager.GetConfig("CharacterTitle_language", "Name_35"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(36, LocalStringManager.GetConfig("CharacterTitle_language", "Name_36"), -1, 12));
		_dataArray.Add(new CharacterTitleItem(37, LocalStringManager.GetConfig("CharacterTitle_language", "Name_37"), -1, -1));
		_dataArray.Add(new CharacterTitleItem(38, LocalStringManager.GetConfig("CharacterTitle_language", "Name_38"), -1, -1));
		_dataArray.Add(new CharacterTitleItem(39, LocalStringManager.GetConfig("CharacterTitle_language", "Name_39"), -1, -1));
		_dataArray.Add(new CharacterTitleItem(40, LocalStringManager.GetConfig("CharacterTitle_language", "Name_40"), -1, -1));
		_dataArray.Add(new CharacterTitleItem(41, LocalStringManager.GetConfig("CharacterTitle_language", "Name_41"), -1, -1));
		_dataArray.Add(new CharacterTitleItem(42, LocalStringManager.GetConfig("CharacterTitle_language", "Name_42"), -1, -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CharacterTitleItem>(43);
		CreateItems0();
	}
}
