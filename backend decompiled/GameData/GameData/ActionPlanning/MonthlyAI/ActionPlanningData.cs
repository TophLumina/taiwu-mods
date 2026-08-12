using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Mission;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.ActionPlanning.MonthlyAI;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true, NotForDisplayModule = true)]
public class ActionPlanningData : ISerializableGameData
{
	public enum ECurrentGoalType
	{
		Primary,
		Secondary
	}

	private static class FieldIds
	{
		public const ushort Goals = 0;

		public const ushort Missions = 1;

		public const ushort InterruptedActions = 2;

		public const ushort PrimaryGoalActionPoint = 3;

		public const ushort SecondaryGoalActionPoint = 4;

		public const ushort ActionOffCooldownDates = 5;

		public const ushort Count = 6;

		public static readonly string[] FieldId2FieldName = new string[6] { "Goals", "Missions", "InterruptedActions", "PrimaryGoalActionPoint", "SecondaryGoalActionPoint", "ActionOffCooldownDates" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public List<CharacterGoalData> Goals;

	[SerializableGameDataField(FieldIndex = 1, SubDataMaxCount = int.MaxValue)]
	public CharacterMissionData[] Missions = new CharacterMissionData[4];

	[SerializableGameDataField(FieldIndex = 2)]
	public List<CharacterActionData> InterruptedActions;

	[SerializableGameDataField(FieldIndex = 3)]
	public int PrimaryGoalActionPoint;

	[SerializableGameDataField(FieldIndex = 4)]
	public int SecondaryGoalActionPoint;

	[SerializableGameDataField(FieldIndex = 5)]
	private Dictionary<int, int> _actionOffCooldownDates;

	private CharacterGoalData _primaryGoal;

	private CharacterGoalData _secondaryGoal;

	public CharacterGoalData PrimaryGoal => GetCurrentGoal(ECurrentGoalType.Primary);

	public CharacterActionData PrimaryGoalAction => GetCurrentAction(ECurrentGoalType.Primary);

	public CharacterGoalData GetCurrentGoal(ECurrentGoalType goalType)
	{
		switch (goalType)
		{
		case ECurrentGoalType.Primary:
		{
			CharacterGoalData secondaryGoal = _primaryGoal;
			if (secondaryGoal != null && secondaryGoal.State == CharacterGoalData.EGoalState.Primary)
			{
				return _primaryGoal;
			}
			_primaryGoal = null;
			foreach (CharacterGoalData goal2 in GetAllGoals())
			{
				if (goal2.State != CharacterGoalData.EGoalState.Primary)
				{
					continue;
				}
				_primaryGoal = goal2;
				break;
			}
			return _primaryGoal;
		}
		case ECurrentGoalType.Secondary:
		{
			CharacterGoalData secondaryGoal = _secondaryGoal;
			if (secondaryGoal != null && secondaryGoal.State == CharacterGoalData.EGoalState.Secondary)
			{
				return _secondaryGoal;
			}
			_secondaryGoal = null;
			foreach (CharacterGoalData goal in GetAllGoals())
			{
				if (goal.State != CharacterGoalData.EGoalState.Secondary)
				{
					continue;
				}
				_secondaryGoal = goal;
				break;
			}
			return _secondaryGoal;
		}
		default:
			throw new ArgumentOutOfRangeException("goalType", goalType, null);
		}
	}

	public CharacterActionData GetCurrentAction(ECurrentGoalType goalType)
	{
		return GetCurrentGoal(goalType)?.CurrentAction;
	}

	public void SetCurrentAction(ECurrentGoalType goalType, CharacterActionData action)
	{
		CharacterGoalData goal = GetCurrentGoal(goalType);
		if (goal.CurrentAction != action)
		{
			SetGoalActionInterrupted(goal);
		}
		goal.CurrentAction = action;
	}

	public IEnumerable<CharacterGoalData> GetAllGoals()
	{
		List<CharacterGoalData> goals = Goals;
		if (goals != null && goals.Count > 0)
		{
			foreach (CharacterGoalData goal in Goals)
			{
				yield return goal;
			}
		}
		CharacterMissionData[] missions = Missions;
		foreach (CharacterMissionData mission in missions)
		{
			if (mission == null)
			{
				continue;
			}
			foreach (CharacterGoalData goal2 in mission.Goals)
			{
				yield return goal2;
			}
		}
	}

	public void InitCharacter(Character character)
	{
		List<CharacterActionData> interruptedActions = InterruptedActions;
		if (interruptedActions != null && interruptedActions.Count > 0)
		{
			foreach (CharacterActionData action in InterruptedActions)
			{
				action.Character = character;
			}
		}
		foreach (CharacterGoalData goal in GetAllGoals())
		{
			if (goal.CurrentAction != null)
			{
				goal.CurrentAction.Character = character;
			}
		}
	}

	public void UpdateActionPoints(ECurrentGoalType goalType)
	{
		switch (goalType)
		{
		case ECurrentGoalType.Primary:
			PrimaryGoalActionPoint = Math.Min(PrimaryGoalActionPoint + GlobalConfig.Instance.PrimaryGoalActionPointsPerMonth, GlobalConfig.Instance.PrimaryGoalMaxActionPoints);
			break;
		case ECurrentGoalType.Secondary:
			SecondaryGoalActionPoint = Math.Min(SecondaryGoalActionPoint + GlobalConfig.Instance.SecondaryGoalActionPointsPerMonth, GlobalConfig.Instance.SecondaryGoalMaxActionPoints);
			break;
		}
	}

	public bool TryStartAction(ECurrentGoalType goalType, CharacterActionData action)
	{
		if (action.HasStarted)
		{
			return false;
		}
		int cost = action.Template.ActionPointCost;
		switch (goalType)
		{
		case ECurrentGoalType.Primary:
			if (cost > PrimaryGoalActionPoint)
			{
				return false;
			}
			PrimaryGoalActionPoint -= cost;
			break;
		case ECurrentGoalType.Secondary:
			if (cost > SecondaryGoalActionPoint)
			{
				return false;
			}
			SecondaryGoalActionPoint -= cost;
			break;
		}
		action.State = CharacterActionData.EActionState.Started;
		return true;
	}

	public bool UpdateActionCooldowns(int currDate)
	{
		if (_actionOffCooldownDates == null)
		{
			return false;
		}
		List<int> toRemove = null;
		foreach (KeyValuePair<int, int> pair in _actionOffCooldownDates)
		{
			if (pair.Value < currDate)
			{
				if (toRemove == null)
				{
					toRemove = ObjectPool<List<int>>.Instance.Get();
					toRemove.Clear();
				}
				toRemove.Add(pair.Key);
			}
		}
		if (toRemove == null)
		{
			return false;
		}
		foreach (int actionTemplateId in toRemove)
		{
			_actionOffCooldownDates.Remove(actionTemplateId);
		}
		ObjectPool<List<int>>.Instance.Return(toRemove);
		return true;
	}

	public void SetActionCooldown(CharacterActionData action, int currDate)
	{
		int cooldown = action.Template.Cooldown;
		if (cooldown > 0)
		{
			if (_actionOffCooldownDates == null)
			{
				_actionOffCooldownDates = new Dictionary<int, int>();
			}
			_actionOffCooldownDates[action.ActionTemplateId] = currDate + cooldown;
		}
	}

	public bool IsActionInCooldown(int actionTemplateId)
	{
		return _actionOffCooldownDates?.ContainsKey(actionTemplateId) ?? false;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (Goals != null)
		{
			totalSize += 2;
			int elementsCount = Goals.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterGoalData element = Goals[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (Missions != null)
		{
			totalSize += 2;
			int elementsCount2 = Missions.Length;
			for (int j = 0; j < elementsCount2; j++)
			{
				CharacterMissionData element2 = Missions[j];
				totalSize = ((element2 == null) ? (totalSize + 4) : (totalSize + (4 + element2.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (InterruptedActions != null)
		{
			totalSize += 2;
			int elementsCount3 = InterruptedActions.Count;
			for (int k = 0; k < elementsCount3; k++)
			{
				CharacterActionData element3 = InterruptedActions[k];
				totalSize = ((element3 == null) ? (totalSize + 2) : (totalSize + (2 + element3.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(_actionOffCooldownDates);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 6;
		pCurrData += 2;
		if (Goals != null)
		{
			int elementsCount = Goals.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterGoalData element = Goals[i];
				if (element != null)
				{
					byte* pSubDataCount = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)pSubDataCount = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Missions != null)
		{
			int elementsCount2 = Missions.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				CharacterMissionData element2 = Missions[j];
				if (element2 != null)
				{
					byte* pSubDataCount2 = pCurrData;
					pCurrData += 4;
					int subDataSize2 = element2.Serialize(pCurrData);
					pCurrData += subDataSize2;
					Tester.Assert(subDataSize2 <= int.MaxValue);
					*(int*)pSubDataCount2 = subDataSize2;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (InterruptedActions != null)
		{
			int elementsCount3 = InterruptedActions.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				CharacterActionData element3 = InterruptedActions[k];
				if (element3 != null)
				{
					byte* pSubDataCount3 = pCurrData;
					pCurrData += 2;
					int subDataSize3 = element3.Serialize(pCurrData);
					pCurrData += subDataSize3;
					Tester.Assert(subDataSize3 <= 65535);
					*(ushort*)pSubDataCount3 = (ushort)subDataSize3;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = PrimaryGoalActionPoint;
		pCurrData += 4;
		*(int*)pCurrData = SecondaryGoalActionPoint;
		pCurrData += 4;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref _actionOffCooldownDates);
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (Goals == null)
				{
					Goals = new List<CharacterGoalData>(elementsCount);
				}
				else
				{
					Goals.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort subDataCount = *(ushort*)pCurrData;
					pCurrData += 2;
					if (subDataCount > 0)
					{
						CharacterGoalData element = new CharacterGoalData();
						pCurrData += element.Deserialize(pCurrData);
						Goals.Add(element);
					}
					else
					{
						Goals.Add(null);
					}
				}
			}
			else
			{
				Goals?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (Missions == null || Missions.Length != elementsCount2)
				{
					Missions = new CharacterMissionData[elementsCount2];
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					int subDataCount2 = *(int*)pCurrData;
					pCurrData += 4;
					if (subDataCount2 > 0)
					{
						CharacterMissionData element2 = Missions[j] ?? new CharacterMissionData();
						pCurrData += element2.Deserialize(pCurrData);
						Missions[j] = element2;
					}
					else
					{
						Missions[j] = null;
					}
				}
			}
			else
			{
				Missions = null;
			}
		}
		if (fieldCount > 2)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (InterruptedActions == null)
				{
					InterruptedActions = new List<CharacterActionData>(elementsCount3);
				}
				else
				{
					InterruptedActions.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					ushort subDataCount3 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (subDataCount3 > 0)
					{
						CharacterActionData element3 = new CharacterActionData();
						pCurrData += element3.Deserialize(pCurrData);
						InterruptedActions.Add(element3);
					}
					else
					{
						InterruptedActions.Add(null);
					}
				}
			}
			else
			{
				InterruptedActions?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			PrimaryGoalActionPoint = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 4)
		{
			SecondaryGoalActionPoint = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 5)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref _actionOffCooldownDates);
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public CharacterGoalData RemoveGoal(int templateId)
	{
		List<CharacterGoalData> goals = Goals;
		if (goals == null || goals.Count <= 0)
		{
			return null;
		}
		for (int index = Goals.Count - 1; index >= 0; index--)
		{
			CharacterGoalData goal = Goals[index];
			if (goal.GoalTemplateId == templateId)
			{
				SetGoalActionInterrupted(goal);
				Goals.RemoveAt(index);
				return goal;
			}
		}
		return null;
	}

	public CharacterGoalData RemoveGoal(int templateId, PlanningContextArg arg0)
	{
		List<CharacterGoalData> goals = Goals;
		if (goals == null || goals.Count <= 0)
		{
			return null;
		}
		for (int index = Goals.Count - 1; index >= 0; index--)
		{
			CharacterGoalData goal = Goals[index];
			if (goal.Match(templateId, arg0))
			{
				SetGoalActionInterrupted(goal);
				Goals.RemoveAt(index);
				return goal;
			}
		}
		return null;
	}

	public CharacterGoalData RemoveGoal(int templateId, PlanningContextArg arg0, PlanningContextArg arg1)
	{
		List<CharacterGoalData> goals = Goals;
		if (goals == null || goals.Count <= 0)
		{
			return null;
		}
		for (int index = Goals.Count - 1; index >= 0; index--)
		{
			CharacterGoalData goal = Goals[index];
			if (goal.Match(templateId, arg0, arg1))
			{
				SetGoalActionInterrupted(goal);
				Goals.RemoveAt(index);
				return goal;
			}
		}
		return null;
	}

	public CharacterGoalData RemoveGoal(int templateId, PlanningContextArg arg0, PlanningContextArg arg1, PlanningContextArg arg2)
	{
		List<CharacterGoalData> goals = Goals;
		if (goals == null || goals.Count <= 0)
		{
			return null;
		}
		for (int index = Goals.Count - 1; index >= 0; index--)
		{
			CharacterGoalData goal = Goals[index];
			if (goal.Match(templateId, arg0, arg1, arg2))
			{
				SetGoalActionInterrupted(goal);
				Goals.RemoveAt(index);
				return goal;
			}
		}
		return null;
	}

	public CharacterGoalData GetGoal(int templateId)
	{
		List<CharacterGoalData> goals = Goals;
		if (goals == null || goals.Count <= 0)
		{
			return null;
		}
		foreach (CharacterGoalData goal in Goals)
		{
			if (goal.GoalTemplateId == templateId)
			{
				return goal;
			}
		}
		return null;
	}

	public CharacterGoalData GetGoal(int templateId, PlanningContextArg arg0)
	{
		List<CharacterGoalData> goals = Goals;
		if (goals == null || goals.Count <= 0)
		{
			return null;
		}
		foreach (CharacterGoalData goal in Goals)
		{
			if (goal.Match(templateId, arg0))
			{
				return goal;
			}
		}
		return null;
	}

	public CharacterGoalData GetGoal(int templateId, PlanningContextArg arg0, PlanningContextArg arg1)
	{
		List<CharacterGoalData> goals = Goals;
		if (goals == null || goals.Count <= 0)
		{
			return null;
		}
		foreach (CharacterGoalData goal in Goals)
		{
			if (goal.Match(templateId, arg0, arg1))
			{
				return goal;
			}
		}
		return null;
	}

	public CharacterGoalData GetGoal(int templateId, PlanningContextArg arg0, PlanningContextArg arg1, PlanningContextArg arg2)
	{
		List<CharacterGoalData> goals = Goals;
		if (goals == null || goals.Count <= 0)
		{
			return null;
		}
		foreach (CharacterGoalData goal in Goals)
		{
			if (goal.Match(templateId, arg0, arg1, arg2))
			{
				return goal;
			}
		}
		return null;
	}

	public CharacterGoalData AddGoal(int templateId, int currDate)
	{
		if (!CharacterActionPlanner.Instance.GetGoalNode(templateId).CheckCanBeAdded())
		{
			return null;
		}
		if (Goals == null)
		{
			Goals = new List<CharacterGoalData>();
		}
		else
		{
			for (int index = Goals.Count - 1; index >= 0; index--)
			{
				CharacterGoalData currGoal = Goals[index];
				if (currGoal.GoalTemplateId == templateId)
				{
					return null;
				}
			}
		}
		CharacterGoalData newGoal = new CharacterGoalData(templateId, currDate);
		if (!newGoal.CheckParameters())
		{
			return null;
		}
		Goals.Add(newGoal);
		return newGoal;
	}

	public CharacterGoalData AddGoal(int templateId, int currDate, PlanningContextArg arg0)
	{
		if (!CharacterActionPlanner.Instance.GetGoalNode(templateId).CheckCanBeAdded())
		{
			return null;
		}
		if (Goals == null)
		{
			Goals = new List<CharacterGoalData>();
		}
		else
		{
			for (int index = Goals.Count - 1; index >= 0; index--)
			{
				CharacterGoalData currGoal = Goals[index];
				if (currGoal.GoalTemplateId == templateId)
				{
					if (currGoal.Match(templateId, arg0))
					{
						return null;
					}
					if (currGoal.Template.Overwrite)
					{
						Goals.RemoveAt(index);
						break;
					}
				}
			}
		}
		CharacterGoalData newGoal = new CharacterGoalData(templateId, currDate, arg0);
		if (!newGoal.CheckParameters())
		{
			return null;
		}
		Goals.Add(newGoal);
		return newGoal;
	}

	public CharacterGoalData AddGoal(int templateId, int currDate, PlanningContextArg arg0, PlanningContextArg arg1)
	{
		if (!CharacterActionPlanner.Instance.GetGoalNode(templateId).CheckCanBeAdded())
		{
			return null;
		}
		if (Goals == null)
		{
			Goals = new List<CharacterGoalData>();
		}
		else
		{
			for (int index = Goals.Count - 1; index >= 0; index--)
			{
				CharacterGoalData currGoal = Goals[index];
				if (currGoal.GoalTemplateId == templateId)
				{
					if (currGoal.Match(templateId, arg0, arg1))
					{
						return null;
					}
					if (currGoal.Template.Overwrite)
					{
						Goals.RemoveAt(index);
						break;
					}
				}
			}
		}
		CharacterGoalData newGoal = new CharacterGoalData(templateId, currDate, arg0, arg1);
		if (!newGoal.CheckParameters())
		{
			return null;
		}
		Goals.Add(newGoal);
		return newGoal;
	}

	public CharacterGoalData AddGoal(int templateId, int currDate, PlanningContextArg arg0, PlanningContextArg arg1, PlanningContextArg arg2)
	{
		if (!CharacterActionPlanner.Instance.GetGoalNode(templateId).CheckCanBeAdded())
		{
			return null;
		}
		if (Goals == null)
		{
			Goals = new List<CharacterGoalData>();
		}
		else
		{
			for (int index = Goals.Count - 1; index >= 0; index--)
			{
				CharacterGoalData currGoal = Goals[index];
				if (currGoal.GoalTemplateId == templateId)
				{
					if (currGoal.Match(templateId, arg0, arg1, arg2))
					{
						return null;
					}
					if (currGoal.Template.Overwrite)
					{
						Goals.RemoveAt(index);
						break;
					}
				}
			}
		}
		CharacterGoalData newGoal = new CharacterGoalData(templateId, currDate, arg0, arg1, arg2);
		if (!newGoal.CheckParameters())
		{
			return null;
		}
		Goals.Add(newGoal);
		return newGoal;
	}

	public void SetGoalAchieved(CharacterGoalData goalData, int date)
	{
		SetGoalActionInterrupted(goalData);
		goalData.SetAchieved(date);
		Goals?.Remove(goalData);
	}

	public void SetGoalReplaced(CharacterGoalData goalData, int date)
	{
		SetGoalActionInterrupted(goalData);
		goalData.SetReplaced(date);
	}

	private void SetGoalActionInterrupted(CharacterGoalData goalData)
	{
		if (goalData.CurrentAction == null)
		{
			return;
		}
		CharacterActionData action = goalData.CurrentAction;
		goalData.CurrentAction = null;
		if (action.InProgress)
		{
			if (InterruptedActions == null)
			{
				InterruptedActions = new List<CharacterActionData>();
			}
			InterruptedActions.Add(action);
		}
	}

	public bool ResetUnreachableGoals()
	{
		bool modified = false;
		foreach (CharacterGoalData goal in GetAllGoals())
		{
			if (goal.Unreachable)
			{
				goal.Unreachable = false;
				modified = true;
			}
		}
		return modified;
	}

	public bool UpdateCurrentGoalsByPriority(Character character, int currDate)
	{
		CharacterGoalData highestPriorityGoal = null;
		CharacterGoalData secondHighestPriorityGoal = null;
		int highestPriority = int.MinValue;
		int secondHighestPriority = int.MinValue;
		foreach (CharacterGoalData goal in GetAllGoals())
		{
			if (!goal.Unreachable && goal.State != CharacterGoalData.EGoalState.Achieved)
			{
				int priority = goal.GetPriority(character);
				if (priority > highestPriority)
				{
					highestPriority = priority;
					highestPriorityGoal = goal;
				}
				else if (priority > secondHighestPriority && !goal.Template.IsPrioritizedGoal)
				{
					secondHighestPriority = priority;
					secondHighestPriorityGoal = goal;
				}
			}
		}
		CharacterGoalData prevPrimaryGoal = GetCurrentGoal(ECurrentGoalType.Primary);
		CharacterGoalData prevSecondaryGoal = GetCurrentGoal(ECurrentGoalType.Secondary);
		bool primaryChanged = prevPrimaryGoal != highestPriorityGoal;
		bool secondaryChanged = prevSecondaryGoal != secondHighestPriorityGoal;
		if (!primaryChanged && !secondaryChanged)
		{
			return false;
		}
		if (primaryChanged && prevPrimaryGoal != secondHighestPriorityGoal && prevPrimaryGoal != null)
		{
			SetGoalReplaced(prevPrimaryGoal, currDate);
		}
		if (secondaryChanged && prevSecondaryGoal != highestPriorityGoal && prevSecondaryGoal != null)
		{
			SetGoalReplaced(prevSecondaryGoal, currDate);
		}
		highestPriorityGoal?.SetCurrent(isPrimary: true, currDate);
		secondHighestPriorityGoal?.SetCurrent(isPrimary: false, currDate);
		_primaryGoal = highestPriorityGoal;
		_secondaryGoal = secondHighestPriorityGoal;
		return true;
	}

	public void OnCharacterDead(DataContext context, Character character)
	{
		CharacterActionData primaryGoalAction = PrimaryGoalAction;
		if (primaryGoalAction != null && primaryGoalAction.Implementation != null)
		{
			primaryGoalAction.Implementation.OnCharacterDead(context, character, primaryGoalAction);
		}
		CharacterActionData secondaryGoalAction = GetCurrentAction(ECurrentGoalType.Secondary);
		if (secondaryGoalAction != null && secondaryGoalAction.Implementation != null)
		{
			secondaryGoalAction.Implementation.OnCharacterDead(context, character, secondaryGoalAction);
		}
	}

	public void OnTraveling(DataContext context, Character character)
	{
		CharacterActionData primaryGoalAction = PrimaryGoalAction;
		if (primaryGoalAction != null && primaryGoalAction.Implementation != null)
		{
			PrimaryGoalAction.Implementation.OnTraveling(context, character, primaryGoalAction);
		}
	}
}
