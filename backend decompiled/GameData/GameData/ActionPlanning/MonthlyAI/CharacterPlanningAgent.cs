using System;
using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.ActionPlanning.MonthlyAI.Sensor;
using GameData.ActionPlanning.State;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Map;
using GameData.Domains.Taiwu.Profession;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.ActionPlanning.MonthlyAI;

public class CharacterPlanningAgent : IAgent<GameData.Domains.Character.Character, StateKey>
{
	public DataContext Context;

	private ISensor<IStateMemory<GameData.Domains.Character.Character, StateKey>, GameData.Domains.Character.Character, StateKey>[] _sensors;

	private readonly List<GameData.Domains.Character.Character> _selectableCharacters = new List<GameData.Domains.Character.Character>();

	private readonly TempListContainer<int> _targetCharIds = new TempListContainer<int>();

	private PlanningActionNode _currPlanningAction;

	private PlanningGoalNode _currPlanningGoal;

	private ContextArgGroupHandle _actionContextArgs;

	private readonly Predicate<GameData.Domains.Character.Character> _actionTargetCharMatcher;

	private int _taiwuPrioritizedChance;

	public GameData.Domains.Character.Character Object { get; private set; } = null;

	public IGoal<GameData.Domains.Character.Character, StateKey> Goal { get; private set; } = null;

	public IList<INode<GameData.Domains.Character.Character, StateKey>> Plan { get; } = new List<INode<GameData.Domains.Character.Character, StateKey>>();

	public IPathfinder<GameData.Domains.Character.Character, StateKey> Pathfinder { get; }

	public IStateMemory<GameData.Domains.Character.Character, StateKey> Memory { get; } = new CharacterStateMemory();

	public CharacterPlanningAgent(CharacterActionPlanner planner)
	{
		Pathfinder = new WeightBasedPathfinder<CharacterStateMemory, GameData.Domains.Character.Character, StateKey>(planner);
		_actionTargetCharMatcher = MatchTargetCharacter;
		_sensors = new ISensor<IStateMemory<GameData.Domains.Character.Character, StateKey>, GameData.Domains.Character.Character, StateKey>[12];
		RegisterSensor(EPlanningStateSensorType.TriggerStateSensor, new TriggerStateSensor());
		RegisterSensor(EPlanningStateSensorType.CharacterStateSensor, new CharacterStateSensor());
		RegisterSensor(EPlanningStateSensorType.CombatSkillStateSensor, new CombatSkillStateSensor());
		RegisterSensor(EPlanningStateSensorType.LifeSkillStateSensor, new LifeSkillStateSensor());
		RegisterSensor(EPlanningStateSensorType.MainAttributeStateSensor, new MainAttributeStateSensor());
		RegisterSensor(EPlanningStateSensorType.ProfessionStateSensor, new ProfessionStateSensor());
		RegisterSensor(EPlanningStateSensorType.ResourceStateSensor, new ResourceStateSensor());
		RegisterSensor(EPlanningStateSensorType.InventoryStateSensor, new InventoryStateSensor());
		RegisterSensor(EPlanningStateSensorType.TargetStateSensor, new TargetStateSensor());
		RegisterSensor(EPlanningStateSensorType.OrganizationStateSensor, new OrganizationStateSensor());
		RegisterSensor(EPlanningStateSensorType.GoalArgumentStateSensor, new GoalArgumentStateSensor());
		RegisterSensor(EPlanningStateSensorType.RelationStateSensor, new RelationStateSensor());
	}

	public void Initialize(DataContext context, GameData.Domains.Character.Character character, IGoal<GameData.Domains.Character.Character, StateKey> goal)
	{
		Context = context;
		Object = character;
		Goal = goal;
		Memory.Clear();
		Plan.Clear();
	}

