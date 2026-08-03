using System;
using System.Collections.Generic;
using System.Threading;
using Config;
using Config.ConfigCells.Character;
using GameData.ArchiveData;
using GameData.Common;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.Map;
using GameData.Domains.World;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TutorialChapter;

[GameDataDomain(15)]
public class TutorialChapterDomain : BaseGameDataDomain
{
	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private int _curProgress;

	private Dictionary<string, int> _fixedCharacters;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private short _tutorialChapter = -1;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private string _guidVideoName = string.Empty;

	[DomainData(DomainDataType.SingleValue, false, false, true, true, DefaultValue = "-1")]
	private short _guidVideoTemplateId;

	[DomainData(DomainDataType.SingleValue, false, true, true, true, DefaultValue = "GameData.Domains.Map.Location.Invalid")]
	private Location _nextForceLocation = Location.Invalid;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _neiliAllocateFitChapter7;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _huanxinDying;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _huanxinSurprised;

	[DomainData(DomainDataType.SingleValue, false, false, true, true, DefaultValue = "-1")]
	private int _forcePathIndex;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private BoolArray _tutorialFunctionStatuses;

	public sbyte Counter;

	public sbyte CounterTarget;

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[10][];

	private SpinLock _spinLockNextForceLocation = new SpinLock(enableThreadOwnerTracking: false);

	private Queue<uint> _pendingLoadingOperationIds;

	public byte TutorialAreaSize { get; private set; } = 20;

	public bool InGuiding => DomainManager.Global.GetCurrGameWorldType() == 2;

	public int CreateFixedWorld(DataContext context, short templateId, WorldCreationInfo info)
	{
		TutorialChaptersItem config = TutorialChapters.Instance.GetItem(templateId);
		DomainManager.World.SetWorldCreationInfo(context, info, inherit: false);
		DomainManager.Map.CreateFixedTutorialArea(context);
		TutorialAreaSize = 20;
		if (templateId == 0)
		{
			Location locationA = GetTutorialLocationByCoordinate(9, 9);
			MapBlockData blockData = DomainManager.Map.GetBlock(locationA);
			blockData.TemplateId = 103;
			blockData.InitResources(context.Random);
			DomainManager.Map.GetBlock(locationA).InitResources(context.Random);
		}
		if (templateId >= 1)
		{
			MapAreaData tutorialAreaData = DomainManager.Map.GetElement_Areas(136);
			SettlementInfo settlementInfo = tutorialAreaData.SettlementInfos[0];
			DomainManager.Taiwu.TryAddVisitedSettlement(settlementInfo.SettlementId, context);
		}
		GameData.Domains.Character.Character huanxin = DomainManager.Character.CreateFixedCharacter(context, 908);
		int huanxinId = huanxin.GetId();
		DomainManager.Character.CompleteCreatingCharacter(huanxinId);
		GameData.Domains.Character.Character taiwu = huanxin;
		int taiwuId = huanxinId;
		List<PresetInventoryItem> presetInventory = config.PresetInventory;
		if (presetInventory != null && presetInventory.Count > 0)
		{
			foreach (PresetInventoryItem presetItem in config.PresetInventory)
			{
				taiwu.CreateInventoryItem(context, presetItem.Type, presetItem.TemplateId, presetItem.Amount);
			}
		}
		GameData.Domains.Character.Character father = DomainManager.Character.CreateFixedCharacter(context, 880);
		int fatherId = father.GetId();
		if (!RelationTypeHelper.AllowAddingAdoptiveParentRelation(huanxinId, fatherId))
		{
			throw new Exception($"Failed to add adoptive parent relation: {huanxinId} - {fatherId}");
		}
		DomainManager.Character.AddRelation(context, huanxinId, fatherId, 64);
		DomainManager.Character.DirectlySetFavorabilities(context, huanxinId, fatherId, 30000, 30000);
		DomainManager.Character.CompleteCreatingCharacter(fatherId);
		if (config.MainCharacter == father.GetTemplateId())
		{
			taiwu = father;
			taiwuId = fatherId;
		}
		DomainManager.Taiwu.SetTaiwu(context, taiwu);
		DomainManager.Taiwu.JoinGroup(context, taiwuId, showNotification: false);
		short areaId = 136;
		short blockId = ByteCoordinate.CoordinateToIndex(config.StartBlockCoordinate, TutorialAreaSize);
		Location location = new Location(areaId, blockId);
		taiwu.SetLocation(location, context);
		ByteCoordinate[] forcePath = config.ForcePath;
		_forcePathIndex = ((forcePath == null || forcePath.Length <= 0) ? (-1) : 0);
		SetForcePathIndex(_forcePathIndex, context);
		short[] openedFunctionTypes = config.OpenedFunctionTypes;
		if (openedFunctionTypes != null && openedFunctionTypes.Length > 0)
		{
			short[] openedFunctionTypes2 = config.OpenedFunctionTypes;
			foreach (short functionType in openedFunctionTypes2)
			{
				SetTutorialFunctionStatus(context, functionType, isOn: true);
			}
		}
		Events.RegisterHandler_TaiwuMove(OnTaiwuMove);
		DomainManager.Global.OnCurrWorldArchiveDataReady(context, isNewWorld: true);
		return taiwuId;
	}

