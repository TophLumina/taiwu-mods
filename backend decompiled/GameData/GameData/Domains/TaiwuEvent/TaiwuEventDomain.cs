using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Config;
using Config.EventConfig;
using GameData.Achievement;
using GameData.ArchiveData;
using GameData.Common;
using GameData.DLC;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.Relation;
using GameData.Domains.CombatSkill;
using GameData.Domains.Extra;
using GameData.Domains.Global;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Domains.TaiwuEvent.Enum;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.TaiwuEvent.EventLog;
using GameData.Domains.TaiwuEvent.EventManager;
using GameData.Domains.TaiwuEvent.EventOption;
using GameData.Domains.TaiwuEvent.MonthlyEventActions;
using GameData.Domains.World;
using GameData.Domains.World.Notification;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using NLog;

namespace GameData.Domains.TaiwuEvent;

[GameDataDomain(12)]
public class TaiwuEventDomain : BaseGameDataDomain
{
	private enum EEventPackageLoadMethod
	{
		LoadFile,
		LoadFrom,
		LoadBuffer
	}

	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public bool InCombatBegin;

	private static readonly HashSet<string> HostileSelectItemEventGuids = new HashSet<string> { "586e9c28-7d1a-4945-b3c5-0394bdd7665c", "1fdd9d65-a207-4e4a-9f1c-99512cf96fd9", "f370a0e3-3ebc-4e52-93bd-9fd75a1d3b78" };

	private LocalObjectPool<EventArgBox> _argBoxPool;

	private List<TaiwuEvent> _triggeredEventList;

	private TaiwuEvent _showingEvent;

	private (string EventGuid, string OptionKey, string nextGuid) _interactCheckContinueData;

	private List<short> _needToShowLegacies = new List<short>();

	private List<short> _needToShowFeatures = new List<short>();

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private TaiwuEventDisplayData _displayingEventData;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private List<EventOptionInfo> _commonOptionPreviewEventOptionInfos;

	public DataContext MainThreadDataContext;

	public string SeriesEventTexture;

	private bool _stopAutoNextEvent;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private List<ItemKey> _tempCreateItemList;

	private string _waitConfirmSelectOption;

	private TaiwuEventItem _waitConfirmEventConfig;

	private string _waitConfirmOptionKey;

	private string _eventAfterInteractCheckResult;

	private readonly List<string> _eventEnteredList = new List<string>();

	private int _doWhileLayer = 0;

	private EventCgTextureItem _currCgTextureItem;

	private EventCgTextureItem _currCgTextureItemOnPictureShowPage;

	public List<(string listeningAction, TaiwuEvent listenerEvent)> ListeningEventActionList = new List<(string, TaiwuEvent)>();

	private static readonly HashSet<string> BlockTriggerActionKeys = new HashSet<string>();

	private readonly Queue<List<EventLogResultData>> _eventLogQueue = new Queue<List<EventLogResultData>>();

	private readonly Dictionary<int, CharacterDisplayData> _characterCache = new Dictionary<int, CharacterDisplayData>();

	private readonly Dictionary<int, int> _characterReferences = new Dictionary<int, int>();

	private readonly Dictionary<int, SecretInformationDisplayData> _secretInformationCache = new Dictionary<int, SecretInformationDisplayData>();

	private readonly Dictionary<int, int> _secretInformationReferences = new Dictionary<int, int>();

	private readonly Dictionary<int, ItemDisplayData> _itemCache = new Dictionary<int, ItemDisplayData>();

	private readonly Dictionary<int, int> _itemReferences = new Dictionary<int, int>();

	private readonly Dictionary<int, CombatSkillDisplayData> _combatSkillCache = new Dictionary<int, CombatSkillDisplayData>();

	private readonly Dictionary<int, int> _combatSkillReferences = new Dictionary<int, int>();

	private readonly Dictionary<int, (ItemKey, bool)> _itemKeys = new Dictionary<int, (ItemKey, bool)>();

	private readonly Dictionary<int, EventLogCharacterData> _npcStatus = new Dictionary<int, EventLogCharacterData>();

	private readonly EventLogCharacterData _taiwuStatus = new EventLogCharacterData(isTaiwu: true);

	private List<EventLogResultData> _resultCache = new List<EventLogResultData>();

	private string _rawResponseData = "";

	private (int, int) _interactingCharacters = (-1, -1);

	private int _adventureId = -1;

	private bool _isCheckValid = false;

	private bool _isSequential = false;

	private bool _shouldCheckStatusImmediately = true;

	private readonly HashSet<IntPair> _executedOncePerMonthOptions = new HashSet<IntPair>();

	private static GameData.Domains.TaiwuEvent.EventManager.EventManager _eventManager;

	private static List<EventPackage> _packagesList;

	private static List<(TaiwuEventOption TaiwuEventOption, short templateId, TaiwuEventItem TaiwuEventItem)> _characterInteractionEventOptionList = new List<(TaiwuEventOption, short, TaiwuEventItem)>();

	private static readonly Dictionary<EventPackage, string> _languageFilePattern = new Dictionary<EventPackage, string>();

	private static EEventPackageLoadMethod _loadMethod;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private EventArgBox _globalArgBox;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private MonthlyEventActionsManager _monthlyEventActionManager;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly HashSetAsDictionary<int> _handledOneShotEvents;

	private static EventScriptRuntime _scriptRuntime;

	private readonly HashSet<string> _selectedTemporaryOptions = new HashSet<string>();

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private string _cgName;

	[DomainData(DomainDataType.SingleValue, false, false, true, false)]
	private EventNotifyData _notifyData;

	[DomainData(DomainDataType.SingleValue, false, false, true, false)]
	private bool _hasListeningEvent;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private EventSelectInformationData _selectInformationData;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private EventCricketBettingData _cricketBettingData;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private EventSelectCombatSkillData _selectCombatSkillData;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private EventSelectLifeSkillData _selectLifeSkillData;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _taiwuLocationChangeFlag;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _secretVillageOnFire;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _taiwuVillageShowShrine;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _hideAllMapBlockCharacters;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _hideAllTeammates;

	[DomainData(DomainDataType.SingleValue, true, false, true, true, ArrayElementsCount = 3)]
	private int[] _allCombatGroupChars;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private string _leftRoleAlternativeName;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private string _rightRoleAlternativeName;

	[DomainData(DomainDataType.SingleValue, false, false, true, true, ArrayElementsCount = 2)]
	private sbyte[] _rightRoleXiangshuDisplayData;

	[DomainData(DomainDataType.SingleValue, false, false, true, true, ArrayElementsCount = 3)]
	private ItemDisplayData[] _itemListOfLeft;

	[DomainData(DomainDataType.SingleValue, false, false, true, true, ArrayElementsCount = 3)]
	private ItemDisplayData[] _itemListOfRight;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _showItemWithCricketBattleGuess;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private List<sbyte> _coverCricketJarGradeListForRight;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private List<int> _marriageLook1CharIdList;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private List<int> _marriageLook2CharIdList;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private List<int> _jieqingMaskCharIdList;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _needToNotifyNewMonth;

	private List<int> _invitedCharacterThisMonth = new List<int>();

	public CharacterSet InteractedCharSet = default(CharacterSet);

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[30][];

	private Queue<uint> _pendingLoadingOperationIds;

	public bool ShowInteractCheckAnimation { get; set; }

	public EventInteractCheckData InteractCheckData { get; set; }

	public TaiwuEvent ShowingEvent
	{
		get
		{
			return _showingEvent;
		}
		private set
		{
			_showingEvent = value;
			Events.RaiseEventWindowFocusStateChanged(MainThreadDataContext, !_showingEvent.IsEmpty);
		}
	}

	public bool IsShowingEvent
	{
		get
		{
			TaiwuEvent showingEvent = _showingEvent;
			return showingEvent != null && !showingEvent.IsEmpty;
		}
	}

	public sbyte LegacyReason { get; private set; }

