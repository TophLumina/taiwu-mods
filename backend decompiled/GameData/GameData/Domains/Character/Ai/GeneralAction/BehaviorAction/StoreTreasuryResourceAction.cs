using System;
using GameData.Common;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class StoreTreasuryResourceAction : IGeneralAction
{
	public sbyte ResourceType;

	public int Amount;

	public sbyte ActionEnergyType => 3;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return selfChar.GetResource(ResourceType) >= Amount;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		throw new Exception("Current action requires no targetChar.");
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		DomainManager.Organization.StoreResourceInTreasury(context, selfChar.GetOrganizationInfo().SettlementId, selfChar, ResourceType, Amount, -1);
		selfChar.ChangeResource(context, ResourceType, -Amount);
	}
}