	public GameData.Domains.Character.Character SelectActionTarget(DataContext context, PlanningGoalNode goal, PlanningActionNode action, ContextArgGroupHandle args, bool allowMovement)
	{
		PlanningActionItem actionItem = action.Template;
		_taiwuPrioritizedChance = actionItem.SelectTaiwuChance;
		_currPlanningAction = action;
		_currPlanningGoal = goal;
		_actionContextArgs = args;
		EPlanningActionCharacterSelectRange range = (allowMovement ? actionItem.CharacterSelectRange : RestrictRangeForNoMovementCharacter(actionItem.CharacterSelectRange));
		GameData.Domains.Character.Character result = SelectActionTarget(context, _actionTargetCharMatcher, actionItem.CharacterSelector, range, actionItem.SelectRangeValue);
		_currPlanningGoal = null;
		_currPlanningAction = null;
		_actionContextArgs = default(ContextArgGroupHandle);
		_taiwuPrioritizedChance = 0;
		return result;
	}

	public IEnumerable<GameData.Domains.Character.Character> SelectActionTargetGroup(DataContext context, PlanningGoalNode goal, PlanningActionNode action, ContextArgGroupHandle args)
	{
		PlanningActionItem actionItem = action.Template;
		_taiwuPrioritizedChance = actionItem.SelectTaiwuChance;
		_currPlanningAction = action;
		_currPlanningGoal = goal;
		_actionContextArgs = args;
		foreach (GameData.Domains.Character.Character item in SelectActionTargetGroup(selectCount: context.Random.Next(actionItem.CharacterSelectCountRange[0], actionItem.CharacterSelectCountRange[1] + 1), context: context, predicate: _actionTargetCharMatcher, selector: actionItem.CharacterSelector, range: actionItem.CharacterSelectRange, rangeValue: actionItem.SelectRangeValue))
		{
			yield return item;
		}
		_currPlanningGoal = null;
		_currPlanningAction = null;
		_actionContextArgs = default(ContextArgGroupHandle);
		_taiwuPrioritizedChance = 0;
	}

	private EPlanningActionCharacterSelectRange RestrictRangeForNoMovementCharacter(EPlanningActionCharacterSelectRange range)
	{
		return (range > EPlanningActionCharacterSelectRange.SameBlock) ? EPlanningActionCharacterSelectRange.SameBlock : range;
	}

	private bool MatchTargetCharacter(GameData.Domains.Character.Character character)
	{
		if (_currPlanningGoal != null && !_currPlanningGoal.MatchTargetCharacter(Context, Object, character, _actionContextArgs))
		{
			return false;
		}
		return _currPlanningAction.MatchTargetCharacter(Context, Object, character, _actionContextArgs);
	}

	public bool MatchTargetCharacterByConditions(GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args, StateConditionAndValue<StateKey>[] conditions)
	{
		foreach (StateConditionAndValue<StateKey> condition in conditions)
		{
			ISensor<IStateMemory<GameData.Domains.Character.Character, StateKey>, GameData.Domains.Character.Character, StateKey> sensor = GetSensor(condition.Key.Template.SensorType);
			int value = GetStateValue(sensor, condition.Key);
			if (value == int.MinValue)
			{
				return false;
			}
			if (condition.IsConstValue)
			{
				if (!StateConditionHelper.Check(condition.ConditionType, value, condition.Value))
				{
					return false;
				}
				continue;
			}
			ISensor<IStateMemory<GameData.Domains.Character.Character, StateKey>, GameData.Domains.Character.Character, StateKey> expectedValueSensor = GetSensor(condition.ReferenceKey.Template.SensorType);
			int expectedValue = GetStateValue(expectedValueSensor, condition.ReferenceKey);
			if (expectedValue == int.MinValue)
			{
				return false;
			}
			expectedValue = (condition.ConditionType.IsPercent() ? (expectedValue * condition.Value / 100) : (expectedValue + condition.Value));
			if (!StateConditionHelper.Check(condition.ConditionType, value, expectedValue))
			{
				return false;
			}
		}
		return true;
		int GetStateValue(ISensor<IStateMemory<GameData.Domains.Character.Character, StateKey>, GameData.Domains.Character.Character, StateKey> sensor2, StateKey key)
		{
			if (1 == 0)
			{
			}
			int result = ((sensor2 is CharacterStateSensorBase characterStateSensor) ? characterStateSensor.Sense(args, targetChar, key) : ((!(sensor2 is TargetStateSensor targetStateSensor)) ? int.MinValue : targetStateSensor.Sense(args, targetChar, selfChar, key)));
			if (1 == 0)
			{
			}
			return result;
		}
	}

