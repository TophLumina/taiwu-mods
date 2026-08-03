using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ProfessionSkill : ConfigData<ProfessionSkillItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 山人技能0
		/// </summary>
		public const int SavageSkill0 = 0;

		/// <summary>
		/// 山人技能1
		/// </summary>
		public const int SavageSkill1 = 1;

		/// <summary>
		/// 山人技能2
		/// </summary>
		public const int SavageSkill2 = 2;

		/// <summary>
		/// 山人技能3
		/// </summary>
		public const int SavageSkill3 = 3;

		/// <summary>
		/// 猎户技能0
		/// </summary>
		public const int HunterSkill0 = 4;

		/// <summary>
		/// 猎户技能1
		/// </summary>
		public const int HunterSkill1 = 5;

		/// <summary>
		/// 猎户技能2
		/// </summary>
		public const int HunterSkill2 = 6;

		/// <summary>
		/// 猎户技能3
		/// </summary>
		public const int HunterSkill3 = 7;

		/// <summary>
		/// 匠人技能0
		/// </summary>
		public const int CraftSkill0 = 8;

		/// <summary>
		/// 匠人技能1
		/// </summary>
		public const int CraftSkill1 = 9;

		/// <summary>
		/// 匠人技能2
		/// </summary>
		public const int CraftSkill2 = 10;

		/// <summary>
		/// 匠人技能3
		/// </summary>
		public const int CraftSkill3 = 11;

		/// <summary>
		/// 武师技能0
		/// </summary>
		public const int MartialArtistSkill0 = 12;

		/// <summary>
		/// 武师技能1
		/// </summary>
		public const int MartialArtistSkill1 = 13;

		/// <summary>
		/// 武师技能2
		/// </summary>
		public const int MartialArtistSkill2 = 14;

		/// <summary>
		/// 武师技能3
		/// </summary>
		public const int MartialArtistSkill3 = 15;

		/// <summary>
		/// 才俊技能0
		/// </summary>
		public const int LiteratiSkill0 = 16;

		/// <summary>
		/// 才俊技能1
		/// </summary>
		public const int LiteratiSkill1 = 17;

		/// <summary>
		/// 才俊技能2
		/// </summary>
		public const int LiteratiSkill2 = 18;

		/// <summary>
		/// 才俊技能3
		/// </summary>
		public const int LiteratiSkill3 = 19;

		/// <summary>
		/// 道长技能0
		/// </summary>
		public const int TaoistMonkSkill0 = 20;

		/// <summary>
		/// 道长技能1
		/// </summary>
		public const int TaoistMonkSkill1 = 21;

		/// <summary>
		/// 道长技能2
		/// </summary>
		public const int TaoistMonkSkill2 = 22;

		/// <summary>
		/// 道长技能3
		/// </summary>
		public const int TaoistMonkSkill3 = 23;

		/// <summary>
		/// 高僧技能0
		/// </summary>
		public const int BuddhistMonkSkill0 = 24;

		/// <summary>
		/// 高僧技能1
		/// </summary>
		public const int BuddhistMonkSkill1 = 25;

		/// <summary>
		/// 高僧技能2
		/// </summary>
		public const int BuddhistMonkSkill2 = 26;

		/// <summary>
		/// 高僧技能3
		/// </summary>
		public const int BuddhistMonkSkill3 = 27;

		/// <summary>
		/// 豪客技能0
		/// </summary>
		public const int WineTasterSkill0 = 28;

		/// <summary>
		/// 豪客技能1
		/// </summary>
		public const int WineTasterSkill1 = 29;

		/// <summary>
		/// 豪客技能2
		/// </summary>
		public const int WineTasterSkill2 = 30;

		/// <summary>
		/// 豪客技能3
		/// </summary>
		public const int WineTasterSkill3 = 31;

		/// <summary>
		/// 名门技能0
		/// </summary>
		public const int AristocratSkill0 = 32;

		/// <summary>
		/// 名门技能1
		/// </summary>
		public const int AristocratSkill1 = 33;

		/// <summary>
		/// 名门技能2
		/// </summary>
		public const int AristocratSkill2 = 34;

		/// <summary>
		/// 名门技能3
		/// </summary>
		public const int AristocratSkill3 = 35;

		/// <summary>
		/// 乞丐技能0
		/// </summary>
		public const int BeggarSkill0 = 36;

		/// <summary>
		/// 乞丐技能1
		/// </summary>
		public const int BeggarSkill1 = 37;

		/// <summary>
		/// 乞丐技能2
		/// </summary>
		public const int BeggarSkill2 = 38;

		/// <summary>
		/// 乞丐技能3
		/// </summary>
		public const int BeggarSkill3 = 39;

		/// <summary>
		/// 平民技能0
		/// </summary>
		public const int CivilianSkill0 = 40;

		/// <summary>
		/// 平民技能1
		/// </summary>
		public const int CivilianSkill1 = 41;

		/// <summary>
		/// 平民技能2
		/// </summary>
		public const int CivilianSkill2 = 42;

		/// <summary>
		/// 平民技能3
		/// </summary>
		public const int CivilianSkill3 = 43;

		/// <summary>
		/// 旅人技能0
		/// </summary>
		public const int TravelerSkill0 = 44;

		/// <summary>
		/// 旅人技能1
		/// </summary>
		public const int TravelerSkill1 = 45;

		/// <summary>
		/// 旅人技能2
		/// </summary>
		public const int TravelerSkill2 = 46;

		/// <summary>
		/// 旅人技能3
		/// </summary>
		public const int TravelerSkill3 = 47;

		/// <summary>
		/// 云游僧技能0
		/// </summary>
		public const int TravelingBuddhistMonkSkill0 = 48;

		/// <summary>
		/// 云游僧技能1
		/// </summary>
		public const int TravelingBuddhistMonkSkill1 = 49;

		/// <summary>
		/// 云游僧技能2
		/// </summary>
		public const int TravelingBuddhistMonkSkill2 = 50;

		/// <summary>
		/// 云游僧技能3
		/// </summary>
		public const int TravelingBuddhistMonkSkill3 = 51;

		/// <summary>
		/// 大夫技能0
		/// </summary>
		public const int DoctorSkill0 = 52;

		/// <summary>
		/// 大夫技能1
		/// </summary>
		public const int DoctorSkill1 = 53;

		/// <summary>
		/// 大夫技能2
		/// </summary>
		public const int DoctorSkill2 = 54;

		/// <summary>
		/// 大夫技能3
		/// </summary>
		public const int DoctorSkill3 = 55;

		/// <summary>
		/// 云游道技能0
		/// </summary>
		public const int TravelingTaoistMonkSkill0 = 56;

		/// <summary>
		/// 云游道技能1
		/// </summary>
		public const int TravelingTaoistMonkSkill1 = 57;

		/// <summary>
		/// 云游道技能2
		/// </summary>
		public const int TravelingTaoistMonkSkill2 = 58;

		/// <summary>
		/// 云游道技能3
		/// </summary>
		public const int TravelingTaoistMonkSkill3 = 59;

		/// <summary>
		/// 富商技能0
		/// </summary>
		public const int CapitalistSkill0 = 60;

		/// <summary>
		/// 富商技能1
		/// </summary>
		public const int CapitalistSkill1 = 61;

		/// <summary>
		/// 富商技能2
		/// </summary>
		public const int CapitalistSkill2 = 62;

		/// <summary>
		/// 富商技能3
		/// </summary>
		public const int CapitalistSkill3 = 63;

		/// <summary>
		/// 贵客技能0
		/// </summary>
		public const int TeaTasterSkill0 = 64;

		/// <summary>
		/// 贵客技能1
		/// </summary>
		public const int TeaTasterSkill1 = 65;

		/// <summary>
		/// 贵客技能2
		/// </summary>
		public const int TeaTasterSkill2 = 66;

		/// <summary>
		/// 贵客技能3
		/// </summary>
		public const int TeaTasterSkill3 = 67;

		/// <summary>
		/// 王公技能0
		/// </summary>
		public const int DukeSkill0 = 68;

		/// <summary>
		/// 王公技能1
		/// </summary>
		public const int DukeSkill1 = 69;

		/// <summary>
		/// 王公技能2
		/// </summary>
		public const int DukeSkill2 = 70;

		/// <summary>
		/// 王公技能3
		/// </summary>
		public const int DukeSkill3 = 71;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 山人技能0
		/// </summary>
		public static ProfessionSkillItem SavageSkill0 => Instance[0];

		/// <summary>
		/// 山人技能1
		/// </summary>
		public static ProfessionSkillItem SavageSkill1 => Instance[1];

		/// <summary>
		/// 山人技能2
		/// </summary>
		public static ProfessionSkillItem SavageSkill2 => Instance[2];

		/// <summary>
		/// 山人技能3
		/// </summary>
		public static ProfessionSkillItem SavageSkill3 => Instance[3];

		/// <summary>
		/// 猎户技能0
		/// </summary>
		public static ProfessionSkillItem HunterSkill0 => Instance[4];

		/// <summary>
		/// 猎户技能1
		/// </summary>
		public static ProfessionSkillItem HunterSkill1 => Instance[5];

		/// <summary>
		/// 猎户技能2
		/// </summary>
		public static ProfessionSkillItem HunterSkill2 => Instance[6];

		/// <summary>
		/// 猎户技能3
		/// </summary>
		public static ProfessionSkillItem HunterSkill3 => Instance[7];

		/// <summary>
		/// 匠人技能0
		/// </summary>
		public static ProfessionSkillItem CraftSkill0 => Instance[8];

		/// <summary>
		/// 匠人技能1
		/// </summary>
		public static ProfessionSkillItem CraftSkill1 => Instance[9];

		/// <summary>
		/// 匠人技能2
		/// </summary>
		public static ProfessionSkillItem CraftSkill2 => Instance[10];

		/// <summary>
		/// 匠人技能3
		/// </summary>
		public static ProfessionSkillItem CraftSkill3 => Instance[11];

		/// <summary>
		/// 武师技能0
		/// </summary>
		public static ProfessionSkillItem MartialArtistSkill0 => Instance[12];

		/// <summary>
		/// 武师技能1
		/// </summary>
		public static ProfessionSkillItem MartialArtistSkill1 => Instance[13];

		/// <summary>
		/// 武师技能2
		/// </summary>
		public static ProfessionSkillItem MartialArtistSkill2 => Instance[14];

		/// <summary>
		/// 武师技能3
		/// </summary>
		public static ProfessionSkillItem MartialArtistSkill3 => Instance[15];

		/// <summary>
		/// 才俊技能0
		/// </summary>
		public static ProfessionSkillItem LiteratiSkill0 => Instance[16];

		/// <summary>
		/// 才俊技能1
		/// </summary>
		public static ProfessionSkillItem LiteratiSkill1 => Instance[17];

		/// <summary>
		/// 才俊技能2
		/// </summary>
		public static ProfessionSkillItem LiteratiSkill2 => Instance[18];

		/// <summary>
		/// 才俊技能3
		/// </summary>
		public static ProfessionSkillItem LiteratiSkill3 => Instance[19];

		/// <summary>
		/// 道长技能0
		/// </summary>
		public static ProfessionSkillItem TaoistMonkSkill0 => Instance[20];

		/// <summary>
		/// 道长技能1
		/// </summary>
		public static ProfessionSkillItem TaoistMonkSkill1 => Instance[21];

		/// <summary>
		/// 道长技能2
		/// </summary>
		public static ProfessionSkillItem TaoistMonkSkill2 => Instance[22];

		/// <summary>
		/// 道长技能3
		/// </summary>
		public static ProfessionSkillItem TaoistMonkSkill3 => Instance[23];

		/// <summary>
		/// 高僧技能0
		/// </summary>
		public static ProfessionSkillItem BuddhistMonkSkill0 => Instance[24];

		/// <summary>
		/// 高僧技能1
		/// </summary>
		public static ProfessionSkillItem BuddhistMonkSkill1 => Instance[25];

		/// <summary>
		/// 高僧技能2
		/// </summary>
		public static ProfessionSkillItem BuddhistMonkSkill2 => Instance[26];

		/// <summary>
		/// 高僧技能3
		/// </summary>
		public static ProfessionSkillItem BuddhistMonkSkill3 => Instance[27];

		/// <summary>
		/// 豪客技能0
		/// </summary>
		public static ProfessionSkillItem WineTasterSkill0 => Instance[28];

		/// <summary>
		/// 豪客技能1
		/// </summary>
		public static ProfessionSkillItem WineTasterSkill1 => Instance[29];

		/// <summary>
		/// 豪客技能2
		/// </summary>
		public static ProfessionSkillItem WineTasterSkill2 => Instance[30];

		/// <summary>
		/// 豪客技能3
		/// </summary>
		public static ProfessionSkillItem WineTasterSkill3 => Instance[31];

		/// <summary>
		/// 名门技能0
		/// </summary>
		public static ProfessionSkillItem AristocratSkill0 => Instance[32];

		/// <summary>
		/// 名门技能1
		/// </summary>
		public static ProfessionSkillItem AristocratSkill1 => Instance[33];

		/// <summary>
		/// 名门技能2
		/// </summary>
		public static ProfessionSkillItem AristocratSkill2 => Instance[34];

		/// <summary>
		/// 名门技能3
		/// </summary>
		public static ProfessionSkillItem AristocratSkill3 => Instance[35];

		/// <summary>
		/// 乞丐技能0
		/// </summary>
		public static ProfessionSkillItem BeggarSkill0 => Instance[36];

		/// <summary>
		/// 乞丐技能1
		/// </summary>
		public static ProfessionSkillItem BeggarSkill1 => Instance[37];

		/// <summary>
		/// 乞丐技能2
		/// </summary>
		public static ProfessionSkillItem BeggarSkill2 => Instance[38];

		/// <summary>
		/// 乞丐技能3
		/// </summary>
		public static ProfessionSkillItem BeggarSkill3 => Instance[39];

		/// <summary>
		/// 平民技能0
		/// </summary>
		public static ProfessionSkillItem CivilianSkill0 => Instance[40];

		/// <summary>
		/// 平民技能1
		/// </summary>
		public static ProfessionSkillItem CivilianSkill1 => Instance[41];

		/// <summary>
		/// 平民技能2
		/// </summary>
		public static ProfessionSkillItem CivilianSkill2 => Instance[42];

		/// <summary>
		/// 平民技能3
		/// </summary>
		public static ProfessionSkillItem CivilianSkill3 => Instance[43];

		/// <summary>
		/// 旅人技能0
		/// </summary>
		public static ProfessionSkillItem TravelerSkill0 => Instance[44];

		/// <summary>
		/// 旅人技能1
		/// </summary>
		public static ProfessionSkillItem TravelerSkill1 => Instance[45];

		/// <summary>
		/// 旅人技能2
		/// </summary>
		public static ProfessionSkillItem TravelerSkill2 => Instance[46];

		/// <summary>
		/// 旅人技能3
		/// </summary>
		public static ProfessionSkillItem TravelerSkill3 => Instance[47];

		/// <summary>
		/// 云游僧技能0
		/// </summary>
		public static ProfessionSkillItem TravelingBuddhistMonkSkill0 => Instance[48];

		/// <summary>
		/// 云游僧技能1
		/// </summary>
		public static ProfessionSkillItem TravelingBuddhistMonkSkill1 => Instance[49];

		/// <summary>
		/// 云游僧技能2
		/// </summary>
		public static ProfessionSkillItem TravelingBuddhistMonkSkill2 => Instance[50];

		/// <summary>
		/// 云游僧技能3
		/// </summary>
		public static ProfessionSkillItem TravelingBuddhistMonkSkill3 => Instance[51];

		/// <summary>
		/// 大夫技能0
		/// </summary>
		public static ProfessionSkillItem DoctorSkill0 => Instance[52];

		/// <summary>
		/// 大夫技能1
		/// </summary>
		public static ProfessionSkillItem DoctorSkill1 => Instance[53];

		/// <summary>
		/// 大夫技能2
		/// </summary>
		public static ProfessionSkillItem DoctorSkill2 => Instance[54];

		/// <summary>
		/// 大夫技能3
		/// </summary>
		public static ProfessionSkillItem DoctorSkill3 => Instance[55];

		/// <summary>
		/// 云游道技能0
		/// </summary>
		public static ProfessionSkillItem TravelingTaoistMonkSkill0 => Instance[56];

		/// <summary>
		/// 云游道技能1
		/// </summary>
		public static ProfessionSkillItem TravelingTaoistMonkSkill1 => Instance[57];

		/// <summary>
		/// 云游道技能2
		/// </summary>
		public static ProfessionSkillItem TravelingTaoistMonkSkill2 => Instance[58];

		/// <summary>
		/// 云游道技能3
		/// </summary>
		public static ProfessionSkillItem TravelingTaoistMonkSkill3 => Instance[59];

		/// <summary>
		/// 富商技能0
		/// </summary>
		public static ProfessionSkillItem CapitalistSkill0 => Instance[60];

		/// <summary>
		/// 富商技能1
		/// </summary>
		public static ProfessionSkillItem CapitalistSkill1 => Instance[61];

		/// <summary>
		/// 富商技能2
		/// </summary>
		public static ProfessionSkillItem CapitalistSkill2 => Instance[62];

		/// <summary>
		/// 富商技能3
		/// </summary>
		public static ProfessionSkillItem CapitalistSkill3 => Instance[63];

		/// <summary>
		/// 贵客技能0
		/// </summary>
		public static ProfessionSkillItem TeaTasterSkill0 => Instance[64];

		/// <summary>
		/// 贵客技能1
		/// </summary>
		public static ProfessionSkillItem TeaTasterSkill1 => Instance[65];

		/// <summary>
		/// 贵客技能2
		/// </summary>
		public static ProfessionSkillItem TeaTasterSkill2 => Instance[66];

		/// <summary>
		/// 贵客技能3
		/// </summary>
		public static ProfessionSkillItem TeaTasterSkill3 => Instance[67];

		/// <summary>
		/// 王公技能0
		/// </summary>
		public static ProfessionSkillItem DukeSkill0 => Instance[68];

		/// <summary>
		/// 王公技能1
		/// </summary>
		public static ProfessionSkillItem DukeSkill1 => Instance[69];

		/// <summary>
		/// 王公技能2
		/// </summary>
		public static ProfessionSkillItem DukeSkill2 => Instance[70];

		/// <summary>
		/// 王公技能3
		/// </summary>
		public static ProfessionSkillItem DukeSkill3 => Instance[71];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static ProfessionSkill Instance = new ProfessionSkill();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Profession", "Desc", "FunctionalDesc", "CharacterProperty", "ResourcesCost", "SkillUnlockDesc", "SkillUnlockExplain", "TemplateId", "Icon",
		"BigIcon", "Level", "UnlockSeniority"
	};

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new ProfessionSkillItem(0, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_0"), instant: false, 0, "ui9_icon_profession_skill_0_0", "ui9_icon_profession_skill_big_0_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_0"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_0"), 1, 0, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 5, 20, 10, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_0"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_0")));
		_dataArray.Add(new ProfessionSkillItem(1, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_1"), instant: true, 0, "ui9_icon_profession_skill_0_1", "ui9_icon_profession_skill_big_0_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_1"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_1"), 2, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 3, 10, costTimeWhenFinished: false, 20, 20, 10, 500, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_1"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_1")));
		_dataArray.Add(new ProfessionSkillItem(2, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_2"), instant: false, 0, "ui9_icon_profession_skill_0_2", "ui9_icon_profession_skill_big_0_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_2"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_2"), 3, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 50, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_2"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_2")));
		_dataArray.Add(new ProfessionSkillItem(3, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_3"), instant: false, 0, "ui9_icon_profession_skill_0_3", "ui9_icon_profession_skill_big_0_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_3"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_3"), 4, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 3, 0, costTimeWhenFinished: false, 100, 0, 0, 5000, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_3"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_3")));
		_dataArray.Add(new ProfessionSkillItem(4, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_4"), instant: false, 1, "ui9_icon_profession_skill_1_1", "ui9_icon_profession_skill_big_1_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_4"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_4"), 1, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 15, 40, 20, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_4"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_4")));
		_dataArray.Add(new ProfessionSkillItem(5, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_5"), instant: false, 1, "ui9_icon_profession_skill_1_2", "ui9_icon_profession_skill_big_1_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_5"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_5"), 2, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 30, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_5"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_5")));
		_dataArray.Add(new ProfessionSkillItem(6, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_6"), instant: true, 1, "ui9_icon_profession_skill_1_0", "ui9_icon_profession_skill_big_1_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_6"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_6"), 3, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 1, 10, costTimeWhenFinished: false, 75, 20, 10, 0, new List<ResourceInfo>
		{
			new ResourceInfo(0, 100)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_6"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_6")));
		_dataArray.Add(new ProfessionSkillItem(7, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_7"), instant: false, 1, "ui9_icon_profession_skill_1_3", "ui9_icon_profession_skill_big_1_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_7"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_7"), 4, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 6, 10, costTimeWhenFinished: false, 100, 0, 0, 25000, new List<ResourceInfo>
		{
			new ResourceInfo(0, 10000)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_7"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_7")));
		_dataArray.Add(new ProfessionSkillItem(8, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_8"), instant: false, 2, "ui9_icon_profession_skill_2_0", "ui9_icon_profession_skill_big_2_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_8"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_8"), 1, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 15, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_8"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_8")));
		_dataArray.Add(new ProfessionSkillItem(9, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_9"), instant: false, 2, "ui9_icon_profession_skill_2_1", "ui9_icon_profession_skill_big_2_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_9"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_9"), 2, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 30, 60, 30, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_9"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_9")));
		_dataArray.Add(new ProfessionSkillItem(10, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_10"), instant: false, 2, "ui9_icon_profession_skill_2_2", "ui9_icon_profession_skill_big_2_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_10"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_10"), 3, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 3, 5, costTimeWhenFinished: false, 75, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_10"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_10")));
		_dataArray.Add(new ProfessionSkillItem(11, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_11"), instant: false, 2, "ui9_icon_profession_skill_2_3", "ui9_icon_profession_skill_big_2_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_11"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_11"), 4, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_11"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_11")));
		_dataArray.Add(new ProfessionSkillItem(12, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_12"), instant: false, 3, "ui9_icon_profession_skill_3_0", "ui9_icon_profession_skill_big_3_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_12"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_12"), 1, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 5, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_12"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_12")));
		_dataArray.Add(new ProfessionSkillItem(13, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_13"), instant: false, 3, "ui9_icon_profession_skill_3_1", "ui9_icon_profession_skill_big_3_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_13"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_13"), 2, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 20, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_13"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_13")));
		_dataArray.Add(new ProfessionSkillItem(14, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_14"), instant: false, 3, "ui9_icon_profession_skill_3_2", "ui9_icon_profession_skill_big_3_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_14"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_14"), 3, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 50, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_14"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_14")));
		_dataArray.Add(new ProfessionSkillItem(15, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_15"), instant: true, 3, "ui9_icon_profession_skill_3_3", "ui9_icon_profession_skill_big_3_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_15"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_15"), 4, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 3, 10, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>
		{
			new ResourceInfo(7, 2500)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_15"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_15")));
		_dataArray.Add(new ProfessionSkillItem(16, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_16"), instant: false, 4, "ui9_icon_profession_skill_4_0", "ui9_icon_profession_skill_big_4_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_16"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_16"), 1, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 1, 5, costTimeWhenFinished: false, 5, 20, 10, 500, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_16"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_16")));
		_dataArray.Add(new ProfessionSkillItem(17, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_17"), instant: false, 4, "ui9_icon_profession_skill_4_1", "ui9_icon_profession_skill_big_4_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_17"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_17"), 2, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 20, 40, 20, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_17"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_17")));
		_dataArray.Add(new ProfessionSkillItem(18, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_18"), instant: false, 4, "ui9_icon_profession_skill_4_2", "ui9_icon_profession_skill_big_4_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_18"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_18"), 3, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 3, 5, costTimeWhenFinished: false, 50, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_18"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_18")));
		_dataArray.Add(new ProfessionSkillItem(19, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_19"), instant: false, 4, "ui9_icon_profession_skill_4_3", "ui9_icon_profession_skill_big_4_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_19"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_19"), 4, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 6, 10, costTimeWhenFinished: false, 100, 0, 0, 25000, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_19"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_19")));
		_dataArray.Add(new ProfessionSkillItem(20, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_20"), instant: false, 5, "ui9_icon_profession_skill_5_0", "ui9_icon_profession_skill_big_5_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_20"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_20"), 1, 4, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 5, 20, 10, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_20"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_20")));
		_dataArray.Add(new ProfessionSkillItem(21, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_21"), instant: false, 5, "ui9_icon_profession_skill_5_1", "ui9_icon_profession_skill_big_5_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_21"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_21"), 2, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 3, 10, costTimeWhenFinished: false, 20, 40, 20, 5000, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_21"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_21")));
		_dataArray.Add(new ProfessionSkillItem(22, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_22"), instant: false, 5, "ui9_icon_profession_skill_5_2", "ui9_icon_profession_skill_big_5_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_22"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_22"), 3, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 50, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_22"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_22")));
		_dataArray.Add(new ProfessionSkillItem(23, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_23"), instant: true, 5, "ui9_icon_profession_skill_5_3", "ui9_icon_profession_skill_big_5_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_23"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_23"), 4, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 3, 20, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_23"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_23")));
		_dataArray.Add(new ProfessionSkillItem(24, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_24"), instant: false, 6, "ui9_icon_profession_skill_6_0", "ui9_icon_profession_skill_big_6_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_24"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_24"), 1, 2, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 5, 20, 10, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_24"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_24")));
		_dataArray.Add(new ProfessionSkillItem(25, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_25"), instant: false, 6, "ui9_icon_profession_skill_6_1", "ui9_icon_profession_skill_big_6_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_25"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_25"), 2, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 1, 10, costTimeWhenFinished: false, 20, 20, 10, 5000, new List<ResourceInfo>
		{
			new ResourceInfo(7, 1000)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_25"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_25")));
		_dataArray.Add(new ProfessionSkillItem(26, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_26"), instant: false, 6, "ui9_icon_profession_skill_6_2", "ui9_icon_profession_skill_big_6_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_26"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_26"), 3, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 3, 15, costTimeWhenFinished: false, 50, 0, 0, 15000, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_26"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_26")));
		_dataArray.Add(new ProfessionSkillItem(27, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_27"), instant: false, 6, "ui9_icon_profession_skill_6_3", "ui9_icon_profession_skill_big_6_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_27"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_27"), 4, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 1, 0, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_27"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_27")));
		_dataArray.Add(new ProfessionSkillItem(28, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_28"), instant: false, 7, "ui9_icon_profession_skill_7_0", "ui9_icon_profession_skill_big_7_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_28"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_28"), 1, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 1, 5, costTimeWhenFinished: false, 5, 0, 0, 0, new List<ResourceInfo>
		{
			new ResourceInfo(7, 100)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_28"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_28")));
		_dataArray.Add(new ProfessionSkillItem(29, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_29"), instant: false, 7, "ui9_icon_profession_skill_7_1", "ui9_icon_profession_skill_big_7_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_29"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_29"), 2, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 20, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_29"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_29")));
		_dataArray.Add(new ProfessionSkillItem(30, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_30"), instant: false, 7, "ui9_icon_profession_skill_7_2", "ui9_icon_profession_skill_big_7_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_30"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_30"), 3, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 50, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_30"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_30")));
		_dataArray.Add(new ProfessionSkillItem(31, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_31"), instant: false, 7, "ui9_icon_profession_skill_7_3", "ui9_icon_profession_skill_big_7_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_31"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_31"), 4, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 12, 20, costTimeWhenFinished: false, 100, 0, 0, 25000, new List<ResourceInfo>
		{
			new ResourceInfo(7, 5000)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_31"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_31")));
		_dataArray.Add(new ProfessionSkillItem(32, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_32"), instant: false, 8, "ui9_icon_profession_skill_8_0", "ui9_icon_profession_skill_big_8_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_32"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_32"), 1, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 1, 10, costTimeWhenFinished: false, 15, 20, 10, 0, new List<ResourceInfo>
		{
			new ResourceInfo(7, 100)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_32"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_32")));
		_dataArray.Add(new ProfessionSkillItem(33, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_33"), instant: false, 8, "ui9_icon_profession_skill_8_1", "ui9_icon_profession_skill_big_8_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_33"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_33"), 2, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 3, 10, costTimeWhenFinished: false, 30, 20, 10, 5000, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_33"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_33")));
		_dataArray.Add(new ProfessionSkillItem(34, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_34"), instant: false, 8, "ui9_icon_profession_skill_8_2", "ui9_icon_profession_skill_big_8_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_34"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_34"), 3, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 75, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_34"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_34")));
		_dataArray.Add(new ProfessionSkillItem(35, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_35"), instant: true, 8, "ui9_icon_profession_skill_8_3", "ui9_icon_profession_skill_big_8_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_35"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_35"), 4, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 6, 20, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>
		{
			new ResourceInfo(7, 5000)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_35"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_35")));
		_dataArray.Add(new ProfessionSkillItem(36, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_36"), instant: false, 9, "ui9_icon_profession_skill_9_0", "ui9_icon_profession_skill_big_9_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_36"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_36"), 1, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 1, 10, costTimeWhenFinished: false, 5, 20, 10, 0, new List<ResourceInfo>
		{
			new ResourceInfo(7, 10)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_36"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_36")));
		_dataArray.Add(new ProfessionSkillItem(37, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_37"), instant: true, 9, "ui9_icon_profession_skill_9_1", "ui9_icon_profession_skill_big_9_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_37"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_37"), 2, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 1, 5, costTimeWhenFinished: false, 20, 20, 10, 0, new List<ResourceInfo>
		{
			new ResourceInfo(7, 100)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_37"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_37")));
		_dataArray.Add(new ProfessionSkillItem(38, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_38"), instant: false, 9, "ui9_icon_profession_skill_9_2", "ui9_icon_profession_skill_big_9_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_38"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_38"), 3, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 3, 10, costTimeWhenFinished: false, 50, 0, 0, 0, new List<ResourceInfo>
		{
			new ResourceInfo(7, 1000)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_38"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_38")));
		_dataArray.Add(new ProfessionSkillItem(39, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_39"), instant: false, 9, "ui9_icon_profession_skill_9_3", "ui9_icon_profession_skill_big_9_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_39"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_39"), 4, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 0, 1, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>
		{
			new ResourceInfo(7, 500)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_39"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_39")));
		_dataArray.Add(new ProfessionSkillItem(40, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_40"), instant: false, 10, "ui9_icon_profession_skill_10_0", "ui9_icon_profession_skill_big_10_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_40"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_40"), 1, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 5, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_40"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_40")));
		_dataArray.Add(new ProfessionSkillItem(41, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_41"), instant: true, 10, "ui9_icon_profession_skill_10_1", "ui9_icon_profession_skill_big_10_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_41"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_41"), 2, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 12, 10, costTimeWhenFinished: false, 20, 720, 360, 2500, new List<ResourceInfo>
		{
			new ResourceInfo(7, 1000)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_41"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_41")));
		_dataArray.Add(new ProfessionSkillItem(42, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_42"), instant: false, 10, "ui9_icon_profession_skill_10_2", "ui9_icon_profession_skill_big_10_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_42"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_42"), 3, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 36, 10, costTimeWhenFinished: false, 50, 0, 0, 25000, new List<ResourceInfo>
		{
			new ResourceInfo(7, 5000)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_42"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_42")));
		_dataArray.Add(new ProfessionSkillItem(43, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_43"), instant: false, 10, "ui9_icon_profession_skill_10_3", "ui9_icon_profession_skill_big_10_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_43"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_43"), 4, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_43"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_43")));
		_dataArray.Add(new ProfessionSkillItem(44, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_44"), instant: true, 11, "ui9_icon_profession_skill_11_0", "ui9_icon_profession_skill_big_11_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_44"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_44"), 1, 3, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 5, 20, 10, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_44"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_44")));
		_dataArray.Add(new ProfessionSkillItem(45, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_45"), instant: true, 11, "ui9_icon_profession_skill_11_1", "ui9_icon_profession_skill_big_11_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_45"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_45"), 2, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 20, 20, 10, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_45"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_45")));
		_dataArray.Add(new ProfessionSkillItem(46, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_46"), instant: false, 11, "ui9_icon_profession_skill_11_2", "ui9_icon_profession_skill_big_11_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_46"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_46"), 3, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 1, 0, costTimeWhenFinished: false, 50, 0, 0, 2500, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_46"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_46")));
		_dataArray.Add(new ProfessionSkillItem(47, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_47"), instant: false, 11, "ui9_icon_profession_skill_11_3", "ui9_icon_profession_skill_big_11_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_47"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_47"), 4, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: true, EProfessionSkillType.Active, 0, 0, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>
		{
			new ResourceInfo(0, 10000),
			new ResourceInfo(1, 10000),
			new ResourceInfo(2, 10000),
			new ResourceInfo(3, 10000),
			new ResourceInfo(4, 10000),
			new ResourceInfo(5, 10000)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_47"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_47")));
		_dataArray.Add(new ProfessionSkillItem(48, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_48"), instant: true, 12, "ui9_icon_profession_skill_12_0", "ui9_icon_profession_skill_big_12_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_48"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_48"), 1, 5, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 5, 20, 10, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_48"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_48")));
		_dataArray.Add(new ProfessionSkillItem(49, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_49"), instant: false, 12, "ui9_icon_profession_skill_12_1", "ui9_icon_profession_skill_big_12_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_49"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_49"), 2, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 1, 5, costTimeWhenFinished: false, 20, 20, 10, 500, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_49"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_49")));
		_dataArray.Add(new ProfessionSkillItem(50, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_50"), instant: false, 12, "ui9_icon_profession_skill_12_2", "ui9_icon_profession_skill_big_12_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_50"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_50"), 3, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 24, 0, costTimeWhenFinished: false, 50, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_50"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_50")));
		_dataArray.Add(new ProfessionSkillItem(51, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_51"), instant: false, 12, "ui9_icon_profession_skill_12_3", "ui9_icon_profession_skill_big_12_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_51"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_51"), 4, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_51"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_51")));
		_dataArray.Add(new ProfessionSkillItem(52, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_52"), instant: false, 13, "ui9_icon_profession_skill_13_0", "ui9_icon_profession_skill_big_13_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_52"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_52"), 1, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 0, 5, costTimeWhenFinished: false, 5, 20, 10, 0, new List<ResourceInfo>
		{
			new ResourceInfo(5, 100)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_52"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_52")));
		_dataArray.Add(new ProfessionSkillItem(53, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_53"), instant: true, 13, "ui9_icon_profession_skill_13_1", "ui9_icon_profession_skill_big_13_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_53"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_53"), 2, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 3, 10, costTimeWhenFinished: false, 30, 60, 30, 0, new List<ResourceInfo>
		{
			new ResourceInfo(5, 2500)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_53"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_53")));
		_dataArray.Add(new ProfessionSkillItem(54, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_54"), instant: false, 13, "ui9_icon_profession_skill_13_2", "ui9_icon_profession_skill_big_13_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_54"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_54"), 3, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 50, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_54"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_54")));
		_dataArray.Add(new ProfessionSkillItem(55, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_55"), instant: false, 13, "ui9_icon_profession_skill_13_3", "ui9_icon_profession_skill_big_13_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_55"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_55"), 4, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 1, 10, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_55"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_55")));
		_dataArray.Add(new ProfessionSkillItem(56, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_56"), instant: true, 14, "ui9_icon_profession_skill_14_0", "ui9_icon_profession_skill_big_14_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_56"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_56"), 1, 1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 5, 20, 10, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_56"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_56")));
		_dataArray.Add(new ProfessionSkillItem(57, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_57"), instant: false, 14, "ui9_icon_profession_skill_14_1", "ui9_icon_profession_skill_big_14_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_57"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_57"), 2, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 3, 5, costTimeWhenFinished: false, 20, 20, 10, 2500, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_57"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_57")));
		_dataArray.Add(new ProfessionSkillItem(58, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_58"), instant: false, 14, "ui9_icon_profession_skill_14_2", "ui9_icon_profession_skill_big_14_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_58"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_58"), 3, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 12, 10, costTimeWhenFinished: false, 50, 0, 0, 50000, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_58"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_58")));
		_dataArray.Add(new ProfessionSkillItem(59, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_59"), instant: false, 14, "ui9_icon_profession_skill_14_3", "ui9_icon_profession_skill_big_14_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_59"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_59"), 4, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_59"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_59")));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new ProfessionSkillItem(60, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_60"), instant: false, 15, "ui9_icon_profession_skill_15_0", "ui9_icon_profession_skill_big_15_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_60"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_60"), 1, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 1, 5, costTimeWhenFinished: false, 15, 20, 10, 0, new List<ResourceInfo>(), 14000, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_60"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_60")));
		_dataArray.Add(new ProfessionSkillItem(61, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_61"), instant: false, 15, "ui9_icon_profession_skill_15_1", "ui9_icon_profession_skill_big_15_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_61"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_61"), 2, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 1, 5, costTimeWhenFinished: false, 30, 20, 10, 0, new List<ResourceInfo>
		{
			new ResourceInfo(7, 500)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_61"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_61")));
		_dataArray.Add(new ProfessionSkillItem(62, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_62"), instant: false, 15, "ui9_icon_profession_skill_15_2", "ui9_icon_profession_skill_big_15_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_62"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_62"), 3, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 0, 0, costTimeWhenFinished: false, 75, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_62"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_62")));
		_dataArray.Add(new ProfessionSkillItem(63, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_63"), instant: false, 15, "ui9_icon_profession_skill_15_3", "ui9_icon_profession_skill_big_15_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_63"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_63"), 4, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_63"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_63")));
		_dataArray.Add(new ProfessionSkillItem(64, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_64"), instant: false, 16, "ui9_icon_profession_skill_16_0", "ui9_icon_profession_skill_big_16_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_64"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_64"), 1, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 1, 5, costTimeWhenFinished: false, 5, 0, 0, 0, new List<ResourceInfo>
		{
			new ResourceInfo(7, 100)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_64"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_64")));
		_dataArray.Add(new ProfessionSkillItem(65, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_65"), instant: false, 16, "ui9_icon_profession_skill_16_1", "ui9_icon_profession_skill_big_16_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_65"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_65"), 2, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 20, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_65"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_65")));
		_dataArray.Add(new ProfessionSkillItem(66, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_66"), instant: false, 16, "ui9_icon_profession_skill_16_2", "ui9_icon_profession_skill_big_16_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_66"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_66"), 3, -1, EProfessionSkillTriggerType.Passive, ignoreCanExecuteSkill: false, EProfessionSkillType.Passive, 1, 0, costTimeWhenFinished: false, 50, 0, 0, 0, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_66"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_66")));
		_dataArray.Add(new ProfessionSkillItem(67, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_67"), instant: false, 16, "ui9_icon_profession_skill_16_3", "ui9_icon_profession_skill_big_16_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_67"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_67"), 4, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 12, 20, costTimeWhenFinished: false, 100, 0, 0, 25000, new List<ResourceInfo>
		{
			new ResourceInfo(7, 5000)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_67"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_67")));
		_dataArray.Add(new ProfessionSkillItem(68, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_68"), instant: false, 17, "ui9_icon_profession_skill_17_0", "ui9_icon_profession_skill_big_17_0", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_68"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_68"), 1, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 1, 5, costTimeWhenFinished: false, 10, 20, 10, 1000, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_68"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_68")));
		_dataArray.Add(new ProfessionSkillItem(69, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_69"), instant: false, 17, "ui9_icon_profession_skill_17_1", "ui9_icon_profession_skill_big_17_1", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_69"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_69"), 2, -1, EProfessionSkillTriggerType.Interactive, ignoreCanExecuteSkill: false, EProfessionSkillType.Interactive, 1, 10, costTimeWhenFinished: false, 30, 120, 60, 0, new List<ResourceInfo>
		{
			new ResourceInfo(7, 2500)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_69"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_69")));
		_dataArray.Add(new ProfessionSkillItem(70, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_70"), instant: false, 17, "ui9_icon_profession_skill_17_2", "ui9_icon_profession_skill_big_17_2", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_70"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_70"), 3, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 6, 10, costTimeWhenFinished: false, 75, 0, 0, 25000, new List<ResourceInfo>(), 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_70"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_70")));
		_dataArray.Add(new ProfessionSkillItem(71, LocalStringManager.GetConfig("ProfessionSkill_language", "Name_71"), instant: true, 17, "ui9_icon_profession_skill_17_3", "ui9_icon_profession_skill_big_17_3", LocalStringManager.GetConfig("ProfessionSkill_language", "Desc_71"), LocalStringManager.GetConfig("ProfessionSkill_language", "FunctionalDesc_71"), 4, -1, EProfessionSkillTriggerType.Active, ignoreCanExecuteSkill: false, EProfessionSkillType.Active, 12, 5, costTimeWhenFinished: false, 100, 0, 0, 0, new List<ResourceInfo>
		{
			new ResourceInfo(7, 5000)
		}, 0, LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockDesc_71"), LocalStringManager.GetConfig("ProfessionSkill_language", "SkillUnlockExplain_71")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ProfessionSkillItem>(72);
		CreateItems0();
		CreateItems1();
	}
}
