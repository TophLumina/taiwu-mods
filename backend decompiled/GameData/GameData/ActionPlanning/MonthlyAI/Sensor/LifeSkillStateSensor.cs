using System.Linq;
using GameData.Domains.Character;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public class LifeSkillStateSensor : CharacterStateSensorBase
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
		case 161:
			result = ((args.CombatSkillType >= 0) ? selfChar.GetLifeSkillQualification(args.LifeSkillType) : int.MinValue);
			break;
		case 162:
		case 163:
		case 164:
		case 165:
		case 166:
		case 167:
		case 168:
		case 169:
		case 170:
		case 171:
		case 172:
		case 173:
		case 174:
		case 175:
		case 176:
		case 177:
			result = selfChar.GetLifeSkillAttainment(stateKey.Offset(162));
			break;
		case 246:
			result = selfChar.GetLifeSkillQualifications().GetMaxLifeSkillValue();
			break;
		case 227:
			result = ((args.LifeSkillType >= 0) ? selfChar.GetLifeSkillAttainment(args.LifeSkillType) : int.MinValue);
			break;
		case 228:
		case 229:
		case 230:
		case 231:
		case 232:
		case 233:
		case 234:
		case 235:
		case 236:
		case 237:
		case 238:
		case 239:
		case 240:
		case 241:
		case 242:
		case 243:
			result = selfChar.GetLifeSkillAttainment(stateKey.Offset(228));
			break;
		case 244:
			result = (LifeSkillType.CraftingTypes.Contains(args.LifeSkillType) ? selfChar.GetLifeSkillAttainment(args.LifeSkillType) : int.MinValue);
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
