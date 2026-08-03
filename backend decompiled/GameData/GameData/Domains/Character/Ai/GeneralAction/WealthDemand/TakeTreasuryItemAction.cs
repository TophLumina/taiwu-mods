using System;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.Organization;

namespace GameData.Domains.Character.Ai.GeneralAction.WealthDemand;

public class TakeTreasuryItemAction : IGeneralAction
{
	public ItemKey TargetItem;

	public int Amount;

	public sbyte ActionEnergyType => 1;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		OrganizationInfo orgInfo = selfChar.GetOrganizationInfo();
		if (orgInfo.SettlementId < 0)
		{
			return false;
		}
		SettlementTreasury treasury = DomainManager.Organization.GetTreasury(orgInfo);
		if (!treasury.Inventory.Items.TryGetValue(TargetItem, out var amount) || amount < Amount)
		{
			return false;
		}
		if (orgInfo.OrgTemplateId == 16)
		{
			return true;
		}
		int contribution = treasury.GetMemberContribution(selfChar);
		Settlement settlement = DomainManager.Organization.GetSettlement(orgInfo.SettlementId);
		int worth = DomainManager.Organization.CalcItemContribution(settlement, TargetItem, Amount);
		return contribution >= worth;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		throw new Exception("Current action requires no targetChar.");
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		DomainManager.Organization.TakeItemFromTreasury(context, selfChar.GetOrganizationInfo().SettlementId, selfChar, TargetItem, Amount);
		selfChar.AddInventoryItem(context, TargetItem, Amount);
	}
}
