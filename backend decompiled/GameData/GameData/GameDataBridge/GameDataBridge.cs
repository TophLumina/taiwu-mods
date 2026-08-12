using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Config.Common;
using GameData.Common;
using GameData.DLC;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains;
using GameData.Domains.Global;
using GameData.Domains.Mod;
using GameData.GameDataBridge.VnPipe;
using GameData.Serializer;
using GameData.Steamworks;
using GameData.Utilities;
using GameData.Utilities.Coroutine;
using NLog;

namespace GameData.GameDataBridge;

public static class GameDataBridge
{
	public const int TimerResolution = 1;

	public const int FramesPerSecond = 60;

	public const int FrameRateDropWarningThreshold = 40;

	public static int ActualFramesPerSecond = 60;

	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	private static volatile bool _shouldDisconnect;

	private static volatile sbyte _gameDataModuleInitializationState;

	private static readonly DataMonitorManager DataMonitorManager = new DataMonitorManager();

	private static readonly CoroutineManager CoroutineManager = new CoroutineManager();

	private static readonly Dictionary<uint, Operation> PassthroughOperations = new Dictionary<uint, Operation>();

	private static uint _nextOperationId;

	private static readonly Stopwatch Stopwatch = new Stopwatch();

	private static long _frameBeginTicks;

	private static long _averageSleepInterval = Stopwatch.Frequency / 1000;

	private static readonly long ExpectedTicksPerFrame = Stopwatch.Frequency / 60;

	private const int NotificationDataPoolDefaultCapacity = 65536;

	private const int InterProcessMessageBufferDefaultSize = 65536;

	private const int WritingThreadSleepInterval = 16;

	private const int ThreadJoinTimeout = 1000;

	private static Slaver _slaverPipe;

	private static Thread _readingThread;

	private static Thread _writingThread;

	private static readonly IncreasableBuffer IncomingMessageBuffer = new IncreasableBuffer(65536);

	private static readonly IncreasableBuffer OutgoingMessageBuffer = new IncreasableBuffer(65536);

	private static List<OperationCollection> _operationCollections = new List<OperationCollection>();

	private static readonly object OperationCollectionsLock = new object();

	private static List<OperationCollection> _processingOperationCollections = new List<OperationCollection>();

	private static List<NotificationCollection> _notificationCollections = new List<NotificationCollection>();

	private static readonly object NotificationCollectionsLock = new object();

	private static NotificationCollection _pendingNotifications = new NotificationCollection(65536);

	private static List<NotificationCollection> _writingNotificationCollections = new List<NotificationCollection>();

	private static readonly List<IConfigData> CachedConfigs = new List<IConfigData>();

	private static DlcInfoList _dlcInfos = DlcInfoList.Create();

	private static ModInfoList _modInfos = ModInfoList.Create();

	private static readonly List<string> ErrorMessages = new List<string>();

	private static readonly List<string> WarningMessages = new List<string>();

	public static void RunMainLoop()
	{
		DataContext context = DataContextManager.GetCurrentThreadDataContext();
		_shouldDisconnect = false;
		Stopwatch.Start();
		Logger.Info("Machine Frequency (Ticks/Second): " + Stopwatch.Frequency);
		_frameBeginTicks = Stopwatch.ElapsedTicks;
		timeBeginPeriod(1u);
		while (!_shouldDisconnect)
		{
			if (!CheckErrorMessages())
			{
				return;
			}
			if (DomainManager.Global.GlobalDataLoaded)
			{
				break;
			}
			AdvanceFrame();
		}
		while (!_shouldDisconnect && CheckErrorMessages())
		{
			if (_gameDataModuleInitializationState == 1)
			{
				InitializeGameDataModule();
			}
			SteamManager.Update();
			if (IsGameDataModuleInitialized())
			{
				CoroutineManager.OnUpdate();
				ProcessOperations(context);
				for (int i = 0; i < DomainManager.Domains.Length; i++)
				{
					DomainManager.Domains[i].OnUpdate(context);
				}
				context.ParallelModificationsRecorder.ApplyAll(context);
				DataMonitorManager.CheckMonitoredData();
				TransferPendingNotifications();
				Events.RaiseBeforeSendRequestToArchiveModule(context);
			}
			AdvanceFrame();
		}
		timeEndPeriod(1u);
	}

