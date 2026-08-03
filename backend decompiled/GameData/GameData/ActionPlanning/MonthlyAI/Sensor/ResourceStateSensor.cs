using GameData.Domains.Character;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public class ResourceStateSensor : CharacterStateSensorBase
{
	public override int Sense(ContextArgGroupHandle args, Character selfChar, StateKey stateKey)
	{
		int stateTemplateId = stateKey.StateTemplateId;
		if (1 == 0)
		{
		}
		int result;
		switch (stateTemplateId)
		{
		case 356:
		case 357:
		case 358:
		case 359:
		case 360:
		case 361:
		case 362:
		case 363:
			result = selfChar.GetResource((sbyte)(stateKey.StateTemplateId - 356));
			break;
		case 364:
		{
			sbyte resourceType = args.ResourceType;
			result = ((resourceType >= 0 && resourceType <= 6) ? selfChar.GetResource(args.ResourceType) : int.MinValue);
			break;
		}
		case 355:
			result = ((args.ResourceType >= 0) ? selfChar.GetResource(args.ResourceType) : int.MinValue);
			break;
		case 39:
			result = ((args.ResourceType >= 0) ? selfChar.GetAdjustedResourceSatisfyingThreshold(args.ResourceType) : int.MinValue);
			break;
		case 365:
			result = selfChar.GetResources().GetTotalWorth();
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