	public IEnumerable<GameData.Domains.Character.Character> SelectActionTargetGroup(DataContext context, Predicate<GameData.Domains.Character.Character> predicate, EPlanningActionCharacterSelector selector, int selectCount, EPlanningActionCharacterSelectRange range, int rangeValue)
	{
		IReadOnlyList<GameData.Domains.Character.Character> selectableCharacters = GetCharactersInSelectRange(range, rangeValue);
		if (selectableCharacters == null)
		{
			yield break;
		}
		List<int> targets = _targetCharIds.Occupy();
		targets.Clear();
		FilterActionTargets(context.Random, selectableCharacters, targets, predicate, selector);
		for (int i = 0; i < selectCount; i++)
		{
			if (targets.Count == 0)
			{
				_targetCharIds.Release(ref targets);
				yield break;
			}
			int index = context.Random.Next(targets.Count);
			int charId = targets[index];
			yield return DomainManager.Character.GetElement_Objects(charId);
			CollectionUtils.SwapAndRemove(targets, index);
		}
		_targetCharIds.Release(ref targets);
	}

	public GameData.Domains.Character.Character SelectActionTarget(DataContext context, Predicate<GameData.Domains.Character.Character> predicate, EPlanningActionCharacterSelector selector, EPlanningActionCharacterSelectRange range, int rangeValue)
	{
		IReadOnlyList<GameData.Domains.Character.Character> selectableCharacters = GetCharactersInSelectRange(range, rangeValue);
		if (selectableCharacters == null)
		{
			return null;
		}
		List<int> targets = _targetCharIds.Occupy();
		targets.Clear();
		FilterActionTargets(context.Random, selectableCharacters, targets, predicate, selector);
		ModifyTaiwuInteractChance(targets);
		int selectedCharId = targets.GetRandomOrDefault(context.Random, -1);
		_targetCharIds.Release(ref targets);
		return (selectedCharId < 0) ? null : DomainManager.Character.GetElement_Objects(selectedCharId);
	}

	public void GetAllActionTargets(IRandomSource random, ICollection<int> result, Predicate<GameData.Domains.Character.Character> predicate, EPlanningActionCharacterSelector selector, EPlanningActionCharacterSelectRange range, int rangeValue)
	{
		result.Clear();
		IReadOnlyList<GameData.Domains.Character.Character> selectableCharacters = GetCharactersInSelectRange(range, rangeValue);
		if (selectableCharacters != null)
		{
			FilterActionTargets(random, selectableCharacters, result, predicate, selector);
		}
	}