	public static void StartNextFrame(Action action)
	{
		CoroutineManager.Start(CoroutineUtils.CallAfterFrames(action, 1));
	}

	public static uint GetNextOperationId()
	{
		uint operationId = _nextOperationId;
		_nextOperationId++;
		return operationId;
	}

	private static void AdvanceFrame()
	{
		long currElapsedTicks = Stopwatch.ElapsedTicks - _frameBeginTicks;
		long expectedSleepTicks = ExpectedTicksPerFrame - currElapsedTicks;
		if (_averageSleepInterval == 0)
		{
			_averageSleepInterval = Stopwatch.Frequency / 1000;
		}
		long expectedSleepCount = expectedSleepTicks / _averageSleepInterval * 8 / 10;
		if (expectedSleepCount == 0)
		{
			expectedSleepCount++;
		}
		long sleepBeginTicks = Stopwatch.ElapsedTicks;
		int sleepCount;
		for (sleepCount = 0; sleepCount < expectedSleepCount; sleepCount++)
		{
			if (currElapsedTicks >= ExpectedTicksPerFrame)
			{
				break;
			}
			Thread.Sleep(1);
			currElapsedTicks = Stopwatch.ElapsedTicks - _frameBeginTicks;
		}
		if (sleepCount > 0)
		{
			_averageSleepInterval = (Stopwatch.ElapsedTicks - sleepBeginTicks) / sleepCount;
		}
		for (currElapsedTicks = Stopwatch.ElapsedTicks - _frameBeginTicks; currElapsedTicks < ExpectedTicksPerFrame; currElapsedTicks = Stopwatch.ElapsedTicks - _frameBeginTicks)
		{
			Thread.Sleep(0);
		}
		ActualFramesPerSecond = (int)(Stopwatch.Frequency / currElapsedTicks + 1);
		_frameBeginTicks = Stopwatch.ElapsedTicks;
	}

	private static void InitializeGameDataModule()
	{
		lock (CachedConfigs)
		{
			DomainManager.Mod.LoadAllMods(_modInfos);
			_modInfos.Items.Clear();
		}
		DataDependenciesInfo.Generate();
		BaseGameDataDomain[] domains = DomainManager.Domains;
		foreach (BaseGameDataDomain domain in domains)
		{
			domain.OnInitializeGameDataModule();
		}
		SetGameDataModuleInitializationState(2);
	}

	private static void ProcessOperations(DataContext context)
	{
		lock (OperationCollectionsLock)
		{
			if (_operationCollections.Count <= 0)
			{
				return;
			}
			List<OperationCollection> operationCollections = _operationCollections;
			List<OperationCollection> processingOperationCollections = _processingOperationCollections;
			_processingOperationCollections = operationCollections;
			_operationCollections = processingOperationCollections;
			_operationCollections.Clear();
		}
		int collectionsCount = _processingOperationCollections.Count;
		for (int i = 0; i < collectionsCount; i++)
		{
			OperationCollection collection = _processingOperationCollections[i];
			RawDataPool dataPool = collection.DataPool;
			int operationsCount = collection.Operations.Count;
			for (int j = 0; j < operationsCount; j++)
			{
				Operation operation = collection.Operations[j];
				switch (operation.Type)
				{
				case 0:
					ProcessDataMonitor(operation);
					break;
				case 1:
					ProcessDataUnMonitor(operation);
					break;
				case 2:
					ProcessDataModification(operation, dataPool, context);
					break;
				case 3:
					ProcessMethodCall(operation, dataPool, context);
					break;
				default:
					throw new Exception($"Unsupported operation type: {operation.Type}");
				}
			}
		}
		_processingOperationCollections.Clear();
	}

	private static void ProcessDataMonitor(Operation operation)
	{
		DataUid uid = new DataUid(operation.DomainId, operation.DataId, operation.SubId0, operation.SubId1);
		DataMonitorManager.MonitorData(uid);
	}

