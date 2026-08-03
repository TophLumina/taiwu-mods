using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Config;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Achievement;
using GameData.ArchiveData;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Common.SingleValueCollection;
using GameData.DLC;
using GameData.DLC.FiveLoong;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Building.Display;
using GameData.Domains.Building.SamsaraPlatformRecord;
using GameData.Domains.Building.ShopEvent;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Creation;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.Filters;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Extra;
using GameData.Domains.Global;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Organization.Display;
using GameData.Domains.Taiwu;
using GameData.Domains.Taiwu.Display;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.Taiwu.VillagerRole;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Domains.World.TeaHorseCaravanEvent;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using GameData.Utilities.RandomGenerator;
using NLog;
using Redzen.Random;

namespace GameData.Domains.Building;

[GameDataDomain(9)]
public class BuildingDomain : BaseGameDataDomain
{
	private struct ItemWithSource
	{
		public ItemKey ItemKey;

		public int Amount;

		public int Source;

		public int IndexInSource;
	}

	public class TeaHorseCaravanState
	{
		public const sbyte None = 0;

		public const sbyte Ready = 1;

		public const sbyte Forward = 2;

		public const sbyte Return = 3;

		public const sbyte ReadyGetItem = 4;
	}

	public enum SaveInfectedType
	{
		Save = 1,
		Release,
		Expel,
		Kill
	}

	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private Dictionary<Location, BuildingAreaData> _buildingAreas;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private Dictionary<BuildingBlockKey, BuildingBlockData> _buildingBlocks;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private List<Location> _taiwuBuildingAreas;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private Dictionary<BuildingBlockKey, sbyte> _CollectBuildingResourceType;

	[DomainData(DomainDataType.SingleValueCollection, false, false, true, false)]
	private Dictionary<BuildingBlockKey, CharacterList> _buildingOperatorDict;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private Dictionary<BuildingBlockKey, int> _customBuildingName;

	private bool _needUpdateEffects;

	public const short DependMaxDistance = 2;

	private short _nextTeaHorseEventId = -1;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private List<BuildingBlockKey> _newCompleteOperationBuildings;

	private List<BuildingBlockKey> _newBrokenBuildings = new List<BuildingBlockKey>();

	public readonly short BaseWorkContribution = 250;

	public readonly short AttainmentToProb = 20;

	private readonly BuildingExceptionData _buildingExceptionData = new BuildingExceptionData();

	private readonly HashSet<BuildingBlockKey> _buildingAutoExpandStoppedNotifiedSet = new HashSet<BuildingBlockKey>();

	private readonly BuildingFormulaContextBridge _formulaContextBridge = new BuildingFormulaContextBridge();

	private readonly Dictionary<Location, IBuildingEffectValue[]> _buildingBlockEffectsCache = new Dictionary<Location, IBuildingEffectValue[]>();

	private readonly BuildingFormulaContextBridge.CalcArgument _formulaArgHandler = CalcBuildingFormulaContextArg;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private Dictionary<int, Chicken> _chicken;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private int _featherValue;

	private int _nextChickenId;

	public List<short> ChickenMapInfo = new List<short>();

	private readonly Dictionary<int, List<int>> _settlementChickenIdLists = new Dictionary<int, List<int>>();

	private const int EffeciencyLeaderAttainmentBonus = 150;

	private const int EffeciencyWorkerAttainmentBonus = 50;

	private static readonly List<ItemSourceType> ResourceBuildingItemSources = new List<ItemSourceType>
	{
		ItemSourceType.Inventory,
		ItemSourceType.Warehouse,
		ItemSourceType.Treasury
	};

	[Obsolete]
	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private Dictionary<BuildingBlockKey, MakeItemDataObsolete> _makeItemDict;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private Dictionary<BuildingBlockKey, MakeItemData> _makeItemDataDict;

	private bool _outsideMakeItem = false;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<BuildingBlockKey, CharacterList> _residences;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<BuildingBlockKey, CharacterList> _comfortableHouses;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<BuildingBlockKey, bool> _comfortableHousesAutoCheckInType;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<BuildingBlockKey, CharacterSet> _lockedResidences;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<BuildingBlockKey, CharacterSet> _lockedComfortableHouses;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private CharacterList _homeless;

	private Dictionary<int, BuildingBlockKey> _buildingResidents;

	private Dictionary<int, BuildingBlockKey> _buildingComfortableHouses;

	private Dictionary<int, (short, int, ItemKey)> _feastParticipants = new Dictionary<int, (short, int, ItemKey)>();

	private const int ResourceBlockBaseValueCount = 5;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private MainAttributes _samsaraPlatformAddMainAttributes;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private CombatSkillShorts _samsaraPlatformAddCombatSkillQualifications;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private LifeSkillShorts _samsaraPlatformAddLifeSkillQualifications;

	[DomainData(DomainDataType.ElementList, true, false, true, true, ArrayElementsCount = 6)]
	private readonly IntPair[] _samsaraPlatformSlots;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<int, IntPair> _samsaraPlatformBornDict;

	private const string TemporaryPossessionCharIdKey = "TemporaryPossessionCharId";

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private Dictionary<BuildingBlockKey, BuildingEarningsData> _collectBuildingEarningsData;

	[DomainData(DomainDataType.SingleValueCollection, false, false, true, false)]
	private Dictionary<BuildingBlockKey, CharacterList> _shopManagerDict;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private TeaHorseCaravanData _teaHorseCaravanData;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private TeaHorseCaravanEventCollection _teaHorseCaravanEventCollection;

	[DomainData(DomainDataType.SingleValueCollection, false, false, true, false)]
	private Dictionary<int, int> _shopManagerUpgradeQualificationDict;

	private Dictionary<BuildingBlockKey, ShopEventCollection> _shopEventCollections;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private List<short> _newlyCreatedBuildingIndexes;

	private List<short> _westTreasureTemplateId = new List<short> { 37, 38, 39, 40, 41 };

	private readonly short[][] WestItemArrayTwo = new short[9][]
	{
		new short[5] { 37, 38, 39, 40, 41 },
		new short[5] { 42, 43, 44, 45, 46 },
		new short[5] { 47, 48, 49, 50, 51 },
		new short[5] { 52, 53, 54, 55, 56 },
		new short[5] { 57, 58, 59, 60, 61 },
		new short[5] { 62, 63, 64, 65, 66 },
		new short[5] { 67, 68, 69, 70, 71 },
		new short[5] { 72, 73, 74, 75, 76 },
		new short[5] { 77, 78, 79, 80, 81 }
	};

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private ushort _shrineBuyTimes;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly HashSetAsDictionary<Location> _locationMarkHashSet;

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[30][];

	private SingleValueCollectionModificationCollection<Location> _modificationsBuildingAreas = SingleValueCollectionModificationCollection<Location>.Create();

	private SingleValueCollectionModificationCollection<BuildingBlockKey> _modificationsBuildingBlocks = SingleValueCollectionModificationCollection<BuildingBlockKey>.Create();

	private SingleValueCollectionModificationCollection<BuildingBlockKey> _modificationsCollectBuildingResourceType = SingleValueCollectionModificationCollection<BuildingBlockKey>.Create();

	private SingleValueCollectionModificationCollection<BuildingBlockKey> _modificationsBuildingOperatorDict = SingleValueCollectionModificationCollection<BuildingBlockKey>.Create();

	private SingleValueCollectionModificationCollection<BuildingBlockKey> _modificationsCustomBuildingName = SingleValueCollectionModificationCollection<BuildingBlockKey>.Create();

	private SingleValueCollectionModificationCollection<int> _modificationsChicken = SingleValueCollectionModificationCollection<int>.Create();

	private static readonly DataInfluence[][] CacheInfluencesSamsaraPlatformSlots = new DataInfluence[6][];

	private readonly byte[] _dataStatesSamsaraPlatformSlots = new byte[2];

	private SingleValueCollectionModificationCollection<int> _modificationsSamsaraPlatformBornDict = SingleValueCollectionModificationCollection<int>.Create();

	private SingleValueCollectionModificationCollection<BuildingBlockKey> _modificationsCollectBuildingEarningsData = SingleValueCollectionModificationCollection<BuildingBlockKey>.Create();

	private SingleValueCollectionModificationCollection<BuildingBlockKey> _modificationsShopManagerDict = SingleValueCollectionModificationCollection<BuildingBlockKey>.Create();

	private SingleValueCollectionModificationCollection<Location> _modificationsLocationMarkHashSet = SingleValueCollectionModificationCollection<Location>.Create();

	private SingleValueCollectionModificationCollection<int> _modificationsShopManagerUpgradeQualificationDict = SingleValueCollectionModificationCollection<int>.Create();

	private Queue<uint> _pendingLoadingOperationIds;

	[DataUpgrader(Version = "1.0.57", Date = "2026/07/13")]
	private void FixResidentBuilding(DataContext context)
	{
		List<int> childList = new List<int>();
		foreach (var (charId, _) in _buildingResidents)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetAgeGroup() < 2)
			{
				childList.Add(charId);
			}
		}
		foreach (int child in childList)
		{
			DomainManager.Building.RemoveTaiwuResident(context, child);
		}
		childList.Clear();
		foreach (int charId2 in _homeless.GetCollection())
		{
			if (DomainManager.Character.TryGetElement_Objects(charId2, out var character2) && character2.GetAgeGroup() < 2)
			{
				childList.Add(charId2);
			}
		}
		foreach (int charId3 in childList)
		{
			_homeless.Remove(charId3);
		}
		SetHomeless(_homeless, context);
		DomainManager.Building.TaiwuVillagerBecomeAdultAdvanceMonth(context);
	}

	[DataUpgrader(Version = "1.0.47", Date = "2026/07/01")]
	private void FixDuplicatedBuildingItem(DataContext context)
	{
		HashSet<ItemKey> nonStackable = new HashSet<ItemKey>();
		KeyValuePair<BuildingBlockKey, BuildingEarningsData>[] array = _collectBuildingEarningsData.ToArray();
		foreach (KeyValuePair<BuildingBlockKey, BuildingEarningsData> keyValuePair in array)
		{
			keyValuePair.Deconstruct(out var key, out var value);
			BuildingBlockKey k = key;
			BuildingEarningsData v = value;
			bool modified = false;
			int i2 = v.ShopSoldItemList.Count;
			while (i2-- > 0)
			{
				ItemKey item = v.ShopSoldItemList[i2];
				if (item.IsValid())
				{
					if (DomainManager.Item.TryGetBaseItem(item) == null || nonStackable.Contains(item))
					{
						modified = true;
						v.ShopSoldItemList[i2] = ItemKey.Invalid;
						AdaptableLog.Warning($"Removing non exist or duplicated item {item}");
					}
					else if (!ItemTemplateHelper.IsPureStackable(item))
					{
						nonStackable.Add(item);
					}
				}
			}
			if (modified)
			{
				SetElement_CollectBuildingEarningsData(k, v, context);
			}
		}
	}

	private void OnInitializedDomainData()
	{
		_buildingResidents = new Dictionary<int, BuildingBlockKey>();
		_buildingComfortableHouses = new Dictionary<int, BuildingBlockKey>();
	}

	private void InitializeOnInitializeGameDataModule()
	{
	}

	private void InitializeOnEnterNewWorld()
	{
		InitializeSamsaraPlatform();
	}

	private void OnLoadedArchiveData()
	{
		Dictionary<int, VillagerWorkData> villagerWorkDict = DomainManager.Taiwu.GetVillagerWorkDict();
		DataContext context = DataContextManager.GetCurrentThreadDataContext();
		foreach (int charId in villagerWorkDict.Keys)
		{
			VillagerWorkData workData = villagerWorkDict[charId];
			BuildingBlockKey blockKey = new BuildingBlockKey(workData.AreaId, workData.BlockId, workData.BuildingBlockIndex);
			switch (workData.WorkType)
			{
			case 0:
				SetBuildingOperator(context, blockKey, workData.WorkerIndex, workData.CharacterId);
				break;
			case 1:
				SetShopBuildingManager(context, blockKey, workData.WorkerIndex, workData.CharacterId, setArtisanOrder: false);
				break;
			}
		}
		FixResidentData(context);
		InitializeBuildingResidents(context);
		InitializeNextChickenId();
		RefreshSettlementChickenIdLists(context);
	}

	public override void OnCurrWorldArchiveDataReady(DataContext context, bool isNewWorld)
	{
		UpgradeTeaHorseCaravanByAwareness(context);
	}

	public override void OnUpdate(DataContext context)
	{
		base.OnUpdate(context);
		if (_needUpdateEffects)
		{
			UpdateTaiwuVillageBuildingEffect();
			_needUpdateEffects = false;
		}
	}

	[DomainMethod]
	public BuildingAreaData GetBuildingAreaData(Location location)
	{
		return GetElement_BuildingAreas(location);
	}

	[DomainMethod]
	public BuildingAreaData GetTaiwuVillageBuildingAreaData()
	{
		return GetElement_BuildingAreas(DomainManager.Taiwu.GetTaiwuVillageLocation());
	}

	[DomainMethod]
	public List<BuildingBlockData> GetBuildingBlockList(Location location)
	{
		List<BuildingBlockData> blockList = new List<BuildingBlockData>();
		foreach (KeyValuePair<BuildingBlockKey, BuildingBlockData> entry in _buildingBlocks)
		{
			if (entry.Key.AreaId == location.AreaId && entry.Key.BlockId == location.BlockId)
			{
				blockList.Add(entry.Value);
			}
		}
		blockList.Sort((BuildingBlockData block1, BuildingBlockData block2) => block1.BlockIndex.CompareTo(block2.BlockIndex));
		return blockList;
	}

	[DomainMethod]
	public BuildingBlockData GetBuildingBlockData(BuildingBlockKey blockKey)
	{
		return GetElement_BuildingBlocks(blockKey);
	}

	[DomainMethod]
	public TransferableRecordDataBase GetReversedBlockShopEvent(DataContext context, BuildingBlockKey blockKey)
	{
		ShopEventCollection collection = GetOrCreateShopEventCollection(blockKey);
		TransferableRecordDataBase data = new TransferableRecordDataBase();
		collection.ReadDataWithNormalOrder(data, GetParameters);
		LifeRecordDomain.PostProcess(data);
		return data;
		static string[] GetParameters(int recordType)
		{
			ShopEventItem config = Config.ShopEvent.Instance[recordType];
			if (config != null)
			{
				return config.Parameters ?? Array.Empty<string>();
			}
			AdaptableLog.Warning($"Unable to render ShopEvent with template id {recordType}");
			return null;
		}
	}

	[DomainMethod]
	public void SetBuildingCustomName(DataContext context, BuildingBlockKey blockKey, string name)
	{
		int textId;
		bool hasCustomName = _customBuildingName.TryGetValue(blockKey, out textId);
		if (!(hasCustomName ? (DomainManager.World.GetElement_CustomTexts(textId) == name) : string.IsNullOrEmpty(name)))
		{
			if (hasCustomName)
			{
				DomainManager.World.UnregisterCustomText(context, textId);
				RemoveElement_CustomBuildingName(blockKey, context);
			}
			if (!string.IsNullOrEmpty(name))
			{
				textId = DomainManager.World.RegisterCustomText(context, name);
				AddElement_CustomBuildingName(blockKey, textId, context);
			}
		}
	}

	[DomainMethod]
	public int GetEmptyBlockCount(short areaId, short blockId)
	{
		int count = 0;
		BuildingAreaData buildingArea = _buildingAreas[new Location(areaId, blockId)];
		for (short blockIndex = 0; blockIndex < buildingArea.Width * buildingArea.Width; blockIndex++)
		{
			if (IsBuildingBlocksEmpty(areaId, blockId, blockIndex, buildingArea.Width, 1))
			{
				count++;
			}
		}
		return count;
	}

	[DomainMethod]
	public int GetSutraReadingRoomBuffValue()
	{
		short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		int buildingEffect = GetBuildingBlockEffect(settlementId, EBuildingScaleEffect.ReadingStrategyCost);
		return Math.Clamp(100 - buildingEffect, 0, 100);
	}

	[DomainMethod]
	public int PracticingCombatSkillInPracticeRoom(DataContext context, BuildingBlockKey blockKey, short skillTemplateId, int count, int cost)
	{
		int proficiency = 0;
		CombatSkillKey combatSkillKey = new CombatSkillKey(DomainManager.Taiwu.GetTaiwuCharId(), skillTemplateId);
		int factor = 1;
		int reduceCostDependBonus = 0;
		int addBreakoutDependBonus = 0;
		int val;
		int origin = (DomainManager.Extra.TryGetElement_CombatSkillProficiencies(combatSkillKey, out val) ? val : 0);
		List<short> neighborList = ObjectPool<List<short>>.Instance.Get();
		BuildingBlockData blockData = GetBuildingBlockData(blockKey);
		short templateId = blockData.TemplateId;
		Location location = new Location(blockKey.AreaId, blockKey.BlockId);
		bool isTaiwuVillage = DomainManager.Taiwu.GetTaiwuVillageLocation() == location;
		BuildingAreaData areaData = GetElement_BuildingAreas(location);
		sbyte buildingWidth = BuildingBlock.Instance[_buildingBlocks[blockKey].TemplateId].Width;
		areaData.GetNeighborBlocks(blockKey.BuildingBlockIndex, buildingWidth, neighborList, null, 2);
		foreach (short buildingBlockIndex in neighborList)
		{
			BuildingBlockData neighborBlock = _buildingBlocks[new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, buildingBlockIndex)];
			if (neighborBlock.RootBlockIndex >= 0)
			{
				neighborBlock = _buildingBlocks[new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborBlock.RootBlockIndex)];
			}
			if (neighborBlock.TemplateId == 0 || !neighborBlock.CanUse())
			{
				continue;
			}
			BuildingBlockItem config = BuildingBlock.Instance[neighborBlock.TemplateId];
			if (config.DependBuildings != null && config.DependBuildings.Contains(templateId))
			{
				if (config.ReduceCombatSkillCost >= 0)
				{
					reduceCostDependBonus = 1;
				}
				if (config.AddCombatSkillBreakout >= 0)
				{
					addBreakoutDependBonus = 1;
				}
			}
		}
		if (!isTaiwuVillage)
		{
			factor *= 3;
		}
		ObjectPool<List<short>>.Instance.Return(neighborList);
		for (int i = 0; i < count; i++)
		{
			int delta = context.Random.Next(GlobalConfig.Instance.BaseCombatSkillPracticeProficiencyDelta[0], GlobalConfig.Instance.BaseCombatSkillPracticeProficiencyDelta[1]);
			if (reduceCostDependBonus > 0)
			{
				delta += context.Random.Next(GlobalConfig.Instance.BaseCombatSkillPracticeProficiencyDelta[0], GlobalConfig.Instance.BaseCombatSkillPracticeProficiencyDelta[1]);
			}
			if (addBreakoutDependBonus > 0)
			{
				delta += context.Random.Next(GlobalConfig.Instance.BaseCombatSkillPracticeProficiencyDelta[0], GlobalConfig.Instance.BaseCombatSkillPracticeProficiencyDelta[1]);
			}
			proficiency += delta * factor;
		}
		DomainManager.Extra.ConsumeActionPoint(context, cost);
		DomainManager.Extra.ChangeCombatSkillProficiency(context, combatSkillKey, proficiency);
		int addSeniority = ProfessionFormulaImpl.Calculate(30, DomainManager.Extra.GetElement_CombatSkillProficiencies(combatSkillKey) - origin);
		DomainManager.Extra.ChangeProfessionSeniority(context, 3, addSeniority);
		return proficiency;
	}

	public List<short> GetAvailableBuildingBlocks(List<short> buildingBlocks, short areaId, short blockId, sbyte areaWidth, sbyte buildingWidth)
	{
		List<short> availableIndexes = new List<short>();
		foreach (short index in buildingBlocks)
		{
			if (IsBuildingBlocksEmpty(areaId, blockId, index, areaWidth, buildingWidth))
			{
				availableIndexes.Add(index);
			}
		}
		return availableIndexes;
	}

	public short GetRootBlockContainingIndex(short areaId, short blockId, short index, sbyte areaWidth, sbyte buildingWidth)
	{
		for (int i = 0; i < buildingWidth; i++)
		{
			for (int j = 0; j < buildingWidth; j++)
			{
				short indexWithOffset = (short)(index - i * areaWidth - j);
				if (IsBuildingBlocksEmpty(areaId, blockId, indexWithOffset, areaWidth, buildingWidth))
				{
					return indexWithOffset;
				}
			}
		}
		return -1;
	}

	public bool RootContainBlock(short areaId, short blockId, short rootIndex, short blockIndex, sbyte areaWidth, sbyte buildingWidth)
	{
		for (int i = 0; i < buildingWidth; i++)
		{
			for (int j = 0; j < buildingWidth; j++)
			{
				short index = (short)(rootIndex + i * areaWidth + j);
				if (index == blockIndex)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool IsBuildingBlocksEmpty(short areaId, short blockId, short rootIndex, sbyte areaWidth, sbyte buildingWidth)
	{
		int x = rootIndex % areaWidth;
		int y = rootIndex / areaWidth;
		if (x + buildingWidth > areaWidth || y + buildingWidth > areaWidth)
		{
			return false;
		}
		for (int i = 0; i < buildingWidth; i++)
		{
			for (int j = 0; j < buildingWidth; j++)
			{
				short index = (short)(rootIndex + i * areaWidth + j);
				BuildingBlockKey key = new BuildingBlockKey(areaId, blockId, index);
				if (_buildingBlocks.ContainsKey(key))
				{
					BuildingBlockData buildingBlock = _buildingBlocks[key];
					if (buildingBlock.TemplateId > 0 || buildingBlock.RootBlockIndex >= 0)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	public void ResetAllChildrenBlocks(DataContext context, BuildingBlockKey blockKey, short templateId, sbyte level = 1)
	{
		BuildingBlockData buildingBlock = GetElement_BuildingBlocks(blockKey);
		if (buildingBlock.TemplateId < 0)
		{
			return;
		}
		int buildingWidth = Math.Max(BuildingBlock.Instance[buildingBlock.TemplateId].Width, BuildingBlock.Instance[templateId].Width);
		MapBlockItem mapBlockData = MapBlock.Instance[DomainManager.Map.GetBlock(blockKey.AreaId, blockKey.BlockId).TemplateId];
		sbyte areaWidth = mapBlockData.BuildingAreaWidth;
		int blockX = buildingBlock.BlockIndex % areaWidth;
		int blockY = buildingBlock.BlockIndex / areaWidth;
		for (int i = blockX; i < Math.Min(blockX + buildingWidth, areaWidth); i++)
		{
			for (int j = blockY; j < Math.Min(blockY + buildingWidth, areaWidth); j++)
			{
				short index = (short)(j * areaWidth + i);
				BuildingBlockKey key = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, index);
				if (templateId > 0 && templateId != 23 && index != blockKey.BuildingBlockIndex)
				{
					_buildingBlocks[key].ResetData(-1, -1, buildingBlock.BlockIndex);
				}
				else
				{
					_buildingBlocks[key].ResetData(templateId, level, -1);
				}
				SetElement_BuildingBlocks(key, _buildingBlocks[key], context);
			}
		}
	}

	public void AddBuilding(DataContext context, short areaId, short blockId, short centerIndex, short templateId, sbyte level, sbyte areaWidth)
	{
		sbyte buildingWidth = BuildingBlock.Instance[templateId].Width;
		for (int i = 0; i < buildingWidth; i++)
		{
			for (int j = 0; j < buildingWidth; j++)
			{
				short index = (short)(centerIndex + i * areaWidth + j);
				BuildingBlockKey key = new BuildingBlockKey(areaId, blockId, index);
				if (_buildingBlocks.ContainsKey(key))
				{
					Logger.AppendWarning($"Building {BuildingBlock.Instance[templateId].Name} with key {key} is being added to a occupied place at {MapBlock.Instance[DomainManager.Map.GetBlock(areaId, blockId).TemplateId].Name}");
				}
				BuildingBlockData val = ((index == centerIndex) ? new BuildingBlockData(index, templateId, level, -1) : new BuildingBlockData(index, -1, -1, centerIndex));
				AddElement_BuildingBlocks(key, val, context);
			}
		}
	}

	public void PlaceBuilding(DataContext context, short areaId, short blockId, short rootIndex, BuildingBlockData blockData, sbyte areaWidth)
	{
		sbyte buildingWidth = BuildingBlock.Instance[blockData.TemplateId].Width;
		for (int i = 0; i < buildingWidth; i++)
		{
			for (int j = 0; j < buildingWidth; j++)
			{
				short index = (short)(rootIndex + i * areaWidth + j);
				BuildingBlockKey key = new BuildingBlockKey(areaId, blockId, index);
				BuildingBlockData val = ((index == rootIndex) ? blockData : new BuildingBlockData(index, -1, -1, rootIndex));
				SetElement_BuildingBlocks(key, val, context);
			}
		}
	}

	public void PlaceBuildingAtBlock(DataContext context, short areaId, short blockId, short templateId, bool forcePlace, bool isRandom)
	{
		BuildingBlockItem buildingConfig = BuildingBlock.Instance[templateId];
		List<short> availableBlockIndices = ObjectPool<List<short>>.Instance.Get();
		availableBlockIndices.Clear();
		BuildingAreaData buildingArea = _buildingAreas[new Location(areaId, blockId)];
		sbyte areaWidth = buildingArea.Width;
		sbyte buildingWidth = buildingConfig.Width;
		for (short blockIndex = 0; blockIndex < buildingArea.Width * buildingArea.Width; blockIndex++)
		{
			if (!IsEdge(blockIndex) && IsBuildingBlocksEmpty(areaId, blockId, blockIndex, areaWidth, buildingConfig.Width))
			{
				availableBlockIndices.Add(blockIndex);
			}
		}
		if (availableBlockIndices.Count == 0)
		{
			if (!forcePlace)
			{
				ObjectPool<List<short>>.Instance.Return(availableBlockIndices);
				return;
			}
			CalcAvailableBlockIndices(availableBlockIndices, (short buildingTemplateId) => BuildingBlock.Instance[buildingTemplateId].Type != EBuildingBlockType.UselessResource && BuildingBlock.Instance[buildingTemplateId].Type != EBuildingBlockType.Empty);
			if (availableBlockIndices.Count == 0)
			{
				CalcAvailableBlockIndices(availableBlockIndices, (short buildingTemplateId) => !BuildingBlockData.IsResource(BuildingBlock.Instance[buildingTemplateId].Type) && BuildingBlock.Instance[buildingTemplateId].Type != EBuildingBlockType.Empty);
			}
		}
		short selectedIndex = -1;
		if (isRandom)
		{
			selectedIndex = availableBlockIndices.GetRandom(context.Random);
		}
		else
		{
			availableBlockIndices.Sort((short l, short r) => GetDisToCenter(l, buildingArea.Width) - GetDisToCenter(r, buildingArea.Width));
			selectedIndex = availableBlockIndices[0];
		}
		BuildingBlockKey selectedBlockKey = new BuildingBlockKey(areaId, blockId, selectedIndex);
		BuildingBlockData blockData = GetElement_BuildingBlocks(selectedBlockKey);
		blockData.ResetData(templateId, 1, -1);
		PlaceBuilding(context, areaId, blockId, selectedIndex, blockData, buildingArea.Width);
		void CalcAvailableBlockIndices(List<short> blocks, Func<short, bool> func)
		{
			for (short blockIndex2 = 0; blockIndex2 < buildingArea.Width * buildingArea.Width; blockIndex2++)
			{
				int x = blockIndex2 % areaWidth;
				int y = blockIndex2 / areaWidth;
				if (x + buildingWidth <= areaWidth && y + buildingWidth <= areaWidth)
				{
					bool isValid = true;
					for (int i = 0; i < buildingWidth; i++)
					{
						for (int j = 0; j < buildingWidth; j++)
						{
							short index = (short)(blockIndex2 + i * areaWidth + j);
							BuildingBlockKey key = new BuildingBlockKey(areaId, blockId, index);
							BuildingBlockData buildingBlock = _buildingBlocks[key];
							if (buildingBlock.RootBlockIndex >= 0)
							{
								isValid = false;
								break;
							}
							if (buildingBlock.TemplateId >= 0 && func(buildingBlock.TemplateId))
							{
								isValid = false;
								break;
							}
							if (IsEdge(blockIndex2))
							{
								isValid = false;
								break;
							}
						}
						if (!isValid)
						{
							break;
						}
					}
					if (isValid)
					{
						blocks.Add(blockIndex2);
					}
				}
			}
		}
		static int GetDisToCenter(short num, sbyte width)
		{
			int x = num % width;
			int y = num / width;
			int center = width / 2 - 1;
			return Math.Abs(x - center) + Math.Abs(y - center);
		}
		bool IsEdge(short num)
		{
			int x = num % areaWidth;
			int y = num / areaWidth;
			return x == 0 || x == areaWidth - buildingWidth || y == 0 || y == areaWidth - buildingWidth;
		}
	}

	public void XiangshuDestroyTaiwuVillageBuilding(DataContext context, Location location)
	{
		if (!DomainManager.Taiwu.GetTaiwuVillageLocation().Equals(location))
		{
			return;
		}
		List<BuildingBlockData> destroyableBuildingList = new List<BuildingBlockData>();
		DomainManager.Building.GetDestroyableBuildings(location, destroyableBuildingList);
		short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		int destroyCount = Math.Min(context.Random.Next(6, 19), destroyableBuildingList.Count);
		bool gameOver = destroyCount == 0;
		for (int i = 0; i < destroyCount; i++)
		{
			if (gameOver)
			{
				break;
			}
			int index = context.Random.Next(destroyableBuildingList.Count);
			BuildingBlockData blockData = destroyableBuildingList[index];
			CollectionUtils.SwapAndRemove(destroyableBuildingList, index);
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, blockData.BlockIndex);
			CValuePercent lossPercent = context.Random.Next(20, 41);
			BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
			sbyte maxDurability = configData.MaxDurability;
			int durabilityLoss = maxDurability * lossPercent;
			if (durabilityLoss >= blockData.Durability)
			{
				if (blockData.TemplateId == 44)
				{
					gameOver = true;
				}
				else
				{
					blockData.Durability = 0;
					MakeBlockDestroy(context, configData, settlementId, blockData, blockKey);
				}
			}
			else if (durabilityLoss > 0)
			{
				blockData.Durability = (sbyte)(blockData.Durability - durabilityLoss);
			}
			if (blockData.TemplateId == 46)
			{
				RemoveExceedingResidents(context, blockKey);
			}
			SetElement_BuildingBlocks(blockKey, blockData, context);
		}
		if (gameOver)
		{
			DomainManager.World.SetTaiwuVillageDestroyed();
		}
	}

	public void GetDestroyableBuildings(Location location, List<BuildingBlockData> destroyableBuildingList)
	{
		destroyableBuildingList.Clear();
		BuildingAreaData buildingArea = _buildingAreas[location];
		sbyte areaWidth = buildingArea.Width;
		for (short blockIndex = 0; blockIndex < buildingArea.Width * buildingArea.Width; blockIndex++)
		{
			BuildingBlockKey key = new BuildingBlockKey(location.AreaId, location.BlockId, blockIndex);
			BuildingBlockData blockData = _buildingBlocks[key];
			if (blockData.RootBlockIndex < 0)
			{
				BuildingBlockItem buildingCfg = BuildingBlock.Instance[blockData.TemplateId];
				if (BuildingBlockData.IsBuilding(buildingCfg.Type) && buildingCfg.MaxDurability > 0)
				{
					if (blockData.Durability <= 0)
					{
						if (buildingCfg.Type == EBuildingBlockType.MainBuilding)
						{
							destroyableBuildingList.Clear();
							break;
						}
					}
					else
					{
						destroyableBuildingList.Add(blockData);
					}
				}
			}
		}
	}

	public static bool HasBuilt(Location location, BuildingAreaData buildingArea, short buildingTemplateId, bool checkUsable = true)
	{
		for (short blockIndex = 0; blockIndex < buildingArea.Width * buildingArea.Width; blockIndex++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, blockIndex);
			BuildingBlockData buildingBlock = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (buildingBlock.TemplateId == buildingTemplateId && (!checkUsable || buildingBlock.CanUse()))
			{
				return true;
			}
		}
		return false;
	}

	public bool CanBuild(BuildingBlockKey blockKey, short buildingTemplateId = -1)
	{
		Location location = new Location(blockKey.AreaId, blockKey.BlockId);
		if (!CheckCanBuildAtLocation(location))
		{
			return false;
		}
		BuildingBlockItem configData = BuildingBlock.Instance[buildingTemplateId];
		BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
		if (blockData.TemplateId != 0)
		{
			return false;
		}
		BuildingAreaData buildingArea = GetElement_BuildingAreas(location);
		if (!IsBuildingBlocksEmpty(blockKey.AreaId, blockKey.BlockId, blockKey.BuildingBlockIndex, buildingArea.Width, configData.Width))
		{
			return false;
		}
		if (configData.Type == EBuildingBlockType.MainBuilding && DomainManager.Global.IsInNormalWorld())
		{
			return false;
		}
		if (configData.IsUnique && HasBuilt(location, buildingArea, buildingTemplateId))
		{
			return false;
		}
		if (!AllDependBuildingAvailable(blockKey, buildingTemplateId, out var _))
		{
			return false;
		}
		if (!CheckCanBuildWithResources(configData))
		{
			return false;
		}
		return true;
	}

	private bool CheckCanBuildAtLocation(Location location)
	{
		return GetTaiwuBuildingAreas().Contains(location) || !DomainManager.Global.IsInNormalWorld();
	}

	private bool CheckCanBuildWithResources(BuildingBlockItem configData)
	{
		if (configData.Class == EBuildingBlockClass.BornResource)
		{
			return true;
		}
		ushort[] costResource = configData.BaseBuildCost;
		ResourceInts resource = GetAllTaiwuResources();
		for (sbyte type = 0; type < 8; type++)
		{
			if (resource.Get(type) < costResource[type])
			{
				return false;
			}
		}
		return true;
	}

	public IEnumerable<BuildingBlockData> GetBuildingBlocksAtLocation(Location location, Predicate<BuildingBlockData> condition = null)
	{
		BuildingAreaData areaData = GetElement_BuildingAreas(location);
		for (short blockIndex = 0; blockIndex < areaData.Width * areaData.Width; blockIndex++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, blockIndex);
			BuildingBlockData buildingBlock = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (condition?.Invoke(buildingBlock) ?? true)
			{
				yield return buildingBlock;
			}
		}
	}

	public static BuildingBlockData FindBuilding(Location location, BuildingAreaData buildingArea, short buildingTemplateId, bool checkUsable = true)
	{
		for (short blockIndex = 0; blockIndex < buildingArea.Width * buildingArea.Width; blockIndex++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, blockIndex);
			BuildingBlockData buildingBlock = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (buildingBlock.TemplateId == buildingTemplateId && (!checkUsable || buildingBlock.CanUse()))
			{
				return buildingBlock;
			}
		}
		return null;
	}

	public static BuildingBlockKey FindBuildingKey(Location location, BuildingAreaData buildingArea, short buildingTemplateId, bool checkUsable = true)
	{
		for (short blockIndex = 0; blockIndex < buildingArea.Width * buildingArea.Width; blockIndex++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, blockIndex);
			BuildingBlockData buildingBlock = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (buildingBlock.TemplateId == buildingTemplateId && (!checkUsable || buildingBlock.CanUse()))
			{
				return blockKey;
			}
		}
		return BuildingBlockKey.Invalid;
	}

	public List<BuildingBlockKey> FindAllBuildingsWithSameTemplate(Location location, BuildingAreaData buildingArea, short buildingTemplateId)
	{
		List<BuildingBlockKey> buildingBlockKeys = new List<BuildingBlockKey>();
		for (short blockIndex = 0; blockIndex < buildingArea.Width * buildingArea.Width; blockIndex++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, blockIndex);
			BuildingBlockData buildingBlock = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (buildingBlock.TemplateId == buildingTemplateId && buildingBlock.CanUse())
			{
				buildingBlockKeys.Add(blockKey);
			}
		}
		return buildingBlockKeys;
	}

	public bool AllDependBuildingAvailable(BuildingBlockKey blockKey, short buildingTemplateId, out sbyte minLevel)
	{
		List<short> dependBuildings = BuildingBlock.Instance[buildingTemplateId].DependBuildings;
		bool hasAllDependBuildings = true;
		minLevel = sbyte.MaxValue;
		if (dependBuildings.Count > 0)
		{
			Location location = new Location(blockKey.AreaId, blockKey.BlockId);
			BuildingAreaData areaData = GetElement_BuildingAreas(location);
			List<short> neighborList = ObjectPool<List<short>>.Instance.Get();
			Span<bool> dependBuildingFound = stackalloc bool[dependBuildings.Count];
			Span<sbyte> dependBuildingLevel = stackalloc sbyte[dependBuildings.Count];
			sbyte buildingWidth = BuildingBlock.Instance[_buildingBlocks[blockKey].TemplateId].Width;
			areaData.GetNeighborBlocks(blockKey.BuildingBlockIndex, buildingWidth, neighborList, null, 2);
			for (int i = 0; i < neighborList.Count; i++)
			{
				BuildingBlockKey neighborKey = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborList[i]);
				BuildingBlockData neighborBlock = _buildingBlocks[neighborKey];
				if (neighborBlock.RootBlockIndex >= 0)
				{
					neighborKey = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborBlock.RootBlockIndex);
					neighborBlock = _buildingBlocks[neighborKey];
				}
				if (neighborBlock.TemplateId != 0 && neighborBlock.CanUse())
				{
					int dependIndex = dependBuildings.IndexOf(neighborBlock.TemplateId);
					if (dependIndex >= 0)
					{
						dependBuildingFound[dependIndex] = true;
						dependBuildingLevel[dependIndex] = Math.Max(dependBuildingLevel[dependIndex], BuildingBlockLevel(neighborKey));
					}
				}
			}
			hasAllDependBuildings = !dependBuildingFound.Contains(value: false);
			minLevel = dependBuildingLevel.Min();
			ObjectPool<List<short>>.Instance.Return(neighborList);
		}
		return hasAllDependBuildings;
	}

	[DomainMethod]
	public bool AllDependBuildingAvailable(BuildingBlockKey blockKey)
	{
		sbyte minLevel;
		if (TryGetElement_BuildingBlocks(blockKey, out var blockData) && blockData != null && blockData.ConfigData != null)
		{
			return AllDependBuildingAvailable(blockKey, blockData.TemplateId, out minLevel);
		}
		return false;
	}

	public void SetBuildingOperator(DataContext context, BuildingBlockKey blockKey, int index, int charId)
	{
		CharacterList charList;
		if (!_buildingOperatorDict.ContainsKey(blockKey))
		{
			charList = default(CharacterList);
			for (int i = 0; i < 3; i++)
			{
				charList.Add(-1);
			}
			AddElement_BuildingOperatorDict(blockKey, charList, context);
		}
		else
		{
			charList = _buildingOperatorDict[blockKey];
		}
		charList.GetCollection()[index] = charId;
		SetElement_BuildingOperatorDict(blockKey, charList, context);
	}

	public void SetShopBuildingManager(DataContext context, BuildingBlockKey blockKey, int index, int charId, bool setArtisanOrder = true)
	{
		CharacterList charList;
		if (!_shopManagerDict.ContainsKey(blockKey))
		{
			charList = default(CharacterList);
			for (int i = 0; i < 7; i++)
			{
				charList.Add(-1);
			}
			AddElement_ShopManagerDict(blockKey, charList, context);
		}
		else
		{
			charList = _shopManagerDict[blockKey];
		}
		charList.GetCollection()[index] = charId;
		if (setArtisanOrder && TryGetElement_BuildingBlocks(blockKey, out var blockData) && BuildingBlock.Instance[blockData.TemplateId].ArtisanOrderAvailable)
		{
			DomainManager.Extra.SetBuildingOrderArtisan(context, blockKey, charList.GetCollection()[0]);
		}
		SetElement_ShopManagerDict(blockKey, charList, context);
	}

	public void SetElementShopManagerDict(BuildingBlockKey blockKey, CharacterList charList, DataContext context)
	{
		SetElement_ShopManagerDict(blockKey, charList, context);
	}

	public bool IsShopManager(int charId)
	{
		VillagerWorkData workData;
		return DomainManager.Taiwu.TryGetElement_VillagerWork(charId, out workData) && workData.WorkType == 1;
	}

	public sbyte GetCollectBuildingResourceType(BuildingBlockKey blockKey)
	{
		BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
		BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
		if (!configData.IsCollectResourceBuilding)
		{
			throw new Exception($"Building {blockData.TemplateId} is not a collect resource building");
		}
		if (_CollectBuildingResourceType.ContainsKey(blockKey))
		{
			return _CollectBuildingResourceType[blockKey];
		}
		BuildingBlockItem resourceConfig = BuildingBlock.Instance[configData.DependBuildings[0]];
		for (int i = 0; i < resourceConfig.CollectResourcePercent.Length; i++)
		{
			if (resourceConfig.CollectResourcePercent[i] > 0)
			{
				return (sbyte)i;
			}
		}
		throw new Exception($"Building {blockData.TemplateId} has no collectable resource type");
	}

	public sbyte GetLifeSkillByResourceType(sbyte resourceType)
	{
		return (sbyte)((resourceType < 6) ? Config.ResourceType.Instance[resourceType].LifeSkillType : 9);
	}

	[DomainMethod]
	public BuildingFormulaContextBridge GetBuildingFormulaContextBridge(BuildingBlockKey blockKey)
	{
		BuildingBlockData blockData = GetBuildingBlockData(blockKey);
		_formulaContextBridge.Initialize(blockKey, blockData.ConfigData, _formulaArgHandler, cacheAllArgs: true);
		return _formulaContextBridge;
	}

	public int GetShopBuildingMaxAttainmentWhetherCanWork(BuildingBlockKey blockKey, bool isAverage = false)
	{
		int resourceAttainment = 0;
		DomainManager.Building.TryGetElement_ShopManagerDict(blockKey, out var managerList);
		for (int i = 0; i < managerList.GetCount(); i++)
		{
			int charId = managerList.GetCollection()[i];
			if (charId >= 0)
			{
				GameData.Domains.Character.Character manageChar = DomainManager.Character.GetElement_Objects(charId);
				resourceAttainment += BaseWorkContribution;
				resourceAttainment += manageChar.GetMaxCombatSkillAttainment();
			}
		}
		return isAverage ? (resourceAttainment / managerList.GetCount()) : resourceAttainment;
	}

	public int GetSpecialBuildingAttainment(BuildingBlockData blockData, BuildingBlockKey blockKey, bool isAverage = false)
	{
		int resourceAttainment = 0;
		DomainManager.Building.TryGetElement_ShopManagerDict(blockKey, out var managerList);
		for (int i = 0; i < managerList.GetCount(); i++)
		{
			int charId = managerList.GetCollection()[i];
			if (charId >= 0 && DomainManager.Taiwu.CanWork(charId))
			{
				GameData.Domains.Character.Character manageChar = DomainManager.Character.GetElement_Objects(charId);
				resourceAttainment += BaseWorkContribution;
				resourceAttainment += manageChar.GetLifeSkillAttainment(BuildingBlock.Instance[blockData.TemplateId].RequireLifeSkillType);
			}
		}
		return isAverage ? (resourceAttainment / managerList.GetCount()) : resourceAttainment;
	}

	public int GetShopBuildingAttainmentWhetherCanWork(BuildingBlockData blockData, BuildingBlockKey blockKey, bool isAverage = false)
	{
		int resourceAttainment = 0;
		DomainManager.Building.TryGetElement_ShopManagerDict(blockKey, out var managerList);
		for (int i = 0; i < managerList.GetCount(); i++)
		{
			int charId = managerList.GetCollection()[i];
			if (charId >= 0)
			{
				GameData.Domains.Character.Character manageChar = DomainManager.Character.GetElement_Objects(charId);
				resourceAttainment += BaseWorkContribution;
				resourceAttainment += manageChar.GetLifeSkillAttainment(BuildingBlock.Instance[blockData.TemplateId].RequireLifeSkillType);
			}
		}
		return isAverage ? (resourceAttainment / managerList.GetCount()) : resourceAttainment;
	}

	[DomainMethod]
	public int GetBuildingAttainment(BuildingBlockData blockData, BuildingBlockKey blockKey, bool isAverage = false)
	{
		bool hasManager;
		int value = (isAverage ? BuildingTotalAverageAttainment(blockKey, -1, out hasManager) : (UseMaxAttainment(blockData) ? BuildingMaxAttainment(blockKey, -1, out hasManager) : BuildingTotalAttainment(blockKey, -1, out hasManager)));
		return hasManager ? value : 0;
	}

	private bool UseMaxAttainment(BuildingBlockData blockData)
	{
		BuildingBlockItem configData = blockData.ConfigData;
		if (configData != null)
		{
			List<short> expandInfos = configData.ExpandInfos;
			if (expandInfos != null && expandInfos.Count > 0)
			{
				foreach (short scaleId in configData.ExpandInfos)
				{
					int formulaId = BuildingScale.Instance[scaleId].Formula;
					if (formulaId < 0)
					{
						continue;
					}
					BuildingFormulaItem formula = BuildingFormula.Instance[formulaId];
					EBuildingFormulaArgType[] arguments = formula.Arguments;
					if (arguments == null || arguments.Length <= 0)
					{
						continue;
					}
					EBuildingFormulaArgType[] arguments2 = formula.Arguments;
					for (int i = 0; i < arguments2.Length; i++)
					{
						if (arguments2[i] == EBuildingFormulaArgType.MaxAttainment)
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	[DomainMethod]
	public int[] GetBuildingShopManagerAutoArrangeSorted(BuildingBlockKey blockKey, int[] managerCharacterIds)
	{
		if (managerCharacterIds == null)
		{
			return Array.Empty<int>();
		}
		Dictionary<int, (int, int, int)> values = new Dictionary<int, (int, int, int)>();
		if (TryGetElement_BuildingBlocks(blockKey, out var blockData))
		{
			BuildingBlockItem blockConfig = BuildingBlock.Instance.GetItem(blockData.TemplateId);
			if (blockConfig != null)
			{
				sbyte lifeSkillType = GetNeedLifeSkillType(blockConfig, blockKey);
				foreach (int managerCharId in managerCharacterIds)
				{
					if (DomainManager.Character.TryGetElement_Objects(managerCharId, out var managerChar))
					{
						short partAttainment = managerChar.GetLifeSkillAttainment(lifeSkillType);
						int partSuccessRate = BuildingManageHarvestSuccessRate(blockKey, managerCharId) * 2;
						int partSpecialRate = BuildingManageHarvestSpecialSuccessRate(blockKey, managerCharId) / 2;
						(int, int, int) value = (partAttainment, partSuccessRate, partSpecialRate);
						values[managerCharId] = value;
					}
				}
			}
		}
		int[] result = managerCharacterIds.ToArray();
		Array.Sort(result, delegate(int charIdA, int charIdB)
		{
			values.TryGetValue(charIdA, out var value2);
			values.TryGetValue(charIdB, out var value3);
			int num = (value3.Item1 + value3.Item2 + value3.Item3).CompareTo(value2.Item1 + value2.Item2 + value2.Item3);
			if (num == 0)
			{
				num = charIdA.CompareTo(charIdB);
			}
			return num;
		});
		return result;
	}

	public bool IsDependKungfuPracticeRoom(BuildingBlockItem config)
	{
		return config.DependBuildings.Count > 0 && config.DependBuildings[0] == 52 && config.IsShop;
	}

	public int GetBuildingAttainmentUniversalWhetherCanWork(BuildingBlockData blockData, BuildingBlockKey blockKey, bool isAverage = false)
	{
		bool hasManager;
		return BuildingTotalAttainment(blockKey, -1, out hasManager, ignoreCanWork: true);
	}

	public int CalcResourceChangeFactor(BuildingBlockData blockData)
	{
		BuildingBlockItem dependConfig = BuildingBlock.Instance[BuildingBlock.Instance[blockData.TemplateId].DependBuildings[0]];
		int factor = 1;
		for (int i = 0; i < dependConfig.CollectResourcePercent.Length; i++)
		{
			if (dependConfig.CollectResourcePercent[i] != 0)
			{
				factor = dependConfig.CollectResourcePercent[i];
				break;
			}
		}
		return factor;
	}

	private void BuildingRemoveVillagerWork(DataContext context, BuildingBlockKey blockKey)
	{
		RemoveAllOperatorsInBuilding(context, blockKey);
		RemoveAllManagersInBuilding(context, blockKey);
	}

	private void BuildingRemoveResident(DataContext context, BuildingBlockData blockData, BuildingBlockKey blockKey)
	{
		if (blockData.TemplateId == 46)
		{
			RemoveResidence(context, blockKey);
		}
		else if (blockData.TemplateId == 47)
		{
			RemoveComfortableHouse(context, blockKey);
		}
	}

	public bool IsHaveSpecifyBuilding(short templateId, GameData.Domains.Character.Character character)
	{
		foreach (KeyValuePair<BuildingBlockKey, BuildingBlockData> pair in _buildingBlocks)
		{
			if (pair.Value.TemplateId == templateId && pair.Value.CanUse() && character.GetLocation().AreaId == pair.Key.AreaId && character.GetLocation().BlockId == pair.Key.BlockId)
			{
				return true;
			}
		}
		return false;
	}

	public (BuildingBlockKey, BuildingBlockData) GetSpecifyBuildingBlockData(short templateId)
	{
		foreach (KeyValuePair<BuildingBlockKey, BuildingBlockData> pair in _buildingBlocks)
		{
			if (pair.Value.TemplateId == templateId && pair.Value.CanUse())
			{
				return (pair.Key, pair.Value);
			}
		}
		return (BuildingBlockKey.Invalid, null);
	}

	public unsafe int CreateCharacterByRecruitCharacterData(DataContext context, RecruitCharacterData recruitCharacterData)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		recruitCharacterData.Recalculate();
		OrganizationInfo orgInfo = taiwuChar.GetOrganizationInfo();
		orgInfo.Grade = 0;
		IntelligentCharacterCreationInfo intelligentCharacterCreationInfo = new IntelligentCharacterCreationInfo(location, orgInfo, recruitCharacterData.TemplateId);
		intelligentCharacterCreationInfo.Age = recruitCharacterData.Age;
		intelligentCharacterCreationInfo.BirthMonth = recruitCharacterData.BirthMonth;
		intelligentCharacterCreationInfo.Gender = recruitCharacterData.Gender;
		intelligentCharacterCreationInfo.Transgender = recruitCharacterData.Transgender;
		intelligentCharacterCreationInfo.BaseAttraction = recruitCharacterData.BaseAttraction;
		intelligentCharacterCreationInfo.Avatar = recruitCharacterData.AvatarData;
		intelligentCharacterCreationInfo.CombatSkillQualificationGrowthType = recruitCharacterData.CombatSkillQualificationGrowthType;
		intelligentCharacterCreationInfo.LifeSkillQualificationGrowthType = recruitCharacterData.LifeSkillQualificationGrowthType;
		intelligentCharacterCreationInfo.InitializeSectSkills = false;
		intelligentCharacterCreationInfo.AllowRandomGrowingGradeAdjust = false;
		intelligentCharacterCreationInfo.GrowingSectGrade = recruitCharacterData.PeopleLevel;
		intelligentCharacterCreationInfo.DisableBeReincarnatedBySavedSoul = true;
		IntelligentCharacterCreationInfo info = intelligentCharacterCreationInfo;
		GameData.Domains.Character.Character character = DomainManager.Character.CreateIntelligentCharacter(context, ref info);
		int charId = character.GetId();
		DomainManager.Character.CompleteCreatingCharacter(charId);
		character.SetBaseMorality(recruitCharacterData.GetBaseMorality(), context);
		character.SetFullName(recruitCharacterData.FullName, context);
		character.SetFeatureIds(recruitCharacterData.FeatureIds.ToList(), context);
		short clothingTemplateId = recruitCharacterData.ClothingTemplateId;
		if (clothingTemplateId >= 0)
		{
			ItemKey cloth = character.GetEquipment()[4];
			if (cloth.TemplateId != clothingTemplateId)
			{
				EquipmentBase destItem = DomainManager.Item.GetBaseEquipment(cloth);
				destItem.ResetOwner();
				destItem.SetOwner(ItemOwnerType.CharacterEquipment, charId);
				ItemKey itemKey = DomainManager.Item.CreateItem(context, 3, clothingTemplateId);
				character.AddInventoryItem(context, itemKey, 1);
				character.ChangeEquipment(context, -1, 4, itemKey);
				bool flag = false;
			}
		}
		DomainManager.Extra.SetCharTeammateCommands(context, charId, new SByteList(recruitCharacterData.TeammateCommands));
		MainAttributes origin = recruitCharacterData.MainAttributes;
		MainAttributes basic = character.GetBaseMainAttributes();
		MainAttributes result = character.GetMaxMainAttributes();
		for (int i = 0; i < 6; i++)
		{
			int delta = origin.Items[i] - result.Items[i];
			ref short reference = ref basic.Items[i];
			reference += (short)delta;
			basic.Items[i] = Math.Max(basic.Items[i], (short)0);
		}
		character.SetBaseMainAttributes(basic, context);
		character.SetCurrMainAttributes(character.GetMaxMainAttributes(), context);
		CombatSkillShorts origin2 = recruitCharacterData.CombatSkillQualifications;
		CombatSkillShorts basic2 = character.GetBaseCombatSkillQualifications();
		CombatSkillShorts result2 = character.GetCombatSkillQualifications();
		for (int j = 0; j < 14; j++)
		{
			int delta2 = origin2.Items[j] - result2.Items[j];
			ref short reference2 = ref basic2.Items[j];
			reference2 += (short)delta2;
			basic2.Items[j] = Math.Max(basic2.Items[j], (short)0);
		}
		character.SetBaseCombatSkillQualifications(ref basic2, context);
		LifeSkillShorts origin3 = recruitCharacterData.LifeSkillQualifications;
		LifeSkillShorts basic3 = character.GetBaseLifeSkillQualifications();
		LifeSkillShorts result3 = character.GetLifeSkillQualifications();
		for (int k = 0; k < 16; k++)
		{
			int delta3 = origin3.Items[k] - result3.Items[k];
			ref short reference3 = ref basic3.Items[k];
			reference3 += (short)delta3;
			basic3.Items[k] = Math.Max(basic3.Items[k], (short)0);
		}
		character.SetBaseLifeSkillQualifications(ref basic3, context);
		return charId;
	}

	public void UpdateBuildingEffect()
	{
		UpdateAllAreaBuildingBlockEffectsCache();
		TriggerCacheUpdate();
	}

	private void UpdateTaiwuVillageBuildingEffect()
	{
		foreach (Location location in _taiwuBuildingAreas)
		{
			UpdateLocationBuildingBlockEffectsCache(location);
		}
		TriggerCacheUpdate();
		_needUpdateEffects = false;
	}

	private void TriggerCacheUpdate()
	{
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		List<short> settlementBlocks = ObjectPool<List<short>>.Instance.Get();
		DomainManager.Map.GetSettlementBlocksAndAffiliatedBlocks(taiwuVillageLocation.AreaId, taiwuVillageLocation.BlockId, settlementBlocks);
		DataContext context = DataContextManager.GetCurrentThreadDataContext();
		for (int i = 0; i < settlementBlocks.Count; i++)
		{
			MapBlockData blockData = DomainManager.Map.GetBlockData(taiwuVillageLocation.AreaId, settlementBlocks[i]);
			if (blockData.CharacterSet != null)
			{
				foreach (int charId in blockData.CharacterSet)
				{
					if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
					{
						character.SetLocation(character.GetLocation(), context);
					}
				}
			}
			if (blockData.InfectedCharacterSet == null)
			{
				continue;
			}
			foreach (int charId2 in blockData.InfectedCharacterSet)
			{
				if (DomainManager.Character.TryGetElement_Objects(charId2, out var character2))
				{
					character2.SetLocation(character2.GetLocation(), context);
				}
			}
		}
		HashSet<int> taiwuGroupCharIds = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		foreach (int charId3 in taiwuGroupCharIds)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId3, out var character3))
			{
				character3.SetLocation(character3.GetLocation(), context);
			}
		}
		ObjectPool<List<short>>.Instance.Return(settlementBlocks);
	}

	public void TriggerBuildingCompleteEvents(DataContext context)
	{
		foreach (BuildingBlockKey buildingKey in _newCompleteOperationBuildings)
		{
			BuildingBlockData blockData = GetBuildingBlockData(buildingKey);
			DomainManager.TaiwuEvent.OnEvent_ConstructComplete(buildingKey, blockData.TemplateId, BuildingBlockLevel(buildingKey));
		}
		_newCompleteOperationBuildings.Clear();
		SetNewCompleteOperationBuildings(_newCompleteOperationBuildings, context);
	}

	public void UpdateResourceBlockEffectsOnAdvanceMonth(DataContext context)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		foreach (KeyValuePair<Location, BuildingAreaData> buildingArea in _buildingAreas)
		{
			buildingArea.Deconstruct(out var key, out var value);
			Location location = key;
			BuildingAreaData buildingAreaData = value;
			(ResourceInts resourcesChange, int expGain) tuple = CalcResourceBlockIncomeEffects(location);
			ResourceInts resourcesChange = tuple.resourcesChange;
			int expGain = tuple.expGain;
			ResourceInts npcResChange = resourcesChange;
			FinalizeResourceBlockIncomeEffectValues(ref npcResChange, isTaiwu: false);
			Settlement settlement = DomainManager.Organization.GetSettlementByLocation(location);
			OrgMemberCollection members = settlement.GetMembers();
			bool hasResources = resourcesChange.IsNonZero();
			bool hasExp = expGain > 0;
			if (!hasResources && !hasExp)
			{
				continue;
			}
			for (sbyte grade = 0; grade <= 8; grade++)
			{
				HashSet<int> gradeMembers = members.GetMembers(grade);
				foreach (int charId in gradeMembers)
				{
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
					if (!character.IsInteractableAsIntelligentCharacter())
					{
						continue;
					}
					if (hasResources)
					{
						if (charId == taiwuId)
						{
							ResourceInts taiwuResChange = resourcesChange;
							FinalizeResourceBlockIncomeEffectValues(ref taiwuResChange, isTaiwu: true);
							character.ChangeResources(context, ref taiwuResChange);
						}
						else
						{
							OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(character.GetOrganizationInfo());
							CValuePercent ratio = orgMemberCfg.ResourceIncomeRatio;
							ResourceInts charResChange = npcResChange;
							for (sbyte resType = 0; resType < 8; resType++)
							{
								charResChange[resType] *= ratio;
							}
							character.ChangeResources(context, ref charResChange);
						}
					}
					if (hasExp)
					{
						character.ChangeExp(context, expGain);
						if (taiwuId == charId)
						{
							InstantNotificationCollection monthlyNotifications = DomainManager.World.GetInstantNotificationCollection();
							monthlyNotifications.AddBuildingExp(expGain);
						}
					}
				}
			}
		}
	}

	public void SerialUpdate(DataContext context)
	{
		List<Location> taiwuBuildingList = GetTaiwuBuildingAreas();
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		List<short> neighborList = ObjectPool<List<short>>.Instance.Get();
		List<short> expandedResourceList = ObjectPool<List<short>>.Instance.Get();
		List<(BuildingBlockKey, BuildingBlockData)> needMaintenanceList = new List<(BuildingBlockKey, BuildingBlockData)>();
		_newBrokenBuildings.Clear();
		for (int i = 0; i < taiwuBuildingList.Count; i++)
		{
			Location location = taiwuBuildingList[i];
			BuildingAreaData areaData = GetElement_BuildingAreas(location);
			MapAreaData mapAreaData = DomainManager.Map.GetElement_Areas(location.AreaId);
			int settlementIndex = DomainManager.Map.GetElement_Areas(location.AreaId).GetSettlementIndex(location.BlockId);
			short settlementId = mapAreaData.SettlementInfos[settlementIndex].SettlementId;
			expandedResourceList.Clear();
			needMaintenanceList.Clear();
			for (short index = 0; index < areaData.Width * areaData.Width; index++)
			{
				BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
				BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
				if (blockData.RootBlockIndex < 0)
				{
					BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
					if (configData.Type == EBuildingBlockType.Building || BuildingBlockData.IsResource(configData.Type))
					{
						if (configData.TemplateId == 45 && blockData.CanUse())
						{
							int tmp = CalculateGainAuthorityByShrinePerMonth(blockKey);
							taiwuChar.ChangeResource(context, 7, tmp);
						}
						if (blockData.Durability == 0 && BuildingBlockLevel(blockKey) == 1 && configData.DestoryType == 1)
						{
							int authorityAmount = GetAllTaiwuResources().Get(7);
							ConsumeResource(context, 7, Math.Min(authorityAmount, configData.MaxDurability));
						}
						if (configData.BaseMaintenanceCost.Count > 0 && blockData.NeedMaintenanceCost())
						{
							needMaintenanceList.Add((blockKey, blockData));
						}
						if (CanUpdateShopProgress(blockKey))
						{
							int buildingAttainment = GetBuildingAttainment(blockData, blockKey);
							int delta = SharedMethods.GetShopManageProgressDelta(blockData.TemplateId, buildingAttainment);
							int resBuildingBonus = GetBuildingBlockEffect(settlementId, EBuildingScaleEffect.ShopProgressBonus);
							delta *= (CValuePercentBonus)resBuildingBonus;
							blockData.OfflineChangeShopProgress(delta);
							SetElement_BuildingBlocks(blockKey, blockData, context);
						}
						if (BuildingBlockData.IsResource(configData.Type) && blockData.OperationType == -1 && !expandedResourceList.Contains(index))
						{
							sbyte buildingWidth = configData.Width;
							List<int> neighborDistanceList = ObjectPool<List<int>>.Instance.Get();
							List<short> neighborRangeOneList = ObjectPool<List<short>>.Instance.Get();
							areaData.GetNeighborBlocks(index, buildingWidth, neighborList, neighborDistanceList, 2);
							areaData.GetNeighborBlocks(index, buildingWidth, neighborRangeOneList);
							UpdateResourceBlock(context, settlementId, blockKey, blockData, neighborList, expandedResourceList, neighborDistanceList, neighborRangeOneList);
						}
					}
				}
			}
			foreach (var (blockKey2, blockData2) in needMaintenanceList)
			{
				if (!UpdateBlockMaintenance(context, blockKey2, blockData2, taiwuChar))
				{
					_newBrokenBuildings.Add(blockKey2);
				}
			}
			BuildingBlockKey samsaraPlatformKey = FindBuildingKey(location, areaData, 50);
			if (!samsaraPlatformKey.IsInvalid)
			{
				AddSamsaraPlatformProgress(context, BuildingBlockLevel(samsaraPlatformKey));
			}
		}
		ObjectPool<List<short>>.Instance.Return(neighborList);
		ObjectPool<List<short>>.Instance.Return(expandedResourceList);
		UpdateChickenInstances(context);
		ApplyCricketAuthorityGain(context);
		UpdateResidentsHappinessAndFavor(context);
		UpdateTeaHorseCaravan(context);
		UpdateStoneRoomData(context);
		UpdateKungfuPracticeRoom(context);
	}

	public int CalculateGainAuthorityByShrinePerMonth(BuildingBlockKey shrineBlockKey)
	{
		if (!HasShopManagerLeader(shrineBlockKey))
		{
			return 0;
		}
		sbyte fameType = BuildLeaderFameType(shrineBlockKey);
		bool hasManager;
		int attainment = BuildingTotalAttainment(shrineBlockKey, -1, out hasManager);
		return SharedMethods.GetTaiwuShrineEffect(fameType, attainment);
	}

	private void UpdateKungfuPracticeRoom(DataContext context)
	{
		if (!IsTaiwuVillageHaveSpecifyBuilding(52))
		{
			return;
		}
		List<sbyte> xiangshuIdList = DomainManager.Extra.GetXiangshuIdInKungfuPracticeRoom();
		for (sbyte i = 0; i < 9; i++)
		{
			if (DomainManager.World.GetXiangshuAvatarFavorabilityType(i) >= 3 && !xiangshuIdList.Contains(i))
			{
				xiangshuIdList.Add(i);
				MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
				switch (i)
				{
				case 0:
					monthlyEventCollection.AddVillageWoodenManByMonv();
					break;
				case 1:
					monthlyEventCollection.AddVillageWoodenManByDayueYaochang();
					break;
				case 2:
					monthlyEventCollection.AddVillageWoodenManByJiuhan();
					break;
				case 3:
					monthlyEventCollection.AddVillageWoodenManByJinHuanger();
					break;
				case 4:
					monthlyEventCollection.AddVillageWoodenManByYiYihou();
					break;
				case 5:
					monthlyEventCollection.AddVillageWoodenManByWeiQi();
					break;
				case 6:
					monthlyEventCollection.AddVillageWoodenManByYixiang();
					break;
				case 7:
					monthlyEventCollection.AddVillageWoodenManByXuefeng();
					break;
				case 8:
					monthlyEventCollection.AddVillageWoodenManByShuFang();
					break;
				}
			}
		}
		DomainManager.Extra.SetXiangshuIdInKungfuPracticeRoom(xiangshuIdList, context);
	}

	private void UpdateStoneRoomData(DataContext context)
	{
		List<GameData.Domains.Character.Character> characterList = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		List<GameData.Domains.Character.Character> characterListAll = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		List<Predicate<GameData.Domains.Character.Character>> predicates = ObjectPool<List<Predicate<GameData.Domains.Character.Character>>>.Instance.Get();
		predicates.Clear();
		characterListAll.Clear();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		sbyte taiwuConsummateLevel = DomainManager.Taiwu.GetTaiwu().GetConsummateLevel();
		if (taiwuConsummateLevel < 6)
		{
			return;
		}
		predicates.Add(CharacterMatchers.MatchNotCalledByAdventure);
		predicates.Add((GameData.Domains.Character.Character character) => CharacterMatchers.MatchConsummateLevel(character, 0, (sbyte)(taiwuConsummateLevel - 6)));
		for (short i = 0; i < 135; i++)
		{
			characterList.Clear();
			MapAreaData mapAreaData = DomainManager.Map.GetElement_Areas(i);
			if (mapAreaData.StationUnlocked)
			{
				MapCharacterFilter.FindInfected(predicates, characterList, i);
				if (characterList.Count != 0)
				{
					characterListAll.AddRange(characterList);
				}
			}
		}
		int num = context.Random.Next(1, 4);
		num = Math.Min(characterListAll.Count, num);
		for (int j = 0; j < num; j++)
		{
			if (DomainManager.Extra.IsStoneRoomFull())
			{
				break;
			}
			int index = context.Random.Next(0, characterListAll.Count);
			GameData.Domains.Character.Character selectedChar = characterListAll[index];
			int charId = selectedChar.GetId();
			Location srcLocation = selectedChar.GetLocation();
			CollectionUtils.SwapAndRemove(characterListAll, index);
			if (selectedChar.IsActiveExternalRelationState(32uL))
			{
				Logger.AppendWarning($"Trying to add {selectedChar} at {srcLocation} to stone room when the character is already in settlement prison.");
			}
			else if (selectedChar.IsActiveExternalRelationState(8uL))
			{
				Logger.AppendWarning($"Trying to add {selectedChar} at {srcLocation} to stone room when the character is already in stone room.");
			}
			else if (context.Random.CheckPercentProb(GlobalConfig.Instance.ImprisonInStoneHouseChance))
			{
				DomainManager.Extra.AddStoneRoomCharacter(context, selectedChar);
				short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
				monthlyNotifications.AddStoneHouseInfectedKidnapped(settlementId, charId);
				lifeRecordCollection.AddXiangshuInfectedPrisonTaiwuVillage(charId, currDate, srcLocation);
			}
			else
			{
				sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(srcLocation.AreaId);
				sbyte sectId = MapState.Instance[stateTemplateId].SectID;
				Sect sect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(sectId);
				sect.AddPrisoner(context, selectedChar, 40);
				lifeRecordCollection.AddXiangshuInfectedPrisonSettlement(charId, currDate, srcLocation, sect.GetId());
			}
		}
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(characterList);
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(characterListAll);
		ObjectPool<List<Predicate<GameData.Domains.Character.Character>>>.Instance.Return(predicates);
	}

	public sbyte GetResourceBlockGrowthChance(BuildingBlockKey blockKey)
	{
		BuildingBlockData blockData = GetBuildingBlockData(blockKey);
		BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
		if (BuildingBlockLevel(blockKey) >= configData.MaxLevel)
		{
			return 0;
		}
		int buildingAddGrowthOdds = 0;
		BuildingAreaData areaData = GetBuildingAreaData(blockKey.GetLocation());
		List<short> neighborList = ObjectPool<List<short>>.Instance.Get();
		List<int> neighborDistanceList = ObjectPool<List<int>>.Instance.Get();
		areaData.GetNeighborBlocks(blockKey.BuildingBlockIndex, configData.Width, neighborList, neighborDistanceList, 2);
		for (int j = 0; j < neighborList.Count; j++)
		{
			BuildingBlockKey neighborKey = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborList[j]);
			BuildingBlockData neighborBlock = GetElement_BuildingBlocks(neighborKey);
			sbyte neighborLevel = BuildingBlockLevel(neighborKey);
			if (neighborBlock.RootBlockIndex >= 0)
			{
				neighborKey = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborBlock.RootBlockIndex);
				neighborBlock = GetElement_BuildingBlocks(neighborKey);
			}
			BuildingBlockItem neighborConfig = BuildingBlock.Instance[neighborBlock.TemplateId];
			if (!neighborConfig.IsCollectResourceBuilding || neighborConfig.DependBuildings[0] != blockData.TemplateId || !neighborBlock.CanUse() || !_shopManagerDict.ContainsKey(neighborKey))
			{
				continue;
			}
			List<int> managerList = _shopManagerDict[neighborKey].GetCollection();
			int expansionProgressGain = 0;
			bool hasValidManager = false;
			foreach (int charId in managerList)
			{
				if (charId >= 0 && DomainManager.Taiwu.CanWork(charId))
				{
					GameData.Domains.Character.Character manageChar = DomainManager.Character.GetElement_Objects(charId);
					expansionProgressGain += manageChar.GetLifeSkillAttainment(configData.RequireLifeSkillType);
					hasValidManager = true;
				}
			}
			if (hasValidManager)
			{
				buildingAddGrowthOdds += neighborLevel * (50 + expansionProgressGain) / 100;
			}
		}
		ObjectPool<List<short>>.Instance.Return(neighborList);
		ObjectPool<List<int>>.Instance.Return(neighborDistanceList);
		int totalChance = buildingAddGrowthOdds * blockData.Durability / configData.MaxDurability;
		return (sbyte)Math.Clamp(totalChance, 0, 100);
	}

	public sbyte GetResourceBlockExpandChance(BuildingBlockKey blockKey)
	{
		BuildingBlockData blockData = GetBuildingBlockData(blockKey);
		BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
		if (BuildingBlockLevel(blockKey) >= configData.MaxLevel)
		{
			return 0;
		}
		int buildingAddExpandOdds = 0;
		BuildingAreaData areaData = GetBuildingAreaData(blockKey.GetLocation());
		List<short> neighborList = ObjectPool<List<short>>.Instance.Get();
		List<int> neighborDistanceList = ObjectPool<List<int>>.Instance.Get();
		areaData.GetNeighborBlocks(blockKey.BuildingBlockIndex, configData.Width, neighborList, neighborDistanceList, 2);
		for (int j = 0; j < neighborList.Count; j++)
		{
			BuildingBlockKey neighborKey = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborList[j]);
			BuildingBlockData neighborBlock = GetElement_BuildingBlocks(neighborKey);
			if (neighborBlock.RootBlockIndex >= 0)
			{
				neighborKey = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborBlock.RootBlockIndex);
				neighborBlock = GetElement_BuildingBlocks(neighborKey);
			}
			BuildingBlockItem neighborConfig = BuildingBlock.Instance[neighborBlock.TemplateId];
			if (!neighborConfig.IsCollectResourceBuilding || neighborConfig.DependBuildings[0] != blockData.TemplateId || !neighborBlock.CanUse() || !_shopManagerDict.ContainsKey(neighborKey))
			{
				continue;
			}
			List<int> managerList = _shopManagerDict[neighborKey].GetCollection();
			int expansionProgressGain = 0;
			bool hasValidManager = false;
			foreach (int charId in managerList)
			{
				if (charId >= 0 && DomainManager.Taiwu.CanWork(charId))
				{
					GameData.Domains.Character.Character manageChar = DomainManager.Character.GetElement_Objects(charId);
					expansionProgressGain += manageChar.GetLifeSkillAttainment(configData.RequireLifeSkillType);
					hasValidManager = true;
				}
			}
			if (hasValidManager)
			{
				buildingAddExpandOdds += BuildingBlockLevel(blockKey) * (50 + expansionProgressGain) / 100;
			}
		}
		ObjectPool<List<short>>.Instance.Return(neighborList);
		ObjectPool<List<int>>.Instance.Return(neighborDistanceList);
		int totalChance = buildingAddExpandOdds * blockData.Durability / configData.MaxDurability;
		return (sbyte)Math.Clamp(totalChance, 0, 100);
	}

	private void UpdateResourceBlock(DataContext context, short settlementId, BuildingBlockKey blockKey, BuildingBlockData blockData, List<short> neighborList, List<short> expandedResourceList, List<int> neighborDistanceList, List<short> neighborRangeOneList)
	{
		BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
		IRandomSource random = context.Random;
		int buildingAddGrowthOdds = 0;
		int buildingAddExpandOdds = 0;
		for (int j = 0; j < neighborList.Count; j++)
		{
			BuildingBlockKey neighborKey = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborList[j]);
			BuildingBlockData neighborBlock = GetElement_BuildingBlocks(neighborKey);
			sbyte neighborLevel = BuildingBlockLevel(neighborKey);
			if (neighborBlock.RootBlockIndex >= 0)
			{
				neighborKey = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborBlock.RootBlockIndex);
				neighborBlock = GetElement_BuildingBlocks(neighborKey);
			}
			BuildingBlockItem neighborConfig = BuildingBlock.Instance[neighborBlock.TemplateId];
			if (!neighborConfig.IsCollectResourceBuilding || neighborConfig.DependBuildings[0] != blockData.TemplateId || !neighborBlock.CanUse() || !_shopManagerDict.ContainsKey(neighborKey))
			{
				continue;
			}
			List<int> managerList = _shopManagerDict[neighborKey].GetCollection();
			sbyte resourceType = GetCollectBuildingResourceType(neighborKey);
			sbyte getResourceType = (sbyte)((resourceType < 6) ? resourceType : 5);
			sbyte lifeSkillType = (sbyte)((resourceType < 6) ? Config.ResourceType.Instance[resourceType].LifeSkillType : 9);
			int expansionProgressGain = 0;
			int manageProgressGain = 0;
			bool hasValidManager = false;
			foreach (int charId in managerList)
			{
				if (charId >= 0 && DomainManager.Taiwu.CanWork(charId))
				{
					GameData.Domains.Character.Character manageChar = DomainManager.Character.GetElement_Objects(charId);
					expansionProgressGain += manageChar.GetLifeSkillAttainment(configData.RequireLifeSkillType);
					hasValidManager = true;
				}
			}
			manageProgressGain = SharedMethods.GetShopManageProgressDelta(neighborConfig.TemplateId, BuildingTotalAttainment(neighborKey, resourceType, out var hasManager));
			int resBuildingBonus = GetBuildingBlockEffect(settlementId, EBuildingScaleEffect.ShopProgressBonus);
			manageProgressGain *= (CValuePercentBonus)resBuildingBonus;
			if (hasValidManager && hasManager)
			{
				buildingAddGrowthOdds += neighborLevel * (50 + expansionProgressGain) / 100;
				buildingAddExpandOdds += neighborLevel * (50 + expansionProgressGain) / 100;
			}
		}
		bool blockDataChanged = false;
		if (blockData.Durability < configData.MaxDurability)
		{
			blockData.Durability++;
			blockDataChanged = true;
		}
		if (blockDataChanged)
		{
			SetElement_BuildingBlocks(blockKey, blockData, context);
		}
	}

	private bool UpdateBlockMaintenance(DataContext context, BuildingBlockKey blockKey, BuildingBlockData blockData, GameData.Domains.Character.Character taiwuChar)
	{
		BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
		bool enough = true;
		ResourceInts resource = GetAllTaiwuResources();
		int[] resourceCosts = SharedMethods.GetFinalMaintenanceCost(configData);
		for (sbyte resType = 0; resType < resourceCosts.Length; resType++)
		{
			if (resource.Get(resType) < resourceCosts[resType])
			{
				enough = false;
				break;
			}
		}
		if (enough)
		{
			for (sbyte resType2 = 0; resType2 < resourceCosts.Length; resType2++)
			{
				ConsumeResource(context, resType2, resourceCosts[resType2]);
			}
		}
		return enough;
	}

	public void UpdateBrokenBuildings(DataContext context)
	{
		foreach (BuildingBlockKey blockKey in _newBrokenBuildings)
		{
			BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
			BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
			MapAreaData mapAreaData = DomainManager.Map.GetElement_Areas(blockKey.AreaId);
			int settlementIndex = mapAreaData.GetSettlementIndex(blockKey.BlockId);
			short settlementId = mapAreaData.SettlementInfos[settlementIndex].SettlementId;
			blockData.Durability--;
			if (blockData.Durability > 0)
			{
				SetElement_BuildingBlocks(blockKey, blockData, context);
				continue;
			}
			blockData.Durability = 0;
			MakeBlockDestroy(context, configData, settlementId, blockData, blockKey);
			SetElement_BuildingBlocks(blockKey, blockData, context);
		}
		if (_newBrokenBuildings.Count > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 315);
		}
		UpdateTaiwuVillageBuildingEffect();
	}

	private void MakeBlockDestroy(DataContext context, BuildingBlockItem configData, short settlementId, BuildingBlockData blockData, BuildingBlockKey blockKey)
	{
		if (configData.DestoryType == 0)
		{
			MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
			monthlyNotifications.AddBuildingRuined(settlementId, blockData.TemplateId);
			BuildingRemoveResident(context, blockData, blockKey);
			BuildingRemoveVillagerWork(context, blockKey);
			ClearBuildingBlockEarningsData(context, blockKey, blockData.TemplateId == 222);
			ResetAllChildrenBlocks(context, blockKey, 23, 1);
			blockData.ResetData(23, 1, -1);
		}
		else if (configData.DestoryType == 1)
		{
			InstantNotificationCollection instantNotifications = DomainManager.World.GetInstantNotificationCollection();
			instantNotifications.AddBuildingLoseAuthority(settlementId, blockData.TemplateId);
		}
	}

	public void ParallelUpdate(DataContext context)
	{
		_shopManagerUpgradeQualificationDict.Clear();
		foreach (KeyValuePair<BuildingBlockKey, BuildingBlockData> entry in _buildingBlocks)
		{
			BuildingBlockKey blockKey = entry.Key;
			BuildingBlockData blockData = entry.Value;
			if (blockData.RootBlockIndex >= 0)
			{
				continue;
			}
			BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
			if (configData.Type == EBuildingBlockType.Building || BuildingBlockData.IsResource(configData.Type) || configData.TemplateId == 44)
			{
				ParallelBuildingModification modification = new ParallelBuildingModification
				{
					BlockKey = blockKey,
					BlockData = blockData
				};
				MapAreaData areaData = DomainManager.Map.GetElement_Areas(blockKey.AreaId);
				int settlementIndex = DomainManager.Map.GetElement_Areas(blockKey.AreaId).GetSettlementIndex(blockKey.BlockId);
				short settlementId = areaData.SettlementInfos[settlementIndex].SettlementId;
				if (blockData.CanUse() && configData.IsShop)
				{
					OfflineUpdateShopManagement(modification, settlementId, configData, blockKey, blockData, context);
				}
				OfflineUpdateOperation(context, modification, settlementId, configData, blockKey, blockData);
				ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
				recorder.RecordType(ParallelModificationType.UpdateBuilding);
				recorder.RecordParameterClass(modification);
			}
		}
	}

	public void TutorialUpdate(DataContext context)
	{
		foreach (KeyValuePair<BuildingBlockKey, BuildingBlockData> entry in _buildingBlocks)
		{
			BuildingBlockKey blockKey = entry.Key;
			BuildingBlockData blockData = entry.Value;
			if (blockData.RootBlockIndex < 0)
			{
				BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
				if (configData.TemplateId == 258 && blockData.OperationType == 0 && DomainManager.Taiwu.VillagerHasWork(DomainManager.Taiwu.GetTaiwuCharId()))
				{
					blockData.LevelUnlockedFlags = 1uL;
					blockData.Durability = configData.MaxDurability;
					blockData.OperationType = -1;
					blockData.OperationProgress = 0;
					int settlementIndex = DomainManager.Map.GetElement_Areas(blockKey.AreaId).GetSettlementIndex(blockKey.BlockId);
					MapAreaData areaData = DomainManager.Map.GetElement_Areas(blockKey.AreaId);
					short settlementId = areaData.SettlementInfos[settlementIndex].SettlementId;
					MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
					monthlyNotifications.AddBuildingConstructionCompleted(settlementId, blockData.TemplateId);
					DomainManager.Taiwu.RemoveVillagerWork(context, DomainManager.Taiwu.GetTaiwuCharId());
				}
			}
		}
	}

	[DomainMethod]
	public void SetNextTeaHorseCaravanEvent(short eventTemplateId)
	{
		_nextTeaHorseEventId = eventTemplateId;
	}

	[DomainMethod]
	public TeaHorseCaravanData GetTeaHorseCaravanData(DataContext context)
	{
		return _teaHorseCaravanData;
	}

	private void UpdateTeaHorseCaravan(DataContext context)
	{
		if (_teaHorseCaravanData == null || _teaHorseCaravanData.CaravanState < 1 || _teaHorseCaravanData.CaravanState == 4)
		{
			return;
		}
		_teaHorseCaravanData.IsShowExchangeReplenishment = false;
		if (_teaHorseCaravanData.CaravanState == 1)
		{
			_teaHorseCaravanData.CaravanState = 2;
		}
		if (_teaHorseCaravanData.StartMonth >= 360)
		{
			MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
			monthlyNotifications.AddWesternMerchantBackAfterLong();
			_teaHorseCaravanData.CaravanState = 4;
			_teaHorseCaravanData.IsShowExchangeReplenishment = false;
			_teaHorseCaravanData.IsShowSeachReplenishment = false;
			_teaHorseCaravanData.DistanceToTaiwuVillage = 0;
			_teaHorseCaravanData.Terrain = 5;
		}
		_teaHorseCaravanData.StartMonth++;
		if (_teaHorseCaravanData.IsStartSearch)
		{
			_teaHorseCaravanData.IsStartSearch = false;
			return;
		}
		sbyte currSolarTerm = DomainManager.World.GetCurrMonthInYear();
		List<TeaHorseCaravanTerrainItem> terrainList = new List<TeaHorseCaravanTerrainItem>();
		for (short i = 0; i < TeaHorseCaravanTerrain.Instance.Count; i++)
		{
			terrainList.Add(TeaHorseCaravanTerrain.Instance.GetItem(i));
		}
		IEnumerable<(short, short)> terrainWeights = terrainList.Select((TeaHorseCaravanTerrainItem a) => ((short TemplateId, short))(TemplateId: a.TemplateId, a.Weighted));
		short terrainTemplateId = RandomUtils.GetRandomResult(terrainWeights, context.Random);
		_teaHorseCaravanData.Terrain = terrainTemplateId;
		List<TeaHorseCaravanWeatherItem> weatherList = new List<TeaHorseCaravanWeatherItem>();
		for (short i2 = 0; i2 < TeaHorseCaravanWeather.Instance.Count; i2++)
		{
			TeaHorseCaravanWeatherItem item = TeaHorseCaravanWeather.Instance.GetItem(i2);
			if (item.NeedSolarTerms.Contains(currSolarTerm) && item.NeedTerrain.Contains((sbyte)terrainTemplateId))
			{
				weatherList.Add(TeaHorseCaravanWeather.Instance.GetItem(i2));
			}
		}
		IEnumerable<(short, short)> weatherWeights = weatherList.Select((TeaHorseCaravanWeatherItem a) => ((short TemplateId, short))(TemplateId: a.TemplateId, a.Weighted));
		short weatherTemplateId = RandomUtils.GetRandomResult(weatherWeights, context.Random);
		int lostProb = ((_teaHorseCaravanData.LackReplenishmentTurn > 10) ? 100 : ((_teaHorseCaravanData.LackReplenishmentTurn > 0) ? ((int)Math.Min(100f, MathF.Pow(2f, _teaHorseCaravanData.LackReplenishmentTurn - 1))) : 0));
		if (lostProb > 0 && context.Random.CheckProb(lostProb, 100))
		{
			if (context.Random.Next(2) == 0)
			{
				if (_teaHorseCaravanData.CarryGoodsList.Count > 0)
				{
					int index = context.Random.Next(_teaHorseCaravanData.CarryGoodsList.Count);
					ItemKey lostItem = _teaHorseCaravanData.CarryGoodsList[index].Item1;
					_teaHorseCaravanData.CarryGoodsList.RemoveAt(index);
					DomainManager.Item.RemoveItem(context, lostItem);
				}
				else if (_teaHorseCaravanData.ExchangeGoodsList.Count > 0)
				{
					int index2 = context.Random.Next(_teaHorseCaravanData.ExchangeGoodsList.Count);
					_teaHorseCaravanData.ExchangeGoodsList.RemoveAt(index2);
				}
			}
			else if (_teaHorseCaravanData.ExchangeGoodsList.Count > 0)
			{
				int index3 = context.Random.Next(_teaHorseCaravanData.ExchangeGoodsList.Count);
				_teaHorseCaravanData.ExchangeGoodsList.RemoveAt(index3);
			}
			else if (_teaHorseCaravanData.CarryGoodsList.Count > 0)
			{
				int index4 = context.Random.Next(_teaHorseCaravanData.CarryGoodsList.Count);
				ItemKey lostItem2 = _teaHorseCaravanData.CarryGoodsList[index4].Item1;
				_teaHorseCaravanData.CarryGoodsList.RemoveAt(index4);
				DomainManager.Item.RemoveItem(context, lostItem2);
			}
		}
		_teaHorseCaravanData.CaravanReplenishment = (short)Math.Clamp(_teaHorseCaravanData.CaravanReplenishment - _teaHorseCaravanData.GetReplenishmentCost(), 0, 100);
		if (_teaHorseCaravanData.CaravanReplenishment == 0)
		{
			_teaHorseCaravanData.LackReplenishmentTurn++;
			MonthlyNotificationCollection monthlyNotifications2 = DomainManager.World.GetMonthlyNotificationCollection();
			monthlyNotifications2.AddWesternMerchanLackReplenishment();
		}
		else
		{
			_teaHorseCaravanData.LackReplenishmentTurn = 0;
		}
		_teaHorseCaravanData.IsShowExchangeReplenishment = (_teaHorseCaravanData.IsShowSeachReplenishment = false);
		int padding = (ushort)_teaHorseCaravanData.StartMonth | (ushort)(_teaHorseCaravanData.DistanceToTaiwuVillage << 16);
		int date = DomainManager.World.GetCurrDate();
		short eventTemplateId = _nextTeaHorseEventId;
		TeaHorseCaravanEventItem eventConfig;
		if (eventTemplateId != -1)
		{
			eventConfig = TeaHorseCaravanEvent.Instance.GetItem(_nextTeaHorseEventId);
			_nextTeaHorseEventId = -1;
		}
		else
		{
			List<TeaHorseCaravanEventItem> eventList = new List<TeaHorseCaravanEventItem>();
			for (short i3 = 0; i3 < TeaHorseCaravanEvent.Instance.Count; i3++)
			{
				eventList.Add(TeaHorseCaravanEvent.Instance.GetItem(i3));
			}
			IEnumerable<(short, short)> eventWeights = eventList.Select((TeaHorseCaravanEventItem a) => ((short TemplateId, short))(TemplateId: a.TemplateId, a.Weighted));
			eventTemplateId = RandomUtils.GetRandomResult(eventWeights, context.Random);
			eventConfig = TeaHorseCaravanEvent.Instance.GetItem(eventTemplateId);
		}
		if (eventConfig.EventType == 0 && (eventConfig.ReplenishmentTrigger != 1 || _teaHorseCaravanData.CaravanReplenishment != 0))
		{
			_teaHorseCaravanData.IsShowExchangeReplenishment = true;
			_teaHorseCaravanData.ExchangeReplenishmentAmountMax = (short)context.Random.Next(eventConfig.ExchangeMin, eventConfig.ExchangeMax + 1);
			_teaHorseCaravanData.ExchangeReplenishmentRemainAmount = _teaHorseCaravanData.ExchangeReplenishmentAmountMax;
			if (eventTemplateId == 19)
			{
				_teaHorseCaravanEventCollection.AddFindVillage(padding, date, _teaHorseCaravanData.ExchangeReplenishmentAmountMax);
			}
			else
			{
				_teaHorseCaravanEventCollection.AddMeetMerchan(padding, date, _teaHorseCaravanData.ExchangeReplenishmentAmountMax);
			}
		}
		else if (eventConfig.EventType == 1 && (eventConfig.ReplenishmentTrigger != 1 || _teaHorseCaravanData.CaravanReplenishment != 0))
		{
			_teaHorseCaravanData.IsShowSeachReplenishment = true;
			_teaHorseCaravanData.SearchReplenishmentMax = (short)context.Random.Next(eventConfig.SearchMin, eventConfig.SearchMax + 1);
			_teaHorseCaravanData.SearchReplenishmentAmount = (short)context.Random.Next(eventConfig.SolarSearchMin, eventConfig.SolarSearchMax + 1);
			_teaHorseCaravanEventCollection.AddFindFruit(padding, date, _teaHorseCaravanData.SearchReplenishmentMax);
		}
		else if ((eventConfig.EventType == 2 || eventConfig.EventType == 3) && (eventConfig.ReplenishmentTrigger != 1 || _teaHorseCaravanData.CaravanReplenishment != 0))
		{
			_teaHorseCaravanData.CaravanAwareness = (short)Math.Clamp(_teaHorseCaravanData.CaravanAwareness + eventConfig.AwarenessChange, 0, 32767);
			switch (eventTemplateId)
			{
			case 0:
				_teaHorseCaravanEventCollection.AddFindMirage(padding, date, eventConfig.AwarenessChange);
				break;
			case 1:
				_teaHorseCaravanEventCollection.AddFindBigfoot(padding, date, eventConfig.AwarenessChange);
				break;
			case 2:
				_teaHorseCaravanEventCollection.AddFindAnimal(padding, date, eventConfig.AwarenessChange);
				break;
			case 3:
				_teaHorseCaravanEventCollection.AddFindPlant(padding, date, eventConfig.AwarenessChange);
				break;
			case 4:
				_teaHorseCaravanEventCollection.AddGetInformation(padding, date, eventConfig.AwarenessChange);
				break;
			case 5:
				_teaHorseCaravanEventCollection.AddFindSettlement(padding, date, eventConfig.AwarenessChange);
				break;
			case 6:
				_teaHorseCaravanEventCollection.AddFindWeather(padding, date, eventConfig.AwarenessChange);
				break;
			default:
				_teaHorseCaravanEventCollection.AddLost(padding, date, -eventConfig.AwarenessChange);
				break;
			}
		}
		else if (eventConfig.EventType == 4 && (eventConfig.ReplenishmentTrigger != 1 || _teaHorseCaravanData.CaravanReplenishment != 0))
		{
			sbyte grade = (sbyte)context.Random.Next(eventConfig.GetItemGradeMin, eventConfig.GetItemGradeMax + 1);
			ItemKey itemKey = GetWestRandomItemByGarde(context, grade);
			_teaHorseCaravanData.ExchangeGoodsList.Add(itemKey);
			_teaHorseCaravanEventCollection.AddFindWreckage(padding, date, itemKey.ItemType, itemKey.TemplateId);
		}
		else if (eventConfig.EventType == 5 && (eventConfig.ReplenishmentTrigger != 1 || _teaHorseCaravanData.CaravanReplenishment != 0))
		{
			int lostNum = context.Random.Next(eventConfig.LoseGoodsNumMin, eventConfig.LoseGoodsNumMax + 1);
			(sbyte, short)[] list = new(sbyte, short)[lostNum];
			for (int i4 = 0; i4 < lostNum; i4++)
			{
				if (context.Random.Next(2) == 0)
				{
					if (_teaHorseCaravanData.CarryGoodsList.Count > 0)
					{
						int index5 = context.Random.Next(_teaHorseCaravanData.CarryGoodsList.Count);
						ItemKey lostItem3 = _teaHorseCaravanData.CarryGoodsList[index5].Item1;
						list[i4] = (lostItem3.ItemType, lostItem3.TemplateId);
						_teaHorseCaravanData.CarryGoodsList.RemoveAt(index5);
						DomainManager.Item.RemoveItem(context, lostItem3);
						continue;
					}
					if (_teaHorseCaravanData.ExchangeGoodsList.Count <= 0)
					{
						lostNum = i4;
						break;
					}
					int index6 = context.Random.Next(_teaHorseCaravanData.ExchangeGoodsList.Count);
					list[i4] = (_teaHorseCaravanData.ExchangeGoodsList[index6].ItemType, _teaHorseCaravanData.ExchangeGoodsList[index6].TemplateId);
					_teaHorseCaravanData.ExchangeGoodsList.RemoveAt(index6);
				}
				else if (_teaHorseCaravanData.ExchangeGoodsList.Count > 0)
				{
					int index7 = context.Random.Next(_teaHorseCaravanData.ExchangeGoodsList.Count);
					list[i4] = (_teaHorseCaravanData.ExchangeGoodsList[index7].ItemType, _teaHorseCaravanData.ExchangeGoodsList[index7].TemplateId);
					_teaHorseCaravanData.ExchangeGoodsList.RemoveAt(index7);
				}
				else
				{
					if (_teaHorseCaravanData.CarryGoodsList.Count <= 0)
					{
						lostNum = i4;
						break;
					}
					int index8 = context.Random.Next(_teaHorseCaravanData.CarryGoodsList.Count);
					ItemKey lostItem4 = _teaHorseCaravanData.CarryGoodsList[index8].Item1;
					list[i4] = (lostItem4.ItemType, lostItem4.TemplateId);
					_teaHorseCaravanData.CarryGoodsList.RemoveAt(index8);
					DomainManager.Item.RemoveItem(context, lostItem4);
				}
			}
			switch (lostNum)
			{
			case 3:
				_teaHorseCaravanEventCollection.AddMeetTheif3(padding, date, list[0].Item1, list[0].Item2, list[1].Item1, list[1].Item2, list[2].Item1, list[2].Item2);
				break;
			case 2:
				_teaHorseCaravanEventCollection.AddMeetTheif2(padding, date, list[0].Item1, list[0].Item2, list[1].Item1, list[1].Item2);
				break;
			case 1:
				if (eventTemplateId == 12)
				{
					_teaHorseCaravanEventCollection.AddGoodsDamage(padding, date, list[0].Item1, list[0].Item2);
				}
				else
				{
					_teaHorseCaravanEventCollection.AddMeetTheif1(padding, date, list[0].Item1, list[0].Item2);
				}
				break;
			}
		}
		else if ((eventConfig.EventType == 6 || eventConfig.EventType == 7) && (eventConfig.ReplenishmentTrigger != 1 || _teaHorseCaravanData.CaravanReplenishment != 0))
		{
			int replementChange = context.Random.Next(eventConfig.ReplenishmentChangeMin, eventConfig.ReplenishmentChangeMax + 1);
			_teaHorseCaravanData.CaravanReplenishment = (short)Math.Clamp(_teaHorseCaravanData.CaravanReplenishment + replementChange, 0, 100);
			switch (eventTemplateId)
			{
			case 16:
				_teaHorseCaravanEventCollection.AddGetHelp(padding, date, replementChange);
				break;
			case 17:
				_teaHorseCaravanEventCollection.AddFindVenison(padding, date, replementChange);
				break;
			case 14:
				_teaHorseCaravanData.CaravanAwareness = (short)Math.Clamp(_teaHorseCaravanData.CaravanAwareness + eventConfig.AwarenessChange, 0, 32767);
				_teaHorseCaravanEventCollection.AddHelpPasserby(padding, date, -replementChange, eventConfig.AwarenessChange);
				break;
			case 15:
				_teaHorseCaravanEventCollection.AddUnacclimatized(padding, date, -replementChange);
				break;
			}
		}
		SetTeaHorseCaravanEventCollection(_teaHorseCaravanEventCollection, context);
		MonthlyNotificationCollection monthlyNotification = DomainManager.World.GetMonthlyNotificationCollection();
		switch (eventConfig.TemplateId)
		{
		case 0:
			monthlyNotification.AddWesternMerchanFindMirage();
			break;
		case 1:
			monthlyNotification.AddWesternMerchanFindBigfoot();
			break;
		case 2:
			monthlyNotification.AddWesternMerchanFindAnimal();
			break;
		case 3:
			monthlyNotification.AddWesternMerchanFindPlant();
			break;
		case 4:
			DomainManager.Information.GiveOrUpgradeWesternRegionInformation(context, DomainManager.Taiwu.GetTaiwuCharId(), WesternRegion.Instance.GetAllKeys().GetRandom(context.Random));
			monthlyNotification.AddWesternMerchanGetInformation();
			break;
		case 5:
			monthlyNotification.AddWesternMerchanFindSettlement();
			break;
		case 6:
			monthlyNotification.AddWesternMerchanFindWeather();
			break;
		case 7:
			monthlyNotification.AddWesternMerchanLost();
			break;
		case 8:
			monthlyNotification.AddWesternMerchanMeetTheif();
			break;
		case 12:
			monthlyNotification.AddWesternMerchanGoodsDamage();
			break;
		case 13:
			monthlyNotification.AddWesternMerchanFindWreckage();
			break;
		case 14:
			monthlyNotification.AddWesternMerchanHelpPasserby();
			break;
		case 15:
			monthlyNotification.AddWesternMerchanUnacclimatized();
			break;
		case 16:
			monthlyNotification.AddWesternMerchanGetHelp();
			break;
		case 17:
			monthlyNotification.AddWesternMerchanFindVenison();
			break;
		case 18:
			monthlyNotification.AddWesternMerchanFindFruit();
			break;
		case 19:
			monthlyNotification.AddWesternMerchanFindVillage();
			break;
		case 20:
			monthlyNotification.AddWesternMerchanMeetMerchan();
			break;
		}
		if (_teaHorseCaravanData.CaravanState == 2 && _teaHorseCaravanData.CaravanReplenishment != 0 && _teaHorseCaravanData.CarryGoodsList.Count > 0)
		{
			int itemIndex = 0;
			(ItemKey, sbyte) itemKey2 = _teaHorseCaravanData.CarryGoodsList[itemIndex];
			ItemKey exchangeItem = ItemKey.Invalid;
			int exchangeValue = ItemTemplateHelper.GetBaseValue(itemKey2.Item1.ItemType, itemKey2.Item1.TemplateId) + _teaHorseCaravanData.CaravanAwareness;
			int exchangeGrade = 0;
			for (int i5 = 0; i5 < _westTreasureTemplateId.Count; i5++)
			{
				int value = ItemTemplateHelper.GetBaseValue(12, _westTreasureTemplateId[i5]);
				if (exchangeValue >= value)
				{
					exchangeGrade = i5;
				}
			}
			exchangeGrade += 4;
			if (exchangeGrade > 4)
			{
				exchangeItem = ((!context.Random.CheckProb(40, 100)) ? GetWestRandomItemByGarde(context, (sbyte)(exchangeGrade - 1)) : GetWestRandomItemByGarde(context, (sbyte)exchangeGrade));
			}
			else
			{
				int baseValue = ItemTemplateHelper.GetBaseValue(12, _westTreasureTemplateId[0]);
				int baseProb = (_teaHorseCaravanData.CaravanAwareness + exchangeValue) * 100 / baseValue - GlobalConfig.Instance.CaravanExchangeProbPenalize;
				int getProb = Math.Clamp(baseProb, 0, 100);
				if (context.Random.CheckProb(getProb, 100))
				{
					exchangeItem = GetWestRandomItemByGarde(context, (sbyte)exchangeGrade);
				}
			}
			if (!exchangeItem.Equals(ItemKey.Invalid))
			{
				_teaHorseCaravanData.ExchangeGoodsList.Add(exchangeItem);
				_teaHorseCaravanData.CarryGoodsList.RemoveAt(itemIndex);
			}
		}
		if (_teaHorseCaravanData.CaravanState == 2)
		{
			_teaHorseCaravanData.DistanceToTaiwuVillage++;
		}
		else if (_teaHorseCaravanData.CaravanState == 3)
		{
			_teaHorseCaravanData.DistanceToTaiwuVillage = (short)Math.Max(0, _teaHorseCaravanData.DistanceToTaiwuVillage - 1);
		}
		if (_teaHorseCaravanData.CaravanState == 2)
		{
			_teaHorseCaravanData.CaravanAwareness = (short)Math.Max(0, _teaHorseCaravanData.CaravanAwareness + 100);
		}
		if (_teaHorseCaravanData.CarryGoodsList.Count == 0)
		{
			_teaHorseCaravanData.CaravanState = 3;
		}
		if (_teaHorseCaravanData.CarryGoodsList.Count == 0 && _teaHorseCaravanData.ExchangeGoodsList.Count == 0)
		{
			ResetTeaHorseCaravanData(context);
			MonthlyNotificationCollection monthlyNotifications3 = DomainManager.World.GetMonthlyNotificationCollection();
			monthlyNotifications3.AddWesternMerchantLoseContact();
		}
		if (_teaHorseCaravanData.CaravanState == 3 && _teaHorseCaravanData.DistanceToTaiwuVillage == 0)
		{
			_teaHorseCaravanData.CaravanState = 4;
			_teaHorseCaravanData.IsShowExchangeReplenishment = false;
			_teaHorseCaravanData.IsShowSeachReplenishment = false;
			_teaHorseCaravanData.Terrain = 5;
			MonthlyNotificationCollection monthlyNotifications4 = DomainManager.World.GetMonthlyNotificationCollection();
			monthlyNotifications4.AddWesternMerchantBackSucceed();
		}
		_teaHorseCaravanData.Weather = weatherTemplateId;
		SetTeaHorseCaravanData(_teaHorseCaravanData, context);
		DomainManager.Building.UpgradeTeaHorseCaravanByAwareness(context);
	}

	internal void CompleteBuilding(DataContext ctx, BuildingBlockKey blockKey, BuildingBlockData blockData)
	{
		blockData.Durability = blockData.ConfigData.MaxDurability;
		if (blockData.TemplateId == 46)
		{
			SetResidenceAutoCheckIn(ctx, blockKey.BuildingBlockIndex, isAutoCheckIn: true);
		}
		if (blockData.TemplateId == 47)
		{
			SetComfortableAutoCheckIn(ctx, blockKey.BuildingBlockIndex, isAutoCheckIn: false);
			DomainManager.Extra.FeastSetAutoRefill(ctx, blockKey, value: true);
		}
		EBuildingBlockType type = blockData.ConfigData.Type;
		if ((uint)type <= 1u)
		{
			DomainManager.Extra.SetResourceBlockExtraData(ctx, new ResourceBlockExtraData(blockKey));
		}
		DomainManager.Taiwu.RecordLifeSummary(ctx, 54);
	}

	private void OnBuildingRemoved(DataContext context, BuildingBlockKey blockKey)
	{
		DomainManager.Extra.TryRemoveResourceBlockExtraData(context, blockKey);
		DomainManager.Extra.TryRemoveBuildingArtisanOrder(context, blockKey);
	}

	private void OfflineUpdateOperation(DataContext context, ParallelBuildingModification modification, short settlementId, BuildingBlockItem configData, BuildingBlockKey blockKey, BuildingBlockData blockData)
	{
		if (blockData.OperationType == -1 || !_buildingOperatorDict.ContainsKey(blockKey))
		{
			return;
		}
		List<int> charList = _buildingOperatorDict[blockKey].GetCollection();
		int addProgress = 0;
		short maxProgress = configData.OperationTotalProgress[blockData.OperationType];
		addProgress = ((!blockData.OperationStopping) ? (addProgress + GetOperationSumValue(charList)) : maxProgress);
		if (addProgress <= 0)
		{
			return;
		}
		if (maxProgress > 0)
		{
			blockData.OperationProgress = (short)Math.Clamp(blockData.OperationProgress + ((!blockData.OperationStopping) ? addProgress : (-addProgress)), 0, maxProgress);
		}
		if (blockData.OperationProgress != ((!blockData.OperationStopping) ? maxProgress : 0))
		{
			return;
		}
		modification.FreeOperator = true;
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		switch (blockData.OperationType)
		{
		case 0:
			if (!blockData.OperationStopping)
			{
				modification.AddBuilding = true;
				monthlyNotifications.AddBuildingConstructionCompleted(settlementId, blockData.TemplateId);
				_newCompleteOperationBuildings.Add(blockKey);
				modification.BuildingOperationComplete = true;
				CompleteBuilding(context, blockKey, blockData);
				break;
			}
			modification.ResetAllChildrenBlocks = true;
			if (SharedMethods.NeedCostResourceToBuild(configData))
			{
				for (sbyte type2 = 0; type2 < 8; type2++)
				{
					modification.SetResource(type2, configData.BaseBuildCost[type2] / 2);
				}
			}
			if (configData.BuildingCoreItem != -1)
			{
				DomainManager.Taiwu.ReturnBuildingCoreItem(DataContextManager.GetCurrentThreadDataContext(), configData);
			}
			break;
		case 1:
			if (!blockData.OperationStopping)
			{
				modification.RemoveMakeItemData = true;
				modification.RemoveEventBookData = true;
				modification.RemoveResidence = true;
				modification.FreeShopManager = true;
				sbyte level = DomainManager.Building.BuildingBlockLevel(blockKey);
				for (sbyte type = 0; type < 8; type++)
				{
					int returnCount = SharedMethods.GetResourceReturnOfRemoveBuilding(configData, level, type, blockData);
					modification.SetResource(type, returnCount);
				}
				if (_CollectBuildingResourceType.ContainsKey(blockKey))
				{
					modification.RemoveCollectResourceType = true;
				}
				modification.ResetAllChildrenBlocks = true;
				monthlyNotifications.AddBuildingDemolitionCompleted(settlementId, blockData.TemplateId);
				modification.BuildingOperationComplete = true;
				OnBuildingRemoved(context, blockKey);
			}
			break;
		}
		blockData.OperationType = -1;
		blockData.OperationProgress = 0;
	}

	private void OfflineUpdateShopManagement(ParallelBuildingModification modification, short settlementId, BuildingBlockItem configData, BuildingBlockKey blockKey, BuildingBlockData blockData, DataContext context)
	{
		if (!HasShopManagerLeader(blockKey))
		{
			return;
		}
		if (ShopBuildingCanTeach(blockKey) && HasShopManagerLeader(blockKey))
		{
			UpdateShopBuildingTeach(context, modification, blockKey, blockData);
		}
		IRandomSource random = context.Random;
		if (blockData.TemplateId == 105)
		{
			if (!_collectBuildingEarningsData.ContainsKey(blockKey) || (TryGetElement_CollectBuildingEarningsData(blockKey, out var data) && data != null && data.FixBookInfoList.Count <= 0))
			{
				return;
			}
			ItemKey itemKey = data.FixBookInfoList[0];
			if (!itemKey.IsValid())
			{
				return;
			}
			GameData.Domains.Item.SkillBook skillBook = DomainManager.Item.GetElement_SkillBooks(itemKey.Id);
			if (!skillBook.CanFix())
			{
				blockData.OfflineResetShopProgress();
				return;
			}
			int needProgress = skillBook.GetFixProgress().needProgress;
			DomainManager.World.ApplyChallengeModeBuildingWorkHard(ref needProgress);
			if (blockData.ShopProgress >= needProgress)
			{
				blockData.OfflineResetShopProgress();
				ParallelBuildingModification parallelBuildingModification = modification;
				if (parallelBuildingModification.FixBookList == null)
				{
					parallelBuildingModification.FixBookList = new List<ItemKey>();
				}
				modification.FixBookList.Add(itemKey);
			}
			return;
		}
		sbyte level = SharedMethods.GetBuildingSlotCount(blockData.TemplateId);
		if (TryGetElement_CollectBuildingEarningsData(blockKey, out var earningsData) && earningsData != null && level <= earningsData.RecruitLevelList.Count)
		{
			return;
		}
		if (configData.SuccesEvent.Count > 0)
		{
			ShopEventItem successShopEventConfig = Config.ShopEvent.Instance[configData.SuccesEvent[0]];
			List<sbyte> resourceList = successShopEventConfig.ResourceList;
			if (resourceList != null && resourceList.Count > 0)
			{
				sbyte resourceType = GetCollectBuildingResourceType(blockKey);
				sbyte getResourceType = (sbyte)((resourceType < 6) ? resourceType : 5);
				int amount = CalcResourceOutputCount(blockKey, getResourceType);
				DomainManager.Taiwu.GetTaiwu().ChangeResource(context, getResourceType, amount);
				ApplyBuildingResourceOutputSetting(context, blockKey, getResourceType, amount);
			}
		}
		if (earningsData != null && level <= earningsData.CollectionItemList.Count + earningsData.CollectionResourceList.Count)
		{
			return;
		}
		int needProgress2 = configData.MaxProduceValue;
		DomainManager.World.ApplyChallengeModeBuildingWorkHard(ref needProgress2);
		if (blockData.ShopProgress < needProgress2)
		{
			return;
		}
		blockData.OfflineResetShopProgress();
		int date = DomainManager.World.GetCurrDate();
		ShopEventCollection shopEventCollection = GetOrCreateShopEventCollection(blockKey);
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		if (!configData.IsShop || configData.SuccesEvent.Count <= 0)
		{
			return;
		}
		ShopEventItem successShopEventConfig2 = Config.ShopEvent.Instance[configData.SuccesEvent[0]];
		ShopEventItem failShopEventConfig = Config.ShopEvent.Instance[configData.FailEvent[0]];
		if (successShopEventConfig2.ItemList.Count > 0)
		{
			List<TemplateKey> itemProbList = ObjectPool<List<TemplateKey>>.Instance.Get();
			itemProbList.Clear();
			int from = 0;
			int end = successShopEventConfig2.ItemList.Count;
			sbyte resourceType2 = -1;
			if (successShopEventConfig2.ResourceList.Count > 1)
			{
				resourceType2 = GetCollectBuildingResourceType(blockKey);
				if (resourceType2 == successShopEventConfig2.ResourceList[0])
				{
					end = successShopEventConfig2.ItemList.Count / 2;
				}
				else
				{
					from = successShopEventConfig2.ItemList.Count / 2;
				}
			}
			for (int i = from; i < end; i++)
			{
				bool hasManager;
				int prob = (successShopEventConfig2.ItemList[i].Amount + BuildingTotalAttainment(blockKey, resourceType2, out hasManager) / 30) * BuildingProductivityByMaxDependencies(blockKey) / 100;
				if (hasManager && random.CheckPercentProb(prob))
				{
					PresetInventoryItem item = successShopEventConfig2.ItemList[i];
					itemProbList.Add(new TemplateKey(item.Type, item.TemplateId));
				}
			}
			if (itemProbList.Count == 0)
			{
				PresetInventoryItem item2 = successShopEventConfig2.ItemList[from];
				itemProbList.Add(new TemplateKey(item2.Type, item2.TemplateId));
			}
			if (itemProbList.Count > 0)
			{
				TemplateKey templateKey = itemProbList[random.Next(0, itemProbList.Count)];
				modification.AddCollectableEarning(templateKey);
				shopEventCollection.AddCollectItemSuccessRecord(successShopEventConfig2, date, templateKey.ItemType, templateKey.TemplateId);
				monthlyNotifications.AddBuildingIncome(settlementId, configData.TemplateId);
			}
			ObjectPool<List<TemplateKey>>.Instance.Return(itemProbList);
		}
		if (successShopEventConfig2.ItemGradeProbList.Count > 0)
		{
			List<sbyte> itemProbList2 = ObjectPool<List<sbyte>>.Instance.Get();
			itemProbList2.Clear();
			for (sbyte i2 = 0; i2 < successShopEventConfig2.ItemGradeProbList.Count; i2++)
			{
				int prob2 = successShopEventConfig2.ItemGradeProbList[i2] + GetBuildingAttainment(blockData, blockKey, isAverage: true) / AttainmentToProb;
				if (random.CheckPercentProb(prob2))
				{
					itemProbList2.Add(i2);
				}
			}
			if (itemProbList2.Count == 0)
			{
				itemProbList2.Add(0);
			}
			if (itemProbList2.Count > 0)
			{
				sbyte gradeLevel = itemProbList2[random.Next(0, itemProbList2.Count)];
				ItemKey itemKey2 = GetRandomItemByGrade(random, gradeLevel, -1);
				TemplateKey templateKey2 = new TemplateKey(itemKey2.ItemType, itemKey2.TemplateId);
				modification.AddCollectableEarning(templateKey2);
				shopEventCollection.AddManageEclecticBuildingSuccess6(date, templateKey2.ItemType, templateKey2.TemplateId, 6, ItemTemplateHelper.GetBaseValue(templateKey2.ItemType, templateKey2.TemplateId));
			}
		}
		if (SharedMethods.IsBuildingProduceMoneyAuthority(configData, successShopEventConfig2) && TryCalcShopManagementYieldAmount(random, blockKey, out var resourceType3, out var amount2, out var _))
		{
			ParallelBuildingModification parallelBuildingModification = modification;
			if (parallelBuildingModification.BuildingMoneyPrestigeSuccessRateCompensationChanged == null)
			{
				parallelBuildingModification.BuildingMoneyPrestigeSuccessRateCompensationChanged = new Dictionary<BuildingBlockKey, int>();
			}
			modification.BuildingMoneyPrestigeSuccessRateCompensationChanged[blockKey] = 0;
			if (resourceType3 >= 0 && amount2 > 0)
			{
				modification.AddCollectableResources(resourceType3, amount2);
				shopEventCollection.AddCollectResourceSuccessRecord(successShopEventConfig2, date, resourceType3, amount2);
				monthlyNotifications.AddBuildingIncome(settlementId, configData.TemplateId);
				List<int> characterList = DomainManager.Building.GetElement_ShopManagerDict(blockKey).GetCollection();
				for (int j = 0; j < characterList.Count; j++)
				{
					int charId = characterList[j];
					if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetAgeGroup() == 2)
					{
						int count = amount2 * GlobalConfig.Instance.ShopBuildingSharePencent[(j != 0) ? 1 : 0] / 100;
						modification.AddShopSalaryResources(charId, resourceType3, count);
					}
				}
			}
		}
		if (successShopEventConfig2.RecruitPeopleProb.Count > 0)
		{
			int peopleLevel = CalcRecruitGrade(random, blockKey, ref blockData.CumulatedScore);
			ParallelBuildingModification parallelBuildingModification = modification;
			if (parallelBuildingModification.RecruitLevelList == null)
			{
				parallelBuildingModification.RecruitLevelList = new List<IntPair>();
			}
			modification.RecruitLevelList.Add(new IntPair(peopleLevel, 0));
			InstantNotificationCollection instantNotifications = DomainManager.World.GetInstantNotificationCollection();
			instantNotifications.AddCandidateArrived(settlementId, blockData.TemplateId);
			if (blockData.TemplateId == 223)
			{
				shopEventCollection.AddRecruitWithCostSuccessRecord(successShopEventConfig2, date, 7, GlobalConfig.Instance.RecruitPeopleCost);
			}
			else
			{
				shopEventCollection.AddRecruitSuccessRecord(successShopEventConfig2, date);
			}
		}
		if (successShopEventConfig2.ExchangeResourceGoods == -1 || !TryGetElement_CollectBuildingEarningsData(blockKey, out var data2))
		{
			return;
		}
		int count2 = 0;
		for (int k = 0; k < data2.ShopSoldItemList.Count; k++)
		{
			if (data2.ShopSoldItemList[k].TemplateId != -1 && random.CheckProb(50, 100))
			{
				SellItemSuccess(successShopEventConfig2, earningsData, k);
				count2++;
			}
		}
		if (count2 != 0)
		{
			return;
		}
		for (int l = 0; l < data2.ShopSoldItemList.Count; l++)
		{
			if (data2.ShopSoldItemList[l].TemplateId != -1)
			{
				SellItemSuccess(successShopEventConfig2, earningsData, l);
				break;
			}
		}
		void SellItemSuccess(ShopEventItem shopEventItem, BuildingEarningsData buildingEarningsData, int index)
		{
			sbyte resourceType4 = shopEventItem.ExchangeResourceGoods;
			int basePrice;
			BuildingProduceDependencyData dependencyData2;
			int soldValue = CalcSoldItemValue(random, blockKey, blockData, buildingEarningsData.ShopSoldItemList[index], out basePrice, out dependencyData2);
			int soldPrice = soldValue / GlobalConfig.ResourcesWorth[resourceType4];
			ParallelBuildingModification parallelBuildingModification2 = modification;
			if (parallelBuildingModification2.ShopSoldItems == null)
			{
				parallelBuildingModification2.ShopSoldItems = new List<(sbyte, IntPair)>();
			}
			modification.ShopSoldItems.Add(((sbyte)index, new IntPair(resourceType4, soldPrice)));
			ItemKey soldItem = buildingEarningsData.ShopSoldItemList[index];
			shopEventCollection.AddSellItemSuccessRecord(shopEventItem, date, soldItem.ItemType, soldItem.TemplateId, resourceType4, soldPrice);
			monthlyNotifications.AddBuildingIncome(settlementId, configData.TemplateId);
		}
	}

	private void UpdateShopBuildingTeach(DataContext context, ParallelBuildingModification modification, BuildingBlockKey blockKey, BuildingBlockData blockData)
	{
		CharacterList managerList = GetElement_ShopManagerDict(blockKey);
		if (managerList.GetRealCount() <= 1)
		{
			return;
		}
		ShopEventCollection shopEventCollection = GetOrCreateShopEventCollection(blockKey);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int date = DomainManager.World.GetCurrDate();
		short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		BuildingBlockItem buildingConfig = BuildingBlock.Instance[blockData.TemplateId];
		CValuePercentBonus buildingProbBonus = ((buildingConfig.RequireLifeSkillType >= 0) ? GetBuildingBlockEffect(settlementId, EBuildingScaleEffect.ShopManagerQualificationImproveRate, buildingConfig.RequireLifeSkillType) : 0);
		int leaderId = managerList[0];
		GameData.Domains.Character.Character leaderCharacter = DomainManager.Character.GetElement_Objects(leaderId);
		for (int index = 1; index < 7; index++)
		{
			int memberId = managerList[index];
			if (memberId < 0)
			{
				continue;
			}
			GameData.Domains.Character.Character memberCharacter = DomainManager.Character.GetElement_Objects(memberId);
			DomainManager.Extra.TryGetElement_TaiwuVillagerPotentialData(memberId, out var alreadyAddCount);
			sbyte requirePersonalityValue = memberCharacter.GetPersonalities()[buildingConfig.RequirePersonalityType];
			sbyte skillType = ((buildingConfig.RequireLifeSkillType >= 0) ? buildingConfig.RequireLifeSkillType : buildingConfig.RequireCombatSkillType);
			int totalAddQualification = 0;
			if (alreadyAddCount < GlobalConfig.Instance.TaiwuVillagerMaxPotential)
			{
				if (alreadyAddCount != 0 && alreadyAddCount % 4 == 0)
				{
					DomainManager.Extra.TrySetShopVillagerQualificationImprove(memberCharacter, skillType, buildingConfig.RequireLifeSkillType >= 0);
					totalAddQualification++;
					if (buildingConfig.RequireLifeSkillType >= 0)
					{
						shopEventCollection.AddBaseDevelopLifeSkill(date, memberId, skillType);
						lifeRecordCollection.AddShopBuildingBaseDevelopLifeSkill(memberId, date, buildingConfig.TemplateId, skillType);
					}
					else
					{
						shopEventCollection.AddBaseDevelopCombatSkill(date, memberId, skillType);
						lifeRecordCollection.AddShopBuildingBaseDevelopCombatSkill(memberId, date, buildingConfig.TemplateId, skillType);
					}
				}
				int personalityAddProb = requirePersonalityValue / 3 * buildingProbBonus;
				if (context.Random.CheckPercentProb(personalityAddProb))
				{
					DomainManager.Extra.TrySetShopVillagerQualificationImprove(memberCharacter, skillType, buildingConfig.RequireLifeSkillType >= 0);
					totalAddQualification++;
					if (buildingConfig.RequireLifeSkillType >= 0)
					{
						shopEventCollection.AddPersonalityDevelopLifeSkill(date, memberId, skillType);
						lifeRecordCollection.AddShopBuildingPersonalityDevelopLifeSkill(memberId, date, buildingConfig.TemplateId, skillType);
					}
					else
					{
						shopEventCollection.AddPersonalityDevelopCombatSkill(date, memberId, skillType);
						lifeRecordCollection.AddShopBuildingPersonalityDevelopCombatSkill(memberId, date, buildingConfig.TemplateId, skillType);
					}
				}
				short leaderQualification = ((buildingConfig.RequireLifeSkillType >= 0) ? leaderCharacter.GetLifeSkillQualification(buildingConfig.RequireLifeSkillType) : leaderCharacter.GetCombatSkillQualification(buildingConfig.RequireCombatSkillType));
				short memberQualification = ((buildingConfig.RequireLifeSkillType >= 0) ? memberCharacter.GetLifeSkillQualification(buildingConfig.RequireLifeSkillType) : memberCharacter.GetCombatSkillQualification(buildingConfig.RequireCombatSkillType));
				int qualificationAddProb = (leaderQualification - memberQualification) * 3 * buildingProbBonus;
				if (context.Random.CheckPercentProb(qualificationAddProb))
				{
					DomainManager.Extra.TrySetShopVillagerQualificationImprove(memberCharacter, skillType, buildingConfig.RequireLifeSkillType >= 0);
					totalAddQualification++;
					if (buildingConfig.RequireLifeSkillType >= 0)
					{
						shopEventCollection.AddLeaderDevelopLifeSkill(date, memberId, leaderId, skillType);
						lifeRecordCollection.AddShopBuildingLeaderDevelopLifeSkill(memberId, date, leaderId, buildingConfig.TemplateId, skillType);
					}
					else
					{
						shopEventCollection.AddLeaderDevelopCombatSkill(date, memberId, leaderId, skillType);
						lifeRecordCollection.AddShopBuildingLeaderDevelopCombatSkill(memberId, date, leaderId, buildingConfig.TemplateId, skillType);
					}
				}
				DomainManager.Extra.UpdateTaiwuVillagerPotentialData(context, memberId, ++alreadyAddCount);
				_shopManagerUpgradeQualificationDict[memberId] = totalAddQualification;
			}
			short memberAttainment = ((buildingConfig.RequireLifeSkillType >= 0) ? memberCharacter.GetLifeSkillAttainment(buildingConfig.RequireLifeSkillType) : memberCharacter.GetCombatSkillAttainment(buildingConfig.RequireCombatSkillType));
			int point = memberAttainment * (100 + requirePersonalityValue) / 100;
			int leaderCanTeachCount;
			if (buildingConfig.RequireLifeSkillType >= 0)
			{
				int memberLearnedPageCount;
				List<(short, byte)> readBooks = ShopBuildingTeachLifeSkillBook(leaderCharacter, memberCharacter, point, blockData.TemplateId, out memberLearnedPageCount, out leaderCanTeachCount);
				foreach (var (skillTemplateId, pageId) in readBooks)
				{
					modification.AddLearnLifeSkill(memberId, skillTemplateId, pageId);
					Config.LifeSkillItem skillConfig = LifeSkill.Instance[skillTemplateId];
					SkillBookItem itemConfig = Config.SkillBook.Instance[skillConfig.SkillBookId];
					lifeRecordCollection.AddShopBuildingLearnLifeSkill(memberId, date, buildingConfig.TemplateId, itemConfig.ItemType, itemConfig.TemplateId, pageId + 1);
					shopEventCollection.AddLearnLifeSkill(date, memberId, itemConfig.ItemType, itemConfig.TemplateId, pageId + 1);
				}
				continue;
			}
			bool hasMemberUnread;
			List<(short, byte, sbyte)> readBooks2 = ShopBuildingTeachCombatSkillBook(leaderCharacter, memberCharacter, point, blockData.TemplateId, out hasMemberUnread, out leaderCanTeachCount);
			foreach (var (skillTemplateId2, pageInternalIndex, _) in readBooks2)
			{
				modification.AddLearnCombatSkill(memberId, skillTemplateId2, pageInternalIndex);
				CombatSkillItem skillConfig2 = Config.CombatSkill.Instance[skillTemplateId2];
				SkillBookItem itemConfig2 = Config.SkillBook.Instance[skillConfig2.BookId];
				byte pageId2 = CombatSkillStateHelper.GetPageId(pageInternalIndex);
				lifeRecordCollection.AddShopBuildingLearnCombatSkill(memberId, date, buildingConfig.TemplateId, itemConfig2.ItemType, itemConfig2.TemplateId, pageId2 + 1);
				shopEventCollection.AddLearnCombatSkill(date, memberId, itemConfig2.ItemType, itemConfig2.TemplateId, pageId2 + 1);
			}
		}
	}

	private List<(short skillTemplateId, byte pageId)> ShopBuildingTeachLifeSkillBook(GameData.Domains.Character.Character leader, GameData.Domains.Character.Character member, int point, short buildingTemplateId, out int memberLearnedPageCount, out int leaderCanTeachPageCount)
	{
		List<(short, byte)> result = new List<(short, byte)>();
		BuildingBlockItem buildingConfig = BuildingBlock.Instance[buildingTemplateId];
		List<GameData.Domains.Character.LifeSkillItem> leaderLearnedLifeSkills = leader.GetLearnedLifeSkills();
		List<GameData.Domains.Character.LifeSkillItem> leaderCanTeach = leaderLearnedLifeSkills.Where(delegate(GameData.Domains.Character.LifeSkillItem a)
		{
			Config.LifeSkillItem lifeSkillItem = LifeSkill.Instance[a.SkillTemplateId];
			return lifeSkillItem.Type == buildingConfig.RequireLifeSkillType;
		}).ToList();
		leaderCanTeach.Sort(delegate(GameData.Domains.Character.LifeSkillItem a, GameData.Domains.Character.LifeSkillItem b)
		{
			sbyte grade = LifeSkill.Instance[a.SkillTemplateId].Grade;
			sbyte grade2 = LifeSkill.Instance[b.SkillTemplateId].Grade;
			return grade.CompareTo(grade2);
		});
		List<GameData.Domains.Character.LifeSkillItem> memberLearnedLifeSkills = member.GetLearnedLifeSkills();
		List<short> memberLearnedLifeSkillTemplateIds = memberLearnedLifeSkills.Select((GameData.Domains.Character.LifeSkillItem a) => a.SkillTemplateId).ToList();
		List<byte> unreadPages = new List<byte>();
		leaderCanTeachPageCount = 0;
		int unreadPageCount = 0;
		for (int i = 0; i < leaderCanTeach.Count; i++)
		{
			GameData.Domains.Character.LifeSkillItem skillItem = leaderCanTeach[i];
			Config.LifeSkillItem skillCfg = LifeSkill.Instance[skillItem.SkillTemplateId];
			leaderCanTeachPageCount += 5;
			int pageCost = SkillGradeData.Instance[skillCfg.Grade].ReadingAttainmentRequirement;
			unreadPages.Clear();
			if (!memberLearnedLifeSkillTemplateIds.Contains(skillItem.SkillTemplateId))
			{
				for (byte pageId = 0; pageId < 5; pageId++)
				{
					if (skillItem.IsPageRead(pageId))
					{
						unreadPages.Add(pageId);
					}
				}
			}
			else
			{
				GameData.Domains.Character.LifeSkillItem memberSkillItem = memberLearnedLifeSkills.Find((GameData.Domains.Character.LifeSkillItem a) => a.SkillTemplateId == skillItem.SkillTemplateId);
				for (byte pageId2 = 0; pageId2 < 5; pageId2++)
				{
					if (skillItem.IsPageRead(pageId2) && !memberSkillItem.IsPageRead(pageId2))
					{
						unreadPages.Add(pageId2);
					}
				}
			}
			unreadPageCount += unreadPages.Count;
			for (int j = 0; j < unreadPages.Count; j++)
			{
				point -= pageCost;
				if (point >= 0)
				{
					result.Add((skillItem.SkillTemplateId, unreadPages[j]));
					continue;
				}
				break;
			}
		}
		memberLearnedPageCount = Math.Max(0, leaderCanTeachPageCount - unreadPageCount);
		return result;
	}

	private List<(short skillTemplateId, byte pageInternalIndex, sbyte direct)> ShopBuildingTeachCombatSkillBook(GameData.Domains.Character.Character leader, GameData.Domains.Character.Character member, int point, short buildingTemplateId, out bool hasMemberUnread, out int leaderCanTeachCount)
	{
		List<(short, byte, sbyte)> result = new List<(short, byte, sbyte)>();
		BuildingBlockItem buildingConfig = BuildingBlock.Instance[buildingTemplateId];
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> leaderLearnedDict = DomainManager.CombatSkill.GetCharCombatSkills(leader.GetId());
		List<short> leaderLearnedTemplateIdList = leaderLearnedDict.Keys.ToList();
		List<short> leaderCanTeach = leaderLearnedTemplateIdList.Where(delegate(short combatSkillTemplateId)
		{
			CombatSkillItem combatSkillItem = Config.CombatSkill.Instance[combatSkillTemplateId];
			return combatSkillItem.Type == buildingConfig.RequireCombatSkillType;
		}).ToList();
		leaderCanTeach.Sort(delegate(short a, short b)
		{
			sbyte grade = Config.CombatSkill.Instance[a].Grade;
			sbyte grade2 = Config.CombatSkill.Instance[b].Grade;
			return grade.CompareTo(grade2);
		});
		leaderCanTeachCount = leaderCanTeach.Count;
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> memberLearnedDict = DomainManager.CombatSkill.GetCharCombatSkills(member.GetId());
		List<short> memberLearnedTemplateIdList = memberLearnedDict.Keys.ToList();
		List<(byte, sbyte)> unreadPages = new List<(byte, sbyte)>();
		hasMemberUnread = false;
		for (int i = 0; i < leaderCanTeach.Count; i++)
		{
			short skillTemplateId = leaderCanTeach[i];
			CombatSkillItem skillCfg = Config.CombatSkill.Instance[skillTemplateId];
			int pageCost = SkillGradeData.Instance[skillCfg.Grade].ReadingAttainmentRequirement;
			unreadPages.Clear();
			GameData.Domains.CombatSkill.CombatSkill leaderSkillItem = leaderLearnedDict[skillTemplateId];
			ushort leaderReadingState = leaderSkillItem.GetReadingState();
			if (!memberLearnedTemplateIdList.Contains(skillTemplateId))
			{
				for (int j = 0; j < 5; j++)
				{
					byte outlineIndex = (byte)j;
					if ((leaderReadingState & (1 << (int)outlineIndex)) != 0)
					{
						unreadPages.Add((outlineIndex, -1));
					}
					byte directIndex = (byte)(5 + j);
					if ((leaderReadingState & (1 << (int)directIndex)) != 0)
					{
						unreadPages.Add((directIndex, 0));
					}
					byte reverseIndex = (byte)(directIndex + 5);
					if ((leaderReadingState & (1 << (int)reverseIndex)) != 0)
					{
						unreadPages.Add((reverseIndex, 1));
					}
				}
			}
			else
			{
				GameData.Domains.CombatSkill.CombatSkill memberSkillItem = memberLearnedDict[skillTemplateId];
				ushort memberReadingState = memberSkillItem.GetReadingState();
				for (int j2 = 0; j2 < 5; j2++)
				{
					byte outlineIndex2 = (byte)j2;
					if ((leaderReadingState & (1 << (int)outlineIndex2)) != 0 && (memberReadingState & (1 << (int)outlineIndex2)) == 0)
					{
						unreadPages.Add((outlineIndex2, -1));
					}
					byte directIndex2 = (byte)(5 + j2);
					if ((leaderReadingState & (1 << (int)directIndex2)) != 0 && (memberReadingState & (1 << (int)directIndex2)) == 0)
					{
						unreadPages.Add((directIndex2, 0));
					}
					byte reverseIndex2 = (byte)(directIndex2 + 5);
					if ((leaderReadingState & (1 << (int)reverseIndex2)) != 0 && (memberReadingState & (1 << (int)reverseIndex2)) == 0)
					{
						unreadPages.Add((reverseIndex2, 1));
					}
				}
			}
			hasMemberUnread |= unreadPages.Count > 0;
			for (int j3 = 0; j3 < unreadPages.Count; j3++)
			{
				point -= pageCost;
				if (point >= 0)
				{
					result.Add((skillTemplateId, unreadPages[j3].Item1, unreadPages[j3].Item2));
					continue;
				}
				break;
			}
		}
		return result;
	}

	private BuildingBlockKey GetBuildingInRange(BuildingBlockKey blockKey, sbyte width, int range, short targetBuildingTemplateId)
	{
		List<short> neighborList = ObjectPool<List<short>>.Instance.Get();
		BuildingAreaData areaData = GetElement_BuildingAreas(new Location(blockKey.AreaId, blockKey.BlockId));
		areaData.GetNeighborBlocks(blockKey.BuildingBlockIndex, width, neighborList, null, range);
		BuildingBlockKey result = BuildingBlockKey.Invalid;
		foreach (short neighborBlockIndex in neighborList)
		{
			BuildingBlockKey neighborKey = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborBlockIndex);
			if (TryGetElement_BuildingBlocks(neighborKey, out var buildingBlockData))
			{
				if (buildingBlockData.RootBlockIndex >= 0)
				{
					neighborKey.BuildingBlockIndex = buildingBlockData.RootBlockIndex;
					buildingBlockData = GetBuildingBlockData(neighborKey);
				}
				if (buildingBlockData.TemplateId == targetBuildingTemplateId)
				{
					result = neighborKey;
					break;
				}
			}
		}
		ObjectPool<List<short>>.Instance.Return(neighborList);
		return result;
	}

	private void GetInfluencedBuildingBlocks(BuildingBlockKey blockKey, List<BuildingBlockData> influencedBlocks)
	{
		BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
		BuildingBlockItem blockCfg = blockData.ConfigData;
		List<short> neighborList = ObjectPool<List<short>>.Instance.Get();
		BuildingAreaData areaData = GetElement_BuildingAreas(new Location(blockKey.AreaId, blockKey.BlockId));
		areaData.GetNeighborBlocks(blockKey.BuildingBlockIndex, blockCfg.Width, neighborList, null, 2);
		foreach (short neighborIndex in neighborList)
		{
			BuildingBlockKey neighborKey = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborIndex);
			if (TryGetElement_BuildingBlocks(neighborKey, out var neighborBlock) && blockData.CanInfluenceBuildingBlock(neighborBlock))
			{
				influencedBlocks.Add(blockData);
			}
		}
		ObjectPool<List<short>>.Instance.Return(neighborList);
	}

	private void RemoveAllOperatorsInBuilding(DataContext context, BuildingBlockKey blockKey)
	{
		if (!_buildingOperatorDict.ContainsKey(blockKey))
		{
			return;
		}
		List<int> operators = _buildingOperatorDict[blockKey].GetCollection();
		for (int i = 0; i < 3; i++)
		{
			if (operators[i] >= 0)
			{
				DomainManager.Taiwu.RemoveVillagerWork(context, operators[i]);
			}
		}
	}

	private void RemoveAllManagersInBuilding(DataContext context, BuildingBlockKey blockKey)
	{
		if (!_shopManagerDict.ContainsKey(blockKey))
		{
			return;
		}
		List<int> shopManagers = _shopManagerDict[blockKey].GetCollection();
		for (int i = 0; i < 7; i++)
		{
			if (shopManagers[i] >= 0)
			{
				DomainManager.Taiwu.RemoveVillagerWork(context, shopManagers[i]);
			}
		}
	}

	public void UpdateTaiwuBuildingAutoOperation(DataContext context)
	{
		foreach (KeyValuePair<BuildingBlockKey, BuildingBlockData> entry in _buildingBlocks)
		{
			BuildingBlockKey blockKey = entry.Key;
			BuildingBlockData blockData = entry.Value;
			if (blockData.RootBlockIndex >= 0)
			{
				continue;
			}
			BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
			if (configData.Type != EBuildingBlockType.Building && !BuildingBlockData.IsResource(configData.Type) && configData.TemplateId != 44)
			{
				continue;
			}
			ParallelBuildingModification modification = new ParallelBuildingModification
			{
				BlockKey = blockKey,
				BlockData = blockData
			};
			if (blockData.CanUse() && configData.IsShop)
			{
				Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
				if (taiwuVillageLocation.AreaId == modification.BlockKey.AreaId && taiwuVillageLocation.BlockId == modification.BlockKey.BlockId)
				{
					TaiwuVillageAutoArrangeShopManager(context, modification);
					TaiwuVillageAutoAddShopSoldItem(context, modification);
				}
			}
		}
	}

	private void TaiwuVillageAutoArrangeShopManager(DataContext context, ParallelBuildingModification modification)
	{
		BuildingBlockItem configData = BuildingBlock.Instance[modification.BlockData.TemplateId];
		if (!configData.IsShop)
		{
			return;
		}
		List<short> autoWorkList = DomainManager.Extra.GetAutoWorkBlockIndexList();
		if (!modification.FreeShopManager && autoWorkList.Contains(modification.BlockKey.BuildingBlockIndex))
		{
			TryGetElement_ShopManagerDict(modification.BlockKey, out var shopManager);
			if (shopManager.GetCount() != 0)
			{
				QuickArrangeShopManager(context, modification.BlockKey);
			}
		}
	}

	private void TaiwuVillageAutoAddShopSoldItem(DataContext context, ParallelBuildingModification modification)
	{
		List<short> autoSoldList = DomainManager.Extra.GetAutoSoldBlockIndexList();
		if (!modification.FreeShopManager && autoSoldList.Contains(modification.BlockKey.BuildingBlockIndex))
		{
			AutoAddShopSoldItem(context, modification.BlockKey);
		}
	}

	private void AutoCheckInResidence(DataContext context, BuildingBlockKey blockKey)
	{
		List<short> autoCheckInList = DomainManager.Extra.GetAutoCheckInResidenceList();
		if (autoCheckInList.Contains(blockKey.BuildingBlockIndex))
		{
			QuickFillResidence(context, blockKey);
		}
	}

	private void AutoCheckInComfortable(DataContext context, BuildingBlockKey blockKey)
	{
		List<short> autoCheckInList = DomainManager.Extra.GetAutoCheckInComfortableList();
		if (autoCheckInList.Contains(blockKey.BuildingBlockIndex) && !DomainManager.Extra.GetFeast(blockKey).CheckAvoidAutoCheckIn())
		{
			QuickFillComfortableHouse(context, blockKey);
		}
	}

	public void ComplementUpdateBuilding(DataContext context, ParallelBuildingModification modification)
	{
		InstantNotificationCollection instantNotifications = DomainManager.World.GetInstantNotificationCollection();
		short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		bool isTaiwuVillage = modification.BlockKey.AreaId == taiwuLocation.AreaId && modification.BlockKey.BlockId == taiwuLocation.BlockId;
		short blockTemplateId = modification.BlockData?.TemplateId ?? (-1);
		if (modification.ResetAllChildrenBlocks)
		{
			ResetAllChildrenBlocks(context, modification.BlockKey, 0, -1);
			SetBuildingCustomName(context, modification.BlockKey, null);
		}
		SetNewCompleteOperationBuildings(_newCompleteOperationBuildings, context);
		SetElement_BuildingBlocks(modification.BlockKey, modification.BlockData, context);
		if (modification.FreeOperator)
		{
			RemoveAllOperatorsInBuilding(context, modification.BlockKey);
		}
		if (modification.AddBuilding)
		{
			switch (blockTemplateId)
			{
			case 46:
				AddResidence(context, modification.BlockKey);
				break;
			case 47:
				AddComfortableHouse(context, modification.BlockKey);
				break;
			}
		}
		if (modification.RemoveResidence)
		{
			if (_residences.ContainsKey(modification.BlockKey))
			{
				RemoveResidence(context, modification.BlockKey);
			}
			else if (_comfortableHouses.ContainsKey(modification.BlockKey))
			{
				RemoveComfortableHouse(context, modification.BlockKey);
			}
		}
		if (isTaiwuVillage)
		{
			AutoCheckInComfortable(context, modification.BlockKey);
			AutoCheckInResidence(context, modification.BlockKey);
		}
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		taiwuChar.ChangeResources(context, ref modification.DeltaResources);
		if (TryGetElement_CollectBuildingEarningsData(modification.BlockKey, out var data))
		{
			int discardTime = SharedMethods.GetBuildingEarnPreserveTime(blockTemplateId) - 2;
			if (blockTemplateId == 222 && data.CollectionItemList != null)
			{
				for (int i = 0; i < data.CollectionItemList.Count; i++)
				{
					if (data.CollectionItemList[i].ModificationState > discardTime)
					{
						ItemBase item = DomainManager.Item.TryGetBaseItem(data.CollectionItemList[i]);
						if (item != null)
						{
							DomainManager.Item.RemoveItem(context, item.GetItemKey());
						}
						data.CollectionItemList.RemoveAt(i);
					}
					else
					{
						data.CollectionItemList[i] = new ItemKey(data.CollectionItemList[i].ItemType, (byte)(data.CollectionItemList[i].ModificationState + 1), data.CollectionItemList[i].TemplateId, data.CollectionItemList[i].Id);
					}
				}
			}
			if (data.RecruitLevelList != null)
			{
				for (int j = 0; j < data.RecruitLevelList.Count; j++)
				{
					if (data.RecruitLevelList[j].Second > discardTime)
					{
						OfflineHandleRecruitPeopleLeave(context, modification.BlockKey, j);
						instantNotifications.AddCandidateLeaved(settlementId, blockTemplateId);
					}
					else
					{
						data.RecruitLevelList[j] = new IntPair(data.RecruitLevelList[j].First, data.RecruitLevelList[j].Second + 1);
					}
				}
			}
			SetElement_CollectBuildingEarningsData(modification.BlockKey, data, context);
		}
		if (modification.CollectableEarnings != null || modification.CollectableResources != null || modification.ShopSoldItems != null || modification.RecruitLevelList != null)
		{
			if (!TryGetElement_CollectBuildingEarningsData(modification.BlockKey, out var earningsData))
			{
				earningsData = new BuildingEarningsData();
				AddElement_CollectBuildingEarningsData(modification.BlockKey, earningsData, context);
			}
			if (modification.CollectableEarnings != null)
			{
				foreach (TemplateKey templateKey in modification.CollectableEarnings)
				{
					ItemKey item2 = DomainManager.Item.CreateItem(context, templateKey.ItemType, templateKey.TemplateId);
					DomainManager.Item.SetOwner(item2, ItemOwnerType.Building, modification.BlockData.TemplateId);
					earningsData.CollectionItemList.Add(item2);
				}
			}
			if (modification.CollectableResources != null)
			{
				foreach (IntPair resourcePair in modification.CollectableResources)
				{
					earningsData.CollectionResourceList.Add(new IntPair(resourcePair.First, resourcePair.Second));
				}
			}
			if (modification.ShopBuildingSalaryList != null)
			{
				ShopEventCollection shopEventCollection = GetOrCreateShopEventCollection(modification.BlockKey);
				LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
				int date = DomainManager.World.GetCurrDate();
				foreach (var (charId, resourceType, count) in modification.ShopBuildingSalaryList)
				{
					if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
					{
						character.ChangeResource(context, resourceType, count);
						lifeRecordCollection.AddTaiwuVillagerSalaryReceived(charId, date, modification.BlockData.TemplateId, count, resourceType);
						shopEventCollection.AddSalaryReceived(date, charId, count, resourceType);
					}
				}
			}
			if (modification.RecruitLevelList != null)
			{
				earningsData.RecruitLevelList.AddRange(modification.RecruitLevelList);
			}
			if (modification.ShopSoldItems != null)
			{
				for (int k = 0; k < modification.ShopSoldItems.Count; k++)
				{
					if (modification.ShopSoldItems[k].index == -2)
					{
						int count2 = SharedMethods.GetBuildingSlotCount(modification.BlockData.TemplateId) - earningsData.ShopSoldItemList.Count;
						for (int l = 0; l < count2; l++)
						{
							earningsData.ShopSoldItemList.Add(ItemKey.Invalid);
							earningsData.ShopSoldItemEarnList.Add(new IntPair(-1, -1));
						}
						continue;
					}
					sbyte index = modification.ShopSoldItems[k].index;
					if (index < earningsData.ShopSoldItemList.Count && index >= 0)
					{
						DomainManager.Item.RemoveItem(context, earningsData.ShopSoldItemList[index]);
						earningsData.ShopSoldItemList[index] = ItemKey.Invalid;
						earningsData.ShopSoldItemEarnList[index] = new IntPair(modification.ShopSoldItems[k].exchangeResource.First, modification.ShopSoldItems[k].exchangeResource.Second);
					}
				}
			}
			SetElement_CollectBuildingEarningsData(modification.BlockKey, earningsData, context);
		}
		if (modification.LearnCombatSkills != null)
		{
			foreach (var learnSkillInfo in modification.LearnCombatSkills)
			{
				if (DomainManager.Character.TryGetElement_Objects(learnSkillInfo.charId, out var character2))
				{
					CombatSkillKey combatSkillKey = new CombatSkillKey(learnSkillInfo.charId, learnSkillInfo.skillTemplateId);
					if (DomainManager.CombatSkill.TryGetElement_CombatSkills(combatSkillKey, out var combatSkill))
					{
						ushort readingSate = combatSkill.GetReadingState();
						readingSate = CombatSkillStateHelper.SetPageRead(readingSate, learnSkillInfo.pageInternalIndex);
						DomainManager.CombatSkill.SetCombatSkillReadingState(context, combatSkill, readingSate);
					}
					else
					{
						ushort readingState = CombatSkillStateHelper.SetPageRead(0, learnSkillInfo.pageInternalIndex);
						character2.LearnNewCombatSkill(context, learnSkillInfo.skillTemplateId, readingState);
					}
					DomainManager.CombatSkill.TryActivateCombatSkillBookPageWhenSetReadingState(context, character2.GetId(), learnSkillInfo.skillTemplateId, learnSkillInfo.pageInternalIndex);
				}
			}
		}
		if (modification.LearnLifeSkills != null)
		{
			foreach (var learnSkillInfo2 in modification.LearnLifeSkills)
			{
				if (DomainManager.Character.TryGetElement_Objects(learnSkillInfo2.charId, out var character3))
				{
					int lifeSkillIndex = character3.FindLearnedLifeSkillIndex(learnSkillInfo2.skillTemplateId);
					if (lifeSkillIndex >= 0)
					{
						character3.ReadLifeSkillPage(context, lifeSkillIndex, learnSkillInfo2.pageId);
					}
					else
					{
						character3.LearnNewLifeSkill(context, learnSkillInfo2.skillTemplateId, (byte)(1 << (int)learnSkillInfo2.pageId));
					}
				}
			}
		}
		if (modification.FixBookList != null && modification.FixBookList.Count > 0)
		{
			GameData.Domains.Item.SkillBook skillBook = DomainManager.Item.GetElement_SkillBooks(modification.FixBookList[0].Id);
			if (!skillBook.CanFix())
			{
				return;
			}
			sbyte incompletePage = skillBook.GetFixProgress().pageNum;
			ushort pageState = skillBook.GetPageIncompleteState();
			pageState = SkillBookStateHelper.SetPageIncompleteState(pageState, (byte)incompletePage, 0);
			skillBook.SetPageIncompleteState(pageState, DataContextManager.GetCurrentThreadDataContext());
			if (!skillBook.CanFix())
			{
				DomainManager.World.GetInstantNotificationCollection().AddBookRepairSuccess(data.FixBookInfoList[0].ItemType, data.FixBookInfoList[0].TemplateId);
			}
		}
		if (modification.FreeShopManager)
		{
			RemoveAllManagersInBuilding(context, modification.BlockKey);
			ClearBuildingBlockEarningsData(context, modification.BlockKey, blockTemplateId == 222);
			DomainManager.Extra.TryRemoveAutoWorkBlockIndexList(context, modification.BlockKey.BuildingBlockIndex);
			DomainManager.Extra.TryRemoveAutoSoldBlockIndexList(context, modification.BlockKey.BuildingBlockIndex);
		}
		if (modification.RemoveMakeItemData && TryGetElement_MakeItemDataDict(modification.BlockKey, out var _))
		{
			RemoveElement_MakeItemDataDict(modification.BlockKey, context);
		}
		if (modification.RemoveEventBookData && _shopEventCollections != null)
		{
			_shopEventCollections.Remove(modification.BlockKey);
		}
		if (modification.RemoveCollectResourceType)
		{
			RemoveElement_CollectBuildingResourceType(modification.BlockKey, context);
		}
		if (modification.AddBuilding)
		{
			DomainManager.Taiwu.AddLegacyPoint(context, 26);
			if (DomainManager.World.IsExtraTaskInProgress(23))
			{
				DomainManager.World.FinishTriggeredExtraTask(context, 13, 23);
			}
			BuildingBlockItem config = BuildingBlock.Instance[modification.BlockData.TemplateId];
			if (BuildingBlockData.IsUsefulResource(config.Type))
			{
				List<short> list = DomainManager.Extra.GetLegaciesBuildingTemplateIdList();
				list.Remove(modification.BlockData.TemplateId);
				DomainManager.Extra.SetLegaciesBuildingTemplateIdList(list, context);
			}
			_newlyCreatedBuildingIndexes.Add(modification.BlockData.BlockIndex);
			SetNewlyCreatedBuildingIndexes(_newlyCreatedBuildingIndexes, context);
		}
		if (modification.BuildingMoneyPrestigeSuccessRateCompensationChanged != null)
		{
			DomainManager.Extra.UpdateBuildingMoneyPrestigeSuccessRateCompensation(context, modification.BuildingMoneyPrestigeSuccessRateCompensationChanged);
			modification.BuildingMoneyPrestigeSuccessRateCompensationChanged.Clear();
		}
		if (modification.BuildingOperationComplete)
		{
			UpdateTaiwuVillageBuildingEffect();
		}
	}

	public void AddBuildingException(BuildingBlockKey buildingBlockKey, BuildingBlockData buildingBlockData, BuildingExceptionType buildingExceptionType)
	{
		if (!_buildingExceptionData.BuildingExceptionDict.TryGetValue(buildingBlockKey, out var exceptionItem))
		{
			exceptionItem = new BuildingExceptionItem();
			_buildingExceptionData.BuildingExceptionDict[buildingBlockKey] = exceptionItem;
		}
		if (!exceptionItem.ExceptionTypeList.Contains((sbyte)buildingExceptionType))
		{
			exceptionItem.ExceptionTypeList.Add((sbyte)buildingExceptionType);
		}
	}

	[DomainMethod]
	public BuildingExceptionData GetBuildingExceptionData()
	{
		_buildingExceptionData.BuildingExceptionDict.Clear();
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			if (DomainManager.Building.TryGetElement_BuildingBlocks(blockKey, out var blockData) && blockData.TemplateId > 0)
			{
				BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
				if (blockData.OperationType != -1 && _buildingOperatorDict.ContainsKey(blockKey) && !blockData.OperationStopping)
				{
					List<int> charList = _buildingOperatorDict[blockKey].GetCollection();
					if (charList.Count == 0)
					{
						AddBuildingException(blockKey, blockData, (blockData.OperationType == 0) ? BuildingExceptionType.BuildStoppedForWorkerShortage : BuildingExceptionType.DemolishStoppedForWorkerShortage);
					}
				}
				if (blockData.CanUse() && configData.NeedShopProgress)
				{
					if (!HasShopManagerLeader(blockKey))
					{
						AddBuildingException(blockKey, blockData, BuildingExceptionType.ManageStoppedForNoLeader);
					}
					int productivity = BuildingProductivityByMaxDependencies(blockKey);
					if (productivity <= 0)
					{
						AddBuildingException(blockKey, blockData, BuildingExceptionType.ManageStoppedForDependency);
					}
				}
				if (configData.TemplateId == 47 && blockData.CanUse())
				{
					Feast feast = DomainManager.Extra.GetFeast(blockKey);
					if (feast.GetInUseDishSlotCount() <= 0)
					{
						DomainManager.Building.AddBuildingException(blockKey, blockData, BuildingExceptionType.ComfortableHouseEntertainNoFood);
					}
				}
				if (configData.IsShop && blockData.CanUse() && !ShopBuildingCanTeach(blockKey))
				{
					AddBuildingException(blockKey, blockData, BuildingExceptionType.LearnException);
				}
				if (blockData.OperationType != 0 && configData.MaxDurability > blockData.Durability)
				{
					AddBuildingException(blockKey, blockData, BuildingExceptionType.Damaged);
				}
				if (configData.DependBuildings.Count > 0 && SharedMethods.HasEffect(configData) && !AllDependBuildingAvailable(blockKey))
				{
					AddBuildingException(blockKey, blockData, BuildingExceptionType.EffectStoppedForDependency);
				}
			}
		}
		return _buildingExceptionData;
	}

	public int GetBuildingBlockEffect(Location location, EBuildingScaleEffect effectType, int subType = -1)
	{
		IBuildingEffectValue effectValue = GetBuildingBlockEffectObject(location, effectType);
		if (effectValue == null)
		{
			return 0;
		}
		return (subType < 0) ? effectValue.Get() : effectValue.Get(subType);
	}

	[DomainMethod]
	public int GetBuildingBlockEffect(short settlementId, EBuildingScaleEffect effectType, int subType = -1)
	{
		IBuildingEffectValue effect = GetBuildingBlockEffectObject(settlementId, effectType);
		if (effect == null)
		{
			return 0;
		}
		return (subType < 0) ? effect.Get() : effect.Get(subType);
	}

	public IBuildingEffectValue GetBuildingBlockEffectObject(Location location, EBuildingScaleEffect effectType)
	{
		if (!DomainManager.Global.IsInNormalWorld())
		{
			return null;
		}
		if (!location.IsValid())
		{
			return null;
		}
		MapBlockData mapBlock = DomainManager.Map.GetBelongSettlementBlock(location);
		if (mapBlock == null)
		{
			return null;
		}
		Location settlementLocation = new Location(mapBlock.AreaId, mapBlock.BlockId);
		IBuildingEffectValue[] effects;
		return _buildingBlockEffectsCache.TryGetValue(settlementLocation, out effects) ? effects[(int)effectType] : null;
	}

	public IBuildingEffectValue GetBuildingBlockEffectObject(short settlementId, EBuildingScaleEffect effectType)
	{
		if (!DomainManager.Global.IsInNormalWorld())
		{
			return null;
		}
		if (settlementId < 0)
		{
			return null;
		}
		Location location = DomainManager.Organization.GetSettlement(settlementId).GetLocation();
		IBuildingEffectValue[] effects;
		return _buildingBlockEffectsCache.TryGetValue(location, out effects) ? effects[(int)effectType] : null;
	}

	private void UpdateAllAreaBuildingBlockEffectsCache()
	{
		_buildingBlockEffectsCache.Clear();
		foreach (var (location2, buildingAreaData2) in _buildingAreas)
		{
			if (MapAreaData.IsRegularArea(location2.AreaId))
			{
				UpdateLocationBuildingBlockEffectsCache(location2);
			}
		}
	}

	private void UpdateLocationBuildingBlockEffectsCache(Location location)
	{
		Span<int> baseValues = stackalloc int[5];
		IBuildingEffectValue[] bonuses = _buildingBlockEffectsCache.GetOrDefault(location);
		if (bonuses == null)
		{
			bonuses = new IBuildingEffectValue[33];
			for (int i = 0; i < bonuses.Length; i++)
			{
				bonuses[i] = InitBonus((EBuildingScaleEffect)i);
			}
			_buildingBlockEffectsCache.Add(location, bonuses);
		}
		else
		{
			for (int j = 0; j < bonuses.Length; j++)
			{
				bonuses[j].Clear();
			}
		}
		for (short templateId = 1; templateId < 21; templateId++)
		{
			CalcResourceBlockEffectBaseValues(location, templateId, ref baseValues);
			BuildingBlockItem buildingBlockCfg = BuildingBlock.Instance[templateId];
			List<short> expandInfos = buildingBlockCfg.ExpandInfos;
			if (expandInfos != null && expandInfos.Count > 0)
			{
				foreach (short buildingScaleId in buildingBlockCfg.ExpandInfos)
				{
					BuildingScaleItem buildingScaleCfg = BuildingScale.Instance[buildingScaleId];
					if (buildingScaleCfg.Effect != EBuildingScaleEffect.Invalid && buildingScaleCfg.Formula >= 0)
					{
						int delta = CalcResourceBlockTotalEffectValue(buildingScaleCfg.Formula, baseValues);
						bonuses[(int)buildingScaleCfg.Effect].Change(delta);
					}
				}
			}
		}
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		bool needManage = DomainManager.Taiwu.GetTaiwuVillageLocation() == location;
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId >= 0)
			{
				BuildingBlockItem buildingBlockCfg2 = blockData.ConfigData;
				if (buildingBlockCfg2.Class != EBuildingBlockClass.BornResource)
				{
					List<short> expandInfos = buildingBlockCfg2.ExpandInfos;
					if (expandInfos != null && expandInfos.Count > 0 && !(!HasShopManagerLeader(blockKey) && needManage) && blockData.CanUse() && AllDependBuildingAvailable(blockKey, blockData.TemplateId, out var _))
					{
						_formulaContextBridge.Initialize(blockKey, buildingBlockCfg2, _formulaArgHandler);
						foreach (short buildingScaleId2 in buildingBlockCfg2.ExpandInfos)
						{
							BuildingScaleItem buildingScaleCfg2 = BuildingScale.Instance[buildingScaleId2];
							if (buildingScaleCfg2.Effect != EBuildingScaleEffect.Invalid)
							{
								ApplyScaleEffect(blockKey, buildingScaleCfg2, bonuses[(int)buildingScaleCfg2.Effect]);
							}
						}
					}
				}
			}
		}
	}

	private static int CalcBuildingFormulaContextArg(BuildingBlockKey blockKey, EBuildingFormulaArgType argType)
	{
		if (1 == 0)
		{
		}
		bool hasManager;
		int result = argType switch
		{
			EBuildingFormulaArgType.MaxAttainment => DomainManager.Building.BuildingMaxAttainment(blockKey, -1, out hasManager), 
			EBuildingFormulaArgType.TotalAttainment => DomainManager.Building.BuildingTotalAttainment(blockKey, -1, out hasManager), 
			EBuildingFormulaArgType.LeaderFameType => DomainManager.Building.BuildLeaderFameType(blockKey), 
			_ => throw new ArgumentOutOfRangeException("argType", argType, null), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private IBuildingEffectValue InitBonus(EBuildingScaleEffect effect)
	{
		if (1 == 0)
		{
		}
		BuildingEffectValue result;
		switch (effect)
		{
		case EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor:
		case EBuildingScaleEffect.BreakOutSuccessRate:
		case EBuildingScaleEffect.CombatSkillAttainment:
			result = new BuildingEffectGroupValue(14);
			break;
		case EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor:
		case EBuildingScaleEffect.ShopManagerQualificationImproveRate:
		case EBuildingScaleEffect.MakeItemAttainmentRequirementReduction:
		case EBuildingScaleEffect.LifeSkillAttainment:
			result = new BuildingEffectGroupValue(16);
			break;
		default:
			result = new BuildingEffectValue();
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}

	private void ApplyScaleEffect(BuildingBlockKey blockKey, BuildingScaleItem scaleCfg, IBuildingEffectValue value)
	{
		int delta = 0;
		List<int> levelEffect = scaleCfg.LevelEffect;
		if (levelEffect != null && levelEffect.Count > 0)
		{
			sbyte level = BuildingBlockLevel(blockKey);
			delta = scaleCfg.GetLevelEffect(level);
		}
		else if (scaleCfg.Formula >= 0)
		{
			BuildingFormulaItem formula = BuildingFormula.Instance[scaleCfg.Formula];
			delta = formula.Calculate(_formulaContextBridge);
		}
		switch (scaleCfg.Effect)
		{
		case EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor:
		case EBuildingScaleEffect.BreakOutSuccessRate:
		case EBuildingScaleEffect.CombatSkillAttainment:
			value.Change(scaleCfg.CombatSkillType, delta);
			break;
		case EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor:
		case EBuildingScaleEffect.ShopManagerQualificationImproveRate:
		case EBuildingScaleEffect.MakeItemAttainmentRequirementReduction:
		case EBuildingScaleEffect.LifeSkillAttainment:
			value.Change(scaleCfg.LifeSkillType, delta);
			break;
		default:
			value.Change(delta);
			break;
		}
	}

	public IReadOnlyList<int> GetSettlementChickenIdList(int settlementId)
	{
		IReadOnlyList<int> result;
		if (!_settlementChickenIdLists.TryGetValue(settlementId, out var list))
		{
			IReadOnlyList<int> readOnlyList = Array.Empty<int>();
			result = readOnlyList;
		}
		else
		{
			IReadOnlyList<int> readOnlyList = list;
			result = readOnlyList;
		}
		return result;
	}

	private void AddChickenInSettlementChickenIdLists(DataContext context, int chickenId, int settlementId)
	{
		if (!_settlementChickenIdLists.TryGetValue(settlementId, out var list))
		{
			list = new List<int>();
			_settlementChickenIdLists.Add(settlementId, list);
		}
		list.Add(chickenId);
		if (settlementId != DomainManager.Taiwu.GetTaiwuVillageSettlementId())
		{
			return;
		}
		foreach (KeyValuePair<int, Chicken> pair in _chicken)
		{
			if (pair.Key == chickenId)
			{
				AchievementManager.RequestSetStat(context, (short)12, (int)pair.Value.TemplateId);
				break;
			}
		}
	}

	private void RemoveChickenInSettlementChickenIdLists(int chickenId, int settlementId)
	{
		if (!_settlementChickenIdLists.TryGetValue(settlementId, out var list))
		{
			PredefinedLog.Instance[(short)30].Log(string.Join(", ", _settlementChickenIdLists.Select((KeyValuePair<int, List<int>> x) => $"{x.Key}: [{string.Join(", ", x.Value.Select((int num) => num.ToString()))}]")), string.Join(", ", _chicken.Select((KeyValuePair<int, Chicken> x) => $"{x.Value.CurrentSettlementId}: {x.Key}({x.Value.TemplateId})")), new StackTrace().ToString(), settlementId);
		}
		else if (!list.Remove(chickenId))
		{
			PredefinedLog.Instance[(short)31].Log(string.Join(", ", _settlementChickenIdLists.Select((KeyValuePair<int, List<int>> x) => $"{x.Key}: [{string.Join(", ", x.Value.Select((int num) => num.ToString()))}]")), string.Join(", ", _chicken.Select((KeyValuePair<int, Chicken> x) => $"{x.Value.CurrentSettlementId}: {x.Key}({x.Value.TemplateId})")), new StackTrace().ToString(), settlementId, chickenId);
		}
		else if (list.Count == 0)
		{
			_settlementChickenIdLists.Remove(settlementId);
		}
	}

	private void ClearSettlementChickenIdLists()
	{
		_settlementChickenIdLists.Clear();
	}

	private void TransferChickenInSettlementChickenIdLists(DataContext context, int chickenId, int fromSettlementId, int toSettlementId)
	{
		RemoveChickenInSettlementChickenIdLists(chickenId, fromSettlementId);
		AddChickenInSettlementChickenIdLists(context, chickenId, toSettlementId);
	}

	public void RefreshSettlementChickenIdLists(DataContext context)
	{
		ClearSettlementChickenIdLists();
		foreach (KeyValuePair<int, Chicken> chicken in _chicken)
		{
			AddChickenInSettlementChickenIdLists(context, chicken.Key, chicken.Value.CurrentSettlementId);
		}
	}

	[DomainMethod]
	public int AddChicken(DataContext context, int settlementId, short templateId)
	{
		int id = GenerateNextChickenId();
		Chicken chicken = new Chicken
		{
			Id = id,
			TemplateId = templateId,
			CurrentSettlementId = settlementId
		};
		AddElement_Chicken(id, chicken, context);
		AddChickenInSettlementChickenIdLists(context, id, settlementId);
		return id;
	}

	[DomainMethod]
	public void RemoveChicken(DataContext context, int id)
	{
		if (_chicken.TryGetValue(id, out var chicken))
		{
			RemoveChickenInSettlementChickenIdLists(id, chicken.CurrentSettlementId);
			RemoveElement_Chicken(id, context);
			return;
		}
		PredefinedLog.Instance[(short)32].Log(string.Join(", ", _settlementChickenIdLists.Select((KeyValuePair<int, List<int>> x) => $"{x.Key}: [{string.Join(", ", x.Value.Select((int num) => num.ToString()))}]")), string.Join(", ", _chicken.Select((KeyValuePair<int, Chicken> x) => $"{x.Value.CurrentSettlementId}: {x.Key}({x.Value.TemplateId})")), new StackTrace().ToString(), id);
	}

	[DomainMethod]
	public void RemoveAllChicken(DataContext context)
	{
		ClearSettlementChickenIdLists();
		ClearChicken(context);
	}

	[DomainMethod]
	public void MoveChicken(DataContext context, int id, int targetSettlementId)
	{
		if (!TryGetElement_Chicken(id, out var chicken))
		{
			return;
		}
		TransferChickenInSettlementChickenIdLists(context, id, chicken.CurrentSettlementId, targetSettlementId);
		chicken.CurrentSettlementId = targetSettlementId;
		SetElement_Chicken(id, chicken, context);
		if (GetSettlementChickenIdList(id).Count != 0)
		{
			return;
		}
		List<short> chickenMapInfo = ChickenMapInfo;
		if (chickenMapInfo != null && chickenMapInfo.Remove((short)chicken.CurrentSettlementId))
		{
			DomainManager.World.FinishTriggeredExtraTask(context, 48, 307);
			if (ChickenMapInfo.Count > 0)
			{
				DomainManager.World.TriggerExtraTask(context, 48, 307);
			}
		}
	}

	[DomainMethod]
	public void TransferChicken(DataContext context, int id, int targetSettlementId)
	{
		if (TryGetElement_Chicken(id, out var chicken))
		{
			chicken.Happiness = 100;
			SetElement_Chicken(id, chicken, context);
			MoveChicken(context, id, targetSettlementId);
		}
	}

	[DomainMethod]
	public bool AllChickenInTaiwuVillage(DataContext context)
	{
		return _settlementChickenIdLists.Count == 1;
	}

	[DomainMethod]
	public bool ClickChickenMap(DataContext context, bool ignoreTask = false)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location taiwuValidLocation = taiwu.GetValidLocation();
		if (taiwuValidLocation.AreaId >= 135)
		{
			return false;
		}
		short costTime = short.MaxValue;
		bool taskInProgress = DomainManager.World.IsExtraTaskInProgress(303);
		List<int> loseFeatherChickens = DomainManager.Extra.GetSectFulongLoseFeatherChickens();
		Location filterLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		Dictionary<int, List<short>> chickenInfo = new Dictionary<int, List<short>>();
		foreach (KeyValuePair<int, Chicken> pair in _chicken)
		{
			if (taskInProgress && loseFeatherChickens != null && loseFeatherChickens.Contains(pair.Key))
			{
				continue;
			}
			Settlement chickenSettlement = DomainManager.Organization.GetSettlement((short)pair.Value.CurrentSettlementId);
			Location chickenLocation = chickenSettlement.GetLocation();
			if (taiwuValidLocation.AreaId == chickenLocation.AreaId && chickenLocation != filterLocation)
			{
				if (chickenInfo.ContainsKey(chickenLocation.AreaId))
				{
					chickenInfo[chickenLocation.AreaId].Add((short)pair.Value.CurrentSettlementId);
					continue;
				}
				chickenInfo.Add(chickenLocation.AreaId, new List<short> { (short)pair.Value.CurrentSettlementId });
			}
		}
		if (chickenInfo.Count > 0)
		{
			if (!ignoreTask)
			{
				DomainManager.World.FinishTriggeredExtraTask(context, 48, 307);
				DomainManager.World.TriggerExtraTask(context, 48, 307);
			}
			ChickenMapInfo = chickenInfo.Values.ElementAt(0).Distinct().ToList();
			return true;
		}
		foreach (KeyValuePair<int, Chicken> pair2 in _chicken)
		{
			if (taskInProgress && loseFeatherChickens != null && loseFeatherChickens.Contains(pair2.Key))
			{
				continue;
			}
			Settlement chickenSettlement2 = DomainManager.Organization.GetSettlement((short)pair2.Value.CurrentSettlementId);
			Location chickenLocation2 = chickenSettlement2.GetLocation();
			if (chickenLocation2 == filterLocation)
			{
				continue;
			}
			CrossAreaMoveInfo crossAreaMoveInfo = DomainManager.Map.CalcAreaTravelRoute(taiwu, taiwuValidLocation.AreaId, taiwuValidLocation.BlockId, chickenLocation2.AreaId);
			short time = crossAreaMoveInfo.Route.GetTotalTimeCost();
			if (time < costTime)
			{
				costTime = time;
				chickenInfo.Clear();
				chickenInfo.Add(chickenLocation2.AreaId, new List<short> { (short)pair2.Value.CurrentSettlementId });
			}
			else if (time == costTime)
			{
				if (chickenInfo.ContainsKey(chickenLocation2.AreaId))
				{
					chickenInfo[chickenLocation2.AreaId].Add((short)pair2.Value.CurrentSettlementId);
					continue;
				}
				chickenInfo.Add(chickenLocation2.AreaId, new List<short> { (short)pair2.Value.CurrentSettlementId });
			}
		}
		if (!ignoreTask)
		{
			DomainManager.World.FinishTriggeredExtraTask(context, 48, 307);
		}
		if (chickenInfo.Count > 0)
		{
			ChickenMapInfo = chickenInfo.Values.ElementAt(context.Random.Next(0, chickenInfo.Count)).Distinct().ToList();
			if (!ignoreTask)
			{
				DomainManager.World.TriggerExtraTask(context, 48, 307);
			}
			return true;
		}
		ChickenMapInfo.Clear();
		return false;
	}

	public void TryFinishChickenMapTask(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int count = taiwu.GetInventory().GetInventoryItemCount(12, 370);
		if (count > 0 && AllChickenInTaiwuVillage(context))
		{
			DomainManager.World.FinishTriggeredExtraTask(context, 48, 307);
		}
	}

	[DomainMethod]
	public void ClickChickenSign(DataContext context, int chickenId)
	{
		List<int> loseFeatherChickens = DomainManager.Extra.GetSectFulongLoseFeatherChickens();
		if (!DomainManager.World.IsExtraTaskInProgress(303))
		{
			return;
		}
		foreach (KeyValuePair<int, Chicken> pair in _chicken)
		{
			if (pair.Key == chickenId && !loseFeatherChickens.Contains(chickenId))
			{
				DomainManager.TaiwuEvent.OnEvent_ClickChicken(chickenId, pair.Value.TemplateId);
				break;
			}
		}
	}

	[DomainMethod]
	public List<int> GetSettlementChickenList(int sourceSettlementId, bool ignoreFulong = true)
	{
		List<int> chickenList = GetSettlementChickenIdList(sourceSettlementId).ToList();
		if (ignoreFulong)
		{
			return chickenList;
		}
		if (DomainManager.Story.GetSectMainStoryTaskStatus(14) == 0)
		{
			Settlement settlement = DomainManager.Organization.GetSettlement((short)sourceSettlementId);
			if (DomainManager.Taiwu.GetTaiwuVillageLocation().Equals(settlement.GetLocation()))
			{
				EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(14);
				bool chickenKingLeaveHome = false;
				argBox.Get(SectMainStoryEventArgKey.DefValue.FulongChickenKingLeaveHome, ref chickenKingLeaveHome);
				if (chickenKingLeaveHome)
				{
					for (int i = chickenList.Count - 1; i >= 0; i--)
					{
						if (_chicken[chickenList[i]].TemplateId == 63)
						{
							chickenList.RemoveAt(i);
							break;
						}
					}
				}
			}
		}
		return chickenList;
	}

	public int GetChickenKingId()
	{
		foreach (KeyValuePair<int, Chicken> pair in _chicken)
		{
			if (pair.Value.TemplateId == 63)
			{
				return pair.Key;
			}
		}
		return -1;
	}

	public int GetChickenByTemplateId(short templateId)
	{
		foreach (KeyValuePair<int, Chicken> pair in _chicken)
		{
			if (pair.Value.TemplateId == templateId)
			{
				return pair.Key;
			}
		}
		return -1;
	}

	[DomainMethod]
	public List<Chicken> GetSettlementChickenDataList(Location location, bool ignoreFulong = true)
	{
		int sourceSettlementId = DomainManager.Organization.GetSettlementByLocation(location).GetId();
		List<int> chickenKeyList = GetSettlementChickenList(sourceSettlementId, ignoreFulong);
		List<Chicken> chickenList = new List<Chicken>();
		for (int i = 0; i < chickenKeyList.Count; i++)
		{
			Chicken chickenData = GetChickenData(chickenKeyList[i]);
			chickenList.Add(chickenData);
		}
		return chickenList;
	}

	[DomainMethod]
	public List<int> GetSettlementChickenIdList(Location location)
	{
		int sourceSettlementId = DomainManager.Organization.GetSettlementByLocation(location).GetId();
		return GetSettlementChickenList(sourceSettlementId);
	}

	[DomainMethod]
	public Chicken GetChickenData(int id)
	{
		Chicken chicken;
		return (!TryGetElement_Chicken(id, out chicken)) ? default(Chicken) : chicken;
	}

	[DomainMethod]
	public List<Chicken> GetChickenDataList(List<int> idList)
	{
		List<Chicken> chickenList = new List<Chicken>();
		if (idList == null)
		{
			return chickenList;
		}
		foreach (int id in idList)
		{
			if (TryGetElement_Chicken(id, out var chicken))
			{
				chickenList.Add(chicken);
			}
			else
			{
				chickenList.Add(default(Chicken));
			}
		}
		return chickenList;
	}

	[DomainMethod]
	public void SetNickNameByChickenId(DataContext context, int id, string nickname)
	{
		if (nickname == null)
		{
			nickname = string.Empty;
		}
		int textId;
		if (DomainManager.Extra.CheckChickenHasNickname(id))
		{
			textId = DomainManager.Extra.GetElement_NicknameDict(id);
			if (DomainManager.World.TryGetElement_CustomTexts(textId, out var customName) && !string.IsNullOrEmpty(customName) && customName.Equals(nickname))
			{
				return;
			}
			DomainManager.World.UnregisterCustomText(context, textId);
		}
		textId = DomainManager.World.RegisterCustomText(context, nickname);
		DomainManager.Extra.SetNicknameByChickenId(id, textId, context);
	}

	[DomainMethod]
	public List<string> GetChickensNicknameByLocation(Location location)
	{
		int sourceSettlementId = DomainManager.Organization.GetSettlementByLocation(location).GetId();
		List<int> chickens = GetSettlementChickenList(sourceSettlementId);
		return GetChickenNicknameList(chickens);
	}

	[DomainMethod]
	public List<string> GetChickenNicknameList(List<int> chickenIdList)
	{
		List<string> nicknames = new List<string>();
		if (chickenIdList == null)
		{
			return nicknames;
		}
		foreach (int id in chickenIdList)
		{
			if (DomainManager.Extra.CheckChickenHasNickname(id))
			{
				int textId = DomainManager.Extra.GetElement_NicknameDict(id);
				nicknames.Add(DomainManager.World.GetElement_CustomTexts(textId));
			}
			else
			{
				nicknames.Add("");
			}
		}
		return nicknames;
	}

	[DomainMethod]
	public sbyte FeedChicken(DataContext context, int id, ItemKey itemKey)
	{
		return FeedChickenWithArgs(context, id, itemKey, ItemSourceType.Inventory);
	}

	[DomainMethod]
	public bool SetFulongChicken(DataContext context, short orgMemberTemplateId, int chickenId)
	{
		DomainManager.Extra.TryGetElement_SectFulongOrgMemberChickens(orgMemberTemplateId, out var chickenIds);
		List<int> items = chickenIds.Items;
		if (items != null && items.Contains(chickenId))
		{
			return false;
		}
		ref List<int> items2 = ref chickenIds.Items;
		if (items2 == null)
		{
			items2 = new List<int>();
		}
		chickenIds.Items.Add(chickenId);
		DomainManager.Extra.AddOrSetFulongChickens(context, orgMemberTemplateId, chickenIds);
		return true;
	}

	[DomainMethod]
	public bool UnsetFulongChicken(DataContext context, short orgMemberTemplateId, int chickenId)
	{
		DomainManager.Extra.TryGetElement_SectFulongOrgMemberChickens(orgMemberTemplateId, out var chickenIds);
		List<int> items = chickenIds.Items;
		if (items == null || !items.Contains(chickenId))
		{
			return false;
		}
		chickenIds.Items.Remove(chickenId);
		DomainManager.Extra.AddOrSetFulongChickens(context, orgMemberTemplateId, chickenIds);
		return true;
	}

	[DomainMethod]
	public void QuickAssignChicken(DataContext context, short orgMemberTemplateId)
	{
		DomainManager.Extra.TryGetElement_SectFulongOrgMemberChickens(orgMemberTemplateId, out var currentChickenIds);
		if (currentChickenIds.Items == null)
		{
			currentChickenIds.Items = new List<int>();
		}
		if (currentChickenIds.Items.Count >= 9)
		{
			return;
		}
		int roleId = OrganizationMember.Instance[orgMemberTemplateId].Grade - 1;
		VillagerRoleItem roleConfig = VillagerRole.Instance[roleId];
		HashSet<int> allAssignedChickenIds = new HashSet<int>();
		foreach (VillagerRoleItem item in (IEnumerable<VillagerRoleItem>)VillagerRole.Instance)
		{
			foreach (Chicken fulongChicken in DomainManager.Building.GetFulongChickens(item.OrganizationMember))
			{
				allAssignedChickenIds.Add(fulongChicken.Id);
			}
		}
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		List<Chicken> allChickenData = GetSettlementChickenDataList(taiwuLocation);
		foreach (Chicken chicken in allChickenData)
		{
			if (allAssignedChickenIds.Contains(chicken.Id) || chicken.TemplateId == 63)
			{
				continue;
			}
			ChickenItem chickenConfig = Config.Chicken.Instance[chicken.TemplateId];
			for (int i = 0; i < roleConfig.NeedPersonalityList.Length; i++)
			{
				if (chickenConfig.PersonalityType == roleConfig.NeedPersonalityList[i].PersonalityType)
				{
					currentChickenIds.Items.Add(chicken.Id);
					if (currentChickenIds.Items.Count >= 9)
					{
						break;
					}
				}
			}
		}
		DomainManager.Extra.AddOrSetFulongChickens(context, orgMemberTemplateId, currentChickenIds);
	}

	public IEnumerable<Chicken> GetFulongChickens(short orgMemberTemplateId)
	{
		if (!DomainManager.Extra.TryGetElement_SectFulongOrgMemberChickens(orgMemberTemplateId, out var chickens))
		{
			yield break;
		}
		List<int> items = chickens.Items;
		if (items == null || items.Count <= 0)
		{
			yield break;
		}
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		foreach (int chickenId in chickens.Items)
		{
			if (_chicken.TryGetValue(chickenId, out var chicken) && chicken.CurrentSettlementId == taiwuSettlementId)
			{
				yield return chicken;
			}
		}
	}

	public bool HasFulongChicken(VillagerRoleItem role)
	{
		if (DomainManager.Extra.TryGetElement_SectFulongOrgMemberChickens(role.OrganizationMember, out var chickenList))
		{
			List<int> items = chickenList.Items;
			if (items != null && items.Count > 0)
			{
				return IsVillagerRoleExtraEffectUnlockState(role);
			}
		}
		return false;
	}

	[DomainMethod]
	public List<bool> GetVillagerRoleExtraEffectUnlockState()
	{
		List<bool> result = new List<bool>();
		foreach (VillagerRoleItem roleConfig in (IEnumerable<VillagerRoleItem>)VillagerRole.Instance)
		{
			result.Add(IsVillagerRoleExtraEffectUnlockState(roleConfig));
		}
		return result;
	}

	private static bool IsVillagerRoleExtraEffectUnlockState(VillagerRoleItem roleConfig)
	{
		bool found = false;
		int[] hasPersonalityCount = new int[roleConfig.NeedPersonalityList.Length];
		foreach (Chicken chicken in DomainManager.Building.GetFulongChickens(roleConfig.OrganizationMember))
		{
			found = true;
			ChickenItem chickenConfig = Config.Chicken.Instance[chicken.TemplateId];
			for (int i = 0; i < roleConfig.NeedPersonalityList.Length; i++)
			{
				if (chickenConfig.PersonalityType == roleConfig.NeedPersonalityList[i].PersonalityType)
				{
					hasPersonalityCount[i]++;
				}
			}
		}
		if (!found)
		{
			return false;
		}
		bool isUnlock = true;
		for (int j = 0; j < roleConfig.NeedPersonalityList.Length; j++)
		{
			if (hasPersonalityCount[j] < roleConfig.NeedPersonalityList[j].NeedCount)
			{
				isUnlock = false;
				break;
			}
		}
		return isUnlock;
	}

	private sbyte FeedChickenWithArgs(DataContext context, int templateId, ItemKey itemKey, ItemSourceType itemSourceType)
	{
		sbyte resValue = 0;
		if (!TryGetElement_ChickenByTemplateId(templateId, out var chicken))
		{
			return 0;
		}
		if (ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == 1204)
		{
			resValue = GlobalConfig.Instance.ChickenMiscTaste;
			chicken.Happiness += GlobalConfig.Instance.ChickenMiscTaste;
		}
		else if (itemKey.ItemType == 11)
		{
			ItemDisplayData cricket = DomainManager.Item.GetItemDisplayData(itemKey);
			CricketPartsItem part = null;
			part = ((ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId) < 7) ? CricketParts.Instance[cricket.CricketPartId] : CricketParts.Instance[cricket.CricketPartId + cricket.CricketColorId]);
			sbyte taste = part.Taste;
			if (part.Type != ECricketPartsType.Trash && part.Type != ECricketPartsType.RealColor && part.Type != ECricketPartsType.King)
			{
				taste += CricketParts.Instance[cricket.CricketColorId].Taste;
			}
			resValue = taste;
			chicken.Happiness += taste;
		}
		else if (itemKey.ItemType == 5)
		{
			resValue = DomainManager.Item.GetElement_Materials(itemKey.Id).GetHappinessChange();
			chicken.Happiness += resValue;
		}
		if (chicken.Happiness < 0)
		{
			chicken.Happiness = 100;
		}
		chicken.Happiness = Math.Max(0, Math.Min(chicken.Happiness, 100));
		SetElement_Chicken(chicken.Id, chicken, context);
		switch (itemSourceType)
		{
		case ItemSourceType.Inventory:
		{
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			taiwu.RemoveInventoryItem(context, itemKey, 1, deleteItem: true);
			break;
		}
		case ItemSourceType.Trough:
			DomainManager.Taiwu.TroughRemove(context, itemKey, 1, deleteItem: true);
			break;
		}
		return resValue;
	}

	public bool TryGetFirstChickenInSettlement(Settlement settlement, out Chicken chicken)
	{
		chicken = default(Chicken);
		short settlementId = settlement.GetId();
		foreach (KeyValuePair<int, Chicken> kvp in _chicken)
		{
			if (kvp.Value.CurrentSettlementId == settlementId)
			{
				chicken = kvp.Value;
				return true;
			}
		}
		return false;
	}

	public bool TryGetElement_ChickenByTemplateId(int templateId, out Chicken value)
	{
		foreach (int key in _chicken.Keys)
		{
			if (_chicken[key].TemplateId == templateId)
			{
				value = _chicken[key];
				return true;
			}
		}
		value = default(Chicken);
		return false;
	}

	internal bool CanSettlementHaveChicken(Location settlementLocation)
	{
		short blockId = settlementLocation.BlockId;
		if (blockId >= 0)
		{
			MapBlockData block = DomainManager.Map.GetBlock(settlementLocation.AreaId, blockId);
			if (block.TemplateId == 34 || block.TemplateId == 35 || block.TemplateId == 36 || block.BlockType == EMapBlockType.City)
			{
				return true;
			}
		}
		return false;
	}

	internal List<int> GetChickenSettlements()
	{
		List<int> chickenSettlements = new List<int>();
		for (short areaId = 0; areaId < 135; areaId++)
		{
			MapAreaData area = DomainManager.Map.GetElement_Areas(areaId);
			SettlementInfo[] settlementInfos = area.SettlementInfos;
			for (int i = 0; i < settlementInfos.Length; i++)
			{
				SettlementInfo settlementInfo = settlementInfos[i];
				if (CanSettlementHaveChicken(new Location(areaId, settlementInfo.BlockId)))
				{
					chickenSettlements.Add(settlementInfo.SettlementId);
				}
			}
		}
		return chickenSettlements;
	}

	protected List<int> _GetChickenVillageSettlements()
	{
		List<int> chickenSettlements = new List<int>();
		for (short areaId = 0; areaId < 135; areaId++)
		{
			MapAreaData area = DomainManager.Map.GetElement_Areas(areaId);
			SettlementInfo[] settlementInfos = area.SettlementInfos;
			for (int i = 0; i < settlementInfos.Length; i++)
			{
				SettlementInfo settlementInfo = settlementInfos[i];
				short blockId = settlementInfo.BlockId;
				if (blockId >= 0)
				{
					MapBlockData block = DomainManager.Map.GetBlock(areaId, blockId);
					if (block.TemplateId == 34)
					{
						chickenSettlements.Add(settlementInfo.SettlementId);
					}
				}
			}
		}
		return chickenSettlements;
	}

	[DomainMethod]
	public void InitMapBlockChicken(DataContext context)
	{
		if (!DomainManager.Extra.IsDreamBack() || _chicken.Count == 1)
		{
			ForceInitMapBlockChicken(context);
		}
	}

	internal void ForceInitMapBlockChicken(DataContext context)
	{
		List<short> chicken = new List<short>();
		List<int> chickenSettlements = GetChickenSettlements();
		for (int i = 0; i < Config.Chicken.Instance.Count; i++)
		{
			if (Config.Chicken.Instance[i].TemplateId != 63)
			{
				chicken.Add(Config.Chicken.Instance[i].TemplateId);
			}
		}
		CollectionUtils.Shuffle(context.Random, chickenSettlements);
		bool hasChickenKing = false;
		Chicken king = default(Chicken);
		foreach (int key in _chicken.Keys)
		{
			if (_chicken[key].TemplateId == 63)
			{
				hasChickenKing = true;
				king = _chicken[key];
			}
		}
		ClearChicken(context);
		if (hasChickenKing)
		{
			AddElement_Chicken(_chicken.Count, king, context);
		}
		while (chicken.Count > 0 && chickenSettlements.Count > 0)
		{
			short chickTemplateId = chicken[0];
			int chickSettlement = chickenSettlements[0];
			AddChicken(context, chickSettlement, chickTemplateId);
			chicken.RemoveAt(0);
			chickenSettlements.RemoveAt(0);
		}
	}

	[DomainMethod]
	public bool IsHaveChickenKing(DataContext context)
	{
		short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		List<int> idList = GetSettlementChickenList(settlementId);
		if (idList.Count == 0)
		{
			return false;
		}
		for (int i = 0; i < idList.Count; i++)
		{
			if (_chicken[idList[i]].TemplateId == 63)
			{
				return true;
			}
		}
		return false;
	}

	public void UpdateChickenInstances(DataContext context)
	{
		UpdateFeatherValue(context);
		Dictionary<int, List<int>> chickenSettlementTable = new Dictionary<int, List<int>>();
		foreach (int settlementId in GetChickenSettlements())
		{
			chickenSettlementTable.Add(settlementId, new List<int>());
		}
		int[] array = _chicken.Keys.ToArray();
		foreach (int id in array)
		{
			Chicken chicken = _chicken[id];
			if (!chickenSettlementTable.ContainsKey(chicken.CurrentSettlementId))
			{
				chickenSettlementTable.Add(chicken.CurrentSettlementId, new List<int>());
			}
			chickenSettlementTable[chicken.CurrentSettlementId].Add(chicken.Id);
			if (id != chicken.Id)
			{
				chicken.Id = id;
				SetElement_Chicken(id, chicken, context);
			}
		}
		RefreshSettlementChickenIdLists(context);
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		Chicken[] array2 = _chicken.Values.ToArray();
		for (int j = 0; j < array2.Length; j++)
		{
			Chicken item = array2[j];
			Chicken chicken2 = item;
			if (chicken2.TemplateId == 63)
			{
				if (chicken2.Happiness != 100)
				{
					SetChickenHappiness(context, chicken2.Id, 100);
				}
			}
			else if (DomainManager.Taiwu.GetTaiwuVillageSettlementId() == chicken2.CurrentSettlementId)
			{
				int chickenDecayMultiple = 1;
				Location location = DomainManager.Organization.GetSettlement(DomainManager.Taiwu.GetTaiwuVillageSettlementId()).GetLocation();
				int chickenCoopCount = 0;
				foreach (BuildingBlockData buildingBlock in DomainManager.Building.GetBuildingBlockList(location))
				{
					if (buildingBlock.TemplateId == 49)
					{
						chickenCoopCount++;
					}
				}
				if (chickenCoopCount == 0)
				{
					chickenDecayMultiple = 3;
				}
				chicken2.Happiness = (sbyte)Math.Max(0, chicken2.Happiness - chickenDecayMultiple * context.Random.Next(GlobalConfig.Instance.ChickenDecayMin, GlobalConfig.Instance.ChickenDecayMax));
				SetChickenHappiness(context, chicken2.Id, chicken2.Happiness);
				while (chicken2.Happiness < 50 && DomainManager.Taiwu.TroughItems.Count > 0)
				{
					ItemKey itemKey = DomainManager.Taiwu.TroughItems.OrderBy((KeyValuePair<ItemKey, int> pair) => ItemTemplateHelper.GetGrade(pair.Key.ItemType, pair.Key.TemplateId)).First().Key;
					sbyte change = FeedChickenWithArgs(context, chicken2.TemplateId, itemKey, ItemSourceType.Trough);
					chicken2.Happiness += change;
				}
				if (chicken2.Happiness <= 0)
				{
					int? nextTargetSettlementId = null;
					foreach (var (settlementId2, list2) in chickenSettlementTable)
					{
						if (list2.Count == 0)
						{
							nextTargetSettlementId = settlementId2;
							list2.Add(chicken2.Id);
							break;
						}
					}
					chickenSettlementTable[chicken2.CurrentSettlementId].Remove(chicken2.Id);
					if (!nextTargetSettlementId.HasValue)
					{
						throw new Exception($"chicken: #{chicken2.Id} cannot find a next settlement for escape");
					}
					chicken2.CurrentSettlementId = nextTargetSettlementId.Value;
					monthlyNotifications.AddChickenEscaped(chicken2.TemplateId);
				}
			}
			short featureId = Config.Chicken.Instance[chicken2.TemplateId].FeatureId;
			if (featureId >= 0)
			{
				int[] characterList = (from data in DomainManager.Organization.GetSettlementMembers((short)chicken2.CurrentSettlementId)
					select data.CharacterId).Where(delegate(int objectId)
				{
					GameData.Domains.Character.Character element_Objects = DomainManager.Character.GetElement_Objects(objectId);
					List<short> chickenFeatures = element_Objects.GetChickenFeatures();
					return !chickenFeatures.Contains(featureId);
				}).ToArray();
				if (characterList.Any())
				{
					CollectionUtils.Shuffle(context.Random, characterList);
					int characterId = characterList.First();
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(characterId);
					character.AddFeature(context, featureId);
				}
			}
			SetElement_Chicken(item.Id, chicken2, context);
		}
	}

	public void SetChickenHappiness(DataContext context, int chickenId, sbyte happiness)
	{
		Chicken chicken = GetChickenData(chickenId);
		chicken.Happiness = Math.Clamp(happiness, 0, 100);
		SetElement_Chicken(chickenId, chicken, context);
	}

	private int GenerateNextChickenId()
	{
		int id = _nextChickenId;
		_nextChickenId++;
		return id;
	}

	private void InitializeNextChickenId()
	{
		foreach (int id in _chicken.Keys)
		{
			if (id >= _nextChickenId)
			{
				_nextChickenId = id + 1;
			}
		}
	}

	public void SaveChicken(DataContext context)
	{
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		foreach (Chicken chicken in _chicken.Values)
		{
			if (chicken.CurrentSettlementId == taiwuSettlementId)
			{
				DomainManager.Global.AddChicken(context, chicken.TemplateId);
			}
		}
	}

	[DomainMethod]
	public int GetCurrentFeatherValue()
	{
		return _featherValue;
	}

	[DomainMethod]
	public ChickenPluckFeatherDisplayData GetChickenPluckFeatherDisplayData()
	{
		if (!IsFeatherSystemUnlocked())
		{
			return new ChickenPluckFeatherDisplayData();
		}
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		IReadOnlyList<int> chickensInVillage = GetSettlementChickenIdList(taiwuSettlementId);
		int canPluckCount = chickensInVillage.Count((int id) => _chicken.TryGetValue(id, out var value) && value.CanPluckFeather);
		int monthlyIncrease = GlobalConfig.Instance.FeatherValueBaseMonthly + chickensInVillage.Count * GlobalConfig.Instance.FeatherValuePerChicken;
		return new ChickenPluckFeatherDisplayData
		{
			FeatherValue = _featherValue,
			ChickenCount = chickensInVillage.Count,
			CanPluckCount = canPluckCount,
			MonthlyIncrease = monthlyIncrease,
			RemainingDays = DomainManager.Extra.GetActionPointCurrMonth() / 10
		};
	}

	[DomainMethod]
	public bool IsFeatherSystemUnlocked()
	{
		return DomainManager.Organization.GetSectFunctionStatus(14, SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked);
	}

	[DomainMethod]
	public void UnlockFeatherSystem(DataContext context)
	{
		_featherValue = GlobalConfig.Instance.InitialFeatherValue;
		SetFeatherValue(_featherValue, context);
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		List<int> chickensInVillage = (from id in GetSettlementChickenIdList(taiwuSettlementId)
			where _chicken.TryGetValue(id, out var value) && !value.CanPluckFeather
			select id).ToList();
		CollectionUtils.Shuffle(context.Random, chickensInVillage);
		int count = Math.Min(GlobalConfig.Instance.InitialFeatherChickens, chickensInVillage.Count);
		for (int i = 0; i < count; i++)
		{
			SetChickenCanPluckFeather(context, chickensInVillage[i], canPluck: true);
		}
	}

	public void UpdateFeatherValue(DataContext context)
	{
		if (IsFeatherSystemUnlocked())
		{
			short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
			IReadOnlyList<int> chickensInVillage = GetSettlementChickenIdList(taiwuSettlementId);
			int monthlyIncrease = GlobalConfig.Instance.FeatherValueBaseMonthly + chickensInVillage.Count * GlobalConfig.Instance.FeatherValuePerChicken;
			_featherValue = Math.Min(_featherValue + monthlyIncrease, GlobalConfig.Instance.FeatherValueMax);
			ProcessFeatherProduction(context, chickensInVillage, isAddNotification: true);
			SetFeatherValue(_featherValue, context);
		}
	}

	private void ProcessFeatherProduction(DataContext context, IReadOnlyList<int> chickensInVillage, bool isAddNotification = false)
	{
		List<int> availableChickens = chickensInVillage.Where((int id) => _chicken.TryGetValue(id, out var value) && !value.CanPluckFeather).ToList();
		int producedCount = 0;
		while (_featherValue >= GlobalConfig.Instance.FeatherValuePerFeather && availableChickens.Count > 0)
		{
			int randomIndex = context.Random.Next(availableChickens.Count);
			int chickenId = availableChickens[randomIndex];
			SetChickenCanPluckFeather(context, chickenId, canPluck: true);
			availableChickens.RemoveAt(randomIndex);
			_featherValue -= GlobalConfig.Instance.FeatherValuePerFeather;
			producedCount++;
		}
		if (isAddNotification)
		{
			bool allCanPluck = chickensInVillage.All((int id) => _chicken.TryGetValue(id, out var value) && value.CanPluckFeather);
			MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
			if (allCanPluck && chickensInVillage.Count > 0)
			{
				monthlyNotifications.AddChickenFullyFledged();
			}
		}
	}

	private void SetChickenCanPluckFeather(DataContext context, int chickenId, bool canPluck)
	{
		if (TryGetElement_Chicken(chickenId, out var chicken))
		{
			chicken.CanPluckFeather = canPluck;
			SetElement_Chicken(chickenId, chicken, context);
		}
	}

	[DomainMethod]
	public List<ItemDisplayData> PluckChickenFeather(DataContext context, int chickenId)
	{
		if (!TryGetElement_Chicken(chickenId, out var chicken))
		{
			return null;
		}
		if (!chicken.CanPluckFeather)
		{
			return null;
		}
		List<ItemDisplayData> res = new List<ItemDisplayData>();
		ChickenItem chickenConfig = Config.Chicken.Instance[chicken.TemplateId];
		sbyte personalityType = chickenConfig.PersonalityType;
		int featherCount = ((chicken.TemplateId != 63) ? 1 : GlobalConfig.Instance.KingFeatherCount);
		chicken.CanPluckFeather = false;
		SetElement_Chicken(chickenId, chicken, context);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		bool isKing = chicken.TemplateId == 63;
		for (int i = 0; i < featherCount; i++)
		{
			sbyte featherPersonalityType = (isKing ? ((sbyte)context.Random.Next(0, 7)) : personalityType);
			short featherItemId = GetChickenFeatherItemId(featherPersonalityType);
			ItemKey itemKey = DomainManager.Item.CreateMaterial(context, featherItemId);
			DomainManager.Taiwu.AddItem(context, itemKey, 1, ItemSourceType.Warehouse);
			res.Add(DomainManager.Item.GetItemDisplayData(itemKey, taiwu.GetId()));
		}
		return res;
	}

	private short GetChickenFeatherItemId(sbyte personalityType)
	{
		return (short)(343 + personalityType);
	}

	[DomainMethod]
	public void TriggerCultivateFeatherEvent()
	{
		DomainManager.TaiwuEvent.OnEvent_OnClickedCultivateFeather();
	}

	[DomainMethod]
	public bool CultivateFeather(DataContext context)
	{
		if (!IsFeatherSystemUnlocked())
		{
			return false;
		}
		_featherValue = Math.Min(_featherValue + GlobalConfig.Instance.CultivateFeatherValue, GlobalConfig.Instance.FeatherValueMax);
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		IReadOnlyList<int> chickensInVillage = GetSettlementChickenIdList(taiwuSettlementId);
		ProcessFeatherProduction(context, chickensInVillage);
		SetFeatherValue(_featherValue, context);
		return true;
	}

	[DomainMethod]
	public bool CanCultivateFeather()
	{
		if (!IsFeatherSystemUnlocked())
		{
			return false;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		sbyte[] resourceTypes = new sbyte[7] { 2, 1, 0, 4, 3, 5, 6 };
		sbyte[] array = resourceTypes;
		foreach (sbyte resourceType in array)
		{
			if (taiwu.GetResource(resourceType) < GlobalConfig.Instance.CultivateCost)
			{
				return false;
			}
		}
		return true;
	}

	[DomainMethod]
	public bool CanPluckFeatherInVillage(int chickenId)
	{
		if (!TryGetElement_Chicken(chickenId, out var chicken))
		{
			return false;
		}
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		return chicken.CanPluckFeather && chicken.CurrentSettlementId == taiwuSettlementId;
	}

	[DomainMethod]
	public bool UseChickenFeather(DataContext context, int characterId, ItemKey itemKey, sbyte personalityType)
	{
		if (!IsFeatherSystemUnlocked())
		{
			return false;
		}
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(characterId);
		if (character == null)
		{
			return false;
		}
		(short, sbyte)? chickenFeature = GetBestChickenFeatureByPersonality(context, personalityType, character);
		if (!chickenFeature.HasValue)
		{
			return false;
		}
		character.AddFeature(context, chickenFeature.Value.Item1, removeMutexFeature: true);
		character.RemoveInventoryItem(context, itemKey, 1, deleteItem: false);
		return true;
	}

	[DomainMethod]
	public bool CanUseChickenFeather(DataContext context, int characterId, sbyte personalityType)
	{
		if (!IsFeatherSystemUnlocked())
		{
			return false;
		}
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(characterId);
		if (character == null)
		{
			return false;
		}
		return GetBestChickenFeatureByPersonality(context, personalityType, character).HasValue;
	}

	private (short FeatureId, sbyte Grade)? GetBestChickenFeatureByPersonality(DataContext context, sbyte personalityType, GameData.Domains.Character.Character character)
	{
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		IReadOnlyList<int> chickensInVillage = GetSettlementChickenIdList(taiwuSettlementId);
		List<(Chicken, ChickenItem)> chickensOfPersonality = (from id in chickensInVillage
			where _chicken.TryGetValue(id, out var value) && value.TemplateId != 63
			select (Chicken: _chicken[id], Config: Config.Chicken.Instance[_chicken[id].TemplateId]) into x
			where x.Config.PersonalityType == personalityType && x.Config.FeatureId >= 0
			orderby x.Config.Grade descending
			select x).ToList();
		if (chickensOfPersonality.Count == 0)
		{
			return null;
		}
		List<short> existingFeatures = character.GetChickenFeatures();
		if (existingFeatures.Contains(chickensOfPersonality.First().Item2.FeatureId))
		{
			return null;
		}
		foreach (var item in chickensOfPersonality)
		{
			if (!existingFeatures.Contains(item.Item2.FeatureId))
			{
				return (item.Item2.FeatureId, item.Item2.Grade);
			}
		}
		return null;
	}

	[DomainMethod]
	public List<Chicken> GetChickensByPersonalityType(sbyte personalityType)
	{
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		IReadOnlyList<int> chickensInVillage = GetSettlementChickenIdList(taiwuSettlementId);
		return (from id in chickensInVillage
			where _chicken.TryGetValue(id, out var value) && value.TemplateId != 63
			select (Chicken: _chicken[id], Config: Config.Chicken.Instance[_chicken[id].TemplateId]) into x
			where x.Config.PersonalityType == personalityType
			orderby x.Config.Grade descending
			select x.Chicken).ToList();
	}

	[DomainMethod]
	public List<short> GetCharacterChickenFeatures(int characterId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(characterId);
		if (character == null)
		{
			return new List<short>();
		}
		return character.GetChickenFeatures().ToList();
	}

	[DomainMethod]
	public bool IsAllChickensCanPluck()
	{
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		IReadOnlyList<int> chickensInVillage = GetSettlementChickenIdList(taiwuSettlementId);
		if (chickensInVillage.Count == 0)
		{
			return false;
		}
		return chickensInVillage.All((int id) => _chicken.TryGetValue(id, out var value) && value.CanPluckFeather);
	}

	[DomainMethod]
	public bool IsAnyChickensCanPluck()
	{
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		IReadOnlyList<int> chickensInVillage = GetSettlementChickenIdList(taiwuSettlementId);
		return chickensInVillage.Count != 0 && chickensInVillage.Any((int id) => _chicken.TryGetValue(id, out var value) && value.CanPluckFeather);
	}

	[DomainMethod]
	public List<ItemDisplayData> PluckAllChickenFeathers(DataContext context)
	{
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		IReadOnlyList<int> chickensInVillage = GetSettlementChickenIdList(taiwuSettlementId);
		List<ItemDisplayData> res = new List<ItemDisplayData>();
		foreach (int chickenId in chickensInVillage)
		{
			if (_chicken.TryGetValue(chickenId, out var chicken) && chicken.CanPluckFeather)
			{
				res.AddRange(PluckChickenFeather(context, chickenId));
			}
		}
		return res;
	}

	[DomainMethod]
	public List<int> GetCanPluckFeatherChickenIds()
	{
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		IReadOnlyList<int> chickensInVillage = GetSettlementChickenIdList(taiwuSettlementId);
		return chickensInVillage.Where((int id) => _chicken.TryGetValue(id, out var value) && value.CanPluckFeather).ToList();
	}

	internal sbyte BuildingBlockLevel(BuildingBlockKey blockKey)
	{
		if (blockKey.IsInvalid)
		{
			return 0;
		}
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		Location location = new Location(blockKey.AreaId, blockKey.BlockId);
		BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
		BuildingBlockItem config = BuildingBlock.Instance[blockData.TemplateId];
		if (!taiwuLocation.Equals(location))
		{
			return Math.Min(blockData.Level, config.MaxLevel);
		}
		if (config == null)
		{
			return 1;
		}
		if (config.MaxLevel > 1)
		{
			if (config.Type == EBuildingBlockType.UselessResource)
			{
				return blockData.Level;
			}
			return Math.Min(config.MaxLevel, blockData.CalcUnlockedLevelCount());
		}
		return config.MaxLevel;
	}

	internal void BuildingBlockDependencies(BuildingBlockKey blockKey, Action<BuildingBlockData, int, BuildingBlockKey> onDependencyFound)
	{
		if (!TryGetElement_BuildingAreas(blockKey.GetLocation(), out var areaData) || !TryGetElement_BuildingBlocks(blockKey, out var buildingBlockData))
		{
			return;
		}
		BuildingBlockItem buildingBlockConfig = BuildingBlock.Instance.GetItem(buildingBlockData.TemplateId);
		List<short> neighborList = ObjectPool<List<short>>.Instance.Get();
		List<int> neighborDistanceList = ObjectPool<List<int>>.Instance.Get();
		Dictionary<short, int> resultMap = ObjectPool<Dictionary<short, int>>.Instance.Get();
		resultMap.Clear();
		areaData.GetNeighborBlocks(blockKey.BuildingBlockIndex, buildingBlockConfig.Width, neighborList, neighborDistanceList, 2);
		foreach (short dependBlockTemplateId in buildingBlockConfig.DependBuildings)
		{
			for (int i = 0; i < neighborList.Count; i++)
			{
				BuildingBlockKey neighborKey = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborList[i]);
				if (!TryGetElement_BuildingBlocks(neighborKey, out var neighborBlock))
				{
					continue;
				}
				if (neighborBlock.RootBlockIndex >= 0)
				{
					neighborKey = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, neighborBlock.RootBlockIndex);
					neighborBlock = GetElement_BuildingBlocks(neighborKey);
				}
				if (neighborBlock.TemplateId == dependBlockTemplateId)
				{
					int currentDistance = neighborDistanceList[i];
					if (!resultMap.TryGetValue(neighborKey.BuildingBlockIndex, out var existDistance) || existDistance >= currentDistance)
					{
						resultMap[neighborKey.BuildingBlockIndex] = currentDistance;
					}
				}
			}
		}
		foreach (KeyValuePair<short, int> pair in resultMap)
		{
			BuildingBlockKey neighborKey2 = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, pair.Key);
			onDependencyFound(GetElement_BuildingBlocks(neighborKey2), pair.Value, neighborKey2);
		}
		ObjectPool<Dictionary<short, int>>.Instance.Return(resultMap);
		ObjectPool<List<short>>.Instance.Return(neighborList);
		ObjectPool<List<int>>.Instance.Return(neighborDistanceList);
	}

	internal void BuildingBlockInfluences(BuildingBlockKey blockKey, Action<BuildingBlockData, int> onInfluenceFound)
	{
		if (TryGetElement_BuildingAreas(blockKey.GetLocation(), out var areaData) && TryGetElement_BuildingBlocks(blockKey, out var buildingBlockData))
		{
			BuildingBlockItem buildingBlockConfig = BuildingBlock.Instance.GetItem(buildingBlockData.TemplateId);
			List<short> neighborList = ObjectPool<List<short>>.Instance.Get();
			List<int> neighborDistanceList = ObjectPool<List<int>>.Instance.Get();
			areaData.GetNeighborBlocks(blockKey.BuildingBlockIndex, buildingBlockConfig.Width, neighborList, neighborDistanceList, 2);
			buildingBlockData.CalcInfluences(neighborList.Select(delegate(short index)
			{
				BuildingBlockKey elementId = new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, index);
				BuildingBlockData value;
				return TryGetElement_BuildingBlocks(elementId, out value) ? value : null;
			}), neighborDistanceList, onInfluenceFound);
			ObjectPool<List<short>>.Instance.Return(neighborList);
			ObjectPool<List<int>>.Instance.Return(neighborDistanceList);
		}
	}

	internal int BuildingTotalAttainment(BuildingBlockKey blockKey, sbyte resourceType, out bool hasManager, bool ignoreCanWork = false)
	{
		if (!TryGetElement_BuildingBlocks(blockKey, out var blockData))
		{
			hasManager = false;
			return 0;
		}
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingBlockItem config = BuildingBlock.Instance[blockData.TemplateId];
		Location location = new Location(blockKey.AreaId, blockKey.BlockId);
		if (!taiwuLocation.Equals(location))
		{
			Settlement settlement = DomainManager.Organization.GetSettlementByLocation(location);
			hasManager = false;
			if (settlement == null)
			{
				return 0;
			}
			bool isLifeSkill = config.RequireLifeSkillType >= 0;
			int value = DomainManager.Organization.GetMaxAttainmentValueInGradeHigh(settlement, isLifeSkill ? config.RequireLifeSkillType : config.RequireCombatSkillType, isLifeSkill);
			return 150 + value;
		}
		if (TryGetElement_ShopManagerDict(blockKey, out var managerList))
		{
			hasManager = false;
			int sum = 0;
			int leaderValue = 150;
			for (int i = 0; i < managerList.GetCount(); i++)
			{
				int charId = managerList.GetCollection()[i];
				if (GameData.Domains.Character.Character.IsCharacterIdValid(charId) && (ignoreCanWork || DomainManager.Taiwu.CanWork(charId)))
				{
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
					if (character.GetAgeGroup() == 2)
					{
						GameData.Domains.Character.Character manageChar = DomainManager.Character.GetElement_Objects(charId);
						short attainment = manageChar.GetLifeSkillAttainment(config.RequireLifeSkillType);
						if (i == 0)
						{
							leaderValue += attainment;
						}
						else
						{
							sum += 50 + attainment;
						}
						hasManager = true;
					}
				}
				else if (i == 0 && config.NeedLeader)
				{
					return 0;
				}
			}
			return leaderValue + sum / GlobalConfig.Instance.BuildingTotalAttainmentFinalDivisor;
		}
		hasManager = false;
		return 0;
	}

	internal int BuildingMaxAttainment(BuildingBlockKey blockKey, sbyte resourceType, out bool hasManager)
	{
		hasManager = false;
		if (!TryGetElement_BuildingBlocks(blockKey, out var blockData))
		{
			return 0;
		}
		BuildingBlockItem config = BuildingBlock.Instance[blockData.TemplateId];
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		Location location = new Location(blockKey.AreaId, blockKey.BlockId);
		if (!taiwuLocation.Equals(location))
		{
			Settlement settlement = DomainManager.Organization.GetSettlementByLocation(location);
			if (settlement == null)
			{
				return 0;
			}
			bool isLifeSkill = config.RequireLifeSkillType >= 0;
			int value = DomainManager.Organization.GetMaxAttainmentValueInGradeHigh(settlement, isLifeSkill ? config.RequireLifeSkillType : config.RequireCombatSkillType, isLifeSkill);
			return 150 + value;
		}
		if (!TryGetElement_ShopManagerDict(blockKey, out var managerList))
		{
			return 0;
		}
		int charId = managerList.GetCollection()[0];
		if (!GameData.Domains.Character.Character.IsCharacterIdValid(charId) || !DomainManager.Taiwu.CanWork(charId))
		{
			return 0;
		}
		GameData.Domains.Character.Character manageChar = DomainManager.Character.GetElement_Objects(charId);
		hasManager = true;
		return 150 + ((config.RequireLifeSkillType >= 0) ? manageChar.GetLifeSkillAttainment(config.RequireLifeSkillType) : manageChar.GetCombatSkillAttainment(config.RequireCombatSkillType));
	}

	internal int BuildingTotalAverageAttainment(BuildingBlockKey blockKey, sbyte resourceType, out bool hasManager, bool ignoreCanWork = false)
	{
		if (TryGetElement_BuildingBlocks(blockKey, out var blockData) && TryGetElement_ShopManagerDict(blockKey, out var managerList))
		{
			hasManager = false;
			int sum = 0;
			BuildingBlockItem config = BuildingBlock.Instance[blockData.TemplateId];
			if (config.IsCollectResourceBuilding)
			{
				for (int i = 0; i < managerList.GetCount(); i++)
				{
					int charId = managerList.GetCollection()[i];
					if (GameData.Domains.Character.Character.IsCharacterIdValid(charId) && (ignoreCanWork || DomainManager.Taiwu.CanWork(charId)))
					{
						GameData.Domains.Character.Character manageChar = DomainManager.Character.GetElement_Objects(charId);
						sum += manageChar.GetLifeSkillAttainment(config.RequireLifeSkillType);
						hasManager = true;
					}
				}
			}
			else
			{
				for (int j = 0; j < managerList.GetCount(); j++)
				{
					int charId2 = managerList.GetCollection()[j];
					if (GameData.Domains.Character.Character.IsCharacterIdValid(charId2) && (ignoreCanWork || DomainManager.Taiwu.CanWork(charId2)))
					{
						GameData.Domains.Character.Character manageChar2 = DomainManager.Character.GetElement_Objects(charId2);
						short attainment = manageChar2.GetLifeSkillAttainment(config.RequireLifeSkillType);
						sum += attainment;
						hasManager = true;
					}
				}
			}
			return sum / managerList.GetCount();
		}
		hasManager = false;
		return 0;
	}

	internal sbyte BuildLeaderFameType(BuildingBlockKey blockKey)
	{
		GameData.Domains.Character.Character leader = GetShopManagerLeader(blockKey);
		if (leader == null)
		{
			return 0;
		}
		sbyte fame = leader.GetFame();
		return FameType.GetFameType(fame);
	}

	internal int BuildingProductivityByMaxDependencies(BuildingBlockKey blockKey)
	{
		if (!TryGetElement_BuildingAreas(blockKey.GetLocation(), out var _) || !TryGetElement_BuildingBlocks(blockKey, out var buildingBlockData))
		{
			return 0;
		}
		int total = 0;
		BuildingBlockItem buildingBlockConfig = BuildingBlock.Instance.GetItem(buildingBlockData.TemplateId);
		List<(BuildingBlockData, int)> set = new List<(BuildingBlockData, int)>();
		BuildingBlockDependencies(blockKey, delegate(BuildingBlockData data, int distance, BuildingBlockKey _)
		{
			set.Add((data, distance));
		});
		foreach (short dependTemplateId in buildingBlockConfig.DependBuildings)
		{
			int max = 0;
			foreach (var dependency in set.Where(((BuildingBlockData, int) b) => b.Item1.TemplateId == dependTemplateId))
			{
				int value = BuildingProductivityBySingleDependency(new BuildingBlockKey(blockKey.AreaId, blockKey.BlockId, dependency.Item1.BlockIndex), dependency.Item2);
				if (value > max)
				{
					max = value;
				}
			}
			total += max;
		}
		return total;
	}

	internal int BuildingProductivityBySingleDependency(BuildingBlockKey buildingBlockKey, int dependencyDistance)
	{
		return (dependencyDistance > 1) ? 20 : 100;
	}

	internal ResourceInts BuildingBaseYield(BuildingBlockData resourceBlockData)
	{
		ResourceInts res = default(ResourceInts);
		BuildingBlockItem config = BuildingBlock.Instance.GetItem(resourceBlockData.TemplateId);
		for (int i = 0; i < config.CollectResourcePercent.Length; i++)
		{
			if (config.CollectResourcePercent[i] > 0)
			{
				int value = 50 + 50 * config.CollectResourcePercent[i];
				res.Add((sbyte)Math.Min(i, 5), value);
			}
		}
		return res;
	}

	internal int BuildingResourceYieldLevel(BuildingBlockKey blockKey, short templateId)
	{
		sbyte level = BuildingBlockLevel(blockKey);
		return SharedMethods.GetBuildingLevelEffect(templateId, level);
	}

	internal int BuildingRandomCorrection(int value, IRandomSource randomSource)
	{
		return value * randomSource.Next(GlobalConfig.Instance.BuildingOutputRandomFactorLowerLimit, GlobalConfig.Instance.BuildingOutputRandomFactorUpperLimit) / 100;
	}

	internal int BuildingManagerSpecificMaxCharacterId(BuildingBlockKey blockKey, Func<int, int> spec)
	{
		int maxSpecValue = 0;
		int maxSpecValueCharId = -1;
		DomainManager.Building.TryGetElement_ShopManagerDict(blockKey, out var managerList);
		for (int i = 0; i < managerList.GetCount(); i++)
		{
			int charId = managerList.GetCollection()[i];
			if (charId >= 0 && DomainManager.Taiwu.CanWork(charId))
			{
				int specValue = spec(charId);
				if (specValue >= maxSpecValue)
				{
					maxSpecValue = specValue;
					maxSpecValueCharId = charId;
				}
			}
		}
		return maxSpecValueCharId;
	}

	internal static int BuildingManagerAttraction(int charId)
	{
		if (DomainManager.Character.TryGetElement_Objects(charId, out var manager))
		{
			return manager.GetAttraction();
		}
		return 0;
	}

	internal unsafe static int BuildingManagerPersonalitiesSum(int charId)
	{
		if (DomainManager.Character.TryGetElement_Objects(charId, out var manager))
		{
			Personalities personalities = manager.GetPersonalities();
			int sum = 0;
			for (int j = 0; j < 7; j++)
			{
				sum += personalities.Items[j];
			}
			return sum;
		}
		return 0;
	}

	internal int BuildingManageHarvestSuccessRate(BuildingBlockKey blockKey, int charId)
	{
		if (TryGetElement_BuildingBlocks(blockKey, out var blockData))
		{
			short templateId = blockData.TemplateId;
			short num = templateId;
			int attainment = GetBuildingAttainment(blockData, blockKey);
			return attainment / 5;
		}
		return 0;
	}

	internal int BuildingManageHarvestSpecialSuccessRate(BuildingBlockKey blockKey, int charId)
	{
		GameData.Domains.Character.Character targetChar = (GameData.Domains.Character.Character.IsCharacterIdValid(charId) ? DomainManager.Character.GetElement_Objects(charId) : GetShopManagerLeader(blockKey));
		if (TryGetElement_BuildingBlocks(blockKey, out var blockData))
		{
			switch (blockData.TemplateId)
			{
			case 215:
			{
				int personalities = targetChar?.GetPersonalities().GetSum() ?? 0;
				return personalities / 10;
			}
			case 216:
			{
				int attraction = targetChar?.GetAttraction() ?? 0;
				return attraction / 30;
			}
			}
		}
		return -1;
	}

	internal int BuildingManageHarvestSuccessRate(BuildingBlockKey blockKey)
	{
		return BuildingManageHarvestSuccessRate(blockKey, -1);
	}

	public void GetTopLevelBlocks(short templateId, Location location, List<(BuildingBlockKey, int)> blocks, int count)
	{
		blocks.Clear();
		IEnumerable<BuildingBlockData> buildingBlocksAtLocation = GetBuildingBlocksAtLocation(location);
		foreach (BuildingBlockData block in buildingBlocksAtLocation)
		{
			if (block.TemplateId == templateId)
			{
				BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, block.BlockIndex);
				if (block.CanUse() && AllDependBuildingAvailable(blockKey, block.TemplateId, out var _))
				{
					sbyte level = BuildingBlockLevel(blockKey);
					blocks.Add((blockKey, level));
				}
			}
		}
		blocks.Sort(((BuildingBlockKey, int) a, (BuildingBlockKey, int) b) => b.Item2.CompareTo(a.Item2));
		if (blocks.Count > count)
		{
			blocks.RemoveRange(count, blocks.Count - count);
		}
	}

	public void ConsumeResource(DataContext context, sbyte resourceType, int delta)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int orig = taiwu.GetResource(resourceType);
		int consume = Math.Min(orig, delta);
		taiwu.ChangeResource(context, resourceType, -consume);
		delta -= consume;
		if (delta > 0)
		{
			SettlementTreasury treasury = DomainManager.Taiwu.GetTaiwuTreasury();
			orig = treasury.Resources.Get(resourceType);
			consume = Math.Min(orig, delta);
			treasury.Resources.Subtract(resourceType, consume);
			DomainManager.Taiwu.SetTaiwuTreasury(context, treasury);
			delta -= consume;
			if (delta > 0)
			{
			}
		}
	}

	private ResourceInts GetAllTaiwuResources()
	{
		ResourceInts res = default(ResourceInts);
		ResourceInts resource = DomainManager.Taiwu.GetAllResources(ItemSourceType.Resources).resource;
		res.Add(ref resource);
		resource = DomainManager.Taiwu.GetAllResources(ItemSourceType.Treasury).resource;
		res.Add(ref resource);
		return res;
	}

	[DomainMethod]
	public List<BuildingBlockData> GetTaiwuVillageResourceBlockEffectInfo(short templateId)
	{
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		List<(BuildingBlockKey, int)> blocks = new List<(BuildingBlockKey, int)>();
		List<BuildingBlockData> blockDataList = new List<BuildingBlockData>();
		GetTopLevelBlocks(templateId, taiwuVillageLocation, blocks, int.MaxValue);
		for (int i = 0; i < blocks.Count; i++)
		{
			blockDataList.Add(GetBuildingBlockData(blocks[i].Item1));
		}
		return blockDataList;
	}

	[DomainMethod]
	public int CalculateBuildingManageHarvestSuccessRate(BuildingBlockKey blockKey)
	{
		return BuildingManageHarvestSuccessRate(blockKey);
	}

	[DomainMethod]
	public int[] CalculateBuildingManageHarvestSuccessRates(BuildingBlockKey blockKey)
	{
		return new int[2]
		{
			BuildingManageHarvestSuccessRate(blockKey),
			BuildingManageHarvestSpecialSuccessRate(blockKey, -1)
		};
	}

	[DomainMethod]
	public int CalcExtraTaiwuGroupMaxCountByStrategyRoom()
	{
		short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		return GetBuildingBlockEffect(settlementId, EBuildingScaleEffect.TaiwuGroupMaxCount);
	}

	[DomainMethod]
	public TaiwuVillagerInfoTipsDisplayData CalcTaiwuVillagerInfoDisplayData()
	{
		short taiwuVillageSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		if (taiwuVillageSettlementId < 0)
		{
			return TaiwuVillagerInfoTipsDisplayData.CreateInvalid();
		}
		TaiwuVillagerInfoTipsDisplayData result = new TaiwuVillagerInfoTipsDisplayData();
		List<int> memberList = ObjectPool<List<int>>.Instance.Get();
		DomainManager.Organization.GetElement_CivilianSettlements(taiwuVillageSettlementId).GetMembers().GetAllMembers(memberList);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		memberList.Remove(taiwuCharId);
		Dictionary<int, VillagerWorkData> villagerWorkDict = DomainManager.Taiwu.GetVillagerWorkDict();
		foreach (int charId in memberList)
		{
			result.TotalCount++;
			if (DomainManager.Taiwu.IsVillagerAvailableForWork(charId, actuallyNotOccupiedOnly: true))
			{
				result.IdleCount++;
			}
			if (DomainManager.Character.GetElement_Objects(charId).GetPhysiologicalAge() >= 16)
			{
				result.AdultsCount++;
			}
			else
			{
				result.MinorsCount++;
			}
			VillagerRoleBase role = DomainManager.Extra.GetVillagerRole(charId);
			VillagerWorkData work;
			if (role != null && role.ArrangementTemplateId >= 0)
			{
				result.DispatchCount++;
			}
			else if (villagerWorkDict.TryGetValue(charId, out work) && work.WorkType >= 10)
			{
				result.DispatchCount++;
			}
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			ulong externRelation = character.GetExternalRelationState();
			if (ExternalRelationStateHelper.IsActive(externRelation, 8uL))
			{
				result.InStoneRoomCount++;
			}
		}
		foreach (KeyValuePair<BuildingBlockKey, CharacterList> item in _shopManagerDict)
		{
			item.Deconstruct(out var _, out var value);
			CharacterList characterList = value;
			List<int> collection = characterList.GetCollection();
			for (int i = 0; i < collection.Count; i++)
			{
				int charId2 = collection[i];
				if (charId2 >= 0)
				{
					result.ShopManageCount++;
					if (i != 0)
					{
						result.LearningCount++;
					}
				}
			}
		}
		ObjectPool<List<int>>.Instance.Return(memberList);
		return result;
	}

	[DomainMethod]
	public int CalcTaiwuVillagerEfficiencyInBuilding(BuildingBlockKey blockKey, int charId)
	{
		if (!TryGetElement_BuildingBlocks(blockKey, out var blockData))
		{
			return -1;
		}
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingBlockItem config = BuildingBlock.Instance[blockData.TemplateId];
		Location location = new Location(blockKey.AreaId, blockKey.BlockId);
		if (!taiwuLocation.Equals(location))
		{
			return -1;
		}
		if (!TryGetElement_ShopManagerDict(blockKey, out var managerList))
		{
			return -1;
		}
		List<int> collection = managerList.GetCollection();
		int myIndex = collection.FindIndex((int id) => id == charId);
		if (myIndex < 0)
		{
			return -1;
		}
		if (!GameData.Domains.Character.Character.IsCharacterIdValid(charId) || !DomainManager.Taiwu.CanWork(charId))
		{
			return -1;
		}
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		if (character.GetAgeGroup() != 2)
		{
			return -1;
		}
		GameData.Domains.Character.Character manageChar = DomainManager.Character.GetElement_Objects(charId);
		if (myIndex == 0)
		{
			return 150 + manageChar.GetLifeSkillAttainment(config.RequireLifeSkillType);
		}
		return (50 + manageChar.GetLifeSkillAttainment(config.RequireLifeSkillType)) / GlobalConfig.Instance.BuildingTotalAttainmentFinalDivisor;
	}

	[DomainMethod]
	public PuppetPageDisplayData GetPuppetPageDisplayData(DataContext context)
	{
		List<sbyte> xiangshuIds = DomainManager.Extra.GetXiangshuIdInKungfuPracticeRoom();
		List<short> puppets = new List<short> { 0 };
		foreach (sbyte xiangshuId in xiangshuIds)
		{
			List<short> list = puppets;
			if (1 == 0)
			{
			}
			short item = xiangshuId switch
			{
				0 => 1, 
				1 => 2, 
				2 => 3, 
				3 => 4, 
				4 => 5, 
				5 => 6, 
				6 => 7, 
				7 => 8, 
				8 => 9, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			if (1 == 0)
			{
			}
			list.Add(item);
		}
		foreach (PuppetItem config in (IEnumerable<PuppetItem>)Puppet.Instance)
		{
			if (config.CharacterId >= 0 && config.SectId >= 1 && DomainManager.Story.GetSectMainStoryTaskStatus(config.SectId) != 0)
			{
				puppets.Add(config.TemplateId);
			}
		}
		return new PuppetPageDisplayData
		{
			Puppets = puppets,
			Features = new List<short>(DomainManager.Extra.GetWoodenXiangshuAvatarSelectedFeatures()),
			LegendaryBookOwningState = DomainManager.LegendaryBook.GetAllLegendaryBooksOwningState(),
			IsAtSettlement = DomainManager.Taiwu.CanTransferItemToWarehouse(context)
		};
	}

	[DomainMethod]
	public int GetStoreLocation(int type)
	{
		return DomainManager.Extra.GetBuildingDefaultStoreLocation().GetMakeData(type);
	}

	[DomainMethod]
	public void SetStoreLocation(DataContext context, int type, int value)
	{
		DomainManager.Extra.GetBuildingDefaultStoreLocation().SetMakeData(type, value);
		DomainManager.Extra.SetBuildingDefaultStoreLocation(DomainManager.Extra.GetBuildingDefaultStoreLocation(), context);
	}

	[DomainMethod]
	public bool UnlockBuildingLevelSlot(DataContext context, BuildingBlockKey key, int index)
	{
		if (!DomainManager.Building.TryGetElement_BuildingBlocks(key, out var blockData))
		{
			return false;
		}
		short templateId = blockData.TemplateId;
		bool condition = ((templateId == 44 || templateId == 50) ? true : false);
		Tester.Assert(condition);
		if (blockData.SlotIsUnlocked(index))
		{
			return false;
		}
		sbyte level = blockData.CalcUnlockedLevelCount();
		blockData.UnlockLevelSlot(index);
		SetElement_BuildingBlocks(key, blockData, context);
		if (blockData.TemplateId == 50)
		{
			DestinyTypeItem config = DestinyType.Instance[index];
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			for (sbyte resourceType = 0; resourceType < config.UnlockCost.Length; resourceType++)
			{
				if (config.UnlockCost[resourceType] > 0)
				{
					taiwu.ChangeResource(context, resourceType, -config.UnlockCost[resourceType]);
				}
			}
		}
		if (blockData.TemplateId == 44)
		{
			GameData.Domains.Character.Character taiwu2 = DomainManager.Taiwu.GetTaiwu();
			int cost = ((level < blockData.ConfigData.MaxLevel) ? GlobalConfig.Instance.TaiwuVillageUpgradeAuthorityCosts[level] : 0);
			sbyte orgTemplateId = OrganizationDomain.GetLargeSectTemplateId((sbyte)index);
			if (DomainManager.Story.GetSectMainStoryTaskStatus(orgTemplateId) != 0)
			{
				cost *= (CValuePercent)GlobalConfig.Instance.VowFinishedSectStoryAuthorityPercent;
			}
			if (cost <= taiwu2.GetResource(7))
			{
				taiwu2.ChangeResource(context, 7, -cost);
			}
			DomainManager.Extra.AddTaiwuVillageVowOrgTemplateIdList(orgTemplateId, blockData.CalcUnlockedLevelCount());
			if (DomainManager.Extra.TryGetDlcEntry<FiveLoongDlcEntry>(2764950uL, out var entry))
			{
				sbyte newLevel = DomainManager.Building.BuildingBlockLevel(key);
				if (newLevel > entry.MaxTaiwuVillageLevel)
				{
					entry.MaxTaiwuVillageLevel = newLevel;
				}
			}
		}
		BuildingBlockItem configData = blockData.ConfigData;
		if (configData != null)
		{
			EBuildingBlockType type = configData.Type;
			if ((uint)type <= 1u)
			{
				condition = true;
				goto IL_01fd;
			}
		}
		condition = false;
		goto IL_01fd;
		IL_01fd:
		if (condition)
		{
			DomainManager.Taiwu.RecordLifeSummary(context, 55);
		}
		return true;
	}

	[DomainMethod]
	public void SetBuildingArrangementSetting(DataContext context, BuildingBlockKey key, BuildingOptionAutoGiveMemberPreset setting)
	{
		if (DomainManager.Building.TryGetElement_BuildingBlocks(key, out var blockData))
		{
			blockData.ArrangementSetting = setting;
			SetElement_BuildingBlocks(key, blockData, context);
		}
	}

	[DomainMethod]
	public void SetBuildingSoldItemSetting(DataContext context, BuildingBlockKey key, BuildingOptionAutoAddSoldItemPreset setting)
	{
		if (DomainManager.Building.TryGetElement_BuildingBlocks(key, out var blockData))
		{
			blockData.SoldItemSetting = setting;
			SetElement_BuildingBlocks(key, blockData, context);
		}
	}

	[DomainMethod]
	public bool UpgradeResourceBuilding(DataContext context, BuildingBlockKey key, int level)
	{
		if (!DomainManager.Building.TryGetElement_BuildingBlocks(key, out var blockData))
		{
			return false;
		}
		short templateId = blockData.TemplateId;
		BuildingBlockItem config = BuildingBlock.Instance[templateId];
		if (config.Class != EBuildingBlockClass.BornResource)
		{
			return false;
		}
		sbyte maxLevel = config.MaxLevel;
		sbyte currentLevel = blockData.CalcUnlockedLevelCount();
		int targetLevel = currentLevel + level;
		if (targetLevel > maxLevel)
		{
			return false;
		}
		short itemTemplateId = config.BuildingCoreItem;
		MiscItem itemConfig = Config.Misc.Instance[itemTemplateId];
		if (DomainManager.Taiwu.GetTaiwuItemCountFromSources(12, itemTemplateId, ResourceBuildingItemSources) < level)
		{
			return false;
		}
		UpgradeToLevelUnchecked(context, key, blockData, targetLevel);
		bool removeResult = DomainManager.Taiwu.RemoveTaiwuItemFromSources(context, 12, itemTemplateId, level, ResourceBuildingItemSources, deleteItem: true);
		Tester.Assert(removeResult);
		for (int i = 0; i < targetLevel - currentLevel; i++)
		{
			DomainManager.Taiwu.AddLegacyPoint(context, 27);
		}
		if (targetLevel >= maxLevel)
		{
			EBuildingBlockType type = config.Type;
			if (1 == 0)
			{
			}
			short num = type switch
			{
				EBuildingBlockType.NormalResource => 87, 
				EBuildingBlockType.SpecialResource => 88, 
				_ => -1, 
			};
			if (1 == 0)
			{
			}
			short statId = num;
			if (statId > 0)
			{
				AchievementManager.RequestSetStat(context, statId, 1);
			}
		}
		BuildingBlockItem configData = blockData.ConfigData;
		bool flag;
		if (configData != null)
		{
			EBuildingBlockType type2 = configData.Type;
			if ((uint)type2 <= 1u)
			{
				flag = true;
				goto IL_0186;
			}
		}
		flag = false;
		goto IL_0186;
		IL_0186:
		if (flag)
		{
			DomainManager.Taiwu.RecordLifeSummary(context, 55, level);
		}
		UpdateTaiwuVillageBuildingEffect();
		return true;
	}

	[DomainMethod]
	public bool UpgradeSlotBuilding(DataContext context, BuildingBlockKey key, int levelSlotIndex)
	{
		BuildingBlockData blockData = DomainManager.Building.GetBuildingBlockData(key);
		short templateId = blockData.TemplateId;
		if (1 == 0)
		{
		}
		List<ResourceInfo> list = templateId switch
		{
			46 => GlobalConfig.Instance.ResidentUnlockCost, 
			47 => GlobalConfig.Instance.ComfortableHouseUnlockCost, 
			48 => GlobalConfig.Instance.WarehouseUnlockCost, 
			_ => null, 
		};
		if (1 == 0)
		{
		}
		List<ResourceInfo> config = list;
		if (config == null)
		{
			return false;
		}
		if (!config.CheckIndex(levelSlotIndex - 1))
		{
			return false;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		ResourceInfo cost = config[levelSlotIndex - 1];
		ResourceInts taiwuResources = DomainManager.Taiwu.GetAllResources(ItemSourceType.Resources).resource;
		ResourceInts treasuryResources = DomainManager.Taiwu.GetAllResources(ItemSourceType.Treasury).resource;
		int haveResource = taiwuResources.Get(cost.ResourceType) + treasuryResources.Get(cost.ResourceType);
		int needResource = cost.ResourceCount;
		if (haveResource < needResource)
		{
			return false;
		}
		DomainManager.Building.ConsumeResource(context, cost.ResourceType, needResource);
		blockData.UnlockLevelSlot(levelSlotIndex);
		SetElement_BuildingBlocks(key, blockData, context);
		if (templateId == 48)
		{
			bool maxLevel = true;
			for (int i = 0; i < config.Count + 1; i++)
			{
				if (!blockData.SlotIsUnlocked(i))
				{
					maxLevel = false;
					break;
				}
			}
			if (maxLevel)
			{
				AchievementManager.RequestSetStat(context, 6, 1);
			}
		}
		return true;
	}

	public void UpgradeToLevelUnchecked(DataContext context, BuildingBlockKey key, BuildingBlockData blockData, int level)
	{
		for (int i = 0; i < level; i++)
		{
			blockData.UnlockLevelSlot(i);
		}
		SetElement_BuildingBlocks(key, blockData, context);
	}

	public Dictionary<short, List<BuildingBlockKey>> GetBuildingRecruitPair()
	{
		Dictionary<short, List<BuildingBlockKey>> result = new Dictionary<short, List<BuildingBlockKey>>();
		foreach (KeyValuePair<BuildingBlockKey, BuildingEarningsData> item in _collectBuildingEarningsData)
		{
			if (item.Value.RecruitLevelList.Count != 0)
			{
				BuildingBlockData buildingBlockData = _buildingBlocks[item.Key];
				if (!result.ContainsKey(buildingBlockData.ConfigData.TemplateId))
				{
					result[buildingBlockData.ConfigData.TemplateId] = new List<BuildingBlockKey>();
				}
				result[buildingBlockData.ConfigData.TemplateId].Add(item.Key);
			}
		}
		return result;
	}

	[DomainMethod]
	public BuildingFunctionData GetBuildingFunctionData(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		return new BuildingFunctionData
		{
			AtTaiwuVillage = (DomainManager.Taiwu.GetTaiwuVillageLocation() == taiwu.GetLocation()),
			JiaoPoolOpen = DomainManager.Extra.GetIsJiaoPoolOpen(),
			CanTransfer = DomainManager.Taiwu.CanTransferItemToWarehouse(context),
			XiangshuIdInKungfuRoom = GetXiangshuIdInKungfuRoom(),
			CanPracticeSkills = taiwu.GetLearnedCombatSkills(),
			OrganizationTemplateIdOfTaiwuLocation = DomainManager.Organization.GetOrganizationTemplateIdOfTaiwuLocation(),
			JingangFunctionOpen = DomainManager.Organization.GetSectFunctionStatus(11, SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked),
			FulongFunctionOpen = DomainManager.Organization.GetSectFunctionStatus(14, SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked),
			JingangMonkSoul = DomainManager.Story.JingangMonkSoulBtnShow()
		};
	}

	[DomainMethod]
	public TaiwuVillageBlockEffectInfo GetTaiwuVillageBlockEffectInfo(DataContext context, BuildingBlockKey blockKey)
	{
		TaiwuVillageBlockEffectInfo info = new TaiwuVillageBlockEffectInfo();
		BuildingBlockData blockData = GetBuildingBlockData(blockKey);
		info.FormulaContextBridge = GetBuildingFormulaContextBridge(blockKey);
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		List<(BuildingBlockKey, int)> blocks = new List<(BuildingBlockKey, int)>();
		GetTopLevelBlocks(blockData.TemplateId, taiwuVillageLocation, blocks, int.MaxValue);
		for (int i = 0; i < blocks.Count; i++)
		{
			BuildingBlockData block = GetBuildingBlockData(blocks[i].Item1);
			info.BlockDataList.Add(block);
			info.BlockKeyList.Add(blocks[i].Item1);
			info.LevelList.Add(blocks[i].Item2);
			if (block.BlockIndex == blockKey.BuildingBlockIndex)
			{
				info.BlockRanking = i;
			}
		}
		return info;
	}

	[DomainMethod]
	public BuildingShopData GetTaiwuVillageShopData(DataContext context, BuildingBlockKey blockKey, EBuildingScaleEffect effectType = EBuildingScaleEffect.ShopProgressBonus)
	{
		BuildingShopData shopData = new BuildingShopData();
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		shopData.ResourceBlockEffect = GetBuildingBlockEffect(taiwuVillageLocation, effectType);
		BuildingBlockData blockData = GetBuildingBlockData(blockKey);
		shopData.Attainment = GetBuildingAttainment(blockData, blockKey);
		return shopData;
	}

	[DomainMethod]
	public BuildingManageDisplayData GetBuildingManageDisplayData(DataContext context, BuildingBlockKey blockKey)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		BuildingBlockData blockData = DomainManager.Building.GetBuildingBlockData(blockKey);
		List<BuildingBlockData> blockList = GetTaiwuVillageResourceBlockEffectInfo(blockData.TemplateId);
		Location location = blockKey.GetLocation();
		int resourceBlockRanking = int.MaxValue;
		for (int i = 0; i < blockList.Count; i++)
		{
			if (blockList[i].BlockIndex == blockData.BlockIndex)
			{
				resourceBlockRanking = i;
				break;
			}
		}
		List<Chicken> chickens = GetSettlementChickenDataList(location);
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingManageDisplayData data = new BuildingManageDisplayData
		{
			BlockData = blockData,
			AreaData = GetBuildingAreaData(location),
			BlockList = GetBuildingBlockList(location),
			LearnedCombatSkillItems = taiwuChar.GetLearnedCombatSkills(),
			LearnedLifeSkillItems = taiwuChar.GetLearnedLifeSkills(),
			BuildingFormulaContextBridge = GetBuildingFormulaContextBridge(blockKey),
			CanTransferItemToWarehouse = DomainManager.Taiwu.CanTransferItemToWarehouse(DomainManager.TaiwuEvent.MainThreadDataContext),
			ResourceBlockRanking = resourceBlockRanking,
			Chickens = chickens,
			ChickenNickNames = GetChickenNicknameList(chickens.Select((Chicken x) => x.Id).ToList()),
			TaiwuVillageResourceBlockEffect = GetTaiwuVillageResourceBlockEffect(context, EBuildingScaleEffect.ShopProgressBonus),
			CanUseBuildingCore = DomainManager.Taiwu.GetCanOperateItemDisplayDataInVillage(context, 1205),
			CannotUseInventoryBuildingCore = DomainManager.Taiwu.GetCannotOperateItemDisplayDataInInventory(context, 1205),
			BuildingSpaceCurr = DomainManager.Taiwu.GetBuildingSpaceCurr(),
			BuildingSpaceLimit = DomainManager.Taiwu.GetBuildingSpaceLimit(),
			IsTaiwuVillageBuilding = (location == taiwuVillageLocation)
		};
		BuildingBlockItem config = BuildingBlock.Instance[blockData.TemplateId];
		if (config.TemplateId == 46 && TryGetElement_Residences(blockKey, out var residentList))
		{
			data.Residences = new List<CharacterDisplayData>();
			foreach (int charId in residentList.GetCollection())
			{
				if (charId >= 0)
				{
					data.Residences.Add(DomainManager.Character.GetCharacterDisplayData(charId));
				}
			}
			CharacterSet lockedSet = GetLockedResidenceCharacters(blockKey);
			if (lockedSet.GetCount() > 0)
			{
				data.LockedResidences = lockedSet.GetCollection().ToList();
			}
		}
		if (config.TemplateId == 46)
		{
			data.AutoCheckIn = DomainManager.Extra.GetAutoCheckInResidenceList().Contains(blockKey.BuildingBlockIndex);
		}
		if (config.TemplateId == 47 && TryGetElement_ComfortableHouses(blockKey, out var comfortableHouseList))
		{
			data.ComfortableHouses = new List<CharacterDisplayData>();
			foreach (int charId2 in comfortableHouseList.GetCollection())
			{
				if (charId2 >= 0)
				{
					data.ComfortableHouses.Add(DomainManager.Character.GetCharacterDisplayData(charId2));
				}
			}
			CharacterSet lockedSet2 = GetLockedComfortableHouseCharacters(blockKey);
			if (lockedSet2.GetCount() > 0)
			{
				data.LockedComfortableHouses = lockedSet2.GetCollection().ToList();
			}
		}
		if (config.TemplateId == 47)
		{
			data.AutoCheckIn = DomainManager.Extra.GetAutoCheckInComfortableList().Contains(blockKey.BuildingBlockIndex);
		}
		if (TryGetElement_ComfortableHousesAutoCheckInType(blockKey, out var autoCheckInType))
		{
			data.AutoCheckInType = autoCheckInType;
		}
		if (config.IsShop)
		{
			BuildingEarningsData buildingEarningsData = GetBuildingEarningData(blockKey);
			List<ItemKey> list = buildingEarningsData?.FixBookInfoList;
			ItemKey fixingBookItemKey = ((list != null && list.Count > 0) ? buildingEarningsData.FixBookInfoList.First() : ItemKey.Invalid);
			CharacterList list2;
			List<int> managerList = (_shopManagerDict.TryGetValue(blockKey, out list2) ? list2.GetCollection() : null);
			if (managerList == null)
			{
				managerList = new List<int>();
				for (int i2 = 0; i2 < 7; i2++)
				{
					managerList.Add(-1);
				}
			}
			data.BuildingAttainment = GetBuildingAttainment(blockData, blockKey);
			data.AvailableWorker = DomainManager.Taiwu.GetAllVillagersAvailableForWork();
			data.AvailableChildren = DomainManager.Taiwu.GetAllChildAvailableForWork();
			data.TipsData = GetShopManagementYieldTipsData(context, blockKey);
			data.FixingBookItemData = (fixingBookItemKey.IsValid() ? DomainManager.Item.GetItemDisplayData(fixingBookItemKey) : null);
			data.SkillBookPageDisplayData = (fixingBookItemKey.IsValid() ? DomainManager.Item.GetSkillBookPagesInfo(fixingBookItemKey) : null);
			data.SuccessRates = CalculateBuildingManageHarvestSuccessRates(blockKey);
			data.EarningsData = DomainManager.Building.GetBuildingEarningData(blockKey);
			data.ShopManagerUpgradeQualificationDict = _shopManagerUpgradeQualificationDict;
			data.ShopManagerList = managerList;
			data.VillagerRoleDataList = new List<VillagerRoleCharacterDisplayData>();
			data.CharacterDataList = new List<CharacterDisplayData>();
			data.VillagerEfficiencyList = new List<int>();
			data.TeachBookDataList = new List<ShopBuildingTeachBookData>();
			for (int index = 0; index < managerList.Count; index++)
			{
				int charId3 = managerList[index];
				bool isValid = charId3 >= 0;
				data.VillagerRoleDataList.Add(isValid ? DomainManager.Taiwu.GetVillagerRoleCharacterDisplayData(charId3) : null);
				data.CharacterDataList.Add(isValid ? DomainManager.Character.GetCharacterDisplayData(charId3) : null);
				data.VillagerEfficiencyList.Add(isValid ? CalcTaiwuVillagerEfficiencyInBuilding(blockKey, charId3) : 0);
				data.TeachBookDataList.Add((isValid && index > 0) ? GetShopBuildingTeachBookData(blockKey, charId3) : null);
			}
			data.ShopEventRecordData = GetShopEventRecordData(context, blockKey);
			if (blockData.TemplateId == 105)
			{
				if (data.CanTransferItemToWarehouse)
				{
					data.InventoryCanSoldItemList = GetTaiwuCanFixBookItemDataList(ItemSourceType.Inventory);
				}
				data.WarehouseCanSoldItemList = GetTaiwuCanFixBookItemDataList(ItemSourceType.Warehouse);
				data.TreasuryCanSoldItemList = GetTaiwuCanFixBookItemDataList(ItemSourceType.Treasury);
			}
			else
			{
				if (data.CanTransferItemToWarehouse)
				{
					data.InventoryCanSoldItemList = DomainManager.Character.GetAllInventoryItemsExcludeValueZero(taiwuCharId);
					FilterItemByList(config, data.InventoryCanSoldItemList);
				}
				data.WarehouseCanSoldItemList = DomainManager.Taiwu.GetAllWarehouseItemsExcludeValueZero(context);
				FilterItemByList(config, data.WarehouseCanSoldItemList);
				List<ItemDisplayData> treasuryCanSoldItemList = DomainManager.Taiwu.GetAllTreasuryItems(context);
				treasuryCanSoldItemList.RemoveAll((ItemDisplayData d) => d.Value <= 0);
				FilterItemByList(config, treasuryCanSoldItemList);
				data.TreasuryCanSoldItemList = treasuryCanSoldItemList;
				List<ItemDisplayData> stockCanSoldItemList = DomainManager.Taiwu.GetAllItems(ItemSourceType.Stock).list;
				FilterItemByList(config, stockCanSoldItemList);
				data.StockCanSoldItemList = stockCanSoldItemList;
			}
		}
		data.UnlockedWorkingVillagerList = DomainManager.Extra.GetUnlockedWorkingVillagers();
		List<short> succesEvent = config.SuccesEvent;
		if (succesEvent != null && succesEvent.Count > 0)
		{
			ShopEventItem shopEvent = Config.ShopEvent.Instance[config.SuccesEvent[0]];
			List<sbyte> resourceList = shopEvent.ResourceList;
			if (resourceList != null && resourceList.Count > 0)
			{
				BuildingManageDisplayData buildingManageDisplayData = data;
				if (buildingManageDisplayData.ResourceOutputValue == null)
				{
					buildingManageDisplayData.ResourceOutputValue = new Dictionary<sbyte, int>();
				}
				foreach (sbyte resourceType in shopEvent.ResourceList)
				{
					data.ResourceOutputValue[resourceType] = CalcResourceOutputCount(blockKey, resourceType);
				}
			}
		}
		data.AutoSoldItem = GetBuildingIsAutoSold(blockKey.BuildingBlockIndex);
		if (config.TemplateId == 47)
		{
			data.Feast = DomainManager.Extra.GetFeast(blockKey);
		}
		if (config.TemplateId == 52)
		{
			data.XiangshuIdInKungfuRoom = GetXiangshuIdInKungfuRoom();
			data.CurrLocationOrganizationTemplateId = DomainManager.Organization.GetOrganizationTemplateIdOfTaiwuLocation();
			data.CanPracticeSkills = GetCurrOrganizationCanPracticeSkills(data.CurrLocationOrganizationTemplateId, data.IsTaiwuVillageBuilding);
		}
		return data;
	}

	[DomainMethod]
	public TaiwuVillageBuildingDataForVillagerRole GetTaiwuVillageBuildingDataForVillagerRole(DataContext context)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		return new TaiwuVillageBuildingDataForVillagerRole
		{
			LearnedCombatSkillItems = taiwuChar.GetLearnedCombatSkills(),
			LearnedLifeSkillItems = taiwuChar.GetLearnedLifeSkills(),
			CanUseBuildingCore = DomainManager.Taiwu.GetCanOperateItemDisplayDataInVillage(context, 1205),
			CannotUseInventoryBuildingCore = DomainManager.Taiwu.GetCannotOperateItemDisplayDataInInventory(context, 1205),
			BuildingSpaceCurr = DomainManager.Taiwu.GetBuildingSpaceCurr(),
			BuildingSpaceLimit = DomainManager.Taiwu.GetBuildingSpaceLimit(),
			AreaData = GetBuildingAreaData(location),
			BlockList = GetBuildingBlockList(location)
		};
	}

	private List<short> GetCurrOrganizationCanPracticeSkills(short organizationTemplateId, bool isTaiwuVillageBuilding)
	{
		List<short> learnedCombatSkillItems = DomainManager.Taiwu.GetTaiwu().GetLearnedCombatSkills();
		List<short> canPracticeSkills = new List<short>();
		if (isTaiwuVillageBuilding)
		{
			canPracticeSkills.AddRange(learnedCombatSkillItems);
		}
		else
		{
			for (int i = learnedCombatSkillItems.Count - 1; i >= 0; i--)
			{
				CombatSkillItem config = Config.CombatSkill.Instance[learnedCombatSkillItems[i]];
				if (config.SectId == organizationTemplateId)
				{
					canPracticeSkills.Add(config.TemplateId);
				}
			}
		}
		return canPracticeSkills;
	}

	private void FilterItemByList(BuildingBlockItem configData, List<ItemDisplayData> itemDataList)
	{
		itemDataList.RemoveAll((ItemDisplayData d) => !SharedMethods.IsBuildingCanSoldItem(configData, d.RealKey));
	}

	[DomainMethod]
	public CraftManDisplayData GetCraftManDisplayDataForBuilding(DataContext context, BuildingBlockKey blockKey)
	{
		CharacterList list;
		List<int> managerList = (_shopManagerDict.TryGetValue(blockKey, out list) ? list.GetCollection() : null);
		if (managerList == null)
		{
			managerList = new List<int>();
			for (int i = 0; i < 7; i++)
			{
				managerList.Add(-1);
			}
		}
		ArtisanOrder artisanOrder = DomainManager.Extra.GetBuildingArtisanOrderAfterUpdate(context, blockKey);
		CraftManDisplayData data = new CraftManDisplayData
		{
			ArtisanOrder = artisanOrder,
			ProductionPool = DomainManager.Extra.GetArtisanOrderProductionPool(artisanOrder),
			CanProduceItemSubType = DomainManager.Extra.GetArtisanOrderCanProduceItemSubType(artisanOrder),
			InventoryItemList = DomainManager.Taiwu.GetAllItems(ItemSourceType.Inventory, includeResources: true).list,
			WarehouseItemList = DomainManager.Taiwu.GetAllItems(ItemSourceType.Warehouse).list,
			TreasuryItemList = DomainManager.Taiwu.GetAllItems(ItemSourceType.Treasury).list,
			CanTransferItemToWarehouse = DomainManager.Taiwu.CanTransferItemToWarehouse(context),
			AvailableWorker = DomainManager.Taiwu.GetAllVillagersAvailableForWork(),
			AvailableChildren = DomainManager.Taiwu.GetAllChildAvailableForWork(),
			ShopManagerUpgradeQualificationDict = _shopManagerUpgradeQualificationDict,
			ShopManagerList = managerList,
			UnlockedWorkingVillagerList = DomainManager.Extra.GetUnlockedWorkingVillagers(),
			BlockList = GetBuildingBlockList(blockKey.GetLocation()),
			VillagerRoleDataList = new List<VillagerRoleCharacterDisplayData>(),
			CharacterDataList = new List<CharacterDisplayData>(),
			VillagerEfficiencyList = new List<int>(),
			TeachBookDataList = new List<ShopBuildingTeachBookData>()
		};
		for (int index = 0; index < managerList.Count; index++)
		{
			int charId = managerList[index];
			bool isValid = charId >= 0;
			data.VillagerRoleDataList.Add(isValid ? DomainManager.Taiwu.GetVillagerRoleCharacterDisplayData(charId) : null);
			data.CharacterDataList.Add(isValid ? DomainManager.Character.GetCharacterDisplayData(charId) : null);
			data.VillagerEfficiencyList.Add(isValid ? CalcTaiwuVillagerEfficiencyInBuilding(blockKey, charId) : 0);
			data.TeachBookDataList.Add((isValid && index > 0) ? GetShopBuildingTeachBookData(blockKey, charId) : null);
		}
		return data;
	}

	[DomainMethod]
	public CraftManDisplayData GetCraftManDisplayDataForCharacter(DataContext context, int artisanId)
	{
		ArtisanOrder artisanOrder = DomainManager.Extra.GetNpcArtisanOrder(artisanId);
		CraftManDisplayData data = new CraftManDisplayData
		{
			ArtisanOrder = artisanOrder,
			ProductionPool = DomainManager.Extra.GetArtisanOrderProductionPool(artisanOrder),
			CanProduceItemSubType = DomainManager.Extra.GetArtisanOrderCanProduceItemSubType(artisanOrder),
			InventoryItemList = DomainManager.Taiwu.GetAllItems(ItemSourceType.Inventory, includeResources: true).list,
			WarehouseItemList = DomainManager.Taiwu.GetAllItems(ItemSourceType.Warehouse).list,
			TreasuryItemList = DomainManager.Taiwu.GetAllItems(ItemSourceType.Treasury).list,
			CanTransferItemToWarehouse = DomainManager.Taiwu.CanTransferItemToWarehouse(context),
			ArtisanCostMoneyBehaviorEffect = DomainManager.Character.GetArtisanCostMoneyBehaviorEffect(context, artisanId)
		};
		data.ArtisanCharData = DomainManager.Character.GetCharacterDisplayData(artisanId);
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(artisanId);
		data.ArtisanLifeSkillAttainments = character.GetLifeSkillAttainments();
		data.ArtisanLifeSkillQualifications = character.GetLifeSkillQualifications();
		for (sbyte i = 0; i < 16; i++)
		{
			int delta = DomainManager.Extra.GetArtisanOrderDelta(artisanId, i);
			data.ArtisanOrderProgressDeltas.Set(i, delta);
		}
		if (artisanOrder != null && artisanOrder.SubscriberId >= 0)
		{
			data.SubscriberCharData = DomainManager.Character.GetCharacterDisplayData(artisanOrder.SubscriberId);
		}
		return data;
	}

	public void CreateBuildingArea(DataContext context, short mapAreaId, short mapBlockId, short mapBlockTemplateId)
	{
		IRandomSource random = context.Random;
		MapBlockItem mapBlockData = MapBlock.Instance[mapBlockTemplateId];
		sbyte areaWidth = mapBlockData.BuildingAreaWidth;
		int blockCount = areaWidth * areaWidth;
		sbyte maxLevel = mapBlockData.CenterBuildingMaxLevel;
		MapBlockItem mapBlockItem = MapBlock.Instance[mapBlockTemplateId];
		sbyte landFormType = 0;
		if (IsLandFormTypeRandom(mapBlockItem))
		{
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(mapAreaId);
			MapStateItem mapStateItem = MapState.Instance[stateTemplateId];
			landFormType = (sbyte)mapStateItem.BornMapType.GetRandom(context.Random);
		}
		else
		{
			landFormType = ((mapBlockTemplateId == 0) ? DomainManager.World.GetTaiwuVillageLandFormType() : mapBlockData.LandFormType);
		}
		LandFormTypeItem landFormData = LandFormType.Instance[landFormType];
		Location location = new Location(mapAreaId, mapBlockId);
		BuildingAreaData areaData = new BuildingAreaData(areaWidth, landFormType);
		List<short> allBlockList = ObjectPool<List<short>>.Instance.Get();
		List<short> canUseBlockList = ObjectPool<List<short>>.Instance.Get();
		allBlockList.Clear();
		canUseBlockList.Clear();
		for (short i = 0; i < blockCount; i++)
		{
			allBlockList.Add(i);
			if (i >= areaWidth && i < blockCount - areaWidth && i % areaWidth != 0 && i % areaWidth != areaWidth - 1)
			{
				canUseBlockList.Add(i);
			}
		}
		short centerIndex = areaData.GetCenterBlockIndex();
		sbyte buildingWidth = BuildingBlock.Instance[mapBlockData.CenterBuilding].Width;
		sbyte level = (sbyte)Math.Max(random.Next(maxLevel / 2, maxLevel + 1), 1);
		short templateId = mapBlockData.CenterBuilding;
		AddBuilding(context, mapAreaId, mapBlockId, centerIndex, templateId, level, areaWidth);
		for (int x = 0; x < buildingWidth; x++)
		{
			for (int y = 0; y < buildingWidth; y++)
			{
				short index = (short)(centerIndex + x * areaWidth + y);
				allBlockList.Remove(index);
				canUseBlockList.Remove(index);
			}
		}
		List<short> centerNeighborList = ObjectPool<List<short>>.Instance.Get();
		areaData.GetNeighborBlocks(centerIndex, buildingWidth, centerNeighborList);
		List<short> centerNeighborsWidth2 = ObjectPool<List<short>>.Instance.Get();
		GetAvailableRootBlocks(centerNeighborList, centerNeighborsWidth2, mapAreaId, mapBlockId, areaWidth, 2);
		List<short> indirectNeighbors = ObjectPool<List<short>>.Instance.Get();
		List<short> indirectNeighborsWidth2 = ObjectPool<List<short>>.Instance.Get();
		List<short> temp = ObjectPool<List<short>>.Instance.Get();
		if (!string.IsNullOrEmpty(mapBlockData.FixedBuildingImage))
		{
			int[] blockSubTypeList = CustomBuildingBlockConfig.Data[mapBlockData.FixedBuildingImage];
			for (short blockId = 0; blockId < blockSubTypeList.Length; blockId++)
			{
				if (blockSubTypeList[blockId] != -1)
				{
					BuildingBlockKey tempKey = new BuildingBlockKey(mapAreaId, mapBlockId, blockId);
					BuildingBlockItem buildingBlock = BuildingBlock.Instance[blockSubTypeList[blockId]];
					if (!_buildingBlocks.ContainsKey(tempKey))
					{
						if (buildingBlock.Width == 1)
						{
							AddElement_BuildingBlocks(tempKey, new BuildingBlockData(blockId, buildingBlock.TemplateId, (sbyte)((buildingBlock.MaxLevel <= 1) ? 1 : random.Next(1, buildingBlock.MaxLevel)), -1), context);
							allBlockList.Remove(blockId);
							canUseBlockList.Remove(blockId);
						}
						else if (buildingBlock.Width == 2)
						{
							AddBuilding(context, mapAreaId, mapBlockId, blockId, buildingBlock.TemplateId, (sbyte)((buildingBlock.MaxLevel <= 1) ? 1 : random.Next(1, buildingBlock.MaxLevel)), areaWidth);
							allBlockList.Remove(blockId);
							allBlockList.Remove((short)(blockId + 1));
							allBlockList.Remove((short)(blockId + areaWidth));
							allBlockList.Remove((short)(blockId + areaWidth + 1));
							canUseBlockList.Remove(blockId);
							canUseBlockList.Remove((short)(blockId + 1));
							canUseBlockList.Remove((short)(blockId + areaWidth));
							canUseBlockList.Remove((short)(blockId + areaWidth + 1));
						}
					}
				}
			}
		}
		List<short> presetList = ObjectPool<List<short>>.Instance.Get();
		presetList.Clear();
		presetList.AddRange(mapBlockData.PresetBuildingList);
		presetList.Sort(ComparePresetBuildings);
		for (int j = 0; j < presetList.Count; j++)
		{
			short buildingId = presetList[j];
			if (buildingId == 287 && mapAreaId == 138)
			{
				continue;
			}
			BuildingBlockItem currBuildingCfg = BuildingBlock.Instance[buildingId];
			buildingWidth = currBuildingCfg.Width;
			short blockIndex;
			if (BuildingBlockData.IsResource(currBuildingCfg.Type))
			{
				blockIndex = canUseBlockList[random.Next(0, canUseBlockList.Count)];
			}
			else
			{
				if (1 == 0)
				{
				}
				short num = ((buildingWidth != 2) ? GetRandomAvailableBuildingBlock(context, canUseBlockList, centerNeighborList, indirectNeighbors, mapAreaId, mapBlockId, areaWidth, buildingWidth) : GetRandomAvailableBuildingBlock(context, canUseBlockList, centerNeighborsWidth2, indirectNeighborsWidth2, mapAreaId, mapBlockId, areaWidth, buildingWidth));
				if (1 == 0)
				{
				}
				blockIndex = num;
				if (blockIndex < 0)
				{
					Logger.AppendWarning($"Failed to create building {currBuildingCfg.Name} at {BuildingBlock.Instance[templateId].Name}({templateId}): no available space.");
					continue;
				}
			}
			temp.Clear();
			areaData.GetNeighborBlocks(blockIndex, buildingWidth, temp);
			indirectNeighbors.AddRange(temp);
			GetAvailableRootBlocks(temp, indirectNeighborsWidth2, mapAreaId, mapBlockId, areaWidth, 2, clearFirst: false);
			level = (sbyte)Math.Clamp(random.Next(maxLevel / 2, maxLevel + 1), 1, currBuildingCfg.MaxLevel);
			AddBuilding(context, mapAreaId, mapBlockId, blockIndex, buildingId, level, areaWidth);
			for (int k = 0; k < buildingWidth; k++)
			{
				for (int l = 0; l < buildingWidth; l++)
				{
					short index2 = (short)(blockIndex + k * areaWidth + l);
					if (centerNeighborList.Contains(index2))
					{
						centerNeighborList.Remove(index2);
					}
					allBlockList.Remove(index2);
					canUseBlockList.Remove(index2);
				}
			}
		}
		ObjectPool<List<short>>.Instance.Return(presetList);
		if (location.AreaId == 138)
		{
			short merchantBuildingId = (short)(276 + context.Random.Next(7));
			buildingWidth = BuildingBlock.Instance[merchantBuildingId].Width;
			if (1 == 0)
			{
			}
			short num = ((buildingWidth != 2) ? GetRandomAvailableBuildingBlock(context, canUseBlockList, centerNeighborList, indirectNeighbors, mapAreaId, mapBlockId, areaWidth, buildingWidth) : GetRandomAvailableBuildingBlock(context, canUseBlockList, centerNeighborsWidth2, indirectNeighborsWidth2, mapAreaId, mapBlockId, areaWidth, buildingWidth));
			if (1 == 0)
			{
			}
			short blockIndex2 = num;
			if (blockIndex2 < 0)
			{
				Logger.AppendWarning($"Failed to create building {BuildingBlock.Instance[merchantBuildingId].Name} at {BuildingBlock.Instance[templateId].Name}({templateId}): no available space.");
			}
			temp.Clear();
			areaData.GetNeighborBlocks(blockIndex2, buildingWidth, temp);
			indirectNeighbors.AddRange(temp);
			GetAvailableRootBlocks(temp, indirectNeighborsWidth2, mapAreaId, mapBlockId, areaWidth, 2, clearFirst: false);
			level = (sbyte)Math.Max(random.Next(maxLevel / 2, maxLevel + 1), 1);
			AddBuilding(context, mapAreaId, mapBlockId, blockIndex2, merchantBuildingId, level, areaWidth);
			for (int m = 0; m < buildingWidth; m++)
			{
				for (int n = 0; n < buildingWidth; n++)
				{
					short index3 = (short)(blockIndex2 + m * areaWidth + n);
					if (centerNeighborList.Contains(index3))
					{
						centerNeighborList.Remove(index3);
					}
					allBlockList.Remove(index3);
					canUseBlockList.Remove(index3);
				}
			}
		}
		List<short> randomBuildingList = ObjectPool<List<short>>.Instance.Get();
		randomBuildingList.Clear();
		randomBuildingList.AddRange(mapBlockData.RandomBuildingList);
		randomBuildingList.Sort(ComparePresetBuildings);
		for (short i2 = 0; i2 < randomBuildingList.Count; i2++)
		{
			int isBuild = random.Next(0, 2);
			if (isBuild != 1)
			{
				continue;
			}
			short buildingId2 = randomBuildingList[i2];
			buildingWidth = BuildingBlock.Instance[buildingId2].Width;
			short blockIndex3;
			if (BuildingBlockData.IsResource(BuildingBlock.Instance[buildingId2].Type))
			{
				blockIndex3 = canUseBlockList[random.Next(0, canUseBlockList.Count)];
			}
			else
			{
				if (1 == 0)
				{
				}
				short num = ((buildingWidth != 2) ? GetRandomAvailableBuildingBlock(context, canUseBlockList, centerNeighborList, indirectNeighbors, mapAreaId, mapBlockId, areaWidth, buildingWidth) : GetRandomAvailableBuildingBlock(context, canUseBlockList, centerNeighborsWidth2, indirectNeighborsWidth2, mapAreaId, mapBlockId, areaWidth, buildingWidth));
				if (1 == 0)
				{
				}
				blockIndex3 = num;
				if (blockIndex3 < 0)
				{
					Logger.AppendWarning($"Failed to create building {BuildingBlock.Instance[buildingId2].Name} at {BuildingBlock.Instance[templateId].Name}({templateId}): no available space.");
					continue;
				}
			}
			temp.Clear();
			areaData.GetNeighborBlocks(blockIndex3, buildingWidth, temp);
			indirectNeighbors.AddRange(temp);
			GetAvailableRootBlocks(temp, indirectNeighborsWidth2, mapAreaId, mapBlockId, areaWidth, 2, clearFirst: false);
			level = (sbyte)Math.Max(random.Next(maxLevel / 2, maxLevel + 1), 1);
			BuildingBlockKey tempKey2 = new BuildingBlockKey(mapAreaId, mapBlockId, blockIndex3);
			if (_buildingBlocks.ContainsKey(tempKey2))
			{
				BuildingBlockData buildingBlockData = GetBuildingBlockData(tempKey2);
				AddBuilding(context, mapAreaId, mapBlockId, blockIndex3, buildingId2, level, areaWidth);
			}
			AddBuilding(context, mapAreaId, mapBlockId, blockIndex3, buildingId2, level, areaWidth);
			for (int num2 = 0; num2 < buildingWidth; num2++)
			{
				for (int num3 = 0; num3 < buildingWidth; num3++)
				{
					short index4 = (short)(blockIndex3 + num2 * areaWidth + num3);
					if (centerNeighborList.Contains(index4))
					{
						centerNeighborList.Remove(index4);
					}
					allBlockList.Remove(index4);
					canUseBlockList.Remove(index4);
				}
			}
		}
		ObjectPool<List<short>>.Instance.Return(randomBuildingList);
		if (mapBlockTemplateId == 0)
		{
			sbyte centerWidth = BuildingBlock.Instance[mapBlockData.CenterBuilding].Width;
			for (int num4 = -1; num4 < centerWidth + 1; num4++)
			{
				for (int num5 = -1; num5 < centerWidth + 1; num5++)
				{
					short index5 = (short)(centerIndex + num5 * areaWidth + num4);
					canUseBlockList.Remove(index5);
				}
			}
		}
		BuildingFormulaItem resourceInitLevelFormula = ((mapBlockItem.TemplateId == 0) ? BuildingFormula.DefValue.TaiwuVillageResourceInitLevel : BuildingFormula.DefValue.NonTaiwuVillageResourceInitLevel);
		for (int num6 = 0; num6 < landFormData.NormalResource.Length; num6++)
		{
			int randomCount = landFormData.NormalResource[num6] * (int)((float)blockCount / 1.6f) / 100;
			if (randomCount <= 0)
			{
				continue;
			}
			short buildingId3 = (short)(1 + num6);
			for (int num7 = 1; num7 <= randomCount; num7++)
			{
				if (num7 >= 5 || random.CheckPercentProb(num7 * 20))
				{
					short blockIndex4 = canUseBlockList[random.Next(0, canUseBlockList.Count)];
					sbyte resLevel = (sbyte)resourceInitLevelFormula.Calculate();
					AddElement_BuildingBlocks(new BuildingBlockKey(mapAreaId, mapBlockId, blockIndex4), new BuildingBlockData(blockIndex4, buildingId3, resLevel, -1), context);
					allBlockList.Remove(blockIndex4);
					canUseBlockList.Remove(blockIndex4);
				}
			}
		}
		for (int num8 = 0; num8 < landFormData.SpecialResource.Length; num8++)
		{
			int randomCount2 = landFormData.SpecialResource[num8] * (int)((float)blockCount / 1.6f) / 100;
			if (randomCount2 <= 0)
			{
				continue;
			}
			short buildingId4 = (short)(11 + num8);
			for (int num9 = 1; num9 <= randomCount2; num9++)
			{
				if (num9 >= 5 || random.CheckPercentProb(num9 * 20))
				{
					short blockIndex5 = canUseBlockList[random.Next(0, canUseBlockList.Count)];
					sbyte resLevel2 = (sbyte)resourceInitLevelFormula.Calculate();
					AddElement_BuildingBlocks(new BuildingBlockKey(mapAreaId, mapBlockId, blockIndex5), new BuildingBlockData(blockIndex5, buildingId4, resLevel2, -1), context);
					allBlockList.Remove(blockIndex5);
					canUseBlockList.Remove(blockIndex5);
				}
			}
		}
		BuildingFormulaItem uselessResourceFormula = BuildingFormula.DefValue.UselessResourceInitLevel;
		if (mapBlockItem.TemplateId == 0)
		{
			for (int num10 = 0; num10 < 3; num10++)
			{
				short buildingId5 = (short)(21 + num10);
				for (int num11 = 1; num11 <= 10; num11++)
				{
					if (canUseBlockList.Count < 1)
					{
						break;
					}
					short blockIndex6 = canUseBlockList[random.Next(0, canUseBlockList.Count)];
					sbyte resLevel3 = (sbyte)uselessResourceFormula.Calculate();
					AddElement_BuildingBlocks(new BuildingBlockKey(mapAreaId, mapBlockId, blockIndex6), new BuildingBlockData(blockIndex6, buildingId5, resLevel3, -1), context);
					allBlockList.Remove(blockIndex6);
					canUseBlockList.Remove(blockIndex6);
				}
			}
		}
		for (short i3 = 0; i3 < allBlockList.Count; i3++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(mapAreaId, mapBlockId, allBlockList[i3]);
			AddElement_BuildingBlocks(blockKey, new BuildingBlockData(allBlockList[i3], 0, -1, -1), context);
		}
		AddElement_BuildingAreas(location, areaData, context);
		ObjectPool<List<short>>.Instance.Return(allBlockList);
		ObjectPool<List<short>>.Instance.Return(canUseBlockList);
		ObjectPool<List<short>>.Instance.Return(centerNeighborList);
		ObjectPool<List<short>>.Instance.Return(centerNeighborsWidth2);
		ObjectPool<List<short>>.Instance.Return(indirectNeighbors);
		ObjectPool<List<short>>.Instance.Return(indirectNeighborsWidth2);
		ObjectPool<List<short>>.Instance.Return(temp);
	}

	private int ComparePresetBuildings(short templateIdA, short templateIdB)
	{
		BuildingBlockItem cfgA = BuildingBlock.Instance[templateIdA];
		BuildingBlockItem cfgB = BuildingBlock.Instance[templateIdB];
		return cfgA.DependBuildings.Count.CompareTo(cfgB.DependBuildings.Count);
	}

	public void AddTaiwuBuildingArea(DataContext context, Location location)
	{
		_taiwuBuildingAreas.Add(location);
		SetTaiwuBuildingAreas(_taiwuBuildingAreas, context);
		InitializeResidences(context, location);
		InitializeComfortableHouses(context, location);
		InitializeBuildingData(context, location);
		DomainManager.Extra.InitializeResourceBlockExtraData(context, location);
	}

	private void InitializeBuildingData(DataContext context, Location location)
	{
		IEnumerable<BuildingBlockData> blocks = GetBuildingBlocksAtLocation(location);
		foreach (BuildingBlockData block in blocks)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, block.BlockIndex);
			if (block.TemplateId == 44)
			{
				HandleTaiwuVillageInitUnlockSlot(context, blockKey, block, location);
			}
			else if (block.TemplateId >= 0 && block.ConfigData.Class == EBuildingBlockClass.BornResource)
			{
				HandleResourceLevel(context, blockKey, block);
			}
		}
	}

	private void HandleTaiwuVillageInitUnlockSlot(DataContext context, BuildingBlockKey blockKey, BuildingBlockData blockData, Location location)
	{
		sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
		sbyte sectId = MapState.Instance[stateTemplateId].SectID;
		sbyte initSectIndex = OrganizationDomain.GetLargeSectIndex(sectId);
		blockData.ResetInitialUnlockedSlot(initSectIndex);
		SetElement_BuildingBlocks(blockKey, blockData, context);
	}

	private void HandleResourceLevel(DataContext context, BuildingBlockKey blockKey, BuildingBlockData blockData)
	{
		for (int i = 0; i < blockData.Level; i++)
		{
			blockData.UnlockLevelSlot(i);
		}
		SetElement_BuildingBlocks(blockKey, blockData, context);
	}

	public void ApplyProsperousConstruction(DataContext context)
	{
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		HashSet<BuildingBlockKey> keys = ObjectPool<HashSet<BuildingBlockKey>>.Instance.Get();
		keys.Clear();
		foreach (var (key, data) in _buildingBlocks)
		{
			if (key.GetLocation() != taiwuVillageLocation)
			{
				continue;
			}
			EBuildingBlockType? eBuildingBlockType = data.ConfigData?.Type;
			bool flag;
			if (eBuildingBlockType.HasValue)
			{
				EBuildingBlockType valueOrDefault = eBuildingBlockType.GetValueOrDefault();
				if ((uint)valueOrDefault <= 1u)
				{
					flag = true;
					goto IL_00a7;
				}
			}
			flag = false;
			goto IL_00a7;
			IL_00a7:
			if (flag)
			{
				keys.Add(key);
			}
		}
		BuildingFormulaItem formula = BuildingFormula.DefValue.ProtagonistConstructionExtraLevel;
		foreach (BuildingBlockKey key2 in keys)
		{
			BuildingBlockData data2 = _buildingBlocks[key2];
			data2.Level = (sbyte)formula.Calculate(data2.Level);
			HandleResourceLevel(context, key2, data2);
		}
		ObjectPool<HashSet<BuildingBlockKey>>.Instance.Return(keys);
	}

	private short GetRandomAvailableBuildingBlock(DataContext context, List<short> allValidBlocks, List<short> indexes, List<short> backupIndexes, short areaId, short blockId, sbyte areaWidth, sbyte buildingWidth)
	{
		RemoveUnavailableBuildingBlocks(allValidBlocks, indexes, areaId, blockId, areaWidth, buildingWidth);
		short index;
		if (indexes.Count == 0)
		{
			RemoveUnavailableBuildingBlocks(allValidBlocks, backupIndexes, areaId, blockId, areaWidth, buildingWidth);
			if (backupIndexes.Count == 0)
			{
				return -1;
			}
			index = backupIndexes[context.Random.Next(0, backupIndexes.Count)];
		}
		else
		{
			index = indexes[context.Random.Next(0, indexes.Count)];
		}
		return index;
	}

	public void RemoveUnavailableBuildingBlocks(List<short> validBlockList, List<short> buildingBlocks, short areaId, short blockId, sbyte areaWidth, sbyte buildingWidth)
	{
		List<short> availableIndexes = ObjectPool<List<short>>.Instance.Get();
		availableIndexes.Clear();
		foreach (short index in buildingBlocks)
		{
			if (IsAllBlocksInValidBlockList(validBlockList, index, areaWidth, buildingWidth))
			{
				availableIndexes.Add(index);
			}
		}
		buildingBlocks.Clear();
		buildingBlocks.AddRange(availableIndexes);
		ObjectPool<List<short>>.Instance.Return(availableIndexes);
	}

	private void GetAvailableRootBlocks(List<short> buildingBlocks, List<short> availableIndexes, short areaId, short blockId, sbyte areaWidth, sbyte buildingWidth, bool clearFirst = true)
	{
		if (clearFirst)
		{
			availableIndexes.Clear();
		}
		foreach (short index in buildingBlocks)
		{
			for (int i = 0; i < buildingWidth; i++)
			{
				for (int j = 0; j < buildingWidth; j++)
				{
					short indexWithOffset = (short)(index - i * areaWidth - j);
					if (IsBuildingBlocksEmpty(areaId, blockId, indexWithOffset, areaWidth, buildingWidth) && !availableIndexes.Contains(indexWithOffset))
					{
						availableIndexes.Add(indexWithOffset);
					}
				}
			}
		}
	}

	private bool IsAllBlocksInValidBlockList(List<short> allValidBlock, short rootIndex, sbyte areaWidth, sbyte buildingWidth)
	{
		int x = rootIndex % areaWidth;
		int y = rootIndex / areaWidth;
		int blocks = 0;
		for (int i = 0; i < buildingWidth && x + i < areaWidth; i++)
		{
			for (int j = 0; j < buildingWidth && y + j < areaWidth; j++)
			{
				short index = (short)(rootIndex + i * areaWidth + j);
				if (!allValidBlock.Contains(index))
				{
					return false;
				}
				blocks++;
			}
		}
		if (blocks == buildingWidth * buildingWidth)
		{
			return true;
		}
		return false;
	}

	private bool IsLandFormTypeRandom(MapBlockItem config)
	{
		if ((config.SubType == EMapBlockSubType.Village || config.SubType == EMapBlockSubType.Town || config.SubType == EMapBlockSubType.WalledTown) && config.LandFormType == -1 && config.BuildingAreaWidth != -1)
		{
			return true;
		}
		return false;
	}

	[DomainMethod]
	public void CricketCollectionAdd(DataContext context, int index, bool isCricket, ItemKey itemKey)
	{
		Tester.Assert(itemKey.Id >= 0);
		Tester.Assert(index >= 0 && index < 17);
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		if (DomainManager.Taiwu.GetWarehouseAllItemKey().Contains(itemKey))
		{
			DomainManager.Taiwu.RemoveItem(context, itemKey, 1, 2, deleteItem: false);
		}
		else
		{
			DomainManager.Taiwu.RemoveItem(context, itemKey, 1, 1, deleteItem: false);
		}
		if (isCricket)
		{
			cricketCollectionData[index].Cricket = itemKey;
			DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Building, 44);
		}
		else
		{
			cricketCollectionData[index].CricketJar = itemKey;
			DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Building, 44);
		}
		cricketCollectionData[index].CricketRegen = 0;
		DomainManager.Extra.SetCricketCollectionDataList(cricketCollectionData, context);
	}

	[DomainMethod]
	public void CricketCollectionRemove(DataContext context, int index, bool isCricket)
	{
		Tester.Assert(index >= 0 && index < 17);
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (isCricket)
		{
			ItemKey itemKey = cricketCollectionData[index].Cricket;
			OfflineRemoveACricket(context, itemKey, cricketCollectionData, index, ItemSourceType.Inventory);
		}
		else
		{
			ItemKey itemKey2 = cricketCollectionData[index].CricketJar;
			OfflineRemoveAJar(context, itemKey2, cricketCollectionData, index, ItemSourceType.Inventory);
		}
		cricketCollectionData[index].CricketRegen = 0;
		DomainManager.Extra.SetCricketCollectionDataList(cricketCollectionData, context);
	}

	[DomainMethod]
	public void CricketCollectionBatchRemoveCricket(DataContext context, ItemSourceType sourceType)
	{
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		for (int i = 0; i < cricketCollectionData.Count; i++)
		{
			ItemKey itemKey = cricketCollectionData[i].Cricket;
			if (itemKey.IsValid())
			{
				OfflineRemoveACricket(context, itemKey, cricketCollectionData, i, sourceType);
				cricketCollectionData[i].CricketRegen = 0;
			}
		}
		DomainManager.Extra.SetCricketCollectionDataList(cricketCollectionData, context);
	}

	[DomainMethod]
	public void CricketCollectionBatchRemoveJar(DataContext context, ItemSourceType sourceType)
	{
		CricketCollectionBatchRemoveCricket(context, sourceType);
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		for (int i = 0; i < cricketCollectionData.Count; i++)
		{
			ItemKey itemKey = cricketCollectionData[i].CricketJar;
			if (itemKey.IsValid())
			{
				OfflineRemoveAJar(context, itemKey, cricketCollectionData, i, sourceType);
			}
		}
		DomainManager.Extra.SetCricketCollectionDataList(cricketCollectionData, context);
	}

	public void CricketCollectionRemoveCricket(DataContext context, ItemKey itemKey)
	{
		DomainManager.Item.RemoveOwner(itemKey, ItemOwnerType.Building, 44);
		List<CricketCollectionData> cricketCollection = DomainManager.Extra.GetCricketCollectionDataList();
		foreach (CricketCollectionData data in cricketCollection)
		{
			if (!(data.Cricket != itemKey))
			{
				data.Cricket = ItemKey.Invalid;
				data.CricketRegen = 0;
			}
		}
		DomainManager.Extra.SetCricketCollectionDataList(cricketCollection, context);
	}

	private void OfflineRemoveAJar(DataContext context, ItemKey itemKey, List<CricketCollectionData> cricketCollectionData, int i, ItemSourceType sourceType)
	{
		DomainManager.Item.RemoveOwner(itemKey, ItemOwnerType.Building, 44);
		if (!DomainManager.Taiwu.CanTransferItemToWarehouse(context) && sourceType == ItemSourceType.Inventory)
		{
			sourceType = ItemSourceType.Warehouse;
		}
		DomainManager.Taiwu.AddItem(context, itemKey, 1, (sbyte)sourceType);
		cricketCollectionData[i].CricketJar = ItemKey.Invalid;
	}

	private void OfflineRemoveACricket(DataContext context, ItemKey itemKey, List<CricketCollectionData> cricketCollectionData, int i, ItemSourceType sourceType)
	{
		DomainManager.Item.RemoveOwner(itemKey, ItemOwnerType.Building, 44);
		if (!DomainManager.Taiwu.CanTransferItemToWarehouse(context) && sourceType == ItemSourceType.Inventory)
		{
			sourceType = ItemSourceType.Warehouse;
		}
		DomainManager.Taiwu.AddItem(context, itemKey, 1, (sbyte)sourceType);
		cricketCollectionData[i].Cricket = ItemKey.Invalid;
	}

	private bool IsCricket(KeyValuePair<ItemKey, int> pair)
	{
		short subType = ItemTemplateHelper.GetItemSubType(pair.Key.ItemType, pair.Key.TemplateId);
		return subType == 1100;
	}

	private bool IsCricketJar(KeyValuePair<ItemKey, int> pair)
	{
		short subType = ItemTemplateHelper.GetItemSubType(pair.Key.ItemType, pair.Key.TemplateId);
		return subType == 1201;
	}

	[DomainMethod]
	public void CricketCollectionBatchAddCricket(DataContext context)
	{
		bool canTransfer = DomainManager.Taiwu.CanTransferItemToWarehouse(context);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		List<ItemWithSource> combinedList = new List<ItemWithSource>();
		List<KeyValuePair<ItemKey, int>> inventoryItems = GetInventoryCrickets(canTransfer, taiwuChar);
		List<KeyValuePair<ItemKey, int>> warehouseItems = GetWarehouseCrickets();
		List<(List<KeyValuePair<ItemKey, int>>, ItemSourceType)> sources = new List<(List<KeyValuePair<ItemKey, int>>, ItemSourceType)>
		{
			(inventoryItems, ItemSourceType.Inventory),
			(warehouseItems, ItemSourceType.Warehouse)
		};
		for (int i = 0; i < sources.Count; i++)
		{
			for (int j = 0; j < sources[i].Item1.Count; j++)
			{
				combinedList.Add(new ItemWithSource
				{
					ItemKey = sources[i].Item1[j].Key,
					Amount = sources[i].Item1[j].Value,
					Source = i,
					IndexInSource = j
				});
			}
		}
		combinedList.Sort(Compare);
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		int indexInCombinedList = 0;
		for (int k = 0; k < cricketCollectionData.Count; k++)
		{
			ItemKey cricketInCollection = cricketCollectionData[k].Cricket;
			ItemKey cricketJarInCollection = cricketCollectionData[k].CricketJar;
			if (cricketJarInCollection.IsValid() && !cricketInCollection.IsValid() && indexInCombinedList <= combinedList.Count - 1)
			{
				ItemWithSource itemWithSource = combinedList[indexInCombinedList];
				ItemKey itemKey = sources[itemWithSource.Source].Item1[itemWithSource.IndexInSource].Key;
				DomainManager.Taiwu.RemoveItem(context, itemKey, 1, (sbyte)sources[itemWithSource.Source].Item2, deleteItem: false);
				itemWithSource.Amount--;
				combinedList[indexInCombinedList] = itemWithSource;
				cricketCollectionData[k].Cricket = itemKey;
				DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Building, 44);
				cricketCollectionData[k].CricketRegen = 0;
				if (itemWithSource.Amount == 0)
				{
					indexInCombinedList++;
				}
			}
		}
		DomainManager.Extra.SetCricketCollectionDataList(cricketCollectionData, context);
		static int Compare(ItemWithSource a, ItemWithSource b)
		{
			GameData.Domains.Item.Cricket cricketA = DomainManager.Item.GetElement_Crickets(a.ItemKey.Id);
			GameData.Domains.Item.Cricket cricketB = DomainManager.Item.GetElement_Crickets(b.ItemKey.Id);
			if (cricketA == null || cricketB == null)
			{
				if (cricketA == null && cricketB == null)
				{
					return 0;
				}
				if (cricketA == null)
				{
					return -1;
				}
				if (cricketB == null)
				{
					return 1;
				}
			}
			short durabilityNumberA = cricketA.GetCurrDurability();
			short durabilityNumberB = cricketB.GetCurrDurability();
			float durabilityA = (float)durabilityNumberA / (float)cricketA.GetMaxDurability();
			float durabilityB = (float)durabilityNumberB / (float)cricketB.GetMaxDurability();
			if (durabilityNumberA == 0 && durabilityNumberB > 0)
			{
				return 1;
			}
			if (durabilityNumberB == 0 && durabilityNumberA > 0)
			{
				return -1;
			}
			int durabilityComparison = durabilityA.CompareTo(durabilityB);
			if (durabilityComparison != 0)
			{
				return durabilityComparison;
			}
			sbyte gradeA = cricketA.GetGrade();
			int gradeComparison = cricketB.GetGrade().CompareTo(gradeA);
			if (gradeComparison != 0)
			{
				return gradeComparison;
			}
			return a.ItemKey.Id.CompareTo(b.ItemKey.Id);
		}
	}

	private List<KeyValuePair<ItemKey, int>> GetTroughCrickets()
	{
		return DomainManager.Taiwu.TroughItems.Where(IsCricket).ToList();
	}

	private List<KeyValuePair<ItemKey, int>> GetWarehouseCrickets()
	{
		return DomainManager.Taiwu.WarehouseItems.Where(IsCricket).ToList();
	}

	private static List<KeyValuePair<ItemKey, int>> GetInventoryCrickets(bool canTransfer, GameData.Domains.Character.Character taiwuChar)
	{
		List<KeyValuePair<ItemKey, int>> inventoryItems = new List<KeyValuePair<ItemKey, int>>();
		if (canTransfer)
		{
			List<ItemDisplayData> cricketDisplayDataList = DomainManager.Character.GetInventoryItems(taiwuChar.GetId(), 1100);
			foreach (ItemDisplayData itemDisplayData in cricketDisplayDataList)
			{
				inventoryItems.Add(new KeyValuePair<ItemKey, int>(itemDisplayData.Key, itemDisplayData.Amount));
			}
		}
		return inventoryItems;
	}

	[DomainMethod]
	public void CricketCollectionBatchAddCricketJar(DataContext context)
	{
		bool canTransfer = DomainManager.Taiwu.CanTransferItemToWarehouse(context);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		List<ItemWithSource> combinedList = new List<ItemWithSource>();
		List<KeyValuePair<ItemKey, int>> inventoryItems = GetInventoryCricketJars(canTransfer, taiwuChar);
		List<KeyValuePair<ItemKey, int>> warehouseItems = GetWarehouseCricketJars();
		List<(List<KeyValuePair<ItemKey, int>>, ItemSourceType)> sources = new List<(List<KeyValuePair<ItemKey, int>>, ItemSourceType)>
		{
			(inventoryItems, ItemSourceType.Inventory),
			(warehouseItems, ItemSourceType.Warehouse)
		};
		for (int i = 0; i < sources.Count; i++)
		{
			for (int j = 0; j < sources[i].Item1.Count; j++)
			{
				combinedList.Add(new ItemWithSource
				{
					ItemKey = sources[i].Item1[j].Key,
					Amount = sources[i].Item1[j].Value,
					Source = i,
					IndexInSource = j
				});
			}
		}
		combinedList.Sort(Compare);
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		int indexInCombinedList = 0;
		for (int k = 0; k < cricketCollectionData.Count; k++)
		{
			ItemKey cricketJarInCollection = cricketCollectionData[k].CricketJar;
			if (!cricketJarInCollection.IsValid() && indexInCombinedList <= combinedList.Count - 1)
			{
				ItemWithSource itemWithSource = combinedList[indexInCombinedList];
				ItemKey itemKey = sources[itemWithSource.Source].Item1[itemWithSource.IndexInSource].Key;
				DomainManager.Taiwu.RemoveItem(context, itemKey, 1, (sbyte)sources[itemWithSource.Source].Item2, deleteItem: false);
				itemWithSource.Amount--;
				combinedList[indexInCombinedList] = itemWithSource;
				cricketCollectionData[k].CricketJar = itemKey;
				DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Building, 44);
				cricketCollectionData[k].CricketRegen = 0;
				if (itemWithSource.Amount == 0)
				{
					indexInCombinedList++;
				}
			}
		}
		DomainManager.Extra.SetCricketCollectionDataList(cricketCollectionData, context);
		static int Compare(ItemWithSource a, ItemWithSource b)
		{
			GameData.Domains.Item.Misc cricketJarA = DomainManager.Item.GetElement_Misc(a.ItemKey.Id);
			GameData.Domains.Item.Misc cricketJarB = DomainManager.Item.GetElement_Misc(b.ItemKey.Id);
			sbyte gradeA = cricketJarA.GetGrade();
			int gradeComparison = cricketJarB.GetGrade().CompareTo(gradeA);
			if (gradeComparison != 0)
			{
				return gradeComparison;
			}
			return a.ItemKey.Id.CompareTo(b.ItemKey.Id);
		}
	}

	private List<KeyValuePair<ItemKey, int>> GetTroughCricketJars()
	{
		return DomainManager.Taiwu.TroughItems.Where(IsCricketJar).ToList();
	}

	private List<KeyValuePair<ItemKey, int>> GetWarehouseCricketJars()
	{
		return DomainManager.Taiwu.WarehouseItems.Where(IsCricketJar).ToList();
	}

	private static List<KeyValuePair<ItemKey, int>> GetInventoryCricketJars(bool canTransfer, GameData.Domains.Character.Character taiwuChar)
	{
		List<KeyValuePair<ItemKey, int>> inventoryItems = new List<KeyValuePair<ItemKey, int>>();
		if (canTransfer)
		{
			List<ItemDisplayData> cricketDisplayDataList = DomainManager.Character.GetInventoryItems(taiwuChar.GetId(), 1201);
			foreach (ItemDisplayData itemDisplayData in cricketDisplayDataList)
			{
				inventoryItems.Add(new KeyValuePair<ItemKey, int>(itemDisplayData.Key, itemDisplayData.Amount));
			}
		}
		return inventoryItems;
	}

	[DomainMethod]
	public CricketCollectionDisplayData GetCricketCollectionDisplayData(DataContext context)
	{
		CricketCollectionDisplayData res = new CricketCollectionDisplayData
		{
			Items = new List<ItemDisplayData>(),
			IsInVillage = DomainManager.Taiwu.CanTransferItemToWarehouse(context),
			CollectionJars = GetCollectionJars(context),
			CollectionCrickets = GetCollectionCrickets(context),
			CollectionCricketRegen = GetCollectionCricketRegen(context),
			AuthorityGain = GetAuthorityGain(context),
			BatchModeButtonStateData = GetBatchButtonEnableState(context),
			AliveCrickets = new Dictionary<int, bool>(),
			CricketRoomData = DomainManager.Taiwu.GetCricketRoomData(),
			CricketLuckPoint = DomainManager.Taiwu.GetCricketLuckPoint(),
			MaterialItems = new List<ItemDisplayData>()
		};
		res.Items.AddRange(GetCricketsAndJarFromSource(ItemSourceType.Inventory));
		res.Items.AddRange(GetCricketsAndJarFromSource(ItemSourceType.Warehouse));
		ItemDisplayData[] collectionJars = res.CollectionJars;
		foreach (ItemDisplayData data in collectionJars)
		{
			if (!data.RealKey.Equals(ItemKey.Invalid))
			{
				res.Items.Add(data);
			}
		}
		ItemDisplayData[] collectionCrickets = res.CollectionCrickets;
		foreach (ItemDisplayData data2 in collectionCrickets)
		{
			if (!data2.RealKey.Equals(ItemKey.Invalid))
			{
				res.Items.Add(data2);
			}
		}
		foreach (ItemDisplayData item in res.Items)
		{
			if (ItemTemplateHelper.GetItemSubType(item.RealKey.ItemType, item.RealKey.TemplateId) == 1100 && DomainManager.Item.TryGetElement_Crickets(item.RealKey.Id, out var cricket) && cricket.IsAlive)
			{
				res.AliveCrickets.Add(item.RealKey.Id, value: true);
			}
		}
		res.MaterialItems.AddRange(GetMaterialsFromSource(ItemSourceType.Inventory));
		res.MaterialItems.AddRange(GetMaterialsFromSource(ItemSourceType.Warehouse));
		return res;
	}

	private IEnumerable<ItemDisplayData> GetCricketsAndJarFromSource(ItemSourceType type)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		IReadOnlyDictionary<ItemKey, int> items = DomainManager.Taiwu.GetItems(type);
		foreach (KeyValuePair<ItemKey, int> item in items)
		{
			item.Deconstruct(out var key, out var value);
			ItemKey itemKey = key;
			int count = value;
			short itemSubType = itemKey.GetConfig().ItemSubType;
			if ((itemSubType == 1100 || itemSubType == 1201) ? true : false)
			{
				yield return DomainManager.Item.GetItemDisplayData(DomainManager.Item.GetBaseItem(itemKey), count, taiwuId, (sbyte)type);
			}
		}
	}

	private IEnumerable<ItemDisplayData> GetMaterialsFromSource(ItemSourceType type)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		IReadOnlyDictionary<ItemKey, int> items = DomainManager.Taiwu.GetItems(type);
		foreach (var (itemKey2, count) in items)
		{
			if (itemKey2.ItemType == 12)
			{
				MiscItem template = Config.Misc.Instance[itemKey2.TemplateId];
				if (template != null && template.ResourceMaterialType != EMiscResourceMaterialType.Invalid)
				{
					yield return DomainManager.Item.GetItemDisplayData(DomainManager.Item.GetBaseItem(itemKey2), count, taiwuId, (sbyte)type);
				}
			}
		}
	}

	[DomainMethod]
	public List<ItemDisplayData> GetCricketOrJarFromSourceStorage(DataContext context, short itemSubType, ItemSourceType sourceType)
	{
		if (itemSubType != 1100 && itemSubType != 1201)
		{
			throw new ArgumentException("itemSubType must be Cricket or CricketJar");
		}
		if (sourceType != ItemSourceType.Inventory && sourceType != ItemSourceType.Warehouse && sourceType != ItemSourceType.Trough)
		{
			throw new ArgumentException("sourceType must be Inventory or Warehouse or Trough");
		}
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		List<ItemDisplayData> result = null;
		bool canTransfer = DomainManager.Taiwu.CanTransferItemToWarehouse(context);
		switch (sourceType)
		{
		case ItemSourceType.Inventory:
			if (!canTransfer)
			{
				throw new InvalidOperationException("Cannot transfer item");
			}
			result = DomainManager.Character.GetInventoryItems(taiwuChar.GetId(), itemSubType);
			break;
		case ItemSourceType.Warehouse:
			result = DomainManager.Taiwu.GetWarehouseItemsBySubType(context, itemSubType);
			break;
		case ItemSourceType.Trough:
		{
			Dictionary<ItemKey, int> items = DomainManager.Taiwu.TroughItems.Where((KeyValuePair<ItemKey, int> pair) => ItemTemplateHelper.GetItemSubType(pair.Key.ItemType, pair.Key.TemplateId) == itemSubType).ToDictionary((KeyValuePair<ItemKey, int> pair) => pair.Key, (KeyValuePair<ItemKey, int> pair) => pair.Value);
			result = CharacterDomain.GetItemDisplayData(taiwuChar.GetId(), items, ItemSourceType.Trough);
			break;
		}
		}
		return result;
	}

	[DomainMethod]
	public void SmartOperateCricketOrJarCollection(DataContext context, int collectionIndex, short itemSubType, ItemSourceType sourceType, ItemKey itemKey)
	{
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		if (collectionIndex < 0 || collectionIndex >= cricketCollectionData.Count)
		{
			throw new ArgumentOutOfRangeException("collectionIndex", collectionIndex, null);
		}
		ItemKey cricket = cricketCollectionData[collectionIndex].Cricket;
		ItemKey jar = cricketCollectionData[collectionIndex].CricketJar;
		switch (itemSubType)
		{
		case 1100:
			if (!jar.IsValid())
			{
				throw new InvalidOperationException("No jar in the collection");
			}
			if (cricket.IsValid())
			{
				OfflineRemoveACricket(context, cricket, cricketCollectionData, collectionIndex, sourceType);
			}
			if (itemKey.IsValid())
			{
				cricketCollectionData[collectionIndex].Cricket = itemKey;
				DomainManager.Taiwu.RemoveItem(context, itemKey, 1, (sbyte)sourceType, deleteItem: false);
				DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Building, 44);
				cricketCollectionData[collectionIndex].CricketRegen = 0;
			}
			break;
		case 1201:
			if (jar.IsValid())
			{
				OfflineRemoveAJar(context, jar, cricketCollectionData, collectionIndex, sourceType);
			}
			if (itemKey.IsValid())
			{
				DomainManager.Taiwu.RemoveItem(context, itemKey, 1, (sbyte)sourceType, deleteItem: false);
				DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Building, 44);
				cricketCollectionData[collectionIndex].CricketJar = itemKey;
			}
			else if (cricket.IsValid())
			{
				OfflineRemoveACricket(context, cricket, cricketCollectionData, collectionIndex, sourceType);
			}
			break;
		default:
			throw new ArgumentException("itemSubType must be Cricket or CricketJar");
		}
		DomainManager.Extra.SetCricketCollectionDataList(cricketCollectionData, context);
	}

	[DomainMethod]
	public CricketCollectionBatchButtonStateDisplayData GetBatchButtonEnableState(DataContext context)
	{
		bool hasCricket = false;
		bool hasEmptyJar = false;
		bool hasJar = false;
		bool hasEmptySlot = false;
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		foreach (CricketCollectionData slot in cricketCollectionData)
		{
			if (slot.CricketJar.IsValid())
			{
				hasJar = true;
				if (slot.Cricket.IsValid())
				{
					hasCricket = true;
				}
				else
				{
					hasEmptyJar = true;
				}
			}
			else
			{
				hasEmptySlot = true;
			}
		}
		bool canTransfer = DomainManager.Taiwu.CanTransferItemToWarehouse(context);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		bool hasSourceCricket = GetInventoryCrickets(canTransfer, taiwuChar).Count > 0 || GetWarehouseCrickets().Count > 0;
		bool hasSourceCricketJar = GetInventoryCricketJars(canTransfer, taiwuChar).Count > 0 || GetWarehouseCricketJars().Count > 0;
		return new CricketCollectionBatchButtonStateDisplayData
		{
			HasCricketInCollection = hasCricket,
			HasJarInCollection = hasJar,
			HasCricketInSources = hasSourceCricket,
			HasEmptyJarInCollection = hasEmptyJar,
			HasJarInSources = hasSourceCricketJar,
			HasEmptyPositionInCollection = hasEmptySlot
		};
	}

	[DomainMethod]
	public ItemDisplayData[] GetCollectionCrickets(DataContext context)
	{
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		ItemDisplayData[] crickets = new ItemDisplayData[cricketCollectionData.Count];
		for (int i = 0; i < crickets.Length; i++)
		{
			if (!cricketCollectionData[i].Cricket.Equals(ItemKey.Invalid))
			{
				crickets[i] = DomainManager.Item.GetItemDisplayData(cricketCollectionData[i].Cricket);
			}
			else
			{
				crickets[i] = new ItemDisplayData();
			}
		}
		return crickets;
	}

	[DomainMethod]
	public ItemDisplayData[] GetCollectionJars(DataContext context)
	{
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		ItemDisplayData[] jars = new ItemDisplayData[cricketCollectionData.Count];
		for (int i = 0; i < jars.Length; i++)
		{
			if (!cricketCollectionData[i].CricketJar.Equals(ItemKey.Invalid))
			{
				jars[i] = DomainManager.Item.GetItemDisplayData(cricketCollectionData[i].CricketJar);
			}
			else
			{
				jars[i] = new ItemDisplayData();
			}
		}
		return jars;
	}

	[DomainMethod]
	public int[] GetCollectionCricketRegen(DataContext context)
	{
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		int[] result = new int[cricketCollectionData.Count];
		for (int i = 0; i < cricketCollectionData.Count; i++)
		{
			result[i] = cricketCollectionData[i].CricketRegen;
		}
		return result;
	}

	[DomainMethod]
	public int GetAuthorityGain(DataContext context)
	{
		return GetCricketAuthorityGain();
	}

	public static int GetCricketAuthorityGain()
	{
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		int authorityGain = 0;
		for (int i = 0; i < cricketCollectionData.Count; i++)
		{
			if (!cricketCollectionData[i].Cricket.Equals(ItemKey.Invalid))
			{
				if (!DomainManager.Item.TryGetElement_Crickets(cricketCollectionData[i].Cricket.Id, out var cricketData))
				{
					Logger.AppendWarning($"Cannot get cricket with id {cricketCollectionData[i].Cricket} at the position {i} of cricket collection while getting authority gain.");
				}
				else
				{
					int level = ((cricketData.GetColorData().Level >= cricketData.GetPartsData().Level) ? cricketData.GetColorData().Level : cricketData.GetPartsData().Level);
					int winless = cricketData.GetWinsCount();
					int defeat = cricketData.GetLossesCount();
					authorityGain += Math.Max(winless - defeat, 0) * level * ((defeat <= 0) ? 100 : 50) / 50;
				}
			}
		}
		return authorityGain;
	}

	public void ApplyCricketAuthorityGain(DataContext context)
	{
		if (DomainManager.World.GetCurrMonthInYear() == GlobalConfig.Instance.CricketActiveStartMonth)
		{
			int authorityGain = GetAuthorityGain(context);
			if (authorityGain > 0)
			{
				GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
				taiwu.ChangeResource(context, 7, authorityGain);
			}
		}
	}

	public void UpdateCricketRoom(DataContext context)
	{
		int addSpirit = DomainManager.Taiwu.CalcCricketRoomAddSpiritEffect();
		CValuePercentBonus recoverDurabilityBonus = DomainManager.Taiwu.CalcCricketRoomRecoverDurabilityBonus();
		int recoverDurability = 1 * recoverDurabilityBonus;
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		for (int i = 0; i < 17; i++)
		{
			if (cricketCollectionData[i].Cricket.Equals(ItemKey.Invalid))
			{
				continue;
			}
			GameData.Domains.Item.Cricket cricket = DomainManager.Item.GetElement_Crickets(cricketCollectionData[i].Cricket.Id);
			short[] injuries = cricket.GetInjuries();
			bool hasInjury = injuries.Exist((short value) => value > 0);
			if (!cricket.IsAlive)
			{
				continue;
			}
			MiscItem jarConfig = Config.Misc.Instance[cricketCollectionData[i].CricketJar.TemplateId];
			if (DlcManager.IsDlcInstalled(4528730uL))
			{
				int addValue = addSpirit + 2 * jarConfig.Grade;
				cricket.AddSpirit(context, addValue);
			}
			if (cricket.GetCurrDurability() >= cricket.GetMaxDurability() && !hasInjury)
			{
				continue;
			}
			cricketCollectionData[i].CricketRegen++;
			if (cricketCollectionData[i].CricketRegen < SharedMethods.CalcCricketRegenTime(jarConfig.Grade))
			{
				continue;
			}
			cricketCollectionData[i].CricketRegen = 0;
			cricket.SetCurrDurability(Math.Min(cricket.GetMaxDurability(), (short)(cricket.GetCurrDurability() + recoverDurability)), context);
			if (!hasInjury || !context.Random.CheckPercentProb(jarConfig.CricketHealInjuryOdds))
			{
				continue;
			}
			List<int> typeRandomPool = ObjectPool<List<int>>.Instance.Get();
			typeRandomPool.Clear();
			for (int injuryIndex = 0; injuryIndex < injuries.Length; injuryIndex++)
			{
				if (injuries[injuryIndex] > 0)
				{
					typeRandomPool.Add(injuryIndex);
				}
			}
			int healIndex = typeRandomPool[context.Random.Next(typeRandomPool.Count)];
			injuries[healIndex] = (short)Math.Max(injuries[healIndex] - ((healIndex >= 2) ? 1 : 5), 0);
			cricket.SetInjuries(injuries, context);
			ObjectPool<List<int>>.Instance.Return(typeRandomPool);
		}
		DomainManager.Extra.SetCricketCollectionDataList(cricketCollectionData, context);
	}

	public override void PackCrossArchiveGameData(CrossArchiveGameData crossArchiveGameData)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			BuildingBlockItem config = BuildingBlock.Instance[blockData.TemplateId];
			if (config != null && config.TemplateId >= 0)
			{
				bool isPawnshop = config.TemplateId == 222;
				DataContext context = DataContextManager.GetCurrentThreadDataContext();
				if (TryGetElement_CollectBuildingEarningsData(blockKey, out var data))
				{
					List<ItemKey> fixBookInfoList = data.FixBookInfoList;
					if (fixBookInfoList != null && fixBookInfoList.Count > 0)
					{
						if (crossArchiveGameData.WarehouseItems == null)
						{
							crossArchiveGameData.WarehouseItems = new Inventory();
						}
						foreach (ItemKey itemKey in data.FixBookInfoList)
						{
							if (itemKey.IsValid())
							{
								crossArchiveGameData.PackItemInventory(itemKey, 1, crossArchiveGameData.WarehouseItems);
							}
						}
						blockData.OfflineResetShopProgress();
						data.FixBookInfoList.Clear();
					}
				}
				ClearBuildingBlockEarningsData(context, blockKey, isPawnshop, clearOutputSetting: false);
				if (blockData.OperationType != -1)
				{
					SetStopOperation(context, blockKey, stop: true);
				}
			}
		}
		crossArchiveGameData.AutoWorkBlockIndexList = DomainManager.Extra.GetAutoWorkBlockIndexList();
		crossArchiveGameData.AutoSoldBlockIndexList = DomainManager.Extra.GetAutoSoldBlockIndexList();
		crossArchiveGameData.AutoCheckInList = DomainManager.Extra.GetAutoCheckInResidenceList();
		crossArchiveGameData.AutoCheckInComfortableList = DomainManager.Extra.GetAutoCheckInComfortableList();
		crossArchiveGameData.ComfortableHousesAutoCheckInType = _comfortableHousesAutoCheckInType;
		foreach (CricketCollectionData cricketData in crossArchiveGameData.CricketCollectionDatas = DomainManager.Extra.GetCricketCollectionDataList())
		{
			if (cricketData.Cricket.IsValid())
			{
				DomainManager.Item.PackCrossArchiveItem(crossArchiveGameData, cricketData.Cricket);
			}
			if (cricketData.CricketJar.IsValid())
			{
				DomainManager.Item.PackCrossArchiveItem(crossArchiveGameData, cricketData.CricketJar);
			}
		}
		crossArchiveGameData.TaiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		crossArchiveGameData.TaiwuVillageAreaData = GetBuildingAreaData(crossArchiveGameData.TaiwuVillageLocation);
		crossArchiveGameData.TaiwuVillageBlocks = GetBuildingBlockList(crossArchiveGameData.TaiwuVillageLocation);
		crossArchiveGameData.BuildingDefaultStoreLocation = DomainManager.Extra.GetBuildingDefaultStoreLocation();
		crossArchiveGameData.BuildingResourceOutputSettings = DomainManager.Extra.GetBuildingResourceOutputSettings();
		crossArchiveGameData.VillagerRoleAutoActionStates = DomainManager.Extra.GetVillagerRoleAutoActionStates();
		crossArchiveGameData.FarmerAutoCollectStorageType = DomainManager.Extra.GetFarmerAutoCollectStorageType();
		crossArchiveGameData.Chicken = new Dictionary<int, Chicken>();
		if (_chicken != null)
		{
			foreach (KeyValuePair<int, Chicken> pair in _chicken)
			{
				crossArchiveGameData.Chicken[pair.Key] = pair.Value;
			}
		}
		crossArchiveGameData.XiangshuIdInKungfuPracticeRoom = new List<sbyte>();
		crossArchiveGameData.XiangshuIdInKungfuPracticeRoom.AddRange(DomainManager.Extra.GetXiangshuIdInKungfuPracticeRoom());
		crossArchiveGameData.SamsaraPlatformAddCombatSkillQualifications = _samsaraPlatformAddCombatSkillQualifications;
		crossArchiveGameData.SamsaraPlatformAddLifeSkillQualifications = _samsaraPlatformAddLifeSkillQualifications;
		crossArchiveGameData.SamsaraPlatformAddMainAttributes = _samsaraPlatformAddMainAttributes;
	}

	public override void UnpackCrossArchiveGameData(DataContext context, CrossArchiveGameData crossArchiveGameData)
	{
		SetSamsaraPlatformAddCombatSkillQualifications(ref crossArchiveGameData.SamsaraPlatformAddCombatSkillQualifications, context);
		SetSamsaraPlatformAddLifeSkillQualifications(ref crossArchiveGameData.SamsaraPlatformAddLifeSkillQualifications, context);
		SetSamsaraPlatformAddMainAttributes(crossArchiveGameData.SamsaraPlatformAddMainAttributes, context);
	}

	public void UnpackCrossArchiveGameData_Building(DataContext context, CrossArchiveGameData crossArchiveGameData)
	{
		SetAllVillagerHomeless(context);
		Location location = crossArchiveGameData.TaiwuVillageLocation;
		short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		if (location != DomainManager.Taiwu.GetTaiwuVillageLocation())
		{
			return;
		}
		List<BuildingBlockKey> toResetBlocks = new List<BuildingBlockKey>();
		SetElement_BuildingAreas(location, crossArchiveGameData.TaiwuVillageAreaData, context);
		DomainManager.Extra.SetBuildingDefaultStoreLocation(crossArchiveGameData.BuildingDefaultStoreLocation ?? new BuildingDefaultStoreLocation(), context);
		DomainManager.Extra.SetBuildingResourceOutputSettings(crossArchiveGameData.BuildingResourceOutputSettings ?? new Dictionary<int, BuildingResourceOutputSetting>(), context);
		DomainManager.Extra.SetVillagerRoleAutoActionStates(crossArchiveGameData.VillagerRoleAutoActionStates ?? new Dictionary<short, ulong>(), context);
		DomainManager.Extra.SetFarmerAutoCollectStorageType(crossArchiveGameData.FarmerAutoCollectStorageType, context);
		foreach (BuildingBlockData blockData in crossArchiveGameData.TaiwuVillageBlocks)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, blockData.BlockIndex);
			SetElement_BuildingBlocks(blockKey, blockData, context);
			BuildingBlockData buildingBlockData = DomainManager.Building.GetBuildingBlockData(blockKey);
			if (blockData.TemplateId == 44)
			{
				DomainManager.Extra.TriggerTaiwuVillageVowMonthlyEventFromCrossArchive(context, buildingBlockData);
			}
			if (blockData.TemplateId == 46)
			{
				QuickFillResidence(context, blockKey);
			}
			else if (blockData.TemplateId == 47)
			{
				QuickFillComfortableHouse(context, blockKey);
			}
		}
		DomainManager.Extra.InitFeasts(context);
		DomainManager.Extra.InitializeResourceBlockExtraData(context, DomainManager.Taiwu.GetTaiwuVillageLocation());
		foreach (BuildingBlockKey blockKey2 in toResetBlocks)
		{
			ResetAllChildrenBlocks(context, blockKey2, 0, 1);
		}
		crossArchiveGameData.TaiwuVillageBlocks = null;
		List<short> autoSoldBlockIndexList = crossArchiveGameData.AutoSoldBlockIndexList;
		if (autoSoldBlockIndexList != null)
		{
			DomainManager.Extra.SetAutoSoldBlockIndexList(autoSoldBlockIndexList, context);
		}
		List<short> autoWorkBlockIndexList = crossArchiveGameData.AutoWorkBlockIndexList;
		if (autoWorkBlockIndexList != null)
		{
			DomainManager.Extra.SetAutoWorkBlockIndexList(autoWorkBlockIndexList, context);
		}
		List<short> autoCheckInList = crossArchiveGameData.AutoCheckInList;
		if (autoCheckInList != null)
		{
			DomainManager.Extra.SetAutoCheckInResidenceList(autoCheckInList, context);
		}
		List<short> autoCheckInComfortableList = crossArchiveGameData.AutoCheckInComfortableList;
		if (autoCheckInComfortableList != null)
		{
			DomainManager.Extra.SetAutoCheckInComfortableList(crossArchiveGameData.AutoCheckInComfortableList, context);
		}
		Dictionary<BuildingBlockKey, bool> comfortableHousesAutoCheckInType = crossArchiveGameData.ComfortableHousesAutoCheckInType;
		if (comfortableHousesAutoCheckInType != null)
		{
			foreach (KeyValuePair<BuildingBlockKey, bool> kv in comfortableHousesAutoCheckInType)
			{
				SetComfortableAutoCheckInType(context, kv.Key, kv.Value);
			}
		}
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		if (crossArchiveGameData.CricketCollectionDatas != null && crossArchiveGameData.CricketCollectionDatas.Count != 0)
		{
			for (int index = 0; index < crossArchiveGameData.CricketCollectionDatas.Count; index++)
			{
				CricketCollectionData cricketData = crossArchiveGameData.CricketCollectionDatas[index];
				if (cricketData.Cricket.IsValid())
				{
					cricketCollectionData[index].Cricket = DomainManager.Item.UnpackCrossArchiveItem(context, crossArchiveGameData, cricketData.Cricket);
					DomainManager.Item.SetOwner(cricketCollectionData[index].Cricket, ItemOwnerType.Building, 44);
				}
				if (cricketData.CricketJar.IsValid())
				{
					cricketCollectionData[index].CricketJar = DomainManager.Item.UnpackCrossArchiveItem(context, crossArchiveGameData, cricketData.CricketJar);
					DomainManager.Item.SetOwner(cricketCollectionData[index].CricketJar, ItemOwnerType.Building, 44);
				}
				cricketCollectionData[index].CricketRegen = cricketData.CricketRegen;
			}
			crossArchiveGameData.CricketCollectionDatas = null;
			DomainManager.Extra.SetCricketCollectionDataList(cricketCollectionData, context);
		}
		UpdateBuildingEffect();
		DomainManager.World.SetWorldFunctionsStatus(context, 11);
		ClearChicken(context);
		if (crossArchiveGameData.Chicken != null)
		{
			int id = 0;
			foreach (KeyValuePair<int, Chicken> pair in crossArchiveGameData.Chicken)
			{
				if (pair.Value.TemplateId != 63)
				{
					Chicken chicken = pair.Value;
					chicken.Id = id;
					AddElement_Chicken(id, chicken, context);
					id++;
				}
			}
		}
		InitializeNextChickenId();
		crossArchiveGameData.Chicken = null;
		if (crossArchiveGameData.XiangshuIdInKungfuPracticeRoom != null)
		{
			DomainManager.Extra.SetXiangshuIdInKungfuPracticeRoom(crossArchiveGameData.XiangshuIdInKungfuPracticeRoom, context);
			crossArchiveGameData.XiangshuIdInKungfuPracticeRoom = null;
		}
	}

	[DomainMethod]
	public (short, BuildingBlockData) GmCmd_BuildImmediately(DataContext context, short buildingTemplateId, BuildingBlockKey blockKey, sbyte level)
	{
		BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
		BuildingRemoveVillagerWork(context, blockKey);
		BuildingRemoveResident(context, blockData, blockKey);
		level = Math.Clamp(level, 1, BuildingBlock.Instance[buildingTemplateId].MaxLevel);
		ResetAllChildrenBlocks(context, blockKey, buildingTemplateId, level);
		for (int i = 0; i < level; i++)
		{
			blockData.UnlockLevelSlot(i);
		}
		SetElement_BuildingBlocks(blockKey, blockData, context);
		UpdateTaiwuVillageBuildingEffect();
		return (blockKey.BuildingBlockIndex, blockData);
	}

	[DomainMethod]
	public (short, BuildingBlockData) GmCmd_RemoveBuildingImmediately(DataContext context, BuildingBlockKey blockKey)
	{
		BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
		BuildingRemoveVillagerWork(context, blockKey);
		BuildingRemoveResident(context, blockData, blockKey);
		ResetAllChildrenBlocks(context, blockKey, 0, -1);
		UpdateTaiwuVillageBuildingEffect();
		OnBuildingRemoved(context, blockKey);
		return (blockKey.BuildingBlockIndex, GetElement_BuildingBlocks(blockKey));
	}

	[DomainMethod]
	public void GmCmd_AddLegacyBuilding(DataContext context, short buildingTemplateId)
	{
		List<short> list = DomainManager.Extra.GetLegaciesBuildingTemplateIdList();
		list.Add(buildingTemplateId);
		DomainManager.Extra.SetLegaciesBuildingTemplateIdList(list, context);
	}

	[DomainMethod]
	public List<Chicken> GmCmd_GetChickenData()
	{
		List<Chicken> chicken = new List<Chicken>();
		chicken.AddRange(_chicken.Values);
		return chicken;
	}

	[DomainMethod]
	public bool GmCmd_BeatMinionPerform(DataContext context, sbyte grade, int repeat)
	{
		CombatResultDisplayData combatResultData = new CombatResultDisplayData
		{
			CombatStatus = 3
		};
		short createdTemplateId = (short)(366 + grade);
		int[] enemyTeam = new int[1] { -1 };
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		List<ItemDisplayData> lootItemList = new List<ItemDisplayData>();
		for (int i = 0; i < repeat; i++)
		{
			GameData.Domains.Character.Character createRandomEnemy = DomainManager.Character.CreateRandomEnemy(context, createdTemplateId, isTemporary: true);
			int createRandomEnemyId = createRandomEnemy.GetId();
			DomainManager.Character.CompleteCreatingCharacter(createRandomEnemyId);
			enemyTeam[0] = createRandomEnemyId;
			CombatConfigItem combatConfig = CombatConfig.Instance[(short)1];
			CombatDomain.ResultCalcExp(combatConfig, isPlaygroundCombat: false, taiwuChar, enemyTeam, combatResultData);
			CombatDomain.ResultCalcResource(combatConfig, isPlaygroundCombat: false, taiwuChar, enemyTeam, combatResultData);
			CombatDomain.ResultCalcAreaSpiritualDebt(isWin: true, taiwuChar, enemyTeam, combatResultData);
			CombatDomain.ResultCalcLootItem(context.Random, 50, combatConfig.CombatType, combatResultData.CombatStatus, isPuppetCombat: false, combatConfig, taiwuChar, enemyTeam, Array.Empty<int>(), combatResultData);
			GameData.Domains.Character.Character enemyChar = createRandomEnemy;
			ItemKey[] enemyEquips = enemyChar.GetEquipment();
			foreach (ItemDisplayData itemKey in combatResultData.ItemList)
			{
				ItemKey key = itemKey.Key;
				sbyte slotIndex = (sbyte)enemyEquips.IndexOf(key);
				if (slotIndex >= 0)
				{
					enemyChar.ChangeEquipment(context, slotIndex, -1, ItemKey.Invalid);
				}
				enemyChar.RemoveInventoryItem(context, key, 1, deleteItem: false);
				lootItemList.Add(itemKey);
			}
			combatResultData.ItemList.Clear();
		}
		ExtraDomain.MergeKeyForItemDisplayDataList(lootItemList);
		taiwuChar.AddInventoryItem(context, lootItemList.Select((ItemDisplayData d) => d.Key).ToList(), EItemAutoOperationSource.Combat);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Item, lootItemList, arg2: false);
		return true;
	}

	[DomainMethod]
	public bool GmCmd_BuildingCollectPerform(DataContext context, int totalAttainment, short buildingTemplateId, int repeat)
	{
		BuildingBlockItem buildingConfig = BuildingBlock.Instance.GetItem(buildingTemplateId);
		if (buildingConfig == null || !buildingConfig.DependBuildings.CheckIndex(0))
		{
			return false;
		}
		BuildingBlockData dependency = new BuildingBlockData
		{
			TemplateId = buildingConfig.DependBuildings[0]
		};
		BuildingBlockItem dependencyConfig = BuildingBlock.Instance.GetItem(dependency.TemplateId);
		int totalCount = 0;
		sbyte resourceType = -1;
		for (sbyte i = 0; i < dependencyConfig.CollectResourcePercent.Length; i++)
		{
			if (dependencyConfig.CollectResourcePercent[i] > 0)
			{
				resourceType = i;
				break;
			}
		}
		List<ItemDisplayData> itemDisplayDataList = new List<ItemDisplayData>();
		for (int j = 0; j < repeat; j++)
		{
			BuildingProduceDependencyData dependencyData = BuildingProduceDependencyData.Invalid;
			dependencyData.Level = buildingConfig.MaxLevel;
			dependencyData.TemplateId = dependency.TemplateId;
			dependencyData.BlockBaseYieldFactor = BuildingBaseYield(dependency).Get(Math.Min(resourceType, 5));
			dependencyData.ResourceYieldLevelFactor = SharedMethods.GetBuildingLevelEffect(dependency.TemplateId, dependencyConfig.MaxLevel);
			dependencyData.ProductivityFactor = GlobalConfig.Instance.CollectResourceBuildingProductivityDistanceOne[0];
			dependencyData.TotalAttainmentFactor = totalAttainment;
			dependencyData.GainResourcePercentFactor = DomainManager.World.GetGainResourcePercent(4);
			dependencyData.ResourceSingleOutputValuation = dependencyData.ResourceBuildingOutput;
			totalCount += dependencyData.ResourceSingleOutputValuation;
			if (!SharedMethods.BuildingShopEventHaveItemList(buildingConfig))
			{
				continue;
			}
			ShopEventItem successShopEventConfig = Config.ShopEvent.Instance[buildingConfig.SuccesEvent[0]];
			List<TemplateKey> itemProbList = ObjectPool<List<TemplateKey>>.Instance.Get();
			itemProbList.Clear();
			int from = 0;
			int end = successShopEventConfig.ItemList.Count;
			if (successShopEventConfig.ResourceList.Count > 1)
			{
				end = successShopEventConfig.ItemList.Count / 2;
			}
			for (int k = from; k < end; k++)
			{
				int prob = successShopEventConfig.ItemList[k].Amount + totalAttainment / 30;
				if (context.Random.CheckPercentProb(prob))
				{
					PresetInventoryItem item = successShopEventConfig.ItemList[k];
					itemProbList.Add(new TemplateKey(item.Type, item.TemplateId));
				}
			}
			if (itemProbList.Count > 0)
			{
				TemplateKey itemTemplateKey = itemProbList[context.Random.Next(0, itemProbList.Count)];
				ItemKey itemKey = DomainManager.Item.CreateItem(context, itemTemplateKey.ItemType, itemTemplateKey.TemplateId);
				DomainManager.Taiwu.GetTaiwu().AddInventoryItem(context, itemKey, 1);
				int existItemIndex = itemDisplayDataList.FindIndex((ItemDisplayData data) => data.Key.Equals(itemKey));
				if (existItemIndex >= 0)
				{
					itemDisplayDataList[existItemIndex].Amount++;
				}
				else
				{
					ItemDisplayData itemDisplayData = DomainManager.Item.GetItemDisplayData(itemKey);
					itemDisplayDataList.Add(itemDisplayData);
				}
			}
			ObjectPool<List<TemplateKey>>.Instance.Return(itemProbList);
		}
		ItemDisplayData resourceDisplayData = new ItemDisplayData
		{
			Key = new ItemKey(12, 0, resourceType, -1),
			Amount = totalCount
		};
		itemDisplayDataList.Add(resourceDisplayData);
		DomainManager.Taiwu.GetTaiwu().ChangeResource(context, resourceType, totalCount);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Item, itemDisplayDataList, arg2: false);
		return true;
	}

	public void InitializeOwnedItems()
	{
		foreach (KeyValuePair<BuildingBlockKey, BuildingEarningsData> pair in _collectBuildingEarningsData)
		{
			if (!DomainManager.Building.TryGetElement_BuildingBlocks(pair.Key, out var blockData))
			{
				continue;
			}
			foreach (ItemKey itemKey in pair.Value.CollectionItemList)
			{
				DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Building, blockData.TemplateId);
			}
			foreach (ItemKey itemKey2 in pair.Value.ShopSoldItemList)
			{
				DomainManager.Item.SetOwner(itemKey2, ItemOwnerType.Building, blockData.TemplateId);
			}
			foreach (ItemKey itemKey3 in pair.Value.FixBookInfoList)
			{
				DomainManager.Item.SetOwner(itemKey3, ItemOwnerType.Building, blockData.TemplateId);
			}
		}
		for (int i = 0; i < _teaHorseCaravanData.CarryGoodsList.Count; i++)
		{
			ItemKey itemKey4 = _teaHorseCaravanData.CarryGoodsList[i].Item1;
			DomainManager.Item.SetOwner(itemKey4, ItemOwnerType.Building, 51);
		}
		for (int j = 0; j < _teaHorseCaravanData.ExchangeGoodsList.Count; j++)
		{
			ItemKey itemKey5 = _teaHorseCaravanData.ExchangeGoodsList[j];
			DomainManager.Item.SetOwner(itemKey5, ItemOwnerType.Building, 51);
		}
		List<CricketCollectionData> cricketCollectionDataList = DomainManager.Extra.GetCricketCollectionDataList();
		for (int k = 0; k < cricketCollectionDataList.Count; k++)
		{
			DomainManager.Item.SetOwner(cricketCollectionDataList[k].Cricket, ItemOwnerType.Building, 44);
			DomainManager.Item.SetOwner(cricketCollectionDataList[k].CricketJar, ItemOwnerType.Building, 44);
		}
		IReadOnlyDictionary<ulong, Feast> feasts = DomainManager.Extra.GetAllFeasts();
		foreach (Feast feast in feasts.Values)
		{
			for (int l = 0; l < GlobalConfig.Instance.FeastCount; l++)
			{
				ItemKey dish = feast.GetDish(l);
				if (dish.IsValid())
				{
					DomainManager.Item.SetOwner(dish, ItemOwnerType.Building, 47);
				}
			}
			for (int m = 0; m < GlobalConfig.Instance.FeastGiftCount; m++)
			{
				ItemKey gift = feast.GetGift(m);
				if (gift.Id >= 0)
				{
					DomainManager.Item.SetOwner(gift, ItemOwnerType.Building, 47);
				}
			}
		}
	}

	[DomainMethod]
	public unsafe MakeItemData StartMakeItem(DataContext context, StartMakeArguments startMakeArguments)
	{
		int charId = startMakeArguments.CharId;
		BuildingBlockKey buildingBlockKey = startMakeArguments.BuildingBlockKey;
		ItemDisplayData tool = startMakeArguments.Tool;
		ItemDisplayData material = startMakeArguments.Material;
		sbyte itemType = startMakeArguments.ItemType;
		List<short> itemList = startMakeArguments.ItemList;
		short makeItemSubTypeId = startMakeArguments.MakeItemSubTypeId;
		ResourceInts resourceCount = startMakeArguments.ResourceCount;
		ResourceInts needResource = startMakeArguments.NeedResource;
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		int makeCount = itemList.Count;
		if (tool.Key.IsValid())
		{
			sbyte grade = ItemTemplateHelper.GetGrade(material.Key.ItemType, material.Key.TemplateId);
			CraftToolItem toolConfig = Config.CraftTool.Instance[tool.Key.TemplateId];
			int cost = toolConfig.DurabilityCost[grade] * makeCount;
			DomainManager.Item.ReduceToolDurability(context, charId, tool.Key, cost, tool.ItemSourceType);
		}
		if (charId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			for (sbyte i = 0; i < 8; i++)
			{
				int value = needResource.Get(i);
				if (value > 0)
				{
					ConsumeResource(context, i, value);
				}
			}
		}
		else
		{
			needResource = needResource.GetReversed();
			character.ChangeResources(context, ref needResource);
		}
		DomainManager.Taiwu.RemoveItem(context, material.Key, makeCount, material.ItemSourceType, deleteItem: true);
		MaterialResources materialResources = default(MaterialResources);
		for (int j = 0; j < 6; j++)
		{
			materialResources.Items[j] = (short)resourceCount.Items[j];
		}
		short configTime = MakeItemSubType.Instance[makeItemSubTypeId].Time;
		short time = (short)(configTime * (makeCount / 3 + 1));
		MakeItemData makeItemData = new MakeItemData
		{
			ProductItemIdList = itemList,
			ProductItemType = itemType,
			LeftTime = time,
			ToolKey = tool.Key,
			MaterialKey = material.Key,
			MaterialResources = materialResources,
			EquipmentEffectId = startMakeArguments.EquipmentEffectId
		};
		AddElement_MakeItemDataDict(buildingBlockKey, makeItemData, context);
		for (int k = 0; k < makeCount; k++)
		{
			DomainManager.Taiwu.RecordLifeSummary(context, 66);
		}
		return makeItemData;
	}

	[DomainMethod]
	public unsafe bool CheckMakeCondition(MakeConditionArguments makeConditionArguments)
	{
		int charId = makeConditionArguments.CharId;
		BuildingBlockKey buildingBlockKey = makeConditionArguments.BuildingBlockKey;
		ItemKey toolKey = makeConditionArguments.ToolKey;
		ItemKey materialKey = makeConditionArguments.MaterialKey;
		short makeCount = makeConditionArguments.MakeCount;
		ResourceInts resourceCount = makeConditionArguments.ResourceCount;
		short makeItemSubTypeId = makeConditionArguments.MakeItemSubTypeId;
		bool isManual = makeConditionArguments.IsManual;
		bool isPerfect = makeConditionArguments.IsPerfect;
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		ResourceInts needResources = default(ResourceInts);
		for (int i = 0; i < 8; i++)
		{
			short amount = ItemTemplateHelper.GetCraftMaterialRequiredResourceAmount(materialKey.TemplateId);
			needResources.Items[i] = resourceCount.Items[i] * makeCount * amount;
		}
		if (!((charId == DomainManager.Taiwu.GetTaiwuCharId()) ? GetAllTaiwuResources() : character.GetResources()).CheckIsMeet(ref needResources))
		{
			return false;
		}
		sbyte grade = ItemTemplateHelper.GetGrade(materialKey.ItemType, materialKey.TemplateId);
		CraftToolItem toolConfig = Config.CraftTool.Instance[toolKey.TemplateId];
		short oneCost = toolConfig.DurabilityCost[grade];
		int totalCost = oneCost * makeCount;
		if (!CheckTool(toolKey, totalCost, oneCost, -1))
		{
			return false;
		}
		MaterialItem materialConfig = Config.Material.Instance[materialKey.TemplateId];
		int requirementReducePercent = 0;
		if (!buildingBlockKey.IsInvalid)
		{
			requirementReducePercent = GetBuildingEffectForMake(buildingBlockKey, materialConfig.RequiredLifeSkillType).attainmentEffect;
		}
		MakeItemSubTypeItem makeItemSubTypeConfig = MakeItemSubType.Instance[makeItemSubTypeId];
		sbyte itemType = makeItemSubTypeConfig.Result.ItemType;
		sbyte lifeSkillType = materialConfig.RequiredLifeSkillType;
		short totalAttainment = GetLifeSkillTotalAttainment(lifeSkillType, toolKey);
		List<short> makeItemSubTypes = MakeItemType.Instance[makeConditionArguments.MakeItemTypeId].MakeItemSubTypes;
		int allPagesReadCookingSkillBookCount = DomainManager.Taiwu.GetTaiwu().GetAllPagesReadCookingSkillBookCount();
		if (!CheckLifeSkill(requireAttainment: (makeItemSubTypes.Count > 1) ? GetMakeResult(materialConfig.TemplateId, toolKey, buildingBlockKey, lifeSkillType, makeItemSubTypes, makeItemSubTypeId, isPerfect, isManual).TargetResultStage.LifeSkillRequiredAttainment : ((itemType != 7) ? GetMakeResult(materialConfig.TemplateId, toolKey, buildingBlockKey, lifeSkillType, makeItemSubTypes, -1, isPerfect, isManual).TargetResultStage.LifeSkillRequiredAttainment : SharedMethods.GetMaterialGradeAndAttainment(materialKey.TemplateId, itemType, lifeSkillType, totalAttainment, makeItemSubTypes, out var _, out var _, allPagesReadCookingSkillBookCount, makeItemSubTypeId, requirementReducePercent, isPerfect, isManual, makeConditionArguments.ManulFoodTemplateId)), lifeSkillType: materialConfig.RequiredLifeSkillType, toolKey: toolKey))
		{
			return false;
		}
		return true;
	}

	[DomainMethod]
	public void TryShowNotifications()
	{
		if (_outsideMakeItem)
		{
			DomainManager.World.GetInstantNotifications().AddMakeItemOutsideSettlement();
			_outsideMakeItem = false;
		}
	}

	[DomainMethod]
	public List<ItemDisplayData> GetMakeItems(DataContext context, BuildingBlockKey buildingBlockKey)
	{
		MakeItemData makeData = GetElement_MakeItemDataDict(buildingBlockKey);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		List<ItemDisplayData> displayDatas = new List<ItemDisplayData>();
		RemoveElement_MakeItemDataDict(buildingBlockKey, context);
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		Location location = taiwuChar.GetLocation();
		bool isInSettlement = false;
		if (location == taiwuVillageLocation)
		{
			isInSettlement = true;
		}
		else
		{
			MapBlockData blockData = DomainManager.Map.GetBlock(location);
			if (blockData.IsCityTown())
			{
				isInSettlement = true;
			}
		}
		sbyte playerEffectFactor = 2;
		Dictionary<short, int> productItemDict = new Dictionary<short, int>();
		foreach (short productItemId in makeData.ProductItemIdList)
		{
			ItemKey productItemKey = makeData.ProductItemType switch
			{
				0 => DomainManager.Item.CreateWeapon(context, productItemId, playerEffectFactor), 
				1 => DomainManager.Item.CreateArmor(context, productItemId, playerEffectFactor), 
				2 => DomainManager.Item.CreateAccessory(context, productItemId, playerEffectFactor), 
				_ => DomainManager.Item.CreateItem(context, makeData.ProductItemType, productItemId), 
			};
			ItemBase productItem = DomainManager.Item.GetBaseItem(productItemKey);
			if (ItemType.IsEquipmentItemType(productItemKey.ItemType))
			{
				EquipmentBase equipItem = DomainManager.Item.GetBaseEquipment(productItemKey);
				equipItem.SetMaterialResources(makeData.MaterialResources, context);
				if (ItemType.IsEquipmentEffectType(productItemKey.ItemType) && makeData.EquipmentEffectId >= 0)
				{
					EquipmentEffectItem effectConfig = EquipmentEffect.Instance[makeData.EquipmentEffectId];
					sbyte type = effectConfig.Type;
					if (1 == 0)
					{
					}
					bool flag;
					switch (type)
					{
					case 0:
					{
						sbyte itemType = productItemKey.ItemType;
						bool flag2 = (uint)itemType <= 2u;
						flag = flag2;
						break;
					}
					case 1:
						flag = productItemKey.ItemType == 0;
						break;
					case 2:
						flag = productItemKey.ItemType == 1;
						break;
					default:
						flag = false;
						break;
					}
					if (1 == 0)
					{
					}
					bool isTypeMeet = flag;
					if (!effectConfig.Special && isTypeMeet)
					{
						equipItem.ApplyDurabilityEquipmentEffectChange(context, equipItem.GetEquipmentEffectId(), makeData.EquipmentEffectId);
						equipItem.SetEquipmentEffectId(makeData.EquipmentEffectId, context);
						equipItem.SetCurrDurability(equipItem.GetMaxDurability(), context);
					}
				}
			}
			if (productItem.GetStackable())
			{
				if (!productItemDict.TryGetValue(productItemId, out var amount))
				{
					productItemDict.Add(productItemId, 1);
					displayDatas.Add(DomainManager.Item.GetItemDisplayData(productItem, 1, DomainManager.Taiwu.GetTaiwuCharId(), -1));
				}
				else
				{
					ItemDisplayData displayData = displayDatas.Find((ItemDisplayData d) => d.Key.TemplateId == productItemId);
					if (displayData != null)
					{
						displayData.Amount = amount + 1;
						productItemDict[productItemId] = displayData.Amount;
					}
				}
			}
			else
			{
				displayDatas.Add(DomainManager.Item.GetItemDisplayData(productItem, 1, DomainManager.Taiwu.GetTaiwuCharId(), -1));
			}
			ItemSourceType itemSource = ItemSourceType.Inventory;
			if (ItemTemplateHelper.IsTransferable(productItemKey.ItemType, productItemKey.TemplateId))
			{
				itemSource = DomainManager.Extra.GetBuildingDefaultStoreLocation().GetMakeType(-1);
				if (itemSource == ItemSourceType.Inventory && !DomainManager.Taiwu.CanTransferItemToWarehouse(context))
				{
					itemSource = ItemSourceType.Warehouse;
					_outsideMakeItem = true;
				}
			}
			DomainManager.Taiwu.AddItem(context, productItemKey, 1, itemSource);
			if (productItem.GetGrade() >= DomainManager.World.GetXiangshuLevel())
			{
				DomainManager.Taiwu.AddLegacyPoint(context, 30);
			}
			sbyte skillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(productItemKey.ItemType, productItemKey.TemplateId);
			if (((uint)(skillType - 6) <= 1u || (uint)(skillType - 10) <= 1u) ? true : false)
			{
				int seniority = ProfessionFormulaImpl.Calculate(16, productItem.GetGrade());
				DomainManager.Extra.ChangeProfessionSeniority(context, 2, seniority);
			}
			if (ItemTemplateHelper.GetItemSubType(productItemKey.ItemType, productItemKey.TemplateId) == 800)
			{
				sbyte grade = ItemTemplateHelper.GetGrade(productItemKey.ItemType, productItemKey.TemplateId);
				int seniority2 = ProfessionFormulaImpl.Calculate(83, grade);
				DomainManager.Extra.ChangeProfessionSeniority(context, 13, seniority2);
			}
			if (productItem.GetGrade() != 8)
			{
				continue;
			}
			short key = -1;
			if (ItemType.IsEquipmentItemType(productItem.GetItemType()))
			{
				sbyte resourceType = productItem.GetResourceType();
				if (1 == 0)
				{
				}
				short num = resourceType switch
				{
					2 => 24, 
					1 => 25, 
					4 => 26, 
					3 => 27, 
					_ => -1, 
				};
				if (1 == 0)
				{
				}
				key = num;
			}
			else if (productItem.GetItemSubType() == 800)
			{
				key = 28;
			}
			else if (productItem.GetItemSubType() == 801)
			{
				key = 29;
			}
			else if (productItem.GetItemType() == 7)
			{
				key = 30;
			}
			if (key >= 0)
			{
				AchievementManager.RequestSetStat(context, key, 1);
			}
		}
		return displayDatas;
	}

	[DomainMethod]
	public MakeItemData GetMakingItemData(BuildingBlockKey buildingBlockKey)
	{
		_makeItemDataDict.TryGetValue(buildingBlockKey, out var data);
		return data;
	}

	public void UpdateMakingProgressOnMonthChange(DataContext context)
	{
		foreach (KeyValuePair<BuildingBlockKey, MakeItemData> makeItem in _makeItemDataDict)
		{
			if (makeItem.Value.LeftTime != 0)
			{
				BuildingBlockData blockData = _buildingBlocks[makeItem.Key];
				if (blockData.CanUse() && AllDependBuildingAvailable(makeItem.Key, blockData.TemplateId, out var _))
				{
					makeItem.Value.LeftTime--;
					SetElement_MakeItemDataDict(makeItem.Key, makeItem.Value, context);
				}
			}
		}
	}

	[DomainMethod]
	public MakeResult GetMakeResult(short materialTemplateId, ItemKey toolKey, BuildingBlockKey buildingBlockKey, sbyte lifeSkillType, List<short> makeItemSubtypeIdList, short makeItemSubTypeId, bool isPerfect, bool isManual)
	{
		MakeItemSubTypeItem makeItemSubTypeConfig = MakeItemSubType.Instance[makeItemSubtypeIdList.First()];
		sbyte itemType = makeItemSubTypeConfig.Result.ItemType;
		(int attainmentEffect, bool upgradeMakeItem) buildingEffectForMake = GetBuildingEffectForMake(buildingBlockKey, lifeSkillType);
		int attainmentEffect = buildingEffectForMake.attainmentEffect;
		bool upgradeMakeItem = buildingEffectForMake.upgradeMakeItem;
		short totalAttainment = GetLifeSkillTotalAttainment(lifeSkillType, toolKey);
		int allPagesReadCookingSkillBookCount = DomainManager.Taiwu.GetTaiwu().GetAllPagesReadCookingSkillBookCount();
		sbyte grade;
		short baseRequiredAttainment;
		short requiredAttainment = SharedMethods.GetMaterialGradeAndAttainment(materialTemplateId, itemType, lifeSkillType, totalAttainment, makeItemSubtypeIdList, out grade, out baseRequiredAttainment, allPagesReadCookingSkillBookCount, makeItemSubTypeId, attainmentEffect, isPerfect, isManual, -1);
		GetMakeResultStageArray(materialTemplateId, grade, requiredAttainment, totalAttainment, makeItemSubtypeIdList, attainmentEffect, lifeSkillType, out var resultIndex, out var makeResultStageArray, makeItemSubTypeId, isManual, isPerfect, upgradeMakeItem);
		short upgradeBuildingName = -1;
		BuildingBlock.Instance.Iterate(delegate(BuildingBlockItem item)
		{
			if (item.UpgradeMakeItem && item.RequireLifeSkillType == lifeSkillType)
			{
				upgradeBuildingName = item.TemplateId;
				return false;
			}
			return true;
		});
		return new MakeResult(resultIndex, makeResultStageArray, upgradeBuildingName, upgradeMakeItem);
	}

	private void GetMakeResultStageArray(short materialTemplateId, sbyte grade, int requiredAttainment, int totalAttainment, List<short> makeItemSubtypeIdList, int attainmentEffect, sbyte lifeSkillType, out int resultIndex, out MakeResultStage[] makeResultStageArray, short makeItemSubTypeId = -1, bool makeIsManual = false, bool makeIsPerfect = false, bool upgradeMakeItem = false)
	{
		bool checkOne = makeIsManual || makeItemSubtypeIdList.Count == 1;
		if (makeItemSubTypeId == -1)
		{
			makeItemSubTypeId = makeItemSubtypeIdList.First();
		}
		MakeItemSubTypeItem makeItemSubTypeConfig = MakeItemSubType.Instance[makeItemSubTypeId];
		sbyte itemType = makeItemSubTypeConfig.Result.ItemType;
		short subTypeExtraLifeSkill = 0;
		if (makeIsManual)
		{
			subTypeExtraLifeSkill = (short)(makeItemSubTypeConfig.ExtraLifeSkill * (grade + 1));
		}
		makeResultStageArray = new MakeResultStage[3];
		resultIndex = 0;
		for (int i = 0; i < 3; i++)
		{
			sbyte tempGrade = grade;
			SharedMethods.GetStageRequirementAndGrade(i, tempGrade, itemType, requiredAttainment, subTypeExtraLifeSkill, out var targetGrade, out var finalRequirement);
			finalRequirement = Math.Max(0, finalRequirement);
			bool lifeSkillIsMeet = totalAttainment >= finalRequirement;
			bool addStage;
			if (checkOne)
			{
				sbyte baseGrade = ItemTemplateHelper.GetGrade(itemType, makeItemSubTypeConfig.Result.TemplateId);
				(bool, sbyte, short) finalGradeAndId = SharedMethods.GetFinalGradeAndId(baseGrade, targetGrade, makeItemSubTypeConfig.Result.ItemType, makeItemSubTypeConfig.Result.TemplateId);
				bool success = finalGradeAndId.Item1;
				sbyte finalGrade = finalGradeAndId.Item2;
				short finialTemplateId = finalGradeAndId.Item3;
				bool exist = makeResultStageArray.Exist((MakeResultStage s) => s.IsInit && s.TemplateId == finialTemplateId);
				addStage = success && !exist;
				if (addStage)
				{
					makeResultStageArray[i] = new MakeResultStage(finalRequirement, lifeSkillIsMeet, itemType, finialTemplateId, makeItemSubTypeId);
				}
			}
			else
			{
				List<short> templateIdList = new List<short>();
				List<short> subTypeIdList = new List<short>();
				foreach (short subTypeId in makeItemSubtypeIdList)
				{
					MakeItemSubTypeItem subTypeConfig = MakeItemSubType.Instance[subTypeId];
					if (itemType == 8 && lifeSkillType == 8)
					{
						SharedMethods.GetMaterialGradeAndAttainment(materialTemplateId, itemType, lifeSkillType, totalAttainment, makeItemSubtypeIdList, out grade, out var _, 0, subTypeId, attainmentEffect, makeIsPerfect, isManul: true, -1);
					}
					tempGrade = grade;
					SharedMethods.GetStageRequirementAndGrade(i, tempGrade, itemType, requiredAttainment, subTypeExtraLifeSkill, out var targetGradeMore, out var _);
					sbyte tempBaseGrade = ItemTemplateHelper.GetGrade(itemType, subTypeConfig.Result.TemplateId);
					(bool, sbyte, short) finalGradeAndId = SharedMethods.GetFinalGradeAndId(tempBaseGrade, targetGradeMore, subTypeConfig.Result.ItemType, subTypeConfig.Result.TemplateId);
					bool success2 = finalGradeAndId.Item1;
					sbyte finalGrade2 = finalGradeAndId.Item2;
					short finialTemplateId2 = finalGradeAndId.Item3;
					bool exist2 = makeResultStageArray.Exist((MakeResultStage s) => s.IsInit && s.TemplateIdList != null && s.TemplateIdList.Contains(finialTemplateId2));
					if (success2 && !exist2)
					{
						templateIdList.Add(finialTemplateId2);
						subTypeIdList.Add(subTypeId);
					}
				}
				addStage = templateIdList.Count > 0;
				if (addStage)
				{
					makeResultStageArray[i] = new MakeResultStage(finalRequirement, lifeSkillIsMeet, itemType, templateIdList, subTypeIdList);
				}
			}
			if (addStage && lifeSkillIsMeet && (i < 2 || (upgradeMakeItem && i == 2)))
			{
				resultIndex = i;
			}
		}
	}

	public (sbyte grade, short templateId) GetMakeResultTargetItemGradeAndTemplateId(short materialTemplateId, short totalAttainment, sbyte lifeSkillType, List<short> makeItemSubtypeIdList, short makeItemSubTypeId, int allPagesReadCookingSkillBookCount, IRandomSource randomSource, bool upgradeMakeItem, int attainmentEffect)
	{
		MakeItemSubTypeItem makeItemSubTypeConfig = MakeItemSubType.Instance[makeItemSubTypeId];
		sbyte itemType = makeItemSubTypeConfig.Result.ItemType;
		sbyte grade;
		short baseRequiredAttainment;
		short requiredAttainment = SharedMethods.GetMaterialGradeAndAttainment(materialTemplateId, itemType, lifeSkillType, totalAttainment, makeItemSubtypeIdList, out grade, out baseRequiredAttainment, allPagesReadCookingSkillBookCount, makeItemSubTypeId, attainmentEffect, isPerfect: false, isManul: false, -1);
		GetMakeResultStageArray(materialTemplateId, grade, requiredAttainment, totalAttainment, makeItemSubtypeIdList, attainmentEffect, lifeSkillType, out var resultIndex, out var makeResultStageArray, makeItemSubTypeId, makeIsManual: false, upgradeMakeItem);
		MakeResultStage stage = makeResultStageArray[resultIndex];
		return ((sbyte grade, short templateId))(stage.LifeSkillIsMeet ? (((int grade, int templateId))stage.GetGradeAndId(randomSource)) : (grade: 0, templateId: -1));
	}

	[DomainMethod]
	public ItemDisplayData[] RepairItemsOptional(DataContext context, int charId, ItemDisplayData[] tools, ItemDisplayData[] equipments)
	{
		return (from x in tools.Zip(equipments, (ItemDisplayData t, ItemDisplayData e) => (t.RealKey.ItemType == 6 && e.RealKey.IsValid()) ? RepairItemOptional(context, charId, t.RealKey, e.RealKey, t.ItemSourceType) : null)
			where x != null
			select x).ToArray();
	}

	[DomainMethod]
	public ItemDisplayData RepairItemOptional(DataContext context, int charId, ItemKey toolKey, ItemKey itemKey, sbyte toolSourceType)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
		short durability = item.GetCurrDurability();
		sbyte grade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
		if (toolKey.IsValid() && toolKey.TemplateId != 54)
		{
			CraftToolItem toolConfig = Config.CraftTool.Instance[toolKey.TemplateId];
			short cost = toolConfig.DurabilityCost[grade];
			DomainManager.Item.ReduceToolDurability(context, charId, toolKey, cost, toolSourceType);
		}
		EquipmentBase equip = DomainManager.Item.GetBaseEquipment(itemKey);
		ResourceInts needResources = ItemTemplateHelper.GetRepairNeedResources(equip.GetMaterialResources(), itemKey, durability);
		if (charId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			for (sbyte i = 0; i < 8; i++)
			{
				int value = needResources.Get(i);
				if (value > 0)
				{
					ConsumeResource(context, i, value);
				}
			}
		}
		else
		{
			needResources = needResources.GetReversed();
			character.ChangeResources(context, ref needResources);
		}
		sbyte skillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(itemKey.ItemType, itemKey.TemplateId);
		if (((uint)(skillType - 6) <= 1u || (uint)(skillType - 10) <= 1u) ? true : false)
		{
			int seniority = ((item.GetCurrDurability() > 0) ? ProfessionFormulaImpl.Calculate(18, grade, item.GetCurrDurability(), item.GetMaxDurability()) : ProfessionFormulaImpl.Calculate(19, grade));
			DomainManager.Extra.ChangeProfessionSeniority(context, 2, seniority);
		}
		item.SetCurrDurability(item.GetMaxDurability(), context);
		return DomainManager.Item.GetItemDisplayData(item, charId, -1, -1);
	}

	[DomainMethod]
	public List<ItemDisplayData> RepairItemList(DataContext context, int charId, List<MultiplyOperation> operationList)
	{
		List<ItemDisplayData> dataList = new List<ItemDisplayData>();
		foreach (MultiplyOperation operation in operationList)
		{
			for (int i = 0; i < operation.Count; i++)
			{
				ItemDisplayData result = RepairItemOptional(context, charId, operation.Tool, operation.Target, operation.ToolItemSourceType);
				dataList.Add(result);
			}
		}
		return dataList;
	}

	[DomainMethod]
	public bool CheckRepairConditionIsMeet(int charId, ItemKey toolKey, ItemKey itemKey, BuildingBlockKey buildingBlockKey)
	{
		if (!DomainManager.Item.CheckItemNeedRepair(itemKey))
		{
			return false;
		}
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
		sbyte grade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
		CraftToolItem toolConfig = Config.CraftTool.Instance[toolKey.TemplateId];
		short cost = toolConfig.DurabilityCost[grade];
		if (!CheckTool(toolKey, cost, cost, -1))
		{
			return false;
		}
		EquipmentBase equip = DomainManager.Item.GetBaseEquipment(itemKey);
		ResourceInts needResources = ItemTemplateHelper.GetRepairNeedResources(equip.GetMaterialResources(), itemKey, item.GetCurrDurability());
		if (!((charId == DomainManager.Taiwu.GetTaiwuCharId()) ? GetAllTaiwuResources() : character.GetResources()).CheckIsMeet(ref needResources))
		{
			return false;
		}
		sbyte requiredLifeSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(itemKey.ItemType, itemKey.TemplateId);
		int requireAttainment = ItemTemplateHelper.GetRepairRequiredAttainment(itemKey.ItemType, itemKey.TemplateId, item.GetCurrDurability());
		if (!buildingBlockKey.IsInvalid)
		{
			int attainmentEffect = GetBuildingEffectForMake(buildingBlockKey, requiredLifeSkillType).attainmentEffect;
			requireAttainment = SharedMethods.GetRequiredLifeSkillAttainmentByBuildingEffect(requireAttainment, attainmentEffect);
		}
		requireAttainment = Math.Max(0, requireAttainment);
		return CheckLifeSkill(requiredLifeSkillType, requireAttainment, toolKey);
	}

	[DomainMethod]
	public (bool, ItemDisplayData) AddItemPoison(DataContext context, int charId, ItemDisplayData tool, ItemDisplayData target, ItemDisplayData[] poisons, List<ItemDisplayData> condensePoisonItemList)
	{
		ItemKey targetKey = target.Key;
		ItemBase targetBaseItem = DomainManager.Item.GetBaseItem(targetKey);
		CraftToolItem toolConfig = Config.CraftTool.Instance[tool.Key.TemplateId];
		FullPoisonEffects poisonEffects = DomainManager.Item.GetPoisonEffects(targetKey);
		if (ModificationStateHelper.IsActive(targetKey.ModificationState, 1) && poisonEffects.IsValid && !poisonEffects.IsIdentified && !ItemType.IsEquipmentItemType(targetKey.ItemType))
		{
			return (false, new ItemDisplayData());
		}
		short durabilityCost = 0;
		ItemBase resultItems = targetBaseItem;
		List<short> condensedMedicineTemplateIdList = new List<short>();
		for (int i = 0; i < poisons.Length; i++)
		{
			ItemDisplayData poison = poisons[i];
			if (poison == null || !poison.Key.HasTemplate)
			{
				continue;
			}
			MedicineItem poisonMedicineConfig = Config.Medicine.Instance[poison.Key.TemplateId];
			sbyte grade = poisonMedicineConfig.Grade;
			PoisonSlot slot = poisonEffects.PoisonSlotList?.GetOrDefault(i);
			sbyte slotPoisonGrade = slot?.MedicineConfig?.Grade ?? (-1);
			bool needKeepOldCondenseData = poisonMedicineConfig.Grade <= slotPoisonGrade && (slot?.IsCondensed ?? false);
			condensedMedicineTemplateIdList.Clear();
			if (condensePoisonItemList != null && condensePoisonItemList.Count > 0)
			{
				foreach (ItemDisplayData itemData in condensePoisonItemList)
				{
					MedicineItem condensedMedicineConfig = Config.Medicine.Instance[itemData.Key.TemplateId];
					if (condensedMedicineConfig.PoisonType == poisonMedicineConfig.PoisonType)
					{
						condensedMedicineTemplateIdList.Add(condensedMedicineConfig.TemplateId);
					}
				}
			}
			if (condensedMedicineTemplateIdList.Count > 0)
			{
				sbyte condensedGrade = condensedMedicineTemplateIdList.Max((short m) => ItemTemplateHelper.GetGrade(8, m));
				grade = Math.Max(grade, condensedGrade);
			}
			else if (needKeepOldCondenseData)
			{
				condensedMedicineTemplateIdList.AddRange(slot.CondensedMedicineTemplateIdList);
			}
			if (condensedMedicineTemplateIdList.Count > 0 || poison.Key.IsValid())
			{
				short cost = toolConfig.DurabilityCost[grade];
				durabilityCost = Math.Max(durabilityCost, cost);
			}
			if (!poison.Key.IsValid())
			{
				slot?.SetPoison(poison.Key.TemplateId, condensedMedicineTemplateIdList);
				continue;
			}
			(ItemBase item, bool keyChanged) tuple = DomainManager.Item.SetAttachedPoisons(context, targetBaseItem, poison.Key.TemplateId, add: true, condensedMedicineTemplateIdList);
			ItemBase newItemObj = tuple.item;
			bool keyChanged = tuple.keyChanged;
			resultItems = newItemObj;
			if (keyChanged)
			{
				ItemKey oldKey = targetKey;
				ItemKey newKey = newItemObj.GetItemKey();
				ChangeItem(context, oldKey, target.ItemSourceType, newKey, charId);
				targetKey = newItemObj.GetItemKey();
				targetBaseItem = newItemObj;
			}
			DomainManager.Taiwu.RemoveItem(context, poison.Key, 1, poison.ItemSourceType, deleteItem: true);
		}
		DomainManager.Item.SetPoisonsIdentified(context, resultItems.GetItemKey(), isIdentified: true);
		if (tool.Key.IsValid())
		{
			DomainManager.Item.ReduceToolDurability(context, charId, tool.Key, durabilityCost, tool.ItemSourceType);
		}
		if (condensePoisonItemList != null && condensePoisonItemList.Count > 0)
		{
			foreach (ItemDisplayData data in condensePoisonItemList)
			{
				DomainManager.Taiwu.RemoveItem(context, data.Key, 1, data.ItemSourceType, deleteItem: true);
			}
		}
		return (true, DomainManager.Item.GetItemDisplayData(resultItems, 1, charId, target.ItemSourceType));
	}

	[DomainMethod]
	public bool CheckAddPoisonCondition(int charId, ItemKey toolKey, ItemKey targetKey, ItemKey[] poisonKeys, BuildingBlockKey buildingBlockKey, FullPoisonEffects tempPoisonEffects)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		if (!DomainManager.Item.GetBaseItem(targetKey).GetPoisonable())
		{
			return false;
		}
		FullPoisonEffects poisonEffects = DomainManager.Item.GetPoisonEffects(targetKey);
		if (poisonEffects.SameOf(tempPoisonEffects) && (!poisonEffects.IsValid || poisonEffects.IsIdentified))
		{
			return false;
		}
		CraftToolItem toolConfig = Config.CraftTool.Instance[toolKey.TemplateId];
		int requireAttainment = 0;
		short durabilityCost = 0;
		for (int index = 0; index < poisonKeys.Length; index++)
		{
			ItemKey poisonKey = poisonKeys[index];
			if (!poisonKey.HasTemplate)
			{
				continue;
			}
			short attainment = ItemTemplateHelper.GetPoisonRequiredAttainment(8, poisonKey.TemplateId);
			bool isCondensed = tempPoisonEffects.PoisonSlotList.CheckIndex(index) && tempPoisonEffects.PoisonSlotList[index].IsCondensed;
			if (isCondensed)
			{
				short condensedAttainment = tempPoisonEffects.PoisonSlotList[index].CondensedMedicineTemplateIdList.Max((short m) => ItemTemplateHelper.GetPoisonRequiredAttainment(8, m));
				int bonus = GlobalConfig.Instance.CondensePoisonRequiredAttainmentBonus;
				condensedAttainment = Convert.ToInt16(condensedAttainment * (100 + bonus) / 100);
				attainment = Math.Max(attainment, condensedAttainment);
			}
			sbyte grade = ItemTemplateHelper.GetGrade(8, poisonKey.TemplateId);
			if (isCondensed)
			{
				sbyte condensedGrade = tempPoisonEffects.PoisonSlotList[index].CondensedMedicineTemplateIdList.Max((short m) => ItemTemplateHelper.GetGrade(8, m));
				grade = Math.Max(grade, condensedGrade);
			}
			if (isCondensed || poisonKey.IsValid())
			{
				requireAttainment = Math.Max(attainment, requireAttainment);
				short cost = toolConfig.DurabilityCost[grade];
				durabilityCost = Math.Max(durabilityCost, cost);
			}
		}
		if (!CheckTool(toolKey, durabilityCost, durabilityCost, 9))
		{
			return false;
		}
		if (!buildingBlockKey.IsInvalid)
		{
			int attainmentEffect = GetBuildingEffectForMake(buildingBlockKey, 9).attainmentEffect;
			requireAttainment = SharedMethods.GetRequiredLifeSkillAttainmentByBuildingEffect(requireAttainment, attainmentEffect);
		}
		if (!CheckLifeSkill(9, requireAttainment, toolKey))
		{
			return false;
		}
		return true;
	}

	[DomainMethod]
	public (bool, List<ItemDisplayData>) RemoveItemPoison(DataContext context, int charId, ItemDisplayData tool, ItemDisplayData target, ItemDisplayData[] medicines, bool isExtract)
	{
		List<ItemDisplayData> resultItemList = new List<ItemDisplayData>();
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		ItemKey[] equipment = character.GetEquipment();
		ItemKey targetKey = target.Key;
		ItemBase targetBaseItem = DomainManager.Item.GetBaseItem(targetKey);
		List<short> poisonMedicineIds = target.PoisonEffects.GetAllMedicineTemplateIds();
		CraftToolItem toolConfig = Config.CraftTool.Instance[tool.Key.TemplateId];
		List<ItemDisplayData> finialMedicineIdList = new List<ItemDisplayData>();
		foreach (ItemDisplayData medicine in medicines)
		{
			if (medicine == null || !medicine.Key.IsValid() || poisonMedicineIds.Contains(medicine.Key.TemplateId))
			{
				continue;
			}
			MedicineItem config = Config.Medicine.Instance[medicine.Key.TemplateId];
			if (poisonMedicineIds.Exist((short id) => id > -1 && Config.Medicine.Instance[id].PoisonType == config.PoisonType))
			{
				if (medicine.HasAnyPoison && !medicine.PoisonIsIdentified)
				{
					resultItemList.Add(new ItemDisplayData());
					return (false, resultItemList);
				}
				finialMedicineIdList.Add(medicine);
			}
		}
		List<short> addedMedicineList = null;
		if (isExtract)
		{
			addedMedicineList = new List<short>();
		}
		ItemBase resultItem = null;
		short durabilityCost = 0;
		foreach (ItemDisplayData medicine2 in finialMedicineIdList)
		{
			MedicineItem config2 = Config.Medicine.Instance[medicine2.Key.TemplateId];
			short targetPoisonId = poisonMedicineIds.Find((short id) => id > -1 && Config.Medicine.Instance[id].PoisonType == config2.PoisonType);
			(ItemBase item, bool keyChanged) tuple = DomainManager.Item.SetAttachedPoisons(context, targetBaseItem, targetPoisonId, add: false);
			ItemBase newItemObj = tuple.item;
			bool keyChanged = tuple.keyChanged;
			resultItem = newItemObj;
			if (keyChanged)
			{
				ItemKey oldKey = targetKey;
				ItemKey newKey = newItemObj.GetItemKey();
				ChangeItem(context, oldKey, target.ItemSourceType, newKey, charId);
				targetKey = newItemObj.GetItemKey();
				targetBaseItem = newItemObj;
			}
			DomainManager.Taiwu.RemoveItem(context, medicine2.Key, 1, medicine2.ItemSourceType, deleteItem: true);
			sbyte grade = ItemTemplateHelper.GetGrade(8, targetPoisonId);
			short cost = toolConfig.DurabilityCost[grade];
			durabilityCost = Math.Max(durabilityCost, cost);
			if (isExtract)
			{
				addedMedicineList.Add(targetPoisonId);
				PoisonSlot targetSlot = target.PoisonEffects.PoisonSlotList.Find((PoisonSlot s) => s.MedicineTemplateId == targetPoisonId);
				if (targetSlot.IsCondensed)
				{
					addedMedicineList.AddRange(targetSlot.CondensedMedicineTemplateIdList);
				}
			}
			int seniority = ProfessionFormulaImpl.Calculate(85, grade);
			DomainManager.Extra.ChangeProfessionSeniority(context, 13, seniority);
		}
		if (tool.Key.IsValid())
		{
			DomainManager.Item.ReduceToolDurability(context, charId, tool.Key, durabilityCost, tool.ItemSourceType);
		}
		ItemDisplayData resultItemData = DomainManager.Item.GetItemDisplayData(resultItem, 1, charId, target.ItemSourceType);
		resultItemList.Add(resultItemData);
		if (isExtract)
		{
			foreach (short templateId in addedMedicineList)
			{
				ItemKey itemKey = DomainManager.Item.CreateItem(context, 8, templateId);
				DomainManager.Taiwu.AddItem(context, itemKey, 1, target.ItemSourceTypeEnum);
				ItemBase itemBase = DomainManager.Item.GetBaseItem(itemKey);
				int findIndex = resultItemList.FindIndex((ItemDisplayData d) => d.Key.Equals(itemKey));
				if (findIndex >= 0)
				{
					resultItemList[findIndex].Amount++;
					continue;
				}
				ItemDisplayData itemData = DomainManager.Item.GetItemDisplayData(itemBase, 1, charId, target.ItemSourceType);
				resultItemList.Add(itemData);
			}
		}
		return (true, resultItemList);
	}

	[DomainMethod]
	public bool CheckRemovePoisonCondition(int charId, ItemKey toolKey, ItemKey targetKey, ItemKey[] medicineKeys, BuildingBlockKey buildingBlockKey, bool isExtract)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		CraftToolItem toolConfig = Config.CraftTool.Instance[toolKey.TemplateId];
		short durabilityCost = 0;
		FullPoisonEffects poisonEffect = DomainManager.Item.GetPoisonEffects(targetKey);
		for (int index = 0; index < medicineKeys.Length; index++)
		{
			ItemKey medicineKey = medicineKeys[index];
			if (medicineKey.IsValid())
			{
				short poisonId = poisonEffect.GetMedicineTemplateIdAt(index);
				sbyte medicineGrade = ItemTemplateHelper.GetGrade(medicineKey.ItemType, medicineKey.TemplateId);
				sbyte poisonGrade = ItemTemplateHelper.GetGrade(8, poisonId);
				short cost = toolConfig.DurabilityCost[poisonGrade];
				durabilityCost = Math.Max(durabilityCost, cost);
				if (!poisonEffect.IsValid || medicineGrade < poisonGrade)
				{
					return false;
				}
				int requireAttainment = ItemTemplateHelper.GetPoisonRequiredAttainment(8, poisonId);
				if (isExtract)
				{
					int bonus = GlobalConfig.Instance.CondensePoisonRequiredAttainmentBonus;
					requireAttainment = Convert.ToInt16(requireAttainment * (100 + bonus) / 100);
				}
				if (!buildingBlockKey.IsInvalid)
				{
					int attainmentEffect = GetBuildingEffectForMake(buildingBlockKey, 9).attainmentEffect;
					requireAttainment = SharedMethods.GetRequiredLifeSkillAttainmentByBuildingEffect(requireAttainment, attainmentEffect);
				}
				if (!CheckLifeSkill(9, requireAttainment, toolKey))
				{
					return false;
				}
			}
		}
		if (!CheckTool(toolKey, durabilityCost, durabilityCost, 9))
		{
			return false;
		}
		return true;
	}

	public bool RemoveItemPoison(DataContext context, GameData.Domains.Character.Character character, ItemKey targetItemKey, ItemKey medicineItemKey)
	{
		if (!targetItemKey.IsValid() || !medicineItemKey.IsValid())
		{
			return false;
		}
		ItemDisplayData medicine = DomainManager.Item.GetItemDisplayData(medicineItemKey);
		ItemDisplayData target = DomainManager.Item.GetItemDisplayData(targetItemKey);
		if (medicine == null || target == null)
		{
			return false;
		}
		List<short> poisonMedicineIds = target.PoisonEffects.GetAllMedicineTemplateIds();
		if (poisonMedicineIds.Contains(medicine.Key.TemplateId))
		{
			return false;
		}
		MedicineItem config = Config.Medicine.Instance[medicine.Key.TemplateId];
		if (!poisonMedicineIds.Exist((short id) => id > -1 && Config.Medicine.Instance[id].PoisonType == config.PoisonType))
		{
			return false;
		}
		if (medicine.HasAnyPoison && !medicine.PoisonIsIdentified)
		{
			return false;
		}
		short targetPoisonId = poisonMedicineIds.Find((short id) => id > -1 && Config.Medicine.Instance[id].PoisonType == config.PoisonType);
		ItemBase targetBaseItem = DomainManager.Item.GetBaseItem(targetItemKey);
		(ItemBase item, bool keyChanged) tuple = DomainManager.Item.SetAttachedPoisons(context, targetBaseItem, targetPoisonId, add: false);
		var (newItemObj, _) = tuple;
		if (tuple.keyChanged)
		{
			ItemKey oldKey = targetItemKey;
			ItemKey newKey = newItemObj.GetItemKey();
			DomainManager.Building.ChangeItem(context, oldKey, target.ItemSourceType, newKey, character.GetId());
		}
		DomainManager.Taiwu.RemoveItem(context, medicine.Key, 1, medicine.ItemSourceType, deleteItem: true);
		return true;
	}

	[DomainMethod]
	public ItemDisplayData RefineItem(DataContext context, int charId, ItemDisplayData[] tools, ItemDisplayData target, ItemDisplayData[] materialItemArray, List<ItemSourceChange> changeList)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		ItemBase equipBaseItem = DomainManager.Item.GetBaseItem(target.Key);
		RefiningEffects refinedEffects = default(RefiningEffects);
		if (ModificationStateHelper.IsActive(equipBaseItem.GetModificationState(), 2))
		{
			refinedEffects = DomainManager.Item.GetRefinedEffects(target.Key);
		}
		else
		{
			refinedEffects.Initialize();
		}
		short[] materialTemplateIdArray = materialItemArray.Select((ItemDisplayData d) => d.Key.TemplateId).ToArray();
		ResourceInts needResources = ItemTemplateHelper.GetRefineRequiredResources(refinedEffects.GetAllMaterialTemplateIds(), materialTemplateIdArray);
		if (charId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			for (sbyte i = 0; i < 8; i++)
			{
				int value = needResources.Get(i);
				if (value > 0)
				{
					ConsumeResource(context, i, value);
					sbyte skillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(target.Key.ItemType, target.Key.TemplateId);
					if (((uint)(skillType - 6) <= 1u || (uint)(skillType - 10) <= 1u) ? true : false)
					{
						int seniority = ProfessionFormulaImpl.Calculate(20, value);
						DomainManager.Extra.ChangeProfessionSeniority(context, 2, seniority);
					}
				}
			}
		}
		else
		{
			needResources = needResources.GetReversed();
			character.ChangeResources(context, ref needResources);
		}
		bool isWeapon = target.Key.ItemType == 0;
		bool isArmor = target.Key.ItemType == 1;
		int oldDurabilityBonus = 0;
		if (isWeapon || isArmor)
		{
			RefiningEffects oldRefinedEffects = (ModificationStateHelper.IsActive(equipBaseItem.GetModificationState(), 2) ? DomainManager.Item.GetRefinedEffects(target.Key) : default(RefiningEffects));
			oldDurabilityBonus = (isWeapon ? oldRefinedEffects.GetWeaponPropertyBonus(ERefiningEffectWeaponType.MaxDurability) : oldRefinedEffects.GetArmorPropertyBonus(ERefiningEffectArmorType.MaxDurability));
			oldDurabilityBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(oldDurabilityBonus, charId);
		}
		ItemKey itemKey;
		for (int i2 = 0; i2 < materialItemArray.Length; i2++)
		{
			ItemDisplayData materialItem = materialItemArray[i2];
			short curId = materialItem.Key.TemplateId;
			short oldId = refinedEffects.GetMaterialTemplateIdAt(i2);
			if (curId == oldId || (curId < 0 && oldId < 0))
			{
				continue;
			}
			(ItemBase item, bool keyChanged) tuple = DomainManager.Item.SetRefinedEffects(context, equipBaseItem, i2, curId);
			var (newItemObj, _) = tuple;
			if (tuple.keyChanged)
			{
				ItemKey oldKey = target.Key;
				ItemKey newKey = newItemObj.GetItemKey();
				equipBaseItem = newItemObj;
				ChangeItem(context, oldKey, target.ItemSourceType, newKey, charId);
			}
			else
			{
				ItemKey[] equipment = character.GetEquipment();
				character.SetEquipment(equipment, context);
			}
			short templateId = GetGreaterGradeMaterial(curId, oldId);
			MaterialItem materialConfig = Config.Material.Instance[templateId];
			ItemDisplayData tool = GetRefineRequiredTool(tools, materialConfig.RequiredLifeSkillType);
			if (tool != null)
			{
				CraftToolItem toolConfig = Config.CraftTool.Instance[tool.RealKey.TemplateId];
				sbyte grade = ItemTemplateHelper.GetGrade(5, templateId);
				short curCost = toolConfig.DurabilityCost[grade];
				itemKey = tool.Key;
				if (itemKey.IsValid())
				{
					DomainManager.Item.ReduceToolDurability(context, charId, tool.RealKey, curCost, tool.ItemSourceType);
				}
			}
		}
		if (isWeapon || isArmor)
		{
			RefiningEffects refiningEffects = default(RefiningEffects);
			if (ModificationStateHelper.IsActive(equipBaseItem.GetModificationState(), 2))
			{
				refiningEffects = DomainManager.Item.GetRefinedEffects(equipBaseItem.GetItemKey());
			}
			else
			{
				refiningEffects.Initialize();
			}
			int newDurabilityBonus = (isWeapon ? refiningEffects.GetWeaponPropertyBonus(ERefiningEffectWeaponType.MaxDurability) : refiningEffects.GetArmorPropertyBonus(ERefiningEffectArmorType.MaxDurability));
			newDurabilityBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(newDurabilityBonus, charId);
			if (newDurabilityBonus != oldDurabilityBonus)
			{
				short maxDurability = equipBaseItem.GetMaxDurability();
				int newMaxDurability = maxDurability * (100 + newDurabilityBonus) / (100 + oldDurabilityBonus);
				short currDurability = equipBaseItem.GetCurrDurability();
				short newCurrDurability = (short)Math.Min(currDurability * (100 + newDurabilityBonus) / (100 + oldDurabilityBonus), newMaxDurability);
				equipBaseItem.SetMaxDurability((short)newMaxDurability, context);
				equipBaseItem.SetCurrDurability(newCurrDurability, context);
			}
		}
		foreach (ItemSourceChange change in changeList)
		{
			foreach (ItemKeyAndCount item in change.Items)
			{
				item.Deconstruct(out itemKey, out var count);
				ItemKey itemKey2 = itemKey;
				int count2 = count;
				if (count2 > 0)
				{
					ItemKey newKey2 = DomainManager.Item.CreateMaterial(context, itemKey2.TemplateId);
					DomainManager.Taiwu.AddItem(context, newKey2, count2, change.ItemSourceType);
				}
				else if (count2 < 0)
				{
					DomainManager.Taiwu.RemoveItem(context, itemKey2, -count2, change.ItemSourceType, deleteItem: true);
				}
			}
		}
		return DomainManager.Item.GetItemDisplayData(equipBaseItem, 1, charId, target.ItemSourceType);
	}

	[DomainMethod]
	public unsafe bool CheckRefineCondition(int charId, ItemKey[] toolKeys, ItemKey equipItemKey, ItemDisplayData[] materialItemData, BuildingBlockKey buildingBlockKey)
	{
		ItemBase equipBaseItem = DomainManager.Item.GetBaseItem(equipItemKey);
		if (!equipBaseItem.GetRefinable())
		{
			return false;
		}
		RefiningEffects refinedEffects = default(RefiningEffects);
		if (ModificationStateHelper.IsActive(equipBaseItem.GetModificationState(), 2))
		{
			refinedEffects = DomainManager.Item.GetRefinedEffects(equipItemKey);
		}
		else
		{
			refinedEffects.Initialize();
		}
		short[] materialTemplateIdArray = materialItemData.Select((ItemDisplayData d) => d.Key.TemplateId).ToArray();
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		ResourceInts needResources = ItemTemplateHelper.GetRefineRequiredResources(refinedEffects.GetAllMaterialTemplateIds(), materialTemplateIdArray);
		if (!((charId == DomainManager.Taiwu.GetTaiwuCharId()) ? GetAllTaiwuResources() : character.GetResources()).CheckIsMeet(ref needResources))
		{
			return false;
		}
		sbyte requiredLifeSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(equipItemKey.ItemType, equipItemKey.TemplateId);
		LifeSkillShorts needLifeSkill = default(LifeSkillShorts);
		bool haveNotChange = true;
		int requirementReducePercent = 0;
		if (!buildingBlockKey.IsInvalid)
		{
			requirementReducePercent = GetBuildingEffectForMake(buildingBlockKey, requiredLifeSkillType).attainmentEffect;
		}
		Dictionary<ItemKey, int> toolDurabilityCost = new Dictionary<ItemKey, int>();
		ItemKey key;
		for (int i = 0; i < materialItemData.Length; i++)
		{
			short oldId = refinedEffects.GetMaterialTemplateIdAt(i);
			short curId = materialItemData[i].Key.TemplateId;
			bool isSame = oldId == curId;
			if (!isSame)
			{
				haveNotChange = false;
			}
			if (curId < 0 && oldId < 0)
			{
				continue;
			}
			short templateId = GetGreaterGradeMaterial(curId, oldId);
			MaterialItem materialConfig = Config.Material.Instance[templateId];
			short lifeSkillAttainment = needLifeSkill.Items[materialConfig.RequiredLifeSkillType];
			int reduce = ((materialConfig.RequiredAttainment == requiredLifeSkillType) ? requirementReducePercent : 0);
			needLifeSkill.Items[materialConfig.RequiredLifeSkillType] = (short)Math.Max(lifeSkillAttainment, materialConfig.RequiredAttainment * (100 - reduce) / 100);
			if (!isSame)
			{
				sbyte requireLifeSkill = materialConfig.RequiredLifeSkillType;
				ItemKey toolKey = GetRefineRequiredTool(toolKeys, requireLifeSkill);
				CraftToolItem toolConfig = Config.CraftTool.Instance[toolKey.TemplateId];
				sbyte grade = ItemTemplateHelper.GetGrade(5, templateId);
				short curCost = toolConfig.DurabilityCost[grade];
				if (!toolDurabilityCost.TryAdd(toolKey, curCost))
				{
					Dictionary<ItemKey, int> dictionary = toolDurabilityCost;
					key = toolKey;
					dictionary[key] += curCost;
				}
				short totalAttainment = GetLifeSkillTotalAttainment(materialConfig.RequiredLifeSkillType, toolKey);
				if (needLifeSkill.Items[materialConfig.RequiredLifeSkillType] > totalAttainment)
				{
					return false;
				}
			}
		}
		foreach (KeyValuePair<ItemKey, int> item in toolDurabilityCost)
		{
			item.Deconstruct(out key, out var value);
			ItemKey toolKey2 = key;
			int curCost2 = value;
			if (!CheckTool(toolKey2, curCost2, curCost2, -1))
			{
				return false;
			}
		}
		if (haveNotChange)
		{
			return false;
		}
		return true;
	}

	private ItemKey GetRefineRequiredTool(ItemKey[] toolKey, sbyte requiredLifeSkillType)
	{
		int index = GameData.Domains.Character.LifeSkillType.RefineTypes.IndexOf(requiredLifeSkillType);
		if (index >= 0)
		{
			return toolKey[index];
		}
		return new ItemKey
		{
			ItemType = 6,
			TemplateId = 54
		};
	}

	private ItemDisplayData GetRefineRequiredTool(ItemDisplayData[] toolKey, sbyte requiredLifeSkillType)
	{
		int index = GameData.Domains.Character.LifeSkillType.RefineTypes.IndexOf(requiredLifeSkillType);
		if (index >= 0)
		{
			return toolKey[index];
		}
		return new ItemDisplayData
		{
			Key = new ItemKey
			{
				ItemType = 6,
				TemplateId = 54
			}
		};
	}

	private short GetGreaterGradeMaterial(short templateId1, short templateId2)
	{
		Tester.Assert(templateId1 >= 0 || templateId2 >= 0);
		short templateId3 = 0;
		sbyte grade = 0;
		if (templateId1 >= 0)
		{
			MaterialItem config = Config.Material.Instance[templateId1];
			grade = config.Grade;
			templateId3 = templateId1;
		}
		if (templateId2 >= 0)
		{
			MaterialItem config2 = Config.Material.Instance[templateId2];
			if (config2.Grade >= grade)
			{
				templateId3 = templateId2;
			}
		}
		return templateId3;
	}

	[DomainMethod]
	public ItemDisplayData WeaveClothingItem(DataContext context, ItemDisplayData tool, ItemDisplayData target, short weaveClothingTemplateId)
	{
		if (tool.Key.IsValid())
		{
			sbyte grade = ItemTemplateHelper.GetGrade(target.Key.ItemType, weaveClothingTemplateId);
			CraftToolItem toolConfig = Config.CraftTool.Instance[tool.Key.TemplateId];
			short cost = toolConfig.DurabilityCost[grade];
			if (cost > 0)
			{
				DomainManager.Item.ReduceToolDurability(context, DomainManager.Taiwu.GetTaiwuCharId(), tool.Key, cost, tool.ItemSourceType);
			}
		}
		DomainManager.Taiwu.SetClothingDisplayModification(context, target.Key, weaveClothingTemplateId);
		ItemDisplayData result = target.Clone();
		result.WeavedClothingTemplateId = weaveClothingTemplateId;
		return result;
	}

	public ItemDisplayData ProfessionDoctorMakeMedicine(DataContext context, ItemDisplayData medicine, ItemDisplayData tool, int makeCount)
	{
		int needItemCount = makeCount * 3;
		Tester.Assert(medicine.Amount >= makeCount);
		short targetTemplateId;
		bool canMedicineUpgrade = ItemTemplateHelper.CanMedicineUpgrade(medicine.Key.ItemType, medicine.Key.TemplateId, out targetTemplateId);
		Tester.Assert(canMedicineUpgrade);
		Inventory inventory = medicine.GetOperationInventoryFromPool(needItemCount);
		foreach (var (key, count) in inventory.Items)
		{
			DomainManager.Taiwu.RemoveItem(context, key, count, medicine.ItemSourceTypeEnum, deleteItem: true);
		}
		ItemDisplayData.ReturnInventoryToPool(inventory);
		if (tool.Key.IsValid())
		{
			sbyte grade = ItemTemplateHelper.GetGrade(medicine.Key.ItemType, medicine.Key.TemplateId);
			CraftToolItem toolConfig = Config.CraftTool.Instance[tool.Key.TemplateId];
			int cost = toolConfig.DurabilityCost[grade] * makeCount;
			DomainManager.Item.ReduceToolDurability(context, DomainManager.Taiwu.GetTaiwuCharId(), tool.Key, cost, tool.ItemSourceType);
		}
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		Location location = taiwuChar.GetLocation();
		bool isInSettlement = false;
		if (location == taiwuVillageLocation)
		{
			isInSettlement = true;
		}
		else
		{
			MapBlockData blockData = DomainManager.Map.GetBlock(location);
			if (blockData.IsCityTown())
			{
				isInSettlement = true;
			}
		}
		ItemKey productItemKey = DomainManager.Item.CreateMedicine(context, targetTemplateId);
		if (isInSettlement)
		{
			taiwuChar.AddInventoryItem(context, productItemKey, makeCount);
		}
		else
		{
			DomainManager.Taiwu.WarehouseAdd(context, productItemKey, makeCount);
		}
		if (ItemTemplateHelper.GetItemSubType(productItemKey.ItemType, productItemKey.TemplateId) == 800)
		{
			sbyte grade2 = ItemTemplateHelper.GetGrade(productItemKey.ItemType, productItemKey.TemplateId);
			int seniority = ProfessionFormulaImpl.Calculate(84, grade2);
			DomainManager.Extra.ChangeProfessionSeniority(context, 13, seniority * makeCount);
		}
		ItemDisplayData itemData = DomainManager.Item.GetItemDisplayData(productItemKey);
		itemData.Amount = makeCount;
		return itemData;
	}

	[DomainMethod]
	public (int attainmentEffect, bool upgradeMakeItem) GetBuildingEffectForMake(BuildingBlockKey buildingBlockKey, sbyte skillType)
	{
		bool upgradeMakeItem = false;
		BuildingAreaData areaData = GetElement_BuildingAreas(buildingBlockKey.GetLocation());
		int attainmentEffect = 0;
		List<short> neighborList = ObjectPool<List<short>>.Instance.Get();
		List<int> neighborDistanceList = ObjectPool<List<int>>.Instance.Get();
		sbyte buildingWidth = BuildingBlock.Instance[_buildingBlocks[buildingBlockKey].TemplateId].Width;
		areaData.GetNeighborBlocks(buildingBlockKey.BuildingBlockIndex, buildingWidth, neighborList, neighborDistanceList, 2);
		foreach (short blockIndex in neighborList)
		{
			BuildingBlockKey neighborKey = new BuildingBlockKey(buildingBlockKey.AreaId, buildingBlockKey.BlockId, blockIndex);
			BuildingBlockData neighborBlock = _buildingBlocks[neighborKey];
			if (neighborBlock.RootBlockIndex >= 0 || neighborBlock.TemplateId == 0 || !neighborBlock.CanUse())
			{
				continue;
			}
			sbyte level = BuildingBlockLevel(neighborKey);
			BuildingBlockItem neighborConfig = BuildingBlock.Instance[neighborBlock.TemplateId];
			if (neighborConfig == null)
			{
				continue;
			}
			if (neighborConfig.ReduceMakeRequirementLifeSkillType == skillType)
			{
				foreach (short scaleId in neighborConfig.ExpandInfos)
				{
					BuildingScaleItem scaleCfg = BuildingScale.Instance[scaleId];
					if (scaleCfg != null && scaleCfg.LifeSkillType == skillType && scaleCfg.Effect == EBuildingScaleEffect.MakeItemAttainmentRequirementReduction)
					{
						attainmentEffect += scaleCfg.GetLevelEffect(level);
					}
				}
			}
			if (neighborConfig.RequireLifeSkillType == skillType && neighborConfig.UpgradeMakeItem)
			{
				upgradeMakeItem = true;
			}
		}
		ObjectPool<List<short>>.Instance.Return(neighborList);
		ObjectPool<List<int>>.Instance.Return(neighborDistanceList);
		return (attainmentEffect: attainmentEffect, upgradeMakeItem: upgradeMakeItem);
	}

	private void ChangeItem(DataContext context, ItemKey oldKey, sbyte itemSourceType, ItemKey newKey, int charId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		ItemKey[] equipment = character.GetEquipment();
		sbyte destSlot = (sbyte)equipment.IndexOf(oldKey);
		int planIndex;
		int slotIndex;
		bool isInPlan = DomainManager.Taiwu.FindItemInEquipmentPlan(oldKey, out planIndex, out slotIndex);
		sbyte legendaryBookWeaponSlot = DomainManager.Extra.GetLegendaryBookWeaponSlotByItemKey(oldKey);
		bool isInLegendaryBook = legendaryBookWeaponSlot >= 0;
		bool deleteItem = newKey.Id != oldKey.Id;
		DomainManager.Taiwu.RemoveItem(context, oldKey, 1, itemSourceType, deleteItem);
		DomainManager.Taiwu.AddItem(context, newKey, 1, itemSourceType);
		if (DomainManager.Taiwu.IsItemLocked(oldKey))
		{
			DomainManager.Taiwu.SetItemLocked(context, oldKey, isLocked: false);
			DomainManager.Taiwu.SetItemLocked(context, newKey, isLocked: true);
		}
		if (!deleteItem)
		{
			if (destSlot > -1)
			{
				character.ChangeEquipment(context, -1, destSlot, newKey);
			}
			if (isInPlan)
			{
				DomainManager.Taiwu.SetEquipmentPlan(context, newKey, planIndex, slotIndex);
			}
			if (isInLegendaryBook)
			{
				DomainManager.Extra.SetLegendaryBookWeaponSlot(context, legendaryBookWeaponSlot, newKey);
			}
			DomainManager.LegendaryBook.SetLegendaryBookWeaponSlotPreset(context, newKey, oldKey);
		}
	}

	private short GetLifeSkillTotalAttainment(sbyte type, ItemKey toolKey)
	{
		int attainment = DomainManager.Taiwu.GetTaiwu().GetLifeSkillAttainment(type);
		GameData.Domains.Item.CraftTool toolItem;
		if (ItemTemplateHelper.IsEmptyTool(toolKey.ItemType, toolKey.TemplateId))
		{
			bool flag = (((uint)(type - 6) <= 1u || (uint)(type - 10) <= 1u) ? true : false);
			int percent;
			if (flag && DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(8))
			{
				ProfessionData professionData = DomainManager.Extra.GetProfessionData(2);
				percent = professionData.GetSeniorityEmptyToolAttainmentBonus();
			}
			else
			{
				percent = ProfessionData.SeniorityToEmptyToolAttainmentBonus(0);
			}
			int toolAttainment = attainment * percent / 100;
			attainment += toolAttainment;
		}
		else if (toolKey.IsValid() && DomainManager.Item.TryGetElement_CraftTools(toolKey.Id, out toolItem))
		{
			CraftToolItem toolConfig = Config.CraftTool.Instance[toolKey.TemplateId];
			if (toolConfig != null && toolConfig.RequiredLifeSkillTypes.Contains(type))
			{
				attainment += toolItem.GetRealAttainmentBonus();
			}
		}
		attainment = Math.Max(0, attainment);
		return (short)attainment;
	}

	public bool CheckTool(ItemKey toolKey, int totalCost, int oneCost, sbyte skillType = -1)
	{
		if (!toolKey.IsValid() || ItemTemplateHelper.IsEmptyTool(toolKey.ItemType, toolKey.TemplateId))
		{
			return true;
		}
		if (!DomainManager.Item.TryGetElement_CraftTools(toolKey.Id, out var tool))
		{
			return false;
		}
		short durability = tool.GetCurrDurability();
		bool toolIsMeet = durability >= totalCost || durability + oneCost > totalCost;
		if (skillType > -1)
		{
			toolIsMeet = toolIsMeet && tool.GetRequiredLifeSkillTypes().Contains(skillType);
		}
		return toolIsMeet;
	}

	public unsafe bool CheckLifeSkill(ref LifeSkillShorts need, ItemKey toolKey)
	{
		for (sbyte i = 0; i < 8; i++)
		{
			short totalAttainment = GetLifeSkillTotalAttainment(i, toolKey);
			if (totalAttainment < need.Items[i])
			{
				return false;
			}
		}
		return true;
	}

	public bool CheckLifeSkill(sbyte lifeSkillType, int requireAttainment, ItemKey toolKey)
	{
		return GetLifeSkillTotalAttainment(lifeSkillType, toolKey) >= requireAttainment;
	}

	public short GetLifeSkillTotalAttainment(int charId, sbyte type, ItemKey toolKey)
	{
		if (charId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			return GetLifeSkillTotalAttainment(type, toolKey);
		}
		short attainment = DomainManager.Character.GetElement_Objects(charId).GetLifeSkillAttainment(type);
		if (toolKey.IsValid() && DomainManager.Item.TryGetElement_CraftTools(toolKey.Id, out var toolItem))
		{
			CraftToolItem toolConfig = Config.CraftTool.Instance[toolKey.TemplateId];
			if (toolConfig != null && toolConfig.RequiredLifeSkillTypes.Contains(type))
			{
				attainment += toolItem.GetAttainmentBonus();
			}
		}
		return Math.Max((short)0, attainment);
	}

	[DomainMethod]
	public BuildingMakeDisplayData GetBuildingMakeDisplayData(DataContext context, BuildingBlockKey blockKey, sbyte lifeSkillType)
	{
		(int, bool) buildingEffect = GetBuildingEffectForMake(blockKey, lifeSkillType);
		return new BuildingMakeDisplayData
		{
			BlockList = GetBuildingBlockList(blockKey.GetLocation()),
			InventoryItemList = DomainManager.Taiwu.GetAllItems(ItemSourceType.Inventory).list,
			WarehouseItemList = DomainManager.Taiwu.GetAllItems(ItemSourceType.Warehouse).list,
			TreasuryItemList = DomainManager.Taiwu.GetAllItems(ItemSourceType.Treasury).list,
			EquippedItemList = DomainManager.Taiwu.GetAllItems(ItemSourceType.Equipment).list,
			LifeSkillAttainments = DomainManager.Taiwu.GetTaiwu().GetLifeSkillAttainments(),
			BuildingAttainmentEffect = buildingEffect.Item1,
			BuildingUpgradeMakeItem = buildingEffect.Item2,
			EmptyToolKey = DomainManager.Item.GetEmptyToolKey(context),
			CanTransferItemToWarehouse = DomainManager.Taiwu.CanTransferItemToWarehouse(context),
			CharacterDisplayData = DomainManager.Character.GetCharacterDisplayData(DomainManager.Taiwu.GetTaiwuCharId()),
			AllPagesReadCookingSkillBookCount = DomainManager.Taiwu.GetTaiwu().GetAllPagesReadCookingSkillBookCount(),
			StoreLocation = GetStoreLocation(-1),
			OwnedClothingList = new List<short>(DomainManager.Taiwu.OwnedClothingSet.Collection),
			WeaveClothingDisplaySetting = DomainManager.Taiwu.WeaveClothingDisplaySetting,
			ClothingDisplayModifications = DomainManager.Taiwu.ClothingDisplayModifications
		};
	}

	[DomainMethod]
	public (short, BuildingBlockData) Build(DataContext context, BuildingBlockKey blockKey, short buildingTemplateId, int[] workers)
	{
		if (!CanBuild(blockKey, buildingTemplateId))
		{
			throw new Exception($"Can not build building {buildingTemplateId} on block {blockKey}");
		}
		SetVillageBuildWork(context, blockKey, workers);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		BuildingBlockItem configData = BuildingBlock.Instance[buildingTemplateId];
		if (BuildingBlockData.CanUpgrade(configData.Type) && SharedMethods.NeedCostResourceToBuild(configData))
		{
			for (sbyte type = 0; type < 8; type++)
			{
				if (configData.BaseBuildCost[type] > 0)
				{
					ConsumeResource(context, type, configData.BaseBuildCost[type]);
				}
			}
		}
		CostBuildingCore(context, configData);
		MapBlockItem mapBlockData = MapBlock.Instance[DomainManager.Map.GetBlock(blockKey.AreaId, blockKey.BlockId).TemplateId];
		sbyte areaWidth = mapBlockData.BuildingAreaWidth;
		BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
		blockData.TemplateId = buildingTemplateId;
		blockData.OfflineResetShopProgress();
		blockData.OperationType = 0;
		blockData.OperationProgress = 0;
		blockData.OperationStopping = false;
		PlaceBuilding(context, blockKey.AreaId, blockKey.BlockId, blockKey.BuildingBlockIndex, blockData, areaWidth);
		if (DomainManager.Taiwu.TriggerBuildingSpaceGuiding())
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 287);
		}
		return (blockKey.BuildingBlockIndex, blockData);
	}

	private void CostBuildingCore(DataContext context, BuildingBlockItem configData)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (configData.BuildingCoreItem == -1)
		{
			return;
		}
		ItemKey tempItem = ItemKey.Invalid;
		foreach (ItemKey item in DomainManager.Taiwu.WarehouseItems.Keys)
		{
			if (item.ItemType == 12 && item.TemplateId == configData.BuildingCoreItem)
			{
				tempItem = item;
				break;
			}
		}
		if (!tempItem.Equals(ItemKey.Invalid))
		{
			DomainManager.Taiwu.WarehouseRemove(context, tempItem, 1);
			return;
		}
		Inventory inventory = taiwuChar.GetInventory();
		foreach (ItemKey item2 in inventory.Items.Keys)
		{
			if (item2.ItemType == 12 && item2.TemplateId == configData.BuildingCoreItem)
			{
				taiwuChar.RemoveInventoryItem(context, item2, 1, deleteItem: true);
				break;
			}
		}
	}

	private int ClacBuildingTimeCost(int[] workers, BuildingBlockItem configData, sbyte buildingOperationType)
	{
		int speed = 0;
		foreach (int charId in workers)
		{
			if (charId >= 0)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				speed += character.GetLifeSkillAttainment(configData.RequireLifeSkillType) + DomainManager.Building.BaseWorkContribution;
			}
		}
		int totalProgress = configData.OperationTotalProgress[buildingOperationType];
		return Convert.ToInt32(Math.Ceiling((float)totalProgress / (float)speed));
	}

	[DomainMethod]
	public (short, BuildingBlockData) Remove(DataContext context, BuildingBlockKey blockKey, int[] workers)
	{
		BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
		BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
		if ((configData.Type != EBuildingBlockType.Building && !BuildingBlockData.IsResource(configData.Type)) || blockData.OperationType != -1 || configData.Class == EBuildingBlockClass.Static || configData.OperationTotalProgress[1] < 0)
		{
			return (blockKey.BuildingBlockIndex, blockData);
		}
		SetVillageBuildWorkAndBlockData(context, blockKey, blockData, workers, 1);
		return (blockKey.BuildingBlockIndex, blockData);
	}

	private void SetVillageBuildWorkAndBlockData(DataContext context, BuildingBlockKey blockKey, BuildingBlockData blockData, int[] workers, sbyte buildingOperationType)
	{
		SetVillageBuildWork(context, blockKey, workers);
		blockData.OperationType = buildingOperationType;
		blockData.OperationProgress = 0;
		blockData.OperationStopping = false;
		SetElement_BuildingBlocks(blockKey, blockData, context);
	}

	private void SetVillageBuildWork(DataContext context, BuildingBlockKey blockKey, int[] workers)
	{
		for (int i = 0; i < workers.Length; i++)
		{
			int workerCharId = workers[i];
			if (workerCharId >= 0)
			{
				VillagerWorkData workData = new VillagerWorkData(workerCharId, 0, blockKey.AreaId, blockKey.BlockId);
				workData.BuildingBlockIndex = blockKey.BuildingBlockIndex;
				workData.WorkerIndex = (sbyte)i;
				DomainManager.Taiwu.SetVillagerWork(context, workerCharId, workData);
			}
		}
	}

	[DomainMethod]
	public (short, BuildingBlockData) SetStopOperation(DataContext context, BuildingBlockKey blockKey, bool stop)
	{
		BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
		if (stop && (blockData.OperationProgress == 0 || blockData.OperationType == 0))
		{
			BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
			GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
			if (blockData.OperationType == 0)
			{
				ResetAllChildrenBlocks(context, blockKey, 0, -1);
				if (SharedMethods.NeedCostResourceToBuild(configData))
				{
					for (sbyte type = 0; type < 8; type++)
					{
						taiwuChar.ChangeResource(context, type, configData.BaseBuildCost[type]);
					}
				}
				if (configData.BuildingCoreItem != -1)
				{
					DomainManager.Taiwu.ReturnBuildingCoreItem(DataContextManager.GetCurrentThreadDataContext(), configData);
				}
				SetBuildingCustomName(context, blockKey, null);
			}
			blockData.OperationType = -1;
			SetElement_BuildingBlocks(blockKey, blockData, context);
			if (_buildingOperatorDict.ContainsKey(blockKey))
			{
				List<int> operators = _buildingOperatorDict[blockKey].GetCollection();
				for (int i = 0; i < operators.Count; i++)
				{
					if (operators[i] >= 0)
					{
						DomainManager.Taiwu.RemoveVillagerWork(context, operators[i]);
					}
				}
			}
		}
		else
		{
			blockData.OperationStopping = stop;
		}
		SetElement_BuildingBlocks(blockKey, blockData, context);
		return (blockKey.BuildingBlockIndex, blockData);
	}

	[DomainMethod]
	public void SetOperator(DataContext context, BuildingBlockKey blockKey, sbyte index, int charId)
	{
		if (_buildingOperatorDict.ContainsKey(blockKey))
		{
			int currCharId = _buildingOperatorDict[blockKey].GetCollection()[index];
			if (currCharId == charId)
			{
				throw new Exception($"Same operator already exist, id: {charId}");
			}
			if (currCharId >= 0)
			{
				DomainManager.Taiwu.RemoveVillagerWork(context, currCharId);
			}
		}
		if (charId >= 0)
		{
			VillagerWorkData workData = new VillagerWorkData(charId, 0, blockKey.AreaId, blockKey.BlockId);
			workData.BuildingBlockIndex = blockKey.BuildingBlockIndex;
			workData.WorkerIndex = index;
			DomainManager.Taiwu.SetVillagerWork(context, charId, workData);
		}
	}

	[DomainMethod]
	public (short, BuildingBlockData) Repair(DataContext context, BuildingBlockKey blockKey)
	{
		BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
		BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
		if (blockData.Durability == configData.MaxDurability)
		{
			return (blockKey.BuildingBlockIndex, blockData);
		}
		ResourceInts taiwuResources = GetAllTaiwuResources();
		sbyte costType = 6;
		int cost = SharedMethods.CalcRepairBuildingCost(blockData, configData);
		if (taiwuResources.Get(costType) >= cost)
		{
			ConsumeResource(context, costType, cost);
			blockData.Durability = configData.MaxDurability;
			SetElement_BuildingBlocks(blockKey, blockData, context);
		}
		return (blockKey.BuildingBlockIndex, blockData);
	}

	[DomainMethod]
	public void ConfirmPlanBuilding(DataContext context, List<IntPair> operateRecord, Location location, List<int> sameSet)
	{
		if (operateRecord == null)
		{
			return;
		}
		foreach (IntPair element in operateRecord)
		{
			BuildingBlockKey originalBlockKey = new BuildingBlockKey(location.AreaId, location.BlockId, (short)element.First);
			BuildingBlockKey nowBlockKey = new BuildingBlockKey(location.AreaId, location.BlockId, (short)element.Second);
			PlanResetBuilding(context, originalBlockKey, nowBlockKey);
		}
		IEnumerable<int> realMovedBuildingIndexSet = (from p in operateRecord.Where(delegate(IntPair p)
			{
				BuildingBlockKey elementId = new BuildingBlockKey(location.AreaId, location.BlockId, (short)p.Second);
				BuildingBlockData element_BuildingBlocks = GetElement_BuildingBlocks(elementId);
				return element_BuildingBlocks.TemplateId != 0;
			})
			select p.Second).Distinct();
		if (sameSet != null)
		{
			realMovedBuildingIndexSet = realMovedBuildingIndexSet.Except(sameSet).ToHashSet();
		}
		foreach (int index in realMovedBuildingIndexSet)
		{
			BuildingBlockKey nowBlockKey2 = new BuildingBlockKey(location.AreaId, location.BlockId, (short)index);
			BuildingBlockData blockData = GetElement_BuildingBlocks(nowBlockKey2);
			if (blockData == null || blockData.ConfigData == null)
			{
				continue;
			}
			for (sbyte i = 0; i < blockData.ConfigData.BaseBuildCost.Length; i++)
			{
				ushort value = blockData.ConfigData.BaseBuildCost[i];
				int finalValue = value * blockData.ConfigData.MoveBuildCostResourceRate / 100;
				if (finalValue > 0)
				{
					ConsumeResource(context, i, finalValue);
				}
			}
		}
	}

	private void PlanResetBuilding(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		ExchangeBlockData(context, originalBlockKey, nowBlockKey);
		ExchangeCollectBuildingResourceType(context, originalBlockKey, nowBlockKey);
		ExchangeBuildingOperator(context, originalBlockKey, nowBlockKey);
		ExchangeCustomBuildingName(context, originalBlockKey, nowBlockKey);
		ExchangeCollectBuildingEarningsData(context, originalBlockKey, nowBlockKey);
		ExchangeShopManager(context, originalBlockKey, nowBlockKey);
		ExchangeShopEvent(context, originalBlockKey, nowBlockKey);
		ExchangeMakeItem(context, originalBlockKey, nowBlockKey);
		ExchangeResident(context, originalBlockKey, nowBlockKey);
		ExchangeComfortableHouses(context, originalBlockKey, nowBlockKey);
		ExchangeBuildingResident(context, originalBlockKey, nowBlockKey);
		ExchangeBuildingComfortableHouse(context, originalBlockKey, nowBlockKey);
		ExchangeAutoWorkList(context, originalBlockKey, nowBlockKey);
		ExchangeAutoSoldList(context, originalBlockKey, nowBlockKey);
		ExchangeAutoCheckComfortableInList(context, originalBlockKey, nowBlockKey);
		ExchangeAutoCheckResidenceInList(context, originalBlockKey, nowBlockKey);
		ExchangeExtraBlockData(context, originalBlockKey, nowBlockKey);
		UpdateTaiwuVillageBuildingEffect();
	}

	private void ExchangeExtraBlockData(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		DomainManager.Extra.ExchangeBuildingArtisanOrder(context, originalBlockKey, nowBlockKey);
		DomainManager.Extra.ExchangeResourceBlockExtraData(context, originalBlockKey, nowBlockKey);
		DomainManager.Extra.ExchangeFeast(context, originalBlockKey, nowBlockKey);
	}

	private void ExchangeAutoCheckComfortableInList(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		List<short> autoCheckInComfortableList = DomainManager.Extra.GetAutoCheckInComfortableList();
		if (autoCheckInComfortableList.Contains(originalBlockKey.BuildingBlockIndex))
		{
			autoCheckInComfortableList.Remove(originalBlockKey.BuildingBlockIndex);
			if (!autoCheckInComfortableList.Contains(nowBlockKey.BuildingBlockIndex))
			{
				autoCheckInComfortableList.Add(nowBlockKey.BuildingBlockIndex);
			}
			DomainManager.Extra.SetAutoCheckInComfortableList(autoCheckInComfortableList, context);
		}
	}

	private void ExchangeAutoCheckResidenceInList(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		List<short> autoCheckInResidenceList = DomainManager.Extra.GetAutoCheckInResidenceList();
		if (autoCheckInResidenceList.Contains(originalBlockKey.BuildingBlockIndex))
		{
			autoCheckInResidenceList.Remove(originalBlockKey.BuildingBlockIndex);
			if (!autoCheckInResidenceList.Contains(nowBlockKey.BuildingBlockIndex))
			{
				autoCheckInResidenceList.Add(nowBlockKey.BuildingBlockIndex);
			}
			DomainManager.Extra.SetAutoCheckInResidenceList(autoCheckInResidenceList, context);
		}
	}

	private void ExchangeAutoWorkList(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		List<short> autoWorkList = DomainManager.Extra.GetAutoWorkBlockIndexList();
		if (autoWorkList.Contains(originalBlockKey.BuildingBlockIndex))
		{
			autoWorkList.Remove(originalBlockKey.BuildingBlockIndex);
			if (!autoWorkList.Contains(nowBlockKey.BuildingBlockIndex))
			{
				autoWorkList.Add(nowBlockKey.BuildingBlockIndex);
			}
			DomainManager.Extra.SetAutoWorkBlockIndexList(autoWorkList, context);
		}
	}

	private void ExchangeAutoSoldList(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		List<short> autoSoldList = DomainManager.Extra.GetAutoSoldBlockIndexList();
		if (autoSoldList.Contains(originalBlockKey.BuildingBlockIndex))
		{
			autoSoldList.Remove(originalBlockKey.BuildingBlockIndex);
			if (!autoSoldList.Contains(nowBlockKey.BuildingBlockIndex))
			{
				autoSoldList.Add(nowBlockKey.BuildingBlockIndex);
			}
			DomainManager.Extra.SetAutoSoldBlockIndexList(autoSoldList, context);
		}
	}

	private void ExchangeBuildingResident(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		if (_buildingResidents == null)
		{
			return;
		}
		List<int> idList = new List<int>();
		foreach (KeyValuePair<int, BuildingBlockKey> pair in _buildingResidents)
		{
			if (pair.Value.Equals(originalBlockKey))
			{
				idList.Add(pair.Key);
			}
		}
		for (int i = 0; i < idList.Count; i++)
		{
			_buildingResidents[idList[i]] = nowBlockKey;
		}
	}

	private void ExchangeBuildingComfortableHouse(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		if (_buildingComfortableHouses == null)
		{
			return;
		}
		List<int> idList = new List<int>();
		foreach (KeyValuePair<int, BuildingBlockKey> pair in _buildingComfortableHouses)
		{
			if (pair.Value.Equals(originalBlockKey))
			{
				idList.Add(pair.Key);
			}
		}
		for (int i = 0; i < idList.Count; i++)
		{
			_buildingComfortableHouses[idList[i]] = nowBlockKey;
		}
	}

	private void ExchangeComfortableHouses(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		if (TryGetElement_ComfortableHouses(originalBlockKey, out var charListOri))
		{
			if (!TryGetElement_ComfortableHouses(nowBlockKey, out var _))
			{
				AddElement_ComfortableHouses(nowBlockKey, charListOri, context);
			}
			else
			{
				SetElement_ComfortableHouses(nowBlockKey, charListOri, context);
			}
			RemoveElement_ComfortableHouses(originalBlockKey, context);
		}
	}

	private void ExchangeResident(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		if (TryGetElement_Residences(originalBlockKey, out var charListOri))
		{
			if (!TryGetElement_Residences(nowBlockKey, out var _))
			{
				AddElement_Residences(nowBlockKey, charListOri, context);
			}
			else
			{
				SetElement_Residences(nowBlockKey, charListOri, context);
			}
			RemoveElement_Residences(originalBlockKey, context);
		}
	}

	private void ExchangeMakeItem(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		if (TryGetElement_MakeItemDataDict(originalBlockKey, out var itemDataOri))
		{
			if (!TryGetElement_MakeItemDataDict(nowBlockKey, out var _))
			{
				AddElement_MakeItemDataDict(nowBlockKey, itemDataOri, context);
			}
			else
			{
				SetElement_MakeItemDataDict(nowBlockKey, itemDataOri, context);
			}
			RemoveElement_MakeItemDataDict(originalBlockKey, context);
		}
	}

	private void ExchangeShopEvent(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		if (_shopEventCollections != null && _shopEventCollections.Remove(originalBlockKey, out var originalCollection))
		{
			_shopEventCollections[nowBlockKey] = originalCollection;
		}
	}

	private void ExchangeShopManager(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		if (!TryGetElement_ShopManagerDict(originalBlockKey, out var charListOri))
		{
			return;
		}
		if (!TryGetElement_ShopManagerDict(nowBlockKey, out var _))
		{
			AddElement_ShopManagerDict(nowBlockKey, charListOri, context);
		}
		else
		{
			SetElement_ShopManagerDict(nowBlockKey, charListOri, context);
		}
		for (int i = 0; i < charListOri.GetCount(); i++)
		{
			if (charListOri.GetCollection()[i] != -1)
			{
				DomainManager.Taiwu.ChangeVillagerWorkBuildingBlockIndex(charListOri.GetCollection()[i], nowBlockKey.BuildingBlockIndex, context);
			}
		}
		RemoveElement_ShopManagerDict(originalBlockKey, context);
	}

	private void ExchangeCollectBuildingEarningsData(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		if (TryGetElement_CollectBuildingEarningsData(originalBlockKey, out var earnDataOri))
		{
			if (!TryGetElement_CollectBuildingEarningsData(nowBlockKey, out var _))
			{
				AddElement_CollectBuildingEarningsData(nowBlockKey, earnDataOri, context);
			}
			else
			{
				SetElement_CollectBuildingEarningsData(nowBlockKey, earnDataOri, context);
			}
			RemoveElement_CollectBuildingEarningsData(originalBlockKey, context);
		}
	}

	private void ExchangeCustomBuildingName(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		if (TryGetElement_CustomBuildingName(originalBlockKey, out var id1))
		{
			if (!TryGetElement_CustomBuildingName(nowBlockKey, out var _))
			{
				AddElement_CustomBuildingName(nowBlockKey, id1, context);
			}
			else
			{
				SetElement_CustomBuildingName(nowBlockKey, id1, context);
			}
			RemoveElement_CustomBuildingName(originalBlockKey, context);
		}
	}

	private void ExchangeBuildingOperator(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		if (!TryGetElement_BuildingOperatorDict(originalBlockKey, out var charListOri))
		{
			return;
		}
		if (!TryGetElement_BuildingOperatorDict(nowBlockKey, out var _))
		{
			AddElement_BuildingOperatorDict(nowBlockKey, charListOri, context);
		}
		else
		{
			SetElement_BuildingOperatorDict(nowBlockKey, charListOri, context);
		}
		RemoveElement_BuildingOperatorDict(originalBlockKey, context);
		for (int i = 0; i < charListOri.GetCount(); i++)
		{
			if (charListOri.GetCollection()[i] != -1)
			{
				DomainManager.Taiwu.ChangeVillagerWorkBuildingBlockIndex(charListOri.GetCollection()[i], nowBlockKey.BuildingBlockIndex, context);
			}
		}
	}

	private void ExchangeCollectBuildingResourceType(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		if (TryGetElement_CollectBuildingResourceType(originalBlockKey, out var typeOri))
		{
			if (!TryGetElement_CollectBuildingResourceType(nowBlockKey, out var _))
			{
				AddElement_CollectBuildingResourceType(nowBlockKey, typeOri, context);
			}
			else
			{
				SetElement_CollectBuildingResourceType(nowBlockKey, typeOri, context);
			}
			RemoveElement_CollectBuildingResourceType(originalBlockKey, context);
		}
	}

	private void ExchangeBlockData(DataContext context, BuildingBlockKey originalBlockKey, BuildingBlockKey nowBlockKey)
	{
		MapBlockItem mapBlockData = MapBlock.Instance[DomainManager.Map.GetBlock(originalBlockKey.AreaId, originalBlockKey.BlockId).TemplateId];
		sbyte areaWidth = mapBlockData.BuildingAreaWidth;
		BuildingBlockData blockData = GetElement_BuildingBlocks(originalBlockKey).Clone();
		BuildingBlockItem blockConfig = BuildingBlock.Instance.GetItem(blockData.TemplateId);
		for (int i = 0; i < blockConfig.Width; i++)
		{
			for (int j = 0; j < blockConfig.Width; j++)
			{
				short index = (short)(originalBlockKey.BuildingBlockIndex + i * areaWidth + j);
				BuildingBlockKey key = new BuildingBlockKey(originalBlockKey.AreaId, originalBlockKey.BlockId, index);
				BuildingBlockData val = new BuildingBlockData(index, 0, -1, -1);
				SetElement_BuildingBlocks(key, val, context);
			}
		}
		for (int k = 0; k < blockConfig.Width; k++)
		{
			for (int l = 0; l < blockConfig.Width; l++)
			{
				short index2 = (short)(nowBlockKey.BuildingBlockIndex + k * areaWidth + l);
				BuildingBlockKey key2 = new BuildingBlockKey(nowBlockKey.AreaId, nowBlockKey.BlockId, index2);
				BuildingBlockData val2 = ((index2 == nowBlockKey.BuildingBlockIndex) ? blockData : new BuildingBlockData(index2, -1, -1, nowBlockKey.BuildingBlockIndex));
				val2.BlockIndex = index2;
				SetElement_BuildingBlocks(key2, val2, context);
			}
		}
	}

	[DomainMethod]
	public int CalcQuickRepairAllBuildingCostMoney(DataContext context)
	{
		int totalCost = 0;
		IEnumerable<(BuildingBlockKey, BuildingBlockData)> blockDataList = GetTaiwuVillageNotEmptyBuildingBlockData();
		foreach (var item in blockDataList)
		{
			BuildingBlockData blockData = item.Item2;
			BuildingBlockItem config = BuildingBlock.Instance[blockData.TemplateId];
			if (BuildingNeedRepair(blockData, config))
			{
				int cost = SharedMethods.CalcRepairBuildingCost(blockData, config);
				totalCost += cost;
			}
		}
		return totalCost;
	}

	private bool BuildingNeedRepair(BuildingBlockData blockData, BuildingBlockItem config)
	{
		EBuildingBlockType type = config.Type;
		bool flag = (uint)(type - 3) <= 1u;
		return flag && blockData.NeedMaintenanceCost() && config.MaxDurability > blockData.Durability;
	}

	[DomainMethod]
	public void QuickRepairAllBuilding(DataContext context)
	{
		int costTotal = 0;
		IEnumerable<(BuildingBlockKey, BuildingBlockData)> blockDataList = GetTaiwuVillageNotEmptyBuildingBlockData();
		foreach (var item in blockDataList)
		{
			BuildingBlockKey blockKey = item.Item1;
			BuildingBlockData blockData = item.Item2;
			BuildingBlockItem config = BuildingBlock.Instance[blockData.TemplateId];
			if (BuildingNeedRepair(blockData, config))
			{
				int cost = SharedMethods.CalcRepairBuildingCost(blockData, config);
				costTotal += cost;
				blockData.Durability = config.MaxDurability;
				SetElement_BuildingBlocks(blockKey, blockData, context);
			}
		}
		sbyte costType = 6;
		ConsumeResource(context, costType, costTotal);
	}

	private void InitializeComfortableHouses(DataContext context, Location location)
	{
		List<BuildingBlockKey> comfortableHouses = FindAllBuildingsWithSameTemplate(location, _buildingAreas[location], 47);
		foreach (BuildingBlockKey buildingBlockKey in comfortableHouses)
		{
			AddElement_ComfortableHouses(buildingBlockKey, default(CharacterList), context);
			DomainManager.Building.SetComfortableAutoCheckIn(context, buildingBlockKey.BuildingBlockIndex, isAutoCheckIn: true);
		}
	}

	private void InitializeResidences(DataContext context, Location location)
	{
		List<BuildingBlockKey> residences = FindAllBuildingsWithSameTemplate(location, _buildingAreas[location], 46);
		foreach (BuildingBlockKey buildingBlockKey in residences)
		{
			BuildingBlockData block = _buildingBlocks[buildingBlockKey];
			for (int i = 0; i < 7; i++)
			{
				block.LevelUnlockedFlags = BitOperation.SetBit(block.LevelUnlockedFlags, i, bit: true);
			}
			SetElement_BuildingBlocks(buildingBlockKey, block, context);
			AddElement_Residences(buildingBlockKey, default(CharacterList), context);
			DomainManager.Building.SetResidenceAutoCheckIn(context, buildingBlockKey.BuildingBlockIndex, isAutoCheckIn: true);
		}
		UpdateHomeless(context, updateAll: true);
	}

	private void InitializeBuildingResidents(DataContext context)
	{
		BuildingBlockKey key;
		CharacterList value;
		foreach (KeyValuePair<BuildingBlockKey, CharacterList> residence in _residences)
		{
			residence.Deconstruct(out key, out value);
			BuildingBlockKey buildingBlockKey = key;
			CharacterList value2 = value;
			foreach (int charId in value2.GetCollection())
			{
				_buildingResidents.Add(charId, buildingBlockKey);
			}
		}
		foreach (KeyValuePair<BuildingBlockKey, CharacterList> comfortableHouse in _comfortableHouses)
		{
			comfortableHouse.Deconstruct(out key, out value);
			BuildingBlockKey buildingBlockKey2 = key;
			CharacterList value3 = value;
			foreach (int charId2 in value3.GetCollection())
			{
				_buildingComfortableHouses.Add(charId2, buildingBlockKey2);
			}
		}
	}

	private void FixResidentData(DataContext context)
	{
		List<int> charList = new List<int>();
		foreach (KeyValuePair<BuildingBlockKey, CharacterList> pair in _residences)
		{
			for (int i = pair.Value.GetCount() - 1; i >= 0; i--)
			{
				int id = pair.Value.GetCollection()[i];
				if (!charList.Contains(id))
				{
					charList.Add(id);
				}
				else
				{
					pair.Value.GetCollection().Remove(id);
				}
			}
		}
		charList.Clear();
		foreach (KeyValuePair<BuildingBlockKey, CharacterList> pair2 in _comfortableHouses)
		{
			for (int i2 = pair2.Value.GetCount() - 1; i2 >= 0; i2--)
			{
				int id2 = pair2.Value.GetCollection()[i2];
				if (!charList.Contains(id2))
				{
					charList.Add(id2);
				}
				else
				{
					pair2.Value.GetCollection().Remove(id2);
				}
			}
		}
	}

	public void AddResidence(DataContext context, BuildingBlockKey key)
	{
		if (_residences.ContainsKey(key))
		{
			SetElement_Residences(key, default(CharacterList), context);
		}
		else
		{
			AddElement_Residences(key, default(CharacterList), context);
		}
	}

	public void RemoveResidence(DataContext context, BuildingBlockKey key)
	{
		if (!_residences.TryGetValue(key, out var charList))
		{
			return;
		}
		RemoveElement_Residences(key, context);
		List<int> collection = charList.GetCollection();
		foreach (int charId in collection)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var _))
			{
				AddTaiwuResident(context, charId);
			}
			_buildingResidents.Remove(charId);
		}
		charList.Clear();
		List<short> autoCheckInList = DomainManager.Extra.GetAutoCheckInResidenceList();
		if (autoCheckInList.Contains(key.BuildingBlockIndex))
		{
			autoCheckInList.Remove(key.BuildingBlockIndex);
			DomainManager.Extra.SetAutoCheckInResidenceList(autoCheckInList, context);
		}
		if (_lockedResidences.ContainsKey(key))
		{
			RemoveElement_LockedResidences(key, context);
		}
	}

	public void AddComfortableHouse(DataContext context, BuildingBlockKey key)
	{
		DomainManager.Extra.SetFeast(context, key, DomainManager.Extra.GetFeast(key));
		if (_comfortableHouses.ContainsKey(key))
		{
			SetElement_ComfortableHouses(key, default(CharacterList), context);
		}
		else
		{
			AddElement_ComfortableHouses(key, default(CharacterList), context);
		}
	}

	public void RemoveComfortableHouse(DataContext context, BuildingBlockKey key)
	{
		DomainManager.Extra.RemoveFeast(context, key);
		if (!_comfortableHouses.TryGetValue(key, out var charList))
		{
			return;
		}
		RemoveElement_ComfortableHouses(key, context);
		List<int> collection = charList.GetCollection();
		foreach (int charId in collection)
		{
			_buildingComfortableHouses.Remove(charId);
		}
		List<short> autoCheckInList = DomainManager.Extra.GetAutoCheckInComfortableList();
		if (autoCheckInList.Contains(key.BuildingBlockIndex))
		{
			autoCheckInList.Remove(key.BuildingBlockIndex);
			DomainManager.Extra.SetAutoCheckInComfortableList(autoCheckInList, context);
		}
		if (_lockedComfortableHouses.ContainsKey(key))
		{
			RemoveElement_LockedComfortableHouses(key, context);
		}
	}

	private void RemoveExceedingResidents(DataContext context, BuildingBlockKey key)
	{
		if (!_residences.TryGetValue(key, out var characterList))
		{
			return;
		}
		CharacterList newList = default(CharacterList);
		int capacity = BuildingScale.DefValue.ResidenceCapacity.GetLevelEffect(BuildingBlockLevel(key));
		List<int> collection = characterList.GetCollection();
		for (int i = 0; i < Math.Min(capacity, collection.Count); i++)
		{
			int charId = collection[i];
			newList.Add(charId);
		}
		for (int j = capacity; j < collection.Count; j++)
		{
			int charId2 = collection[j];
			_buildingResidents.Remove(charId2);
			if (DomainManager.Character.TryGetElement_Objects(charId2, out var character) && character.GetAgeGroup() >= 2)
			{
				_homeless.Add(charId2);
			}
		}
		characterList.Clear();
		SetElement_Residences(key, newList, context);
		SetHomeless(_homeless, context);
	}

	public void SetAllResidenceAutoCheckIn(DataContext context)
	{
		List<Location> taiwuBuildingList = GetTaiwuBuildingAreas();
		for (int i = 0; i < taiwuBuildingList.Count; i++)
		{
			Location location = taiwuBuildingList[i];
			BuildingAreaData areaData = GetElement_BuildingAreas(location);
			for (short index = 0; index < areaData.Width * areaData.Width; index++)
			{
				BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
				BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
				if (blockData.TemplateId == 46)
				{
					SetResidenceAutoCheckIn(context, blockKey.BuildingBlockIndex, isAutoCheckIn: true);
				}
			}
		}
	}

	[DomainMethod]
	public void AddToResidence(DataContext context, int charId, BuildingBlockKey buildingBlockKey)
	{
		RemoveTaiwuResident(context, charId);
		if (!_residences.ContainsKey(buildingBlockKey))
		{
			AddElement_Residences(buildingBlockKey, default(CharacterList), context);
		}
		AddCharToResidence(context, charId, buildingBlockKey);
	}

	[DomainMethod]
	public bool RemoveFromResidence(DataContext context, int charId, BuildingBlockKey buildingBlockKey)
	{
		if (IsResidenceCharacterLocked(buildingBlockKey, charId))
		{
			return false;
		}
		RemoveCharFromResidence(context, charId, buildingBlockKey);
		AddTaiwuResident(context, charId);
		return true;
	}

	[DomainMethod]
	public void RemoveAllFormResidence(DataContext context, BuildingBlockKey buildingBlockKey)
	{
		CharacterList charIdList = _residences[buildingBlockKey];
		for (int i = charIdList.GetCount() - 1; i >= 0; i--)
		{
			int charId = charIdList.GetCollection()[i];
			if (!IsResidenceCharacterLocked(buildingBlockKey, charId))
			{
				RemoveCharFromResidence(context, charId, buildingBlockKey);
				AddTaiwuResident(context, charId);
			}
		}
	}

	[DomainMethod]
	public void RemoveAllFromComfortableHouse(DataContext context, BuildingBlockKey buildingBlockKey)
	{
		if (!_comfortableHouses.ContainsKey(buildingBlockKey))
		{
			return;
		}
		CharacterList charIdList = _comfortableHouses[buildingBlockKey];
		for (int i = charIdList.GetCount() - 1; i >= 0; i--)
		{
			int charId = charIdList.GetCollection()[i];
			if (!IsComfortableHouseCharacterLocked(buildingBlockKey, charId))
			{
				RemoveCharFromComfortableHouse(context, charId, buildingBlockKey);
			}
		}
	}

	[DomainMethod]
	public List<int> SortedComfortableHousePeople(DataContext context, List<int> charIdList)
	{
		for (int index = charIdList.Count - 1; index >= 0; index--)
		{
			int id = charIdList[index];
			if (!DomainManager.Character.TryGetElement_Objects(id, out var character) || character.GetAgeGroup() == 0)
			{
				charIdList.RemoveAt(index);
			}
		}
		charIdList.Sort((int l, int r) => DomainManager.Character.GetElement_Objects(l).GetHappiness().CompareTo(DomainManager.Character.GetElement_Objects(r).GetHappiness()));
		return charIdList;
	}

	[DomainMethod]
	public bool ReplaceCharacterInResidence(DataContext context, int charId, BuildingBlockKey buildingBlockKey, sbyte index)
	{
		CharacterList residence = _residences[buildingBlockKey];
		Tester.Assert(index >= 0 && residence.GetCount() > index);
		List<int> collection = residence.GetCollection();
		int replacedCharId = collection[index];
		if (IsResidenceCharacterLocked(buildingBlockKey, replacedCharId))
		{
			return false;
		}
		if (charId < 0)
		{
			return RemoveFromResidence(context, replacedCharId, buildingBlockKey);
		}
		if (_buildingResidents.TryGetValue(charId, out var srcBuildingBlockKey) && IsResidenceCharacterLocked(srcBuildingBlockKey, charId))
		{
			return false;
		}
		if (_homeless.Contains(charId))
		{
			_homeless.Remove(charId);
			collection[index] = charId;
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetAgeGroup() >= 2)
			{
				_homeless.Add(replacedCharId);
				SetHomeless(_homeless, context);
			}
			_buildingResidents.Add(charId, buildingBlockKey);
			_buildingResidents.Remove(replacedCharId);
		}
		else
		{
			if (!_residences.TryGetValue(srcBuildingBlockKey, out var srcResidence))
			{
				throw new Exception($"{charId}'s previous living status is unknown.");
			}
			List<int> srcResidenceCollection = srcResidence.GetCollection();
			int srcIndex = srcResidenceCollection.IndexOf(charId);
			Tester.Assert(srcIndex >= 0);
			srcResidenceCollection[srcIndex] = replacedCharId;
			collection[index] = charId;
			SetElement_Residences(srcBuildingBlockKey, srcResidence, context);
			_buildingResidents[replacedCharId] = srcBuildingBlockKey;
			_buildingResidents[charId] = buildingBlockKey;
		}
		SetElement_Residences(buildingBlockKey, residence, context);
		return true;
	}

	[DomainMethod]
	public bool ReplaceCharacterInComfortableHouse(DataContext context, int charIdB, BuildingBlockKey buildingBlockKey, sbyte index)
	{
		CharacterList comfortableHouse = _comfortableHouses[buildingBlockKey];
		Tester.Assert(index >= 0 && comfortableHouse.GetCount() > index);
		List<int> collection = comfortableHouse.GetCollection();
		int replacedCharId = collection[index];
		if (IsComfortableHouseCharacterLocked(buildingBlockKey, replacedCharId))
		{
			return false;
		}
		if (charIdB < 0)
		{
			return RemoveFromComfortableHouse(context, replacedCharId, buildingBlockKey);
		}
		if (_buildingComfortableHouses.TryGetValue(charIdB, out var srcBuildingBlockKey) && IsComfortableHouseCharacterLocked(srcBuildingBlockKey, charIdB))
		{
			return false;
		}
		if (_buildingComfortableHouses.TryGetValue(charIdB, out srcBuildingBlockKey))
		{
			CharacterList srcComfortableHouse = _comfortableHouses.GetValueOrDefault(srcBuildingBlockKey);
			List<int> srcComfortableHouseCollection = srcComfortableHouse.GetCollection();
			int srcIndex = srcComfortableHouseCollection.IndexOf(charIdB);
			Tester.Assert(srcIndex >= 0);
			srcComfortableHouseCollection[srcIndex] = replacedCharId;
			collection[index] = charIdB;
			SetElement_ComfortableHouses(srcBuildingBlockKey, srcComfortableHouse, context);
			_buildingComfortableHouses[replacedCharId] = srcBuildingBlockKey;
			_buildingComfortableHouses[charIdB] = buildingBlockKey;
		}
		else
		{
			collection[index] = charIdB;
			_buildingComfortableHouses.Add(charIdB, buildingBlockKey);
			_buildingComfortableHouses.Remove(replacedCharId);
		}
		SetElement_ComfortableHouses(buildingBlockKey, comfortableHouse, context);
		return true;
	}

	[DomainMethod]
	public bool AddToComfortableHouse(DataContext context, int charId, BuildingBlockKey buildingBlockKey)
	{
		if (_buildingComfortableHouses.TryGetValue(charId, out var srcBuildingBlockKey))
		{
			if (IsComfortableHouseCharacterLocked(srcBuildingBlockKey, charId))
			{
				return false;
			}
			if (_comfortableHouses.ContainsKey(srcBuildingBlockKey))
			{
				RemoveCharFromComfortableHouse(context, charId, srcBuildingBlockKey);
			}
		}
		if (!_comfortableHouses.ContainsKey(buildingBlockKey))
		{
			AddElement_ComfortableHouses(buildingBlockKey, default(CharacterList), context);
		}
		AddCharToComfortableHouse(context, charId, buildingBlockKey);
		return true;
	}

	[DomainMethod]
	public bool RemoveFromComfortableHouse(DataContext context, int charId, BuildingBlockKey buildingBlockKey)
	{
		if (IsComfortableHouseCharacterLocked(buildingBlockKey, charId))
		{
			return false;
		}
		RemoveCharFromComfortableHouse(context, charId, buildingBlockKey);
		return true;
	}

	[DomainMethod]
	public CharacterList QuickFillResidence(DataContext context, BuildingBlockKey buildingBlockKey)
	{
		if (!_residences.ContainsKey(buildingBlockKey))
		{
			AddElement_Residences(buildingBlockKey, default(CharacterList), context);
		}
		sbyte level = BuildingBlockLevel(buildingBlockKey);
		int[] collection = _homeless.GetCollection().ToArray();
		int[] array = collection;
		foreach (int homelessChar in array)
		{
			if (_residences[buildingBlockKey].GetCount() >= BuildingScale.DefValue.ResidenceCapacity.GetLevelEffect(level))
			{
				break;
			}
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(homelessChar);
			if (!character.IsCompletelyInfected() && character.GetAgeGroup() >= 2)
			{
				AddCharToResidence(context, homelessChar, buildingBlockKey);
				CharacterList homeless = _homeless;
				homeless.Remove(homelessChar);
				SetHomeless(homeless, context);
			}
		}
		return _residences[buildingBlockKey];
	}

	[DomainMethod]
	public CharacterList QuickFillComfortableHouse(DataContext context, BuildingBlockKey buildingBlockKey)
	{
		RemoveAllFromComfortableHouse(context, buildingBlockKey);
		sbyte level = BuildingBlockLevel(buildingBlockKey);
		int capacity = BuildingScale.DefValue.ComfortableHouseCapacity.GetLevelEffect(level);
		int addCount = capacity;
		if (_comfortableHouses.ContainsKey(buildingBlockKey))
		{
			addCount = capacity - _comfortableHouses[buildingBlockKey].GetCount();
			if (addCount <= 0)
			{
				return _comfortableHouses[buildingBlockKey];
			}
		}
		List<int> charIdList = ObjectPool<List<int>>.Instance.Get();
		charIdList.Clear();
		foreach (KeyValuePair<BuildingBlockKey, CharacterList> residence in _residences)
		{
			charIdList.AddRange(residence.Value.GetCollection());
		}
		charIdList.AddRange(_homeless.GetCollection());
		for (int index = charIdList.Count - 1; index >= 0; index--)
		{
			int id = charIdList[index];
			BuildingBlockKey residenceKey;
			GameData.Domains.Character.Character character;
			if (_buildingComfortableHouses.ContainsKey(id))
			{
				charIdList.RemoveAt(index);
			}
			else if (_buildingResidents.TryGetValue(id, out residenceKey) && IsResidenceCharacterLocked(residenceKey, id))
			{
				charIdList.RemoveAt(index);
			}
			else if (!DomainManager.Character.TryGetElement_Objects(id, out character) || character.GetAgeGroup() == 0)
			{
				charIdList.RemoveAt(index);
			}
		}
		bool sortByHappiness = true;
		if (TryGetElement_ComfortableHousesAutoCheckInType(buildingBlockKey, out var autoCheckInType))
		{
			sortByHappiness = autoCheckInType;
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (sortByHappiness)
		{
			charIdList.Sort((int l, int r) => DomainManager.Character.GetElement_Objects(l).GetHappiness().CompareTo(DomainManager.Character.GetElement_Objects(r).GetHappiness()));
		}
		else
		{
			charIdList.Sort((int l, int r) => DomainManager.Character.GetFavorability(l, taiwuCharId).CompareTo(DomainManager.Character.GetFavorability(r, taiwuCharId)));
		}
		List<int> charAdd = charIdList.GetRange(0, Math.Min(addCount, charIdList.Count));
		for (int i = 0; i < charAdd.Count; i++)
		{
			int charId = charAdd[i];
			AddToComfortableHouse(context, charId, buildingBlockKey);
		}
		ObjectPool<List<int>>.Instance.Return(charIdList);
		_comfortableHouses.TryGetValue(buildingBlockKey, out var characterList);
		return characterList;
	}

	[DomainMethod]
	public CharacterList GetCharsInResidence(DataContext context, BuildingBlockKey key)
	{
		return _residences.ContainsKey(key) ? _residences[key] : default(CharacterList);
	}

	[DomainMethod]
	public List<CharacterList> GetAllResidents(DataContext context, BuildingBlockKey blockKey, bool skipChild = false)
	{
		List<CharacterList> allResidents = new List<CharacterList>(4);
		CharacterList infected = default(CharacterList);
		CharacterList homeless = default(CharacterList);
		List<int> collection = _homeless.GetCollection();
		foreach (int charId in collection)
		{
			if (!skipChild || !IsChild(charId))
			{
				if (DomainManager.Character.GetElement_Objects(charId).IsCompletelyInfected())
				{
					CharacterList charList = infected;
					charList.Add(charId);
					infected = charList;
				}
				else
				{
					CharacterList charList2 = homeless;
					charList2.Add(charId);
					homeless = charList2;
				}
			}
		}
		allResidents.Add(default(CharacterList));
		foreach (KeyValuePair<BuildingBlockKey, CharacterList> residence in _residences)
		{
			if (residence.Key.Equals(blockKey))
			{
				continue;
			}
			CharacterList charList3 = allResidents[0];
			List<int> residentIds = residence.Value.GetCollection();
			IEnumerable<int> charIds;
			if (!skipChild)
			{
				IEnumerable<int> enumerable = residentIds;
				charIds = enumerable;
			}
			else
			{
				charIds = residentIds.Where((int id) => !IsChild(id));
			}
			charList3.AddRange(charIds);
			allResidents[0] = charList3;
		}
		allResidents.Add(homeless);
		allResidents.Add(infected);
		return allResidents;
		static bool IsChild(int objectId)
		{
			sbyte ageGroup = DomainManager.Character.GetElement_Objects(objectId).GetAgeGroup();
			return ageGroup < 2;
		}
	}

	[DomainMethod]
	public CharacterList GetCharsInComfortableHouse(DataContext context, BuildingBlockKey key)
	{
		if (!_comfortableHouses.ContainsKey(key))
		{
			return default(CharacterList);
		}
		return _comfortableHouses[key];
	}

	[DomainMethod]
	public CharacterList GetHomeless(DataContext context)
	{
		return _homeless;
	}

	[DomainMethod]
	public List<int> GetLockedInResidenceIds(DataContext context)
	{
		List<int> result = new List<int>();
		foreach (KeyValuePair<BuildingBlockKey, CharacterSet> lockedResidence in _lockedResidences)
		{
			foreach (int charId in lockedResidence.Value.GetCollection())
			{
				result.Add(charId);
			}
		}
		return result;
	}

	[DomainMethod]
	public List<int> GetLockedInComfortableHouseIds(DataContext context)
	{
		List<int> result = new List<int>();
		foreach (KeyValuePair<BuildingBlockKey, CharacterSet> lockedComfortableHouse in _lockedComfortableHouses)
		{
			foreach (int charId in lockedComfortableHouse.Value.GetCollection())
			{
				result.Add(charId);
			}
		}
		return result;
	}

	[DomainMethod]
	public void SetResidenceAutoCheckIn(DataContext context, short blockIndex, bool isAutoCheckIn)
	{
		List<short> autoCheckInList = DomainManager.Extra.GetAutoCheckInResidenceList();
		if (isAutoCheckIn && !autoCheckInList.Contains(blockIndex))
		{
			autoCheckInList.Add(blockIndex);
			DomainManager.Extra.SetAutoCheckInResidenceList(autoCheckInList, context);
		}
		if (!isAutoCheckIn && autoCheckInList.Contains(blockIndex))
		{
			autoCheckInList.Remove(blockIndex);
			DomainManager.Extra.SetAutoCheckInResidenceList(autoCheckInList, context);
		}
	}

	[DomainMethod]
	public void SetComfortableAutoCheckIn(DataContext context, short blockIndex, bool isAutoCheckIn)
	{
		List<short> autoCheckInList = DomainManager.Extra.GetAutoCheckInComfortableList();
		if (isAutoCheckIn && !autoCheckInList.Contains(blockIndex))
		{
			autoCheckInList.Add(blockIndex);
			DomainManager.Extra.SetAutoCheckInComfortableList(autoCheckInList, context);
		}
		if (!isAutoCheckIn && autoCheckInList.Contains(blockIndex))
		{
			autoCheckInList.Remove(blockIndex);
			DomainManager.Extra.SetAutoCheckInComfortableList(autoCheckInList, context);
		}
	}

	[DomainMethod]
	public void SetComfortableAutoCheckInType(DataContext context, BuildingBlockKey buildingBlockKey, bool checkInType)
	{
		if (_comfortableHousesAutoCheckInType.ContainsKey(buildingBlockKey))
		{
			SetElement_ComfortableHousesAutoCheckInType(buildingBlockKey, checkInType, context);
		}
		else
		{
			AddElement_ComfortableHousesAutoCheckInType(buildingBlockKey, checkInType, context);
		}
	}

	public bool IsResidenceCharacterLocked(BuildingBlockKey buildingBlockKey, int charId)
	{
		if (_lockedResidences.TryGetValue(buildingBlockKey, out var lockedSet))
		{
			return lockedSet.Contains(charId);
		}
		return false;
	}

	public bool IsComfortableHouseCharacterLocked(BuildingBlockKey buildingBlockKey, int charId)
	{
		if (_lockedComfortableHouses.TryGetValue(buildingBlockKey, out var lockedSet))
		{
			return lockedSet.Contains(charId);
		}
		return false;
	}

	[DomainMethod]
	public bool LockResidenceCharacter(DataContext context, BuildingBlockKey buildingBlockKey, int charId)
	{
		if (!_residences.TryGetValue(buildingBlockKey, out var residence) || !residence.GetCollection().Contains(charId))
		{
			return false;
		}
		if (!_lockedResidences.TryGetValue(buildingBlockKey, out var lockedSet))
		{
			lockedSet = default(CharacterSet);
		}
		lockedSet.Add(charId);
		SetElement_LockedResidences(buildingBlockKey, lockedSet, context);
		return true;
	}

	[DomainMethod]
	public bool UnlockResidenceCharacter(DataContext context, BuildingBlockKey buildingBlockKey, int charId)
	{
		if (!_lockedResidences.TryGetValue(buildingBlockKey, out var lockedSet) || !lockedSet.Contains(charId))
		{
			return false;
		}
		lockedSet.Remove(charId);
		SetElement_LockedResidences(buildingBlockKey, lockedSet, context);
		return true;
	}

	[DomainMethod]
	public bool LockComfortableHouseCharacter(DataContext context, BuildingBlockKey buildingBlockKey, int charId)
	{
		if (!_comfortableHouses.TryGetValue(buildingBlockKey, out var comfortableHouse) || !comfortableHouse.GetCollection().Contains(charId))
		{
			return false;
		}
		if (!_lockedComfortableHouses.TryGetValue(buildingBlockKey, out var lockedSet))
		{
			lockedSet = default(CharacterSet);
			lockedSet.Add(charId);
			_lockedComfortableHouses[buildingBlockKey] = lockedSet;
		}
		SetElement_LockedComfortableHouses(buildingBlockKey, lockedSet, context);
		return true;
	}

	[DomainMethod]
	public bool UnlockComfortableHouseCharacter(DataContext context, BuildingBlockKey buildingBlockKey, int charId)
	{
		if (!_lockedComfortableHouses.TryGetValue(buildingBlockKey, out var lockedSet) || !lockedSet.Contains(charId))
		{
			return false;
		}
		lockedSet.Remove(charId);
		SetElement_LockedComfortableHouses(buildingBlockKey, lockedSet, context);
		return true;
	}

	[DomainMethod]
	public CharacterSet GetLockedResidenceCharacters(BuildingBlockKey buildingBlockKey)
	{
		if (_lockedResidences.TryGetValue(buildingBlockKey, out var lockedSet))
		{
			return lockedSet;
		}
		return default(CharacterSet);
	}

	[DomainMethod]
	public CharacterSet GetLockedComfortableHouseCharacters(BuildingBlockKey buildingBlockKey)
	{
		if (_lockedComfortableHouses.TryGetValue(buildingBlockKey, out var lockedSet))
		{
			return lockedSet;
		}
		return default(CharacterSet);
	}

	[DomainMethod]
	public (int sumCapacity, int residentsCount, int villagerSumCount) GetResidenceInfo()
	{
		int capacity = 0;
		foreach (KeyValuePair<BuildingBlockKey, CharacterList> residence2 in _residences)
		{
			sbyte level = BuildingBlockLevel(residence2.Key);
			if (level > 0)
			{
				capacity += BuildingScale.DefValue.ResidenceCapacity.GetLevelEffect(level);
			}
		}
		return (sumCapacity: capacity, residentsCount: _buildingResidents.Count, villagerSumCount: _buildingResidents.Count + _homeless.GetCount());
	}

	public byte GetLivingStatus(int charId)
	{
		if (DomainManager.Taiwu.IsInGroup(charId))
		{
			return 1;
		}
		if (_buildingResidents.TryGetValue(charId, out var _))
		{
			return 2;
		}
		if (_homeless.Contains(charId))
		{
			return 0;
		}
		Logger.Warn($"Given character {charId} is not a taiwu resident.");
		return 0;
	}

	public void AddTaiwuResident(DataContext context, int charId, bool autoHousing = false)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character) || character.GetAgeGroup() < 2)
		{
			return;
		}
		if (autoHousing)
		{
			foreach (KeyValuePair<BuildingBlockKey, CharacterList> residence in _residences)
			{
				sbyte level = BuildingBlockLevel(residence.Key);
				if (level <= 0 || residence.Value.GetCount() == BuildingScale.DefValue.ResidenceCapacity.GetLevelEffect(level) || !DomainManager.Building.GetResidenceIsAutoCheckIn(residence.Key.BuildingBlockIndex))
				{
					continue;
				}
				AddCharToResidence(context, charId, residence.Key);
				return;
			}
		}
		_homeless.Add(charId);
		SetHomeless(_homeless, context);
	}

	public void MakeTargetHomeless(DataContext context, int charId)
	{
		if (!_homeless.Contains(charId) && _buildingResidents.ContainsKey(charId))
		{
			RemoveTaiwuResident(context, charId, removeFromHomeless: false);
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetAgeGroup() >= 2)
			{
				_homeless.Add(charId);
				SetHomeless(_homeless, context);
			}
		}
	}

	public void RemoveTaiwuResident(DataContext context, int charId, bool removeFromHomeless = true)
	{
		if (_buildingResidents.TryGetValue(charId, out var buildingBlockKey))
		{
			if (_residences.ContainsKey(buildingBlockKey))
			{
				RemoveCharFromResidence(context, charId, buildingBlockKey);
			}
		}
		else if (removeFromHomeless && _homeless.Contains(charId))
		{
			_homeless.Remove(charId);
			SetHomeless(_homeless, context);
		}
	}

	private void UpdateHomeless(DataContext context, bool updateAll)
	{
		if (_homeless.GetCount() <= 0)
		{
			return;
		}
		List<int> collection = _homeless.GetCollection();
		if (updateAll)
		{
			_homeless = default(CharacterList);
			SetHomeless(_homeless, context);
			{
				foreach (int homelessChar in collection)
				{
					AddTaiwuResident(context, homelessChar, !DomainManager.Character.GetElement_Objects(homelessChar).IsCompletelyInfected());
				}
				return;
			}
		}
		foreach (int homelessChar2 in collection)
		{
			if (DomainManager.Character.GetElement_Objects(homelessChar2).IsCompletelyInfected())
			{
				continue;
			}
			CharacterList homeless = _homeless;
			homeless.Remove(homelessChar2);
			SetHomeless(homeless, context);
			AddTaiwuResident(context, homelessChar2, autoHousing: true);
			break;
		}
	}

	public void SetAllVillagerHomeless(DataContext context)
	{
		foreach (int charId in _buildingResidents.Keys)
		{
			MakeTargetHomeless(context, charId);
		}
	}

	private void UpdateResidentsHappinessAndFavor(DataContext context)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		List<int> collection = _homeless.GetCollection();
		foreach (int charId in collection)
		{
			UpdateHomelessHappinessAndFavor(charId);
		}
		foreach (KeyValuePair<BuildingBlockKey, CharacterList> pair in _residences)
		{
			BuildingBlockKey blockKey = pair.Key;
			collection = pair.Value.GetCollection();
			BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
			if (blockData.CanUse())
			{
				continue;
			}
			foreach (int charId2 in collection)
			{
				UpdateHomelessHappinessAndFavor(charId2);
			}
		}
		static int ClampDelta(int curValue, int delta)
		{
			if (curValue <= 0)
			{
				return 0;
			}
			return (curValue + delta < 0) ? (-curValue) : delta;
		}
		void UpdateHomelessHappinessAndFavor(int num)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(num);
			sbyte ageGroup = character.GetAgeGroup();
			if (ageGroup >= 2)
			{
				short favorability = DomainManager.Character.GetFavorability(num, taiwuCharId);
				if (favorability > 0)
				{
					int delta = ClampDelta(favorability, GlobalConfig.Instance.HomelessFavorabilityChangePerMonth);
					if (favorability + delta < 0)
					{
						delta = -favorability;
					}
					if (favorability > 0)
					{
						DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, character, taiwu, delta);
					}
				}
				sbyte happiness = character.GetHappiness();
				if (happiness > 0)
				{
					int delta2 = ClampDelta(happiness, GlobalConfig.Instance.HomelessHappinessChangePerMonth);
					character.ChangeHappiness(context, delta2);
				}
			}
		}
	}

	private void AddCharToResidence(DataContext context, int charId, BuildingBlockKey buildingBlockKey)
	{
		_buildingResidents.Add(charId, buildingBlockKey);
		CharacterList charList = _residences[buildingBlockKey];
		charList.Add(charId);
		SetElement_Residences(buildingBlockKey, charList, context);
	}

	private void RemoveCharFromResidence(DataContext context, int charId, BuildingBlockKey buildingBlockKey)
	{
		_buildingResidents.Remove(charId);
		CharacterList charList = _residences[buildingBlockKey];
		charList.Remove(charId);
		SetElement_Residences(buildingBlockKey, charList, context);
		if (_lockedResidences.TryGetValue(buildingBlockKey, out var lockedSet) && lockedSet.Contains(charId))
		{
			lockedSet.Remove(charId);
			SetElement_LockedResidences(buildingBlockKey, lockedSet, context);
		}
	}

	private void AddCharToComfortableHouse(DataContext context, int charId, BuildingBlockKey buildingBlockKey)
	{
		_buildingComfortableHouses.Add(charId, buildingBlockKey);
		CharacterList charList = _comfortableHouses[buildingBlockKey];
		charList.Add(charId);
		SetElement_ComfortableHouses(buildingBlockKey, charList, context);
	}

	private void RemoveCharFromComfortableHouse(DataContext context, int charId, BuildingBlockKey buildingBlockKey)
	{
		_buildingComfortableHouses.Remove(charId);
		CharacterList charList = _comfortableHouses[buildingBlockKey];
		charList.Remove(charId);
		SetElement_ComfortableHouses(buildingBlockKey, charList, context);
		if (_lockedComfortableHouses.TryGetValue(buildingBlockKey, out var lockedSet) && lockedSet.Contains(charId))
		{
			lockedSet.Remove(charId);
			SetElement_LockedComfortableHouses(buildingBlockKey, lockedSet, context);
		}
	}

	public void SetCharacterParticipantFeast(int charId, short feastType, int happiness, ItemKey dishCopy)
	{
		_feastParticipants[charId] = (feastType, happiness, dishCopy);
	}

	public void ClearFeastParticipants()
	{
		_feastParticipants.Clear();
	}

	public Dictionary<BuildingBlockKey, CharacterList> GetAllComfortableHouses()
	{
		return _comfortableHouses;
	}

	public bool IsCharacterParticipantFeast(int charId, out (short, int, ItemKey) value)
	{
		return _feastParticipants.TryGetValue(charId, out value);
	}

	public bool IsCharacterAbleToJoinFeast(int charId)
	{
		if (DomainManager.Taiwu.IsInGroup(charId))
		{
			return false;
		}
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return false;
		}
		if (character.GetCreatingType() != 1)
		{
			return false;
		}
		return (character.GetOrganizationInfo().OrgTemplateId == 16) ? (character.GetAgeGroup() != 0) : (character.GetLocation().AreaId == DomainManager.Taiwu.GetTaiwuVillageLocation().AreaId && DomainManager.Character.GetFavorabilityType(charId, DomainManager.Taiwu.GetTaiwuCharId()) >= 2 && CharacterMatcher.DefValue.CanJoinFeast.Match(character));
	}

	public void FeastAdvanceMonth_Complement(DataContext context)
	{
		foreach (var (id, data) in _feastParticipants)
		{
			if (DomainManager.Character.TryGetElement_Objects(id, out var character) && character.GetEatingItems().GetAvailableEatingSlot(character.GetCurrMaxEatingSlotsCount()) >= 0)
			{
				character.AddEatingItem(context, data.Item3);
			}
		}
	}

	public void TaiwuVillagerBecomeAdultAdvanceMonth(DataContext context)
	{
		short taiwuVillageSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		OrgMemberCollection members = DomainManager.Organization.GetElement_CivilianSettlements(taiwuVillageSettlementId).GetMembers();
		foreach (int charId in members)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetPhysiologicalAge() >= 16 && !_buildingResidents.ContainsKey(charId) && !DomainManager.Taiwu.IsInGroup(charId) && !_homeless.Contains(charId))
			{
				_homeless.Add(charId);
			}
		}
		SetHomeless(_homeless, context);
	}

	public void TryRemoveFeastCustomer(DataContext context, int charId)
	{
		if (_buildingComfortableHouses.TryGetValue(charId, out var buildingBlockKey) && _comfortableHouses.ContainsKey(buildingBlockKey) && !IsCharacterAbleToJoinFeast(charId))
		{
			RemoveCharFromComfortableHouse(context, charId, buildingBlockKey);
		}
	}

	[DomainMethod]
	public List<CharacterDisplayData> GetFeastTargetCharList(DataContext context, BuildingBlockKey buildingBlockKey)
	{
		List<CharacterDisplayData> charDataList = new List<CharacterDisplayData>();
		List<CharacterList> allResidents = GetAllResidents(context, buildingBlockKey);
		foreach (CharacterList item in allResidents)
		{
			foreach (int charId in item.GetCollection())
			{
				if (IsCharacterAbleToJoinFeast(charId))
				{
					CharacterDisplayData charData = DomainManager.Character.GetCharacterDisplayData(charId);
					charDataList.Add(charData);
				}
			}
		}
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(buildingBlockKey.AreaId);
		Span<MapBlockData> span = blocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData mapBlockData = span[i];
			if (mapBlockData.CharacterSet == null)
			{
				continue;
			}
			foreach (int charId2 in mapBlockData.CharacterSet)
			{
				if (!charDataList.Any((CharacterDisplayData d) => d.CharacterId == charId2) && IsCharacterAbleToJoinFeast(charId2))
				{
					CharacterDisplayData charData2 = DomainManager.Character.GetCharacterDisplayData(charId2);
					charDataList.Add(charData2);
				}
			}
		}
		return charDataList;
	}

	[DomainMethod]
	public List<short> GetUnlockedFeastTypeList()
	{
		return DomainManager.Extra.GetUnlockedFeastTypes();
	}

	[DomainMethod]
	public int GetTaiwuVillageResourceBlockEffect(DataContext context, EBuildingScaleEffect effectType)
	{
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		return GetBuildingBlockEffect(taiwuVillageLocation, effectType);
	}

	[DomainMethod]
	public int GetTaiwuLocationResourceBlockEffect(DataContext context, EBuildingScaleEffect effectType)
	{
		Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
		return GetBuildingBlockEffect(location, effectType);
	}

	private int CalcResourceBlockTotalEffectValue(int formulaTemplateId, Span<int> baseValues)
	{
		BuildingFormulaItem formula = BuildingFormula.Instance[formulaTemplateId];
		int total = 0;
		for (int i = 0; i < baseValues.Length; i++)
		{
			total += formula.Calculate(baseValues[i]);
		}
		return total;
	}

	public (ResourceInts resourcesChange, int expGain) CalcResourceBlockIncomeEffects(Location location)
	{
		ResourceInts resources = default(ResourceInts);
		int expGain = 0;
		Span<int> baseValues = stackalloc int[5];
		for (short templateId = 1; templateId < 11; templateId++)
		{
			CalcResourceBlockEffectBaseValues(location, templateId, ref baseValues);
			BuildingBlockItem buildingBlockCfg = BuildingBlock.Instance[templateId];
			List<short> expandInfos = buildingBlockCfg.ExpandInfos;
			if (expandInfos != null && expandInfos.Count > 0)
			{
				foreach (short buildingScaleId in buildingBlockCfg.ExpandInfos)
				{
					BuildingScaleItem buildingScaleCfg = BuildingScale.Instance[buildingScaleId];
					switch (buildingScaleCfg.Class)
					{
					case EBuildingScaleClass.MemberResourceIncome:
					{
						int income2 = CalcResourceBlockTotalEffectValue(buildingScaleCfg.Formula, baseValues);
						resources.Add(buildingScaleCfg.ResourceType, income2);
						break;
					}
					case EBuildingScaleClass.MemberExpIncome:
					{
						int income = CalcResourceBlockTotalEffectValue(buildingScaleCfg.Formula, baseValues);
						expGain += income;
						break;
					}
					}
				}
			}
		}
		return (resourcesChange: resources, expGain: expGain);
	}

	public void CalcResourceBlockEffectBaseValues(Location location, short templateId, ref Span<int> values)
	{
		List<(BuildingBlockKey, int)> blocks = new List<(BuildingBlockKey, int)>();
		GetTopLevelBlocks(templateId, location, blocks, 5);
		for (int i = 0; i < values.Length; i++)
		{
			int percentage = GetPercentage(i);
			values[i] = ((blocks.Count > i) ? (blocks[i].Item2 * percentage / 100) : 0);
		}
		static int GetPercentage(int index)
		{
			return 100 * (5 - index) / 5;
		}
	}

	public void FinalizeResourceBlockIncomeEffectValues(ref ResourceInts resourceChange, bool isTaiwu)
	{
		CValuePercent gainResPercent = DomainManager.World.GetGainResourcePercent((byte)(isTaiwu ? 4 : 12));
		CValuePercent moneyAuthorityPercent = DomainManager.World.GetGainResourcePercent((byte)(isTaiwu ? 5 : 12));
		for (sbyte resourceType = 0; resourceType < 6; resourceType++)
		{
			resourceChange[resourceType] *= gainResPercent;
		}
		for (sbyte resourceType2 = 6; resourceType2 <= 7; resourceType2++)
		{
			resourceChange[resourceType2] *= moneyAuthorityPercent;
		}
	}

	private void InitializeSamsaraPlatform()
	{
		_samsaraPlatformAddMainAttributes.Initialize();
		_samsaraPlatformAddCombatSkillQualifications.Initialize();
		_samsaraPlatformAddLifeSkillQualifications.Initialize();
		for (int i = 0; i < _samsaraPlatformSlots.Length; i++)
		{
			_samsaraPlatformSlots[i] = new IntPair(-1, 0);
		}
	}

	private List<SamsaraPlatformCharDisplayData> GetSamsaraPlatformCharList(DataContext context, bool excludeCharactersInSlot)
	{
		HashSet<int> sourceSet = ObjectPool<HashSet<int>>.Instance.Get();
		HashSet<int> waitingReincarnationChars = ObjectPool<HashSet<int>>.Instance.Get();
		DomainManager.Character.GetAllRelatedDeadCharIds(DomainManager.Taiwu.GetTaiwuCharId(), sourceSet, includeGeneral: false);
		DomainManager.Character.GetTaiwuVillageDeadCharacter(sourceSet);
		DomainManager.Character.GetAllWaitingReincarnationCharIds(waitingReincarnationChars);
		List<SamsaraPlatformCharDisplayData> dataList = sourceSet.Where((int num) => waitingReincarnationChars.Contains(num) && !IsCharOnSamsaraPlatform(num, excludeCharactersInSlot) && !ProfessionSkillHandle.BuddhistMonkSkill_IsDirectedSamsaraCharacter(num) && (!excludeCharactersInSlot || _samsaraPlatformSlots.All((IntPair pair) => pair.First != num))).Select(delegate(int num)
		{
			SamsaraPlatformCharDisplayData samsaraPlatformCharDisplayData = new SamsaraPlatformCharDisplayData();
			SamsaraPlatformCharDisplayData samsaraPlatformCharDisplayData2 = samsaraPlatformCharDisplayData;
			bool flag = !excludeCharactersInSlot;
			bool flag2 = flag;
			IntPair intPair = default(IntPair);
			if (flag2)
			{
				intPair = _samsaraPlatformSlots.FirstOrDefault((IntPair x) => x.First == num);
				bool flag3 = ((intPair.First != 0 || intPair.Second != 0) ? true : false);
				flag2 = flag3;
			}
			samsaraPlatformCharDisplayData2.Progress = ((flag2 && intPair.First != -1) ? intPair.Second : (-1));
			samsaraPlatformCharDisplayData.Data = DomainManager.Character.GetCharacterDisplayDataForGeneralScrollList(context, num);
			samsaraPlatformCharDisplayData.DeadAt = (DomainManager.Character.TryGetDeadCharacter(num, out var character) ? character.DeathDate : DomainManager.World.GetCurrDate());
			return samsaraPlatformCharDisplayData;
		}).ToList();
		if (DomainManager.World.IsExtraTaskInProgress(201) || DomainManager.World.IsExtraTaskInProgress(202))
		{
			DeadCharacter deadCharacter = DomainManager.Character.TryGetDeadCharacterByTemplateId(779);
			if (deadCharacter == null)
			{
				GameData.Domains.Character.Character monk = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 779);
				deadCharacter = DomainManager.Character.SectMainStoryJingangCreateDeadMonk(context, monk);
			}
			int charId = DomainManager.Character.TryGetDeadCharacterIdByTemplateId(779);
			Tester.Assert(charId != -1);
			if (_samsaraPlatformSlots.All((IntPair pair) => pair.First != charId))
			{
				dataList.Add(new SamsaraPlatformCharDisplayData
				{
					Progress = -1,
					Data = DomainManager.Character.GetCharacterDisplayDataForGeneralScrollList(context, charId),
					DeadAt = DomainManager.World.GetCurrDate()
				});
			}
		}
		ObjectPool<HashSet<int>>.Instance.Return(sourceSet);
		ObjectPool<HashSet<int>>.Instance.Return(waitingReincarnationChars);
		return dataList;
	}

	[DomainMethod]
	public List<SamsaraPlatformCharDisplayData> GetSamsaraPlatformCharList(DataContext context)
	{
		return GetSamsaraPlatformCharList(context, excludeCharactersInSlot: false);
	}

	[DomainMethod]
	public void SetSamsaraPlatformChar(DataContext context, sbyte destinyType, int charId)
	{
		SetElement_SamsaraPlatformSlots(destinyType, new IntPair(charId, 0), context);
		if (!DomainManager.World.IsExtraTaskChainInProgress(32))
		{
			return;
		}
		int monkId = DomainManager.Character.TryGetDeadCharacterIdByTemplateId(779);
		bool monkOnSamsaraPlatform = false;
		IntPair[] samsaraPlatformSlots = _samsaraPlatformSlots;
		for (int i = 0; i < samsaraPlatformSlots.Length; i++)
		{
			IntPair item = samsaraPlatformSlots[i];
			if (item.First == monkId)
			{
				monkOnSamsaraPlatform = true;
			}
		}
		if (DomainManager.World.IsExtraTaskInProgress(201) && monkOnSamsaraPlatform)
		{
			DomainManager.World.TriggerExtraTask(context, 32, 202);
		}
		if (DomainManager.World.IsExtraTaskInProgress(202) && !monkOnSamsaraPlatform)
		{
			DomainManager.World.TriggerExtraTask(context, 32, 201);
		}
	}

	[DomainMethod]
	public TransferableRecordDataBase GetReversedSamsaraRecord(DataContext context)
	{
		SamsaraPlatformRecordCollection collection = DomainManager.Extra.GetSamsaraPlatformRecordCollection();
		TransferableRecordDataBase data = new TransferableRecordDataBase();
		collection.ReadDataWithNormalOrder(data, GetParameters);
		LifeRecordDomain.PostProcess(data);
		return data;
		static string[] GetParameters(int recordType)
		{
			SamsaraPlatformRecordItem config = Config.SamsaraPlatformRecord.Instance[recordType];
			if (config != null)
			{
				return config.Parameters ?? Array.Empty<string>();
			}
			AdaptableLog.Warning($"Unable to render SamsaraPlatformRecord with template id {recordType}");
			return null;
		}
	}

	[DomainMethod]
	public CharacterDisplayData SamsaraPlatformReborn(DataContext context, sbyte destinyType)
	{
		IntPair slotInfo = _samsaraPlatformSlots[destinyType];
		if (DomainManager.World.IsExtraTaskInProgress(202) && DomainManager.Character.GetDeadCharacter(slotInfo.First).TemplateId == 779)
		{
			DomainManager.TaiwuEvent.OnEvent_JingangSectMainStoryReborn();
			SamsaraPlatformRecordCollection collection = DomainManager.Extra.GetSamsaraPlatformRecordCollection();
			int date = DomainManager.World.GetCurrDate();
			int charId = slotInfo.First;
			collection.AddSamsaraFailed(date, charId, destinyType);
			DomainManager.Extra.CommitSamsaraPlatformRecord(context);
			SetElement_SamsaraPlatformSlots(destinyType, new IntPair(-1, 0), context);
			return null;
		}
		if (slotInfo.First < 0 || slotInfo.Second < GlobalConfig.Instance.SamsaraPlatformMaxProgress)
		{
			return null;
		}
		DestinyTypeItem destinyConfig = DestinyType.Instance[destinyType];
		bool bornInSect = context.Random.CheckPercentProb(GlobalConfig.Instance.SamsaraPlatformBornInSectOdds);
		List<int> motherRandomPool = ObjectPool<List<int>>.Instance.Get();
		motherRandomPool.Clear();
		if (bornInSect)
		{
			AddSamsaraPlatformSectRandomPool(destinyConfig, motherRandomPool);
		}
		if (motherRandomPool.Count == 0)
		{
			AddSamsaraPlatformCityRandomPool(destinyConfig, motherRandomPool);
		}
		if (motherRandomPool.Count == 0 && !bornInSect)
		{
			AddSamsaraPlatformSectRandomPool(destinyConfig, motherRandomPool);
		}
		int motherId = -1;
		if (motherRandomPool.Count > 0)
		{
			motherId = motherRandomPool[context.Random.Next(motherRandomPool.Count)];
			GameData.Domains.Character.Character mother = DomainManager.Character.GetElement_Objects(motherId);
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			AddElement_SamsaraPlatformBornDict(motherId, new IntPair(slotInfo.First, destinyType), context);
			if (!DomainManager.Character.TryGetPregnantState(motherId, out var _))
			{
				DomainManager.Character.RemovePregnantLock(context, motherId);
				DomainManager.Character.MakePregnantWithoutMale(context, mother);
			}
			switch (destinyType)
			{
			case 0:
				lifeRecordCollection.AddPregnantWithSamsara0(motherId, DomainManager.World.GetCurrDate(), mother.GetLocation());
				break;
			case 1:
				lifeRecordCollection.AddPregnantWithSamsara1(motherId, DomainManager.World.GetCurrDate(), mother.GetLocation());
				break;
			case 2:
				lifeRecordCollection.AddPregnantWithSamsara2(motherId, DomainManager.World.GetCurrDate(), mother.GetLocation());
				break;
			case 3:
				lifeRecordCollection.AddPregnantWithSamsara3(motherId, DomainManager.World.GetCurrDate(), mother.GetLocation());
				break;
			case 4:
				lifeRecordCollection.AddPregnantWithSamsara4(motherId, DomainManager.World.GetCurrDate(), mother.GetLocation());
				break;
			case 5:
				lifeRecordCollection.AddPregnantWithSamsara5(motherId, DomainManager.World.GetCurrDate(), mother.GetLocation());
				break;
			}
		}
		ObjectPool<List<int>>.Instance.Return(motherRandomPool);
		SamsaraPlatformBonusAttributes newPropertyBonus = GetSamsaraPlatformBonusAttributes(slotInfo.First);
		SetSamsaraPlatformAddMainAttributes(newPropertyBonus.MainAttributes, context);
		SetSamsaraPlatformAddCombatSkillQualifications(ref newPropertyBonus.CombatSkillShorts, context);
		SetSamsaraPlatformAddLifeSkillQualifications(ref newPropertyBonus.LifeSkillShorts, context);
		SetElement_SamsaraPlatformSlots(destinyType, new IntPair(-1, 0), context);
		CharacterDisplayData motherData = null;
		if (motherId >= 0)
		{
			OrganizationInfo orgInfo = DomainManager.Character.GetElement_Objects(motherId).GetOrganizationInfo();
			short settlementId = orgInfo.SettlementId;
			motherData = DomainManager.Character.GetCharacterDisplayData(motherId);
			motherData.Location = DomainManager.Organization.GetSettlement(settlementId).GetLocation();
			SamsaraPlatformRecordCollection collection2 = DomainManager.Extra.GetSamsaraPlatformRecordCollection();
			int date2 = DomainManager.World.GetCurrDate();
			int charId2 = slotInfo.First;
			DomainManager.Taiwu.RecordLifeSummary(context, 57);
			DomainManager.World.RequestSetStat(context, 54, 1);
			collection2.AddSamsaraSuccess(date2, charId2, destinyType, settlementId, orgInfo.OrgTemplateId, orgInfo.Grade, orgInfo.Principal, motherData.Gender, motherId);
			DomainManager.Extra.CommitSamsaraPlatformRecord(context);
		}
		DeadCharacter deadChar = DomainManager.Character.GetDeadCharacter(slotInfo.First);
		int sumMainAttributeAndQualifications = deadChar.BaseMainAttributes.GetSum() + deadChar.BaseLifeSkillQualifications.GetSum() + deadChar.BaseCombatSkillQualifications.GetSum();
		int addSeniority = ProfessionFormulaImpl.Calculate(47, sumMainAttributeAndQualifications);
		DomainManager.Extra.ChangeProfessionSeniority(context, 6, addSeniority);
		return motherData;
	}

	[DomainMethod]
	public void SectMainStoryJingangClickMonkSoulBtn(DataContext context)
	{
		DomainManager.TaiwuEvent.OnEvent_JingangSectMainStoryMonkSoul();
	}

	private void AddSamsaraPlatformSectRandomPool(DestinyTypeItem destinyConfig, List<int> motherRandomPool)
	{
		foreach (sbyte sectId in destinyConfig.SectList)
		{
			OrgMemberCollection members = DomainManager.Organization.GetSettlementByOrgTemplateId(sectId).GetMembers();
			sbyte[] organizationGradeRange = destinyConfig.OrganizationGradeRange;
			foreach (sbyte grade in organizationGradeRange)
			{
				HashSet<int> memberSet = members.GetMembers(grade);
				foreach (int charId in memberSet)
				{
					if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && DomainManager.Character.CanSelectForForcePregnancy(character))
					{
						motherRandomPool.Add(charId);
					}
				}
			}
		}
	}

	private void AddSamsaraPlatformCityRandomPool(DestinyTypeItem destinyConfig, List<int> motherRandomPool)
	{
		List<Settlement> settlements = new List<Settlement>();
		DomainManager.Organization.GetAllCivilianSettlements(settlements);
		for (int i = 0; i < settlements.Count; i++)
		{
			OrgMemberCollection members = settlements[i].GetMembers();
			sbyte[] organizationGradeRange = destinyConfig.OrganizationGradeRange;
			foreach (sbyte grade in organizationGradeRange)
			{
				HashSet<int> memberSet = members.GetMembers(grade);
				foreach (int charId in memberSet)
				{
					if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && DomainManager.Character.CanSelectForForcePregnancy(character))
					{
						motherRandomPool.Add(charId);
					}
				}
			}
		}
	}

	private void AddSamsaraPlatformProgress(DataContext context, sbyte level)
	{
		HashSet<int> relatedChars = ObjectPool<HashSet<int>>.Instance.Get();
		DomainManager.Character.GetAllRelatedDeadCharIds(DomainManager.Taiwu.GetTaiwuCharId(), relatedChars, includeGeneral: false);
		for (int i = 0; i < _samsaraPlatformSlots.Length; i++)
		{
			IntPair slotInfo = _samsaraPlatformSlots[i];
			if (slotInfo.First >= 0)
			{
				slotInfo.Second = Math.Min(slotInfo.Second + level, GlobalConfig.Instance.SamsaraPlatformMaxProgress);
				if (DomainManager.World.IsExtraTaskInProgress(202) && DomainManager.Character.GetDeadCharacter(slotInfo.First).TemplateId == 779)
				{
					slotInfo.Second = 1;
				}
				if (relatedChars.Contains(slotInfo.First) && slotInfo.Second >= GlobalConfig.Instance.SamsaraPlatformMaxProgress)
				{
					DomainManager.World.GetInstantNotificationCollection().AddReincarnationArchitectureReincarnationEnd(slotInfo.First);
				}
				SetElement_SamsaraPlatformSlots(i, slotInfo, context);
			}
		}
	}

	public bool IsCharOnSamsaraPlatform(int charId, bool checkSlots = true)
	{
		if (checkSlots)
		{
			for (int i = 0; i < _samsaraPlatformSlots.Length; i++)
			{
				if (_samsaraPlatformSlots[i].First == charId)
				{
					return true;
				}
			}
		}
		foreach (IntPair value in _samsaraPlatformBornDict.Values)
		{
			if (value.First == charId)
			{
				return true;
			}
		}
		return false;
	}

	public void TryRemoveSamsaraPlatformBornData(DataContext context, int motherId)
	{
		if (_samsaraPlatformBornDict.ContainsKey(motherId))
		{
			RemoveElement_SamsaraPlatformBornDict(motherId, context);
		}
	}

	[DomainMethod]
	public List<SamsaraPlatformCharDisplayData> GetSwapSoulCeremonySoulCharIdList(DataContext context)
	{
		return GetSamsaraPlatformCharList(context, excludeCharactersInSlot: true);
	}

	[DomainMethod]
	public List<int> GetSwapSoulCeremonyBodyCharIdList()
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		HashSet<int> charIdHashSet = new HashSet<int>();
		OrgMemberCollection memberCollection = DomainManager.Organization.GetSettlementByOrgTemplateId(16).GetMembers();
		List<int> taiwuVillagerList = new List<int>();
		memberCollection.GetAllMembers(taiwuVillagerList);
		charIdHashSet.UnionWith(taiwuVillagerList);
		CharacterSet charSet = DomainManager.Taiwu.GetGroupCharIds();
		if (charSet.GetCount() > 0)
		{
			charIdHashSet.UnionWith(charSet.GetCollection());
		}
		if (DomainManager.Character.TryGetKidnappedCharacters(taiwuCharId, out var kidnappedCharacterList))
		{
			charIdHashSet.UnionWith(kidnappedCharacterList.GetCollection().ConvertAll((KidnappedCharacter e) => e.CharId));
		}
		charIdHashSet.RemoveWhere(delegate(int e)
		{
			if (e == taiwuCharId)
			{
				return true;
			}
			GameData.Domains.Character.Character element;
			return !DomainManager.Character.TryGetElement_Objects(e, out element) || element.GetAgeGroup() != 2;
		});
		List<int> result = new List<int>();
		result.AddRange(charIdHashSet);
		return result;
	}

	[DomainMethod]
	public byte TrySwapSoulCeremony(DataContext context, List<int> soulCharIds, int bodyCharId, List<short> featureIds)
	{
		DeadCharacter deadCharacter;
		GameData.Domains.Character.Character bodyCharacter;
		byte result = GetPossessionResult(context, soulCharIds, bodyCharId, out deadCharacter, out bodyCharacter);
		if (result != PossessionResult.Success)
		{
			return result;
		}
		int temporaryPossessionCharId = -1;
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		if (!argBox.Get("TemporaryPossessionCharId", ref temporaryPossessionCharId) || !DomainManager.Character.TryGetElement_Objects(temporaryPossessionCharId, out var temp))
		{
			return PossessionResult.InvalidBodyCharId;
		}
		DomainManager.Character.Possession(context, bodyCharId, deadCharacter, bodyCharacter, new AvatarData(temp.GetAvatar()), featureIds);
		for (int i = 0; i < soulCharIds.Count; i++)
		{
			DomainManager.Character.PossessionRemoveWaitingReincarnationChar(context, soulCharIds[i]);
		}
		DomainManager.Extra.RecordPossessionData(context, bodyCharId, new PossessionData(soulCharIds));
		sbyte maxSoulAlreadyAddCount = 0;
		for (int j = 0; j < soulCharIds.Count; j++)
		{
			DomainManager.Extra.TryGetElement_TaiwuVillagerPotentialData(soulCharIds[j], out var soulAlreadyAddCount);
			maxSoulAlreadyAddCount = Math.Max(maxSoulAlreadyAddCount, soulAlreadyAddCount);
		}
		DomainManager.Extra.UpdateTaiwuVillagerPotentialData(context, bodyCharId, maxSoulAlreadyAddCount);
		DomainManager.Taiwu.RecordMergingTrace(context, soulCharIds, bodyCharId);
		RemoveTemporaryPossessionCharacter(context);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Character, new List<int> { bodyCharacter.GetId() }, (sbyte)15);
		DomainManager.Taiwu.RecordLifeSummary(context, 68);
		return result;
	}

	[DomainMethod]
	public PossessionPreview GetPossessionPreview(DataContext context, List<int> soulCharIds, int bodyCharId, List<short> featureIds, int previewId)
	{
		DeadCharacter deadCharacter;
		GameData.Domains.Character.Character bodyCharacter;
		PossessionPreview preview = new PossessionPreview
		{
			Result = GetPossessionResult(context, soulCharIds, bodyCharId, out deadCharacter, out bodyCharacter)
		};
		if (preview.Result != PossessionResult.Success)
		{
			return preview;
		}
		if (!DomainManager.Character.TryGetElement_Objects(previewId, out var temporaryCharacter))
		{
			RemoveTemporaryPossessionCharacter(context);
			temporaryCharacter = DomainManager.Character.CreateTemporaryCopyOfCharacter(context, bodyCharacter);
		}
		int temporaryPossessionCharId = temporaryCharacter.GetId();
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		argBox.Set("TemporaryPossessionCharId", temporaryPossessionCharId);
		DomainManager.Extra.SaveSectMainStoryEventArgumentBox(context, 11);
		DomainManager.Character.Possession(context, temporaryPossessionCharId, deadCharacter, temporaryCharacter, null, featureIds);
		preview.Id = temporaryPossessionCharId;
		preview.BirthDate = temporaryCharacter.GetBirthDate();
		preview.Health = temporaryCharacter.GetHealth();
		preview.Gender = temporaryCharacter.GetGender();
		preview.BaseMorality = temporaryCharacter.GetBaseMorality();
		preview.Happiness = temporaryCharacter.GetHappiness();
		preview.Fame = temporaryCharacter.GetFame();
		preview.Personalities = temporaryCharacter.GetPersonalities();
		preview.BirthFeatureId = temporaryCharacter.GetGroupFeature(184);
		preview.FeatureIds = new List<short>();
		preview.BaseMainAttributes = deadCharacter.BaseMainAttributes;
		preview.BaseLifeSkillQualifications = deadCharacter.BaseLifeSkillQualifications;
		preview.BaseCombatSkillQualifications = deadCharacter.BaseCombatSkillQualifications;
		preview.ConsummateLevel = temporaryCharacter.GetConsummateLevel();
		preview.NeiliAllocation = temporaryCharacter.GetNeiliAllocation();
		preview.CurrNeili = temporaryCharacter.GetCurrNeili();
		preview.BaseNeiliProportionOfFiveElements = temporaryCharacter.GetBaseNeiliProportionOfFiveElements();
		preview.CharacterSamsaraData = DomainManager.Character.GetCharacterSamsaraData(temporaryPossessionCharId);
		foreach (short featureId in temporaryCharacter.GetFeatureIds())
		{
			if (CharacterFeature.Instance[featureId].MutexGroupId != 184)
			{
				preview.FeatureIds.Add(featureId);
			}
		}
		preview.Age = temporaryCharacter.QualificationAge;
		return preview;
	}

	public unsafe byte GetPossessionResult(DataContext context, List<int> soulCharIds, int bodyCharId, out DeadCharacter deadCharacter, out GameData.Domains.Character.Character bodyCharacter, bool mustGetKidnapped = false)
	{
		deadCharacter = null;
		bodyCharacter = null;
		bool hasValidSoul = false;
		for (int i = 0; i < soulCharIds.Count; i++)
		{
			if (DomainManager.Character.TryGetDeadCharacter(soulCharIds[i], out var _))
			{
				hasValidSoul = true;
				break;
			}
		}
		if (!hasValidSoul)
		{
			return PossessionResult.InvalidSoulCharId;
		}
		if (!DomainManager.Character.TryGetElement_Objects(bodyCharId, out bodyCharacter))
		{
			return PossessionResult.InvalidBodyCharId;
		}
		if (mustGetKidnapped)
		{
			if (!DomainManager.Character.TryGetKidnappedCharacters(DomainManager.Taiwu.GetTaiwuCharId(), out var list))
			{
				return PossessionResult.BodyCharNotKidnappedByTaiwu;
			}
			bool isBodyCharKidnappedByTaiwu = false;
			foreach (KidnappedCharacter victim in list.GetCollection())
			{
				if (victim.CharId == bodyCharId)
				{
					isBodyCharKidnappedByTaiwu = true;
					break;
				}
			}
			if (!isBodyCharKidnappedByTaiwu)
			{
				return PossessionResult.BodyCharNotKidnappedByTaiwu;
			}
		}
		MainAttributes maxMainAttributes = default(MainAttributes);
		CombatSkillShorts maxCombatSkillQualifications = default(CombatSkillShorts);
		LifeSkillShorts maxLifeSkillQualifications = default(LifeSkillShorts);
		maxMainAttributes.Initialize();
		maxCombatSkillQualifications.Initialize();
		maxLifeSkillQualifications.Initialize();
		List<DeadCharacter> validDeadCharacters = new List<DeadCharacter>();
		sbyte maxHappiness = sbyte.MinValue;
		deadCharacter = new DeadCharacter();
		deadCharacter.FeatureIds = new List<short>();
		for (int j = 0; j < soulCharIds.Count; j++)
		{
			if (DomainManager.Character.TryGetDeadCharacter(soulCharIds[j], out var deadChar))
			{
				if (j == 0)
				{
					deadCharacter.BirthDate = deadChar.BirthDate;
					deadCharacter.DeathDate = deadChar.DeathDate;
				}
				validDeadCharacters.Add(deadChar);
				for (int k = 0; k < 6; k++)
				{
					maxMainAttributes.Items[k] = Math.Max(maxMainAttributes.Items[k], deadChar.BaseMainAttributes.Items[k]);
				}
				for (int l = 0; l < 14; l++)
				{
					maxCombatSkillQualifications.Items[l] = Math.Max(maxCombatSkillQualifications.Items[l], deadChar.BaseCombatSkillQualifications.Items[l]);
				}
				for (int m = 0; m < 16; m++)
				{
					maxLifeSkillQualifications.Items[m] = Math.Max(maxLifeSkillQualifications.Items[m], deadChar.BaseLifeSkillQualifications.Items[m]);
				}
				maxHappiness = Math.Max(maxHappiness, deadChar.Happiness);
				deadCharacter.FeatureIds.AddRange(deadChar.FeatureIds);
			}
		}
		deadCharacter.BaseMainAttributes = maxMainAttributes;
		deadCharacter.BaseCombatSkillQualifications = maxCombatSkillQualifications;
		deadCharacter.BaseLifeSkillQualifications = maxLifeSkillQualifications;
		deadCharacter.Happiness = maxHappiness;
		if (validDeadCharacters.Count > 0)
		{
			context.SwitchRandomSource((ulong)(((long)(bodyCharId ^ deadCharacter.BirthDate) << 32) ^ deadCharacter.DeathDate));
			int randomIndex = context.Random.Next(validDeadCharacters.Count);
			deadCharacter.Morality = validDeadCharacters[randomIndex].Morality;
			context.SwitchRandomSource(0uL);
			PreexistenceCharIds merged = default(PreexistenceCharIds);
			merged.Reset();
			bool* used = stackalloc bool[9];
			foreach (DeadCharacter deadChar2 in validDeadCharacters)
			{
				PreexistenceCharIds prev = deadChar2.PreexistenceCharIds;
				for (int n = 0; n < prev.Count; n++)
				{
					if (!used[n])
					{
						used[n] = true;
						merged.CharIds[merged.Count++] = prev.CharIds[n];
					}
				}
			}
			deadCharacter.PreexistenceCharIds = merged;
		}
		return PossessionResult.Success;
	}

	[DomainMethod]
	public void SetTemporaryPossessionCharacterAvatar(DataContext context, AvatarData avatar)
	{
		int temporaryPossessionCharId = -1;
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		if (argBox.Get("TemporaryPossessionCharId", ref temporaryPossessionCharId) && DomainManager.Character.TryGetElement_Objects(temporaryPossessionCharId, out var character))
		{
			character.SetAvatar(avatar, context);
		}
	}

	public void RemoveTemporaryPossessionCharacter(DataContext context)
	{
		int temporaryPossessionCharId = -1;
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		if (argBox.Get("TemporaryPossessionCharId", ref temporaryPossessionCharId) && DomainManager.Character.TryGetElement_Objects(temporaryPossessionCharId, out var character))
		{
			DomainManager.Character.RemoveTemporaryIntelligentCharacter(context, character);
			argBox.Set("TemporaryPossessionCharId", -1);
			DomainManager.Extra.SaveSectMainStoryEventArgumentBox(context, 11);
		}
	}

	[DomainMethod]
	public SamsaraPlatformRecordCollection GetSamsaraPlatformRecord()
	{
		return DomainManager.Extra.GetSamsaraPlatformRecordCollection();
	}

	[DomainMethod]
	public SamsaraPlatformCharDisplayData GetSamsaraPlatformCharDisplayData(DataContext context, sbyte slot)
	{
		DeadCharacter character;
		return new SamsaraPlatformCharDisplayData
		{
			Progress = _samsaraPlatformSlots[slot].Second,
			Data = DomainManager.Character.GetCharacterDisplayDataForGeneralScrollList(context, _samsaraPlatformSlots[slot].First),
			DeadAt = (DomainManager.Character.TryGetDeadCharacter(_samsaraPlatformSlots[slot].First, out character) ? character.DeathDate : DomainManager.World.GetCurrDate())
		};
	}

	[DomainMethod]
	public SamsaraPlatformBonusAttributes GetSamsaraPlatformBonusAttributes(int charId = -1)
	{
		SamsaraPlatformBonusAttributes ret = new SamsaraPlatformBonusAttributes
		{
			MainAttributes = _samsaraPlatformAddMainAttributes,
			CombatSkillShorts = _samsaraPlatformAddCombatSkillQualifications,
			LifeSkillShorts = _samsaraPlatformAddLifeSkillQualifications
		};
		if (!DomainManager.Character.TryGetDeadCharacter(charId, out var deadChar))
		{
			return ret;
		}
		foreach (BuildingBlockKey samsaraPlatformKey in from location in GetTaiwuBuildingAreas()
			select FindBuildingKey(location, GetElement_BuildingAreas(location), 50))
		{
			if (samsaraPlatformKey.IsInvalid || !DomainManager.Building.TryGetElement_BuildingBlocks(samsaraPlatformKey, out var buildingBlockData))
			{
				continue;
			}
			int addPercent = GlobalConfig.Instance.SamsaraPlatformAddBasePercent + GlobalConfig.Instance.SamsaraPlatformAddPercentPerLevel * buildingBlockData.CalcUnlockedLevelCount();
			for (int i = 0; i < 6; i++)
			{
				ret.MainAttributes[i] = (short)Math.Max(ret.MainAttributes[i], deadChar.BaseMainAttributes[i] * addPercent / 100);
			}
			for (int i2 = 0; i2 < 14; i2++)
			{
				ret.CombatSkillShorts[i2] = (short)Math.Max(ret.CombatSkillShorts[i2], deadChar.BaseCombatSkillQualifications[i2] * addPercent / 100);
			}
			for (int i3 = 0; i3 < 16; i3++)
			{
				ret.LifeSkillShorts[i3] = (short)Math.Max(ret.LifeSkillShorts[i3], deadChar.BaseLifeSkillQualifications[i3] * addPercent / 100);
			}
			return ret;
		}
		return ret;
	}

	[DomainMethod]
	public ShopEventCollection GetOrCreateShopEventCollection(BuildingBlockKey buildingBlockKey)
	{
		if (_shopEventCollections == null)
		{
			_shopEventCollections = new Dictionary<BuildingBlockKey, ShopEventCollection>();
		}
		if (_shopEventCollections.TryGetValue(buildingBlockKey, out var shopEventCollection))
		{
			return shopEventCollection;
		}
		shopEventCollection = new ShopEventCollection();
		_shopEventCollections.Add(buildingBlockKey, shopEventCollection);
		return shopEventCollection;
	}

	[DomainMethod]
	public bool HasShopManagerLeader(BuildingBlockKey blockKey)
	{
		if (!_buildingBlocks.TryGetValue(blockKey, out var blockData) || blockData.TemplateId < 0)
		{
			return false;
		}
		return GetShopManagerLeader(blockKey) != null || !blockData.ConfigData.NeedLeader;
	}

	public IReadOnlyDictionary<BuildingBlockKey, CharacterList> GetShopManagerDict()
	{
		return _shopManagerDict;
	}

	public GameData.Domains.Character.Character GetShopManagerLeader(BuildingBlockKey blockKey)
	{
		if (!_shopManagerDict.TryGetValue(blockKey, out var characterList) || characterList.GetCount() == 0)
		{
			return null;
		}
		List<int> collection = characterList.GetCollection();
		int charId = collection[0];
		GameData.Domains.Character.Character character;
		return DomainManager.Character.TryGetElement_Objects(charId, out character) ? character : null;
	}

	[DomainMethod]
	public void SetShopManager(DataContext context, BuildingBlockKey blockKey, sbyte index, int charId)
	{
		bool allowChild = index != 0;
		if (_shopManagerDict.ContainsKey(blockKey))
		{
			int currCharId = _shopManagerDict[blockKey].GetCollection()[index];
			if (currCharId == -1 && charId == -1)
			{
				return;
			}
			if (currCharId == charId)
			{
				throw new Exception($"Same shop manager already exist, id: {charId}");
			}
			if (currCharId >= 0)
			{
				DomainManager.Taiwu.RemoveVillagerWork(context, currCharId);
			}
		}
		if (charId >= 0)
		{
			VillagerWorkData workData = new VillagerWorkData(charId, 1, blockKey.AreaId, blockKey.BlockId);
			workData.BuildingBlockIndex = blockKey.BuildingBlockIndex;
			workData.WorkerIndex = index;
			DomainManager.Taiwu.SetVillagerWork(context, charId, workData, allowChild);
		}
		if (DomainManager.Building.TryGetElement_BuildingBlocks(blockKey, out var blockData))
		{
			BuildingBlockItem config = BuildingBlock.Instance[blockData.TemplateId];
			if (SharedMethods.HasEffect(config))
			{
				_needUpdateEffects = true;
			}
		}
	}

	[DomainMethod]
	public void SetCollectBuildingResourceType(DataContext context, BuildingBlockKey blockKey, sbyte resourceType)
	{
		if (_CollectBuildingResourceType.ContainsKey(blockKey))
		{
			SetElement_CollectBuildingResourceType(blockKey, resourceType, context);
		}
		else
		{
			AddElement_CollectBuildingResourceType(blockKey, resourceType, context);
		}
	}

	[DomainMethod]
	public void ClearBuildingBlockEarningsData(DataContext context, BuildingBlockKey key, bool isPawnShop, bool clearOutputSetting = true)
	{
		if (TryGetElement_CollectBuildingEarningsData(key, out var data))
		{
			foreach (ItemKey itemKey in data.ShopSoldItemList)
			{
				if (itemKey.IsValid())
				{
					DomainManager.Item.GetBaseItem(itemKey).ResetOwner();
					DomainManager.Taiwu.WarehouseAdd(context, itemKey, 1);
				}
			}
			foreach (ItemKey itemKey2 in data.FixBookInfoList)
			{
				if (itemKey2.IsValid())
				{
					DomainManager.Item.GetBaseItem(itemKey2).ResetOwner();
					DomainManager.Taiwu.WarehouseAdd(context, itemKey2, 1);
				}
			}
			if (!isPawnShop)
			{
				foreach (ItemKey itemKey3 in data.CollectionItemList)
				{
					if (itemKey3.IsValid())
					{
						ItemBase item = DomainManager.Item.GetBaseItem(itemKey3);
						item.ResetOwner();
						ItemSourceType sourceType = ApplyBuildingItemOutputSetting(key, itemKey3);
						DomainManager.Taiwu.AddItem(context, item.GetItemKey(), 1, sourceType);
					}
				}
			}
			foreach (IntPair earn in data.ShopSoldItemEarnList)
			{
				if (earn.First == 6)
				{
					DomainManager.Taiwu.GetTaiwu().ChangeResource(context, 6, earn.Second);
					ApplyBuildingResourceOutputSetting(context, key, (sbyte)earn.First, earn.Second);
				}
				if (earn.First == 7)
				{
					DomainManager.Taiwu.GetTaiwu().ChangeResource(context, 7, earn.Second);
				}
			}
			foreach (IntPair earn2 in data.CollectionResourceList)
			{
				if (earn2.First == 6)
				{
					DomainManager.Taiwu.GetTaiwu().ChangeResource(context, 6, earn2.Second);
					ApplyBuildingResourceOutputSetting(context, key, (sbyte)earn2.First, earn2.Second);
				}
				if (earn2.First == 7)
				{
					DomainManager.Taiwu.GetTaiwu().ChangeResource(context, 7, earn2.Second);
				}
			}
		}
		if (_shopManagerDict.ContainsKey(key))
		{
			RemoveElement_ShopManagerDict(key, context);
		}
		if (_collectBuildingEarningsData.ContainsKey(key))
		{
			RemoveElement_CollectBuildingEarningsData(key, context);
		}
		if (clearOutputSetting)
		{
			RemoveBuildingResourceOutputSetting(context, key.BuildingBlockIndex);
		}
	}

	private BuildingOptionAutoGiveMemberPreset GetArrangementSetting(BuildingBlockKey blockKey)
	{
		return GetElement_BuildingBlocks(blockKey)?.ArrangementSetting ?? new BuildingOptionAutoGiveMemberPreset();
	}

	private void GetBaseArrangementVillagerList(BuildingBlockKey blockKey, out List<int> roleVillagersForWork, out List<int> noRoleVillagersForWork)
	{
		BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
		List<int> villagersForWork = DomainManager.Taiwu.GetVillagersForWork(includeUnlockedWorkingVillagers: true);
		List<int> haveRoleVillagerIds = new List<int>();
		if (blockData.ConfigData.VillagerRoleTemplateIds != null)
		{
			short[] villagerRoleTemplateIds = blockData.ConfigData.VillagerRoleTemplateIds;
			foreach (short villagerRoleTemplateId in villagerRoleTemplateIds)
			{
				DomainManager.Extra.GetVillagerRoleCharactersByTemplateId(villagerRoleTemplateId, ref haveRoleVillagerIds);
			}
		}
		roleVillagersForWork = new List<int>();
		noRoleVillagersForWork = new List<int>();
		foreach (int charId in villagersForWork)
		{
			if (haveRoleVillagerIds.Contains(charId))
			{
				roleVillagersForWork.Add(charId);
			}
			else
			{
				noRoleVillagersForWork.Add(charId);
			}
		}
	}

	private void SortByAttainment(BuildingBlockItem buildingConfig, ref List<int> ids)
	{
		ids.Sort(delegate(int idLeft, int idRight)
		{
			GameData.Domains.Character.Character element_Objects = DomainManager.Character.GetElement_Objects(idLeft);
			GameData.Domains.Character.Character element_Objects2 = DomainManager.Character.GetElement_Objects(idRight);
			if (buildingConfig.RequireLifeSkillType >= 0)
			{
				return element_Objects2.GetLifeSkillAttainment(buildingConfig.RequireLifeSkillType) - element_Objects.GetLifeSkillAttainment(buildingConfig.RequireLifeSkillType);
			}
			return (buildingConfig.RequireCombatSkillType >= 0) ? (element_Objects2.GetCombatSkillAttainment(buildingConfig.RequireCombatSkillType) - element_Objects.GetCombatSkillAttainment(buildingConfig.RequireCombatSkillType)) : 0;
		});
	}

	private void SortByQualifications(BuildingBlockItem buildingConfig, ref List<int> ids, bool descending = true)
	{
		ids.Sort(delegate(int idLeft, int idRight)
		{
			GameData.Domains.Character.Character element_Objects = DomainManager.Character.GetElement_Objects(idLeft);
			GameData.Domains.Character.Character element_Objects2 = DomainManager.Character.GetElement_Objects(idRight);
			int num = 0;
			if (buildingConfig.RequireLifeSkillType >= 0)
			{
				num = element_Objects2.GetLifeSkillQualification(buildingConfig.RequireLifeSkillType) - element_Objects.GetLifeSkillQualification(buildingConfig.RequireLifeSkillType);
			}
			else if (buildingConfig.RequireCombatSkillType >= 0)
			{
				num = element_Objects2.GetCombatSkillQualification(buildingConfig.RequireCombatSkillType) - element_Objects.GetCombatSkillQualification(buildingConfig.RequireCombatSkillType);
			}
			return descending ? num : (-num);
		});
	}

	private void SortByReadBookTotalValue(BuildingBlockItem buildingConfig, ref List<int> ids, bool descending = true)
	{
		ids.Sort(delegate(int idLeft, int idRight)
		{
			GameData.Domains.Character.Character element_Objects = DomainManager.Character.GetElement_Objects(idLeft);
			GameData.Domains.Character.Character element_Objects2 = DomainManager.Character.GetElement_Objects(idRight);
			int num = 0;
			if (buildingConfig.RequireLifeSkillType >= 0)
			{
				num = element_Objects2.GetLearnedLifeSkillTotalValue(buildingConfig.RequireLifeSkillType) - element_Objects.GetLearnedLifeSkillTotalValue(buildingConfig.RequireLifeSkillType);
			}
			else if (buildingConfig.RequireCombatSkillType >= 0)
			{
				num = element_Objects2.GetLearnedCombatSkillTotalValue(buildingConfig.RequireCombatSkillType) - element_Objects.GetLearnedCombatSkillTotalValue(buildingConfig.RequireCombatSkillType);
			}
			return descending ? num : (-num);
		});
	}

	private void GetLeaderArrangementVillagerList(BuildingBlockKey blockKey, out List<int> villagersForWork)
	{
		BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
		BuildingOptionAutoGiveMemberPreset presetData = GetArrangementSetting(blockKey);
		if (!presetData.GetIsInfluenceLeader())
		{
			villagersForWork = null;
			return;
		}
		GetBaseArrangementVillagerList(blockKey, out var roleVillagersForWork, out var noRoleVillagersForWork);
		BuildingOptionAutoGiveMemberPreset.RoleRule roleRuleForLeader = (BuildingOptionAutoGiveMemberPreset.RoleRule)presetData.RoleRuleForLeader;
		if (roleRuleForLeader.HasFlag(BuildingOptionAutoGiveMemberPreset.RoleRule.OnlyRole))
		{
			noRoleVillagersForWork.Clear();
		}
		villagersForWork = roleVillagersForWork.Concat(noRoleVillagersForWork).Distinct().ToList();
		switch ((BuildingOptionAutoGiveMemberPreset.PickRule)presetData.PickRuleForLeader)
		{
		case BuildingOptionAutoGiveMemberPreset.PickRule.ManageFirst:
			SortByAttainment(blockData.ConfigData, ref villagersForWork);
			break;
		case BuildingOptionAutoGiveMemberPreset.PickRule.QualificationFirst:
			SortByQualifications(blockData.ConfigData, ref villagersForWork);
			break;
		case BuildingOptionAutoGiveMemberPreset.PickRule.ReadingFirst:
			SortByReadBookTotalValue(blockData.ConfigData, ref villagersForWork);
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private void GetMemberArrangementVillagerList(BuildingBlockKey blockKey, out List<int> villagersForWork)
	{
		BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
		BuildingOptionAutoGiveMemberPreset presetData = GetArrangementSetting(blockKey);
		if (!presetData.GetIsInfluenceMember())
		{
			villagersForWork = null;
			return;
		}
		GetBaseArrangementVillagerList(blockKey, out var roleVillagersForWork, out var noRoleVillagersForWork);
		BuildingOptionAutoGiveMemberPreset.RoleRule roleRuleForMember = (BuildingOptionAutoGiveMemberPreset.RoleRule)presetData.RoleRuleForMember;
		if (roleRuleForMember.HasFlag(BuildingOptionAutoGiveMemberPreset.RoleRule.AllowChild))
		{
			List<int> childAvailableForWork = DomainManager.Taiwu.GetAllChildAvailableForWork(actuallyNotOccupiedOnly: true);
			noRoleVillagersForWork.AddRange(childAvailableForWork);
		}
		if (roleRuleForMember.HasFlag(BuildingOptionAutoGiveMemberPreset.RoleRule.NotAllowRole))
		{
			roleVillagersForWork.Clear();
			noRoleVillagersForWork.RemoveAll((int id) => DomainManager.Extra.GetVillagerRole(id) != null);
		}
		if (!roleRuleForMember.HasFlag(BuildingOptionAutoGiveMemberPreset.RoleRule.AllowNoPotential))
		{
			roleVillagersForWork.RemoveAll((int id) => DomainManager.Taiwu.GetTaiwuVillagerLeftPotentialCount(id) == 0);
			noRoleVillagersForWork.RemoveAll((int id) => DomainManager.Taiwu.GetTaiwuVillagerLeftPotentialCount(id) == 0);
		}
		if (!roleRuleForMember.HasFlag(BuildingOptionAutoGiveMemberPreset.RoleRule.AllowNoReadableBook))
		{
			roleVillagersForWork.RemoveAll(Match);
			noRoleVillagersForWork.RemoveAll(Match);
		}
		villagersForWork = roleVillagersForWork.Concat(noRoleVillagersForWork).Distinct().ToList();
		switch ((BuildingOptionAutoGiveMemberPreset.PickRule)presetData.PickRuleForMember)
		{
		case BuildingOptionAutoGiveMemberPreset.PickRule.ManageFirst:
			SortByAttainment(blockData.ConfigData, ref villagersForWork);
			break;
		case BuildingOptionAutoGiveMemberPreset.PickRule.QualificationMax:
			SortByQualifications(blockData.ConfigData, ref villagersForWork);
			break;
		case BuildingOptionAutoGiveMemberPreset.PickRule.QualificationFirst:
			SortByQualifications(blockData.ConfigData, ref villagersForWork, descending: false);
			break;
		case BuildingOptionAutoGiveMemberPreset.PickRule.ReadingFirst:
			SortByReadBookTotalValue(blockData.ConfigData, ref villagersForWork, descending: false);
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		bool Match(int id)
		{
			ShopBuildingTeachBookData teachBookData = GetShopBuildingTeachBookData(blockKey, id);
			sbyte teachBookResult = teachBookData.TeachBookResult;
			if ((uint)(teachBookResult - 3) <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	[DomainMethod]
	public List<int> QuickArrangeShopManager(DataContext context, BuildingBlockKey blockKey, bool onlyCheck = false)
	{
		BuildingOptionAutoGiveMemberPreset presetData = GetArrangementSetting(blockKey);
		List<int> charIds = new List<int>();
		for (sbyte index = 0; index < 7; index++)
		{
			charIds.Add(-1);
			if ((presetData.GetIsInfluenceLeader() || index != 0) && (presetData.GetIsInfluenceMember() || index == 0) && !onlyCheck)
			{
				SetShopManager(context, blockKey, index, -1);
			}
		}
		if (presetData.GetIsInfluenceLeader())
		{
			GetLeaderArrangementVillagerList(blockKey, out var villagersForWork);
			bool unlockChar = !presetData.LockCharForLeader;
			FillLeaders(ref villagersForWork, ref charIds, unlockChar);
		}
		if (presetData.GetIsInfluenceMember())
		{
			GetMemberArrangementVillagerList(blockKey, out var villagersForWork2);
			int leaderIndex = 0;
			villagersForWork2.RemoveAll((int id) => charIds[leaderIndex] == id);
			bool unlockChar2 = !presetData.LockCharForMember;
			int count = presetData.Amount;
			FillMembers(ref count, ref villagersForWork2, ref charIds, unlockChar2);
		}
		return charIds;
		void FillLeaders(ref List<int> availableList, ref List<int> targetList, bool unlock)
		{
			if (availableList.Count > 0 && targetList[0] < 0)
			{
				int removeIndex = 0;
				int leaderId = availableList[removeIndex];
				availableList.RemoveAt(removeIndex);
				targetList[0] = leaderId;
				if (!onlyCheck)
				{
					SetShopManager(context, blockKey, 0, leaderId);
					SetUnlockedWorkingVillagers(context, leaderId, unlock);
				}
			}
		}
		void FillMembers(ref int reference, ref List<int> availableList, ref List<int> targetList, bool unlock)
		{
			if (availableList.Count > 0)
			{
				int removeIndex = 0;
				for (sbyte i = 1; i < targetList.Count; i++)
				{
					int id = targetList[i];
					if (id < 0)
					{
						if (reference <= 0 || availableList.Count <= 0)
						{
							break;
						}
						int memberId = availableList[removeIndex];
						availableList.RemoveAt(removeIndex);
						targetList[i] = memberId;
						reference--;
						if (!onlyCheck)
						{
							SetShopManager(context, blockKey, i, memberId);
							SetUnlockedWorkingVillagers(context, memberId, unlock);
						}
					}
				}
			}
		}
	}

	[DomainMethod]
	public bool CanQuickArrangeShopManager(BuildingBlockKey blockKey)
	{
		_shopManagerDict.TryGetValue(blockKey, out var characterList);
		List<int> collection = characterList.GetCollection();
		List<int> tempList = QuickArrangeShopManager(null, blockKey, onlyCheck: true);
		if (tempList == null)
		{
			return false;
		}
		foreach (int id in tempList)
		{
			if (id >= 0 && id != collection.GetOrDefault(-1))
			{
				return true;
			}
		}
		return false;
	}

	[DomainMethod]
	public List<int> QuickArrangeBuildOperator(short buildingTemplateId, BuildingBlockKey blockKey, sbyte operationType, List<int> exceptCharList = null)
	{
		int needValue = 0;
		BuildingBlockItem buildingConfig = null;
		if (operationType == 0)
		{
			buildingConfig = BuildingBlock.Instance[buildingTemplateId];
			needValue = buildingConfig.OperationTotalProgress[operationType];
		}
		else
		{
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			buildingConfig = BuildingBlock.Instance[blockData.TemplateId];
			needValue = buildingConfig.OperationTotalProgress[operationType] - blockData.OperationProgress;
		}
		List<int> charIds = new List<int>();
		for (sbyte index = 0; index < 3; index++)
		{
			charIds.Add(-1);
		}
		List<int> villagersForWork = DomainManager.Taiwu.GetVillagersForWork(includeUnlockedWorkingVillagers: true);
		if (exceptCharList != null && exceptCharList.Count > 0)
		{
			foreach (int charId in exceptCharList)
			{
				villagersForWork.Remove(charId);
			}
		}
		villagersForWork.Sort(delegate(int leftId, int rightId)
		{
			GameData.Domains.Character.Character element_Objects = DomainManager.Character.GetElement_Objects(leftId);
			GameData.Domains.Character.Character element_Objects2 = DomainManager.Character.GetElement_Objects(rightId);
			return element_Objects.GetPersonalities().GetSum() - element_Objects2.GetPersonalities().GetSum();
		});
		FindMinSumCombination(villagersForWork, needValue, ref charIds);
		return charIds;
		List<int> FindMinSumCombination(List<int> list, int threshold, ref List<int> result)
		{
			if (list == null || list.Count == 0)
			{
				return result;
			}
			int n = list.Count;
			int minSum = int.MaxValue;
			for (int i = 0; i < n; i++)
			{
				int charId2 = list[i];
				result[0] = charId2;
				int workValue = GetCharacterWorkValueSum(charId2);
				if (workValue > threshold && workValue < minSum)
				{
					minSum = workValue;
					result[0] = charId2;
				}
			}
			for (int j = 0; j < n - 1; j++)
			{
				if (GetCharacterWorkValueSum(list[j]) + GetCharacterWorkValueSum(list[j + 1]) <= minSum)
				{
					result[0] = list[j];
					result[1] = list[j + 1];
					for (int k = j + 1; k < n; k++)
					{
						int sum = GetCharacterWorkValueSum(list[j]) + GetCharacterWorkValueSum(list[k]);
						if (sum > minSum)
						{
							break;
						}
						if (sum > threshold)
						{
							minSum = sum;
							result[0] = list[j];
							result[1] = list[k];
						}
					}
				}
			}
			for (int l = 0; l < n - 2 && GetCharacterWorkValueSum(list[l]) + GetCharacterWorkValueSum(list[l + 1]) + GetCharacterWorkValueSum(list[l + 2]) <= minSum; l++)
			{
				result[0] = list[l];
				result[1] = list[l + 1];
				result[2] = list[l + 2];
				int left = l + 1;
				int right = n - 1;
				while (left < right)
				{
					int sum2 = GetCharacterWorkValueSum(list[l]) + GetCharacterWorkValueSum(list[left]) + GetCharacterWorkValueSum(list[right]);
					if (sum2 <= threshold)
					{
						left++;
					}
					else
					{
						if (sum2 < minSum)
						{
							minSum = sum2;
							result[0] = list[l];
							result[1] = list[left];
							result[2] = list[right];
						}
						right--;
					}
				}
			}
			return result;
		}
		int GetCharacterWorkValueSum(int num)
		{
			if (num < 0)
			{
				return 0;
			}
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(num);
			return character.GetPersonalities().GetSum() + BaseWorkContribution;
		}
	}

	[DomainMethod]
	public int GetOperationLeftTime(DataContext context, short buildingTemplateId, BuildingBlockKey blockKey, sbyte operationType, List<int> operatorList)
	{
		int needValue = 0;
		BuildingBlockData blockData;
		int progress = (DomainManager.Building.TryGetElement_BuildingBlocks(blockKey, out blockData) ? blockData.OperationProgress : 0);
		BuildingBlockItem buildingConfig = BuildingBlock.Instance[buildingTemplateId];
		needValue = buildingConfig.OperationTotalProgress[operationType] - progress;
		int sumValue = 0;
		foreach (int charId in operatorList)
		{
			if (charId >= 0)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				int personalitySum = character.GetPersonalities().GetSum();
				sumValue += BaseWorkContribution + personalitySum;
			}
		}
		return (int)Math.Ceiling((float)needValue / (float)sumValue);
	}

	[DomainMethod]
	public int GetBuildingOperationLeftTime(DataContext context, BuildingBlockKey blockKey, sbyte operationType)
	{
		if (!DomainManager.Building.TryGetElement_BuildingBlocks(blockKey, out var blockData))
		{
			return -1;
		}
		BuildingBlockItem buildingConfig = BuildingBlock.Instance[blockData.TemplateId];
		int needValue = buildingConfig.OperationTotalProgress[operationType] - blockData.OperationProgress;
		if (!DomainManager.Building.TryGetElement_BuildingOperatorDict(blockKey, out var operatorDict))
		{
			return -1;
		}
		int sumValue = 0;
		foreach (int charId in operatorDict.GetCollection())
		{
			if (charId >= 0)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				int personalitySum = character.GetPersonalities().GetSum();
				sumValue += BaseWorkContribution + personalitySum;
			}
		}
		if (sumValue == 0)
		{
			return -1;
		}
		return (int)Math.Ceiling((float)needValue / (float)sumValue);
	}

	public int GetOperationSumValue(List<int> operatorList)
	{
		int sumValue = 0;
		foreach (int charId in operatorList)
		{
			if (charId >= 0 && DomainManager.Taiwu.CanWork(charId))
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				int personalitySum = character.GetPersonalities().GetSum();
				sumValue += BaseWorkContribution + personalitySum;
			}
		}
		return sumValue;
	}

	[DomainMethod]
	public bool ShopBuildingCanTeach(BuildingBlockKey blockKey)
	{
		if (TryGetElement_ShopManagerDict(blockKey, out var shopManagerDict))
		{
			BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
			int leaderId = shopManagerDict[0];
			if (leaderId == -1)
			{
				return false;
			}
			VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(leaderId);
			if (villagerRole == null)
			{
				return false;
			}
			BuildingBlockItem buildingConfig = BuildingBlock.Instance[blockData.TemplateId];
			return Enumerable.Contains(buildingConfig.VillagerRoleTemplateIds, villagerRole.RoleTemplateId);
		}
		return false;
	}

	[DomainMethod]
	public ShopBuildingTeachBookData GetShopBuildingTeachBookData(BuildingBlockKey blockKey, int memberId)
	{
		ShopBuildingTeachBookData data = ShopBuildingTeachBookData.CreateDefault();
		if (!HasShopManagerLeader(blockKey))
		{
			data.TeachBookResult = 1;
			return data;
		}
		if (!ShopBuildingCanTeach(blockKey))
		{
			data.TeachBookResult = 2;
			return data;
		}
		BuildingBlockItem buildingConfig = BuildingBlock.Instance[GetElement_BuildingBlocks(blockKey).TemplateId];
		GameData.Domains.Character.Character memberCharacter = DomainManager.Character.GetElement_Objects(memberId);
		sbyte requirePersonalityValue = memberCharacter.GetPersonalities()[buildingConfig.RequirePersonalityType];
		short memberAttainment = ((buildingConfig.RequireLifeSkillType >= 0) ? memberCharacter.GetLifeSkillAttainment(buildingConfig.RequireLifeSkillType) : memberCharacter.GetCombatSkillAttainment(buildingConfig.RequireCombatSkillType));
		int point = memberAttainment * (100 + requirePersonalityValue) / 100;
		GameData.Domains.Character.Character leader = GetShopManagerLeader(blockKey);
		if (buildingConfig.RequireLifeSkillType >= 0)
		{
			int memberReadPageCount;
			int leaderCanTeachPageCount;
			List<(short, byte)> readBooks = ShopBuildingTeachLifeSkillBook(leader, memberCharacter, point, buildingConfig.TemplateId, out memberReadPageCount, out leaderCanTeachPageCount);
			data.TeachBookResult = (sbyte)((readBooks.Count <= 0) ? ((memberReadPageCount >= leaderCanTeachPageCount) ? 3 : 4) : 0);
			if (readBooks.Count > 0)
			{
				foreach (var item in readBooks)
				{
					short skillTemplateId = item.Item1;
					byte pageId = item.Item2;
					Config.LifeSkillItem skillConfig = LifeSkill.Instance[skillTemplateId];
					data.TeachBookInfo.Add((skillConfig.SkillBookId, pageId, -1));
				}
			}
			data.LeaderCanTeachBookCount = leaderCanTeachPageCount;
			data.MemberLearnedBookCount = memberReadPageCount;
		}
		else
		{
			bool hasMemberUnread;
			int canTeachCount;
			List<(short, byte, sbyte)> readBooks2 = ShopBuildingTeachCombatSkillBook(leader, memberCharacter, point, buildingConfig.TemplateId, out hasMemberUnread, out canTeachCount);
			data.TeachBookResult = (sbyte)((readBooks2.Count <= 0) ? (hasMemberUnread ? 4 : 3) : 0);
			if (readBooks2.Count > 0)
			{
				foreach (var item2 in readBooks2)
				{
					short skillTemplateId2 = item2.Item1;
					byte pageInternalIndex = item2.Item2;
					sbyte direct = item2.Item3;
					CombatSkillItem skillConfig2 = Config.CombatSkill.Instance[skillTemplateId2];
					byte pageId2 = CombatSkillStateHelper.GetPageId(pageInternalIndex);
					data.TeachBookInfo.Add((skillConfig2.BookId, pageId2, direct));
				}
			}
			data.LeaderCanTeachBookCount = canTeachCount;
			data.MemberLearnedBookCount = readBooks2.Count;
		}
		return data;
	}

	public void CalcResourceBlockProductivityList(BuildingBlockKey key, List<(BuildingBlockKey, int productivity)> productivityList)
	{
		productivityList.Clear();
		List<(BuildingBlockKey key, int level)> distanceOneBlocks = new List<(BuildingBlockKey, int)>();
		BuildingBlockDependencies(key, delegate(BuildingBlockData dependency, int distance, BuildingBlockKey blockKey)
		{
			switch (distance)
			{
			case 1:
				distanceOneBlocks.Add((blockKey, BuildingBlockLevel(blockKey)));
				break;
			case 2:
				productivityList.Add((blockKey, GlobalConfig.Instance.CollectResourceBuildingProductivityDistanceMore));
				break;
			}
		});
		distanceOneBlocks.Sort(((BuildingBlockKey key, int level) a, (BuildingBlockKey key, int level) b) => b.level.CompareTo(a.level));
		int[] distanceOneProductivityConfig = GlobalConfig.Instance.CollectResourceBuildingProductivityDistanceOne;
		for (int index = distanceOneBlocks.Count - 1; index >= 0; index--)
		{
			(BuildingBlockKey, int) distanceOneBlock = distanceOneBlocks[index];
			int productivity = distanceOneProductivityConfig[index];
			productivityList.Add((distanceOneBlock.Item1, productivity));
		}
		productivityList.Reverse();
	}

	public int CalcResourceOutputCountBySingleSpecifiedDependency(BuildingBlockKey key, sbyte resourceType, BuildingBlockData dependency, int productivity, out BuildingProduceDependencyData dependencyData)
	{
		dependencyData = BuildingProduceDependencyData.Invalid;
		if (TryGetElement_BuildingBlocks(key, out var _))
		{
			BuildingBlockKey dependencyKey = new BuildingBlockKey(key.AreaId, key.BlockId, dependency.BlockIndex);
			dependencyData.Level = BuildingBlockLevel(dependencyKey);
			dependencyData.TemplateId = dependency.TemplateId;
			dependencyData.BlockBaseYieldFactor = BuildingBaseYield(dependency).Get(Math.Min(resourceType, 5));
			dependencyData.ResourceYieldLevelFactor = BuildingResourceYieldLevel(dependencyKey, dependency.TemplateId);
			dependencyData.ProductivityFactor = productivity;
			dependencyData.TotalAttainmentFactor = BuildingTotalAttainment(key, resourceType, out var hasManager);
			dependencyData.GainResourcePercentFactor = DomainManager.World.GetGainResourcePercent(4);
			dependencyData.ResourceSingleOutputValuation = dependencyData.ResourceBuildingOutput;
			CValuePercentBonus resBuildingBonus = DomainManager.Building.GetBuildingBlockEffect(key.GetLocation(), EBuildingScaleEffect.BuildingMaterialResourceIncomeBonus);
			dependencyData.ResourceSingleOutputValuation *= resBuildingBonus;
			if (!hasManager)
			{
				return 0;
			}
			return dependencyData.ResourceSingleOutputValuation;
		}
		return 0;
	}

	[DomainMethod]
	public int CalcResourceOutputCount(BuildingBlockKey key, sbyte resourceType)
	{
		if (TryGetElement_BuildingBlocks(key, out var _))
		{
			int totalCount = 0;
			List<(BuildingBlockKey, int)> productivityList = new List<(BuildingBlockKey, int)>();
			CalcResourceBlockProductivityList(key, productivityList);
			foreach (var element in productivityList)
			{
				totalCount += CalcResourceOutputCountBySingleSpecifiedDependency(key, resourceType, GetBuildingBlockData(element.Item1), element.Item2, out var _);
			}
			return totalCount;
		}
		return 0;
	}

	private int CalcResourceOutputCount(BuildingBlockKey key, sbyte resourceType, Dictionary<BuildingBlockKey, BuildingProduceDependencyData> dependencyDataDict)
	{
		if (TryGetElement_BuildingBlocks(key, out var _))
		{
			int totalCount = 0;
			List<(BuildingBlockKey, int)> productivityList = new List<(BuildingBlockKey, int)>();
			CalcResourceBlockProductivityList(key, productivityList);
			foreach (var element in productivityList)
			{
				totalCount += CalcResourceOutputCountBySingleSpecifiedDependency(key, resourceType, GetBuildingBlockData(element.Item1), element.Item2, out var dependencyData);
				dependencyDataDict.Add(element.Item1, dependencyData);
			}
			return totalCount;
		}
		return 0;
	}

	[DomainMethod]
	public BuildingEarningsData GetBuildingEarningData(BuildingBlockKey blockKey)
	{
		if (TryGetElement_CollectBuildingEarningsData(blockKey, out var earningData))
		{
			return earningData;
		}
		if (DomainManager.Extra.TryGetElement_Feasts((ulong)blockKey, out var feast))
		{
			return new BuildingEarningsData
			{
				CollectionItemList = feast.Gift.Values.Where((ItemKey gift) => gift != ItemKey.Invalid && !ItemTemplateHelper.IsMiscResource(gift.ItemType, gift.TemplateId)).ToList(),
				CollectionResourceList = (from gift in feast.Gift
					where ItemTemplateHelper.IsMiscResource(gift.Value.ItemType, gift.Value.TemplateId) && feast.GiftCount.TryGetValue(gift.Key, out var value) && value > 0
					select new IntPair(gift.Value.TemplateId, feast.GiftCount[gift.Key])).ToList()
			};
		}
		return null;
	}

	[DomainMethod]
	public List<short> GetNewlyCreatedBuildingIndex(DataContext context)
	{
		return _newlyCreatedBuildingIndexes;
	}

	[DomainMethod]
	public void ClearNewlyCreatedBuildingIndex(DataContext context)
	{
		_newlyCreatedBuildingIndexes.Clear();
		SetNewlyCreatedBuildingIndexes(_newlyCreatedBuildingIndexes, context);
	}

	[DomainMethod]
	public List<int> GetBuildingOperatesData(BuildingBlockKey blockKey)
	{
		List<int> charIds = new List<int>();
		Dictionary<int, VillagerWorkData> villageWork = DomainManager.Taiwu.GetVillagerWorkDict();
		foreach (var (charId, workData) in villageWork)
		{
			if (workData.BuildingBlockIndex == blockKey.BuildingBlockIndex && workData.WorkType == 0)
			{
				charIds.Add(charId);
			}
		}
		return charIds;
	}

	[DomainMethod]
	public int GetBuildingBuildPeopleAttainments(BuildingBlockKey blockKey)
	{
		List<int> charIds = GetBuildingOperatesData(blockKey);
		int attainments = 0;
		for (int i = 0; i < charIds.Count; i++)
		{
			if (TryGetElement_BuildingBlocks(blockKey, out var blockData))
			{
				attainments += BaseWorkContribution;
				attainments += DomainManager.Character.GetElement_Objects(charIds[i]).GetLifeSkillAttainment(BuildingBlock.Instance[blockData.TemplateId].RequireLifeSkillType);
			}
		}
		return attainments;
	}

	[DomainMethod]
	public void SetBuildingResourceOutputSetting(DataContext context, int blockIndex, BuildingResourceOutputSetting setting)
	{
		DomainManager.Extra.SetBuildingResourceOutputSetting(context, blockIndex, setting);
	}

	[DomainMethod]
	public BuildingResourceOutputSetting GetBuildingResourceOutputSetting(int blockIndex)
	{
		return DomainManager.Extra.GetBuildingResourceOutputSetting(blockIndex);
	}

	public void RemoveBuildingResourceOutputSetting(DataContext context, int blockIndex)
	{
		DomainManager.Extra.RemoveBuildingResourceOutputSetting(context, blockIndex);
	}

	public void SetCollectBuildingEarningsData(DataContext context, BuildingBlockKey blockKey, BuildingEarningsData data)
	{
		if (TryGetElement_CollectBuildingEarningsData(blockKey, out var _))
		{
			SetElement_CollectBuildingEarningsData(blockKey, data, context);
		}
		else
		{
			AddElement_CollectBuildingEarningsData(blockKey, data, context);
		}
	}

	[DomainMethod]
	public BuildingBlockKey AcceptBuildingBlockCollectEarning(DataContext context, BuildingBlockKey key, int earningDataIndex, bool isPutInInventory, bool isSetData = true, bool isCostMoney = false)
	{
		if (TryGetElement_CollectBuildingEarningsData(key, out var data) && earningDataIndex >= 0)
		{
			BuildingBlockData buildingBlock = GetBuildingBlockData(key);
			if (earningDataIndex < data.CollectionItemList.Count)
			{
				ItemKey itemKey = data.CollectionItemList[earningDataIndex];
				data.CollectionItemList.RemoveAt(earningDataIndex);
				ItemBase item = DomainManager.Item.TryGetBaseItem(itemKey);
				itemKey = item.GetItemKey();
				item.RemoveOwner(ItemOwnerType.Building, buildingBlock.TemplateId);
				if (isCostMoney)
				{
					ConsumeResource(context, 6, ItemTemplateHelper.GetBaseValue(itemKey.ItemType, itemKey.TemplateId));
				}
				ItemSourceType sourceType = ApplyBuildingItemOutputSetting(key, itemKey);
				DomainManager.Taiwu.AddItem(context, itemKey, 1, sourceType);
				Events.RaiseCollectBuildingItem(context, key, buildingBlock.TemplateId, itemKey);
				BuildingChangeProfessionSeniority(context, itemKey);
			}
			if (earningDataIndex < data.CollectionResourceList.Count)
			{
				IntPair resourceIntPair = data.CollectionResourceList[earningDataIndex];
				data.CollectionResourceList.RemoveAt(earningDataIndex - data.CollectionItemList.Count);
				DomainManager.Character.GetElement_Objects(DomainManager.Taiwu.GetTaiwuCharId()).ChangeResource(context, (sbyte)resourceIntPair.First, resourceIntPair.Second);
				ApplyBuildingResourceOutputSetting(context, key, (sbyte)resourceIntPair.First, resourceIntPair.Second);
				Events.RaiseCollectBuildingResourceEarnings(context, key, buildingBlock.TemplateId, (sbyte)resourceIntPair.First, resourceIntPair.Second);
			}
			if (isSetData)
			{
				SetElement_CollectBuildingEarningsData(key, data, context);
			}
		}
		return key;
	}

	private void ApplyBuildingResourceOutputSetting(DataContext context, BuildingBlockKey key, sbyte resourceType, int amount)
	{
		if (!key.IsInvalid && resourceType != 7)
		{
			BuildingResourceOutputSetting settings = GetBuildingResourceOutputSetting(key.BuildingBlockIndex);
			if (settings.ResourceStorage != TaiwuVillageStorageType.Inventory)
			{
				ItemSourceType dest = BuildingResourceOutputSetting.GetItemSourceType(settings.ResourceStorage);
				DomainManager.Taiwu.TransferResource(context, ItemSourceType.Inventory, dest, resourceType, amount);
			}
		}
	}

	public ItemSourceType ApplyBuildingItemOutputSetting(BuildingBlockKey key, ItemKey itemKey)
	{
		if (key.IsInvalid)
		{
			return ItemSourceType.Warehouse;
		}
		BuildingResourceOutputSetting settings = GetBuildingResourceOutputSetting(key.BuildingBlockIndex);
		ItemSourceType dest = BuildingResourceOutputSetting.GetItemSourceType(settings.ItemStorage);
		if (dest == ItemSourceType.Inventory)
		{
			return ItemSourceType.Warehouse;
		}
		return dest;
	}

	[DomainMethod]
	public void AcceptBuildingBlockCollectEarningQuick(DataContext context, BuildingBlockKey key, bool isPutInInventory)
	{
		if (!TryGetElement_CollectBuildingEarningsData(key, out var data))
		{
			return;
		}
		if (data.CollectionItemList != null)
		{
			int count = data.CollectionItemList.Count;
			for (int i = 0; i < count; i++)
			{
				AcceptBuildingBlockCollectEarning(context, key, 0, isPutInInventory, isSetData: false);
			}
		}
		if (data.CollectionResourceList != null)
		{
			int tmpCount = data.CollectionResourceList.Count;
			for (int j = 0; j < tmpCount; j++)
			{
				AcceptBuildingBlockCollectEarning(context, key, 0, isPutInInventory: false);
			}
		}
		SetElement_CollectBuildingEarningsData(key, data, context);
	}

	private void OfflineHandleRecruitPeopleLeave(DataContext context, BuildingBlockKey buildingBlockKey, int earningDataIndex)
	{
		if (TryGetElement_CollectBuildingEarningsData(buildingBlockKey, out var data) && data != null && data.RecruitLevelList.Count > 0 && earningDataIndex >= 0)
		{
			DomainManager.Extra.RequestRecruitCharacterData(context, buildingBlockKey, earningDataIndex, autoRemove: true);
			data.RecruitLevelList.RemoveAt(earningDataIndex);
		}
	}

	[DomainMethod]
	public int AcceptBuildingBlockRecruitPeople(DataContext context, BuildingBlockKey key, int earningDataIndex, bool isSetData = true)
	{
		int charId = -1;
		if (TryGetElement_CollectBuildingEarningsData(key, out var data) && data != null && data.RecruitLevelList.Count > 0 && earningDataIndex >= 0)
		{
			if (earningDataIndex >= data.RecruitLevelList.Count)
			{
				earningDataIndex = 0;
			}
			RecruitCharacterData recruitCharacterData = DomainManager.Extra.RequestRecruitCharacterData(context, key, earningDataIndex);
			charId = CreateCharacterByRecruitCharacterData(context, recruitCharacterData);
			OfflineHandleRecruitPeopleLeave(context, key, earningDataIndex);
			InstantNotificationCollection instantNotifications = DomainManager.World.GetInstantNotificationCollection();
			instantNotifications.AddJoinTaiwuVillage(charId);
			BuildingBlockData blockData = DomainManager.Building.GetBuildingBlockData(key);
			if (blockData.TemplateId == 223)
			{
				ConsumeResource(context, 7, GlobalConfig.Instance.RecruitPeopleCost);
			}
			DomainManager.Taiwu.AddLegacyPoint(context, 31);
			Events.RaiseCollectBuildingRecruit(context, key, _buildingBlocks[key].TemplateId);
			if (isSetData)
			{
				SetElement_CollectBuildingEarningsData(key, data, context);
			}
		}
		return charId;
	}

	[DomainMethod]
	public List<int> AcceptBuildingBlockRecruitPeopleQuick(DataContext context, BuildingBlockKey key)
	{
		List<int> charIdList = new List<int>();
		if (!TryGetElement_CollectBuildingEarningsData(key, out var data) || data.RecruitLevelList == null)
		{
			return null;
		}
		int tmpCount = data.RecruitLevelList.Count;
		for (int i = 0; i < tmpCount; i++)
		{
			charIdList.Add(AcceptBuildingBlockRecruitPeople(context, key, 0, isSetData: false));
		}
		SetElement_CollectBuildingEarningsData(key, data, context);
		return charIdList;
	}

	[DomainMethod]
	public void RejectBuildingBlockRecruitPeople(DataContext context, BuildingBlockKey key, int earningDataIndex, bool isSetData = true)
	{
		if (TryGetElement_CollectBuildingEarningsData(key, out var data) && data != null && data.RecruitLevelList.Count > 0 && earningDataIndex >= 0)
		{
			if (earningDataIndex >= data.RecruitLevelList.Count)
			{
				earningDataIndex = 0;
			}
			OfflineHandleRecruitPeopleLeave(context, key, earningDataIndex);
			if (TryGetElement_BuildingBlocks(key, out var blockData))
			{
				InstantNotificationCollection instantNotifications = DomainManager.World.GetInstantNotificationCollection();
				short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
				instantNotifications.AddCandidateLeaved(settlementId, blockData.TemplateId);
			}
			if (isSetData)
			{
				SetElement_CollectBuildingEarningsData(key, data, context);
			}
		}
	}

	[DomainMethod]
	public void RejectBuildingBlockRecruitPeopleQuick(DataContext context, BuildingBlockKey key)
	{
		if (TryGetElement_CollectBuildingEarningsData(key, out var data) && data.RecruitLevelList != null)
		{
			int tmpCount = data.RecruitLevelList.Count;
			for (int i = 0; i < tmpCount; i++)
			{
				RejectBuildingBlockRecruitPeople(context, key, 0, isSetData: false);
			}
			SetElement_CollectBuildingEarningsData(key, data, context);
		}
	}

	[DomainMethod]
	public void ShopBuildingMultiChangeSoldItem(DataContext context, BuildingBlockKey key, List<ItemKey> itemList, List<int> operateTypeList)
	{
		if (itemList == null || operateTypeList == null || !TryGetElement_BuildingBlocks(key, out var blockData) || itemList.Count != operateTypeList.Count)
		{
			return;
		}
		BuildingBlockItem config = BuildingBlock.Instance[blockData.TemplateId];
		sbyte slot = SharedMethods.GetBuildingSlotCount(config.TemplateId);
		if (config.TemplateId == 105)
		{
			for (int i = 0; i < itemList.Count; i++)
			{
				ItemKey itemKey = itemList[i];
				if (itemKey.IsValid())
				{
					switch (operateTypeList[i])
					{
					case 1:
						AddFixBook(context, key, itemKey, ItemSourceType.Inventory);
						break;
					case 2:
						ChangeFixBook(context, key, ItemKey.Invalid, ItemSourceType.Inventory);
						break;
					case 3:
						AddFixBook(context, key, itemKey, ItemSourceType.Warehouse);
						break;
					case 4:
						ChangeFixBook(context, key, ItemKey.Invalid, ItemSourceType.Warehouse);
						break;
					case 5:
						AddFixBook(context, key, itemKey, ItemSourceType.Treasury);
						break;
					case 6:
						ChangeFixBook(context, key, ItemKey.Invalid, ItemSourceType.Treasury);
						break;
					}
				}
			}
			return;
		}
		if (!TryGetElement_CollectBuildingEarningsData(key, out var earningsData))
		{
			earningsData = new BuildingEarningsData();
			for (int j = 0; j < slot; j++)
			{
				earningsData.ShopSoldItemList.Add(ItemKey.Invalid);
				earningsData.ShopSoldItemEarnList.Add(new IntPair(-1, -1));
			}
			AddElement_CollectBuildingEarningsData(key, earningsData, context);
		}
		if (earningsData.ShopSoldItemList.Count < slot)
		{
			int count = slot - earningsData.ShopSoldItemList.Count;
			for (int k = 0; k < count; k++)
			{
				earningsData.ShopSoldItemList.Add(ItemKey.Invalid);
				earningsData.ShopSoldItemEarnList.Add(new IntPair(-1, -1));
			}
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		for (int l = 0; l < itemList.Count; l++)
		{
			ItemKey itemKey2 = itemList[l];
			if (!itemKey2.IsValid())
			{
				continue;
			}
			switch (operateTypeList[l])
			{
			case 0:
			{
				sbyte index = FindItemKeyIndex(earningsData, itemKey2);
				RemoveBuildingEarningsDataShopSoldItem(index, itemKey2, earningsData, blockData.TemplateId);
				switch (GetBuildingResourceOutputSetting(key.BuildingBlockIndex).ItemStorage)
				{
				case TaiwuVillageStorageType.Inventory:
					taiwu.AddInventoryItem(context, itemKey2, 1);
					break;
				case TaiwuVillageStorageType.Treasury:
					DomainManager.Taiwu.AddItem(context, itemKey2, 1, ItemSourceType.Treasury);
					break;
				case TaiwuVillageStorageType.Stock:
					DomainManager.Taiwu.AddItem(context, itemKey2, 1, ItemSourceType.Stock);
					break;
				default:
					DomainManager.Taiwu.WarehouseAdd(context, itemKey2, 1);
					break;
				}
				break;
			}
			case 1:
			{
				taiwu.RemoveInventoryItem(context, itemKey2, 1, deleteItem: false);
				sbyte index = FindFirstCanUseIndex(earningsData);
				if (index >= 0 && index < earningsData.ShopSoldItemList.Count)
				{
					AddBuildingEarningsDataShopSoldItem(index, itemKey2, earningsData, blockData.TemplateId);
				}
				break;
			}
			case 2:
			{
				sbyte index = FindItemKeyIndex(earningsData, itemKey2);
				RemoveBuildingEarningsDataShopSoldItem(index, itemKey2, earningsData, blockData.TemplateId);
				taiwu.AddInventoryItem(context, itemKey2, 1);
				break;
			}
			case 3:
			{
				DomainManager.Taiwu.WarehouseRemove(context, itemKey2, 1);
				sbyte index = FindFirstCanUseIndex(earningsData);
				if (index >= 0 && index < earningsData.ShopSoldItemList.Count)
				{
					AddBuildingEarningsDataShopSoldItem(index, itemKey2, earningsData, blockData.TemplateId);
				}
				break;
			}
			case 4:
			{
				sbyte index = FindItemKeyIndex(earningsData, itemKey2);
				RemoveBuildingEarningsDataShopSoldItem(index, itemKey2, earningsData, blockData.TemplateId);
				DomainManager.Taiwu.WarehouseAdd(context, itemKey2, 1);
				break;
			}
			case 5:
			{
				DomainManager.Taiwu.RemoveItem(context, itemKey2, 1, ItemSourceType.Treasury, deleteItem: false);
				sbyte index = FindFirstCanUseIndex(earningsData);
				if (index >= 0 && index < earningsData.ShopSoldItemList.Count)
				{
					AddBuildingEarningsDataShopSoldItem(index, itemKey2, earningsData, blockData.TemplateId);
				}
				break;
			}
			case 6:
			{
				sbyte index = FindItemKeyIndex(earningsData, itemKey2);
				RemoveBuildingEarningsDataShopSoldItem(index, itemKey2, earningsData, blockData.TemplateId);
				DomainManager.Taiwu.AddItem(context, itemKey2, 1, ItemSourceType.Treasury);
				break;
			}
			case 7:
			{
				DomainManager.Taiwu.RemoveItem(context, itemKey2, 1, ItemSourceType.Stock, deleteItem: false);
				sbyte index = FindFirstCanUseIndex(earningsData);
				if (index >= 0 && index < earningsData.ShopSoldItemList.Count)
				{
					AddBuildingEarningsDataShopSoldItem(index, itemKey2, earningsData, blockData.TemplateId);
				}
				break;
			}
			case 8:
			{
				sbyte index = FindItemKeyIndex(earningsData, itemKey2);
				RemoveBuildingEarningsDataShopSoldItem(index, itemKey2, earningsData, blockData.TemplateId);
				DomainManager.Taiwu.AddItem(context, itemKey2, 1, ItemSourceType.Stock);
				break;
			}
			}
		}
		SetElement_CollectBuildingEarningsData(key, earningsData, context);
	}

	private void AddBuildingEarningsDataShopSoldItem(int index, ItemKey itemKey, BuildingEarningsData earningsData, short templateId)
	{
		earningsData.ShopSoldItemList[index] = itemKey;
		DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Building, templateId);
	}

	private void RemoveBuildingEarningsDataShopSoldItem(int index, ItemKey itemKey, BuildingEarningsData earningsData, short templateId)
	{
		earningsData.ShopSoldItemList[index] = ItemKey.Invalid;
		DomainManager.Item.RemoveOwner(itemKey, ItemOwnerType.Building, templateId);
	}

	private BuildingOptionAutoAddSoldItemPreset GetAutoAddSoldItemSetting(BuildingBlockKey blockKey)
	{
		TryGetElement_BuildingBlocks(blockKey, out var buildingBlockData);
		return buildingBlockData?.SoldItemSetting ?? new BuildingOptionAutoAddSoldItemPreset();
	}

	private void AutoAddShopSoldItem(DataContext context, BuildingBlockKey blockKey)
	{
		BuildingBlockData blockData = GetBuildingBlockData(blockKey);
		BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
		IReadOnlyDictionary<ItemKey, int> goodsShelf = DomainManager.Taiwu.GetItems(ItemSourceType.Stock);
		if (goodsShelf.Count == 0)
		{
			return;
		}
		BuildingBlockKey betterBlockKey = GetMoreBetterSoldBuilding(blockKey, blockData);
		BuildingBlockData betterBlockData = null;
		BuildingEarningsData betterEarningsData = null;
		bool isHaveBetter = false;
		if (!betterBlockKey.Equals(BuildingBlockKey.Invalid))
		{
			TryGetElement_BuildingBlocks(betterBlockKey, out betterBlockData);
			isHaveBetter = TryGetElement_CollectBuildingEarningsData(betterBlockKey, out betterEarningsData);
			if (betterEarningsData == null)
			{
				InitBuildingEarningsData(SharedMethods.GetBuildingSlotCount(betterBlockData.TemplateId), ref betterEarningsData);
			}
		}
		BuildingEarningsData earningsData;
		bool isHave = TryGetElement_CollectBuildingEarningsData(blockKey, out earningsData);
		if (earningsData == null)
		{
			InitBuildingEarningsData(SharedMethods.GetBuildingSlotCount(blockData.TemplateId), ref earningsData);
		}
		BuildingOptionAutoAddSoldItemPreset settings = GetAutoAddSoldItemSetting(blockKey);
		List<ItemKeyAndCount> goodsList = new List<ItemKeyAndCount>();
		List<ItemKey> canSoldList = new List<ItemKey>();
		ItemKey itemKey;
		int count;
		foreach (KeyValuePair<ItemKey, int> item in goodsShelf)
		{
			item.Deconstruct(out itemKey, out count);
			ItemKey itemKey2 = itemKey;
			int count2 = count;
			if (!SharedMethods.IsBuildingCanSoldItem(configData, itemKey2))
			{
				continue;
			}
			List<sbyte> itemTypeList = settings.ItemTypeList;
			if (itemTypeList == null || itemTypeList.Count <= 0 || settings.ItemTypeList.Contains(itemKey2.ItemType))
			{
				sbyte grade = ItemTemplateHelper.GetGrade(itemKey2.ItemType, itemKey2.TemplateId);
				if (grade >= settings.MinGrade && grade <= settings.MaxGrade)
				{
					goodsList.Add(new ItemKeyAndCount(itemKey2, count2));
				}
			}
		}
		bool isGradeOrderHigh = settings.GradeOrder == 1;
		bool isPropertyOrderMaxValue = settings.PropertyOrderEnum.HasFlag(BuildingOptionAutoAddSoldItemPreset.EPropertyOrder.MaxValue);
		bool isPropertyOrderMaxAmount = settings.PropertyOrderEnum.HasFlag(BuildingOptionAutoAddSoldItemPreset.EPropertyOrder.MaxAmount);
		goodsList.Sort(delegate(ItemKeyAndCount a, ItemKeyAndCount b)
		{
			sbyte grade2 = ItemTemplateHelper.GetGrade(a.ItemKey.ItemType, a.ItemKey.TemplateId);
			sbyte grade3 = ItemTemplateHelper.GetGrade(b.ItemKey.ItemType, b.ItemKey.TemplateId);
			if (grade2 != grade3)
			{
				return isGradeOrderHigh ? grade3.CompareTo(grade2) : grade2.CompareTo(grade3);
			}
			int value = DomainManager.Item.GetValue(a.ItemKey);
			int value2 = DomainManager.Item.GetValue(b.ItemKey);
			if (value != value2)
			{
				return isPropertyOrderMaxValue ? value2.CompareTo(value) : value.CompareTo(value2);
			}
			return (a.Count != b.Count) ? (isPropertyOrderMaxAmount ? b.Count.CompareTo(a.Count) : a.Count.CompareTo(b.Count)) : 0;
		});
		foreach (ItemKeyAndCount item2 in goodsList)
		{
			item2.Deconstruct(out itemKey, out count);
			ItemKey itemKey3 = itemKey;
			int count3 = count;
			for (int i = 0; i < count3; i++)
			{
				canSoldList.Add(itemKey3);
			}
		}
		if (canSoldList.Count <= 0)
		{
			return;
		}
		if (!betterBlockKey.Equals(BuildingBlockKey.Invalid) && betterBlockData != null)
		{
			int betterLeftCapacity = SharedMethods.GetBuildingSlotCount(betterBlockData.TemplateId) - GetShopSoldItemCount(betterEarningsData) - GetShopSoldEarnCount(betterEarningsData);
			for (int i2 = 0; i2 < Math.Min(canSoldList.Count, betterLeftCapacity); i2++)
			{
				int index = FindFirstCanUseIndex(betterEarningsData);
				if (index < 0 && betterEarningsData.ShopSoldItemList.Count < SharedMethods.GetBuildingSlotCount(betterBlockData.TemplateId))
				{
					betterEarningsData.ShopSoldItemList.Add(ItemKey.Invalid);
					betterEarningsData.ShopSoldItemEarnList.Add(new IntPair(-1, -1));
					index = betterEarningsData.ShopSoldItemList.Count - 1;
				}
				if (index >= 0 && index < betterEarningsData.ShopSoldItemList.Count)
				{
					DomainManager.Taiwu.RemoveItem(context, canSoldList[i2], 1, ItemSourceType.Stock, deleteItem: false);
					AddBuildingEarningsDataShopSoldItem(index, canSoldList[i2], betterEarningsData, blockData.TemplateId);
					canSoldList.RemoveAt(i2);
				}
			}
			if (isHaveBetter)
			{
				SetElement_CollectBuildingEarningsData(betterBlockKey, betterEarningsData, context);
			}
			else
			{
				AddElement_CollectBuildingEarningsData(betterBlockKey, betterEarningsData, context);
			}
		}
		int leftCapacity = SharedMethods.GetBuildingSlotCount(blockData.TemplateId) - GetShopSoldItemCount(earningsData) - GetShopSoldEarnCount(earningsData);
		for (int i3 = 0; i3 < Math.Min(canSoldList.Count, leftCapacity); i3++)
		{
			int index2 = FindFirstCanUseIndex(earningsData);
			if (index2 < 0 && earningsData.ShopSoldItemList.Count < SharedMethods.GetBuildingSlotCount(blockData.TemplateId))
			{
				earningsData.ShopSoldItemList.Add(ItemKey.Invalid);
				earningsData.ShopSoldItemEarnList.Add(new IntPair(-1, -1));
				index2 = earningsData.ShopSoldItemList.Count - 1;
			}
			if (index2 >= 0 && index2 < earningsData.ShopSoldItemList.Count)
			{
				DomainManager.Taiwu.RemoveItem(context, canSoldList[i3], 1, ItemSourceType.Stock, deleteItem: false);
				AddBuildingEarningsDataShopSoldItem(index2, canSoldList[i3], earningsData, blockData.TemplateId);
			}
		}
		if (isHave)
		{
			SetElement_CollectBuildingEarningsData(blockKey, earningsData, context);
		}
		else
		{
			AddElement_CollectBuildingEarningsData(blockKey, earningsData, context);
		}
		static void InitBuildingEarningsData(sbyte level, ref BuildingEarningsData reference)
		{
			reference = new BuildingEarningsData();
			for (int j = 0; j < level; j++)
			{
				reference.ShopSoldItemList.Add(ItemKey.Invalid);
				reference.ShopSoldItemEarnList.Add(new IntPair(-1, -1));
			}
		}
	}

	[DomainMethod]
	public void QuickAddShopSoldItem(DataContext context, BuildingBlockKey blockKey)
	{
		QuickRemoveShopSoldItem(context, blockKey);
		AutoAddShopSoldItem(context, blockKey);
		if (TryGetElement_CollectBuildingEarningsData(blockKey, out var earningsData))
		{
			SetElement_CollectBuildingEarningsData(blockKey, earningsData, context);
		}
	}

	[DomainMethod]
	public void QuickRemoveShopSoldItem(DataContext context, BuildingBlockKey blockKey)
	{
		if (!TryGetElement_CollectBuildingEarningsData(blockKey, out var earningsData))
		{
			return;
		}
		for (sbyte i = 0; i < earningsData.ShopSoldItemList.Count; i++)
		{
			ItemKey shopSoldItem = earningsData.ShopSoldItemList[i];
			IntPair shopSoldItemEarn = earningsData.ShopSoldItemEarnList[i];
			if (!shopSoldItem.Equals(ItemKey.Invalid) && shopSoldItemEarn.First == -1)
			{
				BuildingBlockData blockData = GetBuildingBlockData(blockKey);
				RemoveBuildingEarningsDataShopSoldItem(i, shopSoldItem, earningsData, blockData.TemplateId);
				DomainManager.Taiwu.AddStockItem(context, shopSoldItem, 1);
			}
		}
		SetElement_CollectBuildingEarningsData(blockKey, earningsData, context);
	}

	public sbyte FindFirstCanUseIndex(BuildingEarningsData earningsData)
	{
		sbyte index = -1;
		for (sbyte i = 0; i < earningsData.ShopSoldItemList.Count; i++)
		{
			if (earningsData.ShopSoldItemList[i].Equals(ItemKey.Invalid) && earningsData.ShopSoldItemEarnList[i].First == -1)
			{
				index = i;
				break;
			}
		}
		return index;
	}

	public sbyte FindItemKeyIndex(BuildingEarningsData earningsData, ItemKey itemKey)
	{
		sbyte index = 0;
		for (sbyte i = 0; i < earningsData.ShopSoldItemList.Count; i++)
		{
			if (earningsData.ShopSoldItemList[i].Equals(itemKey))
			{
				index = i;
				break;
			}
		}
		return index;
	}

	public int GetShopSoldItemCount(BuildingEarningsData earningsData)
	{
		if (earningsData == null || earningsData.ShopSoldItemList == null)
		{
			return 0;
		}
		int count = 0;
		for (int i = 0; i < earningsData.ShopSoldItemList.Count; i++)
		{
			if (!earningsData.ShopSoldItemList[i].Equals(ItemKey.Invalid))
			{
				count++;
			}
		}
		return count;
	}

	public int GetShopSoldEarnCount(BuildingEarningsData earningsData)
	{
		if (earningsData == null || earningsData.ShopSoldItemEarnList == null)
		{
			return 0;
		}
		int count = 0;
		for (int i = 0; i < earningsData.ShopSoldItemEarnList.Count; i++)
		{
			if (earningsData.ShopSoldItemEarnList[i].First != -1)
			{
				count++;
			}
		}
		return count;
	}

	[DomainMethod]
	public void ShopBuildingSoldItemReceive(DataContext context, BuildingBlockKey key, int earningDataIndex, bool isSetData = true)
	{
		if (TryGetElement_CollectBuildingEarningsData(key, out var data) && earningDataIndex >= 0)
		{
			IntPair resourceIntPair = data.ShopSoldItemEarnList[earningDataIndex];
			DomainManager.Character.GetElement_Objects(DomainManager.Taiwu.GetTaiwuCharId()).ChangeResource(context, (sbyte)resourceIntPair.First, resourceIntPair.Second);
			ApplyBuildingResourceOutputSetting(context, key, (sbyte)resourceIntPair.First, resourceIntPair.Second);
			data.ShopSoldItemList[earningDataIndex] = ItemKey.Invalid;
			data.ShopSoldItemEarnList[earningDataIndex] = new IntPair(-1, -1);
			Events.RaiseCollectBuildingResourceEarnings(context, key, _buildingBlocks[key].TemplateId, (sbyte)resourceIntPair.First, resourceIntPair.Second);
		}
		if (isSetData)
		{
			SetElement_CollectBuildingEarningsData(key, data, context);
		}
	}

	[DomainMethod]
	public void ShopBuildingSoldItemReceiveQuick(DataContext context, BuildingBlockKey key)
	{
		if (!TryGetElement_CollectBuildingEarningsData(key, out var data) || data == null)
		{
			return;
		}
		for (int i = 0; i < data.ShopSoldItemEarnList.Count; i++)
		{
			if (data.ShopSoldItemEarnList[i].First != -1)
			{
				ShopBuildingSoldItemReceive(context, key, i, isSetData: false);
			}
		}
		SetElement_CollectBuildingEarningsData(key, data, context);
	}

	[DomainMethod]
	public List<ItemDisplayData> QuickCollectShopItem(DataContext context)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		List<ItemKey> itemKeyList = new List<ItemKey>();
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId > 0)
			{
				BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
				if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ItemList.Count > 0 && blockData.TemplateId != 222)
				{
					CollectItemQuick(context, blockKey, itemKeyList);
				}
			}
		}
		List<ItemDisplayData> extraItems = new List<ItemDisplayData>();
		foreach (Feast feast in DomainManager.Extra.GetAllFeasts().Values)
		{
			for (int i = 0; i < GlobalConfig.Instance.FeastGiftCount; i++)
			{
				ItemKey gift = feast.GetGift(i);
				if (gift != ItemKey.Invalid)
				{
					if (!ItemTemplateHelper.IsMiscResource(gift.ItemType, gift.TemplateId))
					{
						itemKeyList.Add(gift);
						continue;
					}
					extraItems.Add(new ItemDisplayData(gift.ItemType, gift.TemplateId)
					{
						Amount = (feast.GiftCount.TryGetValue(i, out var giftCount) ? giftCount : 0)
					});
				}
			}
			DomainManager.Extra.FeastReceiveGift(context, feast.BuildingBlockKey, -1);
		}
		return DomainManager.Item.GetItemDisplayDataListOptional(itemKeyList, DomainManager.Taiwu.GetTaiwuCharId(), -1)?.Concat(extraItems).ToList() ?? extraItems;
	}

	[DomainMethod]
	public List<ItemDisplayData> QuickCollectSingleShopItem(DataContext context, BuildingBlockKey blockKey)
	{
		List<ItemKey> itemKeyList = new List<ItemKey>();
		BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
		BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
		if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ItemList.Count > 0)
		{
			CollectItemQuick(context, blockKey, itemKeyList);
		}
		return DomainManager.Item.GetItemDisplayDataList(itemKeyList, DomainManager.Taiwu.GetTaiwuCharId());
	}

	public void CollectItemQuick(DataContext context, BuildingBlockKey key, List<ItemKey> itemKeyList)
	{
		if (!TryGetElement_CollectBuildingEarningsData(key, out var data))
		{
			return;
		}
		if (data.CollectionItemList != null)
		{
			int count = data.CollectionItemList.Count;
			for (int i = 0; i < count; i++)
			{
				CollectShopItem(context, key, 0, itemKeyList);
			}
		}
		SetElement_CollectBuildingEarningsData(key, data, context);
	}

	public BuildingBlockKey CollectShopItem(DataContext context, BuildingBlockKey key, int earningDataIndex, List<ItemKey> itemKeyList)
	{
		if (TryGetElement_CollectBuildingEarningsData(key, out var data) && earningDataIndex >= 0 && earningDataIndex < data.CollectionItemList.Count)
		{
			ItemKey itemKey = data.CollectionItemList[earningDataIndex];
			data.CollectionItemList.RemoveAt(earningDataIndex);
			ItemSourceType sourceType = ApplyBuildingItemOutputSetting(key, itemKey);
			itemKey = DomainManager.Item.GetBaseItem(itemKey).GetItemKey();
			DomainManager.Taiwu.AddItem(context, itemKey, 1, sourceType);
			itemKeyList.Add(itemKey);
			BuildingBlockData buildingBlock = GetBuildingBlockData(key);
			Events.RaiseCollectBuildingItem(context, key, buildingBlock.TemplateId, itemKey);
			BuildingChangeProfessionSeniority(context, itemKey);
		}
		return key;
	}

	public void AddBuildingGainLegacy(DataContext context, BuildingBlockKey key)
	{
		if (DomainManager.Building.TryGetElement_BuildingBlocks(key, out var blockData))
		{
			BuildingBlockItem config = BuildingBlock.Instance.GetItem(blockData.TemplateId);
			DomainManager.Taiwu.AddLegacyPoint(context, (short)(config.IsCollectResourceBuilding ? 28 : 29));
		}
	}

	private void BuildingChangeProfessionSeniority(DataContext context, ItemKey itemKey)
	{
		short itemSubType = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
		int price = DomainManager.Item.GetBaseItem(itemKey).GetValue();
		switch (itemSubType)
		{
		case 901:
		{
			ProfessionFormulaItem formulaItem2 = ProfessionFormula.Instance[55];
			DomainManager.Extra.ChangeProfessionSeniority(context, 7, formulaItem2.Calculate(price));
			break;
		}
		case 900:
		{
			ProfessionFormulaItem formulaItem = ProfessionFormula.Instance[106];
			DomainManager.Extra.ChangeProfessionSeniority(context, 16, formulaItem.Calculate(price));
			break;
		}
		}
	}

	public void GetAllQuickCollectionAmount(out int moneyAmount, out int authorityAmount, out int villagerAmount, out int itemAmount, out int pawnShopItemAmount)
	{
		moneyAmount = 0;
		authorityAmount = 0;
		villagerAmount = 0;
		itemAmount = 0;
		pawnShopItemAmount = 0;
		foreach (var (blockKey, blockData) in GetTaiwuVillageNotEmptyBuildingBlockData())
		{
			if (blockData.TemplateId == 47)
			{
				if (DomainManager.Extra.TryGetElement_Feasts((ulong)blockKey, out var feast))
				{
					itemAmount += feast.GetInUseGiftSlotCount();
				}
			}
			else
			{
				if (!TryGetElement_CollectBuildingEarningsData(blockKey, out var data) || data == null)
				{
					continue;
				}
				if (data.ShopSoldItemEarnList != null)
				{
					moneyAmount += data.ShopSoldItemEarnList.Sum((IntPair pair) => (pair.First == 6) ? pair.Second : 0);
					authorityAmount += data.ShopSoldItemEarnList.Sum((IntPair pair) => (pair.First == 7) ? pair.Second : 0);
				}
				if (data.CollectionResourceList != null)
				{
					moneyAmount += data.CollectionResourceList.Sum((IntPair pair) => (pair.First == 6) ? pair.Second : 0);
					authorityAmount += data.CollectionResourceList.Sum((IntPair pair) => (pair.First == 7) ? pair.Second : 0);
				}
				if (data.CollectionItemList != null)
				{
					if (blockData.TemplateId == 222)
					{
						pawnShopItemAmount += data.CollectionItemList.Count((ItemKey key) => key.IsValid());
					}
					else
					{
						itemAmount += data.CollectionItemList.Count((ItemKey key) => key.IsValid());
					}
				}
				if (data.RecruitLevelList != null)
				{
					villagerAmount += data.RecruitLevelList.Count;
				}
			}
		}
	}

	[DomainMethod]
	public int QuickCollectShopItemCount(DataContext context)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		int count = 0;
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId > 0)
			{
				BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
				BuildingEarningsData data;
				if (blockData.TemplateId == 47 && DomainManager.Extra.TryGetElement_Feasts((ulong)blockKey, out var feast))
				{
					count += feast.GetInUseGiftSlotCount();
				}
				else if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ItemList.Count > 0 && blockData.TemplateId != 222 && TryGetElement_CollectBuildingEarningsData(blockKey, out data) && data.CollectionItemList != null)
				{
					count += data.CollectionItemList.Count;
				}
			}
		}
		return count;
	}

	[DomainMethod]
	public void QuickCollectShopSoldItem(DataContext context)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId > 0)
			{
				BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
				if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ExchangeResourceGoods != -1)
				{
					ShopBuildingSoldItemReceiveQuick(context, blockKey);
				}
				if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ResourceGoods != -1)
				{
					AcceptBuildingBlockCollectEarningQuick(context, blockKey, isPutInInventory: false);
				}
			}
		}
	}

	[DomainMethod]
	public void QuickCollectSingleShopSoldItem(DataContext context, BuildingBlockKey blockKey)
	{
		BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
		BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
		if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ExchangeResourceGoods != -1)
		{
			ShopBuildingSoldItemReceiveQuick(context, blockKey);
		}
		if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ResourceGoods != -1)
		{
			AcceptBuildingBlockCollectEarningQuick(context, blockKey, isPutInInventory: false);
		}
	}

	[DomainMethod]
	public ResourceInts GetQuickCollectResourceAmount(DataContext context)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		ResourceInts resourceAdd = default(ResourceInts);
		resourceAdd.Initialize();
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId > 0)
			{
				BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
				if (TryGetElement_CollectBuildingEarningsData(blockKey, out var data))
				{
					if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ExchangeResourceGoods != -1)
					{
						foreach (IntPair resourceIntPair in data.ShopSoldItemEarnList)
						{
							if (resourceIntPair.First != -1)
							{
								resourceAdd[resourceIntPair.First] += resourceIntPair.Second;
							}
						}
					}
					if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ResourceGoods != -1 && data.CollectionResourceList != null)
					{
						foreach (IntPair resourceIntPair2 in data.CollectionResourceList)
						{
							if (resourceIntPair2.First != -1)
							{
								resourceAdd[resourceIntPair2.First] += resourceIntPair2.Second;
							}
						}
					}
				}
			}
		}
		return resourceAdd;
	}

	[DomainMethod]
	public int QuickCollectShopSoldItemCount(DataContext context)
	{
		int count = 0;
		IEnumerable<(BuildingBlockKey, BuildingBlockData)> blockDataList = GetTaiwuVillageNotEmptyBuildingBlockData();
		foreach (var item in blockDataList)
		{
			BuildingBlockKey blockKey = item.Item1;
			BuildingBlockData blockData = item.Item2;
			BuildingBlockItem config = BuildingBlock.Instance.GetItem(blockData.TemplateId);
			if (SharedMethods.IsBuildingExchangeResourceGoods(config) && TryGetElement_CollectBuildingEarningsData(blockKey, out var data))
			{
				if (data == null)
				{
					continue;
				}
				for (int i = 0; i < data.ShopSoldItemEarnList.Count; i++)
				{
					if (data.ShopSoldItemEarnList[i].First >= 0)
					{
						count++;
					}
				}
			}
			if (SharedMethods.IsBuildingCollectResourceGoods(config) && TryGetElement_CollectBuildingEarningsData(blockKey, out var data2) && data2.CollectionResourceList != null)
			{
				count += data2.CollectionResourceList.Count;
			}
		}
		return count;
	}

	[DomainMethod]
	public List<int> QuickRecruitPeople(DataContext context)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		List<int> charIdList = new List<int>();
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId > 0)
			{
				BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
				if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).RecruitPeopleProb.Count > 0 && blockData.TemplateId != 223)
				{
					RecruitPeopleQuick(context, blockKey, charIdList);
				}
			}
		}
		return charIdList;
	}

	[DomainMethod]
	public List<int> QuickRecruitSingleBuildingPeople(DataContext context, BuildingBlockKey blockKey)
	{
		List<int> charIdList = new List<int>();
		BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
		BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
		if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).RecruitPeopleProb.Count > 0)
		{
			RecruitPeopleQuick(context, blockKey, charIdList);
		}
		return charIdList;
	}

	public void RecruitPeopleQuick(DataContext context, BuildingBlockKey key, List<int> charIdList)
	{
		if (TryGetElement_CollectBuildingEarningsData(key, out var data) && data.RecruitLevelList != null)
		{
			int tmpCount = data.RecruitLevelList.Count;
			for (int i = 0; i < tmpCount; i++)
			{
				RecruitPeople(context, key, 0, charIdList);
			}
			SetElement_CollectBuildingEarningsData(key, data, context);
		}
	}

	public void RecruitPeople(DataContext context, BuildingBlockKey key, int earningDataIndex, List<int> charIdList)
	{
		charIdList.Add(AcceptBuildingBlockRecruitPeople(context, key, earningDataIndex, isSetData: false));
	}

	[DomainMethod]
	public int QuickRecruitPeopleCount(DataContext context)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		int count = 0;
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId > 0)
			{
				BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
				if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).RecruitPeopleProb.Count > 0 && TryGetElement_CollectBuildingEarningsData(blockKey, out var data) && data.RecruitLevelList != null)
				{
					count += data.RecruitLevelList.Count;
				}
			}
		}
		return count;
	}

	[DomainMethod]
	public void QuickCollectBuildingEarn(DataContext context)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId <= 0)
			{
				continue;
			}
			BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
			if (configData.SuccesEvent.Count != 0 && (Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ItemList.Count > 0 || Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ResourceGoods != -1))
			{
				AcceptBuildingBlockCollectEarningQuick(context, blockKey, isPutInInventory: false);
			}
			if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ExchangeResourceGoods != -1)
			{
				if (blockData.TemplateId == 222)
				{
					continue;
				}
				ShopBuildingSoldItemReceiveQuick(context, blockKey);
			}
			if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).RecruitPeopleProb.Count > 0 && blockData.TemplateId != 223)
			{
				AcceptBuildingBlockRecruitPeopleQuick(context, blockKey);
			}
		}
	}

	[DomainMethod]
	public bool AnyBuildingEarnCountMax(DataContext context)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId <= 0)
			{
				continue;
			}
			BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
			if (blockData.TemplateId == 47 && DomainManager.Extra.TryGetElement_Feasts((ulong)blockKey, out var feast) && feast.InUseGiftMax())
			{
				return true;
			}
			if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).RecruitPeopleProb.Count > 0)
			{
				if (!TryGetElement_CollectBuildingEarningsData(blockKey, out var data) || data.RecruitLevelList == null)
				{
					continue;
				}
				int count = data.RecruitLevelList.Count;
				sbyte slotCount = SharedMethods.GetBuildingSlotCount(blockData.TemplateId);
				if (count >= slotCount)
				{
					return true;
				}
			}
			if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ExchangeResourceGoods != -1 && TryGetElement_CollectBuildingEarningsData(blockKey, out var data2))
			{
				if (data2 == null)
				{
					continue;
				}
				int count2 = 0;
				for (int i = 0; i < data2.ShopSoldItemEarnList.Count; i++)
				{
					if (data2.ShopSoldItemEarnList[i].First != -1)
					{
						count2++;
					}
				}
				sbyte slotCount2 = SharedMethods.GetBuildingSlotCount(blockData.TemplateId);
				if (count2 >= slotCount2)
				{
					return true;
				}
			}
			if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ResourceGoods != -1)
			{
				if (!TryGetElement_CollectBuildingEarningsData(blockKey, out var data3))
				{
					continue;
				}
				if (data3.CollectionResourceList?.Count >= SharedMethods.GetBuildingSlotCount(blockData.TemplateId))
				{
					return true;
				}
			}
			if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ItemList.Count > 0)
			{
				if (!TryGetElement_CollectBuildingEarningsData(blockKey, out var data4))
				{
					continue;
				}
				if (data4.CollectionItemList != null)
				{
					sbyte slotCount3 = SharedMethods.GetBuildingSlotCount(blockData.TemplateId);
					if (data4.CollectionItemList?.Count >= slotCount3)
					{
						return true;
					}
				}
			}
			if (blockData.TemplateId == 49)
			{
				int count3 = GetCanPluckFeatherChickenIds().Count;
				short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
				IReadOnlyList<int> chickensInVillage = GetSettlementChickenIdList(taiwuSettlementId);
				if (count3 >= chickensInVillage.Count)
				{
					return true;
				}
			}
		}
		return false;
	}

	[DomainMethod]
	public int QuickCollectBuildingEarnCount(DataContext context)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		int count = 0;
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId <= 0)
			{
				continue;
			}
			BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
			if (blockData.TemplateId == 47 && DomainManager.Extra.TryGetElement_Feasts((ulong)blockKey, out var feast))
			{
				count += feast.GetInUseGiftSlotCount();
			}
			if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).RecruitPeopleProb.Count > 0)
			{
				if (blockData.TemplateId == 223 || !TryGetElement_CollectBuildingEarningsData(blockKey, out var data) || data.RecruitLevelList == null)
				{
					continue;
				}
				count += data.RecruitLevelList.Count;
			}
			if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ExchangeResourceGoods != -1 && TryGetElement_CollectBuildingEarningsData(blockKey, out var data2))
			{
				if (data2 == null)
				{
					continue;
				}
				for (int i = 0; i < data2.ShopSoldItemEarnList.Count; i++)
				{
					if (data2.ShopSoldItemEarnList[i].First != -1)
					{
						count++;
					}
				}
			}
			if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ResourceGoods != -1)
			{
				if (!TryGetElement_CollectBuildingEarningsData(blockKey, out var data3))
				{
					continue;
				}
				if (data3.CollectionResourceList != null)
				{
					count += data3.CollectionResourceList.Count;
				}
			}
			if (configData.SuccesEvent.Count != 0 && Config.ShopEvent.Instance.GetItem(configData.SuccesEvent[0]).ItemList.Count > 0)
			{
				if (blockData.TemplateId == 222 || !TryGetElement_CollectBuildingEarningsData(blockKey, out var data4))
				{
					continue;
				}
				if (data4.CollectionItemList != null)
				{
					count += data4.CollectionItemList.Count;
				}
			}
			if (blockData.TemplateId == 49)
			{
				count += GetCanPluckFeatherChickenIds().Count;
			}
		}
		return count;
	}

	[DomainMethod]
	public void SetBuildingAutoWork(DataContext context, short blockIndex, bool isAutoWork)
	{
		List<short> autoWorkList = DomainManager.Extra.GetAutoWorkBlockIndexList();
		if (isAutoWork && !autoWorkList.Contains(blockIndex))
		{
			autoWorkList.Add(blockIndex);
			DomainManager.Extra.SetAutoWorkBlockIndexList(autoWorkList, context);
		}
		if (!isAutoWork && autoWorkList.Contains(blockIndex))
		{
			autoWorkList.Remove(blockIndex);
			DomainManager.Extra.SetAutoWorkBlockIndexList(autoWorkList, context);
		}
	}

	[DomainMethod]
	public bool GetBuildingIsAutoWork(short blockIndex)
	{
		List<short> autoWorkList = DomainManager.Extra.GetAutoWorkBlockIndexList();
		return autoWorkList.Contains(blockIndex);
	}

	[DomainMethod]
	public void SetBuildingAutoSold(DataContext context, short blockIndex, bool isAutoSold)
	{
		List<short> autoSoldList = DomainManager.Extra.GetAutoSoldBlockIndexList();
		if (isAutoSold && !autoSoldList.Contains(blockIndex))
		{
			autoSoldList.Add(blockIndex);
			DomainManager.Extra.SetAutoSoldBlockIndexList(autoSoldList, context);
		}
		if (!isAutoSold && autoSoldList.Contains(blockIndex))
		{
			autoSoldList.Remove(blockIndex);
			DomainManager.Extra.SetAutoSoldBlockIndexList(autoSoldList, context);
		}
	}

	[DomainMethod]
	public bool GetBuildingIsAutoSold(short blockIndex)
	{
		List<short> autoSoldList = DomainManager.Extra.GetAutoSoldBlockIndexList();
		return autoSoldList.Contains(blockIndex);
	}

	[DomainMethod]
	public bool GetResidenceIsAutoCheckIn(short blockIndex)
	{
		List<short> autoCheckInList = DomainManager.Extra.GetAutoCheckInResidenceList();
		return autoCheckInList.Contains(blockIndex);
	}

	[DomainMethod]
	public bool GetComfortableIsAutoCheckIn(short blockIndex)
	{
		List<short> autoCheckInList = DomainManager.Extra.GetAutoCheckInComfortableList();
		return autoCheckInList.Contains(blockIndex);
	}

	[DomainMethod]
	public void SetUnlockedWorkingVillagers(DataContext context, int charId, bool add)
	{
		if (charId < 0)
		{
			throw new Exception($"CharId is illegal, id: {charId}");
		}
		List<int> list = DomainManager.Extra.GetUnlockedWorkingVillagers();
		if (add && !list.Contains(charId))
		{
			list.Add(charId);
		}
		if (!add && list.Contains(charId))
		{
			list.Remove(charId);
		}
		DomainManager.Extra.SetUnlockedWorkingVillagers(list, context);
	}

	public void TryRemoveUnlockedWorkingVillager(DataContext context, int charId)
	{
		if (charId < 0)
		{
			throw new Exception($"CharId is illegal, id: {charId}");
		}
		List<int> list = DomainManager.Extra.GetUnlockedWorkingVillagers();
		if (list.Contains(charId))
		{
			list.Remove(charId);
			DomainManager.Extra.SetUnlockedWorkingVillagers(list, context);
		}
	}

	[DomainMethod]
	public List<sbyte> GetXiangshuIdInKungfuRoom()
	{
		return DomainManager.Extra.GetXiangshuIdInKungfuPracticeRoom();
	}

	private bool CanUpdateShopProgress(BuildingBlockKey blockKey)
	{
		if (!TryGetElement_BuildingBlocks(blockKey, out var blockData))
		{
			return false;
		}
		if (!HasShopManagerLeader(blockKey))
		{
			return false;
		}
		BuildingBlockItem configData = blockData.ConfigData;
		if (!blockData.CanUse() || !configData.NeedShopProgress)
		{
			return false;
		}
		if (!AllDependBuildingAvailable(blockKey, blockData.TemplateId, out var _))
		{
			return false;
		}
		if (configData.TemplateId == 105)
		{
			return true;
		}
		ShopEventItem shopEventCfg = Config.ShopEvent.Instance[configData.SuccesEvent[0]];
		sbyte slot = SharedMethods.GetBuildingSlotCount(configData.TemplateId);
		BuildingEarningsData earningsData;
		if (shopEventCfg.ExchangeResourceGoods >= 0)
		{
			return TryGetElement_CollectBuildingEarningsData(blockKey, out earningsData) && earningsData != null && earningsData.ShopSoldItemList != null && !earningsData.ShopSoldItemList.All(ItemKey.Invalid);
		}
		BuildingEarningsData earningsData2;
		if (shopEventCfg.ResourceGoods >= 0)
		{
			return !TryGetElement_CollectBuildingEarningsData(blockKey, out earningsData2) || earningsData2.CollectionResourceList == null || earningsData2.CollectionResourceList.Count < slot;
		}
		BuildingEarningsData earningsData3;
		if (shopEventCfg.ItemList.Count > 0 || shopEventCfg.ItemGradeProbList.Count > 0)
		{
			return !TryGetElement_CollectBuildingEarningsData(blockKey, out earningsData3) || earningsData3.CollectionItemList == null || earningsData3.CollectionItemList.Count < slot;
		}
		BuildingEarningsData earningsData4;
		if (shopEventCfg.RecruitPeopleProb.Count > 0)
		{
			return !TryGetElement_CollectBuildingEarningsData(blockKey, out earningsData4) || earningsData4.RecruitLevelList == null || earningsData4.RecruitLevelList.Count < slot;
		}
		return false;
	}

	private int CalcRecruitGrade(IRandomSource random, BuildingBlockKey blockKey, ref int score)
	{
		bool hasManager;
		int attainment = BuildingTotalAttainment(blockKey, -1, out hasManager);
		score += attainment * (random.NextBool() ? 80 : 120) / 100;
		int[] thresholds = GlobalConfig.Instance.RecruitCharacterGradeScoreThresholds;
		sbyte grade = 8;
		while (grade >= 0 && score <= thresholds[grade])
		{
			grade--;
		}
		grade = Math.Max(grade, 0);
		score = Math.Max(score - thresholds[grade], 0);
		return grade;
	}

	private int CalcSoldItemValue(IRandomSource random, BuildingBlockKey blockKey, BuildingBlockData blockData, ItemKey itemKey, out int basePrice, out BuildingProduceDependencyData dependencyData)
	{
		ItemBase baseItem = DomainManager.Item.GetBaseItem(itemKey);
		int basicPrice = baseItem.GetValue();
		basePrice = Math.Max(basicPrice, 1);
		int saleMiddleValue;
		return CalcSoldItemValueBySpecificBaseLine(random, blockKey, blockData, out dependencyData, basePrice, out saleMiddleValue);
	}

	private int CalcSoldItemValueBySpecificBaseLine(IRandomSource random, BuildingBlockKey blockKey, BuildingBlockData blockData, out BuildingProduceDependencyData dependencyData, int baseLine, out int saleMiddleValue)
	{
		dependencyData = BuildingProduceDependencyData.Invalid;
		dependencyData.RandomFactorLowerLimit = GlobalConfig.Instance.BuildingOutputRandomFactorLowerLimit;
		dependencyData.RandomFactorUpperLimit = GlobalConfig.Instance.BuildingOutputRandomFactorUpperLimit;
		dependencyData.TemplateId = blockData.TemplateId;
		dependencyData.Level = BuildingBlockLevel(blockKey);
		BuildingBlockItem buildingBlockConfig = BuildingBlock.Instance.GetItem(blockData.TemplateId);
		dependencyData.ProductivityFactor = BuildingProductivityByMaxDependencies(blockKey);
		dependencyData.SafetyCultureFactor = CalcSafetyOrCultureFactor(buildingBlockConfig);
		dependencyData.TotalAttainmentFactor = dependencyData.BuildSaleItemAttainmentFactor(BuildingTotalAttainment(blockKey, -1, out var _));
		dependencyData.GainResourcePercentFactor = DomainManager.World.GetGainResourcePercent(6);
		saleMiddleValue = dependencyData.CalcSaleItemPrice(baseLine);
		int saleValue = BuildingRandomCorrection(saleMiddleValue, random);
		BuildingBlockItem blockItem = BuildingBlock.Instance[blockData.TemplateId];
		ShopEventItem shopEventItem = Config.ShopEvent.Instance[blockItem.SuccesEvent[0]];
		sbyte resourceType = SharedMethods.GetBuildingResourceGoodsOrExchangeResourceGoodsType(blockItem, shopEventItem);
		CValuePercentBonus resBuildingBonus = DomainManager.Building.GetBuildingBlockEffect(blockKey.GetLocation(), (resourceType == 7) ? EBuildingScaleEffect.BuildingAuthorityIncomeBonus : EBuildingScaleEffect.BuildingMoneyIncomeBonus);
		return saleValue * resBuildingBonus;
	}

	private int CalcSafetyOrCultureFactor(BuildingBlockItem config)
	{
		SharedMethods.PickSafetyOrCultureFactorSettlements(config, DomainManager.Taiwu.GetAllVisitedSettlements(), out var addition);
		return 100 + addition;
	}

	public ItemKey GetRandomItemByGrade(IRandomSource randomSource, sbyte grade, short itemSubType = -1)
	{
		if (itemSubType == -1)
		{
			itemSubType = ItemSubType.GetRandom(randomSource);
			while (!ItemSubType.IsHobbyType(itemSubType))
			{
				itemSubType = ItemSubType.GetRandom(randomSource);
			}
		}
		short templateId = ItemDomain.GetRandomItemIdInSubType(randomSource, itemSubType, grade);
		sbyte itemType = ItemSubType.GetType(itemSubType);
		return new ItemKey(itemType, 0, templateId, -1);
	}

	public BuildingBlockData GetBuildingBlockData(int templateId)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId == templateId)
			{
				return blockData;
			}
		}
		return null;
	}

	public bool IsShopNeedManager(BuildingBlockKey blockKey, BuildingBlockData blockData)
	{
		BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
		int needProgress = configData.MaxProduceValue;
		DomainManager.World.ApplyChallengeModeBuildingWorkHard(ref needProgress);
		return GetBuildingAttainmentUniversalWhetherCanWork(blockData, blockKey) < needProgress;
	}

	private sbyte GetNeedLifeSkillType(BuildingBlockItem config, BuildingBlockKey blockKey)
	{
		return config.RequireLifeSkillType;
	}

	public bool IsTaiwuVillageHaveSpecifyBuilding(short templateId, bool notBuild = false)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId == templateId)
			{
				if (notBuild)
				{
					return blockData.OperationType != 0;
				}
				return true;
			}
		}
		return false;
	}

	private BuildingBlockKey GetMoreBetterSoldBuilding(BuildingBlockKey originalBlockKey, BuildingBlockData originalBlockData)
	{
		BuildingBlockKey betterBlockKey = BuildingBlockKey.Invalid;
		int orgiSoldValue = (40 + SharedMethods.GetBuildingSlotCount(originalBlockData.TemplateId) * 2) * (100 + GetBuildingAttainmentUniversalWhetherCanWork(originalBlockData, originalBlockKey) / 4) / 100;
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		List<short> autoSoldList = DomainManager.Extra.GetAutoSoldBlockIndexList();
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (autoSoldList.Contains(blockKey.BuildingBlockIndex))
			{
				BuildingEarningsData earnData = GetBuildingEarningData(blockKey);
				if (blockKey.BuildingBlockIndex != originalBlockKey.BuildingBlockIndex && blockData.TemplateId == originalBlockData.TemplateId && GetShopSoldItemCount(earnData) + GetShopSoldEarnCount(earnData) < SharedMethods.GetBuildingSlotCount(blockData.TemplateId))
				{
					int soldValue = GetBuildingAttainmentUniversalWhetherCanWork(blockData, blockKey) * SharedMethods.GetBuildingSlotCount(originalBlockData.TemplateId);
					if (soldValue > orgiSoldValue)
					{
						orgiSoldValue = soldValue;
						betterBlockKey = blockKey;
					}
				}
			}
		}
		return betterBlockKey;
	}

	private IEnumerable<(BuildingBlockKey, BuildingBlockData)> GetTaiwuVillageNotEmptyBuildingBlockData()
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData areaData = DomainManager.Building.GetElement_BuildingAreas(location);
		for (short index = 0; index < areaData.Width * areaData.Width; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			BuildingBlockData blockData = DomainManager.Building.GetElement_BuildingBlocks(blockKey);
			if (blockData.TemplateId > 0)
			{
				yield return (blockKey, blockData);
			}
		}
	}

	public TransferableRecordDataBase GetShopEventRecordData(DataContext context, BuildingBlockKey blockKey)
	{
		ShopEventCollection collection = GetOrCreateShopEventCollection(blockKey);
		TransferableRecordDataBase data = new TransferableRecordDataBase();
		collection.ReadDataWithNormalOrder(data, GetParameters);
		LifeRecordDomain.PostProcess(data);
		return data;
		static string[] GetParameters(int recordType)
		{
			ShopEventItem config = Config.ShopEvent.Instance[recordType];
			if (config != null)
			{
				return config.Parameters ?? Array.Empty<string>();
			}
			AdaptableLog.Warning($"Unable to render ShopEvent with template id {recordType}");
			return null;
		}
	}

	[DomainMethod]
	public void AddFixBook(DataContext context, BuildingBlockKey key, ItemKey itemKey, ItemSourceType itemSourceType)
	{
		if (!TryGetElement_CollectBuildingEarningsData(key, out var earningsData))
		{
			earningsData = new BuildingEarningsData();
			AddElement_CollectBuildingEarningsData(key, earningsData, context);
		}
		DomainManager.Taiwu.RemoveItem(context, itemKey, 1, itemSourceType, deleteItem: false);
		AddBuildingEarningsDataFixBook(context, key, earningsData, itemKey);
	}

	[DomainMethod]
	public (short, BuildingBlockData) ChangeFixBook(DataContext context, BuildingBlockKey key, ItemKey itemKey, ItemSourceType itemSourceType)
	{
		BuildingBlockData blockData = null;
		if (TryGetElement_BuildingBlocks(key, out blockData))
		{
			blockData.OfflineResetShopProgress();
			SetElement_BuildingBlocks(key, blockData, context);
		}
		if (TryGetElement_CollectBuildingEarningsData(key, out var earningsData))
		{
			if (earningsData.FixBookInfoList.Count <= 0)
			{
				return (key.BuildingBlockIndex, blockData);
			}
			ItemKey book = earningsData.FixBookInfoList[0];
			RemoveBuildingEarningsDataFixBook(context, key, earningsData, book);
			DomainManager.Taiwu.AddItem(context, book, 1, itemSourceType);
			if (itemKey.IsValid())
			{
				DomainManager.Taiwu.RemoveItem(context, itemKey, 1, itemSourceType, deleteItem: false);
				AddBuildingEarningsDataFixBook(context, key, earningsData, itemKey);
			}
		}
		return (key.BuildingBlockIndex, blockData);
	}

	[DomainMethod]
	public void ReceiveFixBook(DataContext context, BuildingBlockKey key, bool isPutInInventory)
	{
		if (TryGetElement_CollectBuildingEarningsData(key, out var earningsData) && earningsData.FixBookInfoList.Count > 0)
		{
			ItemKey book = earningsData.FixBookInfoList[0];
			earningsData.FixBookInfoList.Clear();
			RemoveBuildingEarningsDataFixBook(context, key, earningsData, book);
			if (isPutInInventory)
			{
				GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
				taiwu.AddInventoryItem(context, book, 1);
			}
			else
			{
				DomainManager.Taiwu.WarehouseAdd(context, book, 1);
			}
		}
	}

	[DomainMethod]
	public int GetFixBookProgress(DataContext context, BuildingBlockKey key)
	{
		if (!TryGetElement_BuildingBlocks(key, out var data) || !TryGetElement_CollectBuildingEarningsData(key, out var earningsDate) || earningsDate.FixBookInfoList.Count <= 0 || !earningsDate.FixBookInfoList[0].IsValid())
		{
			return 0;
		}
		GameData.Domains.Item.SkillBook skillBook = DomainManager.Item.GetElement_SkillBooks(earningsDate.FixBookInfoList[0].Id);
		int needProgress = skillBook.GetFixProgress().needProgress;
		DomainManager.World.ApplyChallengeModeBuildingWorkHard(ref needProgress);
		return data.ShopProgress * 100 / needProgress;
	}

	private void AddBuildingEarningsDataFixBook(DataContext context, BuildingBlockKey key, BuildingEarningsData earningsData, ItemKey itemKey)
	{
		earningsData.FixBookInfoList.Clear();
		earningsData.FixBookInfoList.Add(itemKey);
		SetElement_CollectBuildingEarningsData(key, earningsData, context);
		DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Building, 105);
	}

	private void RemoveBuildingEarningsDataFixBook(DataContext context, BuildingBlockKey key, BuildingEarningsData earningsData, ItemKey itemKey)
	{
		earningsData.FixBookInfoList.Clear();
		SetElement_CollectBuildingEarningsData(key, earningsData, context);
		DomainManager.Item.RemoveOwner(itemKey, ItemOwnerType.Building, 105);
	}

	[DomainMethod]
	public List<ItemDisplayData> GetTaiwuCanFixBookItemDataList(ItemSourceType itemSourceType)
	{
		List<ItemDisplayData> list = DomainManager.Taiwu.GetAllItems(itemSourceType).list;
		list.RemoveAll(delegate(ItemDisplayData d)
		{
			short itemSubType = ItemTemplateHelper.GetItemSubType(d.Key.ItemType, d.Key.TemplateId);
			if ((uint)(itemSubType - 1000) <= 1u)
			{
				SkillBookPageDisplayData skillBookPagesInfo = DomainManager.Item.GetSkillBookPagesInfo(d.Key);
				return !skillBookPagesInfo.CanFix();
			}
			return true;
		});
		return list;
	}

	[DomainMethod]
	public TransferableRecordDataBase GetTeaHorseCaravanEvent(DataContext context)
	{
		TeaHorseCaravanEventCollection collection = _teaHorseCaravanEventCollection;
		TransferableRecordDataBase data = new TransferableRecordDataBase();
		collection.ReadTeaHorseEventWithNormalOrder(data, GetParameters);
		LifeRecordDomain.PostProcess(data);
		return data;
		static string[] GetParameters(int recordType)
		{
			TeaHorseCaravanEventItem config = TeaHorseCaravanEvent.Instance[recordType];
			if (config != null)
			{
				return config.Parameters ?? Array.Empty<string>();
			}
			AdaptableLog.Warning($"Unable to render TeaHorseCaravanEvent with template id {recordType}");
			return null;
		}
	}

	[DomainMethod]
	public void SetTeaHorseCaravanState(DataContext context, sbyte state)
	{
		if (_teaHorseCaravanData != null)
		{
			_teaHorseCaravanData.CaravanState = state;
			SetTeaHorseCaravanData(_teaHorseCaravanData, context);
		}
	}

	[DomainMethod]
	public void SetTeaHorseCaravanWeather(DataContext context, short weatherId)
	{
		if (_teaHorseCaravanData != null)
		{
			_teaHorseCaravanData.Weather = weatherId;
			SetTeaHorseCaravanData(_teaHorseCaravanData, context);
		}
	}

	[DomainMethod]
	public void GetBackTeaHorseCarryItem(DataContext context, ItemKey itemKey, sbyte itemSource)
	{
		TeaHorseCarryRemove(context, itemKey);
		switch (itemSource)
		{
		case 2:
			DomainManager.Taiwu.WarehouseAdd(context, itemKey, 1);
			break;
		case 3:
			DomainManager.Taiwu.StoreItemInTreasury(context, itemKey, 1);
			break;
		case 4:
			DomainManager.Taiwu.AddStockItem(context, itemKey, 1);
			break;
		default:
			DomainManager.Taiwu.GetTaiwu().AddInventoryItem(context, itemKey, 1);
			break;
		}
	}

	[DomainMethod]
	public void AddItemToTeaHorseCarryItem(DataContext context, ItemKey itemKey, sbyte itemSource)
	{
		if (_teaHorseCaravanData == null)
		{
			_teaHorseCaravanData = new TeaHorseCaravanData();
		}
		switch (itemSource)
		{
		case 2:
		{
			int count = DomainManager.Taiwu.GetWarehouseItemCount(itemKey);
			if (count > 0)
			{
				DomainManager.Taiwu.WarehouseRemove(context, itemKey, 1);
				TeaHorseCarryAdd(context, itemKey, 2);
			}
			return;
		}
		case 3:
		{
			int count3 = DomainManager.Taiwu.GetTreasuryItemCount(itemKey);
			if (count3 > 0)
			{
				DomainManager.Taiwu.RemoveTaiwuItemFromTaiwuStorage(context, itemKey, 1, deleteItem: false);
				TeaHorseCarryAdd(context, itemKey, 3);
			}
			return;
		}
		case 4:
		{
			int count2 = DomainManager.Taiwu.GetStockItemCount(itemKey);
			if (count2 > 0)
			{
				DomainManager.Taiwu.RemoveItem(context, itemKey, 1, ItemSourceType.Stock, deleteItem: false);
				TeaHorseCarryAdd(context, itemKey, 4);
			}
			return;
		}
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		ItemKey[] equipments = taiwu.GetEquipment();
		int slotIndex = equipments.IndexOf(itemKey);
		if (slotIndex >= 0)
		{
			taiwu.ChangeEquipment(context, (sbyte)slotIndex, -1, ItemKey.Invalid);
		}
		int count4 = taiwu.GetInventory().GetInventoryItemCount(itemKey);
		if (count4 > 0)
		{
			taiwu.RemoveInventoryItem(context, itemKey, 1, deleteItem: false);
			TeaHorseCarryAdd(context, itemKey, 1);
		}
	}

	private void TeaHorseCarryAdd(DataContext context, ItemKey itemKey, sbyte from)
	{
		_teaHorseCaravanData.CarryGoodsList.Add((itemKey, from));
		SetTeaHorseCaravanData(_teaHorseCaravanData, context);
		DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Building, 51);
	}

	private void TeaHorseCarryRemove(DataContext context, ItemKey itemKey)
	{
		for (int i = 0; i < _teaHorseCaravanData.CarryGoodsList.Count; i++)
		{
			if (_teaHorseCaravanData.CarryGoodsList[i].Item1.Equals(itemKey))
			{
				_teaHorseCaravanData.CarryGoodsList.RemoveAt(i);
				SetTeaHorseCaravanData(_teaHorseCaravanData, context);
				DomainManager.Item.RemoveOwner(itemKey, ItemOwnerType.Building, 51);
				break;
			}
		}
	}

	[DomainMethod]
	public void ExchangeItemToReplenishment(DataContext context, List<ItemKey> carryItems, List<ItemKey> gainItems)
	{
		short getReplenishmentNum = 0;
		if (carryItems != null)
		{
			foreach (ItemKey item in carryItems)
			{
				foreach (var ele in _teaHorseCaravanData.CarryGoodsList)
				{
					var (itemKey, _) = ele;
					if (itemKey.Equals(item))
					{
						_teaHorseCaravanData.CarryGoodsList.Remove(ele);
						DomainManager.Item.RemoveItem(context, item);
						getReplenishmentNum += GradeToReplenishment(ItemTemplateHelper.GetGrade(item.ItemType, item.TemplateId));
						break;
					}
				}
			}
		}
		if (gainItems != null)
		{
			foreach (ItemKey item2 in gainItems)
			{
				if (_teaHorseCaravanData.ExchangeGoodsList.Contains(item2))
				{
					_teaHorseCaravanData.ExchangeGoodsList.Remove(item2);
					getReplenishmentNum += GradeToReplenishment(ItemTemplateHelper.GetGrade(item2.ItemType, item2.TemplateId));
				}
			}
		}
		getReplenishmentNum = (short)Math.Min(getReplenishmentNum, 100 - _teaHorseCaravanData.CaravanReplenishment);
		_teaHorseCaravanData.CaravanReplenishment += Math.Min(getReplenishmentNum, _teaHorseCaravanData.ExchangeReplenishmentRemainAmount);
		_teaHorseCaravanData.CaravanReplenishment = Math.Min(_teaHorseCaravanData.CaravanReplenishment, (short)100);
		_teaHorseCaravanData.ExchangeReplenishmentRemainAmount = (short)Math.Max(0, _teaHorseCaravanData.ExchangeReplenishmentRemainAmount - getReplenishmentNum);
		SetTeaHorseCaravanData(_teaHorseCaravanData, context);
	}

	private short GradeToReplenishment(sbyte grade)
	{
		return (short)((grade + 1) * 5 + 5);
	}

	private void ResetTeaHorseCaravanData(DataContext context)
	{
		_teaHorseCaravanData.DiaryList = new List<short>();
		_teaHorseCaravanData.CaravanState = 0;
		_teaHorseCaravanData.IsStartSearch = false;
		_teaHorseCaravanData.CaravanAwareness = 100;
		_teaHorseCaravanData.CaravanReplenishment = 100;
		_teaHorseCaravanData.LackReplenishmentTurn = 0;
		_teaHorseCaravanData.IsShowExchangeReplenishment = false;
		_teaHorseCaravanData.IsShowSeachReplenishment = false;
		_teaHorseCaravanData.DistanceToTaiwuVillage = 0;
		_teaHorseCaravanData.StartMonth = 0;
		_teaHorseCaravanData.ExchangeReplenishmentAmountMax = 0;
		_teaHorseCaravanData.SearchReplenishmentMax = 0;
		_teaHorseCaravanData.SearchReplenishmentAmount = 0;
		_teaHorseCaravanData.Terrain = 5;
		SetTeaHorseCaravanData(_teaHorseCaravanData, context);
	}

	public ItemKey GetWestRandomItemByGarde(DataContext context, sbyte grade)
	{
		short templateId = WestItemArrayTwo[context.Random.Next(0, WestItemArrayTwo.Length)][grade - 4];
		sbyte itemType = ItemSubType.GetType(1203);
		return new ItemKey(itemType, 0, templateId, -1);
	}

	[DomainMethod]
	public void StartSearchReplenishment(DataContext context)
	{
		_teaHorseCaravanData.IsStartSearch = true;
		_teaHorseCaravanData.CaravanReplenishment = (short)Math.Min(_teaHorseCaravanData.CaravanReplenishment + _teaHorseCaravanData.SearchReplenishmentAmount, 100);
		_teaHorseCaravanData.SearchReplenishmentMax = (short)Math.Max(0, _teaHorseCaravanData.SearchReplenishmentMax - _teaHorseCaravanData.SearchReplenishmentAmount);
		_teaHorseCaravanData.SearchReplenishmentAmount = Math.Min(_teaHorseCaravanData.SearchReplenishmentAmount, _teaHorseCaravanData.SearchReplenishmentMax);
		if (_teaHorseCaravanData.CaravanReplenishment >= 100 || _teaHorseCaravanData.SearchReplenishmentMax <= 0)
		{
			_teaHorseCaravanData.IsShowSeachReplenishment = false;
		}
		SetTeaHorseCaravanData(_teaHorseCaravanData, context);
	}

	[DomainMethod]
	public void QuickGetExchangeItem(DataContext context, ItemSourceType source = ItemSourceType.Warehouse)
	{
		if (_teaHorseCaravanData == null)
		{
			return;
		}
		for (int i = 0; i < _teaHorseCaravanData.ExchangeGoodsList.Count; i++)
		{
			ItemKey itemKey = _teaHorseCaravanData.ExchangeGoodsList[i];
			itemKey = DomainManager.Taiwu.CreateWarehouseItem(context, itemKey.ItemType, itemKey.TemplateId, 1);
			if (source != ItemSourceType.Warehouse)
			{
				DomainManager.Taiwu.TransferItem(context, 2, (sbyte)source, itemKey, 1, i >= _teaHorseCaravanData.ExchangeGoodsList.Count - 1);
			}
		}
		DomainManager.Taiwu.RecordLifeSummary(context, 58, _teaHorseCaravanData.ExchangeGoodsList.Count);
		_teaHorseCaravanData.ExchangeGoodsList.Clear();
		SetTeaHorseCaravanData(_teaHorseCaravanData, context);
		ResetTeaHorseCaravanData(context);
	}

	[DomainMethod]
	public void QuickDiscardExchangeItem(DataContext context)
	{
		if (_teaHorseCaravanData != null)
		{
			_teaHorseCaravanData.ExchangeGoodsList.Clear();
			SetTeaHorseCaravanData(_teaHorseCaravanData, context);
			ResetTeaHorseCaravanData(context);
		}
	}

	[DomainMethod]
	public void QuickGetSpecificExchangeItem(DataContext context, ItemKey key, ItemSourceType source = ItemSourceType.Warehouse)
	{
		if (_teaHorseCaravanData == null)
		{
			AdaptableLog.Warning($"cannot find item {key} since _teaHorseCaravanData is null");
			return;
		}
		int i = _teaHorseCaravanData.ExchangeGoodsList.Count;
		while (i-- > 0)
		{
			if (_teaHorseCaravanData.ExchangeGoodsList[i] == key)
			{
				key = DomainManager.Taiwu.CreateWarehouseItem(context, key.ItemType, key.TemplateId, 1);
				if (source != ItemSourceType.Warehouse)
				{
					DomainManager.Taiwu.TransferItem(context, 2, (sbyte)source, key, 1, i >= _teaHorseCaravanData.ExchangeGoodsList.Count - 1);
				}
				_teaHorseCaravanData.ExchangeGoodsList.RemoveAt(i);
				DomainManager.Taiwu.RecordLifeSummary(context, 58);
				return;
			}
		}
		AdaptableLog.Warning($"cannot find item {key}");
	}

	[DomainMethod]
	public void DealInfectedPeople(DataContext context, List<int> charList, byte dealType)
	{
		if (charList == null)
		{
			return;
		}
		OrganizationInfo taiwuOrg = DomainManager.Taiwu.GetTaiwu().GetOrganizationInfo();
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		OrganizationInfo tarOrgInfo = new OrganizationInfo(taiwuOrg.OrgTemplateId, 0, principal: true, taiwuOrg.SettlementId);
		int secretSignCount = 0;
		int seniorityValue = 0;
		ProfessionFormulaItem formulaItem = ProfessionFormula.Instance[39];
		int faith = 0;
		int faithCount = 0;
		int savePeopleCount = 0;
		for (int i = 0; i < charList.Count; i++)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charList[i]);
			Location location = character.GetLocation();
			int value = DomainManager.Character.GetSpiritualDebtChangeByInfected(character, 50);
			int happinessNormal = (HappinessType.Ranges[3].min + HappinessType.Ranges[3].max) / 2;
			switch (dealType)
			{
			case 1:
				DomainManager.Extra.ChangeAreaSpiritualDebt(context, location.AreaId, value);
				DomainManager.Character.GroupMove(context, character, taiwuVillageLocation);
				DomainManager.Character.RemoveXiangshuInfection(context, character, 0);
				DomainManager.Organization.ChangeOrganization(context, character, tarOrgInfo);
				character.SetHappiness((sbyte)happinessNormal, context);
				secretSignCount += ProfessionRelatedConstants.TaoistMonkSkill2GetSecretSignCountBySave[character.GetConsummateLevel()];
				seniorityValue += formulaItem.Calculate(character.GetOrganizationInfo().Grade);
				character.SavedFromInfected(context, batchMode: true);
				faith += character.SaveFromInfectedGainFaith;
				faithCount++;
				savePeopleCount++;
				DomainManager.Extra.TryRemoveStoneRoomCharacter(context, character);
				break;
			case 2:
				DomainManager.Extra.ChangeAreaSpiritualDebt(context, location.AreaId, value);
				DomainManager.Character.RemoveXiangshuInfection(context, character, 0);
				character.SetHappiness((sbyte)happinessNormal, context);
				secretSignCount += ProfessionRelatedConstants.TaoistMonkSkill2GetSecretSignCountBySave[character.GetConsummateLevel()];
				seniorityValue += formulaItem.Calculate(character.GetOrganizationInfo().Grade);
				character.SavedFromInfected(context, batchMode: true);
				faith += character.SaveFromInfectedGainFaith;
				faithCount++;
				savePeopleCount++;
				DomainManager.Extra.TryRemoveStoneRoomCharacter(context, character);
				break;
			case 3:
			{
				DomainManager.Extra.ChangeAreaSpiritualDebt(context, location.AreaId, -value);
				List<Location> locations = ObjectPool<List<Location>>.Instance.Get();
				DomainManager.Map.GetAreaNotSettlementLocations(locations, location.AreaId);
				Location randomLocation = locations[context.Random.Next(0, locations.Count)];
				DomainManager.Character.GroupMove(context, character, randomLocation);
				DomainManager.Character.GroupMove(context, character, randomLocation);
				ObjectPool<List<Location>>.Instance.Return(locations);
				DomainManager.Extra.TryRemoveStoneRoomCharacter(context, character);
				break;
			}
			case 4:
				DomainManager.Extra.ChangeAreaSpiritualDebt(context, location.AreaId, -value);
				DomainManager.Character.GroupMove(context, character, taiwuVillageLocation);
				DomainManager.Character.MakeCharacterDead(context, character, 9, new CharacterDeathInfo(character.GetValidLocation())
				{
					KillerId = DomainManager.Taiwu.GetTaiwuCharId()
				});
				secretSignCount += ProfessionRelatedConstants.TaoistMonkSkill2GetSecretSignCount[character.GetConsummateLevel()];
				seniorityValue += formulaItem.Calculate(character.GetOrganizationInfo().Grade) / 2;
				break;
			}
		}
		DomainManager.Taiwu.RecordLifeSummary(context, 12, savePeopleCount);
		if (seniorityValue > 0)
		{
			DomainManager.Extra.ChangeProfessionSeniority(context, 5, seniorityValue);
		}
		if (secretSignCount > 0 && DomainManager.Extra.IsProfessionalSkillUnlocked(5, 2))
		{
			GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
			ItemKey itemKey = DomainManager.Item.CreateItem(context, 12, 265);
			taiwuChar.AddInventoryItem(context, itemKey, secretSignCount);
			DomainManager.TaiwuEvent.OnEvent_TaiwuGotTianjieFulu(-1, itemKey, secretSignCount);
			DomainManager.World.GetInstantNotificationCollection().AddGetItem(taiwuChar.GetId(), 12, 265);
		}
		if (faith > 0)
		{
			DomainManager.World.GetInstantNotificationCollection().AddGainFuyuFaith2(faithCount, faith);
		}
	}

	internal bool TryCalcShopManagementYieldAmount(IRandomSource random, BuildingBlockKey blockKey, out sbyte resourceType, out int amount, out BuildingProduceDependencyData dependencyData, int valuationInclination = 0)
	{
		resourceType = -1;
		amount = 0;
		dependencyData = BuildingProduceDependencyData.Invalid;
		if (!TryGetElement_BuildingBlocks(blockKey, out var blockData))
		{
			return false;
		}
		BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
		if (configData.IsShop && configData.SuccesEvent.Count > 0)
		{
			ShopEventItem successShopEventConfig = Config.ShopEvent.Instance[configData.SuccesEvent[0]];
			switch (valuationInclination)
			{
			case 1:
				random = new MaxRandomGenerator();
				break;
			case -1:
				random = new MinRandomGenerator();
				break;
			}
			sbyte level = blockData.CalcUnlockedLevelCount();
			if (successShopEventConfig.ResourceGoods != -1)
			{
				dependencyData.TemplateId = blockData.TemplateId;
				dependencyData.Level = level;
				dependencyData.ProductivityFactor = BuildingProductivityByMaxDependencies(blockKey);
				dependencyData.SafetyCultureFactor = CalcSafetyOrCultureFactor(configData);
				dependencyData.TotalAttainmentFactor = BuildingTotalAttainment(blockKey, -1, out var hasManager);
				dependencyData.GainResourcePercentFactor = DomainManager.World.GetGainResourcePercent(5);
				if (blockData.TemplateId == 215)
				{
					dependencyData.RandomFactorUpperLimit = GlobalConfig.Instance.BuildingOutputRandomFactorUpperLimit * 3;
					dependencyData.RandomFactorLowerLimit = GlobalConfig.Instance.BuildingOutputRandomFactorLowerLimit / 2;
					resourceType = successShopEventConfig.ResourceGoods;
					amount = BuildingRandomCorrection(dependencyData.GamblingHouseOutput, random);
					CValuePercentBonus resBuildingBonus = DomainManager.Building.GetBuildingBlockEffect(blockKey.GetLocation(), EBuildingScaleEffect.BuildingMoneyIncomeBonus);
					amount *= resBuildingBonus;
					if (hasManager)
					{
						if (!DomainManager.Extra.TryGetElement_BuildingMoneyPrestigeSuccessRateCompensation((ulong)blockKey, out var compensation))
						{
							compensation = 0;
						}
						if (1 == 0)
						{
						}
						bool flag = valuationInclination switch
						{
							1 => true, 
							-1 => false, 
							_ => random.CheckPercentProb(BuildingManageHarvestSpecialSuccessRate(blockKey, -1) + compensation), 
						};
						if (1 == 0)
						{
						}
						if (flag)
						{
							amount *= 3;
						}
						else
						{
							amount /= 2;
						}
						return true;
					}
				}
				else if (blockData.TemplateId == 216)
				{
					dependencyData.RandomFactorUpperLimit = GlobalConfig.Instance.BuildingOutputRandomFactorUpperLimit * 3;
					dependencyData.RandomFactorLowerLimit = GlobalConfig.Instance.BuildingOutputRandomFactorLowerLimit / 2;
					resourceType = successShopEventConfig.ResourceGoods;
					amount = BuildingRandomCorrection(dependencyData.BrothelOutput, random);
					CValuePercentBonus resBuildingBonus2 = DomainManager.Building.GetBuildingBlockEffect(blockKey.GetLocation(), EBuildingScaleEffect.BuildingMoneyIncomeBonus);
					amount *= resBuildingBonus2;
					if (hasManager)
					{
						if (!DomainManager.Extra.TryGetElement_BuildingMoneyPrestigeSuccessRateCompensation((ulong)blockKey, out var compensation2))
						{
							compensation2 = 0;
						}
						if (1 == 0)
						{
						}
						bool flag = valuationInclination switch
						{
							1 => true, 
							-1 => false, 
							_ => random.CheckPercentProb(BuildingManageHarvestSpecialSuccessRate(blockKey, -1) + compensation2), 
						};
						if (1 == 0)
						{
						}
						if (flag)
						{
							amount *= 3;
						}
						else
						{
							amount /= 2;
						}
						return true;
					}
				}
				else
				{
					resourceType = successShopEventConfig.ResourceGoods;
					dependencyData.RandomFactorUpperLimit = GlobalConfig.Instance.BuildingOutputRandomFactorUpperLimit;
					dependencyData.RandomFactorLowerLimit = GlobalConfig.Instance.BuildingOutputRandomFactorLowerLimit;
					amount = ((resourceType == 7) ? dependencyData.AuthorityBuildingOutput : dependencyData.MoneyBuildingOutput);
					CValuePercentBonus resBuildingBonus3 = DomainManager.Building.GetBuildingBlockEffect(blockKey.GetLocation(), (resourceType == 7) ? EBuildingScaleEffect.BuildingAuthorityIncomeBonus : EBuildingScaleEffect.BuildingMoneyIncomeBonus);
					amount *= resBuildingBonus3;
					amount = BuildingRandomCorrection(amount, random);
					if (hasManager)
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	[DomainMethod]
	public BuildingManageYieldTipsData GetShopManagementYieldTipsData(DataContext context, BuildingBlockKey blockKey)
	{
		BuildingManageYieldTipsData tipsData = new BuildingManageYieldTipsData(0);
		if (!TryGetElement_ShopManagerDict(blockKey, out var list) || list.GetRealCount() == 0)
		{
			return tipsData;
		}
		if (TryGetElement_BuildingBlocks(blockKey, out var blockData))
		{
			BuildingBlockItem configData = BuildingBlock.Instance.GetItem(blockData.TemplateId);
			if (!SharedMethods.BuildingIsShopWithEvent(configData))
			{
				return tipsData;
			}
			sbyte lifeSkillType = GetNeedLifeSkillType(configData, blockKey);
			ShopEventItem successShopEventConfig = Config.ShopEvent.Instance[configData.SuccesEvent[0]];
			int addition;
			List<SettlementDisplayData> settlements = SharedMethods.PickSafetyOrCultureFactorSettlements(configData, DomainManager.Taiwu.GetAllVisitedSettlements(), out addition);
			if (settlements.Count > 0 && addition > 0)
			{
				bool isCulture = configData.RequireCulture != 0;
				tipsData.SafetyOrCultureFactorSettlementsAndPickValue = new Dictionary<int, SettlementDisplayData>();
				foreach (SettlementDisplayData settlement in settlements)
				{
					int value = SharedMethods.CalcSafetyOrCultureFactorSettlementPickValue(isCulture ? configData.RequireCulture : configData.RequireSafety, isCulture ? settlement.Culture : settlement.Safety);
					if (value > 0)
					{
						tipsData.SafetyOrCultureFactorSettlementsAndPickValue.Add(settlement.SettlementId, settlement);
					}
				}
			}
			if (configData.IsCollectResourceBuilding)
			{
				sbyte resourceType = GetCollectBuildingResourceType(blockKey);
				if (resourceType > 5)
				{
					resourceType = 5;
				}
				tipsData.ResourceOutputValuation = CalcResourceOutputCount(blockKey, resourceType, tipsData.ProduceDependencies);
				tipsData.ProduceResourceType = resourceType;
				tipsData.ManagerAttainment = 0;
				if (TryGetElement_ShopManagerDict(blockKey, out var managerList))
				{
					for (int i = 0; i < managerList.GetCount(); i++)
					{
						int charId = managerList.GetCollection()[i];
						if (GameData.Domains.Character.Character.IsCharacterIdValid(charId) && DomainManager.Character.TryGetElement_Objects(charId, out var character))
						{
							tipsData.ManagerAttainment += character.GetLifeSkillAttainment(lifeSkillType);
						}
					}
				}
			}
			else if (SharedMethods.IsBuildingProduceMoneyAuthority(configData, successShopEventConfig))
			{
				TryCalcShopManagementYieldAmount(context.Random, blockKey, out var resourceType2, out tipsData.ManageProduceValuationMin, out tipsData.BuildingProduceDependencyData, -1);
				TryCalcShopManagementYieldAmount(context.Random, blockKey, out resourceType2, out tipsData.ManageProduceValuationMax, out tipsData.BuildingProduceDependencyData, 1);
				tipsData.ProduceResourceType = successShopEventConfig.ResourceGoods;
				if (tipsData.ManageProduceValuationMin > tipsData.ManageProduceValuationMax)
				{
					ref int manageProduceValuationMin = ref tipsData.ManageProduceValuationMin;
					ref int manageProduceValuationMax = ref tipsData.ManageProduceValuationMax;
					int manageProduceValuationMax2 = tipsData.ManageProduceValuationMax;
					int manageProduceValuationMin2 = tipsData.ManageProduceValuationMin;
					manageProduceValuationMin = manageProduceValuationMax2;
					manageProduceValuationMax = manageProduceValuationMin2;
				}
				tipsData.ManagerAttainment = 0;
				if (TryGetElement_ShopManagerDict(blockKey, out var managerList2))
				{
					for (int j = 0; j < managerList2.GetCount(); j++)
					{
						int charId2 = managerList2.GetCollection()[j];
						if (GameData.Domains.Character.Character.IsCharacterIdValid(charId2) && DomainManager.Character.TryGetElement_Objects(charId2, out var character2))
						{
							tipsData.ManagerAttainment += character2.GetLifeSkillAttainment(lifeSkillType);
						}
					}
				}
			}
			else if (SharedMethods.IsBuildingSoldItem(configData, successShopEventConfig))
			{
				tipsData.ManageProduceValuationMin = CalcSoldItemValueBySpecificBaseLine(new MinRandomGenerator(), blockKey, blockData, out tipsData.BuildingProduceDependencyData, 100, out var manageProduceValuationMin2);
				tipsData.ManageProduceValuationMax = CalcSoldItemValueBySpecificBaseLine(new MaxRandomGenerator(), blockKey, blockData, out tipsData.BuildingProduceDependencyData, 100, out manageProduceValuationMin2);
			}
		}
		return tipsData;
	}

	public void UpgradeTeaHorseCaravanByAwareness(DataContext context)
	{
		if (_teaHorseCaravanData == null)
		{
			return;
		}
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData taiwuBuildingAreaData = DomainManager.Building.GetBuildingAreaData(taiwuVillageLocation);
		BuildingBlockKey key = FindBuildingKey(taiwuVillageLocation, taiwuBuildingAreaData, 51, checkUsable: false);
		if (!DomainManager.Building.TryGetElement_BuildingBlocks(key, out var blockDataEx))
		{
			return;
		}
		sbyte currentLevel = blockDataEx.CalcUnlockedLevelCount();
		short[] table = GlobalConfig.Instance.TeaHorseCaravanLevelToAwareness;
		int targetLevel = -1;
		for (int i = table.Length - 1; i >= 0; i--)
		{
			if (_teaHorseCaravanData.CaravanAwareness >= table[i])
			{
				targetLevel = i + 1;
				break;
			}
		}
		if (targetLevel != -1 && targetLevel > currentLevel)
		{
			UpgradeToLevelUnchecked(context, key, blockDataEx, targetLevel);
			DomainManager.World.RequestSetStat(context, 56, targetLevel);
		}
	}

	[DomainMethod]
	public List<ItemDisplayData> GetAllPawnShopItem(DataContext context, bool getItem)
	{
		IEnumerable<(BuildingBlockKey, BuildingBlockData)> blockDataList = GetTaiwuVillageNotEmptyBuildingBlockData();
		List<ItemKey> itemKeyList = new List<ItemKey>();
		foreach (var (blockKey, blockData) in blockDataList)
		{
			if (blockData.TemplateId != 222 || !TryGetElement_CollectBuildingEarningsData(blockKey, out var earnData) || earnData.CollectionItemList == null)
			{
				continue;
			}
			itemKeyList.AddRange(earnData.CollectionItemList);
			if (getItem)
			{
				int count = earnData.CollectionItemList.Count;
				for (int i = 0; i < count; i++)
				{
					AcceptBuildingBlockCollectEarning(context, blockKey, 0, isPutInInventory: false, isSetData: false, isCostMoney: true);
				}
				SetElement_CollectBuildingEarningsData(blockKey, earnData, context);
			}
		}
		return DomainManager.Item.GetItemDisplayDataListOptional(itemKeyList, DomainManager.Taiwu.GetTaiwuCharId(), -1);
	}

	[DomainMethod]
	public BuildingEarningDisplayData GetBuildingEarningDisplayData(DataContext context, BuildingBlockKey blockKey)
	{
		BuildingEarningDisplayData displayData = new BuildingEarningDisplayData
		{
			AutoSoldItem = GetBuildingIsAutoSold(blockKey.BuildingBlockIndex),
			AutoArrange = GetBuildingIsAutoWork(blockKey.BuildingBlockIndex),
			AutoCheckIn = (GetResidenceIsAutoCheckIn(blockKey.BuildingBlockIndex) || GetComfortableIsAutoCheckIn(blockKey.BuildingBlockIndex))
		};
		BuildingBlockData blockData = GetBuildingBlockData(blockKey);
		BuildingBlockItem configData = BuildingBlock.Instance[blockData.TemplateId];
		if (configData.TemplateId == 46 && TryGetElement_Residences(blockKey, out var residentList))
		{
			displayData.Residences = new List<CharacterDisplayData>();
			foreach (int charId in residentList.GetCollection())
			{
				if (charId >= 0)
				{
					displayData.Residences.Add(DomainManager.Character.GetCharacterDisplayData(charId));
				}
			}
		}
		BuildingEarningsData earningData = GetBuildingEarningData(blockKey);
		if (earningData != null)
		{
			displayData.CollectionItemDisplayList = DomainManager.Item.GetItemDisplayDataListOptional(earningData.CollectionItemList.Where((ItemKey e) => e.IsValid()).ToList(), -1, -1);
			displayData.FixBookInfoDisplayList = DomainManager.Item.GetItemDisplayDataListOptional(earningData.FixBookInfoList, -1, -1);
			displayData.ShopSoldItemDisplayList = GetShopSoldItemDisplayList(earningData.ShopSoldItemList);
			displayData.ShopSoldItemEarnList = earningData.ShopSoldItemEarnList;
			displayData.CollectionResourceList = earningData.CollectionResourceList;
			displayData.RecruitLevelList = earningData.RecruitLevelList;
			displayData.RecruitCharacterDataList = DomainManager.Extra.RequestRecruitCharacterDataList(context, blockKey);
			if (configData.TemplateId == 47 && TryGetElement_ComfortableHouses(blockKey, out var comfortableList))
			{
				displayData.ComfortableHouses = new List<CharacterDisplayData>();
				foreach (int charId2 in comfortableList.GetCollection())
				{
					if (charId2 >= 0)
					{
						displayData.ComfortableHouses.Add(DomainManager.Character.GetCharacterDisplayData(charId2));
					}
				}
			}
		}
		if (!configData.IsShop || !TryGetElement_ShopManagerDict(blockKey, out var shopManagerList))
		{
			return displayData;
		}
		displayData.ManagerDisplayDataList = new List<BuildingManagerDisplayData>();
		List<int> collection = shopManagerList.GetCollection();
		for (int i = 0; i < collection.Count; i++)
		{
			int charId3 = collection[i];
			if (DomainManager.Character.IsCharacterAlive(charId3))
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId3);
				(sbyte leftPotential, sbyte teachBookGrade, bool matchRole) taiwuVillagerTeachData = DomainManager.Taiwu.GetTaiwuVillagerTeachData(character);
				sbyte potentialLeft = taiwuVillagerTeachData.leftPotential;
				sbyte bookGrade = taiwuVillagerTeachData.teachBookGrade;
				bool matchRole = taiwuVillagerTeachData.matchRole;
				BuildingManagerDisplayData managerDisplayData = new BuildingManagerDisplayData
				{
					CharacterDisplayData = DomainManager.Character.GetCharacterDisplayData(charId3),
					IsLeader = (i == 0),
					LeftPotentialCount = potentialLeft,
					LeaderRoleMatch = matchRole,
					LeaderTeachGrade = bookGrade
				};
				displayData.ManagerDisplayDataList.Add(managerDisplayData);
			}
		}
		return displayData;
	}

	private List<ItemDisplayData> GetShopSoldItemDisplayList(List<ItemKey> list)
	{
		List<ItemDisplayData> displayDataList = new List<ItemDisplayData>();
		for (int i = 0; i < list.Count; i++)
		{
			displayDataList.Add((!list[i].IsValid()) ? null : DomainManager.Item.GetItemDisplayData(list[i]));
		}
		return displayDataList;
	}

	[DomainMethod]
	public TaiwuShrineDisplayData GetShrineDisplayData(DataContext context, short areaId, short blockId, short buildingBlockIndex)
	{
		BuildingBlockKey blockKey = new BuildingBlockKey(areaId, blockId, buildingBlockIndex);
		TaiwuShrineDisplayData displayData = new TaiwuShrineDisplayData
		{
			Authority = CalculateGainAuthorityByShrinePerMonth(blockKey),
			CharIdList = GetTaiwuShrineStudentList()
		};
		displayData.CharIdList.Insert(0, DomainManager.Taiwu.GetTaiwuCharId());
		return displayData;
	}

	[DomainMethod]
	public void TeachSkill(DataContext context, int characterId, SkillQualificationBonus bonus)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(characterId);
		if (character == null)
		{
			throw new KeyNotFoundException($"Not found Character with charId:{characterId}");
		}
		List<SkillQualificationBonus> bonusList = character.GetSkillQualificationBonuses();
		if (bonusList.Count < 11)
		{
			bonusList.Add(bonus);
			sbyte skillGroup = bonus.GetSkillGroupAndType().skillGroup;
			if (skillGroup == 1 && !character.GetLearnedCombatSkills().Contains(bonus.SkillId))
			{
				DomainManager.Character.LearnCombatSkill(context, characterId, bonus.SkillId, 0);
				int seniority = ProfessionFormulaImpl.Calculate(53, Config.CombatSkill.Instance[bonus.SkillId].Grade);
				DomainManager.Extra.ChangeProfessionSeniority(context, 7, seniority);
			}
			else if (skillGroup == 0 && character.FindLearnedLifeSkillIndex(bonus.SkillId) < 0)
			{
				DomainManager.Character.LearnLifeSkill(context, characterId, bonus.SkillId, 0);
				int seniority2 = ProfessionFormulaImpl.Calculate(104, LifeSkill.Instance[bonus.SkillId].Grade);
				DomainManager.Extra.ChangeProfessionSeniority(context, 16, seniority2);
			}
			ConsumeResource(context, 7, _shrineBuyTimes * GlobalConfig.Instance.ShrineAuthorityPerTime);
			SetShrineBuyTimes((ushort)(_shrineBuyTimes + 1), context);
			character.SetSkillQualificationBonuses(bonusList, context);
		}
	}

	private List<int> GetTaiwuShrineStudentList()
	{
		List<int> list = new List<int>();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		OrgMemberCollection members = settlement.GetMembers();
		List<int> memberCharIdList = new List<int>();
		members.GetAllMembers(memberCharIdList);
		foreach (int charId in memberCharIdList)
		{
			if (charId != taiwuCharId && DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetAgeGroup() != 0 && !character.IsCompletelyInfected())
			{
				list.Add(charId);
			}
		}
		HashSet<int> groupHashSet = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		list.Sort((int l, int r) => (!groupHashSet.Contains(l) || groupHashSet.Contains(r)) ? 1 : (-1));
		return list;
	}

	[DomainMethod]
	public bool AddLocationMark(DataContext context, Location location)
	{
		if (TryGetElement_LocationMarkHashSet(location, out var _))
		{
			return false;
		}
		AddElement_LocationMarkHashSet(location, default(VoidValue), context);
		return true;
	}

	[DomainMethod]
	public bool RemoveLocationMark(DataContext context, Location location)
	{
		if (!TryGetElement_LocationMarkHashSet(location, out var _))
		{
			return false;
		}
		RemoveElement_LocationMarkHashSet(location, context);
		return true;
	}

	public HashSetAsDictionary<Location> GetAllLocationMark()
	{
		return _locationMarkHashSet;
	}

	[DomainMethod]
	public List<int> RequestUnlockedWorkingVillagers()
	{
		return DomainManager.Extra.GetUnlockedWorkingVillagers();
	}

	public int GetVillagerRoleCapacity(short roleTemplateId)
	{
		return VillagerRole.Instance[roleTemplateId].MaxCount;
	}

	public void GetVillagerRoleCapacitiesDetail(short roleTemplateId, ref List<IntPair> detailList)
	{
		List<Location> taiwuBuildingList = GetTaiwuBuildingAreas();
		for (int i = 0; i < taiwuBuildingList.Count; i++)
		{
			Location location = taiwuBuildingList[i];
			BuildingAreaData areaData = GetElement_BuildingAreas(location);
			short index = 0;
			short len = (short)(areaData.Width * areaData.Width);
			while (index < len)
			{
				BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
				BuildingBlockData blockData = GetElement_BuildingBlocks(blockKey);
				sbyte level = blockData.CalcUnlockedLevelCount();
				if (blockData.RootBlockIndex < 0 && level > 0)
				{
					BuildingBlockItem buildingCfg = BuildingBlock.Instance[blockData.TemplateId];
					if (buildingCfg.ExpandInfos != null && buildingCfg.VillagerRoleTemplateIds != null && buildingCfg.VillagerRoleTemplateIds.Exist(roleTemplateId))
					{
						foreach (short buildingScaleId in buildingCfg.ExpandInfos)
						{
							BuildingScaleItem buildingScaleCfg = BuildingScale.Instance[buildingScaleId];
							detailList.Add(new IntPair(blockData.TemplateId, buildingScaleCfg.LevelEffect.GetOrLast(level - 1)));
						}
					}
				}
				index++;
			}
		}
	}

	[DataUpgrader(Version = "0.0.81.31", Date = "2026/01/06")]
	private void TempFixUnlockedWorkingVillagers(DataContext context)
	{
		List<int> lst = (from id in DomainManager.Extra.GetUnlockedWorkingVillagers()
			where DomainManager.Character.TryGetElement_Objects(id, out var _)
			select id).ToList();
		if (lst.Count != DomainManager.Extra.GetUnlockedWorkingVillagers().Count)
		{
			AdaptableLog.TagWarning("[Should be Dev only]", $"remove dead character. original unlocked: {DomainManager.Extra.GetUnlockedWorkingVillagers().Count}, remain: {lst.Count}");
		}
		DomainManager.Extra.SetUnlockedWorkingVillagers(lst, context);
	}

	public BuildingDomain()
		: base(30)
	{
		_buildingAreas = new Dictionary<Location, BuildingAreaData>(0);
		_buildingBlocks = new Dictionary<BuildingBlockKey, BuildingBlockData>(0);
		_taiwuBuildingAreas = new List<Location>();
		_CollectBuildingResourceType = new Dictionary<BuildingBlockKey, sbyte>(0);
		_buildingOperatorDict = new Dictionary<BuildingBlockKey, CharacterList>(0);
		_customBuildingName = new Dictionary<BuildingBlockKey, int>(0);
		_newCompleteOperationBuildings = new List<BuildingBlockKey>();
		_chicken = new Dictionary<int, Chicken>(0);
		_makeItemDict = new Dictionary<BuildingBlockKey, MakeItemDataObsolete>(0);
		_residences = new Dictionary<BuildingBlockKey, CharacterList>(0);
		_comfortableHouses = new Dictionary<BuildingBlockKey, CharacterList>(0);
		_homeless = default(CharacterList);
		_samsaraPlatformAddMainAttributes = default(MainAttributes);
		_samsaraPlatformAddCombatSkillQualifications = default(CombatSkillShorts);
		_samsaraPlatformAddLifeSkillQualifications = default(LifeSkillShorts);
		_samsaraPlatformSlots = new IntPair[6];
		_samsaraPlatformBornDict = new Dictionary<int, IntPair>(0);
		_collectBuildingEarningsData = new Dictionary<BuildingBlockKey, BuildingEarningsData>(0);
		_shopManagerDict = new Dictionary<BuildingBlockKey, CharacterList>(0);
		_teaHorseCaravanData = new TeaHorseCaravanData();
		_shrineBuyTimes = 0;
		_locationMarkHashSet = new HashSetAsDictionary<Location>();
		_comfortableHousesAutoCheckInType = new Dictionary<BuildingBlockKey, bool>(0);
		_lockedResidences = new Dictionary<BuildingBlockKey, CharacterSet>(0);
		_lockedComfortableHouses = new Dictionary<BuildingBlockKey, CharacterSet>(0);
		_shopManagerUpgradeQualificationDict = new Dictionary<int, int>(0);
		_featherValue = 0;
		_teaHorseCaravanEventCollection = new TeaHorseCaravanEventCollection();
		_newlyCreatedBuildingIndexes = new List<short>();
		_makeItemDataDict = new Dictionary<BuildingBlockKey, MakeItemData>(0);
		OnInitializedDomainData();
	}

	public BuildingAreaData GetElement_BuildingAreas(Location elementId)
	{
		return _buildingAreas[elementId];
	}

	public bool TryGetElement_BuildingAreas(Location elementId, out BuildingAreaData value)
	{
		return _buildingAreas.TryGetValue(elementId, out value);
	}

	private void AddElement_BuildingAreas(Location elementId, BuildingAreaData value, DataContext context)
	{
		_buildingAreas.Add(elementId, value);
		_modificationsBuildingAreas.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void SetElement_BuildingAreas(Location elementId, BuildingAreaData value, DataContext context)
	{
		_buildingAreas[elementId] = value;
		_modificationsBuildingAreas.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_BuildingAreas(Location elementId, DataContext context)
	{
		_buildingAreas.Remove(elementId);
		_modificationsBuildingAreas.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void ClearBuildingAreas(DataContext context)
	{
		_buildingAreas.Clear();
		_modificationsBuildingAreas.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	public BuildingBlockData GetElement_BuildingBlocks(BuildingBlockKey elementId)
	{
		return _buildingBlocks[elementId];
	}

	public bool TryGetElement_BuildingBlocks(BuildingBlockKey elementId, out BuildingBlockData value)
	{
		return _buildingBlocks.TryGetValue(elementId, out value);
	}

	private void AddElement_BuildingBlocks(BuildingBlockKey elementId, BuildingBlockData value, DataContext context)
	{
		_buildingBlocks.Add(elementId, value);
		_modificationsBuildingBlocks.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private void SetElement_BuildingBlocks(BuildingBlockKey elementId, BuildingBlockData value, DataContext context)
	{
		_buildingBlocks[elementId] = value;
		_modificationsBuildingBlocks.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_BuildingBlocks(BuildingBlockKey elementId, DataContext context)
	{
		_buildingBlocks.Remove(elementId);
		_modificationsBuildingBlocks.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private void ClearBuildingBlocks(DataContext context)
	{
		_buildingBlocks.Clear();
		_modificationsBuildingBlocks.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	public List<Location> GetTaiwuBuildingAreas()
	{
		return _taiwuBuildingAreas;
	}

	private void SetTaiwuBuildingAreas(List<Location> value, DataContext context)
	{
		_taiwuBuildingAreas = value;
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	public sbyte GetElement_CollectBuildingResourceType(BuildingBlockKey elementId)
	{
		return _CollectBuildingResourceType[elementId];
	}

	public bool TryGetElement_CollectBuildingResourceType(BuildingBlockKey elementId, out sbyte value)
	{
		return _CollectBuildingResourceType.TryGetValue(elementId, out value);
	}

	private void AddElement_CollectBuildingResourceType(BuildingBlockKey elementId, sbyte value, DataContext context)
	{
		_CollectBuildingResourceType.Add(elementId, value);
		_modificationsCollectBuildingResourceType.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void SetElement_CollectBuildingResourceType(BuildingBlockKey elementId, sbyte value, DataContext context)
	{
		_CollectBuildingResourceType[elementId] = value;
		_modificationsCollectBuildingResourceType.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_CollectBuildingResourceType(BuildingBlockKey elementId, DataContext context)
	{
		_CollectBuildingResourceType.Remove(elementId);
		_modificationsCollectBuildingResourceType.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void ClearCollectBuildingResourceType(DataContext context)
	{
		_CollectBuildingResourceType.Clear();
		_modificationsCollectBuildingResourceType.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	public CharacterList GetElement_BuildingOperatorDict(BuildingBlockKey elementId)
	{
		return _buildingOperatorDict[elementId];
	}

	public bool TryGetElement_BuildingOperatorDict(BuildingBlockKey elementId, out CharacterList value)
	{
		return _buildingOperatorDict.TryGetValue(elementId, out value);
	}

	private void AddElement_BuildingOperatorDict(BuildingBlockKey elementId, CharacterList value, DataContext context)
	{
		_buildingOperatorDict.Add(elementId, value);
		_modificationsBuildingOperatorDict.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	private void SetElement_BuildingOperatorDict(BuildingBlockKey elementId, CharacterList value, DataContext context)
	{
		_buildingOperatorDict[elementId] = value;
		_modificationsBuildingOperatorDict.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_BuildingOperatorDict(BuildingBlockKey elementId, DataContext context)
	{
		_buildingOperatorDict.Remove(elementId);
		_modificationsBuildingOperatorDict.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	private void ClearBuildingOperatorDict(DataContext context)
	{
		_buildingOperatorDict.Clear();
		_modificationsBuildingOperatorDict.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	public int GetElement_CustomBuildingName(BuildingBlockKey elementId)
	{
		return _customBuildingName[elementId];
	}

	public bool TryGetElement_CustomBuildingName(BuildingBlockKey elementId, out int value)
	{
		return _customBuildingName.TryGetValue(elementId, out value);
	}

	private void AddElement_CustomBuildingName(BuildingBlockKey elementId, int value, DataContext context)
	{
		_customBuildingName.Add(elementId, value);
		_modificationsCustomBuildingName.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void SetElement_CustomBuildingName(BuildingBlockKey elementId, int value, DataContext context)
	{
		_customBuildingName[elementId] = value;
		_modificationsCustomBuildingName.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_CustomBuildingName(BuildingBlockKey elementId, DataContext context)
	{
		_customBuildingName.Remove(elementId);
		_modificationsCustomBuildingName.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void ClearCustomBuildingName(DataContext context)
	{
		_customBuildingName.Clear();
		_modificationsCustomBuildingName.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private List<BuildingBlockKey> GetNewCompleteOperationBuildings()
	{
		return _newCompleteOperationBuildings;
	}

	private void SetNewCompleteOperationBuildings(List<BuildingBlockKey> value, DataContext context)
	{
		_newCompleteOperationBuildings = value;
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	public Chicken GetElement_Chicken(int elementId)
	{
		return _chicken[elementId];
	}

	public bool TryGetElement_Chicken(int elementId, out Chicken value)
	{
		return _chicken.TryGetValue(elementId, out value);
	}

	private void AddElement_Chicken(int elementId, Chicken value, DataContext context)
	{
		_chicken.Add(elementId, value);
		_modificationsChicken.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void SetElement_Chicken(int elementId, Chicken value, DataContext context)
	{
		_chicken[elementId] = value;
		_modificationsChicken.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_Chicken(int elementId, DataContext context)
	{
		_chicken.Remove(elementId);
		_modificationsChicken.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void ClearChicken(DataContext context)
	{
		_chicken.Clear();
		_modificationsChicken.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _makeItemDict is no longer in use.")]
	private MakeItemDataObsolete GetElement_MakeItemDict(BuildingBlockKey elementId)
	{
		return _makeItemDict[elementId];
	}

	[Obsolete("DomainData _makeItemDict is no longer in use.")]
	private bool TryGetElement_MakeItemDict(BuildingBlockKey elementId, out MakeItemDataObsolete value)
	{
		return _makeItemDict.TryGetValue(elementId, out value);
	}

	[Obsolete("DomainData _makeItemDict is no longer in use.")]
	private void AddElement_MakeItemDict(BuildingBlockKey elementId, MakeItemDataObsolete value, DataContext context)
	{
		_makeItemDict.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _makeItemDict is no longer in use.")]
	private void SetElement_MakeItemDict(BuildingBlockKey elementId, MakeItemDataObsolete value, DataContext context)
	{
		_makeItemDict[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _makeItemDict is no longer in use.")]
	private void RemoveElement_MakeItemDict(BuildingBlockKey elementId, DataContext context)
	{
		_makeItemDict.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _makeItemDict is no longer in use.")]
	private void ClearMakeItemDict(DataContext context)
	{
		_makeItemDict.Clear();
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private CharacterList GetElement_Residences(BuildingBlockKey elementId)
	{
		return _residences[elementId];
	}

	private bool TryGetElement_Residences(BuildingBlockKey elementId, out CharacterList value)
	{
		return _residences.TryGetValue(elementId, out value);
	}

	private void AddElement_Residences(BuildingBlockKey elementId, CharacterList value, DataContext context)
	{
		_residences.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void SetElement_Residences(BuildingBlockKey elementId, CharacterList value, DataContext context)
	{
		_residences[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_Residences(BuildingBlockKey elementId, DataContext context)
	{
		_residences.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void ClearResidences(DataContext context)
	{
		_residences.Clear();
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private CharacterList GetElement_ComfortableHouses(BuildingBlockKey elementId)
	{
		return _comfortableHouses[elementId];
	}

	private bool TryGetElement_ComfortableHouses(BuildingBlockKey elementId, out CharacterList value)
	{
		return _comfortableHouses.TryGetValue(elementId, out value);
	}

	private void AddElement_ComfortableHouses(BuildingBlockKey elementId, CharacterList value, DataContext context)
	{
		_comfortableHouses.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	private void SetElement_ComfortableHouses(BuildingBlockKey elementId, CharacterList value, DataContext context)
	{
		_comfortableHouses[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_ComfortableHouses(BuildingBlockKey elementId, DataContext context)
	{
		_comfortableHouses.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	private void ClearComfortableHouses(DataContext context)
	{
		_comfortableHouses.Clear();
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	public CharacterList GetHomeless()
	{
		return _homeless;
	}

	public void SetHomeless(CharacterList value, DataContext context)
	{
		_homeless = value;
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	public MainAttributes GetSamsaraPlatformAddMainAttributes()
	{
		return _samsaraPlatformAddMainAttributes;
	}

	private void SetSamsaraPlatformAddMainAttributes(MainAttributes value, DataContext context)
	{
		_samsaraPlatformAddMainAttributes = value;
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	public ref CombatSkillShorts GetSamsaraPlatformAddCombatSkillQualifications()
	{
		return ref _samsaraPlatformAddCombatSkillQualifications;
	}

	private void SetSamsaraPlatformAddCombatSkillQualifications(ref CombatSkillShorts value, DataContext context)
	{
		_samsaraPlatformAddCombatSkillQualifications = value;
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	public ref LifeSkillShorts GetSamsaraPlatformAddLifeSkillQualifications()
	{
		return ref _samsaraPlatformAddLifeSkillQualifications;
	}

	private void SetSamsaraPlatformAddLifeSkillQualifications(ref LifeSkillShorts value, DataContext context)
	{
		_samsaraPlatformAddLifeSkillQualifications = value;
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	public IntPair GetElement_SamsaraPlatformSlots(int index)
	{
		return _samsaraPlatformSlots[index];
	}

	public void SetElement_SamsaraPlatformSlots(int index, IntPair value, DataContext context)
	{
		_samsaraPlatformSlots[index] = value;
		SetModifiedAndInvalidateInfluencedCache(index, _dataStatesSamsaraPlatformSlots, CacheInfluencesSamsaraPlatformSlots, context);
	}

	public IntPair GetElement_SamsaraPlatformBornDict(int elementId)
	{
		return _samsaraPlatformBornDict[elementId];
	}

	public bool TryGetElement_SamsaraPlatformBornDict(int elementId, out IntPair value)
	{
		return _samsaraPlatformBornDict.TryGetValue(elementId, out value);
	}

	private void AddElement_SamsaraPlatformBornDict(int elementId, IntPair value, DataContext context)
	{
		_samsaraPlatformBornDict.Add(elementId, value);
		_modificationsSamsaraPlatformBornDict.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	private void SetElement_SamsaraPlatformBornDict(int elementId, IntPair value, DataContext context)
	{
		_samsaraPlatformBornDict[elementId] = value;
		_modificationsSamsaraPlatformBornDict.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SamsaraPlatformBornDict(int elementId, DataContext context)
	{
		_samsaraPlatformBornDict.Remove(elementId);
		_modificationsSamsaraPlatformBornDict.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	private void ClearSamsaraPlatformBornDict(DataContext context)
	{
		_samsaraPlatformBornDict.Clear();
		_modificationsSamsaraPlatformBornDict.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	public BuildingEarningsData GetElement_CollectBuildingEarningsData(BuildingBlockKey elementId)
	{
		return _collectBuildingEarningsData[elementId];
	}

	public bool TryGetElement_CollectBuildingEarningsData(BuildingBlockKey elementId, out BuildingEarningsData value)
	{
		return _collectBuildingEarningsData.TryGetValue(elementId, out value);
	}

	private void AddElement_CollectBuildingEarningsData(BuildingBlockKey elementId, BuildingEarningsData value, DataContext context)
	{
		_collectBuildingEarningsData.Add(elementId, value);
		_modificationsCollectBuildingEarningsData.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	private void SetElement_CollectBuildingEarningsData(BuildingBlockKey elementId, BuildingEarningsData value, DataContext context)
	{
		_collectBuildingEarningsData[elementId] = value;
		_modificationsCollectBuildingEarningsData.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_CollectBuildingEarningsData(BuildingBlockKey elementId, DataContext context)
	{
		_collectBuildingEarningsData.Remove(elementId);
		_modificationsCollectBuildingEarningsData.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	private void ClearCollectBuildingEarningsData(DataContext context)
	{
		_collectBuildingEarningsData.Clear();
		_modificationsCollectBuildingEarningsData.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	public CharacterList GetElement_ShopManagerDict(BuildingBlockKey elementId)
	{
		return _shopManagerDict[elementId];
	}

	public bool TryGetElement_ShopManagerDict(BuildingBlockKey elementId, out CharacterList value)
	{
		return _shopManagerDict.TryGetValue(elementId, out value);
	}

	private void AddElement_ShopManagerDict(BuildingBlockKey elementId, CharacterList value, DataContext context)
	{
		_shopManagerDict.Add(elementId, value);
		_modificationsShopManagerDict.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
	}

	private void SetElement_ShopManagerDict(BuildingBlockKey elementId, CharacterList value, DataContext context)
	{
		_shopManagerDict[elementId] = value;
		_modificationsShopManagerDict.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_ShopManagerDict(BuildingBlockKey elementId, DataContext context)
	{
		_shopManagerDict.Remove(elementId);
		_modificationsShopManagerDict.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
	}

	private void ClearShopManagerDict(DataContext context)
	{
		_shopManagerDict.Clear();
		_modificationsShopManagerDict.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
	}

	public TeaHorseCaravanData GetTeaHorseCaravanData()
	{
		return _teaHorseCaravanData;
	}

	private void SetTeaHorseCaravanData(TeaHorseCaravanData value, DataContext context)
	{
		_teaHorseCaravanData = value;
		SetModifiedAndInvalidateInfluencedCache(19, DataStates, CacheInfluences, context);
	}

	public ushort GetShrineBuyTimes()
	{
		return _shrineBuyTimes;
	}

	public void SetShrineBuyTimes(ushort value, DataContext context)
	{
		_shrineBuyTimes = value;
		SetModifiedAndInvalidateInfluencedCache(20, DataStates, CacheInfluences, context);
	}

	public VoidValue GetElement_LocationMarkHashSet(Location elementId)
	{
		return _locationMarkHashSet[elementId];
	}

	public bool TryGetElement_LocationMarkHashSet(Location elementId, out VoidValue value)
	{
		return _locationMarkHashSet.TryGetValue(elementId, out value);
	}

	private void AddElement_LocationMarkHashSet(Location elementId, VoidValue value, DataContext context)
	{
		_locationMarkHashSet.Add(elementId, value);
		_modificationsLocationMarkHashSet.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	private void SetElement_LocationMarkHashSet(Location elementId, VoidValue value, DataContext context)
	{
		_locationMarkHashSet[elementId] = value;
		_modificationsLocationMarkHashSet.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_LocationMarkHashSet(Location elementId, DataContext context)
	{
		_locationMarkHashSet.Remove(elementId);
		_modificationsLocationMarkHashSet.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	private void ClearLocationMarkHashSet(DataContext context)
	{
		_locationMarkHashSet.Clear();
		_modificationsLocationMarkHashSet.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	private bool GetElement_ComfortableHousesAutoCheckInType(BuildingBlockKey elementId)
	{
		return _comfortableHousesAutoCheckInType[elementId];
	}

	private bool TryGetElement_ComfortableHousesAutoCheckInType(BuildingBlockKey elementId, out bool value)
	{
		return _comfortableHousesAutoCheckInType.TryGetValue(elementId, out value);
	}

	private void AddElement_ComfortableHousesAutoCheckInType(BuildingBlockKey elementId, bool value, DataContext context)
	{
		_comfortableHousesAutoCheckInType.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	private void SetElement_ComfortableHousesAutoCheckInType(BuildingBlockKey elementId, bool value, DataContext context)
	{
		_comfortableHousesAutoCheckInType[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_ComfortableHousesAutoCheckInType(BuildingBlockKey elementId, DataContext context)
	{
		_comfortableHousesAutoCheckInType.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	private void ClearComfortableHousesAutoCheckInType(DataContext context)
	{
		_comfortableHousesAutoCheckInType.Clear();
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	private CharacterSet GetElement_LockedResidences(BuildingBlockKey elementId)
	{
		return _lockedResidences[elementId];
	}

	private bool TryGetElement_LockedResidences(BuildingBlockKey elementId, out CharacterSet value)
	{
		return _lockedResidences.TryGetValue(elementId, out value);
	}

	private void AddElement_LockedResidences(BuildingBlockKey elementId, CharacterSet value, DataContext context)
	{
		_lockedResidences.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(23, DataStates, CacheInfluences, context);
	}

	private void SetElement_LockedResidences(BuildingBlockKey elementId, CharacterSet value, DataContext context)
	{
		_lockedResidences[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(23, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_LockedResidences(BuildingBlockKey elementId, DataContext context)
	{
		_lockedResidences.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(23, DataStates, CacheInfluences, context);
	}

	private void ClearLockedResidences(DataContext context)
	{
		_lockedResidences.Clear();
		SetModifiedAndInvalidateInfluencedCache(23, DataStates, CacheInfluences, context);
	}

	private CharacterSet GetElement_LockedComfortableHouses(BuildingBlockKey elementId)
	{
		return _lockedComfortableHouses[elementId];
	}

	private bool TryGetElement_LockedComfortableHouses(BuildingBlockKey elementId, out CharacterSet value)
	{
		return _lockedComfortableHouses.TryGetValue(elementId, out value);
	}

	private void AddElement_LockedComfortableHouses(BuildingBlockKey elementId, CharacterSet value, DataContext context)
	{
		_lockedComfortableHouses.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(24, DataStates, CacheInfluences, context);
	}

	private void SetElement_LockedComfortableHouses(BuildingBlockKey elementId, CharacterSet value, DataContext context)
	{
		_lockedComfortableHouses[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(24, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_LockedComfortableHouses(BuildingBlockKey elementId, DataContext context)
	{
		_lockedComfortableHouses.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(24, DataStates, CacheInfluences, context);
	}

	private void ClearLockedComfortableHouses(DataContext context)
	{
		_lockedComfortableHouses.Clear();
		SetModifiedAndInvalidateInfluencedCache(24, DataStates, CacheInfluences, context);
	}

	public int GetElement_ShopManagerUpgradeQualificationDict(int elementId)
	{
		return _shopManagerUpgradeQualificationDict[elementId];
	}

	public bool TryGetElement_ShopManagerUpgradeQualificationDict(int elementId, out int value)
	{
		return _shopManagerUpgradeQualificationDict.TryGetValue(elementId, out value);
	}

	private void AddElement_ShopManagerUpgradeQualificationDict(int elementId, int value, DataContext context)
	{
		_shopManagerUpgradeQualificationDict.Add(elementId, value);
		_modificationsShopManagerUpgradeQualificationDict.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(25, DataStates, CacheInfluences, context);
	}

	private void SetElement_ShopManagerUpgradeQualificationDict(int elementId, int value, DataContext context)
	{
		_shopManagerUpgradeQualificationDict[elementId] = value;
		_modificationsShopManagerUpgradeQualificationDict.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(25, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_ShopManagerUpgradeQualificationDict(int elementId, DataContext context)
	{
		_shopManagerUpgradeQualificationDict.Remove(elementId);
		_modificationsShopManagerUpgradeQualificationDict.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(25, DataStates, CacheInfluences, context);
	}

	private void ClearShopManagerUpgradeQualificationDict(DataContext context)
	{
		_shopManagerUpgradeQualificationDict.Clear();
		_modificationsShopManagerUpgradeQualificationDict.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(25, DataStates, CacheInfluences, context);
	}

	public int GetFeatherValue()
	{
		return _featherValue;
	}

	public void SetFeatherValue(int value, DataContext context)
	{
		_featherValue = value;
		SetModifiedAndInvalidateInfluencedCache(26, DataStates, CacheInfluences, context);
	}

	public TeaHorseCaravanEventCollection GetTeaHorseCaravanEventCollection()
	{
		return _teaHorseCaravanEventCollection;
	}

	private void SetTeaHorseCaravanEventCollection(TeaHorseCaravanEventCollection value, DataContext context)
	{
		_teaHorseCaravanEventCollection = value;
		SetModifiedAndInvalidateInfluencedCache(27, DataStates, CacheInfluences, context);
	}

	private List<short> GetNewlyCreatedBuildingIndexes()
	{
		return _newlyCreatedBuildingIndexes;
	}

	private void SetNewlyCreatedBuildingIndexes(List<short> value, DataContext context)
	{
		_newlyCreatedBuildingIndexes = value;
		SetModifiedAndInvalidateInfluencedCache(28, DataStates, CacheInfluences, context);
	}

	private MakeItemData GetElement_MakeItemDataDict(BuildingBlockKey elementId)
	{
		return _makeItemDataDict[elementId];
	}

	private bool TryGetElement_MakeItemDataDict(BuildingBlockKey elementId, out MakeItemData value)
	{
		return _makeItemDataDict.TryGetValue(elementId, out value);
	}

	private void AddElement_MakeItemDataDict(BuildingBlockKey elementId, MakeItemData value, DataContext context)
	{
		_makeItemDataDict.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(29, DataStates, CacheInfluences, context);
	}

	private void SetElement_MakeItemDataDict(BuildingBlockKey elementId, MakeItemData value, DataContext context)
	{
		_makeItemDataDict[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(29, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_MakeItemDataDict(BuildingBlockKey elementId, DataContext context)
	{
		_makeItemDataDict.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(29, DataStates, CacheInfluences, context);
	}

	private void ClearMakeItemDataDict(DataContext context)
	{
		_makeItemDataDict.Clear();
		SetModifiedAndInvalidateInfluencedCache(29, DataStates, CacheInfluences, context);
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
		archive.WriteSingleValueUnmanaged((ushort)26);
		archive.WriteDomainDataMeta(0);
		archive.WriteSingleValueCollectionCustomKeyValue(_buildingAreas);
		archive.WriteDomainDataMeta(1);
		archive.WriteSingleValueCollectionCustomKeyValue(_buildingBlocks);
		archive.WriteDomainDataMeta(2);
		archive.WriteSingleValueCustomList(_taiwuBuildingAreas);
		archive.WriteDomainDataMeta(3);
		archive.WriteSingleValueCollectionCustomKeyUnmanagedValue(_CollectBuildingResourceType);
		archive.WriteDomainDataMeta(5);
		archive.WriteSingleValueCollectionCustomKeyUnmanagedValue(_customBuildingName);
		archive.WriteDomainDataMeta(6);
		archive.WriteSingleValueCustomList(_newCompleteOperationBuildings);
		archive.WriteDomainDataMeta(7);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_chicken);
		archive.WriteDomainDataMeta(9);
		archive.WriteSingleValueCollectionCustomKeyValue(_residences);
		archive.WriteDomainDataMeta(10);
		archive.WriteSingleValueCollectionCustomKeyValue(_comfortableHouses);
		archive.WriteDomainDataMeta(11);
		archive.WriteSingleValueCustom(_homeless);
		archive.WriteDomainDataMeta(12);
		archive.WriteSingleValueCustom(_samsaraPlatformAddMainAttributes);
		archive.WriteDomainDataMeta(13);
		archive.WriteSingleValueCustom(_samsaraPlatformAddCombatSkillQualifications);
		archive.WriteDomainDataMeta(14);
		archive.WriteSingleValueCustom(_samsaraPlatformAddLifeSkillQualifications);
		archive.WriteDomainDataMeta(15);
		archive.WriteElementListCustom(_samsaraPlatformSlots);
		archive.WriteDomainDataMeta(16);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_samsaraPlatformBornDict);
		archive.WriteDomainDataMeta(17);
		archive.WriteSingleValueCollectionCustomKeyValue(_collectBuildingEarningsData);
		archive.WriteDomainDataMeta(19);
		archive.WriteSingleValueCustom(_teaHorseCaravanData);
		archive.WriteDomainDataMeta(20);
		archive.WriteSingleValueUnmanaged(_shrineBuyTimes);
		archive.WriteDomainDataMeta(21);
		archive.WriteSingleValueCollectionCustomKeyValue(_locationMarkHashSet);
		archive.WriteDomainDataMeta(22);
		archive.WriteSingleValueCollectionCustomKeyUnmanagedValue(_comfortableHousesAutoCheckInType);
		archive.WriteDomainDataMeta(23);
		archive.WriteSingleValueCollectionCustomKeyValue(_lockedResidences);
		archive.WriteDomainDataMeta(24);
		archive.WriteSingleValueCollectionCustomKeyValue(_lockedComfortableHouses);
		archive.WriteDomainDataMeta(26);
		archive.WriteSingleValueUnmanaged(_featherValue);
		archive.WriteDomainDataMeta(27);
		archive.WriteBinary(_teaHorseCaravanEventCollection);
		archive.WriteDomainDataMeta(28);
		archive.WriteSingleValueUnmanagedList(_newlyCreatedBuildingIndexes);
		archive.WriteDomainDataMeta(29);
		archive.WriteSingleValueCollectionCustomKeyValue(_makeItemDataDict);
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
			case 0:
				archive.ReadSingleValueCollectionCustomKeyValue(_buildingAreas);
				break;
			case 1:
				archive.ReadSingleValueCollectionCustomKeyValue(_buildingBlocks);
				break;
			case 2:
				archive.ReadSingleValueCustomList(ref _taiwuBuildingAreas);
				break;
			case 3:
				archive.ReadSingleValueCollectionCustomKeyUnmanagedValue(_CollectBuildingResourceType);
				break;
			case 5:
				archive.ReadSingleValueCollectionCustomKeyUnmanagedValue(_customBuildingName);
				break;
			case 6:
				archive.ReadSingleValueCustomList(ref _newCompleteOperationBuildings);
				break;
			case 7:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_chicken);
				break;
			case 8:
				archive.ReadSingleValueCollectionCustomKeyValue(_makeItemDict);
				break;
			case 9:
				archive.ReadSingleValueCollectionCustomKeyValue(_residences);
				break;
			case 10:
				archive.ReadSingleValueCollectionCustomKeyValue(_comfortableHouses);
				break;
			case 11:
				archive.ReadSingleValueCustom(ref _homeless);
				break;
			case 12:
				archive.ReadSingleValueCustom(ref _samsaraPlatformAddMainAttributes);
				break;
			case 13:
				archive.ReadSingleValueCustom(ref _samsaraPlatformAddCombatSkillQualifications);
				break;
			case 14:
				archive.ReadSingleValueCustom(ref _samsaraPlatformAddLifeSkillQualifications);
				break;
			case 15:
				archive.ReadElementListCustom(_samsaraPlatformSlots);
				break;
			case 16:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_samsaraPlatformBornDict);
				break;
			case 17:
				archive.ReadSingleValueCollectionCustomKeyValue(_collectBuildingEarningsData);
				break;
			case 19:
				archive.ReadSingleValueCustom(ref _teaHorseCaravanData);
				break;
			case 20:
				archive.ReadSingleValueUnmanaged(ref _shrineBuyTimes);
				break;
			case 21:
				archive.ReadSingleValueCollectionCustomKeyValue(_locationMarkHashSet);
				break;
			case 22:
				archive.ReadSingleValueCollectionCustomKeyUnmanagedValue(_comfortableHousesAutoCheckInType);
				break;
			case 23:
				archive.ReadSingleValueCollectionCustomKeyValue(_lockedResidences);
				break;
			case 24:
				archive.ReadSingleValueCollectionCustomKeyValue(_lockedComfortableHouses);
				break;
			case 26:
				archive.ReadSingleValueUnmanaged(ref _featherValue);
				break;
			case 27:
				archive.ReadBinary(ref _teaHorseCaravanEventCollection);
				break;
			case 28:
				archive.ReadSingleValueUnmanagedList(ref _newlyCreatedBuildingIndexes);
				break;
			case 29:
				archive.ReadSingleValueCollectionCustomKeyValue(_makeItemDataDict);
				break;
			default:
				throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
			}
			RecordLoadedDomainData(domainDataMeta.DataId);
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(9);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 0);
				_modificationsBuildingAreas.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_buildingAreas, dataPool);
		case 1:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
				_modificationsBuildingBlocks.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_buildingBlocks, dataPool);
		case 2:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
			}
			return GameData.Serializer.Serializer.Serialize(_taiwuBuildingAreas, dataPool);
		case 3:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
				_modificationsCollectBuildingResourceType.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_CollectBuildingResourceType, dataPool);
		case 4:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
				_modificationsBuildingOperatorDict.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_buildingOperatorDict, dataPool);
		case 5:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
				_modificationsCustomBuildingName.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_customBuildingName, dataPool);
		case 6:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 7:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
				_modificationsChicken.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_chicken, dataPool);
		case 8:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 9:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 10:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 11:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
			}
			return GameData.Serializer.Serializer.Serialize(_homeless, dataPool);
		case 12:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 12);
			}
			return GameData.Serializer.Serializer.Serialize(_samsaraPlatformAddMainAttributes, dataPool);
		case 13:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 13);
			}
			return GameData.Serializer.Serializer.Serialize(_samsaraPlatformAddCombatSkillQualifications, dataPool);
		case 14:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 14);
			}
			return GameData.Serializer.Serializer.Serialize(_samsaraPlatformAddLifeSkillQualifications, dataPool);
		case 15:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(_dataStatesSamsaraPlatformSlots, (int)subId0);
			}
			return GameData.Serializer.Serializer.Serialize(_samsaraPlatformSlots[(uint)subId0], dataPool);
		case 16:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 16);
				_modificationsSamsaraPlatformBornDict.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_samsaraPlatformBornDict, dataPool);
		case 17:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 17);
				_modificationsCollectBuildingEarningsData.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_collectBuildingEarningsData, dataPool);
		case 18:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 18);
				_modificationsShopManagerDict.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_shopManagerDict, dataPool);
		case 19:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 19);
			}
			return GameData.Serializer.Serializer.Serialize(_teaHorseCaravanData, dataPool);
		case 20:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 20);
			}
			return GameData.Serializer.Serializer.Serialize(_shrineBuyTimes, dataPool);
		case 21:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 21);
				_modificationsLocationMarkHashSet.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_locationMarkHashSet, dataPool);
		case 22:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 23:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 24:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 25:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 25);
				_modificationsShopManagerUpgradeQualificationDict.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_shopManagerUpgradeQualificationDict, dataPool);
		case 26:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 26);
			}
			return GameData.Serializer.Serializer.Serialize(_featherValue, dataPool);
		case 27:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 27);
			}
			return GameData.Serializer.Serializer.Serialize(_teaHorseCaravanEventCollection, dataPool);
		case 28:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 29:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
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
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 5:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 6:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 7:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 8:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 9:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 10:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 11:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _homeless);
			SetHomeless(_homeless, context);
			break;
		case 12:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 13:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 14:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 15:
		{
			IntPair value = default(IntPair);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			_samsaraPlatformSlots[(uint)subId0] = value;
			SetElement_SamsaraPlatformSlots((int)subId0, value, context);
			break;
		}
		case 16:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 17:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 18:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 19:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 20:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _shrineBuyTimes);
			SetShrineBuyTimes(_shrineBuyTimes, context);
			break;
		case 21:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 22:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 23:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 24:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 25:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 26:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _featherValue);
			SetFeatherValue(_featherValue, context);
			break;
		case 27:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 28:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 29:
			throw new Exception($"Not allow to set value of dataId {dataId}");
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
			int argsCount159 = operation.ArgsCount;
			int num159 = argsCount159;
			if (num159 == 3)
			{
				BuildingBlockKey blockKey49 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey49);
				sbyte index7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index7);
				int charId24 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId24);
				SetShopManager(context, blockKey49, index7, charId24);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount106 = operation.ArgsCount;
			int num106 = argsCount106;
			if (num106 == 2)
			{
				BuildingBlockKey blockKey35 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey35);
				sbyte resourceType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref resourceType2);
				SetCollectBuildingResourceType(context, blockKey35, resourceType2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				BuildingBlockKey key2 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key2);
				bool isPawnShop2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isPawnShop2);
				ClearBuildingBlockEarningsData(context, key2, isPawnShop2);
				return -1;
			}
			case 3:
			{
				BuildingBlockKey key = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key);
				bool isPawnShop = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isPawnShop);
				bool clearOutputSetting = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref clearOutputSetting);
				ClearBuildingBlockEarningsData(context, key, isPawnShop, clearOutputSetting);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 3:
		{
			int argsCount74 = operation.ArgsCount;
			int num74 = argsCount74;
			if (num74 == 1)
			{
				BuildingBlockKey blockKey21 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey21);
				BuildingEarningsData returnValue106 = GetBuildingEarningData(blockKey21);
				return GameData.Serializer.Serializer.Serialize(returnValue106, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 4:
		{
			int argsCount122 = operation.ArgsCount;
			int num122 = argsCount122;
			if (num122 == 1)
			{
				BuildingBlockKey blockKey39 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey39);
				List<int> returnValue157 = GetBuildingOperatesData(blockKey39);
				return GameData.Serializer.Serializer.Serialize(returnValue157, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 5:
		{
			int argsCount57 = operation.ArgsCount;
			int num57 = argsCount57;
			if (num57 == 1)
			{
				BuildingBlockKey blockKey16 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey16);
				int returnValue87 = GetBuildingBuildPeopleAttainments(blockKey16);
				return GameData.Serializer.Serializer.Serialize(returnValue87, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 6:
			switch (operation.ArgsCount)
			{
			case 3:
			{
				BuildingBlockKey key5 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key5);
				int earningDataIndex3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref earningDataIndex3);
				bool isPutInInventory3 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isPutInInventory3);
				BuildingBlockKey returnValue40 = AcceptBuildingBlockCollectEarning(context, key5, earningDataIndex3, isPutInInventory3);
				return GameData.Serializer.Serializer.Serialize(returnValue40, returnDataPool);
			}
			case 4:
			{
				BuildingBlockKey key4 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key4);
				int earningDataIndex2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref earningDataIndex2);
				bool isPutInInventory2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isPutInInventory2);
				bool isSetData2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isSetData2);
				BuildingBlockKey returnValue39 = AcceptBuildingBlockCollectEarning(context, key4, earningDataIndex2, isPutInInventory2, isSetData2);
				return GameData.Serializer.Serializer.Serialize(returnValue39, returnDataPool);
			}
			case 5:
			{
				BuildingBlockKey key3 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key3);
				int earningDataIndex = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref earningDataIndex);
				bool isPutInInventory = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isPutInInventory);
				bool isSetData = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isSetData);
				bool isCostMoney = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isCostMoney);
				BuildingBlockKey returnValue38 = AcceptBuildingBlockCollectEarning(context, key3, earningDataIndex, isPutInInventory, isSetData, isCostMoney);
				return GameData.Serializer.Serializer.Serialize(returnValue38, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 7:
		{
			int argsCount147 = operation.ArgsCount;
			int num147 = argsCount147;
			if (num147 == 2)
			{
				BuildingBlockKey key30 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key30);
				bool isPutInInventory5 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isPutInInventory5);
				AcceptBuildingBlockCollectEarningQuick(context, key30, isPutInInventory5);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 8:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				BuildingBlockKey key28 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key28);
				int earningDataIndex9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref earningDataIndex9);
				int returnValue165 = AcceptBuildingBlockRecruitPeople(context, key28, earningDataIndex9);
				return GameData.Serializer.Serializer.Serialize(returnValue165, returnDataPool);
			}
			case 3:
			{
				BuildingBlockKey key27 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key27);
				int earningDataIndex8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref earningDataIndex8);
				bool isSetData5 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isSetData5);
				int returnValue164 = AcceptBuildingBlockRecruitPeople(context, key27, earningDataIndex8, isSetData5);
				return GameData.Serializer.Serializer.Serialize(returnValue164, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 9:
		{
			int argsCount97 = operation.ArgsCount;
			int num97 = argsCount97;
			if (num97 == 1)
			{
				BuildingBlockKey key14 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key14);
				List<int> returnValue132 = AcceptBuildingBlockRecruitPeopleQuick(context, key14);
				return GameData.Serializer.Serializer.Serialize(returnValue132, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 10:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				BuildingBlockKey key11 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key11);
				int earningDataIndex5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref earningDataIndex5);
				ShopBuildingSoldItemReceive(context, key11, earningDataIndex5);
				return -1;
			}
			case 3:
			{
				BuildingBlockKey key10 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key10);
				int earningDataIndex4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref earningDataIndex4);
				bool isSetData3 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isSetData3);
				ShopBuildingSoldItemReceive(context, key10, earningDataIndex4, isSetData3);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 11:
		{
			int argsCount45 = operation.ArgsCount;
			int num45 = argsCount45;
			if (num45 == 1)
			{
				BuildingBlockKey key9 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key9);
				ShopBuildingSoldItemReceiveQuick(context, key9);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
			if (operation.ArgsCount == 0)
			{
				List<ItemDisplayData> returnValue6 = QuickCollectShopItem(context);
				return GameData.Serializer.Serializer.Serialize(returnValue6, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 13:
			if (operation.ArgsCount == 0)
			{
				int returnValue173 = QuickCollectShopItemCount(context);
				return GameData.Serializer.Serializer.Serialize(returnValue173, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 14:
			if (operation.ArgsCount == 0)
			{
				QuickCollectShopSoldItem(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 15:
			if (operation.ArgsCount == 0)
			{
				int returnValue118 = QuickCollectShopSoldItemCount(context);
				return GameData.Serializer.Serializer.Serialize(returnValue118, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 16:
			if (operation.ArgsCount == 0)
			{
				List<int> returnValue95 = QuickRecruitPeople(context);
				return GameData.Serializer.Serializer.Serialize(returnValue95, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 17:
			if (operation.ArgsCount == 0)
			{
				int returnValue69 = QuickRecruitPeopleCount(context);
				return GameData.Serializer.Serializer.Serialize(returnValue69, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 18:
			if (operation.ArgsCount == 0)
			{
				QuickCollectBuildingEarn(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 19:
			if (operation.ArgsCount == 0)
			{
				int returnValue183 = QuickCollectBuildingEarnCount(context);
				return GameData.Serializer.Serializer.Serialize(returnValue183, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 20:
		{
			int argsCount132 = operation.ArgsCount;
			int num132 = argsCount132;
			if (num132 == 3)
			{
				BuildingBlockKey key29 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key29);
				ItemKey itemKey9 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey9);
				ItemSourceType itemSourceType3 = ItemSourceType.Equipment;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSourceType3);
				AddFixBook(context, key29, itemKey9, itemSourceType3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 21:
		{
			int argsCount116 = operation.ArgsCount;
			int num116 = argsCount116;
			if (num116 == 3)
			{
				BuildingBlockKey key24 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key24);
				ItemKey itemKey6 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey6);
				ItemSourceType itemSourceType2 = ItemSourceType.Equipment;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSourceType2);
				(short, BuildingBlockData) returnValue153 = ChangeFixBook(context, key24, itemKey6, itemSourceType2);
				return GameData.Serializer.Serializer.Serialize(returnValue153, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 22:
		{
			int argsCount102 = operation.ArgsCount;
			int num102 = argsCount102;
			if (num102 == 2)
			{
				BuildingBlockKey key15 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key15);
				bool isPutInInventory4 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isPutInInventory4);
				ReceiveFixBook(context, key15, isPutInInventory4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 23:
		{
			int argsCount90 = operation.ArgsCount;
			int num90 = argsCount90;
			if (num90 == 1)
			{
				BuildingBlockKey key12 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key12);
				int returnValue117 = GetFixBookProgress(context, key12);
				return GameData.Serializer.Serializer.Serialize(returnValue117, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 24:
		{
			int argsCount67 = operation.ArgsCount;
			int num67 = argsCount67;
			if (num67 == 1)
			{
				sbyte state = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref state);
				SetTeaHorseCaravanState(context, state);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 25:
		{
			int argsCount51 = operation.ArgsCount;
			int num51 = argsCount51;
			if (num51 == 2)
			{
				List<ItemKey> carryItems = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref carryItems);
				List<ItemKey> gainItems = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref gainItems);
				ExchangeItemToReplenishment(context, carryItems, gainItems);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 26:
			if (operation.ArgsCount == 0)
			{
				StartSearchReplenishment(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 27:
			switch (operation.ArgsCount)
			{
			case 0:
				QuickGetExchangeItem(context);
				return -1;
			case 1:
			{
				ItemSourceType source = ItemSourceType.Equipment;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref source);
				QuickGetExchangeItem(context, source);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 28:
		{
			int argsCount14 = operation.ArgsCount;
			int num14 = argsCount14;
			if (num14 == 3)
			{
				short areaId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId);
				short blockId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockId);
				short buildingBlockIndex = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockIndex);
				TaiwuShrineDisplayData returnValue22 = GetShrineDisplayData(context, areaId, blockId, buildingBlockIndex);
				return GameData.Serializer.Serializer.Serialize(returnValue22, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 29:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 2)
			{
				int characterId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId);
				SkillQualificationBonus bonus = default(SkillQualificationBonus);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bonus);
				TeachSkill(context, characterId, bonus);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 30:
		{
			int argsCount148 = operation.ArgsCount;
			int num148 = argsCount148;
			if (num148 == 3)
			{
				int index6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index6);
				bool isCricket2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isCricket2);
				ItemKey itemKey10 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey10);
				CricketCollectionAdd(context, index6, isCricket2, itemKey10);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 31:
		{
			int argsCount136 = operation.ArgsCount;
			int num136 = argsCount136;
			if (num136 == 2)
			{
				int index5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index5);
				bool isCricket = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isCricket);
				CricketCollectionRemove(context, index5, isCricket);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 32:
			if (operation.ArgsCount == 0)
			{
				ItemDisplayData[] returnValue160 = GetCollectionCrickets(context);
				return GameData.Serializer.Serializer.Serialize(returnValue160, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 33:
			if (operation.ArgsCount == 0)
			{
				ItemDisplayData[] returnValue152 = GetCollectionJars(context);
				return GameData.Serializer.Serializer.Serialize(returnValue152, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 34:
			if (operation.ArgsCount == 0)
			{
				int[] returnValue139 = GetCollectionCricketRegen(context);
				return GameData.Serializer.Serializer.Serialize(returnValue139, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 35:
			if (operation.ArgsCount == 0)
			{
				int returnValue124 = GetAuthorityGain(context);
				return GameData.Serializer.Serializer.Serialize(returnValue124, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 36:
		{
			int argsCount83 = operation.ArgsCount;
			int num83 = argsCount83;
			if (num83 == 3)
			{
				short buildingTemplateId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingTemplateId4);
				BuildingBlockKey blockKey24 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey24);
				sbyte level = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref level);
				(short, BuildingBlockData) returnValue112 = GmCmd_BuildImmediately(context, buildingTemplateId4, blockKey24, level);
				return GameData.Serializer.Serializer.Serialize(returnValue112, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 37:
		{
			int argsCount71 = operation.ArgsCount;
			int num71 = argsCount71;
			if (num71 == 1)
			{
				BuildingBlockKey blockKey20 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey20);
				(short, BuildingBlockData) returnValue104 = GmCmd_RemoveBuildingImmediately(context, blockKey20);
				return GameData.Serializer.Serializer.Serialize(returnValue104, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 38:
		{
			int argsCount59 = operation.ArgsCount;
			int num59 = argsCount59;
			if (num59 == 1)
			{
				StartMakeArguments startMakeArguments = default(StartMakeArguments);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref startMakeArguments);
				MakeItemData returnValue89 = StartMakeItem(context, startMakeArguments);
				return GameData.Serializer.Serializer.Serialize(returnValue89, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 39:
		{
			int argsCount48 = operation.ArgsCount;
			int num48 = argsCount48;
			if (num48 == 1)
			{
				MakeConditionArguments makeConditionArguments = default(MakeConditionArguments);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref makeConditionArguments);
				bool returnValue76 = CheckMakeCondition(makeConditionArguments);
				return GameData.Serializer.Serializer.Serialize(returnValue76, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 40:
		{
			int argsCount36 = operation.ArgsCount;
			int num36 = argsCount36;
			if (num36 == 1)
			{
				BuildingBlockKey buildingBlockKey4 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey4);
				List<ItemDisplayData> returnValue57 = GetMakeItems(context, buildingBlockKey4);
				return GameData.Serializer.Serializer.Serialize(returnValue57, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 41:
		{
			int argsCount28 = operation.ArgsCount;
			int num28 = argsCount28;
			if (num28 == 1)
			{
				BuildingBlockKey buildingBlockKey3 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey3);
				MakeItemData returnValue47 = GetMakingItemData(buildingBlockKey3);
				return GameData.Serializer.Serializer.Serialize(returnValue47, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 42:
		{
			int argsCount16 = operation.ArgsCount;
			int num16 = argsCount16;
			if (num16 == 4)
			{
				int charId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId5);
				ItemKey toolKey2 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolKey2);
				ItemKey itemKey3 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey3);
				BuildingBlockKey buildingBlockKey = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey);
				bool returnValue26 = CheckRepairConditionIsMeet(charId5, toolKey2, itemKey3, buildingBlockKey);
				return GameData.Serializer.Serializer.Serialize(returnValue26, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 43:
		{
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 5)
			{
				int charId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId2);
				ItemDisplayData tool = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref tool);
				ItemDisplayData target = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref target);
				ItemDisplayData[] poisons = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref poisons);
				List<ItemDisplayData> condensePoisonItemList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref condensePoisonItemList);
				(bool, ItemDisplayData) returnValue16 = AddItemPoison(context, charId2, tool, target, poisons, condensePoisonItemList);
				return GameData.Serializer.Serializer.Serialize(returnValue16, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 44:
		{
			int argsCount161 = operation.ArgsCount;
			int num161 = argsCount161;
			if (num161 == 6)
			{
				int charId25 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId25);
				ItemKey toolKey5 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolKey5);
				ItemKey targetKey2 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetKey2);
				ItemKey[] poisonKeys = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref poisonKeys);
				BuildingBlockKey buildingBlockKey27 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey27);
				FullPoisonEffects tempPoisonEffects = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref tempPoisonEffects);
				bool returnValue188 = CheckAddPoisonCondition(charId25, toolKey5, targetKey2, poisonKeys, buildingBlockKey27, tempPoisonEffects);
				return GameData.Serializer.Serializer.Serialize(returnValue188, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 45:
		{
			int argsCount153 = operation.ArgsCount;
			int num153 = argsCount153;
			if (num153 == 5)
			{
				int charId23 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId23);
				ItemDisplayData tool3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref tool3);
				ItemDisplayData target4 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref target4);
				ItemDisplayData[] medicines = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref medicines);
				bool isExtract2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isExtract2);
				(bool, List<ItemDisplayData>) returnValue181 = RemoveItemPoison(context, charId23, tool3, target4, medicines, isExtract2);
				return GameData.Serializer.Serializer.Serialize(returnValue181, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 46:
		{
			int argsCount142 = operation.ArgsCount;
			int num142 = argsCount142;
			if (num142 == 6)
			{
				int charId22 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId22);
				ItemKey toolKey4 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolKey4);
				ItemKey targetKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetKey);
				ItemKey[] medicineKeys = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref medicineKeys);
				BuildingBlockKey buildingBlockKey25 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey25);
				bool isExtract = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isExtract);
				bool returnValue175 = CheckRemovePoisonCondition(charId22, toolKey4, targetKey, medicineKeys, buildingBlockKey25, isExtract);
				return GameData.Serializer.Serializer.Serialize(returnValue175, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 47:
		{
			int argsCount134 = operation.ArgsCount;
			int num134 = argsCount134;
			if (num134 == 3)
			{
				BuildingBlockKey blockKey44 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey44);
				short buildingTemplateId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingTemplateId5);
				int[] workers2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref workers2);
				(short, BuildingBlockData) returnValue169 = Build(context, blockKey44, buildingTemplateId5, workers2);
				return GameData.Serializer.Serializer.Serialize(returnValue169, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 48:
		{
			int argsCount126 = operation.ArgsCount;
			int num126 = argsCount126;
			if (num126 == 2)
			{
				BuildingBlockKey blockKey41 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey41);
				int[] workers = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref workers);
				(short, BuildingBlockData) returnValue161 = Remove(context, blockKey41, workers);
				return GameData.Serializer.Serializer.Serialize(returnValue161, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 49:
		{
			int argsCount119 = operation.ArgsCount;
			int num119 = argsCount119;
			if (num119 == 2)
			{
				BuildingBlockKey blockKey38 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey38);
				bool stop = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref stop);
				(short, BuildingBlockData) returnValue155 = SetStopOperation(context, blockKey38, stop);
				return GameData.Serializer.Serializer.Serialize(returnValue155, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 50:
		{
			int argsCount110 = operation.ArgsCount;
			int num110 = argsCount110;
			if (num110 == 3)
			{
				BuildingBlockKey blockKey36 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey36);
				sbyte index4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index4);
				int charId19 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId19);
				SetOperator(context, blockKey36, index4, charId19);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 51:
		{
			int argsCount104 = operation.ArgsCount;
			int num104 = argsCount104;
			if (num104 == 1)
			{
				BuildingBlockKey blockKey34 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey34);
				(short, BuildingBlockData) returnValue142 = Repair(context, blockKey34);
				return GameData.Serializer.Serializer.Serialize(returnValue142, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 52:
		{
			int argsCount100 = operation.ArgsCount;
			int num100 = argsCount100;
			if (num100 == 3)
			{
				List<IntPair> operateRecord = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref operateRecord);
				Location location6 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location6);
				List<int> sameSet = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref sameSet);
				ConfirmPlanBuilding(context, operateRecord, location6, sameSet);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 53:
		{
			int argsCount92 = operation.ArgsCount;
			int num92 = argsCount92;
			if (num92 == 2)
			{
				int charId18 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId18);
				BuildingBlockKey buildingBlockKey21 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey21);
				AddToResidence(context, charId18, buildingBlockKey21);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 54:
		{
			int argsCount86 = operation.ArgsCount;
			int num86 = argsCount86;
			if (num86 == 2)
			{
				int charId17 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId17);
				BuildingBlockKey buildingBlockKey18 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey18);
				bool returnValue114 = RemoveFromResidence(context, charId17, buildingBlockKey18);
				return GameData.Serializer.Serializer.Serialize(returnValue114, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 55:
		{
			int argsCount78 = operation.ArgsCount;
			int num78 = argsCount78;
			if (num78 == 3)
			{
				int charId13 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId13);
				BuildingBlockKey buildingBlockKey14 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey14);
				sbyte index2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index2);
				bool returnValue108 = ReplaceCharacterInResidence(context, charId13, buildingBlockKey14, index2);
				return GameData.Serializer.Serializer.Serialize(returnValue108, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 56:
		{
			int argsCount68 = operation.ArgsCount;
			int num68 = argsCount68;
			if (num68 == 3)
			{
				int charIdB = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charIdB);
				BuildingBlockKey buildingBlockKey11 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey11);
				sbyte index = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index);
				bool returnValue100 = ReplaceCharacterInComfortableHouse(context, charIdB, buildingBlockKey11, index);
				return GameData.Serializer.Serializer.Serialize(returnValue100, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 57:
		{
			int argsCount62 = operation.ArgsCount;
			int num62 = argsCount62;
			if (num62 == 2)
			{
				int charId11 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId11);
				BuildingBlockKey buildingBlockKey9 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey9);
				bool returnValue92 = AddToComfortableHouse(context, charId11, buildingBlockKey9);
				return GameData.Serializer.Serializer.Serialize(returnValue92, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 58:
		{
			int argsCount53 = operation.ArgsCount;
			int num53 = argsCount53;
			if (num53 == 2)
			{
				int charId10 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId10);
				BuildingBlockKey buildingBlockKey7 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey7);
				bool returnValue83 = RemoveFromComfortableHouse(context, charId10, buildingBlockKey7);
				return GameData.Serializer.Serializer.Serialize(returnValue83, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 59:
		{
			int argsCount47 = operation.ArgsCount;
			int num47 = argsCount47;
			if (num47 == 1)
			{
				BuildingBlockKey buildingBlockKey5 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey5);
				CharacterList returnValue75 = QuickFillResidence(context, buildingBlockKey5);
				return GameData.Serializer.Serializer.Serialize(returnValue75, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 60:
		{
			int argsCount40 = operation.ArgsCount;
			int num40 = argsCount40;
			if (num40 == 1)
			{
				BuildingBlockKey key8 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key8);
				CharacterList returnValue63 = GetCharsInResidence(context, key8);
				return GameData.Serializer.Serializer.Serialize(returnValue63, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 61:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				BuildingBlockKey blockKey15 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey15);
				List<CharacterList> returnValue62 = GetAllResidents(context, blockKey15);
				return GameData.Serializer.Serializer.Serialize(returnValue62, returnDataPool);
			}
			case 2:
			{
				BuildingBlockKey blockKey14 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey14);
				bool skipChild = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skipChild);
				List<CharacterList> returnValue61 = GetAllResidents(context, blockKey14, skipChild);
				return GameData.Serializer.Serializer.Serialize(returnValue61, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 62:
		{
			int argsCount31 = operation.ArgsCount;
			int num31 = argsCount31;
			if (num31 == 1)
			{
				BuildingBlockKey key6 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key6);
				CharacterList returnValue51 = GetCharsInComfortableHouse(context, key6);
				return GameData.Serializer.Serializer.Serialize(returnValue51, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 63:
			if (operation.ArgsCount == 0)
			{
				CharacterList returnValue44 = GetHomeless(context);
				return GameData.Serializer.Serializer.Serialize(returnValue44, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 64:
			if (operation.ArgsCount == 0)
			{
				List<SamsaraPlatformCharDisplayData> returnValue28 = GetSamsaraPlatformCharList(context);
				return GameData.Serializer.Serializer.Serialize(returnValue28, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 65:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 2)
			{
				sbyte destinyType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref destinyType2);
				int charId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId4);
				SetSamsaraPlatformChar(context, destinyType2, charId4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 66:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 1)
			{
				sbyte destinyType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref destinyType);
				CharacterDisplayData returnValue9 = SamsaraPlatformReborn(context, destinyType);
				return GameData.Serializer.Serializer.Serialize(returnValue9, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 67:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 1)
			{
				Location location = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location);
				BuildingAreaData returnValue2 = GetBuildingAreaData(location);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 68:
		{
			int argsCount156 = operation.ArgsCount;
			int num156 = argsCount156;
			if (num156 == 1)
			{
				Location location9 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location9);
				List<BuildingBlockData> returnValue184 = GetBuildingBlockList(location9);
				return GameData.Serializer.Serializer.Serialize(returnValue184, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 69:
		{
			int argsCount151 = operation.ArgsCount;
			int num151 = argsCount151;
			if (num151 == 1)
			{
				BuildingBlockKey blockKey46 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey46);
				BuildingBlockData returnValue179 = GetBuildingBlockData(blockKey46);
				return GameData.Serializer.Serializer.Serialize(returnValue179, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 70:
		{
			int argsCount144 = operation.ArgsCount;
			int num144 = argsCount144;
			if (num144 == 2)
			{
				BuildingBlockKey blockKey45 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey45);
				string name = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref name);
				SetBuildingCustomName(context, blockKey45, name);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 71:
		{
			int argsCount139 = operation.ArgsCount;
			int num139 = argsCount139;
			if (num139 == 2)
			{
				short areaId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId2);
				short blockId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockId2);
				int returnValue172 = GetEmptyBlockCount(areaId2, blockId2);
				return GameData.Serializer.Serializer.Serialize(returnValue172, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 72:
		{
			int argsCount133 = operation.ArgsCount;
			int num133 = argsCount133;
			if (num133 == 2)
			{
				int settlementId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId3);
				short templateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId);
				int returnValue167 = AddChicken(context, settlementId3, templateId);
				return GameData.Serializer.Serializer.Serialize(returnValue167, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 73:
		{
			int argsCount128 = operation.ArgsCount;
			int num128 = argsCount128;
			if (num128 == 1)
			{
				int id6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref id6);
				RemoveChicken(context, id6);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 74:
			if (operation.ArgsCount == 0)
			{
				RemoveAllChicken(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 75:
		{
			int argsCount118 = operation.ArgsCount;
			int num118 = argsCount118;
			if (num118 == 2)
			{
				int id5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref id5);
				int targetSettlementId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetSettlementId2);
				MoveChicken(context, id5, targetSettlementId2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 76:
		{
			int argsCount113 = operation.ArgsCount;
			int num113 = argsCount113;
			if (num113 == 2)
			{
				int id4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref id4);
				int targetSettlementId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetSettlementId);
				TransferChicken(context, id4, targetSettlementId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 77:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				int sourceSettlementId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref sourceSettlementId2);
				List<int> returnValue149 = GetSettlementChickenList(sourceSettlementId2);
				return GameData.Serializer.Serializer.Serialize(returnValue149, returnDataPool);
			}
			case 2:
			{
				int sourceSettlementId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref sourceSettlementId);
				bool ignoreFulong2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref ignoreFulong2);
				List<int> returnValue148 = GetSettlementChickenList(sourceSettlementId, ignoreFulong2);
				return GameData.Serializer.Serializer.Serialize(returnValue148, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 78:
		{
			int argsCount107 = operation.ArgsCount;
			int num107 = argsCount107;
			if (num107 == 1)
			{
				int id3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref id3);
				Chicken returnValue144 = GetChickenData(id3);
				return GameData.Serializer.Serializer.Serialize(returnValue144, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 79:
			if (operation.ArgsCount == 0)
			{
				InitMapBlockChicken(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 80:
			if (operation.ArgsCount == 0)
			{
				bool returnValue135 = IsHaveChickenKing(context);
				return GameData.Serializer.Serializer.Serialize(returnValue135, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 81:
		{
			int argsCount95 = operation.ArgsCount;
			int num95 = argsCount95;
			if (num95 == 1)
			{
				BuildingBlockKey buildingBlockKey22 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey22);
				RemoveAllFormResidence(context, buildingBlockKey22);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 82:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				BuildingBlockData blockData2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockData2);
				BuildingBlockKey blockKey27 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey27);
				int returnValue126 = GetBuildingAttainment(blockData2, blockKey27);
				return GameData.Serializer.Serializer.Serialize(returnValue126, returnDataPool);
			}
			case 3:
			{
				BuildingBlockData blockData = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockData);
				BuildingBlockKey blockKey26 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey26);
				bool isAverage = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAverage);
				int returnValue125 = GetBuildingAttainment(blockData, blockKey26, isAverage);
				return GameData.Serializer.Serializer.Serialize(returnValue125, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 83:
		{
			int argsCount91 = operation.ArgsCount;
			int num91 = argsCount91;
			if (num91 == 2)
			{
				BuildingBlockKey key13 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key13);
				sbyte resourceType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref resourceType);
				int returnValue120 = CalcResourceOutputCount(key13, resourceType);
				return GameData.Serializer.Serializer.Serialize(returnValue120, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 84:
		{
			int argsCount88 = operation.ArgsCount;
			int num88 = argsCount88;
			if (num88 == 2)
			{
				List<int> charList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charList);
				byte dealType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref dealType);
				DealInfectedPeople(context, charList, dealType);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 85:
		{
			int argsCount82 = operation.ArgsCount;
			int num82 = argsCount82;
			if (num82 == 1)
			{
				BuildingBlockKey blockKey23 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey23);
				List<ItemDisplayData> returnValue111 = QuickCollectSingleShopItem(context, blockKey23);
				return GameData.Serializer.Serializer.Serialize(returnValue111, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 86:
		{
			int argsCount75 = operation.ArgsCount;
			int num75 = argsCount75;
			if (num75 == 1)
			{
				BuildingBlockKey blockKey22 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey22);
				QuickCollectSingleShopSoldItem(context, blockKey22);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 87:
		{
			int argsCount69 = operation.ArgsCount;
			int num69 = argsCount69;
			if (num69 == 1)
			{
				BuildingBlockKey blockKey19 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey19);
				List<int> returnValue103 = QuickRecruitSingleBuildingPeople(context, blockKey19);
				return GameData.Serializer.Serializer.Serialize(returnValue103, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 88:
		{
			int argsCount65 = operation.ArgsCount;
			int num65 = argsCount65;
			if (num65 == 1)
			{
				BuildingBlockKey buildingBlockKey10 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey10);
				CharacterList returnValue97 = QuickFillComfortableHouse(context, buildingBlockKey10);
				return GameData.Serializer.Serializer.Serialize(returnValue97, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 89:
		{
			int argsCount61 = operation.ArgsCount;
			int num61 = argsCount61;
			if (num61 == 1)
			{
				BuildingBlockKey buildingBlockKey8 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey8);
				RemoveAllFromComfortableHouse(context, buildingBlockKey8);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 90:
		{
			int argsCount54 = operation.ArgsCount;
			int num54 = argsCount54;
			if (num54 == 1)
			{
				List<int> charIdList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charIdList);
				List<int> returnValue84 = SortedComfortableHousePeople(context, charIdList);
				return GameData.Serializer.Serializer.Serialize(returnValue84, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 91:
		{
			int argsCount50 = operation.ArgsCount;
			int num50 = argsCount50;
			if (num50 == 8)
			{
				short materialTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref materialTemplateId);
				ItemKey toolKey3 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolKey3);
				BuildingBlockKey buildingBlockKey6 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey6);
				sbyte lifeSkillType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref lifeSkillType2);
				List<short> makeItemSubtypeIdList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref makeItemSubtypeIdList);
				short makeItemSubTypeId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref makeItemSubTypeId);
				bool isPerfect = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isPerfect);
				bool isManual = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isManual);
				MakeResult returnValue79 = GetMakeResult(materialTemplateId, toolKey3, buildingBlockKey6, lifeSkillType2, makeItemSubtypeIdList, makeItemSubTypeId, isPerfect, isManual);
				return GameData.Serializer.Serializer.Serialize(returnValue79, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 92:
			if (operation.ArgsCount == 0)
			{
				int returnValue72 = GetSutraReadingRoomBuffValue();
				return GameData.Serializer.Serializer.Serialize(returnValue72, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 93:
		{
			int argsCount43 = operation.ArgsCount;
			int num43 = argsCount43;
			if (num43 == 2)
			{
				short blockIndex6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockIndex6);
				bool isAutoWork = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAutoWork);
				SetBuildingAutoWork(context, blockIndex6, isAutoWork);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 94:
		{
			int argsCount37 = operation.ArgsCount;
			int num37 = argsCount37;
			if (num37 == 1)
			{
				short blockIndex5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockIndex5);
				bool returnValue59 = GetBuildingIsAutoWork(blockIndex5);
				return GameData.Serializer.Serializer.Serialize(returnValue59, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 95:
		{
			int argsCount34 = operation.ArgsCount;
			int num34 = argsCount34;
			if (num34 == 3)
			{
				BuildingBlockKey key7 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key7);
				List<ItemKey> itemList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemList);
				List<int> operateTypeList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref operateTypeList);
				ShopBuildingMultiChangeSoldItem(context, key7, itemList, operateTypeList);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 96:
		{
			int argsCount29 = operation.ArgsCount;
			int num29 = argsCount29;
			if (num29 == 2)
			{
				int charId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId8);
				List<MultiplyOperation> operationList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref operationList);
				List<ItemDisplayData> returnValue48 = RepairItemList(context, charId8, operationList);
				return GameData.Serializer.Serializer.Serialize(returnValue48, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 97:
		{
			int argsCount24 = operation.ArgsCount;
			int num24 = argsCount24;
			if (num24 == 2)
			{
				short blockIndex2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockIndex2);
				bool isAutoSold = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAutoSold);
				SetBuildingAutoSold(context, blockIndex2, isAutoSold);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 98:
		{
			int argsCount18 = operation.ArgsCount;
			int num18 = argsCount18;
			if (num18 == 1)
			{
				short blockIndex = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockIndex);
				bool returnValue30 = GetBuildingIsAutoSold(blockIndex);
				return GameData.Serializer.Serializer.Serialize(returnValue30, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 99:
			if (operation.ArgsCount == 0)
			{
				List<sbyte> returnValue25 = GetXiangshuIdInKungfuRoom();
				return GameData.Serializer.Serializer.Serialize(returnValue25, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 100:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 4)
			{
				int charId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId3);
				ItemKey toolKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolKey);
				ItemKey itemKey2 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey2);
				sbyte toolSourceType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolSourceType);
				ItemDisplayData returnValue19 = RepairItemOptional(context, charId3, toolKey, itemKey2, toolSourceType);
				return GameData.Serializer.Serializer.Serialize(returnValue19, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 101:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 2)
			{
				int id = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref id);
				string nickname = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref nickname);
				SetNickNameByChickenId(context, id, nickname);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 102:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				Location location3 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location3);
				List<Chicken> returnValue11 = GetSettlementChickenDataList(location3);
				return GameData.Serializer.Serializer.Serialize(returnValue11, returnDataPool);
			}
			case 2:
			{
				Location location2 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location2);
				bool ignoreFulong = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref ignoreFulong);
				List<Chicken> returnValue10 = GetSettlementChickenDataList(location2, ignoreFulong);
				return GameData.Serializer.Serializer.Serialize(returnValue10, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 103:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 1)
			{
				short weatherId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref weatherId);
				SetTeaHorseCaravanWeather(context, weatherId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 104:
		{
			int argsCount162 = operation.ArgsCount;
			int num162 = argsCount162;
			if (num162 == 1)
			{
				short blockIndex10 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockIndex10);
				bool returnValue189 = GetComfortableIsAutoCheckIn(blockIndex10);
				return GameData.Serializer.Serializer.Serialize(returnValue189, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 105:
		{
			int argsCount158 = operation.ArgsCount;
			int num158 = argsCount158;
			if (num158 == 1)
			{
				short blockIndex9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockIndex9);
				bool returnValue186 = GetResidenceIsAutoCheckIn(blockIndex9);
				return GameData.Serializer.Serializer.Serialize(returnValue186, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 106:
		{
			int argsCount154 = operation.ArgsCount;
			int num154 = argsCount154;
			if (num154 == 2)
			{
				short blockIndex8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockIndex8);
				bool isAutoCheckIn2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAutoCheckIn2);
				SetComfortableAutoCheckIn(context, blockIndex8, isAutoCheckIn2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 107:
		{
			int argsCount150 = operation.ArgsCount;
			int num150 = argsCount150;
			if (num150 == 2)
			{
				short blockIndex7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockIndex7);
				bool isAutoCheckIn = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAutoCheckIn);
				SetResidenceAutoCheckIn(context, blockIndex7, isAutoCheckIn);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 108:
		{
			int argsCount145 = operation.ArgsCount;
			int num145 = argsCount145;
			if (num145 == 1)
			{
				short buildingTemplateId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingTemplateId6);
				GmCmd_AddLegacyBuilding(context, buildingTemplateId6);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 109:
		{
			int argsCount141 = operation.ArgsCount;
			int num141 = argsCount141;
			if (num141 == 2)
			{
				int charId21 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId21);
				bool add = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref add);
				SetUnlockedWorkingVillagers(context, charId21, add);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 110:
		{
			int argsCount137 = operation.ArgsCount;
			int num137 = argsCount137;
			if (num137 == 3)
			{
				ItemDisplayData tool2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref tool2);
				ItemDisplayData target3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref target3);
				short weaveClothingTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref weaveClothingTemplateId);
				ItemDisplayData returnValue171 = WeaveClothingItem(context, tool2, target3, weaveClothingTemplateId);
				return GameData.Serializer.Serializer.Serialize(returnValue171, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 111:
			if (operation.ArgsCount == 0)
			{
				List<Chicken> returnValue168 = GmCmd_GetChickenData();
				return GameData.Serializer.Serializer.Serialize(returnValue168, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 112:
		{
			int argsCount130 = operation.ArgsCount;
			int num130 = argsCount130;
			if (num130 == 4)
			{
				List<int> soulCharIds2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref soulCharIds2);
				int bodyCharId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bodyCharId2);
				List<short> featureIds2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref featureIds2);
				int previewId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref previewId);
				PossessionPreview returnValue166 = GetPossessionPreview(context, soulCharIds2, bodyCharId2, featureIds2, previewId);
				return GameData.Serializer.Serializer.Serialize(returnValue166, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 113:
		{
			int argsCount127 = operation.ArgsCount;
			int num127 = argsCount127;
			if (num127 == 3)
			{
				List<int> soulCharIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref soulCharIds);
				int bodyCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bodyCharId);
				List<short> featureIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref featureIds);
				byte returnValue163 = TrySwapSoulCeremony(context, soulCharIds, bodyCharId, featureIds);
				return GameData.Serializer.Serializer.Serialize(returnValue163, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 114:
		{
			int argsCount124 = operation.ArgsCount;
			int num124 = argsCount124;
			if (num124 == 2)
			{
				ItemKey itemKey8 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey8);
				sbyte itemSource2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSource2);
				GetBackTeaHorseCarryItem(context, itemKey8, itemSource2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 115:
		{
			int argsCount121 = operation.ArgsCount;
			int num121 = argsCount121;
			if (num121 == 2)
			{
				ItemKey itemKey7 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey7);
				sbyte itemSource = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSource);
				AddItemToTeaHorseCarryItem(context, itemKey7, itemSource);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 116:
		{
			int argsCount117 = operation.ArgsCount;
			int num117 = argsCount117;
			if (num117 == 1)
			{
				AvatarData avatar = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref avatar);
				SetTemporaryPossessionCharacterAvatar(context, avatar);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 117:
			if (operation.ArgsCount == 0)
			{
				List<int> returnValue151 = GetSwapSoulCeremonyBodyCharIdList();
				return GameData.Serializer.Serializer.Serialize(returnValue151, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 118:
		{
			int argsCount111 = operation.ArgsCount;
			int num111 = argsCount111;
			if (num111 == 2)
			{
				BuildingBlockKey blockKey37 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey37);
				int[] managerCharacterIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref managerCharacterIds);
				int[] returnValue146 = GetBuildingShopManagerAutoArrangeSorted(blockKey37, managerCharacterIds);
				return GameData.Serializer.Serializer.Serialize(returnValue146, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 119:
			if (operation.ArgsCount == 0)
			{
				SectMainStoryJingangClickMonkSoulBtn(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 120:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				BuildingBlockKey key18 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key18);
				int earningDataIndex7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref earningDataIndex7);
				RejectBuildingBlockRecruitPeople(context, key18, earningDataIndex7);
				return -1;
			}
			case 3:
			{
				BuildingBlockKey key17 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key17);
				int earningDataIndex6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref earningDataIndex6);
				bool isSetData4 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isSetData4);
				RejectBuildingBlockRecruitPeople(context, key17, earningDataIndex6, isSetData4);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 121:
		{
			int argsCount105 = operation.ArgsCount;
			int num105 = argsCount105;
			if (num105 == 1)
			{
				BuildingBlockKey key16 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key16);
				RejectBuildingBlockRecruitPeopleQuick(context, key16);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 122:
		{
			int argsCount103 = operation.ArgsCount;
			int num103 = argsCount103;
			if (num103 == 1)
			{
				BuildingBlockKey blockKey33 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey33);
				BuildingManageYieldTipsData returnValue140 = GetShopManagementYieldTipsData(context, blockKey33);
				return GameData.Serializer.Serializer.Serialize(returnValue140, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 123:
		{
			int argsCount101 = operation.ArgsCount;
			int num101 = argsCount101;
			if (num101 == 1)
			{
				BuildingBlockKey blockKey32 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey32);
				int returnValue137 = CalculateBuildingManageHarvestSuccessRate(blockKey32);
				return GameData.Serializer.Serializer.Serialize(returnValue137, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 124:
		{
			int argsCount98 = operation.ArgsCount;
			int num98 = argsCount98;
			if (num98 == 1)
			{
				BuildingBlockKey buildingBlockKey23 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey23);
				ShopEventCollection returnValue133 = GetOrCreateShopEventCollection(buildingBlockKey23);
				return GameData.Serializer.Serializer.Serialize(returnValue133, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 125:
			if (operation.ArgsCount == 0)
			{
				SamsaraPlatformRecordCollection returnValue128 = GetSamsaraPlatformRecord();
				return GameData.Serializer.Serializer.Serialize(returnValue128, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 126:
			if (operation.ArgsCount == 0)
			{
				List<SamsaraPlatformCharDisplayData> returnValue122 = GetSwapSoulCeremonySoulCharIdList(context);
				return GameData.Serializer.Serializer.Serialize(returnValue122, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 127:
			if (operation.ArgsCount == 0)
			{
				CricketCollectionBatchAddCricketJar(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 128:
			if (operation.ArgsCount == 0)
			{
				CricketCollectionBatchAddCricket(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 129:
		{
			int argsCount85 = operation.ArgsCount;
			int num85 = argsCount85;
			if (num85 == 1)
			{
				ItemSourceType sourceType4 = ItemSourceType.Equipment;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref sourceType4);
				CricketCollectionBatchRemoveJar(context, sourceType4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 130:
		{
			int argsCount80 = operation.ArgsCount;
			int num80 = argsCount80;
			if (num80 == 1)
			{
				ItemSourceType sourceType3 = ItemSourceType.Equipment;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref sourceType3);
				CricketCollectionBatchRemoveCricket(context, sourceType3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 131:
		{
			int argsCount77 = operation.ArgsCount;
			int num77 = argsCount77;
			if (num77 == 2)
			{
				short itemSubType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSubType2);
				ItemSourceType sourceType2 = ItemSourceType.Equipment;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref sourceType2);
				List<ItemDisplayData> returnValue107 = GetCricketOrJarFromSourceStorage(context, itemSubType2, sourceType2);
				return GameData.Serializer.Serializer.Serialize(returnValue107, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 132:
		{
			int argsCount72 = operation.ArgsCount;
			int num72 = argsCount72;
			if (num72 == 4)
			{
				int collectionIndex = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref collectionIndex);
				short itemSubType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSubType);
				ItemSourceType sourceType = ItemSourceType.Equipment;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref sourceType);
				ItemKey itemKey5 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey5);
				SmartOperateCricketOrJarCollection(context, collectionIndex, itemSubType, sourceType, itemKey5);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 133:
			if (operation.ArgsCount == 0)
			{
				CricketCollectionBatchButtonStateDisplayData returnValue102 = GetBatchButtonEnableState(context);
				return GameData.Serializer.Serializer.Serialize(returnValue102, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 134:
		{
			int argsCount66 = operation.ArgsCount;
			int num66 = argsCount66;
			if (num66 == 1)
			{
				BuildingBlockKey blockKey18 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey18);
				int[] returnValue98 = CalculateBuildingManageHarvestSuccessRates(blockKey18);
				return GameData.Serializer.Serializer.Serialize(returnValue98, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 135:
		{
			int argsCount63 = operation.ArgsCount;
			int num63 = argsCount63;
			if (num63 == 2)
			{
				short orgMemberTemplateId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgMemberTemplateId3);
				int chickenId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref chickenId5);
				bool returnValue94 = UnsetFulongChicken(context, orgMemberTemplateId3, chickenId5);
				return GameData.Serializer.Serializer.Serialize(returnValue94, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 136:
		{
			int argsCount60 = operation.ArgsCount;
			int num60 = argsCount60;
			if (num60 == 2)
			{
				short orgMemberTemplateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgMemberTemplateId2);
				int chickenId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref chickenId4);
				bool returnValue90 = SetFulongChicken(context, orgMemberTemplateId2, chickenId4);
				return GameData.Serializer.Serializer.Serialize(returnValue90, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 137:
		{
			int argsCount56 = operation.ArgsCount;
			int num56 = argsCount56;
			if (num56 == 1)
			{
				List<int> idList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref idList);
				List<Chicken> returnValue86 = GetChickenDataList(idList);
				return GameData.Serializer.Serializer.Serialize(returnValue86, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 138:
		{
			int argsCount52 = operation.ArgsCount;
			int num52 = argsCount52;
			if (num52 == 1)
			{
				List<int> chickenIdList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref chickenIdList);
				List<string> returnValue81 = GetChickenNicknameList(chickenIdList);
				return GameData.Serializer.Serializer.Serialize(returnValue81, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 139:
		{
			int argsCount49 = operation.ArgsCount;
			int num49 = argsCount49;
			if (num49 == 1)
			{
				Location location5 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location5);
				List<int> returnValue78 = GetSettlementChickenIdList(location5);
				return GameData.Serializer.Serializer.Serialize(returnValue78, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 140:
		{
			int argsCount46 = operation.ArgsCount;
			int num46 = argsCount46;
			if (num46 == 1)
			{
				Location location4 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location4);
				List<string> returnValue73 = GetChickensNicknameByLocation(location4);
				return GameData.Serializer.Serializer.Serialize(returnValue73, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 141:
			if (operation.ArgsCount == 0)
			{
				bool returnValue71 = AllChickenInTaiwuVillage(context);
				return GameData.Serializer.Serializer.Serialize(returnValue71, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 142:
			if (operation.ArgsCount == 0)
			{
				List<bool> returnValue67 = GetVillagerRoleExtraEffectUnlockState();
				return GameData.Serializer.Serializer.Serialize(returnValue67, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 143:
			switch (operation.ArgsCount)
			{
			case 0:
			{
				bool returnValue66 = ClickChickenMap(context);
				return GameData.Serializer.Serializer.Serialize(returnValue66, returnDataPool);
			}
			case 1:
			{
				bool ignoreTask = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref ignoreTask);
				bool returnValue65 = ClickChickenMap(context, ignoreTask);
				return GameData.Serializer.Serializer.Serialize(returnValue65, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 144:
		{
			int argsCount38 = operation.ArgsCount;
			int num38 = argsCount38;
			if (num38 == 1)
			{
				int chickenId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref chickenId);
				ClickChickenSign(context, chickenId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 145:
		{
			int argsCount35 = operation.ArgsCount;
			int num35 = argsCount35;
			if (num35 == 2)
			{
				int blockIndex4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockIndex4);
				BuildingResourceOutputSetting setting = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref setting);
				SetBuildingResourceOutputSetting(context, blockIndex4, setting);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 146:
		{
			int argsCount32 = operation.ArgsCount;
			int num32 = argsCount32;
			if (num32 == 1)
			{
				int blockIndex3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockIndex3);
				BuildingResourceOutputSetting returnValue52 = GetBuildingResourceOutputSetting(blockIndex3);
				return GameData.Serializer.Serializer.Serialize(returnValue52, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 147:
			if (operation.ArgsCount == 0)
			{
				BuildingExceptionData returnValue50 = GetBuildingExceptionData();
				return GameData.Serializer.Serializer.Serialize(returnValue50, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 148:
		{
			int argsCount26 = operation.ArgsCount;
			int num26 = argsCount26;
			if (num26 == 1)
			{
				BuildingBlockKey blockKey12 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey12);
				bool returnValue45 = AllDependBuildingAvailable(blockKey12);
				return GameData.Serializer.Serializer.Serialize(returnValue45, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 149:
		{
			int argsCount23 = operation.ArgsCount;
			int num23 = argsCount23;
			if (num23 == 4)
			{
				BuildingBlockKey blockKey11 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey11);
				short skillTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateId);
				int count = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count);
				int cost = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref cost);
				int returnValue42 = PracticingCombatSkillInPracticeRoom(context, blockKey11, skillTemplateId, count, cost);
				return GameData.Serializer.Serializer.Serialize(returnValue42, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 150:
		{
			int argsCount20 = operation.ArgsCount;
			int num20 = argsCount20;
			if (num20 == 1)
			{
				BuildingBlockKey blockKey10 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey10);
				bool returnValue36 = HasShopManagerLeader(blockKey10);
				return GameData.Serializer.Serializer.Serialize(returnValue36, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 151:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				BuildingBlockKey blockKey9 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey9);
				List<int> returnValue35 = QuickArrangeShopManager(context, blockKey9);
				return GameData.Serializer.Serializer.Serialize(returnValue35, returnDataPool);
			}
			case 2:
			{
				BuildingBlockKey blockKey8 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey8);
				bool onlyCheck = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref onlyCheck);
				List<int> returnValue34 = QuickArrangeShopManager(context, blockKey8, onlyCheck);
				return GameData.Serializer.Serializer.Serialize(returnValue34, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 152:
			switch (operation.ArgsCount)
			{
			case 3:
			{
				short buildingTemplateId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingTemplateId3);
				BuildingBlockKey blockKey6 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey6);
				sbyte operationType4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref operationType4);
				List<int> returnValue32 = QuickArrangeBuildOperator(buildingTemplateId3, blockKey6, operationType4);
				return GameData.Serializer.Serializer.Serialize(returnValue32, returnDataPool);
			}
			case 4:
			{
				short buildingTemplateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingTemplateId2);
				BuildingBlockKey blockKey5 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey5);
				sbyte operationType3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref operationType3);
				List<int> exceptCharList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref exceptCharList);
				List<int> returnValue31 = QuickArrangeBuildOperator(buildingTemplateId2, blockKey5, operationType3, exceptCharList);
				return GameData.Serializer.Serializer.Serialize(returnValue31, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 153:
		{
			int argsCount17 = operation.ArgsCount;
			int num17 = argsCount17;
			if (num17 == 1)
			{
				BuildingBlockKey blockKey4 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey4);
				bool returnValue27 = ShopBuildingCanTeach(blockKey4);
				return GameData.Serializer.Serializer.Serialize(returnValue27, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 154:
		{
			int argsCount15 = operation.ArgsCount;
			int num15 = argsCount15;
			if (num15 == 4)
			{
				short buildingTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingTemplateId);
				BuildingBlockKey blockKey3 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey3);
				sbyte operationType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref operationType2);
				List<int> operatorList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref operatorList);
				int returnValue23 = GetOperationLeftTime(context, buildingTemplateId, blockKey3, operationType2, operatorList);
				return GameData.Serializer.Serializer.Serialize(returnValue23, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 155:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 2)
			{
				BuildingBlockKey blockKey2 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey2);
				sbyte operationType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref operationType);
				int returnValue21 = GetBuildingOperationLeftTime(context, blockKey2, operationType);
				return GameData.Serializer.Serializer.Serialize(returnValue21, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 156:
		{
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 2)
			{
				BuildingBlockKey blockKey = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey);
				int memberId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref memberId);
				ShopBuildingTeachBookData returnValue17 = GetShopBuildingTeachBookData(blockKey, memberId);
				return GameData.Serializer.Serializer.Serialize(returnValue17, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 157:
			if (operation.ArgsCount == 0)
			{
				int returnValue12 = CalcExtraTaiwuGroupMaxCountByStrategyRoom();
				return GameData.Serializer.Serializer.Serialize(returnValue12, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 158:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 1)
			{
				ItemSourceType itemSourceType = ItemSourceType.Equipment;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSourceType);
				List<ItemDisplayData> returnValue7 = GetTaiwuCanFixBookItemDataList(itemSourceType);
				return GameData.Serializer.Serializer.Serialize(returnValue7, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 159:
			if (operation.ArgsCount == 0)
			{
				(int, int, int) returnValue4 = GetResidenceInfo();
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 160:
		{
			int argsCount163 = operation.ArgsCount;
			int num163 = argsCount163;
			if (num163 == 1)
			{
				EBuildingScaleEffect effectType5 = EBuildingScaleEffect.MigrateSpeedBonusFactor;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref effectType5);
				int returnValue190 = GetTaiwuVillageResourceBlockEffect(context, effectType5);
				return GameData.Serializer.Serializer.Serialize(returnValue190, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 161:
		{
			int argsCount160 = operation.ArgsCount;
			int num160 = argsCount160;
			if (num160 == 1)
			{
				EBuildingScaleEffect effectType4 = EBuildingScaleEffect.MigrateSpeedBonusFactor;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref effectType4);
				int returnValue187 = GetTaiwuLocationResourceBlockEffect(context, effectType4);
				return GameData.Serializer.Serializer.Serialize(returnValue187, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 162:
		{
			int argsCount157 = operation.ArgsCount;
			int num157 = argsCount157;
			if (num157 == 1)
			{
				short templateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId2);
				List<BuildingBlockData> returnValue185 = GetTaiwuVillageResourceBlockEffectInfo(templateId2);
				return GameData.Serializer.Serializer.Serialize(returnValue185, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 163:
		{
			int argsCount155 = operation.ArgsCount;
			int num155 = argsCount155;
			if (num155 == 1)
			{
				BuildingBlockKey blockKey48 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey48);
				bool returnValue182 = CanQuickArrangeShopManager(blockKey48);
				return GameData.Serializer.Serializer.Serialize(returnValue182, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 164:
		{
			int argsCount152 = operation.ArgsCount;
			int num152 = argsCount152;
			if (num152 == 1)
			{
				BuildingBlockKey blockKey47 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey47);
				BuildingFormulaContextBridge returnValue180 = GetBuildingFormulaContextBridge(blockKey47);
				return GameData.Serializer.Serializer.Serialize(returnValue180, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 165:
		{
			int argsCount149 = operation.ArgsCount;
			int num149 = argsCount149;
			if (num149 == 2)
			{
				BuildingBlockKey buildingBlockKey26 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey26);
				sbyte skillType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillType);
				(int, bool) returnValue178 = GetBuildingEffectForMake(buildingBlockKey26, skillType);
				return GameData.Serializer.Serializer.Serialize(returnValue178, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 166:
		{
			int argsCount146 = operation.ArgsCount;
			int num146 = argsCount146;
			if (num146 == 3)
			{
				int totalAttainment = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref totalAttainment);
				short buildingTemplateId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingTemplateId7);
				int repeat2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref repeat2);
				bool returnValue177 = GmCmd_BuildingCollectPerform(context, totalAttainment, buildingTemplateId7, repeat2);
				return GameData.Serializer.Serializer.Serialize(returnValue177, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 167:
		{
			int argsCount143 = operation.ArgsCount;
			int num143 = argsCount143;
			if (num143 == 2)
			{
				sbyte grade = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref grade);
				int repeat = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref repeat);
				bool returnValue176 = GmCmd_BeatMinionPerform(context, grade, repeat);
				return GameData.Serializer.Serializer.Serialize(returnValue176, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 168:
		{
			int argsCount140 = operation.ArgsCount;
			int num140 = argsCount140;
			if (num140 == 1)
			{
				int type2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref type2);
				int returnValue174 = GetStoreLocation(type2);
				return GameData.Serializer.Serializer.Serialize(returnValue174, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 169:
		{
			int argsCount138 = operation.ArgsCount;
			int num138 = argsCount138;
			if (num138 == 2)
			{
				int type = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref type);
				int value = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value);
				SetStoreLocation(context, type, value);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 170:
		{
			int argsCount135 = operation.ArgsCount;
			int num135 = argsCount135;
			if (num135 == 1)
			{
				BuildingBlockKey buildingBlockKey24 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey24);
				List<CharacterDisplayData> returnValue170 = GetFeastTargetCharList(context, buildingBlockKey24);
				return GameData.Serializer.Serializer.Serialize(returnValue170, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 171:
			if (operation.ArgsCount == 0)
			{
				TryShowNotifications();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 172:
		{
			int argsCount131 = operation.ArgsCount;
			int num131 = argsCount131;
			if (num131 == 1)
			{
				BuildingBlockKey blockKey43 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey43);
				QuickRemoveShopSoldItem(context, blockKey43);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 173:
		{
			int argsCount129 = operation.ArgsCount;
			int num129 = argsCount129;
			if (num129 == 1)
			{
				BuildingBlockKey blockKey42 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey42);
				QuickAddShopSoldItem(context, blockKey42);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 174:
			if (operation.ArgsCount == 0)
			{
				TaiwuVillagerInfoTipsDisplayData returnValue162 = CalcTaiwuVillagerInfoDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue162, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 175:
		{
			int argsCount125 = operation.ArgsCount;
			int num125 = argsCount125;
			if (num125 == 2)
			{
				BuildingBlockKey blockKey40 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey40);
				int charId20 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId20);
				int returnValue159 = CalcTaiwuVillagerEfficiencyInBuilding(blockKey40, charId20);
				return GameData.Serializer.Serializer.Serialize(returnValue159, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 176:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				ItemKey key26 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key26);
				QuickGetSpecificExchangeItem(context, key26);
				return -1;
			}
			case 2:
			{
				ItemKey key25 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key25);
				ItemSourceType source2 = ItemSourceType.Equipment;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref source2);
				QuickGetSpecificExchangeItem(context, key25, source2);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 177:
		{
			int argsCount123 = operation.ArgsCount;
			int num123 = argsCount123;
			if (num123 == 1)
			{
				Location location8 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location8);
				bool returnValue158 = AddLocationMark(context, location8);
				return GameData.Serializer.Serializer.Serialize(returnValue158, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 178:
		{
			int argsCount120 = operation.ArgsCount;
			int num120 = argsCount120;
			if (num120 == 1)
			{
				Location location7 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location7);
				bool returnValue156 = RemoveLocationMark(context, location7);
				return GameData.Serializer.Serializer.Serialize(returnValue156, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 179:
			if (operation.ArgsCount == 0)
			{
				List<int> returnValue154 = RequestUnlockedWorkingVillagers();
				return GameData.Serializer.Serializer.Serialize(returnValue154, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 180:
		{
			int argsCount115 = operation.ArgsCount;
			int num115 = argsCount115;
			if (num115 == 2)
			{
				BuildingBlockKey key23 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key23);
				BuildingOptionAutoGiveMemberPreset setting3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref setting3);
				SetBuildingArrangementSetting(context, key23, setting3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 181:
		{
			int argsCount114 = operation.ArgsCount;
			int num114 = argsCount114;
			if (num114 == 2)
			{
				BuildingBlockKey key22 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key22);
				int level2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref level2);
				bool returnValue150 = UpgradeResourceBuilding(context, key22, level2);
				return GameData.Serializer.Serializer.Serialize(returnValue150, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 182:
		{
			int argsCount112 = operation.ArgsCount;
			int num112 = argsCount112;
			if (num112 == 2)
			{
				BuildingBlockKey key21 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key21);
				int levelSlotIndex = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref levelSlotIndex);
				bool returnValue147 = UpgradeSlotBuilding(context, key21, levelSlotIndex);
				return GameData.Serializer.Serializer.Serialize(returnValue147, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 183:
		{
			int argsCount109 = operation.ArgsCount;
			int num109 = argsCount109;
			if (num109 == 2)
			{
				BuildingBlockKey key20 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key20);
				int index3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index3);
				bool returnValue145 = UnlockBuildingLevelSlot(context, key20, index3);
				return GameData.Serializer.Serializer.Serialize(returnValue145, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 184:
		{
			int argsCount108 = operation.ArgsCount;
			int num108 = argsCount108;
			if (num108 == 2)
			{
				BuildingBlockKey key19 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key19);
				BuildingOptionAutoAddSoldItemPreset setting2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref setting2);
				SetBuildingSoldItemSetting(context, key19, setting2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 185:
			if (operation.ArgsCount == 0)
			{
				PuppetPageDisplayData returnValue143 = GetPuppetPageDisplayData(context);
				return GameData.Serializer.Serializer.Serialize(returnValue143, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 186:
			if (operation.ArgsCount == 0)
			{
				QuickRepairAllBuilding(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 187:
			if (operation.ArgsCount == 0)
			{
				int returnValue141 = CalcQuickRepairAllBuildingCostMoney(context);
				return GameData.Serializer.Serializer.Serialize(returnValue141, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 188:
			if (operation.ArgsCount == 0)
			{
				BuildingFunctionData returnValue138 = GetBuildingFunctionData(context);
				return GameData.Serializer.Serializer.Serialize(returnValue138, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 189:
			if (operation.ArgsCount == 0)
			{
				BuildingAreaData returnValue136 = GetTaiwuVillageBuildingAreaData();
				return GameData.Serializer.Serializer.Serialize(returnValue136, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 190:
		{
			int argsCount99 = operation.ArgsCount;
			int num99 = argsCount99;
			if (num99 == 1)
			{
				bool getItem = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref getItem);
				List<ItemDisplayData> returnValue134 = GetAllPawnShopItem(context, getItem);
				return GameData.Serializer.Serializer.Serialize(returnValue134, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 191:
		{
			int argsCount96 = operation.ArgsCount;
			int num96 = argsCount96;
			if (num96 == 1)
			{
				BuildingBlockKey blockKey31 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey31);
				TaiwuVillageBlockEffectInfo returnValue131 = GetTaiwuVillageBlockEffectInfo(context, blockKey31);
				return GameData.Serializer.Serializer.Serialize(returnValue131, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 192:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				BuildingBlockKey blockKey30 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey30);
				BuildingShopData returnValue130 = GetTaiwuVillageShopData(context, blockKey30);
				return GameData.Serializer.Serializer.Serialize(returnValue130, returnDataPool);
			}
			case 2:
			{
				BuildingBlockKey blockKey29 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey29);
				EBuildingScaleEffect effectType3 = EBuildingScaleEffect.MigrateSpeedBonusFactor;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref effectType3);
				BuildingShopData returnValue129 = GetTaiwuVillageShopData(context, blockKey29, effectType3);
				return GameData.Serializer.Serializer.Serialize(returnValue129, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 193:
		{
			int argsCount94 = operation.ArgsCount;
			int num94 = argsCount94;
			if (num94 == 1)
			{
				BuildingBlockKey blockKey28 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey28);
				BuildingEarningDisplayData returnValue127 = GetBuildingEarningDisplayData(context, blockKey28);
				return GameData.Serializer.Serializer.Serialize(returnValue127, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 194:
		{
			int argsCount93 = operation.ArgsCount;
			int num93 = argsCount93;
			if (num93 == 1)
			{
				BuildingBlockKey blockKey25 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey25);
				BuildingManageDisplayData returnValue123 = GetBuildingManageDisplayData(context, blockKey25);
				return GameData.Serializer.Serializer.Serialize(returnValue123, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 195:
			if (operation.ArgsCount == 0)
			{
				List<short> returnValue121 = GetUnlockedFeastTypeList();
				return GameData.Serializer.Serializer.Serialize(returnValue121, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 196:
			if (operation.ArgsCount == 0)
			{
				TransferableRecordDataBase returnValue119 = GetReversedSamsaraRecord(context);
				return GameData.Serializer.Serializer.Serialize(returnValue119, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 197:
		{
			int argsCount89 = operation.ArgsCount;
			int num89 = argsCount89;
			if (num89 == 1)
			{
				BuildingBlockKey buildingBlockKey20 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey20);
				CharacterSet returnValue116 = GetLockedComfortableHouseCharacters(buildingBlockKey20);
				return GameData.Serializer.Serializer.Serialize(returnValue116, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 198:
		{
			int argsCount87 = operation.ArgsCount;
			int num87 = argsCount87;
			if (num87 == 1)
			{
				BuildingBlockKey buildingBlockKey19 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey19);
				CharacterSet returnValue115 = GetLockedResidenceCharacters(buildingBlockKey19);
				return GameData.Serializer.Serializer.Serialize(returnValue115, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 199:
		{
			int argsCount84 = operation.ArgsCount;
			int num84 = argsCount84;
			if (num84 == 2)
			{
				BuildingBlockKey buildingBlockKey17 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey17);
				int charId16 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId16);
				bool returnValue113 = UnlockComfortableHouseCharacter(context, buildingBlockKey17, charId16);
				return GameData.Serializer.Serializer.Serialize(returnValue113, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 200:
		{
			int argsCount81 = operation.ArgsCount;
			int num81 = argsCount81;
			if (num81 == 2)
			{
				BuildingBlockKey buildingBlockKey16 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey16);
				int charId15 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId15);
				bool returnValue110 = LockComfortableHouseCharacter(context, buildingBlockKey16, charId15);
				return GameData.Serializer.Serializer.Serialize(returnValue110, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 201:
		{
			int argsCount79 = operation.ArgsCount;
			int num79 = argsCount79;
			if (num79 == 2)
			{
				BuildingBlockKey buildingBlockKey15 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey15);
				int charId14 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId14);
				bool returnValue109 = UnlockResidenceCharacter(context, buildingBlockKey15, charId14);
				return GameData.Serializer.Serializer.Serialize(returnValue109, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 202:
		{
			int argsCount76 = operation.ArgsCount;
			int num76 = argsCount76;
			if (num76 == 2)
			{
				BuildingBlockKey buildingBlockKey13 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey13);
				bool checkInType = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref checkInType);
				SetComfortableAutoCheckInType(context, buildingBlockKey13, checkInType);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 203:
		{
			int argsCount73 = operation.ArgsCount;
			int num73 = argsCount73;
			if (num73 == 2)
			{
				BuildingBlockKey buildingBlockKey12 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey12);
				int charId12 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId12);
				bool returnValue105 = LockResidenceCharacter(context, buildingBlockKey12, charId12);
				return GameData.Serializer.Serializer.Serialize(returnValue105, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 204:
		{
			int argsCount70 = operation.ArgsCount;
			int num70 = argsCount70;
			if (num70 == 1)
			{
				short eventTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref eventTemplateId);
				SetNextTeaHorseCaravanEvent(eventTemplateId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 205:
			if (operation.ArgsCount == 0)
			{
				List<int> returnValue101 = GetLockedInComfortableHouseIds(context);
				return GameData.Serializer.Serializer.Serialize(returnValue101, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 206:
			if (operation.ArgsCount == 0)
			{
				List<int> returnValue99 = GetLockedInResidenceIds(context);
				return GameData.Serializer.Serializer.Serialize(returnValue99, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 207:
		{
			int argsCount64 = operation.ArgsCount;
			int num64 = argsCount64;
			if (num64 == 1)
			{
				BuildingBlockKey blockKey17 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey17);
				TransferableRecordDataBase returnValue96 = GetReversedBlockShopEvent(context, blockKey17);
				return GameData.Serializer.Serializer.Serialize(returnValue96, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 208:
			if (operation.ArgsCount == 0)
			{
				List<ItemDisplayData> returnValue93 = PluckAllChickenFeathers(context);
				return GameData.Serializer.Serializer.Serialize(returnValue93, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 209:
			if (operation.ArgsCount == 0)
			{
				bool returnValue91 = IsAllChickensCanPluck();
				return GameData.Serializer.Serializer.Serialize(returnValue91, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 210:
		{
			int argsCount58 = operation.ArgsCount;
			int num58 = argsCount58;
			if (num58 == 1)
			{
				int characterId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId4);
				List<short> returnValue88 = GetCharacterChickenFeatures(characterId4);
				return GameData.Serializer.Serializer.Serialize(returnValue88, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 211:
		{
			int argsCount55 = operation.ArgsCount;
			int num55 = argsCount55;
			if (num55 == 1)
			{
				sbyte personalityType3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref personalityType3);
				List<Chicken> returnValue85 = GetChickensByPersonalityType(personalityType3);
				return GameData.Serializer.Serializer.Serialize(returnValue85, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 212:
			if (operation.ArgsCount == 0)
			{
				int returnValue82 = GetCurrentFeatherValue();
				return GameData.Serializer.Serializer.Serialize(returnValue82, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 213:
			if (operation.ArgsCount == 0)
			{
				bool returnValue80 = CanCultivateFeather();
				return GameData.Serializer.Serializer.Serialize(returnValue80, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 214:
			if (operation.ArgsCount == 0)
			{
				ChickenPluckFeatherDisplayData returnValue77 = GetChickenPluckFeatherDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue77, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 215:
			if (operation.ArgsCount == 0)
			{
				bool returnValue74 = IsFeatherSystemUnlocked();
				return GameData.Serializer.Serializer.Serialize(returnValue74, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 216:
			if (operation.ArgsCount == 0)
			{
				UnlockFeatherSystem(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 217:
		{
			int argsCount44 = operation.ArgsCount;
			int num44 = argsCount44;
			if (num44 == 1)
			{
				int chickenId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref chickenId3);
				List<ItemDisplayData> returnValue70 = PluckChickenFeather(context, chickenId3);
				return GameData.Serializer.Serializer.Serialize(returnValue70, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 218:
		{
			int argsCount42 = operation.ArgsCount;
			int num42 = argsCount42;
			if (num42 == 2)
			{
				int characterId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId3);
				sbyte personalityType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref personalityType2);
				bool returnValue68 = CanUseChickenFeather(context, characterId3, personalityType2);
				return GameData.Serializer.Serializer.Serialize(returnValue68, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 219:
		{
			int argsCount41 = operation.ArgsCount;
			int num41 = argsCount41;
			if (num41 == 3)
			{
				int characterId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId2);
				ItemKey itemKey4 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey4);
				sbyte personalityType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref personalityType);
				bool returnValue64 = UseChickenFeather(context, characterId2, itemKey4, personalityType);
				return GameData.Serializer.Serializer.Serialize(returnValue64, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 220:
		{
			int argsCount39 = operation.ArgsCount;
			int num39 = argsCount39;
			if (num39 == 1)
			{
				int chickenId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref chickenId2);
				bool returnValue60 = CanPluckFeatherInVillage(chickenId2);
				return GameData.Serializer.Serializer.Serialize(returnValue60, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 221:
			if (operation.ArgsCount == 0)
			{
				bool returnValue58 = CultivateFeather(context);
				return GameData.Serializer.Serializer.Serialize(returnValue58, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 222:
			if (operation.ArgsCount == 0)
			{
				List<int> returnValue56 = GetCanPluckFeatherChickenIds();
				return GameData.Serializer.Serializer.Serialize(returnValue56, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 223:
			switch (operation.ArgsCount)
			{
			case 0:
			{
				SamsaraPlatformBonusAttributes returnValue55 = GetSamsaraPlatformBonusAttributes();
				return GameData.Serializer.Serializer.Serialize(returnValue55, returnDataPool);
			}
			case 1:
			{
				int charId9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId9);
				SamsaraPlatformBonusAttributes returnValue54 = GetSamsaraPlatformBonusAttributes(charId9);
				return GameData.Serializer.Serializer.Serialize(returnValue54, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 224:
		{
			int argsCount33 = operation.ArgsCount;
			int num33 = argsCount33;
			if (num33 == 1)
			{
				sbyte slot = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref slot);
				SamsaraPlatformCharDisplayData returnValue53 = GetSamsaraPlatformCharDisplayData(context, slot);
				return GameData.Serializer.Serializer.Serialize(returnValue53, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 225:
		{
			int argsCount30 = operation.ArgsCount;
			int num30 = argsCount30;
			if (num30 == 1)
			{
				short orgMemberTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgMemberTemplateId);
				QuickAssignChicken(context, orgMemberTemplateId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 226:
			if (operation.ArgsCount == 0)
			{
				CricketCollectionDisplayData returnValue49 = GetCricketCollectionDisplayData(context);
				return GameData.Serializer.Serializer.Serialize(returnValue49, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 227:
		{
			int argsCount27 = operation.ArgsCount;
			int num27 = argsCount27;
			if (num27 == 2)
			{
				BuildingBlockKey blockKey13 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey13);
				sbyte lifeSkillType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref lifeSkillType);
				BuildingMakeDisplayData returnValue46 = GetBuildingMakeDisplayData(context, blockKey13, lifeSkillType);
				return GameData.Serializer.Serializer.Serialize(returnValue46, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 228:
		{
			int argsCount25 = operation.ArgsCount;
			int num25 = argsCount25;
			if (num25 == 5)
			{
				int charId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId7);
				ItemKey[] toolKeys = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolKeys);
				ItemKey equipItemKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref equipItemKey);
				ItemDisplayData[] materialItemData = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref materialItemData);
				BuildingBlockKey buildingBlockKey2 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingBlockKey2);
				bool returnValue43 = CheckRefineCondition(charId7, toolKeys, equipItemKey, materialItemData, buildingBlockKey2);
				return GameData.Serializer.Serializer.Serialize(returnValue43, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 229:
		{
			int argsCount22 = operation.ArgsCount;
			int num22 = argsCount22;
			if (num22 == 5)
			{
				int charId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId6);
				ItemDisplayData[] tools2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref tools2);
				ItemDisplayData target2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref target2);
				ItemDisplayData[] materialItemArray = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref materialItemArray);
				List<ItemSourceChange> changeList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref changeList);
				ItemDisplayData returnValue41 = RefineItem(context, charId6, tools2, target2, materialItemArray, changeList);
				return GameData.Serializer.Serializer.Serialize(returnValue41, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 230:
		{
			int argsCount21 = operation.ArgsCount;
			int num21 = argsCount21;
			if (num21 == 1)
			{
				int artisanId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref artisanId);
				CraftManDisplayData returnValue37 = GetCraftManDisplayDataForCharacter(context, artisanId);
				return GameData.Serializer.Serializer.Serialize(returnValue37, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 231:
		{
			int argsCount19 = operation.ArgsCount;
			int num19 = argsCount19;
			if (num19 == 1)
			{
				BuildingBlockKey blockKey7 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey7);
				CraftManDisplayData returnValue33 = GetCraftManDisplayDataForBuilding(context, blockKey7);
				return GameData.Serializer.Serializer.Serialize(returnValue33, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 232:
			if (operation.ArgsCount == 0)
			{
				TransferableRecordDataBase returnValue29 = GetTeaHorseCaravanEvent(context);
				return GameData.Serializer.Serializer.Serialize(returnValue29, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 233:
			if (operation.ArgsCount == 0)
			{
				TriggerCultivateFeatherEvent();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 234:
			if (operation.ArgsCount == 0)
			{
				TeaHorseCaravanData returnValue24 = GetTeaHorseCaravanData(context);
				return GameData.Serializer.Serializer.Serialize(returnValue24, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 235:
			if (operation.ArgsCount == 0)
			{
				QuickDiscardExchangeItem(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 236:
			if (operation.ArgsCount == 0)
			{
				TaiwuVillageBuildingDataForVillagerRole returnValue20 = GetTaiwuVillageBuildingDataForVillagerRole(context);
				return GameData.Serializer.Serializer.Serialize(returnValue20, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 237:
			if (operation.ArgsCount == 0)
			{
				bool returnValue18 = IsAnyChickensCanPluck();
				return GameData.Serializer.Serializer.Serialize(returnValue18, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 238:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 2)
			{
				int id2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref id2);
				ItemKey itemKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey);
				sbyte returnValue15 = FeedChicken(context, id2, itemKey);
				return GameData.Serializer.Serializer.Serialize(returnValue15, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 239:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				short settlementId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId2);
				EBuildingScaleEffect effectType2 = EBuildingScaleEffect.MigrateSpeedBonusFactor;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref effectType2);
				int returnValue14 = GetBuildingBlockEffect(settlementId2, effectType2);
				return GameData.Serializer.Serializer.Serialize(returnValue14, returnDataPool);
			}
			case 3:
			{
				short settlementId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId);
				EBuildingScaleEffect effectType = EBuildingScaleEffect.MigrateSpeedBonusFactor;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref effectType);
				int subType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref subType);
				int returnValue13 = GetBuildingBlockEffect(settlementId, effectType, subType);
				return GameData.Serializer.Serializer.Serialize(returnValue13, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 240:
			if (operation.ArgsCount == 0)
			{
				ClearNewlyCreatedBuildingIndex(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 241:
			if (operation.ArgsCount == 0)
			{
				List<short> returnValue8 = GetNewlyCreatedBuildingIndex(context);
				return GameData.Serializer.Serializer.Serialize(returnValue8, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 242:
			if (operation.ArgsCount == 0)
			{
				ResourceInts returnValue5 = GetQuickCollectResourceAmount(context);
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 243:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 3)
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				ItemDisplayData[] tools = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref tools);
				ItemDisplayData[] equipments = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref equipments);
				ItemDisplayData[] returnValue3 = RepairItemsOptional(context, charId, tools, equipments);
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 244:
			if (operation.ArgsCount == 0)
			{
				bool returnValue = AnyBuildingEarnCountMax(context);
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
			_modificationsBuildingAreas.ChangeRecording(monitoring);
			break;
		case 1:
			_modificationsBuildingBlocks.ChangeRecording(monitoring);
			break;
		case 2:
			break;
		case 3:
			_modificationsCollectBuildingResourceType.ChangeRecording(monitoring);
			break;
		case 4:
			_modificationsBuildingOperatorDict.ChangeRecording(monitoring);
			break;
		case 5:
			_modificationsCustomBuildingName.ChangeRecording(monitoring);
			break;
		case 6:
			break;
		case 7:
			_modificationsChicken.ChangeRecording(monitoring);
			break;
		case 8:
			break;
		case 9:
			break;
		case 10:
			break;
		case 11:
			break;
		case 12:
			break;
		case 13:
			break;
		case 14:
			break;
		case 15:
			break;
		case 16:
			_modificationsSamsaraPlatformBornDict.ChangeRecording(monitoring);
			break;
		case 17:
			_modificationsCollectBuildingEarningsData.ChangeRecording(monitoring);
			break;
		case 18:
			_modificationsShopManagerDict.ChangeRecording(monitoring);
			break;
		case 19:
			break;
		case 20:
			break;
		case 21:
			_modificationsLocationMarkHashSet.ChangeRecording(monitoring);
			break;
		case 22:
			break;
		case 23:
			break;
		case 24:
			break;
		case 25:
			_modificationsShopManagerUpgradeQualificationDict.ChangeRecording(monitoring);
			break;
		case 26:
			break;
		case 27:
			break;
		case 28:
			break;
		case 29:
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
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 0);
			int offset5 = GameData.Serializer.Serializer.SerializeModifications(_buildingAreas, dataPool, _modificationsBuildingAreas);
			_modificationsBuildingAreas.Reset();
			return offset5;
		}
		case 1:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 1))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 1);
			int offset10 = GameData.Serializer.Serializer.SerializeModifications(_buildingBlocks, dataPool, _modificationsBuildingBlocks);
			_modificationsBuildingBlocks.Reset();
			return offset10;
		}
		case 2:
			if (!BaseGameDataDomain.IsModified(DataStates, 2))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 2);
			return GameData.Serializer.Serializer.Serialize(_taiwuBuildingAreas, dataPool);
		case 3:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 3))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 3);
			int offset8 = GameData.Serializer.Serializer.SerializeModifications(_CollectBuildingResourceType, dataPool, _modificationsCollectBuildingResourceType);
			_modificationsCollectBuildingResourceType.Reset();
			return offset8;
		}
		case 4:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 4))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 4);
			int offset = GameData.Serializer.Serializer.SerializeModifications(_buildingOperatorDict, dataPool, _modificationsBuildingOperatorDict);
			_modificationsBuildingOperatorDict.Reset();
			return offset;
		}
		case 5:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 5))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 5);
			int offset7 = GameData.Serializer.Serializer.SerializeModifications(_customBuildingName, dataPool, _modificationsCustomBuildingName);
			_modificationsCustomBuildingName.Reset();
			return offset7;
		}
		case 6:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 7:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 7))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 7);
			int offset4 = GameData.Serializer.Serializer.SerializeModifications(_chicken, dataPool, _modificationsChicken);
			_modificationsChicken.Reset();
			return offset4;
		}
		case 8:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 9:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 10:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 11:
			if (!BaseGameDataDomain.IsModified(DataStates, 11))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 11);
			return GameData.Serializer.Serializer.Serialize(_homeless, dataPool);
		case 12:
			if (!BaseGameDataDomain.IsModified(DataStates, 12))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 12);
			return GameData.Serializer.Serializer.Serialize(_samsaraPlatformAddMainAttributes, dataPool);
		case 13:
			if (!BaseGameDataDomain.IsModified(DataStates, 13))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 13);
			return GameData.Serializer.Serializer.Serialize(_samsaraPlatformAddCombatSkillQualifications, dataPool);
		case 14:
			if (!BaseGameDataDomain.IsModified(DataStates, 14))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 14);
			return GameData.Serializer.Serializer.Serialize(_samsaraPlatformAddLifeSkillQualifications, dataPool);
		case 15:
			if (!BaseGameDataDomain.IsModified(_dataStatesSamsaraPlatformSlots, (int)subId0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(_dataStatesSamsaraPlatformSlots, (int)subId0);
			return GameData.Serializer.Serializer.Serialize(_samsaraPlatformSlots[(uint)subId0], dataPool);
		case 16:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 16))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 16);
			int offset11 = GameData.Serializer.Serializer.SerializeModifications(_samsaraPlatformBornDict, dataPool, _modificationsSamsaraPlatformBornDict);
			_modificationsSamsaraPlatformBornDict.Reset();
			return offset11;
		}
		case 17:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 17))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 17);
			int offset9 = GameData.Serializer.Serializer.SerializeModifications(_collectBuildingEarningsData, dataPool, _modificationsCollectBuildingEarningsData);
			_modificationsCollectBuildingEarningsData.Reset();
			return offset9;
		}
		case 18:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 18))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 18);
			int offset6 = GameData.Serializer.Serializer.SerializeModifications(_shopManagerDict, dataPool, _modificationsShopManagerDict);
			_modificationsShopManagerDict.Reset();
			return offset6;
		}
		case 19:
			if (!BaseGameDataDomain.IsModified(DataStates, 19))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 19);
			return GameData.Serializer.Serializer.Serialize(_teaHorseCaravanData, dataPool);
		case 20:
			if (!BaseGameDataDomain.IsModified(DataStates, 20))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 20);
			return GameData.Serializer.Serializer.Serialize(_shrineBuyTimes, dataPool);
		case 21:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 21))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 21);
			int offset3 = GameData.Serializer.Serializer.SerializeModifications(_locationMarkHashSet, dataPool, _modificationsLocationMarkHashSet);
			_modificationsLocationMarkHashSet.Reset();
			return offset3;
		}
		case 22:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 23:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 24:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 25:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 25))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 25);
			int offset2 = GameData.Serializer.Serializer.SerializeModifications(_shopManagerUpgradeQualificationDict, dataPool, _modificationsShopManagerUpgradeQualificationDict);
			_modificationsShopManagerUpgradeQualificationDict.Reset();
			return offset2;
		}
		case 26:
			if (!BaseGameDataDomain.IsModified(DataStates, 26))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 26);
			return GameData.Serializer.Serializer.Serialize(_featherValue, dataPool);
		case 27:
			if (!BaseGameDataDomain.IsModified(DataStates, 27))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 27);
			return GameData.Serializer.Serializer.Serialize(_teaHorseCaravanEventCollection, dataPool);
		case 28:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 29:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
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
				_modificationsBuildingAreas.Reset();
			}
			break;
		case 1:
			if (BaseGameDataDomain.IsModified(DataStates, 1))
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
				_modificationsBuildingBlocks.Reset();
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
				_modificationsCollectBuildingResourceType.Reset();
			}
			break;
		case 4:
			if (BaseGameDataDomain.IsModified(DataStates, 4))
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
				_modificationsBuildingOperatorDict.Reset();
			}
			break;
		case 5:
			if (BaseGameDataDomain.IsModified(DataStates, 5))
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
				_modificationsCustomBuildingName.Reset();
			}
			break;
		case 6:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 7:
			if (BaseGameDataDomain.IsModified(DataStates, 7))
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
				_modificationsChicken.Reset();
			}
			break;
		case 8:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 9:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 10:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 11:
			if (BaseGameDataDomain.IsModified(DataStates, 11))
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
			}
			break;
		case 12:
			if (BaseGameDataDomain.IsModified(DataStates, 12))
			{
				BaseGameDataDomain.ResetModified(DataStates, 12);
			}
			break;
		case 13:
			if (BaseGameDataDomain.IsModified(DataStates, 13))
			{
				BaseGameDataDomain.ResetModified(DataStates, 13);
			}
			break;
		case 14:
			if (BaseGameDataDomain.IsModified(DataStates, 14))
			{
				BaseGameDataDomain.ResetModified(DataStates, 14);
			}
			break;
		case 15:
			if (BaseGameDataDomain.IsModified(_dataStatesSamsaraPlatformSlots, (int)subId0))
			{
				BaseGameDataDomain.ResetModified(_dataStatesSamsaraPlatformSlots, (int)subId0);
			}
			break;
		case 16:
			if (BaseGameDataDomain.IsModified(DataStates, 16))
			{
				BaseGameDataDomain.ResetModified(DataStates, 16);
				_modificationsSamsaraPlatformBornDict.Reset();
			}
			break;
		case 17:
			if (BaseGameDataDomain.IsModified(DataStates, 17))
			{
				BaseGameDataDomain.ResetModified(DataStates, 17);
				_modificationsCollectBuildingEarningsData.Reset();
			}
			break;
		case 18:
			if (BaseGameDataDomain.IsModified(DataStates, 18))
			{
				BaseGameDataDomain.ResetModified(DataStates, 18);
				_modificationsShopManagerDict.Reset();
			}
			break;
		case 19:
			if (BaseGameDataDomain.IsModified(DataStates, 19))
			{
				BaseGameDataDomain.ResetModified(DataStates, 19);
			}
			break;
		case 20:
			if (BaseGameDataDomain.IsModified(DataStates, 20))
			{
				BaseGameDataDomain.ResetModified(DataStates, 20);
			}
			break;
		case 21:
			if (BaseGameDataDomain.IsModified(DataStates, 21))
			{
				BaseGameDataDomain.ResetModified(DataStates, 21);
				_modificationsLocationMarkHashSet.Reset();
			}
			break;
		case 22:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 23:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 24:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 25:
			if (BaseGameDataDomain.IsModified(DataStates, 25))
			{
				BaseGameDataDomain.ResetModified(DataStates, 25);
				_modificationsShopManagerUpgradeQualificationDict.Reset();
			}
			break;
		case 26:
			if (BaseGameDataDomain.IsModified(DataStates, 26))
			{
				BaseGameDataDomain.ResetModified(DataStates, 26);
			}
			break;
		case 27:
			if (BaseGameDataDomain.IsModified(DataStates, 27))
			{
				BaseGameDataDomain.ResetModified(DataStates, 27);
			}
			break;
		case 28:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 29:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
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
			6 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			7 => BaseGameDataDomain.IsModified(DataStates, 7), 
			8 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			9 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			10 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			11 => BaseGameDataDomain.IsModified(DataStates, 11), 
			12 => BaseGameDataDomain.IsModified(DataStates, 12), 
			13 => BaseGameDataDomain.IsModified(DataStates, 13), 
			14 => BaseGameDataDomain.IsModified(DataStates, 14), 
			15 => BaseGameDataDomain.IsModified(_dataStatesSamsaraPlatformSlots, (int)subId0), 
			16 => BaseGameDataDomain.IsModified(DataStates, 16), 
			17 => BaseGameDataDomain.IsModified(DataStates, 17), 
			18 => BaseGameDataDomain.IsModified(DataStates, 18), 
			19 => BaseGameDataDomain.IsModified(DataStates, 19), 
			20 => BaseGameDataDomain.IsModified(DataStates, 20), 
			21 => BaseGameDataDomain.IsModified(DataStates, 21), 
			22 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			23 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			24 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			25 => BaseGameDataDomain.IsModified(DataStates, 25), 
			26 => BaseGameDataDomain.IsModified(DataStates, 26), 
			27 => BaseGameDataDomain.IsModified(DataStates, 27), 
			28 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			29 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
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
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
		case 22:
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
		case 28:
		case 29:
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
	}
}
