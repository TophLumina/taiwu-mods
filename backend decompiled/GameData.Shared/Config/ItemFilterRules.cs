using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class ItemFilterRules : ConfigData<ItemFilterRulesItem, short>
{
	public static class DefKey
	{
		public const short SelectFuyuSword = 0;

		public const short SelectGrade6CombatSkillBook = 1;

		public const short SelectVegetarianFood = 2;

		public const short SelectMeatFood = 3;

		public const short SelectGrade5CombatSkillBook = 4;

		public const short SelectGrade5LifeSkillBook = 5;

		public const short SelectHotPoisonIntroductionGroup = 6;

		public const short SelectAllFoodAndTeaWine = 7;

		public const short SelectWoodOuter = 8;

		public const short SelectWoodInner = 9;

		public const short SelectMetalOuter = 10;

		public const short SelectMetalInner = 11;

		public const short SelectJadeOuter = 12;

		public const short SelectJadeInner = 13;

		public const short SelectFabricOuter = 14;

		public const short SelectFabricInner = 15;

		public const short SelectPoisonRotten = 16;

		public const short SelectPoisonIllusory = 17;

		public const short SelectWeapon = 18;

		public const short SelectFluter = 19;

		public const short SelectZither = 20;

		public const short SelectGiftGrade0 = 21;

		public const short SelectGiftGrade1 = 22;

		public const short SelectGiftGrade2 = 23;

		public const short SelectGiftGrade3 = 24;

		public const short SelectGiftGrade4 = 25;

		public const short SelectGiftGrade5 = 26;

		public const short SelectGiftGrade6 = 27;

		public const short SelectGiftGrade7 = 28;

		public const short SelectGiftGrade8 = 29;

		public const short SelectGiftNoWineGrade0 = 30;

		public const short SelectGiftNoWineGrade1 = 31;

		public const short SelectGiftNoWineGrade2 = 32;

		public const short SelectGiftNoWineGrade3 = 33;

		public const short SelectGiftNoWineGrade4 = 34;

		public const short SelectGiftNoWineGrade5 = 35;

		public const short SelectGiftNoWineGrade6 = 36;

		public const short SelectGiftNoWineGrade7 = 37;

		public const short SelectGiftNoWineGrade8 = 38;

		public const short SelectGiftNoMeatGrade0 = 39;

		public const short SelectGiftNoMeatGrade1 = 40;

		public const short SelectGiftNoMeatGrade2 = 41;

		public const short SelectGiftNoMeatGrade3 = 42;

		public const short SelectGiftNoMeatGrade4 = 43;

		public const short SelectGiftNoMeatGrade5 = 44;

		public const short SelectGiftNoMeatGrade6 = 45;

		public const short SelectGiftNoMeatGrade7 = 46;

		public const short SelectGiftNoMeatGrade8 = 47;

		public const short SelectGiftNoWineMeatGrade0 = 48;

		public const short SelectGiftNoWineMeatGrade1 = 49;

		public const short SelectGiftNoWineMeatGrade2 = 50;

		public const short SelectGiftNoWineMeatGrade3 = 51;

		public const short SelectGiftNoWineMeatGrade4 = 52;

		public const short SelectGiftNoWineMeatGrade5 = 53;

		public const short SelectGiftNoWineMeatGrade6 = 54;

		public const short SelectGiftNoWineMeatGrade7 = 55;

		public const short SelectGiftNoWineMeatGrade8 = 56;

		public const short SelectSomethingCanEat = 57;

		public const short SelectTea = 58;

		public const short SelectWine = 59;

		public const short SelectPoisonMedicine = 60;

		public const short SelectBoat = 61;

		public const short SelectRope = 62;

		public const short SelectSwordFragments = 63;

		public const short SelectWesternPresent = 64;

		public const short SelectCombatSkillBook = 65;

		public const short SelectLifeSkillBook = 66;

		public const short SelectLegendaryBook = 67;

		public const short SelectPoisonGrade1 = 68;

		public const short SelectPoisonGrade2 = 69;

		public const short SelectPoisonGrade3 = 70;

		public const short SelectPoisonGrade4 = 71;

		public const short SelectPoisonGrade5 = 72;

		public const short SelectPoisonGrade6 = 73;

		public const short SelectPoisonGrade7 = 74;

		public const short SelectPoisonGrade8 = 75;

		public const short SelectPoisonGrade9 = 76;
	}

	public static class DefValue
	{
		public static ItemFilterRulesItem SelectFuyuSword => Instance[(short)0];

		public static ItemFilterRulesItem SelectGrade6CombatSkillBook => Instance[(short)1];

		public static ItemFilterRulesItem SelectVegetarianFood => Instance[(short)2];

		public static ItemFilterRulesItem SelectMeatFood => Instance[(short)3];

		public static ItemFilterRulesItem SelectGrade5CombatSkillBook => Instance[(short)4];

		public static ItemFilterRulesItem SelectGrade5LifeSkillBook => Instance[(short)5];

		public static ItemFilterRulesItem SelectHotPoisonIntroductionGroup => Instance[(short)6];

		public static ItemFilterRulesItem SelectAllFoodAndTeaWine => Instance[(short)7];

		public static ItemFilterRulesItem SelectWoodOuter => Instance[(short)8];

		public static ItemFilterRulesItem SelectWoodInner => Instance[(short)9];

		public static ItemFilterRulesItem SelectMetalOuter => Instance[(short)10];

		public static ItemFilterRulesItem SelectMetalInner => Instance[(short)11];

		public static ItemFilterRulesItem SelectJadeOuter => Instance[(short)12];

		public static ItemFilterRulesItem SelectJadeInner => Instance[(short)13];

		public static ItemFilterRulesItem SelectFabricOuter => Instance[(short)14];

		public static ItemFilterRulesItem SelectFabricInner => Instance[(short)15];

		public static ItemFilterRulesItem SelectPoisonRotten => Instance[(short)16];

		public static ItemFilterRulesItem SelectPoisonIllusory => Instance[(short)17];

		public static ItemFilterRulesItem SelectWeapon => Instance[(short)18];

		public static ItemFilterRulesItem SelectFluter => Instance[(short)19];

		public static ItemFilterRulesItem SelectZither => Instance[(short)20];

		public static ItemFilterRulesItem SelectGiftGrade0 => Instance[(short)21];

		public static ItemFilterRulesItem SelectGiftGrade1 => Instance[(short)22];

		public static ItemFilterRulesItem SelectGiftGrade2 => Instance[(short)23];

		public static ItemFilterRulesItem SelectGiftGrade3 => Instance[(short)24];

		public static ItemFilterRulesItem SelectGiftGrade4 => Instance[(short)25];

		public static ItemFilterRulesItem SelectGiftGrade5 => Instance[(short)26];

		public static ItemFilterRulesItem SelectGiftGrade6 => Instance[(short)27];

		public static ItemFilterRulesItem SelectGiftGrade7 => Instance[(short)28];

		public static ItemFilterRulesItem SelectGiftGrade8 => Instance[(short)29];

		public static ItemFilterRulesItem SelectGiftNoWineGrade0 => Instance[(short)30];

		public static ItemFilterRulesItem SelectGiftNoWineGrade1 => Instance[(short)31];

		public static ItemFilterRulesItem SelectGiftNoWineGrade2 => Instance[(short)32];

		public static ItemFilterRulesItem SelectGiftNoWineGrade3 => Instance[(short)33];

		public static ItemFilterRulesItem SelectGiftNoWineGrade4 => Instance[(short)34];

		public static ItemFilterRulesItem SelectGiftNoWineGrade5 => Instance[(short)35];

		public static ItemFilterRulesItem SelectGiftNoWineGrade6 => Instance[(short)36];

		public static ItemFilterRulesItem SelectGiftNoWineGrade7 => Instance[(short)37];

		public static ItemFilterRulesItem SelectGiftNoWineGrade8 => Instance[(short)38];

		public static ItemFilterRulesItem SelectGiftNoMeatGrade0 => Instance[(short)39];

		public static ItemFilterRulesItem SelectGiftNoMeatGrade1 => Instance[(short)40];

		public static ItemFilterRulesItem SelectGiftNoMeatGrade2 => Instance[(short)41];

		public static ItemFilterRulesItem SelectGiftNoMeatGrade3 => Instance[(short)42];

		public static ItemFilterRulesItem SelectGiftNoMeatGrade4 => Instance[(short)43];

		public static ItemFilterRulesItem SelectGiftNoMeatGrade5 => Instance[(short)44];

		public static ItemFilterRulesItem SelectGiftNoMeatGrade6 => Instance[(short)45];

		public static ItemFilterRulesItem SelectGiftNoMeatGrade7 => Instance[(short)46];

		public static ItemFilterRulesItem SelectGiftNoMeatGrade8 => Instance[(short)47];

		public static ItemFilterRulesItem SelectGiftNoWineMeatGrade0 => Instance[(short)48];

		public static ItemFilterRulesItem SelectGiftNoWineMeatGrade1 => Instance[(short)49];

		public static ItemFilterRulesItem SelectGiftNoWineMeatGrade2 => Instance[(short)50];

		public static ItemFilterRulesItem SelectGiftNoWineMeatGrade3 => Instance[(short)51];

		public static ItemFilterRulesItem SelectGiftNoWineMeatGrade4 => Instance[(short)52];

		public static ItemFilterRulesItem SelectGiftNoWineMeatGrade5 => Instance[(short)53];

		public static ItemFilterRulesItem SelectGiftNoWineMeatGrade6 => Instance[(short)54];

		public static ItemFilterRulesItem SelectGiftNoWineMeatGrade7 => Instance[(short)55];

		public static ItemFilterRulesItem SelectGiftNoWineMeatGrade8 => Instance[(short)56];

		public static ItemFilterRulesItem SelectSomethingCanEat => Instance[(short)57];

		public static ItemFilterRulesItem SelectTea => Instance[(short)58];

		public static ItemFilterRulesItem SelectWine => Instance[(short)59];

		public static ItemFilterRulesItem SelectPoisonMedicine => Instance[(short)60];

		public static ItemFilterRulesItem SelectBoat => Instance[(short)61];

		public static ItemFilterRulesItem SelectRope => Instance[(short)62];

		public static ItemFilterRulesItem SelectSwordFragments => Instance[(short)63];

		public static ItemFilterRulesItem SelectWesternPresent => Instance[(short)64];

		public static ItemFilterRulesItem SelectCombatSkillBook => Instance[(short)65];

		public static ItemFilterRulesItem SelectLifeSkillBook => Instance[(short)66];

		public static ItemFilterRulesItem SelectLegendaryBook => Instance[(short)67];

		public static ItemFilterRulesItem SelectPoisonGrade1 => Instance[(short)68];

		public static ItemFilterRulesItem SelectPoisonGrade2 => Instance[(short)69];

		public static ItemFilterRulesItem SelectPoisonGrade3 => Instance[(short)70];

		public static ItemFilterRulesItem SelectPoisonGrade4 => Instance[(short)71];

		public static ItemFilterRulesItem SelectPoisonGrade5 => Instance[(short)72];

		public static ItemFilterRulesItem SelectPoisonGrade6 => Instance[(short)73];

		public static ItemFilterRulesItem SelectPoisonGrade7 => Instance[(short)74];

		public static ItemFilterRulesItem SelectPoisonGrade8 => Instance[(short)75];

		public static ItemFilterRulesItem SelectPoisonGrade9 => Instance[(short)76];
	}

	public static ItemFilterRules Instance = new ItemFilterRules();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "AppointId", "AppointOrIdCore", "TemplateId" };

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
		_dataArray.Add(new ItemFilterRulesItem(0, new PresetItemTemplateId("Misc", 239), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(1, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(1001, 5, 5)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(2, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(700, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(3, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(701, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(4, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(1001, 4, 4)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(5, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(1000, 4, 4)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(6, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 236, 6)
		}));
		_dataArray.Add(new ItemFilterRulesItem(7, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(701, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(901, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(8, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 0, 7)
		}));
		_dataArray.Add(new ItemFilterRulesItem(9, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 7, 7)
		}));
		_dataArray.Add(new ItemFilterRulesItem(10, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 14, 7)
		}));
		_dataArray.Add(new ItemFilterRulesItem(11, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 21, 7)
		}));
		_dataArray.Add(new ItemFilterRulesItem(12, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 28, 7)
		}));
		_dataArray.Add(new ItemFilterRulesItem(13, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 35, 7)
		}));
		_dataArray.Add(new ItemFilterRulesItem(14, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 42, 7)
		}));
		_dataArray.Add(new ItemFilterRulesItem(15, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 49, 7)
		}));
		_dataArray.Add(new ItemFilterRulesItem(16, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 264, 6)
		}));
		_dataArray.Add(new ItemFilterRulesItem(17, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 271, 6)
		}));
		_dataArray.Add(new ItemFilterRulesItem(18, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 0, 8),
			new PresetItemSubTypeWithGradeRange(1, 0, 8),
			new PresetItemSubTypeWithGradeRange(2, 0, 8),
			new PresetItemSubTypeWithGradeRange(3, 0, 8),
			new PresetItemSubTypeWithGradeRange(4, 0, 8),
			new PresetItemSubTypeWithGradeRange(5, 0, 8),
			new PresetItemSubTypeWithGradeRange(6, 0, 8),
			new PresetItemSubTypeWithGradeRange(7, 0, 8),
			new PresetItemSubTypeWithGradeRange(8, 0, 8),
			new PresetItemSubTypeWithGradeRange(9, 0, 8),
			new PresetItemSubTypeWithGradeRange(10, 0, 8),
			new PresetItemSubTypeWithGradeRange(11, 0, 8),
			new PresetItemSubTypeWithGradeRange(12, 0, 8),
			new PresetItemSubTypeWithGradeRange(13, 0, 8),
			new PresetItemSubTypeWithGradeRange(14, 0, 8),
			new PresetItemSubTypeWithGradeRange(15, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(19, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 219, 54)
		}));
		_dataArray.Add(new ItemFilterRulesItem(20, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 705, 54)
		}));
		_dataArray.Add(new ItemFilterRulesItem(21, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 0, 8),
			new PresetItemSubTypeWithGradeRange(1, 0, 8),
			new PresetItemSubTypeWithGradeRange(2, 0, 8),
			new PresetItemSubTypeWithGradeRange(3, 0, 8),
			new PresetItemSubTypeWithGradeRange(4, 0, 8),
			new PresetItemSubTypeWithGradeRange(5, 0, 8),
			new PresetItemSubTypeWithGradeRange(6, 0, 8),
			new PresetItemSubTypeWithGradeRange(7, 0, 8),
			new PresetItemSubTypeWithGradeRange(8, 0, 8),
			new PresetItemSubTypeWithGradeRange(9, 0, 8),
			new PresetItemSubTypeWithGradeRange(10, 0, 8),
			new PresetItemSubTypeWithGradeRange(11, 0, 8),
			new PresetItemSubTypeWithGradeRange(12, 1, 8),
			new PresetItemSubTypeWithGradeRange(13, 1, 8),
			new PresetItemSubTypeWithGradeRange(14, 1, 8),
			new PresetItemSubTypeWithGradeRange(15, 1, 8),
			new PresetItemSubTypeWithGradeRange(100, 0, 8),
			new PresetItemSubTypeWithGradeRange(101, 0, 8),
			new PresetItemSubTypeWithGradeRange(102, 0, 8),
			new PresetItemSubTypeWithGradeRange(103, 0, 8),
			new PresetItemSubTypeWithGradeRange(200, 0, 8),
			new PresetItemSubTypeWithGradeRange(400, 0, 8),
			new PresetItemSubTypeWithGradeRange(600, 0, 8),
			new PresetItemSubTypeWithGradeRange(300, 0, 8),
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(701, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(901, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 0, 8),
			new PresetItemSubTypeWithGradeRange(501, 0, 8),
			new PresetItemSubTypeWithGradeRange(502, 0, 8),
			new PresetItemSubTypeWithGradeRange(503, 0, 8),
			new PresetItemSubTypeWithGradeRange(504, 0, 8),
			new PresetItemSubTypeWithGradeRange(505, 1, 8),
			new PresetItemSubTypeWithGradeRange(506, 1, 8),
			new PresetItemSubTypeWithGradeRange(1000, 0, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 0, 8),
			new PresetItemSubTypeWithGradeRange(801, 0, 8),
			new PresetItemSubTypeWithGradeRange(1205, 0, 8),
			new PresetItemSubTypeWithGradeRange(1206, 0, 8),
			new PresetItemSubTypeWithGradeRange(1100, 0, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(22, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 0, 8),
			new PresetItemSubTypeWithGradeRange(1, 0, 8),
			new PresetItemSubTypeWithGradeRange(2, 0, 8),
			new PresetItemSubTypeWithGradeRange(3, 0, 8),
			new PresetItemSubTypeWithGradeRange(4, 0, 8),
			new PresetItemSubTypeWithGradeRange(5, 0, 8),
			new PresetItemSubTypeWithGradeRange(6, 0, 8),
			new PresetItemSubTypeWithGradeRange(7, 0, 8),
			new PresetItemSubTypeWithGradeRange(8, 0, 8),
			new PresetItemSubTypeWithGradeRange(9, 0, 8),
			new PresetItemSubTypeWithGradeRange(10, 0, 8),
			new PresetItemSubTypeWithGradeRange(11, 0, 8),
			new PresetItemSubTypeWithGradeRange(12, 2, 8),
			new PresetItemSubTypeWithGradeRange(13, 2, 8),
			new PresetItemSubTypeWithGradeRange(14, 2, 8),
			new PresetItemSubTypeWithGradeRange(15, 2, 8),
			new PresetItemSubTypeWithGradeRange(100, 0, 8),
			new PresetItemSubTypeWithGradeRange(101, 0, 8),
			new PresetItemSubTypeWithGradeRange(102, 0, 8),
			new PresetItemSubTypeWithGradeRange(103, 0, 8),
			new PresetItemSubTypeWithGradeRange(200, 0, 8),
			new PresetItemSubTypeWithGradeRange(400, 0, 8),
			new PresetItemSubTypeWithGradeRange(600, 0, 8),
			new PresetItemSubTypeWithGradeRange(300, 1, 8),
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(701, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(901, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 1, 8),
			new PresetItemSubTypeWithGradeRange(501, 1, 8),
			new PresetItemSubTypeWithGradeRange(502, 1, 8),
			new PresetItemSubTypeWithGradeRange(503, 1, 8),
			new PresetItemSubTypeWithGradeRange(504, 1, 8),
			new PresetItemSubTypeWithGradeRange(505, 2, 8),
			new PresetItemSubTypeWithGradeRange(506, 2, 8),
			new PresetItemSubTypeWithGradeRange(1000, 1, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 1, 8),
			new PresetItemSubTypeWithGradeRange(801, 1, 8),
			new PresetItemSubTypeWithGradeRange(1205, 1, 8),
			new PresetItemSubTypeWithGradeRange(1206, 1, 8),
			new PresetItemSubTypeWithGradeRange(1100, 1, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(23, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 1, 8),
			new PresetItemSubTypeWithGradeRange(1, 1, 8),
			new PresetItemSubTypeWithGradeRange(2, 1, 8),
			new PresetItemSubTypeWithGradeRange(3, 1, 8),
			new PresetItemSubTypeWithGradeRange(4, 1, 8),
			new PresetItemSubTypeWithGradeRange(5, 1, 8),
			new PresetItemSubTypeWithGradeRange(6, 1, 8),
			new PresetItemSubTypeWithGradeRange(7, 1, 8),
			new PresetItemSubTypeWithGradeRange(8, 1, 8),
			new PresetItemSubTypeWithGradeRange(9, 1, 8),
			new PresetItemSubTypeWithGradeRange(10, 1, 8),
			new PresetItemSubTypeWithGradeRange(11, 1, 8),
			new PresetItemSubTypeWithGradeRange(12, 3, 8),
			new PresetItemSubTypeWithGradeRange(13, 3, 8),
			new PresetItemSubTypeWithGradeRange(14, 3, 8),
			new PresetItemSubTypeWithGradeRange(15, 3, 8),
			new PresetItemSubTypeWithGradeRange(100, 1, 8),
			new PresetItemSubTypeWithGradeRange(101, 1, 8),
			new PresetItemSubTypeWithGradeRange(102, 1, 8),
			new PresetItemSubTypeWithGradeRange(103, 1, 8),
			new PresetItemSubTypeWithGradeRange(200, 1, 8),
			new PresetItemSubTypeWithGradeRange(400, 1, 8),
			new PresetItemSubTypeWithGradeRange(600, 1, 8),
			new PresetItemSubTypeWithGradeRange(300, 2, 8),
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(701, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(901, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 2, 8),
			new PresetItemSubTypeWithGradeRange(501, 2, 8),
			new PresetItemSubTypeWithGradeRange(502, 2, 8),
			new PresetItemSubTypeWithGradeRange(503, 2, 8),
			new PresetItemSubTypeWithGradeRange(504, 2, 8),
			new PresetItemSubTypeWithGradeRange(505, 3, 8),
			new PresetItemSubTypeWithGradeRange(506, 3, 8),
			new PresetItemSubTypeWithGradeRange(1000, 2, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 2, 8),
			new PresetItemSubTypeWithGradeRange(801, 2, 8),
			new PresetItemSubTypeWithGradeRange(1205, 2, 8),
			new PresetItemSubTypeWithGradeRange(1206, 2, 8),
			new PresetItemSubTypeWithGradeRange(1100, 2, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(24, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 2, 8),
			new PresetItemSubTypeWithGradeRange(1, 2, 8),
			new PresetItemSubTypeWithGradeRange(2, 2, 8),
			new PresetItemSubTypeWithGradeRange(3, 2, 8),
			new PresetItemSubTypeWithGradeRange(4, 2, 8),
			new PresetItemSubTypeWithGradeRange(5, 2, 8),
			new PresetItemSubTypeWithGradeRange(6, 2, 8),
			new PresetItemSubTypeWithGradeRange(7, 2, 8),
			new PresetItemSubTypeWithGradeRange(8, 2, 8),
			new PresetItemSubTypeWithGradeRange(9, 2, 8),
			new PresetItemSubTypeWithGradeRange(10, 2, 8),
			new PresetItemSubTypeWithGradeRange(11, 2, 8),
			new PresetItemSubTypeWithGradeRange(12, 4, 8),
			new PresetItemSubTypeWithGradeRange(13, 4, 8),
			new PresetItemSubTypeWithGradeRange(14, 4, 8),
			new PresetItemSubTypeWithGradeRange(15, 4, 8),
			new PresetItemSubTypeWithGradeRange(100, 2, 8),
			new PresetItemSubTypeWithGradeRange(101, 2, 8),
			new PresetItemSubTypeWithGradeRange(102, 2, 8),
			new PresetItemSubTypeWithGradeRange(103, 2, 8),
			new PresetItemSubTypeWithGradeRange(200, 2, 8),
			new PresetItemSubTypeWithGradeRange(400, 2, 8),
			new PresetItemSubTypeWithGradeRange(600, 2, 8),
			new PresetItemSubTypeWithGradeRange(300, 3, 8),
			new PresetItemSubTypeWithGradeRange(700, 1, 8),
			new PresetItemSubTypeWithGradeRange(701, 1, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(901, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 3, 8),
			new PresetItemSubTypeWithGradeRange(501, 3, 8),
			new PresetItemSubTypeWithGradeRange(502, 3, 8),
			new PresetItemSubTypeWithGradeRange(503, 3, 8),
			new PresetItemSubTypeWithGradeRange(504, 3, 8),
			new PresetItemSubTypeWithGradeRange(505, 4, 8),
			new PresetItemSubTypeWithGradeRange(506, 4, 8),
			new PresetItemSubTypeWithGradeRange(1000, 3, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 3, 8),
			new PresetItemSubTypeWithGradeRange(801, 3, 8),
			new PresetItemSubTypeWithGradeRange(1205, 3, 8),
			new PresetItemSubTypeWithGradeRange(1206, 3, 8),
			new PresetItemSubTypeWithGradeRange(1100, 3, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(25, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 3, 8),
			new PresetItemSubTypeWithGradeRange(1, 3, 8),
			new PresetItemSubTypeWithGradeRange(2, 3, 8),
			new PresetItemSubTypeWithGradeRange(3, 3, 8),
			new PresetItemSubTypeWithGradeRange(4, 3, 8),
			new PresetItemSubTypeWithGradeRange(5, 3, 8),
			new PresetItemSubTypeWithGradeRange(6, 3, 8),
			new PresetItemSubTypeWithGradeRange(7, 3, 8),
			new PresetItemSubTypeWithGradeRange(8, 3, 8),
			new PresetItemSubTypeWithGradeRange(9, 3, 8),
			new PresetItemSubTypeWithGradeRange(10, 3, 8),
			new PresetItemSubTypeWithGradeRange(11, 3, 8),
			new PresetItemSubTypeWithGradeRange(12, 5, 8),
			new PresetItemSubTypeWithGradeRange(13, 5, 8),
			new PresetItemSubTypeWithGradeRange(14, 5, 8),
			new PresetItemSubTypeWithGradeRange(15, 5, 8),
			new PresetItemSubTypeWithGradeRange(100, 3, 8),
			new PresetItemSubTypeWithGradeRange(101, 3, 8),
			new PresetItemSubTypeWithGradeRange(102, 3, 8),
			new PresetItemSubTypeWithGradeRange(103, 3, 8),
			new PresetItemSubTypeWithGradeRange(200, 3, 8),
			new PresetItemSubTypeWithGradeRange(400, 3, 8),
			new PresetItemSubTypeWithGradeRange(600, 3, 8),
			new PresetItemSubTypeWithGradeRange(300, 4, 8),
			new PresetItemSubTypeWithGradeRange(700, 2, 8),
			new PresetItemSubTypeWithGradeRange(701, 2, 8),
			new PresetItemSubTypeWithGradeRange(900, 1, 8),
			new PresetItemSubTypeWithGradeRange(901, 1, 8),
			new PresetItemSubTypeWithGradeRange(500, 4, 8),
			new PresetItemSubTypeWithGradeRange(501, 4, 8),
			new PresetItemSubTypeWithGradeRange(502, 4, 8),
			new PresetItemSubTypeWithGradeRange(503, 4, 8),
			new PresetItemSubTypeWithGradeRange(504, 4, 8),
			new PresetItemSubTypeWithGradeRange(505, 5, 8),
			new PresetItemSubTypeWithGradeRange(506, 5, 8),
			new PresetItemSubTypeWithGradeRange(1000, 4, 8),
			new PresetItemSubTypeWithGradeRange(1001, 1, 8),
			new PresetItemSubTypeWithGradeRange(1201, 1, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 4, 8),
			new PresetItemSubTypeWithGradeRange(801, 4, 8),
			new PresetItemSubTypeWithGradeRange(1205, 4, 8),
			new PresetItemSubTypeWithGradeRange(1206, 4, 8),
			new PresetItemSubTypeWithGradeRange(1100, 4, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(26, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 4, 8),
			new PresetItemSubTypeWithGradeRange(1, 4, 8),
			new PresetItemSubTypeWithGradeRange(2, 4, 8),
			new PresetItemSubTypeWithGradeRange(3, 4, 8),
			new PresetItemSubTypeWithGradeRange(4, 4, 8),
			new PresetItemSubTypeWithGradeRange(5, 4, 8),
			new PresetItemSubTypeWithGradeRange(6, 4, 8),
			new PresetItemSubTypeWithGradeRange(7, 4, 8),
			new PresetItemSubTypeWithGradeRange(8, 4, 8),
			new PresetItemSubTypeWithGradeRange(9, 4, 8),
			new PresetItemSubTypeWithGradeRange(10, 4, 8),
			new PresetItemSubTypeWithGradeRange(11, 4, 8),
			new PresetItemSubTypeWithGradeRange(12, 6, 8),
			new PresetItemSubTypeWithGradeRange(13, 6, 8),
			new PresetItemSubTypeWithGradeRange(14, 6, 8),
			new PresetItemSubTypeWithGradeRange(15, 6, 8),
			new PresetItemSubTypeWithGradeRange(100, 4, 8),
			new PresetItemSubTypeWithGradeRange(101, 4, 8),
			new PresetItemSubTypeWithGradeRange(102, 4, 8),
			new PresetItemSubTypeWithGradeRange(103, 4, 8),
			new PresetItemSubTypeWithGradeRange(200, 4, 8),
			new PresetItemSubTypeWithGradeRange(400, 4, 8),
			new PresetItemSubTypeWithGradeRange(600, 4, 8),
			new PresetItemSubTypeWithGradeRange(300, 5, 8),
			new PresetItemSubTypeWithGradeRange(700, 3, 8),
			new PresetItemSubTypeWithGradeRange(701, 3, 8),
			new PresetItemSubTypeWithGradeRange(900, 2, 8),
			new PresetItemSubTypeWithGradeRange(901, 2, 8),
			new PresetItemSubTypeWithGradeRange(500, 5, 8),
			new PresetItemSubTypeWithGradeRange(501, 5, 8),
			new PresetItemSubTypeWithGradeRange(502, 5, 8),
			new PresetItemSubTypeWithGradeRange(503, 5, 8),
			new PresetItemSubTypeWithGradeRange(504, 5, 8),
			new PresetItemSubTypeWithGradeRange(505, 6, 8),
			new PresetItemSubTypeWithGradeRange(506, 6, 8),
			new PresetItemSubTypeWithGradeRange(1000, 5, 8),
			new PresetItemSubTypeWithGradeRange(1001, 2, 8),
			new PresetItemSubTypeWithGradeRange(1201, 2, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 5, 8),
			new PresetItemSubTypeWithGradeRange(801, 5, 8),
			new PresetItemSubTypeWithGradeRange(1205, 5, 8),
			new PresetItemSubTypeWithGradeRange(1206, 5, 8),
			new PresetItemSubTypeWithGradeRange(1100, 5, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(27, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 5, 8),
			new PresetItemSubTypeWithGradeRange(1, 5, 8),
			new PresetItemSubTypeWithGradeRange(2, 5, 8),
			new PresetItemSubTypeWithGradeRange(3, 5, 8),
			new PresetItemSubTypeWithGradeRange(4, 5, 8),
			new PresetItemSubTypeWithGradeRange(5, 5, 8),
			new PresetItemSubTypeWithGradeRange(6, 5, 8),
			new PresetItemSubTypeWithGradeRange(7, 5, 8),
			new PresetItemSubTypeWithGradeRange(8, 5, 8),
			new PresetItemSubTypeWithGradeRange(9, 5, 8),
			new PresetItemSubTypeWithGradeRange(10, 5, 8),
			new PresetItemSubTypeWithGradeRange(11, 5, 8),
			new PresetItemSubTypeWithGradeRange(12, 7, 8),
			new PresetItemSubTypeWithGradeRange(13, 7, 8),
			new PresetItemSubTypeWithGradeRange(14, 7, 8),
			new PresetItemSubTypeWithGradeRange(15, 7, 8),
			new PresetItemSubTypeWithGradeRange(100, 5, 8),
			new PresetItemSubTypeWithGradeRange(101, 5, 8),
			new PresetItemSubTypeWithGradeRange(102, 5, 8),
			new PresetItemSubTypeWithGradeRange(103, 5, 8),
			new PresetItemSubTypeWithGradeRange(200, 5, 8),
			new PresetItemSubTypeWithGradeRange(400, 5, 8),
			new PresetItemSubTypeWithGradeRange(600, 5, 8),
			new PresetItemSubTypeWithGradeRange(300, 6, 8),
			new PresetItemSubTypeWithGradeRange(700, 4, 8),
			new PresetItemSubTypeWithGradeRange(701, 4, 8),
			new PresetItemSubTypeWithGradeRange(900, 3, 8),
			new PresetItemSubTypeWithGradeRange(901, 3, 8),
			new PresetItemSubTypeWithGradeRange(500, 6, 8),
			new PresetItemSubTypeWithGradeRange(501, 6, 8),
			new PresetItemSubTypeWithGradeRange(502, 6, 8),
			new PresetItemSubTypeWithGradeRange(503, 6, 8),
			new PresetItemSubTypeWithGradeRange(504, 6, 8),
			new PresetItemSubTypeWithGradeRange(505, 7, 8),
			new PresetItemSubTypeWithGradeRange(506, 7, 8),
			new PresetItemSubTypeWithGradeRange(1000, 6, 8),
			new PresetItemSubTypeWithGradeRange(1001, 3, 8),
			new PresetItemSubTypeWithGradeRange(1201, 3, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 6, 8),
			new PresetItemSubTypeWithGradeRange(801, 6, 8),
			new PresetItemSubTypeWithGradeRange(1205, 6, 8),
			new PresetItemSubTypeWithGradeRange(1206, 6, 8),
			new PresetItemSubTypeWithGradeRange(1100, 6, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(28, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 6, 8),
			new PresetItemSubTypeWithGradeRange(1, 6, 8),
			new PresetItemSubTypeWithGradeRange(2, 6, 8),
			new PresetItemSubTypeWithGradeRange(3, 6, 8),
			new PresetItemSubTypeWithGradeRange(4, 6, 8),
			new PresetItemSubTypeWithGradeRange(5, 6, 8),
			new PresetItemSubTypeWithGradeRange(6, 6, 8),
			new PresetItemSubTypeWithGradeRange(7, 6, 8),
			new PresetItemSubTypeWithGradeRange(8, 6, 8),
			new PresetItemSubTypeWithGradeRange(9, 6, 8),
			new PresetItemSubTypeWithGradeRange(10, 6, 8),
			new PresetItemSubTypeWithGradeRange(11, 6, 8),
			new PresetItemSubTypeWithGradeRange(12, 8, 8),
			new PresetItemSubTypeWithGradeRange(13, 8, 8),
			new PresetItemSubTypeWithGradeRange(14, 8, 8),
			new PresetItemSubTypeWithGradeRange(15, 8, 8),
			new PresetItemSubTypeWithGradeRange(100, 6, 8),
			new PresetItemSubTypeWithGradeRange(101, 6, 8),
			new PresetItemSubTypeWithGradeRange(102, 6, 8),
			new PresetItemSubTypeWithGradeRange(103, 6, 8),
			new PresetItemSubTypeWithGradeRange(200, 6, 8),
			new PresetItemSubTypeWithGradeRange(400, 6, 8),
			new PresetItemSubTypeWithGradeRange(600, 6, 8),
			new PresetItemSubTypeWithGradeRange(300, 7, 8),
			new PresetItemSubTypeWithGradeRange(700, 5, 8),
			new PresetItemSubTypeWithGradeRange(701, 5, 8),
			new PresetItemSubTypeWithGradeRange(900, 4, 8),
			new PresetItemSubTypeWithGradeRange(901, 4, 8),
			new PresetItemSubTypeWithGradeRange(500, 7, 8),
			new PresetItemSubTypeWithGradeRange(501, 7, 8),
			new PresetItemSubTypeWithGradeRange(502, 7, 8),
			new PresetItemSubTypeWithGradeRange(503, 7, 8),
			new PresetItemSubTypeWithGradeRange(504, 7, 8),
			new PresetItemSubTypeWithGradeRange(505, 8, 8),
			new PresetItemSubTypeWithGradeRange(506, 8, 8),
			new PresetItemSubTypeWithGradeRange(1000, 7, 8),
			new PresetItemSubTypeWithGradeRange(1001, 4, 8),
			new PresetItemSubTypeWithGradeRange(1201, 4, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 7, 8),
			new PresetItemSubTypeWithGradeRange(801, 7, 8),
			new PresetItemSubTypeWithGradeRange(1205, 7, 8),
			new PresetItemSubTypeWithGradeRange(1206, 7, 8),
			new PresetItemSubTypeWithGradeRange(1100, 7, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(29, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 7, 8),
			new PresetItemSubTypeWithGradeRange(1, 7, 8),
			new PresetItemSubTypeWithGradeRange(2, 7, 8),
			new PresetItemSubTypeWithGradeRange(3, 7, 8),
			new PresetItemSubTypeWithGradeRange(4, 7, 8),
			new PresetItemSubTypeWithGradeRange(5, 7, 8),
			new PresetItemSubTypeWithGradeRange(6, 7, 8),
			new PresetItemSubTypeWithGradeRange(7, 7, 8),
			new PresetItemSubTypeWithGradeRange(8, 7, 8),
			new PresetItemSubTypeWithGradeRange(9, 7, 8),
			new PresetItemSubTypeWithGradeRange(10, 7, 8),
			new PresetItemSubTypeWithGradeRange(11, 7, 8),
			new PresetItemSubTypeWithGradeRange(100, 7, 8),
			new PresetItemSubTypeWithGradeRange(101, 7, 8),
			new PresetItemSubTypeWithGradeRange(102, 7, 8),
			new PresetItemSubTypeWithGradeRange(103, 7, 8),
			new PresetItemSubTypeWithGradeRange(200, 7, 8),
			new PresetItemSubTypeWithGradeRange(400, 7, 8),
			new PresetItemSubTypeWithGradeRange(600, 7, 8),
			new PresetItemSubTypeWithGradeRange(300, 8, 8),
			new PresetItemSubTypeWithGradeRange(700, 6, 8),
			new PresetItemSubTypeWithGradeRange(701, 6, 8),
			new PresetItemSubTypeWithGradeRange(900, 5, 8),
			new PresetItemSubTypeWithGradeRange(901, 5, 8),
			new PresetItemSubTypeWithGradeRange(500, 8, 8),
			new PresetItemSubTypeWithGradeRange(501, 8, 8),
			new PresetItemSubTypeWithGradeRange(502, 8, 8),
			new PresetItemSubTypeWithGradeRange(503, 8, 8),
			new PresetItemSubTypeWithGradeRange(504, 8, 8),
			new PresetItemSubTypeWithGradeRange(1000, 8, 8),
			new PresetItemSubTypeWithGradeRange(1001, 5, 8),
			new PresetItemSubTypeWithGradeRange(1201, 5, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 8, 8),
			new PresetItemSubTypeWithGradeRange(801, 8, 8),
			new PresetItemSubTypeWithGradeRange(1205, 8, 8),
			new PresetItemSubTypeWithGradeRange(1206, 8, 8),
			new PresetItemSubTypeWithGradeRange(1100, 8, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(30, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 0, 8),
			new PresetItemSubTypeWithGradeRange(1, 0, 8),
			new PresetItemSubTypeWithGradeRange(2, 0, 8),
			new PresetItemSubTypeWithGradeRange(3, 0, 8),
			new PresetItemSubTypeWithGradeRange(4, 0, 8),
			new PresetItemSubTypeWithGradeRange(5, 0, 8),
			new PresetItemSubTypeWithGradeRange(6, 0, 8),
			new PresetItemSubTypeWithGradeRange(7, 0, 8),
			new PresetItemSubTypeWithGradeRange(8, 0, 8),
			new PresetItemSubTypeWithGradeRange(9, 0, 8),
			new PresetItemSubTypeWithGradeRange(10, 0, 8),
			new PresetItemSubTypeWithGradeRange(11, 0, 8),
			new PresetItemSubTypeWithGradeRange(12, 1, 8),
			new PresetItemSubTypeWithGradeRange(13, 1, 8),
			new PresetItemSubTypeWithGradeRange(14, 1, 8),
			new PresetItemSubTypeWithGradeRange(15, 1, 8),
			new PresetItemSubTypeWithGradeRange(100, 0, 8),
			new PresetItemSubTypeWithGradeRange(101, 0, 8),
			new PresetItemSubTypeWithGradeRange(102, 0, 8),
			new PresetItemSubTypeWithGradeRange(103, 0, 8),
			new PresetItemSubTypeWithGradeRange(200, 0, 8),
			new PresetItemSubTypeWithGradeRange(400, 0, 8),
			new PresetItemSubTypeWithGradeRange(600, 0, 8),
			new PresetItemSubTypeWithGradeRange(300, 0, 8),
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(701, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 0, 8),
			new PresetItemSubTypeWithGradeRange(501, 0, 8),
			new PresetItemSubTypeWithGradeRange(502, 0, 8),
			new PresetItemSubTypeWithGradeRange(503, 0, 8),
			new PresetItemSubTypeWithGradeRange(504, 0, 8),
			new PresetItemSubTypeWithGradeRange(505, 1, 8),
			new PresetItemSubTypeWithGradeRange(506, 1, 8),
			new PresetItemSubTypeWithGradeRange(1000, 0, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 0, 8),
			new PresetItemSubTypeWithGradeRange(801, 0, 8),
			new PresetItemSubTypeWithGradeRange(1205, 0, 8),
			new PresetItemSubTypeWithGradeRange(1206, 0, 8),
			new PresetItemSubTypeWithGradeRange(1100, 0, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(31, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 0, 8),
			new PresetItemSubTypeWithGradeRange(1, 0, 8),
			new PresetItemSubTypeWithGradeRange(2, 0, 8),
			new PresetItemSubTypeWithGradeRange(3, 0, 8),
			new PresetItemSubTypeWithGradeRange(4, 0, 8),
			new PresetItemSubTypeWithGradeRange(5, 0, 8),
			new PresetItemSubTypeWithGradeRange(6, 0, 8),
			new PresetItemSubTypeWithGradeRange(7, 0, 8),
			new PresetItemSubTypeWithGradeRange(8, 0, 8),
			new PresetItemSubTypeWithGradeRange(9, 0, 8),
			new PresetItemSubTypeWithGradeRange(10, 0, 8),
			new PresetItemSubTypeWithGradeRange(11, 0, 8),
			new PresetItemSubTypeWithGradeRange(12, 2, 8),
			new PresetItemSubTypeWithGradeRange(13, 2, 8),
			new PresetItemSubTypeWithGradeRange(14, 2, 8),
			new PresetItemSubTypeWithGradeRange(15, 2, 8),
			new PresetItemSubTypeWithGradeRange(100, 0, 8),
			new PresetItemSubTypeWithGradeRange(101, 0, 8),
			new PresetItemSubTypeWithGradeRange(102, 0, 8),
			new PresetItemSubTypeWithGradeRange(103, 0, 8),
			new PresetItemSubTypeWithGradeRange(200, 0, 8),
			new PresetItemSubTypeWithGradeRange(400, 0, 8),
			new PresetItemSubTypeWithGradeRange(600, 0, 8),
			new PresetItemSubTypeWithGradeRange(300, 1, 8),
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(701, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 1, 8),
			new PresetItemSubTypeWithGradeRange(501, 1, 8),
			new PresetItemSubTypeWithGradeRange(502, 1, 8),
			new PresetItemSubTypeWithGradeRange(503, 1, 8),
			new PresetItemSubTypeWithGradeRange(504, 1, 8),
			new PresetItemSubTypeWithGradeRange(505, 2, 8),
			new PresetItemSubTypeWithGradeRange(506, 2, 8),
			new PresetItemSubTypeWithGradeRange(1000, 1, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 1, 8),
			new PresetItemSubTypeWithGradeRange(801, 1, 8),
			new PresetItemSubTypeWithGradeRange(1205, 1, 8),
			new PresetItemSubTypeWithGradeRange(1206, 1, 8),
			new PresetItemSubTypeWithGradeRange(1100, 1, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(32, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 1, 8),
			new PresetItemSubTypeWithGradeRange(1, 1, 8),
			new PresetItemSubTypeWithGradeRange(2, 1, 8),
			new PresetItemSubTypeWithGradeRange(3, 1, 8),
			new PresetItemSubTypeWithGradeRange(4, 1, 8),
			new PresetItemSubTypeWithGradeRange(5, 1, 8),
			new PresetItemSubTypeWithGradeRange(6, 1, 8),
			new PresetItemSubTypeWithGradeRange(7, 1, 8),
			new PresetItemSubTypeWithGradeRange(8, 1, 8),
			new PresetItemSubTypeWithGradeRange(9, 1, 8),
			new PresetItemSubTypeWithGradeRange(10, 1, 8),
			new PresetItemSubTypeWithGradeRange(11, 1, 8),
			new PresetItemSubTypeWithGradeRange(12, 3, 8),
			new PresetItemSubTypeWithGradeRange(13, 3, 8),
			new PresetItemSubTypeWithGradeRange(14, 3, 8),
			new PresetItemSubTypeWithGradeRange(15, 3, 8),
			new PresetItemSubTypeWithGradeRange(100, 1, 8),
			new PresetItemSubTypeWithGradeRange(101, 1, 8),
			new PresetItemSubTypeWithGradeRange(102, 1, 8),
			new PresetItemSubTypeWithGradeRange(103, 1, 8),
			new PresetItemSubTypeWithGradeRange(200, 1, 8),
			new PresetItemSubTypeWithGradeRange(400, 1, 8),
			new PresetItemSubTypeWithGradeRange(600, 1, 8),
			new PresetItemSubTypeWithGradeRange(300, 2, 8),
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(701, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 2, 8),
			new PresetItemSubTypeWithGradeRange(501, 2, 8),
			new PresetItemSubTypeWithGradeRange(502, 2, 8),
			new PresetItemSubTypeWithGradeRange(503, 2, 8),
			new PresetItemSubTypeWithGradeRange(504, 2, 8),
			new PresetItemSubTypeWithGradeRange(505, 3, 8),
			new PresetItemSubTypeWithGradeRange(506, 3, 8),
			new PresetItemSubTypeWithGradeRange(1000, 2, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 2, 8),
			new PresetItemSubTypeWithGradeRange(801, 2, 8),
			new PresetItemSubTypeWithGradeRange(1205, 2, 8),
			new PresetItemSubTypeWithGradeRange(1206, 2, 8),
			new PresetItemSubTypeWithGradeRange(1100, 2, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(33, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 2, 8),
			new PresetItemSubTypeWithGradeRange(1, 2, 8),
			new PresetItemSubTypeWithGradeRange(2, 2, 8),
			new PresetItemSubTypeWithGradeRange(3, 2, 8),
			new PresetItemSubTypeWithGradeRange(4, 2, 8),
			new PresetItemSubTypeWithGradeRange(5, 2, 8),
			new PresetItemSubTypeWithGradeRange(6, 2, 8),
			new PresetItemSubTypeWithGradeRange(7, 2, 8),
			new PresetItemSubTypeWithGradeRange(8, 2, 8),
			new PresetItemSubTypeWithGradeRange(9, 2, 8),
			new PresetItemSubTypeWithGradeRange(10, 2, 8),
			new PresetItemSubTypeWithGradeRange(11, 2, 8),
			new PresetItemSubTypeWithGradeRange(12, 4, 8),
			new PresetItemSubTypeWithGradeRange(13, 4, 8),
			new PresetItemSubTypeWithGradeRange(14, 4, 8),
			new PresetItemSubTypeWithGradeRange(15, 4, 8),
			new PresetItemSubTypeWithGradeRange(100, 2, 8),
			new PresetItemSubTypeWithGradeRange(101, 2, 8),
			new PresetItemSubTypeWithGradeRange(102, 2, 8),
			new PresetItemSubTypeWithGradeRange(103, 2, 8),
			new PresetItemSubTypeWithGradeRange(200, 2, 8),
			new PresetItemSubTypeWithGradeRange(400, 2, 8),
			new PresetItemSubTypeWithGradeRange(600, 2, 8),
			new PresetItemSubTypeWithGradeRange(300, 3, 8),
			new PresetItemSubTypeWithGradeRange(700, 1, 8),
			new PresetItemSubTypeWithGradeRange(701, 1, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 3, 8),
			new PresetItemSubTypeWithGradeRange(501, 3, 8),
			new PresetItemSubTypeWithGradeRange(502, 3, 8),
			new PresetItemSubTypeWithGradeRange(503, 3, 8),
			new PresetItemSubTypeWithGradeRange(504, 3, 8),
			new PresetItemSubTypeWithGradeRange(505, 4, 8),
			new PresetItemSubTypeWithGradeRange(506, 4, 8),
			new PresetItemSubTypeWithGradeRange(1000, 3, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 3, 8),
			new PresetItemSubTypeWithGradeRange(801, 3, 8),
			new PresetItemSubTypeWithGradeRange(1205, 3, 8),
			new PresetItemSubTypeWithGradeRange(1206, 3, 8),
			new PresetItemSubTypeWithGradeRange(1100, 3, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(34, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 3, 8),
			new PresetItemSubTypeWithGradeRange(1, 3, 8),
			new PresetItemSubTypeWithGradeRange(2, 3, 8),
			new PresetItemSubTypeWithGradeRange(3, 3, 8),
			new PresetItemSubTypeWithGradeRange(4, 3, 8),
			new PresetItemSubTypeWithGradeRange(5, 3, 8),
			new PresetItemSubTypeWithGradeRange(6, 3, 8),
			new PresetItemSubTypeWithGradeRange(7, 3, 8),
			new PresetItemSubTypeWithGradeRange(8, 3, 8),
			new PresetItemSubTypeWithGradeRange(9, 3, 8),
			new PresetItemSubTypeWithGradeRange(10, 3, 8),
			new PresetItemSubTypeWithGradeRange(11, 3, 8),
			new PresetItemSubTypeWithGradeRange(12, 5, 8),
			new PresetItemSubTypeWithGradeRange(13, 5, 8),
			new PresetItemSubTypeWithGradeRange(14, 5, 8),
			new PresetItemSubTypeWithGradeRange(15, 5, 8),
			new PresetItemSubTypeWithGradeRange(100, 3, 8),
			new PresetItemSubTypeWithGradeRange(101, 3, 8),
			new PresetItemSubTypeWithGradeRange(102, 3, 8),
			new PresetItemSubTypeWithGradeRange(103, 3, 8),
			new PresetItemSubTypeWithGradeRange(200, 3, 8),
			new PresetItemSubTypeWithGradeRange(400, 3, 8),
			new PresetItemSubTypeWithGradeRange(600, 3, 8),
			new PresetItemSubTypeWithGradeRange(300, 4, 8),
			new PresetItemSubTypeWithGradeRange(700, 2, 8),
			new PresetItemSubTypeWithGradeRange(701, 2, 8),
			new PresetItemSubTypeWithGradeRange(900, 1, 8),
			new PresetItemSubTypeWithGradeRange(500, 4, 8),
			new PresetItemSubTypeWithGradeRange(501, 4, 8),
			new PresetItemSubTypeWithGradeRange(502, 4, 8),
			new PresetItemSubTypeWithGradeRange(503, 4, 8),
			new PresetItemSubTypeWithGradeRange(504, 4, 8),
			new PresetItemSubTypeWithGradeRange(505, 5, 8),
			new PresetItemSubTypeWithGradeRange(506, 5, 8),
			new PresetItemSubTypeWithGradeRange(1000, 4, 8),
			new PresetItemSubTypeWithGradeRange(1001, 1, 8),
			new PresetItemSubTypeWithGradeRange(1201, 1, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 4, 8),
			new PresetItemSubTypeWithGradeRange(801, 4, 8),
			new PresetItemSubTypeWithGradeRange(1205, 4, 8),
			new PresetItemSubTypeWithGradeRange(1206, 4, 8),
			new PresetItemSubTypeWithGradeRange(1100, 4, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(35, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 4, 8),
			new PresetItemSubTypeWithGradeRange(1, 4, 8),
			new PresetItemSubTypeWithGradeRange(2, 4, 8),
			new PresetItemSubTypeWithGradeRange(3, 4, 8),
			new PresetItemSubTypeWithGradeRange(4, 4, 8),
			new PresetItemSubTypeWithGradeRange(5, 4, 8),
			new PresetItemSubTypeWithGradeRange(6, 4, 8),
			new PresetItemSubTypeWithGradeRange(7, 4, 8),
			new PresetItemSubTypeWithGradeRange(8, 4, 8),
			new PresetItemSubTypeWithGradeRange(9, 4, 8),
			new PresetItemSubTypeWithGradeRange(10, 4, 8),
			new PresetItemSubTypeWithGradeRange(11, 4, 8),
			new PresetItemSubTypeWithGradeRange(12, 6, 8),
			new PresetItemSubTypeWithGradeRange(13, 6, 8),
			new PresetItemSubTypeWithGradeRange(14, 6, 8),
			new PresetItemSubTypeWithGradeRange(15, 6, 8),
			new PresetItemSubTypeWithGradeRange(100, 4, 8),
			new PresetItemSubTypeWithGradeRange(101, 4, 8),
			new PresetItemSubTypeWithGradeRange(102, 4, 8),
			new PresetItemSubTypeWithGradeRange(103, 4, 8),
			new PresetItemSubTypeWithGradeRange(200, 4, 8),
			new PresetItemSubTypeWithGradeRange(400, 4, 8),
			new PresetItemSubTypeWithGradeRange(600, 4, 8),
			new PresetItemSubTypeWithGradeRange(300, 5, 8),
			new PresetItemSubTypeWithGradeRange(700, 3, 8),
			new PresetItemSubTypeWithGradeRange(701, 3, 8),
			new PresetItemSubTypeWithGradeRange(900, 2, 8),
			new PresetItemSubTypeWithGradeRange(500, 5, 8),
			new PresetItemSubTypeWithGradeRange(501, 5, 8),
			new PresetItemSubTypeWithGradeRange(502, 5, 8),
			new PresetItemSubTypeWithGradeRange(503, 5, 8),
			new PresetItemSubTypeWithGradeRange(504, 5, 8),
			new PresetItemSubTypeWithGradeRange(505, 6, 8),
			new PresetItemSubTypeWithGradeRange(506, 6, 8),
			new PresetItemSubTypeWithGradeRange(1000, 5, 8),
			new PresetItemSubTypeWithGradeRange(1001, 2, 8),
			new PresetItemSubTypeWithGradeRange(1201, 2, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 5, 8),
			new PresetItemSubTypeWithGradeRange(801, 5, 8),
			new PresetItemSubTypeWithGradeRange(1205, 5, 8),
			new PresetItemSubTypeWithGradeRange(1206, 5, 8),
			new PresetItemSubTypeWithGradeRange(1100, 5, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(36, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 5, 8),
			new PresetItemSubTypeWithGradeRange(1, 5, 8),
			new PresetItemSubTypeWithGradeRange(2, 5, 8),
			new PresetItemSubTypeWithGradeRange(3, 5, 8),
			new PresetItemSubTypeWithGradeRange(4, 5, 8),
			new PresetItemSubTypeWithGradeRange(5, 5, 8),
			new PresetItemSubTypeWithGradeRange(6, 5, 8),
			new PresetItemSubTypeWithGradeRange(7, 5, 8),
			new PresetItemSubTypeWithGradeRange(8, 5, 8),
			new PresetItemSubTypeWithGradeRange(9, 5, 8),
			new PresetItemSubTypeWithGradeRange(10, 5, 8),
			new PresetItemSubTypeWithGradeRange(11, 5, 8),
			new PresetItemSubTypeWithGradeRange(12, 7, 8),
			new PresetItemSubTypeWithGradeRange(13, 7, 8),
			new PresetItemSubTypeWithGradeRange(14, 7, 8),
			new PresetItemSubTypeWithGradeRange(15, 7, 8),
			new PresetItemSubTypeWithGradeRange(100, 5, 8),
			new PresetItemSubTypeWithGradeRange(101, 5, 8),
			new PresetItemSubTypeWithGradeRange(102, 5, 8),
			new PresetItemSubTypeWithGradeRange(103, 5, 8),
			new PresetItemSubTypeWithGradeRange(200, 5, 8),
			new PresetItemSubTypeWithGradeRange(400, 5, 8),
			new PresetItemSubTypeWithGradeRange(600, 5, 8),
			new PresetItemSubTypeWithGradeRange(300, 6, 8),
			new PresetItemSubTypeWithGradeRange(700, 4, 8),
			new PresetItemSubTypeWithGradeRange(701, 4, 8),
			new PresetItemSubTypeWithGradeRange(900, 3, 8),
			new PresetItemSubTypeWithGradeRange(500, 6, 8),
			new PresetItemSubTypeWithGradeRange(501, 6, 8),
			new PresetItemSubTypeWithGradeRange(502, 6, 8),
			new PresetItemSubTypeWithGradeRange(503, 6, 8),
			new PresetItemSubTypeWithGradeRange(504, 6, 8),
			new PresetItemSubTypeWithGradeRange(505, 7, 8),
			new PresetItemSubTypeWithGradeRange(506, 7, 8),
			new PresetItemSubTypeWithGradeRange(1000, 6, 8),
			new PresetItemSubTypeWithGradeRange(1001, 3, 8),
			new PresetItemSubTypeWithGradeRange(1201, 3, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 6, 8),
			new PresetItemSubTypeWithGradeRange(801, 6, 8),
			new PresetItemSubTypeWithGradeRange(1205, 6, 8),
			new PresetItemSubTypeWithGradeRange(1206, 6, 8),
			new PresetItemSubTypeWithGradeRange(1100, 6, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(37, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 6, 8),
			new PresetItemSubTypeWithGradeRange(1, 6, 8),
			new PresetItemSubTypeWithGradeRange(2, 6, 8),
			new PresetItemSubTypeWithGradeRange(3, 6, 8),
			new PresetItemSubTypeWithGradeRange(4, 6, 8),
			new PresetItemSubTypeWithGradeRange(5, 6, 8),
			new PresetItemSubTypeWithGradeRange(6, 6, 8),
			new PresetItemSubTypeWithGradeRange(7, 6, 8),
			new PresetItemSubTypeWithGradeRange(8, 6, 8),
			new PresetItemSubTypeWithGradeRange(9, 6, 8),
			new PresetItemSubTypeWithGradeRange(10, 6, 8),
			new PresetItemSubTypeWithGradeRange(11, 6, 8),
			new PresetItemSubTypeWithGradeRange(12, 8, 8),
			new PresetItemSubTypeWithGradeRange(13, 8, 8),
			new PresetItemSubTypeWithGradeRange(14, 8, 8),
			new PresetItemSubTypeWithGradeRange(15, 8, 8),
			new PresetItemSubTypeWithGradeRange(100, 6, 8),
			new PresetItemSubTypeWithGradeRange(101, 6, 8),
			new PresetItemSubTypeWithGradeRange(102, 6, 8),
			new PresetItemSubTypeWithGradeRange(103, 6, 8),
			new PresetItemSubTypeWithGradeRange(200, 6, 8),
			new PresetItemSubTypeWithGradeRange(400, 6, 8),
			new PresetItemSubTypeWithGradeRange(600, 6, 8),
			new PresetItemSubTypeWithGradeRange(300, 7, 8),
			new PresetItemSubTypeWithGradeRange(700, 5, 8),
			new PresetItemSubTypeWithGradeRange(701, 5, 8),
			new PresetItemSubTypeWithGradeRange(900, 4, 8),
			new PresetItemSubTypeWithGradeRange(500, 7, 8),
			new PresetItemSubTypeWithGradeRange(501, 7, 8),
			new PresetItemSubTypeWithGradeRange(502, 7, 8),
			new PresetItemSubTypeWithGradeRange(503, 7, 8),
			new PresetItemSubTypeWithGradeRange(504, 7, 8),
			new PresetItemSubTypeWithGradeRange(505, 8, 8),
			new PresetItemSubTypeWithGradeRange(506, 8, 8),
			new PresetItemSubTypeWithGradeRange(1000, 7, 8),
			new PresetItemSubTypeWithGradeRange(1001, 4, 8),
			new PresetItemSubTypeWithGradeRange(1201, 4, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 7, 8),
			new PresetItemSubTypeWithGradeRange(801, 7, 8),
			new PresetItemSubTypeWithGradeRange(1205, 7, 8),
			new PresetItemSubTypeWithGradeRange(1206, 7, 8),
			new PresetItemSubTypeWithGradeRange(1100, 7, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(38, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 7, 8),
			new PresetItemSubTypeWithGradeRange(1, 7, 8),
			new PresetItemSubTypeWithGradeRange(2, 7, 8),
			new PresetItemSubTypeWithGradeRange(3, 7, 8),
			new PresetItemSubTypeWithGradeRange(4, 7, 8),
			new PresetItemSubTypeWithGradeRange(5, 7, 8),
			new PresetItemSubTypeWithGradeRange(6, 7, 8),
			new PresetItemSubTypeWithGradeRange(7, 7, 8),
			new PresetItemSubTypeWithGradeRange(8, 7, 8),
			new PresetItemSubTypeWithGradeRange(9, 7, 8),
			new PresetItemSubTypeWithGradeRange(10, 7, 8),
			new PresetItemSubTypeWithGradeRange(11, 7, 8),
			new PresetItemSubTypeWithGradeRange(100, 7, 8),
			new PresetItemSubTypeWithGradeRange(101, 7, 8),
			new PresetItemSubTypeWithGradeRange(102, 7, 8),
			new PresetItemSubTypeWithGradeRange(103, 7, 8),
			new PresetItemSubTypeWithGradeRange(200, 7, 8),
			new PresetItemSubTypeWithGradeRange(400, 7, 8),
			new PresetItemSubTypeWithGradeRange(600, 7, 8),
			new PresetItemSubTypeWithGradeRange(300, 8, 8),
			new PresetItemSubTypeWithGradeRange(700, 6, 8),
			new PresetItemSubTypeWithGradeRange(701, 6, 8),
			new PresetItemSubTypeWithGradeRange(900, 5, 8),
			new PresetItemSubTypeWithGradeRange(500, 8, 8),
			new PresetItemSubTypeWithGradeRange(501, 8, 8),
			new PresetItemSubTypeWithGradeRange(502, 8, 8),
			new PresetItemSubTypeWithGradeRange(503, 8, 8),
			new PresetItemSubTypeWithGradeRange(504, 8, 8),
			new PresetItemSubTypeWithGradeRange(1000, 8, 8),
			new PresetItemSubTypeWithGradeRange(1001, 5, 8),
			new PresetItemSubTypeWithGradeRange(1201, 5, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 8, 8),
			new PresetItemSubTypeWithGradeRange(801, 8, 8),
			new PresetItemSubTypeWithGradeRange(1205, 8, 8),
			new PresetItemSubTypeWithGradeRange(1206, 8, 8),
			new PresetItemSubTypeWithGradeRange(1100, 8, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(39, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 0, 8),
			new PresetItemSubTypeWithGradeRange(1, 0, 8),
			new PresetItemSubTypeWithGradeRange(2, 0, 8),
			new PresetItemSubTypeWithGradeRange(3, 0, 8),
			new PresetItemSubTypeWithGradeRange(4, 0, 8),
			new PresetItemSubTypeWithGradeRange(5, 0, 8),
			new PresetItemSubTypeWithGradeRange(6, 0, 8),
			new PresetItemSubTypeWithGradeRange(7, 0, 8),
			new PresetItemSubTypeWithGradeRange(8, 0, 8),
			new PresetItemSubTypeWithGradeRange(9, 0, 8),
			new PresetItemSubTypeWithGradeRange(10, 0, 8),
			new PresetItemSubTypeWithGradeRange(11, 0, 8),
			new PresetItemSubTypeWithGradeRange(12, 1, 8),
			new PresetItemSubTypeWithGradeRange(13, 1, 8),
			new PresetItemSubTypeWithGradeRange(14, 1, 8),
			new PresetItemSubTypeWithGradeRange(15, 1, 8),
			new PresetItemSubTypeWithGradeRange(100, 0, 8),
			new PresetItemSubTypeWithGradeRange(101, 0, 8),
			new PresetItemSubTypeWithGradeRange(102, 0, 8),
			new PresetItemSubTypeWithGradeRange(103, 0, 8),
			new PresetItemSubTypeWithGradeRange(200, 0, 8),
			new PresetItemSubTypeWithGradeRange(400, 0, 8),
			new PresetItemSubTypeWithGradeRange(600, 0, 8),
			new PresetItemSubTypeWithGradeRange(300, 0, 8),
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(901, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 0, 8),
			new PresetItemSubTypeWithGradeRange(501, 0, 8),
			new PresetItemSubTypeWithGradeRange(502, 0, 8),
			new PresetItemSubTypeWithGradeRange(503, 0, 8),
			new PresetItemSubTypeWithGradeRange(504, 0, 8),
			new PresetItemSubTypeWithGradeRange(505, 1, 8),
			new PresetItemSubTypeWithGradeRange(506, 1, 8),
			new PresetItemSubTypeWithGradeRange(1000, 0, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 0, 8),
			new PresetItemSubTypeWithGradeRange(801, 0, 8),
			new PresetItemSubTypeWithGradeRange(1205, 0, 8),
			new PresetItemSubTypeWithGradeRange(1206, 0, 8),
			new PresetItemSubTypeWithGradeRange(1100, 0, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(40, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 0, 8),
			new PresetItemSubTypeWithGradeRange(1, 0, 8),
			new PresetItemSubTypeWithGradeRange(2, 0, 8),
			new PresetItemSubTypeWithGradeRange(3, 0, 8),
			new PresetItemSubTypeWithGradeRange(4, 0, 8),
			new PresetItemSubTypeWithGradeRange(5, 0, 8),
			new PresetItemSubTypeWithGradeRange(6, 0, 8),
			new PresetItemSubTypeWithGradeRange(7, 0, 8),
			new PresetItemSubTypeWithGradeRange(8, 0, 8),
			new PresetItemSubTypeWithGradeRange(9, 0, 8),
			new PresetItemSubTypeWithGradeRange(10, 0, 8),
			new PresetItemSubTypeWithGradeRange(11, 0, 8),
			new PresetItemSubTypeWithGradeRange(12, 2, 8),
			new PresetItemSubTypeWithGradeRange(13, 2, 8),
			new PresetItemSubTypeWithGradeRange(14, 2, 8),
			new PresetItemSubTypeWithGradeRange(15, 2, 8),
			new PresetItemSubTypeWithGradeRange(100, 0, 8),
			new PresetItemSubTypeWithGradeRange(101, 0, 8),
			new PresetItemSubTypeWithGradeRange(102, 0, 8),
			new PresetItemSubTypeWithGradeRange(103, 0, 8),
			new PresetItemSubTypeWithGradeRange(200, 0, 8),
			new PresetItemSubTypeWithGradeRange(400, 0, 8),
			new PresetItemSubTypeWithGradeRange(600, 0, 8),
			new PresetItemSubTypeWithGradeRange(300, 1, 8),
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(901, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 1, 8),
			new PresetItemSubTypeWithGradeRange(501, 1, 8),
			new PresetItemSubTypeWithGradeRange(502, 1, 8),
			new PresetItemSubTypeWithGradeRange(503, 1, 8),
			new PresetItemSubTypeWithGradeRange(504, 1, 8),
			new PresetItemSubTypeWithGradeRange(505, 2, 8),
			new PresetItemSubTypeWithGradeRange(506, 2, 8),
			new PresetItemSubTypeWithGradeRange(1000, 1, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 1, 8),
			new PresetItemSubTypeWithGradeRange(801, 1, 8),
			new PresetItemSubTypeWithGradeRange(1205, 1, 8),
			new PresetItemSubTypeWithGradeRange(1206, 1, 8),
			new PresetItemSubTypeWithGradeRange(1100, 1, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(41, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 1, 8),
			new PresetItemSubTypeWithGradeRange(1, 1, 8),
			new PresetItemSubTypeWithGradeRange(2, 1, 8),
			new PresetItemSubTypeWithGradeRange(3, 1, 8),
			new PresetItemSubTypeWithGradeRange(4, 1, 8),
			new PresetItemSubTypeWithGradeRange(5, 1, 8),
			new PresetItemSubTypeWithGradeRange(6, 1, 8),
			new PresetItemSubTypeWithGradeRange(7, 1, 8),
			new PresetItemSubTypeWithGradeRange(8, 1, 8),
			new PresetItemSubTypeWithGradeRange(9, 1, 8),
			new PresetItemSubTypeWithGradeRange(10, 1, 8),
			new PresetItemSubTypeWithGradeRange(11, 1, 8),
			new PresetItemSubTypeWithGradeRange(12, 3, 8),
			new PresetItemSubTypeWithGradeRange(13, 3, 8),
			new PresetItemSubTypeWithGradeRange(14, 3, 8),
			new PresetItemSubTypeWithGradeRange(15, 3, 8),
			new PresetItemSubTypeWithGradeRange(100, 1, 8),
			new PresetItemSubTypeWithGradeRange(101, 1, 8),
			new PresetItemSubTypeWithGradeRange(102, 1, 8),
			new PresetItemSubTypeWithGradeRange(103, 1, 8),
			new PresetItemSubTypeWithGradeRange(200, 1, 8),
			new PresetItemSubTypeWithGradeRange(400, 1, 8),
			new PresetItemSubTypeWithGradeRange(600, 1, 8),
			new PresetItemSubTypeWithGradeRange(300, 2, 8),
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(901, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 2, 8),
			new PresetItemSubTypeWithGradeRange(501, 2, 8),
			new PresetItemSubTypeWithGradeRange(502, 2, 8),
			new PresetItemSubTypeWithGradeRange(503, 2, 8),
			new PresetItemSubTypeWithGradeRange(504, 2, 8),
			new PresetItemSubTypeWithGradeRange(505, 3, 8),
			new PresetItemSubTypeWithGradeRange(506, 3, 8),
			new PresetItemSubTypeWithGradeRange(1000, 2, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 2, 8),
			new PresetItemSubTypeWithGradeRange(801, 2, 8),
			new PresetItemSubTypeWithGradeRange(1205, 2, 8),
			new PresetItemSubTypeWithGradeRange(1206, 2, 8),
			new PresetItemSubTypeWithGradeRange(1100, 2, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(42, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 2, 8),
			new PresetItemSubTypeWithGradeRange(1, 2, 8),
			new PresetItemSubTypeWithGradeRange(2, 2, 8),
			new PresetItemSubTypeWithGradeRange(3, 2, 8),
			new PresetItemSubTypeWithGradeRange(4, 2, 8),
			new PresetItemSubTypeWithGradeRange(5, 2, 8),
			new PresetItemSubTypeWithGradeRange(6, 2, 8),
			new PresetItemSubTypeWithGradeRange(7, 2, 8),
			new PresetItemSubTypeWithGradeRange(8, 2, 8),
			new PresetItemSubTypeWithGradeRange(9, 2, 8),
			new PresetItemSubTypeWithGradeRange(10, 2, 8),
			new PresetItemSubTypeWithGradeRange(11, 2, 8),
			new PresetItemSubTypeWithGradeRange(12, 4, 8),
			new PresetItemSubTypeWithGradeRange(13, 4, 8),
			new PresetItemSubTypeWithGradeRange(14, 4, 8),
			new PresetItemSubTypeWithGradeRange(15, 4, 8),
			new PresetItemSubTypeWithGradeRange(100, 2, 8),
			new PresetItemSubTypeWithGradeRange(101, 2, 8),
			new PresetItemSubTypeWithGradeRange(102, 2, 8),
			new PresetItemSubTypeWithGradeRange(103, 2, 8),
			new PresetItemSubTypeWithGradeRange(200, 2, 8),
			new PresetItemSubTypeWithGradeRange(400, 2, 8),
			new PresetItemSubTypeWithGradeRange(600, 2, 8),
			new PresetItemSubTypeWithGradeRange(300, 3, 8),
			new PresetItemSubTypeWithGradeRange(700, 1, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(901, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 3, 8),
			new PresetItemSubTypeWithGradeRange(501, 3, 8),
			new PresetItemSubTypeWithGradeRange(502, 3, 8),
			new PresetItemSubTypeWithGradeRange(503, 3, 8),
			new PresetItemSubTypeWithGradeRange(504, 3, 8),
			new PresetItemSubTypeWithGradeRange(505, 4, 8),
			new PresetItemSubTypeWithGradeRange(506, 4, 8),
			new PresetItemSubTypeWithGradeRange(1000, 3, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 3, 8),
			new PresetItemSubTypeWithGradeRange(801, 3, 8),
			new PresetItemSubTypeWithGradeRange(1205, 3, 8),
			new PresetItemSubTypeWithGradeRange(1206, 3, 8),
			new PresetItemSubTypeWithGradeRange(1100, 3, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(43, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 3, 8),
			new PresetItemSubTypeWithGradeRange(1, 3, 8),
			new PresetItemSubTypeWithGradeRange(2, 3, 8),
			new PresetItemSubTypeWithGradeRange(3, 3, 8),
			new PresetItemSubTypeWithGradeRange(4, 3, 8),
			new PresetItemSubTypeWithGradeRange(5, 3, 8),
			new PresetItemSubTypeWithGradeRange(6, 3, 8),
			new PresetItemSubTypeWithGradeRange(7, 3, 8),
			new PresetItemSubTypeWithGradeRange(8, 3, 8),
			new PresetItemSubTypeWithGradeRange(9, 3, 8),
			new PresetItemSubTypeWithGradeRange(10, 3, 8),
			new PresetItemSubTypeWithGradeRange(11, 3, 8),
			new PresetItemSubTypeWithGradeRange(12, 5, 8),
			new PresetItemSubTypeWithGradeRange(13, 5, 8),
			new PresetItemSubTypeWithGradeRange(14, 5, 8),
			new PresetItemSubTypeWithGradeRange(15, 5, 8),
			new PresetItemSubTypeWithGradeRange(100, 3, 8),
			new PresetItemSubTypeWithGradeRange(101, 3, 8),
			new PresetItemSubTypeWithGradeRange(102, 3, 8),
			new PresetItemSubTypeWithGradeRange(103, 3, 8),
			new PresetItemSubTypeWithGradeRange(200, 3, 8),
			new PresetItemSubTypeWithGradeRange(400, 3, 8),
			new PresetItemSubTypeWithGradeRange(600, 3, 8),
			new PresetItemSubTypeWithGradeRange(300, 4, 8),
			new PresetItemSubTypeWithGradeRange(700, 2, 8),
			new PresetItemSubTypeWithGradeRange(900, 1, 8),
			new PresetItemSubTypeWithGradeRange(901, 1, 8),
			new PresetItemSubTypeWithGradeRange(500, 4, 8),
			new PresetItemSubTypeWithGradeRange(501, 4, 8),
			new PresetItemSubTypeWithGradeRange(502, 4, 8),
			new PresetItemSubTypeWithGradeRange(503, 4, 8),
			new PresetItemSubTypeWithGradeRange(504, 4, 8),
			new PresetItemSubTypeWithGradeRange(505, 5, 8),
			new PresetItemSubTypeWithGradeRange(506, 5, 8),
			new PresetItemSubTypeWithGradeRange(1000, 4, 8),
			new PresetItemSubTypeWithGradeRange(1001, 1, 8),
			new PresetItemSubTypeWithGradeRange(1201, 1, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 4, 8),
			new PresetItemSubTypeWithGradeRange(801, 4, 8),
			new PresetItemSubTypeWithGradeRange(1205, 4, 8),
			new PresetItemSubTypeWithGradeRange(1206, 4, 8),
			new PresetItemSubTypeWithGradeRange(1100, 4, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(44, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 4, 8),
			new PresetItemSubTypeWithGradeRange(1, 4, 8),
			new PresetItemSubTypeWithGradeRange(2, 4, 8),
			new PresetItemSubTypeWithGradeRange(3, 4, 8),
			new PresetItemSubTypeWithGradeRange(4, 4, 8),
			new PresetItemSubTypeWithGradeRange(5, 4, 8),
			new PresetItemSubTypeWithGradeRange(6, 4, 8),
			new PresetItemSubTypeWithGradeRange(7, 4, 8),
			new PresetItemSubTypeWithGradeRange(8, 4, 8),
			new PresetItemSubTypeWithGradeRange(9, 4, 8),
			new PresetItemSubTypeWithGradeRange(10, 4, 8),
			new PresetItemSubTypeWithGradeRange(11, 4, 8),
			new PresetItemSubTypeWithGradeRange(12, 6, 8),
			new PresetItemSubTypeWithGradeRange(13, 6, 8),
			new PresetItemSubTypeWithGradeRange(14, 6, 8),
			new PresetItemSubTypeWithGradeRange(15, 6, 8),
			new PresetItemSubTypeWithGradeRange(100, 4, 8),
			new PresetItemSubTypeWithGradeRange(101, 4, 8),
			new PresetItemSubTypeWithGradeRange(102, 4, 8),
			new PresetItemSubTypeWithGradeRange(103, 4, 8),
			new PresetItemSubTypeWithGradeRange(200, 4, 8),
			new PresetItemSubTypeWithGradeRange(400, 4, 8),
			new PresetItemSubTypeWithGradeRange(600, 4, 8),
			new PresetItemSubTypeWithGradeRange(300, 5, 8),
			new PresetItemSubTypeWithGradeRange(700, 3, 8),
			new PresetItemSubTypeWithGradeRange(900, 2, 8),
			new PresetItemSubTypeWithGradeRange(901, 2, 8),
			new PresetItemSubTypeWithGradeRange(500, 5, 8),
			new PresetItemSubTypeWithGradeRange(501, 5, 8),
			new PresetItemSubTypeWithGradeRange(502, 5, 8),
			new PresetItemSubTypeWithGradeRange(503, 5, 8),
			new PresetItemSubTypeWithGradeRange(504, 5, 8),
			new PresetItemSubTypeWithGradeRange(505, 6, 8),
			new PresetItemSubTypeWithGradeRange(506, 6, 8),
			new PresetItemSubTypeWithGradeRange(1000, 5, 8),
			new PresetItemSubTypeWithGradeRange(1001, 2, 8),
			new PresetItemSubTypeWithGradeRange(1201, 2, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 5, 8),
			new PresetItemSubTypeWithGradeRange(801, 5, 8),
			new PresetItemSubTypeWithGradeRange(1205, 5, 8),
			new PresetItemSubTypeWithGradeRange(1206, 5, 8),
			new PresetItemSubTypeWithGradeRange(1100, 5, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(45, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 5, 8),
			new PresetItemSubTypeWithGradeRange(1, 5, 8),
			new PresetItemSubTypeWithGradeRange(2, 5, 8),
			new PresetItemSubTypeWithGradeRange(3, 5, 8),
			new PresetItemSubTypeWithGradeRange(4, 5, 8),
			new PresetItemSubTypeWithGradeRange(5, 5, 8),
			new PresetItemSubTypeWithGradeRange(6, 5, 8),
			new PresetItemSubTypeWithGradeRange(7, 5, 8),
			new PresetItemSubTypeWithGradeRange(8, 5, 8),
			new PresetItemSubTypeWithGradeRange(9, 5, 8),
			new PresetItemSubTypeWithGradeRange(10, 5, 8),
			new PresetItemSubTypeWithGradeRange(11, 5, 8),
			new PresetItemSubTypeWithGradeRange(12, 7, 8),
			new PresetItemSubTypeWithGradeRange(13, 7, 8),
			new PresetItemSubTypeWithGradeRange(14, 7, 8),
			new PresetItemSubTypeWithGradeRange(15, 7, 8),
			new PresetItemSubTypeWithGradeRange(100, 5, 8),
			new PresetItemSubTypeWithGradeRange(101, 5, 8),
			new PresetItemSubTypeWithGradeRange(102, 5, 8),
			new PresetItemSubTypeWithGradeRange(103, 5, 8),
			new PresetItemSubTypeWithGradeRange(200, 5, 8),
			new PresetItemSubTypeWithGradeRange(400, 5, 8),
			new PresetItemSubTypeWithGradeRange(600, 5, 8),
			new PresetItemSubTypeWithGradeRange(300, 6, 8),
			new PresetItemSubTypeWithGradeRange(700, 4, 8),
			new PresetItemSubTypeWithGradeRange(900, 3, 8),
			new PresetItemSubTypeWithGradeRange(901, 3, 8),
			new PresetItemSubTypeWithGradeRange(500, 6, 8),
			new PresetItemSubTypeWithGradeRange(501, 6, 8),
			new PresetItemSubTypeWithGradeRange(502, 6, 8),
			new PresetItemSubTypeWithGradeRange(503, 6, 8),
			new PresetItemSubTypeWithGradeRange(504, 6, 8),
			new PresetItemSubTypeWithGradeRange(505, 7, 8),
			new PresetItemSubTypeWithGradeRange(506, 7, 8),
			new PresetItemSubTypeWithGradeRange(1000, 6, 8),
			new PresetItemSubTypeWithGradeRange(1001, 3, 8),
			new PresetItemSubTypeWithGradeRange(1201, 3, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 6, 8),
			new PresetItemSubTypeWithGradeRange(801, 6, 8),
			new PresetItemSubTypeWithGradeRange(1205, 6, 8),
			new PresetItemSubTypeWithGradeRange(1206, 6, 8),
			new PresetItemSubTypeWithGradeRange(1100, 6, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(46, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 6, 8),
			new PresetItemSubTypeWithGradeRange(1, 6, 8),
			new PresetItemSubTypeWithGradeRange(2, 6, 8),
			new PresetItemSubTypeWithGradeRange(3, 6, 8),
			new PresetItemSubTypeWithGradeRange(4, 6, 8),
			new PresetItemSubTypeWithGradeRange(5, 6, 8),
			new PresetItemSubTypeWithGradeRange(6, 6, 8),
			new PresetItemSubTypeWithGradeRange(7, 6, 8),
			new PresetItemSubTypeWithGradeRange(8, 6, 8),
			new PresetItemSubTypeWithGradeRange(9, 6, 8),
			new PresetItemSubTypeWithGradeRange(10, 6, 8),
			new PresetItemSubTypeWithGradeRange(11, 6, 8),
			new PresetItemSubTypeWithGradeRange(12, 8, 8),
			new PresetItemSubTypeWithGradeRange(13, 8, 8),
			new PresetItemSubTypeWithGradeRange(14, 8, 8),
			new PresetItemSubTypeWithGradeRange(15, 8, 8),
			new PresetItemSubTypeWithGradeRange(100, 6, 8),
			new PresetItemSubTypeWithGradeRange(101, 6, 8),
			new PresetItemSubTypeWithGradeRange(102, 6, 8),
			new PresetItemSubTypeWithGradeRange(103, 6, 8),
			new PresetItemSubTypeWithGradeRange(200, 6, 8),
			new PresetItemSubTypeWithGradeRange(400, 6, 8),
			new PresetItemSubTypeWithGradeRange(600, 6, 8),
			new PresetItemSubTypeWithGradeRange(300, 7, 8),
			new PresetItemSubTypeWithGradeRange(700, 5, 8),
			new PresetItemSubTypeWithGradeRange(900, 4, 8),
			new PresetItemSubTypeWithGradeRange(901, 4, 8),
			new PresetItemSubTypeWithGradeRange(500, 7, 8),
			new PresetItemSubTypeWithGradeRange(501, 7, 8),
			new PresetItemSubTypeWithGradeRange(502, 7, 8),
			new PresetItemSubTypeWithGradeRange(503, 7, 8),
			new PresetItemSubTypeWithGradeRange(504, 7, 8),
			new PresetItemSubTypeWithGradeRange(505, 8, 8),
			new PresetItemSubTypeWithGradeRange(506, 8, 8),
			new PresetItemSubTypeWithGradeRange(1000, 7, 8),
			new PresetItemSubTypeWithGradeRange(1001, 4, 8),
			new PresetItemSubTypeWithGradeRange(1201, 4, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 7, 8),
			new PresetItemSubTypeWithGradeRange(801, 7, 8),
			new PresetItemSubTypeWithGradeRange(1205, 7, 8),
			new PresetItemSubTypeWithGradeRange(1206, 7, 8),
			new PresetItemSubTypeWithGradeRange(1100, 7, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(47, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 7, 8),
			new PresetItemSubTypeWithGradeRange(1, 7, 8),
			new PresetItemSubTypeWithGradeRange(2, 7, 8),
			new PresetItemSubTypeWithGradeRange(3, 7, 8),
			new PresetItemSubTypeWithGradeRange(4, 7, 8),
			new PresetItemSubTypeWithGradeRange(5, 7, 8),
			new PresetItemSubTypeWithGradeRange(6, 7, 8),
			new PresetItemSubTypeWithGradeRange(7, 7, 8),
			new PresetItemSubTypeWithGradeRange(8, 7, 8),
			new PresetItemSubTypeWithGradeRange(9, 7, 8),
			new PresetItemSubTypeWithGradeRange(10, 7, 8),
			new PresetItemSubTypeWithGradeRange(11, 7, 8),
			new PresetItemSubTypeWithGradeRange(100, 7, 8),
			new PresetItemSubTypeWithGradeRange(101, 7, 8),
			new PresetItemSubTypeWithGradeRange(102, 7, 8),
			new PresetItemSubTypeWithGradeRange(103, 7, 8),
			new PresetItemSubTypeWithGradeRange(200, 7, 8),
			new PresetItemSubTypeWithGradeRange(400, 7, 8),
			new PresetItemSubTypeWithGradeRange(600, 7, 8),
			new PresetItemSubTypeWithGradeRange(300, 8, 8),
			new PresetItemSubTypeWithGradeRange(700, 6, 8),
			new PresetItemSubTypeWithGradeRange(900, 5, 8),
			new PresetItemSubTypeWithGradeRange(901, 5, 8),
			new PresetItemSubTypeWithGradeRange(500, 8, 8),
			new PresetItemSubTypeWithGradeRange(501, 8, 8),
			new PresetItemSubTypeWithGradeRange(502, 8, 8),
			new PresetItemSubTypeWithGradeRange(503, 8, 8),
			new PresetItemSubTypeWithGradeRange(504, 8, 8),
			new PresetItemSubTypeWithGradeRange(1000, 8, 8),
			new PresetItemSubTypeWithGradeRange(1001, 5, 8),
			new PresetItemSubTypeWithGradeRange(1201, 5, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 8, 8),
			new PresetItemSubTypeWithGradeRange(801, 8, 8),
			new PresetItemSubTypeWithGradeRange(1205, 8, 8),
			new PresetItemSubTypeWithGradeRange(1206, 8, 8),
			new PresetItemSubTypeWithGradeRange(1100, 8, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(48, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 0, 8),
			new PresetItemSubTypeWithGradeRange(1, 0, 8),
			new PresetItemSubTypeWithGradeRange(2, 0, 8),
			new PresetItemSubTypeWithGradeRange(3, 0, 8),
			new PresetItemSubTypeWithGradeRange(4, 0, 8),
			new PresetItemSubTypeWithGradeRange(5, 0, 8),
			new PresetItemSubTypeWithGradeRange(6, 0, 8),
			new PresetItemSubTypeWithGradeRange(7, 0, 8),
			new PresetItemSubTypeWithGradeRange(8, 0, 8),
			new PresetItemSubTypeWithGradeRange(9, 0, 8),
			new PresetItemSubTypeWithGradeRange(10, 0, 8),
			new PresetItemSubTypeWithGradeRange(11, 0, 8),
			new PresetItemSubTypeWithGradeRange(12, 1, 8),
			new PresetItemSubTypeWithGradeRange(13, 1, 8),
			new PresetItemSubTypeWithGradeRange(14, 1, 8),
			new PresetItemSubTypeWithGradeRange(15, 1, 8),
			new PresetItemSubTypeWithGradeRange(100, 0, 8),
			new PresetItemSubTypeWithGradeRange(101, 0, 8),
			new PresetItemSubTypeWithGradeRange(102, 0, 8),
			new PresetItemSubTypeWithGradeRange(103, 0, 8),
			new PresetItemSubTypeWithGradeRange(200, 0, 8),
			new PresetItemSubTypeWithGradeRange(400, 0, 8),
			new PresetItemSubTypeWithGradeRange(600, 0, 8),
			new PresetItemSubTypeWithGradeRange(300, 0, 8),
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 0, 8),
			new PresetItemSubTypeWithGradeRange(501, 0, 8),
			new PresetItemSubTypeWithGradeRange(502, 0, 8),
			new PresetItemSubTypeWithGradeRange(503, 0, 8),
			new PresetItemSubTypeWithGradeRange(504, 0, 8),
			new PresetItemSubTypeWithGradeRange(505, 1, 8),
			new PresetItemSubTypeWithGradeRange(506, 1, 8),
			new PresetItemSubTypeWithGradeRange(1000, 0, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 0, 8),
			new PresetItemSubTypeWithGradeRange(801, 0, 8),
			new PresetItemSubTypeWithGradeRange(1205, 0, 8),
			new PresetItemSubTypeWithGradeRange(1206, 0, 8),
			new PresetItemSubTypeWithGradeRange(1100, 0, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(49, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 0, 8),
			new PresetItemSubTypeWithGradeRange(1, 0, 8),
			new PresetItemSubTypeWithGradeRange(2, 0, 8),
			new PresetItemSubTypeWithGradeRange(3, 0, 8),
			new PresetItemSubTypeWithGradeRange(4, 0, 8),
			new PresetItemSubTypeWithGradeRange(5, 0, 8),
			new PresetItemSubTypeWithGradeRange(6, 0, 8),
			new PresetItemSubTypeWithGradeRange(7, 0, 8),
			new PresetItemSubTypeWithGradeRange(8, 0, 8),
			new PresetItemSubTypeWithGradeRange(9, 0, 8),
			new PresetItemSubTypeWithGradeRange(10, 0, 8),
			new PresetItemSubTypeWithGradeRange(11, 0, 8),
			new PresetItemSubTypeWithGradeRange(12, 2, 8),
			new PresetItemSubTypeWithGradeRange(13, 2, 8),
			new PresetItemSubTypeWithGradeRange(14, 2, 8),
			new PresetItemSubTypeWithGradeRange(15, 2, 8),
			new PresetItemSubTypeWithGradeRange(100, 0, 8),
			new PresetItemSubTypeWithGradeRange(101, 0, 8),
			new PresetItemSubTypeWithGradeRange(102, 0, 8),
			new PresetItemSubTypeWithGradeRange(103, 0, 8),
			new PresetItemSubTypeWithGradeRange(200, 0, 8),
			new PresetItemSubTypeWithGradeRange(400, 0, 8),
			new PresetItemSubTypeWithGradeRange(600, 0, 8),
			new PresetItemSubTypeWithGradeRange(300, 1, 8),
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 1, 8),
			new PresetItemSubTypeWithGradeRange(501, 1, 8),
			new PresetItemSubTypeWithGradeRange(502, 1, 8),
			new PresetItemSubTypeWithGradeRange(503, 1, 8),
			new PresetItemSubTypeWithGradeRange(504, 1, 8),
			new PresetItemSubTypeWithGradeRange(505, 2, 8),
			new PresetItemSubTypeWithGradeRange(506, 2, 8),
			new PresetItemSubTypeWithGradeRange(1000, 1, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 1, 8),
			new PresetItemSubTypeWithGradeRange(801, 1, 8),
			new PresetItemSubTypeWithGradeRange(1205, 1, 8),
			new PresetItemSubTypeWithGradeRange(1206, 1, 8),
			new PresetItemSubTypeWithGradeRange(1100, 1, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(50, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 1, 8),
			new PresetItemSubTypeWithGradeRange(1, 1, 8),
			new PresetItemSubTypeWithGradeRange(2, 1, 8),
			new PresetItemSubTypeWithGradeRange(3, 1, 8),
			new PresetItemSubTypeWithGradeRange(4, 1, 8),
			new PresetItemSubTypeWithGradeRange(5, 1, 8),
			new PresetItemSubTypeWithGradeRange(6, 1, 8),
			new PresetItemSubTypeWithGradeRange(7, 1, 8),
			new PresetItemSubTypeWithGradeRange(8, 1, 8),
			new PresetItemSubTypeWithGradeRange(9, 1, 8),
			new PresetItemSubTypeWithGradeRange(10, 1, 8),
			new PresetItemSubTypeWithGradeRange(11, 1, 8),
			new PresetItemSubTypeWithGradeRange(12, 3, 8),
			new PresetItemSubTypeWithGradeRange(13, 3, 8),
			new PresetItemSubTypeWithGradeRange(14, 3, 8),
			new PresetItemSubTypeWithGradeRange(15, 3, 8),
			new PresetItemSubTypeWithGradeRange(100, 1, 8),
			new PresetItemSubTypeWithGradeRange(101, 1, 8),
			new PresetItemSubTypeWithGradeRange(102, 1, 8),
			new PresetItemSubTypeWithGradeRange(103, 1, 8),
			new PresetItemSubTypeWithGradeRange(200, 1, 8),
			new PresetItemSubTypeWithGradeRange(400, 1, 8),
			new PresetItemSubTypeWithGradeRange(600, 1, 8),
			new PresetItemSubTypeWithGradeRange(300, 2, 8),
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 2, 8),
			new PresetItemSubTypeWithGradeRange(501, 2, 8),
			new PresetItemSubTypeWithGradeRange(502, 2, 8),
			new PresetItemSubTypeWithGradeRange(503, 2, 8),
			new PresetItemSubTypeWithGradeRange(504, 2, 8),
			new PresetItemSubTypeWithGradeRange(505, 3, 8),
			new PresetItemSubTypeWithGradeRange(506, 3, 8),
			new PresetItemSubTypeWithGradeRange(1000, 2, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 2, 8),
			new PresetItemSubTypeWithGradeRange(801, 2, 8),
			new PresetItemSubTypeWithGradeRange(1205, 2, 8),
			new PresetItemSubTypeWithGradeRange(1206, 2, 8),
			new PresetItemSubTypeWithGradeRange(1100, 2, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(51, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 2, 8),
			new PresetItemSubTypeWithGradeRange(1, 2, 8),
			new PresetItemSubTypeWithGradeRange(2, 2, 8),
			new PresetItemSubTypeWithGradeRange(3, 2, 8),
			new PresetItemSubTypeWithGradeRange(4, 2, 8),
			new PresetItemSubTypeWithGradeRange(5, 2, 8),
			new PresetItemSubTypeWithGradeRange(6, 2, 8),
			new PresetItemSubTypeWithGradeRange(7, 2, 8),
			new PresetItemSubTypeWithGradeRange(8, 2, 8),
			new PresetItemSubTypeWithGradeRange(9, 2, 8),
			new PresetItemSubTypeWithGradeRange(10, 2, 8),
			new PresetItemSubTypeWithGradeRange(11, 2, 8),
			new PresetItemSubTypeWithGradeRange(12, 4, 8),
			new PresetItemSubTypeWithGradeRange(13, 4, 8),
			new PresetItemSubTypeWithGradeRange(14, 4, 8),
			new PresetItemSubTypeWithGradeRange(15, 4, 8),
			new PresetItemSubTypeWithGradeRange(100, 2, 8),
			new PresetItemSubTypeWithGradeRange(101, 2, 8),
			new PresetItemSubTypeWithGradeRange(102, 2, 8),
			new PresetItemSubTypeWithGradeRange(103, 2, 8),
			new PresetItemSubTypeWithGradeRange(200, 2, 8),
			new PresetItemSubTypeWithGradeRange(400, 2, 8),
			new PresetItemSubTypeWithGradeRange(600, 2, 8),
			new PresetItemSubTypeWithGradeRange(300, 3, 8),
			new PresetItemSubTypeWithGradeRange(700, 1, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(500, 3, 8),
			new PresetItemSubTypeWithGradeRange(501, 3, 8),
			new PresetItemSubTypeWithGradeRange(502, 3, 8),
			new PresetItemSubTypeWithGradeRange(503, 3, 8),
			new PresetItemSubTypeWithGradeRange(504, 3, 8),
			new PresetItemSubTypeWithGradeRange(505, 4, 8),
			new PresetItemSubTypeWithGradeRange(506, 4, 8),
			new PresetItemSubTypeWithGradeRange(1000, 3, 8),
			new PresetItemSubTypeWithGradeRange(1001, 0, 8),
			new PresetItemSubTypeWithGradeRange(1201, 0, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 3, 8),
			new PresetItemSubTypeWithGradeRange(801, 3, 8),
			new PresetItemSubTypeWithGradeRange(1205, 3, 8),
			new PresetItemSubTypeWithGradeRange(1206, 3, 8),
			new PresetItemSubTypeWithGradeRange(1100, 3, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(52, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 3, 8),
			new PresetItemSubTypeWithGradeRange(1, 3, 8),
			new PresetItemSubTypeWithGradeRange(2, 3, 8),
			new PresetItemSubTypeWithGradeRange(3, 3, 8),
			new PresetItemSubTypeWithGradeRange(4, 3, 8),
			new PresetItemSubTypeWithGradeRange(5, 3, 8),
			new PresetItemSubTypeWithGradeRange(6, 3, 8),
			new PresetItemSubTypeWithGradeRange(7, 3, 8),
			new PresetItemSubTypeWithGradeRange(8, 3, 8),
			new PresetItemSubTypeWithGradeRange(9, 3, 8),
			new PresetItemSubTypeWithGradeRange(10, 3, 8),
			new PresetItemSubTypeWithGradeRange(11, 3, 8),
			new PresetItemSubTypeWithGradeRange(12, 5, 8),
			new PresetItemSubTypeWithGradeRange(13, 5, 8),
			new PresetItemSubTypeWithGradeRange(14, 5, 8),
			new PresetItemSubTypeWithGradeRange(15, 5, 8),
			new PresetItemSubTypeWithGradeRange(100, 3, 8),
			new PresetItemSubTypeWithGradeRange(101, 3, 8),
			new PresetItemSubTypeWithGradeRange(102, 3, 8),
			new PresetItemSubTypeWithGradeRange(103, 3, 8),
			new PresetItemSubTypeWithGradeRange(200, 3, 8),
			new PresetItemSubTypeWithGradeRange(400, 3, 8),
			new PresetItemSubTypeWithGradeRange(600, 3, 8),
			new PresetItemSubTypeWithGradeRange(300, 4, 8),
			new PresetItemSubTypeWithGradeRange(700, 2, 8),
			new PresetItemSubTypeWithGradeRange(900, 1, 8),
			new PresetItemSubTypeWithGradeRange(500, 4, 8),
			new PresetItemSubTypeWithGradeRange(501, 4, 8),
			new PresetItemSubTypeWithGradeRange(502, 4, 8),
			new PresetItemSubTypeWithGradeRange(503, 4, 8),
			new PresetItemSubTypeWithGradeRange(504, 4, 8),
			new PresetItemSubTypeWithGradeRange(505, 5, 8),
			new PresetItemSubTypeWithGradeRange(506, 5, 8),
			new PresetItemSubTypeWithGradeRange(1000, 4, 8),
			new PresetItemSubTypeWithGradeRange(1001, 1, 8),
			new PresetItemSubTypeWithGradeRange(1201, 1, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 4, 8),
			new PresetItemSubTypeWithGradeRange(801, 4, 8),
			new PresetItemSubTypeWithGradeRange(1205, 4, 8),
			new PresetItemSubTypeWithGradeRange(1206, 4, 8),
			new PresetItemSubTypeWithGradeRange(1100, 4, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(53, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 4, 8),
			new PresetItemSubTypeWithGradeRange(1, 4, 8),
			new PresetItemSubTypeWithGradeRange(2, 4, 8),
			new PresetItemSubTypeWithGradeRange(3, 4, 8),
			new PresetItemSubTypeWithGradeRange(4, 4, 8),
			new PresetItemSubTypeWithGradeRange(5, 4, 8),
			new PresetItemSubTypeWithGradeRange(6, 4, 8),
			new PresetItemSubTypeWithGradeRange(7, 4, 8),
			new PresetItemSubTypeWithGradeRange(8, 4, 8),
			new PresetItemSubTypeWithGradeRange(9, 4, 8),
			new PresetItemSubTypeWithGradeRange(10, 4, 8),
			new PresetItemSubTypeWithGradeRange(11, 4, 8),
			new PresetItemSubTypeWithGradeRange(12, 6, 8),
			new PresetItemSubTypeWithGradeRange(13, 6, 8),
			new PresetItemSubTypeWithGradeRange(14, 6, 8),
			new PresetItemSubTypeWithGradeRange(15, 6, 8),
			new PresetItemSubTypeWithGradeRange(100, 4, 8),
			new PresetItemSubTypeWithGradeRange(101, 4, 8),
			new PresetItemSubTypeWithGradeRange(102, 4, 8),
			new PresetItemSubTypeWithGradeRange(103, 4, 8),
			new PresetItemSubTypeWithGradeRange(200, 4, 8),
			new PresetItemSubTypeWithGradeRange(400, 4, 8),
			new PresetItemSubTypeWithGradeRange(600, 4, 8),
			new PresetItemSubTypeWithGradeRange(300, 5, 8),
			new PresetItemSubTypeWithGradeRange(700, 3, 8),
			new PresetItemSubTypeWithGradeRange(900, 2, 8),
			new PresetItemSubTypeWithGradeRange(500, 5, 8),
			new PresetItemSubTypeWithGradeRange(501, 5, 8),
			new PresetItemSubTypeWithGradeRange(502, 5, 8),
			new PresetItemSubTypeWithGradeRange(503, 5, 8),
			new PresetItemSubTypeWithGradeRange(504, 5, 8),
			new PresetItemSubTypeWithGradeRange(505, 6, 8),
			new PresetItemSubTypeWithGradeRange(506, 6, 8),
			new PresetItemSubTypeWithGradeRange(1000, 5, 8),
			new PresetItemSubTypeWithGradeRange(1001, 2, 8),
			new PresetItemSubTypeWithGradeRange(1201, 2, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 5, 8),
			new PresetItemSubTypeWithGradeRange(801, 5, 8),
			new PresetItemSubTypeWithGradeRange(1205, 5, 8),
			new PresetItemSubTypeWithGradeRange(1206, 5, 8),
			new PresetItemSubTypeWithGradeRange(1100, 5, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(54, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 5, 8),
			new PresetItemSubTypeWithGradeRange(1, 5, 8),
			new PresetItemSubTypeWithGradeRange(2, 5, 8),
			new PresetItemSubTypeWithGradeRange(3, 5, 8),
			new PresetItemSubTypeWithGradeRange(4, 5, 8),
			new PresetItemSubTypeWithGradeRange(5, 5, 8),
			new PresetItemSubTypeWithGradeRange(6, 5, 8),
			new PresetItemSubTypeWithGradeRange(7, 5, 8),
			new PresetItemSubTypeWithGradeRange(8, 5, 8),
			new PresetItemSubTypeWithGradeRange(9, 5, 8),
			new PresetItemSubTypeWithGradeRange(10, 5, 8),
			new PresetItemSubTypeWithGradeRange(11, 5, 8),
			new PresetItemSubTypeWithGradeRange(12, 7, 8),
			new PresetItemSubTypeWithGradeRange(13, 7, 8),
			new PresetItemSubTypeWithGradeRange(14, 7, 8),
			new PresetItemSubTypeWithGradeRange(15, 7, 8),
			new PresetItemSubTypeWithGradeRange(100, 5, 8),
			new PresetItemSubTypeWithGradeRange(101, 5, 8),
			new PresetItemSubTypeWithGradeRange(102, 5, 8),
			new PresetItemSubTypeWithGradeRange(103, 5, 8),
			new PresetItemSubTypeWithGradeRange(200, 5, 8),
			new PresetItemSubTypeWithGradeRange(400, 5, 8),
			new PresetItemSubTypeWithGradeRange(600, 5, 8),
			new PresetItemSubTypeWithGradeRange(300, 6, 8),
			new PresetItemSubTypeWithGradeRange(700, 4, 8),
			new PresetItemSubTypeWithGradeRange(900, 3, 8),
			new PresetItemSubTypeWithGradeRange(500, 6, 8),
			new PresetItemSubTypeWithGradeRange(501, 6, 8),
			new PresetItemSubTypeWithGradeRange(502, 6, 8),
			new PresetItemSubTypeWithGradeRange(503, 6, 8),
			new PresetItemSubTypeWithGradeRange(504, 6, 8),
			new PresetItemSubTypeWithGradeRange(505, 7, 8),
			new PresetItemSubTypeWithGradeRange(506, 7, 8),
			new PresetItemSubTypeWithGradeRange(1000, 6, 8),
			new PresetItemSubTypeWithGradeRange(1001, 3, 8),
			new PresetItemSubTypeWithGradeRange(1201, 3, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 6, 8),
			new PresetItemSubTypeWithGradeRange(801, 6, 8),
			new PresetItemSubTypeWithGradeRange(1205, 6, 8),
			new PresetItemSubTypeWithGradeRange(1206, 6, 8),
			new PresetItemSubTypeWithGradeRange(1100, 6, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(55, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 6, 8),
			new PresetItemSubTypeWithGradeRange(1, 6, 8),
			new PresetItemSubTypeWithGradeRange(2, 6, 8),
			new PresetItemSubTypeWithGradeRange(3, 6, 8),
			new PresetItemSubTypeWithGradeRange(4, 6, 8),
			new PresetItemSubTypeWithGradeRange(5, 6, 8),
			new PresetItemSubTypeWithGradeRange(6, 6, 8),
			new PresetItemSubTypeWithGradeRange(7, 6, 8),
			new PresetItemSubTypeWithGradeRange(8, 6, 8),
			new PresetItemSubTypeWithGradeRange(9, 6, 8),
			new PresetItemSubTypeWithGradeRange(10, 6, 8),
			new PresetItemSubTypeWithGradeRange(11, 6, 8),
			new PresetItemSubTypeWithGradeRange(12, 8, 8),
			new PresetItemSubTypeWithGradeRange(13, 8, 8),
			new PresetItemSubTypeWithGradeRange(14, 8, 8),
			new PresetItemSubTypeWithGradeRange(15, 8, 8),
			new PresetItemSubTypeWithGradeRange(100, 6, 8),
			new PresetItemSubTypeWithGradeRange(101, 6, 8),
			new PresetItemSubTypeWithGradeRange(102, 6, 8),
			new PresetItemSubTypeWithGradeRange(103, 6, 8),
			new PresetItemSubTypeWithGradeRange(200, 6, 8),
			new PresetItemSubTypeWithGradeRange(400, 6, 8),
			new PresetItemSubTypeWithGradeRange(600, 6, 8),
			new PresetItemSubTypeWithGradeRange(300, 7, 8),
			new PresetItemSubTypeWithGradeRange(700, 5, 8),
			new PresetItemSubTypeWithGradeRange(900, 4, 8),
			new PresetItemSubTypeWithGradeRange(500, 7, 8),
			new PresetItemSubTypeWithGradeRange(501, 7, 8),
			new PresetItemSubTypeWithGradeRange(502, 7, 8),
			new PresetItemSubTypeWithGradeRange(503, 7, 8),
			new PresetItemSubTypeWithGradeRange(504, 7, 8),
			new PresetItemSubTypeWithGradeRange(505, 8, 8),
			new PresetItemSubTypeWithGradeRange(506, 8, 8),
			new PresetItemSubTypeWithGradeRange(1000, 7, 8),
			new PresetItemSubTypeWithGradeRange(1001, 4, 8),
			new PresetItemSubTypeWithGradeRange(1201, 4, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 7, 8),
			new PresetItemSubTypeWithGradeRange(801, 7, 8),
			new PresetItemSubTypeWithGradeRange(1205, 7, 8),
			new PresetItemSubTypeWithGradeRange(1206, 7, 8),
			new PresetItemSubTypeWithGradeRange(1100, 7, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(56, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(0, 7, 8),
			new PresetItemSubTypeWithGradeRange(1, 7, 8),
			new PresetItemSubTypeWithGradeRange(2, 7, 8),
			new PresetItemSubTypeWithGradeRange(3, 7, 8),
			new PresetItemSubTypeWithGradeRange(4, 7, 8),
			new PresetItemSubTypeWithGradeRange(5, 7, 8),
			new PresetItemSubTypeWithGradeRange(6, 7, 8),
			new PresetItemSubTypeWithGradeRange(7, 7, 8),
			new PresetItemSubTypeWithGradeRange(8, 7, 8),
			new PresetItemSubTypeWithGradeRange(9, 7, 8),
			new PresetItemSubTypeWithGradeRange(10, 7, 8),
			new PresetItemSubTypeWithGradeRange(11, 7, 8),
			new PresetItemSubTypeWithGradeRange(100, 7, 8),
			new PresetItemSubTypeWithGradeRange(101, 7, 8),
			new PresetItemSubTypeWithGradeRange(102, 7, 8),
			new PresetItemSubTypeWithGradeRange(103, 7, 8),
			new PresetItemSubTypeWithGradeRange(200, 7, 8),
			new PresetItemSubTypeWithGradeRange(400, 7, 8),
			new PresetItemSubTypeWithGradeRange(600, 7, 8),
			new PresetItemSubTypeWithGradeRange(300, 8, 8),
			new PresetItemSubTypeWithGradeRange(700, 6, 8),
			new PresetItemSubTypeWithGradeRange(900, 5, 8),
			new PresetItemSubTypeWithGradeRange(500, 8, 8),
			new PresetItemSubTypeWithGradeRange(501, 8, 8),
			new PresetItemSubTypeWithGradeRange(502, 8, 8),
			new PresetItemSubTypeWithGradeRange(503, 8, 8),
			new PresetItemSubTypeWithGradeRange(504, 8, 8),
			new PresetItemSubTypeWithGradeRange(1000, 8, 8),
			new PresetItemSubTypeWithGradeRange(1001, 5, 8),
			new PresetItemSubTypeWithGradeRange(1201, 5, 8),
			new PresetItemSubTypeWithGradeRange(1202, 0, 8),
			new PresetItemSubTypeWithGradeRange(1204, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 8, 8),
			new PresetItemSubTypeWithGradeRange(801, 8, 8),
			new PresetItemSubTypeWithGradeRange(1205, 8, 8),
			new PresetItemSubTypeWithGradeRange(1206, 8, 8),
			new PresetItemSubTypeWithGradeRange(1100, 8, 8),
			new PresetItemSubTypeWithGradeRange(1207, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(57, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(700, 0, 8),
			new PresetItemSubTypeWithGradeRange(701, 0, 8),
			new PresetItemSubTypeWithGradeRange(800, 0, 8),
			new PresetItemSubTypeWithGradeRange(801, 0, 8),
			new PresetItemSubTypeWithGradeRange(900, 0, 8),
			new PresetItemSubTypeWithGradeRange(901, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(58, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(900, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(59, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(901, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new ItemFilterRulesItem(60, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(801, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(61, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 272, 1)
		}));
		_dataArray.Add(new ItemFilterRulesItem(62, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(1206, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(63, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>(), new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 229, 9)
		}));
		_dataArray.Add(new ItemFilterRulesItem(64, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(1203, 4, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(65, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(1001, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(66, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(1000, 0, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(67, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(1202, 8, 8)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(68, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(801, 0, 0)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(69, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(801, 1, 1)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(70, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(801, 2, 2)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(71, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(801, 3, 3)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(72, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(801, 4, 4)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(73, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(801, 5, 5)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(74, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(801, 6, 6)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(75, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(801, 7, 7)
		}, new List<PresetItemTemplateIdGroup>()));
		_dataArray.Add(new ItemFilterRulesItem(76, new PresetItemTemplateId("Misc", -1), new List<PresetItemSubTypeWithGradeRange>
		{
			new PresetItemSubTypeWithGradeRange(801, 8, 8)
		}, new List<PresetItemTemplateIdGroup>()));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ItemFilterRulesItem>(77);
		CreateItems0();
		CreateItems1();
	}
}