	private static void ProcessDataUnMonitor(Operation operation)
	{
		DataUid uid = new DataUid(operation.DomainId, operation.DataId, operation.SubId0, operation.SubId1);
		DataMonitorManager.UnMonitorData(uid);
	}

	private static void ProcessDataModification(Operation operation, RawDataPool dataPool, DataContext context)
	{
		BaseGameDataDomain domain = DomainManager.Domains[operation.DomainId];
		domain.SetData(operation.DataId, operation.SubId0, operation.SubId1, operation.ValueOffset, dataPool, context);
	}

	private static void ProcessMethodCall(Operation operation, RawDataPool argDataPool, DataContext context)
	{
		BaseGameDataDomain domain = DomainManager.Domains[operation.DomainId];
		int returnOffset = domain.CallMethod(operation, argDataPool, _pendingNotifications.DataPool, context);
		if (returnOffset >= 0)
		{
			_pendingNotifications.Notifications.Add(Notification.CreateMethodReturn(operation.ListenerId, operation.DomainId, operation.MethodId, returnOffset));
		}
	}

	public static NotificationCollection GetPendingNotifications()
	{
		return _pendingNotifications;
	}

	public static void TransferPendingNotifications()
	{
		if (_pendingNotifications.Notifications.Count <= 0)
		{
			return;
		}
		lock (NotificationCollectionsLock)
		{
			_notificationCollections.Add(_pendingNotifications);
			_pendingNotifications = new NotificationCollection(65536);
		}
	}

	public static (DataMonitorManager, NotificationCollection) StartSemiBlockingTask()
	{
		DataMonitorManager monitor = new DataMonitorManager();
		NotificationCollection oriPendingNotifications = _pendingNotifications;
		_pendingNotifications = new NotificationCollection(65536);
		return (monitor, oriPendingNotifications);
	}

	public static void StopSemiBlockingTask(DataMonitorManager monitor, NotificationCollection oriPendingNotifications)
	{
		monitor.CheckMonitoredData();
		monitor.Clear();
		TransferPendingNotifications();
		_pendingNotifications = oriPendingNotifications;
	}

	public static void AppendErrorMessage(string message)
	{
		lock (ErrorMessages)
		{
			ErrorMessages.Add(DomainManager.Global.GetGameVersion() + " " + message);
		}
	}

	public static void AppendWarningMessage(string message)
	{
		lock (WarningMessages)
		{
			WarningMessages.Add(message);
		}
	}

	public static void ClearMonitoredData()
	{
		DataMonitorManager.Clear();
	}

	private static bool CheckErrorMessages()
	{
		lock (ErrorMessages)
		{
			return ErrorMessages.Count <= 0;
		}
	}

	private static bool CheckWarningMessages()
	{
		lock (WarningMessages)
		{
			return WarningMessages.Count <= 0;
		}
	}

	public static uint RecordPassthroughMethod(Operation displayOperation)
	{
		uint archiveOperationId = GetNextOperationId();
		PassthroughOperations.Add(archiveOperationId, displayOperation);
		return archiveOperationId;
	}

	public static void TryReturnPassthroughMethod<T>(uint archiveOperationId, T returnValue)
	{
		if (PassthroughOperations.TryGetValue(archiveOperationId, out var displayOperation))
		{
			int returnOffset = SerializerHolder<T>.Serialize(returnValue, _pendingNotifications.DataPool);
			_pendingNotifications.Notifications.Add(Notification.CreateMethodReturn(displayOperation.ListenerId, displayOperation.DomainId, displayOperation.MethodId, returnOffset));
			PassthroughOperations.Remove(archiveOperationId);
		}
	}

	private static void SetGameDataModuleInitializationState(sbyte state)
	{
		if (!GameDataModuleInitializationState.CheckTransition(_gameDataModuleInitializationState, state))
		{
			throw new Exception($"Invalid transition: {_gameDataModuleInitializationState} -> {state}");
		}
		Logger.Info($"Transition: {_gameDataModuleInitializationState} -> {state}");
		_gameDataModuleInitializationState = state;
	}

	public static bool IsGameDataModuleInitialized()
	{
		sbyte gameDataModuleInitializationState = _gameDataModuleInitializationState;
		if ((uint)(gameDataModuleInitializationState - 2) <= 1u)
		{
			return true;
		}
		return false;
	}

