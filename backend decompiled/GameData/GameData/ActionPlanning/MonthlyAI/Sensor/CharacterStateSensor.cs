using System.Collections.Generic;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Information;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public class CharacterStateSensor : CharacterStateSensorBase
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
		case 5:
			result = DomainManager.Character.GetFuyuFaith();
			break;
		case 60:
			result = selfChar.HasDarkAsh.ToInt();
			break;
		case 34:
			result = selfChar.GetGender();
			break;
		case 35:
			result = selfChar.GetAttraction();
			break;
		case 36:
			result = selfChar.GetMorality();
			break;
		case 37:
			result = selfChar.GetInteractionGrade();
			break;
		case 49:
			result = selfChar.GetCombatPower();
			break;
		case 50:
			result = DomainManager.Organization.GetSettlementCharacter(selfChar.GetId()).GetInfluencePower();
			break;
		case 42:
			result = selfChar.GetFame();
			break;
		case 43:
			result = selfChar.GetHappiness();
			break;
		case 46:
			result = selfChar.GetActualAge();
			break;
		case 45:
			result = selfChar.GetCurrAge();
			break;
		case 47:
			result = selfChar.GetPreexistenceCharIds().Count;
			break;
		case 48:
			result = selfChar.GetExp();
			break;
		case 51:
			result = selfChar.GetConsummateLevel();
			break;
		case 53:
			result = selfChar.GetMaxNeili();
			break;
		case 52:
			result = selfChar.GetCurrNeili();
			break;
		case 56:
			result = selfChar.GetLeftMaxHealth();
			break;
		case 55:
			result = selfChar.GetHealth();
			break;
		case 57:
			result = ((args.InjuryType >= 0 && args.BodyPartType >= 0) ? selfChar.GetInjuries().Get(args.BodyPartType, args.InjuryType == 1) : int.MinValue);
			break;
		case 58:
			result = ((args.PoisonType >= 0) ? selfChar.GetPoisoned().Get(args.PoisonType) : int.MinValue);
			break;
		case 59:
			result = selfChar.GetDisorderOfQi();
			break;
		case 61:
			result = (selfChar.GetEatingItems().CountOfWugMark() > 0).ToInt();
			break;
		case 62:
			result = (selfChar.GetEatingItems().CountOfWugMark() > 0).ToInt();
			break;
		case 63:
			result = (selfChar.GetEatingItems().GetWugKingCount() > 0).ToInt();
			break;
		case 65:
			result = selfChar.GetXiangshuInfection();
			break;
		case 66:
			result = (selfChar.IsCompletelyInfected() ? 1 : 0);
			break;
		case 67:
			result = (selfChar.IsPartiallyInfected() ? 1 : 0);
			break;
		case 296:
			result = selfChar.IsTaiwu().ToInt();
			break;
		case 297:
			result = (DomainManager.Organization.GetFugitiveBountySect(selfChar.GetId()) >= 0).ToInt();
			break;
		case 115:
			result = selfChar.GetPersonality(args.PersonalityType);
			break;
		case 116:
		case 117:
		case 118:
		case 119:
		case 120:
		case 121:
		case 122:
			result = selfChar.GetPersonality(stateKey.Offset(116));
			break;
		case 64:
			result = (selfChar.NeedHealAction(EHealActionType.Healing) || selfChar.NeedHealAction(EHealActionType.Detox) || selfChar.NeedHealAction(EHealActionType.Breathing) || selfChar.NeedHealAction(EHealActionType.Recover)).ToInt();
			break;
		case 41:
		{
			IReadOnlyCollection<SecretInformationId> readOnlyCollection = DomainManager.Information.QueryCharacterKnownSecretInformationIds(selfChar.GetId());
			result = (readOnlyCollection != null && readOnlyCollection.Count > 0).ToInt();
			break;
		}
		case 600:
			result = (selfChar.GetMonkType() != 0).ToInt();
			break;
		case 615:
			result = selfChar.IsOnHomeSettlement().ToInt();
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
