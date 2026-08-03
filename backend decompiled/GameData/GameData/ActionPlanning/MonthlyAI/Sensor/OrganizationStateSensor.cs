using Config;
using GameData.Domains.Character;

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
		default:
			throw new ActionPlanningException($"Unimplemented planning state: {stateKey}");
		}
		if (1 == 0)
		{
		}
		return result;
	}
}
