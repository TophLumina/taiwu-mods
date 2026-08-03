using System.IO;
using System.Text;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using GameData.GameDataBridge;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace GameData.Domains.TaiwuEvent;

public class EventScriptDebugger
{
	private StringBuilder _logStringBuilder = new StringBuilder();

	private readonly EventScriptRuntime _runtime;

	private Logger _logger;

	public EventScriptDebugger(EventScriptRuntime runtime)
	{
		_runtime = runtime;
		string outputPath = Path.Combine(Program.BaseDataDir, "Logs", "EventScripts");
		InitLogger(outputPath);
	}

	private void InitLogger(string outputPath)
	{
		LogFactory factory = new LogFactory();
		LoggingConfiguration config = new LoggingConfiguration(factory);
		StringBuilder sbLayout = new StringBuilder();
		sbLayout.Append("${date}");
		sbLayout.Append("|${logger}");
		sbLayout.Append("|${message}");
		string layout = sbLayout.ToString();
		ColoredConsoleTarget logConsole = new ColoredConsoleTarget("console")
		{
			Layout = layout,
			Encoding = Encoding.UTF8,
			DetectConsoleAvailable = true
		};
		config.AddRule(LogLevel.Debug, LogLevel.Fatal, logConsole);
		ErrorMessagesTarget logErrorMessages = new ErrorMessagesTarget("errorMessages")
		{
			Layout = layout
		};
		config.AddRule(LogLevel.Error, LogLevel.Fatal, logErrorMessages);
		FileTarget logFile = new FileTarget("file")
		{
			Layout = layout,
			Encoding = Encoding.UTF8,
			ArchiveFileName = outputPath + "/EventScript_{#}.log",
			ArchiveNumbering = ArchiveNumberingMode.Date,
			ArchiveDateFormat = "yyyy-MM-dd_HH_mm_ss",
			ArchiveEvery = FileArchivePeriod.Year,
			MaxArchiveFiles = 9,
			FileName = outputPath + "/EventScript_${cached:${date:format=yyyy-MM-dd_HH_mm_ss}}.log",
			KeepFileOpen = true,
			OpenFileCacheTimeout = 30,
			ConcurrentWrites = false,
			CleanupFileName = false,
			AutoFlush = true
		};
		AsyncTargetWrapper logFileWrapper = new AsyncTargetWrapper
		{
			WrappedTarget = logFile,
			OverflowAction = AsyncTargetWrapperOverflowAction.Discard
		};
		config.AddRule(LogLevel.Debug, LogLevel.Fatal, logFileWrapper);
		factory.Configuration = config;
		_logger = factory.GetLogger("EventScriptDebugger");
	}

	public void LogError(string message)
	{
		_logger.Warn(message);
	}

	public void LogMessage(string message)
	{
		_logger.Info(message);
	}

	public void LogScriptInfo(EventScriptId scriptId)
	{
		_logStringBuilder.Clear();
		_logStringBuilder.AppendFormat("[{0}]", scriptId.ToString());
		_logger.Info(_logStringBuilder);
	}

	public void LogConditionListReturn(EventScriptId scriptId, bool value)
	{
		_logStringBuilder.Clear();
		_logStringBuilder.AppendFormat("[Return {0}] {1}", scriptId.ToString(), value.ToString());
		_logger.Info(_logStringBuilder);
	}

	public void LogInstruction(int index, int funcId)
	{
		_logStringBuilder.Clear();
		_logStringBuilder.AppendFormat("[Line ({0})]", index.ToString());
		BuildFunctionNameText(_logStringBuilder, funcId);
		_logger.Info(_logStringBuilder);
	}

	public void LogArguments(int index, ASTNode[] args)
	{
		_logStringBuilder.Clear();
		BuildArgumentOutputText(_logStringBuilder, args);
		_logger.Info(_logStringBuilder);
	}

	public void LogInstructionWithArgs(int index, EventInstructionBase instruction)
	{
		_logStringBuilder.Clear();
		_logStringBuilder.AppendFormat("[Line ({0})]", index.ToString());
		BuildFunctionNameText(_logStringBuilder, instruction.FunctionId);
		_logStringBuilder.Append(':');
		_logStringBuilder.Append(' ');
		BuildArgumentOutputText(_logStringBuilder, instruction.Instruction.Parameters);
		_logger.Info(_logStringBuilder);
	}

	public void LogConditionCheck(int index, EventInstructionBase instruction, bool value)
	{
		_logStringBuilder.Clear();
		_logStringBuilder.AppendFormat("[Return ({0})] {1}", index.ToString(), value.ToString());
		_logger.Info(_logStringBuilder);
	}

	public void LogInstructionReturn(string assignToVar, ValueInfo valueInfo)
	{
		_logStringBuilder.Clear();
		_logStringBuilder.AppendFormat("[Return]");
		BuildReturnValueText(_logStringBuilder, assignToVar, valueInfo);
		_logger.Info(_logStringBuilder);
	}

	private void BuildFunctionNameText(StringBuilder builder, int funcId)
	{
		string funcName = EventFunction.Instance[funcId].Name;
		builder.Append(funcName);
	}

	private void BuildArgumentOutputText(StringBuilder builder, ASTNode[] args)
	{
		if (args == null)
		{
			return;
		}
		for (int i = 0; i < args.Length; i++)
		{
			string value = args[i].GetAnyValueAsString(_runtime.Evaluator);
			builder.Append(value);
			if (i + 1 < args.Length)
			{
				builder.Append(',');
				builder.Append(' ');
			}
		}
	}

	private void BuildReturnValueText(StringBuilder builder, string assignToVar, ValueInfo valueInfo)
	{
		string value = _runtime.Evaluator.GetValueAsString(valueInfo);
		builder.Append(assignToVar);
		builder.Append(" = ");
		builder.Append(value);
	}
}