	private bool ShouldEarlyReturn
	{
		get
		{
			int result;
			if (_resultCache.Count != 0)
			{
				List<EventLogResultData> resultCache = _resultCache;
				result = ((resultCache[resultCache.Count - 1].Type == 30) ? 1 : 0);
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	[Obsolete]
	public static bool IsQuickStartGame { get; private set; }

	public EventScriptRuntime ScriptRuntime => _scriptRuntime;

	[DataUpgrader(Version = "1.0.6", Date = "2026/06/18")]
	private void TryGetMissingEmeiStoryItem(DataContext context)
	{
		if (DomainManager.World.IsTaskFinished(728) && !DomainManager.Taiwu.TaiwuInventoryHasItem(context, 2, 269))
		{
			ItemKey itemKey = DomainManager.Item.CreateItem(context, 2, 269);
			DomainManager.Taiwu.GetTaiwu().AddInventoryItem(context, itemKey, 1);
		}
	}

	[DataUpgrader(Version = "1.0.1", Date = "2026/06/18")]
	private void FixMissingMainStoryAdventure(DataContext context)
	{
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		short areaId = taiwuVillageLocation.AreaId;
		if (!DomainManager.World.IsTaskInProgress(26) || DomainManager.Adventure.QueryMajorEventInArea(areaId, 19898804).IsValid())
		{
			return;
		}
		List<MapBlockData> blockDataList = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetLocationByDistance(taiwuVillageLocation, 1, 3, ref blockDataList);
		MapBlockMatcherItem matcher = MapBlockMatcher.DefValue.NoAdventureNoMajorEvent;
		for (int i = blockDataList.Count - 1; i >= 0; i--)
		{
			if (!matcher.Match(blockDataList[i]))
			{
				CollectionUtils.SwapAndRemove(blockDataList, i);
			}
		}
		MapBlockData selectedBlock = blockDataList.GetRandomOrDefault(context.Random, null);
		ObjectPool<List<MapBlockData>>.Instance.Return(blockDataList);
		Location targetLocation = selectedBlock.GetLocation();
		DomainManager.Adventure.GenerateMajorEvent(context, 19898804, targetLocation);
		AdaptableLog.TagWarning("FixMissingMainStoryAdventure", $"Fixing missing main story adventure TombImmortal at {targetLocation}");
	}

	[DataUpgrader(Version = "1.0.1", Date = "2026/06/18")]
	private void FixAbnormalBrokenPerformAreaMission(DataContext context)
	{
		if (DomainManager.World.IsTaskInProgress(13) || DomainManager.World.IsTaskInProgress(14))
		{
			Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
			if (taiwuLocation.AreaId == 138)
			{
				DomainManager.World.TriggerExtraTask(context, 0, 19);
			}
			else if (taiwuLocation.AreaId == DomainManager.Taiwu.GetTaiwuVillageLocation().AreaId)
			{
				DomainManager.World.TriggerExtraTask(context, 0, 20);
			}
		}
	}

	[NewDomainDataInitializer(12, 28)]
	private void InitNeedToNotifyNewMonth()
	{
		_needToNotifyNewMonth = true;
	}

	private void OnCombatBegin(DataContext context)
	{
		InCombatBegin = false;
	}

	public override void OnUpdate(DataContext context)
	{
		_scriptRuntime?.Update();
	}

	private void OnInitializedDomainData()
	{
		MainThreadDataContext = DataContextManager.GetCurrentThreadDataContext();
		_argBoxPool = new LocalObjectPool<EventArgBox>(5, 65535);
		SetHasListeningEvent(value: false, MainThreadDataContext);
		SetRightRoleXiangshuDisplayData(new sbyte[2] { 9, 0 }, MainThreadDataContext);
	}

	private void InitializeOnInitializeGameDataModule()
	{
		_eventManager = new GameData.Domains.TaiwuEvent.EventManager.EventManager();
		_scriptRuntime = new EventScriptRuntime(MainThreadDataContext, enableDebugging: true);
		InitConchShipEvents();
		InitializeBlockTriggerActionKeys();
	}

	private void InitializeOnEnterNewWorld()
	{
		InitRuntimeEnvironment();
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void OnLoadedArchiveData()
	{
		InitRuntimeEnvironment();
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void PackCrossArchiveGameData(CrossArchiveGameData crossArchiveGameData)
	{
		base.PackCrossArchiveGameData(crossArchiveGameData);
		crossArchiveGameData.HandledOneShotEvents = new List<int>();
		crossArchiveGameData.HandledOneShotEvents.AddRange(_handledOneShotEvents.Keys);
	}

	private void InitRuntimeEnvironment()
	{
		_triggeredEventList = new List<TaiwuEvent>();
		ShowingEvent = TaiwuEvent.Empty;
		_notifyData = EventNotifyData.Empty;
		SetTempCreateItemList(new List<ItemKey>(), MainThreadDataContext);
		_eventManager?.ClearExtendOptions();
		ScriptRuntime.ResetCache();
		string runtimeSettingsPath = Path.Combine(GameData.ArchiveData.Common.ArchiveBaseDir, "EventScriptRuntimeSettings.json");
		ScriptRuntime.LoadSettings(runtimeSettingsPath);
		_doWhileLayer = 0;
		Events.RegisterHandler_AdvanceMonthBegin(OnAdvanceMonthBegin);
	}

	private bool CanNextEvent()
	{
		if (_stopAutoNextEvent)
		{
			return false;
		}
		if (DomainManager.Taiwu.GetLegacyPassingState() != 0)
		{
			return false;
		}
		TaiwuEvent topEvent = null;
		if (_triggeredEventList.Count > 0)
		{
			topEvent = _triggeredEventList[0];
		}
		if (topEvent == null)
		{
			return false;
		}
		if (DomainManager.World.GetAdvancingMonthState() == 14 && !CanTriggerInAdvanceMonth(topEvent.EventConfig.TriggerType))
		{
			return false;
		}
		if ((DomainManager.Combat.IsInCombat() && !CanTriggerInCombat(topEvent.EventConfig.TriggerType)) || (InCombatBegin && !CanTriggerInCombatBegin(topEvent.EventConfig.TriggerType)))
		{
			return false;
		}
		return true;
	}

	private static void ClearHostileInteractionPendingArgBoxKeys(EventArgBox argBox)
	{
		if (argBox != null)
		{
			string selectItemKey = EventTriggerParameter.DefValue.SelectInventoryItemKey.ArgBoxKey;
			argBox.RemoveKey(selectItemKey);
			argBox.RemoveKey(selectItemKey + "Count");
			argBox.RemoveKey("GiftKey");
			argBox.RemoveKey("GiftKeyCount");
			argBox.RemoveKey("ConchShip_PresetKey_ConfirmWaitOptionSignal");
			argBox.RemoveKey("ActionThenState");
		}
	}

	private void ClearWaitConfirmOptionState()
	{
		_waitConfirmOptionKey = string.Empty;
		_waitConfirmEventConfig = null;
		_waitConfirmSelectOption = string.Empty;
	}

	private void ResetArgBoxEventSelectData(EventArgBox argBox)
	{
		if (argBox != null)
		{
			argBox.Set("SelectItemInfo", (ISerializableGameData)null);
			argBox.Set("SelectCharacterData", (ISerializableGameData)null);
			argBox.Set("InputRequestData", (ISerializableGameData)null);
			argBox.Set("SelectReadingBookCount", (ISerializableGameData)null);
			argBox.Set("SelectNeigongLoopingCount", (ISerializableGameData)null);
			argBox.Set("SelectFameData", (ISerializableGameData)null);
			argBox.Set("SelectFuyuFaithCount", (ISerializableGameData)null);
		}
	}

	private void UpdateEventDisplayData()
	{
		TaiwuEvent showingEvent = ShowingEvent;
		if (showingEvent != null && !showingEvent.IsEmpty)
		{
			_doWhileLayer++;
			_eventEnteredList.Clear();
			TaiwuEvent eventItem;
			do
			{
				eventItem = ShowingEvent;
				if (!_eventEnteredList.Contains(eventItem.EventGuid))
				{
					_eventEnteredList.Add(eventItem.EventGuid);
					if (!ShowingEvent.TryExecuteScript(_scriptRuntime))
					{
						ShowingEvent.EventConfig.OnEventEnter();
					}
				}
			}
			while (eventItem != ShowingEvent && !ShowingEvent.IsEmpty);
			_doWhileLayer--;
		}
		try
		{
			showingEvent = ShowingEvent;
			if (showingEvent != null && !showingEvent.IsEmpty)
			{
				if (!string.IsNullOrEmpty(ShowingEvent.EventConfig.TargetRoleKey))
				{
					GameData.Domains.Character.Character targetChar = ShowingEvent.ArgBox.GetCharacter(ShowingEvent.EventConfig.TargetRoleKey);
					if (targetChar != null && targetChar.GetId() != EventArgBox.TaiwuCharacterId)
					{
						if (targetChar.GetCreatingType() == 1)
						{
							DomainManager.Character.TryCreateRelation(MainThreadDataContext, EventArgBox.TaiwuCharacterId, targetChar.GetId());
						}
						DomainManager.Extra.AddInteractedCharacter(MainThreadDataContext, targetChar.GetId());
					}
					GameData.Domains.Character.Character mainChar = ShowingEvent.ArgBox.GetCharacter(ShowingEvent.EventConfig.MainRoleKey);
					if (mainChar != null && mainChar.GetId() != EventArgBox.TaiwuCharacterId)
					{
						if (mainChar.GetCreatingType() == 1)
						{
							DomainManager.Character.TryCreateRelation(MainThreadDataContext, EventArgBox.TaiwuCharacterId, mainChar.GetId());
						}
						DomainManager.Extra.AddInteractedCharacter(MainThreadDataContext, mainChar.GetId());
					}
				}
				if (_doWhileLayer == 0)
				{
					TaiwuEventDisplayData displayData = ShowingEvent.ToDisplayData();
					SetDisplayingEventData(displayData, MainThreadDataContext);
				}
				return;
			}
		}
		catch (Exception ex)
		{
			AdaptableLog.Info(ShowingEvent.EventGuid);
			AdaptableLog.Warning(ex.ToString());
			ShowingEvent = TaiwuEvent.Empty;
			if (_triggeredEventList.Count > 0)
			{
				NextEvent();
			}
		}
		SetDisplayingEventData(null, MainThreadDataContext);
		if (!IsShowingEvent && _triggeredEventList.Count <= 0)
		{
			Events.RaiseEventHandleComplete(MainThreadDataContext);
		}
	}

	private void TriggerHandled()
	{
		List<TaiwuEvent> triggeredEventList = _triggeredEventList;
		bool ignoreShowingEvent = triggeredEventList != null && triggeredEventList.Count > 0 && _triggeredEventList.First().EventConfig.TriggerType == 41;
		if (!ignoreShowingEvent)
		{
			TaiwuEvent showingEvent = ShowingEvent;
			if (showingEvent != null && !showingEvent.IsEmpty)
			{
				return;
			}
		}
		if (_triggeredEventList == null || _triggeredEventList.Count <= 0)
		{
			Events.RaiseEventHandleComplete(MainThreadDataContext);
			return;
		}
		if (!ignoreShowingEvent)
		{
			TaiwuEvent showingEvent = ShowingEvent;
			if (showingEvent == null || !showingEvent.IsEmpty)
			{
				return;
			}
		}
		if (CanNextEvent())
		{
			NextEvent();
		}
	}

	private void NextEvent()
	{
		ShowingEvent = TaiwuEvent.Empty;
		if (_triggeredEventList.Count <= 0)
		{
			SetDisplayingEventData(null, MainThreadDataContext);
			return;
		}
		int i = 0;
		for (int max = _triggeredEventList.Count; i < max; i++)
		{
			if (_triggeredEventList[i].EventConfig.CheckCondition())
			{
				ShowingEvent = _triggeredEventList[i];
				_triggeredEventList.RemoveAt(i);
				break;
			}
		}
		TaiwuEvent showingEvent = ShowingEvent;
		if (showingEvent != null && showingEvent.IsEmpty)
		{
			_triggeredEventList.ForEach(delegate(TaiwuEvent e)
			{
				AdaptableLog.Warning("event " + e.EventGuid + " has triggered but failed to execute,removed trigger");
				e.ArgBox = null;
			});
			_triggeredEventList.Clear();
		}
		UpdateEventDisplayData();
	}

	private bool CanTriggerInAdvanceMonth(short triggerType)
	{
		return triggerType >= 0 && EventTriggerType.Instance[triggerType].CanTriggerInAdvanceMonth;
	}

	private bool CanTriggerInCombat(short triggerType)
	{
		return triggerType >= 0 && EventTriggerType.Instance[triggerType].CanTriggerInCombat;
	}

	private bool CanTriggerInCombatBegin(short triggerType)
	{
		return triggerType >= 0 && EventTriggerType.Instance[triggerType].CanTriggerInCombatBegin;
	}

	private void HandleOptionConsume(TaiwuEventOption option, string mainRoleKey, string targetRoleKey)
	{
		if (option == null || option.OptionConsumeInfos == null)
		{
			return;
		}
		GameData.Domains.Character.Character taiwu = option.ArgBox.GetCharacter("RoleTaiwu");
		GameData.Domains.Character.Character target = null;
		if (!string.IsNullOrEmpty(targetRoleKey))
		{
			target = option.ArgBox.GetCharacter(targetRoleKey);
		}
		bool hasExpression = option.OptionConsumeAmountExpressions != null;
		for (int i = 0; i < option.OptionConsumeInfos.Count; i++)
		{
			if (!hasExpression || !option.OptionConsumeAmountExpressions.TryGetValue(i, out var expression))
			{
				expression = null;
			}
			OptionConsumeInfo consumeInfo = OptionConsumeHelper.ModifyOptionConsumeInfo(option.OptionConsumeInfos[i], option.ArgBox, expression);
			consumeInfo.DoConsume(taiwu.GetId(), target?.GetId() ?? (-1));
		}
	}

	private void HandlerOptionEffect(TaiwuEventOption option)
	{
		if (option == null)
		{
			return;
		}
		sbyte behaviorType = EventOptionBehavior.ToBehaviorType[option.Behavior];
		if (behaviorType != -1)
		{
			DomainManager.Global.InvokeGuidingTrigger(MainThreadDataContext, 223);
			GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
			sbyte taiwuBehaviorType = taiwuChar.GetBehaviorType();
			if (taiwuBehaviorType == behaviorType)
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ChangeRoleHappiness(taiwuChar, 5);
				AchievementManager.RequestSetStat(MainThreadDataContext, 90, 1);
			}
			else if (GameData.Domains.Character.BehaviorType.IsContradictory(taiwuBehaviorType, behaviorType))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ChangeRoleHappiness(taiwuChar, -5);
				AchievementManager.RequestSetStat(MainThreadDataContext, 91, 1);
			}
			short delta = GameData.Domains.Character.BehaviorType.GetBehaviorChangeDeltaByEventSelect(behaviorType, taiwuChar.GetBaseMorality());
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ChangeRoleBaseBehaviorValue(taiwuChar, delta);
		}
	}

	private bool IsCharacterRelatedToEvent(TaiwuEvent eventItem, int charId)
	{
		if (eventItem.IsEmpty)
		{
			return false;
		}
		if (!string.IsNullOrEmpty(eventItem.EventConfig.MainRoleKey))
		{
			int mainCharId = -1;
			if (eventItem.ArgBox.Get(eventItem.EventConfig.MainRoleKey, ref mainCharId) && mainCharId == charId)
			{
				return true;
			}
		}
		if (!string.IsNullOrEmpty(eventItem.EventConfig.TargetRoleKey))
		{
			int targetCharId = -1;
			if (eventItem.ArgBox.Get(eventItem.EventConfig.TargetRoleKey, ref targetCharId) && targetCharId == charId)
			{
				return true;
			}
		}
		return false;
	}

	private void OnAdvanceMonthBegin(DataContext context)
	{
		List<ItemKey> tempCreatedItemKeyList = GetTempCreateItemList();
		if (tempCreatedItemKeyList != null && tempCreatedItemKeyList.Count > 0)
		{
			DomainManager.Item.RemoveItems(context, tempCreatedItemKeyList);
		}
		tempCreatedItemKeyList.Clear();
		SetTempCreateItemList(tempCreatedItemKeyList, MainThreadDataContext);
		_executedOncePerMonthOptions.Clear();
	}

	private bool IsEventStay(string eventGuid, string optionKey)
	{
		if (_selectInformationData != null && _selectInformationData.AvailableData && !_selectInformationData.SelectComplete)
		{
			if (_selectInformationData.IsForShopping)
			{
				return false;
			}
			_selectInformationData.SelectForEventGuid = eventGuid;
			_selectInformationData.SelectForOptionKey = optionKey;
			return true;
		}
		if (_cricketBettingData.IsValid && !_cricketBettingData.IsComplete)
		{
			_cricketBettingData.SelectForEventGuid = eventGuid;
			_cricketBettingData.SelectForOptionKey = optionKey;
			return true;
		}
		return false;
	}

	public EventArgBox GetEventArgBox()
	{
		EventArgBox argBox = _argBoxPool.Get();
		argBox.Clear();
		return argBox;
	}

	public void ReturnArgBox(EventArgBox argBox)
	{
		if (argBox != null)
		{
			argBox.Clear();
			_argBoxPool.Return(argBox);
		}
	}

	public bool IsTriggeredEvent(string guid)
	{
		if (ShowingEvent != null && ShowingEvent.EventGuid == guid)
		{
			return true;
		}
		if (_triggeredEventList != null)
		{
			foreach (TaiwuEvent eventItem in _triggeredEventList)
			{
				if (eventItem.EventGuid == guid)
				{
					return true;
				}
			}
		}
		return false;
	}

	public int GetEventTriggeredCount(string guid)
	{
		int count = 0;
		if (ShowingEvent != null && ShowingEvent.EventGuid == guid)
		{
			count++;
		}
		if (_triggeredEventList != null)
		{
			foreach (TaiwuEvent eventItem in _triggeredEventList)
			{
				if (eventItem.EventGuid == guid)
				{
					count++;
				}
			}
		}
		return count;
	}

	public void AddTriggeredEvent(TaiwuEvent eventItem)
	{
		bool flag = false;
		if (_triggeredEventList.Count > 0)
		{
			for (int i = 0; i < _triggeredEventList.Count; i++)
			{
				if (_triggeredEventList[i].EventConfig.EventSortingOrder < eventItem.EventConfig.EventSortingOrder)
				{
					if (!_triggeredEventList.Contains(eventItem))
					{
						_triggeredEventList.Insert(i, eventItem);
					}
					flag = true;
					break;
				}
			}
		}
		if (!flag && !_triggeredEventList.Contains(eventItem))
		{
			_triggeredEventList.Add(eventItem);
		}
		if (!DomainManager.Adventure.QueryTaiwuInAny())
		{
			AdaptableLog.Info($"new Event triggered : {eventItem.EventGuid}, _triggeredEventList.Count = {_triggeredEventList.Count}");
		}
	}

	public void ToEvent(string eventGuid)
	{
		if (ShowingEvent.IsEmpty)
		{
			throw new Exception("Failed to new event " + eventGuid + " because no event showing!");
		}
		if (eventGuid == ShowingEvent.EventGuid)
		{
			throw new Exception(eventGuid + " try to use ToEvent to self,this is not allowed!");
		}
		ShowingEvent.EventConfig?.OnEventExit();
		if (!DomainManager.Adventure.QueryTaiwuInAny())
		{
			AdaptableLog.Info(ShowingEvent.EventGuid + " to event => " + eventGuid);
		}
		if (string.IsNullOrEmpty(eventGuid))
		{
			ShowingEvent = TaiwuEvent.Empty;
			if (CanNextEvent() && !GetHasListeningEvent())
			{
				NextEvent();
				return;
			}
			Events.RaiseEventHandleComplete(MainThreadDataContext);
			SetDisplayingEventData(null, MainThreadDataContext);
			if (DomainManager.World.GetAdvancingMonthState() != 0 && !GetHasListeningEvent())
			{
				DomainManager.World.SetOnHandingMonthlyEventBlock(value: false, DataContextManager.GetCurrentThreadDataContext());
			}
			return;
		}
		TaiwuEvent eventItem = GetEvent(eventGuid);
		if (eventItem == null)
		{
			return;
		}
		eventItem.ArgBox = ShowingEvent.ArgBox;
		ShowingEvent.ArgBox = null;
		if (eventItem.EventConfig.CheckCondition())
		{
			ShowingEvent = eventItem;
			return;
		}
		eventItem.ArgBox = null;
		if (CanNextEvent())
		{
			NextEvent();
		}
		else
		{
			ShowingEvent = TaiwuEvent.Empty;
		}
	}

	public void SetStopAutoNextEvent(bool flag)
	{
		_stopAutoNextEvent = flag;
	}

	public TaiwuEvent GetEvent(string guid)
	{
		return _eventManager.GetEvent(guid);
	}

	public void AdventureEventCheckComplete()
	{
		TriggerHandled();
	}

	public void TravelingEventCheckComplete()
	{
		TriggerHandled();
	}

	public IReadOnlyList<short> GetNeedToShowLegacies()
	{
		return _needToShowLegacies;
	}

	public IReadOnlyList<short> GetNeedToShowFeatures()
	{
		return _needToShowFeatures;
	}

	public void AddNeedToShowLegacies(short id)
	{
		_needToShowLegacies.Add(id);
		if (_showingEvent.IsEmpty)
		{
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Legacy, _needToShowLegacies, (sbyte)1);
			_needToShowLegacies.Clear();
		}
	}

	public void AddNeedToShowFeatures(short id)
	{
		_needToShowFeatures.Add(id);
		if (_showingEvent.IsEmpty)
		{
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Feature, _needToShowFeatures, (sbyte)13);
			_needToShowLegacies.Clear();
		}
	}

	public void ClearNeedToShowLegacies()
	{
		_needToShowLegacies.Clear();
	}

	public void ClearNeedToShowFeatures()
	{
		_needToShowFeatures.Clear();
	}

	[DomainMethod]
	public void SetItemSelectResult(string key, ItemKey itemKey, bool callComplete)
	{
		if (ShowingEvent != null && !string.IsNullOrEmpty(key) && ShowingEvent.ArgBox.Get("SelectItemInfo", out EventSelectItemData data))
		{
			ShowingEvent.ArgBox.Set(key, itemKey);
			if (callComplete)
			{
				data.OnSelectFinish?.Invoke();
			}
		}
	}

	[DomainMethod]
	public void SetItemSelectCount(string key, int count)
	{
		if (ShowingEvent != null && !string.IsNullOrEmpty(key) && ShowingEvent.ArgBox.Get("SelectItemInfo", out EventSelectItemData _))
		{
			ShowingEvent.ArgBox.Set(key + "Count", count);
		}
	}

	[DomainMethod]
	public void SetCharacterSelectResult(string key, int charId, bool callComplete)
	{
		if (ShowingEvent != null && !string.IsNullOrEmpty(key) && ShowingEvent.ArgBox.Get("SelectCharacterData", out EventSelectCharacterData selectCharacterData))
		{
			ShowingEvent.ArgBox.Set(key, charId);
			if (callComplete)
			{
				selectCharacterData.OnSelectComplete?.Invoke();
			}
		}
	}

	[DomainMethod]
	public void SetCharacterMultSelectResult(string key, List<int> charIds, bool callComplete)
	{
		if (ShowingEvent != null && !string.IsNullOrEmpty(key) && ShowingEvent.ArgBox.Get("SelectCharacterData", out EventSelectCharacterData selectCharacterData))
		{
			IntList characters = IntList.Create();
			characters.Items = charIds;
			ShowingEvent.ArgBox.Set(key, characters);
			if (callComplete)
			{
				selectCharacterData.OnSelectComplete?.Invoke();
			}
		}
	}

	[DomainMethod]
	public void SetCharacterSetSelectResult(string actionName, string key, CharacterSet characterSet)
	{
		if (string.IsNullOrEmpty(key))
		{
			return;
		}
		for (int i = 0; i < ListeningEventActionList.Count; i++)
		{
			if (ListeningEventActionList[i].listeningAction.Equals(actionName))
			{
				TaiwuEvent item = ListeningEventActionList[i].listenerEvent;
				if (item != null && !item.IsEmpty)
				{
					ListeningEventActionList[i].listenerEvent.ArgBox.Set(key, characterSet);
				}
			}
		}
	}

	[DomainMethod]
	public void SetSecretInformationSelectResult(string key, int secretId)
	{
		if (_selectInformationData != null)
		{
			if (((SecretInformationId)secretId).Valid)
			{
				ShowingEvent.ArgBox.Set(key, secretId);
				_selectInformationData.SelectComplete = true;
				EventSelect(_selectInformationData.SelectForEventGuid, _selectInformationData.SelectForOptionKey);
			}
			else
			{
				UpdateEventDisplayData();
			}
			SetSelectInformationData(null, MainThreadDataContext);
		}
	}

	[DomainMethod]
	public void UpdateShowingEventTaiwuCharacterDisplayData()
	{
		TaiwuEventDisplayData displayData = GetDisplayingEventData();
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		if (displayData.MainCharacter.CharacterId == taiwuId)
		{
			CharacterDisplayData taiwuCharacterDisplayData = DomainManager.Character.GetCharacterDisplayData(taiwuId);
			displayData.MainCharacter = taiwuCharacterDisplayData;
			SetDisplayingEventData(displayData, MainThreadDataContext);
		}
		else if (displayData.TargetCharacter.CharacterId == taiwuId)
		{
			CharacterDisplayData taiwuCharacterDisplayData2 = DomainManager.Character.GetCharacterDisplayData(taiwuId);
			displayData.TargetCharacter = taiwuCharacterDisplayData2;
			SetDisplayingEventData(displayData, MainThreadDataContext);
		}
	}

	[DomainMethod]
	public void SetNormalInformationSelectResult(string key, NormalInformation normalInformation)
	{
		if (_selectInformationData != null)
		{
			if (normalInformation.IsValid())
			{
				ShowingEvent.ArgBox.Set(key, normalInformation);
				_selectInformationData.SelectComplete = true;
				EventSelect(_selectInformationData.SelectForEventGuid, _selectInformationData.SelectForOptionKey);
			}
			else
			{
				UpdateEventDisplayData();
			}
			SetSelectInformationData(null, MainThreadDataContext);
		}
	}

	[DomainMethod]
	public void SetCombatSkillSelectResult(short combatSkillId)
	{
		TaiwuEvent showingEvent = ShowingEvent;
		if (showingEvent != null && !showingEvent.IsEmpty && _selectCombatSkillData != null)
		{
			if (combatSkillId >= 0)
			{
				ShowingEvent.ArgBox.Set(_selectCombatSkillData.ResultSaveKey, combatSkillId);
			}
			SetSelectCombatSkillData(null, MainThreadDataContext);
		}
	}

	[DomainMethod]
	public void SetLifeSkillSelectResult(short lifeSkillId)
	{
		TaiwuEvent showingEvent = ShowingEvent;
		if (showingEvent != null && !showingEvent.IsEmpty && _selectLifeSkillData != null)
		{
			if (lifeSkillId >= 0)
			{
				ShowingEvent.ArgBox.Set(_selectLifeSkillData.ResultSaveKey, lifeSkillId);
			}
			SetSelectLifeSkillData(null, MainThreadDataContext);
		}
	}

	[DomainMethod]
	public void SetCricketBettingResult(bool ok, Wager wager, int index)
	{
		if (_cricketBettingData.IsValid)
		{
			_cricketBettingData.IsValid = false;
			_cricketBettingData.IsComplete = ok;
			_cricketBettingData.IsConfirmed = ok;
			_cricketBettingData.Wager = wager;
			_cricketBettingData.Index = index;
			SetCricketBettingData(_cricketBettingData, MainThreadDataContext);
			if (ok)
			{
				CricketWagerData data = _cricketBettingData.BetRewards[index];
				DomainManager.Item.SetWager(wager, data.Wager);
				EventSelect(_cricketBettingData.SelectForEventGuid, _cricketBettingData.SelectForOptionKey);
			}
			else
			{
				UpdateEventDisplayData();
			}
		}
	}

	[DomainMethod]
	public void SetSelectCount(int count)
	{
		if (ShowingEvent != null)
		{
			ShowingEvent.ArgBox.Set("SelectCountResult", count);
		}
	}

	[DomainMethod]
	public void StartHandleEventDuringAdvance()
	{
		NextEvent();
	}

	[DomainMethod]
	public List<TaiwuEventSummaryDisplayData> GetTriggeredEventSummaryDisplayData()
	{
		List<TaiwuEventSummaryDisplayData> list = new List<TaiwuEventSummaryDisplayData>();
		foreach (TaiwuEvent item in _triggeredEventList)
		{
			TaiwuEventSummaryDisplayData data = item.ToSummaryDisplayData();
			if (data != null)
			{
				list.Add(data);
			}
		}
		return list;
	}

	[DomainMethod]
	public void SetEventInProcessing(string eventGuid)
	{
		foreach (TaiwuEvent eventItem in _triggeredEventList)
		{
			if (eventItem.EventGuid == eventGuid)
			{
				ShowingEvent = eventItem;
				_triggeredEventList.Remove(eventItem);
				UpdateEventDisplayData();
				break;
			}
		}
	}

	public void ProcessEventWithDefaultOption(string guid, EventArgBox eventArgBox, sbyte behaviorType)
	{
		HashSet<string> selected = ObjectPool<HashSet<string>>.Instance.Get();
		selected.Clear();
		while (!string.IsNullOrEmpty(guid))
		{
			if (!selected.Add(guid))
			{
				throw new Exception("Loop detected when executing event " + guid);
			}
			TaiwuEvent taiwuEvent = GetEvent(guid);
			if (taiwuEvent.ArgBox != null)
			{
				ReturnArgBox(taiwuEvent.ArgBox);
			}
			taiwuEvent.ArgBox = eventArgBox;
			_triggeredEventList.Remove(taiwuEvent);
			if (!taiwuEvent.EventConfig.CheckCondition())
			{
				break;
			}
			taiwuEvent.EventConfig.OnEventEnter();
			if (string.IsNullOrEmpty(taiwuEvent.EventConfig.EscOptionKey))
			{
				if (taiwuEvent.EventConfig.EventOptions == null || taiwuEvent.EventConfig.EventOptions.Length == 0)
				{
					Logger.AppendWarning("Monthly event " + taiwuEvent.EventGuid + " has no option detected when trying to process with default option.");
					guid = string.Empty;
				}
				else
				{
					bool optionSelected = false;
					TaiwuEventOption[] eventOptions = taiwuEvent.EventConfig.EventOptions;
					foreach (TaiwuEventOption option in eventOptions)
					{
						if (EventOptionBehavior.ToBehaviorType[option.Behavior] == behaviorType)
						{
							guid = option.Select(_scriptRuntime);
							optionSelected = true;
							break;
						}
					}
					if (!optionSelected)
					{
						Logger.AppendWarning("Monthly event " + taiwuEvent.EventGuid + " has neither esc option nor behavior option to handle as default.");
						guid = string.Empty;
					}
				}
			}
			else
			{
				guid = taiwuEvent.EventConfig[taiwuEvent.EventConfig.EscOptionKey].Select(_scriptRuntime);
			}
			taiwuEvent.EventConfig.OnEventExit();
			taiwuEvent.ArgBox = null;
		}
		ObjectPool<HashSet<string>>.Instance.Return(selected);
	}

	[DomainMethod]
	public void EventSelect(string eventGuid, string optionKey, bool isContinue = false)
	{
		if (_showingEvent == null)
		{
			return;
		}
		TaiwuEvent showingEvent = ShowingEvent;
		if ((showingEvent != null && showingEvent.IsEmpty) || eventGuid != ShowingEvent.EventGuid)
		{
			return;
		}
		TaiwuEventItem eventConfig = ShowingEvent.EventConfig;
		EventArgBox passBox = ShowingEvent.ArgBox;
		TaiwuEventOption option = eventConfig[optionKey];
		string guidString;
		if (isContinue)
		{
			ShowInteractCheckAnimation = false;
			guidString = _interactCheckContinueData.nextGuid;
			_interactCheckContinueData = (EventGuid: string.Empty, OptionKey: string.Empty, nextGuid: string.Empty);
		}
		else
		{
			guidString = option.Select(_scriptRuntime);
		}
		if (!isContinue && !string.IsNullOrEmpty(eventConfig.EscOptionKey) && eventConfig.EscOptionKey == optionKey)
		{
			ClearHostileInteractionPendingArgBoxKeys(passBox);
			ClearWaitConfirmOptionState();
		}
		else if (!string.IsNullOrEmpty(guidString) && HostileSelectItemEventGuids.Contains(guidString))
		{
			ClearHostileInteractionPendingArgBoxKeys(passBox);
		}
		if (ShowInteractCheckAnimation)
		{
			_interactCheckContinueData = (EventGuid: eventGuid, OptionKey: optionKey, nextGuid: guidString);
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.InteractCheckAnimation, InteractCheckData);
			return;
		}
		int eventLogMainCharacterId = -1;
		GenerateResponseLog(optionKey, passBox.Get("ConchShip_PresetKey_EventLogMainCharacter", ref eventLogMainCharacterId) ? eventLogMainCharacterId : (-1));
		if (IsEventStay(eventGuid, optionKey))
		{
			return;
		}
		string waitConfirmKey = string.Empty;
		if (eventConfig.ArgBox.Get("ConchShip_PresetKey_OptionWaitConfirm", ref waitConfirmKey))
		{
			ClearHostileInteractionPendingArgBoxKeys(passBox);
			_waitConfirmOptionKey = waitConfirmKey;
			_waitConfirmEventConfig = eventConfig;
			_waitConfirmSelectOption = optionKey;
			eventConfig.ArgBox.Remove<string>("ConchShip_PresetKey_OptionWaitConfirm");
		}
		else
		{
			string confirmSignalKey = string.Empty;
			bool confirmedWaitOption = false;
			if (eventConfig.ArgBox.Get("ConchShip_PresetKey_ConfirmWaitOptionSignal", ref confirmSignalKey))
			{
				if (confirmSignalKey == _waitConfirmOptionKey && _waitConfirmEventConfig != null)
				{
					confirmedWaitOption = true;
					_waitConfirmEventConfig.ArgBox = eventConfig.ArgBox;
					HandleOptionConsume(_waitConfirmEventConfig[_waitConfirmSelectOption], _waitConfirmEventConfig.MainRoleKey, _waitConfirmEventConfig.TargetRoleKey);
					HandlerOptionEffect(_waitConfirmEventConfig[_waitConfirmSelectOption]);
				}
				eventConfig.ArgBox.Remove<string>("ConchShip_PresetKey_ConfirmWaitOptionSignal");
			}
			if (confirmedWaitOption)
			{
				ClearWaitConfirmOptionState();
			}
			else if (!string.IsNullOrEmpty(_waitConfirmOptionKey))
			{
				ClearHostileInteractionPendingArgBoxKeys(passBox);
				ClearWaitConfirmOptionState();
			}
			HandleOptionConsume(eventConfig[optionKey], eventConfig.MainRoleKey, eventConfig.TargetRoleKey);
			HandlerOptionEffect(eventConfig[optionKey]);
		}
		eventConfig.OnEventExit();
		ResetArgBoxEventSelectData(passBox);
		if (string.IsNullOrEmpty(guidString))
		{
			if (GetHasListeningEvent())
			{
				TaiwuEvent showingEvent2 = _showingEvent;
				List<(string listeningAction, TaiwuEvent listenerEvent)> listeningEventActionList = ListeningEventActionList;
				if (showingEvent2 != listeningEventActionList[listeningEventActionList.Count - 1].listenerEvent)
				{
					ShowingEvent.ArgBox = null;
				}
			}
			ShowingEvent = TaiwuEvent.Empty;
			if (GetHasListeningEvent())
			{
				SetDisplayingEventData(null, MainThreadDataContext);
				Events.RaiseEventHandleComplete(MainThreadDataContext);
				return;
			}
			if (CanNextEvent())
			{
				NextEvent();
				return;
			}
			SetDisplayingEventData(null, MainThreadDataContext);
			Events.RaiseEventHandleComplete(MainThreadDataContext);
			if (DomainManager.World.GetAdvancingMonthState() != 0)
			{
				DomainManager.World.SetOnHandingMonthlyEventBlock(value: false, DataContextManager.GetCurrentThreadDataContext());
			}
			return;
		}
		AdaptableLog.Info("select option to next Event: " + guidString);
		ShowingEvent.ArgBox = null;
		TaiwuEvent nextEvent = GetEvent(guidString);
		if (nextEvent != null)
		{
			nextEvent.ArgBox = passBox;
			if (nextEvent.EventConfig.CheckCondition())
			{
				ShowingEvent = nextEvent;
				UpdateEventDisplayData();
			}
			else if (CanNextEvent())
			{
				NextEvent();
			}
			else
			{
				ShowingEvent = TaiwuEvent.Empty;
				SetDisplayingEventData(null, MainThreadDataContext);
				Events.RaiseEventHandleComplete(MainThreadDataContext);
			}
		}
		else
		{
			AdaptableLog.TagError("TaiwuEvent", "can not find event " + guidString);
		}
	}

	public void SetEventAfterInteractCheckResult(string nextEvent)
	{
		_eventAfterInteractCheckResult = nextEvent;
	}

	[DomainMethod]
	public void EventSelectContinue()
	{
		if (!string.IsNullOrEmpty(_eventAfterInteractCheckResult))
		{
			DomainManager.TaiwuEvent.TriggerListener("PlayInteractCheckAnimationFinish", value: true);
			SetEventAfterInteractCheckResult(string.Empty);
			ShowInteractCheckAnimation = false;
			_interactCheckContinueData = (EventGuid: string.Empty, OptionKey: string.Empty, nextGuid: string.Empty);
		}
		else
		{
			EventSelect(_interactCheckContinueData.EventGuid, _interactCheckContinueData.OptionKey, isContinue: true);
		}
	}

	[DomainMethod]
	public List<int> GetImplementedFunctionIds(DataContext context)
	{
		return new List<int>(_scriptRuntime.ImplementedFunctionIds);
	}

	[DomainMethod]
	[Obsolete("use UpdateEventDisplayData instead")]
	public List<TaiwuEventDisplayData> GetEventDisplayData()
	{
		return null;
	}

	[DomainMethod]
	public void SetShowingEventShortListArg(string key, GameData.Utilities.ShortList value)
	{
		if (ShowingEvent != null)
		{
			ShowingEvent.ArgBox.Set(key, value);
		}
	}

	[DomainMethod]
	public void SetShowingEventItemKeyArg(string key, ItemKey value)
	{
		if (ShowingEvent != null)
		{
			ShowingEvent.ArgBox.Set(key, value);
		}
	}

	[DomainMethod]
	public void SetShowingEventShortArg(string key, short value)
	{
		if (ShowingEvent != null)
		{
			ShowingEvent.ArgBox.Set(key, value);
		}
	}

