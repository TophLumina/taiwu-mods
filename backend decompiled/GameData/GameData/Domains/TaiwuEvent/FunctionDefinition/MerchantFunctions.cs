using Config;
using GameData.Domains.Item;
using GameData.Domains.TaiwuEvent.EventHelper;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class MerchantFunctions
{
	[EventFunction(61)]
	private static void ChangeMerchantFavorability(EventScriptRuntime runtime, sbyte merchantType, int delta)
	{
		DomainManager.Merchant.ChangeMerchantCumulativeMoney(runtime.Context, merchantType, delta);
	}

	[EventFunction(153)]
	private static ItemKey CreateMerchantRandomItem(EventScriptRuntime runtime, short merchantTemplateId)
	{
		return DomainManager.Merchant.CreateMerchantRandomItem(runtime.Context, merchantTemplateId);
	}

	[EventFunction(557)]
	private static void AdventureInteractCaravan(EventScriptRuntime runtime, int charId, sbyte merchantTemplateId, string tradeFinishEvent)
	{
		MerchantItem config = Config.Merchant.Instance[merchantTemplateId];
		DomainManager.Merchant.StartSpecificCharIdAndMerchantTypeAction(charId, config.MerchantType, config.Level, refresh: false);
		if (!string.IsNullOrEmpty(tradeFinishEvent))
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(tradeFinishEvent, runtime.ArgBox, "ShopActionComplete");
		}
	}

	[EventFunction(889)]
	private static void ResetTransactionData(EventScriptRuntime runtime)
	{
		DomainManager.Merchant.ResetTransactionData();
	}
}
