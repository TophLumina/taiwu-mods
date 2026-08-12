using System;
using System.Collections.Generic;
using System.IO;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using GameData.ArchiveData;
using GameData.DLC.CricketPolymorph;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Story.SectMainStory;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class EventConditions
{
	[EventFunction(148)]
	private static ValueInfo CheckCharacterCanTeachTaiwuProfession(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int charId = character.GetId();
		int date = DomainManager.Character.GetCharacterTeachTaiwuProfessionDate(charId);
		bool result = DomainManager.World.GetCurrDate() > date + 12;
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(148, result);
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(163)]
	private static ValueInfo CheckCharacterCanTeachTaiwuProfessionSkillUnlock(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int professionId = parameters[1].GetIntValue(evaluator);
		int charId = character.GetId();
		int unlockedSkillCount = DomainManager.Character.GetCharacterProfessionData(charId, professionId)?.GetUnlockedSkillCount() ?? 0;
		bool result = unlockedSkillCount > 0;
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(163, result);
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(90)]
	private static ValueInfo CheckPreviousCombatResult(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int actualValue = 0;
		if (!runtime.ArgBox.Get("CombatResult", ref actualValue))
		{
			throw new Exception("CheckPreviousCombatResult can only be called after combat.");
		}
		int requiredValue = parameters[0].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(requiredValue == actualValue);
	}

	[EventFunction(473)]
	private static ValueInfo CheckPreviousCombatType(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int actualValue = 0;
		if (!runtime.ArgBox.Get("CombatType", ref actualValue))
		{
			throw new Exception("CheckPreviousCombatResult can only be called after combat.");
		}
		int requiredValue = parameters[0].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(requiredValue == actualValue);
	}

	[EventFunction(339)]
	private static ValueInfo CheckPreviousSimulateCombatResult(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte npcCombatResultType = 0;
		if (!runtime.ArgBox.Get("NpcCombatResultType", ref npcCombatResultType))
		{
			throw new Exception("CheckPreviousSimulateCombatResult can only be called after combat.");
		}
		int requiredValue = parameters[0].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(requiredValue == npcCombatResultType);
	}

	public static bool PerformOperation(int operatorId, int currValue, int requiredValue)
	{
		if (1 == 0)
		{
		}
		bool result = operatorId switch
		{
			0 => currValue == requiredValue, 
			1 => currValue != requiredValue, 
			2 => currValue > requiredValue, 
			3 => currValue < requiredValue, 
			4 => currValue >= requiredValue, 
			5 => currValue <= requiredValue, 
			_ => throw new Exception($"Invalid operator {operatorId} for current condition"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	[EventFunction(423)]
	private static ValueInfo CheckGlobalArgBox(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		string keyInGlobalArgBox = parameters[0].GetStringValue(evaluator);
		string tempArgKey = parameters[1].GetStringValue(evaluator);
		EventArgBox argBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		ValueInfo valueInfo = argBox.SelectValue(evaluator, keyInGlobalArgBox);
		if (valueInfo.ValueType == EValueType.Void)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		if (string.IsNullOrEmpty(tempArgKey))
		{
			evaluator.RemoveTopValue(valueInfo);
			return evaluator.PushEvaluationResult(value: true);
		}
		runtime.ArgBox.SetValueFromStack(evaluator.EvaluationStack, tempArgKey, valueInfo.ValueType);
		return evaluator.PushEvaluationResult(value: true);
	}

	[EventFunction(190)]
	private static ValueInfo CheckSettlementApprovingRate(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		Settlement settlement = parameters[0].GetAnyValue<Settlement>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		short approvingRate = settlement.CalcApprovingRate();
		bool result = PerformOperation(operatorId, approvingRate, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(560)]
	private static ValueInfo CheckSettlementApprovingRateUpperLimit(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		Settlement settlement = parameters[0].GetAnyValue<Settlement>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		int approvingRateUpperLimit = settlement.GetApprovingRateUpperLimit();
		bool result = PerformOperation(operatorId, approvingRateUpperLimit, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(193)]
	private static ValueInfo CheckStateHasSettlementType(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte stateTemplateId = (sbyte)parameters[0].GetIntValue(evaluator);
		EOrganizationSettlementType settlementType = (EOrganizationSettlementType)parameters[1].GetIntValue(evaluator);
		sbyte stateId = DomainManager.Map.GetStateIdByStateTemplateId(stateTemplateId);
		List<short> settlementIds = ObjectPool<List<short>>.Instance.Get();
		DomainManager.Map.GetStateSettlementIds(stateId, settlementIds, containsMainCity: true, containsSect: true);
		if (settlementType != EOrganizationSettlementType.Invalid)
		{
			for (int i = settlementIds.Count - 1; i >= 0; i--)
			{
				short settlementId = settlementIds[i];
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
				if (settlement.OrganizationConfig.SettlementType == settlementType)
				{
					ObjectPool<List<short>>.Instance.Return(settlementIds);
					return evaluator.PushEvaluationResult(value: true);
				}
			}
			ObjectPool<List<short>>.Instance.Return(settlementIds);
			return evaluator.PushEvaluationResult(value: false);
		}
		bool hasAny = settlementIds.Count > 0;
		ObjectPool<List<short>>.Instance.Return(settlementIds);
		return evaluator.PushEvaluationResult(hasAny);
	}

	[EventFunction(202)]
	private static ValueInfo CheckAdventureTemplate(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureTemplateIdA = parameters[0].GetIntValue(evaluator);
		int adventureTemplateIdB = parameters[1].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(adventureTemplateIdA == adventureTemplateIdB);
	}

	[EventFunction(170)]
	private static ValueInfo CheckMovePoint(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int operatorId = parameters[0].GetIntValue(evaluator);
		int requiredValue = parameters[1].GetIntValue(evaluator);
		int movePoint = DomainManager.Extra.GetTotalActionPointsRemaining();
		bool result = PerformOperation(operatorId, movePoint, requiredValue);
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(170, result, EventConditionOperator.Instance[operatorId].Name, (requiredValue / 10).ToString());
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(171)]
	private static ValueInfo CheckCurrMonth(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int operatorId = parameters[0].GetIntValue(evaluator);
		int requiredValue = parameters[1].GetIntValue(evaluator);
		sbyte currMonth = DomainManager.World.GetCurrMonthInYear();
		bool result = PerformOperation(operatorId, currMonth, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(446)]
	private static ValueInfo CheckTotalMonth(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int operatorId = parameters[0].GetIntValue(evaluator);
		int requiredValue = parameters[1].GetIntValue(evaluator);
		int currDate = DomainManager.World.GetCurrDate();
		bool result = PerformOperation(operatorId, currDate, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(177)]
	private static ValueInfo CheckCharacterTeammateSpecificIdId(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		short characterTemplateId = (short)parameters[1].GetIntValue(evaluator);
		if (character.IsInTaiwuGroup())
		{
			List<int> specialGroup = DomainManager.Taiwu.GetTaiwuSpecialGroup();
			foreach (int charId in specialGroup)
			{
				if (!DomainManager.Character.TryGetElement_Objects(charId, out var groupCharacter) || groupCharacter.Template.TemplateId != characterTemplateId)
				{
					continue;
				}
				return evaluator.PushEvaluationResult(value: true);
			}
			HashSet<int> groupCharIds = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
			foreach (int charId2 in groupCharIds)
			{
				if (!DomainManager.Character.TryGetElement_Objects(charId2, out var groupCharacter2) || groupCharacter2.Template.TemplateId != characterTemplateId)
				{
					continue;
				}
				return evaluator.PushEvaluationResult(value: true);
			}
		}
		else
		{
			int leaderId = character.GetLeaderId();
			HashSet<int> group = DomainManager.Character.GetGroup(leaderId).GetCollection();
			foreach (int charId3 in group)
			{
				if (!DomainManager.Character.TryGetElement_Objects(charId3, out var groupCharacter3) || groupCharacter3.Template.TemplateId != characterTemplateId)
				{
					continue;
				}
				return evaluator.PushEvaluationResult(value: true);
			}
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(178)]
	private static ValueInfo CheckCharacterExp(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		int exp = character.GetExp();
		bool result = PerformOperation(operatorId, exp, requiredValue);
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(178, result, string.Empty, EventConditionOperator.Instance[operatorId].Name, requiredValue.ToString());
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(180)]
	private static ValueInfo CheckCharacterCombatSkillBreakout(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int combatSkillTemplateId = parameters[1].GetIntValue(evaluator);
		bool result = false;
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> charCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(character.GetId());
		foreach (var (skillTemplateId, skill) in charCombatSkills)
		{
			if (skillTemplateId == combatSkillTemplateId)
			{
				ushort activationState = skill.GetActivationState();
				result = CombatSkillStateHelper.IsBrokenOut(activationState);
			}
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(331)]
	private static ValueInfo CheckWuxianWugJugPoison(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int operatorId = parameters[0].GetIntValue(evaluator);
		int requiredValue = parameters[1].GetIntValue(evaluator);
		SectWuxianWugJugData jugData = DomainManager.Extra.GetSectWuxianWugJugPoisons();
		int value = jugData.TotalPoison;
		bool result = PerformOperation(operatorId, value, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(341)]
	private static ValueInfo CheckSectMainStoryEnding(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte orgTemplateId = (sbyte)parameters[0].GetIntValue(evaluator);
		int requireStatus = parameters[1].GetIntValue(evaluator);
		sbyte status = DomainManager.Story.GetSectMainStoryTaskStatus(orgTemplateId);
		return evaluator.PushEvaluationResult(status == requireStatus);
	}

	[EventFunction(390)]
	private static ValueInfo CheckUsedFuyuSwordInCombat(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		bool saveChar = false;
		runtime.ArgBox.Get("UsedFuyuSwordInCombat", ref saveChar);
		return evaluator.PushEvaluationResult(saveChar);
	}

	[EventFunction(71)]
	private static ValueInfo CheckExpression(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		bool value = parameters[0].GetBoolValue(evaluator);
		return evaluator.PushEvaluationResult(value);
	}

	[EventFunction(109)]
	private static ValueInfo CheckAnd(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		return runtime.Evaluator.PushEvaluationResult(value: true);
	}

	[EventFunction(110)]
	private static ValueInfo CheckOr(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		return runtime.Evaluator.PushEvaluationResult(value: true);
	}

	[EventFunction(641)]
	private static ValueInfo SettlementHasBuilding(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		Settlement settlement = parameters[0].GetAnyValue<Settlement>(evaluator);
		short buildingTemplateId = (short)parameters[1].GetIntValue(evaluator);
		bool checkUsable = parameters[2].GetBoolValue(evaluator);
		Location location = settlement.GetLocation();
		BuildingAreaData buildingArea = DomainManager.Building.GetBuildingAreaData(settlement.GetLocation());
		BuildingBlockData buildingBlockData = BuildingDomain.FindBuilding(location, buildingArea, buildingTemplateId, checkUsable);
		return evaluator.PushEvaluationResult(buildingBlockData != null);
	}

	[EventFunction(784)]
	private static ValueInfo EventTriggerParameterIsBuildingBlockTemplate(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int parameterId = parameters[0].GetIntValue(evaluator);
		string parameterKey = EventTriggerParameter.Instance[parameterId].ArgBoxKey;
		short buildingTemplateId = (short)parameters[1].GetIntValue(evaluator);
		int intVal = 0;
		if (runtime.ArgBox.Get(parameterKey, ref intVal))
		{
			return evaluator.PushEvaluationResult(intVal == buildingTemplateId);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(159)]
	private static ValueInfo CheckCharacterAlive(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		ValueInfo valueInfo = parameters[0].Evaluate(evaluator);
		switch (valueInfo.ValueType)
		{
		case EValueType.Int:
		{
			int charId = evaluator.EvaluationStack.PopUnmanaged<int>();
			return evaluator.PushEvaluationResult(DomainManager.Character.IsCharacterAlive(charId));
		}
		case EValueType.Obj:
		{
			GameData.Domains.Character.Character character = evaluator.EvaluationStack.PopObject<GameData.Domains.Character.Character>();
			return evaluator.PushEvaluationResult(character != null);
		}
		default:
			throw new ArgumentException($"Unrecognized argument type: Character expected, {valueInfo.ValueType} given.");
		}
	}

	[EventFunction(213)]
	private static ValueInfo CheckCharacterPassMatcher(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		ValueInfo arg0 = parameters[0].Evaluate(evaluator);
		GameData.Domains.Character.Character character;
		switch (arg0.ValueType)
		{
		case EValueType.Int:
		{
			int charId = evaluator.EvaluationStack.PopUnmanaged<int>();
			DomainManager.Character.TryGetElement_Objects(charId, out character);
			break;
		}
		case EValueType.Obj:
		{
			object obj = evaluator.EvaluationStack.PopObject<object>();
			if (obj != null && !(obj is EventActorData) && !(obj is GameData.Domains.Character.Character))
			{
				throw new InvalidCastException($"Unrecognized argument type {obj.GetType()}.");
			}
			character = obj as GameData.Domains.Character.Character;
			break;
		}
		default:
			throw new InvalidCastException($"Unrecognized argument type {arg0.ValueType}.");
		}
		if (character == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		int matcherId = parameters[1].GetIntValue(evaluator);
		CharacterMatcherItem matcher = CharacterMatcher.Instance[matcherId];
		bool result = matcher.Match(character);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(76)]
	private static ValueInfo CheckCharacterCurrMainAttribute(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int mainAttributeType = parameters[1].GetIntValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		short currValue = character.GetCurrMainAttribute((sbyte)mainAttributeType);
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(77)]
	private static ValueInfo CheckCharacterMainAttribute(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int mainAttributeType = parameters[1].GetIntValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		short currValue = character.GetMaxMainAttribute((sbyte)mainAttributeType);
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(78)]
	private static ValueInfo CheckCharacterLifeSkillQualification(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int lifeSkillType = parameters[1].GetIntValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		short currValue = character.GetLifeSkillQualification((sbyte)lifeSkillType);
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(79)]
	private static ValueInfo CheckCharacterLifeSkillAttainment(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int lifeSkillType = parameters[1].GetIntValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		short currValue = character.GetLifeSkillAttainment((sbyte)lifeSkillType);
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(79, result, Config.LifeSkillType.Instance[lifeSkillType].Name, EventConditionOperator.Instance[operatorId].Name, requiredValue.ToString());
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(80)]
	private static ValueInfo CheckCharacterCombatSkillQualification(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int combatSkillType = parameters[1].GetIntValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		short currValue = character.GetCombatSkillQualification((sbyte)combatSkillType);
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(81)]
	private static ValueInfo CheckCharacterCombatSkillAttainment(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int combatSkillType = parameters[1].GetIntValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		short currValue = character.GetCombatSkillAttainment((sbyte)combatSkillType);
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(82)]
	private static ValueInfo CheckCharacterPersonality(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int personalityType = parameters[1].GetIntValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		sbyte currValue = character.GetPersonality((sbyte)personalityType);
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(107)]
	private static ValueInfo CheckCharacterBehaviorType(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int expectedBehaviorType = parameters[1].GetIntValue(evaluator);
		sbyte currBehaviorType = character.GetBehaviorType();
		return evaluator.PushEvaluationResult(expectedBehaviorType == currBehaviorType);
	}

	[EventFunction(108)]
	private static ValueInfo CheckMorality(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		short currValue = character.GetMorality();
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(83)]
	private static ValueInfo CheckCharacterResource(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int resourceType = parameters[1].GetIntValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		int currValue = character.GetResource((sbyte)resourceType);
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(85)]
	private static ValueInfo CheckCharacterInventoryByTemplate(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		TemplateKey templateKey = parameters[1].GetAnyValue<UnmanagedVariant<TemplateKey>>(evaluator).Value;
		bool ret = character.GetInventory().GetInventoryItemKey(templateKey.ItemType, templateKey.TemplateId).IsValid();
		return evaluator.PushEvaluationResult(ret);
	}

	[EventFunction(84)]
	private static ValueInfo CheckCharacterFeature(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		short featureId = (short)parameters[1].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(character.GetFeatureIds().Contains(featureId));
	}

	[EventFunction(140)]
	private static ValueInfo CheckCharacterCurrentProfession(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int professionId = parameters[1].GetIntValue(evaluator);
		int actualProfessionId = DomainManager.Character.GetCharacterCurrentProfession(character.GetId())?.TemplateId ?? (-1);
		return evaluator.PushEvaluationResult(actualProfessionId == professionId);
	}

	[EventFunction(146)]
	private static ValueInfo TryGetCharacterCurrentProfession(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int characterId = parameters[0].GetIntValue(evaluator);
		string tempArgKey = parameters[1].GetStringValue(evaluator);
		ProfessionData profession = DomainManager.Character.GetCharacterCurrentProfession(characterId);
		if (string.IsNullOrEmpty(tempArgKey))
		{
			return evaluator.PushEvaluationResult(profession != null);
		}
		runtime.ArgBox.Set(tempArgKey, profession?.TemplateId ?? (-1));
		return evaluator.PushEvaluationResult(profession != null);
	}

	[EventFunction(141)]
	private static ValueInfo CheckCharacterSeniorityPercent(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int professionId = parameters[1].GetIntValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		int actualValue = ((professionId >= 0) ? DomainManager.Character.GetCharacterProfessionData(character.GetId(), professionId) : DomainManager.Character.GetCharacterCurrentProfession(character.GetId()))?.GetSeniorityPercent() ?? 0;
		bool result = PerformOperation(operatorId, actualValue, requiredValue);
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(141, result, string.Empty, (professionId >= 0) ? Profession.Instance[professionId].Name : string.Empty, EventConditionOperator.Instance[operatorId].Name, requiredValue.ToString());
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(103)]
	private static ValueInfo CheckCharacterGrade(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		bool result = PerformOperation(operatorId, character.GetOrganizationInfo().Grade, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(104)]
	private static ValueInfo CheckCharacterSettlement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		Settlement settlement = parameters[1].GetAnyValue<Settlement>(evaluator);
		if (settlement == null)
		{
			return evaluator.PushEvaluationResult(character.GetOrganizationInfo().SettlementId < 0);
		}
		return evaluator.PushEvaluationResult(character.GetOrganizationInfo().SettlementId == settlement.GetId());
	}

	[EventFunction(86)]
	private static ValueInfo CheckCharacterOnSettlementBlock(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		Settlement settlement = parameters[1].GetAnyValue<Settlement>(evaluator);
		if (character == null || settlement == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		short settlementId = settlement.GetId();
		Location location = character.GetValidLocation();
		bool result = DomainManager.Map.IsLocationOnSettlementBlock(location, settlementId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(87)]
	private static ValueInfo CheckCharacterInSettlementInfluenceRange(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		Settlement settlement = parameters[1].GetAnyValue<Settlement>(evaluator);
		Location location = character.GetValidLocation();
		short settlementId = settlement.GetId();
		bool result = DomainManager.Map.IsLocationInSettlementInfluenceRange(location, settlementId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(168)]
	private static ValueInfo CheckCharacterInMapBlockRange(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		if (character == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		Location characterLocation = character.GetLocation();
		if (!character.GetLocation().IsValid())
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		MapBlockData targetBlock = parameters[1].GetAnyValue<MapBlockData>(evaluator);
		if (targetBlock == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		Location targetLocation = targetBlock.GetLocation();
		int distance = parameters[2].GetIntValue(evaluator);
		bool result = characterLocation.IsNearbyLocation(targetLocation, distance);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(638)]
	private static ValueInfo CheckCharacterOnMapBlockTemplate(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int mapBlockTemplateId = parameters[1].GetIntValue(evaluator);
		Location location = character.GetValidLocation();
		MapBlockData mapBlock = DomainManager.Map.GetBlock(location);
		bool result = mapBlockTemplateId == mapBlock.TemplateId;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(95)]
	private static ValueInfo CheckCharacterInMapState(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int stateTemplateId = parameters[1].GetIntValue(evaluator);
		Location location = character.GetValidLocation();
		sbyte charStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
		bool result = stateTemplateId == charStateTemplateId;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(96)]
	private static ValueInfo CheckCharacterInMapArea(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		MapAreaData expectedAreaData = parameters[1].GetAnyValue<MapAreaData>(evaluator);
		Location location = character.GetValidLocation();
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(location.AreaId);
		bool result = areaData == expectedAreaData;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(520)]
	private static ValueInfo CheckCharacterInBrokenArea(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		bool result = MapAreaData.IsBrokenArea(character.GetValidLocation().AreaId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(97)]
	private static ValueInfo CheckCharacterOnAnySettlement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		Location location = character.GetValidLocation();
		MapBlockData rootBlock = DomainManager.Map.GetBlock(location).GetRootBlock();
		bool result = rootBlock.IsCityTown();
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(98)]
	private static ValueInfo CheckCharacterInAnySettlementInfluenceRange(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		Location location = character.GetValidLocation();
		MapBlockData belongSettlementBlock = DomainManager.Map.GetBelongSettlementBlock(location);
		bool result = belongSettlementBlock != null;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(194)]
	private static ValueInfo CheckCharacterInSettlementArea(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		Settlement settlement = parameters[1].GetAnyValue<Settlement>(evaluator);
		bool result = character.GetValidLocation().AreaId == settlement.GetLocation().AreaId;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(88)]
	private static ValueInfo CheckCharacterFavorability(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		GameData.Domains.Character.Character relatedChar = parameters[1].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		short currValue = DomainManager.Character.GetFavorability(character.GetId(), relatedChar.GetId());
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(142)]
	private static ValueInfo CheckCharacterFavorabilityType(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		GameData.Domains.Character.Character relatedChar = parameters[1].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		sbyte currValue = DomainManager.Character.GetFavorabilityType(character.GetId(), relatedChar.GetId());
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(142, result, string.Empty, string.Empty, EventConditionOperator.Instance[operatorId].Name, $"<Language Key=LK_Favor_Type_{requiredValue - -6}/>");
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(878)]
	private static ValueInfo CheckCharacterFavorabilityTypeForExchangeBook(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		if (character == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		sbyte favorType = DomainManager.Character.GetFavorabilityType(character.GetId(), taiwuCharId);
		sbyte requiredFavorType = GetExchangeBookRequiredFavorabilityType(character.GetBehaviorType());
		bool result = favorType >= requiredFavorType;
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(878, result, $"<Language Key=LK_Favor_Type_{requiredFavorType - -6}/>");
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(888)]
	private static ValueInfo CheckCharacterAlertnessForTeach(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		if (character == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		bool result = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsMeetsAlertnessLevelOnTaiwuGetTaught(character.GetId());
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(888, result, $"<Language Key=LK_Alertness_Level_{3}/>");
		}
		return evaluator.PushEvaluationResult(result);
	}

	private static sbyte GetExchangeBookRequiredFavorabilityType(sbyte behaviorType)
	{
		if (1 == 0)
		{
		}
		sbyte result = behaviorType switch
		{
			0 => 6, 
			1 => 4, 
			2 => 3, 
			3 => 2, 
			4 => 5, 
			_ => 3, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	[EventFunction(121)]
	private static ValueInfo CheckCharacterHasItem(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		UnmanagedVariant<TemplateKey> templateKey = parameters[1].GetAnyValue<UnmanagedVariant<TemplateKey>>(evaluator);
		Inventory inventory = character.GetInventory();
		bool result = inventory.GetInventoryItemKey(templateKey.Value.ItemType, templateKey.Value.TemplateId).IsValid() || character.HasEquippedItem(templateKey.Value.ItemType, templateKey.Value.TemplateId);
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(121, result, ItemTemplateHelper.GetName(templateKey.Value.ItemType, templateKey.Value.TemplateId));
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(449)]
	private static ValueInfo CheckCharacterHasItemType(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int expectedItemType = parameters[1].GetIntValue(evaluator);
		Inventory inventory = character.GetInventory();
		int count = inventory.GetInventoryItemTypeCount((sbyte)expectedItemType);
		return evaluator.PushEvaluationResult(count > 0);
	}

	[EventFunction(122)]
	private static ValueInfo CheckCharacterMerchantType(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int merchantType = parameters[1].GetIntValue(evaluator);
		sbyte expectedMerchantType = DomainManager.Extra.GetMerchantCharToType(character.GetId());
		return evaluator.PushEvaluationResult(merchantType == expectedMerchantType);
	}

	[EventFunction(157)]
	private static ValueInfo CheckCharacterConsummateLevel(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		sbyte actualValue = character.GetConsummateLevel();
		bool result = PerformOperation(operatorId, actualValue, requiredValue);
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(157, result, string.Empty, EventConditionOperator.Instance[operatorId].Name, requiredValue.ToString());
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(160)]
	private static ValueInfo CheckCharacterCurrAge(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		short actualValue = character.GetCurrAge();
		bool result = PerformOperation(operatorId, actualValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(161)]
	private static ValueInfo CheckCharacterActualAge(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		short actualValue = character.GetActualAge();
		bool result = PerformOperation(operatorId, actualValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(162)]
	private static ValueInfo CheckCharacterAgeGroup(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		sbyte actualValue = character.GetAgeGroup();
		bool result = PerformOperation(operatorId, actualValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(203)]
	private static ValueInfo CheckCharacterGender(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int requiredValue = parameters[1].GetIntValue(evaluator);
		bool result = character.GetGender() == requiredValue;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(128)]
	private static ValueInfo CheckFixedCharacterTemplate(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int templateId = parameters[1].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(character.GetTemplateId() == templateId);
	}

	[EventFunction(131)]
	private static ValueInfo CheckCharacterReadLifeSkillPageCount(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int lifeSkillTemplateId = parameters[1].GetIntValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		List<GameData.Domains.Character.LifeSkillItem> learnedLifeSkills = character.GetLearnedLifeSkills();
		int lifeSkillIndex = character.FindLearnedLifeSkillIndex((short)lifeSkillTemplateId);
		int actualValue = ((lifeSkillIndex >= 0) ? learnedLifeSkills[lifeSkillIndex].GetReadPagesCount() : 0);
		bool result = PerformOperation(operatorId, actualValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(179)]
	private static ValueInfo CheckCharacterReadCombatSkillPageCount(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		short combatSkillTemplateId = (short)parameters[1].GetIntValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		CombatSkillKey combatSkillKey = new CombatSkillKey(character.GetId(), combatSkillTemplateId);
		GameData.Domains.CombatSkill.CombatSkill element;
		ushort readingState = (DomainManager.CombatSkill.TryGetElement_CombatSkills(combatSkillKey, out element) ? element : null)?.GetReadingState() ?? 0;
		int actualValue = CombatSkillStateHelper.GetCanActivateNormalPagesCount(readingState) + (CombatSkillStateHelper.HasReadOutlinePages(readingState) ? 1 : 0);
		bool result = PerformOperation(operatorId, actualValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(375)]
	private static ValueInfo CheckLovingItemSubType(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int itemSubType = parameters[1].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(character.GetLovingItemSubType() == itemSubType);
	}

	[EventFunction(376)]
	private static ValueInfo CheckHatingItemSubType(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int itemSubType = parameters[1].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(character.GetHatingItemSubType() == itemSubType);
	}

	[EventFunction(257)]
	private static ValueInfo CheckTaiwuHasFuyuFaith(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int operatorId = parameters[0].GetIntValue(evaluator);
		int requiredValue = parameters[1].GetIntValue(evaluator);
		bool result = PerformOperation(operatorId, DomainManager.Character.GetFuyuFaith(), requiredValue);
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(257, result, EventConditionOperator.Instance[operatorId].Name, requiredValue.ToString());
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(258)]
	private static ValueInfo CheckCharacterFuyuFaith(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		bool result = PerformOperation(operatorId, character.GetDarkAshCounter().Tips3, requiredValue);
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(258, result, DomainManager.Character.GetName(character.GetId()), EventConditionOperator.Instance[operatorId].Name, requiredValue.ToString());
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(256)]
	private static ValueInfo TryGetMaxAcceptableFuyuFaith(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		string key = parameters[1].GetStringValue(evaluator);
		runtime.ArgBox.Set(key, GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetMaxAcceptableFuyuFaith(character));
		return evaluator.PushEvaluationResult(value: true);
	}

	[EventFunction(400)]
	private static ValueInfo CheckCharacterEatingWugKing(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		bool result = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsCharacterEatingWugKing(character.GetId());
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(399)]
	private static ValueInfo CheckEventActorTemplate(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		EventActorData actorData = parameters[0].GetAnyValue<EventActorData>(evaluator);
		int templateId = parameters[1].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(actorData.TemplateId == templateId);
	}

	[EventFunction(426)]
	private static ValueInfo CheckCharacterInjuryCount(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		int sumInjury = character.GetInjuries().GetSum();
		bool result = PerformOperation(operatorId, sumInjury, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(442)]
	private static ValueInfo CheckHarmfulActionPhase(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int actualValue = parameters[0].GetIntValue(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		bool result = PerformOperation(operatorId, actualValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(456)]
	private static ValueInfo CheckDisorderOfQi(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		short actualValue = character.GetDisorderOfQi();
		bool result = PerformOperation(operatorId, actualValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(493)]
	private static ValueInfo CanStartRelationHusbandOrWife(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character selfChar = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		GameData.Domains.Character.Character targetChar = parameters[1].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		RelatedCharacter selfToTarget = DomainManager.Character.GetRelation(selfChar.GetId(), targetChar.GetId());
		RelatedCharacter targetToSelf = DomainManager.Character.GetRelation(targetChar.GetId(), selfChar.GetId());
		selfToTarget.Favorability = 30000;
		bool result = AiHelper.Relation.CanStartRelation_HusbandOrWife(selfChar.GetId(), selfToTarget, selfChar.GetBehaviorType(), targetChar.GetId(), targetToSelf, targetChar.GetBehaviorType());
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(493, result);
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(515)]
	private static ValueInfo TryGetFixedCharacter(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		short charTemplateId = (short)parameters[0].GetIntValue(evaluator);
		string argBoxKey = parameters[1].GetStringValue(evaluator);
		GameData.Domains.Character.Character character;
		bool result = DomainManager.Character.TryGetFixedCharacterByTemplateId(charTemplateId, out character);
		if (result)
		{
			runtime.ArgBox.Set(argBoxKey, character.GetId());
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(516)]
	private static ValueInfo CheckCharacterOnValidLocation(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		return evaluator.PushEvaluationResult(character.GetLocation().IsValid());
	}

	[EventFunction(539)]
	private static bool HasRelation(EventScriptRuntime runtime, GameData.Domains.Character.Character self, GameData.Domains.Character.Character target, ushort relationType)
	{
		return DomainManager.Character.HasRelation(self.GetId(), target.GetId(), relationType);
	}

	[EventFunction(548)]
	private static bool CheckInteractionCooldown(EventScriptRuntime runtime, GameData.Domains.Character.Character character, short templateId)
	{
		bool result = DomainManager.TaiwuEvent.IsInteractionEventOptionOffCooldown(character.GetId(), templateId);
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(548, result);
		}
		return result;
	}

	[EventFunction(835)]
	private static bool CheckInteractionMonthCooldown(EventScriptRuntime runtime, GameData.Domains.Character.Character character, short templateId)
	{
		int leftMonth = DomainManager.Extra.GetTaiwuInteractionCooldown(character.GetId(), templateId);
		bool result = leftMonth <= 0;
		if (runtime.RecordingConditionHints && !result)
		{
			runtime.RecordConditionHint(835, result, string.Empty, string.Empty, leftMonth.ToString());
		}
		return result;
	}

	[EventFunction(567)]
	private static bool CheckCharacterNeiliTypeConflictCombatSkill(GameData.Domains.Character.Character character, short skillTemplateId)
	{
		CombatSkillItem skillCfg = Config.CombatSkill.Instance[skillTemplateId];
		return Equipping.CheckCounterWithNeiliType(skillCfg.FiveElements, character.GetNeiliType());
	}

	[EventFunction(578)]
	private static ValueInfo CheckCharacterAvailableEatingSlotsCount(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		EatingItems eatingItems = character.GetEatingItems();
		int availableCount = eatingItems.GetAvailableEatingSlotsCount(character.GetCurrMaxEatingSlotsCount());
		bool result = PerformOperation(operatorId, availableCount, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(604)]
	private static ValueInfo CheckTaiwuHaveReadingBook(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		bool result = DomainManager.Taiwu.GetCurReadingBook().IsValid();
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(604, result);
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(642)]
	private static ValueInfo CheckCharacterLoopingNeigong(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int loopingNeigongId = parameters[1].GetIntValue(evaluator);
		bool result = loopingNeigongId == character.GetLoopingNeigong();
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(625)]
	private static ValueInfo CheckCharacterEquipItemTemplate(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		TemplateKey itemTemplate = parameters[1].GetAnyValue<UnmanagedVariant<TemplateKey>>(evaluator).Value;
		ItemKey[] equipments = character.GetEquipment();
		bool result = false;
		ItemKey[] array = equipments;
		for (int i = 0; i < array.Length; i++)
		{
			ItemKey equipment = array[i];
			if (equipment.ItemType == itemTemplate.ItemType && equipment.TemplateId == itemTemplate.TemplateId)
			{
				result = true;
				break;
			}
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(655)]
	private static ValueInfo CheckProfessionSkill(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int skillA = parameters[0].GetIntValue(evaluator);
		int skillB = parameters[1].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(skillA == skillB);
	}

	[EventFunction(702)]
	private static ValueInfo CheckInventoryItem(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		ItemKey item = parameters[1].GetAnyValue<ItemKey>(evaluator);
		if (!item.IsValid())
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		Inventory inventory = character.GetInventory();
		bool result = inventory.GetInventoryItemCount(item) > 0;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(716)]
	private static ValueInfo CheckCharacterIntelligent(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		bool includeTemporary = parameters[1].GetBoolValue(evaluator);
		bool isTemporary = DomainManager.Character.IsTemporaryIntelligentCharacter(character.GetId());
		bool isIntelligentCharacter = character.GetCreatingType() == 1;
		bool result = false;
		result = ((!includeTemporary) ? (!isTemporary && isIntelligentCharacter) : isIntelligentCharacter);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(728)]
	private static ValueInfo TaiwuGroupFull(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		bool result = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsTaiwuGroupFull();
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(728, !result);
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(764)]
	private static ValueInfo AnySelectableFilteredCharacter(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte selectRange = (sbyte)parameters[0].GetIntValue(evaluator);
		short matcherId = (short)parameters[1].GetIntValue(evaluator);
		bool result = ScriptExecutionInstance.AnySelectableFilteredCharacter(selectRange, matcherId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(786)]
	private static void AddFuyuFaith(EventScriptRuntime runtime, int addAmount)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFuyuFaith(addAmount, showNotification: true);
	}

	[EventFunction(884)]
	private static ValueInfo IsCricketPolymorph(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		if (character == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		bool result = false;
		short templateId = character.GetTemplateId();
		if (templateId >= 968 && templateId <= 1011)
		{
			result = true;
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(896)]
	private static ValueInfo CheckSettlementHasChicken(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		if (character == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		List<int> list = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetCharacterManagedChickenList(character.GetId());
		bool result = list != null && list.Count > 0;
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(896, result);
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(891)]
	private static ValueInfo IsCharacterFollowingTaiwu(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		if (character == null || character.GetCreatingType() != 0)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		bool result = DomainManager.Character.IsCharacterFollowingTaiwu(character.GetId());
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(892)]
	private static ValueInfo IsProfessionSkillEquipped(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int professionSkillId = parameters[0].GetAnyValue<int>(evaluator);
		bool result = DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(professionSkillId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(898)]
	private static ValueInfo CheckCharacterCombatSkillRatio50(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		bool checkAny = parameters[1].GetAnyValue<bool>(evaluator);
		short skillTemplateId = parameters[2].GetAnyValue<short>(evaluator);
		ArraySegmentList<short> attackSkills = character.GetCombatSkillEquipment().Attack;
		if (checkAny)
		{
			ArraySegmentList<short>.Enumerator enumerator = attackSkills.GetEnumerator();
			while (enumerator.MoveNext())
			{
				short skillId = enumerator.Current;
				if (DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillId), out var anyCombatSkill) && anyCombatSkill.GetCurrInnerRatio() == 50)
				{
					return evaluator.PushEvaluationResult(value: true);
				}
			}
			return evaluator.PushEvaluationResult(value: false);
		}
		GameData.Domains.CombatSkill.CombatSkill combatSkill;
		bool result = attackSkills.IndexOf(skillTemplateId) >= 0 && DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillTemplateId), out combatSkill) && combatSkill.GetCurrInnerRatio() == 50;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(731)]
	public static ValueInfo CheckCricketPolymorphState(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		ItemKey key = parameters[0].GetAnyValue<ItemKey>(evaluator);
		ECricketPolymorphState stateType = (ECricketPolymorphState)parameters[1].GetIntValue(evaluator);
		if (key.ItemType != 11 || !DomainManager.Taiwu.TryGetCricketPolymorph(key.Id, out var polymorph))
		{
			return evaluator.PushEvaluationResult(stateType == ECricketPolymorphState.None);
		}
		return evaluator.PushEvaluationResult(polymorph.ContainsState(stateType));
	}

	[EventFunction(594)]
	private static ValueInfo FinishInformationSelect(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		string saveKey = parameters[0].GetStringValue(evaluator);
		bool result = runtime.ArgBox.ContainsKey(saveKey);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(791)]
	private static ValueInfo TaiwuHaveCheatOnSecretInformation(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		SecretInformationDisplayPackage package = DomainManager.Information.GetCheatOnSecretInformationDisplayPackageForSelections(taiwuCharId, character.GetId());
		bool result = package.SecretInformationDisplayDataList.Count > 0;
		if (runtime.RecordingConditionHints)
		{
			runtime.RecordConditionHint(791, result);
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(136)]
	private static ValueInfo CheckItemType(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		ItemKey itemKey = parameters[0].GetAnyValue<ItemKey>(evaluator);
		int expectedItemType = parameters[1].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(itemKey.ItemType == expectedItemType);
	}

	[EventFunction(137)]
	private static ValueInfo CheckItemSubType(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		ItemKey itemKey = parameters[0].GetAnyValue<ItemKey>(evaluator);
		short actualItemSubType = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
		int expectedItemSubType = parameters[1].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(expectedItemSubType == actualItemSubType);
	}

	[EventFunction(138)]
	private static ValueInfo CheckItemTemplate(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		ItemKey itemKey = parameters[0].GetAnyValue<ItemKey>(evaluator);
		TemplateKey itemTemplate = parameters[1].GetAnyValue<UnmanagedVariant<TemplateKey>>(evaluator).Value;
		return evaluator.PushEvaluationResult(itemTemplate.ItemType == itemKey.ItemType && itemTemplate.TemplateId == itemKey.TemplateId);
	}

	[EventFunction(538)]
	private static ValueInfo CheckItemGrade(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		ItemKey itemKey = parameters[0].GetAnyValue<ItemKey>(evaluator);
		int expectedItemGrade = parameters[1].GetIntValue(evaluator);
		sbyte actualItemGrade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
		return evaluator.PushEvaluationResult(expectedItemGrade == actualItemGrade);
	}

	[EventFunction(620)]
	private static ValueInfo CheckInventoryItemOperationType(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int expected = parameters[0].GetIntValue(evaluator);
		int actual = -1;
		if (!runtime.ArgBox.Get(EventTriggerParameter.DefValue.InventoryItemOperationType, ref actual))
		{
			throw new Exception("OperationType undefined.");
		}
		return evaluator.PushEvaluationResult(expected == actual);
	}

	[EventFunction(733)]
	private static ValueInfo CheckCricketColorId(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		ItemKey key = parameters[0].GetAnyValue<ItemKey>(evaluator);
		if (key.ItemType != 11 || !DomainManager.Item.TryGetElement_Crickets(key.Id, out var cricket))
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		int colorId = parameters[1].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(cricket.GetColorId() == colorId);
	}

	[EventFunction(803)]
	private static ValueInfo CheckCricketWinsCount(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		ItemKey item = parameters[0].GetAnyValue<ItemKey>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		if (!DomainManager.Item.TryGetElement_Crickets(item.Id, out var cricket))
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		short currValue = cricket.GetWinsCount();
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(804)]
	private static ValueInfo CheckCharCricketCount(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		bool alive = parameters[1].GetBoolValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		int currValue = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetCricketCount(character.GetId(), alive);
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(805)]
	private static ValueInfo CheckCricketAlive(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		ItemKey item = parameters[0].GetAnyValue<ItemKey>(evaluator);
		if (!DomainManager.Item.TryGetElement_Crickets(item.Id, out var cricket))
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		bool result = cricket.IsAlive;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(706)]
	private static ValueInfo CheckBlockHasCricket(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		Location location = parameters[0].GetAnyValue<MapBlockData>(evaluator).GetLocation();
		bool result = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckBlockHasCricket(location);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(749)]
	private static ValueInfo TryGetBlockXiangshuAvatar(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		MapBlockData mapBlockData = parameters[0].GetAnyValue<MapBlockData>(evaluator);
		Location location = mapBlockData.GetLocation();
		if (!location.IsValid())
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		MapBlockData block = DomainManager.Map.GetBlock(location);
		if (block?.FixedCharacterSet == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		foreach (int charId in block.FixedCharacterSet)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			if (!XiangshuAvatarIds.IsWeakenedXiangshuAvatar(character.GetTemplateId()))
			{
				continue;
			}
			string key = parameters[1].GetStringValue(evaluator);
			runtime.ArgBox.Set(key, charId);
			return evaluator.PushEvaluationResult(value: true);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(750)]
	private static ValueInfo CheckCharacterIsAnySectMember(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		sbyte orgTemplateId = character.GetOrganizationInfo().OrgTemplateId;
		return evaluator.PushEvaluationResult(Config.Organization.Instance[orgTemplateId].IsSect);
	}

	[EventFunction(751)]
	private static ValueInfo CheckDefeatSwordTombCount(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int operatorId = parameters[0].GetIntValue(evaluator);
		int requiredValue = parameters[1].GetIntValue(evaluator);
		int currValue = DomainManager.World.GetDefeatSwordTombCount();
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(752)]
	private static ValueInfo CheckSectMainStoryTriggerConditions(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte orgTemplateId = (sbyte)parameters[0].GetIntValue(evaluator);
		bool result = DomainManager.Story.CheckSectMainStoryTriggerConditions(orgTemplateId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(757)]
	private static ValueInfo CheckCharacterIsXiangshuAvatar(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		sbyte expectedXiangshuAvatarId = (sbyte)parameters[1].GetIntValue(evaluator);
		sbyte actualXiangshuAvatarId = XiangshuAvatarIds.GetXiangshuAvatarIdByCharacterTemplateId(character.GetTemplateId());
		return evaluator.PushEvaluationResult(expectedXiangshuAvatarId == actualXiangshuAvatarId);
	}

	[EventFunction(843)]
	private static ValueInfo CheckChapter9TaiwuEscapeXiangshuMinionRange(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!location.IsValid())
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		EventArgBox globalArgBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		if (!globalArgBox.Get("CSPreset_Chapter9XiangshuMinionAtLocation", out Location atLocation))
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		bool result = location.GetManhattanDistanceToPos(atLocation) > 2;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(865)]
	private static ValueInfo CharacterInSuxiaImpactRange(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		return evaluator.PushEvaluationResult(CharacterInSuxiaImpactRange(character));
	}

	public static bool CharacterInSuxiaImpactRange(GameData.Domains.Character.Character character)
	{
		TwelveImmortalsItem suxiaConfig = TwelveImmortals.DefValue.Suxia;
		if (!DomainManager.Character.TryGetFixedCharacterByTemplateId(suxiaConfig.Character, out var suxia))
		{
			return false;
		}
		int distance = suxia.GetLocation().GetManhattanDistanceToPos(character.GetLocation());
		return distance <= suxiaConfig.ImpactRange;
	}

	[EventFunction(879)]
	private static ValueInfo EmeiInteractionOneCheck(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		if (character == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(2);
		bool result = !argBox.ContainsKey(SectMainStoryEventArgKey.DefValue.EmeiInteractionOneTriggeredList) || !argBox.Get<IntList>(SectMainStoryEventArgKey.DefValue.EmeiInteractionOneTriggeredList).Items.Contains(character.GetId());
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(880)]
	private static ValueInfo EmeiInteractionTwoCheck(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		if (character == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(2);
		bool result = !argBox.ContainsKey(SectMainStoryEventArgKey.DefValue.EmeiInteractionTwoTriggeredList) || !argBox.Get<IntList>(SectMainStoryEventArgKey.DefValue.EmeiInteractionTwoTriggeredList).Items.Contains(character.GetId());
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(106)]
	private static ValueInfo CheckSettlementInMapArea(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		Settlement settlement = parameters[0].GetAnyValue<Settlement>(evaluator);
		int areaTemplateId = parameters[1].GetIntValue(evaluator);
		if (settlement == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		Location location = settlement.GetLocation();
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(location.AreaId);
		bool result = areaData.GetTemplateId() == areaTemplateId;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(105)]
	private static ValueInfo CheckSettlementInMapState(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		Settlement settlement = parameters[0].GetAnyValue<Settlement>(evaluator);
		int stateTemplateId = parameters[1].GetIntValue(evaluator);
		if (settlement == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		Location location = settlement.GetLocation();
		sbyte settlementStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
		bool result = stateTemplateId == settlementStateTemplateId;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(112)]
	private static ValueInfo CheckAreaSpiritualDebt(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		MapAreaData areaData = parameters[0].GetAnyValue<MapAreaData>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		int spiritualDebt = DomainManager.Extra.GetAreaSpiritualDebt(areaData.GetId());
		bool result = PerformOperation(operatorId, spiritualDebt, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(204)]
	private static ValueInfo CheckAreaHasAdventure(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int areaTemplateId = parameters[0].GetIntValue(evaluator);
		int coreId = parameters[1].GetIntValue(evaluator);
		short areaId = DomainManager.Map.GetAreaIdByAreaTemplateId((short)areaTemplateId);
		bool result = DomainManager.Adventure.QueryAnyActivatedInArea(areaId, coreId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(787)]
	private static ValueInfo CheckAreaHasMajorEvent(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		return CheckAreaHasAdventure(runtime, parameters);
	}

	[EventFunction(517)]
	private static ValueInfo CheckAreaHasAdultGraveOfTargetOrganization(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int areaTemplateId = parameters[0].GetIntValue(evaluator);
		Settlement settlement = parameters[1].GetAnyValue<Settlement>(evaluator);
		short areaId = DomainManager.Map.GetAreaIdByAreaTemplateId((short)areaTemplateId);
		short settlementId = settlement.GetId();
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(areaId);
		Span<MapBlockData> span = areaBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData mapBlockData = span[i];
			if (mapBlockData.GraveSet == null || mapBlockData.GraveSet.Count <= 0)
			{
				continue;
			}
			foreach (int graveId in mapBlockData.GraveSet)
			{
				DomainManager.Character.TryGetElement_Graves(graveId, out var grave);
				DeadCharacter deadCharacter = DomainManager.Character.GetDeadCharacter(grave.GetId());
				if (deadCharacter.OrganizationInfo.SettlementId == settlementId && deadCharacter.GetActualAge() >= 16)
				{
					return evaluator.PushEvaluationResult(value: true);
				}
			}
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(769)]
	private static ValueInfo CheckMapBlockByMatcher(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		MapBlockData mapBlock = parameters[0].GetAnyValue<MapBlockData>(evaluator);
		int matcherId = parameters[1].GetIntValue(evaluator);
		bool result = MapBlockMatcher.Instance[matcherId].Match(mapBlock);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(326)]
	private static ValueInfo CheckSectFunctionStatus(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte orgTemplateId = (sbyte)parameters[0].GetIntValue(evaluator);
		SectFunctionStatuses.SectFunctionStatusType functionStatusType = (SectFunctionStatuses.SectFunctionStatusType)parameters[1].GetIntValue(evaluator);
		Sect sect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId);
		bool result = sect.GetFunctionStatus(functionStatusType);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(674)]
	private static ValueInfo CheckSectCanTeach(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte orgTemplateId = (sbyte)parameters[0].GetIntValue(evaluator);
		short settlementId = DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId).GetId();
		bool result = DomainManager.Organization.GetElement_Sects(settlementId).GetTaiwuExploreStatus() == 2;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(768)]
	private static ValueInfo CheckSettlementTreasuryAlertTime(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		Settlement settlement = parameters[0].GetAnyValue<Settlement>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		byte currValue = settlement.Treasuries.AlertTime;
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(785)]
	private static ValueInfo SectSpiritualDebtInteractionOccurred(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte orgTemplateId = (sbyte)parameters[0].GetIntValue(evaluator);
		bool result = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.HasSectSpiritualDebtInteractionOccurred(orgTemplateId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(897)]
	private static ValueInfo CheckFirstMartialArtTournamentHostSect(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte orgTemplateId = (sbyte)parameters[0].GetIntValue(evaluator);
		bool result = orgTemplateId == DomainManager.Organization.GetFirstTournamentHostTemplateId();
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(636)]
	private static ValueInfo CheckTutorialChapter(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int tutorialChapterId = parameters[0].GetIntValue(evaluator);
		bool result = DomainManager.TutorialChapter.IsInTutorialChapter(tutorialChapterId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(158)]
	private static ValueInfo CheckIsDreamBack(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		return evaluator.PushEvaluationResult(DomainManager.Extra.GetIsDreamBack());
	}

	[Obsolete]
	[EventFunction(72)]
	private static ValueInfo CheckMainStoryProgress(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int operatorId = parameters[0].GetIntValue(evaluator);
		int requiredValue = parameters[1].GetIntValue(evaluator);
		short currValue = DomainManager.World.GetMainStoryLineProgress();
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(155)]
	private static ValueInfo CheckWorldFunctionStatus(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		byte worldFunctionType = (byte)parameters[0].GetIntValue(evaluator);
		bool result = DomainManager.World.GetWorldFunctionsStatus(worldFunctionType);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(73)]
	private static ValueInfo CheckTask(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int taskInfoId = parameters[0].GetIntValue(evaluator);
		bool result = DomainManager.World.IsTaskInProgress(taskInfoId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(586)]
	private static ValueInfo CheckTaskFinished(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int taskInfoId = parameters[0].GetIntValue(evaluator);
		bool result = DomainManager.World.IsTaskFinished(taskInfoId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(74)]
	private static ValueInfo CheckTaskChain(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int taskChainId = parameters[0].GetIntValue(evaluator);
		bool result = DomainManager.World.IsTaskChainInProgress(taskChainId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(75)]
	private static ValueInfo CheckXiangshuLevel(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int operatorId = parameters[0].GetIntValue(evaluator);
		int requiredValue = parameters[1].GetIntValue(evaluator);
		sbyte currValue = DomainManager.World.GetXiangshuLevel();
		bool result = PerformOperation(operatorId, currValue, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(123)]
	private static ValueInfo CheckSectMainStoryValueExists(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte orgTemplateId = (sbyte)parameters[0].GetIntValue(evaluator);
		string sectMainStoryArgKey = parameters[1].GetStringValue(evaluator);
		string tempArgKey = parameters[2].GetStringValue(evaluator);
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(orgTemplateId);
		ValueInfo valueInfo = argBox.SelectValue(evaluator, sectMainStoryArgKey);
		if (valueInfo.ValueType == EValueType.Void)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		if (string.IsNullOrEmpty(tempArgKey))
		{
			evaluator.RemoveTopValue(valueInfo);
			return evaluator.PushEvaluationResult(value: true);
		}
		runtime.ArgBox.SetValueFromStack(evaluator.EvaluationStack, tempArgKey, valueInfo.ValueType);
		return evaluator.PushEvaluationResult(value: true);
	}

	[EventFunction(350)]
	private static ValueInfo CheckGotoOutterWorldCoolDown(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		return runtime.Evaluator.PushEvaluationResult(DomainManager.Character.GetOutterWorldCharacter() < 0);
	}

	[EventFunction(663)]
	private static ValueInfo CheckHasDreamBackArchive(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		return runtime.Evaluator.PushEvaluationResult(File.Exists(GameData.ArchiveData.Common.CurrDreamBackArchivePath));
	}

	[EventFunction(741)]
	private static ValueInfo CheckXiangshuAvatarTaskStatus(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int xiangshuAvatarId = parameters[0].GetIntValue(evaluator);
		int juniorXiangshuTaskStatus = parameters[1].GetIntValue(evaluator);
		XiangshuAvatarTaskStatus status = DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(xiangshuAvatarId);
		return runtime.Evaluator.PushEvaluationResult(status.JuniorXiangshuTaskStatus == juniorXiangshuTaskStatus);
	}

	[EventFunction(754)]
	private static ValueInfo IsExorcismNeedToBeDisabled(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		bool result = DomainManager.World.GetExorcismEnabled() && DomainManager.Taiwu.GetTaiwu().GetConsummateLevel() >= 4;
		return runtime.Evaluator.PushEvaluationResult(result);
	}

	[EventFunction(756)]
	private static ValueInfo GetExorcismEnabled(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		bool result = DomainManager.World.GetExorcismEnabled();
		return runtime.Evaluator.PushEvaluationResult(result);
	}
}