	public static void AddPostDataModificationHandler(DataUid uid, string handlerKey, DataModificationHandler handler)
	{
		DataMonitorManager.AddPostModificationHandler(uid, handlerKey, handler);
	}

	public static void RemovePostDataModificationHandler(DataUid uid, string handlerKey)
	{
		DataMonitorManager.RemovePostModificationHandler(uid, handlerKey);
	}

	[DllImport("winmm.dll")]
	internal static extern uint timeBeginPeriod(uint period);

	[DllImport("winmm.dll")]
	internal static extern uint timeEndPeriod(uint period);

	public static void AddDisplayEvent(DisplayEventType type)
	{
		_pendingNotifications.Notifications.Add(Notification.CreateDisplayEvent(type, -1));
	}

	public static void AddDisplayEvent<T1>(DisplayEventType type, T1 arg1)
	{
		RawDataPool dataPool = _pendingNotifications.DataPool;
		int offset = SerializerHolder<T1>.Serialize(arg1, dataPool);
		_pendingNotifications.Notifications.Add(Notification.CreateDisplayEvent(type, offset));
	}

	public static void AddDisplayEvent<T1, T2>(DisplayEventType type, T1 arg1, T2 arg2)
	{
		RawDataPool dataPool = _pendingNotifications.DataPool;
		int offset = SerializerHolder<T1>.Serialize(arg1, dataPool);
		SerializerHolder<T2>.Serialize(arg2, dataPool);
		_pendingNotifications.Notifications.Add(Notification.CreateDisplayEvent(type, offset));
	}

	public static void AddDisplayEvent<T1, T2, T3>(DisplayEventType type, T1 arg1, T2 arg2, T3 arg3)
	{
		RawDataPool dataPool = _pendingNotifications.DataPool;
		int offset = SerializerHolder<T1>.Serialize(arg1, dataPool);
		SerializerHolder<T2>.Serialize(arg2, dataPool);
		SerializerHolder<T3>.Serialize(arg3, dataPool);
		_pendingNotifications.Notifications.Add(Notification.CreateDisplayEvent(type, offset));
	}

