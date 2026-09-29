using System.Collections.Generic;

namespace GameData.Domains.Merchant;

public static class MerchantDomainHelper
{
	public static class DataIds
	{
		public const ushort MerchantData = 0;

		public const ushort MerchantFavorability = 1;

		public const ushort MerchantMoney = 2;

		public const ushort MerchantMaxLevelData = 3;

		public const ushort NextCaravanId = 4;

		public const ushort CaravanData = 5;

		public const ushort CaravanDict = 6;

		public const ushort MerchantExpData = 7;
	}

	public static class MethodIds
	{
		public const ushort GetMerchantData = 0;

		public const ushort SettleTrade = 1;

		public const ushort ExchangeBook = 2;

		public const ushort PullTradeCaravanLocations = 3;

		public const ushort GetCaravanMerchantData = 4;

		public const ushort GetTradeBookDisplayData = 5;

		public const ushort GmCmd_AddItem = 6;

		public const ushort GetTaiwuLocationMaxLevelCaravanIdList = 7;

		public const ushort GetCurFavorability = 8;

		public const ushort FinishBookTrade = 9;

		public const ushort GetTradeBackBookDisplayData = 10;

		public const ushort GetMerchantInfoCaravanDataList = 11;

		public const ushort GetMerchantInfoAreaDataList = 12;

		public const ushort GetMerchantInfoMerchantDataList = 13;

		public const ushort GetMerchantOverFavorData = 14;

		public const ushort GetBuildingMerchantData = 15;

		public const ushort GetCaravanDisplayData = 16;

		public const ushort InvestCaravan = 17;

		public const ushort GetAllFavorability = 18;

		public const ushort ProtectCaravan = 19;

		public const ushort GmCmd_ProtectCaravan = 20;

		public const ushort GmCmd_ProtectAllCaravan = 21;

		public const ushort GmCmd_SetCaravanRobbedRate = 22;

		public const ushort GmCmd_SetCaravanInvested = 23;

		public const ushort GmCmd_SetAllCaravanInvested = 24;

		public const ushort GmCmd_SetCaravanState = 25;

		public const ushort GmCmd_SetCaravanIncomeData = 26;

		public const ushort GetSectStorySpecialMerchantData = 27;

		public const ushort GetMerchantTemplateId = 28;

		public const ushort GetMerchantBuyBackData = 29;

		public const ushort RefreshMerchantGoods = 30;

		public const ushort GetFavorabilityWithDelta = 31;

		public const ushort CanRefreshMerchantGoods = 32;

		public const ushort GetMerchantInfoCaravanDataSingle = 33;

		public const ushort GmCmd_SetMerchantExp = 34;

		public const ushort GmCmd_GetMerchantExp = 35;

		public const ushort GmCmd_GetMerchantLevel = 36;

		public const ushort GmCmd_RemoveMerchantData = 37;

		public const ushort GmCmd_SetMerchantCharToType = 38;
	}

	public const ushort DataCount = 8;

	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "MerchantData", 0 },
		{ "MerchantFavorability", 1 },
		{ "MerchantMoney", 2 },
		{ "MerchantMaxLevelData", 3 },
		{ "NextCaravanId", 4 },
		{ "CaravanData", 5 },
		{ "CaravanDict", 6 },
		{ "MerchantExpData", 7 }
	};

	public static readonly string[] DataId2FieldName = new string[8] { "MerchantData", "MerchantFavorability", "MerchantMoney", "MerchantMaxLevelData", "NextCaravanId", "CaravanData", "CaravanDict", "MerchantExpData" };

	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[8][];

	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "GetMerchantData", 0 },
		{ "SettleTrade", 1 },
		{ "ExchangeBook", 2 },
		{ "PullTradeCaravanLocations", 3 },
		{ "GetCaravanMerchantData", 4 },
		{ "GetTradeBookDisplayData", 5 },
		{ "GmCmd_AddItem", 6 },
		{ "GetTaiwuLocationMaxLevelCaravanIdList", 7 },
		{ "GetCurFavorability", 8 },
		{ "FinishBookTrade", 9 },
		{ "GetTradeBackBookDisplayData", 10 },
		{ "GetMerchantInfoCaravanDataList", 11 },
		{ "GetMerchantInfoAreaDataList", 12 },
		{ "GetMerchantInfoMerchantDataList", 13 },
		{ "GetMerchantOverFavorData", 14 },
		{ "GetBuildingMerchantData", 15 },
		{ "GetCaravanDisplayData", 16 },
		{ "InvestCaravan", 17 },
		{ "GetAllFavorability", 18 },
		{ "ProtectCaravan", 19 },
		{ "GmCmd_ProtectCaravan", 20 },
		{ "GmCmd_ProtectAllCaravan", 21 },
		{ "GmCmd_SetCaravanRobbedRate", 22 },
		{ "GmCmd_SetCaravanInvested", 23 },
		{ "GmCmd_SetAllCaravanInvested", 24 },
		{ "GmCmd_SetCaravanState", 25 },
		{ "GmCmd_SetCaravanIncomeData", 26 },
		{ "GetSectStorySpecialMerchantData", 27 },
		{ "GetMerchantTemplateId", 28 },
		{ "GetMerchantBuyBackData", 29 },
		{ "RefreshMerchantGoods", 30 },
		{ "GetFavorabilityWithDelta", 31 },
		{ "CanRefreshMerchantGoods", 32 },
		{ "GetMerchantInfoCaravanDataSingle", 33 },
		{ "GmCmd_SetMerchantExp", 34 },
		{ "GmCmd_GetMerchantExp", 35 },
		{ "GmCmd_GetMerchantLevel", 36 },
		{ "GmCmd_RemoveMerchantData", 37 },
		{ "GmCmd_SetMerchantCharToType", 38 }
	};

	public static readonly string[] MethodId2MethodName = new string[39]
	{
		"GetMerchantData", "SettleTrade", "ExchangeBook", "PullTradeCaravanLocations", "GetCaravanMerchantData", "GetTradeBookDisplayData", "GmCmd_AddItem", "GetTaiwuLocationMaxLevelCaravanIdList", "GetCurFavorability", "FinishBookTrade",
		"GetTradeBackBookDisplayData", "GetMerchantInfoCaravanDataList", "GetMerchantInfoAreaDataList", "GetMerchantInfoMerchantDataList", "GetMerchantOverFavorData", "GetBuildingMerchantData", "GetCaravanDisplayData", "InvestCaravan", "GetAllFavorability", "ProtectCaravan",
		"GmCmd_ProtectCaravan", "GmCmd_ProtectAllCaravan", "GmCmd_SetCaravanRobbedRate", "GmCmd_SetCaravanInvested", "GmCmd_SetAllCaravanInvested", "GmCmd_SetCaravanState", "GmCmd_SetCaravanIncomeData", "GetSectStorySpecialMerchantData", "GetMerchantTemplateId", "GetMerchantBuyBackData",
		"RefreshMerchantGoods", "GetFavorabilityWithDelta", "CanRefreshMerchantGoods", "GetMerchantInfoCaravanDataSingle", "GmCmd_SetMerchantExp", "GmCmd_GetMerchantExp", "GmCmd_GetMerchantLevel", "GmCmd_RemoveMerchantData", "GmCmd_SetMerchantCharToType"
	};
}
