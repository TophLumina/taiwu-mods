using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using Config.EventConfig;
using GameData.Common;
using GameData.Domains.Map;
using GameData.Domains.TaiwuEvent.Decompiler;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Domains.TaiwuEvent.FunctionDefinition;
using GameData.Domains.TaiwuEvent.ObjectInitializer;
using GameData.Domains.TaiwuEvent.ValueSelector;
using GameData.Serializer;
using GameData.Utilities;
using NLog;
using Redzen.Random;

namespace GameData.Domains.TaiwuEvent;

public class EventScriptRuntime : IInterpreterContext<EventScriptRuntime>
{
	public readonly DataContext Context;

	public Instruction<EventScriptRuntime> ExecutingInstruction;

	private readonly Dictionary<ulong, IEventScriptDecompiler> _decompilers;

	private readonly Interpreter<EventScriptRuntime> _interpreter;

	private readonly Dictionary<int, string> _funcIdToNameMap;

	private readonly Stack<ScriptExecutionInstance> _executionInstances;

	private readonly Dictionary<string, EventScript> _globalScripts;

	private static readonly LocalObjectPool<ScriptExecutionInstance> ObjectPool = new LocalObjectPool<ScriptExecutionInstance>(4, 32);

	private EventArgBox _conditionArgBox;

	private EventScriptId _conditionScriptId = EventScriptId.Invalid;

	public bool MovingNext;

	public bool IsPaused;

	public EventScriptRuntimeSettings Settings;

	public readonly EventScriptDebugger Debugger;

	private readonly Logger _logger = LogManager.GetCurrentClassLogger();

	public bool RecordingConditionHints;

	private List<OptionAvailableConditionInfo> _recordedConditionInfos;

	private Dictionary<IntPair, int[]> _randomUnrepeatedCache;

	private const int RandomUnrepeatedCacheMinThreshold = 10;

	private const int RandomUnrepeatedCacheMaxThreshold = 256;

	public Evaluator Evaluator { get; }

	public ScriptExecutionInstance Current
	{
		get
		{
			ScriptExecutionInstance instance;
			return _executionInstances.TryPeek(out instance) ? instance : null;
		}
	}

	public EventArgBox ArgBox => _conditionArgBox ?? Current?.ArgBox;

	public ICollection<int> ImplementedFunctionIds => _funcIdToNameMap.Keys;

	public EventScriptRuntime(DataContext context, bool enableDebugging = false)
	{
		Context = context;
		Evaluator = new Evaluator();
		if (enableDebugging)
		{
			Debugger = new EventScriptDebugger(this);
		}
		Evaluator.RegisterValueSelector(SelectValueFromEvent);
		Evaluator.RegisterValueSelector(SelectValueFromArgBox);
		Evaluator.RegisterValueSelector(new GlobalValueSelector());
		Evaluator.RegisterValueSelector(typeof(MapBlockData), new MapBlockDataValueSelector());
		Evaluator.RegisterObjectInitializer("ItemTemplate", new ItemTemplateInitializer());
		RegisterValueConvertersFromType<ValueConverters>();
		_decompilers = new Dictionary<ulong, IEventScriptDecompiler>();
		RegisterDecompilers();
		_interpreter = new Interpreter<EventScriptRuntime>();
		_funcIdToNameMap = new Dictionary<int, string>();
		_executionInstances = new Stack<ScriptExecutionInstance>();
		_globalScripts = new Dictionary<string, EventScript>();
		RegisterFunctionsFromType<EventConditions>();
		RegisterFunctionsFromType<BasicFunctions>();
		RegisterFunctionsFromType<CharacterFunctions>();
		RegisterFunctionsFromType<BuildingFunctions>();
		RegisterFunctionsFromType<CombatSkillFunctions>();
		RegisterFunctionsFromType<ItemFunctions>();
		RegisterFunctionsFromType<MapFunctions>();
		RegisterFunctionsFromType<InformationFunctions>();
		RegisterFunctionsFromType<MerchantFunctions>();
		RegisterFunctionsFromType<OrganizationFunctions>();
		RegisterFunctionsFromType<TaiwuFunctions>();
		RegisterFunctionsFromType<WorldFunctions>();
		RegisterFunctionsFromType<AdventureFunctions>();
		RegisterFunctionsFromType<InterfaceFunctions>();
		RegisterFunctionsFromType<SectMainStoryInternalFunctions>();
		RegisterFunctionsFromType<AdventureRemakeConditions>();
		RegisterFunctionsFromType<AdventureRemakeFunctions>();
		RegisterFunctionsFromType<MajorEventFunctions>();
		RegisterFunctionsFromType<MainStoryInternalFunctions>();
		RegisterFunctionsFromType<CricketPolymorphFunctions>();
	}

