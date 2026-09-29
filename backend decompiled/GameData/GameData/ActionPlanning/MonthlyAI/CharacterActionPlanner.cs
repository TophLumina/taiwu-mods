using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Config;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.ActionPlanning.MonthlyAI.Sensor;
using GameData.ActionPlanning.State;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Utilities;

namespace GameData.ActionPlanning.MonthlyAI;

public class CharacterActionPlanner : ActionPlanner<DataContext, CharacterStateMemory, GameData.Domains.Character.Character, StateKey>
{
	public static readonly CharacterActionPlanner Instance = new CharacterActionPlanner();

	private readonly ISensor<IStateMemory<GameData.Domains.Character.Character, StateKey>, GameData.Domains.Character.Character, StateKey>[] _sensors;

	private readonly List<PlanningActionNode> _actionNodes;

	private readonly List<PlanningGoalNode> _goalNodes;

	private readonly List<PlanningGoalNode> _prioritizedGoals;

	private readonly object[] _checkLifeRecordArgs = new object[1];

	private CharacterActionPlanner()
	{
		_actionNodes = new List<PlanningActionNode>();
		_goalNodes = new List<PlanningGoalNode>();
		_prioritizedGoals = new List<PlanningGoalNode>();
		_sensors = new ISensor<IStateMemory<GameData.Domains.Character.Character, StateKey>, GameData.Domains.Character.Character, StateKey>[12];
		RegisterSensor(EPlanningStateSensorType.TriggerStateSensor, new TriggerStateSensor());
		RegisterSensor(EPlanningStateSensorType.CharacterStateSensor, new CharacterStateSensor());
		RegisterSensor(EPlanningStateSensorType.CombatSkillStateSensor, new CombatSkillStateSensor());
		RegisterSensor(EPlanningStateSensorType.LifeSkillStateSensor, new LifeSkillStateSensor());
		RegisterSensor(EPlanningStateSensorType.MainAttributeStateSensor, new MainAttributeStateSensor());
		RegisterSensor(EPlanningStateSensorType.ProfessionStateSensor, new ProfessionStateSensor());
		RegisterSensor(EPlanningStateSensorType.ResourceStateSensor, new ResourceStateSensor());
		RegisterSensor(EPlanningStateSensorType.OrganizationStateSensor, new OrganizationStateSensor());
		RegisterSensor(EPlanningStateSensorType.TargetStateSensor, new TargetStateSensor());
		RegisterSensor(EPlanningStateSensorType.GoalArgumentStateSensor, new GoalArgumentStateSensor());
		AdaptableLog.Info("CharacterActionPlanner created.");
	}

	public void Initialize()
	{
		_prioritizedGoals.Clear();
		_goalNodes.Clear();
		foreach (PlanningGoalItem goalTemplate in (IEnumerable<PlanningGoalItem>)PlanningGoal.Instance)
		{
			_goalNodes.Add(new PlanningGoalNode(goalTemplate));
		}
		_actionNodes.Clear();
		foreach (PlanningActionItem actionTemplate in (IEnumerable<PlanningActionItem>)PlanningAction.Instance)
		{
			_actionNodes.Add(new PlanningActionNode(actionTemplate));
		}
		string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GameData.ActionPlanning.ActionImpl.dll");
		if (File.Exists(path))
		{
			Assembly assembly = Assembly.LoadFile(path);
			LoadActionImplementations(assembly, "GameData.ActionPlanning.ActionImpl");
		}
		Build(_goalNodes, GetImplementedActions());
		foreach (PlanningGoalNode goalNode in _goalNodes)
		{
			goalNode.Reachable = CheckNodeReachable(goalNode);
			if (goalNode.Template.IsPrioritizedGoal)
			{
				_prioritizedGoals.Add(goalNode);
			}
		}
		foreach (PlanningActionNode actionNode in _actionNodes)
		{
			actionNode.Reachable = CheckNodeReachable(actionNode);
		}
		AdaptableLog.Info("CharacterActionPlanner initialized.");
	}

	public IEnumerable<PlanningGoalNode> GetPrioritizedGoals()
	{
		return _prioritizedGoals;
	}

	private IEnumerable<PlanningActionNode> GetImplementedActions()
	{
		foreach (PlanningActionNode action in _actionNodes)
		{
			if (action.IsImplemented)
			{
				yield return action;
			}
		}
	}

