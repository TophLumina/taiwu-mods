using System;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class SellItemAction : IGeneralAction
{
	public ItemKey TargetItem;

	public int Amount;

	public sbyte ActionEnergyType => 3;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		int amount;
		return selfChar.IsInRegularSettlementRange() && selfChar.GetInventory().Items.TryGetValue(TargetItem, out amount) && amount >= Amount;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		throw new Exception("Current action requires no targetChar.");
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int price = DomainManager.Item.GetValue(TargetItem);
		int moneyGain = Amount * price / 5;
		selfChar.RemoveInventoryItem(context, TargetItem, Amount, deleteItem: true);
		selfChar.ChangeResource(context, 6, moneyGain);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetValidLocation();
		Location settlementLocation = DomainManager.Map.GetBelongSettlementBlock(location).GetLocation();
		lifeRecordCollection.AddSellItem1(selfChar.GetId(), currDate, settlementLocation, TargetItem.ItemType, TargetItem.TemplateId);
	}
}
