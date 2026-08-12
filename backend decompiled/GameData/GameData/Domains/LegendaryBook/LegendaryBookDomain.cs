using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Achievement;
using GameData.ArchiveData;
using GameData.Common;
using GameData.Common.SingleValueCollection;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using NLog;

namespace GameData.Domains.LegendaryBook;

[GameDataDomain(11)]
public class LegendaryBookDomain : BaseGameDataDomain
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[DomainData(DomainDataType.ElementList, true, false, true, true, ArrayElementsCount = 14)]
	private readonly int[] _bookOwners;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<int, int> _legendaryBookShockedMonths;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private readonly Dictionary<sbyte, IntPair> _prevLegendaryBookOwnerCopies;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private CharacterSet _legendaryBookConsumedCharIds;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<sbyte, CharacterSet> _contestForLegendaryBookChars;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private CharacterSet _legendaryBookHiddenCharIds;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private sbyte _firstLegendaryBookDelay;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<sbyte, CharacterSet> _previousLegendaryBookOwners;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private LegendaryBookOwnerData _legendaryBookOwnerData;

	private Dictionary<int, List<sbyte>> _charBookTypes;

	private readonly Location[] _bookAdventureLocations = new Location[14];

	private readonly HashSet<int> _actCrazyShockedCharIds = new HashSet<int>();

	private const int CallCharacterPerMonth = 4;

	private const int ActivateDelayMin = 3;

	private const int ActivateDelayMax = 9;

	private readonly ItemKey[] _legendaryBookItems = new ItemKey[14];

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, false)]
	private Dictionary<sbyte, GameData.Utilities.ShortList> _legendaryBookSkillPresetSlot;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private Dictionary<sbyte, LegendaryBookWeaponPreset> _legendaryBookWeaponPresetSlot;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private sbyte _currentUnlockedPresetAmount;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private sbyte _currentUsingPresetIndex;

	private sbyte _initialPresetCount = 3;

	private int _maximumPresetCount = 9;

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[13][];

	private static readonly DataInfluence[][] CacheInfluencesBookOwners = new DataInfluence[14][];

	private readonly byte[] _dataStatesBookOwners = new byte[4];

	private SingleValueCollectionModificationCollection<int> _modificationsLegendaryBookShockedMonths = SingleValueCollectionModificationCollection<int>.Create();

	private SingleValueCollectionModificationCollection<sbyte> _modificationsPrevLegendaryBookOwnerCopies = SingleValueCollectionModificationCollection<sbyte>.Create();

	private SingleValueCollectionModificationCollection<sbyte> _modificationsLegendaryBookSkillPresetSlot = SingleValueCollectionModificationCollection<sbyte>.Create();

	private Queue<uint> _pendingLoadingOperationIds;

	[DataUpgrader(Version = "1.0.48", Date = "2026/07/03")]
	private void FixAbnormalHiddenLegendaryBookOwner(DataContext context)
	{
		if (_legendaryBookHiddenCharIds.GetCount() <= 0)
		{
			return;
		}
		List<int> toRemove = null;
		foreach (int charId in _legendaryBookHiddenCharIds.GetCollection())
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				List<sbyte> charOwnedBookTypes = GetCharOwnedBookTypes(charId);
				if (charOwnedBookTypes == null || charOwnedBookTypes.Count <= 0)
				{
					DomainManager.Character.UnhideCharacterOnMap(context, character, 16uL);
					Logger.Warn($"Fixing abnormal hidden legendary book owner: {character}");
					if (toRemove == null)
					{
						toRemove = new List<int>();
					}
					toRemove.Add(charId);
				}
			}
			else
			{
				if (toRemove == null)
				{
					toRemove = new List<int>();
				}
				toRemove.Add(charId);
			}
		}
		if (toRemove != null && toRemove.Count > 0)
		{
			foreach (int charId2 in toRemove)
			{
				_legendaryBookHiddenCharIds.Remove(charId2);
			}
		}
		SetLegendaryBookHiddenCharIds(_legendaryBookHiddenCharIds, context);
	}

	private void InitializeBookTypesWithAdventure()
	{
		for (int i = 0; i < _bookAdventureLocations.Length; i++)
		{
			_bookAdventureLocations[i] = Location.Invalid;
		}
		int[] coreIds = AiHelper.LegendaryBookRelatedConstants.LegendaryBookAdventures;
		foreach (IAdventureRuntime runtime in DomainManager.Adventure.QueryAnyInWorld(coreIds))
		{
			int bookType = coreIds.IndexOf(runtime.CoreId);
			if (bookType >= 0)
			{
				if (_bookAdventureLocations[bookType].IsValid())
				{
					Logger.AppendWarning($"Duplicate legendary book adventure {runtime.Core.Name} detected at {_bookAdventureLocations[bookType]} and {runtime.MapLocation}.");
				}
				_bookAdventureLocations[bookType] = runtime.MapLocation;
			}
		}
	}

	public void InitializeOwnedItems()
	{
		for (int index = 0; index < _bookAdventureLocations.Length; index++)
		{
			Location location = _bookAdventureLocations[index];
			if (location.IsValid())
			{
				ItemKey bookItemKey = _legendaryBookItems[index];
				DomainManager.Item.SetOwner(bookItemKey, ItemOwnerType.System, 11);
			}
		}
	}

	private void OnInitializedDomainData()
	{
		InitializeLegendaryBookItems();
	}

	private void InitializeOnInitializeGameDataModule()
	{
	}

	private void InitializeOnEnterNewWorld()
	{
		for (int i = 0; i < 14; i++)
		{
			_bookOwners[i] = -1;
		}
		InitializeCharBookTypes();
		InitializeBookTypesWithAdventure();
		InitializeBookPresetData();
	}

	private void OnLoadedArchiveData()
	{
		InitializeCharBookTypes();
		InitializeBookTypesWithAdventure();
	}

	public override void OnCurrWorldArchiveDataReady(DataContext context, bool isNewWorld)
	{
		base.OnCurrWorldArchiveDataReady(context, isNewWorld);
		InitAllPrevLegendaryBookOwnerCopies(context);
	}

	public void ClearActCrazyShockedCharacters()
	{
		_actCrazyShockedCharIds.Clear();
	}

	public void AddActCrazyShockedCharacters(int charId)
	{
		_actCrazyShockedCharIds.Add(charId);
	}

	public bool IsCharacterActingCrazy(GameData.Domains.Character.Character character)
	{
		sbyte ownerState = character.GetLegendaryBookOwnerState();
		if (1 == 0)
		{
		}
		bool result = ownerState >= 1 && (ownerState != 1 || _actCrazyShockedCharIds.Contains(character.GetId()));
		if (1 == 0)
		{
		}
		return result;
	}

	public void CreateLegendaryBooksAccordingToXiangshuProgress(DataContext context)
	{
		if (!DomainManager.World.GetWorldFunctionsStatus(21))
		{
			SetFirstLegendaryBookDelay((sbyte)context.Random.Next(3, 9), context);
			return;
		}
		sbyte monthLeft = _firstLegendaryBookDelay;
		if (monthLeft > 0)
		{
			SetFirstLegendaryBookDelay((sbyte)(monthLeft - 1), context);
			return;
		}
		List<TemplateKey> missingItems = context.AdvanceMonthRelatedData.ItemTemplateKeys.Occupy();
		for (sbyte combatSkillType = 0; combatSkillType < 14; combatSkillType++)
		{
			short templateId = (short)(240 + combatSkillType);
			if (!DomainManager.Item.HasTrackedSpecialItems(12, templateId))
			{
				missingItems.Add(new TemplateKey(12, templateId));
			}
		}
		CollectionUtils.Shuffle(context.Random, missingItems);
		int legendaryBookUnlockProgress = Math.Clamp(DomainManager.World.GetXiangshuLevel() - 1, 0, GlobalConfig.Instance.LegendaryBookAppearAmounts.Length - 1);
		sbyte expectedBookAmount = GlobalConfig.Instance.LegendaryBookAppearAmounts[legendaryBookUnlockProgress];
		int currAmount = 14 - missingItems.Count;
		if (currAmount < expectedBookAmount && context.Random.CheckPercentProb(GlobalConfig.Instance.LegendaryBookAppearChance))
		{
			TemplateKey itemToCreate = TemplateKey.Invalid;
			short areaId = -1;
			if (currAmount == 0)
			{
				CombatSkillShorts attainments = DomainManager.Taiwu.GetTaiwu().GetCombatSkillAttainments();
				int attainment = -1;
				foreach (TemplateKey missingItem in missingItems)
				{
					if (missingItem.TemplateId > 242)
					{
						short currAttainment = attainments[missingItem.TemplateId - 240];
						if (attainment < currAttainment)
						{
							itemToCreate = missingItem;
							attainment = currAttainment;
							areaId = DomainManager.Taiwu.GetTaiwuVillageLocation().AreaId;
						}
					}
				}
			}
			if (areaId < 0)
			{
				itemToCreate = missingItems.GetRandom(context.Random);
				areaId = (short)context.Random.Next(45);
			}
			sbyte bookType = (sbyte)(itemToCreate.TemplateId - 240);
			ItemKey item = DomainManager.Item.CreateItem(context, itemToCreate.ItemType, itemToCreate.TemplateId);
			CreateLegendaryBookAdventure(context, areaId, bookType, 0);
		}
		context.AdvanceMonthRelatedData.ItemTemplateKeys.Release(ref missingItems);
	}

	public void Test_GiveUnownedLegendaryBookToTaiwu(DataContext context)
	{
		List<ItemKey> warehouseItemKeys = DomainManager.Taiwu.GetWarehouseAllItemKey();
		for (sbyte bookType = 0; bookType < _legendaryBookItems.Length; bookType++)
		{
			ItemKey itemKey = _legendaryBookItems[bookType];
			if (itemKey.IsValid() && GetOwner(bookType) < 0 && !warehouseItemKeys.Contains(itemKey))
			{
				DomainManager.Taiwu.GetTaiwu().AddInventoryItem(context, itemKey, 1);
			}
		}
	}

	public void UpdateLegendaryBookOwnersStatuses(DataContext context)
	{
		DomainManager.Taiwu.ClearAllDeadCricketPolymorphLegendaryBookStatus(context);
		List<int> owners = context.AdvanceMonthRelatedData.CharIdList.Occupy();
		owners.AddRange(_charBookTypes.Keys);
		foreach (int ownerCharId in owners)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(ownerCharId);
			if (character.GetId() == DomainManager.Taiwu.GetTaiwuCharId() || character.IsActiveExternalRelationState(172uL))
			{
				continue;
			}
			if (character.GetAgeGroup() != 2)
			{
				LoseAllLegendaryBooks(context, character, createAdventures: true);
				continue;
			}
			if (character.GetKidnapperId() >= 0)
			{
				DomainManager.Character.RemoveKidnappedCharacter(context, ownerCharId, character.GetKidnapperId(), isEscaped: true);
			}
			UpdateOwnerStatus(context, character);
		}
		foreach (int charId in _legendaryBookConsumedCharIds.GetCollection())
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character2))
			{
				character2.ActivateAdvanceMonthStatus(7);
			}
		}
		context.AdvanceMonthRelatedData.CharIdList.Release(ref owners);
	}

	private void UpdateOwnerStatus(DataContext context, GameData.Domains.Character.Character character)
	{
		int charId = character.GetId();
		byte invasionSpeedType = DomainManager.World.GetBossInvasionSpeedType();
		TryGetElement_LegendaryBookShockedMonths(charId, out var shockedMonths);
		switch (character.GetLegendaryBookOwnerState())
		{
		case 0:
			UpdateLegendaryBookOwnerGrowth(context, character);
			break;
		case 1:
			if (shockedMonths >= GlobalConfig.SwordTombAdventureCountDownCoolDown[invasionSpeedType] * 2)
			{
				character.AddFeature(context, 215, removeMutexFeature: true);
				DomainManager.Character.LeaveGroup(context, character, bringWards: false);
				Events.RaiseLegendaryBookOwnerStateChanged(context, character, 2);
			}
			else if (context.Random.CheckPercentProb(50))
			{
				AddActCrazyShockedCharacters(charId);
				AdaptableLog.TagInfo("LegendaryBook", $"{character} => 入邪发狂判定通过");
			}
			SetLegendaryBookShockedMonths(context, charId, shockedMonths + 1);
			if (!IsCharacterHiddenByLegendaryBook(charId))
			{
				break;
			}
			if (!character.GetLocation().IsValid())
			{
				short settlementId = character.GetOrganizationInfo().SettlementId;
				if (settlementId < 0)
				{
					settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
				}
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
				Location location = settlement.GetLocation();
				character.SetLocation(location, context);
			}
			RemoveLegendaryBookHiddenChar(context, charId);
			DomainManager.Character.UnhideCharacterOnMap(context, character, 16uL);
			break;
		case 2:
			if (shockedMonths >= GlobalConfig.SwordTombAdventureCountDownCoolDown[invasionSpeedType] * 3)
			{
				List<sbyte> ownedBookTypes = DomainManager.LegendaryBook.GetCharOwnedBookTypes(charId);
				foreach (sbyte combatSkillType in ownedBookTypes)
				{
					short featureId = Config.CombatSkillType.Instance[combatSkillType].LegendaryBookConsumedFeature;
					character.AddFeature(context, featureId, removeMutexFeature: true);
				}
				AddLegendaryBookConsumed(context, charId);
				Events.RaiseLegendaryBookOwnerStateChanged(context, character, 3);
				LoseAllLegendaryBooks(context, character, createAdventures: true);
			}
			else
			{
				SetLegendaryBookShockedMonths(context, charId, shockedMonths + 1);
			}
			break;
		case 3:
			LoseAllLegendaryBooks(context, character, createAdventures: true);
			break;
		}
		if (IsCharacterActingCrazy(character))
		{
			character.ActivateAdvanceMonthStatus(7);
		}
	}

	private void UpdateLegendaryBookOwnerGrowth(DataContext context, GameData.Domains.Character.Character character)
	{
		int charId = character.GetId();
		sbyte consummateLevel = character.GetConsummateLevel();
		sbyte behaviorType = character.GetBehaviorType();
		if (character.GetOrganizationInfo().OrgTemplateId == 16)
		{
			DomainManager.Character.LeaveGroup(context, character, bringWards: false);
			DomainManager.Organization.JoinNearbyVillageTownAsBeggar(context, character, -1);
			if (character.IsCrossAreaTraveling())
			{
				if (!character.GetLocation().IsValid())
				{
					Location validLocation = character.GetValidLocation();
					character.SetLocation(validLocation, context);
				}
				DomainManager.Character.RemoveCrossAreaTravelInfo(context, charId);
			}
			DomainManager.Character.HideCharacterOnMap(context, character, 16uL);
			DomainManager.World.GetMonthlyNotificationCollection().AddVillagerLeftForLegendaryBook(charId);
			AddLegendaryBookHiddenChar(context, charId);
		}
		if (consummateLevel < 18)
		{
			consummateLevel = (sbyte)Math.Clamp(consummateLevel + 2, 0, 18);
			character.SetConsummateLevel(consummateLevel, context);
		}
		if (consummateLevel >= 18)
		{
			character.AddFeature(context, 214);
			SetLegendaryBookShockedMonths(context, charId, 1);
			Events.RaiseLegendaryBookOwnerStateChanged(context, character, 1);
		}
		int grade = consummateLevel / 2;
		int xiangshuMinionTemplateId = 366 + grade;
		CharacterItem xiangshuMinionCfg = Config.Character.Instance[xiangshuMinionTemplateId];
		if (character.GetExtraNeili() < xiangshuMinionCfg.ExtraNeili)
		{
			character.SetExtraNeili(xiangshuMinionCfg.ExtraNeili, context);
		}
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(charId);
		List<sbyte> ownedBookTypes = DomainManager.LegendaryBook.GetCharOwnedBookTypes(charId);
		Span<bool> learnedSkillTypes = stackalloc bool[14];
		learnedSkillTypes.Fill(value: false);
		foreach (CombatSkillItem skillCfg in (IEnumerable<CombatSkillItem>)Config.CombatSkill.Instance)
		{
			if (skillCfg.Grade > grade || !ownedBookTypes.Contains(skillCfg.Type) || skillCfg.BookId < 0)
			{
				continue;
			}
			if (!combatSkills.TryGetValue(skillCfg.TemplateId, out var combatSkill))
			{
				byte pageTypes = GameData.Domains.Item.SkillBook.GenerateCombatPageTypes(context.Random, -1, 50);
				combatSkill = character.LearnNewCombatSkill(context, skillCfg.TemplateId, CombatSkillStateHelper.GenerateReadingStateFromSkillBook(pageTypes));
				learnedSkillTypes[skillCfg.Type] = true;
			}
			if (!CombatSkillStateHelper.IsBrokenOut(combatSkill.GetActivationState()))
			{
				byte pageTypes2 = GameData.Domains.Item.SkillBook.GenerateCombatPageTypes(context.Random, -1, 50);
				ushort readingState = (ushort)(combatSkill.GetReadingState() | CombatSkillStateHelper.GenerateReadingStateFromSkillBook(pageTypes2));
				DomainManager.CombatSkill.SetCombatSkillReadingState(context, combatSkill, readingState);
				if (combatSkill.CanBreakout())
				{
					ushort activationState = CombatSkillStateHelper.GenerateRandomActivatedNormalPages(context.Random, readingState, 0);
					activationState = CombatSkillStateHelper.GenerateRandomActivatedOutlinePage(context.Random, readingState, activationState, behaviorType);
					sbyte availableStepsCount = character.GetSkillBreakoutAvailableStepsCount(skillCfg.TemplateId);
					combatSkill.SetActivationState(activationState, context);
					combatSkill.SetBreakoutStepsCount(availableStepsCount, context);
					learnedSkillTypes[skillCfg.Type] = true;
				}
			}
		}
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		foreach (sbyte bookType in ownedBookTypes)
		{
			if (learnedSkillTypes[bookType])
			{
				ItemKey itemKey = GetLegendaryBookItem(bookType);
				lifeRecordCollection.AddBoostedByLegendaryBooks(charId, currDate, location, itemKey.ItemType, itemKey.TemplateId);
			}
		}
	}

	public void UpdateLegendaryBookOwnersActions(DataContext context)
	{
		List<int> owners = ObjectPool<List<int>>.Instance.Get();
		owners.AddRange(_charBookTypes.Keys);
		foreach (int ownerCharId in owners)
		{
			if (DomainManager.Character.TryGetElement_Objects(ownerCharId, out var character) && ownerCharId != DomainManager.Taiwu.GetTaiwuCharId() && IsCharacterActingCrazy(character))
			{
				UpdateOwnerAction(context, character);
			}
		}
		ObjectPool<List<int>>.Instance.Return(owners);
	}

	private void UpdateOwnerAction(DataContext context, GameData.Domains.Character.Character character)
	{
		Location location = character.GetLocation();
		if (location.IsValid() && !character.IsActiveExternalRelationState(188uL))
		{
			GameData.Domains.Character.Character harmActionTarget = SelectHarmActionTarget(context, character, location);
			if (harmActionTarget != null)
			{
				LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
				int currDate = DomainManager.World.GetCurrDate();
				lifeRecordCollection.AddActCrazy(character.GetId(), currDate, location);
				DomainManager.Character.HandleAttackAction(context, character, harmActionTarget);
			}
		}
	}

	private GameData.Domains.Character.Character SelectHarmActionTarget(DataContext context, GameData.Domains.Character.Character character, Location location)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		int selfCharId = character.GetId();
		if (location.Equals(taiwuChar.GetLocation()))
		{
			return taiwuChar;
		}
		MapBlockData block = DomainManager.Map.GetBlock(location);
		if (block.CharacterSet == null || block.CharacterSet.Count == 1)
		{
			return null;
		}
		List<int> charIdList = context.AdvanceMonthRelatedData.TargetCharIdList.Occupy();
		charIdList.AddRange(block.CharacterSet);
		charIdList.RemoveAll((int charId) => DomainManager.Character.GetElement_Objects(charId).GetAgeGroup() == 0 || charId == selfCharId);
		int targetCharId = charIdList.GetRandomOrDefault(context.Random, -1);
		context.AdvanceMonthRelatedData.TargetCharIdList.Release(ref charIdList);
		if (targetCharId < 0)
		{
			return null;
		}
		return DomainManager.Character.GetElement_Objects(targetCharId);
	}

	public void UpgradeEnemyNestsByLegendaryBookOwner(DataContext context, short areaId, int upgradeCount)
	{
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		monthlyNotifications.AddRandomEnemyGrow(new Location(areaId, -1));
	}

	public void CreateLegendaryBookAdventure(DataContext context, short areaId, sbyte bookType, sbyte appearType, int prevOwnerId = -1)
	{
		MapBlockData blockData = DomainManager.Map.GetRandomMapBlockDataInAreaByFilters(context.Random, areaId, null, includeBlocksWithAdventure: false);
		if (blockData == null)
		{
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(areaId);
			blockData = DomainManager.Map.GetRandomMapBlockDataByFilters(context.Random, stateTemplateId, -1, null, includeBlockWithAdventure: false);
		}
		Location location = blockData.GetLocation();
		CreateLegendaryBookAdventure(context, location, bookType, appearType, prevOwnerId);
	}

	public void CreateLegendaryBookAdventure(DataContext context, Location location, sbyte bookType, sbyte appearType, int prevOwnerId = -1)
	{
		int adventureId = AiHelper.LegendaryBookRelatedConstants.LegendaryBookAdventures[bookType];
		IAdventureRuntime adventure = DomainManager.Adventure.GenerateAny(context, adventureId, location);
		if (adventure == null)
		{
			throw new Exception($"Unable to create legendary book adventure: bookType={bookType}, location={location}, prevOwnerId={prevOwnerId}");
		}
		adventure.SetParameter("ConchShipPresetKey_CallCharacterCountLimit", 4);
		adventure.SetParameter("ConchShipPresetKey_CallCharactersExceptHide", true);
		sbyte firstMonthDelay = _firstLegendaryBookDelay;
		bool isFirst = firstMonthDelay == 0;
		SetFirstLegendaryBookDelay(-1, context);
		int currDate = DomainManager.World.GetCurrDate();
		sbyte activeDelay = (sbyte)((!isFirst) ? ((sbyte)context.Random.Next(3, 10)) : 0);
		adventure.OfflineHide(context);
		adventure.SetParameter("ConchShipPresetKey_AutoStopHideDate", currDate + activeDelay);
		adventure.SetParameter("ConchShipPresetKey_BookType", bookType);
		adventure.SetParameter("ConchShipPresetKey_AppearType", appearType);
		adventure.SetParameter("ConchShipPresetKey_PrevOwnerId", prevOwnerId);
		DomainManager.Adventure.SetAny(context, adventure);
		_bookAdventureLocations[bookType] = adventure.MapLocation;
	}

	public static bool IsLegendaryBookAdventure(int coreId)
	{
		return AiHelper.LegendaryBookRelatedConstants.LegendaryBookAdventures.Exist(coreId);
	}

	public void OnLegendaryBookAdventureRemoved(DataContext context, IAdventureRuntime adventure)
	{
		sbyte bookType = (sbyte)adventure.GetParameter("ConchShipPresetKey_BookType").Current;
		sbyte appearType = (sbyte)adventure.GetParameter("ConchShipPresetKey_AppearType").Current;
		int prevOwnerId = adventure.GetParameter("ConchShipPresetKey_PrevOwnerId").Current;
		Location location = adventure.MapLocation;
		_bookAdventureLocations[bookType] = Location.Invalid;
		if (DomainManager.LegendaryBook.GetOwner(bookType) < 0 && !AssignRandomOwner(context, adventure))
		{
			CreateLegendaryBookAdventure(context, location.AreaId, bookType, appearType, prevOwnerId);
		}
	}

	public void OnLegendaryBookAdventureActivated(DataContext context, IAdventureRuntime adventure)
	{
		sbyte bookType = (sbyte)adventure.GetParameter("ConchShipPresetKey_BookType").Current;
		sbyte appearType = (sbyte)adventure.GetParameter("ConchShipPresetKey_AppearType").Current;
		int prevOwnerId = adventure.GetParameter("ConchShipPresetKey_PrevOwnerId").Current;
		ItemKey itemKey = DomainManager.LegendaryBook.GetLegendaryBookItem(bookType);
		Location location = adventure.MapLocation;
		DomainManager.Map.EnsureBlockVisible(context, location);
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		switch (appearType)
		{
		case 0:
			monthlyEventCollection.AddFightForNewLegendaryBook(location, (ulong)itemKey);
			monthlyNotifications.AddFightForNewLegendaryBook(location, itemKey.ItemType, itemKey.TemplateId);
			break;
		case 1:
			monthlyEventCollection.AddFightForLegendaryBookOwnerConsumed(prevOwnerId, location, (ulong)itemKey);
			monthlyNotifications.AddFightForLegendaryBookOwnerConsumed(prevOwnerId, location, itemKey.ItemType, itemKey.TemplateId);
			break;
		case 2:
			monthlyEventCollection.AddFightForLegendaryBookOwnerDie(prevOwnerId, location, (ulong)itemKey);
			monthlyNotifications.AddFightForLegendaryBookOwnerDie(prevOwnerId, location, itemKey.ItemType, itemKey.TemplateId);
			break;
		case 3:
			monthlyEventCollection.AddFightForLegendaryBookAbandoned(prevOwnerId, location, (ulong)itemKey);
			monthlyNotifications.AddFightForLegendaryBookAbandoned(prevOwnerId, location, itemKey.ItemType, itemKey.TemplateId);
			break;
		}
	}

	private bool AssignRandomOwner(DataContext context, IAdventureRuntime adventure)
	{
		sbyte bookType = (sbyte)adventure.GetParameter("ConchShipPresetKey_BookType").Current;
		Location location = adventure.MapLocation;
		List<int> charList = new List<int>();
		adventure.CollectCharacters(charList);
		for (int i = 0; i < charList.Count; i++)
		{
			int participateCharId = charList[i];
			if (!DomainManager.Character.TryGetElement_Objects(participateCharId, out var character) || !character.GetLocation().Equals(adventure.MapLocation) || character.IsCompletelyInfected() || character.GetLegendaryBookOwnerState() >= 3 || character.GetKidnapperId() >= 0)
			{
				charList.RemoveAt(i);
			}
		}
		if (charList.Count == 0)
		{
			AdaptableLog.TagInfo("LegendaryBook", $"Failed to assign random owner for book type {bookType}.");
			return false;
		}
		int randomOwnerId = charList.GetRandom(context.Random);
		GameData.Domains.Character.Character randomOwner = DomainManager.Character.GetElement_Objects(randomOwnerId);
		ItemKey itemKey = DomainManager.LegendaryBook.GetLegendaryBookItem(bookType);
		randomOwner.AddInventoryItem(context, itemKey, 1);
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		monthlyNotifications.AddLegendaryBookAppeared(randomOwner.GetId(), location, itemKey.ItemType, itemKey.TemplateId);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		lifeRecordCollection.AddGainLegendaryBook(randomOwner.GetId(), currDate, location, itemKey.ItemType, itemKey.TemplateId);
		return true;
	}

	private void InitAllPrevLegendaryBookOwnerCopies(DataContext context)
	{
		foreach (IntPair pair in _prevLegendaryBookOwnerCopies.Values)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(pair.First);
			character.OfflineSetSrcCharId(pair.Second);
			DomainManager.Character.RemoveInfectedCharFromSet(pair.First);
		}
	}

	public bool IsPrevLegendaryBookOwnerCopy(int charId)
	{
		foreach (IntPair value in _prevLegendaryBookOwnerCopies.Values)
		{
			if (value.First == charId)
			{
				return true;
			}
		}
		return false;
	}

	public int GetPrevLegendaryBookOwnerCopyId(sbyte combatSkillType)
	{
		IntPair pair;
		return _prevLegendaryBookOwnerCopies.TryGetValue(combatSkillType, out pair) ? pair.First : (-1);
	}

	private void RegisterPrevLegendaryBookOwner(DataContext context, GameData.Domains.Character.Character character, sbyte combatSkillType)
	{
		GameData.Domains.Character.Character prevOwnerCopy = DomainManager.Character.CreateTemporaryCopyOfCharacter(context, character);
		context.Equipping.SelectEquipments(context, prevOwnerCopy, isOutOfTaiwuGroup: true);
		IntPair newPair = new IntPair(prevOwnerCopy.GetId(), character.GetId());
		if (_prevLegendaryBookOwnerCopies.TryGetValue(combatSkillType, out var pair))
		{
			int lastCopyCharId = pair.First;
			GameData.Domains.Character.Character toRemoveCopy = DomainManager.Character.GetElement_Objects(lastCopyCharId);
			DomainManager.Character.RemoveTemporaryIntelligentCharacter(context, toRemoveCopy);
			SetElement_PrevLegendaryBookOwnerCopies(combatSkillType, newPair, context);
		}
		else
		{
			AddElement_PrevLegendaryBookOwnerCopies(combatSkillType, newPair, context);
		}
	}

	private void AddPreviousLegendaryBookOwner(DataContext context, int charId, sbyte legendaryBookType)
	{
		if (_previousLegendaryBookOwners.TryGetValue(legendaryBookType, out var characterSet))
		{
			if (characterSet.Add(charId))
			{
				SetElement_PreviousLegendaryBookOwners(legendaryBookType, characterSet, context);
			}
		}
		else
		{
			characterSet.Add(charId);
			AddElement_PreviousLegendaryBookOwners(legendaryBookType, characterSet, context);
		}
	}

	public bool IsLegendaryBookOwned(sbyte legendaryBookType)
	{
		CharacterSet characterSet;
		return _previousLegendaryBookOwners.TryGetValue(legendaryBookType, out characterSet) && characterSet.GetCount() != 0;
	}

	public bool IsLegendaryBookConsumed(int charId)
	{
		return _legendaryBookConsumedCharIds.Contains(charId);
	}

	public void GetLegendaryBookConsumedCharacters(HashSet<int> charIds)
	{
		charIds.Clear();
		charIds.UnionWith(_legendaryBookConsumedCharIds.GetCollection());
	}

	private void AddLegendaryBookConsumed(DataContext context, int charId)
	{
		_legendaryBookConsumedCharIds.Add(charId);
		SetLegendaryBookConsumedCharIds(_legendaryBookConsumedCharIds, context);
	}

	private void RemoveLegendaryBookConsumed(DataContext context, int charId)
	{
		if (_legendaryBookConsumedCharIds.Remove(charId).Item2)
		{
			SetLegendaryBookConsumedCharIds(_legendaryBookConsumedCharIds, context);
		}
	}

	public CharacterSet GetContestForLegendaryBookCharacterSet(sbyte legendaryBookType)
	{
		_contestForLegendaryBookChars.TryGetValue(legendaryBookType, out var charSet);
		return charSet;
	}

	public void AddContestForLegendaryBookCharacter(DataContext context, int charId, sbyte legendaryBookType)
	{
		if (_contestForLegendaryBookChars.TryGetValue(legendaryBookType, out var characterSet))
		{
			if (characterSet.Add(charId))
			{
				SetElement_ContestForLegendaryBookChars(legendaryBookType, characterSet, context);
			}
		}
		else
		{
			characterSet.Add(charId);
			AddElement_ContestForLegendaryBookChars(legendaryBookType, characterSet, context);
		}
	}

	public void RemoveContestForLegendaryBookCharacter(DataContext context, int charId, sbyte legendaryBookType)
	{
		if (_contestForLegendaryBookChars.TryGetValue(legendaryBookType, out var characterSet))
		{
			var (isEmpty, removeSucceed) = characterSet.Remove(charId);
			if (isEmpty)
			{
				RemoveElement_ContestForLegendaryBookChars(legendaryBookType, context);
			}
			else
			{
				SetElement_ContestForLegendaryBookChars(legendaryBookType, characterSet, context);
			}
		}
	}

	private void RemoveContestForLegendaryBookCharacters(DataContext context, sbyte legendaryBookType)
	{
		if (_contestForLegendaryBookChars.TryGetValue(legendaryBookType, out var characterSet))
		{
			characterSet.Clear();
			RemoveElement_ContestForLegendaryBookChars(legendaryBookType, context);
		}
	}

	private bool IsCharacterHiddenByLegendaryBook(int charId)
	{
		return _legendaryBookHiddenCharIds.Contains(charId);
	}

	private void AddLegendaryBookHiddenChar(DataContext context, int charId)
	{
		_legendaryBookHiddenCharIds.Add(charId);
		SetLegendaryBookHiddenCharIds(_legendaryBookHiddenCharIds, context);
	}

	private void RemoveLegendaryBookHiddenChar(DataContext context, int charId)
	{
		(bool, bool) tuple = _legendaryBookHiddenCharIds.Remove(charId);
		var (isEmpty, _) = tuple;
		if (tuple.Item2)
		{
			SetLegendaryBookHiddenCharIds(_legendaryBookHiddenCharIds, context);
		}
	}

	private void SetLegendaryBookShockedMonths(DataContext context, int charId, int months)
	{
		if (_legendaryBookShockedMonths.ContainsKey(charId))
		{
			SetElement_LegendaryBookShockedMonths(charId, months, context);
		}
		else
		{
			AddElement_LegendaryBookShockedMonths(charId, months, context);
		}
	}

	private void RemoveLegendaryBookShockedMonths(DataContext context, int charId)
	{
		if (_legendaryBookShockedMonths.ContainsKey(charId))
		{
			RemoveElement_LegendaryBookShockedMonths(charId, context);
		}
	}

	public void RegisterOwner(DataContext context, GameData.Domains.Character.Character character, sbyte bookType)
	{
		AdaptableLog.TagInfo("LegendaryBook", $"{character} => 得到奇书 {Config.Misc.Instance[240 + bookType].Name}");
		int oriOwner = _bookOwners[bookType];
		if (oriOwner >= 0)
		{
			throw new Exception($"Book {bookType} already has owner: {oriOwner}");
		}
		int charId = character.GetId();
		SetElement_BookOwners(bookType, charId, context);
		RegisterCharBookType(charId, bookType);
		character.TryRetireTreasuryGuard(context);
		if (charId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			DomainManager.World.SetWorldFunctionsStatus(context, 21);
			AchievementManager.RequestSetStat(context, (short)(273 + bookType), 1);
			AchievementManager.RequestSetStat(context, 287, _charBookTypes[charId].Count);
		}
		else if (DomainManager.Taiwu.GetLegacyPassingState() != 4)
		{
			short featureId = Config.CombatSkillType.Instance[bookType].LegendaryBookFeature;
			character.AddFeature(context, featureId);
		}
	}

	public void UnregisterOwner(DataContext context, GameData.Domains.Character.Character character, sbyte bookType)
	{
		AdaptableLog.TagInfo("LegendaryBook", $"{character} => 失去奇书 {Config.Misc.Instance[240 + bookType].Name}");
		int oriOwner = _bookOwners[bookType];
		int charId = character.GetId();
		if (oriOwner < 0)
		{
			throw new Exception($"Book {bookType} does not have owner");
		}
		if (oriOwner != charId)
		{
			throw new Exception($"Wrong owner of book {bookType}: {oriOwner} - {charId}");
		}
		List<short> featureIds = character.GetFeatureIds();
		short bookFeatureId = Config.CombatSkillType.Instance[bookType].LegendaryBookFeature;
		bool isLegendaryBookConsumed = DomainManager.LegendaryBook.IsLegendaryBookConsumed(charId);
		if (isLegendaryBookConsumed || featureIds.Contains(215))
		{
			DomainManager.Character.UnregisterFeatureForAllXiangshuAvatars(context, bookFeatureId);
			RegisterPrevLegendaryBookOwner(context, character, bookType);
			MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
			sbyte currAdvancingMonthState = DomainManager.World.GetAdvancingMonthState();
			if (currAdvancingMonthState > 0 && currAdvancingMonthState < 14)
			{
				ItemKey itemKey = DomainManager.LegendaryBook.GetLegendaryBookItem(bookType);
				monthlyEventCollection.AddSwordTombBackToNormal((ulong)itemKey);
			}
		}
		SetElement_BookOwners(bookType, -1, context);
		UnregisterCharBookType(charId, bookType);
		RemoveContestForLegendaryBookCharacters(context, bookType);
		AddPreviousLegendaryBookOwner(context, charId, bookType);
		if (character.IsTaiwu())
		{
			List<sbyte> bookList;
			int count = (_charBookTypes.TryGetValue(charId, out bookList) ? bookList.Count : 0);
			AchievementManager.RequestSetStat(context, 287, count);
		}
		if (!DomainManager.Character.IsCharacterAlive(charId))
		{
			return;
		}
		character.RemoveFeature(context, bookFeatureId);
		if (!(_charBookTypes.ContainsKey(charId) || isLegendaryBookConsumed))
		{
			if (_legendaryBookHiddenCharIds.Contains(charId))
			{
				RemoveLegendaryBookHiddenChar(context, charId);
				DomainManager.Character.UnhideCharacterOnMap(context, character, 16uL);
			}
			RemoveLegendaryBookShockedMonths(context, charId);
			character.RemoveFeature(context, 214);
			character.RemoveFeature(context, 215);
		}
	}

	public int GetOwner(sbyte bookType)
	{
		return _bookOwners[bookType];
	}

	public sbyte GetConsumedCharacterLegendaryBookType(GameData.Domains.Character.Character character)
	{
		short minFeatureId = Config.CombatSkillType.Instance[(sbyte)0].LegendaryBookConsumedFeature;
		short maxFeatureId = Config.CombatSkillType.Instance[(sbyte)13].LegendaryBookConsumedFeature;
		foreach (short featureId in character.GetFeatureIds())
		{
			if (featureId >= minFeatureId && featureId <= maxFeatureId)
			{
				return (sbyte)(featureId - minFeatureId);
			}
		}
		return -1;
	}

	public void UpdateBossCharacterLegendaryBookFeatures(DataContext context, GameData.Domains.Character.Character character)
	{
		sbyte xiangshuType = character.GetXiangshuType();
		switch (xiangshuType)
		{
		case 1:
		{
			foreach (CombatSkillTypeItem combatSkillTypeCfg3 in (IEnumerable<CombatSkillTypeItem>)Config.CombatSkillType.Instance)
			{
				character.RemoveFeatureGroup(context, combatSkillTypeCfg3.LegendaryBookFeature);
			}
			for (sbyte combatSkillType2 = 0; combatSkillType2 < 14; combatSkillType2++)
			{
				int ownerId = _bookOwners[combatSkillType2];
				if (ownerId >= 0)
				{
					GameData.Domains.Character.Character owner = DomainManager.Character.GetElement_Objects(ownerId);
					if (owner.GetLegendaryBookOwnerState() == 2)
					{
						short featureToAdd2 = Config.CombatSkillType.Instance[combatSkillType2].LegendaryBookConsumedFeature;
						character.AddFeature(context, featureToAdd2);
					}
				}
			}
			break;
		}
		default:
			if (character.GetTemplateId() != 918)
			{
				if (xiangshuType != 4)
				{
					break;
				}
				foreach (CombatSkillTypeItem combatSkillTypeCfg in (IEnumerable<CombatSkillTypeItem>)Config.CombatSkillType.Instance)
				{
					character.RemoveFeatureGroup(context, combatSkillTypeCfg.LegendaryBookFeature);
				}
				List<short> features = DomainManager.Extra.GetWoodenXiangshuAvatarSelectedFeatures();
				{
					foreach (short featureId in features)
					{
						character.AddFeature(context, featureId);
					}
					break;
				}
			}
			goto case 2;
		case 2:
			foreach (CombatSkillTypeItem combatSkillTypeCfg2 in (IEnumerable<CombatSkillTypeItem>)Config.CombatSkillType.Instance)
			{
				character.RemoveFeatureGroup(context, combatSkillTypeCfg2.LegendaryBookFeature);
			}
			{
				foreach (int consumedCharId in _legendaryBookConsumedCharIds.GetCollection())
				{
					if (!DomainManager.Character.TryGetElement_Objects(consumedCharId, out var consumedChar))
					{
						continue;
					}
					short minFeatureId = Config.CombatSkillType.Instance[(sbyte)0].LegendaryBookConsumedFeature;
					short maxFeatureId = Config.CombatSkillType.Instance[(sbyte)13].LegendaryBookConsumedFeature;
					foreach (short featureId2 in consumedChar.GetFeatureIds())
					{
						if (featureId2 >= minFeatureId && featureId2 <= maxFeatureId)
						{
							int combatSkillType = featureId2 - minFeatureId;
							short featureToAdd = Config.CombatSkillType.Instance[combatSkillType].LegendaryBookConsumedFeature;
							character.AddFeature(context, featureToAdd);
						}
					}
				}
				break;
			}
		}
	}

	public sbyte GetCharacterLegendaryBookOwnerState(int charId)
	{
		if (DomainManager.LegendaryBook.IsLegendaryBookConsumed(charId))
		{
			return 3;
		}
		if (DomainManager.LegendaryBook.GetCharOwnedBookTypes(charId) == null || !DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return -1;
		}
		List<short> featureIds = character.GetFeatureIds();
		if (featureIds.Contains(214))
		{
			return 1;
		}
		if (featureIds.Contains(215))
		{
			return 2;
		}
		return 0;
	}

	public sbyte GetLegendaryBookAppearType(int prevOwnerId)
	{
		if (prevOwnerId < 0)
		{
			return 0;
		}
		if (!DomainManager.Character.IsCharacterAlive(prevOwnerId))
		{
			return 2;
		}
		if (DomainManager.LegendaryBook.IsLegendaryBookConsumed(prevOwnerId))
		{
			return 1;
		}
		return 3;
	}

	public List<sbyte> GetCharOwnedBookTypes(int charId)
	{
		List<sbyte> bookTypes;
		return _charBookTypes.TryGetValue(charId, out bookTypes) ? bookTypes : null;
	}

	public void OnCharacterDead(DataContext context, GameData.Domains.Character.Character character)
	{
		int charId = character.GetId();
		RemoveLegendaryBookConsumed(context, charId);
		RemoveLegendaryBookShockedMonths(context, charId);
		DomainManager.Extra.ApplyRanshanThreeCorpsesLegendaryBookActionTargetDeadResult(context, charId);
		LoseAllLegendaryBooks(context, character, createAdventures: true);
	}

	public bool LoseAllLegendaryBooks(DataContext context, GameData.Domains.Character.Character character, bool createAdventures)
	{
		int charId = character.GetId();
		List<sbyte> bookTypes = GetCharOwnedBookTypes(charId);
		if (bookTypes == null)
		{
			return false;
		}
		Dictionary<ItemKey, int> inventoryItems = character.GetInventory().Items;
		List<ItemKey> toRemoveItems = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		foreach (ItemKey itemKey in inventoryItems.Keys)
		{
			if (ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == 1202)
			{
				toRemoveItems.Add(itemKey);
			}
		}
		sbyte appearType = GetLegendaryBookAppearType(charId);
		Inventory inventory = character.GetInventory();
		Location location = character.GetLocation();
		short areaId = location.AreaId;
		if (areaId < 0)
		{
			areaId = (short)context.Random.Next(45);
		}
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		monthlyNotificationCollection.AddRandomEnemyDecay(location);
		foreach (ItemKey itemKey2 in toRemoveItems)
		{
			sbyte bookCombatSkillType = (sbyte)(itemKey2.TemplateId - 240);
			if (appearType != 2)
			{
				character.RemoveInventoryItem(context, itemKey2, 1, deleteItem: false);
			}
			else
			{
				inventory.OfflineRemove(itemKey2, 1);
				UnregisterOwner(context, character, bookCombatSkillType);
				DomainManager.Item.GetBaseItem(itemKey2).ResetOwner();
				SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
				int secretInfoOffset = secretInformationCollection.AddLostQiBook(charId, (ulong)itemKey2);
				DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			}
			monthlyNotificationCollection.AddLegendaryBookLost(charId, location, itemKey2.ItemType, itemKey2.TemplateId);
			DomainManager.Item.SetOwner(itemKey2, ItemOwnerType.System, 11);
			if (createAdventures)
			{
				CreateLegendaryBookAdventure(context, areaId, bookCombatSkillType, appearType, charId);
			}
		}
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref toRemoveItems);
		return true;
	}

	public void LoseTargetLegendaryBook(DataContext context, GameData.Domains.Character.Character character, bool createAdventures, ItemKey itemKey)
	{
		int charId = character.GetId();
		sbyte appearType = GetLegendaryBookAppearType(charId);
		Inventory inventory = character.GetInventory();
		Location location = character.GetLocation();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		sbyte bookCombatSkillType = (sbyte)(itemKey.TemplateId - 240);
		short areaId = location.AreaId;
		if (areaId < 0)
		{
			areaId = (short)context.Random.Next(45);
		}
		if (appearType != 2)
		{
			character.RemoveInventoryItem(context, itemKey, 1, deleteItem: false);
		}
		else
		{
			inventory.OfflineRemove(itemKey, 1);
			UnregisterOwner(context, character, bookCombatSkillType);
			DomainManager.Item.GetBaseItem(itemKey).ResetOwner();
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddLostQiBook(charId, (ulong)itemKey);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		monthlyNotificationCollection.AddLegendaryBookLost(charId, location, itemKey.ItemType, itemKey.TemplateId);
		DomainManager.Item.SetOwner(itemKey, ItemOwnerType.System, 11);
		if (createAdventures)
		{
			CreateLegendaryBookAdventure(context, areaId, bookCombatSkillType, appearType, charId);
		}
	}

	public LegendaryBookCharacterRelatedData GetLegendaryBookCharacterRelatedData(DataContext context, int charId, sbyte bookType = -1)
	{
		if (!GameData.Domains.Character.Character.IsCharacterIdValid(charId) || !DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return null;
		}
		Location location = character.GetLocation();
		FullBlockName blockName = DomainManager.Map.GetBlockFullName(location);
		if (location != Location.Invalid)
		{
			MapBlockData blockData = DomainManager.Map.GetBlock(character.GetValidLocation());
			if (blockData.RootBlockId > -1)
			{
				blockData = DomainManager.Map.GetBlockData(blockData.AreaId, blockData.RootBlockId);
			}
			blockName = DomainManager.Map.GetBlockFullName(blockData.GetLocation());
		}
		LegendaryBookCharacterRelatedData res = new LegendaryBookCharacterRelatedData
		{
			Id = charId,
			PhysiologicalAge = character.GetPhysiologicalAge(),
			Gender = character.GetGender(),
			FeatureId = -1,
			ConsummateLevel = character.GetConsummateLevel(),
			Charm = character.GetAttraction(),
			BehaviorType = character.GetBehaviorType(),
			HappinessType = character.GetHappinessType(),
			Favorability = DomainManager.Character.GetFavorability(charId, DomainManager.Taiwu.GetTaiwuCharId()),
			Alertness = DomainManager.Character.GetAlertnessValue(charId),
			FameType = character.GetFameType(),
			HealthType = DomainManager.Character.GetHealthType(charId),
			BookType = bookType,
			Location = location,
			AvatarRelatedData = DomainManager.Character.GetAvatarRelatedData(charId),
			NameRelatedData = DomainManager.Character.GetNameRelatedData(charId),
			OrganizationInfo = character.GetOrganizationInfo(),
			FullBlockName = blockName,
			CharacterTemplateId = character.GetTemplateId(),
			LocationNameRelatedData = DomainManager.Map.GetLocationNameRelatedData(character.GetLocation()),
			Followed = DomainManager.Taiwu.IsCharacterFollowedByTaiwu(charId),
			DefeatMarkCount = (sbyte)CombatDomain.GetDefeatMarksCountOutOfCombat(character),
			PreexistenceCharCount = (short)character.GetPreexistenceCharIds().Count,
			AttackMedal = character.GetFeatureMedalValue(0),
			DefenceMedal = character.GetFeatureMedalValue(1),
			WisdomMedal = character.GetFeatureMedalValue(2),
			MaxMainAttributes = character.GetMaxMainAttributes(),
			Penetrations = character.GetPenetrations(),
			PenetrationResists = character.GetPenetrationResists(),
			HitValues = character.GetHitValues(),
			AvoidValues = character.GetAvoidValues(),
			DisorderOfQi = character.GetDisorderOfQi(),
			LifeSkillQualifications = character.GetLifeSkillQualifications(),
			LifeSkillGrowthType = character.GetLifeSkillQualificationGrowthType(),
			CombatSkillQualifications = character.GetCombatSkillQualifications(),
			CombatSkillGrowthType = character.GetCombatSkillQualificationGrowthType(),
			CombatSkillAttainments = character.GetCombatSkillAttainments(),
			LifeSkillAttainments = character.GetLifeSkillAttainments(),
			Personalities = character.GetPersonalities(),
			Resources = character.GetResources(),
			CurrInventoryLoad = character.GetCurrInventoryLoad(),
			MaxInventoryLoad = character.GetMaxInventoryLoad(),
			KidnapCount = (sbyte)DomainManager.Character.GetKidnappedCharacterCount(charId),
			ActualAge = character.GetActualAge(),
			ClothDisplayId = character.GetClothingDisplayId(),
			FaceVisible = (!character.GetAvatar().ShowVeil && !character.GetAvatar().ShowMask(character.GetClothingDisplayId())),
			CreatingType = character.GetCreatingType(),
			Command = DomainManager.Extra.GetCharTeammateCommandsSByteList(context, charId),
			AdvancedCommand = DomainManager.Extra.GetAdvancedCharTeammateCommandsSByteList(charId),
			IsSpecialGroupMember = DomainManager.Character.IsSpecialGroupMember(character),
			IsCompanion = DomainManager.Taiwu.IsInGroup(charId),
			IsInteractedWithTaiwu = DomainManager.Character.IsInteractedWithTaiwu(charId),
			BookOwnerState = character.GetLegendaryBookOwnerState(),
			Health = character.GetHealth(),
			MaxLeftHealth = character.GetLeftMaxHealth()
		};
		short minFeatureId = Config.CombatSkillType.Instance[(sbyte)0].LegendaryBookConsumedFeature;
		short maxFeatureId = Config.CombatSkillType.Instance[(sbyte)13].LegendaryBookConsumedFeature;
		foreach (short featureId in character.GetFeatureIds())
		{
			if (featureId >= minFeatureId && featureId <= maxFeatureId)
			{
				res.FeatureId = featureId;
			}
		}
		return res;
	}

	[DomainMethod]
	public LegendaryBookIncrementData GetLegendaryBookIncrementData(DataContext context)
	{
		LegendaryBookIncrementData res = new LegendaryBookIncrementData();
		res.PreviousOwner = new List<int>();
		for (sbyte i = 0; i < 14; i++)
		{
			res.PreviousOwner.Add(DomainManager.LegendaryBook.GetPrevLegendaryBookOwnerCopyId(i));
			Location location = _bookAdventureLocations.GetOrDefault(i, Location.Invalid);
			if (location.IsValid())
			{
				bool anyBreak = false;
				foreach (IAdventureRuntime runtime in DomainManager.Adventure.QueryAnyInLocation(location))
				{
					if (!Enumerable.Contains(AiHelper.LegendaryBookRelatedConstants.LegendaryBookAdventures, runtime.CoreId))
					{
						continue;
					}
					if (runtime.StatusType == EAdventureStatusType.Ready)
					{
						MapBlockData blockData = DomainManager.Map.GetBlock(location);
						FullBlockName fullName = DomainManager.Map.GetBlockFullName(blockData.GetLocation());
						if (blockData.RootBlockId > -1)
						{
							blockData = DomainManager.Map.GetBlockData(blockData.AreaId, blockData.RootBlockId);
						}
						res.BookLocationMap.Add(i, location);
						res.BookDurationMap.Add(i, runtime.RemainMonths);
						res.BlockDataMap.TryAdd(i, blockData);
						res.BlockNameDataMap.TryAdd(i, fullName);
					}
					else
					{
						int remainMonths = runtime.GetParameter("ConchShipPresetKey_AutoStopHideDate").Current - DomainManager.World.GetCurrDate();
						res.BookDurationMap.Add(i, remainMonths);
					}
					anyBreak = true;
					break;
				}
				if (anyBreak)
				{
					continue;
				}
			}
			int ownerId = GetOwner(i);
			LegendaryBookCharacterRelatedData data = GetLegendaryBookCharacterRelatedData(context, ownerId, i);
			if (data != null)
			{
				location = DomainManager.Character.GetElement_Objects(ownerId).GetLocation();
				if (location.IsValid())
				{
					MapBlockData blockData2 = DomainManager.Map.GetBlock(location);
					FullBlockName fullName2 = DomainManager.Map.GetBlockFullName(blockData2.GetLocation());
					if (blockData2.RootBlockId > -1)
					{
						blockData2 = DomainManager.Map.GetBlockData(blockData2.AreaId, blockData2.RootBlockId);
					}
					res.BlockDataMap.TryAdd(i, blockData2);
					res.BlockNameDataMap.TryAdd(i, fullName2);
				}
				res.OwnerMap.Add(i, ownerId);
				res.CharacterMap.TryAdd(ownerId, data);
			}
			foreach (int contestId in GetContestForLegendaryBookCharacterSet(i).GetCollection())
			{
				data = GetLegendaryBookCharacterRelatedData(context, contestId, i);
				if (data != null)
				{
					res.ContestList.Add(contestId);
					res.CharacterMap.TryAdd(contestId, data);
				}
			}
		}
		foreach (LegendaryBookCharacterRelatedData data2 in res.CharacterMap.Values)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(data2.Id);
			foreach (short featureId in character.GetFeatureIds())
			{
				switch (featureId)
				{
				case 214:
					res.ShockedList.Add(data2.Id);
					break;
				case 215:
					res.InsaneList.Add(data2.Id);
					break;
				}
			}
		}
		foreach (int consumedId in _legendaryBookConsumedCharIds.GetCollection())
		{
			LegendaryBookCharacterRelatedData data3 = GetLegendaryBookCharacterRelatedData(context, consumedId, -1);
			if (data3 != null)
			{
				res.ConsumedList.Add(consumedId);
				res.CharacterMap.TryAdd(consumedId, data3);
			}
		}
		foreach (LegendaryBookCharacterRelatedData data4 in res.CharacterMap.Values)
		{
			if (data4.FeatureId == 214)
			{
				continue;
			}
			List<short> featureIds = DomainManager.Character.GetElement_Objects(data4.Id).GetFeatureIds();
			for (sbyte i2 = 0; i2 < 14; i2++)
			{
				CombatSkillTypeItem config = Config.CombatSkillType.Instance[i2];
				if (featureIds.Contains(config.LegendaryBookFeature))
				{
					data4.FeatureId = config.LegendaryBookFeature;
					break;
				}
				if (featureIds.Contains(config.LegendaryBookConsumedFeature))
				{
					data4.FeatureId = config.LegendaryBookConsumedFeature;
					break;
				}
			}
		}
		return res;
	}

	[DomainMethod]
	public List<IntPair> GmCmd_GetAllLegendaryBookStates()
	{
		List<IntPair> res = new List<IntPair>();
		for (sbyte i = 0; i < 14; i++)
		{
			res.Add(new IntPair(_bookOwners[i], -1));
		}
		return res;
	}

	[DomainMethod]
	public void GmCmd_AddRandomLegendaryBookContestChar(DataContext context)
	{
		List<IntPair> res = new List<IntPair>();
		List<GameData.Domains.Character.Character> chars = new List<GameData.Domains.Character.Character>();
		DomainManager.Character.FindIntelligentCharacters((GameData.Domains.Character.Character _) => true, chars);
		for (sbyte bookType = 0; bookType < 14; bookType++)
		{
			int randIndex = context.Random.Next(0, chars.Count);
			GameData.Domains.Character.Character target = chars[randIndex];
			int currentOwner = GetOwner(bookType);
			DomainManager.LegendaryBook.AddContestForLegendaryBookCharacter(context, target.GetId(), bookType);
		}
	}

	[DomainMethod]
	public int GetAllLegendaryBooksOwningState()
	{
		int res = 0;
		for (sbyte bookType = 0; bookType < 14; bookType++)
		{
			if (GetOwner(bookType) >= 0 || _prevLegendaryBookOwnerCopies.TryGetValue(bookType, out var _) || DomainManager.Extra.IsBookOwnedByTaiwu(bookType) || IsLegendaryBookOwned(bookType))
			{
				res |= 1 << (int)bookType;
			}
		}
		return res;
	}

	[DomainMethod]
	public void GmCmd_GiveAllTaiwuLegendaryBookToRandomNpc(DataContext context)
	{
		List<GameData.Domains.Character.Character> chars = new List<GameData.Domains.Character.Character>();
		DomainManager.Character.FindIntelligentCharacters((GameData.Domains.Character.Character _) => true, chars);
		for (sbyte bookType = 0; bookType < 14; bookType++)
		{
			int randIndex = context.Random.Next(0, chars.Count);
			GameData.Domains.Character.Character target = chars[randIndex];
			int currentOwner = GetOwner(bookType);
			if (currentOwner > 0)
			{
				DomainManager.Character.TransferInventoryItem(context, DomainManager.Character.GetElement_Objects(currentOwner), target, GetLegendaryBookItem(bookType), 1);
			}
		}
	}

	public bool IsCharacterLegendaryBookOwnerOrContest(int charId)
	{
		if (_charBookTypes.ContainsKey(charId))
		{
			return true;
		}
		for (sbyte i = 0; i < 14; i++)
		{
			if (GetContestForLegendaryBookCharacterSet(i).Contains(charId))
			{
				return true;
			}
		}
		return false;
	}

	private void InitializeCharBookTypes()
	{
		_charBookTypes = new Dictionary<int, List<sbyte>>();
		for (sbyte bookType = 0; bookType < 14; bookType++)
		{
			int charId = _bookOwners[bookType];
			if (charId >= 0)
			{
				RegisterCharBookType(charId, bookType);
			}
		}
	}

	private void RegisterCharBookType(int charId, sbyte bookType)
	{
		if (!_charBookTypes.TryGetValue(charId, out var bookTypes))
		{
			bookTypes = new List<sbyte>();
			_charBookTypes.Add(charId, bookTypes);
		}
		bookTypes.Add(bookType);
	}

	private void UnregisterCharBookType(int charId, sbyte bookType)
	{
		if (_charBookTypes.TryGetValue(charId, out var bookTypes))
		{
			bookTypes.Remove(bookType);
			if (bookTypes.Count <= 0)
			{
				_charBookTypes.Remove(charId);
			}
		}
	}

	private void InitializeLegendaryBookItems()
	{
		for (sbyte combatSkillType = 0; combatSkillType < 14; combatSkillType++)
		{
			_legendaryBookItems[combatSkillType] = ItemKey.Invalid;
		}
	}

	public ItemKey GetLegendaryBookItem(sbyte combatSkillType)
	{
		return _legendaryBookItems[combatSkillType];
	}

	internal void RegisterLegendaryBookItem(ItemKey itemKey)
	{
		Tester.Assert(ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == 1202, $"Target item {itemKey} is not a valid legendary book.");
		int combatSkillType = itemKey.TemplateId - 240;
		Tester.Assert(!_legendaryBookItems[combatSkillType].IsValid(), $"Legendary book {itemKey} of the same type already exist {_legendaryBookItems[combatSkillType]}");
		_legendaryBookItems[combatSkillType] = itemKey;
	}

	internal void UnregisterLegendaryBookItem(ItemKey itemKey)
	{
		Tester.Assert(ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == 1202, $"Target item {itemKey} is not a valid legendary book.");
		int combatSkillType = itemKey.TemplateId - 240;
		_legendaryBookItems[combatSkillType] = ItemKey.Invalid;
	}

	public bool IsAnyLegendaryBookOwned()
	{
		return _charBookTypes.Count > 0;
	}

	[DomainMethod]
	public LegendaryBookPresetDisplayData GetLegendaryBookPresetDisplayData()
	{
		CheckAndFillPresetSlotData();
		return new LegendaryBookPresetDisplayData
		{
			CurrentUnlockedAmount = GetCurrentUnlockedPresetAmount(),
			CurrentUsingPresetIndex = GetCurrentUsingPresetIndex(),
			MaxPresetAmount = _maximumPresetCount
		};
	}

	[DomainMethod]
	public void AddLegendaryBookSkillEmptyPreset(DataContext context)
	{
		if (_currentUnlockedPresetAmount < _maximumPresetCount)
		{
			SetCurrentUnlockedPresetAmount((sbyte)(_currentUnlockedPresetAmount + 1), context);
		}
	}

	[DomainMethod]
	public void DuplicateLegendaryBookSkillPreset(DataContext context, sbyte presetIndex)
	{
		if (_currentUnlockedPresetAmount >= _maximumPresetCount)
		{
			return;
		}
		SetCurrentUnlockedPresetAmount((sbyte)(_currentUnlockedPresetAmount + 1), context);
		int startIndex = presetIndex * DomainManager.Extra.MaxLegendaryBookSkillSlotCount;
		int newIndex = _currentUnlockedPresetAmount - 1;
		int startIndexNew = newIndex * DomainManager.Extra.MaxLegendaryBookSkillSlotCount;
		foreach (KeyValuePair<sbyte, GameData.Utilities.ShortList> item in _legendaryBookSkillPresetSlot)
		{
			sbyte skillType = item.Key;
			for (int addition = 0; addition < DomainManager.Extra.MaxLegendaryBookSkillSlotCount; addition++)
			{
				item.Value.Items[startIndexNew + addition] = item.Value.Items[startIndex + addition];
			}
			SetElement_LegendaryBookSkillPresetSlot(skillType, item.Value, context);
		}
		foreach (KeyValuePair<sbyte, LegendaryBookWeaponPreset> item2 in _legendaryBookWeaponPresetSlot)
		{
			item2.Value.WeaponPresets[newIndex] = item2.Value.WeaponPresets[presetIndex];
		}
	}

	[DomainMethod]
	public void SaveLegendaryBookSkillPresetSlotCurrent(DataContext context, sbyte skillType, int index, short skillTemplateId)
	{
		DomainManager.Extra.SetLegendaryBookSkillSlot(context, skillType, index, skillTemplateId);
		int targetIndex = _currentUsingPresetIndex * DomainManager.Extra.MaxLegendaryBookSkillSlotCount + index;
		_legendaryBookSkillPresetSlot[skillType].Items[targetIndex] = skillTemplateId;
	}

	[DomainMethod]
	public void SaveLegendaryBookWeaponPresetSlotCurrent(DataContext context, sbyte skillType, ItemKey weaponKey)
	{
		DomainManager.Extra.SetLegendaryBookWeaponSlot(context, skillType, weaponKey);
		_legendaryBookWeaponPresetSlot[skillType].WeaponPresets[_currentUsingPresetIndex] = weaponKey;
	}

	public void SetLegendaryBookWeaponSlotPreset(DataContext context, ItemKey newKey, ItemKey oldKey)
	{
		foreach (KeyValuePair<sbyte, LegendaryBookWeaponPreset> item in _legendaryBookWeaponPresetSlot)
		{
			for (int i = 0; i < item.Value.WeaponPresets.Length; i++)
			{
				if (item.Value.WeaponPresets[i] == oldKey)
				{
					item.Value.WeaponPresets[i] = newKey;
				}
			}
		}
	}

	[DomainMethod]
	public void RemoveLegendaryBookSkillPreset(DataContext context, sbyte presetIndex)
	{
		if (_currentUnlockedPresetAmount <= 1)
		{
			return;
		}
		int startIndex = presetIndex * DomainManager.Extra.MaxLegendaryBookSkillSlotCount;
		int endIndex = startIndex + DomainManager.Extra.MaxLegendaryBookSkillSlotCount;
		bool isCurrentUsing = _currentUsingPresetIndex == presetIndex;
		foreach (KeyValuePair<sbyte, GameData.Utilities.ShortList> item in _legendaryBookSkillPresetSlot)
		{
			for (int i = startIndex; i < item.Value.Items.Count - DomainManager.Extra.MaxLegendaryBookSkillSlotCount; i++)
			{
				item.Value.Items[i] = item.Value.Items[i + DomainManager.Extra.MaxLegendaryBookSkillSlotCount];
			}
			SetElement_LegendaryBookSkillPresetSlot(item.Key, item.Value, context);
		}
		foreach (KeyValuePair<sbyte, LegendaryBookWeaponPreset> item2 in _legendaryBookWeaponPresetSlot)
		{
			for (int j = presetIndex; j < item2.Value.WeaponPresets.Length - 1; j++)
			{
				item2.Value.WeaponPresets[j] = item2.Value.WeaponPresets[j + 1];
			}
			SetElement_LegendaryBookWeaponPresetSlot(item2.Key, item2.Value, context);
		}
		if (isCurrentUsing)
		{
			if (presetIndex == _currentUnlockedPresetAmount - 1)
			{
				presetIndex--;
			}
			SetLegendaryBookSkillPreset(context, presetIndex, forceSet: true);
		}
		_currentUnlockedPresetAmount--;
	}

	[DomainMethod]
	public void ResetLegendaryBookSkillPreset(DataContext context, int presetIndex)
	{
		if (presetIndex < 0 || presetIndex >= _currentUnlockedPresetAmount)
		{
			return;
		}
		int startIndex = presetIndex * DomainManager.Extra.MaxLegendaryBookSkillSlotCount;
		int endIndex = startIndex + DomainManager.Extra.MaxLegendaryBookSkillSlotCount;
		bool isCurrentUsing = _currentUsingPresetIndex == presetIndex;
		foreach (KeyValuePair<sbyte, GameData.Utilities.ShortList> item in _legendaryBookSkillPresetSlot)
		{
			sbyte skillType = item.Key;
			GameData.Utilities.ShortList newSlotData = GameData.Utilities.ShortList.Create();
			for (int i = startIndex; i < endIndex; i++)
			{
				newSlotData.Items.Add(-1);
				item.Value.Items[startIndex] = -1;
			}
			SetElement_LegendaryBookSkillPresetSlot(skillType, item.Value, context);
			if (isCurrentUsing)
			{
				DomainManager.Extra.SetLegendaryBookSkillSlots(context, skillType, newSlotData);
			}
		}
		foreach (KeyValuePair<sbyte, LegendaryBookWeaponPreset> item2 in _legendaryBookWeaponPresetSlot)
		{
			item2.Value.WeaponPresets[presetIndex] = ItemKey.Invalid;
			SetElement_LegendaryBookWeaponPresetSlot(item2.Key, item2.Value, context);
			if (isCurrentUsing)
			{
				DomainManager.Extra.SetLegendaryBookWeaponSlot(context, item2.Key, item2.Value.WeaponPresets[presetIndex]);
			}
		}
	}

	[DomainMethod]
	public void SetLegendaryBookSkillPreset(DataContext context, sbyte presetIndex, bool forceSet = false)
	{
		if (presetIndex < 0 || presetIndex > _maximumPresetCount || (_currentUsingPresetIndex == presetIndex && !forceSet))
		{
			return;
		}
		SetCurrentUsingPresetIndex(presetIndex, context);
		CheckAndFillPresetSlotData();
		int startIndex = presetIndex * DomainManager.Extra.MaxLegendaryBookSkillSlotCount;
		int endIndex = startIndex + DomainManager.Extra.MaxLegendaryBookSkillSlotCount;
		foreach (KeyValuePair<sbyte, GameData.Utilities.ShortList> item2 in _legendaryBookSkillPresetSlot)
		{
			sbyte skillType = item2.Key;
			GameData.Utilities.ShortList newSlotData = GameData.Utilities.ShortList.Create();
			for (int i = startIndex; i < endIndex; i++)
			{
				newSlotData.Items.Add(_legendaryBookSkillPresetSlot[skillType].Items[i]);
			}
			DomainManager.Extra.SetLegendaryBookSkillSlots(context, skillType, newSlotData);
		}
		foreach (KeyValuePair<sbyte, LegendaryBookWeaponPreset> item in _legendaryBookWeaponPresetSlot)
		{
			DomainManager.Extra.SetLegendaryBookWeaponSlot(context, item.Key, item.Value.WeaponPresets[presetIndex]);
		}
	}

	public void CheckAndFillPresetSlotData()
	{
		if (_currentUnlockedPresetAmount == 0)
		{
			_currentUnlockedPresetAmount = 3;
			_currentUsingPresetIndex = 0;
		}
		int presetSlotAmount = DomainManager.Extra.MaxLegendaryBookSkillSlotCount * _maximumPresetCount;
		bool flag = false;
		for (sbyte i = 0; i < Config.CombatSkillType.Instance.Count; i++)
		{
			flag = false;
			if (!_legendaryBookSkillPresetSlot.ContainsKey(i))
			{
				_legendaryBookSkillPresetSlot[i] = GameData.Utilities.ShortList.Create();
				flag = true;
			}
			for (int amount = _legendaryBookSkillPresetSlot[i].Items.Count; amount < presetSlotAmount; amount++)
			{
				_legendaryBookSkillPresetSlot[i].Items.Add(-1);
				flag = true;
			}
			if (!_legendaryBookWeaponPresetSlot.ContainsKey(i))
			{
				_legendaryBookWeaponPresetSlot[i] = new LegendaryBookWeaponPreset();
				flag = true;
			}
		}
	}

	[DomainMethod]
	public void ResetLegendaryBookBonus(DataContext context, sbyte skillType, bool isYin)
	{
		SByteList bonusCount = (isYin ? DomainManager.Extra.GetLegendaryBookBonusCountYin() : DomainManager.Extra.GetLegendaryBookBonusCountYang());
		if (bonusCount.Items == null)
		{
			bonusCount.Items = new List<sbyte>();
			for (sbyte i = 0; i < 14; i++)
			{
				bonusCount.Items.Add(0);
			}
		}
		bonusCount.Items[skillType] = 0;
		DomainManager.Extra.SetLegendaryBookBonusCount(isYin, bonusCount, context);
		DomainManager.Extra.ClearLegendaryBookSkillSlot(context, skillType);
		for (int j = 0; j < _legendaryBookSkillPresetSlot[skillType].Items.Count; j++)
		{
			_legendaryBookSkillPresetSlot[skillType].Items[j] = -1;
		}
		SetElement_LegendaryBookSkillPresetSlot(skillType, _legendaryBookSkillPresetSlot[skillType], context);
		DomainManager.Extra.SetLegendaryBookSkillSlots(context, skillType, default(GameData.Utilities.ShortList));
		DomainManager.Extra.ClearLegendaryBookWeaponSlot(context, skillType);
		for (int k = 0; k < _legendaryBookWeaponPresetSlot[skillType].WeaponPresets.Length; k++)
		{
			_legendaryBookWeaponPresetSlot[skillType].WeaponPresets[k] = ItemKey.Invalid;
		}
		SetElement_LegendaryBookWeaponPresetSlot(skillType, _legendaryBookWeaponPresetSlot[skillType], context);
		DomainManager.Extra.SetLegendaryBookWeaponSlot(context, skillType, ItemKey.Invalid);
	}

	private void InitializeBookPresetData()
	{
		_currentUnlockedPresetAmount = _initialPresetCount;
	}

	public LegendaryBookDomain()
		: base(13)
	{
		_bookOwners = new int[14];
		_legendaryBookOwnerData = new LegendaryBookOwnerData();
		_legendaryBookShockedMonths = new Dictionary<int, int>(0);
		_prevLegendaryBookOwnerCopies = new Dictionary<sbyte, IntPair>(0);
		_legendaryBookConsumedCharIds = default(CharacterSet);
		_contestForLegendaryBookChars = new Dictionary<sbyte, CharacterSet>(0);
		_legendaryBookHiddenCharIds = default(CharacterSet);
		_firstLegendaryBookDelay = 0;
		_previousLegendaryBookOwners = new Dictionary<sbyte, CharacterSet>(0);
		_legendaryBookSkillPresetSlot = new Dictionary<sbyte, GameData.Utilities.ShortList>(0);
		_currentUnlockedPresetAmount = 0;
		_currentUsingPresetIndex = 0;
		_legendaryBookWeaponPresetSlot = new Dictionary<sbyte, LegendaryBookWeaponPreset>(0);
		OnInitializedDomainData();
	}

	public int GetElement_BookOwners(int index)
	{
		return _bookOwners[index];
	}

	public void SetElement_BookOwners(int index, int value, DataContext context)
	{
		_bookOwners[index] = value;
		SetModifiedAndInvalidateInfluencedCache(index, _dataStatesBookOwners, CacheInfluencesBookOwners, context);
	}

	public LegendaryBookOwnerData GetLegendaryBookOwnerData()
	{
		return _legendaryBookOwnerData;
	}

	public void SetLegendaryBookOwnerData(LegendaryBookOwnerData value, DataContext context)
	{
		_legendaryBookOwnerData = value;
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	public int GetElement_LegendaryBookShockedMonths(int elementId)
	{
		return _legendaryBookShockedMonths[elementId];
	}

	public bool TryGetElement_LegendaryBookShockedMonths(int elementId, out int value)
	{
		return _legendaryBookShockedMonths.TryGetValue(elementId, out value);
	}

	private void AddElement_LegendaryBookShockedMonths(int elementId, int value, DataContext context)
	{
		_legendaryBookShockedMonths.Add(elementId, value);
		_modificationsLegendaryBookShockedMonths.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	private void SetElement_LegendaryBookShockedMonths(int elementId, int value, DataContext context)
	{
		_legendaryBookShockedMonths[elementId] = value;
		_modificationsLegendaryBookShockedMonths.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_LegendaryBookShockedMonths(int elementId, DataContext context)
	{
		_legendaryBookShockedMonths.Remove(elementId);
		_modificationsLegendaryBookShockedMonths.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	private void ClearLegendaryBookShockedMonths(DataContext context)
	{
		_legendaryBookShockedMonths.Clear();
		_modificationsLegendaryBookShockedMonths.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	public IntPair GetElement_PrevLegendaryBookOwnerCopies(sbyte elementId)
	{
		return _prevLegendaryBookOwnerCopies[elementId];
	}

	public bool TryGetElement_PrevLegendaryBookOwnerCopies(sbyte elementId, out IntPair value)
	{
		return _prevLegendaryBookOwnerCopies.TryGetValue(elementId, out value);
	}

	private void AddElement_PrevLegendaryBookOwnerCopies(sbyte elementId, IntPair value, DataContext context)
	{
		_prevLegendaryBookOwnerCopies.Add(elementId, value);
		_modificationsPrevLegendaryBookOwnerCopies.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void SetElement_PrevLegendaryBookOwnerCopies(sbyte elementId, IntPair value, DataContext context)
	{
		_prevLegendaryBookOwnerCopies[elementId] = value;
		_modificationsPrevLegendaryBookOwnerCopies.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_PrevLegendaryBookOwnerCopies(sbyte elementId, DataContext context)
	{
		_prevLegendaryBookOwnerCopies.Remove(elementId);
		_modificationsPrevLegendaryBookOwnerCopies.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void ClearPrevLegendaryBookOwnerCopies(DataContext context)
	{
		_prevLegendaryBookOwnerCopies.Clear();
		_modificationsPrevLegendaryBookOwnerCopies.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private CharacterSet GetLegendaryBookConsumedCharIds()
	{
		return _legendaryBookConsumedCharIds;
	}

	private void SetLegendaryBookConsumedCharIds(CharacterSet value, DataContext context)
	{
		_legendaryBookConsumedCharIds = value;
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	private CharacterSet GetElement_ContestForLegendaryBookChars(sbyte elementId)
	{
		return _contestForLegendaryBookChars[elementId];
	}

	private bool TryGetElement_ContestForLegendaryBookChars(sbyte elementId, out CharacterSet value)
	{
		return _contestForLegendaryBookChars.TryGetValue(elementId, out value);
	}

	private void AddElement_ContestForLegendaryBookChars(sbyte elementId, CharacterSet value, DataContext context)
	{
		_contestForLegendaryBookChars.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void SetElement_ContestForLegendaryBookChars(sbyte elementId, CharacterSet value, DataContext context)
	{
		_contestForLegendaryBookChars[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_ContestForLegendaryBookChars(sbyte elementId, DataContext context)
	{
		_contestForLegendaryBookChars.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void ClearContestForLegendaryBookChars(DataContext context)
	{
		_contestForLegendaryBookChars.Clear();
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private CharacterSet GetLegendaryBookHiddenCharIds()
	{
		return _legendaryBookHiddenCharIds;
	}

	private void SetLegendaryBookHiddenCharIds(CharacterSet value, DataContext context)
	{
		_legendaryBookHiddenCharIds = value;
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	public sbyte GetFirstLegendaryBookDelay()
	{
		return _firstLegendaryBookDelay;
	}

	public void SetFirstLegendaryBookDelay(sbyte value, DataContext context)
	{
		_firstLegendaryBookDelay = value;
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private CharacterSet GetElement_PreviousLegendaryBookOwners(sbyte elementId)
	{
		return _previousLegendaryBookOwners[elementId];
	}

	private bool TryGetElement_PreviousLegendaryBookOwners(sbyte elementId, out CharacterSet value)
	{
		return _previousLegendaryBookOwners.TryGetValue(elementId, out value);
	}

	private void AddElement_PreviousLegendaryBookOwners(sbyte elementId, CharacterSet value, DataContext context)
	{
		_previousLegendaryBookOwners.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private void SetElement_PreviousLegendaryBookOwners(sbyte elementId, CharacterSet value, DataContext context)
	{
		_previousLegendaryBookOwners[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_PreviousLegendaryBookOwners(sbyte elementId, DataContext context)
	{
		_previousLegendaryBookOwners.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private void ClearPreviousLegendaryBookOwners(DataContext context)
	{
		_previousLegendaryBookOwners.Clear();
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	public GameData.Utilities.ShortList GetElement_LegendaryBookSkillPresetSlot(sbyte elementId)
	{
		return _legendaryBookSkillPresetSlot[elementId];
	}

	public bool TryGetElement_LegendaryBookSkillPresetSlot(sbyte elementId, out GameData.Utilities.ShortList value)
	{
		return _legendaryBookSkillPresetSlot.TryGetValue(elementId, out value);
	}

	private void AddElement_LegendaryBookSkillPresetSlot(sbyte elementId, GameData.Utilities.ShortList value, DataContext context)
	{
		_legendaryBookSkillPresetSlot.Add(elementId, value);
		_modificationsLegendaryBookSkillPresetSlot.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void SetElement_LegendaryBookSkillPresetSlot(sbyte elementId, GameData.Utilities.ShortList value, DataContext context)
	{
		_legendaryBookSkillPresetSlot[elementId] = value;
		_modificationsLegendaryBookSkillPresetSlot.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_LegendaryBookSkillPresetSlot(sbyte elementId, DataContext context)
	{
		_legendaryBookSkillPresetSlot.Remove(elementId);
		_modificationsLegendaryBookSkillPresetSlot.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private void ClearLegendaryBookSkillPresetSlot(DataContext context)
	{
		_legendaryBookSkillPresetSlot.Clear();
		_modificationsLegendaryBookSkillPresetSlot.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	public sbyte GetCurrentUnlockedPresetAmount()
	{
		return _currentUnlockedPresetAmount;
	}

	private void SetCurrentUnlockedPresetAmount(sbyte value, DataContext context)
	{
		_currentUnlockedPresetAmount = value;
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	public sbyte GetCurrentUsingPresetIndex()
	{
		return _currentUsingPresetIndex;
	}

	private void SetCurrentUsingPresetIndex(sbyte value, DataContext context)
	{
		_currentUsingPresetIndex = value;
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	private LegendaryBookWeaponPreset GetElement_LegendaryBookWeaponPresetSlot(sbyte elementId)
	{
		return _legendaryBookWeaponPresetSlot[elementId];
	}

	private bool TryGetElement_LegendaryBookWeaponPresetSlot(sbyte elementId, out LegendaryBookWeaponPreset value)
	{
		return _legendaryBookWeaponPresetSlot.TryGetValue(elementId, out value);
	}

	private void AddElement_LegendaryBookWeaponPresetSlot(sbyte elementId, LegendaryBookWeaponPreset value, DataContext context)
	{
		_legendaryBookWeaponPresetSlot.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	private void SetElement_LegendaryBookWeaponPresetSlot(sbyte elementId, LegendaryBookWeaponPreset value, DataContext context)
	{
		_legendaryBookWeaponPresetSlot[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_LegendaryBookWeaponPresetSlot(sbyte elementId, DataContext context)
	{
		_legendaryBookWeaponPresetSlot.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	private void ClearLegendaryBookWeaponPresetSlot(DataContext context)
	{
		_legendaryBookWeaponPresetSlot.Clear();
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
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
		archive.WriteElementListUnmanaged(_bookOwners);
		archive.WriteDomainDataMeta(2);
		archive.WriteSingleValueCollectionUnmanagedKeyValue(_legendaryBookShockedMonths);
		archive.WriteDomainDataMeta(3);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_prevLegendaryBookOwnerCopies);
		archive.WriteDomainDataMeta(4);
		archive.WriteSingleValueCustom(_legendaryBookConsumedCharIds);
		archive.WriteDomainDataMeta(5);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_contestForLegendaryBookChars);
		archive.WriteDomainDataMeta(6);
		archive.WriteSingleValueCustom(_legendaryBookHiddenCharIds);
		archive.WriteDomainDataMeta(7);
		archive.WriteSingleValueUnmanaged(_firstLegendaryBookDelay);
		archive.WriteDomainDataMeta(8);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_previousLegendaryBookOwners);
		archive.WriteDomainDataMeta(9);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_legendaryBookSkillPresetSlot);
		archive.WriteDomainDataMeta(10);
		archive.WriteSingleValueUnmanaged(_currentUnlockedPresetAmount);
		archive.WriteDomainDataMeta(11);
		archive.WriteSingleValueUnmanaged(_currentUsingPresetIndex);
		archive.WriteDomainDataMeta(12);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_legendaryBookWeaponPresetSlot);
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
				archive.ReadElementListUnmanaged(_bookOwners);
				break;
			case 2:
				archive.ReadSingleValueCollectionUnmanagedKeyValue(_legendaryBookShockedMonths);
				break;
			case 3:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_prevLegendaryBookOwnerCopies);
				break;
			case 4:
				archive.ReadSingleValueCustom(ref _legendaryBookConsumedCharIds);
				break;
			case 5:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_contestForLegendaryBookChars);
				break;
			case 6:
				archive.ReadSingleValueCustom(ref _legendaryBookHiddenCharIds);
				break;
			case 7:
				archive.ReadSingleValueUnmanaged(ref _firstLegendaryBookDelay);
				break;
			case 8:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_previousLegendaryBookOwners);
				break;
			case 9:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_legendaryBookSkillPresetSlot);
				break;
			case 10:
				archive.ReadSingleValueUnmanaged(ref _currentUnlockedPresetAmount);
				break;
			case 11:
				archive.ReadSingleValueUnmanaged(ref _currentUsingPresetIndex);
				break;
			case 12:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_legendaryBookWeaponPresetSlot);
				break;
			default:
				throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
			}
			RecordLoadedDomainData(domainDataMeta.DataId);
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(11);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(_dataStatesBookOwners, (int)subId0);
			}
			return GameData.Serializer.Serializer.Serialize(_bookOwners[(uint)subId0], dataPool);
		case 1:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
			}
			return GameData.Serializer.Serializer.Serialize(_legendaryBookOwnerData, dataPool);
		case 2:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
				_modificationsLegendaryBookShockedMonths.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_legendaryBookShockedMonths, dataPool);
		case 3:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
				_modificationsPrevLegendaryBookOwnerCopies.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_prevLegendaryBookOwnerCopies, dataPool);
		case 4:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 5:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 6:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 7:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
			}
			return GameData.Serializer.Serializer.Serialize(_firstLegendaryBookDelay, dataPool);
		case 8:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 9:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
				_modificationsLegendaryBookSkillPresetSlot.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_legendaryBookSkillPresetSlot, dataPool);
		case 10:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 10);
			}
			return GameData.Serializer.Serializer.Serialize(_currentUnlockedPresetAmount, dataPool);
		case 11:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
			}
			return GameData.Serializer.Serializer.Serialize(_currentUsingPresetIndex, dataPool);
		case 12:
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
		{
			int value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			_bookOwners[(uint)subId0] = value;
			SetElement_BookOwners((int)subId0, value, context);
			break;
		}
		case 1:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _legendaryBookOwnerData);
			SetLegendaryBookOwnerData(_legendaryBookOwnerData, context);
			break;
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
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _firstLegendaryBookDelay);
			SetFirstLegendaryBookDelay(_firstLegendaryBookDelay, context);
			break;
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
			if (operation.ArgsCount == 0)
			{
				List<IntPair> returnValue3 = GmCmd_GetAllLegendaryBookStates();
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 1:
			if (operation.ArgsCount == 0)
			{
				GmCmd_GiveAllTaiwuLegendaryBookToRandomNpc(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 2:
			if (operation.ArgsCount == 0)
			{
				LegendaryBookIncrementData returnValue4 = GetLegendaryBookIncrementData(context);
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 3:
			if (operation.ArgsCount == 0)
			{
				int returnValue = GetAllLegendaryBooksOwningState();
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 4:
			if (operation.ArgsCount == 0)
			{
				LegendaryBookPresetDisplayData returnValue2 = GetLegendaryBookPresetDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 5:
			if (operation.ArgsCount == 0)
			{
				AddLegendaryBookSkillEmptyPreset(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 6:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 1)
			{
				sbyte presetIndex2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref presetIndex2);
				DuplicateLegendaryBookSkillPreset(context, presetIndex2);
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
				sbyte presetIndex = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref presetIndex);
				RemoveLegendaryBookSkillPreset(context, presetIndex);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 8:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 1)
			{
				int presetIndex5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref presetIndex5);
				ResetLegendaryBookSkillPreset(context, presetIndex5);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 9:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				sbyte presetIndex4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref presetIndex4);
				SetLegendaryBookSkillPreset(context, presetIndex4);
				return -1;
			}
			case 2:
			{
				sbyte presetIndex3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref presetIndex3);
				bool forceSet = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref forceSet);
				SetLegendaryBookSkillPreset(context, presetIndex3, forceSet);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 10:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 3)
			{
				sbyte skillType3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillType3);
				int index = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index);
				short skillTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateId);
				SaveLegendaryBookSkillPresetSlotCurrent(context, skillType3, index, skillTemplateId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 11:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 2)
			{
				sbyte skillType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillType2);
				bool isYin = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isYin);
				ResetLegendaryBookBonus(context, skillType2, isYin);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 2)
			{
				sbyte skillType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillType);
				ItemKey weaponKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref weaponKey);
				SaveLegendaryBookWeaponPresetSlotCurrent(context, skillType, weaponKey);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 13:
			if (operation.ArgsCount == 0)
			{
				GmCmd_AddRandomLegendaryBookContestChar(context);
				return -1;
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
			break;
		case 1:
			break;
		case 2:
			_modificationsLegendaryBookShockedMonths.ChangeRecording(monitoring);
			break;
		case 3:
			_modificationsPrevLegendaryBookOwnerCopies.ChangeRecording(monitoring);
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			break;
		case 7:
			break;
		case 8:
			break;
		case 9:
			_modificationsLegendaryBookSkillPresetSlot.ChangeRecording(monitoring);
			break;
		case 10:
			break;
		case 11:
			break;
		case 12:
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
			if (!BaseGameDataDomain.IsModified(_dataStatesBookOwners, (int)subId0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(_dataStatesBookOwners, (int)subId0);
			return GameData.Serializer.Serializer.Serialize(_bookOwners[(uint)subId0], dataPool);
		case 1:
			if (!BaseGameDataDomain.IsModified(DataStates, 1))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 1);
			return GameData.Serializer.Serializer.Serialize(_legendaryBookOwnerData, dataPool);
		case 2:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 2))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 2);
			int offset = GameData.Serializer.Serializer.SerializeModifications(_legendaryBookShockedMonths, dataPool, _modificationsLegendaryBookShockedMonths);
			_modificationsLegendaryBookShockedMonths.Reset();
			return offset;
		}
		case 3:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 3))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 3);
			int offset3 = GameData.Serializer.Serializer.SerializeModifications(_prevLegendaryBookOwnerCopies, dataPool, _modificationsPrevLegendaryBookOwnerCopies);
			_modificationsPrevLegendaryBookOwnerCopies.Reset();
			return offset3;
		}
		case 4:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 5:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 6:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 7:
			if (!BaseGameDataDomain.IsModified(DataStates, 7))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 7);
			return GameData.Serializer.Serializer.Serialize(_firstLegendaryBookDelay, dataPool);
		case 8:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 9:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 9))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 9);
			int offset2 = GameData.Serializer.Serializer.SerializeModifications(_legendaryBookSkillPresetSlot, dataPool, _modificationsLegendaryBookSkillPresetSlot);
			_modificationsLegendaryBookSkillPresetSlot.Reset();
			return offset2;
		}
		case 10:
			if (!BaseGameDataDomain.IsModified(DataStates, 10))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 10);
			return GameData.Serializer.Serializer.Serialize(_currentUnlockedPresetAmount, dataPool);
		case 11:
			if (!BaseGameDataDomain.IsModified(DataStates, 11))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 11);
			return GameData.Serializer.Serializer.Serialize(_currentUsingPresetIndex, dataPool);
		case 12:
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
			if (BaseGameDataDomain.IsModified(_dataStatesBookOwners, (int)subId0))
			{
				BaseGameDataDomain.ResetModified(_dataStatesBookOwners, (int)subId0);
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
				_modificationsLegendaryBookShockedMonths.Reset();
			}
			break;
		case 3:
			if (BaseGameDataDomain.IsModified(DataStates, 3))
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
				_modificationsPrevLegendaryBookOwnerCopies.Reset();
			}
			break;
		case 4:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 5:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 6:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 7:
			if (BaseGameDataDomain.IsModified(DataStates, 7))
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
			}
			break;
		case 8:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 9:
			if (BaseGameDataDomain.IsModified(DataStates, 9))
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
				_modificationsLegendaryBookSkillPresetSlot.Reset();
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
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override bool IsModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		return dataId switch
		{
			0 => BaseGameDataDomain.IsModified(_dataStatesBookOwners, (int)subId0), 
			1 => BaseGameDataDomain.IsModified(DataStates, 1), 
			2 => BaseGameDataDomain.IsModified(DataStates, 2), 
			3 => BaseGameDataDomain.IsModified(DataStates, 3), 
			4 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			5 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			6 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			7 => BaseGameDataDomain.IsModified(DataStates, 7), 
			8 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			9 => BaseGameDataDomain.IsModified(DataStates, 9), 
			10 => BaseGameDataDomain.IsModified(DataStates, 10), 
			11 => BaseGameDataDomain.IsModified(DataStates, 11), 
			12 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
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
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
	}
}