	private void OnTaiwuMove(DataContext context, MapBlockData fromBlock, MapBlockData toBlock, int actionPointCost)
	{
		if (_forcePathIndex >= 0)
		{
			SetForcePathIndex(_forcePathIndex + 1, context);
		}
	}

	[DomainMethod]
	public void StartChapter(DataContext context, int chapter)
	{
		_curProgress = 0;
		SetTutorialChapter((short)chapter, context);
		DomainManager.TaiwuEvent.OnEvent_EnterTutorialChapter(_tutorialChapter);
	}

	[DomainMethod]
	public Location GetNextForceMoveToLocation()
	{
		return GetNextForceLocation();
	}

	public void SetTutorialFunctionStatus(DataContext context, short functionType, bool isOn)
	{
		_tutorialFunctionStatuses[functionType] = isOn;
		SetTutorialFunctionStatuses(_tutorialFunctionStatuses, context);
	}

	public void SetAllTutorialFunctionStatuses(DataContext context, bool isOn)
	{
		_tutorialFunctionStatuses.SetAll(isOn);
		SetTutorialFunctionStatuses(_tutorialFunctionStatuses, context);
	}

	public bool GetTutorialFunctionStatus(short functionType)
	{
		return _tutorialFunctionStatuses[functionType];
	}

	public void AdvanceProgress(DataContext context)
	{
	}

	public void SpecialAdvanceMonthInTutorial()
	{
		if (_tutorialChapter != 1)
		{
			return;
		}
		Location bambooLocation = GetTutorialLocationByCoordinate(9, 9);
		List<BuildingBlockData> list = DomainManager.Building.GetBuildingBlockList(bambooLocation);
		foreach (BuildingBlockData blockData in list)
		{
			if (blockData.OperationType == 0 && blockData.TemplateId == 258)
			{
				BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
				blockData.Durability = configData.MaxDurability;
			}
		}
	}

	public bool IsInTutorialChapter(int chapterIndex)
	{
		return InGuiding && GetTutorialChapter() == chapterIndex;
	}

	public static Location GetTutorialLocationByCoordinate(byte x, byte y)
	{
		ByteCoordinate coordinate = new ByteCoordinate(x, y);
		short blockId = ByteCoordinate.CoordinateToIndex(coordinate, DomainManager.TutorialChapter.TutorialAreaSize);
		return new Location(136, blockId);
	}

	private void OnInitializedDomainData()
	{
		_fixedCharacters = new Dictionary<string, int>();
	}

	private void InitializeOnInitializeGameDataModule()
	{
	}

	private void InitializeOnEnterNewWorld()
	{
		_nextForceLocation = Location.Invalid;
		_tutorialChapter = -1;
		_guidVideoName = string.Empty;
		_tutorialFunctionStatuses = new BoolArray(TutorialFunctionType.Instance.Count);
	}

	private void OnLoadedArchiveData()
	{
		_tutorialFunctionStatuses = new BoolArray(TutorialFunctionType.Instance.Count);
	}

	[SingleValueDependency(15, new ushort[] { 1, 8 })]
	private Location CalcNextForceLocation()
	{
		if (_tutorialChapter < 0)
		{
			return Location.Invalid;
		}
		TutorialChaptersItem tutorialCfg = TutorialChapters.Instance[_tutorialChapter];
		if (!tutorialCfg.ForcePath.CheckIndex(_forcePathIndex))
		{
			return Location.Invalid;
		}
		ByteCoordinate coordinate = tutorialCfg.ForcePath[_forcePathIndex];
		short areaId = DomainManager.Taiwu.GetTaiwu().GetLocation().AreaId;
		MapAreaData area = DomainManager.Map.GetElement_Areas(areaId);
		byte areaSize = area.GetConfig().Size;
		short blockId = ByteCoordinate.CoordinateToIndex(coordinate, areaSize);
		return new Location(areaId, blockId);
	}

	public TutorialChapterDomain()
		: base(10)
	{
		_curProgress = 0;
		_tutorialChapter = 0;
		_guidVideoName = string.Empty;
		_nextForceLocation = Location.Invalid;
		_neiliAllocateFitChapter7 = false;
		_huanxinDying = false;
		_huanxinSurprised = false;
		_tutorialFunctionStatuses = new BoolArray();
		_forcePathIndex = -1;
		_guidVideoTemplateId = -1;
		OnInitializedDomainData();
	}

