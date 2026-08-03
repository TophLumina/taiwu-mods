using System;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class StoreTreasuryItemAction : IGeneralAction
{
	public ItemKey TargetItem;

	public int Amount;

	public sbyte ActionEnergyType => 3;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		int amount;
		return selfChar.GetInventory().Items.TryGetValue(TargetItem, out amount) && amount >= Amount;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		throw new Exception("Current action requires no targetChar.");
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		selfChar.RemoveInventoryItem(context, TargetItem, Amount, deleteItem: false);
		DomainManager.Organization.StoreItemInTreasury(context, selfChar.GetOrganizationInfo().SettlementId, selfChar, TargetItem, Amount, -1);
	}
}
