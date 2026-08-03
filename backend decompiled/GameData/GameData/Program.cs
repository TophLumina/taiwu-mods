using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using GameData.Achievement;
using GameData.ArchiveData;
using GameData.Common;
using GameData.Common.WorkerThread;
using GameData.Domains;
using GameData.Domains.Map;
using GameData.Domains.Mod;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Steamworks;
using GameData.Utilities;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace GameData;

internal static class Program
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public static string BaseDataDir { get; private set; }

	public static bool IsTestBranch { get; private set; }

	public static bool AdvanceMonthSingleThread { get; private set; }

	internal static void Main(string[] args)
	{
		try
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.Name = "Main";
			DataContextManager.RegisterMainThread();
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			InitializeCommandLineArgs(args);
			BaseDataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..");
			AppDomain.CurrentDomain.AssemblyResolve += ModDomain.ResolveTaiwuModdingLibPath;
			string loggingDir = Path.Combine(BaseDataDir, "Logs");
			InitializeLogging(loggingDir);
			Logger adaptableLogger = LogManager.GetLogger("AdaptableLog");
			AdaptableLog.Initialize(adaptableLogger.Info, adaptableLogger.Warn, adaptableLogger.Error);
			ExternalDataBridge.Initialize(new GameContext());
			DatabaseBridge.RegisterAllTables(Assembly.GetExecutingAssembly());
			GameData.ArchiveData.Common.Initialize(BaseDataDir, IsTestBranch);
			DataUpgradeManager.Initialize();
			ObjectPoolManager.Initialize();
			CoordinateGenericInitializer.Initialize();
			GameData.Serializer.Serializer.Initialize();
			WorkerThreadManager.Initialize();
			GameData.GameDataBridge.GameDataBridge.Initialize();
			SteamManager.Initialize();
			Logger.Info("GameData module initialized.");
			DomainManager.Global.OnInitializeGameDataModule();
			LogHandle.OnAppendMessage += GameData.GameDataBridge.GameDataBridge.AppendWarningMessage;
			AchievementManager.Initialize();
			GameData.GameDataBridge.GameDataBridge.RunMainLoop();
		}
		catch (Exception value)
		{
			Logger.Error(value);
			Location location = DomainManager.Map.LastGetBlockDataPosition_Debug;
			AdaptableLog.Info($"try get block data from frontend: [{location.AreaId}, {location.BlockId}]");
		}
		finally
		{
			Logger.Info("GameData module is about to exit.");
			GameData.GameDataBridge.GameDataBridge.UnInitialize();
			DatabaseBridge.Disconnect(deleteWorkingDb: true);
			SteamManager.UnInitialize();
			LogManager.Shutdown();
		}
	}

	private static void InitializeCommandLineArgs(string[] args)
	{
		foreach (string arg in args)
		{
			string text = arg;
			string text2 = text;
			if (!(text2 == "--test-branch"))
			{
				if (text2 == "--advance-month-single-thread")
				{
					AdvanceMonthSingleThread = true;
				}
			}
			else
			{
				IsTestBranch = true;
			}
		}
	}

	private static void InitializeLogging(string loggingDir)
	{
		ConfigurationItemFactory.Default = new ConfigurationItemFactory(typeof(ILogger).GetTypeInfo().Assembly);
		LoggingConfiguration config = new LoggingConfiguration();
		StringBuilder sbLayout = new StringBuilder("${longdate}");
		sbLayout.Append("|${level:uppercase=true}");
		sbLayout.Append("|${threadname}");
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
			ArchiveFileName = loggingDir + "/GameData_{#}.log",
			ArchiveNumbering = ArchiveNumberingMode.Date,
			ArchiveDateFormat = "yyyy-MM-dd_HH_mm_ss",
			ArchiveEvery = FileArchivePeriod.Year,
			MaxArchiveFiles = 9,
			FileName = loggingDir + "/GameData_${cached:${date:format=yyyy-MM-dd_HH_mm_ss}}.log",
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
		LogManager.Configuration = config;
	}
}