	public override bool CheckNodeReachable(INode<GameData.Domains.Character.Character, StateKey> node)
	{
		if (!base.CheckNodeReachable(node))
		{
			return false;
		}
		foreach (StateConditionAndValue<StateKey> condition in node.GetPreconditions())
		{
			if (condition.Condition.Key.Template.SensorType == EPlanningStateSensorType.None)
			{
				return false;
			}
		}
		if (node is PlanningGoalNode goalNode)
		{
			StateConditionAndValue<StateKey>[] targetCharacterConditionsA = goalNode.Template.TargetCharacterConditionsA;
			foreach (StateConditionAndValue<StateKey> condition2 in targetCharacterConditionsA)
			{
				if (condition2.Condition.Key.Template.SensorType == EPlanningStateSensorType.None)
				{
					return false;
				}
			}
			StateConditionAndValue<StateKey>[] targetCharacterConditionsB = goalNode.Template.TargetCharacterConditionsB;
			foreach (StateConditionAndValue<StateKey> condition3 in targetCharacterConditionsB)
			{
				if (condition3.Condition.Key.Template.SensorType == EPlanningStateSensorType.None)
				{
					return false;
				}
			}
			StateConditionAndValue<StateKey>[] targetCharacterConditionsC = goalNode.Template.TargetCharacterConditionsC;
			foreach (StateConditionAndValue<StateKey> condition4 in targetCharacterConditionsC)
			{
				if (condition4.Condition.Key.Template.SensorType == EPlanningStateSensorType.None)
				{
					return false;
				}
			}
		}
		else if (node is PlanningActionNode actionNode)
		{
			StateConditionAndValue<StateKey>[] selfRestrictions = actionNode.Template.SelfRestrictions;
			foreach (StateConditionAndValue<StateKey> condition5 in selfRestrictions)
			{
				if (condition5.Condition.Key.Template.SensorType == EPlanningStateSensorType.None)
				{
					return false;
				}
			}
			StateConditionAndValue<StateKey>[] targetCharacterConditions = actionNode.Template.TargetCharacterConditions;
			foreach (StateConditionAndValue<StateKey> condition6 in targetCharacterConditions)
			{
				if (condition6.Condition.Key.Template.SensorType == EPlanningStateSensorType.None)
				{
					return false;
				}
			}
		}
		if (node.HasDirectConnections() && !node.GetDirectConnections().Any((INode<GameData.Domains.Character.Character, StateKey> connection) => connection is PlanningActionNode planningActionNode && planningActionNode.IsImplemented))
		{
			return false;
		}
		return true;
	}

	public override void Plan(DataContext context, IAgent<GameData.Domains.Character.Character, StateKey> agent, int maxDepth = -1)
	{
		try
		{
			base.Plan(context, agent, maxDepth);
		}
		catch (Exception arg)
		{
			agent.Plan.Clear();
			PredefinedLog.DefValue.CharacterActionPlanningFailed.Log(agent.Object, agent.Goal, arg);
		}
	}

	public override bool ReassessPlan(DataContext context, IAgent<GameData.Domains.Character.Character, StateKey> agent, out bool modified)
	{
		try
		{
			return base.ReassessPlan(context, agent, out modified);
		}
		catch (Exception arg)
		{
			agent.Plan.Clear();
			modified = true;
			PredefinedLog.DefValue.CharacterActionPlanningFailed.Log(agent.Object, agent.Goal, arg);
			return false;
		}
	}

	public PlanningActionNode GetActionNode(int templateId)
	{
		return _actionNodes[templateId];
	}

	public PlanningGoalNode GetGoalNode(int templateId)
	{
		return _goalNodes[templateId];
	}

	public void LoadActionImplementations(Assembly assembly, string implNamespace)
	{
		foreach (PlanningActionNode action in _actionNodes)
		{
			LoadActionImplementation(assembly, action, implNamespace);
		}
	}

	public void LoadActionImplementation(Assembly assembly, PlanningActionNode action, string implNamespace)
	{
		if (string.IsNullOrEmpty(action.Template.ImplementationPath))
		{
			return;
		}
		Type type = (string.IsNullOrEmpty(implNamespace) ? assembly.GetType(action.Template.ImplementationPath) : assembly.GetType(implNamespace + "." + action.Template.ImplementationPath));
		if (type == null)
		{
			AdaptableLog.TagWarning("LoadActionImplementation", "Cannot find implementation " + action.Template.ImplementationPath);
		}
		else
		{
			if (!type.IsAssignableTo(typeof(ICharacterActionImpl)))
			{
				return;
			}
			MethodInfo checkLifeRecords = type.GetMethod("CheckLifeRecords", (BindingFlags)(-1));
			_checkLifeRecordArgs[0] = action.Template;
			if (checkLifeRecords != null)
			{
				object obj = checkLifeRecords.Invoke(null, _checkLifeRecordArgs);
				if (!(obj is bool) || !(bool)obj)
				{
					string refName = PlanningAction.Instance.GetRefName(action.Template.TemplateId);
					AdaptableLog.TagWarning("LoadActionImplementation", "Invalid life record args configured for action " + refName);
					return;
				}
			}
			action.SetImplementation(type);
		}
	}

	public ISensor<IStateMemory<GameData.Domains.Character.Character, StateKey>, GameData.Domains.Character.Character, StateKey> GetSensor(EPlanningStateSensorType sensorType)
	{
		return _sensors[(int)sensorType];
	}

	private void RegisterSensor(EPlanningStateSensorType sensorType, ISensor<IStateMemory<GameData.Domains.Character.Character, StateKey>, GameData.Domains.Character.Character, StateKey> sensor)
	{
		_sensors[(int)sensorType] = sensor;
	}
}
