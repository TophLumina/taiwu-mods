using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using GameData.Domains.Item;

namespace Config;

[Serializable]
public class ProtagonistFeature : ConfigData<ProtagonistFeatureItem, short>
{
	public static class DefKey
	{
		public const short Strength = 0;

		public const short Dexterity = 1;

		public const short Attack = 2;

		public const short Defend = 3;

		public const short Vitality = 4;

		public const short Energy = 5;

		public const short Hit = 6;

		public const short Avoid = 7;

		public const short Concentration = 8;

		public const short Intelligence = 9;

		public const short DamageStep = 10;

		public const short Personality = 11;

		public const short CloseFriend = 12;

		public const short Attraction = 13;

		public const short PoisonResists = 14;

		public const short Longevity = 15;

		public const short MaterialResources = 16;

		public const short Money = 17;

		public const short Wines = 18;

		public const short Teas = 19;

		public const short Clothing = 20;

		public const short Rope = 21;

		public const short CricketJar = 22;

		public const short Food = 23;

		public const short Horse = 24;

		public const short BuildingMaterial = 25;

		public const short PoisonMaterials = 26;

		public const short Medicines = 27;

		public const short SealOfMerchant = 28;

		public const short Fruit = 29;

		public const short Accessory = 30;

		public const short Construction = 31;

		public const short Literature = 32;

		public const short Religion = 33;

		public const short WitchDoctor = 34;

		public const short Artisan = 35;

		public const short FistFeet = 36;

		public const short SwordBlade = 37;

		public const short ThrowShot = 38;

		public const short SpecialWhip = 39;

		public const short LifeSkillLearning = 40;

		public const short CombatSkillLearning = 41;

		public const short CraftMaterials = 42;

		public const short CraftTools = 43;

		public const short CombatMusic = 44;

		public const short MartialArtist = 45;

		public const short GenericGridCount = 46;

		public const short SkillBooks = 47;
	}

	public static class DefValue
	{
		public static ProtagonistFeatureItem Strength => Instance[(short)0];

		public static ProtagonistFeatureItem Dexterity => Instance[(short)1];

		public static ProtagonistFeatureItem Attack => Instance[(short)2];

		public static ProtagonistFeatureItem Defend => Instance[(short)3];

		public static ProtagonistFeatureItem Vitality => Instance[(short)4];

		public static ProtagonistFeatureItem Energy => Instance[(short)5];

		public static ProtagonistFeatureItem Hit => Instance[(short)6];

		public static ProtagonistFeatureItem Avoid => Instance[(short)7];

		public static ProtagonistFeatureItem Concentration => Instance[(short)8];

		public static ProtagonistFeatureItem Intelligence => Instance[(short)9];

		public static ProtagonistFeatureItem DamageStep => Instance[(short)10];

		public static ProtagonistFeatureItem Personality => Instance[(short)11];

		public static ProtagonistFeatureItem CloseFriend => Instance[(short)12];

		public static ProtagonistFeatureItem Attraction => Instance[(short)13];

		public static ProtagonistFeatureItem PoisonResists => Instance[(short)14];

		public static ProtagonistFeatureItem Longevity => Instance[(short)15];

		public static ProtagonistFeatureItem MaterialResources => Instance[(short)16];

		public static ProtagonistFeatureItem Money => Instance[(short)17];

		public static ProtagonistFeatureItem Wines => Instance[(short)18];

		public static ProtagonistFeatureItem Teas => Instance[(short)19];

		public static ProtagonistFeatureItem Clothing => Instance[(short)20];

		public static ProtagonistFeatureItem Rope => Instance[(short)21];

		public static ProtagonistFeatureItem CricketJar => Instance[(short)22];

		public static ProtagonistFeatureItem Food => Instance[(short)23];

		public static ProtagonistFeatureItem Horse => Instance[(short)24];

		public static ProtagonistFeatureItem BuildingMaterial => Instance[(short)25];

		public static ProtagonistFeatureItem PoisonMaterials => Instance[(short)26];

		public static ProtagonistFeatureItem Medicines => Instance[(short)27];

		public static ProtagonistFeatureItem SealOfMerchant => Instance[(short)28];

		public static ProtagonistFeatureItem Fruit => Instance[(short)29];

