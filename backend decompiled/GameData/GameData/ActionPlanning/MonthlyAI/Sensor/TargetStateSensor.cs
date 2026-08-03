using System.Collections.Generic;
using System.Linq;
using GameData.ActionPlanning.Interface;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Information;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public class TargetStateSensor : ISensor<IStateMemory<Character, StateKey>, Character, StateKey>
{
	public int Sense(IStateMemory<Character, StateKey> currMemory, Character selfChar, StateKey stateKey)
	{
		CharacterStateMemory memory = (CharacterStateMemory)currMemory;
		Character targetChar = memory.TargetChar;
		ContextArgGroupHandle args = memory.Args;
		if (targetChar == null)
		{
			return int.MinValue;
		}
		return Sense(args, selfChar, targetChar, stateKey);
	}

	public int Sense(ContextArgGroupHandle args, Character selfChar, Character targetChar, StateKey stateKey)
	{
		int stateTemplateId = stateKey.StateTemplateId;
		if (1 == 0)
		{
		}
		int result;
		switch (stateTemplateId)
		{
		case 44:
			result = DomainManager.Character.GetFavorability(selfChar.GetId(), targetChar.GetId());
			break;
		case 81:
			result = DomainManager.Character.GetFavorability(targetChar.GetId(), selfChar.GetId());
			break;
		case 107:
			result = ((!DomainManager.Character.IsCharacterAlive(targetChar.GetId())) ? 1 : 0);
			break;
		case 102:
			result = targetChar.GetXiangshuInfection();
			break;
		case 103:
			result = (targetChar.GetFeatureIds().Contains(210) ? 1 : 0);
			break;
		case 104:
			result = (targetChar.IsCompletelyInfected() ? 1 : 0);
			break;
		case 106:
			result = ((selfChar.GetKidnapperId() >= 0) ? 1 : 0);
			break;
		case 94:
			result = ((args.BodyPartType >= 0 && args.InjuryType >= 0) ? targetChar.GetInjuries().Get(args.BodyPartType, args.InjuryType == 1) : int.MinValue);
			break;
		case 95:
			result = ((args.PoisonType >= 0) ? targetChar.GetPoisoned().Get(args.PoisonType) : int.MinValue);
			break;
		case 96:
			result = targetChar.GetDisorderOfQi();
			break;
		case 98:
			result = targetChar.GetEatingItems().CountOfWugMark();
			break;
		case 83:
			result = targetChar.GetActualAge();
			break;
		case 82:
			result = targetChar.GetCurrAge();
			break;
		case 92:
			result = targetChar.GetHealth();
			break;
		case 80:
			result = targetChar.GetHappiness();
			break;
		case 72:
			result = targetChar.GetAttraction();
			break;
		case 87:
		{
			result = (DomainManager.Organization.TryGetSettlementCharacter(targetChar.GetId(), out var settlementChar) ? settlementChar.GetInfluencePower() : 0);
			break;
		}
		case 146:
			result = ((args.CombatSkillType >= 0) ? targetChar.GetCombatSkillQualification(args.CombatSkillType) : int.MinValue);
			break;
		case 147:
		case 148:
		case 149:
		case 150:
		case 151:
		case 152:
		case 153:
		case 154:
		case 155:
		case 156:
		case 157:
		case 158:
		case 159:
		case 160:
			result = targetChar.GetCombatSkillQualification(stateKey.Offset(147));
			break;
		case 178:
			result = ((args.LifeSkillType >= 0) ? targetChar.GetLifeSkillQualification(args.LifeSkillType) : int.MinValue);
			break;
		case 179:
		case 180:
		case 181:
		case 182:
		case 183:
		case 184:
		case 185:
		case 186:
		case 187:
		case 188:
		case 189:
		case 190:
		case 191:
		case 192:
		case 193:
		case 194:
			result = targetChar.GetLifeSkillQualification(stateKey.Offset(179));
			break;
		case 13:
			result = targetChar.GetCurrMainAttribute(args.MainAttributeType);
			break;
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
			result = targetChar.GetCurrMainAttribute(stateKey.Offset(14));
			break;
		case 27:
			result = targetChar.GetMaxMainAttribute(args.MainAttributeType);
			break;
		case 28:
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
			result = targetChar.GetMaxMainAttribute(stateKey.Offset(28));
			break;
		case 211:
			result = ((args.CombatSkillType >= 0) ? targetChar.GetCombatSkillAttainment(args.CombatSkillType) : int.MinValue);
			break;
		case 212:
		case 213:
		case 214:
		case 215:
		case 216:
		case 217:
		case 218:
		case 219:
		case 220:
		case 221:
		case 222:
		case 223:
		case 224:
		case 225:
			result = targetChar.GetLifeSkillAttainment(stateKey.Offset(212));
			break;
		case 247:
			result = ((args.LifeSkillType >= 0) ? targetChar.GetLifeSkillAttainment(args.LifeSkillType) : int.MinValue);
			break;
		case 248:
		case 249:
		case 250:
		case 251:
		case 252:
		case 253:
		case 254:
		case 255:
		case 256:
		case 257:
		case 258:
		case 259:
		case 260:
		case 261:
		case 262:
		case 263:
			result = targetChar.GetCombatSkillAttainment(stateKey.Offset(248));
			break;
		case 264:
			result = (LifeSkillType.CraftingTypes.Contains(args.LifeSkillType) ? targetChar.GetLifeSkillAttainment(args.LifeSkillType) : int.MinValue);
			break;
		case 366:
			result = ((args.ResourceType >= 0) ? targetChar.GetResource(args.ResourceType) : int.MinValue);
			break;
		case 367:
		case 368:
		case 369:
		case 370:
		case 371:
		case 372:
		case 373:
		case 374:
			result = targetChar.GetResource(stateKey.Offset(367));
			break;
		case 375:
		{
			sbyte resourceType = args.ResourceType;
			result = ((resourceType >= 0 && resourceType <= 6) ? targetChar.GetResource(args.ResourceType) : int.MinValue);
			break;
		}
		case 376:
			result = targetChar.GetResources().GetTotalWorth();
			break;
		case 302:
			result = DomainManager.Character.HasRelation(targetChar.GetId(), selfChar.GetId(), 16384).ToInt();
			break;
		case 303:
			result = DomainManager.Character.HasRelation(targetChar.GetId(), selfChar.GetId(), 32768).ToInt();
			break;
		case 304:
			result = DomainManager.Character.IsCharacterRelationFriendly(selfChar.GetId(), targetChar.GetId()).ToInt();
			break;
		case 305:
			result = DomainManager.Character.HasRelation(selfChar.GetId(), targetChar.GetId(), 73).ToInt();
			break;
		case 306:
			result = DomainManager.Character.HasRelation(selfChar.GetId(), targetChar.GetId(), 292).ToInt();
			break;
		case 307:
			result = DomainManager.Character.HasRelation(selfChar.GetId(), targetChar.GetId(), 146).ToInt();
			break;
		case 308:
			result = DomainManager.Character.HasRelation(selfChar.GetId(), targetChar.GetId(), 8192).ToInt();
			break;
		case 309:
			result = DomainManager.Character.HasRelation(selfChar.GetId(), targetChar.GetId(), 448).ToInt();
			break;
		case 310:
			result = DomainManager.Character.HasRelation(selfChar.GetId(), targetChar.GetId(), 1024).ToInt();
			break;
		case 311:
			result = DomainManager.Character.HasRelation(selfChar.GetId(), targetChar.GetId(), 512).ToInt();
			break;
		case 312:
			result = (DomainManager.Character.HasRelation(selfChar.GetId(), targetChar.GetId(), 16384) && DomainManager.Character.HasRelation(targetChar.GetId(), selfChar.GetId(), 16384)).ToInt();
			break;
		case 313:
			result = DomainManager.Character.HasRelation(selfChar.GetId(), targetChar.GetId(), 6144).ToInt();
			break;
		case 314:
			result = (selfChar.GetFactionId() == targetChar.GetFactionId() && selfChar.GetFactionId() >= 0).ToInt();
			break;
		case 315:
			result = (selfChar.GetOrganizationInfo().OrgTemplateId == targetChar.GetOrganizationInfo().OrgTemplateId && selfChar.GetOrganizationInfo().SettlementId == targetChar.GetOrganizationInfo().OrgTemplateId).ToInt();
			break;
		case 316:
			result = IsFromSameArea(selfChar, targetChar).ToInt();
			break;
		case 78:
		{
			IReadOnlyCollection<SecretInformationId> readOnlyCollection = DomainManager.Information.QueryCharacterKnownSecretInformationIds(targetChar.GetId());
			result = (readOnlyCollection != null && readOnlyCollection.Count > 0).ToInt();
			break;
		}
		default:
			throw new ActionPlanningException($"Unimplemented planning state: {stateKey}");
		}
		if (1 == 0)
		{
		}
		return result;
	}

	private bool IsFromSameArea(Character selfChar, Character targetChar)
	{
		short selfFromArea = selfChar.GetBelongMapArea();
		if (selfFromArea < 0)
		{
			return false;
		}
		short targetFromArea = targetChar.GetBelongMapArea();
		return selfFromArea == targetFromArea;
	}
}