	public void ResetCache()
	{
		_randomUnrepeatedCache?.Clear();
	}

	public void LoadSettings(string path)
	{
		Settings = null;
		if (!File.Exists(path))
		{
			return;
		}
		try
		{
			string content = File.ReadAllText(path);
			CommonObjectSerializer.Deserialize<EventScriptRuntimeSettings>(content, out Settings, CommonObjectSerializer.MarshalFormat.Json);
			if (Settings.LogScriptTypes.Length != EventScriptType.Instance.Count)
			{
				Array.Resize(ref Settings.LogScriptTypes, EventScriptType.Instance.Count);
			}
		}
		catch (Exception value)
		{
			Settings = null;
			_logger.Warn($"Unable to load runtime settings.\n{value}");
		}
	}

	private void RegisterDecompilers()
	{
		EventScriptDecompiler_0_0_2_0 decompiler = new EventScriptDecompiler_0_0_2_0();
		_decompilers.Add(VersionUtils.VersionStringToUlong(decompiler.Version), decompiler);
	}

	private void RegisterValueConvertersFromType<T>()
	{
		Type type = typeof(T);
		Type attrType = typeof(ValueConverterAttribute);
		MethodInfo[] methods = type.GetMethods((BindingFlags)(-1));
		Type stackTopValueConverter = typeof(StackTopValueConverter.Conversion);
		Type objectValueConverter = typeof(ValueConverter.Conversion);
		MethodInfo[] array = methods;
		foreach (MethodInfo method in array)
		{
			object[] attributes = method.GetCustomAttributes(attrType, inherit: false);
			if (attributes.Length != 0)
			{
				ValueConverterAttribute attribute = (ValueConverterAttribute)attributes[0];
				ParameterInfo[] parameters = method.GetParameters();
				if (parameters.Length == 2 && parameters[0].ParameterType == typeof(Evaluator) && parameters[1].ParameterType == typeof(ValueInfo))
				{
					StackTopValueConverter.Conversion conversion = (StackTopValueConverter.Conversion)method.CreateDelegate(stackTopValueConverter);
					Evaluator.RegisterValueConversion(attribute.SrcType, attribute.DstType, conversion);
				}
				else if (parameters.Length == 1 && parameters[0].ParameterType == typeof(object))
				{
					ValueConverter.Conversion conversion2 = (ValueConverter.Conversion)method.CreateDelegate(objectValueConverter);
					Evaluator.RegisterValueConversion(attribute.SrcType, attribute.DstType, conversion2);
				}
			}
		}
	}

	public void RegisterFunctionsFromType<T>()
	{
		Type type = typeof(T);
		Type eventFuncAttr = typeof(EventFunctionAttribute);
		MethodInfo[] methods = type.GetMethods((BindingFlags)(-1));
		Type delegateType = typeof(StandardFunction<EventScriptRuntime>.Function);
		MethodInfo[] array = methods;
		foreach (MethodInfo method in array)
		{
			object[] attributes = method.GetCustomAttributes(eventFuncAttr, inherit: false);
			if (attributes.Length != 0)
			{
				EventFunctionAttribute attribute = (EventFunctionAttribute)attributes[0];
				_funcIdToNameMap.Add(attribute.Id, method.Name);
				ParameterInfo[] parameters = method.GetParameters();
				if (parameters.Length == 2 && parameters[0].ParameterType == typeof(EventScriptRuntime) && parameters[1].ParameterType == typeof(ASTNode[]))
				{
					StandardFunction<EventScriptRuntime>.Function standardFunc = (StandardFunction<EventScriptRuntime>.Function)method.CreateDelegate(delegateType);
					_interpreter.AddFunctionDefinition(method.Name, standardFunc);
				}
				else
				{
					_interpreter.AddFunctionDefinition(method.Name, method);
				}
			}
		}
	}

