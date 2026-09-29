using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleFormula : ConfigData<VillagerRoleFormulaItem, int>
{
	public static class DefKey
	{
		public const int FarmerAutoCollectActionCount = 0;

		public const int FarmerAutoCollectActionResult = 1;

		public const int FarmerMigrateResourceSuccessRate = 2;

		public const int FarmerMigrateResourceExtraSuccessRate = 3;

		public const int FarmerChickenUpgradeBuildingCoreRate = 4;

		public const int DoctorInteractTargetGrade = 5;

		public const int DoctorInteractTargetMaxGrade = 6;

		public const int DoctorAutoActionAuthorityIncome = 7;

		public const int DoctorAutoActionAuthorityIncomeAdjust = 8;

		public const int DoctorWorkSpiritualDebtIncome = 9;

		public const int DoctorChickenUpgradeInfectionChangeAmount = 10;

		public const int DoctorCureRequirement = 11;

		public const int VillageHeadAutoActionAffectCount = 12;

		public const int VillageHeadAutoActionFavorChange = 13;

		public const int VillageHeadAutoActionFavorIncreaseRate = 14;

		public const int VillageHeadWorkChangeRuleRange = 15;

		public const int VillageHeadWorkSpecialRuleCount = 16;

		public const int VillageHeadWorkMonthlyAuthorityCost = 17;

		public const int VillageHeadChickenUpgradeActionChance = 18;

		public const int LiteratiAutoActionInfluenceCount = 19;

		public const int LiteratiAutoActionHappinessChange = 20;

		public const int LiteratiWorkUsableCount = 21;

		public const int LiteratiWorkEffectiveValue = 22;

		public const int LiteratiChickenInfluenceCount = 23;

		public const int LiteratiChickenRelationChange = 24;

		public const int MerchantInteractTargetGrade = 25;

		public const int MerchantInteractTargetMaxGrade = 26;

		public const int MerchantAutoActionMoneyIncome = 27;

		public const int MerchantAutoActionMoneyIncomeAdjust = 28;

		public const int MerchantAutoActionTargetMoneyRequirement = 29;

		public const int MerchantBuyItemPriceRate = 30;

		public const int MerchantSellItemPriceRate = 31;

		public const int MerchantChickenIncreaseHeadMerchantFavor = 32;

		public const int MerchantChickenIncreaseBranchMerchantFavor = 33;

		public const int SwordTombKeeperAutoActionKOCount = 34;

		public const int SwordTombKeeperWorkInfectAddPerMonth = 35;

		public const int SwordTombKeeperWorkCollectOdd = 36;

		public const int SwordTombKeeperWorkHurtOdd = 37;

		public const int SwordTombKeeperWorkHurtCount = 38;

		public const int SwordTombKeeperWorkFeatureOddWhenInformationCollect = 39;

		public const int SwordTombKeeperWorkFeatureOddWhenBeAttacked = 40;

		public const int SwordTombKeeperChickenDecreaseFactor = 41;

		public const int CraftsmanAutoRepairCount = 42;

		public const int CraftsmanAutoGainRefineMaterialChance = 43;

		public const int CraftsmanAutoGainRefineMaterialGrade = 44;

		public const int CraftsmanChikenUpgradeAutoGainRefineMaterialGrade = 45;

		public const int BaseFavorAddGainRole = 46;

		public const int BaseFavorCostLostRole = 47;
	}

	public static class DefValue
	{
		public static VillagerRoleFormulaItem FarmerAutoCollectActionCount => Instance[0];

		public static VillagerRoleFormulaItem FarmerAutoCollectActionResult => Instance[1];

		public static VillagerRoleFormulaItem FarmerMigrateResourceSuccessRate => Instance[2];

		public static VillagerRoleFormulaItem FarmerMigrateResourceExtraSuccessRate => Instance[3];

		public static VillagerRoleFormulaItem FarmerChickenUpgradeBuildingCoreRate => Instance[4];

		public static VillagerRoleFormulaItem DoctorInteractTargetGrade => Instance[5];

		public static VillagerRoleFormulaItem DoctorInteractTargetMaxGrade => Instance[6];

		public static VillagerRoleFormulaItem DoctorAutoActionAuthorityIncome => Instance[7];

		public static VillagerRoleFormulaItem DoctorAutoActionAuthorityIncomeAdjust => Instance[8];

		public static VillagerRoleFormulaItem DoctorWorkSpiritualDebtIncome => Instance[9];

		public static VillagerRoleFormulaItem DoctorChickenUpgradeInfectionChangeAmount => Instance[10];

		public static VillagerRoleFormulaItem DoctorCureRequirement => Instance[11];

		public static VillagerRoleFormulaItem VillageHeadAutoActionAffectCount => Instance[12];

		public static VillagerRoleFormulaItem VillageHeadAutoActionFavorChange => Instance[13];

		public static VillagerRoleFormulaItem VillageHeadAutoActionFavorIncreaseRate => Instance[14];

		public static VillagerRoleFormulaItem VillageHeadWorkChangeRuleRange => Instance[15];

		public static VillagerRoleFormulaItem VillageHeadWorkSpecialRuleCount => Instance[16];

		public static VillagerRoleFormulaItem VillageHeadWorkMonthlyAuthorityCost => Instance[17];

		public static VillagerRoleFormulaItem VillageHeadChickenUpgradeActionChance => Instance[18];

		public static VillagerRoleFormulaItem LiteratiAutoActionInfluenceCount => Instance[19];

		public static VillagerRoleFormulaItem LiteratiAutoActionHappinessChange => Instance[20];

		public static VillagerRoleFormulaItem LiteratiWorkUsableCount => Instance[21];

		public static VillagerRoleFormulaItem LiteratiWorkEffectiveValue => Instance[22];

		public static VillagerRoleFormulaItem LiteratiChickenInfluenceCount => Instance[23];

		public static VillagerRoleFormulaItem LiteratiChickenRelationChange => Instance[24];

		public static VillagerRoleFormulaItem MerchantInteractTargetGrade => Instance[25];

		public static VillagerRoleFormulaItem MerchantInteractTargetMaxGrade => Instance[26];

		public static VillagerRoleFormulaItem MerchantAutoActionMoneyIncome => Instance[27];

		public static VillagerRoleFormulaItem MerchantAutoActionMoneyIncomeAdjust => Instance[28];

		public static VillagerRoleFormulaItem MerchantAutoActionTargetMoneyRequirement => Instance[29];

		public static VillagerRoleFormulaItem MerchantBuyItemPriceRate => Instance[30];

		public static VillagerRoleFormulaItem MerchantSellItemPriceRate => Instance[31];

		public static VillagerRoleFormulaItem MerchantChickenIncreaseHeadMerchantFavor => Instance[32];

		public static VillagerRoleFormulaItem MerchantChickenIncreaseBranchMerchantFavor => Instance[33];

		public static VillagerRoleFormulaItem SwordTombKeeperAutoActionKOCount => Instance[34];

		public static VillagerRoleFormulaItem SwordTombKeeperWorkInfectAddPerMonth => Instance[35];

		public static VillagerRoleFormulaItem SwordTombKeeperWorkCollectOdd => Instance[36];

		public static VillagerRoleFormulaItem SwordTombKeeperWorkHurtOdd => Instance[37];

		public static VillagerRoleFormulaItem SwordTombKeeperWorkHurtCount => Instance[38];

		public static VillagerRoleFormulaItem SwordTombKeeperWorkFeatureOddWhenInformationCollect => Instance[39];

		public static VillagerRoleFormulaItem SwordTombKeeperWorkFeatureOddWhenBeAttacked => Instance[40];

		public static VillagerRoleFormulaItem SwordTombKeeperChickenDecreaseFactor => Instance[41];

		public static VillagerRoleFormulaItem CraftsmanAutoRepairCount => Instance[42];

		public static VillagerRoleFormulaItem CraftsmanAutoGainRefineMaterialChance => Instance[43];

		public static VillagerRoleFormulaItem CraftsmanAutoGainRefineMaterialGrade => Instance[44];

		public static VillagerRoleFormulaItem CraftsmanChikenUpgradeAutoGainRefineMaterialGrade => Instance[45];

		public static VillagerRoleFormulaItem BaseFavorAddGainRole => Instance[46];

		public static VillagerRoleFormulaItem BaseFavorCostLostRole => Instance[47];
	}

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
