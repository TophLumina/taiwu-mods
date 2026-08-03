using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using Config;
using Config.ConfigCells;
using GameData.Achievement;
using GameData.ArchiveData;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Common.Binary;
using GameData.Common.SingleValueCollection;
using GameData.Common.WorkerThread;
using GameData.DLC;
using GameData.DLC.FiveLoong;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Adventure;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;
using GameData.Domains.Character.Creation;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.ParallelModifications;
using GameData.Domains.Character.Relation;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Global;
using GameData.Domains.Information;
using GameData.Domains.Information.Secret;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.LifeRecord;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Domains.Mod;
using GameData.Domains.Organization;
using GameData.Domains.Organization.Display;
using GameData.Domains.Taiwu;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.Taiwu.VillagerRole;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.Display;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Domains.World.Task;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using GameData.Utilities.Information;
using NLog;
using Redzen.Random;

namespace GameData.Domains.World;

[GameDataDomain(1)]
public class WorldDomain : BaseGameDataDomain
{
	public delegate void ChallengeModeInitialEffectHandler(DataContext context, ChallengeModeInfo info);

	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private uint _worldId;

	[DomainData(DomainDataType.SingleValue, false, true, true, true)]
	private sbyte _xiangshuProgress;

	[DomainData(DomainDataType.ElementList, true, false, true, true, ArrayElementsCount = 9)]
	private readonly XiangshuAvatarTaskStatus[] _xiangshuAvatarTaskStatuses;

	[DomainData(DomainDataType.SingleValue, true, false, true, true, ArrayElementsCount = 9)]
	private sbyte[] _xiangshuAvatarTasksInOrder;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private short _mainStoryLineProgress;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _beatRanChenZi;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private ulong _worldFunctionsStatuses;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private readonly Dictionary<int, string> _customTexts;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private int _nextCustomTextId;

	[DomainData(DomainDataType.SingleValue, false, true, true, true)]
	private WorldStateData _worldStateData;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private Dictionary<short, GameStatRecordWrapper> _gameStatSaved = new Dictionary<short, GameStatRecordWrapper>();

	private Dictionary<short, GameStatRecordWrapper> _gameStats = new Dictionary<short, GameStatRecordWrapper>();

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<short, BigEventRecord> _bigEvents;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private ChallengeModeData _challengeModeData;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private List<int> _waitForDecideChallengeModeIds;

	private static readonly Dictionary<EChallengeModeImplement, ChallengeModeInitialEffectHandler> ChallengeModeInitialEffect = new Dictionary<EChallengeModeImplement, ChallengeModeInitialEffectHandler>
	{
		{
			EChallengeModeImplement.WugKing,
			ApplyChallengeModeWugKing
		},
		{
			EChallengeModeImplement.Exp,
			ApplyChallengeModeExp
		},
		{
			EChallengeModeImplement.MoneyAndResources,
			ApplyChallengeModeMoneyAndResources
		},
		{
			EChallengeModeImplement.MoreActionPoint,
			ApplyChallengeModeMoreActionPointInit
		},
		{
			EChallengeModeImplement.ReincarnationBonus,
			ApplyChallengeModeReincarnationBonus
		},
		{
			EChallengeModeImplement.FuyuFaithAndLegacyPoint,
			ApplyChallengeModeFuyuFaithAndLegacyPoint
		}
	};

	private Version _currWorldGameVersion;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<short, sbyte> _triggeredGuidingChapterDictionary;

	[DomainData(DomainDataType.Binary, true, false, true, true, CollectionCapacity = 1024)]
	private readonly InstantNotificationCollection _instantNotifications;

	private int _instantNotificationsCommittedOffset;

	private readonly List<short> _instantNotificationTemplateIds = new List<short>();

	private readonly Dictionary<short, string> _instantNotificationTemplateId2Name = new Dictionary<short, string>();

	private Type _instantNotificationCollectionType;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _exorcismEnabled;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _onHandingMonthlyEventBlock;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<short, int> _monthlyEventLastTriggerDates;

	private MonthlyEventCollection _monthlyEventCollection;

	private bool _isTaiwuDying;

	private bool _isTaiwuGettingCompletelyInfected;

	private bool _isTaiwuVillageDestroyed;

	public bool IsTaiwuHunterDie;

	private bool _isTaiwuDyingOfDystocia;

	private int _toRepayKindnessCharId = -1;

	private static readonly BinaryHeap<(int offset, int score)> SpecialEvents = new BinaryHeap<(int, int)>(((int offset, int score) a, (int offset, int score) b) => a.score.CompareTo(b.score));

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private List<int> _sortedMonthlyNotificationSortingGroups;

	[Obsolete("Use ExtraDomain._previousMonthlyNotifications instead.")]
	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private MonthlyNotificationCollection _lastMonthlyNotifications;

	private MonthlyNotificationCollection _currMonthlyNotifications = new MonthlyNotificationCollection();

	private readonly List<short> _monthlyNotificationTemplateIds = new List<short>();

	private readonly Dictionary<short, string> _monthlyNotificationTemplateId2Name = new Dictionary<short, string>();

	private Type _monthlyNotificationCollectionType;

	private readonly List<GameData.Domains.Character.Character> _candidatesCharacters = new List<GameData.Domains.Character.Character>();

	private readonly List<TemplateKey> _candidateItems = new List<TemplateKey>();

	private readonly List<short> _candidateCombatSkills = new List<short>();

	private readonly List<short> _candidateSettlements = new List<short>();

	private readonly List<short> _candidateBuildings = new List<short>();

	private readonly List<short> _candidateAdventures = new List<short>();

	private readonly List<(short colorId, short partId)> _candidateCrickets = new List<(short, short)>();

	private readonly List<short> _candidateChickens = new List<short>();

	private readonly List<short> _canTestMonthlyEventTemplateIdList = new List<short>
	{
		87, 88, 89, 90, 66, 68, 70, 72, 73, 74,
		75, 76, 77, 78, 79, 80, 81, 82, 83, 84,
		85, 86, 114, 115, 116, 117, 118, 343, 344, 280,
		61
	};

	private readonly List<(short monthlyEventTemplateId, int selfCharId, int targetCharId)> _testMonthlyEventList = new List<(short, int, int)>();

	private float _probAdjustOfCreatingCharacter;

	public const sbyte ArchiveFilesBackupsCount = 3;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private byte _worldPopulationType;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private byte _characterLifespanType;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private byte _combatDifficulty;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private byte _hereticsAmountType;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private byte _bossInvasionSpeedType;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private byte _worldResourceAmountType;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private byte _readingDifficulty;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private byte _breakoutDifficulty;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private byte _loopingDifficulty;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private byte _enemyPracticeLevel;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private byte _favorabilityChange;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _canResetWorldSettings;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private byte _professionUpgrade;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private short _lootYield;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _allowRandomTaiwuHeir;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _restrictOptionsBehaviorType;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private sbyte _taiwuVillageStateTemplateId;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private sbyte _taiwuVillageLandFormType;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _hideTaiwuOriginalSurname;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _allowExecute;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private sbyte _archiveFilesBackupInterval;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private sbyte _archiveFilesBackupCount;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private int _worldStandardPopulation;

	[DomainData(DomainDataType.SingleValue, false, true, true, true)]
	private List<TaskData> _currTaskList;

	[DomainData(DomainDataType.SingleValue, false, true, true, true)]
	private List<TaskDisplayData> _sortedTaskList;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private List<TaskData> _extraTriggeredTasks;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private List<int> _taskSortingOrder;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private List<int> _pinnedOnTopTasks;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private List<(int, int)> _taskFinishedDateList;

	private const int MonitorIntervalOfAdvancingMonth = 100;

	private const int MinAdvanceMonthTimeMilliseconds = 2000;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private int _currDate;

	[Obsolete("Use ExtraDomain._actionPointCurrMonth instead.")]
	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private sbyte _daysInCurrMonth;

	[DomainData(DomainDataType.SingleValue, false, false, true, false)]
	private sbyte _advancingMonthState;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private Dictionary<sbyte, sbyte> _stateWeathers;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private Dictionary<short, sbyte> _areaStoryWeathers;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private List<MonthNotify> _monthNotifies;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	[Obsolete]
	private Dictionary<int, PermanentMonthNotify> _permanentMonthNotifies;

	private HashSet<NormalInformation> _monthNotifyInformation = new HashSet<NormalInformation>();

	private Dictionary<int, SecretInformationSnapshot> _monthNotifySecretInformation = new Dictionary<int, SecretInformationSnapshot>();

	private HashSet<int> _monthNotifyInBroadcastSecretInformation = new HashSet<int>();

	private int _actionPointPrevMonth;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private GameVersionInfo _worldVersionInfo;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private List<int> _newfeatureTriggered;

	private List<int> cachedResult = new List<int>();

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[59][];

	private SpinLock _spinLockXiangshuProgress = new SpinLock(enableThreadOwnerTracking: false);

	private static readonly DataInfluence[][] CacheInfluencesXiangshuAvatarTaskStatuses = new DataInfluence[9][];

	private readonly byte[] _dataStatesXiangshuAvatarTaskStatuses = new byte[3];

	private SingleValueCollectionModificationCollection<int> _modificationsCustomTexts = SingleValueCollectionModificationCollection<int>.Create();

	private BinaryModificationCollection _modificationsInstantNotifications = BinaryModificationCollection.Create();

	private SpinLock _spinLockCurrTaskList = new SpinLock(enableThreadOwnerTracking: false);

	private SpinLock _spinLockSortedTaskList = new SpinLock(enableThreadOwnerTracking: false);

	private SpinLock _spinLockWorldStateData = new SpinLock(enableThreadOwnerTracking: false);

	private SingleValueCollectionModificationCollection<short> _modificationsBigEvents = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<sbyte> _modificationsStateWeathers = SingleValueCollectionModificationCollection<sbyte>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsGameStatSaved = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsTriggeredGuidingChapterDictionary = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<int> _modificationsPermanentMonthNotifies = SingleValueCollectionModificationCollection<int>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsAreaStoryWeathers = SingleValueCollectionModificationCollection<short>.Create();

	private Queue<uint> _pendingLoadingOperationIds;

	public int ActionPointRecovery => ApplyChallengeModeMoreActionPointRecovery();

	public int ActionPointMax => ApplyChallengeModeMoreActionPointMax();

	[DataUpgrader(Version = "1.0.65", Date = "2026/07/23")]
	private void FixSwordPassingTime(DataContext context)
	{
		DomainManager.World.RequestSetStat(context, 52, DomainManager.Taiwu.GetTaiwuLifeSummaryDisplayData().TotalTaiwuLifeSummaries.Count - 1);
	}

	[DataUpgrader(Version = "1.0.63", Date = "2026/07/21")]
	private void AddNewChallengeMode_260721(DataContext context)
	{
		if (!_challengeModeData.IsEnabled())
		{
			return;
		}
		if (_waitForDecideChallengeModeIds == null)
		{
			_waitForDecideChallengeModeIds = new List<int>();
		}
		foreach (ChallengeModeItem config in ChallengeMode.Instance.Where(IsWaitForDecide))
		{
			_waitForDecideChallengeModeIds.AddUnique(config.TemplateId);
		}
		SetWaitForDecideChallengeModeIds(_waitForDecideChallengeModeIds, context);
	}

	private bool IsWaitForDecide(ChallengeModeItem config)
	{
		if (_challengeModeData.IsEnabled(config.Implement))
		{
			return false;
		}
		EChallengeModeImplement implement = config.Implement;
		return (uint)(implement - 26) <= 1u;
	}

	private void OnInitializedDomainData()
	{
		_monthlyEventCollection = new MonthlyEventCollection();
	}

	private void InitializeOnInitializeGameDataModule()
	{
	}

	private void InitializeOnEnterNewWorld()
	{
		DataContext context = DataContextManager.GetCurrentThreadDataContext();
		_worldId = context.Random.NextUInt();
		_xiangshuProgress = 0;
		_mainStoryLineProgress = 0;
		_worldFunctionsStatuses = 0uL;
		_nextCustomTextId = 0;
		_canResetWorldSettings = false;
		_currDate = GlobalConfig.Instance.GameStartDate;
		_advancingMonthState = 0;
		_instantNotificationsCommittedOffset = 0;
		for (sbyte i = 0; i < _xiangshuAvatarTasksInOrder.Length; i++)
		{
			_xiangshuAvatarTasksInOrder[i] = i;
		}
		CollectionUtils.Shuffle(context.Random, _xiangshuAvatarTasksInOrder);
		RegisterTaskSortingOrderUpdate();
		SetWorldFunctionsStatus(context, 19);
		SetWorldFunctionsStatus(context, 20);
		SetWorldFunctionsStatus(context, 17);
		SetMonthNotifies(_monthNotifies, context);
		Logger.Info($"EnterNewWorld: {_worldId}");
	}

