using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleFormula : ConfigData<VillagerRoleFormulaItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 农户自动采集次数
		/// </summary>
		public const int FarmerAutoCollectActionCount = 0;

		/// <summary>
		/// 农户自动采集数量
		/// </summary>
		public const int FarmerAutoCollectActionResult = 1;

		/// <summary>
		/// 农户迁移心材成功率
		/// </summary>
		public const int FarmerMigrateResourceSuccessRate = 2;

		/// <summary>
		/// 农户迁移心材额外成功率
		/// </summary>
		public const int FarmerMigrateResourceExtraSuccessRate = 3;

		/// <summary>
		/// 农户元鸡心材升级几率
		/// </summary>
		public const int FarmerChickenUpgradeBuildingCoreRate = 4;

		/// <summary>
		/// 大夫可互动人物品级
		/// </summary>
		public const int DoctorInteractTargetGrade = 5;

		/// <summary>
		/// 大夫可互动最高品级
		/// </summary>
		public const int DoctorInteractTargetMaxGrade = 6;

		/// <summary>
		/// 大夫自动威望收入基础
		/// </summary>
		public const int DoctorAutoActionAuthorityIncome = 7;

		/// <summary>
		/// 大夫自动威望收入浮动
		/// </summary>
		public const int DoctorAutoActionAuthorityIncomeAdjust = 8;

		/// <summary>
		/// 大夫派遣恩义收入
		/// </summary>
		public const int DoctorWorkSpiritualDebtIncome = 9;

		/// <summary>
		/// 大夫元鸡降低入魔值量
		/// </summary>
		public const int DoctorChickenUpgradeInfectionChangeAmount = 10;

		/// <summary>
		/// 大夫行为目标状态门槛
		/// </summary>
		public const int DoctorCureRequirement = 11;

		/// <summary>
		/// 使者自动行为影响人数
		/// </summary>
		public const int VillageHeadAutoActionAffectCount = 12;

		/// <summary>
		/// 使者自动行为好感变化
		/// </summary>
		public const int VillageHeadAutoActionFavorChange = 13;

		/// <summary>
		/// 使者自动行为好感增加概率
		/// </summary>
		public const int VillageHeadAutoActionFavorIncreaseRate = 14;

		/// <summary>
		/// 使者派遣行为调控范围
		/// </summary>
		public const int VillageHeadWorkChangeRuleRange = 15;

		/// <summary>
		/// 使者派遣行为超常数量
		/// </summary>
		public const int VillageHeadWorkSpecialRuleCount = 16;

		/// <summary>
		/// 使者派遣行为每月威望消耗
		/// </summary>
		public const int VillageHeadWorkMonthlyAuthorityCost = 17;

		/// <summary>
		/// 使者元鸡效果结成关系几率
		/// </summary>
		public const int VillageHeadChickenUpgradeActionChance = 18;

		/// <summary>
		/// 文人自动行为影响的人数
		/// </summary>
		public const int LiteratiAutoActionInfluenceCount = 19;

		/// <summary>
		/// 文人自动行为变化的心情
		/// </summary>
		public const int LiteratiAutoActionHappinessChange = 20;

		/// <summary>
		/// 文人派遣行为可进行的次数
		/// </summary>
		public const int LiteratiWorkUsableCount = 21;

		/// <summary>
		/// 文人派遣行为影响的量
		/// </summary>
		public const int LiteratiWorkEffectiveValue = 22;

		/// <summary>
		/// 文人元鸡影响的人数
		/// </summary>
		public const int LiteratiChickenInfluenceCount = 23;

		/// <summary>
		/// 文人元鸡变化的好感
		/// </summary>
		public const int LiteratiChickenRelationChange = 24;

		/// <summary>
		/// 商人可互动人物品级
		/// </summary>
		public const int MerchantInteractTargetGrade = 25;

		/// <summary>
		/// 商人可互动最高品级
		/// </summary>
		public const int MerchantInteractTargetMaxGrade = 26;

		/// <summary>
		/// 商人自动银钱收入基础
		/// </summary>
		public const int MerchantAutoActionMoneyIncome = 27;

		/// <summary>
		/// 商人自动银钱收入浮动
		/// </summary>
		public const int MerchantAutoActionMoneyIncomeAdjust = 28;

		/// <summary>
		/// 商人自动银钱收入目标银钱门槛
		/// </summary>
		public const int MerchantAutoActionTargetMoneyRequirement = 29;

		/// <summary>
		/// 商人购买物品价格比例
		/// </summary>
		public const int MerchantBuyItemPriceRate = 30;

		/// <summary>
		/// 商人出售物品价格比例
		/// </summary>
		public const int MerchantSellItemPriceRate = 31;

		/// <summary>
		/// 商人元鸡增加地区商会总部好感
		/// </summary>
		public const int MerchantChickenIncreaseHeadMerchantFavor = 32;

		/// <summary>
		/// 商人元鸡增加地区商会分部好感
		/// </summary>
		public const int MerchantChickenIncreaseBranchMerchantFavor = 33;

		/// <summary>
		/// 护冢自动行为每月可消灭的数量
		/// </summary>
		public const int SwordTombKeeperAutoActionKOCount = 34;

		/// <summary>
		/// 护冢派遣行为入魔值每月增加
		/// </summary>
		public const int SwordTombKeeperWorkInfectAddPerMonth = 35;

		/// <summary>
		/// 护冢派遣行为收集几率
		/// </summary>
		public const int SwordTombKeeperWorkCollectOdd = 36;

		/// <summary>
		/// 护冢派遣行为受伤几率
		/// </summary>
		public const int SwordTombKeeperWorkHurtOdd = 37;

		/// <summary>
		/// 护冢派遣行为受伤数量
		/// </summary>
		public const int SwordTombKeeperWorkHurtCount = 38;

		/// <summary>
		/// 护冢派遣行为收集见闻时得到特性几率
		/// </summary>
		public const int SwordTombKeeperWorkFeatureOddWhenInformationCollect = 39;

		/// <summary>
		/// 护冢派遣行为被攻击时得到特性几率
		/// </summary>
		public const int SwordTombKeeperWorkFeatureOddWhenBeAttacked = 40;

		/// <summary>
		/// 护冢元鸡降低比例
		/// </summary>
		public const int SwordTombKeeperChickenDecreaseFactor = 41;

		/// <summary>
		/// 匠人自动修理次数
		/// </summary>
		public const int CraftsmanAutoRepairCount = 42;

		/// <summary>
		/// 匠人获得精制引子的几率
		/// </summary>
		public const int CraftsmanAutoGainRefineMaterialChance = 43;

		/// <summary>
		/// 匠人获得精制引子的品级
		/// </summary>
		public const int CraftsmanAutoGainRefineMaterialGrade = 44;

		/// <summary>
		/// 匠人元鸡效果增加精制引子的品级
		/// </summary>
		public const int CraftsmanChikenUpgradeAutoGainRefineMaterialGrade = 45;

		/// <summary>
		/// 授予身份时给的好感
		/// </summary>
		public const int BaseFavorAddGainRole = 46;

		/// <summary>
		/// 剥夺身份时扣的好感
		/// </summary>
		public const int BaseFavorCostLostRole = 47;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 农户自动采集次数
		/// </summary>
		public static VillagerRoleFormulaItem FarmerAutoCollectActionCount => Instance[0];

		/// <summary>
		/// 农户自动采集数量
		/// </summary>
		public static VillagerRoleFormulaItem FarmerAutoCollectActionResult => Instance[1];

		/// <summary>
		/// 农户迁移心材成功率
		/// </summary>
		public static VillagerRoleFormulaItem FarmerMigrateResourceSuccessRate => Instance[2];

		/// <summary>
		/// 农户迁移心材额外成功率
		/// </summary>
		public static VillagerRoleFormulaItem FarmerMigrateResourceExtraSuccessRate => Instance[3];

		/// <summary>
		/// 农户元鸡心材升级几率
		/// </summary>
		public static VillagerRoleFormulaItem FarmerChickenUpgradeBuildingCoreRate => Instance[4];

		/// <summary>
		/// 大夫可互动人物品级
		/// </summary>
		public static VillagerRoleFormulaItem DoctorInteractTargetGrade => Instance[5];

		/// <summary>
		/// 大夫可互动最高品级
		/// </summary>
		public static VillagerRoleFormulaItem DoctorInteractTargetMaxGrade => Instance[6];

		/// <summary>
		/// 大夫自动威望收入基础
		/// </summary>
		public static VillagerRoleFormulaItem DoctorAutoActionAuthorityIncome => Instance[7];

		/// <summary>
		/// 大夫自动威望收入浮动
		/// </summary>
		public static VillagerRoleFormulaItem DoctorAutoActionAuthorityIncomeAdjust => Instance[8];

		/// <summary>
		/// 大夫派遣恩义收入
		/// </summary>
		public static VillagerRoleFormulaItem DoctorWorkSpiritualDebtIncome => Instance[9];

		/// <summary>
		/// 大夫元鸡降低入魔值量
		/// </summary>
		public static VillagerRoleFormulaItem DoctorChickenUpgradeInfectionChangeAmount => Instance[10];

		/// <summary>
		/// 大夫行为目标状态门槛
		/// </summary>
		public static VillagerRoleFormulaItem DoctorCureRequirement => Instance[11];

		/// <summary>
		/// 使者自动行为影响人数
		/// </summary>
		public static VillagerRoleFormulaItem VillageHeadAutoActionAffectCount => Instance[12];

		/// <summary>
		/// 使者自动行为好感变化
		/// </summary>
		public static VillagerRoleFormulaItem VillageHeadAutoActionFavorChange => Instance[13];

		/// <summary>
		/// 使者自动行为好感增加概率
		/// </summary>
		public static VillagerRoleFormulaItem VillageHeadAutoActionFavorIncreaseRate => Instance[14];

		/// <summary>
		/// 使者派遣行为调控范围
		/// </summary>
		public static VillagerRoleFormulaItem VillageHeadWorkChangeRuleRange => Instance[15];

		/// <summary>
		/// 使者派遣行为超常数量
		/// </summary>
		public static VillagerRoleFormulaItem VillageHeadWorkSpecialRuleCount => Instance[16];

		/// <summary>
		/// 使者派遣行为每月威望消耗
		/// </summary>
		public static VillagerRoleFormulaItem VillageHeadWorkMonthlyAuthorityCost => Instance[17];

		/// <summary>
		/// 使者元鸡效果结成关系几率
		/// </summary>
		public static VillagerRoleFormulaItem VillageHeadChickenUpgradeActionChance => Instance[18];

		/// <summary>
		/// 文人自动行为影响的人数
		/// </summary>
		public static VillagerRoleFormulaItem LiteratiAutoActionInfluenceCount => Instance[19];

		/// <summary>
		/// 文人自动行为变化的心情
		/// </summary>
		public static VillagerRoleFormulaItem LiteratiAutoActionHappinessChange => Instance[20];

		/// <summary>
		/// 文人派遣行为可进行的次数
		/// </summary>
		public static VillagerRoleFormulaItem LiteratiWorkUsableCount => Instance[21];

		/// <summary>
		/// 文人派遣行为影响的量
		/// </summary>
		public static VillagerRoleFormulaItem LiteratiWorkEffectiveValue => Instance[22];

		/// <summary>
		/// 文人元鸡影响的人数
		/// </summary>
		public static VillagerRoleFormulaItem LiteratiChickenInfluenceCount => Instance[23];

		/// <summary>
		/// 文人元鸡变化的好感
		/// </summary>
		public static VillagerRoleFormulaItem LiteratiChickenRelationChange => Instance[24];

		/// <summary>
		/// 商人可互动人物品级
		/// </summary>
		public static VillagerRoleFormulaItem MerchantInteractTargetGrade => Instance[25];

		/// <summary>
		/// 商人可互动最高品级
		/// </summary>
		public static VillagerRoleFormulaItem MerchantInteractTargetMaxGrade => Instance[26];

		/// <summary>
		/// 商人自动银钱收入基础
		/// </summary>
		public static VillagerRoleFormulaItem MerchantAutoActionMoneyIncome => Instance[27];

		/// <summary>
		/// 商人自动银钱收入浮动
		/// </summary>
		public static VillagerRoleFormulaItem MerchantAutoActionMoneyIncomeAdjust => Instance[28];

		/// <summary>
		/// 商人自动银钱收入目标银钱门槛
		/// </summary>
		public static VillagerRoleFormulaItem MerchantAutoActionTargetMoneyRequirement => Instance[29];

		/// <summary>
		/// 商人购买物品价格比例
		/// </summary>
		public static VillagerRoleFormulaItem MerchantBuyItemPriceRate => Instance[30];

		/// <summary>
		/// 商人出售物品价格比例
		/// </summary>
		public static VillagerRoleFormulaItem MerchantSellItemPriceRate => Instance[31];

		/// <summary>
		/// 商人元鸡增加地区商会总部好感
		/// </summary>
		public static VillagerRoleFormulaItem MerchantChickenIncreaseHeadMerchantFavor => Instance[32];

		/// <summary>
		/// 商人元鸡增加地区商会分部好感
		/// </summary>
		public static VillagerRoleFormulaItem MerchantChickenIncreaseBranchMerchantFavor => Instance[33];

		/// <summary>
		/// 护冢自动行为每月可消灭的数量
		/// </summary>
		public static VillagerRoleFormulaItem SwordTombKeeperAutoActionKOCount => Instance[34];

		/// <summary>
		/// 护冢派遣行为入魔值每月增加
		/// </summary>
		public static VillagerRoleFormulaItem SwordTombKeeperWorkInfectAddPerMonth => Instance[35];

		/// <summary>
		/// 护冢派遣行为收集几率
		/// </summary>
		public static VillagerRoleFormulaItem SwordTombKeeperWorkCollectOdd => Instance[36];

		/// <summary>
		/// 护冢派遣行为受伤几率
		/// </summary>
		public static VillagerRoleFormulaItem SwordTombKeeperWorkHurtOdd => Instance[37];

		/// <summary>
		/// 护冢派遣行为受伤数量
		/// </summary>
		public static VillagerRoleFormulaItem SwordTombKeeperWorkHurtCount => Instance[38];

		/// <summary>
		/// 护冢派遣行为收集见闻时得到特性几率
		/// </summary>
		public static VillagerRoleFormulaItem SwordTombKeeperWorkFeatureOddWhenInformationCollect => Instance[39];

		/// <summary>
		/// 护冢派遣行为被攻击时得到特性几率
		/// </summary>
		public static VillagerRoleFormulaItem SwordTombKeeperWorkFeatureOddWhenBeAttacked => Instance[40];

		/// <summary>
		/// 护冢元鸡降低比例
		/// </summary>
		public static VillagerRoleFormulaItem SwordTombKeeperChickenDecreaseFactor => Instance[41];

		/// <summary>
		/// 匠人自动修理次数
		/// </summary>
		public static VillagerRoleFormulaItem CraftsmanAutoRepairCount => Instance[42];

		/// <summary>
		/// 匠人获得精制引子的几率
		/// </summary>
		public static VillagerRoleFormulaItem CraftsmanAutoGainRefineMaterialChance => Instance[43];

		/// <summary>
		/// 匠人获得精制引子的品级
		/// </summary>
		public static VillagerRoleFormulaItem CraftsmanAutoGainRefineMaterialGrade => Instance[44];

		/// <summary>
		/// 匠人元鸡效果增加精制引子的品级
		/// </summary>
		public static VillagerRoleFormulaItem CraftsmanChikenUpgradeAutoGainRefineMaterialGrade => Instance[45];

		/// <summary>
		/// 授予身份时给的好感
		/// </summary>
		public static VillagerRoleFormulaItem BaseFavorAddGainRole => Instance[46];

		/// <summary>
		/// 剥夺身份时扣的好感
		/// </summary>
		public static VillagerRoleFormulaItem BaseFavorCostLostRole => Instance[47];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static VillagerRoleFormula Instance = new VillagerRoleFormula();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "DisplayName", "DisplayFormat", "TemplateId" };

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
		_dataArray.Add(new VillagerRoleFormulaItem(0, EVillagerRoleFormulaType.Formula4, new int[2] { 1, 20 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_0"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_0")));
		_dataArray.Add(new VillagerRoleFormulaItem(1, EVillagerRoleFormulaType.Formula3, new int[1] { 5 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_1"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_1")));
		_dataArray.Add(new VillagerRoleFormulaItem(2, EVillagerRoleFormulaType.Formula4, new int[2] { 10, 5 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_2"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_2")));
		_dataArray.Add(new VillagerRoleFormulaItem(3, EVillagerRoleFormulaType.Formula14, new int[3] { 10, 5, 10 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_3"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_3")));
		_dataArray.Add(new VillagerRoleFormulaItem(4, EVillagerRoleFormulaType.Formula4, new int[2] { 5, 10 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_4"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_4")));
		_dataArray.Add(new VillagerRoleFormulaItem(5, EVillagerRoleFormulaType.Formula4, new int[2] { 2, 15 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_5"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_5")));
		_dataArray.Add(new VillagerRoleFormulaItem(6, EVillagerRoleFormulaType.Formula1, new int[1] { 2 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_6"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_6")));
		_dataArray.Add(new VillagerRoleFormulaItem(7, EVillagerRoleFormulaType.Formula7, new int[2] { 25, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_7"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_7")));
		_dataArray.Add(new VillagerRoleFormulaItem(8, EVillagerRoleFormulaType.Formula8, new int[3] { 80, 120, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_8"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_8")));
		_dataArray.Add(new VillagerRoleFormulaItem(9, EVillagerRoleFormulaType.Formula6, new int[2] { 1, 50 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_9"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_9")));
		_dataArray.Add(new VillagerRoleFormulaItem(10, EVillagerRoleFormulaType.Formula9, new int[3] { 5, 50, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_10"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_10")));
		_dataArray.Add(new VillagerRoleFormulaItem(11, EVillagerRoleFormulaType.Formula10, new int[5] { 6, 3, 2000, 25, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_11"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_11")));
		_dataArray.Add(new VillagerRoleFormulaItem(12, EVillagerRoleFormulaType.Formula4, new int[2] { 1, 20 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_12"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_12")));
		_dataArray.Add(new VillagerRoleFormulaItem(13, EVillagerRoleFormulaType.Formula2, new int[1] { 20 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_13"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_13")));
		_dataArray.Add(new VillagerRoleFormulaItem(14, EVillagerRoleFormulaType.Formula10, new int[5] { 75, 100, 50, 0, 25 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_14"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_14")));
		_dataArray.Add(new VillagerRoleFormulaItem(15, EVillagerRoleFormulaType.Formula1, new int[1] { 1 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_15"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_15")));
		_dataArray.Add(new VillagerRoleFormulaItem(16, EVillagerRoleFormulaType.Formula4, new int[2] { 1, 20 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_16"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_16")));
		_dataArray.Add(new VillagerRoleFormulaItem(17, EVillagerRoleFormulaType.Formula11, new int[4] { 10, 100, 10, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_17"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_17")));
		_dataArray.Add(new VillagerRoleFormulaItem(18, EVillagerRoleFormulaType.Formula3, new int[1] { 2 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_18"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_18")));
		_dataArray.Add(new VillagerRoleFormulaItem(19, EVillagerRoleFormulaType.Formula4, new int[2] { 1, 10 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_19"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_19")));
		_dataArray.Add(new VillagerRoleFormulaItem(20, EVillagerRoleFormulaType.Formula4, new int[2] { 3, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_20"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_20")));
		_dataArray.Add(new VillagerRoleFormulaItem(21, EVillagerRoleFormulaType.Formula4, new int[2] { 1, 20 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_21"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_21")));
		_dataArray.Add(new VillagerRoleFormulaItem(22, EVillagerRoleFormulaType.Formula4, new int[2] { 3, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_22"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_22")));
		_dataArray.Add(new VillagerRoleFormulaItem(23, EVillagerRoleFormulaType.Formula4, new int[2] { 1, 20 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_23"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_23")));
		_dataArray.Add(new VillagerRoleFormulaItem(24, EVillagerRoleFormulaType.Formula2, new int[1] { 5 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_24"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_24")));
		_dataArray.Add(new VillagerRoleFormulaItem(25, EVillagerRoleFormulaType.Formula4, new int[2] { 2, 15 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_25"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_25")));
		_dataArray.Add(new VillagerRoleFormulaItem(26, EVillagerRoleFormulaType.Formula1, new int[1] { 2 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_26"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_26")));
		_dataArray.Add(new VillagerRoleFormulaItem(27, EVillagerRoleFormulaType.Formula7, new int[2] { 50, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_27"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_27")));
		_dataArray.Add(new VillagerRoleFormulaItem(28, EVillagerRoleFormulaType.Formula8, new int[3] { 80, 120, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_28"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_28")));
		_dataArray.Add(new VillagerRoleFormulaItem(29, EVillagerRoleFormulaType.Formula3, new int[1] { 2 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_29"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_29")));
		_dataArray.Add(new VillagerRoleFormulaItem(30, EVillagerRoleFormulaType.Formula4, new int[2] { 300, -5 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_30"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_30")));
		_dataArray.Add(new VillagerRoleFormulaItem(31, EVillagerRoleFormulaType.Formula4, new int[2] { 50, 10 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_31"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_31")));
		_dataArray.Add(new VillagerRoleFormulaItem(32, EVillagerRoleFormulaType.Formula9, new int[3] { 1000, 10, 1 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_32"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_32")));
		_dataArray.Add(new VillagerRoleFormulaItem(33, EVillagerRoleFormulaType.Formula9, new int[3] { 500, 20, 1 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_33"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_33")));
		_dataArray.Add(new VillagerRoleFormulaItem(34, EVillagerRoleFormulaType.Formula4, new int[2] { 1, 20 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_34"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_34")));
		_dataArray.Add(new VillagerRoleFormulaItem(35, EVillagerRoleFormulaType.Formula0, new int[1] { 5 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_35"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_35")));
		_dataArray.Add(new VillagerRoleFormulaItem(36, EVillagerRoleFormulaType.Formula9, new int[3] { 10, 20, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_36"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_36")));
		_dataArray.Add(new VillagerRoleFormulaItem(37, EVillagerRoleFormulaType.Formula9, new int[3] { 100, -20, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_37"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_37")));
		_dataArray.Add(new VillagerRoleFormulaItem(38, EVillagerRoleFormulaType.Formula12, new int[1] { 2 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_38"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_38")));
		_dataArray.Add(new VillagerRoleFormulaItem(39, EVillagerRoleFormulaType.Formula9, new int[3] { 5, 20, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_39"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_39")));
		_dataArray.Add(new VillagerRoleFormulaItem(40, EVillagerRoleFormulaType.Formula9, new int[3] { 5, 20, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_40"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_40")));
		_dataArray.Add(new VillagerRoleFormulaItem(41, EVillagerRoleFormulaType.Formula9, new int[3] { 10, 10, 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_41"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_41")));
		_dataArray.Add(new VillagerRoleFormulaItem(42, EVillagerRoleFormulaType.Formula4, new int[2] { 1, 20 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_42"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_42")));
		_dataArray.Add(new VillagerRoleFormulaItem(43, EVillagerRoleFormulaType.Formula4, new int[2] { 10, 10 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_43"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_43")));
		_dataArray.Add(new VillagerRoleFormulaItem(44, EVillagerRoleFormulaType.Formula3, new int[1] { 100 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_44"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_44")));
		_dataArray.Add(new VillagerRoleFormulaItem(45, EVillagerRoleFormulaType.Formula4, new int[2] { 10, 10 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_45"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_45")));
		_dataArray.Add(new VillagerRoleFormulaItem(46, EVillagerRoleFormulaType.Formula2, new int[1] { 1000 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_46"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_46")));
		_dataArray.Add(new VillagerRoleFormulaItem(47, EVillagerRoleFormulaType.Formula2, new int[1] { 2000 }, -1, LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayName_47"), LocalStringManager.GetConfig("VillagerRoleFormula_language", "DisplayFormat_47")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<VillagerRoleFormulaItem>(48);
		CreateItems0();
	}
}
