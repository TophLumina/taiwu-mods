using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Config;
using Config.Common;
using GameData.Achievement;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ArchiveData;
using GameData.Common;
using GameData.Common.SingleValueCollection;
using GameData.Common.WorkerThread;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Creation;
using GameData.Domains.Global.Inscription;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.World;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using NLog;
using Redzen.Random;

namespace GameData.Domains.Global;

[GameDataDomain(0, ArchiveAttached = false, CustomArchiveModuleCode = true)]
public class GlobalDomain : BaseGameDataDomain
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[DomainData(DomainDataType.SingleValue, false, false, false, false)]
	private int _global;

	[DomainData(DomainDataType.SingleValue, false, false, true, false)]
	private bool _loadedAllArchiveData;

	[DomainData(DomainDataType.SingleValue, false, false, true, false)]
	private bool _savingWorld;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<InscribedCharacterKey, InscribedCharacter> _inscribedCharacters;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<InscribedCharacterKey, int> _inscribedCharacterPinOrders;

	private static string _gameVersionStr;

	private static string _gameBuildDateStr;

	public static SharedGlobalSettings Settings;

	public bool GlobalDataLoaded;

	[DomainData(DomainDataType.SingleValue, false, false, true, false)]
	private sbyte _currGameWorldType;

	private HashSet<ushort> _loadingDomainIds;

	private CompressionAlgorithm _compressionAlgorithm = CompressionAlgorithm.Deflate;

	private CompressionType _compressionType = CompressionType.PrioritizeSpeed;

	private static readonly HashSet<ushort> ArchiveDataIds = new HashSet<ushort>();

	private bool _needToSaveGlobal;

	private GlobalArchiveFile _globalArchiveFile;

	private CrossInWorldGuideGameData _crossInWorldGuideGameData;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private List<short> _ownedChickens;

	private CrossArchiveGameData _crossArchiveGameData;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private CustomProtagonistPreset _customProtagonistPreset;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private ulong _globalFlags;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private Dictionary<short, long> _achievements = new Dictionary<short, long>();

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private Dictionary<short, GameStatRecordWrapper> _gameStats = new Dictionary<short, GameStatRecordWrapper>();

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private long _lastTimeOpenAchievements;

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[12][];

	private SingleValueCollectionModificationCollection<InscribedCharacterKey> _modificationsInscribedCharacters = SingleValueCollectionModificationCollection<InscribedCharacterKey>.Create();

	private SingleValueCollectionModificationCollection<InscribedCharacterKey> _modificationsInscribedCharacterPinOrders = SingleValueCollectionModificationCollection<InscribedCharacterKey>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAchievements = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsGameStats = SingleValueCollectionModificationCollection<short>.Create();

	private void OnInitializedDomainData()
	{
		GlobalDataLoaded = false;
		_needToSaveGlobal = false;
		InitArchiveDataIds();
	}

	private void InitializeOnInitializeGameDataModule()
	{
	}

	private void InitializeOnEnterNewWorld()
	{
	}

	private void OnLoadedArchiveData()
	{
		GlobalDataLoaded = true;
	}

	[DomainMethod]
	public void EnterNewWorld(sbyte archiveId)
	{
		if (GameData.ArchiveData.Common.IsInWorld())
		{
			throw new Exception("Cannot enter new world when it's already in a world");
		}
		GameData.ArchiveData.Common.SetArchiveId(archiveId);
		SetLoadedAllArchiveData(value: false, null);
		SetCurrGameWorldType(1, null);
		DomainManager.ResetArchiveAttachedDomains();
		BaseGameDataDomain[] archiveAttachedDomains = DomainManager.GetArchiveAttachedDomains();
		foreach (BaseGameDataDomain domain in archiveAttachedDomains)
		{
			domain.OnEnterNewWorld();
		}
		DataUid uid = new DataUid(0, 1, ulong.MaxValue);
		AddPostModificationHandler(uid, "InitAchievements", InitAchievements);
		DatabaseBridge.Disconnect(deleteWorkingDb: true);
		DatabaseBridge.Connect();
	}

	[DomainMethod]
	public void LoadWorld(sbyte archiveId, long backupTimestamp)
	{
		if (GameData.ArchiveData.Common.IsInWorld())
		{
			throw new Exception("Cannot load world when it's already in a world");
		}
		GameData.ArchiveData.Common.SetArchiveId(archiveId);
		SetLoadedAllArchiveData(value: false, null);
		_loadingDomainIds = new HashSet<ushort>(DomainManager.ArchiveAttachedDomainIds);
		DataUid uid = new DataUid(0, 1, ulong.MaxValue);
		AddPostModificationHandler(uid, "RegisterItemOwners", ItemDomain.RegisterItemOwners);
		AddPostModificationHandler(uid, "FixAllAbnormalDomainArchiveData", FixAllAbnormalDomainArchiveData);
		AddPostModificationHandler(uid, "InitBuildingEffect", InitBuildingEffect);
		AddPostModificationHandler(uid, "InitAchievements", InitAchievements);
		GameData.GameDataBridge.GameDataBridge.StartNextFrame(delegate
		{
			Stopwatch sw = StartTimer();
			string text = ((backupTimestamp < 0) ? GameData.ArchiveData.Common.GetArchiveDataPath(archiveId) : GameData.ArchiveData.Common.GetArchiveDataPath(archiveId, backupTimestamp));
			LocalArchiveFile localArchiveFile = new LocalArchiveFile(text);
			try
			{
				localArchiveFile.Load();
			}
			catch (Exception arg)
			{
				PredefinedLog.DefValue.LoadArchiveDataFailed.Log(text, arg);
				GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.BackToMainMenu);
				RemovePostModificationHandlers(uid);
			}
			SetCurrGameWorldType(1, null);
			StopTimer(sw, "LoadWorld");
		});
	}

	[DomainMethod]
	public void EnterInGameGuideWorld(DataContext context, short templateId)
	{
		_crossInWorldGuideGameData = new CrossInWorldGuideGameData
		{
			ArchiveId = GameData.ArchiveData.Common.GetCurrArchiveId()
		};
		SetLoadedAllArchiveData(value: false, context);
		string path = GameData.ArchiveData.Common.GetTempSavePath(_crossInWorldGuideGameData.ArchiveId);
		SaveWorldAt(context, path, completeNextFrame: false);
		LeaveWorld();
		string guideWorldPath = Path.Combine(Program.BaseDataDir, "The Scroll of Taiwu_Data", "GuideWorlds", $"guide_{templateId}.sav");
		LoadWorldAt(context, guideWorldPath);
		SetCurrGameWorldType(3, null);
		GameData.ArchiveData.Common.SetArchiveId(_crossInWorldGuideGameData.ArchiveId);
	}

	[DomainMethod]
	public void ExitInGameGuideWorld(DataContext context)
	{
		LeaveWorld();
		string path = GameData.ArchiveData.Common.GetTempSavePath(_crossInWorldGuideGameData.ArchiveId);
		LoadWorldAt(context, path);
		SetCurrGameWorldType(1, null);
		GameData.ArchiveData.Common.SetArchiveId(_crossInWorldGuideGameData.ArchiveId);
		GameData.GameDataBridge.GameDataBridge.StartNextFrame(delegate
		{
			File.Delete(path);
			_crossInWorldGuideGameData = null;
		});
	}

	[DomainMethod]
	public void EnterTutorialWorld(DataContext context, short templateId)
	{
		SetCurrGameWorldType(2, context);
		WorldCreationInfo worldCreationInfo = new WorldCreationInfo
		{
			CombatDifficulty = 1,
			TaiwuVillageStateTemplateId = 1
		};
		DomainManager.TutorialChapter.CreateFixedWorld(context, templateId, worldCreationInfo);
	}

	[DomainMethod]
	public void LoadEnding(sbyte archiveId)
	{
		if (GameData.ArchiveData.Common.IsInWorld())
		{
			throw new Exception("Need to exit the current world first.");
		}
		GameData.ArchiveData.Common.SetArchiveId(archiveId);
		SetLoadedAllArchiveData(value: false, null);
		_loadingDomainIds = new HashSet<ushort>(DomainManager.ArchiveAttachedDomainIds);
		DataUid uid = new DataUid(0, 1, ulong.MaxValue);
		AddPostModificationHandler(uid, "RegisterItemOwners", ItemDomain.RegisterItemOwners);
		AddPostModificationHandler(uid, "UnpackAllCrossArchiveGameData", UnpackAllCrossArchiveGameData);
		AddPostModificationHandler(uid, "FixAllAbnormalDomainArchiveData", FixAllAbnormalDomainArchiveData);
		AddPostModificationHandler(uid, "InitBuildingEffect", InitBuildingEffect);
		GameData.GameDataBridge.GameDataBridge.StartNextFrame(delegate
		{
			Stopwatch sw = StartTimer();
			string dreamBackArchiveDataPath = GameData.ArchiveData.Common.GetDreamBackArchiveDataPath(archiveId);
			LocalArchiveFile localArchiveFile = new LocalArchiveFile(dreamBackArchiveDataPath);
			try
			{
				localArchiveFile.Load();
			}
			catch (Exception arg)
			{
				PredefinedLog.DefValue.LoadArchiveDataFailed.Log(dreamBackArchiveDataPath, arg);
				GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.BackToMainMenu);
				RemovePostModificationHandlers(uid);
			}
			SetCurrGameWorldType(1, null);
			StopTimer(sw, "LoadEnding");
		});
	}

	public void SaveEnding(DataContext context)
	{
		if (!GameData.ArchiveData.Common.IsInWorld())
		{
			throw new Exception("Cannot save world when it's not in a world");
		}
		WorldDomain.CheckSanity();
		Events.RaiseBeforeSaveWorld(context);
		GameData.GameDataBridge.GameDataBridge.StartNextFrame(delegate
		{
			Stopwatch sw = StartTimer();
			sbyte currArchiveId = GameData.ArchiveData.Common.GetCurrArchiveId();
			string dreamBackArchiveDataPath = GameData.ArchiveData.Common.GetDreamBackArchiveDataPath(currArchiveId);
			LocalArchiveFile localArchiveFile = new LocalArchiveFile(dreamBackArchiveDataPath);
			localArchiveFile.Save(_compressionAlgorithm, _compressionType);
			StopTimer(sw, "SaveEnding");
		});
	}

	public void CompleteLoading(ushort domainId)
	{
		if (_loadingDomainIds != null)
		{
			_loadingDomainIds.Remove(domainId);
			if (_loadingDomainIds.Count <= 0)
			{
				_loadingDomainIds = null;
				OnCurrWorldArchiveDataReady(DataContextManager.GetCurrentThreadDataContext(), isNewWorld: false);
			}
		}
	}

	public override void OnCurrWorldArchiveDataReady(DataContext context, bool isNewWorld)
	{
		if (_loadedAllArchiveData)
		{
			Logger.Warn("OnCurrWorldArchiveDataReady called when _loadedAllArchiveData already set to true.");
			return;
		}
		BaseGameDataDomain[] archiveAttachedDomains = DomainManager.GetArchiveAttachedDomains();
		foreach (BaseGameDataDomain domain in archiveAttachedDomains)
		{
			domain.OnCurrWorldArchiveDataReady(context, isNewWorld);
		}
		SetLoadedAllArchiveData(value: true, context);
	}

	private void FixAllAbnormalDomainArchiveData(DataContext context, DataUid uid)
	{
		if (_loadedAllArchiveData)
		{
			Stopwatch timer = StartTimer();
			BaseGameDataDomain[] archiveAttachedDomains = DomainManager.GetArchiveAttachedDomains();
			foreach (BaseGameDataDomain domain in archiveAttachedDomains)
			{
				domain.FixAbnormalDomainArchiveData(context);
			}
			RemovePostModificationHandler(uid, "FixAllAbnormalDomainArchiveData");
			StopTimer(timer, "FixAbnormalDomainArchiveData");
		}
	}

	private void InitBuildingEffect(DataContext context, DataUid uid)
	{
		DomainManager.Building.UpdateBuildingEffect();
	}

	private void InitAchievements(DataContext context, DataUid uid)
	{
		AchievementManager.OnArchiveDataLoaded(context, uid);
	}

	[DomainMethod]
	public void SaveWorld(DataContext context)
	{
		SaveWorld(context, 0);
	}

	public void SaveWorld(DataContext context, sbyte minBackupCount)
	{
		if (DomainManager.Taiwu.AtPastTaiwuVillage())
		{
			DomainManager.Extra.UpdateActionPoint(context);
		}
		if (!GameData.ArchiveData.Common.IsInWorld())
		{
			AdaptableLog.Warning("Trying to save game while not in a world.");
			return;
		}
		SetSavingWorld(value: true, null);
		DomainManager.World.UpdateSavingWorldVersionInfo(context);
		DomainManager.Extra.BackupDreamBackArchiveData(context);
		WorldDomain.CheckSanity();
		Events.RaiseBeforeSaveWorld(context);
		GameData.GameDataBridge.GameDataBridge.StartNextFrame(delegate
		{
			if (!GameData.ArchiveData.Common.IsInWorld())
			{
				AdaptableLog.Warning("Trying to save game while not in a world.");
				SetSavingWorld(value: false, null);
			}
			else if (!CheckDriveSpace(context))
			{
				SetSavingWorld(value: false, null);
			}
			else
			{
				Stopwatch sw = StartTimer();
				sbyte currArchiveId = GameData.ArchiveData.Common.GetCurrArchiveId();
				string archiveDataPath = GameData.ArchiveData.Common.GetArchiveDataPath(currArchiveId);
				string text = archiveDataPath + ".old";
				if (File.Exists(archiveDataPath))
				{
					try
					{
						File.Move(archiveDataPath, text, overwrite: true);
					}
					catch (Exception arg)
					{
						PredefinedLog.DefValue.TransferToOldFailed.Log(archiveDataPath, arg);
					}
				}
				LocalArchiveFile localArchiveFile = new LocalArchiveFile(archiveDataPath);
				try
				{
					localArchiveFile.Save(_compressionAlgorithm, _compressionType);
				}
				catch (Exception value)
				{
					Logger.AppendWarning($"Failed to save archive data. \n{value}");
					if (File.Exists(text))
					{
						File.Copy(text, archiveDataPath, overwrite: true);
					}
					return;
				}
				finally
				{
					StopTimer(sw, "SaveWorld");
				}
				sbyte b = ShouldMakeBackup(minBackupCount);
				if (b > 0)
				{
					GameData.ArchiveData.Common.MakeBackup(currArchiveId);
					GameData.ArchiveData.Common.RemoveRedundantBackups(currArchiveId, b);
				}
				SetSavingWorld(value: false, null);
			}
		});
	}

	private void SaveWorldAt(DataContext context, string filePath, bool completeNextFrame = true)
	{
		if (!GameData.ArchiveData.Common.IsInWorld())
		{
			throw new Exception("Cannot save world when it's not in a world");
		}
		SetSavingWorld(value: true, null);
		DomainManager.World.UpdateSavingWorldVersionInfo(context);
		DomainManager.Extra.BackupDreamBackArchiveData(context);
		WorldDomain.CheckSanity();
		Events.RaiseBeforeSaveWorld(context);
		if (completeNextFrame)
		{
			GameData.GameDataBridge.GameDataBridge.StartNextFrame(ConfirmSave);
		}
		else
		{
			ConfirmSave();
		}
		void ConfirmSave()
		{
			if (!CheckDriveSpace(context))
			{
				throw new Exception("Drive space to enough.");
			}
			Stopwatch sw = StartTimer();
			LocalArchiveFile archiveFile = new LocalArchiveFile(filePath);
			archiveFile.Save(_compressionAlgorithm, _compressionType);
			StopTimer(sw, "SaveWorld");
			SetSavingWorld(value: false, null);
		}
	}

	private void LoadWorldAt(DataContext context, string filePath)
	{
		if (GameData.ArchiveData.Common.IsInWorld())
		{
			throw new Exception("Need to exit the current world first.");
		}
		_loadingDomainIds = new HashSet<ushort>(DomainManager.ArchiveAttachedDomainIds);
		DataUid uid = new DataUid(0, 1, ulong.MaxValue);
		AddPostModificationHandler(uid, "RegisterItemOwners", ItemDomain.RegisterItemOwners);
		AddPostModificationHandler(uid, "FixAllAbnormalDomainArchiveData", FixAllAbnormalDomainArchiveData);
		AddPostModificationHandler(uid, "InitBuildingEffect", InitBuildingEffect);
		GameData.GameDataBridge.GameDataBridge.StartNextFrame(delegate
		{
			Stopwatch sw = StartTimer();
			LocalArchiveFile localArchiveFile = new LocalArchiveFile(filePath);
			try
			{
				localArchiveFile.Load();
			}
			catch (Exception arg)
			{
				PredefinedLog.DefValue.LoadArchiveDataFailed.Log(filePath, arg);
				GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.BackToMainMenu);
				RemovePostModificationHandlers(uid);
			}
			StopTimer(sw, "LoadWorld");
		});
	}

	[DomainMethod]
	public void LeaveWorld()
	{
		if (!GameData.ArchiveData.Common.IsInWorld())
		{
			throw new Exception("Cannot leave world when it's not in a world");
		}
		DatabaseBridge.Disconnect(deleteWorkingDb: false);
		DomainManager.ResetArchiveAttachedDomains();
		GameData.GameDataBridge.GameDataBridge.ClearMonitoredData();
		Events.ClearAllHandlers();
		ObjectPoolManager.Initialize();
		WorkerThreadManager.ReInitialize();
		GameData.ArchiveData.Common.ResetArchiveId();
		SetLoadedAllArchiveData(value: false, null);
		SetCurrGameWorldType(0, null);
		DataUid uid = new DataUid(0, 1, ulong.MaxValue);
		RemovePostModificationHandler(uid, "InitAchievements");
	}

	[DomainMethod(IsPassthrough = true)]
	public void GetArchivesInfo(uint operationId)
	{
		ArchiveInfo[] archivesInfo = GetArchivesInfo();
		GameData.GameDataBridge.GameDataBridge.TryReturnPassthroughMethod(operationId, archivesInfo);
	}

	private ArchiveInfo[] GetArchivesInfo()
	{
		sbyte archiveSlotCount = 15;
		ArchiveInfo[] slots = new ArchiveInfo[archiveSlotCount];
		for (sbyte i = 0; i < archiveSlotCount; i++)
		{
			string slotDir = GameData.ArchiveData.Common.GetArchiveDataDirectory(i);
			if (!Directory.Exists(slotDir))
			{
				slots[i] = new ArchiveInfo
				{
					Status = 0,
					BackupWorldsInfo = new List<(long, WorldInfo)>(0)
				};
			}
			else
			{
				string archiveDataPath = GameData.ArchiveData.Common.GetArchiveDataPath(i);
				LocalArchiveFile archiveFile = new LocalArchiveFile(archiveDataPath);
				if (!archiveFile.TryGetArchiveInfo(out slots[i]))
				{
					slots[i] = new ArchiveInfo
					{
						Status = 2
					};
				}
				slots[i].BackupWorldsInfo = new List<(long, WorldInfo)>();
				List<long> backupTimestamps = GameData.ArchiveData.Common.GetBackupTimestamps(i);
				backupTimestamps.Reverse();
				foreach (long timestamp in backupTimestamps)
				{
					string file = GameData.ArchiveData.Common.GetArchiveDataPath(i, timestamp);
					LocalArchiveFile backupFile = new LocalArchiveFile(file);
					if (backupFile.TryGetArchiveInfo(out var backupArchiveInfo))
					{
						slots[i].BackupWorldsInfo.Add((timestamp, backupArchiveInfo.WorldInfo));
					}
				}
			}
		}
		return slots;
	}

	[DomainMethod]
	public void DeleteArchive(sbyte archiveId)
	{
		if (!GameData.ArchiveData.Common.CheckArchiveId(archiveId))
		{
			throw new Exception($"Invalid archiveId: {archiveId}");
		}
		GameData.ArchiveData.Common.DeleteArchive(archiveId);
	}

	[DomainMethod]
	public void SetGameBuildInfo(string gameVersion, string gameBuildDate)
	{
		_gameVersionStr = gameVersion;
		_gameBuildDateStr = gameBuildDate;
		Logger.Info("Game Version: " + gameVersion + ", Build Date: " + gameBuildDate);
	}

	[DomainMethod]
	public void SetCompressionType(byte compressionType)
	{
		_compressionType = (CompressionType)compressionType;
	}

	public string GetGameVersion()
	{
		return _gameVersionStr;
	}

	public string GetGameBuildDate()
	{
		return _gameBuildDateStr;
	}

	private static sbyte ShouldMakeBackup(sbyte minBackupCount)
	{
		sbyte backupInterval = DomainManager.World.GetArchiveFilesBackupInterval();
		if (backupInterval <= 0 && minBackupCount <= 0)
		{
			return 0;
		}
		int currDate = DomainManager.World.GetCurrDate();
		sbyte backupCount = Math.Max(minBackupCount, DomainManager.World.GetArchiveFilesBackupCount());
		return (sbyte)((currDate % backupInterval == 0) ? backupCount : 0);
	}

	[DomainMethod]
	public bool CheckDriveSpace(DataContext context)
	{
		string archiveBaseDir = GameData.ArchiveData.Common.ArchiveBaseDir;
		string root = Path.GetPathRoot(archiveBaseDir);
		if (root == null)
		{
			Logger.Warn("Invalid root directory for path: " + archiveBaseDir);
			return false;
		}
		long requiredSpace = 1073741824L;
		sbyte archiveId = GameData.ArchiveData.Common.GetCurrArchiveId();
		if (archiveId >= 0)
		{
			string prevArchiveFilePath = Path.Combine(archiveBaseDir, $"World_{archiveId + 1}/local.sav");
			if (File.Exists(prevArchiveFilePath))
			{
				FileInfo fileInfo = new FileInfo(prevArchiveFilePath);
				requiredSpace = Math.Max(requiredSpace, fileInfo.Length * 3);
			}
		}
		DriveInfo driveInfo = new DriveInfo(root);
		Logger.Info($"Required Space: {requiredSpace} bytes.\nAvailable Space: {driveInfo.AvailableFreeSpace}");
		return driveInfo.AvailableFreeSpace >= requiredSpace;
	}

	public bool IsInNormalWorld()
	{
		return _currGameWorldType == 1;
	}

	private static void InitArchiveDataIds()
	{
		Type domainDataAttrType = typeof(DomainDataAttribute);
		ArchiveDataIds.Clear();
		FieldInfo[] fields = typeof(GlobalDomain).GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in fields)
		{
			object[] fieldAttributes = fieldInfo.GetCustomAttributes(domainDataAttrType, inherit: false);
			if (fieldAttributes.Length != 0)
			{
				DomainDataAttribute fieldAttr = (DomainDataAttribute)fieldAttributes[0];
				if (fieldAttr.IsArchive)
				{
					string fieldPublicName = DataDependenciesInfo.ToPublicName(fieldInfo.Name);
					ushort dataId = GlobalDomainHelper.FieldName2DataId[fieldPublicName];
					ArchiveDataIds.Add(dataId);
				}
			}
		}
	}

	public void LoadGlobal()
	{
		string path = Path.Combine(GameData.ArchiveData.Common.ArchiveBaseDir, "global.sav");
		if (_globalArchiveFile == null)
		{
			_globalArchiveFile = new GlobalArchiveFile(path);
		}
		try
		{
			if (File.Exists(path))
			{
				_globalArchiveFile.Load();
			}
			else
			{
				OnEnterNewWorld();
			}
		}
		catch (Exception ex)
		{
			Logger.Warn("Invalid global archive file.\n" + ex);
			OnEnterNewWorld();
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(0);
	}

	private void SaveGlobal()
	{
		string path = Path.Combine(GameData.ArchiveData.Common.ArchiveBaseDir, "global.sav");
		if (_globalArchiveFile == null)
		{
			_globalArchiveFile = new GlobalArchiveFile(path);
		}
		_globalArchiveFile.Save(_compressionAlgorithm, _compressionType);
	}

	protected override void SetModifiedAndInvalidateInfluencedCache(int dataId, byte[] dataStates, DataInfluence[][] cacheInfluences, DataContext context)
	{
		if (ArchiveDataIds.Contains((ushort)dataId))
		{
			_needToSaveGlobal = true;
		}
		base.SetModifiedAndInvalidateInfluencedCache(dataId, dataStates, cacheInfluences, context);
	}

	public override void OnUpdate(DataContext context)
	{
		base.OnUpdate(context);
		if (_needToSaveGlobal && GlobalDataLoaded)
		{
			SaveGlobal();
			_needToSaveGlobal = false;
		}
	}

	public void OnPostAdvanceMonth(DataContext context)
	{
		DomainManager.Building.SaveChicken(context);
		if (DomainManager.TutorialChapter.InGuiding && DomainManager.TutorialChapter.GetTutorialChapter() == 1)
		{
			DomainManager.Building.TutorialUpdate(context);
		}
		InvokeGuidingTrigger(context, 0);
		InvokeGuidingTrigger(context, 2);
		if (DomainManager.World.GetCurrMonthInYear() == GlobalConfig.Instance.CricketActiveStartMonth)
		{
			InvokeGuidingTrigger(context, 3);
		}
	}

	public void AddChicken(DataContext context, short templateId)
	{
		if (!_ownedChickens.Contains(templateId))
		{
			_ownedChickens.Add(templateId);
			SetOwnedChickens(_ownedChickens, context);
			AchievementManager.RequestSetStat(context, (short)12, (int)templateId);
		}
	}

	[DomainMethod]
	public bool UpdateSharedGlobalSettings(SharedGlobalSettings settings)
	{
		bool shouldReload = Settings != null && settings.Language != Settings.Language;
		Settings = settings;
		if (shouldReload)
		{
			ReloadAllConfigData();
		}
		return true;
	}

	[DomainMethod]
	public bool ReloadAllConfigData()
	{
		LocalStringManager.Init(Settings.Language);
		Parallel.ForEach(ConfigCollection.Items, delegate(IConfigData item)
		{
			item.Init();
		});
		RefNameMap.DoQueuedLoadRequests();
		DynamicMapping.Initialize();
		DomainManager.TaiwuEvent.ReloadAllPackageLanguages();
		Equipping.InitFormulas();
		CharacterActionPlanner.Instance.Initialize();
		return true;
	}

	[DomainMethod]
	public void PackAllCrossArchiveGameData()
	{
		Logger.Info("Start packing cross archive game data.");
		CrossArchiveGameData data = new CrossArchiveGameData();
		if (_crossArchiveGameData != null)
		{
			data.SectZhujianGearMate = _crossArchiveGameData.SectZhujianGearMate;
		}
		_crossArchiveGameData = data;
		BaseGameDataDomain[] domains = DomainManager.Domains;
		foreach (BaseGameDataDomain domain in domains)
		{
			domain.PackCrossArchiveGameData(_crossArchiveGameData);
		}
	}

	public void UnpackAllCrossArchiveGameData(DataContext context, DataUid uid)
	{
		if (_crossArchiveGameData != null)
		{
			BaseGameDataDomain[] domains = DomainManager.Domains;
			foreach (BaseGameDataDomain domain in domains)
			{
				domain.UnpackCrossArchiveGameData(context, _crossArchiveGameData);
			}
			_crossArchiveGameData = null;
			Logger.Info("Finish packing cross archive game data.");
		}
	}

	[DomainMethod]
	public void SetCustomProtagonistPreset(DataContext context, CustomProtagonistPreset customProtagonistPreset)
	{
		SetCustomProtagonistPreset(customProtagonistPreset, context);
	}

	[DomainMethod]
	public void SetGlobalFlag(DataContext context, sbyte flagType, bool value)
	{
		_globalFlags = BitOperation.SetBit(_globalFlags, flagType, value);
		SetGlobalFlags(_globalFlags, context);
	}

	[DomainMethod]
	public bool GetGlobalFlag(sbyte flagType)
	{
		return BitOperation.GetBit(_globalFlags, flagType);
	}

	public void CheckPregnantGuidingTrigger(DataContext context)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		if (DomainManager.Character.TryGetPregnantState(taiwuId, out var pregnantState))
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 238);
			return;
		}
		HashSet<int> ids = DomainManager.Character.GetRelatedCharIds(taiwuId, 1024);
		if (ids.Count == 0)
		{
			return;
		}
		foreach (int id in ids)
		{
			if (DomainManager.Character.TryGetPregnantState(id, out pregnantState))
			{
				DomainManager.Global.InvokeGuidingTrigger(context, 238);
				break;
			}
		}
	}

	public void CheckHasTwoWayAdoredGuidingTrigger(DataContext context)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		HashSet<int> ids = DomainManager.Character.GetRelatedCharIds(taiwuId, 1024);
		if (ids.Count != 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 230);
			return;
		}
		ids = DomainManager.Character.GetRelatedCharIds(taiwuId, 16384);
		CharacterSet ids2 = DomainManager.Character.GetReversedRelatedCharIds(taiwuId, 16384);
		foreach (int id in ids)
		{
			if (ids2.Contains(id))
			{
				DomainManager.Global.InvokeGuidingTrigger(context, 230);
				break;
			}
		}
	}

	public void CheckFiveElementConflictGuidingTrigger(DataContext context, sbyte currNeiliType)
	{
		if (currNeiliType >= 0 && NeiliType.Instance[currNeiliType].ShowConflictingWorldState)
		{
			InvokeGuidingTrigger(context, 264);
		}
	}

	[DomainMethod]
	public void InvokeGuidingTrigger(DataContext context, short templateId)
	{
		if (DomainManager.TutorialChapter.InGuiding)
		{
			return;
		}
		GuidingChapterTriggerItem trigger = GuidingChapterTrigger.Instance[templateId];
		List<short> list = trigger?.Chapters;
		if (list == null || list.Count <= 0)
		{
			return;
		}
		foreach (short chapterId in trigger.Chapters)
		{
			DomainManager.World.TriggeredGuidingChapter(context, chapterId);
		}
	}

	[DomainMethod]
	public void InscribeCharacter(DataContext context, int charId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		InscribedCharacter inscribedChar = CreateInscribedCharacter(character);
		uint worldId = DomainManager.World.GetWorldId();
		InscribedCharacterKey key = new InscribedCharacterKey(worldId, charId);
		AddElement_InscribedCharacters(key, inscribedChar, context);
		AchievementManager.RequestSetStat(context, 60, 1);
	}

	private InscribedCharacter CreateInscribedCharacter(GameData.Domains.Character.Character character)
	{
		InscribedCharacter inscribedCharacter = new InscribedCharacter();
		inscribedCharacter.Timestamp = DateTime.UtcNow.Ticks;
		inscribedCharacter.Gender = character.GetGender();
		inscribedCharacter.ActualAge = character.GetActualAge();
		inscribedCharacter.CurrAge = character.GetCurrAge();
		inscribedCharacter.BaseMaxHealth = character.GetBaseMaxHealth();
		inscribedCharacter.Morality = character.GetMorality();
		inscribedCharacter.OrganizationInfo = character.GetOrganizationInfo();
		inscribedCharacter.Avatar = new AvatarData(character.GetAvatar());
		inscribedCharacter.ClothingDisplayId = character.GetClothingDisplayId();
		inscribedCharacter.BirthMonth = character.GetBirthMonth();
		inscribedCharacter.BaseMainAttributes = character.GetBaseMainAttributes();
		inscribedCharacter.BaseLifeSkillQualifications = character.GetBaseLifeSkillQualifications();
		inscribedCharacter.LifeSkillQualificationGrowthType = character.GetLifeSkillQualificationGrowthType();
		inscribedCharacter.BaseCombatSkillQualifications = character.GetBaseCombatSkillQualifications();
		inscribedCharacter.CombatSkillQualificationGrowthType = character.GetCombatSkillQualificationGrowthType();
		inscribedCharacter.InnateSkillQualificationBonuses = new SkillQualificationBonus[2];
		inscribedCharacter.FeatureIds = new List<short>();
		InscribedCharacter inscribedChar = inscribedCharacter;
		(inscribedChar.Surname, inscribedChar.GivenName) = CharacterDomain.GetRealName(character);
		character.GetInscribableFeatureIds(inscribedChar.FeatureIds);
		List<SkillQualificationBonus> skillQualificationBonuses = character.GetSkillQualificationBonuses();
		if (skillQualificationBonuses.CheckIndex(0))
		{
			inscribedChar.InnateSkillQualificationBonuses[0] = skillQualificationBonuses[0];
		}
		if (skillQualificationBonuses.CheckIndex(1))
		{
			inscribedChar.InnateSkillQualificationBonuses[1] = skillQualificationBonuses[1];
		}
		return inscribedChar;
	}

	[DomainMethod]
	public void RemoveInscribedCharacter(DataContext context, InscribedCharacterKey key)
	{
		RemoveElement_InscribedCharacters(key, context);
	}

	public bool IsCharacterInscribed(InscribedCharacterKey key)
	{
		return _inscribedCharacters.ContainsKey(key);
	}

	[DomainMethod]
	public void SetInscribedCharacterPinOrder(DataContext context, InscribedCharacterKey key, int order)
	{
		if (_inscribedCharacterPinOrders.ContainsKey(key))
		{
			SetElement_InscribedCharacterPinOrders(key, order, context);
		}
		else
		{
			AddElement_InscribedCharacterPinOrders(key, order, context);
		}
	}

	[DomainMethod]
	public void RemoveInscribedCharacterPinOrder(DataContext context, InscribedCharacterKey key)
	{
		if (_inscribedCharacterPinOrders.ContainsKey(key))
		{
			RemoveElement_InscribedCharacterPinOrders(key, context);
		}
	}

	public static Stopwatch StartTimer()
	{
		return Stopwatch.StartNew();
	}

	public static void StopTimer(Stopwatch sw, string label)
	{
		sw.Stop();
		Logger.Info($"{label}: {sw.Elapsed.TotalMilliseconds:N1}");
	}

	public static void ShowMemoryUsage()
	{
		long totalMemory = GC.GetTotalMemory(forceFullCollection: true);
		Logger.Info($"Total managed memory usage: {(double)totalMemory / 1024.0 / 1024.0:N1}MB");
	}

	private void RunTestGetCacheData(DataContext context)
	{
		context.Random.Reinitialise(1uL);
		EnterNewWorld(2);
		GameData.Domains.Character.Character[] characters = RunTestGetCacheData_CreateCharacters(context);
		RunTestGetCacheData_MultiThreads(context, characters);
		LeaveWorld();
	}

	private static GameData.Domains.Character.Character[] RunTestGetCacheData_CreateCharacters(DataContext context)
	{
		Logger.Info($"ProcessorCount: {Environment.ProcessorCount}");
		int charactersCount = 100000 * Environment.ProcessorCount;
		GameData.Domains.Character.Character[] characters = new GameData.Domains.Character.Character[charactersCount];
		IRandomSource random = context.Random;
		for (int i = 0; i < charactersCount; i++)
		{
			sbyte gender = Gender.GetRandom(random);
			sbyte orgTemplateId = OrganizationDomain.GetRandomSectOrgTemplateId(random, gender);
			sbyte grade = (sbyte)random.Next(9);
			IntelligentCharacterCreationInfo info = new IntelligentCharacterCreationInfo(new Location((short)random.Next(45), 0), new OrganizationInfo(orgTemplateId, grade, principal: true, -1), (short)random.Next(1, 33));
			GameData.Domains.Character.Character character = DomainManager.Character.CreateIntelligentCharacter(context, ref info);
			List<short> featureIds = character.GetFeatureIds();
			featureIds.Clear();
			for (int j = 0; j < 10; j++)
			{
				int featureId = random.Next(172);
				featureIds.Add((short)featureId);
			}
			character.SetFeatureIds(featureIds, context);
			characters[i] = character;
			DomainManager.Character.CompleteCreatingCharacter(character.GetId());
		}
		return characters;
	}

	private static void RunTestGetCacheData_SingleThread(DataContext context, GameData.Domains.Character.Character[] characters)
	{
		Stopwatch sw = Stopwatch.StartNew();
		RunTestGetCacheData_GetCacheData(characters, 0, characters.Length);
		sw.Stop();
		Logger.Info($"Calc cache data: {sw.Elapsed.TotalMilliseconds:N1}");
		sw.Restart();
		RunTestGetCacheData_GetCacheData(characters, 0, characters.Length);
		sw.Stop();
		Logger.Info($"Get cached data: {sw.Elapsed.TotalMilliseconds:N1}");
		sw.Restart();
		RunTestGetCacheData_InvalidCache(context, characters);
		sw.Stop();
		Logger.Info($"Invalid cache: {sw.Elapsed.TotalMilliseconds:N1}");
		sw.Restart();
		RunTestGetCacheData_GetCacheData(characters, 0, characters.Length);
		sw.Stop();
		Logger.Info($"Re-calc cache data: {sw.Elapsed.TotalMilliseconds:N1}");
		sw.Restart();
		RunTestGetCacheData_GetCacheData(characters, 0, characters.Length);
		sw.Stop();
		Logger.Info($"Re-get cache data: {sw.Elapsed.TotalMilliseconds:N1}");
	}

	private static void RunTestGetCacheData_GetCacheData(GameData.Domains.Character.Character[] characters, int indexBegin, int indexEnd)
	{
		for (int i = indexBegin; i < indexEnd; i++)
		{
			GameData.Domains.Character.Character character = characters[i];
			character.GetMaxMainAttributes();
			character.GetHitValues();
			character.GetPenetrations();
			character.GetAvoidValues();
			character.GetPenetrationResists();
			character.GetLifeSkillQualifications();
			character.GetCombatSkillQualifications();
			character.GetLifeSkillAttainments();
			character.GetCombatSkillAttainments();
		}
	}

	private static void RunTestGetCacheData_GetCacheData(GameData.Domains.Character.Character character)
	{
		character.GetMaxMainAttributes();
		character.GetHitValues();
		character.GetPenetrations();
		character.GetAvoidValues();
		character.GetPenetrationResists();
		character.GetLifeSkillQualifications();
		character.GetCombatSkillQualifications();
		character.GetLifeSkillAttainments();
		character.GetCombatSkillAttainments();
	}

	private static void RunTestGetCacheData_InvalidCache(DataContext context, GameData.Domains.Character.Character[] characters)
	{
		int i = 0;
		for (int charactersCount = characters.Length; i < charactersCount; i++)
		{
			GameData.Domains.Character.Character character = characters[i];
			List<short> featureIds = character.GetFeatureIds();
			character.SetFeatureIds(featureIds, context);
		}
	}

	private static void RunTestGetCacheData_MultiThreads(DataContext context, GameData.Domains.Character.Character[] characters)
	{
		Action<GameData.Domains.Character.Character> getCacheDataAction = RunTestGetCacheData_GetCacheData;
		Stopwatch sw = Stopwatch.StartNew();
		Parallel.ForEach(characters, getCacheDataAction);
		sw.Stop();
		Logger.Info($"Calc cache data: {sw.Elapsed.TotalMilliseconds:N1}");
		sw.Restart();
		Parallel.ForEach(characters, getCacheDataAction);
		sw.Stop();
		Logger.Info($"Get cached data: {sw.Elapsed.TotalMilliseconds:N1}");
		sw.Restart();
		RunTestGetCacheData_InvalidCache(context, characters);
		sw.Stop();
		Logger.Info($"Invalid cache: {sw.Elapsed.TotalMilliseconds:N1}");
		sw.Restart();
		Parallel.ForEach(characters, getCacheDataAction);
		sw.Stop();
		Logger.Info($"Re-calc cache data: {sw.Elapsed.TotalMilliseconds:N1}");
		sw.Restart();
		Parallel.ForEach(characters, getCacheDataAction);
		sw.Stop();
		Logger.Info($"Re-get cache data: {sw.Elapsed.TotalMilliseconds:N1}");
	}

	public void RunTestCompileDll()
	{
	}

	public static void RunTestRandomGenerators()
	{
		Random systemRandomSource = new Random();
		IRandomSource redzenDefaultRandomSource = RandomDefaults.CreateRandomSource();
		IRandomSource redzenFloatRandomSource = new Xoshiro256PlusRandomFactory().Create();
		Stopwatch sw = new Stopwatch();
		int[] samples = new int[10000000];
		sw.Restart();
		for (int i = 0; i < 10000000; i++)
		{
			samples[i] = RedzenHelper.NormalDistribute(redzenDefaultRandomSource, 0f, 1f, 0, 2);
		}
		RunTestRandomGenerators_ShowHistogram(sw, samples, "", 0, 3, 4);
		sw.Stop();
	}

	private static void RunTestRandomGenerators_ShowHistogram(Stopwatch sw, int[] samples, string label, int min = 0, int max = 100, int bins = 10)
	{
		sw.Stop();
		Logger.Info($"{label}: {sw.Elapsed.TotalMilliseconds:N1}");
		Histogram histogram = new Histogram(min, max, bins);
		histogram.Record(samples);
		Logger.Info("Histogram:\n" + histogram.GetTextGraph());
		sw.Restart();
	}

	public static void RunTestSkewDistribute()
	{
		int[] samples = new int[10000];
		IRandomSource redzenDefaultRandomSource = RandomDefaults.CreateRandomSource();
		for (int i = 0; i < 10000; i++)
		{
			samples[i] = RedzenHelper.SkewDistribute(redzenDefaultRandomSource, 6f, 1.5f, 2f, 2, 12);
		}
		Stopwatch sw = new Stopwatch();
		RunTestRandomGenerators_ShowHistogram(sw, samples, "", 0, 13, 13);
	}

	public static void RunTestNormalDistribute()
	{
		int[] samples = new int[10000];
		IRandomSource redzenDefaultRandomSource = RandomDefaults.CreateRandomSource();
		for (int i = 0; i < 10000; i++)
		{
			samples[i] = RedzenHelper.NormalDistribute(redzenDefaultRandomSource, 4f, 1.2f);
		}
		Stopwatch sw = new Stopwatch();
		RunTestRandomGenerators_ShowHistogram(sw, samples, "", 0, 13, 13);
	}

	public static void RunTestAvatarGenerating(DataContext context)
	{
		Stopwatch sw = new Stopwatch();
		IRandomSource random = context.Random;
		int[] samples = new int[1000000];
		AvatarManager.Instance = new AvatarManager();
		sw.Restart();
		for (int i = 0; i < 1000000; i++)
		{
			short attraction = (short)random.Next(0, 901);
			AvatarData avatar = AvatarManager.Instance.GetRandomAvatar(random, Gender.GetRandom(random), transgender: false, BodyType.GetRandom(random), attraction);
			short newAttraction = avatar.GetBaseCharm();
			int delta = newAttraction - attraction;
			samples[i] = delta;
		}
		sw.Stop();
		Logger.Info($"{sw.Elapsed.TotalMilliseconds:N1}");
		Histogram histogram = new Histogram(-5, 5, 11);
		histogram.Record(samples);
		Logger.Info("Histogram:\n" + histogram.GetTextGraph());
		Histogram histogram2 = new Histogram(-50, 50, 20);
		histogram2.Record(samples);
		Logger.Info("Histogram:\n" + histogram2.GetTextGraph());
		Histogram histogram3 = new Histogram(-200, 200, 20);
		histogram3.Record(samples);
		Logger.Info("Histogram:\n" + histogram3.GetTextGraph());
	}

	public static void RunTestCharacterQualificationGenerating(DataContext context)
	{
		int[][] samples = new int[2][]
		{
			new int[1000],
			new int[1000]
		};
		Stopwatch sw = Stopwatch.StartNew();
		for (int i = 0; i < 1000; i++)
		{
			short qualification0 = CreateIntelligentCharacterAndGetQualification(context, 6, 11, 8, 4);
			short qualification1 = CreateIntelligentCharacterAndGetQualification(context, 7, 13, 8, 4);
			samples[0][i] = qualification0;
			samples[1][i] = qualification1;
		}
		sw.Stop();
		Logger.Info($"{sw.Elapsed.TotalMilliseconds:N1}");
		Histogram histogram = new Histogram(0, 120, 20);
		histogram.Record(samples[0]);
		Logger.Info("Histogram:\n" + histogram.GetTextGraph());
		Histogram histogram2 = new Histogram(0, 120, 20);
		histogram2.Record(samples[1]);
		Logger.Info("Histogram:\n" + histogram2.GetTextGraph());
	}

	private unsafe static short CreateIntelligentCharacterAndGetQualification(DataContext context, sbyte orgTemplateId, short charTemplateId, sbyte grade, sbyte lifeSkillType)
	{
		IntelligentCharacterCreationInfo info = new IntelligentCharacterCreationInfo(Location.Invalid, new OrganizationInfo(orgTemplateId, grade, principal: true, -1), charTemplateId);
		GameData.Domains.Character.Character character = DomainManager.Character.CreateIntelligentCharacter(context, ref info);
		DomainManager.Character.CompleteCreatingCharacter(character.GetId());
		return character.GetLifeSkillQualifications().Items[lifeSkillType];
	}

	public static void RunTestCharacterCombatSkillEquipping(DataContext context)
	{
		double[] learnedSkillsCounts = new double[9];
		double[] equippedSkillsCounts = new double[9];
		Stopwatch sw = Stopwatch.StartNew();
		for (int i = 0; i < 1000; i++)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.CreateRandomEnemy(context, 374, isTemporary: true);
			int charId = character.GetId();
			DomainManager.Character.CompleteCreatingCharacter(charId);
			List<short> learnedCombatSkills = character.GetLearnedCombatSkills();
			foreach (short skillTemplateId in learnedCombatSkills)
			{
				CombatSkillItem config = Config.CombatSkill.Instance[skillTemplateId];
				learnedSkillsCounts[config.Grade] += 1.0;
			}
			CombatSkillEquipment combatSkillEquipment = character.GetCombatSkillEquipment();
			foreach (short skillTemplateId2 in combatSkillEquipment)
			{
				if (skillTemplateId2 >= 0)
				{
					CombatSkillItem config2 = Config.CombatSkill.Instance[skillTemplateId2];
					equippedSkillsCounts[config2.Grade] += 1.0;
				}
			}
		}
		sw.Stop();
		Logger.Info($"{sw.Elapsed.TotalMilliseconds:N1}");
		for (int j = 0; j < 9; j++)
		{
			learnedSkillsCounts[j] /= 1000.0;
			equippedSkillsCounts[j] /= 1000.0;
		}
		Logger.Info("Learned skills:" + $"  {learnedSkillsCounts[0]:N1}, {learnedSkillsCounts[1]:N1}, {learnedSkillsCounts[2]:N1};" + $"  {learnedSkillsCounts[3]:N1}, {learnedSkillsCounts[4]:N1}, {learnedSkillsCounts[5]:N1};" + $"  {learnedSkillsCounts[6]:N1}, {learnedSkillsCounts[7]:N1}, {learnedSkillsCounts[8]:N1};");
		Logger.Info("Equipped skills:" + $"  {equippedSkillsCounts[0]:N1}, {equippedSkillsCounts[1]:N1}, {equippedSkillsCounts[2]:N1};" + $"  {equippedSkillsCounts[3]:N1}, {equippedSkillsCounts[4]:N1}, {equippedSkillsCounts[5]:N1};" + $"  {equippedSkillsCounts[6]:N1}, {equippedSkillsCounts[7]:N1}, {equippedSkillsCounts[8]:N1};");
	}

	public static void RunTestNameGenerating(DataContext context)
	{
		IRandomSource random = context.Random;
		int itemsCount = LocalSurnames.Instance.SurnameCore.Length;
		int totalWeight = 0;
		for (int i = 0; i < itemsCount; i++)
		{
			SurnameItem item = LocalSurnames.Instance.SurnameCore[i];
			if (item != null)
			{
				totalWeight += item.Prob;
			}
		}
		double unitWeight = 1.0 / (double)totalWeight;
		int[] surnamesCounts = new int[itemsCount];
		Stopwatch sw = Stopwatch.StartNew();
		for (int j = 0; j < 1000000; j++)
		{
			sbyte gender = (sbyte)(j % 2);
			short surnameId = CharacterDomain.GenerateRandomHanName(random, -1, -1, gender, -1).SurnameId;
			surnamesCounts[surnameId]++;
		}
		sw.Stop();
		Logger.Info($"{sw.Elapsed.TotalMilliseconds:N1}");
		StringBuilder message = new StringBuilder("Ratios:\n");
		for (int k = 0; k < itemsCount; k++)
		{
			SurnameItem item2 = LocalSurnames.Instance.SurnameCore[k];
			if (item2 != null)
			{
				double idealProb = (double)item2.Prob * unitWeight;
				double realProb = (double)surnamesCounts[k] / 1000000.0;
				double ratio = realProb / idealProb;
				StringBuilder stringBuilder = message;
				StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(2, 2, stringBuilder);
				handler.AppendFormatted(item2.Surname);
				handler.AppendLiteral(": ");
				handler.AppendFormatted(ratio, "N3");
				stringBuilder.AppendLine(ref handler);
				if (!(ratio >= 0.9) || !(ratio <= 1.1))
				{
					Logger.Warn($"{item2.Surname}: {ratio:N3}");
				}
			}
			else
			{
				Tester.Assert(surnamesCounts[k] == 0);
			}
		}
		Logger.Info(message);
	}

	public void SetAchievement(DataContext context, short achievementId)
	{
		long timeStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
		if (!_achievements.ContainsKey(achievementId))
		{
			DomainManager.Taiwu.RecordAchievement(context, achievementId);
			AddElement_Achievements(achievementId, timeStamp, context);
		}
		else
		{
			SetElement_Achievements(achievementId, timeStamp, context);
		}
	}

	public bool GetAchievement(short achievementId)
	{
		return _achievements.ContainsKey(achievementId);
	}

	[DomainMethod]
	public AchievementDisplayData GetAchievementDisplayData()
	{
		return new AchievementDisplayData
		{
			LastTimeOpen = _lastTimeOpenAchievements,
			Achievements = _achievements
		};
	}

	[DomainMethod]
	public void SetLastTimeOpenAchievements(DataContext context)
	{
		long timeStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
		_lastTimeOpenAchievements = timeStamp;
	}

	public void SetStat(DataContext context, short statId, GameStatRecordWrapper value)
	{
		if (!_gameStats.ContainsKey(statId))
		{
			AddElement_GameStats(statId, value, context);
		}
		else
		{
			SetElement_GameStats(statId, value, context);
		}
	}

	public int GetStat(short statId)
	{
		GameStatRecordWrapper wrapper;
		return _gameStats.TryGetValue(statId, out wrapper) ? wrapper.GetStat() : 0;
	}

	public GameStatRecordWrapper GetStatWrapper(short statId)
	{
		GameStatRecordWrapper wrapper;
		return _gameStats.TryGetValue(statId, out wrapper) ? wrapper : new GameStatRecordWrapper(statId);
	}

	public void ClearAllStat(DataContext context)
	{
		ClearGameStats(context);
		ClearAchievements(context);
	}

	public GlobalDomain()
		: base(12)
	{
		_global = 0;
		_loadedAllArchiveData = false;
		_savingWorld = false;
		_inscribedCharacters = new Dictionary<InscribedCharacterKey, InscribedCharacter>(0);
		_globalFlags = 0uL;
		_ownedChickens = new List<short>();
		_currGameWorldType = 0;
		_inscribedCharacterPinOrders = new Dictionary<InscribedCharacterKey, int>(0);
		_achievements = new Dictionary<short, long>(0);
		_gameStats = new Dictionary<short, GameStatRecordWrapper>(0);
		_customProtagonistPreset = new CustomProtagonistPreset();
		_lastTimeOpenAchievements = 0L;
		OnInitializedDomainData();
	}

	private int GetGlobal()
	{
		return _global;
	}

	private void SetGlobal(int value, DataContext context)
	{
		_global = value;
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	public bool GetLoadedAllArchiveData()
	{
		return _loadedAllArchiveData;
	}

	private void SetLoadedAllArchiveData(bool value, DataContext context)
	{
		_loadedAllArchiveData = value;
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	public bool GetSavingWorld()
	{
		return _savingWorld;
	}

	private void SetSavingWorld(bool value, DataContext context)
	{
		_savingWorld = value;
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	public InscribedCharacter GetElement_InscribedCharacters(InscribedCharacterKey elementId)
	{
		return _inscribedCharacters[elementId];
	}

	public bool TryGetElement_InscribedCharacters(InscribedCharacterKey elementId, out InscribedCharacter value)
	{
		return _inscribedCharacters.TryGetValue(elementId, out value);
	}

	private void AddElement_InscribedCharacters(InscribedCharacterKey elementId, InscribedCharacter value, DataContext context)
	{
		_inscribedCharacters.Add(elementId, value);
		_modificationsInscribedCharacters.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void SetElement_InscribedCharacters(InscribedCharacterKey elementId, InscribedCharacter value, DataContext context)
	{
		_inscribedCharacters[elementId] = value;
		_modificationsInscribedCharacters.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_InscribedCharacters(InscribedCharacterKey elementId, DataContext context)
	{
		_inscribedCharacters.Remove(elementId);
		_modificationsInscribedCharacters.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void ClearInscribedCharacters(DataContext context)
	{
		_inscribedCharacters.Clear();
		_modificationsInscribedCharacters.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	public ulong GetGlobalFlags()
	{
		return _globalFlags;
	}

	public void SetGlobalFlags(ulong value, DataContext context)
	{
		_globalFlags = value;
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	public List<short> GetOwnedChickens()
	{
		return _ownedChickens;
	}

	public void SetOwnedChickens(List<short> value, DataContext context)
	{
		_ownedChickens = value;
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	public sbyte GetCurrGameWorldType()
	{
		return _currGameWorldType;
	}

	private void SetCurrGameWorldType(sbyte value, DataContext context)
	{
		_currGameWorldType = value;
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	public int GetElement_InscribedCharacterPinOrders(InscribedCharacterKey elementId)
	{
		return _inscribedCharacterPinOrders[elementId];
	}

	public bool TryGetElement_InscribedCharacterPinOrders(InscribedCharacterKey elementId, out int value)
	{
		return _inscribedCharacterPinOrders.TryGetValue(elementId, out value);
	}

	private void AddElement_InscribedCharacterPinOrders(InscribedCharacterKey elementId, int value, DataContext context)
	{
		_inscribedCharacterPinOrders.Add(elementId, value);
		_modificationsInscribedCharacterPinOrders.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void SetElement_InscribedCharacterPinOrders(InscribedCharacterKey elementId, int value, DataContext context)
	{
		_inscribedCharacterPinOrders[elementId] = value;
		_modificationsInscribedCharacterPinOrders.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_InscribedCharacterPinOrders(InscribedCharacterKey elementId, DataContext context)
	{
		_inscribedCharacterPinOrders.Remove(elementId);
		_modificationsInscribedCharacterPinOrders.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void ClearInscribedCharacterPinOrders(DataContext context)
	{
		_inscribedCharacterPinOrders.Clear();
		_modificationsInscribedCharacterPinOrders.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	public long GetElement_Achievements(short elementId)
	{
		return _achievements[elementId];
	}

	public bool TryGetElement_Achievements(short elementId, out long value)
	{
		return _achievements.TryGetValue(elementId, out value);
	}

	private void AddElement_Achievements(short elementId, long value, DataContext context)
	{
		_achievements.Add(elementId, value);
		_modificationsAchievements.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private void SetElement_Achievements(short elementId, long value, DataContext context)
	{
		_achievements[elementId] = value;
		_modificationsAchievements.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_Achievements(short elementId, DataContext context)
	{
		_achievements.Remove(elementId);
		_modificationsAchievements.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private void ClearAchievements(DataContext context)
	{
		_achievements.Clear();
		_modificationsAchievements.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	public GameStatRecordWrapper GetElement_GameStats(short elementId)
	{
		return _gameStats[elementId];
	}

	public bool TryGetElement_GameStats(short elementId, out GameStatRecordWrapper value)
	{
		return _gameStats.TryGetValue(elementId, out value);
	}

	private void AddElement_GameStats(short elementId, GameStatRecordWrapper value, DataContext context)
	{
		_gameStats.Add(elementId, value);
		_modificationsGameStats.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void SetElement_GameStats(short elementId, GameStatRecordWrapper value, DataContext context)
	{
		_gameStats[elementId] = value;
		_modificationsGameStats.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_GameStats(short elementId, DataContext context)
	{
		_gameStats.Remove(elementId);
		_modificationsGameStats.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void ClearGameStats(DataContext context)
	{
		_gameStats.Clear();
		_modificationsGameStats.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	public CustomProtagonistPreset GetCustomProtagonistPreset()
	{
		return _customProtagonistPreset;
	}

	public void SetCustomProtagonistPreset(CustomProtagonistPreset value, DataContext context)
	{
		_customProtagonistPreset = value;
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	public long GetLastTimeOpenAchievements()
	{
		return _lastTimeOpenAchievements;
	}

	public void SetLastTimeOpenAchievements(long value, DataContext context)
	{
		_lastTimeOpenAchievements = value;
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	public override void OnInitializeGameDataModule()
	{
		InitializeOnInitializeGameDataModule();
	}

	public override void OnEnterNewWorld()
	{
		InitializeOnEnterNewWorld();
		InitializeInternalDataOfCollections();
	}

	public override void OnSaveWorld(ArchiveFileBase archive)
	{
		archive.WriteSingleValueUnmanaged((ushort)8);
		archive.WriteDomainDataMeta(3);
		archive.WriteSingleValueCollectionCustomKeyValue(_inscribedCharacters);
		archive.WriteDomainDataMeta(4);
		archive.WriteSingleValueUnmanaged(_globalFlags);
		archive.WriteDomainDataMeta(5);
		archive.WriteSingleValueUnmanagedList(_ownedChickens);
		archive.WriteDomainDataMeta(7);
		archive.WriteSingleValueCollectionCustomKeyUnmanagedValue(_inscribedCharacterPinOrders);
		archive.WriteDomainDataMeta(8);
		archive.WriteSingleValueCollectionUnmanagedKeyValue(_achievements);
		archive.WriteDomainDataMeta(9);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_gameStats);
		archive.WriteDomainDataMeta(10);
		archive.WriteSingleValueCustom(_customProtagonistPreset);
		archive.WriteDomainDataMeta(11);
		archive.WriteSingleValueUnmanaged(_lastTimeOpenAchievements);
	}

	public override void OnLoadWorld(ArchiveFileBase archive)
	{
		ushort savedFieldCount = 0;
		archive.ReadSingleValueUnmanaged(ref savedFieldCount);
		for (int domainDataIndex = 0; domainDataIndex < savedFieldCount; domainDataIndex++)
		{
			DomainDataMeta domainDataMeta = archive.ReadDomainDataMeta();
			switch (domainDataMeta.DataId)
			{
			case 3:
				archive.ReadSingleValueCollectionCustomKeyValue(_inscribedCharacters);
				break;
			case 4:
				archive.ReadSingleValueUnmanaged(ref _globalFlags);
				break;
			case 5:
				archive.ReadSingleValueUnmanagedList(ref _ownedChickens);
				break;
			case 7:
				archive.ReadSingleValueCollectionCustomKeyUnmanagedValue(_inscribedCharacterPinOrders);
				break;
			case 8:
				archive.ReadSingleValueCollectionUnmanagedKeyValue(_achievements);
				break;
			case 9:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_gameStats);
				break;
			case 10:
				archive.ReadSingleValueCustom(ref _customProtagonistPreset);
				break;
			case 11:
				archive.ReadSingleValueUnmanaged(ref _lastTimeOpenAchievements);
				break;
			default:
				throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
			}
			RecordLoadedDomainData(domainDataMeta.DataId);
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(0);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 1:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
			}
			return GameData.Serializer.Serializer.Serialize(_loadedAllArchiveData, dataPool);
		case 2:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
			}
			return GameData.Serializer.Serializer.Serialize(_savingWorld, dataPool);
		case 3:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
				_modificationsInscribedCharacters.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_inscribedCharacters, dataPool);
		case 4:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
			}
			return GameData.Serializer.Serializer.Serialize(_globalFlags, dataPool);
		case 5:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
			}
			return GameData.Serializer.Serializer.Serialize(_ownedChickens, dataPool);
		case 6:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 6);
			}
			return GameData.Serializer.Serializer.Serialize(_currGameWorldType, dataPool);
		case 7:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
				_modificationsInscribedCharacterPinOrders.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_inscribedCharacterPinOrders, dataPool);
		case 8:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
				_modificationsAchievements.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_achievements, dataPool);
		case 9:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
				_modificationsGameStats.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_gameStats, dataPool);
		case 10:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 10);
			}
			return GameData.Serializer.Serializer.Serialize(_customProtagonistPreset, dataPool);
		case 11:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
			}
			return GameData.Serializer.Serializer.Serialize(_lastTimeOpenAchievements, dataPool);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void SetData(ushort dataId, ulong subId0, uint subId1, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 1:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 2:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 3:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 4:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _globalFlags);
			SetGlobalFlags(_globalFlags, context);
			break;
		case 5:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _ownedChickens);
			SetOwnedChickens(_ownedChickens, context);
			break;
		case 6:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 7:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 8:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 9:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 10:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _customProtagonistPreset);
			SetCustomProtagonistPreset(_customProtagonistPreset, context);
			break;
		case 11:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _lastTimeOpenAchievements);
			SetLastTimeOpenAchievements(_lastTimeOpenAchievements, context);
			break;
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override int CallMethod(Operation operation, RawDataPool argDataPool, RawDataPool returnDataPool, DataContext context)
	{
		int argsOffset = operation.ArgsOffset;
		switch (operation.MethodId)
		{
		case 0:
		{
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 1)
			{
				sbyte archiveId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref archiveId3);
				EnterNewWorld(archiveId3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 2)
			{
				sbyte archiveId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref archiveId);
				long backupTimestamp = 0L;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref backupTimestamp);
				LoadWorld(archiveId, backupTimestamp);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 1)
			{
				sbyte archiveId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref archiveId4);
				LoadEnding(archiveId4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 3:
			if (operation.ArgsCount == 0)
			{
				SaveWorld(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 4:
			if (operation.ArgsCount == 0)
			{
				LeaveWorld();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 5:
			if (operation.ArgsCount == 0)
			{
				uint operationId = GameData.GameDataBridge.GameDataBridge.RecordPassthroughMethod(operation);
				GetArchivesInfo(operationId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 6:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 1)
			{
				sbyte archiveId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref archiveId2);
				DeleteArchive(archiveId2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 7:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 1)
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				InscribeCharacter(context, charId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 8:
		{
			int argsCount14 = operation.ArgsCount;
			int num14 = argsCount14;
			if (num14 == 1)
			{
				InscribedCharacterKey key3 = default(InscribedCharacterKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key3);
				RemoveInscribedCharacter(context, key3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 9:
		{
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 2)
			{
				string gameVersion = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref gameVersion);
				string gameBuildDate = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref gameBuildDate);
				SetGameBuildInfo(gameVersion, gameBuildDate);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 10:
			if (operation.ArgsCount == 0)
			{
				PackAllCrossArchiveGameData();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 11:
		{
			int argsCount17 = operation.ArgsCount;
			int num17 = argsCount17;
			if (num17 == 2)
			{
				sbyte flagType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref flagType2);
				bool value = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value);
				SetGlobalFlag(context, flagType2, value);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
		{
			int argsCount15 = operation.ArgsCount;
			int num15 = argsCount15;
			if (num15 == 1)
			{
				sbyte flagType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref flagType);
				bool returnValue5 = GetGlobalFlag(flagType);
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 13:
			if (operation.ArgsCount == 0)
			{
				bool returnValue4 = CheckDriveSpace(context);
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 14:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 1)
			{
				SharedGlobalSettings settings = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settings);
				bool returnValue3 = UpdateSharedGlobalSettings(settings);
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 15:
			if (operation.ArgsCount == 0)
			{
				bool returnValue2 = ReloadAllConfigData();
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 16:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 1)
			{
				byte compressionType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref compressionType);
				SetCompressionType(compressionType);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 17:
		{
			int argsCount16 = operation.ArgsCount;
			int num16 = argsCount16;
			if (num16 == 1)
			{
				short templateId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId3);
				EnterInGameGuideWorld(context, templateId3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 18:
			if (operation.ArgsCount == 0)
			{
				ExitInGameGuideWorld(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 19:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 1)
			{
				short templateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId2);
				EnterTutorialWorld(context, templateId2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 20:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 2)
			{
				InscribedCharacterKey key2 = default(InscribedCharacterKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key2);
				int order = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref order);
				SetInscribedCharacterPinOrder(context, key2, order);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 21:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 1)
			{
				InscribedCharacterKey key = default(InscribedCharacterKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key);
				RemoveInscribedCharacterPinOrder(context, key);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 22:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 1)
			{
				CustomProtagonistPreset customProtagonistPreset = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref customProtagonistPreset);
				SetCustomProtagonistPreset(context, customProtagonistPreset);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 23:
			if (operation.ArgsCount == 0)
			{
				AchievementDisplayData returnValue = GetAchievementDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 24:
			if (operation.ArgsCount == 0)
			{
				SetLastTimeOpenAchievements(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 25:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 1)
			{
				short templateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId);
				InvokeGuidingTrigger(context, templateId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		default:
			throw new Exception($"Unsupported methodId {operation.MethodId}");
		}
	}

	public override void OnMonitorData(ushort dataId, ulong subId0, uint subId1, bool monitoring)
	{
		switch (dataId)
		{
		case 0:
			break;
		case 1:
			break;
		case 2:
			break;
		case 3:
			_modificationsInscribedCharacters.ChangeRecording(monitoring);
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			break;
		case 7:
			_modificationsInscribedCharacterPinOrders.ChangeRecording(monitoring);
			break;
		case 8:
			_modificationsAchievements.ChangeRecording(monitoring);
			break;
		case 9:
			_modificationsGameStats.ChangeRecording(monitoring);
			break;
		case 10:
			break;
		case 11:
			break;
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override int CheckModified(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 1:
			if (!BaseGameDataDomain.IsModified(DataStates, 1))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 1);
			return GameData.Serializer.Serializer.Serialize(_loadedAllArchiveData, dataPool);
		case 2:
			if (!BaseGameDataDomain.IsModified(DataStates, 2))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 2);
			return GameData.Serializer.Serializer.Serialize(_savingWorld, dataPool);
		case 3:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 3))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 3);
			int offset4 = GameData.Serializer.Serializer.SerializeModifications(_inscribedCharacters, dataPool, _modificationsInscribedCharacters);
			_modificationsInscribedCharacters.Reset();
			return offset4;
		}
		case 4:
			if (!BaseGameDataDomain.IsModified(DataStates, 4))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 4);
			return GameData.Serializer.Serializer.Serialize(_globalFlags, dataPool);
		case 5:
			if (!BaseGameDataDomain.IsModified(DataStates, 5))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 5);
			return GameData.Serializer.Serializer.Serialize(_ownedChickens, dataPool);
		case 6:
			if (!BaseGameDataDomain.IsModified(DataStates, 6))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 6);
			return GameData.Serializer.Serializer.Serialize(_currGameWorldType, dataPool);
		case 7:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 7))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 7);
			int offset = GameData.Serializer.Serializer.SerializeModifications(_inscribedCharacterPinOrders, dataPool, _modificationsInscribedCharacterPinOrders);
			_modificationsInscribedCharacterPinOrders.Reset();
			return offset;
		}
		case 8:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 8))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 8);
			int offset3 = GameData.Serializer.Serializer.SerializeModifications(_achievements, dataPool, _modificationsAchievements);
			_modificationsAchievements.Reset();
			return offset3;
		}
		case 9:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 9))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 9);
			int offset2 = GameData.Serializer.Serializer.SerializeModifications(_gameStats, dataPool, _modificationsGameStats);
			_modificationsGameStats.Reset();
			return offset2;
		}
		case 10:
			if (!BaseGameDataDomain.IsModified(DataStates, 10))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 10);
			return GameData.Serializer.Serializer.Serialize(_customProtagonistPreset, dataPool);
		case 11:
			if (!BaseGameDataDomain.IsModified(DataStates, 11))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 11);
			return GameData.Serializer.Serializer.Serialize(_lastTimeOpenAchievements, dataPool);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void ResetModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 1:
			if (BaseGameDataDomain.IsModified(DataStates, 1))
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
			}
			break;
		case 2:
			if (BaseGameDataDomain.IsModified(DataStates, 2))
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
			}
			break;
		case 3:
			if (BaseGameDataDomain.IsModified(DataStates, 3))
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
				_modificationsInscribedCharacters.Reset();
			}
			break;
		case 4:
			if (BaseGameDataDomain.IsModified(DataStates, 4))
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
			}
			break;
		case 5:
			if (BaseGameDataDomain.IsModified(DataStates, 5))
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
			}
			break;
		case 6:
			if (BaseGameDataDomain.IsModified(DataStates, 6))
			{
				BaseGameDataDomain.ResetModified(DataStates, 6);
			}
			break;
		case 7:
			if (BaseGameDataDomain.IsModified(DataStates, 7))
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
				_modificationsInscribedCharacterPinOrders.Reset();
			}
			break;
		case 8:
			if (BaseGameDataDomain.IsModified(DataStates, 8))
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
				_modificationsAchievements.Reset();
			}
			break;
		case 9:
			if (BaseGameDataDomain.IsModified(DataStates, 9))
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
				_modificationsGameStats.Reset();
			}
			break;
		case 10:
			if (BaseGameDataDomain.IsModified(DataStates, 10))
			{
				BaseGameDataDomain.ResetModified(DataStates, 10);
			}
			break;
		case 11:
			if (BaseGameDataDomain.IsModified(DataStates, 11))
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
			}
			break;
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override bool IsModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		return dataId switch
		{
			0 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			1 => BaseGameDataDomain.IsModified(DataStates, 1), 
			2 => BaseGameDataDomain.IsModified(DataStates, 2), 
			3 => BaseGameDataDomain.IsModified(DataStates, 3), 
			4 => BaseGameDataDomain.IsModified(DataStates, 4), 
			5 => BaseGameDataDomain.IsModified(DataStates, 5), 
			6 => BaseGameDataDomain.IsModified(DataStates, 6), 
			7 => BaseGameDataDomain.IsModified(DataStates, 7), 
			8 => BaseGameDataDomain.IsModified(DataStates, 8), 
			9 => BaseGameDataDomain.IsModified(DataStates, 9), 
			10 => BaseGameDataDomain.IsModified(DataStates, 10), 
			11 => BaseGameDataDomain.IsModified(DataStates, 11), 
			_ => throw new Exception($"Unsupported dataId {dataId}"), 
		};
	}

	public override void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll)
	{
		switch (influence.TargetIndicator.DataId)
		{
		default:
			throw new Exception($"Unsupported dataId {influence.TargetIndicator.DataId}");
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
	}
}
