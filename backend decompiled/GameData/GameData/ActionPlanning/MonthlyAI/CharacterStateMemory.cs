using System;
using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.State;
using GameData.Domains.Character;
using GameData.Domains.Item;

namespace GameData.ActionPlanning.MonthlyAI;

public class CharacterStateMemory : StateMemory<GameData.Domains.Character.Character, StateKey>, IContextArgGroup
{
	public GameData.Domains.Character.Character TargetChar = null;

	private readonly List<(EPlanningParameterType type, PlanningContextArg value)> _contextArgs = new List<(EPlanningParameterType, PlanningContextArg)>();

	public readonly ContextArgGroupHandle Args;

	public CharacterStateMemory()
	{
		Args = new ContextArgGroupHandle(this);
	}

	public override void InitContext(IAgent<GameData.Domains.Character.Character, StateKey> agent)
	{
		Inherit(agent.Memory);
		if (agent.Goal is CharacterGoalData { Template: var template } goal)
		{
			sbyte[] parameters = template.Parameters;
			if (parameters != null && parameters.Length > 0)
			{
				for (int i = 0; i < template.Parameters.Length; i++)
				{
					sbyte paramTypeId = template.Parameters[i];
					PlanningParameterItem parameter = PlanningParameter.Instance[paramTypeId];
					_contextArgs.Add((parameter.Type, goal.ContextArgs[i]));
				}
			}
		}
		foreach (StateConditionAndValue<StateKey> condition in agent.Goal.GetPreconditions())
		{
			AddCondition(agent, condition);
		}
	}

	public override void Inherit(IStateMemory<GameData.Domains.Character.Character, StateKey> other)
	{
		_contextArgs.Clear();
		if (other is CharacterStateMemory charStateMemory)
		{
			TargetChar = charStateMemory.TargetChar;
			_contextArgs.AddRange(charStateMemory._contextArgs);
		}
		base.Inherit(other);
	}

	protected override bool TryMatchAndInheritStateParameter(StateKey effectState, StateKey conditionState)
	{
		if (effectState.StateTemplateId == conditionState.StateTemplateId)
		{
			return true;
		}
		PlanningStateItem conditionStateTemplate = conditionState.Template;
		PlanningStateItem effectStateTemplate = effectState.Template;
		if (effectState.IsSubStateOf(conditionState))
		{
			if (conditionStateTemplate.InputParamType >= 0)
			{
				if (conditionStateTemplate.InputParamType == effectStateTemplate.InputParamType)
				{
					return true;
				}
				if (effectStateTemplate.OutputParamType < 0)
				{
					return false;
				}
				if (MatchParameterValue(conditionStateTemplate.InputParamType, effectStateTemplate.OutputParamType, effectStateTemplate.OutputParamValue))
				{
					return true;
				}
			}
			else if (conditionStateTemplate.OutputParamType >= 0 && conditionStateTemplate.OutputParamType == effectStateTemplate.OutputParamType)
			{
				return true;
			}
		}
		else if (conditionState.IsSubStateOf(effectState))
		{
			if (effectStateTemplate.InputParamType >= 0)
			{
				if (conditionStateTemplate.InputParamType >= 0)
				{
					return effectStateTemplate.InputParamType == conditionStateTemplate.InputParamType;
				}
				if (conditionStateTemplate.OutputParamType >= 0)
				{
					ContextArgGroupHandle args = Args;
					PlanningParameterItem parameterCfg = PlanningParameter.Instance[conditionStateTemplate.OutputParamType];
					args[parameterCfg.Type] = CreateArg(parameterCfg, conditionStateTemplate.OutputParamValue);
					return true;
				}
			}
			else if (effectStateTemplate.OutputParamType >= 0)
			{
				return conditionStateTemplate.OutputParamType == effectStateTemplate.OutputParamType;
			}
		}
		return false;
	}

	private PlanningContextArg CreateArg(PlanningParameterItem parameterCfg, int outputValue)
	{
		EPlanningParameterValueType valueType = parameterCfg.ValueType;
		if (1 == 0)
		{
		}
		PlanningContextArg result = valueType switch
		{
			EPlanningParameterValueType.Int => outputValue, 
			EPlanningParameterValueType.Sbyte => (sbyte)outputValue, 
			EPlanningParameterValueType.Short => (short)outputValue, 
			EPlanningParameterValueType.Ushort => (ushort)outputValue, 
			EPlanningParameterValueType.Uint => (uint)outputValue, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private bool MatchParameterValue(sbyte inputParameterType, sbyte outputParameterType, int outputValue)
	{
		PlanningParameterItem inputParamCfg = PlanningParameter.Instance[inputParameterType];
		PlanningParameterItem outputParamCfg = PlanningParameter.Instance[outputParameterType];
		if (inputParameterType == outputParameterType)
		{
			PlanningContextArg? arg = Args[outputParamCfg.Type];
			bool hasValue = arg.HasValue;
			bool flag = hasValue;
			if (flag)
			{
				EPlanningParameterValueType valueType = outputParamCfg.ValueType;
				if (1 == 0)
				{
				}
				bool flag2 = valueType switch
				{
					EPlanningParameterValueType.Int => (int)arg.Value == outputValue, 
					EPlanningParameterValueType.Sbyte => (sbyte)arg.Value == outputValue, 
					EPlanningParameterValueType.Short => (short)arg.Value == outputValue, 
					EPlanningParameterValueType.Ushort => (ushort)arg.Value == outputValue, 
					EPlanningParameterValueType.Uint => (ulong)(ushort)arg.Value == (ulong)outputValue, 
					_ => false, 
				};
				if (1 == 0)
				{
				}
				flag = flag2;
			}
			return flag;
		}
		if (outputParamCfg.Type == EPlanningParameterType.ItemSubType && inputParamCfg.Type == EPlanningParameterType.ItemTemplate)
		{
			if (!Args[outputParamCfg.Type].HasValue)
			{
				return false;
			}
			short itemSubType = (short)outputValue;
			return ItemTemplateHelper.GetItemSubType(Args.ItemType, Args.ItemTemplateId) == itemSubType;
		}
		return false;
	}

	public override void Clear()
	{
		ClearLocalValues();
		base.Clear();
	}

	private void ClearLocalValues()
	{
		TargetChar = null;
		_contextArgs.Clear();
	}

	PlanningContextArg? IContextArgGroup.GetArgOfType(EPlanningParameterType type)
	{
		foreach (var arg in _contextArgs)
		{
			if (arg.type == type)
			{
				return arg.value;
			}
		}
		return null;
	}

	void IContextArgGroup.SetArgOfType(EPlanningParameterType type, PlanningContextArg arg)
	{
		for (int index = 0; index < _contextArgs.Count; index++)
		{
			if (_contextArgs[index].type == type)
			{
				_contextArgs[index] = (type, arg);
				return;
			}
		}
		_contextArgs.Add((type, arg));
	}

	void IContextArgGroup.RemoveArgOfType(EPlanningParameterType type)
	{
		for (int index = 0; index < _contextArgs.Count; index++)
		{
			if (_contextArgs[index].type == type)
			{
				_contextArgs.RemoveAt(index);
				break;
			}
		}
	}
}