		public static ProtagonistFeatureItem Accessory => Instance[(short)30];

		public static ProtagonistFeatureItem Construction => Instance[(short)31];

		public static ProtagonistFeatureItem Literature => Instance[(short)32];

		public static ProtagonistFeatureItem Religion => Instance[(short)33];

		public static ProtagonistFeatureItem WitchDoctor => Instance[(short)34];

		public static ProtagonistFeatureItem Artisan => Instance[(short)35];

		public static ProtagonistFeatureItem FistFeet => Instance[(short)36];

		public static ProtagonistFeatureItem SwordBlade => Instance[(short)37];

		public static ProtagonistFeatureItem ThrowShot => Instance[(short)38];

		public static ProtagonistFeatureItem SpecialWhip => Instance[(short)39];

		public static ProtagonistFeatureItem LifeSkillLearning => Instance[(short)40];

		public static ProtagonistFeatureItem CombatSkillLearning => Instance[(short)41];

		public static ProtagonistFeatureItem CraftMaterials => Instance[(short)42];

		public static ProtagonistFeatureItem CraftTools => Instance[(short)43];

		public static ProtagonistFeatureItem CombatMusic => Instance[(short)44];

		public static ProtagonistFeatureItem MartialArtist => Instance[(short)45];

		public static ProtagonistFeatureItem GenericGridCount => Instance[(short)46];

		public static ProtagonistFeatureItem SkillBooks => Instance[(short)47];
	}

