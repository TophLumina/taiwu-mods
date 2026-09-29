using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class Merchant : ConfigData<MerchantItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Foods0 = 0;

		public const sbyte Foods1 = 1;

		public const sbyte Foods2 = 2;

		public const sbyte Foods3 = 3;

		public const sbyte Foods4 = 4;

		public const sbyte Foods5 = 5;

		public const sbyte Foods6 = 6;

		public const sbyte Books0 = 7;

		public const sbyte Books1 = 8;

		public const sbyte Books2 = 9;

		public const sbyte Books3 = 10;

		public const sbyte Books4 = 11;

		public const sbyte Books5 = 12;

		public const sbyte Books6 = 13;

		public const sbyte Materials0 = 14;

		public const sbyte Materials1 = 15;

		public const sbyte Materials2 = 16;

		public const sbyte Materials3 = 17;

		public const sbyte Materials4 = 18;

		public const sbyte Materials5 = 19;

		public const sbyte Materials6 = 20;

		public const sbyte Equipments0 = 21;

		public const sbyte Equipments1 = 22;

		public const sbyte Equipments2 = 23;

		public const sbyte Equipments3 = 24;

		public const sbyte Equipments4 = 25;

		public const sbyte Equipments5 = 26;

		public const sbyte Equipments6 = 27;

		public const sbyte Medicines0 = 28;

		public const sbyte Medicines1 = 29;

		public const sbyte Medicines2 = 30;

		public const sbyte Medicines3 = 31;

		public const sbyte Medicines4 = 32;

		public const sbyte Medicines5 = 33;

		public const sbyte Medicines6 = 34;

		public const sbyte Constructions0 = 35;

		public const sbyte Constructions1 = 36;

		public const sbyte Constructions2 = 37;

		public const sbyte Constructions3 = 38;

		public const sbyte Constructions4 = 39;

		public const sbyte Constructions5 = 40;

		public const sbyte Constructions6 = 41;

		public const sbyte Accessories0 = 42;

		public const sbyte Accessories1 = 43;

		public const sbyte Accessories2 = 44;

		public const sbyte Accessories3 = 45;

		public const sbyte Accessories4 = 46;

		public const sbyte Accessories5 = 47;

		public const sbyte Accessories6 = 48;

		public const sbyte WuHuZhenBao0 = 49;

		public const sbyte WuHuZhenBao1 = 50;

		public const sbyte WuHuZhenBao2 = 51;

		public const sbyte FruitShop = 52;

		public const sbyte EMeiShop = 53;
	}

	public static class DefValue
	{
		public static MerchantItem Foods0 => Instance[(sbyte)0];

		public static MerchantItem Foods1 => Instance[(sbyte)1];

		public static MerchantItem Foods2 => Instance[(sbyte)2];

		public static MerchantItem Foods3 => Instance[(sbyte)3];

		public static MerchantItem Foods4 => Instance[(sbyte)4];

		public static MerchantItem Foods5 => Instance[(sbyte)5];

		public static MerchantItem Foods6 => Instance[(sbyte)6];

		public static MerchantItem Books0 => Instance[(sbyte)7];

		public static MerchantItem Books1 => Instance[(sbyte)8];

		public static MerchantItem Books2 => Instance[(sbyte)9];

		public static MerchantItem Books3 => Instance[(sbyte)10];

		public static MerchantItem Books4 => Instance[(sbyte)11];

		public static MerchantItem Books5 => Instance[(sbyte)12];

		public static MerchantItem Books6 => Instance[(sbyte)13];

		public static MerchantItem Materials0 => Instance[(sbyte)14];

		public static MerchantItem Materials1 => Instance[(sbyte)15];

		public static MerchantItem Materials2 => Instance[(sbyte)16];

		public static MerchantItem Materials3 => Instance[(sbyte)17];

		public static MerchantItem Materials4 => Instance[(sbyte)18];

		public static MerchantItem Materials5 => Instance[(sbyte)19];

		public static MerchantItem Materials6 => Instance[(sbyte)20];

		public static MerchantItem Equipments0 => Instance[(sbyte)21];

		public static MerchantItem Equipments1 => Instance[(sbyte)22];

		public static MerchantItem Equipments2 => Instance[(sbyte)23];

		public static MerchantItem Equipments3 => Instance[(sbyte)24];

		public static MerchantItem Equipments4 => Instance[(sbyte)25];

		public static MerchantItem Equipments5 => Instance[(sbyte)26];

		public static MerchantItem Equipments6 => Instance[(sbyte)27];

		public static MerchantItem Medicines0 => Instance[(sbyte)28];

		public static MerchantItem Medicines1 => Instance[(sbyte)29];

		public static MerchantItem Medicines2 => Instance[(sbyte)30];

		public static MerchantItem Medicines3 => Instance[(sbyte)31];

		public static MerchantItem Medicines4 => Instance[(sbyte)32];

		public static MerchantItem Medicines5 => Instance[(sbyte)33];

		public static MerchantItem Medicines6 => Instance[(sbyte)34];

		public static MerchantItem Constructions0 => Instance[(sbyte)35];

		public static MerchantItem Constructions1 => Instance[(sbyte)36];

		public static MerchantItem Constructions2 => Instance[(sbyte)37];

		public static MerchantItem Constructions3 => Instance[(sbyte)38];

		public static MerchantItem Constructions4 => Instance[(sbyte)39];

		public static MerchantItem Constructions5 => Instance[(sbyte)40];

		public static MerchantItem Constructions6 => Instance[(sbyte)41];

		public static MerchantItem Accessories0 => Instance[(sbyte)42];

		public static MerchantItem Accessories1 => Instance[(sbyte)43];

		public static MerchantItem Accessories2 => Instance[(sbyte)44];

		public static MerchantItem Accessories3 => Instance[(sbyte)45];

		public static MerchantItem Accessories4 => Instance[(sbyte)46];

		public static MerchantItem Accessories5 => Instance[(sbyte)47];

		public static MerchantItem Accessories6 => Instance[(sbyte)48];

		public static MerchantItem WuHuZhenBao0 => Instance[(sbyte)49];

		public static MerchantItem WuHuZhenBao1 => Instance[(sbyte)50];

		public static MerchantItem WuHuZhenBao2 => Instance[(sbyte)51];

		public static MerchantItem FruitShop => Instance[(sbyte)52];

		public static MerchantItem EMeiShop => Instance[(sbyte)53];
	}

	public static Merchant Instance = new Merchant();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"GroupId", "MerchantType", "UiName", "Goods0", "Goods1", "Goods2", "Goods3", "Goods4", "Goods5", "Goods6",
		"Goods7", "Goods8", "Goods9", "Goods10", "Goods11", "Goods12", "Goods13", "Guards", "Enemy", "TemplateId",
		"Level", "GenerateInterval", "MoveInterval"
	};

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
		List<MerchantItem> dataArray = _dataArray;
		string config = LocalStringManager.GetConfig("Merchant_language", "UiName_0");
		List<PresetItemTemplateIdGroup> goods = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 56, 3),
			new PresetItemTemplateIdGroup("Material", 57, 3),
			new PresetItemTemplateIdGroup("Material", 58, 3)
		};
		List<PresetItemTemplateIdGroup> goods2 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 63, 3),
			new PresetItemTemplateIdGroup("Material", 64, 3),
			new PresetItemTemplateIdGroup("Material", 65, 3)
		};
		List<PresetItemTemplateIdGroup> goods3 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 70, 3),
			new PresetItemTemplateIdGroup("Material", 71, 3),
			new PresetItemTemplateIdGroup("Material", 72, 3)
		};
		List<PresetItemTemplateIdGroup> goods4 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 77, 3),
			new PresetItemTemplateIdGroup("Material", 78, 3),
			new PresetItemTemplateIdGroup("Material", 79, 3)
		};
		List<PresetItemTemplateIdGroup> goods5 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 0, 3),
			new PresetItemTemplateIdGroup("Food", 1, 3),
			new PresetItemTemplateIdGroup("Food", 2, 3)
		};
		List<PresetItemTemplateIdGroup> goods6 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 9, 3),
			new PresetItemTemplateIdGroup("Food", 10, 3),
			new PresetItemTemplateIdGroup("Food", 18, 3),
			new PresetItemTemplateIdGroup("Food", 11, 3),
			new PresetItemTemplateIdGroup("Food", 19, 3),
			new PresetItemTemplateIdGroup("Food", 26, 3)
		};
		List<PresetItemTemplateIdGroup> goods7 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 51, 3),
			new PresetItemTemplateIdGroup("Food", 52, 3),
			new PresetItemTemplateIdGroup("Food", 60, 3),
			new PresetItemTemplateIdGroup("Food", 53, 3),
			new PresetItemTemplateIdGroup("Food", 61, 3),
			new PresetItemTemplateIdGroup("Food", 68, 3)
		};
		List<PresetItemTemplateIdGroup> goods8 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 93, 3),
			new PresetItemTemplateIdGroup("Food", 94, 3),
			new PresetItemTemplateIdGroup("Food", 102, 3),
			new PresetItemTemplateIdGroup("Food", 95, 3),
			new PresetItemTemplateIdGroup("Food", 103, 3),
			new PresetItemTemplateIdGroup("Food", 110, 3)
		};
		List<PresetItemTemplateIdGroup> goods9 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 135, 3),
			new PresetItemTemplateIdGroup("Food", 136, 3),
			new PresetItemTemplateIdGroup("Food", 144, 3),
			new PresetItemTemplateIdGroup("Food", 137, 3),
			new PresetItemTemplateIdGroup("Food", 145, 3),
			new PresetItemTemplateIdGroup("Food", 152, 3)
		};
		List<PresetItemTemplateIdGroup> goods10 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 18, 1),
			new PresetItemTemplateIdGroup("Carrier", 19, 1)
		};
		List<PresetItemTemplateIdGroup> goods11 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 36, 1),
			new PresetItemTemplateIdGroup("CraftTool", 37, 1),
			new PresetItemTemplateIdGroup("CraftTool", 38, 1)
		};
		List<PresetItemTemplateIdGroup> goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray.Add(new MerchantItem(0, 0, 0, 0, config, 0, 1, 3, 20, 6000, goods, goods2, goods3, goods4, goods5, goods6, goods7, goods8, goods9, goods10, goods11, goods12, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 266, 10)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 18, 30)
		}, new sbyte[6] { 0, 1, 2, 3, 9, 10 }, new sbyte[7] { 0, 1, 2, 3, 9, 10, 13 }, new short[14]
		{
			2, 2, 2, 2, 1, 2, 2, 2, 2, 1,
			1, 0, 1, 1
		}, new short[14]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 0, 1, 1
		}, new short[14]
		{
			0, 2, 0, 0, 0, 0, 2, 0, 0, 0,
			0, 0, 2, 2
		}, new short[14]
		{
			0, 0, 2, 0, 0, 0, 0, 2, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 2, 0, 0, 0, 0, 2, 0,
			0, 0, 0, 1
		}, new short[14]
		{
			2, 0, 0, 0, 0, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 377, 376, 376, 376 }, 310));
		List<MerchantItem> dataArray2 = _dataArray;
		string config2 = LocalStringManager.GetConfig("Merchant_language", "UiName_1");
		List<PresetItemTemplateIdGroup> goods13 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 59, 1)
		};
		List<PresetItemTemplateIdGroup> goods14 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 66, 1)
		};
		List<PresetItemTemplateIdGroup> goods15 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 73, 1)
		};
		List<PresetItemTemplateIdGroup> goods16 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 80, 1)
		};
		List<PresetItemTemplateIdGroup> goods17 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 3, 2)
		};
		List<PresetItemTemplateIdGroup> goods18 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 12, 2),
			new PresetItemTemplateIdGroup("Food", 20, 2),
			new PresetItemTemplateIdGroup("Food", 27, 2),
			new PresetItemTemplateIdGroup("Food", 33, 2)
		};
		List<PresetItemTemplateIdGroup> goods19 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 54, 2),
			new PresetItemTemplateIdGroup("Food", 62, 2),
			new PresetItemTemplateIdGroup("Food", 69, 2),
			new PresetItemTemplateIdGroup("Food", 75, 2)
		};
		List<PresetItemTemplateIdGroup> goods20 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 96, 2),
			new PresetItemTemplateIdGroup("Food", 104, 2),
			new PresetItemTemplateIdGroup("Food", 111, 2),
			new PresetItemTemplateIdGroup("Food", 117, 2)
		};
		List<PresetItemTemplateIdGroup> goods21 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 138, 2),
			new PresetItemTemplateIdGroup("Food", 146, 2),
			new PresetItemTemplateIdGroup("Food", 153, 2),
			new PresetItemTemplateIdGroup("Food", 159, 2)
		};
		List<PresetItemTemplateIdGroup> goods22 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 20, 1)
		};
		List<PresetItemTemplateIdGroup> goods23 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 39, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods24 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods25 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray2.Add(new MerchantItem(1, 0, 0, 1, config2, 20, 1, 3, 20, 12000, goods13, goods14, goods15, goods16, goods17, goods18, goods19, goods20, goods21, goods22, goods23, goods24, goods25, goods12, new sbyte[6] { 0, 1, 2, 3, 9, 10 }, new sbyte[6] { 0, 1, 2, 3, 9, 10 }, new short[14]
		{
			-60, -60, -60, -60, -60, 1, 1, 1, 1, 1,
			-60, 0, 0, 0
		}, new short[14]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 0, 0, 0
		}, new short[14]
		{
			0, -60, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -60, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -60, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-60, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 378, 377, 377, 377 }, 330));
		List<MerchantItem> dataArray3 = _dataArray;
		string config3 = LocalStringManager.GetConfig("Merchant_language", "UiName_2");
		List<PresetItemTemplateIdGroup> goods26 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 59, 1)
		};
		List<PresetItemTemplateIdGroup> goods27 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 66, 1)
		};
		List<PresetItemTemplateIdGroup> goods28 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 73, 1)
		};
		List<PresetItemTemplateIdGroup> goods29 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 80, 1)
		};
		List<PresetItemTemplateIdGroup> goods30 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 4, 2)
		};
		List<PresetItemTemplateIdGroup> goods31 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 13, 2),
			new PresetItemTemplateIdGroup("Food", 21, 2),
			new PresetItemTemplateIdGroup("Food", 28, 2),
			new PresetItemTemplateIdGroup("Food", 34, 2),
			new PresetItemTemplateIdGroup("Food", 39, 2)
		};
		List<PresetItemTemplateIdGroup> goods32 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 55, 2),
			new PresetItemTemplateIdGroup("Food", 63, 2),
			new PresetItemTemplateIdGroup("Food", 70, 2),
			new PresetItemTemplateIdGroup("Food", 76, 2),
			new PresetItemTemplateIdGroup("Food", 81, 2)
		};
		List<PresetItemTemplateIdGroup> goods33 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 97, 2),
			new PresetItemTemplateIdGroup("Food", 105, 2),
			new PresetItemTemplateIdGroup("Food", 112, 2),
			new PresetItemTemplateIdGroup("Food", 118, 2),
			new PresetItemTemplateIdGroup("Food", 123, 2)
		};
		List<PresetItemTemplateIdGroup> goods34 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 139, 2),
			new PresetItemTemplateIdGroup("Food", 147, 2),
			new PresetItemTemplateIdGroup("Food", 154, 2),
			new PresetItemTemplateIdGroup("Food", 160, 2),
			new PresetItemTemplateIdGroup("Food", 165, 2)
		};
		List<PresetItemTemplateIdGroup> goods35 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 21, 1)
		};
		List<PresetItemTemplateIdGroup> goods36 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 40, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods37 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods38 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray3.Add(new MerchantItem(2, 0, 0, 2, config3, 40, 1, 6, 20, 24000, goods26, goods27, goods28, goods29, goods30, goods31, goods32, goods33, goods34, goods35, goods36, goods37, goods38, goods12, new sbyte[6] { 0, 1, 2, 3, 9, 10 }, new sbyte[6] { 0, 1, 2, 3, 9, 10 }, new short[14]
		{
			-60, -60, -60, -60, -50, 1, 1, 1, 1, -60,
			-50, 0, 0, 0
		}, new short[14]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 0, 0, 0
		}, new short[14]
		{
			0, -60, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -60, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -60, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-60, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 379, 378, 378, 378 }, 335));
		List<MerchantItem> dataArray4 = _dataArray;
		string config4 = LocalStringManager.GetConfig("Merchant_language", "UiName_3");
		List<PresetItemTemplateIdGroup> goods39 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 60, 1)
		};
		List<PresetItemTemplateIdGroup> goods40 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 67, 1)
		};
		List<PresetItemTemplateIdGroup> goods41 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 74, 1)
		};
		List<PresetItemTemplateIdGroup> goods42 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 81, 1)
		};
		List<PresetItemTemplateIdGroup> goods43 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 5, 2)
		};
		List<PresetItemTemplateIdGroup> goods44 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 14, 2),
			new PresetItemTemplateIdGroup("Food", 22, 2),
			new PresetItemTemplateIdGroup("Food", 29, 2),
			new PresetItemTemplateIdGroup("Food", 35, 2),
			new PresetItemTemplateIdGroup("Food", 40, 2),
			new PresetItemTemplateIdGroup("Food", 44, 2)
		};
		List<PresetItemTemplateIdGroup> goods45 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 56, 2),
			new PresetItemTemplateIdGroup("Food", 64, 2),
			new PresetItemTemplateIdGroup("Food", 71, 2),
			new PresetItemTemplateIdGroup("Food", 77, 2),
			new PresetItemTemplateIdGroup("Food", 82, 2),
			new PresetItemTemplateIdGroup("Food", 86, 2)
		};
		List<PresetItemTemplateIdGroup> goods46 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 98, 2),
			new PresetItemTemplateIdGroup("Food", 106, 2),
			new PresetItemTemplateIdGroup("Food", 113, 2),
			new PresetItemTemplateIdGroup("Food", 119, 2),
			new PresetItemTemplateIdGroup("Food", 124, 2),
			new PresetItemTemplateIdGroup("Food", 128, 2)
		};
		List<PresetItemTemplateIdGroup> goods47 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 140, 2),
			new PresetItemTemplateIdGroup("Food", 148, 2),
			new PresetItemTemplateIdGroup("Food", 155, 2),
			new PresetItemTemplateIdGroup("Food", 161, 2),
			new PresetItemTemplateIdGroup("Food", 166, 2),
			new PresetItemTemplateIdGroup("Food", 170, 2)
		};
		List<PresetItemTemplateIdGroup> goods48 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 22, 1)
		};
		List<PresetItemTemplateIdGroup> goods49 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 41, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods50 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods51 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray4.Add(new MerchantItem(3, 0, 0, 3, config4, 60, 1, 6, 20, 48000, goods39, goods40, goods41, goods42, goods43, goods44, goods45, goods46, goods47, goods48, goods49, goods50, goods51, goods12, new sbyte[6] { 0, 1, 2, 3, 9, 10 }, new sbyte[6] { 0, 1, 2, 3, 9, 10 }, new short[14]
		{
			-50, -50, -50, -50, -40, 2, 2, 2, 2, -50,
			-40, 0, 0, 0
		}, new short[14]
		{
			1, 1, 1, 1, -80, 2, 2, 2, 2, 1,
			-80, 0, 0, 0
		}, new short[14]
		{
			0, -50, 0, 0, 0, 0, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -50, 0, 0, 0, 0, 2, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -50, 0, 0, 0, 0, 2, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-50, 0, 0, 0, 0, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 380, 379, 379, 379 }, 340));
		List<MerchantItem> dataArray5 = _dataArray;
		string config5 = LocalStringManager.GetConfig("Merchant_language", "UiName_4");
		List<PresetItemTemplateIdGroup> goods52 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 60, 1)
		};
		List<PresetItemTemplateIdGroup> goods53 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 67, 1)
		};
		List<PresetItemTemplateIdGroup> goods54 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 74, 1)
		};
		List<PresetItemTemplateIdGroup> goods55 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 81, 1)
		};
		List<PresetItemTemplateIdGroup> goods56 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 6, 1)
		};
		List<PresetItemTemplateIdGroup> goods57 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 15, 1),
			new PresetItemTemplateIdGroup("Food", 23, 1),
			new PresetItemTemplateIdGroup("Food", 30, 1),
			new PresetItemTemplateIdGroup("Food", 36, 1),
			new PresetItemTemplateIdGroup("Food", 41, 1),
			new PresetItemTemplateIdGroup("Food", 45, 1),
			new PresetItemTemplateIdGroup("Food", 48, 1)
		};
		List<PresetItemTemplateIdGroup> goods58 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 57, 1),
			new PresetItemTemplateIdGroup("Food", 65, 1),
			new PresetItemTemplateIdGroup("Food", 72, 1),
			new PresetItemTemplateIdGroup("Food", 78, 1),
			new PresetItemTemplateIdGroup("Food", 83, 1),
			new PresetItemTemplateIdGroup("Food", 87, 1),
			new PresetItemTemplateIdGroup("Food", 90, 1)
		};
		List<PresetItemTemplateIdGroup> goods59 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 99, 1),
			new PresetItemTemplateIdGroup("Food", 107, 1),
			new PresetItemTemplateIdGroup("Food", 114, 1),
			new PresetItemTemplateIdGroup("Food", 120, 1),
			new PresetItemTemplateIdGroup("Food", 125, 1),
			new PresetItemTemplateIdGroup("Food", 129, 1),
			new PresetItemTemplateIdGroup("Food", 132, 1)
		};
		List<PresetItemTemplateIdGroup> goods60 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 141, 1),
			new PresetItemTemplateIdGroup("Food", 149, 1),
			new PresetItemTemplateIdGroup("Food", 156, 1),
			new PresetItemTemplateIdGroup("Food", 162, 1),
			new PresetItemTemplateIdGroup("Food", 167, 1),
			new PresetItemTemplateIdGroup("Food", 171, 1),
			new PresetItemTemplateIdGroup("Food", 174, 1)
		};
		List<PresetItemTemplateIdGroup> goods61 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 23, 1)
		};
		List<PresetItemTemplateIdGroup> goods62 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 42, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods63 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods64 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray5.Add(new MerchantItem(4, 0, 0, 4, config5, 80, 1, 9, 20, 96000, goods52, goods53, goods54, goods55, goods56, goods57, goods58, goods59, goods60, goods61, goods62, goods63, goods64, goods12, new sbyte[6] { 0, 1, 2, 3, 9, 10 }, new sbyte[6] { 0, 1, 2, 3, 9, 10 }, new short[14]
		{
			-50, -50, -50, -50, -30, 1, 1, 1, 1, -40,
			-30, 0, 0, 0
		}, new short[14]
		{
			1, 1, 1, 1, -60, 1, 1, 1, 1, -80,
			-60, 0, 0, 0
		}, new short[14]
		{
			0, -50, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -50, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -50, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-50, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 381, 380, 380, 380 }, 345));
		List<MerchantItem> dataArray6 = _dataArray;
		string config6 = LocalStringManager.GetConfig("Merchant_language", "UiName_5");
		List<PresetItemTemplateIdGroup> goods65 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 61, 1)
		};
		List<PresetItemTemplateIdGroup> goods66 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 68, 1)
		};
		List<PresetItemTemplateIdGroup> goods67 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 75, 1)
		};
		List<PresetItemTemplateIdGroup> goods68 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 82, 1)
		};
		List<PresetItemTemplateIdGroup> goods69 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 7, 1)
		};
		List<PresetItemTemplateIdGroup> goods70 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 16, 1),
			new PresetItemTemplateIdGroup("Food", 24, 1),
			new PresetItemTemplateIdGroup("Food", 31, 1),
			new PresetItemTemplateIdGroup("Food", 37, 1),
			new PresetItemTemplateIdGroup("Food", 42, 1),
			new PresetItemTemplateIdGroup("Food", 46, 1),
			new PresetItemTemplateIdGroup("Food", 49, 1)
		};
		List<PresetItemTemplateIdGroup> goods71 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 58, 1),
			new PresetItemTemplateIdGroup("Food", 66, 1),
			new PresetItemTemplateIdGroup("Food", 73, 1),
			new PresetItemTemplateIdGroup("Food", 79, 1),
			new PresetItemTemplateIdGroup("Food", 84, 1),
			new PresetItemTemplateIdGroup("Food", 88, 1),
			new PresetItemTemplateIdGroup("Food", 91, 1)
		};
		List<PresetItemTemplateIdGroup> goods72 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 100, 1),
			new PresetItemTemplateIdGroup("Food", 108, 1),
			new PresetItemTemplateIdGroup("Food", 115, 1),
			new PresetItemTemplateIdGroup("Food", 121, 1),
			new PresetItemTemplateIdGroup("Food", 126, 1),
			new PresetItemTemplateIdGroup("Food", 130, 1),
			new PresetItemTemplateIdGroup("Food", 133, 1)
		};
		List<PresetItemTemplateIdGroup> goods73 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 142, 1),
			new PresetItemTemplateIdGroup("Food", 150, 1),
			new PresetItemTemplateIdGroup("Food", 157, 1),
			new PresetItemTemplateIdGroup("Food", 163, 1),
			new PresetItemTemplateIdGroup("Food", 168, 1),
			new PresetItemTemplateIdGroup("Food", 172, 1),
			new PresetItemTemplateIdGroup("Food", 175, 1)
		};
		List<PresetItemTemplateIdGroup> goods74 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 24, 1)
		};
		List<PresetItemTemplateIdGroup> goods75 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 43, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods76 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods77 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray6.Add(new MerchantItem(5, 0, 0, 5, config6, 90, 1, 9, 20, 192000, goods65, goods66, goods67, goods68, goods69, goods70, goods71, goods72, goods73, goods74, goods75, goods76, goods77, goods12, new sbyte[6] { 0, 1, 2, 3, 9, 10 }, new sbyte[6] { 0, 1, 2, 3, 9, 10 }, new short[14]
		{
			-40, -40, -40, -40, -20, 1, 1, 1, 1, -30,
			-20, 0, 0, 0
		}, new short[14]
		{
			-80, -80, -80, -80, -40, 1, 1, 1, 1, -60,
			-40, 0, 0, 0
		}, new short[14]
		{
			0, -40, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -40, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -40, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-40, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 382, 381, 381, 381 }, 350));
		List<MerchantItem> dataArray7 = _dataArray;
		string config7 = LocalStringManager.GetConfig("Merchant_language", "UiName_6");
		List<PresetItemTemplateIdGroup> goods78 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 61, 1)
		};
		List<PresetItemTemplateIdGroup> goods79 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 68, 1)
		};
		List<PresetItemTemplateIdGroup> goods80 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 75, 1)
		};
		List<PresetItemTemplateIdGroup> goods81 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 82, 1)
		};
		List<PresetItemTemplateIdGroup> goods82 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 8, 1)
		};
		List<PresetItemTemplateIdGroup> goods83 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 17, 1),
			new PresetItemTemplateIdGroup("Food", 25, 1),
			new PresetItemTemplateIdGroup("Food", 32, 1),
			new PresetItemTemplateIdGroup("Food", 38, 1),
			new PresetItemTemplateIdGroup("Food", 43, 1),
			new PresetItemTemplateIdGroup("Food", 47, 1),
			new PresetItemTemplateIdGroup("Food", 50, 1)
		};
		List<PresetItemTemplateIdGroup> goods84 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 59, 1),
			new PresetItemTemplateIdGroup("Food", 67, 1),
			new PresetItemTemplateIdGroup("Food", 74, 1),
			new PresetItemTemplateIdGroup("Food", 80, 1),
			new PresetItemTemplateIdGroup("Food", 85, 1),
			new PresetItemTemplateIdGroup("Food", 89, 1),
			new PresetItemTemplateIdGroup("Food", 92, 1)
		};
		List<PresetItemTemplateIdGroup> goods85 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 101, 1),
			new PresetItemTemplateIdGroup("Food", 109, 1),
			new PresetItemTemplateIdGroup("Food", 116, 1),
			new PresetItemTemplateIdGroup("Food", 122, 1),
			new PresetItemTemplateIdGroup("Food", 127, 1),
			new PresetItemTemplateIdGroup("Food", 131, 1),
			new PresetItemTemplateIdGroup("Food", 134, 1)
		};
		List<PresetItemTemplateIdGroup> goods86 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 143, 1),
			new PresetItemTemplateIdGroup("Food", 151, 1),
			new PresetItemTemplateIdGroup("Food", 158, 1),
			new PresetItemTemplateIdGroup("Food", 164, 1),
			new PresetItemTemplateIdGroup("Food", 169, 1),
			new PresetItemTemplateIdGroup("Food", 173, 1),
			new PresetItemTemplateIdGroup("Food", 176, 1)
		};
		List<PresetItemTemplateIdGroup> goods87 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 25, 1)
		};
		List<PresetItemTemplateIdGroup> goods88 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 44, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods89 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray7.Add(new MerchantItem(6, 0, 0, 6, config7, 100, 1, 12, 20, 384000, goods78, goods79, goods80, goods81, goods82, goods83, goods84, goods85, goods86, goods87, goods88, goods89, goods12, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 26, 1)
		}, new sbyte[0], new sbyte[0], new short[14]
		{
			-40, -40, -40, -40, -10, 1, 1, 1, 1, -20,
			-10, 0, 0, -10
		}, new short[14]
		{
			-80, -80, -80, -80, -20, 1, 1, 1, 1, -40,
			-20, 0, 0, -10
		}, new short[14]
		{
			0, -40, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -40, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -40, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-40, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 383, 382, 382, 382 }, 355));
		List<MerchantItem> dataArray8 = _dataArray;
		string config8 = LocalStringManager.GetConfig("Merchant_language", "UiName_7");
		List<PresetItemTemplateIdGroup> goods90 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 0, 1),
			new PresetItemTemplateIdGroup("SkillBook", 1, 1),
			new PresetItemTemplateIdGroup("SkillBook", 2, 1),
			new PresetItemTemplateIdGroup("SkillBook", 9, 1),
			new PresetItemTemplateIdGroup("SkillBook", 10, 1),
			new PresetItemTemplateIdGroup("SkillBook", 11, 1),
			new PresetItemTemplateIdGroup("SkillBook", 18, 1),
			new PresetItemTemplateIdGroup("SkillBook", 19, 1),
			new PresetItemTemplateIdGroup("SkillBook", 20, 1),
			new PresetItemTemplateIdGroup("SkillBook", 27, 1),
			new PresetItemTemplateIdGroup("SkillBook", 28, 1),
			new PresetItemTemplateIdGroup("SkillBook", 29, 1)
		};
		List<PresetItemTemplateIdGroup> goods91 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 108, 1),
			new PresetItemTemplateIdGroup("SkillBook", 109, 1),
			new PresetItemTemplateIdGroup("SkillBook", 110, 1),
			new PresetItemTemplateIdGroup("SkillBook", 117, 1),
			new PresetItemTemplateIdGroup("SkillBook", 118, 1),
			new PresetItemTemplateIdGroup("SkillBook", 119, 1),
			new PresetItemTemplateIdGroup("SkillBook", 45, 1),
			new PresetItemTemplateIdGroup("SkillBook", 46, 1),
			new PresetItemTemplateIdGroup("SkillBook", 47, 1),
			new PresetItemTemplateIdGroup("SkillBook", 126, 1),
			new PresetItemTemplateIdGroup("SkillBook", 127, 1),
			new PresetItemTemplateIdGroup("SkillBook", 128, 1)
		};
		List<PresetItemTemplateIdGroup> goods92 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 72, 1),
			new PresetItemTemplateIdGroup("SkillBook", 73, 1),
			new PresetItemTemplateIdGroup("SkillBook", 74, 1),
			new PresetItemTemplateIdGroup("SkillBook", 81, 1),
			new PresetItemTemplateIdGroup("SkillBook", 82, 1),
			new PresetItemTemplateIdGroup("SkillBook", 83, 1),
			new PresetItemTemplateIdGroup("SkillBook", 36, 1),
			new PresetItemTemplateIdGroup("SkillBook", 37, 1),
			new PresetItemTemplateIdGroup("SkillBook", 38, 1),
			new PresetItemTemplateIdGroup("SkillBook", 135, 1),
			new PresetItemTemplateIdGroup("SkillBook", 136, 1),
			new PresetItemTemplateIdGroup("SkillBook", 137, 1)
		};
		List<PresetItemTemplateIdGroup> goods93 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 54, 1),
			new PresetItemTemplateIdGroup("SkillBook", 55, 1),
			new PresetItemTemplateIdGroup("SkillBook", 56, 1),
			new PresetItemTemplateIdGroup("SkillBook", 63, 1),
			new PresetItemTemplateIdGroup("SkillBook", 64, 1),
			new PresetItemTemplateIdGroup("SkillBook", 65, 1),
			new PresetItemTemplateIdGroup("SkillBook", 90, 1),
			new PresetItemTemplateIdGroup("SkillBook", 91, 1),
			new PresetItemTemplateIdGroup("SkillBook", 92, 1),
			new PresetItemTemplateIdGroup("SkillBook", 99, 1),
			new PresetItemTemplateIdGroup("SkillBook", 100, 1),
			new PresetItemTemplateIdGroup("SkillBook", 101, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods94 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods95 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods96 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods97 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods98 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods99 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods100 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods101 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods102 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray8.Add(new MerchantItem(7, 7, 1, 0, config8, 0, 1, 3, 20, 6000, goods90, goods91, goods92, goods93, goods94, goods95, goods96, goods97, goods98, goods99, goods100, goods101, goods102, goods12, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 0, 1, 2, 3 }, new short[14]
		{
			3, 3, 3, 3, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			2, 2, 2, 2, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			3, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 3, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 3, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 3, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 377, 376, 376, 376 }, 310));
		List<MerchantItem> dataArray9 = _dataArray;
		string config9 = LocalStringManager.GetConfig("Merchant_language", "UiName_8");
		List<PresetItemTemplateIdGroup> goods103 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 3, 1),
			new PresetItemTemplateIdGroup("SkillBook", 12, 1),
			new PresetItemTemplateIdGroup("SkillBook", 21, 1),
			new PresetItemTemplateIdGroup("SkillBook", 30, 1)
		};
		List<PresetItemTemplateIdGroup> goods104 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 111, 1),
			new PresetItemTemplateIdGroup("SkillBook", 120, 1),
			new PresetItemTemplateIdGroup("SkillBook", 129, 1),
			new PresetItemTemplateIdGroup("SkillBook", 48, 1)
		};
		List<PresetItemTemplateIdGroup> goods105 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 75, 1),
			new PresetItemTemplateIdGroup("SkillBook", 84, 1),
			new PresetItemTemplateIdGroup("SkillBook", 39, 1),
			new PresetItemTemplateIdGroup("SkillBook", 138, 1)
		};
		List<PresetItemTemplateIdGroup> goods106 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 57, 1),
			new PresetItemTemplateIdGroup("SkillBook", 66, 1),
			new PresetItemTemplateIdGroup("SkillBook", 93, 1),
			new PresetItemTemplateIdGroup("SkillBook", 102, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods107 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods108 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods109 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods110 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods111 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods112 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods113 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods114 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods115 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray9.Add(new MerchantItem(8, 7, 1, 1, config9, 20, 1, 3, 20, 12000, goods103, goods104, goods105, goods106, goods107, goods108, goods109, goods110, goods111, goods112, goods113, goods114, goods115, goods12, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 0, 1, 2, 3 }, new short[14]
		{
			1, 1, 1, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 1, 1, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 378, 377, 377, 377 }, 330));
		List<MerchantItem> dataArray10 = _dataArray;
		string config10 = LocalStringManager.GetConfig("Merchant_language", "UiName_9");
		List<PresetItemTemplateIdGroup> goods116 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 4, 1),
			new PresetItemTemplateIdGroup("SkillBook", 13, 1),
			new PresetItemTemplateIdGroup("SkillBook", 22, 1),
			new PresetItemTemplateIdGroup("SkillBook", 31, 1)
		};
		List<PresetItemTemplateIdGroup> goods117 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 112, 1),
			new PresetItemTemplateIdGroup("SkillBook", 121, 1),
			new PresetItemTemplateIdGroup("SkillBook", 49, 1),
			new PresetItemTemplateIdGroup("SkillBook", 130, 1)
		};
		List<PresetItemTemplateIdGroup> goods118 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 76, 1),
			new PresetItemTemplateIdGroup("SkillBook", 85, 1),
			new PresetItemTemplateIdGroup("SkillBook", 40, 1),
			new PresetItemTemplateIdGroup("SkillBook", 139, 1)
		};
		List<PresetItemTemplateIdGroup> goods119 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 58, 1),
			new PresetItemTemplateIdGroup("SkillBook", 67, 1),
			new PresetItemTemplateIdGroup("SkillBook", 94, 1),
			new PresetItemTemplateIdGroup("SkillBook", 103, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods120 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods121 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods122 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods123 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods124 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods125 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods126 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods127 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods128 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray10.Add(new MerchantItem(9, 7, 1, 2, config10, 40, 1, 6, 20, 24000, goods116, goods117, goods118, goods119, goods120, goods121, goods122, goods123, goods124, goods125, goods126, goods127, goods128, goods12, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 0, 1, 2, 3 }, new short[14]
		{
			1, 1, 1, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 1, 1, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 379, 378, 378, 378 }, 335));
		List<MerchantItem> dataArray11 = _dataArray;
		string config11 = LocalStringManager.GetConfig("Merchant_language", "UiName_10");
		List<PresetItemTemplateIdGroup> goods129 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 5, 1),
			new PresetItemTemplateIdGroup("SkillBook", 14, 1),
			new PresetItemTemplateIdGroup("SkillBook", 23, 1),
			new PresetItemTemplateIdGroup("SkillBook", 32, 1)
		};
		List<PresetItemTemplateIdGroup> goods130 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 113, 1),
			new PresetItemTemplateIdGroup("SkillBook", 122, 1),
			new PresetItemTemplateIdGroup("SkillBook", 50, 1),
			new PresetItemTemplateIdGroup("SkillBook", 131, 1)
		};
		List<PresetItemTemplateIdGroup> goods131 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 77, 1),
			new PresetItemTemplateIdGroup("SkillBook", 86, 1),
			new PresetItemTemplateIdGroup("SkillBook", 41, 1),
			new PresetItemTemplateIdGroup("SkillBook", 140, 1)
		};
		List<PresetItemTemplateIdGroup> goods132 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 59, 1),
			new PresetItemTemplateIdGroup("SkillBook", 68, 1),
			new PresetItemTemplateIdGroup("SkillBook", 95, 1),
			new PresetItemTemplateIdGroup("SkillBook", 104, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods133 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods134 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods135 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods136 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods137 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods138 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods139 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods140 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods141 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray11.Add(new MerchantItem(10, 7, 1, 3, config11, 60, 1, 6, 20, 48000, goods129, goods130, goods131, goods132, goods133, goods134, goods135, goods136, goods137, goods138, goods139, goods140, goods141, goods12, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 0, 1, 2, 3 }, new short[14]
		{
			1, 1, 1, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 1, 1, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 380, 379, 379, 379 }, 340));
		List<MerchantItem> dataArray12 = _dataArray;
		string config12 = LocalStringManager.GetConfig("Merchant_language", "UiName_11");
		List<PresetItemTemplateIdGroup> goods142 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 6, 1),
			new PresetItemTemplateIdGroup("SkillBook", 15, 1),
			new PresetItemTemplateIdGroup("SkillBook", 24, 1),
			new PresetItemTemplateIdGroup("SkillBook", 33, 1)
		};
		List<PresetItemTemplateIdGroup> goods143 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 114, 1),
			new PresetItemTemplateIdGroup("SkillBook", 123, 1),
			new PresetItemTemplateIdGroup("SkillBook", 51, 1),
			new PresetItemTemplateIdGroup("SkillBook", 132, 1)
		};
		List<PresetItemTemplateIdGroup> goods144 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 78, 1),
			new PresetItemTemplateIdGroup("SkillBook", 87, 1),
			new PresetItemTemplateIdGroup("SkillBook", 42, 1),
			new PresetItemTemplateIdGroup("SkillBook", 141, 1)
		};
		List<PresetItemTemplateIdGroup> goods145 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 60, 1),
			new PresetItemTemplateIdGroup("SkillBook", 69, 1),
			new PresetItemTemplateIdGroup("SkillBook", 96, 1),
			new PresetItemTemplateIdGroup("SkillBook", 105, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods146 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods147 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods148 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods149 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods150 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods151 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods152 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods153 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods154 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray12.Add(new MerchantItem(11, 7, 1, 4, config12, 80, 1, 9, 20, 96000, goods142, goods143, goods144, goods145, goods146, goods147, goods148, goods149, goods150, goods151, goods152, goods153, goods154, goods12, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 0, 1, 2, 3 }, new short[14]
		{
			-30, -30, -30, -30, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-60, -60, -60, -60, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-30, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -30, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, -30, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -30, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 381, 380, 380, 380 }, 345));
		List<MerchantItem> dataArray13 = _dataArray;
		string config13 = LocalStringManager.GetConfig("Merchant_language", "UiName_12");
		List<PresetItemTemplateIdGroup> goods155 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 7, 1),
			new PresetItemTemplateIdGroup("SkillBook", 16, 1),
			new PresetItemTemplateIdGroup("SkillBook", 25, 1),
			new PresetItemTemplateIdGroup("SkillBook", 34, 1)
		};
		List<PresetItemTemplateIdGroup> goods156 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 115, 1),
			new PresetItemTemplateIdGroup("SkillBook", 124, 1),
			new PresetItemTemplateIdGroup("SkillBook", 52, 1),
			new PresetItemTemplateIdGroup("SkillBook", 133, 1)
		};
		List<PresetItemTemplateIdGroup> goods157 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 79, 1),
			new PresetItemTemplateIdGroup("SkillBook", 88, 1),
			new PresetItemTemplateIdGroup("SkillBook", 43, 1),
			new PresetItemTemplateIdGroup("SkillBook", 142, 1)
		};
		List<PresetItemTemplateIdGroup> goods158 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 61, 1),
			new PresetItemTemplateIdGroup("SkillBook", 70, 1),
			new PresetItemTemplateIdGroup("SkillBook", 97, 1),
			new PresetItemTemplateIdGroup("SkillBook", 106, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods159 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods160 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods161 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods162 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods163 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods164 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods165 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods166 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods167 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray13.Add(new MerchantItem(12, 7, 1, 5, config13, 90, 1, 9, 20, 192000, goods155, goods156, goods157, goods158, goods159, goods160, goods161, goods162, goods163, goods164, goods165, goods166, goods167, goods12, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 0, 1, 2, 3 }, new short[14]
		{
			-20, -20, -20, -20, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-40, -40, -40, -40, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-20, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -20, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, -20, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -20, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 382, 381, 381, 381 }, 350));
		List<MerchantItem> dataArray14 = _dataArray;
		string config14 = LocalStringManager.GetConfig("Merchant_language", "UiName_13");
		List<PresetItemTemplateIdGroup> goods168 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 8, 1),
			new PresetItemTemplateIdGroup("SkillBook", 17, 1),
			new PresetItemTemplateIdGroup("SkillBook", 26, 1),
			new PresetItemTemplateIdGroup("SkillBook", 35, 1)
		};
		List<PresetItemTemplateIdGroup> goods169 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 116, 1),
			new PresetItemTemplateIdGroup("SkillBook", 125, 1),
			new PresetItemTemplateIdGroup("SkillBook", 134, 1),
			new PresetItemTemplateIdGroup("SkillBook", 53, 1)
		};
		List<PresetItemTemplateIdGroup> goods170 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 80, 1),
			new PresetItemTemplateIdGroup("SkillBook", 89, 1),
			new PresetItemTemplateIdGroup("SkillBook", 44, 1),
			new PresetItemTemplateIdGroup("SkillBook", 143, 1)
		};
		List<PresetItemTemplateIdGroup> goods171 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 62, 1),
			new PresetItemTemplateIdGroup("SkillBook", 71, 1),
			new PresetItemTemplateIdGroup("SkillBook", 98, 1),
			new PresetItemTemplateIdGroup("SkillBook", 107, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods172 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods173 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods174 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods175 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods176 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray14.Add(new MerchantItem(13, 7, 1, 6, config14, 100, 1, 12, 20, 384000, goods168, goods169, goods170, goods171, goods172, goods173, goods174, goods175, goods176, goods12, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 8, 1),
			new PresetItemTemplateIdGroup("SkillBook", 17, 1),
			new PresetItemTemplateIdGroup("SkillBook", 26, 1),
			new PresetItemTemplateIdGroup("SkillBook", 35, 1),
			new PresetItemTemplateIdGroup("SkillBook", 44, 1),
			new PresetItemTemplateIdGroup("SkillBook", 53, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 62, 1),
			new PresetItemTemplateIdGroup("SkillBook", 71, 1),
			new PresetItemTemplateIdGroup("SkillBook", 80, 1),
			new PresetItemTemplateIdGroup("SkillBook", 89, 1),
			new PresetItemTemplateIdGroup("SkillBook", 98, 1),
			new PresetItemTemplateIdGroup("SkillBook", 107, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 116, 1),
			new PresetItemTemplateIdGroup("SkillBook", 125, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("SkillBook", 134, 1),
			new PresetItemTemplateIdGroup("SkillBook", 143, 1)
		}, new sbyte[0], new sbyte[0], new short[14]
		{
			-10, -10, -10, -10, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-20, -20, -20, -20, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-10, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -10, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, -10, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -10, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 383, 382, 382, 382 }, 355));
		List<MerchantItem> dataArray15 = _dataArray;
		string config15 = LocalStringManager.GetConfig("Merchant_language", "UiName_14");
		List<PresetItemTemplateIdGroup> goods177 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 0, 3),
			new PresetItemTemplateIdGroup("Material", 7, 3)
		};
		List<PresetItemTemplateIdGroup> goods178 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 14, 3),
			new PresetItemTemplateIdGroup("Material", 21, 3)
		};
		List<PresetItemTemplateIdGroup> goods179 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 28, 3),
			new PresetItemTemplateIdGroup("Material", 35, 3)
		};
		List<PresetItemTemplateIdGroup> goods180 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 42, 3),
			new PresetItemTemplateIdGroup("Material", 49, 3)
		};
		List<PresetItemTemplateIdGroup> goods181 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 90, 1),
			new PresetItemTemplateIdGroup("Accessory", 91, 1)
		};
		List<PresetItemTemplateIdGroup> goods182 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 0, 3),
			new PresetItemTemplateIdGroup("TeaWine", 1, 3),
			new PresetItemTemplateIdGroup("TeaWine", 2, 3),
			new PresetItemTemplateIdGroup("TeaWine", 9, 3),
			new PresetItemTemplateIdGroup("TeaWine", 10, 3),
			new PresetItemTemplateIdGroup("TeaWine", 11, 3)
		};
		List<PresetItemTemplateIdGroup> goods183 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 18, 3),
			new PresetItemTemplateIdGroup("TeaWine", 19, 3),
			new PresetItemTemplateIdGroup("TeaWine", 20, 3),
			new PresetItemTemplateIdGroup("TeaWine", 27, 3),
			new PresetItemTemplateIdGroup("TeaWine", 28, 3),
			new PresetItemTemplateIdGroup("TeaWine", 29, 3)
		};
		List<PresetItemTemplateIdGroup> goods184 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 27, 1),
			new PresetItemTemplateIdGroup("CraftTool", 28, 1),
			new PresetItemTemplateIdGroup("CraftTool", 29, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods185 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods186 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods187 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods188 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray15.Add(new MerchantItem(14, 14, 2, 0, config15, 0, 1, 3, 20, 6000, goods177, goods178, goods179, goods180, goods181, goods182, goods183, goods184, goods185, goods186, goods187, goods188, goods12, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 82, 3),
			new PresetItemTemplateIdGroup("Misc", 83, 3)
		}, new sbyte[7] { 0, 1, 2, 3, 4, 7, 13 }, new sbyte[7] { 0, 1, 2, 3, 4, 7, 13 }, new short[14]
		{
			1, 1, 1, 1, 1, 2, 2, 1, 0, 0,
			0, 0, 0, 1
		}, new short[14]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
			0, 0, 0, 1
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 1, 0, 0, 0, 0, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 1, 0, 0, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 0, 0, 0, 0, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 377, 376, 376, 376 }, 310));
		List<MerchantItem> dataArray16 = _dataArray;
		string config16 = LocalStringManager.GetConfig("Merchant_language", "UiName_15");
		List<PresetItemTemplateIdGroup> goods189 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 1, 3),
			new PresetItemTemplateIdGroup("Material", 8, 3)
		};
		List<PresetItemTemplateIdGroup> goods190 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 15, 3),
			new PresetItemTemplateIdGroup("Material", 22, 3)
		};
		List<PresetItemTemplateIdGroup> goods191 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 29, 3),
			new PresetItemTemplateIdGroup("Material", 36, 3)
		};
		List<PresetItemTemplateIdGroup> goods192 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 43, 3),
			new PresetItemTemplateIdGroup("Material", 50, 3)
		};
		List<PresetItemTemplateIdGroup> goods193 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 92, 1)
		};
		List<PresetItemTemplateIdGroup> goods194 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 3, 2),
			new PresetItemTemplateIdGroup("TeaWine", 12, 2)
		};
		List<PresetItemTemplateIdGroup> goods195 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 21, 2),
			new PresetItemTemplateIdGroup("TeaWine", 30, 2)
		};
		List<PresetItemTemplateIdGroup> goods196 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 30, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods197 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods198 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods199 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods200 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray16.Add(new MerchantItem(15, 14, 2, 1, config16, 20, 1, 3, 20, 12000, goods189, goods190, goods191, goods192, goods193, goods194, goods195, goods196, goods197, goods198, goods199, goods200, goods12, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 84, 3)
		}, new sbyte[7] { 0, 1, 2, 3, 4, 7, 13 }, new sbyte[7] { 0, 1, 2, 3, 4, 7, 13 }, new short[14]
		{
			1, 1, 1, 1, 1, 2, 2, -60, 0, 0,
			0, 0, 0, 1
		}, new short[14]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
			0, 0, 0, 1
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 1, 0, 0, 0, 0, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 1, 0, 0, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 0, 0, 0, 0, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 378, 377, 377, 377 }, 330));
		List<MerchantItem> dataArray17 = _dataArray;
		string config17 = LocalStringManager.GetConfig("Merchant_language", "UiName_16");
		List<PresetItemTemplateIdGroup> goods201 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 2, 2),
			new PresetItemTemplateIdGroup("Material", 9, 2)
		};
		List<PresetItemTemplateIdGroup> goods202 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 16, 2),
			new PresetItemTemplateIdGroup("Material", 23, 2)
		};
		List<PresetItemTemplateIdGroup> goods203 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 30, 2),
			new PresetItemTemplateIdGroup("Material", 37, 2)
		};
		List<PresetItemTemplateIdGroup> goods204 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 44, 2),
			new PresetItemTemplateIdGroup("Material", 51, 2)
		};
		List<PresetItemTemplateIdGroup> goods205 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 93, 1)
		};
		List<PresetItemTemplateIdGroup> goods206 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 4, 2),
			new PresetItemTemplateIdGroup("TeaWine", 13, 2)
		};
		List<PresetItemTemplateIdGroup> goods207 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 22, 2),
			new PresetItemTemplateIdGroup("TeaWine", 31, 2)
		};
		List<PresetItemTemplateIdGroup> goods208 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 31, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods209 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods210 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods211 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods212 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray17.Add(new MerchantItem(16, 14, 2, 2, config17, 40, 1, 6, 20, 24000, goods201, goods202, goods203, goods204, goods205, goods206, goods207, goods208, goods209, goods210, goods211, goods212, goods12, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 85, 2)
		}, new sbyte[7] { 0, 1, 2, 3, 4, 7, 13 }, new sbyte[7] { 0, 1, 2, 3, 4, 7, 13 }, new short[14]
		{
			-60, -60, -60, -60, -60, -60, -60, -50, 0, 0,
			0, 0, 0, -60
		}, new short[14]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
			0, 0, 0, 1
		}, new short[14]
		{
			0, 0, 0, -60, 0, 0, -60, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, -60, 0, 0, 0, 0, -60, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -60, 0, 0, -60, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-60, 0, 0, 0, 0, -60, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 379, 378, 378, 378 }, 335));
		List<MerchantItem> dataArray18 = _dataArray;
		string config18 = LocalStringManager.GetConfig("Merchant_language", "UiName_17");
		List<PresetItemTemplateIdGroup> goods213 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 3, 2),
			new PresetItemTemplateIdGroup("Material", 10, 2)
		};
		List<PresetItemTemplateIdGroup> goods214 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 17, 2),
			new PresetItemTemplateIdGroup("Material", 24, 2)
		};
		List<PresetItemTemplateIdGroup> goods215 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 31, 2),
			new PresetItemTemplateIdGroup("Material", 38, 2)
		};
		List<PresetItemTemplateIdGroup> goods216 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 45, 2),
			new PresetItemTemplateIdGroup("Material", 52, 2)
		};
		List<PresetItemTemplateIdGroup> goods217 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 94, 1)
		};
		List<PresetItemTemplateIdGroup> goods218 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 5, 2),
			new PresetItemTemplateIdGroup("TeaWine", 14, 2)
		};
		List<PresetItemTemplateIdGroup> goods219 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 23, 2),
			new PresetItemTemplateIdGroup("TeaWine", 32, 2)
		};
		List<PresetItemTemplateIdGroup> goods220 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 32, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods221 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods222 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods223 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods224 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray18.Add(new MerchantItem(17, 14, 2, 3, config18, 60, 1, 6, 20, 48000, goods213, goods214, goods215, goods216, goods217, goods218, goods219, goods220, goods221, goods222, goods223, goods224, goods12, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 86, 2)
		}, new sbyte[7] { 0, 1, 2, 3, 4, 7, 13 }, new sbyte[7] { 0, 1, 2, 3, 4, 7, 13 }, new short[14]
		{
			-50, -50, -50, -50, -50, -50, -50, -40, 0, 0,
			0, 0, 0, -50
		}, new short[14]
		{
			1, 1, 1, 1, 1, 1, 1, -80, 0, 0,
			0, 0, 0, 1
		}, new short[14]
		{
			0, 0, 0, -50, 0, 0, -50, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, -50, 0, 0, 0, 0, -50, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -50, 0, 0, -50, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-50, 0, 0, 0, 0, -50, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 380, 379, 379, 379 }, 340));
		List<MerchantItem> dataArray19 = _dataArray;
		string config19 = LocalStringManager.GetConfig("Merchant_language", "UiName_18");
		List<PresetItemTemplateIdGroup> goods225 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 4, 2),
			new PresetItemTemplateIdGroup("Material", 11, 2)
		};
		List<PresetItemTemplateIdGroup> goods226 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 18, 2),
			new PresetItemTemplateIdGroup("Material", 25, 2)
		};
		List<PresetItemTemplateIdGroup> goods227 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 32, 2),
			new PresetItemTemplateIdGroup("Material", 39, 2)
		};
		List<PresetItemTemplateIdGroup> goods228 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 46, 2),
			new PresetItemTemplateIdGroup("Material", 53, 2)
		};
		List<PresetItemTemplateIdGroup> goods229 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 95, 1)
		};
		List<PresetItemTemplateIdGroup> goods230 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 6, 1),
			new PresetItemTemplateIdGroup("TeaWine", 15, 1)
		};
		List<PresetItemTemplateIdGroup> goods231 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 24, 1),
			new PresetItemTemplateIdGroup("TeaWine", 33, 1)
		};
		List<PresetItemTemplateIdGroup> goods232 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 33, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods233 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods234 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods235 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods236 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray19.Add(new MerchantItem(18, 14, 2, 4, config19, 80, 1, 9, 20, 96000, goods225, goods226, goods227, goods228, goods229, goods230, goods231, goods232, goods233, goods234, goods235, goods236, goods12, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 87, 2)
		}, new sbyte[7] { 0, 1, 2, 3, 4, 7, 13 }, new sbyte[7] { 0, 1, 2, 3, 4, 7, 13 }, new short[14]
		{
			-40, -40, -40, -40, -40, -40, -40, -30, 0, 0,
			0, 0, 0, -40
		}, new short[14]
		{
			-80, -80, -80, -80, -80, -80, -80, -60, 0, 0,
			0, 0, 0, -80
		}, new short[14]
		{
			0, 0, 0, -40, 0, 0, -40, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, -40, 0, 0, 0, 0, -40, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -40, 0, 0, -40, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-40, 0, 0, 0, 0, -40, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 381, 380, 380, 380 }, 345));
		List<MerchantItem> dataArray20 = _dataArray;
		string config20 = LocalStringManager.GetConfig("Merchant_language", "UiName_19");
		List<PresetItemTemplateIdGroup> goods237 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 5, 1),
			new PresetItemTemplateIdGroup("Material", 12, 1)
		};
		List<PresetItemTemplateIdGroup> goods238 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 19, 1),
			new PresetItemTemplateIdGroup("Material", 26, 1)
		};
		List<PresetItemTemplateIdGroup> goods239 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 33, 1),
			new PresetItemTemplateIdGroup("Material", 40, 1)
		};
		List<PresetItemTemplateIdGroup> goods240 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 47, 1),
			new PresetItemTemplateIdGroup("Material", 54, 1)
		};
		List<PresetItemTemplateIdGroup> goods241 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 96, 1)
		};
		List<PresetItemTemplateIdGroup> goods242 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 7, 1),
			new PresetItemTemplateIdGroup("TeaWine", 16, 1)
		};
		List<PresetItemTemplateIdGroup> goods243 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 25, 1),
			new PresetItemTemplateIdGroup("TeaWine", 34, 1)
		};
		List<PresetItemTemplateIdGroup> goods244 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 34, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods245 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods246 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods247 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods248 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray20.Add(new MerchantItem(19, 14, 2, 5, config20, 90, 1, 9, 20, 192000, goods237, goods238, goods239, goods240, goods241, goods242, goods243, goods244, goods245, goods246, goods247, goods248, goods12, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 88, 1)
		}, new sbyte[7] { 0, 1, 2, 3, 4, 7, 13 }, new sbyte[7] { 0, 1, 2, 3, 4, 7, 13 }, new short[14]
		{
			-30, -30, -30, -30, -30, -30, -30, -20, 0, 0,
			0, 0, 0, -30
		}, new short[14]
		{
			-60, -60, -60, -60, -60, -60, -60, -40, 0, 0,
			0, 0, 0, -60
		}, new short[14]
		{
			0, 0, 0, -30, 0, 0, -30, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, -30, 0, 0, 0, 0, -30, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -30, 0, 0, -30, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-30, 0, 0, 0, 0, -30, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 382, 381, 381, 381 }, 350));
		List<MerchantItem> dataArray21 = _dataArray;
		string config21 = LocalStringManager.GetConfig("Merchant_language", "UiName_20");
		List<PresetItemTemplateIdGroup> goods249 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 5, 1),
			new PresetItemTemplateIdGroup("Material", 12, 1)
		};
		List<PresetItemTemplateIdGroup> goods250 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 19, 1),
			new PresetItemTemplateIdGroup("Material", 26, 1)
		};
		List<PresetItemTemplateIdGroup> goods251 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 33, 1),
			new PresetItemTemplateIdGroup("Material", 40, 1)
		};
		List<PresetItemTemplateIdGroup> goods252 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 47, 1),
			new PresetItemTemplateIdGroup("Material", 54, 1)
		};
		List<PresetItemTemplateIdGroup> goods253 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 97, 1)
		};
		List<PresetItemTemplateIdGroup> goods254 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 8, 1),
			new PresetItemTemplateIdGroup("TeaWine", 17, 1)
		};
		List<PresetItemTemplateIdGroup> goods255 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("TeaWine", 26, 1),
			new PresetItemTemplateIdGroup("TeaWine", 35, 1)
		};
		List<PresetItemTemplateIdGroup> goods256 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 35, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods257 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods258 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods259 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods260 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray21.Add(new MerchantItem(20, 14, 2, 6, config21, 100, 1, 12, 20, 384000, goods249, goods250, goods251, goods252, goods253, goods254, goods255, goods256, goods257, goods258, goods259, goods260, goods12, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 89, 1)
		}, new sbyte[0], new sbyte[0], new short[14]
		{
			-30, -30, -30, -30, -20, -20, -20, -10, 0, 0,
			0, 0, 0, -20
		}, new short[14]
		{
			-60, -60, -60, -60, -60, -60, -60, -20, 0, 0,
			0, 0, 0, -40
		}, new short[14]
		{
			0, 0, 0, -30, 0, 0, -20, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, -30, 0, 0, 0, 0, -20, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -30, 0, 0, -20, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-30, 0, 0, 0, 0, -20, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 383, 382, 382, 382 }, 355));
		_dataArray.Add(new MerchantItem(21, 21, 3, 0, LocalStringManager.GetConfig("Merchant_language", "UiName_21"), 0, 1, 3, 20, 6000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 111, 1),
			new PresetItemTemplateIdGroup("Weapon", 112, 1),
			new PresetItemTemplateIdGroup("Weapon", 120, 1),
			new PresetItemTemplateIdGroup("Weapon", 121, 1),
			new PresetItemTemplateIdGroup("Weapon", 129, 1),
			new PresetItemTemplateIdGroup("Weapon", 130, 1),
			new PresetItemTemplateIdGroup("Weapon", 138, 1),
			new PresetItemTemplateIdGroup("Weapon", 139, 1),
			new PresetItemTemplateIdGroup("Weapon", 147, 1),
			new PresetItemTemplateIdGroup("Weapon", 148, 1),
			new PresetItemTemplateIdGroup("Weapon", 156, 1),
			new PresetItemTemplateIdGroup("Weapon", 157, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 165, 1),
			new PresetItemTemplateIdGroup("Weapon", 166, 1),
			new PresetItemTemplateIdGroup("Weapon", 174, 1),
			new PresetItemTemplateIdGroup("Weapon", 175, 1),
			new PresetItemTemplateIdGroup("Weapon", 183, 1),
			new PresetItemTemplateIdGroup("Weapon", 184, 1),
			new PresetItemTemplateIdGroup("Weapon", 192, 1),
			new PresetItemTemplateIdGroup("Weapon", 193, 1),
			new PresetItemTemplateIdGroup("Weapon", 201, 1),
			new PresetItemTemplateIdGroup("Weapon", 202, 1),
			new PresetItemTemplateIdGroup("Weapon", 210, 1),
			new PresetItemTemplateIdGroup("Weapon", 211, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 273, 1),
			new PresetItemTemplateIdGroup("Weapon", 274, 1),
			new PresetItemTemplateIdGroup("Weapon", 282, 1),
			new PresetItemTemplateIdGroup("Weapon", 283, 1),
			new PresetItemTemplateIdGroup("Weapon", 291, 1),
			new PresetItemTemplateIdGroup("Weapon", 292, 1),
			new PresetItemTemplateIdGroup("Weapon", 300, 1),
			new PresetItemTemplateIdGroup("Weapon", 301, 1),
			new PresetItemTemplateIdGroup("Weapon", 309, 1),
			new PresetItemTemplateIdGroup("Weapon", 310, 1),
			new PresetItemTemplateIdGroup("Weapon", 318, 1),
			new PresetItemTemplateIdGroup("Weapon", 319, 1),
			new PresetItemTemplateIdGroup("Weapon", 327, 1),
			new PresetItemTemplateIdGroup("Weapon", 328, 1),
			new PresetItemTemplateIdGroup("Weapon", 336, 1),
			new PresetItemTemplateIdGroup("Weapon", 337, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 381, 1),
			new PresetItemTemplateIdGroup("Weapon", 382, 1),
			new PresetItemTemplateIdGroup("Weapon", 390, 1),
			new PresetItemTemplateIdGroup("Weapon", 391, 1),
			new PresetItemTemplateIdGroup("Weapon", 399, 1),
			new PresetItemTemplateIdGroup("Weapon", 400, 1),
			new PresetItemTemplateIdGroup("Weapon", 408, 1),
			new PresetItemTemplateIdGroup("Weapon", 409, 1),
			new PresetItemTemplateIdGroup("Weapon", 417, 1),
			new PresetItemTemplateIdGroup("Weapon", 418, 1),
			new PresetItemTemplateIdGroup("Weapon", 426, 1),
			new PresetItemTemplateIdGroup("Weapon", 427, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 435, 1),
			new PresetItemTemplateIdGroup("Weapon", 436, 1),
			new PresetItemTemplateIdGroup("Weapon", 444, 1),
			new PresetItemTemplateIdGroup("Weapon", 445, 1),
			new PresetItemTemplateIdGroup("Weapon", 453, 1),
			new PresetItemTemplateIdGroup("Weapon", 454, 1),
			new PresetItemTemplateIdGroup("Weapon", 462, 1),
			new PresetItemTemplateIdGroup("Weapon", 463, 1),
			new PresetItemTemplateIdGroup("Weapon", 471, 1),
			new PresetItemTemplateIdGroup("Weapon", 472, 1),
			new PresetItemTemplateIdGroup("Weapon", 480, 1),
			new PresetItemTemplateIdGroup("Weapon", 481, 1),
			new PresetItemTemplateIdGroup("Weapon", 489, 1),
			new PresetItemTemplateIdGroup("Weapon", 490, 1),
			new PresetItemTemplateIdGroup("Weapon", 498, 1),
			new PresetItemTemplateIdGroup("Weapon", 499, 1),
			new PresetItemTemplateIdGroup("Weapon", 507, 1),
			new PresetItemTemplateIdGroup("Weapon", 508, 1),
			new PresetItemTemplateIdGroup("Weapon", 516, 1),
			new PresetItemTemplateIdGroup("Weapon", 517, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 525, 1),
			new PresetItemTemplateIdGroup("Weapon", 526, 1),
			new PresetItemTemplateIdGroup("Weapon", 534, 1),
			new PresetItemTemplateIdGroup("Weapon", 535, 1),
			new PresetItemTemplateIdGroup("Weapon", 543, 1),
			new PresetItemTemplateIdGroup("Weapon", 544, 1),
			new PresetItemTemplateIdGroup("Weapon", 552, 1),
			new PresetItemTemplateIdGroup("Weapon", 553, 1),
			new PresetItemTemplateIdGroup("Weapon", 561, 1),
			new PresetItemTemplateIdGroup("Weapon", 562, 1),
			new PresetItemTemplateIdGroup("Weapon", 570, 1),
			new PresetItemTemplateIdGroup("Weapon", 571, 1),
			new PresetItemTemplateIdGroup("Weapon", 579, 1),
			new PresetItemTemplateIdGroup("Weapon", 580, 1),
			new PresetItemTemplateIdGroup("Weapon", 588, 1),
			new PresetItemTemplateIdGroup("Weapon", 589, 1),
			new PresetItemTemplateIdGroup("Weapon", 597, 1),
			new PresetItemTemplateIdGroup("Weapon", 598, 1),
			new PresetItemTemplateIdGroup("Weapon", 606, 1),
			new PresetItemTemplateIdGroup("Weapon", 607, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 615, 1),
			new PresetItemTemplateIdGroup("Weapon", 616, 1),
			new PresetItemTemplateIdGroup("Weapon", 624, 1),
			new PresetItemTemplateIdGroup("Weapon", 625, 1),
			new PresetItemTemplateIdGroup("Weapon", 633, 1),
			new PresetItemTemplateIdGroup("Weapon", 634, 1),
			new PresetItemTemplateIdGroup("Weapon", 642, 1),
			new PresetItemTemplateIdGroup("Weapon", 643, 1),
			new PresetItemTemplateIdGroup("Weapon", 651, 1),
			new PresetItemTemplateIdGroup("Weapon", 652, 1),
			new PresetItemTemplateIdGroup("Weapon", 660, 1),
			new PresetItemTemplateIdGroup("Weapon", 661, 1),
			new PresetItemTemplateIdGroup("Weapon", 669, 1),
			new PresetItemTemplateIdGroup("Weapon", 670, 1),
			new PresetItemTemplateIdGroup("Weapon", 678, 1),
			new PresetItemTemplateIdGroup("Weapon", 679, 1),
			new PresetItemTemplateIdGroup("Weapon", 687, 1),
			new PresetItemTemplateIdGroup("Weapon", 688, 1),
			new PresetItemTemplateIdGroup("Weapon", 696, 1),
			new PresetItemTemplateIdGroup("Weapon", 697, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 795, 1),
			new PresetItemTemplateIdGroup("Weapon", 796, 1),
			new PresetItemTemplateIdGroup("Weapon", 804, 1),
			new PresetItemTemplateIdGroup("Weapon", 805, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 0, 1),
			new PresetItemTemplateIdGroup("Armor", 1, 1),
			new PresetItemTemplateIdGroup("Armor", 9, 1),
			new PresetItemTemplateIdGroup("Armor", 10, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 126, 1),
			new PresetItemTemplateIdGroup("Armor", 127, 1),
			new PresetItemTemplateIdGroup("Armor", 135, 1),
			new PresetItemTemplateIdGroup("Armor", 136, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 252, 1),
			new PresetItemTemplateIdGroup("Armor", 253, 1),
			new PresetItemTemplateIdGroup("Armor", 261, 1),
			new PresetItemTemplateIdGroup("Armor", 262, 1),
			new PresetItemTemplateIdGroup("Armor", 270, 1),
			new PresetItemTemplateIdGroup("Armor", 271, 1),
			new PresetItemTemplateIdGroup("Armor", 279, 1),
			new PresetItemTemplateIdGroup("Armor", 280, 1),
			new PresetItemTemplateIdGroup("Armor", 288, 1),
			new PresetItemTemplateIdGroup("Armor", 289, 1),
			new PresetItemTemplateIdGroup("Armor", 297, 1),
			new PresetItemTemplateIdGroup("Armor", 298, 1),
			new PresetItemTemplateIdGroup("Armor", 378, 1),
			new PresetItemTemplateIdGroup("Armor", 379, 1),
			new PresetItemTemplateIdGroup("Armor", 387, 1),
			new PresetItemTemplateIdGroup("Armor", 388, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 396, 1),
			new PresetItemTemplateIdGroup("Armor", 397, 1),
			new PresetItemTemplateIdGroup("Armor", 405, 1),
			new PresetItemTemplateIdGroup("Armor", 406, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 0, 1),
			new PresetItemTemplateIdGroup("Accessory", 1, 1),
			new PresetItemTemplateIdGroup("Accessory", 9, 1),
			new PresetItemTemplateIdGroup("Accessory", 10, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 9, 1),
			new PresetItemTemplateIdGroup("CraftTool", 10, 1),
			new PresetItemTemplateIdGroup("CraftTool", 11, 1),
			new PresetItemTemplateIdGroup("CraftTool", 18, 1),
			new PresetItemTemplateIdGroup("CraftTool", 19, 1),
			new PresetItemTemplateIdGroup("CraftTool", 20, 1),
			new PresetItemTemplateIdGroup("CraftTool", 0, 1),
			new PresetItemTemplateIdGroup("CraftTool", 1, 1),
			new PresetItemTemplateIdGroup("CraftTool", 2, 1)
		}, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, new short[14]
		{
			3, 3, 4, 3, 5, 5, 5, 1, 1, 1,
			4, 1, 1, 3
		}, new short[14]
		{
			2, 2, 2, 2, 3, 3, 3, 1, 1, 1,
			2, 1, 1, 2
		}, new short[14]
		{
			3, 0, 4, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 3, 0, 0, 5, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 3, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 5, 5, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 377, 376, 376, 376 }, 310));
		List<MerchantItem> dataArray22 = _dataArray;
		string config22 = LocalStringManager.GetConfig("Merchant_language", "UiName_22");
		List<PresetItemTemplateIdGroup> goods261 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 113, 1),
			new PresetItemTemplateIdGroup("Weapon", 122, 1),
			new PresetItemTemplateIdGroup("Weapon", 131, 1),
			new PresetItemTemplateIdGroup("Weapon", 140, 1),
			new PresetItemTemplateIdGroup("Weapon", 149, 1),
			new PresetItemTemplateIdGroup("Weapon", 158, 1)
		};
		List<PresetItemTemplateIdGroup> goods262 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 167, 1),
			new PresetItemTemplateIdGroup("Weapon", 176, 1),
			new PresetItemTemplateIdGroup("Weapon", 185, 1),
			new PresetItemTemplateIdGroup("Weapon", 194, 1),
			new PresetItemTemplateIdGroup("Weapon", 203, 1),
			new PresetItemTemplateIdGroup("Weapon", 212, 1)
		};
		List<PresetItemTemplateIdGroup> goods263 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 275, 1),
			new PresetItemTemplateIdGroup("Weapon", 284, 1),
			new PresetItemTemplateIdGroup("Weapon", 293, 1),
			new PresetItemTemplateIdGroup("Weapon", 302, 1),
			new PresetItemTemplateIdGroup("Weapon", 311, 1),
			new PresetItemTemplateIdGroup("Weapon", 320, 1),
			new PresetItemTemplateIdGroup("Weapon", 329, 1),
			new PresetItemTemplateIdGroup("Weapon", 338, 1)
		};
		List<PresetItemTemplateIdGroup> goods264 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 383, 1),
			new PresetItemTemplateIdGroup("Weapon", 392, 1),
			new PresetItemTemplateIdGroup("Weapon", 401, 1),
			new PresetItemTemplateIdGroup("Weapon", 410, 1),
			new PresetItemTemplateIdGroup("Weapon", 419, 1),
			new PresetItemTemplateIdGroup("Weapon", 428, 1)
		};
		List<PresetItemTemplateIdGroup> goods265 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 437, 1),
			new PresetItemTemplateIdGroup("Weapon", 446, 1),
			new PresetItemTemplateIdGroup("Weapon", 455, 1),
			new PresetItemTemplateIdGroup("Weapon", 464, 1),
			new PresetItemTemplateIdGroup("Weapon", 473, 1),
			new PresetItemTemplateIdGroup("Weapon", 482, 1),
			new PresetItemTemplateIdGroup("Weapon", 491, 1),
			new PresetItemTemplateIdGroup("Weapon", 500, 1),
			new PresetItemTemplateIdGroup("Weapon", 509, 1),
			new PresetItemTemplateIdGroup("Weapon", 518, 1)
		};
		List<PresetItemTemplateIdGroup> goods266 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 527, 1),
			new PresetItemTemplateIdGroup("Weapon", 536, 1),
			new PresetItemTemplateIdGroup("Weapon", 545, 1),
			new PresetItemTemplateIdGroup("Weapon", 554, 1),
			new PresetItemTemplateIdGroup("Weapon", 563, 1),
			new PresetItemTemplateIdGroup("Weapon", 572, 1),
			new PresetItemTemplateIdGroup("Weapon", 581, 1),
			new PresetItemTemplateIdGroup("Weapon", 590, 1),
			new PresetItemTemplateIdGroup("Weapon", 599, 1),
			new PresetItemTemplateIdGroup("Weapon", 608, 1)
		};
		List<PresetItemTemplateIdGroup> goods267 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 617, 1),
			new PresetItemTemplateIdGroup("Weapon", 626, 1),
			new PresetItemTemplateIdGroup("Weapon", 635, 1),
			new PresetItemTemplateIdGroup("Weapon", 644, 1),
			new PresetItemTemplateIdGroup("Weapon", 653, 1),
			new PresetItemTemplateIdGroup("Weapon", 662, 1),
			new PresetItemTemplateIdGroup("Weapon", 671, 1),
			new PresetItemTemplateIdGroup("Weapon", 680, 1),
			new PresetItemTemplateIdGroup("Weapon", 689, 1),
			new PresetItemTemplateIdGroup("Weapon", 698, 1)
		};
		List<PresetItemTemplateIdGroup> goods268 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 797, 1),
			new PresetItemTemplateIdGroup("Weapon", 806, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray22.Add(new MerchantItem(22, 21, 3, 1, config22, 20, 1, 3, 20, 12000, goods261, goods262, goods263, goods264, goods265, goods266, goods267, goods268, goods12, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 128, 1),
			new PresetItemTemplateIdGroup("Armor", 137, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 254, 1),
			new PresetItemTemplateIdGroup("Armor", 263, 1),
			new PresetItemTemplateIdGroup("Armor", 272, 1),
			new PresetItemTemplateIdGroup("Armor", 281, 1),
			new PresetItemTemplateIdGroup("Armor", 290, 1),
			new PresetItemTemplateIdGroup("Armor", 299, 1),
			new PresetItemTemplateIdGroup("Armor", 380, 1),
			new PresetItemTemplateIdGroup("Armor", 389, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 398, 1),
			new PresetItemTemplateIdGroup("Armor", 407, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 2, 1),
			new PresetItemTemplateIdGroup("Accessory", 11, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 12, 1),
			new PresetItemTemplateIdGroup("CraftTool", 21, 1),
			new PresetItemTemplateIdGroup("CraftTool", 3, 1)
		}, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, new short[14]
		{
			2, 2, 2, 2, 3, 3, 3, 1, 1, 1,
			2, 1, 1, 1
		}, new short[14]
		{
			1, 1, 1, 1, 2, 2, 2, 1, 1, 1,
			1, 1, 1, 1
		}, new short[14]
		{
			2, 0, 2, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 2, 0, 0, 3, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 2, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 3, 3, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 378, 377, 377, 377 }, 330));
		_dataArray.Add(new MerchantItem(23, 21, 3, 2, LocalStringManager.GetConfig("Merchant_language", "UiName_23"), 40, 1, 6, 20, 24000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 114, 1),
			new PresetItemTemplateIdGroup("Weapon", 123, 1),
			new PresetItemTemplateIdGroup("Weapon", 132, 1),
			new PresetItemTemplateIdGroup("Weapon", 141, 1),
			new PresetItemTemplateIdGroup("Weapon", 150, 1),
			new PresetItemTemplateIdGroup("Weapon", 159, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 168, 1),
			new PresetItemTemplateIdGroup("Weapon", 177, 1),
			new PresetItemTemplateIdGroup("Weapon", 186, 1),
			new PresetItemTemplateIdGroup("Weapon", 195, 1),
			new PresetItemTemplateIdGroup("Weapon", 204, 1),
			new PresetItemTemplateIdGroup("Weapon", 213, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 276, 1),
			new PresetItemTemplateIdGroup("Weapon", 285, 1),
			new PresetItemTemplateIdGroup("Weapon", 294, 1),
			new PresetItemTemplateIdGroup("Weapon", 303, 1),
			new PresetItemTemplateIdGroup("Weapon", 312, 1),
			new PresetItemTemplateIdGroup("Weapon", 321, 1),
			new PresetItemTemplateIdGroup("Weapon", 330, 1),
			new PresetItemTemplateIdGroup("Weapon", 339, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 384, 1),
			new PresetItemTemplateIdGroup("Weapon", 393, 1),
			new PresetItemTemplateIdGroup("Weapon", 402, 1),
			new PresetItemTemplateIdGroup("Weapon", 411, 1),
			new PresetItemTemplateIdGroup("Weapon", 420, 1),
			new PresetItemTemplateIdGroup("Weapon", 429, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 438, 1),
			new PresetItemTemplateIdGroup("Weapon", 447, 1),
			new PresetItemTemplateIdGroup("Weapon", 456, 1),
			new PresetItemTemplateIdGroup("Weapon", 465, 1),
			new PresetItemTemplateIdGroup("Weapon", 474, 1),
			new PresetItemTemplateIdGroup("Weapon", 483, 1),
			new PresetItemTemplateIdGroup("Weapon", 492, 1),
			new PresetItemTemplateIdGroup("Weapon", 501, 1),
			new PresetItemTemplateIdGroup("Weapon", 510, 1),
			new PresetItemTemplateIdGroup("Weapon", 519, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 528, 1),
			new PresetItemTemplateIdGroup("Weapon", 537, 1),
			new PresetItemTemplateIdGroup("Weapon", 546, 1),
			new PresetItemTemplateIdGroup("Weapon", 555, 1),
			new PresetItemTemplateIdGroup("Weapon", 564, 1),
			new PresetItemTemplateIdGroup("Weapon", 573, 1),
			new PresetItemTemplateIdGroup("Weapon", 582, 1),
			new PresetItemTemplateIdGroup("Weapon", 591, 1),
			new PresetItemTemplateIdGroup("Weapon", 600, 1),
			new PresetItemTemplateIdGroup("Weapon", 609, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 618, 1),
			new PresetItemTemplateIdGroup("Weapon", 627, 1),
			new PresetItemTemplateIdGroup("Weapon", 636, 1),
			new PresetItemTemplateIdGroup("Weapon", 645, 1),
			new PresetItemTemplateIdGroup("Weapon", 654, 1),
			new PresetItemTemplateIdGroup("Weapon", 663, 1),
			new PresetItemTemplateIdGroup("Weapon", 672, 1),
			new PresetItemTemplateIdGroup("Weapon", 681, 1),
			new PresetItemTemplateIdGroup("Weapon", 690, 1),
			new PresetItemTemplateIdGroup("Weapon", 699, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 798, 1),
			new PresetItemTemplateIdGroup("Weapon", 807, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 3, 1),
			new PresetItemTemplateIdGroup("Armor", 12, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 129, 1),
			new PresetItemTemplateIdGroup("Armor", 138, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 255, 1),
			new PresetItemTemplateIdGroup("Armor", 264, 1),
			new PresetItemTemplateIdGroup("Armor", 273, 1),
			new PresetItemTemplateIdGroup("Armor", 282, 1),
			new PresetItemTemplateIdGroup("Armor", 291, 1),
			new PresetItemTemplateIdGroup("Armor", 300, 1),
			new PresetItemTemplateIdGroup("Armor", 381, 1),
			new PresetItemTemplateIdGroup("Armor", 390, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 399, 1),
			new PresetItemTemplateIdGroup("Armor", 408, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 3, 1),
			new PresetItemTemplateIdGroup("Accessory", 12, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 13, 1),
			new PresetItemTemplateIdGroup("CraftTool", 22, 1),
			new PresetItemTemplateIdGroup("CraftTool", 4, 1)
		}, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, new short[14]
		{
			1, 1, 2, 1, 2, 2, 2, -60, -60, -60,
			2, -60, -60, 1
		}, new short[14]
		{
			1, 1, 2, 1, 2, 2, 2, 1, 1, 1,
			2, 1, 1, 1
		}, new short[14]
		{
			1, 0, 2, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 1, 0, 0, 0, 0, 0, -60, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 2, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 379, 378, 378, 378 }, 335));
		_dataArray.Add(new MerchantItem(24, 21, 3, 3, LocalStringManager.GetConfig("Merchant_language", "UiName_24"), 60, 1, 6, 20, 48000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 115, 1),
			new PresetItemTemplateIdGroup("Weapon", 124, 1),
			new PresetItemTemplateIdGroup("Weapon", 133, 1),
			new PresetItemTemplateIdGroup("Weapon", 142, 1),
			new PresetItemTemplateIdGroup("Weapon", 151, 1),
			new PresetItemTemplateIdGroup("Weapon", 160, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 169, 1),
			new PresetItemTemplateIdGroup("Weapon", 178, 1),
			new PresetItemTemplateIdGroup("Weapon", 187, 1),
			new PresetItemTemplateIdGroup("Weapon", 196, 1),
			new PresetItemTemplateIdGroup("Weapon", 205, 1),
			new PresetItemTemplateIdGroup("Weapon", 214, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 277, 1),
			new PresetItemTemplateIdGroup("Weapon", 286, 1),
			new PresetItemTemplateIdGroup("Weapon", 295, 1),
			new PresetItemTemplateIdGroup("Weapon", 304, 1),
			new PresetItemTemplateIdGroup("Weapon", 313, 1),
			new PresetItemTemplateIdGroup("Weapon", 322, 1),
			new PresetItemTemplateIdGroup("Weapon", 331, 1),
			new PresetItemTemplateIdGroup("Weapon", 340, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 385, 1),
			new PresetItemTemplateIdGroup("Weapon", 394, 1),
			new PresetItemTemplateIdGroup("Weapon", 403, 1),
			new PresetItemTemplateIdGroup("Weapon", 412, 1),
			new PresetItemTemplateIdGroup("Weapon", 421, 1),
			new PresetItemTemplateIdGroup("Weapon", 430, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 439, 1),
			new PresetItemTemplateIdGroup("Weapon", 448, 1),
			new PresetItemTemplateIdGroup("Weapon", 457, 1),
			new PresetItemTemplateIdGroup("Weapon", 466, 1),
			new PresetItemTemplateIdGroup("Weapon", 475, 1),
			new PresetItemTemplateIdGroup("Weapon", 484, 1),
			new PresetItemTemplateIdGroup("Weapon", 493, 1),
			new PresetItemTemplateIdGroup("Weapon", 502, 1),
			new PresetItemTemplateIdGroup("Weapon", 511, 1),
			new PresetItemTemplateIdGroup("Weapon", 520, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 529, 1),
			new PresetItemTemplateIdGroup("Weapon", 538, 1),
			new PresetItemTemplateIdGroup("Weapon", 547, 1),
			new PresetItemTemplateIdGroup("Weapon", 556, 1),
			new PresetItemTemplateIdGroup("Weapon", 565, 1),
			new PresetItemTemplateIdGroup("Weapon", 574, 1),
			new PresetItemTemplateIdGroup("Weapon", 583, 1),
			new PresetItemTemplateIdGroup("Weapon", 592, 1),
			new PresetItemTemplateIdGroup("Weapon", 601, 1),
			new PresetItemTemplateIdGroup("Weapon", 610, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 619, 1),
			new PresetItemTemplateIdGroup("Weapon", 628, 1),
			new PresetItemTemplateIdGroup("Weapon", 637, 1),
			new PresetItemTemplateIdGroup("Weapon", 646, 1),
			new PresetItemTemplateIdGroup("Weapon", 655, 1),
			new PresetItemTemplateIdGroup("Weapon", 664, 1),
			new PresetItemTemplateIdGroup("Weapon", 673, 1),
			new PresetItemTemplateIdGroup("Weapon", 682, 1),
			new PresetItemTemplateIdGroup("Weapon", 691, 1),
			new PresetItemTemplateIdGroup("Weapon", 700, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 799, 1),
			new PresetItemTemplateIdGroup("Weapon", 808, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 4, 1),
			new PresetItemTemplateIdGroup("Armor", 13, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 130, 1),
			new PresetItemTemplateIdGroup("Armor", 139, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 256, 1),
			new PresetItemTemplateIdGroup("Armor", 265, 1),
			new PresetItemTemplateIdGroup("Armor", 274, 1),
			new PresetItemTemplateIdGroup("Armor", 283, 1),
			new PresetItemTemplateIdGroup("Armor", 292, 1),
			new PresetItemTemplateIdGroup("Armor", 301, 1),
			new PresetItemTemplateIdGroup("Armor", 382, 1),
			new PresetItemTemplateIdGroup("Armor", 391, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 400, 1),
			new PresetItemTemplateIdGroup("Armor", 409, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 4, 1),
			new PresetItemTemplateIdGroup("Accessory", 13, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 14, 1),
			new PresetItemTemplateIdGroup("CraftTool", 23, 1),
			new PresetItemTemplateIdGroup("CraftTool", 5, 1)
		}, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, new short[14]
		{
			1, 1, 2, 1, 2, 2, 2, -50, -50, -50,
			2, -50, -50, 1
		}, new short[14]
		{
			1, 1, 2, 1, 2, 2, 2, 1, 1, 1,
			2, 1, 1, 1
		}, new short[14]
		{
			1, 0, 2, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 1, 0, 0, 0, 0, 0, -50, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 2, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 380, 379, 379, 379 }, 340));
		_dataArray.Add(new MerchantItem(25, 21, 3, 4, LocalStringManager.GetConfig("Merchant_language", "UiName_25"), 80, 1, 9, 20, 96000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 116, 1),
			new PresetItemTemplateIdGroup("Weapon", 125, 1),
			new PresetItemTemplateIdGroup("Weapon", 134, 1),
			new PresetItemTemplateIdGroup("Weapon", 143, 1),
			new PresetItemTemplateIdGroup("Weapon", 152, 1),
			new PresetItemTemplateIdGroup("Weapon", 161, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 170, 1),
			new PresetItemTemplateIdGroup("Weapon", 179, 1),
			new PresetItemTemplateIdGroup("Weapon", 188, 1),
			new PresetItemTemplateIdGroup("Weapon", 197, 1),
			new PresetItemTemplateIdGroup("Weapon", 206, 1),
			new PresetItemTemplateIdGroup("Weapon", 215, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 278, 1),
			new PresetItemTemplateIdGroup("Weapon", 287, 1),
			new PresetItemTemplateIdGroup("Weapon", 296, 1),
			new PresetItemTemplateIdGroup("Weapon", 305, 1),
			new PresetItemTemplateIdGroup("Weapon", 314, 1),
			new PresetItemTemplateIdGroup("Weapon", 323, 1),
			new PresetItemTemplateIdGroup("Weapon", 332, 1),
			new PresetItemTemplateIdGroup("Weapon", 341, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 386, 1),
			new PresetItemTemplateIdGroup("Weapon", 395, 1),
			new PresetItemTemplateIdGroup("Weapon", 404, 1),
			new PresetItemTemplateIdGroup("Weapon", 413, 1),
			new PresetItemTemplateIdGroup("Weapon", 422, 1),
			new PresetItemTemplateIdGroup("Weapon", 431, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 440, 1),
			new PresetItemTemplateIdGroup("Weapon", 449, 1),
			new PresetItemTemplateIdGroup("Weapon", 458, 1),
			new PresetItemTemplateIdGroup("Weapon", 467, 1),
			new PresetItemTemplateIdGroup("Weapon", 476, 1),
			new PresetItemTemplateIdGroup("Weapon", 485, 1),
			new PresetItemTemplateIdGroup("Weapon", 494, 1),
			new PresetItemTemplateIdGroup("Weapon", 503, 1),
			new PresetItemTemplateIdGroup("Weapon", 512, 1),
			new PresetItemTemplateIdGroup("Weapon", 521, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 530, 1),
			new PresetItemTemplateIdGroup("Weapon", 539, 1),
			new PresetItemTemplateIdGroup("Weapon", 548, 1),
			new PresetItemTemplateIdGroup("Weapon", 557, 1),
			new PresetItemTemplateIdGroup("Weapon", 566, 1),
			new PresetItemTemplateIdGroup("Weapon", 575, 1),
			new PresetItemTemplateIdGroup("Weapon", 584, 1),
			new PresetItemTemplateIdGroup("Weapon", 593, 1),
			new PresetItemTemplateIdGroup("Weapon", 602, 1),
			new PresetItemTemplateIdGroup("Weapon", 611, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 620, 1),
			new PresetItemTemplateIdGroup("Weapon", 629, 1),
			new PresetItemTemplateIdGroup("Weapon", 638, 1),
			new PresetItemTemplateIdGroup("Weapon", 647, 1),
			new PresetItemTemplateIdGroup("Weapon", 656, 1),
			new PresetItemTemplateIdGroup("Weapon", 665, 1),
			new PresetItemTemplateIdGroup("Weapon", 674, 1),
			new PresetItemTemplateIdGroup("Weapon", 683, 1),
			new PresetItemTemplateIdGroup("Weapon", 692, 1),
			new PresetItemTemplateIdGroup("Weapon", 701, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 800, 1),
			new PresetItemTemplateIdGroup("Weapon", 809, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 5, 1),
			new PresetItemTemplateIdGroup("Armor", 14, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 131, 1),
			new PresetItemTemplateIdGroup("Armor", 140, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 257, 1),
			new PresetItemTemplateIdGroup("Armor", 266, 1),
			new PresetItemTemplateIdGroup("Armor", 275, 1),
			new PresetItemTemplateIdGroup("Armor", 284, 1),
			new PresetItemTemplateIdGroup("Armor", 293, 1),
			new PresetItemTemplateIdGroup("Armor", 302, 1),
			new PresetItemTemplateIdGroup("Armor", 383, 1),
			new PresetItemTemplateIdGroup("Armor", 392, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 401, 1),
			new PresetItemTemplateIdGroup("Armor", 410, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 5, 1),
			new PresetItemTemplateIdGroup("Accessory", 14, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 15, 1),
			new PresetItemTemplateIdGroup("CraftTool", 24, 1),
			new PresetItemTemplateIdGroup("CraftTool", 6, 1)
		}, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, new short[14]
		{
			1, 1, 2, 1, 2, 2, 2, -40, -40, -40,
			2, -40, -40, -30
		}, new short[14]
		{
			1, 1, 2, 1, 2, 2, 2, -80, -80, -80,
			2, -80, -80, -60
		}, new short[14]
		{
			1, 0, 2, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 1, 0, 0, 0, 0, 0, -40, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 2, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 381, 380, 380, 380 }, 345));
		_dataArray.Add(new MerchantItem(26, 21, 3, 5, LocalStringManager.GetConfig("Merchant_language", "UiName_26"), 90, 1, 9, 20, 192000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 117, 1),
			new PresetItemTemplateIdGroup("Weapon", 126, 1),
			new PresetItemTemplateIdGroup("Weapon", 135, 1),
			new PresetItemTemplateIdGroup("Weapon", 144, 1),
			new PresetItemTemplateIdGroup("Weapon", 153, 1),
			new PresetItemTemplateIdGroup("Weapon", 162, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 171, 1),
			new PresetItemTemplateIdGroup("Weapon", 180, 1),
			new PresetItemTemplateIdGroup("Weapon", 189, 1),
			new PresetItemTemplateIdGroup("Weapon", 198, 1),
			new PresetItemTemplateIdGroup("Weapon", 207, 1),
			new PresetItemTemplateIdGroup("Weapon", 216, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 279, 1),
			new PresetItemTemplateIdGroup("Weapon", 288, 1),
			new PresetItemTemplateIdGroup("Weapon", 297, 1),
			new PresetItemTemplateIdGroup("Weapon", 306, 1),
			new PresetItemTemplateIdGroup("Weapon", 315, 1),
			new PresetItemTemplateIdGroup("Weapon", 324, 1),
			new PresetItemTemplateIdGroup("Weapon", 333, 1),
			new PresetItemTemplateIdGroup("Weapon", 342, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 387, 1),
			new PresetItemTemplateIdGroup("Weapon", 396, 1),
			new PresetItemTemplateIdGroup("Weapon", 405, 1),
			new PresetItemTemplateIdGroup("Weapon", 414, 1),
			new PresetItemTemplateIdGroup("Weapon", 423, 1),
			new PresetItemTemplateIdGroup("Weapon", 432, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 441, 1),
			new PresetItemTemplateIdGroup("Weapon", 450, 1),
			new PresetItemTemplateIdGroup("Weapon", 459, 1),
			new PresetItemTemplateIdGroup("Weapon", 468, 1),
			new PresetItemTemplateIdGroup("Weapon", 477, 1),
			new PresetItemTemplateIdGroup("Weapon", 486, 1),
			new PresetItemTemplateIdGroup("Weapon", 495, 1),
			new PresetItemTemplateIdGroup("Weapon", 504, 1),
			new PresetItemTemplateIdGroup("Weapon", 513, 1),
			new PresetItemTemplateIdGroup("Weapon", 522, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 531, 1),
			new PresetItemTemplateIdGroup("Weapon", 540, 1),
			new PresetItemTemplateIdGroup("Weapon", 549, 1),
			new PresetItemTemplateIdGroup("Weapon", 558, 1),
			new PresetItemTemplateIdGroup("Weapon", 567, 1),
			new PresetItemTemplateIdGroup("Weapon", 576, 1),
			new PresetItemTemplateIdGroup("Weapon", 585, 1),
			new PresetItemTemplateIdGroup("Weapon", 594, 1),
			new PresetItemTemplateIdGroup("Weapon", 603, 1),
			new PresetItemTemplateIdGroup("Weapon", 612, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 621, 1),
			new PresetItemTemplateIdGroup("Weapon", 630, 1),
			new PresetItemTemplateIdGroup("Weapon", 639, 1),
			new PresetItemTemplateIdGroup("Weapon", 648, 1),
			new PresetItemTemplateIdGroup("Weapon", 657, 1),
			new PresetItemTemplateIdGroup("Weapon", 666, 1),
			new PresetItemTemplateIdGroup("Weapon", 675, 1),
			new PresetItemTemplateIdGroup("Weapon", 684, 1),
			new PresetItemTemplateIdGroup("Weapon", 693, 1),
			new PresetItemTemplateIdGroup("Weapon", 702, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 801, 1),
			new PresetItemTemplateIdGroup("Weapon", 810, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 6, 1),
			new PresetItemTemplateIdGroup("Armor", 15, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 132, 1),
			new PresetItemTemplateIdGroup("Armor", 141, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 258, 1),
			new PresetItemTemplateIdGroup("Armor", 267, 1),
			new PresetItemTemplateIdGroup("Armor", 276, 1),
			new PresetItemTemplateIdGroup("Armor", 285, 1),
			new PresetItemTemplateIdGroup("Armor", 294, 1),
			new PresetItemTemplateIdGroup("Armor", 303, 1),
			new PresetItemTemplateIdGroup("Armor", 384, 1),
			new PresetItemTemplateIdGroup("Armor", 393, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 402, 1),
			new PresetItemTemplateIdGroup("Armor", 411, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 6, 1),
			new PresetItemTemplateIdGroup("Accessory", 15, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 16, 1),
			new PresetItemTemplateIdGroup("CraftTool", 25, 1),
			new PresetItemTemplateIdGroup("CraftTool", 7, 1)
		}, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, new short[14]
		{
			-30, -30, -30, -30, 1, 1, 1, -30, -30, -30,
			1, -30, -30, -20
		}, new short[14]
		{
			-60, -60, 1, -60, 1, 1, 1, -60, -60, -60,
			1, -60, -60, -40
		}, new short[14]
		{
			-30, 0, -30, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -30, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, -30, 0, 0, 0, 0, 0, -30, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 1, 1, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 382, 381, 381, 381 }, 350));
		_dataArray.Add(new MerchantItem(27, 21, 3, 6, LocalStringManager.GetConfig("Merchant_language", "UiName_27"), 100, 1, 12, 20, 384000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 118, 1),
			new PresetItemTemplateIdGroup("Weapon", 127, 1),
			new PresetItemTemplateIdGroup("Weapon", 136, 1),
			new PresetItemTemplateIdGroup("Weapon", 145, 1),
			new PresetItemTemplateIdGroup("Weapon", 154, 1),
			new PresetItemTemplateIdGroup("Weapon", 163, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 172, 1),
			new PresetItemTemplateIdGroup("Weapon", 181, 1),
			new PresetItemTemplateIdGroup("Weapon", 190, 1),
			new PresetItemTemplateIdGroup("Weapon", 199, 1),
			new PresetItemTemplateIdGroup("Weapon", 208, 1),
			new PresetItemTemplateIdGroup("Weapon", 217, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 280, 1),
			new PresetItemTemplateIdGroup("Weapon", 289, 1),
			new PresetItemTemplateIdGroup("Weapon", 298, 1),
			new PresetItemTemplateIdGroup("Weapon", 307, 1),
			new PresetItemTemplateIdGroup("Weapon", 316, 1),
			new PresetItemTemplateIdGroup("Weapon", 325, 1),
			new PresetItemTemplateIdGroup("Weapon", 334, 1),
			new PresetItemTemplateIdGroup("Weapon", 343, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 388, 1),
			new PresetItemTemplateIdGroup("Weapon", 397, 1),
			new PresetItemTemplateIdGroup("Weapon", 406, 1),
			new PresetItemTemplateIdGroup("Weapon", 415, 1),
			new PresetItemTemplateIdGroup("Weapon", 424, 1),
			new PresetItemTemplateIdGroup("Weapon", 433, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 442, 1),
			new PresetItemTemplateIdGroup("Weapon", 451, 1),
			new PresetItemTemplateIdGroup("Weapon", 460, 1),
			new PresetItemTemplateIdGroup("Weapon", 469, 1),
			new PresetItemTemplateIdGroup("Weapon", 478, 1),
			new PresetItemTemplateIdGroup("Weapon", 487, 1),
			new PresetItemTemplateIdGroup("Weapon", 496, 1),
			new PresetItemTemplateIdGroup("Weapon", 505, 1),
			new PresetItemTemplateIdGroup("Weapon", 514, 1),
			new PresetItemTemplateIdGroup("Weapon", 523, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 532, 1),
			new PresetItemTemplateIdGroup("Weapon", 541, 1),
			new PresetItemTemplateIdGroup("Weapon", 550, 1),
			new PresetItemTemplateIdGroup("Weapon", 559, 1),
			new PresetItemTemplateIdGroup("Weapon", 568, 1),
			new PresetItemTemplateIdGroup("Weapon", 577, 1),
			new PresetItemTemplateIdGroup("Weapon", 586, 1),
			new PresetItemTemplateIdGroup("Weapon", 595, 1),
			new PresetItemTemplateIdGroup("Weapon", 604, 1),
			new PresetItemTemplateIdGroup("Weapon", 613, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 622, 1),
			new PresetItemTemplateIdGroup("Weapon", 631, 1),
			new PresetItemTemplateIdGroup("Weapon", 640, 1),
			new PresetItemTemplateIdGroup("Weapon", 649, 1),
			new PresetItemTemplateIdGroup("Weapon", 658, 1),
			new PresetItemTemplateIdGroup("Weapon", 667, 1),
			new PresetItemTemplateIdGroup("Weapon", 676, 1),
			new PresetItemTemplateIdGroup("Weapon", 685, 1),
			new PresetItemTemplateIdGroup("Weapon", 694, 1),
			new PresetItemTemplateIdGroup("Weapon", 703, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 802, 1),
			new PresetItemTemplateIdGroup("Weapon", 811, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 7, 1),
			new PresetItemTemplateIdGroup("Armor", 16, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 133, 1),
			new PresetItemTemplateIdGroup("Armor", 142, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 259, 1),
			new PresetItemTemplateIdGroup("Armor", 268, 1),
			new PresetItemTemplateIdGroup("Armor", 277, 1),
			new PresetItemTemplateIdGroup("Armor", 286, 1),
			new PresetItemTemplateIdGroup("Armor", 295, 1),
			new PresetItemTemplateIdGroup("Armor", 304, 1),
			new PresetItemTemplateIdGroup("Armor", 385, 1),
			new PresetItemTemplateIdGroup("Armor", 394, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 403, 1),
			new PresetItemTemplateIdGroup("Armor", 412, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 7, 1),
			new PresetItemTemplateIdGroup("Accessory", 16, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 17, 1),
			new PresetItemTemplateIdGroup("CraftTool", 26, 1),
			new PresetItemTemplateIdGroup("CraftTool", 8, 1)
		}, new sbyte[0], new sbyte[0], new short[14]
		{
			-20, -20, -20, -20, 1, 1, 1, -20, -20, -20,
			1, -20, -20, -10
		}, new short[14]
		{
			-40, -40, 1, -40, 1, 1, 1, -40, -40, -40,
			1, -40, -40, -20
		}, new short[14]
		{
			-20, 0, -20, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -20, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, -20, 0, 0, 0, 0, 0, -20, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 1, 1, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 383, 382, 382, 382 }, 355));
		List<MerchantItem> dataArray23 = _dataArray;
		string config23 = LocalStringManager.GetConfig("Merchant_language", "UiName_28");
		List<PresetItemTemplateIdGroup> goods269 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 140, 3),
			new PresetItemTemplateIdGroup("Material", 156, 3),
			new PresetItemTemplateIdGroup("Material", 172, 3),
			new PresetItemTemplateIdGroup("Material", 188, 3)
		};
		List<PresetItemTemplateIdGroup> goods270 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 144, 3),
			new PresetItemTemplateIdGroup("Material", 160, 3),
			new PresetItemTemplateIdGroup("Material", 176, 3),
			new PresetItemTemplateIdGroup("Material", 192, 3),
			new PresetItemTemplateIdGroup("Material", 208, 3),
			new PresetItemTemplateIdGroup("Material", 224, 3)
		};
		List<PresetItemTemplateIdGroup> goods271 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 148, 3),
			new PresetItemTemplateIdGroup("Material", 152, 3),
			new PresetItemTemplateIdGroup("Material", 164, 3),
			new PresetItemTemplateIdGroup("Material", 180, 3),
			new PresetItemTemplateIdGroup("Material", 184, 3),
			new PresetItemTemplateIdGroup("Material", 196, 3),
			new PresetItemTemplateIdGroup("Material", 212, 3),
			new PresetItemTemplateIdGroup("Material", 216, 3),
			new PresetItemTemplateIdGroup("Material", 220, 3),
			new PresetItemTemplateIdGroup("Material", 232, 3)
		};
		List<PresetItemTemplateIdGroup> goods272 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 168, 3),
			new PresetItemTemplateIdGroup("Material", 200, 3),
			new PresetItemTemplateIdGroup("Material", 204, 3),
			new PresetItemTemplateIdGroup("Material", 228, 3)
		};
		List<PresetItemTemplateIdGroup> goods273 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 236, 3),
			new PresetItemTemplateIdGroup("Material", 243, 3),
			new PresetItemTemplateIdGroup("Material", 250, 3),
			new PresetItemTemplateIdGroup("Material", 257, 3),
			new PresetItemTemplateIdGroup("Material", 264, 3),
			new PresetItemTemplateIdGroup("Material", 271, 3)
		};
		List<PresetItemTemplateIdGroup> goods274 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 54, 3),
			new PresetItemTemplateIdGroup("Medicine", 55, 3),
			new PresetItemTemplateIdGroup("Medicine", 66, 3),
			new PresetItemTemplateIdGroup("Medicine", 67, 3),
			new PresetItemTemplateIdGroup("Medicine", 82, 3),
			new PresetItemTemplateIdGroup("Medicine", 83, 3),
			new PresetItemTemplateIdGroup("Medicine", 94, 3),
			new PresetItemTemplateIdGroup("Medicine", 95, 3),
			new PresetItemTemplateIdGroup("Medicine", 56, 3),
			new PresetItemTemplateIdGroup("Medicine", 68, 3),
			new PresetItemTemplateIdGroup("Medicine", 84, 3),
			new PresetItemTemplateIdGroup("Medicine", 96, 3)
		};
		List<PresetItemTemplateIdGroup> goods275 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 130, 3),
			new PresetItemTemplateIdGroup("Medicine", 131, 3),
			new PresetItemTemplateIdGroup("Medicine", 142, 3),
			new PresetItemTemplateIdGroup("Medicine", 143, 3),
			new PresetItemTemplateIdGroup("Medicine", 154, 3),
			new PresetItemTemplateIdGroup("Medicine", 155, 3),
			new PresetItemTemplateIdGroup("Medicine", 166, 3),
			new PresetItemTemplateIdGroup("Medicine", 167, 3),
			new PresetItemTemplateIdGroup("Medicine", 178, 3),
			new PresetItemTemplateIdGroup("Medicine", 179, 3),
			new PresetItemTemplateIdGroup("Medicine", 190, 3),
			new PresetItemTemplateIdGroup("Medicine", 191, 3),
			new PresetItemTemplateIdGroup("Medicine", 132, 3),
			new PresetItemTemplateIdGroup("Medicine", 144, 3),
			new PresetItemTemplateIdGroup("Medicine", 156, 3),
			new PresetItemTemplateIdGroup("Medicine", 168, 3),
			new PresetItemTemplateIdGroup("Medicine", 180, 3),
			new PresetItemTemplateIdGroup("Medicine", 192, 3)
		};
		List<PresetItemTemplateIdGroup> goods276 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 118, 2),
			new PresetItemTemplateIdGroup("Medicine", 119, 2),
			new PresetItemTemplateIdGroup("Medicine", 202, 2),
			new PresetItemTemplateIdGroup("Medicine", 203, 2),
			new PresetItemTemplateIdGroup("Medicine", 214, 2),
			new PresetItemTemplateIdGroup("Medicine", 215, 2),
			new PresetItemTemplateIdGroup("Medicine", 226, 2),
			new PresetItemTemplateIdGroup("Medicine", 227, 2),
			new PresetItemTemplateIdGroup("Medicine", 238, 2),
			new PresetItemTemplateIdGroup("Medicine", 239, 2),
			new PresetItemTemplateIdGroup("Medicine", 250, 2),
			new PresetItemTemplateIdGroup("Medicine", 251, 2),
			new PresetItemTemplateIdGroup("Medicine", 274, 2),
			new PresetItemTemplateIdGroup("Medicine", 275, 2),
			new PresetItemTemplateIdGroup("Medicine", 298, 2),
			new PresetItemTemplateIdGroup("Medicine", 299, 2),
			new PresetItemTemplateIdGroup("Medicine", 322, 2),
			new PresetItemTemplateIdGroup("Medicine", 323, 2),
			new PresetItemTemplateIdGroup("Medicine", 334, 2),
			new PresetItemTemplateIdGroup("Medicine", 335, 2),
			new PresetItemTemplateIdGroup("Medicine", 120, 2),
			new PresetItemTemplateIdGroup("Medicine", 204, 2),
			new PresetItemTemplateIdGroup("Medicine", 216, 2),
			new PresetItemTemplateIdGroup("Medicine", 228, 2),
			new PresetItemTemplateIdGroup("Medicine", 240, 2),
			new PresetItemTemplateIdGroup("Medicine", 252, 2),
			new PresetItemTemplateIdGroup("Medicine", 276, 2),
			new PresetItemTemplateIdGroup("Medicine", 300, 2),
			new PresetItemTemplateIdGroup("Medicine", 324, 2),
			new PresetItemTemplateIdGroup("Medicine", 336, 2)
		};
		List<PresetItemTemplateIdGroup> goods277 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 106, 2),
			new PresetItemTemplateIdGroup("Medicine", 107, 2),
			new PresetItemTemplateIdGroup("Medicine", 108, 2),
			new PresetItemTemplateIdGroup("Medicine", 262, 2),
			new PresetItemTemplateIdGroup("Medicine", 263, 2),
			new PresetItemTemplateIdGroup("Medicine", 264, 2),
			new PresetItemTemplateIdGroup("Medicine", 286, 2),
			new PresetItemTemplateIdGroup("Medicine", 287, 2),
			new PresetItemTemplateIdGroup("Medicine", 288, 2),
			new PresetItemTemplateIdGroup("Medicine", 310, 2),
			new PresetItemTemplateIdGroup("Medicine", 311, 2),
			new PresetItemTemplateIdGroup("Medicine", 312, 2)
		};
		List<PresetItemTemplateIdGroup> goods278 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 0, 1),
			new PresetItemTemplateIdGroup("Medicine", 1, 1),
			new PresetItemTemplateIdGroup("Medicine", 9, 1),
			new PresetItemTemplateIdGroup("Medicine", 10, 1),
			new PresetItemTemplateIdGroup("Medicine", 18, 1),
			new PresetItemTemplateIdGroup("Medicine", 19, 1),
			new PresetItemTemplateIdGroup("Medicine", 27, 1),
			new PresetItemTemplateIdGroup("Medicine", 28, 1),
			new PresetItemTemplateIdGroup("Medicine", 36, 1),
			new PresetItemTemplateIdGroup("Medicine", 37, 1),
			new PresetItemTemplateIdGroup("Medicine", 45, 1),
			new PresetItemTemplateIdGroup("Medicine", 46, 1),
			new PresetItemTemplateIdGroup("Medicine", 2, 1),
			new PresetItemTemplateIdGroup("Medicine", 11, 1),
			new PresetItemTemplateIdGroup("Medicine", 20, 1),
			new PresetItemTemplateIdGroup("Medicine", 29, 1),
			new PresetItemTemplateIdGroup("Medicine", 38, 1),
			new PresetItemTemplateIdGroup("Medicine", 47, 1)
		};
		List<PresetItemTemplateIdGroup> goods279 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 57, 1),
			new PresetItemTemplateIdGroup("Weapon", 58, 1),
			new PresetItemTemplateIdGroup("Weapon", 66, 1),
			new PresetItemTemplateIdGroup("Weapon", 67, 1),
			new PresetItemTemplateIdGroup("Weapon", 75, 1),
			new PresetItemTemplateIdGroup("Weapon", 76, 1),
			new PresetItemTemplateIdGroup("Weapon", 84, 1),
			new PresetItemTemplateIdGroup("Weapon", 85, 1),
			new PresetItemTemplateIdGroup("Weapon", 93, 1),
			new PresetItemTemplateIdGroup("Weapon", 94, 1),
			new PresetItemTemplateIdGroup("Weapon", 102, 1),
			new PresetItemTemplateIdGroup("Weapon", 103, 1)
		};
		List<PresetItemTemplateIdGroup> goods280 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 45, 1),
			new PresetItemTemplateIdGroup("CraftTool", 46, 1),
			new PresetItemTemplateIdGroup("CraftTool", 47, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray23.Add(new MerchantItem(28, 28, 4, 0, config23, 0, 1, 3, 20, 6000, goods269, goods270, goods271, goods272, goods273, goods274, goods275, goods276, goods277, goods278, goods279, goods280, goods12, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 264, 30)
		}, new sbyte[7] { 0, 1, 2, 3, 4, 10, 11 }, new sbyte[7] { 0, 1, 2, 3, 4, 10, 11 }, new short[14]
		{
			2, 2, 4, 2, 2, 4, 6, 10, 4, 6,
			3, 1, 0, 1
		}, new short[14]
		{
			1, 1, 2, 1, 1, 2, 3, 5, 2, 3,
			2, 1, 0, 1
		}, new short[14]
		{
			0, 0, 0, 2, 0, 0, 0, 0, 4, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 2, 0, 0, 0, 0, 6, 0, 0, 0,
			0, 0, 0, 1
		}, new short[14]
		{
			0, 0, 4, 0, 0, 0, 0, 10, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			2, 0, 0, 0, 0, 4, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 377, 376, 376, 376 }, 310));
		List<MerchantItem> dataArray24 = _dataArray;
		string config24 = LocalStringManager.GetConfig("Merchant_language", "UiName_29");
		List<PresetItemTemplateIdGroup> goods281 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 140, 3),
			new PresetItemTemplateIdGroup("Material", 156, 3),
			new PresetItemTemplateIdGroup("Material", 172, 3),
			new PresetItemTemplateIdGroup("Material", 188, 3)
		};
		List<PresetItemTemplateIdGroup> goods282 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 144, 3),
			new PresetItemTemplateIdGroup("Material", 160, 3),
			new PresetItemTemplateIdGroup("Material", 176, 3),
			new PresetItemTemplateIdGroup("Material", 192, 3),
			new PresetItemTemplateIdGroup("Material", 208, 3),
			new PresetItemTemplateIdGroup("Material", 224, 3)
		};
		List<PresetItemTemplateIdGroup> goods283 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 148, 3),
			new PresetItemTemplateIdGroup("Material", 152, 3),
			new PresetItemTemplateIdGroup("Material", 164, 3),
			new PresetItemTemplateIdGroup("Material", 180, 3),
			new PresetItemTemplateIdGroup("Material", 184, 3),
			new PresetItemTemplateIdGroup("Material", 196, 3),
			new PresetItemTemplateIdGroup("Material", 212, 3),
			new PresetItemTemplateIdGroup("Material", 216, 3),
			new PresetItemTemplateIdGroup("Material", 220, 3),
			new PresetItemTemplateIdGroup("Material", 232, 3)
		};
		List<PresetItemTemplateIdGroup> goods284 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 168, 3),
			new PresetItemTemplateIdGroup("Material", 200, 3),
			new PresetItemTemplateIdGroup("Material", 204, 3),
			new PresetItemTemplateIdGroup("Material", 228, 3)
		};
		List<PresetItemTemplateIdGroup> goods285 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 237, 3),
			new PresetItemTemplateIdGroup("Material", 244, 3),
			new PresetItemTemplateIdGroup("Material", 251, 3),
			new PresetItemTemplateIdGroup("Material", 258, 3),
			new PresetItemTemplateIdGroup("Material", 265, 3),
			new PresetItemTemplateIdGroup("Material", 272, 3)
		};
		List<PresetItemTemplateIdGroup> goods286 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 57, 2),
			new PresetItemTemplateIdGroup("Medicine", 60, 2),
			new PresetItemTemplateIdGroup("Medicine", 69, 2),
			new PresetItemTemplateIdGroup("Medicine", 72, 2),
			new PresetItemTemplateIdGroup("Medicine", 85, 2),
			new PresetItemTemplateIdGroup("Medicine", 88, 2),
			new PresetItemTemplateIdGroup("Medicine", 97, 2),
			new PresetItemTemplateIdGroup("Medicine", 100, 2)
		};
		List<PresetItemTemplateIdGroup> goods287 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 133, 2),
			new PresetItemTemplateIdGroup("Medicine", 136, 2),
			new PresetItemTemplateIdGroup("Medicine", 145, 2),
			new PresetItemTemplateIdGroup("Medicine", 148, 2),
			new PresetItemTemplateIdGroup("Medicine", 157, 2),
			new PresetItemTemplateIdGroup("Medicine", 160, 2),
			new PresetItemTemplateIdGroup("Medicine", 169, 2),
			new PresetItemTemplateIdGroup("Medicine", 172, 2),
			new PresetItemTemplateIdGroup("Medicine", 181, 2),
			new PresetItemTemplateIdGroup("Medicine", 184, 2),
			new PresetItemTemplateIdGroup("Medicine", 193, 2),
			new PresetItemTemplateIdGroup("Medicine", 196, 2)
		};
		List<PresetItemTemplateIdGroup> goods288 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 121, 1),
			new PresetItemTemplateIdGroup("Medicine", 124, 2),
			new PresetItemTemplateIdGroup("Medicine", 205, 1),
			new PresetItemTemplateIdGroup("Medicine", 208, 2),
			new PresetItemTemplateIdGroup("Medicine", 217, 1),
			new PresetItemTemplateIdGroup("Medicine", 220, 2),
			new PresetItemTemplateIdGroup("Medicine", 229, 1),
			new PresetItemTemplateIdGroup("Medicine", 232, 2),
			new PresetItemTemplateIdGroup("Medicine", 241, 1),
			new PresetItemTemplateIdGroup("Medicine", 244, 2),
			new PresetItemTemplateIdGroup("Medicine", 253, 1),
			new PresetItemTemplateIdGroup("Medicine", 256, 2),
			new PresetItemTemplateIdGroup("Medicine", 277, 1),
			new PresetItemTemplateIdGroup("Medicine", 280, 2),
			new PresetItemTemplateIdGroup("Medicine", 301, 1),
			new PresetItemTemplateIdGroup("Medicine", 304, 2),
			new PresetItemTemplateIdGroup("Medicine", 325, 1),
			new PresetItemTemplateIdGroup("Medicine", 328, 2),
			new PresetItemTemplateIdGroup("Medicine", 337, 1),
			new PresetItemTemplateIdGroup("Medicine", 340, 2)
		};
		List<PresetItemTemplateIdGroup> goods289 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 109, 1),
			new PresetItemTemplateIdGroup("Medicine", 112, 2),
			new PresetItemTemplateIdGroup("Medicine", 265, 1),
			new PresetItemTemplateIdGroup("Medicine", 268, 2),
			new PresetItemTemplateIdGroup("Medicine", 289, 1),
			new PresetItemTemplateIdGroup("Medicine", 292, 2),
			new PresetItemTemplateIdGroup("Medicine", 313, 1),
			new PresetItemTemplateIdGroup("Medicine", 316, 2)
		};
		List<PresetItemTemplateIdGroup> goods290 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 3, 1),
			new PresetItemTemplateIdGroup("Medicine", 12, 1),
			new PresetItemTemplateIdGroup("Medicine", 21, 1),
			new PresetItemTemplateIdGroup("Medicine", 30, 1),
			new PresetItemTemplateIdGroup("Medicine", 39, 1),
			new PresetItemTemplateIdGroup("Medicine", 48, 1)
		};
		List<PresetItemTemplateIdGroup> goods291 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 59, 1),
			new PresetItemTemplateIdGroup("Weapon", 68, 1),
			new PresetItemTemplateIdGroup("Weapon", 77, 1),
			new PresetItemTemplateIdGroup("Weapon", 86, 1),
			new PresetItemTemplateIdGroup("Weapon", 95, 1),
			new PresetItemTemplateIdGroup("Weapon", 104, 1)
		};
		List<PresetItemTemplateIdGroup> goods292 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 48, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods293 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray24.Add(new MerchantItem(29, 28, 4, 1, config24, 20, 1, 3, 20, 12000, goods281, goods282, goods283, goods284, goods285, goods286, goods287, goods288, goods289, goods290, goods291, goods292, goods293, goods12, new sbyte[7] { 0, 1, 2, 3, 4, 10, 11 }, new sbyte[7] { 0, 1, 2, 3, 4, 10, 11 }, new short[14]
		{
			2, 2, 4, 2, 2, 2, 4, 6, 2, 2,
			2, -60, 0, 0
		}, new short[14]
		{
			1, 1, 2, 1, 1, 2, 4, 6, 2, 2,
			1, 1, 0, 0
		}, new short[14]
		{
			0, 0, 0, 2, 0, 0, 0, 0, 2, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 2, 0, 0, 0, 0, 4, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 4, 0, 0, 0, 0, 6, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			2, 0, 0, 0, 0, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 378, 377, 377, 377 }, 330));
		List<MerchantItem> dataArray25 = _dataArray;
		string config25 = LocalStringManager.GetConfig("Merchant_language", "UiName_30");
		List<PresetItemTemplateIdGroup> goods294 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 141, 2),
			new PresetItemTemplateIdGroup("Material", 157, 2),
			new PresetItemTemplateIdGroup("Material", 173, 2),
			new PresetItemTemplateIdGroup("Material", 189, 2)
		};
		List<PresetItemTemplateIdGroup> goods295 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 145, 2),
			new PresetItemTemplateIdGroup("Material", 161, 2),
			new PresetItemTemplateIdGroup("Material", 177, 2),
			new PresetItemTemplateIdGroup("Material", 193, 2),
			new PresetItemTemplateIdGroup("Material", 209, 2),
			new PresetItemTemplateIdGroup("Material", 225, 2)
		};
		List<PresetItemTemplateIdGroup> goods296 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 149, 2),
			new PresetItemTemplateIdGroup("Material", 153, 2),
			new PresetItemTemplateIdGroup("Material", 165, 2),
			new PresetItemTemplateIdGroup("Material", 181, 2),
			new PresetItemTemplateIdGroup("Material", 185, 2),
			new PresetItemTemplateIdGroup("Material", 197, 2),
			new PresetItemTemplateIdGroup("Material", 213, 2),
			new PresetItemTemplateIdGroup("Material", 217, 2),
			new PresetItemTemplateIdGroup("Material", 221, 2),
			new PresetItemTemplateIdGroup("Material", 233, 2)
		};
		List<PresetItemTemplateIdGroup> goods297 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 169, 2),
			new PresetItemTemplateIdGroup("Material", 201, 2),
			new PresetItemTemplateIdGroup("Material", 205, 2),
			new PresetItemTemplateIdGroup("Material", 229, 2)
		};
		List<PresetItemTemplateIdGroup> goods298 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 238, 2),
			new PresetItemTemplateIdGroup("Material", 245, 2),
			new PresetItemTemplateIdGroup("Material", 252, 2),
			new PresetItemTemplateIdGroup("Material", 259, 2),
			new PresetItemTemplateIdGroup("Material", 266, 2),
			new PresetItemTemplateIdGroup("Material", 273, 2)
		};
		List<PresetItemTemplateIdGroup> goods299 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 58, 2),
			new PresetItemTemplateIdGroup("Medicine", 61, 2),
			new PresetItemTemplateIdGroup("Medicine", 70, 2),
			new PresetItemTemplateIdGroup("Medicine", 73, 2),
			new PresetItemTemplateIdGroup("Medicine", 86, 2),
			new PresetItemTemplateIdGroup("Medicine", 89, 2),
			new PresetItemTemplateIdGroup("Medicine", 98, 2),
			new PresetItemTemplateIdGroup("Medicine", 101, 2)
		};
		List<PresetItemTemplateIdGroup> goods300 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 134, 2),
			new PresetItemTemplateIdGroup("Medicine", 137, 2),
			new PresetItemTemplateIdGroup("Medicine", 146, 2),
			new PresetItemTemplateIdGroup("Medicine", 149, 2),
			new PresetItemTemplateIdGroup("Medicine", 158, 2),
			new PresetItemTemplateIdGroup("Medicine", 161, 2),
			new PresetItemTemplateIdGroup("Medicine", 170, 2),
			new PresetItemTemplateIdGroup("Medicine", 173, 2),
			new PresetItemTemplateIdGroup("Medicine", 182, 2),
			new PresetItemTemplateIdGroup("Medicine", 185, 2),
			new PresetItemTemplateIdGroup("Medicine", 194, 2),
			new PresetItemTemplateIdGroup("Medicine", 197, 2)
		};
		List<PresetItemTemplateIdGroup> goods301 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 122, 1),
			new PresetItemTemplateIdGroup("Medicine", 125, 2),
			new PresetItemTemplateIdGroup("Medicine", 206, 1),
			new PresetItemTemplateIdGroup("Medicine", 209, 2),
			new PresetItemTemplateIdGroup("Medicine", 218, 1),
			new PresetItemTemplateIdGroup("Medicine", 221, 2),
			new PresetItemTemplateIdGroup("Medicine", 230, 1),
			new PresetItemTemplateIdGroup("Medicine", 233, 2),
			new PresetItemTemplateIdGroup("Medicine", 242, 1),
			new PresetItemTemplateIdGroup("Medicine", 245, 2),
			new PresetItemTemplateIdGroup("Medicine", 254, 1),
			new PresetItemTemplateIdGroup("Medicine", 257, 2),
			new PresetItemTemplateIdGroup("Medicine", 278, 1),
			new PresetItemTemplateIdGroup("Medicine", 281, 2),
			new PresetItemTemplateIdGroup("Medicine", 302, 1),
			new PresetItemTemplateIdGroup("Medicine", 305, 2),
			new PresetItemTemplateIdGroup("Medicine", 326, 1),
			new PresetItemTemplateIdGroup("Medicine", 329, 2),
			new PresetItemTemplateIdGroup("Medicine", 338, 1),
			new PresetItemTemplateIdGroup("Medicine", 341, 2)
		};
		List<PresetItemTemplateIdGroup> goods302 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 110, 1),
			new PresetItemTemplateIdGroup("Medicine", 113, 2),
			new PresetItemTemplateIdGroup("Medicine", 266, 1),
			new PresetItemTemplateIdGroup("Medicine", 269, 2),
			new PresetItemTemplateIdGroup("Medicine", 290, 1),
			new PresetItemTemplateIdGroup("Medicine", 293, 2),
			new PresetItemTemplateIdGroup("Medicine", 314, 1),
			new PresetItemTemplateIdGroup("Medicine", 317, 2)
		};
		List<PresetItemTemplateIdGroup> goods303 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 4, 1),
			new PresetItemTemplateIdGroup("Medicine", 13, 1),
			new PresetItemTemplateIdGroup("Medicine", 22, 1),
			new PresetItemTemplateIdGroup("Medicine", 31, 1),
			new PresetItemTemplateIdGroup("Medicine", 40, 1),
			new PresetItemTemplateIdGroup("Medicine", 49, 1)
		};
		List<PresetItemTemplateIdGroup> goods304 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 60, 1),
			new PresetItemTemplateIdGroup("Weapon", 69, 1),
			new PresetItemTemplateIdGroup("Weapon", 78, 1),
			new PresetItemTemplateIdGroup("Weapon", 87, 1),
			new PresetItemTemplateIdGroup("Weapon", 96, 1),
			new PresetItemTemplateIdGroup("Weapon", 105, 1)
		};
		List<PresetItemTemplateIdGroup> goods305 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 49, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods306 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray25.Add(new MerchantItem(30, 28, 4, 2, config25, 40, 1, 6, 20, 24000, goods294, goods295, goods296, goods297, goods298, goods299, goods300, goods301, goods302, goods303, goods304, goods305, goods306, goods12, new sbyte[7] { 0, 1, 2, 3, 4, 10, 11 }, new sbyte[7] { 0, 1, 2, 3, 4, 10, 11 }, new short[14]
		{
			1, 2, 3, 1, 2, 2, 4, 6, 2, 2,
			1, -50, 0, 0
		}, new short[14]
		{
			1, 2, 3, 1, 2, 2, 4, 6, 2, 2,
			1, 1, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 2, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 2, 0, 0, 0, 0, 4, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 3, 0, 0, 0, 0, 6, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 0, 0, 0, 0, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 379, 378, 378, 378 }, 335));
		List<MerchantItem> dataArray26 = _dataArray;
		string config26 = LocalStringManager.GetConfig("Merchant_language", "UiName_31");
		List<PresetItemTemplateIdGroup> goods307 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 141, 2),
			new PresetItemTemplateIdGroup("Material", 157, 2),
			new PresetItemTemplateIdGroup("Material", 173, 2),
			new PresetItemTemplateIdGroup("Material", 189, 2)
		};
		List<PresetItemTemplateIdGroup> goods308 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 145, 2),
			new PresetItemTemplateIdGroup("Material", 161, 2),
			new PresetItemTemplateIdGroup("Material", 177, 2),
			new PresetItemTemplateIdGroup("Material", 193, 2),
			new PresetItemTemplateIdGroup("Material", 209, 2),
			new PresetItemTemplateIdGroup("Material", 225, 2)
		};
		List<PresetItemTemplateIdGroup> goods309 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 149, 2),
			new PresetItemTemplateIdGroup("Material", 153, 2),
			new PresetItemTemplateIdGroup("Material", 165, 2),
			new PresetItemTemplateIdGroup("Material", 181, 2),
			new PresetItemTemplateIdGroup("Material", 185, 2),
			new PresetItemTemplateIdGroup("Material", 197, 2),
			new PresetItemTemplateIdGroup("Material", 213, 2),
			new PresetItemTemplateIdGroup("Material", 217, 2),
			new PresetItemTemplateIdGroup("Material", 221, 2),
			new PresetItemTemplateIdGroup("Material", 233, 2)
		};
		List<PresetItemTemplateIdGroup> goods310 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 169, 2),
			new PresetItemTemplateIdGroup("Material", 201, 2),
			new PresetItemTemplateIdGroup("Material", 205, 2),
			new PresetItemTemplateIdGroup("Material", 229, 2)
		};
		List<PresetItemTemplateIdGroup> goods311 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 239, 2),
			new PresetItemTemplateIdGroup("Material", 246, 2),
			new PresetItemTemplateIdGroup("Material", 253, 2),
			new PresetItemTemplateIdGroup("Material", 260, 2),
			new PresetItemTemplateIdGroup("Material", 267, 2),
			new PresetItemTemplateIdGroup("Material", 274, 2)
		};
		List<PresetItemTemplateIdGroup> goods312 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 59, 2),
			new PresetItemTemplateIdGroup("Medicine", 62, 2),
			new PresetItemTemplateIdGroup("Medicine", 71, 2),
			new PresetItemTemplateIdGroup("Medicine", 74, 2),
			new PresetItemTemplateIdGroup("Medicine", 87, 2),
			new PresetItemTemplateIdGroup("Medicine", 90, 2),
			new PresetItemTemplateIdGroup("Medicine", 99, 2),
			new PresetItemTemplateIdGroup("Medicine", 102, 2)
		};
		List<PresetItemTemplateIdGroup> goods313 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 135, 2),
			new PresetItemTemplateIdGroup("Medicine", 138, 2),
			new PresetItemTemplateIdGroup("Medicine", 147, 2),
			new PresetItemTemplateIdGroup("Medicine", 150, 2),
			new PresetItemTemplateIdGroup("Medicine", 159, 2),
			new PresetItemTemplateIdGroup("Medicine", 162, 2),
			new PresetItemTemplateIdGroup("Medicine", 171, 2),
			new PresetItemTemplateIdGroup("Medicine", 174, 2),
			new PresetItemTemplateIdGroup("Medicine", 183, 2),
			new PresetItemTemplateIdGroup("Medicine", 186, 2),
			new PresetItemTemplateIdGroup("Medicine", 195, 2),
			new PresetItemTemplateIdGroup("Medicine", 198, 2)
		};
		List<PresetItemTemplateIdGroup> goods314 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 123, 1),
			new PresetItemTemplateIdGroup("Medicine", 126, 2),
			new PresetItemTemplateIdGroup("Medicine", 207, 1),
			new PresetItemTemplateIdGroup("Medicine", 210, 2),
			new PresetItemTemplateIdGroup("Medicine", 219, 1),
			new PresetItemTemplateIdGroup("Medicine", 222, 2),
			new PresetItemTemplateIdGroup("Medicine", 231, 1),
			new PresetItemTemplateIdGroup("Medicine", 234, 2),
			new PresetItemTemplateIdGroup("Medicine", 243, 1),
			new PresetItemTemplateIdGroup("Medicine", 246, 2),
			new PresetItemTemplateIdGroup("Medicine", 255, 1),
			new PresetItemTemplateIdGroup("Medicine", 258, 2),
			new PresetItemTemplateIdGroup("Medicine", 279, 1),
			new PresetItemTemplateIdGroup("Medicine", 282, 2),
			new PresetItemTemplateIdGroup("Medicine", 303, 1),
			new PresetItemTemplateIdGroup("Medicine", 306, 2),
			new PresetItemTemplateIdGroup("Medicine", 327, 1),
			new PresetItemTemplateIdGroup("Medicine", 330, 2),
			new PresetItemTemplateIdGroup("Medicine", 339, 1),
			new PresetItemTemplateIdGroup("Medicine", 342, 2)
		};
		List<PresetItemTemplateIdGroup> goods315 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 111, 1),
			new PresetItemTemplateIdGroup("Medicine", 114, 2),
			new PresetItemTemplateIdGroup("Medicine", 267, 1),
			new PresetItemTemplateIdGroup("Medicine", 270, 2),
			new PresetItemTemplateIdGroup("Medicine", 291, 1),
			new PresetItemTemplateIdGroup("Medicine", 294, 2),
			new PresetItemTemplateIdGroup("Medicine", 315, 1),
			new PresetItemTemplateIdGroup("Medicine", 318, 2)
		};
		List<PresetItemTemplateIdGroup> goods316 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 5, 1),
			new PresetItemTemplateIdGroup("Medicine", 14, 1),
			new PresetItemTemplateIdGroup("Medicine", 23, 1),
			new PresetItemTemplateIdGroup("Medicine", 32, 1),
			new PresetItemTemplateIdGroup("Medicine", 41, 1),
			new PresetItemTemplateIdGroup("Medicine", 50, 1)
		};
		List<PresetItemTemplateIdGroup> goods317 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 61, 1),
			new PresetItemTemplateIdGroup("Weapon", 70, 1),
			new PresetItemTemplateIdGroup("Weapon", 79, 1),
			new PresetItemTemplateIdGroup("Weapon", 88, 1),
			new PresetItemTemplateIdGroup("Weapon", 97, 1),
			new PresetItemTemplateIdGroup("Weapon", 106, 1)
		};
		List<PresetItemTemplateIdGroup> goods318 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 50, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods319 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray26.Add(new MerchantItem(31, 28, 4, 3, config26, 60, 1, 6, 20, 48000, goods307, goods308, goods309, goods310, goods311, goods312, goods313, goods314, goods315, goods316, goods317, goods318, goods319, goods12, new sbyte[7] { 0, 1, 2, 3, 4, 10, 11 }, new sbyte[7] { 0, 1, 2, 3, 4, 10, 11 }, new short[14]
		{
			1, 2, 3, 1, 2, 2, 4, 6, 2, 2,
			1, -40, 0, 0
		}, new short[14]
		{
			1, 2, 3, 1, 2, 2, 4, 6, 2, 2,
			1, -80, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 2, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 2, 0, 0, 0, 0, 4, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 3, 0, 0, 0, 0, 6, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 0, 0, 0, 0, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 380, 379, 379, 379 }, 340));
		List<MerchantItem> dataArray27 = _dataArray;
		string config27 = LocalStringManager.GetConfig("Merchant_language", "UiName_32");
		List<PresetItemTemplateIdGroup> goods320 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 142, 1),
			new PresetItemTemplateIdGroup("Material", 158, 1),
			new PresetItemTemplateIdGroup("Material", 174, 1),
			new PresetItemTemplateIdGroup("Material", 190, 1)
		};
		List<PresetItemTemplateIdGroup> goods321 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 146, 1),
			new PresetItemTemplateIdGroup("Material", 162, 1),
			new PresetItemTemplateIdGroup("Material", 178, 1),
			new PresetItemTemplateIdGroup("Material", 194, 1),
			new PresetItemTemplateIdGroup("Material", 210, 1),
			new PresetItemTemplateIdGroup("Material", 226, 1)
		};
		List<PresetItemTemplateIdGroup> goods322 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 150, 1),
			new PresetItemTemplateIdGroup("Material", 154, 1),
			new PresetItemTemplateIdGroup("Material", 166, 1),
			new PresetItemTemplateIdGroup("Material", 182, 1),
			new PresetItemTemplateIdGroup("Material", 186, 1),
			new PresetItemTemplateIdGroup("Material", 198, 1),
			new PresetItemTemplateIdGroup("Material", 214, 1),
			new PresetItemTemplateIdGroup("Material", 218, 1),
			new PresetItemTemplateIdGroup("Material", 222, 1),
			new PresetItemTemplateIdGroup("Material", 234, 1)
		};
		List<PresetItemTemplateIdGroup> goods323 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 170, 1),
			new PresetItemTemplateIdGroup("Material", 202, 1),
			new PresetItemTemplateIdGroup("Material", 206, 1),
			new PresetItemTemplateIdGroup("Material", 230, 1)
		};
		List<PresetItemTemplateIdGroup> goods324 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 240, 2),
			new PresetItemTemplateIdGroup("Material", 247, 2),
			new PresetItemTemplateIdGroup("Material", 254, 2),
			new PresetItemTemplateIdGroup("Material", 261, 2),
			new PresetItemTemplateIdGroup("Material", 268, 2),
			new PresetItemTemplateIdGroup("Material", 275, 2)
		};
		List<PresetItemTemplateIdGroup> goods325 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 63, 1),
			new PresetItemTemplateIdGroup("Medicine", 75, 1),
			new PresetItemTemplateIdGroup("Medicine", 91, 1),
			new PresetItemTemplateIdGroup("Medicine", 103, 1)
		};
		List<PresetItemTemplateIdGroup> goods326 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 139, 1),
			new PresetItemTemplateIdGroup("Medicine", 151, 1),
			new PresetItemTemplateIdGroup("Medicine", 163, 1),
			new PresetItemTemplateIdGroup("Medicine", 175, 1),
			new PresetItemTemplateIdGroup("Medicine", 187, 1),
			new PresetItemTemplateIdGroup("Medicine", 199, 1)
		};
		List<PresetItemTemplateIdGroup> goods327 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 127, 1),
			new PresetItemTemplateIdGroup("Medicine", 211, 1),
			new PresetItemTemplateIdGroup("Medicine", 223, 1),
			new PresetItemTemplateIdGroup("Medicine", 235, 1),
			new PresetItemTemplateIdGroup("Medicine", 247, 1),
			new PresetItemTemplateIdGroup("Medicine", 259, 1),
			new PresetItemTemplateIdGroup("Medicine", 283, 1),
			new PresetItemTemplateIdGroup("Medicine", 307, 1),
			new PresetItemTemplateIdGroup("Medicine", 331, 1),
			new PresetItemTemplateIdGroup("Medicine", 343, 1)
		};
		List<PresetItemTemplateIdGroup> goods328 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 115, 1),
			new PresetItemTemplateIdGroup("Medicine", 271, 1),
			new PresetItemTemplateIdGroup("Medicine", 295, 1),
			new PresetItemTemplateIdGroup("Medicine", 319, 1)
		};
		List<PresetItemTemplateIdGroup> goods329 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 6, 1),
			new PresetItemTemplateIdGroup("Medicine", 15, 1),
			new PresetItemTemplateIdGroup("Medicine", 24, 1),
			new PresetItemTemplateIdGroup("Medicine", 33, 1),
			new PresetItemTemplateIdGroup("Medicine", 42, 1),
			new PresetItemTemplateIdGroup("Medicine", 51, 1)
		};
		List<PresetItemTemplateIdGroup> goods330 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 62, 1),
			new PresetItemTemplateIdGroup("Weapon", 71, 1),
			new PresetItemTemplateIdGroup("Weapon", 80, 1),
			new PresetItemTemplateIdGroup("Weapon", 89, 1),
			new PresetItemTemplateIdGroup("Weapon", 98, 1),
			new PresetItemTemplateIdGroup("Weapon", 107, 1)
		};
		List<PresetItemTemplateIdGroup> goods331 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 51, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods332 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray27.Add(new MerchantItem(32, 28, 4, 4, config27, 80, 1, 9, 20, 96000, goods320, goods321, goods322, goods323, goods324, goods325, goods326, goods327, goods328, goods329, goods330, goods331, goods332, goods12, new sbyte[7] { 0, 1, 2, 3, 4, 10, 11 }, new sbyte[7] { 0, 1, 2, 3, 4, 10, 11 }, new short[14]
		{
			1, 2, 3, 1, 2, -30, 1, 2, -30, 1,
			1, -30, 0, 0
		}, new short[14]
		{
			1, 2, 3, 1, 2, -60, 1, 2, -60, 1,
			1, -60, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 0, 0, -30, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 2, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 3, 0, 0, 0, 0, 2, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 0, 0, 0, 0, -30, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 381, 380, 380, 380 }, 345));
		List<MerchantItem> dataArray28 = _dataArray;
		string config28 = LocalStringManager.GetConfig("Merchant_language", "UiName_33");
		List<PresetItemTemplateIdGroup> goods333 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 142, 1),
			new PresetItemTemplateIdGroup("Material", 158, 1),
			new PresetItemTemplateIdGroup("Material", 174, 1),
			new PresetItemTemplateIdGroup("Material", 190, 1)
		};
		List<PresetItemTemplateIdGroup> goods334 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 146, 1),
			new PresetItemTemplateIdGroup("Material", 162, 1),
			new PresetItemTemplateIdGroup("Material", 178, 1),
			new PresetItemTemplateIdGroup("Material", 194, 1),
			new PresetItemTemplateIdGroup("Material", 210, 1),
			new PresetItemTemplateIdGroup("Material", 226, 1)
		};
		List<PresetItemTemplateIdGroup> goods335 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 150, 1),
			new PresetItemTemplateIdGroup("Material", 154, 1),
			new PresetItemTemplateIdGroup("Material", 166, 1),
			new PresetItemTemplateIdGroup("Material", 182, 1),
			new PresetItemTemplateIdGroup("Material", 186, 1),
			new PresetItemTemplateIdGroup("Material", 198, 1),
			new PresetItemTemplateIdGroup("Material", 214, 1),
			new PresetItemTemplateIdGroup("Material", 218, 1),
			new PresetItemTemplateIdGroup("Material", 222, 1),
			new PresetItemTemplateIdGroup("Material", 234, 1)
		};
		List<PresetItemTemplateIdGroup> goods336 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 170, 1),
			new PresetItemTemplateIdGroup("Material", 202, 1),
			new PresetItemTemplateIdGroup("Material", 206, 1),
			new PresetItemTemplateIdGroup("Material", 230, 1)
		};
		List<PresetItemTemplateIdGroup> goods337 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 241, 1),
			new PresetItemTemplateIdGroup("Material", 248, 1),
			new PresetItemTemplateIdGroup("Material", 255, 1),
			new PresetItemTemplateIdGroup("Material", 262, 1),
			new PresetItemTemplateIdGroup("Material", 269, 1),
			new PresetItemTemplateIdGroup("Material", 276, 1)
		};
		List<PresetItemTemplateIdGroup> goods338 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 64, 1),
			new PresetItemTemplateIdGroup("Medicine", 76, 1),
			new PresetItemTemplateIdGroup("Medicine", 92, 1),
			new PresetItemTemplateIdGroup("Medicine", 104, 1)
		};
		List<PresetItemTemplateIdGroup> goods339 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 140, 1),
			new PresetItemTemplateIdGroup("Medicine", 152, 1),
			new PresetItemTemplateIdGroup("Medicine", 164, 1),
			new PresetItemTemplateIdGroup("Medicine", 176, 1),
			new PresetItemTemplateIdGroup("Medicine", 188, 1),
			new PresetItemTemplateIdGroup("Medicine", 200, 1)
		};
		List<PresetItemTemplateIdGroup> goods340 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 128, 1),
			new PresetItemTemplateIdGroup("Medicine", 212, 1),
			new PresetItemTemplateIdGroup("Medicine", 224, 1),
			new PresetItemTemplateIdGroup("Medicine", 236, 1),
			new PresetItemTemplateIdGroup("Medicine", 248, 1),
			new PresetItemTemplateIdGroup("Medicine", 260, 1),
			new PresetItemTemplateIdGroup("Medicine", 284, 1),
			new PresetItemTemplateIdGroup("Medicine", 308, 1),
			new PresetItemTemplateIdGroup("Medicine", 332, 1),
			new PresetItemTemplateIdGroup("Medicine", 344, 1)
		};
		List<PresetItemTemplateIdGroup> goods341 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 116, 1),
			new PresetItemTemplateIdGroup("Medicine", 272, 1),
			new PresetItemTemplateIdGroup("Medicine", 296, 1),
			new PresetItemTemplateIdGroup("Medicine", 320, 1)
		};
		List<PresetItemTemplateIdGroup> goods342 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 7, 1),
			new PresetItemTemplateIdGroup("Medicine", 16, 1),
			new PresetItemTemplateIdGroup("Medicine", 25, 1),
			new PresetItemTemplateIdGroup("Medicine", 34, 1),
			new PresetItemTemplateIdGroup("Medicine", 43, 1),
			new PresetItemTemplateIdGroup("Medicine", 52, 1)
		};
		List<PresetItemTemplateIdGroup> goods343 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 63, 1),
			new PresetItemTemplateIdGroup("Weapon", 72, 1),
			new PresetItemTemplateIdGroup("Weapon", 81, 1),
			new PresetItemTemplateIdGroup("Weapon", 90, 1),
			new PresetItemTemplateIdGroup("Weapon", 99, 1),
			new PresetItemTemplateIdGroup("Weapon", 108, 1)
		};
		List<PresetItemTemplateIdGroup> goods344 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 52, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods345 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray28.Add(new MerchantItem(33, 28, 4, 5, config28, 90, 1, 9, 20, 192000, goods333, goods334, goods335, goods336, goods337, goods338, goods339, goods340, goods341, goods342, goods343, goods344, goods345, goods12, new sbyte[7] { 0, 1, 2, 3, 4, 10, 11 }, new sbyte[7] { 0, 1, 2, 3, 4, 10, 11 }, new short[14]
		{
			1, 2, 3, 1, 1, -20, 1, 2, -20, 1,
			-30, -20, 0, 0
		}, new short[14]
		{
			1, 2, 3, 1, 1, -40, 1, 2, -40, 1,
			-60, -40, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 0, 0, -20, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 2, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 3, 0, 0, 0, 0, 2, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 0, 0, 0, 0, -20, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 382, 381, 381, 381 }, 350));
		List<MerchantItem> dataArray29 = _dataArray;
		string config29 = LocalStringManager.GetConfig("Merchant_language", "UiName_34");
		List<PresetItemTemplateIdGroup> goods346 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 142, 1),
			new PresetItemTemplateIdGroup("Material", 158, 1),
			new PresetItemTemplateIdGroup("Material", 174, 1),
			new PresetItemTemplateIdGroup("Material", 190, 1)
		};
		List<PresetItemTemplateIdGroup> goods347 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 146, 1),
			new PresetItemTemplateIdGroup("Material", 162, 1),
			new PresetItemTemplateIdGroup("Material", 178, 1),
			new PresetItemTemplateIdGroup("Material", 194, 1),
			new PresetItemTemplateIdGroup("Material", 210, 1),
			new PresetItemTemplateIdGroup("Material", 226, 1)
		};
		List<PresetItemTemplateIdGroup> goods348 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 150, 1),
			new PresetItemTemplateIdGroup("Material", 154, 1),
			new PresetItemTemplateIdGroup("Material", 166, 1),
			new PresetItemTemplateIdGroup("Material", 182, 1),
			new PresetItemTemplateIdGroup("Material", 186, 1),
			new PresetItemTemplateIdGroup("Material", 198, 1),
			new PresetItemTemplateIdGroup("Material", 214, 1),
			new PresetItemTemplateIdGroup("Material", 218, 1),
			new PresetItemTemplateIdGroup("Material", 222, 1),
			new PresetItemTemplateIdGroup("Material", 234, 1)
		};
		List<PresetItemTemplateIdGroup> goods349 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 170, 1),
			new PresetItemTemplateIdGroup("Material", 202, 1),
			new PresetItemTemplateIdGroup("Material", 206, 1),
			new PresetItemTemplateIdGroup("Material", 230, 1)
		};
		List<PresetItemTemplateIdGroup> goods350 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Material", 241, 1),
			new PresetItemTemplateIdGroup("Material", 248, 1),
			new PresetItemTemplateIdGroup("Material", 255, 1),
			new PresetItemTemplateIdGroup("Material", 262, 1),
			new PresetItemTemplateIdGroup("Material", 269, 1),
			new PresetItemTemplateIdGroup("Material", 276, 1)
		};
		List<PresetItemTemplateIdGroup> goods351 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 64, 1),
			new PresetItemTemplateIdGroup("Medicine", 76, 1),
			new PresetItemTemplateIdGroup("Medicine", 92, 1),
			new PresetItemTemplateIdGroup("Medicine", 104, 1)
		};
		List<PresetItemTemplateIdGroup> goods352 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 140, 1),
			new PresetItemTemplateIdGroup("Medicine", 152, 1),
			new PresetItemTemplateIdGroup("Medicine", 164, 1),
			new PresetItemTemplateIdGroup("Medicine", 176, 1),
			new PresetItemTemplateIdGroup("Medicine", 188, 1),
			new PresetItemTemplateIdGroup("Medicine", 200, 1)
		};
		List<PresetItemTemplateIdGroup> goods353 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 128, 1),
			new PresetItemTemplateIdGroup("Medicine", 212, 1),
			new PresetItemTemplateIdGroup("Medicine", 224, 1),
			new PresetItemTemplateIdGroup("Medicine", 236, 1),
			new PresetItemTemplateIdGroup("Medicine", 248, 1),
			new PresetItemTemplateIdGroup("Medicine", 260, 1),
			new PresetItemTemplateIdGroup("Medicine", 284, 1),
			new PresetItemTemplateIdGroup("Medicine", 308, 1),
			new PresetItemTemplateIdGroup("Medicine", 332, 1),
			new PresetItemTemplateIdGroup("Medicine", 344, 1)
		};
		List<PresetItemTemplateIdGroup> goods354 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 116, 1),
			new PresetItemTemplateIdGroup("Medicine", 272, 1),
			new PresetItemTemplateIdGroup("Medicine", 296, 1),
			new PresetItemTemplateIdGroup("Medicine", 320, 1)
		};
		List<PresetItemTemplateIdGroup> goods355 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Medicine", 7, 1),
			new PresetItemTemplateIdGroup("Medicine", 16, 1),
			new PresetItemTemplateIdGroup("Medicine", 25, 1),
			new PresetItemTemplateIdGroup("Medicine", 34, 1),
			new PresetItemTemplateIdGroup("Medicine", 43, 1),
			new PresetItemTemplateIdGroup("Medicine", 52, 1)
		};
		List<PresetItemTemplateIdGroup> goods356 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 64, 1),
			new PresetItemTemplateIdGroup("Weapon", 73, 1),
			new PresetItemTemplateIdGroup("Weapon", 82, 1),
			new PresetItemTemplateIdGroup("Weapon", 91, 1),
			new PresetItemTemplateIdGroup("Weapon", 100, 1),
			new PresetItemTemplateIdGroup("Weapon", 109, 1)
		};
		List<PresetItemTemplateIdGroup> goods357 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 53, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods358 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray29.Add(new MerchantItem(34, 28, 4, 6, config29, 100, 1, 12, 20, 384000, goods346, goods347, goods348, goods349, goods350, goods351, goods352, goods353, goods354, goods355, goods356, goods357, goods358, goods12, new sbyte[0], new sbyte[0], new short[14]
		{
			1, 2, 3, 1, 1, -20, 1, 2, -20, 1,
			-20, -10, 0, 0
		}, new short[14]
		{
			1, 2, 3, 1, 1, -40, 1, 2, -40, 1,
			-40, -20, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 0, 0, -20, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 2, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 3, 0, 0, 0, 0, 2, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 0, 0, 0, 0, -20, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 383, 382, 382, 382 }, 355));
		List<MerchantItem> dataArray30 = _dataArray;
		string config30 = LocalStringManager.GetConfig("Merchant_language", "UiName_35");
		List<PresetItemTemplateIdGroup> goods359 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 9, 1),
			new PresetItemTemplateIdGroup("CraftTool", 10, 1),
			new PresetItemTemplateIdGroup("CraftTool", 11, 1),
			new PresetItemTemplateIdGroup("CraftTool", 0, 1),
			new PresetItemTemplateIdGroup("CraftTool", 1, 1),
			new PresetItemTemplateIdGroup("CraftTool", 2, 1)
		};
		List<PresetItemTemplateIdGroup> goods360 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 0, 1),
			new PresetItemTemplateIdGroup("Carrier", 1, 1),
			new PresetItemTemplateIdGroup("Carrier", 9, 1),
			new PresetItemTemplateIdGroup("Carrier", 10, 1)
		};
		List<PresetItemTemplateIdGroup> goods361 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 144, 1)
		};
		List<PresetItemTemplateIdGroup> goods362 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 146, 1),
			new PresetItemTemplateIdGroup("Misc", 147, 1),
			new PresetItemTemplateIdGroup("Misc", 150, 1),
			new PresetItemTemplateIdGroup("Misc", 151, 1),
			new PresetItemTemplateIdGroup("Misc", 154, 1),
			new PresetItemTemplateIdGroup("Misc", 155, 1),
			new PresetItemTemplateIdGroup("Misc", 158, 1),
			new PresetItemTemplateIdGroup("Misc", 159, 1)
		};
		List<PresetItemTemplateIdGroup> goods363 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 207, 1),
			new PresetItemTemplateIdGroup("Misc", 208, 1),
			new PresetItemTemplateIdGroup("Misc", 211, 1),
			new PresetItemTemplateIdGroup("Misc", 212, 1),
			new PresetItemTemplateIdGroup("Misc", 166, 1),
			new PresetItemTemplateIdGroup("Misc", 167, 1),
			new PresetItemTemplateIdGroup("Misc", 215, 1),
			new PresetItemTemplateIdGroup("Misc", 216, 1)
		};
		List<PresetItemTemplateIdGroup> goods364 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 183, 1),
			new PresetItemTemplateIdGroup("Misc", 184, 1),
			new PresetItemTemplateIdGroup("Misc", 189, 1),
			new PresetItemTemplateIdGroup("Misc", 190, 1),
			new PresetItemTemplateIdGroup("Misc", 162, 1),
			new PresetItemTemplateIdGroup("Misc", 163, 1),
			new PresetItemTemplateIdGroup("Misc", 221, 1),
			new PresetItemTemplateIdGroup("Misc", 222, 1)
		};
		List<PresetItemTemplateIdGroup> goods365 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 171, 1),
			new PresetItemTemplateIdGroup("Misc", 172, 1),
			new PresetItemTemplateIdGroup("Misc", 177, 1),
			new PresetItemTemplateIdGroup("Misc", 178, 1),
			new PresetItemTemplateIdGroup("Misc", 195, 1),
			new PresetItemTemplateIdGroup("Misc", 196, 1),
			new PresetItemTemplateIdGroup("Misc", 201, 1),
			new PresetItemTemplateIdGroup("Misc", 202, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods366 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods367 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods368 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods369 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods370 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods371 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray30.Add(new MerchantItem(35, 35, 5, 0, config30, 0, 1, 3, 20, 6000, goods359, goods360, goods361, goods362, goods363, goods364, goods365, goods366, goods367, goods368, goods369, goods370, goods371, goods12, new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new short[14]
		{
			1, 2, 1, 2, 2, 2, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 1, 0, 1, 1, 1, 1, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 2, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 2, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, 2, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 377, 376, 376, 376 }, 310));
		List<MerchantItem> dataArray31 = _dataArray;
		string config31 = LocalStringManager.GetConfig("Merchant_language", "UiName_36");
		List<PresetItemTemplateIdGroup> goods372 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 12, 1),
			new PresetItemTemplateIdGroup("CraftTool", 3, 1)
		};
		List<PresetItemTemplateIdGroup> goods373 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 2, 1),
			new PresetItemTemplateIdGroup("Carrier", 11, 1)
		};
		List<PresetItemTemplateIdGroup> goods374 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 120, 1),
			new PresetItemTemplateIdGroup("Misc", 121, 1)
		};
		List<PresetItemTemplateIdGroup> goods375 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 122, 1),
			new PresetItemTemplateIdGroup("Misc", 123, 1)
		};
		List<PresetItemTemplateIdGroup> goods376 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 124, 1),
			new PresetItemTemplateIdGroup("Misc", 125, 1)
		};
		List<PresetItemTemplateIdGroup> goods377 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 126, 1),
			new PresetItemTemplateIdGroup("Misc", 127, 1)
		};
		List<PresetItemTemplateIdGroup> goods378 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 128, 1),
			new PresetItemTemplateIdGroup("Misc", 129, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods379 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods380 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods381 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods382 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods383 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods384 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray31.Add(new MerchantItem(36, 35, 5, 1, config31, 20, 1, 3, 20, 12000, goods372, goods373, goods374, goods375, goods376, goods377, goods378, goods379, goods380, goods381, goods382, goods383, goods384, goods12, new sbyte[6] { 0, 1, 3, 4, 5, 6 }, new sbyte[6] { 0, 1, 3, 4, 5, 6 }, new short[14]
		{
			1, -60, -60, -60, -60, -60, -60, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, -60, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -60, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, 0, -60, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -60, -60, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 378, 377, 377, 377 }, 330));
		List<MerchantItem> dataArray32 = _dataArray;
		string config32 = LocalStringManager.GetConfig("Merchant_language", "UiName_37");
		List<PresetItemTemplateIdGroup> goods385 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 13, 1),
			new PresetItemTemplateIdGroup("CraftTool", 4, 1)
		};
		List<PresetItemTemplateIdGroup> goods386 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 3, 1),
			new PresetItemTemplateIdGroup("Carrier", 12, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods387 = goods12;
		List<PresetItemTemplateIdGroup> goods388 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 148, 1),
			new PresetItemTemplateIdGroup("Misc", 152, 1),
			new PresetItemTemplateIdGroup("Misc", 156, 1),
			new PresetItemTemplateIdGroup("Misc", 160, 1)
		};
		List<PresetItemTemplateIdGroup> goods389 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 209, 1),
			new PresetItemTemplateIdGroup("Misc", 213, 1),
			new PresetItemTemplateIdGroup("Misc", 168, 1),
			new PresetItemTemplateIdGroup("Misc", 217, 1),
			new PresetItemTemplateIdGroup("Misc", 218, 1)
		};
		List<PresetItemTemplateIdGroup> goods390 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 185, 1),
			new PresetItemTemplateIdGroup("Misc", 186, 1),
			new PresetItemTemplateIdGroup("Misc", 191, 1),
			new PresetItemTemplateIdGroup("Misc", 192, 1),
			new PresetItemTemplateIdGroup("Misc", 164, 1),
			new PresetItemTemplateIdGroup("Misc", 223, 1)
		};
		List<PresetItemTemplateIdGroup> goods391 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 173, 1),
			new PresetItemTemplateIdGroup("Misc", 174, 1),
			new PresetItemTemplateIdGroup("Misc", 179, 1),
			new PresetItemTemplateIdGroup("Misc", 180, 1),
			new PresetItemTemplateIdGroup("Misc", 197, 1),
			new PresetItemTemplateIdGroup("Misc", 198, 1),
			new PresetItemTemplateIdGroup("Misc", 203, 1),
			new PresetItemTemplateIdGroup("Misc", 204, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods392 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods393 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods394 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods395 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods396 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods397 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray32.Add(new MerchantItem(37, 35, 5, 2, config32, 40, 1, 6, 20, 24000, goods385, goods386, goods387, goods388, goods389, goods390, goods391, goods392, goods393, goods394, goods395, goods396, goods397, goods12, new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[14]
		{
			-60, -50, 0, 1, 1, 1, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 1, 0, 1, 1, 1, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, 0, 2, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 379, 378, 378, 378 }, 335));
		List<MerchantItem> dataArray33 = _dataArray;
		string config33 = LocalStringManager.GetConfig("Merchant_language", "UiName_38");
		List<PresetItemTemplateIdGroup> goods398 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 14, 1),
			new PresetItemTemplateIdGroup("CraftTool", 5, 1)
		};
		List<PresetItemTemplateIdGroup> goods399 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 4, 1),
			new PresetItemTemplateIdGroup("Carrier", 13, 1)
		};
		List<PresetItemTemplateIdGroup> goods400 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 130, 1),
			new PresetItemTemplateIdGroup("Misc", 131, 1),
			new PresetItemTemplateIdGroup("Misc", 132, 1)
		};
		List<PresetItemTemplateIdGroup> goods401 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 133, 1),
			new PresetItemTemplateIdGroup("Misc", 134, 1),
			new PresetItemTemplateIdGroup("Misc", 135, 1)
		};
		List<PresetItemTemplateIdGroup> goods402 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 136, 1),
			new PresetItemTemplateIdGroup("Misc", 137, 1),
			new PresetItemTemplateIdGroup("Misc", 138, 1),
			new PresetItemTemplateIdGroup("Misc", 139, 1)
		};
		List<PresetItemTemplateIdGroup> goods403 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 140, 1),
			new PresetItemTemplateIdGroup("Misc", 141, 1),
			new PresetItemTemplateIdGroup("Misc", 142, 1),
			new PresetItemTemplateIdGroup("Misc", 143, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods404 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods405 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods406 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods407 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods408 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods409 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods410 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray33.Add(new MerchantItem(38, 35, 5, 3, config33, 60, 1, 6, 20, 48000, goods398, goods399, goods400, goods401, goods402, goods403, goods404, goods405, goods406, goods407, goods408, goods409, goods410, goods12, new sbyte[6] { 0, 1, 3, 4, 5, 6 }, new sbyte[6] { 0, 1, 3, 4, 5, 6 }, new short[14]
		{
			-50, -40, -40, 1, 1, 1, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, -80, -80, 1, 1, 1, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -40, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 380, 379, 379, 379 }, 340));
		List<MerchantItem> dataArray34 = _dataArray;
		string config34 = LocalStringManager.GetConfig("Merchant_language", "UiName_39");
		List<PresetItemTemplateIdGroup> goods411 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 15, 1),
			new PresetItemTemplateIdGroup("CraftTool", 6, 1)
		};
		List<PresetItemTemplateIdGroup> goods412 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 5, 1),
			new PresetItemTemplateIdGroup("Carrier", 14, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods413 = goods12;
		List<PresetItemTemplateIdGroup> goods414 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 149, 1),
			new PresetItemTemplateIdGroup("Misc", 153, 1),
			new PresetItemTemplateIdGroup("Misc", 157, 1),
			new PresetItemTemplateIdGroup("Misc", 161, 1)
		};
		List<PresetItemTemplateIdGroup> goods415 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 210, 1),
			new PresetItemTemplateIdGroup("Misc", 214, 1),
			new PresetItemTemplateIdGroup("Misc", 169, 1),
			new PresetItemTemplateIdGroup("Misc", 170, 1),
			new PresetItemTemplateIdGroup("Misc", 219, 1)
		};
		List<PresetItemTemplateIdGroup> goods416 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 187, 1),
			new PresetItemTemplateIdGroup("Misc", 193, 1),
			new PresetItemTemplateIdGroup("Misc", 165, 1),
			new PresetItemTemplateIdGroup("Misc", 224, 1)
		};
		List<PresetItemTemplateIdGroup> goods417 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 175, 1),
			new PresetItemTemplateIdGroup("Misc", 181, 1),
			new PresetItemTemplateIdGroup("Misc", 199, 1),
			new PresetItemTemplateIdGroup("Misc", 205, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods418 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods419 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods420 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods421 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods422 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods423 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray34.Add(new MerchantItem(39, 35, 5, 4, config34, 80, 1, 9, 20, 96000, goods411, goods412, goods413, goods414, goods415, goods416, goods417, goods418, goods419, goods420, goods421, goods422, goods423, goods12, new sbyte[6] { 0, 1, 2, 4, 5, 6 }, new sbyte[6] { 0, 1, 2, 4, 5, 6 }, new short[14]
		{
			-40, -30, 0, -30, -30, -30, -30, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-80, -60, 0, -60, -60, -60, -60, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, -30, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, 0, -30, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, -30, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, -30, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 381, 380, 380, 380 }, 345));
		List<MerchantItem> dataArray35 = _dataArray;
		string config35 = LocalStringManager.GetConfig("Merchant_language", "UiName_40");
		List<PresetItemTemplateIdGroup> goods424 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 16, 1),
			new PresetItemTemplateIdGroup("CraftTool", 7, 1)
		};
		List<PresetItemTemplateIdGroup> goods425 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 6, 1),
			new PresetItemTemplateIdGroup("Carrier", 15, 1)
		};
		List<PresetItemTemplateIdGroup> goods426 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 145, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods427 = goods12;
		List<PresetItemTemplateIdGroup> goods428 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 220, 1)
		};
		List<PresetItemTemplateIdGroup> goods429 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 188, 1),
			new PresetItemTemplateIdGroup("Misc", 194, 1)
		};
		List<PresetItemTemplateIdGroup> goods430 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 176, 1),
			new PresetItemTemplateIdGroup("Misc", 182, 1),
			new PresetItemTemplateIdGroup("Misc", 200, 1),
			new PresetItemTemplateIdGroup("Misc", 206, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods431 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods432 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods433 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods434 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods435 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods436 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray35.Add(new MerchantItem(40, 35, 5, 5, config35, 90, 1, 9, 20, 192000, goods424, goods425, goods426, goods427, goods428, goods429, goods430, goods431, goods432, goods433, goods434, goods435, goods436, goods12, new sbyte[6] { 0, 1, 2, 4, 5, 6 }, new sbyte[6] { 0, 1, 2, 4, 5, 6 }, new short[14]
		{
			-30, -20, -20, 0, -20, -20, -20, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-60, -40, -40, 0, -40, -40, -40, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14], new short[14]
		{
			0, 0, 0, 0, 0, 0, -20, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, -20, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -20, 0, 0, -20, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 382, 381, 381, 381 }, 350));
		List<MerchantItem> dataArray36 = _dataArray;
		string config36 = LocalStringManager.GetConfig("Merchant_language", "UiName_41");
		List<PresetItemTemplateIdGroup> goods437 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 17, 1),
			new PresetItemTemplateIdGroup("CraftTool", 8, 1)
		};
		List<PresetItemTemplateIdGroup> goods438 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Carrier", 7, 1),
			new PresetItemTemplateIdGroup("Carrier", 16, 1)
		};
		List<PresetItemTemplateIdGroup> goods439 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 145, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods440 = goods12;
		List<PresetItemTemplateIdGroup> goods441 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 220, 1)
		};
		List<PresetItemTemplateIdGroup> goods442 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 188, 1),
			new PresetItemTemplateIdGroup("Misc", 194, 1)
		};
		List<PresetItemTemplateIdGroup> goods443 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 176, 1),
			new PresetItemTemplateIdGroup("Misc", 182, 1),
			new PresetItemTemplateIdGroup("Misc", 200, 1),
			new PresetItemTemplateIdGroup("Misc", 206, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods444 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods445 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods446 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods447 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods448 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods449 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray36.Add(new MerchantItem(41, 35, 5, 6, config36, 100, 1, 12, 20, 384000, goods437, goods438, goods439, goods440, goods441, goods442, goods443, goods444, goods445, goods446, goods447, goods448, goods449, goods12, new sbyte[0], new sbyte[0], new short[14]
		{
			-20, -10, -20, 0, -20, -20, -20, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			-40, -20, -40, 0, -40, -40, -40, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14], new short[14]
		{
			0, 0, 0, 0, 0, 0, -20, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, -20, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, -20, 0, 0, -20, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 383, 382, 382, 382 }, 355));
		_dataArray.Add(new MerchantItem(42, 42, 6, 0, LocalStringManager.GetConfig("Merchant_language", "UiName_42"), 0, 1, 3, 20, 6000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Clothing", 0, 1),
			new PresetItemTemplateIdGroup("Clothing", 1, 1),
			new PresetItemTemplateIdGroup("Clothing", 2, 1),
			new PresetItemTemplateIdGroup("Clothing", 9, 1),
			new PresetItemTemplateIdGroup("Clothing", 10, 1),
			new PresetItemTemplateIdGroup("Clothing", 11, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 219, 1),
			new PresetItemTemplateIdGroup("Weapon", 220, 1),
			new PresetItemTemplateIdGroup("Weapon", 228, 1),
			new PresetItemTemplateIdGroup("Weapon", 229, 1),
			new PresetItemTemplateIdGroup("Weapon", 237, 1),
			new PresetItemTemplateIdGroup("Weapon", 238, 1),
			new PresetItemTemplateIdGroup("Weapon", 246, 1),
			new PresetItemTemplateIdGroup("Weapon", 247, 1),
			new PresetItemTemplateIdGroup("Weapon", 255, 1),
			new PresetItemTemplateIdGroup("Weapon", 256, 1),
			new PresetItemTemplateIdGroup("Weapon", 264, 1),
			new PresetItemTemplateIdGroup("Weapon", 265, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 345, 1),
			new PresetItemTemplateIdGroup("Weapon", 346, 1),
			new PresetItemTemplateIdGroup("Weapon", 354, 1),
			new PresetItemTemplateIdGroup("Weapon", 355, 1),
			new PresetItemTemplateIdGroup("Weapon", 363, 1),
			new PresetItemTemplateIdGroup("Weapon", 364, 1),
			new PresetItemTemplateIdGroup("Weapon", 372, 1),
			new PresetItemTemplateIdGroup("Weapon", 373, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 705, 1),
			new PresetItemTemplateIdGroup("Weapon", 706, 1),
			new PresetItemTemplateIdGroup("Weapon", 714, 1),
			new PresetItemTemplateIdGroup("Weapon", 715, 1),
			new PresetItemTemplateIdGroup("Weapon", 723, 1),
			new PresetItemTemplateIdGroup("Weapon", 724, 1),
			new PresetItemTemplateIdGroup("Weapon", 732, 1),
			new PresetItemTemplateIdGroup("Weapon", 733, 1),
			new PresetItemTemplateIdGroup("Weapon", 741, 1),
			new PresetItemTemplateIdGroup("Weapon", 742, 1),
			new PresetItemTemplateIdGroup("Weapon", 750, 1),
			new PresetItemTemplateIdGroup("Weapon", 751, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 759, 1),
			new PresetItemTemplateIdGroup("Weapon", 760, 1),
			new PresetItemTemplateIdGroup("Weapon", 768, 1),
			new PresetItemTemplateIdGroup("Weapon", 769, 1),
			new PresetItemTemplateIdGroup("Weapon", 777, 1),
			new PresetItemTemplateIdGroup("Weapon", 778, 1),
			new PresetItemTemplateIdGroup("Weapon", 786, 1),
			new PresetItemTemplateIdGroup("Weapon", 787, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 813, 1),
			new PresetItemTemplateIdGroup("Weapon", 814, 1),
			new PresetItemTemplateIdGroup("Weapon", 822, 1),
			new PresetItemTemplateIdGroup("Weapon", 823, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 18, 1),
			new PresetItemTemplateIdGroup("Armor", 19, 1),
			new PresetItemTemplateIdGroup("Armor", 27, 1),
			new PresetItemTemplateIdGroup("Armor", 28, 1),
			new PresetItemTemplateIdGroup("Armor", 36, 1),
			new PresetItemTemplateIdGroup("Armor", 37, 1),
			new PresetItemTemplateIdGroup("Armor", 45, 1),
			new PresetItemTemplateIdGroup("Armor", 46, 1),
			new PresetItemTemplateIdGroup("Armor", 54, 1),
			new PresetItemTemplateIdGroup("Armor", 55, 1),
			new PresetItemTemplateIdGroup("Armor", 63, 1),
			new PresetItemTemplateIdGroup("Armor", 64, 1),
			new PresetItemTemplateIdGroup("Armor", 72, 1),
			new PresetItemTemplateIdGroup("Armor", 73, 1),
			new PresetItemTemplateIdGroup("Armor", 81, 1),
			new PresetItemTemplateIdGroup("Armor", 82, 1),
			new PresetItemTemplateIdGroup("Armor", 90, 1),
			new PresetItemTemplateIdGroup("Armor", 91, 1),
			new PresetItemTemplateIdGroup("Armor", 99, 1),
			new PresetItemTemplateIdGroup("Armor", 100, 1),
			new PresetItemTemplateIdGroup("Armor", 108, 1),
			new PresetItemTemplateIdGroup("Armor", 109, 1),
			new PresetItemTemplateIdGroup("Armor", 117, 1),
			new PresetItemTemplateIdGroup("Armor", 118, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 144, 1),
			new PresetItemTemplateIdGroup("Armor", 145, 1),
			new PresetItemTemplateIdGroup("Armor", 153, 1),
			new PresetItemTemplateIdGroup("Armor", 154, 1),
			new PresetItemTemplateIdGroup("Armor", 162, 1),
			new PresetItemTemplateIdGroup("Armor", 163, 1),
			new PresetItemTemplateIdGroup("Armor", 171, 1),
			new PresetItemTemplateIdGroup("Armor", 172, 1),
			new PresetItemTemplateIdGroup("Armor", 180, 1),
			new PresetItemTemplateIdGroup("Armor", 181, 1),
			new PresetItemTemplateIdGroup("Armor", 189, 1),
			new PresetItemTemplateIdGroup("Armor", 190, 1),
			new PresetItemTemplateIdGroup("Armor", 198, 1),
			new PresetItemTemplateIdGroup("Armor", 199, 1),
			new PresetItemTemplateIdGroup("Armor", 207, 1),
			new PresetItemTemplateIdGroup("Armor", 208, 1),
			new PresetItemTemplateIdGroup("Armor", 216, 1),
			new PresetItemTemplateIdGroup("Armor", 217, 1),
			new PresetItemTemplateIdGroup("Armor", 225, 1),
			new PresetItemTemplateIdGroup("Armor", 226, 1),
			new PresetItemTemplateIdGroup("Armor", 234, 1),
			new PresetItemTemplateIdGroup("Armor", 235, 1),
			new PresetItemTemplateIdGroup("Armor", 243, 1),
			new PresetItemTemplateIdGroup("Armor", 244, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 306, 1),
			new PresetItemTemplateIdGroup("Armor", 307, 1),
			new PresetItemTemplateIdGroup("Armor", 315, 1),
			new PresetItemTemplateIdGroup("Armor", 316, 1),
			new PresetItemTemplateIdGroup("Armor", 324, 1),
			new PresetItemTemplateIdGroup("Armor", 325, 1),
			new PresetItemTemplateIdGroup("Armor", 333, 1),
			new PresetItemTemplateIdGroup("Armor", 334, 1),
			new PresetItemTemplateIdGroup("Armor", 342, 1),
			new PresetItemTemplateIdGroup("Armor", 343, 1),
			new PresetItemTemplateIdGroup("Armor", 351, 1),
			new PresetItemTemplateIdGroup("Armor", 352, 1),
			new PresetItemTemplateIdGroup("Armor", 360, 1),
			new PresetItemTemplateIdGroup("Armor", 361, 1),
			new PresetItemTemplateIdGroup("Armor", 369, 1),
			new PresetItemTemplateIdGroup("Armor", 370, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 414, 1),
			new PresetItemTemplateIdGroup("Armor", 415, 1),
			new PresetItemTemplateIdGroup("Armor", 423, 1),
			new PresetItemTemplateIdGroup("Armor", 424, 1),
			new PresetItemTemplateIdGroup("Armor", 504, 1),
			new PresetItemTemplateIdGroup("Armor", 505, 1),
			new PresetItemTemplateIdGroup("Armor", 513, 1),
			new PresetItemTemplateIdGroup("Armor", 514, 1),
			new PresetItemTemplateIdGroup("Armor", 432, 1),
			new PresetItemTemplateIdGroup("Armor", 433, 1),
			new PresetItemTemplateIdGroup("Armor", 468, 1),
			new PresetItemTemplateIdGroup("Armor", 469, 1),
			new PresetItemTemplateIdGroup("Armor", 441, 1),
			new PresetItemTemplateIdGroup("Armor", 442, 1),
			new PresetItemTemplateIdGroup("Armor", 477, 1),
			new PresetItemTemplateIdGroup("Armor", 478, 1),
			new PresetItemTemplateIdGroup("Armor", 450, 1),
			new PresetItemTemplateIdGroup("Armor", 451, 1),
			new PresetItemTemplateIdGroup("Armor", 486, 1),
			new PresetItemTemplateIdGroup("Armor", 487, 1),
			new PresetItemTemplateIdGroup("Armor", 459, 1),
			new PresetItemTemplateIdGroup("Armor", 460, 1),
			new PresetItemTemplateIdGroup("Armor", 495, 1),
			new PresetItemTemplateIdGroup("Armor", 496, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 18, 1),
			new PresetItemTemplateIdGroup("Accessory", 19, 1),
			new PresetItemTemplateIdGroup("Accessory", 27, 1),
			new PresetItemTemplateIdGroup("Accessory", 28, 1),
			new PresetItemTemplateIdGroup("Accessory", 36, 1),
			new PresetItemTemplateIdGroup("Accessory", 37, 1),
			new PresetItemTemplateIdGroup("Accessory", 45, 1),
			new PresetItemTemplateIdGroup("Accessory", 46, 1),
			new PresetItemTemplateIdGroup("Accessory", 54, 1),
			new PresetItemTemplateIdGroup("Accessory", 55, 1),
			new PresetItemTemplateIdGroup("Accessory", 63, 1),
			new PresetItemTemplateIdGroup("Accessory", 64, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 72, 1),
			new PresetItemTemplateIdGroup("Accessory", 73, 1),
			new PresetItemTemplateIdGroup("Accessory", 81, 1),
			new PresetItemTemplateIdGroup("Accessory", 82, 1),
			new PresetItemTemplateIdGroup("Accessory", 99, 1),
			new PresetItemTemplateIdGroup("Accessory", 100, 1),
			new PresetItemTemplateIdGroup("Accessory", 108, 1),
			new PresetItemTemplateIdGroup("Accessory", 109, 1),
			new PresetItemTemplateIdGroup("Accessory", 117, 1),
			new PresetItemTemplateIdGroup("Accessory", 118, 1),
			new PresetItemTemplateIdGroup("Accessory", 126, 1),
			new PresetItemTemplateIdGroup("Accessory", 127, 1),
			new PresetItemTemplateIdGroup("Accessory", 135, 1),
			new PresetItemTemplateIdGroup("Accessory", 136, 1),
			new PresetItemTemplateIdGroup("Accessory", 144, 1),
			new PresetItemTemplateIdGroup("Accessory", 145, 1),
			new PresetItemTemplateIdGroup("Accessory", 153, 1),
			new PresetItemTemplateIdGroup("Accessory", 154, 1),
			new PresetItemTemplateIdGroup("Accessory", 162, 1),
			new PresetItemTemplateIdGroup("Accessory", 163, 1),
			new PresetItemTemplateIdGroup("Accessory", 171, 1),
			new PresetItemTemplateIdGroup("Accessory", 172, 1),
			new PresetItemTemplateIdGroup("Accessory", 180, 1),
			new PresetItemTemplateIdGroup("Accessory", 181, 1),
			new PresetItemTemplateIdGroup("Accessory", 189, 1),
			new PresetItemTemplateIdGroup("Accessory", 190, 1),
			new PresetItemTemplateIdGroup("Accessory", 198, 1),
			new PresetItemTemplateIdGroup("Accessory", 199, 1),
			new PresetItemTemplateIdGroup("Accessory", 207, 1),
			new PresetItemTemplateIdGroup("Accessory", 208, 1),
			new PresetItemTemplateIdGroup("Accessory", 216, 1),
			new PresetItemTemplateIdGroup("Accessory", 217, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 18, 1),
			new PresetItemTemplateIdGroup("CraftTool", 19, 1),
			new PresetItemTemplateIdGroup("CraftTool", 20, 1),
			new PresetItemTemplateIdGroup("CraftTool", 0, 1),
			new PresetItemTemplateIdGroup("CraftTool", 1, 1),
			new PresetItemTemplateIdGroup("CraftTool", 2, 1),
			new PresetItemTemplateIdGroup("CraftTool", 27, 1),
			new PresetItemTemplateIdGroup("CraftTool", 28, 1),
			new PresetItemTemplateIdGroup("CraftTool", 29, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 91, 2),
			new PresetItemTemplateIdGroup("Misc", 92, 1),
			new PresetItemTemplateIdGroup("Misc", 93, 1)
		}, new sbyte[12]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			12, 13
		}, new sbyte[12]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			12, 13
		}, new short[14]
		{
			2, 3, 2, 3, 2, 1, 6, 6, 4, 6,
			3, 8, 3, 1
		}, new short[14]
		{
			1, 2, 1, 2, 1, 1, 3, 3, 2, 3,
			2, 4, 2, 1
		}, new short[14]
		{
			2, 0, 2, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 2, 0, 0, 0, 0, 0,
			3, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 8, 0, 1
		}, new short[14]
		{
			0, 3, 0, 3, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 377, 376, 376, 376 }, 310));
		_dataArray.Add(new MerchantItem(43, 42, 6, 1, LocalStringManager.GetConfig("Merchant_language", "UiName_43"), 20, 1, 3, 20, 12000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Clothing", 3, 1),
			new PresetItemTemplateIdGroup("Clothing", 12, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 221, 1),
			new PresetItemTemplateIdGroup("Weapon", 230, 1),
			new PresetItemTemplateIdGroup("Weapon", 239, 1),
			new PresetItemTemplateIdGroup("Weapon", 248, 1),
			new PresetItemTemplateIdGroup("Weapon", 257, 1),
			new PresetItemTemplateIdGroup("Weapon", 266, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 347, 1),
			new PresetItemTemplateIdGroup("Weapon", 356, 1),
			new PresetItemTemplateIdGroup("Weapon", 365, 1),
			new PresetItemTemplateIdGroup("Weapon", 374, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 707, 1),
			new PresetItemTemplateIdGroup("Weapon", 716, 1),
			new PresetItemTemplateIdGroup("Weapon", 725, 1),
			new PresetItemTemplateIdGroup("Weapon", 734, 1),
			new PresetItemTemplateIdGroup("Weapon", 743, 1),
			new PresetItemTemplateIdGroup("Weapon", 752, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 761, 1),
			new PresetItemTemplateIdGroup("Weapon", 770, 1),
			new PresetItemTemplateIdGroup("Weapon", 779, 1),
			new PresetItemTemplateIdGroup("Weapon", 788, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 815, 1),
			new PresetItemTemplateIdGroup("Weapon", 824, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 20, 1),
			new PresetItemTemplateIdGroup("Armor", 29, 1),
			new PresetItemTemplateIdGroup("Armor", 38, 1),
			new PresetItemTemplateIdGroup("Armor", 47, 1),
			new PresetItemTemplateIdGroup("Armor", 56, 1),
			new PresetItemTemplateIdGroup("Armor", 65, 1),
			new PresetItemTemplateIdGroup("Armor", 74, 1),
			new PresetItemTemplateIdGroup("Armor", 83, 1),
			new PresetItemTemplateIdGroup("Armor", 92, 1),
			new PresetItemTemplateIdGroup("Armor", 101, 1),
			new PresetItemTemplateIdGroup("Armor", 110, 1),
			new PresetItemTemplateIdGroup("Armor", 119, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 146, 1),
			new PresetItemTemplateIdGroup("Armor", 155, 1),
			new PresetItemTemplateIdGroup("Armor", 164, 1),
			new PresetItemTemplateIdGroup("Armor", 173, 1),
			new PresetItemTemplateIdGroup("Armor", 182, 1),
			new PresetItemTemplateIdGroup("Armor", 191, 1),
			new PresetItemTemplateIdGroup("Armor", 200, 1),
			new PresetItemTemplateIdGroup("Armor", 209, 1),
			new PresetItemTemplateIdGroup("Armor", 218, 1),
			new PresetItemTemplateIdGroup("Armor", 227, 1),
			new PresetItemTemplateIdGroup("Armor", 236, 1),
			new PresetItemTemplateIdGroup("Armor", 245, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 308, 1),
			new PresetItemTemplateIdGroup("Armor", 317, 1),
			new PresetItemTemplateIdGroup("Armor", 326, 1),
			new PresetItemTemplateIdGroup("Armor", 335, 1),
			new PresetItemTemplateIdGroup("Armor", 344, 1),
			new PresetItemTemplateIdGroup("Armor", 353, 1),
			new PresetItemTemplateIdGroup("Armor", 362, 1),
			new PresetItemTemplateIdGroup("Armor", 371, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 416, 1),
			new PresetItemTemplateIdGroup("Armor", 425, 1),
			new PresetItemTemplateIdGroup("Armor", 506, 1),
			new PresetItemTemplateIdGroup("Armor", 515, 1),
			new PresetItemTemplateIdGroup("Armor", 434, 1),
			new PresetItemTemplateIdGroup("Armor", 470, 1),
			new PresetItemTemplateIdGroup("Armor", 443, 1),
			new PresetItemTemplateIdGroup("Armor", 479, 1),
			new PresetItemTemplateIdGroup("Armor", 452, 1),
			new PresetItemTemplateIdGroup("Armor", 488, 1),
			new PresetItemTemplateIdGroup("Armor", 461, 1),
			new PresetItemTemplateIdGroup("Armor", 497, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 20, 1),
			new PresetItemTemplateIdGroup("Accessory", 29, 1),
			new PresetItemTemplateIdGroup("Accessory", 38, 1),
			new PresetItemTemplateIdGroup("Accessory", 47, 1),
			new PresetItemTemplateIdGroup("Accessory", 56, 1),
			new PresetItemTemplateIdGroup("Accessory", 65, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 74, 1),
			new PresetItemTemplateIdGroup("Accessory", 83, 1),
			new PresetItemTemplateIdGroup("Accessory", 101, 1),
			new PresetItemTemplateIdGroup("Accessory", 110, 1),
			new PresetItemTemplateIdGroup("Accessory", 119, 1),
			new PresetItemTemplateIdGroup("Accessory", 128, 1),
			new PresetItemTemplateIdGroup("Accessory", 137, 1),
			new PresetItemTemplateIdGroup("Accessory", 146, 1),
			new PresetItemTemplateIdGroup("Accessory", 155, 1),
			new PresetItemTemplateIdGroup("Accessory", 164, 1),
			new PresetItemTemplateIdGroup("Accessory", 173, 1),
			new PresetItemTemplateIdGroup("Accessory", 182, 1),
			new PresetItemTemplateIdGroup("Accessory", 191, 1),
			new PresetItemTemplateIdGroup("Accessory", 200, 1),
			new PresetItemTemplateIdGroup("Accessory", 209, 1),
			new PresetItemTemplateIdGroup("Accessory", 218, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 21, 1),
			new PresetItemTemplateIdGroup("CraftTool", 3, 1),
			new PresetItemTemplateIdGroup("CraftTool", 30, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 94, 1)
		}, new sbyte[12]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			12, 13
		}, new sbyte[12]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			12, 13
		}, new short[14]
		{
			-60, 2, 1, 2, 1, 1, 3, 3, 2, 3,
			2, 4, 1, -60
		}, new short[14]
		{
			1, 1, 1, 1, 1, 1, 2, 2, 1, 2,
			1, 2, 1, 1
		}, new short[14]
		{
			-60, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			2, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 4, 0, -60
		}, new short[14]
		{
			0, 2, 0, 2, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 378, 377, 377, 377 }, 330));
		_dataArray.Add(new MerchantItem(44, 42, 6, 2, LocalStringManager.GetConfig("Merchant_language", "UiName_44"), 40, 1, 6, 20, 24000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Clothing", 4, 1),
			new PresetItemTemplateIdGroup("Clothing", 13, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 222, 1),
			new PresetItemTemplateIdGroup("Weapon", 231, 1),
			new PresetItemTemplateIdGroup("Weapon", 240, 1),
			new PresetItemTemplateIdGroup("Weapon", 249, 1),
			new PresetItemTemplateIdGroup("Weapon", 258, 1),
			new PresetItemTemplateIdGroup("Weapon", 267, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 348, 1),
			new PresetItemTemplateIdGroup("Weapon", 357, 1),
			new PresetItemTemplateIdGroup("Weapon", 366, 1),
			new PresetItemTemplateIdGroup("Weapon", 375, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 708, 1),
			new PresetItemTemplateIdGroup("Weapon", 717, 1),
			new PresetItemTemplateIdGroup("Weapon", 726, 1),
			new PresetItemTemplateIdGroup("Weapon", 735, 1),
			new PresetItemTemplateIdGroup("Weapon", 744, 1),
			new PresetItemTemplateIdGroup("Weapon", 753, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 762, 1),
			new PresetItemTemplateIdGroup("Weapon", 771, 1),
			new PresetItemTemplateIdGroup("Weapon", 780, 1),
			new PresetItemTemplateIdGroup("Weapon", 789, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 816, 1),
			new PresetItemTemplateIdGroup("Weapon", 825, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 21, 1),
			new PresetItemTemplateIdGroup("Armor", 30, 1),
			new PresetItemTemplateIdGroup("Armor", 39, 1),
			new PresetItemTemplateIdGroup("Armor", 48, 1),
			new PresetItemTemplateIdGroup("Armor", 57, 1),
			new PresetItemTemplateIdGroup("Armor", 66, 1),
			new PresetItemTemplateIdGroup("Armor", 75, 1),
			new PresetItemTemplateIdGroup("Armor", 84, 1),
			new PresetItemTemplateIdGroup("Armor", 93, 1),
			new PresetItemTemplateIdGroup("Armor", 102, 1),
			new PresetItemTemplateIdGroup("Armor", 111, 1),
			new PresetItemTemplateIdGroup("Armor", 120, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 147, 1),
			new PresetItemTemplateIdGroup("Armor", 156, 1),
			new PresetItemTemplateIdGroup("Armor", 165, 1),
			new PresetItemTemplateIdGroup("Armor", 174, 1),
			new PresetItemTemplateIdGroup("Armor", 183, 1),
			new PresetItemTemplateIdGroup("Armor", 192, 1),
			new PresetItemTemplateIdGroup("Armor", 201, 1),
			new PresetItemTemplateIdGroup("Armor", 210, 1),
			new PresetItemTemplateIdGroup("Armor", 219, 1),
			new PresetItemTemplateIdGroup("Armor", 228, 1),
			new PresetItemTemplateIdGroup("Armor", 237, 1),
			new PresetItemTemplateIdGroup("Armor", 246, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 309, 1),
			new PresetItemTemplateIdGroup("Armor", 318, 1),
			new PresetItemTemplateIdGroup("Armor", 327, 1),
			new PresetItemTemplateIdGroup("Armor", 336, 1),
			new PresetItemTemplateIdGroup("Armor", 345, 1),
			new PresetItemTemplateIdGroup("Armor", 354, 1),
			new PresetItemTemplateIdGroup("Armor", 363, 1),
			new PresetItemTemplateIdGroup("Armor", 372, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 417, 1),
			new PresetItemTemplateIdGroup("Armor", 426, 1),
			new PresetItemTemplateIdGroup("Armor", 507, 1),
			new PresetItemTemplateIdGroup("Armor", 516, 1),
			new PresetItemTemplateIdGroup("Armor", 435, 1),
			new PresetItemTemplateIdGroup("Armor", 471, 1),
			new PresetItemTemplateIdGroup("Armor", 444, 1),
			new PresetItemTemplateIdGroup("Armor", 480, 1),
			new PresetItemTemplateIdGroup("Armor", 453, 1),
			new PresetItemTemplateIdGroup("Armor", 489, 1),
			new PresetItemTemplateIdGroup("Armor", 462, 1),
			new PresetItemTemplateIdGroup("Armor", 498, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 21, 1),
			new PresetItemTemplateIdGroup("Accessory", 30, 1),
			new PresetItemTemplateIdGroup("Accessory", 39, 1),
			new PresetItemTemplateIdGroup("Accessory", 48, 1),
			new PresetItemTemplateIdGroup("Accessory", 57, 1),
			new PresetItemTemplateIdGroup("Accessory", 66, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 75, 1),
			new PresetItemTemplateIdGroup("Accessory", 84, 1),
			new PresetItemTemplateIdGroup("Accessory", 102, 1),
			new PresetItemTemplateIdGroup("Accessory", 111, 1),
			new PresetItemTemplateIdGroup("Accessory", 120, 1),
			new PresetItemTemplateIdGroup("Accessory", 129, 1),
			new PresetItemTemplateIdGroup("Accessory", 138, 1),
			new PresetItemTemplateIdGroup("Accessory", 147, 1),
			new PresetItemTemplateIdGroup("Accessory", 156, 1),
			new PresetItemTemplateIdGroup("Accessory", 165, 1),
			new PresetItemTemplateIdGroup("Accessory", 174, 1),
			new PresetItemTemplateIdGroup("Accessory", 183, 1),
			new PresetItemTemplateIdGroup("Accessory", 192, 1),
			new PresetItemTemplateIdGroup("Accessory", 201, 1),
			new PresetItemTemplateIdGroup("Accessory", 210, 1),
			new PresetItemTemplateIdGroup("Accessory", 219, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 22, 1),
			new PresetItemTemplateIdGroup("CraftTool", 4, 1),
			new PresetItemTemplateIdGroup("CraftTool", 31, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 95, 1)
		}, new sbyte[12]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			12, 13
		}, new sbyte[12]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			12, 13
		}, new short[14]
		{
			-50, 1, 1, 1, 1, -60, 3, 3, 2, 3,
			1, 4, 1, -50
		}, new short[14]
		{
			1, 1, 1, 1, 1, 1, 2, 2, 1, 2,
			1, 2, 1, 1
		}, new short[14]
		{
			-50, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			1, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, -60, 0, 0, 0, 0,
			0, 4, 0, -50
		}, new short[14]
		{
			0, 1, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 379, 378, 378, 378 }, 335));
		_dataArray.Add(new MerchantItem(45, 42, 6, 3, LocalStringManager.GetConfig("Merchant_language", "UiName_45"), 60, 1, 6, 20, 48000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Clothing", 5, 1),
			new PresetItemTemplateIdGroup("Clothing", 14, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 223, 1),
			new PresetItemTemplateIdGroup("Weapon", 232, 1),
			new PresetItemTemplateIdGroup("Weapon", 241, 1),
			new PresetItemTemplateIdGroup("Weapon", 250, 1),
			new PresetItemTemplateIdGroup("Weapon", 259, 1),
			new PresetItemTemplateIdGroup("Weapon", 268, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 349, 1),
			new PresetItemTemplateIdGroup("Weapon", 358, 1),
			new PresetItemTemplateIdGroup("Weapon", 367, 1),
			new PresetItemTemplateIdGroup("Weapon", 376, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 709, 1),
			new PresetItemTemplateIdGroup("Weapon", 718, 1),
			new PresetItemTemplateIdGroup("Weapon", 727, 1),
			new PresetItemTemplateIdGroup("Weapon", 736, 1),
			new PresetItemTemplateIdGroup("Weapon", 745, 1),
			new PresetItemTemplateIdGroup("Weapon", 754, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 763, 1),
			new PresetItemTemplateIdGroup("Weapon", 772, 1),
			new PresetItemTemplateIdGroup("Weapon", 781, 1),
			new PresetItemTemplateIdGroup("Weapon", 790, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 817, 1),
			new PresetItemTemplateIdGroup("Weapon", 826, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 22, 1),
			new PresetItemTemplateIdGroup("Armor", 31, 1),
			new PresetItemTemplateIdGroup("Armor", 40, 1),
			new PresetItemTemplateIdGroup("Armor", 49, 1),
			new PresetItemTemplateIdGroup("Armor", 58, 1),
			new PresetItemTemplateIdGroup("Armor", 67, 1),
			new PresetItemTemplateIdGroup("Armor", 76, 1),
			new PresetItemTemplateIdGroup("Armor", 85, 1),
			new PresetItemTemplateIdGroup("Armor", 94, 1),
			new PresetItemTemplateIdGroup("Armor", 103, 1),
			new PresetItemTemplateIdGroup("Armor", 112, 1),
			new PresetItemTemplateIdGroup("Armor", 121, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 148, 1),
			new PresetItemTemplateIdGroup("Armor", 157, 1),
			new PresetItemTemplateIdGroup("Armor", 166, 1),
			new PresetItemTemplateIdGroup("Armor", 175, 1),
			new PresetItemTemplateIdGroup("Armor", 184, 1),
			new PresetItemTemplateIdGroup("Armor", 193, 1),
			new PresetItemTemplateIdGroup("Armor", 202, 1),
			new PresetItemTemplateIdGroup("Armor", 211, 1),
			new PresetItemTemplateIdGroup("Armor", 220, 1),
			new PresetItemTemplateIdGroup("Armor", 229, 1),
			new PresetItemTemplateIdGroup("Armor", 238, 1),
			new PresetItemTemplateIdGroup("Armor", 247, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 310, 1),
			new PresetItemTemplateIdGroup("Armor", 319, 1),
			new PresetItemTemplateIdGroup("Armor", 328, 1),
			new PresetItemTemplateIdGroup("Armor", 337, 1),
			new PresetItemTemplateIdGroup("Armor", 346, 1),
			new PresetItemTemplateIdGroup("Armor", 355, 1),
			new PresetItemTemplateIdGroup("Armor", 364, 1),
			new PresetItemTemplateIdGroup("Armor", 373, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 418, 1),
			new PresetItemTemplateIdGroup("Armor", 427, 1),
			new PresetItemTemplateIdGroup("Armor", 508, 1),
			new PresetItemTemplateIdGroup("Armor", 517, 1),
			new PresetItemTemplateIdGroup("Armor", 436, 1),
			new PresetItemTemplateIdGroup("Armor", 472, 1),
			new PresetItemTemplateIdGroup("Armor", 445, 1),
			new PresetItemTemplateIdGroup("Armor", 481, 1),
			new PresetItemTemplateIdGroup("Armor", 454, 1),
			new PresetItemTemplateIdGroup("Armor", 490, 1),
			new PresetItemTemplateIdGroup("Armor", 463, 1),
			new PresetItemTemplateIdGroup("Armor", 499, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 22, 1),
			new PresetItemTemplateIdGroup("Accessory", 31, 1),
			new PresetItemTemplateIdGroup("Accessory", 40, 1),
			new PresetItemTemplateIdGroup("Accessory", 49, 1),
			new PresetItemTemplateIdGroup("Accessory", 58, 1),
			new PresetItemTemplateIdGroup("Accessory", 67, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 76, 1),
			new PresetItemTemplateIdGroup("Accessory", 85, 1),
			new PresetItemTemplateIdGroup("Accessory", 103, 1),
			new PresetItemTemplateIdGroup("Accessory", 112, 1),
			new PresetItemTemplateIdGroup("Accessory", 121, 1),
			new PresetItemTemplateIdGroup("Accessory", 130, 1),
			new PresetItemTemplateIdGroup("Accessory", 139, 1),
			new PresetItemTemplateIdGroup("Accessory", 148, 1),
			new PresetItemTemplateIdGroup("Accessory", 157, 1),
			new PresetItemTemplateIdGroup("Accessory", 166, 1),
			new PresetItemTemplateIdGroup("Accessory", 175, 1),
			new PresetItemTemplateIdGroup("Accessory", 184, 1),
			new PresetItemTemplateIdGroup("Accessory", 193, 1),
			new PresetItemTemplateIdGroup("Accessory", 202, 1),
			new PresetItemTemplateIdGroup("Accessory", 211, 1),
			new PresetItemTemplateIdGroup("Accessory", 220, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 23, 1),
			new PresetItemTemplateIdGroup("CraftTool", 5, 1),
			new PresetItemTemplateIdGroup("CraftTool", 32, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 96, 1)
		}, new sbyte[12]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			12, 13
		}, new sbyte[12]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			12, 13
		}, new short[14]
		{
			-40, 1, 1, 1, 1, -50, 3, 3, 2, 3,
			1, 4, 1, -40
		}, new short[14]
		{
			-80, 1, 1, 1, 1, 1, 2, 2, 1, 2,
			1, 2, 1, -80
		}, new short[14]
		{
			-40, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			1, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, -50, 0, 0, 0, 0,
			0, 4, 0, -40
		}, new short[14]
		{
			0, 1, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 380, 379, 379, 379 }, 340));
		_dataArray.Add(new MerchantItem(46, 42, 6, 4, LocalStringManager.GetConfig("Merchant_language", "UiName_46"), 80, 1, 9, 20, 96000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Clothing", 6, 1),
			new PresetItemTemplateIdGroup("Clothing", 15, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 224, 1),
			new PresetItemTemplateIdGroup("Weapon", 233, 1),
			new PresetItemTemplateIdGroup("Weapon", 242, 1),
			new PresetItemTemplateIdGroup("Weapon", 251, 1),
			new PresetItemTemplateIdGroup("Weapon", 260, 1),
			new PresetItemTemplateIdGroup("Weapon", 269, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 350, 1),
			new PresetItemTemplateIdGroup("Weapon", 359, 1),
			new PresetItemTemplateIdGroup("Weapon", 368, 1),
			new PresetItemTemplateIdGroup("Weapon", 377, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 710, 1),
			new PresetItemTemplateIdGroup("Weapon", 719, 1),
			new PresetItemTemplateIdGroup("Weapon", 728, 1),
			new PresetItemTemplateIdGroup("Weapon", 737, 1),
			new PresetItemTemplateIdGroup("Weapon", 746, 1),
			new PresetItemTemplateIdGroup("Weapon", 755, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 764, 1),
			new PresetItemTemplateIdGroup("Weapon", 773, 1),
			new PresetItemTemplateIdGroup("Weapon", 782, 1),
			new PresetItemTemplateIdGroup("Weapon", 791, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 818, 1),
			new PresetItemTemplateIdGroup("Weapon", 827, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 23, 1),
			new PresetItemTemplateIdGroup("Armor", 32, 1),
			new PresetItemTemplateIdGroup("Armor", 41, 1),
			new PresetItemTemplateIdGroup("Armor", 50, 1),
			new PresetItemTemplateIdGroup("Armor", 59, 1),
			new PresetItemTemplateIdGroup("Armor", 68, 1),
			new PresetItemTemplateIdGroup("Armor", 77, 1),
			new PresetItemTemplateIdGroup("Armor", 86, 1),
			new PresetItemTemplateIdGroup("Armor", 95, 1),
			new PresetItemTemplateIdGroup("Armor", 104, 1),
			new PresetItemTemplateIdGroup("Armor", 113, 1),
			new PresetItemTemplateIdGroup("Armor", 122, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 149, 1),
			new PresetItemTemplateIdGroup("Armor", 158, 1),
			new PresetItemTemplateIdGroup("Armor", 167, 1),
			new PresetItemTemplateIdGroup("Armor", 176, 1),
			new PresetItemTemplateIdGroup("Armor", 185, 1),
			new PresetItemTemplateIdGroup("Armor", 194, 1),
			new PresetItemTemplateIdGroup("Armor", 203, 1),
			new PresetItemTemplateIdGroup("Armor", 212, 1),
			new PresetItemTemplateIdGroup("Armor", 221, 1),
			new PresetItemTemplateIdGroup("Armor", 230, 1),
			new PresetItemTemplateIdGroup("Armor", 239, 1),
			new PresetItemTemplateIdGroup("Armor", 248, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 311, 1),
			new PresetItemTemplateIdGroup("Armor", 320, 1),
			new PresetItemTemplateIdGroup("Armor", 329, 1),
			new PresetItemTemplateIdGroup("Armor", 338, 1),
			new PresetItemTemplateIdGroup("Armor", 347, 1),
			new PresetItemTemplateIdGroup("Armor", 356, 1),
			new PresetItemTemplateIdGroup("Armor", 365, 1),
			new PresetItemTemplateIdGroup("Armor", 374, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 419, 1),
			new PresetItemTemplateIdGroup("Armor", 428, 1),
			new PresetItemTemplateIdGroup("Armor", 509, 1),
			new PresetItemTemplateIdGroup("Armor", 518, 1),
			new PresetItemTemplateIdGroup("Armor", 437, 1),
			new PresetItemTemplateIdGroup("Armor", 473, 1),
			new PresetItemTemplateIdGroup("Armor", 446, 1),
			new PresetItemTemplateIdGroup("Armor", 482, 1),
			new PresetItemTemplateIdGroup("Armor", 455, 1),
			new PresetItemTemplateIdGroup("Armor", 491, 1),
			new PresetItemTemplateIdGroup("Armor", 464, 1),
			new PresetItemTemplateIdGroup("Armor", 500, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 23, 1),
			new PresetItemTemplateIdGroup("Accessory", 32, 1),
			new PresetItemTemplateIdGroup("Accessory", 41, 1),
			new PresetItemTemplateIdGroup("Accessory", 50, 1),
			new PresetItemTemplateIdGroup("Accessory", 59, 1),
			new PresetItemTemplateIdGroup("Accessory", 68, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 77, 1),
			new PresetItemTemplateIdGroup("Accessory", 86, 1),
			new PresetItemTemplateIdGroup("Accessory", 104, 1),
			new PresetItemTemplateIdGroup("Accessory", 113, 1),
			new PresetItemTemplateIdGroup("Accessory", 122, 1),
			new PresetItemTemplateIdGroup("Accessory", 131, 1),
			new PresetItemTemplateIdGroup("Accessory", 140, 1),
			new PresetItemTemplateIdGroup("Accessory", 149, 1),
			new PresetItemTemplateIdGroup("Accessory", 158, 1),
			new PresetItemTemplateIdGroup("Accessory", 167, 1),
			new PresetItemTemplateIdGroup("Accessory", 176, 1),
			new PresetItemTemplateIdGroup("Accessory", 185, 1),
			new PresetItemTemplateIdGroup("Accessory", 194, 1),
			new PresetItemTemplateIdGroup("Accessory", 203, 1),
			new PresetItemTemplateIdGroup("Accessory", 212, 1),
			new PresetItemTemplateIdGroup("Accessory", 221, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 24, 1),
			new PresetItemTemplateIdGroup("CraftTool", 6, 1),
			new PresetItemTemplateIdGroup("CraftTool", 33, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 97, 1)
		}, new sbyte[12]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			12, 13
		}, new sbyte[12]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			12, 13
		}, new short[14]
		{
			-30, 1, 1, 1, 1, -40, 3, 3, 2, 3,
			1, 4, -30, -30
		}, new short[14]
		{
			-60, 1, 1, 1, 1, -80, 2, 2, 1, 2,
			1, 2, -60, -60
		}, new short[14]
		{
			-30, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			1, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, -40, 0, 0, 0, 0,
			0, 4, 0, -30
		}, new short[14]
		{
			0, 1, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 381, 380, 380, 380 }, 345));
		_dataArray.Add(new MerchantItem(47, 42, 6, 5, LocalStringManager.GetConfig("Merchant_language", "UiName_47"), 90, 1, 9, 20, 192000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Clothing", 7, 1),
			new PresetItemTemplateIdGroup("Clothing", 16, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 225, 1),
			new PresetItemTemplateIdGroup("Weapon", 234, 1),
			new PresetItemTemplateIdGroup("Weapon", 243, 1),
			new PresetItemTemplateIdGroup("Weapon", 252, 1),
			new PresetItemTemplateIdGroup("Weapon", 261, 1),
			new PresetItemTemplateIdGroup("Weapon", 270, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 351, 1),
			new PresetItemTemplateIdGroup("Weapon", 360, 1),
			new PresetItemTemplateIdGroup("Weapon", 369, 1),
			new PresetItemTemplateIdGroup("Weapon", 378, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 711, 1),
			new PresetItemTemplateIdGroup("Weapon", 720, 1),
			new PresetItemTemplateIdGroup("Weapon", 729, 1),
			new PresetItemTemplateIdGroup("Weapon", 738, 1),
			new PresetItemTemplateIdGroup("Weapon", 747, 1),
			new PresetItemTemplateIdGroup("Weapon", 756, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 765, 1),
			new PresetItemTemplateIdGroup("Weapon", 774, 1),
			new PresetItemTemplateIdGroup("Weapon", 783, 1),
			new PresetItemTemplateIdGroup("Weapon", 792, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 819, 1),
			new PresetItemTemplateIdGroup("Weapon", 828, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 24, 1),
			new PresetItemTemplateIdGroup("Armor", 33, 1),
			new PresetItemTemplateIdGroup("Armor", 42, 1),
			new PresetItemTemplateIdGroup("Armor", 51, 1),
			new PresetItemTemplateIdGroup("Armor", 60, 1),
			new PresetItemTemplateIdGroup("Armor", 69, 1),
			new PresetItemTemplateIdGroup("Armor", 78, 1),
			new PresetItemTemplateIdGroup("Armor", 87, 1),
			new PresetItemTemplateIdGroup("Armor", 96, 1),
			new PresetItemTemplateIdGroup("Armor", 105, 1),
			new PresetItemTemplateIdGroup("Armor", 114, 1),
			new PresetItemTemplateIdGroup("Armor", 123, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 150, 1),
			new PresetItemTemplateIdGroup("Armor", 159, 1),
			new PresetItemTemplateIdGroup("Armor", 168, 1),
			new PresetItemTemplateIdGroup("Armor", 177, 1),
			new PresetItemTemplateIdGroup("Armor", 186, 1),
			new PresetItemTemplateIdGroup("Armor", 195, 1),
			new PresetItemTemplateIdGroup("Armor", 204, 1),
			new PresetItemTemplateIdGroup("Armor", 213, 1),
			new PresetItemTemplateIdGroup("Armor", 222, 1),
			new PresetItemTemplateIdGroup("Armor", 231, 1),
			new PresetItemTemplateIdGroup("Armor", 240, 1),
			new PresetItemTemplateIdGroup("Armor", 249, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 312, 1),
			new PresetItemTemplateIdGroup("Armor", 321, 1),
			new PresetItemTemplateIdGroup("Armor", 330, 1),
			new PresetItemTemplateIdGroup("Armor", 339, 1),
			new PresetItemTemplateIdGroup("Armor", 348, 1),
			new PresetItemTemplateIdGroup("Armor", 357, 1),
			new PresetItemTemplateIdGroup("Armor", 366, 1),
			new PresetItemTemplateIdGroup("Armor", 375, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 420, 1),
			new PresetItemTemplateIdGroup("Armor", 429, 1),
			new PresetItemTemplateIdGroup("Armor", 510, 1),
			new PresetItemTemplateIdGroup("Armor", 519, 1),
			new PresetItemTemplateIdGroup("Armor", 438, 1),
			new PresetItemTemplateIdGroup("Armor", 474, 1),
			new PresetItemTemplateIdGroup("Armor", 447, 1),
			new PresetItemTemplateIdGroup("Armor", 483, 1),
			new PresetItemTemplateIdGroup("Armor", 456, 1),
			new PresetItemTemplateIdGroup("Armor", 492, 1),
			new PresetItemTemplateIdGroup("Armor", 465, 1),
			new PresetItemTemplateIdGroup("Armor", 501, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 24, 1),
			new PresetItemTemplateIdGroup("Accessory", 33, 1),
			new PresetItemTemplateIdGroup("Accessory", 42, 1),
			new PresetItemTemplateIdGroup("Accessory", 51, 1),
			new PresetItemTemplateIdGroup("Accessory", 60, 1),
			new PresetItemTemplateIdGroup("Accessory", 69, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 78, 1),
			new PresetItemTemplateIdGroup("Accessory", 87, 1),
			new PresetItemTemplateIdGroup("Accessory", 105, 1),
			new PresetItemTemplateIdGroup("Accessory", 114, 1),
			new PresetItemTemplateIdGroup("Accessory", 123, 1),
			new PresetItemTemplateIdGroup("Accessory", 132, 1),
			new PresetItemTemplateIdGroup("Accessory", 141, 1),
			new PresetItemTemplateIdGroup("Accessory", 150, 1),
			new PresetItemTemplateIdGroup("Accessory", 159, 1),
			new PresetItemTemplateIdGroup("Accessory", 168, 1),
			new PresetItemTemplateIdGroup("Accessory", 177, 1),
			new PresetItemTemplateIdGroup("Accessory", 186, 1),
			new PresetItemTemplateIdGroup("Accessory", 195, 1),
			new PresetItemTemplateIdGroup("Accessory", 204, 1),
			new PresetItemTemplateIdGroup("Accessory", 213, 1),
			new PresetItemTemplateIdGroup("Accessory", 222, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 25, 1),
			new PresetItemTemplateIdGroup("CraftTool", 7, 1),
			new PresetItemTemplateIdGroup("CraftTool", 34, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 98, 1)
		}, new sbyte[12]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			12, 13
		}, new sbyte[12]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			12, 13
		}, new short[14]
		{
			-20, -30, -30, -30, -30, -30, 1, 1, 1, 1,
			-30, 2, -20, -20
		}, new short[14]
		{
			-40, -60, -60, -60, -60, -60, 1, 1, 1, 1,
			-60, 2, -40, -40
		}, new short[14]
		{
			-20, 0, -30, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, -30, 0, 0, 0, 0, 0,
			-30, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, -30, 0, 0, 0, 0,
			0, 2, 0, -20
		}, new short[14]
		{
			0, -30, 0, -30, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 382, 381, 381, 381 }, 350));
		_dataArray.Add(new MerchantItem(48, 42, 6, 6, LocalStringManager.GetConfig("Merchant_language", "UiName_48"), 100, 1, 12, 20, 384000, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Clothing", 8, 1),
			new PresetItemTemplateIdGroup("Clothing", 17, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 226, 1),
			new PresetItemTemplateIdGroup("Weapon", 235, 1),
			new PresetItemTemplateIdGroup("Weapon", 244, 1),
			new PresetItemTemplateIdGroup("Weapon", 253, 1),
			new PresetItemTemplateIdGroup("Weapon", 262, 1),
			new PresetItemTemplateIdGroup("Weapon", 271, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 352, 1),
			new PresetItemTemplateIdGroup("Weapon", 361, 1),
			new PresetItemTemplateIdGroup("Weapon", 370, 1),
			new PresetItemTemplateIdGroup("Weapon", 379, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 712, 1),
			new PresetItemTemplateIdGroup("Weapon", 721, 1),
			new PresetItemTemplateIdGroup("Weapon", 730, 1),
			new PresetItemTemplateIdGroup("Weapon", 739, 1),
			new PresetItemTemplateIdGroup("Weapon", 748, 1),
			new PresetItemTemplateIdGroup("Weapon", 757, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 766, 1),
			new PresetItemTemplateIdGroup("Weapon", 775, 1),
			new PresetItemTemplateIdGroup("Weapon", 784, 1),
			new PresetItemTemplateIdGroup("Weapon", 793, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Weapon", 820, 1),
			new PresetItemTemplateIdGroup("Weapon", 829, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 25, 1),
			new PresetItemTemplateIdGroup("Armor", 34, 1),
			new PresetItemTemplateIdGroup("Armor", 43, 1),
			new PresetItemTemplateIdGroup("Armor", 52, 1),
			new PresetItemTemplateIdGroup("Armor", 61, 1),
			new PresetItemTemplateIdGroup("Armor", 70, 1),
			new PresetItemTemplateIdGroup("Armor", 79, 1),
			new PresetItemTemplateIdGroup("Armor", 88, 1),
			new PresetItemTemplateIdGroup("Armor", 97, 1),
			new PresetItemTemplateIdGroup("Armor", 106, 1),
			new PresetItemTemplateIdGroup("Armor", 115, 1),
			new PresetItemTemplateIdGroup("Armor", 124, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 151, 1),
			new PresetItemTemplateIdGroup("Armor", 160, 1),
			new PresetItemTemplateIdGroup("Armor", 169, 1),
			new PresetItemTemplateIdGroup("Armor", 178, 1),
			new PresetItemTemplateIdGroup("Armor", 187, 1),
			new PresetItemTemplateIdGroup("Armor", 196, 1),
			new PresetItemTemplateIdGroup("Armor", 205, 1),
			new PresetItemTemplateIdGroup("Armor", 214, 1),
			new PresetItemTemplateIdGroup("Armor", 223, 1),
			new PresetItemTemplateIdGroup("Armor", 232, 1),
			new PresetItemTemplateIdGroup("Armor", 241, 1),
			new PresetItemTemplateIdGroup("Armor", 250, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 313, 1),
			new PresetItemTemplateIdGroup("Armor", 322, 1),
			new PresetItemTemplateIdGroup("Armor", 331, 1),
			new PresetItemTemplateIdGroup("Armor", 340, 1),
			new PresetItemTemplateIdGroup("Armor", 349, 1),
			new PresetItemTemplateIdGroup("Armor", 358, 1),
			new PresetItemTemplateIdGroup("Armor", 367, 1),
			new PresetItemTemplateIdGroup("Armor", 376, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Armor", 421, 1),
			new PresetItemTemplateIdGroup("Armor", 430, 1),
			new PresetItemTemplateIdGroup("Armor", 511, 1),
			new PresetItemTemplateIdGroup("Armor", 520, 1),
			new PresetItemTemplateIdGroup("Armor", 439, 1),
			new PresetItemTemplateIdGroup("Armor", 475, 1),
			new PresetItemTemplateIdGroup("Armor", 448, 1),
			new PresetItemTemplateIdGroup("Armor", 484, 1),
			new PresetItemTemplateIdGroup("Armor", 457, 1),
			new PresetItemTemplateIdGroup("Armor", 493, 1),
			new PresetItemTemplateIdGroup("Armor", 466, 1),
			new PresetItemTemplateIdGroup("Armor", 502, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 25, 1),
			new PresetItemTemplateIdGroup("Accessory", 34, 1),
			new PresetItemTemplateIdGroup("Accessory", 43, 1),
			new PresetItemTemplateIdGroup("Accessory", 52, 1),
			new PresetItemTemplateIdGroup("Accessory", 61, 1),
			new PresetItemTemplateIdGroup("Accessory", 70, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Accessory", 79, 1),
			new PresetItemTemplateIdGroup("Accessory", 88, 1),
			new PresetItemTemplateIdGroup("Accessory", 106, 1),
			new PresetItemTemplateIdGroup("Accessory", 115, 1),
			new PresetItemTemplateIdGroup("Accessory", 124, 1),
			new PresetItemTemplateIdGroup("Accessory", 133, 1),
			new PresetItemTemplateIdGroup("Accessory", 142, 1),
			new PresetItemTemplateIdGroup("Accessory", 151, 1),
			new PresetItemTemplateIdGroup("Accessory", 160, 1),
			new PresetItemTemplateIdGroup("Accessory", 169, 1),
			new PresetItemTemplateIdGroup("Accessory", 178, 1),
			new PresetItemTemplateIdGroup("Accessory", 187, 1),
			new PresetItemTemplateIdGroup("Accessory", 196, 1),
			new PresetItemTemplateIdGroup("Accessory", 205, 1),
			new PresetItemTemplateIdGroup("Accessory", 214, 1),
			new PresetItemTemplateIdGroup("Accessory", 223, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("CraftTool", 26, 1),
			new PresetItemTemplateIdGroup("CraftTool", 8, 1),
			new PresetItemTemplateIdGroup("CraftTool", 35, 1)
		}, new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 99, 1)
		}, new sbyte[0], new sbyte[0], new short[14]
		{
			-10, -20, -20, -20, -20, -20, 1, 1, 1, 1,
			-20, 2, -10, -10
		}, new short[14]
		{
			-20, -40, -40, -40, -40, -40, 1, 1, 1, 1,
			-40, 2, -20, -20
		}, new short[14]
		{
			-10, 0, -20, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, -20, 0, 0, 0, 0, 0,
			-20, 0, 0, 0
		}, new short[14]
		{
			0, 0, 0, 0, 0, -20, 0, 0, 0, 0,
			0, 2, 0, -10
		}, new short[14]
		{
			0, -20, 0, -20, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new List<short> { 383, 382, 382, 382 }, 355));
		List<MerchantItem> dataArray37 = _dataArray;
		string config37 = LocalStringManager.GetConfig("Merchant_language", "UiName_49");
		List<PresetItemTemplateIdGroup> goods450 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 37, 1),
			new PresetItemTemplateIdGroup("Misc", 42, 1),
			new PresetItemTemplateIdGroup("Misc", 47, 1),
			new PresetItemTemplateIdGroup("Misc", 52, 1),
			new PresetItemTemplateIdGroup("Misc", 57, 1),
			new PresetItemTemplateIdGroup("Misc", 62, 1),
			new PresetItemTemplateIdGroup("Misc", 67, 1),
			new PresetItemTemplateIdGroup("Misc", 72, 1),
			new PresetItemTemplateIdGroup("Misc", 77, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods451 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods452 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods453 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods454 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods455 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods456 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods457 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods458 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods459 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods460 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods461 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods462 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray37.Add(new MerchantItem(49, 49, 2, 3, config37, 60, 12, -1, -1, 0, goods450, goods451, goods452, goods453, goods454, goods455, goods456, goods457, goods458, goods459, goods460, goods461, goods462, goods12, new sbyte[0], new sbyte[0], new short[14]
		{
			3, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			3, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14], new short[14], new short[14], new short[14], new List<short> { 379, 378, 378, 378 }, -1));
		List<MerchantItem> dataArray38 = _dataArray;
		string config38 = LocalStringManager.GetConfig("Merchant_language", "UiName_50");
		List<PresetItemTemplateIdGroup> goods463 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 38, 1),
			new PresetItemTemplateIdGroup("Misc", 43, 1),
			new PresetItemTemplateIdGroup("Misc", 48, 1),
			new PresetItemTemplateIdGroup("Misc", 53, 1),
			new PresetItemTemplateIdGroup("Misc", 58, 1),
			new PresetItemTemplateIdGroup("Misc", 63, 1),
			new PresetItemTemplateIdGroup("Misc", 68, 1),
			new PresetItemTemplateIdGroup("Misc", 73, 1),
			new PresetItemTemplateIdGroup("Misc", 78, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods464 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods465 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods466 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods467 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods468 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods469 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods470 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods471 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods472 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods473 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods474 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods475 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray38.Add(new MerchantItem(50, 49, 2, 4, config38, 80, 12, -1, -1, 0, goods463, goods464, goods465, goods466, goods467, goods468, goods469, goods470, goods471, goods472, goods473, goods474, goods475, goods12, new sbyte[0], new sbyte[0], new short[14]
		{
			3, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			3, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14], new short[14], new short[14], new short[14], new List<short> { 380, 379, 379, 379 }, -1));
		List<MerchantItem> dataArray39 = _dataArray;
		string config39 = LocalStringManager.GetConfig("Merchant_language", "UiName_51");
		List<PresetItemTemplateIdGroup> goods476 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 39, 1),
			new PresetItemTemplateIdGroup("Misc", 44, 1),
			new PresetItemTemplateIdGroup("Misc", 49, 1),
			new PresetItemTemplateIdGroup("Misc", 54, 1),
			new PresetItemTemplateIdGroup("Misc", 59, 1),
			new PresetItemTemplateIdGroup("Misc", 64, 1),
			new PresetItemTemplateIdGroup("Misc", 69, 1),
			new PresetItemTemplateIdGroup("Misc", 74, 1),
			new PresetItemTemplateIdGroup("Misc", 79, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods477 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods478 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods479 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods480 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods481 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods482 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods483 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods484 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods485 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods486 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods487 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods488 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		dataArray39.Add(new MerchantItem(51, 49, 2, 5, config39, 90, 12, -1, -1, 0, goods476, goods477, goods478, goods479, goods480, goods481, goods482, goods483, goods484, goods485, goods486, goods487, goods488, goods12, new sbyte[0], new sbyte[0], new short[14]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		}, new short[14], new short[14], new short[14], new short[14], new List<short> { 381, 380, 380, 380 }, -1));
		List<MerchantItem> dataArray40 = _dataArray;
		string config40 = LocalStringManager.GetConfig("Merchant_language", "UiName_52");
		List<PresetItemTemplateIdGroup> goods489 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 0, 3)
		};
		List<PresetItemTemplateIdGroup> goods490 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 1, 3)
		};
		List<PresetItemTemplateIdGroup> goods491 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 2, 3)
		};
		List<PresetItemTemplateIdGroup> goods492 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 3, 2)
		};
		List<PresetItemTemplateIdGroup> goods493 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 4, 2)
		};
		List<PresetItemTemplateIdGroup> goods494 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 5, 2)
		};
		List<PresetItemTemplateIdGroup> goods495 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Food", 6, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods496 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods497 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods498 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods499 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods500 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods501 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods502 = goods12;
		sbyte[] extraGoodsIndexGroup = new sbyte[0];
		sbyte[] capitalistSkillExtraGoodsIndexGroup = new sbyte[0];
		short[] goodsRate = new short[14]
		{
			1, 1, 1, -40, -30, -20, -10, 0, 0, 0,
			0, 0, 0, 0
		};
		short[] capitalistSkillExtraGoodsRate = new short[14];
		short[] seasonsGoodsRate = new short[14];
		short[] seasonsGoodsRate2 = new short[14];
		short[] seasonsGoodsRate3 = new short[14];
		short[] seasonsGoodsRate4 = new short[14];
		List<short> guards = new List<short>();
		dataArray40.Add(new MerchantItem(52, 52, 7, 0, config40, 0, 1, -1, -1, 0, goods489, goods490, goods491, goods492, goods493, goods494, goods495, goods496, goods497, goods498, goods499, goods500, goods501, goods502, extraGoodsIndexGroup, capitalistSkillExtraGoodsIndexGroup, goodsRate, capitalistSkillExtraGoodsRate, seasonsGoodsRate, seasonsGoodsRate2, seasonsGoodsRate3, seasonsGoodsRate4, guards, -1));
		List<MerchantItem> dataArray41 = _dataArray;
		string config41 = LocalStringManager.GetConfig("Merchant_language", "UiName_53");
		List<PresetItemTemplateIdGroup> goods503 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 100, 3),
			new PresetItemTemplateIdGroup("Misc", 101, 3),
			new PresetItemTemplateIdGroup("Misc", 102, 3),
			new PresetItemTemplateIdGroup("Misc", 103, 3),
			new PresetItemTemplateIdGroup("Misc", 104, 3),
			new PresetItemTemplateIdGroup("Misc", 105, 3),
			new PresetItemTemplateIdGroup("Misc", 106, 3),
			new PresetItemTemplateIdGroup("Misc", 107, 3),
			new PresetItemTemplateIdGroup("Misc", 108, 3),
			new PresetItemTemplateIdGroup("Misc", 109, 3)
		};
		List<PresetItemTemplateIdGroup> goods504 = new List<PresetItemTemplateIdGroup>
		{
			new PresetItemTemplateIdGroup("Misc", 110, 1),
			new PresetItemTemplateIdGroup("Misc", 111, 1),
			new PresetItemTemplateIdGroup("Misc", 112, 1),
			new PresetItemTemplateIdGroup("Misc", 113, 1),
			new PresetItemTemplateIdGroup("Misc", 114, 1),
			new PresetItemTemplateIdGroup("Misc", 115, 1),
			new PresetItemTemplateIdGroup("Misc", 116, 1),
			new PresetItemTemplateIdGroup("Misc", 117, 1),
			new PresetItemTemplateIdGroup("Misc", 118, 1),
			new PresetItemTemplateIdGroup("Misc", 119, 1)
		};
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods505 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods506 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods507 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods508 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods509 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods510 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods511 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods512 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods513 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods514 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods515 = goods12;
		goods12 = new List<PresetItemTemplateIdGroup>();
		List<PresetItemTemplateIdGroup> goods516 = goods12;
		sbyte[] extraGoodsIndexGroup2 = new sbyte[0];
		sbyte[] capitalistSkillExtraGoodsIndexGroup2 = new sbyte[0];
		short[] goodsRate2 = new short[14]
		{
			10, 10, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0
		};
		short[] capitalistSkillExtraGoodsRate2 = new short[14];
		short[] seasonsGoodsRate5 = new short[14];
		short[] seasonsGoodsRate6 = new short[14];
		short[] seasonsGoodsRate7 = new short[14];
		short[] seasonsGoodsRate8 = new short[14];
		guards = new List<short>();
		dataArray41.Add(new MerchantItem(53, 53, 8, 0, config41, 0, 1, -1, -1, 0, goods503, goods504, goods505, goods506, goods507, goods508, goods509, goods510, goods511, goods512, goods513, goods514, goods515, goods516, extraGoodsIndexGroup2, capitalistSkillExtraGoodsIndexGroup2, goodsRate2, capitalistSkillExtraGoodsRate2, seasonsGoodsRate5, seasonsGoodsRate6, seasonsGoodsRate7, seasonsGoodsRate8, guards, -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MerchantItem>(54);
		CreateItems0();
	}
}