	private void FilterActionTargets(IRandomSource random, IReadOnlyList<GameData.Domains.Character.Character> selectableCharacters, ICollection<int> result, Predicate<GameData.Domains.Character.Character> predicate, EPlanningActionCharacterSelector selector)
	{
		switch (selector)
		{
		case EPlanningActionCharacterSelector.RandomTarget:
			FilterRandomTarget(random, selectableCharacters, result, predicate);
			break;
		case EPlanningActionCharacterSelector.MaxPriorityTarget:
			FilterMaxPriorityTarget(random, selectableCharacters, result, predicate);
			break;
		case EPlanningActionCharacterSelector.RequestTarget:
			FilterDemandTarget(random, selectableCharacters, result, 0, predicate);
			break;
		case EPlanningActionCharacterSelector.StealTarget:
			FilterDemandTarget(random, selectableCharacters, result, 1, predicate);
			break;
		case EPlanningActionCharacterSelector.ScamTarget:
			FilterDemandTarget(random, selectableCharacters, result, 2, predicate);
			break;
		case EPlanningActionCharacterSelector.RobTarget:
			FilterDemandTarget(random, selectableCharacters, result, 3, predicate);
			break;
		case EPlanningActionCharacterSelector.CloseTarget:
			FilterMaxPriorityTarget(random, selectableCharacters, result, predicate);
			if (result.Count == 0)
			{
				FilterRandomTarget(random, selectableCharacters, result, predicate);
			}
			break;
		default:
		{
			int currActionTemplateId = _currPlanningAction?.Template.TemplateId ?? (-1);
			string actionRefName = PlanningAction.Instance.GetRefName(currActionTemplateId);
			AdaptableLog.TagWarning("FilterActionTargets", $"Unrecognized selector {selector} for action {actionRefName}");
			break;
		}
		}
	}

	private GameData.Domains.Character.Character SelectRandomTarget(DataContext context, IReadOnlyList<GameData.Domains.Character.Character> selectableCharacters, Predicate<GameData.Domains.Character.Character> condition)
	{
		if (selectableCharacters == null)
		{
			return null;
		}
		List<int> targets = _targetCharIds.Occupy();
		FilterRandomTarget(context.Random, selectableCharacters, targets, condition);
		ModifyTaiwuInteractChance(targets);
		int selectedCharId = targets.GetRandomOrDefault(context.Random, -1);
		_targetCharIds.Release(ref targets);
		if (selectedCharId < 0)
		{
			return null;
		}
		return DomainManager.Character.GetElement_Objects(selectedCharId);
	}

	private void FilterRandomTarget(IRandomSource random, IReadOnlyList<GameData.Domains.Character.Character> selectableCharacters, ICollection<int> targets, Predicate<GameData.Domains.Character.Character> condition)
	{
		int selfCharId = Object.GetId();
		foreach (GameData.Domains.Character.Character targetChar in selectableCharacters)
		{
			int targetCharId = targetChar.GetId();
			if (targetChar.GetAgeGroup() != 0 && DomainManager.Character.TryGetRelation(selfCharId, targetCharId, out var _) && (condition == null || condition(targetChar)))
			{
				if (targetChar.IsTaiwu() && CheckPrioritizeTaiwuAsTarget(random))
				{
					targets.Clear();
					targets.Add(targetCharId);
					break;
				}
				targets.Add(targetCharId);
			}
		}
	}

	private GameData.Domains.Character.Character SelectMaxPriorityTarget(DataContext context, IReadOnlyList<GameData.Domains.Character.Character> selectableCharacters, Predicate<GameData.Domains.Character.Character> condition)
	{
		if (selectableCharacters == null)
		{
			return null;
		}
		List<int> maxPriorityTargets = _targetCharIds.Occupy();
		FilterMaxPriorityTarget(context.Random, selectableCharacters, maxPriorityTargets, condition);
		ModifyTaiwuInteractChance(maxPriorityTargets);
		int targetCharId = maxPriorityTargets.GetRandomOrDefault(context.Random, -1);
		_targetCharIds.Release(ref maxPriorityTargets);
		if (targetCharId < 0)
		{
			return null;
		}
		return DomainManager.Character.GetElement_Objects(targetCharId);
	}