	public static void AddDisplayEvent<T1, T2, T3, T4>(DisplayEventType type, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
	{
		RawDataPool dataPool = _pendingNotifications.DataPool;
		int offset = SerializerHolder<T1>.Serialize(arg1, dataPool);
		SerializerHolder<T2>.Serialize(arg2, dataPool);
		SerializerHolder<T3>.Serialize(arg3, dataPool);
		SerializerHolder<T4>.Serialize(arg4, dataPool);
		_pendingNotifications.Notifications.Add(Notification.CreateDisplayEvent(type, offset));
	}

	public static void AddDisplayEvent<T1, T2, T3, T4, T5>(DisplayEventType type, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
	{
		RawDataPool dataPool = _pendingNotifications.DataPool;
		int offset = SerializerHolder<T1>.Serialize(arg1, dataPool);
		SerializerHolder<T2>.Serialize(arg2, dataPool);
		SerializerHolder<T3>.Serialize(arg3, dataPool);
		SerializerHolder<T4>.Serialize(arg4, dataPool);
		SerializerHolder<T5>.Serialize(arg5, dataPool);
		_pendingNotifications.Notifications.Add(Notification.CreateDisplayEvent(type, offset));
	}

	public static void AddDisplayEvent<T1, T2, T3, T4, T5, T6>(DisplayEventType type, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
	{
		RawDataPool dataPool = _pendingNotifications.DataPool;
		int offset = SerializerHolder<T1>.Serialize(arg1, dataPool);
		SerializerHolder<T2>.Serialize(arg2, dataPool);
		SerializerHolder<T3>.Serialize(arg3, dataPool);
		SerializerHolder<T4>.Serialize(arg4, dataPool);
		SerializerHolder<T5>.Serialize(arg5, dataPool);
		SerializerHolder<T6>.Serialize(arg6, dataPool);
		_pendingNotifications.Notifications.Add(Notification.CreateDisplayEvent(type, offset));
	}

	public static void AddDisplayEvent<T1, T2, T3, T4, T5, T6, T7>(DisplayEventType type, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
	{
		RawDataPool dataPool = _pendingNotifications.DataPool;
		int offset = SerializerHolder<T1>.Serialize(arg1, dataPool);
		SerializerHolder<T2>.Serialize(arg2, dataPool);
		SerializerHolder<T3>.Serialize(arg3, dataPool);
		SerializerHolder<T4>.Serialize(arg4, dataPool);
		SerializerHolder<T5>.Serialize(arg5, dataPool);
		SerializerHolder<T6>.Serialize(arg6, dataPool);
		SerializerHolder<T7>.Serialize(arg7, dataPool);
		_pendingNotifications.Notifications.Add(Notification.CreateDisplayEvent(type, offset));
	}

	public static void AddDisplayEvent<T1, T2, T3, T4, T5, T6, T7, T8>(DisplayEventType type, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
	{
		RawDataPool dataPool = _pendingNotifications.DataPool;
		int offset = SerializerHolder<T1>.Serialize(arg1, dataPool);
		SerializerHolder<T2>.Serialize(arg2, dataPool);
		SerializerHolder<T3>.Serialize(arg3, dataPool);
		SerializerHolder<T4>.Serialize(arg4, dataPool);
		SerializerHolder<T5>.Serialize(arg5, dataPool);
		SerializerHolder<T6>.Serialize(arg6, dataPool);
		SerializerHolder<T7>.Serialize(arg7, dataPool);
		SerializerHolder<T8>.Serialize(arg8, dataPool);
		_pendingNotifications.Notifications.Add(Notification.CreateDisplayEvent(type, offset));
	}

	public static void Initialize()
	{
		_gameDataModuleInitializationState = 0;
		_slaverPipe = Slaver.Connect("taiwu");
		if (_slaverPipe == null)
		{
			throw new Exception("pipe connect failed");
		}
		_readingThread = new Thread(ReadInterProcessMessages)
		{
			IsBackground = false,
			Name = "ReadInterProcessMessages"
		};
		_readingThread.Start();
		_writingThread = new Thread(WriteInterProcessMessages)
		{
			IsBackground = false,
			Name = "WriteInterProcessMessages"
		};
		_writingThread.Start();
	}

	public static void UnInitialize()
	{
		_shouldDisconnect = true;
		if (_readingThread != null)
		{
			if (_readingThread.ThreadState != ThreadState.Unstarted && !_readingThread.Join(1000))
			{
				Logger.Warn("Failed to wait for _readingThread to terminate.");
			}
			_readingThread = null;
		}
		if (_writingThread != null)
		{
			if (_writingThread.ThreadState != ThreadState.Unstarted && !_writingThread.Join(1000))
			{
				Logger.Warn("Failed to wait for _writingThread to terminate.");
			}
			_writingThread = null;
		}
		if (_slaverPipe != null)
		{
			_slaverPipe.Dispose();
			_slaverPipe = null;
		}
	}

	private static void ReadInterProcessMessages()
	{
		Logger.Info("ReadInterProcessMessages thread started.");
		try
		{
			bool shouldExit = false;
			while (!shouldExit)
			{
				shouldExit = ReadInterProcessMessage();
			}
		}
		catch (Exception value)
		{
			Logger.Error(value);
		}
		Logger.Info("ReadInterProcessMessages thread is about to exit.");
		LogManager.Flush();
		_shouldDisconnect = true;
	}

	private static bool ReadInterProcessMessage()
	{
		GetUnmanagedValuesFromSocket<byte, int>(out var messageType, out var contentLength);
		return messageType switch
		{
			0 => ReadInterProcessMessageInitialize(contentLength), 
			1 => ReadInterProcessMessageOperations(contentLength), 
			2 => ReadInterProcessMessageDisconnect(contentLength), 
			_ => throw new Exception("Unknown message type: " + messageType), 
		};
	}

	private unsafe static bool ReadInterProcessMessageInitialize(int contentLength)
	{
		Logger.Info("Incoming message: Initialize");
		RawDataPool dataPool = new RawDataPool((IPipe)_slaverPipe, contentLength);
		int offset = 0;
		SharedGlobalSettings sharedSettings = new SharedGlobalSettings();
		string gameVersion;
		string gameBuildDate;
		lock (CachedConfigs)
		{
			int gameVersionSize = SerializationHelper.Deserialize(dataPool.GetPointer(offset), out gameVersion);
			offset += gameVersionSize;
			int gameBuildDateSize = SerializationHelper.Deserialize(dataPool.GetPointer(offset), out gameBuildDate);
			offset += gameBuildDateSize;
			offset += RestoreObject<SharedGlobalSettings>(sharedSettings, offset, "SharedGlobalSettings");
			offset += RestoreObject<DlcInfoList>(_dlcInfos, offset, "DlcInfoList");
			offset += RestoreObject<ModInfoList>(_modInfos, offset, "ModInfoList");
		}
		if (contentLength != offset)
		{
			throw new Exception($"Content length: expected {contentLength}, actual {offset}");
		}
		GlobalDomain.Settings = sharedSettings;
		DomainManager.Global.SetGameBuildInfo(gameVersion, gameBuildDate);
		DomainManager.Global.ReloadAllConfigData();
		DomainManager.Global.LoadGlobal();
		DlcManager.SetDldInfoList(_dlcInfos.Items);
		SetGameDataModuleInitializationState(1);
		return false;
		unsafe int RestoreObject<T>(T dataObject, int dataOffset, string name) where T : ISerializableGameData
		{
			int startOffset = dataOffset;
			int objectSize = (int)dataPool.GetUnmanaged<uint>(dataOffset);
			dataOffset += 4;
			int readSize = dataObject.Deserialize(dataPool.GetPointer(dataOffset));
			if (objectSize != readSize)
			{
				throw new Exception($"Serialized size of {name}: expected {objectSize}, actual {readSize}");
			}
			dataOffset += readSize;
			return dataOffset - startOffset;
		}
	}

	private unsafe static bool ReadInterProcessMessageOperations(int contentLength)
	{
		GetUnmanagedValuesFromSocket<uint>(out var operationsCount);
		int operationsContentLength = sizeof(Operation) * (int)operationsCount;
		byte[] buffer = GetRawDataFromSocket(operationsContentLength);
		List<Operation> operations = new List<Operation>();
		fixed (byte* pBuffer = buffer)
		{
			byte* pCurrData = pBuffer;
			for (byte* pEnd = pBuffer + operationsContentLength; pCurrData < pEnd; pCurrData += sizeof(Operation))
			{
				operations.Add(*(Operation*)pCurrData);
			}
		}
		GetUnmanagedValuesFromSocket<uint>(out var dataPoolSize);
		RawDataPool dataPool = new RawDataPool((IPipe)_slaverPipe, (int)dataPoolSize);
		OperationCollection operationCollection = new OperationCollection(operations, dataPool);
		lock (OperationCollectionsLock)
		{
			_operationCollections.Add(operationCollection);
		}
		long readSize = 4 + operationsContentLength + 4 + dataPoolSize;
		if (contentLength != readSize)
		{
			throw new Exception($"Content length: expected {contentLength}, actual {readSize}");
		}
		return false;
	}

	private static bool ReadInterProcessMessageDisconnect(int contentLength)
	{
		Logger.Info("Incoming message: Disconnect");
		if (contentLength != 0)
		{
			throw new Exception("Content length of Disconnect message must be zero: " + contentLength);
		}
		_shouldDisconnect = true;
		return true;
	}

	private static void WriteInterProcessMessages()
	{
		Logger.Info("WriteInterProcessMessages thread started.");
		while (true)
		{
			try
			{
				WriteInterProcessMessagesWarningMessages();
				WriteInterProcessMessagesErrorMessages();
				if (WriteInterProcessMessagesDisconnect())
				{
					break;
				}
				WriteInterProcessMessagesGameModuleInitialized();
				WriteInterProcessMessagesNotifications();
				Thread.Sleep(16);
				continue;
			}
			catch (Exception value)
			{
				Logger.Error(value);
				continue;
			}
		}
		Logger.Info("WriteInterProcessMessages thread is about to exit.");
		LogManager.Flush();
	}

	private unsafe static void WriteInterProcessMessagesGameModuleInitialized()
	{
		if (_gameDataModuleInitializationState == 2)
		{
			Logger.Info("Outgoing message: GameModuleInitialized");
			byte[] buffer = OutgoingMessageBuffer.Get(5);
			fixed (byte* pBuffer = buffer)
			{
				*pBuffer = 0;
				*(int*)(pBuffer + 1) = 0;
			}
			_slaverPipe.Write(buffer, 0, 5);
			SetGameDataModuleInitializationState(3);
		}
	}

	private static void WriteInterProcessMessagesNotifications()
	{
		lock (NotificationCollectionsLock)
		{
			if (_notificationCollections.Count <= 0)
			{
				return;
			}
			List<NotificationCollection> notificationCollections = _notificationCollections;
			List<NotificationCollection> writingNotificationCollections = _writingNotificationCollections;
			_writingNotificationCollections = notificationCollections;
			_notificationCollections = writingNotificationCollections;
			_notificationCollections.Clear();
		}
		foreach (NotificationCollection collection in _writingNotificationCollections)
		{
			int dataSize;
			byte[] buffer = CreateNotificationCollectionData(collection, out dataSize);
			_slaverPipe.Write(buffer, 0, dataSize);
			collection.DataPool.CopyTo((IPipe)_slaverPipe);
		}
		_writingNotificationCollections.Clear();
	}

	private unsafe static byte[] CreateNotificationCollectionData(NotificationCollection collection, out int dataSize)
	{
		int notificationsCount = collection.Notifications.Count;
		int contentLengthWithoutDataPool = 4 + sizeof(Notification) * notificationsCount + 4;
		int contentLength = contentLengthWithoutDataPool + collection.DataPool.RawDataSize;
		dataSize = 5 + contentLengthWithoutDataPool;
		byte[] buffer = OutgoingMessageBuffer.Get(dataSize);
		fixed (byte* pBuffer = buffer)
		{
			byte* pCurrData = pBuffer;
			*pCurrData = 1;
			pCurrData++;
			*(int*)pCurrData = contentLength;
			pCurrData += 4;
			*(int*)pCurrData = notificationsCount;
			pCurrData += 4;
			for (int i = 0; i < notificationsCount; i++)
			{
				*(Notification*)pCurrData = collection.Notifications[i];
				pCurrData += sizeof(Notification);
			}
			*(int*)pCurrData = collection.DataPool.RawDataSize;
		}
		return buffer;
	}

	private static void WriteInterProcessMessagesErrorMessages()
	{
		byte[] buffer;
		int dataSize;
		lock (ErrorMessages)
		{
			if (ErrorMessages.Count <= 0)
			{
				return;
			}
			buffer = CreateErrorMessagesData(out dataSize);
			ErrorMessages.Clear();
		}
		Logger.Info("Outgoing message: ErrorMessages");
		_slaverPipe?.Write(buffer, 0, dataSize);
	}

	private static void WriteInterProcessMessagesWarningMessages()
	{
		byte[] buffer;
		int dataSize;
		lock (WarningMessages)
		{
			if (WarningMessages.Count <= 0)
			{
				return;
			}
			buffer = CreateWarningMessagesData(out dataSize);
			WarningMessages.Clear();
		}
		Logger.Info("Outgoing message: WarningMessage");
		_slaverPipe?.Write(buffer, 0, dataSize);
	}

	private unsafe static byte[] CreateErrorMessagesData(out int dataSize)
	{
		int errorMessagesCount = ErrorMessages.Count;
		int contentLength = 0;
		for (int i = 0; i < errorMessagesCount; i++)
		{
			int elementSize = 2 * ErrorMessages[i].Length;
			if (elementSize > 65000)
			{
				elementSize = 65000;
			}
			contentLength += 2 + elementSize;
		}
		dataSize = 5 + contentLength;
		byte[] buffer = OutgoingMessageBuffer.Get(dataSize);
		fixed (byte* pBuffer = buffer)
		{
			byte* pCurrData = pBuffer;
			*pCurrData = 2;
			pCurrData++;
			*(int*)pCurrData = contentLength;
			pCurrData += 4;
			for (int j = 0; j < errorMessagesCount; j++)
			{
				string element = ErrorMessages[j];
				int charsCount = element.Length;
				int elementSize2 = 2 * charsCount;
				if (elementSize2 > 65000)
				{
					elementSize2 = 65000;
					charsCount = 32500;
				}
				*(ushort*)pCurrData = (ushort)elementSize2;
				pCurrData += 2;
				fixed (char* pErrorMessage = element)
				{
					for (int k = 0; k < charsCount; k++)
					{
						((short*)pCurrData)[k] = (short)pErrorMessage[k];
					}
				}
				pCurrData += elementSize2;
			}
		}
		return buffer;
	}

	private unsafe static byte[] CreateWarningMessagesData(out int dataSize)
	{
		int errorMessagesCount = WarningMessages.Count;
		int contentLength = 0;
		for (int i = 0; i < errorMessagesCount; i++)
		{
			int elementSize = 2 * WarningMessages[i].Length;
			if (elementSize > 65000)
			{
				elementSize = 65000;
			}
			contentLength += 2 + elementSize;
		}
		dataSize = 5 + contentLength;
		byte[] buffer = OutgoingMessageBuffer.Get(dataSize);
		fixed (byte* pBuffer = buffer)
		{
			byte* pCurrData = pBuffer;
			*pCurrData = 3;
			pCurrData++;
			*(int*)pCurrData = contentLength;
			pCurrData += 4;
			for (int j = 0; j < errorMessagesCount; j++)
			{
				string element = WarningMessages[j];
				int charsCount = element.Length;
				int elementSize2 = 2 * charsCount;
				if (elementSize2 > 65000)
				{
					elementSize2 = 65000;
					charsCount = 32500;
				}
				*(ushort*)pCurrData = (ushort)elementSize2;
				pCurrData += 2;
				fixed (char* pWarningMessage = element)
				{
					for (int k = 0; k < charsCount; k++)
					{
						((short*)pCurrData)[k] = (short)pWarningMessage[k];
					}
				}
				pCurrData += elementSize2;
			}
		}
		return buffer;
	}

	private unsafe static bool WriteInterProcessMessagesDisconnect()
	{
		if (!_shouldDisconnect)
		{
			return false;
		}
		Logger.Info("Outgoing message: Disconnect");
		try
		{
			byte[] buffer = OutgoingMessageBuffer.Get(5);
			fixed (byte* pBuffer = buffer)
			{
				*pBuffer = 4;
				*(int*)(pBuffer + 1) = 0;
			}
			_slaverPipe?.Write(buffer, 0, 5);
		}
		catch (Exception value)
		{
			Logger.Error(value);
		}
		return true;
	}

	private static byte[] GetRawDataFromSocket(int size)
	{
		byte[] buffer = IncomingMessageBuffer.Get(size);
		int received;
		for (int totalReceived = 0; totalReceived < size; totalReceived += received)
		{
			received = _slaverPipe.Read(buffer, totalReceived, size - totalReceived);
		}
		return buffer;
	}

	private unsafe static void GetUnmanagedValuesFromSocket<T1>(out T1 item1) where T1 : unmanaged
	{
		int size = sizeof(T1);
		byte[] buffer = IncomingMessageBuffer.Get(size);
		int received;
		for (int totalReceived = 0; totalReceived < size; totalReceived += received)
		{
			received = _slaverPipe.Read(buffer, totalReceived, size - totalReceived);
		}
		fixed (byte* pBuffer = buffer)
		{
			item1 = *(T1*)pBuffer;
		}
	}

	private unsafe static void GetUnmanagedValuesFromSocket<T1, T2>(out T1 item1, out T2 item2) where T1 : unmanaged where T2 : unmanaged
	{
		int size = sizeof(T1) + sizeof(T2);
		byte[] buffer = IncomingMessageBuffer.Get(size);
		int received;
		for (int totalReceived = 0; totalReceived < size; totalReceived += received)
		{
			received = _slaverPipe.Read(buffer, totalReceived, size - totalReceived);
		}
		fixed (byte* pBuffer = buffer)
		{
			item1 = *(T1*)pBuffer;
			item2 = *(T2*)(pBuffer + sizeof(T1));
		}
	}
}
