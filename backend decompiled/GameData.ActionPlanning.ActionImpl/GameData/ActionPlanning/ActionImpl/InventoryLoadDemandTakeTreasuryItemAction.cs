using GameData.ActionPlanning.ActionImpl.Helper;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Organization;
using GameData.Serializer;

namespace GameData.ActionPlanning.ActionImpl;

public class InventoryLoadDemandTakeTreasuryItemAction : WealthDemandTakeTreasuryItemAction, ICharacterActionImpl, ISerializableGameData
{
	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		if (!ActionHelper.CanInteractTreasury(character))
		{
			return false;
		}
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		Settlement settlement = DomainManager.Organization.GetSettlement(orgInfo.SettlementId);
		SettlementTreasury treasury = settlement.GetTreasury(orgInfo.Grade);
		ItemKey targetItemKey = ActionHelper.SelectIncreaseInventoryLoadItem(character, treasury.Inventory);
		if (!targetItemKey.IsValid())
		{
			return false;
		}
		int requiredContribution = settlement.CalcItemContribution(targetItemKey, 1);
		if (orgInfo.OrgTemplateId != 16 && treasury.GetMemberContribution(character) < requiredContribution)
		{
			return false;
		}
		TargetItem = targetItemKey;
		Amount = 1;
		return true;
	}
}