	private void FilterMaxPriorityTarget(IRandomSource random, IReadOnlyList<GameData.Domains.Character.Character> selectableCharacters, ICollection<int> targets, Predicate<GameData.Domains.Character.Character> condition)
	{
		sbyte currMaxPriorityType = -1;
		int currMaxPriorityScore = 0;
		int selfCharId = Object.GetId();
		sbyte behaviorType = Object.GetBehaviorType();
		foreach (GameData.Domains.Character.Character targetChar in selectableCharacters)
		{
			int charId = targetChar.GetId();
			if (targetChar.GetAgeGroup() == 0 || !DomainManager.Character.TryGetRelation(selfCharId, charId, out var selfToTarget) || (condition != null && !condition(targetChar)))
			{
				continue;
			}
			if (targetChar.IsTaiwu() && CheckPrioritizeTaiwuAsTarget(random))
			{
				targets.Clear();
				targets.Add(charId);
				break;
			}
			sbyte currPriorityType = AiHelper.ActionTargetType.GetActionTargetType(selfToTarget.RelationType);
			if (currPriorityType != -1)
			{
				sbyte currPriorityScore = AiHelper.ActionTargetType.PriorityScores[behaviorType][currPriorityType];
				if (currPriorityType == currMaxPriorityType)
				{
					targets.Add(charId);
				}
				else if (currMaxPriorityScore < currPriorityScore)
				{
					currMaxPriorityType = currPriorityType;
					currMaxPriorityScore = currPriorityScore;
					targets.Clear();
					targets.Add(charId);
				}
			}
		}
	}

	private void FilterDemandTarget(IRandomSource random, IReadOnlyList<GameData.Domains.Character.Character> selectableCharacters, ICollection<int> targets, sbyte actionType, Predicate<GameData.Domains.Character.Character> condition)
	{
		GameData.Domains.Character.Character selfChar = Object;
		int selfCharId = selfChar.GetId();
		sbyte selfBehaviorType = selfChar.GetBehaviorType();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		bool taiwuCanBeTarget = DomainManager.Taiwu.CanTaiwuBeSneakyHarmfulActionTarget() || actionType == 0;
		if (actionType == 0)
		{
			sbyte currMaxPriorityType = -1;
			int currMaxPriorityScore = 0;
			{
				foreach (GameData.Domains.Character.Character targetChar in selectableCharacters)
				{
					int targetCharId = targetChar.GetId();
					if (targetChar.GetAgeGroup() == 0 || !DomainManager.Character.TryGetRelation(selfCharId, targetCharId, out var selfToTarget) || (condition != null && !condition(targetChar)))
					{
						continue;
					}
					if (targetChar.IsTaiwu() && CheckPrioritizeTaiwuAsTarget(random))
					{
						targets.Clear();
						targets.Add(targetCharId);
						break;
					}
					sbyte currPriorityType = AiHelper.ActionTargetType.GetActionTargetType(selfToTarget.RelationType);
					if (currPriorityType != -1)
					{
						sbyte currPriorityScore = AiHelper.ActionTargetType.PriorityScores[selfBehaviorType][currPriorityType];
						if (currPriorityType == currMaxPriorityType)
						{
							targets.Add(targetCharId);
						}
						else if (currMaxPriorityScore < currPriorityScore)
						{
							currMaxPriorityType = currPriorityType;
							currMaxPriorityScore = currPriorityScore;
							targets.Clear();
							targets.Add(targetCharId);
						}
					}
				}
				return;
			}
		}
		if (1 == 0)
		{
		}
		sbyte[] array = actionType switch
		{
			1 => AiHelper.GeneralActionConstants.StartStealingChance[selfBehaviorType], 
			2 => AiHelper.GeneralActionConstants.StartScammingChance[selfBehaviorType], 
			3 => AiHelper.GeneralActionConstants.StartRobbingChance[selfBehaviorType], 
			_ => throw new ArgumentOutOfRangeException("actionType", actionType, $"value not in valid range [0,{5})."), 
		};
		if (1 == 0)
		{
		}
		sbyte[] chances = array;
		foreach (GameData.Domains.Character.Character targetChar2 in selectableCharacters)
		{
			int targetCharId2 = targetChar2.GetId();
			if (!DomainManager.Character.TryGetRelation(selfCharId, targetCharId2, out var selfToTarget2) || (condition != null && !condition(targetChar2)))
			{
				continue;
			}
			sbyte category = AiHelper.ActionTargetRelationCategory.GetTargetRelationCategory(selfToTarget2.RelationType);
			if (!random.CheckPercentProb(chances[category]))
			{
				continue;
			}
			if (targetCharId2 == taiwuCharId)
			{
				if (!taiwuCanBeTarget)
				{
					continue;
				}
				if (CheckPrioritizeTaiwuAsTarget(random))
				{
					targets.Clear();
					targets.Add(targetCharId2);
					break;
				}
			}
			targets.Add(targetCharId2);
		}
	}

