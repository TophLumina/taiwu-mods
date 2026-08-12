using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Config;
using Config.ConfigCells.Character;
using GameData.Achievement;
using GameData.ArchiveData;
using GameData.Common;
using GameData.Common.SingleValueCollection;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Adventure;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Creation;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.Filters;
using GameData.Domains.Character.Relation;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Global.Inscription;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization.Display;
using GameData.Domains.Organization.SettlementPrisonRecord;
using GameData.Domains.Organization.SettlementTreasuryRecord;
using GameData.Domains.Taiwu;
using GameData.Domains.Taiwu.ExchangeSystem;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.Taiwu.Profession.SkillsData;
using GameData.Domains.Taiwu.VillagerRole;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.World;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using NLog;
using Redzen.Random;

namespace GameData.Domains.Organization;

[GameDataDomain(3)]
public class OrganizationDomain : BaseGameDataDomain
{
	public enum ESettlementTreasuryOperationResult
	{
		None,
		[Obsolete("不会触发事件了，直接完成交换")]
		Exchange,
		Steal,
		Store
	}

	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<short, Sect> _sects;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<short, CivilianSettlement> _civilianSettlements;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private short _nextSettlementId;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, SectCharacter> _sectCharacters;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, CivilianSettlementCharacter> _civilianSettlementCharacters;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<int, CharacterSet> _factions;

	[DomainData(DomainDataType.SingleValue, true, false, false, false, ArrayElementsCount = 64)]
	private sbyte[] _largeSectFavorabilities;

	[DomainData(DomainDataType.SingleValue, false, true, true, true)]
	private List<MartialArtTournamentPreparationInfo> _martialArtTournamentPreparationInfoList;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private List<short> _previousMartialArtTournamentHosts;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private List<MaxApprovingRateTempBonus> _maxApprovingRateTemporaryBonus;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private List<short> _prevMartialArtTournamentWinners;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private Dictionary<short, SettlementTreasuryRecordCollection> _settlementTreasuryRecordCollections;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private Dictionary<short, SettlementPrisonRecordCollection> _settlementPrisonRecordCollections;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<short, SerializableList<SettlementMemberFeature>> _settlementMemberFeatures;

	private bool _pendingInscribedCharacterAchievement;

	private Dictionary<Location, Settlement> _locationSettlements;

	private Dictionary<short, Settlement> _settlements;

	private List<Settlement>[] _orgTemplateId2Settlements;

	private Dictionary<int, SettlementCharacter> _settlementCharacters;

	public const sbyte MerchantGrade = 4;

	public bool ParallelUpdateOrganizationMembers = true;

	private SettlementCreatingInfo _settlementCreatingInfo;

	private static Dictionary<sbyte, List<InscribedCharacter>> _orgInscribedCharIdMap;

	private static StringBuilder _stringBuilder;

	private static readonly sbyte[] CreateFactionChance = new sbyte[5] { 30, 10, 40, 20, 50 };

	private static readonly sbyte[] ExpandFactionChance = new sbyte[5] { 20, 40, 50, 10, 30 };

	private static readonly sbyte[] JoinFactionChance = new sbyte[5] { 30, 40, 50, 10, 20 };

	private static readonly sbyte[] JoinFactionFavorabilityBonus = new sbyte[5] { 0, 5, 10, 15, 0 };

	private static readonly sbyte[] JoinFactionFavorabilityReq = new sbyte[6] { 1, 1, 2, 1, 2, 3 };

	private static readonly sbyte[][] JoinFactionPriorities = new sbyte[5][]
	{
		new sbyte[6] { 2, 1, 4, 3, 0, 5 },
		new sbyte[6] { 0, 2, 1, 3, 4, 5 },
		new sbyte[6] { 1, 0, 4, 2, 3, 5 },
		new sbyte[6] { 4, 2, 0, 3, 1, 5 },
		new sbyte[6] { 0, 1, 4, 3, 2, 5 }
	};

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private short _currTournamentHost;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private int _lastTournamentFinishDate;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private int _tournamentPreparationEndDate;

	private bool _tmpSkipTournamentMonth;

	private static readonly sbyte[] WinnerLearnCombatSkillCounts = new sbyte[9] { 1, 1, 2, 3, 3, 4, 5, 5, 6 };

	private static readonly sbyte[] WinnerLearnLifeSkillCounts = new sbyte[9] { 1, 1, 1, 2, 2, 2, 3, 3, 3 };

	private const int InvalidDate = int.MinValue;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<short, SettlementPrison> _settlementPrisons;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<short, SerializableList<PunishmentSeverityCustomizeData>> _cityPunishmentSeverityCustomizeDict;

	private readonly Dictionary<int, List<sbyte>> _sectFugitives = new Dictionary<int, List<sbyte>>();

	private readonly Dictionary<int, sbyte> _sectPrisoners = new Dictionary<int, sbyte>();

	private readonly List<SettlementBounty> _calculatedBountiesCache = new List<SettlementBounty>();

	[Obsolete]
	private int _prisonGuardCharId = -1;

	private static sbyte[] _allSectOrgTemplateIds;

	private static sbyte[] _maleSectOrgTemplateIds;

	private static sbyte[] _femaleSectOrgTemplateIds;

	private SettlementTreasuryLayers _currentTreasuryLayer;

	private int _firstGuardCharId = -1;

	private List<ItemSourceChange> _itemSourceChanges;

	private ESettlementTreasuryOperationResult _operationResult;

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[19][];

	private static readonly DataInfluence[][] CacheInfluencesSects = new DataInfluence[22][];

	private readonly ObjectCollectionDataStates _dataStatesSects = new ObjectCollectionDataStates(22, 0);

	public readonly ObjectCollectionHelperData HelperDataSects;

	private static readonly DataInfluence[][] CacheInfluencesCivilianSettlements = new DataInfluence[17][];

	private readonly ObjectCollectionDataStates _dataStatesCivilianSettlements = new ObjectCollectionDataStates(17, 0);

	public readonly ObjectCollectionHelperData HelperDataCivilianSettlements;

	private static readonly DataInfluence[][] CacheInfluencesSectCharacters = new DataInfluence[6][];

	private readonly ObjectCollectionDataStates _dataStatesSectCharacters = new ObjectCollectionDataStates(6, 0);

	public readonly ObjectCollectionHelperData HelperDataSectCharacters;

	private static readonly DataInfluence[][] CacheInfluencesCivilianSettlementCharacters = new DataInfluence[6][];

	private readonly ObjectCollectionDataStates _dataStatesCivilianSettlementCharacters = new ObjectCollectionDataStates(6, 0);

	public readonly ObjectCollectionHelperData HelperDataCivilianSettlementCharacters;

	private SingleValueCollectionModificationCollection<int> _modificationsFactions = SingleValueCollectionModificationCollection<int>.Create();

	private SpinLock _spinLockMartialArtTournamentPreparationInfoList = new SpinLock(enableThreadOwnerTracking: false);

	private SingleValueCollectionModificationCollection<short> _modificationsSettlementTreasuryRecordCollections = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsSettlementPrisonRecordCollections = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsSettlementPrisons = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsCityPunishmentSeverityCustomizeDict = SingleValueCollectionModificationCollection<short>.Create();

	private Queue<uint> _pendingLoadingOperationIds;

	public bool PauseUpdateInfluencePower => DomainManager.Organization.GetCurrTournamentState() != EMartialArtTournamentState.WaitTrigger;

	private void OnInitializedDomainData()
	{
		InitializeSettlementTreasury();
	}

	private void InitializeOnInitializeGameDataModule()
	{
		InitializeSectOrgTemplateIds();
	}

	private void InitializeOnEnterNewWorld()
	{
		InitializeSettlementsCache();
		InitializeSettlementCharactersCache();
		_orgInscribedCharIdMap = new Dictionary<sbyte, List<InscribedCharacter>>();
		_currTournamentHost = -1;
		_lastTournamentFinishDate = int.MinValue;
		_tournamentPreparationEndDate = int.MinValue;
	}

	private void OnLoadedArchiveData()
	{
		InitializeSettlementsCache();
		InitializeSettlementCharactersCache();
		DataUid dataUid = new DataUid(0, 1, ulong.MaxValue);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(dataUid, "InitializeSortedMembersCache", InitializeSortedMembersCache);
	}

	public void TryFlushPendingAchievement(DataContext context)
	{
		if (_pendingInscribedCharacterAchievement)
		{
			_pendingInscribedCharacterAchievement = false;
			AchievementManager.RequestSetStat(context, 61, 1);
		}
	}

	public override void OnCurrWorldArchiveDataReady(DataContext context, bool isNewWorld)
	{
		InitializePrisonCache();
	}

	private BuildingBlockData GetAvailableBlockInSettlementBuildingArea(Location location)
	{
		BuildingAreaData buildingAreaData = DomainManager.Building.GetElement_BuildingAreas(location);
		int blockCount = buildingAreaData.Width * buildingAreaData.Width;
		(int, int) centerPos = (buildingAreaData.Width / 2, buildingAreaData.Width / 2);
		BuildingBlockData bestBlock = null;
		int bestBlockPriority = int.MinValue;
		int bestDistance = int.MaxValue;
		for (short index = 0; index < blockCount; index++)
		{
			BuildingBlockKey blockKey = new BuildingBlockKey(location.AreaId, location.BlockId, index);
			if (DomainManager.Building.TryGetElement_BuildingBlocks(blockKey, out var block) && block.RootBlockIndex < 0)
			{
				BuildingBlockItem configData = block.ConfigData;
				EBuildingBlockType type = configData.Type;
				if ((uint)(type - 3) > 1u)
				{
					(int, int) pos = buildingAreaData.GetBlockPos(index);
					EBuildingBlockType type2 = configData.Type;
					if (1 == 0)
					{
					}
					int num = type2 switch
					{
						EBuildingBlockType.SpecialResource => 0, 
						EBuildingBlockType.NormalResource => 1, 
						EBuildingBlockType.UselessResource => 2, 
						EBuildingBlockType.Empty => 3, 
						_ => int.MinValue, 
					};
					if (1 == 0)
					{
					}
					int priority = num;
					int distance = MathUtils.GetManhattanDistance(centerPos.Item1, centerPos.Item2, pos.Item1, pos.Item2);
					if (bestBlock == null || bestBlockPriority > priority || (bestBlockPriority == priority && distance < bestDistance))
					{
						bestBlock = block;
						bestBlockPriority = priority;
						bestDistance = distance;
					}
				}
			}
		}
		return bestBlock;
	}

	[SingleValueDependency(3, new ushort[] { 8, 16, 18 })]
	[ObjectCollectionDependency(3, 0, new ushort[] { 21 })]
	private unsafe void CalcMartialArtTournamentPreparationInfoList(List<MartialArtTournamentPreparationInfo> value)
	{
		value.Clear();
		if (GetCurrTournamentState() != EMartialArtTournamentState.Prepare)
		{
			return;
		}
		long* sortedByCombatPower = stackalloc long[_sects.Count];
		long* sortedByAuthority = stackalloc long[_sects.Count];
		long* sortedByResource = stackalloc long[_sects.Count];
		int indexThreshold = Math.Max(0, _previousMartialArtTournamentHosts.Count - 3);
		value.AddRange(from x in _sects.Values.AsParallel().Select(delegate(Sect sect)
			{
				short id = sect.GetId();
				int num = _previousMartialArtTournamentHosts.LastIndexOf(id);
				if (num >= indexThreshold)
				{
					return new MartialArtTournamentPreparationInfo
					{
						SettlementId = -1
					};
				}
				int[] martialArtTournamentPreparations = sect.GetMartialArtTournamentPreparations();
				int combatPowerPreparation = martialArtTournamentPreparations[0];
				int authorityPreparation = martialArtTournamentPreparations[1];
				int resourcePreparation = martialArtTournamentPreparations[2];
				return new MartialArtTournamentPreparationInfo
				{
					SettlementId = id,
					CombatPowerPreparation = combatPowerPreparation,
					AuthorityPreparation = authorityPreparation,
					ResourcePreparation = resourcePreparation,
					TotalScore = 0
				};
			})
			where x.SettlementId != -1
			select x);
		int count;
		for (count = 0; count < value.Count; count++)
		{
			MartialArtTournamentPreparationInfo info = value[count];
			sortedByCombatPower[count] = ((long)info.CombatPowerPreparation << 32) | info.SettlementId;
			sortedByAuthority[count] = ((long)info.AuthorityPreparation << 32) | info.SettlementId;
			sortedByResource[count] = ((long)info.ResourcePreparation << 32) | info.SettlementId;
		}
		CollectionUtils.Sort(sortedByCombatPower, count);
		CollectionUtils.Sort(sortedByAuthority, count);
		CollectionUtils.Sort(sortedByResource, count);
		stackalloc long[count].Fill(0L);
		for (int i = 0; i < count; i++)
		{
			int rankIndex = count - i - 1;
			short settlementId = (short)(sortedByCombatPower[rankIndex] & 0xFFFF);
			int score = GetScore(sortedByCombatPower, count, rankIndex);
			int index = value.FindIndex((MartialArtTournamentPreparationInfo martialArtTournamentPreparationInfo) => martialArtTournamentPreparationInfo.SettlementId == settlementId);
			MartialArtTournamentPreparationInfo info2 = value[index];
			info2.TotalScore += score;
			value[index] = info2;
			short settlementId2 = (short)(sortedByAuthority[rankIndex] & 0xFFFF);
			int score2 = GetScore(sortedByAuthority, count, rankIndex);
			int index2 = value.FindIndex((MartialArtTournamentPreparationInfo martialArtTournamentPreparationInfo) => martialArtTournamentPreparationInfo.SettlementId == settlementId2);
			MartialArtTournamentPreparationInfo info3 = value[index2];
			info3.TotalScore += score2;
			value[index2] = info3;
			short settlementId3 = (short)(sortedByResource[rankIndex] & 0xFFFF);
			int score3 = GetScore(sortedByResource, count, rankIndex);
			int index3 = value.FindIndex((MartialArtTournamentPreparationInfo martialArtTournamentPreparationInfo) => martialArtTournamentPreparationInfo.SettlementId == settlementId3);
			MartialArtTournamentPreparationInfo info4 = value[index3];
			info4.TotalScore += score3;
			value[index3] = info4;
		}
		value.Sort();
		unsafe static int GetScore(long* rank, int length, int num)
		{
			int actualRankIndex = num;
			long score4 = rank[num] >> 32;
			for (int j = num + 1; j < length; j++)
			{
				long currScore = rank[j] >> 32;
				if (currScore != score4)
				{
					break;
				}
				actualRankIndex = j;
			}
			return 15 - (length - actualRankIndex - 1);
		}
	}

	public void MakeNoneOrgCharactersBecomeBeggar(DataContext context)
	{
		List<GameData.Domains.Character.Character> noneOrgCharacters = new List<GameData.Domains.Character.Character>();
		MapCharacterFilter.ParallelFind((GameData.Domains.Character.Character character2) => character2.GetOrganizationInfo().OrgTemplateId == 0 && character2.IsInteractableAsIntelligentCharacter() && DomainManager.Organization.GetFugitiveBountySect(character2.GetId()) < 0 && DomainManager.Organization.GetPrisonerSect(character2.GetId()) < 0, noneOrgCharacters, 0, 135);
		foreach (GameData.Domains.Character.Character character in noneOrgCharacters)
		{
			JoinNearbyVillageTownAsBeggar(context, character, -1);
		}
	}

	public void UpdateApprovingRateEffectOnAdvanceMonth(DataContext context)
	{
		DomainManager.Organization.UpdateMaxApprovingRateTempBonus(context);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		int goodSectTotalApprovingRate = 0;
		int evilSectTotalApprovingRate = 0;
		int neutralTotalApprovingRate = 0;
		foreach (KeyValuePair<short, Sect> sect2 in _sects)
		{
			sect2.Deconstruct(out var key, out var value);
			short settlementId = key;
			Sect sect = value;
			short approvingRate = sect.CalcApprovingRate();
			if (approvingRate >= 200)
			{
				switch (Config.Organization.Instance[sect.GetOrgTemplateId()].Goodness)
				{
				case -1:
					evilSectTotalApprovingRate += approvingRate;
					break;
				case 0:
					neutralTotalApprovingRate += approvingRate;
					break;
				case 1:
					goodSectTotalApprovingRate += approvingRate;
					break;
				}
			}
		}
		if (evilSectTotalApprovingRate >= 100)
		{
			taiwuChar.RecordFameAction(context, 72, -1, (short)(evilSectTotalApprovingRate / 100));
		}
		if (goodSectTotalApprovingRate >= 100)
		{
			taiwuChar.RecordFameAction(context, 71, -1, (short)(goodSectTotalApprovingRate / 100));
		}
		if (neutralTotalApprovingRate >= 100)
		{
			taiwuChar.RecordFameAction(context, 73, -1, (short)(neutralTotalApprovingRate / 100));
			taiwuChar.RecordFameAction(context, 74, -1, (short)(neutralTotalApprovingRate / 100));
		}
		taiwuChar.ChangeResource(context, 7, CalcApprovingRateEffectAuthorityGain());
	}

	[DomainMethod]
	public int CalcApprovingRateEffectAuthorityGain()
	{
		int totalAuthorityGain = 0;
		foreach (KeyValuePair<short, Sect> sect2 in _sects)
		{
			sect2.Deconstruct(out var key, out var value);
			short settlementId = key;
			Sect sect = value;
			short approvingRate = sect.CalcApprovingRate();
			if (approvingRate >= 300)
			{
				totalAuthorityGain += approvingRate;
			}
		}
		return totalAuthorityGain / 10;
	}

	public short GetMaxApprovingRateTempBonus(short settlementId)
	{
		short val = 0;
		foreach (MaxApprovingRateTempBonus approvingRateBonus in _maxApprovingRateTemporaryBonus)
		{
			if (approvingRateBonus.SettlementId == settlementId)
			{
				val += approvingRateBonus.Bonus;
			}
		}
		return val;
	}

	public void UpdateMaxApprovingRateTempBonus(DataContext context)
	{
		int currDate = DomainManager.World.GetCurrDate();
		_maxApprovingRateTemporaryBonus.RemoveAll((MaxApprovingRateTempBonus bonus) => bonus.ExpireDate <= currDate);
		SetMaxApprovingRateTemporaryBonus(_maxApprovingRateTemporaryBonus, context);
	}

	public void AddMaxApprovingRateTempBonus(DataContext context, short settlementId, short bonus, int duration)
	{
		int currDate = DomainManager.World.GetCurrDate();
		_maxApprovingRateTemporaryBonus.Add(new MaxApprovingRateTempBonus(settlementId, bonus, currDate + duration));
		SetMaxApprovingRateTemporaryBonus(_maxApprovingRateTemporaryBonus, context);
	}

	public Settlement GetSettlement(short settlementId)
	{
		return _settlements[settlementId];
	}

	public Settlement GetSettlementOrDefault(short settlementId)
	{
		return _settlements.GetValueOrDefault(settlementId);
	}

	public bool ContainsStockadeInStory(IEnumerable<short> items, out short stockadeInStoryId)
	{
		stockadeInStoryId = -1;
		foreach (short item in items)
		{
			if (_settlements.TryGetValue(item, out var settlement) && settlement.GetLocation().AreaId == 138)
			{
				stockadeInStoryId = item;
				return true;
			}
		}
		return false;
	}

	public Settlement GetSettlementByOrgTemplateId(sbyte orgTemplateId)
	{
		List<Settlement> settlements = _orgTemplateId2Settlements[orgTemplateId];
		bool flag = settlements == null;
		bool flag2 = flag;
		if (!flag2)
		{
			int count = settlements.Count;
			bool flag3 = ((count > 1 || count == 0) ? true : false);
			flag2 = flag3;
		}
		if (flag2)
		{
			return null;
		}
		return settlements[0];
	}

	public Settlement GetSettlementByLocation(Location location)
	{
		if (_locationSettlements.TryGetValue(location, out var settlement))
		{
			return settlement;
		}
		return null;
	}

	public void GetAllSettlements(List<Settlement> settlements)
	{
		settlements.Clear();
		settlements.AddRange(_sects.Values);
		settlements.AddRange(_civilianSettlements.Values);
	}

	public void GetAllCivilianSettlements(List<Settlement> settlements)
	{
		settlements.Clear();
		settlements.AddRange(_civilianSettlements.Values);
	}

	public short GetSettlementIdByOrgTemplateId(sbyte orgTemplateId)
	{
		return GetSettlementByOrgTemplateId(orgTemplateId)?.GetId() ?? (-1);
	}

	public SettlementCharacter GetSettlementCharacter(int charId)
	{
		return _settlementCharacters[charId];
	}

	public bool TryGetSettlementCharacter(int charId, out SettlementCharacter settlementChar)
	{
		return _settlementCharacters.TryGetValue(charId, out settlementChar);
	}

	public bool IsInAnySect(int charId)
	{
		return _sectCharacters.ContainsKey(charId);
	}

	public bool IsInAnyCivilianSettlement(int charId)
	{
		return _civilianSettlementCharacters.ContainsKey(charId);
	}

	public void JoinSect(DataContext context, GameData.Domains.Character.Character character, OrganizationInfo destOrgInfo)
	{
		LeaveOrganization(context, character, charIsDead: false);
		JoinOrganization(context, character, destOrgInfo, charIsCreating: false);
		OrganizationInfo srcOrgInfo = character.GetOrganizationInfo();
		character.SetOrganizationInfo(destOrgInfo, context);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		int selfCharId = character.GetId();
		Location currLocation = character.GetLocation();
		sbyte gender = character.GetGender();
		lifeRecordCollection.AddJoinSectSucceed(selfCharId, currDate, currLocation, destOrgInfo.SettlementId, destOrgInfo.OrgTemplateId, destOrgInfo.Grade, orgPrincipal: true, gender);
		Events.RaiseCharacterOrganizationChanged(context, character, srcOrgInfo, destOrgInfo);
	}

	public void JoinOrganization(DataContext context, GameData.Domains.Character.Character character, OrganizationInfo destOrgInfo, bool charIsCreating)
	{
		if (destOrgInfo.SettlementId < 0)
		{
			return;
		}
		int charId = character.GetId();
		SettlementCharacter settlementCharacter;
		OrgMemberCollection members;
		if (IsSect(destOrgInfo.OrgTemplateId))
		{
			SectCharacter sectChar = new SectCharacter(charId, destOrgInfo.OrgTemplateId, destOrgInfo.SettlementId);
			AddElement_SectCharacters(charId, sectChar);
			settlementCharacter = sectChar;
			Sect sect = _sects[destOrgInfo.SettlementId];
			members = sect.GetMembers();
			CreateRelationWithAllSettlementMembers(context, character, members);
			members.Add(charId, destOrgInfo.Grade);
			sect.SetMembers(members, context);
			TryAddSectMemberFeature(context, character, destOrgInfo);
			if (destOrgInfo.Grade == 8 && destOrgInfo.Principal)
			{
				character.AddFeature(context, 696);
			}
			OrganizationMemberItem orgMemberConfig = GetOrgMemberConfig(destOrgInfo);
			short mentorSeniorityId = SetRandomSectMentor(context, charId, destOrgInfo, members, orgMemberConfig.TeacherGrade);
			if (TryBecomeSectMonk(context, character, sect, orgMemberConfig, mentorSeniorityId) && !charIsCreating)
			{
				SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
				int secretInfoOffset = secretInformationCollection.AddBecomeMonk(character.GetId(), character.GetLocation());
				DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			}
		}
		else
		{
			CivilianSettlementCharacter civilianSettlementChar = new CivilianSettlementCharacter(charId, destOrgInfo.OrgTemplateId, destOrgInfo.SettlementId);
			AddElement_CivilianSettlementCharacters(charId, civilianSettlementChar);
			settlementCharacter = civilianSettlementChar;
			CivilianSettlement civilianSettlement = _civilianSettlements[destOrgInfo.SettlementId];
			members = civilianSettlement.GetMembers();
			CreateRelationWithAllSettlementMembers(context, character, members);
			members.Add(charId, destOrgInfo.Grade);
			civilianSettlement.SetMembers(members, context);
			if (destOrgInfo.OrgTemplateId == 16)
			{
				Events.RaiseCharacterJoinTaiwuVillage(context, character, charIsCreating);
			}
		}
		_settlementCharacters.Add(charId, settlementCharacter);
		if (destOrgInfo.Principal)
		{
			CheckPrincipalMembersAmount(destOrgInfo.OrgTemplateId, destOrgInfo.Grade, members);
		}
		character.ChangeMerchantType(context, destOrgInfo);
	}

