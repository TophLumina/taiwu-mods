using GameData.Domains.Character;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public class CombatSkillStateSensor : CharacterStateSensorBase
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
		case 131:
			result = ((args.CombatSkillType >= 0) ? selfChar.GetCombatSkillQualification(args.CombatSkillType) : int.MinValue);
			break;
		case 132:
		case 133:
		case 134:
		case 135:
		case 136:
		case 137:
		case 138:
		case 139:
		case 140:
		case 141:
		case 142:
		case 143:
		case 144:
		case 145:
			result = selfChar.GetCombatSkillQualification(stateKey.Offset(132));
			break;
		case 195:
			result = ((args.CombatSkillType >= 0) ? selfChar.GetCombatSkillAttainment(args.CombatSkillType) : int.MinValue);
			break;
		case 196:
		case 197:
		case 198:
		case 199:
		case 200:
		case 201:
		case 202:
		case 203:
		case 204:
		case 205:
		case 206:
		case 207:
		case 208:
		case 209:
			result = selfChar.GetCombatSkillAttainment(stateKey.Offset(196));
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