	public bool CheckInTargetSelectRange(GameData.Domains.Character.Character targetChar, EPlanningActionCharacterSelectRange range, int rangeValue)
	{
		Location selfLocation = Object.GetLocation();
		Location targetLocation = targetChar.GetLocation();
		if (!selfLocation.IsValid() || !targetLocation.IsValid())
		{
			return false;
		}
		switch (range)
		{
		case EPlanningActionCharacterSelectRange.SameBlock:
			return targetLocation == selfLocation;
		case EPlanningActionCharacterSelectRange.SameArea:
			return targetLocation.AreaId == selfLocation.AreaId;
		case EPlanningActionCharacterSelectRange.SameState:
		{
			sbyte selfStateId = DomainManager.Map.GetStateIdByAreaId(selfLocation.AreaId);
			sbyte targetStateId = DomainManager.Map.GetStateIdByAreaId(targetLocation.AreaId);
			return selfStateId == targetStateId;
		}
		case EPlanningActionCharacterSelectRange.BlockRange:
			return selfLocation.IsNearbyLocation(targetLocation, rangeValue);
		case EPlanningActionCharacterSelectRange.SettlementRange:
		{
			MapBlockData selfBelongBlock = DomainManager.Map.GetBelongSettlementBlock(selfLocation);
			MapBlockData targetBelongBlock = DomainManager.Map.GetBelongSettlementBlock(targetLocation);
			return selfBelongBlock != null && targetBelongBlock != null;
		}
		default:
			return false;
		}
	}

	private void ModifyTaiwuInteractChance(List<int> targets)
	{
		if (DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(34) && targets.Contains(DomainManager.Taiwu.GetTaiwuCharId()))
		{
			ProfessionSkillHandle.AristocratSkill_BoostTaiwuAsTargetInCollection(targets);
		}
	}

	private bool CheckPrioritizeTaiwuAsTarget(IRandomSource random)
	{
		return _taiwuPrioritizedChance > 0 && random.CheckPercentProb(_taiwuPrioritizedChance);
	}

	private IReadOnlyList<GameData.Domains.Character.Character> GetCharactersInSelectRange(EPlanningActionCharacterSelectRange range, int rangeValue)
	{
		_selectableCharacters.Clear();
		Location location = Object.GetLocation();
		if (!location.IsValid())
		{
			return _selectableCharacters;
		}
		switch (range)
		{
		case EPlanningActionCharacterSelectRange.SameBlock:
		{
			MapBlockData blockData = DomainManager.Map.GetBlock(location);
			AddCharactersInBlock(_selectableCharacters, blockData);
			break;
		}
		case EPlanningActionCharacterSelectRange.SameArea:
			AddCharactersInArea(_selectableCharacters, location.AreaId);
			break;
		case EPlanningActionCharacterSelectRange.SameState:
		{
			sbyte stateId = DomainManager.Map.GetStateIdByAreaId(location.AreaId);
			AddCharactersInState(_selectableCharacters, stateId);
			break;
		}
		case EPlanningActionCharacterSelectRange.BlockRange:
			AddCharactersInBlockRange(_selectableCharacters, location, rangeValue);
			break;
		case EPlanningActionCharacterSelectRange.SettlementRange:
		{
			MapBlockData belongSettlementBlock = DomainManager.Map.GetBelongSettlementBlock(location);
			if (belongSettlementBlock != null)
			{
				AddCharactersInSettlementRange(_selectableCharacters, belongSettlementBlock.GetLocation());
			}
			break;
		}
		}
		return _selectableCharacters;
	}

