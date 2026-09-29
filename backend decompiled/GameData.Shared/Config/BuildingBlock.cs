using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BuildingBlock : ConfigData<BuildingBlockItem, short>
{
	public static class DefKey
	{
		public const short EmptyBlock = 0;

		public const short NormalResourceBegin = 1;

		public const short SpecialResourceBegin = 11;

		public const short Xuansheku = 16;

		public const short Qixiangyuan = 17;

		public const short UselessResourceBegin = 21;

		public const short Ruins = 23;

		public const short TaiwuVillage = 44;

		public const short TaiwuShrine = 45;

		public const short Residence = 46;

		public const short ComfortableHouse = 47;

		public const short Warehouse = 48;

		public const short ChickenCoop = 49;

		public const short SamsaraPlatform = 50;

		public const short TeaHorseCaravan = 51;

		public const short KungfuPracticeRoom = 52;

		public const short IceWall = 56;

		public const short PhoenixPlatform = 91;

		public const short StrategyRoom = 98;

		public const short BookCollectionRoom = 105;

		public const short MakeupRoom = 112;

		public const short BirthDeathStreamer = 119;

		public const short TeaHouse = 121;

		public const short Tavern = 122;

		public const short FourSeasMansion = 124;

		public const short TeaPlantation = 127;

		public const short Distillery = 128;

		public const short ForgingRoom = 129;

		public const short WoodworkingRoom = 139;

		public const short MedicineRoom = 149;

		public const short Hospital = 152;

		public const short ToxicologyRoom = 159;

		public const short PoisonHospital = 162;

		public const short WeavingRoom = 169;

		public const short JadeRoom = 179;

		public const short LifeElixirRoom = 195;

		public const short SutraReadingRoom = 202;

		public const short Kitchen = 203;

		public const short GamblingHouse = 215;

		public const short Brothel = 216;

		public const short RecruitBeauty = 217;

		public const short Pawnshop = 222;

		public const short ExcellentPersonShop = 223;

		public const short Jingcheng = 224;

		public const short Chengdu = 225;

		public const short Guizhou = 226;

		public const short Xiangyang = 227;

		public const short Taiyuan = 228;

		public const short Guangzhou = 229;

		public const short Qingzhou = 230;

		public const short Jiangling = 231;

		public const short Fuzhou = 232;

		public const short LiaoYang = 233;

		public const short Qinzhou = 234;

		public const short Dali = 235;

		public const short Shouchun = 236;

		public const short Hangzhou = 237;

		public const short Yangzhou = 238;

		public const short Shaolin = 239;

		public const short Emei = 240;

		public const short Baihua = 241;

		public const short Wudang = 242;

		public const short Yuanshan = 243;

		public const short Shixiang = 244;

		public const short Ranshan = 245;

		public const short Xuannv = 246;

		public const short Zhujian = 247;

		public const short Kongsang = 248;

		public const short Jingang = 249;

		public const short Wuxian = 250;

		public const short Jieqing = 251;

		public const short Fulong = 252;

		public const short Xuehou = 253;

		public const short Cunzhuang = 254;

		public const short Shizhen = 255;

		public const short Guanzhai = 256;

		public const short BambooHouse1 = 257;

		public const short BambooHouse2 = 258;

		public const short ShaolinSpecialBuilding = 259;

		public const short EmeiSpecialBuilding = 260;

		public const short BaihuaSpecialBuilding = 261;

		public const short WudangSpecialBuilding = 262;

		public const short YuanshanSpecialBuilding = 263;

		public const short ShixiangSpecialBuilding = 264;

		public const short RanshanSpecialBuilding = 265;

		public const short XuannvSpecialBuilding = 266;

		public const short ZhujianSpecialBuilding = 267;

		public const short KongsangSpecialBuilding = 268;

		public const short JingangSpecialBuilding = 269;

		public const short WuxianSpecialBuilding = 270;

		public const short JieqingSpecialBuilding = 271;

		public const short FulongSpecialBuilding = 272;

		public const short XuehouSpecialBuilding = 273;

		public const short BodhidharmaStupa = 274;

		public const short QiWenXingTai = 275;

		public const short MerchantBuildingBegin = 276;

		public const short MerchantBuildingEnd = 282;

		public const short WuHuZhenBao = 283;

		public const short TreasuryZhucheng = 284;

		public const short TreasuryShizhen = 285;

		public const short TreasuryCunzhuang = 286;

		public const short TreasuryGuanzhai = 287;

		public const short TreasuryShaolin = 288;

		public const short TreasuryEmei = 289;

		public const short TreasuryBaihua = 290;

		public const short TreasuryWudang = 291;

		public const short TreasuryYuanshan = 292;

		public const short TreasuryShixiang = 293;

		public const short TreasuryRanshan = 294;

		public const short TreasuryXuannv = 295;

		public const short TreasuryZhujian = 296;

		public const short TreasuryKongsang = 297;

		public const short TreasuryJingang = 298;

		public const short TreasuryWuxian = 299;

		public const short TreasuryJieqing = 300;

		public const short TreasuryFulong = 301;

		public const short TreasuryXuehou = 302;

		public const short PrisonShaolin = 303;

		public const short PrisonEmei = 304;

		public const short PrisonBaihua = 305;

		public const short PrisonWudang = 306;

		public const short PrisonYuanshan = 307;

		public const short PrisonShixiang = 308;

		public const short PrisonRanshan = 309;

		public const short PrisonXuannv = 310;

		public const short PrisonZhujian = 311;

		public const short PrisonKongsang = 312;

		public const short PrisonJingang = 313;

		public const short PrisonWuxian = 314;

		public const short PrisonJieqing = 315;

		public const short PrisonFulong = 316;

		public const short PrisonXuehou = 317;

		public const short XiangshuTower = 318;
	}

	public static class DefValue
	{
		public static BuildingBlockItem EmptyBlock => Instance[(short)0];

		public static BuildingBlockItem NormalResourceBegin => Instance[(short)1];

		public static BuildingBlockItem SpecialResourceBegin => Instance[(short)11];

		public static BuildingBlockItem Xuansheku => Instance[(short)16];

		public static BuildingBlockItem Qixiangyuan => Instance[(short)17];

		public static BuildingBlockItem UselessResourceBegin => Instance[(short)21];

		public static BuildingBlockItem Ruins => Instance[(short)23];

		public static BuildingBlockItem TaiwuVillage => Instance[(short)44];

		public static BuildingBlockItem TaiwuShrine => Instance[(short)45];

		public static BuildingBlockItem Residence => Instance[(short)46];

		public static BuildingBlockItem ComfortableHouse => Instance[(short)47];

		public static BuildingBlockItem Warehouse => Instance[(short)48];

		public static BuildingBlockItem ChickenCoop => Instance[(short)49];

		public static BuildingBlockItem SamsaraPlatform => Instance[(short)50];

		public static BuildingBlockItem TeaHorseCaravan => Instance[(short)51];

		public static BuildingBlockItem KungfuPracticeRoom => Instance[(short)52];

		public static BuildingBlockItem IceWall => Instance[(short)56];

		public static BuildingBlockItem PhoenixPlatform => Instance[(short)91];

		public static BuildingBlockItem StrategyRoom => Instance[(short)98];

		public static BuildingBlockItem BookCollectionRoom => Instance[(short)105];

		public static BuildingBlockItem MakeupRoom => Instance[(short)112];

		public static BuildingBlockItem BirthDeathStreamer => Instance[(short)119];

		public static BuildingBlockItem TeaHouse => Instance[(short)121];

		public static BuildingBlockItem Tavern => Instance[(short)122];

		public static BuildingBlockItem FourSeasMansion => Instance[(short)124];

		public static BuildingBlockItem TeaPlantation => Instance[(short)127];

		public static BuildingBlockItem Distillery => Instance[(short)128];

		public static BuildingBlockItem ForgingRoom => Instance[(short)129];

		public static BuildingBlockItem WoodworkingRoom => Instance[(short)139];

		public static BuildingBlockItem MedicineRoom => Instance[(short)149];

		public static BuildingBlockItem Hospital => Instance[(short)152];

		public static BuildingBlockItem ToxicologyRoom => Instance[(short)159];

		public static BuildingBlockItem PoisonHospital => Instance[(short)162];

		public static BuildingBlockItem WeavingRoom => Instance[(short)169];

		public static BuildingBlockItem JadeRoom => Instance[(short)179];

		public static BuildingBlockItem LifeElixirRoom => Instance[(short)195];

		public static BuildingBlockItem SutraReadingRoom => Instance[(short)202];

		public static BuildingBlockItem Kitchen => Instance[(short)203];

		public static BuildingBlockItem GamblingHouse => Instance[(short)215];

		public static BuildingBlockItem Brothel => Instance[(short)216];

		public static BuildingBlockItem RecruitBeauty => Instance[(short)217];

		public static BuildingBlockItem Pawnshop => Instance[(short)222];

		public static BuildingBlockItem ExcellentPersonShop => Instance[(short)223];

		public static BuildingBlockItem Jingcheng => Instance[(short)224];

		public static BuildingBlockItem Chengdu => Instance[(short)225];

		public static BuildingBlockItem Guizhou => Instance[(short)226];

		public static BuildingBlockItem Xiangyang => Instance[(short)227];

		public static BuildingBlockItem Taiyuan => Instance[(short)228];

		public static BuildingBlockItem Guangzhou => Instance[(short)229];

		public static BuildingBlockItem Qingzhou => Instance[(short)230];

		public static BuildingBlockItem Jiangling => Instance[(short)231];

		public static BuildingBlockItem Fuzhou => Instance[(short)232];

		public static BuildingBlockItem LiaoYang => Instance[(short)233];

		public static BuildingBlockItem Qinzhou => Instance[(short)234];

		public static BuildingBlockItem Dali => Instance[(short)235];

		public static BuildingBlockItem Shouchun => Instance[(short)236];

		public static BuildingBlockItem Hangzhou => Instance[(short)237];

		public static BuildingBlockItem Yangzhou => Instance[(short)238];

		public static BuildingBlockItem Shaolin => Instance[(short)239];

		public static BuildingBlockItem Emei => Instance[(short)240];

		public static BuildingBlockItem Baihua => Instance[(short)241];

		public static BuildingBlockItem Wudang => Instance[(short)242];

		public static BuildingBlockItem Yuanshan => Instance[(short)243];

		public static BuildingBlockItem Shixiang => Instance[(short)244];

		public static BuildingBlockItem Ranshan => Instance[(short)245];

		public static BuildingBlockItem Xuannv => Instance[(short)246];

		public static BuildingBlockItem Zhujian => Instance[(short)247];

		public static BuildingBlockItem Kongsang => Instance[(short)248];

		public static BuildingBlockItem Jingang => Instance[(short)249];

		public static BuildingBlockItem Wuxian => Instance[(short)250];

		public static BuildingBlockItem Jieqing => Instance[(short)251];

		public static BuildingBlockItem Fulong => Instance[(short)252];

		public static BuildingBlockItem Xuehou => Instance[(short)253];

		public static BuildingBlockItem Cunzhuang => Instance[(short)254];

		public static BuildingBlockItem Shizhen => Instance[(short)255];

		public static BuildingBlockItem Guanzhai => Instance[(short)256];

		public static BuildingBlockItem BambooHouse1 => Instance[(short)257];

		public static BuildingBlockItem BambooHouse2 => Instance[(short)258];

		public static BuildingBlockItem ShaolinSpecialBuilding => Instance[(short)259];

		public static BuildingBlockItem EmeiSpecialBuilding => Instance[(short)260];

		public static BuildingBlockItem BaihuaSpecialBuilding => Instance[(short)261];

		public static BuildingBlockItem WudangSpecialBuilding => Instance[(short)262];

		public static BuildingBlockItem YuanshanSpecialBuilding => Instance[(short)263];

		public static BuildingBlockItem ShixiangSpecialBuilding => Instance[(short)264];

		public static BuildingBlockItem RanshanSpecialBuilding => Instance[(short)265];

		public static BuildingBlockItem XuannvSpecialBuilding => Instance[(short)266];

		public static BuildingBlockItem ZhujianSpecialBuilding => Instance[(short)267];

		public static BuildingBlockItem KongsangSpecialBuilding => Instance[(short)268];

		public static BuildingBlockItem JingangSpecialBuilding => Instance[(short)269];

		public static BuildingBlockItem WuxianSpecialBuilding => Instance[(short)270];

		public static BuildingBlockItem JieqingSpecialBuilding => Instance[(short)271];

		public static BuildingBlockItem FulongSpecialBuilding => Instance[(short)272];

		public static BuildingBlockItem XuehouSpecialBuilding => Instance[(short)273];

		public static BuildingBlockItem BodhidharmaStupa => Instance[(short)274];

		public static BuildingBlockItem QiWenXingTai => Instance[(short)275];

		public static BuildingBlockItem MerchantBuildingBegin => Instance[(short)276];

		public static BuildingBlockItem MerchantBuildingEnd => Instance[(short)282];

		public static BuildingBlockItem WuHuZhenBao => Instance[(short)283];

		public static BuildingBlockItem TreasuryZhucheng => Instance[(short)284];

		public static BuildingBlockItem TreasuryShizhen => Instance[(short)285];

		public static BuildingBlockItem TreasuryCunzhuang => Instance[(short)286];

		public static BuildingBlockItem TreasuryGuanzhai => Instance[(short)287];

		public static BuildingBlockItem TreasuryShaolin => Instance[(short)288];

		public static BuildingBlockItem TreasuryEmei => Instance[(short)289];

		public static BuildingBlockItem TreasuryBaihua => Instance[(short)290];

		public static BuildingBlockItem TreasuryWudang => Instance[(short)291];

		public static BuildingBlockItem TreasuryYuanshan => Instance[(short)292];

		public static BuildingBlockItem TreasuryShixiang => Instance[(short)293];

		public static BuildingBlockItem TreasuryRanshan => Instance[(short)294];

		public static BuildingBlockItem TreasuryXuannv => Instance[(short)295];

		public static BuildingBlockItem TreasuryZhujian => Instance[(short)296];

		public static BuildingBlockItem TreasuryKongsang => Instance[(short)297];

		public static BuildingBlockItem TreasuryJingang => Instance[(short)298];

		public static BuildingBlockItem TreasuryWuxian => Instance[(short)299];

		public static BuildingBlockItem TreasuryJieqing => Instance[(short)300];

		public static BuildingBlockItem TreasuryFulong => Instance[(short)301];

		public static BuildingBlockItem TreasuryXuehou => Instance[(short)302];

		public static BuildingBlockItem PrisonShaolin => Instance[(short)303];

		public static BuildingBlockItem PrisonEmei => Instance[(short)304];

		public static BuildingBlockItem PrisonBaihua => Instance[(short)305];

		public static BuildingBlockItem PrisonWudang => Instance[(short)306];

		public static BuildingBlockItem PrisonYuanshan => Instance[(short)307];

		public static BuildingBlockItem PrisonShixiang => Instance[(short)308];

		public static BuildingBlockItem PrisonRanshan => Instance[(short)309];

		public static BuildingBlockItem PrisonXuannv => Instance[(short)310];

		public static BuildingBlockItem PrisonZhujian => Instance[(short)311];

		public static BuildingBlockItem PrisonKongsang => Instance[(short)312];

		public static BuildingBlockItem PrisonJingang => Instance[(short)313];

		public static BuildingBlockItem PrisonWuxian => Instance[(short)314];

		public static BuildingBlockItem PrisonJieqing => Instance[(short)315];

		public static BuildingBlockItem PrisonFulong => Instance[(short)316];

		public static BuildingBlockItem PrisonXuehou => Instance[(short)317];

		public static BuildingBlockItem XiangshuTower => Instance[(short)318];
	}

	public static BuildingBlock Instance = new BuildingBlock();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "FuncDesc", "BuildingCoreItem", "DependBuildings", "ExpandBuildings", "RequireLifeSkillType", "RequireCombatSkillType", "RequirePersonalityType", "LeaderName",
		"MemberName", "BaseMaintenanceCost", "AddReadingLifeSkillBookEfficiency", "ReduceCombatSkillCost", "AddCombatSkillBreakout", "AddLifeSkillAttainment", "AddReadingLifeSkillBookFlash", "ReduceMakeRequirementLifeSkillType", "VillagerRoleTemplateIds", "SuccesEvent",
		"FailEvent", "IdleEvent", "MerchantId", "ExpandInfos", "EffectDesc", "BelongOrganization", "AvailableOrganization", "TemplateId", "Icon", "FuncIcon",
		"Color", "BaseIcon", "IconOffset"
	};

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
		_dataArray.Add(new BuildingBlockItem(0, LocalStringManager.GetConfig("BuildingBlock_language", "Name_0"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_0"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_0"), null, null, haveDynamicIcon: false, EBuildingBlockType.Empty, EBuildingBlockClass.Invalid, 0, canOpenManageOutTaiwu: false, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), -1, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_0"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_0"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_0"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 1, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(1, LocalStringManager.GetConfig("BuildingBlock_language", "Name_1"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_1"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_1"), "SectSpecial/1_shuiyu", null, haveDynamicIcon: false, EBuildingBlockType.NormalResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 500, 0, 0, 0, 0, 0, 0, 0 }, 100, 50, new sbyte[7] { 2, 0, 0, 0, 0, 0, 0 }, 100, new List<short>(), new List<short> { 24, 89, 125, 133, 217 }, 14, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_1"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_1"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 250 }, 5, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 0, 20, 33 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_1"), -1, new string[2] { "ui9_buildingarea_namebase_0_2", "ui9_buildingarea_namebase_1_2" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(2, LocalStringManager.GetConfig("BuildingBlock_language", "Name_2"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_2"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_2"), "SectSpecial/2_shihan", null, haveDynamicIcon: false, EBuildingBlockType.NormalResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 500, 0, 0, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 2, 0, 0, 0, 0 }, 101, new List<short>(), new List<short> { 25, 103, 135, 136, 183 }, 6, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_2"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_2"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 250 }, 5, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 1, 21, 34 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_2"), -1, new string[2] { "ui9_buildingarea_namebase_0_2", "ui9_buildingarea_namebase_1_2" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(3, LocalStringManager.GetConfig("BuildingBlock_language", "Name_3"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_3"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_3"), "SectSpecial/3_shulin", null, haveDynamicIcon: false, EBuildingBlockType.NormalResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 500, 0, 0, 0, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 2, 0, 0, 0, 0, 0 }, 102, new List<short>(), new List<short> { 26, 145, 146 }, 7, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_3"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_3"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 250 }, 5, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 2, 22, 35, 36 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_3"), -1, new string[2] { "ui9_buildingarea_namebase_0_2", "ui9_buildingarea_namebase_1_2" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(4, LocalStringManager.GetConfig("BuildingBlock_language", "Name_4"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_4"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_4"), "SectSpecial/4_gufeng", null, haveDynamicIcon: false, EBuildingBlockType.NormalResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 250, 250, 0, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 1, 1, 0, 0, 0 }, 103, new List<short>(), new List<short> { 27, 54, 117, 193 }, 4, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_4"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_4"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 250 }, 5, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 3, 23, 24, 37 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_4"), -1, new string[2] { "ui9_buildingarea_namebase_0_2", "ui9_buildingarea_namebase_1_2" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(5, LocalStringManager.GetConfig("BuildingBlock_language", "Name_5"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_5"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_5"), "SectSpecial/5_caoyao", null, haveDynamicIcon: false, EBuildingBlockType.NormalResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 0, 0, 0, 500, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 0, 0, 0, 2, 0 }, 104, new List<short>(), new List<short> { 28, 155, 156, 200 }, 8, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_5"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_5"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 250 }, 5, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 4, 25, 38 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_5"), -1, new string[2] { "ui9_buildingarea_namebase_0_2", "ui9_buildingarea_namebase_1_2" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(6, LocalStringManager.GetConfig("BuildingBlock_language", "Name_6"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_6"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_6"), "SectSpecial/6_duzhao", null, haveDynamicIcon: false, EBuildingBlockType.NormalResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 0, 0, 0, 500, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 0, 0, 0, 0, 2 }, 105, new List<short>(), new List<short> { 29, 143, 165, 166 }, 9, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_6"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_6"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 250 }, 5, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 5, 26, 39 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_6"), -1, new string[2] { "ui9_buildingarea_namebase_0_2", "ui9_buildingarea_namebase_1_2" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(7, LocalStringManager.GetConfig("BuildingBlock_language", "Name_7"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_7"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_7"), "SectSpecial/7_huagu", null, haveDynamicIcon: false, EBuildingBlockType.NormalResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 0, 0, 500, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 0, 0, 2, 0, 0 }, 106, new List<short>(), new List<short> { 30, 110, 175, 176, 220 }, 10, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_7"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_7"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 250 }, 5, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 6, 27, 40, 41 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_7"), -1, new string[2] { "ui9_buildingarea_namebase_0_2", "ui9_buildingarea_namebase_1_2" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(8, LocalStringManager.GetConfig("BuildingBlock_language", "Name_8"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_8"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_8"), "SectSpecial/8_baoshi", null, haveDynamicIcon: false, EBuildingBlockType.NormalResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 0, 500, 0, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 0, 2, 0, 0, 0 }, 107, new List<short>(), new List<short> { 31, 96, 173, 185, 186 }, 11, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_8"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_8"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 250 }, 5, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 7, 28, 42 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_8"), -1, new string[2] { "ui9_buildingarea_namebase_0_2", "ui9_buildingarea_namebase_1_2" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(9, LocalStringManager.GetConfig("BuildingBlock_language", "Name_9"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_9"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_9"), "SectSpecial/9_woye", null, haveDynamicIcon: false, EBuildingBlockType.NormalResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 250, 250, 0, 0, 0, 0, 0, 0 }, 100, 50, new sbyte[7] { 1, 1, 0, 0, 0, 0, 0 }, 108, new List<short>(), new List<short> { 32, 127, 128, 209, 210 }, 14, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_9"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_9"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 250 }, 5, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 8, 29, 30, 43 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_9"), -1, new string[2] { "ui9_buildingarea_namebase_0_2", "ui9_buildingarea_namebase_1_2" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(10, LocalStringManager.GetConfig("BuildingBlock_language", "Name_10"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_10"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_10"), "SectSpecial/10_shouqun", null, haveDynamicIcon: false, EBuildingBlockType.NormalResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 250, 0, 0, 0, 250, 0, 0, 0 }, 100, 50, new sbyte[7] { 1, 0, 0, 0, 1, 0, 0 }, 109, new List<short>(), new List<short> { 33, 153, 163, 207 }, 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_10"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_10"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 250 }, 5, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 9, 31, 32, 44 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_10"), -1, new string[2] { "ui9_buildingarea_namebase_0_2", "ui9_buildingarea_namebase_1_2" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(11, LocalStringManager.GetConfig("BuildingBlock_language", "Name_11"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_11"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_11"), "SectSpecial/101_huochi", null, haveDynamicIcon: false, EBuildingBlockType.SpecialResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 1000, 0, 0, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 3, 0, 0, 0, 0 }, 110, new List<short>(), new List<short> { 34, 138, 184 }, 6, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_11"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_11"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 500 }, 10, new List<ResourceInfo>(), 100, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 10, 45 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_11"), -1, new string[2] { "ui9_buildingarea_namebase_0_3", "ui9_buildingarea_namebase_1_3" }, new string[2] { "buildingarea_industry_icon_6", "buildingarea_industry_base_6" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(12, LocalStringManager.GetConfig("BuildingBlock_language", "Name_12"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_12"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_12"), "SectSpecial/102_yuntiekeng", null, haveDynamicIcon: false, EBuildingBlockType.SpecialResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 1000, 0, 0, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 3, 0, 0, 0, 0 }, 111, new List<short>(), new List<short> { 35, 134, 208 }, 6, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_12"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_12"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 500 }, 10, new List<ResourceInfo>(), 100, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 11, 46 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_12"), -1, new string[2] { "ui9_buildingarea_namebase_0_3", "ui9_buildingarea_namebase_1_3" }, new string[2] { "buildingarea_industry_icon_6", "buildingarea_industry_base_6" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(13, LocalStringManager.GetConfig("BuildingBlock_language", "Name_13"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_13"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_13"), "SectSpecial/103_milin", null, haveDynamicIcon: false, EBuildingBlockType.SpecialResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 1000, 0, 0, 0, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 3, 0, 0, 0, 0, 0 }, 112, new List<short>(), new List<short> { 36, 144, 164 }, 7, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_13"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_13"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 500 }, 10, new List<ResourceInfo>(), 100, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 12, 47 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_13"), -1, new string[2] { "ui9_buildingarea_namebase_0_3", "ui9_buildingarea_namebase_1_3" }, new string[2] { "buildingarea_industry_icon_6", "buildingarea_industry_base_6" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(14, LocalStringManager.GetConfig("BuildingBlock_language", "Name_14"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_14"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_14"), "SectSpecial/104_taishilin", null, haveDynamicIcon: false, EBuildingBlockType.SpecialResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 1000, 0, 0, 0, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 3, 0, 0, 0, 0, 0 }, 113, new List<short>(), new List<short> { 37, 148, 201 }, 7, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_14"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_14"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 500 }, 10, new List<ResourceInfo>(), 100, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 13, 48 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_14"), -1, new string[2] { "ui9_buildingarea_namebase_0_3", "ui9_buildingarea_namebase_1_3" }, new string[2] { "buildingarea_industry_icon_6", "buildingarea_industry_base_6" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(15, LocalStringManager.GetConfig("BuildingBlock_language", "Name_15"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_15"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_15"), "SectSpecial/105_changchunjian", null, haveDynamicIcon: false, EBuildingBlockType.SpecialResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 0, 0, 0, 1000, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 0, 0, 0, 3, 0 }, 114, new List<short>(), new List<short> { 38, 90, 126, 158, 221 }, 8, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_15"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_15"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 500 }, 10, new List<ResourceInfo>(), 100, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 14, 49 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_15"), -1, new string[2] { "ui9_buildingarea_namebase_0_3", "ui9_buildingarea_namebase_1_3" }, new string[2] { "buildingarea_industry_icon_6", "buildingarea_industry_base_6" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(16, LocalStringManager.GetConfig("BuildingBlock_language", "Name_16"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_16"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_16"), "SectSpecial/106_xuansheku", null, haveDynamicIcon: false, EBuildingBlockType.SpecialResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 0, 0, 0, 1000, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 0, 0, 0, 0, 3 }, 115, new List<short>(), new List<short> { 39, 168, 174 }, 9, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_16"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_16"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 500 }, 10, new List<ResourceInfo>(), 100, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 15, 50 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_16"), -1, new string[2] { "ui9_buildingarea_namebase_0_3", "ui9_buildingarea_namebase_1_3" }, new string[2] { "buildingarea_industry_icon_6", "buildingarea_industry_base_6" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(17, LocalStringManager.GetConfig("BuildingBlock_language", "Name_17"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_17"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_17"), "SectSpecial/107_qixiangyuan", null, haveDynamicIcon: false, EBuildingBlockType.SpecialResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 0, 0, 1000, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 0, 0, 3, 0, 0 }, 116, new List<short>(), new List<short> { 40, 111, 178 }, 10, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_17"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_17"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 500 }, 10, new List<ResourceInfo>(), 100, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 16, 51 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_17"), -1, new string[2] { "ui9_buildingarea_namebase_0_3", "ui9_buildingarea_namebase_1_3" }, new string[2] { "buildingarea_industry_icon_6", "buildingarea_industry_base_6" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(18, LocalStringManager.GetConfig("BuildingBlock_language", "Name_18"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_18"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_18"), "SectSpecial/108_fengshuilongxue", null, haveDynamicIcon: false, EBuildingBlockType.SpecialResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 0, 0, 1000, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 0, 0, 3, 0, 0 }, 117, new List<short>(), new List<short> { 41, 118, 194 }, 4, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_18"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_18"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 500 }, 10, new List<ResourceInfo>(), 100, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 17, 52 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_18"), -1, new string[2] { "ui9_buildingarea_namebase_0_3", "ui9_buildingarea_namebase_1_3" }, new string[2] { "buildingarea_industry_icon_6", "buildingarea_industry_base_6" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(19, LocalStringManager.GetConfig("BuildingBlock_language", "Name_19"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_19"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_19"), "SectSpecial/109_lingmai", null, haveDynamicIcon: false, EBuildingBlockType.SpecialResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 0, 1000, 0, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 0, 3, 0, 0, 0 }, 118, new List<short>(), new List<short> { 42, 104, 188 }, 11, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_19"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_19"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 500 }, 10, new List<ResourceInfo>(), 100, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 18, 53 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_19"), -1, new string[2] { "ui9_buildingarea_namebase_0_3", "ui9_buildingarea_namebase_1_3" }, new string[2] { "buildingarea_industry_icon_6", "buildingarea_industry_base_6" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(20, LocalStringManager.GetConfig("BuildingBlock_language", "Name_20"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_20"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_20"), "SectSpecial/110_xuanbing", null, haveDynamicIcon: false, EBuildingBlockType.SpecialResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 0, 1000, 0, 0, 0, 0 }, 100, 50, new sbyte[7] { 0, 0, 0, 3, 0, 0, 0 }, 119, new List<short>(), new List<short> { 43, 56, 97, 154, 212 }, 11, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_20"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_20"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 500 }, 10, new List<ResourceInfo>(), 100, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 19, 54 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_20"), -1, new string[2] { "ui9_buildingarea_namebase_0_3", "ui9_buildingarea_namebase_1_3" }, new string[2] { "buildingarea_industry_icon_6", "buildingarea_industry_base_6" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(21, LocalStringManager.GetConfig("BuildingBlock_language", "Name_21"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_21"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_21"), "SectSpecial/20001_zhachaodui", null, haveDynamicIcon: false, EBuildingBlockType.UselessResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 100, 100, 0, 0, 100, 100, 0, 0 }, 100, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_21"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_21"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, 250 }, 10, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_21"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(22, LocalStringManager.GetConfig("BuildingBlock_language", "Name_22"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_22"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_22"), "SectSpecial/20002_luanshidui", null, haveDynamicIcon: false, EBuildingBlockType.UselessResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 200, 200, 0, 0, 0, 0 }, 100, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_22"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_22"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, 250 }, 10, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_22"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(23, LocalStringManager.GetConfig("BuildingBlock_language", "Name_23"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_23"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_23"), "SectSpecial/20003_feixu", null, haveDynamicIcon: false, EBuildingBlockType.UselessResource, EBuildingBlockClass.BornResource, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 0, 0, 0, 0, 1000, 100 }, 100, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_23"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_23"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, 250 }, 10, new List<ResourceInfo>(), 50, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_23"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(24, LocalStringManager.GetConfig("BuildingBlock_language", "Name_24"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_24"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_24"), "SectSpecial/10001_diyan", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 1000, 250, 0, 500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 1 }, new List<short>(), 14, -1, 6, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_24"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_24"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 20)
		}, 100, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1], isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 0 }, new List<short> { 20 }, -1, new List<ShortList>(), -1, new List<short> { 55 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_24"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(25, LocalStringManager.GetConfig("BuildingBlock_language", "Name_25"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_25"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_25"), "SectSpecial/10002_kuangjing", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 1000, 500, 0, 250, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 2 }, new List<short>(), 6, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_25"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_25"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 20)
		}, 100, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 1 }, new List<short> { 21 }, -1, new List<ShortList>(), -1, new List<short> { 56 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_25"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(26, LocalStringManager.GetConfig("BuildingBlock_language", "Name_26"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_26"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_26"), "SectSpecial/10003_shunong", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 500, 250, 0, 1000, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 3 }, new List<short>(), 7, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_26"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_26"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 20)
		}, 100, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 2 }, new List<short> { 22 }, -1, new List<ShortList>(), -1, new List<short> { 57 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_26"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(27, LocalStringManager.GetConfig("BuildingBlock_language", "Name_27"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_27"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_27"), "SectSpecial/10004_shibei", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 250, 1000, 500, 0, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 4 }, new List<short>(), 4, -1, 5, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_27"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_27"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 20)
		}, 100, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 6 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 3 }, new List<short> { 23 }, -1, new List<ShortList>(), -1, new List<short> { 58 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_27"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(28, LocalStringManager.GetConfig("BuildingBlock_language", "Name_28"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_28"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_28"), "SectSpecial/10005_yaonong", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 500, 0, 0, 1000, 250, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 5 }, new List<short>(), 8, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_28"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_28"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 20)
		}, 100, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 4 }, new List<short> { 24 }, -1, new List<ShortList>(), -1, new List<short> { 59 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_28"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(29, LocalStringManager.GetConfig("BuildingBlock_language", "Name_29"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_29"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_29"), "SectSpecial/10006_niqu", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 500, 1000, 0, 0, 0, 250, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 6 }, new List<short>(), 9, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_29"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_29"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 20)
		}, 100, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 5 }, new List<short> { 25 }, -1, new List<ShortList>(), -1, new List<short> { 60 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_29"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(30, LocalStringManager.GetConfig("BuildingBlock_language", "Name_30"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_30"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_30"), "SectSpecial/10007_huanong", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 1000, 0, 500, 250, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 7 }, new List<short>(), 10, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_30"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_30"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 20)
		}, 100, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 6 }, new List<short> { 26 }, -1, new List<ShortList>(), -1, new List<short> { 61 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_30"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(31, LocalStringManager.GetConfig("BuildingBlock_language", "Name_31"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_31"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_31"), "SectSpecial/10008_baojing", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 500, 1000, 250, 0, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 8 }, new List<short>(), 11, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_31"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_31"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 20)
		}, 100, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 7 }, new List<short> { 27 }, -1, new List<ShortList>(), -1, new List<short> { 62 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_31"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(32, LocalStringManager.GetConfig("BuildingBlock_language", "Name_32"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_32"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_32"), "SectSpecial/10009_tongche", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 1000, 250, 0, 500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 9 }, new List<short>(), 14, -1, 6, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_32"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_32"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 20)
		}, 100, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1], isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 8 }, new List<short> { 28 }, -1, new List<ShortList>(), -1, new List<short> { 63 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_32"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(33, LocalStringManager.GetConfig("BuildingBlock_language", "Name_33"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_33"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_33"), "SectSpecial/10010_muchang", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 1000, 250, 0, 0, 500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 10 }, new List<short>(), 14, -1, 2, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_33"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_33"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 20)
		}, 100, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1], isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 9 }, new List<short> { 29 }, -1, new List<ShortList>(), -1, new List<short> { 64 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_33"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(34, LocalStringManager.GetConfig("BuildingBlock_language", "Name_34"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_34"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_34"), "SectSpecial/11001_liulisuo", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 2500, 7500, 5000, 0, 0, 0, 1000 }, 50, 50, new sbyte[7], 120, new List<short> { 11 }, new List<short>(), 6, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_34"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_34"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 10 }, new List<short> { 30 }, -1, new List<ShortList>(), -1, new List<short> { 65 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_34"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(35, LocalStringManager.GetConfig("BuildingBlock_language", "Name_35"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_35"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_35"), "SectSpecial/11002_huobaodui", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 7500, 0, 0, 2500, 5000, 0, 1000 }, 50, 50, new sbyte[7], 121, new List<short> { 12 }, new List<short>(), 6, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_35"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_35"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 11 }, new List<short> { 31 }, -1, new List<ShortList>(), -1, new List<short> { 66 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_35"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(36, LocalStringManager.GetConfig("BuildingBlock_language", "Name_36"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_36"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_36"), "SectSpecial/11003_hulinqiang", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 7500, 2500, 0, 5000, 0, 0, 1000 }, 50, 50, new sbyte[7], 122, new List<short> { 13 }, new List<short>(), 7, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_36"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_36"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 12 }, new List<short> { 32 }, -1, new List<ShortList>(), -1, new List<short> { 67 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_36"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(37, LocalStringManager.GetConfig("BuildingBlock_language", "Name_37"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_37"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_37"), "SectSpecial/11004_xuankongzhan", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 5000, 2500, 0, 7500, 0, 0, 1000 }, 50, 50, new sbyte[7], 123, new List<short> { 14 }, new List<short>(), 7, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_37"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_37"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 13 }, new List<short> { 33 }, -1, new List<ShortList>(), -1, new List<short> { 68 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_37"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(38, LocalStringManager.GetConfig("BuildingBlock_language", "Name_38"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_38"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_38"), "SectSpecial/11005_yinjianqu", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 7500, 0, 5000, 2500, 0, 0, 1000 }, 50, 50, new sbyte[7], 124, new List<short> { 15 }, new List<short>(), 8, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_38"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_38"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 14 }, new List<short> { 34 }, -1, new List<ShortList>(), -1, new List<short> { 69 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_38"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(39, LocalStringManager.GetConfig("BuildingBlock_language", "Name_39"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_39"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_39"), "SectSpecial/11006_ershilao", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 7500, 0, 5000, 0, 0, 2500, 0, 1000 }, 50, 50, new sbyte[7], 125, new List<short> { 16 }, new List<short>(), 9, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_39"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_39"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 15 }, new List<short> { 35 }, -1, new List<ShortList>(), -1, new List<short> { 70 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_39"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(40, LocalStringManager.GetConfig("BuildingBlock_language", "Name_40"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_40"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_40"), "SectSpecial/11007_yunpeng", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 5000, 2500, 0, 7500, 0, 0, 1000 }, 50, 50, new sbyte[7], 126, new List<short> { 17 }, new List<short>(), 10, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_40"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_40"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 16 }, new List<short> { 36 }, -1, new List<ShortList>(), -1, new List<short> { 71 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_40"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(41, LocalStringManager.GetConfig("BuildingBlock_language", "Name_41"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_41"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_41"), "SectSpecial/11008_furenju", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 5000, 0, 0, 7500, 2500, 0, 0, 1000 }, 50, 50, new sbyte[7], 127, new List<short> { 18 }, new List<short>(), 4, -1, 5, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_41"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_41"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 6 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 17 }, new List<short> { 37 }, -1, new List<ShortList>(), -1, new List<short> { 72 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_41"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(42, LocalStringManager.GetConfig("BuildingBlock_language", "Name_42"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_42"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_42"), "SectSpecial/11009_miling", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 2500, 0, 7500, 0, 5000, 0, 1000 }, 50, 50, new sbyte[7], 128, new List<short> { 19 }, new List<short>(), 11, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_42"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_42"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 18 }, new List<short> { 38 }, -1, new List<ShortList>(), -1, new List<short> { 73 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_42"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(43, LocalStringManager.GetConfig("BuildingBlock_language", "Name_43"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_43"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_43"), "SectSpecial/11010_bingyixiang", "Func_ResourceUp", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Resource, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 0, 7500, 5000, 2500, 0, 0, 1000 }, 50, 50, new sbyte[7], 129, new List<short> { 20 }, new List<short>(), 11, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_43"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_43"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: true, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 800, 0, 0, new List<short> { 19 }, new List<short> { 39 }, -1, new List<ShortList>(), -1, new List<short> { 74 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_43"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(44, LocalStringManager.GetConfig("BuildingBlock_language", "Name_44"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_44"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_44"), "Main/1001_taiwucun", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 15, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 50, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_44"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_44"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, 20, new List<ResourceInfo>(), 1000, mustMaintenance: true, isUnique: true, 1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 107, 108, 109 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_44"), -1, new string[2] { "ui9_buildingarea_namebase_0_0", "ui9_buildingarea_namebase_1_0" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(45, LocalStringManager.GetConfig("BuildingBlock_language", "Name_45"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_45"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_45"), "SectSpecial/1005_taiwushicitang", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Villiage, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 0, 500, 500, 500, 500, 0, 0, 500 }, 50, 50, new sbyte[7], 225, new List<short>(), new List<short>(), 4, -1, 5, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_45"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_45"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, -1 }, 20, new List<ResourceInfo>(), 500, mustMaintenance: true, isUnique: true, 1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 6 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 111 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_45"), -1, new string[2] { "ui9_buildingarea_namebase_0_0", "ui9_buildingarea_namebase_1_0" }, new string[2] { "buildingarea_industry_icon_0", "buildingarea_industry_base_0" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(46, LocalStringManager.GetConfig("BuildingBlock_language", "Name_46"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_46"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_46"), "SectSpecial/1002_jusuo", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Villiage, 9, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 500, 500, 500, 500, 500, 500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_46"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_46"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 250, 250 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(0, 10)
		}, 100, mustMaintenance: true, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 113 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_46"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(47, LocalStringManager.GetConfig("BuildingBlock_language", "Name_47"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_47"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_47"), "SectSpecial/1003_xiangfang", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Villiage, 3, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 2500, 2500, 2500, 2500, 2500, 2500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_47"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_47"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: true, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 114 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_47"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(48, LocalStringManager.GetConfig("BuildingBlock_language", "Name_48"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_48"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_48"), "SectSpecial/1004_cangku", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Villiage, 9, canOpenManageOutTaiwu: true, 1, null, new ushort[8] { 0, 1500, 1500, 0, 0, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_48"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_48"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 250, 250 }, 10, new List<ResourceInfo>(), 100, mustMaintenance: true, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 112 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_48"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(49, LocalStringManager.GetConfig("BuildingBlock_language", "Name_49"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_49"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_49"), "SectSpecial/1007_yuanjishe", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Villiage, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8] { 500, 500, 500, 500, 500, 500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_49"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_49"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>(), 500, mustMaintenance: false, isUnique: false, 1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 110 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_49"), -1, new string[2] { "ui9_buildingarea_namebase_0_0", "ui9_buildingarea_namebase_1_0" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(50, LocalStringManager.GetConfig("BuildingBlock_language", "Name_50"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_50"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_50"), "SectSpecial/2507_lunhuitai", "Func_Special", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Villiage, 6, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 1500, 1500, 1500, 1500, 1500, 1500, 0, 500 }, 50, 50, new sbyte[7], 227, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_50"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_50"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, -1 }, 20, new List<ResourceInfo>(), 1000, mustMaintenance: false, isUnique: true, 1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 115 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_50"), -1, new string[2] { "ui9_buildingarea_namebase_0_0", "ui9_buildingarea_namebase_1_0" }, new string[2] { "buildingarea_industry_icon_0", "buildingarea_industry_base_0" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(51, LocalStringManager.GetConfig("BuildingBlock_language", "Name_51"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_51"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_51"), "SectSpecial/2610_chamabang", "Func_Special", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Villiage, 20, canOpenManageOutTaiwu: false, 1, null, new ushort[8] { 2500, 2500, 2500, 2500, 2500, 2500, 10000, 1500 }, 50, 50, new sbyte[7], 226, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_51"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_51"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, -1 }, 20, new List<ResourceInfo>(), 2500, mustMaintenance: false, isUnique: true, 1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 116 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_51"), -1, new string[2] { "ui9_buildingarea_namebase_0_0", "ui9_buildingarea_namebase_1_0" }, new string[2] { "buildingarea_industry_icon_0", "buildingarea_industry_base_0" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(52, LocalStringManager.GetConfig("BuildingBlock_language", "Name_52"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_52"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_52"), "SectSpecial/1008_liangongfang", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8] { 0, 500, 1000, 0, 500, 1000, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short>
		{
			53, 54, 55, 56, 57, 58, 59, 60, 61, 62,
			63, 64, 65, 66, 67, 68, 69, 70, 71, 72,
			73, 74, 75, 76, 77, 78, 79, 80, 81, 82,
			83, 84
		}, 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_52"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_52"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 250, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_52"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(53, LocalStringManager.GetConfig("BuildingBlock_language", "Name_53"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_53"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_53"), "SectSpecial/2030_biaoju", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 1500, 0, 2000, 0, 0, 1500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), 4, -1, 5, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_53"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_53"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 6 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, -50, new List<short> { 40 }, new List<short> { 43 }, -1, new List<ShortList>(), -1, new List<short> { 76 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_53"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(54, LocalStringManager.GetConfig("BuildingBlock_language", "Name_54"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_54"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_54"), "SectSpecial/2032_lianshenfeng", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 5000, 5000, 0, 0, 5000, 0, 2500 }, 50, 50, new sbyte[7], 144, new List<short> { 52, 4 }, new List<short>(), 4, -1, 5, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_54"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_54"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 6 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 41 }, new List<short> { 44 }, -1, new List<ShortList>(), -1, new List<short> { 75 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_54"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(55, LocalStringManager.GetConfig("BuildingBlock_language", "Name_55"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_55"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_55"), "SectSpecial/2031_hziketing", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 2500, 1500, 0, 1500, 2500, 0, 0, 1000 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), 4, -1, 5, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_55"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_55"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 6 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 0, -50, new List<short> { 42 }, new List<short> { 45 }, -1, new List<ShortList>(), -1, new List<short> { 77 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_55"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(56, LocalStringManager.GetConfig("BuildingBlock_language", "Name_56"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_56"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_56"), "SectSpecial/2033_xuanbingbi", "Func_Special", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 5000, 10000, 20000, 5000, 0, 0, 15000 }, 50, 50, new sbyte[7], 145, new List<short> { 52, 20 }, new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_56"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_56"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 1000)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 78 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_56"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(57, LocalStringManager.GetConfig("BuildingBlock_language", "Name_57"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_57"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_57"), "SectSpecial/2002_jingshi", "Func_CombatSkill0", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 2500, 0, 2500, 0, 5000, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 0, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_57"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_57"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			9, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 0, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 79 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_57"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(58, LocalStringManager.GetConfig("BuildingBlock_language", "Name_58"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_58"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_58"), "SectSpecial/2003_zhuanglin", "Func_CombatSkill1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 5000, 2500, 0, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 1, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_58"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_58"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, 9, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 80 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_58"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(59, LocalStringManager.GetConfig("BuildingBlock_language", "Name_59"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_59"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_59"), "SectSpecial/2004_juezhitang", "Func_CombatSkill2", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 0, 0, 2500, 2500, 5000, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 2, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_59"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_59"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, 9, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 2, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 81 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_59"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new BuildingBlockItem(60, LocalStringManager.GetConfig("BuildingBlock_language", "Name_60"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_60"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_60"), "SectSpecial/2005_murenzhen", "Func_CombatSkill3", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 5000, 2500, 0, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 3, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_60"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_60"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, 9, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 3, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 82 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_60"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(61, LocalStringManager.GetConfig("BuildingBlock_language", "Name_61"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_61"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_61"), "SectSpecial/2006_tongrenzhen", "Func_CombatSkill4", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 2500, 5000, 0, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 4, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_61"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_61"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, 9, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 4, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 83 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_61"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(62, LocalStringManager.GetConfig("BuildingBlock_language", "Name_62"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_62"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_62"), "SectSpecial/2007_heinitan", "Func_CombatSkill5", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 5000, 2500, 0, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 5, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_62"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_62"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, 9, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 5, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 84 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_62"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(63, LocalStringManager.GetConfig("BuildingBlock_language", "Name_63"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_63"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_63"), "SectSpecial/2008_bachang", "Func_CombatSkill6", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 2500, 5000, 0, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 6, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_63"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_63"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, 9, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 6, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 85 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_63"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(64, LocalStringManager.GetConfig("BuildingBlock_language", "Name_64"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_64"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_64"), "SectSpecial/2009_shijiantai", "Func_CombatSkill7", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 2500, 0, 5000, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 7, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_64"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_64"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, 9, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 7, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 86 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_64"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(65, LocalStringManager.GetConfig("BuildingBlock_language", "Name_65"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_65"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_65"), "SectSpecial/2010_shendaotang", "Func_CombatSkill8", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 2500, 5000, 2500, 0, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 8, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_65"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_65"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, 9, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 8, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 87 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_65"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(66, LocalStringManager.GetConfig("BuildingBlock_language", "Name_66"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_66"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_66"), "SectSpecial/2011_yanwuchang", "Func_CombatSkill9", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 2500, 5000, 0, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 9, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_66"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_66"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, 9,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 9, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 88 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_66"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(67, LocalStringManager.GetConfig("BuildingBlock_language", "Name_67"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_67"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_67"), "SectSpecial/2012_yirenguan", "Func_CombatSkill10", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 5000, 0, 2500, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 10, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_67"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_67"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			9, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 10, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 89 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_67"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(68, LocalStringManager.GetConfig("BuildingBlock_language", "Name_68"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_68"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_68"), "SectSpecial/2013_fengshi", "Func_CombatSkill11", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 2500, 0, 2500, 5000, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 11, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_68"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_68"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, 9, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 11, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 90 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_68"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(69, LocalStringManager.GetConfig("BuildingBlock_language", "Name_69"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_69"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_69"), "SectSpecial/2014_tianjige", "Func_CombatSkill12", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 0, 2500, 5000, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 12, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_69"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_69"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, 9, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 12, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 91 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_69"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(70, LocalStringManager.GetConfig("BuildingBlock_language", "Name_70"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_70"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_70"), "SectSpecial/2015_konggu", "Func_CombatSkill13", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 0, 0, 2500, 5000, 2500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 52 }, new List<short>(), -1, 13, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_70"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_70"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, 9
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 1000, mustMaintenance: false, isUnique: true, 0, -1, 13, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 92 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_70"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(71, LocalStringManager.GetConfig("BuildingBlock_language", "Name_71"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_71"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_71"), "SectSpecial/2016_geshita", "Func_CombatSkill0", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 5000, 0, 10000, 0, 15000, 0, 0 }, 50, 50, new sbyte[7], 130, new List<short> { 52 }, new List<short>(), -1, 0, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_71"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_71"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			12, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 0, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 93 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_71"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(72, LocalStringManager.GetConfig("BuildingBlock_language", "Name_72"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_72"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_72"), "SectSpecial/2017_lingyunjie", "Func_CombatSkill1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 15000, 10000, 0, 5000, 0, 0, 0 }, 50, 50, new sbyte[7], 131, new List<short> { 52 }, new List<short>(), -1, 1, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_72"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_72"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, 12, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 94 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_72"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(73, LocalStringManager.GetConfig("BuildingBlock_language", "Name_73"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_73"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_73"), "SectSpecial/2018_mishi", "Func_CombatSkill2", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 0, 0, 5000, 10000, 15000, 0, 0 }, 50, 50, new sbyte[7], 132, new List<short> { 52 }, new List<short>(), -1, 2, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_73"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_73"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, 12, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 2, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 95 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_73"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(74, LocalStringManager.GetConfig("BuildingBlock_language", "Name_74"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_74"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_74"), "SectSpecial/2019_bohulao", "Func_CombatSkill3", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 15000, 10000, 0, 5000, 0, 0, 0 }, 50, 50, new sbyte[7], 133, new List<short> { 52 }, new List<short>(), -1, 3, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_74"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_74"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, 12, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 3, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 96 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_74"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(75, LocalStringManager.GetConfig("BuildingBlock_language", "Name_75"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_75"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_75"), "SectSpecial/2020_miantieerbi", "Func_CombatSkill4", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 5000, 15000, 0, 10000, 0, 0, 0 }, 50, 50, new sbyte[7], 134, new List<short> { 52 }, new List<short>(), -1, 4, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_75"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_75"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, 12, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 4, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 97 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_75"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(76, LocalStringManager.GetConfig("BuildingBlock_language", "Name_76"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_76"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_76"), "SectSpecial/2021_daoqiongdou", "Func_CombatSkill5", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 15000, 5000, 0, 10000, 0, 0, 0 }, 50, 50, new sbyte[7], 135, new List<short> { 52 }, new List<short>(), -1, 5, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_76"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_76"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, 12, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 5, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 98 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_76"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(77, LocalStringManager.GetConfig("BuildingBlock_language", "Name_77"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_77"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_77"), "SectSpecial/2022_anshi", "Func_CombatSkill6", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 10000, 15000, 0, 5000, 0, 0, 0 }, 50, 50, new sbyte[7], 136, new List<short> { 52 }, new List<short>(), -1, 6, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_77"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_77"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, 12, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 6, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 99 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_77"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(78, LocalStringManager.GetConfig("BuildingBlock_language", "Name_78"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_78"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_78"), "SectSpecial/2023_jianzhong", "Func_CombatSkill7", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 10000, 0, 15000, 5000, 0, 0, 0 }, 50, 50, new sbyte[7], 137, new List<short> { 52 }, new List<short>(), -1, 7, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_78"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_78"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, 12, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 7, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 100 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_78"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(79, LocalStringManager.GetConfig("BuildingBlock_language", "Name_79"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_79"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_79"), "SectSpecial/2024_xiuluochang", "Func_CombatSkill8", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 10000, 15000, 5000, 0, 0, 0, 0 }, 50, 50, new sbyte[7], 138, new List<short> { 52 }, new List<short>(), -1, 8, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_79"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_79"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, 12, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 8, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 101 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_79"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(80, LocalStringManager.GetConfig("BuildingBlock_language", "Name_80"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_80"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_80"), "SectSpecial/2025_tiejuzhen", "Func_CombatSkill9", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 10000, 15000, 0, 5000, 0, 0, 0 }, 50, 50, new sbyte[7], 139, new List<short> { 52 }, new List<short>(), -1, 9, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_80"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_80"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, 12,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 9, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 102 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_80"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(81, LocalStringManager.GetConfig("BuildingBlock_language", "Name_81"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_81"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_81"), "SectSpecial/2026_bazhentu", "Func_CombatSkill10", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 15000, 0, 10000, 5000, 0, 0, 0 }, 50, 50, new sbyte[7], 140, new List<short> { 52 }, new List<short>(), -1, 10, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_81"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_81"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			12, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 10, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 103 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_81"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(82, LocalStringManager.GetConfig("BuildingBlock_language", "Name_82"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_82"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_82"), "SectSpecial/2027_qiansixiang", "Func_CombatSkill11", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 10000, 0, 5000, 15000, 0, 0, 0 }, 50, 50, new sbyte[7], 141, new List<short> { 52 }, new List<short>(), -1, 11, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_82"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_82"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, 12, -1, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 11, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 104 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_82"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(83, LocalStringManager.GetConfig("BuildingBlock_language", "Name_83"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_83"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_83"), "SectSpecial/2028_zhuiyingdong", "Func_CombatSkill12", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 0, 5000, 15000, 10000, 0, 0, 0 }, 50, 50, new sbyte[7], 142, new List<short> { 52 }, new List<short>(), -1, 12, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_83"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_83"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, 12, -1
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 12, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 105 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_83"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(84, LocalStringManager.GetConfig("BuildingBlock_language", "Name_84"), EBuildingBlockFuncType.Breakout, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_84"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_84"), "SectSpecial/2029_qixianlou", "Func_CombatSkill13", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Kungfu, 1, canOpenManageOutTaiwu: false, 1, "473a32", new ushort[8] { 0, 0, 0, 10000, 15000, 5000, 0, 0 }, 50, 50, new sbyte[7], 143, new List<short> { 52 }, new List<short>(), -1, 13, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_84"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_84"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, 12
		}, new short[2] { 1500, 1500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, 13, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 106 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_84"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(85, LocalStringManager.GetConfig("BuildingBlock_language", "Name_85"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_85"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_85"), "SectSpecial/1009_qinshe", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Music, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8] { 0, 500, 0, 500, 1500, 0, 2500, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 86, 87, 88, 89, 90, 91 }, 0, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_85"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_85"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 250, mustMaintenance: false, isUnique: false, 0, 0, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 117 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_85"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(86, LocalStringManager.GetConfig("BuildingBlock_language", "Name_86"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_86"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_86"), "SectSpecial/2102_yuefang", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Music, 1, canOpenManageOutTaiwu: false, 1, "406056", new ushort[8] { 0, 1250, 0, 1250, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 85 }, new List<short>(), 0, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_86"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_86"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 50, 0, new List<short> { 46 }, new List<short> { 49 }, -1, new List<ShortList>(), -1, new List<short> { 143 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_86"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(87, LocalStringManager.GetConfig("BuildingBlock_language", "Name_87"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_87"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_87"), "SectSpecial/2103_zhiyinge", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Music, 1, canOpenManageOutTaiwu: false, 1, "406056", new ushort[8] { 0, 2500, 0, 2500, 5000, 0, 0, 2500 }, 50, 50, new sbyte[7], 146, new List<short> { 85 }, new List<short>(), 0, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_87"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_87"), new short[16]
		{
			12, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 47 }, new List<short> { 50 }, -1, new List<ShortList>(), -1, new List<short> { 168 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_87"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(88, LocalStringManager.GetConfig("BuildingBlock_language", "Name_88"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_88"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_88"), "SectSpecial/2104_baixiyuan", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Music, 1, canOpenManageOutTaiwu: false, 1, "406056", new ushort[8] { 0, 2000, 0, 2000, 5000, 0, 5000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 85 }, new List<short>(), 0, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_88"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_88"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 50, 0, new List<short> { 48 }, new List<short> { 51 }, -1, new List<ShortList>(), -1, new List<short> { 152 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_88"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(89, LocalStringManager.GetConfig("BuildingBlock_language", "Name_89"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_89"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_89"), "SectSpecial/2105_yiqingju", "Func_LiveSkill0", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Music, 1, canOpenManageOutTaiwu: false, 1, "406056", new ushort[8] { 0, 1500, 0, 1500, 5000, 0, 0, 1000 }, 50, 50, new sbyte[7], 147, new List<short> { 85, 1 }, new List<short>(), 0, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_89"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_89"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 0, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 186 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_89"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(90, LocalStringManager.GetConfig("BuildingBlock_language", "Name_90"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_90"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_90"), "SectSpecial/2106_xianjing", "Func_LiveSkill0", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Music, 1, canOpenManageOutTaiwu: false, 1, "406056", new ushort[8] { 0, 2500, 0, 2500, 15000, 0, 0, 5000 }, 50, 50, new sbyte[7], 148, new List<short> { 85, 15 }, new List<short>(), 0, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_90"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_90"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 0, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 202 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_90"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(91, LocalStringManager.GetConfig("BuildingBlock_language", "Name_91"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_91"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_91"), "SectSpecial/2107_fenghuangtai", "Func_Special", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Music, 1, canOpenManageOutTaiwu: false, 1, "406056", new ushort[8] { 0, 7500, 0, 7500, 15000, 0, 0, 15000 }, 50, 50, new sbyte[7], 149, new List<short> { 85 }, new List<short>(), 0, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_91"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_91"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 1000)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 225 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_91"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(92, LocalStringManager.GetConfig("BuildingBlock_language", "Name_92"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_92"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_92"), "SectSpecial/1010_yixuan", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Chess, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8] { 0, 500, 0, 1500, 500, 0, 2500, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 93, 94, 95, 96, 97, 98 }, 1, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_92"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_92"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 250, mustMaintenance: false, isUnique: false, 0, 1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 118 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_92"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(93, LocalStringManager.GetConfig("BuildingBlock_language", "Name_93"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_93"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_93"), "SectSpecial/2202_qiguan", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Chess, 1, canOpenManageOutTaiwu: false, 1, "414141", new ushort[8] { 0, 1250, 0, 2500, 1250, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 92 }, new List<short>(), 1, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_93"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_93"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 50, 0, new List<short> { 52 }, new List<short> { 55 }, -1, new List<ShortList>(), -1, new List<short> { 144 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_93"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(94, LocalStringManager.GetConfig("BuildingBlock_language", "Name_94"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_94"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_94"), "SectSpecial/2203_douyitai", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Chess, 1, canOpenManageOutTaiwu: false, 1, "414141", new ushort[8] { 0, 2500, 0, 5000, 2500, 0, 0, 2500 }, 50, 50, new sbyte[7], 150, new List<short> { 92 }, new List<short>(), 1, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_94"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_94"), new short[16]
		{
			-1, 12, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 53 }, new List<short> { 56 }, -1, new List<ShortList>(), -1, new List<short> { 169 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_94"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(95, LocalStringManager.GetConfig("BuildingBlock_language", "Name_95"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_95"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_95"), "SectSpecial/2204_shipuyuan", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Chess, 1, canOpenManageOutTaiwu: false, 1, "414141", new ushort[8] { 0, 2000, 0, 5000, 2000, 0, 5000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 92 }, new List<short>(), 1, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_95"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_95"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 50, 0, new List<short> { 54 }, new List<short> { 57 }, -1, new List<ShortList>(), -1, new List<short> { 153 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_95"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(96, LocalStringManager.GetConfig("BuildingBlock_language", "Name_96"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_96"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_96"), "SectSpecial/2205_liuliguan", "Func_LiveSkill1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Chess, 1, canOpenManageOutTaiwu: false, 1, "414141", new ushort[8] { 0, 1500, 0, 5000, 1500, 0, 0, 1000 }, 50, 50, new sbyte[7], 151, new List<short> { 92, 8 }, new List<short>(), 1, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_96"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_96"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 187 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_96"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(97, LocalStringManager.GetConfig("BuildingBlock_language", "Name_97"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_97"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_97"), "SectSpecial/2206_jingzhongtai", "Func_LiveSkill1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Chess, 1, canOpenManageOutTaiwu: false, 1, "414141", new ushort[8] { 0, 5000, 0, 10000, 5000, 0, 0, 5000 }, 50, 50, new sbyte[7], 152, new List<short> { 92, 20 }, new List<short>(), 1, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_97"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_97"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 203 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_97"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(98, LocalStringManager.GetConfig("BuildingBlock_language", "Name_98"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_98"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_98"), "SectSpecial/2207_fanglveshi", "Func_Special", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Chess, 1, canOpenManageOutTaiwu: false, 1, "414141", new ushort[8] { 5000, 5000, 0, 15000, 5000, 0, 0, 15000 }, 50, 50, new sbyte[7], 153, new List<short> { 92 }, new List<short>(), 1, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_98"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_98"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 1000)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 226 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_98"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(99, LocalStringManager.GetConfig("BuildingBlock_language", "Name_99"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_99"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_99"), "SectSpecial/1011_shufang", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Poem, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8] { 0, 1500, 0, 500, 1000, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 100, 101, 102, 103, 104, 105 }, 2, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_99"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_99"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 250, mustMaintenance: false, isUnique: false, 0, 2, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 119 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_99"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(100, LocalStringManager.GetConfig("BuildingBlock_language", "Name_100"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_100"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_100"), "SectSpecial/2302_shupu", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Poem, 1, canOpenManageOutTaiwu: false, 1, "394a5d", new ushort[8] { 0, 2500, 0, 1000, 1500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 99 }, new List<short>(), 2, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_100"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_100"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 50, 0, new List<short> { 58 }, new List<short> { 61 }, -1, new List<ShortList>(), -1, new List<short> { 145 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_100"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(101, LocalStringManager.GetConfig("BuildingBlock_language", "Name_101"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_101"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_101"), "SectSpecial/2303_shuyuan", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Poem, 1, canOpenManageOutTaiwu: false, 1, "394a5d", new ushort[8] { 0, 5000, 0, 1500, 3500, 0, 0, 2500 }, 50, 50, new sbyte[7], 154, new List<short> { 99 }, new List<short>(), 2, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_101"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_101"), new short[16]
		{
			-1, -1, 12, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 59 }, new List<short> { 62 }, -1, new List<ShortList>(), -1, new List<short> { 170 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_101"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(102, LocalStringManager.GetConfig("BuildingBlock_language", "Name_102"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_102"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_102"), "SectSpecial/2304_hanyuan", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Poem, 1, canOpenManageOutTaiwu: false, 1, "394a5d", new ushort[8] { 0, 5000, 0, 1500, 2500, 0, 5000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 99 }, new List<short>(), 2, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_102"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_102"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 50, 0, new List<short> { 60 }, new List<short> { 63 }, -1, new List<ShortList>(), -1, new List<short> { 154 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_102"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(103, LocalStringManager.GetConfig("BuildingBlock_language", "Name_103"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_103"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_103"), "SectSpecial/2305_longguishan", "Func_LiveSkill2", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Poem, 1, canOpenManageOutTaiwu: false, 1, "394a5d", new ushort[8] { 0, 5000, 0, 1000, 2000, 0, 0, 1000 }, 50, 50, new sbyte[7], 155, new List<short> { 99, 2 }, new List<short>(), 2, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_103"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_103"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 2, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 188 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_103"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(104, LocalStringManager.GetConfig("BuildingBlock_language", "Name_104"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_104"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_104"), "SectSpecial/2306_zhaoyelou", "Func_LiveSkill2", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Poem, 1, canOpenManageOutTaiwu: false, 1, "394a5d", new ushort[8] { 0, 10000, 0, 2500, 7500, 0, 0, 5000 }, 50, 50, new sbyte[7], 156, new List<short> { 99, 19 }, new List<short>(), 2, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_104"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_104"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 2, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 204 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_104"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(105, LocalStringManager.GetConfig("BuildingBlock_language", "Name_105"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_105"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_105"), "SectSpecial/2307_cangshuge", "Func_Special", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Poem, 1, canOpenManageOutTaiwu: false, 1, "394a5d", new ushort[8] { 0, 15000, 2500, 5000, 7500, 0, 0, 15000 }, 50, 50, new sbyte[7], 157, new List<short> { 99 }, new List<short>(), 2, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_105"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_105"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 1000)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_105"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(106, LocalStringManager.GetConfig("BuildingBlock_language", "Name_106"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_106"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_106"), "SectSpecial/1012_huage", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Painting, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8] { 0, 500, 0, 1000, 1500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 107, 108, 109, 110, 111, 112 }, 3, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_106"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_106"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 250, mustMaintenance: false, isUnique: false, 0, 3, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 120 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_106"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(107, LocalStringManager.GetConfig("BuildingBlock_language", "Name_107"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_107"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_107"), "SectSpecial/2402_huapu", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Painting, 1, canOpenManageOutTaiwu: false, 1, "a25968", new ushort[8] { 0, 1000, 0, 1500, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 106 }, new List<short>(), 3, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_107"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_107"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 50, 0, new List<short> { 64 }, new List<short> { 67 }, -1, new List<ShortList>(), -1, new List<short> { 146 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_107"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(108, LocalStringManager.GetConfig("BuildingBlock_language", "Name_108"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_108"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_108"), "SectSpecial/2403_danqingguan", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Painting, 1, canOpenManageOutTaiwu: false, 1, "a25968", new ushort[8] { 0, 2500, 0, 2500, 5000, 0, 0, 2500 }, 50, 50, new sbyte[7], 158, new List<short> { 106 }, new List<short>(), 3, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_108"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_108"), new short[16]
		{
			-1, -1, -1, 12, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 65 }, new List<short> { 68 }, -1, new List<ShortList>(), -1, new List<short> { 171 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_108"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(109, LocalStringManager.GetConfig("BuildingBlock_language", "Name_109"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_109"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_109"), "SectSpecial/2404_liuguangyuan", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Painting, 1, canOpenManageOutTaiwu: false, 1, "a25968", new ushort[8] { 0, 1000, 0, 2000, 5000, 0, 10000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 106 }, new List<short>(), 3, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_109"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_109"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 50, 0, new List<short> { 66 }, new List<short> { 69 }, -1, new List<ShortList>(), -1, new List<short> { 155 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_109"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(110, LocalStringManager.GetConfig("BuildingBlock_language", "Name_110"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_110"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_110"), "SectSpecial/2405_wuseku", "Func_LiveSkill3", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Painting, 1, canOpenManageOutTaiwu: false, 1, "a25968", new ushort[8] { 0, 1000, 0, 2000, 5000, 0, 0, 1000 }, 50, 50, new sbyte[7], 159, new List<short> { 106, 7 }, new List<short>(), 3, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_110"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_110"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 3, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 189 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_110"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(111, LocalStringManager.GetConfig("BuildingBlock_language", "Name_111"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_111"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_111"), "SectSpecial/2406_tianxiangcaige", "Func_LiveSkill3", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Painting, 1, canOpenManageOutTaiwu: false, 1, "a25968", new ushort[8] { 0, 2000, 0, 5000, 10000, 0, 15000, 5000 }, 50, 50, new sbyte[7], 160, new List<short> { 106, 17 }, new List<short>(), 3, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_111"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_111"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 3, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 205 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_111"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(112, LocalStringManager.GetConfig("BuildingBlock_language", "Name_112"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_112"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_112"), "SectSpecial/2407_huayingxuan", "Func_Special", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Painting, 1, canOpenManageOutTaiwu: false, 1, "a25968", new ushort[8] { 0, 2500, 0, 7500, 15000, 5000, 0, 15000 }, 50, 50, new sbyte[7], 161, new List<short> { 106 }, new List<short>(), 3, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_112"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_112"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 1000)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 227 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_112"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(113, LocalStringManager.GetConfig("BuildingBlock_language", "Name_113"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_113"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_113"), "SectSpecial/1013_guanxingtai", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Math, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8] { 0, 1000, 0, 1500, 500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 114, 115, 116, 117, 118, 119 }, 4, -1, 5, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_113"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_113"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 250, mustMaintenance: false, isUnique: false, 0, 4, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 6 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 121 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_113"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(114, LocalStringManager.GetConfig("BuildingBlock_language", "Name_114"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_114"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_114"), "SectSpecial/2502_zhanbuguan", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Math, 1, canOpenManageOutTaiwu: false, 1, "423d59", new ushort[8] { 0, 1500, 0, 2500, 1000, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 113 }, new List<short>(), 4, -1, 5, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_114"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_114"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 6 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, -50, 0, new List<short> { 70 }, new List<short> { 73 }, -1, new List<ShortList>(), -1, new List<short> { 147 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_114"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(115, LocalStringManager.GetConfig("BuildingBlock_language", "Name_115"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_115"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_115"), "SectSpecial/2503_fangshiguan", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Math, 1, canOpenManageOutTaiwu: false, 1, "423d59", new ushort[8] { 0, 2500, 0, 5000, 2500, 0, 0, 2500 }, 50, 50, new sbyte[7], 162, new List<short> { 113 }, new List<short>(), 4, -1, 5, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_115"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_115"), new short[16]
		{
			-1, -1, -1, -1, 12, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 6 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 71 }, new List<short> { 74 }, -1, new List<ShortList>(), -1, new List<short> { 172 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_115"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(116, LocalStringManager.GetConfig("BuildingBlock_language", "Name_116"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_116"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_116"), "SectSpecial/2504_jitiangaotai", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Math, 1, canOpenManageOutTaiwu: false, 1, "423d59", new ushort[8] { 0, 2500, 0, 5000, 1500, 0, 5000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 113 }, new List<short>(), 4, -1, 5, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_116"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_116"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 6 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, -50, 0, new List<short> { 72 }, new List<short> { 75 }, -1, new List<ShortList>(), -1, new List<short> { 156 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_116"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(117, LocalStringManager.GetConfig("BuildingBlock_language", "Name_117"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_117"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_117"), "SectSpecial/2505_zhaixinglou", "Func_LiveSkill4", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Math, 1, canOpenManageOutTaiwu: false, 1, "423d59", new ushort[8] { 0, 1500, 0, 2500, 1000, 0, 15000, 1000 }, 50, 50, new sbyte[7], 163, new List<short> { 113, 4 }, new List<short>(), 4, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_117"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_117"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 4, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 190 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_117"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(118, LocalStringManager.GetConfig("BuildingBlock_language", "Name_118"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_118"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_118"), "SectSpecial/2506_kunlunta", "Func_LiveSkill4", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Math, 1, canOpenManageOutTaiwu: false, 1, "423d59", new ushort[8] { 0, 7500, 0, 10000, 2500, 0, 0, 5000 }, 50, 50, new sbyte[7], 164, new List<short> { 113, 18 }, new List<short>(), 4, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_118"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_118"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 4, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 206 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_118"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(119, LocalStringManager.GetConfig("BuildingBlock_language", "Name_119"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_119"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_119"), "SectSpecial/2508_shengmieliangxingfan", "Func_LiveSkill4", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Math, 1, canOpenManageOutTaiwu: false, 1, "423d59", new ushort[8] { 0, 10000, 0, 15000, 5000, 0, 0, 15000 }, 50, 50, new sbyte[7], 165, new List<short> { 113 }, new List<short>(), 4, -1, 5, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_119"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_119"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 1000)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 6 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 228 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_119"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new BuildingBlockItem(120, LocalStringManager.GetConfig("BuildingBlock_language", "Name_120"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_120"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_120"), "SectSpecial/1014_ganquanting", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Appraisal, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8] { 1500, 1000, 0, 0, 0, 500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 121, 122, 123, 124, 125, 126, 127, 128 }, 5, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_120"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_120"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 250, mustMaintenance: false, isUnique: false, 0, 5, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 122 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_120"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(121, LocalStringManager.GetConfig("BuildingBlock_language", "Name_121"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_121"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_121"), "SectSpecial/2602_chaguan", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Appraisal, 1, canOpenManageOutTaiwu: false, 1, "9a694f", new ushort[8] { 2500, 500, 0, 0, 0, 1000, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 120 }, new List<short>(), 5, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_121"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_121"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 250, 250 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, 50, new List<short> { 76 }, new List<short> { 82 }, -1, new List<ShortList>(), -1, new List<short> { 133 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_121"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(122, LocalStringManager.GetConfig("BuildingBlock_language", "Name_122"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_122"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_122"), "SectSpecial/2603_jiusi", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Appraisal, 1, canOpenManageOutTaiwu: false, 1, "9a694f", new ushort[8] { 2500, 1000, 0, 0, 0, 500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 120 }, new List<short>(), 5, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_122"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_122"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, 50, new List<short> { 77 }, new List<short> { 83 }, -1, new List<ShortList>(), -1, new List<short> { 134 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_122"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(123, LocalStringManager.GetConfig("BuildingBlock_language", "Name_123"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_123"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_123"), "SectSpecial/2604_wenxiangyuan", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Appraisal, 1, canOpenManageOutTaiwu: false, 1, "9a694f", new ushort[8] { 5000, 2500, 0, 0, 0, 2500, 0, 2500 }, 50, 50, new sbyte[7], 166, new List<short> { 120 }, new List<short>(), 5, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_123"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_123"), new short[16]
		{
			-1, -1, -1, -1, -1, 12, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 78 }, new List<short> { 84 }, -1, new List<ShortList>(), -1, new List<short> { 173 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_123"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(124, LocalStringManager.GetConfig("BuildingBlock_language", "Name_124"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_124"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_124"), "SectSpecial/2605_sihaifu", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Appraisal, 1, canOpenManageOutTaiwu: false, 1, "9a694f", new ushort[8] { 5000, 2500, 0, 0, 0, 1500, 5000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 120 }, new List<short>(), 5, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_124"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_124"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 0, 50, new List<short> { 79 }, new List<short> { 85 }, -1, new List<ShortList>(), -1, new List<short> { 157 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_124"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(125, LocalStringManager.GetConfig("BuildingBlock_language", "Name_125"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_125"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_125"), "SectSpecial/2606_hufang", "Func_LiveSkill5", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Appraisal, 1, canOpenManageOutTaiwu: false, 1, "9a694f", new ushort[8] { 5000, 2000, 0, 0, 0, 1000, 0, 1000 }, 50, 50, new sbyte[7], 167, new List<short> { 120, 1 }, new List<short>(), 5, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_125"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_125"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 5, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 191 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_125"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(126, LocalStringManager.GetConfig("BuildingBlock_language", "Name_126"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_126"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_126"), "SectSpecial/2607_shenxianyuan", "Func_LiveSkill5", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Appraisal, 1, canOpenManageOutTaiwu: false, 1, "9a694f", new ushort[8] { 12500, 2500, 0, 0, 0, 2500, 12500, 5000 }, 50, 50, new sbyte[7], 168, new List<short> { 120, 15 }, new List<short>(), 5, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_126"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_126"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 5, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 207 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_126"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(127, LocalStringManager.GetConfig("BuildingBlock_language", "Name_127"), EBuildingBlockFuncType.Item, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_127"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_127"), "SectSpecial/2608_chayuan", "Func_GetItem1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Appraisal, 1, canOpenManageOutTaiwu: false, 1, "9a694f", new ushort[8] { 15000, 5000, 0, 0, 0, 10000, 0, 15000 }, 50, 50, new sbyte[7], 169, new List<short> { 120, 9 }, new List<short>(), 5, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_127"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_127"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 1000)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 80 }, new List<short> { 86 }, -1, new List<ShortList>(), -1, new List<short> { 246 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_127"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: true, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(128, LocalStringManager.GetConfig("BuildingBlock_language", "Name_128"), EBuildingBlockFuncType.Item, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_128"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_128"), "SectSpecial/2609_zhengjiufang", "Func_GetItem2", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Appraisal, 1, canOpenManageOutTaiwu: false, 1, "9a694f", new ushort[8] { 15000, 10000, 0, 0, 0, 5000, 0, 15000 }, 50, 50, new sbyte[7], 170, new List<short> { 120, 9 }, new List<short>(), 5, -1, 1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_128"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_128"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 1000)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 4 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 81 }, new List<short> { 87 }, -1, new List<ShortList>(), -1, new List<short> { 247 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_128"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: true, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(129, LocalStringManager.GetConfig("BuildingBlock_language", "Name_129"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_129"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_129"), "SectSpecial/1015_huolianshi", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Forging, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8] { 0, 500, 2500, 0, 0, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 130, 131, 132, 133, 134, 135, 136, 137, 138 }, 6, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_129"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_129"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(2, 10)
		}, 250, mustMaintenance: false, isUnique: false, 0, 6, -1, -1, -1, -1, canMakeItem: true, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 123 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_129"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: true, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(130, LocalStringManager.GetConfig("BuildingBlock_language", "Name_130"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_130"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_130"), "SectSpecial/2702_tiejiangpu", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Forging, 1, canOpenManageOutTaiwu: false, 1, "583936", new ushort[8] { 0, 1500, 2500, 0, 1000, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 129 }, new List<short>(), 6, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_130"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_130"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(2, 20)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, 50, new List<short> { 88 }, new List<short> { 93 }, -1, new List<ShortList>(), -1, new List<short> { 135 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_130"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(131, LocalStringManager.GetConfig("BuildingBlock_language", "Name_131"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_131"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_131"), "SectSpecial/2703_duanyefang", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Forging, 1, canOpenManageOutTaiwu: false, 1, "583936", new ushort[8] { 0, 2500, 5000, 0, 1500, 0, 5000, 2500 }, 50, 50, new sbyte[7], 171, new List<short> { 129 }, new List<short>(), 6, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_131"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_131"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 89 }, new List<short> { 94 }, -1, new List<ShortList>(), -1, new List<short> { 174 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_131"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(132, LocalStringManager.GetConfig("BuildingBlock_language", "Name_132"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_132"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_132"), "SectSpecial/2704_jinpu", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Forging, 1, canOpenManageOutTaiwu: false, 1, "583936", new ushort[8] { 0, 1500, 5000, 0, 500, 0, 15000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 129 }, new List<short>(), 6, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_132"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_132"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(2, 100)
		}, 1000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 0, 50, new List<short> { 90 }, new List<short> { 95 }, -1, new List<ShortList>(), -1, new List<short> { 162 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_132"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(133, LocalStringManager.GetConfig("BuildingBlock_language", "Name_133"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_133"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_133"), "SectSpecial/2705_shuipai", "Func_LiveSkill6", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Forging, 1, canOpenManageOutTaiwu: false, 1, "583936", new ushort[8] { 0, 2000, 5000, 0, 1000, 0, 0, 1000 }, 50, 50, new sbyte[7], -1, new List<short> { 129, 1 }, new List<short>(), 6, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_133"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_133"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(2, 20)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 6, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 192 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_133"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(134, LocalStringManager.GetConfig("BuildingBlock_language", "Name_134"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_134"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_134"), "SectSpecial/2706_yuntiekuangchang", "Func_LiveSkill6", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Forging, 1, canOpenManageOutTaiwu: false, 1, "583936", new ushort[8] { 0, 5000, 12500, 0, 2500, 0, 0, 5000 }, 50, 50, new sbyte[7], 172, new List<short> { 129, 12 }, new List<short>(), 6, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_134"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_134"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(2, 100)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 6, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 208 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_134"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(135, LocalStringManager.GetConfig("BuildingBlock_language", "Name_135"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_135"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_135"), "SectSpecial/2707_taoxichi", "Func_GetMoreItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Forging, 1, canOpenManageOutTaiwu: false, 1, "583936", new ushort[8] { 0, 10000, 20000, 0, 5000, 0, 0, 7500 }, 50, 50, new sbyte[7], 173, new List<short> { 129, 2 }, new List<short>(), 6, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_135"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_135"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(2, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 91 }, new List<short> { 96 }, -1, new List<ShortList>(), -1, new List<short> { 231 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_135"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(136, LocalStringManager.GetConfig("BuildingBlock_language", "Name_136"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_136"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_136"), "SectSpecial/2708_jinglianshi", "Func_GetBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Forging, 1, canOpenManageOutTaiwu: false, 1, "583936", new ushort[8] { 0, 10000, 20000, 0, 5000, 0, 0, 7500 }, 50, 50, new sbyte[7], 174, new List<short> { 129, 2 }, new List<short>(), 6, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_136"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_136"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(2, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 92 }, new List<short> { 97 }, -1, new List<ShortList>(), -1, new List<short> { 232 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_136"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(137, LocalStringManager.GetConfig("BuildingBlock_language", "Name_137"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_137"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_137"), "SectSpecial/2709_longjingqixingquan", "Func_MakeBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Forging, 1, canOpenManageOutTaiwu: false, 1, "583936", new ushort[8] { 0, 15000, 55000, 0, 10000, 0, 0, 35000 }, 50, 50, new sbyte[7], 175, new List<short> { 129 }, new List<short>(), 6, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_137"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_137"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(2, 200)
		}, 15000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: true, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_137"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(138, LocalStringManager.GetConfig("BuildingBlock_language", "Name_138"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_138"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_138"), "SectSpecial/2710_shenhuozhu", "Func_ReduceRequirement", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Forging, 1, canOpenManageOutTaiwu: false, 1, "583936", new ushort[8] { 0, 7500, 25000, 0, 2500, 0, 25000, 15000 }, 50, 50, new sbyte[7], 176, new List<short> { 129, 11 }, new List<short>(), 6, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_138"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_138"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(2, 100)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, 6, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 218 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_138"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(139, LocalStringManager.GetConfig("BuildingBlock_language", "Name_139"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_139"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_139"), "SectSpecial/1016_mugongfang", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Woodworking, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8] { 0, 2500, 500, 0, 0, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 140, 141, 142, 143, 144, 145, 146, 147, 148 }, 7, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_139"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_139"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(1, 10)
		}, 250, mustMaintenance: false, isUnique: false, 0, 7, -1, -1, -1, -1, canMakeItem: true, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 124 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_139"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: true, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(140, LocalStringManager.GetConfig("BuildingBlock_language", "Name_140"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_140"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_140"), "SectSpecial/2802_mugongpu", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Woodworking, 1, canOpenManageOutTaiwu: false, 1, "4c6b5d", new ushort[8] { 0, 2500, 1500, 0, 1000, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 139 }, new List<short>(), 7, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_140"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_140"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(1, 20)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, 50, new List<short> { 98 }, new List<short> { 103 }, -1, new List<ShortList>(), -1, new List<short> { 136 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_140"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(141, LocalStringManager.GetConfig("BuildingBlock_language", "Name_141"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_141"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_141"), "SectSpecial/2803_zhimufang", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Woodworking, 1, canOpenManageOutTaiwu: false, 1, "4c6b5d", new ushort[8] { 0, 5000, 2500, 0, 1500, 0, 5000, 2500 }, 50, 50, new sbyte[7], 177, new List<short> { 139 }, new List<short>(), 7, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_141"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_141"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, 12, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 99 }, new List<short> { 104 }, -1, new List<ShortList>(), -1, new List<short> { 175 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_141"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(142, LocalStringManager.GetConfig("BuildingBlock_language", "Name_142"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_142"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_142"), "SectSpecial/2804_yingzaofang", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Woodworking, 1, canOpenManageOutTaiwu: false, 1, "4c6b5d", new ushort[8] { 0, 5000, 1500, 0, 500, 0, 15000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 139 }, new List<short>(), 7, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_142"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_142"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(1, 100)
		}, 1000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 0, 50, new List<short> { 100 }, new List<short> { 105 }, -1, new List<ShortList>(), -1, new List<short> { 163 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_142"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(143, LocalStringManager.GetConfig("BuildingBlock_language", "Name_143"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_143"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_143"), "SectSpecial/2805_heizhichi", "Func_LiveSkill7", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Woodworking, 1, canOpenManageOutTaiwu: false, 1, "4c6b5d", new ushort[8] { 0, 5000, 2000, 0, 1000, 0, 0, 1000 }, 50, 50, new sbyte[7], -1, new List<short> { 139, 6 }, new List<short>(), 7, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_143"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_143"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(1, 20)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 7, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 193 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_143"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(144, LocalStringManager.GetConfig("BuildingBlock_language", "Name_144"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_144"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_144"), "SectSpecial/2806_muliaobiaoben", "Func_LiveSkill7", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Woodworking, 1, canOpenManageOutTaiwu: false, 1, "4c6b5d", new ushort[8] { 0, 12500, 5000, 0, 2500, 0, 0, 5000 }, 50, 50, new sbyte[7], 178, new List<short> { 139, 13 }, new List<short>(), 7, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_144"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_144"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(1, 100)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 7, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 209 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_144"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(145, LocalStringManager.GetConfig("BuildingBlock_language", "Name_145"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_145"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_145"), "SectSpecial/2807_famuchang", "Func_GetMoreItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Woodworking, 1, canOpenManageOutTaiwu: false, 1, "4c6b5d", new ushort[8] { 0, 20000, 10000, 0, 5000, 0, 0, 7500 }, 50, 50, new sbyte[7], 179, new List<short> { 139, 3 }, new List<short>(), 7, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_145"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_145"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(1, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 101 }, new List<short> { 106 }, -1, new List<ShortList>(), -1, new List<short> { 233 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_145"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(146, LocalStringManager.GetConfig("BuildingBlock_language", "Name_146"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_146"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_146"), "SectSpecial/2808_linchang", "Func_GetBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Woodworking, 1, canOpenManageOutTaiwu: false, 1, "4c6b5d", new ushort[8] { 0, 20000, 10000, 0, 5000, 0, 0, 7500 }, 50, 50, new sbyte[7], 180, new List<short> { 139, 3 }, new List<short>(), 7, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_146"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_146"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(1, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 102 }, new List<short> { 107 }, -1, new List<ShortList>(), -1, new List<short> { 234 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_146"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(147, LocalStringManager.GetConfig("BuildingBlock_language", "Name_147"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_147"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_147"), "SectSpecial/2809_youmingyao", "Func_MakeBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Woodworking, 1, canOpenManageOutTaiwu: false, 1, "4c6b5d", new ushort[8] { 0, 55000, 15000, 0, 10000, 0, 0, 35000 }, 50, 50, new sbyte[7], 181, new List<short> { 139 }, new List<short>(), 7, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_147"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_147"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(1, 200)
		}, 15000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: true, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_147"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(148, LocalStringManager.GetConfig("BuildingBlock_language", "Name_148"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_148"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_148"), "SectSpecial/2810_shenmulin", "Func_ReduceRequirement", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Woodworking, 1, canOpenManageOutTaiwu: false, 1, "4c6b5d", new ushort[8] { 0, 25000, 7500, 0, 2500, 0, 25000, 15000 }, 50, 50, new sbyte[7], 182, new List<short> { 139, 14 }, new List<short>(), 7, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_148"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_148"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(1, 100)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, 7, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 219 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_148"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(149, LocalStringManager.GetConfig("BuildingBlock_language", "Name_149"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_149"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_149"), "SectSpecial/1017_yaofang", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Medicine, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8] { 0, 0, 0, 0, 500, 2500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 150, 151, 152, 153, 154, 155, 156, 157, 158 }, 8, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_149"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_149"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(5, 10)
		}, 250, mustMaintenance: false, isUnique: false, 0, 8, -1, -1, -1, -1, canMakeItem: true, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 125 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_149"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: true, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(150, LocalStringManager.GetConfig("BuildingBlock_language", "Name_150"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_150"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_150"), "SectSpecial/2902_shuyaopu", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Medicine, 1, canOpenManageOutTaiwu: false, 1, "698455", new ushort[8] { 0, 0, 0, 1000, 1500, 2500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 149 }, new List<short>(), 8, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_150"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_150"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 20)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, -50, new List<short> { 108 }, new List<short> { 113 }, -1, new List<ShortList>(), -1, new List<short> { 137 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_150"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(151, LocalStringManager.GetConfig("BuildingBlock_language", "Name_151"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_151"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_151"), "SectSpecial/2903_yaoshiguan", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Medicine, 1, canOpenManageOutTaiwu: false, 1, "698455", new ushort[8] { 0, 0, 0, 1500, 2500, 5000, 5000, 2500 }, 50, 50, new sbyte[7], 183, new List<short> { 149 }, new List<short>(), 8, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_151"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_151"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, 12, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 109 }, new List<short> { 114 }, -1, new List<ShortList>(), -1, new List<short> { 176 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_151"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(152, LocalStringManager.GetConfig("BuildingBlock_language", "Name_152"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_152"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_152"), "SectSpecial/2904_bingfang", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Medicine, 1, canOpenManageOutTaiwu: false, 1, "698455", new ushort[8] { 0, 0, 0, 500, 1500, 5000, 15000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 149 }, new List<short>(), 8, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_152"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_152"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 100)
		}, 1000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 0, -50, new List<short> { 110 }, new List<short> { 115 }, -1, new List<ShortList>(), -1, new List<short> { 164 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_152"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(153, LocalStringManager.GetConfig("BuildingBlock_language", "Name_153"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_153"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_153"), "SectSpecial/2905_shouyiguan", "Func_LiveSkill8", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Medicine, 1, canOpenManageOutTaiwu: false, 1, "698455", new ushort[8] { 0, 0, 0, 1000, 2000, 5000, 0, 1000 }, 50, 50, new sbyte[7], -1, new List<short> { 149, 10 }, new List<short>(), 8, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_153"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_153"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 20)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 8, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 194 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_153"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(154, LocalStringManager.GetConfig("BuildingBlock_language", "Name_154"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_154"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_154"), "SectSpecial/2906_yingaibingguan", "Func_LiveSkill8", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Medicine, 1, canOpenManageOutTaiwu: false, 1, "698455", new ushort[8] { 0, 0, 0, 2500, 5000, 12500, 0, 5000 }, 50, 50, new sbyte[7], 184, new List<short> { 149, 20 }, new List<short>(), 8, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_154"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_154"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 100)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 8, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 210 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_154"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(155, LocalStringManager.GetConfig("BuildingBlock_language", "Name_155"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_155"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_155"), "SectSpecial/2907_yaopu", "Func_GetMoreItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Medicine, 1, canOpenManageOutTaiwu: false, 1, "698455", new ushort[8] { 0, 0, 0, 5000, 10000, 20000, 0, 7500 }, 50, 50, new sbyte[7], 185, new List<short> { 149, 5 }, new List<short>(), 8, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_155"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_155"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 111 }, new List<short> { 116 }, -1, new List<ShortList>(), -1, new List<short> { 239 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_155"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(156, LocalStringManager.GetConfig("BuildingBlock_language", "Name_156"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_156"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_156"), "SectSpecial/2908_yangyaoshi", "Func_GetBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Medicine, 1, canOpenManageOutTaiwu: false, 1, "698455", new ushort[8] { 0, 0, 0, 5000, 10000, 20000, 0, 7500 }, 50, 50, new sbyte[7], 186, new List<short> { 149, 5 }, new List<short>(), 8, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_156"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_156"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 112 }, new List<short> { 117 }, -1, new List<ShortList>(), -1, new List<short> { 240 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_156"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(157, LocalStringManager.GetConfig("BuildingBlock_language", "Name_157"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_157"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_157"), "SectSpecial/2909_shuihuoqinglu", "Func_MakeBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Medicine, 1, canOpenManageOutTaiwu: false, 1, "698455", new ushort[8] { 0, 0, 0, 10000, 15000, 55000, 0, 35000 }, 50, 50, new sbyte[7], 187, new List<short> { 149 }, new List<short>(), 8, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_157"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_157"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 200)
		}, 15000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: true, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_157"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(158, LocalStringManager.GetConfig("BuildingBlock_language", "Name_158"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_158"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_158"), "SectSpecial/2910_shennongjian", "Func_ReduceRequirement", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Medicine, 1, canOpenManageOutTaiwu: false, 1, "698455", new ushort[8] { 0, 0, 0, 2500, 7500, 25000, 25000, 15000 }, 50, 50, new sbyte[7], 188, new List<short> { 149, 15 }, new List<short>(), 8, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_158"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_158"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 100)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, 8, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 220 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_158"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(159, LocalStringManager.GetConfig("BuildingBlock_language", "Name_159"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_159"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_159"), "SectSpecial/1018_youshi", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Toxicology, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8] { 500, 0, 0, 0, 0, 2500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 160, 161, 162, 163, 164, 165, 166, 167, 168 }, 9, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_159"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_159"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(5, 10)
		}, 250, mustMaintenance: false, isUnique: false, 0, 9, -1, -1, -1, -1, canMakeItem: true, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 126 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_159"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: true, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(160, LocalStringManager.GetConfig("BuildingBlock_language", "Name_160"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_160"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_160"), "SectSpecial/3002_dushi", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Toxicology, 1, canOpenManageOutTaiwu: false, 1, "6b6c9e", new ushort[8] { 1500, 0, 1000, 0, 0, 2500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 159 }, new List<short>(), 9, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_160"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_160"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 20)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, -50, new List<short> { 118 }, new List<short> { 123 }, -1, new List<ShortList>(), -1, new List<short> { 138 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_160"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(161, LocalStringManager.GetConfig("BuildingBlock_language", "Name_161"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_161"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_161"), "SectSpecial/3003_anlao", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Toxicology, 1, canOpenManageOutTaiwu: false, 1, "6b6c9e", new ushort[8] { 2500, 0, 1500, 0, 0, 5000, 5000, 2500 }, 50, 50, new sbyte[7], 189, new List<short> { 159 }, new List<short>(), 9, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_161"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_161"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, 12,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 119 }, new List<short> { 124 }, -1, new List<ShortList>(), -1, new List<short> { 177 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_161"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(162, LocalStringManager.GetConfig("BuildingBlock_language", "Name_162"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_162"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_162"), "SectSpecial/3004_miyi", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Toxicology, 1, canOpenManageOutTaiwu: false, 1, "6b6c9e", new ushort[8] { 1500, 0, 500, 0, 0, 5000, 15000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 159 }, new List<short>(), 9, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_162"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_162"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 100)
		}, 1000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 0, -50, new List<short> { 120 }, new List<short> { 125 }, -1, new List<ShortList>(), -1, new List<short> { 165 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_162"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(163, LocalStringManager.GetConfig("BuildingBlock_language", "Name_163"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_163"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_163"), "SectSpecial/3005_huanyangshi", "Func_LiveSkill9", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Toxicology, 1, canOpenManageOutTaiwu: false, 1, "6b6c9e", new ushort[8] { 2000, 0, 1000, 0, 0, 5000, 0, 1000 }, 50, 50, new sbyte[7], -1, new List<short> { 159, 10 }, new List<short>(), 9, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_163"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_163"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 20)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 9, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 195 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_163"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(164, LocalStringManager.GetConfig("BuildingBlock_language", "Name_164"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_164"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_164"), "SectSpecial/3006_wurenju", "Func_LiveSkill9", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Toxicology, 1, canOpenManageOutTaiwu: false, 1, "6b6c9e", new ushort[8] { 5000, 0, 2500, 0, 0, 12500, 0, 5000 }, 50, 50, new sbyte[7], 190, new List<short> { 159, 13 }, new List<short>(), 9, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_164"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_164"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 100)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 9, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 211 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_164"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(165, LocalStringManager.GetConfig("BuildingBlock_language", "Name_165"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_165"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_165"), "SectSpecial/3007_lianzhangchi", "Func_GetMoreItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Toxicology, 1, canOpenManageOutTaiwu: false, 1, "6b6c9e", new ushort[8] { 10000, 0, 5000, 0, 0, 20000, 0, 7500 }, 50, 50, new sbyte[7], 191, new List<short> { 159, 6 }, new List<short>(), 9, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_165"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_165"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 121 }, new List<short> { 126 }, -1, new List<ShortList>(), -1, new List<short> { 241 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_165"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(166, LocalStringManager.GetConfig("BuildingBlock_language", "Name_166"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_166"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_166"), "SectSpecial/3008_feirenchi", "Func_GetBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Toxicology, 1, canOpenManageOutTaiwu: false, 1, "6b6c9e", new ushort[8] { 10000, 0, 5000, 0, 0, 20000, 0, 7500 }, 50, 50, new sbyte[7], 192, new List<short> { 159, 6 }, new List<short>(), 9, -1, 0, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_166"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_166"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 2 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 122 }, new List<short> { 127 }, -1, new List<ShortList>(), -1, new List<short> { 242 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_166"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(167, LocalStringManager.GetConfig("BuildingBlock_language", "Name_167"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_167"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_167"), "SectSpecial/3009_xuechi", "Func_MakeBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Toxicology, 1, canOpenManageOutTaiwu: false, 1, "6b6c9e", new ushort[8] { 15000, 0, 10000, 0, 0, 55000, 0, 35000 }, 50, 50, new sbyte[7], 193, new List<short> { 159 }, new List<short>(), 9, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_167"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_167"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 200)
		}, 15000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: true, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_167"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(168, LocalStringManager.GetConfig("BuildingBlock_language", "Name_168"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_168"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_168"), "SectSpecial/3010_shenlongzhu", "Func_ReduceRequirement", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Toxicology, 1, canOpenManageOutTaiwu: false, 1, "6b6c9e", new ushort[8] { 7500, 0, 2500, 0, 0, 25000, 25000, 15000 }, 50, 50, new sbyte[7], 194, new List<short> { 159, 16 }, new List<short>(), 9, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_168"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_168"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(5, 100)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, 9, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 221 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_168"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(169, LocalStringManager.GetConfig("BuildingBlock_language", "Name_169"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_169"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_169"), "SectSpecial/1019_xiulou", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Weaving, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8] { 0, 500, 0, 0, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 170, 171, 172, 173, 174, 175, 176, 177, 178 }, 10, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_169"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_169"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(4, 10)
		}, 250, mustMaintenance: false, isUnique: false, 0, 10, -1, -1, -1, -1, canMakeItem: true, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 127 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_169"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: true, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(170, LocalStringManager.GetConfig("BuildingBlock_language", "Name_170"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_170"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_170"), "SectSpecial/3102_buzhuang", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Weaving, 1, canOpenManageOutTaiwu: false, 1, "212b3c", new ushort[8] { 0, 1500, 0, 1000, 2500, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 169 }, new List<short>(), 10, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_170"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_170"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(4, 20)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, 50, new List<short> { 128 }, new List<short> { 133 }, -1, new List<ShortList>(), -1, new List<short> { 139 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_170"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(171, LocalStringManager.GetConfig("BuildingBlock_language", "Name_171"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_171"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_171"), "SectSpecial/3103_zhizaofang", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Weaving, 1, canOpenManageOutTaiwu: false, 1, "212b3c", new ushort[8] { 0, 2500, 0, 1500, 5000, 0, 5000, 2500 }, 50, 50, new sbyte[7], 195, new List<short> { 169 }, new List<short>(), 10, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_171"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_171"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			12, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 129 }, new List<short> { 134 }, -1, new List<ShortList>(), -1, new List<short> { 178 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_171"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(172, LocalStringManager.GetConfig("BuildingBlock_language", "Name_172"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_172"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_172"), "SectSpecial/3104_jinxiuge", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Weaving, 1, canOpenManageOutTaiwu: false, 1, "212b3c", new ushort[8] { 0, 1500, 0, 500, 5000, 0, 15000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 169 }, new List<short>(), 10, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_172"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_172"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(4, 100)
		}, 1000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 0, 50, new List<short> { 130 }, new List<short> { 135 }, -1, new List<ShortList>(), -1, new List<short> { 166 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_172"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(173, LocalStringManager.GetConfig("BuildingBlock_language", "Name_173"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_173"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_173"), "SectSpecial/3105_zhuixingge", "Func_LiveSkill10", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Weaving, 1, canOpenManageOutTaiwu: false, 1, "212b3c", new ushort[8] { 0, 2000, 0, 1000, 5000, 0, 0, 1000 }, 50, 50, new sbyte[7], -1, new List<short> { 169, 8 }, new List<short>(), 10, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_173"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_173"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(4, 20)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 10, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 196 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_173"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(174, LocalStringManager.GetConfig("BuildingBlock_language", "Name_174"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_174"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_174"), "SectSpecial/3106_shegulingji", "Func_LiveSkill10", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Weaving, 1, canOpenManageOutTaiwu: false, 1, "212b3c", new ushort[8] { 0, 5000, 0, 2500, 12500, 0, 0, 5000 }, 50, 50, new sbyte[7], 196, new List<short> { 169, 16 }, new List<short>(), 10, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_174"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_174"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(4, 100)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 10, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 212 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_174"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(175, LocalStringManager.GetConfig("BuildingBlock_language", "Name_175"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_175"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_175"), "SectSpecial/3107_baihuapu", "Func_GetMoreItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Weaving, 1, canOpenManageOutTaiwu: false, 1, "212b3c", new ushort[8] { 0, 10000, 0, 5000, 20000, 0, 0, 7500 }, 50, 50, new sbyte[7], 197, new List<short> { 169, 7 }, new List<short>(), 10, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_175"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_175"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(4, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 131 }, new List<short> { 136 }, -1, new List<ShortList>(), -1, new List<short> { 235 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_175"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(176, LocalStringManager.GetConfig("BuildingBlock_language", "Name_176"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_176"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_176"), "SectSpecial/3108_qizhenyuan", "Func_GetBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Weaving, 1, canOpenManageOutTaiwu: false, 1, "212b3c", new ushort[8] { 0, 10000, 0, 5000, 20000, 0, 0, 7500 }, 50, 50, new sbyte[7], 198, new List<short> { 169, 7 }, new List<short>(), 10, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_176"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_176"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(4, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 132 }, new List<short> { 137 }, -1, new List<ShortList>(), -1, new List<short> { 236 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_176"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(177, LocalStringManager.GetConfig("BuildingBlock_language", "Name_177"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_177"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_177"), "SectSpecial/3109_caisangyuan", "Func_MakeBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Weaving, 1, canOpenManageOutTaiwu: false, 1, "212b3c", new ushort[8] { 0, 15000, 0, 10000, 55000, 0, 0, 35000 }, 50, 50, new sbyte[7], 199, new List<short> { 169 }, new List<short>(), 10, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_177"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_177"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(4, 200)
		}, 15000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: true, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_177"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(178, LocalStringManager.GetConfig("BuildingBlock_language", "Name_178"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_178"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_178"), "SectSpecial/3110_shencaisuo", "Func_ReduceRequirement", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Weaving, 1, canOpenManageOutTaiwu: false, 1, "212b3c", new ushort[8] { 0, 7500, 0, 2500, 25000, 0, 25000, 15000 }, 50, 50, new sbyte[7], 200, new List<short> { 169, 17 }, new List<short>(), 10, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_178"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_178"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(4, 100)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, 10, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 222 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_178"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(179, LocalStringManager.GetConfig("BuildingBlock_language", "Name_179"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_179"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_179"), "SectSpecial/1020_qiaojiangwu", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Jade, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8] { 0, 0, 500, 2500, 0, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 180, 181, 182, 183, 184, 185, 186, 187, 188 }, 11, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_179"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_179"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(3, 10)
		}, 250, mustMaintenance: false, isUnique: false, 0, 11, -1, -1, -1, -1, canMakeItem: true, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 128 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_179"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: true, 0, new List<short>(), 0, 0u, null, null));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new BuildingBlockItem(180, LocalStringManager.GetConfig("BuildingBlock_language", "Name_180"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_180"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_180"), "SectSpecial/3202_zhubaopu", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Jade, 1, canOpenManageOutTaiwu: false, 1, "624166", new ushort[8] { 0, 0, 1500, 2500, 1000, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 179 }, new List<short>(), 11, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_180"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_180"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(3, 20)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, 50, new List<short> { 138 }, new List<short> { 143 }, -1, new List<ShortList>(), -1, new List<short> { 140 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_180"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(181, LocalStringManager.GetConfig("BuildingBlock_language", "Name_181"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_181"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_181"), "SectSpecial/3203_maoshifang", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Jade, 1, canOpenManageOutTaiwu: false, 1, "624166", new ushort[8] { 0, 0, 2500, 5000, 1500, 0, 5000, 2500 }, 50, 50, new sbyte[7], 201, new List<short> { 179 }, new List<short>(), 11, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_181"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_181"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, 12, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 139 }, new List<short> { 144 }, -1, new List<ShortList>(), -1, new List<short> { 179 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_181"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(182, LocalStringManager.GetConfig("BuildingBlock_language", "Name_182"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_182"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_182"), "SectSpecial/3204_linlangge", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Jade, 1, canOpenManageOutTaiwu: false, 1, "624166", new ushort[8] { 0, 0, 1500, 5000, 500, 0, 15000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 179 }, new List<short>(), 11, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_182"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_182"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(3, 100)
		}, 1000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 0, 50, new List<short> { 140 }, new List<short> { 145 }, -1, new List<ShortList>(), -1, new List<short> { 167 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_182"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(183, LocalStringManager.GetConfig("BuildingBlock_language", "Name_183"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_183"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_183"), "SectSpecial/3205_gongyulou", "Func_LiveSkill11", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Jade, 1, canOpenManageOutTaiwu: false, 1, "624166", new ushort[8] { 0, 0, 2000, 5000, 1000, 0, 0, 1000 }, 50, 50, new sbyte[7], -1, new List<short> { 179, 2 }, new List<short>(), 11, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_183"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_183"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(3, 20)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 11, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 197 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_183"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(184, LocalStringManager.GetConfig("BuildingBlock_language", "Name_184"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_184"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_184"), "SectSpecial/3206_chixuejing", "Func_LiveSkill11", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Jade, 1, canOpenManageOutTaiwu: false, 1, "624166", new ushort[8] { 0, 0, 5000, 12500, 2500, 0, 0, 5000 }, 50, 50, new sbyte[7], 202, new List<short> { 179, 11 }, new List<short>(), 11, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_184"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_184"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(3, 100)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 11, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 213 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_184"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(185, LocalStringManager.GetConfig("BuildingBlock_language", "Name_185"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_185"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_185"), "SectSpecial/3207_huanbichi", "Func_GetMoreItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Jade, 1, canOpenManageOutTaiwu: false, 1, "624166", new ushort[8] { 0, 0, 10000, 20000, 5000, 0, 0, 7500 }, 50, 50, new sbyte[7], 203, new List<short> { 179, 8 }, new List<short>(), 11, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_185"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_185"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(3, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 141 }, new List<short> { 146 }, -1, new List<ShortList>(), -1, new List<short> { 237 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_185"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(186, LocalStringManager.GetConfig("BuildingBlock_language", "Name_186"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_186"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_186"), "SectSpecial/3208_jingangjieyutai", "Func_GetBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Jade, 1, canOpenManageOutTaiwu: false, 1, "624166", new ushort[8] { 0, 0, 10000, 20000, 5000, 0, 0, 7500 }, 50, 50, new sbyte[7], 204, new List<short> { 179, 8 }, new List<short>(), 11, -1, 4, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_186"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_186"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(3, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 1 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 142 }, new List<short> { 147 }, -1, new List<ShortList>(), -1, new List<short> { 238 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_186"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(187, LocalStringManager.GetConfig("BuildingBlock_language", "Name_187"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_187"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_187"), "SectSpecial/3209_linglongtai", "Func_MakeBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Jade, 1, canOpenManageOutTaiwu: false, 1, "624166", new ushort[8] { 0, 0, 15000, 55000, 10000, 0, 0, 35000 }, 50, 50, new sbyte[7], 205, new List<short> { 179 }, new List<short>(), 11, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_187"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_187"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(3, 200)
		}, 15000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: true, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_187"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(188, LocalStringManager.GetConfig("BuildingBlock_language", "Name_188"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_188"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_188"), "SectSpecial/3210_shenguangbi", "Func_ReduceRequirement", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Jade, 1, canOpenManageOutTaiwu: false, 1, "624166", new ushort[8] { 0, 0, 7500, 25000, 2500, 0, 25000, 15000 }, 50, 50, new sbyte[7], 206, new List<short> { 179, 19 }, new List<short>(), 11, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_188"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_188"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(3, 100)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, 11, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 223 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_188"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(189, LocalStringManager.GetConfig("BuildingBlock_language", "Name_189"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_189"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_189"), "SectSpecial/1021_yunfang", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Taoism, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8] { 0, 500, 0, 1000, 0, 1500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 190, 191, 192, 193, 194, 195 }, 12, -1, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_189"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_189"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 250, mustMaintenance: false, isUnique: false, 0, 12, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 129 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_189"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(190, LocalStringManager.GetConfig("BuildingBlock_language", "Name_190"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_190"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_190"), "SectSpecial/3302_fashidaochang", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Taoism, 1, canOpenManageOutTaiwu: false, 1, "414f8a", new ushort[8] { 0, 500, 0, 1000, 0, 2500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 189 }, new List<short>(), 12, -1, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_190"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_190"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, -50, new List<short> { 148 }, new List<short> { 151 }, -1, new List<ShortList>(), -1, new List<short> { 148 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_190"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(191, LocalStringManager.GetConfig("BuildingBlock_language", "Name_191"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_191"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_191"), "SectSpecial/3303_daoguan", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Taoism, 1, canOpenManageOutTaiwu: false, 1, "414f8a", new ushort[8] { 0, 2000, 0, 3000, 0, 5000, 0, 2500 }, 50, 50, new sbyte[7], 207, new List<short> { 189 }, new List<short>(), 12, -1, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_191"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_191"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, 12, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 149 }, new List<short> { 152 }, -1, new List<ShortList>(), -1, new List<short> { 180 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_191"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(192, LocalStringManager.GetConfig("BuildingBlock_language", "Name_192"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_192"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_192"), "SectSpecial/3304_sanqingdian", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Taoism, 1, canOpenManageOutTaiwu: false, 1, "414f8a", new ushort[8] { 0, 1000, 0, 2000, 0, 5000, 10000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 189 }, new List<short>(), 12, -1, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_192"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_192"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 0, -50, new List<short> { 150 }, new List<short> { 153 }, -1, new List<ShortList>(), -1, new List<short> { 158 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_192"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(193, LocalStringManager.GetConfig("BuildingBlock_language", "Name_193"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_193"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_193"), "SectSpecial/3305_biguya", "Func_LiveSkill12", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Taoism, 1, canOpenManageOutTaiwu: false, 1, "414f8a", new ushort[8] { 0, 1000, 0, 2000, 0, 5000, 0, 1000 }, 50, 50, new sbyte[7], 208, new List<short> { 189, 4 }, new List<short>(), 12, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_193"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_193"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 12, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 198 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_193"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(194, LocalStringManager.GetConfig("BuildingBlock_language", "Name_194"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_194"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_194"), "SectSpecial/3306_zhaoyuandong", "Func_LiveSkill12", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Taoism, 1, canOpenManageOutTaiwu: false, 1, "414f8a", new ushort[8] { 0, 3000, 0, 5000, 2000, 10000, 0, 5000 }, 50, 50, new sbyte[7], 209, new List<short> { 189, 18 }, new List<short>(), 12, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_194"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_194"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 12, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 214 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_194"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(195, LocalStringManager.GetConfig("BuildingBlock_language", "Name_195"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_195"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_195"), "SectSpecial/3307_danfang", "Func_Special", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Taoism, 1, canOpenManageOutTaiwu: false, 1, "414f8a", new ushort[8] { 0, 2500, 0, 7500, 5000, 15000, 0, 15000 }, 50, 50, new sbyte[7], 210, new List<short> { 189 }, new List<short>(), 12, -1, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_195"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_195"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 1000)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 229 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_195"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(196, LocalStringManager.GetConfig("BuildingBlock_language", "Name_196"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_196"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_196"), "SectSpecial/1022_chanfang", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Buddhism, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8] { 0, 1000, 0, 0, 1500, 500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 197, 198, 199, 200, 201, 202 }, 13, -1, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_196"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_196"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 250, mustMaintenance: false, isUnique: false, 0, 13, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 130 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_196"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(197, LocalStringManager.GetConfig("BuildingBlock_language", "Name_197"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_197"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_197"), "SectSpecial/3402_siyuan", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Buddhism, 1, canOpenManageOutTaiwu: false, 1, "33393f", new ushort[8] { 0, 1000, 0, 0, 2500, 500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 196 }, new List<short>(), 13, -1, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_197"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_197"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, -50, new List<short> { 154 }, new List<short> { 157 }, -1, new List<ShortList>(), -1, new List<short> { 149 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_197"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(198, LocalStringManager.GetConfig("BuildingBlock_language", "Name_198"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_198"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_198"), "SectSpecial/3403_fota", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Buddhism, 1, canOpenManageOutTaiwu: false, 1, "33393f", new ushort[8] { 0, 3000, 0, 0, 5000, 2000, 0, 2500 }, 50, 50, new sbyte[7], 211, new List<short> { 196 }, new List<short>(), 13, -1, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_198"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_198"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, 12, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 155 }, new List<short> { 158 }, -1, new List<ShortList>(), -1, new List<short> { 181 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_198"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(199, LocalStringManager.GetConfig("BuildingBlock_language", "Name_199"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_199"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_199"), "SectSpecial/3404_fatang", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Buddhism, 1, canOpenManageOutTaiwu: false, 1, "33393f", new ushort[8] { 0, 2000, 0, 0, 5000, 1000, 10000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 196 }, new List<short>(), 13, -1, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_199"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_199"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 0, -50, new List<short> { 156 }, new List<short> { 159 }, -1, new List<ShortList>(), -1, new List<short> { 159 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_199"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(200, LocalStringManager.GetConfig("BuildingBlock_language", "Name_200"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_200"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_200"), "SectSpecial/3405_jianxingdong", "Func_LiveSkill13", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Buddhism, 1, canOpenManageOutTaiwu: false, 1, "33393f", new ushort[8] { 0, 2000, 0, 0, 5000, 1000, 0, 1000 }, 50, 50, new sbyte[7], 212, new List<short> { 196, 5 }, new List<short>(), 13, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_200"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_200"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 13, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 199 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_200"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(201, LocalStringManager.GetConfig("BuildingBlock_language", "Name_201"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_201"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_201"), "SectSpecial/3406_kurongtai", "Func_LiveSkill13", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Buddhism, 1, canOpenManageOutTaiwu: false, 1, "33393f", new ushort[8] { 0, 5000, 0, 2000, 10000, 3000, 0, 5000 }, 50, 50, new sbyte[7], 213, new List<short> { 196, 14 }, new List<short>(), 13, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_201"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_201"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 13, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 215 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_201"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(202, LocalStringManager.GetConfig("BuildingBlock_language", "Name_202"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_202"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_202"), "SectSpecial/3407_yuejingge", "Func_Special", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Buddhism, 1, canOpenManageOutTaiwu: false, 1, "33393f", new ushort[8] { 0, 7500, 0, 2500, 15000, 5000, 0, 15000 }, 50, 50, new sbyte[7], 214, new List<short> { 196 }, new List<short>(), 13, -1, 3, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_202"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_202"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 1000)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 5 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 230 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_202"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(203, LocalStringManager.GetConfig("BuildingBlock_language", "Name_203"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_203"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_203"), "SectSpecial/1023_shijiao", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Cooking, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8] { 2500, 500, 0, 0, 0, 0, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 204, 205, 206, 207, 208, 209, 210, 211, 212 }, 14, -1, 6, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_203"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_203"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(0, 10)
		}, 250, mustMaintenance: false, isUnique: false, 0, 14, -1, -1, -1, -1, canMakeItem: true, upgradeMakeItem: false, -1, new short[1], isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 131 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_203"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: true, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(204, LocalStringManager.GetConfig("BuildingBlock_language", "Name_204"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_204"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_204"), "SectSpecial/3502_jiulou", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Cooking, 1, canOpenManageOutTaiwu: false, 1, "815f47", new ushort[8] { 2500, 1500, 0, 0, 0, 1000, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 203 }, new List<short>(), 14, -1, 6, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_204"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_204"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(0, 20)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1], isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, 50, new List<short> { 160 }, new List<short> { 165 }, -1, new List<ShortList>(), -1, new List<short> { 141 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_204"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(205, LocalStringManager.GetConfig("BuildingBlock_language", "Name_205"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_205"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_205"), "SectSpecial/3503_baijiayan", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Cooking, 1, canOpenManageOutTaiwu: false, 1, "815f47", new ushort[8] { 5000, 2500, 0, 0, 0, 1500, 5000, 2500 }, 50, 50, new sbyte[7], 215, new List<short> { 203 }, new List<short>(), 14, -1, 6, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_205"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_205"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, 12, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1], isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 161 }, new List<short> { 166 }, -1, new List<ShortList>(), -1, new List<short> { 182 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_205"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(206, LocalStringManager.GetConfig("BuildingBlock_language", "Name_206"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_206"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_206"), "SectSpecial/3504_zhengyange", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Cooking, 1, canOpenManageOutTaiwu: false, 1, "815f47", new ushort[8] { 5000, 1500, 0, 0, 0, 500, 15000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 203 }, new List<short>(), 14, -1, 6, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_206"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_206"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(0, 100)
		}, 1000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1], isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 0, 50, new List<short> { 162 }, new List<short> { 167 }, -1, new List<ShortList>(), -1, new List<short> { 160 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_206"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(207, LocalStringManager.GetConfig("BuildingBlock_language", "Name_207"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_207"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_207"), "SectSpecial/3505_baishouyuan", "Func_LiveSkill14", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Cooking, 1, canOpenManageOutTaiwu: false, 1, "815f47", new ushort[8] { 5000, 2000, 0, 0, 0, 1000, 0, 1000 }, 50, 50, new sbyte[7], -1, new List<short> { 203, 10 }, new List<short>(), 14, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_207"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_207"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(0, 20)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 14, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 200 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_207"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(208, LocalStringManager.GetConfig("BuildingBlock_language", "Name_208"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_208"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_208"), "SectSpecial/3506_zaowangxuanding", "Func_LiveSkill14", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Cooking, 1, canOpenManageOutTaiwu: false, 1, "815f47", new ushort[8] { 12500, 5000, 0, 0, 0, 2500, 0, 5000 }, 50, 50, new sbyte[7], 216, new List<short> { 203, 12 }, new List<short>(), 14, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_208"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_208"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(0, 100)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 14, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 216 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_208"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(209, LocalStringManager.GetConfig("BuildingBlock_language", "Name_209"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_209"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_209"), "SectSpecial/3507_sijiyuan", "Func_GetMoreItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Cooking, 1, canOpenManageOutTaiwu: false, 1, "815f47", new ushort[8] { 20000, 10000, 0, 0, 0, 5000, 0, 7500 }, 50, 50, new sbyte[7], 217, new List<short> { 203, 9 }, new List<short>(), 14, -1, 6, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_209"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_209"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(0, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1], isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 163 }, new List<short> { 168 }, -1, new List<ShortList>(), -1, new List<short> { 243 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_209"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(210, LocalStringManager.GetConfig("BuildingBlock_language", "Name_210"), EBuildingBlockFuncType.Material, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_210"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_210"), "SectSpecial/3508_tianchengxiang", "Func_GetBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Cooking, 1, canOpenManageOutTaiwu: false, 1, "815f47", new ushort[8] { 20000, 10000, 0, 0, 0, 5000, 0, 7500 }, 50, 50, new sbyte[7], 218, new List<short> { 203, 9 }, new List<short>(), 14, -1, 6, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_210"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_210"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(0, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1], isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 164 }, new List<short> { 169 }, -1, new List<ShortList>(), -1, new List<short> { 244 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_210"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(211, LocalStringManager.GetConfig("BuildingBlock_language", "Name_211"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_211"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_211"), "SectSpecial/3509_xiangliaoguan", "Func_MakeBetterItem", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Cooking, 1, canOpenManageOutTaiwu: false, 1, "815f47", new ushort[8] { 55000, 15000, 0, 0, 0, 10000, 0, 35000 }, 50, 50, new sbyte[7], 219, new List<short> { 203 }, new List<short>(), 14, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_211"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_211"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(0, 200)
		}, 15000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: true, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_211"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(212, LocalStringManager.GetConfig("BuildingBlock_language", "Name_212"), EBuildingBlockFuncType.Make, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_212"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_212"), "SectSpecial/3510_longgong", "Func_ReduceRequirement", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Cooking, 1, canOpenManageOutTaiwu: false, 1, "815f47", new ushort[8] { 25000, 7500, 0, 0, 0, 2500, 25000, 15000 }, 50, 50, new sbyte[7], 220, new List<short> { 203, 20 }, new List<short>(), 14, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_212"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_212"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(0, 100)
		}, 5000, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, 14, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 224 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_212"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(213, LocalStringManager.GetConfig("BuildingBlock_language", "Name_213"), EBuildingBlockFuncType.Reading, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_213"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_213"), "SectSpecial/1024_changjie", null, haveDynamicIcon: true, EBuildingBlockType.Building, EBuildingBlockClass.Eclectic, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8] { 500, 500, 500, 500, 500, 500, 0, 0 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short> { 214, 215, 216, 217, 218, 219, 220, 221, 222, 223 }, 15, -1, 2, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_213"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_213"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 20, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 250, mustMaintenance: false, isUnique: false, 0, 15, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 3 }, isShop: true, needLeader: true, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 132 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_213"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(214, LocalStringManager.GetConfig("BuildingBlock_language", "Name_214"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_214"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_214"), "SectSpecial/3602_shiji", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Eclectic, 1, canOpenManageOutTaiwu: false, 1, "bababa", new ushort[8] { 500, 500, 500, 500, 500, 500, 5000, 500 }, 50, 50, new sbyte[7], -1, new List<short> { 213 }, new List<short>(), 15, -1, 2, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_214"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_214"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 3 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, 50, new List<short> { 170 }, new List<short> { 178 }, -1, new List<ShortList>(), -1, new List<short> { 142 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_214"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(215, LocalStringManager.GetConfig("BuildingBlock_language", "Name_215"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_215"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_215"), "SectSpecial/3603_dufang", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Eclectic, 1, canOpenManageOutTaiwu: false, 1, "bababa", new ushort[8] { 750, 750, 750, 750, 750, 750, 2500, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 213 }, new List<short>(), 15, -1, 2, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_215"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_215"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 3 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, 50, new List<short> { 171 }, new List<short> { 179 }, -1, new List<ShortList>(), -1, new List<short> { 151 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_215"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(216, LocalStringManager.GetConfig("BuildingBlock_language", "Name_216"), EBuildingBlockFuncType.Money, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_216"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_216"), "SectSpecial/3604_qinglou", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Eclectic, 1, canOpenManageOutTaiwu: false, 1, "bababa", new ushort[8] { 750, 750, 750, 750, 750, 750, 0, 250 }, 50, 50, new sbyte[7], -1, new List<short> { 213 }, new List<short>(), 15, -1, 2, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_216"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_216"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 500, 500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 50)
		}, 500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 3 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: true, 800, 0, 50, new List<short> { 172 }, new List<short> { 180 }, -1, new List<ShortList>(), -1, new List<short> { 150 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_216"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(217, LocalStringManager.GetConfig("BuildingBlock_language", "Name_217"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_217"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_217"), "SectSpecial/3605_huafang", "Func_GetMoney1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Eclectic, 1, canOpenManageOutTaiwu: false, 1, "bababa", new ushort[8] { 2000, 0, 2000, 2000, 2000, 0, 10000, 2500 }, 50, 50, new sbyte[7], 221, new List<short> { 213, 1 }, new List<short>(), 15, -1, 2, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_217"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_217"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, 9
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 3 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 173 }, new List<short> { 181 }, -1, new List<ShortList>(), -1, new List<short> { 183 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_217"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(218, LocalStringManager.GetConfig("BuildingBlock_language", "Name_218"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_218"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_218"), "SectSpecial/3606_goulanwashe", "Func_GetVillager", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Eclectic, 1, canOpenManageOutTaiwu: false, 1, "bababa", new ushort[8] { 2000, 0, 2000, 2000, 2000, 0, 10000, 2500 }, 50, 50, new sbyte[7], 222, new List<short> { 213 }, new List<short>(), 15, -1, 2, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_218"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_218"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, 12
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 50)
		}, 2500, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 3 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 174 }, new List<short> { 182 }, -1, new List<ShortList>(), -1, new List<short> { 184 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_218"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(219, LocalStringManager.GetConfig("BuildingBlock_language", "Name_219"), EBuildingBlockFuncType.Authority, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_219"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_219"), "SectSpecial/3607_youyuan", "Func_GetAuthority1", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Eclectic, 1, canOpenManageOutTaiwu: false, 1, "bababa", new ushort[8] { 1500, 1500, 1500, 1500, 1500, 1500, 5000, 0 }, 50, 50, new sbyte[7], -1, new List<short> { 213 }, new List<short>(), 15, -1, 2, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_219"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_219"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 1000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 3 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 175 }, new List<short> { 183 }, -1, new List<ShortList>(), -1, new List<short> { 161 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_219"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(220, LocalStringManager.GetConfig("BuildingBlock_language", "Name_220"), EBuildingBlockFuncType.Qualification, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_220"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_220"), "SectSpecial/3608_dayouyuan", "Func_LiveSkill15", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Eclectic, 1, canOpenManageOutTaiwu: false, 1, "bababa", new ushort[8] { 1000, 1000, 1000, 1000, 1000, 1000, 10000, 1000 }, 50, 50, new sbyte[7], 223, new List<short> { 213, 7 }, new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_220"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_220"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 100)
		}, 500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, -1, 15, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 201 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_220"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(221, LocalStringManager.GetConfig("BuildingBlock_language", "Name_221"), EBuildingBlockFuncType.Attainment, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_221"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_221"), "SectSpecial/3609_miaopu", "Func_LiveSkill15", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Eclectic, 1, canOpenManageOutTaiwu: false, 1, "bababa", new ushort[8] { 2500, 2500, 2500, 2500, 2500, 2500, 25000, 5000 }, 50, 50, new sbyte[7], 224, new List<short> { 213, 15 }, new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_221"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_221"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 750, 750 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 500)
		}, 2500, mustMaintenance: false, isUnique: true, 0, -1, -1, -1, 15, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, new List<short> { 217 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_221"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(222, LocalStringManager.GetConfig("BuildingBlock_language", "Name_222"), EBuildingBlockFuncType.Item, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_222"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_222"), "SectSpecial/3610_dangpu", "Func_GetMoney2", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Eclectic, 1, canOpenManageOutTaiwu: false, 1, "bababa", new ushort[8] { 5000, 5000, 5000, 5000, 5000, 5000, 50000, 15000 }, 50, 50, new sbyte[7], -1, new List<short> { 213 }, new List<short>(), 15, -1, 2, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_222"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_222"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(6, 1000)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 3 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: true, showItemStoreLocation: true, showItemLocationAsResourceLocation: false, 1600, 0, 0, new List<short> { 176 }, new List<short> { 184 }, -1, new List<ShortList>(), -1, new List<short> { 245 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_222"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(223, LocalStringManager.GetConfig("BuildingBlock_language", "Name_223"), EBuildingBlockFuncType.People, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_223"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_223"), "SectSpecial/3611_xianshiguan", "Func_GetAuthority2", haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Eclectic, 1, canOpenManageOutTaiwu: false, 1, "bababa", new ushort[8] { 5000, 5000, 5000, 5000, 5000, 5000, 50000, 15000 }, 50, 50, new sbyte[7], -1, new List<short> { 213 }, new List<short>(), 15, -1, 2, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_223"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_223"), new short[16]
		{
			9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
			9, 9, 9, 9, 9, 9
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, 1500 }, 10, new List<ResourceInfo>
		{
			new ResourceInfo(7, 100)
		}, 5000, mustMaintenance: false, isUnique: false, 0, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, new short[1] { 3 }, isShop: true, needLeader: true, needShopProgress: true, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, 4800, 0, 0, new List<short> { 177 }, new List<short> { 185 }, -1, new List<ShortList>(), -1, new List<short> { 185 }, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_223"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(224, LocalStringManager.GetConfig("BuildingBlock_language", "Name_224"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_224"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_224"), "Main/30001_jingcheng", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_224"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_224"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_224"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(225, LocalStringManager.GetConfig("BuildingBlock_language", "Name_225"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_225"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_225"), "Main/30002_chengdu", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_225"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_225"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_225"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(226, LocalStringManager.GetConfig("BuildingBlock_language", "Name_226"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_226"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_226"), "Main/30003_guizhou", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_226"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_226"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_226"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(227, LocalStringManager.GetConfig("BuildingBlock_language", "Name_227"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_227"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_227"), "Main/30004_xiangyang", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_227"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_227"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_227"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(228, LocalStringManager.GetConfig("BuildingBlock_language", "Name_228"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_228"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_228"), "Main/30005_taiyuan", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_228"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_228"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_228"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(229, LocalStringManager.GetConfig("BuildingBlock_language", "Name_229"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_229"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_229"), "Main/30006_guangzhou", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_229"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_229"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_229"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(230, LocalStringManager.GetConfig("BuildingBlock_language", "Name_230"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_230"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_230"), "Main/30007_qingzhou", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_230"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_230"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_230"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(231, LocalStringManager.GetConfig("BuildingBlock_language", "Name_231"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_231"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_231"), "Main/30008_jiangling", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_231"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_231"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_231"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(232, LocalStringManager.GetConfig("BuildingBlock_language", "Name_232"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_232"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_232"), "Main/30009_fuzhou", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_232"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_232"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_232"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(233, LocalStringManager.GetConfig("BuildingBlock_language", "Name_233"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_233"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_233"), "Main/30010_liaoyang", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_233"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_233"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_233"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(234, LocalStringManager.GetConfig("BuildingBlock_language", "Name_234"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_234"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_234"), "Main/30011_qinzhou", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_234"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_234"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_234"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(235, LocalStringManager.GetConfig("BuildingBlock_language", "Name_235"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_235"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_235"), "Main/30012_dali", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_235"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_235"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_235"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(236, LocalStringManager.GetConfig("BuildingBlock_language", "Name_236"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_236"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_236"), "Main/30013_shouchun", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_236"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_236"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_236"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(237, LocalStringManager.GetConfig("BuildingBlock_language", "Name_237"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_237"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_237"), "Main/30014_hangzhou", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_237"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_237"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_237"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(238, LocalStringManager.GetConfig("BuildingBlock_language", "Name_238"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_238"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_238"), "Main/30015_yangzhou", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_238"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_238"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_238"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(239, LocalStringManager.GetConfig("BuildingBlock_language", "Name_239"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_239"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_239"), "Main/31001_shaolinsi", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_239"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_239"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_239"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new BuildingBlockItem(240, LocalStringManager.GetConfig("BuildingBlock_language", "Name_240"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_240"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_240"), "Main/31002_emeipai", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_240"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_240"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_240"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(241, LocalStringManager.GetConfig("BuildingBlock_language", "Name_241"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_241"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_241"), "Main/31003_baihuagu", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_241"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_241"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_241"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(242, LocalStringManager.GetConfig("BuildingBlock_language", "Name_242"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_242"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_242"), "Main/31004_wudangpai", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_242"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_242"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_242"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(243, LocalStringManager.GetConfig("BuildingBlock_language", "Name_243"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_243"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_243"), "Main/31005_daxiaoyuanshan", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_243"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_243"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_243"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(244, LocalStringManager.GetConfig("BuildingBlock_language", "Name_244"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_244"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_244"), "Main/31006_shixiangmen", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_244"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_244"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_244"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(245, LocalStringManager.GetConfig("BuildingBlock_language", "Name_245"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_245"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_245"), "Main/31007_ranshanpai", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_245"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_245"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_245"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(246, LocalStringManager.GetConfig("BuildingBlock_language", "Name_246"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_246"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_246"), "Main/31008_xuannvfeng", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_246"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_246"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_246"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(247, LocalStringManager.GetConfig("BuildingBlock_language", "Name_247"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_247"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_247"), "Main/31009_zhujianshanzhuang", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_247"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_247"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_247"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(248, LocalStringManager.GetConfig("BuildingBlock_language", "Name_248"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_248"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_248"), "Main/31010_kongsangpai", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_248"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_248"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_248"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(249, LocalStringManager.GetConfig("BuildingBlock_language", "Name_249"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_249"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_249"), "Main/31011_wuliangjingangzong", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_249"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_249"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_249"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(250, LocalStringManager.GetConfig("BuildingBlock_language", "Name_250"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_250"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_250"), "Main/31012_wuxianjiao", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_250"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_250"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_250"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(251, LocalStringManager.GetConfig("BuildingBlock_language", "Name_251"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_251"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_251"), "Main/31013_jieqingya", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_251"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_251"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_251"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(252, LocalStringManager.GetConfig("BuildingBlock_language", "Name_252"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_252"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_252"), "Main/31014_fulongtan", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_252"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_252"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_252"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(253, LocalStringManager.GetConfig("BuildingBlock_language", "Name_253"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_253"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_253"), "Main/31015_xuehoujiao", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_253"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_253"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_253"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(254, LocalStringManager.GetConfig("BuildingBlock_language", "Name_254"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_254"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_254"), "Main/32001_cunzhuang", null, haveDynamicIcon: false, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_254"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_254"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_254"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(255, LocalStringManager.GetConfig("BuildingBlock_language", "Name_255"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_255"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_255"), "Main/32002_shizhen", null, haveDynamicIcon: false, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_255"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_255"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_255"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(256, LocalStringManager.GetConfig("BuildingBlock_language", "Name_256"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_256"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_256"), "Main/32003_guanzhai", null, haveDynamicIcon: false, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_256"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_256"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_256"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(257, LocalStringManager.GetConfig("BuildingBlock_language", "Name_257"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_257"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_257"), "Main/40001_zhulu", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_257"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_257"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: true, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_257"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(258, LocalStringManager.GetConfig("BuildingBlock_language", "Name_258"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_258"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_258"), "Main/40001_zhulu", null, haveDynamicIcon: true, EBuildingBlockType.MainBuilding, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8] { 0, 100, 0, 0, 0, 0, 0, 0 }, 0, -1, new sbyte[7], 228, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_258"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_258"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: true, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_258"), -1, new string[2] { "ui9_buildingarea_namebase_0_5", "ui9_buildingarea_namebase_1_5" }, new string[2] { "buildingarea_industry_icon_4", "buildingarea_industry_base_4" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(259, LocalStringManager.GetConfig("BuildingBlock_language", "Name_259"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_259"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_259"), "SectSpecial/50001_cangjingge", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_259"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_259"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_259"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(260, LocalStringManager.GetConfig("BuildingBlock_language", "Name_260"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_260"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_260"), "SectSpecial/50002_jinding", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_260"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_260"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_260"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(261, LocalStringManager.GetConfig("BuildingBlock_language", "Name_261"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_261"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_261"), "SectSpecial/50003_bailutan", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_261"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_261"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_261"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(262, LocalStringManager.GetConfig("BuildingBlock_language", "Name_262"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_262"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_262"), "SectSpecial/50004_qixingtai", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_262"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_262"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_262"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(263, LocalStringManager.GetConfig("BuildingBlock_language", "Name_263"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_263"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_263"), "SectSpecial/50005_yuanshanshilao", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_263"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_263"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_263"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(264, LocalStringManager.GetConfig("BuildingBlock_language", "Name_264"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_264"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_264"), "SectSpecial/50006_shiwanglei", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_264"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_264"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_264"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(265, LocalStringManager.GetConfig("BuildingBlock_language", "Name_265"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_265"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_265"), "SectSpecial/50007_qinglangge", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_265"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_265"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_265"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(266, LocalStringManager.GetConfig("BuildingBlock_language", "Name_266"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_266"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_266"), "SectSpecial/50008_yimingjue", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_266"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_266"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_266"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(267, LocalStringManager.GetConfig("BuildingBlock_language", "Name_267"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_267"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_267"), "SectSpecial/50009_zushijianlu", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_267"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_267"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_267"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(268, LocalStringManager.GetConfig("BuildingBlock_language", "Name_268"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_268"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_268"), "SectSpecial/50010_yaowanglu", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_268"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_268"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_268"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(269, LocalStringManager.GetConfig("BuildingBlock_language", "Name_269"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_269"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_269"), "SectSpecial/50011_jingangzunxiang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_269"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_269"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_269"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(270, LocalStringManager.GetConfig("BuildingBlock_language", "Name_270"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_270"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_270"), "SectSpecial/50012_wuduyugu", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_270"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_270"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_270"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(271, LocalStringManager.GetConfig("BuildingBlock_language", "Name_271"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_271"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_271"), "SectSpecial/50013_wushengyuan", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_271"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_271"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_271"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(272, LocalStringManager.GetConfig("BuildingBlock_language", "Name_272"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_272"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_272"), "SectSpecial/50014_jinlongdian", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_272"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_272"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_272"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(273, LocalStringManager.GetConfig("BuildingBlock_language", "Name_273"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_273"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_273"), "SectSpecial/50015_xuechi", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_273"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_273"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_273"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(274, LocalStringManager.GetConfig("BuildingBlock_language", "Name_274"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_274"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_274"), "SectSpecial/50016_damoshelita", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: false, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_274"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_274"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_274"), -1, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(275, LocalStringManager.GetConfig("BuildingBlock_language", "Name_275"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_275"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_275"), "Main/gang_qiwenxingtai", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8] { 10000, 10000, 10000, 10000, 10000, 10000, 10000, 5000 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_275"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_275"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_275"), 13, new string[2] { "ui9_buildingarea_namebase_0_8", "ui9_buildingarea_namebase_1_8" }, new string[2] { "buildingarea_industry_icon_5", "buildingarea_industry_base_5" }, artisanOrderAvailable: false, 0, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 300, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(276, LocalStringManager.GetConfig("BuildingBlock_language", "Name_276"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_276"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_276"), "Merchant/40004_funiubang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_276"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_276"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), 0, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_276"), -1, new string[2] { "ui9_buildingarea_namebase_0_4", "ui9_buildingarea_namebase_1_4" }, new string[2] { "buildingarea_industry_icon_3", "buildingarea_industry_base_3" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(277, LocalStringManager.GetConfig("BuildingBlock_language", "Name_277"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_277"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_277"), "Merchant/40005_wensanshuhaige", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_277"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_277"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), 1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_277"), -1, new string[2] { "ui9_buildingarea_namebase_0_4", "ui9_buildingarea_namebase_1_4" }, new string[2] { "buildingarea_industry_icon_3", "buildingarea_industry_base_3" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(278, LocalStringManager.GetConfig("BuildingBlock_language", "Name_278"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_278"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_278"), "Merchant/40006_wuhushanghui", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_278"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_278"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), 2, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_278"), -1, new string[2] { "ui9_buildingarea_namebase_0_4", "ui9_buildingarea_namebase_1_4" }, new string[2] { "buildingarea_industry_icon_3", "buildingarea_industry_base_3" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(279, LocalStringManager.GetConfig("BuildingBlock_language", "Name_279"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_279"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_279"), "Merchant/40007_dawukui", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_279"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_279"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), 3, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_279"), -1, new string[2] { "ui9_buildingarea_namebase_0_4", "ui9_buildingarea_namebase_1_4" }, new string[2] { "buildingarea_industry_icon_3", "buildingarea_industry_base_3" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(280, LocalStringManager.GetConfig("BuildingBlock_language", "Name_280"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_280"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_280"), "Merchant/40008_huichuntang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_280"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_280"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), 4, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_280"), -1, new string[2] { "ui9_buildingarea_namebase_0_4", "ui9_buildingarea_namebase_1_4" }, new string[2] { "buildingarea_industry_icon_3", "buildingarea_industry_base_3" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(281, LocalStringManager.GetConfig("BuildingBlock_language", "Name_281"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_281"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_281"), "Merchant/40009_gongshufang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_281"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_281"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), 5, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_281"), -1, new string[2] { "ui9_buildingarea_namebase_0_4", "ui9_buildingarea_namebase_1_4" }, new string[2] { "buildingarea_industry_icon_3", "buildingarea_industry_base_3" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(282, LocalStringManager.GetConfig("BuildingBlock_language", "Name_282"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_282"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_282"), "Merchant/40010_qihuozai", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_282"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_282"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), 6, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_282"), -1, new string[2] { "ui9_buildingarea_namebase_0_4", "ui9_buildingarea_namebase_1_4" }, new string[2] { "buildingarea_industry_icon_3", "buildingarea_industry_base_3" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(283, LocalStringManager.GetConfig("BuildingBlock_language", "Name_283"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_283"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_283"), "Merchant/40006_wuhushanghui", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_283"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_283"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: true, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), 2, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_283"), -1, new string[2] { "ui9_buildingarea_namebase_0_4", "ui9_buildingarea_namebase_1_4" }, new string[2] { "buildingarea_industry_icon_3", "buildingarea_industry_base_3" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(284, LocalStringManager.GetConfig("BuildingBlock_language", "Name_284"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_284"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_284"), "SettlementTreasury/Icon_Buildingblock_TreasuryZhucheng", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_284"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_284"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_284"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(285, LocalStringManager.GetConfig("BuildingBlock_language", "Name_285"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_285"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_285"), "SettlementTreasury/Icon_Buildingblock_TreasuryShizhen", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_285"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_285"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_285"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(286, LocalStringManager.GetConfig("BuildingBlock_language", "Name_286"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_286"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_286"), "SettlementTreasury/Icon_Buildingblock_TreasuryCunzhuang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_286"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_286"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_286"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(287, LocalStringManager.GetConfig("BuildingBlock_language", "Name_287"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_287"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_287"), "SettlementTreasury/Icon_Buildingblock_TreasuryGuanzhai", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_287"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_287"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_287"), -1, new string[2] { "ui9_buildingarea_namebase_0_4", "ui9_buildingarea_namebase_1_4" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(288, LocalStringManager.GetConfig("BuildingBlock_language", "Name_288"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_288"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_288"), "SettlementTreasury/Icon_Buildingblock_TreasuryShaolin", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_288"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_288"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_288"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(289, LocalStringManager.GetConfig("BuildingBlock_language", "Name_289"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_289"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_289"), "SettlementTreasury/Icon_Buildingblock_TreasuryEmei", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_289"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_289"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_289"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(290, LocalStringManager.GetConfig("BuildingBlock_language", "Name_290"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_290"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_290"), "SettlementTreasury/Icon_Buildingblock_TreasuryBaihua", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_290"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_290"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_290"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(291, LocalStringManager.GetConfig("BuildingBlock_language", "Name_291"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_291"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_291"), "SettlementTreasury/Icon_Buildingblock_TreasuryWudang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_291"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_291"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_291"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(292, LocalStringManager.GetConfig("BuildingBlock_language", "Name_292"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_292"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_292"), "SettlementTreasury/Icon_Buildingblock_TreasuryYuanshan", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_292"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_292"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_292"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(293, LocalStringManager.GetConfig("BuildingBlock_language", "Name_293"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_293"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_293"), "SettlementTreasury/Icon_Buildingblock_TreasuryShixiang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_293"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_293"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_293"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(294, LocalStringManager.GetConfig("BuildingBlock_language", "Name_294"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_294"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_294"), "SettlementTreasury/Icon_Buildingblock_TreasuryRanshan", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_294"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_294"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_294"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(295, LocalStringManager.GetConfig("BuildingBlock_language", "Name_295"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_295"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_295"), "SettlementTreasury/Icon_Buildingblock_TreasuryXuannv", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_295"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_295"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_295"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(296, LocalStringManager.GetConfig("BuildingBlock_language", "Name_296"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_296"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_296"), "SettlementTreasury/Icon_Buildingblock_TreasuryZhujian", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_296"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_296"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_296"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(297, LocalStringManager.GetConfig("BuildingBlock_language", "Name_297"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_297"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_297"), "SettlementTreasury/Icon_Buildingblock_TreasuryKongsang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_297"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_297"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_297"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(298, LocalStringManager.GetConfig("BuildingBlock_language", "Name_298"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_298"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_298"), "SettlementTreasury/Icon_Buildingblock_TreasuryJingang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_298"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_298"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_298"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(299, LocalStringManager.GetConfig("BuildingBlock_language", "Name_299"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_299"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_299"), "SettlementTreasury/Icon_Buildingblock_TreasuryWuxian", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_299"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_299"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_299"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new BuildingBlockItem(300, LocalStringManager.GetConfig("BuildingBlock_language", "Name_300"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_300"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_300"), "SettlementTreasury/Icon_Buildingblock_TreasuryJieqing", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_300"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_300"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_300"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(301, LocalStringManager.GetConfig("BuildingBlock_language", "Name_301"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_301"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_301"), "SettlementTreasury/Icon_Buildingblock_TreasuryFulong", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_301"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_301"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_301"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(302, LocalStringManager.GetConfig("BuildingBlock_language", "Name_302"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_302"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_302"), "SettlementTreasury/Icon_Buildingblock_TreasuryXuehou", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_302"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_302"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_302"), -1, new string[2] { "ui9_buildingarea_namebase_0_6", "ui9_buildingarea_namebase_1_6" }, new string[2] { "buildingarea_industry_icon_1", "buildingarea_industry_base_1" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(303, LocalStringManager.GetConfig("BuildingBlock_language", "Name_303"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_303"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_303"), "SettlementPrison/Icon_Buildingblock_PrisonShaolin", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_303"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_303"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_303"), 1, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(304, LocalStringManager.GetConfig("BuildingBlock_language", "Name_304"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_304"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_304"), "SettlementPrison/Icon_Buildingblock_PrisonEmei", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_304"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_304"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_304"), 2, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(305, LocalStringManager.GetConfig("BuildingBlock_language", "Name_305"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_305"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_305"), "SettlementPrison/Icon_Buildingblock_PrisonBaihua", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_305"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_305"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_305"), 3, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(306, LocalStringManager.GetConfig("BuildingBlock_language", "Name_306"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_306"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_306"), "SettlementPrison/Icon_Buildingblock_PrisonWudang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_306"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_306"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_306"), 4, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(307, LocalStringManager.GetConfig("BuildingBlock_language", "Name_307"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_307"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_307"), "SettlementPrison/Icon_Buildingblock_PrisonYuanshan", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_307"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_307"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_307"), 5, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(308, LocalStringManager.GetConfig("BuildingBlock_language", "Name_308"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_308"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_308"), "SettlementPrison/Icon_Buildingblock_PrisonShixiang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_308"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_308"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_308"), 6, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(309, LocalStringManager.GetConfig("BuildingBlock_language", "Name_309"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_309"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_309"), "SettlementPrison/Icon_Buildingblock_PrisonRanshan", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_309"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_309"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_309"), 7, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(310, LocalStringManager.GetConfig("BuildingBlock_language", "Name_310"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_310"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_310"), "SettlementPrison/Icon_Buildingblock_PrisonXuannv", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_310"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_310"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_310"), 8, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(311, LocalStringManager.GetConfig("BuildingBlock_language", "Name_311"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_311"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_311"), "SettlementPrison/Icon_Buildingblock_PrisonZhujian", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_311"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_311"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_311"), 9, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(312, LocalStringManager.GetConfig("BuildingBlock_language", "Name_312"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_312"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_312"), "SettlementPrison/Icon_Buildingblock_PrisonKongsang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_312"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_312"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_312"), 10, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(313, LocalStringManager.GetConfig("BuildingBlock_language", "Name_313"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_313"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_313"), "SettlementPrison/Icon_Buildingblock_PrisonJingang", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_313"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_313"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_313"), 11, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(314, LocalStringManager.GetConfig("BuildingBlock_language", "Name_314"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_314"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_314"), "SettlementPrison/Icon_Buildingblock_PrisonWuxian", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_314"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_314"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_314"), 12, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(315, LocalStringManager.GetConfig("BuildingBlock_language", "Name_315"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_315"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_315"), "SettlementPrison/Icon_Buildingblock_PrisonJieqing", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_315"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_315"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_315"), 13, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(316, LocalStringManager.GetConfig("BuildingBlock_language", "Name_316"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_316"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_316"), "SettlementPrison/Icon_Buildingblock_PrisonFulong", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_316"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_316"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_316"), 14, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(317, LocalStringManager.GetConfig("BuildingBlock_language", "Name_317"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_317"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_317"), "SettlementPrison/Icon_Buildingblock_PrisonXuehou", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Static, 1, canOpenManageOutTaiwu: true, 1, null, new ushort[8], 0, -1, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_317"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_317"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { -1, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: false, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_317"), 15, new string[2] { "ui9_buildingarea_namebase_0_7", "ui9_buildingarea_namebase_1_7" }, new string[2] { "buildingarea_industry_icon_2", "buildingarea_industry_base_2" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 0u, null, null));
		_dataArray.Add(new BuildingBlockItem(318, LocalStringManager.GetConfig("BuildingBlock_language", "Name_318"), EBuildingBlockFuncType.Other, LocalStringManager.GetConfig("BuildingBlock_language", "Desc_318"), LocalStringManager.GetConfig("BuildingBlock_language", "FuncDesc_318"), "TaiwuAsXiangshu/XiangshuTower", null, haveDynamicIcon: false, EBuildingBlockType.Building, EBuildingBlockClass.Villiage, 1, canOpenManageOutTaiwu: true, 2, null, new ushort[8] { 0, 0, 0, 0, 0, 0, 0, 50000 }, 50, 50, new sbyte[7], -1, new List<short>(), new List<short>(), 15, -1, -1, LocalStringManager.GetConfig("BuildingBlock_language", "LeaderName_318"), LocalStringManager.GetConfig("BuildingBlock_language", "MemberName_318"), new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[2] { 1500, -1 }, -1, new List<ResourceInfo>(), -1, mustMaintenance: false, isUnique: true, -1, -1, -1, -1, -1, -1, canMakeItem: false, upgradeMakeItem: false, -1, null, isShop: false, needLeader: false, needShopProgress: false, isCollectResourceBuilding: false, showResourceStoreLocation: false, showItemStoreLocation: false, showItemLocationAsResourceLocation: false, -1, 0, 0, new List<short>(), new List<short>(), -1, new List<ShortList>(), -1, null, LocalStringManager.GetConfig("BuildingBlock_language", "EffectDesc_318"), -1, new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" }, new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" }, artisanOrderAvailable: false, 0, new List<short>(), 0, 5093790u, "TaiwuAsXiangshu/building_block", new short[2] { 0, 30 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<BuildingBlockItem>(319);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
	}
}