	public void Execute(string instStr)
	{
		ValueInfo retVal = _interpreter.Execute(this, instStr);
		Evaluator.RemoveTopValue(retVal);
	}

	public T Execute<T>(string instStr)
	{
		return _interpreter.Execute<T>(this, instStr);
	}

	public T Evaluate<T>(string expr)
	{
		return _interpreter.EvaluateExpression<T>(this, expr);
	}

	public EventInstruction CreateInst(int functionId, int indentAmount, string assignToVar, string args)
	{
		string funcName = _funcIdToNameMap[functionId];
		try
		{
			Instruction<EventScriptRuntime> inst = _interpreter.BuildInstruction(funcName, args);
			return new EventInstruction(functionId, indentAmount, assignToVar, inst);
		}
		catch (Exception innerException)
		{
			throw new Exception($"Failed to build instruction.\n\n {funcName}: {args}\n", innerException);
		}
	}

	public EventInstruction CreateInst(int functionId, int indentAmount, string assignToVar, string[] args)
	{
		string funcName = _funcIdToNameMap[functionId];
		try
		{
			Instruction<EventScriptRuntime> inst = _interpreter.BuildInstruction(funcName, args);
			return new EventInstruction(functionId, indentAmount, assignToVar, inst);
		}
		catch (Exception innerException)
		{
			throw new Exception($"Failed to build instruction.\n\n {funcName}: {string.Join(',', args)}\n", innerException);
		}
	}

	public EventInstruction TestCreateInst(int indentAmount, string assignToVar, string instructionStr)
	{
		try
		{
			Instruction<EventScriptRuntime> inst = _interpreter.BuildInstruction(instructionStr);
			return new EventInstruction(-1, indentAmount, assignToVar, inst);
		}
		catch (Exception innerException)
		{
			throw new Exception("Failed to build instruction " + instructionStr + ".", innerException);
		}
	}

	public EventCondition CreateCondition(int functionId, int indent, bool reverse, string args)
	{
		string funcName = _funcIdToNameMap[functionId];
		try
		{
			Instruction<EventScriptRuntime> inst = _interpreter.BuildInstruction(funcName, args);
			return new EventCondition(functionId, inst, reverse, indent);
		}
		catch (Exception innerException)
		{
			throw new Exception($"Failed to build instruction.\n\n {funcName}: {args}\n", innerException);
		}
	}

	public EventCondition CreateCondition(int functionId, int indent, bool reverse, string[] args)
	{
		string funcName = _funcIdToNameMap[functionId];
		try
		{
			Instruction<EventScriptRuntime> inst = _interpreter.BuildInstruction(funcName, args);
			return new EventCondition(functionId, inst, reverse, indent);
		}
		catch (Exception innerException)
		{
			throw new Exception($"Failed to build instruction.\n\n {funcName}: {string.Join(',', args)}\n", innerException);
		}
	}