	public static ProtagonistFeature Instance = new ProtagonistFeature();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "EffectDesc", "PermanentBonus", "CustomGroupItem", "CustomGroupName", "TemplateId", "Type", "Cost", "PrerequisiteCost" };

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
		_dataArray.Add(new ProtagonistFeatureItem(0, 0, 1, 0, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_0"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_0"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_0"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(0, 20, percent: false),
			new PropertyAndValueAndModifyType(112, 50, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(1, 0, 1, 0, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_1"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_1"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_1"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(1, 20, percent: false),
			new PropertyAndValueAndModifyType(113, 50, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(2, 0, 1, 0, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_2"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_2"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_2"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(10, 10, percent: true),
			new PropertyAndValueAndModifyType(11, 10, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(3, 0, 1, 0, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_3"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_3"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_3"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(16, 10, percent: true),
			new PropertyAndValueAndModifyType(17, 10, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(4, 0, 1, 1, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_4"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_4"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_4"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(3, 20, percent: false),
			new PropertyAndValueAndModifyType(115, 50, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(5, 0, 1, 1, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_5"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_5"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_5"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(4, 20, percent: false),
			new PropertyAndValueAndModifyType(116, 50, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(6, 0, 1, 1, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_6"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_6"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_6"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(6, 10, percent: true),
			new PropertyAndValueAndModifyType(7, 10, percent: true),
			new PropertyAndValueAndModifyType(8, 10, percent: true),
			new PropertyAndValueAndModifyType(9, 10, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(7, 0, 1, 1, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_7"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_7"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_7"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(12, 10, percent: true),
			new PropertyAndValueAndModifyType(13, 10, percent: true),
			new PropertyAndValueAndModifyType(14, 10, percent: true),
			new PropertyAndValueAndModifyType(15, 10, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(8, 0, 1, 2, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_8"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_8"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_8"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(2, 20, percent: false),
			new PropertyAndValueAndModifyType(114, 50, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(9, 0, 1, 2, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_9"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_9"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_9"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(5, 20, percent: false),
			new PropertyAndValueAndModifyType(117, 50, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(10, 0, 1, 2, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_10"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_10"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_10"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(118, 25, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(11, 0, 1, 2, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_11"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_11"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_11"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(94, 20, percent: false),
			new PropertyAndValueAndModifyType(95, 20, percent: false),
			new PropertyAndValueAndModifyType(96, 20, percent: false),
			new PropertyAndValueAndModifyType(97, 20, percent: false),
			new PropertyAndValueAndModifyType(98, 20, percent: false),
			new PropertyAndValueAndModifyType(99, 20, percent: false),
			new PropertyAndValueAndModifyType(100, 20, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(12, 0, 2, 3, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_12"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_12"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_12"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(13, 0, 2, 3, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_13"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_13"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_13"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(101, 600, percent: false),
			new PropertyAndValueAndModifyType(133, 33, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(14, 0, 3, 5, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_14"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_14"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_14"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(28, 300, percent: false),
			new PropertyAndValueAndModifyType(29, 300, percent: false),
			new PropertyAndValueAndModifyType(30, 300, percent: false),
			new PropertyAndValueAndModifyType(31, 300, percent: false),
			new PropertyAndValueAndModifyType(32, 300, percent: false),
			new PropertyAndValueAndModifyType(33, 300, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(15, 0, 3, 5, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_15"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_15"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_15"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(16, 1, 1, 0, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_16"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_16"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_16"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[1]
		{
			new List<TemplateKey>
			{
				new TemplateKey("Misc", 100),
				new TemplateKey("Misc", 101),
				new TemplateKey("Misc", 102),
				new TemplateKey("Misc", 103),
				new TemplateKey("Misc", 104),
				new TemplateKey("Misc", 105),
				new TemplateKey("Misc", 106),
				new TemplateKey("Misc", 107),
				new TemplateKey("Misc", 108),
				new TemplateKey("Misc", 109)
			}
		}, new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_16_0") }));
		_dataArray.Add(new ProtagonistFeatureItem(17, 1, 1, 0, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_17"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_17"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_17"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(18, 1, 1, 0, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_18"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_18"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_18"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(19, 1, 1, 0, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_19"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_19"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_19"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(20, 1, 1, 1, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_20"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_20"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_20"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(21, 1, 1, 1, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_21"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_21"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_21"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(22, 1, 1, 1, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_22"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_22"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_22"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(23, 1, 1, 1, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_23"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_23"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_23"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[4]
		{
			new List<TemplateKey>
			{
				new TemplateKey("Food", 23),
				new TemplateKey("Food", 30),
				new TemplateKey("Food", 36),
				new TemplateKey("Food", 41),
				new TemplateKey("Food", 45),
				new TemplateKey("Food", 48)
			},
			new List<TemplateKey>
			{
				new TemplateKey("Food", 57),
				new TemplateKey("Food", 65),
				new TemplateKey("Food", 72),
				new TemplateKey("Food", 78),
				new TemplateKey("Food", 83),
				new TemplateKey("Food", 90)
			},
			new List<TemplateKey>
			{
				new TemplateKey("Food", 6),
				new TemplateKey("Food", 99),
				new TemplateKey("Food", 107),
				new TemplateKey("Food", 114),
				new TemplateKey("Food", 120),
				new TemplateKey("Food", 125),
				new TemplateKey("Food", 129),
				new TemplateKey("Food", 132)
			},
			new List<TemplateKey>
			{
				new TemplateKey("Food", 87),
				new TemplateKey("Food", 141),
				new TemplateKey("Food", 149),
				new TemplateKey("Food", 156),
				new TemplateKey("Food", 162),
				new TemplateKey("Food", 167),
				new TemplateKey("Food", 171),
				new TemplateKey("Food", 174)
			}
		}, new int[4] { 1, 1, 1, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_23_0"),
			LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_23_1"),
			LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_23_2"),
			LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_23_3")
		}));
		_dataArray.Add(new ProtagonistFeatureItem(24, 1, 1, 2, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_24"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_24"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_24"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(25, 1, 1, 2, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_25"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_25"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_25"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[1]
		{
			new List<TemplateKey>
			{
				new TemplateKey("Misc", 110),
				new TemplateKey("Misc", 111),
				new TemplateKey("Misc", 112),
				new TemplateKey("Misc", 113),
				new TemplateKey("Misc", 114),
				new TemplateKey("Misc", 115),
				new TemplateKey("Misc", 116),
				new TemplateKey("Misc", 117),
				new TemplateKey("Misc", 118),
				new TemplateKey("Misc", 119)
			}
		}, new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_25_0") }));
		_dataArray.Add(new ProtagonistFeatureItem(26, 1, 1, 2, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_26"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_26"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_26"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[4]
		{
			new List<TemplateKey>
			{
				new TemplateKey("Medicine", 7),
				new TemplateKey("Medicine", 16),
				new TemplateKey("Medicine", 25),
				new TemplateKey("Medicine", 34),
				new TemplateKey("Medicine", 43),
				new TemplateKey("Medicine", 52)
			},
			new List<TemplateKey>
			{
				new TemplateKey("Medicine", 6),
				new TemplateKey("Medicine", 15),
				new TemplateKey("Medicine", 24),
				new TemplateKey("Medicine", 33),
				new TemplateKey("Medicine", 42),
				new TemplateKey("Medicine", 51)
			},
			new List<TemplateKey>
			{
				new TemplateKey("Medicine", 5),
				new TemplateKey("Medicine", 14),
				new TemplateKey("Medicine", 23),
				new TemplateKey("Medicine", 32),
				new TemplateKey("Medicine", 41),
				new TemplateKey("Medicine", 50)
			},
			new List<TemplateKey>
			{
				new TemplateKey("Medicine", 4),
				new TemplateKey("Medicine", 13),
				new TemplateKey("Medicine", 22),
				new TemplateKey("Medicine", 31),
				new TemplateKey("Medicine", 40),
				new TemplateKey("Medicine", 49)
			}
		}, new int[4] { 1, 2, 4, 8 }, new string[4]
		{
			LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_26_0"),
			LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_26_1"),
			LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_26_2"),
			LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_26_3")
		}));
		_dataArray.Add(new ProtagonistFeatureItem(27, 1, 1, 2, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_27"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_27"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_27"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(28, 1, 2, 3, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_28"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_28"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_28"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(29, 1, 2, 3, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_29"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_29"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_29"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(30, 1, 3, 5, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_30"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_30"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_30"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[1]
		{
			new List<TemplateKey>
			{
				new TemplateKey("Accessory", 225),
				new TemplateKey("Accessory", 226),
				new TemplateKey("Accessory", 227),
				new TemplateKey("Accessory", 228),
				new TemplateKey("Accessory", 229),
				new TemplateKey("Accessory", 230),
				new TemplateKey("Accessory", 231),
				new TemplateKey("Accessory", 232),
				new TemplateKey("Accessory", 233),
				new TemplateKey("Accessory", 234),
				new TemplateKey("Accessory", 235),
				new TemplateKey("Accessory", 236),
				new TemplateKey("Accessory", 237),
				new TemplateKey("Accessory", 238),
				new TemplateKey("Accessory", 239),
				new TemplateKey("Accessory", 240),
				new TemplateKey("Accessory", 241),
				new TemplateKey("Accessory", 242),
				new TemplateKey("Accessory", 243),
				new TemplateKey("Accessory", 244),
				new TemplateKey("Accessory", 245),
				new TemplateKey("Accessory", 246),
				new TemplateKey("Accessory", 247),
				new TemplateKey("Accessory", 248),
				new TemplateKey("Accessory", 249)
			}
		}, new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_30_0") }));
		_dataArray.Add(new ProtagonistFeatureItem(31, 1, 3, 5, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_31"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_31"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_31"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(32, 2, 1, 0, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_32"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_32"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_32"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(34, 20, percent: false),
			new PropertyAndValueAndModifyType(35, 20, percent: false),
			new PropertyAndValueAndModifyType(36, 20, percent: false),
			new PropertyAndValueAndModifyType(37, 20, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(33, 2, 1, 0, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_33"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_33"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_33"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(47, 20, percent: false),
			new PropertyAndValueAndModifyType(46, 20, percent: false),
			new PropertyAndValueAndModifyType(39, 20, percent: false),
			new PropertyAndValueAndModifyType(48, 20, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(34, 2, 1, 0, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_34"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_34"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_34"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(42, 20, percent: false),
			new PropertyAndValueAndModifyType(43, 20, percent: false),
			new PropertyAndValueAndModifyType(38, 20, percent: false),
			new PropertyAndValueAndModifyType(49, 20, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(35, 2, 1, 0, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_35"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_35"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_35"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(40, 20, percent: false),
			new PropertyAndValueAndModifyType(41, 20, percent: false),
			new PropertyAndValueAndModifyType(45, 20, percent: false),
			new PropertyAndValueAndModifyType(44, 20, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(36, 2, 1, 1, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_36"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_36"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_36"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(69, 20, percent: false),
			new PropertyAndValueAndModifyType(70, 20, percent: false),
			new PropertyAndValueAndModifyType(71, 20, percent: false),
			new PropertyAndValueAndModifyType(122, 3, percent: false),
			new PropertyAndValueAndModifyType(123, 3, percent: false),
			new PropertyAndValueAndModifyType(124, 3, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(37, 2, 1, 1, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_37"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_37"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_37"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(73, 20, percent: false),
			new PropertyAndValueAndModifyType(74, 20, percent: false),
			new PropertyAndValueAndModifyType(75, 20, percent: false),
			new PropertyAndValueAndModifyType(126, 3, percent: false),
			new PropertyAndValueAndModifyType(127, 3, percent: false),
			new PropertyAndValueAndModifyType(128, 3, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(38, 2, 1, 1, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_38"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_38"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_38"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(72, 20, percent: false),
			new PropertyAndValueAndModifyType(78, 20, percent: false),
			new PropertyAndValueAndModifyType(125, 3, percent: false),
			new PropertyAndValueAndModifyType(131, 3, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(39, 2, 1, 1, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_39"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_39"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_39"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(76, 20, percent: false),
			new PropertyAndValueAndModifyType(77, 20, percent: false),
			new PropertyAndValueAndModifyType(129, 3, percent: false),
			new PropertyAndValueAndModifyType(130, 3, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(40, 2, 1, 2, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_40"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_40"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_40"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(108, 25, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(41, 2, 1, 2, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_41"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_41"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_41"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(109, 25, percent: true)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(42, 2, 1, 2, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_42"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_42"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_42"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[4]
		{
			new List<TemplateKey>
			{
				new TemplateKey("Material", 6),
				new TemplateKey("Material", 13),
				new TemplateKey("Material", 20),
				new TemplateKey("Material", 27),
				new TemplateKey("Material", 34),
				new TemplateKey("Material", 41),
				new TemplateKey("Material", 48),
				new TemplateKey("Material", 55),
				new TemplateKey("Material", 143),
				new TemplateKey("Material", 147),
				new TemplateKey("Material", 151),
				new TemplateKey("Material", 155),
				new TemplateKey("Material", 159),
				new TemplateKey("Material", 163),
				new TemplateKey("Material", 167),
				new TemplateKey("Material", 171),
				new TemplateKey("Material", 175),
				new TemplateKey("Material", 179),
				new TemplateKey("Material", 183),
				new TemplateKey("Material", 187),
				new TemplateKey("Material", 191),
				new TemplateKey("Material", 195),
				new TemplateKey("Material", 199),
				new TemplateKey("Material", 203),
				new TemplateKey("Material", 207),
				new TemplateKey("Material", 211),
				new TemplateKey("Material", 215),
				new TemplateKey("Material", 219),
				new TemplateKey("Material", 223),
				new TemplateKey("Material", 227),
				new TemplateKey("Material", 231),
				new TemplateKey("Material", 235),
				new TemplateKey("Material", 242),
				new TemplateKey("Material", 249),
				new TemplateKey("Material", 256),
				new TemplateKey("Material", 263),
				new TemplateKey("Material", 270),
				new TemplateKey("Material", 277)
			},
			new List<TemplateKey>
			{
				new TemplateKey("Material", 5),
				new TemplateKey("Material", 12),
				new TemplateKey("Material", 19),
				new TemplateKey("Material", 26),
				new TemplateKey("Material", 33),
				new TemplateKey("Material", 40),
				new TemplateKey("Material", 47),
				new TemplateKey("Material", 54),
				new TemplateKey("Material", 62),
				new TemplateKey("Material", 69),
				new TemplateKey("Material", 76),
				new TemplateKey("Material", 83),
				new TemplateKey("Material", 241),
				new TemplateKey("Material", 248),
				new TemplateKey("Material", 255),
				new TemplateKey("Material", 262),
				new TemplateKey("Material", 269),
				new TemplateKey("Material", 276)
			},
			new List<TemplateKey>
			{
				new TemplateKey("Material", 4),
				new TemplateKey("Material", 11),
				new TemplateKey("Material", 18),
				new TemplateKey("Material", 25),
				new TemplateKey("Material", 32),
				new TemplateKey("Material", 39),
				new TemplateKey("Material", 46),
				new TemplateKey("Material", 53),
				new TemplateKey("Material", 61),
				new TemplateKey("Material", 68),
				new TemplateKey("Material", 75),
				new TemplateKey("Material", 82),
				new TemplateKey("Material", 142),
				new TemplateKey("Material", 146),
				new TemplateKey("Material", 150),
				new TemplateKey("Material", 154),
				new TemplateKey("Material", 158),
				new TemplateKey("Material", 162),
				new TemplateKey("Material", 166),
				new TemplateKey("Material", 170),
				new TemplateKey("Material", 174),
				new TemplateKey("Material", 178),
				new TemplateKey("Material", 182),
				new TemplateKey("Material", 186),
				new TemplateKey("Material", 190),
				new TemplateKey("Material", 194),
				new TemplateKey("Material", 198),
				new TemplateKey("Material", 202),
				new TemplateKey("Material", 206),
				new TemplateKey("Material", 210),
				new TemplateKey("Material", 214),
				new TemplateKey("Material", 218),
				new TemplateKey("Material", 222),
				new TemplateKey("Material", 226),
				new TemplateKey("Material", 230),
				new TemplateKey("Material", 234),
				new TemplateKey("Material", 240),
				new TemplateKey("Material", 247),
				new TemplateKey("Material", 254),
				new TemplateKey("Material", 261),
				new TemplateKey("Material", 268),
				new TemplateKey("Material", 275)
			},
			new List<TemplateKey>
			{
				new TemplateKey("Material", 3),
				new TemplateKey("Material", 10),
				new TemplateKey("Material", 17),
				new TemplateKey("Material", 24),
				new TemplateKey("Material", 31),
				new TemplateKey("Material", 38),
				new TemplateKey("Material", 45),
				new TemplateKey("Material", 52),
				new TemplateKey("Material", 60),
				new TemplateKey("Material", 67),
				new TemplateKey("Material", 74),
				new TemplateKey("Material", 81),
				new TemplateKey("Material", 239),
				new TemplateKey("Material", 246),
				new TemplateKey("Material", 253),
				new TemplateKey("Material", 260),
				new TemplateKey("Material", 267),
				new TemplateKey("Material", 274)
			}
		}, new int[4] { 1, 2, 4, 8 }, new string[4]
		{
			LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_42_0"),
			LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_42_1"),
			LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_42_2"),
			LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_42_3")
		}));
		_dataArray.Add(new ProtagonistFeatureItem(43, 2, 1, 2, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_43"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_43"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_43"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[1]
		{
			new List<TemplateKey>
			{
				new TemplateKey("CraftTool", 6),
				new TemplateKey("CraftTool", 15),
				new TemplateKey("CraftTool", 24),
				new TemplateKey("CraftTool", 33),
				new TemplateKey("CraftTool", 42),
				new TemplateKey("CraftTool", 51)
			}
		}, new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("ProtagonistFeature_language", "CustomGroupName_43_0") }));
		_dataArray.Add(new ProtagonistFeatureItem(44, 2, 2, 3, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_44"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_44"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_44"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(79, 20, percent: false),
			new PropertyAndValueAndModifyType(132, 3, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(45, 2, 2, 3, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_45"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_45"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_45"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(66, 20, percent: false),
			new PropertyAndValueAndModifyType(67, 20, percent: false),
			new PropertyAndValueAndModifyType(68, 20, percent: false),
			new PropertyAndValueAndModifyType(119, 3, percent: false),
			new PropertyAndValueAndModifyType(120, 3, percent: false),
			new PropertyAndValueAndModifyType(121, 3, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(46, 2, 3, 5, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_46"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_46"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_46"), new List<PropertyAndValueAndModifyType>
		{
			new PropertyAndValueAndModifyType(134, 3, percent: false)
		}, new List<TemplateKey>[0], new int[0], new string[0]));
		_dataArray.Add(new ProtagonistFeatureItem(47, 2, 3, 5, LocalStringManager.GetConfig("ProtagonistFeature_language", "Name_47"), LocalStringManager.GetConfig("ProtagonistFeature_language", "Desc_47"), LocalStringManager.GetConfig("ProtagonistFeature_language", "EffectDesc_47"), new List<PropertyAndValueAndModifyType>(), new List<TemplateKey>[0], new int[0], new string[0]));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ProtagonistFeatureItem>(48);
		CreateItems0();
	}
}