	public void LeaveOrganization(DataContext context, GameData.Domains.Character.Character character, bool charIsDead)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (orgInfo.SettlementId < 0)
		{
			return;
		}
		int charId = character.GetId();
		OrganizationItem orgConfig = Config.Organization.Instance[orgInfo.OrgTemplateId];
		if (IsSect(orgInfo.OrgTemplateId))
		{
			Sect sect = _sects[orgInfo.SettlementId];
			if (orgConfig.Hereditary && orgInfo.Principal && orgInfo.Grade > 0)
			{
				OrgMemberCollection lackingMembers = sect.GetLackingCoreMembers();
				lackingMembers.Add(charId, orgInfo.Grade);
				sect.SetLackingCoreMembers(lackingMembers, context);
			}
			OrgMemberCollection members = sect.GetMembers();
			members.Remove(charId, orgInfo.Grade);
			sect.SetMembers(members, context);
			RemoveElement_SectCharacters(charId);
			if (!charIsDead && orgInfo.Grade == 8 && orgInfo.Principal)
			{
				character.RemoveFeature(context, 696);
			}
			int factionId = character.GetFactionId();
			if (factionId == charId)
			{
				RemoveFaction(context, character, charIsDead);
			}
			else if (factionId >= 0)
			{
				LeaveFaction(context, character, charIsDead);
			}
			if (!charIsDead)
			{
				TrySecularize(context, character);
			}
			SettlementLayeredTreasuries treasuries = sect.Treasuries;
			if (treasuries.TryRemoveGuard(charId, out var _))
			{
				if (!charIsDead)
				{
					character.RemoveFeatureGroup(context, 691);
				}
				Logger.Info($"{character} is no longer guarding sect {sect.GetNameRelatedData().GetName()}");
				DomainManager.Extra.SetTreasuries(context, sect.GetId(), treasuries, needUpdateTotalValue: false);
			}
		}
		else
		{
			CivilianSettlement civilianSettlement = _civilianSettlements[orgInfo.SettlementId];
			if (orgConfig.Hereditary && orgInfo.Principal && orgInfo.Grade > 0)
			{
				OrgMemberCollection lackingMembers2 = civilianSettlement.GetLackingCoreMembers();
				lackingMembers2.Add(charId, orgInfo.Grade);
				civilianSettlement.SetLackingCoreMembers(lackingMembers2, context);
			}
			OrgMemberCollection members2 = civilianSettlement.GetMembers();
			members2.Remove(charId, orgInfo.Grade);
			civilianSettlement.SetMembers(members2, context);
			RemoveElement_CivilianSettlementCharacters(charId);
			if (orgInfo.OrgTemplateId == 16)
			{
				Events.RaiseCharacterLeaveTaiwuVillage(context, character, charIsDead);
			}
		}
		_settlementCharacters.Remove(charId);
		TryDowngradeDeputySpouses(context, charId, orgInfo);
	}

	public void ChangeOrganization(DataContext context, GameData.Domains.Character.Character character, OrganizationInfo destOrgInfo)
	{
		LeaveOrganization(context, character, charIsDead: false);
		JoinOrganization(context, character, destOrgInfo, charIsCreating: false);
		OrganizationInfo srcOrgInfo = character.GetOrganizationInfo();
		character.SetOrganizationInfo(destOrgInfo, context);
		if (srcOrgInfo.OrgTemplateId != 20 && destOrgInfo.OrgTemplateId != 20 && srcOrgInfo.OrgTemplateId != destOrgInfo.OrgTemplateId)
		{
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			int selfCharId = character.GetId();
			int currDate = DomainManager.World.GetCurrDate();
			sbyte gender = character.GetGender();
			if (srcOrgInfo.OrgTemplateId == 0)
			{
				lifeRecordCollection.AddJoinOrganization(selfCharId, currDate, destOrgInfo.SettlementId, destOrgInfo.OrgTemplateId, destOrgInfo.Grade, destOrgInfo.Principal, gender);
			}
			else if (destOrgInfo.OrgTemplateId == 0)
			{
				lifeRecordCollection.AddBreakAwayOrganization(selfCharId, currDate, srcOrgInfo.SettlementId);
			}
			else
			{
				lifeRecordCollection.AddChangeOrganization(selfCharId, currDate, srcOrgInfo.SettlementId, destOrgInfo.SettlementId, destOrgInfo.OrgTemplateId, destOrgInfo.Grade, destOrgInfo.Principal, gender);
			}
		}
		if (Config.Organization.Instance[destOrgInfo.OrgTemplateId].IsSect && srcOrgInfo.OrgTemplateId != destOrgInfo.OrgTemplateId)
		{
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddJoinOrganization(character.GetId(), DomainManager.Organization.GetSettlementByOrgTemplateId(destOrgInfo.OrgTemplateId).GetLocation());
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		if (destOrgInfo.OrgTemplateId == 16)
		{
			DomainManager.Taiwu.AddLegacyPoint(context, 31);
		}
		Events.RaiseCharacterOrganizationChanged(context, character, srcOrgInfo, destOrgInfo);
	}

	public void ChangeGrade(DataContext context, GameData.Domains.Character.Character character, sbyte destGrade, bool destPrincipal)
	{
		ChangeGrade(context, character, destGrade, destPrincipal, autoCommitLifeRecord: true);
	}

	public void ChangeGrade(DataContext context, GameData.Domains.Character.Character character, sbyte destGrade, bool destPrincipal, bool autoCommitLifeRecord)
	{
		int charId = character.GetId();
		OrganizationInfo oriOrgInfo = character.GetOrganizationInfo();
		OrganizationInfo destOrgInfo = new OrganizationInfo(oriOrgInfo.OrgTemplateId, destGrade, destPrincipal, oriOrgInfo.SettlementId);
		character.SetOrganizationInfo(destOrgInfo, context);
		if (autoCommitLifeRecord)
		{
			if (destGrade > oriOrgInfo.Grade || (destGrade == oriOrgInfo.Grade && destPrincipal && !oriOrgInfo.Principal))
			{
				LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
				Location location = character.GetLocation();
				int currDate = DomainManager.World.GetCurrDate();
				sbyte gender = character.GetGender();
				lifeRecordCollection.AddChangeGrade(charId, currDate, location, destOrgInfo.OrgTemplateId, destGrade, destPrincipal, gender);
			}
			else if (destGrade < oriOrgInfo.Grade || (destGrade == oriOrgInfo.Grade && destPrincipal && !oriOrgInfo.Principal))
			{
				LifeRecordCollection lifeRecordCollection2 = DomainManager.LifeRecord.GetLifeRecordCollection();
				Location location2 = character.GetLocation();
				int currDate2 = DomainManager.World.GetCurrDate();
				sbyte gender2 = character.GetGender();
				lifeRecordCollection2.AddChangeGradeDrop(charId, currDate2, location2, destOrgInfo.OrgTemplateId, destGrade, destPrincipal, gender2);
			}
		}
		if (oriOrgInfo.SettlementId < 0)
		{
			return;
		}
		Settlement settlement = _settlements[oriOrgInfo.SettlementId];
		OrganizationItem orgConfig = Config.Organization.Instance[oriOrgInfo.OrgTemplateId];
		if (orgConfig.Hereditary && oriOrgInfo.Principal && oriOrgInfo.Grade > 0)
		{
			OrgMemberCollection lackingMembers = settlement.GetLackingCoreMembers();
			lackingMembers.Add(charId, oriOrgInfo.Grade);
			settlement.SetLackingCoreMembers(lackingMembers, context);
		}
		OrgMemberCollection members = settlement.GetMembers();
		members.OnChangeGrade(charId, oriOrgInfo.Grade, destGrade);
		settlement.SetMembers(members, context);
		if (orgConfig.IsSect)
		{
			TryAddSectMemberFeature(context, character, destOrgInfo);
			if (destGrade == 8 && destPrincipal)
			{
				character.AddFeature(context, 696);
			}
			else if (oriOrgInfo.Grade == 8 && oriOrgInfo.Principal)
			{
				character.RemoveFeature(context, 696);
			}
		}
		settlement.RemoveSettlementFeatures(context, character);
		settlement.AddSettlementFeatures(context, character);
		int factionId = character.GetFactionId();
		if (factionId == charId)
		{
			RemoveFaction(context, character, leaderIsDead: false);
		}
		else if (factionId >= 0)
		{
			LeaveFaction(context, character, charIsDead: false);
		}
		if (destPrincipal)
		{
			CheckPrincipalMembersAmount(oriOrgInfo.OrgTemplateId, destGrade, members);
		}
		if (destGrade > oriOrgInfo.Grade && settlement is Sect)
		{
			OrganizationMemberItem orgMemberConfig = GetOrgMemberConfig(destOrgInfo);
			SetRandomSectMentor(context, charId, destOrgInfo, members, orgMemberConfig.TeacherGrade);
		}
		character.ChangeMerchantType(context, destOrgInfo);
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(8);
		AristocratSkillsData skillsData = professionData.GetSkillsData<AristocratSkillsData>();
		if (skillsData.IsCharacterRecommended(charId) && destPrincipal)
		{
			short influencePower = DomainManager.Organization.GetSettlementCharacter(charId).GetInfluencePower();
			if (destGrade > oriOrgInfo.Grade)
			{
				int gradeChange = destGrade - oriOrgInfo.Grade;
				ProfessionFormulaItem seniorityFormula = ProfessionFormula.Instance[57];
				int addSeniority = seniorityFormula.Calculate(influencePower, gradeChange);
				DomainManager.Extra.ChangeProfessionSeniority(context, 8, addSeniority);
			}
			if (destGrade == 8 && orgConfig.IsSect)
			{
				ProfessionFormulaItem seniorityFormula2 = ProfessionFormula.Instance[58];
				int addSeniority2 = seniorityFormula2.Calculate(influencePower);
				DomainManager.Extra.ChangeProfessionSeniority(context, 8, addSeniority2);
			}
		}
		if (orgConfig.TemplateId == 16)
		{
			DomainManager.Taiwu.OnTaiwuVillagerGradeChanged(context, character, destGrade);
		}
	}

	public void JoinNearbyVillageTownAsBeggar(DataContext context, GameData.Domains.Character.Character character, short settlementId = -1)
	{
		if (settlementId < 0)
		{
			Location location = character.GetLocation();
			if (!location.IsValid())
			{
				location = character.GetValidLocation();
			}
			if (location.AreaId == 138)
			{
				MapAreaData areaData = DomainManager.Map.GetElement_Areas(location.AreaId);
				settlementId = areaData.SettlementInfos[0].SettlementId;
			}
			else if (location.AreaId < 135)
			{
				sbyte stateId = DomainManager.Map.GetStateIdByAreaId(location.AreaId);
				List<short> settlementIds = ObjectPool<List<short>>.Instance.Get();
				DomainManager.Map.GetStateSettlementIds(stateId, settlementIds);
				settlementIds.Remove(character.GetOrganizationInfo().SettlementId);
				short taiwuVillageSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
				if (settlementIds.Count > 1 && settlementIds.Contains(taiwuVillageSettlementId))
				{
					settlementIds.Remove(taiwuVillageSettlementId);
				}
				settlementId = (short)((settlementIds.Count <= 0) ? (-1) : settlementIds.GetRandom(context.Random));
				ObjectPool<List<short>>.Instance.Return(settlementIds);
			}
			else
			{
				settlementId = -1;
			}
		}
		if (settlementId >= 0)
		{
			Settlement settlement = GetSettlement(settlementId);
			OrganizationInfo orgInfo = new OrganizationInfo(settlement.GetOrgTemplateId(), 0, principal: true, settlementId);
			ChangeOrganization(context, character, orgInfo);
		}
		else
		{
			ChangeOrganization(context, character, OrganizationInfo.None);
		}
	}

	public bool CheckSettlementGradeIsFull(GameData.Domains.Character.Character selfChar)
	{
		Settlement settlement = GetSettlementOrDefault(selfChar.GetOrganizationInfo().SettlementId);
		if (settlement == null)
		{
			return true;
		}
		sbyte grade = selfChar.GetOrganizationInfo().Grade;
		int expected = settlement.GetExpectedCoreMemberAmount(OrganizationMember.Instance[settlement.OrganizationConfig.Members[grade]]);
		return settlement.GetMembers().GetMembers(grade).Count > expected * 2;
	}

	public sbyte GetChildGrade(IRandomSource random, sbyte[] grades, short settlementId)
	{
		if (grades == null || grades.Length <= 0)
		{
			return -1;
		}
		Settlement settlement = DomainManager.Organization.GetSettlementOrDefault(settlementId);
		if (settlement == null)
		{
			return grades.GetRandom(random);
		}
		OrgMemberCollection members = settlement.GetMembers();
		sbyte grade = grades[0];
		for (int idx = 1; idx < grades.Length; idx++)
		{
			if (members.GetMembers(grade).Count * settlement.GetExpectedCoreMemberAmount(grades[idx]) > members.GetMembers(grades[idx]).Count * settlement.GetExpectedCoreMemberAmount(grade))
			{
				grade = grades[idx];
			}
		}
		return grade;
	}

	public bool KeepJoinOrganizationDirection(GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar)
	{
		OrganizationInfo selfOrgInfo = selfChar.GetOrganizationInfo();
		bool selfIsSectMember = Config.Organization.Instance[selfOrgInfo.OrgTemplateId].IsSect;
		sbyte selfCharGrade = selfOrgInfo.Grade;
		int selfAuthority = selfChar.GetResource(7);
		OrganizationInfo targetOrgInfo = targetChar.GetOrganizationInfo();
		bool targetIsSectMember = Config.Organization.Instance[targetOrgInfo.OrgTemplateId].IsSect;
		sbyte targetCharGrade = targetOrgInfo.Grade;
		int targetAuthority = targetChar.GetResource(7);
		if (selfIsSectMember && !targetIsSectMember)
		{
			return true;
		}
		if (!selfIsSectMember && targetIsSectMember)
		{
			return false;
		}
		bool selfSectGradeFull = CheckSettlementGradeIsFull(selfChar);
		bool targetSectGradeFull = CheckSettlementGradeIsFull(targetChar);
		if (selfSectGradeFull && !targetSectGradeFull)
		{
			return true;
		}
		if (!selfSectGradeFull && targetSectGradeFull)
		{
			return false;
		}
		if (selfCharGrade > targetCharGrade)
		{
			return true;
		}
		if (selfCharGrade < targetCharGrade)
		{
			return false;
		}
		if (selfAuthority > targetAuthority)
		{
			return true;
		}
		if (selfAuthority < targetAuthority)
		{
			return false;
		}
		if (selfChar.GetId() < targetChar.GetId())
		{
			return true;
		}
		return false;
	}

	public bool CanPerformDistantMarriage(GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar)
	{
		if (selfChar.GetOrganizationInfo().OrgTemplateId == 16 || targetChar.GetOrganizationInfo().OrgTemplateId == 16)
		{
			return true;
		}
		GameData.Domains.Character.Character far;
		GameData.Domains.Character.Character near;
		if (!KeepJoinOrganizationDirection(selfChar, targetChar))
		{
			GameData.Domains.Character.Character character = selfChar;
			far = character;
			near = targetChar;
		}
		else
		{
			GameData.Domains.Character.Character character = targetChar;
			far = character;
			near = selfChar;
		}
		if (CheckSettlementGradeIsFull(near))
		{
			return false;
		}
		sbyte grade = far.GetOrganizationInfo().Grade;
		Settlement settlement = GetSettlementOrDefault(far.GetOrganizationInfo().SettlementId);
		if (settlement == null)
		{
			return true;
		}
		int expected = settlement.GetExpectedCoreMemberAmount(OrganizationMember.Instance[settlement.OrganizationConfig.Members[grade]]);
		foreach (int charId in settlement.GetMembers().GetMembers(grade))
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character2) && character2.GetOrganizationInfo().Principal && character2.GetAgeGroup() == 2 && --expected < 0)
			{
				return true;
			}
		}
		return false;
	}

	public void UpdateOrganizationAfterMarriage(DataContext context, GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (selfChar.GetId() != taiwuCharId && targetChar.GetId() != taiwuCharId)
		{
			if (KeepJoinOrganizationDirection(selfChar, targetChar))
			{
				DomainManager.Organization.JoinSpouseOrganization(context, targetChar, selfChar);
			}
			else
			{
				DomainManager.Organization.JoinSpouseOrganization(context, selfChar, targetChar);
			}
		}
	}

	public void JoinSpouseOrganization(DataContext context, GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character spouseChar)
	{
		OrganizationInfo selfOrgInfo = selfChar.GetOrganizationInfo();
		OrganizationInfo spouseOrgInfo = spouseChar.GetOrganizationInfo();
		OrganizationMemberItem spouseOrgMemberCfg = GetOrgMemberConfig(spouseOrgInfo);
		int num;
		if (spouseOrgInfo.Principal)
		{
			if (spouseOrgMemberCfg != null)
			{
				sbyte[] childGrade = spouseOrgMemberCfg.ChildGrade;
				if (childGrade != null)
				{
					num = ((childGrade.Length > 0) ? 1 : 0);
					goto IL_0037;
				}
			}
			num = 0;
			goto IL_0037;
		}
		goto IL_0044;
		IL_0044:
		Logger.AppendWarning($"Invalid marriage between {selfChar} x {spouseChar}: principal={spouseOrgInfo.Principal}, childGrade={spouseOrgMemberCfg.ChildGrade} >= 0");
		return;
		IL_0037:
		if (num != 0)
		{
			if (selfOrgInfo.OrgTemplateId == spouseOrgInfo.OrgTemplateId && selfOrgInfo.SettlementId == spouseOrgInfo.SettlementId)
			{
				UpdateGradeAccordingToSpouse(context, selfChar, spouseChar);
			}
			else if (spouseOrgInfo.OrgTemplateId == 16)
			{
				OrganizationInfo selfNewOrgInfo = new OrganizationInfo(spouseOrgInfo.OrgTemplateId, 0, principal: true, spouseOrgInfo.SettlementId);
				DomainManager.Organization.ChangeOrganization(context, selfChar, selfNewOrgInfo);
			}
			else
			{
				OrganizationInfo selfNewOrgInfo2 = new OrganizationInfo(spouseOrgInfo.OrgTemplateId, (sbyte)((!spouseOrgMemberCfg.RestrictPrincipalAmount || spouseOrgMemberCfg.DeputySpouseDowngrade >= 0) ? spouseOrgInfo.Grade : 0), spouseOrgMemberCfg.DeputySpouseDowngrade < 0, spouseOrgInfo.SettlementId);
				DomainManager.Organization.ChangeOrganization(context, selfChar, selfNewOrgInfo2);
			}
			return;
		}
		goto IL_0044;
	}

	public void UpdateGradeAccordingToSpouse(DataContext context, GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character spouseChar)
	{
		OrganizationInfo selfOrgInfo = selfChar.GetOrganizationInfo();
		OrganizationInfo spouseOrgInfo = spouseChar.GetOrganizationInfo();
		if (selfOrgInfo.OrgTemplateId != spouseOrgInfo.OrgTemplateId || selfOrgInfo.SettlementId != spouseOrgInfo.SettlementId || (selfOrgInfo.Grade >= spouseOrgInfo.Grade && selfOrgInfo.Principal) || selfOrgInfo.OrgTemplateId == 16)
		{
			return;
		}
		OrganizationMemberItem spouseOrgMemberCfg = GetOrgMemberConfig(spouseOrgInfo);
		Tester.Assert(spouseOrgInfo.Principal);
		if (spouseOrgMemberCfg.DeputySpouseDowngrade < 0)
		{
			if (!selfOrgInfo.Principal && !spouseOrgMemberCfg.RestrictPrincipalAmount)
			{
				ChangeGrade(context, selfChar, spouseOrgInfo.Grade, destPrincipal: true);
			}
		}
		else
		{
			ChangeGrade(context, selfChar, spouseOrgInfo.Grade, destPrincipal: false);
		}
	}

	private void UpdateAllMentorsAndMenteesInSect(DataContext context, Sect sect)
	{
		OrgMemberCollection sectMembers = sect.GetMembers();
		for (sbyte grade = 0; grade < 8; grade++)
		{
			HashSet<int> members = sectMembers.GetMembers(grade);
			foreach (int charId in members)
			{
				if (DomainManager.Character.TryGetElement_Objects(charId, out var mentee))
				{
					OrganizationInfo menteeOrgInfo = mentee.GetOrganizationInfo();
					OrganizationMemberItem orgMemberConfig = GetOrgMemberConfig(menteeOrgInfo);
					DomainManager.Organization.SetRandomSectMentor(context, charId, menteeOrgInfo, sectMembers, orgMemberConfig.TeacherGrade);
				}
			}
		}
	}

	public void GetCharactersFromSettlement(short settlementId, sbyte minGrade, sbyte maxGrade, List<GameData.Domains.Character.Character> result)
	{
		GetCharactersFromSettlementWithInfantFilter(settlementId, minGrade, maxGrade, result, includeInfant: true);
	}

	public void GetCharactersFromSettlementWithInfantFilter(short settlementId, sbyte minGrade, sbyte maxGrade, List<GameData.Domains.Character.Character> result, bool includeInfant = false)
	{
		result.Clear();
		Settlement sect = DomainManager.Organization.GetSettlement(settlementId);
		OrgMemberCollection sectMembers = sect.GetMembers();
		for (sbyte grade = minGrade; grade <= maxGrade; grade++)
		{
			IEnumerable<GameData.Domains.Character.Character> gradeMembers = from memberId in sectMembers.GetMembers(grade)
				select DomainManager.Character.GetElement_Objects(memberId);
			if (!includeInfant)
			{
				gradeMembers = DomainManager.Character.ExcludeInfant(gradeMembers);
			}
			result.AddRange(gradeMembers);
		}
	}

	public void OnCharacterDead(DataContext context, GameData.Domains.Character.Character character)
	{
		ClearOrganizationStatus(context, character, charIsDead: true);
	}

	public void ClearOrganizationStatus(DataContext context, GameData.Domains.Character.Character character, bool charIsDead)
	{
		LeaveOrganization(context, character, charIsDead);
		int charId = character.GetId();
		sbyte fugitiveSectId = GetFugitiveBountySect(charId);
		if (fugitiveSectId >= 0)
		{
			Sect sect = (Sect)GetSettlementByOrgTemplateId(fugitiveSectId);
			sect.RemoveBounty(context, charId);
		}
		sbyte prisonerSectId = GetPrisonerSect(charId);
		if (prisonerSectId >= 0)
		{
			Sect sect2 = (Sect)GetSettlementByOrgTemplateId(prisonerSectId);
			sect2.RemovePrisoner(context, charId);
		}
		DomainManager.Building.TryRemoveFeastCustomer(context, charId);
	}

	public void OnSectMemberCrimeMadePublic(DataContext context, GameData.Domains.Character.Character character, OrganizationInfo orgInfoOnCommit, sbyte punishmentSeverity, short punishmentType)
	{
		if (punishmentSeverity < 0 || punishmentType < 0 || orgInfoOnCommit.SettlementId != character.GetOrganizationInfo().SettlementId || character.IsCompletelyInfected())
		{
			return;
		}
		if (!DomainManager.Organization.TryGetElement_Sects(orgInfoOnCommit.SettlementId, out var sect))
		{
			if (orgInfoOnCommit.SettlementId < 0)
			{
				return;
			}
			Location settlementLocation = DomainManager.Organization.GetSettlement(orgInfoOnCommit.SettlementId).GetLocation();
			if (!settlementLocation.IsValid())
			{
				return;
			}
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(settlementLocation.AreaId);
			MapStateItem stateCfg = MapState.Instance[stateTemplateId];
			if (stateCfg.SectID < 0)
			{
				return;
			}
			sect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(stateCfg.SectID);
		}
		PunishmentSeverityItem punishSeverityCfg = PunishmentSeverity.Instance[punishmentSeverity];
		sbyte behaviorType = character.GetBehaviorType();
		sbyte escapeChance = punishSeverityCfg.EscapePunishmentChance[behaviorType];
		if (punishmentType == 41)
		{
			escapeChance = 100;
		}
		if (character.IsActiveExternalRelationState(32uL))
		{
			DomainManager.Organization.PunishSectMember(context, sect, character, punishmentSeverity, punishmentType, isArrested: true);
			return;
		}
		if (!context.Random.CheckPercentProb(escapeChance) && character.IsInteractableAsIntelligentCharacter())
		{
			DomainManager.Character.LeaveGroup(context, character);
			DomainManager.Character.GroupMove(context, character, sect.GetLocation());
			DomainManager.Organization.PunishSectMember(context, sect, character, punishmentSeverity, punishmentType);
			return;
		}
		OrganizationInfo currOrgInfo = character.GetOrganizationInfo();
		if (currOrgInfo.OrgTemplateId == orgInfoOnCommit.OrgTemplateId)
		{
			DomainManager.Organization.ChangeOrganization(context, character, new OrganizationInfo(0, currOrgInfo.Grade, principal: true, -1));
		}
		sect.AddBounty(context, character, punishmentSeverity, punishmentType);
	}

	public void PunishSectMember(DataContext context, Sect sect, GameData.Domains.Character.Character character, sbyte punishmentSeverity = -1, short punishmentType = -1, bool isArrested = false)
	{
		int charId = character.GetId();
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		sbyte sectTemplateId = sect.GetOrgTemplateId();
		short sectSettlementId = sect.GetId();
		PunishmentTypeItem punishmentTypeCfg = PunishmentType.Instance[punishmentType];
		if (punishmentTypeCfg == null)
		{
			PredefinedLog.Show(33, character, PunishmentSeverity.Instance.GetItem(punishmentSeverity)?.Name);
			return;
		}
		if (punishmentSeverity < 0)
		{
			punishmentSeverity = sect.GetPunishmentTypeSeverity(punishmentTypeCfg, includeDefault: true);
		}
		PunishmentSeverityItem punishmentSeverityCfg = PunishmentSeverity.Instance[punishmentSeverity];
		if (punishmentSeverityCfg.ResourceConfiscation > 0)
		{
			ResourceInts resources = character.GetResources();
			if (punishmentSeverityCfg.ResourceConfiscation == 1)
			{
				for (sbyte resourceType = 0; resourceType < 8; resourceType++)
				{
					resources[resourceType] /= 2;
				}
			}
			sect.ConfiscateResources(context, character, ref resources);
		}
		if (punishmentSeverityCfg.ItemConfiscation > 0)
		{
			List<ItemKey> itemKeys = ObjectPool<List<ItemKey>>.Instance.Get();
			character.GetItemsToLose(itemKeys, 0, 8);
			itemKeys.Sort(ItemTemplateHelper.ItemGradeComparer);
			if (punishmentSeverityCfg.ItemConfiscation == 1)
			{
				int removeIndex = itemKeys.Count / 2;
				itemKeys.RemoveRange(removeIndex, itemKeys.Count - removeIndex);
			}
			sect.ConfiscateItem(context, character, itemKeys);
			ObjectPool<List<ItemKey>>.Instance.Return(itemKeys);
		}
		if (punishmentSeverityCfg.CombatSkillRevoke > 0)
		{
			List<short> skillsToRevoke = ObjectPool<List<short>>.Instance.Get();
			character.GetLearnedCombatSkillsFromSect(skillsToRevoke, sectTemplateId, 0, 8);
			int removeCount = skillsToRevoke.Count;
			if (punishmentSeverityCfg.CombatSkillRevoke == 1)
			{
				removeCount /= 2;
				skillsToRevoke.Sort(GameData.Domains.Character.CombatSkillHelper.CombatSkillGradeComparer);
			}
			for (int index = skillsToRevoke.Count - removeCount; index < skillsToRevoke.Count; index++)
			{
				short skillId = skillsToRevoke[index];
				DomainManager.Character.RevokeCombatSkill(context, character, skillId);
			}
			ObjectPool<List<short>>.Instance.Return(skillsToRevoke);
		}
		if (character.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
		{
			return;
		}
		if (punishmentSeverityCfg.PrisonTime > 0)
		{
			sect.AddPrisoner(context, character, punishmentSeverity, punishmentType);
			SettlementPrisonRecordCollection prisonRecord = DomainManager.Organization.GetSettlementPrisonRecordCollection(context, sectSettlementId);
			int currDate = DomainManager.World.GetCurrDate();
			if (isArrested)
			{
				prisonRecord.AddImprisonedByArrested(currDate, sectSettlementId, charId, punishmentType);
			}
			else
			{
				prisonRecord.AddImprisonedVoluntarily(currDate, sectSettlementId, charId, punishmentType);
			}
		}
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (punishmentSeverityCfg.Expel)
		{
			int spouseId = DomainManager.Character.GetAliveSpouse(charId);
			GameData.Domains.Character.Character spouseChar = ((spouseId >= 0) ? DomainManager.Character.GetElement_Objects(spouseId) : null);
			OrganizationInfo spouseOrgInfo = default(OrganizationInfo);
			if (spouseChar != null)
			{
				spouseOrgInfo = spouseChar.GetOrganizationInfo();
				if (spouseOrgInfo.OrgTemplateId != orgInfo.OrgTemplateId || (spouseOrgInfo.Principal && orgInfo.Principal))
				{
					spouseChar = null;
					spouseId = -1;
				}
			}
			lifeRecordCollection.AddSectPunishmentRecord(punishmentTypeCfg, punishmentSeverityCfg, sectSettlementId, isArrested, character, spouseId);
			if (spouseChar != null)
			{
				if (spouseOrgInfo.Principal)
				{
					GameData.Domains.Character.Character.ApplySeverHusbandOrWife(context, character, spouseChar, character.GetBehaviorType(), selfIsTaiwuPeople: false, targetIsTaiwuPeople: false);
				}
				else
				{
					PunishSectMember(context, sect, spouseChar, punishmentSeverity, 21);
				}
			}
		}
		else
		{
			lifeRecordCollection.AddSectPunishmentRecord(punishmentTypeCfg, punishmentSeverityCfg, sectSettlementId, isArrested, character, -1);
			if (orgInfo.OrgTemplateId == 0 && punishmentSeverityCfg.PrisonTime <= 0)
			{
				sect.AdjustPunishedSectMemberOrganization(context, character);
			}
		}
	}

	public void TryAddSectMemberFeature(DataContext context, GameData.Domains.Character.Character character, OrganizationInfo dstOrgInfo)
	{
		if (character.GetAgeGroup() == 2)
		{
			short featureId = Config.Organization.Instance[dstOrgInfo.OrgTemplateId].MemberFeature;
			if (featureId >= 0 && dstOrgInfo.Grade >= GlobalConfig.Instance.AddMemberFeatureMinGrade)
			{
				character.AddFeature(context, featureId);
			}
		}
	}

	public static short GetApprovingRateUpperLimit()
	{
		int xiangshuLevel = Math.Clamp(DomainManager.World.GetXiangshuLevel(), 0, GlobalConfig.Instance.SectApprovingRateUpperLimits.Length);
		int upperLimit = GlobalConfig.Instance.SectApprovingRateUpperLimits[xiangshuLevel] * 10;
		return (short)Math.Min(upperLimit, 1000);
	}

	public static sbyte GetHighestGradeOfTeachableCombatSkill(short approvingRate)
	{
		if (approvingRate < 300)
		{
			return 1;
		}
		int grade = 2 + (approvingRate - 300) / 100;
		return (sbyte)Math.Clamp(grade, 0, 8);
	}

	public static bool IsLargeSect(short orgTemplateId)
	{
		return orgTemplateId >= 1 && orgTemplateId <= 15;
	}

	public static sbyte GetLargeSectIndex(sbyte orgTemplateId)
	{
		return (sbyte)((orgTemplateId >= 1 && orgTemplateId <= 15) ? ((sbyte)(orgTemplateId - 1)) : (-1));
	}

	public static sbyte GetLargeSectTemplateId(sbyte index)
	{
		return (sbyte)(index + 1);
	}

	public void UpdateSectPrisonersOnAdvanceMonth(DataContext context)
	{
		foreach (var (_, sect2) in _sects)
		{
			sect2.UpdatePrisonOnAdvanceMonth(context);
		}
	}

	public void UpdateFugitiveGroupsOnAdvanceMonth(DataContext context)
	{
		Dictionary<IntPair, List<GameData.Domains.Character.Character>> groups = new Dictionary<IntPair, List<GameData.Domains.Character.Character>>();
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		foreach (var (_, sect2) in _sects)
		{
			groups.Clear();
			List<SettlementBounty> bounties = sect2.Prison.Bounties;
			foreach (SettlementBounty bounty in bounties)
			{
				if (!DomainManager.Character.TryGetElement_Objects(bounty.CharId, out var character) || !character.IsInteractableAsIntelligentCharacter() || character == taiwuChar)
				{
					continue;
				}
				Location location = character.GetLocation();
				if (location.AreaId < 0 || !character.IsEscapingFromBounty())
				{
					continue;
				}
				int leaderId = character.GetLeaderId();
				if (leaderId < 0)
				{
					IntPair key = new IntPair(location.AreaId, character.ActionPlanningData.PrimaryGoalAction.GetActualTargetLocation().AreaId);
					if (!groups.TryGetValue(key, out var group))
					{
						group = new List<GameData.Domains.Character.Character>();
						groups.Add(key, group);
					}
					group.Add(character);
				}
			}
			foreach (var (key2, group2) in groups)
			{
				if (group2.Count <= 1)
				{
					continue;
				}
				GameData.Domains.Character.Character leader = group2.GetRandom(context.Random);
				foreach (GameData.Domains.Character.Character groupChar in group2)
				{
					if (leader != groupChar)
					{
						DomainManager.Character.JoinGroup(context, groupChar, leader);
					}
				}
			}
		}
	}

	public void UpdateOrganizationMembers(DataContext context)
	{
		bool isPreparingMartialArtTournament = PauseUpdateInfluencePower;
		int currDate = DomainManager.World.GetCurrDate();
		Dictionary<int, (GameData.Domains.Character.Character, short)> baseInfluencePowers = new Dictionary<int, (GameData.Domains.Character.Character, short)>();
		HashSet<int> relatedCharIds = new HashSet<int>();
		short key;
		foreach (KeyValuePair<short, Sect> sect2 in _sects)
		{
			sect2.Deconstruct(out key, out var value);
			Sect sect = value;
			sbyte orgTemplateId = sect.GetOrgTemplateId();
			sect.UpdateMemberGrades(context);
			short influencePowerUpdateInterval = Config.Organization.Instance[orgTemplateId].InfluencePowerUpdateInterval;
			int influencePowerUpdateDate = sect.GetInfluencePowerUpdateDate();
			if (isPreparingMartialArtTournament)
			{
				sect.SetInfluencePowerUpdateDate(influencePowerUpdateDate + 1, context);
			}
			else if (influencePowerUpdateInterval > 0 && currDate >= influencePowerUpdateDate)
			{
				sect.UpdateInfluencePowers(context, baseInfluencePowers, relatedCharIds, !isPreparingMartialArtTournament);
				sect.SetInfluencePowerUpdateDate(currDate + influencePowerUpdateInterval, context);
				UpdateFactions(context, sect);
			}
			if (currDate % 3 == 0)
			{
				sect.UpdateApprovalOfTaiwu(context);
			}
			UpdateAllMentorsAndMenteesInSect(context, sect);
			sect.UpdateTreasuryOnAdvanceMonth(context);
			sect.PrisonEnteredStatus = TreasuryOrPrisonVisitStatusType.None;
		}
		foreach (KeyValuePair<short, CivilianSettlement> civilianSettlement in _civilianSettlements)
		{
			civilianSettlement.Deconstruct(out key, out var value2);
			CivilianSettlement settlement = value2;
			sbyte orgTemplateId2 = settlement.GetOrgTemplateId();
			settlement.UpdateMemberGrades(context);
			short influencePowerUpdateInterval2 = Config.Organization.Instance[orgTemplateId2].InfluencePowerUpdateInterval;
			int influencePowerUpdateDate2 = settlement.GetInfluencePowerUpdateDate();
			if (influencePowerUpdateInterval2 > 0 && currDate >= influencePowerUpdateDate2)
			{
				settlement.UpdateInfluencePowers(context, baseInfluencePowers, relatedCharIds, updateTreasury: true);
				settlement.SetInfluencePowerUpdateDate(currDate + influencePowerUpdateInterval2, context);
			}
			settlement.UpdateTreasuryOnAdvanceMonth(context);
		}
		short taiwuVillageSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		Settlement taiwuVillageSettlement = DomainManager.Organization.GetSettlement(taiwuVillageSettlementId);
		sbyte orgTemplateId3 = taiwuVillageSettlement.GetOrgTemplateId();
		short influencePowerUpdateInterval3 = Config.Organization.Instance[orgTemplateId3].InfluencePowerUpdateInterval;
		int influencePowerUpdateDate3 = taiwuVillageSettlement.GetInfluencePowerUpdateDate();
		if (influencePowerUpdateInterval3 > 0 && currDate >= influencePowerUpdateDate3)
		{
			taiwuVillageSettlement.UpdateTaiwuVillagerInfluencePowers(context, baseInfluencePowers, relatedCharIds);
			taiwuVillageSettlement.SetInfluencePowerUpdateDate(currDate + influencePowerUpdateInterval3, context);
		}
		UpdateSettlementCacheInfo();
		DomainManager.Building.UpdateBuildingEffect();
	}

	[DomainMethod]
	public void ForceUpdateTaiwuVillager(DataContext context)
	{
		Dictionary<int, (GameData.Domains.Character.Character, short)> baseInfluencePowers = new Dictionary<int, (GameData.Domains.Character.Character, short)>();
		HashSet<int> relatedCharIds = new HashSet<int>();
		short taiwuVillageSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		Settlement taiwuVillageSettlement = DomainManager.Organization.GetSettlement(taiwuVillageSettlementId);
		taiwuVillageSettlement.UpdateTaiwuVillagerInfluencePowers(context, baseInfluencePowers, relatedCharIds);
	}

	private void UpdateSettlementCacheInfo()
	{
		bool isPreparing = DomainManager.Organization.GetCurrTournamentState() != EMartialArtTournamentState.WaitTrigger;
		if (ParallelUpdateOrganizationMembers)
		{
			Parallel.ForEach(_settlements, delegate(KeyValuePair<short, Settlement> pair)
			{
				Settlement value = pair.Value;
				value.SortMembersByCombatPower();
				if (isPreparing && value is Sect sect2)
				{
					sect2.UpdateMartialArtTournamentPreparations();
				}
			});
		}
		else
		{
			foreach (KeyValuePair<short, Settlement> settlement2 in _settlements)
			{
				Settlement settlement = settlement2.Value;
				settlement.SortMembersByCombatPower();
				if (isPreparing && settlement is Sect sect)
				{
					sect.UpdateMartialArtTournamentPreparations();
				}
			}
		}
		DomainManager.Character.UpdateTopThousandCharRanking();
	}

	public void ForceUpdateInfluencePowers(DataContext context, bool updateTreasury = true)
	{
		Dictionary<int, (GameData.Domains.Character.Character, short)> baseInfluencePowers = new Dictionary<int, (GameData.Domains.Character.Character, short)>();
		HashSet<int> relatedCharIds = new HashSet<int>();
		int currDate = DomainManager.World.GetCurrDate();
		DomainManager.Extra.InitTreasurySupplies();
		foreach (KeyValuePair<short, Settlement> settlement2 in _settlements)
		{
			Settlement settlement = settlement2.Value;
			short influencePowerUpdateInterval = Config.Organization.Instance[settlement.GetOrgTemplateId()].InfluencePowerUpdateInterval;
			settlement.UpdateInfluencePowers(context, baseInfluencePowers, relatedCharIds, updateTreasury);
			if (influencePowerUpdateInterval > 0)
			{
				settlement.SetInfluencePowerUpdateDate(currDate + influencePowerUpdateInterval, context);
			}
			if (settlement is Sect sect)
			{
				UpdateFactions(context, sect);
			}
		}
	}

	public void ResetSectExploreStatuses(DataContext context)
	{
		foreach (var (_, sect2) in _sects)
		{
			sect2.SetTaiwuExploreStatus(0, context);
			sect2.SetSpiritualDebtInteractionOccurred(spiritualDebtInteractionOccurred: false, context);
		}
	}

	public void BecomeSectMonk(DataContext context, GameData.Domains.Character.Character character, short mentorSeniorityId)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		OrganizationMemberItem orgMemberCfg = GetOrgMemberConfig(orgInfo);
		Sect sect = _sects[orgInfo.SettlementId];
		BecomeSectMonkInternal(context, character, sect, orgMemberCfg, mentorSeniorityId);
	}

	public static bool TryBecomeSectMonk(DataContext context, GameData.Domains.Character.Character character, Sect sect, OrganizationMemberItem orgMemberCfg, short mentorSeniorityId)
	{
		if (!CheckConditionOfBecomingSectMonk(context, character, orgMemberCfg))
		{
			return false;
		}
		if (orgMemberCfg.ProbOfBecomingMonk <= 0)
		{
			return false;
		}
		if (!context.Random.CheckPercentProb(orgMemberCfg.ProbOfBecomingMonk))
		{
			return false;
		}
		BecomeSectMonkInternal(context, character, sect, orgMemberCfg, mentorSeniorityId);
		return true;
	}

	public void SelectRandomSectCharacterToApproveTaiwu(DataContext context, sbyte orgTemplateId, sbyte grade)
	{
		Tester.Assert(IsSect(orgTemplateId));
		Settlement organization = GetSettlementByOrgTemplateId(orgTemplateId);
		OrgMemberCollection orgMembers = organization.GetMembers();
		List<int> validMembers = ObjectPool<List<int>>.Instance.Get();
		for (sbyte actualGrade = grade; actualGrade >= 0; actualGrade--)
		{
			IEnumerable<int> gradeMembers = DomainManager.Character.ExcludeInfant(orgMembers.GetMembers(actualGrade));
			validMembers.Clear();
			foreach (int gradeMember in gradeMembers)
			{
				SectCharacter sectChar = _sectCharacters[gradeMember];
				if (!sectChar.GetApprovedTaiwu())
				{
					validMembers.Add(gradeMember);
				}
			}
			if (validMembers.Count > 0)
			{
				break;
			}
		}
		if (validMembers.Count > 0)
		{
			int targetGradeSectCharId = validMembers.GetRandom(context.Random);
			SectCharacter sectChar2 = _sectCharacters[targetGradeSectCharId];
			sectChar2.SetApprovedTaiwu(context, approve: true);
		}
		ObjectPool<List<int>>.Instance.Return(validMembers);
	}

	public void ShowCharactersStats()
	{
		int worldBabyCount = 0;
		int worldChildCount = 0;
		int worldAdultCount = 0;
		List<int> ages = new List<int>();
		StringBuilder message = new StringBuilder();
		message.AppendLine("Organization characters:");
		short key;
		StringBuilder stringBuilder;
		StringBuilder.AppendInterpolatedStringHandler handler;
		foreach (KeyValuePair<short, Sect> sect2 in _sects)
		{
			sect2.Deconstruct(out key, out var value);
			Sect sect = value;
			MapBlockData block = DomainManager.Map.GetBlock(sect.GetLocation()).GetRootBlock();
			string name = MapBlock.Instance[block.TemplateId].Name;
			(int, int, int) ageStats = GetAgeStats(sect.GetMembers(), ages);
			int babyCount = ageStats.Item1;
			int childCount = ageStats.Item2;
			int adultCount = ageStats.Item3;
			worldBabyCount += babyCount;
			worldChildCount += childCount;
			worldAdultCount += adultCount;
			stringBuilder = message;
			StringBuilder stringBuilder2 = stringBuilder;
			handler = new StringBuilder.AppendInterpolatedStringHandler(8, 4, stringBuilder);
			handler.AppendLiteral("  ");
			handler.AppendFormatted<string>(name, 5);
			handler.AppendLiteral(": ");
			handler.AppendFormatted(babyCount, 3);
			handler.AppendLiteral(", ");
			handler.AppendFormatted(childCount, 3);
			handler.AppendLiteral(", ");
			handler.AppendFormatted(adultCount, 3);
			stringBuilder2.AppendLine(ref handler);
		}
		foreach (KeyValuePair<short, CivilianSettlement> civilianSettlement2 in _civilianSettlements)
		{
			civilianSettlement2.Deconstruct(out key, out var value2);
			CivilianSettlement civilianSettlement = value2;
			short randomNameId = civilianSettlement.GetRandomNameId();
			string name2;
			if (randomNameId >= 0)
			{
				name2 = LocalTownNames.Instance.TownNameCore[randomNameId].Name;
			}
			else
			{
				MapBlockData block2 = DomainManager.Map.GetBlock(civilianSettlement.GetLocation()).GetRootBlock();
				name2 = MapBlock.Instance[block2.TemplateId].Name;
			}
			(int, int, int) ageStats2 = GetAgeStats(civilianSettlement.GetMembers(), ages);
			int babyCount2 = ageStats2.Item1;
			int childCount2 = ageStats2.Item2;
			int adultCount2 = ageStats2.Item3;
			worldBabyCount += babyCount2;
			worldChildCount += childCount2;
			worldAdultCount += adultCount2;
			stringBuilder = message;
			StringBuilder stringBuilder3 = stringBuilder;
			handler = new StringBuilder.AppendInterpolatedStringHandler(8, 4, stringBuilder);
			handler.AppendLiteral("  ");
			handler.AppendFormatted<string>(name2, 5);
			handler.AppendLiteral(": ");
			handler.AppendFormatted(babyCount2, 3);
			handler.AppendLiteral(", ");
			handler.AppendFormatted(childCount2, 3);
			handler.AppendLiteral(", ");
			handler.AppendFormatted(adultCount2, 3);
			stringBuilder3.AppendLine(ref handler);
		}
		int totalCount = worldBabyCount + worldChildCount + worldAdultCount;
		float babyPercent = (float)worldBabyCount * 100f / (float)totalCount;
		float childPercent = (float)worldChildCount * 100f / (float)totalCount;
		float adultPercent = (float)worldAdultCount * 100f / (float)totalCount;
		stringBuilder = message;
		StringBuilder stringBuilder4 = stringBuilder;
		handler = new StringBuilder.AppendInterpolatedStringHandler(23, 6, stringBuilder);
		handler.AppendLiteral("Total: ");
		handler.AppendFormatted(worldBabyCount);
		handler.AppendLiteral(" (");
		handler.AppendFormatted(babyPercent, "N1");
		handler.AppendLiteral("%)");
		handler.AppendLiteral(", ");
		handler.AppendFormatted(worldChildCount);
		handler.AppendLiteral(" (");
		handler.AppendFormatted(childPercent, "N1");
		handler.AppendLiteral("%)");
		handler.AppendLiteral(", ");
		handler.AppendFormatted(worldAdultCount);
		handler.AppendLiteral(" (");
		handler.AppendFormatted(adultPercent, "N1");
		handler.AppendLiteral("%)");
		stringBuilder4.AppendLine(ref handler);
		Logger.Info(message);
		Histogram histogram = new Histogram(0, 60, 20);
		histogram.Record(ages);
		Logger.Info($"World ages ({ages.Count}):\n{histogram.GetTextGraph()}");
	}

	[DomainMethod]
	public short GetOrganizationTemplateIdOfTaiwuLocation()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return -1;
		}
		MapBlockData taiwuBlockData = DomainManager.Map.GetBlockData(taiwuLocation.AreaId, taiwuLocation.BlockId);
		return GetSettlementByLocation(taiwuBlockData.GetRootBlock().GetLocation())?.GetOrgTemplateId() ?? (-1);
	}

	public int GetMaxAttainmentValueInGradeHigh(Settlement settlement, sbyte skillType, bool isLifeSkill)
	{
		OrgMemberCollection members = settlement.GetMembers();
		List<int> charIdList = members.GetMembers(8).ToList();
		charIdList.AddRange(members.GetMembers(7));
		charIdList.AddRange(members.GetMembers(6));
		int maxValue = 0;
		foreach (int charId in charIdList)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				short value = (isLifeSkill ? character.GetLifeSkillAttainment(skillType) : character.GetCombatSkillAttainment(skillType));
				if (value > maxValue)
				{
					maxValue = value;
				}
			}
		}
		return maxValue;
	}

	public void SetSectFunctionStatus(DataContext context, sbyte orgTemplateId, SectFunctionStatuses.SectFunctionStatusType statusType, bool value)
	{
		Sect sect = (Sect)GetSettlementByOrgTemplateId(orgTemplateId);
		sect.SetFunctionStatus(context, statusType, value);
		switch (orgTemplateId)
		{
		case 1:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 336);
				break;
			case SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 337);
				break;
			}
			break;
		case 2:
			if (statusType == SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked)
			{
				DomainManager.Global.InvokeGuidingTrigger(context, 338);
			}
			break;
		case 3:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 339);
				break;
			case SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked:
				DomainManager.Story.UpgradeBaihuaLifeLink(context);
				break;
			}
			break;
		case 4:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 340);
				break;
			case SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 341);
				break;
			}
			break;
		case 5:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
			{
				bool demon = DomainManager.Extra.AreVitalsDemon();
				DomainManager.Global.InvokeGuidingTrigger(context, (short)(demon ? 359 : 358));
				break;
			}
			}
			break;
		case 6:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 342);
				break;
			}
			break;
		case 7:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 343);
				break;
			case SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked:
				DomainManager.Extra.SetRanshanThreeCorpsesCharacterUpgrade(context, value);
				break;
			}
			break;
		case 8:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 345);
				break;
			case SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 346);
				break;
			}
			break;
		case 9:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 347);
				break;
			}
			break;
		case 10:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 348);
				break;
			case SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 349);
				break;
			}
			break;
		case 11:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 350);
				break;
			}
			break;
		case 12:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 351);
				break;
			case SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 352);
				break;
			}
			break;
		case 13:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 353);
				break;
			}
			break;
		case 14:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 354);
				break;
			case SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked:
				DomainManager.Building.UnlockFeatherSystem(context);
				DomainManager.Global.InvokeGuidingTrigger(context, 355);
				break;
			}
			break;
		case 15:
			switch (statusType)
			{
			case SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 356);
				break;
			case SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked:
				DomainManager.Global.InvokeGuidingTrigger(context, 357);
				break;
			}
			break;
		}
	}

	[DomainMethod]
	public bool GetSectFunctionStatus(sbyte orgTemplateId, SectFunctionStatuses.SectFunctionStatusType statusType)
	{
		Sect sect = (Sect)GetSettlementByOrgTemplateId(orgTemplateId);
		return sect.GetFunctionStatus(statusType);
	}

	public short GetLastMartialArtTournamentWinner()
	{
		List<short> prevMartialArtTournamentWinners = _prevMartialArtTournamentWinners;
		if (prevMartialArtTournamentWinners == null || prevMartialArtTournamentWinners.Count <= 0)
		{
			return -1;
		}
		List<short> prevMartialArtTournamentWinners2 = _prevMartialArtTournamentWinners;
		return prevMartialArtTournamentWinners2[prevMartialArtTournamentWinners2.Count - 1];
	}

	public void RegisterMartialArtTournamentWinner(DataContext context, short orgTemplateId)
	{
		_prevMartialArtTournamentWinners.Add(orgTemplateId);
		SetPrevMartialArtTournamentWinners(_prevMartialArtTournamentWinners, context);
	}

	public IReadOnlyList<SettlementMemberFeature> GetSettlementMemberFeatures(short settlementId)
	{
		SerializableList<SettlementMemberFeature> list;
		return _settlementMemberFeatures.TryGetValue(settlementId, out list) ? list.Items : null;
	}

	public void RegisterSettlementMemberFeature(DataContext context, short settlementId, SettlementMemberFeature settlementMemberFeature)
	{
		if (_settlementMemberFeatures.TryGetValue(settlementId, out var list))
		{
			ref List<SettlementMemberFeature> items = ref list.Items;
			if (items == null)
			{
				items = new List<SettlementMemberFeature>();
			}
			list.Items.Add(settlementMemberFeature);
			SetElement_SettlementMemberFeatures(settlementId, list, context);
		}
		else
		{
			list = SerializableList<SettlementMemberFeature>.Create();
			list.Items.Add(settlementMemberFeature);
			AddElement_SettlementMemberFeatures(settlementId, list, context);
		}
	}

	public void UnregisterSettlementMemberFeature(short settlementId, SettlementMemberFeature settlementMemberFeature)
	{
		if (!_settlementMemberFeatures.TryGetValue(settlementId, out var list) || list.Items == null)
		{
			return;
		}
		for (int i = 0; i < list.Items.Count; i++)
		{
			if (list.Items[i].FeatureId == settlementMemberFeature.FeatureId)
			{
				list.Items.RemoveAt(i);
				break;
			}
		}
	}

	private void InitializeSettlementsCache()
	{
		_settlements = new Dictionary<short, Settlement>();
		_locationSettlements = new Dictionary<Location, Settlement>();
		int orgTemplateCount = CalcOrgTemplateCount();
		_orgTemplateId2Settlements = new List<Settlement>[orgTemplateCount];
		short key;
		foreach (KeyValuePair<short, Sect> sect2 in _sects)
		{
			sect2.Deconstruct(out key, out var value);
			Sect sect = value;
			AddSettlementCache(sect);
		}
		foreach (KeyValuePair<short, CivilianSettlement> civilianSettlement2 in _civilianSettlements)
		{
			civilianSettlement2.Deconstruct(out key, out var value2);
			CivilianSettlement civilianSettlement = value2;
			AddSettlementCache(civilianSettlement);
		}
	}

	private void InitializeSortedMembersCache(DataContext context, DataUid dataUid)
	{
		UpdateSettlementCacheInfo();
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(dataUid, "InitializeSortedMembersCache");
	}

	private void CreateRelationWithAllSettlementMembers(DataContext context, GameData.Domains.Character.Character character, OrgMemberCollection members)
	{
		for (sbyte grade = 0; grade < 9; grade++)
		{
			foreach (int orgMemberId in members.GetMembers(grade))
			{
				GameData.Domains.Character.Character orgMember = DomainManager.Character.GetElement_Objects(orgMemberId);
				DomainManager.Character.TryCreateGeneralRelation(context, character, orgMember);
			}
		}
	}

	private static int CalcOrgTemplateCount()
	{
		sbyte maxOrgTemplateId = -1;
		foreach (OrganizationItem item in (IEnumerable<OrganizationItem>)Config.Organization.Instance)
		{
			if (item.TemplateId > maxOrgTemplateId)
			{
				maxOrgTemplateId = item.TemplateId;
			}
		}
		return maxOrgTemplateId + 1;
	}

	private void AddSettlementCache(Settlement settlement)
	{
		_locationSettlements.Add(settlement.GetLocation(), settlement);
		_settlements.Add(settlement.GetId(), settlement);
		sbyte orgTemplateId = settlement.GetOrgTemplateId();
		List<Settlement> settlements = _orgTemplateId2Settlements[orgTemplateId];
		if (settlements == null)
		{
			settlements = new List<Settlement>();
			_orgTemplateId2Settlements[orgTemplateId] = settlements;
		}
		settlements.Add(settlement);
	}

	private void RemoveSettlementCache(Settlement settlement)
	{
		_settlements.Remove(settlement.GetId());
		_orgTemplateId2Settlements[settlement.GetOrgTemplateId()]?.Remove(settlement);
	}

	private void InitializeSettlementCharactersCache()
	{
		_settlementCharacters = new Dictionary<int, SettlementCharacter>();
		int key;
		foreach (KeyValuePair<int, SectCharacter> sectCharacter in _sectCharacters)
		{
			sectCharacter.Deconstruct(out key, out var value);
			int charId = key;
			SectCharacter settlementChar = value;
			_settlementCharacters.Add(charId, settlementChar);
		}
		foreach (KeyValuePair<int, CivilianSettlementCharacter> civilianSettlementCharacter in _civilianSettlementCharacters)
		{
			civilianSettlementCharacter.Deconstruct(out key, out var value2);
			int charId2 = key;
			CivilianSettlementCharacter settlementChar2 = value2;
			_settlementCharacters.Add(charId2, settlementChar2);
		}
	}

	private static void CheckPrincipalMembersAmount(sbyte orgTemplateId, sbyte grade, OrgMemberCollection members)
	{
		OrganizationMemberItem config = GetOrgMemberConfig(orgTemplateId, grade);
		if (!config.RestrictPrincipalAmount)
		{
			return;
		}
		int principalAmount = 0;
		HashSet<int> gradeMembers = members.GetMembers(grade);
		foreach (int charId in gradeMembers)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetOrganizationInfo().Principal)
			{
				principalAmount++;
			}
		}
		if (principalAmount <= config.Amount)
		{
			return;
		}
		throw new Exception($"The number of principal members exceeds the max limit: {config.TemplateId}");
	}

	private short SetRandomSectMentor(DataContext context, int charId, OrganizationInfo orgInfo, OrgMemberCollection sectMembers, sbyte mentorGrade)
	{
		if (mentorGrade < 0)
		{
			return -1;
		}
		HashSet<int> mentorIds = DomainManager.Character.GetRelatedCharIds(charId, 2048);
		foreach (int mentorId in mentorIds)
		{
			if (DomainManager.Character.TryGetElement_Objects(mentorId, out var mentor))
			{
				OrganizationInfo mentorOrgInfo = mentor.GetOrganizationInfo();
				if (mentorOrgInfo.SettlementId == orgInfo.SettlementId && mentorOrgInfo.Grade >= mentorGrade)
				{
					return mentor.GetMonasticTitle().SeniorityId;
				}
			}
		}
		while (mentorGrade < 9)
		{
			HashSet<int> gradeCharIds = sectMembers.GetMembers(mentorGrade);
			if (gradeCharIds.Count > 0)
			{
				short maxInfluencePower = short.MinValue;
				int mentorId2 = -1;
				foreach (int gradeCharId in gradeCharIds)
				{
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(gradeCharId);
					if (character.GetKidnapperId() < 0 && character.GetAgeGroup() == 2)
					{
						SettlementCharacter settlementCharacter = GetSettlementCharacter(gradeCharId);
						short influencePower = settlementCharacter.GetInfluencePower();
						if (maxInfluencePower < influencePower)
						{
							maxInfluencePower = influencePower;
							mentorId2 = gradeCharId;
						}
					}
				}
				if (mentorId2 >= 0 && RelationTypeHelper.AllowAddingMentorRelation(charId, mentorId2))
				{
					DomainManager.Character.AddRelation(context, charId, mentorId2, 2048);
					GameData.Domains.Character.Character mentor2 = DomainManager.Character.GetElement_Objects(mentorId2);
					MonasticTitle monasticTitle = mentor2.GetMonasticTitle();
					SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
					int secretInfoOffset1 = secretInformationCollection.AddBecomeMaster(charId, mentorId2);
					SecretInformationId secretId1 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset1);
					int secretInfoOffset2 = secretInformationCollection.AddBecomeApprentice(mentorId2, charId);
					SecretInformationId secretId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
					return monasticTitle.SeniorityId;
				}
			}
			mentorGrade++;
		}
		return -1;
	}

	private static bool CheckConditionOfBecomingSectMonk(DataContext context, GameData.Domains.Character.Character character, OrganizationMemberItem orgMemberCfg)
	{
		byte monkType = character.GetMonkType();
		if (character.GetTemplateId() == 697)
		{
			return false;
		}
		if (monkType == 0)
		{
			return true;
		}
		if ((monkType & 0x80) == 0)
		{
			character.SetMonkType(0, context);
			return true;
		}
		if (monkType != orgMemberCfg.MonkType)
		{
			throw new Exception($"Monk type of character is not compatible with organization: {monkType}, {orgMemberCfg.TemplateId}");
		}
		if (!DomainManager.Character.IsTemporaryIntelligentCharacter(character.GetId()))
		{
			throw new Exception($"Character.Character is not TemporaryIntelligentCharacter: {character.GetTemplateId()}");
		}
		return false;
	}

	private static void BecomeSectMonkInternal(DataContext context, GameData.Domains.Character.Character character, Sect sect, OrganizationMemberItem orgMemberCfg, short mentorSeniorityId)
	{
		if (orgMemberCfg.MonkType == 0)
		{
			throw new Exception($"Sect member {orgMemberCfg.TemplateId} cannot become monk");
		}
		MonasticTitle monasticTitle = CharacterDomain.CreateSectMemberMonasticTitle(context, sect, mentorSeniorityId);
		character.SetMonasticTitle(monasticTitle, context);
		character.SetMonkType(orgMemberCfg.MonkType, context);
		if (orgMemberCfg.MonkType == 130)
		{
			AvatarData avatar = character.GetAvatar();
			avatar.ResetGrowableElementShowingAbility(0);
			character.SetAvatar(avatar, context);
		}
	}

	public static void TrySecularize(DataContext context, GameData.Domains.Character.Character character)
	{
		byte monkType = character.GetMonkType();
		if ((monkType & 0x80) != 0)
		{
			if (character.GetMonkType() == 130)
			{
				AvatarData avatar = character.GetAvatar();
				avatar.SetGrowableElementShowingAbility(0);
				avatar.ResetGrowableElementShowingState(0);
				character.SetAvatar(avatar, context);
				DomainManager.Character.InitializeAvatarElementGrowthProgress(context, character.GetId(), 0);
			}
			character.SetMonkType(0, context);
			character.SetMonasticTitle(new MonasticTitle(-1, -1), context);
		}
	}

	public void TryDowngradeDeputySpouses(DataContext context, int charId, OrganizationInfo orgInfo)
	{
		OrganizationMemberItem orgMemberConfig = GetOrgMemberConfig(orgInfo);
		if (orgMemberConfig.DeputySpouseDowngrade < 0)
		{
			return;
		}
		HashSet<int> spouseIds = DomainManager.Character.GetRelatedCharIds(charId, 1024);
		foreach (int spouseId in spouseIds)
		{
			if (!DomainManager.Character.TryGetElement_Objects(spouseId, out var spouseChar))
			{
				continue;
			}
			OrganizationInfo spouseOrgInfo = spouseChar.GetOrganizationInfo();
			if (!spouseOrgInfo.Principal && spouseOrgInfo.SettlementId == orgInfo.SettlementId)
			{
				sbyte targetGrade = orgMemberConfig.DeputySpouseDowngrade;
				if (targetGrade < 0)
				{
					targetGrade = orgMemberConfig.GetRejoinGrade();
				}
				ChangeGrade(context, spouseChar, targetGrade, destPrincipal: true);
			}
		}
	}

	public void TryDowngradeDeputySpouse(DataContext context, int charId, OrganizationInfo charOrgInfo, int spouseId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(spouseId, out var spouseChar))
		{
			return;
		}
		OrganizationInfo spouseOrgInfo = spouseChar.GetOrganizationInfo();
		if (spouseOrgInfo.Principal)
		{
			return;
		}
		OrganizationMemberItem orgMemberConfig = GetOrgMemberConfig(charOrgInfo);
		if (spouseOrgInfo.SettlementId != charOrgInfo.SettlementId)
		{
			return;
		}
		if (spouseOrgInfo.Grade <= orgMemberConfig.DeputySpouseDowngrade)
		{
			ChangeGrade(context, spouseChar, spouseOrgInfo.Grade, destPrincipal: true);
			return;
		}
		sbyte targetGrade = orgMemberConfig.DeputySpouseDowngrade;
		if (targetGrade < 0)
		{
			targetGrade = orgMemberConfig.GetRejoinGrade();
		}
		ChangeGrade(context, spouseChar, targetGrade, destPrincipal: true);
	}

	private unsafe static (int, int, int) GetAgeStats(OrgMemberCollection members, List<int> ages)
	{
		byte* intPtr = stackalloc byte[12];
		// IL initblk instruction
		Unsafe.InitBlock(intPtr, 0, 12);
		int* counts = (int*)intPtr;
		List<int> charIds = new List<int>();
		members.GetAllMembers(charIds);
		int i = 0;
		for (int count = charIds.Count; i < count; i++)
		{
			int charId = charIds[i];
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			short age = character.GetCurrAge();
			sbyte ageGroup = AgeGroup.GetAgeGroup(age);
			counts[ageGroup]++;
			ages.Add(age);
		}
		return (*counts, counts[1], counts[2]);
	}

	public void BeginCreatingSettlements(IRandomSource randomSource)
	{
		List<short> villageNameIds = new List<short>();
		List<short> townNameIds = new List<short>();
		List<short> walledTownNameIds = new List<short>();
		LocalTownNames nameCollection = LocalTownNames.Instance;
		for (short i = nameCollection.VillageStart; i <= nameCollection.VillageEnd; i++)
		{
			villageNameIds.Add(nameCollection.TownNameCore[i].TemplateId);
		}
		for (short i2 = nameCollection.TownStart; i2 <= nameCollection.TownEnd; i2++)
		{
			townNameIds.Add(nameCollection.TownNameCore[i2].TemplateId);
		}
		for (short i3 = nameCollection.WalledTownStart; i3 <= nameCollection.WalledTownEnd; i3++)
		{
			walledTownNameIds.Add(nameCollection.TownNameCore[i3].TemplateId);
		}
		CollectionUtils.Shuffle(randomSource, villageNameIds);
		CollectionUtils.Shuffle(randomSource, townNameIds);
		CollectionUtils.Shuffle(randomSource, walledTownNameIds);
		_settlementCreatingInfo = new SettlementCreatingInfo(villageNameIds, townNameIds, walledTownNameIds);
	}

	public void EndCreatingSettlements(DataContext context)
	{
		ForceUpdateInfluencePowers(context);
		RecordSettlementStandardPopulations(context);
		DomainManager.World.RecordWorldStandardPopulation(context);
		DomainManager.World.UpdatePopulationRelatedData();
		_settlementCreatingInfo = null;
		_orgInscribedCharIdMap = null;
	}

	public bool IsCreatingSettlements()
	{
		return _settlementCreatingInfo != null;
	}

	public void CreateEmptySects(DataContext context)
	{
		short index = 0;
		foreach (OrganizationItem orgCfg in (IEnumerable<OrganizationItem>)Config.Organization.Instance)
		{
			if (orgCfg.IsSect)
			{
				short settlementId = GenerateNextSettlementId(context);
				Sect sect = new Sect(settlementId, new Location(-1, index), orgCfg.TemplateId, context.Random);
				AddElement_Sects(settlementId, sect);
				AddSettlementCache(sect);
				index++;
			}
		}
	}

	public short CreateSettlement(DataContext context, Location location, sbyte orgTemplateId)
	{
		short settlementId = GenerateNextSettlementId(context);
		if (IsSect(orgTemplateId))
		{
			Sect sect = new Sect(settlementId, location, orgTemplateId, context.Random);
			AddElement_Sects(settlementId, sect);
			SetLargeSectFavorabilities(_largeSectFavorabilities, context);
			AddSettlementCache(sect);
			CreateSettlementMembers(context, sect);
		}
		else
		{
			CivilianSettlement civilianSettlement = new CivilianSettlement(settlementId, location, orgTemplateId, _settlementCreatingInfo, context.Random);
			AddElement_CivilianSettlements(settlementId, civilianSettlement);
			AddSettlementCache(civilianSettlement);
			CreateSettlementMembers(context, civilianSettlement);
		}
		return settlementId;
	}

	[DomainMethod]
	public void SetInscribedCharactersForCreation(DataContext context, List<InscribedCharacterKey> inscribedCharList, List<short> ages = null)
	{
		_orgInscribedCharIdMap = new Dictionary<sbyte, List<InscribedCharacter>>();
		if (inscribedCharList != null && inscribedCharList.Count > 0)
		{
			_pendingInscribedCharacterAchievement = true;
			IRandomSource random = context.Random;
			int totalCount = inscribedCharList.Count;
			List<(InscribedCharacterKey, short)> inscribedCharsForCreation = new List<(InscribedCharacterKey, short)>(totalCount);
			for (int i = 0; i < totalCount; i++)
			{
				short age = (short)((ages != null && ages.Count > i) ? ages[i] : (-1));
				inscribedCharsForCreation.Add((inscribedCharList[i], age));
			}
			if (1 == 0)
			{
			}
			int num = totalCount switch
			{
				1 => random.Next(2), 
				2 => 1, 
				_ => totalCount / 3, 
			};
			if (1 == 0)
			{
			}
			int civilianCount = num;
			CollectionUtils.Shuffle(random, inscribedCharsForCreation);
			Logger.Info($"Inscribed Character to settlements: {civilianCount} civilians / {totalCount - civilianCount} sect members");
			for (int j = 0; j < civilianCount; j++)
			{
				InscribedCharacterKey inscribedCharKey = inscribedCharsForCreation[j].Item1;
				InscribedCharacter inscribedChar = GetInscribedCharWithAge(inscribedCharKey, inscribedCharsForCreation[j].Item2);
				sbyte orgTemplateId = (sbyte)(21 + random.Next(15));
				AddOrgInscribedCharacter(orgTemplateId, inscribedChar);
			}
			for (int k = civilianCount; k < totalCount; k++)
			{
				InscribedCharacterKey inscribedCharKey2 = inscribedCharsForCreation[k].Item1;
				InscribedCharacter inscribedChar2 = GetInscribedCharWithAge(inscribedCharKey2, inscribedCharsForCreation[k].Item2);
				sbyte orgTemplateId2 = GetBestMatchingOrgTemplateId(random, inscribedChar2.Gender, inscribedChar2.BaseCombatSkillQualifications, inscribedChar2.BaseLifeSkillQualifications);
				AddOrgInscribedCharacter(orgTemplateId2, inscribedChar2);
			}
		}
		static void AddOrgInscribedCharacter(sbyte key, InscribedCharacter inscribedCharacter)
		{
			if (!_orgInscribedCharIdMap.TryGetValue(key, out var charList))
			{
				charList = new List<InscribedCharacter>();
				_orgInscribedCharIdMap.Add(key, charList);
			}
			charList.Add(inscribedCharacter);
		}
		static InscribedCharacter GetInscribedCharWithAge(InscribedCharacterKey key, short num2)
		{
			InscribedCharacter original = DomainManager.Global.GetElement_InscribedCharacters(key);
			if (original == null)
			{
				return null;
			}
			if (num2 >= 0)
			{
				return new InscribedCharacter(original)
				{
					CurrAge = num2,
					ActualAge = num2
				};
			}
			return original;
		}
	}

	private sbyte GetBestMatchingOrgTemplateId(IRandomSource random, sbyte gender, CombatSkillShorts combatSkillQualifications, LifeSkillShorts lifeSkillQualifications)
	{
		int bestScore = int.MinValue;
		Span<sbyte> span = stackalloc sbyte[15];
		SpanList<sbyte> bestScoreSectIds = span;
		foreach (OrganizationItem orgConfig in (IEnumerable<OrganizationItem>)Config.Organization.Instance)
		{
			if (!orgConfig.IsSect || (orgConfig.GenderRestriction != -1 && orgConfig.GenderRestriction != gender))
			{
				continue;
			}
			OrganizationMemberItem highestOrgMemberConfig = GetOrgMemberConfig(orgConfig.TemplateId, 8);
			int score = 0;
			for (sbyte combatSkillType = 0; combatSkillType < 14; combatSkillType++)
			{
				short adjust = highestOrgMemberConfig.CombatSkillsAdjust[combatSkillType];
				if (adjust >= 0)
				{
					score += combatSkillQualifications[combatSkillType] * adjust * 3;
				}
			}
			for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
			{
				short adjust2 = highestOrgMemberConfig.LifeSkillsAdjust[lifeSkillType];
				if (adjust2 >= 0)
				{
					score += lifeSkillQualifications[lifeSkillType] * adjust2;
				}
			}
			if (score > bestScore)
			{
				bestScoreSectIds.Clear();
				bestScoreSectIds.Add(orgConfig.TemplateId);
				bestScore = score;
			}
			else if (score == bestScore)
			{
				bestScoreSectIds.Add(orgConfig.TemplateId);
			}
		}
		return bestScoreSectIds.GetRandom(random);
	}

	private short GenerateNextSettlementId(DataContext context)
	{
		short settlementId = _nextSettlementId;
		_nextSettlementId++;
		if ((ushort)_nextSettlementId > 32767)
		{
			_nextSettlementId = 0;
		}
		SetNextSettlementId(_nextSettlementId, context);
		return settlementId;
	}

	private static void CreateSettlementMembers(DataContext context, Settlement settlement)
	{
		sbyte orgTemplateId = settlement.GetOrgTemplateId();
		short settlementId = settlement.GetId();
		Location location = settlement.GetLocation();
		OrgMemberCollection members = settlement.GetMembers();
		if (_orgInscribedCharIdMap.TryGetValue(orgTemplateId, out var charList))
		{
			if (_stringBuilder == null)
			{
				_stringBuilder = new StringBuilder();
			}
			_stringBuilder.Clear();
			_stringBuilder.Append("Creating inscribed characters at ");
			_stringBuilder.AppendLine(settlement.GetNameRelatedData().GetName());
			foreach (InscribedCharacter inscribedChar in charList)
			{
				OrganizationInfo targetOrgInfo = GetInscribedCharTargetOrgInfo(context.Random, inscribedChar, settlement);
				GameData.Domains.Character.Character character = DomainManager.Character.CreateIntelligentCharacterFromInscription(context, inscribedChar, targetOrgInfo);
				DomainManager.Character.CompleteCreatingCharacter(character.GetId());
				_stringBuilder.Append('\t');
				_stringBuilder.AppendLine(character.ToString());
			}
			Logger.Info(_stringBuilder.ToString());
		}
		OrganizationItem orgConfig = Config.Organization.Instance[orgTemplateId];
		if (orgConfig.Population <= 0)
		{
			return;
		}
		sbyte mapStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
		if (mapStateTemplateId <= 0)
		{
			mapStateTemplateId = DomainManager.World.GetTaiwuVillageStateTemplateId();
		}
		List<short> blockIds = new List<short>();
		DomainManager.Map.GetSettlementBlocks(location.AreaId, location.BlockId, blockIds);
		List<short> nearbyBlockIds = new List<short>();
		DomainManager.Map.GetSettlementBlocksAndAffiliatedBlocks(location.AreaId, location.BlockId, nearbyBlockIds);
		SettlementMembersCreationInfo info = new SettlementMembersCreationInfo(orgTemplateId, settlementId, mapStateTemplateId, location.AreaId, blockIds, nearbyBlockIds);
		int worldPopulationFactor = DomainManager.World.GetWorldPopulationFactor();
		sbyte maxGrade = (sbyte)((orgTemplateId != 16) ? 8 : 7);
		for (sbyte grade = maxGrade; grade >= 0; grade--)
		{
			short orgMemberId = orgConfig.Members[grade];
			OrganizationMemberItem orgMemberConfig = OrganizationMember.Instance[orgMemberId];
			if (orgMemberConfig.Amount > 0)
			{
				info.CoreMemberConfig = orgMemberConfig;
				HashSet<int> existingMembers = members.GetMembers(grade);
				int coreMembersAmount = orgMemberConfig.Amount;
				if (!orgMemberConfig.RestrictPrincipalAmount)
				{
					coreMembersAmount = Math.Max(1, coreMembersAmount * worldPopulationFactor / 125);
				}
				else if (existingMembers.Count > 0)
				{
					coreMembersAmount -= existingMembers.Count;
				}
				for (int i = 0; i < coreMembersAmount; i++)
				{
					CreateCoreCharacter(context, info);
					CreateBrothersAndSisters(context, info);
					CreateSpouseAndChildren(context, info);
					info.CompleteCreatingCharacters();
				}
			}
		}
	}

	private static OrganizationInfo GetInscribedCharTargetOrgInfo(IRandomSource random, InscribedCharacter inscribedChar, Settlement settlement)
	{
		OrgMemberCollection members = settlement.GetMembers();
		sbyte orgTemplateId = settlement.GetOrgTemplateId();
		bool isSect = settlement is Sect;
		sbyte mainAttrGrade = CharacterCreation.GetMainAttributeGrade(inscribedChar.BaseMainAttributes.GetSum());
		sbyte combatSkillGrade = CharacterCreation.GetCombatSkillQualificationGrade(inscribedChar.BaseCombatSkillQualifications.GetSum());
		sbyte lifeSkillGrade = CharacterCreation.GetLifeSkillQualificationGrade(inscribedChar.BaseLifeSkillQualifications.GetSum());
		sbyte grade = (sbyte)Math.Clamp((mainAttrGrade + combatSkillGrade + lifeSkillGrade) / 3, 0, 8);
		if (isSect)
		{
			for (grade = (sbyte)Math.Clamp(random.Next(grade - 2, grade + 1), 0, 8); grade >= 0; grade--)
			{
				OrganizationMemberItem orgMemberCfg = GetOrgMemberConfig(orgTemplateId, grade);
				if ((!orgMemberCfg.RestrictPrincipalAmount || members.GetMembers(grade).Count < orgMemberCfg.Amount) && (orgMemberCfg.Gender == -1 || orgMemberCfg.Gender == inscribedChar.Gender))
				{
					break;
				}
			}
		}
		else
		{
			OrganizationMemberItem orgMemberCfg2 = GetOrgMemberConfig(orgTemplateId, grade);
			if (orgMemberCfg2.RestrictPrincipalAmount && members.GetMembers(grade).Count >= orgMemberCfg2.Amount)
			{
				grade = Math.Max(0, orgMemberCfg2.ChildGrade.GetRandom(random));
			}
			else if (orgMemberCfg2.Gender != -1 && orgMemberCfg2.Gender != inscribedChar.Gender)
			{
				grade = 0;
			}
		}
		return new OrganizationInfo(orgTemplateId, grade, principal: true, settlement.GetId());
	}

	public static void CreateCoreCharacter(DataContext context, SettlementMembersCreationInfo info)
	{
		IRandomSource random = context.Random;
		Genome.CreateRandom(random, ref info.CoreMotherGenome);
		Genome.CreateRandom(random, ref info.CoreFatherGenome);
		sbyte gender = ((info.CoreMemberConfig.Gender == -1) ? Gender.GetRandom(random) : info.CoreMemberConfig.Gender);
		short charTemplateId = GetCharacterTemplateId(info.OrgTemplateId, info.MapStateTemplateId, gender);
		short initialAge = GetInitialAge(info.CoreMemberConfig);
		short age;
		if (initialAge >= 0)
		{
			int variationRange = initialAge / 4;
			age = (short)(initialAge + random.Next(-variationRange, variationRange + 1));
		}
		else
		{
			age = GameData.Domains.Character.Character.GenerateRandomAge(random);
		}
		short mapBlockId = (info.CoreMemberConfig.CanStroll ? info.NearbyBlockIds[random.Next(info.NearbyBlockIds.Count)] : info.BlockIds[random.Next(info.BlockIds.Count)]);
		sbyte grade = (sbyte)((info.OrgTemplateId != 16) ? info.CoreMemberConfig.Grade : 0);
		IntelligentCharacterCreationInfo intelligentCharacterCreationInfo = new IntelligentCharacterCreationInfo(orgInfo: new OrganizationInfo(info.OrgTemplateId, grade, principal: true, info.SettlementId), location: new Location(info.AreaId, mapBlockId), charTemplateId: charTemplateId);
		intelligentCharacterCreationInfo.Age = age;
		intelligentCharacterCreationInfo.SpecifyGenome = true;
		IntelligentCharacterCreationInfo charCreationInfo = intelligentCharacterCreationInfo;
		Genome.Inherit(random, ref info.CoreMotherGenome, ref info.CoreFatherGenome, ref charCreationInfo.Genome);
		GameData.Domains.Character.Character coreChar = DomainManager.Character.CreateIntelligentCharacter(context, ref charCreationInfo);
		int charId = coreChar.GetId();
		info.CreatedCharIds.Add(charId);
		bool isInfertile = coreChar.GetFertility() <= 0;
		if (age >= 16 && !isInfertile && random.CheckPercentProb(10))
		{
			coreChar.LoseVirginity(context);
		}
		info.CoreCharId = charId;
		info.CoreChar = coreChar;
		info.IsCoreCharInfertile = isInfertile;
		if (coreChar.GetGender() == 0)
		{
			info.CoreMotherAvatar = coreChar.GetAvatar();
			info.CoreFatherAvatar = new AvatarData(info.CoreMotherAvatar);
			info.CoreFatherAvatar.ChangeGender(1);
			info.CoreFatherAvatar.ChangeBodyType(BodyType.GetRandom(random));
		}
		else
		{
			info.CoreFatherAvatar = coreChar.GetAvatar();
			info.CoreMotherAvatar = new AvatarData(info.CoreFatherAvatar);
			info.CoreMotherAvatar.ChangeGender(0);
			info.CoreMotherAvatar.ChangeBodyType(BodyType.GetRandom(random));
		}
	}

	private unsafe static void CreateBrothersAndSisters(DataContext context, SettlementMembersCreationInfo info)
	{
		IRandomSource random = context.Random;
		int brothersAndSistersCount = RedzenHelper.NormalDistribute(random, 1f, 1f, 1, 3);
		if (info.OrgTemplateId == 16)
		{
			brothersAndSistersCount = Math.Min(brothersAndSistersCount, 2);
		}
		sbyte brotherGrade = info.CoreMemberConfig.BrotherGrade;
		short orgMemberId = Config.Organization.Instance[info.OrgTemplateId].Members[brotherGrade];
		OrganizationMemberItem orgMemberConfig = OrganizationMember.Instance[orgMemberId];
		(int, int, ushort)* pBrothersAndSistersInfo = stackalloc(int, int, ushort)[brothersAndSistersCount];
		Unsafe.Write(pBrothersAndSistersInfo, (info.CoreCharId, info.CoreChar.GetBirthDate(), (ushort)4));
		FullName coreCharFullName = info.CoreChar.GetFullName();
		short currAge = info.CoreChar.GetCurrAge();
		for (int i = 1; i < brothersAndSistersCount; i++)
		{
			currAge += (short)(1 + random.Next(2));
			sbyte gender = ((orgMemberConfig.Gender == -1) ? Gender.GetRandom(random) : orgMemberConfig.Gender);
			short charTemplateId = GetCharacterTemplateId(info.OrgTemplateId, info.MapStateTemplateId, gender);
			ushort relationType = (ushort)(random.CheckPercentProb(75) ? 4 : 512);
			short mapBlockId = (orgMemberConfig.CanStroll ? info.NearbyBlockIds[random.Next(info.NearbyBlockIds.Count)] : info.BlockIds[random.Next(info.BlockIds.Count)]);
			IntelligentCharacterCreationInfo intelligentCharacterCreationInfo = new IntelligentCharacterCreationInfo(orgInfo: new OrganizationInfo(info.OrgTemplateId, brotherGrade, principal: true, info.SettlementId), location: new Location(info.AreaId, mapBlockId), charTemplateId: charTemplateId);
			intelligentCharacterCreationInfo.Age = currAge;
			IntelligentCharacterCreationInfo charCreationInfo = intelligentCharacterCreationInfo;
			if (relationType == 4)
			{
				charCreationInfo.Avatar = AvatarManager.Instance.GetRandomAvatar(random, gender, transgender: false, -1, info.CoreFatherAvatar, info.CoreMotherAvatar);
				charCreationInfo.BaseAttraction = charCreationInfo.Avatar.GetBaseCharm();
				charCreationInfo.SpecifyGenome = true;
				Genome.Inherit(random, ref info.CoreMotherGenome, ref info.CoreFatherGenome, ref charCreationInfo.Genome);
				charCreationInfo.ReferenceFullName = coreCharFullName;
			}
			GameData.Domains.Character.Character character = DomainManager.Character.CreateIntelligentCharacter(context, ref charCreationInfo);
			int charId = character.GetId();
			info.CreatedCharIds.Add(charId);
			if (currAge >= 16 && random.CheckPercentProb(10) && character.GetFertility() > 0)
			{
				character.LoseVirginity(context);
			}
			Unsafe.Write(pBrothersAndSistersInfo + i, (charId, character.GetBirthDate(), relationType));
		}
		for (int j = 0; j < brothersAndSistersCount; j++)
		{
			(int, int, ushort) tuple = pBrothersAndSistersInfo[j];
			int youngerCharId = tuple.Item1;
			int youngerBirthDate = tuple.Item2;
			ushort youngerRelationType = tuple.Item3;
			for (int k = j + 1; k < brothersAndSistersCount; k++)
			{
				(int, int, ushort) tuple2 = pBrothersAndSistersInfo[k];
				int elderCharId = tuple2.Item1;
				ushort elderRelationType = tuple2.Item3;
				ushort relationType2 = (ushort)((youngerRelationType == 4 && elderRelationType == 4) ? 4 : 512);
				DomainManager.Character.AddRelation(context, youngerCharId, elderCharId, relationType2, youngerBirthDate);
			}
		}
	}

	private static void CreateSpouseAndChildren(DataContext context, SettlementMembersCreationInfo info)
	{
		OrganizationMemberItem coreMemberConfig = info.CoreMemberConfig;
		if (coreMemberConfig == null)
		{
			return;
		}
		sbyte[] childGrade = coreMemberConfig.ChildGrade;
		if (childGrade == null || childGrade.Length <= 0 || info.CoreChar.GetMonkType() != 0)
		{
			return;
		}
		IRandomSource random = context.Random;
		int marriageRate = Math.Min((info.CoreChar.GetCurrAge() - 20) * 10, 90);
		if (random.CheckPercentProb(marriageRate))
		{
			bool isTaiwuVillage = info.OrgTemplateId == 16;
			CreateSpouse(context, info);
			if (!isTaiwuVillage && random.CheckPercentProb(10))
			{
				CreateLover(context, info);
			}
			short coreCharFertility = info.CoreChar.GetFertility();
			short spouseCharFertility = info.SpouseChar.GetFertility();
			if (coreCharFertility > 0 && spouseCharFertility > 0 && coreCharFertility * spouseCharFertility > random.Next(20000))
			{
				info.CoreChar.LoseVirginity(context);
				info.SpouseChar.LoseVirginity(context);
				CreateChildren(context, info, isBloodChildren: true);
			}
			else if (!isTaiwuVillage && random.CheckPercentProb((info.CoreChar.GetCurrAge() - 40) * 2))
			{
				CreateChildren(context, info, isBloodChildren: false);
			}
		}
		else if (random.CheckPercentProb(25))
		{
			CreateLover(context, info);
		}
	}

	private static void CreateSpouse(DataContext context, SettlementMembersCreationInfo info)
	{
		IRandomSource random = context.Random;
		sbyte grade = (sbyte)((info.OrgTemplateId != 16) ? info.CoreChar.GetOrganizationInfo().Grade : 0);
		sbyte gender = Gender.Flip(info.CoreChar.GetGender());
		short charTemplateId = GetCharacterTemplateId(info.OrgTemplateId, info.MapStateTemplateId, gender);
		short age = (short)Math.Max(info.CoreChar.GetCurrAge() + ((gender != 0) ? 1 : (-1)) * random.Next(16), 16);
		short mapBlockId = (info.CoreMemberConfig.CanStroll ? info.NearbyBlockIds[random.Next(info.NearbyBlockIds.Count)] : info.BlockIds[random.Next(info.BlockIds.Count)]);
		IntelligentCharacterCreationInfo intelligentCharacterCreationInfo = new IntelligentCharacterCreationInfo(orgInfo: new OrganizationInfo(info.OrgTemplateId, grade, info.CoreMemberConfig.DeputySpouseDowngrade < 0, info.SettlementId), location: new Location(info.AreaId, mapBlockId), charTemplateId: charTemplateId);
		intelligentCharacterCreationInfo.Age = age;
		IntelligentCharacterCreationInfo charCreationInfo = intelligentCharacterCreationInfo;
		GameData.Domains.Character.Character character = DomainManager.Character.CreateIntelligentCharacter(context, ref charCreationInfo);
		int charId = character.GetId();
		info.CreatedCharIds.Add(charId);
		GameData.Domains.Character.Character wife = ((gender == 0) ? character : info.CoreChar);
		int marriageDate = wife.GetBirthDate() + 192;
		if (!RelationTypeHelper.AllowAddingHusbandOrWifeRelation(info.CoreCharId, charId))
		{
			throw new Exception($"Failed to add husband or wife relation: {info.CoreCharId} - {charId}");
		}
		DomainManager.Character.AddRelation(context, info.CoreCharId, charId, 1024, marriageDate);
		if (context.Random.NextBool())
		{
			DomainManager.Character.ChangeRelationType(context, info.CoreCharId, charId, 0, 16384);
		}
		if (context.Random.NextBool())
		{
			DomainManager.Character.ChangeRelationType(context, charId, info.CoreCharId, 0, 16384);
		}
		if (!info.IsCoreCharInfertile && random.CheckPercentProb(75) && character.GetFertility() > 0)
		{
			info.CoreChar.LoseVirginity(context);
			character.LoseVirginity(context);
			if (random.CheckPercentProb(10))
			{
				GameData.Domains.Character.Character husband = ((gender == 1) ? character : info.CoreChar);
				GameData.Domains.Character.Character.GetMakeLoveRole(context.Random, ref husband, ref wife);
				wife.AddFeature(context, 198);
				DomainManager.Character.CreatePregnantState(context, wife, husband, isRaped: false);
			}
		}
		info.SpouseCharId = charId;
		info.SpouseChar = character;
	}

	private static void CreateLover(DataContext context, SettlementMembersCreationInfo info)
	{
		IRandomSource random = context.Random;
		sbyte grade = info.CoreMemberConfig.BrotherGrade;
		sbyte gender = Gender.Flip(info.CoreChar.GetGender());
		short charTemplateId = GetCharacterTemplateId(info.OrgTemplateId, info.MapStateTemplateId, gender);
		short age = (short)Math.Max(info.CoreChar.GetCurrAge() + ((gender != 0) ? 1 : (-1)) * random.Next(16), 16);
		short orgMemberId = Config.Organization.Instance[info.OrgTemplateId].Members[grade];
		OrganizationMemberItem orgMemberConfig = OrganizationMember.Instance[orgMemberId];
		short mapBlockId = (orgMemberConfig.CanStroll ? info.NearbyBlockIds[random.Next(info.NearbyBlockIds.Count)] : info.BlockIds[random.Next(info.BlockIds.Count)]);
		IntelligentCharacterCreationInfo intelligentCharacterCreationInfo = new IntelligentCharacterCreationInfo(orgInfo: new OrganizationInfo(info.OrgTemplateId, grade, principal: true, info.SettlementId), location: new Location(info.AreaId, mapBlockId), charTemplateId: charTemplateId);
		intelligentCharacterCreationInfo.Age = age;
		IntelligentCharacterCreationInfo charCreationInfo = intelligentCharacterCreationInfo;
		GameData.Domains.Character.Character character = DomainManager.Character.CreateIntelligentCharacter(context, ref charCreationInfo);
		int charId = character.GetId();
		info.CreatedCharIds.Add(charId);
		if (random.CheckPercentProb(50))
		{
			if (!RelationTypeHelper.AllowAddingAdoredRelation(info.CoreCharId, charId))
			{
				throw new Exception($"Failed to add adored relation: {info.CoreCharId} - {charId}");
			}
			DomainManager.Character.AddRelation(context, info.CoreCharId, charId, 16384);
			if (!RelationTypeHelper.AllowAddingAdoredRelation(charId, info.CoreCharId))
			{
				throw new Exception($"Failed to add adored relation: {charId} - {info.CoreCharId}");
			}
			DomainManager.Character.AddRelation(context, charId, info.CoreCharId, 16384);
			if (!info.IsCoreCharInfertile && random.CheckPercentProb(20) && character.GetFertility() > 0)
			{
				info.CoreChar.LoseVirginity(context);
				character.LoseVirginity(context);
			}
		}
		else
		{
			if (!RelationTypeHelper.AllowAddingAdoredRelation(info.CoreCharId, charId))
			{
				throw new Exception($"Failed to add adored relation: {info.CoreCharId} - {charId}");
			}
			DomainManager.Character.AddRelation(context, info.CoreCharId, charId, 16384);
		}
	}

	private static void CreateChildren(DataContext context, SettlementMembersCreationInfo info, bool isBloodChildren)
	{
		IRandomSource random = context.Random;
		int fatherId;
		GameData.Domains.Character.Character father;
		int motherId;
		GameData.Domains.Character.Character mother;
		short motherAge;
		if (info.CoreChar.GetGender() == 1)
		{
			fatherId = info.CoreCharId;
			father = info.CoreChar;
			motherId = info.SpouseCharId;
			mother = info.SpouseChar;
			motherAge = info.SpouseChar.GetCurrAge();
		}
		else
		{
			fatherId = info.SpouseCharId;
			father = info.SpouseChar;
			motherId = info.CoreCharId;
			mother = info.CoreChar;
			motherAge = info.CoreChar.GetCurrAge();
		}
		sbyte grade = info.CoreMemberConfig.ChildGrade.GetRandom(context.Random);
		short orgMemberId = Config.Organization.Instance[info.OrgTemplateId].Members[grade];
		OrganizationMemberItem orgMemberConfig = OrganizationMember.Instance[orgMemberId];
		sbyte orgMemberGender = orgMemberConfig.Gender;
		int motherAgeAtFirstChildBirthMin = 17;
		int motherAgeAtFirstChildBirthMax = Math.Min(GlobalConfig.Instance.MaxAgeOfCreatingChar + 1, motherAge);
		if (motherAgeAtFirstChildBirthMin > motherAgeAtFirstChildBirthMax)
		{
			return;
		}
		int childAge = motherAge - random.Next(motherAgeAtFirstChildBirthMin, motherAgeAtFirstChildBirthMax + 1);
		int childrenCount = RedzenHelper.NormalDistribute(random, 1f, 1f, 1, 3);
		for (int i = 0; i < childrenCount; i++)
		{
			int motherAgeAtChildBirth = motherAge - childAge;
			if (motherAgeAtChildBirth >= motherAgeAtFirstChildBirthMin && childAge >= 0)
			{
				sbyte gender = ((orgMemberGender == -1) ? Gender.GetRandom(random) : orgMemberGender);
				short charTemplateId = GetCharacterTemplateId(info.OrgTemplateId, info.MapStateTemplateId, gender);
				IntelligentCharacterCreationInfo intelligentCharacterCreationInfo = new IntelligentCharacterCreationInfo(orgInfo: new OrganizationInfo(info.OrgTemplateId, grade, principal: true, info.SettlementId), location: mother.GetLocation(), charTemplateId: charTemplateId);
				intelligentCharacterCreationInfo.GrowingSectGrade = info.CoreMemberConfig.Grade;
				intelligentCharacterCreationInfo.Age = (short)childAge;
				IntelligentCharacterCreationInfo charCreationInfo = intelligentCharacterCreationInfo;
				if (isBloodChildren)
				{
					charCreationInfo.MotherCharId = motherId;
					charCreationInfo.Mother = mother;
					charCreationInfo.FatherCharId = fatherId;
					charCreationInfo.ActualFatherCharId = fatherId;
					charCreationInfo.Father = father;
					charCreationInfo.ActualFather = father;
				}
				GameData.Domains.Character.Character character = DomainManager.Character.CreateIntelligentCharacter(context, ref charCreationInfo);
				int charId = character.GetId();
				info.CreatedCharIds.Add(charId);
				int birthDate = character.GetBirthDate();
				if (isBloodChildren)
				{
					if (!RelationTypeHelper.AllowAddingBloodParentRelation(charId, fatherId))
					{
						throw new Exception($"Failed to add blood parent relation: {charId} - {fatherId}");
					}
					if (!RelationTypeHelper.AllowAddingBloodParentRelation(charId, motherId))
					{
						throw new Exception($"Failed to add blood parent relation: {charId} - {motherId}");
					}
					DomainManager.Character.AddBloodParentRelations(context, charId, fatherId, birthDate);
					DomainManager.Character.AddBloodParentRelations(context, charId, motherId, birthDate);
				}
				else
				{
					if (!RelationTypeHelper.AllowAddingAdoptiveParentRelation(charId, fatherId))
					{
						throw new Exception($"Failed to add adoptive parent relation: {charId} - {fatherId}");
					}
					if (!RelationTypeHelper.AllowAddingAdoptiveParentRelation(charId, motherId))
					{
						throw new Exception($"Failed to add adoptive parent relation: {charId} - {motherId}");
					}
					DomainManager.Character.AddAdoptiveParentRelations(context, charId, fatherId, birthDate);
					DomainManager.Character.AddAdoptiveParentRelations(context, charId, motherId, birthDate);
				}
			}
			childAge -= 1 + random.Next(2);
		}
	}

	[DomainMethod]
	public SettlementDisplayData GetDisplayData(short settlementId)
	{
		Settlement settlement = _settlements[settlementId];
		SettlementDisplayData data = default(SettlementDisplayData);
		(int, int) population = settlement.GetPopulationInfo();
		data.SettlementId = settlementId;
		data.Culture = settlement.GetCulture();
		data.MaxCulture = settlement.GetMaxCulture();
		data.Safety = settlement.GetSafety();
		data.MaxSafety = settlement.GetMaxSafety();
		data.Population = population.Item1;
		data.MaxPopulation = population.Item2;
		data.SettlementNameRelatedData = settlement.GetNameRelatedData();
		data.OrgTemplateId = settlement.GetOrgTemplateId();
		data.AreaTemplateId = DomainManager.Map.GetElement_Areas(settlement.GetLocation().AreaId).GetTemplateId();
		data.InfluencePowerUpdateDate = settlement.GetInfluencePowerUpdateDate();
		data.ApprovingRate = settlement.CalcApprovingRate();
		data.ApprovingRateUpperLimit = settlement.GetApprovingRateUpperLimit();
		sbyte orgTemplateId = data.OrgTemplateId;
		data.IsInfluencePowerUpdatePaused = orgTemplateId >= 1 && orgTemplateId == 15 && DomainManager.Organization.PauseUpdateInfluencePower;
		return data;
	}

	[DomainMethod]
	public SettlementPopulationDisplayData GetSettlementPopulationDisplayData(short settlementId)
	{
		Settlement settlement = _settlements[settlementId];
		SettlementPopulationDisplayData data = new SettlementPopulationDisplayData();
		List<int> memberCharIdList = new List<int>();
		settlement.GetMembers().GetAllMembers(memberCharIdList);
		int manCount = 0;
		int womanCount = 0;
		int boyCount = 0;
		int girlCount = 0;
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		for (int i = 0; i < memberCharIdList.Count; i++)
		{
			if (DomainManager.Character.TryGetElement_Objects(memberCharIdList[i], out var character) && character.GetId() != taiwuCharId)
			{
				sbyte gender = character.GetGender();
				bool adult = character.GetAgeGroup() >= 2;
				if (adult && gender == 1)
				{
					manCount++;
				}
				else if (adult && gender == 0)
				{
					womanCount++;
				}
				else if (!adult && gender == 1)
				{
					boyCount++;
				}
				else if (!adult && gender == 0)
				{
					girlCount++;
				}
			}
		}
		data.BoyCount = boyCount;
		data.GirlCount = girlCount;
		data.ManCount = manCount;
		data.WomanCount = womanCount;
		return data;
	}

	[DomainMethod]
	public List<SettlementNameRelatedData> GetSettlementNameRelatedData(List<short> settlementIds)
	{
		int settlementsCount = settlementIds.Count;
		List<SettlementNameRelatedData> data = new List<SettlementNameRelatedData>(settlementsCount);
		for (int i = 0; i < settlementsCount; i++)
		{
			if (settlementIds[i] < 0)
			{
				data.Add(new SettlementNameRelatedData(-1, -1));
				continue;
			}
			Settlement settlement = _settlements[settlementIds[i]];
			data.Add(settlement.GetNameRelatedData());
		}
		return data;
	}

	[DomainMethod]
	public List<CharacterDisplayData> GetSettlementMembers(short settlementId)
	{
		Settlement settlement = _settlements[settlementId];
		List<int> chars = new List<int>();
		settlement.GetMembers().GetAllMembers(chars);
		return DomainManager.Character.GetCharacterDisplayDataList(chars);
	}

	public OrganizationMemberDisplayDataForGeneralScrollList GetOrganizationMemberDisplayDataForGeneralScrollList(DataContext context, int charId)
	{
		SectCharacter sectChar;
		return new OrganizationMemberDisplayDataForGeneralScrollList
		{
			ApprovingState = (TryGetElement_SectCharacters(charId, out sectChar) ? ((!ProfessionSkillHandle.DukeSkill_CheckCharacterHasTitle(charId)) ? EApprovingState.ApproveDirectly : EApprovingState.Duke) : EApprovingState.None),
			ApprovingRate = (sectChar?.GetApprovingRate() ?? 0),
			InfluencePower = (sectChar?.GetInfluencePower() ?? 0),
			CharacterDisplayDataForGeneralScrollList = DomainManager.Character.GetCharacterDisplayDataForGeneralScrollList(context, charId)
		};
	}

	[DomainMethod]
	public OrganizationMemberDisplayDataForGeneralScrollList[] GetSettlementApproveTaiwuMembers(DataContext context, short settlementId)
	{
		return (from charId in _settlements[settlementId].GetMembers()
			select GetOrganizationMemberDisplayDataForGeneralScrollList(context, charId) into sectChar
			where sectChar.ApprovingState != EApprovingState.None
			orderby sectChar.ApprovingState descending, sectChar.ApprovingRate descending, sectChar.CharacterDisplayDataForGeneralScrollList.CharacterId
			select sectChar).ToArray();
	}

	[DomainMethod]
	public OrganizationCombatSkillsDisplayData GetOrganizationCombatSkillsDisplayData(sbyte organizationTemplateId)
	{
		OrganizationCombatSkillsDisplayData data = new OrganizationCombatSkillsDisplayData();
		data.OrganizationTemplateId = organizationTemplateId;
		Settlement settlement = GetSettlementByOrgTemplateId(organizationTemplateId);
		data.ApprovingRate = settlement.CalcApprovingRate();
		data.ApprovingRateTotal = settlement.CalcApprovingRateTotal();
		data.ApprovingRateUpperLimit = GetApprovingRateUpperLimit();
		data.ApprovingRateUpperLimitBonus = (short)(settlement.GetApprovingRateUpperLimitBonus() + settlement.GetApprovingRateUpperLimitTempBonus());
		int currDate = DomainManager.World.GetCurrDate();
		int maxDuration = 0;
		bool found = false;
		foreach (MaxApprovingRateTempBonus bonus in _maxApprovingRateTemporaryBonus)
		{
			if (bonus.SettlementId == settlement.GetId())
			{
				int remaining = bonus.ExpireDate - currDate;
				if (!found || remaining > maxDuration)
				{
					maxDuration = remaining;
					found = true;
				}
			}
		}
		data.Duration = (found ? maxDuration : 0);
		List<short> taiwuLearnedCombatSkillIdList = DomainManager.Taiwu.GetTaiwu().GetLearnedCombatSkills();
		List<short> organizationLearnedSkillIdList = new List<short>();
		for (int i = 0; i < taiwuLearnedCombatSkillIdList.Count; i++)
		{
			CombatSkillItem config = Config.CombatSkill.Instance[taiwuLearnedCombatSkillIdList[i]];
			if (config != null && config.SectId == organizationTemplateId)
			{
				organizationLearnedSkillIdList.Add(taiwuLearnedCombatSkillIdList[i]);
			}
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		data.LearnedSkills = DomainManager.CombatSkill.GetCombatSkillDisplayData(taiwuCharId, organizationLearnedSkillIdList);
		return data;
	}

	[DomainMethod]
	public int[] GetSectPreparationForMartialArtTournament(sbyte orgTemplateId)
	{
		Sect sect = (Sect)GetSettlementByOrgTemplateId(orgTemplateId);
		return sect.GetMartialArtTournamentPreparations();
	}

	[DomainMethod]
	public short GetMartialArtTournamentCurrentHostSettlementId()
	{
		return _currTournamentHost;
	}

	[DomainMethod]
	public short GetSettlementIdByAreaIdAndBlockId(short areaId, short blockId)
	{
		return DomainManager.Organization.GetSettlementByLocation(new Location(areaId, blockId)).GetId();
	}

	[DomainMethod]
	public ShortPair GetCultureByAreaIdAndBlockId(short areaId, short blockId)
	{
		short settlementId = DomainManager.Organization.GetSettlementByLocation(new Location(areaId, blockId)).GetId();
		Settlement settlement = _settlements[settlementId];
		return new ShortPair(settlement.GetCulture(), settlement.GetMaxCulture());
	}

	private void UpdateFactions(DataContext context, Settlement settlement)
	{
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		OrgMemberCollection orgMemberCollection = settlement.GetMembers();
		List<GameData.Domains.Character.Character> charsWithoutFaction = new List<GameData.Domains.Character.Character>();
		List<GameData.Domains.Character.Character> factionLeaders = new List<GameData.Domains.Character.Character>();
		for (sbyte grade = 0; grade < 9; grade++)
		{
			OrganizationMemberItem memberConfig = GetOrgMemberConfig(settlement.GetOrgTemplateId(), grade);
			if (!memberConfig.RestrictPrincipalAmount || memberConfig.Amount >= 2)
			{
				factionLeaders.Clear();
				charsWithoutFaction.Clear();
				GameData.Domains.Character.Character newFactionLeader = null;
				int maxInfluencePower = -1;
				HashSet<int> gradeMember = orgMemberCollection.GetMembers(grade);
				foreach (int charId in gradeMember)
				{
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
					if (!character.IsInteractableAsIntelligentCharacter())
					{
						continue;
					}
					int factionId = character.GetFactionId();
					if (factionId < 0)
					{
						charsWithoutFaction.Add(character);
					}
					else if (factionId == charId)
					{
						factionLeaders.Add(character);
					}
					else
					{
						RelatedCharacter relation = DomainManager.Character.GetRelation(charId, factionId);
						sbyte favorabilityType = FavorabilityType.GetFavorabilityType(relation.Favorability);
						sbyte priorityType = FactionLeaderPriorityType.GetFactionLeaderPriorityType(relation.RelationType);
						sbyte favorabilityReq = JoinFactionFavorabilityReq[priorityType];
						if (favorabilityType < favorabilityReq)
						{
							LeaveFaction(context, character, charIsDead: false);
						}
					}
					SettlementCharacter settlementCharacter = DomainManager.Organization.GetSettlementCharacter(charId);
					short influencePower = settlementCharacter.GetInfluencePower();
					if (influencePower > maxInfluencePower)
					{
						maxInfluencePower = influencePower;
						newFactionLeader = character;
					}
				}
				if (newFactionLeader != null && TryCreateFaction(context, newFactionLeader))
				{
					charsWithoutFaction.Remove(newFactionLeader);
					factionLeaders.Add(newFactionLeader);
				}
				foreach (GameData.Domains.Character.Character character2 in charsWithoutFaction)
				{
					(int factionId, bool succeed) tuple = OfflineJoinFaction(context, character2, factionLeaders);
					var (factionId2, _) = tuple;
					if (tuple.succeed)
					{
						lifeRecordCollection.AddJoinFaction(character2.GetId(), currDate, factionId2, character2.GetLocation());
						CharacterSet members = _factions[factionId2];
						character2.SetFactionId(factionId2, context);
						members.Add(character2.GetId());
						SetElement_Factions(factionId2, members, context);
					}
				}
			}
		}
	}

	public bool TryCreateFaction(DataContext context, GameData.Domains.Character.Character factionLeader)
	{
		int charId = factionLeader.GetId();
		int initialFactionId = factionLeader.GetFactionId();
		if (charId == initialFactionId)
		{
			return false;
		}
		if (!context.Random.CheckPercentProb(CreateFactionChance[factionLeader.GetBehaviorType()]))
		{
			return false;
		}
		if (initialFactionId >= 0)
		{
			LeaveFaction(context, factionLeader, charIsDead: false);
		}
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		monthlyNotifications.AddFactionUpgrade(charId, factionLeader.GetOrganizationInfo().SettlementId);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		lifeRecordCollection.AddCreateFaction(charId, currDate, factionLeader.GetLocation());
		AddElement_Factions(charId, default(CharacterSet), context);
		factionLeader.SetFactionId(charId, context);
		return true;
	}

	public void LeaveFaction(DataContext context, GameData.Domains.Character.Character character, bool charIsDead)
	{
		int factionId = character.GetFactionId();
		int currDate = DomainManager.World.GetCurrDate();
		DomainManager.LifeRecord.GetLifeRecordCollection().AddLeaveFaction(character.GetId(), currDate, factionId, character.GetLocation());
		CharacterSet factionMembers = _factions[factionId];
		factionMembers.Remove(character.GetId());
		if (!charIsDead)
		{
			character.SetFactionId(-1, context);
		}
		SetElement_Factions(factionId, factionMembers, context);
	}

	public void RemoveFaction(DataContext context, GameData.Domains.Character.Character factionLeader, bool leaderIsDead)
	{
		int factionId = factionLeader.GetId();
		if (!leaderIsDead)
		{
			factionLeader.SetFactionId(-1, context);
		}
		foreach (int charId in _factions[factionId].GetCollection())
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			character.SetFactionId(-1, context);
		}
		RemoveElement_Factions(factionId, context);
	}

	public void ExpandAllFactions(DataContext context)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		foreach (int factionId in _factions.Keys)
		{
			GameData.Domains.Character.Character leader = DomainManager.Character.GetElement_Objects(factionId);
			if (!leader.IsInteractableAsIntelligentCharacter())
			{
				continue;
			}
			var (newMemberId, succeed) = OfflineExpandFaction(context, leader);
			if (newMemberId >= 0)
			{
				if (succeed)
				{
					lifeRecordCollection.AddFactionRecruitSucceed(factionId, currDate, newMemberId, leader.GetLocation());
					CharacterSet members = _factions[factionId];
					members.Add(newMemberId);
					DomainManager.Character.GetElement_Objects(newMemberId).SetFactionId(factionId, context);
					SetElement_Factions(factionId, members, context);
				}
				else
				{
					lifeRecordCollection.AddFactionRecruitFail(factionId, currDate, newMemberId, leader.GetLocation());
				}
			}
		}
	}

	public (int newMemberId, bool succeed) OfflineExpandFaction(DataContext context, GameData.Domains.Character.Character factionLeader)
	{
		int leaderId = factionLeader.GetId();
		OrganizationInfo orgInfo = factionLeader.GetOrganizationInfo();
		Sect sect = _sects[orgInfo.SettlementId];
		OrgMemberCollection members = sect.GetMembers();
		HashSet<int> gradeMembers = members.GetMembers(orgInfo.Grade);
		if (gradeMembers.Count == 0)
		{
			return (newMemberId: -1, succeed: false);
		}
		if (!context.Random.CheckPercentProb(ExpandFactionChance[factionLeader.GetBehaviorType()]))
		{
			return (newMemberId: -1, succeed: false);
		}
		int maxPriority = int.MaxValue;
		int maxSuccessRate = int.MinValue;
		int selectedCharId = -1;
		foreach (int charId in gradeMembers)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			if (character.GetFactionId() >= 0 || !character.IsInteractableAsIntelligentCharacter() || !character.GetLocation().IsValid())
			{
				continue;
			}
			sbyte behaviorType = character.GetBehaviorType();
			RelatedCharacter relation = DomainManager.Character.GetRelation(charId, leaderId);
			ushort relationType = relation.RelationType;
			sbyte favorabilityType = FavorabilityType.GetFavorabilityType(relation.Favorability);
			sbyte priorityType = FactionLeaderPriorityType.GetFactionLeaderPriorityType(relationType);
			if (priorityType == -1)
			{
				continue;
			}
			sbyte favorabilityReq = JoinFactionFavorabilityReq[priorityType];
			if (favorabilityType < favorabilityReq)
			{
				continue;
			}
			sbyte priority = JoinFactionPriorities[behaviorType][priorityType];
			if (priority <= maxPriority)
			{
				int successRate = JoinFactionChance[behaviorType] + JoinFactionFavorabilityBonus[behaviorType] * (favorabilityType - favorabilityReq);
				if (successRate != 0 && (priority < maxPriority || maxSuccessRate < successRate))
				{
					maxPriority = priority;
					maxSuccessRate = successRate;
					selectedCharId = charId;
				}
			}
		}
		if (selectedCharId >= 0)
		{
			return (newMemberId: selectedCharId, succeed: context.Random.CheckPercentProb(maxSuccessRate));
		}
		return (newMemberId: -1, succeed: false);
	}

	public (int factionId, bool succeed) OfflineJoinFaction(DataContext context, GameData.Domains.Character.Character character, List<GameData.Domains.Character.Character> factionLeaders)
	{
		int charId = character.GetId();
		sbyte behaviorType = character.GetBehaviorType();
		int maxPriority = int.MaxValue;
		int maxSuccessRate = int.MinValue;
		int selectedCharId = -1;
		foreach (GameData.Domains.Character.Character factionLeader in factionLeaders)
		{
			int leaderId = factionLeader.GetId();
			RelatedCharacter relation = DomainManager.Character.GetRelation(charId, leaderId);
			ushort relationType = relation.RelationType;
			sbyte favorabilityType = FavorabilityType.GetFavorabilityType(relation.Favorability);
			sbyte priorityType = FactionLeaderPriorityType.GetFactionLeaderPriorityType(relationType);
			if (priorityType == -1)
			{
				continue;
			}
			sbyte favorabilityReq = JoinFactionFavorabilityReq[priorityType];
			if (favorabilityType < favorabilityReq)
			{
				continue;
			}
			sbyte priority = JoinFactionPriorities[behaviorType][priorityType];
			if (priority <= maxPriority)
			{
				int successRate = JoinFactionChance[behaviorType] + JoinFactionFavorabilityBonus[behaviorType] * (favorabilityType - favorabilityReq);
				if (successRate != 0 && (priority < maxPriority || maxSuccessRate < successRate))
				{
					maxPriority = priority;
					maxSuccessRate = successRate;
					selectedCharId = leaderId;
				}
			}
		}
		if (selectedCharId >= 0)
		{
			return (factionId: selectedCharId, succeed: context.Random.CheckPercentProb(maxSuccessRate));
		}
		return (factionId: -1, succeed: false);
	}

	public void Test_CheckFactions()
	{
		int totalMemberCount = 0;
		foreach (KeyValuePair<int, CharacterSet> faction in _factions)
		{
			faction.Deconstruct(out var key, out var value);
			int factionId = key;
			CharacterSet members = value;
			GameData.Domains.Character.Character leader = DomainManager.Character.GetElement_Objects(factionId);
			if (AgeGroup.GetAgeGroup(leader.GetCurrAge()) == 0)
			{
				throw new Exception($"(Test) Faction leader {factionId} cannot be a baby");
			}
			OrganizationInfo leaderOrgInfo = leader.GetOrganizationInfo();
			if (!IsSect(leaderOrgInfo.OrgTemplateId))
			{
				throw new Exception($"(Test) Faction {factionId} appeared in non-sect organization {Config.Organization.Instance[leaderOrgInfo.OrgTemplateId].Name}");
			}
			foreach (int member in members.GetCollection())
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(member);
				if (character.GetAgeGroup() == 0)
				{
					throw new Exception($"(Test) Faction member {member} cannot be a baby.");
				}
				OrganizationInfo memberOrgInfo = character.GetOrganizationInfo();
				if (memberOrgInfo.OrgTemplateId != leaderOrgInfo.OrgTemplateId)
				{
					throw new Exception($"(Test) Faction member {member} is in different faction from the leader {factionId}");
				}
				if (memberOrgInfo.Grade != leaderOrgInfo.Grade)
				{
					throw new Exception($"(Test) Faction member {member} is in different grade from the leader {factionId}");
				}
			}
			totalMemberCount += members.GetCount();
		}
		Logger.Info($"Faction Total Count: {_factions.Count}   Faction Member Total Count: {totalMemberCount}");
	}

	[DomainMethod]
	public void GmCmd_SetAllSettlementInformationVisited(DataContext context)
	{
		TaiwuDomain taiwuDomain = DomainManager.Taiwu;
		HashSet<short> visited = taiwuDomain.GetVisitedSettlements().ToHashSet();
		foreach (short sectId in _sects.Keys)
		{
			visited.Add(sectId);
		}
		foreach (short townId in _civilianSettlements.Keys)
		{
			visited.Add(townId);
		}
		taiwuDomain.SetVisitedSettlements(visited.ToList(), context);
	}

	[DomainMethod]
	public void GmCmd_SetAllSettlementMemberApprovedTaiwu(DataContext context, sbyte orgTemplateId, bool approvedTaiwu)
	{
		Settlement organization = GetSettlementByOrgTemplateId(orgTemplateId);
		OrgMemberCollection orgMembers = organization.GetMembers();
		for (sbyte grade = 0; grade <= 8; grade++)
		{
			HashSet<int> gradeMembers = orgMembers.GetMembers(grade);
			foreach (int gradeMemberId in gradeMembers)
			{
				SettlementCharacter settlementChar = GetSettlementCharacter(gradeMemberId);
				if (settlementChar.GetApprovedTaiwu() != approvedTaiwu)
				{
					settlementChar.SetApprovedTaiwu(context, approvedTaiwu);
				}
			}
		}
	}

	[DomainMethod]
	public List<CharacterDisplayData> GmCmd_GetSettlementPrisoner(DataContext context, int prisonType)
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return null;
		}
		MapBlockData taiwuBlockData = DomainManager.Map.GetBlockData(taiwuLocation.AreaId, taiwuLocation.BlockId);
		if (taiwuBlockData == null)
		{
			return null;
		}
		Settlement settlement = GetSettlementByLocation(taiwuBlockData.GetRootBlock().GetLocation());
		if (!(settlement is Sect sect))
		{
			return null;
		}
		if (sect == null)
		{
			return null;
		}
		return (PrisonType)prisonType switch
		{
			PrisonType.Low => DomainManager.Character.GetCharacterDisplayDataList((from x in sect.Prison.GetPrisonLow()
				select x.CharId).ToList()), 
			PrisonType.Mid => DomainManager.Character.GetCharacterDisplayDataList((from x in sect.Prison.GetPrisonMid()
				select x.CharId).ToList()), 
			PrisonType.High => DomainManager.Character.GetCharacterDisplayDataList((from x in sect.Prison.GetPrisonHigh()
				select x.CharId).ToList()), 
			PrisonType.Infected => DomainManager.Character.GetCharacterDisplayDataList((from x in sect.Prison.GetPrisonInfected()
				select x.CharId).ToList()), 
			_ => null, 
		};
	}

	[DomainMethod]
	public List<List<CharacterDisplayData>> GmCmd_GetAllFactionMembers()
	{
		CharacterDomain characterDomain = DomainManager.Character;
		List<int> memberList = new List<int>();
		List<List<CharacterDisplayData>> result = new List<List<CharacterDisplayData>>();
		foreach (KeyValuePair<int, CharacterSet> faction in _factions)
		{
			memberList.Clear();
			memberList.Add(faction.Key);
			memberList.AddRange(faction.Value.GetCollection());
			result.Add(characterDomain.GetCharacterDisplayDataList(memberList));
		}
		return result;
	}

	[DomainMethod]
	public void GmCmd_ForceUpdateTreasuryGuards(DataContext context, short settlementId)
	{
		Settlement settlement = GetSettlement(settlementId);
		settlement.ForceUpdateTreasuryGuards(context);
	}

	[DomainMethod]
	public void GmCmd_ForceUpdateInfluencePower(DataContext context, short settlementId)
	{
		Settlement settlement = GetSettlement(settlementId);
		Dictionary<int, (GameData.Domains.Character.Character, short)> baseInfluencePowers = new Dictionary<int, (GameData.Domains.Character.Character, short)>();
		HashSet<int> relatedCharIds = new HashSet<int>();
		settlement.UpdateInfluencePowers(context, baseInfluencePowers, relatedCharIds);
	}

	[DomainMethod]
	public void AddSectBounty(DataContext context, sbyte orgTemplateId, int charId, sbyte punishmentSeverity, short punishmentType, int duration)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character) || !IsSect(orgTemplateId))
		{
			return;
		}
		Sect sect = (Sect)GetSettlementByOrgTemplateId(orgTemplateId);
		sect.AddBounty(context, character, punishmentSeverity, punishmentType, duration);
		if (punishmentType != 43)
		{
			return;
		}
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId);
		List<int> members = new List<int>();
		settlement.GetMembers().GetAllMembers(members);
		using List<int>.Enumerator enumerator = members.GetEnumerator();
		if (enumerator.MoveNext())
		{
			int memberId = enumerator.Current;
			DomainManager.Character.AddRelation(context, charId, memberId, 32768);
		}
	}

	[DomainMethod]
	public void AddSectPrisoner(DataContext context, sbyte orgTemplateId, int charId, sbyte punishmentSeverity, short punishmentType, int duration)
	{
		if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && IsSect(orgTemplateId))
		{
			Sect sect = (Sect)GetSettlementByOrgTemplateId(orgTemplateId);
			sect.AddPrisoner(context, character, punishmentSeverity, punishmentType);
			int date = DomainManager.World.GetCurrDate();
			short settlementId = sect.GetId();
			int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
			LifeRecordCollection collection = DomainManager.LifeRecord.GetLifeRecordCollection();
			collection.AddSendingToPrisonCriminal(character.GetId(), date, taiwuCharId, sect.GetId());
			collection.AddSendingToPrison2Taiwu(taiwuCharId, date, character.GetId(), sect.GetId());
			SettlementPrisonRecordCollection treasuryRecordCollection = DomainManager.Organization.GetSettlementPrisonRecordCollection(context, settlementId);
			treasuryRecordCollection.AddSentToPrisonTaiwu(date, settlementId, charId, taiwuCharId);
			DomainManager.Organization.SetSettlementPrisonRecordCollection(context, settlementId, treasuryRecordCollection);
			if (character.IsCompletelyInfected())
			{
				sect.AddPrisoner(context, character, 40);
			}
			else
			{
				DomainManager.Organization.PunishSectMember(context, sect, character, punishmentSeverity, punishmentType, isArrested: true);
			}
			ProfessionFormulaItem seniorityFormula = ProfessionFormula.Instance[27];
			int addSeniority = seniorityFormula.Calculate(punishmentSeverity + 1, character.GetInteractionGrade());
			DomainManager.Extra.ChangeProfessionSeniority(context, 3, addSeniority);
		}
	}

	[DomainMethod]
	public void GmCmd_SetSectFunctionStatus(DataContext context, sbyte orgTemplateId, SectFunctionStatuses.SectFunctionStatusType statusType, bool value)
	{
		SetSectFunctionStatus(context, orgTemplateId, statusType, value);
	}

	public EMartialArtTournamentState GetCurrTournamentState()
	{
		if (_currTournamentHost < 0)
		{
			return (_tournamentPreparationEndDate != int.MinValue) ? EMartialArtTournamentState.Prepare : EMartialArtTournamentState.WaitTrigger;
		}
		Location location = GetElement_Sects(_currTournamentHost).GetLocation();
		return DomainManager.Adventure.QueryAnyActivatedInArea(location.AreaId, 114668976) ? EMartialArtTournamentState.Open : EMartialArtTournamentState.Confirmed;
	}

	public void ResetMartialArtTournamentState(DataContext context, IAdventureRuntime adventure, bool isComplete)
	{
		List<short> previousHosts = DomainManager.Organization.GetPreviousMartialArtTournamentHosts();
		int currDate = DomainManager.World.GetCurrDate();
		if (isComplete)
		{
			previousHosts.Add(_currTournamentHost);
			SetPreviousMartialArtTournamentHosts(previousHosts, context);
			SetLastTournamentFinishDate(currDate, context);
		}
		else if (previousHosts.Count == 0)
		{
			MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
			monthlyEventCollection.AddWulinConferenceTaiwuAbsent();
			_tmpSkipTournamentMonth = true;
			DomainManager.World.TriggerExtraTask(context, 0, 64);
		}
		else
		{
			sbyte winnerSectId = SelectMartialArtTournamentWinner(adventure);
			AddMartialArtTournamentWinnerPrize(context, winnerSectId);
			MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
			short settlementId = GetSettlementIdByOrgTemplateId(winnerSectId);
			monthlyNotifications.AddWulinConferenceWinner(settlementId);
			previousHosts.Add(_currTournamentHost);
			SetPreviousMartialArtTournamentHosts(previousHosts, context);
			SetLastTournamentFinishDate(currDate, context);
		}
		SetCurrTournamentHost(-1, context);
		SetTournamentPreparationEndDate(int.MinValue, context);
	}

	public sbyte GetFirstTournamentHostTemplateId()
	{
		List<short> previousMartialArtTournamentHosts = _previousMartialArtTournamentHosts;
		short settlementId = ((previousMartialArtTournamentHosts != null && previousMartialArtTournamentHosts.Count > 0) ? _previousMartialArtTournamentHosts[0] : _currTournamentHost);
		if (settlementId < 0)
		{
			return -1;
		}
		return GetSettlement(settlementId).GetOrgTemplateId();
	}

	public void UpdateMartialArtTournament(DataContext context)
	{
		EMartialArtTournamentState currState = GetCurrTournamentState();
		if (!DomainManager.World.GetWorldFunctionsStatus(25))
		{
			if (currState == EMartialArtTournamentState.WaitTrigger)
			{
				return;
			}
			if (currState == EMartialArtTournamentState.Confirmed || currState == EMartialArtTournamentState.Open)
			{
				Sect hostSect = GetElement_Sects(_currTournamentHost);
				Location hostLocation = hostSect.GetLocation();
				foreach (AdventureRuntime adventureRuntime in DomainManager.Adventure.QueryAdventuresInArea(hostLocation.AreaId))
				{
					if (adventureRuntime.CoreId == 114668976)
					{
						DomainManager.Adventure.RemoveAdventure(context, adventureRuntime.Id, EAdventureRemoveType.Timeout);
						break;
					}
				}
			}
			SetTournamentPreparationEndDate(int.MinValue, context);
			SetCurrTournamentHost(-1, context);
		}
		else if (_tmpSkipTournamentMonth)
		{
			_tmpSkipTournamentMonth = false;
		}
		else
		{
			switch (currState)
			{
			case EMartialArtTournamentState.WaitTrigger:
				UpdateMartialArtTournament_WaitTrigger(context);
				break;
			case EMartialArtTournamentState.Prepare:
				UpdateMartialArtTournament_Prepare(context);
				break;
			}
		}
	}

	private void UpdateMartialArtTournament_WaitTrigger(DataContext context)
	{
		if (!DomainManager.World.GetWorldFunctionsStatus(25))
		{
			return;
		}
		int currDate = DomainManager.World.GetCurrDate();
		if (_lastTournamentFinishDate + 108 <= currDate)
		{
			SetTournamentPreparationEndDate(currDate + 12, context);
			DomainManager.World.GetMonthlyNotificationCollection().AddWulinConferenceInPreparing();
			List<short> previousMartialArtTournamentHosts = _previousMartialArtTournamentHosts;
			if (previousMartialArtTournamentHosts == null || previousMartialArtTournamentHosts.Count <= 0)
			{
				DomainManager.World.TriggerExtraTask(context, 0, 65);
			}
		}
	}

	private void UpdateMartialArtTournament_Prepare(DataContext context)
	{
		if (_tournamentPreparationEndDate <= DomainManager.World.GetCurrDate())
		{
			CreateMartialArtTournamentAdventure(context);
		}
	}

	private void CreateMartialArtTournamentAdventure(DataContext context)
	{
		List<MartialArtTournamentPreparationInfo> preparationInfoList = DomainManager.Organization.GetMartialArtTournamentPreparationInfoList();
		short currentHost = preparationInfoList.Max().SettlementId;
		SetCurrTournamentHost(currentHost, context);
		Sect sect = DomainManager.Organization.GetElement_Sects(currentHost);
		Location location = sect.GetLocation();
		List<short> validBlockList = ObjectPool<List<short>>.Instance.Get();
		validBlockList.Clear();
		DomainManager.Map.GetSettlementBlocks(location.AreaId, location.BlockId, validBlockList);
		validBlockList.RemoveAll((short blockId2) => DomainManager.Adventure.QueryAnyAdventureOrMajorEvent(location.AreaId, blockId2));
		if (validBlockList.Count == 0)
		{
			DomainManager.Map.GetSettlementBlocks(location.AreaId, location.BlockId, validBlockList);
		}
		CollectionUtils.Shuffle(context.Random, validBlockList);
		foreach (short blockId in validBlockList)
		{
			Location actualLocation = new Location(location.AreaId, blockId);
			IAdventureRuntime runtime = DomainManager.Adventure.GenerateAny(context, 114668976, actualLocation);
			if (runtime == null)
			{
				continue;
			}
			short currHost = GetCurrTournamentHost();
			sbyte orgTemplateId = GetSettlement(currHost).GetOrgTemplateId();
			runtime.SetParameter("MainOrg", orgTemplateId);
			List<short> previousMartialArtTournamentHosts = _previousMartialArtTournamentHosts;
			if (previousMartialArtTournamentHosts == null || previousMartialArtTournamentHosts.Count <= 0)
			{
				DomainManager.World.TriggerExtraTask(context, 0, 66);
			}
			return;
		}
		throw new Exception($"No valid location for martial art tournament at {sect}.");
	}

	private void SectAskHelpForMartialArtTournament(DataContext context)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		List<MartialArtTournamentPreparationInfo> preparingForMartialArtTournamentSects = GetMartialArtTournamentPreparationInfoList();
		List<short> availableSects = ObjectPool<List<short>>.Instance.Get();
		availableSects.Clear();
		foreach (MartialArtTournamentPreparationInfo item in preparingForMartialArtTournamentSects)
		{
			short settlementId = item.SettlementId;
			Sect sect = DomainManager.Organization.GetElement_Sects(settlementId);
			short approvingRate = sect.CalcApprovingRate();
			if (approvingRate >= 500)
			{
				availableSects.Add(settlementId);
			}
		}
		if (availableSects.Count == 0)
		{
			ObjectPool<List<short>>.Instance.Return(availableSects);
			return;
		}
		short selectedSettlementId = availableSects.GetRandom(context.Random);
		monthlyEventCollection.AddWulinConferenceAskForHelp(selectedSettlementId, taiwuCharId);
		ObjectPool<List<short>>.Instance.Return(availableSects);
	}

	public void AddMartialArtTournamentWinnerPrize(DataContext context, sbyte sectTemplateId)
	{
		RegisterMartialArtTournamentWinner(context, sectTemplateId);
		int gainEquipmentCount = 3;
		List<TemplateKey> presetItems = new List<TemplateKey>();
		Settlement settlement = GetSettlementByOrgTemplateId(sectTemplateId);
		OrgMemberCollection members = settlement.GetMembers();
		for (sbyte grade = 0; grade <= 8; grade++)
		{
			HashSet<int> gradeMembers = members.GetMembers(grade);
			foreach (int charId in gradeMembers)
			{
				if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
				{
					continue;
				}
				OrganizationInfo orgInfo = character.GetOrganizationInfo();
				OrganizationMemberItem orgMemberCfg = GetOrgMemberConfig(orgInfo);
				ArraySegmentList<short> attackSkills = character.GetCombatSkillEquipment().Attack;
				presetItems.Clear();
				for (int index = 0; index < attackSkills.Count; index++)
				{
					short skillTemplateId = attackSkills[index];
					if (skillTemplateId >= 0)
					{
						CombatSkillItem skillCfg = Config.CombatSkill.Instance[skillTemplateId];
						if (skillCfg.MostFittingWeaponID >= 0)
						{
							presetItems.Add(new TemplateKey(0, skillCfg.MostFittingWeaponID));
						}
					}
				}
				for (int i = 0; i < orgMemberCfg.Equipment.Length; i++)
				{
					PresetEquipmentItemWithProb presetItem = orgMemberCfg.Equipment[i];
					if (presetItem.Type >= 0 && presetItem.TemplateId >= 0)
					{
						presetItems.Add(new TemplateKey(presetItem.Type, presetItem.TemplateId));
					}
				}
				CollectionUtils.Shuffle(context.Random, presetItems);
				if (gainEquipmentCount > presetItems.Count)
				{
					gainEquipmentCount = presetItems.Count;
				}
				for (int j = 0; j < gainEquipmentCount; j++)
				{
					TemplateKey presetItem2 = presetItems[j];
					short templateId = (short)(presetItem2.TemplateId + orgInfo.Grade);
					character.CreateInventoryItem(context, presetItem2.ItemType, templateId, 1);
				}
				WinnerLearnCombatSkills(context, character);
				WinnerLearnLifeSkills(context, character);
			}
		}
	}

	private sbyte SelectMartialArtTournamentWinner(IAdventureRuntime adventure)
	{
		Span<int> sectMaxPowers = stackalloc int[15];
		Span<int> powerSums = stackalloc int[15];
		Span<int> charCounts = stackalloc int[15];
		sectMaxPowers.Fill(0);
		List<int> charIds = new List<int>();
		adventure.CollectCharacters(charIds);
		foreach (int charId in charIds)
		{
			if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				continue;
			}
			sbyte sectId = character.GetOrganizationInfo().OrgTemplateId;
			if (IsSect(sectId))
			{
				int stateId = sectId - 1;
				int combatPower = character.GetCombatPower();
				if (combatPower > sectMaxPowers[stateId])
				{
					sectMaxPowers[stateId] = combatPower;
				}
				powerSums[stateId] += combatPower;
				charCounts[stateId]++;
			}
		}
		for (int i = 0; i < powerSums.Length; i++)
		{
			if (charCounts[i] > 0)
			{
				sectMaxPowers[i] += powerSums[i] / charCounts[i];
			}
		}
		int maxPowerIndex = CollectionUtils.GetMaxIndex(sectMaxPowers);
		int winnerSectId = 1 + maxPowerIndex;
		return (sbyte)winnerSectId;
	}

	private static void WinnerLearnCombatSkills(DataContext context, GameData.Domains.Character.Character character)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		sbyte behaviorType = character.GetBehaviorType();
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> learnedSkills = DomainManager.CombatSkill.GetCharCombatSkills(character.GetId());
		List<sbyte> skillTypes = Config.Organization.Instance[orgInfo.OrgTemplateId].CombatSkillTypes;
		List<short> skillsToLearn = ObjectPool<List<short>>.Instance.Get();
		skillsToLearn.Clear();
		foreach (sbyte skillType in skillTypes)
		{
			IReadOnlyList<CombatSkillItem> learnableSkills = CombatSkillDomain.GetLearnableCombatSkills(orgInfo.OrgTemplateId, skillType);
			for (int index = 0; index < learnableSkills.Count; index++)
			{
				CombatSkillItem skillCfg = learnableSkills[index];
				if (learnedSkills.TryGetValue(skillCfg.TemplateId, out var skill))
				{
					if (skill.CanBreakout() && !CombatSkillStateHelper.IsBrokenOut(skill.GetActivationState()))
					{
						skillsToLearn.Add(skillCfg.TemplateId);
					}
				}
				else
				{
					skillsToLearn.Add(skillCfg.TemplateId);
				}
			}
		}
		CollectionUtils.Shuffle(context.Random, skillsToLearn);
		int learnSkillCount = WinnerLearnCombatSkillCounts[orgInfo.Grade];
		if (learnSkillCount > skillsToLearn.Count)
		{
			learnSkillCount = skillsToLearn.Count;
		}
		for (int i = 0; i < learnSkillCount; i++)
		{
			short skillTemplateId = skillsToLearn[i];
			if (learnedSkills.TryGetValue(skillTemplateId, out var skill2))
			{
				DomainManager.CombatSkill.SetCombatSkillReadingState(context, skill2, 32767);
				ushort activationState = CombatSkillStateHelper.GenerateRandomActivatedNormalPages(context.Random, 32767, 0);
				activationState = CombatSkillStateHelper.GenerateRandomActivatedOutlinePage(context.Random, 32767, activationState, behaviorType);
				skill2.SetActivationState(activationState, context);
				skill2.SetBreakoutStepsCount(GlobalConfig.Instance.BreakoutSpecialNpcStepsCount, context);
				skill2.SetForcedBreakoutStepsCount(0, context);
			}
			else
			{
				character.LearnNewCombatSkill(context, skillTemplateId, 32767);
			}
		}
	}

	private static void WinnerLearnLifeSkills(DataContext context, GameData.Domains.Character.Character character)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		OrganizationMemberItem orgMemberCfg = GetOrgMemberConfig(orgInfo);
		List<GameData.Domains.Character.LifeSkillItem> learnedLifeSkills = character.GetLearnedLifeSkills();
		List<short> skillsToLearn = ObjectPool<List<short>>.Instance.Get();
		skillsToLearn.Clear();
		for (sbyte lifeSkillType = 0; lifeSkillType < orgMemberCfg.LifeSkillsAdjust.Length; lifeSkillType++)
		{
			short adjust = orgMemberCfg.LifeSkillsAdjust[lifeSkillType];
			if (adjust >= 6)
			{
				for (int i = 0; i <= orgMemberCfg.LifeSkillGradeLimit; i++)
				{
					short lifeSkillTemplateId = Config.LifeSkillType.Instance[lifeSkillType].SkillList[i];
					int index = character.FindLearnedLifeSkillIndex(lifeSkillTemplateId);
					if (index < 0)
					{
						skillsToLearn.Add(lifeSkillTemplateId);
						continue;
					}
					GameData.Domains.Character.LifeSkillItem learnedLifeSkill = learnedLifeSkills[index];
					if (!learnedLifeSkill.IsAllPagesRead())
					{
						skillsToLearn.Add(learnedLifeSkill.SkillTemplateId);
					}
				}
			}
		}
		CollectionUtils.Shuffle(context.Random, skillsToLearn);
		int learnSkillCount = WinnerLearnLifeSkillCounts[orgInfo.Grade];
		if (skillsToLearn.Count < learnSkillCount)
		{
			learnSkillCount = skillsToLearn.Count;
		}
		for (int j = 0; j < learnSkillCount; j++)
		{
			short skillTemplateId = skillsToLearn[j];
			int index2 = character.FindLearnedLifeSkillIndex(skillTemplateId);
			if (index2 < 0)
			{
				character.LearnNewLifeSkill(context, skillTemplateId, 31);
			}
			else
			{
				character.UpdateLifeSkillReadingState(context, index2, 31);
			}
		}
	}

	private void RecordSettlementStandardPopulations(DataContext context)
	{
		foreach (KeyValuePair<short, Settlement> settlement2 in _settlements)
		{
			settlement2.Deconstruct(out var _, out var value);
			Settlement settlement = value;
			OrgMemberCollection members = settlement.GetMembers();
			int count = members.GetCount();
			settlement.SetStandardOnStagePopulation(count, context);
		}
	}

	public void ChangeSettlementStandardPopulations(DataContext context, byte oriWorldPopulationType)
	{
		int oriFactor = WorldDomain.GetWorldPopulationFactor(oriWorldPopulationType);
		int currFactor = DomainManager.World.GetWorldPopulationFactor();
		foreach (KeyValuePair<short, Settlement> settlement2 in _settlements)
		{
			settlement2.Deconstruct(out var _, out var value);
			Settlement settlement = value;
			int oriPopulation = settlement.GetStandardOnStagePopulation();
			int basicPopulation = oriPopulation * 100 / oriFactor;
			int currPopulation = basicPopulation * currFactor / 100;
			settlement.SetStandardOnStagePopulation(currPopulation, context);
		}
	}

	public Dictionary<short, (int Expected, int Primary, int NonPrimary)[]> GetSettlementDarkAshTriple()
	{
		return _settlements.ToDictionary((KeyValuePair<short, Settlement> kv) => kv.Key, (KeyValuePair<short, Settlement> kv) => kv.Value.OrganizationConfig.Members.Select((short id) => OrganizationMember.Instance[id]).Select(delegate(OrganizationMemberItem orgMemberCfg)
		{
			GameData.Domains.Character.Character[] source = (from id in kv.Value.GetMembers().GetMembers(orgMemberCfg.Grade)
				select DomainManager.Character.TryGetElement_Objects(id, out var element) ? element : null into x
				where x?.GetAgeGroup() == 2 && x.GetDarkAshProtector() == 0
				select x).ToArray();
			return (kv.Value.GetExpectedCoreMemberAmount(orgMemberCfg), source.Count((GameData.Domains.Character.Character character) => character.GetOrganizationInfo().Principal), source.Count((GameData.Domains.Character.Character character) => !character.GetOrganizationInfo().Principal));
		}).ToArray());
	}

	private void InitializePrisonCache()
	{
		_sectFugitives.Clear();
		_sectPrisoners.Clear();
		foreach (Sect sect in _sects.Values)
		{
			sbyte orgTemplateId = sect.GetOrgTemplateId();
			SettlementPrison prison = sect.Prison;
			foreach (SettlementBounty bounty in prison.Bounties)
			{
				RegisterSectFugitive(bounty.CharId, orgTemplateId);
			}
			foreach (SettlementPrisoner prisoner in prison.Prisoners)
			{
				RegisterSectPrisoner(prisoner.CharId, orgTemplateId);
			}
		}
	}

	public void SetSettlementPrison(DataContext context, short settlementId, SettlementPrison prison)
	{
		if (_settlementPrisons.ContainsKey(settlementId))
		{
			SetElement_SettlementPrisons(settlementId, prison, context);
		}
		else
		{
			AddElement_SettlementPrisons(settlementId, prison, context);
		}
	}

	internal void RegisterSectFugitive(int charId, sbyte orgTemplateId)
	{
		if (!_sectFugitives.TryGetValue(charId, out var sectSet))
		{
			sectSet = new List<sbyte>(1);
			_sectFugitives.Add(charId, sectSet);
		}
		else if (sectSet.Contains(orgTemplateId))
		{
			return;
		}
		sectSet.Add(orgTemplateId);
	}

	internal void UnregisterSectFugitive(int charId, sbyte orgTemplateId)
	{
		if (_sectFugitives.TryGetValue(charId, out var sectSet))
		{
			sectSet.Remove(orgTemplateId);
			if (sectSet.Count == 0)
			{
				_sectFugitives.Remove(charId);
			}
		}
	}

	public sbyte GetFugitiveBountySect(int charId)
	{
		if (_sectFugitives.TryGetValue(charId, out var sects))
		{
			return sects[0];
		}
		return -1;
	}

	public IEnumerable<sbyte> GetFugitiveBountySects(int charId)
	{
		if (!_sectFugitives.TryGetValue(charId, out var sects))
		{
			yield break;
		}
		foreach (sbyte item in sects)
		{
			yield return item;
		}
	}

	public List<sbyte> GetTaiwuFugitiveBountySect()
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (_sectFugitives.TryGetValue(taiwuCharId, out var sects))
		{
			return sects;
		}
		return null;
	}

	public bool IsSectFugitive(int charId, sbyte orgTemplateId)
	{
		List<sbyte> sectSet;
		return _sectFugitives.TryGetValue(charId, out sectSet) && sectSet.Contains(orgTemplateId);
	}

	public SettlementBounty GetBounty(int charId, out sbyte sectOrgTemplateId)
	{
		sectOrgTemplateId = GetFugitiveBountySect(charId);
		if (sectOrgTemplateId < 0)
		{
			return null;
		}
		Sect sect = (Sect)GetSettlementByOrgTemplateId(sectOrgTemplateId);
		return sect.Prison.GetBounty(charId);
	}

	public bool TryRemoveBounty(DataContext context, int charId)
	{
		Tester.Assert(charId != DomainManager.Taiwu.GetTaiwuCharId(), "使用TryRemoveTaiwuBounty移除太吾的悬赏");
		sbyte bountySectId = DomainManager.Organization.GetFugitiveBountySect(charId);
		if (bountySectId < 0)
		{
			return false;
		}
		short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(bountySectId);
		Sect sect = _sects[settlementId];
		return sect.RemoveBounty(context, charId);
	}

	public void TryRemoveTaiwuBounty(DataContext context)
	{
		List<sbyte> bountySectIds = DomainManager.Organization.GetTaiwuFugitiveBountySect();
		if (bountySectIds != null)
		{
			for (int i = 0; i < bountySectIds.Count; i++)
			{
				sbyte sectTemplateId = bountySectIds[i];
				short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(sectTemplateId);
				Sect sect = _sects[settlementId];
				sect.RemoveBounty(context, DomainManager.Taiwu.GetTaiwuCharId());
			}
		}
	}

	public void TryRemoveTaiwuGroupBountyAndPunishment(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuId = taiwu.GetId();
		HashSet<int> taiwuGroup = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		InstantNotificationCollection instantCollection = DomainManager.World.GetInstantNotificationCollection();
		List<short> featureIds = taiwu.GetFeatureIds();
		foreach (int charId in taiwuGroup)
		{
			if (charId == taiwuId)
			{
				continue;
			}
			sbyte bountySectId = DomainManager.Organization.GetFugitiveBountySect(charId);
			if (bountySectId >= 0)
			{
				short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(bountySectId);
				Sect sect = _sects[settlementId];
				if (sect.RemoveBounty(context, charId))
				{
					instantCollection.AddSectPunishmentWarrantRelieved(charId, settlementId);
				}
			}
		}
		List<int> toRemoveList = new List<int>();
		if (_sectFugitives.TryGetValue(taiwuId, out var sects))
		{
			foreach (sbyte sectTemplateId in sects)
			{
				toRemoveList.Add(sectTemplateId);
			}
		}
		foreach (int sectTemplateId2 in toRemoveList)
		{
			short settlementId2 = DomainManager.Organization.GetSettlementIdByOrgTemplateId((sbyte)sectTemplateId2);
			Sect sect2 = _sects[settlementId2];
			if (sect2.RemoveBounty(context, taiwuId))
			{
				instantCollection.AddSectPunishmentWarrantRelieved(taiwuId, settlementId2);
			}
		}
		toRemoveList.Clear();
		for (sbyte orgTemplateId = 1; orgTemplateId <= 15; orgTemplateId++)
		{
			List<short> punishments = Config.Organization.Instance[orgTemplateId].TaiwuPunishementFeature;
			if (punishments != null)
			{
				foreach (short punishment in punishments)
				{
					if (featureIds.Contains(punishment))
					{
						short settlementId3 = DomainManager.Organization.GetSettlementIdByOrgTemplateId(orgTemplateId);
						toRemoveList.Add(punishment);
						instantCollection.AddSectPunishmentCharacterFeatureRelieved(taiwuId, settlementId3);
						break;
					}
				}
			}
		}
		foreach (int featureId in toRemoveList)
		{
			taiwu.RemoveFeature(context, (short)featureId);
			DomainManager.Character.UnregisterCharacterTemporaryFeature(context, taiwuId, (short)featureId);
		}
	}

	internal void RegisterSectPrisoner(int charId, sbyte orgTemplateId)
	{
		if (!_sectPrisoners.TryAdd(charId, orgTemplateId))
		{
			Logger.AppendWarning($"character {charId} is imprisoned by multiple sects.");
		}
	}

	internal void UnregisterSectPrisoner(int charId)
	{
		_sectPrisoners.Remove(charId);
	}

	public sbyte GetPrisonerSect(int charId)
	{
		return _sectPrisoners.GetValueOrDefault<int, sbyte>(charId, -1);
	}

	public void GetAllPrisoner(List<int> results)
	{
		foreach (var (charId, sectId) in _sectPrisoners)
		{
			results.Add(charId);
		}
	}

	[Obsolete]
	public void SetSettlementPrisonGuardCharId(int charId)
	{
		_prisonGuardCharId = charId;
	}

	[DomainMethod]
	public SettlementPrisonDisplayData GetSettlementPrisonDisplayData(DataContext context, short settlementId)
	{
		Sect sect = GetSettlement(settlementId) as Sect;
		SettlementPrison prison = sect.Prison;
		CharacterDisplayData[] guards = (from prisonGuardCharId in sect.Treasuries.GetGuardIds()
			select DomainManager.Character.GetCharacterDisplayData(prisonGuardCharId)).ToArray();
		SettlementPrisonDisplayData data = new SettlementPrisonDisplayData
		{
			OrgTemplateId = sect.GetOrgTemplateId(),
			DebtOrSupport = sect.CalcApprovingRate(),
			GuardianCharacterDisplayDataLow = sect.GetGuardsDisplayData(context, 0),
			GuardianCharacterDisplayDataMid = sect.GetGuardsDisplayData(context, 1),
			GuardianCharacterDisplayDataHigh = sect.GetGuardsDisplayData(context, 2),
			PrisonerCharacterDisplayDataDict = new Dictionary<int, CharacterDisplayDataForSettlementPrisoner>(),
			IsStoneRoomFull = DomainManager.Extra.IsStoneRoomFull()
		};
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		foreach (SettlementPrisoner prisoner in prison.Prisoners)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(prisoner.CharId);
			CharacterDisplayDataForSettlementPrisoner charDisplayData = new CharacterDisplayDataForSettlementPrisoner();
			charDisplayData.Resistance = sect.CalcKidnappedCharacterResistance(prisoner);
			charDisplayData.EscapeRate = prisoner.CalcEscapeRate(charDisplayData.Resistance, 0, character.IsEscapeCertainly());
			charDisplayData.SettlementPrisoner = new SettlementPrisoner(prisoner);
			charDisplayData.CompletelyInfected = character.IsCompletelyInfected();
			charDisplayData.OwningBook = character.IsOwningBook();
			int kidnappedCharId = prisoner.CharId;
			AvatarData avatarData = character.GetAvatar();
			KidnapCharDisplayData kidnapCharDisplayData = (charDisplayData.KidnapCharDisplayData = new KidnapCharDisplayData
			{
				CharacterId = kidnappedCharId,
				CharacterTemplateId = character.GetTemplateId(),
				NameData = DomainManager.Character.GetNameRelatedData(kidnappedCharId),
				AvatarRelatedData = character.GenerateAvatarRelatedData(),
				OrganizationInfo = character.GetOrganizationInfo(),
				CurrAge = character.GetCurrAge(),
				ActualAge = character.GetActualAge(),
				Health = character.GetHealth(),
				MaxLeftHealth = character.GetLeftMaxHealth(),
				DefeatMarkCount = (sbyte)CombatDomain.GetDefeatMarksCountOutOfCombat(character),
				Charm = character.GetAttraction(),
				BehaviorType = character.GetBehaviorType(),
				Fame = character.GetFame(),
				Happiness = ((DomainManager.Combat.IsInCombat() && DomainManager.Combat.IsCharInCombat(kidnappedCharId)) ? DomainManager.Combat.GetElement_CombatCharacterDict(kidnappedCharId).GetHappiness() : character.GetHappiness()),
				FavorabilityToTaiwu = DomainManager.Character.GetFavorability(kidnappedCharId, taiwuCharId),
				Alertness = DomainManager.Character.GetAlertnessValue(kidnappedCharId),
				PreexistenceCharCount = (short)character.GetPreexistenceCharIds().Count,
				Gender = character.GetGender(),
				PhysiologicalAge = character.GetPhysiologicalAge(),
				ClothDisplayId = character.GetClothingDisplayId(),
				FaceVisible = (!avatarData.ShowVeil && !avatarData.ShowMask(character.GetClothingDisplayId())),
				CreatingType = character.GetCreatingType(),
				IsInteractedWithTaiwu = DomainManager.Character.IsInteractedWithTaiwu(kidnappedCharId),
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
				LifeSkillAttainments = character.GetLifeSkillAttainments(),
				CombatSkillAttainments = character.GetCombatSkillAttainments(),
				Personalities = character.GetPersonalities(),
				Resources = character.GetResources(),
				CurrInventoryLoad = character.GetCurrInventoryLoad(),
				MaxInventoryLoad = character.GetMaxInventoryLoad(),
				KidnapCount = (sbyte)DomainManager.Character.GetKidnappedCharacterCount(kidnappedCharId),
				AttackMedal = character.GetFeatureMedalValue(0),
				DefenceMedal = character.GetFeatureMedalValue(1),
				WisdomMedal = character.GetFeatureMedalValue(2),
				Command = DomainManager.Extra.GetCharTeammateCommandsSByteList(context, kidnappedCharId),
				AdvancedCommand = DomainManager.Extra.GetAdvancedCharTeammateCommandsSByteList(kidnappedCharId),
				ConsummateLevel = character.GetConsummateLevel()
			});
			charDisplayData.RandomNameId = (short)((kidnapCharDisplayData.OrganizationInfo.SettlementId >= 0) ? DomainManager.Organization.GetSettlement(kidnapCharDisplayData.OrganizationInfo.SettlementId).GetNameRelatedData().RandomNameId : (-1));
			data.PrisonerCharacterDisplayDataDict[prisoner.CharId] = charDisplayData;
		}
		return data;
	}

	[DomainMethod]
	public SettlementBountyDisplayData GetSettlementBountyDisplayData(short settlementId)
	{
		SettlementBountyDisplayData data = new SettlementBountyDisplayData();
		Sect sect = (Sect)GetSettlement(settlementId);
		_calculatedBountiesCache.Clear();
		sect.GetEnemyRelationBounties(_calculatedBountiesCache);
		sect.GetEnemySectBounties(_calculatedBountiesCache);
		sect.GetXiangshuInfectedBounties(_calculatedBountiesCache);
		SettlementPrison prison = sect.Prison;
		data.BountyCharacterDisplayDataDict = new Dictionary<int, CharacterDisplayDataForSettlementBounty>();
		data.OrgTemplateId = sect.GetOrgTemplateId();
		GetBountyCharacterDisplayDataFromList(data, prison.Bounties);
		GetBountyCharacterDisplayDataFromList(data, _calculatedBountiesCache);
		return data;
	}

	internal void FillBountyCharacterDisplayDataFromInfo(CharacterDisplayDataForSettlementBounty charDisplayData, GameData.Domains.Character.Character character, SettlementBounty bounty, bool getListDisplayData = false)
	{
		charDisplayData.PhysiologicalAge = character.GetPhysiologicalAge();
		charDisplayData.AvatarRelatedData = character.GenerateAvatarRelatedData();
		charDisplayData.NameRelatedData = DomainManager.Character.GetNameRelatedData(character.GetId());
		charDisplayData.Gender = character.GetGender();
		charDisplayData.Health = character.GetHealth();
		charDisplayData.LeftMaxHealth = character.GetLeftMaxHealth();
		charDisplayData.OrgInfo = character.GetOrganizationInfo();
		charDisplayData.FullBlockName = DomainManager.Map.GetBlockFullName(character.GetLocation());
		charDisplayData.RandomNameId = (short)((charDisplayData.OrgInfo.SettlementId >= 0) ? DomainManager.Organization.GetSettlement(charDisplayData.OrgInfo.SettlementId).GetNameRelatedData().RandomNameId : (-1));
		charDisplayData.Happiness = character.GetHappiness();
		charDisplayData.FavorabilityToTaiwu = DomainManager.Character.GetFavorability(character.GetId(), DomainManager.Taiwu.GetTaiwuCharId());
		charDisplayData.Location = character.GetLocation();
		if (getListDisplayData)
		{
			DataContext context = DataContextManager.GetCurrentThreadDataContext();
			charDisplayData.CharacterDisplayDataForGeneralScrollList = DomainManager.Character.GetCharacterDisplayDataForGeneralScrollList(context, character.GetId());
		}
		if (bounty != null)
		{
			charDisplayData.SettlementBounty = new SettlementBounty(bounty);
			charDisplayData.HunterState = GetHunterState(bounty, character);
		}
	}

	private void GetBountyCharacterDisplayDataFromList(SettlementBountyDisplayData data, List<SettlementBounty> source)
	{
		foreach (SettlementBounty bounty in source)
		{
			if (!data.BountyCharacterDisplayDataDict.ContainsKey(bounty.CharId))
			{
				CharacterDisplayDataForSettlementBounty charDisplayData = new CharacterDisplayDataForSettlementBounty();
				FillBountyCharacterDisplayDataFromInfo(charDisplayData, DomainManager.Character.GetElement_Objects(bounty.CharId), bounty, getListDisplayData: true);
				data.BountyCharacterDisplayDataDict[bounty.CharId] = charDisplayData;
			}
		}
	}

	[DomainMethod]
	public SettlementBountyDisplayData GetBountyCharacterDisplayDataFromCharacterList(List<int> characterIds)
	{
		SettlementBountyDisplayData result = new SettlementBountyDisplayData
		{
			BountyCharacterDisplayDataDict = new Dictionary<int, CharacterDisplayDataForSettlementBounty>(),
			OrgTemplateId = -1
		};
		OrganizationDomain orgDomain = DomainManager.Organization;
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		List<int> sourceIds = new List<int>();
		if (characterIds != null)
		{
			sourceIds.AddRange(characterIds);
		}
		for (int i = 0; i < sourceIds.Count; i++)
		{
			int charId = sourceIds[i];
			if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				continue;
			}
			if (charId == taiwuCharId)
			{
				int index = -1;
				foreach (OrganizationItem orgConfig in (IEnumerable<OrganizationItem>)Config.Organization.Instance)
				{
					if (!orgConfig.IsSect || !orgDomain.IsSectFugitive(charId, orgConfig.TemplateId) || !(orgDomain.GetSettlementByOrgTemplateId(orgConfig.TemplateId) is Sect sect))
					{
						continue;
					}
					SettlementBounty bounty = sect.Prison.GetBounty(charId);
					if (bounty != null)
					{
						CharacterDisplayDataForSettlementBounty data = new CharacterDisplayDataForSettlementBounty();
						FillBountyCharacterDisplayDataFromInfo(data, character, bounty);
						data.OrgInfo.OrgTemplateId = orgConfig.TemplateId;
						if (!sourceIds.Contains(bounty.CurrentHunterId))
						{
							sourceIds.Add(bounty.CurrentHunterId);
						}
						result.BountyCharacterDisplayDataDict[index] = data;
						index--;
					}
				}
			}
			else
			{
				CharacterDisplayDataForSettlementBounty data2 = new CharacterDisplayDataForSettlementBounty();
				sbyte sectOrgTemplateId;
				SettlementBounty bounty2 = GetBounty(charId, out sectOrgTemplateId);
				FillBountyCharacterDisplayDataFromInfo(data2, character, bounty2);
				data2.OrgInfo.OrgTemplateId = sectOrgTemplateId;
				if (bounty2 != null && !sourceIds.Contains(bounty2.CurrentHunterId))
				{
					sourceIds.Add(bounty2.CurrentHunterId);
				}
				result.BountyCharacterDisplayDataDict[charId] = data2;
			}
		}
		return result;
	}

	[DomainMethod]
	public SettlementPrisonRecordCollection GetSettlementPrisonRecordCollection(DataContext context, short settlementId)
	{
		if (_settlementPrisonRecordCollections.TryGetValue(settlementId, out var collection))
		{
			return collection;
		}
		collection = new SettlementPrisonRecordCollection();
		AddElement_SettlementPrisonRecordCollections(settlementId, collection, context);
		return collection;
	}

	[DomainMethod]
	public TransferableRecordDataBase GetReversedSettlementPrisonRecordCollection(DataContext context, short settlementId)
	{
		SettlementPrisonRecordCollection collection = GetSettlementPrisonRecordCollection(context, settlementId);
		TransferableRecordDataBase data = new TransferableRecordDataBase();
		collection.ReadOrganizationRecordDataWithNormalOrder(data, GetParameters);
		LifeRecordDomain.PostProcess(data);
		return data;
		static string[] GetParameters(int recordType)
		{
			SettlementPrisonRecordItem config = Config.SettlementPrisonRecord.Instance[recordType];
			if (config != null)
			{
				return config.Parameters ?? Array.Empty<string>();
			}
			AdaptableLog.Warning($"Unable to render SettlementPrisonRecord with template id {recordType}");
			return null;
		}
	}

	public bool IsCharacterSectFugitive(int charId, sbyte orgTemplateId)
	{
		sbyte bountyOrgTemplateId = DomainManager.Organization.GetFugitiveBountySect(charId);
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		return bountyOrgTemplateId == orgTemplateId || character.IsCompletelyInfected();
	}

	public void SetSettlementPrisonRecordCollection(DataContext context, short settlementId, SettlementPrisonRecordCollection collection)
	{
		SetElement_SettlementPrisonRecordCollections(settlementId, collection, context);
	}

	private sbyte GetHunterState(SettlementBounty bounty, GameData.Domains.Character.Character character)
	{
		if (bounty.CurrentHunterId < 0)
		{
			return (sbyte)((bounty.RequiredConsummateLevel >= 0) ? 2 : 0);
		}
		return (sbyte)((character.GetKidnapperId() != bounty.CurrentHunterId) ? 1 : 3);
	}

	public (CharacterSet changeFavorCharIds, CharacterSet becomeEnemyCharIds, CharacterSet approveCharIds, CharacterSet disapproveCharIds) ApplySettlementPrisonEventEffect(DataContext context, SettlementPrisonEventEffectItem effectCfg, short settlementId)
	{
		Settlement settlement = GetSettlement(settlementId);
		if (!(settlement is Sect sect))
		{
			throw new Exception($"settlement {settlement} is not Sect");
		}
		SettlementLayeredTreasuries treasuries = settlement.Treasuries;
		OrgMemberCollection members = settlement.GetMembers();
		if (effectCfg.TaiwuBounty >= 0)
		{
			PunishmentTypeItem punishment = PunishmentType.Instance[effectCfg.TaiwuBounty];
			if (punishment != null)
			{
				sect.AddBounty(context, DomainManager.Taiwu.GetTaiwu(), punishment.Severity, effectCfg.TaiwuBounty);
			}
		}
		if (effectCfg.AlterTime > 0)
		{
			sect.SetAlterTime(context, (byte)effectCfg.AlterTime);
		}
		HashSet<int> guardIds = ObjectPool<HashSet<int>>.Instance.Get();
		guardIds.Clear();
		treasuries.GetGuardIds(guardIds);
		SettlementTreasuryEventEffectHelper.EffectArgs guardArgs = new SettlementTreasuryEventEffectHelper.EffectArgs(effectCfg, guardIds.Count, isGuard: true);
		ApplySettlementTreasuryEventEffect(context, guardIds, ref guardArgs);
		List<int> charIdList = ObjectPool<List<int>>.Instance.Get();
		charIdList.Clear();
		for (sbyte grade = 0; grade <= 8; grade++)
		{
			IEnumerable<int> gradeMembers = DomainManager.Character.ExcludeInfant(members.GetMembers(grade));
			foreach (int charId in gradeMembers)
			{
				if (!guardIds.Contains(charId))
				{
					charIdList.Add(charId);
				}
			}
		}
		CollectionUtils.Shuffle(context.Random, charIdList);
		SettlementTreasuryEventEffectHelper.EffectArgs effectArgs = new SettlementTreasuryEventEffectHelper.EffectArgs(effectCfg, charIdList.Count, isGuard: false);
		effectArgs.ChangeFavorCharIds = guardArgs.ChangeFavorCharIds;
		effectArgs.ApproveCharIds = guardArgs.ApproveCharIds;
		effectArgs.DisapproveCharIds = guardArgs.DisapproveCharIds;
		effectArgs.BecomeEnemyCharIds = guardArgs.BecomeEnemyCharIds;
		SettlementTreasuryEventEffectHelper.EffectArgs memberArgs = effectArgs;
		ApplySettlementTreasuryEventEffect(context, charIdList, ref memberArgs);
		ObjectPool<HashSet<int>>.Instance.Return(guardIds);
		ObjectPool<List<int>>.Instance.Return(charIdList);
		return (changeFavorCharIds: memberArgs.ChangeFavorCharIds, becomeEnemyCharIds: memberArgs.BecomeEnemyCharIds, approveCharIds: memberArgs.ApproveCharIds, disapproveCharIds: memberArgs.DisapproveCharIds);
	}

	[DomainMethod]
	public bool IsTaiwuSectFugitive(sbyte orgTemplateId)
	{
		return GetTaiwuFugitiveBountySect()?.Contains(orgTemplateId) ?? false;
	}

	[DomainMethod]
	public void UpdateCityPunishmentSeverityCustomizeData(DataContext context, sbyte stateTemplateId, bool isSect, short punishmentTypeTemplateId, sbyte customizedPunishmentSeverityTemplateId)
	{
		short key = PunishmentSeverityCustomizeData.GetPunishmentSeverityCustomizeKey(stateTemplateId, isSect);
		if (TryGetElement_CityPunishmentSeverityCustomizeDict(key, out var punishmentSeverityCustomize))
		{
			if (punishmentSeverityCustomize.Items == null)
			{
				punishmentSeverityCustomize = SerializableList<PunishmentSeverityCustomizeData>.Create();
			}
			for (int index = punishmentSeverityCustomize.Items.Count - 1; index >= 0; index--)
			{
				PunishmentSeverityCustomizeData data = punishmentSeverityCustomize.Items[index];
				if (data.PunishmentTypeTemplateId == punishmentTypeTemplateId)
				{
					punishmentSeverityCustomize.Items.RemoveAt(index);
					break;
				}
			}
			PunishmentSeverityCustomizeData newData = new PunishmentSeverityCustomizeData
			{
				PunishmentTypeTemplateId = punishmentTypeTemplateId,
				CustomizedPunishmentSeverityTemplateId = customizedPunishmentSeverityTemplateId,
				ModifyDate = DomainManager.World.GetCurrDate()
			};
			punishmentSeverityCustomize.Items.Add(newData);
			SetElement_CityPunishmentSeverityCustomizeDict(key, punishmentSeverityCustomize, context);
		}
		else
		{
			PunishmentSeverityCustomizeData newData2 = new PunishmentSeverityCustomizeData
			{
				PunishmentTypeTemplateId = punishmentTypeTemplateId,
				CustomizedPunishmentSeverityTemplateId = customizedPunishmentSeverityTemplateId,
				ModifyDate = DomainManager.World.GetCurrDate()
			};
			SerializableList<PunishmentSeverityCustomizeData> list = SerializableList<PunishmentSeverityCustomizeData>.Create();
			list.Items.Add(newData2);
			AddElement_CityPunishmentSeverityCustomizeDict(key, list, context);
		}
	}

	public void UpdateSpecialCustomizedSeverity(DataContext context)
	{
		RemoveOverdueCityPunishmentSeverityCustomizeData(context);
		Dictionary<short, VillagerRoleHead> keysWithVillageHead = new Dictionary<short, VillagerRoleHead>();
		IReadOnlySet<int> villageHeadSet = DomainManager.Taiwu.GetVillagerRoleSet(6);
		foreach (int charId in villageHeadSet)
		{
			VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(charId);
			if (villagerRole is VillagerRoleHead villageHead && villageHead.TryGetWorkingStateCustomizeKey(out var key))
			{
				keysWithVillageHead.TryAdd(key, villageHead);
			}
		}
		int defaultRange = GlobalConfig.Instance.ModifySeverityDefaultRange;
		foreach (KeyValuePair<short, SerializableList<PunishmentSeverityCustomizeData>> item in _cityPunishmentSeverityCustomizeDict)
		{
			item.Deconstruct(out var key2, out var value);
			short key3 = key2;
			SerializableList<PunishmentSeverityCustomizeData> serializableList = value;
			List<PunishmentSeverityCustomizeData> items = serializableList.Items;
			if (items == null || items.Count <= 0)
			{
				continue;
			}
			VillagerRoleHead villageHead2 = keysWithVillageHead.GetOrDefault(key3, null);
			int specialRuleRange = villageHead2?.ArrangementSpecialRuleRange ?? 0;
			int specialRuleCount = villageHead2?.ArrangementSpecialRuleCount ?? 0;
			int count = 0;
			bool needSave = false;
			for (int index = serializableList.Items.Count - 1; index >= 0; index--)
			{
				PunishmentSeverityCustomizeData data = serializableList.Items[index];
				int diff = data.ModificationDiff(key3);
				if (diff > defaultRange)
				{
					if (diff > specialRuleRange || count >= specialRuleCount)
					{
						serializableList.Items.RemoveAt(index);
						needSave = true;
					}
					else
					{
						count++;
					}
				}
			}
			if (needSave)
			{
				SetElement_CityPunishmentSeverityCustomizeDict(key3, serializableList, context);
			}
		}
	}

	public (int, int) GetSpecialCustomizedSeverityRangeAndAvailableAmount(short settlementId, out bool hasVillageHead)
	{
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		Location settlementLocation = settlement.GetLocation();
		sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(settlementLocation.AreaId);
		bool isSect = settlement is Sect;
		int exceedCount = GetSpecialCustomizedCityPunishmentSeverityCount(stateTemplateId, isSect);
		short expectedKey = PunishmentSeverityCustomizeData.GetPunishmentSeverityCustomizeKey(stateTemplateId, isSect);
		IReadOnlySet<int> members = DomainManager.Taiwu.GetVillagerRoleSet(6);
		foreach (int charId in members)
		{
			VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(charId);
			if (!(villagerRole is VillagerRoleHead head) || !head.TryGetWorkingStateCustomizeKey(out var key) || key != expectedKey)
			{
				continue;
			}
			hasVillageHead = true;
			return (head.ArrangementSpecialRuleRange, head.ArrangementSpecialRuleCount - exceedCount);
		}
		hasVillageHead = false;
		return (GlobalConfig.Instance.ModifySeverityDefaultRange, 0);
	}

	public int GetSpecialCustomizedCityPunishmentSeverityCount(sbyte stateTemplateId, bool isSect)
	{
		int defaultRange = GlobalConfig.Instance.ModifySeverityDefaultRange;
		short key = PunishmentSeverityCustomizeData.GetPunishmentSeverityCustomizeKey(stateTemplateId, isSect);
		int count = 0;
		if (TryGetElement_CityPunishmentSeverityCustomizeDict(key, out var punishmentSeverityCustomize))
		{
			List<PunishmentSeverityCustomizeData> items = punishmentSeverityCustomize.Items;
			if (items != null && items.Count > 0)
			{
				foreach (PunishmentSeverityCustomizeData customSeverityData in punishmentSeverityCustomize.Items)
				{
					if (customSeverityData.ModificationDiff(stateTemplateId, isSect) > defaultRange)
					{
						count++;
					}
				}
			}
		}
		return count;
	}

	public bool TryGetCustomizedCityPunishmentSeverity(sbyte stateTemplateId, bool isSect, short punishmentTypeTemplateId, ref sbyte customizedPunishmentSeverityTemplateId)
	{
		short key = PunishmentSeverityCustomizeData.GetPunishmentSeverityCustomizeKey(stateTemplateId, isSect);
		if (TryGetElement_CityPunishmentSeverityCustomizeDict(key, out var punishmentSeverityCustomize) && punishmentSeverityCustomize.Items != null)
		{
			for (int index = punishmentSeverityCustomize.Items.Count - 1; index >= 0; index--)
			{
				PunishmentSeverityCustomizeData data = punishmentSeverityCustomize.Items[index];
				if (data.PunishmentTypeTemplateId == punishmentTypeTemplateId)
				{
					customizedPunishmentSeverityTemplateId = data.CustomizedPunishmentSeverityTemplateId;
					return true;
				}
			}
		}
		return false;
	}

	private void RemoveOverdueCityPunishmentSeverityCustomizeData(DataContext context)
	{
		int currDate = DomainManager.World.GetCurrDate();
		foreach (KeyValuePair<short, SerializableList<PunishmentSeverityCustomizeData>> pair in _cityPunishmentSeverityCustomizeDict)
		{
			if (pair.Value.Items == null)
			{
				continue;
			}
			bool needSave = false;
			for (int index = pair.Value.Items.Count - 1; index >= 0; index--)
			{
				PunishmentSeverityCustomizeData data = pair.Value.Items[index];
				if (currDate - data.ModifyDate >= GlobalConfig.Instance.TownPunishmentSeverityCustomizeDuration)
				{
					needSave = true;
					pair.Value.Items.RemoveAt(index);
				}
			}
			if (needSave)
			{
				SetElement_CityPunishmentSeverityCustomizeDict(pair.Key, pair.Value, context);
			}
		}
	}

	[DomainMethod]
	public int GetCustomizePunishmentSeverityCost(sbyte stateTemplateId, bool isSect)
	{
		ICollection<int> villagers = DomainManager.Extra.GetVillagerRoleCharacters();
		int totalCost = 0;
		foreach (int charId in villagers)
		{
			VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(charId);
			if (villagerRole is VillagerRoleHead head && villagerRole.WorkData != null && head.TryGetWorkingStateCustomizeKey(out var key))
			{
				var (headStateTemplateId, headIsSect) = PunishmentSeverityCustomizeData.DecodePunishmentSeverityCustomizeKey(key);
				if (headStateTemplateId == stateTemplateId && isSect == headIsSect)
				{
					totalCost += head.GetAuthorityCost(removeExceeded: false, out var _);
				}
			}
		}
		return totalCost;
	}

	[DomainMethod]
	public bool WillCustomizePunishmentBreakWithoutVillagerHead(int villagerHeadCharId)
	{
		IReadOnlySet<int> villageHeadSet = DomainManager.Taiwu.GetVillagerRoleSet(6);
		VillagerRoleHead villagerHead = null;
		short villagerHeadKey = -1;
		foreach (int charId in villageHeadSet)
		{
			if (charId == villagerHeadCharId)
			{
				VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(charId);
				if (villagerRole is VillagerRoleHead villageHead && villageHead.TryGetWorkingStateCustomizeKey(out var key))
				{
					villagerHead = villageHead;
					villagerHeadKey = key;
					break;
				}
			}
		}
		if (villagerHead == null || villagerHeadKey < 0)
		{
			Logger.Warn($"WillCustomizePunishmentBreakWithoutVillagerHead() failed to find villager head with charId: {villagerHeadCharId}");
			return false;
		}
		var (headStateTemplateId, headIsSect) = PunishmentSeverityCustomizeData.DecodePunishmentSeverityCustomizeKey(villagerHeadKey);
		if (!TryGetElement_CityPunishmentSeverityCustomizeDict(villagerHeadKey, out var punishmentSeverityCustomize))
		{
			Logger.Warn($"WillCustomizePunishmentBreakWithoutVillagerHead() failed to find punishment severity customize for key: {villagerHeadKey}");
			return false;
		}
		if (punishmentSeverityCustomize.Items == null || punishmentSeverityCustomize.Items.Count <= 0)
		{
			Logger.Warn($"WillCustomizePunishmentBreakWithoutVillagerHead() no items found for key: {villagerHeadKey}");
			return false;
		}
		int defaultRange = GlobalConfig.Instance.ModifySeverityDefaultRange;
		int exceedCount = 0;
		foreach (PunishmentSeverityCustomizeData customSeverityData in punishmentSeverityCustomize.Items)
		{
			if (customSeverityData.ModificationDiff(headStateTemplateId, headIsSect) > defaultRange)
			{
				exceedCount++;
			}
		}
		int villageHeadSetCount = 0;
		foreach (int charId2 in villageHeadSet)
		{
			VillagerRoleBase villagerRole2 = DomainManager.Extra.GetVillagerRole(charId2);
			if (villagerRole2 is VillagerRoleHead head && villagerRole2.WorkData != null && head.TryGetWorkingStateCustomizeKey(out var key2))
			{
				var (headStateTemplateId2, headIsSect2) = PunishmentSeverityCustomizeData.DecodePunishmentSeverityCustomizeKey(key2);
				if (headStateTemplateId == headStateTemplateId2 && headIsSect == headIsSect2)
				{
					villageHeadSetCount += head.ArrangementSpecialRuleCount;
				}
			}
		}
		if (villageHeadSetCount - villagerHead.ArrangementSpecialRuleCount < exceedCount)
		{
			return true;
		}
		return false;
	}

	public sbyte GetSectFavorability(sbyte orgTemplateId, sbyte relatedOrgTemplateId)
	{
		sbyte largeSectIndex = GetLargeSectIndex(orgTemplateId);
		sbyte relatedLargeSectIndex = GetLargeSectIndex(relatedOrgTemplateId);
		if (largeSectIndex >= 0 && relatedLargeSectIndex >= 0)
		{
			return Config.Organization.Instance[orgTemplateId].LargeSectFavorabilities[relatedLargeSectIndex];
		}
		return 0;
	}

	public void GetSectTemplateIdsByFavorability(sbyte orgTemplateId, sbyte sectFavorability, ref SpanList<sbyte> result)
	{
		for (sbyte i = 0; i < 15; i++)
		{
			sbyte relatedSectTemplateId = GetLargeSectTemplateId(i);
			if (GetSectFavorability(orgTemplateId, relatedSectTemplateId) == sectFavorability)
			{
				result.Add(relatedSectTemplateId);
			}
		}
	}

	[Obsolete]
	public void SetSectFavorability(DataContext context, sbyte orgTemplateId, sbyte relatedOrgTemplateId, sbyte favorability)
	{
		sbyte largeSectIndex = GetLargeSectIndex(orgTemplateId);
		sbyte relatedLargeSectIndex = GetLargeSectIndex(relatedOrgTemplateId);
		if (largeSectIndex >= 0 && relatedLargeSectIndex >= 0)
		{
			SetLargeSectFavorability(context, largeSectIndex, relatedLargeSectIndex, favorability);
			return;
		}
		throw new Exception($"Not support favorability of small sects: {orgTemplateId}, {relatedOrgTemplateId}");
	}

	public unsafe void OfflineInitializeLargeSectFavorabilities(sbyte largeSectIndex, sbyte[] sectFavorabilities)
	{
		uint favorabilities = 0u;
		for (int i = 0; i < 15; i++)
		{
			uint favorability = (uint)sectFavorabilities[i];
			favorabilities |= favorability << i * 2;
		}
		fixed (sbyte* pLargeSectFavorabilities = _largeSectFavorabilities)
		{
			sbyte* pFavorabilities = pLargeSectFavorabilities + largeSectIndex * 4;
			*(uint*)pFavorabilities = favorabilities;
		}
	}

	[Obsolete]
	private sbyte GetLargeSectFavorability(sbyte largeSectIndex, sbyte relatedLargeSectIndex)
	{
		int index0 = largeSectIndex * 4 + relatedLargeSectIndex / 4;
		uint favorabilities = (uint)_largeSectFavorabilities[index0];
		int index1 = relatedLargeSectIndex % 4 * 2;
		return (sbyte)((favorabilities >> index1) & 3);
	}

	[Obsolete]
	private void SetLargeSectFavorability(DataContext context, sbyte largeSectIndex, sbyte relatedLargeSectIndex, sbyte favorability)
	{
		int index0 = largeSectIndex * 4 + relatedLargeSectIndex / 4;
		uint favorabilities = (uint)_largeSectFavorabilities[index0];
		int index1 = relatedLargeSectIndex % 4 * 2;
		favorabilities &= (uint)(~(3 << index1));
		favorabilities |= (uint)(favorability << index1);
		_largeSectFavorabilities[index0] = (sbyte)favorabilities;
		SetLargeSectFavorabilities(_largeSectFavorabilities, context);
	}

	public static sbyte GetRandomSectOrgTemplateId(IRandomSource random, sbyte gender = -1)
	{
		if (1 == 0)
		{
		}
		sbyte result = gender switch
		{
			-1 => _allSectOrgTemplateIds[random.Next(_allSectOrgTemplateIds.Length)], 
			0 => _femaleSectOrgTemplateIds[random.Next(_femaleSectOrgTemplateIds.Length)], 
			1 => _maleSectOrgTemplateIds[random.Next(_maleSectOrgTemplateIds.Length)], 
			_ => throw new Exception($"Unsupported gender {gender}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static sbyte GetGoodAtCombatSkillTypeSect(IRandomSource random, sbyte combatSkillType)
	{
		Span<sbyte> span = stackalloc sbyte[15];
		SpanList<sbyte> potentialSects = span;
		for (sbyte i = 0; i < 15; i++)
		{
			sbyte orgTemplateId = GetLargeSectTemplateId(i);
			OrganizationItem orgCfg = Config.Organization.Instance[orgTemplateId];
			if (orgCfg.CombatSkillTypes.Contains(combatSkillType))
			{
				potentialSects.Add(orgTemplateId);
			}
		}
		if (potentialSects.Count == 0)
		{
			return -1;
		}
		return potentialSects.GetRandom(random);
	}

	public static sbyte GetGoodAtLifeSkillTypeSect(IRandomSource random, sbyte lifeSkillType)
	{
		Span<sbyte> span = stackalloc sbyte[15];
		SpanList<sbyte> potentialSects = span;
		for (sbyte i = 0; i < 15; i++)
		{
			sbyte orgTemplateId = GetLargeSectTemplateId(i);
			OrganizationItem orgCfg = Config.Organization.Instance[orgTemplateId];
			if (orgCfg.LearnLifeSkillTypes.Contains(lifeSkillType))
			{
				potentialSects.Add(orgTemplateId);
			}
		}
		if (potentialSects.Count == 0)
		{
			return -1;
		}
		return potentialSects.GetRandom(random);
	}

	public static short GetRandomOrgMemberClothing(IRandomSource random, OrganizationMemberItem orgMemberConfig)
	{
		PresetEquipmentItem clothing = orgMemberConfig.Clothing;
		if (clothing.TemplateId >= 0)
		{
			return clothing.TemplateId;
		}
		return (short)((!random.NextBool()) ? 9 : 0);
	}

	public static sbyte GetRandomOrgMemberGender(IRandomSource random, sbyte orgTemplateId)
	{
		sbyte genderRestriction = Config.Organization.Instance[orgTemplateId].GenderRestriction;
		return (sbyte)((genderRestriction != -1) ? genderRestriction : (random.NextBool() ? 1 : 0));
	}

	public static bool MeetGenderRestriction(sbyte orgTemplateId, sbyte gender)
	{
		sbyte genderRestriction = Config.Organization.Instance[orgTemplateId].GenderRestriction;
		return genderRestriction == -1 || genderRestriction == gender;
	}

	public static bool IsSect(sbyte orgTemplateId)
	{
		return Config.Organization.Instance[orgTemplateId].IsSect;
	}

	public static short GetMemberId(sbyte orgTemplateId, sbyte grade)
	{
		return Config.Organization.Instance[orgTemplateId].Members[grade];
	}

	public static short[] GetMemberResourcesAdjust(short orgMemberId)
	{
		return OrganizationMember.Instance[orgMemberId].ResourcesAdjust;
	}

	public static short[] GetMemberMainAttributesAdjust(short orgMemberId)
	{
		return OrganizationMember.Instance[orgMemberId].MainAttributesAdjust;
	}

	public static short[] GetMemberLifeSkillsAdjust(short orgMemberId)
	{
		return OrganizationMember.Instance[orgMemberId].LifeSkillsAdjust;
	}

	public static short[] GetMemberCombatSkillsAdjust(short orgMemberId)
	{
		return OrganizationMember.Instance[orgMemberId].CombatSkillsAdjust;
	}

	public static string GetMonasticTitleSuffix(sbyte orgTemplateId, sbyte grade, sbyte gender)
	{
		OrganizationItem orgConfig = Config.Organization.Instance[orgTemplateId];
		short orgMemberId = orgConfig.Members[grade];
		OrganizationMemberItem orgMemberConfig = OrganizationMember.Instance[orgMemberId];
		return orgMemberConfig.MonasticTitleSuffixes[gender];
	}

	public static (short first, short last) GetSeniorityRange(sbyte seniorityGroupId)
	{
		LocalMonasticTitles config = LocalMonasticTitles.Instance;
		if (1 == 0)
		{
		}
		(short, short) result = seniorityGroupId switch
		{
			0 => (config.SeniorityShaolinStart, config.SeniorityShaolinEnd), 
			1 => (config.SeniorityEmeiStart, config.SeniorityEmeiEnd), 
			2 => (config.SeniorityWudangStart, config.SeniorityWudangEnd), 
			3 => (config.SeniorityRanshanStart, config.SeniorityRanshanEnd), 
			_ => throw new Exception($"Unsupported seniorityGroupId {seniorityGroupId}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static (short first, short last) GetMonasticTitleSuffixRange(sbyte seniorityGroupId)
	{
		LocalMonasticTitles config = LocalMonasticTitles.Instance;
		if (1 == 0)
		{
		}
		(short, short) result = seniorityGroupId switch
		{
			0 => (config.SuffixBuddhistStart, config.SuffixBuddhistEnd), 
			1 => (config.SuffixBuddhistStart, config.SuffixBuddhistEnd), 
			2 => (config.SuffixTaoistStart, config.SuffixTaoistEnd), 
			3 => (config.SuffixTaoistStart, config.SuffixTaoistEnd), 
			_ => throw new Exception($"Unsupported seniorityGroupId {seniorityGroupId}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static short GetNextSeniorityId(sbyte seniorityGroupId, short currSeniorityId)
	{
		(short first, short last) seniorityRange = GetSeniorityRange(seniorityGroupId);
		short firstId = seniorityRange.first;
		short lastId = seniorityRange.last;
		short nextId = (short)(currSeniorityId + 1);
		return (nextId > lastId) ? firstId : nextId;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OrganizationMemberItem GetOrgMemberConfig(OrganizationInfo orgInfo)
	{
		return orgInfo.GetOrgMemberConfig();
	}

	public static OrganizationMemberItem GetOrgMemberConfig(sbyte orgTemplateId, sbyte grade)
	{
		OrganizationItem orgConfig = Config.Organization.Instance[orgTemplateId];
		short orgMemberId = orgConfig.Members[grade];
		return OrganizationMember.Instance[orgMemberId];
	}

	public static short GetInitialAge(OrganizationMemberItem orgMemberCfg)
	{
		byte lifespanType = DomainManager.World.GetCharacterLifespanType();
		return orgMemberCfg.InitialAges[lifespanType];
	}

	public static short GetCharacterTemplateId(sbyte orgTemplateId, sbyte mapStateTemplateId, sbyte gender)
	{
		short charTemplateId = Config.Organization.Instance[orgTemplateId].CharTemplateIds[gender];
		return (charTemplateId >= 0) ? charTemplateId : MapDomain.GetCharacterTemplateId(mapStateTemplateId, gender);
	}

	public static bool CanInteractWithType(GameData.Domains.Character.Character character, sbyte type)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		OrganizationMemberItem config = GetOrgMemberConfig(orgInfo);
		if (config == null)
		{
			return false;
		}
		short currAge = character.GetCurrAge();
		if (currAge < config.IdentityActiveAge)
		{
			return false;
		}
		return config.IdentityInteractConfig.Contains(type);
	}

	private static void InitializeSectOrgTemplateIds()
	{
		List<sbyte> allSectIds = new List<sbyte>();
		List<sbyte> femaleSectIds = new List<sbyte>();
		List<sbyte> maleSectIds = new List<sbyte>();
		foreach (OrganizationItem item in (IEnumerable<OrganizationItem>)Config.Organization.Instance)
		{
			if (item.IsSect)
			{
				allSectIds.Add(item.TemplateId);
				switch (item.GenderRestriction)
				{
				case -1:
					maleSectIds.Add(item.TemplateId);
					femaleSectIds.Add(item.TemplateId);
					break;
				case 0:
					femaleSectIds.Add(item.TemplateId);
					break;
				case 1:
					maleSectIds.Add(item.TemplateId);
					break;
				}
			}
		}
		_allSectOrgTemplateIds = allSectIds.ToArray();
		_femaleSectOrgTemplateIds = femaleSectIds.ToArray();
		_maleSectOrgTemplateIds = maleSectIds.ToArray();
	}

	public void Test_ContributionInfluencePowerBonus()
	{
		SettlementTreasury treasury = new SettlementTreasury();
		treasury.Contributions.Add(0, Config.Accessory.Instance[(short)8].BaseValue);
		treasury.Contributions.Add(1, Config.Accessory.Instance[(short)8].BaseValue * 10);
		Tester.Assert(treasury.CalcBonusInfluencePower(0) == 110);
		Tester.Assert(treasury.CalcBonusInfluencePower(1) == 200);
		Tester.Assert(treasury.CalcBonusInfluencePower(2) == 100);
	}

	public SettlementTreasury GetTreasury(OrganizationInfo info)
	{
		if (info.OrgTemplateId == 16)
		{
			return DomainManager.Taiwu.GetTaiwuTreasury();
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(info.SettlementId);
		return settlement.GetTreasury(info.Grade);
	}

	public SettlementTreasury GetTreasury(short settlementId, sbyte layerIndex)
	{
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		return settlement.Treasuries.SettlementTreasuries[layerIndex];
	}

	public void RemoveTreasuryItem(DataContext context, short settlementId, ItemKey itemKey, int amount, bool deleteItem = false)
	{
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		settlement.RemoveItemFromTreasury(context, itemKey, amount, deleteItem);
	}

	public void StoreItemInTreasury(DataContext context, short settlementId, GameData.Domains.Character.Character character, ItemKey itemKey, int amount, sbyte layerIndex = -1, bool isBequest = false)
	{
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		sbyte orgTemplateId = settlement.GetOrgTemplateId();
		if (orgTemplateId == 16)
		{
			if (character.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
			{
				DomainManager.Taiwu.StoreItemInTreasury(context, itemKey, amount);
			}
			else
			{
				DomainManager.Taiwu.VillagerStoreItemInTreasury(context, character, itemKey, amount, addLifeSkillRecord: true, isBequest);
			}
		}
		else
		{
			settlement.StoreItemInTreasury(context, character, itemKey, amount, layerIndex, isBequest);
		}
	}

	public void TakeItemFromTreasury(DataContext context, short settlementId, GameData.Domains.Character.Character character, ItemKey itemKey, int amount, bool deleteItem = false)
	{
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		sbyte orgTemplateId = settlement.GetOrgTemplateId();
		if (orgTemplateId == 16)
		{
			if (character.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
			{
				DomainManager.Taiwu.TakeItemFromTreasury(context, itemKey, amount, deleteItem);
			}
			else
			{
				DomainManager.Taiwu.VillagerTakeItemFromTreasury(context, character, itemKey, amount);
			}
		}
		else
		{
			settlement.TakeItemFromTreasury(context, character, itemKey, amount);
		}
	}

	public void StoreResourceInTreasury(DataContext context, short settlementId, GameData.Domains.Character.Character character, sbyte resourceType, int amount, sbyte layerIndex = -1)
	{
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		sbyte orgTemplateId = settlement.GetOrgTemplateId();
		if (orgTemplateId == 16)
		{
			if (character.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
			{
				DomainManager.Taiwu.StoreResourceInTreasury(context, resourceType, amount);
			}
			else
			{
				DomainManager.Taiwu.VillagerStoreResourceInTreasury(context, character, resourceType, amount);
			}
		}
		else
		{
			settlement.StoreResourceInTreasury(context, character, resourceType, amount, layerIndex);
		}
	}

	public void TakeResourceFromTreasury(DataContext context, short settlementId, GameData.Domains.Character.Character character, sbyte resourceType, int amount, sbyte layerIndex = -1)
	{
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		sbyte orgTemplateId = settlement.GetOrgTemplateId();
		if (orgTemplateId == 16)
		{
			if (character.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
			{
				DomainManager.Taiwu.TakeResourceFromTreasury(context, resourceType, amount);
			}
			else
			{
				DomainManager.Taiwu.VillagerTakeResourceFromTreasury(context, character, resourceType, amount);
			}
		}
		else
		{
			settlement.TakeResourceFromTreasury(context, character, resourceType, amount, layerIndex);
		}
	}

	public int CalcResourceContribution(sbyte orgTemplateId, sbyte resourceType, int amount)
	{
		OrganizationMemberItem memberConfig = GetOrgMemberConfig(orgTemplateId, 8);
		long contribution = memberConfig.AdjustResourceValue(resourceType, amount) * GlobalConfig.Instance.ResourceContributionPercent / 100;
		return (int)Math.Clamp(contribution, -2147483648L, 2147483647L);
	}

	public int CalcItemContribution(Settlement settlement, ItemKey itemKey, int amount)
	{
		return (settlement.GetOrgTemplateId() != 16) ? settlement.CalcItemContribution(itemKey, amount) : DomainManager.Taiwu.CalcItemContribution(itemKey, amount);
	}

	public bool IsCharacterTreasuryGuard(int charId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return false;
		}
		if (character.GetOrganizationInfo().SettlementId < 0)
		{
			return false;
		}
		return GetSettlement(character.GetOrganizationInfo().SettlementId).Treasuries.IsGuard(charId);
	}

	public byte CharacterTreasuryGuardInfo(int charId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return 0;
		}
		if (character.GetOrganizationInfo().SettlementId < 0)
		{
			return 0;
		}
		byte res = GetSettlement(character.GetOrganizationInfo().SettlementId).Treasuries.GuardLevel(charId);
		if (res != 0 && Settlement.IsGuarding(charId))
		{
			return (byte)(res | 4);
		}
		return res;
	}

	public void InitializeOwnedItems()
	{
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		foreach (var (settlementId, _) in _settlements)
		{
			ItemKey key;
			int value;
			if (settlementId == taiwuSettlementId)
			{
				foreach (KeyValuePair<ItemKey, int> item in DomainManager.Taiwu.GetTaiwuTreasury().Inventory.Items)
				{
					item.Deconstruct(out key, out value);
					ItemKey itemKey = key;
					DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Treasury, settlementId);
				}
			}
			else
			{
				if (!DomainManager.Extra.TryGetElement_SettlementLayeredTreasuries(settlementId, out var treasuries))
				{
					continue;
				}
				SettlementTreasury[] settlementTreasuries = treasuries.SettlementTreasuries;
				foreach (SettlementTreasury treasury in settlementTreasuries)
				{
					foreach (KeyValuePair<ItemKey, int> item2 in treasury.Inventory.Items)
					{
						item2.Deconstruct(out key, out value);
						ItemKey itemKey2 = key;
						DomainManager.Item.SetOwner(itemKey2, ItemOwnerType.Treasury, settlementId);
					}
				}
			}
		}
	}

	public void InitializeSettlementTreasury()
	{
		_firstGuardCharId = -1;
		_itemSourceChanges = null;
		_currentTreasuryLayer = SettlementTreasuryLayers.Shallow;
	}

	public void SetCurrentTreasuryLayer(sbyte layerIndex)
	{
		_currentTreasuryLayer = (SettlementTreasuryLayers)layerIndex;
	}

	public sbyte GetCurrentTreasuryLayer()
	{
		return (sbyte)_currentTreasuryLayer;
	}

	public void SetSettlementTreasuryFirstGuardChar(int charId)
	{
		_firstGuardCharId = charId;
	}

	public void SetSettlementTreasuryAlterTime(DataContext context, short settlementId, byte time)
	{
		Settlement settlement = _settlements[settlementId];
		settlement.SetAlterTime(context, time);
	}

	public byte GetSettlementTreasuryAlterTime(DataContext context, short settlementId)
	{
		Settlement settlement = _settlements[settlementId];
		return settlement.GetAlterTime(context);
	}

	[DomainMethod]
	public SettlementTreasuryDisplayData GetSettlementTreasuryDisplayData(DataContext context, short settlementId, sbyte layerIndex)
	{
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		sbyte orgTemplateId = settlement.GetOrgTemplateId();
		OrganizationItem orgConfig = Config.Organization.Instance[orgTemplateId];
		SettlementTreasury settlementTreasury = settlement.Treasuries.GetTreasury(layerIndex);
		SettlementTreasuryDisplayData settlementTreasuryDisplayData = new SettlementTreasuryDisplayData
		{
			SettlementTreasury = settlementTreasury,
			AlertTime = settlement.Treasuries.AlertTime,
			SupplyLevel = settlement.GetSupplyLevel(),
			DebtOrSupport = settlement.CalcApprovingRate(),
			GuardianCharacterDisplayDataLow = settlement.GetGuardsDisplayData(context, 0),
			GuardianCharacterDisplayDataMid = settlement.GetGuardsDisplayData(context, 1),
			GuardianCharacterDisplayDataHigh = settlement.GetGuardsDisplayData(context, 2),
			OrgTemplateId = orgTemplateId,
			SupplyItems = settlement.GetSupplyItems(),
			SupplyCounts = settlement.GetSupplyRangeAndCounts().supplyCounts,
			InfluenceRefreshTime = (byte)Math.Clamp(settlement.GetInfluencePowerUpdateDate() - DomainManager.World.GetCurrDate(), 0, 256),
			SettlementNameRelatedData = settlement.GetNameRelatedData(),
			ResourceStatus = settlement.Treasuries.GetTreasuryResourceStatus()
		};
		if (orgConfig.IsSect)
		{
			sbyte sectMainStoryTaskStatus = DomainManager.Story.GetSectMainStoryTaskStatus(orgTemplateId);
			settlementTreasuryDisplayData.SectStoryEnding = sectMainStoryTaskStatus;
			short winner = GetLastMartialArtTournamentWinner();
			settlementTreasuryDisplayData.MartialArtTournamentResult = orgTemplateId == winner;
		}
		return settlementTreasuryDisplayData;
	}

	[DomainMethod]
	public static bool[] CheckSettlementGuardFavorabilityType(DataContext context, short settlementId)
	{
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		int layerCount = Enum.GetValues(typeof(SettlementTreasuryLayers)).Length;
		bool[] res = new bool[layerCount];
		res[0] = true;
		for (sbyte layerIndex = 1; layerIndex < layerCount; layerIndex++)
		{
			short favor = settlement.GetGuardsAndFavors(context, layerIndex).First().Favor;
			sbyte favorabilityType = FavorabilityType.GetFavorabilityType(favor);
			res[layerIndex] = favorabilityType >= 4;
		}
		return res;
	}

	[DomainMethod]
	public SettlementTreasuryRecordCollection GetSettlementTreasuryRecordCollection(DataContext context, short settlementId)
	{
		if (_settlementTreasuryRecordCollections.TryGetValue(settlementId, out var collection))
		{
			return collection;
		}
		collection = new SettlementTreasuryRecordCollection();
		AddElement_SettlementTreasuryRecordCollections(settlementId, collection, context);
		return collection;
	}

	[DomainMethod]
	public TransferableRecordDataBase GetReversedSettlementTreasuryRecordCollection(DataContext context, short settlementId)
	{
		SettlementTreasuryRecordCollection collection = GetSettlementTreasuryRecordCollection(context, settlementId);
		TransferableRecordDataBase data = new TransferableRecordDataBase();
		collection.ReadOrganizationRecordDataWithNormalOrder(data, GetParameters);
		LifeRecordDomain.PostProcess(data);
		return data;
		static string[] GetParameters(int recordType)
		{
			SettlementTreasuryRecordItem config = Config.SettlementTreasuryRecord.Instance[recordType];
			if (config != null)
			{
				return config.Parameters ?? Array.Empty<string>();
			}
			AdaptableLog.Warning($"Unable to render SettlementTreasuryRecord with template id {recordType}");
			return null;
		}
	}

	public void SetSettlementTreasuryRecordCollection(DataContext context, short settlementId, SettlementTreasuryRecordCollection collection)
	{
		SetElement_SettlementTreasuryRecordCollections(settlementId, collection, context);
	}

	public void ConfirmSettlementTreasuryOperation(DataContext context, int needAuthority, List<ItemSourceChange> itemSourceChanges, long totalValueWithAdvantage, ESettlementTreasuryOperationResult result)
	{
		_itemSourceChanges = itemSourceChanges;
		_operationResult = result;
		DomainManager.TaiwuEvent.SetListenerEventActionIntArg("ShopActionComplete", "OperationResult", (int)_operationResult);
		DomainManager.TaiwuEvent.SetListenerEventActionIntArg("ShopActionComplete", "NeedAuthority", needAuthority);
		int totalValue = (int)Math.Min(Math.Abs(totalValueWithAdvantage), 2147483647L);
		DomainManager.TaiwuEvent.SetListenerEventActionIntArg("ShopActionComplete", "TotalValue", totalValue);
		if (itemSourceChanges == null || itemSourceChanges.Count == 0)
		{
			return;
		}
		foreach (ItemSourceChange itemSourceChange in _itemSourceChanges)
		{
			foreach (var (itemKey2, countDelta) in itemSourceChange.Items)
			{
				if (countDelta >= 0)
				{
					continue;
				}
				if (ItemTemplateHelper.IsMiscResource(itemKey2.ItemType, itemKey2.TemplateId))
				{
					sbyte resourceType = ItemTemplateHelper.GetMiscResourceType(itemKey2.ItemType, itemKey2.TemplateId);
					if (itemSourceChange.ItemSourceTypeEnum != ItemSourceType.Treasury)
					{
						DomainManager.Taiwu.GetTaiwu().ChangeResource(context, resourceType, countDelta);
					}
					else
					{
						DomainManager.Taiwu.TakeResourceFromTreasury(context, resourceType, -countDelta);
					}
				}
				else
				{
					DomainManager.Taiwu.RemoveItem(context, itemKey2, -countDelta, itemSourceChange.ItemSourceType, deleteItem: false);
				}
			}
		}
	}

	[DomainMethod]
	public List<ItemSourceChange> GetLastSettlementTreasuryOperationData()
	{
		return _itemSourceChanges;
	}

	public (CharacterSet changeFavorCharIds, CharacterSet becomeEnemyCharIds, CharacterSet approveCharIds, CharacterSet disapproveCharIds) ApplySettlementTreasuryEventEffect(DataContext context, SettlementTreasuryEventEffectItem effectCfg, short settlementId, int totalWorth, sbyte layerIndex)
	{
		Settlement settlement = GetSettlement(settlementId);
		OrgMemberCollection members = settlement.GetMembers();
		if (effectCfg.TaiwuBounty >= 0)
		{
			PunishmentTypeItem punishment = PunishmentType.Instance[effectCfg.TaiwuBounty];
			if (punishment != null)
			{
				sbyte orgTemplateId = MapDomain.GetSectOrgTemplateIdByStateTemplateId(DomainManager.Map.GetStateTemplateIdByAreaId(settlement.GetLocation().AreaId));
				Sect sect = DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId) as Sect;
				sect.AddBounty(context, DomainManager.Taiwu.GetTaiwu(), punishment.Severity, effectCfg.TaiwuBounty);
			}
		}
		if (effectCfg.AlterTime > 0)
		{
			settlement.SetAlterTime(context, (byte)effectCfg.AlterTime);
		}
		HashSet<int> guardIds = settlement.Treasuries.GetTreasury(layerIndex).GuardIds.GetCollection();
		SettlementTreasuryEventEffectHelper.EffectArgs guardArgs = new SettlementTreasuryEventEffectHelper.EffectArgs(effectCfg, guardIds.Count, totalWorth, isGuard: true);
		ApplySettlementTreasuryEventEffect(context, guardIds, ref guardArgs);
		List<int> charIdList = ObjectPool<List<int>>.Instance.Get();
		charIdList.Clear();
		for (sbyte grade = 0; grade <= 8; grade++)
		{
			IEnumerable<int> gradeMembers = DomainManager.Character.ExcludeInfant(members.GetMembers(grade));
			foreach (int charId in gradeMembers)
			{
				if (!guardIds.Contains(charId))
				{
					charIdList.Add(charId);
				}
			}
		}
		CollectionUtils.Shuffle(context.Random, charIdList);
		SettlementTreasuryEventEffectHelper.EffectArgs effectArgs = new SettlementTreasuryEventEffectHelper.EffectArgs(effectCfg, charIdList.Count, totalWorth, isGuard: false);
		effectArgs.ChangeFavorCharIds = guardArgs.ChangeFavorCharIds;
		effectArgs.ApproveCharIds = guardArgs.ApproveCharIds;
		effectArgs.DisapproveCharIds = guardArgs.DisapproveCharIds;
		effectArgs.BecomeEnemyCharIds = guardArgs.BecomeEnemyCharIds;
		SettlementTreasuryEventEffectHelper.EffectArgs memberArgs = effectArgs;
		ApplySettlementTreasuryEventEffect(context, charIdList, ref memberArgs);
		Location location = settlement.GetLocation();
		int spiritualDebtChange = effectCfg.CalcSpiritualDebtChange(totalWorth);
		if (spiritualDebtChange != 0)
		{
			DomainManager.Extra.ChangeAreaSpiritualDebt(context, location.AreaId, spiritualDebtChange);
		}
		ObjectPool<List<int>>.Instance.Return(charIdList);
		_itemSourceChanges?.Clear();
		return (changeFavorCharIds: memberArgs.ChangeFavorCharIds, becomeEnemyCharIds: memberArgs.BecomeEnemyCharIds, approveCharIds: memberArgs.ApproveCharIds, disapproveCharIds: memberArgs.DisapproveCharIds);
	}

	public void ApplySettlementTreasuryEventEffect(DataContext context, IEnumerable<int> charIds, ref SettlementTreasuryEventEffectHelper.EffectArgs args)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = taiwuChar.GetId();
		int currChangeFavorCount = 0;
		int currDisapproveCount = 0;
		int currApproveCount = 0;
		int currBecomeEnemyCount = 0;
		foreach (int charId in charIds)
		{
			if (currChangeFavorCount >= args.ChangeFavorCount)
			{
				break;
			}
			if (!DomainManager.Character.TryGetElement_Objects(charId, out var guardChar) || guardChar.GetCreatingType() != 1 || DomainManager.Organization.GetPrisonerSect(charId) >= 0)
			{
				continue;
			}
			short prevFavorability = DomainManager.Character.GetFavorability(guardChar.GetId(), taiwuChar.GetId());
			if (prevFavorability == short.MinValue)
			{
				DomainManager.Character.TryCreateGeneralRelation(context, guardChar, taiwuChar);
				prevFavorability = DomainManager.Character.GetFavorability(guardChar.GetId(), taiwuChar.GetId());
			}
			int delta = DomainManager.Character.CalcFavorabilityDelta(charId, taiwuCharId, args.FavorChange, -1);
			if (delta == 0)
			{
				continue;
			}
			DomainManager.Character.DirectlyChangeFavorabilityOptional(context, guardChar, taiwuChar, args.FavorChange, 3);
			DomainManager.Character.AddFavorabilityChangeInstantNotification(guardChar, taiwuChar, delta > 0);
			args.ChangeFavorCharIds.Add(charId);
			if (currBecomeEnemyCount < args.BecomeEnemyCount && !DomainManager.Character.HasRelation(charId, taiwuCharId, 32768))
			{
				DomainManager.Character.AddRelation(context, charId, taiwuCharId, 32768);
				args.BecomeEnemyCharIds.Add(charId);
				currBecomeEnemyCount++;
			}
			SettlementCharacter settlementChar = GetSettlementCharacter(charId);
			if (settlementChar.GetApprovedTaiwu())
			{
				if (currDisapproveCount < args.DisapproveCount)
				{
					settlementChar.SetApprovedTaiwu(context, approve: false);
					args.DisapproveCharIds.Add(charId);
					currDisapproveCount++;
				}
			}
			else if (currApproveCount < args.ApproveCount)
			{
				settlementChar.SetApprovedTaiwu(context, approve: true);
				args.ApproveCharIds.Add(charId);
				currApproveCount++;
			}
			currChangeFavorCount++;
		}
	}

	public void SettleTreasuryOperate(DataContext context, short settlementId, bool takeEffect, bool startCombat, bool isSect, bool restart, byte settlementAlterTime)
	{
		if (settlementAlterTime > 0)
		{
			DomainManager.Organization.SetSettlementTreasuryAlterTime(context, settlementId, settlementAlterTime);
		}
		int charId = DomainManager.Taiwu.GetTaiwuCharId();
		ItemKey itemKey;
		int count;
		if (_itemSourceChanges != null)
		{
			foreach (ItemSourceChange itemSourceChange in _itemSourceChanges)
			{
				foreach (ItemKeyAndCount item in itemSourceChange.Items)
				{
					item.Deconstruct(out itemKey, out count);
					ItemKey itemKey2 = itemKey;
					int countDelta = count;
					if (countDelta >= 0)
					{
						continue;
					}
					if (ItemTemplateHelper.IsMiscResource(itemKey2.ItemType, itemKey2.TemplateId))
					{
						sbyte resourceType = ItemTemplateHelper.GetMiscResourceType(itemKey2.ItemType, itemKey2.TemplateId);
						if (itemSourceChange.ItemSourceTypeEnum != ItemSourceType.Treasury)
						{
							DomainManager.Taiwu.GetTaiwu().ChangeResource(context, resourceType, -countDelta);
						}
						else
						{
							DomainManager.Taiwu.StoreResourceInTreasury(context, resourceType, -countDelta);
						}
					}
					else
					{
						DomainManager.Taiwu.AddItem(context, itemKey2, -countDelta, itemSourceChange.ItemSourceType);
					}
				}
			}
		}
		if (restart)
		{
			return;
		}
		if (_operationResult == ESettlementTreasuryOperationResult.Steal)
		{
			SettlementTreasuryRecordCollection settlementTreasuryRecordCollection = DomainManager.Organization.GetSettlementTreasuryRecordCollection(context, settlementId);
			int currDate = DomainManager.World.GetCurrDate();
			if (isSect)
			{
				settlementTreasuryRecordCollection.AddPlunderSectTreasurySuccess(currDate, settlementId, charId);
			}
			else
			{
				settlementTreasuryRecordCollection.AddPlunderTownTreasurySuccess(currDate, settlementId, charId);
			}
			DomainManager.Organization.SetSettlementTreasuryRecordCollection(context, settlementId, settlementTreasuryRecordCollection);
		}
		if (takeEffect)
		{
			if (_itemSourceChanges != null)
			{
				foreach (ItemSourceChange itemSourceChange2 in _itemSourceChanges)
				{
					foreach (ItemKeyAndCount item2 in itemSourceChange2.Items)
					{
						item2.Deconstruct(out itemKey, out count);
						ItemKey itemKey3 = itemKey;
						int countDelta2 = count;
						if (countDelta2 > 0)
						{
							if (ItemTemplateHelper.IsMiscResource(itemKey3.ItemType, itemKey3.TemplateId))
							{
								GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
								sbyte resourceType2 = ItemTemplateHelper.GetMiscResourceType(itemKey3.ItemType, itemKey3.TemplateId);
								DomainManager.Organization.TakeResourceFromTreasury(context, settlementId, taiwu, resourceType2, countDelta2, GetCurrentTreasuryLayer());
								DomainManager.Taiwu.GetTaiwu().ChangeResource(context, resourceType2, countDelta2);
							}
							else
							{
								DomainManager.Organization.TakeItemFromTreasury(context, settlementId, DomainManager.Taiwu.GetTaiwu(), itemKey3, countDelta2);
								DomainManager.Taiwu.AddItem(context, itemKey3, countDelta2, itemSourceChange2.ItemSourceType);
							}
						}
						else
						{
							if (countDelta2 >= 0)
							{
								continue;
							}
							if (ItemTemplateHelper.IsMiscResource(itemKey3.ItemType, itemKey3.TemplateId))
							{
								GameData.Domains.Character.Character taiwu2 = DomainManager.Taiwu.GetTaiwu();
								sbyte resourceType3 = ItemTemplateHelper.GetMiscResourceType(itemKey3.ItemType, itemKey3.TemplateId);
								if (itemSourceChange2.ItemSourceTypeEnum != ItemSourceType.Treasury)
								{
									DomainManager.Taiwu.GetTaiwu().ChangeResource(context, resourceType3, countDelta2);
								}
								else
								{
									TakeResourceFromTreasury(context, DomainManager.Taiwu.GetTaiwu().GetOrganizationInfo().SettlementId, DomainManager.Taiwu.GetTaiwu(), resourceType3, -countDelta2, -1);
								}
								DomainManager.Organization.StoreResourceInTreasury(context, settlementId, taiwu2, resourceType3, -countDelta2, GetCurrentTreasuryLayer());
							}
							else
							{
								DomainManager.Taiwu.RemoveItem(context, itemKey3, -countDelta2, itemSourceChange2.ItemSourceType, deleteItem: false);
								DomainManager.Organization.StoreItemInTreasury(context, settlementId, DomainManager.Taiwu.GetTaiwu(), itemKey3, -countDelta2, GetCurrentTreasuryLayer());
							}
						}
					}
				}
			}
		}
		else if (startCombat && _operationResult == ESettlementTreasuryOperationResult.Steal)
		{
			SettlementTreasuryRecordCollection settlementTreasuryRecordCollection2 = DomainManager.Organization.GetSettlementTreasuryRecordCollection(context, settlementId);
			int currDate2 = DomainManager.World.GetCurrDate();
			if (isSect)
			{
				settlementTreasuryRecordCollection2.AddPlunderSectTreasuryFail(currDate2, settlementId, charId);
			}
			else
			{
				settlementTreasuryRecordCollection2.AddPlunderTownTreasuryFail(currDate2, settlementId, charId);
			}
			DomainManager.Organization.SetSettlementTreasuryRecordCollection(context, settlementId, settlementTreasuryRecordCollection2);
		}
		Exchange exchange = DomainManager.Taiwu.SettlementExchange;
		DomainManager.Taiwu.SettlementExchangeCost(context, exchange);
		InitializeSettlementTreasury();
		DomainManager.Taiwu.ClearSettlementExchange();
	}

	public sbyte CheckTreasuryLayerItemGradeRange(EventArgBox argBox)
	{
		return 1;
	}

	[DomainMethod]
	public void GmCmd_ClearSettlementTreasuryAlertTime(DataContext context, short settlementId)
	{
		if (settlementId >= 0)
		{
			SettlementLayeredTreasuries treasuries = GetSettlement(settlementId).Treasuries;
			treasuries.AlertTime = 0;
			DomainManager.Extra.SetTreasuries(context, settlementId, treasuries, needUpdateTotalValue: false);
		}
	}

	[DomainMethod]
	public void GmCmd_ClearSettlementTreasuryItemAndResource(DataContext context, short settlementId)
	{
		if (settlementId >= 0)
		{
			SettlementLayeredTreasuries treasuries = GetSettlement(settlementId).Treasuries;
			SettlementTreasury[] settlementTreasuries = treasuries.SettlementTreasuries;
			foreach (SettlementTreasury settlementTreasury in settlementTreasuries)
			{
				settlementTreasury?.Inventory?.Items?.Clear();
				settlementTreasury?.Resources.Initialize();
			}
			DomainManager.Extra.SetTreasuries(context, settlementId, treasuries, needUpdateTotalValue: true);
		}
	}

	[DomainMethod]
	public void GmCmd_UpdateSettlementTreasury(DataContext context, short settlementId)
	{
		if (_settlements.TryGetValue(settlementId, out var settlement))
		{
			settlement.UpdateTreasury(context);
		}
	}

	public OrganizationDomain()
		: base(19)
	{
		_sects = new Dictionary<short, Sect>(0);
		_civilianSettlements = new Dictionary<short, CivilianSettlement>(0);
		_nextSettlementId = 0;
		_sectCharacters = new Dictionary<int, SectCharacter>(0);
		_civilianSettlementCharacters = new Dictionary<int, CivilianSettlementCharacter>(0);
		_factions = new Dictionary<int, CharacterSet>(0);
		_largeSectFavorabilities = new sbyte[64];
		_martialArtTournamentPreparationInfoList = new List<MartialArtTournamentPreparationInfo>();
		_previousMartialArtTournamentHosts = new List<short>();
		_maxApprovingRateTemporaryBonus = new List<MaxApprovingRateTempBonus>();
		_prevMartialArtTournamentWinners = new List<short>();
		_settlementTreasuryRecordCollections = new Dictionary<short, SettlementTreasuryRecordCollection>(0);
		_settlementPrisonRecordCollections = new Dictionary<short, SettlementPrisonRecordCollection>(0);
		_settlementMemberFeatures = new Dictionary<short, SerializableList<SettlementMemberFeature>>(0);
		_settlementPrisons = new Dictionary<short, SettlementPrison>(0);
		_cityPunishmentSeverityCustomizeDict = new Dictionary<short, SerializableList<PunishmentSeverityCustomizeData>>(0);
		_currTournamentHost = 0;
		_lastTournamentFinishDate = 0;
		_tournamentPreparationEndDate = 0;
		HelperDataSects = new ObjectCollectionHelperData(3, 0, CacheInfluencesSects, _dataStatesSects, isArchive: true);
		HelperDataCivilianSettlements = new ObjectCollectionHelperData(3, 1, CacheInfluencesCivilianSettlements, _dataStatesCivilianSettlements, isArchive: true);
		HelperDataSectCharacters = new ObjectCollectionHelperData(3, 3, CacheInfluencesSectCharacters, _dataStatesSectCharacters, isArchive: true);
		HelperDataCivilianSettlementCharacters = new ObjectCollectionHelperData(3, 4, CacheInfluencesCivilianSettlementCharacters, _dataStatesCivilianSettlementCharacters, isArchive: true);
		OnInitializedDomainData();
	}

	public Sect GetElement_Sects(short objectId)
	{
		return _sects[objectId];
	}

	public bool TryGetElement_Sects(short objectId, out Sect element)
	{
		return _sects.TryGetValue(objectId, out element);
	}

	private void AddElement_Sects(short objectId, Sect instance)
	{
		instance.CollectionHelperData = HelperDataSects;
		instance.DataStatesOffset = _dataStatesSects.Create();
		_sects.Add(objectId, instance);
	}

	private void RemoveElement_Sects(short objectId)
	{
		if (_sects.TryGetValue(objectId, out var instance))
		{
			_dataStatesSects.Remove(instance.DataStatesOffset);
			_sects.Remove(objectId);
		}
	}

	private void ClearSects()
	{
		_dataStatesSects.Clear();
		_sects.Clear();
	}

	public int GetElementField_Sects(short objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_sects.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_Sects", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesSects.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetOrgTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetLocation(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetCulture(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxCulture(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetSafety(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxSafety(), dataPool);
		case 7:
			return GameData.Serializer.Serializer.Serialize(instance.GetPopulation(), dataPool);
		case 8:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxPopulation(), dataPool);
		case 9:
			return GameData.Serializer.Serializer.Serialize(instance.GetStandardOnStagePopulation(), dataPool);
		case 10:
			return GameData.Serializer.Serializer.Serialize(instance.GetMembers(), dataPool);
		case 11:
			return GameData.Serializer.Serializer.Serialize(instance.GetLackingCoreMembers(), dataPool);
		case 12:
			return GameData.Serializer.Serializer.Serialize(instance.GetApprovingRateUpperLimitBonus(), dataPool);
		case 13:
			return GameData.Serializer.Serializer.Serialize(instance.GetInfluencePowerUpdateDate(), dataPool);
		case 14:
			return GameData.Serializer.Serializer.Serialize(instance.GetMinSeniorityId(), dataPool);
		case 15:
			return GameData.Serializer.Serializer.Serialize(instance.GetAvailableMonasticTitleSuffixIds(), dataPool);
		case 16:
			return GameData.Serializer.Serializer.Serialize(instance.GetTaiwuExploreStatus(), dataPool);
		case 17:
			return GameData.Serializer.Serializer.Serialize(instance.GetSpiritualDebtInteractionOccurred(), dataPool);
		case 18:
			return GameData.Serializer.Serializer.Serialize(instance.GetTaiwuInvestmentForMartialArtTournament(), dataPool);
		case 19:
			return GameData.Serializer.Serializer.Serialize(instance.GetFunctionStatuses(), dataPool);
		case 20:
			return GameData.Serializer.Serializer.Serialize(instance.GetApprovingRateUpperLimitTempBonus(), dataPool);
		case 21:
			return GameData.Serializer.Serializer.Serialize(instance.GetMartialArtTournamentPreparations(), dataPool);
		default:
			if (fieldId >= 22)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_Sects(short objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_sects.TryGetValue(objectId, out var instance))
		{
			throw new Exception($"Failed to find element {objectId} with field {fieldId}");
		}
		switch (fieldId)
		{
		case 0:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 1:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 2:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetCulture(value, context);
			return;
		}
		case 4:
		{
			short value17 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value17);
			instance.SetMaxCulture(value17, context);
			return;
		}
		case 5:
		{
			short value16 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value16);
			instance.SetSafety(value16, context);
			return;
		}
		case 6:
		{
			short value15 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value15);
			instance.SetMaxSafety(value15, context);
			return;
		}
		case 7:
		{
			int value14 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value14);
			instance.SetPopulation(value14, context);
			return;
		}
		case 8:
		{
			int value13 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value13);
			instance.SetMaxPopulation(value13, context);
			return;
		}
		case 9:
		{
			int value12 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value12);
			instance.SetStandardOnStagePopulation(value12, context);
			return;
		}
		case 10:
		{
			OrgMemberCollection value11 = instance.GetMembers();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value11);
			instance.SetMembers(value11, context);
			return;
		}
		case 11:
		{
			OrgMemberCollection value10 = instance.GetLackingCoreMembers();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value10);
			instance.SetLackingCoreMembers(value10, context);
			return;
		}
		case 12:
		{
			short value9 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value9);
			instance.SetApprovingRateUpperLimitBonus(value9, context);
			return;
		}
		case 13:
		{
			int value8 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value8);
			instance.SetInfluencePowerUpdateDate(value8, context);
			return;
		}
		case 14:
		{
			short value7 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value7);
			instance.SetMinSeniorityId(value7, context);
			return;
		}
		case 15:
		{
			List<short> value6 = instance.GetAvailableMonasticTitleSuffixIds();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value6);
			instance.SetAvailableMonasticTitleSuffixIds(value6, context);
			return;
		}
		case 16:
		{
			byte value5 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetTaiwuExploreStatus(value5, context);
			return;
		}
		case 17:
		{
			bool value4 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetSpiritualDebtInteractionOccurred(value4, context);
			return;
		}
		case 18:
		{
			int[] value3 = instance.GetTaiwuInvestmentForMartialArtTournament();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetTaiwuInvestmentForMartialArtTournament(value3, context);
			return;
		}
		case 19:
		{
			SectFunctionStatuses value2 = default(SectFunctionStatuses);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value2);
			instance.SetFunctionStatuses(value2, context);
			return;
		}
		}
		if (fieldId >= 22)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 22)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_Sects(short objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_sects.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 22)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesSects.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesSects.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetOrgTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetLocation(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetCulture(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetMaxCulture(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetSafety(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetMaxSafety(), dataPool), 
			7 => GameData.Serializer.Serializer.Serialize(instance.GetPopulation(), dataPool), 
			8 => GameData.Serializer.Serializer.Serialize(instance.GetMaxPopulation(), dataPool), 
			9 => GameData.Serializer.Serializer.Serialize(instance.GetStandardOnStagePopulation(), dataPool), 
			10 => GameData.Serializer.Serializer.Serialize(instance.GetMembers(), dataPool), 
			11 => GameData.Serializer.Serializer.Serialize(instance.GetLackingCoreMembers(), dataPool), 
			12 => GameData.Serializer.Serializer.Serialize(instance.GetApprovingRateUpperLimitBonus(), dataPool), 
			13 => GameData.Serializer.Serializer.Serialize(instance.GetInfluencePowerUpdateDate(), dataPool), 
			14 => GameData.Serializer.Serializer.Serialize(instance.GetMinSeniorityId(), dataPool), 
			15 => GameData.Serializer.Serializer.Serialize(instance.GetAvailableMonasticTitleSuffixIds(), dataPool), 
			16 => GameData.Serializer.Serializer.Serialize(instance.GetTaiwuExploreStatus(), dataPool), 
			17 => GameData.Serializer.Serializer.Serialize(instance.GetSpiritualDebtInteractionOccurred(), dataPool), 
			18 => GameData.Serializer.Serializer.Serialize(instance.GetTaiwuInvestmentForMartialArtTournament(), dataPool), 
			19 => GameData.Serializer.Serializer.Serialize(instance.GetFunctionStatuses(), dataPool), 
			20 => GameData.Serializer.Serializer.Serialize(instance.GetApprovingRateUpperLimitTempBonus(), dataPool), 
			21 => GameData.Serializer.Serializer.Serialize(instance.GetMartialArtTournamentPreparations(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_Sects(short objectId, ushort fieldId)
	{
		if (_sects.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 22)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesSects.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesSects.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_Sects(short objectId, ushort fieldId)
	{
		if (!_sects.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 22)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesSects.IsModified(instance.DataStatesOffset, fieldId);
	}

	public CivilianSettlement GetElement_CivilianSettlements(short objectId)
	{
		return _civilianSettlements[objectId];
	}

	public bool TryGetElement_CivilianSettlements(short objectId, out CivilianSettlement element)
	{
		return _civilianSettlements.TryGetValue(objectId, out element);
	}

	private void AddElement_CivilianSettlements(short objectId, CivilianSettlement instance)
	{
		instance.CollectionHelperData = HelperDataCivilianSettlements;
		instance.DataStatesOffset = _dataStatesCivilianSettlements.Create();
		_civilianSettlements.Add(objectId, instance);
	}

	private void RemoveElement_CivilianSettlements(short objectId)
	{
		if (_civilianSettlements.TryGetValue(objectId, out var instance))
		{
			_dataStatesCivilianSettlements.Remove(instance.DataStatesOffset);
			_civilianSettlements.Remove(objectId);
		}
	}

	private void ClearCivilianSettlements()
	{
		_dataStatesCivilianSettlements.Clear();
		_civilianSettlements.Clear();
	}

	public int GetElementField_CivilianSettlements(short objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_civilianSettlements.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_CivilianSettlements", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesCivilianSettlements.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetOrgTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetLocation(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetCulture(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxCulture(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetSafety(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxSafety(), dataPool);
		case 7:
			return GameData.Serializer.Serializer.Serialize(instance.GetPopulation(), dataPool);
		case 8:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxPopulation(), dataPool);
		case 9:
			return GameData.Serializer.Serializer.Serialize(instance.GetStandardOnStagePopulation(), dataPool);
		case 10:
			return GameData.Serializer.Serializer.Serialize(instance.GetMembers(), dataPool);
		case 11:
			return GameData.Serializer.Serializer.Serialize(instance.GetLackingCoreMembers(), dataPool);
		case 12:
			return GameData.Serializer.Serializer.Serialize(instance.GetApprovingRateUpperLimitBonus(), dataPool);
		case 13:
			return GameData.Serializer.Serializer.Serialize(instance.GetInfluencePowerUpdateDate(), dataPool);
		case 14:
			return GameData.Serializer.Serializer.Serialize(instance.GetRandomNameId(), dataPool);
		case 15:
			return GameData.Serializer.Serializer.Serialize(instance.GetMainMorality(), dataPool);
		case 16:
			return GameData.Serializer.Serializer.Serialize(instance.GetApprovingRateUpperLimitTempBonus(), dataPool);
		default:
			if (fieldId >= 17)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_CivilianSettlements(short objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_civilianSettlements.TryGetValue(objectId, out var instance))
		{
			throw new Exception($"Failed to find element {objectId} with field {fieldId}");
		}
		switch (fieldId)
		{
		case 0:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 1:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 2:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetCulture(value, context);
			return;
		}
		case 4:
		{
			short value12 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value12);
			instance.SetMaxCulture(value12, context);
			return;
		}
		case 5:
		{
			short value11 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value11);
			instance.SetSafety(value11, context);
			return;
		}
		case 6:
		{
			short value10 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value10);
			instance.SetMaxSafety(value10, context);
			return;
		}
		case 7:
		{
			int value9 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value9);
			instance.SetPopulation(value9, context);
			return;
		}
		case 8:
		{
			int value8 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value8);
			instance.SetMaxPopulation(value8, context);
			return;
		}
		case 9:
		{
			int value7 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value7);
			instance.SetStandardOnStagePopulation(value7, context);
			return;
		}
		case 10:
		{
			OrgMemberCollection value6 = instance.GetMembers();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value6);
			instance.SetMembers(value6, context);
			return;
		}
		case 11:
		{
			OrgMemberCollection value5 = instance.GetLackingCoreMembers();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetLackingCoreMembers(value5, context);
			return;
		}
		case 12:
		{
			short value4 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetApprovingRateUpperLimitBonus(value4, context);
			return;
		}
		case 13:
		{
			int value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetInfluencePowerUpdateDate(value3, context);
			return;
		}
		case 14:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 15:
		{
			short value2 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value2);
			instance.SetMainMorality(value2, context);
			return;
		}
		}
		if (fieldId >= 17)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 17)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_CivilianSettlements(short objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_civilianSettlements.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 17)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesCivilianSettlements.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesCivilianSettlements.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetOrgTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetLocation(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetCulture(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetMaxCulture(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetSafety(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetMaxSafety(), dataPool), 
			7 => GameData.Serializer.Serializer.Serialize(instance.GetPopulation(), dataPool), 
			8 => GameData.Serializer.Serializer.Serialize(instance.GetMaxPopulation(), dataPool), 
			9 => GameData.Serializer.Serializer.Serialize(instance.GetStandardOnStagePopulation(), dataPool), 
			10 => GameData.Serializer.Serializer.Serialize(instance.GetMembers(), dataPool), 
			11 => GameData.Serializer.Serializer.Serialize(instance.GetLackingCoreMembers(), dataPool), 
			12 => GameData.Serializer.Serializer.Serialize(instance.GetApprovingRateUpperLimitBonus(), dataPool), 
			13 => GameData.Serializer.Serializer.Serialize(instance.GetInfluencePowerUpdateDate(), dataPool), 
			14 => GameData.Serializer.Serializer.Serialize(instance.GetRandomNameId(), dataPool), 
			15 => GameData.Serializer.Serializer.Serialize(instance.GetMainMorality(), dataPool), 
			16 => GameData.Serializer.Serializer.Serialize(instance.GetApprovingRateUpperLimitTempBonus(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_CivilianSettlements(short objectId, ushort fieldId)
	{
		if (_civilianSettlements.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 17)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesCivilianSettlements.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesCivilianSettlements.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_CivilianSettlements(short objectId, ushort fieldId)
	{
		if (!_civilianSettlements.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 17)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesCivilianSettlements.IsModified(instance.DataStatesOffset, fieldId);
	}

	private short GetNextSettlementId()
	{
		return _nextSettlementId;
	}

	private void SetNextSettlementId(short value, DataContext context)
	{
		_nextSettlementId = value;
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	public SectCharacter GetElement_SectCharacters(int objectId)
	{
		return _sectCharacters[objectId];
	}

	public bool TryGetElement_SectCharacters(int objectId, out SectCharacter element)
	{
		return _sectCharacters.TryGetValue(objectId, out element);
	}

	private void AddElement_SectCharacters(int objectId, SectCharacter instance)
	{
		instance.CollectionHelperData = HelperDataSectCharacters;
		instance.DataStatesOffset = _dataStatesSectCharacters.Create();
		_sectCharacters.Add(objectId, instance);
	}

	private void RemoveElement_SectCharacters(int objectId)
	{
		if (_sectCharacters.TryGetValue(objectId, out var instance))
		{
			_dataStatesSectCharacters.Remove(instance.DataStatesOffset);
			_sectCharacters.Remove(objectId);
		}
	}

	private void ClearSectCharacters()
	{
		_dataStatesSectCharacters.Clear();
		_sectCharacters.Clear();
	}

	public int GetElementField_SectCharacters(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_sectCharacters.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_SectCharacters", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesSectCharacters.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetOrgTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetSettlementId(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetApprovedTaiwu(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetInfluencePower(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetInfluencePowerBonus(), dataPool);
		default:
			if (fieldId >= 6)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_SectCharacters(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_sectCharacters.TryGetValue(objectId, out var instance))
		{
			throw new Exception($"Failed to find element {objectId} with field {fieldId}");
		}
		switch (fieldId)
		{
		case 0:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 1:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 2:
		{
			short value2 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value2);
			instance.SetSettlementId(value2, context);
			return;
		}
		case 3:
		{
			bool value = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetApprovedTaiwu(value, context);
			return;
		}
		case 4:
		{
			short value4 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetInfluencePower(value4, context);
			return;
		}
		case 5:
		{
			short value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetInfluencePowerBonus(value3, context);
			return;
		}
		}
		if (fieldId >= 6)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 6)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_SectCharacters(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_sectCharacters.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 6)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesSectCharacters.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesSectCharacters.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetOrgTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetSettlementId(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetApprovedTaiwu(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetInfluencePower(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetInfluencePowerBonus(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_SectCharacters(int objectId, ushort fieldId)
	{
		if (_sectCharacters.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 6)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesSectCharacters.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesSectCharacters.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_SectCharacters(int objectId, ushort fieldId)
	{
		if (!_sectCharacters.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 6)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesSectCharacters.IsModified(instance.DataStatesOffset, fieldId);
	}

	public CivilianSettlementCharacter GetElement_CivilianSettlementCharacters(int objectId)
	{
		return _civilianSettlementCharacters[objectId];
	}

	public bool TryGetElement_CivilianSettlementCharacters(int objectId, out CivilianSettlementCharacter element)
	{
		return _civilianSettlementCharacters.TryGetValue(objectId, out element);
	}

	private void AddElement_CivilianSettlementCharacters(int objectId, CivilianSettlementCharacter instance)
	{
		instance.CollectionHelperData = HelperDataCivilianSettlementCharacters;
		instance.DataStatesOffset = _dataStatesCivilianSettlementCharacters.Create();
		_civilianSettlementCharacters.Add(objectId, instance);
	}

	private void RemoveElement_CivilianSettlementCharacters(int objectId)
	{
		if (_civilianSettlementCharacters.TryGetValue(objectId, out var instance))
		{
			_dataStatesCivilianSettlementCharacters.Remove(instance.DataStatesOffset);
			_civilianSettlementCharacters.Remove(objectId);
		}
	}

	private void ClearCivilianSettlementCharacters()
	{
		_dataStatesCivilianSettlementCharacters.Clear();
		_civilianSettlementCharacters.Clear();
	}

	public int GetElementField_CivilianSettlementCharacters(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_civilianSettlementCharacters.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_CivilianSettlementCharacters", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesCivilianSettlementCharacters.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetOrgTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetSettlementId(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetApprovedTaiwu(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetInfluencePower(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetInfluencePowerBonus(), dataPool);
		default:
			if (fieldId >= 6)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_CivilianSettlementCharacters(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_civilianSettlementCharacters.TryGetValue(objectId, out var instance))
		{
			throw new Exception($"Failed to find element {objectId} with field {fieldId}");
		}
		switch (fieldId)
		{
		case 0:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 1:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 2:
		{
			short value2 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value2);
			instance.SetSettlementId(value2, context);
			return;
		}
		case 3:
		{
			bool value = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetApprovedTaiwu(value, context);
			return;
		}
		case 4:
		{
			short value4 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetInfluencePower(value4, context);
			return;
		}
		case 5:
		{
			short value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetInfluencePowerBonus(value3, context);
			return;
		}
		}
		if (fieldId >= 6)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 6)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_CivilianSettlementCharacters(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_civilianSettlementCharacters.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 6)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesCivilianSettlementCharacters.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesCivilianSettlementCharacters.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetOrgTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetSettlementId(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetApprovedTaiwu(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetInfluencePower(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetInfluencePowerBonus(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_CivilianSettlementCharacters(int objectId, ushort fieldId)
	{
		if (_civilianSettlementCharacters.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 6)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesCivilianSettlementCharacters.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesCivilianSettlementCharacters.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_CivilianSettlementCharacters(int objectId, ushort fieldId)
	{
		if (!_civilianSettlementCharacters.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 6)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesCivilianSettlementCharacters.IsModified(instance.DataStatesOffset, fieldId);
	}

	public CharacterSet GetElement_Factions(int elementId)
	{
		return _factions[elementId];
	}

	public bool TryGetElement_Factions(int elementId, out CharacterSet value)
	{
		return _factions.TryGetValue(elementId, out value);
	}

	private void AddElement_Factions(int elementId, CharacterSet value, DataContext context)
	{
		_factions.Add(elementId, value);
		_modificationsFactions.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void SetElement_Factions(int elementId, CharacterSet value, DataContext context)
	{
		_factions[elementId] = value;
		_modificationsFactions.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_Factions(int elementId, DataContext context)
	{
		_factions.Remove(elementId);
		_modificationsFactions.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void ClearFactions(DataContext context)
	{
		_factions.Clear();
		_modificationsFactions.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private sbyte[] GetLargeSectFavorabilities()
	{
		return _largeSectFavorabilities;
	}

	private void SetLargeSectFavorabilities(sbyte[] value, DataContext context)
	{
		_largeSectFavorabilities = value;
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	public List<MartialArtTournamentPreparationInfo> GetMartialArtTournamentPreparationInfoList()
	{
		Thread.MemoryBarrier();
		if (BaseGameDataDomain.IsCached(DataStates, 7))
		{
			return _martialArtTournamentPreparationInfoList;
		}
		List<MartialArtTournamentPreparationInfo> value = new List<MartialArtTournamentPreparationInfo>();
		CalcMartialArtTournamentPreparationInfoList(value);
		bool lockTaken = false;
		try
		{
			_spinLockMartialArtTournamentPreparationInfoList.Enter(ref lockTaken);
			_martialArtTournamentPreparationInfoList.Assign(value);
			BaseGameDataDomain.SetCached(DataStates, 7);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLockMartialArtTournamentPreparationInfoList.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _martialArtTournamentPreparationInfoList;
	}

	public List<short> GetPreviousMartialArtTournamentHosts()
	{
		return _previousMartialArtTournamentHosts;
	}

	public void SetPreviousMartialArtTournamentHosts(List<short> value, DataContext context)
	{
		_previousMartialArtTournamentHosts = value;
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private List<MaxApprovingRateTempBonus> GetMaxApprovingRateTemporaryBonus()
	{
		return _maxApprovingRateTemporaryBonus;
	}

	private void SetMaxApprovingRateTemporaryBonus(List<MaxApprovingRateTempBonus> value, DataContext context)
	{
		_maxApprovingRateTemporaryBonus = value;
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	private List<short> GetPrevMartialArtTournamentWinners()
	{
		return _prevMartialArtTournamentWinners;
	}

	private void SetPrevMartialArtTournamentWinners(List<short> value, DataContext context)
	{
		_prevMartialArtTournamentWinners = value;
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	public SettlementTreasuryRecordCollection GetElement_SettlementTreasuryRecordCollections(short elementId)
	{
		return _settlementTreasuryRecordCollections[elementId];
	}

	public bool TryGetElement_SettlementTreasuryRecordCollections(short elementId, out SettlementTreasuryRecordCollection value)
	{
		return _settlementTreasuryRecordCollections.TryGetValue(elementId, out value);
	}

	private void AddElement_SettlementTreasuryRecordCollections(short elementId, SettlementTreasuryRecordCollection value, DataContext context)
	{
		_settlementTreasuryRecordCollections.Add(elementId, value);
		_modificationsSettlementTreasuryRecordCollections.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	private void SetElement_SettlementTreasuryRecordCollections(short elementId, SettlementTreasuryRecordCollection value, DataContext context)
	{
		_settlementTreasuryRecordCollections[elementId] = value;
		_modificationsSettlementTreasuryRecordCollections.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SettlementTreasuryRecordCollections(short elementId, DataContext context)
	{
		_settlementTreasuryRecordCollections.Remove(elementId);
		_modificationsSettlementTreasuryRecordCollections.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	private void ClearSettlementTreasuryRecordCollections(DataContext context)
	{
		_settlementTreasuryRecordCollections.Clear();
		_modificationsSettlementTreasuryRecordCollections.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	public SettlementPrisonRecordCollection GetElement_SettlementPrisonRecordCollections(short elementId)
	{
		return _settlementPrisonRecordCollections[elementId];
	}

	public bool TryGetElement_SettlementPrisonRecordCollections(short elementId, out SettlementPrisonRecordCollection value)
	{
		return _settlementPrisonRecordCollections.TryGetValue(elementId, out value);
	}

	private void AddElement_SettlementPrisonRecordCollections(short elementId, SettlementPrisonRecordCollection value, DataContext context)
	{
		_settlementPrisonRecordCollections.Add(elementId, value);
		_modificationsSettlementPrisonRecordCollections.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	private void SetElement_SettlementPrisonRecordCollections(short elementId, SettlementPrisonRecordCollection value, DataContext context)
	{
		_settlementPrisonRecordCollections[elementId] = value;
		_modificationsSettlementPrisonRecordCollections.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SettlementPrisonRecordCollections(short elementId, DataContext context)
	{
		_settlementPrisonRecordCollections.Remove(elementId);
		_modificationsSettlementPrisonRecordCollections.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	private void ClearSettlementPrisonRecordCollections(DataContext context)
	{
		_settlementPrisonRecordCollections.Clear();
		_modificationsSettlementPrisonRecordCollections.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	private SerializableList<SettlementMemberFeature> GetElement_SettlementMemberFeatures(short elementId)
	{
		return _settlementMemberFeatures[elementId];
	}

	private bool TryGetElement_SettlementMemberFeatures(short elementId, out SerializableList<SettlementMemberFeature> value)
	{
		return _settlementMemberFeatures.TryGetValue(elementId, out value);
	}

	private void AddElement_SettlementMemberFeatures(short elementId, SerializableList<SettlementMemberFeature> value, DataContext context)
	{
		_settlementMemberFeatures.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	private void SetElement_SettlementMemberFeatures(short elementId, SerializableList<SettlementMemberFeature> value, DataContext context)
	{
		_settlementMemberFeatures[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SettlementMemberFeatures(short elementId, DataContext context)
	{
		_settlementMemberFeatures.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	private void ClearSettlementMemberFeatures(DataContext context)
	{
		_settlementMemberFeatures.Clear();
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	public SettlementPrison GetElement_SettlementPrisons(short elementId)
	{
		return _settlementPrisons[elementId];
	}

	public bool TryGetElement_SettlementPrisons(short elementId, out SettlementPrison value)
	{
		return _settlementPrisons.TryGetValue(elementId, out value);
	}

	private void AddElement_SettlementPrisons(short elementId, SettlementPrison value, DataContext context)
	{
		_settlementPrisons.Add(elementId, value);
		_modificationsSettlementPrisons.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	private void SetElement_SettlementPrisons(short elementId, SettlementPrison value, DataContext context)
	{
		_settlementPrisons[elementId] = value;
		_modificationsSettlementPrisons.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SettlementPrisons(short elementId, DataContext context)
	{
		_settlementPrisons.Remove(elementId);
		_modificationsSettlementPrisons.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	private void ClearSettlementPrisons(DataContext context)
	{
		_settlementPrisons.Clear();
		_modificationsSettlementPrisons.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	public SerializableList<PunishmentSeverityCustomizeData> GetElement_CityPunishmentSeverityCustomizeDict(short elementId)
	{
		return _cityPunishmentSeverityCustomizeDict[elementId];
	}

	public bool TryGetElement_CityPunishmentSeverityCustomizeDict(short elementId, out SerializableList<PunishmentSeverityCustomizeData> value)
	{
		return _cityPunishmentSeverityCustomizeDict.TryGetValue(elementId, out value);
	}

	private void AddElement_CityPunishmentSeverityCustomizeDict(short elementId, SerializableList<PunishmentSeverityCustomizeData> value, DataContext context)
	{
		_cityPunishmentSeverityCustomizeDict.Add(elementId, value);
		_modificationsCityPunishmentSeverityCustomizeDict.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	private void SetElement_CityPunishmentSeverityCustomizeDict(short elementId, SerializableList<PunishmentSeverityCustomizeData> value, DataContext context)
	{
		_cityPunishmentSeverityCustomizeDict[elementId] = value;
		_modificationsCityPunishmentSeverityCustomizeDict.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_CityPunishmentSeverityCustomizeDict(short elementId, DataContext context)
	{
		_cityPunishmentSeverityCustomizeDict.Remove(elementId);
		_modificationsCityPunishmentSeverityCustomizeDict.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	private void ClearCityPunishmentSeverityCustomizeDict(DataContext context)
	{
		_cityPunishmentSeverityCustomizeDict.Clear();
		_modificationsCityPunishmentSeverityCustomizeDict.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	public short GetCurrTournamentHost()
	{
		return _currTournamentHost;
	}

	public void SetCurrTournamentHost(short value, DataContext context)
	{
		_currTournamentHost = value;
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	public int GetLastTournamentFinishDate()
	{
		return _lastTournamentFinishDate;
	}

	public void SetLastTournamentFinishDate(int value, DataContext context)
	{
		_lastTournamentFinishDate = value;
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	public int GetTournamentPreparationEndDate()
	{
		return _tournamentPreparationEndDate;
	}

	public void SetTournamentPreparationEndDate(int value, DataContext context)
	{
		_tournamentPreparationEndDate = value;
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
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
		archive.WriteSingleValueUnmanaged((ushort)18);
		archive.WriteDomainDataMeta(0);
		archive.WriteObjectCollectionUnmanagedKey(_sects);
		archive.WriteDomainDataMeta(1);
		archive.WriteObjectCollectionUnmanagedKey(_civilianSettlements);
		archive.WriteDomainDataMeta(2);
		archive.WriteSingleValueUnmanaged(_nextSettlementId);
		archive.WriteDomainDataMeta(3);
		archive.WriteObjectCollectionUnmanagedKey(_sectCharacters);
		archive.WriteDomainDataMeta(4);
		archive.WriteObjectCollectionUnmanagedKey(_civilianSettlementCharacters);
		archive.WriteDomainDataMeta(5);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_factions);
		archive.WriteDomainDataMeta(6);
		archive.WriteSingleValueUnmanagedArray(_largeSectFavorabilities);
		archive.WriteDomainDataMeta(8);
		archive.WriteSingleValueUnmanagedList(_previousMartialArtTournamentHosts);
		archive.WriteDomainDataMeta(9);
		archive.WriteSingleValueCustomList(_maxApprovingRateTemporaryBonus);
		archive.WriteDomainDataMeta(10);
		archive.WriteSingleValueUnmanagedList(_prevMartialArtTournamentWinners);
		archive.WriteDomainDataMeta(11);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_settlementTreasuryRecordCollections);
		archive.WriteDomainDataMeta(12);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_settlementPrisonRecordCollections);
		archive.WriteDomainDataMeta(13);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_settlementMemberFeatures);
		archive.WriteDomainDataMeta(14);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_settlementPrisons);
		archive.WriteDomainDataMeta(15);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_cityPunishmentSeverityCustomizeDict);
		archive.WriteDomainDataMeta(16);
		archive.WriteSingleValueUnmanaged(_currTournamentHost);
		archive.WriteDomainDataMeta(17);
		archive.WriteSingleValueUnmanaged(_lastTournamentFinishDate);
		archive.WriteDomainDataMeta(18);
		archive.WriteSingleValueUnmanaged(_tournamentPreparationEndDate);
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
				archive.ReadObjectCollectionUnmanagedKey(_sects);
				break;
			case 1:
				archive.ReadObjectCollectionUnmanagedKey(_civilianSettlements);
				break;
			case 2:
				archive.ReadSingleValueUnmanaged(ref _nextSettlementId);
				break;
			case 3:
				archive.ReadObjectCollectionUnmanagedKey(_sectCharacters);
				break;
			case 4:
				archive.ReadObjectCollectionUnmanagedKey(_civilianSettlementCharacters);
				break;
			case 5:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_factions);
				break;
			case 6:
				archive.ReadSingleValueUnmanagedArray(ref _largeSectFavorabilities);
				break;
			case 8:
				archive.ReadSingleValueUnmanagedList(ref _previousMartialArtTournamentHosts);
				break;
			case 9:
				archive.ReadSingleValueCustomList(ref _maxApprovingRateTemporaryBonus);
				break;
			case 10:
				archive.ReadSingleValueUnmanagedList(ref _prevMartialArtTournamentWinners);
				break;
			case 11:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_settlementTreasuryRecordCollections);
				break;
			case 12:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_settlementPrisonRecordCollections);
				break;
			case 13:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_settlementMemberFeatures);
				break;
			case 14:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_settlementPrisons);
				break;
			case 15:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_cityPunishmentSeverityCustomizeDict);
				break;
			case 16:
				archive.ReadSingleValueUnmanaged(ref _currTournamentHost);
				break;
			case 17:
				archive.ReadSingleValueUnmanaged(ref _lastTournamentFinishDate);
				break;
			case 18:
				archive.ReadSingleValueUnmanaged(ref _tournamentPreparationEndDate);
				break;
			default:
				throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
			}
			RecordLoadedDomainData(domainDataMeta.DataId);
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(3);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			return GetElementField_Sects((short)subId0, (ushort)subId1, dataPool, resetModified);
		case 1:
			return GetElementField_CivilianSettlements((short)subId0, (ushort)subId1, dataPool, resetModified);
		case 2:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 3:
			return GetElementField_SectCharacters((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 4:
			return GetElementField_CivilianSettlementCharacters((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 5:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
				_modificationsFactions.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_factions, dataPool);
		case 6:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 7:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
			}
			return GameData.Serializer.Serializer.Serialize(GetMartialArtTournamentPreparationInfoList(), dataPool);
		case 8:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
			}
			return GameData.Serializer.Serializer.Serialize(_previousMartialArtTournamentHosts, dataPool);
		case 9:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 10:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 11:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
				_modificationsSettlementTreasuryRecordCollections.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_settlementTreasuryRecordCollections, dataPool);
		case 12:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 12);
				_modificationsSettlementPrisonRecordCollections.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_settlementPrisonRecordCollections, dataPool);
		case 13:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 14:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 14);
				_modificationsSettlementPrisons.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_settlementPrisons, dataPool);
		case 15:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 15);
				_modificationsCityPunishmentSeverityCustomizeDict.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_cityPunishmentSeverityCustomizeDict, dataPool);
		case 16:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 16);
			}
			return GameData.Serializer.Serializer.Serialize(_currTournamentHost, dataPool);
		case 17:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 17);
			}
			return GameData.Serializer.Serializer.Serialize(_lastTournamentFinishDate, dataPool);
		case 18:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 18);
			}
			return GameData.Serializer.Serializer.Serialize(_tournamentPreparationEndDate, dataPool);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void SetData(ushort dataId, ulong subId0, uint subId1, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		switch (dataId)
		{
		case 0:
			SetElementField_Sects((short)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 1:
			SetElementField_CivilianSettlements((short)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 2:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 3:
			SetElementField_SectCharacters((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 4:
			SetElementField_CivilianSettlementCharacters((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 5:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 6:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 7:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 8:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _previousMartialArtTournamentHosts);
			SetPreviousMartialArtTournamentHosts(_previousMartialArtTournamentHosts, context);
			break;
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
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _currTournamentHost);
			SetCurrTournamentHost(_currTournamentHost, context);
			break;
		case 17:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _lastTournamentFinishDate);
			SetLastTournamentFinishDate(_lastTournamentFinishDate, context);
			break;
		case 18:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _tournamentPreparationEndDate);
			SetTournamentPreparationEndDate(_tournamentPreparationEndDate, context);
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
			int argsCount19 = operation.ArgsCount;
			int num19 = argsCount19;
			if (num19 == 1)
			{
				short settlementId10 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId10);
				SettlementDisplayData returnValue15 = GetDisplayData(settlementId10);
				return GameData.Serializer.Serializer.Serialize(returnValue15, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 1)
			{
				List<short> settlementIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementIds);
				List<SettlementNameRelatedData> returnValue5 = GetSettlementNameRelatedData(settlementIds);
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
		{
			int argsCount23 = operation.ArgsCount;
			int num23 = argsCount23;
			if (num23 == 1)
			{
				short settlementId13 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId13);
				List<CharacterDisplayData> returnValue18 = GetSettlementMembers(settlementId13);
				return GameData.Serializer.Serializer.Serialize(returnValue18, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 3:
		{
			int argsCount31 = operation.ArgsCount;
			int num31 = argsCount31;
			if (num31 == 1)
			{
				sbyte organizationTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref organizationTemplateId);
				OrganizationCombatSkillsDisplayData returnValue26 = GetOrganizationCombatSkillsDisplayData(organizationTemplateId);
				return GameData.Serializer.Serializer.Serialize(returnValue26, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 4:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 1)
			{
				sbyte orgTemplateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgTemplateId2);
				int[] returnValue11 = GetSectPreparationForMartialArtTournament(orgTemplateId2);
				return GameData.Serializer.Serializer.Serialize(returnValue11, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 5:
			if (operation.ArgsCount == 0)
			{
				short returnValue24 = GetMartialArtTournamentCurrentHostSettlementId();
				return GameData.Serializer.Serializer.Serialize(returnValue24, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 6:
			if (operation.ArgsCount == 0)
			{
				GmCmd_SetAllSettlementInformationVisited(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 7:
			if (operation.ArgsCount == 0)
			{
				List<List<CharacterDisplayData>> returnValue2 = GmCmd_GetAllFactionMembers();
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 8:
		{
			int argsCount25 = operation.ArgsCount;
			int num25 = argsCount25;
			if (num25 == 2)
			{
				short areaId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId2);
				short blockId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockId2);
				short returnValue19 = GetSettlementIdByAreaIdAndBlockId(areaId2, blockId2);
				return GameData.Serializer.Serializer.Serialize(returnValue19, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 9:
		{
			int argsCount16 = operation.ArgsCount;
			int num16 = argsCount16;
			if (num16 == 2)
			{
				short areaId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref areaId);
				short blockId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref blockId);
				ShortPair returnValue13 = GetCultureByAreaIdAndBlockId(areaId, blockId);
				return GameData.Serializer.Serializer.Serialize(returnValue13, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 10:
			if (operation.ArgsCount == 0)
			{
				int returnValue7 = CalcApprovingRateEffectAuthorityGain();
				return GameData.Serializer.Serializer.Serialize(returnValue7, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 11:
		{
			int argsCount33 = operation.ArgsCount;
			int num33 = argsCount33;
			if (num33 == 2)
			{
				short settlementId17 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId17);
				sbyte layerIndex = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref layerIndex);
				SettlementTreasuryDisplayData returnValue28 = GetSettlementTreasuryDisplayData(context, settlementId17, layerIndex);
				return GameData.Serializer.Serializer.Serialize(returnValue28, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
		{
			int argsCount28 = operation.ArgsCount;
			int num28 = argsCount28;
			if (num28 == 1)
			{
				short settlementId16 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId16);
				SettlementTreasuryRecordCollection returnValue22 = GetSettlementTreasuryRecordCollection(context, settlementId16);
				return GameData.Serializer.Serializer.Serialize(returnValue22, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 13:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				List<InscribedCharacterKey> inscribedCharList2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref inscribedCharList2);
				SetInscribedCharactersForCreation(context, inscribedCharList2);
				return -1;
			}
			case 2:
			{
				List<InscribedCharacterKey> inscribedCharList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref inscribedCharList);
				List<short> ages = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref ages);
				SetInscribedCharactersForCreation(context, inscribedCharList, ages);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 14:
		{
			int argsCount20 = operation.ArgsCount;
			int num20 = argsCount20;
			if (num20 == 1)
			{
				short settlementId11 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId11);
				GmCmd_UpdateSettlementTreasury(context, settlementId11);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 15:
		{
			int argsCount14 = operation.ArgsCount;
			int num14 = argsCount14;
			if (num14 == 1)
			{
				short settlementId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId8);
				GmCmd_ClearSettlementTreasuryAlertTime(context, settlementId8);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 16:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 1)
			{
				short settlementId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId6);
				GmCmd_ClearSettlementTreasuryItemAndResource(context, settlementId6);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 17:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 1)
			{
				short settlementId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId3);
				GmCmd_ForceUpdateTreasuryGuards(context, settlementId3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 18:
		{
			int argsCount32 = operation.ArgsCount;
			int num32 = argsCount32;
			if (num32 == 5)
			{
				sbyte orgTemplateId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgTemplateId7);
				int charId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId2);
				sbyte punishmentSeverity2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref punishmentSeverity2);
				short punishmentType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref punishmentType2);
				int duration2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref duration2);
				AddSectBounty(context, orgTemplateId7, charId2, punishmentSeverity2, punishmentType2, duration2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 19:
		{
			int argsCount30 = operation.ArgsCount;
			int num30 = argsCount30;
			if (num30 == 5)
			{
				sbyte orgTemplateId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgTemplateId6);
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				sbyte punishmentSeverity = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref punishmentSeverity);
				short punishmentType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref punishmentType);
				int duration = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref duration);
				AddSectPrisoner(context, orgTemplateId6, charId, punishmentSeverity, punishmentType, duration);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 20:
		{
			int argsCount26 = operation.ArgsCount;
			int num26 = argsCount26;
			if (num26 == 1)
			{
				short settlementId14 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId14);
				SettlementPrisonDisplayData returnValue20 = GetSettlementPrisonDisplayData(context, settlementId14);
				return GameData.Serializer.Serializer.Serialize(returnValue20, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 21:
		{
			int argsCount22 = operation.ArgsCount;
			int num22 = argsCount22;
			if (num22 == 1)
			{
				short settlementId12 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId12);
				SettlementBountyDisplayData returnValue17 = GetSettlementBountyDisplayData(settlementId12);
				return GameData.Serializer.Serializer.Serialize(returnValue17, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 22:
		{
			int argsCount17 = operation.ArgsCount;
			int num17 = argsCount17;
			if (num17 == 1)
			{
				short settlementId9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId9);
				SettlementPrisonRecordCollection returnValue14 = GetSettlementPrisonRecordCollection(context, settlementId9);
				return GameData.Serializer.Serializer.Serialize(returnValue14, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 23:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 1)
			{
				short settlementId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId7);
				GmCmd_ForceUpdateInfluencePower(context, settlementId7);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 24:
		{
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 1)
			{
				List<int> characterIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterIds);
				SettlementBountyDisplayData returnValue9 = GetBountyCharacterDisplayDataFromCharacterList(characterIds);
				return GameData.Serializer.Serializer.Serialize(returnValue9, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 25:
			if (operation.ArgsCount == 0)
			{
				ForceUpdateTaiwuVillager(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 26:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 1)
			{
				sbyte orgTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgTemplateId);
				bool returnValue3 = IsTaiwuSectFugitive(orgTemplateId);
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 27:
			if (operation.ArgsCount == 0)
			{
				short returnValue27 = GetOrganizationTemplateIdOfTaiwuLocation();
				return GameData.Serializer.Serializer.Serialize(returnValue27, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 28:
			if (operation.ArgsCount == 0)
			{
				List<ItemSourceChange> returnValue25 = GetLastSettlementTreasuryOperationData();
				return GameData.Serializer.Serializer.Serialize(returnValue25, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 29:
		{
			int argsCount29 = operation.ArgsCount;
			int num29 = argsCount29;
			if (num29 == 1)
			{
				int prisonType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref prisonType);
				List<CharacterDisplayData> returnValue23 = GmCmd_GetSettlementPrisoner(context, prisonType);
				return GameData.Serializer.Serializer.Serialize(returnValue23, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 30:
		{
			int argsCount27 = operation.ArgsCount;
			int num27 = argsCount27;
			if (num27 == 1)
			{
				short settlementId15 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId15);
				bool[] returnValue21 = CheckSettlementGuardFavorabilityType(context, settlementId15);
				return GameData.Serializer.Serializer.Serialize(returnValue21, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 31:
		{
			int argsCount24 = operation.ArgsCount;
			int num24 = argsCount24;
			if (num24 == 2)
			{
				sbyte orgTemplateId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgTemplateId5);
				bool approvedTaiwu = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref approvedTaiwu);
				GmCmd_SetAllSettlementMemberApprovedTaiwu(context, orgTemplateId5, approvedTaiwu);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 32:
		{
			int argsCount21 = operation.ArgsCount;
			int num21 = argsCount21;
			if (num21 == 2)
			{
				sbyte orgTemplateId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgTemplateId4);
				SectFunctionStatuses.SectFunctionStatusType statusType2 = SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref statusType2);
				bool returnValue16 = GetSectFunctionStatus(orgTemplateId4, statusType2);
				return GameData.Serializer.Serializer.Serialize(returnValue16, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 33:
		{
			int argsCount18 = operation.ArgsCount;
			int num18 = argsCount18;
			if (num18 == 3)
			{
				sbyte orgTemplateId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgTemplateId3);
				SectFunctionStatuses.SectFunctionStatusType statusType = SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref statusType);
				bool value = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value);
				GmCmd_SetSectFunctionStatus(context, orgTemplateId3, statusType, value);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 34:
		{
			int argsCount15 = operation.ArgsCount;
			int num15 = argsCount15;
			if (num15 == 4)
			{
				sbyte stateTemplateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref stateTemplateId2);
				bool isSect2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isSect2);
				short punishmentTypeTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref punishmentTypeTemplateId);
				sbyte customizedPunishmentSeverityTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref customizedPunishmentSeverityTemplateId);
				UpdateCityPunishmentSeverityCustomizeData(context, stateTemplateId2, isSect2, punishmentTypeTemplateId, customizedPunishmentSeverityTemplateId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 35:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 2)
			{
				sbyte stateTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref stateTemplateId);
				bool isSect = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isSect);
				int returnValue12 = GetCustomizePunishmentSeverityCost(stateTemplateId, isSect);
				return GameData.Serializer.Serializer.Serialize(returnValue12, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 36:
		{
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 1)
			{
				int villagerHeadCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref villagerHeadCharId);
				bool returnValue10 = WillCustomizePunishmentBreakWithoutVillagerHead(villagerHeadCharId);
				return GameData.Serializer.Serializer.Serialize(returnValue10, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 37:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 1)
			{
				short settlementId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId5);
				SettlementPopulationDisplayData returnValue8 = GetSettlementPopulationDisplayData(settlementId5);
				return GameData.Serializer.Serializer.Serialize(returnValue8, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 38:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 1)
			{
				short settlementId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId4);
				TransferableRecordDataBase returnValue6 = GetReversedSettlementPrisonRecordCollection(context, settlementId4);
				return GameData.Serializer.Serializer.Serialize(returnValue6, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 39:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 1)
			{
				short settlementId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId2);
				TransferableRecordDataBase returnValue4 = GetReversedSettlementTreasuryRecordCollection(context, settlementId2);
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 40:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 1)
			{
				short settlementId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref settlementId);
				OrganizationMemberDisplayDataForGeneralScrollList[] returnValue = GetSettlementApproveTaiwuMembers(context, settlementId);
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
			_modificationsFactions.ChangeRecording(monitoring);
			break;
		case 6:
			break;
		case 7:
			break;
		case 8:
			break;
		case 9:
			break;
		case 10:
			break;
		case 11:
			_modificationsSettlementTreasuryRecordCollections.ChangeRecording(monitoring);
			break;
		case 12:
			_modificationsSettlementPrisonRecordCollections.ChangeRecording(monitoring);
			break;
		case 13:
			break;
		case 14:
			_modificationsSettlementPrisons.ChangeRecording(monitoring);
			break;
		case 15:
			_modificationsCityPunishmentSeverityCustomizeDict.ChangeRecording(monitoring);
			break;
		case 16:
			break;
		case 17:
			break;
		case 18:
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
			return CheckModified_Sects((short)subId0, (ushort)subId1, dataPool);
		case 1:
			return CheckModified_CivilianSettlements((short)subId0, (ushort)subId1, dataPool);
		case 2:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 3:
			return CheckModified_SectCharacters((int)subId0, (ushort)subId1, dataPool);
		case 4:
			return CheckModified_CivilianSettlementCharacters((int)subId0, (ushort)subId1, dataPool);
		case 5:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 5))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 5);
			int offset2 = GameData.Serializer.Serializer.SerializeModifications(_factions, dataPool, _modificationsFactions);
			_modificationsFactions.Reset();
			return offset2;
		}
		case 6:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 7:
			if (!BaseGameDataDomain.IsModified(DataStates, 7))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 7);
			return GameData.Serializer.Serializer.Serialize(GetMartialArtTournamentPreparationInfoList(), dataPool);
		case 8:
			if (!BaseGameDataDomain.IsModified(DataStates, 8))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 8);
			return GameData.Serializer.Serializer.Serialize(_previousMartialArtTournamentHosts, dataPool);
		case 9:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 10:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 11:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 11))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 11);
			int offset = GameData.Serializer.Serializer.SerializeModifications(_settlementTreasuryRecordCollections, dataPool, _modificationsSettlementTreasuryRecordCollections);
			_modificationsSettlementTreasuryRecordCollections.Reset();
			return offset;
		}
		case 12:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 12))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 12);
			int offset5 = GameData.Serializer.Serializer.SerializeModifications(_settlementPrisonRecordCollections, dataPool, _modificationsSettlementPrisonRecordCollections);
			_modificationsSettlementPrisonRecordCollections.Reset();
			return offset5;
		}
		case 13:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 14:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 14))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 14);
			int offset4 = GameData.Serializer.Serializer.SerializeModifications(_settlementPrisons, dataPool, _modificationsSettlementPrisons);
			_modificationsSettlementPrisons.Reset();
			return offset4;
		}
		case 15:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 15))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 15);
			int offset3 = GameData.Serializer.Serializer.SerializeModifications(_cityPunishmentSeverityCustomizeDict, dataPool, _modificationsCityPunishmentSeverityCustomizeDict);
			_modificationsCityPunishmentSeverityCustomizeDict.Reset();
			return offset3;
		}
		case 16:
			if (!BaseGameDataDomain.IsModified(DataStates, 16))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 16);
			return GameData.Serializer.Serializer.Serialize(_currTournamentHost, dataPool);
		case 17:
			if (!BaseGameDataDomain.IsModified(DataStates, 17))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 17);
			return GameData.Serializer.Serializer.Serialize(_lastTournamentFinishDate, dataPool);
		case 18:
			if (!BaseGameDataDomain.IsModified(DataStates, 18))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 18);
			return GameData.Serializer.Serializer.Serialize(_tournamentPreparationEndDate, dataPool);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void ResetModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		switch (dataId)
		{
		case 0:
			ResetModifiedWrapper_Sects((short)subId0, (ushort)subId1);
			break;
		case 1:
			ResetModifiedWrapper_CivilianSettlements((short)subId0, (ushort)subId1);
			break;
		case 2:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 3:
			ResetModifiedWrapper_SectCharacters((int)subId0, (ushort)subId1);
			break;
		case 4:
			ResetModifiedWrapper_CivilianSettlementCharacters((int)subId0, (ushort)subId1);
			break;
		case 5:
			if (BaseGameDataDomain.IsModified(DataStates, 5))
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
				_modificationsFactions.Reset();
			}
			break;
		case 6:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
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
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 10:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 11:
			if (BaseGameDataDomain.IsModified(DataStates, 11))
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
				_modificationsSettlementTreasuryRecordCollections.Reset();
			}
			break;
		case 12:
			if (BaseGameDataDomain.IsModified(DataStates, 12))
			{
				BaseGameDataDomain.ResetModified(DataStates, 12);
				_modificationsSettlementPrisonRecordCollections.Reset();
			}
			break;
		case 13:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 14:
			if (BaseGameDataDomain.IsModified(DataStates, 14))
			{
				BaseGameDataDomain.ResetModified(DataStates, 14);
				_modificationsSettlementPrisons.Reset();
			}
			break;
		case 15:
			if (BaseGameDataDomain.IsModified(DataStates, 15))
			{
				BaseGameDataDomain.ResetModified(DataStates, 15);
				_modificationsCityPunishmentSeverityCustomizeDict.Reset();
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
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override bool IsModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		return dataId switch
		{
			0 => IsModifiedWrapper_Sects((short)subId0, (ushort)subId1), 
			1 => IsModifiedWrapper_CivilianSettlements((short)subId0, (ushort)subId1), 
			2 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			3 => IsModifiedWrapper_SectCharacters((int)subId0, (ushort)subId1), 
			4 => IsModifiedWrapper_CivilianSettlementCharacters((int)subId0, (ushort)subId1), 
			5 => BaseGameDataDomain.IsModified(DataStates, 5), 
			6 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			7 => BaseGameDataDomain.IsModified(DataStates, 7), 
			8 => BaseGameDataDomain.IsModified(DataStates, 8), 
			9 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			10 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			11 => BaseGameDataDomain.IsModified(DataStates, 11), 
			12 => BaseGameDataDomain.IsModified(DataStates, 12), 
			13 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			14 => BaseGameDataDomain.IsModified(DataStates, 14), 
			15 => BaseGameDataDomain.IsModified(DataStates, 15), 
			16 => BaseGameDataDomain.IsModified(DataStates, 16), 
			17 => BaseGameDataDomain.IsModified(DataStates, 17), 
			18 => BaseGameDataDomain.IsModified(DataStates, 18), 
			_ => throw new Exception($"Unsupported dataId {dataId}"), 
		};
	}

	public override void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll)
	{
		switch (influence.TargetIndicator.DataId)
		{
		case 0:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects2 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _sects, influencedObjects2))
				{
					int influencedObjectsCount2 = influencedObjects2.Count;
					for (int k = 0; k < influencedObjectsCount2; k++)
					{
						BaseGameDataObject targetObject2 = influencedObjects2[k];
						List<DataUid> targetUids2 = influence.TargetUids;
						int targetUidsCount2 = targetUids2.Count;
						for (int l = 0; l < targetUidsCount2; l++)
						{
							targetObject2.InvalidateSelfAndInfluencedCache((ushort)targetUids2[l].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesSects, _dataStatesSects, influence, context);
				}
				influencedObjects2.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects2);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesSects, _dataStatesSects, influence, context);
			}
			break;
		case 1:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects4 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _civilianSettlements, influencedObjects4))
				{
					int influencedObjectsCount4 = influencedObjects4.Count;
					for (int num = 0; num < influencedObjectsCount4; num++)
					{
						BaseGameDataObject targetObject4 = influencedObjects4[num];
						List<DataUid> targetUids4 = influence.TargetUids;
						int targetUidsCount4 = targetUids4.Count;
						for (int num2 = 0; num2 < targetUidsCount4; num2++)
						{
							targetObject4.InvalidateSelfAndInfluencedCache((ushort)targetUids4[num2].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCivilianSettlements, _dataStatesCivilianSettlements, influence, context);
				}
				influencedObjects4.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects4);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCivilianSettlements, _dataStatesCivilianSettlements, influence, context);
			}
			break;
		case 3:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects3 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _sectCharacters, influencedObjects3))
				{
					int influencedObjectsCount3 = influencedObjects3.Count;
					for (int m = 0; m < influencedObjectsCount3; m++)
					{
						BaseGameDataObject targetObject3 = influencedObjects3[m];
						List<DataUid> targetUids3 = influence.TargetUids;
						int targetUidsCount3 = targetUids3.Count;
						for (int n = 0; n < targetUidsCount3; n++)
						{
							targetObject3.InvalidateSelfAndInfluencedCache((ushort)targetUids3[n].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesSectCharacters, _dataStatesSectCharacters, influence, context);
				}
				influencedObjects3.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects3);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesSectCharacters, _dataStatesSectCharacters, influence, context);
			}
			break;
		case 4:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _civilianSettlementCharacters, influencedObjects))
				{
					int influencedObjectsCount = influencedObjects.Count;
					for (int i = 0; i < influencedObjectsCount; i++)
					{
						BaseGameDataObject targetObject = influencedObjects[i];
						List<DataUid> targetUids = influence.TargetUids;
						int targetUidsCount = targetUids.Count;
						for (int j = 0; j < targetUidsCount; j++)
						{
							targetObject.InvalidateSelfAndInfluencedCache((ushort)targetUids[j].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCivilianSettlementCharacters, _dataStatesCivilianSettlementCharacters, influence, context);
				}
				influencedObjects.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCivilianSettlementCharacters, _dataStatesCivilianSettlementCharacters, influence, context);
			}
			break;
		case 7:
			BaseGameDataDomain.InvalidateSelfAndInfluencedCache(7, DataStates, CacheInfluences, context);
			break;
		default:
			throw new Exception($"Unsupported dataId {influence.TargetIndicator.DataId}");
		case 2:
		case 5:
		case 6:
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
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
		foreach (KeyValuePair<short, Sect> sect in _sects)
		{
			Sect instance = sect.Value;
			instance.CollectionHelperData = HelperDataSects;
			instance.DataStatesOffset = _dataStatesSects.Create();
		}
		foreach (KeyValuePair<short, CivilianSettlement> civilianSettlement in _civilianSettlements)
		{
			CivilianSettlement instance2 = civilianSettlement.Value;
			instance2.CollectionHelperData = HelperDataCivilianSettlements;
			instance2.DataStatesOffset = _dataStatesCivilianSettlements.Create();
		}
		foreach (KeyValuePair<int, SectCharacter> sectCharacter in _sectCharacters)
		{
			SectCharacter instance3 = sectCharacter.Value;
			instance3.CollectionHelperData = HelperDataSectCharacters;
			instance3.DataStatesOffset = _dataStatesSectCharacters.Create();
		}
		foreach (KeyValuePair<int, CivilianSettlementCharacter> civilianSettlementCharacter in _civilianSettlementCharacters)
		{
			CivilianSettlementCharacter instance4 = civilianSettlementCharacter.Value;
			instance4.CollectionHelperData = HelperDataCivilianSettlementCharacters;
			instance4.DataStatesOffset = _dataStatesCivilianSettlementCharacters.Create();
		}
	}
}
