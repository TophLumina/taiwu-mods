using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Config;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.ActionPlanning.State;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.ActionPlanning.MonthlyAI;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true, NotForDisplayModule = true)]
public class CharacterGoalData : ISerializableGameData, IContextArgGroup, IGoal<GameData.Domains.Character.Character, StateKey>, INode<GameData.Domains.Character.Character, StateKey>, IEquatable<INode<GameData.Domains.Character.Character, StateKey>>
{
	public enum EGoalState : sbyte
	{
		Queued,
		Primary,
		Secondary,
		Replaced,
		Achieved
	}

	private static class FieldIds
	{
		public const ushort GoalTemplateId = 0;

		public const ushort CreateDate = 1;

		public const ushort NextUpdateDate = 2;

		public const ushort PriorityDelta = 3;

		public const ushort State = 4;

		public const ushort Plan = 5;

		public const ushort TriggeredBoolStates = 6;

		public const ushort ContextArgs = 7;

		public const ushort CurrentAction = 8;

		public const ushort TriggeredIntStates = 9;

		public const ushort Count = 10;

		public static readonly string[] FieldId2FieldName = new string[10] { "GoalTemplateId", "CreateDate", "NextUpdateDate", "PriorityDelta", "State", "Plan", "TriggeredBoolStates", "ContextArgs", "CurrentAction", "TriggeredIntStates" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int GoalTemplateId;

	[SerializableGameDataField(FieldIndex = 1)]
	public int CreateDate;

	[SerializableGameDataField(FieldIndex = 2)]
	public int NextUpdateDate;

	[SerializableGameDataField(FieldIndex = 3)]
	public int PriorityDelta;

	[SerializableGameDataField(FieldIndex = 4)]
	private sbyte _state;

	[SerializableGameDataField(FieldIndex = 5)]
	public List<int> Plan;

	[SerializableGameDataField(FieldIndex = 6)]
	private List<int> _triggeredBoolStates;

	[SerializableGameDataField(FieldIndex = 7)]
	public PlanningContextArg[] ContextArgs;

	[SerializableGameDataField(FieldIndex = 8)]
	public CharacterActionData CurrentAction;

	[SerializableGameDataField(FieldIndex = 9)]
	private Dictionary<int, int> _triggeredIntStates;

	public bool Unreachable;

	public readonly ContextArgGroupHandle Args;

	public PlanningGoalNode TemplateNode => CharacterActionPlanner.Instance.GetGoalNode(GoalTemplateId);

	public PlanningGoalItem Template => PlanningGoal.Instance[GoalTemplateId];

	public int RemainingMonths => (Template.Duration > 0) ? Math.Max(NextUpdateDate - DomainManager.World.GetCurrDate(), 0) : (-1);

	public bool IsTimeout => Template.Duration > 0 && RemainingMonths <= 0;

	public EGoalState State
	{
		get
		{
			return (EGoalState)_state;
		}
		set
		{
			_state = (sbyte)value;
		}
	}

	public bool IsCurrent => State == EGoalState.Primary || State == EGoalState.Secondary;

	public int GetPriority(GameData.Domains.Character.Character character)
	{
		PlanningGoalItem template = Template;
		return template.BasePriority + PriorityDelta + template.MoralityPriority[character.GetBehaviorType()] + TemplateNode.Settings.PriorityAdjust;
	}

	public bool Match(int templateId)
	{
		return templateId == GoalTemplateId;
	}

	public bool Match(int templateId, PlanningContextArg arg0)
	{
		int result;
		if (templateId == GoalTemplateId)
		{
			PlanningContextArg[] contextArgs = ContextArgs;
			if (contextArgs != null && contextArgs.Length >= 1)
			{
				result = (ContextArgs[0].Equals(arg0) ? 1 : 0);
				goto IL_002e;
			}
		}
		result = 0;
		goto IL_002e;
		IL_002e:
		return (byte)result != 0;
	}

	public bool Match(int templateId, PlanningContextArg arg0, PlanningContextArg arg1)
	{
		int result;
		if (templateId == GoalTemplateId)
		{
			PlanningContextArg[] contextArgs = ContextArgs;
			if (contextArgs != null && contextArgs.Length >= 2 && ContextArgs[0].Equals(arg0))
			{
				result = (ContextArgs[1].Equals(arg1) ? 1 : 0);
				goto IL_0042;
			}
		}
		result = 0;
		goto IL_0042;
		IL_0042:
		return (byte)result != 0;
	}

	public bool Match(int templateId, PlanningContextArg arg0, PlanningContextArg arg1, PlanningContextArg arg2)
	{
		int result;
		if (templateId == GoalTemplateId)
		{
			PlanningContextArg[] contextArgs = ContextArgs;
			if (contextArgs != null && contextArgs.Length >= 3 && ContextArgs[0].Equals(arg0) && ContextArgs[1].Equals(arg1))
			{
				result = (ContextArgs[2].Equals(arg2) ? 1 : 0);
				goto IL_0057;
			}
		}
		result = 0;
		goto IL_0057;
		IL_0057:
		return (byte)result != 0;
	}

	public void TryApplyEffect(StateEffect<StateKey> effect)
	{
		PlanningStateItem stateTemplate = effect.Key.Template;
		if (effect.Key.Template.SensorType != EPlanningStateSensorType.TriggerStateSensor)
		{
			return;
		}
		switch (stateTemplate.ValueType)
		{
		case EPlanningStateValueType.Int:
			if (_triggeredIntStates == null)
			{
				_triggeredIntStates = new Dictionary<int, int>();
			}
			if (!_triggeredIntStates.TryAdd(stateTemplate.TemplateId, 1))
			{
				_triggeredIntStates[stateTemplate.TemplateId]++;
			}
			break;
		case EPlanningStateValueType.Bool:
			if (_triggeredBoolStates == null)
			{
				_triggeredBoolStates = new List<int>();
			}
			if (!_triggeredBoolStates.Contains(stateTemplate.TemplateId))
			{
				_triggeredBoolStates.Add(stateTemplate.TemplateId);
			}
			break;
		}
	}

	public void FillStateMemory(IStateMemory<GameData.Domains.Character.Character, StateKey> stateMemory)
	{
		if (_triggeredBoolStates != null)
		{
			foreach (int state in _triggeredBoolStates)
			{
				stateMemory.SetState(state, 1);
			}
		}
		if (_triggeredIntStates == null)
		{
			return;
		}
		foreach (KeyValuePair<int, int> pair in _triggeredIntStates)
		{
			stateMemory.SetState(pair.Key, pair.Value);
		}
	}

	public CharacterGoalData(int templateId, int createDate, params PlanningContextArg[] args)
	{
		GoalTemplateId = templateId;
		CreateDate = createDate;
		ContextArgs = args;
		NextUpdateDate = CreateDate + Template.Duration;
		Args = new ContextArgGroupHandle(this);
	}

	public CharacterGoalData()
	{
		Args = new ContextArgGroupHandle(this);
	}

	public bool CheckParameters()
	{
		PlanningGoalItem template = Template;
		sbyte[] parameters = template.Parameters;
		int expectedArgCount = ((parameters != null) ? parameters.Length : 0);
		PlanningContextArg[] contextArgs = ContextArgs;
		int actualArgCount = ((contextArgs != null) ? contextArgs.Length : 0);
		if (expectedArgCount != actualArgCount)
		{
			AdaptableLog.TagWarning("CharacterGoalData", $"{template.Name}: Incorrect arg count.\n{expectedArgCount} expected, {actualArgCount} given.\n{new StackTrace()}", appendWarningMessage: true);
			return false;
		}
		if (template.Parameters == null || ContextArgs == null)
		{
			return true;
		}
		for (int i = 0; i < template.Parameters.Length; i++)
		{
			sbyte parameterType = template.Parameters[i];
			EPlanningParameterValueType parameterValueType = PlanningParameter.Instance[parameterType].ValueType;
			PlanningContextArg arg = ContextArgs[i];
			if (parameterValueType != arg.ValueType)
			{
				AdaptableLog.TagWarning("CharacterGoalData", $"{Template.Name}: Incorrect arg type at index {i}.\n{parameterValueType} expected, {arg.ValueType} given.\n{new StackTrace()}");
				return false;
			}
		}
		return true;
	}

	PlanningContextArg? IContextArgGroup.GetArgOfType(EPlanningParameterType type)
	{
		PlanningGoalItem template = Template;
		for (int i = 0; i < ContextArgs.Length; i++)
		{
			sbyte parameterTypeId = template.Parameters[i];
			if (PlanningParameter.Instance[parameterTypeId].Type == type)
			{
				return ContextArgs[i];
			}
		}
		return null;
	}

	void IContextArgGroup.SetArgOfType(EPlanningParameterType type, PlanningContextArg arg)
	{
		PlanningGoalItem template = Template;
		for (int i = 0; i < ContextArgs.Length; i++)
		{
			sbyte parameterTypeId = template.Parameters[i];
			if (PlanningParameter.Instance[parameterTypeId].Type == type)
			{
				ContextArgs[i] = arg;
				return;
			}
		}
		throw new Exception($"Accessing invalid argument of type {type}.");
	}

	void IContextArgGroup.RemoveArgOfType(EPlanningParameterType type)
	{
		throw new NotSupportedException();
	}

	public void ResetPlan()
	{
		Plan?.Clear();
		_triggeredBoolStates?.Clear();
	}

	public void SetReplaced(int currDate)
	{
		State = EGoalState.Replaced;
		ResetPlan();
	}

	public void SetCurrent(bool isPrimary, int currDate)
	{
		State = (isPrimary ? EGoalState.Primary : EGoalState.Secondary);
	}

	public void SetAchieved(int currDate)
	{
		State = EGoalState.Achieved;
		ResetPlan();
	}

	public override string ToString()
	{
		PlanningGoalItem template = Template;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(template.Name);
		sbyte[] parameters = template.Parameters;
		if (parameters != null && parameters.Length > 0)
		{
			stringBuilder.Append('(');
			for (int i = 0; i < template.Parameters.Length; i++)
			{
				sbyte parameterTypeId = template.Parameters[i];
				EPlanningParameterType parameterType = PlanningParameter.Instance[parameterTypeId].Type;
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(Args.ArgToString(parameterType, ContextArgs[i]));
			}
			stringBuilder.Append(')');
		}
		return stringBuilder.ToString();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 19;
		totalSize = ((Plan == null) ? (totalSize + 2) : (totalSize + (2 + 4 * Plan.Count)));
		totalSize = ((_triggeredBoolStates == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _triggeredBoolStates.Count)));
		totalSize = ((ContextArgs == null) ? (totalSize + 2) : (totalSize + (2 + 8 * ContextArgs.Length)));
		totalSize = ((CurrentAction == null) ? (totalSize + 2) : (totalSize + (2 + CurrentAction.GetSerializedSize())));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(_triggeredIntStates);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 10;
		pCurrData += 2;
		*(int*)pCurrData = GoalTemplateId;
		pCurrData += 4;
		*(int*)pCurrData = CreateDate;
		pCurrData += 4;
		*(int*)pCurrData = NextUpdateDate;
		pCurrData += 4;
		*(int*)pCurrData = PriorityDelta;
		pCurrData += 4;
		*pCurrData = (byte)_state;
		pCurrData++;
		if (Plan != null)
		{
			int elementsCount = Plan.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = Plan[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_triggeredBoolStates != null)
		{
			int elementsCount2 = _triggeredBoolStates.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = _triggeredBoolStates[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ContextArgs != null)
		{
			int elementsCount3 = ContextArgs.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData += ContextArgs[k].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CurrentAction != null)
		{
			byte* pSubDataCount = pCurrData;
			pCurrData += 2;
			int fieldSize = CurrentAction.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)pSubDataCount = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref _triggeredIntStates);
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
			GoalTemplateId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			CreateDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			NextUpdateDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			PriorityDelta = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 4)
		{
			_state = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 5)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (Plan == null)
				{
					Plan = new List<int>(elementsCount);
				}
				else
				{
					Plan.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					Plan.Add(((int*)pCurrData)[i]);
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				Plan?.Clear();
			}
		}
		if (fieldCount > 6)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (_triggeredBoolStates == null)
				{
					_triggeredBoolStates = new List<int>(elementsCount2);
				}
				else
				{
					_triggeredBoolStates.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					_triggeredBoolStates.Add(((int*)pCurrData)[j]);
				}
				pCurrData += 4 * elementsCount2;
			}
			else
			{
				_triggeredBoolStates?.Clear();
			}
		}
		if (fieldCount > 7)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (ContextArgs == null || ContextArgs.Length != elementsCount3)
				{
					ContextArgs = new PlanningContextArg[elementsCount3];
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					PlanningContextArg element = default(PlanningContextArg);
					pCurrData += element.Deserialize(pCurrData);
					ContextArgs[k] = element;
				}
			}
			else
			{
				ContextArgs = null;
			}
		}
		if (fieldCount > 8)
		{
			ushort fieldSize = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize > 0)
			{
				if (CurrentAction == null)
				{
					CurrentAction = new CharacterActionData();
				}
				pCurrData += CurrentAction.Deserialize(pCurrData);
			}
			else
			{
				CurrentAction = null;
			}
		}
		if (fieldCount > 9)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref _triggeredIntStates);
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public int GetMaxDepth()
	{
		return TemplateNode.GetMaxDepth();
	}

	public bool AllowNodeInPath(INode<GameData.Domains.Character.Character, StateKey> node)
	{
		return TemplateNode.AllowNodeInPath(node);
	}

	public bool IsValid(GameData.Domains.Character.Character character)
	{
		if (!TemplateNode.IsValid(character))
		{
			return false;
		}
		EPlanningGoalValidator[] validators = Template.Validators;
		if (validators == null || validators.Length <= 0)
		{
			return true;
		}
		EPlanningGoalValidator[] validators2 = Template.Validators;
		for (int i = 0; i < validators2.Length; i++)
		{
			switch (validators2[i])
			{
			case EPlanningGoalValidator.CharacterOwnItem:
			{
				ItemBase item = DomainManager.Item.TryGetBaseItem(Args.ItemType, Args.ItemId);
				if (item == null)
				{
					return false;
				}
				ItemKey itemKey = item.GetItemKey();
				if (!character.GetInventory().Items.ContainsKey(itemKey) && !character.GetEquipment().Exist(itemKey))
				{
					return false;
				}
				break;
			}
			case EPlanningGoalValidator.TargetCharIsNotNearbyFree:
			{
				int targetCharId = Args.TargetCharId;
				if (!DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar))
				{
					return true;
				}
				Location targetLocation = targetChar.GetLocation();
				if (!targetLocation.IsValid())
				{
					return true;
				}
				Location selfLocation = character.GetLocation();
				if (selfLocation.AreaId != targetLocation.AreaId)
				{
					return true;
				}
				byte areaSize = DomainManager.Map.GetAreaSize(selfLocation.AreaId);
				ByteCoordinate selfCoordinate = ByteCoordinate.IndexToCoordinate(selfLocation.BlockId, areaSize);
				ByteCoordinate targetCoordinate = ByteCoordinate.IndexToCoordinate(targetLocation.BlockId, areaSize);
				return selfCoordinate.GetManhattanDistance(targetCoordinate) > 3;
			}
			}
		}
		return true;
	}

	public bool Equals(INode<GameData.Domains.Character.Character, StateKey> other)
	{
		return this == other;
	}

	public IEnumerable<StateEffect<StateKey>> GetEffects()
	{
		return TemplateNode.GetEffects();
	}

	public IEnumerable<StateConditionAndValue<StateKey>> GetPreconditions()
	{
		return TemplateNode.GetPreconditions();
	}

	public IEnumerable<INode<GameData.Domains.Character.Character, StateKey>> GetDirectConnections()
	{
		return TemplateNode.GetDirectConnections();
	}

	public bool HasDirectConnections()
	{
		return TemplateNode.HasDirectConnections();
	}

	public bool HasDirectConnection(INode<GameData.Domains.Character.Character, StateKey> other)
	{
		return TemplateNode.HasDirectConnection(other);
	}

	public int GetWeight(IAgent<GameData.Domains.Character.Character, StateKey> agent)
	{
		return TemplateNode.GetWeight(agent);
	}
}
