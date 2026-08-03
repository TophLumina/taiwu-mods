using System;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using Config.EventConfig;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class BasicFunctions
{
	[EventFunction(0)]
	private static ValueInfo If(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		bool condition = parameters[0].GetBoolValue(runtime.Evaluator);
		ScriptExecutionInstance instance = runtime.Current;
		int indent = instance.GetCurrentIndentAmount();
		instance.ExecuteBranch(indent, condition);
		instance.EnterScope(ScriptExecutionInstance.ScopeType.If);
		if (!condition)
		{
			instance.ExitScope(indent + 1);
		}
		return ValueInfo.Void;
	}

	[EventFunction(1)]
	private static ValueInfo Else(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		ScriptExecutionInstance instance = runtime.Current;
		int indent = instance.GetCurrentIndentAmount();
		if (instance.IsBranchEntered(indent))
		{
			instance.ExitScope(indent + 1);
		}
		else
		{
			instance.ExecuteBranch(indent, executed: true);
			instance.EnterScope(ScriptExecutionInstance.ScopeType.If);
		}
		return ValueInfo.Void;
	}

	[EventFunction(2)]
	private static ValueInfo ElseIf(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		ScriptExecutionInstance instance = runtime.Current;
		int indent = instance.GetCurrentIndentAmount();
		if (instance.IsBranchEntered(indent))
		{
			instance.ExecuteBranch(indent, executed: true);
			instance.ExitScope(indent + 1);
		}
		else
		{
			If(runtime, parameters);
		}
		return ValueInfo.Void;
	}

	[EventFunction(3)]
	private static ValueInfo Loop(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		ScriptExecutionInstance instance = runtime.Current;
		instance.EnterScope(ScriptExecutionInstance.ScopeType.Loop);
		if (parameters.CheckIndex(0))
		{
			switch (parameters[0].Evaluate(runtime.Evaluator).ValueType)
			{
			case EValueType.Bool:
			{
				bool condition = runtime.Evaluator.EvaluationStack.PopUnmanaged<bool>();
				instance.CheckAndAdvanceIteration(condition);
				break;
			}
			case EValueType.Int:
			{
				int maxCount = runtime.Evaluator.EvaluationStack.PopUnmanaged<int>();
				instance.CheckAndAdvanceIteration(maxCount);
				break;
			}
			}
		}
		else
		{
			instance.CheckAndAdvanceIteration(condition: true);
		}
		return ValueInfo.Void;
	}

	[EventFunction(4)]
	private static ValueInfo Break(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		runtime.Current.BreakLoop();
		return ValueInfo.Void;
	}

	[EventFunction(6)]
	private static ValueInfo Continue(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		runtime.Current.GotoLoopHead();
		return ValueInfo.Void;
	}

	[EventFunction(7)]
	private static ValueInfo Label(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		return ValueInfo.Void;
	}

	[EventFunction(8)]
	private static ValueInfo Jump(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		string label = parameters[0].GetStringValue(runtime.Evaluator);
		runtime.Current.GotoLabel(label);
		return ValueInfo.Void;
	}

	[EventFunction(11)]
	private static ValueInfo Random(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		int min = parameters[0].GetIntValue(runtime.Evaluator);
		int max = parameters[1].GetIntValue(runtime.Evaluator);
		int retVal = runtime.Context.Random.Next(min, max);
		return runtime.Evaluator.PushEvaluationResult(retVal);
	}

	[EventFunction(12)]
	private static ValueInfo CheckProb(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		int chance = parameters[0].GetIntValue(runtime.Evaluator);
		bool retVal = runtime.Context.Random.CheckPercentProb(chance);
		return runtime.Evaluator.PushEvaluationResult(retVal);
	}

	[EventFunction(215)]
	private static ValueInfo GetListLength(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		object array = parameters[0].GetAnyValue(evaluator);
		if (1 == 0)
		{
		}
		int num = ((array is GameData.Utilities.ShortList shortList) ? (shortList.Items?.Count ?? 0) : ((array is IntList intList) ? (intList.Items?.Count ?? 0) : ((array is ItemList itemList) ? itemList.Count : ((array is IReadOnlySerializableList serializableList) ? serializableList.GetCount() : 0))));
		if (1 == 0)
		{
		}
		int length = num;
		return evaluator.PushEvaluationResult(length);
	}

	[EventFunction(216)]
	private static ValueInfo GetListElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		object obj = parameters[0].GetAnyValue(evaluator);
		int index = parameters[1].GetIntValue(evaluator);
		object obj2 = obj;
		object obj3 = obj2;
		if (!(obj3 is IntList intList))
		{
			if (!(obj3 is GameData.Utilities.ShortList shortList))
			{
				if (!(obj3 is ItemList itemList))
				{
					if (obj3 is IReadOnlySerializableList serializableList)
					{
						return evaluator.PushEvaluationResult(serializableList.GetElementAt(index));
					}
					throw new InvalidCastException($"Unable to cast object {obj} to a list.");
				}
				return evaluator.PushEvaluationResult(itemList[index]);
			}
			return evaluator.PushEvaluationResult(shortList.Items[index]);
		}
		return evaluator.PushEvaluationResult(intList.Items[index]);
	}

	[EventFunction(218)]
	private static ValueInfo CheckListElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		object obj = parameters[0].GetAnyValue(evaluator);
		int index = parameters[1].GetIntValue(evaluator);
		string key = parameters[2].GetStringValue(evaluator);
		object obj2 = obj;
		object obj3 = obj2;
		if (!(obj3 is IntList intList))
		{
			if (!(obj3 is GameData.Utilities.ShortList shortList))
			{
				if (!(obj3 is ItemList itemList))
				{
					if (obj3 is IReadOnlySerializableList serializableList)
					{
						if (serializableList.GetCount() <= index)
						{
							return evaluator.PushEvaluationResult(value: false);
						}
						runtime.ArgBox.Set(key, serializableList.GetElementAt(index));
						return evaluator.PushEvaluationResult(value: true);
					}
					return evaluator.PushEvaluationResult(value: false);
				}
				if (itemList.Count <= index)
				{
					return evaluator.PushEvaluationResult(value: false);
				}
				runtime.ArgBox.Set(key, itemList[index]);
				return evaluator.PushEvaluationResult(value: true);
			}
			if (shortList.Items == null || shortList.Items.Count <= index)
			{
				return evaluator.PushEvaluationResult(value: false);
			}
			runtime.ArgBox.Set(key, shortList.Items[index]);
			return evaluator.PushEvaluationResult(value: true);
		}
		if (intList.Items == null || intList.Items.Count <= index)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		runtime.ArgBox.Set(key, intList.Items[index]);
		return evaluator.PushEvaluationResult(value: true);
	}

	[EventFunction(91)]
	private static ValueInfo ExecuteGlobalScript(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		string scriptGuid = parameters[0].GetStringValue(runtime.Evaluator);
		EventArgBox argBox = runtime.Current.ArgBox;
		runtime.ExecuteGlobalScript(scriptGuid, argBox);
		return ValueInfo.Void;
	}

	[EventFunction(9)]
	private static ValueInfo Return(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		runtime.Current.ExitScript();
		return ValueInfo.Void;
	}

	[EventFunction(10)]
	private static ValueInfo Assign(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		return parameters[0].Evaluate(runtime.Evaluator);
	}

	[EventFunction(14)]
	private static ValueInfo Log(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		string text = parameters[0].GetAnyValueAsString(runtime.Evaluator);
		runtime.Log(text);
		return ValueInfo.Void;
	}

	[EventFunction(15)]
	private static ValueInfo Comment(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		return ValueInfo.Void;
	}

	[EventFunction(5)]
	private static ValueInfo End(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		return ValueInfo.Void;
	}

	[EventFunction(13)]
	private static ValueInfo EventTransition(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		ScriptExecutionInstance current = runtime.Current;
		current.NextEvent = parameters[0].GetStringValue(runtime.Evaluator);
		current.ExitScript();
		return ValueInfo.Void;
	}

	[EventFunction(94)]
	private static ValueInfo OptionInjection(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		ScriptExecutionInstance current = runtime.Current;
		EventScriptId scriptId = current.ScriptId;
		Evaluator evaluator = runtime.Evaluator;
		string srcEventGuid = scriptId.EventScriptRef.Guid.ToString();
		int optionId = parameters[0].GetIntValue(evaluator);
		string targetEventGuid = parameters[1].GetStringValue(evaluator);
		TaiwuEvent targetEvent = DomainManager.TaiwuEvent.GetEvent(targetEventGuid);
		TaiwuEvent srcEvent = DomainManager.TaiwuEvent.GetEvent(srcEventGuid);
		targetEvent.AddOption(srcEventGuid, srcEvent.EventConfig.EventOptions[optionId - 1].OptionKey);
		return ValueInfo.Void;
	}

	[EventFunction(420)]
	private static ValueInfo InjectAllOptions(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		string fromEventGuid = parameters[0].GetStringValue(evaluator);
		string toEventGuid = parameters[1].GetStringValue(evaluator);
		TaiwuEvent fromEvent = DomainManager.TaiwuEvent.GetEvent(fromEventGuid);
		TaiwuEvent toEvent = DomainManager.TaiwuEvent.GetEvent(toEventGuid);
		TaiwuEventOption[] eventOptions = fromEvent.EventConfig.EventOptions;
		foreach (TaiwuEventOption option in eventOptions)
		{
			toEvent.AddOption(fromEventGuid, option.OptionKey);
		}
		return ValueInfo.Void;
	}

	[EventFunction(437)]
	private static ValueInfo GetCurrentEvent(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		return runtime.Evaluator.PushEvaluationResult(runtime.Current.EventGuid);
	}

	[EventFunction(101)]
	private static ValueInfo SaveSectMainStoryValue(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte orgTemplateId = (sbyte)parameters[0].GetIntValue(evaluator);
		string key = parameters[1].GetStringValue(evaluator);
		ValueInfo valueInfo = parameters[2].Evaluate(evaluator);
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(orgTemplateId);
		SaveValueToArgBox(evaluator, key, valueInfo, argBox);
		DomainManager.Extra.SaveSectMainStoryEventArgumentBox(runtime.Context, orgTemplateId);
		return ValueInfo.Void;
	}

	[EventFunction(102)]
	private static ValueInfo ReadSectMainStoryValue(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte orgTemplateId = (sbyte)parameters[0].GetIntValue(evaluator);
		string key = parameters[1].GetStringValue(evaluator);
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(orgTemplateId);
		return argBox.SelectValue(evaluator, key);
	}

	[EventFunction(485)]
	private static ValueInfo SaveGlobalValue(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		string key = parameters[0].GetStringValue(evaluator);
		ValueInfo valueInfo = parameters[1].Evaluate(evaluator);
		EventArgBox argBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		SaveValueToArgBox(evaluator, key, valueInfo, argBox);
		DomainManager.TaiwuEvent.SaveGlobalEventArgumentBox();
		return ValueInfo.Void;
	}

	[EventFunction(486)]
	private static ValueInfo ReadGlobalValue(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		string key = parameters[0].GetStringValue(evaluator);
		EventArgBox argBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		return argBox.SelectValue(evaluator, key);
	}

	private static void SaveValueToArgBox(Evaluator evaluator, string key, ValueInfo valueInfo, EventArgBox argBox)
	{
		switch (valueInfo.ValueType)
		{
		case EValueType.Int:
		{
			int value3 = evaluator.EvaluationStack.PopUnmanaged<int>();
			argBox.Set(key, value3);
			break;
		}
		case EValueType.Float:
		{
			float value4 = evaluator.EvaluationStack.PopUnmanaged<float>();
			argBox.Set(key, value4);
			break;
		}
		case EValueType.Bool:
		{
			bool value5 = evaluator.EvaluationStack.PopUnmanaged<bool>();
			argBox.Set(key, value5);
			break;
		}
		case EValueType.Str:
		{
			string value2 = evaluator.EvaluationStack.PopObject<string>();
			argBox.Set(key, value2);
			break;
		}
		case EValueType.Obj:
		{
			object value = evaluator.EvaluationStack.PopObject<object>();
			object obj = value;
			object obj2 = obj;
			if (!(obj2 is GameData.Domains.Character.Character character))
			{
				if (!(obj2 is Settlement settlement))
				{
					if (!(obj2 is ItemKey itemKey))
					{
						if (obj2 is MapBlockData mapBlock)
						{
							argBox.Set(key, mapBlock.GetLocation());
							break;
						}
						if (!EventArgBox.SerializeObjectMap.ContainsKey(value.GetType()))
						{
							throw new Exception($"Cannot save object {value}.");
						}
						argBox.Set(key, (ISerializableGameData)value);
					}
					else
					{
						argBox.Set(key, itemKey);
					}
				}
				else
				{
					argBox.Set(key, settlement.GetId());
				}
			}
			else
			{
				argBox.Set(key, character.GetId());
			}
			break;
		}
		}
	}

	[EventFunction(118)]
	private static void StartLifeSkillCombat(EventScriptRuntime runtime, GameData.Domains.Character.Character character, string onFinishEventId, bool normalBp, bool targetSelect, sbyte lifeSKillType)
	{
		if (character == null)
		{
			throw new ArgumentNullException("character");
		}
		if (normalBp)
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartLifeSkillCombat(character.GetId(), 16, onFinishEventId, runtime.Current.ArgBox);
		}
		else if (targetSelect)
		{
			sbyte type = character.GetLifeSkillAttainments().GetMaxLifeSkillType();
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartLifeSkillCombat(character.GetId(), type, onFinishEventId, runtime.Current.ArgBox);
		}
		else
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartLifeSkillCombat(character.GetId(), lifeSKillType, onFinishEventId, runtime.Current.ArgBox);
		}
	}

	[EventFunction(397)]
	private static void SetCommonOptionAvailable(EventScriptRuntime runtime, int type)
	{
		runtime.ArgBox.Set("ShowCommonOption", type);
	}

	[EventFunction(513)]
	private static void BanCommonOption(EventScriptRuntime runtime, bool ban)
	{
		runtime.ArgBox.Set("BanCommonOption", ban);
	}

	[EventFunction(424)]
	private static ValueInfo CheckValueExist(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		string key = parameters[0].GetStringValue(evaluator);
		bool result = runtime.ArgBox.ContainsKey(key);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(489)]
	private static bool RemoveArgBoxValue(EventScriptRuntime runtime, string key)
	{
		bool result = runtime.ArgBox.ContainsKey(key);
		if (result)
		{
			runtime.ArgBox.RemoveKey(key);
		}
		return result;
	}

	[EventFunction(490)]
	private static void ClearArgBoxValue(EventScriptRuntime runtime)
	{
		runtime.ArgBox.Clear();
	}

	[EventFunction(862)]
	private static void EventClearListeningEvent(EventScriptRuntime runtime)
	{
		DomainManager.TaiwuEvent.ClearListeningEvent();
	}

	[EventFunction(568)]
	private static ValueInfo GetLocalLanguageString(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		string key = parameters[0].GetStringValue(evaluator);
		return evaluator.PushEvaluationResult(LocalStringManager.Get(key));
	}

	[EventFunction(640)]
	private static ValueInfo SetListenerWithActionName(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		string key = parameters[0].GetStringValue(evaluator);
		string guid = parameters[1].GetStringValue(evaluator);
		EventArgBox argBox = DomainManager.TaiwuEvent.GetEventArgBox();
		runtime.ArgBox.CloneTo(argBox);
		DomainManager.TaiwuEvent.SetListenerWithActionName(guid, argBox, key);
		return ValueInfo.Void;
	}

	[EventFunction(654)]
	private static ValueInfo TryGetEventTriggerParameter(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int parameterId = parameters[0].GetIntValue(evaluator);
		string key = parameters[1].GetStringValue(evaluator);
		string parameterKey = EventTriggerParameter.Instance[parameterId].ArgBoxKey;
		int intVal = 0;
		if (runtime.ArgBox.Get(parameterKey, ref intVal))
		{
			runtime.ArgBox.Set(key, intVal);
			return evaluator.PushEvaluationResult(value: true);
		}
		float floatVal = 0f;
		if (runtime.ArgBox.Get(parameterKey, ref floatVal))
		{
			runtime.ArgBox.Set(key, floatVal);
			return evaluator.PushEvaluationResult(value: true);
		}
		bool boolVal = false;
		if (runtime.ArgBox.Get(parameterKey, ref boolVal))
		{
			runtime.ArgBox.Set(key, boolVal);
			return evaluator.PushEvaluationResult(value: true);
		}
		string strVal = null;
		if (runtime.ArgBox.Get(parameterKey, ref strVal))
		{
			runtime.ArgBox.Set(key, strVal);
			return evaluator.PushEvaluationResult(value: true);
		}
		if (runtime.ArgBox.Get(parameterKey, out ISerializableGameData val))
		{
			runtime.ArgBox.Set(key, val);
			return evaluator.PushEvaluationResult(value: true);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(767)]
	private static ValueInfo GetRandomUnrepeated(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int seed = parameters[0].GetIntValue(evaluator);
		int count = parameters[1].GetIntValue(evaluator);
		int index = parameters[2].GetIntValue(evaluator);
		int value = runtime.GetRandomUnrepeated(seed, count, index);
		return evaluator.PushEvaluationResult(value);
	}
}