	public int GetCurProgress()
	{
		return _curProgress;
	}

	public void SetCurProgress(int value, DataContext context)
	{
		_curProgress = value;
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	public short GetTutorialChapter()
	{
		return _tutorialChapter;
	}

	public void SetTutorialChapter(short value, DataContext context)
	{
		_tutorialChapter = value;
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	public string GetGuidVideoName()
	{
		return _guidVideoName;
	}

	public void SetGuidVideoName(string value, DataContext context)
	{
		_guidVideoName = value;
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	public Location GetNextForceLocation()
	{
		Thread.MemoryBarrier();
		if (BaseGameDataDomain.IsCached(DataStates, 3))
		{
			return _nextForceLocation;
		}
		Location value = CalcNextForceLocation();
		bool lockTaken = false;
		try
		{
			_spinLockNextForceLocation.Enter(ref lockTaken);
			_nextForceLocation = value;
			BaseGameDataDomain.SetCached(DataStates, 3);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLockNextForceLocation.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _nextForceLocation;
	}

	public bool GetNeiliAllocateFitChapter7()
	{
		return _neiliAllocateFitChapter7;
	}

	public void SetNeiliAllocateFitChapter7(bool value, DataContext context)
	{
		_neiliAllocateFitChapter7 = value;
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	public bool GetHuanxinDying()
	{
		return _huanxinDying;
	}

	public void SetHuanxinDying(bool value, DataContext context)
	{
		_huanxinDying = value;
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	public bool GetHuanxinSurprised()
	{
		return _huanxinSurprised;
	}

	public void SetHuanxinSurprised(bool value, DataContext context)
	{
		_huanxinSurprised = value;
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	public BoolArray GetTutorialFunctionStatuses()
	{
		return _tutorialFunctionStatuses;
	}

	public void SetTutorialFunctionStatuses(BoolArray value, DataContext context)
	{
		_tutorialFunctionStatuses = value;
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	public int GetForcePathIndex()
	{
		return _forcePathIndex;
	}

	public void SetForcePathIndex(int value, DataContext context)
	{
		_forcePathIndex = value;
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	public short GetGuidVideoTemplateId()
	{
		return _guidVideoTemplateId;
	}

	public void SetGuidVideoTemplateId(short value, DataContext context)
	{
		_guidVideoTemplateId = value;
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
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
		archive.WriteSingleValueUnmanaged((ushort)0);
	}

	public override void OnLoadWorld(ArchiveFileBase archive)
	{
		ushort savedFieldCount = 0;
		archive.ReadSingleValueUnmanaged(ref savedFieldCount);
		int domainDataIndex = 0;
		if (domainDataIndex < savedFieldCount)
		{
			DomainDataMeta domainDataMeta = archive.ReadDomainDataMeta();
			ushort dataId = domainDataMeta.DataId;
			ushort num = dataId;
			throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(15);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 0);
			}
			return GameData.Serializer.Serializer.Serialize(_curProgress, dataPool);
		case 1:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
			}
			return GameData.Serializer.Serializer.Serialize(_tutorialChapter, dataPool);
		case 2:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
			}
			return GameData.Serializer.Serializer.Serialize(_guidVideoName, dataPool);
		case 3:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
			}
			return GameData.Serializer.Serializer.Serialize(GetNextForceLocation(), dataPool);
		case 4:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
			}
			return GameData.Serializer.Serializer.Serialize(_neiliAllocateFitChapter7, dataPool);
		case 5:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
			}
			return GameData.Serializer.Serializer.Serialize(_huanxinDying, dataPool);
		case 6:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 6);
			}
			return GameData.Serializer.Serializer.Serialize(_huanxinSurprised, dataPool);
		case 7:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
			}
			return GameData.Serializer.Serializer.Serialize(_tutorialFunctionStatuses, dataPool);
		case 8:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
			}
			return GameData.Serializer.Serializer.Serialize(_forcePathIndex, dataPool);
		case 9:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
			}
			return GameData.Serializer.Serializer.Serialize(_guidVideoTemplateId, dataPool);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void SetData(ushort dataId, ulong subId0, uint subId1, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		switch (dataId)
		{
		case 0:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _curProgress);
			SetCurProgress(_curProgress, context);
			break;
		case 1:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _tutorialChapter);
			SetTutorialChapter(_tutorialChapter, context);
			break;
		case 2:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _guidVideoName);
			SetGuidVideoName(_guidVideoName, context);
			break;
		case 3:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 4:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _neiliAllocateFitChapter7);
			SetNeiliAllocateFitChapter7(_neiliAllocateFitChapter7, context);
			break;
		case 5:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _huanxinDying);
			SetHuanxinDying(_huanxinDying, context);
			break;
		case 6:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _huanxinSurprised);
			SetHuanxinSurprised(_huanxinSurprised, context);
			break;
		case 7:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _tutorialFunctionStatuses);
			SetTutorialFunctionStatuses(_tutorialFunctionStatuses, context);
			break;
		case 8:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _forcePathIndex);
			SetForcePathIndex(_forcePathIndex, context);
			break;
		case 9:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _guidVideoTemplateId);
			SetGuidVideoTemplateId(_guidVideoTemplateId, context);
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
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 1)
			{
				int chapter = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref chapter);
				StartChapter(context, chapter);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
			if (operation.ArgsCount == 0)
			{
				Location returnValue = GetNextForceMoveToLocation();
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		default:
			throw new Exception($"Unsupported methodId {operation.MethodId}");
		}
	}

	public override void OnMonitorData(ushort dataId, ulong subId0, uint subId1, bool monitoring)
	{
		switch (dataId)
		{
		case 0:
			return;
		case 1:
			return;
		case 2:
			return;
		case 3:
			return;
		case 4:
			return;
		case 5:
			return;
		case 6:
			return;
		case 7:
			return;
		case 8:
			return;
		case 9:
			return;
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override int CheckModified(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool)
	{
		switch (dataId)
		{
		case 0:
			if (!BaseGameDataDomain.IsModified(DataStates, 0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 0);
			return GameData.Serializer.Serializer.Serialize(_curProgress, dataPool);
		case 1:
			if (!BaseGameDataDomain.IsModified(DataStates, 1))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 1);
			return GameData.Serializer.Serializer.Serialize(_tutorialChapter, dataPool);
		case 2:
			if (!BaseGameDataDomain.IsModified(DataStates, 2))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 2);
			return GameData.Serializer.Serializer.Serialize(_guidVideoName, dataPool);
		case 3:
			if (!BaseGameDataDomain.IsModified(DataStates, 3))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 3);
			return GameData.Serializer.Serializer.Serialize(GetNextForceLocation(), dataPool);
		case 4:
			if (!BaseGameDataDomain.IsModified(DataStates, 4))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 4);
			return GameData.Serializer.Serializer.Serialize(_neiliAllocateFitChapter7, dataPool);
		case 5:
			if (!BaseGameDataDomain.IsModified(DataStates, 5))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 5);
			return GameData.Serializer.Serializer.Serialize(_huanxinDying, dataPool);
		case 6:
			if (!BaseGameDataDomain.IsModified(DataStates, 6))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 6);
			return GameData.Serializer.Serializer.Serialize(_huanxinSurprised, dataPool);
		case 7:
			if (!BaseGameDataDomain.IsModified(DataStates, 7))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 7);
			return GameData.Serializer.Serializer.Serialize(_tutorialFunctionStatuses, dataPool);
		case 8:
			if (!BaseGameDataDomain.IsModified(DataStates, 8))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 8);
			return GameData.Serializer.Serializer.Serialize(_forcePathIndex, dataPool);
		case 9:
			if (!BaseGameDataDomain.IsModified(DataStates, 9))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 9);
			return GameData.Serializer.Serializer.Serialize(_guidVideoTemplateId, dataPool);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void ResetModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		switch (dataId)
		{
		case 0:
			if (BaseGameDataDomain.IsModified(DataStates, 0))
			{
				BaseGameDataDomain.ResetModified(DataStates, 0);
			}
			break;
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
			}
			break;
		case 8:
			if (BaseGameDataDomain.IsModified(DataStates, 8))
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
			}
			break;
		case 9:
			if (BaseGameDataDomain.IsModified(DataStates, 9))
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
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
			0 => BaseGameDataDomain.IsModified(DataStates, 0), 
			1 => BaseGameDataDomain.IsModified(DataStates, 1), 
			2 => BaseGameDataDomain.IsModified(DataStates, 2), 
			3 => BaseGameDataDomain.IsModified(DataStates, 3), 
			4 => BaseGameDataDomain.IsModified(DataStates, 4), 
			5 => BaseGameDataDomain.IsModified(DataStates, 5), 
			6 => BaseGameDataDomain.IsModified(DataStates, 6), 
			7 => BaseGameDataDomain.IsModified(DataStates, 7), 
			8 => BaseGameDataDomain.IsModified(DataStates, 8), 
			9 => BaseGameDataDomain.IsModified(DataStates, 9), 
			_ => throw new Exception($"Unsupported dataId {dataId}"), 
		};
	}

	public override void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll)
	{
		switch (influence.TargetIndicator.DataId)
		{
		case 3:
			BaseGameDataDomain.InvalidateSelfAndInfluencedCache(3, DataStates, CacheInfluences, context);
			break;
		default:
			throw new Exception($"Unsupported dataId {influence.TargetIndicator.DataId}");
		case 0:
		case 1:
		case 2:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
	}
}