	public void LoadGlobalScripts(string path)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		_globalScripts.Clear();
		if (!directoryInfo.Exists)
		{
			return;
		}
		FileInfo[] files = directoryInfo.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			using FileStream fileStream = File.OpenRead(fileInfo.FullName);
			using BinaryReader binaryReader = new BinaryReader(fileStream);
			ulong version = binaryReader.ReadUInt64();
			IEventScriptDecompiler decompiler = GetDecompiler(version);
			EventScriptId id = decompiler.DecompileScriptId(this, binaryReader);
			EventScript script = decompiler.DecompileEventScript(this, id, binaryReader);
			_globalScripts.Add(id.EventScriptRef.Guid.ToString(), script);
		}
	}

	public void LoadPackageScripts(EventPackage package, string packageScriptPath)
	{
		if (!File.Exists(packageScriptPath))
		{
			return;
		}
		using FileStream fileStream = File.OpenRead(packageScriptPath);
		using BinaryReader binaryReader = new BinaryReader(fileStream);
		ulong version = binaryReader.ReadUInt64();
		IEventScriptDecompiler decompiler = GetDecompiler(version);
		if (decompiler == null)
		{
			throw new Exception($"Loading package with Invalid decompiler version {VersionUtils.VersionUlongToString(version)} at {packageScriptPath}.");
		}
		Dictionary<EventScriptId, EventScriptBase> scripts = decompiler.DecompileEventScriptPackage(this, binaryReader);
		List<TaiwuEventItem> events = package.GetAllEvents();
		foreach (TaiwuEventItem eventItem in events)
		{
			Guid eventGuid = eventItem.Guid;
			eventItem.Script = (EventScript)scripts.GetValueOrDefault(new EventScriptId(1, eventGuid));
			eventItem.Conditions = (EventConditionList)scripts.GetValueOrDefault(new EventScriptId(2, eventGuid));
			TaiwuEventOption[] eventOptions = eventItem.EventOptions;
			foreach (TaiwuEventOption option in eventOptions)
			{
				try
				{
					Guid optionGuid = Guid.Parse(option.OptionGuid);
					EventScriptRef eventRef = new EventScriptRef(eventGuid, optionGuid);
					option.Script = (EventScript)scripts.GetValueOrDefault(new EventScriptId(3, eventRef));
					option.AvailableConditions = (EventConditionList)scripts.GetValueOrDefault(new EventScriptId(4, eventRef));
					option.VisibleConditions = (EventConditionList)scripts.GetValueOrDefault(new EventScriptId(5, eventRef));
				}
				catch (Exception innerException)
				{
					string message = $"Event guid:{eventItem.Guid.ToString()},Option guid:{option.OptionGuid} ";
					throw new Exception(message, innerException);
				}
			}
		}
	}

	private IEventScriptDecompiler GetDecompiler(ulong version)
	{
		return _decompilers.GetValueOrDefault(version);
	}

	public string ExecuteScript(EventScript script, EventArgBox argBox, bool obtainEnabled = true)
	{
		ScriptExecutionInstance instance = ObjectPool.Get();
		_executionInstances.Push(instance);
		instance.SetObtainPopupEnabled(obtainEnabled);
		instance.ExecuteScript(this, script, argBox);
		if (!instance.IsRunning && _executionInstances.TryPop(out var top) && top != instance)
		{
			_logger.Warn($"Trying to pop top instance {instance}, but {top} got popped instead.");
		}
		return instance.NextEvent;
	}

	public void ExecuteGlobalScript(string scriptGuid, EventArgBox argBox)
	{
		if (_globalScripts.TryGetValue(scriptGuid, out var script))
		{
			ExecuteScript(script, argBox);
		}
	}

	public bool CheckConditionList(EventConditionList conditionList, EventArgBox argBox)
	{
		if (conditionList == null || conditionList.Conditions == null)
		{
			return true;
		}
		_conditionArgBox = argBox;
		_conditionScriptId = conditionList.Id;
		bool logExecution = LogScriptExecution(conditionList.Id);
		if (logExecution)
		{
			Debugger.LogScriptInfo(conditionList.Id);
		}
		int index = 0;
		bool result = CheckAndCondition(conditionList, ref index, logExecution);
		if (logExecution)
		{
			Debugger.LogConditionListReturn(conditionList.Id, result);
		}
		_conditionArgBox = null;
		_conditionScriptId = EventScriptId.Invalid;
		return result;
	}

	private bool CheckCondition(EventConditionList conditionList, EventCondition condition, ref int currIndex, bool logExecution)
	{
		if (logExecution)
		{
			Debugger.LogInstructionWithArgs(currIndex, condition);
		}
		int initIndex = currIndex;
		bool ret;
		switch (condition.FunctionId)
		{
		case 109:
			currIndex++;
			ret = condition.Reverse != CheckAndCondition(conditionList, ref currIndex, logExecution);
			while (currIndex < conditionList.Conditions.Length && conditionList.Conditions[currIndex].Indent > condition.Indent)
			{
				currIndex++;
			}
			break;
		case 110:
			currIndex++;
			ret = condition.Reverse != CheckOrConditions(conditionList, ref currIndex, logExecution);
			while (currIndex < conditionList.Conditions.Length && conditionList.Conditions[currIndex].Indent > condition.Indent)
			{
				currIndex++;
			}
			break;
		case 5:
			throw new Exception("Cannot handle End here");
		default:
			ret = condition.Check(this);
			break;
		}
		if (logExecution)
		{
			Debugger.LogConditionCheck(initIndex, condition, ret);
		}
		return ret;
	}

	private bool CheckAndCondition(EventConditionList conditionList, ref int currIndex, bool logExecution)
	{
		bool ret = true;
		while (currIndex < conditionList.Conditions.Length)
		{
			EventCondition condition = conditionList.Conditions[currIndex];
			if (condition.FunctionId == 5)
			{
				return ret;
			}
			try
			{
				ret &= CheckCondition(conditionList, condition, ref currIndex, logExecution);
				if (!ret && !RecordingConditionHints)
				{
					while (currIndex < conditionList.Conditions.Length && conditionList.Conditions[currIndex].Indent >= condition.Indent)
					{
						currIndex++;
					}
					return false;
				}
			}
			catch (Exception innerException)
			{
				throw new TaiwuEventConditionException("Failed to check condition", conditionList.Id, currIndex, condition, innerException);
			}
			currIndex++;
		}
		return ret;
	}

	private bool CheckOrConditions(EventConditionList conditionList, ref int currIndex, bool logExecution)
	{
		bool ret = false;
		while (currIndex < conditionList.Conditions.Length)
		{
			EventCondition condition = conditionList.Conditions[currIndex];
			if (condition.FunctionId == 5)
			{
				return ret;
			}
			try
			{
				ret |= CheckCondition(conditionList, condition, ref currIndex, logExecution);
				if (ret && !RecordingConditionHints)
				{
					while (currIndex < conditionList.Conditions.Length && conditionList.Conditions[currIndex].Indent >= condition.Indent)
					{
						currIndex++;
					}
					return true;
				}
			}
			catch (Exception innerException)
			{
				throw new TaiwuEventConditionException("Failed to check condition", conditionList.Id, currIndex, condition, innerException);
			}
			currIndex++;
		}
		return ret;
	}

	public bool LogScriptExecution(EventScriptId scriptId)
	{
		if (Settings == null || Debugger == null)
		{
			return false;
		}
		if (Settings.LogMonitoredScriptsOnly && !Settings.MonitoredScripts.Contains(scriptId))
		{
			return false;
		}
		return Settings.LogScriptTypes[scriptId.Type];
	}

	public void Update()
	{
		ScriptExecutionInstance instance;
		while (_executionInstances.TryPeek(out instance))
		{
			instance.Update(this);
			if (instance.IsRunning)
			{
				break;
			}
			_executionInstances.Pop();
			ObjectPool.Return(instance);
		}
	}

	private ValueInfo SelectValueFromArgBox(Evaluator env, string identifier)
	{
		if (_conditionArgBox != null)
		{
			return _conditionArgBox.SelectValue(Evaluator, identifier);
		}
		if (Current?.ArgBox != null)
		{
			return Current.ArgBox.SelectValue(Evaluator, identifier);
		}
		if (DomainManager.TaiwuEvent.ShowingEvent != null)
		{
			return DomainManager.TaiwuEvent.ShowingEvent.ArgBox.SelectValue(Evaluator, identifier);
		}
		return ValueInfo.Void;
	}

	private ValueInfo SelectValueFromEvent(Evaluator env, string identifier)
	{
		if (_conditionScriptId.IsValid())
		{
			if (!EventScriptId.IsEventType(_conditionScriptId.Type))
			{
				return ValueInfo.Void;
			}
			TaiwuEvent taiwuEvent = DomainManager.TaiwuEvent.GetEvent(_conditionScriptId.EventScriptRef.Guid.ToString());
			return taiwuEvent.SelectValue(Evaluator, identifier);
		}
		ScriptExecutionInstance instance = Current;
		if (instance != null && !string.IsNullOrEmpty(instance.EventGuid))
		{
			return DomainManager.TaiwuEvent.GetEvent(instance.EventGuid).SelectValue(Evaluator, identifier);
		}
		if (DomainManager.TaiwuEvent.ShowingEvent != null)
		{
			return DomainManager.TaiwuEvent.ShowingEvent.SelectValue(Evaluator, identifier);
		}
		return ValueInfo.Void;
	}

	public void Log(string message)
	{
		_logger.Info(message);
	}

	public void OnExecuteInstruction(Instruction<EventScriptRuntime> instruction, ASTNode[] parameters)
	{
		ExecutingInstruction = instruction;
	}

	public void OnInstructionEvaluated(ValueInfo ret)
	{
	}

	public Instruction<EventScriptRuntime> GetExecutingInstruction()
	{
		return ExecutingInstruction;
	}

	public void StartRecordConditionHints()
	{
		RecordingConditionHints = true;
		if (_recordedConditionInfos == null)
		{
			_recordedConditionInfos = new List<OptionAvailableConditionInfo>();
		}
		_recordedConditionInfos.Clear();
	}

	public List<OptionAvailableConditionInfo> StopRecordConditionHints()
	{
		RecordingConditionHints = false;
		List<OptionAvailableConditionInfo> recordedConditionInfos = _recordedConditionInfos;
		if (recordedConditionInfos == null || recordedConditionInfos.Count <= 0)
		{
			return null;
		}
		List<OptionAvailableConditionInfo> recordedConditionInfos2 = _recordedConditionInfos;
		_recordedConditionInfos = null;
		return recordedConditionInfos2;
	}

	public void RecordConditionHint(int funcId, bool result, params string[] args)
	{
		OptionAvailableConditionInfo conditionInfo = new OptionAvailableConditionInfo(funcId, result, args);
		_recordedConditionInfos.Add(conditionInfo);
	}

	public int GetRandomUnrepeated(int seed, int count, int currIndex)
	{
		if (count < 10)
		{
			Xoshiro256PlusRandom random = new Xoshiro256PlusRandom((ulong)seed);
			Span<int> span = stackalloc int[count];
			RandomUtils.GetRandomUnrepeated(random, 0, count - 1, span);
			return span[currIndex];
		}
		if (_randomUnrepeatedCache == null || !_randomUnrepeatedCache.TryGetValue(new IntPair(seed, count), out var arr))
		{
			arr = InitCache(seed, count);
		}
		return arr[currIndex];
	}

	private int[] InitCache(int seed, int count)
	{
		if (_randomUnrepeatedCache == null)
		{
			_randomUnrepeatedCache = new Dictionary<IntPair, int[]>();
		}
		Xoshiro256PlusRandom random = new Xoshiro256PlusRandom((ulong)seed);
		if ((count <= 10 || count > 256) ? true : false)
		{
			throw new ArgumentOutOfRangeException("count", count, "Supported range [1, 256].");
		}
		IEnumerable<ulong> result = RandomUtils.GetRandomUnrepeated(random, (ulong)count);
		int[] arr = new int[count];
		int index = 0;
		foreach (ulong num in result)
		{
			arr[index] = (int)num;
			index++;
		}
		_randomUnrepeatedCache[new IntPair(seed, count)] = arr;
		return arr;
	}
}