	private void AddCharactersInBlockRange(List<GameData.Domains.Character.Character> characters, Location location, int steps)
	{
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, neighborBlocks, steps, includeCenter: true);
		foreach (MapBlockData block in neighborBlocks)
		{
			AddCharactersInBlock(characters, block);
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
	}

	private void AddCharactersInSettlementRange(List<GameData.Domains.Character.Character> characters, Location settlementLocation)
	{
		List<short> blockIds = ObjectPool<List<short>>.Instance.Get();
		DomainManager.Map.GetSettlementBlocks(settlementLocation.AreaId, settlementLocation.BlockId, blockIds);
		foreach (short blockId in blockIds)
		{
			MapBlockData blockData = DomainManager.Map.GetBlock(settlementLocation.AreaId, blockId);
			AddCharactersInBlock(characters, blockData);
		}
		ObjectPool<List<short>>.Instance.Return(blockIds);
	}

	private void AddCharactersInState(List<GameData.Domains.Character.Character> characters, sbyte stateId)
	{
		List<short> areaIds = ObjectPool<List<short>>.Instance.Get();
		DomainManager.Map.GetAllAreaInState(stateId, areaIds);
		foreach (short areaId in areaIds)
		{
			AddCharactersInArea(characters, areaId);
		}
		ObjectPool<List<short>>.Instance.Return(areaIds);
	}

