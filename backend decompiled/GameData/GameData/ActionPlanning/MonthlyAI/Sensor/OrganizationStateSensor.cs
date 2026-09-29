using System.Collections.Generic;
using Config;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Organization;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public class OrganizationStateSensor : CharacterStateSensorBase
{
	public override int Sense(ContextArgGroupHandle args, GameData.Domains.Character.Character selfChar, StateKey stateKey)
	{
		int stateTemplateId = stateKey.StateTemplateId;
		if (1 == 0)
		{
		}
		int result;
		switch (stateTemplateId)
		{
		case 317:
			result = selfChar.GetOrganizationInfo().GetOrganizationConfig().IsSect.ToInt();
			break;
		case 318:
			result = selfChar.GetOrganizationInfo().GetOrganizationConfig().IsCivilian.ToInt();
			break;
		case 321:
			result = (selfChar.GetOrganizationInfo().OrgTemplateId == 16).ToInt();
			break;
		case 331:
		{
			OrganizationItem organizationConfig = selfChar.GetOrganizationInfo().GetOrganizationConfig();
			result = (organizationConfig != null && organizationConfig.IsSect && organizationConfig.Goodness == -1).ToInt();
			break;
		}
		case 332:
		{
			OrganizationItem organizationConfig = selfChar.GetOrganizationInfo().GetOrganizationConfig();
			result = (organizationConfig != null && organizationConfig.IsSect && organizationConfig.Goodness == 1).ToInt();
			break;
		}
		case 333:
		{
			OrganizationItem organizationConfig = selfChar.GetOrganizationInfo().GetOrganizationConfig();
			result = (organizationConfig != null && organizationConfig.IsSect && organizationConfig.Goodness == 0).ToInt();
			break;
		}
		case 427:
			result = selfChar.GetTotalTreasuryContribution();
			break;
		case 606:
			result = (selfChar.GetOrganizationInfo().OrgTemplateId == 0).ToInt();
			break;
		case 613:
			result = CanTakeInventoryLoadItemFromTreasury(selfChar).ToInt();
			break;
		case 605:
			result = GetItemContribution(selfChar, args.ItemType, args.ItemTemplateId);
			break;
		case 604:
			result = (args.HasArgOfType(EPlanningParameterType.Integer) ? GetResourceContribution(selfChar, args.ResourceType, args.Amount) : int.MinValue);
			break;
		default:
			throw new ActionPlanningException($"Unimplemented planning state: {stateKey}");
		}
		if (1 == 0)
		{
		}
		return result;
	}

	private static int GetItemContribution(GameData.Domains.Character.Character character, sbyte itemType, short itemTemplateId)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (orgInfo.SettlementId < 0)
		{
			return int.MinValue;
		}
		SettlementTreasury treasury = DomainManager.Organization.GetTreasury(orgInfo);
		short itemSubType = ItemTemplateHelper.GetItemSubType(itemType, itemTemplateId);
		int itemWorth = ItemTemplateHelper.GetBaseValue(itemType, itemTemplateId);
		return treasury.CalcAdjustedWorth(itemSubType, itemWorth);
	}

	private static int GetResourceContribution(GameData.Domains.Character.Character character, sbyte resourceType, int amount)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (orgInfo.SettlementId < 0)
		{
			return int.MinValue;
		}
		return DomainManager.Organization.CalcResourceContribution(orgInfo.OrgTemplateId, resourceType, amount);
	}

	private static bool CanTakeInventoryLoadItemFromTreasury(GameData.Domains.Character.Character character)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (orgInfo.SettlementId < 0)
		{
			return false;
		}
		SettlementTreasury treasury = DomainManager.Organization.GetTreasury(orgInfo);
		int contribution = character.GetTotalTreasuryContribution();
		foreach (var (itemKey2, amount) in treasury.Inventory.Items)
		{
			if (character.ItemCanImproveInventoryLoad(itemKey2))
			{
				ItemBase item = DomainManager.Item.GetBaseItem(itemKey2);
				int worth = treasury.CalcAdjustedWorth(item.GetItemSubType(), item.GetValue());
				if (contribution >= worth)
				{
					return true;
				}
			}
		}
		return false;
	}
}
