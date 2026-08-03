using GameData.Domains.Character;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public class MainAttributeStateSensor : CharacterStateSensorBase
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
		case 6:
			result = ((args.MainAttributeType >= 0) ? selfChar.GetCurrMainAttribute(args.MainAttributeType) : int.MinValue);
			break;
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
			result = selfChar.GetCurrMainAttribute(stateKey.Offset(7));
			break;
		case 20:
			result = ((args.MainAttributeType >= 0) ? selfChar.GetMaxMainAttribute(args.MainAttributeType) : int.MinValue);
			break;
		case 21:
		case 22:
		case 23:
		case 24:
		case 25:
		case 26:
			result = selfChar.GetMaxMainAttribute(stateKey.Offset(21));
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
