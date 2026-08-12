using System;
using GameData.Common;
using GameData.Domains.Organization;

namespace GameData.Domains.Character.Ai.GeneralAction.WealthDemand;

public class TakeTreasuryResourceAction : IGeneralAction
{
	public sbyte ResourceType;

	public int Amount;

	public sbyte ActionEnergyType => 1;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		OrganizationInfo orgInfo = selfChar.GetOrganizationInfo();
		short settlementId = orgInfo.SettlementId;
		if (settlementId < 0)
		{
			return false;
		}
		SettlementTreasury treasury = DomainManager.Organization.GetTreasury(orgInfo);
		int worth = DomainManager.Organization.CalcResourceContribution(orgInfo.OrgTemplateId, ResourceType, Amount);
		return treasury.Resources[ResourceType] >= Amount && treasury.GetMemberContribution(selfChar) >= worth;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		throw new Exception("Current action requires no targetChar.");
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		DomainManager.Organization.TakeResourceFromTreasury(context, selfChar.GetOrganizationInfo().SettlementId, selfChar, ResourceType, Amount, -1);
		selfChar.ChangeResource(context, ResourceType, Amount);
	}
}
