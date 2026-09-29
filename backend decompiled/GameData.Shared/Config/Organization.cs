using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using Config.ConfigCells.Character;
using GameData.Utilities;

namespace Config;

[Serializable]
public class Organization : ConfigData<OrganizationItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte None = 0;

		public const sbyte Shaolin = 1;

		public const sbyte Emei = 2;

		public const sbyte Baihua = 3;

		public const sbyte Wudang = 4;

		public const sbyte Yuanshan = 5;

		public const sbyte Shixiang = 6;

		public const sbyte Ranshan = 7;

		public const sbyte Xuannv = 8;

		public const sbyte Zhujian = 9;

		public const sbyte Kongsang = 10;

		public const sbyte Jingang = 11;

		public const sbyte Wuxian = 12;

		public const sbyte Jieqing = 13;

		public const sbyte Fulong = 14;

		public const sbyte Xuehou = 15;

		public const sbyte Taiwu = 16;

		public const sbyte Heretic = 17;

		public const sbyte Righteous = 18;

		public const sbyte XiangshuMinion = 19;

		public const sbyte XiangshuInfected = 20;

		public const sbyte Jingcheng = 21;

		public const sbyte Chengdu = 22;

		public const sbyte Guizhou = 23;

		public const sbyte Xiangyang = 24;

		public const sbyte Taiyuan = 25;

		public const sbyte Guangzhou = 26;

		public const sbyte Qingzhou = 27;

		public const sbyte Jiangling = 28;

		public const sbyte Fuzhou = 29;

		public const sbyte Liaoyang = 30;

		public const sbyte Qinzhou = 31;

		public const sbyte Dali = 32;

		public const sbyte Shouchun = 33;

		public const sbyte Hangzhou = 34;

		public const sbyte Yangzhou = 35;

		public const sbyte Village = 36;

		public const sbyte Town = 37;

		public const sbyte WalledTown = 38;

		public const sbyte Beast = 40;
	}

	public static class DefValue
	{
		public static OrganizationItem None => Instance[(sbyte)0];

		public static OrganizationItem Shaolin => Instance[(sbyte)1];

		public static OrganizationItem Emei => Instance[(sbyte)2];

		public static OrganizationItem Baihua => Instance[(sbyte)3];

		public static OrganizationItem Wudang => Instance[(sbyte)4];

		public static OrganizationItem Yuanshan => Instance[(sbyte)5];

		public static OrganizationItem Shixiang => Instance[(sbyte)6];

		public static OrganizationItem Ranshan => Instance[(sbyte)7];

		public static OrganizationItem Xuannv => Instance[(sbyte)8];

		public static OrganizationItem Zhujian => Instance[(sbyte)9];

		public static OrganizationItem Kongsang => Instance[(sbyte)10];

		public static OrganizationItem Jingang => Instance[(sbyte)11];

		public static OrganizationItem Wuxian => Instance[(sbyte)12];

		public static OrganizationItem Jieqing => Instance[(sbyte)13];

		public static OrganizationItem Fulong => Instance[(sbyte)14];

		public static OrganizationItem Xuehou => Instance[(sbyte)15];

		public static OrganizationItem Taiwu => Instance[(sbyte)16];

		public static OrganizationItem Heretic => Instance[(sbyte)17];

		public static OrganizationItem Righteous => Instance[(sbyte)18];

		public static OrganizationItem XiangshuMinion => Instance[(sbyte)19];

		public static OrganizationItem XiangshuInfected => Instance[(sbyte)20];

		public static OrganizationItem Jingcheng => Instance[(sbyte)21];

		public static OrganizationItem Chengdu => Instance[(sbyte)22];

		public static OrganizationItem Guizhou => Instance[(sbyte)23];

		public static OrganizationItem Xiangyang => Instance[(sbyte)24];

		public static OrganizationItem Taiyuan => Instance[(sbyte)25];

		public static OrganizationItem Guangzhou => Instance[(sbyte)26];

		public static OrganizationItem Qingzhou => Instance[(sbyte)27];

		public static OrganizationItem Jiangling => Instance[(sbyte)28];

		public static OrganizationItem Fuzhou => Instance[(sbyte)29];

		public static OrganizationItem Liaoyang => Instance[(sbyte)30];

		public static OrganizationItem Qinzhou => Instance[(sbyte)31];

		public static OrganizationItem Dali => Instance[(sbyte)32];

		public static OrganizationItem Shouchun => Instance[(sbyte)33];

		public static OrganizationItem Hangzhou => Instance[(sbyte)34];

		public static OrganizationItem Yangzhou => Instance[(sbyte)35];

		public static OrganizationItem Village => Instance[(sbyte)36];

		public static OrganizationItem Town => Instance[(sbyte)37];

		public static OrganizationItem WalledTown => Instance[(sbyte)38];

		public static OrganizationItem Beast => Instance[(sbyte)40];
	}

	public static Organization Instance = new Organization();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "TaiwuVillageSteleDesc", "CharTemplateIds", "RandomEnemyTemplateIds", "MerchantTendency", "LegendaryBookTendency", "AbandonedBabyOrganizations", "PunishmentFeature", "TaiwuPunishementFeature",
		"LearnLifeSkillTypes", "CombatSkillTypes", "Members", "MemberFeature", "OrganizationExtraDesc", "PrisonBuilding", "MartialArtistItemBonus", "VowSpecialHint", "TaiwuBeHunted", "SkillBreakBonusWeights",
		"LifeSkillCombatBriberyItemTypeWeight", "LifeSkillCombatBriberyItemSubTypeWeight", "VowFixedRewardItems", "VowRandomRewardItems", "TemplateId", "Icon", "MousetipIcon"
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
		_dataArray.Add(new OrganizationItem(0, LocalStringManager.GetConfig("Organization_language", "Name_0"), LocalStringManager.GetConfig("Organization_language", "Desc_0"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_0"), null, "mousetip_menpai_0", 0, 0, 0, new short[2] { -1, -1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.Invalid, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 1, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, -1, new sbyte[15], new short[9], 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_0"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_0"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, -1));
		_dataArray.Add(new OrganizationItem(1, LocalStringManager.GetConfig("Organization_language", "Name_1"), LocalStringManager.GetConfig("Organization_language", "Desc_1"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_1"), "ui9_icon_faction_9", "mousetip_menpai_1", 125, 150, 700, new short[2] { 0, 1 }, new short[9] { 392, 391, 390, 389, 388, 387, 386, 385, 384 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, 0, 1, 250, 1, 20, hereditary: false, allowPoisoning: false, noMeatEating: true, noDrinking: true, 1, 1, -1, new List<sbyte> { 2, 3, 4, 5, 16 }, 219, null, new List<sbyte> { 1, 8, 13 }, new List<sbyte> { 0, 1, 2, 3, 4, 9 }, 0, 18, new sbyte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, -1, 0
		}, new short[9] { 54, 53, 52, 51, 50, 49, 48, 47, 46 }, 1, 575, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_1"), 303, new short[7] { 300, 273, 354, 678, 651, 660, 696 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_1"), 0, new ShortPair[3]
		{
			new ShortPair(14, 100),
			new ShortPair(1, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 10),
			new LifeSkillCombatBriberyItemTypeWeight(1, 20),
			new LifeSkillCombatBriberyItemTypeWeight(2, 10),
			new LifeSkillCombatBriberyItemTypeWeight(4, 10),
			new LifeSkillCombatBriberyItemTypeWeight(7, 0)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 40),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 10),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("TeaWine", 20, 3, 100),
			new PresetInventoryItem("TeaWine", 29, 3, 100)
		}, new List<PresetInventoryItem>(), 0, 90));
		_dataArray.Add(new OrganizationItem(2, LocalStringManager.GetConfig("Organization_language", "Name_2"), LocalStringManager.GetConfig("Organization_language", "Desc_2"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_2"), "ui9_icon_faction_2", "mousetip_menpai_2", 150, -18, 650, new short[2] { 2, 3 }, new short[9] { 401, 400, 399, 398, 397, 396, 395, 394, 393 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, 1, 1, 250, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, 0, 1, 10, new List<sbyte>(), -1, new List<short> { 470, 471, 472, 473, 474 }, new List<sbyte> { 12, 13, 14 }, new List<sbyte> { 0, 1, 2, 3, 4, 7, 10 }, 1, 9, new sbyte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			-1, 0, 0, 0, 0
		}, new short[9] { 63, 62, 61, 60, 59, 58, 57, 56, 55 }, 4, 576, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_2"), 304, new short[10] { 354, 345, 372, 273, 327, 363, 435, 462, 480, 147 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_2"), 1, new ShortPair[8]
		{
			new ShortPair(14, 50),
			new ShortPair(15, 50),
			new ShortPair(12, 25),
			new ShortPair(24, 25),
			new ShortPair(23, 25),
			new ShortPair(35, 25),
			new ShortPair(36, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 5),
			new LifeSkillCombatBriberyItemTypeWeight(1, 5),
			new LifeSkillCombatBriberyItemTypeWeight(2, 20),
			new LifeSkillCombatBriberyItemTypeWeight(4, 10),
			new LifeSkillCombatBriberyItemTypeWeight(7, 10)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 40),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 10),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>(), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 100, 1, 100),
			new PresetInventoryItem("Misc", 101, 1, 100),
			new PresetInventoryItem("Misc", 102, 1, 100),
			new PresetInventoryItem("Misc", 103, 1, 100),
			new PresetInventoryItem("Misc", 104, 1, 100),
			new PresetInventoryItem("Misc", 105, 1, 100),
			new PresetInventoryItem("Misc", 106, 1, 100),
			new PresetInventoryItem("Misc", 107, 1, 100),
			new PresetInventoryItem("Misc", 108, 1, 100),
			new PresetInventoryItem("Misc", 109, 1, 100)
		}, 3, 90));
		_dataArray.Add(new OrganizationItem(3, LocalStringManager.GetConfig("Organization_language", "Name_3"), LocalStringManager.GetConfig("Organization_language", "Desc_3"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_3"), "ui9_icon_faction_1", "mousetip_menpai_3", -18, -18, 250, new short[2] { 4, 5 }, new short[9] { 410, 409, 408, 407, 406, 405, 404, 403, 402 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, -1, 1, 250, -1, 40, hereditary: false, allowPoisoning: true, noMeatEating: false, noDrinking: false, 4, 1, 4, new List<sbyte>(), -1, new List<short> { 475, 476, 477, 478, 479 }, new List<sbyte> { 0, 3, 8, 9, 10 }, new List<sbyte> { 0, 1, 2, 4, 12, 13 }, 2, 12, new sbyte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, -1
		}, new short[9] { 72, 71, 70, 69, 68, 67, 66, 65, 64 }, 3, 577, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_3"), 305, new short[7] { 363, 372, 93, 102, 84, 102, 255 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_3"), 2, new ShortPair[8]
		{
			new ShortPair(4, 100),
			new ShortPair(3, 25),
			new ShortPair(0, 25),
			new ShortPair(42, 25),
			new ShortPair(44, 25),
			new ShortPair(46, 25),
			new ShortPair(32, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 5),
			new LifeSkillCombatBriberyItemTypeWeight(1, 0),
			new LifeSkillCombatBriberyItemTypeWeight(2, 0),
			new LifeSkillCombatBriberyItemTypeWeight(4, 0),
			new LifeSkillCombatBriberyItemTypeWeight(7, 0)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 25),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 40),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 20),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 10)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Medicine", 60, 3, 100),
			new PresetInventoryItem("Medicine", 72, 3, 100)
		}, new List<PresetInventoryItem>(), 0, 70));
		_dataArray.Add(new OrganizationItem(4, LocalStringManager.GetConfig("Organization_language", "Name_4"), LocalStringManager.GetConfig("Organization_language", "Desc_4"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_4"), "ui9_icon_faction_12", "mousetip_menpai_4", 150, 125, 600, new short[2] { 6, 7 }, new short[9] { 419, 418, 417, 416, 415, 414, 413, 412, 411 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, 2, 1, 0, -1, 30, hereditary: false, allowPoisoning: false, noMeatEating: false, noDrinking: false, 2, 1, 7, new List<sbyte>(), -1, new List<short> { 480, 481, 482, 483, 484 }, new List<sbyte> { 2, 4, 12 }, new List<sbyte> { 0, 1, 2, 3, 7, 11 }, 3, 15, new sbyte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, -1, 0, 0
		}, new short[9] { 81, 80, 79, 78, 77, 76, 75, 74, 73 }, 1, 578, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_4"), 306, new short[8] { 273, 354, 435, 480, 453, 489, 786, 777 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_4"), 3, new ShortPair[6]
		{
			new ShortPair(15, 100),
			new ShortPair(2, 25),
			new ShortPair(19, 25),
			new ShortPair(26, 25),
			new ShortPair(30, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 10),
			new LifeSkillCombatBriberyItemTypeWeight(1, 10),
			new LifeSkillCombatBriberyItemTypeWeight(2, 20),
			new LifeSkillCombatBriberyItemTypeWeight(4, 0),
			new LifeSkillCombatBriberyItemTypeWeight(7, 0)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 40),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 20),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Medicine", 88, 3, 100)
		}, new List<PresetInventoryItem>(), 0, 90));
		_dataArray.Add(new OrganizationItem(5, LocalStringManager.GetConfig("Organization_language", "Name_5"), LocalStringManager.GetConfig("Organization_language", "Desc_5"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_5"), "ui9_icon_faction_15", "mousetip_menpai_5", -18, 150, 800, new short[2] { 8, 9 }, new short[9] { 428, 427, 426, 425, 424, 423, 422, 421, 420 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, -1, 1, 500, -1, 20, hereditary: false, allowPoisoning: false, noMeatEating: true, noDrinking: false, 0, 1, 5, new List<sbyte>(), -1, null, new List<sbyte> { 8, 9, 12, 13, 14 }, new List<sbyte> { 0, 1, 2, 5, 7, 8 }, 4, 18, new sbyte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, -1, 0, 0, 0
		}, new short[9] { 90, 89, 88, 87, 86, 85, 84, 83, 82 }, 0, 579, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_5"), 307, new short[7] { 453, 471, 498, 570, 588, 525, 579 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_5"), 4, new ShortPair[3]
		{
			new ShortPair(14, 50),
			new ShortPair(15, 50),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 20),
			new LifeSkillCombatBriberyItemTypeWeight(1, 20),
			new LifeSkillCombatBriberyItemTypeWeight(2, 20),
			new LifeSkillCombatBriberyItemTypeWeight(4, 20),
			new LifeSkillCombatBriberyItemTypeWeight(7, 0)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 20),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Medicine", 292, 3, 100)
		}, new List<PresetInventoryItem>(), 0, 90));
		_dataArray.Add(new OrganizationItem(6, LocalStringManager.GetConfig("Organization_language", "Name_6"), LocalStringManager.GetConfig("Organization_language", "Desc_6"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_6"), "ui9_icon_faction_10", "mousetip_menpai_6", -18, -18, 750, new short[2] { 10, 11 }, new short[9] { 437, 436, 435, 434, 433, 432, 431, 430, 429 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, -1, 0, -250, -1, 40, hereditary: true, allowPoisoning: false, noMeatEating: false, noDrinking: false, 3, 1, 9, new List<sbyte>(), -1, new List<short> { 485, 486, 487, 488, 489 }, new List<sbyte> { 6, 7, 14, 15 }, new List<sbyte> { 0, 1, 2, 3, 8, 9 }, 0, 9, new sbyte[15]
		{
			0, 0, 0, 0, 0, 0, -1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new short[9] { 99, 98, 97, 96, 95, 94, 93, 92, 91 }, 0, 580, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_6"), 308, new short[7] { 282, 525, 543, 552, 561, 624, 642 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_6"), 5, new ShortPair[3]
		{
			new ShortPair(22, 50),
			new ShortPair(29, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 20),
			new LifeSkillCombatBriberyItemTypeWeight(1, 20),
			new LifeSkillCombatBriberyItemTypeWeight(2, 15),
			new LifeSkillCombatBriberyItemTypeWeight(4, 20),
			new LifeSkillCombatBriberyItemTypeWeight(7, 20)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 5),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("TeaWine", 2, 3, 100),
			new PresetInventoryItem("TeaWine", 11, 3, 100)
		}, new List<PresetInventoryItem>(), 0, 90));
		_dataArray.Add(new OrganizationItem(7, LocalStringManager.GetConfig("Organization_language", "Name_7"), LocalStringManager.GetConfig("Organization_language", "Desc_7"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_7"), "ui9_icon_faction_8", "mousetip_menpai_7", 150, -18, 100, new short[2] { 12, 13 }, new short[9] { 446, 445, 444, 443, 442, 441, 440, 439, 438 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, 3, 0, 0, -1, 30, hereditary: false, allowPoisoning: true, noMeatEating: true, noDrinking: false, 1, 1, 1, new List<sbyte>(), -1, new List<short> { 490, 491, 492, 493, 494 }, new List<sbyte> { 2, 4, 11, 12, 15 }, new List<sbyte> { 0, 1, 2, 4, 7, 10 }, 1, 15, new sbyte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, -1,
			0, 0, 0, 0, 0
		}, new short[9] { 108, 107, 106, 105, 104, 103, 102, 101, 100 }, 2, 581, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_7"), 309, new short[5] { 309, 336, 498, 516, 48 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_7"), 6, new ShortPair[7]
		{
			new ShortPair(15, 100),
			new ShortPair(2, 25),
			new ShortPair(10, 25),
			new ShortPair(13, 25),
			new ShortPair(20, 25),
			new ShortPair(31, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 5),
			new LifeSkillCombatBriberyItemTypeWeight(1, 0),
			new LifeSkillCombatBriberyItemTypeWeight(2, 20),
			new LifeSkillCombatBriberyItemTypeWeight(4, 0),
			new LifeSkillCombatBriberyItemTypeWeight(7, 0)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 50),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 25),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Medicine", 112, 3, 100)
		}, new List<PresetInventoryItem>(), 0, 70));
		_dataArray.Add(new OrganizationItem(8, LocalStringManager.GetConfig("Organization_language", "Name_8"), LocalStringManager.GetConfig("Organization_language", "Desc_8"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_8"), "ui9_icon_faction_13", "mousetip_menpai_8", 150, -18, 400, new short[2] { 14, 15 }, new short[9] { 455, 454, 453, 452, 451, 450, 449, 448, 447 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, -1, 0, 500, 0, 10, hereditary: false, allowPoisoning: true, noMeatEating: false, noDrinking: false, 6, 1, 13, new List<sbyte> { 6, 7, 9, 10, 16 }, 220, new List<short> { 495, 496, 497, 498, 499 }, new List<sbyte> { 0, 3, 5, 12 }, new List<sbyte> { 0, 1, 2, 3, 4, 13 }, 2, 18, new sbyte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, -1, 0,
			0, 0, 0, 0, 0
		}, new short[9] { 117, 116, 115, 114, 113, 112, 111, 110, 109 }, 1, 582, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_8"), 310, new short[6] { 336, 327, 345, 318, 309, 741 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_8"), 7, new ShortPair[6]
		{
			new ShortPair(0, 100),
			new ShortPair(3, 25),
			new ShortPair(11, 25),
			new ShortPair(25, 25),
			new ShortPair(33, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 5),
			new LifeSkillCombatBriberyItemTypeWeight(1, 0),
			new LifeSkillCombatBriberyItemTypeWeight(2, 30),
			new LifeSkillCombatBriberyItemTypeWeight(4, 0),
			new LifeSkillCombatBriberyItemTypeWeight(7, 0)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 40),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 25),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Medicine", 268, 3, 100)
		}, new List<PresetInventoryItem>(), 0, 70));
		_dataArray.Add(new OrganizationItem(9, LocalStringManager.GetConfig("Organization_language", "Name_9"), LocalStringManager.GetConfig("Organization_language", "Desc_9"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_9"), "ui9_icon_faction_16", "mousetip_menpai_9", -18, -18, 300, new short[2] { 16, 17 }, new short[9] { 464, 463, 462, 461, 460, 459, 458, 457, 456 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, -1, 0, 0, -1, 30, hereditary: true, allowPoisoning: false, noMeatEating: false, noDrinking: false, 5, 1, 12, new List<sbyte>(), -1, null, new List<sbyte> { 6, 7, 10, 11 }, new List<sbyte> { 0, 1, 2, 7, 8, 9, 12 }, 3, 12, new sbyte[15]
		{
			0, 0, 0, 0, 0, -1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new short[9] { 126, 125, 124, 123, 122, 121, 120, 119, 118 }, 2, 583, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_9"), 311, new short[20]
		{
			462, 435, 471, 444, 480, 453, 534, 561, 543, 570,
			552, 525, 615, 669, 633, 687, 651, 660, 30, 21
		}, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_9"), 8, new ShortPair[9]
		{
			new ShortPair(6, 100),
			new ShortPair(7, 100),
			new ShortPair(8, 50),
			new ShortPair(9, 50),
			new ShortPair(29, 25),
			new ShortPair(30, 25),
			new ShortPair(31, 25),
			new ShortPair(32, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 20),
			new LifeSkillCombatBriberyItemTypeWeight(1, 20),
			new LifeSkillCombatBriberyItemTypeWeight(2, 5),
			new LifeSkillCombatBriberyItemTypeWeight(4, 5),
			new LifeSkillCombatBriberyItemTypeWeight(7, 0)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 10),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 10),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 10),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 10),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 10)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 0, 3, 100),
			new PresetInventoryItem("Material", 7, 3, 100),
			new PresetInventoryItem("Material", 14, 3, 100),
			new PresetInventoryItem("Material", 21, 3, 100),
			new PresetInventoryItem("Material", 28, 3, 100),
			new PresetInventoryItem("Material", 35, 3, 100),
			new PresetInventoryItem("Material", 42, 3, 100),
			new PresetInventoryItem("Material", 49, 3, 100)
		}, new List<PresetInventoryItem>(), 0, 70));
		_dataArray.Add(new OrganizationItem(10, LocalStringManager.GetConfig("Organization_language", "Name_10"), LocalStringManager.GetConfig("Organization_language", "Desc_10"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_10"), "ui9_icon_faction_6", "mousetip_menpai_10", -18, 125, 500, new short[2] { 18, 19 }, new short[9] { 473, 472, 471, 470, 469, 468, 467, 466, 465 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, -1, 0, -500, -1, 20, hereditary: false, allowPoisoning: true, noMeatEating: false, noDrinking: true, 4, 1, 2, new List<sbyte>(), -1, null, new List<sbyte> { 8, 9, 10, 11 }, new List<sbyte> { 0, 1, 2, 3, 4, 5, 6 }, 4, 18, new sbyte[15]
		{
			0, 0, 0, 0, 0, 0, 0, -1, 0, 0,
			0, 0, 0, 0, 0
		}, new short[9] { 135, 134, 133, 132, 131, 130, 129, 128, 127 }, 3, 584, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_10"), 312, new short[5] { 273, 336, 318, 372, 3 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_10"), 9, new ShortPair[11]
		{
			new ShortPair(4, 100),
			new ShortPair(5, 100),
			new ShortPair(18, 25),
			new ShortPair(41, 25),
			new ShortPair(42, 25),
			new ShortPair(43, 25),
			new ShortPair(44, 25),
			new ShortPair(45, 25),
			new ShortPair(46, 25),
			new ShortPair(32, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 5),
			new LifeSkillCombatBriberyItemTypeWeight(1, 0),
			new LifeSkillCombatBriberyItemTypeWeight(2, 0),
			new LifeSkillCombatBriberyItemTypeWeight(4, 0),
			new LifeSkillCombatBriberyItemTypeWeight(7, 0)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 5),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 25),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 25),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 20),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 20),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Medicine", 100, 3, 100)
		}, new List<PresetInventoryItem>(), 0, 70));
		_dataArray.Add(new OrganizationItem(11, LocalStringManager.GetConfig("Organization_language", "Name_11"), LocalStringManager.GetConfig("Organization_language", "Desc_11"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_11"), "ui9_icon_faction_5", "mousetip_menpai_11", -18, -18, 750, new short[2] { 30, 31 }, new short[9] { 482, 481, 480, 479, 478, 477, 476, 475, 474 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, -1, -1, -500, -1, 10, hereditary: false, allowPoisoning: true, noMeatEating: false, noDrinking: false, 3, 1, 8, new List<sbyte> { 12, 13, 14, 15, 16 }, 221, new List<short> { 500, 501, 502, 503, 504 }, new List<sbyte> { 5, 13, 15 }, new List<sbyte> { 0, 1, 2, 3, 8, 10 }, 0, 6, new sbyte[15]
		{
			0, -1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new short[9] { 144, 143, 142, 141, 140, 139, 138, 137, 136 }, 4, 585, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_11"), 313, new short[9] { 282, 300, 534, 525, 552, 570, 381, 390, 408 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_11"), 10, new ShortPair[4]
		{
			new ShortPair(14, 50),
			new ShortPair(16, 25),
			new ShortPair(17, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 10),
			new LifeSkillCombatBriberyItemTypeWeight(1, 10),
			new LifeSkillCombatBriberyItemTypeWeight(2, 40),
			new LifeSkillCombatBriberyItemTypeWeight(4, 10),
			new LifeSkillCombatBriberyItemTypeWeight(7, 20)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 10),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>(), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 37, 1, 100),
			new PresetInventoryItem("Misc", 42, 1, 100),
			new PresetInventoryItem("Misc", 47, 1, 100),
			new PresetInventoryItem("Misc", 52, 1, 100),
			new PresetInventoryItem("Misc", 57, 1, 100),
			new PresetInventoryItem("Misc", 62, 1, 100),
			new PresetInventoryItem("Misc", 67, 1, 100),
			new PresetInventoryItem("Misc", 72, 1, 100),
			new PresetInventoryItem("Misc", 77, 1, 100)
		}, 3, 80));
		_dataArray.Add(new OrganizationItem(12, LocalStringManager.GetConfig("Organization_language", "Name_12"), LocalStringManager.GetConfig("Organization_language", "Desc_12"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_12"), "ui9_icon_faction_11", "mousetip_menpai_12", -18, -18, 550, new short[2] { 22, 23 }, new short[9] { 491, 490, 489, 488, 487, 486, 485, 484, 483 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, -1, -1, -250, -1, 20, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, 2, 1, 11, new List<sbyte>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 13, 14, 15, 16
		}, 222, null, new List<sbyte> { 7, 8, 9 }, new List<sbyte> { 0, 1, 2, 3, 4, 7, 11 }, 1, 15, new sbyte[15]
		{
			0, 0, 0, 0, -1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new short[9] { 153, 152, 151, 150, 149, 148, 147, 146, 145 }, 3, 586, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_12"), 314, new short[11]
		{
			354, 273, 345, 372, 336, 327, 480, 498, 489, 795,
			813
		}, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_12"), 11, new ShortPair[9]
		{
			new ShortPair(5, 100),
			new ShortPair(41, 25),
			new ShortPair(42, 25),
			new ShortPair(43, 25),
			new ShortPair(44, 25),
			new ShortPair(45, 25),
			new ShortPair(46, 25),
			new ShortPair(30, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 10),
			new LifeSkillCombatBriberyItemTypeWeight(1, 0),
			new LifeSkillCombatBriberyItemTypeWeight(2, 0),
			new LifeSkillCombatBriberyItemTypeWeight(4, 0),
			new LifeSkillCombatBriberyItemTypeWeight(7, 0)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 20),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 25),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 35),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 10),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Medicine", 2, 1, 100),
			new PresetInventoryItem("Medicine", 11, 1, 100),
			new PresetInventoryItem("Medicine", 20, 1, 100),
			new PresetInventoryItem("Medicine", 29, 1, 100),
			new PresetInventoryItem("Medicine", 38, 1, 100),
			new PresetInventoryItem("Medicine", 47, 1, 100)
		}, new List<PresetInventoryItem>(), 0, 80));
		_dataArray.Add(new OrganizationItem(13, LocalStringManager.GetConfig("Organization_language", "Name_13"), LocalStringManager.GetConfig("Organization_language", "Desc_13"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_13"), "ui9_icon_faction_4", "mousetip_menpai_13", 125, -18, 350, new short[2] { 24, 25 }, new short[9] { 500, 499, 498, 497, 496, 495, 494, 493, 492 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, -1, -1, -250, -1, 10, hereditary: false, allowPoisoning: true, noMeatEating: true, noDrinking: false, 6, 1, 6, new List<sbyte>(), -1, new List<short> { 505, 506, 507, 508, 509 }, new List<sbyte> { 1, 4, 9 }, new List<sbyte> { 0, 1, 2, 4, 6, 7 }, 2, 9, new sbyte[15]
		{
			0, 0, 0, -1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new short[9] { 162, 161, 160, 159, 158, 157, 156, 155, 154 }, 0, 587, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_13"), 315, new short[8] { 318, 309, 363, 183, 192, 201, 462, 435 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_13"), 12, new ShortPair[6]
		{
			new ShortPair(10, 50),
			new ShortPair(1, 50),
			new ShortPair(27, 25),
			new ShortPair(28, 25),
			new ShortPair(34, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 5),
			new LifeSkillCombatBriberyItemTypeWeight(1, 0),
			new LifeSkillCombatBriberyItemTypeWeight(2, 20),
			new LifeSkillCombatBriberyItemTypeWeight(4, 0),
			new LifeSkillCombatBriberyItemTypeWeight(7, 0)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 25),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 10),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 20),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 20),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Medicine", 316, 3, 100)
		}, new List<PresetInventoryItem>(), 0, 80));
		_dataArray.Add(new OrganizationItem(14, LocalStringManager.GetConfig("Organization_language", "Name_14"), LocalStringManager.GetConfig("Organization_language", "Desc_14"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_14"), "ui9_icon_faction_3", "mousetip_menpai_14", -18, -18, 500, new short[2] { 26, 27 }, new short[9] { 509, 508, 507, 506, 505, 504, 503, 502, 501 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, -1, -1, 500, -1, 30, hereditary: true, allowPoisoning: false, noMeatEating: false, noDrinking: false, 5, 1, 3, new List<sbyte>(), -1, new List<short> { 510, 511, 512, 513, 514 }, new List<sbyte> { 5, 6, 14 }, new List<sbyte> { 0, 1, 2, 3, 6, 8 }, 3, 12, new sbyte[15]
		{
			-1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new short[9] { 171, 170, 169, 168, 167, 166, 165, 164, 163 }, 2, 588, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_14"), 316, new short[7] { 282, 273, 300, 165, 525, 543, 561 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_14"), 13, new ShortPair[7]
		{
			new ShortPair(11, 50),
			new ShortPair(12, 50),
			new ShortPair(21, 25),
			new ShortPair(38, 25),
			new ShortPair(39, 25),
			new ShortPair(29, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 20),
			new LifeSkillCombatBriberyItemTypeWeight(1, 20),
			new LifeSkillCombatBriberyItemTypeWeight(2, 10),
			new LifeSkillCombatBriberyItemTypeWeight(4, 0),
			new LifeSkillCombatBriberyItemTypeWeight(7, 40)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 10),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 57, 3, 100),
			new PresetInventoryItem("Material", 64, 3, 100),
			new PresetInventoryItem("Material", 71, 3, 100),
			new PresetInventoryItem("Material", 78, 3, 100)
		}, new List<PresetInventoryItem>(), 0, 80));
		_dataArray.Add(new OrganizationItem(15, LocalStringManager.GetConfig("Organization_language", "Name_15"), LocalStringManager.GetConfig("Organization_language", "Desc_15"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_15"), "ui9_icon_faction_14", "mousetip_menpai_15", -18, -18, 750, new short[2] { 28, 29 }, new short[9] { 518, 517, 516, 515, 514, 513, 512, 511, 510 }, EOrganizationSettlementType.Sect, isSect: true, isCivilian: false, -1, -1, -500, -1, 10, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, 0, 1, 0, new List<sbyte>(), -1, null, new List<sbyte> { 5, 8, 9, 13, 15 }, new List<sbyte> { 0, 1, 2, 3, 4, 5, 6 }, 4, 6, new sbyte[15]
		{
			0, 0, -1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new short[9] { 180, 179, 178, 177, 176, 175, 174, 173, 172 }, 4, 589, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_15"), 317, new short[6] { 345, 273, 354, 291, 345, 12 }, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_15"), 14, new ShortPair[6]
		{
			new ShortPair(40, 100),
			new ShortPair(13, 25),
			new ShortPair(41, 25),
			new ShortPair(43, 25),
			new ShortPair(45, 25),
			new ShortPair(37, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>
		{
			new LifeSkillCombatBriberyItemTypeWeight(0, 5),
			new LifeSkillCombatBriberyItemTypeWeight(1, 5),
			new LifeSkillCombatBriberyItemTypeWeight(2, 20),
			new LifeSkillCombatBriberyItemTypeWeight(4, 5),
			new LifeSkillCombatBriberyItemTypeWeight(7, 5)
		}, new List<LifeSkillCombatBriberyItemSubTypeWeight>
		{
			new LifeSkillCombatBriberyItemSubTypeWeight(1000, 15),
			new LifeSkillCombatBriberyItemSubTypeWeight(800, 5),
			new LifeSkillCombatBriberyItemSubTypeWeight(801, 20),
			new LifeSkillCombatBriberyItemSubTypeWeight(505, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(506, 20),
			new LifeSkillCombatBriberyItemSubTypeWeight(501, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(502, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(503, 0),
			new LifeSkillCombatBriberyItemSubTypeWeight(504, 0)
		}, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 11, 9, 100)
		}, new List<PresetInventoryItem>(), 0, 100));
		_dataArray.Add(new OrganizationItem(16, LocalStringManager.GetConfig("Organization_language", "Name_16"), LocalStringManager.GetConfig("Organization_language", "Desc_16"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_16"), "ui9_icon_faction_0", null, 25, 100, 100, new short[2] { -1, -1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.TaiwuVillage, isSect: false, isCivilian: false, -1, 1, short.MinValue, -1, 20, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 1, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 18, 17, 16, 15, 14, 13, 12, 11, 10 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_16"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_16"), -1, new ShortPair[48]
		{
			new ShortPair(33, 36),
			new ShortPair(34, 36),
			new ShortPair(47, 36),
			new ShortPair(37, 36),
			new ShortPair(35, 12),
			new ShortPair(36, 12),
			new ShortPair(38, 12),
			new ShortPair(39, 12),
			new ShortPair(41, 12),
			new ShortPair(42, 12),
			new ShortPair(43, 12),
			new ShortPair(44, 12),
			new ShortPair(45, 12),
			new ShortPair(46, 12),
			new ShortPair(21, 6),
			new ShortPair(22, 6),
			new ShortPair(23, 6),
			new ShortPair(24, 6),
			new ShortPair(25, 6),
			new ShortPair(26, 6),
			new ShortPair(27, 6),
			new ShortPair(28, 6),
			new ShortPair(40, 6),
			new ShortPair(0, 1),
			new ShortPair(1, 1),
			new ShortPair(2, 1),
			new ShortPair(3, 1),
			new ShortPair(4, 1),
			new ShortPair(5, 1),
			new ShortPair(6, 1),
			new ShortPair(7, 1),
			new ShortPair(8, 1),
			new ShortPair(9, 1),
			new ShortPair(10, 1),
			new ShortPair(11, 1),
			new ShortPair(12, 1),
			new ShortPair(13, 1),
			new ShortPair(14, 1),
			new ShortPair(15, 1),
			new ShortPair(16, 1),
			new ShortPair(17, 1),
			new ShortPair(18, 1),
			new ShortPair(19, 1),
			new ShortPair(20, 1),
			new ShortPair(29, 1),
			new ShortPair(30, 1),
			new ShortPair(31, 1),
			new ShortPair(32, 1)
		}, new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, -1));
		_dataArray.Add(new OrganizationItem(17, LocalStringManager.GetConfig("Organization_language", "Name_17"), LocalStringManager.GetConfig("Organization_language", "Desc_17"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_17"), null, null, 0, 0, 0, new short[2] { -1, -1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.Invalid, isSect: false, isCivilian: false, -1, -1, short.MinValue, -1, 0, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 1, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, -1, new sbyte[15], new short[9] { 27, 26, 25, 24, 23, 22, 21, 20, 19 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_17"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_17"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, -1));
		_dataArray.Add(new OrganizationItem(18, LocalStringManager.GetConfig("Organization_language", "Name_18"), LocalStringManager.GetConfig("Organization_language", "Desc_18"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_18"), null, null, 0, 0, 0, new short[2] { -1, -1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.Invalid, isSect: false, isCivilian: false, -1, 1, short.MinValue, -1, 0, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 1, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, -1, new sbyte[15], new short[9] { 36, 35, 34, 33, 32, 31, 30, 29, 28 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_18"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_18"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, -1));
		_dataArray.Add(new OrganizationItem(19, LocalStringManager.GetConfig("Organization_language", "Name_19"), LocalStringManager.GetConfig("Organization_language", "Desc_19"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_19"), null, null, 0, 0, 0, new short[2] { -1, -1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.Invalid, isSect: false, isCivilian: false, -1, -1, short.MinValue, -1, 0, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 1, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, -1, new sbyte[15], new short[9] { 45, 44, 43, 42, 41, 40, 39, 38, 37 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_19"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_19"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, -1));
		_dataArray.Add(new OrganizationItem(20, LocalStringManager.GetConfig("Organization_language", "Name_20"), LocalStringManager.GetConfig("Organization_language", "Desc_20"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_20"), null, null, 0, 0, 0, new short[2] { -1, -1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.Invalid, isSect: false, isCivilian: false, -1, -1, short.MinValue, -1, 0, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 1, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, -1, new sbyte[15], new short[9] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_20"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_20"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, -1));
		_dataArray.Add(new OrganizationItem(21, LocalStringManager.GetConfig("Organization_language", "Name_21"), LocalStringManager.GetConfig("Organization_language", "Desc_21"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_21"), "ui9_icon_faction_17", null, 150, 125, 550000, new short[2] { 0, 1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_21"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_21"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(22, LocalStringManager.GetConfig("Organization_language", "Name_22"), LocalStringManager.GetConfig("Organization_language", "Desc_22"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_22"), "ui9_icon_faction_17", null, 150, 125, 120000, new short[2] { 2, 3 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_22"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_22"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(23, LocalStringManager.GetConfig("Organization_language", "Name_23"), LocalStringManager.GetConfig("Organization_language", "Desc_23"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_23"), "ui9_icon_faction_17", null, 75, 150, 52000, new short[2] { 4, 5 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_23"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_23"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(24, LocalStringManager.GetConfig("Organization_language", "Name_24"), LocalStringManager.GetConfig("Organization_language", "Desc_24"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_24"), "ui9_icon_faction_17", null, 125, 175, 120000, new short[2] { 6, 7 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_24"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_24"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(25, LocalStringManager.GetConfig("Organization_language", "Name_25"), LocalStringManager.GetConfig("Organization_language", "Desc_25"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_25"), "ui9_icon_faction_17", null, 100, 175, 58000, new short[2] { 8, 9 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_25"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_25"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(26, LocalStringManager.GetConfig("Organization_language", "Name_26"), LocalStringManager.GetConfig("Organization_language", "Desc_26"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_26"), "ui9_icon_faction_17", null, 125, 75, 78000, new short[2] { 10, 11 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_26"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_26"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(27, LocalStringManager.GetConfig("Organization_language", "Name_27"), LocalStringManager.GetConfig("Organization_language", "Desc_27"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_27"), "ui9_icon_faction_17", null, 100, 100, 54000, new short[2] { 12, 13 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_27"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_27"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(28, LocalStringManager.GetConfig("Organization_language", "Name_28"), LocalStringManager.GetConfig("Organization_language", "Desc_28"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_28"), "ui9_icon_faction_17", null, 175, 125, 75000, new short[2] { 14, 15 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_28"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_28"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(29, LocalStringManager.GetConfig("Organization_language", "Name_29"), LocalStringManager.GetConfig("Organization_language", "Desc_29"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_29"), "ui9_icon_faction_17", null, 125, 150, 140000, new short[2] { 16, 17 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_29"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_29"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(30, LocalStringManager.GetConfig("Organization_language", "Name_30"), LocalStringManager.GetConfig("Organization_language", "Desc_30"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_30"), "ui9_icon_faction_17", null, 75, 175, 56000, new short[2] { 18, 19 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_30"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_30"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(31, LocalStringManager.GetConfig("Organization_language", "Name_31"), LocalStringManager.GetConfig("Organization_language", "Desc_31"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_31"), "ui9_icon_faction_17", null, 75, 75, 32000, new short[2] { 20, 21 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_31"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_31"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(32, LocalStringManager.GetConfig("Organization_language", "Name_32"), LocalStringManager.GetConfig("Organization_language", "Desc_32"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_32"), "ui9_icon_faction_17", null, 100, 150, 68000, new short[2] { 22, 23 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_32"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_32"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(33, LocalStringManager.GetConfig("Organization_language", "Name_33"), LocalStringManager.GetConfig("Organization_language", "Desc_33"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_33"), "ui9_icon_faction_17", null, 150, 100, 85000, new short[2] { 24, 25 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_33"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_33"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(34, LocalStringManager.GetConfig("Organization_language", "Name_34"), LocalStringManager.GetConfig("Organization_language", "Desc_34"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_34"), "ui9_icon_faction_17", null, 175, 100, 160000, new short[2] { 26, 27 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_34"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_34"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(35, LocalStringManager.GetConfig("Organization_language", "Name_35"), LocalStringManager.GetConfig("Organization_language", "Desc_35"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_35"), "ui9_icon_faction_17", null, 175, 75, 110000, new short[2] { 28, 29 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.City, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 4, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 189, 188, 187, 186, 185, 184, 183, 182, 181 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_35"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_35"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 30));
		_dataArray.Add(new OrganizationItem(36, LocalStringManager.GetConfig("Organization_language", "Name_36"), LocalStringManager.GetConfig("Organization_language", "Desc_36"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_36"), "ui9_icon_faction_18", null, -10, -10, 50, new short[2] { -1, -1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.Village, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 1, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 198, 197, 196, 195, 194, 193, 192, 191, 190 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_36"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_36"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 20));
		_dataArray.Add(new OrganizationItem(37, LocalStringManager.GetConfig("Organization_language", "Name_37"), LocalStringManager.GetConfig("Organization_language", "Desc_37"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_37"), "ui9_icon_faction_20", null, -18, -18, 1000, new short[2] { -1, -1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.Town, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 3, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 207, 206, 205, 204, 203, 202, 201, 200, 199 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_37"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_37"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 25));
		_dataArray.Add(new OrganizationItem(38, LocalStringManager.GetConfig("Organization_language", "Name_38"), LocalStringManager.GetConfig("Organization_language", "Desc_38"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_38"), "ui9_icon_faction_19", null, -14, -14, 300, new short[2] { -1, -1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.WalledTown, isSect: false, isCivilian: true, -1, 0, short.MinValue, -1, 30, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 2, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, 12, new sbyte[15], new short[9] { 216, 215, 214, 213, 212, 211, 210, 209, 208 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_38"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_38"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, 25));
		_dataArray.Add(new OrganizationItem(39, LocalStringManager.GetConfig("Organization_language", "Name_39"), LocalStringManager.GetConfig("Organization_language", "Desc_39"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_39"), null, null, 0, 0, 0, new short[2] { -1, -1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.Invalid, isSect: false, isCivilian: false, -1, -1, short.MinValue, -1, 0, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 1, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, -1, new sbyte[15], new short[9] { 225, 224, 223, 222, 221, 220, 219, 218, 217 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_39"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_39"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, -1));
		_dataArray.Add(new OrganizationItem(40, LocalStringManager.GetConfig("Organization_language", "Name_40"), LocalStringManager.GetConfig("Organization_language", "Desc_40"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_40"), null, null, 0, 0, 0, new short[2] { -1, -1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.Invalid, isSect: false, isCivilian: false, -1, -1, short.MinValue, -1, 0, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 1, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, -1, new sbyte[15], new short[9] { 234, 233, 232, 231, 230, 229, 228, 227, 226 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_40"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_40"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, -1));
		_dataArray.Add(new OrganizationItem(41, LocalStringManager.GetConfig("Organization_language", "Name_41"), LocalStringManager.GetConfig("Organization_language", "Desc_41"), LocalStringManager.GetConfig("Organization_language", "TaiwuVillageSteleDesc_41"), null, null, 0, 0, 0, new short[2] { -1, -1 }, new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 }, EOrganizationSettlementType.Invalid, isSect: false, isCivilian: false, -1, -1, short.MinValue, -1, 0, hereditary: true, allowPoisoning: true, noMeatEating: false, noDrinking: false, -1, 1, -1, new List<sbyte>(), -1, null, new List<sbyte>(), new List<sbyte>(), -1, -1, new sbyte[15], new short[9] { 243, 242, 241, 240, 239, 238, 237, 236, 235 }, 0, -1, LocalStringManager.GetConfig("Organization_language", "OrganizationExtraDesc_41"), -1, null, LocalStringManager.GetConfig("Organization_language", "VowSpecialHint_41"), -1, new ShortPair[0], new List<LifeSkillCombatBriberyItemTypeWeight>(), new List<LifeSkillCombatBriberyItemSubTypeWeight>(), new List<PresetInventoryItem>(), new List<PresetInventoryItem>(), 0, -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<OrganizationItem>(42);
		CreateItems0();
	}
}