	public void AppendMarriageLook1CharId(int charId)
	{
		if (_marriageLook1CharIdList == null)
		{
			_marriageLook1CharIdList = new List<int>();
		}
		if (!_marriageLook1CharIdList.Contains(charId))
		{
			_marriageLook1CharIdList.Add(charId);
			SetMarriageLook1CharIdList(_marriageLook1CharIdList, MainThreadDataContext);
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				character.SetAvatar(character.GetAvatar(), MainThreadDataContext);
			}
		}
	}

	public void RemoveMarriageLook1CharId(int charId)
	{
		if (_marriageLook1CharIdList != null && _marriageLook1CharIdList.Contains(charId))
		{
			_marriageLook1CharIdList.Remove(charId);
			SetMarriageLook1CharIdList(_marriageLook1CharIdList, MainThreadDataContext);
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				character.SetAvatar(character.GetAvatar(), MainThreadDataContext);
			}
		}
	}

	public void AppendMarriageLook2CharId(int charId)
	{
		if (_marriageLook2CharIdList == null)
		{
			_marriageLook2CharIdList = new List<int>();
		}
		if (!_marriageLook2CharIdList.Contains(charId))
		{
			_marriageLook2CharIdList.Add(charId);
			SetMarriageLook2CharIdList(_marriageLook2CharIdList, MainThreadDataContext);
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				character.SetAvatar(character.GetAvatar(), MainThreadDataContext);
			}
		}
	}

	public void RemoveMarriageLook2CharId(int charId)
	{
		if (_marriageLook2CharIdList != null && _marriageLook2CharIdList.Contains(charId))
		{
			_marriageLook2CharIdList.Remove(charId);
			SetMarriageLook2CharIdList(_marriageLook2CharIdList, MainThreadDataContext);
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				character.SetAvatar(character.GetAvatar(), MainThreadDataContext);
			}
		}
	}

	public void ClearAllMarriageLook()
	{
		_marriageLook1CharIdList?.Clear();
		_marriageLook2CharIdList?.Clear();
		SetMarriageLook1CharIdList(_marriageLook1CharIdList, MainThreadDataContext);
		SetMarriageLook2CharIdList(_marriageLook2CharIdList, MainThreadDataContext);
	}

	public void ClearAllTriggeredEvent()
	{
		if (ListeningEventActionList.Count > 0)
		{
			foreach (var listeningEventAction in ListeningEventActionList)
			{
				ReturnArgBox(listeningEventAction.listenerEvent.ArgBox);
			}
			ListeningEventActionList.Clear();
			SetHasListeningEvent(value: false, MainThreadDataContext);
		}
		foreach (TaiwuEvent queueEvent in _triggeredEventList)
		{
			ReturnArgBox(queueEvent.ArgBox);
		}
		_triggeredEventList.Clear();
	}

	public void OnPassingLegacyStateChange(sbyte newState)
	{
		if (newState == 0 && ShowingEvent.IsEmpty)
		{
			SetLegacyReason(-1);
			NextEvent();
		}
	}

	public void SetTaiwuLocationDirtyFlag()
	{
		_taiwuLocationChangeFlag = !_taiwuLocationChangeFlag;
		SetTaiwuLocationChangeFlag(_taiwuLocationChangeFlag, MainThreadDataContext);
	}

	public void OnCharacterRemoved(int charId)
	{
		if (_triggeredEventList.Count <= 0)
		{
			return;
		}
		for (int i = _triggeredEventList.Count - 1; i >= 0; i--)
		{
			TaiwuEvent eventItem = _triggeredEventList[i];
			if (IsCharacterRelatedToEvent(eventItem, charId))
			{
				_triggeredEventList.RemoveAt(i);
			}
		}
	}

	public void GMCharacterDie(int charId)
	{
		TaiwuEvent showingEvent = ShowingEvent;
		if (showingEvent != null && !showingEvent.IsEmpty && IsCharacterRelatedToEvent(ShowingEvent, charId))
		{
			ShowingEvent = TaiwuEvent.Empty;
			UpdateEventDisplayData();
		}
	}

	public void SetLegacyReason(sbyte reason)
	{
		LegacyReason = reason;
	}

	public void ShowCgTexture(short cgTextureTemplateId)
	{
		if (cgTextureTemplateId < 0)
		{
			float tweenTime = _currCgTextureItem?.AnimDuration ?? 1f;
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ShowEventCgTexture, string.Empty, tweenTime);
			_currCgTextureItem = null;
		}
		else
		{
			_currCgTextureItem = EventCgTexture.Instance[cgTextureTemplateId];
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ShowEventCgTexture, _currCgTextureItem.ResourceFormat, _currCgTextureItem.AnimDuration);
		}
	}

	public void ShowCgTextureInPictureShowPage(EventScriptRuntime runtime, short cgTextureTemplateId, string onFinishEvent)
	{
		bool hasFollowupEvent = !string.IsNullOrEmpty(onFinishEvent);
		string actionName = (hasFollowupEvent ? "TextureShowCountDown" : string.Empty);
		if (cgTextureTemplateId < 0)
		{
			float waitTime = _currCgTextureItemOnPictureShowPage?.AnimDuration ?? (-1f);
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenPictureShow, string.Empty, "CG", actionName, -1, waitTime, string.Empty);
			_currCgTextureItemOnPictureShowPage = null;
			return;
		}
		_currCgTextureItemOnPictureShowPage = EventCgTexture.Instance[cgTextureTemplateId];
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenPictureShow, _currCgTextureItemOnPictureShowPage.ResourceFormat, "CG", actionName, -1, _currCgTextureItemOnPictureShowPage.AnimDuration, string.Empty);
		if (hasFollowupEvent)
		{
			SetListenerWithActionName(onFinishEvent, runtime.ArgBox, actionName);
		}
	}

	private void InitializeBlockTriggerActionKeys()
	{
		BlockTriggerActionKeys.Clear();
		foreach (EventActionKeyItem actionKeyItem in (IEnumerable<EventActionKeyItem>)EventActionKey.Instance)
		{
			if (actionKeyItem.BlockTrigger)
			{
				BlockTriggerActionKeys.Add(actionKeyItem.KeyCode);
			}
		}
	}

	[DomainMethod]
	public bool CheckIsShowingEvent()
	{
		return IsShowingEvent;
	}

	public bool CheckListenedEventBlockTrigger()
	{
		List<(string, TaiwuEvent)> listeningEventActionList = ListeningEventActionList;
		if (listeningEventActionList == null || listeningEventActionList.Count <= 0)
		{
			return false;
		}
		foreach (var listenedEvent in ListeningEventActionList)
		{
			if (BlockTriggerActionKeys.Contains(listenedEvent.listeningAction))
			{
				return true;
			}
		}
		return false;
	}

	public void SetListenerWithActionName(string listenerEventGuid, EventArgBox eventBox, string actionName)
	{
		if (string.IsNullOrEmpty(listenerEventGuid))
		{
			return;
		}
		TaiwuEvent targetEvent = GetEvent(listenerEventGuid);
		if (targetEvent != null)
		{
			eventBox?.Remove<bool>(actionName);
			targetEvent.ArgBox = eventBox;
			if (!ListeningEventActionList.Contains((actionName, targetEvent)))
			{
				ListeningEventActionList.Add((actionName, targetEvent));
			}
			else
			{
				AdaptableLog.Info($"actionName:{actionName},listenerEventGuid:{listenerEventGuid} repeated");
			}
			SetHasListeningEvent(ListeningEventActionList.Count > 0, MainThreadDataContext);
		}
	}

	public void RemoveEventInListenWithActionName(string eventGuid, string actionName)
	{
		for (int i = ListeningEventActionList.Count - 1; i >= 0; i--)
		{
			if (ListeningEventActionList[i].listeningAction.Equals(actionName) && ListeningEventActionList[i].listenerEvent.EventGuid.Equals(eventGuid))
			{
				ListeningEventActionList.RemoveAt(i);
			}
		}
		SetHasListeningEvent(ListeningEventActionList.Count > 0, MainThreadDataContext);
	}

	public void ClearListeningEvent()
	{
		ListeningEventActionList.Clear();
	}

	[DomainMethod]
	public void TriggerListener(string key, bool value)
	{
		(string, TaiwuEvent) triggeredListeningEventAction = (string.Empty, TaiwuEvent.Empty);
		for (int i = ListeningEventActionList.Count - 1; i >= 0; i--)
		{
			if (ListeningEventActionList[i].listeningAction.Equals(key))
			{
				triggeredListeningEventAction = ListeningEventActionList[i];
				ListeningEventActionList.RemoveAt(i);
				break;
			}
		}
		if (string.IsNullOrEmpty(triggeredListeningEventAction.Item1) || triggeredListeningEventAction.Item2.IsEmpty)
		{
			SetHasListeningEvent(ListeningEventActionList.Count > 0, MainThreadDataContext);
			Events.RaiseEventHandleComplete(MainThreadDataContext);
			return;
		}
		if (!string.IsNullOrEmpty(key))
		{
			triggeredListeningEventAction.Item2.ArgBox.Set(key, value);
		}
		SetHasListeningEvent(ListeningEventActionList.Count > 0, MainThreadDataContext);
		if (triggeredListeningEventAction.Item2.EventConfig.CheckCondition())
		{
			ShowingEvent = triggeredListeningEventAction.Item2;
			UpdateEventDisplayData();
		}
		else
		{
			Events.RaiseEventHandleComplete(MainThreadDataContext);
		}
	}

	[DomainMethod]
	public void SetListenerEventActionISerializableArg(string actionName, string key, ItemKey value)
	{
		if (string.IsNullOrEmpty(key))
		{
			return;
		}
		for (int i = 0; i < ListeningEventActionList.Count; i++)
		{
			if (ListeningEventActionList[i].listeningAction.Equals(actionName))
			{
				TaiwuEvent item = ListeningEventActionList[i].listenerEvent;
				if (item != null && !item.IsEmpty)
				{
					ListeningEventActionList[i].listenerEvent.ArgBox.Set(key, value);
				}
			}
		}
	}

	[DomainMethod]
	public void SetListenerEventActionIntListArg(string actionName, string key, IntList value)
	{
		if (string.IsNullOrEmpty(key))
		{
			return;
		}
		for (int i = 0; i < ListeningEventActionList.Count; i++)
		{
			if (ListeningEventActionList[i].listeningAction.Equals(actionName))
			{
				TaiwuEvent item = ListeningEventActionList[i].listenerEvent;
				if (item != null && !item.IsEmpty)
				{
					ListeningEventActionList[i].listenerEvent.ArgBox.Set(key, value);
				}
			}
		}
	}

	[DomainMethod]
	public void SetListenerEventActionShortListArg(string actionName, string key, GameData.Utilities.ShortList value)
	{
		if (string.IsNullOrEmpty(key))
		{
			return;
		}
		for (int i = 0; i < ListeningEventActionList.Count; i++)
		{
			if (ListeningEventActionList[i].listeningAction.Equals(actionName))
			{
				TaiwuEvent item = ListeningEventActionList[i].listenerEvent;
				if (item != null && !item.IsEmpty)
				{
					ListeningEventActionList[i].listenerEvent.ArgBox.Set(key, value);
				}
			}
		}
	}

	[DomainMethod]
	public void SetListenerEventActionItemKeyArg(string actionName, string key, ItemKey value)
	{
		if (string.IsNullOrEmpty(key))
		{
			return;
		}
		for (int i = 0; i < ListeningEventActionList.Count; i++)
		{
			if (ListeningEventActionList[i].listeningAction.Equals(actionName))
			{
				TaiwuEvent item = ListeningEventActionList[i].listenerEvent;
				if (item != null && !item.IsEmpty)
				{
					ListeningEventActionList[i].listenerEvent.ArgBox.Set(key, value);
				}
			}
		}
	}

	[DomainMethod]
	public void SetListenerEventActionIntArg(string actionName, string key, int value)
	{
		if (string.IsNullOrEmpty(key))
		{
			return;
		}
		for (int i = 0; i < ListeningEventActionList.Count; i++)
		{
			if (ListeningEventActionList[i].listeningAction.Equals(actionName))
			{
				TaiwuEvent item = ListeningEventActionList[i].listenerEvent;
				if (item != null && !item.IsEmpty)
				{
					ListeningEventActionList[i].listenerEvent.ArgBox.Set(key, value);
				}
			}
		}
	}

	[DomainMethod]
	public void SetListenerEventActionBoolArg(string actionName, string key, bool value)
	{
		if (string.IsNullOrEmpty(key))
		{
			return;
		}
		for (int i = 0; i < ListeningEventActionList.Count; i++)
		{
			if (ListeningEventActionList[i].listeningAction.Equals(actionName))
			{
				TaiwuEvent item = ListeningEventActionList[i].listenerEvent;
				if (item != null && !item.IsEmpty)
				{
					ListeningEventActionList[i].listenerEvent.ArgBox.Set(key, value);
				}
			}
		}
	}

	[DomainMethod]
	public void SetListenerEventActionStringArg(string actionName, string key, string value)
	{
		if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
		{
			return;
		}
		for (int i = 0; i < ListeningEventActionList.Count; i++)
		{
			if (ListeningEventActionList[i].listeningAction.Equals(actionName))
			{
				TaiwuEvent item = ListeningEventActionList[i].listenerEvent;
				if (item != null && !item.IsEmpty)
				{
					ListeningEventActionList[i].listenerEvent.ArgBox.Set(key, value);
				}
			}
		}
	}

	[DomainMethod]
	public EventLogData GetEventLogData()
	{
		foreach (EventLogResultData result in _resultCache)
		{
			EnqueueResultImpl(result, clearCache: false);
		}
		EventLogData res = new EventLogData
		{
			CharacterList = _characterCache.Values.ToList(),
			SecretInformationList = _secretInformationCache.Values.ToList(),
			ItemList = _itemCache.Values.ToList(),
			CombatSkillList = _combatSkillCache.Values.ToList(),
			ResultList = _eventLogQueue.SelectMany((List<EventLogResultData> x) => x).Concat(_resultCache).ToList()
		};
		foreach (EventLogResultData result2 in _resultCache)
		{
			DequeueResultImpl(result2);
		}
		return res;
	}

	[DomainMethod]
	public void StartNewDialog(DataContext context, IntPair charIds, string dialog, string rawResponseData, EventActorData leftActor, EventActorData rightActor, string leftName, string rightName, short merchantTemplateId)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		sbyte type = 0;
		if (IsResultCacheValid())
		{
			if (_eventLogQueue.Count > 99)
			{
				EventLogDequeue();
			}
			int adventureId = DomainManager.Adventure.GetAdventureTaiwu().AdventureId;
			if (_isCheckValid || _isSequential || (adventureId >= 0 && _adventureId >= 0))
			{
				CompareCharacterStatusRecord(taiwuId);
				if (_interactingCharacters.Item1 >= 0 && _interactingCharacters.Item1 != taiwuId)
				{
					if (_interactingCharacters.Item1 == charIds.First)
					{
						CompareCharacterStatusRecord(_interactingCharacters.Item1);
					}
					else if (_npcStatus.ContainsKey(_interactingCharacters.Item1))
					{
						_npcStatus.Remove(_interactingCharacters.Item1);
					}
				}
				if (_interactingCharacters.Item2 >= 0 && _interactingCharacters.Item2 != taiwuId && _interactingCharacters.Item1 != _interactingCharacters.Item2)
				{
					if (_interactingCharacters.Item2 == charIds.Second)
					{
						CompareCharacterStatusRecord(_interactingCharacters.Item2);
					}
					else if (_npcStatus.ContainsKey(_interactingCharacters.Item2))
					{
						_npcStatus.Remove(_interactingCharacters.Item2);
					}
				}
			}
			else
			{
				_npcStatus.Clear();
			}
			_adventureId = adventureId;
			EventLogEnqueue();
		}
		else
		{
			_resultCache = new List<EventLogResultData>();
		}
		if (merchantTemplateId >= 0)
		{
			type = 1;
			rightActor = new EventActorData(merchantTemplateId);
		}
		Dictionary<int, NameStringAndAvatar> charDict = new Dictionary<int, NameStringAndAvatar>();
		AddChar(charDict, leftActor, charIds.First);
		AddChar(charDict, rightActor, charIds.Second);
		List<EventLogResultData> resultCache = _resultCache;
		EventLogResultData obj = new EventLogResultData
		{
			Type = type
		};
		int num = 3;
		List<int> list = new List<int>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<int> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = 2;
		num2++;
		span[num2] = charIds.First;
		num2++;
		span[num2] = charIds.Second;
		obj.ValueList = list;
		obj.Text = dialog;
		obj.LeftActorData = leftActor;
		obj.RightActorData = rightActor;
		obj.LeftName = leftName;
		obj.RightName = rightName;
		obj.CharDict = charDict;
		resultCache.Add(obj);
		_rawResponseData = rawResponseData;
		_interactingCharacters = (charIds.First, charIds.Second);
		_isSequential = false;
		_isCheckValid = true;
		BlockEventLogImmediateStatusCheck();
		UpdateCharacterStatusRecord(taiwuId);
		if (charIds.First >= 0 && charIds.First != taiwuId)
		{
			UpdateCharacterStatusRecord(charIds.First);
		}
		if (charIds.Second >= 0 && charIds.Second != taiwuId)
		{
			UpdateCharacterStatusRecord(charIds.Second);
		}
	}

	private void AddChar(Dictionary<int, NameStringAndAvatar> charDict, EventActorData leftActor, int charId)
	{
		GameData.Domains.Character.Character recChar;
		if (leftActor != null)
		{
			charDict[charId] = new NameStringAndAvatar
			{
				Avatar = new AvatarRelatedData
				{
					AvatarData = leftActor.AvatarData,
					DisplayAge = leftActor.Age,
					ClothingDisplayId = leftActor.ClothDisplayId
				},
				Name = leftActor.DisplayName,
				CharId = charId,
				CharTemplateId = leftActor.TemplateId
			};
		}
		else if (DomainManager.Character.TryGetElement_Objects(charId, out recChar))
		{
			charDict[charId] = new NameStringAndAvatar
			{
				Avatar = DomainManager.Character.GetAvatarRelatedData(charId),
				Name = DomainManager.Character.GetName(charId),
				CharId = charId,
				CharTemplateId = recChar.GetTemplateId()
			};
		}
	}

	public void CheckTaiwuStatusImmediately()
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		if (_shouldCheckStatusImmediately)
		{
			CompareCharacterStatusRecord(taiwuId);
		}
		_shouldCheckStatusImmediately = true;
		UpdateCharacterStatusRecord(taiwuId);
	}

	public void BlockEventLogStatusCheck()
	{
		_isCheckValid = false;
	}

	public void BlockEventLogImmediateStatusCheck()
	{
		_shouldCheckStatusImmediately = false;
	}

	public void SetIsSequential(bool value)
	{
		_isSequential = value;
	}

	public void RecordCharacterEnterCombat()
	{
		_taiwuStatus.Combat = (8, -1);
		SetIsSequential(value: true);
		Events.RegisterHandler_CombatSettlement(CombatSettlementEventCallback);
	}

	public void RecordCharacterEnterLifeCombat()
	{
		_taiwuStatus.Combat = (9, -1);
		SetIsSequential(value: true);
	}

	public void RecordCharacterEnterCricketCombat()
	{
		_taiwuStatus.Combat = (10, -1);
		SetIsSequential(value: true);
	}

	public void RecordCombatResult(bool isTaiwuWin)
	{
		_taiwuStatus.Combat = (_taiwuStatus.Combat.Item1, isTaiwuWin ? 1 : 0);
	}

	public void UpdateEventLogCharacterDisplayData(int charId)
	{
		if (_characterCache.ContainsKey(charId))
		{
			_characterCache[charId] = DomainManager.Character.GetCharacterDisplayData(charId);
		}
	}

	private void CombatSettlementEventCallback(DataContext context, sbyte combatStatus)
	{
		switch (combatStatus)
		{
		case 2:
		case 4:
			RecordCombatResult(isTaiwuWin: false);
			break;
		case 3:
		case 5:
			RecordCombatResult(isTaiwuWin: true);
			break;
		}
		Events.UnRegisterHandler_CombatSettlement(CombatSettlementEventCallback);
	}

	public void RecordCharacterRelationChanged(bool isRemove, int id1, int id2, ushort type)
	{
		_taiwuStatus.Relation.Add((isRemove, id1, id2, type));
	}

	public void RecordTeammateStateChanged(bool isLosing, int id)
	{
		_taiwuStatus.Teammate = (isLosing, id);
	}

	public void RecordFavorabilityToTaiwuChanged(int id, short value)
	{
		if (_npcStatus.TryGetValue(id, out var status))
		{
			status.FavorabilityToTaiwu = value;
		}
	}

	private void GenerateResponseLog(string optionKey, int charId)
	{
		if (string.IsNullOrEmpty(optionKey) || string.IsNullOrEmpty(_rawResponseData))
		{
			return;
		}
		string[] responses = _rawResponseData.Split("<$new response dialog>");
		string[] array = responses;
		foreach (string response in array)
		{
			if (!string.IsNullOrEmpty(response))
			{
				string[] data = response.Split("<$optionKey>");
				if (data[0] == optionKey)
				{
					InsertResponseLog(data[1], charId, Convert.ToInt32(data[2]));
					break;
				}
			}
		}
	}

	private void InsertResponseLog(string optionContent, int charId = -1, int behavior = 0)
	{
		Dictionary<int, NameStringAndAvatar> dict = new Dictionary<int, NameStringAndAvatar>();
		if (charId < 0)
		{
			charId = DomainManager.Taiwu.GetTaiwuCharId();
		}
		AddChar(dict, null, charId);
		_resultCache.Insert(1, new EventLogResultData
		{
			Type = 2,
			ValueList = new List<int> { 1, charId, behavior },
			Text = optionContent,
			CharDict = dict
		});
	}

	private void EventLogDequeue()
	{
		List<EventLogResultData> resultList = _eventLogQueue.Dequeue();
		foreach (EventLogResultData result in resultList)
		{
			DequeueResultImpl(result);
		}
	}

	private void DequeueResultImpl(EventLogResultData result)
	{
		for (int i = 1; i < 1 + result.ValueList[0]; i++)
		{
			int character = result.ValueList[i];
			if (character >= 0)
			{
				_characterReferences[character]--;
				if (_characterReferences[character] <= 0)
				{
					_characterReferences.Remove(character);
					_characterCache.Remove(character);
				}
			}
		}
		switch (result.Type)
		{
		case 29:
		{
			List<int> valueList = result.ValueList;
			int metaDataId = valueList[valueList.Count - 1];
			_secretInformationReferences[metaDataId]--;
			result.ValueList.RemoveRange(2, result.ValueList[0] - 1);
			result.ValueList[0] = 1;
			if (_secretInformationReferences[metaDataId] <= 0)
			{
				_secretInformationReferences.Remove(metaDataId);
				_secretInformationCache.Remove(metaDataId);
			}
			break;
		}
		case 11:
		{
			int itemId = result.ValueList[2];
			_itemReferences[itemId]--;
			if (_itemReferences[itemId] <= 0)
			{
				_itemReferences.Remove(itemId);
				_itemCache.Remove(itemId);
			}
			break;
		}
		case 21:
		{
			int combatSkillId = result.ValueList[2];
			_combatSkillReferences[combatSkillId]--;
			if (_combatSkillReferences[combatSkillId] <= 0)
			{
				_combatSkillReferences.Remove(combatSkillId);
				_combatSkillCache.Remove(combatSkillId);
			}
			break;
		}
		}
	}

	private void EventLogEnqueue()
	{
		if (_resultCache.Count == 0)
		{
			return;
		}
		foreach (EventLogResultData result in _resultCache)
		{
			EnqueueResultImpl(result);
		}
		_resultCache.Add(new EventLogResultData
		{
			Type = 30,
			ValueList = new List<int> { 0 }
		});
		_eventLogQueue.Enqueue(_resultCache);
		_resultCache = new List<EventLogResultData>();
	}

	private void EnqueueResultImpl(EventLogResultData result, bool clearCache = true)
	{
		switch (result.Type)
		{
		case 29:
		{
			List<int> valueList = result.ValueList;
			int secretId = valueList[valueList.Count - 1];
			HashSet<int> characterList = new HashSet<int>();
			SecretInformationDisplayData displayData = DomainManager.Information.GetSecretInformationDisplayData((SecretInformationId)secretId, characterList);
			result.ValueList.InsertRange(2, characterList);
			result.ValueList[0] = result.ValueList.Count - 2;
			if (!_secretInformationReferences.ContainsKey(secretId))
			{
				_secretInformationReferences[secretId] = 0;
				_secretInformationCache[secretId] = displayData;
			}
			_secretInformationReferences[secretId]++;
			break;
		}
		case 11:
		{
			int itemId = result.ValueList[2];
			if (!_itemReferences.ContainsKey(itemId))
			{
				ItemKey key = _itemKeys[itemId].Item1;
				bool isTemporary = false;
				if (!DomainManager.Item.ItemExists(key))
				{
					key = DomainManager.Item.CreateItem(DomainManager.TaiwuEvent.MainThreadDataContext, key.ItemType, key.TemplateId);
					isTemporary = true;
				}
				_itemReferences[itemId] = 0;
				_itemCache[itemId] = DomainManager.Item.GetItemDisplayData(key, result.ValueList[1]);
				if ((_itemKeys[itemId].Item2 && !clearCache) || isTemporary)
				{
					DomainManager.Item.RemoveItem(MainThreadDataContext, key);
				}
				if (clearCache)
				{
					_itemKeys.Remove(itemId);
				}
			}
			_itemReferences[itemId]++;
			break;
		}
		case 21:
		{
			int combatSkillId = result.ValueList[2];
			if (!_combatSkillReferences.ContainsKey(combatSkillId))
			{
				_combatSkillReferences[combatSkillId] = 0;
				_combatSkillCache[combatSkillId] = DomainManager.CombatSkill.GetCombatSkillDisplayDataOnce(result.ValueList[1], (short)result.ValueList[2]);
			}
			_combatSkillReferences[combatSkillId]++;
			break;
		}
		}
		for (int i = 1; i < 1 + result.ValueList[0]; i++)
		{
			int character = result.ValueList[i];
			if (character >= 0)
			{
				if (!_characterReferences.ContainsKey(character))
				{
					_characterReferences[character] = 0;
					_characterCache[character] = DomainManager.Character.GetCharacterDisplayData(character);
				}
				_characterReferences[character]++;
			}
		}
	}

	private bool IsResultCacheValid()
	{
		foreach (EventLogResultData res in _resultCache)
		{
			if (res.Type == 2)
			{
				return true;
			}
		}
		return false;
	}

	private void UpdateCharacterStatusRecord(int id)
	{
		DomainManager.Character.TryGetElement_Objects(id, out var character);
		EventLogCharacterData status;
		if (DomainManager.Taiwu.GetTaiwuCharId() == id)
		{
			status = _taiwuStatus;
			status.SecretInformation.Clear();
			foreach (SecretInformationId secretId in DomainManager.Information.QueryCharacterKnownSecretInformationIds(id))
			{
				status.SecretInformation.Add((int)secretId);
			}
			status.NormalInformation.Clear();
			if (DomainManager.Information.TryGetElement_Information(id, out var collection2))
			{
				foreach (NormalInformation data in collection2.GetList())
				{
					status.NormalInformation.Add(data);
				}
			}
			status.Combat = (-1, -1);
			status.Relation.Clear();
			status.SpiritualDebt = DomainManager.Extra.GetAreaSpiritualDebt();
			status.Teammate = (false, -1);
			status.Profession.Clear();
			foreach (ProfessionItem profession in (IEnumerable<ProfessionItem>)Profession.Instance)
			{
				status.Profession[profession.TemplateId] = DomainManager.Extra.GetProfessionData(profession.TemplateId).Seniority;
			}
		}
		else
		{
			if (!_npcStatus.ContainsKey(id))
			{
				_npcStatus.Add(id, new EventLogCharacterData(isTaiwu: false));
			}
			status = _npcStatus[id];
			status.FavorabilityToTaiwu = 0;
			status.ApprovedTaiwu = ((DomainManager.Organization.TryGetSettlementCharacter(id, out var settlementChar) && DomainManager.Organization.GetSettlementByOrgTemplateId(settlementChar.GetOrgTemplateId()) != null) ? DomainManager.Organization.GetSettlementByOrgTemplateId(settlementChar.GetOrgTemplateId()).CalcApprovingRate() : 0);
		}
		status.Happiness = character.GetHappiness();
		status.Fame = character.GetFame();
		status.Infection = character.GetXiangshuInfection();
		status.InfectionStatus = character.GetGroupFeature(209);
		status.Item.Clear();
		foreach (KeyValuePair<ItemKey, int> pair in character.GetInventory().Items)
		{
			status.Item[pair.Key] = pair.Value;
		}
		Array.Copy(character.GetEquipment(), status.Equip, status.Equip.Length);
		for (sbyte i = 0; i < 8; i++)
		{
			status.Resource[i] = character.GetResource(i);
		}
		status.Exp = character.GetExp();
		status.Health = character.GetHealth();
		status.MainAttribute = character.GetCurrMainAttributes();
		status.Injury = character.GetInjuries();
		status.Poison = character.GetPoisoned();
		status.DisorderOfQi = character.GetDisorderOfQi();
		status.CombatSkills.Clear();
		status.CombatSkills.AddRange(character.GetLearnedCombatSkills());
		status.LifeSkills.Clear();
		status.LifeSkills.AddRange(character.GetLearnedLifeSkills());
		status.Feature.Clear();
		status.Feature.AddRange(character.GetFeatureIds());
	}

	private void CompareCharacterStatusRecord(int id)
	{
		DomainManager.Character.TryGetElement_Objects(id, out var character);
		if (DomainManager.Taiwu.GetTaiwuCharId() == id)
		{
			EventLogCheckCombatResult(_taiwuStatus, character);
			EventLogCheckHappiness(_taiwuStatus, character);
			EventLogCheckFame(_taiwuStatus, character);
			EventLogCheckInfection(_taiwuStatus, character);
			EventLogCheckItem(_taiwuStatus, character);
			EventLogCheckResource(_taiwuStatus, character);
			EventLogCheckExp(_taiwuStatus, character);
			EventLogCheckHealth(_taiwuStatus, character);
			EventLogCheckMainAttribute(_taiwuStatus, character);
			EventLogCheckInjury(_taiwuStatus, character);
			EventLogCheckPoison(_taiwuStatus, character);
			EventLogCheckDisorderOfQi(_taiwuStatus, character);
			EventLogCheckCombatSkills(_taiwuStatus, character);
			EventLogCheckLifeSkills(_taiwuStatus, character);
			EventLogCheckRelation(_taiwuStatus, character);
			EventLogCheckFeature(_taiwuStatus, character);
			EventLogCheckSecretInformation(_taiwuStatus, character);
			EventLogCheckNormalInformation(_taiwuStatus, character);
			EventLogCheckSpiritualDebt(_taiwuStatus, character);
			EventLogCheckTeammate(_taiwuStatus, character);
			EventLogCheckProfession(_taiwuStatus, character);
		}
		else
		{
			_npcStatus.TryGetValue(id, out var status);
			EventLogCheckHappiness(status, character);
			EventLogCheckFame(status, character);
			EventLogCheckInfection(status, character);
			EventLogCheckExp(status, character);
			EventLogCheckHealth(status, character);
			EventLogCheckMainAttribute(status, character);
			EventLogCheckInjury(status, character);
			EventLogCheckPoison(status, character);
			EventLogCheckDisorderOfQi(status, character);
			EventLogCheckCombatSkills(status, character);
			EventLogCheckLifeSkills(status, character);
			EventLogCheckFeature(status, character);
			EventLogCheckFavorabilityToTaiwu(status, character);
			EventLogCheckApprovedTaiwu(status, character);
		}
	}

	private void AddDifferenceToResultCache<T>(sbyte type, int charId, bool isLosing, ICollection<T> origList, ICollection<T> newList, bool elementIsCharacter = false, int? extraAdding = null) where T : struct
	{
		foreach (T newItem in newList)
		{
			if (origList.Contains(newItem))
			{
				continue;
			}
			Dictionary<int, NameStringAndAvatar> dict = new Dictionary<int, NameStringAndAvatar>();
			AddChar(dict, null, charId);
			if (elementIsCharacter && newItem is int ni)
			{
				AddChar(dict, null, ni);
			}
			List<EventLogResultData> resultCache = _resultCache;
			EventLogResultData eventLogResultData = new EventLogResultData();
			eventLogResultData.Type = type;
			eventLogResultData.IsLosing = isLosing;
			EventLogResultData eventLogResultData2 = eventLogResultData;
			List<int> list = new List<int>();
			list.Add((!elementIsCharacter) ? 1 : 2);
			list.Add(charId);
			List<int> list2 = list;
			if (1 == 0)
			{
			}
			int item11;
			if (!(newItem is sbyte item))
			{
				if (!(newItem is byte item2))
				{
					if (!(newItem is short item3))
					{
						if (!(newItem is ushort item4))
						{
							if (!(newItem is int item5))
							{
								if (!(newItem is uint item6))
								{
									if (!(newItem is long item7))
									{
										if (!(newItem is ulong item8))
										{
											if (!(newItem is GameData.Domains.Character.LifeSkillItem item9))
											{
												if (!(newItem is NormalInformation item10))
												{
													throw new Exception("Fatal error. Event Log Result Value List doesn't support this type yet.");
												}
												item11 = AddNormalInformationToValueList(item10, out extraAdding);
											}
											else
											{
												item11 = item9.SkillTemplateId;
											}
										}
										else
										{
											item11 = (int)item8;
										}
									}
									else
									{
										item11 = (int)item7;
									}
								}
								else
								{
									item11 = (int)item6;
								}
							}
							else
							{
								item11 = item5;
							}
						}
						else
						{
							item11 = item4;
						}
					}
					else
					{
						item11 = item3;
					}
				}
				else
				{
					item11 = item2;
				}
			}
			else
			{
				item11 = item;
			}
			if (1 == 0)
			{
			}
			list2.Add(item11);
			eventLogResultData2.ValueList = list;
			eventLogResultData.CharDict = dict;
			resultCache.Add(eventLogResultData);
			if (extraAdding.HasValue)
			{
				List<EventLogResultData> resultCache2 = _resultCache;
				resultCache2[resultCache2.Count - 1].ValueList.Add(extraAdding.Value);
			}
		}
	}

	private void AddDifferenceToResultCache(sbyte type, int charId, int origValue, int newValue, int? extraAdding = null)
	{
		if (origValue != newValue)
		{
			Dictionary<int, NameStringAndAvatar> dict = new Dictionary<int, NameStringAndAvatar>();
			AddChar(dict, null, charId);
			_resultCache.Add(new EventLogResultData
			{
				Type = type,
				ValueList = new List<int> { 1, charId, origValue, newValue },
				CharDict = dict
			});
			if (extraAdding.HasValue)
			{
				List<EventLogResultData> resultCache = _resultCache;
				resultCache[resultCache.Count - 1].ValueList.Add(extraAdding.Value);
			}
		}
	}

	private void AddDifferenceToResultCache(int charId, bool isLosing, Dictionary<ItemKey, int> origInventory, Dictionary<ItemKey, int> newInventory)
	{
		foreach (KeyValuePair<ItemKey, int> item in newInventory)
		{
			item.Deconstruct(out var key, out var value);
			ItemKey itemKey = key;
			int newCount = value;
			int origCount;
			int delta = (origInventory.TryGetValue(itemKey, out origCount) ? (newCount - origCount) : newCount);
			if (delta > 0)
			{
				ItemKey key2 = itemKey;
				bool isTemporary = false;
				if (key2.Id == -1 || !DomainManager.Item.ItemExists(key2))
				{
					key2 = DomainManager.Item.CreateItem(DomainManager.TaiwuEvent.MainThreadDataContext, itemKey.ItemType, itemKey.TemplateId);
					isTemporary = true;
				}
				_itemKeys[key2.Id] = (key2, isTemporary);
				Dictionary<int, NameStringAndAvatar> dict = new Dictionary<int, NameStringAndAvatar>();
				AddChar(dict, null, charId);
				_resultCache.Add(new EventLogResultData
				{
					Type = 11,
					IsLosing = isLosing,
					ValueList = new List<int> { 1, charId, key2.Id, delta },
					CharDict = dict
				});
			}
		}
	}

	private int AddNormalInformationToValueList(NormalInformation item, out int? level)
	{
		level = item.Level;
		return item.TemplateId;
	}

	private Location GetTaiwuLocation()
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwu.GetLocation();
		return location.IsValid() ? location : taiwu.GetValidLocation();
	}

	private void EventLogCheckHappiness(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn)
		{
			AddDifferenceToResultCache(3, character.GetId(), status.Happiness, character.GetHappiness());
		}
	}

	private void EventLogCheckFame(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn)
		{
			AddDifferenceToResultCache(4, character.GetId(), status.Fame, character.GetFame());
		}
	}

	private void EventLogCheckInfection(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn)
		{
			byte infection = character.GetXiangshuInfection();
			AddDifferenceToResultCache(6, character.GetId(), status.Infection, infection);
			AddDifferenceToResultCache(7, character.GetId(), status.InfectionStatus, character.GetGroupFeature(209));
		}
	}

	private void EventLogCheckItem(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (ShouldEarlyReturn)
		{
			return;
		}
		Dictionary<ItemKey, int> items = new Dictionary<ItemKey, int>(character.GetInventory().Items);
		Dictionary<ItemKey, int> olds = new Dictionary<ItemKey, int>(status.Item);
		foreach (ItemKey key in status.Equip.Where((ItemKey itemKey) => itemKey.IsValid()))
		{
			olds[key] = 1;
		}
		foreach (ItemKey key2 in from itemKey in character.GetEquipment()
			where itemKey.IsValid()
			select itemKey)
		{
			items[key2] = 1;
		}
		int charId = character.GetId();
		AddDifferenceToResultCache(charId, isLosing: false, olds, items);
		AddDifferenceToResultCache(charId, isLosing: true, items, olds);
	}

	private void EventLogCheckResource(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn)
		{
			for (sbyte i = 0; i < 8; i++)
			{
				AddDifferenceToResultCache(12, character.GetId(), status.Resource[i], character.GetResource(i), i);
			}
		}
	}

	private void EventLogCheckExp(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn)
		{
			AddDifferenceToResultCache(27, character.GetId(), status.Exp, character.GetExp());
		}
	}

	private void EventLogCheckHealth(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn)
		{
			AddDifferenceToResultCache(15, character.GetId(), status.Health, character.GetHealth());
		}
	}

	private unsafe void EventLogCheckMainAttribute(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (ShouldEarlyReturn)
		{
			return;
		}
		MainAttributes delta = character.GetCurrMainAttributes().Subtract(status.MainAttribute);
		if (delta.GetSum() == 0)
		{
			return;
		}
		for (sbyte i = 0; i < 6; i++)
		{
			if (delta.Items[i] != 0)
			{
				Dictionary<int, NameStringAndAvatar> dict = new Dictionary<int, NameStringAndAvatar>();
				AddChar(dict, null, character.GetId());
				_resultCache.Add(new EventLogResultData
				{
					Type = 16,
					ValueList = new List<int>
					{
						1,
						character.GetId(),
						status.MainAttribute.Items[i],
						delta.Items[i],
						i
					},
					CharDict = dict
				});
			}
		}
	}

	private void EventLogCheckInjury(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (ShouldEarlyReturn)
		{
			return;
		}
		Injuries delta = character.GetInjuries().Subtract(status.Injury);
		if (delta.GetSum() == 0)
		{
			return;
		}
		for (sbyte i = 0; i < 7; i++)
		{
			sbyte val1 = delta.Get(i, isInnerInjury: true);
			if (val1 != 0)
			{
				Dictionary<int, NameStringAndAvatar> dict = new Dictionary<int, NameStringAndAvatar>();
				AddChar(dict, null, character.GetId());
				_resultCache.Add(new EventLogResultData
				{
					Type = 17,
					ValueList = new List<int>
					{
						1,
						character.GetId(),
						status.Injury.Get(i, isInnerInjury: true),
						val1,
						i
					},
					CharDict = dict
				});
			}
			sbyte val2 = delta.Get(i, isInnerInjury: false);
			if (val2 != 0)
			{
				Dictionary<int, NameStringAndAvatar> dict2 = new Dictionary<int, NameStringAndAvatar>();
				AddChar(dict2, null, character.GetId());
				_resultCache.Add(new EventLogResultData
				{
					Type = 18,
					ValueList = new List<int>
					{
						1,
						character.GetId(),
						status.Injury.Get(i, isInnerInjury: false),
						val2,
						i
					},
					CharDict = dict2
				});
			}
		}
	}

	private unsafe void EventLogCheckPoison(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (ShouldEarlyReturn)
		{
			return;
		}
		PoisonInts delta = character.GetPoisoned().Subtract(ref status.Poison);
		if (delta.Sum() == 0)
		{
			return;
		}
		for (sbyte i = 0; i < 6; i++)
		{
			if (delta.Items[i] != 0)
			{
				Dictionary<int, NameStringAndAvatar> dict = new Dictionary<int, NameStringAndAvatar>();
				AddChar(dict, null, character.GetId());
				_resultCache.Add(new EventLogResultData
				{
					Type = 19,
					ValueList = new List<int>
					{
						1,
						character.GetId(),
						status.Poison.Items[i],
						delta.Items[i],
						i
					},
					CharDict = dict
				});
			}
		}
	}

	private void EventLogCheckDisorderOfQi(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn)
		{
			AddDifferenceToResultCache(20, character.GetId(), status.DisorderOfQi, character.GetDisorderOfQi());
		}
	}

	private void EventLogCheckCombatSkills(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn)
		{
			AddDifferenceToResultCache(21, character.GetId(), isLosing: false, status.CombatSkills, character.GetLearnedCombatSkills());
		}
	}

	private void EventLogCheckLifeSkills(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn)
		{
			AddDifferenceToResultCache(22, character.GetId(), isLosing: false, status.LifeSkills, character.GetLearnedLifeSkills());
		}
	}

	private void EventLogCheckFeature(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn)
		{
			short[] features = (from x in character.GetFeatureIds()
				where !CharacterFeature.Instance[x].Hidden
				select x).ToArray();
			short[] oldFeatures = status.Feature.Where((short x) => !CharacterFeature.Instance[x].Hidden).ToArray();
			AddDifferenceToResultCache(25, character.GetId(), isLosing: false, oldFeatures, features);
			AddDifferenceToResultCache(25, character.GetId(), isLosing: true, features, oldFeatures);
		}
	}

	private void EventLogCheckSecretInformation(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (ShouldEarlyReturn)
		{
			return;
		}
		IReadOnlyCollection<SecretInformationId> collection = DomainManager.Information.QueryCharacterKnownSecretInformationIds(character.GetId());
		if (collection.Count != 0)
		{
			AddDifferenceToResultCache(29, character.GetId(), isLosing: false, status.SecretInformation, collection.Select((SecretInformationId secretId) => (int)secretId).ToList());
		}
	}

	private void EventLogCheckNormalInformation(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn && DomainManager.Information.TryGetElement_Information(character.GetId(), out var collection))
		{
			AddDifferenceToResultCache(28, character.GetId(), isLosing: false, status.NormalInformation, collection.GetList().ToList());
		}
	}

	private void EventLogCheckCombatResult(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn && status.Combat.Item1 != -1 && status.Combat.Item2 >= 0)
		{
			_resultCache.Add(new EventLogResultData
			{
				Type = status.Combat.Item1,
				ValueList = new List<int>
				{
					0,
					status.Combat.Item2
				}
			});
		}
	}

	private void EventLogCheckRelation(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (ShouldEarlyReturn)
		{
			return;
		}
		foreach (var relation in status.Relation)
		{
			int oneWay = 0;
			if (RelationType.IsOneWayRelation(relation.Item4))
			{
				if (DomainManager.Character.HasRelation(relation.Item2, relation.Item3, relation.Item4) && !DomainManager.Character.HasRelation(relation.Item3, relation.Item2, relation.Item4))
				{
					oneWay = 1;
				}
				else if (!DomainManager.Character.HasRelation(relation.Item2, relation.Item3, relation.Item4) && DomainManager.Character.HasRelation(relation.Item3, relation.Item2, relation.Item4))
				{
					oneWay = 2;
				}
			}
			Dictionary<int, NameStringAndAvatar> dict = new Dictionary<int, NameStringAndAvatar>();
			AddChar(dict, null, relation.Item2);
			AddChar(dict, null, relation.Item3);
			_resultCache.Add(new EventLogResultData
			{
				Type = 24,
				IsLosing = relation.Item1,
				ValueList = new List<int>
				{
					2,
					relation.Item2,
					relation.Item3,
					RelationType.GetTypeId(relation.Item4),
					oneWay
				},
				CharDict = dict
			});
		}
	}

	private void EventLogCheckSpiritualDebt(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (ShouldEarlyReturn)
		{
			return;
		}
		foreach (short areaId in DomainManager.Extra.GetAreaSpiritualDebt(createCopy: false).Keys.Concat(status.SpiritualDebt.Keys).Distinct().Order())
		{
			AddDifferenceToResultCache(13, character.GetId(), status.SpiritualDebt.GetValueOrDefault(areaId), DomainManager.Extra.GetAreaSpiritualDebt(areaId), areaId);
		}
	}

	private void EventLogCheckTeammate(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn && status.Teammate.Item2 >= 0)
		{
			Dictionary<int, NameStringAndAvatar> dict = new Dictionary<int, NameStringAndAvatar>();
			AddChar(dict, null, character.GetId());
			AddChar(dict, null, status.Teammate.Item2);
			_resultCache.Add(new EventLogResultData
			{
				Type = 14,
				IsLosing = status.Teammate.Item1,
				ValueList = new List<int>
				{
					2,
					character.GetId(),
					status.Teammate.Item2
				},
				CharDict = dict
			});
		}
	}

	private void EventLogCheckProfession(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (ShouldEarlyReturn)
		{
			return;
		}
		foreach (ProfessionItem profession in (IEnumerable<ProfessionItem>)Profession.Instance)
		{
			int templateId = profession.TemplateId;
			if (status.Profession.ContainsKey(templateId))
			{
				AddDifferenceToResultCache(26, character.GetId(), status.Profession[templateId], DomainManager.Extra.GetProfessionData(templateId).Seniority, templateId);
			}
		}
	}

	private void EventLogCheckFavorabilityToTaiwu(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (!ShouldEarlyReturn && status.FavorabilityToTaiwu != 0)
		{
			Dictionary<int, NameStringAndAvatar> dict = new Dictionary<int, NameStringAndAvatar>();
			AddChar(dict, null, character.GetId());
			_resultCache.Add(new EventLogResultData
			{
				Type = 5,
				ValueList = new List<int>
				{
					1,
					character.GetId(),
					status.FavorabilityToTaiwu
				},
				CharDict = dict
			});
		}
	}

	private void EventLogCheckApprovedTaiwu(EventLogCharacterData status, GameData.Domains.Character.Character character)
	{
		if (ShouldEarlyReturn)
		{
			return;
		}
		int id = character.GetId();
		if (DomainManager.Organization.TryGetSettlementCharacter(id, out var settlementChar))
		{
			Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(settlementChar.GetOrgTemplateId());
			if (settlement != null)
			{
				AddDifferenceToResultCache(23, id, status.ApprovedTaiwu, settlement.CalcApprovingRate(), settlementChar.GetOrgTemplateId());
			}
		}
	}

	[DomainMethod]
	public void GmCmd_SaveMonthlyActionManager(DataContext context)
	{
		SetMonthlyEventActionManager(_monthlyEventActionManager, context);
	}

	[DomainMethod]
	public void GmCmd_TaiwuCrossArchive()
	{
		DomainManager.TaiwuEvent.OnEvent_TaiwuCrossArchive();
	}

	[DomainMethod]
	public void GmCmd_TravelToPastTaiwuVillage(DataContext context)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddTravelCommand("TravelToPastTaiwuVillageArea");
	}

	[DomainMethod]
	public void GmCmd_BackFromPastTaiwuVillage(DataContext context)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddTravelCommand("BackFromPastTaiwuVillageArea");
	}

	[DomainMethod]
	public GlobalArgValue GmCmd_GetGlobalArgBoxInt(string key)
	{
		int val = 0;
		return (_globalArgBox.Get(key, ref val), val);
	}

	[DomainMethod]
	public void GmCmd_SetGlobalArgBoxInt(DataContext context, string key, int value)
	{
		_globalArgBox.Set(key, value);
		SetGlobalArgBox(_globalArgBox, context);
	}

	[DomainMethod]
	public void GmCmd_TaiwuWantedSectPunished(DataContext context, sbyte orgTemplateId, sbyte severity)
	{
		EventArgBox argBox = new EventArgBox();
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId);
		if (settlement != null && settlement is Sect sect)
		{
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			sect.AddBounty(context, taiwu, severity, 0);
			argBox.Set("SettlementId", settlement.GetId());
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.TaiwuWantedSectPunished(argBox, confess: false);
		}
	}

	[DomainMethod]
	public void GmCmd_TriggerOvercomeCombatOver(int combatResult, int combatType, int mainEnemyId)
	{
		InCombatBegin = false;
		SetListenerEventActionIntArg("CombatOver", "CombatResult", combatResult);
		SetListenerEventActionIntArg("CombatOver", "CombatType", combatType);
		SetListenerEventActionIntArg("CombatOver", "MainEnemyId", mainEnemyId);
		if (DomainManager.Character.TryGetElement_Objects(mainEnemyId, out var mainEnemy))
		{
			SetListenerEventActionIntArg("CombatOver", "EnemyTemplateId", mainEnemy.GetTemplateId());
		}
		TriggerListener("CombatOver", value: true);
	}

	[DomainMethod]
	public List<short> GetValidInteractionEventOptions(int targetCharId)
	{
		List<short> optionList = new List<short>();
		GameData.Domains.Character.Character targetChar = DomainManager.Character.GetElement_Objects(targetCharId);
		foreach (InteractionEventOptionItem optionCfg in (IEnumerable<InteractionEventOptionItem>)InteractionEventOption.Instance)
		{
			if (CheckInteractionEventOption(optionCfg, targetChar))
			{
				optionList.Add(optionCfg.TemplateId);
			}
		}
		return optionList;
	}

	public bool CheckInteractionEventOption(InteractionEventOptionItem optionCfg, GameData.Domains.Character.Character targetChar)
	{
		int targetCharId = targetChar.GetId();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (optionCfg.ProfessionSkill >= 0)
		{
			ProfessionSkillItem skillCfg = ProfessionSkill.Instance[optionCfg.ProfessionSkill];
			int index = ProfessionSkillHandle.GetSkillIndex(skillCfg);
			if (!DomainManager.Extra.CanExecuteProfessionSkill(skillCfg.Profession, index))
			{
				return false;
			}
		}
		if (DomainManager.Extra.GetActionPointCurrMonth() < optionCfg.ActionPointCost)
		{
			return false;
		}
		short settlementId = targetChar.GetOrganizationInfo().SettlementId;
		if (settlementId >= 0)
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
			Location location = settlement.GetLocation();
			if (DomainManager.Extra.GetAreaSpiritualDebt(location.AreaId) < optionCfg.SpiritualDebtCost)
			{
				return false;
			}
		}
		ResourceInts resourceCost = optionCfg.ResourceCost;
		if (taiwuChar.GetResources().CheckIsMeet(ref resourceCost))
		{
			return false;
		}
		MainAttributes mainAttributeCost = optionCfg.MainAttributeCost;
		if (taiwuChar.GetCurrMainAttributes().CheckIsMeet(ref mainAttributeCost))
		{
			return false;
		}
		return true;
	}

	public void SetInteractionEventOptionCooldown(int targetCharId, short optionTemplateId)
	{
		_executedOncePerMonthOptions.Add(new IntPair(targetCharId, optionTemplateId));
	}

	public bool IsInteractionEventOptionOffCooldown(int targetCharId, short optionTemplateId)
	{
		return !_executedOncePerMonthOptions.Contains(new IntPair(targetCharId, optionTemplateId));
	}

	[DomainMethod]
	public bool JumpToInteractionEventOption(int targetCharId, short customButtonTemplateId)
	{
		MapBlockCharCustomButtonItem config = MapBlockCharCustomButton.Instance[customButtonTemplateId];
		if (config.LogicType != EMapBlockCharCustomButtonLogicType.Interact)
		{
			return false;
		}
		List<short> interactionTableIds = config.InteractionEventOption;
		short optionTemplateId = -1;
		Dictionary<short, bool> dict = GetVisibleCharacterInteractionEventOptions(targetCharId).dict;
		foreach (short id in interactionTableIds)
		{
			if (!dict.TryGetValue(id, out var canInteract) || !canInteract)
			{
				continue;
			}
			optionTemplateId = id;
			break;
		}
		if (optionTemplateId == -1)
		{
			AdaptableLog.Warning($"JumpToInteractionEventOption: No available interaction option found for button {customButtonTemplateId}, character {targetCharId}");
			return false;
		}
		return JumpToInteractionEventOptionByInteractionIdInner(targetCharId, optionTemplateId);
	}

	[DomainMethod]
	public void MeetTaiwu(DataContext context, int charId)
	{
		if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetCreatingType() == 1)
		{
			DomainManager.Character.TryCreateRelation(context, DomainManager.Taiwu.GetTaiwuCharId(), charId);
			DomainManager.Extra.AddInteractedCharacter(context, charId);
		}
	}

	[DomainMethod]
	public bool JumpToInteractionEventOptionByInteractionId(DataContext context, int targetCharId, short targetTemplateId)
	{
		MeetTaiwu(context, targetCharId);
		Dictionary<short, bool> dict = GetVisibleCharacterInteractionEventOptions(targetCharId).dict;
		if (!dict.TryGetValue(targetTemplateId, out var canInteract))
		{
			return false;
		}
		if (!canInteract)
		{
			return false;
		}
		return JumpToInteractionEventOptionByInteractionIdInner(targetCharId, targetTemplateId);
	}

	private bool JumpToInteractionEventOptionByInteractionIdInner(int targetCharId, short targetTemplateId)
	{
		InteractionEventOptionItem interactionConfig = InteractionEventOption.Instance[targetTemplateId];
		List<string> eventGuidPath = interactionConfig.MapBlockCharCustomButtonEventPath;
		List<string> optionGuidPath = interactionConfig.MapBlockCharCustomButtonEventOptionPath;
		if (ShowingEvent.IsEmpty)
		{
			EventArgBox argBox = new EventArgBox();
			argBox.Set("RoleTaiwu", EventArgBox.TaiwuCharacterId);
			argBox.Set(EventTriggerParameter.DefValue.CharacterId, targetCharId);
			TaiwuEvent entryEvent = GetEvent(eventGuidPath[0]);
			if (entryEvent == null)
			{
				return false;
			}
			entryEvent.ArgBox = argBox;
			if (!entryEvent.EventConfig.CheckCondition())
			{
				return false;
			}
			ShowingEvent = entryEvent;
			_showingEvent.EventConfig.OnCheckEventCondition();
		}
		for (int i = 0; i < eventGuidPath.Count; i++)
		{
			string eventGuid = eventGuidPath[i];
			string optionGuid = optionGuidPath[i];
			if (ShowingEvent.IsEmpty || ShowingEvent.EventGuid != eventGuid)
			{
				AdaptableLog.Warning("JumpToInteractionEventOption: Expected event " + eventGuid + ", but current showing event is " + ShowingEvent.EventGuid);
				return false;
			}
			TaiwuEventOption option = ShowingEvent.EventConfig.EventOptions.Find((TaiwuEventOption o) => o.OptionGuid == optionGuid);
			if (option == null)
			{
				AdaptableLog.Warning("JumpToInteractionEventOption: Option " + optionGuid + " not found in event " + eventGuid);
				return false;
			}
			if (!ExecuteEventOptionInternal(eventGuid, option.OptionKey))
			{
				AdaptableLog.Warning("JumpToInteractionEventOption: Failed to execute option " + option.OptionKey + " in event " + eventGuid);
				return false;
			}
			if (i < eventGuidPath.Count - 1)
			{
				string expectedNextGuid = eventGuidPath[i + 1];
				if (ShowingEvent.IsEmpty || ShowingEvent.EventGuid != expectedNextGuid)
				{
					AdaptableLog.Warning("JumpToInteractionEventOption: Expected to jump to event " + expectedNextGuid + ", but current event is " + ShowingEvent.EventGuid);
					return false;
				}
			}
		}
		Dictionary<short, bool> optionsDict = GetVisibleCharacterInteractionEventOptions(targetCharId).dict;
		if (!optionsDict.TryGetValue(targetTemplateId, out var isAvailable) || !isAvailable)
		{
			AdaptableLog.Warning($"JumpToInteractionEventOption: Target option {targetTemplateId} is no longer available after event chain execution");
			UpdateEventDisplay();
			return false;
		}
		if (ShowingEvent.IsEmpty)
		{
			UpdateEventDisplay();
			return true;
		}
		TaiwuEventOption[] currentEventOptions = ShowingEvent.EventConfig.EventOptions;
		InteractionEventOptionItem optionConfig = InteractionEventOption.Instance[targetTemplateId];
		TaiwuEventOption targetInteractionOption = currentEventOptions.FirstOrDefault((TaiwuEventOption opt) => opt.OptionGuid == optionConfig.OptionGuid);
		if (targetInteractionOption == null)
		{
			AdaptableLog.Warning($"JumpToInteractionEventOption: Could not find target option {targetTemplateId} in current event {ShowingEvent.EventGuid}");
			UpdateEventDisplay();
			return false;
		}
		if (!ExecuteEventOptionInternal(ShowingEvent.EventGuid, targetInteractionOption.OptionKey))
		{
			AdaptableLog.Warning("JumpToInteractionEventOption: Failed to execute target option " + targetInteractionOption.OptionKey);
			UpdateEventDisplay();
			return false;
		}
		return true;
		void UpdateEventDisplay()
		{
			UpdateEventDisplayData();
		}
	}

	private bool ExecuteEventOptionInternal(string eventGuid, string optionKey)
	{
		TaiwuEvent showingEvent = ShowingEvent;
		if ((showingEvent != null && showingEvent.IsEmpty) || eventGuid != ShowingEvent.EventGuid)
		{
			return false;
		}
		TaiwuEventItem eventConfig = ShowingEvent.EventConfig;
		EventArgBox passBox = ShowingEvent.ArgBox;
		TaiwuEventOption option = eventConfig[optionKey];
		string guidString = option.Select(_scriptRuntime);
		int eventLogMainCharacterId = -1;
		GenerateResponseLog(optionKey, passBox.Get("ConchShip_PresetKey_EventLogMainCharacter", ref eventLogMainCharacterId) ? eventLogMainCharacterId : (-1));
		if (IsEventStay(eventGuid, optionKey))
		{
			return true;
		}
		HandleOptionConsume(eventConfig[optionKey], eventConfig.MainRoleKey, eventConfig.TargetRoleKey);
		HandlerOptionEffect(eventConfig[optionKey]);
		eventConfig.OnEventExit();
		ResetArgBoxEventSelectData(passBox);
		if (string.IsNullOrEmpty(guidString))
		{
			ShowingEvent = TaiwuEvent.Empty;
			return true;
		}
		ShowingEvent.ArgBox = null;
		TaiwuEvent nextEvent = GetEvent(guidString);
		if (nextEvent != null)
		{
			nextEvent.ArgBox = passBox;
			if (nextEvent.EventConfig.CheckCondition())
			{
				ShowingEvent = nextEvent;
				return true;
			}
			ShowingEvent = TaiwuEvent.Empty;
			return false;
		}
		AdaptableLog.TagError("TaiwuEvent", "JumpToInteractionEventOption: can not find event " + guidString);
		return false;
	}

	[DomainMethod]
	public void InitConchShipEvents()
	{
		string globalScriptsFolderPath = Path.Combine("..", "Event/EventLib/GlobalScriptCompiled");
		_scriptRuntime.LoadGlobalScripts(globalScriptsFolderPath);
		_packagesList = new List<EventPackage>();
		_languageFilePattern.Clear();
		EventPackagePathInfo pathInfo = new EventPackagePathInfo("../Event");
		string useLoadFromPath = Path.Combine("..", "use_load_from.txt");
		string useLoadFilePath = Path.Combine("..", "use_load_file.txt");
		_eventManager.Reset();
		_loadMethod = (File.Exists(useLoadFromPath) ? EEventPackageLoadMethod.LoadFrom : ((!File.Exists(useLoadFilePath)) ? EEventPackageLoadMethod.LoadBuffer : EEventPackageLoadMethod.LoadFile));
		string[] dllFiles = Directory.GetFiles(pathInfo.DllDirPath, "*.dll", SearchOption.AllDirectories);
		foreach (string dllFilePath in dllFiles)
		{
			string packageName = Path.GetFileNameWithoutExtension(dllFilePath);
			LoadEventPackageFromAssembly(packageName, pathInfo, "ConchShip");
		}
		AdaptableLog.Info("ConchShip events init complete,can load mod events now");
		DlcManager.LoadAllEventPackages();
		DomainManager.Mod.LoadAllEventPackages();
		InitCharacterInteractionEventOptionConfigList();
	}

	[DomainMethod]
	public void ReloadConchShipEvents(List<string> packageNameList)
	{
		EventPackagePathInfo pathInfo = new EventPackagePathInfo("../Event");
		for (int i = 0; i < packageNameList.Count; i++)
		{
			string packageName = packageNameList[i];
			packageName = "Taiwu_EventPackage_" + packageName;
			LoadEventPackageFromAssembly(packageName, pathInfo, "ConchShip");
		}
	}

	[DomainMethod]
	public void LoadEventsFromPath(string eventDataDirectory)
	{
		if (!Directory.Exists(eventDataDirectory))
		{
			throw new Exception("Directory " + eventDataDirectory + " does not exist");
		}
		EventPackagePathInfo pathInfo = new EventPackagePathInfo(eventDataDirectory);
		string[] dllFiles = Directory.GetFiles(eventDataDirectory, "*.dll", SearchOption.AllDirectories);
		string parentDirectory = new DirectoryInfo(eventDataDirectory).Parent.FullName;
		int packageCount = 0;
		foreach (string dllFilePath in dllFiles)
		{
			string packageName = Path.GetFileNameWithoutExtension(dllFilePath);
			LoadEventPackageFromAssembly(packageName, pathInfo, parentDirectory);
			packageCount++;
		}
		AdaptableLog.Info($"load events from {eventDataDirectory} complete,{packageCount} packages loaded!");
	}

	public void LoadEventPackageFromAssembly(string packageName, EventPackagePathInfo pathInfo, string modIdString, string dllFilePath = null)
	{
		if (string.IsNullOrEmpty(dllFilePath))
		{
			dllFilePath = Path.Combine(pathInfo.DllDirPath, packageName + ".dll");
		}
		Assembly assembly = LoadEventPackageAssembly(dllFilePath);
		EventPackage package = CreateEventPackageObject(assembly);
		if (package == null)
		{
			Logger.AppendWarning("Failed to load event package at " + dllFilePath + ".");
			return;
		}
		package.SetModIdString(modIdString);
		int loadedPackageIndex = _packagesList.FindIndex((EventPackage loadedPackage) => loadedPackage.Key == package.Key);
		if (loadedPackageIndex >= 0)
		{
			Logger.Info("Overwriting event package " + package.Key);
			_eventManager.UnloadPackage(_packagesList[loadedPackageIndex]);
			_packagesList.RemoveAt(loadedPackageIndex);
		}
		string packagePath = Path.Combine(pathInfo.ScriptDirPath, packageName + ".twes");
		try
		{
			_scriptRuntime.LoadPackageScripts(package, packagePath);
		}
		catch (Exception value)
		{
			Logger.AppendWarning($"Failed to load event package at {packagePath}.\n{value}");
			return;
		}
		_languageFilePattern[package] = Path.Combine(pathInfo.LanguageDirPath, packageName + "_Language_{0}.txt");
		ReloadSinglePackageLanguage(package);
		_eventManager.HandleEventPackage(package);
		_packagesList.Add(package);
	}

	internal void ReloadSinglePackageLanguage(EventPackage package)
	{
		if (_languageFilePattern.TryGetValue(package, out var pattern))
		{
			package.InitLanguage(string.Format(pattern, LocalStringManager.CurLanguageType.ToString()));
		}
	}

	internal void ReloadAllPackageLanguages()
	{
		if (_packagesList == null)
		{
			return;
		}
		foreach (EventPackage package in _packagesList)
		{
			ReloadSinglePackageLanguage(package);
		}
	}

	private Assembly LoadEventPackageAssembly(string path)
	{
		EEventPackageLoadMethod loadMethod = _loadMethod;
		if (1 == 0)
		{
		}
		Assembly result = loadMethod switch
		{
			EEventPackageLoadMethod.LoadFile => Assembly.LoadFile(path), 
			EEventPackageLoadMethod.LoadFrom => Assembly.LoadFrom(path), 
			EEventPackageLoadMethod.LoadBuffer => LoadBinaryWithPdb(), 
			_ => throw new Exception($"Unable to load assembly with undefined method {_loadMethod}."), 
		};
		if (1 == 0)
		{
		}
		return result;
		Assembly LoadBinaryWithPdb()
		{
			DirectoryInfo directory = Directory.GetParent(path);
			string pdbPath = Path.Combine(directory.FullName, Path.GetFileNameWithoutExtension(path) + ".pdb");
			if (File.Exists(pdbPath))
			{
				return Assembly.Load(File.ReadAllBytes(path), File.ReadAllBytes(pdbPath));
			}
			return Assembly.Load(File.ReadAllBytes(path));
		}
	}

	private EventPackage CreateEventPackageObject(Assembly assembly)
	{
		Type[] types = assembly.GetExportedTypes();
		Type baseType = typeof(EventPackage);
		Type[] array = types;
		foreach (Type type in array)
		{
			if (type.IsSubclassOf(baseType))
			{
				try
				{
					return Activator.CreateInstance(type) as EventPackage;
				}
				catch (Exception value)
				{
					Logger.AppendWarning($"Failed to load event package {value}.");
					return null;
				}
			}
		}
		return null;
	}

	public List<TaiwuEventItem> GetAllEventConfigs()
	{
		List<TaiwuEventItem> allEventConfigList = new List<TaiwuEventItem>();
		_packagesList.ForEach(delegate(EventPackage e)
		{
			allEventConfigList.AddRange(e.GetAllEvents());
		});
		return allEventConfigList;
	}

	private void InitCharacterInteractionEventOptionConfigList()
	{
		_characterInteractionEventOptionList.Clear();
		List<short> keys = InteractionEventOption.Instance.GetAllKeys();
		foreach (EventPackage package in _packagesList)
		{
			List<TaiwuEventItem> allEvents = package.GetAllEvents();
			if (keys.Count == 0)
			{
				break;
			}
			foreach (TaiwuEventItem taiwuEventItem in allEvents)
			{
				if (keys.Count == 0)
				{
					break;
				}
				TaiwuEventOption[] eventOptions = taiwuEventItem.EventOptions;
				foreach (TaiwuEventOption taiwuEventOption in eventOptions)
				{
					if (keys.Count == 0)
					{
						break;
					}
					int findIndex = keys.FindIndex(delegate(short key)
					{
						InteractionEventOptionItem interactionEventOptionItem = InteractionEventOption.Instance[key];
						return interactionEventOptionItem.OptionGuid == taiwuEventOption.OptionGuid;
					});
					if (findIndex >= 0)
					{
						_characterInteractionEventOptionList.Add((taiwuEventOption, keys[findIndex], taiwuEventItem));
						keys.RemoveAt(findIndex);
					}
				}
			}
		}
	}

	public (Dictionary<short, bool> dict, int NoInteractionReason) GetVisibleCharacterInteractionEventOptions(int charId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		string guid = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetCharacterClickedSpecialNextEvent(character, new EventArgBox(), createRelation: false);
		if (!string.IsNullOrEmpty(guid))
		{
			return (dict: null, NoInteractionReason: 2);
		}
		if (!DomainManager.Character.TryGetRelation(charId, DomainManager.Taiwu.GetTaiwuCharId(), out var _))
		{
			return (dict: null, NoInteractionReason: 1);
		}
		Dictionary<short, bool> result = new Dictionary<short, bool>();
		EventArgBox eventArgBox = _argBoxPool.Get();
		eventArgBox.Set("RoleTaiwu", EventArgBox.TaiwuCharacterId);
		eventArgBox.Set(EventTriggerParameter.DefValue.CharacterId, charId);
		foreach (var characterInteractionEventOption in _characterInteractionEventOptionList)
		{
			TaiwuEventOption taiwuEventOption = characterInteractionEventOption.TaiwuEventOption;
			short templateId = characterInteractionEventOption.templateId;
			TaiwuEventItem taiwuEventItem = characterInteractionEventOption.TaiwuEventItem;
			InteractionEventOptionItem config = InteractionEventOption.Instance[templateId];
			if (config.InteractionType != EInteractionEventOptionInteractionType.Invalid)
			{
				EventArgBox prevEventBox = taiwuEventItem.ArgBox;
				EventArgBox prevOptionBox = taiwuEventOption.ArgBox;
				taiwuEventItem.ArgBox = eventArgBox;
				taiwuEventOption.ArgBox = eventArgBox;
				if (taiwuEventOption.IsVisible)
				{
					result.Add(templateId, taiwuEventOption.IsAvailable);
				}
				taiwuEventItem.ArgBox = prevEventBox;
				taiwuEventOption.ArgBox = prevOptionBox;
			}
		}
		_argBoxPool.Return(eventArgBox);
		return (dict: result, NoInteractionReason: 0);
	}

	[DomainMethod]
	public void EventCommonOptionSelect(short templateId)
	{
		EventCommonOptionItem config = EventCommonOption.Instance[templateId];
		if (!ShowingEvent.IsEmpty && !(config.EventGuid == ShowingEvent.EventGuid))
		{
			DomainManager.TaiwuEvent.ToEvent(config.EventGuid);
			ResetArgBoxEventSelectData(ShowingEvent.ArgBox);
			if (!string.IsNullOrEmpty(config.EventGuid))
			{
				UpdateEventDisplayData();
			}
			if (!string.IsNullOrEmpty(config.OptionRecordText))
			{
				InsertResponseLog(config.OptionRecordText);
			}
		}
	}

	[DomainMethod]
	public void EventCommonOptionPreview(short templateId)
	{
		if (ShowingEvent.IsEmpty || templateId < 0 || templateId >= EventCommonOption.Instance.Count)
		{
			SetCommonOptionPreviewEventOptionInfos(null, MainThreadDataContext);
			return;
		}
		EventCommonOptionItem config = EventCommonOption.Instance[templateId];
		if (string.IsNullOrEmpty(config.EventGuid))
		{
			SetCommonOptionPreviewEventOptionInfos(null, MainThreadDataContext);
			return;
		}
		TaiwuEvent previewEvent = DomainManager.TaiwuEvent.GetEvent(config.EventGuid);
		if (previewEvent == null)
		{
			SetCommonOptionPreviewEventOptionInfos(null, MainThreadDataContext);
			return;
		}
		EventArgBox showingArgBox = ShowingEvent.ArgBox;
		if (showingArgBox == null)
		{
			SetCommonOptionPreviewEventOptionInfos(null, MainThreadDataContext);
			return;
		}
		EventArgBox previewArgBox = GetEventArgBox();
		showingArgBox.CloneTo(previewArgBox);
		EventArgBox previousArgBox = previewEvent.ArgBox;
		try
		{
			previewEvent.ArgBox = previewArgBox;
			SetCommonOptionPreviewEventOptionInfos(previewEvent.ToDisplayData()?.EventOptionInfos, MainThreadDataContext);
		}
		catch (Exception value)
		{
			AdaptableLog.Warning($"EventCommonOptionPreview failed, templateId:{templateId}, eventGuid:{config.EventGuid}\n{value}");
			SetCommonOptionPreviewEventOptionInfos(null, MainThreadDataContext);
		}
		finally
		{
			previewEvent.ArgBox = previousArgBox;
			ReturnArgBox(previewArgBox);
		}
	}

	[DomainMethod]
	public bool EventCommonOptionHaveAvailableOption(short templateId)
	{
		EventCommonOptionItem config = EventCommonOption.Instance[templateId];
		if (string.IsNullOrEmpty(config.EventGuid))
		{
			SetCommonOptionPreviewEventOptionInfos(null, MainThreadDataContext);
			return false;
		}
		TaiwuEvent commonEvent = DomainManager.TaiwuEvent.GetEvent(config.EventGuid);
		if (commonEvent == null)
		{
			SetCommonOptionPreviewEventOptionInfos(null, MainThreadDataContext);
			return false;
		}
		EventArgBox showingArgBox = ShowingEvent.ArgBox;
		if (showingArgBox == null)
		{
			SetCommonOptionPreviewEventOptionInfos(null, MainThreadDataContext);
			return false;
		}
		EventArgBox eventArgBox = GetEventArgBox();
		showingArgBox.CloneTo(eventArgBox);
		EventArgBox previousArgBox = commonEvent.ArgBox;
		commonEvent.ArgBox = eventArgBox;
		bool result = commonEvent.HaveAvailableOption();
		commonEvent.ArgBox = previousArgBox;
		ReturnArgBox(eventArgBox);
		return result;
	}

	public EventArgBox GetGlobalEventArgumentBox()
	{
		return GetGlobalArgBox();
	}

	public void ClearGlobalEventArgumentBox()
	{
		_globalArgBox.Clear();
		SetGlobalArgBox(_globalArgBox, MainThreadDataContext);
	}

	public void SaveGlobalEventArgumentBox()
	{
		SetGlobalArgBox(_globalArgBox, MainThreadDataContext);
	}

	public void SaveArgToGlobalArgBox<T>(string key, T value)
	{
		_globalArgBox.GenericSet(key, value);
		SetGlobalArgBox(_globalArgBox, MainThreadDataContext);
	}

	public void ActivateNextSwordTomb()
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetNextSwordTombCountDownDate();
	}

	public void XiangshuMinionSurroundTaiwuVillage(DataContext context)
	{
		if (!GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GlobalArgBoxContainsKey<bool>("TrySurroundTaiwuVillage"))
		{
			return;
		}
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.MakeAreaGraduallyBrokenInCondition(EventArgBox.TaiwuVillageAreaId, delegate(MapBlockData mapBlockData)
		{
			if (mapBlockData.CharacterSet == null)
			{
				return false;
			}
			if (mapBlockData.CharacterSet.Count > 0)
			{
				int num2 = Math.Min(3, mapBlockData.CharacterSet.Count);
				List<int> list = mapBlockData.CharacterSet.ToList();
				CollectionUtils.Shuffle(MainThreadDataContext.Random, list);
				for (int k = 0; k < num2; k++)
				{
					if (DomainManager.Character.TryGetElement_Objects(list[k], out var element))
					{
						DomainManager.Character.MakeCharacterDead(MainThreadDataContext, element, 10);
					}
				}
			}
			HashSet<int> characterSet = mapBlockData.CharacterSet;
			return characterSet != null && characterSet.Count > 0;
		}, new Dictionary<short, byte>());
		MonthlyNotificationCollection notificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		List<int> areaCharIdList = new List<int>();
		for (short i = 0; i < 45; i++)
		{
			areaCharIdList.Clear();
			Span<MapBlockData> areaBlockCollection = DomainManager.Map.GetAreaBlocks(i);
			Span<MapBlockData> span = areaBlockCollection;
			for (int num = 0; num < span.Length; num++)
			{
				MapBlockData blockData = span[num];
				if (blockData.CharacterSet != null)
				{
					areaCharIdList.AddRange(blockData.CharacterSet);
				}
			}
			if (areaCharIdList.Count > 0)
			{
				int killCount = (int)Math.Max(1f, (float)areaCharIdList.Count * 0.2f);
				CollectionUtils.Shuffle(MainThreadDataContext.Random, areaCharIdList);
				for (int j = 0; j < killCount; j++)
				{
					if (DomainManager.Character.TryGetElement_Objects(areaCharIdList[j], out var character) && character.GetCreatingType() != 0)
					{
						DomainManager.Character.MakeCharacterDead(MainThreadDataContext, character, 10);
					}
				}
				Location location = new Location(i, -1);
				notificationCollection.AddXiangshuKilling(location, killCount);
			}
		}
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.EnsureTaiwuVillagerLocationForSpiritualWanderPlace();
	}

	[DomainMethod]
	public void SetIsQuickStartGame(bool flag)
	{
		EventArgBox globalArgBox = DomainManager.TaiwuEvent.GetGlobalArgBox();
		globalArgBox.Set("CS_PK_IsQuickStartGame", flag);
		DomainManager.TaiwuEvent.SaveGlobalEventArgumentBox();
	}

	public void CollectUnreleasedCalledCharacters(HashSet<int> calledCharacters)
	{
		_monthlyEventActionManager.CollectUnreleasedCalledCharacters(calledCharacters);
	}

	[DomainMethod]
	public (int, int) GetMonthlyActionStateAndTime(MonthlyActionKey key)
	{
		MonthlyActionBase action = _monthlyEventActionManager.GetMonthlyAction(key);
		if (action == null)
		{
			return (0, 0);
		}
		return (action.State, action.Month);
	}

	public MonthlyActionBase GetMonthlyAction(MonthlyActionKey key)
	{
		return _monthlyEventActionManager.GetMonthlyAction(key);
	}

	public MonthlyActionKey AddTempDynamicAction<T>(DataContext context, T action) where T : MonthlyActionBase, IDynamicAction
	{
		MonthlyActionKey key = _monthlyEventActionManager.AddTempDynamicAction(action);
		action.TriggerAction();
		SetMonthlyEventActionManager(_monthlyEventActionManager, context);
		return key;
	}

	public MonthlyActionKey AddWrappedConfigAction(DataContext context, short templateId, short assignedAreaId = -1)
	{
		MonthlyActionKey key = _monthlyEventActionManager.AddWrappedConfigAction(templateId, assignedAreaId);
		SetMonthlyEventActionManager(_monthlyEventActionManager, context);
		return key;
	}

	public void RemoveTempDynamicAction(DataContext context, MonthlyActionKey key)
	{
		_monthlyEventActionManager.RemoveTempDynamicAction(key);
		SetMonthlyEventActionManager(_monthlyEventActionManager, context);
	}

	public void ClearTaiwuBindingMonthlyActions(DataContext context)
	{
		_monthlyEventActionManager.ClearTaiwuBindingMonthlyActions();
		SetMonthlyEventActionManager(_monthlyEventActionManager, context);
	}

	public bool IsOneShotEventHandled(int oneShotEventType)
	{
		return _handledOneShotEvents.ContainsKey(oneShotEventType);
	}

	public void SetOneShotEventHandled(DataContext context, int oneShotEventType)
	{
		if (!_handledOneShotEvents.ContainsKey(oneShotEventType))
		{
			AddElement_HandledOneShotEvents(oneShotEventType, default(VoidValue), context);
		}
		AdaptableLog.TagInfo("One Shot Event", $"One shot event {oneShotEventType} is being handled.");
		Events.RaiseOneShotEventHandled(context, oneShotEventType);
	}

	public bool WasTemporaryOptionSelected(string guid)
	{
		return _selectedTemporaryOptions.Contains(guid);
	}

	public void SetTemporaryOptionSelected(string guid, bool selected)
	{
		if (selected)
		{
			_selectedTemporaryOptions.Add(guid);
		}
		else
		{
			_selectedTemporaryOptions.Remove(guid);
		}
	}

	[DomainMethod]
	public void EventScriptExecuteNext()
	{
		_scriptRuntime.MovingNext = true;
	}

	[DomainMethod]
	public void SetEventScriptExecutionPause(bool isPaused)
	{
		_scriptRuntime.IsPaused = isPaused;
	}

	public void OnEvent_TaiwuBlockChanged(Location arg0, Location arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(0);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BlockFrom, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BlockTo, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_CharacterClicked(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(1);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_AnimalAvatarClicked(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(2);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.AnimalId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_PurpleBambooAvatarClicked(int arg0, sbyte arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(3);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.XiangshuAvatarId, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_FixedCharacterClicked(int arg0, short arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(4);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterTemplateId, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_FixedEnemyClicked(int arg0, short arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(5);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterTemplateId, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_CharacterTemplateClicked(short arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(6);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterTemplateId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_NpcTombClicked(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(7);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.TombId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_InteractPrisoner(int arg0, int arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(8);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.InteractPrisonerType, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_LetTeammateLeaveGroup(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(9);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_NeedToPassLegacy(bool arg0, string arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(10);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.IsTaiwuDying, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.OnFinishPassingLegacyEvent, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_CaravanClicked(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(11);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CaravanId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_KidnappedCharacterClicked(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(12);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_RecordEnterGame()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(13);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_NewGameMonth()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(14);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_BlackMaskAnimationComplete(bool arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(15);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.MaskVisible, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_CloseUI(string arg0, bool arg1, int arg2)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(16);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.UIName, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.PresetBool, arg1);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.PresetInt, arg2);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_EnterBuildingArea(Location arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(62);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.Location, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_SectBuildingClicked(short arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(17);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BuildingTemplateId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_ConstructComplete(BuildingBlockKey arg0, short arg1, sbyte arg2)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(18);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BuildingBlockKey, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BuildingTemplateId, arg1);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BuildingLevel, arg2);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_CollectedMakingSystemItem(BuildingBlockKey arg0, short arg1, bool arg2)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(19);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BuildingBlockKey, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BuildingTemplateId, arg1);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.ShowingGetItem, arg2);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_OnSectSpecialBuildingClicked(short arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(20);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BuildingTemplateId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_OnClickedChickenCoop()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(21);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_OnSettlementTreasuryBuildingClicked(short arg0, sbyte arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(22);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BuildingTemplateId, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.TreasuryOrPrisonCurrentPage, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_SwitchToGuardedPage(byte arg0, sbyte arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(23);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.TreasuryOrPrisonVisitStatus, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.TreasuryOrPrisonCurrentPage, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuVillageDestroyed()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(24);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_OnClickedPrisonBtn(short arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(25);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BuildingTemplateId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_OnClickedSendPrisonBtn()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(26);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_ClickChicken(int arg0, short arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(27);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.ChickenId, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.ChickenTemplateId, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_MainStoryFinishCatchCricket(bool arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(28);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CricketCatchSuccess, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_UserLoadDreamBackArchive()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(29);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_LifeSkillCombatForceSilent(int arg0, sbyte arg1, sbyte arg2)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(30);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.LifeSkillCombatConcessionCount, arg1);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.LifeSkillCombatInducementCount, arg2);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_CombatOpening(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(31);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_ProfessionExperienceChange(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(32);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.ProfessionTemplateId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_ProfessionSkillClicked(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(33);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.ProfessionSkillTemplateId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuGotTianjieFulu(int arg0, ItemKey arg1, int arg2)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(34);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.TianjieFuluItemKey, arg1);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.TianjieFuluCount, arg2);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuSaveCountChange(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(35);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.MonkProfessionSaveCount, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuFindMaterial(int arg0, TreasureFindResult arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(36);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BrokenLevel, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.FindResult, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuFindExtraTreasure(TreasureFindResult arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(37);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.FindResult, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuVillagerExpelled(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(38);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuCrossArchive()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(39);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuCrossArchiveFindMemory(sbyte arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(40);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.DreamBackUnlockStateType, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_OperateInventoryItem(int arg0, sbyte arg1, ItemKey arg2, int arg3)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(41);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.InventoryItemOperationType, arg1);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.SelectInventoryItemKey, arg2);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.Amount, arg3);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_ConfirmEnterSwordTomb()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(42);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuBeHuntedArrivedSect(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(43);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuBeHuntedHunterDie(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(44);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TriggerBatchMapPickupEvent(Location arg0, bool arg1, int arg2)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(45);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.Location, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.IsPickUpAll, arg1);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.MapPickupIndex, arg2);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TriggerMapPickupEvent(Location arg0, bool arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(46);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.Location, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.IsEvent, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuInvite(int arg0, Location arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(47);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.InviteLocation, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_EnterTutorialChapter(short arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(48);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.ChapterIndex, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TryMoveWhenMoveDisabled()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(49);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TryMoveToInvalidLocationInTutorial()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(50);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuDeportVitals(int arg0, bool arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(51);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.VitalType, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.IsGoodEnd, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_SoulWitheringBellTransfer()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(52);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_CatchThief(sbyte arg0, bool arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(53);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.ThiefLevel, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.IsTimeout, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_OnShixiangDrumClickedManyTimes()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(54);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_JingangSectMainStoryReborn()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(55);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_JingangSectMainStoryMonkSoul()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(56);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuCollectWudangHeavenlyTreeSeed(sbyte arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(57);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.ResourceType, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_StartSectShaolinDemonSlayer(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(58);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.BossIndex, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_DlcLoongPutJiaoEggs(int arg0, ItemKey arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(59);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.PoolId, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.JiaoEggItemKey, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_DlcLoongInteractJiao(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(60);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.PoolId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_DlcLoongPetJiao(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(61);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.PoolId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_OnClickedCultivateFeather()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(63);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_OnFinishTravel()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(64);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_ClickDamageHugeSword()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(65);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_MajorEventPoint()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(66);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TaiwuMiscGift(int arg0, ItemKey arg1)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(67);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.ItemKey, arg1);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_TwelveImmortals2AttackTaiwu()
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(68);
			trigger.ArgBox.Clear();
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_FirstIntoTwelveImmortalsImpactRange(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(69);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	public void OnEvent_ClickEmeiGuidance(int arg0)
	{
		if (!CheckListenedEventBlockTrigger())
		{
			EventTrigger trigger = _eventManager.GetTrigger(70);
			trigger.ArgBox.Clear();
			trigger.ArgBox.Set(EventTriggerParameter.DefValue.CharacterId, arg0);
			trigger.OnEvent(trigger.ArgBox);
			TriggerHandled();
		}
	}

	[DomainMethod]
	public void OnCharacterClicked(DataContext context, int charId)
	{
		InteractedCharSet.Add(charId);
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		short characterTemplateId = character.GetTemplateId();
		if (!GameData.Domains.Character.Character.IsXiangshuMinion(characterTemplateId))
		{
			if (Enumerable.Contains(XiangshuAvatarIds.JuniorXiangshuTemplateIds, characterTemplateId))
			{
				sbyte avatarId = XiangshuAvatarIds.GetXiangshuAvatarIdByCharacterTemplateId(characterTemplateId);
				OnEvent_PurpleBambooAvatarClicked(charId, avatarId);
			}
			else if (character.GetCreatingType() == 0)
			{
				OnEvent_FixedCharacterClicked(charId, characterTemplateId);
			}
			else if (character.GetCreatingType() != 3 || DomainManager.Character.IsSpecialGroupMember(character))
			{
				OnEvent_CharacterClicked(charId);
			}
			else if (character.GetCreatingType() == 3)
			{
				OnEvent_FixedEnemyClicked(charId, characterTemplateId);
			}
		}
	}

	[DomainMethod]
	public void OnCharacterTemplateClicked(DataContext context, short characterTemplateId)
	{
		OnEvent_CharacterTemplateClicked(characterTemplateId);
	}

	[DomainMethod]
	public void OnLetTeammateLeaveGroup(DataContext context, int charId)
	{
		OnEvent_LetTeammateLeaveGroup(charId);
	}

	[DomainMethod]
	public void OnInteractCaravan(int caravanId)
	{
		OnEvent_CaravanClicked(caravanId);
	}

	[DomainMethod]
	public void OnInteractKidnappedCharacter(int charId)
	{
		OnEvent_KidnappedCharacterClicked(charId);
	}

	[DomainMethod]
	public void OnSectBuildingClicked(short buildingTemplateId)
	{
		OnEvent_SectBuildingClicked(buildingTemplateId);
	}

	[DomainMethod]
	public void OnRecordEnterGame()
	{
		DomainManager.Organization.TryFlushPendingAchievement(MainThreadDataContext);
		if (!DomainManager.TutorialChapter.InGuiding)
		{
			OnEvent_RecordEnterGame();
			DomainManager.Building.TryFinishChickenMapTask(DataContextManager.GetCurrentThreadDataContext());
		}
	}

	[DomainMethod]
	public void OnNewGameMonth(DataContext context)
	{
		OnEvent_NewGameMonth();
		DomainManager.Building.TriggerBuildingCompleteEvents(MainThreadDataContext);
		SetNeedToNotifyNewMonth(value: false, context);
	}

	[DomainMethod]
	[Obsolete]
	public void OnCombatWithXiangshuMinionComplete(short templateId)
	{
	}

	[DomainMethod]
	public void OnBlackMaskAnimationComplete(bool maskVisible)
	{
		OnEvent_BlackMaskAnimationComplete(maskVisible);
	}

	[DomainMethod]
	[Obsolete]
	public void OnMakingSystemOpened(BuildingBlockKey blockKey, short templateId)
	{
	}

	[DomainMethod]
	public void OnCollectedMakingSystemItem(BuildingBlockKey blockKey, short templateId, bool showingGetItem)
	{
		OnEvent_CollectedMakingSystemItem(blockKey, templateId, showingGetItem);
	}

	[DomainMethod]
	public void OnSectSpecialBuildingClicked(short templateId)
	{
		OnEvent_OnSectSpecialBuildingClicked(templateId);
	}

	[DomainMethod]
	public void AnimalAvatarClicked(int animalId)
	{
		DataContext context = DataContextManager.GetCurrentThreadDataContext();
		DomainManager.Global.InvokeGuidingTrigger(context, 28);
		OnEvent_AnimalAvatarClicked(animalId);
	}

	[DomainMethod]
	public void MainStoryFinishCatchCricket(bool result)
	{
		OnEvent_MainStoryFinishCatchCricket(result);
	}

	[DomainMethod]
	public void NpcTombClicked(int tombId)
	{
		OnEvent_NpcTombClicked(tombId);
	}

	[DomainMethod]
	public void OnLifeSkillCombatForceSilent(int charId, sbyte concessionCount, sbyte inducementCount)
	{
		OnEvent_LifeSkillCombatForceSilent(charId, concessionCount, inducementCount);
	}

	[DomainMethod]
	public void TryMoveWhenMoveDisable()
	{
		OnEvent_TryMoveWhenMoveDisabled();
	}

	[DomainMethod]
	public void TryMoveToInvalidLocationInTutorial()
	{
		OnEvent_TryMoveToInvalidLocationInTutorial();
	}

	[DomainMethod]
	public void CloseUI(string uiName, bool presetBool = false, int presetInt = -1)
	{
		DomainManager.TaiwuEvent.OnEvent_CloseUI(uiName, presetBool, presetInt);
	}

	[DomainMethod]
	public void OnEnterBuildingArea(DataContext context, Location location)
	{
		DomainManager.TaiwuEvent.OnEvent_EnterBuildingArea(location);
		DomainManager.TaiwuEvent.TriggerListener(EventActionKey.DefValue.EnterBuildingArea, value: false);
	}

	[DomainMethod]
	public void TaiwuCollectWudangHeavenlyTreeSeed(sbyte resourceType)
	{
		DomainManager.TaiwuEvent.OnEvent_TaiwuCollectWudangHeavenlyTreeSeed(resourceType);
	}

	[DomainMethod]
	public void TaiwuVillagerExpelled(int charId)
	{
		DomainManager.TaiwuEvent.OnEvent_TaiwuVillagerExpelled(charId);
	}

	[DomainMethod]
	public void TaiwuCrossArchiveFindMemory(sbyte type)
	{
		DomainManager.TaiwuEvent.OnEvent_TaiwuCrossArchiveFindMemory(type);
	}

	[DomainMethod]
	public void UserLoadDreamBackArchive()
	{
		DomainManager.TaiwuEvent.OnEvent_UserLoadDreamBackArchive();
		OnEvent_RecordEnterGame();
	}

	[DomainMethod]
	public void OperateInventoryItem(int charId, sbyte operationType, ItemDisplayData itemData)
	{
		DomainManager.TaiwuEvent.OnEvent_OperateInventoryItem(charId, operationType, itemData.Key, itemData.Amount);
	}

	[DomainMethod]
	public void SettlementTreasuryBuildingClicked(short templateId, byte currStatus, sbyte currPage)
	{
		DomainManager.TaiwuEvent.OnEvent_OnSettlementTreasuryBuildingClicked(templateId, currPage);
	}

	[DomainMethod]
	public void TriggerShixiangDrumEasterEgg()
	{
		DomainManager.TaiwuEvent.OnEvent_OnShixiangDrumClickedManyTimes();
	}

	[DomainMethod]
	public void OnClickedPrisonBtn(short buildingTemplateId)
	{
		DomainManager.TaiwuEvent.OnEvent_OnClickedPrisonBtn(buildingTemplateId);
	}

	[DomainMethod]
	public void OnClickedSendPrisonBtn()
	{
		DomainManager.TaiwuEvent.OnEvent_OnClickedSendPrisonBtn();
	}

	[DomainMethod]
	public void InteractPrisoner(int characterId, int interactPrisonerType)
	{
		DomainManager.TaiwuEvent.OnEvent_InteractPrisoner(characterId, interactPrisonerType);
	}

	[DomainMethod]
	public void OnClickMapPickupEvent(Location location)
	{
		DomainManager.TaiwuEvent.OnEvent_TriggerMapPickupEvent(location, arg1: true);
	}

	[DomainMethod]
	public void OnClickMapPickupNormalEvent(Location location)
	{
		if (!DomainManager.Map.TempDisableTriggerNormalPickupByTaiwuEscape)
		{
			DomainManager.TaiwuEvent.OnEvent_TriggerBatchMapPickupEvent(location, arg1: false, 0);
		}
	}

	[DomainMethod]
	public void OnClickMapPickupBatchEvent(BatchMapPickupInfo pickupInfo)
	{
		if (!DomainManager.Map.TempDisableTriggerNormalPickupByTaiwuEscape)
		{
			DomainManager.TaiwuEvent.OnEvent_TriggerBatchMapPickupEvent(pickupInfo.Location, pickupInfo.PickAll, pickupInfo.PickupIndex);
		}
	}

	[DomainMethod]
	public void OnClickDeportButton(int type, bool isGood)
	{
		DomainManager.Extra.SetCurrentVitalIndex(type);
		DomainManager.TaiwuEvent.OnEvent_TaiwuDeportVitals(type, isGood);
	}

	[DomainMethod]
	public void OnClickChickenCoop()
	{
		DomainManager.TaiwuEvent.OnEvent_OnClickedChickenCoop();
	}

	[DomainMethod]
	public void OnSwitchToGuardedPage(byte currStatus, sbyte currPage)
	{
		OnEvent_SwitchToGuardedPage(currStatus, currPage);
	}

	public void AddJieqingMaskCharId(int charId)
	{
		if (_jieqingMaskCharIdList == null)
		{
			_jieqingMaskCharIdList = new List<int>();
		}
		if (!_jieqingMaskCharIdList.Contains(charId))
		{
			_jieqingMaskCharIdList.Add(charId);
			SetJieqingMaskCharIdList(_jieqingMaskCharIdList, MainThreadDataContext);
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				character.SetAvatar(character.GetAvatar(), MainThreadDataContext);
			}
		}
	}

	public void RemoveJieqingMaskCharId(int charId)
	{
		if (_jieqingMaskCharIdList != null && _jieqingMaskCharIdList.Contains(charId))
		{
			_jieqingMaskCharIdList.Remove(charId);
			SetJieqingMaskCharIdList(_jieqingMaskCharIdList, MainThreadDataContext);
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				character.SetAvatar(character.GetAvatar(), MainThreadDataContext);
			}
		}
	}

	[DomainMethod]
	public void GmCmd_AddJieqingMaskCharId(int charId)
	{
		AddJieqingMaskCharId(charId);
	}

	[DomainMethod]
	public void GmCmd_RemoveJieqingMaskCharId(int charId)
	{
		RemoveJieqingMaskCharId(charId);
	}

	[DomainMethod]
	public void OnTaiwuTryInvite(DataContext context, int charId, Location location)
	{
		_invitedCharacterThisMonth.Add(charId);
		DomainManager.World.AdvanceDaysInMonth(context, GlobalConfig.Instance.AppointmentCostDays);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		ItemKey itemKey = taiwu.GetInventory().GetInventoryItemKey(12, 266);
		if (itemKey.IsValid())
		{
			taiwu.RemoveInventoryItem(context, itemKey, 1, deleteItem: true);
		}
		OnEvent_TaiwuInvite(charId, location);
	}

	public void InviteAdvanceMonth(DataContext context)
	{
		_invitedCharacterThisMonth.Clear();
	}

	public bool CheckCharacterInvitedThisMonth(int charId)
	{
		if (_invitedCharacterThisMonth.Contains(charId))
		{
			return true;
		}
		return _invitedCharacterThisMonth.Contains(charId);
	}

	public TaiwuEventDomain()
		: base(30)
	{
		_globalArgBox = new EventArgBox();
		_monthlyEventActionManager = new MonthlyEventActionsManager();
		_cgName = string.Empty;
		_notifyData = new EventNotifyData();
		_hasListeningEvent = false;
		_selectInformationData = new EventSelectInformationData();
		_taiwuLocationChangeFlag = false;
		_secretVillageOnFire = false;
		_taiwuVillageShowShrine = false;
		_hideAllTeammates = false;
		_leftRoleAlternativeName = string.Empty;
		_rightRoleAlternativeName = string.Empty;
		_rightRoleXiangshuDisplayData = new sbyte[2];
		_selectCombatSkillData = new EventSelectCombatSkillData();
		_selectLifeSkillData = new EventSelectLifeSkillData();
		_itemListOfLeft = new ItemDisplayData[3];
		_itemListOfRight = new ItemDisplayData[3];
		_showItemWithCricketBattleGuess = false;
		_displayingEventData = new TaiwuEventDisplayData();
		_tempCreateItemList = new List<ItemKey>();
		_coverCricketJarGradeListForRight = new List<sbyte>();
		_marriageLook1CharIdList = new List<int>();
		_marriageLook2CharIdList = new List<int>();
		_allCombatGroupChars = new int[3];
		_cricketBettingData = new EventCricketBettingData();
		_jieqingMaskCharIdList = new List<int>();
		_handledOneShotEvents = new HashSetAsDictionary<int>();
		_hideAllMapBlockCharacters = false;
		_needToNotifyNewMonth = false;
		_commonOptionPreviewEventOptionInfos = new List<EventOptionInfo>();
		OnInitializedDomainData();
	}

	private EventArgBox GetGlobalArgBox()
	{
		return _globalArgBox;
	}

	private void SetGlobalArgBox(EventArgBox value, DataContext context)
	{
		_globalArgBox = value;
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private MonthlyEventActionsManager GetMonthlyEventActionManager()
	{
		return _monthlyEventActionManager;
	}

	private void SetMonthlyEventActionManager(MonthlyEventActionsManager value, DataContext context)
	{
		_monthlyEventActionManager = value;
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	public string GetCgName()
	{
		return _cgName;
	}

	public void SetCgName(string value, DataContext context)
	{
		_cgName = value;
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	public EventNotifyData GetNotifyData()
	{
		return _notifyData;
	}

	private void SetNotifyData(EventNotifyData value, DataContext context)
	{
		_notifyData = value;
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	public bool GetHasListeningEvent()
	{
		return _hasListeningEvent;
	}

	private void SetHasListeningEvent(bool value, DataContext context)
	{
		_hasListeningEvent = value;
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	public EventSelectInformationData GetSelectInformationData()
	{
		return _selectInformationData;
	}

	public void SetSelectInformationData(EventSelectInformationData value, DataContext context)
	{
		_selectInformationData = value;
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	public bool GetTaiwuLocationChangeFlag()
	{
		return _taiwuLocationChangeFlag;
	}

	public void SetTaiwuLocationChangeFlag(bool value, DataContext context)
	{
		_taiwuLocationChangeFlag = value;
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	public bool GetSecretVillageOnFire()
	{
		return _secretVillageOnFire;
	}

	public void SetSecretVillageOnFire(bool value, DataContext context)
	{
		_secretVillageOnFire = value;
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	public bool GetTaiwuVillageShowShrine()
	{
		return _taiwuVillageShowShrine;
	}

	public void SetTaiwuVillageShowShrine(bool value, DataContext context)
	{
		_taiwuVillageShowShrine = value;
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	public bool GetHideAllTeammates()
	{
		return _hideAllTeammates;
	}

	public void SetHideAllTeammates(bool value, DataContext context)
	{
		_hideAllTeammates = value;
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	public string GetLeftRoleAlternativeName()
	{
		return _leftRoleAlternativeName;
	}

	public void SetLeftRoleAlternativeName(string value, DataContext context)
	{
		_leftRoleAlternativeName = value;
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	public string GetRightRoleAlternativeName()
	{
		return _rightRoleAlternativeName;
	}

	public void SetRightRoleAlternativeName(string value, DataContext context)
	{
		_rightRoleAlternativeName = value;
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	public sbyte[] GetRightRoleXiangshuDisplayData()
	{
		return _rightRoleXiangshuDisplayData;
	}

	public void SetRightRoleXiangshuDisplayData(sbyte[] value, DataContext context)
	{
		_rightRoleXiangshuDisplayData = value;
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	public EventSelectCombatSkillData GetSelectCombatSkillData()
	{
		return _selectCombatSkillData;
	}

	public void SetSelectCombatSkillData(EventSelectCombatSkillData value, DataContext context)
	{
		_selectCombatSkillData = value;
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	public EventSelectLifeSkillData GetSelectLifeSkillData()
	{
		return _selectLifeSkillData;
	}

	public void SetSelectLifeSkillData(EventSelectLifeSkillData value, DataContext context)
	{
		_selectLifeSkillData = value;
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	public ItemDisplayData[] GetItemListOfLeft()
	{
		return _itemListOfLeft;
	}

	public void SetItemListOfLeft(ItemDisplayData[] value, DataContext context)
	{
		_itemListOfLeft = value;
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	public ItemDisplayData[] GetItemListOfRight()
	{
		return _itemListOfRight;
	}

	public void SetItemListOfRight(ItemDisplayData[] value, DataContext context)
	{
		_itemListOfRight = value;
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	public bool GetShowItemWithCricketBattleGuess()
	{
		return _showItemWithCricketBattleGuess;
	}

	public void SetShowItemWithCricketBattleGuess(bool value, DataContext context)
	{
		_showItemWithCricketBattleGuess = value;
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	public TaiwuEventDisplayData GetDisplayingEventData()
	{
		return _displayingEventData;
	}

	public void SetDisplayingEventData(TaiwuEventDisplayData value, DataContext context)
	{
		_displayingEventData = value;
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
	}

	public List<ItemKey> GetTempCreateItemList()
	{
		return _tempCreateItemList;
	}

	public void SetTempCreateItemList(List<ItemKey> value, DataContext context)
	{
		_tempCreateItemList = value;
		SetModifiedAndInvalidateInfluencedCache(19, DataStates, CacheInfluences, context);
	}

	public List<sbyte> GetCoverCricketJarGradeListForRight()
	{
		return _coverCricketJarGradeListForRight;
	}

	public void SetCoverCricketJarGradeListForRight(List<sbyte> value, DataContext context)
	{
		_coverCricketJarGradeListForRight = value;
		SetModifiedAndInvalidateInfluencedCache(20, DataStates, CacheInfluences, context);
	}

	public List<int> GetMarriageLook1CharIdList()
	{
		return _marriageLook1CharIdList;
	}

	public void SetMarriageLook1CharIdList(List<int> value, DataContext context)
	{
		_marriageLook1CharIdList = value;
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	public List<int> GetMarriageLook2CharIdList()
	{
		return _marriageLook2CharIdList;
	}

	public void SetMarriageLook2CharIdList(List<int> value, DataContext context)
	{
		_marriageLook2CharIdList = value;
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	public int[] GetAllCombatGroupChars()
	{
		return _allCombatGroupChars;
	}

	public void SetAllCombatGroupChars(int[] value, DataContext context)
	{
		_allCombatGroupChars = value;
		SetModifiedAndInvalidateInfluencedCache(23, DataStates, CacheInfluences, context);
	}

	public EventCricketBettingData GetCricketBettingData()
	{
		return _cricketBettingData;
	}

	public void SetCricketBettingData(EventCricketBettingData value, DataContext context)
	{
		_cricketBettingData = value;
		SetModifiedAndInvalidateInfluencedCache(24, DataStates, CacheInfluences, context);
	}

	public List<int> GetJieqingMaskCharIdList()
	{
		return _jieqingMaskCharIdList;
	}

	public void SetJieqingMaskCharIdList(List<int> value, DataContext context)
	{
		_jieqingMaskCharIdList = value;
		SetModifiedAndInvalidateInfluencedCache(25, DataStates, CacheInfluences, context);
	}

	private VoidValue GetElement_HandledOneShotEvents(int elementId)
	{
		return _handledOneShotEvents[elementId];
	}

	private bool TryGetElement_HandledOneShotEvents(int elementId, out VoidValue value)
	{
		return _handledOneShotEvents.TryGetValue(elementId, out value);
	}

	private void AddElement_HandledOneShotEvents(int elementId, VoidValue value, DataContext context)
	{
		_handledOneShotEvents.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(26, DataStates, CacheInfluences, context);
	}

	private void SetElement_HandledOneShotEvents(int elementId, VoidValue value, DataContext context)
	{
		_handledOneShotEvents[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(26, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_HandledOneShotEvents(int elementId, DataContext context)
	{
		_handledOneShotEvents.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(26, DataStates, CacheInfluences, context);
	}

	private void ClearHandledOneShotEvents(DataContext context)
	{
		_handledOneShotEvents.Clear();
		SetModifiedAndInvalidateInfluencedCache(26, DataStates, CacheInfluences, context);
	}

	public bool GetHideAllMapBlockCharacters()
	{
		return _hideAllMapBlockCharacters;
	}

	public void SetHideAllMapBlockCharacters(bool value, DataContext context)
	{
		_hideAllMapBlockCharacters = value;
		SetModifiedAndInvalidateInfluencedCache(27, DataStates, CacheInfluences, context);
	}

	public bool GetNeedToNotifyNewMonth()
	{
		return _needToNotifyNewMonth;
	}

	public void SetNeedToNotifyNewMonth(bool value, DataContext context)
	{
		_needToNotifyNewMonth = value;
		SetModifiedAndInvalidateInfluencedCache(28, DataStates, CacheInfluences, context);
	}

	public List<EventOptionInfo> GetCommonOptionPreviewEventOptionInfos()
	{
		return _commonOptionPreviewEventOptionInfos;
	}

	public void SetCommonOptionPreviewEventOptionInfos(List<EventOptionInfo> value, DataContext context)
	{
		_commonOptionPreviewEventOptionInfos = value;
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
		archive.WriteSingleValueUnmanaged((ushort)12);
		archive.WriteDomainDataMeta(0);
		archive.WriteSingleValueCustom(_globalArgBox);
		archive.WriteDomainDataMeta(1);
		archive.WriteSingleValueCustom(_monthlyEventActionManager);
		archive.WriteDomainDataMeta(7);
		archive.WriteSingleValueUnmanaged(_secretVillageOnFire);
		archive.WriteDomainDataMeta(8);
		archive.WriteSingleValueUnmanaged(_taiwuVillageShowShrine);
		archive.WriteDomainDataMeta(9);
		archive.WriteSingleValueUnmanaged(_hideAllTeammates);
		archive.WriteDomainDataMeta(19);
		archive.WriteSingleValueCustomList(_tempCreateItemList);
		archive.WriteDomainDataMeta(21);
		archive.WriteSingleValueUnmanagedList(_marriageLook1CharIdList);
		archive.WriteDomainDataMeta(22);
		archive.WriteSingleValueUnmanagedList(_marriageLook2CharIdList);
		archive.WriteDomainDataMeta(23);
		archive.WriteSingleValueUnmanagedArray(_allCombatGroupChars);
		archive.WriteDomainDataMeta(26);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_handledOneShotEvents);
		archive.WriteDomainDataMeta(27);
		archive.WriteSingleValueUnmanaged(_hideAllMapBlockCharacters);
		archive.WriteDomainDataMeta(28);
		archive.WriteSingleValueUnmanaged(_needToNotifyNewMonth);
	}

	public override void OnLoadWorld(ArchiveFileBase archive)
	{
		ushort savedFieldCount = 0;
		archive.ReadSingleValueUnmanaged(ref savedFieldCount);
		DomainDataMeta domainDataMeta;
		for (int domainDataIndex = 0; domainDataIndex < savedFieldCount; RecordLoadedDomainData(domainDataMeta.DataId), domainDataIndex++)
		{
			domainDataMeta = archive.ReadDomainDataMeta();
			ushort dataId = domainDataMeta.DataId;
			ushort num = dataId;
			switch (num)
			{
			case 1:
				if (num != 1)
				{
					break;
				}
				archive.ReadSingleValueCustom(ref _monthlyEventActionManager);
				continue;
			case 0:
				archive.ReadSingleValueCustom(ref _globalArgBox);
				continue;
			case 7:
				archive.ReadSingleValueUnmanaged(ref _secretVillageOnFire);
				continue;
			case 8:
				archive.ReadSingleValueUnmanaged(ref _taiwuVillageShowShrine);
				continue;
			case 9:
				archive.ReadSingleValueUnmanaged(ref _hideAllTeammates);
				continue;
			case 19:
				archive.ReadSingleValueCustomList(ref _tempCreateItemList);
				continue;
			case 21:
				archive.ReadSingleValueUnmanagedList(ref _marriageLook1CharIdList);
				continue;
			case 22:
				archive.ReadSingleValueUnmanagedList(ref _marriageLook2CharIdList);
				continue;
			case 23:
				archive.ReadSingleValueUnmanagedArray(ref _allCombatGroupChars);
				continue;
			case 26:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_handledOneShotEvents);
				continue;
			case 27:
				archive.ReadSingleValueUnmanaged(ref _hideAllMapBlockCharacters);
				continue;
			case 28:
				archive.ReadSingleValueUnmanaged(ref _needToNotifyNewMonth);
				continue;
			}
			throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(12);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 1:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 2:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
			}
			return GameData.Serializer.Serializer.Serialize(_cgName, dataPool);
		case 3:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
			}
			return GameData.Serializer.Serializer.Serialize(_notifyData, dataPool);
		case 4:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
			}
			return GameData.Serializer.Serializer.Serialize(_hasListeningEvent, dataPool);
		case 5:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
			}
			return GameData.Serializer.Serializer.Serialize(_selectInformationData, dataPool);
		case 6:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 6);
			}
			return GameData.Serializer.Serializer.Serialize(_taiwuLocationChangeFlag, dataPool);
		case 7:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
			}
			return GameData.Serializer.Serializer.Serialize(_secretVillageOnFire, dataPool);
		case 8:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
			}
			return GameData.Serializer.Serializer.Serialize(_taiwuVillageShowShrine, dataPool);
		case 9:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
			}
			return GameData.Serializer.Serializer.Serialize(_hideAllTeammates, dataPool);
		case 10:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 10);
			}
			return GameData.Serializer.Serializer.Serialize(_leftRoleAlternativeName, dataPool);
		case 11:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
			}
			return GameData.Serializer.Serializer.Serialize(_rightRoleAlternativeName, dataPool);
		case 12:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 12);
			}
			return GameData.Serializer.Serializer.Serialize(_rightRoleXiangshuDisplayData, dataPool);
		case 13:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 13);
			}
			return GameData.Serializer.Serializer.Serialize(_selectCombatSkillData, dataPool);
		case 14:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 14);
			}
			return GameData.Serializer.Serializer.Serialize(_selectLifeSkillData, dataPool);
		case 15:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 15);
			}
			return GameData.Serializer.Serializer.Serialize(_itemListOfLeft, dataPool);
		case 16:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 16);
			}
			return GameData.Serializer.Serializer.Serialize(_itemListOfRight, dataPool);
		case 17:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 17);
			}
			return GameData.Serializer.Serializer.Serialize(_showItemWithCricketBattleGuess, dataPool);
		case 18:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 18);
			}
			return GameData.Serializer.Serializer.Serialize(_displayingEventData, dataPool);
		case 19:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 19);
			}
			return GameData.Serializer.Serializer.Serialize(_tempCreateItemList, dataPool);
		case 20:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 20);
			}
			return GameData.Serializer.Serializer.Serialize(_coverCricketJarGradeListForRight, dataPool);
		case 21:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 21);
			}
			return GameData.Serializer.Serializer.Serialize(_marriageLook1CharIdList, dataPool);
		case 22:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 22);
			}
			return GameData.Serializer.Serializer.Serialize(_marriageLook2CharIdList, dataPool);
		case 23:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 23);
			}
			return GameData.Serializer.Serializer.Serialize(_allCombatGroupChars, dataPool);
		case 24:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 24);
			}
			return GameData.Serializer.Serializer.Serialize(_cricketBettingData, dataPool);
		case 25:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 25);
			}
			return GameData.Serializer.Serializer.Serialize(_jieqingMaskCharIdList, dataPool);
		case 26:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 27:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 27);
			}
			return GameData.Serializer.Serializer.Serialize(_hideAllMapBlockCharacters, dataPool);
		case 28:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 28);
			}
			return GameData.Serializer.Serializer.Serialize(_needToNotifyNewMonth, dataPool);
		case 29:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 29);
			}
			return GameData.Serializer.Serializer.Serialize(_commonOptionPreviewEventOptionInfos, dataPool);
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
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _cgName);
			SetCgName(_cgName, context);
			break;
		case 3:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 4:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 5:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _selectInformationData);
			SetSelectInformationData(_selectInformationData, context);
			break;
		case 6:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _taiwuLocationChangeFlag);
			SetTaiwuLocationChangeFlag(_taiwuLocationChangeFlag, context);
			break;
		case 7:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _secretVillageOnFire);
			SetSecretVillageOnFire(_secretVillageOnFire, context);
			break;
		case 8:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _taiwuVillageShowShrine);
			SetTaiwuVillageShowShrine(_taiwuVillageShowShrine, context);
			break;
		case 9:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _hideAllTeammates);
			SetHideAllTeammates(_hideAllTeammates, context);
			break;
		case 10:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _leftRoleAlternativeName);
			SetLeftRoleAlternativeName(_leftRoleAlternativeName, context);
			break;
		case 11:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _rightRoleAlternativeName);
			SetRightRoleAlternativeName(_rightRoleAlternativeName, context);
			break;
		case 12:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _rightRoleXiangshuDisplayData);
			SetRightRoleXiangshuDisplayData(_rightRoleXiangshuDisplayData, context);
			break;
		case 13:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _selectCombatSkillData);
			SetSelectCombatSkillData(_selectCombatSkillData, context);
			break;
		case 14:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _selectLifeSkillData);
			SetSelectLifeSkillData(_selectLifeSkillData, context);
			break;
		case 15:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _itemListOfLeft);
			SetItemListOfLeft(_itemListOfLeft, context);
			break;
		case 16:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _itemListOfRight);
			SetItemListOfRight(_itemListOfRight, context);
			break;
		case 17:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _showItemWithCricketBattleGuess);
			SetShowItemWithCricketBattleGuess(_showItemWithCricketBattleGuess, context);
			break;
		case 18:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _displayingEventData);
			SetDisplayingEventData(_displayingEventData, context);
			break;
		case 19:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _tempCreateItemList);
			SetTempCreateItemList(_tempCreateItemList, context);
			break;
		case 20:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _coverCricketJarGradeListForRight);
			SetCoverCricketJarGradeListForRight(_coverCricketJarGradeListForRight, context);
			break;
		case 21:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _marriageLook1CharIdList);
			SetMarriageLook1CharIdList(_marriageLook1CharIdList, context);
			break;
		case 22:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _marriageLook2CharIdList);
			SetMarriageLook2CharIdList(_marriageLook2CharIdList, context);
			break;
		case 23:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _allCombatGroupChars);
			SetAllCombatGroupChars(_allCombatGroupChars, context);
			break;
		case 24:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _cricketBettingData);
			SetCricketBettingData(_cricketBettingData, context);
			break;
		case 25:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _jieqingMaskCharIdList);
			SetJieqingMaskCharIdList(_jieqingMaskCharIdList, context);
			break;
		case 26:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 27:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _hideAllMapBlockCharacters);
			SetHideAllMapBlockCharacters(_hideAllMapBlockCharacters, context);
			break;
		case 28:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _needToNotifyNewMonth);
			SetNeedToNotifyNewMonth(_needToNotifyNewMonth, context);
			break;
		case 29:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _commonOptionPreviewEventOptionInfos);
			SetCommonOptionPreviewEventOptionInfos(_commonOptionPreviewEventOptionInfos, context);
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
			int argsCount41 = operation.ArgsCount;
			int num41 = argsCount41;
			if (num41 == 1)
			{
				MonthlyActionKey key12 = default(MonthlyActionKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key12);
				(int, int) returnValue10 = GetMonthlyActionStateAndTime(key12);
				return GameData.Serializer.Serializer.Serialize(returnValue10, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
			if (operation.ArgsCount == 0)
			{
				InitConchShipEvents();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 2:
		{
			int argsCount49 = operation.ArgsCount;
			int num49 = argsCount49;
			if (num49 == 2)
			{
				string key15 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key15);
				bool value9 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value9);
				TriggerListener(key15, value9);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 3:
		{
			int argsCount67 = operation.ArgsCount;
			int num67 = argsCount67;
			if (num67 == 3)
			{
				string key21 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key21);
				ItemKey itemKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey);
				bool callComplete3 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref callComplete3);
				SetItemSelectResult(key21, itemKey, callComplete3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 4:
		{
			int argsCount15 = operation.ArgsCount;
			int num15 = argsCount15;
			if (num15 == 3)
			{
				string key2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key2);
				int charId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId3);
				bool callComplete2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref callComplete2);
				SetCharacterSelectResult(key2, charId3, callComplete2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 5:
		{
			int argsCount61 = operation.ArgsCount;
			int num61 = argsCount61;
			if (num61 == 2)
			{
				string key18 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key18);
				int secretId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref secretId);
				SetSecretInformationSelectResult(key18, secretId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 6:
		{
			int argsCount23 = operation.ArgsCount;
			int num23 = argsCount23;
			if (num23 == 2)
			{
				string key5 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key5);
				NormalInformation normalInformation = default(NormalInformation);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref normalInformation);
				SetNormalInformationSelectResult(key5, normalInformation);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 7:
			if (operation.ArgsCount == 0)
			{
				StartHandleEventDuringAdvance();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 8:
			if (operation.ArgsCount == 0)
			{
				List<TaiwuEventSummaryDisplayData> returnValue11 = GetTriggeredEventSummaryDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue11, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 9:
		{
			int argsCount36 = operation.ArgsCount;
			int num36 = argsCount36;
			if (num36 == 1)
			{
				string eventGuid3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref eventGuid3);
				SetEventInProcessing(eventGuid3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 10:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				string eventGuid2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref eventGuid2);
				string optionKey2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref optionKey2);
				EventSelect(eventGuid2, optionKey2);
				return -1;
			}
			case 3:
			{
				string eventGuid = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref eventGuid);
				string optionKey = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref optionKey);
				bool isContinue = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isContinue);
				EventSelect(eventGuid, optionKey, isContinue);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 11:
			if (operation.ArgsCount == 0)
			{
				List<TaiwuEventDisplayData> returnValue3 = GetEventDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 12:
			if (operation.ArgsCount == 0)
			{
				GmCmd_SaveMonthlyActionManager(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 13:
		{
			int argsCount60 = operation.ArgsCount;
			int num60 = argsCount60;
			if (num60 == 1)
			{
				int charId10 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId10);
				OnCharacterClicked(context, charId10);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 14:
		{
			int argsCount44 = operation.ArgsCount;
			int num44 = argsCount44;
			if (num44 == 1)
			{
				int charId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId6);
				OnLetTeammateLeaveGroup(context, charId6);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 15:
		{
			int argsCount31 = operation.ArgsCount;
			int num31 = argsCount31;
			if (num31 == 1)
			{
				int caravanId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref caravanId);
				OnInteractCaravan(caravanId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 16:
		{
			int argsCount18 = operation.ArgsCount;
			int num18 = argsCount18;
			if (num18 == 1)
			{
				int charId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId4);
				OnInteractKidnappedCharacter(charId4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 17:
		{
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 1)
			{
				short buildingTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingTemplateId);
				OnSectBuildingClicked(buildingTemplateId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 18:
			if (operation.ArgsCount == 0)
			{
				OnRecordEnterGame();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 19:
			if (operation.ArgsCount == 0)
			{
				OnNewGameMonth(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 20:
		{
			int argsCount55 = operation.ArgsCount;
			int num55 = argsCount55;
			if (num55 == 1)
			{
				short templateId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId8);
				OnCombatWithXiangshuMinionComplete(templateId8);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 21:
		{
			int argsCount47 = operation.ArgsCount;
			int num47 = argsCount47;
			if (num47 == 1)
			{
				bool maskVisible = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref maskVisible);
				OnBlackMaskAnimationComplete(maskVisible);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 22:
		{
			int argsCount37 = operation.ArgsCount;
			int num37 = argsCount37;
			if (num37 == 2)
			{
				BuildingBlockKey blockKey2 = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey2);
				short templateId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId5);
				OnMakingSystemOpened(blockKey2, templateId5);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 23:
		{
			int argsCount28 = operation.ArgsCount;
			int num28 = argsCount28;
			if (num28 == 3)
			{
				BuildingBlockKey blockKey = default(BuildingBlockKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockKey);
				short templateId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId4);
				bool showingGetItem = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref showingGetItem);
				OnCollectedMakingSystemItem(blockKey, templateId4, showingGetItem);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 24:
		{
			int argsCount20 = operation.ArgsCount;
			int num20 = argsCount20;
			if (num20 == 1)
			{
				short templateId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId3);
				OnSectSpecialBuildingClicked(templateId3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 25:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 1)
			{
				int animalId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref animalId);
				AnimalAvatarClicked(animalId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 26:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 1)
			{
				bool result = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref result);
				MainStoryFinishCatchCricket(result);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 27:
		{
			int argsCount71 = operation.ArgsCount;
			int num71 = argsCount71;
			if (num71 == 1)
			{
				string eventDataDirectory = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref eventDataDirectory);
				LoadEventsFromPath(eventDataDirectory);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 28:
		{
			int argsCount68 = operation.ArgsCount;
			int num68 = argsCount68;
			if (num68 == 1)
			{
				int tombId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref tombId);
				NpcTombClicked(tombId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 29:
		{
			int argsCount64 = operation.ArgsCount;
			int num64 = argsCount64;
			if (num64 == 1)
			{
				short lifeSkillId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref lifeSkillId);
				SetLifeSkillSelectResult(lifeSkillId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 30:
		{
			int argsCount57 = operation.ArgsCount;
			int num57 = argsCount57;
			if (num57 == 1)
			{
				short combatSkillId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatSkillId);
				SetCombatSkillSelectResult(combatSkillId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 31:
		{
			int argsCount52 = operation.ArgsCount;
			int num52 = argsCount52;
			if (num52 == 3)
			{
				int charId9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId9);
				sbyte concessionCount = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref concessionCount);
				sbyte inducementCount = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref inducementCount);
				OnLifeSkillCombatForceSilent(charId9, concessionCount, inducementCount);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 32:
			if (operation.ArgsCount == 0)
			{
				TryMoveWhenMoveDisable();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 33:
			if (operation.ArgsCount == 0)
			{
				TryMoveToInvalidLocationInTutorial();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 34:
		{
			int argsCount33 = operation.ArgsCount;
			int num33 = argsCount33;
			if (num33 == 3)
			{
				string actionName3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref actionName3);
				string key10 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key10);
				CharacterSet characterSet = default(CharacterSet);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterSet);
				SetCharacterSetSelectResult(actionName3, key10, characterSet);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 35:
		{
			int argsCount27 = operation.ArgsCount;
			int num27 = argsCount27;
			if (num27 == 1)
			{
				short characterTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterTemplateId);
				OnCharacterTemplateClicked(context, characterTemplateId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 36:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				string uiName3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref uiName3);
				CloseUI(uiName3);
				return -1;
			}
			case 2:
			{
				string uiName2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref uiName2);
				bool presetBool2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref presetBool2);
				CloseUI(uiName2, presetBool2);
				return -1;
			}
			case 3:
			{
				string uiName = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref uiName);
				bool presetBool = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref presetBool);
				int presetInt = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref presetInt);
				CloseUI(uiName, presetBool, presetInt);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 37:
		{
			int argsCount22 = operation.ArgsCount;
			int num22 = argsCount22;
			if (num22 == 1)
			{
				bool flag = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref flag);
				SetIsQuickStartGame(flag);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 38:
		{
			int argsCount16 = operation.ArgsCount;
			int num16 = argsCount16;
			if (num16 == 1)
			{
				sbyte resourceType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref resourceType);
				TaiwuCollectWudangHeavenlyTreeSeed(resourceType);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 39:
			if (operation.ArgsCount == 0)
			{
				EventLogData returnValue4 = GetEventLogData();
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 40:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 8)
			{
				IntPair charIds = default(IntPair);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charIds);
				string dialog = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref dialog);
				string rawResponseData = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref rawResponseData);
				EventActorData leftActor = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref leftActor);
				EventActorData rightActor = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref rightActor);
				string leftName = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref leftName);
				string rightName = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref rightName);
				short merchantTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantTemplateId);
				StartNewDialog(context, charIds, dialog, rawResponseData, leftActor, rightActor, leftName, rightName, merchantTemplateId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 41:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 1)
			{
				int charId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId2);
				TaiwuVillagerExpelled(charId2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 42:
			if (operation.ArgsCount == 0)
			{
				GmCmd_TaiwuCrossArchive();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 43:
		{
			int argsCount69 = operation.ArgsCount;
			int num69 = argsCount69;
			if (num69 == 1)
			{
				sbyte type2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref type2);
				TaiwuCrossArchiveFindMemory(type2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 44:
			if (operation.ArgsCount == 0)
			{
				UserLoadDreamBackArchive();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 45:
		{
			int argsCount63 = operation.ArgsCount;
			int num63 = argsCount63;
			if (num63 == 3)
			{
				int charId11 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId11);
				sbyte operationType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref operationType);
				ItemDisplayData itemData = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemData);
				OperateInventoryItem(charId11, operationType, itemData);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 46:
		{
			int argsCount58 = operation.ArgsCount;
			int num58 = argsCount58;
			if (num58 == 2)
			{
				string key17 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key17);
				int count = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count);
				SetItemSelectCount(key17, count);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 47:
		{
			int argsCount54 = operation.ArgsCount;
			int num54 = argsCount54;
			if (num54 == 3)
			{
				short templateId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId7);
				byte currStatus2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref currStatus2);
				sbyte currPage2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref currPage2);
				SettlementTreasuryBuildingClicked(templateId7, currStatus2, currPage2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 48:
		{
			int argsCount50 = operation.ArgsCount;
			int num50 = argsCount50;
			if (num50 == 3)
			{
				string actionName7 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref actionName7);
				string key16 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key16);
				ItemKey value10 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value10);
				SetListenerEventActionISerializableArg(actionName7, key16, value10);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 49:
		{
			int argsCount46 = operation.ArgsCount;
			int num46 = argsCount46;
			if (num46 == 3)
			{
				string actionName6 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref actionName6);
				string key14 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key14);
				int value8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value8);
				SetListenerEventActionIntArg(actionName6, key14, value8);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 50:
		{
			int argsCount42 = operation.ArgsCount;
			int num42 = argsCount42;
			if (num42 == 3)
			{
				string actionName5 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref actionName5);
				string key13 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key13);
				bool value7 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value7);
				SetListenerEventActionBoolArg(actionName5, key13, value7);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 51:
		{
			int argsCount39 = operation.ArgsCount;
			int num39 = argsCount39;
			if (num39 == 3)
			{
				string actionName4 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref actionName4);
				string key11 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key11);
				string value6 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value6);
				SetListenerEventActionStringArg(actionName4, key11, value6);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 52:
		{
			int argsCount34 = operation.ArgsCount;
			int num34 = argsCount34;
			if (num34 == 1)
			{
				int targetCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetCharId);
				List<short> returnValue7 = GetValidInteractionEventOptions(targetCharId);
				return GameData.Serializer.Serializer.Serialize(returnValue7, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 53:
		{
			int argsCount30 = operation.ArgsCount;
			int num30 = argsCount30;
			if (num30 == 3)
			{
				string actionName2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref actionName2);
				string key9 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key9);
				IntList value5 = default(IntList);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value5);
				SetListenerEventActionIntListArg(actionName2, key9, value5);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 54:
		{
			int argsCount25 = operation.ArgsCount;
			int num25 = argsCount25;
			if (num25 == 3)
			{
				string actionName = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref actionName);
				string key7 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key7);
				ItemKey value4 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value4);
				SetListenerEventActionItemKeyArg(actionName, key7, value4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 55:
			if (operation.ArgsCount == 0)
			{
				TriggerShixiangDrumEasterEgg();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 56:
		{
			int argsCount21 = operation.ArgsCount;
			int num21 = argsCount21;
			if (num21 == 2)
			{
				int characterId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId);
				int interactPrisonerType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref interactPrisonerType);
				InteractPrisoner(characterId, interactPrisonerType);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 57:
			if (operation.ArgsCount == 0)
			{
				OnClickedSendPrisonBtn();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 58:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 1)
			{
				short buildingTemplateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingTemplateId2);
				OnClickedPrisonBtn(buildingTemplateId2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 59:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 3)
			{
				string key = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key);
				List<int> charIds2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charIds2);
				bool callComplete = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref callComplete);
				SetCharacterMultSelectResult(key, charIds2, callComplete);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 60:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 3)
			{
				bool ok = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref ok);
				Wager wager = default(Wager);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref wager);
				int index = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index);
				SetCricketBettingResult(ok, wager, index);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 61:
			if (operation.ArgsCount == 0)
			{
				List<int> returnValue2 = GetImplementedFunctionIds(context);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 62:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 1)
			{
				bool isPaused = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isPaused);
				SetEventScriptExecutionPause(isPaused);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 63:
			if (operation.ArgsCount == 0)
			{
				EventScriptExecuteNext();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 64:
		{
			int argsCount70 = operation.ArgsCount;
			int num70 = argsCount70;
			if (num70 == 2)
			{
				sbyte orgTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgTemplateId);
				sbyte severity = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref severity);
				GmCmd_TaiwuWantedSectPunished(context, orgTemplateId, severity);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 65:
			if (operation.ArgsCount == 0)
			{
				EventSelectContinue();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 66:
		{
			int argsCount66 = operation.ArgsCount;
			int num66 = argsCount66;
			if (num66 == 1)
			{
				int count2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count2);
				SetSelectCount(count2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 67:
		{
			int argsCount65 = operation.ArgsCount;
			int num65 = argsCount65;
			if (num65 == 3)
			{
				string actionName8 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref actionName8);
				string key20 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key20);
				GameData.Utilities.ShortList value12 = default(GameData.Utilities.ShortList);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value12);
				SetListenerEventActionShortListArg(actionName8, key20, value12);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 68:
		{
			int argsCount62 = operation.ArgsCount;
			int num62 = argsCount62;
			if (num62 == 2)
			{
				string key19 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key19);
				GameData.Utilities.ShortList value11 = default(GameData.Utilities.ShortList);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value11);
				SetShowingEventShortListArg(key19, value11);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 69:
		{
			int argsCount59 = operation.ArgsCount;
			int num59 = argsCount59;
			if (num59 == 1)
			{
				Location location4 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location4);
				OnClickMapPickupEvent(location4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 70:
		{
			int argsCount56 = operation.ArgsCount;
			int num56 = argsCount56;
			if (num56 == 1)
			{
				Location location3 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location3);
				OnClickMapPickupNormalEvent(location3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 71:
		{
			int argsCount53 = operation.ArgsCount;
			int num53 = argsCount53;
			if (num53 == 2)
			{
				int type = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref type);
				bool isGood = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isGood);
				OnClickDeportButton(type, isGood);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 72:
		{
			int argsCount51 = operation.ArgsCount;
			int num51 = argsCount51;
			if (num51 == 2)
			{
				byte currStatus = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref currStatus);
				sbyte currPage = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref currPage);
				OnSwitchToGuardedPage(currStatus, currPage);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 73:
		{
			int argsCount48 = operation.ArgsCount;
			int num48 = argsCount48;
			if (num48 == 1)
			{
				int charId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId8);
				GmCmd_AddJieqingMaskCharId(charId8);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 74:
		{
			int argsCount45 = operation.ArgsCount;
			int num45 = argsCount45;
			if (num45 == 1)
			{
				int charId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId7);
				GmCmd_RemoveJieqingMaskCharId(charId7);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 75:
		{
			int argsCount43 = operation.ArgsCount;
			int num43 = argsCount43;
			if (num43 == 1)
			{
				short templateId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId6);
				EventCommonOptionSelect(templateId6);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 76:
		{
			int argsCount40 = operation.ArgsCount;
			int num40 = argsCount40;
			if (num40 == 2)
			{
				int targetCharId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetCharId3);
				short customButtonTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref customButtonTemplateId);
				bool returnValue9 = JumpToInteractionEventOption(targetCharId3, customButtonTemplateId);
				return GameData.Serializer.Serializer.Serialize(returnValue9, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 77:
		{
			int argsCount38 = operation.ArgsCount;
			int num38 = argsCount38;
			if (num38 == 2)
			{
				int targetCharId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetCharId2);
				short targetTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetTemplateId);
				bool returnValue8 = JumpToInteractionEventOptionByInteractionId(context, targetCharId2, targetTemplateId);
				return GameData.Serializer.Serializer.Serialize(returnValue8, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 78:
		{
			int argsCount35 = operation.ArgsCount;
			int num35 = argsCount35;
			if (num35 == 2)
			{
				int charId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId5);
				Location location2 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location2);
				OnTaiwuTryInvite(context, charId5, location2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 79:
		{
			int argsCount32 = operation.ArgsCount;
			int num32 = argsCount32;
			if (num32 == 1)
			{
				List<string> packageNameList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref packageNameList);
				ReloadConchShipEvents(packageNameList);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 80:
		{
			int argsCount29 = operation.ArgsCount;
			int num29 = argsCount29;
			if (num29 == 1)
			{
				BatchMapPickupInfo pickupInfo = default(BatchMapPickupInfo);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref pickupInfo);
				OnClickMapPickupBatchEvent(pickupInfo);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 81:
		{
			int argsCount26 = operation.ArgsCount;
			int num26 = argsCount26;
			if (num26 == 1)
			{
				string key8 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key8);
				GlobalArgValue returnValue6 = GmCmd_GetGlobalArgBoxInt(key8);
				return GameData.Serializer.Serializer.Serialize(returnValue6, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 82:
		{
			int argsCount24 = operation.ArgsCount;
			int num24 = argsCount24;
			if (num24 == 2)
			{
				string key6 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key6);
				int value3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value3);
				GmCmd_SetGlobalArgBoxInt(context, key6, value3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 83:
			if (operation.ArgsCount == 0)
			{
				bool returnValue5 = CheckIsShowingEvent();
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 84:
			if (operation.ArgsCount == 0)
			{
				OnClickChickenCoop();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 85:
		{
			int argsCount19 = operation.ArgsCount;
			int num19 = argsCount19;
			if (num19 == 2)
			{
				string key4 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key4);
				ItemKey value2 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value2);
				SetShowingEventItemKeyArg(key4, value2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 86:
		{
			int argsCount17 = operation.ArgsCount;
			int num17 = argsCount17;
			if (num17 == 2)
			{
				string key3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref key3);
				short value = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value);
				SetShowingEventShortArg(key3, value);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 87:
		{
			int argsCount14 = operation.ArgsCount;
			int num14 = argsCount14;
			if (num14 == 1)
			{
				Location location = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location);
				OnEnterBuildingArea(context, location);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 88:
			if (operation.ArgsCount == 0)
			{
				UpdateShowingEventTaiwuCharacterDisplayData();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 89:
		{
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 1)
			{
				short templateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId2);
				EventCommonOptionPreview(templateId2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 90:
			if (operation.ArgsCount == 0)
			{
				GmCmd_TravelToPastTaiwuVillage(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 91:
			if (operation.ArgsCount == 0)
			{
				GmCmd_BackFromPastTaiwuVillage(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 92:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 1)
			{
				short templateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId);
				bool returnValue = EventCommonOptionHaveAvailableOption(templateId);
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 93:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 3)
			{
				int combatResult = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatResult);
				int combatType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatType);
				int mainEnemyId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref mainEnemyId);
				GmCmd_TriggerOvercomeCombatOver(combatResult, combatType, mainEnemyId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 94:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 1)
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				MeetTaiwu(context, charId);
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
		case 10:
			return;
		case 11:
			return;
		case 12:
			return;
		case 13:
			return;
		case 14:
			return;
		case 15:
			return;
		case 16:
			return;
		case 17:
			return;
		case 18:
			return;
		case 19:
			return;
		case 20:
			return;
		case 21:
			return;
		case 22:
			return;
		case 23:
			return;
		case 24:
			return;
		case 25:
			return;
		case 26:
			return;
		case 27:
			return;
		case 28:
			return;
		case 29:
			return;
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override int CheckModified(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 1:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 2:
			if (!BaseGameDataDomain.IsModified(DataStates, 2))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 2);
			return GameData.Serializer.Serializer.Serialize(_cgName, dataPool);
		case 3:
			if (!BaseGameDataDomain.IsModified(DataStates, 3))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 3);
			return GameData.Serializer.Serializer.Serialize(_notifyData, dataPool);
		case 4:
			if (!BaseGameDataDomain.IsModified(DataStates, 4))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 4);
			return GameData.Serializer.Serializer.Serialize(_hasListeningEvent, dataPool);
		case 5:
			if (!BaseGameDataDomain.IsModified(DataStates, 5))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 5);
			return GameData.Serializer.Serializer.Serialize(_selectInformationData, dataPool);
		case 6:
			if (!BaseGameDataDomain.IsModified(DataStates, 6))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 6);
			return GameData.Serializer.Serializer.Serialize(_taiwuLocationChangeFlag, dataPool);
		case 7:
			if (!BaseGameDataDomain.IsModified(DataStates, 7))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 7);
			return GameData.Serializer.Serializer.Serialize(_secretVillageOnFire, dataPool);
		case 8:
			if (!BaseGameDataDomain.IsModified(DataStates, 8))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 8);
			return GameData.Serializer.Serializer.Serialize(_taiwuVillageShowShrine, dataPool);
		case 9:
			if (!BaseGameDataDomain.IsModified(DataStates, 9))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 9);
			return GameData.Serializer.Serializer.Serialize(_hideAllTeammates, dataPool);
		case 10:
			if (!BaseGameDataDomain.IsModified(DataStates, 10))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 10);
			return GameData.Serializer.Serializer.Serialize(_leftRoleAlternativeName, dataPool);
		case 11:
			if (!BaseGameDataDomain.IsModified(DataStates, 11))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 11);
			return GameData.Serializer.Serializer.Serialize(_rightRoleAlternativeName, dataPool);
		case 12:
			if (!BaseGameDataDomain.IsModified(DataStates, 12))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 12);
			return GameData.Serializer.Serializer.Serialize(_rightRoleXiangshuDisplayData, dataPool);
		case 13:
			if (!BaseGameDataDomain.IsModified(DataStates, 13))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 13);
			return GameData.Serializer.Serializer.Serialize(_selectCombatSkillData, dataPool);
		case 14:
			if (!BaseGameDataDomain.IsModified(DataStates, 14))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 14);
			return GameData.Serializer.Serializer.Serialize(_selectLifeSkillData, dataPool);
		case 15:
			if (!BaseGameDataDomain.IsModified(DataStates, 15))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 15);
			return GameData.Serializer.Serializer.Serialize(_itemListOfLeft, dataPool);
		case 16:
			if (!BaseGameDataDomain.IsModified(DataStates, 16))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 16);
			return GameData.Serializer.Serializer.Serialize(_itemListOfRight, dataPool);
		case 17:
			if (!BaseGameDataDomain.IsModified(DataStates, 17))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 17);
			return GameData.Serializer.Serializer.Serialize(_showItemWithCricketBattleGuess, dataPool);
		case 18:
			if (!BaseGameDataDomain.IsModified(DataStates, 18))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 18);
			return GameData.Serializer.Serializer.Serialize(_displayingEventData, dataPool);
		case 19:
			if (!BaseGameDataDomain.IsModified(DataStates, 19))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 19);
			return GameData.Serializer.Serializer.Serialize(_tempCreateItemList, dataPool);
		case 20:
			if (!BaseGameDataDomain.IsModified(DataStates, 20))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 20);
			return GameData.Serializer.Serializer.Serialize(_coverCricketJarGradeListForRight, dataPool);
		case 21:
			if (!BaseGameDataDomain.IsModified(DataStates, 21))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 21);
			return GameData.Serializer.Serializer.Serialize(_marriageLook1CharIdList, dataPool);
		case 22:
			if (!BaseGameDataDomain.IsModified(DataStates, 22))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 22);
			return GameData.Serializer.Serializer.Serialize(_marriageLook2CharIdList, dataPool);
		case 23:
			if (!BaseGameDataDomain.IsModified(DataStates, 23))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 23);
			return GameData.Serializer.Serializer.Serialize(_allCombatGroupChars, dataPool);
		case 24:
			if (!BaseGameDataDomain.IsModified(DataStates, 24))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 24);
			return GameData.Serializer.Serializer.Serialize(_cricketBettingData, dataPool);
		case 25:
			if (!BaseGameDataDomain.IsModified(DataStates, 25))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 25);
			return GameData.Serializer.Serializer.Serialize(_jieqingMaskCharIdList, dataPool);
		case 26:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 27:
			if (!BaseGameDataDomain.IsModified(DataStates, 27))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 27);
			return GameData.Serializer.Serializer.Serialize(_hideAllMapBlockCharacters, dataPool);
		case 28:
			if (!BaseGameDataDomain.IsModified(DataStates, 28))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 28);
			return GameData.Serializer.Serializer.Serialize(_needToNotifyNewMonth, dataPool);
		case 29:
			if (!BaseGameDataDomain.IsModified(DataStates, 29))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 29);
			return GameData.Serializer.Serializer.Serialize(_commonOptionPreviewEventOptionInfos, dataPool);
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
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
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
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
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
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override bool IsModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		return dataId switch
		{
			0 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			1 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
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
			26 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			27 => BaseGameDataDomain.IsModified(DataStates, 27), 
			28 => BaseGameDataDomain.IsModified(DataStates, 28), 
			29 => BaseGameDataDomain.IsModified(DataStates, 29), 
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
