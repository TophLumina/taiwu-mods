using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Config;
using Config.ConfigCells;
using Config.ConfigCells.Character;
using GameData.Adventure;
using GameData.ArchiveData;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Common.Algorithm;
using GameData.Common.SingleValueCollection;
using GameData.DLC.FiveLoong;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Adventure;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.Filters;
using GameData.Domains.Character.ParallelModifications;
using GameData.Domains.Character.Relation;
using GameData.Domains.Combat;
using GameData.Domains.Extra;
using GameData.Domains.Global;
using GameData.Domains.Item;
using GameData.Domains.Item.Filters;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map.Filters;
using GameData.Domains.Map.TeammateBubble;
using GameData.Domains.Merchant;
using GameData.Domains.Organization;
using GameData.Domains.Organization.ParallelModifications;
using GameData.Domains.Taiwu;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.Taiwu.Profession.SkillsData;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World;
using GameData.Domains.World.Notification;
using GameData.Domains.World.TravelingEvent;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using NLog;
using Redzen.Random;

namespace GameData.Domains.Map;

[GameDataDomain(2)]
public class MapDomain : BaseGameDataDomain
{
	private enum EFilterRes
	{
		None,
		Fail,
		Success
	}

	public delegate bool ApplyPickupDelegate(DataContext context, MapPickup pickup);

	public delegate bool MapBlockDataFilter(MapBlockData blockData);

	public const sbyte RegularStateCount = 15;

	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[DomainData(DomainDataType.ElementList, true, false, true, false, ArrayElementsCount = 141)]
	private readonly MapAreaData[] _areas;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks0;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks1;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks2;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks3;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks4;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks5;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks6;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks7;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks8;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks9;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks10;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks11;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks12;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks13;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks14;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks15;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks16;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks17;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks18;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks19;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks20;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks21;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks22;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks23;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks24;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks25;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks26;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks27;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks28;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks29;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks30;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks31;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks32;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks33;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks34;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks35;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks36;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks37;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks38;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks39;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks40;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks41;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks42;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks43;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _areaBlocks44;

	private AreaBlockCollection[] _regularAreaBlocksArray;

	private Action<short, MapBlockData, DataContext>[] _regularAreaBlocksAddFuncs;

	private Action<short, MapBlockData, DataContext>[] _regularAreaBlocksSetFuncs;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _brokenAreaBlocks;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _bornAreaBlocks;

	[DomainData(DomainDataType.ElementList, true, false, true, false, ArrayElementsCount = 90)]
	private readonly BrokenAreaData[] _brokenAreaEnemies;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _guideAreaBlocks;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _secretVillageAreaBlocks;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _brokenPerformAreaBlocks;

	public const short StockadeInStoryNameId = -2;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _pastTaiwuVillageAreaBlocks;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private AreaBlockCollection _chaishanAreaBlocks;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private Dictionary<TravelRouteKey, TravelRoute> _travelRouteDict;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private Dictionary<TravelRouteKey, TravelRoute> _bornStateTravelRouteDict;

	[DomainData(DomainDataType.ElementList, true, false, true, false, ArrayElementsCount = 141)]
	private readonly CricketPlaceData[] _cricketPlaceData;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<short, GameData.Utilities.ShortList> _regularAreaNearList;

	[DomainData(DomainDataType.ElementList, true, false, true, true, ArrayElementsCount = 8)]
	private readonly Location[] _swordTombLocations;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private List<HunterAnimalKey> _hunterAnimals;

	public List<int> MapPickBattles = new List<int>();

	[DomainData(DomainDataType.ElementList, true, false, false, false, ArrayElementsCount = 10)]
	private readonly MapBlockFindData[] _mapBlockFindDataPresets;

	[Obsolete]
	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true, SkipLoad = true)]
	private readonly Dictionary<Location, int> _locationNaturalDisasterDate;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<Location, int> _locationNaturalDisasterDateNew;

	[DomainData(DomainDataType.SingleValue, false, true, true, true)]
	private List<LoongLocationData> _loongLocations;

	[DomainData(DomainDataType.SingleValue, false, true, true, true)]
	private List<Location> _fleeBeasts;

	[DomainData(DomainDataType.SingleValue, false, true, true, true)]
	private List<Location> _fleeLoongs;

	private readonly List<MapBlockDisplayData> _blockDisplayDataCache = new List<MapBlockDisplayData>();

	private readonly Dictionary<sbyte, TemplateKey> _forceCollectResourceItems = new Dictionary<sbyte, TemplateKey>();

	private Dictionary<sbyte, int> _forceCollectResourceAmounts = new Dictionary<sbyte, int>();

	public Location LastGetBlockDataPosition_Debug;

	private static AStarMap _aStarMap = new AStarMap();

	internal readonly HashSet<int> SearchedCharacter = new HashSet<int>();

	private readonly sbyte[] _stateBrokenAreaLevels = new sbyte[6] { 1, 2, 3, 4, 5, 6 };

	private static int _brokenAreaEnemyBaseCount;

	private const sbyte InitMaliceBlockPercent = 5;

	private Stopwatch _swCreatingNormalAreas;

	private Stopwatch _swCreatingSettlements;

	private Stopwatch _swInitializingAreaTravelRoutes;

	private static readonly Dictionary<MapPickup.EMapPickupType, ApplyPickupDelegate> ApplyPickups = new Dictionary<MapPickup.EMapPickupType, ApplyPickupDelegate>
	{
		{
			MapPickup.EMapPickupType.Resource,
			AddResourceByPickup
		},
		{
			MapPickup.EMapPickupType.Item,
			AddItemByPickup
		},
		{
			MapPickup.EMapPickupType.LoopEffect,
			LoopOnceByPickup
		},
		{
			MapPickup.EMapPickupType.ReadEffect,
			ReadOnceByPickup
		},
		{
			MapPickup.EMapPickupType.ExpBonus,
			AddExpByPickup
		},
		{
			MapPickup.EMapPickupType.DebtBonus,
			AddDebtByPickup
		}
	};

	[DomainData(DomainDataType.SingleValue, false, true, true, true)]
	private List<MapElementPickupDisplayData> _visibleMapPickups;

	private HashSet<Location> _wudangHeavenlyTrees = new HashSet<Location>();

	private HashSet<int> _fulongLightedBlocks = new HashSet<int>();

	[DomainData(DomainDataType.SingleValue, false, false, true, false)]
	private int _moveBanned;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _crossArchiveLockMoveTime;

	[Obsolete]
	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _pastTaiwuVillageLockMoveTime;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _isTaiwuInFulongFlameArea;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private HashSetAsDictionary<Location> _arrivedSize2Blocks;

	private Queue<Location> _taiwuMoveRecord = new Queue<Location>(3);

	private bool _teleportMove = false;

	private (int charId, int count) _lastTeammateBubble;

	private Location _lastTaiwuLocation;

	private bool _canTriggerFulongFlameTeammateBubble;

	private readonly List<(int charId, int index, int subtype)> _teammates = new List<(int, int, int)>();

	private readonly List<(int charId, int index, int subtype)> _teammateHighestPriorityText = new List<(int, int, int)>();

	private readonly Dictionary<int, int> _availableBubbleCache = new Dictionary<int, int>();

	private readonly Dictionary<ETeammateBubbleBubbleElementType, HashSet<short>> _elementTypeBubbleCache = new Dictionary<ETeammateBubbleBubbleElementType, HashSet<short>>();

	private int _teammateTypes;

	private const int AreaFindPathMultiplier = 1000;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private CrossAreaMoveInfo _travelInfo;

	private readonly DijkstraMap _dijkstraMap = new DijkstraMap();

	private int _carrierReduceTravelCostDaysPercent;

	private const int UnlockedRoutePenaltyDays = 1000;

	private bool _preferUnlockedTravelRoute;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _onHandlingTravelingEventBlock;

	private readonly List<(short, short)> _travelingEventWeights = new List<(short, short)>();

	[DomainData(DomainDataType.SingleValue, false, true, true, true)]
	private List<Location> _alterSettlementLocations;

	[DomainData(DomainDataType.ElementList, true, false, true, false, ArrayElementsCount = 15)]
	private readonly XiangshuInfectedDemonData[] _stateXiangshuInfectedDemons;

	private readonly Dictionary<int, sbyte> _xiangshuInfectedDemonsStateCache = new Dictionary<int, sbyte>();

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[76][];

	private static readonly DataInfluence[][] CacheInfluencesAreas = new DataInfluence[141][];

	private readonly byte[] _dataStatesAreas = new byte[36];

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks0 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks1 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks2 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks3 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks4 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks5 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks6 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks7 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks8 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks9 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks10 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks11 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks12 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks13 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks14 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks15 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks16 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks17 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks18 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks19 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks20 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks21 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks22 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks23 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks24 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks25 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks26 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks27 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks28 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks29 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks30 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks31 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks32 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks33 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks34 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks35 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks36 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks37 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks38 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks39 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks40 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks41 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks42 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks43 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaBlocks44 = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsBrokenAreaBlocks = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsBornAreaBlocks = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsGuideAreaBlocks = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsSecretVillageAreaBlocks = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsBrokenPerformAreaBlocks = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<TravelRouteKey> _modificationsTravelRouteDict = SingleValueCollectionModificationCollection<TravelRouteKey>.Create();

	private SingleValueCollectionModificationCollection<TravelRouteKey> _modificationsBornStateTravelRouteDict = SingleValueCollectionModificationCollection<TravelRouteKey>.Create();

	private static readonly DataInfluence[][] CacheInfluencesCricketPlaceData = new DataInfluence[141][];

	private readonly byte[] _dataStatesCricketPlaceData = new byte[36];

	private static readonly DataInfluence[][] CacheInfluencesSwordTombLocations = new DataInfluence[8][];

	private readonly byte[] _dataStatesSwordTombLocations = new byte[2];

	private SpinLock _spinLockFleeBeasts = new SpinLock(enableThreadOwnerTracking: false);

	private SpinLock _spinLockFleeLoongs = new SpinLock(enableThreadOwnerTracking: false);

	private SpinLock _spinLockLoongLocations = new SpinLock(enableThreadOwnerTracking: false);

	private SpinLock _spinLockAlterSettlementLocations = new SpinLock(enableThreadOwnerTracking: false);

	private SpinLock _spinLockVisibleMapPickups = new SpinLock(enableThreadOwnerTracking: false);

	private static readonly DataInfluence[][] CacheInfluencesBrokenAreaEnemies = new DataInfluence[90][];

	private readonly byte[] _dataStatesBrokenAreaEnemies = new byte[23];

	private static readonly DataInfluence[][] CacheInfluencesStateXiangshuInfectedDemons = new DataInfluence[15][];

	private readonly byte[] _dataStatesStateXiangshuInfectedDemons = new byte[4];

	private static readonly DataInfluence[][] CacheInfluencesMapBlockFindDataPresets = new DataInfluence[10][];

	private readonly byte[] _dataStatesMapBlockFindDataPresets = new byte[3];

	private SingleValueCollectionModificationCollection<short> _modificationsPastTaiwuVillageAreaBlocks = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsChaishanAreaBlocks = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<Location> _modificationsLocationNaturalDisasterDate = SingleValueCollectionModificationCollection<Location>.Create();

	private SingleValueCollectionModificationCollection<Location> _modificationsLocationNaturalDisasterDateNew = SingleValueCollectionModificationCollection<Location>.Create();

	public bool TempDisableTriggerNormalPickupByTaiwuEscape { get; set; }

	public Location TaiwuLastLocation { get; set; }

	public EMapBlockType LastLocationBlockType
	{
		get
		{
			MapBlockData data;
			return TryGetBlock(TaiwuLastLocation, out data) ? MapBlock.Instance[data.TemplateId].Type : EMapBlockType.Invalid;
		}
	}

	public bool LockTime { get; private set; }

	public bool IsTraveling => _travelInfo.Traveling;

	[Obsolete("just a hot fix, should be deleted")]
	[DataUpgrader(Version = "0.84.49", Date = "2026/06/09")]
	private void OpenWorldStateMonthlyReport(DataContext context)
	{
		DomainManager.World.SetWorldFunctionsStatus(context, 1);
	}

	[Obsolete("just a hot fix, should be deleted")]
	[DataUpgrader(Version = "1.0.10", Date = "2026/06/20")]
	private void TransferTreasuryResource(DataContext context)
	{
		DomainManager.Taiwu.TransferResource(context, ItemSourceType.Treasury, ItemSourceType.Inventory, 7, DomainManager.Taiwu.GetAllResources(ItemSourceType.Treasury).resource[7]);
	}

	[Obsolete("just a hot fix, should be deleted")]
	[DataUpgrader(Version = "0.84.64", Date = "2026/06/15")]
	private void FixMapBlockData(DataContext context)
	{
		for (short areaId = 0; areaId < 141; areaId++)
		{
			foreach (KeyValuePair<short, MapBlockData> block in GetAreaBlockCollection(areaId))
			{
				HashSet<int> set = block.Value.FixedCharacterSet;
				if (set == null)
				{
					continue;
				}
				short i = areaId;
				int[] arr = set.Where((int x) => DomainManager.Character.TryGetElement_Objects(x, out var element) && element.GetLocation() != new Location(i, block.Key)).ToArray();
				if (arr.Length != 0)
				{
					int[] array = arr;
					foreach (int c in array)
					{
						block.Value.FixedCharacterSet.Remove(c);
					}
					SetBlockData(context, block.Value);
				}
			}
		}
	}

	[Obsolete("just a hot fix, should be deleted")]
	[DataUpgrader(Version = "1.0.51", Date = "2026/07/07")]
	private void FixMapBlockData_Grave(DataContext context)
	{
		for (short areaId = 0; areaId < 141; areaId++)
		{
			foreach (KeyValuePair<short, MapBlockData> block in GetAreaBlockCollection(areaId))
			{
				HashSet<int> set = block.Value.GraveSet;
				if (set == null)
				{
					continue;
				}
				short i = areaId;
				int[] arr = set.Where((int x) => !DomainManager.Character.TryGetElement_Graves(x, out var _)).ToArray();
				if (arr.Length != 0)
				{
					int[] array = arr;
					foreach (int c in array)
					{
						block.Value.GraveSet.Remove(c);
					}
					SetBlockData(context, block.Value);
					AdaptableLog.Warning($"remove invalid grave: {string.Join(", ", arr)} at block {new Location(i, block.Key)}");
				}
			}
		}
	}

	[Obsolete("just a hot fix, incomplete, should be deleted ASAP")]
	[DataUpgrader(Version = "0.84.48", Date = "2026/06/07")]
	private void ComplementInitChaishan(DataContext context)
	{
		MapAreaData mapAreaData = _areas[140];
		if (mapAreaData != null && mapAreaData.StationUnlocked)
		{
			return;
		}
		_swCreatingNormalAreas = new Stopwatch();
		Dictionary<int, List<short>> blockTypeDict = new Dictionary<int, List<short>>();
		Dictionary<int, List<short>> blockSubTypeDict = new Dictionary<int, List<short>>();
		List<short> allBlockKeys = MapBlock.Instance.GetAllKeys();
		foreach (short t in allBlockKeys)
		{
			MapBlockItem blockConfig = MapBlock.Instance[t];
			int blockType = (int)blockConfig.Type;
			int blockSubType = (int)blockConfig.SubType;
			if (!blockTypeDict.ContainsKey(blockType))
			{
				blockTypeDict.Add(blockType, new List<short>());
			}
			blockTypeDict[blockType].Add(blockConfig.TemplateId);
			if (!blockSubTypeDict.ContainsKey(blockSubType))
			{
				blockSubTypeDict.Add(blockSubType, new List<short>());
			}
			blockSubTypeDict[blockSubType].Add(blockConfig.TemplateId);
		}
		GenerateChaishan(context, blockTypeDict, blockSubTypeDict);
		ClearTravelRouteDict(context);
		ClearRegularAreaNearList(context);
		InitAreaTravelRoute(context);
	}

	[DataUpgrader(Version = "0.84.49", Date = "2026/06/8")]
	private void ComplementInitPastTaiwuVillage(DataContext context)
	{
		if (_pastTaiwuVillageAreaBlocks == null)
		{
			_pastTaiwuVillageAreaBlocks = new AreaBlockCollection();
		}
		MapAreaData pastTaiwuVillageArea = _areas[139];
		if (pastTaiwuVillageArea.GetConfig().TemplateId != 138)
		{
			Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
			AreaBlockCollection areaBlockCollection = DomainManager.Map.GetAreaBlockCollection(taiwuVillageLocation.AreaId);
			pastTaiwuVillageArea.Init(138, 139);
			_pastTaiwuVillageAreaBlocks.Init(areaBlockCollection.Count);
			MapBlockData[] taiwuVillage = areaBlockCollection.GetArray();
			AreaBlockCollection pastTaiwu = GetAreaBlockCollection(139);
			for (short i = 0; i < taiwuVillage.Length; i++)
			{
				MapBlockData blockData = MapBlockData.SimpleClone(taiwuVillage[i]);
				blockData.AreaId = 139;
				pastTaiwu.Add(blockData.BlockId, blockData);
			}
			MapAreaData taiwuAreaData = GetElement_Areas(taiwuVillageLocation.AreaId);
			pastTaiwuVillageArea.Discovered = true;
			pastTaiwuVillageArea.StationUnlocked = true;
			pastTaiwuVillageArea.SettlementInfos = taiwuAreaData.SettlementInfos.ToArray();
			pastTaiwuVillageArea.StationBlockId = taiwuAreaData.StationBlockId;
			_areas[139] = pastTaiwuVillageArea;
		}
	}

	private void OnInitializedDomainData()
	{
		for (int i = 0; i < 141; i++)
		{
			_areas[i] = new MapAreaData();
		}
		for (int stateId = 0; stateId < 15; stateId++)
		{
			_stateXiangshuInfectedDemons[stateId] = new XiangshuInfectedDemonData();
		}
		InitRegularBlockArrayAndFuncs();
		TaiwuLastLocation = Location.Invalid;
	}

	private void InitializeOnInitializeGameDataModule()
	{
	}

	private void InitializeOnEnterNewWorld()
	{
		Events.RegisterHandler_CharacterLocationChanged(OnCharacterLocationChanged);
		InitializeTeammateBubble();
		InitializeBrokenAreaEnemies();
	}

	private void OnLoadedArchiveData()
	{
		for (short areaId = 0; areaId < 45; areaId++)
		{
			_regularAreaBlocksArray[areaId].ConvertToRegularCollection();
		}
		_brokenAreaBlocks.ConvertToRegularCollection();
		_bornAreaBlocks.ConvertToRegularCollection();
		_guideAreaBlocks.ConvertToRegularCollection();
		_secretVillageAreaBlocks.ConvertToRegularCollection();
		_brokenPerformAreaBlocks.ConvertToRegularCollection();
		_pastTaiwuVillageAreaBlocks.ConvertToRegularCollection();
		_chaishanAreaBlocks.ConvertToRegularCollection();
		for (short areaId2 = 0; areaId2 < 141; areaId2++)
		{
			Span<MapBlockData> blocks = GetAreaBlocks(areaId2);
			for (short blockId = 0; blockId < blocks.Length; blockId++)
			{
				MapBlockData blockData = blocks[blockId];
				if (blockData.RootBlockId >= 0)
				{
					MapBlockData rootBlock = blocks[blockData.RootBlockId];
					MapBlockData mapBlockData = rootBlock;
					if (mapBlockData.GroupBlockList == null)
					{
						mapBlockData.GroupBlockList = new List<MapBlockData>();
					}
					if (!rootBlock.GroupBlockList.Contains(blockData))
					{
						rootBlock.GroupBlockList.Add(blockData);
					}
				}
			}
		}
		Events.RegisterHandler_CharacterLocationChanged(OnCharacterLocationChanged);
		InitializeTravelMap();
		InitializeTeammateBubble();
		InitializeXiangshuInfectedDemonsAreaCache();
	}

	public AreaBlockCollection GetAreaBlockCollection(short areaId)
	{
		if (1 == 0)
		{
		}
		AreaBlockCollection result = ((areaId < 45) ? _regularAreaBlocksArray[areaId] : ((areaId < 135) ? _brokenAreaBlocks : (areaId switch
		{
			135 => _bornAreaBlocks, 
			136 => _guideAreaBlocks, 
			137 => _secretVillageAreaBlocks, 
			138 => _brokenPerformAreaBlocks, 
			139 => _pastTaiwuVillageAreaBlocks, 
			140 => _chaishanAreaBlocks, 
			_ => throw new Exception($"Invalid area id: {areaId}"), 
		})));
		if (1 == 0)
		{
		}
		return result;
	}

	public void AddRegularBlockData(DataContext context, Location blockKey, MapBlockData data)
	{
		_regularAreaBlocksAddFuncs[blockKey.AreaId](blockKey.BlockId, data, context);
	}

	public void SetRegularBlockData(DataContext context, MapBlockData block)
	{
		_regularAreaBlocksSetFuncs[block.AreaId](block.BlockId, block, context);
	}

	private void InitRegularBlockArrayAndFuncs()
	{
		_regularAreaBlocksArray = new AreaBlockCollection[45]
		{
			_areaBlocks0, _areaBlocks1, _areaBlocks2, _areaBlocks3, _areaBlocks4, _areaBlocks5, _areaBlocks6, _areaBlocks7, _areaBlocks8, _areaBlocks9,
			_areaBlocks10, _areaBlocks11, _areaBlocks12, _areaBlocks13, _areaBlocks14, _areaBlocks15, _areaBlocks16, _areaBlocks17, _areaBlocks18, _areaBlocks19,
			_areaBlocks20, _areaBlocks21, _areaBlocks22, _areaBlocks23, _areaBlocks24, _areaBlocks25, _areaBlocks26, _areaBlocks27, _areaBlocks28, _areaBlocks29,
			_areaBlocks30, _areaBlocks31, _areaBlocks32, _areaBlocks33, _areaBlocks34, _areaBlocks35, _areaBlocks36, _areaBlocks37, _areaBlocks38, _areaBlocks39,
			_areaBlocks40, _areaBlocks41, _areaBlocks42, _areaBlocks43, _areaBlocks44
		};
		_regularAreaBlocksAddFuncs = new Action<short, MapBlockData, DataContext>[45]
		{
			AddElement_AreaBlocks0, AddElement_AreaBlocks1, AddElement_AreaBlocks2, AddElement_AreaBlocks3, AddElement_AreaBlocks4, AddElement_AreaBlocks5, AddElement_AreaBlocks6, AddElement_AreaBlocks7, AddElement_AreaBlocks8, AddElement_AreaBlocks9,
			AddElement_AreaBlocks10, AddElement_AreaBlocks11, AddElement_AreaBlocks12, AddElement_AreaBlocks13, AddElement_AreaBlocks14, AddElement_AreaBlocks15, AddElement_AreaBlocks16, AddElement_AreaBlocks17, AddElement_AreaBlocks18, AddElement_AreaBlocks19,
			AddElement_AreaBlocks20, AddElement_AreaBlocks21, AddElement_AreaBlocks22, AddElement_AreaBlocks23, AddElement_AreaBlocks24, AddElement_AreaBlocks25, AddElement_AreaBlocks26, AddElement_AreaBlocks27, AddElement_AreaBlocks28, AddElement_AreaBlocks29,
			AddElement_AreaBlocks30, AddElement_AreaBlocks31, AddElement_AreaBlocks32, AddElement_AreaBlocks33, AddElement_AreaBlocks34, AddElement_AreaBlocks35, AddElement_AreaBlocks36, AddElement_AreaBlocks37, AddElement_AreaBlocks38, AddElement_AreaBlocks39,
			AddElement_AreaBlocks40, AddElement_AreaBlocks41, AddElement_AreaBlocks42, AddElement_AreaBlocks43, AddElement_AreaBlocks44
		};
		_regularAreaBlocksSetFuncs = new Action<short, MapBlockData, DataContext>[45]
		{
			SetElement_AreaBlocks0, SetElement_AreaBlocks1, SetElement_AreaBlocks2, SetElement_AreaBlocks3, SetElement_AreaBlocks4, SetElement_AreaBlocks5, SetElement_AreaBlocks6, SetElement_AreaBlocks7, SetElement_AreaBlocks8, SetElement_AreaBlocks9,
			SetElement_AreaBlocks10, SetElement_AreaBlocks11, SetElement_AreaBlocks12, SetElement_AreaBlocks13, SetElement_AreaBlocks14, SetElement_AreaBlocks15, SetElement_AreaBlocks16, SetElement_AreaBlocks17, SetElement_AreaBlocks18, SetElement_AreaBlocks19,
			SetElement_AreaBlocks20, SetElement_AreaBlocks21, SetElement_AreaBlocks22, SetElement_AreaBlocks23, SetElement_AreaBlocks24, SetElement_AreaBlocks25, SetElement_AreaBlocks26, SetElement_AreaBlocks27, SetElement_AreaBlocks28, SetElement_AreaBlocks29,
			SetElement_AreaBlocks30, SetElement_AreaBlocks31, SetElement_AreaBlocks32, SetElement_AreaBlocks33, SetElement_AreaBlocks34, SetElement_AreaBlocks35, SetElement_AreaBlocks36, SetElement_AreaBlocks37, SetElement_AreaBlocks38, SetElement_AreaBlocks39,
			SetElement_AreaBlocks40, SetElement_AreaBlocks41, SetElement_AreaBlocks42, SetElement_AreaBlocks43, SetElement_AreaBlocks44
		};
	}

	public void GetPassableBlocksInArea(short areaId, List<MapBlockData> result)
	{
		result.Clear();
		Span<MapBlockData> areaBlocks = GetAreaBlocks(areaId);
		Span<MapBlockData> span = areaBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData block = span[i];
			if (block.IsPassable())
			{
				result.Add(block);
			}
		}
	}

	public Span<MapBlockData> GetAreaBlocks(short areaId)
	{
		if (MapAreaData.IsBrokenArea(areaId))
		{
			MapBlockData[] allBrokenAreaBlocks = _brokenAreaBlocks.GetArray();
			if (allBrokenAreaBlocks.Length == 0)
			{
				return new Span<MapBlockData>(allBrokenAreaBlocks, 0, 0);
			}
			int blockPerArea = 25;
			int blockIdBegin = (short)(blockPerArea * (areaId - 45));
			return new Span<MapBlockData>(allBrokenAreaBlocks, blockIdBegin, blockPerArea);
		}
		AreaBlockCollection blockCollection = GetAreaBlockCollection(areaId);
		return new Span<MapBlockData>(blockCollection.GetArray());
	}

	public void SetBlockData(DataContext context, MapBlockData block)
	{
		short areaId = block.AreaId;
		short num = areaId;
		if (num >= 45)
		{
			if (num >= 135)
			{
				switch (num)
				{
				case 135:
					SetElement_BornAreaBlocks(block.BlockId, block, context);
					break;
				case 136:
					SetElement_GuideAreaBlocks(block.BlockId, block, context);
					break;
				case 137:
					SetElement_SecretVillageAreaBlocks(block.BlockId, block, context);
					break;
				case 138:
					SetElement_BrokenPerformAreaBlocks(block.BlockId, block, context);
					break;
				case 139:
					SetElement_PastTaiwuVillageAreaBlocks(block.BlockId, block, context);
					break;
				case 140:
					SetElement_ChaishanAreaBlocks(block.BlockId, block, context);
					break;
				default:
					throw new Exception($"Invalid area id: {block.AreaId}");
				}
			}
			else
			{
				short blockId = (short)(25 * (block.AreaId - 45) + block.BlockId);
				SetElement_BrokenAreaBlocks(blockId, block, context);
			}
		}
		else
		{
			SetRegularBlockData(context, block);
		}
	}

	public void OnCharacterLocationChanged(DataContext context, int charId, Location srcLocation, Location destLocation)
	{
		if (srcLocation.IsValid())
		{
			MapBlockData block = GetBlock(srcLocation);
			if (block.RemoveCharacter(charId))
			{
				SetBlockData(context, block);
			}
		}
		if (destLocation.IsValid())
		{
			MapBlockData block2 = GetBlock(destLocation);
			block2.AddCharacter(charId);
			SetBlockData(context, block2);
			DomainManager.Taiwu.CheckNotTaiwu(charId);
		}
	}

	public void OnInfectedCharacterLocationChanged(DataContext context, int charId, Location srcLocation, Location destLocation)
	{
		if (srcLocation.IsValid())
		{
			MapBlockData block = GetBlock(srcLocation);
			if (block.RemoveInfectedCharacter(charId))
			{
				SetBlockData(context, block);
			}
		}
		if (destLocation.IsValid())
		{
			MapBlockData block2 = GetBlock(destLocation);
			block2.AddInfectedCharacter(charId);
			SetBlockData(context, block2);
			DomainManager.Taiwu.CheckNotTaiwu(charId);
		}
	}

	public void OnFixedCharacterLocationChanged(DataContext context, int charId, Location srcLocation, Location destLocation)
	{
		if (srcLocation.IsValid())
		{
			MapBlockData block = GetBlock(srcLocation);
			if (block.RemoveFixedCharacter(charId))
			{
				SetBlockData(context, block);
			}
		}
		if (destLocation.IsValid())
		{
			MapBlockData block2 = GetBlock(destLocation);
			block2.AddFixedCharacter(charId);
			SetBlockData(context, block2);
			SetBlockAndViewRangeVisible(context, destLocation.AreaId, destLocation.BlockId);
		}
	}

	public void OnEnemyCharacterLocationChanged(DataContext context, int charId, Location srcLocation, Location destLocation)
	{
		if (srcLocation.IsValid())
		{
			MapBlockData block = GetBlock(srcLocation);
			if (block.RemoveEnemyCharacter(charId))
			{
				SetBlockData(context, block);
			}
		}
		if (destLocation.IsValid())
		{
			MapBlockData block2 = GetBlock(destLocation);
			block2.AddEnemyCharacter(charId);
			SetBlockData(context, block2);
		}
	}

	public void OnGraveLocationChanged(DataContext context, int charId, Location srcLocation, Location destLocation)
	{
		if (srcLocation.IsValid())
		{
			MapBlockData block = GetBlock(srcLocation);
			if (block.RemoveGrave(charId))
			{
				SetBlockData(context, block);
			}
		}
		if (destLocation.IsValid())
		{
			MapBlockData block2 = GetBlock(destLocation);
			block2.AddGrave(charId);
			SetBlockData(context, block2);
		}
	}

	public void OnTemplateEnemyLocationChanged(DataContext context, MapTemplateEnemyInfo templateEnemyInfo, Location srcLocation, Location destLocation)
	{
		if (srcLocation.IsValid())
		{
			MapBlockData block = GetBlock(srcLocation);
			if (block.RemoveTemplateEnemy(templateEnemyInfo))
			{
				SetBlockData(context, block);
			}
			if (templateEnemyInfo.SourceType == 3)
			{
				sbyte stateId = GetStateIdByAreaId(srcLocation.AreaId);
				XiangshuInfectedDemonData xiangshuInfectedDemon = _stateXiangshuInfectedDemons[stateId];
				if (xiangshuInfectedDemon.RemoveMinion(srcLocation.AreaId, templateEnemyInfo))
				{
					SetElement_StateXiangshuInfectedDemons(stateId, xiangshuInfectedDemon, context);
				}
			}
		}
		if (destLocation.IsValid())
		{
			MapBlockData block2 = GetBlock(destLocation);
			templateEnemyInfo.BlockId = destLocation.BlockId;
			MapTemplateEnemyInfo templateEnemy = new MapTemplateEnemyInfo(templateEnemyInfo.TemplateId, destLocation.BlockId, templateEnemyInfo.SourceType, templateEnemyInfo.SourceAdventureBlockId, templateEnemyInfo.Duration);
			block2.AddTemplateEnemy(templateEnemy);
			SetBlockData(context, block2);
			if (templateEnemyInfo.SourceType == 3)
			{
				sbyte stateId2 = GetStateIdByAreaId(destLocation.AreaId);
				XiangshuInfectedDemonData xiangshuInfectedDemon2 = _stateXiangshuInfectedDemons[stateId2];
				xiangshuInfectedDemon2.AddMinion(destLocation.AreaId, templateEnemyInfo);
				SetElement_StateXiangshuInfectedDemons(stateId2, xiangshuInfectedDemon2, context);
			}
		}
	}

	public int GetStationUnlockedRegularAreaCount()
	{
		int count = 0;
		for (short areaId = 0; areaId < 45; areaId++)
		{
			if (_areas[areaId].StationUnlocked)
			{
				count++;
			}
		}
		return count;
	}

	private void UpdateLocationNaturalDisasterDate(DataContext context, Location location, int date)
	{
		if (TryGetElement_LocationNaturalDisasterDateNew(location, out var _))
		{
			SetElement_LocationNaturalDisasterDateNew(location, date, context);
		}
		else
		{
			AddElement_LocationNaturalDisasterDateNew(location, date, context);
		}
	}

	private bool LocationCanTriggerNaturalDisaster(DataContext context, Location location)
	{
		if (TryGetElement_LocationNaturalDisasterDateNew(location, out var date))
		{
			return date + GlobalConfig.Instance.LocationNaturalDisasterDuration < DomainManager.World.GetCurrDate();
		}
		return true;
	}

	[SingleValueCollectionDependency(19, new ushort[] { 95 })]
	private void CalcLoongLocations(List<LoongLocationData> value)
	{
		value.Clear();
		foreach (LoongInfo loongInfo in DomainManager.Extra.FiveLoongDict.Values)
		{
			if (!loongInfo.IsDisappear)
			{
				value.Add(new LoongLocationData(loongInfo));
			}
		}
	}

	[SingleValueCollectionDependency(19, new ushort[] { 111 })]
	private void CalcFleeBeasts(List<Location> value)
	{
		value.Clear();
		foreach (Location location in DomainManager.Extra.GetAllFleeBeastLocations())
		{
			if (!value.Contains(location))
			{
				value.Add(location);
			}
		}
	}

	[SingleValueCollectionDependency(19, new ushort[] { 111 })]
	private void CalcFleeLoongs(List<Location> value)
	{
		value.Clear();
		foreach (Location location in DomainManager.Extra.GetAllFleeJiaoLoongLocations())
		{
			if (!value.Contains(location))
			{
				value.Add(location);
			}
		}
	}

	[SingleValueCollectionDependency(19, new ushort[] { 194 })]
	private void CalcAlterSettlementLocations(List<Location> value)
	{
		value.Clear();
		foreach (short settlementId in DomainManager.Extra.GetAllAlteredSettlementIds())
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
			value.Add(settlement.GetLocation());
		}
	}

	[SingleValueCollectionDependency(19, new ushort[] { 173 })]
	[SingleValueCollectionDependency(1, new ushort[] { 1 })]
	[SingleValueCollectionDependency(1, new ushort[] { 26 })]
	[ObjectCollectionDependency(4, 0, new ushort[] { 46 }, Condition = InfluenceCondition.CharIsTaiwu)]
	[SingleValueCollectionDependency(5, new ushort[] { 43 })]
	private void CalcVisibleMapPickups(List<MapElementPickupDisplayData> value)
	{
		value.Clear();
		foreach (MapPickupCollection collection in DomainManager.Extra.PickupDict.Values)
		{
			if (collection != null && collection.Count > 0)
			{
				List<MapPickup> pickups = collection.Where(MapPickupHelper.IsVisible).ToList();
				pickups.Sort(MapPickupHelper.CompareVisiblePickups);
				value.AddRange(pickups.Select(GetPickupDisplayData));
			}
		}
	}

	public void AddHunterAnimal(DataContext context, short areaId, short blockId, short animalId)
	{
		_hunterAnimals.Add(new HunterAnimalKey(areaId, blockId, animalId));
		SetHunterAnimals(_hunterAnimals, context);
	}

	public void MoveHunterAnimal(DataContext context, Location before, Location after, short animalId)
	{
		HunterAnimalKey beforeAnimal = new HunterAnimalKey(before.AreaId, before.BlockId, animalId);
		if (_hunterAnimals.Contains(beforeAnimal))
		{
			_hunterAnimals.Remove(beforeAnimal);
			HunterAnimalKey afterAnimal = new HunterAnimalKey(after.AreaId, after.BlockId, animalId);
			_hunterAnimals.Add(afterAnimal);
			SetHunterAnimals(_hunterAnimals, context);
		}
	}

	public void RemoveHunterAnimal(DataContext context, Location location, short animalId)
	{
		HunterAnimalKey animal = new HunterAnimalKey(location.AreaId, location.BlockId, animalId);
		if (_hunterAnimals.Contains(animal))
		{
			_hunterAnimals.Remove(animal);
			SetHunterAnimals(_hunterAnimals, context);
		}
	}

	public void ClearHunterAnim(DataContext context)
	{
		if (_hunterAnimals.Count != 0)
		{
			_hunterAnimals.Clear();
			SetHunterAnimals(_hunterAnimals, context);
		}
	}

	private static void AddAnimalProfessionSeniority(DataContext context, Location destLocation)
	{
		if (!DomainManager.Extra.TryGetElement_TaiwuProfessions(1, out var _) || !destLocation.IsValid() || !DomainManager.Extra.TryGetAnimalsByLocation(destLocation, out var animals))
		{
			return;
		}
		ProfessionFormulaItem formula = ProfessionFormula.Instance[8];
		foreach (GameData.Domains.Character.Animal animal in animals)
		{
			if (DomainManager.Extra.TryTriggerAddSeniorityPoint(context, formula.TemplateId, animal.Id))
			{
				sbyte consummateLevel = Config.Character.Instance[animal.CharacterTemplateId].ConsummateLevel;
				int addSeniority = formula.Calculate(consummateLevel);
				DomainManager.Extra.ChangeProfessionSeniority(context, 1, addSeniority);
			}
		}
	}

	[DomainMethod]
	public AreaDisplayData[] GetAllAreaDisplayData()
	{
		AreaDisplayData[] ret = new AreaDisplayData[141];
		for (short areaId = 0; areaId < 135; areaId++)
		{
			ret[areaId] = GetAreaDisplayData(areaId);
		}
		ret[140] = GetAreaDisplayData(140);
		foreach (TwelveImmortalsItem cfg in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
		{
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(cfg.Character, out var ch))
			{
				Location loc = ch.GetLocation();
				if (loc.IsValid())
				{
					NameAndAvatar data = new NameAndAvatar
					{
						Avatar = ch.GenerateAvatarRelatedData(),
						CharId = ch.GetId(),
						IsTaiwu = false
					};
					CharacterDomain.GetNameRelatedData(ch, ref data.Name);
					ret[loc.AreaId].TwelveImmortal = data;
				}
			}
		}
		if (DomainManager.Story.GetTaiwuAsXiangshuEntered())
		{
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(1340, out var longyufu))
			{
				Location loc2 = longyufu.GetLocation();
				if (loc2.IsValid())
				{
					NameAndAvatar data2 = new NameAndAvatar
					{
						Avatar = longyufu.GenerateAvatarRelatedData(),
						CharId = longyufu.GetId(),
						IsTaiwu = false
					};
					CharacterDomain.GetNameRelatedData(longyufu, ref data2.Name);
					ret[loc2.AreaId].TaiwuAsXiangshuLongYufu = data2;
				}
			}
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(1341, out var ziwuxiao))
			{
				Location loc3 = ziwuxiao.GetLocation();
				if (loc3.IsValid())
				{
					NameAndAvatar data3 = new NameAndAvatar
					{
						Avatar = ziwuxiao.GenerateAvatarRelatedData(),
						CharId = ziwuxiao.GetId(),
						IsTaiwu = false
					};
					CharacterDomain.GetNameRelatedData(ziwuxiao, ref data3.Name);
					ret[loc3.AreaId].TaiwuAsXiangshuZiWuxiao = data3;
				}
			}
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(1342, out var ranchenzi))
			{
				Location loc4 = ranchenzi.GetLocation();
				if (loc4.IsValid())
				{
					NameAndAvatar data4 = new NameAndAvatar
					{
						Avatar = ranchenzi.GenerateAvatarRelatedData(),
						CharId = ranchenzi.GetId(),
						IsTaiwu = false
					};
					CharacterDomain.GetNameRelatedData(ranchenzi, ref data4.Name);
					ret[loc4.AreaId].TaiwuAsXiangshuRanchenzi = data4;
				}
			}
		}
		return ret;
	}

	internal AreaDisplayData GetAreaDisplayData(short areaId)
	{
		List<GameData.Domains.Character.Character> cache = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		cache.Clear();
		MapCharacterFilter.FindInfected(CharacterMatchers.MatchCompletelyInfected, cache, areaId);
		int infectedCount = cache.Count;
		cache.Clear();
		MapCharacterFilter.Find(delegate(GameData.Domains.Character.Character ch)
		{
			sbyte legendaryBookOwnerState = ch.GetLegendaryBookOwnerState();
			return legendaryBookOwnerState >= 0 && legendaryBookOwnerState <= 2;
		}, cache, areaId, includeInfected: true);
		int legendaryBookOwnerCount = cache.Count;
		cache.Clear();
		MapCharacterFilter.Find(CharacterMatchers.MatchNotTaiwuOwnedLegendaryBook, cache, areaId, includeInfected: true);
		int legendaryBookConsumedCount = cache.Count - legendaryBookOwnerCount;
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(cache);
		sbyte stateId = GetStateIdByAreaId(areaId);
		XiangshuInfectedDemonData demonData = ((stateId < 0) ? XiangshuInfectedDemonData.Invalid : GetElement_StateXiangshuInfectedDemons(stateId));
		GameData.Domains.Character.Character character;
		bool anyInfectedDemon = DomainManager.Character.TryGetElement_Objects(demonData.CharId, out character) && character.GetValidLocation().AreaId == areaId;
		AreaDisplayData displayData = new AreaDisplayData
		{
			IsUnlocked = StationUnlocked(areaId),
			IsBroken = (areaId >= 45),
			AllActivatedAdventureOrMajorEventCoreIds = new List<int>(DomainManager.Adventure.QueryAllActivatedCoreIds(areaId)),
			_loongStatusInternal = DomainManager.Extra.GetAreaLoongStatus(areaId),
			AnyFleeBeast = GetFleeBeasts().Any((Location x) => x.AreaId == areaId),
			BrokenLevel = QueryAreaBrokenLevel(areaId),
			PurpleBamboos = GetPurpleBambooNameAndAvatar(areaId).ToArray(),
			SpecialNpc = GetNonPurpleBambooNameAndAvatar(areaId).ToArray(),
			HasSectZhujianSpecialMerchant = (DomainManager.Taiwu.GetAreaMerchantInfo(areaId).merchantSourceType == OpenShopEventArguments.EMerchantSourceType.SpecialBuilding),
			SettlementDisplayData = (from x in GetAreaByAreaId(areaId).SettlementInfos
				where x.SettlementId != -1
				select DomainManager.Organization.GetDisplayData(x.SettlementId)).ToArray(),
			MigratableBlocks = DomainManager.Map.GetAreaBlocks(areaId).ToArray().Aggregate(new int[6], delegate(int[] ints, MapBlockData data)
			{
				for (int j = 0; j < 6; j++)
				{
					if (data.CanBeFarmerMigrateTarget((sbyte)j))
					{
						ints[j]++;
					}
				}
				return ints;
			})
		};
		displayData.AdventureNameAndDuration = (from x in displayData.AllActivatedAdventureOrMajorEventCoreIds.Where((int x) => !XiangshuAvatarIds.IsSwordTombAdventure(x)).Select(AdventureDomain.Core.GetAdventureAny).Where(delegate(IAdventureData x)
			{
				IReadOnlyList<EAdventureTag> readOnlyList = x?.Tags;
				return readOnlyList == null || (!readOnlyList.Contains(EAdventureTag.MainStory) && !readOnlyList.Contains(EAdventureTag.SectStory));
			})
			orderby x.Name, x.StayMonths
			select new AdventureNameAndDurationDisplayData(x.Name, x.StayMonths)).ToArray();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		dictionary[0] = Counter((int x) => AdventureDomain.Core.GetAdventureAny(x)?.Tags.Contains(EAdventureTag.MainStory) ?? false);
		dictionary[1] = Counter((int x) => AdventureDomain.Core.GetAdventureAny(x)?.Tags.Contains(EAdventureTag.SectStory) ?? false);
		dictionary[21] = Counter(XiangshuAvatarIds.IsSwordTombAdventure);
		dictionary[22] = Counter((int x) => AdventureDomain.Core.TryGetAdventureMajorEventData(x, out var _));
		dictionary[8] = displayData.AdventureNameAndDuration.Length;
		dictionary[2] = legendaryBookOwnerCount;
		dictionary[23] = legendaryBookConsumedCount;
		dictionary[3] = (displayData.AnyLoong ? (-1) : 0);
		dictionary[4] = displayData.PurpleBamboos.Length;
		dictionary[24] = displayData.SpecialNpc.Length;
		dictionary[5] = Math.Max(infectedCount + (anyInfectedDemon ? (-1) : 0), 0);
		dictionary[17] = (anyInfectedDemon ? (-1) : 0);
		dictionary[6] = DomainManager.Extra.GetAreaPastLifeRelationCount(areaId);
		dictionary[7] = (GetFleeLoongs().Any((Location x) => x.AreaId == areaId) ? (-1) : 0);
		dictionary[20] = (GetFleeBeasts().Any((Location x) => x.AreaId == areaId) ? (-1) : 0);
		Dictionary<int, int> dict = dictionary;
		int count = dict.Keys.Prepend(-1).Max() + 1;
		displayData.States = new List<int>(count);
		for (int i = 0; i < count; i++)
		{
			displayData.States.Add(dict.GetValueOrDefault(i));
		}
		displayData.HasSectExam = displayData.AllActivatedAdventureOrMajorEventCoreIds.Any((int x) => (AdventureDomain.Core.GetAdventureAny(x)?.Tags)?.Contains(EAdventureTag.SectCompetition) ?? false);
		return displayData;
		int Counter(Func<int, bool> filter)
		{
			return displayData.AllActivatedAdventureOrMajorEventCoreIds.Count(filter);
		}
	}

	[DomainMethod]
	public List<MapBlockDisplayData> GetBlockDisplayDataInArea(short areaId)
	{
		Span<MapBlockData> blocks = GetAreaBlocks(areaId);
		_blockDisplayDataCache.Clear();
		_blockDisplayDataCache.EnsureCapacity(blocks.Length);
		List<GameData.Domains.Character.Character> characterCache = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		for (int i = 0; i < blocks.Length; i++)
		{
			MapBlockData block = blocks[i];
			MapBlockDisplayData displayData = GetMapBlockDisplayData(block.GetLocation(), -1, characterCache);
			_blockDisplayDataCache.Add(displayData);
		}
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(characterCache);
		return _blockDisplayDataCache;
	}

	private MapBlockDisplayData GetMapBlockDisplayData(Location location, int professionId, List<GameData.Domains.Character.Character> characters)
	{
		MapBlockDisplayData data = new MapBlockDisplayData
		{
			TreasureExpect = DomainManager.Extra.FindTreasureExpect(location),
			ProfessionId = professionId,
			Count0 = 0,
			Count1 = 0,
			Count2 = 0
		};
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		MapBlockData block = DomainManager.Map.GetBlock(location.AreaId, location.BlockId);
		switch (professionId)
		{
		case 0:
			data.Count0 = (block.Destroyed ? 1 : 0);
			break;
		case 1:
			data.Count0 = DomainManager.Extra.QueryAnimalCount(location);
			break;
		case 5:
			QueryCharacters(expectInfected: false);
			foreach (GameData.Domains.Character.Character character3 in characters)
			{
				List<short> featureIds = character3.GetFeatureIds();
				if (featureIds.Contains(210))
				{
					data.Count0++;
				}
				else if (featureIds.Contains(211))
				{
					data.Count1++;
				}
			}
			break;
		case 10:
			foreach (int charId2 in IterCharIds())
			{
				HashSet<int> characterSet = DomainManager.Character.GetRelatedCharIds(charId2, 32768);
				if (characterSet.Contains(taiwuCharId))
				{
					data.Count0++;
				}
			}
			break;
		case 12:
			QueryCharacters();
			foreach (GameData.Domains.Character.Character character2 in characters)
			{
				switch (character2.GetBehaviorType())
				{
				case 3:
					data.Count0++;
					break;
				case 4:
					data.Count1++;
					break;
				}
			}
			break;
		case 13:
			QueryCharacters();
			foreach (GameData.Domains.Character.Character character in characters)
			{
				if (character.GetInjuries().HasAnyInjury())
				{
					data.Count0++;
				}
				PoisonInts poisoned = character.GetPoisoned();
				if (poisoned.IsNonZero())
				{
					data.Count1++;
				}
				if (character.GetDisorderOfQi() > 0)
				{
					data.Count2++;
				}
			}
			break;
		case 17:
			foreach (int charId in IterCharIds(expectInfected: false))
			{
				if (ProfessionSkillHandle.DukeSkill_CheckCharacterHasTitle(charId))
				{
					data.Count0++;
				}
			}
			break;
		}
		return data;
		IEnumerable<int> IterCharIds(bool expectInfected = true)
		{
			if (block.CharacterSet != null)
			{
				foreach (int item in block.CharacterSet)
				{
					yield return item;
				}
				if (!(block.InfectedCharacterSet == null || expectInfected))
				{
					foreach (int item2 in block.InfectedCharacterSet)
					{
						yield return item2;
					}
				}
			}
		}
		void QueryCharacters(bool expectInfected = true)
		{
			characters.Clear();
			foreach (int charId3 in IterCharIds(expectInfected))
			{
				if (DomainManager.Character.TryGetElement_Objects(charId3, out var character4))
				{
					characters.Add(character4);
				}
			}
		}
	}

	[DomainMethod]
	public int[] GetAllAreaCompletelyInfectedCharCount()
	{
		List<GameData.Domains.Character.Character> charList = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		int[] result = new int[135];
		for (short areaId = 0; areaId < 135; areaId++)
		{
			charList.Clear();
			MapCharacterFilter.FindInfected(CharacterMatchers.MatchCompletelyInfected, charList, areaId);
			result[areaId] = charList.Count;
		}
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(charList);
		return result;
	}

	[DomainMethod]
	public int[] GetAllStateCompletelyInfectedCharCount()
	{
		List<GameData.Domains.Character.Character> charList = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		int[] result = new int[15];
		for (sbyte stateId = 0; stateId < 15; stateId++)
		{
			charList.Clear();
			MapCharacterFilter.FindStateInfected(CharacterMatchers.MatchCompletelyInfected, charList, stateId);
			result[stateId] = charList.Count;
		}
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(charList);
		return result;
	}

	[DomainMethod]
	public Dictionary<TravelRouteKey, TravelRoute> GetTravelRoutesInState(sbyte stateId)
	{
		if (stateId < 0)
		{
			return null;
		}
		Dictionary<TravelRouteKey, TravelRoute> routeDict = new Dictionary<TravelRouteKey, TravelRoute>();
		List<short> areaIdList = ObjectPool<List<short>>.Instance.Get();
		Dictionary<TravelRouteKey, TravelRoute> findRouteDict = (DomainManager.World.GetWorldFunctionsStatus(4) ? _travelRouteDict : _bornStateTravelRouteDict);
		GetAllAreaInState(stateId, areaIdList);
		for (int i = 0; i < areaIdList.Count - 1; i++)
		{
			for (int j = i + 1; j < areaIdList.Count; j++)
			{
				TravelRouteKey key = new TravelRouteKey(areaIdList[i], areaIdList[j]);
				routeDict.Add(key, findRouteDict[key]);
			}
		}
		ObjectPool<List<short>>.Instance.Return(areaIdList);
		return routeDict;
	}

	public Location CrossAreaTravelInfoToLocation(CrossAreaMoveInfo crossAreaMoveInfos)
	{
		if (crossAreaMoveInfos.CostedDays == 0)
		{
			return new Location(crossAreaMoveInfos.FromAreaId, crossAreaMoveInfos.FromBlockId);
		}
		int days = 0;
		for (int i = 0; i < crossAreaMoveInfos.Route.CostList.Count; i++)
		{
			short cost = crossAreaMoveInfos.Route.CostList[i];
			days += cost;
			if (days >= crossAreaMoveInfos.CostedDays)
			{
				short areaId = crossAreaMoveInfos.Route.AreaList[i];
				MapAreaData areaData = DomainManager.Map.GetElement_Areas(areaId);
				return new Location(areaId, areaData.StationBlockId);
			}
		}
		return Location.Invalid;
	}

	public void GetAllAreaInState(sbyte stateId, List<short> areaList)
	{
		SharedMethods.GetAreaListInState(stateId, areaList);
	}

	public void GetAllRegularAreaInState(sbyte stateId, List<short> areaList)
	{
		SharedMethods.GetRegularAreaListInState(stateId, areaList);
	}

	public void GetAllBrokenAreaInState(sbyte stateId, List<short> areaList)
	{
		SharedMethods.GetBrokenAreaListInState(stateId, areaList);
	}

	public IEnumerable<short> GetRegularAreaIdsInState(sbyte stateId)
	{
		return SharedMethods.GetRegularAreaIdsInState(stateId);
	}

	public byte GetAreaSize(short areaId)
	{
		if (areaId < 45 || areaId >= 135)
		{
			MapAreaItem areaConfigData = _areas[areaId].GetConfig();
			short taiwuVillageSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
			if ((taiwuVillageSettlementId >= 0 && DomainManager.Organization.GetSettlement(taiwuVillageSettlementId).GetLocation().AreaId == areaId) || areaId == 139)
			{
				return (byte)GlobalConfig.Instance.TaiwuVillageForceAreaSize;
			}
			return areaConfigData.Size;
		}
		return 5;
	}

	public bool IsAreaBroken(short areaId)
	{
		int brokenAreaIdStart = 45;
		int brokenAreaIdEnd = 135;
		return areaId >= brokenAreaIdStart && areaId < brokenAreaIdEnd;
	}

	public short GetMainSettlementMainBlockId(short areaId)
	{
		MapAreaData area = _areas[areaId];
		SettlementInfo mainSettlementInfo = area.SettlementInfos[0];
		return mainSettlementInfo.BlockId;
	}

	public short GetNearestSettlementIdByLocation(Location location)
	{
		MapAreaData areaMapData = DomainManager.Map.GetElement_Areas(location.AreaId);
		byte areaSize = DomainManager.Map.GetAreaSize(location.AreaId);
		ByteCoordinate selfCoordinate = ByteCoordinate.IndexToCoordinate(location.BlockId, areaSize);
		int initDistance = int.MaxValue;
		short settlementId = -1;
		for (int i = 0; i < areaMapData.SettlementInfos.Length; i++)
		{
			SettlementInfo settlementInfo = areaMapData.SettlementInfos[i];
			int distance = selfCoordinate.GetManhattanDistance(ByteCoordinate.IndexToCoordinate(settlementInfo.BlockId, areaSize));
			if (distance < initDistance)
			{
				initDistance = distance;
				settlementId = settlementInfo.SettlementId;
			}
		}
		return settlementId;
	}

	public ByteCoordinate GetWorldPos(short areaId)
	{
		sbyte[] pos = _areas[areaId].GetConfig().WorldMapPos;
		return new ByteCoordinate((byte)pos[0], (byte)pos[1]);
	}

	public sbyte GetStateIdByStateTemplateId(short stateTemplateId)
	{
		return (sbyte)(stateTemplateId - 1);
	}

	public sbyte GetStateIdByAreaId(short areaId)
	{
		return GetStateIdByStateTemplateId(_areas[areaId].GetConfig().StateID);
	}

	public sbyte GetStateTemplateIdByAreaId(short areaId)
	{
		return _areas[areaId].GetConfig().StateID;
	}

	public (string stateName, string areaName) GetStateAndAreaNameByAreaId(short areaId)
	{
		MapAreaItem areaConfig = _areas[areaId].GetConfig();
		string areaName = areaConfig.Name;
		string stateName = MapState.Instance[areaConfig.StateID].Name;
		return (stateName: stateName, areaName: areaName);
	}

	public (sbyte stateTemplateId, short areaTemplateId) GetStateAndAreaNameTemplateIdByAreaId(short areaId)
	{
		MapAreaItem areaConfig = _areas[areaId].GetConfig();
		return (stateTemplateId: MapState.Instance[areaConfig.StateID].TemplateId, areaTemplateId: areaConfig.TemplateId);
	}

	public short GetAreaIdByAreaTemplateId(short areaTemplateId)
	{
		for (short areaId = 0; areaId < _areas.Length; areaId++)
		{
			if (_areas[areaId].GetTemplateId() == areaTemplateId)
			{
				return areaId;
			}
		}
		return -1;
	}

	public void GetEdgeBlockList(short areaId, List<short> blockIdList, bool excludeTravelBlock = false, bool strictSelect = true)
	{
		HashSet<short> edgeTemplates = ObjectPool<HashSet<short>>.Instance.Get();
		edgeTemplates.Clear();
		edgeTemplates.Add(126);
		GetEdgeBlockList(areaId, blockIdList, null, excludeTravelBlock, strictSelect);
		ObjectPool<HashSet<short>>.Instance.Return(edgeTemplates);
	}

	public void GetEdgeBlockList(short areaId, List<short> blockIdList, ISet<short> edgeTemplates, bool excludeTravelBlock = false, bool strictSelect = true, bool containsBigBlock = false)
	{
		byte areaSize = GetAreaSize(areaId);
		Span<MapBlockData> blocks = GetAreaBlocks(areaId);
		int blockCount = blocks.Length;
		List<short> travelBlocks = null;
		byte minX = byte.MaxValue;
		byte minY = byte.MaxValue;
		byte maxX = 0;
		byte maxY = 0;
		if (excludeTravelBlock)
		{
			travelBlocks = ObjectPool<List<short>>.Instance.Get();
			travelBlocks.Clear();
		}
		if (strictSelect)
		{
			for (byte x = 0; x < areaSize; x++)
			{
				for (byte y = 0; y < areaSize; y++)
				{
					MapBlockData block = blocks[ByteCoordinate.CoordinateToIndex(new ByteCoordinate(x, y), areaSize)];
					if (block.IsPassable() && !containsBigBlock && block.RootBlockId < 0 && block.GroupBlockList == null)
					{
						minX = Math.Min(x, minX);
						minY = Math.Min(y, minY);
						maxX = Math.Max(x, maxX);
						maxY = Math.Max(y, maxY);
					}
				}
			}
		}
		blockIdList.Clear();
		for (short blockId = 0; blockId < blockCount; blockId++)
		{
			MapBlockData block2 = blocks[blockId];
			if (block2.IsPassable() && (containsBigBlock || block2.RootBlockId < 0) && (block2.GroupBlockList == null || block2.GroupBlockList.Count <= 0))
			{
				ByteCoordinate pos = ByteCoordinate.IndexToCoordinate(blockId, areaSize);
				bool isEdge = pos.X == 0 || pos.X == areaSize - 1 || pos.Y == 0 || pos.Y == areaSize - 1;
				if (!isEdge)
				{
					if (strictSelect)
					{
						bool nearLeft = pos.X < areaSize / 2;
						bool nearRight = !nearLeft;
						bool nearBottom = pos.Y < areaSize / 2;
						bool nearTop = !nearBottom;
						int xDist = (nearLeft ? pos.X : (areaSize - pos.X));
						int yDist = (nearBottom ? pos.Y : (areaSize - pos.Y));
						if (xDist < yDist)
						{
							nearBottom = (nearTop = false);
						}
						else if (xDist > yDist)
						{
							nearLeft = (nearRight = false);
						}
						isEdge = (!nearLeft || pos.X == minX) && (!nearRight || pos.X == maxX) && (!nearBottom || pos.Y == minY) && (!nearTop || pos.Y == maxY);
					}
					else
					{
						isEdge = edgeTemplates.Contains(blocks[(short)(blockId - 1)].TemplateId) || edgeTemplates.Contains(blocks[(short)(blockId + 1)].TemplateId) || edgeTemplates.Contains(blocks[(short)(blockId - areaSize)].TemplateId) || edgeTemplates.Contains(blocks[(short)(blockId + areaSize)].TemplateId);
					}
				}
				if (isEdge && (!excludeTravelBlock || !travelBlocks.Contains(blockId)))
				{
					blockIdList.Add(blockId);
				}
			}
		}
		if (excludeTravelBlock)
		{
			ObjectPool<List<short>>.Instance.Return(travelBlocks);
		}
	}

	public short GetRandomSettlementId(sbyte stateId, IRandomSource random, bool containsMainCityAndSect = false)
	{
		int regularAreasPerState = 3;
		List<short> randomPool = ObjectPool<List<short>>.Instance.Get();
		short settlementId = -1;
		randomPool.Clear();
		short taiwuVillageSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		for (int index = 0; index < regularAreasPerState; index++)
		{
			short areaId = (short)(stateId * regularAreasPerState + index);
			SettlementInfo[] settlementInfos = _areas[areaId].SettlementInfos;
			for (int i = 0; i < settlementInfos.Length; i++)
			{
				SettlementInfo settlementInfo = settlementInfos[i];
				if (settlementInfo.SettlementId >= 0 && settlementInfo.SettlementId != taiwuVillageSettlementId && (containsMainCityAndSect || GetBlock(areaId, settlementInfo.BlockId).BlockType == EMapBlockType.Town))
				{
					randomPool.Add(settlementInfo.SettlementId);
				}
			}
		}
		if (randomPool.Count > 0)
		{
			settlementId = randomPool[random.Next(0, randomPool.Count)];
		}
		return settlementId;
	}

	public short GetRandomStateSettlementId(IRandomSource random, sbyte stateId, bool containsMainCity = false, bool containsSect = false)
	{
		List<short> settlementIds = ObjectPool<List<short>>.Instance.Get();
		GetStateSettlementIds(stateId, settlementIds, containsMainCity, containsSect);
		if (settlementIds.Count == 0)
		{
			return -1;
		}
		short settlementId = settlementIds.GetRandom(random);
		ObjectPool<List<short>>.Instance.Return(settlementIds);
		return settlementId;
	}

	public void GetStateSettlementIds(sbyte stateId, List<short> settlementIds, bool containsMainCity = false, bool containsSect = false)
	{
		settlementIds.Clear();
		int regularAreasPerState = 3;
		for (int index = 0; index < regularAreasPerState; index++)
		{
			short areaId = (short)(stateId * regularAreasPerState + index);
			SettlementInfo[] settlementInfos = _areas[areaId].SettlementInfos;
			for (int i = 0; i < settlementInfos.Length; i++)
			{
				SettlementInfo settlementInfo = settlementInfos[i];
				if (settlementInfo.SettlementId < 0)
				{
					continue;
				}
				MapBlockData blockData = GetBlock(areaId, settlementInfo.BlockId);
				switch (blockData.BlockType)
				{
				case EMapBlockType.Town:
					settlementIds.Add(settlementInfo.SettlementId);
					break;
				case EMapBlockType.City:
					if (containsMainCity)
					{
						settlementIds.Add(settlementInfo.SettlementId);
					}
					break;
				case EMapBlockType.Sect:
					if (containsSect)
					{
						settlementIds.Add(settlementInfo.SettlementId);
					}
					break;
				}
			}
		}
	}

	public void GetAreaSettlementIds(short areaId, List<short> settlementIds, bool containsMainCity = false, bool containsSect = false)
	{
		settlementIds.Clear();
		SettlementInfo[] settlementInfos = _areas[areaId].SettlementInfos;
		for (int i = 0; i < settlementInfos.Length; i++)
		{
			SettlementInfo settlementInfo = settlementInfos[i];
			if (settlementInfo.SettlementId < 0)
			{
				continue;
			}
			MapBlockData blockData = GetBlock(areaId, settlementInfo.BlockId);
			switch (blockData.BlockType)
			{
			case EMapBlockType.Town:
				settlementIds.Add(settlementInfo.SettlementId);
				break;
			case EMapBlockType.City:
				if (containsMainCity)
				{
					settlementIds.Add(settlementInfo.SettlementId);
				}
				break;
			case EMapBlockType.Sect:
				if (containsSect)
				{
					settlementIds.Add(settlementInfo.SettlementId);
				}
				break;
			}
		}
	}

	public CrossAreaMoveInfo CalcAreaTravelRoute(GameData.Domains.Character.Character character, short fromAreaId, short fromBlockId, short toAreaId)
	{
		if (fromAreaId == toAreaId)
		{
			throw new ArgumentException("fromAreaId cannot equals toAreaId");
		}
		bool reversePath = fromAreaId > toAreaId;
		TravelRouteKey routeKey = new TravelRouteKey(reversePath ? toAreaId : fromAreaId, reversePath ? fromAreaId : toAreaId);
		Dictionary<TravelRouteKey, TravelRoute> findRouteDict = _travelRouteDict;
		TravelRoute route = new TravelRoute(findRouteDict[routeKey]);
		if (reversePath)
		{
			route.PosList.Reverse();
			route.AreaList.Reverse();
			route.CostList.Reverse();
		}
		route.AreaList.RemoveAt(0);
		CValuePercentBonus carrierReducePercent = character.CalcCarrierTimeBonus();
		for (int i = 0; i < route.CostList.Count; i++)
		{
			route.CostList[i] = (short)Math.Max(route.CostList[i] * carrierReducePercent, 1);
		}
		return new CrossAreaMoveInfo
		{
			FromAreaId = fromAreaId,
			FromBlockId = fromBlockId,
			ToAreaId = toAreaId,
			Route = route
		};
	}

	public bool AllowCrossAreaTravel(short fromAreaId, short toAreaId)
	{
		if (fromAreaId >= 135 || toAreaId >= 135)
		{
			return false;
		}
		bool reversePath = fromAreaId > toAreaId;
		TravelRouteKey routeKey = new TravelRouteKey(reversePath ? toAreaId : fromAreaId, reversePath ? fromAreaId : toAreaId);
		if (!_travelRouteDict.ContainsKey(routeKey))
		{
			return false;
		}
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		return (fromAreaId != taiwuVillageLocation.AreaId && toAreaId != taiwuVillageLocation.AreaId) || (DomainManager.Map.GetElement_Areas(taiwuVillageLocation.AreaId).StationUnlocked && DomainManager.World.GetWorldFunctionsStatus(4));
	}

	public int GetTotalTimeCost(GameData.Domains.Character.Character character, short fromAreaId, short toAreaId)
	{
		if (fromAreaId == toAreaId)
		{
			return 0;
		}
		if (!AllowCrossAreaTravel(fromAreaId, toAreaId))
		{
			return int.MaxValue;
		}
		bool reversePath = fromAreaId > toAreaId;
		TravelRouteKey routeKey = new TravelRouteKey(reversePath ? toAreaId : fromAreaId, reversePath ? fromAreaId : toAreaId);
		CValuePercentBonus carrierReducePercent = character.CalcCarrierTimeBonus();
		TravelRoute route = _travelRouteDict[routeKey];
		int timeCost = 0;
		for (int i = 0; i < route.CostList.Count; i++)
		{
			timeCost += Math.Max(route.CostList[i] * carrierReducePercent, 1);
		}
		return timeCost;
	}

	public static void ParallelUpdateBrokenBlockOnMonthChange(DataContext context, int areaIdInt)
	{
		ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks((short)areaIdInt);
		for (int i = 0; i < areaBlocks.Length; i++)
		{
			MapBlockData block = areaBlocks[i];
			if (block.CountDown())
			{
				recorder.RecordType(ParallelModificationType.UpdateBrokenArea);
				recorder.RecordParameterClass(block);
			}
		}
	}

	public static void ParallelUpdateOnMonthChange(DataContext context, int areaIdInt)
	{
		short areaId = (short)areaIdInt;
		MapAreaData area = DomainManager.Map.GetElement_Areas(areaId);
		ParallelMapAreaModification mod = new ParallelMapAreaModification();
		List<sbyte> recoverResourceType = Month.Instance[DomainManager.World.GetCurrMonthInYear()].RecoverResourceType;
		int maxRecoverPercent = 14 - DomainManager.World.GetWorldResourceAmountType() * 3;
		Dictionary<sbyte, List<Location>> resourceSpeedUpDict = DomainManager.Taiwu.ResourceRecoverSpeedUpDict;
		List<(short, short)> potentialDisasterBlocks = context.AdvanceMonthRelatedData.WeightTable.Occupy();
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
		for (short blockId = 0; blockId < blocks.Length; blockId++)
		{
			MapBlockData block = blocks[blockId];
			Location location = new Location(areaId, blockId);
			if (block.IsPassable())
			{
				if (!block.Destroyed || !DomainManager.Extra.IsMapBlockRecoveryLocked(location))
				{
					block.StopDestroyedByRecover();
					OfflineRecoverResource(context.Random, block, location, maxRecoverPercent, recoverResourceType, resourceSpeedUpDict);
				}
				if (block.Items != null)
				{
					block.DestroyItems(mod.DestroyedUniqueItems);
				}
				short maxMalice = block.GetMaxMalice();
				bool disasterCondition = maxMalice > 0 && block.Malice * 100 / maxMalice >= 25 && block.RootBlockId < 0 && block.GroupBlockList == null;
				if (block.GetConfig().SubType == EMapBlockSubType.DLCLoong)
				{
					disasterCondition = false;
				}
				if (!DomainManager.Map.LocationCanTriggerNaturalDisaster(context, location))
				{
					disasterCondition = false;
				}
				if (disasterCondition)
				{
					potentialDisasterBlocks.Add((blockId, (short)(block.Malice * 100 / maxMalice)));
				}
				block.CountDown();
			}
		}
		if (areaId < 45 && areaId != DomainManager.Taiwu.GetTaiwuVillageLocation().AreaId)
		{
			TriggerDisasters(context, areaId, potentialDisasterBlocks, mod);
		}
		context.AdvanceMonthRelatedData.WeightTable.Release(ref potentialDisasterBlocks);
		for (int i = 0; i < area.SettlementInfos.Length; i++)
		{
			SettlementInfo settlementInfo = area.SettlementInfos[i];
			if (settlementInfo.SettlementId >= 0 && !mod.SettlementDict.ContainsKey(settlementInfo.SettlementId))
			{
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementInfo.SettlementId);
				if (settlement.GetSafety() >= settlement.GetMaxSafety() / 2)
				{
					mod.SettlementDict.Add(settlementInfo.SettlementId, new ParallelSettlementModification(settlement.GetCulture(), settlement.GetSafety(), Math.Min(settlement.GetPopulation() + 1, settlement.GetMaxPopulation())));
				}
			}
		}
		ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
		mod.AreaId = areaId;
		recorder.RecordType(ParallelModificationType.UpdateMapArea);
		recorder.RecordParameterClass(mod);
	}

	private unsafe static void OfflineRecoverResource(IRandomSource random, MapBlockData block, Location location, int maxRecoverPercent, List<sbyte> recoverResourceType, Dictionary<sbyte, List<Location>> resourceSpeedUpDict)
	{
		int buildingBonus = DomainManager.Building.GetBuildingBlockEffect(location, EBuildingScaleEffect.MapResourceRegenBonus);
		for (int i = 0; i < recoverResourceType.Count; i++)
		{
			sbyte type = recoverResourceType[i];
			int maxAddValue = Math.Max(block.MaxResources.Items[type] * maxRecoverPercent / 100, 1);
			int addValue = random.Next(maxAddValue + 1);
			addValue *= (CValuePercentBonus)buildingBonus;
			addValue = addValue * GameData.Domains.World.SharedMethods.GetGainResourcePercent(1) / 100;
			if (resourceSpeedUpDict.TryGetValue(type, out var value) && value.Contains(location))
			{
				addValue *= 3;
			}
			block.CurrResources.Items[type] = (short)Math.Min(block.CurrResources.Items[type] + addValue, block.MaxResources.Items[type]);
		}
	}

	private static void TriggerDisasters(DataContext context, short areaId, List<(short, short)> potentialDisasterBlocks, ParallelMapAreaModification mod)
	{
		potentialDisasterBlocks.Sort(((short, short) a, (short, short) b) => b.Item2.CompareTo(a.Item2));
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(areaId);
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		for (int i = 0; i < potentialDisasterBlocks.Count; i++)
		{
			short blockId = potentialDisasterBlocks[i].Item1;
			MapBlockData block = areaBlocks[blockId];
			short maxMalice = block.GetMaxMalice();
			int malicePercentage = block.Malice * 100 / maxMalice;
			List<MapBlockData> groupBlockList = block.GroupBlockList;
			if ((groupBlockList != null && groupBlockList.Count > 0) || block.RootBlockId >= 0)
			{
				continue;
			}
			for (int index = 0; index < GlobalConfig.Instance.DisasterTriggerCurrBlockThresholds.Length; index++)
			{
				sbyte currBlockThreshold = GlobalConfig.Instance.DisasterTriggerCurrBlockThresholds[index];
				if (malicePercentage >= currBlockThreshold)
				{
					sbyte triggerRange = GlobalConfig.Instance.DisasterTriggerRanges[index];
					if (triggerRange > 0)
					{
						DomainManager.Map.GetRealNeighborBlocks(areaId, blockId, neighborBlocks, triggerRange);
					}
					else
					{
						neighborBlocks.Clear();
					}
					int malicePercentageSum = GetMalicePercentageSum(neighborBlocks) + malicePercentage;
					short neighborSumThreshold = GlobalConfig.Instance.DisasterTriggerNeighborSumThresholds[index];
					if (malicePercentageSum >= neighborSumThreshold)
					{
						DomainManager.Map.GetRealNeighborBlocks(areaId, blockId, neighborBlocks, GlobalConfig.Instance.DisasterTriggerRanges[^1]);
						TriggerDisaster(context, areaId, blockId, neighborBlocks, mod);
						break;
					}
				}
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
	}

	private static int GetMalicePercentageSum(List<MapBlockData> blocks)
	{
		int percentageSum = 0;
		foreach (MapBlockData block in blocks)
		{
			short maxMalice = block.GetMaxMalice();
			if (maxMalice > 0)
			{
				percentageSum += block.Malice * 100 / maxMalice;
			}
		}
		return percentageSum;
	}

	private static void TriggerDisaster(DataContext context, short areaId, short blockId, List<MapBlockData> neighborBlocks, ParallelMapAreaModification mod)
	{
		Location blockKey = new Location(areaId, blockId);
		MapAreaData area = DomainManager.Map.GetElement_Areas(areaId);
		MapBlockData block = DomainManager.Map.GetBlock(blockKey);
		mod.DisasterBlocks.Add(blockId);
		int adventureId = ResourceDisasterHelper.RandomDisasterAdventureId(context.Random, block);
		if (adventureId > 0)
		{
			mod.DisasterAdventureId.Add(blockId, adventureId);
		}
		block.Malice = 0;
		foreach (MapBlockData neighborBlock in neighborBlocks)
		{
			neighborBlock.Malice = 0;
		}
		block.MakeDestroyed(mod.DestroyedUniqueItems);
		for (int i = 0; i < area.SettlementInfos.Length; i++)
		{
			SettlementInfo settlementInfo = area.SettlementInfos[i];
			if (settlementInfo.BlockId == blockId && settlementInfo.SettlementId >= 0)
			{
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementInfo.SettlementId);
				mod.SettlementDict.Add(settlementInfo.SettlementId, new ParallelSettlementModification(0, 0, settlement.GetPopulation() * context.Random.Next(70, 91) / 100));
				break;
			}
		}
		if (block.CharacterSet != null)
		{
			foreach (int charId in block.CharacterSet)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				int randResult = context.Random.Next(5);
				if (character.GetAgeGroup() != 2 || DomainManager.Taiwu.GetGroupCharIds().Contains(charId) || character.GetFeatureIds().Contains(681))
				{
					randResult--;
				}
				switch (randResult)
				{
				case 1:
				{
					AddOrIncreaseInjuryParams param2 = new AddOrIncreaseInjuryParams(BodyPartType.GetRandomBodyPartType(context.Random), isInnerInjury: false, (sbyte)context.Random.Next(1, 3));
					mod.CharInjuries.Add((character, param2));
					break;
				}
				case 2:
				{
					for (int k = 0; k < 2; k++)
					{
						AddOrIncreaseInjuryParams param3 = new AddOrIncreaseInjuryParams(BodyPartType.GetRandomBodyPartType(context.Random), isInnerInjury: false, (sbyte)context.Random.Next(3, 5));
						mod.CharInjuries.Add((character, param3));
					}
					break;
				}
				case 3:
				{
					for (int j = 0; j < 2; j++)
					{
						AddOrIncreaseInjuryParams param = new AddOrIncreaseInjuryParams(BodyPartType.GetRandomBodyPartType(context.Random), isInnerInjury: false, (sbyte)context.Random.Next(5, 7));
						mod.CharInjuries.Add((character, param));
					}
					break;
				}
				case 4:
					mod.DeadCharList.Add(charId);
					break;
				}
			}
		}
		if (block.GraveSet != null)
		{
			mod.DamageGraveList.AddRange(block.GraveSet);
		}
	}

	public void ComplementUpdateMapArea(DataContext context, ParallelMapAreaModification mod)
	{
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Span<MapBlockData> blocks = GetAreaBlocks(mod.AreaId);
		int i = 0;
		for (int count = blocks.Length; i < count; i++)
		{
			SetBlockData(context, blocks[i]);
		}
		foreach (KeyValuePair<short, ParallelSettlementModification> settlement in mod.SettlementDict)
		{
			Sect sect;
			if (DomainManager.Organization.TryGetElement_CivilianSettlements(settlement.Key, out var civilianSettlement))
			{
				civilianSettlement.SetCulture(settlement.Value.Culture, context);
				civilianSettlement.SetSafety(settlement.Value.Safety, context);
				civilianSettlement.SetPopulation(settlement.Value.Population, context);
			}
			else if (DomainManager.Organization.TryGetElement_Sects(settlement.Key, out sect))
			{
				sect.SetCulture(settlement.Value.Culture, context);
				sect.SetSafety(settlement.Value.Safety, context);
				sect.SetPopulation(settlement.Value.Population, context);
			}
		}
		if (mod.DisasterBlocks.Count > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 1);
			Location disasterLocation = new Location(mod.AreaId, -1);
			monthlyNotifications.AddNaturalDisasterOccurred(disasterLocation, mod.DeadCharList.Count, mod.DisasterBlocks.Count);
			List<MapBlockData> neighborBlocks = new List<MapBlockData>();
			foreach (short blockId in mod.DisasterBlocks)
			{
				DomainManager.Map.UpdateLocationNaturalDisasterDate(context, new Location(mod.AreaId, blockId), DomainManager.World.GetCurrDate());
				DomainManager.Map.GetRealNeighborBlocks(mod.AreaId, blockId, neighborBlocks, 2);
				int count2 = context.Random.Next(GlobalConfig.Instance.GenerateXiangshuMinionAfterDisasterRangeMax) + GlobalConfig.Instance.GenerateXiangshuMinionAfterDisasterBase;
				while (count2-- > 0)
				{
					if (DomainManager.Map.GetBlock(mod.AreaId, blockId).BlockType != EMapBlockType.Developed || context.Random.CheckPercentProb(GlobalConfig.Instance.GenerateXiangshuMinionAfterDisasterInDevelopedBlockProbabilityPercentage))
					{
						CreateTemporaryEnemiesOnValidBlocks(context, 0, Location.Invalid, (short)Math.Clamp(366 + DomainManager.World.GetXiangshuLevel() - context.Random.Next(GlobalConfig.Instance.GenerateXiangshuMinionAfterDisasterGradeMinusMax), 366, 374), 1, neighborBlocks);
					}
				}
			}
		}
		GameData.Domains.Character.Character uncommittedChar = null;
		int j = 0;
		for (int count3 = mod.CharInjuries.Count; j < count3; j++)
		{
			var (character, param) = mod.CharInjuries[j];
			character.GetInjuries().Change(param.BodyPartType, param.IsInnerInjury, param.InjuryValue);
			if (character != uncommittedChar)
			{
				uncommittedChar?.SetInjuries(uncommittedChar.GetInjuries(), context);
				uncommittedChar = character;
				Location location = character.GetLocation();
				if (!location.IsValid())
				{
					location = character.GetLocation();
				}
				lifeRecordCollection.AddNaturalDisasterButSurvive(character.GetId(), currDate, location);
			}
		}
		uncommittedChar?.SetInjuries(uncommittedChar.GetInjuries(), context);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		for (int k = 0; k < mod.DeadCharList.Count; k++)
		{
			int deadCharId = mod.DeadCharList[k];
			if (deadCharId == taiwuCharId)
			{
				DomainManager.World.SetTaiwuDying();
			}
			if (DomainManager.Character.TryGetElement_Objects(deadCharId, out var deadChar))
			{
				DomainManager.Character.MakeCharacterDead(context, deadChar, 6);
			}
		}
		for (int l = 0; l < mod.DamageGraveList.Count; l++)
		{
			int charId = mod.DamageGraveList[l];
			Grave grave = DomainManager.Character.GetElement_Graves(charId);
			if (grave.GetLevel() > 1)
			{
				grave.SetLevel((sbyte)(grave.GetLevel() - 1), context);
			}
			else
			{
				DomainManager.Character.RemoveGrave(context, grave);
			}
		}
		foreach (KeyValuePair<short, int> item in mod.DisasterAdventureId)
		{
			item.Deconstruct(out var key, out var value);
			short blockId2 = key;
			int coreId = value;
			IAdventureData core = AdventureDomain.Core.GetAdventureAny(coreId);
			Location location2 = new Location(mod.AreaId, blockId2);
			Logger.Info("Disaster generate material adventure {0} at ({1}, {2})", core.Name, mod.AreaId, blockId2);
			DomainManager.Adventure.GenerateAny(context, coreId, location2);
			monthlyNotifications.AddDisasterAndPreciousMaterial(location2);
		}
		DomainManager.Item.RemoveItems(context, mod.DestroyedUniqueItems);
	}

	public bool LocationHasCricket(DataContext context, Location location)
	{
		CricketPlaceData data = _cricketPlaceData[location.AreaId];
		if (data != null)
		{
			int index = Array.IndexOf(data.CricketBlocks, location.BlockId);
			if (index >= 0)
			{
				return !data.CricketTriggered[index];
			}
		}
		if (DomainManager.Extra.TryGetElement_CricketPlaceExtraData(location.AreaId, out var cricketPlaceExtraData) && cricketPlaceExtraData != null && cricketPlaceExtraData.ExtraMapUnits != null && cricketPlaceExtraData.ExtraMapUnits.TryGetValue(location.BlockId, out var _))
		{
			return true;
		}
		return false;
	}

	public void UpdateCricketPlaceData(DataContext context)
	{
		sbyte currMonthInYear = DomainManager.World.GetCurrMonthInYear();
		if (currMonthInYear == GlobalConfig.Instance.CricketActiveStartMonth)
		{
			for (short areaId = 0; areaId < 45; areaId++)
			{
				InitializeCricketPlaceData(context, areaId);
			}
			InitializeCricketPlaceData(context, 137);
			InitializeCricketPlaceData(context, 138);
			MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
			monthlyNotifications.AddCricketsAppeared();
		}
		else if (currMonthInYear == GlobalConfig.Instance.CricketActiveEndMonth)
		{
			for (short areaId2 = 0; areaId2 < 45; areaId2++)
			{
				SetElement_CricketPlaceData(areaId2, null, context);
			}
			SetElement_CricketPlaceData(137, null, context);
			SetElement_CricketPlaceData(138, null, context);
		}
		DomainManager.Extra.UpdateExtraCricketMapUnit(context);
	}

	private void InitializeCricketPlaceData(DataContext context, short areaId)
	{
		CricketPlaceData cricketData = new CricketPlaceData();
		cricketData.Init(areaId, context.Random);
		SetElement_CricketPlaceData(areaId, cricketData, context);
	}

	public void SetCricketPlaceData(DataContext context, short areaId, CricketPlaceData cricketData)
	{
		SetElement_CricketPlaceData(areaId, cricketData, context);
	}

	[DomainMethod]
	public bool TryTriggerCricketCatch(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwu.GetLocation();
		if (DomainManager.Extra.TryGetElement_CricketPlaceExtraData(location.AreaId, out var cricketPlaceExtraData) && cricketPlaceExtraData != null && cricketPlaceExtraData.ExtraMapUnits != null && cricketPlaceExtraData.ExtraMapUnits.TryGetValue(location.BlockId, out var _))
		{
			if (!TryCostSweepNet())
			{
				return false;
			}
			DomainManager.Extra.RemoveExtraCricketMapUnit(context, location);
			CricketLuckPointPostProcess();
			return true;
		}
		CricketPlaceData cricketPlaceData = GetElement_CricketPlaceData(location.AreaId);
		if (cricketPlaceData == null)
		{
			return false;
		}
		int index = Array.IndexOf(cricketPlaceData.CricketBlocks, location.BlockId);
		if (index < 0 || cricketPlaceData.CricketTriggered[index])
		{
			return false;
		}
		if (!TryCostSweepNet())
		{
			return false;
		}
		int grpIdx = index / 3;
		if (cricketPlaceData.RealCircketIdx[grpIdx] == index % 3)
		{
			for (int i = 0; i < 3; i++)
			{
				cricketPlaceData.CricketTriggered[3 * grpIdx + i] = true;
			}
			SetElement_CricketPlaceData(location.AreaId, cricketPlaceData, context);
			return true;
		}
		CricketLuckPointPostProcess();
		cricketPlaceData.CricketTriggered[index] = true;
		cricketPlaceData.ChangePlace(location.AreaId, index);
		SetElement_CricketPlaceData(location.AreaId, cricketPlaceData, context);
		return false;
		void CricketLuckPointPostProcess()
		{
			DomainManager.Taiwu.SetCricketLuckPoint(DomainManager.Taiwu.GetCricketLuckPoint() + context.Random.Next(6, 13), context);
		}
		bool TryCostSweepNet()
		{
			List<(ItemKey, int)> ret = new List<(ItemKey, int)>();
			CharacterItemFilterWrappers.FindByTemplateId(taiwu, 12, 18, ret, searchInventory: true, searchEquipment: false);
			if (ret.Count == 0)
			{
				return false;
			}
			ItemKey itemKey = ret[0].Item1;
			taiwu.RemoveInventoryItem(context, itemKey, 1, deleteItem: false);
			return true;
		}
	}

	public bool IsCricketInLocation(Location location)
	{
		if (!location.IsValid())
		{
			return false;
		}
		CricketPlaceData cricketPlaceData = _cricketPlaceData[location.AreaId];
		for (int i = 0; i < (cricketPlaceData?.CricketBlocks?.Length).GetValueOrDefault(); i++)
		{
			if (cricketPlaceData.CricketBlocks[i] == location.BlockId && !cricketPlaceData.CricketTriggered[i])
			{
				return true;
			}
		}
		if (DomainManager.Extra.TryGetElement_CricketPlaceExtraData(location.AreaId, out var extraData))
		{
			Dictionary<short, short> extraMapUnits = extraData.ExtraMapUnits;
			if (extraMapUnits != null && extraMapUnits.Count > 0)
			{
				return extraData.ExtraMapUnits.ContainsKey(location.BlockId);
			}
		}
		return false;
	}

	public void GetNearAreaList(short areaId, List<short> areaList)
	{
		if (areaId < 45)
		{
			areaList.Clear();
			areaList.Add(areaId);
			areaList.AddRange(_regularAreaNearList[areaId].Items);
		}
	}

	public void ChangeSettlementSafetyInArea(DataContext context, short areaId, int delta)
	{
		MapAreaData areaData = _areas[areaId];
		SettlementInfo[] settlementInfos = areaData.SettlementInfos;
		for (int i = 0; i < settlementInfos.Length; i++)
		{
			SettlementInfo settlementInfo = settlementInfos[i];
			if (settlementInfo.SettlementId >= 0)
			{
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementInfo.SettlementId);
				settlement.ChangeSafety(context, delta);
			}
		}
	}

	public void ChangeSettlementCultureInArea(DataContext context, short areaId, int delta)
	{
		MapAreaData areaData = _areas[areaId];
		SettlementInfo[] settlementInfos = areaData.SettlementInfos;
		for (int i = 0; i < settlementInfos.Length; i++)
		{
			SettlementInfo settlementInfo = settlementInfos[i];
			if (settlementInfo.SettlementId >= 0)
			{
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementInfo.SettlementId);
				settlement.ChangeCulture(context, delta);
			}
		}
	}

	[DomainMethod]
	public MapAreaData GetAreaByAreaId(short areaId)
	{
		return GetElement_Areas(areaId);
	}

	public short GetSpiritualDebtLowestAreaIdByAreaId(short currAreaId)
	{
		sbyte stateId = GetStateIdByAreaId(currAreaId);
		List<short> areas = ObjectPool<List<short>>.Instance.Get();
		GetAllAreaInState(stateId, areas);
		int lowestSpiritualDebtValue = int.MaxValue;
		short lowestSpiritualDebtAreaId = currAreaId;
		foreach (short areaId in areas)
		{
			if (!IsAreaBroken(areaId))
			{
				int value = DomainManager.Extra.GetAreaSpiritualDebt(areaId);
				if (value < lowestSpiritualDebtValue)
				{
					lowestSpiritualDebtValue = value;
					lowestSpiritualDebtAreaId = areaId;
				}
			}
		}
		ObjectPool<List<short>>.Instance.Return(areas);
		return lowestSpiritualDebtAreaId;
	}

	[DomainMethod]
	public MapBlockData GetBlockData(short areaId, short blockId)
	{
		LastGetBlockDataPosition_Debug = new Location(areaId, blockId);
		return GetBlock(areaId, blockId);
	}

	[DomainMethod]
	public FullBlockName GetBlockFullName(Location location)
	{
		if (location.AreaId < 0)
		{
			return new FullBlockName
			{
				areaTemplateId = -1,
				stateTemplateId = -1,
				BelongBlockData = null,
				BlockData = null
			};
		}
		FullBlockName fullBlockName = new FullBlockName
		{
			areaTemplateId = GetElement_Areas(location.AreaId).GetTemplateId(),
			stateTemplateId = GetStateTemplateIdByAreaId(location.AreaId)
		};
		MapBlockData blockData = GetBlock(location);
		fullBlockName.BlockData = MapBlockData.SimpleClone(blockData);
		if (blockData.BelongBlockId >= 0)
		{
			MapBlockData belongBlockData = GetBlock(blockData.AreaId, blockData.BelongBlockId);
			fullBlockName.BelongBlockData = MapBlockData.SimpleClone(belongBlockData);
		}
		return fullBlockName;
	}

	[DomainMethod]
	public List<CollectResourceResult> CollectAllResourcesFree(DataContext context)
	{
		List<CollectResourceResult> result = new List<CollectResourceResult>();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		MapDomain mapDomain = DomainManager.Map;
		foreach (Location blockLocation in ProfessionSkillHandle.GetSavageSkill_1_EffectRange(taiwu.GetLocation()))
		{
			MapBlockData blockData = mapDomain.GetBlock(blockLocation);
			if (126 != blockData.TemplateId)
			{
				for (sbyte resourceType = 0; resourceType < 6; resourceType++)
				{
					short currentResource;
					short maxResource;
					CollectResourceResult step = CalcCollectResourceResult(context.Random, blockData, resourceType, out currentResource, out maxResource);
					ApplyCollectResourceResult(context, taiwu, blockData, currentResource, maxResource, costResource: false, ref step);
					result.Add(step);
				}
			}
		}
		return result;
	}

	internal unsafe CollectResourceResult CalcCollectResourceResult(IRandomSource random, MapBlockData blockData, sbyte resourceType, out short currentResource, out short maxResource)
	{
		CollectResourceResult result = default(CollectResourceResult);
		currentResource = blockData.CurrResources.Items[resourceType];
		maxResource = Math.Max(blockData.MaxResources.Items[resourceType], (short)1);
		result.ResourceType = resourceType;
		if (_forceCollectResourceAmounts.TryGetValue(resourceType, out var amount))
		{
			result.ResourceCount = amount;
			_forceCollectResourceAmounts.Remove(resourceType);
		}
		else
		{
			result.ResourceCount = (short)GetCollectResourceAmount(random, blockData, resourceType);
			result.ResourceCount = (short)(result.ResourceCount * GameData.Domains.World.SharedMethods.GetGainResourcePercent(3) / 100);
		}
		return result;
	}

	internal unsafe void ApplyCollectResourceResult(DataContext ctx, GameData.Domains.Character.Character character, MapBlockData blockData, short currentResource, short maxResource, bool costResource, ref CollectResourceResult result)
	{
		IRandomSource random = ctx.Random;
		int charId = character.GetId();
		sbyte resourceType = result.ResourceType;
		character.ChangeResource(ctx, resourceType, result.ResourceCount);
		short itemTemplateId = blockData.GetCollectItemTemplateId(random, resourceType);
		CValuePercentBonus buildingBonus = DomainManager.Building.GetBuildingBlockEffect(blockData.GetLocation(), EBuildingScaleEffect.CollectResourceGetItemBonus);
		int collectItemChance = blockData.GetCollectItemChance(resourceType) * buildingBonus;
		if (_forceCollectResourceItems.TryGetValue(resourceType, out var templateKey))
		{
			if (templateKey.IsValid())
			{
				ItemKey itemKey = DomainManager.Item.CreateItem(ctx, templateKey.ItemType, templateKey.TemplateId);
				character.AddInventoryItem(ctx, itemKey, 1);
				result.ItemDisplayData = DomainManager.Item.GetItemDisplayData(itemKey, charId);
				result.ItemDisplayData.Amount = 1;
				_forceCollectResourceItems[resourceType] = TemplateKey.Invalid;
			}
		}
		else if (itemTemplateId >= 0 && random.CheckPercentProb(collectItemChance))
		{
			int neighborOddsMultiplier = 1;
			if (charId == DomainManager.Taiwu.GetTaiwuCharId())
			{
				MapBlockItem blockConfig = MapBlock.Instance[blockData.TemplateId];
				List<MapBlockData> neighborList = ObjectPool<List<MapBlockData>>.Instance.Get();
				GetNeighborBlocks(blockData.AreaId, blockData.BlockId, neighborList);
				for (int i = 0; i < neighborList.Count; i++)
				{
					if (blockConfig.ResourceCollectionType == MapBlock.Instance[neighborList[i].TemplateId].ResourceCollectionType)
					{
						neighborOddsMultiplier += 2;
					}
				}
				ObjectPool<List<MapBlockData>>.Instance.Return(neighborList);
			}
			UpgradeCollectMaterial(random, blockData.GetResourceCollectionConfig(), resourceType, maxResource, currentResource, neighborOddsMultiplier, ref itemTemplateId);
			ItemKey itemKey2 = DomainManager.Item.CreateItem(ctx, 5, itemTemplateId);
			character.AddInventoryItem(ctx, itemKey2, 1);
			result.ItemDisplayData = DomainManager.Item.GetItemDisplayData(itemKey2, charId);
			result.ItemDisplayData.Amount = 1;
		}
		else
		{
			result.ItemDisplayData = null;
		}
		if (DomainManager.Global.IsInNormalWorld() && charId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			ProfessionFormulaItem formula1 = ProfessionFormula.Instance[0];
			int addSeniority1 = formula1.Calculate(currentResource);
			int addSeniority2 = 0;
			if (result.ItemDisplayData != null)
			{
				ProfessionFormulaItem formula2 = ProfessionFormula.Instance[1];
				addSeniority2 = formula2.Calculate((int)Math.Min(2147483647L, result.ItemDisplayData.Value));
			}
			DomainManager.Extra.ChangeProfessionSeniority(ctx, 0, addSeniority1 + addSeniority2);
		}
		if (costResource)
		{
			ResourceTypeItem resourceConfig = Config.ResourceType.Instance[resourceType];
			blockData.CurrResources.Items[resourceType] = (short)Math.Max(currentResource - resourceConfig.ResourceReducePerCollection, 0);
			SetBlockData(ctx, blockData);
			AddBlockMalice(ctx, blockData.AreaId, blockData.BlockId, 10);
		}
		VillagerWorkData workData = DomainManager.Taiwu.GetVillagerMapWorkData(blockData.AreaId, blockData.BlockId, 10);
		if (workData != null)
		{
			DomainManager.Taiwu.SetVillagerWork(ctx, workData.CharacterId, workData);
		}
	}

	public void SetForceCollectResourceAmount(sbyte resourceType, int amount)
	{
		_forceCollectResourceAmounts[resourceType] = amount;
	}

	public void SetForceCollectResourceItem(sbyte resourceType, TemplateKey templateKey)
	{
		_forceCollectResourceItems[resourceType] = templateKey;
	}

	public void UpgradeCollectMaterial(IRandomSource random, ResourceCollectionItem collectionConfig, sbyte resourceType, short maxResource, short currentResource, int neighborOddsMultiplier, ref short itemTemplateId)
	{
		sbyte maxAddGrade = collectionConfig.MaxAddGrade[resourceType];
		int gradeUpOdds = collectionConfig.GradeUpOdds[resourceType] + Math.Max(maxResource - 100, 0) / 10 * neighborOddsMultiplier;
		if (!random.CheckPercentProb(gradeUpOdds))
		{
			return;
		}
		int odds = gradeUpOdds * currentResource / maxResource;
		if (odds >= 100)
		{
			itemTemplateId += maxAddGrade;
			return;
		}
		for (int i = 0; i < maxAddGrade; i++)
		{
			if (random.CheckPercentProb(odds))
			{
				itemTemplateId++;
			}
		}
	}

	[DomainMethod]
	public CollectResourceResult CollectResource(DataContext context, int charId, sbyte resourceType, bool costTime = true, bool costResource = true)
	{
		if (costTime && DomainManager.World.GetLeftDaysInCurrMonth() == 0)
		{
			throw new Exception("No enough time for resource collection");
		}
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		MapBlockData blockData = GetBlock(character.GetLocation());
		short currentResource;
		short maxResource;
		CollectResourceResult result = CalcCollectResourceResult(context.Random, blockData, resourceType, out currentResource, out maxResource);
		ApplyCollectResourceResult(context, character, blockData, currentResource, maxResource, costResource, ref result);
		return result;
	}

	[DomainMethod]
	public List<MapBlockData> GetMapBlockDataList(List<Location> locationList)
	{
		return GetMapBlockDataListOptional(locationList);
	}

	[DomainMethod]
	public List<MapBlockData> GetMapBlockDataListOptional(List<Location> locationList, bool includeRoot = false, bool includeBelong = false)
	{
		List<MapBlockData> dataList = new List<MapBlockData>();
		if (locationList != null)
		{
			for (int i = 0; i < locationList.Count; i++)
			{
				MapBlockData block = GetBlock(locationList[i]);
				dataList.Add(block);
				if (includeRoot && block.RootBlockId > -1)
				{
					MapBlockData rootBlock = GetBlock(block.AreaId, block.RootBlockId);
					dataList.Add(rootBlock);
				}
				if (includeBelong && block.BelongBlockId > -1)
				{
					MapBlockData belongBlock = GetBlock(block.AreaId, block.BelongBlockId);
					dataList.Add(belongBlock);
				}
			}
		}
		return dataList;
	}

	[DomainMethod]
	public bool IsContainsPurpleBamboo(short areaId)
	{
		using (IEnumerator<short> enumerator = IterAreaPurpleBambooTemplateIds(areaId).GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				short _ = enumerator.Current;
				return true;
			}
		}
		return false;
	}

	public IEnumerable<short> IterAreaPurpleBambooTemplateIds(short areaId)
	{
		byte size = GetAreaSize(areaId);
		for (short i = 0; i < size * size; i++)
		{
			MapBlockData blockData = GetBlock(areaId, i);
			if (blockData.FixedCharacterSet != null)
			{
				foreach (int charId in blockData.FixedCharacterSet)
				{
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
					if (character.GetXiangshuType() == 3)
					{
						yield return character.GetTemplateId();
					}
				}
			}
		}
	}

	public IEnumerable<NameAndAvatarWithFavor> GetPurpleBambooNameAndAvatar(short areaId)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		byte size = GetAreaSize(areaId);
		for (short i = 0; i < size * size; i++)
		{
			MapBlockData blockData = GetBlock(areaId, i);
			if (blockData.FixedCharacterSet != null)
			{
				foreach (int charId in blockData.FixedCharacterSet.Where((int objectId) => DomainManager.Character.GetElement_Objects(objectId).GetXiangshuType() == 3))
				{
					yield return new NameAndAvatarWithFavor
					{
						NameAndAvatar = new NameAndAvatar
						{
							Avatar = DomainManager.Character.GetAvatarRelatedData(charId),
							CharId = charId,
							IsTaiwu = (charId == taiwuCharId),
							Name = DomainManager.Character.GetNameRelatedData(charId)
						},
						Favor = DomainManager.Character.GetFavorability(charId, taiwuCharId)
					};
				}
			}
		}
	}

	public IEnumerable<NameAndAvatar> GetNonPurpleBambooNameAndAvatar(short areaId)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		byte size = GetAreaSize(areaId);
		for (short i = 0; i < size * size; i++)
		{
			MapBlockData blockData = GetBlock(areaId, i);
			if (blockData.FixedCharacterSet != null)
			{
				foreach (int charId in blockData.FixedCharacterSet.Where((int objectId) => DomainManager.Character.GetElement_Objects(objectId).GetXiangshuType() != 3))
				{
					yield return new NameAndAvatar
					{
						Avatar = DomainManager.Character.GetAvatarRelatedData(charId),
						CharId = charId,
						IsTaiwu = (charId == taiwuCharId),
						Name = DomainManager.Character.GetNameRelatedData(charId)
					};
				}
			}
		}
	}

	[DomainMethod]
	public List<short> GetBelongBlockTemplateIdList(List<Location> locationList)
	{
		List<short> templateIdList = new List<short>();
		if (locationList != null)
		{
			for (int i = 0; i < locationList.Count; i++)
			{
				Location location = locationList[i];
				short belongBlockId = GetBlock(location).BelongBlockId;
				templateIdList.Add((short)((belongBlockId >= 0) ? GetBlock(location.AreaId, belongBlockId).TemplateId : (-1)));
			}
		}
		return templateIdList;
	}

	[DomainMethod]
	public LocationNameRelatedData GetLocationNameRelatedData(Location location)
	{
		if (location.AreaId < 0)
		{
			return new LocationNameRelatedData(-1);
		}
		MapAreaData area = _areas[location.AreaId];
		LocationNameRelatedData data = new LocationNameRelatedData(area.GetTemplateId());
		if (location.BlockId < 0)
		{
			return data;
		}
		MapBlockData block = GetBlock(location).GetRootBlock();
		if (block.IsCityTown())
		{
			data.SettlementMapBlockTemplateId = block.TemplateId;
			int settlementIdx = area.GetSettlementIndex(block.BlockId);
			SettlementInfo settlementInfo = area.SettlementInfos[settlementIdx];
			data.SettlementRandomNameId = settlementInfo.RandomNameId;
		}
		else
		{
			var (settlementIdx2, direction) = area.GetReferenceSettlementAndDirection(location.BlockId);
			if (settlementIdx2 >= 0)
			{
				SettlementInfo settlementInfo2 = area.SettlementInfos[settlementIdx2];
				MapBlockData settlementBlock = GetBlock(location.AreaId, settlementInfo2.BlockId);
				data.SettlementMapBlockTemplateId = settlementBlock.TemplateId;
				data.SettlementRandomNameId = settlementInfo2.RandomNameId;
			}
			data.Direction = direction;
		}
		return data;
	}

	[DomainMethod]
	public List<LocationNameRelatedData> GetLocationNameRelatedDataList(List<Location> locations)
	{
		int locationsCount = locations.Count;
		List<LocationNameRelatedData> dataList = new List<LocationNameRelatedData>(locationsCount);
		for (int i = 0; i < locationsCount; i++)
		{
			dataList.Add(GetLocationNameRelatedData(locations[i]));
		}
		return dataList;
	}

	[DomainMethod]
	public Location ChangeBlockTemplate(DataContext context, Location location, short blockTemplateId, bool isTurnVisible)
	{
		MapBlockData blockData = GetBlock(location);
		ChangeBlockTemplate(context, blockData, blockTemplateId);
		if (SharedConstValue.SwordTombId2XiangshuId.Keys.Contains(blockTemplateId))
		{
			List<Location> list = GetBlockLocationGroup(location);
			foreach (Location l in list)
			{
				if (DomainManager.Extra.TryGetHeavenlyTreeByLocation(l, out var tree))
				{
					DomainManager.Extra.RemoveHeavenlyTree(context, tree.Id);
				}
			}
		}
		if (isTurnVisible)
		{
			SetBlockAndViewRangeVisible(context, location.AreaId, location.BlockId);
		}
		return blockData.GetRootBlock().GetLocation();
	}

	public bool TryGetBlock(Location location, out MapBlockData blockData)
	{
		blockData = null;
		short areaId = location.AreaId;
		if ((areaId < 0 || areaId >= 141) ? true : false)
		{
			return false;
		}
		short areaId2 = location.AreaId;
		AreaBlockCollection areaBlocks = GetAreaBlockCollection(areaId2);
		short blockId = location.BlockId;
		if (IsAreaBroken(areaId2))
		{
			blockId += (short)(25 * (areaId2 - 45));
		}
		return areaBlocks?.TryGetValue(blockId, out blockData) ?? false;
	}

	public MapBlockData GetBlock(short areaId, short blockId)
	{
		if (TryGetBlock(new Location(areaId, blockId), out var data))
		{
			return data;
		}
		throw new Exception($"Failed to get block at {areaId} {blockId}");
	}

	public MapBlockData GetBlock(Location key)
	{
		return GetBlock(key.AreaId, key.BlockId);
	}

	public bool SplitMultiBlock(DataContext context, MapBlockData blockData)
	{
		MapBlockItem config = blockData.GetConfig();
		if (config.SplitOrMergeBlockId < 0)
		{
			return false;
		}
		if (config.Size < 2)
		{
			return false;
		}
		return ChangeBlockTemplate(context, blockData, config.SplitOrMergeBlockId);
	}

	public bool MergeMultiBlock(DataContext context, MapBlockData blockData)
	{
		MapBlockItem config = blockData.GetConfig();
		if (config.SplitOrMergeBlockId < 0)
		{
			return false;
		}
		if (config.Size > 1)
		{
			return false;
		}
		return ChangeBlockTemplateByMerge(context, blockData, config.SplitOrMergeBlockId);
	}

	public bool ChangeBlockTemplate(DataContext context, MapBlockData blockData, short newTemplateId)
	{
		if (MapBlock.Instance[newTemplateId].Size > 1)
		{
			return ChangeBlockTemplateByMerge(context, blockData, newTemplateId);
		}
		blockData = blockData.GetRootBlock();
		List<MapBlockData> groupBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		groupBlocks.Clear();
		if (blockData.GroupBlockList == null)
		{
			groupBlocks.Add(blockData);
		}
		else
		{
			groupBlocks.Add(blockData);
			groupBlocks.AddRange(blockData.GroupBlockList);
			blockData.GroupBlockList = null;
		}
		foreach (MapBlockData block in groupBlocks)
		{
			block.RootBlockId = -1;
			block.ChangeTemplateId(newTemplateId);
			block.StopDestroyedByInitResources(context.Random);
			SetBlockData(context, block);
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(groupBlocks);
		return true;
	}

	public bool ChangeBlockTemplateByMerge(DataContext context, MapBlockData blockData, short newTemplateId)
	{
		byte areaSize = GetAreaSize(blockData.AreaId);
		Span<MapBlockData> areaBlocks = GetAreaBlocks(blockData.AreaId);
		ByteCoordinate blockPos = ByteCoordinate.IndexToCoordinate(blockData.BlockId, areaSize);
		MapBlockItem newConfig = MapBlock.Instance[newTemplateId];
		for (byte x = 0; x < newConfig.Size; x++)
		{
			for (byte y = 0; y < newConfig.Size; y++)
			{
				ByteCoordinate childPos = blockPos + new ByteCoordinate(x, y);
				short childId = ByteCoordinate.CoordinateToIndex(childPos, areaSize);
				MapBlockData block = areaBlocks[childId];
				Tester.Assert(block.IsPassable(), "childBlock.IsPassable()");
				if (block == blockData)
				{
					block.ChangeTemplateId(newTemplateId);
				}
				else
				{
					block.ChangeTemplateId(-1);
					block.SetToSizeBlock(blockData);
				}
				block.StopDestroyedByInitResources(context.Random);
				SetBlockData(context, block);
			}
		}
		blockData.SetVisible(blockData.Visible, context);
		return true;
	}

	private void GetInSightBlocks(List<MapBlockData> inSightBlocks)
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (taiwuLocation.IsValid())
		{
			MapBlockData taiwuBlock = GetBlock(taiwuLocation);
			GetNeighborBlocks(taiwuLocation.AreaId, taiwuLocation.BlockId, inSightBlocks, taiwuBlock.GetConfig().ViewRange);
			inSightBlocks.Add(taiwuBlock.GetRootBlock());
		}
	}

	public void GetNeighborBlocks(short areaId, short blockId, List<MapBlockData> neighborBlocks, int maxSteps = 1)
	{
		byte areaSize = GetAreaSize(areaId);
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
		MapBlockData centerBlock = blocks[blockId].GetRootBlock();
		ByteCoordinate blockPos = ByteCoordinate.IndexToCoordinate(centerBlock.BlockId, areaSize);
		byte blockSize = centerBlock.GetConfig().Size;
		neighborBlocks.Clear();
		for (byte x = (byte)Math.Max(blockPos.X - maxSteps, 0); x < Math.Min(blockPos.X + blockSize + maxSteps, areaSize); x++)
		{
			for (byte y = (byte)Math.Max(blockPos.Y - maxSteps, 0); y < Math.Min(blockPos.Y + blockSize + maxSteps, areaSize); y++)
			{
				MapBlockData neighborBlock = blocks[ByteCoordinate.CoordinateToIndex(new ByteCoordinate(x, y), areaSize)].GetRootBlock();
				if (neighborBlock.BlockId != centerBlock.BlockId && centerBlock.GetManhattanDistanceToPos(x, y) <= maxSteps && neighborBlock.IsPassable() && !neighborBlocks.Contains(neighborBlock))
				{
					neighborBlocks.Add(neighborBlock);
				}
			}
		}
	}

	public void GetLocationByDistance(Location centerLocation, int minStep, int maxStep, ref List<MapBlockData> mapBlockList)
	{
		ByteCoordinate centerBlockPos = DomainManager.Map.GetBlock(centerLocation).GetBlockPos();
		DomainManager.Map.GetRealNeighborBlocks(centerLocation.AreaId, centerLocation.BlockId, mapBlockList, maxStep, minStep <= 0);
		if (minStep <= 0)
		{
			return;
		}
		for (int i = mapBlockList.Count - 1; i >= 0; i--)
		{
			if (mapBlockList[i].GetManhattanDistanceToPos(centerBlockPos.X, centerBlockPos.Y) < minStep)
			{
				CollectionUtils.SwapAndRemove(mapBlockList, i);
			}
		}
	}

	public void GetTaiwuVillageDistanceLocations(List<Location> locations, int distance)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		byte areaSize = GetAreaSize(location.AreaId);
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(location.AreaId);
		ByteCoordinate blockPos = ByteCoordinate.IndexToCoordinate(location.BlockId, areaSize);
		for (byte x = 0; x < areaSize; x++)
		{
			for (byte y = 0; y < areaSize; y++)
			{
				if (MathF.Abs(x - blockPos.X) > (float)distance && MathF.Abs(y - blockPos.Y) > (float)distance)
				{
					short index = ByteCoordinate.CoordinateToIndex(new ByteCoordinate(x, y), areaSize);
					MapBlockData block = blocks[index].GetRootBlock();
					locations.Add(new Location(block.AreaId, block.BlockId));
				}
			}
		}
	}

	public void GetAreaNotSettlementLocations(List<Location> locations, short areaId)
	{
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
		MapAreaData areaMapData = DomainManager.Map.GetElement_Areas(areaId);
		List<short> settlementList = ObjectPool<List<short>>.Instance.Get();
		settlementList.Clear();
		for (int i = 0; i < areaMapData.SettlementInfos.Length; i++)
		{
			short blockId = areaMapData.SettlementInfos[i].BlockId;
			if (blockId >= 0)
			{
				settlementList.Add(blockId);
			}
		}
		for (int j = 0; j < blocks.Length; j++)
		{
			if (!settlementList.Contains(blocks[j].BlockId))
			{
				MapBlockData mapBlockData = blocks[j];
				locations.Add(new Location(mapBlockData.AreaId, mapBlockData.BlockId));
			}
		}
		ObjectPool<List<short>>.Instance.Return(settlementList);
	}

	public void GetRealNeighborBlocks(short areaId, short blockId, List<MapBlockData> neighborBlocks, int maxSteps = 1, bool includeCenter = false)
	{
		byte areaSize = GetAreaSize(areaId);
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
		MapBlockData centerBlock = blocks[blockId];
		ByteCoordinate blockPos = ByteCoordinate.IndexToCoordinate(centerBlock.BlockId, areaSize);
		neighborBlocks.Clear();
		for (byte x = (byte)Math.Max(blockPos.X - maxSteps, 0); x < Math.Min(blockPos.X + maxSteps + 1, areaSize); x++)
		{
			for (byte y = (byte)Math.Max(blockPos.Y - maxSteps, 0); y < Math.Min(blockPos.Y + maxSteps + 1, areaSize); y++)
			{
				ByteCoordinate pos = new ByteCoordinate(x, y);
				MapBlockData neighborBlock = blocks[ByteCoordinate.CoordinateToIndex(pos, areaSize)];
				if (neighborBlock.IsPassable() && blockPos.GetManhattanDistance(pos) <= maxSteps && (neighborBlock.BlockId != centerBlock.BlockId || includeCenter) && !neighborBlocks.Contains(neighborBlock))
				{
					neighborBlocks.Add(neighborBlock);
				}
			}
		}
	}

	public Location GetRandomGraveBlock(IRandomSource random, Location location)
	{
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(location.AreaId);
		MapBlockData centerBlock = blocks[location.BlockId].GetRootBlock();
		if (!centerBlock.IsCityTown() && centerBlock.BlockType != EMapBlockType.Station)
		{
			return location;
		}
		byte areaSize = GetAreaSize(location.AreaId);
		ByteCoordinate blockPos = ByteCoordinate.IndexToCoordinate(centerBlock.BlockId, areaSize);
		byte blockSize = centerBlock.GetConfig().Size;
		int range = ((blockSize >= 2) ? 3 : 2);
		List<short> blockRandomPool = ObjectPool<List<short>>.Instance.Get();
		blockRandomPool.Clear();
		for (byte x = (byte)Math.Max(blockPos.X - range, 0); x < Math.Min(blockPos.X + blockSize + range, areaSize); x++)
		{
			for (byte y = (byte)Math.Max(blockPos.Y - range, 0); y < Math.Min(blockPos.Y + blockSize + range, areaSize); y++)
			{
				MapBlockData block = blocks[ByteCoordinate.CoordinateToIndex(new ByteCoordinate(x, y), areaSize)];
				short blockId = block.BlockId;
				if (blockId != centerBlock.BlockId && block.IsPassable() && !block.IsCityTown() && block.BlockType != EMapBlockType.Station && centerBlock.GetManhattanDistanceToPos(x, y) <= range)
				{
					blockRandomPool.Add(blockId);
				}
			}
		}
		short randomBlockId = blockRandomPool[random.Next(blockRandomPool.Count)];
		ObjectPool<List<short>>.Instance.Return(blockRandomPool);
		return new Location(location.AreaId, randomBlockId);
	}

	public unsafe short GetRandomAdjacentBlockId(IRandomSource random, short areaId, short blockId)
	{
		byte areaSize = GetAreaSize(areaId);
		int centerX = blockId % areaSize;
		int centerY = blockId / areaSize;
		sbyte* pCoords = stackalloc sbyte[8]
		{
			(sbyte)(centerX - 1),
			(sbyte)centerY,
			(sbyte)(centerX + 1),
			(sbyte)centerY,
			(sbyte)centerX,
			(sbyte)(centerY - 1),
			(sbyte)centerX,
			(sbyte)(centerY + 1)
		};
		Span<MapBlockData> blocks = GetAreaBlocks(areaId);
		for (int candidatesCount = 4; candidatesCount > 0; candidatesCount--)
		{
			int selectedIndex = random.Next(candidatesCount);
			sbyte selectedX = pCoords[selectedIndex * 2];
			sbyte selectedY = pCoords[selectedIndex * 2 + 1];
			if (selectedX >= 0 && selectedX < areaSize && selectedY >= 0 && selectedY < areaSize)
			{
				int selectedBlockId = selectedX + selectedY * areaSize;
				MapBlockData selectedBlock = blocks[selectedBlockId];
				if (selectedBlock.IsPassable())
				{
					return (short)selectedBlockId;
				}
			}
			short* pCombinedCoords = (short*)pCoords;
			short last = pCombinedCoords[candidatesCount - 1];
			pCombinedCoords[selectedIndex] = last;
		}
		throw new Exception($"Failed to get passable adjacent block: ({areaId}, {blockId})");
	}

	public short GetRandomEdgeBlock(IRandomSource random, short areaId)
	{
		int depth = 0;
		short blockId = -1;
		while (blockId < 0)
		{
			if (++depth > 100)
			{
				AdaptableLog.Warning($"Failed to get a random edge block due to depth overflow, areaId = {areaId}");
				break;
			}
			sbyte edgeType = (sbyte)random.Next(4);
			short edgeBlockId = GetRandomEdgeBlock(random, areaId, edgeType);
			if (TryGetBlock(new Location(areaId, edgeBlockId), out var block) && block.IsPassable())
			{
				blockId = edgeBlockId;
			}
		}
		return blockId;
	}

	public short GetRandomEdgeBlock(IRandomSource random, short areaId, sbyte edgeType)
	{
		Span<MapBlockData> blocks = GetAreaBlocks(areaId);
		List<short> blockIdList = ObjectPool<List<short>>.Instance.Get();
		byte areaSize = GetAreaSize(areaId);
		blockIdList.Clear();
		for (byte i = 0; i < areaSize; i++)
		{
			for (byte j = 0; j < areaSize; j++)
			{
				int num;
				switch (edgeType)
				{
				default:
					num = (byte)(areaSize - 1 - i);
					break;
				case 0:
					num = i;
					break;
				case 2:
				case 3:
					num = j;
					break;
				}
				byte x = (byte)num;
				int num2;
				switch (edgeType)
				{
				default:
					num2 = (byte)(areaSize - 1 - i);
					break;
				case 3:
					num2 = i;
					break;
				case 0:
				case 1:
					num2 = j;
					break;
				}
				byte y = (byte)num2;
				ByteCoordinate coord = new ByteCoordinate(x, y);
				short blockId = ByteCoordinate.CoordinateToIndex(coord, areaSize);
				if (blocks[blockId].IsPassable())
				{
					blockIdList.Add(blockId);
				}
			}
			if (blockIdList.Count > 0)
			{
				break;
			}
		}
		short result = (short)((blockIdList.Count > 0) ? blockIdList[random.Next(blockIdList.Count)] : 0);
		ObjectPool<List<short>>.Instance.Return(blockIdList);
		return result;
	}

	public void EnsureBlockVisible(DataContext context, Location location)
	{
		if (location.IsValid())
		{
			MapBlockData block = GetBlock(location);
			if (!block.Visible)
			{
				block.SetVisible(visible: true, context);
			}
		}
	}

	public void HideAllBlocks(DataContext context)
	{
		List<MapBlockData> exceptBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		GetInSightBlocks(exceptBlocks);
		for (short areaId = 0; areaId < 141; areaId++)
		{
			HideAllBlocks(context, areaId, exceptBlocks);
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(exceptBlocks);
		DomainManager.Merchant.RefreshCaravanInTaiwuState(context);
	}

	public void HideAllBlocks(DataContext context, short areaId, List<MapBlockData> exceptBlocks)
	{
		Span<MapBlockData> blocks = GetAreaBlocks(areaId);
		for (int i = 0; i < blocks.Length; i++)
		{
			MapBlockData block = blocks[i];
			if (block.IsPassable())
			{
				bool visible = exceptBlocks.Contains(block) || exceptBlocks.Contains(block.GetRootBlock());
				if (visible != block.Visible)
				{
					block.SetVisible(visible, context);
				}
			}
		}
	}

	public void AddBlockMalice(DataContext context, short areaId, short blockId, int addValue)
	{
		MapBlockData block = GetBlock(areaId, blockId);
		short maxMalice = block.GetMaxMalice();
		if (maxMalice > 0)
		{
			block.Malice = (short)Math.Clamp(block.Malice + addValue, 0, block.GetMaxMalice());
			SetBlockData(context, block);
		}
	}

	public void AddBlockItem(DataContext context, MapBlockData block, ItemKey itemKey, int amount)
	{
		SortedList<ItemKeyAndDate, int> items = block.Items;
		if (items != null && items.Count > 500)
		{
			DomainManager.Item.RemoveItem(context, itemKey);
		}
		else
		{
			OfflineAddBlockItem(block, itemKey, amount);
		}
		SetBlockData(context, block);
	}

	public void AddBlockItems(DataContext context, MapBlockData block, List<(ItemKey itemKey, int amount)> items)
	{
		if (block.Items?.Count + items.Count > 500)
		{
			DomainManager.Item.RemoveItems(context, items);
		}
		else
		{
			OfflineAddBlockItems(block, items);
		}
		SetBlockData(context, block);
	}

	public void RemoveBlockItem(DataContext context, MapBlockData block, ItemKeyAndDate itemKeyAndDate)
	{
		OfflineRemoveBlockItem(block, itemKeyAndDate);
		SetBlockData(context, block);
	}

	private void OfflineAddBlockItem(MapBlockData block, ItemKey itemKey, int amount)
	{
		int locationId = block.GetLocation().GetHashCode();
		DomainManager.Item.SetOwner(itemKey, ItemOwnerType.MapBlock, locationId);
		block.AddItem(itemKey, amount);
	}

	private void OfflineAddBlockItems(MapBlockData block, List<(ItemKey itemKey, int amount)> items)
	{
		int locationId = block.GetLocation().GetHashCode();
		int i = 0;
		for (int count = items.Count; i < count; i++)
		{
			var (itemKey, amount) = items[i];
			DomainManager.Item.SetOwner(itemKey, ItemOwnerType.MapBlock, locationId);
		}
		block.AddItems(items);
	}

	private void OfflineRemoveBlockItem(MapBlockData block, ItemKeyAndDate itemKeyAndDate)
	{
		DomainManager.Item.RemoveOwner(itemKeyAndDate.ItemKey, ItemOwnerType.MapBlock, block.GetLocation().GetHashCode());
		block.RemoveItem(itemKeyAndDate);
	}

	private void OfflineRemoveBlockItemByCount(MapBlockData block, ItemKeyAndDate itemKeyAndDate, int count)
	{
		DomainManager.Item.RemoveOwner(itemKeyAndDate.ItemKey, ItemOwnerType.MapBlock, block.GetLocation().GetHashCode());
		block.RemoveItemByCount(itemKeyAndDate, count);
	}

	public void InitializeOwnedItems()
	{
		for (short areaId = 0; areaId < 141; areaId++)
		{
			Span<MapBlockData> blocks = GetAreaBlocks(areaId);
			int blockIdx = 0;
			for (int blocksCount = blocks.Length; blockIdx < blocksCount; blockIdx++)
			{
				MapBlockData block = blocks[blockIdx];
				SortedList<ItemKeyAndDate, int> blockItems = block.Items;
				if (blockItems != null)
				{
					Location location = new Location(areaId, block.BlockId);
					IList<ItemKeyAndDate> keys = blockItems.Keys;
					int itemIdx = 0;
					for (int elementCount = blockItems.Count; itemIdx < elementCount; itemIdx++)
					{
						ItemKey itemKey = keys[itemIdx].ItemKey;
						DomainManager.Item.SetOwner(itemKey, ItemOwnerType.MapBlock, location.GetHashCode());
					}
				}
			}
		}
	}

	public List<(Location, short)> CalcBlockTravelRoute(IRandomSource random, Location start, Location end, bool isMerchant = true)
	{
		List<(Location, short)> route = new List<(Location, short)>();
		List<(short, short)> areaRoute = new List<(short, short)>();
		Location currLocation = start;
		sbyte startEdge = -1;
		AStarMap aStarMap = new AStarMap();
		List<ByteCoordinate> pathInArea = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		List<ByteCoordinate> avoidPosList = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		List<short> settlementBlockIdList = ObjectPool<List<short>>.Instance.Get();
		Dictionary<TravelRouteKey, TravelRoute> findRouteDict = ((isMerchant || start.AreaId >= 135 || DomainManager.World.GetWorldFunctionsStatus(4)) ? _travelRouteDict : _bornStateTravelRouteDict);
		areaRoute.Add((start.AreaId, 0));
		if (start.AreaId != end.AreaId)
		{
			TravelRouteKey routeKey = new TravelRouteKey(start.AreaId, end.AreaId);
			bool reverse = routeKey.FromAreaId > routeKey.ToAreaId;
			if (reverse)
			{
				routeKey.Reverse();
			}
			TravelRoute travelRoute = findRouteDict[routeKey];
			if (!reverse)
			{
				for (int i = 0; i < travelRoute.CostList.Count; i++)
				{
					areaRoute.Add((travelRoute.AreaList[i + 1], travelRoute.CostList[i]));
				}
			}
			else
			{
				for (int i2 = travelRoute.CostList.Count - 1; i2 >= 0; i2--)
				{
					areaRoute.Add((travelRoute.AreaList[i2], travelRoute.CostList[i2]));
				}
			}
		}
		for (int j = 0; j < areaRoute.Count; j++)
		{
			(short, short) routePoint = areaRoute[j];
			short areaId = routePoint.Item1;
			byte areaSize = GetAreaSize(areaId);
			if (startEdge >= 0)
			{
				short startBlockId = GetRandomEdgeBlock(random, areaId, startEdge);
				currLocation.AreaId = areaId;
				currLocation.BlockId = startBlockId;
				route.Add((currLocation, routePoint.Item2));
			}
			aStarMap.InitMap(areaSize, areaSize, (ByteCoordinate coord) => GetBlock(areaId, ByteCoordinate.CoordinateToIndex(coord, areaSize)).MoveCost);
			avoidPosList.Clear();
			if (isMerchant && areaId < 45)
			{
				settlementBlockIdList.Clear();
				SettlementInfo[] settlementInfos = _areas[areaId].SettlementInfos;
				for (int num = 0; num < settlementInfos.Length; num++)
				{
					SettlementInfo settlementInfo = settlementInfos[num];
					if (settlementInfo.BlockId >= 0)
					{
						MapBlockData blockData = GetBlock(areaId, settlementInfo.BlockId);
						int groupBlockCount = blockData.GroupBlockList?.Count ?? 0;
						if (groupBlockCount > 1)
						{
							settlementBlockIdList.Add(blockData.GroupBlockList.GetRandom(random).BlockId);
						}
						else
						{
							settlementBlockIdList.Add(settlementInfo.BlockId);
						}
					}
				}
				if (settlementBlockIdList.Count > 1)
				{
					MapBlockData curBlockData = GetBlock(areaId, currLocation.BlockId);
					settlementBlockIdList.Sort(delegate(short aBlockId, short bBlockId)
					{
						MapBlockData block = GetBlock(areaId, aBlockId);
						int num2 = ((block.GetRootBlock().BlockId == end.BlockId) ? int.MaxValue : curBlockData.GetBlockPos().GetManhattanDistance(block.GetBlockPos()));
						MapBlockData block2 = GetBlock(areaId, bBlockId);
						int value = ((block2.GetRootBlock().BlockId == end.BlockId) ? int.MaxValue : curBlockData.GetBlockPos().GetManhattanDistance(block2.GetBlockPos()));
						return num2.CompareTo(value);
					});
				}
				foreach (short cityBlockId in settlementBlockIdList)
				{
					CalcPathInArea(aStarMap, route, pathInArea, areaId, areaSize, currLocation.BlockId, cityBlockId);
					currLocation.BlockId = cityBlockId;
					avoidPosList.AddRange(pathInArea);
				}
			}
			if (j == areaRoute.Count - 1)
			{
				if (isMerchant && route.Exists(((Location, short) r) => r.Item1 == end))
				{
					MapBlockData blockData2 = GetBlock(areaId, end.BlockId);
					List<MapBlockData> blockList = ObjectPool<List<MapBlockData>>.Instance.Get();
					int groupBlockCount2 = blockData2.GroupBlockList?.Count ?? 0;
					if (groupBlockCount2 > 1)
					{
						blockList.AddRange(blockData2.GroupBlockList.Where((MapBlockData b) => b.GetLocation() != end));
						if (blockList.Count > 0)
						{
							end.BlockId = blockList.GetRandom(random).BlockId;
						}
					}
					ObjectPool<List<MapBlockData>>.Instance.Return(blockList);
				}
				CalcPathInArea(aStarMap, route, pathInArea, areaId, areaSize, currLocation.BlockId, end.BlockId, avoidPosList);
			}
			else
			{
				sbyte[] fromPos = DomainManager.Map.GetElement_Areas(routePoint.Item1).GetConfig().WorldMapPos;
				sbyte[] toPos = DomainManager.Map.GetElement_Areas(areaRoute[j + 1].Item1).GetConfig().WorldMapPos;
				startEdge = MapAreaEdge.GetEnterEdge(fromPos, toPos);
				short blockId = GetRandomEdgeBlock(random, areaId, MapAreaEdge.GetOppositeEdge(startEdge));
				CalcPathInArea(aStarMap, route, pathInArea, areaId, areaSize, currLocation.BlockId, blockId, avoidPosList);
			}
		}
		ObjectPool<List<ByteCoordinate>>.Instance.Return(pathInArea);
		ObjectPool<List<ByteCoordinate>>.Instance.Return(avoidPosList);
		ObjectPool<List<short>>.Instance.Return(settlementBlockIdList);
		return route;
	}

	[DomainMethod]
	public List<Location> GetPathInAreaWithoutCost(Location start, Location end)
	{
		List<Location> locations = new List<Location>();
		GetPathInAreaWithoutCost(start, end, locations);
		return locations;
	}

	public static void GetPathInAreaWithoutCost(Location start, Location end, List<Location> locations, List<ByteCoordinate> avoidPosList = null)
	{
		locations.Clear();
		if (start.Equals(end))
		{
			return;
		}
		byte areaSize = DomainManager.Map.GetAreaSize(start.AreaId);
		_aStarMap.InitMap(areaSize, areaSize, delegate(ByteCoordinate byteCoordinate)
		{
			MapBlockData block = DomainManager.Map.GetBlock(start.AreaId, ByteCoordinate.CoordinateToIndex(byteCoordinate, areaSize));
			return (sbyte)(block.IsPassable() ? 1 : sbyte.MaxValue);
		});
		List<ByteCoordinate> pathInArea = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		_aStarMap.FindWay(ByteCoordinate.IndexToCoordinate(start.BlockId, areaSize), ByteCoordinate.IndexToCoordinate(end.BlockId, areaSize), ref pathInArea, avoidPosList);
		foreach (ByteCoordinate coord in pathInArea)
		{
			Location location = new Location(start.AreaId, ByteCoordinate.CoordinateToIndex(coord, areaSize));
			locations.Add(location);
		}
		ObjectPool<List<ByteCoordinate>>.Instance.Return(pathInArea);
	}

	public bool ContainsCharacter(Location location, int charId)
	{
		MapBlockData block = GetBlock(location.AreaId, location.BlockId);
		return block.CharacterSet?.Contains(charId) ?? false;
	}

	public bool BlockWillTriggerHereticAttack(short areaId, short blockId)
	{
		MapBlockData blockData = GetBlock(areaId, blockId);
		return blockData.TemplateEnemyList != null && blockData.TemplateEnemyList.Count > 0;
	}

	public bool BlockContainsInfectedCharacter(short areaId, short blockId)
	{
		MapBlockData blockData = GetBlock(areaId, blockId);
		return blockData.InfectedCharacterSet != null && blockData.InfectedCharacterSet.Count > 0;
	}

	public void GetHereticAttackBlockCoords(short areaId, List<ByteCoordinate> result)
	{
		byte areaSize = GetAreaSize(areaId);
		for (short i = 0; i < areaSize * areaSize; i++)
		{
			MapBlockData blockData = GetBlock(areaId, i);
			if (blockData.TemplateEnemyList != null && blockData.TemplateEnemyList.Count > 0)
			{
				result.Add(ByteCoordinate.IndexToCoordinate(i, areaSize));
			}
		}
	}

	public void GetInfectedCharacterBlockCoords(short areaId, List<ByteCoordinate> result)
	{
		byte areaSize = GetAreaSize(areaId);
		for (short i = 0; i < areaSize * areaSize; i++)
		{
			MapBlockData blockData = GetBlock(areaId, i);
			if (blockData.InfectedCharacterSet != null && blockData.InfectedCharacterSet.Count > 0)
			{
				result.Add(ByteCoordinate.IndexToCoordinate(i, areaSize));
			}
		}
	}

	[DomainMethod]
	public List<Location> GetPathInAreaWithAvoidSettings(Location start, Location end)
	{
		List<Location> locations = new List<Location>();
		GetPathInAreaWithAvoidSettings(start, end, locations);
		return locations;
	}

	public void GetPathInAreaWithAvoidSettings(Location start, Location end, List<Location> locations)
	{
		locations.Clear();
		if (!start.Equals(end) && start.AreaId == end.AreaId)
		{
			SharedGlobalSettings settings = GlobalDomain.Settings;
			List<ByteCoordinate> avoidPosList = ObjectPool<List<ByteCoordinate>>.Instance.Get();
			avoidPosList.Clear();
			if (settings.AvoidHereticAttackBlocks)
			{
				GetHereticAttackBlockCoords(start.AreaId, avoidPosList);
			}
			if (settings.AvoidInfectedCharacterBlocks)
			{
				GetInfectedCharacterBlockCoords(start.AreaId, avoidPosList);
			}
			GetPathInAreaWithoutCost(start, end, locations, avoidPosList);
			ObjectPool<List<ByteCoordinate>>.Instance.Return(avoidPosList);
		}
	}

	private void CalcPathInArea(AStarMap aStarMap, List<(Location, short)> route, List<ByteCoordinate> pathInArea, short areaId, byte areaSize, short startBlock, short endBlock, List<ByteCoordinate> avoidPosList = null)
	{
		pathInArea.Clear();
		aStarMap.FindWay(ByteCoordinate.IndexToCoordinate(startBlock, areaSize), ByteCoordinate.IndexToCoordinate(endBlock, areaSize), ref pathInArea, avoidPosList);
		for (int i = 1; i < pathInArea.Count; i++)
		{
			short blockId = ByteCoordinate.CoordinateToIndex(pathInArea[i], areaSize);
			route.Add((new Location(areaId, blockId), GetBlock(areaId, blockId).MoveCost));
		}
	}

	private short GetMerchantSettlementDestBlockId(short blockId, byte areaSize, byte blockSize, sbyte inEdge, sbyte outEdge)
	{
		if (blockSize < 2 || inEdge < 0 || outEdge < 0 || outEdge == MapAreaEdge.GetOppositeEdge(inEdge))
		{
			return blockId;
		}
		return inEdge switch
		{
			0 => (short)((outEdge == 2) ? (blockId + areaSize * (blockSize - 1)) : blockId), 
			1 => (short)((outEdge == 2) ? (blockId + areaSize * (blockSize - 1) + blockSize - 1) : (blockId + blockSize - 1)), 
			2 => (short)((outEdge == 0) ? (blockId + areaSize * (blockSize - 1)) : (blockId + areaSize * (blockSize - 1) + blockSize - 1)), 
			3 => (short)((outEdge == 2) ? blockId : (blockId + blockSize - 1)), 
			_ => blockId, 
		};
	}

	public unsafe int GetCollectResourceAmount(IRandomSource random, MapBlockData blockData, sbyte resourceType)
	{
		ResourceTypeItem resourceConfig = Config.ResourceType.Instance[resourceType];
		short currentResource = blockData.CurrResources.Items[resourceType];
		int resourceMultiplier = resourceConfig.CollectMultiplier;
		CValuePercentBonus buildingBonus = DomainManager.Building.GetBuildingBlockEffect(blockData.GetLocation(), EBuildingScaleEffect.CollectResourceIncomeBonus);
		return currentResource * (((currentResource >= 100) ? 60 : 40) + random.Next(-20, 21)) / 100 * resourceMultiplier * buildingBonus;
	}

	public List<Location> GetBlockLocationGroup(Location location, bool includeSelf = true)
	{
		List<Location> retList = new List<Location>();
		retList.Add(location);
		if (!location.IsValid())
		{
			return retList;
		}
		MapBlockData srcBlockData = DomainManager.Map.GetBlock(location);
		MapBlockData rootBlockData = null;
		short rootBlockId = srcBlockData.RootBlockId;
		if (-1 != rootBlockId)
		{
			rootBlockData = DomainManager.Map.GetBlockData(location.AreaId, rootBlockId);
			if (rootBlockData == null)
			{
				return retList;
			}
		}
		else
		{
			List<MapBlockData> groupBlockList = srcBlockData.GroupBlockList;
			if (groupBlockList != null && groupBlockList.Count > 0)
			{
				rootBlockData = srcBlockData;
			}
		}
		if (rootBlockData != null)
		{
			Location rootLocation = new Location(rootBlockData.AreaId, rootBlockData.BlockId);
			if (!retList.Contains(rootLocation))
			{
				retList.Add(rootLocation);
			}
			List<MapBlockData> groupList = rootBlockData.GroupBlockList;
			if (groupList != null && groupList.Count > 0)
			{
				groupList.ForEach(delegate(MapBlockData e)
				{
					Location item = new Location(e.AreaId, e.BlockId);
					if (!retList.Contains(item))
					{
						retList.Add(item);
					}
				});
			}
		}
		return retList;
	}

	public void MakeBlockDestroyed(DataContext context, MapBlockData blockData)
	{
		List<ItemKey> itemsToDestroy = ObjectPool<List<ItemKey>>.Instance.Get();
		blockData.MakeDestroyed(itemsToDestroy);
		SetBlockData(context, blockData);
		DomainManager.Item.RemoveItems(context, itemsToDestroy);
		ObjectPool<List<ItemKey>>.Instance.Return(itemsToDestroy);
	}

	public void MakeBlockDestroyedInAdvanceMonth(DataContext context, MapBlockData blockData)
	{
		blockData.MakeDestroyed(context.AdvanceMonthRelatedData.WorldItemsToBeRemoved);
		SetBlockData(context, blockData);
	}

	public void DestroyMapBlockItemsDirect(DataContext context, MapBlockData blockData)
	{
		List<ItemKey> itemsToDestroy = ObjectPool<List<ItemKey>>.Instance.Get();
		blockData.DestroyItemsDirect(itemsToDestroy);
		SetBlockData(context, blockData);
		DomainManager.Item.RemoveItems(context, itemsToDestroy);
		ObjectPool<List<ItemKey>>.Instance.Return(itemsToDestroy);
	}

	public void ClearBlockRandomEnemies(DataContext context, MapBlockData blockData)
	{
		if (blockData.TemplateEnemyList != null)
		{
			Location location = blockData.GetLocation();
			for (int i = blockData.TemplateEnemyList.Count - 1; i >= 0; i--)
			{
				MapTemplateEnemyInfo templateEnemy = blockData.TemplateEnemyList[i];
				Events.RaiseTemplateEnemyLocationChanged(context, templateEnemy, location, Location.Invalid);
			}
		}
	}

	[DomainMethod]
	public MapBlockCharacterCountData GetMapBlockCharacterCountData(Location location, List<short> orgTemplateIds = null)
	{
		MapBlockData blockData = DomainManager.Map.GetBlock(location);
		DomainManager.Extra.TryGetAnimalsByLocation(location, out var animals);
		MapBlockCharacterCountData result = new MapBlockCharacterCountData
		{
			CharacterCountDict = new Dictionary<short, int>
			{
				[0] = blockData.CharacterSet?.Count ?? 0,
				[8] = blockData.FixedCharacterSet?.Count ?? 0,
				[6] = blockData.InfectedCharacterSet?.Count ?? 0,
				[9] = animals?.Count ?? 0,
				[26] = blockData.GraveSet?.Count ?? 0,
				[27] = blockData.Items?.Count ?? 0
			}
		};
		SortedList<ItemKeyAndDate, int> items = blockData.Items;
		if (items != null && items.Count > 0)
		{
			result.TreasureExpectResult = DomainManager.Extra.FindTreasureExpect(location);
		}
		if (blockData.EnemyCharacterSet != null)
		{
			foreach (int charId in blockData.EnemyCharacterSet)
			{
				GameData.Domains.Character.Character targetChar = DomainManager.Character.GetElement_Objects(charId);
				if (targetChar.GetCreatingType() == 1)
				{
					AddCount(5);
				}
				else
				{
					AddCount(2);
				}
			}
		}
		if (blockData.TemplateEnemyList != null)
		{
			foreach (MapTemplateEnemyInfo enemyInfo in blockData.TemplateEnemyList)
			{
				CharacterItem charConfig = Config.Character.Instance[enemyInfo.TemplateId];
				if (charConfig?.GroupId >= 0)
				{
					charConfig = Config.Character.Instance[charConfig.GroupId];
				}
				if (charConfig == null)
				{
					continue;
				}
				short randomEnemyId = charConfig.RandomEnemyId;
				if (randomEnemyId >= 75 && randomEnemyId <= 83)
				{
					AddCount(43);
					continue;
				}
				RandomEnemyItem enemyConfig = RandomEnemy.Instance[charConfig.RandomEnemyId];
				if (enemyConfig == null)
				{
					AddCount(2);
				}
				else
				{
					AddCount((short)((enemyConfig.SpiritualDebt >= 0) ? 2 : 3));
				}
			}
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (blockData.CharacterSet != null)
		{
			foreach (int charId2 in blockData.CharacterSet)
			{
				if (charId2 == taiwuCharId)
				{
					continue;
				}
				GameData.Domains.Character.Character targetChar2 = DomainManager.Character.GetElement_Objects(charId2);
				RelatedCharacter selfToTarget;
				bool hasSelfToTargetRelation = DomainManager.Character.TryGetRelation(taiwuCharId, targetChar2.GetId(), out selfToTarget);
				RelatedCharacter targetToSelf;
				bool hasTargetToSelfRelation = DomainManager.Character.TryGetRelation(targetChar2.GetId(), taiwuCharId, out targetToSelf);
				if (hasSelfToTargetRelation || hasTargetToSelfRelation)
				{
					sbyte categorySelfToTarget = AiHelper.ActionTargetRelationCategory.GetTargetRelationCategory(selfToTarget.RelationType);
					sbyte categoryTargetToSelf = AiHelper.ActionTargetRelationCategory.GetTargetRelationCategory(targetToSelf.RelationType);
					if (categorySelfToTarget == 1 || categoryTargetToSelf == 1)
					{
						AddCount(4);
					}
					if (categorySelfToTarget == 2 || categoryTargetToSelf == 2)
					{
						AddCount(5);
					}
				}
				List<short> features = targetChar2.GetFeatureIds();
				if (targetChar2.IsOwningBook())
				{
					AddCount(7);
				}
				if (features.Contains(215))
				{
					Transfer(0, 44);
				}
				if (features.Contains(861))
				{
					AddCount(5);
				}
				(ushort, ushort) categorySelfToTarget2 = DomainManager.Extra.GetDreamBackRelationTypeWithTaiwu(charId2);
				if (DomainManager.Extra.TryGetDreamBackLifeRecordByRelatedCharId(charId2, out var _))
				{
					AddCount(10);
				}
				else if (categorySelfToTarget2.Item1 != 0 && categorySelfToTarget2.Item2 != 0)
				{
					AddCount(10);
				}
				if (targetChar2.GetOrganizationInfo().OrgTemplateId == 16)
				{
					Transfer(0, 1);
				}
				if (orgTemplateIds != null && orgTemplateIds.Count > 0)
				{
					sbyte orgId = DomainManager.Character.GetAliveOrgDeadCharacterOrgInfo(charId2).OrgTemplateId;
					if (orgTemplateIds.Contains(orgId) && DomainManager.Extra.IsCharacterEligibleForJieqingSeizeFortune(charId2))
					{
						AddCount(11);
					}
				}
			}
		}
		if (blockData.InfectedCharacterSet != null)
		{
			foreach (int charId3 in blockData.InfectedCharacterSet)
			{
				List<short> features2 = DomainManager.Character.GetElement_Objects(charId3).GetFeatureIds();
				if (features2 != null)
				{
					if (features2.Contains(814))
					{
						Transfer(6, 42);
					}
					else if (features2.Contains(215))
					{
						Transfer(6, 44);
					}
				}
			}
		}
		result.CharacterCountDict.RemoveAllKeys((short key) => result.CharacterCountDict[key] == 0);
		return result;
		void AddCount(short key)
		{
			result.CharacterCountDict[key] = result.CharacterCountDict.GetOrDefault(key) + 1;
		}
		void RemoveCount(short key)
		{
			result.CharacterCountDict[key] = result.CharacterCountDict.GetOrDefault(key) - 1;
		}
		void Transfer(short from, short to)
		{
			AddCount(to);
			RemoveCount(from);
		}
	}

	[DomainMethod]
	public List<Location> SetMapBlockFindDataPreset(DataContext context, int index, MapBlockFindData findData)
	{
		if (index < 0 || index >= 10)
		{
			throw new ArgumentOutOfRangeException("index", $"Index must be between 0 and {9}");
		}
		_mapBlockFindDataPresets[index] = findData;
		return ExecuteMapBlockFind(context, findData);
	}

	[DomainMethod]
	public MapBlockFindData GetMapBlockFindDataPreset(int index)
	{
		if (index < 0 || index >= 10)
		{
			throw new ArgumentOutOfRangeException("index", $"Index must be between 0 and {9}");
		}
		return _mapBlockFindDataPresets[index];
	}

	private List<Location> ExecuteMapBlockFind(DataContext context, MapBlockFindData findData)
	{
		SearchedCharacter.Clear();
		List<Location> result = new List<Location>();
		if (findData == null || findData.TotalDataCount == 0)
		{
			return result;
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return result;
		}
		Span<MapBlockData> blocks = GetAreaBlocks(taiwuLocation.AreaId);
		if (blocks != null)
		{
			for (int blockId = 0; blockId < blocks.Length; blockId++)
			{
				MapBlockData block = blocks[blockId];
				if (block.Visible)
				{
					Location location = new Location(taiwuLocation.AreaId, (short)blockId);
					if (CheckBlockMatchFilter(context, findData, location, block, taiwuCharId))
					{
						result.Add(location);
					}
				}
			}
		}
		return result;
	}

	private bool CheckBlockMatchFilter(DataContext context, MapBlockFindData findData, Location location, MapBlockData block, int taiwuCharId)
	{
		if (CheckCharacterFilter(findData, block, taiwuCharId))
		{
			return true;
		}
		if (CheckMerchantFilter(context, findData, block))
		{
			return true;
		}
		if (CheckGraveFilter(findData, block, taiwuCharId))
		{
			return true;
		}
		if (CheckBeastFilter(findData, location))
		{
			return true;
		}
		if (CheckTerrainFilter(findData, block))
		{
			return true;
		}
		return false;
	}

	private bool CheckCharacterFilter(MapBlockFindData findData, MapBlockData block, int taiwuCharId)
	{
		bool found = false;
		if (block.CharacterSet != null && block.CharacterSet.Count > 0)
		{
			foreach (int charId in block.CharacterSet)
			{
				if (CheckCharacterMatchFilter(findData, charId, taiwuCharId))
				{
					found = true;
					SearchedCharacter.Add(charId);
				}
			}
		}
		if (block.InfectedCharacterSet != null && block.InfectedCharacterSet.Count > 0)
		{
			foreach (int charId2 in block.InfectedCharacterSet)
			{
				if (CheckCharacterMatchFilter(findData, charId2, taiwuCharId))
				{
					found = true;
					SearchedCharacter.Add(charId2);
				}
			}
		}
		return found;
	}

	private bool CheckCharacterMatchFilter(MapBlockFindData findData, int charId, int taiwuCharId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return false;
		}
		EFilterRes identityRes = CheckCharacterIdentityFilter(findData, character, charId, taiwuCharId);
		EFilterRes statusRes = CheckCharacterStatusFilter(findData, character, charId, taiwuCharId);
		EFilterRes attributeRes = CheckCharacterAttributeFilter(findData, character);
		return (identityRes == EFilterRes.Success || statusRes == EFilterRes.Success || attributeRes == EFilterRes.Success) && identityRes != EFilterRes.Fail && statusRes != EFilterRes.Fail && attributeRes != EFilterRes.Fail;
	}

	private EFilterRes CheckCharacterIdentityFilter(MapBlockFindData findData, GameData.Domains.Character.Character character, int charId, int taiwuCharId)
	{
		EFilterRes res = EFilterRes.None;
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.CharacterRelation, out var relations))
		{
			List<int> items = relations.Items;
			if (items != null && items.Count > 0)
			{
				bool hasRelation = false;
				RelatedCharacter relationToTarget;
				bool selfToTarget = DomainManager.Character.TryGetRelation(taiwuCharId, charId, out relationToTarget);
				RelatedCharacter relationToSelf;
				bool targetToSelf = DomainManager.Character.TryGetRelation(charId, taiwuCharId, out relationToSelf);
				foreach (int relationIdx in (IEnumerable<int>)relations/*cast due to constrained. prefix*/)
				{
					if (CheckRelationMatch(relationIdx, (ushort)(selfToTarget ? relationToTarget.RelationType : 0), (ushort)(targetToSelf ? relationToSelf.RelationType : 0), findData, taiwuCharId, charId))
					{
						hasRelation = true;
						break;
					}
				}
				if (!hasRelation)
				{
					return EFilterRes.Fail;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.CharacterIdentity, out var identities))
		{
			List<int> items2 = identities.Items;
			if (items2 != null && items2.Count > 0)
			{
				OrganizationInfo orgInfo = character.GetOrganizationInfo();
				OrganizationItem orgConfig = Config.Organization.Instance[orgInfo.OrgTemplateId];
				bool identityMatch = false;
				foreach (int identityIdx in (IEnumerable<int>)identities/*cast due to constrained. prefix*/)
				{
					if (identityIdx == 0 && orgConfig.IsSect)
					{
						identityMatch = true;
						break;
					}
					if (identityIdx == 1 && orgConfig.IsCivilian)
					{
						identityMatch = true;
						break;
					}
					if (identityIdx == 2 && orgConfig.SettlementType == EOrganizationSettlementType.TaiwuVillage)
					{
						identityMatch = true;
						break;
					}
				}
				if (!identityMatch)
				{
					return EFilterRes.Fail;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.CharacterRank, out var ranks))
		{
			List<int> items3 = ranks.Items;
			if (items3 != null && items3.Count > 0)
			{
				sbyte grade = character.GetOrganizationInfo().Grade;
				if (!ranks.Contains(grade))
				{
					return EFilterRes.Fail;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.SingleSelectData.TryGetValue(EFilterItemKey.CharacterFollow, out var followVal))
		{
			bool isFollowed = DomainManager.Taiwu.IsCharacterFollowedByTaiwu(charId);
			if (followVal == 0 && !isFollowed)
			{
				return EFilterRes.Fail;
			}
			if (followVal == 1 && isFollowed)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.RangeSliderData.TryGetValue(EFilterItemKey.CharacterAge, out var ageRange))
		{
			short age = character.GetCurrAge();
			if (age < ageRange.First || age > ageRange.Second)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.CharacterGender, out var genders))
		{
			List<int> items4 = genders.Items;
			if (items4 != null && items4.Count > 0)
			{
				sbyte gender = character.GetGender();
				bool transgender = character.GetTransgender();
				if (!genders.Contains((gender != 1) ? ((!transgender) ? 1 : 3) : (transgender ? 2 : 0)))
				{
					return EFilterRes.Fail;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.SingleSelectData.TryGetValue(EFilterItemKey.CharacterSpouse, out var spouseVal))
		{
			HashSet<int> spouseIds = DomainManager.Character.GetRelatedCharIds(charId, 1024);
			bool hasSpouse = spouseIds.Count > 0;
			bool isWidowed = false;
			foreach (int spouseId in spouseIds)
			{
				if (!DomainManager.Character.IsCharacterAlive(spouseId))
				{
					isWidowed = true;
					break;
				}
			}
			if (spouseVal == 0 && !hasSpouse)
			{
				return EFilterRes.Fail;
			}
			if (spouseVal == 1 && hasSpouse)
			{
				return EFilterRes.Fail;
			}
			if (spouseVal == 2 && !isWidowed)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.ToggleSliderData.TryGetValue(EFilterItemKey.CharacterReincarnation, out var reincarnationVal) && reincarnationVal.IsOn)
		{
			PreexistenceCharIds preexistenceCharIds = character.GetPreexistenceCharIds();
			if (preexistenceCharIds.Count < reincarnationVal.Value)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		return res;
	}

	private bool CheckRelationMatch(int relationIdx, ushort selfToTarget, ushort targetToSelf, MapBlockFindData findData, int taiwuCharId, int targetCharId)
	{
		ushort[] relationTypes = new ushort[10] { 32768, 16384, 1024, 512, 8192, 146, 73, 292, 6144, 0 };
		if (relationIdx == 9)
		{
			if (!DomainManager.Character.TryGetElement_Objects(taiwuCharId, out var taiwuChar) || !DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar))
			{
				return false;
			}
			int taiwuFactionId = taiwuChar.GetFactionId();
			int targetFactionId = targetChar.GetFactionId();
			return taiwuFactionId >= 0 && taiwuFactionId == targetFactionId;
		}
		ushort targetType = relationTypes[relationIdx];
		bool selfHasRelation = (selfToTarget & targetType) != 0;
		bool targetHasRelation = (targetToSelf & targetType) != 0;
		return selfHasRelation || targetHasRelation;
	}

	private EFilterRes CheckCharacterStatusFilter(MapBlockFindData findData, GameData.Domains.Character.Character character, int charId, int taiwuCharId)
	{
		EFilterRes res = EFilterRes.None;
		if (findData.RangeSliderData.TryGetValue(EFilterItemKey.CharacterFavorability, out var favorRange))
		{
			sbyte favor = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(charId, taiwuCharId));
			if (favor < favorRange.First || favor > favorRange.Second)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.CharacterMood, out var moods))
		{
			List<int> items = moods.Items;
			if (items != null && items.Count > 0)
			{
				sbyte happiness = HappinessType.GetHappinessType(character.GetHappiness());
				if (!moods.Contains(happiness))
				{
					return EFilterRes.Fail;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.ToggleSliderData.TryGetValue(EFilterItemKey.CharacterHealth, out var healthVal) && healthVal.IsOn)
		{
			int healthPercent = ((character.GetMaxHealth() != 0) ? (character.GetHealth() * 100 / character.GetMaxHealth()) : 0);
			if (healthPercent > healthVal.Value)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.ToggleSliderData.TryGetValue(EFilterItemKey.CharacterBreath, out var breathVal) && breathVal.IsOn)
		{
			short disorderOfQi = character.GetDisorderOfQi();
			if (disorderOfQi < breathVal.Value * 10)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.ToggleSliderData.TryGetValue(EFilterItemKey.CharacterInjury, out var injuryVal) && injuryVal.IsOn)
		{
			int totalInjury = character.GetInjuries().GetSum();
			if (totalInjury < injuryVal.Value)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.ToggleSliderData.TryGetValue(EFilterItemKey.CharacterPoison, out var poisonVal) && poisonVal.IsOn)
		{
			PoisonInts poisoned = character.GetPoisoned();
			int totalPoison = poisoned.Sum();
			if (totalPoison < poisonVal.Value)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.SingleSelectData.TryGetValue(EFilterItemKey.CharacterTrait, out var traitVal))
		{
			List<short> featureIds = character.GetFeatureIds();
			short[] traitFeatureIds = new short[1] { 198 };
			if (traitVal > 0)
			{
				return EFilterRes.Fail;
			}
			if (!featureIds.Contains(traitFeatureIds[traitVal]))
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		return res;
	}

	private unsafe EFilterRes CheckCharacterAttributeFilter(MapBlockFindData findData, GameData.Domains.Character.Character character)
	{
		EFilterRes res = EFilterRes.None;
		bool isCombatSkill = false;
		if (findData.SingleSelectData.TryGetValue(EFilterItemKey.CharacterAttributeType, out var attrType))
		{
			isCombatSkill = attrType == 0;
		}
		else
		{
			attrType = -1;
		}
		if (attrType != -1)
		{
			List<int> selectedTypes = new List<int>();
			IntList lifeTypes;
			if (isCombatSkill && findData.MultiSelectData.TryGetValue(EFilterItemKey.CharacterCombatSkillType, out var combatTypes))
			{
				selectedTypes.AddRange(combatTypes);
			}
			else if (!isCombatSkill && findData.MultiSelectData.TryGetValue(EFilterItemKey.CharacterLifeSkillType, out lifeTypes))
			{
				selectedTypes.AddRange(lifeTypes);
			}
			if (findData.SingleSliderData.TryGetValue(EFilterItemKey.CharacterAptitude, out var aptitudeVal) && selectedTypes.Count > 0)
			{
				bool qualified = false;
				foreach (int skillType in selectedTypes)
				{
					short qualification = (isCombatSkill ? character.GetCombatSkillQualification((sbyte)skillType) : character.GetLifeSkillQualification((sbyte)skillType));
					if (qualification >= aptitudeVal)
					{
						qualified = true;
						break;
					}
				}
				if (!qualified)
				{
					return EFilterRes.Fail;
				}
				res = EFilterRes.Success;
			}
			if (findData.SingleSliderData.TryGetValue(EFilterItemKey.CharacterAchievement, out var achieveVal) && selectedTypes.Count > 0)
			{
				bool qualified2 = false;
				foreach (int skillType2 in selectedTypes)
				{
					short attainment = (isCombatSkill ? character.GetCombatSkillAttainment((sbyte)skillType2) : character.GetLifeSkillAttainment((sbyte)skillType2));
					if (attainment >= achieveVal)
					{
						qualified2 = true;
						break;
					}
				}
				if (!qualified2)
				{
					return EFilterRes.Fail;
				}
				res = EFilterRes.Success;
			}
			if (findData.MultiSelectData.TryGetValue(EFilterItemKey.CharacterGrowth, out var growths))
			{
				List<int> items = growths.Items;
				if (items != null && items.Count > 0)
				{
					sbyte growthType = (isCombatSkill ? character.GetCombatSkillQualificationGrowthType() : character.GetLifeSkillQualificationGrowthType());
					if (!growths.Contains(growthType))
					{
						return EFilterRes.Fail;
					}
					res = EFilterRes.Success;
				}
			}
		}
		if (findData.SingleSliderData.TryGetValue(EFilterItemKey.CharacterVitality, out var constVal))
		{
			MainAttributes mainAttrs = character.GetCurrMainAttributes();
			if (mainAttrs.Items[3] < constVal)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.SingleSliderData.TryGetValue(EFilterItemKey.CharacterEnergy, out var boneVal))
		{
			MainAttributes mainAttrs2 = character.GetCurrMainAttributes();
			if (mainAttrs2.Items[4] < boneVal)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.SingleSliderData.TryGetValue(EFilterItemKey.CharacterStrength, out var strengthVal))
		{
			if (character.GetCurrMainAttributes().Items[0] < strengthVal)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.SingleSliderData.TryGetValue(EFilterItemKey.CharacterIntelligence, out var understandVal))
		{
			MainAttributes mainAttrs3 = character.GetCurrMainAttributes();
			if (mainAttrs3.Items[5] < understandVal)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.SingleSliderData.TryGetValue(EFilterItemKey.CharacterDexterity, out var agilityVal))
		{
			MainAttributes mainAttrs4 = character.GetCurrMainAttributes();
			if (mainAttrs4.Items[1] < agilityVal)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		if (findData.SingleSliderData.TryGetValue(EFilterItemKey.CharacterConcentration, out var willVal))
		{
			MainAttributes mainAttrs5 = character.GetCurrMainAttributes();
			if (mainAttrs5.Items[2] < willVal)
			{
				return EFilterRes.Fail;
			}
			res = EFilterRes.Success;
		}
		return res;
	}

	private bool CheckMerchantFilter(DataContext context, MapBlockFindData findData, MapBlockData block)
	{
		Location location = block.GetLocation();
		if (block.CharacterSet != null)
		{
			foreach (int charId in block.CharacterSet)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				if (character.GetAgeGroup() != 2 || !DomainManager.Extra.TryGetMerchantCharToType(charId, out var merchantType) || character.GetOrganizationInfo().Grade != 4 || !CheckMerchantMatchFilter(context, findData, charId, merchantType, -1))
				{
					continue;
				}
				SearchedCharacter.Add(charId);
				return true;
			}
		}
		foreach (CaravanDisplayData caravan in DomainManager.Merchant.GetCaravanAtBlock(context, location))
		{
			sbyte caravanMerchantType = Config.Merchant.Instance[caravan.MerchantTemplateId].MerchantType;
			if (CheckMerchantMatchFilter(context, findData, -1, caravanMerchantType, caravan.CaravanId))
			{
				return true;
			}
		}
		Settlement settlement = DomainManager.Organization.GetSettlementByLocation(location);
		if (settlement != null)
		{
			Location settlementLocation = settlement.GetLocation();
			foreach (BuildingBlockData buildingBlock in DomainManager.Building.GetBuildingBlocksAtLocation(settlementLocation))
			{
				short buildingTemplateId = buildingBlock.TemplateId;
				if (buildingTemplateId >= 276 && buildingTemplateId <= 282)
				{
					BuildingBlockItem buildingConfig = BuildingBlock.Instance[buildingTemplateId];
					sbyte guildMerchantType = buildingConfig.MerchantId;
					MerchantTypeItem merchantTypeConfig = Config.MerchantType.Instance[guildMerchantType];
					short areaTemplateId = DomainManager.Map.GetElement_Areas(settlementLocation.AreaId).GetTemplateId();
					sbyte guildMerchantLevel = ((merchantTypeConfig.HeadArea == areaTemplateId) ? merchantTypeConfig.HeadLevel : merchantTypeConfig.BranchLevel);
					if (CheckGuildMatchFilter(findData, guildMerchantType, guildMerchantLevel))
					{
						return true;
					}
					break;
				}
			}
		}
		return false;
	}

	private bool CheckMerchantMatchFilter(DataContext context, MapBlockFindData findData, int charId, sbyte merchantType, int caravanId)
	{
		EFilterRes res = EFilterRes.None;
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.MerchantType, out var types))
		{
			List<int> items = types.Items;
			if (items != null && items.Count > 0)
			{
				bool isMerchant = charId >= 0 && caravanId < 0;
				bool isCaravan = caravanId >= 0;
				bool isGuild = false;
				bool typeMatch = false;
				foreach (int t in (IEnumerable<int>)types/*cast due to constrained. prefix*/)
				{
					if (t == 0 && isMerchant)
					{
						typeMatch = true;
						break;
					}
					if (t == 1 && isCaravan)
					{
						typeMatch = true;
						break;
					}
				}
				if (!typeMatch)
				{
					return false;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.MerchantGuildType, out var guildTypes))
		{
			List<int> items2 = guildTypes.Items;
			if (items2 != null && items2.Count > 0)
			{
				if (!guildTypes.Contains(merchantType))
				{
					return false;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.MerchantGuildRank, out var ranks))
		{
			List<int> items3 = ranks.Items;
			if (items3 != null && items3.Count > 0)
			{
				sbyte level = 0;
				if (charId >= 0)
				{
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
					short settlementId = character.GetOrganizationInfo().SettlementId;
					if (settlementId >= 0)
					{
						level = DomainManager.Merchant.GetMerchantLevel(merchantType, settlementId);
					}
				}
				else if (caravanId >= 0)
				{
					MerchantData caravanData = DomainManager.Merchant.GetCaravanMerchantData(context, caravanId);
					if (caravanData != null)
					{
						level = caravanData.MerchantConfig.Level;
					}
				}
				if (!ranks.Contains(level))
				{
					return false;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.SingleSelectData.TryGetValue(EFilterItemKey.MerchantCaravanStatus, out var status) && caravanId >= 0)
		{
			DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var caravanExtra);
			bool isHijacked = caravanExtra != null && caravanExtra.StateEnum == CaravanState.Robbed;
			if (status == 0 && isHijacked)
			{
				return false;
			}
			if (status == 1 && !isHijacked)
			{
				return false;
			}
			res = EFilterRes.Success;
		}
		return res == EFilterRes.Success;
	}

	private bool CheckGuildMatchFilter(MapBlockFindData findData, sbyte merchantType, sbyte merchantLevel)
	{
		EFilterRes res = EFilterRes.None;
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.MerchantType, out var types))
		{
			List<int> items = types.Items;
			if (items != null && items.Count > 0)
			{
				if (!types.Contains(2))
				{
					return false;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.MerchantGuildType, out var guildTypes))
		{
			List<int> items2 = guildTypes.Items;
			if (items2 != null && items2.Count > 0)
			{
				if (!guildTypes.Contains(merchantType))
				{
					return false;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.MerchantGuildRank, out var ranks))
		{
			List<int> items3 = ranks.Items;
			if (items3 != null && items3.Count > 0)
			{
				if (!ranks.Contains(merchantLevel))
				{
					return false;
				}
				res = EFilterRes.Success;
			}
		}
		return res == EFilterRes.Success;
	}

	private bool CheckGraveFilter(MapBlockFindData findData, MapBlockData block, int taiwuCharId)
	{
		if (block.GraveSet == null || block.GraveSet.Count == 0)
		{
			return false;
		}
		foreach (int graveId in block.GraveSet)
		{
			if (DomainManager.Character.TryGetElement_Graves(graveId, out var grave) && CheckGraveMatchFilter(findData, grave, taiwuCharId))
			{
				SearchedCharacter.Add(graveId);
				return true;
			}
		}
		return false;
	}

	private bool CheckGraveMatchFilter(MapBlockFindData findData, Grave grave, int taiwuCharId)
	{
		EFilterRes res = EFilterRes.None;
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.GraveRank, out var ranks))
		{
			List<int> items = ranks.Items;
			if (items != null && items.Count > 0 && DomainManager.Character.TryGetDeadCharacter(grave.GetId(), out var deadChar))
			{
				sbyte grade = deadChar.OrganizationInfo.Grade;
				if (!ranks.Contains(grade))
				{
					return false;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.SingleSelectData.TryGetValue(EFilterItemKey.GraveInteraction, out var interaction))
		{
			int graveId = grave.GetId();
			switch (interaction)
			{
			case 0:
				if (EventHelper.IsForbidGraveInteraction(graveId))
				{
					return false;
				}
				break;
			case 1:
				if (EventHelper.IsForbidGraveInteraction(graveId))
				{
					return false;
				}
				if (grave.GetLevel() >= 3)
				{
					return false;
				}
				break;
			case 2:
			{
				if (EventHelper.IsForbidGraveInteraction(graveId))
				{
					return false;
				}
				if (DomainManager.Character.TryGetDeadCharacter(graveId, out var deadChar2) && deadChar2.GetActualAge() < 16)
				{
					return false;
				}
				break;
			}
			}
			res = EFilterRes.Success;
		}
		if (findData.SingleSliderData.TryGetValue(EFilterItemKey.GraveDurability, out var durabilityVal))
		{
			if (grave.GetDurability() > durabilityVal)
			{
				return false;
			}
			res = EFilterRes.Success;
		}
		if (findData.SingleSelectData.TryGetValue(EFilterItemKey.GraveHasRelation, out var hasRelation))
		{
			RelatedCharacter relation;
			bool selfToTarget = DomainManager.Character.TryGetRelation(taiwuCharId, grave.GetId(), out relation);
			bool targetToSelf = DomainManager.Character.TryGetRelation(grave.GetId(), taiwuCharId, out relation);
			bool hasAnyRelation = selfToTarget || targetToSelf;
			if (hasRelation == 0 && !hasAnyRelation)
			{
				return false;
			}
			if (hasRelation == 1 && hasAnyRelation)
			{
				return false;
			}
			res = EFilterRes.Success;
		}
		if (hasRelation == 0 && findData.MultiSelectData.TryGetValue(EFilterItemKey.GraveRelation, out var relations))
		{
			List<int> items2 = relations.Items;
			if (items2 != null && items2.Count > 0)
			{
				RelatedCharacter relationToTarget;
				bool selfToTarget2 = DomainManager.Character.TryGetRelation(taiwuCharId, grave.GetId(), out relationToTarget);
				RelatedCharacter relationToSelf;
				bool targetToSelf2 = DomainManager.Character.TryGetRelation(grave.GetId(), taiwuCharId, out relationToSelf);
				bool foundRelation = false;
				foreach (int relationIdx in (IEnumerable<int>)relations/*cast due to constrained. prefix*/)
				{
					if (CheckRelationMatch(relationIdx, (ushort)(selfToTarget2 ? relationToTarget.RelationType : 0), (ushort)(targetToSelf2 ? relationToSelf.RelationType : 0), findData, taiwuCharId, grave.GetId()))
					{
						foundRelation = true;
						break;
					}
				}
				if (!foundRelation)
				{
					return false;
				}
				res = EFilterRes.Success;
			}
		}
		return res == EFilterRes.Success;
	}

	private bool CheckBeastFilter(MapBlockFindData findData, Location location)
	{
		if (!DomainManager.Extra.TryGetAnimalsByLocation(location, out var animals) || animals.Count == 0)
		{
			return false;
		}
		foreach (GameData.Domains.Character.Animal animal in animals)
		{
			if (CheckBeastMatchFilter(findData, animal))
			{
				return true;
			}
		}
		return false;
	}

	private bool CheckBeastMatchFilter(MapBlockFindData findData, GameData.Domains.Character.Animal animal)
	{
		EFilterRes res = EFilterRes.None;
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.BeastType, out var types))
		{
			List<int> items = types.Items;
			if (items != null && items.Count > 0)
			{
				short characterTemplateId = animal.CharacterTemplateId;
				bool flag = ((characterTemplateId < 246 || characterTemplateId > 286) ? true : false);
				bool isBeast = flag;
				if (!types.Contains((!isBeast) ? 1 : 0))
				{
					return false;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.MultiSelectData.TryGetValue(EFilterItemKey.BeastRank, out var ranks))
		{
			List<int> items2 = ranks.Items;
			if (items2 != null && items2.Count > 0)
			{
				sbyte grade = Config.Character.Instance[animal.CharacterTemplateId]?.OrganizationInfo.Grade ?? 0;
				if (!ranks.Contains(grade))
				{
					return false;
				}
				res = EFilterRes.Success;
			}
		}
		if (findData.SingleSelectData.TryGetValue(EFilterItemKey.BeastStatus, out var status))
		{
			bool isEscaped = animal.ItemKey.IsValid();
			if (status == 0 && isEscaped)
			{
				return false;
			}
			if (status == 1 && !isEscaped)
			{
				return false;
			}
			res = EFilterRes.Success;
		}
		return res == EFilterRes.Success;
	}

	private bool CheckTerrainFilter(MapBlockFindData findData, MapBlockData block)
	{
		EFilterRes res = EFilterRes.None;
		if (findData.SingleSelectData.TryGetValue(EFilterItemKey.TerrainResourceType, out var resourceType))
		{
			MaterialResources currResources = block.CurrResources;
			bool hasResource = false;
			for (int i = 0; i < 6; i++)
			{
				if (i == resourceType && currResources.Get(i) > 0)
				{
					hasResource = true;
					break;
				}
			}
			if (!hasResource)
			{
				return false;
			}
			res = EFilterRes.Success;
		}
		if (res != EFilterRes.Success)
		{
			resourceType = -1;
		}
		if (findData.RangeSliderData.TryGetValue(EFilterItemKey.TerrainResourceAmount, out var amountRange))
		{
			if (resourceType != -1)
			{
				short currentResource = block.CurrResources[resourceType];
				if (currentResource < amountRange.First || currentResource > amountRange.Second)
				{
					return false;
				}
				res = EFilterRes.Success;
			}
			else
			{
				for (int j = 0; j < 6; j++)
				{
					short count = block.CurrResources[j];
					if (count < amountRange.First || count > amountRange.Second)
					{
						if (j == 5)
						{
							return false;
						}
						continue;
					}
					res = EFilterRes.Success;
					break;
				}
			}
		}
		if (findData.SingleSelectData.TryGetValue(EFilterItemKey.TerrainMigration, out var migration))
		{
			bool canMigrate = CheckBlockCanMigrate(block);
			if (migration == 0 && !canMigrate)
			{
				return false;
			}
			if (migration == 1 && canMigrate)
			{
				return false;
			}
			res = EFilterRes.Success;
		}
		if (findData.SingleSelectData.TryGetValue(EFilterItemKey.TerrainStatus, out var status))
		{
			if (status == 0 && block.Destroyed)
			{
				return false;
			}
			if (status == 1 && !block.Destroyed)
			{
				return false;
			}
			res = EFilterRes.Success;
		}
		if (findData.ToggleSliderData.TryGetValue(EFilterItemKey.TerrainExcavation, out var excavationVal) && excavationVal.IsOn)
		{
			sbyte maxGrade = GetBlockMaxExcavationGrade(block);
			if (maxGrade < excavationVal.Value)
			{
				return false;
			}
			res = EFilterRes.Success;
		}
		return res == EFilterRes.Success;
	}

	private bool CheckBlockCanMigrate(MapBlockData block)
	{
		MapBlockItem blockConfig = block.GetConfig();
		if (blockConfig == null || blockConfig.ResourceCollectionType < 0)
		{
			return false;
		}
		for (sbyte i = 0; i < 6; i++)
		{
			short maxResource = block.MaxResources.Get(i);
			if (maxResource > 0 && block.CurrResources.Get(i) >= maxResource / 2)
			{
				return true;
			}
		}
		return false;
	}

	private sbyte GetBlockMaxExcavationGrade(MapBlockData block)
	{
		if (block.Items != null)
		{
			SortedList<ItemKeyAndDate, int> items = block.Items;
			if (items == null || items.Count != 0)
			{
				sbyte maxGrade = 0;
				foreach (KeyValuePair<ItemKeyAndDate, int> item in block.Items)
				{
					sbyte grade = ItemTemplateHelper.GetGrade(item.Key.ItemKey.ItemType, item.Key.ItemKey.TemplateId);
					if (grade > maxGrade)
					{
						maxGrade = grade;
					}
				}
				return maxGrade;
			}
		}
		return 0;
	}

	public void InitializeBrokenAreaEnemies()
	{
		for (int i = 0; i < _brokenAreaEnemies.Length; i++)
		{
			_brokenAreaEnemies[i] = new BrokenAreaData();
		}
		_brokenAreaEnemyBaseCount = GlobalConfig.Instance.BrokenAreaEnemyCountLevelDist.Sum();
	}

	public void GenerateBrokenAreaInitialEnemies(DataContext context)
	{
		int factor = DomainManager.World.GetHereticsAmountFactor();
		List<MapBlockData> validBlocks = new List<MapBlockData>();
		for (int i = 0; i < _brokenAreaEnemies.Length; i += 6)
		{
			CollectionUtils.Shuffle(context.Random, _stateBrokenAreaLevels);
			for (int offset = 0; offset < 6; offset++)
			{
				int index = i + offset;
				short areaId = (short)(45 + index);
				_brokenAreaEnemies[index].Level = _stateBrokenAreaLevels[offset];
				GetValidBlocksForRandomEnemy(areaId, -1, 3, onSettlement: false, nearTaiwu: false, validBlocks);
				for (int baseLevel = 0; baseLevel < 3; baseLevel++)
				{
					short enemyId = (short)(366 + baseLevel + _brokenAreaEnemies[index].Level - 1);
					int enemyCount = GlobalConfig.Instance.BrokenAreaEnemyCountLevelDist[baseLevel] * factor / 100;
					CreateRandomEnemiesOnValidBlocks(context, 0, Location.Invalid, enemyId, enemyCount, validBlocks);
				}
				SetElement_BrokenAreaEnemies(index, _brokenAreaEnemies[index], context);
			}
		}
		DomainManager.Extra.InitializeTreasureMaterials(context);
	}

	public void UpdateBrokenAreaRandomEnemies(DataContext context)
	{
		for (short areaId = 45; areaId < 135; areaId++)
		{
			ComplementEnemiesInBrokenArea(context, areaId);
		}
		UpdateBrokenAreaRandomEnemiesMovement(context);
	}

	private void UpdateBrokenAreaRandomEnemiesMovement(DataContext context)
	{
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		List<MapTemplateEnemyInfo> enemyList = ObjectPool<List<MapTemplateEnemyInfo>>.Instance.Get();
		for (int index = 0; index < _brokenAreaEnemies.Length; index++)
		{
			if (_brokenAreaEnemies[index].RandomEnemies == null)
			{
				return;
			}
			enemyList.Clear();
			enemyList.AddRange(_brokenAreaEnemies[index].RandomEnemies);
			short areaId = (short)(index + 45);
			foreach (MapTemplateEnemyInfo randEnemy in enemyList)
			{
				GetValidBlocksForRandomEnemy(areaId, randEnemy.BlockId, 3, onSettlement: false, nearTaiwu: true, neighborBlocks);
				MapBlockData targetBlock = neighborBlocks.GetRandom(context.Random);
				if (randEnemy.BlockId != targetBlock.BlockId)
				{
					Events.RaiseTemplateEnemyLocationChanged(srcLocation: new Location(areaId, randEnemy.BlockId), destLocation: new Location(areaId, targetBlock.BlockId), context: context, templateEnemyInfo: randEnemy);
				}
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
		ObjectPool<List<MapTemplateEnemyInfo>>.Instance.Return(enemyList);
	}

	public void GetValidBlocksForRandomEnemy(short areaId, short centerBlockId, short maxSteps, bool onSettlement, bool nearTaiwu, List<MapBlockData> validBlocks)
	{
		validBlocks.Clear();
		List<MapBlockData> taiwuLocationNeighbors = ObjectPool<List<MapBlockData>>.Instance.Get();
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
		if (!nearTaiwu && taiwuLocation.IsValid())
		{
			GetRealNeighborBlocks(taiwuLocation.AreaId, taiwuLocation.BlockId, taiwuLocationNeighbors);
		}
		if (centerBlockId != -1)
		{
			List<MapBlockData> curBlockNeighbors = ObjectPool<List<MapBlockData>>.Instance.Get();
			GetRealNeighborBlocks(areaId, centerBlockId, curBlockNeighbors, maxSteps);
			foreach (MapBlockData blockData in curBlockNeighbors)
			{
				if ((nearTaiwu || taiwuLocation.AreaId != areaId || (taiwuLocation.BlockId != blockData.BlockId && !taiwuLocationNeighbors.Contains(blockData))) && (onSettlement || (!blockData.IsCityTown() && blockData.BlockType != EMapBlockType.Station)) && MapBlockDataMatchers.IsValidForRandomEnemy(blockData) && blockData.IsPassable())
				{
					validBlocks.Add(blockData);
				}
			}
			curBlockNeighbors.Clear();
			ObjectPool<List<MapBlockData>>.Instance.Return(curBlockNeighbors);
		}
		else
		{
			Span<MapBlockData> areaBlocks = GetAreaBlocks(areaId);
			Span<MapBlockData> span = areaBlocks;
			for (int i = 0; i < span.Length; i++)
			{
				MapBlockData blockData2 = span[i];
				if ((nearTaiwu || taiwuLocation.AreaId != areaId || (taiwuLocation.BlockId != blockData2.BlockId && !taiwuLocationNeighbors.Contains(blockData2))) && (onSettlement || (!blockData2.IsCityTown() && blockData2.BlockType != EMapBlockType.Station)) && MapBlockDataMatchers.IsValidForRandomEnemy(blockData2) && blockData2.IsPassable())
				{
					validBlocks.Add(blockData2);
				}
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(taiwuLocationNeighbors);
	}

	private void ComplementEnemiesInBrokenArea(DataContext context, short areaId)
	{
		bool modified = false;
		int brokenAreaOffset = areaId - 45;
		int factor = DomainManager.World.GetHereticsAmountFactor();
		Span<int> enemyCounts = stackalloc int[GlobalConfig.Instance.BrokenAreaEnemyCountLevelDist.Length];
		enemyCounts.Fill(0);
		BrokenAreaData brokenAreaData = _brokenAreaEnemies[brokenAreaOffset];
		if (brokenAreaData.RandomEnemies.Count >= _brokenAreaEnemyBaseCount * factor / 100)
		{
			return;
		}
		foreach (MapTemplateEnemyInfo randomEnemy in brokenAreaData.RandomEnemies)
		{
			int baseLevel = randomEnemy.TemplateId - brokenAreaData.BaseXiangshuMinionTemplateId;
			if (baseLevel >= 0 && baseLevel < enemyCounts.Length)
			{
				enemyCounts[baseLevel]++;
			}
		}
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		List<MapBlockData> validBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		validBlocks.Clear();
		Span<MapBlockData> areaBlocks = GetAreaBlocks(areaId);
		for (int i = 0; i < areaBlocks.Length; i++)
		{
			MapBlockData block = areaBlocks[i];
			if (taiwuLocation != block.GetLocation() && block.IsPassable())
			{
				validBlocks.Add(block);
			}
		}
		for (int j = 0; j < 3; j++)
		{
			sbyte baseCount = GlobalConfig.Instance.BrokenAreaEnemyCountLevelDist[j];
			int complementAmount = baseCount * factor / 100 - enemyCounts[j];
			if (complementAmount > 0)
			{
				short enemyId = (short)Math.Clamp(j + brokenAreaData.BaseXiangshuMinionTemplateId, 366, 374);
				CreateRandomEnemiesOnValidBlocks(context, 0, Location.Invalid, enemyId, 1, validBlocks);
				modified = true;
				break;
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(validBlocks);
		if (modified)
		{
			SetElement_BrokenAreaEnemies(brokenAreaOffset, brokenAreaData, context);
		}
	}

	public void CreateRandomEnemiesOnValidBlocks(DataContext context, sbyte sourceType, Location sourceNestLocation, short enemyTemplateId, int enemyAmount, IList<MapBlockData> validBlocks)
	{
		CreateTemporaryEnemiesOnValidBlocks(context, sourceType, sourceNestLocation, enemyTemplateId, enemyAmount, validBlocks, -1);
	}

	public void CreateTemporaryEnemiesOnValidBlocks(DataContext context, sbyte sourceType, Location sourceNestLocation, short enemyTemplateId, int enemyAmount, IList<MapBlockData> validBlocks, sbyte duration = sbyte.MinValue)
	{
		if (enemyTemplateId <= 0)
		{
			return;
		}
		byte creatingType = Config.Character.Instance[enemyTemplateId].CreatingType;
		bool condition = (uint)(creatingType - 2) <= 1u;
		Tester.Assert(condition);
		if (sourceNestLocation.IsValid() && duration != -1)
		{
			AdaptableLog.TagWarning("CreateTemporaryEnemiesOnValidBlocks", $"Creating Enemy with sourceNestLocation and duration = {duration} is invalid, changing duration to -1:\n{new StackTrace()}");
			duration = -1;
		}
		else if (duration == sbyte.MinValue)
		{
			duration = MapTemplateEnemyInfo.DefaultDuration(DomainManager.Taiwu.GetTaiwu().GetConsummateLevel());
		}
		for (int i = 0; i < enemyAmount; i++)
		{
			if (validBlocks.Count == 0)
			{
				break;
			}
			int index = context.Random.Next(0, validBlocks.Count);
			Location validBlockLocation = new Location(validBlocks[index].AreaId, validBlocks[index].BlockId);
			MapTemplateEnemyInfo enemyInfo = new MapTemplateEnemyInfo(enemyTemplateId, validBlockLocation.BlockId, sourceType, sourceNestLocation.BlockId, duration);
			Events.RaiseTemplateEnemyLocationChanged(context, enemyInfo, Location.Invalid, validBlockLocation);
		}
	}

	public void CreateFixedTutorialArea(DataContext context)
	{
		Dictionary<int, List<short>> blockTypeDict = new Dictionary<int, List<short>>();
		Dictionary<int, List<short>> blockSubTypeDict = new Dictionary<int, List<short>>();
		List<short> allBlockKeys = MapBlock.Instance.GetAllKeys();
		for (int i = 0; i < allBlockKeys.Count; i++)
		{
			MapBlockItem blockConfig = MapBlock.Instance[allBlockKeys[i]];
			int blockType = (int)blockConfig.Type;
			int blockSubType = (int)blockConfig.SubType;
			if (!blockTypeDict.ContainsKey(blockType))
			{
				blockTypeDict.Add(blockType, new List<short>());
			}
			blockTypeDict[blockType].Add(blockConfig.TemplateId);
			if (!blockSubTypeDict.ContainsKey(blockSubType))
			{
				blockSubTypeDict.Add(blockSubType, new List<short>());
			}
			blockSubTypeDict[blockSubType].Add(blockConfig.TemplateId);
		}
		DomainManager.Organization.BeginCreatingSettlements(context.Random);
		_swCreatingNormalAreas = new Stopwatch();
		_swCreatingSettlements = new Stopwatch();
		_swInitializingAreaTravelRoutes = new Stopwatch();
		CreateEmptyStateAreas(context);
		DomainManager.Organization.CreateEmptySects(context);
		MapAreaData bornArea = _areas[135];
		bornArea.Init(0, 135);
		_bornAreaBlocks.Init(0);
		SetElement_Areas(135, bornArea, context);
		MapAreaData guideArea = _areas[136];
		MapAreaItem guideAreaConfig = MapArea.Instance[(short)136];
		guideArea.Init(136, 136);
		_guideAreaBlocks.Init(guideAreaConfig.Size * guideAreaConfig.Size);
		CreateNormalArea(context, guideArea, 136, blockTypeDict, blockSubTypeDict);
		guideArea.Discovered = true;
		SetElement_Areas(136, guideArea, context);
		MapAreaData secretVillageArea = _areas[137];
		secretVillageArea.Init(137, 137);
		_secretVillageAreaBlocks.Init(0);
		SetElement_Areas(137, secretVillageArea, context);
		MapAreaData pastTaiwuVillageAreaId = _areas[139];
		pastTaiwuVillageAreaId.Init(137, 139);
		_pastTaiwuVillageAreaBlocks.Init(0);
		SetElement_Areas(139, pastTaiwuVillageAreaId, context);
		MapAreaData chaishanArea = _areas[140];
		secretVillageArea.Init(139, 140);
		_secretVillageAreaBlocks.Init(0);
		SetElement_Areas(140, secretVillageArea, context);
		short brokenAreaId = -1;
		sbyte stateId = GetStateIdByStateTemplateId(DomainManager.World.GetTaiwuVillageStateTemplateId());
		for (int j = 0; j < 6; j++)
		{
			brokenAreaId = (short)(45 + stateId * 6 + j);
			if (context.Random.NextBool())
			{
				break;
			}
		}
		Tester.Assert(brokenAreaId >= 0);
		MapAreaData brokenPerformArea = _areas[138];
		MapAreaItem brokenPerformAreaConfig = GetElement_Areas(brokenAreaId).GetConfig();
		brokenPerformArea.Init(brokenPerformAreaConfig.TemplateId, 138);
		_brokenPerformAreaBlocks.Init(0);
		SetElement_Areas(138, brokenPerformArea, context);
		DomainManager.Organization.EndCreatingSettlements(context);
		Logger.Info($"CreateNormalAreas: {_swCreatingNormalAreas.Elapsed.TotalMilliseconds:N1}");
		Logger.Info($"CreateSettlements: {_swCreatingSettlements.Elapsed.TotalMilliseconds:N1}");
		Logger.Info($"InitializeAreaTravelRoutes: {_swInitializingAreaTravelRoutes.Elapsed.TotalMilliseconds:N1}");
	}

	private void CreateEmptyStateAreas(DataContext context)
	{
		Dictionary<sbyte, List<short>> thirdAreaDict = new Dictionary<sbyte, List<short>>();
		List<short> allAreaKeys = MapArea.Instance.GetAllKeys();
		for (int i = 31; i < allAreaKeys.Count; i++)
		{
			short areaTemplateId = allAreaKeys[i];
			sbyte stateTemplateId = MapArea.Instance[areaTemplateId].StateID;
			if (stateTemplateId >= 0)
			{
				if (!thirdAreaDict.ContainsKey(stateTemplateId))
				{
					thirdAreaDict.Add(stateTemplateId, new List<short>());
				}
				thirdAreaDict[stateTemplateId].Add(areaTemplateId);
			}
		}
		List<short> brokenAreaTemplateIdList = ObjectPool<List<short>>.Instance.Get();
		brokenAreaTemplateIdList.Clear();
		for (int stateId = 0; stateId < 15; stateId++)
		{
			MapStateItem stateConfig = MapState.Instance[stateId + 1];
			List<short> thirdAreaList = thirdAreaDict[stateConfig.TemplateId];
			short thirdAreaTemplateId = thirdAreaList[context.Random.Next(thirdAreaList.Count)];
			for (int stateAreaIndex = 0; stateAreaIndex < 3; stateAreaIndex++)
			{
				short areaId = (short)(stateId * 3 + stateAreaIndex);
				short areaTemplateId2 = stateAreaIndex switch
				{
					0 => stateConfig.MainAreaID, 
					1 => stateConfig.SectAreaID, 
					_ => thirdAreaTemplateId, 
				};
				MapAreaData area = _areas[areaId];
				area.Init(areaTemplateId2, areaId);
				MapAreaItem areaConfigData = area.GetConfig();
				bool taiwuVillageInArea = areaConfigData.StateID == DomainManager.World.GetTaiwuVillageStateTemplateId() && stateAreaIndex == 2;
				AreaBlockCollection areaBlocks = GetAreaBlockCollection(areaId);
				if (taiwuVillageInArea)
				{
					areaBlocks.Init(1);
					AddRegularBlockData(context, new Location(areaId, 0), new MapBlockData(areaId, 0, 0));
					short settlementId = DomainManager.Organization.CreateSettlement(context, new Location(areaId, 0), 16);
					Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
					short randomNameId = (short)((settlement is CivilianSettlement cs) ? cs.GetRandomNameId() : (-1));
					area.SettlementInfos[1] = new SettlementInfo(settlementId, 0, settlement.GetOrgTemplateId(), randomNameId);
					DomainManager.Taiwu.SetTaiwuVillageSettlementId(settlementId, context);
					DomainManager.Building.CreateBuildingArea(context, areaId, 0, 0);
					DomainManager.Building.AddTaiwuBuildingArea(context, new Location(areaId, 0));
				}
				else
				{
					areaBlocks.Init(0);
				}
			}
			thirdAreaList.Remove(thirdAreaTemplateId);
			brokenAreaTemplateIdList.AddRange(thirdAreaList);
		}
		_brokenAreaBlocks.Init(0);
		for (int j = 0; j < brokenAreaTemplateIdList.Count; j++)
		{
			short areaId2 = (short)(45 + j);
			MapAreaData area2 = _areas[areaId2];
			short areaTemplateId3 = brokenAreaTemplateIdList[j];
			area2.Init(areaTemplateId3, areaId2);
		}
		ObjectPool<List<short>>.Instance.Return(brokenAreaTemplateIdList);
	}

	public void CreateAllAreas(DataContext context)
	{
		Dictionary<int, List<short>> blockTypeDict = new Dictionary<int, List<short>>();
		Dictionary<int, List<short>> blockSubTypeDict = new Dictionary<int, List<short>>();
		List<short> allBlockKeys = MapBlock.Instance.GetAllKeys();
		for (int i = 0; i < allBlockKeys.Count; i++)
		{
			MapBlockItem blockConfig = MapBlock.Instance[allBlockKeys[i]];
			int blockType = (int)blockConfig.Type;
			int blockSubType = (int)blockConfig.SubType;
			if (!blockTypeDict.ContainsKey(blockType))
			{
				blockTypeDict.Add(blockType, new List<short>());
			}
			blockTypeDict[blockType].Add(blockConfig.TemplateId);
			if (!blockSubTypeDict.ContainsKey(blockSubType))
			{
				blockSubTypeDict.Add(blockSubType, new List<short>());
			}
			blockSubTypeDict[blockSubType].Add(blockConfig.TemplateId);
		}
		DomainManager.Organization.BeginCreatingSettlements(context.Random);
		_swCreatingNormalAreas = new Stopwatch();
		_swCreatingSettlements = new Stopwatch();
		_swInitializingAreaTravelRoutes = new Stopwatch();
		CreateStateAreas(context, blockTypeDict, blockSubTypeDict);
		_swInitializingAreaTravelRoutes.Start();
		InitAreaTravelRoute(context);
		_swInitializingAreaTravelRoutes.Stop();
		for (short areaId = 0; areaId < 135; areaId++)
		{
			SetElement_Areas(areaId, _areas[areaId], context);
		}
		sbyte taiwuStateTemplateId = DomainManager.World.GetTaiwuVillageStateTemplateId();
		sbyte[] neighborStateList = MapState.Instance[taiwuStateTemplateId].NeighborStates;
		List<sbyte> initUnlockStationStateList = ObjectPool<List<sbyte>>.Instance.Get();
		List<short> areaIdList = ObjectPool<List<short>>.Instance.Get();
		initUnlockStationStateList.Clear();
		initUnlockStationStateList.Add(GetStateIdByStateTemplateId(taiwuStateTemplateId));
		for (int j = 0; j < neighborStateList.Length; j++)
		{
			initUnlockStationStateList.Add(GetStateIdByStateTemplateId(neighborStateList[j]));
		}
		while (initUnlockStationStateList.Count > GlobalConfig.Instance.MapInitUnlockStationStateCount)
		{
			initUnlockStationStateList.RemoveAt(context.Random.Next(1, initUnlockStationStateList.Count));
		}
		for (int k = 0; k < initUnlockStationStateList.Count; k++)
		{
			GetAllAreaInState(initUnlockStationStateList[k], areaIdList);
			foreach (short areaId2 in areaIdList)
			{
				if (!_areas[areaId2].StationUnlocked)
				{
					UnlockStation(context, areaId2, costAuthority: false);
				}
			}
		}
		DomainManager.Extra.SetStationInited(1, context);
		ObjectPool<List<sbyte>>.Instance.Return(initUnlockStationStateList);
		ObjectPool<List<short>>.Instance.Return(areaIdList);
		Stopwatch swGeneratingInitialEnemies = new Stopwatch();
		swGeneratingInitialEnemies.Start();
		GenerateBrokenAreaInitialEnemies(context);
		swGeneratingInitialEnemies.Stop();
		MapAreaData bornArea = _areas[135];
		MapAreaItem bornAreaConfig = MapArea.Instance[(short)0];
		bornArea.Init(0, 135);
		_bornAreaBlocks.Init(bornAreaConfig.Size * bornAreaConfig.Size);
		CreateNormalArea(context, bornArea, 135, blockTypeDict, blockSubTypeDict);
		bornArea.Discovered = true;
		SetElement_Areas(135, bornArea, context);
		DomainManager.Taiwu.TryAddVisitedSettlement(bornArea.SettlementInfos[0].SettlementId, context);
		MapAreaData guideArea = _areas[136];
		MapAreaItem guideAreaConfig = MapArea.Instance[(short)136];
		guideArea.Init(136, 136);
		_guideAreaBlocks.Init(guideAreaConfig.Size * guideAreaConfig.Size);
		CreateNormalArea(context, guideArea, 136, blockTypeDict, blockSubTypeDict);
		guideArea.Discovered = true;
		SetElement_Areas(136, guideArea, context);
		MapAreaData secretVillageArea = _areas[137];
		MapAreaItem secretVillageAreaConfig = MapArea.Instance[(short)137];
		secretVillageArea.Init(secretVillageAreaConfig.TemplateId, 137);
		_secretVillageAreaBlocks.Init(secretVillageAreaConfig.Size * secretVillageAreaConfig.Size);
		CreateNormalArea(context, secretVillageArea, 137, blockTypeDict, blockSubTypeDict);
		secretVillageArea.Discovered = true;
		secretVillageArea.StationUnlocked = true;
		SetElement_Areas(137, secretVillageArea, context);
		MapAreaData pastTaiwuVillageArea = _areas[139];
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		pastTaiwuVillageArea.Init(138, 139);
		AreaBlockCollection areaBlockCollection = DomainManager.Map.GetAreaBlockCollection(taiwuVillageLocation.AreaId);
		_pastTaiwuVillageAreaBlocks.Init(areaBlockCollection.Count);
		MapBlockData[] taiwuVillage = areaBlockCollection.GetArray();
		AreaBlockCollection pastTaiwu = GetAreaBlockCollection(139);
		for (short i2 = 0; i2 < taiwuVillage.Length; i2++)
		{
			MapBlockData blockData = MapBlockData.SimpleClone(taiwuVillage[i2]);
			blockData.AreaId = 139;
			pastTaiwu.Add(blockData.BlockId, blockData);
		}
		MapAreaData taiwuAreaData = GetElement_Areas(taiwuVillageLocation.AreaId);
		pastTaiwuVillageArea.Discovered = true;
		pastTaiwuVillageArea.StationUnlocked = true;
		pastTaiwuVillageArea.SettlementInfos = taiwuAreaData.SettlementInfos.ToArray();
		pastTaiwuVillageArea.StationBlockId = taiwuAreaData.StationBlockId;
		SetElement_Areas(139, pastTaiwuVillageArea, context);
		short brokenAreaId = -1;
		sbyte stateId = GetStateIdByStateTemplateId(DomainManager.World.GetTaiwuVillageStateTemplateId());
		for (int l = 0; l < 6; l++)
		{
			brokenAreaId = (short)(45 + stateId * 6 + l);
			if (context.Random.NextBool())
			{
				break;
			}
		}
		Tester.Assert(brokenAreaId >= 0);
		MapAreaData brokenPerformArea = _areas[138];
		MapAreaItem brokenPerformAreaConfig = GetElement_Areas(brokenAreaId).GetConfig();
		brokenPerformArea.Init(brokenPerformAreaConfig.TemplateId, 138);
		_brokenPerformAreaBlocks.Init(brokenPerformAreaConfig.Size * brokenPerformAreaConfig.Size);
		CreateNormalArea(context, brokenPerformArea, 138, blockTypeDict, blockSubTypeDict);
		brokenPerformArea.Discovered = true;
		brokenPerformArea.StationUnlocked = true;
		SetElement_Areas(138, brokenPerformArea, context);
		SetBlockAndViewRangeVisible(context, 138, brokenPerformArea.StationBlockId);
		DomainManager.Organization.EndCreatingSettlements(context);
		InitializeTravelMap();
		Logger.Info($"CreateNormalAreas: {_swCreatingNormalAreas.Elapsed.TotalMilliseconds:N1}");
		Logger.Info($"CreateSettlements: {_swCreatingSettlements.Elapsed.TotalMilliseconds:N1}");
		Logger.Info($"InitializeAreaTravelRoutes: {_swInitializingAreaTravelRoutes.Elapsed.TotalMilliseconds:N1}");
		Logger.Info($"InitializeBrokenAreaEnemies: {swGeneratingInitialEnemies.Elapsed.TotalMilliseconds:N1}");
	}

	private void CreateStateAreas(DataContext context, Dictionary<int, List<short>> blockTypeDict, Dictionary<int, List<short>> blockSubTypeDict)
	{
		Dictionary<sbyte, List<short>> thirdAreaDict = new Dictionary<sbyte, List<short>>();
		List<short> allAreaKeys = MapArea.Instance.GetAllKeys();
		for (int i = 31; i < allAreaKeys.Count; i++)
		{
			short areaTemplateId = allAreaKeys[i];
			sbyte stateTemplateId = MapArea.Instance[areaTemplateId].StateID;
			if (stateTemplateId >= 0)
			{
				if (!thirdAreaDict.ContainsKey(stateTemplateId))
				{
					thirdAreaDict.Add(stateTemplateId, new List<short>());
				}
				thirdAreaDict[stateTemplateId].Add(areaTemplateId);
			}
		}
		List<short> brokenAreaTemplateIdList = ObjectPool<List<short>>.Instance.Get();
		List<short> ruinBlockRandomPool = ObjectPool<List<short>>.Instance.Get();
		List<short> ruinBigBlockRandomPool = ObjectPool<List<short>>.Instance.Get();
		brokenAreaTemplateIdList.Clear();
		for (int stateId = 0; stateId < 15; stateId++)
		{
			MapStateItem stateConfig = MapState.Instance[stateId + 1];
			List<short> thirdAreaList = thirdAreaDict[stateConfig.TemplateId];
			short thirdAreaTemplateId = thirdAreaList[context.Random.Next(thirdAreaList.Count)];
			for (int stateAreaIndex = 0; stateAreaIndex < 3; stateAreaIndex++)
			{
				short areaId = (short)(stateId * 3 + stateAreaIndex);
				short areaTemplateId2 = stateAreaIndex switch
				{
					0 => stateConfig.MainAreaID, 
					1 => stateConfig.SectAreaID, 
					_ => thirdAreaTemplateId, 
				};
				MapAreaData area = _areas[areaId];
				MapAreaItem configData = MapArea.Instance[areaTemplateId2];
				area.Init(areaTemplateId2, areaId);
				byte areaSize = configData.Size;
				if (configData.StateID == DomainManager.World.GetTaiwuVillageStateTemplateId() && stateAreaIndex == 2)
				{
					areaSize = (byte)GlobalConfig.Instance.TaiwuVillageForceAreaSize;
				}
				GetAreaBlockCollection(areaId).Init(areaSize * areaSize);
				CreateNormalArea(context, area, areaId, blockTypeDict, blockSubTypeDict, stateAreaIndex);
			}
			thirdAreaList.Remove(thirdAreaTemplateId);
			brokenAreaTemplateIdList.AddRange(thirdAreaList);
		}
		GenerateChaishan(context, blockTypeDict, blockSubTypeDict);
		ruinBlockRandomPool.Clear();
		ruinBlockRandomPool.Add(118);
		ruinBlockRandomPool.Add(119);
		ruinBlockRandomPool.Add(120);
		ruinBlockRandomPool.Add(121);
		ruinBlockRandomPool.Add(122);
		ruinBlockRandomPool.Add(123);
		ruinBigBlockRandomPool.Clear();
		ruinBigBlockRandomPool.Add(142);
		ruinBigBlockRandomPool.Add(143);
		ruinBigBlockRandomPool.Add(144);
		ruinBigBlockRandomPool.Add(145);
		ruinBigBlockRandomPool.Add(146);
		ruinBigBlockRandomPool.Add(147);
		_brokenAreaBlocks.Init(2250);
		for (int j = 0; j < brokenAreaTemplateIdList.Count; j++)
		{
			short areaId2 = (short)(45 + j);
			MapAreaData area2 = _areas[areaId2];
			short areaTemplateId3 = brokenAreaTemplateIdList[j];
			area2.Init(areaTemplateId3, areaId2);
			CreateBrokenArea(context, _areas[areaId2], areaId2, ruinBlockRandomPool, ruinBigBlockRandomPool);
		}
		for (sbyte areaId3 = 0; areaId3 < 45; areaId3++)
		{
			int k = 0;
			for (int times = context.Random.Next(3, 6); k < times; k++)
			{
				DomainManager.Extra.AnimalRandomGenerateInArea(context, areaId3);
			}
		}
		ObjectPool<List<short>>.Instance.Return(brokenAreaTemplateIdList);
		ObjectPool<List<short>>.Instance.Return(ruinBlockRandomPool);
	}

	private void GenerateChaishan(DataContext context, Dictionary<int, List<short>> blockTypeDict, Dictionary<int, List<short>> blockSubTypeDict)
	{
		MapAreaData area = _areas[140];
		MapAreaItem areaConfig = MapArea.Instance[(short)139];
		area.Init(areaConfig.TemplateId, 140);
		_chaishanAreaBlocks.Init(areaConfig.Size * areaConfig.Size);
		CreateNormalArea(context, area, 140, blockTypeDict, blockSubTypeDict);
		area.StationUnlocked = true;
		SetElement_Areas(140, area, context);
	}

	private unsafe void CreateNormalArea(DataContext context, MapAreaData mapAreaData, short areaId, Dictionary<int, List<short>> blockTypeDict, Dictionary<int, List<short>> blockSubTypeDict, int indexInState = -1)
	{
		_swCreatingNormalAreas.Start();
		short* offset4X = stackalloc short[4];
		short* offset4Y = stackalloc short[4];
		*offset4X = 1;
		offset4X[1] = -1;
		offset4X[2] = 0;
		offset4X[3] = 0;
		*offset4Y = 0;
		offset4Y[1] = 0;
		offset4Y[2] = 1;
		offset4Y[3] = -1;
		MapAreaItem areaConfigData = mapAreaData.GetConfig();
		bool taiwuVillageInArea = areaConfigData.StateID == DomainManager.World.GetTaiwuVillageStateTemplateId() && indexInState == 2;
		byte areaSize = areaConfigData.Size;
		if (taiwuVillageInArea)
		{
			areaSize = (byte)GlobalConfig.Instance.TaiwuVillageForceAreaSize;
		}
		MapBlockData[] areaBlocks = GetAreaBlockCollection(areaId).GetArray();
		int settlementCount = areaConfigData.OrganizationId.Length + (taiwuVillageInArea ? 1 : 0);
		List<short> staticBlockIdList = ObjectPool<List<short>>.Instance.Get();
		if (areaConfigData.CustomBlockConfig == null)
		{
			int keepRange = areaSize * 3 / 4;
			if (taiwuVillageInArea)
			{
				keepRange = Math.Max(keepRange, SharedConstValue.TaiwuEnsuredSurroundingBlockOffsets.Select(((int, int) p) => Math.Abs(p.Item1 + p.Item2)).Max());
			}
			byte[,] edgeClipMap = GetAreaShape(context.Random, areaSize, (byte)keepRange, ensureEdge: true);
			byte[,] availableBlockMap = new byte[areaSize, areaSize];
			for (byte x = 0; x < areaSize; x++)
			{
				for (byte y = 0; y < areaSize; y++)
				{
					if (edgeClipMap[x, y] == 0)
					{
						short blockId = ByteCoordinate.CoordinateToIndex(new ByteCoordinate(x, y), areaSize);
						areaBlocks[blockId] = new MapBlockData(areaId, blockId, 126);
						availableBlockMap[x, y] = 1;
					}
				}
			}
			if (taiwuVillageInArea)
			{
				PlaceTaiwuVillageAreaBlocks(context, areaId, areaConfigData, areaBlocks, availableBlockMap, staticBlockIdList, context.Random);
			}
			else
			{
				PlaceStaticBlocks(areaId, areaConfigData, areaSize, areaBlocks, availableBlockMap, edgeClipMap, staticBlockIdList, context.Random);
			}
			mapAreaData.Discovered = taiwuVillageInArea;
			PlaceOtherBlocks(areaId, areaConfigData, areaSize, areaBlocks, availableBlockMap, staticBlockIdList, settlementCount, context.Random);
			FixSeriesBlocks(areaConfigData, areaSize, areaBlocks, blockTypeDict, context.Random);
			FixEncircleBlocks(areaConfigData, areaSize, areaBlocks, blockTypeDict, context.Random);
		}
		else
		{
			short[][] presetMapData = CustomMapBlockConfig.Data[areaConfigData.CustomBlockConfig];
			areaSize = (byte)presetMapData.GetLength(0);
			for (byte i = 0; i < presetMapData.Length; i++)
			{
				short[] linePreset = presetMapData[i];
				for (byte j = 0; j < linePreset.Length; j++)
				{
					short blockTemplateId = linePreset[j];
					MapBlockItem blockConfig = MapBlock.Instance[blockTemplateId];
					if (blockConfig == null)
					{
						continue;
					}
					ByteCoordinate byteCoordinate = new ByteCoordinate(i, j);
					short blockId2 = ByteCoordinate.CoordinateToIndex(byteCoordinate, areaSize);
					MapBlockData block = areaBlocks[blockId2];
					if (block == null)
					{
						block = new MapBlockData(areaId, blockId2, blockTemplateId);
						block.Visible = true;
						areaBlocks[blockId2] = block;
						if (block.IsCityTown())
						{
							staticBlockIdList.Add(blockId2);
						}
						if (block.BlockType == EMapBlockType.Station)
						{
							mapAreaData.StationBlockId = blockId2;
						}
					}
					else if (-1 != block.RootBlockId)
					{
						continue;
					}
					if (blockConfig.Size <= 1)
					{
						continue;
					}
					for (byte aIndex = 0; aIndex < blockConfig.Size; aIndex++)
					{
						for (byte bIndex = 0; bIndex < blockConfig.Size; bIndex++)
						{
							if (aIndex + bIndex != 0 && byteCoordinate.X + aIndex < areaSize && byteCoordinate.Y + bIndex < areaSize)
							{
								ByteCoordinate childByteCoordinate = new ByteCoordinate((byte)(byteCoordinate.X + aIndex), (byte)(byteCoordinate.Y + bIndex));
								short childBlockId = ByteCoordinate.CoordinateToIndex(childByteCoordinate, areaSize);
								areaBlocks[childBlockId] = new MapBlockData(areaId, childBlockId, -1);
								areaBlocks[childBlockId].SetToSizeBlock(block);
								areaBlocks[childBlockId].Visible = true;
							}
						}
					}
				}
			}
			List<MapBlockData> rangeBlockList = ObjectPool<List<MapBlockData>>.Instance.Get();
			for (int i2 = 0; i2 < staticBlockIdList.Count; i2++)
			{
				bool shouldPrint = false;
				if (!staticBlockIdList.CheckIndex(i2))
				{
					shouldPrint = true;
					AdaptableLog.Warning($"staticBlockIdList invalid index: {i2}");
				}
				if (!areaBlocks.CheckIndex(staticBlockIdList[i2]))
				{
					shouldPrint = true;
					AdaptableLog.Warning($"areaBlocks invalid index: {staticBlockIdList[i2]}");
				}
				if (shouldPrint)
				{
					PrintAreaDebug(areaBlocks, areaSize);
					StringBuilder sb = new StringBuilder();
					int j2 = 0;
					for (int jc = staticBlockIdList.Count; j2 < jc; j2++)
					{
						if (j2 != 0)
						{
							sb.Append(", ");
						}
						StringBuilder stringBuilder = sb;
						StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder);
						handler.AppendFormatted(staticBlockIdList[j2]);
						stringBuilder.Append(ref handler);
					}
					AdaptableLog.Warning($"{"staticBlockIdList"}: {sb}");
					continue;
				}
				MapBlockData block2 = areaBlocks[staticBlockIdList[i2]];
				MapBlockItem blockConfig2 = block2.GetConfig();
				if (blockConfig2.Range <= 0)
				{
					continue;
				}
				ByteCoordinate byteCoordinate2 = ByteCoordinate.IndexToCoordinate(block2.BlockId, areaSize);
				rangeBlockList.Clear();
				for (byte x2 = (byte)Math.Max(byteCoordinate2.X - blockConfig2.Range, 0); x2 < Math.Min(byteCoordinate2.X + blockConfig2.Size + blockConfig2.Range, areaSize); x2++)
				{
					for (byte y2 = (byte)Math.Max(byteCoordinate2.Y - blockConfig2.Range, 0); y2 < Math.Min(byteCoordinate2.Y + blockConfig2.Size + blockConfig2.Range, areaSize); y2++)
					{
						MapBlockData neighborBlock = areaBlocks[ByteCoordinate.CoordinateToIndex(new ByteCoordinate(x2, y2), areaSize)].GetRootBlock();
						if (neighborBlock.BlockId != block2.BlockId && block2.GetManhattanDistanceToPos(x2, y2) <= blockConfig2.Range && neighborBlock.IsPassable() && !rangeBlockList.Contains(neighborBlock))
						{
							rangeBlockList.Add(neighborBlock);
						}
					}
				}
				foreach (MapBlockData rangeBlock in rangeBlockList)
				{
					if (rangeBlock.IsPassable() && rangeBlock.GetConfig().Size == 1 && rangeBlock.BelongBlockId == -1)
					{
						rangeBlock.BelongBlockId = block2.BlockId;
					}
				}
			}
			ObjectPool<List<MapBlockData>>.Instance.Return(rangeBlockList);
		}
		List<MapBlockData> maliceBlockRandomPool = ObjectPool<List<MapBlockData>>.Instance.Get();
		maliceBlockRandomPool.Clear();
		for (short blockId3 = 0; blockId3 < areaBlocks.Length; blockId3++)
		{
			MapBlockData block3 = areaBlocks[blockId3];
			if (block3.IsPassable())
			{
				block3.InitResources(context.Random);
				if (block3.GetConfig().MaxMalice > 0)
				{
					maliceBlockRandomPool.Add(block3);
				}
			}
		}
		int initMaliceBlockCount = maliceBlockRandomPool.Count * 5 / 100;
		for (int i3 = 0; i3 < initMaliceBlockCount; i3++)
		{
			int index = context.Random.Next(maliceBlockRandomPool.Count);
			MapBlockData block4 = maliceBlockRandomPool[index];
			short maxMalice = block4.GetMaxMalice();
			int initialMalicePercent = RedzenHelper.SkewDistribute(context.Random, 20f, 8f, 1.8f, 0, 80);
			block4.Malice = (short)(maxMalice * initialMalicePercent / 100);
			maliceBlockRandomPool.RemoveAt(index);
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(maliceBlockRandomPool);
		if (areaId < 45)
		{
			for (short blockId4 = 0; blockId4 < areaBlocks.Length; blockId4++)
			{
				AddRegularBlockData(context, new Location(areaId, blockId4), areaBlocks[blockId4]);
			}
			if (mapAreaData.StationBlockId >= 0)
			{
				areaBlocks[mapAreaData.StationBlockId].SetVisible(visible: true, context);
			}
		}
		else
		{
			switch (areaId)
			{
			case 135:
			{
				for (short blockId8 = 0; blockId8 < areaBlocks.Length; blockId8++)
				{
					AddElement_BornAreaBlocks(blockId8, areaBlocks[blockId8], context);
				}
				break;
			}
			case 136:
			{
				for (short blockId6 = 0; blockId6 < areaBlocks.Length; blockId6++)
				{
					AddElement_GuideAreaBlocks(blockId6, areaBlocks[blockId6], context);
				}
				break;
			}
			case 137:
			{
				for (short blockId7 = 0; blockId7 < areaBlocks.Length; blockId7++)
				{
					AddElement_SecretVillageAreaBlocks(blockId7, areaBlocks[blockId7], context);
				}
				break;
			}
			case 138:
			{
				for (short blockId5 = 0; blockId5 < areaBlocks.Length; blockId5++)
				{
					AddElement_BrokenPerformAreaBlocks(blockId5, areaBlocks[blockId5], context);
				}
				break;
			}
			}
		}
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		bool isStoryStockade = areaId == 138;
		if (isStoryStockade)
		{
			settlementCount = 1;
		}
		for (int i4 = 0; i4 < settlementCount; i4++)
		{
			short blockId9 = staticBlockIdList[i4];
			Location location = new Location(areaId, blockId9);
			MapBlockData block5 = areaBlocks[blockId9];
			bool isTaiwuVillage = block5.TemplateId == 0;
			sbyte orgTemplateId = (sbyte)(isStoryStockade ? 38 : ((!taiwuVillageInArea) ? areaConfigData.OrganizationId[i4] : (isTaiwuVillage ? 16 : areaConfigData.OrganizationId[i4 - 1])));
			_swCreatingSettlements.Start();
			short settlementId = DomainManager.Organization.CreateSettlement(context, location, orgTemplateId);
			_swCreatingSettlements.Stop();
			Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
			short randomNameId = (short)((settlement is CivilianSettlement cs) ? cs.GetRandomNameId() : (-1));
			mapAreaData.SettlementInfos[i4] = new SettlementInfo(settlementId, blockId9, settlement.GetOrgTemplateId(), randomNameId);
			if (isTaiwuVillage)
			{
				DomainManager.Taiwu.SetTaiwuVillageSettlementId(settlementId, context);
			}
			if (areaId != 137)
			{
				GetNeighborBlocks(areaId, blockId9, neighborBlocks, (areaId != 135) ? 1 : block5.GetConfig().ViewRange);
				block5.SetVisible(visible: true, context);
				if (block5.GroupBlockList != null)
				{
					for (int j3 = 0; j3 < block5.GroupBlockList.Count; j3++)
					{
						block5.SetVisible(visible: true, context);
					}
				}
				for (int j4 = 0; j4 < neighborBlocks.Count; j4++)
				{
					MapBlockData neighborBlock2 = neighborBlocks[j4];
					neighborBlock2.SetVisible(visible: true, context);
					if (neighborBlock2.GroupBlockList != null)
					{
						for (int k = 0; k < neighborBlock2.GroupBlockList.Count; k++)
						{
							neighborBlock2.GroupBlockList[k].SetVisible(visible: true, context);
						}
					}
				}
			}
			if (areaBlocks[blockId9].IsCityTown())
			{
				DomainManager.Building.CreateBuildingArea(context, areaId, blockId9, areaBlocks[blockId9].TemplateId);
				if (orgTemplateId == 16)
				{
					DomainManager.Building.AddTaiwuBuildingArea(context, new Location(areaId, blockId9));
				}
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
		ObjectPool<List<short>>.Instance.Return(staticBlockIdList);
		_swCreatingNormalAreas.Stop();
	}

	public static void PrintAreaDebug(Span<MapBlockData> blockCollection, byte areaSize)
	{
		StringBuilder sb = new StringBuilder();
		AdaptableLog.Info("The blockCollection is:");
		for (int y = 0; y < areaSize; y++)
		{
			sb.Clear();
			for (int x = 0; x < areaSize; x++)
			{
				short index = ByteCoordinate.CoordinateToIndex(new ByteCoordinate((byte)x, (byte)y), areaSize);
				StringBuilder stringBuilder = sb;
				StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(1, 1, stringBuilder);
				handler.AppendLiteral(" ");
				handler.AppendFormatted(blockCollection[index].TemplateId, "D3");
				stringBuilder.Append(ref handler);
			}
			AdaptableLog.Info(sb.ToString());
		}
		AdaptableLog.Info("The BelongBlockId is:");
		for (int i = 0; i < areaSize; i++)
		{
			sb.Clear();
			for (int j = 0; j < areaSize; j++)
			{
				short index2 = ByteCoordinate.CoordinateToIndex(new ByteCoordinate((byte)j, (byte)i), areaSize);
				int belongBlockId = ((blockCollection[index2] != null) ? blockCollection[index2].BelongBlockId : (-1));
				sb.Append((belongBlockId >= 0) ? $" {belongBlockId:D3}" : " XXX");
			}
			AdaptableLog.Info(sb.ToString());
		}
		AdaptableLog.Info("The TemplateId is:");
		for (int k = 0; k < areaSize; k++)
		{
			sb.Clear();
			for (int l = 0; l < areaSize; l++)
			{
				short index3 = ByteCoordinate.CoordinateToIndex(new ByteCoordinate((byte)l, (byte)k), areaSize);
				int templateId = ((blockCollection[index3] != null) ? blockCollection[index3].TemplateId : (-1));
				sb.Append((templateId >= 0) ? $" {templateId:D3}" : " XXX");
			}
			AdaptableLog.Info(sb.ToString());
		}
	}

	private void CreateBrokenArea(DataContext context, MapAreaData mapAreaData, short areaId, List<short> ruinBlockRandomPool, List<short> ruinBigBlockRandomPool)
	{
		byte areaSize = 5;
		short blockIdBegin = (short)(areaSize * areaSize * (areaId - 45));
		byte[,] edgeClipMap = GetAreaShape(context.Random, areaSize, areaSize, ensureEdge: true);
		List<short> validBlockIdList = ObjectPool<List<short>>.Instance.Get();
		short bigBlockId = -1;
		for (byte x = 0; x < areaSize - 1; x++)
		{
			for (byte y = 0; y < areaSize - 1; y++)
			{
				if (edgeClipMap[x, y] * edgeClipMap[x, y + 1] * edgeClipMap[x + 1, y] * edgeClipMap[x + 1, y + 1] != 0)
				{
					validBlockIdList.Add((short)((x << 8) | y));
				}
			}
		}
		MapBlockData bigBlock = null;
		if (validBlockIdList.Count > 0)
		{
			bigBlockId = validBlockIdList[context.Random.Next(validBlockIdList.Count)];
			byte x2 = (byte)(bigBlockId >> 8);
			byte y2 = (byte)(bigBlockId & 0xFF);
			edgeClipMap[x2, y2] = byte.MaxValue;
			edgeClipMap[x2, y2 + 1] = (edgeClipMap[x2 + 1, y2] = (edgeClipMap[x2 + 1, y2 + 1] = 254));
			bigBlock = new MapBlockData(areaId, ByteCoordinate.CoordinateToIndex(new ByteCoordinate(x2, y2), areaSize), ruinBigBlockRandomPool[context.Random.Next(ruinBigBlockRandomPool.Count)]);
		}
		validBlockIdList.Clear();
		for (byte x3 = 0; x3 < areaSize; x3++)
		{
			for (byte y3 = 0; y3 < areaSize; y3++)
			{
				short blockId = ByteCoordinate.CoordinateToIndex(new ByteCoordinate(x3, y3), areaSize);
				MapBlockData block = null;
				bool validBlock = edgeClipMap[x3, y3] != 0;
				if (edgeClipMap[x3, y3] >= 128)
				{
					if (edgeClipMap[x3, y3] == byte.MaxValue)
					{
						block = bigBlock;
					}
					else
					{
						block = new MapBlockData(areaId, blockId, -1);
						block.SetToSizeBlock(bigBlock);
					}
				}
				else
				{
					short blockTemplateId = (short)(validBlock ? ruinBlockRandomPool[context.Random.Next(ruinBlockRandomPool.Count)] : 126);
					if (validBlock)
					{
						validBlockIdList.Add(blockId);
					}
					block = new MapBlockData(areaId, blockId, blockTemplateId);
				}
				block.InitResources(context.Random);
				AddElement_BrokenAreaBlocks((short)(blockIdBegin + blockId), block, context);
			}
		}
		mapAreaData.Discovered = false;
		mapAreaData.StationBlockId = validBlockIdList[context.Random.Next(validBlockIdList.Count)];
		MapBlockData stationBlock = _brokenAreaBlocks[(short)(blockIdBegin + mapAreaData.StationBlockId)];
		stationBlock.ChangeTemplateId(38, checkCanChange: false);
		stationBlock.SetVisible(visible: true, context);
		SetElement_BrokenAreaBlocks((short)(blockIdBegin + mapAreaData.StationBlockId), stationBlock, context);
		ObjectPool<List<short>>.Instance.Return(validBlockIdList);
	}

	private byte[,] GetAreaShape(IRandomSource random, byte mapSize, byte keepRange, bool ensureEdge = false)
	{
		if (mapSize < keepRange)
		{
			AdaptableLog.TagWarning("MapCreate", "error,sizeMax < sizeMin");
			return null;
		}
		byte[,] map = new byte[mapSize, mapSize];
		byte centerPos = (byte)(mapSize / 2 - 1);
		float safeRange = (float)(int)keepRange / 2f;
		ByteCoordinate center = new ByteCoordinate(centerPos, centerPos);
		List<ByteCoordinate> smoothPosList = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		smoothPosList.Clear();
		for (byte i = 0; i < mapSize; i++)
		{
			for (byte j = 0; j < mapSize; j++)
			{
				ByteCoordinate pos = new ByteCoordinate(i, j);
				if (ByteCoordinate.Distance(center, pos) > (double)safeRange)
				{
					byte rate = 50;
					if (ensureEdge && (i == 0 || i == mapSize - 1 || j == 0 || j == mapSize - 1))
					{
						rate += 25;
					}
					map[i, j] = (byte)((random.Next(100) < rate) ? 1u : 0u);
					smoothPosList.Add(pos);
				}
				else
				{
					map[i, j] = 1;
				}
			}
		}
		for (int a = 0; a < 1; a++)
		{
			for (int s = 0; s < smoothPosList.Count; s++)
			{
				ByteCoordinate pos2 = smoothPosList[s];
				int wallCount = CountWalls(pos2.X, pos2.Y);
				if (wallCount > 4)
				{
					map[pos2.X, pos2.Y] = 0;
				}
				else if (wallCount < 4)
				{
					map[pos2.X, pos2.Y] = 1;
				}
			}
		}
		ObjectPool<List<ByteCoordinate>>.Instance.Return(smoothPosList);
		List<ByteCoordinate> island = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		List<ByteCoordinate> edgeWallList = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		island.Clear();
		SpreadIsland(center, island, mapSize, CanPass, new byte[mapSize, mapSize]);
		for (byte i2 = 0; i2 < mapSize; i2++)
		{
			for (byte j2 = 0; j2 < mapSize; j2++)
			{
				if (!island.Contains(new ByteCoordinate(i2, j2)))
				{
					map[i2, j2] = 0;
				}
			}
		}
		island.Clear();
		edgeWallList.Clear();
		for (byte i3 = 0; i3 < mapSize - 1; i3++)
		{
			if (map[0, i3] == 0)
			{
				edgeWallList.Add(new ByteCoordinate(0, i3));
			}
			if (map[(byte)(i3 + 1), (byte)(mapSize - 1)] == 0)
			{
				edgeWallList.Add(new ByteCoordinate((byte)(i3 + 1), (byte)(mapSize - 1)));
			}
			if (map[i3, (byte)(mapSize - 1)] == 0)
			{
				edgeWallList.Add(new ByteCoordinate(i3, (byte)(mapSize - 1)));
			}
			if (map[(byte)(mapSize - 1), (byte)(i3 + 1)] == 0)
			{
				edgeWallList.Add(new ByteCoordinate((byte)(mapSize - 1), (byte)(i3 + 1)));
			}
		}
		while (edgeWallList.Count > 0)
		{
			SpreadIsland(edgeWallList[0], island, mapSize, IsWall, new byte[mapSize, mapSize]);
			edgeWallList.RemoveAll((ByteCoordinate item) => island.Contains(item));
		}
		for (byte i4 = 0; i4 < mapSize; i4++)
		{
			for (byte j3 = 0; j3 < mapSize; j3++)
			{
				if (!island.Contains(new ByteCoordinate(i4, j3)))
				{
					map[i4, j3] = 1;
				}
			}
		}
		for (byte i5 = 0; i5 < mapSize; i5++)
		{
			for (byte j4 = 0; j4 < mapSize; j4++)
			{
				if (map[i5, j4] == 1 && (i5 == 0 || i5 == mapSize - 1 || j4 == 0 || j4 == mapSize - 1 || map[i5 - 1, j4] == 0 || map[i5 + 1, j4] == 0 || map[i5, j4 - 1] == 0 || map[i5, j4 + 1] == 0))
				{
					map[i5, j4] = 2;
				}
			}
		}
		ObjectPool<List<ByteCoordinate>>.Instance.Return(island);
		ObjectPool<List<ByteCoordinate>>.Instance.Return(edgeWallList);
		return map;
		bool CanPass(ByteCoordinate byteCoordinate)
		{
			return map[byteCoordinate.X, byteCoordinate.Y] == 1;
		}
		int CountWalls(int x, int y)
		{
			int wallCount2 = 0;
			for (int k = x - 1; k <= x + 1; k++)
			{
				for (int l = y - 1; l <= y + 1; l++)
				{
					if (k != x || l != y)
					{
						wallCount2 = ((k < 0 || k >= mapSize || l < 0 || l >= mapSize) ? (wallCount2 + 1) : (wallCount2 + ((map[k, l] == 0) ? 1 : 0)));
					}
				}
			}
			return wallCount2;
		}
		bool IsWall(ByteCoordinate byteCoordinate)
		{
			return map[byteCoordinate.X, byteCoordinate.Y] == 0;
		}
	}

	private void PlaceTaiwuVillageAreaBlocks(DataContext context, short areaId, MapAreaItem areaConfigData, MapBlockData[] areaBlocks, byte[,] availableBlockMap, List<short> staticBlockIds, IRandomSource random)
	{
		HashSet<ByteCoordinate> emptyPos = new HashSet<ByteCoordinate>();
		byte areaSize = (byte)GlobalConfig.Instance.TaiwuVillageForceAreaSize;
		for (byte x = 0; x < areaSize; x++)
		{
			for (byte y = 0; y < areaSize; y++)
			{
				if (availableBlockMap[x, y] != 1)
				{
					emptyPos.Add(new ByteCoordinate(x, y));
				}
			}
		}
		int attempts = 0;
		Dictionary<short, ByteCoordinate> coordinates;
		List<EightDirection> swordTombCoordinates;
		while (!TryGetTaiwuVillageBlockCoordinates(areaConfigData, emptyPos, random, out coordinates, out swordTombCoordinates))
		{
			attempts++;
			if (attempts >= GlobalConfig.Instance.MaxTaiwuVillageAreaCreateCount)
			{
				throw new Exception("Cannot Create Taiwu Village Area");
			}
		}
		foreach (KeyValuePair<short, ByteCoordinate> item in coordinates)
		{
			item.Deconstruct(out var key, out var value);
			short templateId = key;
			ByteCoordinate coordinate = value;
			bool isTaiwuVillage = templateId == 0;
			PlaceStaticBlock(areaId, areaConfigData, areaSize, areaBlocks, templateId, coordinate, availableBlockMap, random, isTaiwuVillage, isTaiwuVillage);
			staticBlockIds.Add(ByteCoordinate.CoordinateToIndex(coordinate, areaSize));
		}
		ByteCoordinate center = GetAreaCenter(areaSize);
		for (int i = 0; i < swordTombCoordinates.Count; i++)
		{
			ByteCoordinate coordinate2 = new ByteCoordinate((byte)(swordTombCoordinates[i].X + center.X), (byte)(swordTombCoordinates[i].Y + center.Y));
			SetElement_SwordTombLocations(i, new Location(areaId, ByteCoordinate.CoordinateToIndex(coordinate2, areaSize)), context);
			AdaptableLog.Info($"Generating Sword Tomb Location: {coordinate2.X}, {coordinate2.Y}");
		}
	}

	private ByteCoordinate GetAreaCenter(byte areaSize)
	{
		return new ByteCoordinate((byte)((areaSize - 1) / 2), (byte)((areaSize - 1) / 2));
	}

	public bool TryGetTaiwuVillageBlockCoordinates(MapAreaItem areaConfigData, HashSet<ByteCoordinate> emptyPos, IRandomSource random, out Dictionary<short, ByteCoordinate> coordinates, out List<EightDirection> selected)
	{
		coordinates = new Dictionary<short, ByteCoordinate>();
		selected = new List<EightDirection>();
		byte areaSize = (byte)GlobalConfig.Instance.TaiwuVillageForceAreaSize;
		ByteCoordinate center = GetAreaCenter(areaSize);
		if (SimulateBlockOccupied(areaSize, 0, emptyPos, center))
		{
			coordinates.Add(0, center);
			short[] settlementBlockCore = areaConfigData.SettlementBlockCore;
			foreach (short templateId in settlementBlockCore)
			{
				if (!TryGetCanPlacePos(templateId, emptyPos, random, out var coordinate))
				{
					return false;
				}
				if (SimulateBlockOccupied(areaSize, templateId, emptyPos, coordinate))
				{
					coordinates.Add(templateId, coordinate);
					continue;
				}
				return false;
			}
			if (areaConfigData.SceneryBlockCore != null)
			{
				short[] sceneryBlockCore = areaConfigData.SceneryBlockCore;
				foreach (short templateId2 in sceneryBlockCore)
				{
					if (!TryGetCanPlacePos(templateId2, emptyPos, random, out var coordinate2))
					{
						return false;
					}
					if (SimulateBlockOccupied(areaSize, templateId2, emptyPos, coordinate2))
					{
						coordinates.Add(templateId2, coordinate2);
						continue;
					}
					return false;
				}
			}
			if (areaConfigData.BigBaseBlockCore != null)
			{
				foreach (short[] bigBlock in areaConfigData.BigBaseBlockCore)
				{
					int count = ((bigBlock[1] == 1) ? 1 : random.Next(1, bigBlock[1]));
					for (int k = 0; k < count; k++)
					{
						if (!TryGetCanPlacePos(bigBlock[0], emptyPos, random, out var coordinate3))
						{
							return false;
						}
						if (SimulateBlockOccupied(areaSize, bigBlock[0], emptyPos, coordinate3))
						{
							coordinates.Add(bigBlock[0], coordinate3);
							continue;
						}
						return false;
					}
				}
			}
			if (emptyPos.Count < SwordTomb.Instance.Count)
			{
				return false;
			}
			Dictionary<sbyte, List<EightDirection>> coordinateEightDirectionData = new Dictionary<sbyte, List<EightDirection>>();
			foreach (ByteCoordinate pos in emptyPos)
			{
				if (CheckCanPlace(128, emptyPos, pos))
				{
					EightDirection eightDirection = new EightDirection(center, pos);
					coordinateEightDirectionData.TryAdd(eightDirection.Direction, new List<EightDirection>());
					coordinateEightDirectionData[eightDirection.Direction].Add(eightDirection);
				}
			}
			if (coordinateEightDirectionData.Count < 8)
			{
				return false;
			}
			List<EightDirection> canSelect = new List<EightDirection>();
			Span<sbyte> span = stackalloc sbyte[8];
			SpanList<sbyte> randomDirections = span;
			randomDirections.Add(0);
			randomDirections.Add(1);
			randomDirections.Add(2);
			randomDirections.Add(3);
			randomDirections.Add(4);
			randomDirections.Add(5);
			randomDirections.Add(6);
			randomDirections.Add(7);
			CollectionUtils.Shuffle(random, randomDirections);
			for (sbyte i2 = 0; i2 < 8; i2++)
			{
				sbyte direction = randomDirections[i2];
				canSelect.Clear();
				foreach (EightDirection data in coordinateEightDirectionData[direction])
				{
					int score = GetSwordTombPositionScore(data, i2, selected);
					if (score >= 0)
					{
						canSelect.Add(new EightDirection(data, score));
					}
				}
				if (canSelect.Count == 0)
				{
					return false;
				}
				CollectionUtils.Shuffle(random, canSelect);
				if (canSelect.Count >= GlobalConfig.Instance.MaxSwordTombCanSelectCount)
				{
					canSelect.RemoveRange(GlobalConfig.Instance.MaxSwordTombCanSelectCount, canSelect.Count - GlobalConfig.Instance.MaxSwordTombCanSelectCount);
				}
				canSelect.Sort((EightDirection a, EightDirection b) => -a.Value.CompareTo(b.Value));
				selected.Add(canSelect[0]);
			}
			int smallestIndex = 0;
			for (int index = 1; index < selected.Count; index++)
			{
				if (selected[index].GetManhattanDistance(EightDirection.Origin) < selected[smallestIndex].GetManhattanDistance(EightDirection.Origin))
				{
					smallestIndex = index;
				}
			}
			List<EightDirection> list = selected;
			int index2 = smallestIndex;
			List<EightDirection> obj = selected;
			EightDirection value = selected[0];
			EightDirection value2 = selected[smallestIndex];
			list[index2] = value;
			obj[0] = value2;
			return true;
		}
		return false;
	}

	private bool TryGetCanPlacePos(short templateId, HashSet<ByteCoordinate> emptyPos, IRandomSource random, out ByteCoordinate pos)
	{
		do
		{
			pos = emptyPos.ElementAt(random.Next(emptyPos.Count));
			if (CheckCanPlace(templateId, emptyPos, pos))
			{
				return true;
			}
			emptyPos.Remove(pos);
		}
		while (emptyPos.Count > 0);
		return false;
	}

	private bool CheckCanPlace(short templateId, HashSet<ByteCoordinate> emptyPos, ByteCoordinate pos)
	{
		MapBlockItem config = MapBlock.Instance[templateId];
		if (config.Range > 0)
		{
			int xMin = pos.X - config.Range;
			int yMin = pos.Y - config.Range;
			int xMax = pos.X + config.Size + config.Range;
			int yMax = pos.Y + config.Size + config.Range;
			for (int i = xMin; i < xMax; i++)
			{
				for (int j = yMin; j < yMax; j++)
				{
					if (!emptyPos.Contains(new ByteCoordinate((byte)i, (byte)j)))
					{
						return false;
					}
				}
			}
		}
		else if (config.Size > 1)
		{
			for (int k = 0; k < config.Size; k++)
			{
				for (int l = 0; l < config.Size; l++)
				{
					if (!emptyPos.Contains(new ByteCoordinate((byte)(pos.X + k), (byte)(pos.Y + l))))
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	private int GetSwordTombPositionScore(EightDirection curr, int index, List<EightDirection> selected)
	{
		int distance = curr.GetManhattanDistance(EightDirection.Origin);
		if (index == 0)
		{
			if (distance < GlobalConfig.Instance.SwordTombFirstBestDistanceRange[0])
			{
				return -1;
			}
		}
		else if (distance < GlobalConfig.Instance.SwordTombNormalBestDistanceRange[0])
		{
			return -1;
		}
		if (distance > GlobalConfig.Instance.SwordTombNormalBestDistanceRange[1] * 2)
		{
			return -1;
		}
		foreach (EightDirection item in selected)
		{
			if (item.GetManhattanDistance(curr) < GlobalConfig.Instance.SwordTombMinimumDistance)
			{
				return -1;
			}
		}
		int score = ((curr.Value == 0) ? GlobalConfig.Instance.SwordTombRightDirectionPoint : Math.Min(0, GlobalConfig.Instance.SwordTombNormalDirectionPoint - curr.Value * GlobalConfig.Instance.SwordTombNormalDirectionOffset));
		if (index == 0)
		{
			if (distance >= GlobalConfig.Instance.SwordTombFirstBestDistanceRange[0] && distance <= GlobalConfig.Instance.SwordTombFirstBestDistanceRange[1])
			{
				score += GlobalConfig.Instance.SwordTombBestDistanceRangePoint;
			}
		}
		else if (distance >= GlobalConfig.Instance.SwordTombNormalBestDistanceRange[0] && distance <= GlobalConfig.Instance.SwordTombNormalBestDistanceRange[1])
		{
			score += GlobalConfig.Instance.SwordTombBestDistanceRangePoint;
		}
		return score;
	}

	private bool SimulateBlockOccupied(byte areaSize, short blockTemplateId, HashSet<ByteCoordinate> emptyPos, ByteCoordinate byteCoordinate)
	{
		MapBlockItem blockConfig = MapBlock.Instance[blockTemplateId];
		List<ByteCoordinate> staticBlockLocationList = new List<ByteCoordinate>();
		staticBlockLocationList.Clear();
		staticBlockLocationList.Add(byteCoordinate);
		emptyPos.Remove(byteCoordinate);
		if (blockConfig.Size > 1)
		{
			for (byte i = 0; i < blockConfig.Size; i++)
			{
				for (byte j = 0; j < blockConfig.Size; j++)
				{
					if (i + j != 0 && byteCoordinate.X + i < areaSize && byteCoordinate.Y + j < areaSize)
					{
						ByteCoordinate childByteCoordinate = new ByteCoordinate((byte)(byteCoordinate.X + i), (byte)(byteCoordinate.Y + j));
						emptyPos.Remove(childByteCoordinate);
						staticBlockLocationList.Add(childByteCoordinate);
					}
				}
			}
		}
		if (blockConfig.Range > 0)
		{
			int xMin = Math.Max(0, byteCoordinate.X - blockConfig.Range);
			int yMin = Math.Max(0, byteCoordinate.Y - blockConfig.Range);
			int xMax = Math.Min(areaSize - 1, byteCoordinate.X + blockConfig.Size + blockConfig.Range);
			int yMax = Math.Min(areaSize - 1, byteCoordinate.Y + blockConfig.Size + blockConfig.Range);
			for (byte i2 = (byte)xMin; i2 < xMax; i2++)
			{
				for (byte j2 = (byte)yMin; j2 < yMax; j2++)
				{
					ByteCoordinate rangeByteCoordinate = new ByteCoordinate(i2, j2);
					if (rangeByteCoordinate.GetMinManhattanDistance(staticBlockLocationList) <= blockConfig.Range)
					{
						emptyPos.Remove(rangeByteCoordinate);
					}
				}
			}
		}
		return emptyPos.Count != 0;
	}

	private void PlaceStaticBlocks(short areaId, MapAreaItem areaConfigData, byte mapSize, MapBlockData[] areaBlocks, byte[,] availableBlockMap, byte[,] edgeClipMap, List<short> staticBlockIds, IRandomSource random)
	{
		List<short> staticBlockCore = ObjectPool<List<short>>.Instance.Get();
		staticBlockCore.Clear();
		if (areaId == 138)
		{
			staticBlockCore.Add(36);
		}
		else
		{
			staticBlockCore.AddRange(areaConfigData.SettlementBlockCore);
		}
		int settlementCount = staticBlockCore.Count;
		if (areaConfigData.SceneryBlockCore != null)
		{
			staticBlockCore.AddRange(areaConfigData.SceneryBlockCore);
		}
		if (areaConfigData.BigBaseBlockCore != null)
		{
			for (int i = 0; i < areaConfigData.BigBaseBlockCore.Count; i++)
			{
				short[] bigBlock = areaConfigData.BigBaseBlockCore[i];
				int count = ((bigBlock[1] == 1) ? 1 : random.Next(1, bigBlock[1]));
				for (int j = 0; j < count; j++)
				{
					staticBlockCore.Add(bigBlock[0]);
				}
			}
		}
		staticBlockIds.Clear();
		if (staticBlockCore.Contains(areaConfigData.CenterBlock))
		{
			ByteCoordinate center = new ByteCoordinate((byte)((mapSize - 1) / 2), (byte)((mapSize - 1) / 2));
			PlaceStaticBlock(areaId, areaConfigData, mapSize, areaBlocks, areaConfigData.CenterBlock, center, availableBlockMap, random);
			staticBlockIds.Add(ByteCoordinate.CoordinateToIndex(center, mapSize));
			staticBlockCore.Remove(areaConfigData.CenterBlock);
			settlementCount--;
		}
		if (staticBlockCore.Count > 0)
		{
			List<ByteCoordinate> canUsePosList = ObjectPool<List<ByteCoordinate>>.Instance.Get();
			ByteCoordinate center2 = GetAreaCenter(mapSize);
			int maxBlockRange = 0;
			MapBlock.Instance.Iterate(delegate(MapBlockItem b)
			{
				maxBlockRange = Math.Max(maxBlockRange, b.Range * 2);
				return true;
			});
			for (int index = 0; index < staticBlockCore.Count; index++)
			{
				MapBlockItem blockConfig = MapBlock.Instance[staticBlockCore[index]];
				GetStaticBlockPosRandomPool(blockConfig, mapSize, availableBlockMap, edgeClipMap, canUsePosList);
				canUsePosList.RemoveAll((ByteCoordinate coord) => coord.GetManhattanDistance(center2) <= maxBlockRange);
				if (index < settlementCount && canUsePosList.Count == 0)
				{
					GetStaticBlockPosRandomPool(blockConfig, mapSize, availableBlockMap, edgeClipMap, canUsePosList, calcRange: false);
				}
				canUsePosList.RemoveAll((ByteCoordinate coord) => coord.GetManhattanDistance(center2) <= maxBlockRange);
				canUsePosList.RemoveAll(delegate(ByteCoordinate coord)
				{
					short num = ByteCoordinate.CoordinateToIndex(coord, mapSize);
					byte blockRange = GetBlockRange(areaId, blockConfig.TemplateId);
					int num2 = Math.Max(0, coord.X - blockRange);
					int num3 = Math.Max(0, coord.Y - blockRange);
					int num4 = Math.Min(mapSize - 1, coord.X + blockConfig.Size + blockRange);
					int num5 = Math.Min(mapSize - 1, coord.Y + blockConfig.Size + blockRange);
					for (byte b = (byte)num2; b < num4; b++)
					{
						for (byte b2 = (byte)num3; b2 < num5; b2++)
						{
							short num6 = ByteCoordinate.CoordinateToIndex(new ByteCoordinate(b, b2), mapSize);
							MapBlockData mapBlockData = areaBlocks[num6];
							if (mapBlockData != null && (mapBlockData.BelongBlockId >= 0 || mapBlockData.IsCityTown()))
							{
								return true;
							}
						}
					}
					return areaBlocks[num] != null && (areaBlocks[num].BelongBlockId >= 0 || areaBlocks[num].IsCityTown());
				});
				if (index < settlementCount && canUsePosList.Count == 0)
				{
					throw new Exception($"Area {areaId} is too small to place the {index} static block {blockConfig.TemplateId}");
				}
				if (canUsePosList.Count > 0)
				{
					ByteCoordinate byteCoordinate = ((areaId == 138 && blockConfig.TemplateId == 36) ? center2 : canUsePosList.GetRandom(random));
					PlaceStaticBlock(areaId, areaConfigData, mapSize, areaBlocks, staticBlockCore[index], byteCoordinate, availableBlockMap, random, index == areaConfigData.StationLocate);
					staticBlockIds.Add(ByteCoordinate.CoordinateToIndex(byteCoordinate, mapSize));
				}
			}
			ObjectPool<List<ByteCoordinate>>.Instance.Return(canUsePosList);
		}
		ObjectPool<List<short>>.Instance.Return(staticBlockCore);
	}

	private void GetStaticBlockPosRandomPool(MapBlockItem blockConfig, byte mapSize, byte[,] availableBlockMap, byte[,] edgeClipMap, List<ByteCoordinate> posList, bool calcRange = true)
	{
		posList.Clear();
		for (byte x = 0; x < mapSize; x++)
		{
			for (byte y = 0; y < mapSize; y++)
			{
				bool canUse = true;
				int minI = (calcRange ? (x - blockConfig.Range) : x);
				int minJ = (calcRange ? (y - blockConfig.Range) : y);
				int maxI = (calcRange ? (x + blockConfig.Size + blockConfig.Range) : (x + blockConfig.Size));
				int maxJ = (calcRange ? (y + blockConfig.Size + blockConfig.Range) : (y + blockConfig.Size));
				for (int i = minI; i < maxI; i++)
				{
					for (int j = minJ; j < maxJ; j++)
					{
						if (i <= 0 || i >= mapSize - 1 || j <= 0 || j >= mapSize - 1 || availableBlockMap[i, j] == 1 || edgeClipMap[i, j] != 1)
						{
							canUse = false;
							break;
						}
					}
					if (!canUse)
					{
						break;
					}
				}
				if (canUse)
				{
					posList.Add(new ByteCoordinate(x, y));
				}
			}
		}
	}

	private byte GetBlockRange(short areaId, short blockTemplateId)
	{
		MapBlockItem blockConfig = MapBlock.Instance[blockTemplateId];
		if (areaId == 138 && blockConfig.TemplateId == 36)
		{
			return 2;
		}
		return blockConfig.Range;
	}

	private byte GetBlockRange(MapBlockData blockData)
	{
		return GetBlockRange(blockData.AreaId, blockData.TemplateId);
	}

	private void PlaceStaticBlock(short areaId, MapAreaItem areaConfigData, byte areaSize, MapBlockData[] areaBlocks, short blockTemplateId, ByteCoordinate byteCoordinate, byte[,] availableBlockMap, IRandomSource random, bool hasStation = false, bool createTaiwuVillage = false)
	{
		short blockId = ByteCoordinate.CoordinateToIndex(byteCoordinate, areaSize);
		MapBlockData staticBlock = new MapBlockData(areaId, blockId, blockTemplateId);
		MapBlockItem blockConfig = MapBlock.Instance[blockTemplateId];
		List<ByteCoordinate> staticBlockLocationList = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		areaBlocks[blockId] = staticBlock;
		staticBlockLocationList.Clear();
		staticBlockLocationList.Add(byteCoordinate);
		availableBlockMap[byteCoordinate.X, byteCoordinate.Y] = 1;
		if (blockConfig.Size > 1)
		{
			for (byte i = 0; i < blockConfig.Size; i++)
			{
				for (byte j = 0; j < blockConfig.Size; j++)
				{
					if (i + j != 0 && byteCoordinate.X + i < areaSize && byteCoordinate.Y + j < areaSize)
					{
						ByteCoordinate childByteCoordinate = new ByteCoordinate((byte)(byteCoordinate.X + i), (byte)(byteCoordinate.Y + j));
						short childBlockId = ByteCoordinate.CoordinateToIndex(childByteCoordinate, areaSize);
						availableBlockMap[childByteCoordinate.X, childByteCoordinate.Y] = 1;
						areaBlocks[childBlockId] = new MapBlockData(areaId, childBlockId, -1);
						areaBlocks[childBlockId].SetToSizeBlock(staticBlock);
						staticBlockLocationList.Add(childByteCoordinate);
					}
				}
			}
		}
		byte blockRange = GetBlockRange(staticBlock);
		if (blockRange > 0)
		{
			int xMin = Math.Max(0, byteCoordinate.X - blockRange);
			int yMin = Math.Max(0, byteCoordinate.Y - blockRange);
			int xMax = Math.Min(areaSize - 1, byteCoordinate.X + blockConfig.Size + blockRange);
			int yMax = Math.Min(areaSize - 1, byteCoordinate.Y + blockConfig.Size + blockRange);
			List<short> rangeBlockList = ObjectPool<List<short>>.Instance.Get();
			List<short[]> blockTemplateIdList = ObjectPool<List<short[]>>.Instance.Get();
			rangeBlockList.Clear();
			for (byte i2 = (byte)xMin; i2 < xMax; i2++)
			{
				for (byte j2 = (byte)yMin; j2 < yMax; j2++)
				{
					ByteCoordinate rangeByteCoordinate = new ByteCoordinate(i2, j2);
					if (rangeByteCoordinate.GetMinManhattanDistance(staticBlockLocationList) <= blockRange && availableBlockMap[i2, j2] != 1)
					{
						availableBlockMap[i2, j2] = 1;
						rangeBlockList.Add(ByteCoordinate.CoordinateToIndex(rangeByteCoordinate, areaSize));
					}
				}
			}
			blockTemplateIdList.Clear();
			RandomUtils.GenerateRandomWeightCellList(random, areaConfigData.DevelopedBlockCore, rangeBlockList.Count, ref blockTemplateIdList);
			for (int k = 0; k < rangeBlockList.Count; k++)
			{
				short rangeBlockId = rangeBlockList[k];
				areaBlocks[rangeBlockId] = new MapBlockData(areaId, rangeBlockId, blockTemplateIdList[k][0]);
				areaBlocks[rangeBlockId].BelongBlockId = blockId;
			}
			if (hasStation)
			{
				if (rangeBlockList.Count <= 0)
				{
					StringBuilder sb = new StringBuilder();
					AdaptableLog.Info("The availableBlockMap is:");
					for (int y = 0; y < areaSize; y++)
					{
						sb.Clear();
						for (int x = 0; x < areaSize; x++)
						{
							if (x != 0)
							{
								sb.Append(" ");
							}
							StringBuilder stringBuilder = sb;
							StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder);
							handler.AppendFormatted(availableBlockMap[x, y]);
							stringBuilder.Append(ref handler);
						}
						AdaptableLog.Info(sb.ToString());
					}
					AdaptableLog.Info("The BelongBlockId is:");
					for (int l = 0; l < areaSize; l++)
					{
						sb.Clear();
						for (int m = 0; m < areaSize; m++)
						{
							short index = ByteCoordinate.CoordinateToIndex(new ByteCoordinate((byte)m, (byte)l), areaSize);
							int belongBlockId = ((areaBlocks[index] != null) ? areaBlocks[index].BelongBlockId : (-1));
							if (m != 0)
							{
								sb.Append(" ");
							}
							sb.Append((belongBlockId >= 0) ? $"{belongBlockId:D3}" : "XXX");
						}
						AdaptableLog.Info(sb.ToString());
					}
					AdaptableLog.Info("The TemplateId is:");
					for (int n = 0; n < areaSize; n++)
					{
						sb.Clear();
						for (int num = 0; num < areaSize; num++)
						{
							short index2 = ByteCoordinate.CoordinateToIndex(new ByteCoordinate((byte)num, (byte)n), areaSize);
							int templateId = ((areaBlocks[index2] != null) ? areaBlocks[index2].TemplateId : (-1));
							if (num != 0)
							{
								sb.Append(" ");
							}
							sb.Append((templateId >= 0) ? $"{templateId:D3}" : "XXX");
						}
						AdaptableLog.Info(sb.ToString());
					}
					throw new Exception($"rangeBlockList.Count must be > 0 when creating station | (templateId: {blockConfig.TemplateId}, areaSize: {areaSize}, coord: {byteCoordinate.X}, {byteCoordinate.Y})");
				}
				List<short> majorStations = ObjectPool<List<short>>.Instance.Get();
				majorStations.Clear();
				majorStations.AddRange(rangeBlockList.Where(delegate(short bId)
				{
					ByteCoordinate byteCoordinate2 = ByteCoordinate.IndexToCoordinate(bId, areaSize);
					if (staticBlockLocationList.Contains(byteCoordinate2))
					{
						return false;
					}
					foreach (ByteCoordinate item in staticBlockLocationList)
					{
						if (item.GetManhattanDistance(byteCoordinate2) != 2)
						{
							return false;
						}
					}
					return true;
				}));
				MapAreaData mapAreaData = _areas[areaId];
				MapBlockData stationBlock = null;
				stationBlock = ((majorStations.Count <= 0) ? areaBlocks[rangeBlockList.OrderByDescending(delegate(short bId)
				{
					ByteCoordinate coord = ByteCoordinate.IndexToCoordinate(bId, areaSize);
					return (!staticBlockLocationList.Contains(coord)) ? staticBlockLocationList.Max((ByteCoordinate groupCoord) => groupCoord.GetManhattanDistance(coord)) : 0;
				}).First()] : areaBlocks[majorStations.GetRandom(random)]);
				if (areaId == 138 || createTaiwuVillage)
				{
					stationBlock.ChangeTemplateId(38, checkCanChange: false);
				}
				else
				{
					stationBlock.ChangeTemplateId(37, checkCanChange: false);
				}
				mapAreaData.StationBlockId = stationBlock.BlockId;
				ObjectPool<List<short>>.Instance.Return(majorStations);
			}
			ObjectPool<List<short>>.Instance.Return(rangeBlockList);
			ObjectPool<List<short[]>>.Instance.Return(blockTemplateIdList);
		}
		ObjectPool<List<ByteCoordinate>>.Instance.Return(staticBlockLocationList);
	}

	private void PlaceOtherBlocks(short areaId, MapAreaItem areaConfigData, byte areaSize, MapBlockData[] areaBlocks, byte[,] availableBlockMap, List<short> staticBlockIds, int settlementCount, IRandomSource random)
	{
		List<MapBlockData> staticBlockList = ObjectPool<List<MapBlockData>>.Instance.Get();
		List<short> normalBlockIdList = ObjectPool<List<short>>.Instance.Get();
		List<short[]> normalTemplateIdList = ObjectPool<List<short[]>>.Instance.Get();
		List<short> wildBlockIdList = ObjectPool<List<short>>.Instance.Get();
		List<short[]> wildTemplateIdList = ObjectPool<List<short[]>>.Instance.Get();
		staticBlockList.Clear();
		for (int i = 0; i < settlementCount; i++)
		{
			staticBlockList.Add(areaBlocks[staticBlockIds[i]]);
		}
		normalBlockIdList.Clear();
		wildBlockIdList.Clear();
		for (byte x = 0; x < areaSize; x++)
		{
			for (byte y = 0; y < areaSize; y++)
			{
				if (availableBlockMap[x, y] == 0)
				{
					short blockId = ByteCoordinate.CoordinateToIndex(new ByteCoordinate(x, y), areaSize);
					availableBlockMap[x, y] = 1;
					if (InNormalBlockRange(blockId, staticBlockList, areaSize))
					{
						normalBlockIdList.Add(blockId);
					}
					else
					{
						wildBlockIdList.Add(blockId);
					}
				}
			}
		}
		normalTemplateIdList.Clear();
		RandomUtils.GenerateRandomWeightCellList(random, areaConfigData.NormalBlockCore, normalBlockIdList.Count, ref normalTemplateIdList);
		for (int j = 0; j < normalBlockIdList.Count; j++)
		{
			short blockId2 = normalBlockIdList[j];
			areaBlocks[blockId2] = new MapBlockData(areaId, blockId2, normalTemplateIdList[j][0]);
		}
		wildTemplateIdList.Clear();
		RandomUtils.GenerateRandomWeightCellList(random, areaConfigData.WildBlockCore, wildBlockIdList.Count, ref wildTemplateIdList);
		for (int k = 0; k < wildBlockIdList.Count; k++)
		{
			short blockId3 = wildBlockIdList[k];
			areaBlocks[blockId3] = new MapBlockData(areaId, blockId3, wildTemplateIdList[k][0]);
		}
		int l = 0;
		for (int len = areaBlocks.Length; l < len; l++)
		{
			MapBlockData block = areaBlocks[l];
			if (block.TemplateId != 124)
			{
				continue;
			}
			int maxSteps = 1;
			ByteCoordinate blockPos = ByteCoordinate.IndexToCoordinate(block.BlockId, areaSize);
			int blockSize = 1;
			bool banAbyss = false;
			for (byte x2 = (byte)Math.Max(blockPos.X - maxSteps, 0); x2 < Math.Min(blockPos.X + blockSize + maxSteps, areaSize); x2++)
			{
				for (byte y2 = (byte)Math.Max(blockPos.Y - maxSteps, 0); y2 < Math.Min(blockPos.Y + blockSize + maxSteps, areaSize); y2++)
				{
					MapBlockData neighborBlock = areaBlocks[ByteCoordinate.CoordinateToIndex(new ByteCoordinate(x2, y2), areaSize)];
					if (neighborBlock.BlockId != block.BlockId && (neighborBlock.TemplateId == 124 || neighborBlock.TemplateId == 126))
					{
						banAbyss = true;
						break;
					}
				}
				if (banAbyss)
				{
					break;
				}
			}
			if (banAbyss)
			{
				areaBlocks[l] = new MapBlockData(block.AreaId, block.BlockId, MapBlock.Instance.First((MapBlockItem b) => b.Type == EMapBlockType.Normal && b.Size == 1 && b.TemplateId != 124).TemplateId);
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(staticBlockList);
		ObjectPool<List<short>>.Instance.Return(normalBlockIdList);
		ObjectPool<List<short[]>>.Instance.Return(normalTemplateIdList);
		ObjectPool<List<short>>.Instance.Return(wildBlockIdList);
		ObjectPool<List<short[]>>.Instance.Return(wildTemplateIdList);
	}

	private bool InNormalBlockRange(short blockId, List<MapBlockData> staticBlocks, byte mapSize)
	{
		ByteCoordinate blockPos = ByteCoordinate.IndexToCoordinate(blockId, mapSize);
		for (int i = 0; i < staticBlocks.Count; i++)
		{
			MapBlockData staticBlock = staticBlocks[i];
			byte range = staticBlock.GetConfig().Range;
			ByteCoordinate staticBlockPos = ByteCoordinate.IndexToCoordinate(staticBlock.BlockId, mapSize);
			int distance = MathUtils.GetManhattanDistance(staticBlockPos.X - range - GlobalConfig.Instance.MapNormalBlockRange, staticBlockPos.Y - range - GlobalConfig.Instance.MapNormalBlockRange, blockPos.X, blockPos.Y, staticBlock.GetConfig().Size + (range + GlobalConfig.Instance.MapNormalBlockRange) * 2);
			if (distance <= 0)
			{
				return true;
			}
		}
		return false;
	}

	private ByteCoordinate[] GetSniffRectList(ByteCoordinate byteCoordinate, int range, byte mapSize)
	{
		List<ByteCoordinate> list = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		list.Clear();
		byte xMin = (byte)Math.Max(byteCoordinate.X - range, 0);
		byte yMin = (byte)Math.Max(byteCoordinate.Y - range, 0);
		byte xMax = (byte)Math.Min(byteCoordinate.X + range, mapSize - 1);
		byte yMax = (byte)Math.Min(byteCoordinate.Y + range, mapSize - 1);
		for (byte x = xMin; x < xMax; x++)
		{
			list.Add(new ByteCoordinate(x, yMin));
			list.Add(new ByteCoordinate(x, yMax));
		}
		for (byte y = (byte)(yMin + 1); y < yMax; y++)
		{
			list.Add(new ByteCoordinate(xMin, y));
			list.Add(new ByteCoordinate(xMax, y));
		}
		ByteCoordinate[] result = list.ToArray();
		ObjectPool<List<ByteCoordinate>>.Instance.Return(list);
		return result;
	}

	private void FixSeriesBlocks(MapAreaItem areaConfigData, byte mapSize, MapBlockData[] areaBlocks, Dictionary<int, List<short>> blockTypeDict, IRandomSource random)
	{
		if (areaConfigData.SeriesBlockCore == null)
		{
			return;
		}
		foreach (short[] array in areaConfigData.SeriesBlockCore)
		{
			int blockSubType = array[0];
			List<MapBlockData> blocks = areaBlocks.FindAll((MapBlockData mapBlockData) => mapBlockData.CanChangeBlockType() && mapBlockData.BlockSubType == (EMapBlockSubType)blockSubType);
			int seriesGroupCount = array[1];
			int seriesBlockCount = random.Next(array[2], array[3]);
			for (int i = 0; i < seriesGroupCount; i++)
			{
				MapBlockData block = blocks.GetRandom(random);
				if (block == null)
				{
					break;
				}
				BlockInfect(block, seriesBlockCount);
				blocks.Remove(block);
				seriesBlockCount = random.Next(array[2], array[3]) - 1;
			}
		}
		void BlockInfect(MapBlockData mapBlockData, int infectCount)
		{
			int blockSubType2 = (int)mapBlockData.BlockSubType;
			List<ByteCoordinate> canInfectCore = ObjectPool<List<ByteCoordinate>>.Instance.Get();
			canInfectCore.Clear();
			int range = 1;
			while (canInfectCore.Count < infectCount)
			{
				canInfectCore.AddRange(GetSniffRectList(ByteCoordinate.IndexToCoordinate(mapBlockData.BlockId, mapSize), range++, mapSize));
				canInfectCore.RemoveAll(delegate(ByteCoordinate location)
				{
					short num = ByteCoordinate.CoordinateToIndex(location, mapSize);
					return !areaBlocks.CheckIndex(num) || !areaBlocks[num].CanChangeBlockType();
				});
			}
			for (int i2 = 0; i2 < infectCount; i2++)
			{
				int blockIndex = ByteCoordinate.CoordinateToIndex(canInfectCore[i2], mapSize);
				if (blockTypeDict.TryGetValue(blockSubType2, out var presetIdList))
				{
					areaBlocks[blockIndex].ChangeTemplateId(presetIdList.GetRandom(random));
				}
			}
			ObjectPool<List<ByteCoordinate>>.Instance.Return(canInfectCore);
		}
	}

	private void FixEncircleBlocks(MapAreaItem areaConfigData, byte mapSize, MapBlockData[] areaBlocks, Dictionary<int, List<short>> blockTypeDict, IRandomSource random)
	{
		if (areaConfigData.EncircleBlockCore == null)
		{
			return;
		}
		List<ByteCoordinate> centerPosList = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		List<ByteCoordinate> edgePosList = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		List<MapBlockData> circleBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		for (int index = 0; index < areaConfigData.EncircleBlockCore.Count; index++)
		{
			short[] encircleData = areaConfigData.EncircleBlockCore[index];
			if (!blockTypeDict.TryGetValue(encircleData[0], out var targetTypeIdList))
			{
				continue;
			}
			targetTypeIdList.RemoveAll((short templateId) => MapBlock.Instance[templateId].Size != 1);
			if (targetTypeIdList.Count == 0)
			{
				continue;
			}
			short centerTemplateId = encircleData[1];
			byte[,] circleMap = GetAreaShape(random, (byte)(encircleData[4] * 2 + 1), (byte)encircleData[3], ensureEdge: true);
			ByteCoordinate circleCenter = ((centerTemplateId == -1) ? new ByteCoordinate((byte)random.Next(mapSize / 4, mapSize * 3 / 4), (byte)random.Next(mapSize / 4, mapSize * 3 / 4)) : ByteCoordinate.IndexToCoordinate(areaBlocks.FindAll((MapBlockData block) => block.TemplateId == centerTemplateId).GetRandom(random).BlockId, mapSize));
			centerPosList.Clear();
			edgePosList.Clear();
			circleBlocks.Clear();
			for (byte x = 0; x < circleMap.GetLength(0); x++)
			{
				for (byte y = 0; y < circleMap.GetLength(1); y++)
				{
					byte data = circleMap[x, y];
					ByteCoordinate pos = new ByteCoordinate(x, y);
					switch (data)
					{
					case 1:
						centerPosList.Add(pos);
						break;
					case 2:
						edgePosList.Add(pos);
						break;
					}
				}
			}
			if (edgePosList.Count > 0)
			{
				int[] offset = new int[2];
				int[] pos2 = new int[2];
				for (int i = 0; i < edgePosList.Count; i++)
				{
					ByteCoordinate edgePos = edgePosList[i];
					offset[0] = edgePos.X - circleCenter.X;
					offset[1] = edgePos.Y - circleCenter.Y;
					pos2[0] = circleCenter.X + offset[0];
					pos2[1] = circleCenter.Y + offset[1];
					if (pos2[0] >= 0 && pos2[0] < mapSize && pos2[1] >= 0 && pos2[1] < mapSize)
					{
						ByteCoordinate realPosition = new ByteCoordinate((byte)pos2[0], (byte)pos2[1]);
						short blockIndex = ByteCoordinate.CoordinateToIndex(realPosition, mapSize);
						MapBlockData blockData = null;
						if (areaBlocks.CheckIndex(blockIndex))
						{
							blockData = areaBlocks[blockIndex];
						}
						if (blockData != null && blockData.CanChangeBlockType())
						{
							circleBlocks.Add(blockData);
						}
					}
				}
			}
			else
			{
				Logger.Warn($"{areaConfigData.Name}:encircleType {encircleData[0]} has no edgePosList");
			}
			if (circleBlocks.Count > 0)
			{
				for (int i2 = 0; i2 < encircleData[2]; i2++)
				{
					if (circleBlocks.Count <= 0)
					{
						break;
					}
					circleBlocks.RemoveAt(random.Next(circleBlocks.Count));
				}
				circleBlocks.ForEach(delegate(MapBlockData block)
				{
					block.ChangeTemplateId(targetTypeIdList.GetRandom(random));
				});
			}
			else
			{
				Logger.Warn($"Error:areaId {areaConfigData.TemplateId} failed to set encircle data of type {encircleData[0]} circle center is {circleCenter}");
			}
		}
		List<List<ByteCoordinate>> areaIslands = ObjectPool<List<List<ByteCoordinate>>>.Instance.Get();
		List<ByteCoordinate> notLinkedPosList = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		areaIslands.Clear();
		notLinkedPosList.Clear();
		for (short blockId = 0; blockId < areaBlocks.Length; blockId++)
		{
			if (areaBlocks[blockId].IsPassable())
			{
				notLinkedPosList.Add(ByteCoordinate.IndexToCoordinate(blockId, mapSize));
			}
		}
		while (notLinkedPosList.Count > 0)
		{
			List<ByteCoordinate> island = ObjectPool<List<ByteCoordinate>>.Instance.Get();
			island.Clear();
			areaIslands.Add(island);
			SpreadIsland(notLinkedPosList[0], island, mapSize, CanPass, new byte[mapSize, mapSize]);
			notLinkedPosList.RemoveAll((ByteCoordinate item) => island.Contains(item));
		}
		if (areaIslands.Count > 1)
		{
			List<short> baseBlockRandomPool = ObjectPool<List<short>>.Instance.Get();
			baseBlockRandomPool.Clear();
			for (int i3 = 0; i3 < areaConfigData.WildBlockCore.Count; i3++)
			{
				short blockTemplateId = areaConfigData.WildBlockCore[i3][0];
				if (blockTemplateId != 124)
				{
					baseBlockRandomPool.Add(blockTemplateId);
				}
			}
			areaIslands.Sort((List<ByteCoordinate> left, List<ByteCoordinate> right) => (left.Count != right.Count) ? (right.Count - left.Count) : (left.GetHashCode() - right.GetHashCode()));
			List<ByteCoordinate> mainIsland = areaIslands[0];
			for (int i4 = 1; i4 < areaIslands.Count; i4++)
			{
				List<ByteCoordinate> island2 = areaIslands[i4];
				ByteCoordinate mainIslandBlockPos = mainIsland[random.Next(mainIsland.Count)];
				MapBlockData linkBlock = null;
				int minDist = int.MaxValue;
				foreach (ByteCoordinate pos3 in island2)
				{
					int distance = pos3.GetManhattanDistance(mainIslandBlockPos);
					if (distance < minDist)
					{
						linkBlock = areaBlocks[ByteCoordinate.CoordinateToIndex(pos3, mapSize)];
						minDist = distance;
					}
				}
				ByteCoordinate linkBlockPos = ByteCoordinate.IndexToCoordinate(linkBlock.BlockId, mapSize);
				MapBlockData mainIslandLinkBlock = null;
				minDist = int.MaxValue;
				foreach (ByteCoordinate pos4 in mainIsland)
				{
					int distance2 = pos4.GetManhattanDistance(linkBlockPos);
					if (distance2 < minDist)
					{
						mainIslandLinkBlock = areaBlocks[ByteCoordinate.CoordinateToIndex(pos4, mapSize)];
						minDist = distance2;
					}
				}
				ByteCoordinate mainIslandLinkBlockPos = ByteCoordinate.IndexToCoordinate(mainIslandLinkBlock.BlockId, mapSize);
				int xAddValue = Math.Sign(mainIslandLinkBlockPos.X - linkBlockPos.X);
				int yAddValue = Math.Sign(mainIslandLinkBlockPos.Y - linkBlockPos.Y);
				while (linkBlockPos != mainIslandLinkBlockPos)
				{
					if (linkBlockPos.X != mainIslandLinkBlockPos.X && (linkBlockPos.Y == mainIslandLinkBlockPos.Y || random.CheckPercentProb(50)))
					{
						linkBlockPos.X = (byte)(linkBlockPos.X + xAddValue);
					}
					else
					{
						linkBlockPos.Y = (byte)(linkBlockPos.Y + yAddValue);
					}
					short blockIndex2 = ByteCoordinate.CoordinateToIndex(linkBlockPos, mapSize);
					if (!areaBlocks[blockIndex2].IsPassable())
					{
						areaBlocks[blockIndex2].ChangeTemplateId(baseBlockRandomPool.GetRandom(random), checkCanChange: false);
					}
				}
				if (mainIslandLinkBlock.TemplateId == 124)
				{
					mainIslandLinkBlock.ChangeTemplateId(baseBlockRandomPool.GetRandom(random), checkCanChange: false);
				}
			}
			ObjectPool<List<short>>.Instance.Return(baseBlockRandomPool);
		}
		ObjectPool<List<ByteCoordinate>>.Instance.Return(centerPosList);
		ObjectPool<List<ByteCoordinate>>.Instance.Return(edgePosList);
		ObjectPool<List<MapBlockData>>.Instance.Return(circleBlocks);
		areaIslands.ForEach(delegate(List<ByteCoordinate> item)
		{
			ObjectPool<List<ByteCoordinate>>.Instance.Return(item);
		});
		ObjectPool<List<List<ByteCoordinate>>>.Instance.Return(areaIslands);
		ObjectPool<List<ByteCoordinate>>.Instance.Return(notLinkedPosList);
		bool CanPass(ByteCoordinate byteCoordinate)
		{
			return areaBlocks[ByteCoordinate.CoordinateToIndex(byteCoordinate, mapSize)].IsPassable();
		}
	}

	private void SpreadIsland(ByteCoordinate pos, List<ByteCoordinate> island, byte mapSize, Predicate<ByteCoordinate> canPass, byte[,] reachMap)
	{
		if (reachMap[pos.X, pos.Y] == 1)
		{
			return;
		}
		reachMap[pos.X, pos.Y] = 1;
		if (canPass(pos))
		{
			island.Add(pos);
			if (pos.X > 0)
			{
				SpreadIsland(new ByteCoordinate((byte)(pos.X - 1), pos.Y), island, mapSize, canPass, reachMap);
			}
			if (pos.X < mapSize - 1)
			{
				SpreadIsland(new ByteCoordinate((byte)(pos.X + 1), pos.Y), island, mapSize, canPass, reachMap);
			}
			if (pos.Y > 0)
			{
				SpreadIsland(new ByteCoordinate(pos.X, (byte)(pos.Y - 1)), island, mapSize, canPass, reachMap);
			}
			if (pos.Y < mapSize - 1)
			{
				SpreadIsland(new ByteCoordinate(pos.X, (byte)(pos.Y + 1)), island, mapSize, canPass, reachMap);
			}
		}
	}

	private void InitAreaTravelRoute(DataContext context)
	{
		ClearTravelRouteDict(context);
		for (short areaId = 0; areaId < 135; areaId++)
		{
			MapAreaData area = _areas[areaId];
			MapAreaItem areaConfig = area.GetConfig();
			AreaTravelRoute[] routeList = areaConfig.NeighborAreas;
			AreaTravelRoute[] array = routeList;
			for (int i = 0; i < array.Length; i++)
			{
				AreaTravelRoute routeConfig = array[i];
				short neighborAreaId = GetAreaIdByAreaTemplateId(routeConfig.DestAreaId);
				TravelRouteKey key = new TravelRouteKey(areaId, neighborAreaId);
				TravelRoute route = new TravelRoute();
				area.NeighborAreas.Add(neighborAreaId);
				_areas[neighborAreaId].NeighborAreas.Add(areaId);
				route.PosList.AddRange(routeConfig.MapPosList);
				route.AreaList.Add(areaId);
				route.AreaList.Add(neighborAreaId);
				route.CostList.Add(routeConfig.CostDays);
				if (areaId > neighborAreaId)
				{
					key.Reverse();
					route.PosList.Reverse();
					route.AreaList.Reverse();
				}
				AddElement_TravelRouteDict(key, route, context);
			}
		}
		AStarMapForTravel aStarMap = new AStarMapForTravel();
		List<short> path = ObjectPool<List<short>>.Instance.Get();
		aStarMap.InitMap(GetTravelCost);
		for (short fromArea = 0; fromArea < 134; fromArea++)
		{
			for (short toArea = (short)(fromArea + 1); toArea < 135; toArea++)
			{
				TravelRouteKey key2 = new TravelRouteKey(fromArea, toArea);
				if (!_travelRouteDict.ContainsKey(key2))
				{
					TravelRoute route2 = new TravelRoute();
					path.Clear();
					aStarMap.FindWay(fromArea, toArea, ref path);
					route2.AreaList.AddRange(path);
					for (int j = 0; j < path.Count - 1; j++)
					{
						short subRouteFromArea = path[j];
						short subRouteToArea = path[j + 1];
						bool reverse = subRouteFromArea > subRouteToArea;
						TravelRouteKey subRouteKey = new TravelRouteKey(subRouteFromArea, subRouteToArea);
						if (reverse)
						{
							subRouteKey.Reverse();
						}
						TravelRoute subRoute = _travelRouteDict[subRouteKey];
						if (!reverse)
						{
							route2.PosList.AddRange(subRoute.PosList);
							for (int k = 0; k < subRoute.CostList.Count; k++)
							{
								route2.CostList.Add(subRoute.CostList[k]);
							}
						}
						else
						{
							for (int j2 = subRoute.PosList.Count - 1; j2 >= 0; j2--)
							{
								route2.PosList.Add(subRoute.PosList[j2]);
							}
							for (int j3 = subRoute.CostList.Count - 1; j3 >= 0; j3--)
							{
								route2.CostList.Add(subRoute.CostList[j3]);
							}
						}
						if (j < path.Count - 2)
						{
							sbyte[] toAreaPos = _areas[subRouteToArea].GetConfig().WorldMapPos;
							route2.PosList.Add(new ByteCoordinate((byte)toAreaPos[0], (byte)toAreaPos[1]));
						}
					}
					AddElement_TravelRouteDict(key2, route2, context);
				}
			}
		}
		List<short> areaIdInBornState = ObjectPool<List<short>>.Instance.Get();
		short firstNormalAreaId = (short)((DomainManager.World.GetTaiwuVillageStateTemplateId() - 1) * 3);
		short firstBrokenAreaId = (short)(45 + (DomainManager.World.GetTaiwuVillageStateTemplateId() - 1) * 6);
		areaIdInBornState.Clear();
		for (int l = 0; l < 3; l++)
		{
			areaIdInBornState.Add((short)(firstNormalAreaId + l));
		}
		for (int m = 0; m < 6; m++)
		{
			areaIdInBornState.Add((short)(firstBrokenAreaId + m));
		}
		aStarMap.InitMap(GetTravelCostInState);
		for (int fromIndex = 0; fromIndex < areaIdInBornState.Count - 1; fromIndex++)
		{
			short fromArea2 = areaIdInBornState[fromIndex];
			for (int toIndex = fromIndex + 1; toIndex < areaIdInBornState.Count; toIndex++)
			{
				short toArea2 = areaIdInBornState[toIndex];
				TravelRouteKey key3 = new TravelRouteKey(fromArea2, toArea2);
				if (_bornStateTravelRouteDict.ContainsKey(key3))
				{
					continue;
				}
				TravelRoute route3 = new TravelRoute();
				path.Clear();
				aStarMap.FindWay(fromArea2, toArea2, ref path);
				route3.AreaList.AddRange(path);
				for (int n = 0; n < path.Count - 1; n++)
				{
					short subRouteFromArea2 = path[n];
					short subRouteToArea2 = path[n + 1];
					bool reverse2 = subRouteFromArea2 > subRouteToArea2;
					TravelRouteKey subRouteKey2 = new TravelRouteKey(subRouteFromArea2, subRouteToArea2);
					if (reverse2)
					{
						subRouteKey2.Reverse();
					}
					TravelRoute subRoute2 = _travelRouteDict[subRouteKey2];
					if (!reverse2)
					{
						route3.PosList.AddRange(subRoute2.PosList);
						for (int num = 0; num < subRoute2.CostList.Count; num++)
						{
							route3.CostList.Add(subRoute2.CostList[num]);
						}
					}
					else
					{
						for (int j4 = subRoute2.PosList.Count - 1; j4 >= 0; j4--)
						{
							route3.PosList.Add(subRoute2.PosList[j4]);
						}
						for (int j5 = subRoute2.CostList.Count - 1; j5 >= 0; j5--)
						{
							route3.CostList.Add(subRoute2.CostList[j5]);
						}
					}
					if (n < path.Count - 2)
					{
						sbyte[] toAreaPos2 = _areas[subRouteToArea2].GetConfig().WorldMapPos;
						route3.PosList.Add(new ByteCoordinate((byte)toAreaPos2[0], (byte)toAreaPos2[1]));
					}
				}
				AddElement_BornStateTravelRouteDict(key3, route3, context);
			}
		}
		for (short areaId2 = 0; areaId2 < 134; areaId2++)
		{
			TravelRouteKey key4 = new TravelRouteKey(areaId2, 135);
			TravelRoute route4 = new TravelRoute();
			route4.AreaList.Add(areaId2);
			route4.AreaList.Add(135);
			route4.CostList.Add(10);
			AddElement_TravelRouteDict(key4, route4, context);
		}
		ObjectPool<List<short>>.Instance.Return(areaIdInBornState);
		ObjectPool<List<short>>.Instance.Return(path);
		List<short> allAreaList = new List<short>();
		for (short areaId3 = 0; areaId3 < 45; areaId3++)
		{
			allAreaList.Add(areaId3);
		}
		short areaId4;
		for (areaId4 = 0; areaId4 < 45; areaId4++)
		{
			GameData.Utilities.ShortList otherAreaList = GameData.Utilities.ShortList.Create();
			otherAreaList.Items.AddRange(allAreaList);
			otherAreaList.Items.Remove(areaId4);
			otherAreaList.Items.Sort(delegate(short num2, short num3)
			{
				TravelRouteKey key5 = new TravelRouteKey(areaId4, num2);
				TravelRouteKey key6 = new TravelRouteKey(areaId4, num3);
				if (areaId4 > num2)
				{
					key5.Reverse();
				}
				if (areaId4 > num3)
				{
					key6.Reverse();
				}
				return _travelRouteDict[key5].GetTotalTimeCost().CompareTo(_travelRouteDict[key6].GetTotalTimeCost());
			});
			AddElement_RegularAreaNearList(areaId4, otherAreaList, context);
		}
		short GetTravelCost(short num2, short num3)
		{
			bool reverse3 = num2 > num3;
			TravelRouteKey key5 = new TravelRouteKey(num2, num3);
			if (reverse3)
			{
				key5.Reverse();
			}
			return _travelRouteDict[key5].GetTotalTimeCost();
		}
		short GetTravelCostInState(short num2, short num3)
		{
			if (!areaIdInBornState.Contains(num2) || !areaIdInBornState.Contains(num3))
			{
				return 10000;
			}
			bool reverse3 = num2 > num3;
			TravelRouteKey key5 = new TravelRouteKey(num2, num3);
			if (reverse3)
			{
				key5.Reverse();
			}
			return _travelRouteDict[key5].GetTotalTimeCost();
		}
	}

	public override void UnpackCrossArchiveGameData(DataContext context, CrossArchiveGameData crossArchiveGameData)
	{
		DomainManager.Map.SetCrossArchiveLockMoveTime(value: true, context);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.TaiwuCrossArchiveSpecialEffect);
		Location villageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		List<MapBlockData> nearBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetLocationByDistance(villageLocation, 15, 15, ref nearBlocks);
		if (nearBlocks.Count > 0)
		{
			MapBlockData mapBlockData = nearBlocks.GetRandom(context.Random);
			DomainManager.Map.SetTeleportMove(teleport: true);
			DomainManager.Map.Move(context, mapBlockData.BlockId, notCostTime: true);
			DomainManager.Map.SetTeleportMove(teleport: false);
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(nearBlocks);
		List<MapBlockData> exceptBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		GetInSightBlocks(exceptBlocks);
		HideAllBlocks(context, DomainManager.Taiwu.GetTaiwuVillageLocation().AreaId, exceptBlocks);
		ObjectPool<List<MapBlockData>>.Instance.Return(exceptBlocks);
		MapBlockData villageBlock = DomainManager.Map.GetBlock(villageLocation);
		villageBlock.SetVisible(visible: true, context);
	}

	[DomainMethod]
	public void RetrieveDreamBackLocation(DataContext context, Location location)
	{
		if (DomainManager.TaiwuEvent.GetGlobalEventArgumentBox().GetBool("ConchShip_PresetKey_FuyuHiltGuiding") || DomainManager.Taiwu.GetTaiwu().GetLocation() != location)
		{
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.SetEventLockInputState, arg1: false);
			return;
		}
		foreach (EDreamBackLocationType type in RemoveDreamBackLocation(context, location))
		{
			TaiwuEventDomain taiwuEvent = DomainManager.TaiwuEvent;
			if (1 == 0)
			{
			}
			sbyte arg = type switch
			{
				EDreamBackLocationType.Inventory => 1, 
				EDreamBackLocationType.LifeSkill => 3, 
				EDreamBackLocationType.CombatSkill => 2, 
				_ => -1, 
			};
			if (1 == 0)
			{
			}
			taiwuEvent.OnEvent_TaiwuCrossArchiveFindMemory(arg);
		}
	}

	public void CreateDreamBackLocation(DataContext context, Location location, EDreamBackLocationType locationType)
	{
		List<DreamBackLocationData> dreamBackLocationData = DomainManager.Extra.GetDreamBackLocationData();
		DreamBackLocationData data = DreamBackLocationData.Create(location, locationType);
		dreamBackLocationData.Add(data);
		DomainManager.Extra.SetDreamBackLocationData(dreamBackLocationData, context);
	}

	public IEnumerable<EDreamBackLocationType> RemoveDreamBackLocation(DataContext context, Location location)
	{
		List<DreamBackLocationData> dreamBackLocationData = DomainManager.Extra.GetDreamBackLocationData();
		bool anyRemoved = false;
		for (int i = dreamBackLocationData.Count - 1; i >= 0; i--)
		{
			DreamBackLocationData locationData = dreamBackLocationData[i];
			if (!(locationData.Location != location))
			{
				CollectionUtils.SwapAndRemove(dreamBackLocationData, i);
				anyRemoved = true;
				yield return locationData.Type;
			}
		}
		if (anyRemoved)
		{
			DomainManager.Extra.SetDreamBackLocationData(dreamBackLocationData, context);
		}
	}

	[DomainMethod]
	public void GmCmd_SetLockTime(bool isLock)
	{
		LockTime = isLock;
	}

	[DomainMethod]
	public void GmCmd_SetTeleportMove(bool teleportOn)
	{
		_teleportMove = teleportOn;
	}

	[DomainMethod]
	public void GmCmd_ShowAllMapBlock(DataContext context)
	{
		for (short areaId = 0; areaId < 141; areaId++)
		{
			Span<MapBlockData> blocks = GetAreaBlocks(areaId);
			for (int i = 0; i < blocks.Length; i++)
			{
				MapBlockData block = blocks[i];
				if (block.TemplateId != 126)
				{
					block.SetVisible(visible: true, context);
				}
			}
			_areas[areaId].Discovered = true;
			SetElement_Areas(areaId, _areas[areaId], context);
		}
		DomainManager.Merchant.RefreshCaravanInTaiwuState(context);
	}

	[DomainMethod]
	public void GmCmd_HideAllMapBlock(DataContext context)
	{
		DomainManager.Map.HideAllBlocks(context);
		DomainManager.Merchant.RefreshCaravanInTaiwuState(context);
	}

	[DomainMethod]
	public void GmCmd_UnlockAllStation(DataContext context)
	{
		for (short areaId = 0; areaId < 135; areaId++)
		{
			if (!_areas[areaId].StationUnlocked)
			{
				MapBlockData stationBlock = GetBlock(areaId, _areas[areaId].StationBlockId);
				UnlockStation(context, areaId, costAuthority: false);
				if (!stationBlock.Visible)
				{
					stationBlock.SetVisible(visible: true, context);
				}
			}
		}
	}

	[DomainMethod]
	public void GmCmd_ChangeSpiritualDebt(DataContext context, short areaId, int spiritualDebt)
	{
		DomainManager.Extra.SetAreaSpiritualDebt(context, areaId, spiritualDebt);
	}

	[DomainMethod]
	public void GmCmd_ChangeAllSpiritualDebt(DataContext context, int spiritualDebt)
	{
		for (short i = 0; i < DomainManager.Map._areas.Length; i++)
		{
			DomainManager.Extra.SetAreaSpiritualDebt(context, i, spiritualDebt);
		}
	}

	[DomainMethod]
	public void GmCmd_SetMapBlockData(DataContext context, MapBlockData mapBlockData)
	{
		SetBlockData(context, mapBlockData);
	}

	[DomainMethod]
	public void GmCmd_CreateFixedCharacterAtCurrentBlock(DataContext context, short templateId)
	{
		GameData.Domains.Character.Character taiwuCharacter = DomainManager.Taiwu.GetTaiwu();
		if (Config.Character.Instance[templateId].CreatingType == 0 && DomainManager.Character.TryGetFixedCharacterByTemplateId(templateId, out var character))
		{
			EventHelper.MoveFixedCharacter(character, taiwuCharacter.GetLocation());
			return;
		}
		character = DomainManager.Character.CreateFixedCharacter(context, templateId);
		if (character != null && taiwuCharacter != null)
		{
			Location location = taiwuCharacter.GetLocation();
			DomainManager.Character.CompleteCreatingCharacter(character.GetId());
			EventHelper.MoveFixedCharacter(character, location);
		}
	}

	[DomainMethod]
	public void GmCmd_AddAnimal(DataContext context, short templateId)
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		DomainManager.Extra.CreateAnimalByCharacterTemplateId(context, templateId, taiwuLocation);
	}

	[DomainMethod]
	public void GmCmd_AddRandomEnemyOnMap(DataContext context, short templateId)
	{
		byte creatingType = Config.Character.Instance[templateId].CreatingType;
		bool condition = (uint)(creatingType - 2) <= 1u;
		Tester.Assert(condition);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		MapBlockData block = DomainManager.Map.GetBlock(taiwu.GetLocation());
		block.AddTemplateEnemy(MapTemplateEnemyInfo.CreateDefault(templateId, block.BlockId, -1));
		DomainManager.Map.SetBlockData(context, block);
	}

	[DomainMethod]
	public void GmCmd_TurnMapBlockIntoAshes(DataContext context)
	{
		short areaId = DomainManager.Taiwu.GetTaiwu().GetLocation().AreaId;
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(areaId);
		for (int i = 0; i < areaBlocks.Length; i++)
		{
			MapBlockData block = areaBlocks[i];
			if (!block.IsCityTown() && (block.IsNonDeveloped() || block.GetConfig().Type == EMapBlockType.Developed))
			{
				DomainManager.Map.ChangeBlockTemplate(context, block, (short)(context.Random.NextBool() ? 118 : 124));
			}
		}
	}

	[DomainMethod]
	public void GMCmd_ThrowBackend()
	{
		throw new Exception("a backend test exception");
	}

	[DomainMethod]
	public bool GmCmd_TriggerTravelingEvent(DataContext context, short templateId)
	{
		TravelingEventItem configData = TravelingEvent.Instance[templateId];
		if (string.IsNullOrEmpty(configData.Event))
		{
			return false;
		}
		TravelingEventCollection travelingEventCollection = DomainManager.Extra.GetTravelingEventCollection();
		short currAreaId = DomainManager.Taiwu.GetTaiwu().GetValidLocation().AreaId;
		int offset = AddTravelingEvent(context, templateId, currAreaId);
		if (offset < 0)
		{
			return false;
		}
		GameData.Domains.TaiwuEvent.TaiwuEvent taiwuEvent = DomainManager.TaiwuEvent.GetEvent(configData.Event);
		if (taiwuEvent != null)
		{
			GameData.Domains.TaiwuEvent.TaiwuEvent taiwuEvent2 = taiwuEvent;
			if (taiwuEvent2.ArgBox == null)
			{
				EventArgBox eventArgBox = (taiwuEvent2.ArgBox = DomainManager.TaiwuEvent.GetEventArgBox());
			}
			travelingEventCollection.FillEventArgBox(offset, taiwuEvent.ArgBox);
			if (!taiwuEvent.EventConfig.CheckCondition())
			{
				int size = travelingEventCollection.GetRecordSize(offset);
				travelingEventCollection.Remove(offset, size);
				Logger.Warn($"Traveling event {templateId} - {configData.Name} is triggering {taiwuEvent.EventGuid} when OnCheckEventCondition return false.");
				return false;
			}
			DomainManager.TaiwuEvent.AddTriggeredEvent(taiwuEvent);
			DomainManager.TaiwuEvent.TravelingEventCheckComplete();
			DomainManager.Map.SetOnHandlingTravelingEventBlock(value: true, context);
		}
		else
		{
			Logger.Warn($"Monthly Event {templateId} - {configData.Name} ({configData.Event}) not found.");
		}
		return false;
	}

	[DomainMethod]
	public int GmCmd_GetTreasuryValueByTaiwuLocation()
	{
		Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!location.IsValid())
		{
			return 0;
		}
		return DomainManager.Organization.GetSettlementByLocation(location)?.Treasuries.CurrentTotalValue ?? 0;
	}

	private void InvokeGuidingChapterByMove(DataContext context, MapBlockData destBlock)
	{
		Location location = destBlock.GetLocation();
		DomainManager.Global.InvokeGuidingTrigger(context, 175);
		if (IsCricketInLocation(location))
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 176);
		}
		SortedList<ItemKeyAndDate, int> items = destBlock.Items;
		if (items != null && items.Count > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 177);
		}
		if (AnyVisiblePickup(location))
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 201);
		}
		if (DomainManager.Merchant.IsCaravanAtBlock(location))
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 199);
		}
		if (DomainManager.Adventure.QueryAdventureInLocation(location) != null)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 228);
		}
		Settlement settlement = DomainManager.Organization.GetSettlementByLocation(destBlock.GetRootBlock().GetLocation());
		if (settlement != null)
		{
			InvokeGuidingChapterByMoveInSect(context, settlement);
		}
		InvokeGuidingChapterByMoveCheckCharacterSet(context, destBlock);
		InvokeGuidingChapterByMoveCheckTemplateEnemyList(context, destBlock);
	}

	private void InvokeGuidingChapterByMoveInSect(DataContext context, Settlement settlement)
	{
		DomainManager.Global.InvokeGuidingTrigger(context, 178);
		OrganizationItem config = settlement.OrganizationConfig;
		if (config == null)
		{
			return;
		}
		if (config.IsSect)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 179);
			sbyte templateId = settlement.OrganizationConfig.TemplateId;
			if (1 == 0)
			{
			}
			short? num = templateId switch
			{
				1 => 180, 
				2 => 181, 
				3 => 182, 
				4 => 183, 
				5 => 184, 
				6 => 185, 
				7 => 186, 
				8 => 187, 
				9 => 188, 
				10 => 189, 
				11 => 190, 
				12 => 191, 
				13 => 192, 
				14 => 193, 
				15 => 194, 
				_ => null, 
			};
			if (1 == 0)
			{
			}
			short? guidingChapterTrigger = num;
			if (guidingChapterTrigger.HasValue)
			{
				DomainManager.Global.InvokeGuidingTrigger(context, guidingChapterTrigger.Value);
			}
		}
		else if (config.TemplateId == 16)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 195);
		}
		else if (config.IsCivilian)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 200);
		}
	}

	private void InvokeGuidingChapterByMoveCheckCharacterSet(DataContext context, MapBlockData destBlock)
	{
		HashSet<int> characterSet = destBlock.CharacterSet;
		if (characterSet == null || characterSet.Count <= 0)
		{
			return;
		}
		bool anyDarkAsh = false;
		foreach (int charId in destBlock.CharacterSet)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			anyDarkAsh = character.HasDarkAsh;
			if (anyDarkAsh)
			{
				break;
			}
		}
		if (anyDarkAsh)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 196);
		}
	}

	private void InvokeGuidingChapterByMoveCheckTemplateEnemyList(DataContext context, MapBlockData destBlock)
	{
		List<MapTemplateEnemyInfo> templateEnemyList = destBlock.TemplateEnemyList;
		if (templateEnemyList == null || templateEnemyList.Count <= 0)
		{
			return;
		}
		foreach (MapTemplateEnemyInfo enemyInfo in destBlock.TemplateEnemyList)
		{
			CharacterItem config = Config.Character.Instance[enemyInfo.TemplateId];
			if (config.OrganizationInfo.OrgTemplateId == 19)
			{
				DomainManager.Global.InvokeGuidingTrigger(context, 197);
				continue;
			}
			sbyte orgTemplateId = config.OrganizationInfo.OrgTemplateId;
			if ((uint)(orgTemplateId - 17) <= 1u)
			{
				DomainManager.Global.InvokeGuidingTrigger(context, 198);
			}
		}
	}

	internal void BlockCharacterFix(DataContext context)
	{
		MapAreaData[] areas = _areas;
		foreach (MapAreaData area in areas)
		{
			Span<MapBlockData> areaBlocks = GetAreaBlocks(area.GetId());
			for (int j = 0; j < areaBlocks.Length; j++)
			{
				MapBlockData block = areaBlocks[j];
				int len = (block.CharacterSet?.Count ?? 0) + (block.FixedCharacterSet?.Count ?? 0);
				block.CharacterSet?.RemoveWhere((int id) => !DomainManager.Character.TryGetElement_Objects(id, out var element) || element.GetLocation() != block.GetLocation());
				block.FixedCharacterSet?.RemoveWhere((int id) => !DomainManager.Character.TryGetElement_Objects(id, out var element) || element.GetLocation() != block.GetLocation());
				if (len > (block.CharacterSet?.Count ?? 0) + (block.FixedCharacterSet?.Count ?? 0))
				{
					AdaptableLog.TagWarning("BlockFix", $"block {block.GetLocation()} in wrong state, fixing..");
					SetBlockData(context, block);
				}
			}
		}
	}

	public void SetMapPickupUsed(DataContext context, MapPickup pickup)
	{
		if (pickup == null)
		{
			throw new ArgumentNullException("pickup");
		}
		if (!DomainManager.Extra.TryGetElement_PickupDict(pickup.Location, out var pickupCollection))
		{
			throw new ArgumentException("SetPickupUsed: Trying to set a pickup not in pickup collection");
		}
		if (pickupCollection != null)
		{
			SetMapPickupUsedInternal(context, pickupCollection, pickup);
		}
	}

	private void SetMapPickupUsedInternal(DataContext context, MapPickupCollection pickupCollection, MapPickup pickup)
	{
		pickup.SetAsUsed();
		DomainManager.Extra.SetMapPickupCollection(context, pickup.Location, pickupCollection);
	}

	public IEnumerable<MapPickup> GetMapPickups(Location location)
	{
		if (!DomainManager.Extra.TryGetElement_PickupDict(location, out var pickupCollection))
		{
			return Enumerable.Empty<MapPickup>();
		}
		sbyte xiangshuProgress = DomainManager.World.GetXiangshuProgress();
		sbyte xiangshuLevel = GameData.Domains.World.SharedMethods.GetXiangshuLevel(xiangshuProgress);
		return pickupCollection.IterVisiblePickups(xiangshuLevel);
	}

	public bool AnyVisiblePickup(Location location)
	{
		return FindFirstVisibleMapPickupOnLocation(location) != null;
	}

	public MapPickup FindFirstVisibleMapPickupOnLocation(Location location)
	{
		List<MapPickup> pickups = GetMapPickups(location).ToList();
		pickups.Sort(MapPickupHelper.CompareVisiblePickups);
		if (pickups.Count == 0)
		{
			return null;
		}
		return pickups[0];
	}

	public MapPickup FindVisibleMapPickupOnLocation(Location location, int index)
	{
		List<MapPickup> pickups = GetMapPickups(location).ToList();
		pickups.Sort(MapPickupHelper.CompareVisiblePickups);
		if (pickups.Count <= index)
		{
			return null;
		}
		return pickups[index];
	}

	public void TriggerNormalMapPickup(DataContext context, MapPickup pickup)
	{
		if (pickup == null || !DomainManager.Extra.TryGetElement_PickupDict(pickup.Location, out var pickupCollection) || pickupCollection == null)
		{
			return;
		}
		if (pickup.IsEventType)
		{
			throw new ArgumentException("TriggerNormalMapPickup: Trying to trigger a pickup that is an event");
		}
		SetMapPickupUsedInternal(context, pickupCollection, pickup);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int invokeBonusRate = taiwu.WorkingCarrierExploreBonusRate;
		ItemKey[] equipment = taiwu.GetEquipment();
		foreach (ItemKey itemKey in equipment)
		{
			if (DomainManager.Item.TryGetBaseItem(itemKey) is IExploreBonusRateItem bonusRateItem)
			{
				invokeBonusRate += bonusRateItem.GetExploreBonusRate();
			}
		}
		bool bonusIsExtra = true;
		bool invokeBonus = context.Random.CheckPercentProb(invokeBonusRate);
		if (invokeBonus && pickup.Type == MapPickup.EMapPickupType.Item)
		{
			IItemConfig config = ItemConfigHelper.GetConfig(pickup.ItemType, pickup.ItemTemplateId);
			if (config.ItemSubType != 505)
			{
				bonusIsExtra = false;
				IItemConfig upgradeConfig = config.Upgrade();
				if (upgradeConfig == null)
				{
					invokeBonus = false;
				}
				else
				{
					pickup = new MapPickup(pickup)
					{
						ItemTemplateId = upgradeConfig.TemplateId
					};
				}
			}
		}
		bool normalSuccess = false;
		bool extraSuccess = false;
		if (ApplyPickups.TryGetValue(pickup.Type, out var handler))
		{
			normalSuccess = handler(context, pickup);
			if (invokeBonus && bonusIsExtra)
			{
				extraSuccess = handler(context, pickup);
			}
		}
		MapElementPickupDisplayData displayData = GetPickupDisplayData(pickup);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.PlayMapPickupEffect, displayData);
		if (invokeBonus && pickup.Template.ExtraBonusReplaceInstantNotification >= 0 && extraSuccess)
		{
			AddNotification(pickup, pickup.Template.ExtraBonusReplaceInstantNotification);
			return;
		}
		if (pickup.Template.InstantNotification >= 0 && normalSuccess)
		{
			AddNotification(pickup, pickup.Template.InstantNotification);
		}
		if (invokeBonus && pickup.Template.ExtraBonusAddInstantNotification >= 0 && extraSuccess)
		{
			AddNotification(pickup, pickup.Template.ExtraBonusAddInstantNotification);
		}
	}

	private void AddNotification(MapPickup pickup, short notificationId)
	{
		InstantNotificationCollection collection = DomainManager.World.GetInstantNotificationCollection();
		switch (notificationId)
		{
		case 179:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Resource);
			collection.AddMapPickupsResource(pickup.Location, pickup.ResourceType, pickup.ResourceCount);
			break;
		case 244:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Resource);
			collection.AddMapPickupsResourceUpdate(pickup.ResourceType, pickup.ResourceCount);
			break;
		case 180:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsFoodIngredients(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 181:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsMaterials(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 182:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsHerbal0(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 183:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsHerbal1(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 188:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsFruit(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 189:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsChickenDishes(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 190:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsMeatDishes(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 191:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsVegetarianDishes(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 192:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsSeafoodDishes(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 193:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsWine(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 194:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsTea(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 195:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsTool(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 196:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsAccessory(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 197:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsPoisonCream(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 198:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsHarrier(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 199:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsToken(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 200:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsNeedleBox(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 201:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsThorn(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 202:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsHiddenWeapon(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 203:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsFlute(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 204:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsGloves(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 205:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsFurGloves(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 206:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsPestle(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 207:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsSword(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 208:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsBlade(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 209:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsPolearm(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 210:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupQin(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 211:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsWhisk(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 212:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsWhip(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 213:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsCrest(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 214:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsShoes(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 215:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsArmor(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 216:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsArmGuard(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 217:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsCarDrop(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 184:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsPoisonCorrected(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 185:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsInjuryMedicineCorrected(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 186:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsAntidoteCorrected(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 187:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsGainMedicineCorrected(pickup.Location, pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 247:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsItemUpdate(pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 254:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.Item);
			collection.AddMapPickupsMedicineUpdate(pickup.ItemType, pickup.ItemTemplateId);
			break;
		case 218:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.ExpBonus);
			collection.AddMapPickupsExp(pickup.Location, pickup.ExpCount);
			break;
		case 245:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.ExpBonus);
			collection.AddMapPickupsExpUpdate(pickup.ExpCount);
			break;
		case 219:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.ReadEffect);
			collection.AddMapPickupsReading();
			break;
		case 248:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.ReadEffect);
			collection.AddMapPickupsReadingUpdate();
			break;
		case 220:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.LoopEffect);
			collection.AddMapPickupsQiArt();
			break;
		case 249:
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.LoopEffect);
			collection.AddMapPickupsQiArtUpdate();
			break;
		case 221:
		{
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.DebtBonus);
			sbyte stateTemplateId = GetStateTemplateIdByAreaId(pickup.Location.AreaId);
			collection.AddMapPickupsMorale(stateTemplateId);
			break;
		}
		case 246:
		{
			Tester.Assert(pickup.Type == MapPickup.EMapPickupType.DebtBonus);
			sbyte stateTemplateIdUpdate = GetStateTemplateIdByAreaId(pickup.Location.AreaId);
			collection.AddMapPickupsMoraleUpdate(stateTemplateIdUpdate);
			break;
		}
		case 222:
		case 223:
		case 224:
		case 225:
		case 226:
		case 227:
		case 228:
		case 229:
		case 230:
		case 231:
		case 232:
		case 233:
		case 234:
		case 235:
		case 236:
		case 237:
		case 238:
		case 239:
		case 240:
		case 241:
		case 242:
		case 243:
		case 250:
		case 251:
		case 252:
		case 253:
			break;
		}
	}

	private static bool AddResourceByPickup(DataContext context, MapPickup pickup)
	{
		DomainManager.Taiwu.AddResource(context, ItemSourceType.Inventory, pickup.ResourceType, pickup.ResourceCount);
		return true;
	}

	private static bool AddItemByPickup(DataContext context, MapPickup pickup)
	{
		ItemKey itemKey = DomainManager.Item.CreateItem(context, pickup.ItemType, pickup.ItemTemplateId);
		return AddItem(context, itemKey, 1);
	}

	private static bool LoopOnceByPickup(DataContext context, MapPickup pickup)
	{
		DomainManager.Taiwu.ApplyNeigongLoopingImprovementOnce(context);
		DomainManager.Taiwu.TryAddLoopingEvent(context, GlobalConfig.Instance.BaseLoopingEventProbability);
		return true;
	}

	private static bool ReadOnceByPickup(DataContext context, MapPickup pickup)
	{
		if (!DomainManager.Taiwu.UpdateReadingProgressOnce(context, isInCombat: false, addInstantNotification: false))
		{
			return false;
		}
		ItemKey currBook = DomainManager.Taiwu.GetCurReadingBook();
		DomainManager.Extra.AddReadingEventBookId(context, currBook.Id);
		return true;
	}

	private static bool AddExpByPickup(DataContext context, MapPickup pickup)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		taiwuChar.ChangeExp(context, pickup.ExpCount);
		return true;
	}

	private static bool AddDebtByPickup(DataContext context, MapPickup pickup)
	{
		sbyte stateId = DomainManager.Map.GetStateIdByAreaId(pickup.Location.AreaId);
		List<short> areaIdList = ObjectPool<List<short>>.Instance.Get();
		DomainManager.Map.GetAllAreaInState(stateId, areaIdList);
		foreach (short areaId in areaIdList)
		{
			DomainManager.Extra.ChangeAreaSpiritualDebt(context, areaId, pickup.DebtCount, getProfessionSeniority: true, addInstantNotification: false);
		}
		return true;
	}

	public void SetPickupAtFirst(DataContext context, MapPickup pickup)
	{
		if (pickup == null)
		{
			throw new ArgumentNullException("pickup");
		}
		if (!DomainManager.Extra.TryGetElement_PickupDict(pickup.Location, out var pickupCollection))
		{
			throw new ArgumentException("IgnorePickup: Trying Ignore a pickup not in pickup collection");
		}
		pickupCollection.SetPickupAtFirst(pickup);
		DomainManager.Extra.SetMapPickupCollection(context, pickup.Location, pickupCollection);
	}

	public void IgnoreOneMapPickup(DataContext context, MapPickup pickup)
	{
		if (pickup == null)
		{
			throw new ArgumentNullException("pickup");
		}
		if (!DomainManager.Extra.TryGetElement_PickupDict(pickup.Location, out var pickupCollection))
		{
			throw new ArgumentException("IgnorePickup: Trying Ignore a pickup not in pickup collection");
		}
		pickupCollection.IgnorePickup(pickup);
		DomainManager.Extra.SetMapPickupCollection(context, pickup.Location, pickupCollection);
	}

	public static (bool, PresetItemWithCount) CheckMapPickupConfigItemRewards(MapPickupsItem pickupConfig, int index)
	{
		List<PresetItemWithCount> itemRewards = pickupConfig.EventSecondItemRewards;
		if (index < 0 || itemRewards == null || index > itemRewards.Count - 1)
		{
			return (false, null);
		}
		PresetItemWithCount itemReward = itemRewards[index];
		if (!itemReward.IsValid)
		{
			return (false, null);
		}
		return (true, itemReward);
	}

	public static (bool, ResourceInfo?) CheckMapPickupConfigResourceRewards(MapPickupsItem pickupConfig, int index)
	{
		List<ResourceInfo> resourceRewards = pickupConfig.EventSecondResourceRewards;
		if (index < 0 || resourceRewards == null || index > resourceRewards.Count - 1)
		{
			return (false, null);
		}
		ResourceInfo resourceReward = resourceRewards[index];
		if (resourceReward.ResourceType < 0)
		{
			return (false, null);
		}
		return (true, resourceReward);
	}

	public static (bool, PropertyAndValue?) CheckMapPickupConfigQualificationRewards(MapPickupsItem pickupConfig, int index)
	{
		List<PropertyAndValue> propertyRewards = pickupConfig.EventSecondPropertyRewards;
		if (index < 0 || propertyRewards == null || index > propertyRewards.Count - 1)
		{
			return (false, null);
		}
		PropertyAndValue qualificationReward = propertyRewards[index];
		short propertyId = qualificationReward.PropertyId;
		bool isLifeSkillQualification = propertyId >= 34 && propertyId <= 49;
		bool isCombatSkillQualification = propertyId >= 66 && propertyId <= 79;
		if (!isLifeSkillQualification && !isCombatSkillQualification)
		{
			return (false, null);
		}
		return (true, qualificationReward);
	}

	public static (bool, PropertyAndValue?) CheckMapPickupConfigCricketLuckPointRewards(MapPickupsItem pickupConfig, int index)
	{
		List<PropertyAndValue> propertyRewards = pickupConfig.EventSecondPropertyRewards;
		if (index < 0 || propertyRewards == null || index > propertyRewards.Count - 1)
		{
			return (false, null);
		}
		PropertyAndValue qualificationReward = propertyRewards[index];
		short propertyId = qualificationReward.PropertyId;
		if (propertyId != 111)
		{
			return (false, null);
		}
		return (true, qualificationReward);
	}

	public static (bool, int?) CheckMapPickupConfigDebtRewards(MapPickupsItem pickupConfig, int index)
	{
		List<int> debtRewards = pickupConfig.EventSecondDebtRewards;
		if (index < 0 || debtRewards == null || index > debtRewards.Count - 1)
		{
			return (false, null);
		}
		int debtReward = debtRewards[index];
		if (debtReward < 0)
		{
			return (false, null);
		}
		return (true, debtReward);
	}

	public static (bool, int?) CheckMapPickupConfigExpRewards(MapPickupsItem pickupConfig, int index)
	{
		List<int> expRewards = pickupConfig.EventSecondExpRewards;
		if (index < 0 || expRewards == null || index > expRewards.Count - 1)
		{
			return (false, null);
		}
		int expReward = expRewards[index];
		return (true, expReward);
	}

	public bool GiveMapPickupEventUserSelectedItemReward(DataContext context, ItemKey itemKey, int count)
	{
		AddItem(context, itemKey, count);
		return true;
	}

	public bool GiveMapPickupEventNormalReward(DataContext context, MapPickup pickup, int index)
	{
		if (index < 0)
		{
			return false;
		}
		var (isValidItemReward, itemReward) = CheckMapPickupConfigItemRewards(pickup.Template, index);
		if (isValidItemReward)
		{
			return AddItemByEventPickup(context, itemReward);
		}
		var (isValidResourceReward, resourceReward) = CheckMapPickupConfigResourceRewards(pickup.Template, index);
		if (isValidResourceReward)
		{
			return AddResourceByEventPickup(context, resourceReward.Value);
		}
		var (isValidQualificationReward, qualificationReward) = CheckMapPickupConfigQualificationRewards(pickup.Template, index);
		if (isValidQualificationReward)
		{
			return AddQualificationByEventPickup(context, qualificationReward.Value);
		}
		var (isValidCricketLuckPointReward, cricketLuckPointReward) = CheckMapPickupConfigCricketLuckPointRewards(pickup.Template, index);
		if (isValidCricketLuckPointReward)
		{
			return AddCricketLuckPointByEventPickup(context, cricketLuckPointReward.Value);
		}
		var (isValidDebtReward, debtReward) = CheckMapPickupConfigDebtRewards(pickup.Template, index);
		if (isValidDebtReward)
		{
			return AddDebtByEventPickup(context, pickup, debtReward.Value);
		}
		var (isValidExpReward, expReward) = CheckMapPickupConfigExpRewards(pickup.Template, index);
		if (isValidExpReward)
		{
			return AddExpByEventPickup(context, expReward.Value);
		}
		return false;
	}

	private static bool AddDebtByEventPickup(DataContext context, MapPickup pickup, int debtReward)
	{
		short areaId = pickup.Location.AreaId;
		DomainManager.Extra.ChangeAreaSpiritualDebt(context, areaId, debtReward);
		return true;
	}

	private static bool AddExpByEventPickup(DataContext context, int expReward)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		taiwuChar.ChangeExp(context, expReward);
		return true;
	}

	private static bool AddQualificationByEventPickup(DataContext context, PropertyAndValue qualificationReward)
	{
		short value = qualificationReward.Value;
		GameData.Domains.Character.Character character = DomainManager.Taiwu.GetTaiwu();
		ECharacterPropertyReferencedType lifeSkillQualificationStartRef = ECharacterPropertyReferencedType.QualificationMusic;
		ECharacterPropertyReferencedType lifeSkillQualificationEndRef = ECharacterPropertyReferencedType.QualificationEclectic;
		ECharacterPropertyReferencedType combatSkillQualificationStartRef = ECharacterPropertyReferencedType.QualificationNeigong;
		ECharacterPropertyReferencedType combatSkillQualificationEndRef = ECharacterPropertyReferencedType.QualificationCombatMusic;
		short propertyId = qualificationReward.PropertyId;
		if (propertyId >= (short)lifeSkillQualificationStartRef && propertyId <= (short)lifeSkillQualificationEndRef)
		{
			LifeSkillShorts qualifications = character.GetBaseLifeSkillQualifications();
			int skillType = propertyId - (short)lifeSkillQualificationStartRef;
			qualifications.Set(skillType, (short)(qualifications.Get(skillType) + value));
			character.SetBaseLifeSkillQualifications(ref qualifications, context);
			return true;
		}
		if (propertyId >= (short)combatSkillQualificationStartRef && propertyId <= (short)combatSkillQualificationEndRef)
		{
			CombatSkillShorts qualifications2 = character.GetBaseCombatSkillQualifications();
			int skillType2 = propertyId - (short)combatSkillQualificationStartRef;
			qualifications2[skillType2] += value;
			character.SetBaseCombatSkillQualifications(ref qualifications2, context);
			return true;
		}
		return false;
	}

	private static bool AddCricketLuckPointByEventPickup(DataContext context, PropertyAndValue cricketLuckPointReward)
	{
		short value = cricketLuckPointReward.Value;
		DomainManager.Taiwu.SetCricketLuckPoint(DomainManager.Taiwu.GetCricketLuckPoint() + value, context);
		return true;
	}

	private static bool AddResourceByEventPickup(DataContext context, ResourceInfo resourceReward)
	{
		sbyte resourceType = resourceReward.ResourceType;
		int count = resourceReward.ResourceCount;
		DomainManager.Taiwu.AddResource(context, ItemSourceType.Inventory, resourceType, count);
		return true;
	}

	private static bool AddItemByEventPickup(DataContext context, PresetItemWithCount itemReward)
	{
		sbyte itemType = itemReward.ItemType;
		short templateId = itemReward.TemplateId;
		int count = itemReward.Count;
		ItemKey itemKey = DomainManager.Item.CreateItem(context, itemType, templateId);
		if (!itemKey.IsValid())
		{
			return false;
		}
		AddItem(context, itemKey, count);
		return true;
	}

	private static bool AddItem(DataContext context, ItemKey itemKey, int count)
	{
		return DomainManager.Taiwu.AddItem(context, itemKey, count, ItemSourceType.Inventory, offLine: false, EItemAutoOperationSource.Pick);
	}

	public MapElementPickupDisplayData GetPickupDisplayData(MapPickup pickup)
	{
		return new MapElementPickupDisplayData
		{
			Pickup = pickup,
			BanReason = pickup.CalcMapPickupBanReason(),
			CanAutoBeatXiangshuMinion = pickup.CalcCanAutoBeatXiangshuMinion()
		};
	}

	[DomainMethod]
	public void TeleportByTraveler(DataContext context, short destBlockId)
	{
		SetTeleportMove(teleport: true);
		Move(context, destBlockId);
		SetTeleportMove(teleport: false);
	}

	[DomainMethod]
	public bool BuildTravelerPalace(DataContext context, Location location)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(11);
		TravelerSkillsData skillData = professionData.GetSkillsData<TravelerSkillsData>();
		if (skillData.PalaceCount >= 3)
		{
			return false;
		}
		skillData.OfflineBuildPalace(location);
		DomainManager.Extra.SetProfessionData(context, professionData);
		return true;
	}

	[DomainMethod]
	public bool ChangeTravelerPalaceName(DataContext context, int index, string newName)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(11);
		TravelerSkillsData skillData = professionData.GetSkillsData<TravelerSkillsData>();
		TravelerPalaceData palaceData = skillData.TryGetPalaceData(index);
		if (palaceData == null)
		{
			return false;
		}
		palaceData.CustomName = newName;
		DomainManager.Extra.SetProfessionData(context, professionData);
		return true;
	}

	[DomainMethod]
	public bool DestroyTravelerPalace(DataContext context, int index)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(11);
		TravelerSkillsData skillData = professionData.GetSkillsData<TravelerSkillsData>();
		bool success = skillData.OfflineDestroyPalace(index);
		if (success)
		{
			DomainManager.Extra.SetProfessionData(context, professionData);
		}
		return success;
	}

	[DomainMethod]
	public bool TeleportOnTravelerPalace(DataContext context, int index)
	{
		if (IsTraveling)
		{
			return false;
		}
		if (DomainManager.Extra.GetTotalActionPointsRemaining() < 10)
		{
			return false;
		}
		DomainManager.Extra.ConsumeActionPoint(context, 10);
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(11);
		TravelerSkillsData skillData = professionData.GetSkillsData<TravelerSkillsData>();
		TravelerPalaceData palaceData = skillData.TryGetPalaceData(index);
		if (palaceData == null)
		{
			return false;
		}
		Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (location.AreaId != palaceData.Location.AreaId)
		{
			QuickTravel(context, palaceData.Location.AreaId);
		}
		TeleportByTraveler(context, palaceData.Location.BlockId);
		if (location.AreaId != palaceData.Location.AreaId)
		{
			DomainManager.TaiwuEvent.OnEvent_OnFinishTravel();
		}
		foreach (int groupCharId in DomainManager.Taiwu.GetGroupCharIds().GetCollection())
		{
			GameData.Domains.Character.Character groupChar = DomainManager.Character.GetElement_Objects(groupCharId);
			MakeRandomTravelerPalaceDisaster(context, groupChar);
		}
		return true;
	}

	private static void MakeRandomTravelerPalaceDisaster(DataContext context, GameData.Domains.Character.Character groupChar)
	{
		switch (context.Random.Next(4))
		{
		case 0:
		{
			for (int j = 0; j < ProfessionRelatedConstants.TravelerPalaceRandomInjuryCount(context.Random); j++)
			{
				sbyte bodyPart = (sbyte)context.Random.Next(7);
				bool inner = context.Random.NextBool();
				groupChar.ChangeInjury(context, bodyPart, inner, 1);
			}
			break;
		}
		case 1:
		{
			List<sbyte> poisonTypes = ObjectPool<List<sbyte>>.Instance.Get();
			for (sbyte i = 0; i < 6; i++)
			{
				poisonTypes.Add(i);
			}
			foreach (sbyte poisonType in RandomUtils.GetRandomUnrepeated(context.Random, 3, poisonTypes))
			{
				groupChar.ChangePoisoned(context, poisonType, 3, ProfessionRelatedConstants.TravelerRandomPoisonValue(context.Random));
			}
			ObjectPool<List<sbyte>>.Instance.Return(poisonTypes);
			break;
		}
		case 2:
		{
			int addQiDisorder = ProfessionRelatedConstants.TravelerRandomQiDisorderValue(context.Random);
			groupChar.ChangeDisorderOfQiRandomRecovery(context, addQiDisorder);
			break;
		}
		case 3:
		{
			int reduceHealth = ProfessionRelatedConstants.TravelerRandomHealthValue(context.Random);
			groupChar.ChangeHealth(context, -reduceHealth);
			break;
		}
		}
	}

	[DomainMethod]
	public Location QueryFixedCharacterLocation(short templateId)
	{
		GameData.Domains.Character.Character character;
		return DomainManager.Character.TryGetFixedCharacterByTemplateId(templateId, out character) ? character.GetLocation() : Location.Invalid;
	}

	[DomainMethod]
	public Location QueryFixedCharacterLocationInArea(short templateId, short areaId)
	{
		Location location = QueryFixedCharacterLocation(templateId);
		return (location.AreaId == areaId) ? location : Location.Invalid;
	}

	[DomainMethod]
	public Location QueryTemplateBlockLocation(int templateId)
	{
		for (short areaId = 0; areaId < 141; areaId++)
		{
			Location location = QueryTemplateBlockLocationInArea(templateId, areaId);
			if (location.IsValid())
			{
				return location;
			}
		}
		return Location.Invalid;
	}

	[DomainMethod]
	public Location QueryTemplateBlockLocationInArea(int templateId, short areaId)
	{
		Span<MapBlockData> areaBlocks = GetAreaBlocks(areaId);
		if (areaBlocks.Length <= 0)
		{
			return Location.Invalid;
		}
		Span<MapBlockData> span = areaBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData blockData = span[i];
			if (blockData.TemplateId == templateId)
			{
				return blockData.GetLocation();
			}
		}
		return Location.Invalid;
	}

	public void QueryRootBlocks(List<MapBlockData> rootBlocks, Location location)
	{
		rootBlocks.Clear();
		if (!location.IsValid())
		{
			return;
		}
		Span<MapBlockData> areaBlocks = GetAreaBlocks(location.AreaId);
		Span<MapBlockData> span = areaBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData block = span[i];
			if (block.BlockId == location.BlockId || block.RootBlockId == location.BlockId)
			{
				rootBlocks.Add(block);
			}
		}
	}

	public void QueryRegularBelongBlocks(List<MapBlockData> belongBlocks, Location location, bool includeSect, params MapBlockDataFilter[] extraFilters)
	{
		belongBlocks.Clear();
		if (!location.IsValid() || location.AreaId >= _regularAreaBlocksArray.Length)
		{
			return;
		}
		AreaBlockCollection areaBlocks = _regularAreaBlocksArray[location.AreaId];
		MapBlockData[] blockArray = areaBlocks.GetArray();
		foreach (MapBlockData blockData in blockArray)
		{
			if (IsFiltersPass(blockData, extraFilters) && blockData.IsPassable())
			{
				if (includeSect && (blockData.BlockId == location.BlockId || blockData.RootBlockId == location.BlockId))
				{
					belongBlocks.Add(blockData);
				}
				else if (blockData.BelongBlockId == location.BlockId)
				{
					belongBlocks.Add(blockData);
				}
			}
		}
	}

	public int QueryAreaBrokenLevel(short areaId)
	{
		if ((areaId < 45 || areaId >= 135) ? true : false)
		{
			return -1;
		}
		return GetElement_BrokenAreaEnemies(areaId - 45).Level;
	}

	private List<CharacterDisplayData> CharacterDisplayDataSorter(List<CharacterDisplayData> data)
	{
		return (from item in data
			orderby item.OrgInfo.Grade descending, item.OrgInfo.Principal descending, item.PhysiologicalAge descending, item.BirthDate, item.BirthDate, item.CharacterId
			select item).ToList();
	}

	[DomainMethod]
	public MapBlockCharacterList RequestMapBlockCharacterList(DataContext context, MapBlockData data)
	{
		MapBlockCharacterList mapBlockCharacterList = new MapBlockCharacterList();
		mapBlockCharacterList.SpecialCharacters = CharacterDisplayDataSorter((data?.FixedCharacterSet != null) ? DomainManager.Character.GetCharacterDisplayDataList(data.FixedCharacterSet.Concat((!DomainManager.Extra.TryGetHeavenlyTreeByLocation(data.GetLocation(), out var tree)) ? ((IEnumerable<int>)Array.Empty<int>()) : ((IEnumerable<int>)new int[1] { tree.Id })).ToList()) : ((data != null && DomainManager.Extra.TryGetHeavenlyTreeByLocation(data.GetLocation(), out tree)) ? new List<CharacterDisplayData> { DomainManager.Character.GetCharacterDisplayData(tree.Id) } : new List<CharacterDisplayData>()));
		mapBlockCharacterList.NormalCharacters = ((data?.CharacterSet == null) ? new List<CharacterDisplayData>() : CharacterDisplayDataSorter(DomainManager.Character.GetCharacterDisplayDataList(data.CharacterSet.ToList())));
		mapBlockCharacterList.InfectedCharacters = ((data?.InfectedCharacterSet == null) ? new List<CharacterDisplayData>() : CharacterDisplayDataSorter(DomainManager.Character.GetCharacterDisplayDataList(data.InfectedCharacterSet.ToList())));
		mapBlockCharacterList.EnemyCharacters = ((data?.EnemyCharacterSet == null) ? new List<CharacterDisplayData>() : CharacterDisplayDataSorter(DomainManager.Character.GetCharacterDisplayDataList(data.EnemyCharacterSet.ToList())));
		mapBlockCharacterList.RandomEnemies = data?.TemplateEnemyList?.OrderByDescending((MapTemplateEnemyInfo item) => Config.Character.Instance[item.TemplateId].OrganizationInfo.Grade).ThenBy((MapTemplateEnemyInfo item) => item.TemplateId).ToList() ?? new List<MapTemplateEnemyInfo>();
		mapBlockCharacterList.Animals = ((data != null && DomainManager.Extra.TryGetAnimalIdsByLocation(data.GetLocation(), out var animalIds)) ? (from id in animalIds
			select DomainManager.Extra.GetElement_Animals(id) into item
			orderby Config.Character.Instance[item.CharacterTemplateId]?.OrganizationInfo.Grade ?? (-1) descending, item.CharacterTemplateId
			select item).ToList() : new List<GameData.Domains.Character.Animal>());
		mapBlockCharacterList.Caravans = ((data == null) ? new List<CaravanDisplayData>() : (from x in DomainManager.Merchant.GetCaravanAtBlock(context, data.GetLocation())
			orderby x.CaravanId
			select x).ToList());
		mapBlockCharacterList.Graves = ((data?.GraveSet == null) ? new List<GraveDisplayData>() : (from x in DomainManager.Character.GetGraveDisplayDataList(data.GraveSet.Where(delegate(int id)
			{
				if (DomainManager.Character.TryGetElement_Graves(id, out var _))
				{
					return true;
				}
				AdaptableLog.Warning($"Found id {id} in GraveSet with invalid grave data, related deadcharacter is {DomainManager.Character.GetMonasticTitleOrDisplayName(id)}", appendWarningMessage: true);
				return false;
			}).ToList())
			orderby x.NameData.OrgGrade descending, x.Principal descending, x.NameData.Gender, x.Id
			select x).ToList());
		mapBlockCharacterList.InteractedCharSet = DomainManager.TaiwuEvent.InteractedCharSet;
		mapBlockCharacterList.HasGuardInfo = new Dictionary<int, bool>();
		MapBlockCharacterList res = mapBlockCharacterList;
		foreach (CharacterDisplayData charData in res.EnemyCharacters.Concat(res.SpecialCharacters.Concat(res.NormalCharacters.Concat(res.InfectedCharacters))))
		{
			if (charData.CreatingType == 1)
			{
				(charData.VisibleCharacterInteractionEventOptionDict, charData.NoInteractionReason) = DomainManager.TaiwuEvent.GetVisibleCharacterInteractionEventOptions(charData.CharacterId);
			}
			CharacterDisplayDataForGuard guardData = DomainManager.Character.GetCharacterDisplayDataForGuard(context, charData.CharacterId);
			if (guardData.Guards.Count > 0)
			{
				res.HasGuardInfo[guardData.CharId] = guardData.HasGuard;
			}
		}
		return res;
	}

	private static bool IsFiltersPass(MapBlockData blockData, IEnumerable<MapBlockDataFilter> filters)
	{
		if (filters == null)
		{
			return true;
		}
		foreach (MapBlockDataFilter filter in filters)
		{
			if (!filter(blockData))
			{
				return false;
			}
		}
		return true;
	}

	public static bool QueryFilterAnyCharacter(MapBlockData blockData)
	{
		return blockData.CharacterSet != null && blockData.CharacterSet.Count > 0;
	}

	public MapBlockData GetRandomMapBlockDataByFilters(IRandomSource random, sbyte stateTemplateId, List<short> mapBlockSubTypes, bool includeBlockWithAdventure)
	{
		if (mapBlockSubTypes != null && mapBlockSubTypes.Count > 0)
		{
			EMapBlockSubType mapBlockSubType = (EMapBlockSubType)mapBlockSubTypes[random.Next(0, mapBlockSubTypes.Count)];
			if (mapBlockSubType == EMapBlockSubType.TaiwuCun)
			{
				return GetBlock(DomainManager.Taiwu.GetTaiwuVillageLocation());
			}
			if (mapBlockSubType > EMapBlockSubType.TaiwuCun && mapBlockSubType < EMapBlockSubType.Farmland)
			{
				for (short areaId = 0; areaId < 45; areaId++)
				{
					short settlementMainBlockId = DomainManager.Map.GetMainSettlementMainBlockId(areaId);
					MapBlockData settlementMainBlock = DomainManager.Map.GetBlock(areaId, settlementMainBlockId);
					if (settlementMainBlock.BlockSubType == mapBlockSubType)
					{
						List<short> settlementBlocks = new List<short>();
						GetSettlementBlocks(areaId, settlementMainBlockId, settlementBlocks);
						if (!includeBlockWithAdventure)
						{
							AdventureCacheData cache = DomainManager.Adventure.GetAdventureCache();
							for (int i = settlementBlocks.Count - 1; i >= 0; i--)
							{
								short blockId = settlementBlocks[i];
								if (cache.QueryAnyAdventureOrMajorEvent(new Location(areaId, blockId)))
								{
									settlementBlocks.RemoveAt(i);
								}
							}
						}
						return GetBlock(areaId, settlementBlocks[random.Next(settlementBlocks.Count)]);
					}
				}
			}
		}
		List<short> areaList = ObjectPool<List<short>>.Instance.Get();
		areaList.Clear();
		if (stateTemplateId == 0)
		{
			areaList.Add(135);
		}
		else
		{
			if (stateTemplateId == -1)
			{
				stateTemplateId = (sbyte)random.Next(1, 16);
			}
			int normalAreaCount = 3;
			DomainManager.Map.GetAllAreaInState((sbyte)(stateTemplateId - 1), areaList);
			areaList.RemoveRange(normalAreaCount, 6);
		}
		MapStateItem stateConfig = MapState.Instance[stateTemplateId];
		short selectedAreaId = areaList[random.Next(0, areaList.Count)];
		ObjectPool<List<short>>.Instance.Return(areaList);
		return GetRandomMapBlockDataInAreaByFilters(random, selectedAreaId, mapBlockSubTypes, includeBlockWithAdventure);
	}

	public void GetMapBlocksInAreaByFilters(short areaId, Predicate<MapBlockData> predicate, List<MapBlockData> result)
	{
		result.Clear();
		Span<MapBlockData> areaBlocks = GetAreaBlocks(areaId);
		Span<MapBlockData> span = areaBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData areaBlock = span[i];
			if (areaBlock.IsPassable() && !DomainManager.Extra.IsLocationInDreamBack(areaBlock.GetLocation()) && predicate(areaBlock))
			{
				result.Add(areaBlock);
			}
		}
	}

	public MapBlockData GetRandomMapBlockDataInAreaByFilters(IRandomSource random, short areaId, IReadOnlyCollection<short> mapBlockSubTypes, bool includeBlocksWithAdventure)
	{
		List<MapBlockData> selectableBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		Predicate<MapBlockData> predicate = ((mapBlockSubTypes != null && mapBlockSubTypes.Count > 0) ? new Predicate<MapBlockData>(IsBlockInList) : new Predicate<MapBlockData>(IsBlockNormalOrWild));
		GetMapBlocksInAreaByFilters(areaId, predicate, selectableBlocks);
		MapBlockData block = ((selectableBlocks.Count > 0) ? selectableBlocks[random.Next(selectableBlocks.Count)] : null);
		ObjectPool<List<MapBlockData>>.Instance.Return(selectableBlocks);
		return block;
		bool IsBlockInList(MapBlockData mapBlockData)
		{
			if (!mapBlockSubTypes.Contains((short)mapBlockData.BlockType))
			{
				return false;
			}
			if (!includeBlocksWithAdventure)
			{
				return !DomainManager.Adventure.GetAdventureCache().QueryAnyAdventureOrMajorEvent(mapBlockData.GetLocation());
			}
			return true;
		}
		bool IsBlockNormalOrWild(MapBlockData mapBlockData)
		{
			if (mapBlockData.BlockSubType == EMapBlockSubType.SwordTomb || mapBlockData.BlockSubType == EMapBlockSubType.DLCLoong || (mapBlockData.BlockType != EMapBlockType.Normal && mapBlockData.BlockType != EMapBlockType.Wild))
			{
				return false;
			}
			if (!includeBlocksWithAdventure)
			{
				return !DomainManager.Adventure.GetAdventureCache().QueryAnyAdventureOrMajorEvent(mapBlockData.GetLocation());
			}
			return true;
		}
	}

	public MapBlockData SelectBlockInCurrentOrNeighborState(IRandomSource random, Location centerLocation, Predicate<MapBlockData> condition, bool taiwuVillageInfluenceRangeIsLast = false)
	{
		MapBlockData blockData = SelectBlockInArea(random, centerLocation.AreaId, condition, taiwuVillageInfluenceRangeIsLast);
		if (blockData != null)
		{
			return blockData;
		}
		sbyte stateId = DomainManager.Map.GetStateIdByAreaId(centerLocation.AreaId);
		blockData = SelectBlockInState(random, stateId, condition);
		if (blockData != null)
		{
			return blockData;
		}
		sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(centerLocation.AreaId);
		sbyte[] neighborStateTemplateIds = MapState.Instance[stateTemplateId].NeighborStates;
		sbyte[] array = neighborStateTemplateIds;
		foreach (sbyte neighborStateTemplateId in array)
		{
			sbyte neighborStateId = DomainManager.Map.GetStateIdByStateTemplateId(neighborStateTemplateId);
			blockData = SelectBlockInState(random, neighborStateId, condition);
			if (blockData != null)
			{
				return blockData;
			}
		}
		if (taiwuVillageInfluenceRangeIsLast)
		{
			blockData = SelectBlockInTaiwuVillageInfluenceRange(random, condition);
			if (blockData != null)
			{
				return blockData;
			}
		}
		return null;
	}

	private MapBlockData SelectBlockInState(IRandomSource random, sbyte stateId, Predicate<MapBlockData> condition)
	{
		List<short> areaIds = ObjectPool<List<short>>.Instance.Get();
		DomainManager.Map.GetAllRegularAreaInState(stateId, areaIds);
		CollectionUtils.Shuffle(random, areaIds);
		MapBlockData blockData = null;
		foreach (short areaId in areaIds)
		{
			blockData = SelectBlockInArea(random, areaId, condition);
			if (blockData != null)
			{
				break;
			}
		}
		ObjectPool<List<short>>.Instance.Return(areaIds);
		return blockData;
	}

	public MapBlockData SelectBlockInArea(IRandomSource random, short areaId, Predicate<MapBlockData> condition, bool exceptTaiwuVillageInfluenceRange = false)
	{
		List<MapBlockData> blocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetMapBlocksInAreaByFilters(areaId, condition, blocks);
		if (exceptTaiwuVillageInfluenceRange)
		{
			short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
			blocks.RemoveAll((MapBlockData b) => DomainManager.Map.IsLocationInSettlementInfluenceRange(b.GetLocation(), settlementId));
		}
		MapBlockData selectedBlock = blocks.GetRandomOrDefault(random, null);
		ObjectPool<List<MapBlockData>>.Instance.Return(blocks);
		return selectedBlock;
	}

	public MapBlockData SelectBlockInTaiwuVillageInfluenceRange(IRandomSource random, Predicate<MapBlockData> condition)
	{
		List<MapBlockData> blocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		DomainManager.Map.GetMapBlocksInAreaByFilters(taiwuVillageLocation.AreaId, condition, blocks);
		short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		blocks.RemoveAll((MapBlockData b) => !DomainManager.Map.IsLocationInSettlementInfluenceRange(b.GetLocation(), settlementId));
		MapBlockData selectedBlock = blocks.GetRandomOrDefault(random, null);
		ObjectPool<List<MapBlockData>>.Instance.Return(blocks);
		return selectedBlock;
	}

	public MapBlockData GetBelongSettlementBlock(Location location)
	{
		MapBlockData blockData = GetBlock(location);
		if (blockData.IsCityTown())
		{
			return blockData.GetRootBlock();
		}
		if (blockData.BelongBlockId >= 0)
		{
			MapBlockData belongBlock = GetBlock(new Location(location.AreaId, blockData.BelongBlockId));
			if (belongBlock.IsCityTown())
			{
				return belongBlock;
			}
		}
		return null;
	}

	public bool IsLocationInSettlementInfluenceRange(Location location, short settlementId)
	{
		Location settlementLocation = DomainManager.Organization.GetSettlement(settlementId).GetLocation();
		return IsLocationInSettlementInfluenceRange(location, settlementLocation);
	}

	private bool IsLocationInSettlementInfluenceRange(Location location, Location settlementLocation)
	{
		if (location.AreaId != settlementLocation.AreaId)
		{
			return false;
		}
		MapBlockData blockData = GetBlock(location);
		return blockData.BlockId == settlementLocation.BlockId || blockData.RootBlockId == settlementLocation.BlockId || blockData.BelongBlockId == settlementLocation.BlockId;
	}

	public bool IsLocationInOrganizationInfluenceRange(Location location, sbyte orgTemplateId)
	{
		MapBlockData block = GetBelongSettlementBlock(location);
		if (block == null)
		{
			return false;
		}
		Settlement settlement = DomainManager.Organization.GetSettlementByLocation(block.GetLocation());
		return settlement.GetOrgTemplateId() == orgTemplateId;
	}

	public bool IsLocationOnSettlementBlock(Location location, short settlementId)
	{
		MapBlockData rootBlock = GetBlock(location)?.GetRootBlock();
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		if (rootBlock == null || settlement == null)
		{
			return false;
		}
		Location settlementLocation = settlement.GetLocation();
		return rootBlock.AreaId == settlementLocation.AreaId && rootBlock.BlockId == settlementLocation.BlockId;
	}

	public bool CheckLocationsHasSameRoot(Location locationA, Location locationB)
	{
		if (!locationA.IsValid() || !locationB.IsValid())
		{
			return false;
		}
		if (locationA == locationB)
		{
			return true;
		}
		MapBlockData blockA = GetBlock(locationA);
		MapBlockData blockB = GetBlock(locationB);
		return blockA.GetRootBlock() == blockB.GetRootBlock();
	}

	public void GetSettlementBlocks(short areaId, short blockId, List<short> blockIds)
	{
		blockIds.Add(blockId);
		List<MapBlockData> groupBlocks = GetAreaBlockCollection(areaId)[blockId].GroupBlockList;
		if (groupBlocks != null)
		{
			int i = 0;
			for (int count = groupBlocks.Count; i < count; i++)
			{
				blockIds.Add(groupBlocks[i].BlockId);
			}
		}
	}

	public short GetRandomSettlementBlock(IRandomSource random, short areaId, short blockId)
	{
		List<MapBlockData> groupBlocks = GetAreaBlockCollection(areaId)[blockId].GroupBlockList;
		if (groupBlocks == null)
		{
			return -1;
		}
		Span<short> span = stackalloc short[9];
		SpanList<short> spanList = span;
		int i = 0;
		for (int count = groupBlocks.Count; i < count; i++)
		{
			spanList.Add(new Location(areaId, groupBlocks[i].BlockId).BlockId);
		}
		spanList.Add(blockId);
		return (short)((spanList.Count > 0) ? spanList.GetRandom(random) : (-1));
	}

	public void GetSettlementBlocksAndAffiliatedBlocks(short areaId, short blockId, List<short> blockIds)
	{
		blockIds.Add(blockId);
		AreaBlockCollection areaBlocks = GetAreaBlockCollection(areaId);
		int i = 0;
		for (int count = areaBlocks.Count; i < count; i++)
		{
			MapBlockData block = areaBlocks[(short)i];
			if (block.RootBlockId == blockId || (block.BelongBlockId == blockId && block.IsPassable()))
			{
				blockIds.Add(block.BlockId);
			}
		}
	}

	public void GetSettlementAffiliatedBlocks(short areaId, short blockId, List<MapBlockData> blocks)
	{
		blocks.Clear();
		AreaBlockCollection areaBlocks = GetAreaBlockCollection(areaId);
		int i = 0;
		for (int count = areaBlocks.Count; i < count; i++)
		{
			MapBlockData block = areaBlocks[(short)i];
			if (block.BelongBlockId == blockId && block.IsPassable())
			{
				blocks.Add(block);
			}
		}
	}

	[DomainMethod]
	public bool IsLocationInBuildingEffectRange(Location location, Location settlementLocation)
	{
		return IsLocationInSettlementInfluenceRange(location, settlementLocation);
	}

	[DomainMethod]
	public void RemoveSwordTombFromLocation(DataContext context, Location location)
	{
		List<Location> blockIdList = GetBlockLocationGroup(location);
		short settlementId = DomainManager.Map.GetNearestSettlementIdByLocation(location);
		List<short[]> noDevelopedIdList = new List<short[]>();
		List<short> developedIdList = new List<short>();
		MapBlock.Instance.Iterate(delegate(MapBlockItem e)
		{
			if (e.Size > 1)
			{
				return true;
			}
			if (e.Type == EMapBlockType.Developed && e.CanGenerate)
			{
				developedIdList.Add(e.TemplateId);
			}
			if (e.Type == EMapBlockType.Normal && e.CanGenerate)
			{
				noDevelopedIdList.Add(new short[2] { e.TemplateId, 15 });
			}
			if (e.Type == EMapBlockType.Wild && e.CanGenerate)
			{
				noDevelopedIdList.Add(new short[2] { e.TemplateId, 60 });
			}
			if (e.Type == EMapBlockType.Bad && e.CanGenerate && e.SubType != EMapBlockSubType.Ruin && e.SubType != EMapBlockSubType.DarkPool)
			{
				noDevelopedIdList.Add(new short[2] { e.TemplateId, 25 });
			}
			return true;
		});
		short rootBlockId = DomainManager.Map.GetBlock(location).RootBlockId;
		if (rootBlockId != -1)
		{
			location = new Location(location.AreaId, rootBlockId);
		}
		DomainManager.Map.ChangeBlockTemplate(context, location, noDevelopedIdList.GetRandom(context.Random)[0], isTurnVisible: true);
		foreach (Location cellLocation in blockIdList)
		{
			short[] randomCell = RandomUtils.GenerateRandomWeightCell(context.Random, noDevelopedIdList);
			short blockTemplateId = randomCell[0];
			if (DomainManager.Map.IsLocationInSettlementInfluenceRange(cellLocation, settlementId))
			{
				blockTemplateId = developedIdList.GetRandom(context.Random);
			}
			ChangeBlockTemplate(context, cellLocation, blockTemplateId, isTurnVisible: true);
			MapBlockData cellBlockData = GetBlock(cellLocation);
			MakeBlockDestroyed(context, cellBlockData);
		}
	}

	[DomainMethod]
	public void SetBlockAndViewRangeVisibleByBlockTemplateId(DataContext context, Location location, short templateId)
	{
		MapBlockData block = GetBlock(location);
		MapBlockItem config = MapBlock.Instance[templateId];
		SetBlockAndNeighborVisible(context, block, config.ViewRange);
	}

	public void InitializeSpecialBlocksData()
	{
		UpdateWudangHeavenlyTreeLocations();
		UpdateFulongFlameLocations();
	}

	public void UpdateWudangHeavenlyTreeLocations()
	{
		List<SectStoryHeavenlyTreeExtendable> trees = DomainManager.Extra.GetAllHeavenlyTrees();
		_wudangHeavenlyTrees.Clear();
		foreach (SectStoryHeavenlyTreeExtendable tree in trees)
		{
			_wudangHeavenlyTrees.Add(tree.Location);
		}
	}

	public void UpdateFulongFlameLocations()
	{
		List<FulongInFlameArea> flameAreas = DomainManager.Extra.GetAllFulongInFlameAreas();
		_fulongLightedBlocks.Clear();
		foreach (FulongInFlameArea area in flameAreas)
		{
			foreach (short blockId in area.LightedBlocks.Keys)
			{
				_fulongLightedBlocks.Add(blockId);
			}
		}
	}

	public bool IsBlockOccupiedByCriticalAdventure(short areaId, short blockId)
	{
		return false;
	}

	public bool IsBlockSpecial(MapBlockData mapBlockData, bool strictCheck = true)
	{
		if (FiveLoongDlcEntry.IsBlockLoongBlock(mapBlockData))
		{
			return true;
		}
		if (IsLocationInFulongFlameArea(mapBlockData.GetLocation()))
		{
			return true;
		}
		if (strictCheck && _wudangHeavenlyTrees.Contains(mapBlockData.GetLocation()))
		{
			return true;
		}
		return false;
	}

	public bool IsLocationInFulongFlameArea(Location location)
	{
		List<FulongInFlameArea> flameAreas = DomainManager.Extra.GetAllFulongInFlameAreas();
		foreach (FulongInFlameArea area in flameAreas)
		{
			if (area.IsLocationInActiveFlame(location))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsBlockAvailable(MapBlockData mapBlockData, bool strictCheck)
	{
		return mapBlockData.IsNonDeveloped() && !mapBlockData.Destroyed && !IsBlockSpecial(mapBlockData, strictCheck) && mapBlockData.GetConfig().TemplateId != 126 && mapBlockData.IsPassable() && !IsBlockOccupiedByCriticalAdventure(mapBlockData.AreaId, mapBlockData.BlockId) && (!strictCheck || mapBlockData.GetConfig().TemplateId != 124);
	}

	public void RemoveTrivialObjectsOnBlocks(DataContext context, List<MapBlockData> mapBlocks)
	{
		foreach (MapBlockData block in mapBlocks)
		{
			Location location = block.GetLocation();
			if (DomainManager.Extra.TryGetAnimalIdsByLocation(location, out var animals))
			{
				for (int index = animals.Count - 1; index >= 0; index--)
				{
					int animalId = animals[index];
					DomainManager.Extra.ApplyAnimalDeadByAccident(context, animalId);
				}
			}
			List<MapTemplateEnemyInfo> templateEnemyList = block.TemplateEnemyList;
			if (templateEnemyList != null && templateEnemyList.Count > 0)
			{
				for (int index2 = block.TemplateEnemyList.Count - 1; index2 >= 0; index2--)
				{
					MapTemplateEnemyInfo enemyInfo = block.TemplateEnemyList[index2];
					Events.RaiseTemplateEnemyLocationChanged(context, enemyInfo, location, Location.Invalid);
				}
			}
			if (LocationHasCricket(context, location))
			{
				int index3 = Array.IndexOf(_cricketPlaceData[location.AreaId].CricketBlocks, location.BlockId);
				_cricketPlaceData[location.AreaId].CricketTriggered[index3] = true;
				SetElement_CricketPlaceData(location.AreaId, _cricketPlaceData[location.AreaId], context);
			}
		}
	}

	public bool TryGetAvailableBlockIdInRange(short areaId, int range, List<MapBlockData> neighborBlocks)
	{
		Span<MapBlockData> mapBlocks = DomainManager.Map.GetAreaBlocks(areaId);
		HashSet<short> visited = new HashSet<short>();
		return TryGetAvailableBlockIdInRange(areaId, range, isStrict: true, mapBlocks, visited, neighborBlocks) || TryGetAvailableBlockIdInRange(areaId, range, isStrict: false, mapBlocks, visited, neighborBlocks);
	}

	private bool TryGetAvailableBlockIdInRange(short areaId, int range, bool isStrict, Span<MapBlockData> mapBlocks, HashSet<short> visited, List<MapBlockData> neighborBlocks)
	{
		int extraRange = range + ((!isStrict) ? 1 : 2);
		byte areaSize = GetAreaSize(areaId);
		visited.Clear();
		Span<MapBlockData> span = mapBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData centerBlock = span[i];
			bool ok = true;
			ByteCoordinate blockPos = ByteCoordinate.IndexToCoordinate(centerBlock.BlockId, areaSize);
			neighborBlocks.Clear();
			for (int x = blockPos.X - extraRange; x <= blockPos.X + extraRange; x++)
			{
				if (!ok)
				{
					break;
				}
				for (int y = blockPos.Y - extraRange; y <= blockPos.Y + extraRange; y++)
				{
					if (x < 0 || x >= areaSize || y < 0 || y >= areaSize)
					{
						ok = false;
						break;
					}
					ByteCoordinate pos = new ByteCoordinate((byte)x, (byte)y);
					int distance = blockPos.GetManhattanDistance(pos);
					if (distance > extraRange)
					{
						continue;
					}
					MapBlockData neighborBlock = mapBlocks[ByteCoordinate.CoordinateToIndex(pos, areaSize)];
					if (!neighborBlocks.Contains(neighborBlock))
					{
						if (visited.Contains(neighborBlock.BlockId))
						{
							ok = false;
							break;
						}
						if (!IsBlockAvailable(neighborBlock, isStrict))
						{
							visited.Add(neighborBlock.BlockId);
							ok = false;
							break;
						}
						if (distance <= range)
						{
							neighborBlocks.Add(neighborBlock);
						}
					}
				}
			}
			if (ok)
			{
				return true;
			}
		}
		return false;
	}

	public void IncreaseMoveBanned(DataContext context)
	{
		SetMoveBanned(_moveBanned + 1, context);
	}

	public void DecreaseMoveBanned(DataContext context)
	{
		SetMoveBanned(_moveBanned - 1, context);
		if (_moveBanned < 0)
		{
			AdaptableLog.Warning($"Move banned count less than zero, current value is {_moveBanned}");
		}
	}

	public void Move(DataContext context, short destBlockId, bool notCostTime)
	{
		Logger.Info($"Move to {destBlockId}");
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location srcLocation = (TaiwuLastLocation = taiwuChar.GetLocation());
		Location destLocation = new Location(srcLocation.AreaId, destBlockId);
		MapAreaData areaData = _areas[srcLocation.AreaId];
		MapBlockData srcBlock = GetBlock(srcLocation);
		MapBlockData destBlock = GetBlock(destLocation);
		byte areaSize = GetAreaSize(srcLocation.AreaId);
		MapBlockItem blockConfig = destBlock.GetConfig();
		int requiredActionPoints = destBlock.MoveCostActionPoint;
		ByteCoordinate fromByteCoordinate = ByteCoordinate.IndexToCoordinate(srcLocation.BlockId, areaSize);
		ByteCoordinate toByteCoordinate = ByteCoordinate.IndexToCoordinate(destBlockId, areaSize);
		bool isNeighbor = Math.Abs(toByteCoordinate.X - fromByteCoordinate.X) + Math.Abs(toByteCoordinate.Y - fromByteCoordinate.Y) == 1;
		if (fromByteCoordinate == toByteCoordinate)
		{
			return;
		}
		if (DomainManager.TutorialChapter.InGuiding)
		{
			Location forceNextLocation = DomainManager.TutorialChapter.GetNextForceLocation();
			if (forceNextLocation != Location.Invalid && forceNextLocation != destLocation)
			{
				return;
			}
		}
		if (!destBlock.IsPassable())
		{
			PredefinedLog.Show(11, $"Block is not passable: {destBlockId}");
			return;
		}
		if (!isNeighbor && !_teleportMove)
		{
			PredefinedLog.Show(11, $"Can only move to a neighbor block: src={srcLocation.BlockId}, dst={destBlockId}");
		}
		if (!DomainManager.Extra.IsActionPointEnough(requiredActionPoints) && !notCostTime)
		{
			PredefinedLog.Show(11, $"Cannot advance days across month: {requiredActionPoints}, left days: {DomainManager.Extra.GetTotalActionPointsRemaining()}");
			return;
		}
		DomainManager.Taiwu.TaiwuGroupMove(context, destLocation);
		DomainManager.Extra.GearMateFollowTaiwu(context);
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(11);
		TravelerSkillsData skillsData = professionData.GetSkillsData<TravelerSkillsData>();
		int addSeniority = skillsData.RecordMovementConsumedActionPoints(requiredActionPoints);
		if (addSeniority > 0)
		{
			DomainManager.Extra.ChangeProfessionSeniority(context, 11, addSeniority);
		}
		else
		{
			DomainManager.Extra.SetProfessionData(context, professionData);
		}
		SetBlockAndViewRangeVisibleByMove(context, destBlock);
		AddAnimalProfessionSeniority(context, destLocation);
		if (destBlock.IsCityTown())
		{
			short settlementId = areaData.SettlementInfos[areaData.GetSettlementIndex(destBlock.GetRootBlock().BlockId)].SettlementId;
			Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
			Location location2 = settlement.GetLocation();
			MapBlockData mapBlockData = DomainManager.Map.GetBlock(location2);
			short mapBlockTemplateId = mapBlockData.GetConfig().TemplateId;
			if (!DomainManager.Extra.CheckIsUnlockedSectXuannvMusicByMapBlockId(mapBlockTemplateId))
			{
				DomainManager.Extra.UnlockSectXuannvMusicByMapBlockId(context, mapBlockTemplateId);
			}
		}
		HashSet<int> groupCharIds = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		if (blockConfig.TemplateId == 124)
		{
			List<sbyte> bodyPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
			IEnumerable<int> damagedCharIds = groupCharIds;
			if (taiwuChar.IsActiveExternalRelationState(2uL))
			{
				damagedCharIds = damagedCharIds.Union(from c in DomainManager.Character.GetKidnappedCharacters(taiwuChar.GetId()).GetCollection()
					select c.CharId);
			}
			foreach (int charId in damagedCharIds)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				Injuries injuries = character.GetInjuries();
				bodyPartRandomPool.Clear();
				bodyPartRandomPool.AddRange(BodyPart.Instance.GetAllKeys());
				bodyPartRandomPool.RemoveAll((sbyte part) => injuries.Get(part, isInnerInjury: false) >= 6);
				if (bodyPartRandomPool.Count > 0)
				{
					injuries.Change(bodyPartRandomPool[context.Random.Next(bodyPartRandomPool.Count)], isInnerInjury: false, 1);
					character.SetInjuries(injuries, context);
				}
				ReduceCharCarrierDurability(context, charId);
			}
			ObjectPool<List<sbyte>>.Instance.Return(bodyPartRandomPool);
		}
		else if (blockConfig.SubType == EMapBlockSubType.Ruin || destBlock.Destroyed)
		{
			foreach (int charId2 in groupCharIds)
			{
				ReduceCharCarrierDurability(context, charId2);
			}
		}
		UpdateIsTaiwuInFulongFlameArea(context);
		if (!notCostTime)
		{
			DomainManager.World.ConsumeActionPoint(context, requiredActionPoints);
		}
		InvokeGuidingChapterByMove(context, destBlock);
		Events.RaiseTaiwuMove(context, srcBlock, destBlock, requiredActionPoints);
	}

	[DomainMethod]
	public void Move(DataContext context, short destBlockId)
	{
		Move(context, destBlockId, _teleportMove || _crossArchiveLockMoveTime);
	}

	[DomainMethod]
	public void MoveFinish(DataContext context, Location previous, Location current)
	{
		if (!DomainManager.Map.GetCrossArchiveLockMoveTime())
		{
			MapBlockData currentBlockData = GetBlockData(current.AreaId, current.BlockId);
			if (currentBlockData != null)
			{
				MapBlockItem blockConfig = currentBlockData.GetConfig();
				if (blockConfig != null)
				{
					if (blockConfig.TemplateId == 124)
					{
						DomainManager.World.GetInstantNotifications().AddWalkThroughAbyss();
					}
					else if (blockConfig.SubType == EMapBlockSubType.Ruin && IsAnyGroupCharEquippingCarrier())
					{
						DomainManager.World.GetInstantNotifications().AddWalkThroughErosionBlock();
					}
				}
				if (currentBlockData.Destroyed && IsAnyGroupCharEquippingCarrier())
				{
					DomainManager.World.GetInstantNotifications().AddWalkThroughDestroyBlock();
				}
			}
		}
		DomainManager.Character.UpdateFollowMovementCharacters(context);
		RefreshTaiwuMoveRecord(previous);
		DomainManager.TaiwuEvent.OnEvent_TaiwuBlockChanged(previous, current);
	}

	private void RefreshTaiwuMoveRecord(Location previous)
	{
		_taiwuMoveRecord.Enqueue(previous);
		while (_taiwuMoveRecord.Count > 3)
		{
			_taiwuMoveRecord.Dequeue();
		}
	}

	public void ClearTaiwuMoveRecord()
	{
		_taiwuMoveRecord.Clear();
	}

	public Queue<Location> GetTaiwuMoveRecord()
	{
		return _taiwuMoveRecord;
	}

	[DomainMethod]
	public bool IsContinuousMovingBreak()
	{
		return DomainManager.TaiwuEvent.IsShowingEvent || DomainManager.TaiwuEvent.GetHasListeningEvent();
	}

	[DomainMethod]
	public MapHealSimulateResult SimulateHealCost(int typeInt, int doctorId, int patientId, bool needPay = false, bool isExpensiveHeal = false)
	{
		if (GameData.Domains.Character.Character.AllHealActions.Contains((EHealActionType)typeInt))
		{
			return SimulateHealCost((EHealActionType)typeInt, doctorId, patientId, needPay, isExpensiveHeal);
		}
		Logger.Warn($"SimulateHealCost by invalid type {typeInt}");
		return default(MapHealSimulateResult);
	}

	[DomainMethod]
	public bool HealOnMap(DataContext context, int typeInt, int doctorId, int patientId, bool needPay = false, int payerId = -1, bool isExpensiveHeal = false)
	{
		if (GameData.Domains.Character.Character.AllHealActions.Contains((EHealActionType)typeInt))
		{
			return HealOnMap(context, (EHealActionType)typeInt, doctorId, patientId, needPay, payerId, isExpensiveHeal);
		}
		Logger.Warn($"HealOnMap by invalid type {typeInt}");
		return false;
	}

	private void ReduceCharCarrierDurability(DataContext context, int charId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		foreach (ItemKey carrier in character.GetValidCarrierEquipment())
		{
			int reduceDurability = -context.Random.Next(GlobalConfig.CarrierDurationReduceOnRuinBlock[0], GlobalConfig.CarrierDurationReduceOnRuinBlock[1]);
			ItemBase baseItem = DomainManager.Item.GetBaseItem(carrier);
			short currDurability = baseItem.GetCurrDurability();
			short durability = (short)Math.Clamp(reduceDurability + currDurability, 0, baseItem.GetMaxDurability());
			baseItem.SetCurrDurability(durability, context);
		}
	}

	private bool IsAnyGroupCharEquippingCarrier()
	{
		return DomainManager.Taiwu.GetGroupCharIds().GetCollection().SelectMany((int charId) => DomainManager.Character.GetElement_Objects(charId).GetValidCarrierEquipment())
			.Any();
	}

	private MapHealSimulateResult SimulateHealCost(EHealActionType type, int doctorId, int patientId, bool needPay = false, bool isExpensiveHeal = false)
	{
		GameData.Domains.Character.Character doctorChar = DomainManager.Character.GetElement_Objects(doctorId);
		GameData.Domains.Character.Character patientChar = DomainManager.Character.GetElement_Objects(patientId);
		int maxRequireAttainment;
		int healEffect = doctorChar.CalcHealEffect(type, patientChar, out maxRequireAttainment, isExpensiveHeal ? 100 : 0);
		int costHerb = patientChar.CalcHealCostHerb(type, isExpensiveHeal);
		int costMoney = (needPay ? patientChar.CalcHealCostMoney(type, doctorChar.GetBehaviorType(), isExpensiveHeal) : 0);
		int costSpiritualDebt = (isExpensiveHeal ? patientChar.CalcHealCostSpiritualDebt(type) : 0);
		return new MapHealSimulateResult(type, costHerb, costMoney, healEffect, costSpiritualDebt, maxRequireAttainment);
	}

	private bool HealOnMap(DataContext context, EHealActionType type, int doctorId, int patientId, bool needPay = false, int payerId = -1, bool isExpensiveHeal = false)
	{
		GameData.Domains.Character.Character doctorChar = DomainManager.Character.GetElement_Objects(doctorId);
		GameData.Domains.Character.Character patientChar = DomainManager.Character.GetElement_Objects(patientId);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (DomainManager.Character.GetUsableCombatResources(doctorId).Get(type) <= 0)
		{
			Logger.Warn("Heal count not enough");
			return false;
		}
		int costHerb = patientChar.CalcHealCostHerb(type, isExpensiveHeal);
		if (taiwuChar.GetResource(5) < costHerb)
		{
			Logger.Warn($"Herb not enough. need {costHerb}, has {taiwuChar.GetResource(5)}");
			return false;
		}
		int costMoney = (needPay ? patientChar.CalcHealCostMoney(type, doctorChar.GetBehaviorType(), isExpensiveHeal) : 0);
		if (costMoney > 0 && taiwuChar.GetResource(6) < costMoney)
		{
			Logger.Warn($"Money not enough. need {costMoney}, has {taiwuChar.GetResource(6)}");
			return false;
		}
		if (isExpensiveHeal)
		{
			GameData.Domains.Character.Character doctor = DomainManager.Character.GetElement_Objects(doctorId);
			Settlement settlement = DomainManager.Organization.GetSettlement(doctor.GetOrganizationInfo().SettlementId);
			if (settlement == null)
			{
				Logger.Warn($"DoctorId:{doctorId}, Settlement  is null");
				return false;
			}
			int costSpiritualDebt = patientChar.CalcHealCostSpiritualDebt(type);
			DomainManager.Extra.ChangeAreaSpiritualDebt(context, settlement.GetLocation().AreaId, -costSpiritualDebt);
		}
		if (DomainManager.World.GetLeftDaysInCurrMonth() == 0)
		{
			Logger.Warn("Time not enough to heal");
			return false;
		}
		DomainManager.Character.UseCombatResources(context, doctorId, type, 1);
		if (costHerb > 0)
		{
			taiwuChar.ChangeResource(context, 5, -costHerb);
		}
		if (costMoney > 0)
		{
			taiwuChar.ChangeResource(context, 6, -costMoney);
			doctorChar.ChangeResource(context, 6, costMoney);
		}
		DomainManager.World.AdvanceDaysInMonth(context, 1);
		doctorChar.DoHealAction(context, type, patientChar, doctorId == DomainManager.Taiwu.GetTaiwuCharId(), isExpensiveHeal ? 100 : 0);
		return true;
	}

	public void UpdateIsTaiwuInFulongFlameArea(DataContext context)
	{
		if (!IsLocationInFulongFlameArea(DomainManager.Taiwu.GetTaiwu().GetLocation()))
		{
			if (_isTaiwuInFulongFlameArea)
			{
				_isTaiwuInFulongFlameArea = false;
				SetIsTaiwuInFulongFlameArea(_isTaiwuInFulongFlameArea, context);
			}
		}
		else if (!_isTaiwuInFulongFlameArea)
		{
			_canTriggerFulongFlameTeammateBubble = true;
			_isTaiwuInFulongFlameArea = true;
			SetIsTaiwuInFulongFlameArea(_isTaiwuInFulongFlameArea, context);
		}
	}

	public void SetTeleportMove(bool teleport)
	{
		_teleportMove = teleport;
	}

	public int GetTaiwuViewRange(MapBlockData blockData)
	{
		int viewRange = blockData.GetConfig().ViewRange;
		if (DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(45))
		{
			viewRange += DomainManager.Extra.GetProfessionData(11).GetSeniorityVisionRangeBonus();
		}
		return viewRange;
	}

	public void SetBlockAndViewRangeVisibleByMove(DataContext context, MapBlockData blockData)
	{
		List<MapBlockData> areaInvisibleBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		areaInvisibleBlocks.Clear();
		Span<MapBlockData> areaBlocks = GetAreaBlocks(blockData.AreaId);
		for (int i = 0; i < areaBlocks.Length; i++)
		{
			MapBlockData block = areaBlocks[i];
			if (!block.Visible)
			{
				areaInvisibleBlocks.Add(block);
			}
		}
		int viewRange = GetTaiwuViewRange(blockData);
		SetBlockAndNeighborVisible(context, blockData, viewRange);
		MapBlockData targetRootBlock = blockData.GetRootBlock();
		if (targetRootBlock.IsCityTown())
		{
			int settlementIndex = _areas[blockData.AreaId].GetSettlementIndex(targetRootBlock.BlockId);
			if (settlementIndex >= 0)
			{
				short settlementId = _areas[blockData.AreaId].SettlementInfos[settlementIndex].SettlementId;
				if (DomainManager.Taiwu.TryAddVisitedSettlement(settlementId, context))
				{
					GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.PlayAudioCommand, "ui_adventure_change", arg2: false, arg3: false);
				}
			}
		}
		else if (targetRootBlock.GetConfig().Size == 2)
		{
			Location location = targetRootBlock.GetLocation();
			if (_arrivedSize2Blocks.TryAdd(location, default(VoidValue)))
			{
				GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.PlayAudioCommand, "ui_adventure_change", arg2: false, arg3: false);
			}
		}
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(11);
		TravelerSkillsData skillsData = professionData.GetSkillsData<TravelerSkillsData>();
		bool changed = false;
		foreach (MapBlockData block2 in areaInvisibleBlocks)
		{
			if (block2.Visible)
			{
				int addSeniority = skillsData.RecordExploredMapBlock(block2.GetConfig().MoveCost * 10);
				if (addSeniority > 0)
				{
					DomainManager.Extra.ChangeProfessionSeniority(context, 11, addSeniority);
					changed = false;
				}
				else
				{
					changed = true;
				}
			}
		}
		if (changed)
		{
			DomainManager.Extra.SetProfessionData(context, professionData);
			DomainManager.Global.InvokeGuidingTrigger(context, 226);
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(areaInvisibleBlocks);
	}

	public void SetBlockAndViewRangeVisible(DataContext context, short areaId, short blockId)
	{
		MapBlockData block = GetBlock(areaId, blockId);
		SetBlockAndNeighborVisible(context, block, block.GetConfig().ViewRange);
	}

	public void SetBlockAndNeighborVisible(DataContext context, MapBlockData block, int range)
	{
		if (!block.Visible)
		{
			block.SetVisible(visible: true, context);
		}
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		GetNeighborBlocks(block.AreaId, block.BlockId, neighborBlocks, range);
		for (int i = 0; i < neighborBlocks.Count; i++)
		{
			MapBlockData neighborBlock = neighborBlocks[i];
			if (!neighborBlock.Visible)
			{
				neighborBlock.SetVisible(visible: true, context);
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
	}

	[Obsolete]
	[DomainMethod]
	public TeammateBubbleCollection GetTeammateBubbleCollection(DataContext context, bool isTraveling)
	{
		TeammateBubbleCollection collection;
		return (DomainManager.Adventure.GetAdventureTaiwu().NotInAdventure && DomainManager.Adventure.GetAdventureMajorEventTaiwu().NotInAdventure && TryUpdateTeammateTypes() && TryGetTeammateBubbleCollection(context, isTraveling, out collection)) ? collection : null;
	}

	[DomainMethod]
	public TransferableRecordDataBase GetReversedTeammateBubble(DataContext context, bool isTraveling)
	{
		TransferablePureData data = new TransferablePureData();
		if (!DomainManager.Adventure.GetAdventureTaiwu().NotInAdventure || !DomainManager.Adventure.GetAdventureMajorEventTaiwu().NotInAdventure || !TryUpdateTeammateTypes() || !TryGetTeammateBubbleCollection(context, isTraveling, out var collection))
		{
			return data;
		}
		collection.ReadTeammateBubbleWithNormalOrder(data, GetParameters);
		LifeRecordDomain.PostProcess(data);
		return data;
		static string[] GetParameters(int recordType)
		{
			TeammateBubbleItem config = Config.TeammateBubble.Instance[recordType];
			if (config != null)
			{
				return config.Parameters ?? Array.Empty<string>();
			}
			AdaptableLog.Warning($"Unable to render TeammateBubble with template id {recordType}");
			return null;
		}
	}

	public bool IsTeammateBubbleAbleToDisplayByTeammateTypes(short templateId)
	{
		return (_availableBubbleCache[templateId] & _teammateTypes) != 0;
	}

	public (int charId, int index, int subtype) GetSelectedBubbleBestMatchTeammate(short templateId)
	{
		(int, int, int) res = (-1, -1, -1);
		sbyte personalityType = Config.TeammateBubble.Instance[templateId].PersonalityType;
		int prevPriority = -1;
		int prevPersonality = -1;
		_teammateHighestPriorityText.Clear();
		foreach (var teammate in _teammates)
		{
			if (!IsTeammateAbleToDisplayBubble(teammate.charId))
			{
				continue;
			}
			for (int subtype = 0; subtype < 13; subtype++)
			{
				int mask = 1 << subtype;
				if ((mask & _availableBubbleCache[templateId]) != 0 && (mask & teammate.subtype) != 0)
				{
					_teammateHighestPriorityText.Add((teammate.charId, teammate.index, subtype));
				}
			}
		}
		foreach (var teammate2 in _teammateHighestPriorityText)
		{
			int currPriority = TeammateBubbleSubType.GetPriority(teammate2.subtype);
			sbyte currPersonality = DomainManager.Character.GetElement_Objects(teammate2.charId).GetPersonality(personalityType);
			if (!GameData.Domains.Character.Character.IsCharacterIdValid(res.Item1) || prevPriority < currPriority || (prevPriority == currPriority && prevPersonality < currPersonality))
			{
				res = teammate2;
				prevPersonality = currPersonality;
				prevPriority = currPriority;
			}
		}
		return res;
	}

	public bool TryUpdateTeammateTypes()
	{
		if (GetTeammateCount() == 0)
		{
			return false;
		}
		if (_lastTaiwuLocation == DomainManager.Taiwu.GetTaiwu().GetValidLocation())
		{
			return false;
		}
		_teammateTypes = 0;
		foreach (var teammate in _teammates)
		{
			if (IsTeammateAbleToDisplayBubble(teammate.charId))
			{
				_teammateTypes |= teammate.subtype;
			}
		}
		return true;
	}

	public bool TryGetTeammateBubbleCollection(DataContext context, bool isTraveling, out TeammateBubbleCollection collection)
	{
		Location location = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		Settlement settlement = DomainManager.Organization.GetSettlementByLocation(location);
		MapBlockData mapBlock = DomainManager.Map.GetBlock(location);
		IAdventureRuntime runtime;
		int adventureId = (DomainManager.Adventure.QueryAnyFirstOrDefault(location, out runtime) ? runtime.CoreId : (-1));
		collection = new TeammateBubbleCollection();
		if (isTraveling)
		{
			return TryGetTravelingBubble(location.AreaId, collection);
		}
		for (ETeammateBubbleBubbleElementType type = ETeammateBubbleBubbleElementType.Lost; type < ETeammateBubbleBubbleElementType.Count; type++)
		{
			switch (type)
			{
			case ETeammateBubbleBubbleElementType.Lost:
				if (TryGetDreamBackBubble(location, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.Story:
				if (TryGetStoryBubble(adventureId, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.StoryMapblockEffect:
				if (TryGetStoryMapBlockEffectBubble(location, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.Queerbook:
				if (TryGetLegendaryBookBubble(adventureId, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.Chicken:
				if (TryGetChickenBubble(settlement, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.SectCombatMatch:
				if (TryGetSectCombatMatchBubble(adventureId, mapBlock.TemplateId, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.Treasure:
				if (TryGetMaterialResourceBubble(adventureId, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.RelatedCharacter:
				if (TryGetRelatedCharacterBubble(mapBlock, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.Infected:
				if (TryGetInfectedCharacterBubble(mapBlock, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.LegendaryBookInsane:
				if (TryGetLegendaryBookInsaneCharacterBubble(mapBlock, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.Grave:
				if (TryGetNonEnemyGraveBubble(mapBlock, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.SectLeader:
				if (TryGetSectLeaderBubble(mapBlock, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.DestroyedArea:
				if (TryGetBrokenAreaBubble(location.AreaId, mapBlock.TemplateId, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.Animal:
				if (TryGetAnimalCharacterBubble(location, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.Caravan:
				if (TryGetCaravanCharacterBubble(collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.SwordGrave:
				if (TryGetSwordTombBubble(adventureId, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.SettlementAdventure:
				if (TryGetSettlementAdventureBubble(adventureId, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.TaiwuVillage:
				if (TryGetTaiwuVillageBubble(mapBlock.TemplateId, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.Organization:
				if (TryGetOrganizationBubble(mapBlock.TemplateId, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.City:
				if (TryGetCityBubble(mapBlock.TemplateId, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.Village:
				if (TryGetVillageBubble(mapBlock.TemplateId, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.EnemyNest:
				if (TryGetEnemyNestBubble(adventureId, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.Worker:
				if (TryGetWorkerBubble(location, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.Cricket:
				if (TryGetCricketBubble(context, location, collection))
				{
					return true;
				}
				break;
			case ETeammateBubbleBubbleElementType.SummerCombatMatch:
				if (TryGetCombatMatchBubble(adventureId, collection))
				{
					return true;
				}
				break;
			}
		}
		return false;
	}

	private void InitializeTeammateBubble()
	{
		_lastTaiwuLocation = Location.Invalid;
		_availableBubbleCache.Clear();
		_elementTypeBubbleCache.Clear();
		foreach (TeammateBubbleItem item in (IEnumerable<TeammateBubbleItem>)Config.TeammateBubble.Instance)
		{
			if (!_elementTypeBubbleCache.ContainsKey(item.BubbleElementType))
			{
				_elementTypeBubbleCache.Add(item.BubbleElementType, new HashSet<short>());
			}
			_elementTypeBubbleCache[item.BubbleElementType].Add(item.TemplateId);
			_availableBubbleCache[item.TemplateId] = 0;
			if (!string.IsNullOrEmpty(item.SpecialDesc0))
			{
				_availableBubbleCache[item.TemplateId] |= 1;
			}
			if (!string.IsNullOrEmpty(item.SpecialDesc1))
			{
				_availableBubbleCache[item.TemplateId] |= 2;
			}
			if (!string.IsNullOrEmpty(item.SpecialDesc2))
			{
				_availableBubbleCache[item.TemplateId] |= 4;
			}
			if (!string.IsNullOrEmpty(item.SpecialDesc3))
			{
				_availableBubbleCache[item.TemplateId] |= 8;
			}
			if (!string.IsNullOrEmpty(item.SpecialDesc4))
			{
				_availableBubbleCache[item.TemplateId] |= 16;
			}
			if (item.Cricket != null && item.Cricket.Length != 0)
			{
				bool canUse = true;
				string[] cricket = item.Cricket;
				foreach (string str in cricket)
				{
					if (string.IsNullOrEmpty(str))
					{
						canUse = false;
						break;
					}
				}
				if (canUse)
				{
					_availableBubbleCache[item.TemplateId] |= 32;
				}
			}
			if (!string.IsNullOrEmpty(item.FamilyDesc))
			{
				_availableBubbleCache[item.TemplateId] |= 64;
			}
			if (!string.IsNullOrEmpty(item.FriendDesc))
			{
				_availableBubbleCache[item.TemplateId] |= 128;
			}
			if (!string.IsNullOrEmpty(item.BehaviorDesc[0]))
			{
				_availableBubbleCache[item.TemplateId] |= 256;
			}
			if (!string.IsNullOrEmpty(item.BehaviorDesc[1]))
			{
				_availableBubbleCache[item.TemplateId] |= 512;
			}
			if (!string.IsNullOrEmpty(item.BehaviorDesc[2]))
			{
				_availableBubbleCache[item.TemplateId] |= 1024;
			}
			if (!string.IsNullOrEmpty(item.BehaviorDesc[3]))
			{
				_availableBubbleCache[item.TemplateId] |= 2048;
			}
			if (!string.IsNullOrEmpty(item.BehaviorDesc[4]))
			{
				_availableBubbleCache[item.TemplateId] |= 4096;
			}
		}
		UpdateTeammateBubbleData();
		for (int index = 0; index < 3; index++)
		{
			GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(new DataUid(5, 32, (ulong)index), "UpdateTeammateBubbleData", UpdateTeammateBubbleData);
		}
	}

	private void UpdateTeammateBubbleData(DataContext context, DataUid uid)
	{
		UpdateTeammateBubbleData();
	}

	public void UpdateTeammateBubbleData()
	{
		_teammates.Clear();
		CharacterSet groupChars = DomainManager.Taiwu.GetGroupCharIds();
		for (int i = 0; i < 3; i++)
		{
			int charId = DomainManager.Taiwu.GetElement_CombatGroupCharIds(i);
			if (charId >= 0 && groupChars.Contains(charId))
			{
				_teammates.Add((charId, i, GetTeammateType(charId)));
			}
		}
	}

	private int GetTeammateHighestPriority(int charId)
	{
		int res = 0;
		int teammateType = 0;
		foreach (var teammate in _teammates)
		{
			if (teammate.charId == charId)
			{
				teammateType = teammate.subtype;
				break;
			}
		}
		for (int i = 0; i < 13; i++)
		{
			if ((teammateType & (1 << i)) != 0)
			{
				res = Math.Max(res, TeammateBubbleSubType.GetPriority(i));
			}
		}
		return res;
	}

	private int GetTeammateType(int charId)
	{
		int res = 0;
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		if (character.GetFeatureIds().Contains(685))
		{
			res |= 1;
		}
		short templateId = character.GetTemplateId();
		if (templateId == 520)
		{
			res |= 2;
		}
		if (templateId == 519)
		{
			res |= 4;
		}
		if (templateId == 522)
		{
			res |= 8;
		}
		if (templateId == 521)
		{
			res |= 0x10;
		}
		if (templateId >= 968 && templateId <= 1011)
		{
			res |= 0x20;
		}
		if (!DomainManager.Character.TryGetRelation(charId, DomainManager.Taiwu.GetTaiwuCharId(), out var relation))
		{
			return 0;
		}
		ushort relationType = relation.RelationType;
		if (RelationType.IsFamilyRelation(relationType))
		{
			res |= 0x40;
		}
		if (RelationType.IsFriendRelation(relationType))
		{
			res |= 0x80;
		}
		switch (character.GetBehaviorType())
		{
		case 0:
			res |= 0x100;
			break;
		case 1:
			res |= 0x200;
			break;
		case 2:
			res |= 0x400;
			break;
		case 3:
			res |= 0x800;
			break;
		case 4:
			res |= 0x1000;
			break;
		}
		return res;
	}

	private int GetTeammateCount()
	{
		return _teammates.Count;
	}

	private bool IsTeammateAbleToDisplayBubble(int charId)
	{
		return GetTeammateCount() == 1 || _lastTeammateBubble.charId != charId || _lastTeammateBubble.count < 2;
	}

	private void SetLastTeammateBubble(int charId)
	{
		_lastTeammateBubble = ((_lastTeammateBubble.charId == charId) ? (charId: charId, count: _lastTeammateBubble.count + 1) : (charId: charId, count: 1));
		_lastTaiwuLocation = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
	}

	private void ApplyTeammateBubble(short templateId, TeammateBubbleCollection collection)
	{
		(int, int, int) teammate = GetSelectedBubbleBestMatchTeammate(templateId);
		collection.AddNoneParameterBubble(Config.TeammateBubble.Instance[templateId], teammate.Item2, teammate.Item3);
		SetLastTeammateBubble(teammate.Item1);
	}

	private void ApplySwordTombBubble(short templateId, TeammateBubbleCollection collection)
	{
		(int, int, int) teammate = GetSelectedBubbleBestMatchTeammate(templateId);
		short charTemplateId = DomainManager.Character.GetElement_Objects(teammate.Item1).GetTemplateId();
		collection.AddSingleCharacterTemplateNoneParameterBubble(Config.TeammateBubble.Instance[templateId], teammate.Item2, teammate.Item3, charTemplateId);
		SetLastTeammateBubble(teammate.Item1);
	}

	private void ApplyAdventureTeammateBubble(short templateId, TeammateBubbleCollection collection, int adventureId)
	{
		(int, int, int) teammate = GetSelectedBubbleBestMatchTeammate(templateId);
		collection.AddAdventureParameterBubble(Config.TeammateBubble.Instance[templateId], teammate.Item2, teammate.Item3, adventureId);
		SetLastTeammateBubble(teammate.Item1);
	}

	private void ApplyCombatMatchTeammateBubble(short templateId, TeammateBubbleCollection collection, sbyte type)
	{
		(int, int, int) teammate = GetSelectedBubbleBestMatchTeammate(templateId);
		collection.AddSingleCombatSkillTypeParameterBubble(Config.TeammateBubble.Instance[templateId], teammate.Item2, teammate.Item3, type);
		SetLastTeammateBubble(teammate.Item1);
	}

	private void ApplyIdentityTeammateBubble(short templateId, TeammateBubbleCollection collection, int type)
	{
		(int, int, int) teammate = GetSelectedBubbleBestMatchTeammate(templateId);
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(type);
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		sbyte gender = character.GetGender();
		collection.AddCharacterIdentityBubble(Config.TeammateBubble.Instance[templateId], teammate.Item2, teammate.Item3, type, orgInfo, gender);
		SetLastTeammateBubble(teammate.Item1);
	}

	private bool TryGetBrokenAreaBubble(short areaId, short mapBlockTemplateId, TeammateBubbleCollection collection)
	{
		if (MapAreaData.IsBrokenArea(areaId) && mapBlockTemplateId == 38 && IsTeammateBubbleAbleToDisplayByTeammateTypes(187))
		{
			ApplyTeammateBubble(187, collection);
			return true;
		}
		return false;
	}

	private bool TryGetTravelingBubble(short areaId, TeammateBubbleCollection collection)
	{
		sbyte stateId = DomainManager.Map.GetStateTemplateIdByAreaId(areaId);
		if (_lastTaiwuLocation != Location.Invalid && DomainManager.Map.GetStateTemplateIdByAreaId(_lastTaiwuLocation.AreaId) == stateId)
		{
			return false;
		}
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.Traveling])
		{
			if (IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (config.MapStateTemplateId == stateId)
				{
					ApplyTeammateBubble(templateId, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetDreamBackBubble(Location location, TeammateBubbleCollection collection)
	{
		List<DreamBackLocationData> dataList = DomainManager.Extra.GetDreamBackLocationData();
		if (dataList == null || dataList.Count == 0)
		{
			return false;
		}
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.Lost])
		{
			if (!IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				continue;
			}
			foreach (DreamBackLocationData item in dataList)
			{
				if (item.Location == location)
				{
					ApplyTeammateBubble(templateId, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetStoryBubble(int coreId, TeammateBubbleCollection collection)
	{
		if (coreId < 0)
		{
			return false;
		}
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.Story])
		{
			if (IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (config.AdventureTemplateIdList != null && config.AdventureTemplateIdList.Contains(coreId))
				{
					ApplyTeammateBubble(templateId, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetStoryMapBlockEffectBubble(Location location, TeammateBubbleCollection collection)
	{
		if (_canTriggerFulongFlameTeammateBubble)
		{
			ApplyTeammateBubble(188, collection);
			_canTriggerFulongFlameTeammateBubble = false;
			return true;
		}
		return false;
	}

	private bool TryGetLegendaryBookBubble(int coreId, TeammateBubbleCollection collection)
	{
		if (coreId < 0)
		{
			return false;
		}
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.Queerbook])
		{
			if (IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (config.AdventureTemplateIdList != null && config.AdventureTemplateIdList.Contains(coreId))
				{
					ApplyAdventureTeammateBubble(templateId, collection, coreId);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetChickenBubble(Settlement settlement, TeammateBubbleCollection collection)
	{
		if (settlement == null)
		{
			return false;
		}
		if (DomainManager.Building.TryGetFirstChickenInSettlement(settlement, out var _))
		{
			foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.Chicken])
			{
				if (!IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
				{
					continue;
				}
				ApplyTeammateBubble(templateId, collection);
				return true;
			}
		}
		return false;
	}

	private bool TryGetSectCombatMatchBubble(int coreId, short mapBlockTemplateId, TeammateBubbleCollection collection)
	{
		if (coreId != 213197576)
		{
			return false;
		}
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.SectCombatMatch])
		{
			if (IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (mapBlockTemplateId == config.MapBlockTemplateId)
				{
					ApplyTeammateBubble(templateId, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetMaterialResourceBubble(int coreId, TeammateBubbleCollection collection)
	{
		if (coreId < 0)
		{
			return false;
		}
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.Treasure])
		{
			if (IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (config.AdventureTemplateIdList != null && config.AdventureTemplateIdList.Contains(coreId))
				{
					ApplyTeammateBubble(templateId, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetSwordTombBubble(int coreId, TeammateBubbleCollection collection)
	{
		if (coreId < 0)
		{
			return false;
		}
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.SwordGrave])
		{
			if (IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (config.AdventureTemplateIdList != null && config.AdventureTemplateIdList.Contains(coreId))
				{
					ApplySwordTombBubble(templateId, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetSettlementAdventureBubble(int coreId, TeammateBubbleCollection collection)
	{
		if (coreId < 0)
		{
			return false;
		}
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.SettlementAdventure])
		{
			if (IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (config.AdventureTemplateIdList != null && config.AdventureTemplateIdList.Contains(coreId))
				{
					ApplyTeammateBubble(templateId, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetCombatMatchBubble(int coreId, TeammateBubbleCollection collection)
	{
		if (coreId < 0)
		{
			return false;
		}
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.SummerCombatMatch])
		{
			if (!IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				continue;
			}
			TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
			if (config == null)
			{
				return false;
			}
			if (config.AdventureTemplateIdList == null || !config.AdventureTemplateIdList.Contains(coreId))
			{
				continue;
			}
			foreach (CombatSkillTypeItem skillType in (IEnumerable<CombatSkillTypeItem>)CombatSkillType.Instance)
			{
				if (skillType.CombatMatchAdventure != coreId)
				{
					continue;
				}
				ApplyCombatMatchTeammateBubble(templateId, collection, skillType.TemplateId);
				return true;
			}
		}
		return false;
	}

	private bool TryGetTaiwuVillageBubble(short mapBlockTemplateId, TeammateBubbleCollection collection)
	{
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.TaiwuVillage])
		{
			if (IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (mapBlockTemplateId == config.MapBlockTemplateId)
				{
					ApplyTeammateBubble(templateId, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetOrganizationBubble(short mapBlockTemplateId, TeammateBubbleCollection collection)
	{
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.Organization])
		{
			if (IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (mapBlockTemplateId == config.MapBlockTemplateId)
				{
					ApplyTeammateBubble(templateId, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetCityBubble(short mapBlockTemplateId, TeammateBubbleCollection collection)
	{
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.City])
		{
			if (IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (mapBlockTemplateId == config.MapBlockTemplateId)
				{
					ApplyTeammateBubble(templateId, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetVillageBubble(short mapBlockTemplateId, TeammateBubbleCollection collection)
	{
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.Village])
		{
			if (IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (mapBlockTemplateId == config.MapBlockTemplateId)
				{
					ApplyTeammateBubble(templateId, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetEnemyNestBubble(int coreId, TeammateBubbleCollection collection)
	{
		if (coreId < 0)
		{
			return false;
		}
		foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.EnemyNest])
		{
			if (IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (config.AdventureTemplateIdList != null && config.AdventureTemplateIdList.Contains(coreId))
				{
					ApplyTeammateBubble(templateId, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetWorkerBubble(Location location, TeammateBubbleCollection collection)
	{
		if (DomainManager.Taiwu.TryGetElement_VillagerWorkLocations(location, out var _))
		{
			foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.Worker])
			{
				if (!IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
				{
					continue;
				}
				ApplyTeammateBubble(templateId, collection);
				return true;
			}
		}
		return false;
	}

	private bool TryGetCricketBubble(DataContext context, Location location, TeammateBubbleCollection collection)
	{
		if (DomainManager.Map.LocationHasCricket(context, location))
		{
			foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.Cricket])
			{
				if (!IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
				{
					continue;
				}
				ApplyTeammateBubble(templateId, collection);
				return true;
			}
		}
		return false;
	}

	private bool TryGetAnimalCharacterBubble(Location location, TeammateBubbleCollection collection)
	{
		if (DomainManager.Extra.TryGetAnimalIdsByLocation(location, out var animals) && animals.Count > 0 && DomainManager.Extra.TryGetAnimal(animals[0], out var animal))
		{
			short templateId = (short)((animal.ItemKey == ItemKey.Invalid) ? 155 : 156);
			if (!IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
			{
				return false;
			}
			ApplyTeammateBubble(templateId, collection);
			return true;
		}
		return false;
	}

	private bool TryGetCaravanCharacterBubble(TeammateBubbleCollection collection)
	{
		if (DomainManager.Merchant.TryGetFirstTaiwuLocationCaravanId(out var _))
		{
			foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.Caravan])
			{
				if (!IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
				{
					continue;
				}
				ApplyTeammateBubble(templateId, collection);
				return true;
			}
		}
		return false;
	}

	private bool TryGetRelatedCharacterBubble(MapBlockData block, TeammateBubbleCollection collection)
	{
		if (block.CharacterSet == null || block.CharacterSet.Count == 0)
		{
			return false;
		}
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		foreach (int id in block.CharacterSet)
		{
			if (!DomainManager.Character.TryGetRelation(id, taiwuId, out var relation))
			{
				continue;
			}
			ushort relationType = relation.RelationType;
			if (RelationType.IsFamilyRelation(relationType))
			{
				if (IsTeammateBubbleAbleToDisplayByTeammateTypes(158))
				{
					ApplyTeammateBubble(158, collection);
					return true;
				}
			}
			else if (RelationType.IsFriendRelation(relationType))
			{
				if (IsTeammateBubbleAbleToDisplayByTeammateTypes(159))
				{
					ApplyTeammateBubble(159, collection);
					return true;
				}
			}
			else if ((0x8000 & relationType) != 0 && IsTeammateBubbleAbleToDisplayByTeammateTypes(160))
			{
				ApplyTeammateBubble(160, collection);
				return true;
			}
		}
		return false;
	}

	private bool TryGetInfectedCharacterBubble(MapBlockData block, TeammateBubbleCollection collection)
	{
		if (block.InfectedCharacterSet == null || block.InfectedCharacterSet.Count == 0)
		{
			return false;
		}
		foreach (int id in block.InfectedCharacterSet)
		{
			if (!DomainManager.Character.TryGetElement_Objects(id, out var character))
			{
				continue;
			}
			List<short> features = character.GetFeatureIds();
			foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.Infected])
			{
				if (!IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
				{
					continue;
				}
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (config.CharacterFeatureTemplateIdList == null)
				{
					continue;
				}
				foreach (short featureId in config.CharacterFeatureTemplateIdList)
				{
					if (features.Contains(featureId))
					{
						ApplyTeammateBubble(templateId, collection);
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool TryGetLegendaryBookInsaneCharacterBubble(MapBlockData block, TeammateBubbleCollection collection)
	{
		if (block.InfectedCharacterSet == null || block.InfectedCharacterSet.Count == 0)
		{
			return false;
		}
		foreach (int id in block.InfectedCharacterSet)
		{
			if (!DomainManager.Character.TryGetElement_Objects(id, out var character))
			{
				continue;
			}
			List<sbyte> types = DomainManager.LegendaryBook.GetCharOwnedBookTypes(id);
			if (types == null)
			{
				continue;
			}
			List<short> features = character.GetFeatureIds();
			if (features.Contains(214))
			{
				if (IsTeammateBubbleAbleToDisplayByTeammateTypes(165))
				{
					ApplyTeammateBubble(165, collection);
					return true;
				}
			}
			else if (features.Contains(215) && IsTeammateBubbleAbleToDisplayByTeammateTypes(166))
			{
				ApplyTeammateBubble(166, collection);
				return true;
			}
		}
		return false;
	}

	private bool TryGetNonEnemyGraveBubble(MapBlockData block, TeammateBubbleCollection collection)
	{
		if (block.GraveSet == null || block.GraveSet.Count == 0)
		{
			return false;
		}
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		foreach (int id in block.GraveSet)
		{
			if (DomainManager.Character.TryGetRelation(id, taiwuId, out var relation))
			{
				ushort relationType = relation.RelationType;
				if ((0x8000 & relationType) == 0 && IsTeammateBubbleAbleToDisplayByTeammateTypes(167))
				{
					ApplyTeammateBubble(167, collection);
					return true;
				}
			}
		}
		return false;
	}

	private bool TryGetSectLeaderBubble(MapBlockData block, TeammateBubbleCollection collection)
	{
		if (block.CharacterSet == null || block.CharacterSet.Count == 0)
		{
			return false;
		}
		foreach (int id in block.CharacterSet)
		{
			if (!DomainManager.Character.TryGetElement_Objects(id, out var character))
			{
				continue;
			}
			List<short> features = character.GetFeatureIds();
			foreach (short templateId in _elementTypeBubbleCache[ETeammateBubbleBubbleElementType.SectLeader])
			{
				if (!IsTeammateBubbleAbleToDisplayByTeammateTypes(templateId))
				{
					continue;
				}
				TeammateBubbleItem config = Config.TeammateBubble.Instance[templateId];
				if (config.CharacterFeatureTemplateIdList == null)
				{
					continue;
				}
				foreach (short featureId in config.CharacterFeatureTemplateIdList)
				{
					if (features.Contains(featureId))
					{
						ApplyIdentityTeammateBubble(templateId, collection, id);
						return true;
					}
				}
			}
		}
		return false;
	}

	public static sbyte GetSectOrgTemplateIdByStateTemplateId(sbyte mapStateTemplateId)
	{
		return MapState.Instance[mapStateTemplateId].SectID;
	}

	public static short GetCharacterTemplateId(sbyte mapStateTemplateId, sbyte gender)
	{
		return MapState.Instance[mapStateTemplateId].TemplateCharacterIds[gender];
	}

	private void InitializeTravelMap()
	{
		_dijkstraMap.Initialize(GetAllAreaIds(), GetAreaNeighbors);
	}

	public bool StationUnlocked(short areaId)
	{
		return _areas[areaId].StationUnlocked;
	}

	[DomainMethod]
	public void UnlockStation(DataContext context, short areaId, bool costAuthority = true)
	{
		MapAreaData areaData = _areas[areaId];
		if (areaId >= 135)
		{
			throw new Exception($"Invalid area id {areaId}");
		}
		if (areaData.StationUnlocked)
		{
			throw new Exception($"Station of area {areaId} already unlocked");
		}
		int foundAreasCount = 0;
		for (short i = 0; i < 135; i++)
		{
			if (_areas[i].StationUnlocked)
			{
				foundAreasCount++;
			}
		}
		int activeUnlocked = foundAreasCount - 9 * GlobalConfig.Instance.MapInitUnlockStationStateCount + 1;
		if (costAuthority)
		{
			GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
			int needAuthority = Math.Max(GlobalConfig.Instance.MapAreaOpenPrestige * activeUnlocked, 0);
			if (taiwuChar.GetResource(7) < needAuthority)
			{
				throw new Exception($"Authority not enough to unlock station at area {areaId}, need {needAuthority}, have {taiwuChar.GetResource(7)}");
			}
			taiwuChar.ChangeResource(context, 7, -needAuthority);
			AddUnlockStationSeniority(context, needAuthority);
			Events.RaiseStationUnlocked(context);
		}
		DomainManager.World.RequestSetStat(context, 57, activeUnlocked);
		areaData.Discovered = true;
		areaData.StationUnlocked = true;
		SetElement_Areas(areaId, areaData, context);
		foreach (short neighborAreaId in areaData.NeighborAreas)
		{
			MapAreaData neighborArea = _areas[neighborAreaId];
			if (!neighborArea.Discovered)
			{
				neighborArea.Discovered = true;
				SetElement_Areas(neighborAreaId, neighborArea, context);
			}
		}
	}

	[DomainMethod]
	public void QuickTravel(DataContext context, short destAreaId)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		short destBlockId = GetPureTravelBlockId(context, destAreaId, taiwuChar.GetLocation().AreaId);
		Location arriveLocation = new Location(destAreaId, destBlockId);
		DomainManager.Taiwu.TaiwuGroupMove(context, arriveLocation);
		MapBlockData destBlock = GetBlock(arriveLocation);
		SetBlockAndViewRangeVisibleByMove(context, destBlock);
		DomainManager.Extra.GearMateFollowTaiwu(context);
	}

	[DomainMethod]
	public CrossAreaMoveInfo GetTravelCost(short fromAreaId, short fromBlockId, short toAreaId)
	{
		sbyte fromStateTemplateId = GetStateTemplateIdByAreaId(fromAreaId);
		CrossAreaMoveInfo moveInfo = new CrossAreaMoveInfo
		{
			FromAreaId = fromAreaId,
			FromBlockId = fromBlockId,
			ToAreaId = toAreaId
		};
		if (fromAreaId == toAreaId)
		{
			return moveInfo;
		}
		_carrierReduceTravelCostDaysPercent = CalcCarrierReduceTravelCostDaysPercent();
		_preferUnlockedTravelRoute = GlobalDomain.Settings.PreferUnlockedTravelRoute;
		if (toAreaId == 137 || fromAreaId == 137 || toAreaId == 138 || fromAreaId == 138 || toAreaId == 139 || fromAreaId == 139)
		{
			TravelRoute route = new TravelRoute();
			route.AreaList.Add(fromAreaId);
			route.AreaList.Add(toAreaId);
			sbyte[] pos = _areas[fromAreaId].GetConfig().WorldMapPos;
			route.PosList.Add(new ByteCoordinate((byte)pos[0], (byte)pos[1]));
			route.PosList.Add(new ByteCoordinate(0, 0));
			route.CostList.Add(0);
			route.CostList.Add(0);
			moveInfo.Route = route;
		}
		else
		{
			BuildTravelRoute(moveInfo, fromAreaId, toAreaId, _preferUnlockedTravelRoute);
		}
		moveInfo.MoneyCost = moveInfo.Route.GetTotalTimeCost() * MapState.Instance[fromStateTemplateId].TravalMoney * 5;
		int foundAreasCount = 0;
		for (short areaId = 0; areaId < 135; areaId++)
		{
			if (_areas[areaId].StationUnlocked)
			{
				foundAreasCount++;
			}
		}
		moveInfo.AuthorityCost = 0;
		for (int i = 0; i < moveInfo.Route.AreaList.Count; i++)
		{
			short areaId2 = moveInfo.Route.AreaList[i];
			if (!_areas[areaId2].StationUnlocked)
			{
				moveInfo.AuthorityCost += Math.Max(GlobalConfig.Instance.MapAreaOpenPrestige * (foundAreasCount - 9 * GlobalConfig.Instance.MapInitUnlockStationStateCount + 1), 0);
				foundAreasCount++;
			}
		}
		if (fromAreaId == 135 || fromAreaId == 138 || fromAreaId == 137 || toAreaId == 139 || fromAreaId == 139)
		{
			moveInfo.MoneyCost = 0;
			moveInfo.AuthorityCost = 0;
		}
		return moveInfo;
	}

	[DomainMethod]
	public TravelPreviewDisplayData GetTravelPreview(short toAreaId)
	{
		TravelPreviewDisplayData result = new TravelPreviewDisplayData
		{
			ToAreaId = -1
		};
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwuChar.GetLocation();
		if (!taiwuLocation.IsValid() || toAreaId == taiwuLocation.AreaId || toAreaId < 0)
		{
			return result;
		}
		result.ToAreaId = toAreaId;
		CrossAreaMoveInfo cost = GetTravelCost(taiwuLocation.AreaId, taiwuLocation.BlockId, toAreaId);
		result.AuthorityCost = cost.AuthorityCost;
		result.MoneyCost = cost.MoneyCost;
		result.DaysCost = ((IEnumerable<short>)cost.Route.CostList).Select((Func<short, int>)((short x) => x)).Sum();
		result.CurrentAuthority = taiwuChar.GetResource(7);
		if (result.AuthorityCost > 0)
		{
			result.NeedUnlockStations = new List<short>();
			foreach (short areaId in cost.Route.AreaList)
			{
				if (!_areas[areaId].StationUnlocked)
				{
					result.NeedUnlockStations.Add(areaId);
				}
			}
		}
		return result;
	}

	[DomainMethod]
	public bool UnlockTravelPath(DataContext context, short toAreaId)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwuChar.GetLocation();
		CrossAreaMoveInfo moveInfo = GetTravelCost(taiwuLocation.AreaId, taiwuLocation.BlockId, toAreaId);
		return moveInfo.AuthorityCost > 0 && UnlockTravelPathInternal(context, moveInfo);
	}

	private void BuildTravelRoute(CrossAreaMoveInfo moveInfo, short fromAreaId, short toAreaId, bool useActualCost)
	{
		IReadOnlyList<DijkstraAlgorithm<short>.IReadonlyDijkstraNode> shortestRoute = _dijkstraMap.FindShortestPath(fromAreaId, toAreaId);
		List<ByteCoordinate> tempRoutePos = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		TravelRoute route = (moveInfo.Route = new TravelRoute());
		route.AreaList.EnsureCapacity(shortestRoute.Count);
		route.CostList.EnsureCapacity(shortestRoute.Count);
		if (useActualCost)
		{
			short lastAreaId = fromAreaId;
			foreach (DijkstraAlgorithm<short>.IReadonlyDijkstraNode node in shortestRoute)
			{
				if (node.Pos != fromAreaId)
				{
					route.AreaList.Add(node.Pos);
					route.CostList.Add((short)GetAreaCostDays(lastAreaId, node.Pos));
					lastAreaId = node.Pos;
				}
			}
		}
		else
		{
			int cost = 0;
			foreach (DijkstraAlgorithm<short>.IReadonlyDijkstraNode node2 in shortestRoute)
			{
				if (node2.Pos != fromAreaId)
				{
					route.AreaList.Add(node2.Pos);
					route.CostList.Add((short)(node2.Cost / 1000 - cost));
					cost = node2.Cost / 1000;
				}
			}
		}
		for (int i = 0; i < route.AreaList.Count; i++)
		{
			short areaId = route.AreaList[i];
			short lastAreaId2 = ((i == 0) ? fromAreaId : route.AreaList[i - 1]);
			MapAreaItem lastArea = _areas[lastAreaId2].GetConfig();
			MapAreaItem nowArea = _areas[areaId].GetConfig();
			tempRoutePos.Clear();
			if (nowArea.TemplateId > lastArea.TemplateId)
			{
				AreaTravelRoute[] neighborAreas = lastArea.NeighborAreas;
				for (int j = 0; j < neighborAreas.Length; j++)
				{
					AreaTravelRoute neighborArea = neighborAreas[j];
					if (neighborArea.DestAreaId == nowArea.TemplateId)
					{
						tempRoutePos.AddRange(neighborArea.MapPosList);
						break;
					}
				}
			}
			else
			{
				AreaTravelRoute[] neighborAreas2 = nowArea.NeighborAreas;
				for (int k = 0; k < neighborAreas2.Length; k++)
				{
					AreaTravelRoute neighborArea2 = neighborAreas2[k];
					if (neighborArea2.DestAreaId == lastArea.TemplateId)
					{
						tempRoutePos.AddRange(neighborArea2.MapPosList);
						tempRoutePos.Reverse();
						break;
					}
				}
			}
			route.PosList.AddRange(tempRoutePos);
			if (areaId != toAreaId)
			{
				route.PosList.Add(new ByteCoordinate((byte)nowArea.WorldMapPos[0], (byte)nowArea.WorldMapPos[1]));
			}
		}
		ObjectPool<List<ByteCoordinate>>.Instance.Return(tempRoutePos);
	}

	[DomainMethod]
	public void StartTravel(DataContext context, short toAreaId)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwuChar.GetLocation();
		CrossAreaMoveInfo moveInfo = GetTravelCost(taiwuLocation.AreaId, taiwuLocation.BlockId, toAreaId);
		moveInfo.AutoCheckFreeTravel();
		if (!UnlockTravelPathInternal(context, moveInfo))
		{
			throw new Exception($"Authority not enough to travel to area {moveInfo.ToAreaId}, need {moveInfo.AuthorityCost}, have {taiwuChar.GetResource(7)}");
		}
		if (moveInfo.MoneyCost > 0)
		{
			taiwuChar.ChangeResource(context, 6, -moveInfo.MoneyCost);
		}
		StartTravelWithoutCost(context, moveInfo);
	}

	[DomainMethod]
	public void DirectTravelToTaiwuVillage(DataContext context)
	{
		StopTravel(context);
		short toAreaId = DomainManager.Taiwu.GetTaiwuVillageLocation().AreaId;
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwuChar.GetLocation();
		CrossAreaMoveInfo moveInfo = GetTravelCost(taiwuLocation.AreaId, taiwuLocation.BlockId, toAreaId);
		moveInfo.AutoCheckFreeTravel();
		if (moveInfo.MoneyCost > 0)
		{
			taiwuChar.ChangeResource(context, 6, -moveInfo.MoneyCost);
		}
		DirectTravel(context, moveInfo);
	}

	[DomainMethod]
	public bool ContinueTravel(DataContext context)
	{
		if (_travelInfo.Traveling && _travelInfo.CurrentAreaId == _travelInfo.ToAreaId)
		{
			FinishTravel(context, _travelInfo.ToAreaId);
			return false;
		}
		EnsureCostDays(context);
		int costDays = _travelInfo.NextCostDays;
		if (costDays == -1)
		{
			return false;
		}
		int actionPoints = DomainManager.Extra.GetTotalActionPointsRemaining();
		int cost = costDays * 10;
		int actualCost = Math.Min(cost, actionPoints);
		DomainManager.Extra.ConsumeActionPoint(context, actualCost);
		RecordTravelCostedDays(context, _travelInfo.CostedDays + actualCost / 10);
		if (actualCost < cost)
		{
			DomainManager.World.AdvanceMonth(context);
			return false;
		}
		int routeIndex = _travelInfo.RouteIndex;
		short fromAreaId = ((routeIndex == 0) ? _travelInfo.FromAreaId : _travelInfo.Route.AreaList[routeIndex - 1]);
		short toAreaId = _travelInfo.Route.AreaList[routeIndex];
		if (fromAreaId < 135)
		{
			List<(Location, short)> blockRoute = CalcBlockTravelRoute(context.Random, new Location(fromAreaId, _areas[fromAreaId].StationBlockId), new Location(toAreaId, _areas[toAreaId].StationBlockId), isMerchant: false);
			for (int i = 0; i < blockRoute.Count; i++)
			{
				Location location = blockRoute[i].Item1;
				SetBlockAndViewRangeVisible(context, location.AreaId, location.BlockId);
			}
		}
		else if (toAreaId != 137 && toAreaId != 138 && toAreaId != 139 && fromAreaId != 139)
		{
			SetBlockAndViewRangeVisible(context, toAreaId, _areas[toAreaId].StationBlockId);
		}
		return true;
	}

	[DomainMethod]
	public short ContinueTravelWithDetectTravelingEvent(DataContext context)
	{
		if (_travelInfo.Traveling && ContinueTravel(context))
		{
			return DetectTravelingEvent(context);
		}
		return -1;
	}

	[DomainMethod]
	public void RecordTravelCostedDays(DataContext context, int costedDays)
	{
		_travelInfo.CostedDays = costedDays;
		SetTravelInfo(_travelInfo, context);
	}

	[DomainMethod]
	public void StopTravel(DataContext context)
	{
		if (_travelInfo.Traveling)
		{
			FinishTravel(context, _travelInfo.CurrentAreaId);
		}
	}

	[DomainMethod]
	public void TaiwuBeKidnapped(DataContext context, Location targetLocation, int hunterCharId)
	{
		short areaId = targetLocation.AreaId;
		Tester.Assert(areaId >= 0 && areaId < 135);
		DomainManager.Map.StopTravel(context);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		if (taiwu.GetLocation().AreaId != targetLocation.AreaId)
		{
			KidnappedTravelData kidnappedData = new KidnappedTravelData
			{
				Target = targetLocation,
				HunterCharId = hunterCharId
			};
			DomainManager.Extra.SetKidnappedTravelData(kidnappedData, context);
			DirectTravel(context, targetLocation.AreaId);
		}
		else
		{
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OperateBlackMaskView, arg1: true, 1f, arg3: true);
			SetTeleportMove(teleport: true);
			Move(context, targetLocation.BlockId, notCostTime: true);
			SetTeleportMove(teleport: false);
			DomainManager.TaiwuEvent.OnEvent_TaiwuBeHuntedArrivedSect(hunterCharId);
		}
	}

	public void DirectTravel(DataContext context, short toAreaId)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwuChar.GetLocation();
		CrossAreaMoveInfo moveInfo = GetTravelCost(taiwuLocation.AreaId, taiwuLocation.BlockId, toAreaId);
		DirectTravel(context, moveInfo);
	}

	public void DirectTravel(DataContext context, CrossAreaMoveInfo moveInfo)
	{
		if (!DomainManager.Extra.GetIsDirectTraveling())
		{
			DomainManager.Extra.SetIsDirectTraveling(value: true, context);
		}
		StartTravelWithoutCost(context, moveInfo);
	}

	public void StartTravelWithoutCost(DataContext context, CrossAreaMoveInfo moveInfo)
	{
		if (_travelInfo.Traveling)
		{
			throw new Exception($"Last travel to area {_travelInfo.ToAreaId} is not finished");
		}
		SetTravelInfo(moveInfo, context);
		DomainManager.Taiwu.TaiwuGroupMove(context, Location.Invalid);
		DomainManager.Extra.GearMateFollowTaiwu(context);
	}

	public Location GetTravelCurrLocation()
	{
		if (_travelInfo.ToAreaId < 0)
		{
			throw new Exception("Taiwu is not travelling");
		}
		short areaId = _travelInfo.CurrentAreaId;
		Location result = new Location(areaId, _areas[areaId].StationBlockId);
		if (!result.IsValid())
		{
			result.AreaId = _travelInfo.FromAreaId;
			result.BlockId = _travelInfo.FromBlockId;
		}
		return result;
	}

	internal bool UnlockTravelPathInternal(DataContext context, CrossAreaMoveInfo moveInfo)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (moveInfo.AuthorityCost <= 0)
		{
			return true;
		}
		if (taiwuChar.GetResource(7) < moveInfo.AuthorityCost)
		{
			return false;
		}
		taiwuChar.ChangeResource(context, 7, -moveInfo.AuthorityCost);
		AddUnlockStationSeniority(context, moveInfo.AuthorityCost);
		for (int i = 0; i < moveInfo.Route.AreaList.Count; i++)
		{
			short areaId = moveInfo.Route.AreaList[i];
			if (!_areas[areaId].StationUnlocked)
			{
				UnlockStation(context, areaId, costAuthority: false);
				Events.RaiseStationUnlocked(context);
			}
			foreach (short neighborAreaId in _areas[areaId].NeighborAreas)
			{
				MapAreaData neighborArea = _areas[neighborAreaId];
				if (!neighborArea.Discovered)
				{
					neighborArea.Discovered = true;
					SetElement_Areas(neighborAreaId, neighborArea, context);
				}
			}
		}
		return true;
	}

	private void EnsureCostDays(DataContext context)
	{
		if (!_travelInfo.Traveling)
		{
			return;
		}
		_carrierReduceTravelCostDaysPercent = CalcCarrierReduceTravelCostDaysPercent();
		int dynamicCost = GetAreaCostDays(_travelInfo.CurrentAreaId, _travelInfo.NextAreaId);
		if (dynamicCost < 0)
		{
			return;
		}
		short nextCost = _travelInfo.Route.CostList[_travelInfo.RouteIndex + 1];
		if (nextCost != dynamicCost)
		{
			int correction = Math.Min(nextCost - dynamicCost, _travelInfo.NextCostDays - 1);
			if (correction != 0)
			{
				_travelInfo.Route.CostList[_travelInfo.RouteIndex + 1] -= (short)correction;
				SetTravelInfo(_travelInfo, context);
			}
		}
	}

	private IEnumerable<short> GetAllAreaIds()
	{
		for (short i = 0; i < _areas.Length; i++)
		{
			yield return i;
		}
	}

	private IEnumerable<(short area, int cost)> GetAreaNeighbors(short areaId)
	{
		MapAreaItem config = _areas[areaId].GetConfig();
		AreaTravelRoute[] neighborAreas = config.NeighborAreas;
		for (int i = 0; i < neighborAreas.Length; i++)
		{
			AreaTravelRoute neighborArea = neighborAreas[i];
			short neighborAreaId = GetAreaIdByAreaTemplateId(neighborArea.DestAreaId);
			int cost = GetAreaPathDays(neighborArea.CostDays);
			if (_preferUnlockedTravelRoute && !_areas[neighborAreaId].StationUnlocked)
			{
				cost += 1000000;
			}
			yield return (area: neighborAreaId, cost: cost);
		}
		foreach (MapAreaItem extraConfig in (IEnumerable<MapAreaItem>)MapArea.Instance)
		{
			AreaTravelRoute[] neighborAreas2 = extraConfig.NeighborAreas;
			for (int j = 0; j < neighborAreas2.Length; j++)
			{
				AreaTravelRoute neighborArea2 = neighborAreas2[j];
				if (neighborArea2.DestAreaId == config.TemplateId)
				{
					short extraAreaId = GetAreaIdByAreaTemplateId(extraConfig.TemplateId);
					int cost2 = GetAreaPathDays(neighborArea2.CostDays);
					if (_preferUnlockedTravelRoute && !_areas[extraAreaId].StationUnlocked)
					{
						cost2 += 1000000;
					}
					yield return (area: extraAreaId, cost: cost2);
				}
			}
		}
	}

	private int GetAreaCostDays(short areaA, short areaB)
	{
		if (areaA == areaB)
		{
			return -1;
		}
		MapAreaItem configA = _areas[areaA].GetConfig();
		MapAreaItem configB = _areas[areaB].GetConfig();
		AreaTravelRoute[] neighborAreas = configA.NeighborAreas;
		for (int i = 0; i < neighborAreas.Length; i++)
		{
			AreaTravelRoute route = neighborAreas[i];
			if (route.DestAreaId == configB.TemplateId)
			{
				return GetAreaCostDays(route.CostDays);
			}
		}
		AreaTravelRoute[] neighborAreas2 = configB.NeighborAreas;
		for (int j = 0; j < neighborAreas2.Length; j++)
		{
			AreaTravelRoute route2 = neighborAreas2[j];
			if (route2.DestAreaId == configA.TemplateId)
			{
				return GetAreaCostDays(route2.CostDays);
			}
		}
		return -1;
	}

	private int GetAreaPathDays(short configCostDays)
	{
		return Math.Max(GetAreaCostDays(configCostDays), 1) * 1000 + 1;
	}

	private int GetAreaCostDays(short configCostDays)
	{
		return configCostDays - configCostDays * _carrierReduceTravelCostDaysPercent / 100;
	}

	private int CalcCarrierReduceTravelCostDaysPercent()
	{
		KidnappedTravelData kidnappedData = DomainManager.Extra.GetKidnappedTravelData();
		if (kidnappedData.Valid)
		{
			return Config.Carrier.Instance[(short)26].BaseTravelTimeReduction;
		}
		return 100 - 100 * DomainManager.Taiwu.GetTaiwu().CalcCarrierTimeBonus();
	}

	private void FinishTravel(DataContext context, short destAreaId)
	{
		short destBlockId = ((destAreaId == _travelInfo.FromAreaId) ? _travelInfo.FromBlockId : GetPureTravelBlockId(context, destAreaId, _travelInfo.FromAreaId));
		Location arriveLocation = new Location(destAreaId, destBlockId);
		if (DomainManager.Extra.GetIsDirectTraveling())
		{
			DomainManager.Extra.SetIsDirectTraveling(value: false, context);
		}
		KidnappedTravelData kidnappedData = DomainManager.Extra.GetKidnappedTravelData();
		if (kidnappedData.Valid && destAreaId == kidnappedData.Target.AreaId)
		{
			arriveLocation.BlockId = kidnappedData.Target.BlockId;
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.HidePartWorldMap);
			DomainManager.TaiwuEvent.OnEvent_TaiwuBeHuntedArrivedSect(kidnappedData.HunterCharId);
			DomainManager.Extra.SetKidnappedTravelData(KidnappedTravelData.Invalid, context);
		}
		DomainManager.Taiwu.TaiwuGroupMove(context, arriveLocation);
		MapBlockData destBlock = GetBlock(arriveLocation);
		SetBlockAndViewRangeVisibleByMove(context, destBlock);
		DomainManager.Extra.GearMateFollowTaiwu(context);
		_travelInfo.ToAreaId = -1;
		if (!DomainManager.Extra.TryGetElement_TaiwuVisitedAreas(destAreaId, out var _))
		{
			DomainManager.Extra.SetTaiwuVisitedAreas(context, destAreaId, isVisited: true);
		}
		SetTravelInfo(_travelInfo, context);
		MapAreaData areaData = GetElement_Areas(destAreaId);
		if (!DomainManager.Map.IsAreaBroken(destAreaId))
		{
			sbyte stateId = areaData.GetConfig().StateID;
			if (!DomainManager.Extra.CheckIsUnlockedSectXuannvMusicByMapStateId(stateId))
			{
				DomainManager.Extra.UnlockSectXuannvMusicByMapStateId(context, stateId);
			}
		}
		DomainManager.Merchant.RefreshCaravanInTaiwuState(context);
		DomainManager.Extra.ClearTravelingEvents(context);
		DomainManager.Extra.ClearGainsInTravel(context);
		DomainManager.TaiwuEvent.OnEvent_OnFinishTravel();
	}

	private short GetPureTravelBlockId(DataContext context, short destAreaId, short fromAreaId)
	{
		short destBlockId = _areas[destAreaId].StationBlockId;
		short num = destAreaId;
		bool flag = (uint)(num - 137) <= 1u;
		bool flag2 = !flag;
		bool flag3 = flag2;
		if (flag3)
		{
			bool flag4 = ((fromAreaId == 135 || fromAreaId == 138) ? true : false);
			flag3 = !flag4;
		}
		if (flag3 && destBlockId >= 0)
		{
			return destBlockId;
		}
		List<short> edgeBlocks = new List<short>();
		GetEdgeBlockList(destAreaId, edgeBlocks, excludeTravelBlock: true);
		edgeBlocks.RemoveAll((short blockId) => GetBlockData(destAreaId, blockId).TemplateId == 124);
		edgeBlocks.RemoveAll(delegate(short blockId)
		{
			MapBlockData blockData = GetBlockData(destAreaId, blockId);
			return (blockData.TemplateEnemyList != null && blockData.TemplateEnemyList.Count > 0) || DomainManager.Extra.IsLocationContainsAnimal(new Location(destAreaId, blockId));
		});
		return edgeBlocks.GetRandom(context.Random);
	}

	private static void AddUnlockStationSeniority(DataContext context, int needAuthority)
	{
		ProfessionFormulaItem formula = ProfessionFormula.Instance[74];
		int addSeniority = formula.Calculate(needAuthority);
		DomainManager.Extra.ChangeProfessionSeniority(context, 11, addSeniority);
	}

	public unsafe short DetectTravelingEvent(DataContext context)
	{
		List<(short, short)> weightTable = _travelingEventWeights;
		weightTable.Clear();
		int routeIndex = _travelInfo.RouteIndex;
		short currAreaId = _travelInfo.CurrentAreaId;
		short fromAreaId = _travelInfo.LastAreaId;
		short destAreaId = _travelInfo.NextAreaId;
		if (_travelInfo.ToAreaId < 0)
		{
			currAreaId = (fromAreaId = (destAreaId = DomainManager.Taiwu.GetTaiwu().GetLocation().AreaId));
		}
		sbyte currStateTemplateId = GetStateTemplateIdByAreaId(currAreaId);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Personalities personalities = taiwuChar.GetPersonalities();
		sbyte fame = taiwuChar.GetFame();
		List<short> costList = _travelInfo.Route.CostList;
		int leftDays = DomainManager.World.GetLeftDaysInCurrMonth() - ((costList.CheckIndex(routeIndex) ? costList[routeIndex] : costList[0]) + 1);
		foreach (TravelingEventItem cfg in (IEnumerable<TravelingEventItem>)TravelingEvent.Instance)
		{
			if (cfg.OccurRate > 0 && leftDays >= cfg.NeedTime && fame >= cfg.FameLimit[0] && fame <= cfg.FameLimit[1] && CheckValidAreaToTrigger(cfg, currAreaId, fromAreaId, destAreaId) && (cfg.StateTemplateId < 0 || cfg.StateTemplateId == currStateTemplateId) && (!cfg.IsUnique || !DomainManager.Extra.HasTravelingEventBeenTriggered(cfg.TemplateId)) && CheckTravelingEventSpecialCondition(context.Random, cfg.TemplateId))
			{
				int occurRate = cfg.OccurRate;
				if (cfg.NeedPersonality >= 0)
				{
					sbyte personality = personalities.Items[cfg.NeedPersonality];
					occurRate = occurRate * personality / 50;
				}
				if (cfg.FameMultiplier != 0)
				{
					occurRate = occurRate * cfg.FameMultiplier * fame / 100;
				}
				weightTable.Add((cfg.TemplateId, (short)Math.Clamp(occurRate, 0, 32767)));
			}
		}
		CollectionUtils.Shuffle(context.Random, weightTable);
		weightTable.Sort(CompareTravelingEventsDec);
		foreach (var (templateId, occurRate2) in weightTable)
		{
			if (!context.Random.CheckPercentProb(occurRate2))
			{
				continue;
			}
			int offset = AddTravelingEvent(context, templateId, currAreaId);
			if (offset < 0)
			{
				continue;
			}
			DomainManager.Extra.AddTriggeredTravelingEvent(context, templateId);
			TravelingEventItem configData = TravelingEvent.Instance[templateId];
			if (string.IsNullOrEmpty(configData.Event))
			{
				return templateId;
			}
			TravelingEventCollection travelingEventCollection = DomainManager.Extra.GetTravelingEventCollection();
			GameData.Domains.TaiwuEvent.TaiwuEvent taiwuEvent = DomainManager.TaiwuEvent.GetEvent(configData.Event);
			if (taiwuEvent != null)
			{
				GameData.Domains.TaiwuEvent.TaiwuEvent taiwuEvent2 = taiwuEvent;
				if (taiwuEvent2.ArgBox == null)
				{
					EventArgBox eventArgBox = (taiwuEvent2.ArgBox = DomainManager.TaiwuEvent.GetEventArgBox());
				}
				travelingEventCollection.FillEventArgBox(offset, taiwuEvent.ArgBox);
				if (taiwuEvent.EventConfig.CheckCondition())
				{
					DomainManager.TaiwuEvent.AddTriggeredEvent(taiwuEvent);
					DomainManager.TaiwuEvent.TravelingEventCheckComplete();
					DomainManager.Map.SetOnHandlingTravelingEventBlock(value: true, context);
					ProfessionFormulaItem formula = ProfessionFormula.Instance[77];
					int addSeniority = formula.Calculate();
					DomainManager.Extra.ChangeProfessionSeniority(context, 11, addSeniority);
					return templateId;
				}
				int size = travelingEventCollection.GetRecordSize(offset);
				travelingEventCollection.Remove(offset, size);
				Logger.Warn($"Traveling event {templateId} - {configData.Name} is triggering {taiwuEvent.EventGuid} when OnCheckEventCondition return false.");
				return -1;
			}
			Logger.Warn($"Monthly Event {templateId} - {configData.Name} ({configData.Event}) not found.");
			return -1;
		}
		return -1;
		static int CompareTravelingEventsDec((short templateId, short weight) a, (short templateId, short weight) b)
		{
			sbyte aOrder = TravelingEvent.Instance[a.templateId].OccurOrder;
			sbyte bOrder = TravelingEvent.Instance[b.templateId].OccurOrder;
			return bOrder.CompareTo(aOrder);
		}
	}

	private bool CheckValidAreaToTrigger(TravelingEventItem config, short currAreaId, short fromAreaId, short toAreaId)
	{
		return config.TriggerType switch
		{
			ETravelingEventTriggerType.Any => CheckTriggerAreaType(config.TriggerAreaType, fromAreaId) || CheckTriggerAreaType(config.TriggerAreaType, currAreaId) || CheckTriggerAreaType(config.TriggerAreaType, toAreaId), 
			ETravelingEventTriggerType.OnArea => CheckTriggerAreaType(config.TriggerAreaType, currAreaId), 
			ETravelingEventTriggerType.ToArea => CheckTriggerAreaType(config.TriggerAreaType, toAreaId), 
			ETravelingEventTriggerType.FromArea => CheckTriggerAreaType(config.TriggerAreaType, fromAreaId), 
			_ => false, 
		};
	}

	private bool CheckTriggerAreaType(ETravelingEventTriggerAreaType areaType, short areaId)
	{
		switch (areaType)
		{
		case ETravelingEventTriggerAreaType.Any:
			return true;
		case ETravelingEventTriggerAreaType.NormalArea:
			return areaId < 45;
		case ETravelingEventTriggerAreaType.BrokenArea:
			return areaId >= 45 && areaId < 135;
		case ETravelingEventTriggerAreaType.SectArea:
		{
			MapAreaItem areaCfg2 = _areas[areaId].GetConfig();
			return MapState.Instance[areaCfg2.StateID].SectAreaID == areaCfg2.TemplateId;
		}
		case ETravelingEventTriggerAreaType.MainCityArea:
		{
			MapAreaItem areaCfg = _areas[areaId].GetConfig();
			return MapState.Instance[areaCfg.StateID].MainAreaID == areaCfg.TemplateId;
		}
		default:
			return false;
		}
	}

	private int AddTravelingEvent(DataContext context, short templateId, short areaId)
	{
		TravelingEventCollection travelingEventCollection = DomainManager.Extra.GetTravelingEventCollection();
		TravelingEventItem config = TravelingEvent.Instance[templateId];
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location location = new Location(areaId, -1);
		switch (config.Type)
		{
		case ETravelingEventType.AreaMaterial:
			var (itemType, itemTemplateId) = GenerateTravelingEventItemParameter(context, config);
			if (string.IsNullOrEmpty(config.Event))
			{
				ItemKey itemKey2 = DomainManager.Item.CreateItem(context, itemType, itemTemplateId);
				DomainManager.Extra.AddGainsInTravel(context, itemKey2);
				taiwuChar.AddInventoryItem(context, itemKey2, 1);
			}
			return travelingEventCollection.AddType_AreaMaterial(templateId, taiwuCharId, itemType, itemTemplateId);
		case ETravelingEventType.AreaResource:
			var (resourceType2, amount2) = GenerateTravelingEventResourceParameter(context, config);
			if (resourceType2 < 0 || amount2 <= 0)
			{
				return -1;
			}
			if (string.IsNullOrEmpty(config.Event))
			{
				taiwuChar.ChangeResource(context, resourceType2, amount2);
			}
			return travelingEventCollection.AddType_AreaResource(templateId, taiwuCharId, amount2, resourceType2);
		case ETravelingEventType.AreaFood:
			var (itemType2, itemTemplateId2) = GenerateTravelingEventItemParameter(context, config);
			if (string.IsNullOrEmpty(config.Event))
			{
				ItemKey itemKey3 = DomainManager.Item.CreateItem(context, itemType2, itemTemplateId2);
				DomainManager.Extra.AddGainsInTravel(context, itemKey3);
				taiwuChar.AddInventoryItem(context, itemKey3, 1);
			}
			return travelingEventCollection.AddType_AreaFood(templateId, taiwuCharId, itemType2, itemTemplateId2);
		case ETravelingEventType.Heal:
		{
			int value = context.Random.Next(config.ValueRange[0], config.ValueRange[1]);
			switch (templateId)
			{
			case 45:
			{
				sbyte bodyPartType2 = taiwuChar.GetRandomInjuredBodyPartToHeal(context.Random, isInnerInjury: false, 6);
				taiwuChar.ChangeInjury(context, bodyPartType2, isInnerInjury: false, (sbyte)(-value));
				return travelingEventCollection.AddHealOuterInjury(taiwuCharId, value);
			}
			case 46:
			{
				sbyte bodyPartType = taiwuChar.GetRandomInjuredBodyPartToHeal(context.Random, isInnerInjury: true, 6);
				if (bodyPartType < 0)
				{
					return -1;
				}
				taiwuChar.ChangeInjury(context, bodyPartType, isInnerInjury: true, (sbyte)(-value));
				return travelingEventCollection.AddHealInnerInjury(taiwuCharId, value);
			}
			case 47:
			{
				sbyte poisonType = taiwuChar.GetRandomPoisonTypeToDetox(context.Random, 3);
				if (poisonType < 0)
				{
					return -1;
				}
				taiwuChar.ChangePoisoned(context, poisonType, 3, -value);
				return travelingEventCollection.AddHealPoison(taiwuCharId, poisonType);
			}
			case 48:
				taiwuChar.ChangeDisorderOfQi(context, (short)(-value));
				return travelingEventCollection.AddHealDisorderOfQi(taiwuCharId, value);
			case 49:
				taiwuChar.ChangeHealth(context, value);
				return travelingEventCollection.AddHealLifeSpan(taiwuCharId, value);
			default:
				return -1;
			}
		}
		case ETravelingEventType.CharacterGiftItem:
		{
			int charId = ((config.FameMultiplier != 0) ? GenerateTravelingEventAreaCharacterParameter(context, config, areaId) : GenerateTravelingEventFriendOrFamilyCharacterParameter(context, config, areaId));
			if (charId < 0)
			{
				return -1;
			}
			ItemKey itemKey = GenerateTravelingEventCharacterItemParameter(context, config, charId);
			if (!itemKey.IsValid())
			{
				return -1;
			}
			if (string.IsNullOrEmpty(config.Event))
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				DomainManager.Character.TransferInventoryItem(context, character, taiwuChar, itemKey, 1);
				DomainManager.Extra.AddGainsInTravel(context, itemKey);
			}
			return travelingEventCollection.AddType_CharacterGiftItem(templateId, taiwuCharId, location, charId, itemKey.ItemType, itemKey.TemplateId);
		}
		case ETravelingEventType.CharacterGiftResource:
		{
			int charId2 = ((config.FameMultiplier != 0) ? GenerateTravelingEventAreaCharacterParameter(context, config, areaId) : GenerateTravelingEventFriendOrFamilyCharacterParameter(context, config, areaId));
			if (charId2 < 0)
			{
				return -1;
			}
			var (resourceType, amount) = GenerateTravelingEventCharacterResourceParameter(context, config, charId2);
			if (resourceType < 0 || amount <= 0)
			{
				return -1;
			}
			if (string.IsNullOrEmpty(config.Event))
			{
				GameData.Domains.Character.Character character2 = DomainManager.Character.GetElement_Objects(charId2);
				DomainManager.Character.TransferResource(context, character2, taiwuChar, resourceType, amount);
			}
			return travelingEventCollection.AddType_CharacterGiftResource(templateId, taiwuCharId, location, charId2, amount, resourceType);
		}
		case ETravelingEventType.AttributeRegen:
			if (string.IsNullOrEmpty(config.Event))
			{
				sbyte mainAttrType = (sbyte)(config.CharacterProperty - 0);
				taiwuChar.ChangeCurrMainAttribute(context, mainAttrType, 10);
			}
			return travelingEventCollection.AddType_AttributeRegen(templateId, taiwuCharId, location, 10);
		case ETravelingEventType.AreaInteraction:
		{
			int targetCharId = GenerateTravelingEventAreaCharacterParameter(context, config, location.AreaId);
			if (targetCharId < 0)
			{
				return -1;
			}
			return travelingEventCollection.AddType_AreaInteraction(templateId, taiwuCharId, location, targetCharId);
		}
		case ETravelingEventType.SpiritualDebt:
		{
			short settlementId = GenerateTravelingEventSettlementParameter(context, config, location.AreaId);
			if (settlementId < 0)
			{
				return -1;
			}
			return travelingEventCollection.AddType_SpiritualDebt(templateId, taiwuCharId, settlementId);
		}
		case ETravelingEventType.SectVisit:
			return travelingEventCollection.AddType_SectVisit(templateId, taiwuCharId, location);
		case ETravelingEventType.Combat:
		{
			short enemyCharTemplateId = GenerateTravelingEventEnemyCharTemplateParameter(context, config);
			if (enemyCharTemplateId < 0)
			{
				return -1;
			}
			return travelingEventCollection.AddType_Combat(templateId, taiwuCharId, enemyCharTemplateId);
		}
		case ETravelingEventType.SectCombat:
		{
			short enemyCharTemplateId2 = GenerateTravelingEventEnemyCharTemplateParameter(context, config);
			if (enemyCharTemplateId2 < 0)
			{
				return -1;
			}
			return travelingEventCollection.AddType_SectCombat(templateId, taiwuCharId, enemyCharTemplateId2);
		}
		case ETravelingEventType.CharacterRecommendVillager:
		{
			int recommenderCharId = ((config.FameMultiplier != 0) ? GenerateTravelingEventAreaCharacterParameter(context, config, areaId) : GenerateTravelingEventFriendOrFamilyCharacterParameter(context, config, areaId));
			if (recommenderCharId < 0)
			{
				return -1;
			}
			int recommendedCharId = GetRecommendedCharacterId(context, recommenderCharId);
			if (recommendedCharId < 0)
			{
				return -1;
			}
			return travelingEventCollection.AddType_CharacterRecommendVillager(templateId, taiwuCharId, location, recommenderCharId, recommendedCharId);
		}
		case ETravelingEventType.AttributeCost:
			return travelingEventCollection.AddType_AttributeCost(templateId, taiwuCharId, 10);
		case ETravelingEventType.CarrierDurability:
			if (DomainManager.World.GetLeftDaysInCurrMonth() < config.NeedTime + 3)
			{
				return -1;
			}
			foreach (ItemKey carrierKey in taiwuChar.GetValidCarrierEquipment())
			{
				EquipmentBase carrier = DomainManager.Item.TryGetBaseEquipment(carrierKey);
				if (carrier == null || carrier.GetCurrDurability() == 0)
				{
					continue;
				}
				return travelingEventCollection.AddRoadBlock(taiwuCharId);
			}
			return -1;
		default:
			return -1;
		}
	}

	private bool CheckTravelingEventSpecialCondition(IRandomSource random, short templateId)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		switch (templateId)
		{
		case 45:
			return taiwuChar.GetRandomInjuredBodyPartToHeal(random, isInnerInjury: false, 6) >= 0;
		case 46:
			return taiwuChar.GetRandomInjuredBodyPartToHeal(random, isInnerInjury: true, 6) >= 0;
		case 47:
			return taiwuChar.GetRandomPoisonTypeToDetox(random, 3) >= 0;
		case 48:
			return taiwuChar.GetDisorderOfQi() > 0;
		case 49:
			return taiwuChar.GetHealth() < taiwuChar.GetLeftMaxHealth();
		default:
		{
			TravelingEventItem config = TravelingEvent.Instance.GetItem(templateId);
			if (config != null && config.Type == ETravelingEventType.Combat && DomainManager.Taiwu.IsTaiwuAvoidTravelingEnemies())
			{
				return false;
			}
			return true;
		}
		}
	}

	private (sbyte itemType, short itemTemplateId) GenerateTravelingEventItemParameter(DataContext context, TravelingEventItem config)
	{
		Tester.Assert(config.ItemRange.Count > 0 && config.ItemGradeWeight != null && config.ItemGradeWeight.Length != 0);
		List<TemplateKey> validTemplateKeys = context.AdvanceMonthRelatedData.ItemTemplateKeys.Occupy();
		int grade = RandomUtils.GetRandomIndex(config.ItemGradeWeight, context.Random);
		PresetItemTemplateIdGroup presetItemTemplateIdGroup = config.ItemRange.GetRandom(context.Random);
		for (int i = 0; i < presetItemTemplateIdGroup.GroupLength; i++)
		{
			short currTemplateId = (short)(presetItemTemplateIdGroup.StartId + i);
			if (ItemTemplateHelper.GetGrade(presetItemTemplateIdGroup.ItemType, currTemplateId) == grade)
			{
				validTemplateKeys.Add(new TemplateKey(presetItemTemplateIdGroup.ItemType, currTemplateId));
			}
		}
		if (validTemplateKeys.Count == 0)
		{
			throw new Exception($"No valid item of type {presetItemTemplateIdGroup.ItemType} and grade {grade} for traveling event {config.TemplateId} {config.Name}");
		}
		TemplateKey randomKey = validTemplateKeys.GetRandom(context.Random);
		context.AdvanceMonthRelatedData.ItemTemplateKeys.Release(ref validTemplateKeys);
		return (itemType: randomKey.ItemType, itemTemplateId: randomKey.TemplateId);
	}

	private ItemKey GenerateTravelingEventCharacterItemParameter(DataContext context, TravelingEventItem config, int charId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		Inventory inventory = character.GetInventory();
		List<ItemKey> validItemKeys = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		List<(ItemBase, int)>[] classifiedItems = context.AdvanceMonthRelatedData.ClassifiedItems.Occupy();
		foreach (var (itemKey2, amount) in inventory.Items)
		{
			if (itemKey2.ItemType == config.FilterItemType && !ItemTemplateHelper.IsTransferable(itemKey2.ItemType, itemKey2.TemplateId))
			{
				ItemBase item = DomainManager.Item.GetBaseItem(itemKey2);
				classifiedItems[item.GetGrade() / 3].Add((item, amount));
			}
		}
		List<(ItemBase, int)>[] array = classifiedItems;
		foreach (List<(ItemBase, int)> gradeGroup in array)
		{
			if (gradeGroup.Count > 0)
			{
				validItemKeys.Add(gradeGroup.GetRandom(context.Random).Item1.GetItemKey());
			}
		}
		ItemKey selectedItemKey = validItemKeys.GetRandomOrDefault(context.Random, ItemKey.Invalid);
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref validItemKeys);
		context.AdvanceMonthRelatedData.ClassifiedItems.Release(ref classifiedItems);
		return selectedItemKey;
	}

	private short GenerateTravelingEventSettlementParameter(DataContext context, TravelingEventItem config, short areaId)
	{
		List<short> settlementIds = ObjectPool<List<short>>.Instance.Get();
		settlementIds.Clear();
		SettlementInfo[] settlementInfos = _areas[areaId].SettlementInfos;
		for (int i = 0; i < settlementInfos.Length; i++)
		{
			SettlementInfo settlementInfo = settlementInfos[i];
			if (settlementInfo.SettlementId >= 0 && GetBlock(areaId, settlementInfo.BlockId).BlockType != EMapBlockType.Sect)
			{
				settlementIds.Add(settlementInfo.SettlementId);
			}
		}
		int selectedSettlementId = ((settlementIds.Count > 0) ? settlementIds.GetRandom(context.Random) : (-1));
		ObjectPool<List<short>>.Instance.Return(settlementIds);
		return (short)selectedSettlementId;
	}

	private (sbyte resourceType, int amount) GenerateTravelingEventResourceParameter(DataContext context, TravelingEventItem config)
	{
		Tester.Assert(config.ResourceWeights != null && config.ResourceWeights.Length != 0);
		sbyte resourceType = (sbyte)RandomUtils.GetRandomIndex(config.ResourceWeights, context.Random);
		int worth = context.Random.Next(50, 151) * GlobalConfig.ResourcesWorth[0];
		int amount = worth / GlobalConfig.ResourcesWorth[resourceType];
		return (resourceType: resourceType, amount: amount);
	}

	private (sbyte resourceType, int amount) GenerateTravelingEventCharacterResourceParameter(DataContext context, TravelingEventItem config, int charId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		List<sbyte> validResTypes = ObjectPool<List<sbyte>>.Instance.Get();
		validResTypes.Clear();
		for (sbyte resType = 0; resType < 7; resType++)
		{
			if (character.GetResource(resType) >= 100)
			{
				validResTypes.Add(resType);
			}
		}
		sbyte resourceType = (sbyte)((validResTypes.Count > 0) ? validResTypes.GetRandom(context.Random) : (-1));
		ObjectPool<List<sbyte>>.Instance.Return(validResTypes);
		if (resourceType < 0)
		{
			return (resourceType: -1, amount: 0);
		}
		int amount = character.GetResource(resourceType) / context.Random.Next(5, 11);
		return (resourceType: resourceType, amount: amount);
	}

	private short GenerateTravelingEventEnemyCharTemplateParameter(DataContext context, TravelingEventItem config)
	{
		sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
		sbyte enemyGrade = Math.Clamp(xiangshuLevel, 0, 8);
		return CharacterDomain.GetRandomEnemyCharTemplateId(context.Random, config.OrgTemplateId, enemyGrade);
	}

	private int GenerateTravelingEventAreaCharacterParameter(DataContext context, TravelingEventItem config, short areaId)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		List<int> charIdList = context.AdvanceMonthRelatedData.CharIdList.Occupy();
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
		int i = 0;
		for (int blocksCount = blocks.Length; i < blocksCount; i++)
		{
			HashSet<int> charIds = blocks[i].CharacterSet;
			if (charIds == null)
			{
				continue;
			}
			foreach (int charId in charIds)
			{
				if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.IsInteractableAsIntelligentCharacter() && !DomainManager.Character.HasRelation(charId, taiwuCharId, 32768))
				{
					charIdList.Add(charId);
				}
			}
		}
		int selectedCharId = charIdList.GetRandomOrDefault(context.Random, -1);
		context.AdvanceMonthRelatedData.CharIdList.Release(ref charIdList);
		return selectedCharId;
	}

	private int GenerateTravelingEventFriendOrFamilyCharacterParameter(DataContext context, TravelingEventItem config, short areaId)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		List<int> charIdList = context.AdvanceMonthRelatedData.CharIdList.Occupy();
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
		int i = 0;
		for (int blocksCount = blocks.Length; i < blocksCount; i++)
		{
			HashSet<int> charIds = blocks[i].CharacterSet;
			if (charIds == null)
			{
				continue;
			}
			foreach (int charId in charIds)
			{
				if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.IsInteractableAsIntelligentCharacter() && DomainManager.Character.TryGetRelation(charId, taiwuCharId, out var targetToSelf) && AiHelper.ActionTargetRelationCategory.GetTargetRelationCategory(targetToSelf.RelationType) == 1)
				{
					charIdList.Add(charId);
				}
			}
		}
		int selectedCharId = charIdList.GetRandomOrDefault(context.Random, -1);
		context.AdvanceMonthRelatedData.CharIdList.Release(ref charIdList);
		return selectedCharId;
	}

	private int GetRecommendedCharacterId(DataContext context, int recommenderId)
	{
		HashSet<int> relatedCharIds = context.AdvanceMonthRelatedData.RelatedCharIds.Occupy();
		DomainManager.Character.GetAllTwoWayRelatedCharIds(recommenderId, relatedCharIds);
		OrganizationInfo taiwuOrgInfo = DomainManager.Taiwu.GetTaiwu().GetOrganizationInfo();
		sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
		sbyte maxGrade = GlobalConfig.Instance.XiangshuInfectionGradeUpperLimits[xiangshuLevel];
		int charIdWithMaxFavor = -1;
		short maxFavor = -30000;
		foreach (int relatedCharId in relatedCharIds)
		{
			if (!DomainManager.Character.TryGetElement_Objects(relatedCharId, out var character) || !character.IsInteractableAsIntelligentCharacter())
			{
				continue;
			}
			OrganizationInfo orgInfo = character.GetOrganizationInfo();
			if (orgInfo.Grade <= maxGrade && orgInfo.OrgTemplateId != taiwuOrgInfo.OrgTemplateId && !character.IsTreasuryGuard())
			{
				RelatedCharacter relation = DomainManager.Character.GetRelation(recommenderId, relatedCharId);
				if (relation.Favorability > maxFavor)
				{
					charIdWithMaxFavor = relatedCharId;
					maxFavor = relation.Favorability;
				}
			}
		}
		context.AdvanceMonthRelatedData.RelatedCharIds.Release(ref relatedCharIds);
		return charIdWithMaxFavor;
	}

	private void InitializeXiangshuInfectedDemonsAreaCache()
	{
		_xiangshuInfectedDemonsStateCache.Clear();
		for (sbyte stateId = 0; stateId < 15; stateId++)
		{
			XiangshuInfectedDemonData demonData = _stateXiangshuInfectedDemons[stateId];
			if (demonData != null && demonData.CharId >= 0)
			{
				_xiangshuInfectedDemonsStateCache.Add(demonData.CharId, stateId);
			}
		}
	}

	public void UpdateXiangshuInfectedDemons(DataContext context)
	{
		if (DomainManager.World.IsChallengeModeEnabled(EChallengeModeImplement.InfectedDemon))
		{
			for (sbyte stateId = 0; stateId < 15; stateId++)
			{
				UpdateStateXiangshuInfectedDemon(context, stateId);
			}
		}
	}

	public void TryResetXiangshuInfectedDemon(DataContext context, int charId)
	{
		if (_xiangshuInfectedDemonsStateCache.TryGetValue(charId, out var stateId))
		{
			XiangshuInfectedDemonData demonData = _stateXiangshuInfectedDemons[stateId];
			if (demonData.CharId != charId)
			{
				Logger.Warn($"Corrupted demon data at state {stateId} with charId {charId}");
			}
			else
			{
				_xiangshuInfectedDemonsStateCache.Remove(demonData.CharId);
				demonData.LastRescuedOrKilledDate = DomainManager.World.GetCurrDate();
				ResetXiangshuInfectedDemon(context, stateId, demonData);
			}
		}
	}

	private void UpdateStateXiangshuInfectedDemon(DataContext context, sbyte stateId)
	{
		XiangshuInfectedDemonData demonData = _stateXiangshuInfectedDemons[stateId];
		GameData.Domains.Character.Character character = GetStateMostPowerfulXiangshuInfected(stateId);
		if (DomainManager.Character.TryGetElement_Objects(demonData.CharId, out var currentDemon))
		{
			if (currentDemon == character)
			{
				UpdateXiangshuInfectedDemonMinionsMovement(context, character, demonData);
				CreateXiangshuInfectedDemonMinions(context, character, stateId, demonData, GlobalConfig.Instance.ChallengeInfectedDemonMinionPerMonth);
				return;
			}
			currentDemon.AddFeature(context, 211, removeMutexFeature: true);
			_xiangshuInfectedDemonsStateCache.Remove(demonData.CharId);
			ResetXiangshuInfectedDemon(context, stateId, demonData);
			if (character != null)
			{
				demonData.CharId = character.GetId();
				character.AddFeature(context, 814, removeMutexFeature: true);
				_xiangshuInfectedDemonsStateCache.Add(demonData.CharId, stateId);
				CreateXiangshuInfectedDemonMinions(context, character, stateId, demonData, GlobalConfig.Instance.ChallengeInfectedDemonInitMinion);
			}
		}
		else if (character != null && demonData.LastRescuedOrKilledDate + GlobalConfig.Instance.ChallengeInfectedDemonInterval <= DomainManager.World.GetCurrDate())
		{
			demonData.CharId = character.GetId();
			character.AddFeature(context, 814, removeMutexFeature: true);
			_xiangshuInfectedDemonsStateCache.Add(demonData.CharId, stateId);
			CreateXiangshuInfectedDemonMinions(context, character, stateId, demonData, GlobalConfig.Instance.ChallengeInfectedDemonInitMinion);
		}
	}

	private void ResetXiangshuInfectedDemon(DataContext context, sbyte stateId, XiangshuInfectedDemonData demonData)
	{
		List<XiangshuInfectedDemonMinion> minions = demonData.Minions;
		if (minions != null && minions.Count > 0)
		{
			ClearXiangshuInfectedDemonMinions(context, demonData);
		}
		demonData.CharId = -1;
		SetElement_StateXiangshuInfectedDemons(stateId, demonData, context);
	}

	private void ClearXiangshuInfectedDemonMinions(DataContext context, XiangshuInfectedDemonData demonData)
	{
		foreach (XiangshuInfectedDemonMinion minion in demonData.Minions)
		{
			Location location = new Location(minion.AreaId, minion.EnemyInfo.BlockId);
			MapBlockData block = GetBlock(location);
			if (block.RemoveTemplateEnemy(minion.EnemyInfo))
			{
				SetBlockData(context, block);
			}
		}
		demonData.Minions.Clear();
	}

	private void UpdateXiangshuInfectedDemonMinionsMovement(DataContext context, GameData.Domains.Character.Character character, XiangshuInfectedDemonData demonData)
	{
		List<XiangshuInfectedDemonMinion> minions = demonData.Minions;
		if (minions != null && minions.Count > 0)
		{
			Location demonLocation = character.GetValidLocation();
			List<MapBlockData> neighborBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
			DomainManager.Map.GetNeighborBlocks(demonLocation.AreaId, demonLocation.BlockId, neighborBlocks, 2);
			List<XiangshuInfectedDemonMinion> list = new List<XiangshuInfectedDemonMinion>(demonData.Minions);
			ClearXiangshuInfectedDemonMinions(context, demonData);
			for (int index = 0; index < list.Count; index++)
			{
				XiangshuInfectedDemonMinion minion = list[index];
				short blockId = neighborBlocks.GetRandom(context.Random).BlockId;
				minion.EnemyInfo.BlockId = blockId;
				Events.RaiseTemplateEnemyLocationChanged(destLocation: new Location(demonLocation.AreaId, blockId), context: context, templateEnemyInfo: minion.EnemyInfo, srcLocation: Location.Invalid);
			}
			context.AdvanceMonthRelatedData.Blocks.Release(ref neighborBlocks);
		}
	}

	private void CreateXiangshuInfectedDemonMinions(DataContext context, GameData.Domains.Character.Character character, sbyte stateId, XiangshuInfectedDemonData demonData, int count)
	{
		Location demonLocation = character.GetValidLocation();
		List<MapBlockData> neighborBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.GetNeighborBlocks(demonLocation.AreaId, demonLocation.BlockId, neighborBlocks, GlobalConfig.Instance.ChallengeInfectedDemonMinionRange);
		if (demonData.Minions == null)
		{
			demonData.Minions = new List<XiangshuInfectedDemonMinion>();
		}
		int actualCount = Math.Min(count, GlobalConfig.Instance.ChallengeInfectedDemonMaxMinion - demonData.Minions.Count);
		sbyte minionGrade = GetXiangshuInfectedDemonMinionGrade(character);
		short minionTemplateId = (short)(366 + minionGrade);
		for (int i = 0; i < actualCount; i++)
		{
			short blockId = neighborBlocks.GetRandom(context.Random).BlockId;
			MapTemplateEnemyInfo enemyInfo = MapTemplateEnemyInfo.CreateFromXiangshuInfectedDemon(minionTemplateId, blockId);
			Events.RaiseTemplateEnemyLocationChanged(destLocation: new Location(demonLocation.AreaId, blockId), context: context, templateEnemyInfo: enemyInfo, srcLocation: Location.Invalid);
		}
		SetElement_StateXiangshuInfectedDemons(stateId, demonData, context);
		context.AdvanceMonthRelatedData.Blocks.Release(ref neighborBlocks);
	}

	private sbyte GetXiangshuInfectedDemonMinionGrade(GameData.Domains.Character.Character character)
	{
		sbyte selfGrade = character.GetOrganizationInfo().Grade;
		sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
		sbyte targetGrade = Math.Max(selfGrade, xiangshuLevel);
		return Math.Clamp(targetGrade, 0, 8);
	}

	private GameData.Domains.Character.Character GetStateMostPowerfulXiangshuInfected(sbyte stateId)
	{
		List<short> areaIds = ObjectPool<List<short>>.Instance.Get();
		DomainManager.Map.GetAllAreaInState(stateId, areaIds);
		int bestCombatPower = -1;
		GameData.Domains.Character.Character strongestCharacter = null;
		foreach (short areaId in areaIds)
		{
			Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(areaId);
			Span<MapBlockData> span = areaBlocks;
			for (int i = 0; i < span.Length; i++)
			{
				MapBlockData block = span[i];
				HashSet<int> infectedCharacterSet = block.InfectedCharacterSet;
				if (infectedCharacterSet == null || infectedCharacterSet.Count <= 0)
				{
					continue;
				}
				foreach (int infectedCharId in block.InfectedCharacterSet)
				{
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(infectedCharId);
					int combatPower = character.GetCombatPower();
					if (combatPower >= bestCombatPower)
					{
						strongestCharacter = character;
						bestCombatPower = combatPower;
					}
				}
			}
		}
		ObjectPool<List<short>>.Instance.Return(areaIds);
		return strongestCharacter;
	}

	public MapDomain()
		: base(76)
	{
		_areas = new MapAreaData[141];
		_areaBlocks0 = new AreaBlockCollection();
		_areaBlocks1 = new AreaBlockCollection();
		_areaBlocks2 = new AreaBlockCollection();
		_areaBlocks3 = new AreaBlockCollection();
		_areaBlocks4 = new AreaBlockCollection();
		_areaBlocks5 = new AreaBlockCollection();
		_areaBlocks6 = new AreaBlockCollection();
		_areaBlocks7 = new AreaBlockCollection();
		_areaBlocks8 = new AreaBlockCollection();
		_areaBlocks9 = new AreaBlockCollection();
		_areaBlocks10 = new AreaBlockCollection();
		_areaBlocks11 = new AreaBlockCollection();
		_areaBlocks12 = new AreaBlockCollection();
		_areaBlocks13 = new AreaBlockCollection();
		_areaBlocks14 = new AreaBlockCollection();
		_areaBlocks15 = new AreaBlockCollection();
		_areaBlocks16 = new AreaBlockCollection();
		_areaBlocks17 = new AreaBlockCollection();
		_areaBlocks18 = new AreaBlockCollection();
		_areaBlocks19 = new AreaBlockCollection();
		_areaBlocks20 = new AreaBlockCollection();
		_areaBlocks21 = new AreaBlockCollection();
		_areaBlocks22 = new AreaBlockCollection();
		_areaBlocks23 = new AreaBlockCollection();
		_areaBlocks24 = new AreaBlockCollection();
		_areaBlocks25 = new AreaBlockCollection();
		_areaBlocks26 = new AreaBlockCollection();
		_areaBlocks27 = new AreaBlockCollection();
		_areaBlocks28 = new AreaBlockCollection();
		_areaBlocks29 = new AreaBlockCollection();
		_areaBlocks30 = new AreaBlockCollection();
		_areaBlocks31 = new AreaBlockCollection();
		_areaBlocks32 = new AreaBlockCollection();
		_areaBlocks33 = new AreaBlockCollection();
		_areaBlocks34 = new AreaBlockCollection();
		_areaBlocks35 = new AreaBlockCollection();
		_areaBlocks36 = new AreaBlockCollection();
		_areaBlocks37 = new AreaBlockCollection();
		_areaBlocks38 = new AreaBlockCollection();
		_areaBlocks39 = new AreaBlockCollection();
		_areaBlocks40 = new AreaBlockCollection();
		_areaBlocks41 = new AreaBlockCollection();
		_areaBlocks42 = new AreaBlockCollection();
		_areaBlocks43 = new AreaBlockCollection();
		_areaBlocks44 = new AreaBlockCollection();
		_brokenAreaBlocks = new AreaBlockCollection();
		_bornAreaBlocks = new AreaBlockCollection();
		_guideAreaBlocks = new AreaBlockCollection();
		_secretVillageAreaBlocks = new AreaBlockCollection();
		_brokenPerformAreaBlocks = new AreaBlockCollection();
		_travelRouteDict = new Dictionary<TravelRouteKey, TravelRoute>(0);
		_bornStateTravelRouteDict = new Dictionary<TravelRouteKey, TravelRoute>(0);
		_cricketPlaceData = new CricketPlaceData[141];
		_regularAreaNearList = new Dictionary<short, GameData.Utilities.ShortList>(0);
		_swordTombLocations = new Location[8];
		_travelInfo = new CrossAreaMoveInfo();
		_onHandlingTravelingEventBlock = false;
		_hunterAnimals = new List<HunterAnimalKey>();
		_moveBanned = 0;
		_crossArchiveLockMoveTime = false;
		_fleeBeasts = new List<Location>();
		_fleeLoongs = new List<Location>();
		_loongLocations = new List<LoongLocationData>();
		_alterSettlementLocations = new List<Location>();
		_isTaiwuInFulongFlameArea = false;
		_visibleMapPickups = new List<MapElementPickupDisplayData>();
		_brokenAreaEnemies = new BrokenAreaData[90];
		_stateXiangshuInfectedDemons = new XiangshuInfectedDemonData[15];
		_mapBlockFindDataPresets = new MapBlockFindData[10];
		_pastTaiwuVillageAreaBlocks = new AreaBlockCollection();
		_pastTaiwuVillageLockMoveTime = false;
		_chaishanAreaBlocks = new AreaBlockCollection();
		_arrivedSize2Blocks = new HashSetAsDictionary<Location>();
		_locationNaturalDisasterDate = new Dictionary<Location, int>(0);
		_locationNaturalDisasterDateNew = new Dictionary<Location, int>(0);
		OnInitializedDomainData();
	}

	public MapAreaData GetElement_Areas(int index)
	{
		return _areas[index];
	}

	private void SetElement_Areas(int index, MapAreaData value, DataContext context)
	{
		_areas[index] = value;
		SetModifiedAndInvalidateInfluencedCache(index, _dataStatesAreas, CacheInfluencesAreas, context);
	}

	public MapBlockData GetElement_AreaBlocks0(short elementId)
	{
		return _areaBlocks0[elementId];
	}

	public bool TryGetElement_AreaBlocks0(short elementId, out MapBlockData value)
	{
		return _areaBlocks0.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks0(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks0.Add(elementId, value);
		_modificationsAreaBlocks0.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks0(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks0[elementId] = value;
		_modificationsAreaBlocks0.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks0(short elementId, DataContext context)
	{
		_areaBlocks0.Remove(elementId);
		_modificationsAreaBlocks0.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks0(DataContext context)
	{
		_areaBlocks0.Clear();
		_modificationsAreaBlocks0.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks1(short elementId)
	{
		return _areaBlocks1[elementId];
	}

	public bool TryGetElement_AreaBlocks1(short elementId, out MapBlockData value)
	{
		return _areaBlocks1.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks1(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks1.Add(elementId, value);
		_modificationsAreaBlocks1.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks1(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks1[elementId] = value;
		_modificationsAreaBlocks1.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks1(short elementId, DataContext context)
	{
		_areaBlocks1.Remove(elementId);
		_modificationsAreaBlocks1.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks1(DataContext context)
	{
		_areaBlocks1.Clear();
		_modificationsAreaBlocks1.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks2(short elementId)
	{
		return _areaBlocks2[elementId];
	}

	public bool TryGetElement_AreaBlocks2(short elementId, out MapBlockData value)
	{
		return _areaBlocks2.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks2(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks2.Add(elementId, value);
		_modificationsAreaBlocks2.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks2(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks2[elementId] = value;
		_modificationsAreaBlocks2.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks2(short elementId, DataContext context)
	{
		_areaBlocks2.Remove(elementId);
		_modificationsAreaBlocks2.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks2(DataContext context)
	{
		_areaBlocks2.Clear();
		_modificationsAreaBlocks2.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks3(short elementId)
	{
		return _areaBlocks3[elementId];
	}

	public bool TryGetElement_AreaBlocks3(short elementId, out MapBlockData value)
	{
		return _areaBlocks3.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks3(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks3.Add(elementId, value);
		_modificationsAreaBlocks3.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks3(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks3[elementId] = value;
		_modificationsAreaBlocks3.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks3(short elementId, DataContext context)
	{
		_areaBlocks3.Remove(elementId);
		_modificationsAreaBlocks3.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks3(DataContext context)
	{
		_areaBlocks3.Clear();
		_modificationsAreaBlocks3.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks4(short elementId)
	{
		return _areaBlocks4[elementId];
	}

	public bool TryGetElement_AreaBlocks4(short elementId, out MapBlockData value)
	{
		return _areaBlocks4.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks4(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks4.Add(elementId, value);
		_modificationsAreaBlocks4.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks4(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks4[elementId] = value;
		_modificationsAreaBlocks4.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks4(short elementId, DataContext context)
	{
		_areaBlocks4.Remove(elementId);
		_modificationsAreaBlocks4.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks4(DataContext context)
	{
		_areaBlocks4.Clear();
		_modificationsAreaBlocks4.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks5(short elementId)
	{
		return _areaBlocks5[elementId];
	}

	public bool TryGetElement_AreaBlocks5(short elementId, out MapBlockData value)
	{
		return _areaBlocks5.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks5(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks5.Add(elementId, value);
		_modificationsAreaBlocks5.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks5(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks5[elementId] = value;
		_modificationsAreaBlocks5.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks5(short elementId, DataContext context)
	{
		_areaBlocks5.Remove(elementId);
		_modificationsAreaBlocks5.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks5(DataContext context)
	{
		_areaBlocks5.Clear();
		_modificationsAreaBlocks5.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks6(short elementId)
	{
		return _areaBlocks6[elementId];
	}

	public bool TryGetElement_AreaBlocks6(short elementId, out MapBlockData value)
	{
		return _areaBlocks6.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks6(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks6.Add(elementId, value);
		_modificationsAreaBlocks6.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks6(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks6[elementId] = value;
		_modificationsAreaBlocks6.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks6(short elementId, DataContext context)
	{
		_areaBlocks6.Remove(elementId);
		_modificationsAreaBlocks6.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks6(DataContext context)
	{
		_areaBlocks6.Clear();
		_modificationsAreaBlocks6.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks7(short elementId)
	{
		return _areaBlocks7[elementId];
	}

	public bool TryGetElement_AreaBlocks7(short elementId, out MapBlockData value)
	{
		return _areaBlocks7.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks7(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks7.Add(elementId, value);
		_modificationsAreaBlocks7.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks7(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks7[elementId] = value;
		_modificationsAreaBlocks7.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks7(short elementId, DataContext context)
	{
		_areaBlocks7.Remove(elementId);
		_modificationsAreaBlocks7.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks7(DataContext context)
	{
		_areaBlocks7.Clear();
		_modificationsAreaBlocks7.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks8(short elementId)
	{
		return _areaBlocks8[elementId];
	}

	public bool TryGetElement_AreaBlocks8(short elementId, out MapBlockData value)
	{
		return _areaBlocks8.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks8(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks8.Add(elementId, value);
		_modificationsAreaBlocks8.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks8(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks8[elementId] = value;
		_modificationsAreaBlocks8.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks8(short elementId, DataContext context)
	{
		_areaBlocks8.Remove(elementId);
		_modificationsAreaBlocks8.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks8(DataContext context)
	{
		_areaBlocks8.Clear();
		_modificationsAreaBlocks8.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks9(short elementId)
	{
		return _areaBlocks9[elementId];
	}

	public bool TryGetElement_AreaBlocks9(short elementId, out MapBlockData value)
	{
		return _areaBlocks9.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks9(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks9.Add(elementId, value);
		_modificationsAreaBlocks9.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks9(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks9[elementId] = value;
		_modificationsAreaBlocks9.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks9(short elementId, DataContext context)
	{
		_areaBlocks9.Remove(elementId);
		_modificationsAreaBlocks9.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks9(DataContext context)
	{
		_areaBlocks9.Clear();
		_modificationsAreaBlocks9.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks10(short elementId)
	{
		return _areaBlocks10[elementId];
	}

	public bool TryGetElement_AreaBlocks10(short elementId, out MapBlockData value)
	{
		return _areaBlocks10.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks10(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks10.Add(elementId, value);
		_modificationsAreaBlocks10.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks10(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks10[elementId] = value;
		_modificationsAreaBlocks10.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks10(short elementId, DataContext context)
	{
		_areaBlocks10.Remove(elementId);
		_modificationsAreaBlocks10.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks10(DataContext context)
	{
		_areaBlocks10.Clear();
		_modificationsAreaBlocks10.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks11(short elementId)
	{
		return _areaBlocks11[elementId];
	}

	public bool TryGetElement_AreaBlocks11(short elementId, out MapBlockData value)
	{
		return _areaBlocks11.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks11(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks11.Add(elementId, value);
		_modificationsAreaBlocks11.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks11(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks11[elementId] = value;
		_modificationsAreaBlocks11.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks11(short elementId, DataContext context)
	{
		_areaBlocks11.Remove(elementId);
		_modificationsAreaBlocks11.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks11(DataContext context)
	{
		_areaBlocks11.Clear();
		_modificationsAreaBlocks11.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks12(short elementId)
	{
		return _areaBlocks12[elementId];
	}

	public bool TryGetElement_AreaBlocks12(short elementId, out MapBlockData value)
	{
		return _areaBlocks12.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks12(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks12.Add(elementId, value);
		_modificationsAreaBlocks12.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks12(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks12[elementId] = value;
		_modificationsAreaBlocks12.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks12(short elementId, DataContext context)
	{
		_areaBlocks12.Remove(elementId);
		_modificationsAreaBlocks12.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks12(DataContext context)
	{
		_areaBlocks12.Clear();
		_modificationsAreaBlocks12.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks13(short elementId)
	{
		return _areaBlocks13[elementId];
	}

	public bool TryGetElement_AreaBlocks13(short elementId, out MapBlockData value)
	{
		return _areaBlocks13.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks13(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks13.Add(elementId, value);
		_modificationsAreaBlocks13.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks13(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks13[elementId] = value;
		_modificationsAreaBlocks13.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks13(short elementId, DataContext context)
	{
		_areaBlocks13.Remove(elementId);
		_modificationsAreaBlocks13.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks13(DataContext context)
	{
		_areaBlocks13.Clear();
		_modificationsAreaBlocks13.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks14(short elementId)
	{
		return _areaBlocks14[elementId];
	}

	public bool TryGetElement_AreaBlocks14(short elementId, out MapBlockData value)
	{
		return _areaBlocks14.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks14(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks14.Add(elementId, value);
		_modificationsAreaBlocks14.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks14(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks14[elementId] = value;
		_modificationsAreaBlocks14.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks14(short elementId, DataContext context)
	{
		_areaBlocks14.Remove(elementId);
		_modificationsAreaBlocks14.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks14(DataContext context)
	{
		_areaBlocks14.Clear();
		_modificationsAreaBlocks14.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks15(short elementId)
	{
		return _areaBlocks15[elementId];
	}

	public bool TryGetElement_AreaBlocks15(short elementId, out MapBlockData value)
	{
		return _areaBlocks15.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks15(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks15.Add(elementId, value);
		_modificationsAreaBlocks15.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks15(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks15[elementId] = value;
		_modificationsAreaBlocks15.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks15(short elementId, DataContext context)
	{
		_areaBlocks15.Remove(elementId);
		_modificationsAreaBlocks15.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks15(DataContext context)
	{
		_areaBlocks15.Clear();
		_modificationsAreaBlocks15.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks16(short elementId)
	{
		return _areaBlocks16[elementId];
	}

	public bool TryGetElement_AreaBlocks16(short elementId, out MapBlockData value)
	{
		return _areaBlocks16.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks16(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks16.Add(elementId, value);
		_modificationsAreaBlocks16.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks16(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks16[elementId] = value;
		_modificationsAreaBlocks16.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks16(short elementId, DataContext context)
	{
		_areaBlocks16.Remove(elementId);
		_modificationsAreaBlocks16.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks16(DataContext context)
	{
		_areaBlocks16.Clear();
		_modificationsAreaBlocks16.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks17(short elementId)
	{
		return _areaBlocks17[elementId];
	}

	public bool TryGetElement_AreaBlocks17(short elementId, out MapBlockData value)
	{
		return _areaBlocks17.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks17(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks17.Add(elementId, value);
		_modificationsAreaBlocks17.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks17(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks17[elementId] = value;
		_modificationsAreaBlocks17.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks17(short elementId, DataContext context)
	{
		_areaBlocks17.Remove(elementId);
		_modificationsAreaBlocks17.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks17(DataContext context)
	{
		_areaBlocks17.Clear();
		_modificationsAreaBlocks17.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks18(short elementId)
	{
		return _areaBlocks18[elementId];
	}

	public bool TryGetElement_AreaBlocks18(short elementId, out MapBlockData value)
	{
		return _areaBlocks18.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks18(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks18.Add(elementId, value);
		_modificationsAreaBlocks18.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(19, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks18(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks18[elementId] = value;
		_modificationsAreaBlocks18.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(19, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks18(short elementId, DataContext context)
	{
		_areaBlocks18.Remove(elementId);
		_modificationsAreaBlocks18.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(19, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks18(DataContext context)
	{
		_areaBlocks18.Clear();
		_modificationsAreaBlocks18.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(19, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks19(short elementId)
	{
		return _areaBlocks19[elementId];
	}

	public bool TryGetElement_AreaBlocks19(short elementId, out MapBlockData value)
	{
		return _areaBlocks19.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks19(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks19.Add(elementId, value);
		_modificationsAreaBlocks19.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(20, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks19(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks19[elementId] = value;
		_modificationsAreaBlocks19.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(20, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks19(short elementId, DataContext context)
	{
		_areaBlocks19.Remove(elementId);
		_modificationsAreaBlocks19.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(20, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks19(DataContext context)
	{
		_areaBlocks19.Clear();
		_modificationsAreaBlocks19.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(20, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks20(short elementId)
	{
		return _areaBlocks20[elementId];
	}

	public bool TryGetElement_AreaBlocks20(short elementId, out MapBlockData value)
	{
		return _areaBlocks20.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks20(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks20.Add(elementId, value);
		_modificationsAreaBlocks20.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks20(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks20[elementId] = value;
		_modificationsAreaBlocks20.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks20(short elementId, DataContext context)
	{
		_areaBlocks20.Remove(elementId);
		_modificationsAreaBlocks20.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks20(DataContext context)
	{
		_areaBlocks20.Clear();
		_modificationsAreaBlocks20.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks21(short elementId)
	{
		return _areaBlocks21[elementId];
	}

	public bool TryGetElement_AreaBlocks21(short elementId, out MapBlockData value)
	{
		return _areaBlocks21.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks21(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks21.Add(elementId, value);
		_modificationsAreaBlocks21.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks21(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks21[elementId] = value;
		_modificationsAreaBlocks21.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks21(short elementId, DataContext context)
	{
		_areaBlocks21.Remove(elementId);
		_modificationsAreaBlocks21.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks21(DataContext context)
	{
		_areaBlocks21.Clear();
		_modificationsAreaBlocks21.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks22(short elementId)
	{
		return _areaBlocks22[elementId];
	}

	public bool TryGetElement_AreaBlocks22(short elementId, out MapBlockData value)
	{
		return _areaBlocks22.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks22(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks22.Add(elementId, value);
		_modificationsAreaBlocks22.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(23, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks22(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks22[elementId] = value;
		_modificationsAreaBlocks22.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(23, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks22(short elementId, DataContext context)
	{
		_areaBlocks22.Remove(elementId);
		_modificationsAreaBlocks22.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(23, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks22(DataContext context)
	{
		_areaBlocks22.Clear();
		_modificationsAreaBlocks22.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(23, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks23(short elementId)
	{
		return _areaBlocks23[elementId];
	}

	public bool TryGetElement_AreaBlocks23(short elementId, out MapBlockData value)
	{
		return _areaBlocks23.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks23(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks23.Add(elementId, value);
		_modificationsAreaBlocks23.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(24, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks23(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks23[elementId] = value;
		_modificationsAreaBlocks23.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(24, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks23(short elementId, DataContext context)
	{
		_areaBlocks23.Remove(elementId);
		_modificationsAreaBlocks23.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(24, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks23(DataContext context)
	{
		_areaBlocks23.Clear();
		_modificationsAreaBlocks23.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(24, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks24(short elementId)
	{
		return _areaBlocks24[elementId];
	}

	public bool TryGetElement_AreaBlocks24(short elementId, out MapBlockData value)
	{
		return _areaBlocks24.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks24(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks24.Add(elementId, value);
		_modificationsAreaBlocks24.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(25, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks24(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks24[elementId] = value;
		_modificationsAreaBlocks24.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(25, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks24(short elementId, DataContext context)
	{
		_areaBlocks24.Remove(elementId);
		_modificationsAreaBlocks24.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(25, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks24(DataContext context)
	{
		_areaBlocks24.Clear();
		_modificationsAreaBlocks24.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(25, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks25(short elementId)
	{
		return _areaBlocks25[elementId];
	}

	public bool TryGetElement_AreaBlocks25(short elementId, out MapBlockData value)
	{
		return _areaBlocks25.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks25(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks25.Add(elementId, value);
		_modificationsAreaBlocks25.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(26, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks25(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks25[elementId] = value;
		_modificationsAreaBlocks25.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(26, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks25(short elementId, DataContext context)
	{
		_areaBlocks25.Remove(elementId);
		_modificationsAreaBlocks25.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(26, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks25(DataContext context)
	{
		_areaBlocks25.Clear();
		_modificationsAreaBlocks25.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(26, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks26(short elementId)
	{
		return _areaBlocks26[elementId];
	}

	public bool TryGetElement_AreaBlocks26(short elementId, out MapBlockData value)
	{
		return _areaBlocks26.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks26(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks26.Add(elementId, value);
		_modificationsAreaBlocks26.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(27, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks26(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks26[elementId] = value;
		_modificationsAreaBlocks26.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(27, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks26(short elementId, DataContext context)
	{
		_areaBlocks26.Remove(elementId);
		_modificationsAreaBlocks26.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(27, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks26(DataContext context)
	{
		_areaBlocks26.Clear();
		_modificationsAreaBlocks26.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(27, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks27(short elementId)
	{
		return _areaBlocks27[elementId];
	}

	public bool TryGetElement_AreaBlocks27(short elementId, out MapBlockData value)
	{
		return _areaBlocks27.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks27(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks27.Add(elementId, value);
		_modificationsAreaBlocks27.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(28, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks27(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks27[elementId] = value;
		_modificationsAreaBlocks27.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(28, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks27(short elementId, DataContext context)
	{
		_areaBlocks27.Remove(elementId);
		_modificationsAreaBlocks27.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(28, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks27(DataContext context)
	{
		_areaBlocks27.Clear();
		_modificationsAreaBlocks27.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(28, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks28(short elementId)
	{
		return _areaBlocks28[elementId];
	}

	public bool TryGetElement_AreaBlocks28(short elementId, out MapBlockData value)
	{
		return _areaBlocks28.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks28(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks28.Add(elementId, value);
		_modificationsAreaBlocks28.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(29, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks28(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks28[elementId] = value;
		_modificationsAreaBlocks28.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(29, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks28(short elementId, DataContext context)
	{
		_areaBlocks28.Remove(elementId);
		_modificationsAreaBlocks28.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(29, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks28(DataContext context)
	{
		_areaBlocks28.Clear();
		_modificationsAreaBlocks28.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(29, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks29(short elementId)
	{
		return _areaBlocks29[elementId];
	}

	public bool TryGetElement_AreaBlocks29(short elementId, out MapBlockData value)
	{
		return _areaBlocks29.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks29(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks29.Add(elementId, value);
		_modificationsAreaBlocks29.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(30, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks29(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks29[elementId] = value;
		_modificationsAreaBlocks29.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(30, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks29(short elementId, DataContext context)
	{
		_areaBlocks29.Remove(elementId);
		_modificationsAreaBlocks29.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(30, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks29(DataContext context)
	{
		_areaBlocks29.Clear();
		_modificationsAreaBlocks29.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(30, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks30(short elementId)
	{
		return _areaBlocks30[elementId];
	}

	public bool TryGetElement_AreaBlocks30(short elementId, out MapBlockData value)
	{
		return _areaBlocks30.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks30(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks30.Add(elementId, value);
		_modificationsAreaBlocks30.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(31, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks30(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks30[elementId] = value;
		_modificationsAreaBlocks30.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(31, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks30(short elementId, DataContext context)
	{
		_areaBlocks30.Remove(elementId);
		_modificationsAreaBlocks30.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(31, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks30(DataContext context)
	{
		_areaBlocks30.Clear();
		_modificationsAreaBlocks30.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(31, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks31(short elementId)
	{
		return _areaBlocks31[elementId];
	}

	public bool TryGetElement_AreaBlocks31(short elementId, out MapBlockData value)
	{
		return _areaBlocks31.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks31(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks31.Add(elementId, value);
		_modificationsAreaBlocks31.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(32, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks31(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks31[elementId] = value;
		_modificationsAreaBlocks31.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(32, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks31(short elementId, DataContext context)
	{
		_areaBlocks31.Remove(elementId);
		_modificationsAreaBlocks31.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(32, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks31(DataContext context)
	{
		_areaBlocks31.Clear();
		_modificationsAreaBlocks31.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(32, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks32(short elementId)
	{
		return _areaBlocks32[elementId];
	}

	public bool TryGetElement_AreaBlocks32(short elementId, out MapBlockData value)
	{
		return _areaBlocks32.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks32(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks32.Add(elementId, value);
		_modificationsAreaBlocks32.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(33, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks32(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks32[elementId] = value;
		_modificationsAreaBlocks32.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(33, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks32(short elementId, DataContext context)
	{
		_areaBlocks32.Remove(elementId);
		_modificationsAreaBlocks32.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(33, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks32(DataContext context)
	{
		_areaBlocks32.Clear();
		_modificationsAreaBlocks32.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(33, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks33(short elementId)
	{
		return _areaBlocks33[elementId];
	}

	public bool TryGetElement_AreaBlocks33(short elementId, out MapBlockData value)
	{
		return _areaBlocks33.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks33(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks33.Add(elementId, value);
		_modificationsAreaBlocks33.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(34, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks33(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks33[elementId] = value;
		_modificationsAreaBlocks33.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(34, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks33(short elementId, DataContext context)
	{
		_areaBlocks33.Remove(elementId);
		_modificationsAreaBlocks33.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(34, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks33(DataContext context)
	{
		_areaBlocks33.Clear();
		_modificationsAreaBlocks33.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(34, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks34(short elementId)
	{
		return _areaBlocks34[elementId];
	}

	public bool TryGetElement_AreaBlocks34(short elementId, out MapBlockData value)
	{
		return _areaBlocks34.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks34(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks34.Add(elementId, value);
		_modificationsAreaBlocks34.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(35, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks34(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks34[elementId] = value;
		_modificationsAreaBlocks34.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(35, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks34(short elementId, DataContext context)
	{
		_areaBlocks34.Remove(elementId);
		_modificationsAreaBlocks34.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(35, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks34(DataContext context)
	{
		_areaBlocks34.Clear();
		_modificationsAreaBlocks34.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(35, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks35(short elementId)
	{
		return _areaBlocks35[elementId];
	}

	public bool TryGetElement_AreaBlocks35(short elementId, out MapBlockData value)
	{
		return _areaBlocks35.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks35(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks35.Add(elementId, value);
		_modificationsAreaBlocks35.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(36, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks35(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks35[elementId] = value;
		_modificationsAreaBlocks35.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(36, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks35(short elementId, DataContext context)
	{
		_areaBlocks35.Remove(elementId);
		_modificationsAreaBlocks35.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(36, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks35(DataContext context)
	{
		_areaBlocks35.Clear();
		_modificationsAreaBlocks35.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(36, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks36(short elementId)
	{
		return _areaBlocks36[elementId];
	}

	public bool TryGetElement_AreaBlocks36(short elementId, out MapBlockData value)
	{
		return _areaBlocks36.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks36(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks36.Add(elementId, value);
		_modificationsAreaBlocks36.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(37, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks36(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks36[elementId] = value;
		_modificationsAreaBlocks36.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(37, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks36(short elementId, DataContext context)
	{
		_areaBlocks36.Remove(elementId);
		_modificationsAreaBlocks36.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(37, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks36(DataContext context)
	{
		_areaBlocks36.Clear();
		_modificationsAreaBlocks36.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(37, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks37(short elementId)
	{
		return _areaBlocks37[elementId];
	}

	public bool TryGetElement_AreaBlocks37(short elementId, out MapBlockData value)
	{
		return _areaBlocks37.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks37(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks37.Add(elementId, value);
		_modificationsAreaBlocks37.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(38, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks37(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks37[elementId] = value;
		_modificationsAreaBlocks37.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(38, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks37(short elementId, DataContext context)
	{
		_areaBlocks37.Remove(elementId);
		_modificationsAreaBlocks37.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(38, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks37(DataContext context)
	{
		_areaBlocks37.Clear();
		_modificationsAreaBlocks37.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(38, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks38(short elementId)
	{
		return _areaBlocks38[elementId];
	}

	public bool TryGetElement_AreaBlocks38(short elementId, out MapBlockData value)
	{
		return _areaBlocks38.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks38(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks38.Add(elementId, value);
		_modificationsAreaBlocks38.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(39, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks38(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks38[elementId] = value;
		_modificationsAreaBlocks38.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(39, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks38(short elementId, DataContext context)
	{
		_areaBlocks38.Remove(elementId);
		_modificationsAreaBlocks38.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(39, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks38(DataContext context)
	{
		_areaBlocks38.Clear();
		_modificationsAreaBlocks38.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(39, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks39(short elementId)
	{
		return _areaBlocks39[elementId];
	}

	public bool TryGetElement_AreaBlocks39(short elementId, out MapBlockData value)
	{
		return _areaBlocks39.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks39(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks39.Add(elementId, value);
		_modificationsAreaBlocks39.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(40, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks39(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks39[elementId] = value;
		_modificationsAreaBlocks39.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(40, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks39(short elementId, DataContext context)
	{
		_areaBlocks39.Remove(elementId);
		_modificationsAreaBlocks39.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(40, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks39(DataContext context)
	{
		_areaBlocks39.Clear();
		_modificationsAreaBlocks39.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(40, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks40(short elementId)
	{
		return _areaBlocks40[elementId];
	}

	public bool TryGetElement_AreaBlocks40(short elementId, out MapBlockData value)
	{
		return _areaBlocks40.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks40(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks40.Add(elementId, value);
		_modificationsAreaBlocks40.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(41, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks40(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks40[elementId] = value;
		_modificationsAreaBlocks40.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(41, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks40(short elementId, DataContext context)
	{
		_areaBlocks40.Remove(elementId);
		_modificationsAreaBlocks40.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(41, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks40(DataContext context)
	{
		_areaBlocks40.Clear();
		_modificationsAreaBlocks40.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(41, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks41(short elementId)
	{
		return _areaBlocks41[elementId];
	}

	public bool TryGetElement_AreaBlocks41(short elementId, out MapBlockData value)
	{
		return _areaBlocks41.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks41(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks41.Add(elementId, value);
		_modificationsAreaBlocks41.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(42, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks41(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks41[elementId] = value;
		_modificationsAreaBlocks41.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(42, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks41(short elementId, DataContext context)
	{
		_areaBlocks41.Remove(elementId);
		_modificationsAreaBlocks41.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(42, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks41(DataContext context)
	{
		_areaBlocks41.Clear();
		_modificationsAreaBlocks41.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(42, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks42(short elementId)
	{
		return _areaBlocks42[elementId];
	}

	public bool TryGetElement_AreaBlocks42(short elementId, out MapBlockData value)
	{
		return _areaBlocks42.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks42(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks42.Add(elementId, value);
		_modificationsAreaBlocks42.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(43, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks42(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks42[elementId] = value;
		_modificationsAreaBlocks42.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(43, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks42(short elementId, DataContext context)
	{
		_areaBlocks42.Remove(elementId);
		_modificationsAreaBlocks42.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(43, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks42(DataContext context)
	{
		_areaBlocks42.Clear();
		_modificationsAreaBlocks42.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(43, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks43(short elementId)
	{
		return _areaBlocks43[elementId];
	}

	public bool TryGetElement_AreaBlocks43(short elementId, out MapBlockData value)
	{
		return _areaBlocks43.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks43(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks43.Add(elementId, value);
		_modificationsAreaBlocks43.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(44, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks43(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks43[elementId] = value;
		_modificationsAreaBlocks43.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(44, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks43(short elementId, DataContext context)
	{
		_areaBlocks43.Remove(elementId);
		_modificationsAreaBlocks43.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(44, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks43(DataContext context)
	{
		_areaBlocks43.Clear();
		_modificationsAreaBlocks43.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(44, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_AreaBlocks44(short elementId)
	{
		return _areaBlocks44[elementId];
	}

	public bool TryGetElement_AreaBlocks44(short elementId, out MapBlockData value)
	{
		return _areaBlocks44.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaBlocks44(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks44.Add(elementId, value);
		_modificationsAreaBlocks44.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(45, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaBlocks44(short elementId, MapBlockData value, DataContext context)
	{
		_areaBlocks44[elementId] = value;
		_modificationsAreaBlocks44.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(45, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaBlocks44(short elementId, DataContext context)
	{
		_areaBlocks44.Remove(elementId);
		_modificationsAreaBlocks44.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(45, DataStates, CacheInfluences, context);
	}

	private void ClearAreaBlocks44(DataContext context)
	{
		_areaBlocks44.Clear();
		_modificationsAreaBlocks44.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(45, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_BrokenAreaBlocks(short elementId)
	{
		return _brokenAreaBlocks[elementId];
	}

	public bool TryGetElement_BrokenAreaBlocks(short elementId, out MapBlockData value)
	{
		return _brokenAreaBlocks.TryGetValue(elementId, out value);
	}

	private void AddElement_BrokenAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_brokenAreaBlocks.Add(elementId, value);
		_modificationsBrokenAreaBlocks.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(46, DataStates, CacheInfluences, context);
	}

	private void SetElement_BrokenAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_brokenAreaBlocks[elementId] = value;
		_modificationsBrokenAreaBlocks.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(46, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_BrokenAreaBlocks(short elementId, DataContext context)
	{
		_brokenAreaBlocks.Remove(elementId);
		_modificationsBrokenAreaBlocks.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(46, DataStates, CacheInfluences, context);
	}

	private void ClearBrokenAreaBlocks(DataContext context)
	{
		_brokenAreaBlocks.Clear();
		_modificationsBrokenAreaBlocks.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(46, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_BornAreaBlocks(short elementId)
	{
		return _bornAreaBlocks[elementId];
	}

	public bool TryGetElement_BornAreaBlocks(short elementId, out MapBlockData value)
	{
		return _bornAreaBlocks.TryGetValue(elementId, out value);
	}

	private void AddElement_BornAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_bornAreaBlocks.Add(elementId, value);
		_modificationsBornAreaBlocks.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(47, DataStates, CacheInfluences, context);
	}

	private void SetElement_BornAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_bornAreaBlocks[elementId] = value;
		_modificationsBornAreaBlocks.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(47, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_BornAreaBlocks(short elementId, DataContext context)
	{
		_bornAreaBlocks.Remove(elementId);
		_modificationsBornAreaBlocks.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(47, DataStates, CacheInfluences, context);
	}

	private void ClearBornAreaBlocks(DataContext context)
	{
		_bornAreaBlocks.Clear();
		_modificationsBornAreaBlocks.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(47, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_GuideAreaBlocks(short elementId)
	{
		return _guideAreaBlocks[elementId];
	}

	public bool TryGetElement_GuideAreaBlocks(short elementId, out MapBlockData value)
	{
		return _guideAreaBlocks.TryGetValue(elementId, out value);
	}

	private void AddElement_GuideAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_guideAreaBlocks.Add(elementId, value);
		_modificationsGuideAreaBlocks.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(48, DataStates, CacheInfluences, context);
	}

	private void SetElement_GuideAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_guideAreaBlocks[elementId] = value;
		_modificationsGuideAreaBlocks.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(48, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_GuideAreaBlocks(short elementId, DataContext context)
	{
		_guideAreaBlocks.Remove(elementId);
		_modificationsGuideAreaBlocks.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(48, DataStates, CacheInfluences, context);
	}

	private void ClearGuideAreaBlocks(DataContext context)
	{
		_guideAreaBlocks.Clear();
		_modificationsGuideAreaBlocks.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(48, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_SecretVillageAreaBlocks(short elementId)
	{
		return _secretVillageAreaBlocks[elementId];
	}

	public bool TryGetElement_SecretVillageAreaBlocks(short elementId, out MapBlockData value)
	{
		return _secretVillageAreaBlocks.TryGetValue(elementId, out value);
	}

	private void AddElement_SecretVillageAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_secretVillageAreaBlocks.Add(elementId, value);
		_modificationsSecretVillageAreaBlocks.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(49, DataStates, CacheInfluences, context);
	}

	private void SetElement_SecretVillageAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_secretVillageAreaBlocks[elementId] = value;
		_modificationsSecretVillageAreaBlocks.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(49, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SecretVillageAreaBlocks(short elementId, DataContext context)
	{
		_secretVillageAreaBlocks.Remove(elementId);
		_modificationsSecretVillageAreaBlocks.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(49, DataStates, CacheInfluences, context);
	}

	private void ClearSecretVillageAreaBlocks(DataContext context)
	{
		_secretVillageAreaBlocks.Clear();
		_modificationsSecretVillageAreaBlocks.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(49, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_BrokenPerformAreaBlocks(short elementId)
	{
		return _brokenPerformAreaBlocks[elementId];
	}

	public bool TryGetElement_BrokenPerformAreaBlocks(short elementId, out MapBlockData value)
	{
		return _brokenPerformAreaBlocks.TryGetValue(elementId, out value);
	}

	private void AddElement_BrokenPerformAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_brokenPerformAreaBlocks.Add(elementId, value);
		_modificationsBrokenPerformAreaBlocks.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(50, DataStates, CacheInfluences, context);
	}

	private void SetElement_BrokenPerformAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_brokenPerformAreaBlocks[elementId] = value;
		_modificationsBrokenPerformAreaBlocks.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(50, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_BrokenPerformAreaBlocks(short elementId, DataContext context)
	{
		_brokenPerformAreaBlocks.Remove(elementId);
		_modificationsBrokenPerformAreaBlocks.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(50, DataStates, CacheInfluences, context);
	}

	private void ClearBrokenPerformAreaBlocks(DataContext context)
	{
		_brokenPerformAreaBlocks.Clear();
		_modificationsBrokenPerformAreaBlocks.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(50, DataStates, CacheInfluences, context);
	}

	public TravelRoute GetElement_TravelRouteDict(TravelRouteKey elementId)
	{
		return _travelRouteDict[elementId];
	}

	public bool TryGetElement_TravelRouteDict(TravelRouteKey elementId, out TravelRoute value)
	{
		return _travelRouteDict.TryGetValue(elementId, out value);
	}

	private void AddElement_TravelRouteDict(TravelRouteKey elementId, TravelRoute value, DataContext context)
	{
		_travelRouteDict.Add(elementId, value);
		_modificationsTravelRouteDict.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(51, DataStates, CacheInfluences, context);
	}

	private void SetElement_TravelRouteDict(TravelRouteKey elementId, TravelRoute value, DataContext context)
	{
		_travelRouteDict[elementId] = value;
		_modificationsTravelRouteDict.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(51, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_TravelRouteDict(TravelRouteKey elementId, DataContext context)
	{
		_travelRouteDict.Remove(elementId);
		_modificationsTravelRouteDict.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(51, DataStates, CacheInfluences, context);
	}

	private void ClearTravelRouteDict(DataContext context)
	{
		_travelRouteDict.Clear();
		_modificationsTravelRouteDict.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(51, DataStates, CacheInfluences, context);
	}

	public TravelRoute GetElement_BornStateTravelRouteDict(TravelRouteKey elementId)
	{
		return _bornStateTravelRouteDict[elementId];
	}

	public bool TryGetElement_BornStateTravelRouteDict(TravelRouteKey elementId, out TravelRoute value)
	{
		return _bornStateTravelRouteDict.TryGetValue(elementId, out value);
	}

	private void AddElement_BornStateTravelRouteDict(TravelRouteKey elementId, TravelRoute value, DataContext context)
	{
		_bornStateTravelRouteDict.Add(elementId, value);
		_modificationsBornStateTravelRouteDict.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(52, DataStates, CacheInfluences, context);
	}

	private void SetElement_BornStateTravelRouteDict(TravelRouteKey elementId, TravelRoute value, DataContext context)
	{
		_bornStateTravelRouteDict[elementId] = value;
		_modificationsBornStateTravelRouteDict.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(52, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_BornStateTravelRouteDict(TravelRouteKey elementId, DataContext context)
	{
		_bornStateTravelRouteDict.Remove(elementId);
		_modificationsBornStateTravelRouteDict.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(52, DataStates, CacheInfluences, context);
	}

	private void ClearBornStateTravelRouteDict(DataContext context)
	{
		_bornStateTravelRouteDict.Clear();
		_modificationsBornStateTravelRouteDict.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(52, DataStates, CacheInfluences, context);
	}

	public CricketPlaceData GetElement_CricketPlaceData(int index)
	{
		return _cricketPlaceData[index];
	}

	private void SetElement_CricketPlaceData(int index, CricketPlaceData value, DataContext context)
	{
		_cricketPlaceData[index] = value;
		SetModifiedAndInvalidateInfluencedCache(index, _dataStatesCricketPlaceData, CacheInfluencesCricketPlaceData, context);
	}

	private GameData.Utilities.ShortList GetElement_RegularAreaNearList(short elementId)
	{
		return _regularAreaNearList[elementId];
	}

	private bool TryGetElement_RegularAreaNearList(short elementId, out GameData.Utilities.ShortList value)
	{
		return _regularAreaNearList.TryGetValue(elementId, out value);
	}

	private void AddElement_RegularAreaNearList(short elementId, GameData.Utilities.ShortList value, DataContext context)
	{
		_regularAreaNearList.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(54, DataStates, CacheInfluences, context);
	}

	private void SetElement_RegularAreaNearList(short elementId, GameData.Utilities.ShortList value, DataContext context)
	{
		_regularAreaNearList[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(54, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_RegularAreaNearList(short elementId, DataContext context)
	{
		_regularAreaNearList.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(54, DataStates, CacheInfluences, context);
	}

	private void ClearRegularAreaNearList(DataContext context)
	{
		_regularAreaNearList.Clear();
		SetModifiedAndInvalidateInfluencedCache(54, DataStates, CacheInfluences, context);
	}

	public Location GetElement_SwordTombLocations(int index)
	{
		return _swordTombLocations[index];
	}

	public void SetElement_SwordTombLocations(int index, Location value, DataContext context)
	{
		_swordTombLocations[index] = value;
		SetModifiedAndInvalidateInfluencedCache(index, _dataStatesSwordTombLocations, CacheInfluencesSwordTombLocations, context);
	}

	public CrossAreaMoveInfo GetTravelInfo()
	{
		return _travelInfo;
	}

	private void SetTravelInfo(CrossAreaMoveInfo value, DataContext context)
	{
		_travelInfo = value;
		SetModifiedAndInvalidateInfluencedCache(56, DataStates, CacheInfluences, context);
	}

	public bool GetOnHandlingTravelingEventBlock()
	{
		return _onHandlingTravelingEventBlock;
	}

	public void SetOnHandlingTravelingEventBlock(bool value, DataContext context)
	{
		_onHandlingTravelingEventBlock = value;
		SetModifiedAndInvalidateInfluencedCache(57, DataStates, CacheInfluences, context);
	}

	public List<HunterAnimalKey> GetHunterAnimals()
	{
		return _hunterAnimals;
	}

	private void SetHunterAnimals(List<HunterAnimalKey> value, DataContext context)
	{
		_hunterAnimals = value;
		SetModifiedAndInvalidateInfluencedCache(58, DataStates, CacheInfluences, context);
	}

	public int GetMoveBanned()
	{
		return _moveBanned;
	}

	private void SetMoveBanned(int value, DataContext context)
	{
		_moveBanned = value;
		SetModifiedAndInvalidateInfluencedCache(59, DataStates, CacheInfluences, context);
	}

	public bool GetCrossArchiveLockMoveTime()
	{
		return _crossArchiveLockMoveTime;
	}

	public void SetCrossArchiveLockMoveTime(bool value, DataContext context)
	{
		_crossArchiveLockMoveTime = value;
		SetModifiedAndInvalidateInfluencedCache(60, DataStates, CacheInfluences, context);
	}

	public List<Location> GetFleeBeasts()
	{
		Thread.MemoryBarrier();
		if (BaseGameDataDomain.IsCached(DataStates, 61))
		{
			return _fleeBeasts;
		}
		List<Location> value = new List<Location>();
		CalcFleeBeasts(value);
		bool lockTaken = false;
		try
		{
			_spinLockFleeBeasts.Enter(ref lockTaken);
			_fleeBeasts.Assign(value);
			BaseGameDataDomain.SetCached(DataStates, 61);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLockFleeBeasts.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _fleeBeasts;
	}

	public List<Location> GetFleeLoongs()
	{
		Thread.MemoryBarrier();
		if (BaseGameDataDomain.IsCached(DataStates, 62))
		{
			return _fleeLoongs;
		}
		List<Location> value = new List<Location>();
		CalcFleeLoongs(value);
		bool lockTaken = false;
		try
		{
			_spinLockFleeLoongs.Enter(ref lockTaken);
			_fleeLoongs.Assign(value);
			BaseGameDataDomain.SetCached(DataStates, 62);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLockFleeLoongs.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _fleeLoongs;
	}

	public List<LoongLocationData> GetLoongLocations()
	{
		Thread.MemoryBarrier();
		if (BaseGameDataDomain.IsCached(DataStates, 63))
		{
			return _loongLocations;
		}
		List<LoongLocationData> value = new List<LoongLocationData>();
		CalcLoongLocations(value);
		bool lockTaken = false;
		try
		{
			_spinLockLoongLocations.Enter(ref lockTaken);
			_loongLocations.Assign(value);
			BaseGameDataDomain.SetCached(DataStates, 63);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLockLoongLocations.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _loongLocations;
	}

	public List<Location> GetAlterSettlementLocations()
	{
		Thread.MemoryBarrier();
		if (BaseGameDataDomain.IsCached(DataStates, 64))
		{
			return _alterSettlementLocations;
		}
		List<Location> value = new List<Location>();
		CalcAlterSettlementLocations(value);
		bool lockTaken = false;
		try
		{
			_spinLockAlterSettlementLocations.Enter(ref lockTaken);
			_alterSettlementLocations.Assign(value);
			BaseGameDataDomain.SetCached(DataStates, 64);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLockAlterSettlementLocations.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _alterSettlementLocations;
	}

	public bool GetIsTaiwuInFulongFlameArea()
	{
		return _isTaiwuInFulongFlameArea;
	}

	public void SetIsTaiwuInFulongFlameArea(bool value, DataContext context)
	{
		_isTaiwuInFulongFlameArea = value;
		SetModifiedAndInvalidateInfluencedCache(65, DataStates, CacheInfluences, context);
	}

	public List<MapElementPickupDisplayData> GetVisibleMapPickups()
	{
		Thread.MemoryBarrier();
		if (BaseGameDataDomain.IsCached(DataStates, 66))
		{
			return _visibleMapPickups;
		}
		List<MapElementPickupDisplayData> value = new List<MapElementPickupDisplayData>();
		CalcVisibleMapPickups(value);
		bool lockTaken = false;
		try
		{
			_spinLockVisibleMapPickups.Enter(ref lockTaken);
			_visibleMapPickups.Assign(value);
			BaseGameDataDomain.SetCached(DataStates, 66);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLockVisibleMapPickups.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _visibleMapPickups;
	}

	public BrokenAreaData GetElement_BrokenAreaEnemies(int index)
	{
		return _brokenAreaEnemies[index];
	}

	private void SetElement_BrokenAreaEnemies(int index, BrokenAreaData value, DataContext context)
	{
		_brokenAreaEnemies[index] = value;
		SetModifiedAndInvalidateInfluencedCache(index, _dataStatesBrokenAreaEnemies, CacheInfluencesBrokenAreaEnemies, context);
	}

	public XiangshuInfectedDemonData GetElement_StateXiangshuInfectedDemons(int index)
	{
		return _stateXiangshuInfectedDemons[index];
	}

	private void SetElement_StateXiangshuInfectedDemons(int index, XiangshuInfectedDemonData value, DataContext context)
	{
		_stateXiangshuInfectedDemons[index] = value;
		SetModifiedAndInvalidateInfluencedCache(index, _dataStatesStateXiangshuInfectedDemons, CacheInfluencesStateXiangshuInfectedDemons, context);
	}

	private MapBlockFindData GetElement_MapBlockFindDataPresets(int index)
	{
		return _mapBlockFindDataPresets[index];
	}

	private void SetElement_MapBlockFindDataPresets(int index, MapBlockFindData value, DataContext context)
	{
		_mapBlockFindDataPresets[index] = value;
		SetModifiedAndInvalidateInfluencedCache(index, _dataStatesMapBlockFindDataPresets, CacheInfluencesMapBlockFindDataPresets, context);
	}

	public MapBlockData GetElement_PastTaiwuVillageAreaBlocks(short elementId)
	{
		return _pastTaiwuVillageAreaBlocks[elementId];
	}

	public bool TryGetElement_PastTaiwuVillageAreaBlocks(short elementId, out MapBlockData value)
	{
		return _pastTaiwuVillageAreaBlocks.TryGetValue(elementId, out value);
	}

	private void AddElement_PastTaiwuVillageAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_pastTaiwuVillageAreaBlocks.Add(elementId, value);
		_modificationsPastTaiwuVillageAreaBlocks.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(70, DataStates, CacheInfluences, context);
	}

	private void SetElement_PastTaiwuVillageAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_pastTaiwuVillageAreaBlocks[elementId] = value;
		_modificationsPastTaiwuVillageAreaBlocks.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(70, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_PastTaiwuVillageAreaBlocks(short elementId, DataContext context)
	{
		_pastTaiwuVillageAreaBlocks.Remove(elementId);
		_modificationsPastTaiwuVillageAreaBlocks.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(70, DataStates, CacheInfluences, context);
	}

	private void ClearPastTaiwuVillageAreaBlocks(DataContext context)
	{
		_pastTaiwuVillageAreaBlocks.Clear();
		_modificationsPastTaiwuVillageAreaBlocks.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(70, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _pastTaiwuVillageLockMoveTime is no longer in use.")]
	public bool GetPastTaiwuVillageLockMoveTime()
	{
		return _pastTaiwuVillageLockMoveTime;
	}

	[Obsolete("DomainData _pastTaiwuVillageLockMoveTime is no longer in use.")]
	public void SetPastTaiwuVillageLockMoveTime(bool value, DataContext context)
	{
		_pastTaiwuVillageLockMoveTime = value;
		SetModifiedAndInvalidateInfluencedCache(71, DataStates, CacheInfluences, context);
	}

	public MapBlockData GetElement_ChaishanAreaBlocks(short elementId)
	{
		return _chaishanAreaBlocks[elementId];
	}

	public bool TryGetElement_ChaishanAreaBlocks(short elementId, out MapBlockData value)
	{
		return _chaishanAreaBlocks.TryGetValue(elementId, out value);
	}

	private void AddElement_ChaishanAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_chaishanAreaBlocks.Add(elementId, value);
		_modificationsChaishanAreaBlocks.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(72, DataStates, CacheInfluences, context);
	}

	private void SetElement_ChaishanAreaBlocks(short elementId, MapBlockData value, DataContext context)
	{
		_chaishanAreaBlocks[elementId] = value;
		_modificationsChaishanAreaBlocks.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(72, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_ChaishanAreaBlocks(short elementId, DataContext context)
	{
		_chaishanAreaBlocks.Remove(elementId);
		_modificationsChaishanAreaBlocks.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(72, DataStates, CacheInfluences, context);
	}

	private void ClearChaishanAreaBlocks(DataContext context)
	{
		_chaishanAreaBlocks.Clear();
		_modificationsChaishanAreaBlocks.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(72, DataStates, CacheInfluences, context);
	}

	private VoidValue GetElement_ArrivedSize2Blocks(Location elementId)
	{
		return _arrivedSize2Blocks[elementId];
	}

	private bool TryGetElement_ArrivedSize2Blocks(Location elementId, out VoidValue value)
	{
		return _arrivedSize2Blocks.TryGetValue(elementId, out value);
	}

	private void AddElement_ArrivedSize2Blocks(Location elementId, VoidValue value, DataContext context)
	{
		_arrivedSize2Blocks.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(73, DataStates, CacheInfluences, context);
	}

	private void SetElement_ArrivedSize2Blocks(Location elementId, VoidValue value, DataContext context)
	{
		_arrivedSize2Blocks[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(73, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_ArrivedSize2Blocks(Location elementId, DataContext context)
	{
		_arrivedSize2Blocks.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(73, DataStates, CacheInfluences, context);
	}

	private void ClearArrivedSize2Blocks(DataContext context)
	{
		_arrivedSize2Blocks.Clear();
		SetModifiedAndInvalidateInfluencedCache(73, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _locationNaturalDisasterDate is no longer in use.")]
	public int GetElement_LocationNaturalDisasterDate(Location elementId)
	{
		return _locationNaturalDisasterDate[elementId];
	}

	[Obsolete("DomainData _locationNaturalDisasterDate is no longer in use.")]
	public bool TryGetElement_LocationNaturalDisasterDate(Location elementId, out int value)
	{
		return _locationNaturalDisasterDate.TryGetValue(elementId, out value);
	}

	[Obsolete("DomainData _locationNaturalDisasterDate is no longer in use.")]
	private void AddElement_LocationNaturalDisasterDate(Location elementId, int value, DataContext context)
	{
		_locationNaturalDisasterDate.Add(elementId, value);
		_modificationsLocationNaturalDisasterDate.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(74, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _locationNaturalDisasterDate is no longer in use.")]
	private void SetElement_LocationNaturalDisasterDate(Location elementId, int value, DataContext context)
	{
		_locationNaturalDisasterDate[elementId] = value;
		_modificationsLocationNaturalDisasterDate.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(74, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _locationNaturalDisasterDate is no longer in use.")]
	private void RemoveElement_LocationNaturalDisasterDate(Location elementId, DataContext context)
	{
		_locationNaturalDisasterDate.Remove(elementId);
		_modificationsLocationNaturalDisasterDate.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(74, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _locationNaturalDisasterDate is no longer in use.")]
	private void ClearLocationNaturalDisasterDate(DataContext context)
	{
		_locationNaturalDisasterDate.Clear();
		_modificationsLocationNaturalDisasterDate.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(74, DataStates, CacheInfluences, context);
	}

	public int GetElement_LocationNaturalDisasterDateNew(Location elementId)
	{
		return _locationNaturalDisasterDateNew[elementId];
	}

	public bool TryGetElement_LocationNaturalDisasterDateNew(Location elementId, out int value)
	{
		return _locationNaturalDisasterDateNew.TryGetValue(elementId, out value);
	}

	private void AddElement_LocationNaturalDisasterDateNew(Location elementId, int value, DataContext context)
	{
		_locationNaturalDisasterDateNew.Add(elementId, value);
		_modificationsLocationNaturalDisasterDateNew.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(75, DataStates, CacheInfluences, context);
	}

	private void SetElement_LocationNaturalDisasterDateNew(Location elementId, int value, DataContext context)
	{
		_locationNaturalDisasterDateNew[elementId] = value;
		_modificationsLocationNaturalDisasterDateNew.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(75, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_LocationNaturalDisasterDateNew(Location elementId, DataContext context)
	{
		_locationNaturalDisasterDateNew.Remove(elementId);
		_modificationsLocationNaturalDisasterDateNew.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(75, DataStates, CacheInfluences, context);
	}

	private void ClearLocationNaturalDisasterDateNew(DataContext context)
	{
		_locationNaturalDisasterDateNew.Clear();
		_modificationsLocationNaturalDisasterDateNew.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(75, DataStates, CacheInfluences, context);
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
		archive.WriteSingleValueUnmanaged((ushort)65);
		archive.WriteDomainDataMeta(0);
		archive.WriteElementListCustom(_areas);
		archive.WriteDomainDataMeta(1);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks0);
		archive.WriteDomainDataMeta(2);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks1);
		archive.WriteDomainDataMeta(3);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks2);
		archive.WriteDomainDataMeta(4);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks3);
		archive.WriteDomainDataMeta(5);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks4);
		archive.WriteDomainDataMeta(6);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks5);
		archive.WriteDomainDataMeta(7);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks6);
		archive.WriteDomainDataMeta(8);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks7);
		archive.WriteDomainDataMeta(9);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks8);
		archive.WriteDomainDataMeta(10);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks9);
		archive.WriteDomainDataMeta(11);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks10);
		archive.WriteDomainDataMeta(12);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks11);
		archive.WriteDomainDataMeta(13);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks12);
		archive.WriteDomainDataMeta(14);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks13);
		archive.WriteDomainDataMeta(15);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks14);
		archive.WriteDomainDataMeta(16);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks15);
		archive.WriteDomainDataMeta(17);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks16);
		archive.WriteDomainDataMeta(18);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks17);
		archive.WriteDomainDataMeta(19);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks18);
		archive.WriteDomainDataMeta(20);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks19);
		archive.WriteDomainDataMeta(21);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks20);
		archive.WriteDomainDataMeta(22);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks21);
		archive.WriteDomainDataMeta(23);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks22);
		archive.WriteDomainDataMeta(24);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks23);
		archive.WriteDomainDataMeta(25);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks24);
		archive.WriteDomainDataMeta(26);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks25);
		archive.WriteDomainDataMeta(27);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks26);
		archive.WriteDomainDataMeta(28);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks27);
		archive.WriteDomainDataMeta(29);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks28);
		archive.WriteDomainDataMeta(30);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks29);
		archive.WriteDomainDataMeta(31);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks30);
		archive.WriteDomainDataMeta(32);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks31);
		archive.WriteDomainDataMeta(33);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks32);
		archive.WriteDomainDataMeta(34);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks33);
		archive.WriteDomainDataMeta(35);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks34);
		archive.WriteDomainDataMeta(36);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks35);
		archive.WriteDomainDataMeta(37);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks36);
		archive.WriteDomainDataMeta(38);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks37);
		archive.WriteDomainDataMeta(39);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks38);
		archive.WriteDomainDataMeta(40);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks39);
		archive.WriteDomainDataMeta(41);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks40);
		archive.WriteDomainDataMeta(42);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks41);
		archive.WriteDomainDataMeta(43);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks42);
		archive.WriteDomainDataMeta(44);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks43);
		archive.WriteDomainDataMeta(45);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks44);
		archive.WriteDomainDataMeta(46);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_brokenAreaBlocks);
		archive.WriteDomainDataMeta(47);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_bornAreaBlocks);
		archive.WriteDomainDataMeta(48);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_guideAreaBlocks);
		archive.WriteDomainDataMeta(49);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_secretVillageAreaBlocks);
		archive.WriteDomainDataMeta(50);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_brokenPerformAreaBlocks);
		archive.WriteDomainDataMeta(51);
		archive.WriteSingleValueCollectionCustomKeyValue(_travelRouteDict);
		archive.WriteDomainDataMeta(52);
		archive.WriteSingleValueCollectionCustomKeyValue(_bornStateTravelRouteDict);
		archive.WriteDomainDataMeta(53);
		archive.WriteElementListCustom(_cricketPlaceData);
		archive.WriteDomainDataMeta(54);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_regularAreaNearList);
		archive.WriteDomainDataMeta(55);
		archive.WriteElementListCustom(_swordTombLocations);
		archive.WriteDomainDataMeta(56);
		archive.WriteSingleValueCustom(_travelInfo);
		archive.WriteDomainDataMeta(58);
		archive.WriteSingleValueCustomList(_hunterAnimals);
		archive.WriteDomainDataMeta(67);
		archive.WriteElementListCustom(_brokenAreaEnemies);
		archive.WriteDomainDataMeta(68);
		archive.WriteElementListCustom(_stateXiangshuInfectedDemons);
		archive.WriteDomainDataMeta(69);
		archive.WriteElementListCustom(_mapBlockFindDataPresets);
		archive.WriteDomainDataMeta(70);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_pastTaiwuVillageAreaBlocks);
		archive.WriteDomainDataMeta(72);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_chaishanAreaBlocks);
		archive.WriteDomainDataMeta(73);
		archive.WriteSingleValueCollectionCustomKeyValue(_arrivedSize2Blocks);
		archive.WriteDomainDataMeta(75);
		archive.WriteSingleValueCollectionCustomKeyUnmanagedValue(_locationNaturalDisasterDateNew);
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
				archive.ReadElementListCustom(_areas);
				break;
			case 1:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks0);
				break;
			case 2:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks1);
				break;
			case 3:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks2);
				break;
			case 4:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks3);
				break;
			case 5:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks4);
				break;
			case 6:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks5);
				break;
			case 7:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks6);
				break;
			case 8:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks7);
				break;
			case 9:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks8);
				break;
			case 10:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks9);
				break;
			case 11:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks10);
				break;
			case 12:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks11);
				break;
			case 13:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks12);
				break;
			case 14:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks13);
				break;
			case 15:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks14);
				break;
			case 16:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks15);
				break;
			case 17:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks16);
				break;
			case 18:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks17);
				break;
			case 19:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks18);
				break;
			case 20:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks19);
				break;
			case 21:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks20);
				break;
			case 22:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks21);
				break;
			case 23:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks22);
				break;
			case 24:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks23);
				break;
			case 25:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks24);
				break;
			case 26:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks25);
				break;
			case 27:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks26);
				break;
			case 28:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks27);
				break;
			case 29:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks28);
				break;
			case 30:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks29);
				break;
			case 31:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks30);
				break;
			case 32:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks31);
				break;
			case 33:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks32);
				break;
			case 34:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks33);
				break;
			case 35:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks34);
				break;
			case 36:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks35);
				break;
			case 37:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks36);
				break;
			case 38:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks37);
				break;
			case 39:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks38);
				break;
			case 40:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks39);
				break;
			case 41:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks40);
				break;
			case 42:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks41);
				break;
			case 43:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks42);
				break;
			case 44:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks43);
				break;
			case 45:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_areaBlocks44);
				break;
			case 46:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_brokenAreaBlocks);
				break;
			case 47:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_bornAreaBlocks);
				break;
			case 48:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_guideAreaBlocks);
				break;
			case 49:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_secretVillageAreaBlocks);
				break;
			case 50:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_brokenPerformAreaBlocks);
				break;
			case 51:
				archive.ReadSingleValueCollectionCustomKeyValue(_travelRouteDict);
				break;
			case 52:
				archive.ReadSingleValueCollectionCustomKeyValue(_bornStateTravelRouteDict);
				break;
			case 53:
				archive.ReadElementListCustom(_cricketPlaceData);
				break;
			case 54:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_regularAreaNearList);
				break;
			case 55:
				archive.ReadElementListCustom(_swordTombLocations);
				break;
			case 56:
				archive.ReadSingleValueCustom(ref _travelInfo);
				break;
			case 58:
				archive.ReadSingleValueCustomList(ref _hunterAnimals);
				break;
			case 67:
				archive.ReadElementListCustom(_brokenAreaEnemies);
				break;
			case 68:
				archive.ReadElementListCustom(_stateXiangshuInfectedDemons);
				break;
			case 69:
				archive.ReadElementListCustom(_mapBlockFindDataPresets);
				break;
			case 70:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_pastTaiwuVillageAreaBlocks);
				break;
			case 72:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_chaishanAreaBlocks);
				break;
			case 73:
				archive.ReadSingleValueCollectionCustomKeyValue(_arrivedSize2Blocks);
				break;
			case 74:
				archive.ReadSingleValueCollectionCustomKeyUnmanagedValue(_locationNaturalDisasterDate, skip: true);
				break;
			case 75:
				archive.ReadSingleValueCollectionCustomKeyUnmanagedValue(_locationNaturalDisasterDateNew);
				break;
			default:
				throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
			}
			RecordLoadedDomainData(domainDataMeta.DataId);
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(2);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(_dataStatesAreas, (int)subId0);
			}
			return GameData.Serializer.Serializer.Serialize(_areas[(uint)subId0], dataPool);
		case 1:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
				_modificationsAreaBlocks0.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks0, dataPool);
		case 2:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
				_modificationsAreaBlocks1.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks1, dataPool);
		case 3:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
				_modificationsAreaBlocks2.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks2, dataPool);
		case 4:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
				_modificationsAreaBlocks3.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks3, dataPool);
		case 5:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
				_modificationsAreaBlocks4.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks4, dataPool);
		case 6:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 6);
				_modificationsAreaBlocks5.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks5, dataPool);
		case 7:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
				_modificationsAreaBlocks6.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks6, dataPool);
		case 8:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
				_modificationsAreaBlocks7.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks7, dataPool);
		case 9:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
				_modificationsAreaBlocks8.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks8, dataPool);
		case 10:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 10);
				_modificationsAreaBlocks9.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks9, dataPool);
		case 11:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
				_modificationsAreaBlocks10.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks10, dataPool);
		case 12:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 12);
				_modificationsAreaBlocks11.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks11, dataPool);
		case 13:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 13);
				_modificationsAreaBlocks12.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks12, dataPool);
		case 14:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 14);
				_modificationsAreaBlocks13.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks13, dataPool);
		case 15:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 15);
				_modificationsAreaBlocks14.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks14, dataPool);
		case 16:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 16);
				_modificationsAreaBlocks15.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks15, dataPool);
		case 17:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 17);
				_modificationsAreaBlocks16.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks16, dataPool);
		case 18:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 18);
				_modificationsAreaBlocks17.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks17, dataPool);
		case 19:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 19);
				_modificationsAreaBlocks18.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks18, dataPool);
		case 20:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 20);
				_modificationsAreaBlocks19.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks19, dataPool);
		case 21:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 21);
				_modificationsAreaBlocks20.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks20, dataPool);
		case 22:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 22);
				_modificationsAreaBlocks21.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks21, dataPool);
		case 23:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 23);
				_modificationsAreaBlocks22.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks22, dataPool);
		case 24:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 24);
				_modificationsAreaBlocks23.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks23, dataPool);
		case 25:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 25);
				_modificationsAreaBlocks24.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks24, dataPool);
		case 26:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 26);
				_modificationsAreaBlocks25.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks25, dataPool);
		case 27:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 27);
				_modificationsAreaBlocks26.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks26, dataPool);
		case 28:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 28);
				_modificationsAreaBlocks27.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks27, dataPool);
		case 29:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 29);
				_modificationsAreaBlocks28.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks28, dataPool);
		case 30:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 30);
				_modificationsAreaBlocks29.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks29, dataPool);
		case 31:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 31);
				_modificationsAreaBlocks30.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks30, dataPool);
		case 32:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 32);
				_modificationsAreaBlocks31.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks31, dataPool);
		case 33:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 33);
				_modificationsAreaBlocks32.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks32, dataPool);
		case 34:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 34);
				_modificationsAreaBlocks33.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks33, dataPool);
		case 35:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 35);
				_modificationsAreaBlocks34.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks34, dataPool);
		case 36:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 36);
				_modificationsAreaBlocks35.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks35, dataPool);
		case 37:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 37);
				_modificationsAreaBlocks36.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks36, dataPool);
		case 38:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 38);
				_modificationsAreaBlocks37.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks37, dataPool);
		case 39:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 39);
				_modificationsAreaBlocks38.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks38, dataPool);
		case 40:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 40);
				_modificationsAreaBlocks39.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks39, dataPool);
		case 41:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 41);
				_modificationsAreaBlocks40.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks40, dataPool);
		case 42:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 42);
				_modificationsAreaBlocks41.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks41, dataPool);
		case 43:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 43);
				_modificationsAreaBlocks42.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks42, dataPool);
		case 44:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 44);
				_modificationsAreaBlocks43.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks43, dataPool);
		case 45:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 45);
				_modificationsAreaBlocks44.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaBlocks44, dataPool);
		case 46:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 46);
				_modificationsBrokenAreaBlocks.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_brokenAreaBlocks, dataPool);
		case 47:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 47);
				_modificationsBornAreaBlocks.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_bornAreaBlocks, dataPool);
		case 48:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 48);
				_modificationsGuideAreaBlocks.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_guideAreaBlocks, dataPool);
		case 49:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 49);
				_modificationsSecretVillageAreaBlocks.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_secretVillageAreaBlocks, dataPool);
		case 50:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 50);
				_modificationsBrokenPerformAreaBlocks.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_brokenPerformAreaBlocks, dataPool);
		case 51:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 51);
				_modificationsTravelRouteDict.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_travelRouteDict, dataPool);
		case 52:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 52);
				_modificationsBornStateTravelRouteDict.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_bornStateTravelRouteDict, dataPool);
		case 53:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(_dataStatesCricketPlaceData, (int)subId0);
			}
			return GameData.Serializer.Serializer.Serialize(_cricketPlaceData[(uint)subId0], dataPool);
		case 54:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 55:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(_dataStatesSwordTombLocations, (int)subId0);
			}
			return GameData.Serializer.Serializer.Serialize(_swordTombLocations[(uint)subId0], dataPool);
		case 56:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 56);
			}
			return GameData.Serializer.Serializer.Serialize(_travelInfo, dataPool);
		case 57:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 57);
			}
			return GameData.Serializer.Serializer.Serialize(_onHandlingTravelingEventBlock, dataPool);
		case 58:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 58);
			}
			return GameData.Serializer.Serializer.Serialize(_hunterAnimals, dataPool);
		case 59:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 59);
			}
			return GameData.Serializer.Serializer.Serialize(_moveBanned, dataPool);
		case 60:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 60);
			}
			return GameData.Serializer.Serializer.Serialize(_crossArchiveLockMoveTime, dataPool);
		case 61:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 61);
			}
			return GameData.Serializer.Serializer.Serialize(GetFleeBeasts(), dataPool);
		case 62:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 62);
			}
			return GameData.Serializer.Serializer.Serialize(GetFleeLoongs(), dataPool);
		case 63:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 63);
			}
			return GameData.Serializer.Serializer.Serialize(GetLoongLocations(), dataPool);
		case 64:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 64);
			}
			return GameData.Serializer.Serializer.Serialize(GetAlterSettlementLocations(), dataPool);
		case 65:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 65);
			}
			return GameData.Serializer.Serializer.Serialize(_isTaiwuInFulongFlameArea, dataPool);
		case 66:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 66);
			}
			return GameData.Serializer.Serializer.Serialize(GetVisibleMapPickups(), dataPool);
		case 67:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(_dataStatesBrokenAreaEnemies, (int)subId0);
			}
			return GameData.Serializer.Serializer.Serialize(_brokenAreaEnemies[(uint)subId0], dataPool);
		case 68:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(_dataStatesStateXiangshuInfectedDemons, (int)subId0);
			}
			return GameData.Serializer.Serializer.Serialize(_stateXiangshuInfectedDemons[(uint)subId0], dataPool);
		case 69:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 70:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 70);
				_modificationsPastTaiwuVillageAreaBlocks.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_pastTaiwuVillageAreaBlocks, dataPool);
		case 71:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 71);
			}
			return GameData.Serializer.Serializer.Serialize(_pastTaiwuVillageLockMoveTime, dataPool);
		case 72:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 72);
				_modificationsChaishanAreaBlocks.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_chaishanAreaBlocks, dataPool);
		case 73:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 74:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 74);
				_modificationsLocationNaturalDisasterDate.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_locationNaturalDisasterDate, dataPool);
		case 75:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 75);
				_modificationsLocationNaturalDisasterDateNew.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_locationNaturalDisasterDateNew, dataPool);
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
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 12:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 13:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 14:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 15:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 16:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 17:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 18:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 19:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 20:
			throw new Exception($"Not allow to set value of dataId {dataId}");
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
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 27:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 28:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 29:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 30:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 31:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 32:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 33:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 34:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 35:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 36:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 37:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 38:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 39:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 40:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 41:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 42:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 43:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 44:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 45:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 46:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 47:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 48:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 49:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 50:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 51:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 52:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 53:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 54:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 55:
		{
			Location value = default(Location);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			_swordTombLocations[(uint)subId0] = value;
			SetElement_SwordTombLocations((int)subId0, value, context);
			break;
		}
		case 56:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 57:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _onHandlingTravelingEventBlock);
			SetOnHandlingTravelingEventBlock(_onHandlingTravelingEventBlock, context);
			break;
		case 58:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 59:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 60:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _crossArchiveLockMoveTime);
			SetCrossArchiveLockMoveTime(_crossArchiveLockMoveTime, context);
			break;
		case 61:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 62:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 63:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 64:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 65:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _isTaiwuInFulongFlameArea);
			SetIsTaiwuInFulongFlameArea(_isTaiwuInFulongFlameArea, context);
			break;
		case 66:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 67:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 68:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 69:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 70:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 71:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _pastTaiwuVillageLockMoveTime);
			SetPastTaiwuVillageLockMoveTime(_pastTaiwuVillageLockMoveTime, context);
			break;
		case 72:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 73:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 74:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 75:
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
			int argsCount32 = operation.ArgsCount;
			int num32 = argsCount32;
			if (num32 == 1)
			{
				bool isLock = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isLock);
				GmCmd_SetLockTime(isLock);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 1)
			{
				bool teleportOn = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref teleportOn);
				GmCmd_SetTeleportMove(teleportOn);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
			if (operation.ArgsCount == 0)
			{
				GmCmd_ShowAllMapBlock(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 3:
			if (operation.ArgsCount == 0)
			{
				GmCmd_UnlockAllStation(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 4:
		{
			int argsCount19 = operation.ArgsCount;
			int num19 = argsCount19;
			if (num19 == 2)
			{
				short areaId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId3);
				int spiritualDebt = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref spiritualDebt);
				GmCmd_ChangeSpiritualDebt(context, areaId3, spiritualDebt);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 5:
		{
			int argsCount44 = operation.ArgsCount;
			int num44 = argsCount44;
			if (num44 == 1)
			{
				MapBlockData mapBlockData = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref mapBlockData);
				GmCmd_SetMapBlockData(context, mapBlockData);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 6:
		{
			int argsCount22 = operation.ArgsCount;
			int num22 = argsCount22;
			if (num22 == 1)
			{
				short templateId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId4);
				GmCmd_CreateFixedCharacterAtCurrentBlock(context, templateId4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 7:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 1)
			{
				short destBlockId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref destBlockId);
				Move(context, destBlockId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 8:
		{
			int argsCount38 = operation.ArgsCount;
			int num38 = argsCount38;
			if (num38 == 2)
			{
				Location previous = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref previous);
				Location current = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref current);
				MoveFinish(context, previous, current);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 9:
			if (operation.ArgsCount == 0)
			{
				bool returnValue29 = IsContinuousMovingBreak();
				return GameData.Serializer.Serializer.Serialize(returnValue29, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 10:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				short areaId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId6);
				UnlockStation(context, areaId6);
				return -1;
			}
			case 2:
			{
				short areaId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId5);
				bool costAuthority = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref costAuthority);
				UnlockStation(context, areaId5, costAuthority);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 11:
		{
			int argsCount15 = operation.ArgsCount;
			int num15 = argsCount15;
			if (num15 == 3)
			{
				short fromAreaId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref fromAreaId);
				short fromBlockId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref fromBlockId);
				short toAreaId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toAreaId2);
				CrossAreaMoveInfo returnValue14 = GetTravelCost(fromAreaId, fromBlockId, toAreaId2);
				return GameData.Serializer.Serializer.Serialize(returnValue14, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
		{
			int argsCount49 = operation.ArgsCount;
			int num49 = argsCount49;
			if (num49 == 1)
			{
				short toAreaId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toAreaId4);
				StartTravel(context, toAreaId4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 13:
			if (operation.ArgsCount == 0)
			{
				bool returnValue40 = ContinueTravel(context);
				return GameData.Serializer.Serializer.Serialize(returnValue40, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 14:
			if (operation.ArgsCount == 0)
			{
				StopTravel(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 15:
		{
			int argsCount28 = operation.ArgsCount;
			int num28 = argsCount28;
			if (num28 == 1)
			{
				int costedDays = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref costedDays);
				RecordTravelCostedDays(context, costedDays);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 16:
			if (operation.ArgsCount == 0)
			{
				int[] returnValue21 = GetAllAreaCompletelyInfectedCharCount();
				return GameData.Serializer.Serializer.Serialize(returnValue21, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 17:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 1)
			{
				sbyte stateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref stateId);
				Dictionary<TravelRouteKey, TravelRoute> returnValue11 = GetTravelRoutesInState(stateId);
				return GameData.Serializer.Serializer.Serialize(returnValue11, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 18:
			if (operation.ArgsCount == 0)
			{
				bool returnValue2 = TryTriggerCricketCatch(context);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 19:
		{
			int argsCount45 = operation.ArgsCount;
			int num45 = argsCount45;
			if (num45 == 2)
			{
				short areaId9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId9);
				short blockId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockId);
				MapBlockData returnValue53 = GetBlockData(areaId9, blockId);
				return GameData.Serializer.Serializer.Serialize(returnValue53, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 20:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				int charId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId3);
				sbyte resourceType3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref resourceType3);
				CollectResourceResult returnValue44 = CollectResource(context, charId3, resourceType3);
				return GameData.Serializer.Serializer.Serialize(returnValue44, returnDataPool);
			}
			case 3:
			{
				int charId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId2);
				sbyte resourceType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref resourceType2);
				bool costTime2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref costTime2);
				CollectResourceResult returnValue43 = CollectResource(context, charId2, resourceType2, costTime2);
				return GameData.Serializer.Serializer.Serialize(returnValue43, returnDataPool);
			}
			case 4:
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				sbyte resourceType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref resourceType);
				bool costTime = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref costTime);
				bool costResource = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref costResource);
				CollectResourceResult returnValue42 = CollectResource(context, charId, resourceType, costTime, costResource);
				return GameData.Serializer.Serializer.Serialize(returnValue42, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 21:
		{
			int argsCount41 = operation.ArgsCount;
			int num41 = argsCount41;
			if (num41 == 1)
			{
				List<Location> locationList5 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref locationList5);
				List<MapBlockData> returnValue38 = GetMapBlockDataList(locationList5);
				return GameData.Serializer.Serializer.Serialize(returnValue38, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 22:
		{
			int argsCount35 = operation.ArgsCount;
			int num35 = argsCount35;
			if (num35 == 1)
			{
				List<Location> locationList4 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref locationList4);
				List<short> returnValue34 = GetBelongBlockTemplateIdList(locationList4);
				return GameData.Serializer.Serializer.Serialize(returnValue34, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 23:
		{
			int argsCount31 = operation.ArgsCount;
			int num31 = argsCount31;
			if (num31 == 1)
			{
				Location location8 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location8);
				LocationNameRelatedData returnValue31 = GetLocationNameRelatedData(location8);
				return GameData.Serializer.Serializer.Serialize(returnValue31, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 24:
		{
			int argsCount25 = operation.ArgsCount;
			int num25 = argsCount25;
			if (num25 == 1)
			{
				List<Location> locations = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref locations);
				List<LocationNameRelatedData> returnValue26 = GetLocationNameRelatedDataList(locations);
				return GameData.Serializer.Serializer.Serialize(returnValue26, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 25:
		{
			int argsCount21 = operation.ArgsCount;
			int num21 = argsCount21;
			if (num21 == 3)
			{
				Location location7 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location7);
				short blockTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockTemplateId);
				bool isTurnVisible = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isTurnVisible);
				Location returnValue23 = ChangeBlockTemplate(context, location7, blockTemplateId, isTurnVisible);
				return GameData.Serializer.Serializer.Serialize(returnValue23, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 26:
		{
			int argsCount17 = operation.ArgsCount;
			int num17 = argsCount17;
			if (num17 == 1)
			{
				short areaId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId2);
				bool returnValue18 = IsContainsPurpleBamboo(areaId2);
				return GameData.Serializer.Serializer.Serialize(returnValue18, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 27:
			if (operation.ArgsCount == 0)
			{
				int[] returnValue10 = GetAllStateCompletelyInfectedCharCount();
				return GameData.Serializer.Serializer.Serialize(returnValue10, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 28:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 1)
			{
				Location location2 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location2);
				FullBlockName returnValue6 = GetBlockFullName(location2);
				return GameData.Serializer.Serializer.Serialize(returnValue6, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 29:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				List<Location> locationList3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref locationList3);
				List<MapBlockData> returnValue5 = GetMapBlockDataListOptional(locationList3);
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			case 2:
			{
				List<Location> locationList2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref locationList2);
				bool includeRoot2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref includeRoot2);
				List<MapBlockData> returnValue4 = GetMapBlockDataListOptional(locationList2, includeRoot2);
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			case 3:
			{
				List<Location> locationList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref locationList);
				bool includeRoot = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref includeRoot);
				bool includeBelong = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref includeBelong);
				List<MapBlockData> returnValue3 = GetMapBlockDataListOptional(locationList, includeRoot, includeBelong);
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 30:
		{
			int argsCount47 = operation.ArgsCount;
			int num47 = argsCount47;
			if (num47 == 2)
			{
				Location location10 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location10);
				Location settlementLocation = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementLocation);
				bool returnValue54 = IsLocationInBuildingEffectRange(location10, settlementLocation);
				return GameData.Serializer.Serializer.Serialize(returnValue54, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 31:
			if (operation.ArgsCount == 0)
			{
				short returnValue52 = ContinueTravelWithDetectTravelingEvent(context);
				return GameData.Serializer.Serializer.Serialize(returnValue52, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 32:
			if (operation.ArgsCount == 0)
			{
				List<CollectResourceResult> returnValue41 = CollectAllResourcesFree(context);
				return GameData.Serializer.Serializer.Serialize(returnValue41, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 33:
		{
			int argsCount40 = operation.ArgsCount;
			int num40 = argsCount40;
			if (num40 == 1)
			{
				short destAreaId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref destAreaId);
				QuickTravel(context, destAreaId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 34:
		{
			int argsCount36 = operation.ArgsCount;
			int num36 = argsCount36;
			if (num36 == 1)
			{
				short templateId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId8);
				Location returnValue35 = QueryFixedCharacterLocation(templateId8);
				return GameData.Serializer.Serializer.Serialize(returnValue35, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 35:
			if (operation.ArgsCount == 0)
			{
				AreaDisplayData[] returnValue32 = GetAllAreaDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue32, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 36:
		{
			int argsCount29 = operation.ArgsCount;
			int num29 = argsCount29;
			if (num29 == 1)
			{
				int templateId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId7);
				Location returnValue30 = QueryTemplateBlockLocation(templateId7);
				return GameData.Serializer.Serializer.Serialize(returnValue30, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 37:
		{
			int argsCount27 = operation.ArgsCount;
			int num27 = argsCount27;
			if (num27 == 1)
			{
				short areaId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId8);
				List<MapBlockDisplayData> returnValue28 = GetBlockDisplayDataInArea(areaId8);
				return GameData.Serializer.Serializer.Serialize(returnValue28, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 38:
		{
			int argsCount23 = operation.ArgsCount;
			int num23 = argsCount23;
			if (num23 == 1)
			{
				short toAreaId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toAreaId3);
				bool returnValue24 = UnlockTravelPath(context, toAreaId3);
				return GameData.Serializer.Serializer.Serialize(returnValue24, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 39:
			if (operation.ArgsCount == 0)
			{
				GmCmd_HideAllMapBlock(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 40:
		{
			int argsCount18 = operation.ArgsCount;
			int num18 = argsCount18;
			if (num18 == 2)
			{
				Location start2 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref start2);
				Location end2 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref end2);
				List<Location> returnValue19 = GetPathInAreaWithoutCost(start2, end2);
				return GameData.Serializer.Serializer.Serialize(returnValue19, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 41:
		{
			int argsCount14 = operation.ArgsCount;
			int num14 = argsCount14;
			if (num14 == 1)
			{
				short toAreaId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toAreaId);
				TravelPreviewDisplayData returnValue13 = GetTravelPreview(toAreaId);
				return GameData.Serializer.Serializer.Serialize(returnValue13, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 42:
		{
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 1)
			{
				Location location4 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location4);
				RetrieveDreamBackLocation(context, location4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 43:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 1)
			{
				short areaId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId);
				MapAreaData returnValue7 = GetAreaByAreaId(areaId);
				return GameData.Serializer.Serializer.Serialize(returnValue7, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 44:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 1)
			{
				short templateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId);
				GmCmd_AddAnimal(context, templateId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 45:
		{
			int argsCount48 = operation.ArgsCount;
			int num48 = argsCount48;
			if (num48 == 1)
			{
				bool isTraveling2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isTraveling2);
				TeammateBubbleCollection returnValue55 = GetTeammateBubbleCollection(context, isTraveling2);
				return GameData.Serializer.Serializer.Serialize(returnValue55, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 46:
		{
			int argsCount46 = operation.ArgsCount;
			int num46 = argsCount46;
			if (num46 == 1)
			{
				short templateId9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId9);
				GmCmd_AddRandomEnemyOnMap(context, templateId9);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 47:
			if (operation.ArgsCount == 0)
			{
				GMCmd_ThrowBackend();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 48:
			switch (operation.ArgsCount)
			{
			case 3:
			{
				int typeInt7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref typeInt7);
				int doctorId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref doctorId7);
				int patientId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref patientId7);
				MapHealSimulateResult returnValue51 = SimulateHealCost(typeInt7, doctorId7, patientId7);
				return GameData.Serializer.Serializer.Serialize(returnValue51, returnDataPool);
			}
			case 4:
			{
				int typeInt6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref typeInt6);
				int doctorId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref doctorId6);
				int patientId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref patientId6);
				bool needPay5 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref needPay5);
				MapHealSimulateResult returnValue50 = SimulateHealCost(typeInt6, doctorId6, patientId6, needPay5);
				return GameData.Serializer.Serializer.Serialize(returnValue50, returnDataPool);
			}
			case 5:
			{
				int typeInt5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref typeInt5);
				int doctorId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref doctorId5);
				int patientId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref patientId5);
				bool needPay4 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref needPay4);
				bool isExpensiveHeal2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isExpensiveHeal2);
				MapHealSimulateResult returnValue49 = SimulateHealCost(typeInt5, doctorId5, patientId5, needPay4, isExpensiveHeal2);
				return GameData.Serializer.Serializer.Serialize(returnValue49, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 49:
			switch (operation.ArgsCount)
			{
			case 3:
			{
				int typeInt4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref typeInt4);
				int doctorId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref doctorId4);
				int patientId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref patientId4);
				bool returnValue48 = HealOnMap(context, typeInt4, doctorId4, patientId4);
				return GameData.Serializer.Serializer.Serialize(returnValue48, returnDataPool);
			}
			case 4:
			{
				int typeInt3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref typeInt3);
				int doctorId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref doctorId3);
				int patientId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref patientId3);
				bool needPay3 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref needPay3);
				bool returnValue47 = HealOnMap(context, typeInt3, doctorId3, patientId3, needPay3);
				return GameData.Serializer.Serializer.Serialize(returnValue47, returnDataPool);
			}
			case 5:
			{
				int typeInt2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref typeInt2);
				int doctorId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref doctorId2);
				int patientId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref patientId2);
				bool needPay2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref needPay2);
				int payerId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref payerId2);
				bool returnValue46 = HealOnMap(context, typeInt2, doctorId2, patientId2, needPay2, payerId2);
				return GameData.Serializer.Serializer.Serialize(returnValue46, returnDataPool);
			}
			case 6:
			{
				int typeInt = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref typeInt);
				int doctorId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref doctorId);
				int patientId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref patientId);
				bool needPay = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref needPay);
				int payerId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref payerId);
				bool isExpensiveHeal = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isExpensiveHeal);
				bool returnValue45 = HealOnMap(context, typeInt, doctorId, patientId, needPay, payerId, isExpensiveHeal);
				return GameData.Serializer.Serializer.Serialize(returnValue45, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 50:
		{
			int argsCount43 = operation.ArgsCount;
			int num43 = argsCount43;
			if (num43 == 1)
			{
				short destBlockId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref destBlockId2);
				TeleportByTraveler(context, destBlockId2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 51:
		{
			int argsCount42 = operation.ArgsCount;
			int num42 = argsCount42;
			if (num42 == 1)
			{
				Location location9 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location9);
				bool returnValue39 = BuildTravelerPalace(context, location9);
				return GameData.Serializer.Serializer.Serialize(returnValue39, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 52:
		{
			int argsCount39 = operation.ArgsCount;
			int num39 = argsCount39;
			if (num39 == 1)
			{
				int index5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index5);
				bool returnValue37 = TeleportOnTravelerPalace(context, index5);
				return GameData.Serializer.Serializer.Serialize(returnValue37, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 53:
		{
			int argsCount37 = operation.ArgsCount;
			int num37 = argsCount37;
			if (num37 == 2)
			{
				int index4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index4);
				string newName = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref newName);
				bool returnValue36 = ChangeTravelerPalaceName(context, index4, newName);
				return GameData.Serializer.Serializer.Serialize(returnValue36, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 54:
		{
			int argsCount34 = operation.ArgsCount;
			int num34 = argsCount34;
			if (num34 == 1)
			{
				int index3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index3);
				bool returnValue33 = DestroyTravelerPalace(context, index3);
				return GameData.Serializer.Serializer.Serialize(returnValue33, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 55:
		{
			int argsCount33 = operation.ArgsCount;
			int num33 = argsCount33;
			if (num33 == 1)
			{
				int spiritualDebt2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref spiritualDebt2);
				GmCmd_ChangeAllSpiritualDebt(context, spiritualDebt2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 56:
		{
			int argsCount30 = operation.ArgsCount;
			int num30 = argsCount30;
			if (num30 == 2)
			{
				Location targetLocation = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetLocation);
				int hunterCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref hunterCharId);
				TaiwuBeKidnapped(context, targetLocation, hunterCharId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 57:
			if (operation.ArgsCount == 0)
			{
				DirectTravelToTaiwuVillage(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 58:
		{
			int argsCount26 = operation.ArgsCount;
			int num26 = argsCount26;
			if (num26 == 2)
			{
				int templateId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId6);
				short areaId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId7);
				Location returnValue27 = QueryTemplateBlockLocationInArea(templateId6, areaId7);
				return GameData.Serializer.Serializer.Serialize(returnValue27, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 59:
		{
			int argsCount24 = operation.ArgsCount;
			int num24 = argsCount24;
			if (num24 == 2)
			{
				short templateId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId5);
				short areaId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId4);
				Location returnValue25 = QueryFixedCharacterLocationInArea(templateId5, areaId4);
				return GameData.Serializer.Serializer.Serialize(returnValue25, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 60:
			if (operation.ArgsCount == 0)
			{
				GmCmd_TurnMapBlockIntoAshes(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 61:
		{
			int argsCount20 = operation.ArgsCount;
			int num20 = argsCount20;
			if (num20 == 1)
			{
				short templateId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId3);
				bool returnValue22 = GmCmd_TriggerTravelingEvent(context, templateId3);
				return GameData.Serializer.Serializer.Serialize(returnValue22, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 62:
			if (operation.ArgsCount == 0)
			{
				int returnValue20 = GmCmd_GetTreasuryValueByTaiwuLocation();
				return GameData.Serializer.Serializer.Serialize(returnValue20, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 63:
		{
			int argsCount16 = operation.ArgsCount;
			int num16 = argsCount16;
			if (num16 == 1)
			{
				MapBlockData data = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref data);
				MapBlockCharacterList returnValue17 = RequestMapBlockCharacterList(context, data);
				return GameData.Serializer.Serializer.Serialize(returnValue17, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 64:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				Location location6 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location6);
				MapBlockCharacterCountData returnValue16 = GetMapBlockCharacterCountData(location6);
				return GameData.Serializer.Serializer.Serialize(returnValue16, returnDataPool);
			}
			case 2:
			{
				Location location5 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location5);
				List<short> orgTemplateIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgTemplateIds);
				MapBlockCharacterCountData returnValue15 = GetMapBlockCharacterCountData(location5, orgTemplateIds);
				return GameData.Serializer.Serializer.Serialize(returnValue15, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 65:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 1)
			{
				int index2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index2);
				MapBlockFindData returnValue12 = GetMapBlockFindDataPreset(index2);
				return GameData.Serializer.Serializer.Serialize(returnValue12, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 66:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 2)
			{
				int index = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index);
				MapBlockFindData findData = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref findData);
				List<Location> returnValue9 = SetMapBlockFindDataPreset(context, index, findData);
				return GameData.Serializer.Serializer.Serialize(returnValue9, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 67:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 1)
			{
				bool isTraveling = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isTraveling);
				TransferableRecordDataBase returnValue8 = GetReversedTeammateBubble(context, isTraveling);
				return GameData.Serializer.Serializer.Serialize(returnValue8, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 68:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 1)
			{
				Location location3 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location3);
				RemoveSwordTombFromLocation(context, location3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 69:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 2)
			{
				Location location = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location);
				short templateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId2);
				SetBlockAndViewRangeVisibleByBlockTemplateId(context, location, templateId2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 70:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 2)
			{
				Location start = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref start);
				Location end = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref end);
				List<Location> returnValue = GetPathInAreaWithAvoidSettings(start, end);
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
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
			_modificationsAreaBlocks0.ChangeRecording(monitoring);
			break;
		case 2:
			_modificationsAreaBlocks1.ChangeRecording(monitoring);
			break;
		case 3:
			_modificationsAreaBlocks2.ChangeRecording(monitoring);
			break;
		case 4:
			_modificationsAreaBlocks3.ChangeRecording(monitoring);
			break;
		case 5:
			_modificationsAreaBlocks4.ChangeRecording(monitoring);
			break;
		case 6:
			_modificationsAreaBlocks5.ChangeRecording(monitoring);
			break;
		case 7:
			_modificationsAreaBlocks6.ChangeRecording(monitoring);
			break;
		case 8:
			_modificationsAreaBlocks7.ChangeRecording(monitoring);
			break;
		case 9:
			_modificationsAreaBlocks8.ChangeRecording(monitoring);
			break;
		case 10:
			_modificationsAreaBlocks9.ChangeRecording(monitoring);
			break;
		case 11:
			_modificationsAreaBlocks10.ChangeRecording(monitoring);
			break;
		case 12:
			_modificationsAreaBlocks11.ChangeRecording(monitoring);
			break;
		case 13:
			_modificationsAreaBlocks12.ChangeRecording(monitoring);
			break;
		case 14:
			_modificationsAreaBlocks13.ChangeRecording(monitoring);
			break;
		case 15:
			_modificationsAreaBlocks14.ChangeRecording(monitoring);
			break;
		case 16:
			_modificationsAreaBlocks15.ChangeRecording(monitoring);
			break;
		case 17:
			_modificationsAreaBlocks16.ChangeRecording(monitoring);
			break;
		case 18:
			_modificationsAreaBlocks17.ChangeRecording(monitoring);
			break;
		case 19:
			_modificationsAreaBlocks18.ChangeRecording(monitoring);
			break;
		case 20:
			_modificationsAreaBlocks19.ChangeRecording(monitoring);
			break;
		case 21:
			_modificationsAreaBlocks20.ChangeRecording(monitoring);
			break;
		case 22:
			_modificationsAreaBlocks21.ChangeRecording(monitoring);
			break;
		case 23:
			_modificationsAreaBlocks22.ChangeRecording(monitoring);
			break;
		case 24:
			_modificationsAreaBlocks23.ChangeRecording(monitoring);
			break;
		case 25:
			_modificationsAreaBlocks24.ChangeRecording(monitoring);
			break;
		case 26:
			_modificationsAreaBlocks25.ChangeRecording(monitoring);
			break;
		case 27:
			_modificationsAreaBlocks26.ChangeRecording(monitoring);
			break;
		case 28:
			_modificationsAreaBlocks27.ChangeRecording(monitoring);
			break;
		case 29:
			_modificationsAreaBlocks28.ChangeRecording(monitoring);
			break;
		case 30:
			_modificationsAreaBlocks29.ChangeRecording(monitoring);
			break;
		case 31:
			_modificationsAreaBlocks30.ChangeRecording(monitoring);
			break;
		case 32:
			_modificationsAreaBlocks31.ChangeRecording(monitoring);
			break;
		case 33:
			_modificationsAreaBlocks32.ChangeRecording(monitoring);
			break;
		case 34:
			_modificationsAreaBlocks33.ChangeRecording(monitoring);
			break;
		case 35:
			_modificationsAreaBlocks34.ChangeRecording(monitoring);
			break;
		case 36:
			_modificationsAreaBlocks35.ChangeRecording(monitoring);
			break;
		case 37:
			_modificationsAreaBlocks36.ChangeRecording(monitoring);
			break;
		case 38:
			_modificationsAreaBlocks37.ChangeRecording(monitoring);
			break;
		case 39:
			_modificationsAreaBlocks38.ChangeRecording(monitoring);
			break;
		case 40:
			_modificationsAreaBlocks39.ChangeRecording(monitoring);
			break;
		case 41:
			_modificationsAreaBlocks40.ChangeRecording(monitoring);
			break;
		case 42:
			_modificationsAreaBlocks41.ChangeRecording(monitoring);
			break;
		case 43:
			_modificationsAreaBlocks42.ChangeRecording(monitoring);
			break;
		case 44:
			_modificationsAreaBlocks43.ChangeRecording(monitoring);
			break;
		case 45:
			_modificationsAreaBlocks44.ChangeRecording(monitoring);
			break;
		case 46:
			_modificationsBrokenAreaBlocks.ChangeRecording(monitoring);
			break;
		case 47:
			_modificationsBornAreaBlocks.ChangeRecording(monitoring);
			break;
		case 48:
			_modificationsGuideAreaBlocks.ChangeRecording(monitoring);
			break;
		case 49:
			_modificationsSecretVillageAreaBlocks.ChangeRecording(monitoring);
			break;
		case 50:
			_modificationsBrokenPerformAreaBlocks.ChangeRecording(monitoring);
			break;
		case 51:
			_modificationsTravelRouteDict.ChangeRecording(monitoring);
			break;
		case 52:
			_modificationsBornStateTravelRouteDict.ChangeRecording(monitoring);
			break;
		case 53:
			break;
		case 54:
			break;
		case 55:
			break;
		case 56:
			break;
		case 57:
			break;
		case 58:
			break;
		case 59:
			break;
		case 60:
			break;
		case 61:
			break;
		case 62:
			break;
		case 63:
			break;
		case 64:
			break;
		case 65:
			break;
		case 66:
			break;
		case 67:
			break;
		case 68:
			break;
		case 69:
			break;
		case 70:
			_modificationsPastTaiwuVillageAreaBlocks.ChangeRecording(monitoring);
			break;
		case 71:
			break;
		case 72:
			_modificationsChaishanAreaBlocks.ChangeRecording(monitoring);
			break;
		case 73:
			break;
		case 74:
			_modificationsLocationNaturalDisasterDate.ChangeRecording(monitoring);
			break;
		case 75:
			_modificationsLocationNaturalDisasterDateNew.ChangeRecording(monitoring);
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
			if (!BaseGameDataDomain.IsModified(_dataStatesAreas, (int)subId0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(_dataStatesAreas, (int)subId0);
			return GameData.Serializer.Serializer.Serialize(_areas[(uint)subId0], dataPool);
		case 1:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 1))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 1);
			int offset40 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks0, dataPool, _modificationsAreaBlocks0);
			_modificationsAreaBlocks0.Reset();
			return offset40;
		}
		case 2:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 2))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 2);
			int offset14 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks1, dataPool, _modificationsAreaBlocks1);
			_modificationsAreaBlocks1.Reset();
			return offset14;
		}
		case 3:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 3))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 3);
			int offset28 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks2, dataPool, _modificationsAreaBlocks2);
			_modificationsAreaBlocks2.Reset();
			return offset28;
		}
		case 4:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 4))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 4);
			int offset48 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks3, dataPool, _modificationsAreaBlocks3);
			_modificationsAreaBlocks3.Reset();
			return offset48;
		}
		case 5:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 5))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 5);
			int offset26 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks4, dataPool, _modificationsAreaBlocks4);
			_modificationsAreaBlocks4.Reset();
			return offset26;
		}
		case 6:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 6))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 6);
			int offset52 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks5, dataPool, _modificationsAreaBlocks5);
			_modificationsAreaBlocks5.Reset();
			return offset52;
		}
		case 7:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 7))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 7);
			int offset35 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks6, dataPool, _modificationsAreaBlocks6);
			_modificationsAreaBlocks6.Reset();
			return offset35;
		}
		case 8:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 8))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 8);
			int offset19 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks7, dataPool, _modificationsAreaBlocks7);
			_modificationsAreaBlocks7.Reset();
			return offset19;
		}
		case 9:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 9))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 9);
			int offset3 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks8, dataPool, _modificationsAreaBlocks8);
			_modificationsAreaBlocks8.Reset();
			return offset3;
		}
		case 10:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 10))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 10);
			int offset41 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks9, dataPool, _modificationsAreaBlocks9);
			_modificationsAreaBlocks9.Reset();
			return offset41;
		}
		case 11:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 11))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 11);
			int offset32 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks10, dataPool, _modificationsAreaBlocks10);
			_modificationsAreaBlocks10.Reset();
			return offset32;
		}
		case 12:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 12))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 12);
			int offset22 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks11, dataPool, _modificationsAreaBlocks11);
			_modificationsAreaBlocks11.Reset();
			return offset22;
		}
		case 13:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 13))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 13);
			int offset13 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks12, dataPool, _modificationsAreaBlocks12);
			_modificationsAreaBlocks12.Reset();
			return offset13;
		}
		case 14:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 14))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 14);
			int offset54 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks13, dataPool, _modificationsAreaBlocks13);
			_modificationsAreaBlocks13.Reset();
			return offset54;
		}
		case 15:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 15))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 15);
			int offset45 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks14, dataPool, _modificationsAreaBlocks14);
			_modificationsAreaBlocks14.Reset();
			return offset45;
		}
		case 16:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 16))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 16);
			int offset37 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks15, dataPool, _modificationsAreaBlocks15);
			_modificationsAreaBlocks15.Reset();
			return offset37;
		}
		case 17:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 17))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 17);
			int offset31 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks16, dataPool, _modificationsAreaBlocks16);
			_modificationsAreaBlocks16.Reset();
			return offset31;
		}
		case 18:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 18))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 18);
			int offset23 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks17, dataPool, _modificationsAreaBlocks17);
			_modificationsAreaBlocks17.Reset();
			return offset23;
		}
		case 19:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 19))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 19);
			int offset17 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks18, dataPool, _modificationsAreaBlocks18);
			_modificationsAreaBlocks18.Reset();
			return offset17;
		}
		case 20:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 20))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 20);
			int offset9 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks19, dataPool, _modificationsAreaBlocks19);
			_modificationsAreaBlocks19.Reset();
			return offset9;
		}
		case 21:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 21))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 21);
			int offset2 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks20, dataPool, _modificationsAreaBlocks20);
			_modificationsAreaBlocks20.Reset();
			return offset2;
		}
		case 22:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 22))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 22);
			int offset49 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks21, dataPool, _modificationsAreaBlocks21);
			_modificationsAreaBlocks21.Reset();
			return offset49;
		}
		case 23:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 23))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 23);
			int offset43 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks22, dataPool, _modificationsAreaBlocks22);
			_modificationsAreaBlocks22.Reset();
			return offset43;
		}
		case 24:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 24))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 24);
			int offset38 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks23, dataPool, _modificationsAreaBlocks23);
			_modificationsAreaBlocks23.Reset();
			return offset38;
		}
		case 25:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 25))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 25);
			int offset34 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks24, dataPool, _modificationsAreaBlocks24);
			_modificationsAreaBlocks24.Reset();
			return offset34;
		}
		case 26:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 26))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 26);
			int offset29 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks25, dataPool, _modificationsAreaBlocks25);
			_modificationsAreaBlocks25.Reset();
			return offset29;
		}
		case 27:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 27))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 27);
			int offset25 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks26, dataPool, _modificationsAreaBlocks26);
			_modificationsAreaBlocks26.Reset();
			return offset25;
		}
		case 28:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 28))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 28);
			int offset20 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks27, dataPool, _modificationsAreaBlocks27);
			_modificationsAreaBlocks27.Reset();
			return offset20;
		}
		case 29:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 29))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 29);
			int offset16 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks28, dataPool, _modificationsAreaBlocks28);
			_modificationsAreaBlocks28.Reset();
			return offset16;
		}
		case 30:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 30))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 30);
			int offset10 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks29, dataPool, _modificationsAreaBlocks29);
			_modificationsAreaBlocks29.Reset();
			return offset10;
		}
		case 31:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 31))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 31);
			int offset6 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks30, dataPool, _modificationsAreaBlocks30);
			_modificationsAreaBlocks30.Reset();
			return offset6;
		}
		case 32:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 32))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 32);
			int offset55 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks31, dataPool, _modificationsAreaBlocks31);
			_modificationsAreaBlocks31.Reset();
			return offset55;
		}
		case 33:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 33))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 33);
			int offset51 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks32, dataPool, _modificationsAreaBlocks32);
			_modificationsAreaBlocks32.Reset();
			return offset51;
		}
		case 34:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 34))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 34);
			int offset46 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks33, dataPool, _modificationsAreaBlocks33);
			_modificationsAreaBlocks33.Reset();
			return offset46;
		}
		case 35:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 35))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 35);
			int offset42 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks34, dataPool, _modificationsAreaBlocks34);
			_modificationsAreaBlocks34.Reset();
			return offset42;
		}
		case 36:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 36))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 36);
			int offset39 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks35, dataPool, _modificationsAreaBlocks35);
			_modificationsAreaBlocks35.Reset();
			return offset39;
		}
		case 37:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 37))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 37);
			int offset36 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks36, dataPool, _modificationsAreaBlocks36);
			_modificationsAreaBlocks36.Reset();
			return offset36;
		}
		case 38:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 38))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 38);
			int offset33 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks37, dataPool, _modificationsAreaBlocks37);
			_modificationsAreaBlocks37.Reset();
			return offset33;
		}
		case 39:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 39))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 39);
			int offset30 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks38, dataPool, _modificationsAreaBlocks38);
			_modificationsAreaBlocks38.Reset();
			return offset30;
		}
		case 40:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 40))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 40);
			int offset27 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks39, dataPool, _modificationsAreaBlocks39);
			_modificationsAreaBlocks39.Reset();
			return offset27;
		}
		case 41:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 41))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 41);
			int offset24 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks40, dataPool, _modificationsAreaBlocks40);
			_modificationsAreaBlocks40.Reset();
			return offset24;
		}
		case 42:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 42))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 42);
			int offset21 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks41, dataPool, _modificationsAreaBlocks41);
			_modificationsAreaBlocks41.Reset();
			return offset21;
		}
		case 43:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 43))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 43);
			int offset18 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks42, dataPool, _modificationsAreaBlocks42);
			_modificationsAreaBlocks42.Reset();
			return offset18;
		}
		case 44:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 44))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 44);
			int offset15 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks43, dataPool, _modificationsAreaBlocks43);
			_modificationsAreaBlocks43.Reset();
			return offset15;
		}
		case 45:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 45))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 45);
			int offset12 = GameData.Serializer.Serializer.SerializeModifications(_areaBlocks44, dataPool, _modificationsAreaBlocks44);
			_modificationsAreaBlocks44.Reset();
			return offset12;
		}
		case 46:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 46))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 46);
			int offset8 = GameData.Serializer.Serializer.SerializeModifications(_brokenAreaBlocks, dataPool, _modificationsBrokenAreaBlocks);
			_modificationsBrokenAreaBlocks.Reset();
			return offset8;
		}
		case 47:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 47))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 47);
			int offset5 = GameData.Serializer.Serializer.SerializeModifications(_bornAreaBlocks, dataPool, _modificationsBornAreaBlocks);
			_modificationsBornAreaBlocks.Reset();
			return offset5;
		}
		case 48:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 48))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 48);
			int offset56 = GameData.Serializer.Serializer.SerializeModifications(_guideAreaBlocks, dataPool, _modificationsGuideAreaBlocks);
			_modificationsGuideAreaBlocks.Reset();
			return offset56;
		}
		case 49:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 49))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 49);
			int offset53 = GameData.Serializer.Serializer.SerializeModifications(_secretVillageAreaBlocks, dataPool, _modificationsSecretVillageAreaBlocks);
			_modificationsSecretVillageAreaBlocks.Reset();
			return offset53;
		}
		case 50:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 50))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 50);
			int offset50 = GameData.Serializer.Serializer.SerializeModifications(_brokenPerformAreaBlocks, dataPool, _modificationsBrokenPerformAreaBlocks);
			_modificationsBrokenPerformAreaBlocks.Reset();
			return offset50;
		}
		case 51:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 51))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 51);
			int offset47 = GameData.Serializer.Serializer.SerializeModifications(_travelRouteDict, dataPool, _modificationsTravelRouteDict);
			_modificationsTravelRouteDict.Reset();
			return offset47;
		}
		case 52:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 52))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 52);
			int offset44 = GameData.Serializer.Serializer.SerializeModifications(_bornStateTravelRouteDict, dataPool, _modificationsBornStateTravelRouteDict);
			_modificationsBornStateTravelRouteDict.Reset();
			return offset44;
		}
		case 53:
			if (!BaseGameDataDomain.IsModified(_dataStatesCricketPlaceData, (int)subId0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(_dataStatesCricketPlaceData, (int)subId0);
			return GameData.Serializer.Serializer.Serialize(_cricketPlaceData[(uint)subId0], dataPool);
		case 54:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 55:
			if (!BaseGameDataDomain.IsModified(_dataStatesSwordTombLocations, (int)subId0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(_dataStatesSwordTombLocations, (int)subId0);
			return GameData.Serializer.Serializer.Serialize(_swordTombLocations[(uint)subId0], dataPool);
		case 56:
			if (!BaseGameDataDomain.IsModified(DataStates, 56))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 56);
			return GameData.Serializer.Serializer.Serialize(_travelInfo, dataPool);
		case 57:
			if (!BaseGameDataDomain.IsModified(DataStates, 57))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 57);
			return GameData.Serializer.Serializer.Serialize(_onHandlingTravelingEventBlock, dataPool);
		case 58:
			if (!BaseGameDataDomain.IsModified(DataStates, 58))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 58);
			return GameData.Serializer.Serializer.Serialize(_hunterAnimals, dataPool);
		case 59:
			if (!BaseGameDataDomain.IsModified(DataStates, 59))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 59);
			return GameData.Serializer.Serializer.Serialize(_moveBanned, dataPool);
		case 60:
			if (!BaseGameDataDomain.IsModified(DataStates, 60))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 60);
			return GameData.Serializer.Serializer.Serialize(_crossArchiveLockMoveTime, dataPool);
		case 61:
			if (!BaseGameDataDomain.IsModified(DataStates, 61))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 61);
			return GameData.Serializer.Serializer.Serialize(GetFleeBeasts(), dataPool);
		case 62:
			if (!BaseGameDataDomain.IsModified(DataStates, 62))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 62);
			return GameData.Serializer.Serializer.Serialize(GetFleeLoongs(), dataPool);
		case 63:
			if (!BaseGameDataDomain.IsModified(DataStates, 63))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 63);
			return GameData.Serializer.Serializer.Serialize(GetLoongLocations(), dataPool);
		case 64:
			if (!BaseGameDataDomain.IsModified(DataStates, 64))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 64);
			return GameData.Serializer.Serializer.Serialize(GetAlterSettlementLocations(), dataPool);
		case 65:
			if (!BaseGameDataDomain.IsModified(DataStates, 65))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 65);
			return GameData.Serializer.Serializer.Serialize(_isTaiwuInFulongFlameArea, dataPool);
		case 66:
			if (!BaseGameDataDomain.IsModified(DataStates, 66))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 66);
			return GameData.Serializer.Serializer.Serialize(GetVisibleMapPickups(), dataPool);
		case 67:
			if (!BaseGameDataDomain.IsModified(_dataStatesBrokenAreaEnemies, (int)subId0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(_dataStatesBrokenAreaEnemies, (int)subId0);
			return GameData.Serializer.Serializer.Serialize(_brokenAreaEnemies[(uint)subId0], dataPool);
		case 68:
			if (!BaseGameDataDomain.IsModified(_dataStatesStateXiangshuInfectedDemons, (int)subId0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(_dataStatesStateXiangshuInfectedDemons, (int)subId0);
			return GameData.Serializer.Serializer.Serialize(_stateXiangshuInfectedDemons[(uint)subId0], dataPool);
		case 69:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 70:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 70))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 70);
			int offset11 = GameData.Serializer.Serializer.SerializeModifications(_pastTaiwuVillageAreaBlocks, dataPool, _modificationsPastTaiwuVillageAreaBlocks);
			_modificationsPastTaiwuVillageAreaBlocks.Reset();
			return offset11;
		}
		case 71:
			if (!BaseGameDataDomain.IsModified(DataStates, 71))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 71);
			return GameData.Serializer.Serializer.Serialize(_pastTaiwuVillageLockMoveTime, dataPool);
		case 72:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 72))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 72);
			int offset7 = GameData.Serializer.Serializer.SerializeModifications(_chaishanAreaBlocks, dataPool, _modificationsChaishanAreaBlocks);
			_modificationsChaishanAreaBlocks.Reset();
			return offset7;
		}
		case 73:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 74:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 74))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 74);
			int offset4 = GameData.Serializer.Serializer.SerializeModifications(_locationNaturalDisasterDate, dataPool, _modificationsLocationNaturalDisasterDate);
			_modificationsLocationNaturalDisasterDate.Reset();
			return offset4;
		}
		case 75:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 75))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 75);
			int offset = GameData.Serializer.Serializer.SerializeModifications(_locationNaturalDisasterDateNew, dataPool, _modificationsLocationNaturalDisasterDateNew);
			_modificationsLocationNaturalDisasterDateNew.Reset();
			return offset;
		}
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void ResetModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		switch (dataId)
		{
		case 0:
			if (BaseGameDataDomain.IsModified(_dataStatesAreas, (int)subId0))
			{
				BaseGameDataDomain.ResetModified(_dataStatesAreas, (int)subId0);
			}
			break;
		case 1:
			if (BaseGameDataDomain.IsModified(DataStates, 1))
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
				_modificationsAreaBlocks0.Reset();
			}
			break;
		case 2:
			if (BaseGameDataDomain.IsModified(DataStates, 2))
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
				_modificationsAreaBlocks1.Reset();
			}
			break;
		case 3:
			if (BaseGameDataDomain.IsModified(DataStates, 3))
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
				_modificationsAreaBlocks2.Reset();
			}
			break;
		case 4:
			if (BaseGameDataDomain.IsModified(DataStates, 4))
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
				_modificationsAreaBlocks3.Reset();
			}
			break;
		case 5:
			if (BaseGameDataDomain.IsModified(DataStates, 5))
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
				_modificationsAreaBlocks4.Reset();
			}
			break;
		case 6:
			if (BaseGameDataDomain.IsModified(DataStates, 6))
			{
				BaseGameDataDomain.ResetModified(DataStates, 6);
				_modificationsAreaBlocks5.Reset();
			}
			break;
		case 7:
			if (BaseGameDataDomain.IsModified(DataStates, 7))
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
				_modificationsAreaBlocks6.Reset();
			}
			break;
		case 8:
			if (BaseGameDataDomain.IsModified(DataStates, 8))
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
				_modificationsAreaBlocks7.Reset();
			}
			break;
		case 9:
			if (BaseGameDataDomain.IsModified(DataStates, 9))
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
				_modificationsAreaBlocks8.Reset();
			}
			break;
		case 10:
			if (BaseGameDataDomain.IsModified(DataStates, 10))
			{
				BaseGameDataDomain.ResetModified(DataStates, 10);
				_modificationsAreaBlocks9.Reset();
			}
			break;
		case 11:
			if (BaseGameDataDomain.IsModified(DataStates, 11))
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
				_modificationsAreaBlocks10.Reset();
			}
			break;
		case 12:
			if (BaseGameDataDomain.IsModified(DataStates, 12))
			{
				BaseGameDataDomain.ResetModified(DataStates, 12);
				_modificationsAreaBlocks11.Reset();
			}
			break;
		case 13:
			if (BaseGameDataDomain.IsModified(DataStates, 13))
			{
				BaseGameDataDomain.ResetModified(DataStates, 13);
				_modificationsAreaBlocks12.Reset();
			}
			break;
		case 14:
			if (BaseGameDataDomain.IsModified(DataStates, 14))
			{
				BaseGameDataDomain.ResetModified(DataStates, 14);
				_modificationsAreaBlocks13.Reset();
			}
			break;
		case 15:
			if (BaseGameDataDomain.IsModified(DataStates, 15))
			{
				BaseGameDataDomain.ResetModified(DataStates, 15);
				_modificationsAreaBlocks14.Reset();
			}
			break;
		case 16:
			if (BaseGameDataDomain.IsModified(DataStates, 16))
			{
				BaseGameDataDomain.ResetModified(DataStates, 16);
				_modificationsAreaBlocks15.Reset();
			}
			break;
		case 17:
			if (BaseGameDataDomain.IsModified(DataStates, 17))
			{
				BaseGameDataDomain.ResetModified(DataStates, 17);
				_modificationsAreaBlocks16.Reset();
			}
			break;
		case 18:
			if (BaseGameDataDomain.IsModified(DataStates, 18))
			{
				BaseGameDataDomain.ResetModified(DataStates, 18);
				_modificationsAreaBlocks17.Reset();
			}
			break;
		case 19:
			if (BaseGameDataDomain.IsModified(DataStates, 19))
			{
				BaseGameDataDomain.ResetModified(DataStates, 19);
				_modificationsAreaBlocks18.Reset();
			}
			break;
		case 20:
			if (BaseGameDataDomain.IsModified(DataStates, 20))
			{
				BaseGameDataDomain.ResetModified(DataStates, 20);
				_modificationsAreaBlocks19.Reset();
			}
			break;
		case 21:
			if (BaseGameDataDomain.IsModified(DataStates, 21))
			{
				BaseGameDataDomain.ResetModified(DataStates, 21);
				_modificationsAreaBlocks20.Reset();
			}
			break;
		case 22:
			if (BaseGameDataDomain.IsModified(DataStates, 22))
			{
				BaseGameDataDomain.ResetModified(DataStates, 22);
				_modificationsAreaBlocks21.Reset();
			}
			break;
		case 23:
			if (BaseGameDataDomain.IsModified(DataStates, 23))
			{
				BaseGameDataDomain.ResetModified(DataStates, 23);
				_modificationsAreaBlocks22.Reset();
			}
			break;
		case 24:
			if (BaseGameDataDomain.IsModified(DataStates, 24))
			{
				BaseGameDataDomain.ResetModified(DataStates, 24);
				_modificationsAreaBlocks23.Reset();
			}
			break;
		case 25:
			if (BaseGameDataDomain.IsModified(DataStates, 25))
			{
				BaseGameDataDomain.ResetModified(DataStates, 25);
				_modificationsAreaBlocks24.Reset();
			}
			break;
		case 26:
			if (BaseGameDataDomain.IsModified(DataStates, 26))
			{
				BaseGameDataDomain.ResetModified(DataStates, 26);
				_modificationsAreaBlocks25.Reset();
			}
			break;
		case 27:
			if (BaseGameDataDomain.IsModified(DataStates, 27))
			{
				BaseGameDataDomain.ResetModified(DataStates, 27);
				_modificationsAreaBlocks26.Reset();
			}
			break;
		case 28:
			if (BaseGameDataDomain.IsModified(DataStates, 28))
			{
				BaseGameDataDomain.ResetModified(DataStates, 28);
				_modificationsAreaBlocks27.Reset();
			}
			break;
		case 29:
			if (BaseGameDataDomain.IsModified(DataStates, 29))
			{
				BaseGameDataDomain.ResetModified(DataStates, 29);
				_modificationsAreaBlocks28.Reset();
			}
			break;
		case 30:
			if (BaseGameDataDomain.IsModified(DataStates, 30))
			{
				BaseGameDataDomain.ResetModified(DataStates, 30);
				_modificationsAreaBlocks29.Reset();
			}
			break;
		case 31:
			if (BaseGameDataDomain.IsModified(DataStates, 31))
			{
				BaseGameDataDomain.ResetModified(DataStates, 31);
				_modificationsAreaBlocks30.Reset();
			}
			break;
		case 32:
			if (BaseGameDataDomain.IsModified(DataStates, 32))
			{
				BaseGameDataDomain.ResetModified(DataStates, 32);
				_modificationsAreaBlocks31.Reset();
			}
			break;
		case 33:
			if (BaseGameDataDomain.IsModified(DataStates, 33))
			{
				BaseGameDataDomain.ResetModified(DataStates, 33);
				_modificationsAreaBlocks32.Reset();
			}
			break;
		case 34:
			if (BaseGameDataDomain.IsModified(DataStates, 34))
			{
				BaseGameDataDomain.ResetModified(DataStates, 34);
				_modificationsAreaBlocks33.Reset();
			}
			break;
		case 35:
			if (BaseGameDataDomain.IsModified(DataStates, 35))
			{
				BaseGameDataDomain.ResetModified(DataStates, 35);
				_modificationsAreaBlocks34.Reset();
			}
			break;
		case 36:
			if (BaseGameDataDomain.IsModified(DataStates, 36))
			{
				BaseGameDataDomain.ResetModified(DataStates, 36);
				_modificationsAreaBlocks35.Reset();
			}
			break;
		case 37:
			if (BaseGameDataDomain.IsModified(DataStates, 37))
			{
				BaseGameDataDomain.ResetModified(DataStates, 37);
				_modificationsAreaBlocks36.Reset();
			}
			break;
		case 38:
			if (BaseGameDataDomain.IsModified(DataStates, 38))
			{
				BaseGameDataDomain.ResetModified(DataStates, 38);
				_modificationsAreaBlocks37.Reset();
			}
			break;
		case 39:
			if (BaseGameDataDomain.IsModified(DataStates, 39))
			{
				BaseGameDataDomain.ResetModified(DataStates, 39);
				_modificationsAreaBlocks38.Reset();
			}
			break;
		case 40:
			if (BaseGameDataDomain.IsModified(DataStates, 40))
			{
				BaseGameDataDomain.ResetModified(DataStates, 40);
				_modificationsAreaBlocks39.Reset();
			}
			break;
		case 41:
			if (BaseGameDataDomain.IsModified(DataStates, 41))
			{
				BaseGameDataDomain.ResetModified(DataStates, 41);
				_modificationsAreaBlocks40.Reset();
			}
			break;
		case 42:
			if (BaseGameDataDomain.IsModified(DataStates, 42))
			{
				BaseGameDataDomain.ResetModified(DataStates, 42);
				_modificationsAreaBlocks41.Reset();
			}
			break;
		case 43:
			if (BaseGameDataDomain.IsModified(DataStates, 43))
			{
				BaseGameDataDomain.ResetModified(DataStates, 43);
				_modificationsAreaBlocks42.Reset();
			}
			break;
		case 44:
			if (BaseGameDataDomain.IsModified(DataStates, 44))
			{
				BaseGameDataDomain.ResetModified(DataStates, 44);
				_modificationsAreaBlocks43.Reset();
			}
			break;
		case 45:
			if (BaseGameDataDomain.IsModified(DataStates, 45))
			{
				BaseGameDataDomain.ResetModified(DataStates, 45);
				_modificationsAreaBlocks44.Reset();
			}
			break;
		case 46:
			if (BaseGameDataDomain.IsModified(DataStates, 46))
			{
				BaseGameDataDomain.ResetModified(DataStates, 46);
				_modificationsBrokenAreaBlocks.Reset();
			}
			break;
		case 47:
			if (BaseGameDataDomain.IsModified(DataStates, 47))
			{
				BaseGameDataDomain.ResetModified(DataStates, 47);
				_modificationsBornAreaBlocks.Reset();
			}
			break;
		case 48:
			if (BaseGameDataDomain.IsModified(DataStates, 48))
			{
				BaseGameDataDomain.ResetModified(DataStates, 48);
				_modificationsGuideAreaBlocks.Reset();
			}
			break;
		case 49:
			if (BaseGameDataDomain.IsModified(DataStates, 49))
			{
				BaseGameDataDomain.ResetModified(DataStates, 49);
				_modificationsSecretVillageAreaBlocks.Reset();
			}
			break;
		case 50:
			if (BaseGameDataDomain.IsModified(DataStates, 50))
			{
				BaseGameDataDomain.ResetModified(DataStates, 50);
				_modificationsBrokenPerformAreaBlocks.Reset();
			}
			break;
		case 51:
			if (BaseGameDataDomain.IsModified(DataStates, 51))
			{
				BaseGameDataDomain.ResetModified(DataStates, 51);
				_modificationsTravelRouteDict.Reset();
			}
			break;
		case 52:
			if (BaseGameDataDomain.IsModified(DataStates, 52))
			{
				BaseGameDataDomain.ResetModified(DataStates, 52);
				_modificationsBornStateTravelRouteDict.Reset();
			}
			break;
		case 53:
			if (BaseGameDataDomain.IsModified(_dataStatesCricketPlaceData, (int)subId0))
			{
				BaseGameDataDomain.ResetModified(_dataStatesCricketPlaceData, (int)subId0);
			}
			break;
		case 54:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 55:
			if (BaseGameDataDomain.IsModified(_dataStatesSwordTombLocations, (int)subId0))
			{
				BaseGameDataDomain.ResetModified(_dataStatesSwordTombLocations, (int)subId0);
			}
			break;
		case 56:
			if (BaseGameDataDomain.IsModified(DataStates, 56))
			{
				BaseGameDataDomain.ResetModified(DataStates, 56);
			}
			break;
		case 57:
			if (BaseGameDataDomain.IsModified(DataStates, 57))
			{
				BaseGameDataDomain.ResetModified(DataStates, 57);
			}
			break;
		case 58:
			if (BaseGameDataDomain.IsModified(DataStates, 58))
			{
				BaseGameDataDomain.ResetModified(DataStates, 58);
			}
			break;
		case 59:
			if (BaseGameDataDomain.IsModified(DataStates, 59))
			{
				BaseGameDataDomain.ResetModified(DataStates, 59);
			}
			break;
		case 60:
			if (BaseGameDataDomain.IsModified(DataStates, 60))
			{
				BaseGameDataDomain.ResetModified(DataStates, 60);
			}
			break;
		case 61:
			if (BaseGameDataDomain.IsModified(DataStates, 61))
			{
				BaseGameDataDomain.ResetModified(DataStates, 61);
			}
			break;
		case 62:
			if (BaseGameDataDomain.IsModified(DataStates, 62))
			{
				BaseGameDataDomain.ResetModified(DataStates, 62);
			}
			break;
		case 63:
			if (BaseGameDataDomain.IsModified(DataStates, 63))
			{
				BaseGameDataDomain.ResetModified(DataStates, 63);
			}
			break;
		case 64:
			if (BaseGameDataDomain.IsModified(DataStates, 64))
			{
				BaseGameDataDomain.ResetModified(DataStates, 64);
			}
			break;
		case 65:
			if (BaseGameDataDomain.IsModified(DataStates, 65))
			{
				BaseGameDataDomain.ResetModified(DataStates, 65);
			}
			break;
		case 66:
			if (BaseGameDataDomain.IsModified(DataStates, 66))
			{
				BaseGameDataDomain.ResetModified(DataStates, 66);
			}
			break;
		case 67:
			if (BaseGameDataDomain.IsModified(_dataStatesBrokenAreaEnemies, (int)subId0))
			{
				BaseGameDataDomain.ResetModified(_dataStatesBrokenAreaEnemies, (int)subId0);
			}
			break;
		case 68:
			if (BaseGameDataDomain.IsModified(_dataStatesStateXiangshuInfectedDemons, (int)subId0))
			{
				BaseGameDataDomain.ResetModified(_dataStatesStateXiangshuInfectedDemons, (int)subId0);
			}
			break;
		case 69:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 70:
			if (BaseGameDataDomain.IsModified(DataStates, 70))
			{
				BaseGameDataDomain.ResetModified(DataStates, 70);
				_modificationsPastTaiwuVillageAreaBlocks.Reset();
			}
			break;
		case 71:
			if (BaseGameDataDomain.IsModified(DataStates, 71))
			{
				BaseGameDataDomain.ResetModified(DataStates, 71);
			}
			break;
		case 72:
			if (BaseGameDataDomain.IsModified(DataStates, 72))
			{
				BaseGameDataDomain.ResetModified(DataStates, 72);
				_modificationsChaishanAreaBlocks.Reset();
			}
			break;
		case 73:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 74:
			if (BaseGameDataDomain.IsModified(DataStates, 74))
			{
				BaseGameDataDomain.ResetModified(DataStates, 74);
				_modificationsLocationNaturalDisasterDate.Reset();
			}
			break;
		case 75:
			if (BaseGameDataDomain.IsModified(DataStates, 75))
			{
				BaseGameDataDomain.ResetModified(DataStates, 75);
				_modificationsLocationNaturalDisasterDateNew.Reset();
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
			0 => BaseGameDataDomain.IsModified(_dataStatesAreas, (int)subId0), 
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
			12 => BaseGameDataDomain.IsModified(DataStates, 12), 
			13 => BaseGameDataDomain.IsModified(DataStates, 13), 
			14 => BaseGameDataDomain.IsModified(DataStates, 14), 
			15 => BaseGameDataDomain.IsModified(DataStates, 15), 
			16 => BaseGameDataDomain.IsModified(DataStates, 16), 
			17 => BaseGameDataDomain.IsModified(DataStates, 17), 
			18 => BaseGameDataDomain.IsModified(DataStates, 18), 
			19 => BaseGameDataDomain.IsModified(DataStates, 19), 
			20 => BaseGameDataDomain.IsModified(DataStates, 20), 
			21 => BaseGameDataDomain.IsModified(DataStates, 21), 
			22 => BaseGameDataDomain.IsModified(DataStates, 22), 
			23 => BaseGameDataDomain.IsModified(DataStates, 23), 
			24 => BaseGameDataDomain.IsModified(DataStates, 24), 
			25 => BaseGameDataDomain.IsModified(DataStates, 25), 
			26 => BaseGameDataDomain.IsModified(DataStates, 26), 
			27 => BaseGameDataDomain.IsModified(DataStates, 27), 
			28 => BaseGameDataDomain.IsModified(DataStates, 28), 
			29 => BaseGameDataDomain.IsModified(DataStates, 29), 
			30 => BaseGameDataDomain.IsModified(DataStates, 30), 
			31 => BaseGameDataDomain.IsModified(DataStates, 31), 
			32 => BaseGameDataDomain.IsModified(DataStates, 32), 
			33 => BaseGameDataDomain.IsModified(DataStates, 33), 
			34 => BaseGameDataDomain.IsModified(DataStates, 34), 
			35 => BaseGameDataDomain.IsModified(DataStates, 35), 
			36 => BaseGameDataDomain.IsModified(DataStates, 36), 
			37 => BaseGameDataDomain.IsModified(DataStates, 37), 
			38 => BaseGameDataDomain.IsModified(DataStates, 38), 
			39 => BaseGameDataDomain.IsModified(DataStates, 39), 
			40 => BaseGameDataDomain.IsModified(DataStates, 40), 
			41 => BaseGameDataDomain.IsModified(DataStates, 41), 
			42 => BaseGameDataDomain.IsModified(DataStates, 42), 
			43 => BaseGameDataDomain.IsModified(DataStates, 43), 
			44 => BaseGameDataDomain.IsModified(DataStates, 44), 
			45 => BaseGameDataDomain.IsModified(DataStates, 45), 
			46 => BaseGameDataDomain.IsModified(DataStates, 46), 
			47 => BaseGameDataDomain.IsModified(DataStates, 47), 
			48 => BaseGameDataDomain.IsModified(DataStates, 48), 
			49 => BaseGameDataDomain.IsModified(DataStates, 49), 
			50 => BaseGameDataDomain.IsModified(DataStates, 50), 
			51 => BaseGameDataDomain.IsModified(DataStates, 51), 
			52 => BaseGameDataDomain.IsModified(DataStates, 52), 
			53 => BaseGameDataDomain.IsModified(_dataStatesCricketPlaceData, (int)subId0), 
			54 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			55 => BaseGameDataDomain.IsModified(_dataStatesSwordTombLocations, (int)subId0), 
			56 => BaseGameDataDomain.IsModified(DataStates, 56), 
			57 => BaseGameDataDomain.IsModified(DataStates, 57), 
			58 => BaseGameDataDomain.IsModified(DataStates, 58), 
			59 => BaseGameDataDomain.IsModified(DataStates, 59), 
			60 => BaseGameDataDomain.IsModified(DataStates, 60), 
			61 => BaseGameDataDomain.IsModified(DataStates, 61), 
			62 => BaseGameDataDomain.IsModified(DataStates, 62), 
			63 => BaseGameDataDomain.IsModified(DataStates, 63), 
			64 => BaseGameDataDomain.IsModified(DataStates, 64), 
			65 => BaseGameDataDomain.IsModified(DataStates, 65), 
			66 => BaseGameDataDomain.IsModified(DataStates, 66), 
			67 => BaseGameDataDomain.IsModified(_dataStatesBrokenAreaEnemies, (int)subId0), 
			68 => BaseGameDataDomain.IsModified(_dataStatesStateXiangshuInfectedDemons, (int)subId0), 
			69 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			70 => BaseGameDataDomain.IsModified(DataStates, 70), 
			71 => BaseGameDataDomain.IsModified(DataStates, 71), 
			72 => BaseGameDataDomain.IsModified(DataStates, 72), 
			73 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			74 => BaseGameDataDomain.IsModified(DataStates, 74), 
			75 => BaseGameDataDomain.IsModified(DataStates, 75), 
			_ => throw new Exception($"Unsupported dataId {dataId}"), 
		};
	}

	public override void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll)
	{
		switch (influence.TargetIndicator.DataId)
		{
		case 61:
			BaseGameDataDomain.InvalidateSelfAndInfluencedCache(61, DataStates, CacheInfluences, context);
			break;
		case 62:
			BaseGameDataDomain.InvalidateSelfAndInfluencedCache(62, DataStates, CacheInfluences, context);
			break;
		case 63:
			BaseGameDataDomain.InvalidateSelfAndInfluencedCache(63, DataStates, CacheInfluences, context);
			break;
		case 64:
			BaseGameDataDomain.InvalidateSelfAndInfluencedCache(64, DataStates, CacheInfluences, context);
			break;
		case 66:
			BaseGameDataDomain.InvalidateSelfAndInfluencedCache(66, DataStates, CacheInfluences, context);
			break;
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
		case 30:
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
		case 37:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
		case 48:
		case 49:
		case 50:
		case 51:
		case 52:
		case 53:
		case 54:
		case 55:
		case 56:
		case 57:
		case 58:
		case 59:
		case 60:
		case 65:
		case 67:
		case 68:
		case 69:
		case 70:
		case 71:
		case 72:
		case 73:
		case 74:
		case 75:
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
	}
}