	private void AddCharactersInArea(List<GameData.Domains.Character.Character> characters, short areaId)
	{
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(areaId);
		Span<MapBlockData> span = areaBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData blockData = span[i];
			AddCharactersInBlock(characters, blockData);
		}
	}

	private void AddCharactersInBlock(List<GameData.Domains.Character.Character> characters, MapBlockData mapBlockData)
	{
		int selfCharId = Object.GetId();
		if (DomainManager.Taiwu.GetTaiwu().GetLocation() == mapBlockData.GetLocation())
		{
			foreach (int charId in DomainManager.Taiwu.GetGroupCharIds().GetCollection())
			{
				if (charId != selfCharId)
				{
					characters.Add(DomainManager.Character.GetElement_Objects(charId));
				}
			}
		}
		if (mapBlockData.CharacterSet == null)
		{
			return;
		}
		foreach (int charId2 in mapBlockData.CharacterSet)
		{
			if (charId2 != selfCharId)
			{
				characters.Add(DomainManager.Character.GetElement_Objects(charId2));
			}
		}
	}

	public void PrepareContext(IStateMemory<GameData.Domains.Character.Character, StateKey> stateMemory, INode<GameData.Domains.Character.Character, StateKey> currNode, INode<GameData.Domains.Character.Character, StateKey> nextNode, INode<GameData.Domains.Character.Character, StateKey> destNode)
	{
		if (nextNode is PlanningActionNode action && action.Template.CharacterSelector != EPlanningActionCharacterSelector.None)
		{
			CharacterStateMemory characterStateMemory = (CharacterStateMemory)stateMemory;
			if (destNode is CharacterGoalData { TemplateNode: var goalNode } goalData)
			{
				characterStateMemory.TargetChar = SelectActionTarget(Context, goalNode, action, characterStateMemory.Args, goalData.State == CharacterGoalData.EGoalState.Primary);
				return;
			}
			PlanningGoalNode goalNode2 = destNode as PlanningGoalNode;
			characterStateMemory.TargetChar = SelectActionTarget(Context, goalNode2, action, characterStateMemory.Args, allowMovement: true);
		}
	}

	public bool CheckPrerequisites(IStateMemory<GameData.Domains.Character.Character, StateKey> stateMemory, INode<GameData.Domains.Character.Character, StateKey> node)
	{
		if (!(node is PlanningActionNode action))
		{
			return false;
		}
		if (!(stateMemory is IContextArgGroup argGroup))
		{
			return false;
		}
		sbyte[] parameters = action.Template.Parameters;
		if (parameters != null && parameters.Length > 0)
		{
			sbyte[] parameters2 = action.Template.Parameters;
			foreach (sbyte paramType in parameters2)
			{
				if (!argGroup.GetArgOfType(PlanningParameter.Instance[paramType].Type).HasValue)
				{
					return false;
				}
			}
		}
		GameData.Domains.Character.Character character = Object;
		if (character.ActionPlanningData.IsActionInCooldown(action.Template.TemplateId))
		{
			return false;
		}
		int[] professionRequirement = action.Template.ProfessionRequirement;
		if (professionRequirement != null && professionRequirement.Length == 2)
		{
			ProfessionData currProfession = Object.GetCurrentProfession();
			if (currProfession.TemplateId != action.Template.ProfessionRequirement[0])
			{
				return false;
			}
			int skillIndex = action.Template.ProfessionRequirement[1];
			if (!currProfession.IsSkillUnlocked(skillIndex))
			{
				return false;
			}
			if (currProfession.IsSkillCooldown(DomainManager.World.GetCurrDate(), skillIndex))
			{
				return false;
			}
		}
		if (action.Template.SelfMatcher >= 0 && !CharacterMatcher.Instance[action.Template.SelfMatcher].Match(character))
		{
			return false;
		}
		StateConditionAndValue<StateKey>[] selfRestrictions = action.Template.SelfRestrictions;
		if (selfRestrictions != null && selfRestrictions.Length > 0)
		{
			StateConditionAndValue<StateKey>[] selfRestrictions2 = action.Template.SelfRestrictions;
			foreach (StateConditionAndValue<StateKey> restriction in selfRestrictions2)
			{
				if (!stateMemory.CheckCondition(this, restriction))
				{
					return false;
				}
			}
		}
		if (action.Template.IsAdultOnly && character.GetAgeGroup() != 2)
		{
			return false;
		}
		if (action.Template.IsNonMonk && character.GetMonkType() != 0)
		{
			return false;
		}
		if (action.Template.IsNonTaiwuTeammate && character.IsInTaiwuGroup())
		{
			return false;
		}
		OrganizationMemberItem orgMemberCfg = character.GetOrganizationInfo().GetOrgMemberConfig();
		short[] requiredOrgMembers = action.Template.RequiredOrgMembers;
		if (requiredOrgMembers != null && requiredOrgMembers.Length > 0 && !action.Template.RequiredOrgMembers.Exist(orgMemberCfg.TemplateId))
		{
			return false;
		}
		if (action.Template.LoafChance >= 0 && !orgMemberCfg.CanStroll)
		{
			return Context.Random.CheckPercentProb(action.Template.LoafChance);
		}
		return true;
	}

	public int CalcCurrentState(IStateMemory<GameData.Domains.Character.Character, StateKey> currMemory, StateKey key)
	{
		PlanningStateItem stateKeyTemplate = key.Template;
		if (currMemory is CharacterStateMemory characterStateMemory)
		{
			sbyte requiredParamType = stateKeyTemplate.InputParamType;
			if (requiredParamType >= 0 && !characterStateMemory.Args.HasArgOfType(PlanningParameter.Instance[requiredParamType].Type))
			{
				return int.MinValue;
			}
		}
		return GetSensor(stateKeyTemplate.SensorType)?.Sense(currMemory, Object, key) ?? int.MinValue;
	}

	public ISensor<IStateMemory<GameData.Domains.Character.Character, StateKey>, GameData.Domains.Character.Character, StateKey> GetSensor(EPlanningStateSensorType sensorType)
	{
		return (sensorType == EPlanningStateSensorType.None) ? null : _sensors[(int)sensorType];
	}

	private void RegisterSensor(EPlanningStateSensorType sensorType, ISensor<IStateMemory<GameData.Domains.Character.Character, StateKey>, GameData.Domains.Character.Character, StateKey> sensor)
	{
		_sensors[(int)sensorType] = sensor;
	}
}
