using GameData.Domains.Character;
using GameData.Domains.Taiwu.Profession;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public class ProfessionStateSensor : CharacterStateSensorBase
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
		case 337:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 0) ? 1 : 0);
			break;
		}
		case 338:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 1) ? 1 : 0);
			break;
		}
		case 339:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 2) ? 1 : 0);
			break;
		}
		case 340:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 3) ? 1 : 0);
			break;
		}
		case 341:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 4) ? 1 : 0);
			break;
		}
		case 342:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 5) ? 1 : 0);
			break;
		}
		case 343:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 6) ? 1 : 0);
			break;
		}
		case 344:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 7) ? 1 : 0);
			break;
		}
		case 345:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 8) ? 1 : 0);
			break;
		}
		case 346:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 9) ? 1 : 0);
			break;
		}
		case 347:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 10) ? 1 : 0);
			break;
		}
		case 348:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 11) ? 1 : 0);
			break;
		}
		case 349:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 12) ? 1 : 0);
			break;
		}
		case 350:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 13) ? 1 : 0);
			break;
		}
		case 351:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 14) ? 1 : 0);
			break;
		}
		case 352:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 15) ? 1 : 0);
			break;
		}
		case 353:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 16) ? 1 : 0);
			break;
		}
		case 354:
		{
			ProfessionData currentProfession = selfChar.GetCurrentProfession();
			result = ((currentProfession != null && currentProfession.TemplateId == 17) ? 1 : 0);
			break;
		}
		case 38:
			result = selfChar.GetCurrentProfession()?.Seniority ?? int.MinValue;
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