	private void OnLoadedArchiveData()
	{
		CheckWorldGameVersion();
		_instantNotificationsCommittedOffset = _instantNotifications.Size;
		RegisterTaskSortingOrderUpdate();
		InitializeStatData();
		Logger.Info($"LoadWorld: {_worldId}");
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 28 }, Condition = InfluenceCondition.CharIsTaiwu)]
	private sbyte CalcXiangshuProgress()
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (taiwuChar == null)
		{
			return 0;
		}
		int consummateLevel = taiwuChar.GetConsummateLevel();
		return (sbyte)Math.Clamp(consummateLevel, 0, 18);
	}

	[SingleValueDependency(1, new ushort[] { 1, 26, 6 })]
	[ElementListDependency(20, 0, 15)]
	[SingleValueDependency(5, new ushort[] { 22, 0, 7, 8, 55, 65, 31, 69, 70 })]
	[SingleValueDependency(2, new ushort[] { 56 })]
	[ObjectCollectionDependency(4, 0, new ushort[] { 21, 26, 44, 64 }, Condition = InfluenceCondition.CharIsTaiwu)]
	[ObjectCollectionDependency(4, 0, new ushort[] { 104, 103, 94, 19, 26, 17, 111 }, Condition = InfluenceCondition.CharIsInTaiwuGroup)]
	[SingleValueDependency(1, new ushort[] { 45 })]
	[SingleValueDependency(1, new ushort[] { 36 })]
	[SingleValueDependency(1, new ushort[] { 52 })]
	[SingleValueCollectionDependency(19, new ushort[] { 95, 146 })]
	[ElementListDependency(19, 41, 15)]
	[SingleValueCollectionDependency(3, new ushort[] { 14 })]
	[SingleValueDependency(3, new ushort[] { 16, 18 })]
	[SingleValueDependency(2, new ushort[] { 65 })]
	[SingleValueCollectionDependency(4, new ushort[] { 33 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(9, new ushort[] { 11 })]
	[SingleValueDependency(12, new ushort[] { 0 })]
	[ObjectCollectionDependency(4, 0, new ushort[] { 46 }, Condition = InfluenceCondition.CharIsTaiwu)]
	[SingleValueCollectionDependency(5, new ushort[] { 43, 44 })]
	[SingleValueDependency(19, new ushort[] { 10, 122, 120 })]
	[ObjectCollectionDependency(7, 0, new ushort[] { 6 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 259 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(1, new ushort[] { 58 })]
	private WorldStateData CalcWorldStateData()
	{
		WorldStateData value = default(WorldStateData);
		value.DetectEquipmentOverload();
		value.DetectWarehouseOverload();
		value.DetectResourceOverload();
		value.DetectInventoryOverload();
		value.DetectInjuries();
		value.DetectPoisons();
		value.DetectDisorderOfQi();
		value.DetectTeammateInjuries();
		value.DetectXiangshuInvasionProgress();
		value.DetectXiangshuInfection();
		value.DetectMainStory();
		value.DetectXiangshuAvatars();
		value.DetectMartialArtTournament();
		value.DetectChangeWorldCreation();
		value.DetectLoongDebuff();
		value.DetectInFulongFlameArea();
		value.DetectTribulation();
		value.DetectSectMainStory();
		value.DetectTaiwuWanted();
		value.DetectTeammateDying();
		value.DetectHomelessVillager();
		value.DetectNeiliConflicting();
		value.DetectChallengeMode();
		value.DetectLoopingStates();
		value.DetectReadingStates();
		value.DetectChallengeModeChanged();
		return value;
	}

	[ElementListDependency(1, 2, 9)]
	[SingleValueDependency(1, new ushort[] { 6 })]
	[SingleValueDependency(12, new ushort[] { 0 })]
	[SingleValueDependency(5, new ushort[] { 31 })]
	[SingleValueDependency(1, new ushort[] { 45 })]
	[SingleValueDependency(19, new ushort[] { 147 })]
	[SingleValueDependency(10, new ushort[] { 3 })]
	[SingleValueDependency(10, new ushort[] { 2 })]
	[SingleValueCollectionDependency(19, new ushort[] { 146 })]
	[SingleValueCollectionDependency(9, new ushort[] { 0 })]
	[ObjectCollectionDependency(4, 0, new ushort[] { 57, 55, 17 }, Condition = InfluenceCondition.CharIsTaskRelated)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ObjectCollectionDependency(3, 0, new ushort[] { 19 })]
	private void CalcCurrTaskList(List<TaskData> value)
	{
		if (!DomainManager.Global.GetLoadedAllArchiveData())
		{
			return;
		}
		AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
		AdventureRuntime adventure = (adventureTaiwu.InAdventure ? adventureTaiwu.Adventure : null);
		int adventureTaskCount = adventure?.GetParameter("ConchShipPresetKey_Task_Count").Current ?? 0;
		Span<int> span = stackalloc int[adventureTaskCount];
		SpanList<int> adventureLinearChains = span;
		for (int i = 0; i < adventureTaskCount; i++)
		{
			AddExtraTask(value, ref adventureLinearChains, adventure.GetParameter(AdventureConstants.TaskKey(i)).AsTask);
		}
		List<TaskData> extraTriggeredTasks = GetExtraTriggeredTasks();
		span = stackalloc int[Math.Min(extraTriggeredTasks.Count, TaskChain.Instance.Count)];
		SpanList<int> triggeredLinearChains = span;
		foreach (TaskData extraTask in extraTriggeredTasks)
		{
			AddExtraTask(value, ref triggeredLinearChains, extraTask);
		}
		foreach (TaskChainItem chainCfg in (IEnumerable<TaskChainItem>)TaskChain.Instance)
		{
			if (chainCfg.TaskList.Count <= 0)
			{
				continue;
			}
			List<(int, int)> finishedDateList = GetTaskFinishedDateList();
			bool isMainStoryLineOutOfRange = !CheckRequiredTasksStatus(chainCfg);
			bool isStartConditionNotMet = chainCfg.StartConditions.Count > 0 && !chainCfg.StartConditions.TrueForAll(TaskConditionChecker.CheckCondition);
			bool isRemoveConditionMet = chainCfg.RemoveCondtions.Count > 0 && chainCfg.RemoveCondtions.TrueForAll(TaskConditionChecker.CheckCondition);
			bool isTaskChainCanTrigger = !isMainStoryLineOutOfRange && !isStartConditionNotMet && !isRemoveConditionMet;
			if (triggeredLinearChains.Contains(chainCfg.TemplateId) || adventureLinearChains.Contains(chainCfg.TemplateId))
			{
				continue;
			}
			foreach (int taskInfoId in chainCfg.TaskList)
			{
				TaskInfoItem taskCfg = TaskInfo.Instance[taskInfoId];
				if (taskCfg.IsTriggeredTask)
				{
					continue;
				}
				bool isExist = false;
				bool isFinished = false;
				int index = -1;
				for (int j = 0; j < finishedDateList.Count; j++)
				{
					var (infoId, date) = finishedDateList[j];
					if (infoId == taskInfoId)
					{
						isExist = true;
						index = j;
						isFinished = date != -1;
						break;
					}
				}
				if (!isTaskChainCanTrigger && !isFinished)
				{
					continue;
				}
				if (!isFinished)
				{
					if (!CheckRequiredTasksStatus(taskCfg))
					{
						continue;
					}
					if (taskCfg.RunCondition.Count > 0 && !taskCfg.RunCondition.TrueForAll(TaskConditionChecker.CheckCondition))
					{
						if (isExist && taskCfg.FinishCondition.Count <= 0)
						{
							isFinished = true;
							finishedDateList[index] = (taskInfoId, DomainManager.World.GetCurrDate());
						}
						else if (!isExist || taskCfg.FinishCondition.Count <= 0 || taskCfg.FinishCondition.TrueForAll(TaskConditionChecker.CheckCondition))
						{
							continue;
						}
					}
					if (isExist && taskCfg.FinishCondition.Count > 0 && taskCfg.FinishCondition.TrueForAll(TaskConditionChecker.CheckCondition))
					{
						isFinished = true;
						finishedDateList[index] = (taskInfoId, DomainManager.World.GetCurrDate());
					}
					if (!isExist)
					{
						finishedDateList.Add((taskInfoId, -1));
					}
					bool isBlocked = taskCfg.BlockCondition.Count > 0 && taskCfg.BlockCondition.TrueForAll(TaskConditionChecker.CheckCondition);
					TaskData taskData = new TaskData
					{
						TaskChainId = chainCfg.TemplateId,
						TaskInfoId = taskInfoId,
						TaskStatus = (byte)(isFinished ? 2 : (isBlocked ? 1 : 0))
					};
					value.Add(taskData);
				}
				else if (!taskCfg.UnableRepeat && CheckRequiredTasksStatus(taskCfg) && taskCfg.RunCondition.Count > 0 && taskCfg.RunCondition.TrueForAll(TaskConditionChecker.CheckCondition) && ((taskCfg.FinishCondition.Count > 0 && !taskCfg.FinishCondition.TrueForAll(TaskConditionChecker.CheckCondition)) || taskCfg.FinishCondition.Count <= 0))
				{
					finishedDateList.RemoveAt(index);
					finishedDateList.Add((taskInfoId, -1));
					bool isBlocked2 = taskCfg.BlockCondition.Count > 0 && taskCfg.BlockCondition.TrueForAll(TaskConditionChecker.CheckCondition);
					TaskData taskData2 = new TaskData
					{
						TaskChainId = chainCfg.TemplateId,
						TaskInfoId = taskInfoId,
						TaskStatus = (byte)(isBlocked2 ? 1 : 0)
					};
					value.Add(taskData2);
				}
				else
				{
					TaskData taskData3 = new TaskData
					{
						TaskChainId = chainCfg.TemplateId,
						TaskInfoId = taskInfoId,
						TaskStatus = 2
					};
					value.Add(taskData3);
				}
				if (chainCfg.Type != ETaskChainType.Line || isFinished)
				{
					continue;
				}
				break;
			}
		}
	}

	private void AddExtraTask(List<TaskData> value, ref SpanList<int> linearChains, TaskData extraTask)
	{
		TaskInfoItem taskCfg = TaskInfo.Instance[extraTask.TaskInfoId];
		if (!CheckRequiredTasksStatus(taskCfg))
		{
			return;
		}
		TaskChainItem taskChainCfg = TaskChain.Instance[extraTask.TaskChainId];
		if (!CheckRequiredTasksStatus(taskChainCfg))
		{
			return;
		}
		List<int> removeCondtions = taskChainCfg.RemoveCondtions;
		if (removeCondtions == null || removeCondtions.Count <= 0 || !taskChainCfg.RemoveCondtions.TrueForAll(TaskConditionChecker.CheckCondition))
		{
			bool isBlocked = taskCfg.BlockCondition.Count > 0 && taskCfg.BlockCondition.TrueForAll(TaskConditionChecker.CheckCondition);
			TaskData task = extraTask;
			if (task.TaskStatus != 2)
			{
				task.TaskStatus = (byte)(isBlocked ? 1 : 0);
			}
			value.Add(task);
			if (TaskChain.Instance[task.TaskChainId].Type == ETaskChainType.Line && !linearChains.Contains(task.TaskChainId) && task.TaskStatus != 2)
			{
				linearChains.Add(extraTask.TaskChainId);
			}
		}
	}

	private bool CheckRequiredTasksStatus(TaskInfoItem taskCfg)
	{
		return CheckRequiredTasksStatus(taskCfg.RequireFinishedTask, taskCfg.RequireUntriggeredTask);
	}

	private bool CheckRequiredTasksStatus(TaskChainItem taskChainCfg)
	{
		return CheckRequiredTasksStatus(taskChainCfg.RequireFinishedTask, taskChainCfg.RequireUntriggeredTask);
	}

	private bool CheckRequiredTasksStatus(int requiredFinishedTask, int requiredUntriggeredTask)
	{
		if (requiredFinishedTask >= 0 && (!TryGetExtraTriggeredTaskStatus(requiredFinishedTask, out var taskStatus) || taskStatus != 2))
		{
			return false;
		}
		if (requiredUntriggeredTask >= 0 && TryGetExtraTriggeredTaskStatus(requiredUntriggeredTask, out var _))
		{
			return false;
		}
		return true;
	}

	[SingleValueDependency(1, new ushort[] { 29, 46 })]
	private void CalcSortedTaskList(List<TaskDisplayData> value)
	{
		List<TaskData> taskList = GetCurrTaskList();
		List<int> sortingOrder = GetTaskSortingOrder();
		List<(int, int)> finishedDateLists = GetTaskFinishedDateList();
		bool pastTaiwuVillage = DomainManager.Taiwu.AtPastTaiwuVillage();
		foreach (TaskData task in taskList)
		{
			TaskInfoItem taskCfg = TaskInfo.Instance[task.TaskInfoId];
			if (taskCfg == null)
			{
				PredefinedLog.Show(10, task.TaskInfoId);
				continue;
			}
			TaskChainItem taskChainCfg = TaskChain.Instance[task.TaskChainId];
			if (pastTaiwuVillage && taskChainCfg.Group != ETaskChainGroup.MainStory)
			{
				continue;
			}
			TaskDisplayData displayData = new TaskDisplayData
			{
				DisplayType = 0,
				TargetLocation = Location.Invalid,
				SkillIdList = GameData.Utilities.ShortList.Create(),
				CountDown = -1,
				SettlementNameData = new SettlementNameRelatedData
				{
					RandomNameId = -1,
					MapBlockTemplateId = -1
				},
				StringArray = null,
				InnerTaskData = task,
				FinishedDate = -1
			};
			foreach (var (taskInfoId, finishedDate) in finishedDateLists)
			{
				if (task.TaskInfoId == taskInfoId)
				{
					displayData.FinishedDate = finishedDate;
					break;
				}
			}
			foreach (short charId in taskCfg.CharacterTemplateId)
			{
				if (DomainManager.Character.TryGetFixedCharacterByTemplateId(charId, out var character) && character.GetLocation().IsValid())
				{
					displayData.TargetLocation = character.GetLocation();
				}
			}
			ETaskChainGroup eTaskChainGroup = taskChainCfg.Group;
			if (1 == 0)
			{
			}
			EventArgBox eventArgBox = ((eTaskChainGroup != ETaskChainGroup.SectMainStory) ? DomainManager.TaiwuEvent.GetGlobalEventArgumentBox() : DomainManager.Extra.GetSectMainStoryEventArgBox(taskChainCfg.Sect));
			if (1 == 0)
			{
			}
			EventArgBox argBox = eventArgBox;
			int groupId;
			if (argBox != null)
			{
				if (!string.IsNullOrEmpty(taskCfg.EventArgBoxKey))
				{
					if (taskCfg.EventArgBoxKey == SectMainStoryEventArgKey.DefValue.ShaolinStudyForBodhidharmaChallenge.ArgBoxKey)
					{
						displayData.DisplayType |= 64;
						displayData.CountDown = argBox.GetInt(taskCfg.EventArgBoxKey);
					}
					else if (taskCfg.EventArgBoxKey == SectMainStoryEventArgKey.DefValue.RanshanSanZongBiWuCountDown.ArgBoxKey || taskCfg.EventArgBoxKey == SectMainStoryEventArgKey.DefValue.FulongAdventureOneCountDown.ArgBoxKey || taskCfg.EventArgBoxKey == SectMainStoryEventArgKey.DefValue.FulongAdventureThreeCountDown.ArgBoxKey)
					{
						displayData.DisplayType |= 8;
						displayData.CountDown = argBox.GetInt(taskCfg.EventArgBoxKey);
					}
					else
					{
						if (taskCfg.TemplateId == 279)
						{
							displayData.DisplayType |= 128;
							short settlementId = -1;
							argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsMonthEventSettlementId, ref settlementId);
							sbyte fiveElementType = -1;
							argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsFiveElementsType, ref fiveElementType);
							Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
							List<SettlementNameRelatedData> settlementNameDataList = DomainManager.Organization.GetSettlementNameRelatedData(new List<short> { settlement.GetId() });
							displayData.TargetLocation = DomainManager.Organization.GetSettlement(settlementId).GetLocation();
							displayData.SettlementNameData = settlementNameDataList[0];
							displayData.StringArray = new string[2];
							displayData.StringArray[0] = fiveElementType.ToString();
							displayData.StringArray[1] = MathF.Max(0f, 1 - DomainManager.Story.BaihuaGroupMeetCount(isLeuko: true, out groupId)).ToString();
							value.Add(displayData);
							continue;
						}
						if (taskCfg.TemplateId == 281)
						{
							displayData.DisplayType |= 128;
							short settlementId2 = -1;
							argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsMonthEventSettlementId, ref settlementId2);
							sbyte fiveElementType2 = -1;
							argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsFiveElementsType, ref fiveElementType2);
							Settlement settlement2 = DomainManager.Organization.GetSettlement(settlementId2);
							List<SettlementNameRelatedData> settlementNameDataList2 = DomainManager.Organization.GetSettlementNameRelatedData(new List<short> { settlement2.GetId() });
							displayData.TargetLocation = DomainManager.Organization.GetSettlement(settlementId2).GetLocation();
							displayData.SettlementNameData = settlementNameDataList2[0];
							displayData.StringArray = new string[2];
							displayData.StringArray[0] = fiveElementType2.ToString();
							displayData.StringArray[1] = MathF.Max(0f, 1 - DomainManager.Story.BaihuaGroupMeetCount(isLeuko: false, out groupId)).ToString();
							value.Add(displayData);
							continue;
						}
						if (!displayData.TargetLocation.IsValid())
						{
							short settlementId3 = -1;
							if (argBox.Get(taskCfg.EventArgBoxKey, out displayData.TargetLocation))
							{
								MapBlockData blockData = DomainManager.Map.GetBlock(displayData.TargetLocation);
								if (blockData.IsCityTown())
								{
									MapBlockData settlementBlock = blockData.GetRootBlock();
									Location location = settlementBlock.GetLocation();
									Settlement settlement3 = DomainManager.Organization.GetSettlementByLocation(location);
									if (settlement3 != null)
									{
										List<SettlementNameRelatedData> settlementNameDataList3 = DomainManager.Organization.GetSettlementNameRelatedData(new List<short> { settlement3.GetId() });
										displayData.SettlementNameData = settlementNameDataList3[0];
									}
								}
							}
							else if (argBox.Get(taskCfg.EventArgBoxKey, ref settlementId3))
							{
								displayData.TargetLocation = DomainManager.Organization.GetSettlement(settlementId3).GetLocation();
								List<SettlementNameRelatedData> settlementNameDataList4 = DomainManager.Organization.GetSettlementNameRelatedData(new List<short> { settlementId3 });
								displayData.SettlementNameData = settlementNameDataList4[0];
							}
							else
							{
								displayData.TargetLocation = Location.Invalid;
							}
						}
					}
				}
				string[] combatSkillIdsEventArgBoxKey = taskCfg.CombatSkillIdsEventArgBoxKey;
				if (combatSkillIdsEventArgBoxKey != null && combatSkillIdsEventArgBoxKey.Length > 0)
				{
					displayData.DisplayType |= 1;
					string[] combatSkillIdsEventArgBoxKey2 = taskCfg.CombatSkillIdsEventArgBoxKey;
					foreach (string key in combatSkillIdsEventArgBoxKey2)
					{
						short skillId = -1;
						if (argBox.Get(key, ref skillId) && skillId > -1 && DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(DomainManager.Taiwu.GetTaiwuCharId(), skillId), out var skill) && !skill.GetRevoked() && !CombatSkillStateHelper.IsBrokenOut(skill.GetActivationState()))
						{
							displayData.SkillIdList.Items.Add(skillId);
						}
					}
				}
				combatSkillIdsEventArgBoxKey = taskCfg.SkillIdsEventArgBoxKey;
				if (combatSkillIdsEventArgBoxKey != null && combatSkillIdsEventArgBoxKey.Length > 0)
				{
					displayData.DisplayType |= 4;
					string[] skillIdsEventArgBoxKey = taskCfg.SkillIdsEventArgBoxKey;
					foreach (string key2 in skillIdsEventArgBoxKey)
					{
						short skillId2 = argBox.GetShort(key2);
						if (skillId2 > -1)
						{
							displayData.SkillIdList.Items.Add(skillId2);
						}
					}
				}
				combatSkillIdsEventArgBoxKey = taskCfg.StringArrayEventArgBoxKey;
				if (combatSkillIdsEventArgBoxKey != null && combatSkillIdsEventArgBoxKey.Length > 0)
				{
					displayData.DisplayType |= 32;
					displayData.StringArray = new string[taskCfg.StringArrayEventArgBoxKey.Length];
					int k = 0;
					for (int max = taskCfg.StringArrayEventArgBoxKey.Length; k < max; k++)
					{
						displayData.StringArray[k] = argBox.GetString(taskCfg.StringArrayEventArgBoxKey[k]);
					}
				}
			}
			if (displayData.TargetLocation.IsValid())
			{
				displayData.DisplayType |= 2;
			}
			if (taskCfg.FrontEndKey != null)
			{
				displayData.DisplayType |= 16;
			}
			groupId = taskCfg.TemplateId;
			if (groupId >= 238 && groupId <= 242)
			{
				short loongCharacterTemplateId = (short)(taskCfg.TemplateId - 238 + 246);
				if (DomainManager.Extra.TryGetElement_FiveLoongDict(loongCharacterTemplateId, out var loongInfo))
				{
					displayData.DisplayType |= 2;
					displayData.TargetLocation = loongInfo.LoongCurrentLocation;
				}
			}
			if (taskCfg.TemplateId == 307)
			{
				displayData.DisplayType |= 256;
				displayData.TargetLocations = new List<Location>();
				if (DomainManager.Building.ChickenMapInfo.Count == 0)
				{
					DomainManager.Building.ClickChickenMap(DataContextManager.GetCurrentThreadDataContext(), ignoreTask: true);
				}
				if (DomainManager.Building.ChickenMapInfo.Count == 0)
				{
					short settlementId4 = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
					DomainManager.Building.ChickenMapInfo.Add(settlementId4);
				}
				for (int l = 0; l < DomainManager.Building.ChickenMapInfo.Count; l++)
				{
					short settlementId5 = DomainManager.Building.ChickenMapInfo[l];
					Settlement settlement4 = DomainManager.Organization.GetSettlement(settlementId5);
					displayData.TargetLocations.Add(settlement4.GetLocation());
				}
				List<SettlementNameRelatedData> settlementNameDataList5 = DomainManager.Organization.GetSettlementNameRelatedData(DomainManager.Building.ChickenMapInfo);
				displayData.SettlementNameDatas = settlementNameDataList5;
			}
			value.Add(displayData);
		}
		value.Sort(delegate(TaskDisplayData a, TaskDisplayData b)
		{
			if (a.InnerTaskData.IsBlocked != b.InnerTaskData.IsBlocked)
			{
				return a.InnerTaskData.IsBlocked.CompareTo(b.InnerTaskData.IsBlocked);
			}
			int num = sortingOrder.IndexOf(a.InnerTaskData.TaskInfoId);
			int num2 = sortingOrder.IndexOf(b.InnerTaskData.TaskInfoId);
			if (num != -1 && num2 != -1)
			{
				return num.CompareTo(num2);
			}
			if (num != -1)
			{
				return -1;
			}
			if (num2 != -1)
			{
				return 1;
			}
			TaskInfoItem taskInfoItem = TaskInfo.Instance[a.InnerTaskData.TaskInfoId];
			TaskInfoItem taskInfoItem2 = TaskInfo.Instance[b.InnerTaskData.TaskInfoId];
			if (a.InnerTaskData.TaskChainId == b.InnerTaskData.TaskChainId)
			{
				int num3 = taskInfoItem.IndexInChain.CompareTo(taskInfoItem2.IndexInChain);
				if (num3 != 0)
				{
					return num3;
				}
				return taskInfoItem.TemplateId.CompareTo(taskInfoItem2.TemplateId);
			}
			return (taskInfoItem.TaskOrder == taskInfoItem2.TaskOrder) ? taskInfoItem.TemplateId.CompareTo(taskInfoItem2.TemplateId) : taskInfoItem.TaskOrder.CompareTo(taskInfoItem2.TaskOrder);
		});
	}

	public void SetStat(DataContext context, short statId, GameStatRecordWrapper value)
	{
		_gameStats[statId] = value;
		StatInfoItem config = StatInfo.Instance[statId];
		if (config.SaveType == EStatInfoSaveType.Local)
		{
			if (!_gameStatSaved.ContainsKey(statId))
			{
				AddElement_GameStatSaved(statId, value, context);
			}
			else
			{
				SetElement_GameStatSaved(statId, value, context);
			}
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

	public bool StatContains(short statId, int value)
	{
		if (_gameStats.TryGetValue(statId, out var wrapper) && wrapper.Contains(value))
		{
			return true;
		}
		return false;
	}

	public bool StatOverlaps(short statId1, short statId2)
	{
		if (StatInfo.Instance[statId1].Type == StatInfo.Instance[statId2].Type && _gameStats.TryGetValue(statId1, out var wrapper1) && _gameStats.TryGetValue(statId2, out var wrapper2))
		{
			return wrapper1.Overlaps(wrapper2);
		}
		return false;
	}

	[DomainMethod]
	public void RequestSetStat(DataContext context, short statId, int value)
	{
		AchievementManager.RequestSetStat(context, statId, value);
	}

	[DomainMethod]
	public void ResetStatsAndAchievements(DataContext context)
	{
		AchievementManager.ResetStatsAndAchievements(context);
	}

	public void ClearAllStat(DataContext context)
	{
		_gameStats.Clear();
		ClearGameStatSaved(context);
	}

	private void InitializeStatData()
	{
		_gameStats.Clear();
		foreach (var (id, data) in _gameStatSaved)
		{
			_gameStats[id] = data;
		}
	}

	internal void BigEventGainSwordTombRemoved(DataContext context, sbyte swordTombType)
	{
		SwordTombItem swordTombCfg = SwordTomb.Instance.GetItem(swordTombType);
		if (swordTombCfg != null)
		{
			if (!TryGetElement_BigEvents(swordTombCfg.BigEventWhenRemoved, out var bigEventRecord))
			{
				AddElement_BigEvents(swordTombCfg.BigEventWhenRemoved, bigEventRecord = new BigEventRecord(), context);
			}
			bigEventRecord.OccurDate = DomainManager.World.GetCurrDate();
			SetElement_BigEvents(swordTombCfg.BigEventWhenRemoved, bigEventRecord, context);
		}
	}

	public void InitializeChallengeMode(DataContext context, IReadOnlyList<int> challengeModeIds)
	{
		if (challengeModeIds == null)
		{
			challengeModeIds = Array.Empty<int>();
		}
		ChallengeModeData data = new ChallengeModeData(challengeModeIds);
		SetChallengeModeData(data, context);
	}

	public void ApplyChallengeModeInitialEffect(DataContext context, ChallengeModeInfo info)
	{
		HashSet<EChallengeModeImplement> initialModes = new HashSet<EChallengeModeImplement>();
		foreach (ChallengeModeItem mode in (IEnumerable<ChallengeModeItem>)ChallengeMode.Instance)
		{
			if (IsChallengeModeEnabled(mode.Implement))
			{
				initialModes.Add(mode.Implement);
			}
		}
		foreach (EChallengeModeImplement implement in initialModes)
		{
			if (ChallengeModeInitialEffect.TryGetValue(implement, out var handler))
			{
				handler(context, info);
			}
		}
	}

	public bool IsChallengeModeEnabled(EChallengeModeImplement implement)
	{
		return _challengeModeData.IsEnabled(implement);
	}

	public void ApplyChallengeModeDamageStep(DamageStepCollection stepCollection, bool isAlly)
	{
		if (IsChallengeModeEnabled(EChallengeModeImplement.DamageStep) && DomainManager.Combat.TaiwuInAllyMainChar)
		{
			CValuePercentBonus injuryAndFatalStepBonus = ApplyChallengeModeDamageStep(isAlly, DefeatMarkKey.Invalid);
			CValuePercentBonus mindStepBonus = ApplyChallengeModeDamageStep(isAlly, EMarkType.Mind);
			stepCollection.FatalDamageStep *= injuryAndFatalStepBonus;
			stepCollection.MindDamageStep *= mindStepBonus;
			for (int i = 0; i < 7; i++)
			{
				stepCollection.OuterDamageSteps[i] *= injuryAndFatalStepBonus;
				stepCollection.InnerDamageSteps[i] *= injuryAndFatalStepBonus;
			}
		}
	}

	private CValuePercentBonus ApplyChallengeModeDamageStep(bool isAlly, DefeatMarkKey markKey)
	{
		EMarkType type = markKey.Type;
		if (1 == 0)
		{
		}
		int num = ((type != EMarkType.Mind) ? (isAlly ? (-50) : 100) : (isAlly ? (-25) : 50));
		if (1 == 0)
		{
		}
		return num;
	}

	public void ApplyChallengeModeBuildingWorkHard(ref int progress)
	{
		_challengeModeData.ApplyChallengeModeBuildingWorkHard(ref progress);
	}

	public void ApplyChallengeModeScarMark(ref bool enabled)
	{
		enabled = IsChallengeModeEnabled(EChallengeModeImplement.ScarMark);
	}

	public int ApplyChallengeModeAttainment(int qualification)
	{
		if (!IsChallengeModeEnabled(EChallengeModeImplement.Attainment) || qualification <= 90)
		{
			return qualification;
		}
		return 90 + (qualification - 90) * 600 / (qualification + 600);
	}

	public void ApplyChallengeModeQiDisorder(DataContext context, CombatCharacter combatChar, int neiliAllocationDelta)
	{
		if (IsChallengeModeEnabled(EChallengeModeImplement.QiDisorder))
		{
			CValuePercentBonus qiDisorderBonus = (combatChar.IsAlly ? 100 : (-50));
			int addQiDisorder = Math.Abs(neiliAllocationDelta) * 2 * qiDisorderBonus;
			if (addQiDisorder != 0)
			{
				DomainManager.Combat.ChangeDisorderOfQiRandomRecovery(context, combatChar, addQiDisorder);
			}
		}
	}

	public void ApplyChallengeModeAdvanceMonthWorsen(IRandomSource random, GameData.Domains.Character.Character character, ref Injuries injuries, ref PoisonInts poisoned, PeriAdvanceMonthUpdateStatusModification mod)
	{
		if (!IsChallengeModeEnabled(EChallengeModeImplement.AdvanceMonthWorsen))
		{
			return;
		}
		CValuePercent worsenFactor = (character.CanAffectedByCombatDifficulty ? 20 : 100);
		int innerModifier = Math.Min((int)character.GetMaxMainAttribute(4), 100);
		int outerModifier = Math.Min((int)character.GetMaxMainAttribute(3), 100);
		for (sbyte i = 0; i < 7; i++)
		{
			(sbyte outer, sbyte inner) tuple = injuries.Get(i);
			sbyte outerInjury = tuple.outer;
			sbyte innerInjury = tuple.inner;
			int innerWorsenRate = innerInjury * 30 - innerModifier;
			if (innerInjury < 6 && random.CheckPercentProb(innerWorsenRate * worsenFactor))
			{
				injuries.Change(i, isInnerInjury: true, 1);
				mod.ChallengeModeWorsenInjuryCount.Inner++;
			}
			int outerWorsenRate = injuries.Get(i, isInnerInjury: false) * innerWorsenRate - outerModifier;
			if (outerInjury < 6 && random.CheckPercentProb(outerWorsenRate * worsenFactor))
			{
				injuries.Change(i, isInnerInjury: false, 1);
				mod.ChallengeModeWorsenInjuryCount.Outer++;
			}
		}
		CValuePercentBonus poisonWorsenValue = 50;
		for (sbyte i2 = 0; i2 < 6; i2++)
		{
			int poisonValue = poisoned.Get(i2);
			if ((poisonValue > 0 && poisonValue < 25000) || 1 == 0)
			{
				sbyte poisonLevel = PoisonsAndLevels.CalcPoisonedLevel(poisonValue);
				int modifier = Math.Min(character.GetPoisonResist(i2), 1000) / 10;
				int worsenRate = poisonLevel * 50 - modifier;
				if (random.CheckPercentProb(worsenRate * worsenFactor))
				{
					int newPoisonValue = Math.Min(poisonValue * poisonWorsenValue, 25000);
					poisoned[i2] = newPoisonValue;
					mod.ChallengeModeWorsenAnyPoison = true;
				}
			}
		}
	}

	public int ApplyChallengeModeEffectDamageFactor(CombatCharacter combatChar, DefeatMarkKey markKey)
	{
		if (IsChallengeModeEnabled(EChallengeModeImplement.EffectDamageFactor))
		{
			return GlobalConfig.Instance.ChallengeEffectDamageFactor.GetDamageStep(markKey) * ApplyChallengeModeDamageStep(combatChar.IsAlly, markKey);
		}
		return combatChar.GetDamageStepCollection().GetDamageStep(markKey);
	}

	private static void ApplyChallengeModeWugKing(DataContext context, ChallengeModeInfo info)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		for (sbyte i = 0; i < 8; i++)
		{
			short wugKingTemplateId = ItemDomain.GetWugTemplateId(i, 5);
			for (int ii = 0; ii < 3; ii++)
			{
				ItemKey wugKingItemKey = DomainManager.Item.CreateMedicine(context, wugKingTemplateId);
				taiwu.AddInventoryItem(context, wugKingItemKey, 1, offLine: true);
			}
		}
		taiwu.SetInventory(taiwu.GetInventory(), context);
	}

	private static void ApplyChallengeModeReincarnationBonus(DataContext context, ChallengeModeInfo info)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		short featureId = ((info != null && info.ReincarnationBonusFeatureId >= 0) ? info.ReincarnationBonusFeatureId : ((short)context.Random.Next(232, 242)));
		taiwu.AddFeature(context, featureId);
		DomainManager.Character.CreatePreexistenceCharactersForChallengeMode(context, taiwu);
	}

	private static void ApplyChallengeModeExp(DataContext context, ChallengeModeInfo info)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		taiwu.ChangeExp(context, 1000000);
	}

	private static void ApplyChallengeModeMoneyAndResources(DataContext context, ChallengeModeInfo info)
	{
		ResourceInts delta = default(ResourceInts);
		delta.Initialize();
		delta[6] = 250000;
		for (int i = 0; i < 6; i++)
		{
			delta[i] = 50000;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		taiwu.ChangeResources(context, ref delta);
	}

	public void ApplyChallengeModeAutoReadBook(DataContext context, ItemKey itemKey)
	{
		if (!IsChallengeModeEnabled(EChallengeModeImplement.AutoReadBook) || !DomainManager.Item.TryGetElement_SkillBooks(itemKey.Id, out var book) || !book.AnyCompletePage())
		{
			return;
		}
		ushort pageState = book.GetPageIncompleteState();
		int pageCount = (book.IsCombatSkillBook() ? 6 : 5);
		TaiwuLifeSkill lifeSkill;
		TaiwuCombatSkill combatSkill;
		sbyte[] readState = ((!book.IsCombatSkillBook()) ? (DomainManager.Taiwu.TryGetElement_LifeSkills(book.GetCombatSkillTemplateId(), out lifeSkill) ? lifeSkill.GetAllBookPageReadingProgress() : null) : (DomainManager.Taiwu.TryGetElement_CombatSkills(book.GetCombatSkillTemplateId(), out combatSkill) ? combatSkill.GetAllBookPageReadingProgress() : null));
		for (byte i = 0; i < pageCount; i++)
		{
			if (SkillBookStateHelper.GetPageIncompleteState(pageState, i) == 0)
			{
				byte internalIndex = (book.IsCombatSkillBook() ? CombatSkillStateHelper.GetPageInternalIndex(book.GetPageTypes(), i) : i);
				sbyte progress = readState?.GetOrDefault(internalIndex) ?? 0;
				if (progress != 100)
				{
					DomainManager.Taiwu.ReadSkillBookPageAndSetComplete(context, book, i);
				}
			}
		}
	}

	public void ApplyChallengeModeAutoReadBookAtAllExistBook(DataContext context)
	{
		if (!IsChallengeModeEnabled(EChallengeModeImplement.AutoReadBook))
		{
			return;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		foreach (ItemKey itemKey in taiwu.GetInventory().Items.Keys)
		{
			if (itemKey.ItemType == 10)
			{
				ApplyChallengeModeAutoReadBook(context, itemKey);
			}
		}
	}

	private int ApplyChallengeModeMoreActionPointRecovery()
	{
		return IsChallengeModeEnabled(EChallengeModeImplement.MoreActionPoint) ? GlobalConfig.Instance.MoreActionPointRecoveryPerMonth : GlobalConfig.Instance.ActionPointRecoveryPerMonth;
	}

	private int ApplyChallengeModeMoreActionPointMax()
	{
		return IsChallengeModeEnabled(EChallengeModeImplement.MoreActionPoint) ? GlobalConfig.Instance.MoreActionPointLimitPerMonth : GlobalConfig.Instance.ActionPointLimitPerMonth;
	}

	private static void ApplyChallengeModeMoreActionPointInit(DataContext context, ChallengeModeInfo info)
	{
		int addValue = GlobalConfig.Instance.MoreActionPointRecoveryPerMonth - GlobalConfig.Instance.ActionPointRecoveryPerMonth;
		DomainManager.Extra.ChangeActionPoint(context, addValue);
	}

	private static void ApplyChallengeModeFuyuFaithAndLegacyPoint(DataContext context, ChallengeModeInfo info)
	{
		DomainManager.Character.AddFuyuFaith(context, 1000);
		DomainManager.Taiwu.AddLegacyPoint(context, 51);
	}

	[DomainMethod]
	public bool DecideNewChallengeMode(DataContext context, int modeId, bool enable)
	{
		List<int> waitForDecideChallengeModeIds = _waitForDecideChallengeModeIds;
		if (waitForDecideChallengeModeIds == null || waitForDecideChallengeModeIds.Count <= 0 || !_waitForDecideChallengeModeIds.Contains(modeId))
		{
			return false;
		}
		_waitForDecideChallengeModeIds.Remove(modeId);
		SetWaitForDecideChallengeModeIds(_waitForDecideChallengeModeIds, context);
		if (enable)
		{
			_challengeModeData.AppendEnabledChallengeMode(modeId);
			SetChallengeModeData(_challengeModeData, context);
		}
		return true;
	}

	public sbyte GetXiangshuLevel()
	{
		return SharedMethods.GetXiangshuLevel(GetXiangshuProgress());
	}

	public Dictionary<short, BigEventRecord> GetBigEvents()
	{
		return _bigEvents;
	}

	public sbyte GetMaxGradeOfXiangshuInfection()
	{
		return SharedMethods.GetMaxGradeOfXiangshuInfection(GetXiangshuProgress());
	}

	public int GetDefeatSwordTombCount()
	{
		int count = 0;
		for (int xiangshuAvatarId = 0; xiangshuAvatarId < 9; xiangshuAvatarId++)
		{
			if (GetElement_XiangshuAvatarTaskStatuses(xiangshuAvatarId).SwordTombStatus == 2)
			{
				count++;
			}
		}
		return count;
	}

	public void SetSwordTombStatus(DataContext context, sbyte xiangshuAvatarId, sbyte swordTombStatus)
	{
		if (DomainManager.Combat.GetIsPuppetCombat())
		{
			return;
		}
		XiangshuAvatarTaskStatus taskStatus = _xiangshuAvatarTaskStatuses[xiangshuAvatarId];
		if (swordTombStatus <= taskStatus.SwordTombStatus)
		{
			return;
		}
		int delta = swordTombStatus - taskStatus.SwordTombStatus;
		taskStatus.SwordTombStatus = swordTombStatus;
		SetElement_XiangshuAvatarTaskStatuses(xiangshuAvatarId, taskStatus, context);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		taiwuChar.ChangeConsummateLevel(context, delta);
		DomainManager.Taiwu.UpdateConsummateLevelBrokenFeature(context);
		if (swordTombStatus == 2)
		{
			sbyte level = TaiwuDomain.GetWorldCreationGroupLevel(0);
			short legacy = SwordTomb.Instance[xiangshuAvatarId].Legacies[level];
			if (DomainManager.Taiwu.AddAvailableLegacy(context, legacy))
			{
				DomainManager.Combat.AddCombatResultLegacy(legacy);
			}
			DomainManager.World.BigEventGainSwordTombRemoved(context, xiangshuAvatarId);
			DomainManager.Taiwu.RecordLifeSummary(context, 86 + xiangshuAvatarId);
		}
	}

	[Obsolete]
	public void ChangeMainStoryLineProgress(DataContext context, short progress)
	{
		if (!MainStoryLineProgress.CheckTransition(_mainStoryLineProgress, progress))
		{
			throw new Exception($"Invalid transition: {_mainStoryLineProgress} -> {progress}");
		}
		Logger.Info($"Main storyline progress is being changed to {progress}.");
		if (progress == 27)
		{
			DomainManager.Organization.TryRemoveTaiwuGroupBountyAndPunishment(context);
		}
		if (progress == 8)
		{
			DomainManager.Building.SetAllResidenceAutoCheckIn(context);
		}
		if (progress == 3)
		{
			GameData.Domains.Character.Character victim = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 892);
			victim.AddDarkAsh(context, null, 0);
			victim.DirectlyChangeDarkAshDuration(context, DomainManager.World.GetCurrDate(), 0, 0, 6);
		}
		if (progress == 6)
		{
			Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(138);
			for (int i = 0; i < areaBlocks.Length; i++)
			{
				MapBlockData block = areaBlocks[i];
				if (block.TemplateId != 36)
				{
					continue;
				}
				Settlement settlement = DomainManager.Organization.GetSettlementByLocation(new Location(138, block.BlockId));
				int max = context.Random.Next(GlobalConfig.Instance.BrokenPerformDarkAshInfectorRangeMax) + GlobalConfig.Instance.BrokenPerformDarkAshInfectorBase;
				foreach (int member in settlement.GetMembers())
				{
					if (DomainManager.Character.TryGetElement_Objects(member, out var character) && character.GetDarkAshProtector() == 0 && character.GetActualAge() >= 16 && max-- > 0)
					{
						character.AddDarkAsh(context);
					}
				}
				break;
			}
		}
		if (progress == 16 && !DomainManager.Extra.GetIsDreamBack())
		{
			DomainManager.Character.AddFuyuFaith(context, GlobalConfig.FuyuFaithCountBySaveInfected[^1]);
			DomainManager.World.GetInstantNotificationCollection().AddGainFuyuFaith3(GlobalConfig.FuyuFaithCountBySaveInfected[^1]);
		}
		SetMainStoryLineProgress(progress, context);
	}

	public bool CheckCurrMainStoryLineProgressInRange(short min, short max)
	{
		return _mainStoryLineProgress >= min && _mainStoryLineProgress < max;
	}

	public bool GetWorldFunctionsStatus(byte worldFunctionType)
	{
		return WorldFunctionType.Get(_worldFunctionsStatuses, worldFunctionType);
	}

	public void SetWorldFunctionsStatus(DataContext context, byte worldFunctionType)
	{
		ulong worldFunctionStatuses = WorldFunctionType.Set(_worldFunctionsStatuses, worldFunctionType);
		if (worldFunctionStatuses != _worldFunctionsStatuses)
		{
			SetWorldFunctionsStatuses(worldFunctionStatuses, context);
			Logger.Info($"Unlocking world function: {worldFunctionType}");
		}
	}

	public void ResetWorldFunctionsStatus(DataContext context, byte worldFunctionType)
	{
		ulong worldFunctionStatuses = WorldFunctionType.Reset(_worldFunctionsStatuses, worldFunctionType);
		if (worldFunctionStatuses != _worldFunctionsStatuses)
		{
			SetWorldFunctionsStatuses(worldFunctionStatuses, context);
			Logger.Info($"Reseting world function status: {worldFunctionType}");
		}
	}

	[DomainMethod]
	public void CreateWorld(DataContext context, WorldCreationInfo info, List<int> challengeModeIds)
	{
		Stopwatch sw = GlobalDomain.StartTimer();
		SetWorldCreationInfo(context, info, inherit: false);
		InitializeChallengeMode(context, challengeModeIds);
		InitializeWorldVersionInfo(context);
		context.SwitchRandomSource(_worldId);
		DomainManager.Map.CreateAllAreas(context);
		DomainManager.Character.CreatePregeneratedCityTownGuards(context);
		DomainManager.Character.CreatePregeneratedRandomEnemies(context);
		DomainManager.Character.CreatePregeneratedFixedEnemies(context);
		Stopwatch sw2 = GlobalDomain.StartTimer();
		DomainManager.Extra.CreatePickups(context);
		GlobalDomain.StopTimer(sw2, "CreatePickups");
		GlobalDomain.StopTimer(sw, "CreateWorld");
	}

	[DomainMethod]
	public void SetWorldCreationInfo(DataContext context, WorldCreationInfo info, bool inherit)
	{
		SetWorldPopulationType(info.WorldPopulationType, context);
		SetCharacterLifespanType(info.CharacterLifespanType, context);
		SetCombatDifficulty(info.CombatDifficulty, context);
		SetHereticsAmountType(info.HereticsAmountType, context);
		byte prevBossInvasionType = GetBossInvasionSpeedType();
		SetBossInvasionSpeedType(info.BossInvasionSpeedType, context);
		SetWorldResourceAmountType(info.WorldResourceAmountType, context);
		SetAllowRandomTaiwuHeir(info.AllowRandomTaiwuHeir, context);
		SetRestrictOptionsBehaviorType(info.RestrictOptionsBehaviorType, context);
		SetTaiwuVillageStateTemplateId(info.TaiwuVillageStateTemplateId, context);
		SetTaiwuVillageLandFormType(info.TaiwuVillageLandFormType, context);
		SetReadingDifficulty(info.ReadingDifficulty, context);
		SetBreakoutDifficulty(info.BreakoutDifficulty, context);
		SetLoopingDifficulty(info.LoopingDifficulty, context);
		SetEnemyPracticeLevel(info.EnemyPracticeLevel, context);
		SetFavorabilityChange(info.FavorabilityChange, context);
		SetProfessionUpgrade(info.ProfessionUpgrade, context);
		SetLootYield(info.LootYield, context);
		if (!inherit)
		{
			SetCanResetWorldSettings(value: false, context);
		}
		if (GetXiangshuProgress() > 0 && prevBossInvasionType != info.BossInvasionSpeedType)
		{
			Events.RaiseBossInvasionSpeedTypeChanged(context, prevBossInvasionType);
		}
	}

	[DomainMethod]
	public WorldCreationInfo GetWorldCreationInfo()
	{
		return new WorldCreationInfo
		{
			WorldPopulationType = GetWorldPopulationType(),
			CharacterLifespanType = GetCharacterLifespanType(),
			CombatDifficulty = GetCombatDifficulty(),
			ReadingDifficulty = GetReadingDifficulty(),
			BreakoutDifficulty = GetBreakoutDifficulty(),
			LoopingDifficulty = GetLoopingDifficulty(),
			EnemyPracticeLevel = GetEnemyPracticeLevel(),
			FavorabilityChange = GetFavorabilityChange(),
			ProfessionUpgrade = GetProfessionUpgrade(),
			LootYield = GetLootYield(),
			HereticsAmountType = GetHereticsAmountType(),
			BossInvasionSpeedType = GetBossInvasionSpeedType(),
			WorldResourceAmountType = GetWorldResourceAmountType(),
			AllowRandomTaiwuHeir = GetAllowRandomTaiwuHeir(),
			RestrictOptionsBehaviorType = GetRestrictOptionsBehaviorType(),
			TaiwuVillageStateTemplateId = GetTaiwuVillageStateTemplateId(),
			TaiwuVillageLandFormType = GetTaiwuVillageLandFormType()
		};
	}

	public WorldInfo GetWorldInfo()
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		(string surname, string givenName) realName = CharacterDomain.GetRealName(taiwu);
		string surname = realName.surname;
		string givenName = realName.givenName;
		Location location = taiwu.GetLocation();
		if (!location.IsValid())
		{
			location = taiwu.GetValidLocation();
		}
		var (stateTemplateId, areaTemplateId) = DomainManager.Map.GetStateAndAreaNameTemplateIdByAreaId(location.AreaId);
		return new WorldInfo
		{
			CurrDate = GetCurrDate(),
			TaiwuGenerationsCount = DomainManager.Taiwu.GetTaiwuGenerationsCount(),
			SavingTimestamp = DateTime.UtcNow.Ticks,
			TaiwuSurname = surname,
			TaiwuGivenName = givenName,
			Gender = taiwu.GetGender(),
			AvatarRelatedData = taiwu.GenerateAvatarRelatedData(),
			CharacterLifespanType = GetCharacterLifespanType(),
			CombatDifficulty = GetCombatDifficulty(),
			BreakoutDifficulty = GetBreakoutDifficulty(),
			ReadingDifficulty = GetReadingDifficulty(),
			LoopingDifficulty = GetLoopingDifficulty(),
			EnemyPracticeLevel = GetEnemyPracticeLevel(),
			FavorabilityChange = GetFavorabilityChange(),
			ProfessionUpgrade = GetProfessionUpgrade(),
			LootYield = GetLootYield(),
			HereticsAmountType = GetHereticsAmountType(),
			BossInvasionSpeedType = GetBossInvasionSpeedType(),
			WorldResourceAmountType = GetWorldResourceAmountType(),
			WorldPopulationType = GetWorldPopulationType(),
			AllowRandomTaiwuHeir = GetAllowRandomTaiwuHeir(),
			RestrictOptionsBehaviorType = GetRestrictOptionsBehaviorType(),
			StateTaskStatuses = DomainManager.Story.GetSectMainStoryTaskStatuses().ToArray(),
			XiangshuAvatarTaskStatuses = _xiangshuAvatarTaskStatuses.ToArray(),
			MainStoryLineProgress = _mainStoryLineProgress,
			BeatRanChenZi = _beatRanChenZi,
			ModIds = ModDomain.GetLoadedModIds(),
			DlcIds = DlcManager.GetAllInstalledDlcIds(),
			GameVersionInfo = GetWorldVersionInfo(),
			TotalTaiwuLifeSummaryInfo = DomainManager.Taiwu.GetTotalTaiwuLifeSummaryInfo(),
			WorldFunctionStatuses = GetWorldFunctionsStatuses(),
			MapStateTemplateId = stateTemplateId,
			MapAreaTemplateId = areaTemplateId
		};
	}

	public void UpdateCurrWorldGameVersion()
	{
		GameVersionInfo gameVersionInfo = GetWorldVersionInfo();
		_currWorldGameVersion = ((gameVersionInfo != null && !string.IsNullOrEmpty(gameVersionInfo.GameVersionLastSaving)) ? GameVersionInfo.ParseGameVersion(gameVersionInfo.GameVersionLastSaving) : null);
	}

	public Version GetCurrWorldGameVersion()
	{
		return _currWorldGameVersion;
	}

	public bool IsCurrWorldBeforeVersion(int major, int minor = 0, int build = 0, int revision = 0)
	{
		if (_currWorldGameVersion == null)
		{
			return false;
		}
		if (_currWorldGameVersion.Major != major)
		{
			return _currWorldGameVersion.Major < major;
		}
		if (_currWorldGameVersion.Minor != minor)
		{
			return _currWorldGameVersion.Minor < minor;
		}
		if (_currWorldGameVersion.Build != build)
		{
			return _currWorldGameVersion.Build < build;
		}
		if (_currWorldGameVersion.Revision != revision)
		{
			return _currWorldGameVersion.Revision < revision;
		}
		return false;
	}

	public bool IsCurrWorldAfterVersion(int major, int minor = 0, int build = 0, int revision = 0)
	{
		if (_currWorldGameVersion == null)
		{
			return false;
		}
		if (_currWorldGameVersion.Major != major)
		{
			return _currWorldGameVersion.Major > major;
		}
		if (_currWorldGameVersion.Minor != minor)
		{
			return _currWorldGameVersion.Minor > minor;
		}
		if (_currWorldGameVersion.Build != build)
		{
			return _currWorldGameVersion.Build > build;
		}
		if (_currWorldGameVersion.Revision != revision)
		{
			return _currWorldGameVersion.Revision > revision;
		}
		return false;
	}

	public bool IsCurrWorldSavedWithVersion(int major, int minor, int build, int revision)
	{
		if (_currWorldGameVersion == null)
		{
			return false;
		}
		if (_currWorldGameVersion.Major != major)
		{
			return false;
		}
		if (_currWorldGameVersion.Minor != minor)
		{
			return false;
		}
		if (_currWorldGameVersion.Build != build)
		{
			return false;
		}
		if (_currWorldGameVersion.Revision != revision)
		{
			return false;
		}
		return true;
	}

	public int RegisterCustomText(DataContext context, string text)
	{
		if (text == null)
		{
			throw new Exception("Text can not be null");
		}
		int id = GenerateNextCustomTextId(context);
		AddElement_CustomTexts(id, text, context);
		return id;
	}

	public void UnregisterCustomText(DataContext context, int id)
	{
		RemoveElement_CustomTexts(id, context);
	}

	public IReadOnlyDictionary<int, string> GetCustomTexts()
	{
		return _customTexts;
	}

	[DomainMethod]
	public List<Location> GetJuniorXiangshuLocations()
	{
		List<Location> locations = new List<Location>();
		XiangshuAvatarTaskStatus[] xiangshuAvatarTaskStatuses = _xiangshuAvatarTaskStatuses;
		for (int i = 0; i < xiangshuAvatarTaskStatuses.Length; i++)
		{
			XiangshuAvatarTaskStatus xiangshuTaskStatus = xiangshuAvatarTaskStatuses[i];
			if (xiangshuTaskStatus.JuniorXiangshuCharId < 0)
			{
				locations.Add(Location.Invalid);
				continue;
			}
			Location location = DomainManager.Character.GetElement_Objects(xiangshuTaskStatus.JuniorXiangshuCharId).GetLocation();
			locations.Add(location);
		}
		return locations;
	}

	public void ChangeXiangshuAvatarFavorability(DataContext context, sbyte xiangshuAvatarId, int delta)
	{
		XiangshuAvatarTaskStatus avatarStatus = _xiangshuAvatarTaskStatuses[xiangshuAvatarId];
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		GameData.Domains.Character.Character xiangshuAvatarChar = DomainManager.Character.GetElement_Objects(avatarStatus.JuniorXiangshuCharId);
		DomainManager.Character.DirectlyChangeFavorabilityOptional(context, xiangshuAvatarChar, taiwuChar, delta, 4);
	}

	public short GetXiangshuAvatarFavorability(sbyte xiangshuAvatarId)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		XiangshuAvatarTaskStatus avatarStatus = _xiangshuAvatarTaskStatuses[xiangshuAvatarId];
		return DomainManager.Character.GetFavorability(avatarStatus.JuniorXiangshuCharId, taiwuCharId);
	}

	public sbyte GetXiangshuAvatarFavorabilityType(sbyte xiangshuAvatarId)
	{
		return FavorabilityType.GetFavorabilityType(DomainManager.World.GetXiangshuAvatarFavorability(xiangshuAvatarId));
	}

	public void TransferXiangshuAvatarRelations(DataContext context, int oldTaiwuCharId, int newTaiwuCharId)
	{
		for (int avatarId = 0; avatarId < 9; avatarId++)
		{
			XiangshuAvatarTaskStatus xiangshuAvatarTaskStatus = _xiangshuAvatarTaskStatuses[avatarId];
			int avatarCharId = xiangshuAvatarTaskStatus.JuniorXiangshuCharId;
			if (DomainManager.Character.TryGetElement_Objects(avatarCharId, out var _))
			{
				RelatedCharacter taiwuToTarget = DomainManager.Character.GetRelation(oldTaiwuCharId, avatarCharId);
				RelatedCharacter targetToTaiwu = DomainManager.Character.GetRelation(avatarCharId, oldTaiwuCharId);
				DomainManager.Character.DirectlySetFavorabilities(context, newTaiwuCharId, avatarCharId, taiwuToTarget.Favorability, targetToTaiwu.Favorability);
				SetElement_XiangshuAvatarTaskStatuses(avatarId, xiangshuAvatarTaskStatus, context);
			}
		}
	}

	public void SetJuniorXiangshuTaskStatus(DataContext context, sbyte xiangshuAvatarId, sbyte taskStatus)
	{
		if (xiangshuAvatarId >= 9)
		{
			throw new ArgumentOutOfRangeException("xiangshuAvatarId", xiangshuAvatarId, $"Valid range [0, {8}");
		}
		XiangshuAvatarTaskStatus status = GetElement_XiangshuAvatarTaskStatuses(xiangshuAvatarId);
		if (status.JuniorXiangshuTaskStatus != taskStatus)
		{
			status.JuniorXiangshuTaskStatus = taskStatus;
			SetElement_XiangshuAvatarTaskStatuses(xiangshuAvatarId, status, context);
			if ((uint)(taskStatus - 5) <= 1u)
			{
				DomainManager.Taiwu.RecordLifeSummary(context, 104 + xiangshuAvatarId);
			}
		}
	}

	public bool IsXiangshuAvatarTaskStatusesGood(sbyte xiangshuAvatarId)
	{
		return DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(xiangshuAvatarId).JuniorXiangshuTaskStatus == 6;
	}

	public string GetWorldDateKey()
	{
		int currYear = GetCurrYear() + 1;
		int currMonth = GetCurrMonthInYear() + 1;
		return $"{_worldId}_{currYear}_{currMonth}";
	}

	[DomainMethod]
	public WorldStateData RequestWorldStateData()
	{
		return GetWorldStateData();
	}

	private int GenerateNextCustomTextId(DataContext context)
	{
		int customTextId = _nextCustomTextId;
		_nextCustomTextId++;
		if ((uint)_nextCustomTextId > 2147483647u)
		{
			_nextCustomTextId = 0;
		}
		SetNextCustomTextId(_nextCustomTextId, context);
		return customTextId;
	}

	public override void PackCrossArchiveGameData(CrossArchiveGameData crossArchiveGameData)
	{
		crossArchiveGameData.CustomTexts = _customTexts;
		crossArchiveGameData.NextCustomTextId = _nextCustomTextId;
		crossArchiveGameData.FinalDateBeforeDreamBack = _currDate;
		crossArchiveGameData.WorldCreationInfo = GetWorldCreationInfo();
		crossArchiveGameData.WorldId = _worldId;
	}

	public override void UnpackCrossArchiveGameData(DataContext context, CrossArchiveGameData crossArchiveGameData)
	{
		foreach (KeyValuePair<int, string> pair in crossArchiveGameData.CustomTexts)
		{
			if (_customTexts.ContainsKey(pair.Key))
			{
				SetElement_CustomTexts(pair.Key, pair.Value, context);
			}
			else
			{
				AddElement_CustomTexts(pair.Key, pair.Value, context);
			}
		}
		SetNextCustomTextId(Math.Max(crossArchiveGameData.NextCustomTextId, _nextCustomTextId), context);
		SetWorldCreationInfo(context, crossArchiveGameData.WorldCreationInfo, inherit: false);
		if (crossArchiveGameData.WorldId != _worldId)
		{
			PredefinedLog.Show(16);
		}
	}

	[DomainMethod]
	public void GmCmd_AddSectJieqingNpcExtraLegacyPoints(DataContext context, int charId, int delta)
	{
		DomainManager.Extra.AddSectJieqingNpcExtraLegacyPoints(context, charId, delta);
	}

	[DomainMethod]
	public void GmCmd_AddExtraTask(DataContext context, int taskChainId, int taskInfoId)
	{
		TriggerExtraTask(context, taskChainId, taskInfoId);
	}

	[DomainMethod]
	public void GmCmd_RemoveTriggeredExtraTask(DataContext context, int taskChainId, int taskInfoId)
	{
		FinishTriggeredExtraTask(context, taskChainId, taskInfoId);
	}

	[DomainMethod]
	public void GmCmd_AddResetWorldSettingsChance(DataContext context)
	{
		SetCanResetWorldSettings(value: true, context);
	}

	[DomainMethod]
	public void TriggeredGuidingChapter(DataContext context, short templateId, EGuidingChapterState state = EGuidingChapterState.NewTriggered)
	{
		if (templateId >= 0 && templateId < GuidingChapter.Instance.Count && ((state >= EGuidingChapterState.NewTriggered && state <= EGuidingChapterState.Finished) || 1 == 0))
		{
			if (!_triggeredGuidingChapterDictionary.TryGetValue(templateId, out var existState))
			{
				AddElement_TriggeredGuidingChapterDictionary(templateId, (sbyte)state, context);
			}
			else if (existState < (sbyte)state)
			{
				SetElement_TriggeredGuidingChapterDictionary(templateId, (sbyte)state, context);
			}
		}
	}

	[DomainMethod]
	public void GmCmd_SetAllGuidingChapter(DataContext context, bool value)
	{
		if (!value)
		{
			ClearTriggeredGuidingChapterDictionary(context);
			return;
		}
		for (short i = 0; i < GuidingChapter.Instance.Count; i++)
		{
			TriggeredGuidingChapter(context, i);
		}
	}

	public InstantNotificationCollection GetInstantNotificationCollection()
	{
		return _instantNotifications;
	}

	public void CommitInstantNotifications(DataContext context)
	{
		int deltaSize = _instantNotifications.Size - _instantNotificationsCommittedOffset;
		if (deltaSize > 0)
		{
			CommitInsert_InstantNotifications(context, _instantNotificationsCommittedOffset, deltaSize);
			CommitSetMetadata_InstantNotifications(context);
			_instantNotificationsCommittedOffset = _instantNotifications.Size;
		}
	}

	private void RemoveObsoletedInstantNotifications(DataContext context)
	{
		int deletedSize = RemoveObsoletedInstantNotificationsInternal(context);
		_instantNotificationsCommittedOffset -= deletedSize;
	}

	private unsafe int RemoveObsoletedInstantNotificationsInternal(DataContext context)
	{
		int thresholdDate = GetCurrDate() - 12;
		int index = -1;
		int offset = -1;
		bool foundDemarcationPoint = false;
		fixed (byte* pRawData = _instantNotifications.RawData)
		{
			while (_instantNotifications.Next(ref index, ref offset))
			{
				byte* pCurrData = pRawData + offset;
				int currDate = *(int*)(pCurrData + 1);
				if (currDate >= thresholdDate)
				{
					foundDemarcationPoint = true;
					break;
				}
			}
		}
		if (foundDemarcationPoint)
		{
			if (index <= 0)
			{
				return 0;
			}
			_instantNotifications.Remove(0, offset);
			_instantNotifications.Count -= index;
			CommitRemove_InstantNotifications(context, 0, offset);
			CommitSetMetadata_InstantNotifications(context);
			return offset;
		}
		if (_instantNotifications.Count <= 0)
		{
			return 0;
		}
		int size = _instantNotifications.Size;
		_instantNotifications.Remove(0, size);
		_instantNotifications.Count = 0;
		CommitRemove_InstantNotifications(context, 0, size);
		CommitSetMetadata_InstantNotifications(context);
		return size;
	}

	public void PrepareTestInstantNotificationRelatedData()
	{
		if (_instantNotificationTemplateIds.Count <= 0)
		{
			InitializeTestInstantNotificationRelatedData();
		}
	}

	public void AddRandomInstantNotification(DataContext context, InstantNotificationCollection notifications)
	{
		int selectedIndex = context.Random.Next(_instantNotificationTemplateIds.Count);
		short templateId = _instantNotificationTemplateIds[selectedIndex];
		InstantNotificationItem config = InstantNotification.Instance[templateId];
		string name = _instantNotificationTemplateId2Name[config.TemplateId];
		MethodInfo methodInfo = _instantNotificationCollectionType.GetMethod("Add" + name);
		Tester.Assert(methodInfo != null);
		List<object> arguments = new List<object>();
		GameData.Domains.Character.Character character = null;
		int i = 0;
		for (int count = config.Parameters.Length; i < count; i++)
		{
			string paramName = config.Parameters[i];
			if (string.IsNullOrEmpty(paramName))
			{
				break;
			}
			sbyte paramType = ParameterType.Parse(paramName);
			AddNotificationArguments(context.Random, arguments, paramType, ref character);
		}
		methodInfo.Invoke(notifications, arguments.ToArray());
	}

	private void InitializeTestInstantNotificationRelatedData()
	{
		_instantNotificationTemplateIds.Clear();
		_instantNotificationTemplateId2Name.Clear();
		Type defKeysType = Type.GetType("Config.InstantNotification+DefKey");
		Tester.Assert(defKeysType != null);
		FieldInfo[] defKeysFieldInfos = defKeysType.GetFields(BindingFlags.Static | BindingFlags.Public);
		FieldInfo[] array = defKeysFieldInfos;
		foreach (FieldInfo info in array)
		{
			string name = info.Name;
			short templateId = (short)info.GetValue(null);
			_instantNotificationTemplateIds.Add(templateId);
			_instantNotificationTemplateId2Name.Add(templateId, name);
		}
		_instantNotificationCollectionType = Type.GetType("GameData.Domains.World.Notification.InstantNotificationCollection");
	}

	[DomainMethod]
	public void OnClickDamageHugeSword(DataContext context)
	{
		DomainManager.TaiwuEvent.OnEvent_ClickDamageHugeSword();
	}

	public void CheckMonthlyEvents(DataContext context)
	{
		AddTestMonthlyEvent(context);
		if (_isTaiwuVillageDestroyed)
		{
			_monthlyEventCollection.Clear();
			_monthlyEventCollection.AddTaiwuVillageBeDestoryed();
			ResetFlag();
			Logger.Info("CheckMonthlyEvents: TaiwuVillageBeDestroyed.");
			return;
		}
		if (DomainManager.Taiwu.GetTaiwu().GetLocation().AreaId == 138 && EventHelper.GlobalArgBoxContainsKey<Location>("WangliuLocation"))
		{
			Location wangliuLocation = EventHelper.GetObjectFromGlobalArgBox<Location>("WangliuLocation");
			List<Location> outLocations = EventHelper.GetMapBlocksNearLocation(wangliuLocation, 3);
			List<Location> innerLocations = EventHelper.GetMapBlocksNearLocation(wangliuLocation, 2);
			outLocations.RemoveAll((Location e) => innerLocations.Contains(e));
			bool isAllRuin = true;
			foreach (Location eLocation in outLocations)
			{
				MapBlockData block = DomainManager.Map.GetBlock(eLocation);
				if (block.BlockSubType != EMapBlockSubType.Ruin)
				{
					isAllRuin = false;
					break;
				}
			}
			if (isAllRuin)
			{
				_monthlyEventCollection.Clear();
				_monthlyEventCollection.AddAreaTotallyDestoryed(DomainManager.Taiwu.GetTaiwuCharId());
				Logger.Info("CheckMonthlyEvents: AreaTotallyDestoryed.");
				return;
			}
		}
		if (_isTaiwuDying || _isTaiwuGettingCompletelyInfected)
		{
			_monthlyEventCollection.Clear();
			GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
			if (_isTaiwuDying)
			{
				_monthlyEventCollection.AddTaiwuDeath(taiwuChar.GetId(), taiwuChar.GetLocation());
			}
			else
			{
				_monthlyEventCollection.AddTaiwuInfected(taiwuChar.GetId(), taiwuChar.GetLocation());
				AchievementManager.RequestSetStat(context, 229, 2);
			}
			ResetFlag();
			Events.RaisePassingLegacyWhileAdvancingMonth(context);
			Logger.Info("CheckMonthlyEvents: LegacyPassing.");
			return;
		}
		KidnappedTravelData kidnappedData = DomainManager.Extra.GetKidnappedTravelData();
		if (kidnappedData.Valid)
		{
			_monthlyEventCollection.Clear();
			if (IsTaiwuHunterDie)
			{
				_monthlyEventCollection.AddTaiwuBeHuntedHunterDie(kidnappedData.HunterCharId, DomainManager.Taiwu.GetTaiwuCharId());
				ResetFlag();
			}
			return;
		}
		DomainManager.Extra.TriggerTaiwuVillageVowMonthlyEvent(context);
		DomainManager.Taiwu.AddJieqingPunishmentMonthlyEvent(context);
		DomainManager.Adventure.CheckRandomEnemyAttackTaiwuOnAdvanceMonth();
		DomainManager.Extra.CheckAnimalAttackTaiwuOnAdvanceMonth(context.Random);
		UpdateMonthlyEventToRepayKindness(context);
		DomainManager.Taiwu.UpdateTaiwuBequests(context);
		CheckAutoTriggerMonthlyEvents(context);
		CheckWorldStateMonthlyEvents();
		CheckTaskMonthlyEvents();
		RemoveAllInvalidMonthlyEvents(context);
		TrimSpecialMonthlyEvents(context);
		Logger.Info($"{"CheckMonthlyEvents"}: {_monthlyEventCollection.Count} events detected.");
		void ResetFlag()
		{
			_isTaiwuDying = false;
			_isTaiwuGettingCompletelyInfected = false;
			_isTaiwuDyingOfDystocia = false;
			_isTaiwuVillageDestroyed = false;
			IsTaiwuHunterDie = false;
		}
	}

	[DomainMethod]
	public void HandleMonthlyEvent(DataContext context, int offset)
	{
		short recordType = _monthlyEventCollection.GetRecordType(offset);
		MonthlyEventItem configData = Config.MonthlyEvent.Instance[recordType];
		int size = _monthlyEventCollection.GetRecordSize(offset);
		switch (recordType)
		{
		case 1:
			EventHelper.TriggerLegacyPassingEvent(isTaiwuDying: true, string.Empty);
			DomainManager.TaiwuEvent.SetEventInProcessing(configData.Event);
			return;
		case 3:
			EventHelper.TriggerLegacyPassingEvent(isTaiwuDying: false, string.Empty);
			DomainManager.TaiwuEvent.SetEventInProcessing(configData.Event);
			return;
		}
		if (!string.IsNullOrEmpty(configData.Event))
		{
			GameData.Domains.TaiwuEvent.TaiwuEvent taiwuEvent = DomainManager.TaiwuEvent.GetEvent(configData.Event);
			if (taiwuEvent != null)
			{
				if (taiwuEvent.ArgBox == null)
				{
					taiwuEvent.ArgBox = DomainManager.TaiwuEvent.GetEventArgBox();
				}
				_monthlyEventCollection.FillEventArgBox(offset, taiwuEvent.ArgBox);
				if (!taiwuEvent.EventConfig.CheckCondition())
				{
					throw new Exception($"monthly event {configData.Name} is triggering {taiwuEvent.EventGuid} when OnCheckEventCondition return false.");
				}
				DomainManager.TaiwuEvent.AddTriggeredEvent(taiwuEvent);
				DomainManager.TaiwuEvent.SetEventInProcessing(configData.Event);
			}
			else
			{
				Logger.Warn($"Monthly Event {configData.Name} ({configData.Event}) not found.");
			}
		}
		Logger.Info($"Removing monthly event {recordType} at {offset} of size {size} from a collection of size {_monthlyEventCollection.Size} and count {_monthlyEventCollection.Count}");
		if (_monthlyEventCollection.Size == 0)
		{
			Logger.AppendWarning("MonthlyEventCollection is empty.");
			return;
		}
		_monthlyEventCollection.Remove(offset, size);
		_monthlyEventCollection.Count--;
	}

	[DomainMethod]
	public MonthlyEventCollection GetMonthlyEventCollection()
	{
		return _monthlyEventCollection;
	}

	[DomainMethod]
	public void RemoveAllInvalidMonthlyEvents(DataContext context)
	{
		int index = -1;
		int offset = -1;
		List<int> toRemoveOffsets = ObjectPool<List<int>>.Instance.Get();
		toRemoveOffsets.Clear();
		EventArgBox argBox = DomainManager.TaiwuEvent.GetEventArgBox();
		bool notInAdventure = DomainManager.Adventure.GetAdventureTaiwu().NotInAdventure;
		while (_monthlyEventCollection.Next(ref index, ref offset))
		{
			short recordType = _monthlyEventCollection.GetRecordType(offset);
			MonthlyEventItem monthlyEventCfg = Config.MonthlyEvent.Instance[recordType];
			if (string.IsNullOrEmpty(monthlyEventCfg.Event))
			{
				if (monthlyEventCfg.TemplateId == 0)
				{
					DomainManager.Taiwu.CheckNotInInventoryBooks(context);
					if (!DomainManager.Taiwu.GetCurReadingBook().IsValid())
					{
						toRemoveOffsets.Add(offset);
					}
				}
				continue;
			}
			if (!monthlyEventCfg.AllowInAdventure && !notInAdventure)
			{
				toRemoveOffsets.Add(offset);
				continue;
			}
			GameData.Domains.TaiwuEvent.TaiwuEvent taiwuEvent = DomainManager.TaiwuEvent.GetEvent(monthlyEventCfg.Event);
			if (taiwuEvent == null)
			{
				Logger.AppendWarning("Cannot find monthly event " + monthlyEventCfg.Name + ": " + monthlyEventCfg.Event);
				toRemoveOffsets.Add(offset);
				continue;
			}
			_monthlyEventCollection.FillEventArgBox(offset, argBox);
			taiwuEvent.ArgBox = argBox;
			if (!taiwuEvent.EventConfig.CheckCondition())
			{
				toRemoveOffsets.Add(offset);
			}
			taiwuEvent.ArgBox = null;
		}
		for (int i = toRemoveOffsets.Count - 1; i >= 0; i--)
		{
			int toRemoveOffset = toRemoveOffsets[i];
			short recordType2 = _monthlyEventCollection.GetRecordType(toRemoveOffset);
			int recordSize = _monthlyEventCollection.GetRecordSize(toRemoveOffset);
			MonthlyEventItem recordName = Config.MonthlyEvent.Instance[recordType2];
			Logger.Info($"Removing monthly event {recordName}({recordType2}) at {toRemoveOffset} of size {recordSize} from a collection of size {_monthlyEventCollection.Size} and count {_monthlyEventCollection.Count}");
			_monthlyEventCollection.Remove(toRemoveOffset, recordSize);
			_monthlyEventCollection.Count--;
		}
		DomainManager.TaiwuEvent.ReturnArgBox(argBox);
		ObjectPool<List<int>>.Instance.Return(toRemoveOffsets);
	}

	private bool IsMonthlyEventInCooldown(short templateId)
	{
		if (!_monthlyEventLastTriggerDates.TryGetValue(templateId, out var date))
		{
			return false;
		}
		return _currDate - date < Config.MonthlyEvent.Instance[templateId].AutoTriggerInterval;
	}

	private void TrimSpecialMonthlyEvents(DataContext context)
	{
		int availableScore = 15;
		int index = -1;
		int offset = -1;
		SpecialEvents.Clear();
		while (_monthlyEventCollection.Next(ref index, ref offset))
		{
			short recordType = _monthlyEventCollection.GetRecordType(offset);
			MonthlyEventItem cfg = Config.MonthlyEvent.Instance[recordType];
			if (cfg.Type == EMonthlyEventType.SpecialEvent)
			{
				SpecialEvents.Push((offset, cfg.Score));
			}
		}
		List<int> toRemoveOffsets = context.AdvanceMonthRelatedData.IntList.Occupy();
		while (SpecialEvents.Count > 0)
		{
			(int, int) item = SpecialEvents.Pop();
			if (availableScore < item.Item2)
			{
				toRemoveOffsets.Add(item.Item1);
			}
			else
			{
				availableScore -= item.Item2;
			}
		}
		if (toRemoveOffsets.Count == 0)
		{
			context.AdvanceMonthRelatedData.IntList.Release(ref toRemoveOffsets);
			return;
		}
		toRemoveOffsets.Sort();
		for (int i = toRemoveOffsets.Count - 1; i >= 0; i--)
		{
			int toRemoveOffset = toRemoveOffsets[i];
			int recordSize = _monthlyEventCollection.GetRecordSize(toRemoveOffset);
			Logger.Info($"{"TrimSpecialMonthlyEvents"}: Removing monthly event {recordSize} at {toRemoveOffset} of size {recordSize} from a collection of size {_monthlyEventCollection.Size} and count {_monthlyEventCollection.Count}");
			_monthlyEventCollection.Remove(toRemoveOffset, recordSize);
			_monthlyEventCollection.Count--;
		}
		context.AdvanceMonthRelatedData.IntList.Release(ref toRemoveOffsets);
	}

	public void ClearTrivialMonthlyEvents(DataContext context)
	{
		int index = -1;
		int offset = -1;
		EventArgBox argBox = DomainManager.TaiwuEvent.GetEventArgBox();
		sbyte behaviorType = DomainManager.Taiwu.GetTaiwu().GetBehaviorType();
		while (_monthlyEventCollection.Next(ref index, ref offset))
		{
			short recordType = _monthlyEventCollection.GetRecordType(offset);
			MonthlyEventItem cfg = Config.MonthlyEvent.Instance[recordType];
			if (cfg.Type != EMonthlyEventType.SpecialEvent)
			{
				if (cfg.Type == EMonthlyEventType.LockedEvent)
				{
					Logger.AppendWarning("Monthly Event " + cfg.Name + " is a locked event which cannot be cleared or handled with default option.");
				}
				else if (!string.IsNullOrEmpty(cfg.Event))
				{
					argBox.Clear();
					argBox.Set("DefaultHandleFlag", arg: true);
					_monthlyEventCollection.FillEventArgBox(offset, argBox);
					DomainManager.TaiwuEvent.ProcessEventWithDefaultOption(cfg.Event, argBox, behaviorType);
				}
			}
		}
		DomainManager.TaiwuEvent.ReturnArgBox(argBox);
		_monthlyEventCollection.Clear();
		SetOnHandingMonthlyEventBlock(value: false, context);
	}

	[DomainMethod]
	public void ProcessAllMonthlyEventsWithDefaultOption(DataContext context)
	{
		int index = -1;
		int offset = -1;
		EventArgBox argBox = DomainManager.TaiwuEvent.GetEventArgBox();
		sbyte behaviorType = DomainManager.Taiwu.GetTaiwu().GetBehaviorType();
		while (_monthlyEventCollection.Next(ref index, ref offset))
		{
			short recordType = _monthlyEventCollection.GetRecordType(offset);
			MonthlyEventItem cfg = Config.MonthlyEvent.Instance[recordType];
			if (cfg.Type == EMonthlyEventType.SpecialEvent || cfg.Type == EMonthlyEventType.LockedEvent)
			{
				Logger.AppendWarning(cfg.Name + " is a special event that cannot be handled with default option.");
			}
			else if (!string.IsNullOrEmpty(cfg.Event))
			{
				argBox.Clear();
				argBox.Set("DefaultHandleFlag", arg: true);
				_monthlyEventCollection.FillEventArgBox(offset, argBox);
				DomainManager.TaiwuEvent.ProcessEventWithDefaultOption(cfg.Event, argBox, behaviorType);
			}
		}
		DomainManager.TaiwuEvent.ReturnArgBox(argBox);
		_monthlyEventCollection.Clear();
		SetOnHandingMonthlyEventBlock(value: false, context);
	}

	public void EscapeDuringMonthlyEvent(DataContext context)
	{
		if (!DomainManager.Taiwu.GetNeedToEscape())
		{
			Tester.Assert(!_isTaiwuDying && !_isTaiwuGettingCompletelyInfected);
			Tester.Assert(_advancingMonthState == 14);
			DomainManager.Taiwu.SetNeedToEscape(value: true, context);
			ClearTrivialMonthlyEvents(context);
			_monthlyEventCollection.Clear();
		}
	}

	public void SetTaiwuDying(bool isTaiwuDyingOfDystocia = false)
	{
		if (!_isTaiwuDying)
		{
			_isTaiwuDying = true;
			_isTaiwuDyingOfDystocia = isTaiwuDyingOfDystocia;
		}
	}

	public void SetTaiwuGettingCompletelyInfected()
	{
		_isTaiwuGettingCompletelyInfected = true;
	}

	public void SetTaiwuVillageDestroyed()
	{
		_isTaiwuVillageDestroyed = true;
	}

	public void SetToRepayKindnessCharId(int charId)
	{
		_toRepayKindnessCharId = charId;
	}

	public void UpdateMonthlyEventToRepayKindness(DataContext context)
	{
		if (GameData.Domains.Character.Character.IsCharacterIdValid(_toRepayKindnessCharId) && DomainManager.Character.TryGetElement_Objects(_toRepayKindnessCharId, out var _))
		{
			MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
			monthlyEventCollection.AddToRepayKindness(DomainManager.Taiwu.GetTaiwu().GetValidLocation());
		}
	}

	public int GetToRepayKindnessCharId()
	{
		return _toRepayKindnessCharId;
	}

	public bool ClearMonthlyEventCollectionNotEndGame()
	{
		return _isTaiwuDying || _isTaiwuGettingCompletelyInfected || DomainManager.Extra.GetKidnappedTravelData().Valid;
	}

	private void CheckTaskMonthlyEvents()
	{
		MonthlyEventCollection monthlyEventCollection = GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotifications = GetMonthlyNotificationCollection();
		List<TaskData> taskList = GetCurrTaskList();
		HashSet<int> taskChainSet = ObjectPool<HashSet<int>>.Instance.Get();
		foreach (TaskData task in taskList)
		{
			if (!task.IsInProgress)
			{
				continue;
			}
			taskChainSet.Add(task.TaskChainId);
			TaskInfoItem taskInfo = TaskInfo.Instance[task.TaskInfoId];
			AutoTriggerMonthlyEvent[] monthlyEvents = taskInfo.MonthlyEvents;
			if (monthlyEvents == null || monthlyEvents.Length <= 0)
			{
				continue;
			}
			sbyte orgTemplateId = TaskChain.Instance[task.TaskChainId].Sect;
			EventArgBox argBox = ((orgTemplateId >= 0 && OrganizationDomain.IsSect(orgTemplateId)) ? DomainManager.Extra.GetSectMainStoryEventArgBox(orgTemplateId) : DomainManager.TaiwuEvent.GetGlobalEventArgumentBox());
			monthlyEvents = taskInfo.MonthlyEvents;
			if (monthlyEvents != null && monthlyEvents.Length > 0)
			{
				AutoTriggerMonthlyEvent[] monthlyEvents2 = taskInfo.MonthlyEvents;
				foreach (AutoTriggerMonthlyEvent autoMonthlyEvent in monthlyEvents2)
				{
					monthlyEventCollection.AddAutoMonthlyEvent(argBox, autoMonthlyEvent);
				}
			}
			short[] monthlyNotifications2 = taskInfo.MonthlyNotifications;
			if (monthlyNotifications2 != null && monthlyNotifications2.Length > 0)
			{
				short[] monthlyNotifications3 = taskInfo.MonthlyNotifications;
				foreach (short monthlyNotification in monthlyNotifications3)
				{
					monthlyNotifications.AddMonthlyNotificationWithNoArgument(monthlyNotification);
				}
			}
		}
		foreach (int taskChainId in taskChainSet)
		{
			TaskChainItem taskChainCfg = TaskChain.Instance[taskChainId];
			sbyte orgTemplateId2 = taskChainCfg.Sect;
			EventArgBox argBox2 = ((orgTemplateId2 >= 0 && OrganizationDomain.IsSect(orgTemplateId2)) ? DomainManager.Extra.GetSectMainStoryEventArgBox(orgTemplateId2) : DomainManager.TaiwuEvent.GetGlobalEventArgumentBox());
			AutoTriggerMonthlyEvent[] monthlyEvents3 = taskChainCfg.MonthlyEvents;
			foreach (AutoTriggerMonthlyEvent autoMonthlyEvent2 in monthlyEvents3)
			{
				monthlyEventCollection.AddAutoMonthlyEvent(argBox2, autoMonthlyEvent2);
			}
		}
		ObjectPool<HashSet<int>>.Instance.Return(taskChainSet);
	}

	private void CheckWorldStateMonthlyEvents()
	{
		MonthlyEventCollection monthlyEventCollection = GetMonthlyEventCollection();
		WorldStateData worldStates = GetWorldStateData();
		foreach (WorldStateItem worldStateCfg in (IEnumerable<WorldStateItem>)WorldState.Instance)
		{
			short[] monthlyEvents = worldStateCfg.MonthlyEvents;
			if (monthlyEvents != null && monthlyEvents.Length > 0 && worldStates.GetWorldState(worldStateCfg.TemplateId))
			{
				short[] monthlyEvents2 = worldStateCfg.MonthlyEvents;
				foreach (short monthlyEventId in monthlyEvents2)
				{
					monthlyEventCollection.AddWorldStateMonthlyEvent(worldStateCfg, Config.MonthlyEvent.Instance[monthlyEventId]);
				}
			}
		}
	}

	private void CheckAutoTriggerMonthlyEvents(DataContext context)
	{
		MonthlyEventCollection monthlyEventCollection = GetMonthlyEventCollection();
		EventArgBox globalArgBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		foreach (MonthlyEventItem monthlyEventCfg in (IEnumerable<MonthlyEventItem>)Config.MonthlyEvent.Instance)
		{
			if (monthlyEventCfg.AutoTriggerChance > 0 && !IsMonthlyEventInCooldown(monthlyEventCfg.TemplateId))
			{
				if (_monthlyEventLastTriggerDates.ContainsKey(monthlyEventCfg.TemplateId))
				{
					SetElement_MonthlyEventLastTriggerDates(monthlyEventCfg.TemplateId, _currDate, context);
				}
				else
				{
					AddElement_MonthlyEventLastTriggerDates(monthlyEventCfg.TemplateId, _currDate, context);
				}
				if (context.Random.CheckPercentProb(monthlyEventCfg.AutoTriggerChance))
				{
					monthlyEventCollection.AddAutoMonthlyEvent(globalArgBox, monthlyEventCfg);
				}
			}
		}
	}

	public MonthlyNotificationCollection GetMonthlyNotificationCollection()
	{
		return _currMonthlyNotifications;
	}

	private void CheckMonthlyNotifications(DataContext context)
	{
		MonthlyNotificationCollection monthlyNotifications = GetMonthlyNotificationCollection();
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		EventArgBox globalArgBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		int yirenId = -1;
		if (globalArgBox.Get("Yiren", ref yirenId) && DomainManager.Character.TryGetElement_Objects(yirenId, out var yiren))
		{
			Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
			if (!taiwuChar.GetLocation().Equals(taiwuVillageLocation) && yiren.GetLocation().IsValid())
			{
				monthlyNotifications.AddYirenAppearInTaiwuArea(taiwuChar.GetId());
			}
		}
		DomainManager.Taiwu.CheckAboutToDieVillagersAndTaiwuPeople(context);
		DomainManager.Taiwu.GenerateAllFollowingMonthNotifications();
	}

	private void TransferMonthlyNotifications(DataContext context)
	{
		UpdateMonthNotifyData(context);
	}

	public void InitializeSortedMonthlyNotificationSortingGroups(Dictionary<int, NotificationSortingGroup> groups)
	{
		_sortedMonthlyNotificationSortingGroups = new List<int>();
		foreach (int id in groups.Keys)
		{
			_sortedMonthlyNotificationSortingGroups.Add(id);
		}
		_sortedMonthlyNotificationSortingGroups.Sort(CompareGroups);
	}

	public void SortMonthlyNotificationSortingGroups(DataContext context)
	{
		_sortedMonthlyNotificationSortingGroups.Sort(CompareGroups);
		SetSortedMonthlyNotificationSortingGroups(_sortedMonthlyNotificationSortingGroups, context);
	}

	private int CompareGroups(int groupId1, int groupId2)
	{
		NotificationSortingGroup group1 = DomainManager.Extra.GetElement_MonthlyNotificationSortingGroups(groupId1);
		NotificationSortingGroup group2 = DomainManager.Extra.GetElement_MonthlyNotificationSortingGroups(groupId2);
		if (group1.IsOnTop && !group2.IsOnTop)
		{
			return -1;
		}
		if (!group1.IsOnTop && group2.IsOnTop)
		{
			return 1;
		}
		return (group1.Priority == group2.Priority) ? group1.Id.CompareTo(group2.Id) : group1.Priority.CompareTo(group2.Priority);
	}

	public void PrepareTestMonthlyNotificationRelatedData()
	{
		if (_monthlyNotificationTemplateIds.Count <= 0)
		{
			InitializeTestMonthlyNotificationRelatedData();
		}
		_candidatesCharacters.Clear();
		DomainManager.Character.FindIntelligentCharacters((GameData.Domains.Character.Character _) => true, _candidatesCharacters);
	}

	public void AddRandomMonthlyNotification(DataContext context, MonthlyNotificationCollection notifications)
	{
		int selectedIndex = context.Random.Next(_monthlyNotificationTemplateIds.Count);
		short templateId = _monthlyNotificationTemplateIds[selectedIndex];
		MonthlyNotificationItem config = MonthlyNotification.Instance[templateId];
		string name = _monthlyNotificationTemplateId2Name[config.TemplateId];
		MethodInfo methodInfo = _monthlyNotificationCollectionType.GetMethod("Add" + name);
		Tester.Assert(methodInfo != null);
		List<object> arguments = new List<object>();
		GameData.Domains.Character.Character character = null;
		int i = 0;
		for (int count = config.Parameters.Length; i < count; i++)
		{
			string paramName = config.Parameters[i];
			if (string.IsNullOrEmpty(paramName))
			{
				break;
			}
			sbyte paramType = ParameterType.Parse(paramName);
			AddNotificationArguments(context.Random, arguments, paramType, ref character);
		}
		methodInfo.Invoke(notifications, arguments.ToArray());
	}

	private void InitializeTestMonthlyNotificationRelatedData()
	{
		_monthlyNotificationTemplateIds.Clear();
		_monthlyNotificationTemplateId2Name.Clear();
		Type defKeysType = Type.GetType("Config.MonthlyNotification+DefKey");
		Tester.Assert(defKeysType != null);
		FieldInfo[] defKeysFieldInfos = defKeysType.GetFields(BindingFlags.Static | BindingFlags.Public);
		FieldInfo[] array = defKeysFieldInfos;
		foreach (FieldInfo info in array)
		{
			string name = info.Name;
			short templateId = (short)info.GetValue(null);
			_monthlyNotificationTemplateIds.Add(templateId);
			_monthlyNotificationTemplateId2Name.Add(templateId, name);
		}
		_monthlyNotificationCollectionType = Type.GetType("GameData.Domains.World.Notification.MonthlyNotificationCollection");
		_candidateItems.Clear();
		InitializeCandidateItems(_candidateItems);
		_candidateCombatSkills.Clear();
		foreach (CombatSkillItem item in (IEnumerable<CombatSkillItem>)Config.CombatSkill.Instance)
		{
			_candidateCombatSkills.Add(item.TemplateId);
		}
		_candidateSettlements.Clear();
		InitializeCandidateSettlements(_candidateSettlements);
		_candidateBuildings.Clear();
		foreach (BuildingBlockItem item2 in (IEnumerable<BuildingBlockItem>)BuildingBlock.Instance)
		{
			_candidateBuildings.Add(item2.TemplateId);
		}
		_candidateAdventures.Clear();
		foreach (Config.AdventureItem item3 in (IEnumerable<Config.AdventureItem>)Config.Adventure.Instance)
		{
			_candidateAdventures.Add(item3.TemplateId);
		}
		_candidateCrickets.Clear();
		InitializeCandidateCrickets(_candidateCrickets);
		_candidateChickens.Clear();
		foreach (ChickenItem item4 in (IEnumerable<ChickenItem>)Config.Chicken.Instance)
		{
			_candidateChickens.Add(item4.TemplateId);
		}
	}

	private static void InitializeCandidateItems(List<TemplateKey> items)
	{
		foreach (AccessoryItem item in (IEnumerable<AccessoryItem>)Config.Accessory.Instance)
		{
			items.Add(new TemplateKey(item.ItemType, item.TemplateId));
		}
		foreach (ArmorItem item2 in (IEnumerable<ArmorItem>)Config.Armor.Instance)
		{
			items.Add(new TemplateKey(item2.ItemType, item2.TemplateId));
		}
		foreach (CarrierItem item3 in (IEnumerable<CarrierItem>)Config.Carrier.Instance)
		{
			items.Add(new TemplateKey(item3.ItemType, item3.TemplateId));
		}
		foreach (ClothingItem item4 in (IEnumerable<ClothingItem>)Config.Clothing.Instance)
		{
			items.Add(new TemplateKey(item4.ItemType, item4.TemplateId));
		}
		foreach (CraftToolItem item5 in (IEnumerable<CraftToolItem>)Config.CraftTool.Instance)
		{
			items.Add(new TemplateKey(item5.ItemType, item5.TemplateId));
		}
		foreach (CricketItem item6 in (IEnumerable<CricketItem>)Config.Cricket.Instance)
		{
			items.Add(new TemplateKey(item6.ItemType, item6.TemplateId));
		}
		foreach (FoodItem item7 in (IEnumerable<FoodItem>)Config.Food.Instance)
		{
			items.Add(new TemplateKey(item7.ItemType, item7.TemplateId));
		}
		foreach (MaterialItem item8 in (IEnumerable<MaterialItem>)Config.Material.Instance)
		{
			items.Add(new TemplateKey(item8.ItemType, item8.TemplateId));
		}
		foreach (MedicineItem item9 in (IEnumerable<MedicineItem>)Config.Medicine.Instance)
		{
			items.Add(new TemplateKey(item9.ItemType, item9.TemplateId));
		}
		foreach (MiscItem item10 in (IEnumerable<MiscItem>)Config.Misc.Instance)
		{
			items.Add(new TemplateKey(item10.ItemType, item10.TemplateId));
		}
		foreach (SkillBookItem item11 in (IEnumerable<SkillBookItem>)Config.SkillBook.Instance)
		{
			items.Add(new TemplateKey(item11.ItemType, item11.TemplateId));
		}
		foreach (TeaWineItem item12 in (IEnumerable<TeaWineItem>)Config.TeaWine.Instance)
		{
			items.Add(new TemplateKey(item12.ItemType, item12.TemplateId));
		}
		foreach (WeaponItem item13 in (IEnumerable<WeaponItem>)Config.Weapon.Instance)
		{
			items.Add(new TemplateKey(item13.ItemType, item13.TemplateId));
		}
	}

	private static void InitializeCandidateSettlements(List<short> settlementIds)
	{
		Type classType = Type.GetType("GameData.Domains.Organization.OrganizationDomain");
		Tester.Assert(classType != null);
		FieldInfo fieldInfo = classType.GetField("_settlements", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		Tester.Assert(fieldInfo != null);
		Dictionary<short, Settlement> settlements = (Dictionary<short, Settlement>)fieldInfo.GetValue(DomainManager.Organization);
		Tester.Assert(settlements != null);
		foreach (var (settlementId, _) in settlements)
		{
			settlementIds.Add(settlementId);
		}
	}

	private static void InitializeCandidateCrickets(List<(short colorId, short partId)> crickets)
	{
		List<short> partIds = new List<short>();
		List<short> colorIds = new List<short>();
		foreach (CricketPartsItem item in (IEnumerable<CricketPartsItem>)CricketParts.Instance)
		{
			switch (item.Type)
			{
			case ECricketPartsType.Trash:
			case ECricketPartsType.King:
			case ECricketPartsType.RealColor:
				crickets.Add((item.TemplateId, 0));
				break;
			case ECricketPartsType.Parts:
				partIds.Add(item.TemplateId);
				break;
			default:
				colorIds.Add(item.TemplateId);
				break;
			}
		}
		foreach (short partId in partIds)
		{
			foreach (short colorId in colorIds)
			{
				crickets.Add((colorId, partId));
			}
		}
	}

	private void AddNotificationArguments(IRandomSource random, List<object> arguments, sbyte paramType, ref GameData.Domains.Character.Character character)
	{
		switch (paramType)
		{
		case 0:
		{
			GameData.Domains.Character.Character selectedCharacter = ((character != null) ? SelectRandomCharacter(random, character.GetId()) : (character = SelectRandomCharacter(random)));
			arguments.Add(selectedCharacter.GetId());
			break;
		}
		case 1:
		{
			Location location;
			if (character == null)
			{
				short areaId = (short)random.Next(141);
				location = new Location(areaId, -1);
			}
			else
			{
				location = character.GetLocation();
				if (!location.IsValid())
				{
					location = character.GetValidLocation();
				}
			}
			arguments.Add(location);
			break;
		}
		case 2:
		{
			int selectedIndex7 = random.Next(_candidateItems.Count);
			TemplateKey selectedItem = _candidateItems[selectedIndex7];
			arguments.Add(selectedItem.ItemType);
			arguments.Add(selectedItem.TemplateId);
			break;
		}
		case 3:
		{
			int selectedIndex6 = random.Next(_candidateCombatSkills.Count);
			short selectedCombatSkillId = _candidateCombatSkills[selectedIndex6];
			arguments.Add(selectedCombatSkillId);
			break;
		}
		case 4:
		{
			sbyte resourceType = (sbyte)random.Next(0, 8);
			arguments.Add(resourceType);
			break;
		}
		case 5:
		{
			int selectedIndex5 = random.Next(_candidateSettlements.Count);
			short selectedSettlementId = _candidateSettlements[selectedIndex5];
			arguments.Add(selectedSettlementId);
			break;
		}
		case 6:
		{
			Tester.Assert(character != null);
			OrganizationInfo orgInfo = character.GetOrganizationInfo();
			arguments.Add(orgInfo.OrgTemplateId);
			arguments.Add(orgInfo.Grade);
			arguments.Add(orgInfo.Principal);
			arguments.Add(character.GetGender());
			break;
		}
		case 7:
		{
			int selectedIndex4 = random.Next(_candidateBuildings.Count);
			short selectedBuildingTemplateId = _candidateBuildings[selectedIndex4];
			arguments.Add(selectedBuildingTemplateId);
			break;
		}
		case 8:
		{
			sbyte xiangshuAvatarId2 = (sbyte)random.Next(0, 9);
			arguments.Add(xiangshuAvatarId2);
			break;
		}
		case 9:
		{
			sbyte xiangshuAvatarId = (sbyte)random.Next(0, 9);
			arguments.Add(xiangshuAvatarId);
			break;
		}
		case 10:
		{
			int selectedIndex3 = random.Next(_candidateAdventures.Count);
			short adventureTemplateId = _candidateAdventures[selectedIndex3];
			arguments.Add(adventureTemplateId);
			break;
		}
		case 11:
		{
			sbyte behaviorType = (sbyte)random.Next(0, 5);
			arguments.Add(behaviorType);
			break;
		}
		case 12:
		{
			short favorability = (short)random.Next(-30000, 30001);
			sbyte favorabilityType = FavorabilityType.GetFavorabilityType(favorability);
			arguments.Add(favorabilityType);
			break;
		}
		case 13:
		{
			int selectedIndex2 = random.Next(_candidateCrickets.Count);
			var (colorId, partId) = _candidateCrickets[selectedIndex2];
			arguments.Add(colorId);
			arguments.Add(partId);
			break;
		}
		case 14:
		{
			short itemSubType = ItemSubType.GetRandom(random);
			if (!ItemSubType.IsHobbyType(itemSubType))
			{
				itemSubType = -1;
			}
			arguments.Add(itemSubType);
			break;
		}
		case 15:
		{
			int selectedIndex = random.Next(_candidateChickens.Count);
			short chickenTemplateId = _candidateChickens[selectedIndex];
			arguments.Add(chickenTemplateId);
			break;
		}
		case 16:
		{
			short characterPropertyReferencedType = (short)random.Next(0, 161);
			arguments.Add(characterPropertyReferencedType);
			break;
		}
		case 17:
		{
			sbyte bodyPartType = (sbyte)random.Next(0, 7);
			arguments.Add(bodyPartType);
			break;
		}
		case 18:
		{
			sbyte injuryType = (sbyte)random.Next(0, 2);
			arguments.Add(injuryType);
			break;
		}
		case 19:
		{
			sbyte poisonType = (sbyte)random.Next(0, 6);
			arguments.Add(poisonType);
			break;
		}
		case 22:
		{
			int value = random.Next(1000);
			arguments.Add(value);
			break;
		}
		default:
			throw new Exception($"Unsupported ParameterType: {paramType}");
		}
	}

	private GameData.Domains.Character.Character SelectRandomCharacter(IRandomSource random, int exceptedCharId = -1)
	{
		for (int i = 0; i < 100; i++)
		{
			int selectedIndex = random.Next(_candidatesCharacters.Count);
			GameData.Domains.Character.Character selectedCharacter = _candidatesCharacters[selectedIndex];
			if (exceptedCharId < 0 || selectedCharacter.GetId() != exceptedCharId)
			{
				return selectedCharacter;
			}
		}
		throw new Exception("Exceeded max retry count");
	}

	[DomainMethod]
	public bool GmCmd_AddMonthlyEvent(short startTemplateId, short endTemplateId, int selfCharId, int targetCharId)
	{
		bool success = false;
		if (endTemplateId == -1)
		{
			endTemplateId = startTemplateId;
		}
		for (short templateId = startTemplateId; templateId <= endTemplateId; templateId++)
		{
			if (_canTestMonthlyEventTemplateIdList.Contains(startTemplateId))
			{
				(short, int, int) tuple = (templateId, selfCharId, targetCharId);
				if (!_testMonthlyEventList.Contains(tuple))
				{
					_testMonthlyEventList.Add(tuple);
				}
				CharacterDomain.AddLockMovementCharSet(selfCharId);
				success = true;
			}
		}
		return success;
	}

	public void AddTestMonthlyEvent(DataContext context)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int taiwuCharId = taiwuChar.GetId();
		Location location = taiwuChar.GetValidLocation();
		short itemTemplateId = -1;
		short itemTemplateId2 = -1;
		byte pageTypes = CombatSkillStateHelper.GeneratePageTypesFromReadingState(context.Random, 0);
		byte internalIndex = 0;
		PoisonItem poisonConfig;
		foreach (var testMonthlyEvent in _testMonthlyEventList)
		{
			short eventTemplateId = testMonthlyEvent.monthlyEventTemplateId;
			int selfCharId = testMonthlyEvent.selfCharId;
			int targetCharId = testMonthlyEvent.targetCharId;
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(selfCharId);
			switch (eventTemplateId)
			{
			case 87:
				monthlyEventCollection.AddRequestPlayCombat(selfCharId, location, taiwuCharId);
				break;
			case 88:
				monthlyEventCollection.AddRequestNormalCombat(selfCharId, location, taiwuCharId);
				break;
			case 89:
				monthlyEventCollection.AddRequestLifeSkillBattle(selfCharId, location, taiwuCharId);
				break;
			case 90:
				monthlyEventCollection.AddRequestCricketBattle(selfCharId, location, taiwuCharId);
				break;
			case 66:
			{
				itemTemplateId = Config.Medicine.Instance.First((MedicineItem m) => m.EffectType == EMedicineEffectType.RecoverOuterInjury).TemplateId;
				ItemKey itemKey = AddItem(context, itemTemplateId, 8, taiwuCharId);
				character.ChangeInjury(context, 0, isInnerInjury: false, 1);
				monthlyEventCollection.AddRequestHealOuterInjuryByItem(selfCharId, location, taiwuCharId, (ulong)itemKey, 0);
				break;
			}
			case 68:
			{
				itemTemplateId = Config.Medicine.Instance.First((MedicineItem m) => m.EffectType == EMedicineEffectType.RecoverInnerInjury).TemplateId;
				ItemKey itemKey = AddItem(context, itemTemplateId, 8, taiwuCharId);
				character.ChangeInjury(context, 0, isInnerInjury: true, 1);
				monthlyEventCollection.AddRequestHealInnerInjuryByItem(selfCharId, location, taiwuCharId, (ulong)itemKey, 0);
				break;
			}
			case 70:
			{
				poisonConfig = Poison.Instance.FirstOrDefault((PoisonItem p) => !taiwuChar.HasPoisonImmunity(p.TemplateId));
				itemTemplateId = Config.Medicine.Instance.First((MedicineItem m) => m.EffectType == EMedicineEffectType.DetoxPoison && m.DetoxPoisonType == poisonConfig.TemplateId).TemplateId;
				ItemKey itemKey = AddItem(context, itemTemplateId, 8, taiwuCharId);
				character.ChangePoisoned(context, poisonConfig.TemplateId, 0, 100);
				monthlyEventCollection.AddRequestHealPoisonByItem(selfCharId, location, taiwuCharId, (ulong)itemKey, 0);
				break;
			}
			case 72:
			{
				itemTemplateId = Config.Medicine.Instance.First((MedicineItem m) => m.EffectType == EMedicineEffectType.RecoverHealth).TemplateId;
				ItemKey itemKey = AddItem(context, itemTemplateId, 8, taiwuCharId);
				character.ChangeHealth(context, -10);
				monthlyEventCollection.AddRequestHealth(selfCharId, location, taiwuCharId, (ulong)itemKey);
				break;
			}
			case 73:
			{
				itemTemplateId = Config.Medicine.Instance.First((MedicineItem m) => m.EffectType == EMedicineEffectType.ChangeDisorderOfQi).TemplateId;
				ItemKey itemKey = AddItem(context, itemTemplateId, 8, taiwuCharId);
				character.ChangeDisorderOfQi(context, 1000);
				monthlyEventCollection.AddRequestHealDisorderOfQi(selfCharId, location, taiwuCharId, (ulong)itemKey);
				break;
			}
			case 74:
			{
				itemTemplateId = Config.Misc.Instance.First((MiscItem m) => m.Neili > 0).TemplateId;
				ItemKey itemKey = AddItem(context, itemTemplateId, 12, taiwuCharId);
				character.ChangeCurrNeili(context, -Math.Min(character.GetMaxNeili(), 100));
				monthlyEventCollection.AddRequestNeili(selfCharId, location, taiwuCharId, (ulong)itemKey);
				break;
			}
			case 75:
			{
				itemTemplateId = Config.Medicine.Instance.First((MedicineItem m) => m.WugType == 0).TemplateId;
				ItemKey itemKey = AddItem(context, itemTemplateId, 8, taiwuCharId);
				ItemKey wugItemKey = AddWug(context, selfCharId);
				monthlyEventCollection.AddRequestKillWug(selfCharId, location, taiwuCharId, (ulong)itemKey, (ulong)wugItemKey);
				break;
			}
			case 76:
			{
				itemTemplateId = Config.Food.Instance.First().TemplateId;
				ItemKey itemKey = AddItem(context, itemTemplateId, 7, taiwuCharId);
				monthlyEventCollection.AddRequestFood(selfCharId, location, taiwuCharId, (ulong)itemKey, 1);
				break;
			}
			case 77:
			{
				itemTemplateId = Config.TeaWine.Instance[1].TemplateId;
				ItemKey itemKey = AddItem(context, itemTemplateId, 9, taiwuCharId);
				monthlyEventCollection.AddRequestTeaWine(selfCharId, location, taiwuCharId, (ulong)itemKey);
				break;
			}
			case 78:
				monthlyEventCollection.AddRequestResource(selfCharId, location, taiwuCharId, 1, 0);
				break;
			case 79:
			{
				itemTemplateId = 264;
				ItemKey itemKey = AddItem(context, itemTemplateId, 12, taiwuCharId);
				monthlyEventCollection.AddRequestItem(selfCharId, location, taiwuCharId, (ulong)itemKey, 1);
				break;
			}
			case 80:
			{
				itemTemplateId = Config.Weapon.Instance.First((WeaponItem w) => w.Grade == 2 && w.ResourceType == 1).TemplateId;
				ItemKey itemKey = AddItem(context, itemTemplateId, 0, selfCharId);
				itemTemplateId2 = Config.CraftTool.Instance.First((CraftToolItem w) => w.Grade == 2 && w.RequiredLifeSkillTypes.Contains(7)).TemplateId;
				ItemKey itemKey2 = AddItem(context, itemTemplateId2, 6, taiwuCharId);
				monthlyEventCollection.AddRequestRepairItem(selfCharId, location, taiwuCharId, (ulong)itemKey, (ulong)itemKey2, 1, 1);
				break;
			}
			case 81:
			{
				itemTemplateId = Config.Weapon.Instance.First((WeaponItem w) => w.Grade == 2 && w.ResourceType == 2).TemplateId;
				ItemKey itemKey = AddItem(context, itemTemplateId, 0, selfCharId, equip: true);
				itemTemplateId2 = Config.Medicine.Instance.First((MedicineItem m) => m.EffectType == EMedicineEffectType.ApplyPoison).TemplateId;
				ItemKey itemKey2 = AddItem(context, itemTemplateId2, 8, taiwuCharId);
				monthlyEventCollection.AddRequestAddPoisonToItem(selfCharId, location, taiwuCharId, (ulong)itemKey, (ulong)itemKey2);
				break;
			}
			case 82:
			{
				SkillBookItem skillBookConfig = Config.SkillBook.Instance.FirstOrDefault((SkillBookItem s) => s.LifeSkillType > 0 && character.FindLearnedLifeSkillIndex(s.LifeSkillTemplateId) < 0);
				if (skillBookConfig == null)
				{
					Logger.Warn($"未找到{character}未学过的技艺书籍");
				}
				else
				{
					ItemKey itemKey = AddItem(context, skillBookConfig.TemplateId, 10, selfCharId);
					monthlyEventCollection.AddRequestInstructionOnLifeSkill(selfCharId, location, taiwuCharId, itemKey.ItemType, itemKey.TemplateId, 1);
				}
				break;
			}
			case 83:
			{
				SkillBookItem skillBookConfig = Config.SkillBook.Instance.FirstOrDefault((SkillBookItem s) => s.CombatSkillType >= 0 && !character.GetLearnedCombatSkills().Contains(s.CombatSkillTemplateId));
				if (skillBookConfig == null)
				{
					Logger.Warn($"未找到{character}未学过的功法书籍");
				}
				else
				{
					ItemKey itemKey = AddItem(context, skillBookConfig.TemplateId, 10, selfCharId);
					monthlyEventCollection.AddRequestInstructionOnCombatSkill(selfCharId, location, taiwuCharId, itemKey.ItemType, itemKey.TemplateId, CombatSkillStateHelper.GetPageId(internalIndex) + 1, internalIndex, pageTypes);
				}
				break;
			}
			case 84:
			{
				SkillBookItem skillBookConfig = Config.SkillBook.Instance.FirstOrDefault((SkillBookItem s) => s.LifeSkillType >= 0 && character.FindLearnedLifeSkillIndex(s.LifeSkillTemplateId) < 0);
				if (skillBookConfig == null)
				{
					Logger.Warn($"未找到{character}未学过的技艺书籍");
				}
				else
				{
					ItemKey itemKey = AddItem(context, skillBookConfig.TemplateId, 10, selfCharId);
					monthlyEventCollection.AddRequestInstructionOnReadingLifeSkill(selfCharId, location, taiwuCharId, (ulong)itemKey, 1);
				}
				break;
			}
			case 85:
			{
				SkillBookItem skillBookConfig = Config.SkillBook.Instance.FirstOrDefault((SkillBookItem s) => s.CombatSkillType >= 0 && !character.GetLearnedCombatSkills().Contains(s.CombatSkillTemplateId));
				if (skillBookConfig == null)
				{
					Logger.Warn($"未找到{character}未学过的功法书籍");
				}
				else
				{
					ItemKey itemKey = AddItem(context, skillBookConfig.TemplateId, 10, selfCharId);
					monthlyEventCollection.AddRequestInstructionOnReadingCombatSkill(selfCharId, location, taiwuCharId, (ulong)itemKey, CombatSkillStateHelper.GetPageId(internalIndex) + 1, internalIndex);
				}
				break;
			}
			case 86:
			{
				SkillBookItem skillBookConfig = Config.SkillBook.Instance.FirstOrDefault((SkillBookItem s) => s.CombatSkillType >= 0 && !character.GetLearnedCombatSkills().Contains(s.CombatSkillTemplateId));
				if (skillBookConfig == null)
				{
					Logger.Warn($"未找到{character}未学过的功法书籍");
				}
				else
				{
					character.LearnNewCombatSkill(context, skillBookConfig.CombatSkillTemplateId, 32767);
					monthlyEventCollection.AddRequestInstructionOnBreakout(selfCharId, location, taiwuCharId, skillBookConfig.CombatSkillTemplateId);
				}
				break;
			}
			case 114:
				taiwuChar.ChangeInjury(context, 0, isInnerInjury: true, 1);
				monthlyEventCollection.AddAdviseHealInjury(selfCharId, location, taiwuCharId, 1);
				break;
			case 115:
				poisonConfig = Poison.Instance.FirstOrDefault((PoisonItem p) => !taiwuChar.HasPoisonImmunity(p.TemplateId));
				taiwuChar.ChangePoisoned(context, poisonConfig.TemplateId, 0, 100);
				monthlyEventCollection.AddAdviseHealPoison(selfCharId, location, taiwuCharId, 1);
				break;
			case 116:
			{
				itemTemplateId = Config.Weapon.Instance.First((WeaponItem w) => w.Grade == 2 && w.ResourceType == 1).TemplateId;
				ItemKey itemKey = AddItem(context, itemTemplateId, 0, taiwuCharId);
				itemTemplateId2 = Config.CraftTool.Instance.First((CraftToolItem w) => w.Grade == 2 && w.RequiredLifeSkillTypes.Contains(7)).TemplateId;
				ItemKey itemKey2 = AddItem(context, itemTemplateId2, 6, selfCharId);
				monthlyEventCollection.AddAdviseRepairItem(selfCharId, location, taiwuCharId, (ulong)itemKey, (ulong)itemKey2, 1, 1);
				break;
			}
			case 117:
				monthlyEventCollection.AddAdviseBarb(selfCharId, location, taiwuCharId);
				break;
			case 118:
				monthlyEventCollection.AddAskForMoney(selfCharId, location, taiwuCharId);
				break;
			case 343:
				taiwuChar.ChangeDisorderOfQi(context, 1000);
				monthlyEventCollection.AddAdviseHealDisorderOfQi(selfCharId, location, taiwuCharId, 1);
				break;
			case 344:
				taiwuChar.ChangeHealth(context, -10);
				monthlyEventCollection.AddAdviseHealHealth(selfCharId, location, taiwuCharId, 1);
				break;
			case 280:
			{
				Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(selfCharId);
				short templateId = -1;
				templateId = combatSkills.Keys.FirstOrDefault((short combatSkillTemplateId) => !taiwuChar.GetLearnedCombatSkills().Contains(combatSkillTemplateId));
				if (templateId < 0 || combatSkills.Keys.Count == 0)
				{
					Logger.Warn("未找到可以指点的功法书籍");
				}
				else
				{
					monthlyEventCollection.AddTeachCombatSkill(selfCharId, location, taiwuCharId, templateId);
				}
				break;
			}
			case 61:
				monthlyEventCollection.AddAskProtectByRevengeAttack(selfCharId, location, targetCharId, taiwuCharId);
				break;
			default:
			{
				MonthlyEventItem eventConfig = Config.MonthlyEvent.Instance.GetItem(eventTemplateId);
				if (eventConfig == null)
				{
					Logger.Warn($"未找到ID为{eventTemplateId}的过月事件");
				}
				else
				{
					Logger.Warn("未添加过月事件 " + eventConfig.Name + " 的测试代码");
				}
				break;
			}
			}
		}
		_testMonthlyEventList.Clear();
	}

	private ItemKey AddItem(DataContext context, short itemTemplateId, sbyte itemType, int charId, bool equip = false)
	{
		ItemKey itemKey = DomainManager.Item.CreateItem(context, itemType, itemTemplateId);
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		character.AddInventoryItem(context, itemKey, 1);
		if (ItemType.IsEquipmentItemType(itemType))
		{
			ItemBase itemBase = DomainManager.Item.GetBaseItem(itemKey);
			itemBase.SetCurrDurability(Convert.ToInt16((float)itemBase.GetMaxDurability() * 0.5f), context);
			if (equip)
			{
				ItemKey[] equipment = character.GetEquipment();
				if (equipment[0].IsValid())
				{
					character.ChangeEquipment(context, 0, -1, equipment[0]);
				}
				character.ChangeEquipment(context, -1, 0, itemKey);
			}
		}
		return itemKey;
	}

	private ItemKey AddWug(DataContext context, int charId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		short medicineTemplateId = 347;
		ItemKey wugItemKey = new ItemKey(8, 0, medicineTemplateId, -1);
		character.AddWug(context, wugItemKey, -1);
		return wugItemKey;
	}

	public float GetProbAdjustOfCreatingCharacter()
	{
		return _probAdjustOfCreatingCharacter;
	}

	public void RecordWorldStandardPopulation(DataContext context)
	{
		int worldPopulation = DomainManager.Character.GetWorldPopulation();
		SetWorldStandardPopulation(worldPopulation, context);
	}

	public void ChangeWorldPopulation(DataContext context, byte oriWorldPopulationType)
	{
		int basicPopulation = _worldStandardPopulation * 100 / GetWorldPopulationFactor(oriWorldPopulationType);
		int currFactor = GetWorldPopulationFactor();
		int currStandardPopulation = basicPopulation * currFactor / 100;
		SetWorldStandardPopulation(currStandardPopulation, context);
	}

	public void UpdatePopulationRelatedData()
	{
		int standardPopulation = GetWorldStandardPopulation();
		int currPopulation = DomainManager.Character.GetWorldPopulation();
		_probAdjustOfCreatingCharacter = 1f;
		Logger.Info($"Currrent Population / World Standard Population: {currPopulation}/{standardPopulation}, Probability Adjustment of Creating Character: {(int)Math.Round(_probAdjustOfCreatingCharacter * 100f)}%");
	}

	[DomainMethod]
	public void SpecifyWorldPopulationType(DataContext context, byte worldPopulationType)
	{
		byte oriType = _worldPopulationType;
		SetWorldPopulationType(worldPopulationType, context);
		ChangeWorldPopulation(context, oriType);
		DomainManager.Organization.ChangeSettlementStandardPopulations(context, oriType);
	}

	public int GetWorldCreationSetting(byte worldCreationType)
	{
		if (1 == 0)
		{
		}
		int num = worldCreationType switch
		{
			1 => GetCombatDifficulty(), 
			11 => GetEnemyPracticeLevel(), 
			12 => GetFavorabilityChange(), 
			2 => GetReadingDifficulty(), 
			3 => GetBreakoutDifficulty(), 
			4 => GetLoopingDifficulty(), 
			5 => GetHereticsAmountType(), 
			6 => GetBossInvasionSpeedType(), 
			7 => GetWorldResourceAmountType(), 
			13 => GetProfessionUpgrade(), 
			14 => GetLootYield(), 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		int setting = num;
		if (setting < 0)
		{
			PredefinedLog.Show(19, $"GetSettingWorldCreationType by {worldCreationType}");
		}
		return setting;
	}

	public int GetWorldPopulationFactor()
	{
		return WorldCreation.Instance[(byte)8].InfluenceFactors[_worldPopulationType];
	}

	public static int GetWorldPopulationFactor(byte worldPopulationType)
	{
		return WorldCreation.Instance[(byte)8].InfluenceFactors[worldPopulationType];
	}

	public int GetCharacterLifeSpanFactor()
	{
		return WorldCreation.Instance[(byte)0].InfluenceFactors[_characterLifespanType];
	}

	public int GetHereticsAmountFactor()
	{
		return WorldCreation.Instance[(byte)5].InfluenceFactors[_hereticsAmountType];
	}

	public int GetBossInvasionSpeed()
	{
		return WorldCreation.Instance[(byte)6].InfluenceFactors[_bossInvasionSpeedType];
	}

	public int GetGainResourcePercent(byte type)
	{
		return WorldResource.Instance[type].InfluenceFactors[_worldResourceAmountType];
	}

	public (int Value, bool Reciprocal) GetFavorabilityChangePercent(short type, bool isFavorabilityGainFixed)
	{
		if (type < 0)
		{
			return (Value: 100, Reciprocal: false);
		}
		byte favorabilityChange = DomainManager.World.GetFavorabilityChange();
		if (isFavorabilityGainFixed)
		{
			type = 6;
		}
		WorldFavorabilityItem worldFavorability = WorldFavorability.Instance[type];
		return (Value: worldFavorability.InfluenceFactors[favorabilityChange], Reciprocal: worldFavorability.NegativeUsingReciprocal);
	}

	public bool IsTaskInProgress(int taskInfoId)
	{
		return GetCurrTaskList().Exists((TaskData task) => task.TaskInfoId == taskInfoId && task.TaskStatus != 2);
	}

	public bool IsTaskChainInProgress(int taskChainId)
	{
		return GetCurrTaskList().Exists((TaskData task) => task.TaskChainId == taskChainId && task.TaskStatus != 2);
	}

	public bool IsTaskFinished(int taskInfoId)
	{
		return GetCurrTaskList().Exists((TaskData task) => task.TaskInfoId == taskInfoId && task.TaskStatus == 2);
	}

	[DomainMethod]
	public void SetTopTask(DataContext context, int topTaskInfoId, int targetIndex = 0)
	{
		if (targetIndex >= 0)
		{
			List<TaskData> currTaskList = GetCurrTaskList();
			TaskData targetTask = currTaskList.Find((TaskData t) => t.TaskInfoId == topTaskInfoId);
			if (targetTask.TaskChainId >= 0)
			{
				TaskChainItem taskChainCfg = TaskChain.Instance[targetTask.TaskChainId];
				ETaskChainGroup targetGroup = taskChainCfg.Group;
				List<int> tasksToRemove = ObjectPool<List<int>>.Instance.Get();
				tasksToRemove.Clear();
				foreach (int pinnedTaskId in _pinnedOnTopTasks)
				{
					TaskData pinnedTask = currTaskList.Find((TaskData t) => t.TaskInfoId == pinnedTaskId);
					if (pinnedTask.TaskChainId >= 0)
					{
						TaskChainItem pinnedTaskChainCfg = TaskChain.Instance[pinnedTask.TaskChainId];
						if (pinnedTaskChainCfg.Group == targetGroup)
						{
							tasksToRemove.Add(pinnedTaskId);
						}
					}
				}
				foreach (int taskId in tasksToRemove)
				{
					_pinnedOnTopTasks.Remove(taskId);
				}
				ObjectPool<List<int>>.Instance.Return(tasksToRemove);
			}
		}
		bool isInTopRated = _pinnedOnTopTasks.Contains(topTaskInfoId);
		if (targetIndex >= 0)
		{
			if (!isInTopRated)
			{
				_pinnedOnTopTasks.Insert(targetIndex, topTaskInfoId);
			}
		}
		else if (isInTopRated)
		{
			_pinnedOnTopTasks.Remove(topTaskInfoId);
		}
		SetPinnedOnTopTasks(_pinnedOnTopTasks, context);
		int currentIndex = _taskSortingOrder.IndexOf(topTaskInfoId);
		if (currentIndex >= 0)
		{
			_taskSortingOrder.RemoveAt(currentIndex);
		}
		List<int> sortedTaskOrder = new List<int>();
		foreach (int taskId2 in _pinnedOnTopTasks)
		{
			sortedTaskOrder.Add(taskId2);
		}
		foreach (int taskId3 in _taskSortingOrder)
		{
			if (!_pinnedOnTopTasks.Contains(taskId3) && taskId3 != topTaskInfoId)
			{
				sortedTaskOrder.Add(taskId3);
			}
		}
		if (!sortedTaskOrder.Contains(topTaskInfoId))
		{
			if (_pinnedOnTopTasks.Count >= sortedTaskOrder.Count)
			{
				sortedTaskOrder.Add(topTaskInfoId);
			}
			else
			{
				sortedTaskOrder.Insert(_pinnedOnTopTasks.Count, topTaskInfoId);
			}
		}
		_taskSortingOrder = sortedTaskOrder;
		SetTaskSortingOrder(_taskSortingOrder, context);
	}

	private void RegisterTaskSortingOrderUpdate()
	{
		DataUid uid = new DataUid(1, 29, ulong.MaxValue);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(uid, "RemoveInvalidTaskSortingOrder", RemoveInvalidTaskSortingOrder);
	}

	private void RemoveInvalidTaskSortingOrder(DataContext context, DataUid uid)
	{
		List<TaskData> taskList = DomainManager.World.GetCurrTaskList();
		if (taskList.Count < _taskSortingOrder.Count)
		{
			_taskSortingOrder.RemoveAll(IsTaskInfoIdNotInTaskList);
		}
		bool IsTaskInfoIdNotInTaskList(int taskInfoId)
		{
			for (int i = 0; i < taskList.Count; i++)
			{
				if (taskList[i].TaskInfoId == taskInfoId)
				{
					return taskList[i].IsBlocked;
				}
			}
			return true;
		}
	}

	public void TriggerExtraTask(DataContext context, int taskChainId, int taskInfoId)
	{
		TaskInfoItem taskCfg = TaskInfo.Instance[taskInfoId];
		if (!taskCfg.IsTriggeredTask)
		{
			throw new Exception("Task " + taskCfg.TaskTitle + " is not triggered task.");
		}
		TaskChainItem taskChainCfg = TaskChain.Instance[taskChainId];
		if (!taskChainCfg.TaskList.Contains(taskInfoId))
		{
			throw new Exception("Task " + taskCfg.TaskTitle + " is not in task chain " + taskChainCfg.Name);
		}
		if (taskChainCfg.RelateAdventure)
		{
			TriggerExtraTaskViaAdventure(context, taskChainId, taskInfoId);
			return;
		}
		if (taskChainCfg.Type == ETaskChainType.Line)
		{
			int currentDate = DomainManager.World.GetCurrDate();
			for (int i = 0; i < _extraTriggeredTasks.Count; i++)
			{
				if (_extraTriggeredTasks[i].TaskStatus != 2)
				{
					TaskData task = _extraTriggeredTasks[i];
					if (taskChainId == task.TaskChainId)
					{
						task.TaskStatus = 2;
						_extraTriggeredTasks[i] = task;
						_taskFinishedDateList.Add((task.TaskInfoId, currentDate));
						Events.RaiseTaskFinished(context, task);
					}
				}
			}
		}
		int index = _extraTriggeredTasks.FindIndex((TaskData taskData) => taskData.TaskInfoId == taskInfoId && taskData.TaskChainId == taskChainId);
		if (index < 0)
		{
			_extraTriggeredTasks.Add(new TaskData
			{
				TaskChainId = taskChainId,
				TaskInfoId = taskInfoId,
				TaskStatus = 0
			});
		}
		else
		{
			TaskData task2 = _extraTriggeredTasks[index];
			task2.TaskStatus = 0;
			_extraTriggeredTasks[index] = task2;
		}
		for (int i2 = _taskFinishedDateList.Count - 1; i2 >= 0; i2--)
		{
			if (_taskFinishedDateList[i2].Item1 == taskInfoId)
			{
				_taskFinishedDateList.RemoveAt(i2);
				break;
			}
		}
		SetExtraTriggeredTasks(_extraTriggeredTasks, context);
		if (taskChainCfg.Type != ETaskChainType.Parallel || taskChainCfg.TaskList[0] == taskInfoId)
		{
			SetTopTask(context, taskInfoId);
		}
	}

	public void FinishTriggeredExtraTask(DataContext context, int taskChainId, int taskInfoId)
	{
		TaskInfoItem taskCfg = TaskInfo.Instance[taskInfoId];
		TaskChainItem taskChainCfg = TaskChain.Instance[taskChainId];
		if (!taskCfg.IsTriggeredTask)
		{
			throw new Exception("Task " + taskCfg.TaskTitle + " is not triggered task.");
		}
		if (!taskChainCfg.TaskList.Contains(taskInfoId))
		{
			throw new Exception("Task " + taskCfg.TaskTitle + " is not in task chain " + taskChainCfg.Name);
		}
		if (taskChainCfg.RelateAdventure)
		{
			FinishTriggeredExtraTaskViaAdventure(context, taskChainId, taskInfoId);
			return;
		}
		for (int i = 0; i < _extraTriggeredTasks.Count; i++)
		{
			TaskData task = _extraTriggeredTasks[i];
			if (task.TaskChainId == taskChainId && task.TaskInfoId == taskInfoId && task.TaskStatus != 2)
			{
				task.TaskStatus = 2;
				int currentDate = DomainManager.World.GetCurrDate();
				_taskFinishedDateList.Add((taskInfoId, currentDate));
				_extraTriggeredTasks[i] = task;
				Events.RaiseTaskFinished(context, task);
			}
		}
		SetExtraTriggeredTasks(_extraTriggeredTasks, context);
	}

	public void FinishAllTaskInChain(DataContext context, int taskChainId)
	{
		TaskChainItem taskChainCfg = TaskChain.Instance[taskChainId];
		if (taskChainCfg.RelateAdventure)
		{
			FinishAllTaskInChainViaAdventure(context, taskChainId);
			return;
		}
		for (int index = _extraTriggeredTasks.Count - 1; index >= 0; index--)
		{
			TaskData taskData = _extraTriggeredTasks[index];
			if (taskData.TaskChainId == taskChainId)
			{
				TaskData task = _extraTriggeredTasks[index];
				if (task.TaskStatus != 2)
				{
					task.TaskStatus = 2;
					int currentDate = DomainManager.World.GetCurrDate();
					_taskFinishedDateList.Add((taskData.TaskInfoId, currentDate));
					_extraTriggeredTasks[index] = task;
					Events.RaiseTaskFinished(context, taskData);
				}
			}
		}
		SetExtraTriggeredTasks(_extraTriggeredTasks, context);
	}

	public bool IsExtraTaskInProgress(int taskInfoId)
	{
		return _extraTriggeredTasks.Exists((TaskData task) => task.TaskInfoId == taskInfoId && task.TaskStatus != 2);
	}

	public bool IsExtraTaskChainInProgress(int taskChainId)
	{
		return _extraTriggeredTasks.Exists((TaskData task) => task.TaskChainId == taskChainId && task.TaskStatus != 2);
	}

	public bool IsExtraTaskFinished(int taskInfoId)
	{
		byte taskStatus;
		return TryGetExtraTriggeredTaskStatus(taskInfoId, out taskStatus) && taskStatus == 2;
	}

	public int GetExtraTaskChainCurrentTask(int taskChainId)
	{
		for (int index = 0; index < _extraTriggeredTasks.Count; index++)
		{
			TaskData task = _extraTriggeredTasks[index];
			if (task.TaskChainId == taskChainId && task.TaskStatus != 2)
			{
				return task.TaskInfoId;
			}
		}
		return -1;
	}

	private bool TryGetExtraTriggeredTaskStatus(int taskInfoId, out byte taskStatus)
	{
		for (int i = _extraTriggeredTasks.Count - 1; i >= 0; i--)
		{
			TaskData task = _extraTriggeredTasks[i];
			if (task.TaskInfoId == taskInfoId)
			{
				taskStatus = task.TaskStatus;
				return true;
			}
		}
		taskStatus = 0;
		return false;
	}

	public void SetExtraTriggeredTasks(DataContext context, List<TaskData> value)
	{
		SetExtraTriggeredTasks(value, context);
	}

	public void SetTaskSortingOrder(DataContext context, List<int> value)
	{
		SetTaskSortingOrder(value, context);
	}

	public void SetPinnedOnTopTasks(DataContext context, List<int> value)
	{
		SetPinnedOnTopTasks(value, context);
	}

	public void SetTaskFinishedDateList(DataContext context, List<(int, int)> value)
	{
		SetTaskFinishedDateList(value, context);
	}

	private static void TriggerExtraTaskViaAdventure(DataContext context, int taskChainId, int taskInfoId)
	{
		AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
		if (adventureTaiwu.NotInAdventure)
		{
			return;
		}
		AdventureRuntime adventure = adventureTaiwu.Adventure;
		bool anyChanged = false;
		TaskChainItem taskChainCfg = TaskChain.Instance[taskChainId];
		if (taskChainCfg.Type == ETaskChainType.Line)
		{
			int count = adventure.GetParameter("ConchShipPresetKey_Task_Count").Current;
			for (int i = count - 1; i >= 0; i--)
			{
				string key = AdventureConstants.TaskKey(i);
				if (adventure.GetParameter(key).AsTask.TaskChainId == taskChainId)
				{
					anyChanged = AdventureTaskRemoveAt(adventure, i) || anyChanged;
				}
			}
		}
		int index = AdventureTaskFindIndex(adventure, taskChainId, taskInfoId);
		if (index < 0)
		{
			int count2 = AdventureGetTaskCount(adventure);
			adventure.SetParameter(AdventureConstants.TaskKey(count2), new TaskData
			{
				TaskChainId = taskChainId,
				TaskInfoId = taskInfoId,
				TaskStatus = 0
			});
			adventure.SetParameter("ConchShipPresetKey_Task_Count", count2 + 1);
			anyChanged = true;
		}
		else
		{
			string key2 = AdventureConstants.TaskKey(index);
			TaskData task = adventure.GetParameter(key2).AsTask;
			anyChanged = anyChanged || task.TaskStatus != 0;
			task.TaskStatus = 0;
			adventure.SetParameter(key2, task);
		}
		if (anyChanged)
		{
			DomainManager.Adventure.SetAny(context, adventure);
		}
		if (taskChainCfg.Type != ETaskChainType.Parallel || taskChainCfg.TaskList[0] == taskInfoId)
		{
			DomainManager.World.SetTopTask(context, taskInfoId);
		}
	}

	private static void FinishTriggeredExtraTaskViaAdventure(DataContext context, int taskChainId, int taskInfoId)
	{
		AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
		if (adventureTaiwu.NotInAdventure)
		{
			return;
		}
		AdventureRuntime adventure = adventureTaiwu.Adventure;
		int count = adventure.GetParameter("ConchShipPresetKey_Task_Count").Current;
		bool anyChanged = false;
		for (int i = count - 1; i >= 0; i--)
		{
			string key = AdventureConstants.TaskKey(i);
			TaskData task = adventure.GetParameter(key).AsTask;
			if (task.TaskChainId == taskChainId && task.TaskInfoId == taskInfoId)
			{
				anyChanged = AdventureTaskRemoveAt(adventure, i) || anyChanged;
			}
		}
		if (anyChanged)
		{
			DomainManager.Adventure.SetAny(context, adventure);
		}
	}

	private static void FinishAllTaskInChainViaAdventure(DataContext context, int taskChainId)
	{
		AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
		if (adventureTaiwu.NotInAdventure)
		{
			return;
		}
		AdventureRuntime adventure = adventureTaiwu.Adventure;
		int count = adventure.GetParameter("ConchShipPresetKey_Task_Count").Current;
		bool anyChanged = false;
		for (int i = count - 1; i >= 0; i--)
		{
			string key = AdventureConstants.TaskKey(i);
			if (adventure.GetParameter(key).AsTask.TaskChainId == taskChainId)
			{
				anyChanged = AdventureTaskRemoveAt(adventure, i) || anyChanged;
			}
		}
		if (anyChanged)
		{
			DomainManager.Adventure.SetAny(context, adventure);
		}
	}

	private static int AdventureGetTaskCount(AdventureRuntime adventure)
	{
		return adventure.GetParameter("ConchShipPresetKey_Task_Count").Current;
	}

	private static int AdventureTaskFindIndex(AdventureRuntime adventure, int taskChainId, int taskInfoId)
	{
		int count = AdventureGetTaskCount(adventure);
		for (int i = 0; i < count; i++)
		{
			string key = AdventureConstants.TaskKey(i);
			TaskData task = adventure.GetParameter(key).AsTask;
			if (task.TaskChainId == taskChainId && task.TaskInfoId == taskInfoId)
			{
				return i;
			}
		}
		return -1;
	}

	private static bool AdventureTaskRemoveAt(AdventureRuntime adventure, int index)
	{
		int count = AdventureGetTaskCount(adventure);
		if (index < 0 || index >= count)
		{
			return false;
		}
		int newCount = count - 1;
		for (int i = index; i < newCount; i++)
		{
			adventure.SetParameter(AdventureConstants.TaskKey(i), adventure.GetParameter(AdventureConstants.TaskKey(i + 1)));
		}
		adventure.RemoveParameter(AdventureConstants.TaskKey(newCount));
		adventure.SetParameter("ConchShipPresetKey_Task_Count", newCount);
		return true;
	}

	public short GetCurrYear()
	{
		return (short)(_currDate / 12);
	}

	public sbyte GetCurrMonthInYear()
	{
		return (sbyte)(_currDate % 12);
	}

	public bool CheckDateInterval(int beginDate, int expectedInterval)
	{
		int monthCount = _currDate - beginDate;
		return monthCount / expectedInterval > 0 && monthCount % expectedInterval == 0;
	}

	public int GetLeftDaysInCurrMonth()
	{
		return DomainManager.Extra.GetTotalActionPointsRemaining() / 10;
	}

	public int GetActionPointPrevMonth()
	{
		return _actionPointPrevMonth;
	}

	[DomainMethod]
	public AdvanceMonthConditionsDisplayData GetAdvanceMonthSoftConditions(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = taiwu.GetId();
		return new AdvanceMonthConditionsDisplayData
		{
			HasExtraMovePoints = (GetLeftDaysInCurrMonth() > 0),
			CanLoopingNeigong = (taiwu.GetLoopingNeigong() == -1 && taiwu.GetLearnedCombatSkills().Any((short id) => Config.CombatSkill.Instance[id].EquipType == 0 && DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(taiwuCharId, id), out var element) && !element.GetRevoked())),
			InventoryOverload = (taiwu.GetCurrInventoryLoad() > taiwu.GetMaxInventoryLoad()),
			WarehouseOverload = (DomainManager.Taiwu.GetWarehouseCurrLoad() > DomainManager.Taiwu.GetWarehouseMaxLoad()),
			EnergyBonus = DomainManager.Building.GetTaiwuLocationResourceBlockEffect(context, EBuildingScaleEffect.ActionPointRegenBonus),
			BuildingCollectAnyMax = DomainManager.Building.AnyBuildingEarnCountMax(context)
		};
	}

	[DomainMethod]
	public void AdvanceDaysInMonth(DataContext context, int days)
	{
		int costActionPoints = days * 10;
		DomainManager.Extra.ConsumeActionPoint(context, costActionPoints);
	}

	public void ConsumeActionPoint(DataContext context, int actionPoints)
	{
		DomainManager.Extra.ConsumeActionPoint(context, actionPoints);
	}

	[DomainMethod]
	public void AdvanceMonth(DataContext context)
	{
		if (_advancingMonthState != 0)
		{
			Logger.Warn($"{"AdvanceMonth"}: Wrong AdvancingMonthState: {_advancingMonthState}.");
			return;
		}
		Logger.Info("AdvanceMonth: begin ------------------------------------------------------------");
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		var (monitor, oriPendingNotifications) = GameData.GameDataBridge.GameDataBridge.StartSemiBlockingTask();
		monitor.MonitorData(new DataUid(1, 28, ulong.MaxValue));
		monitor.MonitorData(new DataUid(1, 26, ulong.MaxValue));
		AdvanceMonth_ResetTemporaryData(context);
		AdvanceMonth_CheckPrerequisites(context);
		Events.RaiseAdvanceMonthBegin(context);
		Logger.Info($"New month begin: Year {GetCurrYear() + 1}, Month {GetCurrMonthInYear() + 1} ({_currDate})");
		if (DomainManager.Global.IsInNormalWorld())
		{
			AdvanceMonth_Execute(context, monitor);
			DlcManager.OnPostAdvanceMonth(context);
		}
		else
		{
			AdvanceMonth_SimulateProcess(context, monitor);
		}
		DomainManager.Global.OnPostAdvanceMonth(context);
		PostAdvanceMonth_ClearRedundantData(context);
		GameData.GameDataBridge.GameDataBridge.StopSemiBlockingTask(monitor, oriPendingNotifications);
		CheckMonthlyEvents(context);
		CheckMonthlyNotifications(context);
		TransferMonthlyNotifications(context);
		stopwatch.Stop();
		if (stopwatch.ElapsedMilliseconds < 2000)
		{
			Thread.Sleep((int)(2000 - stopwatch.ElapsedMilliseconds));
		}
		SetAdvancingMonthState(14, context);
		Logger.Info("AdvanceMonth: end --------------------------------------------------------------");
		Logger.Info($"Advance Month Time Cost: {stopwatch.ElapsedMilliseconds}ms");
	}

	[DomainMethod]
	public void AdvanceMonth_DisplayedMonthlyNotifications(DataContext context, bool saveWorld)
	{
		Logger.Info(saveWorld ? "Exit advancing month state and start saving world." : "Exit advancing month state without saving world.");
		if (_advancingMonthState != 14)
		{
			throw new Exception($"Wrong AdvancingMonthState: {_advancingMonthState}");
		}
		SetAdvancingMonthState(0, context);
		Events.RaiseAdvanceMonthFinish(context);
		Events.ClearPassingLegacyWhileAdvancingMonthHandlers(context);
		RemoveObsoletedInstantNotifications(context);
		if (saveWorld)
		{
			DomainManager.Global.SaveWorld(context);
		}
		UpdatePopulationRelatedData();
		ShowWorldStatistics();
		DomainManager.TaiwuEvent.SetNeedToNotifyNewMonth(value: true, context);
	}

	private void AdvanceMonth_ResetTemporaryData(DataContext context)
	{
		_monthlyEventCollection.Clear();
		_currMonthlyNotifications.Clear();
		GenerateMonthNotifyData();
		DomainManager.Character.ClearAlertnessRecord(context);
		DomainManager.Taiwu.UpdateVillagerRoleRecords(context);
		CharacterDomain.ClearLockMovementCharSet();
		DomainManager.LegendaryBook.ClearActCrazyShockedCharacters();
		DomainManager.Character.ClearTemporaryEnemies(context);
		DomainManager.Character.ClearTemporaryIntelligentCharacters(context);
		DomainManager.Building.RemoveTemporaryPossessionCharacter(context);
		DomainManager.Map.ClearHunterAnim(context);
		DomainManager.Character.ResetAllAdvanceMonthStatus();
		DomainManager.Map.ClearTaiwuMoveRecord();
		DomainManager.Taiwu.SetJieqingPunishmentAssassinAlreadyAdd(value: false);
		DomainManager.Taiwu.SetJieqingHuntTaiwu(DomainManager.Taiwu.GetHuntingTaiwuCharacter() >= 0);
		DomainManager.TaiwuEvent.InviteAdvanceMonth(context);
		DomainManager.TaiwuEvent.InteractedCharSet.Clear();
		DomainManager.Taiwu.AddChoosyRemainUpgradeData(context);
		DomainManager.Character.UpdateFixedCharacterEatingItems(context);
		DomainManager.Taiwu.ClearUnlockedDebateStrategyList(context);
	}

	private void AdvanceMonth_CheckPrerequisites(DataContext context)
	{
		CheckSanity();
		DomainManager.Global.CheckDriveSpace(context);
	}

	public static void CheckSanity()
	{
		DomainManager.Character.CheckCharacterCreationState();
		DomainManager.Character.CheckCharacterTemporaryModificationState();
		DomainManager.Character.Test_SoftCheckGroups();
	}

	public void ShowWorldStatistics()
	{
		DomainManager.Character.ShowCharactersStats();
		DomainManager.Character.ShowNonIntelligentCharactersStats();
		EventArgBox.ShowStatus();
		DomainManager.Item.CheckUnownedItems();
		GlobalDomain.ShowMemoryUsage();
	}

	private void AdvanceMonth_SimulateProcess(DataContext context, DataMonitorManager monitor)
	{
		foreach (AdvancingMonthStateItem advancingStateItem in (IEnumerable<AdvancingMonthStateItem>)AdvancingMonthState.Instance)
		{
			if (advancingStateItem.TemplateId != 0 && advancingStateItem.TemplateId != 14)
			{
				SetAndNotifyAdvancingMonthState(context, (sbyte)advancingStateItem.TemplateId, monitor);
				Thread.Sleep(50);
			}
		}
		EnterNextMonth(context);
		UpdateActionPoint(context);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		taiwu.PeriAdvanceMonth_SelfImprovement_Taiwu(context);
		context.ParallelModificationsRecorder.ApplyAll(context);
	}

	private void SetAndNotifyAdvancingMonthState(DataContext context, sbyte value, DataMonitorManager monitor)
	{
		SetAdvancingMonthState(value, context);
		monitor.CheckMonitoredData();
		GameData.GameDataBridge.GameDataBridge.TransferPendingNotifications();
	}

	private void EnterNextMonth(DataContext context)
	{
		SetCurrDate(_currDate + 1, context);
		sbyte currMonthInYear = GetCurrMonthInYear();
		AddSolarTermNotification(currMonthInYear);
	}

	private void UpdateActionPoint(DataContext context)
	{
		_actionPointPrevMonth = DomainManager.Extra.GetActionPointCurrMonth();
		DomainManager.Extra.UpdateActionPoint(context);
	}

	private void AddSolarTermNotification(int month)
	{
		switch (month)
		{
		case 0:
			_currMonthlyNotifications.AddSolarTerm0();
			break;
		case 1:
			_currMonthlyNotifications.AddSolarTerm1();
			break;
		case 2:
			_currMonthlyNotifications.AddSolarTerm2();
			break;
		case 3:
			_currMonthlyNotifications.AddSolarTerm3();
			break;
		case 4:
			_currMonthlyNotifications.AddSolarTerm4();
			break;
		case 5:
			_currMonthlyNotifications.AddSolarTerm5();
			break;
		case 6:
			_currMonthlyNotifications.AddSolarTerm6();
			break;
		case 7:
			_currMonthlyNotifications.AddSolarTerm7();
			break;
		case 8:
			_currMonthlyNotifications.AddSolarTerm8();
			break;
		case 9:
			_currMonthlyNotifications.AddSolarTerm9();
			break;
		case 10:
			_currMonthlyNotifications.AddSolarTerm10();
			break;
		case 11:
			_currMonthlyNotifications.AddSolarTerm11();
			break;
		}
	}

	private void UpdateStateWeathers(DataContext context)
	{
		sbyte season = TimeKit.GetCurrSeason();
		List<sbyte> weathers = ObjectPool<List<sbyte>>.Instance.Get();
		List<short> weights = ObjectPool<List<short>>.Instance.Get();
		foreach (WeatherItem weather in (IEnumerable<WeatherItem>)Weather.Instance)
		{
			if (weather.Season.Contains(season))
			{
				weathers.Add(weather.TemplateId);
				weights.Add(weather.Weight);
			}
		}
		foreach (MapStateItem state in (IEnumerable<MapStateItem>)MapState.Instance)
		{
			int index = RandomUtils.GetRandomIndex(weights, context.Random);
			sbyte weather2 = weathers[index];
			if (_stateWeathers.ContainsKey(state.TemplateId))
			{
				SetElement_StateWeathers(state.TemplateId, weather2, context);
			}
			else
			{
				AddElement_StateWeathers(state.TemplateId, weather2, context);
			}
		}
	}

	public void UpdateAreaStoryWeathers(DataContext context, short areaId, sbyte weatherTemplateId)
	{
		if (TryGetElement_AreaStoryWeathers(areaId, out var _))
		{
			if (weatherTemplateId < 0)
			{
				RemoveElement_AreaStoryWeathers(areaId, context);
			}
			else
			{
				SetElement_AreaStoryWeathers(areaId, weatherTemplateId, context);
			}
		}
		else if (weatherTemplateId >= 0)
		{
			AddElement_AreaStoryWeathers(areaId, weatherTemplateId, context);
		}
	}

	private void GenerateMonthNotifyData()
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		PoisonInts poisoned = default(PoisonInts);
		poisoned.Add(ref taiwu.GetPoisoned());
		MonthNotify data = new MonthNotify
		{
			Date = _currDate + 1,
			TaiwuId = taiwu.GetId(),
			PrevInjuries = taiwu.GetInjuries(),
			PrevPoison = poisoned,
			PrevHappiness = taiwu.GetHappiness(),
			PrevHealth = taiwu.GetHealth(),
			PrevMaxLeftHealth = taiwu.GetLeftMaxHealth(),
			PrevQiDisorder = taiwu.GetDisorderOfQi(),
			PrevAttributes = taiwu.GetCurrMainAttributes(),
			PrevMaxAttributes = taiwu.GetMaxMainAttributes(),
			LoopingCombatSkillTemplateId = taiwu.GetLoopingNeigong(),
			PrevNeili = taiwu.GetCurrNeili(),
			PrevMaxNeili = taiwu.GetMaxNeili(),
			PrevNeiliPercent = taiwu.GetNeiliProportionOfFiveElements(),
			NeiliTransferType = -1,
			NeiliDstType = -1,
			NeiliTransferAmount = 0,
			PrevNeiliType = taiwu.GetNeiliType(),
			PrevExtraNeiliAllocationProgress = new List<int>(taiwu.GetExtraNeiliAllocationProgress()).ToArray(),
			ReadingBook = DomainManager.Taiwu.GetCurReadingBook(),
			ReferenceBooks = new List<ItemKey>(DomainManager.Taiwu.GetReferenceBooks())
		};
		if (data.ReadingBook.IsValid())
		{
			ItemBase item = DomainManager.Item.GetBaseItem(data.ReadingBook);
			SkillBookPageDisplayData pageData = DomainManager.Item.GetSkillBookPagesInfo(data.ReadingBook);
			data.BookMaxDurability[data.ReadingBook] = item.GetMaxDurability();
			data.BookPrevDurability[data.ReadingBook] = item.GetCurrDurability();
			data.PrevReadingProgress = pageData.ReadingProgress;
			data.ReadingBookState = pageData.State;
			data.ReadingBookType = pageData.Type;
		}
		foreach (ItemKey key in data.ReferenceBooks)
		{
			if (key.IsValid())
			{
				ItemBase item2 = DomainManager.Item.GetBaseItem(key);
				data.BookMaxDurability[key] = item2.GetMaxDurability();
				data.BookPrevDurability[key] = item2.GetCurrDurability();
				data.BookRefSpeed[key] = DomainManager.Taiwu.GetRefBonusSpeed(key);
			}
		}
		int taiwuId = taiwu.GetId();
		HashSet<int> charIds = new HashSet<int>();
		DomainManager.Character.GetRelatedCharacters(taiwuId).GetAllRelatedCharIds(charIds);
		foreach (int charId in charIds)
		{
			if (DomainManager.Character.TryGetRelation(charId, taiwuId, out var relation))
			{
				data.CharacterNames[charId] = DomainManager.Character.GetNameAndLifeRelatedData(charId);
				data.PrevFavor[charId] = relation.Favorability;
				if (data.CharacterNames[charId].LifeState == 0)
				{
					data.Avatars[charId] = DomainManager.Character.GetAvatarRelatedData(charId);
				}
			}
		}
		data.CharacterNames[taiwuId] = DomainManager.Character.GetNameAndLifeRelatedData(taiwuId);
		data.Avatars[taiwuId] = DomainManager.Character.GetAvatarRelatedData(taiwuId);
		GenerateMonthNotifyInformationData();
		_monthNotifies.Insert(0, data);
		if (_monthNotifies.Count > GlobalConfig.Instance.MonthsMonthNotificationsKept)
		{
			_monthNotifies.RemoveAt(GlobalConfig.Instance.MonthsMonthNotificationsKept);
		}
	}

	private void GenerateMonthNotifyInformationData()
	{
		_monthNotifyInformation.Clear();
		_monthNotifySecretInformation.Clear();
		_monthNotifyInBroadcastSecretInformation.Clear();
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		if (DomainManager.Information.TryGetElement_Information(taiwuId, out var collection))
		{
			foreach (NormalInformation item in collection.GetList())
			{
				_monthNotifyInformation.Add(item);
			}
		}
		if (!DomainManager.Information.TryGetCharacterKnownSecret(taiwuId, out var known))
		{
			return;
		}
		foreach (SecretInformationId secretId in known.KnownSecrets)
		{
			if (DomainManager.Information.TryGetSecretInformationSnapshot(secretId, known, out var snapshot))
			{
				_monthNotifySecretInformation.Add((int)secretId, snapshot);
			}
		}
		foreach (GameData.Domains.Information.Secret.SecretInformation secret in DomainManager.Information.QueryAllSecretInformation((SecretOccurence occurence) => occurence.InBroadcast))
		{
			_monthNotifyInBroadcastSecretInformation.Add((int)secret.Id);
		}
	}

	private void UpdateMonthNotifyData(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		MonthNotify data = _monthNotifies[0];
		PoisonInts poisoned = default(PoisonInts);
		poisoned.Add(ref taiwu.GetPoisoned());
		data.MonthlyNotificationCollection = _currMonthlyNotifications;
		_currMonthlyNotifications = new MonthlyNotificationCollection();
		List<RenderInfo> renderInfoList = new List<RenderInfo>();
		ArgumentCollection notificationArgumentCollection = new ArgumentCollection();
		data.MonthlyNotificationCollection.GetRenderInfos(renderInfoList, notificationArgumentCollection);
		foreach (int charId in notificationArgumentCollection.Characters)
		{
			data.CharacterNames[charId] = DomainManager.Character.GetNameAndLifeRelatedData(charId);
			if (data.CharacterNames[charId].LifeState == 0)
			{
				data.Avatars[charId] = DomainManager.Character.GetAvatarRelatedData(charId);
			}
		}
		foreach (int jiaoId in notificationArgumentCollection.JiaoLoongs)
		{
			data.JiaoLoongNames[jiaoId] = DomainManager.Extra.GetJiaoLoongNameRelatedData(jiaoId);
		}
		data.CurrInjuries = taiwu.GetInjuries();
		data.CurrPoison = poisoned;
		data.CurrHappiness = taiwu.GetHappiness();
		data.CurrHealth = taiwu.GetHealth();
		data.CurrMaxLeftHealth = taiwu.GetLeftMaxHealth();
		data.CurrQiDisorder = taiwu.GetDisorderOfQi();
		data.CurrAttributes = taiwu.GetCurrMainAttributes();
		data.CurrMaxAttributes = taiwu.GetMaxMainAttributes();
		data.Eaten = taiwu.GetEatingItems();
		data.CurrNeili = taiwu.GetCurrNeili();
		data.CurrMaxNeili = taiwu.GetMaxNeili();
		data.CurrNeiliPercent = taiwu.GetNeiliProportionOfFiveElements();
		data.ActiveLoopingProgress = (short)((data.LoopingCombatSkillTemplateId >= 0) ? DomainManager.Extra.GetActiveLoopingProgress() : 0);
		data.ActiveReadingProgress = (short)(data.ReadingBook.IsValid() ? DomainManager.Extra.GetActiveReadingProgress() : 0);
		data.CurrNeiliType = taiwu.GetNeiliType();
		if (data.LoopingCombatSkillTemplateId >= 0 && DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(taiwu.GetId(), data.LoopingCombatSkillTemplateId), out var skill))
		{
			(sbyte destinationType, sbyte transferType, sbyte amount) loopingTransferNeiliProportionOfFiveElementsData = CombatSkillDomain.GetLoopingTransferNeiliProportionOfFiveElementsData(context, taiwu, data.LoopingCombatSkillTemplateId, skill);
			sbyte destinationType = loopingTransferNeiliProportionOfFiveElementsData.destinationType;
			sbyte transferType = loopingTransferNeiliProportionOfFiveElementsData.transferType;
			sbyte amount = loopingTransferNeiliProportionOfFiveElementsData.amount;
			int source = ((transferType >= 0 && destinationType >= 0) ? NeiliProportionOfFiveElements.GetTransferSource(transferType, destinationType) : (-1));
			data.NeiliDstType = destinationType;
			data.NeiliTransferType = (sbyte)source;
			data.NeiliTransferAmount = amount;
			data.LoopingObtainedNeili = skill.GetObtainedNeili();
			data.LoopingTotalObtainableNeili = skill.GetTotalObtainableNeili();
		}
		data.CurrExtraNeiliAllocationProgress = new List<int>(taiwu.GetExtraNeiliAllocationProgress()).ToArray();
		if (data.ReadingBook.IsValid())
		{
			data.BookCurrDurability[data.ReadingBook] = (short)(DomainManager.Item.ItemExists(data.ReadingBook) ? DomainManager.Item.GetBaseItem(data.ReadingBook).GetCurrDurability() : 0);
			data.CurrReadingProgress = DomainManager.Item.GetSkillBookPagesInfo(data.ReadingBook).ReadingProgress;
			data.ReadingProgress = DomainManager.Taiwu.GetTotalReadingProgress(data.ReadingBook.Id);
		}
		foreach (ItemKey key in data.ReferenceBooks)
		{
			if (key.IsValid())
			{
				if (!DomainManager.Item.ItemExists(key))
				{
					data.BookCurrDurability[key] = 0;
					data.BookRefSpeed[key] = 0;
				}
				else
				{
					data.BookCurrDurability[key] = DomainManager.Item.GetBaseItem(key).GetCurrDurability();
					data.BookRefSpeed[key] = DomainManager.Taiwu.GetRefBonusSpeed(key);
				}
			}
		}
		data.ReadingEvent = DomainManager.Extra.GetReadingEventBookIdList().Contains(data.ReadingBook.Id);
		data.LoopingEvent = DomainManager.Extra.GetLoopingEventSkillIdList().Contains(data.LoopingCombatSkillTemplateId);
		int taiwuId = taiwu.GetId();
		HashSet<int> charIds = new HashSet<int>();
		DomainManager.Character.GetRelatedCharacters(taiwuId).GetAllRelatedCharIds(charIds);
		foreach (int charId2 in charIds)
		{
			if (DomainManager.Character.TryGetRelation(charId2, taiwuId, out var relation))
			{
				data.CurrFavor[charId2] = relation.Favorability;
			}
		}
		SaveMonthNotifyInformationModificationData(data);
		SaveMonthNotifyVillageOutlineData(data);
		SetMonthNotifies(_monthNotifies, context);
	}

	[DomainMethod]
	public MonthNotifyDisplayData GetNewestMonthNotifyDisplayData()
	{
		MonthNotifyDisplayData res = new MonthNotifyDisplayData();
		List<MonthNotify> monthNotifies = _monthNotifies;
		if (monthNotifies == null || monthNotifies.Count <= 0)
		{
			return res;
		}
		List<RenderInfo> renderInfoList = new List<RenderInfo>();
		ArgumentCollection notificationArgumentCollection = new ArgumentCollection();
		MonthNotify monthNotify = _monthNotifies[0];
		ArgumentCollectionRenderArguments arguments = new ArgumentCollectionRenderArguments();
		monthNotify.MonthlyNotificationCollection.GetRenderInfos(renderInfoList, notificationArgumentCollection);
		arguments.CharNameAndLifeDataList = new List<NameAndLifeRelatedData>();
		arguments.JiaoLoongNames = new List<JiaoLoongNameRelatedData>();
		arguments.LocationNames = new List<LocationNameRelatedData>();
		arguments.SettlementNames = new List<SettlementNameRelatedData>();
		foreach (int charId in notificationArgumentCollection.Characters)
		{
			arguments.CharNameAndLifeDataList.Add(monthNotify.CharacterNames[charId]);
		}
		foreach (int jiaoId in notificationArgumentCollection.JiaoLoongs)
		{
			arguments.JiaoLoongNames.Add(monthNotify.JiaoLoongNames[jiaoId]);
		}
		List<Location> locations = notificationArgumentCollection.Locations;
		if (locations != null && locations.Count > 0)
		{
			arguments.LocationNames = DomainManager.Map.GetLocationNameRelatedDataList(notificationArgumentCollection.Locations);
		}
		List<short> settlements = notificationArgumentCollection.Settlements;
		if (settlements != null && settlements.Count > 0)
		{
			arguments.SettlementNames = DomainManager.Organization.GetSettlementNameRelatedData(notificationArgumentCollection.Settlements);
		}
		res.MonthNotifies.Add(monthNotify);
		res.Arguments.Add(arguments);
		return res;
	}

	[DomainMethod]
	public MonthNotifyDisplayData GetMonthNotifyDisplayData()
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		MonthNotifyDisplayData res = new MonthNotifyDisplayData();
		List<RenderInfo> renderInfoList = new List<RenderInfo>();
		ArgumentCollection notificationArgumentCollection = new ArgumentCollection();
		for (int index = 0; index < _monthNotifies.Count; index++)
		{
			MonthNotify monthNotify = _monthNotifies[index];
			notificationArgumentCollection.Clear();
			ArgumentCollectionRenderArguments arguments = new ArgumentCollectionRenderArguments();
			monthNotify.MonthlyNotificationCollection.GetRenderInfos(renderInfoList, notificationArgumentCollection);
			arguments.CharNameAndLifeDataList = new List<NameAndLifeRelatedData>();
			arguments.JiaoLoongNames = new List<JiaoLoongNameRelatedData>();
			arguments.LocationNames = new List<LocationNameRelatedData>();
			arguments.SettlementNames = new List<SettlementNameRelatedData>();
			foreach (int charId in notificationArgumentCollection.Characters)
			{
				arguments.CharNameAndLifeDataList.Add(monthNotify.CharacterNames[charId]);
			}
			foreach (int jiaoId in notificationArgumentCollection.JiaoLoongs)
			{
				arguments.JiaoLoongNames.Add(monthNotify.JiaoLoongNames[jiaoId]);
			}
			List<Location> locations = notificationArgumentCollection.Locations;
			if (locations != null && locations.Count > 0)
			{
				arguments.LocationNames = DomainManager.Map.GetLocationNameRelatedDataList(notificationArgumentCollection.Locations);
			}
			List<short> settlements = notificationArgumentCollection.Settlements;
			if (settlements != null && settlements.Count > 0)
			{
				arguments.SettlementNames = DomainManager.Organization.GetSettlementNameRelatedData(notificationArgumentCollection.Settlements);
			}
			res.MonthNotifies.Add(monthNotify);
			res.Arguments.Add(arguments);
			foreach (var (id, snapshot) in monthNotify.SecretInformationSnapshots)
			{
				res.SecretInformationLocation[id] = DomainManager.Map.GetBlockFullName(snapshot.Location);
			}
			for (int i = 0; i < 9; i++)
			{
				ItemKey itemKey = monthNotify.Eaten.GetItem(i);
				if (itemKey.IsValid())
				{
					res.EatenItem[itemKey] = DomainManager.Item.GetItemDisplayData(itemKey);
				}
			}
		}
		return res;
	}

	private void SaveMonthNotifyInformationModificationData(MonthNotify data)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		if (DomainManager.Information.TryGetElement_Information(taiwuId, out var collection))
		{
			foreach (NormalInformation item in collection.GetList())
			{
				if (!_monthNotifyInformation.Contains(item))
				{
					data.Information.Add(item);
				}
			}
		}
		if (!DomainManager.Information.TryGetCharacterKnownSecret(taiwuId, out var known))
		{
			return;
		}
		foreach (SecretInformationId secretId in known.KnownSecrets)
		{
			if (!_monthNotifySecretInformation.ContainsKey((int)secretId) && DomainManager.Information.TryGetSecretInformationSnapshot(secretId, known, out var snapshot))
			{
				snapshot.Type = 0;
				data.SecretInformationSnapshots[(int)secretId] = snapshot;
			}
		}
		foreach (var (intId, snapshot2) in _monthNotifySecretInformation)
		{
			if (!known.KnownSecrets.Contains((SecretInformationId)intId))
			{
				snapshot2.Type = 2;
				data.SecretInformationSnapshots[intId] = snapshot2;
				continue;
			}
			GameData.Domains.Information.Secret.SecretInformation secret = DomainManager.Information.QuerySecretInformation((SecretInformationId)intId);
			if (secret != null)
			{
				SecretOccurence secretOccurence = DomainManager.Information.QuerySecretOccurence(secret.Id);
				if (secretOccurence != null && secretOccurence.PackedParameters != null && InformationDomain.CalcSecretOccurenceRemainingLifeTime(secretOccurence) <= 3)
				{
					snapshot2.Type = 3;
					data.SecretInformationSnapshots[intId] = snapshot2;
				}
			}
		}
		foreach (GameData.Domains.Information.Secret.SecretInformation secret2 in DomainManager.Information.QueryAllSecretInformation((SecretOccurence occurence) => occurence.InBroadcast))
		{
			if (!_monthNotifyInBroadcastSecretInformation.Contains((int)secret2.Id) && DomainManager.Information.TryGetSecretInformationSnapshot(secret2.Id, known, out var snapshot3))
			{
				snapshot3.Type = 1;
				data.SecretInformationSnapshots[(int)secret2.Id] = snapshot3;
			}
		}
		foreach (SecretInformationSnapshot snapshot4 in data.SecretInformationSnapshots.Values)
		{
			SecretInformationItem config = Config.SecretInformation.Instance[snapshot4.SecretInformationTemplateId];
			snapshot4.ParametersPack.ExtractSecretParameters(config, delegate(int _, int charId)
			{
				if (!data.CharacterScore.ContainsKey(charId))
				{
					AddSecretInformationCharacterData(data, charId);
				}
			});
			if (snapshot4.SourceCharacterId >= 0)
			{
				AddSecretInformationCharacterData(data, snapshot4.SourceCharacterId);
			}
		}
	}

	private void AddSecretInformationCharacterData(MonthNotify data, int charId)
	{
		GameData.Domains.Character.Character character;
		DeadCharacter dead;
		OrganizationInfo orgInfo = (DomainManager.Character.TryGetElement_Objects(charId, out character) ? character.GetOrganizationInfo() : (DomainManager.Character.TryGetDeadCharacter(charId, out dead) ? dead.OrganizationInfo : OrganizationInfo.None));
		data.TaiwuRelations[charId] = DomainManager.Information.GetHighestScoreRelation(charId);
		data.CharacterScore[charId] = (ushort)(Config.Organization.Instance[orgInfo.OrgTemplateId].IsSect ? GlobalConfig.Instance.SecretSectFactor[orgInfo.Grade] : GlobalConfig.Instance.SecretNonSectFactor[orgInfo.Grade]);
		data.CharacterNames[charId] = DomainManager.Character.GetNameAndLifeRelatedData(charId);
		if (data.CharacterNames[charId].LifeState == 0)
		{
			data.Avatars[charId] = DomainManager.Character.GetAvatarRelatedData(charId);
		}
	}

	private void SaveMonthNotifyVillageOutlineData(MonthNotify data)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		SettlementTreasury treasury = DomainManager.Taiwu.GetTaiwuTreasury();
		short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		CivilianSettlement settlement = DomainManager.Organization.GetElement_CivilianSettlements(settlementId);
		Dictionary<int, VillagerWorkData> works = DomainManager.Taiwu.GetVillagerWorkDict();
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingBlockData blockData = DomainManager.Building.GetBuildingBlockData(44);
		sbyte villageLevel = DomainManager.Building.BuildingBlockLevel(new BuildingBlockKey(location.AreaId, location.BlockId, blockData.BlockIndex));
		DomainManager.Building.GetAllQuickCollectionAmount(out data.GainMoney, out data.GainAuthority, out data.GainVillager, out data.GainItem, out data.PawnShopItem);
		data.Resources.Add(ref taiwu.GetResources());
		data.Resources.Add(ref treasury.Resources);
		data.ResourceDelta = DomainManager.Taiwu.GetResourceChange();
		data.VillagerCount = DomainManager.Taiwu.GetTotalVillagerCount();
		data.YouthCount = data.VillagerCount - DomainManager.Taiwu.GetTotalAdultVillagerCount();
		data.IdleCount = DomainManager.Taiwu.GetAvailableVillagerCount();
		data.RoleCount = DomainManager.Extra.GetVillagerRoleCharacters().Count;
		data.HouseCapacity = DomainManager.Building.GetResidenceInfo().sumCapacity;
		data.StoneCurr = DomainManager.Extra.GetStoneRoomCharList().Count;
		data.StoneMax = BuildingScale.DefValue.StoneRoomCapacity.GetLevelEffect(villageLevel);
		data.DispatchCount = settlement.GetMembers().Count(delegate(int charId)
		{
			VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(charId);
			VillagerWorkData value;
			return (villagerRole != null && villagerRole.ArrangementTemplateId >= 0) || (works.TryGetValue(charId, out value) && value.WorkType >= 10);
		});
		data.ManagingCount = DomainManager.Building.GetShopManagerDict().Values.Sum((CharacterList characterList) => characterList.GetCollection().Count((int charId) => DomainManager.Character.TryGetElement_Objects(charId, out var element) && element.GetAgeGroup() == 2));
		data.WarehouseCurr = DomainManager.Taiwu.GetWarehouseCurrLoad();
		data.WarehouseMax = DomainManager.Taiwu.GetWarehouseMaxLoad();
		data.SafetyCurr = settlement.GetSafety();
		data.SafetyMax = settlement.GetMaxSafety();
		data.CultureCurr = settlement.GetCulture();
		data.CultureMax = settlement.GetMaxCulture();
		data.BuildingCount = DomainManager.Taiwu.GetBuildingSpaceCurr();
		data.BuildingCapacity = DomainManager.Taiwu.GetBuildingSpaceLimit();
	}

	private void AdvanceMonth_Execute(DataContext context, DataMonitorManager monitor)
	{
		Stopwatch timer = GlobalDomain.StartTimer();
		DomainManager.Map.BlockCharacterFix(context);
		SetAndNotifyAdvancingMonthState(context, 1, monitor);
		EnterNextMonth(context);
		UpdateActionPoint(context);
		ProfessionSkillHandle.OnPreAdvanceMonth(context);
		DomainManager.Taiwu.LoseOverloadWarehouseItems(context);
		if (DomainManager.World.GetWorldFunctionsStatus(10))
		{
			DomainManager.Taiwu.CalcVillagerWorkLocation(context);
		}
		if (DomainManager.World.GetWorldFunctionsStatus(10))
		{
			DomainManager.Taiwu.CalcVillagerWorkOnMap(context);
		}
		if (DomainManager.World.GetWorldFunctionsStatus(10))
		{
			PreAdvanceMonth_Building(context);
		}
		DomainManager.Organization.UpdateApprovingRateEffectOnAdvanceMonth(context);
		DomainManager.Building.UpdateMakingProgressOnMonthChange(context);
		DomainManager.Organization.MakeNoneOrgCharactersBecomeBeggar(context);
		DomainManager.Character.AssassinationByJieqing(context);
		GlobalDomain.StopTimer(timer, "[AdvanceMonth_Execute] PreAdvanceMonth");
		SetAndNotifyAdvancingMonthState(context, 2, monitor);
		ParallelActionManager.Execute(monitor, CharacterParallelAction<CharacterMixedPoisonEffect>.Instance);
		timer = GlobalDomain.StartTimer();
		ParallelActionManager.Execute(monitor, CharacterParallelAction<UpdateCharacterStatus>.Instance);
		DomainManager.Character.UpdateCharacterAliveStates(context);
		DomainManager.Character.RecoverGuards(context);
		DomainManager.Character.UpdateGroupFavorabilities(context);
		DomainManager.Character.UpdateKidnappedCharacters(context);
		DomainManager.Character.UpdatePregnancyUnlockDates(context);
		DomainManager.LegendaryBook.UpdateLegendaryBookOwnersStatuses(context);
		DomainManager.Character.TryRestoreCharacterAvatars(context);
		DomainManager.Character.PostAdvanceMonthCalcDarkAsh(context);
		DomainManager.Character.UpdateTwelveImmortals(context);
		GlobalDomain.StopTimer(timer, "[AdvanceMonth_Execute] UpdateStatus");
		SetAndNotifyAdvancingMonthState(context, 3, monitor);
		WorkerThreadManager.Run(DomainManager.Adventure.PreAdvanceMonth_UpdateRandomEnemies, 0, 141, monitor, 100);
		timer = GlobalDomain.StartTimer();
		SetAndNotifyAdvancingMonthState(context, 4, monitor);
		DomainManager.Taiwu.UpdateReadingLoopingOnAdvanceMonth(context);
		ParallelActionManager.Execute(monitor, CharacterParallelAction<CharacterSelfImprovement>.Instance);
		ParallelActionManager.Execute(monitor, CharacterParallelAction<CharacterSelfImprovement_LearnNewSkills>.Instance);
		DomainManager.Character.UpdateSeniorityForCharacterProfessions(context);
		ParallelActionManager.Execute(monitor, CharacterParallelAction<CharacterSelfImprovement_Reading>.Instance);
		ParallelActionManager.Execute(monitor, CharacterParallelAction<CharacterSelfImprovement_PracticeAndBreakout>.Instance);
		GlobalDomain.StopTimer(timer, "[AdvanceMonth_Execute] SelfImprovement");
		timer = GlobalDomain.StartTimer();
		SetAndNotifyAdvancingMonthState(context, 5, monitor);
		ParallelActionManager.Execute(monitor, CharacterParallelAction<CharacterPreparation_GetSupply>.Instance);
		ParallelActionManager.Execute(monitor, CharacterParallelAction<CharacterPreparation_CombatSkillAndItemEquipping>.Instance);
		DomainManager.Item.UpdateCrickets(context);
		DomainManager.Building.UpdateCricketRoom(context);
		if (GameData.Domains.Taiwu.SharedMethods.NeedCostMoreResource)
		{
			DomainManager.Taiwu.CostResources(context);
		}
		SetAndNotifyAdvancingMonthState(context, 6, monitor);
		ParallelActionManager.Execute(monitor, CharacterParallelAction<CharacterPreparation_LoseOverloadItems>.Instance);
		DomainManager.Taiwu.UpdateVillagerTreasuryNeed(context);
		DomainManager.Taiwu.LoseOverloadResources(context);
		GlobalDomain.StopTimer(timer, "[AdvanceMonth_Execute] CharacterPreparation");
		timer = GlobalDomain.StartTimer();
		SetAndNotifyAdvancingMonthState(context, 7, monitor);
		ParallelActionManager.Execute(monitor, CharacterParallelActionWithTarget<CharacterRelationsUpdate>.Instance);
		DomainManager.Character.UpdateDistantMarriages(context);
		DomainManager.Character.UpdateAdoreRelationsInMarriage(context);
		DomainManager.Organization.ExpandAllFactions(context);
		GlobalDomain.StopTimer(timer, "[AdvanceMonth_Execute] CharacterRelationsUpdate");
		timer = GlobalDomain.StartTimer();
		if (DomainManager.World.GetWorldFunctionsStatus(30))
		{
			DomainManager.Character.PrepareForPrioritizedAction(context);
		}
		SetAndNotifyAdvancingMonthState(context, 8, monitor);
		if (DomainManager.World.GetWorldFunctionsStatus(30))
		{
			ParallelActionManager.Execute(monitor, CharacterParallelAction<UpdateCharacterMission>.Instance);
		}
		ParallelActionManager.Execute(monitor, CharacterParallelAction<UpdateCharacterGoal>.Instance);
		DomainManager.Character.UpdateInfectedCharacterActions(context);
		DomainManager.LegendaryBook.UpdateLegendaryBookOwnersActions(context);
		SetAndNotifyAdvancingMonthState(context, 9, monitor);
		if (DomainManager.World.GetWorldFunctionsStatus(30))
		{
			ParallelActionManager.Execute(monitor, CharacterParallelAction<UpdatePrimaryGoalAndActions>.Instance);
		}
		SetAndNotifyAdvancingMonthState(context, 10, monitor);
		if (DomainManager.World.GetWorldFunctionsStatus(30))
		{
			ParallelActionManager.Execute(monitor, CharacterParallelAction<UpdateSecondaryGoalAndActions>.Instance);
		}
		GlobalDomain.StopTimer(timer, "[AdvanceMonth_Execute] CharacterActionPlanning");
		timer = GlobalDomain.StartTimer();
		SetAndNotifyAdvancingMonthState(context, 11, monitor);
		PeriAdvanceMonth_CharacterFixedAction(context, monitor);
		GlobalDomain.StopTimer(timer, "[AdvanceMonth_Execute] CharacterFixedAction");
		DomainManager.Taiwu.MoveVillagersToWorkLocation(context);
		DomainManager.Character.RecoverSkillBookLibraries(context);
		DomainManager.Extra.UpdateItemPriceFluctuations(context);
		Events.RaisePostAdvanceMonthBegin(context);
		timer = GlobalDomain.StartTimer();
		SetAndNotifyAdvancingMonthState(context, 12, monitor);
		DomainManager.Information.ProcessAdvanceMonth(context);
		GlobalDomain.StopTimer(timer, "[AdvanceMonth_Execute] UpdateInformation");
		DomainManager.Character.UpdateLuckEvents(context);
		DomainManager.Merchant.OnPostAdvanceMonth(context);
		PostAdvanceMonth_Map(context, monitor);
		DomainManager.TaiwuEvent.XiangshuMinionSurroundTaiwuVillage(context);
		timer = GlobalDomain.StartTimer();
		DomainManager.Character.UpdateInfectedCharacterMovements(context);
		DomainManager.Map.UpdateXiangshuInfectedDemons(context);
		DomainManager.Character.UpdateLegendaryBookInsaneCharacterMovements(context);
		GlobalDomain.StopTimer(timer, "[AdvanceMonth_Execute] UpdateInfectedCharacters");
		timer = GlobalDomain.StartTimer();
		DomainManager.Character.UpdateFixedCharacterMovements(context);
		DomainManager.Character.UpdateIntelligentCharacterMovements(context);
		GlobalDomain.StopTimer(timer, "[AdvanceMonth_Execute] UpdateCharacterMovements");
		PostAdvanceMonth_Taming(context, monitor);
		if (DomainManager.World.GetWorldFunctionsStatus(10))
		{
			PostAdvanceMonth_Building(context);
		}
		timer = GlobalDomain.StartTimer();
		DomainManager.Organization.UpdateOrganizationMembers(context);
		GlobalDomain.StopTimer(timer, "[AdvanceMonth_Execute] UpdateOrganizationMembers");
		DomainManager.Character.DecayGraves(context);
		DomainManager.Organization.UpdateSectPrisonersOnAdvanceMonth(context);
		DomainManager.Character.UpdateCharacterTimers(context);
		DomainManager.LegendaryBook.CreateLegendaryBooksAccordingToXiangshuProgress(context);
		DomainManager.Organization.UpdateMartialArtTournament(context);
		DomainManager.Adventure.UpdateAdventures(context);
		ProfessionSkillHandle.OnPostAdvanceMonth(context);
		DomainManager.Story.InvokeAdvanceSwordFragmentSkillEvent();
		DomainManager.Story.OnAdvanceMonth(context);
		DomainManager.Organization.UpdateSpecialCustomizedSeverity(context);
		DomainManager.Extra.UpdateArtisanOrderProgress(context);
		DomainManager.Taiwu.UpdateChildrenEducation(context);
	}

	private void PeriAdvanceMonth_CharacterFixedAction(DataContext context, DataMonitorManager monitor)
	{
		if (!DomainManager.TaiwuEvent.GetGlobalEventArgumentBox().Get("MainStoryLine_SpiritualWanderPlace_TaiwuVillagersCenter", out Location _))
		{
			ParallelActionManager.Execute(monitor, CharacterParallelActionWithTarget<CharacterFixedAction>.Instance);
			DomainManager.Character.UpdateExceedingGroupChars(context);
			DomainManager.Taiwu.UpdateVillagerFixedActions(context);
		}
	}

	private static void TestCreateChildren(DataContext context)
	{
		List<(GameData.Domains.Character.Character, GameData.Domains.Character.Character)> charsToChildbirth = new List<(GameData.Domains.Character.Character, GameData.Domains.Character.Character)>();
		float childBirthProb = 0.01f * DomainManager.World.GetProbAdjustOfCreatingCharacter();
		for (short areaId = 0; areaId < 135; areaId++)
		{
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
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
					if (character.GetGender() == 0 && character.GetAgeGroup() == 2)
					{
						HashSet<int> spouseCharIds = DomainManager.Character.GetRelatedCharIds(charId, 1024);
						int aliveSpouseId = DomainManager.Character.GetAliveSpouse(charId);
						if ((spouseCharIds.Count <= 0 || aliveSpouseId >= 0) && !(context.Random.NextFloat() >= childBirthProb))
						{
							GameData.Domains.Character.Character spouse = ((aliveSpouseId >= 0) ? DomainManager.Character.GetElement_Objects(aliveSpouseId) : null);
							charsToChildbirth.Add((character, spouse));
						}
					}
				}
			}
		}
		foreach (var (mother, father) in charsToChildbirth)
		{
			DomainManager.Character.TestAddPregnantState(context, mother, father);
			DomainManager.Character.ParallelCreateNewbornChildren(context, mother, isDystocia: false, isMotherDead: false);
		}
		context.ParallelModificationsRecorder.ApplyAll(context);
	}

	private static void TestGenerateLifeRecords(DataContext context)
	{
		LifeRecordCollection lifeRecords = DomainManager.LifeRecord.GetLifeRecordCollection();
		DomainManager.LifeRecord.InitializeTestRelatedData();
		for (short areaId = 0; areaId < 135; areaId++)
		{
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
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
					DomainManager.LifeRecord.AddRandomLifeRecord(context, lifeRecords, character, blocks[i]);
				}
			}
		}
	}

	private void TestGenerateMonthlyNotifications(DataContext context)
	{
		MonthlyNotificationCollection notifications = GetMonthlyNotificationCollection();
		PrepareTestMonthlyNotificationRelatedData();
		int notificationsCount = context.Random.Next(6, 25);
		for (int i = 0; i < notificationsCount; i++)
		{
			AddRandomMonthlyNotification(context, notifications);
		}
	}

	private void TestGenerateInstantNotifications(DataContext context)
	{
		InstantNotificationCollection notifications = GetInstantNotificationCollection();
		PrepareTestInstantNotificationRelatedData();
		int notificationsCount = context.Random.Next(15, 31);
		for (int i = 0; i < notificationsCount; i++)
		{
			AddRandomInstantNotification(context, notifications);
		}
	}

	private void PostAdvanceMonth_Map(DataContext context, DataMonitorManager monitor)
	{
		WorkerThreadManager.Run(MapDomain.ParallelUpdateOnMonthChange, 0, 45, monitor, 100);
		WorkerThreadManager.Run(MapDomain.ParallelUpdateBrokenBlockOnMonthChange, 45, 135, monitor, 100);
		UpdateStateWeathers(context);
		DomainManager.Map.UpdateCricketPlaceData(context);
		DomainManager.Extra.UpdateAnimalAreaData(context);
		DomainManager.Extra.UpdateMapBlockRecoveryUnlockDates(context);
		if (DomainManager.World.GetWorldFunctionsStatus(29))
		{
			DomainManager.Character.GenerateSkeletons(context);
		}
		DomainManager.Extra.MapPickupsPostAdvanceMonth(context);
	}

	private void PostAdvanceMonth_Building(DataContext context)
	{
		if (DomainManager.World.GetWorldFunctionsStatus(10))
		{
			DomainManager.Building.UpdateBrokenBuildings(context);
			DomainManager.Building.TaiwuVillagerBecomeAdultAdvanceMonth(context);
			DomainManager.Building.ParallelUpdate(context);
			context.ParallelModificationsRecorder.ApplyAll(context);
			DomainManager.Taiwu.MakeVillagerWorkSettlementsVisited(context);
			DomainManager.Taiwu.UpdateVillagerRoleNewClothing(context);
			DomainManager.Extra.UpdateBuildingAreaEffectProgresses(context);
			DomainManager.Building.FeastAdvanceMonth_Complement(context);
			short availableVillagerCount = DomainManager.Taiwu.GetAvailableVillagerCount();
			if (availableVillagerCount > 0)
			{
				short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
				InstantNotificationCollection instantNotifications = DomainManager.World.GetInstantNotificationCollection();
				instantNotifications.AddTaiwuVillageIdleCount(settlementId, availableVillagerCount);
			}
		}
	}

	private void PostAdvanceMonth_Taming(DataContext context, DataMonitorManager monitor)
	{
		DomainManager.Extra.UpdateTaiwuTeammateTaming(context);
		WorkerThreadManager.Run(DomainManager.Extra.PostAdvanceMonth_UpdateNpcTaming, 0, 141, monitor, 100);
		Thread.Sleep(20);
		DomainManager.Extra.UpdateTaiwuTaming(context);
	}

	private static void PostAdvanceMonth_ClearRedundantData(DataContext context)
	{
		DomainManager.Taiwu.ClearAdvanceMonthData();
		if (DomainManager.World.GetCurrMonthInYear() == 0)
		{
			DomainManager.Character.TryRemoveRecentDeadCharacters(context);
			DomainManager.Character.TryRemoveDeadCharacters(context);
			short currYear = DomainManager.World.GetCurrYear();
			if (currYear % 10 == 0)
			{
				DomainManager.Character.RemoveObsoleteActualBloodParents(context);
			}
		}
		DomainManager.Merchant.RemoveObsoleteMerchantData(context);
		DomainManager.Merchant.SetVillagerRoleMerchantType(context);
		DomainManager.Character.ClearArtisanCostMoneyBehaviorEffect();
		DomainManager.Character.SetDivineFlameRelationTargetLocation(context, Location.Invalid);
		DomainManager.Character.SetDivineFlameMoralityTargetLocation(context, Location.Invalid, isGood: true);
		DomainManager.Character.SetDivineFlameMoralityTargetLocation(context, Location.Invalid, isGood: false);
		WorkerThreadManager.RunPostAction(RemoveWorldItemsToBeRemoved);
		RemoveWorldItemsToBeRemoved(context);
	}

	private static void RemoveWorldItemsToBeRemoved(DataContext context)
	{
		List<ItemKey> items = context.AdvanceMonthRelatedData.WorldItemsToBeRemoved;
		DomainManager.Item.RemoveItems(context, items);
		items.Clear();
	}

	private void PreAdvanceMonth_Building(DataContext context)
	{
		if (DomainManager.World.GetWorldFunctionsStatus(10))
		{
			DomainManager.Building.UpdateTaiwuBuildingAutoOperation(context);
			DomainManager.Building.SerialUpdate(context);
			DomainManager.Building.UpdateResourceBlockEffectsOnAdvanceMonth(context);
			DomainManager.Extra.FeastAdvanceMonth(context);
			DomainManager.Extra.UpdateResourceBlockBuildingCoreProducing(context);
		}
	}

	private void CheckWorldGameVersion()
	{
		DomainManager.World.UpdateCurrWorldGameVersion();
		GameVersionInfo gameVersionInfo = GetWorldVersionInfo();
		if (gameVersionInfo != null)
		{
			if (gameVersionInfo.TimestampCreating != 0)
			{
				Logger.Info($"WorldCreatingTime: {DateTime.MinValue.AddTicks(gameVersionInfo.TimestampCreating).ToLocalTime():yyyy-MM-dd [HH:mm]}");
			}
			if (!string.IsNullOrEmpty(gameVersionInfo.GameVersionCreating))
			{
				Logger.Info("GameVersionCreating: " + gameVersionInfo.GameVersionCreating);
			}
			if (!string.IsNullOrEmpty(gameVersionInfo.GameVersionLastSaving))
			{
				Logger.Info("GameVersionLastSaving: " + gameVersionInfo.GameVersionLastSaving);
			}
		}
	}

	public void InitializeWorldVersionInfo(DataContext context)
	{
		GameVersionInfo gameVersionInfo = GetWorldVersionInfo() ?? new GameVersionInfo();
		gameVersionInfo.TimestampCreating = DateTime.UtcNow.Ticks;
		gameVersionInfo.TimestampLastSaving = DateTime.UtcNow.Ticks;
		gameVersionInfo.GameVersionCreating = DomainManager.Global.GetGameVersion();
		gameVersionInfo.GameVersionLastSaving = DomainManager.Global.GetGameVersion();
		gameVersionInfo.GameBuildDateCreating = DomainManager.Global.GetGameBuildDate();
		gameVersionInfo.GameBuildDateLastSaving = DomainManager.Global.GetGameBuildDate();
		SetWorldVersionInfo(gameVersionInfo, context);
		DomainManager.World.UpdateCurrWorldGameVersion();
	}

	public void UpdateSavingWorldVersionInfo(DataContext context)
	{
		GameVersionInfo gameVersionInfo = GetWorldVersionInfo() ?? new GameVersionInfo();
		gameVersionInfo.TimestampLastSaving = DateTime.UtcNow.Ticks;
		gameVersionInfo.GameVersionLastSaving = DomainManager.Global.GetGameVersion();
		gameVersionInfo.GameBuildDateLastSaving = DomainManager.Global.GetGameBuildDate();
		SetWorldVersionInfo(gameVersionInfo, context);
		DomainManager.World.UpdateCurrWorldGameVersion();
	}

	public List<int> GetHintsByTiming(int timing)
	{
		cachedResult.Clear();
		switch (timing)
		{
		case 0:
			if (CheckFunctionUnlockHintAndNotTriggered(0))
			{
				cachedResult.Add(0);
			}
			if (CheckFunctionUnlockHintAndNotTriggered(1))
			{
				cachedResult.Add(1);
			}
			if (CheckFunctionUnlockHintAndNotTriggered(2))
			{
				cachedResult.Add(2);
			}
			return cachedResult;
		case 1:
			if (CheckFunctionUnlockHintAndNotTriggered(20))
			{
				cachedResult.Add(20);
			}
			if (CheckFunctionUnlockHintAndNotTriggered(21))
			{
				cachedResult.Add(21);
			}
			return cachedResult;
		case 2:
			if (CheckFunctionUnlockHintAndNotTriggered(3))
			{
				cachedResult.Add(3);
			}
			return cachedResult;
		case 3:
			if (CheckFunctionUnlockHintAndNotTriggered(4))
			{
				cachedResult.Add(4);
			}
			return cachedResult;
		case 4:
			if (CheckFunctionUnlockHintAndNotTriggered(5))
			{
				cachedResult.Add(5);
			}
			return cachedResult;
		case 5:
			if (CheckFunctionUnlockHintAndNotTriggered(6))
			{
				cachedResult.Add(6);
			}
			return cachedResult;
		case 6:
			if (CheckFunctionUnlockHintAndNotTriggered(7))
			{
				cachedResult.Add(7);
			}
			return cachedResult;
		case 7:
			if (CheckFunctionUnlockHintAndNotTriggered(8))
			{
				cachedResult.Add(8);
			}
			return cachedResult;
		case 17:
			if (CheckFunctionUnlockHintAndNotTriggered(9))
			{
				cachedResult.Add(9);
			}
			if (CheckFunctionUnlockHintAndNotTriggered(10))
			{
				cachedResult.Add(10);
			}
			if (CheckFunctionUnlockHintAndNotTriggered(19))
			{
				cachedResult.Add(19);
			}
			return cachedResult;
		case 8:
			return cachedResult;
		case 9:
			if (CheckFunctionUnlockHintAndNotTriggered(11))
			{
				cachedResult.Add(11);
			}
			if (CheckFunctionUnlockHintAndNotTriggered(12))
			{
				cachedResult.Add(12);
			}
			return cachedResult;
		case 10:
			if (CheckFunctionUnlockHintAndNotTriggered(13))
			{
				cachedResult.Add(13);
			}
			return cachedResult;
		case 11:
			if (CheckFunctionUnlockHintAndNotTriggered(14))
			{
				cachedResult.Add(14);
			}
			return cachedResult;
		case 12:
			cachedResult.Add(15);
			cachedResult.Add(16);
			return cachedResult;
		case 14:
			if (CheckFunctionUnlockHintAndNotTriggered(22))
			{
				cachedResult.Add(22);
			}
			return cachedResult;
		case 15:
			if (CheckFunctionUnlockHintAndNotTriggered(23))
			{
				cachedResult.Add(23);
			}
			return cachedResult;
		case 16:
			if (CheckFunctionUnlockHintAndNotTriggered(24))
			{
				cachedResult.Add(24);
			}
			return cachedResult;
		case 13:
			if (CheckFunctionUnlockHintAndNotTriggered(17))
			{
				cachedResult.Add(17);
			}
			if (CheckFunctionUnlockHintAndNotTriggered(18))
			{
				cachedResult.Add(18);
			}
			return cachedResult;
		default:
			return cachedResult;
		}
	}

	public void CheckAndNotifyFunctionUnlock(int templateId)
	{
		if (CheckFunctionUnlockHintAndNotTriggered(templateId))
		{
			NotifyFunctionUnlock(templateId);
		}
	}

	public bool CheckFunctionUnlockHintAndNotTriggered(int templateId)
	{
		if (_newfeatureTriggered.Contains(templateId))
		{
			return false;
		}
		switch (templateId)
		{
		case 22:
			if (!GetWorldFunctionsStatus(21))
			{
				return false;
			}
			break;
		case 3:
			if (!GetWorldFunctionsStatus(5))
			{
				return false;
			}
			break;
		case 9:
			if (!GetWorldFunctionsStatus(1))
			{
				return false;
			}
			break;
		case 11:
		case 12:
			if (!GetWorldFunctionsStatus(10))
			{
				return false;
			}
			break;
		case 15:
			if (!GetWorldFunctionsStatus(11))
			{
				return false;
			}
			break;
		case 16:
			if (!GetWorldFunctionsStatus(4))
			{
				return false;
			}
			break;
		case 17:
			if (!GetWorldFunctionsStatus(15))
			{
				return false;
			}
			break;
		case 18:
			return true;
		case 19:
			return true;
		case 20:
			if (!GetWorldFunctionsStatus(23))
			{
				return false;
			}
			foreach (BuildingBlockData block2 in DomainManager.Building.GetBuildingBlocksAtLocation(DomainManager.Organization.GetSettlementByOrgTemplateId(16).GetLocation()))
			{
				if (block2.TemplateId == 51 && block2.CanUse())
				{
					return true;
				}
			}
			return false;
		case 21:
		{
			if (!GetWorldFunctionsStatus(12))
			{
				return false;
			}
			Location location = DomainManager.Organization.GetSettlementByOrgTemplateId(16).GetLocation();
			IEnumerable<BuildingBlockData> blocks = DomainManager.Building.GetBuildingBlocksAtLocation(location);
			foreach (BuildingBlockData block in blocks)
			{
				if (block.TemplateId == 50 && block.CanUse())
				{
					return true;
				}
			}
			return false;
		}
		case 23:
			if (!GetWorldFunctionsStatus(24))
			{
				return false;
			}
			break;
		case 24:
			if (!GetWorldFunctionsStatus(25))
			{
				return false;
			}
			break;
		case 2:
			if (!CheckSkillBreakPlateNeedFeatureHint())
			{
				return false;
			}
			break;
		}
		return true;
	}

	public void CheckFunctionUnlockHints(List<int> templateIds)
	{
		if (templateIds == null)
		{
			return;
		}
		for (int i = 0; i < templateIds.Count; i++)
		{
			if (!CheckFunctionUnlockHintAndNotTriggered(templateIds[i]))
			{
				templateIds.RemoveAt(i);
				i--;
			}
		}
	}

	public void NotifyFunctionUnlock(int templateId)
	{
		_newfeatureTriggered.Add(templateId);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.NewFeatureUnlock, templateId);
	}

	public void NotifyFunctionUnlock(List<int> templateIds)
	{
		if (templateIds == null || templateIds.Count == 0)
		{
			return;
		}
		foreach (int item in templateIds)
		{
			_newfeatureTriggered.Add(item);
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.NewFeatureUnlock, item);
		}
	}

	private bool CheckSkillBreakPlateNeedFeatureHint()
	{
		bool flag = false;
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> charCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(DomainManager.Taiwu.GetTaiwuCharId());
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in charCombatSkills)
		{
			item.Deconstruct(out var key, out var value);
			short skillTemplateId = key;
			GameData.Domains.CombatSkill.CombatSkill skill = value;
			ushort activationState = skill.GetActivationState();
			if (skill.CanBreakout())
			{
				flag = true;
				break;
			}
		}
		return flag;
	}

	[DomainMethod]
	public void GmCmd_SetWorldFunctionUnlockHint(int templateId, bool trigger)
	{
		if (trigger)
		{
			CheckAndNotifyFunctionUnlock(templateId);
		}
		else if (_newfeatureTriggered.Contains(templateId))
		{
			_newfeatureTriggered.Remove(templateId);
		}
	}

	public WorldDomain()
		: base(59)
	{
		_worldId = 0u;
		_xiangshuProgress = 0;
		_xiangshuAvatarTaskStatuses = new XiangshuAvatarTaskStatus[9];
		_xiangshuAvatarTasksInOrder = new sbyte[9];
		_mainStoryLineProgress = 0;
		_beatRanChenZi = false;
		_worldFunctionsStatuses = 0uL;
		_customTexts = new Dictionary<int, string>(0);
		_nextCustomTextId = 0;
		_instantNotifications = new InstantNotificationCollection(1024);
		_onHandingMonthlyEventBlock = false;
		_lastMonthlyNotifications = new MonthlyNotificationCollection(0);
		_worldPopulationType = 0;
		_characterLifespanType = 0;
		_combatDifficulty = 0;
		_hereticsAmountType = 0;
		_bossInvasionSpeedType = 0;
		_worldResourceAmountType = 0;
		_allowRandomTaiwuHeir = false;
		_restrictOptionsBehaviorType = false;
		_taiwuVillageStateTemplateId = 0;
		_taiwuVillageLandFormType = 0;
		_hideTaiwuOriginalSurname = false;
		_allowExecute = false;
		_archiveFilesBackupInterval = 0;
		_worldStandardPopulation = 0;
		_currDate = 0;
		_daysInCurrMonth = 0;
		_advancingMonthState = 0;
		_currTaskList = new List<TaskData>();
		_sortedTaskList = new List<TaskDisplayData>();
		_worldStateData = default(WorldStateData);
		_archiveFilesBackupCount = 0;
		_sortedMonthlyNotificationSortingGroups = new List<int>();
		_monthlyEventLastTriggerDates = new Dictionary<short, int>(0);
		_professionUpgrade = 0;
		_canResetWorldSettings = false;
		_favorabilityChange = 0;
		_enemyPracticeLevel = 0;
		_loopingDifficulty = 0;
		_breakoutDifficulty = 0;
		_readingDifficulty = 0;
		_lootYield = 0;
		_bigEvents = new Dictionary<short, BigEventRecord>(0);
		_stateWeathers = new Dictionary<sbyte, sbyte>(0);
		_extraTriggeredTasks = new List<TaskData>();
		_taskSortingOrder = new List<int>();
		_pinnedOnTopTasks = new List<int>();
		_worldVersionInfo = new GameVersionInfo();
		_newfeatureTriggered = new List<int>();
		_taskFinishedDateList = new List<(int, int)>();
		_challengeModeData = new ChallengeModeData();
		_exorcismEnabled = false;
		_monthNotifies = new List<MonthNotify>();
		_gameStatSaved = new Dictionary<short, GameStatRecordWrapper>(0);
		_triggeredGuidingChapterDictionary = new Dictionary<short, sbyte>(0);
		_permanentMonthNotifies = new Dictionary<int, PermanentMonthNotify>(0);
		_areaStoryWeathers = new Dictionary<short, sbyte>(0);
		_waitForDecideChallengeModeIds = new List<int>();
		OnInitializedDomainData();
	}

	public uint GetWorldId()
	{
		return _worldId;
	}

	private void SetWorldId(uint value, DataContext context)
	{
		_worldId = value;
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	public sbyte GetXiangshuProgress()
	{
		Thread.MemoryBarrier();
		if (BaseGameDataDomain.IsCached(DataStates, 1))
		{
			return _xiangshuProgress;
		}
		sbyte value = CalcXiangshuProgress();
		bool lockTaken = false;
		try
		{
			_spinLockXiangshuProgress.Enter(ref lockTaken);
			_xiangshuProgress = value;
			BaseGameDataDomain.SetCached(DataStates, 1);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLockXiangshuProgress.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _xiangshuProgress;
	}

	public XiangshuAvatarTaskStatus GetElement_XiangshuAvatarTaskStatuses(int index)
	{
		return _xiangshuAvatarTaskStatuses[index];
	}

	public void SetElement_XiangshuAvatarTaskStatuses(int index, XiangshuAvatarTaskStatus value, DataContext context)
	{
		_xiangshuAvatarTaskStatuses[index] = value;
		SetModifiedAndInvalidateInfluencedCache(index, _dataStatesXiangshuAvatarTaskStatuses, CacheInfluencesXiangshuAvatarTaskStatuses, context);
	}

	public sbyte[] GetXiangshuAvatarTasksInOrder()
	{
		return _xiangshuAvatarTasksInOrder;
	}

	public void SetXiangshuAvatarTasksInOrder(sbyte[] value, DataContext context)
	{
		_xiangshuAvatarTasksInOrder = value;
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	public short GetMainStoryLineProgress()
	{
		return _mainStoryLineProgress;
	}

	public void SetMainStoryLineProgress(short value, DataContext context)
	{
		_mainStoryLineProgress = value;
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	public bool GetBeatRanChenZi()
	{
		return _beatRanChenZi;
	}

	public void SetBeatRanChenZi(bool value, DataContext context)
	{
		_beatRanChenZi = value;
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	public ulong GetWorldFunctionsStatuses()
	{
		return _worldFunctionsStatuses;
	}

	public void SetWorldFunctionsStatuses(ulong value, DataContext context)
	{
		_worldFunctionsStatuses = value;
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	public string GetElement_CustomTexts(int elementId)
	{
		return _customTexts[elementId];
	}

	public bool TryGetElement_CustomTexts(int elementId, out string value)
	{
		return _customTexts.TryGetValue(elementId, out value);
	}

	private void AddElement_CustomTexts(int elementId, string value, DataContext context)
	{
		_customTexts.Add(elementId, value);
		_modificationsCustomTexts.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void SetElement_CustomTexts(int elementId, string value, DataContext context)
	{
		_customTexts[elementId] = value;
		_modificationsCustomTexts.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_CustomTexts(int elementId, DataContext context)
	{
		_customTexts.Remove(elementId);
		_modificationsCustomTexts.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void ClearCustomTexts(DataContext context)
	{
		_customTexts.Clear();
		_modificationsCustomTexts.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private int GetNextCustomTextId()
	{
		return _nextCustomTextId;
	}

	private void SetNextCustomTextId(int value, DataContext context)
	{
		_nextCustomTextId = value;
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	public InstantNotificationCollection GetInstantNotifications()
	{
		return _instantNotifications;
	}

	private void CommitInsert_InstantNotifications(DataContext context, int offset, int size)
	{
		_modificationsInstantNotifications.RecordInserting(offset, size);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void CommitWrite_InstantNotifications(DataContext context, int offset, int size)
	{
		_modificationsInstantNotifications.RecordWriting(offset, size);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void CommitRemove_InstantNotifications(DataContext context, int offset, int size)
	{
		_modificationsInstantNotifications.RecordRemoving(offset, size);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void CommitSetMetadata_InstantNotifications(DataContext context)
	{
		_modificationsInstantNotifications.RecordSettingMetadata();
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	public bool GetOnHandingMonthlyEventBlock()
	{
		return _onHandingMonthlyEventBlock;
	}

	public void SetOnHandingMonthlyEventBlock(bool value, DataContext context)
	{
		_onHandingMonthlyEventBlock = value;
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _lastMonthlyNotifications is no longer in use.")]
	public MonthlyNotificationCollection GetLastMonthlyNotifications()
	{
		return _lastMonthlyNotifications;
	}

	[Obsolete("DomainData _lastMonthlyNotifications is no longer in use.")]
	private void SetLastMonthlyNotifications(MonthlyNotificationCollection value, DataContext context)
	{
		_lastMonthlyNotifications = value;
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	public byte GetWorldPopulationType()
	{
		return _worldPopulationType;
	}

	private void SetWorldPopulationType(byte value, DataContext context)
	{
		_worldPopulationType = value;
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	public byte GetCharacterLifespanType()
	{
		return _characterLifespanType;
	}

	public void SetCharacterLifespanType(byte value, DataContext context)
	{
		_characterLifespanType = value;
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	public byte GetCombatDifficulty()
	{
		return _combatDifficulty;
	}

	public void SetCombatDifficulty(byte value, DataContext context)
	{
		_combatDifficulty = value;
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	public byte GetHereticsAmountType()
	{
		return _hereticsAmountType;
	}

	public void SetHereticsAmountType(byte value, DataContext context)
	{
		_hereticsAmountType = value;
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	public byte GetBossInvasionSpeedType()
	{
		return _bossInvasionSpeedType;
	}

	public void SetBossInvasionSpeedType(byte value, DataContext context)
	{
		_bossInvasionSpeedType = value;
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	public byte GetWorldResourceAmountType()
	{
		return _worldResourceAmountType;
	}

	public void SetWorldResourceAmountType(byte value, DataContext context)
	{
		_worldResourceAmountType = value;
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	public bool GetAllowRandomTaiwuHeir()
	{
		return _allowRandomTaiwuHeir;
	}

	public void SetAllowRandomTaiwuHeir(bool value, DataContext context)
	{
		_allowRandomTaiwuHeir = value;
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
	}

	public bool GetRestrictOptionsBehaviorType()
	{
		return _restrictOptionsBehaviorType;
	}

	public void SetRestrictOptionsBehaviorType(bool value, DataContext context)
	{
		_restrictOptionsBehaviorType = value;
		SetModifiedAndInvalidateInfluencedCache(19, DataStates, CacheInfluences, context);
	}

	public sbyte GetTaiwuVillageStateTemplateId()
	{
		return _taiwuVillageStateTemplateId;
	}

	public void SetTaiwuVillageStateTemplateId(sbyte value, DataContext context)
	{
		_taiwuVillageStateTemplateId = value;
		SetModifiedAndInvalidateInfluencedCache(20, DataStates, CacheInfluences, context);
	}

	public sbyte GetTaiwuVillageLandFormType()
	{
		return _taiwuVillageLandFormType;
	}

	public void SetTaiwuVillageLandFormType(sbyte value, DataContext context)
	{
		_taiwuVillageLandFormType = value;
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	public bool GetHideTaiwuOriginalSurname()
	{
		return _hideTaiwuOriginalSurname;
	}

	public void SetHideTaiwuOriginalSurname(bool value, DataContext context)
	{
		_hideTaiwuOriginalSurname = value;
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	public bool GetAllowExecute()
	{
		return _allowExecute;
	}

	public void SetAllowExecute(bool value, DataContext context)
	{
		_allowExecute = value;
		SetModifiedAndInvalidateInfluencedCache(23, DataStates, CacheInfluences, context);
	}

	public sbyte GetArchiveFilesBackupInterval()
	{
		return _archiveFilesBackupInterval;
	}

	public void SetArchiveFilesBackupInterval(sbyte value, DataContext context)
	{
		_archiveFilesBackupInterval = value;
		SetModifiedAndInvalidateInfluencedCache(24, DataStates, CacheInfluences, context);
	}

	public int GetWorldStandardPopulation()
	{
		return _worldStandardPopulation;
	}

	private void SetWorldStandardPopulation(int value, DataContext context)
	{
		_worldStandardPopulation = value;
		SetModifiedAndInvalidateInfluencedCache(25, DataStates, CacheInfluences, context);
	}

	public int GetCurrDate()
	{
		return _currDate;
	}

	private void SetCurrDate(int value, DataContext context)
	{
		_currDate = value;
		SetModifiedAndInvalidateInfluencedCache(26, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _daysInCurrMonth is no longer in use.")]
	public sbyte GetDaysInCurrMonth()
	{
		return _daysInCurrMonth;
	}

	[Obsolete("DomainData _daysInCurrMonth is no longer in use.")]
	private void SetDaysInCurrMonth(sbyte value, DataContext context)
	{
		_daysInCurrMonth = value;
		SetModifiedAndInvalidateInfluencedCache(27, DataStates, CacheInfluences, context);
	}

	public sbyte GetAdvancingMonthState()
	{
		return _advancingMonthState;
	}

	private void SetAdvancingMonthState(sbyte value, DataContext context)
	{
		_advancingMonthState = value;
		SetModifiedAndInvalidateInfluencedCache(28, DataStates, CacheInfluences, context);
	}

	public List<TaskData> GetCurrTaskList()
	{
		Thread.MemoryBarrier();
		if (BaseGameDataDomain.IsCached(DataStates, 29))
		{
			return _currTaskList;
		}
		List<TaskData> value = new List<TaskData>();
		CalcCurrTaskList(value);
		bool lockTaken = false;
		try
		{
			_spinLockCurrTaskList.Enter(ref lockTaken);
			_currTaskList.Assign(value);
			BaseGameDataDomain.SetCached(DataStates, 29);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLockCurrTaskList.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _currTaskList;
	}

	public List<TaskDisplayData> GetSortedTaskList()
	{
		Thread.MemoryBarrier();
		if (BaseGameDataDomain.IsCached(DataStates, 30))
		{
			return _sortedTaskList;
		}
		List<TaskDisplayData> value = new List<TaskDisplayData>();
		CalcSortedTaskList(value);
		bool lockTaken = false;
		try
		{
			_spinLockSortedTaskList.Enter(ref lockTaken);
			_sortedTaskList.Assign(value);
			BaseGameDataDomain.SetCached(DataStates, 30);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLockSortedTaskList.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _sortedTaskList;
	}

	public ref WorldStateData GetWorldStateData()
	{
		Thread.MemoryBarrier();
		if (BaseGameDataDomain.IsCached(DataStates, 31))
		{
			return ref _worldStateData;
		}
		WorldStateData value = CalcWorldStateData();
		bool lockTaken = false;
		try
		{
			_spinLockWorldStateData.Enter(ref lockTaken);
			_worldStateData = value;
			BaseGameDataDomain.SetCached(DataStates, 31);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLockWorldStateData.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return ref _worldStateData;
	}

	public sbyte GetArchiveFilesBackupCount()
	{
		return _archiveFilesBackupCount;
	}

	public void SetArchiveFilesBackupCount(sbyte value, DataContext context)
	{
		_archiveFilesBackupCount = value;
		SetModifiedAndInvalidateInfluencedCache(32, DataStates, CacheInfluences, context);
	}

	public List<int> GetSortedMonthlyNotificationSortingGroups()
	{
		return _sortedMonthlyNotificationSortingGroups;
	}

	public void SetSortedMonthlyNotificationSortingGroups(List<int> value, DataContext context)
	{
		_sortedMonthlyNotificationSortingGroups = value;
		SetModifiedAndInvalidateInfluencedCache(33, DataStates, CacheInfluences, context);
	}

	private int GetElement_MonthlyEventLastTriggerDates(short elementId)
	{
		return _monthlyEventLastTriggerDates[elementId];
	}

	private bool TryGetElement_MonthlyEventLastTriggerDates(short elementId, out int value)
	{
		return _monthlyEventLastTriggerDates.TryGetValue(elementId, out value);
	}

	private void AddElement_MonthlyEventLastTriggerDates(short elementId, int value, DataContext context)
	{
		_monthlyEventLastTriggerDates.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(34, DataStates, CacheInfluences, context);
	}

	private void SetElement_MonthlyEventLastTriggerDates(short elementId, int value, DataContext context)
	{
		_monthlyEventLastTriggerDates[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(34, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_MonthlyEventLastTriggerDates(short elementId, DataContext context)
	{
		_monthlyEventLastTriggerDates.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(34, DataStates, CacheInfluences, context);
	}

	private void ClearMonthlyEventLastTriggerDates(DataContext context)
	{
		_monthlyEventLastTriggerDates.Clear();
		SetModifiedAndInvalidateInfluencedCache(34, DataStates, CacheInfluences, context);
	}

	public byte GetProfessionUpgrade()
	{
		return _professionUpgrade;
	}

	public void SetProfessionUpgrade(byte value, DataContext context)
	{
		_professionUpgrade = value;
		SetModifiedAndInvalidateInfluencedCache(35, DataStates, CacheInfluences, context);
	}

	public bool GetCanResetWorldSettings()
	{
		return _canResetWorldSettings;
	}

	public void SetCanResetWorldSettings(bool value, DataContext context)
	{
		_canResetWorldSettings = value;
		SetModifiedAndInvalidateInfluencedCache(36, DataStates, CacheInfluences, context);
	}

	public byte GetFavorabilityChange()
	{
		return _favorabilityChange;
	}

	public void SetFavorabilityChange(byte value, DataContext context)
	{
		_favorabilityChange = value;
		SetModifiedAndInvalidateInfluencedCache(37, DataStates, CacheInfluences, context);
	}

	public byte GetEnemyPracticeLevel()
	{
		return _enemyPracticeLevel;
	}

	public void SetEnemyPracticeLevel(byte value, DataContext context)
	{
		_enemyPracticeLevel = value;
		SetModifiedAndInvalidateInfluencedCache(38, DataStates, CacheInfluences, context);
	}

	public byte GetLoopingDifficulty()
	{
		return _loopingDifficulty;
	}

	public void SetLoopingDifficulty(byte value, DataContext context)
	{
		_loopingDifficulty = value;
		SetModifiedAndInvalidateInfluencedCache(39, DataStates, CacheInfluences, context);
	}

	public byte GetBreakoutDifficulty()
	{
		return _breakoutDifficulty;
	}

	public void SetBreakoutDifficulty(byte value, DataContext context)
	{
		_breakoutDifficulty = value;
		SetModifiedAndInvalidateInfluencedCache(40, DataStates, CacheInfluences, context);
	}

	public byte GetReadingDifficulty()
	{
		return _readingDifficulty;
	}

	public void SetReadingDifficulty(byte value, DataContext context)
	{
		_readingDifficulty = value;
		SetModifiedAndInvalidateInfluencedCache(41, DataStates, CacheInfluences, context);
	}

	public short GetLootYield()
	{
		return _lootYield;
	}

	public void SetLootYield(short value, DataContext context)
	{
		_lootYield = value;
		SetModifiedAndInvalidateInfluencedCache(42, DataStates, CacheInfluences, context);
	}

	public BigEventRecord GetElement_BigEvents(short elementId)
	{
		return _bigEvents[elementId];
	}

	public bool TryGetElement_BigEvents(short elementId, out BigEventRecord value)
	{
		return _bigEvents.TryGetValue(elementId, out value);
	}

	private void AddElement_BigEvents(short elementId, BigEventRecord value, DataContext context)
	{
		_bigEvents.Add(elementId, value);
		_modificationsBigEvents.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(43, DataStates, CacheInfluences, context);
	}

	private void SetElement_BigEvents(short elementId, BigEventRecord value, DataContext context)
	{
		_bigEvents[elementId] = value;
		_modificationsBigEvents.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(43, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_BigEvents(short elementId, DataContext context)
	{
		_bigEvents.Remove(elementId);
		_modificationsBigEvents.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(43, DataStates, CacheInfluences, context);
	}

	private void ClearBigEvents(DataContext context)
	{
		_bigEvents.Clear();
		_modificationsBigEvents.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(43, DataStates, CacheInfluences, context);
	}

	public sbyte GetElement_StateWeathers(sbyte elementId)
	{
		return _stateWeathers[elementId];
	}

	public bool TryGetElement_StateWeathers(sbyte elementId, out sbyte value)
	{
		return _stateWeathers.TryGetValue(elementId, out value);
	}

	private void AddElement_StateWeathers(sbyte elementId, sbyte value, DataContext context)
	{
		_stateWeathers.Add(elementId, value);
		_modificationsStateWeathers.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(44, DataStates, CacheInfluences, context);
	}

	private void SetElement_StateWeathers(sbyte elementId, sbyte value, DataContext context)
	{
		_stateWeathers[elementId] = value;
		_modificationsStateWeathers.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(44, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_StateWeathers(sbyte elementId, DataContext context)
	{
		_stateWeathers.Remove(elementId);
		_modificationsStateWeathers.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(44, DataStates, CacheInfluences, context);
	}

	private void ClearStateWeathers(DataContext context)
	{
		_stateWeathers.Clear();
		_modificationsStateWeathers.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(44, DataStates, CacheInfluences, context);
	}

	public List<TaskData> GetExtraTriggeredTasks()
	{
		return _extraTriggeredTasks;
	}

	private void SetExtraTriggeredTasks(List<TaskData> value, DataContext context)
	{
		_extraTriggeredTasks = value;
		SetModifiedAndInvalidateInfluencedCache(45, DataStates, CacheInfluences, context);
	}

	public List<int> GetTaskSortingOrder()
	{
		return _taskSortingOrder;
	}

	private void SetTaskSortingOrder(List<int> value, DataContext context)
	{
		_taskSortingOrder = value;
		SetModifiedAndInvalidateInfluencedCache(46, DataStates, CacheInfluences, context);
	}

	public List<int> GetPinnedOnTopTasks()
	{
		return _pinnedOnTopTasks;
	}

	private void SetPinnedOnTopTasks(List<int> value, DataContext context)
	{
		_pinnedOnTopTasks = value;
		SetModifiedAndInvalidateInfluencedCache(47, DataStates, CacheInfluences, context);
	}

	public GameVersionInfo GetWorldVersionInfo()
	{
		return _worldVersionInfo;
	}

	private void SetWorldVersionInfo(GameVersionInfo value, DataContext context)
	{
		_worldVersionInfo = value;
		SetModifiedAndInvalidateInfluencedCache(48, DataStates, CacheInfluences, context);
	}

	public List<int> GetNewfeatureTriggered()
	{
		return _newfeatureTriggered;
	}

	public void SetNewfeatureTriggered(List<int> value, DataContext context)
	{
		_newfeatureTriggered = value;
		SetModifiedAndInvalidateInfluencedCache(49, DataStates, CacheInfluences, context);
	}

	public List<(int, int)> GetTaskFinishedDateList()
	{
		return _taskFinishedDateList;
	}

	private void SetTaskFinishedDateList(List<(int, int)> value, DataContext context)
	{
		_taskFinishedDateList = value;
		SetModifiedAndInvalidateInfluencedCache(50, DataStates, CacheInfluences, context);
	}

	public ChallengeModeData GetChallengeModeData()
	{
		return _challengeModeData;
	}

	private void SetChallengeModeData(ChallengeModeData value, DataContext context)
	{
		_challengeModeData = value;
		SetModifiedAndInvalidateInfluencedCache(51, DataStates, CacheInfluences, context);
	}

	public bool GetExorcismEnabled()
	{
		return _exorcismEnabled;
	}

	public void SetExorcismEnabled(bool value, DataContext context)
	{
		_exorcismEnabled = value;
		SetModifiedAndInvalidateInfluencedCache(52, DataStates, CacheInfluences, context);
	}

	public List<MonthNotify> GetMonthNotifies()
	{
		return _monthNotifies;
	}

	public void SetMonthNotifies(List<MonthNotify> value, DataContext context)
	{
		_monthNotifies = value;
		SetModifiedAndInvalidateInfluencedCache(53, DataStates, CacheInfluences, context);
	}

	public GameStatRecordWrapper GetElement_GameStatSaved(short elementId)
	{
		return _gameStatSaved[elementId];
	}

	public bool TryGetElement_GameStatSaved(short elementId, out GameStatRecordWrapper value)
	{
		return _gameStatSaved.TryGetValue(elementId, out value);
	}

	private void AddElement_GameStatSaved(short elementId, GameStatRecordWrapper value, DataContext context)
	{
		_gameStatSaved.Add(elementId, value);
		_modificationsGameStatSaved.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(54, DataStates, CacheInfluences, context);
	}

	private void SetElement_GameStatSaved(short elementId, GameStatRecordWrapper value, DataContext context)
	{
		_gameStatSaved[elementId] = value;
		_modificationsGameStatSaved.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(54, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_GameStatSaved(short elementId, DataContext context)
	{
		_gameStatSaved.Remove(elementId);
		_modificationsGameStatSaved.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(54, DataStates, CacheInfluences, context);
	}

	private void ClearGameStatSaved(DataContext context)
	{
		_gameStatSaved.Clear();
		_modificationsGameStatSaved.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(54, DataStates, CacheInfluences, context);
	}

	public sbyte GetElement_TriggeredGuidingChapterDictionary(short elementId)
	{
		return _triggeredGuidingChapterDictionary[elementId];
	}

	public bool TryGetElement_TriggeredGuidingChapterDictionary(short elementId, out sbyte value)
	{
		return _triggeredGuidingChapterDictionary.TryGetValue(elementId, out value);
	}

	private void AddElement_TriggeredGuidingChapterDictionary(short elementId, sbyte value, DataContext context)
	{
		_triggeredGuidingChapterDictionary.Add(elementId, value);
		_modificationsTriggeredGuidingChapterDictionary.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(55, DataStates, CacheInfluences, context);
	}

	private void SetElement_TriggeredGuidingChapterDictionary(short elementId, sbyte value, DataContext context)
	{
		_triggeredGuidingChapterDictionary[elementId] = value;
		_modificationsTriggeredGuidingChapterDictionary.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(55, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_TriggeredGuidingChapterDictionary(short elementId, DataContext context)
	{
		_triggeredGuidingChapterDictionary.Remove(elementId);
		_modificationsTriggeredGuidingChapterDictionary.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(55, DataStates, CacheInfluences, context);
	}

	private void ClearTriggeredGuidingChapterDictionary(DataContext context)
	{
		_triggeredGuidingChapterDictionary.Clear();
		_modificationsTriggeredGuidingChapterDictionary.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(55, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _permanentMonthNotifies is no longer in use.")]
	public PermanentMonthNotify GetElement_PermanentMonthNotifies(int elementId)
	{
		return _permanentMonthNotifies[elementId];
	}

	[Obsolete("DomainData _permanentMonthNotifies is no longer in use.")]
	public bool TryGetElement_PermanentMonthNotifies(int elementId, out PermanentMonthNotify value)
	{
		return _permanentMonthNotifies.TryGetValue(elementId, out value);
	}

	[Obsolete("DomainData _permanentMonthNotifies is no longer in use.")]
	private void AddElement_PermanentMonthNotifies(int elementId, PermanentMonthNotify value, DataContext context)
	{
		_permanentMonthNotifies.Add(elementId, value);
		_modificationsPermanentMonthNotifies.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(56, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _permanentMonthNotifies is no longer in use.")]
	private void SetElement_PermanentMonthNotifies(int elementId, PermanentMonthNotify value, DataContext context)
	{
		_permanentMonthNotifies[elementId] = value;
		_modificationsPermanentMonthNotifies.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(56, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _permanentMonthNotifies is no longer in use.")]
	private void RemoveElement_PermanentMonthNotifies(int elementId, DataContext context)
	{
		_permanentMonthNotifies.Remove(elementId);
		_modificationsPermanentMonthNotifies.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(56, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _permanentMonthNotifies is no longer in use.")]
	private void ClearPermanentMonthNotifies(DataContext context)
	{
		_permanentMonthNotifies.Clear();
		_modificationsPermanentMonthNotifies.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(56, DataStates, CacheInfluences, context);
	}

	public sbyte GetElement_AreaStoryWeathers(short elementId)
	{
		return _areaStoryWeathers[elementId];
	}

	public bool TryGetElement_AreaStoryWeathers(short elementId, out sbyte value)
	{
		return _areaStoryWeathers.TryGetValue(elementId, out value);
	}

	private void AddElement_AreaStoryWeathers(short elementId, sbyte value, DataContext context)
	{
		_areaStoryWeathers.Add(elementId, value);
		_modificationsAreaStoryWeathers.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(57, DataStates, CacheInfluences, context);
	}

	private void SetElement_AreaStoryWeathers(short elementId, sbyte value, DataContext context)
	{
		_areaStoryWeathers[elementId] = value;
		_modificationsAreaStoryWeathers.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(57, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_AreaStoryWeathers(short elementId, DataContext context)
	{
		_areaStoryWeathers.Remove(elementId);
		_modificationsAreaStoryWeathers.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(57, DataStates, CacheInfluences, context);
	}

	private void ClearAreaStoryWeathers(DataContext context)
	{
		_areaStoryWeathers.Clear();
		_modificationsAreaStoryWeathers.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(57, DataStates, CacheInfluences, context);
	}

	public List<int> GetWaitForDecideChallengeModeIds()
	{
		return _waitForDecideChallengeModeIds;
	}

	private void SetWaitForDecideChallengeModeIds(List<int> value, DataContext context)
	{
		_waitForDecideChallengeModeIds = value;
		SetModifiedAndInvalidateInfluencedCache(58, DataStates, CacheInfluences, context);
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
		archive.WriteSingleValueUnmanaged((ushort)45);
		archive.WriteDomainDataMeta(0);
		archive.WriteSingleValueUnmanaged(_worldId);
		archive.WriteDomainDataMeta(2);
		archive.WriteElementListCustom(_xiangshuAvatarTaskStatuses);
		archive.WriteDomainDataMeta(3);
		archive.WriteSingleValueUnmanagedArray(_xiangshuAvatarTasksInOrder);
		archive.WriteDomainDataMeta(4);
		archive.WriteSingleValueUnmanaged(_mainStoryLineProgress);
		archive.WriteDomainDataMeta(5);
		archive.WriteSingleValueUnmanaged(_beatRanChenZi);
		archive.WriteDomainDataMeta(6);
		archive.WriteSingleValueUnmanaged(_worldFunctionsStatuses);
		archive.WriteDomainDataMeta(7);
		archive.WriteSingleValueCollectionUnmanagedKeyValue(_customTexts);
		archive.WriteDomainDataMeta(8);
		archive.WriteSingleValueUnmanaged(_nextCustomTextId);
		archive.WriteDomainDataMeta(9);
		archive.WriteBinary(_instantNotifications);
		archive.WriteDomainDataMeta(12);
		archive.WriteSingleValueUnmanaged(_worldPopulationType);
		archive.WriteDomainDataMeta(13);
		archive.WriteSingleValueUnmanaged(_characterLifespanType);
		archive.WriteDomainDataMeta(14);
		archive.WriteSingleValueUnmanaged(_combatDifficulty);
		archive.WriteDomainDataMeta(15);
		archive.WriteSingleValueUnmanaged(_hereticsAmountType);
		archive.WriteDomainDataMeta(16);
		archive.WriteSingleValueUnmanaged(_bossInvasionSpeedType);
		archive.WriteDomainDataMeta(17);
		archive.WriteSingleValueUnmanaged(_worldResourceAmountType);
		archive.WriteDomainDataMeta(18);
		archive.WriteSingleValueUnmanaged(_allowRandomTaiwuHeir);
		archive.WriteDomainDataMeta(19);
		archive.WriteSingleValueUnmanaged(_restrictOptionsBehaviorType);
		archive.WriteDomainDataMeta(20);
		archive.WriteSingleValueUnmanaged(_taiwuVillageStateTemplateId);
		archive.WriteDomainDataMeta(21);
		archive.WriteSingleValueUnmanaged(_taiwuVillageLandFormType);
		archive.WriteDomainDataMeta(25);
		archive.WriteSingleValueUnmanaged(_worldStandardPopulation);
		archive.WriteDomainDataMeta(26);
		archive.WriteSingleValueUnmanaged(_currDate);
		archive.WriteDomainDataMeta(34);
		archive.WriteSingleValueCollectionUnmanagedKeyValue(_monthlyEventLastTriggerDates);
		archive.WriteDomainDataMeta(35);
		archive.WriteSingleValueUnmanaged(_professionUpgrade);
		archive.WriteDomainDataMeta(36);
		archive.WriteSingleValueUnmanaged(_canResetWorldSettings);
		archive.WriteDomainDataMeta(37);
		archive.WriteSingleValueUnmanaged(_favorabilityChange);
		archive.WriteDomainDataMeta(38);
		archive.WriteSingleValueUnmanaged(_enemyPracticeLevel);
		archive.WriteDomainDataMeta(39);
		archive.WriteSingleValueUnmanaged(_loopingDifficulty);
		archive.WriteDomainDataMeta(40);
		archive.WriteSingleValueUnmanaged(_breakoutDifficulty);
		archive.WriteDomainDataMeta(41);
		archive.WriteSingleValueUnmanaged(_readingDifficulty);
		archive.WriteDomainDataMeta(42);
		archive.WriteSingleValueUnmanaged(_lootYield);
		archive.WriteDomainDataMeta(43);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_bigEvents);
		archive.WriteDomainDataMeta(44);
		archive.WriteSingleValueCollectionUnmanagedKeyValue(_stateWeathers);
		archive.WriteDomainDataMeta(45);
		archive.WriteSingleValueCustomList(_extraTriggeredTasks);
		archive.WriteDomainDataMeta(46);
		archive.WriteSingleValueUnmanagedList(_taskSortingOrder);
		archive.WriteDomainDataMeta(47);
		archive.WriteSingleValueUnmanagedList(_pinnedOnTopTasks);
		archive.WriteDomainDataMeta(48);
		archive.WriteSingleValueCustom(_worldVersionInfo);
		archive.WriteDomainDataMeta(49);
		archive.WriteSingleValueUnmanagedList(_newfeatureTriggered);
		archive.WriteDomainDataMeta(50);
		archive.WriteSingleValueUnmanagedList<(int, int)>((IList<(int, int)>)_taskFinishedDateList);
		archive.WriteDomainDataMeta(51);
		archive.WriteSingleValueCustom(_challengeModeData);
		archive.WriteDomainDataMeta(52);
		archive.WriteSingleValueUnmanaged(_exorcismEnabled);
		archive.WriteDomainDataMeta(53);
		archive.WriteSingleValueCustomList(_monthNotifies);
		archive.WriteDomainDataMeta(54);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_gameStatSaved);
		archive.WriteDomainDataMeta(55);
		archive.WriteSingleValueCollectionUnmanagedKeyValue(_triggeredGuidingChapterDictionary);
		archive.WriteDomainDataMeta(57);
		archive.WriteSingleValueCollectionUnmanagedKeyValue(_areaStoryWeathers);
		archive.WriteDomainDataMeta(58);
		archive.WriteSingleValueUnmanagedList(_waitForDecideChallengeModeIds);
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
				archive.ReadSingleValueUnmanaged(ref _worldId);
				break;
			case 2:
				archive.ReadElementListCustom(_xiangshuAvatarTaskStatuses);
				break;
			case 3:
				archive.ReadSingleValueUnmanagedArray(ref _xiangshuAvatarTasksInOrder);
				break;
			case 4:
				archive.ReadSingleValueUnmanaged(ref _mainStoryLineProgress);
				break;
			case 5:
				archive.ReadSingleValueUnmanaged(ref _beatRanChenZi);
				break;
			case 6:
				archive.ReadSingleValueUnmanaged(ref _worldFunctionsStatuses);
				break;
			case 7:
				archive.ReadSingleValueCollectionUnmanagedKeyValue(_customTexts);
				break;
			case 8:
				archive.ReadSingleValueUnmanaged(ref _nextCustomTextId);
				break;
			case 9:
				archive.ReadBinary(_instantNotifications);
				break;
			case 11:
				archive.ReadBinary(ref _lastMonthlyNotifications);
				break;
			case 12:
				archive.ReadSingleValueUnmanaged(ref _worldPopulationType);
				break;
			case 13:
				archive.ReadSingleValueUnmanaged(ref _characterLifespanType);
				break;
			case 14:
				archive.ReadSingleValueUnmanaged(ref _combatDifficulty);
				break;
			case 15:
				archive.ReadSingleValueUnmanaged(ref _hereticsAmountType);
				break;
			case 16:
				archive.ReadSingleValueUnmanaged(ref _bossInvasionSpeedType);
				break;
			case 17:
				archive.ReadSingleValueUnmanaged(ref _worldResourceAmountType);
				break;
			case 18:
				archive.ReadSingleValueUnmanaged(ref _allowRandomTaiwuHeir);
				break;
			case 19:
				archive.ReadSingleValueUnmanaged(ref _restrictOptionsBehaviorType);
				break;
			case 20:
				archive.ReadSingleValueUnmanaged(ref _taiwuVillageStateTemplateId);
				break;
			case 21:
				archive.ReadSingleValueUnmanaged(ref _taiwuVillageLandFormType);
				break;
			case 25:
				archive.ReadSingleValueUnmanaged(ref _worldStandardPopulation);
				break;
			case 26:
				archive.ReadSingleValueUnmanaged(ref _currDate);
				break;
			case 27:
				archive.ReadSingleValueUnmanaged(ref _daysInCurrMonth);
				break;
			case 34:
				archive.ReadSingleValueCollectionUnmanagedKeyValue(_monthlyEventLastTriggerDates);
				break;
			case 35:
				archive.ReadSingleValueUnmanaged(ref _professionUpgrade);
				break;
			case 36:
				archive.ReadSingleValueUnmanaged(ref _canResetWorldSettings);
				break;
			case 37:
				archive.ReadSingleValueUnmanaged(ref _favorabilityChange);
				break;
			case 38:
				archive.ReadSingleValueUnmanaged(ref _enemyPracticeLevel);
				break;
			case 39:
				archive.ReadSingleValueUnmanaged(ref _loopingDifficulty);
				break;
			case 40:
				archive.ReadSingleValueUnmanaged(ref _breakoutDifficulty);
				break;
			case 41:
				archive.ReadSingleValueUnmanaged(ref _readingDifficulty);
				break;
			case 42:
				archive.ReadSingleValueUnmanaged(ref _lootYield);
				break;
			case 43:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_bigEvents);
				break;
			case 44:
				archive.ReadSingleValueCollectionUnmanagedKeyValue(_stateWeathers);
				break;
			case 45:
				archive.ReadSingleValueCustomList(ref _extraTriggeredTasks);
				break;
			case 46:
				archive.ReadSingleValueUnmanagedList(ref _taskSortingOrder);
				break;
			case 47:
				archive.ReadSingleValueUnmanagedList(ref _pinnedOnTopTasks);
				break;
			case 48:
				archive.ReadSingleValueCustom(ref _worldVersionInfo);
				break;
			case 49:
				archive.ReadSingleValueUnmanagedList(ref _newfeatureTriggered);
				break;
			case 50:
				archive.ReadSingleValueUnmanagedList<(int, int)>(ref _taskFinishedDateList);
				break;
			case 51:
				archive.ReadSingleValueCustom(ref _challengeModeData);
				break;
			case 52:
				archive.ReadSingleValueUnmanaged(ref _exorcismEnabled);
				break;
			case 53:
				archive.ReadSingleValueCustomList(ref _monthNotifies);
				break;
			case 54:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_gameStatSaved);
				break;
			case 55:
				archive.ReadSingleValueCollectionUnmanagedKeyValue(_triggeredGuidingChapterDictionary);
				break;
			case 56:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_permanentMonthNotifies);
				break;
			case 57:
				archive.ReadSingleValueCollectionUnmanagedKeyValue(_areaStoryWeathers);
				break;
			case 58:
				archive.ReadSingleValueUnmanagedList(ref _waitForDecideChallengeModeIds);
				break;
			default:
				throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
			}
			RecordLoadedDomainData(domainDataMeta.DataId);
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(1);
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
			return GameData.Serializer.Serializer.Serialize(_worldId, dataPool);
		case 1:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
			}
			return GameData.Serializer.Serializer.Serialize(GetXiangshuProgress(), dataPool);
		case 2:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(_dataStatesXiangshuAvatarTaskStatuses, (int)subId0);
			}
			return GameData.Serializer.Serializer.Serialize(_xiangshuAvatarTaskStatuses[(uint)subId0], dataPool);
		case 3:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
			}
			return GameData.Serializer.Serializer.Serialize(_xiangshuAvatarTasksInOrder, dataPool);
		case 4:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
			}
			return GameData.Serializer.Serializer.Serialize(_mainStoryLineProgress, dataPool);
		case 5:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
			}
			return GameData.Serializer.Serializer.Serialize(_beatRanChenZi, dataPool);
		case 6:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 6);
			}
			return GameData.Serializer.Serializer.Serialize(_worldFunctionsStatuses, dataPool);
		case 7:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
				_modificationsCustomTexts.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_customTexts, dataPool);
		case 8:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 9:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
				_modificationsInstantNotifications.Reset(_instantNotifications.GetSize());
			}
			return GameData.Serializer.Serializer.SerializeModifications(_instantNotifications, dataPool);
		case 10:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 10);
			}
			return GameData.Serializer.Serializer.Serialize(_onHandingMonthlyEventBlock, dataPool);
		case 11:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
			}
			return GameData.Serializer.Serializer.Serialize(_lastMonthlyNotifications, dataPool);
		case 12:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 12);
			}
			return GameData.Serializer.Serializer.Serialize(_worldPopulationType, dataPool);
		case 13:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 13);
			}
			return GameData.Serializer.Serializer.Serialize(_characterLifespanType, dataPool);
		case 14:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 14);
			}
			return GameData.Serializer.Serializer.Serialize(_combatDifficulty, dataPool);
		case 15:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 15);
			}
			return GameData.Serializer.Serializer.Serialize(_hereticsAmountType, dataPool);
		case 16:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 16);
			}
			return GameData.Serializer.Serializer.Serialize(_bossInvasionSpeedType, dataPool);
		case 17:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 17);
			}
			return GameData.Serializer.Serializer.Serialize(_worldResourceAmountType, dataPool);
		case 18:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 18);
			}
			return GameData.Serializer.Serializer.Serialize(_allowRandomTaiwuHeir, dataPool);
		case 19:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 19);
			}
			return GameData.Serializer.Serializer.Serialize(_restrictOptionsBehaviorType, dataPool);
		case 20:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 20);
			}
			return GameData.Serializer.Serializer.Serialize(_taiwuVillageStateTemplateId, dataPool);
		case 21:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 21);
			}
			return GameData.Serializer.Serializer.Serialize(_taiwuVillageLandFormType, dataPool);
		case 22:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 22);
			}
			return GameData.Serializer.Serializer.Serialize(_hideTaiwuOriginalSurname, dataPool);
		case 23:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 23);
			}
			return GameData.Serializer.Serializer.Serialize(_allowExecute, dataPool);
		case 24:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 24);
			}
			return GameData.Serializer.Serializer.Serialize(_archiveFilesBackupInterval, dataPool);
		case 25:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 25);
			}
			return GameData.Serializer.Serializer.Serialize(_worldStandardPopulation, dataPool);
		case 26:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 26);
			}
			return GameData.Serializer.Serializer.Serialize(_currDate, dataPool);
		case 27:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 27);
			}
			return GameData.Serializer.Serializer.Serialize(_daysInCurrMonth, dataPool);
		case 28:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 28);
			}
			return GameData.Serializer.Serializer.Serialize(_advancingMonthState, dataPool);
		case 29:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 29);
			}
			return GameData.Serializer.Serializer.Serialize(GetCurrTaskList(), dataPool);
		case 30:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 30);
			}
			return GameData.Serializer.Serializer.Serialize(GetSortedTaskList(), dataPool);
		case 31:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 31);
			}
			return GameData.Serializer.Serializer.Serialize(GetWorldStateData(), dataPool);
		case 32:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 32);
			}
			return GameData.Serializer.Serializer.Serialize(_archiveFilesBackupCount, dataPool);
		case 33:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 33);
			}
			return GameData.Serializer.Serializer.Serialize(_sortedMonthlyNotificationSortingGroups, dataPool);
		case 34:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 35:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 35);
			}
			return GameData.Serializer.Serializer.Serialize(_professionUpgrade, dataPool);
		case 36:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 36);
			}
			return GameData.Serializer.Serializer.Serialize(_canResetWorldSettings, dataPool);
		case 37:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 37);
			}
			return GameData.Serializer.Serializer.Serialize(_favorabilityChange, dataPool);
		case 38:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 38);
			}
			return GameData.Serializer.Serializer.Serialize(_enemyPracticeLevel, dataPool);
		case 39:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 39);
			}
			return GameData.Serializer.Serializer.Serialize(_loopingDifficulty, dataPool);
		case 40:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 40);
			}
			return GameData.Serializer.Serializer.Serialize(_breakoutDifficulty, dataPool);
		case 41:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 41);
			}
			return GameData.Serializer.Serializer.Serialize(_readingDifficulty, dataPool);
		case 42:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 42);
			}
			return GameData.Serializer.Serializer.Serialize(_lootYield, dataPool);
		case 43:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 43);
				_modificationsBigEvents.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_bigEvents, dataPool);
		case 44:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 44);
				_modificationsStateWeathers.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_stateWeathers, dataPool);
		case 45:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 45);
			}
			return GameData.Serializer.Serializer.Serialize(_extraTriggeredTasks, dataPool);
		case 46:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 46);
			}
			return GameData.Serializer.Serializer.Serialize(_taskSortingOrder, dataPool);
		case 47:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 47);
			}
			return GameData.Serializer.Serializer.Serialize(_pinnedOnTopTasks, dataPool);
		case 48:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 48);
			}
			return GameData.Serializer.Serializer.Serialize(_worldVersionInfo, dataPool);
		case 49:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 49);
			}
			return GameData.Serializer.Serializer.Serialize(_newfeatureTriggered, dataPool);
		case 50:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 50);
			}
			return GameData.Serializer.Serializer.Serialize(_taskFinishedDateList, dataPool);
		case 51:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 51);
			}
			return GameData.Serializer.Serializer.Serialize(_challengeModeData, dataPool);
		case 52:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 52);
			}
			return GameData.Serializer.Serializer.Serialize(_exorcismEnabled, dataPool);
		case 53:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 53);
			}
			return GameData.Serializer.Serializer.Serialize(_monthNotifies, dataPool);
		case 54:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 54);
				_modificationsGameStatSaved.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_gameStatSaved, dataPool);
		case 55:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 55);
				_modificationsTriggeredGuidingChapterDictionary.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_triggeredGuidingChapterDictionary, dataPool);
		case 56:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 56);
				_modificationsPermanentMonthNotifies.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_permanentMonthNotifies, dataPool);
		case 57:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 57);
				_modificationsAreaStoryWeathers.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_areaStoryWeathers, dataPool);
		case 58:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 58);
			}
			return GameData.Serializer.Serializer.Serialize(_waitForDecideChallengeModeIds, dataPool);
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
		{
			XiangshuAvatarTaskStatus value = default(XiangshuAvatarTaskStatus);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			_xiangshuAvatarTaskStatuses[(uint)subId0] = value;
			SetElement_XiangshuAvatarTaskStatuses((int)subId0, value, context);
			break;
		}
		case 3:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _xiangshuAvatarTasksInOrder);
			SetXiangshuAvatarTasksInOrder(_xiangshuAvatarTasksInOrder, context);
			break;
		case 4:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _mainStoryLineProgress);
			SetMainStoryLineProgress(_mainStoryLineProgress, context);
			break;
		case 5:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _beatRanChenZi);
			SetBeatRanChenZi(_beatRanChenZi, context);
			break;
		case 6:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _worldFunctionsStatuses);
			SetWorldFunctionsStatuses(_worldFunctionsStatuses, context);
			break;
		case 7:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 8:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 9:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 10:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _onHandingMonthlyEventBlock);
			SetOnHandingMonthlyEventBlock(_onHandingMonthlyEventBlock, context);
			break;
		case 11:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 12:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 13:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _characterLifespanType);
			SetCharacterLifespanType(_characterLifespanType, context);
			break;
		case 14:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _combatDifficulty);
			SetCombatDifficulty(_combatDifficulty, context);
			break;
		case 15:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _hereticsAmountType);
			SetHereticsAmountType(_hereticsAmountType, context);
			break;
		case 16:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _bossInvasionSpeedType);
			SetBossInvasionSpeedType(_bossInvasionSpeedType, context);
			break;
		case 17:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _worldResourceAmountType);
			SetWorldResourceAmountType(_worldResourceAmountType, context);
			break;
		case 18:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _allowRandomTaiwuHeir);
			SetAllowRandomTaiwuHeir(_allowRandomTaiwuHeir, context);
			break;
		case 19:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _restrictOptionsBehaviorType);
			SetRestrictOptionsBehaviorType(_restrictOptionsBehaviorType, context);
			break;
		case 20:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _taiwuVillageStateTemplateId);
			SetTaiwuVillageStateTemplateId(_taiwuVillageStateTemplateId, context);
			break;
		case 21:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _taiwuVillageLandFormType);
			SetTaiwuVillageLandFormType(_taiwuVillageLandFormType, context);
			break;
		case 22:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _hideTaiwuOriginalSurname);
			SetHideTaiwuOriginalSurname(_hideTaiwuOriginalSurname, context);
			break;
		case 23:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _allowExecute);
			SetAllowExecute(_allowExecute, context);
			break;
		case 24:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _archiveFilesBackupInterval);
			SetArchiveFilesBackupInterval(_archiveFilesBackupInterval, context);
			break;
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
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _archiveFilesBackupCount);
			SetArchiveFilesBackupCount(_archiveFilesBackupCount, context);
			break;
		case 33:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _sortedMonthlyNotificationSortingGroups);
			SetSortedMonthlyNotificationSortingGroups(_sortedMonthlyNotificationSortingGroups, context);
			break;
		case 34:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 35:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _professionUpgrade);
			SetProfessionUpgrade(_professionUpgrade, context);
			break;
		case 36:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _canResetWorldSettings);
			SetCanResetWorldSettings(_canResetWorldSettings, context);
			break;
		case 37:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _favorabilityChange);
			SetFavorabilityChange(_favorabilityChange, context);
			break;
		case 38:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _enemyPracticeLevel);
			SetEnemyPracticeLevel(_enemyPracticeLevel, context);
			break;
		case 39:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _loopingDifficulty);
			SetLoopingDifficulty(_loopingDifficulty, context);
			break;
		case 40:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _breakoutDifficulty);
			SetBreakoutDifficulty(_breakoutDifficulty, context);
			break;
		case 41:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _readingDifficulty);
			SetReadingDifficulty(_readingDifficulty, context);
			break;
		case 42:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _lootYield);
			SetLootYield(_lootYield, context);
			break;
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
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _newfeatureTriggered);
			SetNewfeatureTriggered(_newfeatureTriggered, context);
			break;
		case 50:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 51:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 52:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _exorcismEnabled);
			SetExorcismEnabled(_exorcismEnabled, context);
			break;
		case 53:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _monthNotifies);
			SetMonthNotifies(_monthNotifies, context);
			break;
		case 54:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 55:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 56:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 57:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 58:
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
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 2)
			{
				WorldCreationInfo info2 = default(WorldCreationInfo);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref info2);
				List<int> challengeModeIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref challengeModeIds);
				CreateWorld(context, info2, challengeModeIds);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 2)
			{
				WorldCreationInfo info = default(WorldCreationInfo);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref info);
				bool inherit = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref inherit);
				SetWorldCreationInfo(context, info, inherit);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
			if (operation.ArgsCount == 0)
			{
				WorldCreationInfo returnValue5 = GetWorldCreationInfo();
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 3:
			if (operation.ArgsCount == 0)
			{
				List<Location> returnValue9 = GetJuniorXiangshuLocations();
				return GameData.Serializer.Serializer.Serialize(returnValue9, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 4:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 1)
			{
				int offset = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref offset);
				HandleMonthlyEvent(context, offset);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 5:
			if (operation.ArgsCount == 0)
			{
				MonthlyEventCollection returnValue8 = GetMonthlyEventCollection();
				return GameData.Serializer.Serializer.Serialize(returnValue8, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 6:
			if (operation.ArgsCount == 0)
			{
				RemoveAllInvalidMonthlyEvents(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 7:
			if (operation.ArgsCount == 0)
			{
				ProcessAllMonthlyEventsWithDefaultOption(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 8:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 1)
			{
				byte worldPopulationType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref worldPopulationType);
				SpecifyWorldPopulationType(context, worldPopulationType);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 9:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 1)
			{
				int days = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref days);
				AdvanceDaysInMonth(context, days);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 10:
			if (operation.ArgsCount == 0)
			{
				AdvanceMonth(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 11:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 1)
			{
				bool saveWorld = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref saveWorld);
				AdvanceMonth_DisplayedMonthlyNotifications(context, saveWorld);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 4)
			{
				short startTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref startTemplateId);
				short endTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref endTemplateId);
				int selfCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref selfCharId);
				int targetCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetCharId);
				bool returnValue6 = GmCmd_AddMonthlyEvent(startTemplateId, endTemplateId, selfCharId, targetCharId);
				return GameData.Serializer.Serializer.Serialize(returnValue6, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 13:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 2)
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				int delta = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref delta);
				GmCmd_AddSectJieqingNpcExtraLegacyPoints(context, charId, delta);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 14:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				int topTaskInfoId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref topTaskInfoId2);
				SetTopTask(context, topTaskInfoId2);
				return -1;
			}
			case 2:
			{
				int topTaskInfoId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref topTaskInfoId);
				int targetIndex = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetIndex);
				SetTopTask(context, topTaskInfoId, targetIndex);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 15:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 2)
			{
				int taskChainId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref taskChainId2);
				int taskInfoId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref taskInfoId2);
				GmCmd_AddExtraTask(context, taskChainId2, taskInfoId2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 16:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 2)
			{
				int taskChainId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref taskChainId);
				int taskInfoId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref taskInfoId);
				GmCmd_RemoveTriggeredExtraTask(context, taskChainId, taskInfoId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 17:
			if (operation.ArgsCount == 0)
			{
				AdvanceMonthConditionsDisplayData returnValue2 = GetAdvanceMonthSoftConditions(context);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 18:
		{
			int argsCount14 = operation.ArgsCount;
			int num14 = argsCount14;
			if (num14 == 2)
			{
				int templateId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId3);
				bool trigger = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref trigger);
				GmCmd_SetWorldFunctionUnlockHint(templateId3, trigger);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 19:
			if (operation.ArgsCount == 0)
			{
				WorldStateData returnValue7 = RequestWorldStateData();
				return GameData.Serializer.Serializer.Serialize(returnValue7, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 20:
			if (operation.ArgsCount == 0)
			{
				GmCmd_AddResetWorldSettingsChance(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 21:
			if (operation.ArgsCount == 0)
			{
				MonthNotifyDisplayData returnValue4 = GetMonthNotifyDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 22:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				short templateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId2);
				TriggeredGuidingChapter(context, templateId2);
				return -1;
			}
			case 2:
			{
				short templateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId);
				EGuidingChapterState state = EGuidingChapterState.NewTriggered;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref state);
				TriggeredGuidingChapter(context, templateId, state);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 23:
		{
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 2)
			{
				short statId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref statId);
				int value2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value2);
				RequestSetStat(context, statId, value2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 24:
			if (operation.ArgsCount == 0)
			{
				ResetStatsAndAchievements(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 25:
			if (operation.ArgsCount == 0)
			{
				MonthNotifyDisplayData returnValue3 = GetNewestMonthNotifyDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 26:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 1)
			{
				bool value = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value);
				GmCmd_SetAllGuidingChapter(context, value);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 27:
			if (operation.ArgsCount == 0)
			{
				OnClickDamageHugeSword(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 28:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 2)
			{
				int modeId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modeId);
				bool enable = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref enable);
				bool returnValue = DecideNewChallengeMode(context, modeId, enable);
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
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			break;
		case 7:
			_modificationsCustomTexts.ChangeRecording(monitoring);
			break;
		case 8:
			break;
		case 9:
			_modificationsInstantNotifications.ChangeRecording(monitoring, _instantNotifications.GetSize());
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
			break;
		case 17:
			break;
		case 18:
			break;
		case 19:
			break;
		case 20:
			break;
		case 21:
			break;
		case 22:
			break;
		case 23:
			break;
		case 24:
			break;
		case 25:
			break;
		case 26:
			break;
		case 27:
			break;
		case 28:
			break;
		case 29:
			break;
		case 30:
			break;
		case 31:
			break;
		case 32:
			break;
		case 33:
			break;
		case 34:
			break;
		case 35:
			break;
		case 36:
			break;
		case 37:
			break;
		case 38:
			break;
		case 39:
			break;
		case 40:
			break;
		case 41:
			break;
		case 42:
			break;
		case 43:
			_modificationsBigEvents.ChangeRecording(monitoring);
			break;
		case 44:
			_modificationsStateWeathers.ChangeRecording(monitoring);
			break;
		case 45:
			break;
		case 46:
			break;
		case 47:
			break;
		case 48:
			break;
		case 49:
			break;
		case 50:
			break;
		case 51:
			break;
		case 52:
			break;
		case 53:
			break;
		case 54:
			_modificationsGameStatSaved.ChangeRecording(monitoring);
			break;
		case 55:
			_modificationsTriggeredGuidingChapterDictionary.ChangeRecording(monitoring);
			break;
		case 56:
			_modificationsPermanentMonthNotifies.ChangeRecording(monitoring);
			break;
		case 57:
			_modificationsAreaStoryWeathers.ChangeRecording(monitoring);
			break;
		case 58:
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
			if (!BaseGameDataDomain.IsModified(DataStates, 0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 0);
			return GameData.Serializer.Serializer.Serialize(_worldId, dataPool);
		case 1:
			if (!BaseGameDataDomain.IsModified(DataStates, 1))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 1);
			return GameData.Serializer.Serializer.Serialize(GetXiangshuProgress(), dataPool);
		case 2:
			if (!BaseGameDataDomain.IsModified(_dataStatesXiangshuAvatarTaskStatuses, (int)subId0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(_dataStatesXiangshuAvatarTaskStatuses, (int)subId0);
			return GameData.Serializer.Serializer.Serialize(_xiangshuAvatarTaskStatuses[(uint)subId0], dataPool);
		case 3:
			if (!BaseGameDataDomain.IsModified(DataStates, 3))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 3);
			return GameData.Serializer.Serializer.Serialize(_xiangshuAvatarTasksInOrder, dataPool);
		case 4:
			if (!BaseGameDataDomain.IsModified(DataStates, 4))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 4);
			return GameData.Serializer.Serializer.Serialize(_mainStoryLineProgress, dataPool);
		case 5:
			if (!BaseGameDataDomain.IsModified(DataStates, 5))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 5);
			return GameData.Serializer.Serializer.Serialize(_beatRanChenZi, dataPool);
		case 6:
			if (!BaseGameDataDomain.IsModified(DataStates, 6))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 6);
			return GameData.Serializer.Serializer.Serialize(_worldFunctionsStatuses, dataPool);
		case 7:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 7))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 7);
			int offset8 = GameData.Serializer.Serializer.SerializeModifications(_customTexts, dataPool, _modificationsCustomTexts);
			_modificationsCustomTexts.Reset();
			return offset8;
		}
		case 8:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 9:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 9))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 9);
			int offset5 = GameData.Serializer.Serializer.SerializeModifications(_instantNotifications, dataPool, _modificationsInstantNotifications);
			_modificationsInstantNotifications.Reset(_instantNotifications.GetSize());
			return offset5;
		}
		case 10:
			if (!BaseGameDataDomain.IsModified(DataStates, 10))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 10);
			return GameData.Serializer.Serializer.Serialize(_onHandingMonthlyEventBlock, dataPool);
		case 11:
			if (!BaseGameDataDomain.IsModified(DataStates, 11))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 11);
			return GameData.Serializer.Serializer.Serialize(_lastMonthlyNotifications, dataPool);
		case 12:
			if (!BaseGameDataDomain.IsModified(DataStates, 12))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 12);
			return GameData.Serializer.Serializer.Serialize(_worldPopulationType, dataPool);
		case 13:
			if (!BaseGameDataDomain.IsModified(DataStates, 13))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 13);
			return GameData.Serializer.Serializer.Serialize(_characterLifespanType, dataPool);
		case 14:
			if (!BaseGameDataDomain.IsModified(DataStates, 14))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 14);
			return GameData.Serializer.Serializer.Serialize(_combatDifficulty, dataPool);
		case 15:
			if (!BaseGameDataDomain.IsModified(DataStates, 15))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 15);
			return GameData.Serializer.Serializer.Serialize(_hereticsAmountType, dataPool);
		case 16:
			if (!BaseGameDataDomain.IsModified(DataStates, 16))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 16);
			return GameData.Serializer.Serializer.Serialize(_bossInvasionSpeedType, dataPool);
		case 17:
			if (!BaseGameDataDomain.IsModified(DataStates, 17))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 17);
			return GameData.Serializer.Serializer.Serialize(_worldResourceAmountType, dataPool);
		case 18:
			if (!BaseGameDataDomain.IsModified(DataStates, 18))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 18);
			return GameData.Serializer.Serializer.Serialize(_allowRandomTaiwuHeir, dataPool);
		case 19:
			if (!BaseGameDataDomain.IsModified(DataStates, 19))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 19);
			return GameData.Serializer.Serializer.Serialize(_restrictOptionsBehaviorType, dataPool);
		case 20:
			if (!BaseGameDataDomain.IsModified(DataStates, 20))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 20);
			return GameData.Serializer.Serializer.Serialize(_taiwuVillageStateTemplateId, dataPool);
		case 21:
			if (!BaseGameDataDomain.IsModified(DataStates, 21))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 21);
			return GameData.Serializer.Serializer.Serialize(_taiwuVillageLandFormType, dataPool);
		case 22:
			if (!BaseGameDataDomain.IsModified(DataStates, 22))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 22);
			return GameData.Serializer.Serializer.Serialize(_hideTaiwuOriginalSurname, dataPool);
		case 23:
			if (!BaseGameDataDomain.IsModified(DataStates, 23))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 23);
			return GameData.Serializer.Serializer.Serialize(_allowExecute, dataPool);
		case 24:
			if (!BaseGameDataDomain.IsModified(DataStates, 24))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 24);
			return GameData.Serializer.Serializer.Serialize(_archiveFilesBackupInterval, dataPool);
		case 25:
			if (!BaseGameDataDomain.IsModified(DataStates, 25))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 25);
			return GameData.Serializer.Serializer.Serialize(_worldStandardPopulation, dataPool);
		case 26:
			if (!BaseGameDataDomain.IsModified(DataStates, 26))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 26);
			return GameData.Serializer.Serializer.Serialize(_currDate, dataPool);
		case 27:
			if (!BaseGameDataDomain.IsModified(DataStates, 27))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 27);
			return GameData.Serializer.Serializer.Serialize(_daysInCurrMonth, dataPool);
		case 28:
			if (!BaseGameDataDomain.IsModified(DataStates, 28))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 28);
			return GameData.Serializer.Serializer.Serialize(_advancingMonthState, dataPool);
		case 29:
			if (!BaseGameDataDomain.IsModified(DataStates, 29))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 29);
			return GameData.Serializer.Serializer.Serialize(GetCurrTaskList(), dataPool);
		case 30:
			if (!BaseGameDataDomain.IsModified(DataStates, 30))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 30);
			return GameData.Serializer.Serializer.Serialize(GetSortedTaskList(), dataPool);
		case 31:
			if (!BaseGameDataDomain.IsModified(DataStates, 31))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 31);
			return GameData.Serializer.Serializer.Serialize(GetWorldStateData(), dataPool);
		case 32:
			if (!BaseGameDataDomain.IsModified(DataStates, 32))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 32);
			return GameData.Serializer.Serializer.Serialize(_archiveFilesBackupCount, dataPool);
		case 33:
			if (!BaseGameDataDomain.IsModified(DataStates, 33))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 33);
			return GameData.Serializer.Serializer.Serialize(_sortedMonthlyNotificationSortingGroups, dataPool);
		case 34:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 35:
			if (!BaseGameDataDomain.IsModified(DataStates, 35))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 35);
			return GameData.Serializer.Serializer.Serialize(_professionUpgrade, dataPool);
		case 36:
			if (!BaseGameDataDomain.IsModified(DataStates, 36))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 36);
			return GameData.Serializer.Serializer.Serialize(_canResetWorldSettings, dataPool);
		case 37:
			if (!BaseGameDataDomain.IsModified(DataStates, 37))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 37);
			return GameData.Serializer.Serializer.Serialize(_favorabilityChange, dataPool);
		case 38:
			if (!BaseGameDataDomain.IsModified(DataStates, 38))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 38);
			return GameData.Serializer.Serializer.Serialize(_enemyPracticeLevel, dataPool);
		case 39:
			if (!BaseGameDataDomain.IsModified(DataStates, 39))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 39);
			return GameData.Serializer.Serializer.Serialize(_loopingDifficulty, dataPool);
		case 40:
			if (!BaseGameDataDomain.IsModified(DataStates, 40))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 40);
			return GameData.Serializer.Serializer.Serialize(_breakoutDifficulty, dataPool);
		case 41:
			if (!BaseGameDataDomain.IsModified(DataStates, 41))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 41);
			return GameData.Serializer.Serializer.Serialize(_readingDifficulty, dataPool);
		case 42:
			if (!BaseGameDataDomain.IsModified(DataStates, 42))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 42);
			return GameData.Serializer.Serializer.Serialize(_lootYield, dataPool);
		case 43:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 43))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 43);
			int offset7 = GameData.Serializer.Serializer.SerializeModifications(_bigEvents, dataPool, _modificationsBigEvents);
			_modificationsBigEvents.Reset();
			return offset7;
		}
		case 44:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 44))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 44);
			int offset6 = GameData.Serializer.Serializer.SerializeModifications(_stateWeathers, dataPool, _modificationsStateWeathers);
			_modificationsStateWeathers.Reset();
			return offset6;
		}
		case 45:
			if (!BaseGameDataDomain.IsModified(DataStates, 45))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 45);
			return GameData.Serializer.Serializer.Serialize(_extraTriggeredTasks, dataPool);
		case 46:
			if (!BaseGameDataDomain.IsModified(DataStates, 46))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 46);
			return GameData.Serializer.Serializer.Serialize(_taskSortingOrder, dataPool);
		case 47:
			if (!BaseGameDataDomain.IsModified(DataStates, 47))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 47);
			return GameData.Serializer.Serializer.Serialize(_pinnedOnTopTasks, dataPool);
		case 48:
			if (!BaseGameDataDomain.IsModified(DataStates, 48))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 48);
			return GameData.Serializer.Serializer.Serialize(_worldVersionInfo, dataPool);
		case 49:
			if (!BaseGameDataDomain.IsModified(DataStates, 49))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 49);
			return GameData.Serializer.Serializer.Serialize(_newfeatureTriggered, dataPool);
		case 50:
			if (!BaseGameDataDomain.IsModified(DataStates, 50))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 50);
			return GameData.Serializer.Serializer.Serialize(_taskFinishedDateList, dataPool);
		case 51:
			if (!BaseGameDataDomain.IsModified(DataStates, 51))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 51);
			return GameData.Serializer.Serializer.Serialize(_challengeModeData, dataPool);
		case 52:
			if (!BaseGameDataDomain.IsModified(DataStates, 52))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 52);
			return GameData.Serializer.Serializer.Serialize(_exorcismEnabled, dataPool);
		case 53:
			if (!BaseGameDataDomain.IsModified(DataStates, 53))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 53);
			return GameData.Serializer.Serializer.Serialize(_monthNotifies, dataPool);
		case 54:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 54))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 54);
			int offset4 = GameData.Serializer.Serializer.SerializeModifications(_gameStatSaved, dataPool, _modificationsGameStatSaved);
			_modificationsGameStatSaved.Reset();
			return offset4;
		}
		case 55:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 55))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 55);
			int offset3 = GameData.Serializer.Serializer.SerializeModifications(_triggeredGuidingChapterDictionary, dataPool, _modificationsTriggeredGuidingChapterDictionary);
			_modificationsTriggeredGuidingChapterDictionary.Reset();
			return offset3;
		}
		case 56:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 56))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 56);
			int offset2 = GameData.Serializer.Serializer.SerializeModifications(_permanentMonthNotifies, dataPool, _modificationsPermanentMonthNotifies);
			_modificationsPermanentMonthNotifies.Reset();
			return offset2;
		}
		case 57:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 57))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 57);
			int offset = GameData.Serializer.Serializer.SerializeModifications(_areaStoryWeathers, dataPool, _modificationsAreaStoryWeathers);
			_modificationsAreaStoryWeathers.Reset();
			return offset;
		}
		case 58:
			if (!BaseGameDataDomain.IsModified(DataStates, 58))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 58);
			return GameData.Serializer.Serializer.Serialize(_waitForDecideChallengeModeIds, dataPool);
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
			if (BaseGameDataDomain.IsModified(_dataStatesXiangshuAvatarTaskStatuses, (int)subId0))
			{
				BaseGameDataDomain.ResetModified(_dataStatesXiangshuAvatarTaskStatuses, (int)subId0);
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
				_modificationsCustomTexts.Reset();
			}
			break;
		case 8:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 9:
			if (BaseGameDataDomain.IsModified(DataStates, 9))
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
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
			if (BaseGameDataDomain.IsModified(DataStates, 15))
			{
				BaseGameDataDomain.ResetModified(DataStates, 15);
			}
			break;
		case 16:
			if (BaseGameDataDomain.IsModified(DataStates, 16))
			{
				BaseGameDataDomain.ResetModified(DataStates, 16);
			}
			break;
		case 17:
			if (BaseGameDataDomain.IsModified(DataStates, 17))
			{
				BaseGameDataDomain.ResetModified(DataStates, 17);
			}
			break;
		case 18:
			if (BaseGameDataDomain.IsModified(DataStates, 18))
			{
				BaseGameDataDomain.ResetModified(DataStates, 18);
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
			}
			break;
		case 22:
			if (BaseGameDataDomain.IsModified(DataStates, 22))
			{
				BaseGameDataDomain.ResetModified(DataStates, 22);
			}
			break;
		case 23:
			if (BaseGameDataDomain.IsModified(DataStates, 23))
			{
				BaseGameDataDomain.ResetModified(DataStates, 23);
			}
			break;
		case 24:
			if (BaseGameDataDomain.IsModified(DataStates, 24))
			{
				BaseGameDataDomain.ResetModified(DataStates, 24);
			}
			break;
		case 25:
			if (BaseGameDataDomain.IsModified(DataStates, 25))
			{
				BaseGameDataDomain.ResetModified(DataStates, 25);
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
			if (BaseGameDataDomain.IsModified(DataStates, 28))
			{
				BaseGameDataDomain.ResetModified(DataStates, 28);
			}
			break;
		case 29:
			if (BaseGameDataDomain.IsModified(DataStates, 29))
			{
				BaseGameDataDomain.ResetModified(DataStates, 29);
			}
			break;
		case 30:
			if (BaseGameDataDomain.IsModified(DataStates, 30))
			{
				BaseGameDataDomain.ResetModified(DataStates, 30);
			}
			break;
		case 31:
			if (BaseGameDataDomain.IsModified(DataStates, 31))
			{
				BaseGameDataDomain.ResetModified(DataStates, 31);
			}
			break;
		case 32:
			if (BaseGameDataDomain.IsModified(DataStates, 32))
			{
				BaseGameDataDomain.ResetModified(DataStates, 32);
			}
			break;
		case 33:
			if (BaseGameDataDomain.IsModified(DataStates, 33))
			{
				BaseGameDataDomain.ResetModified(DataStates, 33);
			}
			break;
		case 34:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 35:
			if (BaseGameDataDomain.IsModified(DataStates, 35))
			{
				BaseGameDataDomain.ResetModified(DataStates, 35);
			}
			break;
		case 36:
			if (BaseGameDataDomain.IsModified(DataStates, 36))
			{
				BaseGameDataDomain.ResetModified(DataStates, 36);
			}
			break;
		case 37:
			if (BaseGameDataDomain.IsModified(DataStates, 37))
			{
				BaseGameDataDomain.ResetModified(DataStates, 37);
			}
			break;
		case 38:
			if (BaseGameDataDomain.IsModified(DataStates, 38))
			{
				BaseGameDataDomain.ResetModified(DataStates, 38);
			}
			break;
		case 39:
			if (BaseGameDataDomain.IsModified(DataStates, 39))
			{
				BaseGameDataDomain.ResetModified(DataStates, 39);
			}
			break;
		case 40:
			if (BaseGameDataDomain.IsModified(DataStates, 40))
			{
				BaseGameDataDomain.ResetModified(DataStates, 40);
			}
			break;
		case 41:
			if (BaseGameDataDomain.IsModified(DataStates, 41))
			{
				BaseGameDataDomain.ResetModified(DataStates, 41);
			}
			break;
		case 42:
			if (BaseGameDataDomain.IsModified(DataStates, 42))
			{
				BaseGameDataDomain.ResetModified(DataStates, 42);
			}
			break;
		case 43:
			if (BaseGameDataDomain.IsModified(DataStates, 43))
			{
				BaseGameDataDomain.ResetModified(DataStates, 43);
				_modificationsBigEvents.Reset();
			}
			break;
		case 44:
			if (BaseGameDataDomain.IsModified(DataStates, 44))
			{
				BaseGameDataDomain.ResetModified(DataStates, 44);
				_modificationsStateWeathers.Reset();
			}
			break;
		case 45:
			if (BaseGameDataDomain.IsModified(DataStates, 45))
			{
				BaseGameDataDomain.ResetModified(DataStates, 45);
			}
			break;
		case 46:
			if (BaseGameDataDomain.IsModified(DataStates, 46))
			{
				BaseGameDataDomain.ResetModified(DataStates, 46);
			}
			break;
		case 47:
			if (BaseGameDataDomain.IsModified(DataStates, 47))
			{
				BaseGameDataDomain.ResetModified(DataStates, 47);
			}
			break;
		case 48:
			if (BaseGameDataDomain.IsModified(DataStates, 48))
			{
				BaseGameDataDomain.ResetModified(DataStates, 48);
			}
			break;
		case 49:
			if (BaseGameDataDomain.IsModified(DataStates, 49))
			{
				BaseGameDataDomain.ResetModified(DataStates, 49);
			}
			break;
		case 50:
			if (BaseGameDataDomain.IsModified(DataStates, 50))
			{
				BaseGameDataDomain.ResetModified(DataStates, 50);
			}
			break;
		case 51:
			if (BaseGameDataDomain.IsModified(DataStates, 51))
			{
				BaseGameDataDomain.ResetModified(DataStates, 51);
			}
			break;
		case 52:
			if (BaseGameDataDomain.IsModified(DataStates, 52))
			{
				BaseGameDataDomain.ResetModified(DataStates, 52);
			}
			break;
		case 53:
			if (BaseGameDataDomain.IsModified(DataStates, 53))
			{
				BaseGameDataDomain.ResetModified(DataStates, 53);
			}
			break;
		case 54:
			if (BaseGameDataDomain.IsModified(DataStates, 54))
			{
				BaseGameDataDomain.ResetModified(DataStates, 54);
				_modificationsGameStatSaved.Reset();
			}
			break;
		case 55:
			if (BaseGameDataDomain.IsModified(DataStates, 55))
			{
				BaseGameDataDomain.ResetModified(DataStates, 55);
				_modificationsTriggeredGuidingChapterDictionary.Reset();
			}
			break;
		case 56:
			if (BaseGameDataDomain.IsModified(DataStates, 56))
			{
				BaseGameDataDomain.ResetModified(DataStates, 56);
				_modificationsPermanentMonthNotifies.Reset();
			}
			break;
		case 57:
			if (BaseGameDataDomain.IsModified(DataStates, 57))
			{
				BaseGameDataDomain.ResetModified(DataStates, 57);
				_modificationsAreaStoryWeathers.Reset();
			}
			break;
		case 58:
			if (BaseGameDataDomain.IsModified(DataStates, 58))
			{
				BaseGameDataDomain.ResetModified(DataStates, 58);
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
			2 => BaseGameDataDomain.IsModified(_dataStatesXiangshuAvatarTaskStatuses, (int)subId0), 
			3 => BaseGameDataDomain.IsModified(DataStates, 3), 
			4 => BaseGameDataDomain.IsModified(DataStates, 4), 
			5 => BaseGameDataDomain.IsModified(DataStates, 5), 
			6 => BaseGameDataDomain.IsModified(DataStates, 6), 
			7 => BaseGameDataDomain.IsModified(DataStates, 7), 
			8 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
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
			34 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
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
			53 => BaseGameDataDomain.IsModified(DataStates, 53), 
			54 => BaseGameDataDomain.IsModified(DataStates, 54), 
			55 => BaseGameDataDomain.IsModified(DataStates, 55), 
			56 => BaseGameDataDomain.IsModified(DataStates, 56), 
			57 => BaseGameDataDomain.IsModified(DataStates, 57), 
			58 => BaseGameDataDomain.IsModified(DataStates, 58), 
			_ => throw new Exception($"Unsupported dataId {dataId}"), 
		};
	}

	public override void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll)
	{
		switch (influence.TargetIndicator.DataId)
		{
		case 1:
			BaseGameDataDomain.InvalidateSelfAndInfluencedCache(1, DataStates, CacheInfluences, context);
			break;
		case 29:
			BaseGameDataDomain.InvalidateSelfAndInfluencedCache(29, DataStates, CacheInfluences, context);
			break;
		case 30:
			BaseGameDataDomain.InvalidateSelfAndInfluencedCache(30, DataStates, CacheInfluences, context);
			break;
		case 31:
			BaseGameDataDomain.InvalidateSelfAndInfluencedCache(31, DataStates, CacheInfluences, context);
			break;
		default:
			throw new Exception($"Unsupported dataId {influence.TargetIndicator.DataId}");
		case 0:
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
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
	}
}
