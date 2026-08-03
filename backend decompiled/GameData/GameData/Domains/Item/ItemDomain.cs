using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Config;
using Config.ConfigCells;
using Config.ConfigCells.Character;
using GameData.Achievement;
using GameData.ArchiveData;
using GameData.Combat.Cricket;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Common.SingleValueCollection;
using GameData.DLC;
using GameData.DLC.FiveLoong;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Extra;
using GameData.Domains.Global;
using GameData.Domains.Item.Display;
using GameData.Domains.Map;
using GameData.Domains.SpecialEffect;
using GameData.Domains.Taiwu;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.Taiwu.Profession.SkillsData;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World;
using GameData.Domains.World.Notification;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using NLog;
using Redzen.Random;

namespace GameData.Domains.Item;

[GameDataDomain(6)]
public class ItemDomain : BaseGameDataDomain
{
	private static readonly int WagerValueUnit = GlobalConfig.UnitsOfResourceTransfer[0] * GlobalConfig.ResourcesWorth[0];

	private sbyte _minCricketGrade = 0;

	private sbyte _maxCricketGrade = 8;

	private bool _onlyNoInjuryCricket;

	private int _cricketBattleEnemyId;

	private readonly List<ItemKey> _cricketBattleEnemyCrickets = new List<ItemKey>();

	private Wager _cricketBattleSelfWager;

	private Wager _cricketBattleEnemyWager;

	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, Weapon> _weapons;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, Armor> _armors;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, Accessory> _accessories;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, Clothing> _clothing;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, Carrier> _carriers;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, Material> _materials;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, CraftTool> _craftTools;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, Food> _foods;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, Medicine> _medicines;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, TeaWine> _teaWines;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, SkillBook> _skillBooks;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, Cricket> _crickets;

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true)]
	private readonly Dictionary<int, Misc> _misc;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private int _nextItemId;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<TemplateKey, int> _stackableItems;

	[Obsolete("Now only for data fix. Use ExtraDomain.PoisonEffects instead")]
	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<int, PoisonEffects> _poisonItems;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<int, RefiningEffects> _refinedItems;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<int, int> _medicineExtraAddPercent;

	[DomainData(DomainDataType.SingleValueCollection, false, false, false, false)]
	private readonly Dictionary<int, GameData.Utilities.ShortList> _externEquipmentEffects;

	private readonly HashSet<ItemKey> _trackedSpecialItems = new HashSet<ItemKey>();

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private ItemKey _emptyHandKey;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private ItemKey _branchKey;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private ItemKey _stoneKey;

	private static List<short>[] _categorizedEquipmentEffects;

	private static Dictionary<short, List<short>>[] _categorizedItemTemplates;

	private static List<TemplateKey>[] _skillBreakPlateBonusEffects;

	public const int ItemGradeSatisfactionOffset = -2;

	private static readonly Dictionary<sbyte, ushort> EquipmentItemTypeToDataIds = new Dictionary<sbyte, ushort>
	{
		{ 0, 0 },
		{ 1, 1 },
		{ 2, 2 },
		{ 3, 3 },
		{ 4, 4 }
	};

	private static readonly Dictionary<sbyte, ushort> EquipmentItemTypeToEquippedPowerFieldIds = new Dictionary<sbyte, ushort>
	{
		{ 0, 13 },
		{ 1, 13 },
		{ 2, 8 },
		{ 3, 9 },
		{ 4, 8 }
	};

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private Dictionary<int, MysteryData> _mysteryData;

	public const int NormalPageBaseCostExp = 20;

	public const int OutlinePageBaseCostExp = 60;

	private readonly HashSet<ItemKey> _newDeadCrickets = new HashSet<ItemKey>();

	private static short[] _wugTemplateIds;

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[23][];

	private static readonly DataInfluence[][] CacheInfluencesWeapons = new DataInfluence[14][];

	private readonly ObjectCollectionDataStates _dataStatesWeapons = new ObjectCollectionDataStates(14, 0);

	public readonly ObjectCollectionHelperData HelperDataWeapons;

	private static readonly DataInfluence[][] CacheInfluencesArmors = new DataInfluence[14][];

	private readonly ObjectCollectionDataStates _dataStatesArmors = new ObjectCollectionDataStates(14, 0);

	public readonly ObjectCollectionHelperData HelperDataArmors;

	private static readonly DataInfluence[][] CacheInfluencesAccessories = new DataInfluence[9][];

	private readonly ObjectCollectionDataStates _dataStatesAccessories = new ObjectCollectionDataStates(9, 0);

	public readonly ObjectCollectionHelperData HelperDataAccessories;

	private static readonly DataInfluence[][] CacheInfluencesClothing = new DataInfluence[10][];

	private readonly ObjectCollectionDataStates _dataStatesClothing = new ObjectCollectionDataStates(10, 0);

	public readonly ObjectCollectionHelperData HelperDataClothing;

	private static readonly DataInfluence[][] CacheInfluencesCarriers = new DataInfluence[9][];

	private readonly ObjectCollectionDataStates _dataStatesCarriers = new ObjectCollectionDataStates(9, 0);

	public readonly ObjectCollectionHelperData HelperDataCarriers;

	private static readonly DataInfluence[][] CacheInfluencesMaterials = new DataInfluence[5][];

	private readonly ObjectCollectionDataStates _dataStatesMaterials = new ObjectCollectionDataStates(5, 0);

	public readonly ObjectCollectionHelperData HelperDataMaterials;

	private static readonly DataInfluence[][] CacheInfluencesCraftTools = new DataInfluence[5][];

	private readonly ObjectCollectionDataStates _dataStatesCraftTools = new ObjectCollectionDataStates(5, 0);

	public readonly ObjectCollectionHelperData HelperDataCraftTools;

	private static readonly DataInfluence[][] CacheInfluencesFoods = new DataInfluence[5][];

	private readonly ObjectCollectionDataStates _dataStatesFoods = new ObjectCollectionDataStates(5, 0);

	public readonly ObjectCollectionHelperData HelperDataFoods;

	private static readonly DataInfluence[][] CacheInfluencesMedicines = new DataInfluence[5][];

	private readonly ObjectCollectionDataStates _dataStatesMedicines = new ObjectCollectionDataStates(5, 0);

	public readonly ObjectCollectionHelperData HelperDataMedicines;

	private static readonly DataInfluence[][] CacheInfluencesTeaWines = new DataInfluence[5][];

	private readonly ObjectCollectionDataStates _dataStatesTeaWines = new ObjectCollectionDataStates(5, 0);

	public readonly ObjectCollectionHelperData HelperDataTeaWines;

	private static readonly DataInfluence[][] CacheInfluencesSkillBooks = new DataInfluence[7][];

	private readonly ObjectCollectionDataStates _dataStatesSkillBooks = new ObjectCollectionDataStates(7, 0);

	public readonly ObjectCollectionHelperData HelperDataSkillBooks;

	private static readonly DataInfluence[][] CacheInfluencesCrickets = new DataInfluence[19][];

	private readonly ObjectCollectionDataStates _dataStatesCrickets = new ObjectCollectionDataStates(19, 0);

	public readonly ObjectCollectionHelperData HelperDataCrickets;

	private static readonly DataInfluence[][] CacheInfluencesMisc = new DataInfluence[5][];

	private readonly ObjectCollectionDataStates _dataStatesMisc = new ObjectCollectionDataStates(5, 0);

	public readonly ObjectCollectionHelperData HelperDataMisc;

	private SingleValueCollectionModificationCollection<int> _modificationsMysteryData = SingleValueCollectionModificationCollection<int>.Create();

	private SingleValueCollectionModificationCollection<int> _modificationsMedicineExtraAddPercent = SingleValueCollectionModificationCollection<int>.Create();

	private Queue<uint> _pendingLoadingOperationIds;

	[Obsolete("Instead by FullPoisonEffects. Now only for archive data fix. Do not delete this code.")]
	public Dictionary<int, PoisonEffects> PoisonItems => _poisonItems;

	public IReadOnlyDictionary<int, FullPoisonEffects> PoisonEffects => DomainManager.Extra.PoisonEffects;

	public bool VersionNeedRepairSectAccessory => (object)DomainManager.World.GetCurrWorldGameVersion() == null || DomainManager.World.IsCurrWorldBeforeVersion(0, 0, 78, 31);

	[DataUpgrader(Version = "1.0.51", Date = "2026/07/06")]
	private void FixAbnormalOutlineBookPage(DataContext context)
	{
		foreach (var (id, book) in _skillBooks)
		{
			if (book.IsCombatSkillBook() && SkillBookStateHelper.GetOutlinePageType(book.GetPageTypes()) >= 5)
			{
				book.SetOutlinePageType(context, 0);
				AdaptableLog.Warning($"Fix Abnormal Book Outline Page: {book.GetItemKey()}.");
			}
		}
	}

	[DomainMethod]
	public List<ItemDisplayData> CatchCricket(DataContext context, short colorId, short partId, short singLevel, sbyte cricketPlaceId)
	{
		List<ItemDisplayData> itemList = new List<ItemDisplayData>();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		sbyte level = Math.Max(CricketParts.Instance[colorId].Level, CricketParts.Instance[partId].Level);
		int successOdds = 10 + singLevel - Math.Min(level * 5, 40);
		bool mustSuccessLoud = CricketParts.Instance[colorId].MustSuccessLoud || CricketParts.Instance[partId].MustSuccessLoud;
		bool success = singLevel >= (mustSuccessLoud ? 80 : GlobalConfig.Instance.CatchCricketSuccessSingLevel);
		if (!success)
		{
			success = context.Random.CheckPercentProb((singLevel >= 80) ? successOdds : (successOdds / 2));
		}
		if (success)
		{
			ItemKey itemKey = DomainManager.Item.CreateCricket(context, colorId, partId);
			Cricket cricket = DomainManager.Item.GetElement_Crickets(itemKey.Id);
			DomainManager.Taiwu.SetCricketLuckPoint(DomainManager.Taiwu.GetCricketLuckPoint() + cricket.CalcCatchLucky(), context);
			DomainManager.Taiwu.AddLegacyPoint(context, 32, 100 + Math.Abs(cricket.CalcCatchLucky()) * 5);
			taiwu.AddInventoryItem(context, itemKey, 1);
			AddCatchCricketProfessionSeniority(context, cricket);
			DomainManager.Taiwu.RecordLifeSummary(context, 72);
			AchievementManager.RequestSetStat(context, 13, 1);
			if (cricket.GetGrade() >= 8)
			{
				DomainManager.Taiwu.RecordLifeSummary(context, 73);
				AchievementManager.RequestSetStat(context, (short)15, (int)CricketParts.Instance[cricket.GetColorId()].TemplateId);
			}
			if (CricketParts.Instance[cricket.GetColorId()].Type == ECricketPartsType.Trash)
			{
				AchievementManager.RequestSetStat(context, 14, 1);
			}
			if (context.Random.CheckPercentProb(cricket.GetGrade() * 2))
			{
				cricket.SetCurrDurability((short)(cricket.GetCurrDurability() - 1), context);
				ItemKey extraItemKey = DomainManager.Item.CreateMisc(context, 34);
				taiwu.AddInventoryItem(context, extraItemKey, 1);
				itemList.Add(DomainManager.Item.GetItemDisplayData(DomainManager.Item.GetBaseItem(extraItemKey), 1, -1, -1));
			}
			else if (cricket.GetGrade() > 0 && context.Random.CheckPercentProb(10))
			{
				ItemKey extraItemKey2 = DomainManager.Item.CreateCricket(context, (short)(cricket.GetGrade() - 1));
				Cricket extraCricket = DomainManager.Item.GetElement_Crickets(extraItemKey2.Id);
				cricket.SetCurrDurability((short)(cricket.GetMaxDurability() / 2), context);
				extraCricket.SetCurrDurability((short)(extraCricket.GetMaxDurability() / 2), context);
				taiwu.AddInventoryItem(context, extraItemKey2, 1);
				itemList.Add(DomainManager.Item.GetItemDisplayData(DomainManager.Item.GetBaseItem(extraItemKey2), 1, -1, -1));
				AddCatchCricketProfessionSeniority(context, extraCricket);
				DomainManager.Taiwu.RecordLifeSummary(context, 72);
				if (extraCricket.GetGrade() >= 8)
				{
					DomainManager.Taiwu.RecordLifeSummary(context, 73);
					AchievementManager.RequestSetStat(context, (short)15, (int)CricketParts.Instance[extraCricket.GetColorId()].TemplateId);
				}
				if (CricketParts.Instance[extraCricket.GetColorId()].Type == ECricketPartsType.Trash)
				{
					AchievementManager.RequestSetStat(context, 14, 1);
				}
			}
			itemList.Insert(0, DomainManager.Item.GetItemDisplayData(cricket, 1, -1, -1));
		}
		else if (singLevel >= 80)
		{
			short[] uselessItems = CricketPlace.Instance[cricketPlaceId].UselessItemList;
			short templateId = uselessItems[context.Random.Next(uselessItems.Length)];
			ItemKey itemKey2 = DomainManager.Item.CreateItem(context, 12, templateId);
			taiwu.AddInventoryItem(context, itemKey2, 1);
			itemList.Add(DomainManager.Item.GetItemDisplayData(DomainManager.Item.GetBaseItem(itemKey2), 1, -1, -1));
		}
		return itemList;
	}

	public void AddCatchCricketProfessionSeniority(DataContext context, Cricket cricket)
	{
		ProfessionFormulaItem formula = ProfessionFormula.Instance[107];
		int addSeniority = formula.Calculate(cricket.GetValue());
		DomainManager.Extra.ChangeProfessionSeniority(context, 17, addSeniority);
	}

	[DomainMethod]
	public CricketData GetCricketData(int itemId)
	{
		if (!TryGetElement_Crickets(itemId, out var cricket))
		{
			return null;
		}
		return new CricketData
		{
			Injuries = cricket.GetInjuries(),
			WinsCount = cricket.GetWinsCount(),
			LossesCount = cricket.GetLossesCount(),
			BestEnemyColorId = cricket.GetBestEnemyColorId(),
			BestEnemyPartId = cricket.GetBestEnemyPartId(),
			AgeProgress = cricket.GetAgeProgress(),
			MaxAge = (short)cricket.CalcMaxAge(),
			IsSmart = DomainManager.Extra.IsCricketSmart(itemId),
			IsIdentified = DomainManager.Extra.IsCricketIdentified(itemId),
			CricketValue = cricket.GetValue(),
			Spirit = cricket.GetSpirit(),
			SpiritAddProperties = cricket.GetSpiritAddProperties(),
			OriginState = cricket.GetOriginState(),
			NameId = cricket.GetNameId()
		};
	}

	[DomainMethod]
	public List<CricketData> GetCricketDataList(List<ItemKey> itemList)
	{
		List<CricketData> dataList = new List<CricketData>();
		if (itemList == null)
		{
			return dataList;
		}
		for (int i = 0; i < itemList.Count; i++)
		{
			CricketData data = GetCricketData(itemList[i].Id);
			dataList.Add(data);
		}
		return dataList;
	}

	[DomainMethod]
	public void SetCricketRecord(DataContext context, int itemId, bool win, int enemyItemId)
	{
		if (!DomainManager.Item.TryGetElement_Crickets(itemId, out var cricket))
		{
			return;
		}
		bool ownedByTaiwu = cricket.Owner.OwnerType == ItemOwnerType.CharacterInventory && cricket.Owner.OwnerId == DomainManager.Taiwu.GetTaiwuCharId();
		if (win)
		{
			if (!DomainManager.Item.TryGetElement_Crickets(enemyItemId, out var enemyCricket))
			{
				return;
			}
			if (DlcManager.IsDlcInstalled(4528730uL) && ownedByTaiwu)
			{
				cricket.AddSpiritByWin(context, enemyCricket.GetColorId(), enemyCricket.GetPartId());
			}
			if (cricket.GetGrade() - enemyCricket.GetGrade() <= 2)
			{
				int bestEnemyGrade = ((cricket.GetBestEnemyColorId() > 0) ? Math.Max(CricketParts.Instance[cricket.GetBestEnemyColorId()].Level, CricketParts.Instance[cricket.GetBestEnemyPartId()].Level) : 0);
				cricket.SetWinsCount((short)(cricket.GetWinsCount() + 1), context);
				if (enemyCricket.GetGrade() >= bestEnemyGrade)
				{
					cricket.SetBestEnemyColorId(enemyCricket.GetColorId(), context);
					cricket.SetBestEnemyPartId(enemyCricket.GetPartId(), context);
				}
				if (ownedByTaiwu)
				{
					ProfessionFormulaItem formula = ProfessionFormula.Instance[108];
					int addSeniority = formula.Calculate(enemyCricket.GetGrade());
					DomainManager.Extra.ChangeProfessionSeniority(context, 17, addSeniority);
				}
			}
		}
		else
		{
			cricket.SetLossesCount((short)(cricket.GetLossesCount() + 1), context);
		}
	}

	[DomainMethod]
	public void AddCricketInjury(DataContext context, int itemId, int index, short value)
	{
		if (DomainManager.Item.TryGetElement_Crickets(itemId, out var cricket))
		{
			short[] injuries = cricket.GetInjuries();
			injuries[index] += value;
			cricket.SetInjuries(injuries, context);
		}
	}

	[DomainMethod]
	public void SetCricketBattleConfig(sbyte minGrade, sbyte maxGrade, bool onlyNoInjuryCricket)
	{
		_minCricketGrade = minGrade;
		_maxCricketGrade = maxGrade;
		_onlyNoInjuryCricket = onlyNoInjuryCricket;
	}

	public void ResetCricketWagerData(int enemyId)
	{
		_cricketBattleEnemyId = enemyId;
		_cricketBattleSelfWager.Type = -1;
		_cricketBattleEnemyWager.Type = -1;
	}

	public List<CricketWagerData> SelectCricketWagers(DataContext context)
	{
		GameData.Domains.Character.Character enemy = DomainManager.Character.GetElement_Objects(_cricketBattleEnemyId);
		List<CricketWagerData> result = new List<CricketWagerData>();
		foreach (Wager wager in CalcEnemyWagers(context.Random, enemy))
		{
			CricketWagerData data = new CricketWagerData
			{
				Wager = wager,
				Crickets = GetNpcCricketDisplayDataListForCricketBattle(context, _cricketBattleEnemyId, _cricketBattleEnemyCrickets, wager.Grade),
				MinWagerValue = CalcMinWagerValue(wager)
			};
			data.PreRandomizedShowCricketIndex = (byte)context.Random.Next(data.Crickets.Count);
			result.Add(data);
		}
		return result;
	}

	public List<ItemDisplayData> GetNpcCricketDisplayDataListForCricketBattle(DataContext context, int charId, List<ItemKey> tempCreateCricketKeyList, sbyte wagerGrade = -1)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		sbyte orgGrade = character.GetOrganizationInfo().Grade;
		if (wagerGrade < 0)
		{
			wagerGrade = orgGrade;
		}
		short attainment = character.GetLifeSkillAttainment(15);
		List<ItemDisplayData> result = new List<ItemDisplayData>();
		List<sbyte> grades = ObjectPool<List<sbyte>>.Instance.Get();
		grades.AddRange(CricketGenerator.Generate(orgGrade, wagerGrade, attainment));
		FillInventoryCricket(charId, grades, result);
		sbyte stateId = character.GetValidOrganizationStateId();
		foreach (sbyte grade in grades)
		{
			sbyte finalGrade = Math.Clamp(grade, _minCricketGrade, _maxCricketGrade);
			short templateId = finalGrade;
			ItemKey cricketKey = DomainManager.Item.CreateCricket(context, templateId, finalGrade == 8);
			Cricket cricket = DomainManager.Item.GetElement_Crickets(cricketKey.Id);
			cricket.SetOriginState(stateId, context);
			if (_onlyNoInjuryCricket)
			{
				short[] injuries = cricket.GetInjuries();
				Array.Clear(injuries, 0, injuries.Length);
				cricket.SetInjuries(injuries, context);
			}
			tempCreateCricketKeyList.Add(cricketKey);
			result.Add(DomainManager.Item.GetItemDisplayData(cricketKey));
		}
		ObjectPool<List<sbyte>>.Instance.Return(grades);
		CollectionUtils.Shuffle(context.Random, result);
		return result;
	}

	private void FillInventoryCricket(int charId, IList<sbyte> grades, List<ItemDisplayData> crickets)
	{
		sbyte minGrade = grades.Min();
		List<ItemDisplayData> inventoryCrickets = DomainManager.Character.GetInventoryItems(charId, 1100);
		inventoryCrickets.RemoveAll(delegate(ItemDisplayData data)
		{
			if (data.Durability <= 0)
			{
				return true;
			}
			sbyte cricketGrade = ItemTemplateHelper.GetCricketGrade(data.CricketColorId, data.CricketPartId);
			if (cricketGrade < _minCricketGrade || cricketGrade > _maxCricketGrade || cricketGrade < minGrade)
			{
				return true;
			}
			return (_onlyNoInjuryCricket && GetElement_Crickets(data.Key.Id).GetInjuries().Sum() > 0) ? true : false;
		});
		inventoryCrickets.Sort((ItemDisplayData lhs, ItemDisplayData rhs) => GetGrade(lhs).CompareTo(GetGrade(rhs)));
		while (inventoryCrickets.Count > grades.Count)
		{
			inventoryCrickets.RemoveAt(0);
		}
		crickets.AddRange(inventoryCrickets);
		for (int i = 0; i < inventoryCrickets.Count; i++)
		{
			minGrade = grades.Min();
			grades.Remove(minGrade);
		}
		static sbyte GetGrade(ItemDisplayData data)
		{
			return ItemTemplateHelper.GetCricketGrade(data.CricketColorId, data.CricketPartId);
		}
	}

	public void SetWager(Wager selfWager, Wager enemyWager)
	{
		_cricketBattleSelfWager = selfWager;
		_cricketBattleEnemyWager = enemyWager;
	}

	[DomainMethod]
	public CricketSettlementResult SettlementCricketWagerByGiveUp(DataContext context, bool win, bool invokeExtraWager = false)
	{
		return SettlementCricketWager(context, win, null, null, invokeExtraWager);
	}

	[DomainMethod]
	public CricketSettlementResult SettlementCricketWager(DataContext context, bool win, ItemKey[] taiwuCricketKeys, short[] durabilityList, bool invokeExtraWager = false)
	{
		CricketSettlementResult result = new CricketSettlementResult
		{
			TaiwuWin = win
		};
		GameData.Domains.Character.Character enemy = DomainManager.Character.GetElement_Objects(_cricketBattleEnemyId);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (taiwuCricketKeys != null && taiwuCricketKeys.Length > 0 && durabilityList != null && durabilityList.Length > 0)
		{
			for (int i = 0; i < taiwuCricketKeys.Length; i++)
			{
				DomainManager.TaiwuEvent.SetListenerEventActionISerializableArg("CricketCombatOver", $"SelfCricket{i}", taiwuCricketKeys[i]);
				Cricket cricket = DomainManager.Item.GetElement_Crickets(taiwuCricketKeys[i].Id);
				cricket.SetCurrDurability(durabilityList[i], context);
			}
		}
		if (win)
		{
			if (invokeExtraWager)
			{
				result.ExtraWager = SelectAndTransferExtraWager(context, enemy, taiwuChar);
			}
			TransferWager(context, enemy, taiwuChar, _cricketBattleEnemyWager);
		}
		else if (_cricketBattleSelfWager.Type != 2)
		{
			TransferWager(context, taiwuChar, enemy, _cricketBattleSelfWager);
		}
		else
		{
			TaiwuTransferCharacterWager(context);
		}
		int selfHappiness = (win ? GlobalConfig.Instance.OtherCombatWinHappiness[taiwuChar.GetBehaviorType()] : GlobalConfig.Instance.OtherCombatLoseHappiness[taiwuChar.GetBehaviorType()]);
		int favorabilityToEnemy = (win ? GlobalConfig.Instance.OtherCombatWinFavorability[taiwuChar.GetBehaviorType()] : GlobalConfig.Instance.OtherCombatLoseFavorability[taiwuChar.GetBehaviorType()]);
		int enemyHappiness = (win ? GlobalConfig.Instance.OtherCombatLoseHappiness[enemy.GetBehaviorType()] : GlobalConfig.Instance.OtherCombatWinHappiness[enemy.GetBehaviorType()]);
		int favorabilityToSelf = (win ? GlobalConfig.Instance.OtherCombatLoseFavorability[enemy.GetBehaviorType()] : GlobalConfig.Instance.OtherCombatWinFavorability[enemy.GetBehaviorType()]);
		taiwuChar.ChangeHappiness(context, selfHappiness);
		enemy.ChangeHappiness(context, enemyHappiness);
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, taiwuChar, enemy, favorabilityToEnemy);
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, enemy, taiwuChar, favorabilityToSelf);
		Events.RaiseCricketCombatFinished(context, win);
		if (win)
		{
			DomainManager.Taiwu.RecordLifeSummary(context, 74);
			AchievementManager.RequestSetStat(context, 89, 1);
		}
		if (win && taiwuCricketKeys != null)
		{
			int taiwuCricketGradeSum = 0;
			for (int j = 0; j < taiwuCricketKeys.Length; j++)
			{
				ItemKey cricket2 = taiwuCricketKeys[j];
				taiwuCricketGradeSum += Config.Cricket.Instance[cricket2.TemplateId].Grade;
			}
			int enemyCricketGradeSum = 0;
			foreach (ItemKey cricket3 in _cricketBattleEnemyCrickets)
			{
				enemyCricketGradeSum += Config.Cricket.Instance[cricket3.TemplateId].Grade;
			}
			if (taiwuCricketGradeSum <= enemyCricketGradeSum + 3)
			{
				DomainManager.Taiwu.AddLegacyPoint(context, 33);
			}
		}
		foreach (ItemKey itemKey in _cricketBattleEnemyCrickets)
		{
			DomainManager.Item.RemoveItem(context, itemKey);
		}
		_cricketBattleEnemyCrickets.Clear();
		_minCricketGrade = 0;
		_maxCricketGrade = 8;
		_onlyNoInjuryCricket = false;
		return result;
	}

	private void TaiwuTransferCharacterWager(DataContext context)
	{
		GameData.Domains.Character.Character enemy = DomainManager.Character.GetElement_Objects(_cricketBattleEnemyId);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = taiwuChar.GetId();
		if (ExternalRelationStateHelper.IsActive(taiwuChar.GetExternalRelationState(), 2uL))
		{
			KidnappedCharacterList kidnappedCharList = DomainManager.Character.GetKidnappedCharacters(taiwuCharId);
			int targetIndex = kidnappedCharList.IndexOf(_cricketBattleSelfWager.CharId);
			if (targetIndex >= 0)
			{
				DomainManager.Character.TransferKidnappedCharacter(context, _cricketBattleEnemyId, taiwuChar.GetId(), kidnappedCharList.Get(targetIndex));
				return;
			}
		}
		if (_cricketBattleSelfWager.CharId == taiwuCharId)
		{
			EventHelper.TriggerLegacyPassingEvent(isTaiwuDying: true);
		}
		else if (DomainManager.Taiwu.IsInGroup(_cricketBattleSelfWager.CharId))
		{
			ItemKey rope = enemy.GetInventoryRope(context, enemy.GetOrganizationInfo().Grade);
			DomainManager.Character.AddKidnappedCharacter(context, _cricketBattleEnemyId, _cricketBattleSelfWager.CharId, rope);
		}
	}

	private Wager SelectAndTransferExtraWager(DataContext context, GameData.Domains.Character.Character enemy, GameData.Domains.Character.Character taiwuChar)
	{
		List<Wager> pool = ObjectPool<List<Wager>>.Instance.Get();
		pool.Clear();
		pool.AddRange(CalcEnemyWagers(context.Random, enemy));
		pool.Remove(_cricketBattleEnemyWager);
		Wager result = ((pool.Count > 0) ? pool.GetRandom(context.Random) : ((_cricketBattleEnemyWager.Type == 3) ? _cricketBattleEnemyWager : Wager.Invalid));
		ObjectPool<List<Wager>>.Instance.Return(pool);
		if (result.Type == -1)
		{
			PredefinedLog.DefValue.CricketExtraWagerGenerateFailed.Log(_cricketBattleEnemyWager.Type);
		}
		else
		{
			TransferWager(context, enemy, taiwuChar, result);
		}
		return result;
	}

	public void TransferWager(DataContext context, GameData.Domains.Character.Character srcChar, GameData.Domains.Character.Character destChar, Wager wager)
	{
		switch (wager.Type)
		{
		case 0:
			if (wager.Count > 0)
			{
				DomainManager.Character.TransferResource(context, srcChar, destChar, wager.WagerResourceType, wager.Count);
			}
			break;
		case 1:
			if (wager.Count > 0)
			{
				DomainManager.Character.TransferInventoryItem(context, srcChar, destChar, wager.ItemKey, wager.Count);
			}
			break;
		case 2:
		{
			int winnerId = destChar.GetId();
			int loserId = srcChar.GetId();
			KidnappedCharacterList kidnappedCharList = DomainManager.Character.GetKidnappedCharacters(srcChar.GetId());
			KidnappedCharacter kidnappedChar = kidnappedCharList.Get(kidnappedCharList.IndexOf(wager.CharId));
			DomainManager.Character.TransferKidnappedCharacter(context, winnerId, loserId, kidnappedChar);
			break;
		}
		case 3:
			if (wager.Count > 0)
			{
				destChar.ChangeExp(context, wager.Count);
			}
			break;
		}
	}

	public bool CheckCharacterHasWager(GameData.Domains.Character.Character character, Wager wager)
	{
		int amount;
		GameData.Domains.Character.Character kidnappedChar;
		return wager.Type switch
		{
			0 => character.GetResource(wager.WagerResourceType) >= wager.Count, 
			1 => character.GetInventory().Items.TryGetValue(wager.ItemKey, out amount) && amount >= wager.Count, 
			2 => DomainManager.Character.TryGetElement_Objects(wager.CharId, out kidnappedChar) && kidnappedChar.GetKidnapperId() == character.GetId(), 
			3 => true, 
			_ => false, 
		};
	}

	public bool NpcHasAnyCricketWager(int charId)
	{
		IRandomSource random = DataContextManager.GetCurrentThreadDataContext().Random;
		GameData.Domains.Character.Character enemy = DomainManager.Character.GetElement_Objects(charId);
		return CalcEnemyWagers(random, enemy).Any();
	}

	public Wager SelectCharacterValidWager(DataContext context, GameData.Domains.Character.Character character)
	{
		List<Wager> validWagers = context.AdvanceMonthRelatedData.Wagers.Occupy();
		GetCharacterValidWagers(context.Random, character, validWagers);
		Wager wager = validWagers.GetRandomOrDefault(context.Random, Wager.CreateResource(6, 0));
		context.AdvanceMonthRelatedData.Wagers.Release(ref validWagers);
		Tester.Assert(CheckCharacterHasWager(character, wager));
		return wager;
	}

	public static void GetCharacterValidWagers(IRandomSource random, GameData.Domains.Character.Character character, List<Wager> validWagers)
	{
		validWagers.Clear();
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		Vector2 valueRange = Wager.BehaviorValueRange[character.GetBehaviorType()];
		OrganizationItem orgCfg = Config.Organization.Instance[orgInfo.OrgTemplateId];
		sbyte grade = orgInfo.Grade;
		do
		{
			short orgMemberId = orgCfg.Members[grade];
			OrganizationMemberItem orgMemberCfg = OrganizationMember.Instance[orgMemberId];
			int expectedValue = orgMemberCfg.ExpectedWagerValue;
			Dictionary<ItemKey, int> items = character.GetInventory().Items;
			float minValue = Math.Max(valueRange.X * (float)expectedValue, 1f);
			float maxValue = Math.Max(valueRange.Y * (float)expectedValue, minValue);
			foreach (KeyValuePair<ItemKey, int> itemEntry in items)
			{
				int itemValue = DomainManager.Item.GetValue(itemEntry.Key);
				if (minValue <= (float)itemValue && (float)itemValue <= maxValue)
				{
					for (int i = 0; i < 3; i++)
					{
						validWagers.Add(Wager.CreateItem(itemEntry.Key, 1));
					}
				}
			}
			for (sbyte type = 0; type < 8; type++)
			{
				int resourceCount = character.GetResource(type);
				sbyte resourceWorth = GlobalConfig.ResourcesWorth[type];
				short resourceUnit = GlobalConfig.UnitsOfResourceTransfer[type];
				minValue = Math.Max(valueRange.X * (float)expectedValue, resourceWorth * resourceUnit);
				maxValue = Math.Max(valueRange.Y * (float)expectedValue, minValue);
				int minUnitCount = (int)(minValue / (float)resourceWorth / (float)resourceUnit);
				int maxUnitCount = (int)(Math.Min(maxValue / (float)resourceWorth, resourceCount) / (float)resourceUnit);
				if (resourceCount / resourceUnit >= minUnitCount)
				{
					Wager wager = Wager.CreateResource(type, resourceUnit * random.Next(minUnitCount, maxUnitCount + 1));
					for (int j = 0; j < Wager.ResourceRandomWeight[type]; j++)
					{
						validWagers.Add(wager);
					}
				}
			}
			grade--;
		}
		while (validWagers.Count == 0 && grade >= 0);
	}

	private IEnumerable<Wager> CalcEnemyWagers(IRandomSource random, GameData.Domains.Character.Character character)
	{
		sbyte charGrade = character.GetOrganizationInfo().Grade;
		sbyte taiwuFame = DomainManager.Taiwu.GetTaiwu().GetFame();
		(sbyte, sbyte) tuple = CricketSpecialConstants.CalcWagerGradeRange(charGrade, taiwuFame);
		sbyte minGrade = tuple.Item1;
		sbyte maxGrade = tuple.Item2;
		List<ItemKey> itemPool = ObjectPool<List<ItemKey>>.Instance.Get();
		Dictionary<ItemKey, int> items = character.GetInventory().Items;
		foreach (Func<ItemKey, bool> matcher in CricketSpecialConstants.WagerItemMatchers)
		{
			itemPool.Clear();
			itemPool.AddRange(items.Keys.Where(matcher).Where(GradeMatcher));
			itemPool.RemoveAll((ItemKey x) => GetBaseItem(x).GetValue() < 1);
			if (itemPool.Count != 0)
			{
				sbyte highestGrade = itemPool.Max((ItemKey x) => ItemTemplateHelper.GetGrade(x.ItemType, x.TemplateId));
				itemPool.RemoveAll((ItemKey x) => ItemTemplateHelper.GetGrade(x.ItemType, x.TemplateId) < highestGrade);
				ItemKey itemKey = itemPool.GetRandom(random);
				yield return Wager.CreateItem(itemKey, 1);
			}
		}
		ObjectPool<List<ItemKey>>.Instance.Return(itemPool);
		List<sbyte> resourcePool = ObjectPool<List<sbyte>>.Instance.Get();
		List<sbyte> resourceGrades = ObjectPool<List<sbyte>>.Instance.Get();
		for (sbyte resourceType = 0; resourceType < 8; resourceType++)
		{
			int resourceCount = character.GetResource(resourceType);
			for (sbyte resourceGrade = maxGrade; resourceGrade >= minGrade; resourceGrade--)
			{
				int gradeCount = CricketSpecialConstants.GradeToPriceResource(resourceType, resourceGrade);
				if (gradeCount <= resourceCount)
				{
					resourcePool.Add(resourceType);
					resourceGrades.Add(resourceGrade);
					break;
				}
			}
		}
		foreach (sbyte resourceType2 in RandomUtils.GetRandomUnrepeated(random, 3, resourcePool))
		{
			int index = resourcePool.IndexOf(resourceType2);
			sbyte grade = resourceGrades[index];
			int count = CricketSpecialConstants.GradeToPriceResource(resourceType2, grade);
			yield return Wager.CreateResource(resourceType2, count);
		}
		ObjectPool<List<sbyte>>.Instance.Return(resourcePool);
		ObjectPool<List<sbyte>>.Instance.Return(resourceGrades);
		int exp = CricketSpecialConstants.GradeToPriceExp((sbyte)(maxGrade / 2));
		yield return Wager.CreateExp(exp);
		bool GradeMatcher(ItemKey itemKey2)
		{
			sbyte itemGrade = ItemTemplateHelper.GetGrade(itemKey2.ItemType, itemKey2.TemplateId);
			return minGrade <= itemGrade && itemGrade <= maxGrade;
		}
	}

	public long CalcMinWagerValue(Wager wager)
	{
		long wagerValue = GetWagerValue(wager);
		return (wagerValue == 0L) ? 0 : Math.Max(wagerValue, WagerValueUnit);
	}

	private long GetWagerValue(Wager wager)
	{
		sbyte type = wager.Type;
		if ((type == 0 || type == 3) ? true : false)
		{
			return wager.CalcWagerValue(0, 0, 0, 0, -1, 0);
		}
		if (wager.Type == 1)
		{
			return wager.CalcWagerValue(GetValue(wager.ItemKey), 0, 0, 0, -1, 0);
		}
		if (wager.Type == 2)
		{
			GameData.Domains.Character.Character wagerChar = DomainManager.Character.GetElement_Objects(wager.CharId);
			return wager.CalcWagerValue(0, wagerChar.GetFame(), wagerChar.GetAttraction(), wagerChar.GetPhysiologicalAge(), wagerChar.GetAvatar().Gender, wagerChar.GetOrganizationInfo().Grade);
		}
		if (wager.Type == 3)
		{
			return wager.CalcWagerValue(0, 0, 0, 0, -1, 0);
		}
		return 0L;
	}

	[DomainMethod]
	public void MakeCricketRebirth(DataContext ctx, ItemKey itemKey)
	{
		if (itemKey.ItemType == 11 && TryGetElement_Crickets(itemKey.Id, out var cricket))
		{
			cricket.Rebirth(ctx);
			ProfessionFormulaItem formula = ProfessionFormula.Instance[111];
			int addSeniority = formula.Calculate(cricket.GetValue());
			DomainManager.Extra.ChangeProfessionSeniority(ctx, 17, addSeniority);
		}
	}

	[DomainMethod]
	public void SetCricketName(DataContext context, ItemKey itemKey, string name)
	{
		if (itemKey.ItemType == 11 && TryGetElement_Crickets(itemKey.Id, out var cricket))
		{
			cricket.Name(context, (name == null) ? (-1) : DomainManager.World.RegisterCustomText(context, name));
		}
	}

	public List<int> GetAllCricketIdList()
	{
		return new List<int>(_crickets.Keys);
	}

	public ItemKey CreateCricketByLuckPoint(DataContext context, ref int luckPoint, int simulateCount = 1)
	{
		List<(short, short)> weightTable = context.AdvanceMonthRelatedData.WeightTable.Occupy();
		short maxColorId = 0;
		short maxPartId = 0;
		sbyte maxLevel = 0;
		for (int i = 0; i < simulateCount; i++)
		{
			(short, short) tuple = SimulateCricketByLuckPoint(context.Random, luckPoint, weightTable);
			luckPoint += tuple.CalcCricketCatchLucky();
			sbyte level = tuple.CalcCricketGrade();
			if (level >= maxLevel && (level != maxLevel || !context.Random.CheckPercentProb(50)))
			{
				(maxColorId, maxPartId) = tuple;
			}
		}
		context.AdvanceMonthRelatedData.WeightTable.Release(ref weightTable);
		return CreateCricket(context, maxColorId, maxPartId);
	}

	private static (short colorId, short partId) SimulateCricketByLuckPoint(IRandomSource random, int luckPoint, List<(short, short)> weightTable)
	{
		weightTable.Clear();
		foreach (CricketPlaceItem item in (IEnumerable<CricketPlaceItem>)CricketPlace.Instance)
		{
			weightTable.Add((item.TemplateId, item.PlaceRate));
		}
		short placeId = RandomUtils.GetRandomResult(weightTable, random);
		CricketPlaceItem placeConfig = CricketPlace.Instance[placeId];
		weightTable.Clear();
		weightTable.Add((4, placeConfig.Cyan));
		weightTable.Add((5, placeConfig.Yellow));
		weightTable.Add((6, placeConfig.Purple));
		weightTable.Add((7, placeConfig.Red));
		weightTable.Add((8, placeConfig.Black));
		weightTable.Add((9, placeConfig.White));
		weightTable.Add((0, placeConfig.Trash));
		ECricketPartsType baseColorType = (ECricketPartsType)RandomUtils.GetRandomResult(weightTable, random);
		if (baseColorType == ECricketPartsType.Trash)
		{
			return (colorId: 0, partId: 0);
		}
		weightTable.Clear();
		foreach (CricketPartsItem item2 in (IEnumerable<CricketPartsItem>)CricketParts.Instance)
		{
			if (item2.Type == baseColorType)
			{
				weightTable.Add((item2.TemplateId, item2.Rate));
			}
		}
		short selectedColorId = RandomUtils.GetRandomResult(weightTable, random);
		if (random.Next(21) == 0 && random.CheckPercentProb(CricketParts.Instance[selectedColorId].AdvanceRate * luckPoint / 100))
		{
			short cricketKingId;
			if (random.CheckPercentProb(luckPoint / 10))
			{
				weightTable.Clear();
				foreach (CricketPartsItem item3 in (IEnumerable<CricketPartsItem>)CricketParts.Instance)
				{
					if (item3.Type == ECricketPartsType.King)
					{
						weightTable.Add((item3.TemplateId, item3.Rate));
					}
				}
				cricketKingId = RandomUtils.GetRandomResult(weightTable, random);
			}
			else
			{
				if (1 == 0)
				{
				}
				short num = baseColorType switch
				{
					ECricketPartsType.Cyan => 22, 
					ECricketPartsType.Yellow => 23, 
					ECricketPartsType.Purple => 24, 
					ECricketPartsType.Red => 25, 
					ECricketPartsType.Black => 26, 
					ECricketPartsType.White => 27, 
					_ => 0, 
				};
				if (1 == 0)
				{
				}
				cricketKingId = num;
			}
			return (colorId: cricketKingId, partId: 0);
		}
		weightTable.Clear();
		foreach (CricketPartsItem item4 in (IEnumerable<CricketPartsItem>)CricketParts.Instance)
		{
			if (item4.Type == ECricketPartsType.Parts)
			{
				weightTable.Add((item4.TemplateId, item4.Rate));
			}
		}
		short selectedPartId = RandomUtils.GetRandomResult(weightTable, random);
		return (colorId: selectedColorId, partId: selectedPartId);
	}

	[DomainMethod]
	public List<sbyte> GetWeaponTricks(ItemKey weaponKey)
	{
		if (TryGetElement_Weapons(weaponKey.Id, out var weapon))
		{
			return weapon.GetTricks();
		}
		return Config.Weapon.Instance[weaponKey.TemplateId].Tricks;
	}

	[DomainMethod]
	public (int minDist, int maxDist) GetWeaponAttackRange(int charId, ItemKey weaponKey)
	{
		if (!TryGetElement_Weapons(weaponKey.Id, out var weapon))
		{
			WeaponItem weaponCfg = Config.Weapon.Instance[weaponKey.TemplateId];
			return (minDist: weaponCfg.MinDistance, maxDist: weaponCfg.MaxDistance);
		}
		(int, int) range = (weapon.GetMinDistance(), weapon.GetMaxDistance());
		int addValue = DomainManager.SpecialEffect.GetModifyValue(charId, 29, EDataModifyType.Add, weaponKey.ItemType, weaponKey.TemplateId, weaponKey.Id);
		range.Item1 = Math.Max(range.Item1 - addValue, 20);
		range.Item2 = Math.Min(range.Item2 + addValue, 120);
		if (ModificationStateHelper.IsActive(weapon.GetModificationState(), 2))
		{
			RefiningEffects refiningEffects = GetRefinedEffects(weaponKey);
			int equippedCharId = weapon.GetEquippedCharId();
			int minRangeBonus = refiningEffects.GetWeaponPropertyBonus(ERefiningEffectWeaponType.MinAttackRange);
			minRangeBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(minRangeBonus, equippedCharId);
			range.Item1 = Math.Max(range.Item1 - minRangeBonus, 20);
			int maxRangeBonus = refiningEffects.GetWeaponPropertyBonus(ERefiningEffectWeaponType.MaxAttackRange);
			maxRangeBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(maxRangeBonus, equippedCharId);
			range.Item2 = Math.Min(range.Item2 + maxRangeBonus, 120);
		}
		return range;
	}

	[DomainMethod]
	public int GetWeaponPrepareFrame(int charId, ItemKey weaponKey)
	{
		if (!_weapons.TryGetValue(weaponKey.Id, out var weapon))
		{
			return 0;
		}
		if (DomainManager.Combat.IsCharInCombat(charId))
		{
			CombatCharacter combatChar = DomainManager.Combat.GetElement_CombatCharacterDict(charId);
			return combatChar.CalcNormalAttackStartupFrames(weapon);
		}
		int startupFrames = Config.Weapon.Instance[weapon.GetTemplateId()].BaseStartupFrames;
		if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return weapon.CalcAttackStartupOrRecoveryFrame(character.GetAttackSpeed(), startupFrames);
		}
		AdaptableLog.Warning($"Try to get {weaponKey} prepare frame with a invalid charId {charId}");
		return weapon.CalcAttackStartupOrRecoveryFrame(100, startupFrames);
	}

	[DomainMethod]
	public short[] GetCricketCombatRecords(ItemKey cricketKey)
	{
		Cricket cricket = DomainManager.Item.GetElement_Crickets(cricketKey.Id);
		return new short[2]
		{
			cricket.GetWinsCount(),
			cricket.GetLossesCount()
		};
	}

	[DomainMethod]
	public ItemDisplayData GetItemDisplayData(ItemKey itemKey, int charId = -1)
	{
		if (itemKey.Id == -1)
		{
			itemKey = CreateItem(DomainManager.TaiwuEvent.MainThreadDataContext, itemKey.ItemType, itemKey.TemplateId);
			PredefinedLog.Show(12, $"Cannot use GetItemDisplayData for create item, {itemKey} {charId}");
		}
		ItemBase item = TryGetBaseItem(itemKey);
		if (item != null)
		{
			return DomainManager.Item.GetItemDisplayData(item, 1, charId, -1);
		}
		Logger.Warn($"{itemKey} try to get deleted item display data through pure template.");
		return new ItemDisplayData(itemKey.ItemType, itemKey.TemplateId);
	}

	[Obsolete("注意此方法不会合并额外商品、堆叠淬毒物品，批量获取用GetItemDisplayDataListOptional替代并开启合并")]
	[DomainMethod]
	public List<ItemDisplayData> GetItemDisplayDataList(List<ItemKey> itemKeyList, int charId = -1)
	{
		return GetItemDisplayDataListOptional(itemKeyList, charId, -1);
	}

	public ItemDisplayData[] GetEquipmentDisplayData(int charId)
	{
		ItemDisplayData[] ret = new ItemDisplayData[17];
		Array.Fill(ret, new ItemDisplayData());
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var element))
		{
			return ret;
		}
		ItemKey[] equipments = element.GetEquipment();
		int i = 17;
		while (i-- > 0)
		{
			if (equipments[i].IsValid())
			{
				ItemBase itemBase = TryGetBaseItem(equipments[i]);
				if (itemBase != null)
				{
					ret[i] = DomainManager.Item.GetItemDisplayData(itemBase, 1, charId, 0);
				}
			}
		}
		return ret;
	}

	[DomainMethod]
	public List<ItemDisplayData> GetItemDisplayDataListOptional(List<ItemKey> itemKeyList, int charId = -1, sbyte itemSourceType = -1, bool merge = true)
	{
		List<ItemDisplayData> dataList = null;
		if (itemKeyList != null && itemKeyList.Count > 0)
		{
			if (merge)
			{
				Dictionary<ItemKey, int> dict = itemKeyList.GroupBy((ItemKey i) => i, (ItemKey key, IEnumerable<ItemKey> keys) => new
				{
					key = key,
					amount = keys.Count()
				}).ToDictionary(g => g.key, g => g.amount);
				dataList = CharacterDomain.GetItemDisplayData(charId, dict, (ItemSourceType)itemSourceType);
			}
			else
			{
				dataList = new List<ItemDisplayData>();
				foreach (ItemKey itemKey in itemKeyList)
				{
					ItemBase itemBase = TryGetBaseItem(itemKey);
					ItemDisplayData itemData = ((itemBase != null) ? DomainManager.Item.GetItemDisplayData(itemBase, 1, charId, itemSourceType) : (ItemTemplateHelper.IsMiscResource(itemKey.ItemType, itemKey.TemplateId) ? ItemDisplayData.CreateResource(ItemTemplateHelper.GetMiscResourceType(itemKey.ItemType, itemKey.TemplateId), 1) : new ItemDisplayData(itemKey.ItemType, itemKey.TemplateId)));
					if (itemBase == null && !ItemTemplateHelper.IsThanksLetter(itemKey.ItemType, itemKey.TemplateId) && !ItemTemplateHelper.IsMiscResource(itemKey.ItemType, itemKey.TemplateId))
					{
						AdaptableLog.Warning($"Try get not exist item display data by {itemKey}");
					}
					dataList.Add(itemData);
				}
			}
		}
		return dataList;
	}

	[DomainMethod]
	public List<ItemDisplayData> GetItemDisplayDataListOptionalFromInventory(Inventory inventory, int charId = -1, sbyte itemSourceType = -1, bool merge = true)
	{
		if (inventory == null)
		{
			return null;
		}
		return GetItemDisplayDataListOptionalFromInventory(inventory.Items, charId, itemSourceType, merge);
	}

	public List<ItemDisplayData> GetItemDisplayDataListOptionalFromInventory(IReadOnlyDictionary<ItemKey, int> dict, int charId = -1, sbyte itemSourceType = -1, bool merge = true)
	{
		List<ItemDisplayData> dataList = null;
		if (dict != null && dict.Count > 0)
		{
			if (merge)
			{
				dataList = CharacterDomain.GetItemDisplayData(charId, dict, (ItemSourceType)itemSourceType);
			}
			else
			{
				dataList = new List<ItemDisplayData>();
				foreach (KeyValuePair<ItemKey, int> item in dict)
				{
					item.Deconstruct(out var key, out var value);
					ItemKey itemKey = key;
					int amount = value;
					ItemDisplayData itemData = DomainManager.Item.GetItemDisplayData(GetBaseItem(itemKey), amount, charId, itemSourceType);
					dataList.Add(itemData);
				}
			}
		}
		return dataList;
	}

	[DomainMethod]
	public SkillBookPageDisplayData GetSkillBookPagesInfo(ItemKey itemKey)
	{
		if (!ItemExists(itemKey))
		{
			SkillBookItem configData = Config.SkillBook.Instance[itemKey.TemplateId];
			bool isCombatSkill = configData.ItemSubType == 1001;
			SkillBookPageDisplayData skillBookPageDisplayData = new SkillBookPageDisplayData();
			skillBookPageDisplayData.ItemKey = itemKey;
			skillBookPageDisplayData.State = new sbyte[isCombatSkill ? 6 : 5];
			skillBookPageDisplayData.ReadingProgress = new sbyte[isCombatSkill ? 6 : 5];
			skillBookPageDisplayData.Type = new sbyte[isCombatSkill ? 6 : 5];
			return skillBookPageDisplayData;
		}
		SkillBook book = GetElement_SkillBooks(itemKey.Id);
		SkillBookPageDisplayData data = new SkillBookPageDisplayData();
		ushort pageState = book.GetPageIncompleteState();
		byte pageTypes = book.GetPageTypes();
		data.ItemKey = itemKey;
		if (SkillGroup.FromItemSubType(book.GetItemSubType()) == 0)
		{
			short skillTemplateId = book.GetLifeSkillTemplateId();
			TaiwuLifeSkill notLearnLifeSkill;
			if (DomainManager.Taiwu.TryGetTaiwuLifeSkill(skillTemplateId, out var lifeSkill))
			{
				data.ReadingProgress = lifeSkill.GetAllBookPageReadingProgress();
			}
			else if (DomainManager.Taiwu.TryGetNotLearnLifeSkillReadingProgress(skillTemplateId, out notLearnLifeSkill))
			{
				data.ReadingProgress = notLearnLifeSkill.GetAllBookPageReadingProgress();
			}
			else
			{
				data.ReadingProgress = new sbyte[5];
			}
			data.Type = new sbyte[5];
		}
		else
		{
			data.Type = new sbyte[6];
			data.Type[0] = SkillBookStateHelper.GetOutlinePageType(pageTypes);
			for (byte i = 1; i < 6; i++)
			{
				data.Type[i] = SkillBookStateHelper.GetNormalPageType(pageTypes, i);
			}
			short skillTemplateId2 = book.GetCombatSkillTemplateId();
			sbyte[] readingProgress = null;
			TaiwuCombatSkill notLearnCombatSkill;
			if (DomainManager.Taiwu.TryGetElement_CombatSkills(skillTemplateId2, out var combatSkill))
			{
				readingProgress = combatSkill.GetAllBookPageReadingProgress();
			}
			else if (DomainManager.Taiwu.TryGetNotLearnCombatSkillReadingProgress(skillTemplateId2, out notLearnCombatSkill))
			{
				readingProgress = notLearnCombatSkill.GetAllBookPageReadingProgress();
			}
			data.ReadingProgress = new sbyte[6];
			if (readingProgress != null)
			{
				for (byte i2 = 0; i2 < data.ReadingProgress.Length; i2++)
				{
					data.ReadingProgress[i2] = readingProgress[CombatSkillStateHelper.GetPageInternalIndex(data.Type[0], data.Type[i2], i2)];
				}
			}
			data.CombatSkillAllReadingProgress = readingProgress;
		}
		data.State = new sbyte[data.ReadingProgress.Length];
		for (byte i3 = 0; i3 < data.ReadingProgress.Length; i3++)
		{
			data.State[i3] = SkillBookStateHelper.GetPageIncompleteState(pageState, i3);
		}
		return data;
	}

	[DomainMethod]
	public List<SkillBookPageDisplayData> GetSkillBookPageDisplayDataList(List<ItemKey> itemKeyList)
	{
		return itemKeyList?.Where((ItemKey key) => key.IsValid()).Select(GetSkillBookPagesInfo).ToList() ?? new List<SkillBookPageDisplayData>();
	}

	public ItemDisplayData GetItemDisplayData(ItemBase item, int amount = 1, int charId = -1, sbyte itemSourceType = -1)
	{
		ItemKey itemKey = item.GetItemKey();
		LoveTokenDataItem loveTokenDataItem;
		ItemDisplayData itemDisplayData = new ItemDisplayData(itemKey, amount)
		{
			Durability = item.GetCurrDurability(),
			MaxDurability = item.GetMaxDurability(),
			Weight = item.GetWeight(),
			Value = DomainManager.Item.GetValue(itemKey),
			OwnerCharId = charId,
			ItemSourceType = itemSourceType,
			IsLocked = (charId == DomainManager.Taiwu.GetTaiwuCharId() && DomainManager.Taiwu.IsItemLocked(itemKey)),
			CarrierTamePoint = DomainManager.Extra.GetCarrierTamePoint(itemKey.Id),
			IsReadingFinished = (itemKey.ItemType == 10 && DomainManager.Taiwu.GetTotalReadingProgress(itemKey.Id) >= 100),
			BookPageStates = GetBookPageStates(itemKey),
			BookPageProgress = GetBookPageProgress(itemKey),
			BookPageTypes = GetBookPageTypes(itemKey),
			IsThreeCorpseKeepingLegendaryBook = DomainManager.Extra.IsThreeCorpseKeepingLegendaryBook(itemKey),
			LoveTokenDataItem = (DomainManager.Extra.TryGetLoveTokenData(itemKey, out loveTokenDataItem) ? loveTokenDataItem : new LoveTokenDataItem()),
			IsInCurrentCricketPreset = (itemKey.ItemType == 11 && charId == DomainManager.Taiwu.GetTaiwuCharId() && DomainManager.Taiwu.CheckItemIsInCurrentCricketPreset(itemKey))
		};
		if (ModificationStateHelper.IsActive(itemKey.ModificationState, 2))
		{
			itemDisplayData.RefiningEffects = DomainManager.Item.GetRefinedEffects(itemKey);
		}
		if (ModificationStateHelper.IsActive(itemKey.ModificationState, 1))
		{
			DomainManager.Extra.TryGetPoisonEffect(itemKey.Id, out itemDisplayData.PoisonEffects);
		}
		if (DomainManager.Character.TryGetElement_Objects(charId, out var targetChar))
		{
			itemDisplayData.AlertFactor = targetChar.GetItemAlertFactor(itemKey, 1);
		}
		if (item is EquipmentBase equipBase)
		{
			itemDisplayData.EquipmentEffectIds = new List<short>(from x in DomainManager.Item.GetEquipmentEffects(equipBase)
				select x.TemplateId);
			itemDisplayData.MaterialResources = equipBase.GetMaterialResources();
			if (charId >= 0)
			{
				List<ItemKey> equipmentKeys = DomainManager.Character.GetEquipmentKeys(charId);
				itemDisplayData.EquipmentSlot = (sbyte)equipmentKeys.IndexOf(itemKey);
			}
		}
		if (item is Weapon weapon)
		{
			itemDisplayData.EquipmentAttack = weapon.GetEquipmentAttack();
			itemDisplayData.EquipmentDefense = weapon.GetEquipmentDefense();
			itemDisplayData.HitAvoidFactor = ((charId >= 0) ? weapon.GetHitFactors(charId) : weapon.GetHitFactors());
			itemDisplayData.PenetrationInfo.Item1 = weapon.GetPenetrationFactor();
			IntPair expect = DomainManager.Combat.GetWeaponExpectInnerRatio(itemKey);
			WeaponItem weaponConfig = Config.Weapon.Instance[itemKey.TemplateId];
			int baseRatio = weaponConfig.DefaultInnerRatio;
			int changeRange = weaponConfig.InnerRatioAdjustRange * expect.Second / 100;
			int rangeMin = Math.Max(baseRatio - changeRange, 0);
			int rangeMax = Math.Min(baseRatio + changeRange, 100);
			itemDisplayData.WeaponInnerRatio = (sbyte)Math.Clamp(expect.First, rangeMin, rangeMax);
			itemDisplayData.WeaponTrickList = weapon.GetTricks();
			WeaponEffectDisplayData[] weaponEffects = DomainManager.Combat.GetWeaponEffects(item.GetItemKey());
			itemDisplayData.WeaponEffectDisplayDataList = weaponEffects.Where((WeaponEffectDisplayData e) => e.EffectKey.SkillId >= 0).ToList();
		}
		else if (item is Armor armor)
		{
			itemDisplayData.EquipmentAttack = armor.GetEquipmentAttack();
			itemDisplayData.EquipmentDefense = armor.GetEquipmentDefense();
			itemDisplayData.HitAvoidFactor = ((charId >= 0) ? armor.GetAvoidFactors(charId) : armor.GetAvoidFactors());
			armor.GetPenetrationResistFactors().Deconstruct(out itemDisplayData.PenetrationInfo.Item1, out itemDisplayData.PenetrationInfo.Item2);
			itemDisplayData.InjuryFactors = armor.GetInjuryFactor();
		}
		else if (itemKey.ItemType == 3)
		{
			itemDisplayData.WeavedClothingTemplateId = DomainManager.Taiwu.GetModifiedClothingTemplateId(itemKey);
		}
		if (item is Cricket cricket)
		{
			itemDisplayData.SpecialArg = ((ushort)cricket.GetColorId() << 16) | (ushort)cricket.GetPartId();
			itemDisplayData.CricketData = GetCricketData(item.GetId());
		}
		else if (item is Misc && GameData.Domains.Combat.SharedConstValue.SwordFragment2BossId.ContainsKey(itemKey.TemplateId))
		{
			itemDisplayData.SpecialArg = DomainManager.Item.GetSwordFragmentCurrSkill(itemKey);
		}
		else if (item is Carrier carrier)
		{
			itemDisplayData.TravelTimeReduction = carrier.GetTravelTimeReduction();
			itemDisplayData.MaxInventoryLoadBonus = carrier.GetMaxInventoryLoadBonus();
		}
		else if (item is Accessory accessory)
		{
			itemDisplayData.MaxInventoryLoadBonus = accessory.GetMaxInventoryLoadBonus();
			itemDisplayData.EquipmentPropertyBonusDict = new Dictionary<int, int>();
			for (ECharacterPropertyReferencedType type = ECharacterPropertyReferencedType.Strength; type <= ECharacterPropertyReferencedType.ResistOfIllusoryPoison; type++)
			{
				int value = DomainManager.Item.GetCharacterPropertyBonus(itemKey, type);
				itemDisplayData.EquipmentPropertyBonusDict[(int)type] = value;
			}
		}
		else if (item is Medicine medicine)
		{
			short baseValue = medicine.GetEffectValue();
			if (medicine.GetEffectType() != EMedicineEffectType.Invalid && charId >= 0)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				int value2 = character.GetSpecialEffectModifiedMedicineEffectValue(baseValue, itemKey.Id);
				itemDisplayData.MedicineEffectValue = value2;
			}
			else
			{
				itemDisplayData.MedicineEffectValue = baseValue;
			}
		}
		if (ItemPowerHelper.IsSupport(itemKey.ItemType))
		{
			itemDisplayData.PowerInfo = DomainManager.Character.GetItemPowerInfo(charId, itemKey);
			itemDisplayData.Requirements = DomainManager.Character.GetItemRequirementsAndActualValues(charId, itemKey);
		}
		if (itemDisplayData.ItemSourceTypeEnum == ItemSourceType.Inventory || itemDisplayData.ItemSourceTypeEnum == ItemSourceType.Equipment || itemDisplayData.ItemSourceTypeEnum == ItemSourceType.JiaoPool)
		{
			itemDisplayData.UsingType = DomainManager.Character.GetItemUsingType(itemKey, charId);
		}
		else
		{
			itemDisplayData.UsingType = ItemDisplayData.ItemUsingType.Invalid;
		}
		bool flag = ((item is Carrier || item is Material) ? true : false);
		if (flag && (DomainManager.Extra.TryGetJiaoByItemKey(itemKey, out var _) || DomainManager.Extra.TryGetChildrenOfLoongIdByItemKey(itemKey, out var _)))
		{
			itemDisplayData.JiaoLoongDisplayData = DomainManager.Extra.GetJiaoLoongDisplayDataByItemKey(itemKey, getItemData: false);
		}
		return itemDisplayData;
	}

	private sbyte[] GetBookPageStates(ItemKey itemKey)
	{
		if (itemKey.ItemType != 10)
		{
			return null;
		}
		if (!TryGetElement_SkillBooks(itemKey.Id, out var book))
		{
			return null;
		}
		ushort pageState = book.GetPageIncompleteState();
		int pageCount = ((book.GetItemSubType() == 1001) ? 6 : 5);
		sbyte[] states = new sbyte[pageCount];
		for (byte i = 0; i < pageCount; i++)
		{
			states[i] = SkillBookStateHelper.GetPageIncompleteState(pageState, i);
		}
		return states;
	}

	private sbyte[] GetBookPageTypes(ItemKey itemKey)
	{
		if (itemKey.ItemType != 10)
		{
			return null;
		}
		if (!TryGetElement_SkillBooks(itemKey.Id, out var book))
		{
			return null;
		}
		if (book.GetItemSubType() != 1001)
		{
			return null;
		}
		byte pageTypes = book.GetPageTypes();
		sbyte[] types = new sbyte[6]
		{
			SkillBookStateHelper.GetOutlinePageType(pageTypes),
			0,
			0,
			0,
			0,
			0
		};
		for (byte i = 1; i < 6; i++)
		{
			types[i] = SkillBookStateHelper.GetNormalPageType(pageTypes, i);
		}
		return types;
	}

	private sbyte[] GetBookPageProgress(ItemKey itemKey)
	{
		if (itemKey.ItemType != 10)
		{
			return null;
		}
		if (!TryGetElement_SkillBooks(itemKey.Id, out var book))
		{
			return null;
		}
		if (book.GetItemSubType() == 1001)
		{
			byte pageTypes = book.GetPageTypes();
			short skillTemplateId = book.GetCombatSkillTemplateId();
			sbyte[] readingProgress = null;
			TaiwuCombatSkill notLearnCombatSkill;
			if (DomainManager.Taiwu.TryGetElement_CombatSkills(skillTemplateId, out var combatSkill))
			{
				readingProgress = combatSkill.GetAllBookPageReadingProgress();
			}
			else if (DomainManager.Taiwu.TryGetNotLearnCombatSkillReadingProgress(skillTemplateId, out notLearnCombatSkill))
			{
				readingProgress = notLearnCombatSkill.GetAllBookPageReadingProgress();
			}
			sbyte[] progress = new sbyte[6];
			if (readingProgress != null)
			{
				sbyte outlineType = SkillBookStateHelper.GetOutlinePageType(pageTypes);
				for (byte i = 0; i < progress.Length; i++)
				{
					sbyte pageType = ((i == 0) ? outlineType : SkillBookStateHelper.GetNormalPageType(pageTypes, i));
					progress[i] = readingProgress[CombatSkillStateHelper.GetPageInternalIndex(outlineType, pageType, i)];
				}
			}
			return progress;
		}
		short skillTemplateId2 = book.GetLifeSkillTemplateId();
		if (DomainManager.Taiwu.TryGetTaiwuLifeSkill(skillTemplateId2, out var lifeSkill))
		{
			return lifeSkill.GetAllBookPageReadingProgress();
		}
		if (DomainManager.Taiwu.TryGetNotLearnLifeSkillReadingProgress(skillTemplateId2, out var notLearnLifeSkill))
		{
			return notLearnLifeSkill.GetAllBookPageReadingProgress();
		}
		return new sbyte[5];
	}

	private void OnInitializedDomainData()
	{
	}

	private void InitializeOnInitializeGameDataModule()
	{
		InitializeWugTemplateIds();
		InitializeCreationTemplateIds();
		InitializeCategorizedItemTemplates();
		InitializeCategorizedEquipmentEffects();
		InitializeSkillBreakPlateBonusEffects();
		MixedPoisonType.InitializeMaskDict();
		CricketExternalBridge.Initialize(new CricketBridgeImplement());
	}

	private void InitializeOnEnterNewWorld()
	{
		_nextItemId = 0;
		_emptyHandKey = ItemKey.Invalid;
		_branchKey = ItemKey.Invalid;
		_stoneKey = ItemKey.Invalid;
		_trackedSpecialItems.Clear();
	}

	private void OnLoadedArchiveData()
	{
		InitializeTrackedSpecialItems();
		InitializeMysteryListeners();
	}

	public void TryAddMedicineExtraAddPercent(DataContext context, int itemId, int value)
	{
		if (TryGetElement_MedicineExtraAddPercent(itemId, out var _))
		{
			SetElement_MedicineExtraAddPercent(itemId, value, context);
		}
		else
		{
			AddElement_MedicineExtraAddPercent(itemId, value, context);
		}
	}

	[Obsolete("This method is obsolete, and will be removed in future.")]
	public (int outer, int inner, int mind, int fatalDamage) GetWeaponBlockDamageValue(DataContext context, int charId, ItemKey weaponKey)
	{
		return (outer: 0, inner: 0, mind: 0, fatalDamage: 0);
	}

	private void InitializeCategorizedEquipmentEffects()
	{
		if (_categorizedEquipmentEffects == null)
		{
			_categorizedEquipmentEffects = new List<short>[3];
		}
		for (int i = 0; i < 3; i++)
		{
			List<short>[] categorizedEquipmentEffects = _categorizedEquipmentEffects;
			int num = i;
			if (categorizedEquipmentEffects[num] == null)
			{
				categorizedEquipmentEffects[num] = new List<short>();
			}
			_categorizedEquipmentEffects[i].Clear();
		}
		foreach (EquipmentEffectItem equipmentEffectCfg in (IEnumerable<EquipmentEffectItem>)EquipmentEffect.Instance)
		{
			if (!equipmentEffectCfg.Special)
			{
				switch (equipmentEffectCfg.Type)
				{
				case 0:
					_categorizedEquipmentEffects[0].Add(equipmentEffectCfg.TemplateId);
					_categorizedEquipmentEffects[1].Add(equipmentEffectCfg.TemplateId);
					_categorizedEquipmentEffects[2].Add(equipmentEffectCfg.TemplateId);
					break;
				case 1:
					_categorizedEquipmentEffects[0].Add(equipmentEffectCfg.TemplateId);
					break;
				case 2:
					_categorizedEquipmentEffects[1].Add(equipmentEffectCfg.TemplateId);
					break;
				}
			}
		}
	}

	private void InitializeSkillBreakPlateBonusEffects()
	{
		int effectCount = SkillBreakBonusEffect.Instance.Count;
		_skillBreakPlateBonusEffects = new List<TemplateKey>[effectCount];
		for (int i = 0; i < effectCount; i++)
		{
			_skillBreakPlateBonusEffects[i] = new List<TemplateKey>();
		}
		for (sbyte itemType = 0; itemType < 13; itemType++)
		{
			IList<int> keys = ItemTemplateHelper.GetTemplateDataAllKeys(itemType);
			foreach (int key in keys)
			{
				short templateId = (short)key;
				sbyte bonusEffectId = ItemTemplateHelper.GetBreakBonusEffect(itemType, templateId);
				if (bonusEffectId >= 0)
				{
					short groupId = ItemTemplateHelper.GetGroupId(itemType, templateId);
					if (groupId < 0)
					{
						groupId = templateId;
					}
					else if (groupId != templateId)
					{
						continue;
					}
					_skillBreakPlateBonusEffects[bonusEffectId].Add(new TemplateKey(itemType, groupId));
				}
			}
		}
	}

	private void InitializeCategorizedItemTemplates()
	{
		if (_categorizedItemTemplates == null)
		{
			_categorizedItemTemplates = new Dictionary<short, List<short>>[9];
		}
		for (int i = 0; i < 9; i++)
		{
			Dictionary<short, List<short>>[] categorizedItemTemplates = _categorizedItemTemplates;
			int num = i;
			if (categorizedItemTemplates[num] == null)
			{
				categorizedItemTemplates[num] = new Dictionary<short, List<short>>();
			}
			Dictionary<short, List<short>> subType2Templates = _categorizedItemTemplates[i];
			for (int itemType = 0; itemType < 13; itemType++)
			{
				short[] subTypes = ItemSubType.Type2SubTypes[itemType];
				short[] array = subTypes;
				foreach (short subType in array)
				{
					if (subType2Templates.TryGetValue(subType, out var templates))
					{
						templates.Clear();
					}
					else
					{
						_categorizedItemTemplates[i].Add(subType, new List<short>());
					}
				}
			}
		}
		for (sbyte i2 = 0; i2 < 9; i2++)
		{
			Dictionary<short, List<short>> subType2Templates2 = _categorizedItemTemplates[i2];
			for (sbyte itemType2 = 0; itemType2 < 13; itemType2++)
			{
				short[] array2 = ItemSubType.Type2SubTypes[itemType2];
				foreach (short itemSubType in array2)
				{
					if (!ItemSubType.IsHobbyType(itemSubType))
					{
						continue;
					}
					sbyte grade;
					IEnumerable<short> list;
					switch (itemType2)
					{
					case 0:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.Weapon.Instance.ToList(), ((WeaponItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.Weapon.Instance
							where item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					case 1:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.Armor.Instance.ToList(), ((ArmorItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.Armor.Instance
							where item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					case 2:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.Accessory.Instance.ToList(), ((AccessoryItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.Accessory.Instance
							where item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					case 3:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.Clothing.Instance.ToList(), ((ClothingItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.Clothing.Instance
							where item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					case 4:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.Carrier.Instance.ToList(), ((CarrierItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.Carrier.Instance
							where item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					case 5:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.Material.Instance.ToList(), ((MaterialItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.Material.Instance
							where item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					case 6:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.CraftTool.Instance.ToList(), ((CraftToolItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.CraftTool.Instance
							where item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					case 7:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.Food.Instance.ToList(), ((FoodItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.Food.Instance
							where item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					case 8:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.Medicine.Instance.ToList(), ((MedicineItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.Medicine.Instance
							where item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					case 9:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.TeaWine.Instance.ToList(), ((TeaWineItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.TeaWine.Instance
							where item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					case 10:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.SkillBook.Instance.ToList(), ((SkillBookItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.SkillBook.Instance
							where item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					case 11:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.Cricket.Instance.ToList(), ((CricketItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.Cricket.Instance
							where item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					case 12:
						grade = GetClosestNeighboringGradeWithValidItem(i2, Config.Misc.Instance.ToList(), ((MiscItem, sbyte) pair) => pair.Item1.Grade == pair.Item2 && itemSubType == pair.Item1.ItemSubType && pair.Item1.DropRate > 0);
						list = from item in Config.Misc.Instance
							where item != null && item.Grade == grade && itemSubType == item.ItemSubType && item.DropRate > 0 && item.BaseValue > 0 && item.Transferable && item.AllowRandomCreate
							select item.TemplateId;
						break;
					default:
						throw ItemTemplateHelper.CreateItemTypeException(itemType2);
					}
					subType2Templates2[itemSubType].AddRange(list);
				}
			}
		}
	}

	private void InitializeTrackedSpecialItems()
	{
		foreach (Misc misc in _misc.Values)
		{
			short templateId = misc.GetTemplateId();
			if (templateId == 267)
			{
				_trackedSpecialItems.Add(misc.GetItemKey());
			}
			else if (Config.Misc.Instance[templateId].ItemSubType == 1202)
			{
				ItemKey itemKey = misc.GetItemKey();
				_trackedSpecialItems.Add(itemKey);
				DomainManager.LegendaryBook.RegisterLegendaryBookItem(itemKey);
			}
		}
	}

	public void CheckAndTrackSpecialItem(ItemKey itemKey)
	{
		if (itemKey.ItemType == 12)
		{
			if (itemKey.TemplateId == 267)
			{
				_trackedSpecialItems.Add(itemKey);
			}
			else if (Config.Misc.Instance[itemKey.TemplateId].ItemSubType == 1202)
			{
				_trackedSpecialItems.Add(itemKey);
				DomainManager.LegendaryBook.RegisterLegendaryBookItem(itemKey);
			}
		}
	}

	public bool HasTrackedSpecialItems(sbyte itemType, short itemTemplateId)
	{
		foreach (ItemKey itemKey in _trackedSpecialItems)
		{
			if (itemKey.ItemType == itemType && itemKey.TemplateId == itemTemplateId)
			{
				return true;
			}
		}
		return false;
	}

	public ItemKey GetWuYingFromCharacterInventory(GameData.Domains.Character.Character character)
	{
		Inventory inventory = character.GetInventory();
		foreach (ItemKey itemKey in _trackedSpecialItems)
		{
			if (12 != itemKey.ItemType || 267 != itemKey.TemplateId || !inventory.Items.ContainsKey(itemKey))
			{
				continue;
			}
			return itemKey;
		}
		return ItemKey.Invalid;
	}

	public static short GetRandomEquipmentEffect(IRandomSource random, sbyte itemType)
	{
		if (!_categorizedEquipmentEffects.CheckIndex(itemType) || _categorizedEquipmentEffects[itemType].Count == 0)
		{
			return -1;
		}
		return _categorizedEquipmentEffects[itemType].GetRandom(random);
	}

	public static TemplateKey GetRandomItemGroupIdByEffect(IRandomSource random, sbyte effectId)
	{
		List<TemplateKey> list = _skillBreakPlateBonusEffects[effectId];
		return (list.Count >= 0) ? list.GetRandom(random) : TemplateKey.Invalid;
	}

	public static bool IsValidEquipmentEffectForItemType(sbyte itemType, short equipmentEffect)
	{
		return _categorizedEquipmentEffects[itemType].Contains(equipmentEffect);
	}

	public static bool CanItemBeLost(ItemKey itemKey)
	{
		if (!ItemTemplateHelper.IsTransferable(itemKey.ItemType, itemKey.TemplateId))
		{
			return false;
		}
		if (ModificationStateHelper.IsActive(itemKey.ModificationState, 4))
		{
			return false;
		}
		return true;
	}

	public ItemKey GetDefaultWeaponItemKey(DataContext context, short templateId)
	{
		switch (templateId)
		{
		case 0:
			if (!_emptyHandKey.IsValid())
			{
				SetEmptyHandKey(CreateWeapon(context, templateId, 0), context);
			}
			return _emptyHandKey;
		case 1:
			if (!_branchKey.IsValid())
			{
				SetBranchKey(CreateWeapon(context, templateId, 0), context);
			}
			return _branchKey;
		case 2:
			if (!_stoneKey.IsValid())
			{
				SetStoneKey(CreateWeapon(context, templateId, 0), context);
			}
			return _stoneKey;
		default:
			throw new Exception($"{templateId} is not a valid default weapon template id.");
		}
	}

	public ItemBase GetBaseItem(ItemKey itemKey)
	{
		int itemId = itemKey.Id;
		sbyte itemType = itemKey.ItemType;
		if (1 == 0)
		{
		}
		ItemBase result = itemType switch
		{
			0 => _weapons[itemId], 
			1 => _armors[itemId], 
			2 => _accessories[itemId], 
			3 => _clothing[itemId], 
			4 => _carriers[itemId], 
			5 => _materials[itemId], 
			6 => _craftTools[itemId], 
			7 => _foods[itemId], 
			8 => _medicines[itemId], 
			9 => _teaWines[itemId], 
			10 => _skillBooks[itemId], 
			11 => _crickets[itemId], 
			12 => _misc[itemId], 
			_ => throw ItemTemplateHelper.CreateItemTypeException(itemKey.ItemType), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public ItemBase TryGetBaseItem(ItemKey itemKey)
	{
		return TryGetBaseItem(itemKey.ItemType, itemKey.Id);
	}

	public ItemBase TryGetBaseItem(sbyte itemType, int itemId)
	{
		if (1 == 0)
		{
		}
		ItemBase result = itemType switch
		{
			0 => _weapons.GetOrDefault(itemId), 
			1 => _armors.GetOrDefault(itemId), 
			2 => _accessories.GetOrDefault(itemId), 
			3 => _clothing.GetOrDefault(itemId), 
			4 => _carriers.GetOrDefault(itemId), 
			5 => _materials.GetOrDefault(itemId), 
			6 => _craftTools.GetOrDefault(itemId), 
			7 => _foods.GetOrDefault(itemId), 
			8 => _medicines.GetOrDefault(itemId), 
			9 => _teaWines.GetOrDefault(itemId), 
			10 => _skillBooks.GetOrDefault(itemId), 
			11 => _crickets.GetOrDefault(itemId), 
			12 => _misc.GetOrDefault(itemId), 
			_ => null, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public bool ItemExists(ItemKey itemKey)
	{
		int itemId = itemKey.Id;
		sbyte itemType = itemKey.ItemType;
		if (1 == 0)
		{
		}
		bool result = itemType switch
		{
			0 => _weapons.ContainsKey(itemId), 
			1 => _armors.ContainsKey(itemId), 
			2 => _accessories.ContainsKey(itemId), 
			3 => _clothing.ContainsKey(itemId), 
			4 => _carriers.ContainsKey(itemId), 
			5 => _materials.ContainsKey(itemId), 
			6 => _craftTools.ContainsKey(itemId), 
			7 => _foods.ContainsKey(itemId), 
			8 => _medicines.ContainsKey(itemId), 
			9 => _teaWines.ContainsKey(itemId), 
			10 => _skillBooks.ContainsKey(itemId), 
			11 => _crickets.ContainsKey(itemId), 
			12 => _misc.ContainsKey(itemId), 
			_ => throw ItemTemplateHelper.CreateItemTypeException(itemKey.ItemType), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public EquipmentBase GetBaseEquipment(ItemKey itemKey)
	{
		int itemId = itemKey.Id;
		sbyte itemType = itemKey.ItemType;
		if (1 == 0)
		{
		}
		EquipmentBase result = itemType switch
		{
			0 => _weapons[itemId], 
			1 => _armors[itemId], 
			2 => _accessories[itemId], 
			3 => _clothing[itemId], 
			4 => _carriers[itemId], 
			_ => throw ItemTemplateHelper.CreateItemTypeException(itemKey.ItemType), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public EquipmentBase TryGetBaseEquipment(ItemKey itemKey)
	{
		int itemId = itemKey.Id;
		sbyte itemType = itemKey.ItemType;
		if (1 == 0)
		{
		}
		Weapon weapon;
		Armor armor;
		Accessory accessory;
		Clothing clothing;
		Carrier carrier;
		EquipmentBase result = itemType switch
		{
			0 => _weapons.TryGetValue(itemId, out weapon) ? weapon : null, 
			1 => _armors.TryGetValue(itemId, out armor) ? armor : null, 
			2 => _accessories.TryGetValue(itemId, out accessory) ? accessory : null, 
			3 => _clothing.TryGetValue(itemId, out clothing) ? clothing : null, 
			4 => _carriers.TryGetValue(itemId, out carrier) ? carrier : null, 
			_ => null, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static bool IsPureStackable(ItemBase item)
	{
		return item.GetStackable() && !ModificationStateHelper.IsAnyActive(item.GetModificationState());
	}

	public int GetCharacterPropertyBonus(ItemKey itemKey, ECharacterPropertyReferencedType propertyType)
	{
		ItemBase item = GetBaseItem(itemKey);
		return item.GetCharacterPropertyBonus(propertyType);
	}

	public static int GetDestroyedDate(ItemKey itemKey)
	{
		short preserveDuration = ItemTemplateHelper.GetPreservationDuration(itemKey.ItemType, itemKey.TemplateId);
		return (preserveDuration >= 0) ? (DomainManager.World.GetCurrDate() + preserveDuration) : int.MaxValue;
	}

	public static int GetDestroyedDate(ItemKey itemKey, int date)
	{
		short preserveDuration = ItemTemplateHelper.GetPreservationDuration(itemKey.ItemType, itemKey.TemplateId);
		return (preserveDuration >= 0) ? (date + preserveDuration) : int.MaxValue;
	}

	public int GetStackableItemIdByTemplateId(sbyte itemType, short templateId)
	{
		int value;
		return _stackableItems.TryGetValue(new TemplateKey(itemType, templateId), out value) ? value : (-1);
	}

	[DomainMethod]
	public int GetValue(ItemKey itemKey)
	{
		return GetBaseItem(itemKey).GetValue();
	}

	[DomainMethod]
	[Obsolete("Use GetValue Instead.")]
	public int GetPrice(ItemKey itemKey)
	{
		return GetBaseItem(itemKey).GetValue();
	}

	public static short GetRandomItemIdInSubType(IRandomSource random, short itemSubType, sbyte grade)
	{
		if (!ItemSubType.IsHobbyType(itemSubType))
		{
			throw new Exception($"Unsupported itemSubType {itemSubType}");
		}
		sbyte itemType = ItemSubType.GetType(itemSubType);
		Logger.Info($"Getting item of type {itemType}({ItemType.TypeId2TypeName[itemType]}) and sub type {itemSubType} with grade {grade}");
		return _categorizedItemTemplates[grade][itemSubType].GetRandom(random);
	}

	[Obsolete("This method will remove in future, use GetRandomItemIdInSubType instead.")]
	public static short GetRandomItemTemplateId(IRandomSource random, short itemSubType, sbyte grade)
	{
		return GetRandomItemIdInSubType(random, itemSubType, grade);
	}

	public static sbyte GetClosestNeighboringGradeWithValidItem<T>(sbyte grade, List<T> collection, Predicate<(T, sbyte)> matchingFunc)
	{
		int delta = ((grade < 4) ? 1 : (-1));
		for (int i = grade; i >= 0 && i < 9; i += delta)
		{
			sbyte curGrade = (sbyte)i;
			foreach (T item in collection)
			{
				if (matchingFunc((item, curGrade)))
				{
					return curGrade;
				}
			}
		}
		int i2 = grade - delta;
		while (i2 >= 0 && i2 < 9)
		{
			sbyte curGrade2 = (sbyte)i2;
			foreach (T item2 in collection)
			{
				if (matchingFunc((item2, curGrade2)))
				{
					return curGrade2;
				}
			}
			i2 -= delta;
		}
		return -1;
	}

	public short GetSwordFragmentCurrSkill(ItemKey itemKey)
	{
		if (itemKey.ItemType != 12 || !GameData.Domains.Combat.SharedConstValue.SwordFragment2BossId.TryGetValue(itemKey.TemplateId, out var bossId))
		{
			return -1;
		}
		List<sbyte> unlocked = DomainManager.Story.GetAdvanceXiangshuAvatarIds();
		List<short> skillList = Boss.Instance[bossId].PlayerCastSkills;
		XiangshuAvatarTaskStatus status = DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(bossId);
		bool favorEnough = unlocked.Contains(bossId);
		if (status.JuniorXiangshuTaskStatus == 6)
		{
			return favorEnough ? skillList[2] : skillList[0];
		}
		if (status.JuniorXiangshuTaskStatus == 5)
		{
			return favorEnough ? skillList[3] : skillList[1];
		}
		return -1;
	}

	public static long GetItemWorth(ItemKey itemKey, int amount)
	{
		long worth = 0L;
		short itemDurability = DomainManager.Item.GetBaseItem(itemKey).GetCurrDurability();
		if (itemDurability > 0)
		{
			int value = DomainManager.Item.GetValue(itemKey);
			worth = value * amount;
		}
		return worth;
	}

	public static long ResourceAmountToWorth(short resourceType, int amount)
	{
		return GlobalConfig.ResourcesWorth[resourceType] * amount;
	}

	public static long ResourceAmountToWorth(ref ResourceInts resources)
	{
		long worth = 0L;
		for (int type = 0; type < 7; type++)
		{
			worth += GlobalConfig.ResourcesWorth[type] * resources.Get(type);
		}
		return worth;
	}

	public ClothingItem GetClothingItemByDisplayId(short displayId)
	{
		foreach (ClothingItem clothingItem in (IEnumerable<ClothingItem>)Config.Clothing.Instance)
		{
			if (clothingItem.DisplayId == displayId)
			{
				return clothingItem;
			}
		}
		return null;
	}

	public List<int> GetAllCarrierIdList()
	{
		return new List<int>(_carriers.Keys);
	}

	[DomainMethod]
	public ItemKey GetEmptyToolKey(DataContext context)
	{
		return DomainManager.Extra.GetEmptyToolKey(context);
	}

	[DomainMethod]
	public int GetRepairItemNeedResourceCount(ItemKey itemKey, short targetDurability = -1)
	{
		ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
		EquipmentBase equip = DomainManager.Item.TryGetBaseEquipment(itemKey);
		if (equip == null)
		{
			return 0;
		}
		return ItemTemplateHelper.GetRepairNeedResourceCount(equip.GetMaterialResources(), itemKey, item.GetCurrDurability());
	}

	[DomainMethod]
	public List<ItemDisplayData> DisassembleItem(DataContext context, int charId, ItemKey itemKey, ItemKey toolKey, sbyte itemSourceType, sbyte toolSourceType)
	{
		if (charId == DomainManager.Taiwu.GetTaiwuCharId() && DomainManager.Taiwu.IsItemLocked(itemKey))
		{
			AdaptableLog.Error($"{itemKey} is locked!");
			return null;
		}
		List<ItemKey> keyList = DisassembleItemOptionalInternal(context, charId, itemKey, toolKey, itemSourceType, toolSourceType);
		DomainManager.Taiwu.RemoveItem(context, itemKey, 1, itemSourceType, deleteItem: true);
		if (keyList != null && keyList.Count > 0)
		{
			return GetItemDisplayDataListOptional(keyList, charId, itemSourceType);
		}
		return null;
	}

	public List<ItemKey> DisassembleItemOptionalInternal(DataContext context, int charId, ItemKey itemKey, ItemKey toolKey, sbyte itemSourceType, sbyte toolSourceType)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		ItemBase item = GetBaseItem(itemKey);
		sbyte resourceType = ItemTemplateHelper.GetResourceType(itemKey.ItemType, itemKey.TemplateId);
		if (resourceType == -1)
		{
			return null;
		}
		List<ItemKey> keyList = null;
		sbyte grade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
		int sameGradeRate = ItemTemplateHelper.GetDisassembleSameGradeRate(grade);
		short disassemblyMaterialId = ItemTemplateHelper.GetDisassemblyMaterial(itemKey.ItemType, itemKey.TemplateId, context.Random, sameGradeRate);
		if (disassemblyMaterialId > -1)
		{
			ItemKey disassemblyMaterialKey = CreateMaterial(context, disassemblyMaterialId);
			DomainManager.Taiwu.AddItem(context, disassemblyMaterialKey, 1, itemSourceType);
			if (keyList == null)
			{
				keyList = new List<ItemKey>();
			}
			keyList.Add(disassemblyMaterialKey);
		}
		if (ModificationStateHelper.IsActive(item.GetModificationState(), 2))
		{
			DomainManager.Item.GetRefinedEffects(itemKey).GetAllMaterialTemplateIds()?.ForEach(delegate(int num, short materialId)
			{
				if (materialId <= -1)
				{
					return false;
				}
				ItemKey itemKey2 = CreateMaterial(context, materialId);
				DomainManager.Taiwu.AddItem(context, itemKey2, 1, itemSourceType);
				if (keyList == null)
				{
					keyList = new List<ItemKey>();
				}
				keyList.Add(itemKey2);
				return false;
			});
		}
		if (ItemType.IsEquipmentItemType(itemKey.ItemType))
		{
			EquipmentBase equipItem = DomainManager.Item.GetBaseEquipment(itemKey);
			ResourceInts resourceInts = ItemTemplateHelper.GetDisassembleResources(equipItem.GetMaterialResources(), itemKey.ItemType, itemKey.TemplateId, 1);
			character.ChangeResources(context, ref resourceInts);
		}
		else if (itemKey.ItemType == 12)
		{
			MiscItem miscConfig = Config.Misc.Instance[itemKey.TemplateId];
			MaterialResources presetResources = MakeItemSubType.Instance[miscConfig.MakeItemSubType]?.MaxMaterialResources ?? default(MaterialResources);
			ResourceInts resourceInts2 = ItemTemplateHelper.GetDisassembleResources(presetResources, itemKey.ItemType, itemKey.TemplateId, 1);
			character.ChangeResources(context, ref resourceInts2);
		}
		else
		{
			ResourceInts resource = ItemTemplateHelper.GetDisassembleResources(default(MaterialResources), itemKey.ItemType, itemKey.TemplateId, 1);
			character.ChangeResources(context, ref resource);
			if (itemKey.ItemType == 5)
			{
				MaterialItem config = Config.Material.Instance[itemKey.TemplateId];
				List<PresetInventoryItem> disassembleResultItemList = config.DisassembleResultItemList;
				if (disassembleResultItemList != null && disassembleResultItemList.Count > 0 && config.DisassembleResultCount > 0)
				{
					int rate = 0;
					List<PresetInventoryItem> rateList = new List<PresetInventoryItem>();
					rateList.AddRange(config.DisassembleResultItemList);
					for (int i = 0; i < config.DisassembleResultItemList.Count; i++)
					{
						PresetInventoryItem resultItem = config.DisassembleResultItemList[i];
						int curRate = resultItem.Amount;
						rate += curRate;
						rateList[i] = new PresetInventoryItem(resultItem.Type, resultItem.TemplateId, rate, 100);
					}
					for (int i2 = 0; i2 < config.DisassembleResultCount; i2++)
					{
						int random = context.Random.Next(rateList.Last().Amount) + 1;
						int index = rateList.FindIndex((PresetInventoryItem r) => random <= r.Amount);
						PresetInventoryItem result = rateList[index];
						ItemKey resultItemKey = DomainManager.Item.CreateItem(context, result.Type, result.TemplateId);
						if (keyList == null)
						{
							keyList = new List<ItemKey>();
						}
						keyList.Add(resultItemKey);
						DomainManager.Taiwu.AddItem(context, resultItemKey, 1, itemSourceType);
					}
				}
				int value = DomainManager.Item.GetValue(itemKey);
				int seniority = ProfessionFormulaImpl.Calculate(4, value);
				DomainManager.Extra.ChangeProfessionSeniority(context, 0, seniority);
			}
		}
		if (itemKey.ItemType != 5)
		{
			sbyte skillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(itemKey.ItemType, itemKey.TemplateId);
			if (((uint)(skillType - 6) <= 1u || (uint)(skillType - 10) <= 1u) ? true : false)
			{
				int seniority2 = ProfessionFormulaImpl.Calculate(17, grade);
				DomainManager.Extra.ChangeProfessionSeniority(context, 2, seniority2);
			}
		}
		if (toolKey.IsValid())
		{
			CraftToolItem toolConfig = Config.CraftTool.Instance[toolKey.TemplateId];
			short cost = toolConfig.DurabilityCost[grade];
			if (cost > 0)
			{
				ReduceToolDurability(context, charId, toolKey, cost, toolSourceType);
			}
		}
		return keyList;
	}

	[DomainMethod]
	public List<ItemDisplayData> DisassembleItemList(DataContext context, int charId, List<MultiplyOperation> operationList)
	{
		List<ItemDisplayData> dataList = new List<ItemDisplayData>();
		foreach (MultiplyOperation operation in operationList)
		{
			for (int i = 0; i < operation.Count; i++)
			{
				List<ItemDisplayData> resultList = DisassembleItem(context, charId, operation.Target, operation.Tool, operation.TargetItemSourceType, operation.ToolItemSourceType);
				if (resultList == null || resultList.Count <= 0)
				{
					continue;
				}
				foreach (ItemDisplayData newItem in resultList)
				{
					ItemDisplayData oldItem = dataList.Find((ItemDisplayData itemDisplayData) => itemDisplayData.Key.TemplateEquals(newItem.Key));
					if (oldItem == null)
					{
						dataList.Add(newItem);
					}
					else
					{
						oldItem.Amount += newItem.Amount;
					}
				}
			}
		}
		return dataList;
	}

	[DomainMethod]
	public void DiscardItem(DataContext context, int charId, ItemKey itemKey, sbyte itemSourceType, int count = 1)
	{
		if (DomainManager.Taiwu.IsItemLocked(itemKey))
		{
			AdaptableLog.Error($"{itemKey} is locked!");
		}
		else if (ItemTemplateHelper.IsMiscResource(itemKey.ItemType, itemKey.TemplateId))
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			sbyte resourceType = ItemTemplateHelper.GetMiscResourceType(itemKey.ItemType, itemKey.TemplateId);
			character.ChangeResourceWithoutChecking(context, resourceType, -count);
		}
		else
		{
			DomainManager.Taiwu.RemoveItem(context, itemKey, count, itemSourceType, deleteItem: true);
		}
	}

	[DomainMethod]
	public void DiscardItemList(DataContext context, int charId, List<ItemKey> keyList, sbyte itemSourceType)
	{
		Tester.Assert(keyList != null);
		Tester.Assert(keyList.Count > 0);
		foreach (ItemKey key in keyList)
		{
			DiscardItem(context, charId, key, itemSourceType);
		}
	}

	[DomainMethod]
	public void DiscardItemInventory(DataContext context, int charId, Inventory inventory, sbyte itemSourceType)
	{
		Tester.Assert(inventory != null);
		foreach (var (key, count) in inventory.Items)
		{
			DiscardItem(context, charId, key, itemSourceType, count);
		}
	}

	[DomainMethod]
	public List<ItemKey> GetRepairableItems(DataContext context, int charId, ItemKey toolKey)
	{
		List<ItemKey> ret = new List<ItemKey>();
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		Dictionary<ItemKey, int> inventoryItems = character.GetInventory().Items;
		if (!toolKey.TemplateEquals(DomainManager.Item.GetEmptyToolKey(context)))
		{
			if (!inventoryItems.ContainsKey(toolKey))
			{
				return ret;
			}
			CraftTool tool = GetElement_CraftTools(toolKey.Id);
			if (tool.GetCurrDurability() <= 0)
			{
				return ret;
			}
		}
		List<sbyte> toolRequiredLifeSkillTypes = Config.CraftTool.Instance[toolKey.TemplateId].RequiredLifeSkillTypes;
		foreach (var (itemKey2, _) in inventoryItems)
		{
			Do(itemKey2);
		}
		ItemKey[] equipment = character.GetEquipment();
		foreach (ItemKey itemKey3 in equipment)
		{
			Do(itemKey3);
		}
		return ret;
		void Do(ItemKey itemKey4)
		{
			if (itemKey4.IsValid() && DomainManager.Item.CheckItemNeedRepair(itemKey4))
			{
				sbyte itemRequiredLifeSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(itemKey4.ItemType, itemKey4.TemplateId);
				if (toolRequiredLifeSkillTypes.Contains(itemRequiredLifeSkillType))
				{
					ret.Add(itemKey4);
				}
			}
		}
	}

	[DomainMethod]
	public List<ItemKey> GetDisassemblableItems(DataContext context, int charId, ItemKey toolKey)
	{
		List<ItemKey> ret = new List<ItemKey>();
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		Dictionary<ItemKey, int> inventoryItems = character.GetInventory().Items;
		if (!toolKey.TemplateEquals(DomainManager.Item.GetEmptyToolKey(context)))
		{
			if (!inventoryItems.ContainsKey(toolKey))
			{
				return ret;
			}
			CraftTool tool = GetElement_CraftTools(toolKey.Id);
			if (tool.GetCurrDurability() <= 0)
			{
				return ret;
			}
		}
		List<sbyte> toolRequiredLifeSkillTypes = Config.CraftTool.Instance[toolKey.TemplateId].RequiredLifeSkillTypes;
		foreach (var (itemKey2, _) in inventoryItems)
		{
			Do(itemKey2);
		}
		ItemKey[] equipment = character.GetEquipment();
		foreach (ItemKey itemKey3 in equipment)
		{
			Do(itemKey3);
		}
		return ret;
		void Do(ItemKey itemKey4)
		{
			if (itemKey4.IsValid() && ItemTemplateHelper.GetCanDisassemble(itemKey4.ItemType, itemKey4.TemplateId))
			{
				sbyte itemRequiredLifeSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(itemKey4.ItemType, itemKey4.TemplateId);
				if (toolRequiredLifeSkillTypes.Contains(itemRequiredLifeSkillType))
				{
					ItemBase item = DomainManager.Item.GetBaseItem(itemKey4);
					ret.Add(item.GetItemKey());
				}
			}
		}
	}

	public bool CheckItemNeedRepair(ItemKey itemKey)
	{
		if (!itemKey.IsValid())
		{
			return false;
		}
		ItemBase baseItem = DomainManager.Item.GetBaseItem(itemKey);
		return baseItem.GetRepairable() && baseItem.GetCurrDurability() < baseItem.GetMaxDurability();
	}

	public void ReduceToolDurability(DataContext context, int charId, ItemKey toolKey, int reduceValue, sbyte itemSourceType)
	{
		if (ItemTemplateHelper.IsEmptyTool(toolKey.ItemType, toolKey.TemplateId))
		{
			return;
		}
		CraftTool tool = DomainManager.Item.GetElement_CraftTools(toolKey.Id);
		int curDurability = Math.Max(0, tool.GetCurrDurability() - reduceValue);
		tool.SetCurrDurability((short)curDurability, context);
		if (tool.GetCurrDurability() <= 0)
		{
			if (charId == DomainManager.Taiwu.GetTaiwuCharId())
			{
				DomainManager.Taiwu.RemoveItem(context, toolKey, 1, itemSourceType, deleteItem: true);
				return;
			}
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			character.RemoveInventoryItem(context, toolKey, 1, deleteItem: true);
		}
	}

	public void ReduceAccessoryDurability(DataContext context, int charId, ItemKey itemKey, int reduceValue, sbyte itemSourceType = 1)
	{
		Accessory accessory = DomainManager.Item.GetElement_Accessories(itemKey.Id);
		int curDurability = Math.Max(0, accessory.GetCurrDurability() - reduceValue);
		accessory.SetCurrDurability((short)curDurability, context);
		if (accessory.GetCurrDurability() <= 0)
		{
			if (charId == DomainManager.Taiwu.GetTaiwuCharId())
			{
				DomainManager.Taiwu.RemoveItem(context, itemKey, 1, itemSourceType, deleteItem: true);
				return;
			}
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			character.RemoveInventoryItem(context, itemKey, 1, deleteItem: true);
		}
	}

	private void InitializeCreationTemplateIds()
	{
		Cricket.InitializeCricketWeights();
	}

	public ItemKey CreateItem(DataContext context, sbyte itemType, short templateId)
	{
		if (ItemTemplateHelper.IsStackable(itemType, templateId))
		{
			int itemId = GetStackableItem(context, itemType, templateId);
			return new ItemKey(itemType, 0, templateId, itemId);
		}
		ItemBase item = CreateItemInternal(context, itemType, templateId);
		return item.GetItemKey();
	}

	public ItemKey CreateCopyOfItem(DataContext context, ItemKey srcItemKey)
	{
		if (ItemTemplateHelper.IsPureStackable(srcItemKey))
		{
			return srcItemKey;
		}
		IRandomSource random = context.Random;
		int itemId = GenerateNextItemId(context);
		CopyModificationState(context, srcItemKey, itemId);
		switch (srcItemKey.ItemType)
		{
		case 0:
		{
			Weapon srcItem2 = GetElement_Weapons(srcItemKey.Id);
			Weapon item2 = GameData.Serializer.Serializer.CreateCopy(srcItem2);
			item2.OfflineSetId(itemId);
			item2.OfflineSetEquippedCharId(-1);
			AddElement_Weapons(itemId, item2);
			return item2.GetItemKey();
		}
		case 1:
		{
			Armor srcItem3 = GetElement_Armors(srcItemKey.Id);
			Armor item3 = GameData.Serializer.Serializer.CreateCopy(srcItem3);
			item3.OfflineSetId(itemId);
			item3.OfflineSetEquippedCharId(-1);
			AddElement_Armors(itemId, item3);
			return item3.GetItemKey();
		}
		case 2:
		{
			Accessory srcItem4 = GetElement_Accessories(srcItemKey.Id);
			Accessory item4 = GameData.Serializer.Serializer.CreateCopy(srcItem4);
			item4.OfflineSetId(itemId);
			item4.OfflineSetEquippedCharId(-1);
			AddElement_Accessories(itemId, item4);
			return item4.GetItemKey();
		}
		case 3:
		{
			Clothing srcItem13 = GetElement_Clothing(srcItemKey.Id);
			Clothing item13 = GameData.Serializer.Serializer.CreateCopy(srcItem13);
			item13.OfflineSetId(itemId);
			item13.OfflineSetEquippedCharId(-1);
			AddElement_Clothing(itemId, item13);
			return item13.GetItemKey();
		}
		case 4:
		{
			Carrier srcItem12 = GetElement_Carriers(srcItemKey.Id);
			Carrier item12 = GameData.Serializer.Serializer.CreateCopy(srcItem12);
			item12.OfflineSetId(itemId);
			item12.OfflineSetEquippedCharId(-1);
			AddElement_Carriers(itemId, item12);
			ItemKey itemKey2 = item12.GetItemKey();
			int srcLoongId;
			ChildrenOfLoong srcLoong;
			if (DomainManager.Extra.TryGetJiaoIdByItemKey(srcItemKey, out var srcJiaoId2) && DomainManager.Extra.TryGetJiao(srcJiaoId2, out var srcJiao2))
			{
				DomainManager.Extra.AddCopyOfJiao(context, srcJiao2, itemKey2);
			}
			else if (DomainManager.Extra.TryGetChildrenOfLoongIdByItemKey(srcItemKey, out srcLoongId) && DomainManager.Extra.TryGetLoong(srcLoongId, out srcLoong))
			{
				DomainManager.Extra.AddCopyOfChildOfLoong(context, srcLoong, itemKey2);
			}
			return itemKey2;
		}
		case 5:
		{
			Material srcItem11 = GetElement_Materials(srcItemKey.Id);
			Material item11 = GameData.Serializer.Serializer.CreateCopy(srcItem11);
			item11.OfflineSetId(itemId);
			AddElement_Materials(itemId, item11);
			return item11.GetItemKey();
		}
		case 6:
		{
			CraftTool srcItem10 = GetElement_CraftTools(srcItemKey.Id);
			CraftTool item10 = GameData.Serializer.Serializer.CreateCopy(srcItem10);
			item10.OfflineSetId(itemId);
			AddElement_CraftTools(itemId, item10);
			return item10.GetItemKey();
		}
		case 7:
		{
			Food srcItem9 = GetElement_Foods(srcItemKey.Id);
			Food item9 = GameData.Serializer.Serializer.CreateCopy(srcItem9);
			item9.OfflineSetId(itemId);
			AddElement_Foods(itemId, item9);
			return item9.GetItemKey();
		}
		case 8:
		{
			Medicine srcItem8 = GetElement_Medicines(srcItemKey.Id);
			Medicine item8 = GameData.Serializer.Serializer.CreateCopy(srcItem8);
			item8.OfflineSetId(itemId);
			AddElement_Medicines(itemId, item8);
			return item8.GetItemKey();
		}
		case 9:
		{
			TeaWine srcItem7 = GetElement_TeaWines(srcItemKey.Id);
			TeaWine item7 = GameData.Serializer.Serializer.CreateCopy(srcItem7);
			item7.OfflineSetId(itemId);
			AddElement_TeaWines(itemId, item7);
			return item7.GetItemKey();
		}
		case 10:
		{
			SkillBook srcItem6 = GetElement_SkillBooks(srcItemKey.Id);
			SkillBook item6 = GameData.Serializer.Serializer.CreateCopy(srcItem6);
			item6.OfflineSetId(itemId);
			AddElement_SkillBooks(itemId, item6);
			return item6.GetItemKey();
		}
		case 11:
		{
			Cricket srcItem5 = GetElement_Crickets(srcItemKey.Id);
			Cricket item5 = GameData.Serializer.Serializer.CreateCopy(srcItem5);
			item5.OfflineSetId(itemId);
			AddElement_Crickets(itemId, item5);
			Events.RaiseCricketCreated(context, item5.GetItemKey());
			return item5.GetItemKey();
		}
		case 12:
		{
			Misc srcItem = GetElement_Misc(srcItemKey.Id);
			Misc item = GameData.Serializer.Serializer.CreateCopy(srcItem);
			item.OfflineSetId(itemId);
			AddElement_Misc(itemId, item);
			ItemKey itemKey = item.GetItemKey();
			if (DomainManager.Extra.TryGetJiaoIdByItemKey(srcItemKey, out var srcJiaoId) && DomainManager.Extra.TryGetJiao(srcJiaoId, out var srcJiao))
			{
				DomainManager.Extra.AddCopyOfJiao(context, srcJiao, itemKey);
			}
			return itemKey;
		}
		default:
			throw ItemTemplateHelper.CreateItemTypeException(srcItemKey.ItemType);
		}
	}

	private void CopyModificationState(DataContext context, ItemKey srcItemKey, int destItemId)
	{
		if (ModificationStateHelper.IsActive(srcItemKey.ModificationState, 2))
		{
			RefiningEffects refiningEffect = GetRefinedEffects(srcItemKey);
			AddElement_RefinedItems(destItemId, refiningEffect, context);
		}
		if (ModificationStateHelper.IsActive(srcItemKey.ModificationState, 1))
		{
			FullPoisonEffects poisoned = GetPoisonEffects(srcItemKey);
			DomainManager.Extra.SetPoisonEffect(context, destItemId, new FullPoisonEffects(poisoned));
		}
	}

	public ItemKey CreateEquipment(DataContext context, sbyte itemType, short templateId, int spawnSpecialEffectChance)
	{
		int itemId = GenerateNextItemId(context);
		EquipmentBase equipment = CreateEquipmentInternal(context, itemId, itemType, templateId, 0);
		if (context.Random.CheckPercentProb(spawnSpecialEffectChance))
		{
			equipment.OfflineGenerateEquipmentEffect(context.Random);
			equipment.SetEquipmentEffectId(equipment.GetEquipmentEffectId(), context);
			equipment.SetCurrDurability(equipment.GetCurrDurability(), context);
			equipment.SetMaxDurability(equipment.GetMaxDurability(), context);
		}
		return equipment.GetItemKey();
	}

	public ItemKey CreateWeapon(DataContext context, short templateId, sbyte spawnSpecialEffectMultiplier = 1)
	{
		WeaponItem itemCfg = Config.Weapon.Instance[templateId];
		Tester.Assert(!itemCfg.Stackable);
		int itemId = GenerateNextItemId(context);
		EquipmentBase item = CreateEquipmentInternal(context, itemId, 0, templateId, spawnSpecialEffectMultiplier);
		return item.GetItemKey();
	}

	public ItemKey CreateArmor(DataContext context, short templateId, sbyte spawnSpecialEffectMultiplier = 1)
	{
		Tester.Assert(!Config.Armor.Instance[templateId].Stackable);
		int itemId = GenerateNextItemId(context);
		EquipmentBase item = CreateEquipmentInternal(context, itemId, 1, templateId, spawnSpecialEffectMultiplier);
		return item.GetItemKey();
	}

	public ItemKey CreateAccessory(DataContext context, short templateId, sbyte spawnSpecialEffectMultiplier = 1)
	{
		Tester.Assert(!Config.Accessory.Instance[templateId].Stackable);
		int itemId = GenerateNextItemId(context);
		EquipmentBase item = CreateEquipmentInternal(context, itemId, 2, templateId, spawnSpecialEffectMultiplier);
		return item.GetItemKey();
	}

	public ItemKey CreateClothing(DataContext context, short templateId, sbyte gender)
	{
		Tester.Assert(!Config.Clothing.Instance[templateId].Stackable);
		int itemId = GenerateNextItemId(context);
		EquipmentBase item = CreateEquipmentInternal(context, itemId, 3, templateId, 1);
		return item.GetItemKey();
	}

	public ItemKey CreateCarrier(DataContext context, short templateId)
	{
		Tester.Assert(!Config.Carrier.Instance[templateId].Stackable);
		int itemId = GenerateNextItemId(context);
		EquipmentBase item = CreateEquipmentInternal(context, itemId, 4, templateId, 1);
		return item.GetItemKey();
	}

	public ItemKey CreateMaterial(DataContext context, short templateId)
	{
		Tester.Assert(Config.Material.Instance[templateId].Stackable);
		int itemId = GetStackableItem(context, 5, templateId);
		return new ItemKey(5, 0, templateId, itemId);
	}

	public ItemKey CreateCraftTool(DataContext context, short templateId)
	{
		Tester.Assert(!Config.CraftTool.Instance[templateId].Stackable);
		int itemId = GenerateNextItemId(context);
		CraftTool item = new CraftTool(context.Random, templateId, itemId);
		AddElement_CraftTools(itemId, item);
		return item.GetItemKey();
	}

	public ItemKey CreateFood(DataContext context, short templateId)
	{
		Tester.Assert(Config.Food.Instance[templateId].Stackable);
		int itemId = GetStackableItem(context, 7, templateId);
		return new ItemKey(7, 0, templateId, itemId);
	}

	public ItemKey CreateMedicine(DataContext context, short templateId)
	{
		Tester.Assert(Config.Medicine.Instance[templateId].Stackable);
		int itemId = GetStackableItem(context, 8, templateId);
		return new ItemKey(8, 0, templateId, itemId);
	}

	public ItemKey CreateTeaWine(DataContext context, short templateId)
	{
		Tester.Assert(Config.TeaWine.Instance[templateId].Stackable);
		int itemId = GetStackableItem(context, 9, templateId);
		return new ItemKey(9, 0, templateId, itemId);
	}

	public ItemKey CreateDemandedSkillBook(DataContext context, short templateId, byte ensuredPageIndex, byte pageTypes = 0)
	{
		SkillBookItem bookCfg = Config.SkillBook.Instance[templateId];
		ItemKey itemKey;
		if (bookCfg.CombatSkillType >= 0)
		{
			sbyte lostPagesCount = (sbyte)context.Random.Next(6);
			itemKey = DomainManager.Item.CreateSkillBook(context, templateId, pageTypes, 0, lostPagesCount);
		}
		else
		{
			sbyte lostPagesCount2 = (sbyte)context.Random.Next(6);
			itemKey = DomainManager.Item.CreateSkillBook(context, templateId, 0, lostPagesCount2, -1, 50);
		}
		SkillBook skillBook = _skillBooks[itemKey.Id];
		sbyte skillGroup = SkillGroup.FromItemSubType(bookCfg.ItemSubType);
		sbyte creatingGrade = (sbyte)(bookCfg.Grade + 2);
		ushort incompleteState = SkillBook.GeneratePageIncompleteState(context.Random, skillGroup, creatingGrade, -1, -1, outlineAlwaysComplete: true);
		incompleteState = SkillBookStateHelper.SetPageIncompleteState(incompleteState, ensuredPageIndex, 0);
		skillBook.SetPageIncompleteState(incompleteState, context);
		return itemKey;
	}

	public ItemKey CreateSkillBook(DataContext context, short templateId, sbyte completePagesCount = -1, sbyte lostPagesCount = -1, sbyte outlinePageType = -1, sbyte normalPagesDirectProb = 50, bool outlineAlwaysComplete = true)
	{
		Tester.Assert(!Config.SkillBook.Instance[templateId].Stackable);
		int itemId = GenerateNextItemId(context);
		SkillBook item = new SkillBook(context.Random, templateId, itemId, completePagesCount, lostPagesCount, outlinePageType, normalPagesDirectProb, outlineAlwaysComplete);
		AddElement_SkillBooks(itemId, item);
		return item.GetItemKey();
	}

	public ItemKey CreateSkillBook(DataContext context, short templateId, byte pageTypes, sbyte completePagesCount = -1, sbyte lostPagesCount = -1, bool outlineAlwaysComplete = true)
	{
		Tester.Assert(!Config.SkillBook.Instance[templateId].Stackable);
		int itemId = GenerateNextItemId(context);
		SkillBook item = new SkillBook(context.Random, templateId, itemId, pageTypes, completePagesCount, lostPagesCount, outlineAlwaysComplete);
		AddElement_SkillBooks(itemId, item);
		return item.GetItemKey();
	}

	public ItemKey CreateSkillBook(DataContext context, short templateId, ushort activationState)
	{
		Tester.Assert(!Config.SkillBook.Instance[templateId].Stackable);
		int itemId = GenerateNextItemId(context);
		SkillBook item = new SkillBook(context.Random, templateId, itemId, activationState);
		AddElement_SkillBooks(itemId, item);
		return item.GetItemKey();
	}

	public ItemKey CreateSkillBook(DataContext context, short templateId, byte pageTypes, ushort pageIncompleteState)
	{
		Tester.Assert(!Config.SkillBook.Instance[templateId].Stackable);
		int itemId = GenerateNextItemId(context);
		SkillBook item = new SkillBook(context.Random, templateId, itemId, pageTypes, pageIncompleteState);
		AddElement_SkillBooks(itemId, item);
		return item.GetItemKey();
	}

	public ItemKey CreateCricket(DataContext context, short colorId, short partId)
	{
		int itemId = GenerateNextItemId(context);
		Cricket item = new Cricket(context.Random, colorId, partId, itemId);
		Tester.Assert(!Config.Cricket.Instance[item.GetTemplateId()].Stackable);
		AddElement_Crickets(itemId, item);
		Events.RaiseCricketCreated(context, item.GetItemKey());
		return item.GetItemKey();
	}

	public ItemKey CreateCricket(DataContext context, short templateId)
	{
		Tester.Assert(!Config.Cricket.Instance[templateId].Stackable);
		int itemId = GenerateNextItemId(context);
		Cricket item = new Cricket(context.Random, templateId, itemId);
		AddElement_Crickets(itemId, item);
		Events.RaiseCricketCreated(context, item.GetItemKey());
		return item.GetItemKey();
	}

	public ItemKey CreateCricket(DataContext context, short templateId, bool isSpecial)
	{
		Tester.Assert(!Config.Cricket.Instance[templateId].Stackable);
		int itemId = GenerateNextItemId(context);
		Cricket item = new Cricket(context.Random, templateId, itemId, isSpecial);
		AddElement_Crickets(itemId, item);
		Events.RaiseCricketCreated(context, item.GetItemKey());
		return item.GetItemKey();
	}

	public ItemKey CreateMisc(DataContext context, short templateId)
	{
		if (Config.Misc.Instance[templateId].Stackable)
		{
			int itemId = GetStackableItem(context, 12, templateId);
			return new ItemKey(12, 0, templateId, itemId);
		}
		int itemId2 = GenerateNextItemId(context);
		Misc item = new Misc(context.Random, templateId, itemId2);
		AddElement_Misc(itemId2, item);
		return item.GetItemKey();
	}

	public void RemoveItem(DataContext context, ItemKey itemKey)
	{
		if (TryGetElement_MedicineExtraAddPercent(itemKey.Id, out var _))
		{
			RemoveElement_MedicineExtraAddPercent(itemKey.Id, context);
		}
		if (ItemTemplateHelper.IsPureStackable(itemKey))
		{
			return;
		}
		int itemId = itemKey.Id;
		_trackedSpecialItems.Remove(itemKey);
		if (_mysteryData.ContainsKey(itemId))
		{
			RemoveMysteryListener(itemId);
			RemoveElement_MysteryData(itemId, context);
		}
		RemoveItemInternal(itemKey.ItemType, itemId);
		byte state = itemKey.ModificationState;
		if (ModificationStateHelper.IsActive(state, 1))
		{
			RemoveElement_PoisonItems(itemId, context);
			DomainManager.Extra.RemovePoisonEffect(context, itemId);
		}
		if (ModificationStateHelper.IsActive(state, 2))
		{
			RemoveElement_RefinedItems(itemId, context);
		}
		if (ModificationStateHelper.IsActive(state, 4))
		{
			DomainManager.Extra.RemoveLoveTokenData(context, itemKey, itemIsDeleted: true);
		}
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(2);
		if (professionData?.SkillsData is CraftSkillsData craftSkillsData)
		{
			Dictionary<ItemKey, GameData.Utilities.ShortList> weaponOriginTrickDict = craftSkillsData.WeaponOriginTrickDict;
			if (weaponOriginTrickDict != null && weaponOriginTrickDict.Remove(itemKey))
			{
				DomainManager.Extra.SetProfessionData(context, professionData);
			}
		}
	}

	public void ForceRemoveItem(DataContext context, ItemKey itemKey)
	{
		int itemId = itemKey.Id;
		_trackedSpecialItems.Remove(itemKey);
		if (_mysteryData.ContainsKey(itemId))
		{
			RemoveMysteryListener(itemId);
			RemoveElement_MysteryData(itemId, context);
		}
		RemoveItemInternal(itemKey.ItemType, itemId);
		if (_poisonItems.ContainsKey(itemId))
		{
			RemoveElement_PoisonItems(itemId, context);
		}
		if (DomainManager.Extra.PoisonEffects.ContainsKey(itemId))
		{
			DomainManager.Extra.RemovePoisonEffect(context, itemId);
		}
		if (_refinedItems.ContainsKey(itemId))
		{
			RemoveElement_RefinedItems(itemId, context);
		}
	}

	public void RemoveItems(DataContext context, List<ItemKey> itemKeys)
	{
		int i = 0;
		for (int count = itemKeys.Count; i < count; i++)
		{
			RemoveItem(context, itemKeys[i]);
		}
	}

	public void RemoveItems(DataContext context, Dictionary<ItemKey, int> items)
	{
		foreach (var (itemKey2, _) in items)
		{
			RemoveItem(context, itemKey2);
		}
	}

	public void RemoveItems(DataContext context, List<(ItemKey, int)> items)
	{
		foreach (var item in items)
		{
			ItemKey itemKey = item.Item1;
			RemoveItem(context, itemKey);
		}
	}

	public static short GenerateRandomItemTemplateId(IRandomSource random, sbyte itemType, short groupBeginId, sbyte expectedGrade)
	{
		sbyte randomItemGrade = GenerateRandomItemGrade(random, expectedGrade);
		if (itemType == 8 && Config.Medicine.Instance[groupBeginId].ItemSubType == 800)
		{
			randomItemGrade = GetRandomMedicineGrade(randomItemGrade);
			return (short)(groupBeginId + randomItemGrade);
		}
		return ItemTemplateHelper.GetTemplateIdInGroup(itemType, groupBeginId, randomItemGrade);
	}

	public static sbyte GenerateRandomItemGrade(IRandomSource random, sbyte itemGrade)
	{
		int mean = itemGrade + -2;
		return (sbyte)RedzenHelper.SkewDistribute(random, mean, 0.333333f, 3f, 0, itemGrade);
	}

	public static sbyte GetRandomMedicineGrade(sbyte generatedGrade)
	{
		generatedGrade = (sbyte)(generatedGrade / 2 + 1);
		return (sbyte)((generatedGrade > 5) ? 5 : generatedGrade);
	}

	private int GenerateNextItemId(DataContext context)
	{
		int itemId = _nextItemId;
		_nextItemId++;
		if ((uint)_nextItemId > 2147483647u)
		{
			_nextItemId = 0;
		}
		SetNextItemId(_nextItemId, context);
		return itemId;
	}

	private int GetStackableItem(DataContext context, sbyte itemType, short templateId)
	{
		TemplateKey templateKey = new TemplateKey(itemType, templateId);
		if (_stackableItems.TryGetValue(templateKey, out var itemId))
		{
			return itemId;
		}
		ItemBase item = CreateItemInternal(context, itemType, templateId);
		Tester.Assert(item.GetModificationState() == 0);
		itemId = item.GetId();
		AddElement_StackableItems(templateKey, itemId, context);
		return itemId;
	}

	public ItemBase CreateUniqueStackableItem(DataContext context, sbyte itemType, short templateId)
	{
		ItemBase item = CreateItemInternal(context, itemType, templateId);
		Tester.Assert(item.GetModificationState() == 0);
		return item;
	}

	private EquipmentBase CreateEquipmentInternal(DataContext context, int itemId, sbyte itemType, short templateId, sbyte spawnSpecialEffectMultiplier = 1)
	{
		IRandomSource random = context.Random;
		if (1 == 0)
		{
		}
		EquipmentBase equipmentBase = itemType switch
		{
			0 => new Weapon(random, templateId, itemId), 
			1 => new Armor(random, templateId, itemId), 
			2 => new Accessory(random, templateId, itemId), 
			3 => new Clothing(random, templateId, itemId, -1), 
			4 => new Carrier(random, templateId, itemId), 
			_ => throw new Exception($"ItemType {itemType} is not an equipment"), 
		};
		if (1 == 0)
		{
		}
		EquipmentBase equipment = equipmentBase;
		if ((uint)(itemType - 3) <= 1u)
		{
			spawnSpecialEffectMultiplier = 0;
		}
		if (random.CheckPercentProb(GlobalConfig.Instance.EquipmentWithEffectRate * spawnSpecialEffectMultiplier))
		{
			equipment.OfflineGenerateEquipmentEffect(random);
		}
		equipment.OfflineGenerateMaterialResources(random);
		switch (itemType)
		{
		case 0:
			AddElement_Weapons(itemId, (Weapon)equipment);
			break;
		case 1:
			AddElement_Armors(itemId, (Armor)equipment);
			break;
		case 2:
			AddElement_Accessories(itemId, (Accessory)equipment);
			break;
		case 3:
			AddElement_Clothing(itemId, (Clothing)equipment);
			break;
		case 4:
			AddElement_Carriers(itemId, (Carrier)equipment);
			Events.RaiseCarrierCreated(context, equipment.GetItemKey());
			break;
		}
		int mysteryEffectId = equipment.GetItemKey().GetConfig().MysteryEffectId;
		if (mysteryEffectId >= 0)
		{
			MysteryData mysteryData = new MysteryData();
			AddElement_MysteryData(itemId, mysteryData, context);
			AddMysteryListener(itemId);
		}
		return equipment;
	}

	private ItemBase CreateItemInternal(DataContext context, sbyte itemType, short templateId)
	{
		IRandomSource random = context.Random;
		int itemId = GenerateNextItemId(context);
		switch (itemType)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
			return CreateEquipmentInternal(context, itemId, itemType, templateId, 1);
		case 5:
		{
			Material item6 = new Material(random, templateId, itemId);
			AddElement_Materials(itemId, item6);
			return item6;
		}
		case 6:
		{
			CraftTool item8 = new CraftTool(random, templateId, itemId);
			AddElement_CraftTools(itemId, item8);
			return item8;
		}
		case 7:
		{
			Food item7 = new Food(random, templateId, itemId);
			AddElement_Foods(itemId, item7);
			return item7;
		}
		case 8:
		{
			MedicineItem template = Config.Medicine.Instance[templateId];
			if (template.IsVirtual)
			{
				throw new InvalidOperationException($"Unable to create instance of a virtual item {template.Name}({templateId}).");
			}
			Medicine item5 = new Medicine(random, templateId, itemId);
			AddElement_Medicines(itemId, item5);
			return item5;
		}
		case 9:
		{
			TeaWine item4 = new TeaWine(random, templateId, itemId);
			AddElement_TeaWines(itemId, item4);
			return item4;
		}
		case 10:
		{
			SkillBook item3 = new SkillBook(random, templateId, itemId, -1, -1, -1, 50);
			AddElement_SkillBooks(itemId, item3);
			return item3;
		}
		case 11:
		{
			Cricket item2 = new Cricket(random, templateId, itemId);
			AddElement_Crickets(itemId, item2);
			Events.RaiseCricketCreated(context, item2.GetItemKey());
			return item2;
		}
		case 12:
		{
			Misc item = new Misc(random, templateId, itemId);
			AddElement_Misc(itemId, item);
			CheckAndTrackSpecialItem(item.GetItemKey());
			return item;
		}
		default:
			throw ItemTemplateHelper.CreateItemTypeException(itemType);
		}
	}

	private void RemoveItemInternal(sbyte itemType, int itemId)
	{
		switch (itemType)
		{
		case 0:
		{
			if (TryGetElement_Weapons(itemId, out var weapon))
			{
				Events.RaiseWeaponRemoved(DataContextManager.GetCurrentThreadDataContext(), weapon.GetItemKey());
			}
			RemoveElement_Weapons(itemId);
			break;
		}
		case 1:
			RemoveElement_Armors(itemId);
			break;
		case 2:
			RemoveElement_Accessories(itemId);
			break;
		case 3:
			RemoveElement_Clothing(itemId);
			break;
		case 4:
			Events.RaiseCarrierRemoved(DataContextManager.GetCurrentThreadDataContext(), GetElement_Carriers(itemId).GetItemKey());
			RemoveElement_Carriers(itemId);
			break;
		case 5:
			RemoveElement_Materials(itemId);
			break;
		case 6:
			RemoveElement_CraftTools(itemId);
			break;
		case 7:
			RemoveElement_Foods(itemId);
			break;
		case 8:
			RemoveElement_Medicines(itemId);
			break;
		case 9:
			RemoveElement_TeaWines(itemId);
			break;
		case 10:
			RemoveElement_SkillBooks(itemId);
			break;
		case 11:
			Events.RaiseCricketRemoved(DataContextManager.GetCurrentThreadDataContext(), GetElement_Crickets(itemId).GetItemKey());
			RemoveElement_Crickets(itemId);
			break;
		case 12:
			RemoveElement_Misc(itemId);
			break;
		default:
			throw ItemTemplateHelper.CreateItemTypeException(itemType);
		}
	}

	public bool IsInStackableItems(ItemKey itemKey)
	{
		TemplateKey templateKey = new TemplateKey(itemKey.ItemType, itemKey.TemplateId);
		int id;
		return _stackableItems.TryGetValue(templateKey, out id) && itemKey.Id == id;
	}

	public override void UnpackCrossArchiveGameData(DataContext context, CrossArchiveGameData crossArchiveGameData)
	{
		foreach (KeyValuePair<int, ItemBase> item in crossArchiveGameData.ItemGroupPackage.Items)
		{
			UnpackCrossArchiveItem(context, crossArchiveGameData, item.Key);
		}
		crossArchiveGameData.ItemGroupPackage = null;
	}

	internal void PackCrossArchiveItem(CrossArchiveGameData crossArchiveGameData, ItemKey itemKey)
	{
		if (ItemExists(itemKey))
		{
			ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
			item.ResetOwner();
			if (crossArchiveGameData.ItemGroupPackage == null)
			{
				crossArchiveGameData.ItemGroupPackage = new ItemGroupPackage();
			}
			PackItem(crossArchiveGameData.ItemGroupPackage, item);
		}
	}

	internal ItemKey UnpackCrossArchiveItem(DataContext context, CrossArchiveGameData crossArchiveGameData, ItemKey srcItemKey)
	{
		bool isLocked = crossArchiveGameData.LockedItems.Items.ContainsKey(srcItemKey);
		ItemKey itemKey = UnpackCrossArchiveItem(context, crossArchiveGameData, srcItemKey.Id);
		if (isLocked)
		{
			DomainManager.Taiwu.SetItemLocked(context, itemKey, isLocked: true);
		}
		return itemKey;
	}

	internal ItemKey UnpackCrossArchiveItem(DataContext context, CrossArchiveGameData crossArchiveGameData, int srcItemId)
	{
		if (crossArchiveGameData.UnpackedItems == null)
		{
			crossArchiveGameData.UnpackedItems = new Dictionary<int, ItemKey>();
		}
		if (crossArchiveGameData.UnpackedItems.TryGetValue(srcItemId, out var unpackedItemKey))
		{
			return unpackedItemKey;
		}
		if (crossArchiveGameData.ItemGroupPackage == null)
		{
			return ItemKey.Invalid;
		}
		ItemKey itemKey = UnpackItem(context, crossArchiveGameData.ItemGroupPackage, srcItemId);
		if (itemKey.IsValid())
		{
			crossArchiveGameData.UnpackedItems.Add(srcItemId, itemKey);
			if (itemKey.ItemType == 11)
			{
				crossArchiveGameData.CricketCombatPreset.ReplaceCrickets(srcItemId, itemKey.Id);
			}
		}
		return itemKey;
	}

	public void PackItem(ItemGroupPackage package, ItemBase item)
	{
		ItemKey itemKey = item.GetItemKey();
		if (!package.Items.TryAdd(itemKey.Id, item))
		{
			return;
		}
		if (ModificationStateHelper.IsActive(itemKey.ModificationState, 2))
		{
			RefiningEffects refiningEffects = DomainManager.Item.GetRefinedEffects(itemKey);
			ItemGroupPackage itemGroupPackage = package;
			if (itemGroupPackage.RefiningEffects == null)
			{
				itemGroupPackage.RefiningEffects = new Dictionary<int, RefiningEffects>();
			}
			package.RefiningEffects.Add(itemKey.Id, refiningEffects);
		}
		if (ModificationStateHelper.IsActive(itemKey.ModificationState, 1))
		{
			FullPoisonEffects poisonEffects = DomainManager.Item.GetPoisonEffects(itemKey);
			ItemGroupPackage itemGroupPackage = package;
			if (itemGroupPackage.FullPoisonEffects == null)
			{
				itemGroupPackage.FullPoisonEffects = new Dictionary<int, FullPoisonEffects>();
			}
			package.FullPoisonEffects.Add(itemKey.Id, new FullPoisonEffects(poisonEffects));
		}
		if (_mysteryData.TryGetValue(itemKey.Id, out var mysteryData))
		{
			ItemGroupPackage itemGroupPackage = package;
			if (itemGroupPackage.MysteryEffects == null)
			{
				itemGroupPackage.MysteryEffects = new Dictionary<int, MysteryData>();
			}
			package.MysteryEffects.Add(itemKey.Id, new MysteryData
			{
				Compatibility = ((mysteryData.Compatibility == null) ? null : new Dictionary<int, int>(mysteryData.Compatibility))
			});
		}
		switch (itemKey.ItemType)
		{
		case 11:
		{
			bool isSmart = DomainManager.Extra.IsCricketSmart(itemKey.Id);
			bool isIdentified = DomainManager.Extra.IsCricketIdentified(itemKey.Id);
			if (isSmart)
			{
				package.CricketIsSmart.Add(itemKey.Id, value: true);
			}
			if (isIdentified)
			{
				package.CricketIsIdentified.Add(itemKey.Id, value: true);
			}
			break;
		}
		case 4:
		{
			int tamePoint = DomainManager.Extra.GetCarrierTamePoint(itemKey.Id);
			if (tamePoint >= 0)
			{
				package.CarrierTamePoint.Add(itemKey.Id, tamePoint);
			}
			int loongId;
			ChildrenOfLoong loong;
			if (DomainManager.Extra.TryGetJiaoIdByItemKey(itemKey, out var jiaoId2) && DomainManager.Extra.TryGetJiao(jiaoId2, out var jiao2))
			{
				jiao2.PettingCoolDown = -1;
				package.Jiaos.Add(jiaoId2, jiao2);
				package.JiaoKeyToId.Add(itemKey, jiaoId2);
			}
			else if (DomainManager.Extra.TryGetChildrenOfLoongIdByItemKey(itemKey, out loongId) && DomainManager.Extra.TryGetLoong(loongId, out loong))
			{
				package.ChildrenOfLoong.Add(loongId, loong);
				package.ChildrenOfLoongKeyToId.Add(itemKey, loongId);
			}
			break;
		}
		case 5:
		{
			if (DomainManager.Extra.TryGetJiaoIdByItemKey(itemKey, out var jiaoId) && DomainManager.Extra.TryGetJiao(jiaoId, out var jiao))
			{
				jiao.PettingCoolDown = -1;
				package.Jiaos.Add(jiaoId, jiao);
				package.JiaoKeyToId.Add(itemKey, jiaoId);
			}
			break;
		}
		case 3:
		{
			short modifiedTemplateId = DomainManager.Taiwu.GetModifiedClothingTemplateId(itemKey);
			if (modifiedTemplateId != itemKey.TemplateId)
			{
				ItemGroupPackage itemGroupPackage = package;
				if (itemGroupPackage.ClothingDisplayModifications == null)
				{
					itemGroupPackage.ClothingDisplayModifications = new Dictionary<int, short>();
				}
				package.ClothingDisplayModifications.Add(itemKey.Id, modifiedTemplateId);
			}
			break;
		}
		}
	}

	public ItemKey UnpackItem(DataContext context, ItemGroupPackage package, int srcItemId)
	{
		if (package.Items == null || !package.Items.TryGetValue(srcItemId, out var srcItem))
		{
			return ItemKey.Invalid;
		}
		ItemKey srcItemKey = srcItem.GetItemKey();
		if (ItemTemplateHelper.IsPureStackable(srcItemKey))
		{
			ItemKey dstItemKey = srcItemKey;
			dstItemKey.Id = GetStackableItem(context, srcItemKey.ItemType, srcItemKey.TemplateId);
			return dstItemKey;
		}
		int itemId = GenerateNextItemId(context);
		if (ModificationStateHelper.IsActive(srcItemKey.ModificationState, 2))
		{
			RefiningEffects refiningEffect = package.RefiningEffects[srcItemId];
			AddElement_RefinedItems(itemId, refiningEffect, context);
		}
		if (ModificationStateHelper.IsActive(srcItemKey.ModificationState, 1))
		{
			FullPoisonEffects poisonEffect = package.FullPoisonEffects[srcItemId];
			DomainManager.Extra.SetPoisonEffect(context, itemId, new FullPoisonEffects(poisonEffect));
		}
		bool hasMysteryEffect = false;
		Dictionary<int, MysteryData> mysteryEffects = package.MysteryEffects;
		if (mysteryEffects != null && mysteryEffects.TryGetValue(srcItemId, out var mysteryData))
		{
			hasMysteryEffect = true;
			AddElement_MysteryData(itemId, mysteryData, context);
		}
		switch (srcItemKey.ItemType)
		{
		case 0:
		{
			Weapon item11 = GameData.Serializer.Serializer.CreateCopy((Weapon)srcItem);
			item11.OfflineSetId(itemId);
			item11.OfflineSetEquippedCharId(-1);
			AddElement_Weapons(itemId, item11);
			ItemKey itemKey7 = item11.GetItemKey();
			if (hasMysteryEffect)
			{
				AddMysteryListener(itemId);
			}
			return itemKey7;
		}
		case 1:
		{
			Armor item6 = GameData.Serializer.Serializer.CreateCopy((Armor)srcItem);
			item6.OfflineSetId(itemId);
			item6.OfflineSetEquippedCharId(-1);
			AddElement_Armors(itemId, item6);
			ItemKey itemKey4 = item6.GetItemKey();
			if (hasMysteryEffect)
			{
				AddMysteryListener(itemId);
			}
			return itemKey4;
		}
		case 2:
		{
			Accessory item12 = GameData.Serializer.Serializer.CreateCopy((Accessory)srcItem);
			item12.OfflineSetId(itemId);
			item12.OfflineSetEquippedCharId(-1);
			AddElement_Accessories(itemId, item12);
			ItemKey itemKey8 = item12.GetItemKey();
			if (hasMysteryEffect)
			{
				AddMysteryListener(itemId);
			}
			return itemKey8;
		}
		case 3:
		{
			Clothing item10 = GameData.Serializer.Serializer.CreateCopy((Clothing)srcItem);
			item10.OfflineSetId(itemId);
			item10.OfflineSetEquippedCharId(-1);
			AddElement_Clothing(itemId, item10);
			ItemKey itemKey6 = item10.GetItemKey();
			if (hasMysteryEffect)
			{
				AddMysteryListener(itemId);
			}
			if (package.ClothingDisplayModifications != null && package.ClothingDisplayModifications.TryGetValue(srcItemId, out var modifiedTemplateId))
			{
				DomainManager.Taiwu.SetClothingDisplayModification(context, itemKey6, modifiedTemplateId);
			}
			return itemKey6;
		}
		case 4:
		{
			Carrier item13 = GameData.Serializer.Serializer.CreateCopy((Carrier)srcItem);
			item13.OfflineSetId(itemId);
			item13.OfflineSetEquippedCharId(-1);
			AddElement_Carriers(itemId, item13);
			ItemKey itemKey9 = item13.GetItemKey();
			if (hasMysteryEffect)
			{
				AddMysteryListener(itemId);
			}
			if (package.CarrierTamePoint.TryGetValue(srcItemKey.Id, out var tamePoint))
			{
				DomainManager.Extra.SetCarrierTamePoint(context, itemKey9.Id, tamePoint);
			}
			ChildrenOfLoong loong;
			if (package.JiaoKeyToId.TryGetValue(srcItemKey, out var id3) && package.Jiaos.TryGetValue(id3, out var jiao3))
			{
				DomainManager.Extra.SetJiaoItemKey(context, id3, jiao3, itemKey9);
			}
			else if (package.ChildrenOfLoongKeyToId.TryGetValue(srcItemKey, out id3) && package.ChildrenOfLoong.TryGetValue(id3, out loong))
			{
				DomainManager.Extra.SetChildrenOfLoongItemKey(context, id3, loong, itemKey9);
			}
			return itemKey9;
		}
		case 5:
		{
			Material item5 = GameData.Serializer.Serializer.CreateCopy((Material)srcItem);
			item5.OfflineSetId(itemId);
			AddElement_Materials(itemId, item5);
			ItemKey itemKey3 = item5.GetItemKey();
			if (package.JiaoKeyToId.TryGetValue(srcItemKey, out var id2) && package.Jiaos.TryGetValue(id2, out var jiao2))
			{
				DomainManager.Extra.SetJiaoItemKey(context, id2, jiao2, itemKey3);
			}
			return itemKey3;
		}
		case 6:
		{
			CraftTool item7 = GameData.Serializer.Serializer.CreateCopy((CraftTool)srcItem);
			item7.OfflineSetId(itemId);
			AddElement_CraftTools(itemId, item7);
			return item7.GetItemKey();
		}
		case 7:
		{
			Food item4 = GameData.Serializer.Serializer.CreateCopy((Food)srcItem);
			item4.OfflineSetId(itemId);
			AddElement_Foods(itemId, item4);
			return item4.GetItemKey();
		}
		case 8:
		{
			Medicine item3 = GameData.Serializer.Serializer.CreateCopy((Medicine)srcItem);
			item3.OfflineSetId(itemId);
			AddElement_Medicines(itemId, item3);
			return item3.GetItemKey();
		}
		case 9:
		{
			TeaWine item8 = GameData.Serializer.Serializer.CreateCopy((TeaWine)srcItem);
			item8.OfflineSetId(itemId);
			AddElement_TeaWines(itemId, item8);
			return item8.GetItemKey();
		}
		case 10:
		{
			SkillBook item14 = GameData.Serializer.Serializer.CreateCopy((SkillBook)srcItem);
			item14.OfflineSetId(itemId);
			AddElement_SkillBooks(itemId, item14);
			return item14.GetItemKey();
		}
		case 11:
		{
			Cricket item9 = GameData.Serializer.Serializer.CreateCopy((Cricket)srcItem);
			item9.OfflineSetId(itemId);
			AddElement_Crickets(itemId, item9);
			Events.RaiseCricketCreated(context, item9.GetItemKey());
			ItemKey itemKey5 = item9.GetItemKey();
			if (package.CricketIsSmart.ContainsKey(srcItemKey.Id))
			{
				DomainManager.Extra.ForceCricketSmart(context, itemKey5);
			}
			if (package.CricketIsIdentified.ContainsKey(srcItemKey.Id))
			{
				DomainManager.Extra.SetCricketIdentified(context, itemKey5.Id);
			}
			DomainManager.Taiwu.ReplaceCricketPlan(context, srcItemKey, itemKey5);
			return itemKey5;
		}
		case 12:
		{
			if (package.JiaoKeyToId.TryGetValue(srcItemKey, out var id) && package.Jiaos.TryGetValue(id, out var jiao))
			{
				Material item = new Material(context.Random, (jiao.GrowthStage == 0) ? DomainManager.Extra.GetJiaoEggTemplateIdByJiaoTemplateId(jiao.TemplateId) : DomainManager.Extra.GetJiaoTeenagerTemplateIdByJiaoTemplateId(jiao.TemplateId), itemId);
				AddElement_Materials(itemId, item);
				ItemKey itemKey = item.GetItemKey();
				DomainManager.Extra.SetJiaoItemKey(context, id, jiao, itemKey);
				return itemKey;
			}
			Misc item2 = GameData.Serializer.Serializer.CreateCopy((Misc)srcItem);
			item2.OfflineSetId(itemId);
			AddElement_Misc(itemId, item2);
			ItemKey itemKey2 = item2.GetItemKey();
			CheckAndTrackSpecialItem(itemKey2);
			return itemKey2;
		}
		default:
			throw ItemTemplateHelper.CreateItemTypeException(srcItemKey.ItemType);
		}
	}

	public void AddExternEquipmentEffect(DataContext context, ItemKey itemKey, short effectId)
	{
		GameData.Utilities.ShortList effectIds;
		bool exist = _externEquipmentEffects.TryGetValue(itemKey.Id, out effectIds);
		ref List<short> items = ref effectIds.Items;
		if (items == null)
		{
			items = new List<short>();
		}
		effectIds.Items.Add(effectId);
		if (exist)
		{
			SetElement_ExternEquipmentEffects(itemKey.Id, effectIds, context);
		}
		else
		{
			AddElement_ExternEquipmentEffects(itemKey.Id, effectIds, context);
		}
		EquipmentBase equipment = GetBaseEquipment(itemKey);
		equipment.SetEquipmentEffectId(equipment.GetEquipmentEffectId(), context);
	}

	public void RemoveExternEquipmentEffect(DataContext context, ItemKey itemKey, short effectId)
	{
		if (TryGetElement_ExternEquipmentEffects(itemKey.Id, out var effectIds))
		{
			effectIds.Items.Remove(effectId);
			if (effectIds.Items.Count > 0)
			{
				SetElement_ExternEquipmentEffects(itemKey.Id, effectIds, context);
			}
			else
			{
				RemoveElement_ExternEquipmentEffects(itemKey.Id, context);
			}
			EquipmentBase equipment = TryGetBaseEquipment(itemKey);
			equipment?.SetEquipmentEffectId(equipment.GetEquipmentEffectId(), context);
		}
	}

	public IEnumerable<EquipmentEffectItem> GetEquipmentEffects(EquipmentBase equipment)
	{
		if (equipment.GetEquipmentEffectId() >= 0)
		{
			yield return EquipmentEffect.Instance[equipment.GetEquipmentEffectId()];
		}
		if (!TryGetElement_ExternEquipmentEffects(equipment.GetId(), out var effectIds))
		{
			yield break;
		}
		foreach (short effectId in effectIds.Items)
		{
			yield return EquipmentEffect.Instance[effectId];
		}
	}

	[DomainMethod]
	public void ChangeDurability(DataContext dataContext, int charId, short changeValue, sbyte itemType, short startId, short endId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		ItemKey[] equipment = character.GetEquipment();
		ItemKey[] array = equipment;
		for (int i = 0; i < array.Length; i++)
		{
			ItemKey itemKey = array[i];
			if (itemKey.IsValid())
			{
				ItemBase baseItem = DomainManager.Item.GetBaseItem(itemKey);
				if (itemKey.ItemType == itemType && itemKey.TemplateId >= startId && itemKey.TemplateId <= endId)
				{
					baseItem.ChangeCurrDurability(dataContext, changeValue);
				}
			}
		}
		Inventory inventory = character.GetInventory();
		foreach (KeyValuePair<ItemKey, int> item in inventory.Items)
		{
			item.Deconstruct(out var key, out var value);
			ItemKey itemKey2 = key;
			int amount = value;
			ItemBase baseItem2 = DomainManager.Item.GetBaseItem(itemKey2);
			if (itemKey2.ItemType == itemType && itemKey2.TemplateId >= startId && itemKey2.TemplateId <= endId)
			{
				int durability = baseItem2.GetCurrDurability() + changeValue;
				durability = Math.Clamp(durability, 0, baseItem2.GetMaxDurability());
				baseItem2.SetCurrDurability((short)durability, dataContext);
			}
		}
	}

	[DomainMethod]
	public void ChangePoisonIdentified(DataContext dataContext, int charId, bool isIdentified)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		Inventory inventory = character.GetInventory();
		foreach (ItemKey itemsKey in inventory.Items.Keys)
		{
			SetPoisonsIdentified(dataContext, itemsKey, isIdentified);
		}
	}

	[DomainMethod]
	public void GmCmd_StartCricketCombat(DataContext context, int enemyId)
	{
		ResetCricketWagerData(enemyId);
		Wager selfWager = Wager.CreateExp(0);
		List<CricketWagerData> list = SelectCricketWagers(context);
		CricketWagerData enemyWagerData = list[list.Count - 1];
		SetWager(selfWager, enemyWagerData.Wager);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenCricketBattle, enemyId, selfWager, enemyWagerData);
	}

	[DomainMethod]
	public void GmCmd_ChangeAllMysteryCompatibility(DataContext context, int deltaValue)
	{
		Dictionary<int, MysteryData> mysteryData = _mysteryData;
		if (mysteryData == null || mysteryData.Count <= 0)
		{
			return;
		}
		int charId = DomainManager.Taiwu.GetTaiwuCharId();
		List<int> target = new List<int>(_mysteryData.Keys);
		foreach (int itemId in target)
		{
			EquipmentBase equipment = GetEquipmentById(itemId);
			ChangeMysteryCompatibility(context, equipment.GetItemKey(), charId, deltaValue);
		}
	}

	[DomainMethod]
	public void GmCmd_ChangeAllCricketSpirit(DataContext context, int addValue)
	{
		Inventory inventory = DomainManager.Taiwu.GetTaiwu().GetInventory();
		foreach (ItemKey key in inventory.Items.Keys)
		{
			if (key.ItemType == 11 && TryGetElement_Crickets(key.Id, out var cricket))
			{
				cricket.AddSpirit(context, addValue);
			}
		}
	}

	private void InitializeMysteryListeners()
	{
		foreach (int itemId in _mysteryData.Keys)
		{
			AddMysteryListener(itemId);
		}
	}

	private void AddMysteryListener(int itemId)
	{
		EquipmentBase equipment = GetEquipmentById(itemId);
		sbyte itemType = equipment.GetItemType();
		ushort dataId = EquipmentItemTypeToDataIds[itemType];
		ushort fieldId = EquipmentItemTypeToEquippedPowerFieldIds[itemType];
		DataUid uid = new DataUid(6, dataId, (ulong)itemId, fieldId);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(uid, "OnMysteryEquippedPowerChanged", OnMysteryEquippedPowerChanged);
	}

	private void RemoveMysteryListener(int itemId)
	{
		EquipmentBase equipment = GetEquipmentById(itemId);
		sbyte itemType = equipment.GetItemType();
		ushort dataId = EquipmentItemTypeToDataIds[itemType];
		ushort fieldId = EquipmentItemTypeToEquippedPowerFieldIds[itemType];
		DataUid uid = new DataUid(6, dataId, (ulong)itemId, fieldId);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(uid, "OnMysteryEquippedPowerChanged");
	}

	private void OnMysteryEquippedPowerChanged(DataContext context, DataUid uid)
	{
		int itemId = (int)uid.SubId0;
		UpdateMysteryEffect(context, itemId);
	}

	public void UpdateMysteryEffect(DataContext context, int itemId)
	{
		EquipmentBase equipment = GetEquipmentById(itemId);
		MysteryEffectItem mysteryEffect = equipment?.GetItemKey().GetConfig().MysteryEffect;
		if (mysteryEffect == null)
		{
			return;
		}
		int charId = equipment.GetEquippedCharId();
		short power = equipment.GetEquippedPower();
		MysteryData mysteryData = _mysteryData[itemId];
		bool anyChanged = false;
		for (int i = 0; i < mysteryEffect.BonusEffects.Count; i++)
		{
			int requirePower = mysteryEffect.PowerRequirements[i + mysteryEffect.BonusValues.Count];
			bool shouldEnable = power >= requirePower;
			long enabledEffectId = mysteryData.EffectIds?.GetOrDefault(i, -1L) ?? (-1);
			bool enabled = enabledEffectId >= 0;
			if (shouldEnable && enabled)
			{
				SpecialEffectBase effect = DomainManager.SpecialEffect.Get(enabledEffectId);
				if (effect.CharacterId == charId)
				{
					continue;
				}
				DomainManager.SpecialEffect.Remove(context, enabledEffectId);
			}
			if (shouldEnable)
			{
				short effectTemplateId = mysteryEffect.BonusEffects[i];
				long effectId = DomainManager.SpecialEffect.AddEquipmentEffect(context, charId, itemId, effectTemplateId);
				MysteryData mysteryData2 = mysteryData;
				if (mysteryData2.EffectIds == null)
				{
					mysteryData2.EffectIds = new List<long>();
				}
				mysteryData.EffectIds.SetOrAdd(i, effectId, -1L);
				anyChanged = true;
			}
			else if (enabled)
			{
				DomainManager.SpecialEffect.Remove(context, enabledEffectId);
				mysteryData.EffectIds[i] = -1L;
				anyChanged = true;
			}
		}
		if (anyChanged)
		{
			SetElement_MysteryData(itemId, mysteryData, context);
		}
	}

	public EquipmentBase GetEquipmentById(int itemId)
	{
		if (_weapons.TryGetValue(itemId, out var weapon))
		{
			return weapon;
		}
		if (_armors.TryGetValue(itemId, out var armor))
		{
			return armor;
		}
		if (_accessories.TryGetValue(itemId, out var accessory))
		{
			return accessory;
		}
		if (_clothing.TryGetValue(itemId, out var clothing))
		{
			return clothing;
		}
		return _carriers.GetOrDefault(itemId);
	}

	public void ChangeMysteryCompatibility(DataContext context, ItemKey itemKey, int charId, int delta)
	{
		if (!_mysteryData.TryGetValue(itemKey.Id, out var mysteryData) || delta == 0)
		{
			return;
		}
		EquipmentBase equipment = TryGetBaseEquipment(itemKey);
		if (equipment != null)
		{
			MysteryData mysteryData2 = mysteryData;
			if (mysteryData2.Compatibility == null)
			{
				mysteryData2.Compatibility = new Dictionary<int, int>();
			}
			int newCompatibility = mysteryData.Compatibility.GetOrDefault(charId) + delta;
			newCompatibility = Math.Min(newCompatibility, 999999999);
			mysteryData.Compatibility[charId] = newCompatibility;
			SetElement_MysteryData(itemKey.Id, mysteryData, context);
			equipment.SetEquipmentEffectId(equipment.GetEquipmentEffectId(), context);
		}
	}

	public CValueModify CalcMysteryBonus(ItemKey itemKey, ECharacterPropertyReferencedType propertyType)
	{
		CValueModify result = CValueModify.Zero;
		if (!itemKey.IsValid())
		{
			return result;
		}
		MysteryEffectItem mysteryEffect = itemKey.GetConfig().MysteryEffect;
		if (mysteryEffect == null)
		{
			return result;
		}
		EquipmentBase equipment = TryGetBaseEquipment(itemKey);
		if (equipment == null)
		{
			return result;
		}
		for (int i = 0; i < mysteryEffect.BonusValues.Count; i++)
		{
			CValueModify bonusValue = CValueModify.Zero;
			foreach (PropertyAndValueAndModifyType value in mysteryEffect.BonusValues[i])
			{
				if (value.Type == propertyType)
				{
					bonusValue += (CValueModifyDelta)value;
				}
			}
			if (!bonusValue.IsZero)
			{
				int requirePower = mysteryEffect.PowerRequirements[i];
				if (requirePower > equipment.GetEquippedPower())
				{
					break;
				}
				result += bonusValue;
			}
		}
		return result;
	}

	public static void RegisterItemOwners(DataContext context, DataUid uid)
	{
		DomainManager.Item.InitializeOwnedItems();
		DomainManager.Organization.InitializeOwnedItems();
		DomainManager.Character.InitializeOwnedItems();
		DomainManager.Taiwu.InitializeOwnedItems();
		DomainManager.Map.InitializeOwnedItems();
		DomainManager.Merchant.InitializeOwnedItems();
		DomainManager.Building.InitializeOwnedItems();
		DomainManager.LegendaryBook.InitializeOwnedItems();
		DomainManager.Extra.InitializeOwnedItems();
		DomainManager.Item.CheckUnownedItems();
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(uid, "RegisterItemOwners");
	}

	private void InitializeOwnedItems()
	{
		SetOwner(_emptyHandKey, ItemOwnerType.System, 6);
		SetOwner(_branchKey, ItemOwnerType.System, 6);
		SetOwner(_stoneKey, ItemOwnerType.System, 6);
	}

	public void CheckUnownedItems()
	{
		Span<int> unownedCount = stackalloc int[13];
		int key;
		foreach (KeyValuePair<int, Weapon> weapon in _weapons)
		{
			weapon.Deconstruct(out key, out var value);
			Weapon item = value;
			if (!IsPureStackable(item) && item.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[0]++;
				LogUnownedItem(item);
			}
		}
		foreach (KeyValuePair<int, Armor> armor in _armors)
		{
			armor.Deconstruct(out key, out var value2);
			Armor item2 = value2;
			if (!IsPureStackable(item2) && item2.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[1]++;
				LogUnownedItem(item2);
			}
		}
		foreach (KeyValuePair<int, Accessory> accessory in _accessories)
		{
			accessory.Deconstruct(out key, out var value3);
			Accessory item3 = value3;
			if (!IsPureStackable(item3) && item3.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[2]++;
				LogUnownedItem(item3);
			}
		}
		foreach (KeyValuePair<int, Clothing> item14 in _clothing)
		{
			item14.Deconstruct(out key, out var value4);
			Clothing item4 = value4;
			if (!IsPureStackable(item4) && item4.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[3]++;
				LogUnownedItem(item4);
			}
		}
		foreach (KeyValuePair<int, Carrier> carrier in _carriers)
		{
			carrier.Deconstruct(out key, out var value5);
			Carrier item5 = value5;
			if (!IsPureStackable(item5) && item5.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[4]++;
				LogUnownedItem(item5);
			}
		}
		foreach (KeyValuePair<int, Material> material in _materials)
		{
			material.Deconstruct(out key, out var value6);
			Material item6 = value6;
			if (!IsPureStackable(item6) && item6.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[5]++;
				LogUnownedItem(item6);
			}
		}
		foreach (KeyValuePair<int, CraftTool> craftTool in _craftTools)
		{
			craftTool.Deconstruct(out key, out var value7);
			CraftTool item7 = value7;
			if (!IsPureStackable(item7) && item7.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[6]++;
				LogUnownedItem(item7);
			}
		}
		foreach (KeyValuePair<int, Food> food in _foods)
		{
			food.Deconstruct(out key, out var value8);
			Food item8 = value8;
			if (!IsPureStackable(item8) && item8.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[7]++;
				LogUnownedItem(item8);
			}
		}
		foreach (KeyValuePair<int, Medicine> medicine in _medicines)
		{
			medicine.Deconstruct(out key, out var value9);
			Medicine item9 = value9;
			if (!IsPureStackable(item9) && item9.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[8]++;
				LogUnownedItem(item9);
			}
		}
		foreach (KeyValuePair<int, TeaWine> teaWine in _teaWines)
		{
			teaWine.Deconstruct(out key, out var value10);
			TeaWine item10 = value10;
			if (!IsPureStackable(item10) && item10.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[9]++;
				LogUnownedItem(item10);
			}
		}
		foreach (KeyValuePair<int, SkillBook> skillBook in _skillBooks)
		{
			skillBook.Deconstruct(out key, out var value11);
			SkillBook item11 = value11;
			if (!IsPureStackable(item11) && item11.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[10]++;
				LogUnownedItem(item11);
			}
		}
		foreach (KeyValuePair<int, Cricket> cricket in _crickets)
		{
			cricket.Deconstruct(out key, out var value12);
			Cricket item12 = value12;
			if (!IsPureStackable(item12) && item12.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[11]++;
				LogUnownedItem(item12);
			}
		}
		foreach (KeyValuePair<int, Misc> item15 in _misc)
		{
			item15.Deconstruct(out key, out var value13);
			Misc item13 = value13;
			if (!IsPureStackable(item13) && item13.Owner.OwnerType == ItemOwnerType.None)
			{
				unownedCount[12]++;
				LogUnownedItem(item13);
			}
		}
		int totalCount = 0;
		for (sbyte itemType = 0; itemType < 13; itemType++)
		{
			if (unownedCount[itemType] > 0)
			{
				totalCount += unownedCount[itemType];
				Logger.Warn($"{unownedCount[itemType]} unowned {ItemType.TypeId2TypeName[itemType]} detected.");
			}
		}
		Logger.Info($"Total unowned items: {totalCount}");
	}

	private void LogUnownedItem(ItemBase itemBase)
	{
		if (itemBase.PrevOwner.OwnerType != ItemOwnerType.None)
		{
			Logger.Warn($"Item {itemBase.GetItemKey()} is no longer owned buy any container. Prev owner: {itemBase.PrevOwner}");
		}
	}

	public void SetOwner(ItemKey itemKey, ItemOwnerType ownerType, int ownerId)
	{
		if (itemKey.IsValid() && ItemExists(itemKey))
		{
			ItemBase baseItem = GetBaseItem(itemKey);
			baseItem.SetOwner(ownerType, ownerId);
		}
	}

	public void RemoveOwner(ItemKey itemKey, ItemOwnerType ownerType, int ownerId)
	{
		ItemBase baseItem = GetBaseItem(itemKey);
		baseItem.RemoveOwner(ownerType, ownerId);
	}

	[Obsolete("Instead by FullPoisonEffects. Now only for archive data fix. Do not delete this code.")]
	public bool HasOldPoisonEffects(ItemKey itemKey)
	{
		return _poisonItems.ContainsKey(itemKey.Id);
	}

	[Obsolete("Instead by FullPoisonEffects. Now only for archive data fix. Do not delete this code.")]
	public PoisonEffects GetOldPoisonEffects(ItemKey itemKey)
	{
		return _poisonItems[itemKey.Id];
	}

	public PoisonsAndLevels GetAttachedPoisons(ItemKey itemKey)
	{
		if (DomainManager.Extra.TryGetPoisonEffect(itemKey.Id, out var poisonEffects))
		{
			return poisonEffects.GetAllPoisonsAndLevels();
		}
		PoisonsAndLevels poisonsAndLevels = default(PoisonsAndLevels);
		poisonsAndLevels.Initialize();
		return poisonsAndLevels;
	}

	public void SetPoisonsIdentified(DataContext context, ItemKey itemKey, bool isIdentified)
	{
		if (DomainManager.Extra.TryGetPoisonEffect(itemKey.Id, out var poisonEffects))
		{
			poisonEffects.IsIdentified = isIdentified;
			DomainManager.Extra.SetPoisonEffect(context, itemKey.Id, poisonEffects);
		}
	}

	public FullPoisonEffects GetPoisonEffects(ItemKey itemKey)
	{
		PoisonEffects.TryGetValue(itemKey.Id, out var poisonEffect);
		if (poisonEffect == null)
		{
			return new FullPoisonEffects();
		}
		return poisonEffect;
	}

	public (ItemBase item, bool keyChanged) SetAttachedPoisons(DataContext context, ItemBase item, short medicineTemplateId, bool add, IReadOnlyList<short> condensedMedicineTemplateIdList = null)
	{
		ItemBase resultItem = item;
		bool keyChanged = false;
		int itemId = item.GetId();
		ItemKey itemKey = item.GetItemKey();
		byte state = item.GetModificationState();
		if (ModificationStateHelper.IsActive(state, 1))
		{
			FullPoisonEffects poisonEffects = PoisonEffects[itemId];
			if (!add)
			{
				poisonEffects.RemovePoison(medicineTemplateId);
			}
			else
			{
				poisonEffects.AddPoison(medicineTemplateId, condensedMedicineTemplateIdList);
			}
			if (poisonEffects.IsValid)
			{
				DomainManager.Extra.SetPoisonEffect(context, itemId, poisonEffects);
			}
			else
			{
				DomainManager.Extra.RemovePoisonEffect(context, itemId);
				byte currState = ModificationStateHelper.Deactivate(state, 1);
				item.SetModificationState(currState, context);
				if (ItemTemplateHelper.IsStackable(itemKey.ItemType, itemKey.TemplateId))
				{
					ItemKey newItemKey = DomainManager.Item.CreateItem(context, itemKey.ItemType, itemKey.TemplateId);
					resultItem = DomainManager.Item.GetBaseItem(newItemKey);
				}
				keyChanged = true;
			}
		}
		else
		{
			FullPoisonEffects poisonEffects2 = new FullPoisonEffects();
			poisonEffects2.AddPoison(medicineTemplateId, condensedMedicineTemplateIdList);
			int id;
			if (!IsPureStackable(item))
			{
				byte currState2 = ModificationStateHelper.Activate(state, 1);
				item.SetModificationState(currState2, context);
				id = item.GetId();
			}
			else
			{
				ItemBase newItem = CreateUniqueStackableItem(context, item.GetItemType(), item.GetTemplateId());
				byte newState = newItem.GetModificationState();
				newState = ModificationStateHelper.Activate(newState, 1);
				newItem.SetModificationState(newState, context);
				resultItem = newItem;
				id = newItem.GetId();
			}
			keyChanged = true;
			DomainManager.Extra.SetPoisonEffect(context, id, poisonEffects2);
		}
		return (item: resultItem, keyChanged: keyChanged);
	}

	public ItemBase SetAttachedPoisons(DataContext context, ItemBase item, FullPoisonEffects poisonEffects)
	{
		if (poisonEffects == null || item == null)
		{
			return item;
		}
		if (DomainManager.Extra.TryGetPoisonEffect(item.GetId(), out var _))
		{
			DomainManager.Extra.RemovePoisonEffect(context, item.GetId());
		}
		if (!poisonEffects.IsValid)
		{
			return item;
		}
		ItemBase result = item;
		foreach (PoisonSlot poisonSlot in poisonEffects.PoisonSlotList)
		{
			result = SetAttachedPoisons(context, result, poisonSlot.MedicineTemplateId, add: true, poisonSlot.CondensedMedicineTemplateIdList).item;
		}
		SetPoisonsIdentified(context, result.GetItemKey(), poisonEffects.IsIdentified);
		return result;
	}

	[DomainMethod]
	public List<ItemDisplayData> IdentifyPoisons(DataContext context, int charId, ItemDisplayData itemDisplayData)
	{
		Inventory itemList = itemDisplayData.GetAllInventoryFromPool();
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		List<ItemDisplayData> identifiedList = new List<ItemDisplayData>();
		foreach (var (key, count) in itemList.Items)
		{
			if (PoisonEffects.TryGetValue(key.Id, out var poisonEffects))
			{
				if (poisonEffects.IsIdentified)
				{
					continue;
				}
				List<short> idArray = poisonEffects.GetAllMedicineTemplateIds();
				int grade = idArray.Max((short id) => (id > -1) ? ItemTemplateHelper.GetGrade(8, id) : (-1));
				if (grade > -1)
				{
					short attainment = GlobalConfig.Instance.PoisonAttainments[grade];
					short charAttainment = character.GetLifeSkillAttainment(9);
					if (charAttainment >= attainment)
					{
						IdentifySuccess(key);
					}
				}
				else
				{
					IdentifySuccess(key);
				}
			}
			else
			{
				IdentifySuccess(key);
			}
		}
		ItemDisplayData.ReturnInventoryToPool(itemList);
		DomainManager.World.AdvanceDaysInMonth(context, 1);
		bool isOnCityTown = character.IsOnCityTown();
		Inventory inventory = character.GetInventory();
		bool isTaiwu = character.GetId() == DomainManager.Taiwu.GetTaiwuCharId();
		List<ItemSourceType> itemSourceTypeList = new List<ItemSourceType>();
		switch ((ItemSourceType)itemDisplayData.ItemSourceType)
		{
		case ItemSourceType.Equipment:
		case ItemSourceType.Inventory:
		case ItemSourceType.EquipmentPlan:
			itemSourceTypeList.Add(ItemSourceType.Inventory);
			if (isOnCityTown && isTaiwu)
			{
				itemSourceTypeList.Add(ItemSourceType.Warehouse);
				itemSourceTypeList.Add(ItemSourceType.Treasury);
			}
			break;
		case ItemSourceType.Warehouse:
			if (isTaiwu)
			{
				itemSourceTypeList.Add(ItemSourceType.Warehouse);
				if (isOnCityTown)
				{
					itemSourceTypeList.Add(ItemSourceType.Inventory);
				}
				itemSourceTypeList.Add(ItemSourceType.Treasury);
			}
			break;
		case ItemSourceType.Treasury:
			if (isTaiwu)
			{
				itemSourceTypeList.Add(ItemSourceType.Treasury);
				if (isOnCityTown)
				{
					itemSourceTypeList.Add(ItemSourceType.Inventory);
				}
				itemSourceTypeList.Add(ItemSourceType.Warehouse);
			}
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		if (!CheckItemInSourceList(itemSourceTypeList))
		{
			throw new Exception("IdentifyPoisons dot not have enough TestingNeedle");
		}
		if (itemDisplayData.HasAnyPoison && identifiedList.Count == 1)
		{
			identifiedList.RemoveAll((ItemDisplayData d) => !d.HasAnyPoison);
		}
		return identifiedList;
		static bool CheckItem(IReadOnlyDictionary<ItemKey, int> items, out ItemKey testingNeedleKey)
		{
			testingNeedleKey = items.FirstOrDefault((KeyValuePair<ItemKey, int> p) => p.Key.ItemType == 12 && p.Key.TemplateId == 264).Key;
			if (!testingNeedleKey.IsValid() || !items.TryGetValue(testingNeedleKey, out var amount) || amount <= 0)
			{
				return false;
			}
			return true;
		}
		bool CheckItemBySource(ItemSourceType itemSourceType)
		{
			ItemKey testingNeedleKey;
			switch (itemSourceType)
			{
			case ItemSourceType.Inventory:
				if (CheckItem(inventory.Items, out testingNeedleKey))
				{
					character.RemoveInventoryItem(context, testingNeedleKey, 1, deleteItem: true);
					return true;
				}
				return false;
			case ItemSourceType.Warehouse:
				if (CheckItem(DomainManager.Taiwu.WarehouseItems, out testingNeedleKey))
				{
					DomainManager.Taiwu.RemoveItem(context, testingNeedleKey, 1, 2, deleteItem: true);
					return true;
				}
				return false;
			case ItemSourceType.Treasury:
				if (CheckItem(DomainManager.Taiwu.GetItems(ItemSourceType.Treasury), out testingNeedleKey))
				{
					DomainManager.Taiwu.RemoveItem(context, testingNeedleKey, 1, 3, deleteItem: true);
					return true;
				}
				return false;
			default:
				throw new ArgumentOutOfRangeException("itemSourceType", itemSourceType, null);
			}
		}
		bool CheckItemInSourceList(List<ItemSourceType> list)
		{
			foreach (ItemSourceType itemSourceType in list)
			{
				if (CheckItemBySource(itemSourceType))
				{
					return true;
				}
			}
			return false;
		}
		void IdentifySuccess(ItemKey itemKey2)
		{
			SetPoisonsIdentified(context, itemKey2, isIdentified: true);
			ItemBase itemBase = DomainManager.Item.GetBaseItem(itemKey2);
			ItemDisplayData newItemData = DomainManager.Item.GetItemDisplayData(itemBase, 1, charId, itemDisplayData.ItemSourceType);
			ItemDisplayData oldItemData = identifiedList.Find((ItemDisplayData d) => d.PoisonEquals(newItemData));
			if (oldItemData == null)
			{
				identifiedList.Add(newItemData);
			}
			else
			{
				oldItemData.Amount++;
			}
		}
	}

	internal ItemKey RemoveOldPoisonEffect(DataContext dataContext, ItemKey itemKey)
	{
		ItemBase baseItem = GetBaseItem(itemKey);
		ItemKey newItemKey;
		if (ItemTemplateHelper.IsStackable(itemKey.ItemType, itemKey.TemplateId))
		{
			RemoveItem(dataContext, itemKey);
			newItemKey = CreateItem(dataContext, itemKey.ItemType, itemKey.TemplateId);
		}
		else
		{
			if (DomainManager.Item.HasOldPoisonEffects(itemKey))
			{
				RemoveElement_PoisonItems(itemKey.Id, dataContext);
			}
			byte state = baseItem.GetModificationState();
			state = ModificationStateHelper.Deactivate(state, 1);
			baseItem.SetModificationState(state, dataContext);
			newItemKey = baseItem.GetItemKey();
		}
		Logger.Warn($"Fixing wrong poison effects of item {itemKey}");
		return newItemKey;
	}

	internal ItemKey RemovePoisonEffect(DataContext dataContext, ItemKey itemKey)
	{
		ItemBase baseItem = GetBaseItem(itemKey);
		ItemKey newItemKey;
		if (ItemTemplateHelper.IsStackable(itemKey.ItemType, itemKey.TemplateId))
		{
			RemoveItem(dataContext, itemKey);
			newItemKey = CreateItem(dataContext, itemKey.ItemType, itemKey.TemplateId);
		}
		else
		{
			if (DomainManager.Extra.TryGetPoisonEffect(itemKey.Id, out var _))
			{
				DomainManager.Extra.RemovePoisonEffect(dataContext, itemKey.Id);
			}
			byte state = baseItem.GetModificationState();
			state = ModificationStateHelper.Deactivate(state, 1);
			baseItem.SetModificationState(state, dataContext);
			newItemKey = baseItem.GetItemKey();
		}
		Logger.Warn($"Fixing wrong poison effects of item {itemKey}");
		return newItemKey;
	}

	public RefiningEffects GetRefinedEffects(ItemKey itemKey)
	{
		return _refinedItems[itemKey.Id];
	}

	public (ItemBase item, bool keyChanged) SetRefinedEffects(DataContext context, ItemBase item, int index, short materialTemplateId)
	{
		ItemBase resultItem = item;
		bool keyChanged = false;
		int itemId = item.GetId();
		byte state = item.GetModificationState();
		if (ModificationStateHelper.IsActive(state, 2))
		{
			RefiningEffects refineEffect = _refinedItems[itemId];
			refineEffect.Set(index, materialTemplateId);
			if (refineEffect.IsRefined)
			{
				SetElement_RefinedItems(itemId, refineEffect, context);
				item.SetModificationState(state, context);
			}
			else
			{
				RemoveElement_RefinedItems(itemId, context);
				byte currState = ModificationStateHelper.Deactivate(state, 2);
				item.SetModificationState(currState, context);
				keyChanged = true;
			}
		}
		else
		{
			RefiningEffects refiningEffects = default(RefiningEffects);
			refiningEffects.Initialize();
			refiningEffects.Set(index, materialTemplateId);
			if (!IsPureStackable(item))
			{
				byte currState2 = ModificationStateHelper.Activate(state, 2);
				item.SetModificationState(currState2, context);
				AddElement_RefinedItems(item.GetId(), refiningEffects, context);
				keyChanged = true;
			}
			else
			{
				ItemBase newItem = CreateUniqueStackableItem(context, item.GetItemType(), item.GetTemplateId());
				byte newState = newItem.GetModificationState();
				newState = ModificationStateHelper.Activate(newState, 2);
				newItem.SetModificationState(newState, context);
				AddElement_RefinedItems(newItem.GetId(), refiningEffects, context);
				keyChanged = true;
				resultItem = newItem;
			}
		}
		return (item: resultItem, keyChanged: keyChanged);
	}

	public ItemBase SetRefinedEffects(DataContext context, ItemBase item, RefiningEffects refiningEffects)
	{
		if (!refiningEffects.IsRefined)
		{
			return item;
		}
		ItemBase result = item;
		short[] templateIds = refiningEffects.GetAllMaterialTemplateIds();
		for (int index = 0; index < templateIds.Length; index++)
		{
			short id = templateIds[index];
			result = SetRefinedEffects(context, result, index, id).item;
		}
		return result;
	}

	public bool RemoveRefinedEffectsAndReturnMaterial(DataContext context, ItemKey baseKey, Inventory inventory, out ItemBase resultItem)
	{
		resultItem = null;
		if (!ModificationStateHelper.IsActive(baseKey.ModificationState, 2))
		{
			return false;
		}
		if (baseKey.ItemType != 2)
		{
			return false;
		}
		AccessoryItem config = Config.Accessory.Instance[baseKey.TemplateId];
		if (config.GroupId != 282)
		{
			return false;
		}
		ItemBase item = GetBaseItem(baseKey);
		RefiningEffects refinedEffects = DomainManager.Item.GetRefinedEffects(baseKey);
		for (int i = 0; i < 5; i++)
		{
			short material = refinedEffects.GetMaterialTemplateIdAt(i);
			if (material >= 0)
			{
				ItemKey materialItem = CreateMaterial(context, material);
				if (inventory == null)
				{
					DomainManager.Taiwu.AddItem(context, materialItem, 1, ItemSourceType.Warehouse);
				}
				else
				{
					inventory.OfflineAdd(materialItem, 1);
				}
				(ItemBase item, bool keyChanged) tuple = DomainManager.Item.SetRefinedEffects(context, item, i, -1);
				var (newItem, _) = tuple;
				if (tuple.keyChanged)
				{
					resultItem = newItem;
				}
			}
		}
		return resultItem != null;
	}

	[DomainMethod]
	public List<SkillBookModifyDisplayData> GetTaiwuInventoryCombatSkillBooks()
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Inventory inventory = taiwu.GetInventory();
		List<SkillBookModifyDisplayData> skillBookDisplayData = new List<SkillBookModifyDisplayData>();
		foreach (ItemKey key in inventory.Items.Keys)
		{
			if (key.IsValid() && key.ItemType == 10)
			{
				SkillBookItem config = Config.SkillBook.Instance[key.TemplateId];
				if (config.ItemSubType == 1001 && _skillBooks.TryGetValue(key.Id, out var skillBook))
				{
					short gainExp = SkillGradeData.Instance[skillBook.GetGrade()].ReadingExpGainPerPage;
					int normalPageCost = gainExp * 20;
					int outlinePageCost = gainExp * 60;
					SkillBookModifyDisplayData data = new SkillBookModifyDisplayData
					{
						ItemDisplayData = GetItemDisplayData(key),
						PageTypes = skillBook.GetPageTypes(),
						PageIncompleteState = skillBook.GetPageIncompleteState(),
						NormalPageCostExp = normalPageCost,
						OutlinePageCostExp = outlinePageCost
					};
					skillBookDisplayData.Add(data);
				}
			}
		}
		return skillBookDisplayData;
	}

	[DomainMethod]
	[Obsolete("Use SetCombatSkillBookPage instead")]
	public bool ModifyCombatSkillBookPageOutline(DataContext context, ItemKey itemKey, sbyte behaviorType)
	{
		if (DomainManager.World.GetLeftDaysInCurrMonth() < 10)
		{
			return false;
		}
		if (!_skillBooks.TryGetValue(itemKey.Id, out var skillBook))
		{
			return false;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int expCost = SkillGradeData.Instance[skillBook.GetGrade()].ReadingExpGainPerPage * 60;
		if (taiwu.GetExp() < expCost)
		{
			return false;
		}
		DomainManager.World.AdvanceDaysInMonth(context, 10);
		taiwu.ChangeExp(context, -expCost);
		skillBook.SetOutlinePageType(context, behaviorType);
		return true;
	}

	[DomainMethod]
	[Obsolete("Use SetCombatSkillBookPage instead")]
	public bool ModifyCombatSkillBookPageNormal(DataContext context, ItemKey itemKey, List<byte> pageIds, List<sbyte> directions)
	{
		if (DomainManager.World.GetLeftDaysInCurrMonth() < 10)
		{
			return false;
		}
		if (pageIds == null || pageIds.Count <= 0 || directions == null || directions.Count <= 0 || pageIds.Count != directions.Count)
		{
			return false;
		}
		if (!_skillBooks.TryGetValue(itemKey.Id, out var skillBook))
		{
			return false;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int expCost = SkillGradeData.Instance[skillBook.GetGrade()].ReadingExpGainPerPage * 20 * pageIds.Count;
		if (taiwu.GetExp() < expCost)
		{
			return false;
		}
		DomainManager.World.AdvanceDaysInMonth(context, 10);
		taiwu.ChangeExp(context, -expCost);
		for (int i = 0; i < pageIds.Count; i++)
		{
			skillBook.SetNormalPageType(context, pageIds[i], directions[i]);
		}
		return true;
	}

	[DomainMethod]
	public bool SetCombatSkillBookPage(DataContext context, ItemKey itemKey, sbyte behaviorType, List<sbyte> directions)
	{
		if (DomainManager.World.GetLeftDaysInCurrMonth() < 10)
		{
			return false;
		}
		if (!_skillBooks.TryGetValue(itemKey.Id, out var skillBook))
		{
			return false;
		}
		if (directions == null || directions.Count != 5)
		{
			return false;
		}
		byte pageTypes = skillBook.GetPageTypes();
		sbyte oldOutlineType = SkillBookStateHelper.GetOutlinePageType(pageTypes);
		bool needChangeOutline = oldOutlineType != behaviorType;
		int outlineCost = (needChangeOutline ? (SkillGradeData.Instance[skillBook.GetGrade()].ReadingExpGainPerPage * 60) : 0);
		int normalCost = 0;
		Span<bool> needModifyList = stackalloc bool[5];
		for (int i = 0; i < 5; i++)
		{
			sbyte oldNormalType = SkillBookStateHelper.GetNormalPageType(pageTypes, (byte)(i + 1));
			needModifyList[i] = oldNormalType != directions[i];
			normalCost += (needModifyList[i] ? (SkillGradeData.Instance[skillBook.GetGrade()].ReadingExpGainPerPage * 20) : 0);
		}
		int totalCost = outlineCost + normalCost;
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		if (taiwu.GetExp() < totalCost)
		{
			return false;
		}
		DomainManager.World.AdvanceDaysInMonth(context, 10);
		taiwu.ChangeExp(context, -totalCost);
		if (needChangeOutline)
		{
			skillBook.SetOutlinePageType(context, behaviorType);
		}
		for (int j = 0; j < 5; j++)
		{
			if (needModifyList[j])
			{
				skillBook.SetNormalPageType(context, (byte)(j + 1), directions[j]);
			}
		}
		DomainManager.World.ApplyChallengeModeAutoReadBook(context, itemKey);
		return true;
	}

	public int GetPageIncompleteState(ushort pageIncompleteState, byte pageId, ItemKey[] referenceBooks, ItemKey curReadingBook)
	{
		sbyte incompleteState = SkillBookStateHelper.GetPageIncompleteState(pageIncompleteState, pageId);
		if (incompleteState == 0 || !curReadingBook.IsValid())
		{
			return incompleteState;
		}
		SkillBook book = GetElement_SkillBooks(curReadingBook.Id);
		for (int i = 0; i < referenceBooks.Length; i++)
		{
			ItemKey refBookKey = referenceBooks[i];
			if (!refBookKey.IsValid() || refBookKey.TemplateId != book.GetTemplateId())
			{
				continue;
			}
			SkillBook refBook = GetElement_SkillBooks(refBookKey.Id);
			bool needSupply = true;
			if (book.GetCombatSkillTemplateId() > -1)
			{
				byte pageTypes = book.GetPageTypes();
				byte refPageTypes = refBook.GetPageTypes();
				sbyte pageType = SkillBookStateHelper.GetNormalPageType(pageTypes, pageId);
				sbyte refPageType = SkillBookStateHelper.GetNormalPageType(refPageTypes, pageId);
				if (pageType != refPageType)
				{
					needSupply = false;
				}
			}
			if (needSupply)
			{
				sbyte refBookPageState = SkillBookStateHelper.GetPageIncompleteState(refBook.GetPageIncompleteState(), pageId);
				if (refBookPageState >= 0 && refBookPageState < incompleteState)
				{
					incompleteState = refBookPageState;
				}
			}
		}
		return incompleteState;
	}

	public bool HasNewDeadCricket()
	{
		return _newDeadCrickets.Count > 0;
	}

	public bool IsNewDeadCricket(ItemKey itemKey)
	{
		return _newDeadCrickets.Contains(itemKey);
	}

	public void UpdateCrickets(DataContext context)
	{
		_newDeadCrickets.Clear();
		if (DomainManager.World.GetCurrMonthInYear() != GlobalConfig.Instance.CricketActiveStartMonth + 1)
		{
			return;
		}
		List<CricketCollectionData> cricketCollectionData = DomainManager.Extra.GetCricketCollectionDataList();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		CValuePercent cricketRoomAgePercent = DomainManager.Taiwu.CalcCricketRoomReduceAgeEffect();
		foreach (Cricket cricket in _crickets.Values)
		{
			if (DomainManager.Taiwu.IsAliveCricketPolymorph(cricket.GetId()))
			{
				continue;
			}
			ItemKey cricketKey = cricket.GetItemKey();
			bool inCricketRoom = cricketCollectionData.Select((CricketCollectionData item) => item.Cricket).Contains(cricketKey);
			if (cricket.UpdateCricketAge(context, inCricketRoom ? cricketRoomAgePercent : ((CValuePercent)100)))
			{
				if (DomainManager.Taiwu.GetWarehouseItemCount(cricketKey) > 0 || inCricketRoom || DomainManager.Taiwu.GetTaiwu().GetInventory().Items.ContainsKey(cricketKey))
				{
					short colorId = cricket.GetColorId();
					short partId = cricket.GetPartId();
					int nameId = cricket.GetNameId();
					monthlyNotificationCollection.AddCricketEndLife(colorId, partId, nameId);
				}
				else
				{
					_newDeadCrickets.Add(cricketKey);
				}
			}
		}
	}

	[DomainMethod]
	public bool[] GetCricketsAliveState(List<ItemKey> keyList)
	{
		bool[] stateArray = new bool[keyList.Count];
		if (keyList != null)
		{
			for (int index = 0; index < keyList.Count; index++)
			{
				ItemKey itemKey = keyList[index];
				bool alive = false;
				if (DomainManager.Item.TryGetElement_Crickets(itemKey.Id, out var cricket))
				{
					alive = cricket.IsAlive;
				}
				stateArray[index] = alive;
			}
		}
		return stateArray;
	}

	public static short GetWugTemplateId(sbyte wugType, sbyte wugGrowthType)
	{
		int index = wugType * 6 + wugGrowthType;
		return _wugTemplateIds[index];
	}

	public static IEnumerable<short> GetWugTemplateIdGroup(sbyte wugType, bool isKing)
	{
		int group = wugType * 6;
		int begin = (isKing ? 5 : group);
		int end = (isKing ? 53 : (group + 5));
		int step = ((!isKing) ? 1 : 6);
		for (int i = begin; i < end; i += step)
		{
			yield return _wugTemplateIds[i];
		}
	}

	private static void InitializeWugTemplateIds()
	{
		_wugTemplateIds = new short[48];
		foreach (MedicineItem item in (IEnumerable<MedicineItem>)Config.Medicine.Instance)
		{
			if (item.WugType >= 0)
			{
				int index = item.WugType * 6 + item.WugGrowthType;
				_wugTemplateIds[index] = item.TemplateId;
			}
		}
	}

	public ItemDomain()
		: base(23)
	{
		_weapons = new Dictionary<int, Weapon>(0);
		_armors = new Dictionary<int, Armor>(0);
		_accessories = new Dictionary<int, Accessory>(0);
		_clothing = new Dictionary<int, Clothing>(0);
		_carriers = new Dictionary<int, Carrier>(0);
		_materials = new Dictionary<int, Material>(0);
		_craftTools = new Dictionary<int, CraftTool>(0);
		_foods = new Dictionary<int, Food>(0);
		_medicines = new Dictionary<int, Medicine>(0);
		_teaWines = new Dictionary<int, TeaWine>(0);
		_skillBooks = new Dictionary<int, SkillBook>(0);
		_crickets = new Dictionary<int, Cricket>(0);
		_misc = new Dictionary<int, Misc>(0);
		_nextItemId = 0;
		_stackableItems = new Dictionary<TemplateKey, int>(0);
		_poisonItems = new Dictionary<int, PoisonEffects>(0);
		_refinedItems = new Dictionary<int, RefiningEffects>(0);
		_emptyHandKey = default(ItemKey);
		_branchKey = default(ItemKey);
		_stoneKey = default(ItemKey);
		_externEquipmentEffects = new Dictionary<int, GameData.Utilities.ShortList>(0);
		_mysteryData = new Dictionary<int, MysteryData>(0);
		_medicineExtraAddPercent = new Dictionary<int, int>(0);
		HelperDataWeapons = new ObjectCollectionHelperData(6, 0, CacheInfluencesWeapons, _dataStatesWeapons, isArchive: true);
		HelperDataArmors = new ObjectCollectionHelperData(6, 1, CacheInfluencesArmors, _dataStatesArmors, isArchive: true);
		HelperDataAccessories = new ObjectCollectionHelperData(6, 2, CacheInfluencesAccessories, _dataStatesAccessories, isArchive: true);
		HelperDataClothing = new ObjectCollectionHelperData(6, 3, CacheInfluencesClothing, _dataStatesClothing, isArchive: true);
		HelperDataCarriers = new ObjectCollectionHelperData(6, 4, CacheInfluencesCarriers, _dataStatesCarriers, isArchive: true);
		HelperDataMaterials = new ObjectCollectionHelperData(6, 5, CacheInfluencesMaterials, _dataStatesMaterials, isArchive: true);
		HelperDataCraftTools = new ObjectCollectionHelperData(6, 6, CacheInfluencesCraftTools, _dataStatesCraftTools, isArchive: true);
		HelperDataFoods = new ObjectCollectionHelperData(6, 7, CacheInfluencesFoods, _dataStatesFoods, isArchive: true);
		HelperDataMedicines = new ObjectCollectionHelperData(6, 8, CacheInfluencesMedicines, _dataStatesMedicines, isArchive: true);
		HelperDataTeaWines = new ObjectCollectionHelperData(6, 9, CacheInfluencesTeaWines, _dataStatesTeaWines, isArchive: true);
		HelperDataSkillBooks = new ObjectCollectionHelperData(6, 10, CacheInfluencesSkillBooks, _dataStatesSkillBooks, isArchive: true);
		HelperDataCrickets = new ObjectCollectionHelperData(6, 11, CacheInfluencesCrickets, _dataStatesCrickets, isArchive: true);
		HelperDataMisc = new ObjectCollectionHelperData(6, 12, CacheInfluencesMisc, _dataStatesMisc, isArchive: true);
		OnInitializedDomainData();
	}

	public Weapon GetElement_Weapons(int objectId)
	{
		return _weapons[objectId];
	}

	public bool TryGetElement_Weapons(int objectId, out Weapon element)
	{
		return _weapons.TryGetValue(objectId, out element);
	}

	private void AddElement_Weapons(int objectId, Weapon instance)
	{
		instance.CollectionHelperData = HelperDataWeapons;
		instance.DataStatesOffset = _dataStatesWeapons.Create();
		_weapons.Add(objectId, instance);
	}

	private void RemoveElement_Weapons(int objectId)
	{
		if (_weapons.TryGetValue(objectId, out var instance))
		{
			_dataStatesWeapons.Remove(instance.DataStatesOffset);
			_weapons.Remove(objectId);
		}
	}

	private void ClearWeapons()
	{
		_dataStatesWeapons.Clear();
		_weapons.Clear();
	}

	public int GetElementField_Weapons(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_weapons.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_Weapons", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesWeapons.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquipmentEffectId(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetTricks(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		case 7:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquippedCharId(), dataPool);
		case 8:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaterialResources(), dataPool);
		case 9:
			return GameData.Serializer.Serializer.Serialize(instance.GetPenetrationFactor(), dataPool);
		case 10:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquipmentAttack(), dataPool);
		case 11:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquipmentDefense(), dataPool);
		case 12:
			return GameData.Serializer.Serializer.Serialize(instance.GetWeight(), dataPool);
		case 13:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquippedPower(), dataPool);
		default:
			if (fieldId >= 86)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_Weapons(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_weapons.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetEquipmentEffectId(value, context);
			return;
		}
		case 4:
		{
			List<sbyte> value6 = instance.GetTricks();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value6);
			instance.SetTricks(value6, context);
			return;
		}
		case 5:
		{
			short value5 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetCurrDurability(value5, context);
			return;
		}
		case 6:
		{
			byte value4 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetModificationState(value4, context);
			return;
		}
		case 7:
		{
			int value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetEquippedCharId(value3, context);
			return;
		}
		case 8:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		if (fieldId >= 86)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 14)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_Weapons(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_weapons.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 14)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesWeapons.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesWeapons.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetEquipmentEffectId(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetTricks(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			7 => GameData.Serializer.Serializer.Serialize(instance.GetEquippedCharId(), dataPool), 
			8 => GameData.Serializer.Serializer.Serialize(instance.GetMaterialResources(), dataPool), 
			9 => GameData.Serializer.Serializer.Serialize(instance.GetPenetrationFactor(), dataPool), 
			10 => GameData.Serializer.Serializer.Serialize(instance.GetEquipmentAttack(), dataPool), 
			11 => GameData.Serializer.Serializer.Serialize(instance.GetEquipmentDefense(), dataPool), 
			12 => GameData.Serializer.Serializer.Serialize(instance.GetWeight(), dataPool), 
			13 => GameData.Serializer.Serializer.Serialize(instance.GetEquippedPower(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_Weapons(int objectId, ushort fieldId)
	{
		if (_weapons.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 14)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesWeapons.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesWeapons.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_Weapons(int objectId, ushort fieldId)
	{
		if (!_weapons.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 14)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesWeapons.IsModified(instance.DataStatesOffset, fieldId);
	}

	public Armor GetElement_Armors(int objectId)
	{
		return _armors[objectId];
	}

	public bool TryGetElement_Armors(int objectId, out Armor element)
	{
		return _armors.TryGetValue(objectId, out element);
	}

	private void AddElement_Armors(int objectId, Armor instance)
	{
		instance.CollectionHelperData = HelperDataArmors;
		instance.DataStatesOffset = _dataStatesArmors.Create();
		_armors.Add(objectId, instance);
	}

	private void RemoveElement_Armors(int objectId)
	{
		if (_armors.TryGetValue(objectId, out var instance))
		{
			_dataStatesArmors.Remove(instance.DataStatesOffset);
			_armors.Remove(objectId);
		}
	}

	private void ClearArmors()
	{
		_dataStatesArmors.Clear();
		_armors.Clear();
	}

	public int GetElementField_Armors(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_armors.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_Armors", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesArmors.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquipmentEffectId(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquippedCharId(), dataPool);
		case 7:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaterialResources(), dataPool);
		case 8:
			return GameData.Serializer.Serializer.Serialize(instance.GetPenetrationResistFactors(), dataPool);
		case 9:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquipmentAttack(), dataPool);
		case 10:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquipmentDefense(), dataPool);
		case 11:
			return GameData.Serializer.Serializer.Serialize(instance.GetWeight(), dataPool);
		case 12:
			return GameData.Serializer.Serializer.Serialize(instance.GetInjuryFactor(), dataPool);
		case 13:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquippedPower(), dataPool);
		default:
			if (fieldId >= 56)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_Armors(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_armors.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetEquipmentEffectId(value, context);
			return;
		}
		case 4:
		{
			short value5 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetCurrDurability(value5, context);
			return;
		}
		case 5:
		{
			byte value4 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetModificationState(value4, context);
			return;
		}
		case 6:
		{
			int value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetEquippedCharId(value3, context);
			return;
		}
		case 7:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		if (fieldId >= 56)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 14)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_Armors(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_armors.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 14)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesArmors.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesArmors.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetEquipmentEffectId(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetEquippedCharId(), dataPool), 
			7 => GameData.Serializer.Serializer.Serialize(instance.GetMaterialResources(), dataPool), 
			8 => GameData.Serializer.Serializer.Serialize(instance.GetPenetrationResistFactors(), dataPool), 
			9 => GameData.Serializer.Serializer.Serialize(instance.GetEquipmentAttack(), dataPool), 
			10 => GameData.Serializer.Serializer.Serialize(instance.GetEquipmentDefense(), dataPool), 
			11 => GameData.Serializer.Serializer.Serialize(instance.GetWeight(), dataPool), 
			12 => GameData.Serializer.Serializer.Serialize(instance.GetInjuryFactor(), dataPool), 
			13 => GameData.Serializer.Serializer.Serialize(instance.GetEquippedPower(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_Armors(int objectId, ushort fieldId)
	{
		if (_armors.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 14)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesArmors.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesArmors.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_Armors(int objectId, ushort fieldId)
	{
		if (!_armors.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 14)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesArmors.IsModified(instance.DataStatesOffset, fieldId);
	}

	public Accessory GetElement_Accessories(int objectId)
	{
		return _accessories[objectId];
	}

	public bool TryGetElement_Accessories(int objectId, out Accessory element)
	{
		return _accessories.TryGetValue(objectId, out element);
	}

	private void AddElement_Accessories(int objectId, Accessory instance)
	{
		instance.CollectionHelperData = HelperDataAccessories;
		instance.DataStatesOffset = _dataStatesAccessories.Create();
		_accessories.Add(objectId, instance);
	}

	private void RemoveElement_Accessories(int objectId)
	{
		if (_accessories.TryGetValue(objectId, out var instance))
		{
			_dataStatesAccessories.Remove(instance.DataStatesOffset);
			_accessories.Remove(objectId);
		}
	}

	private void ClearAccessories()
	{
		_dataStatesAccessories.Clear();
		_accessories.Clear();
	}

	public int GetElementField_Accessories(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_accessories.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_Accessories", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesAccessories.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquipmentEffectId(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquippedCharId(), dataPool);
		case 7:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaterialResources(), dataPool);
		case 8:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquippedPower(), dataPool);
		default:
			if (fieldId >= 83)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_Accessories(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_accessories.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetEquipmentEffectId(value, context);
			return;
		}
		case 4:
		{
			short value5 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetCurrDurability(value5, context);
			return;
		}
		case 5:
		{
			byte value4 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetModificationState(value4, context);
			return;
		}
		case 6:
		{
			int value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetEquippedCharId(value3, context);
			return;
		}
		case 7:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		if (fieldId >= 83)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 9)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_Accessories(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_accessories.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 9)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesAccessories.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesAccessories.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetEquipmentEffectId(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetEquippedCharId(), dataPool), 
			7 => GameData.Serializer.Serializer.Serialize(instance.GetMaterialResources(), dataPool), 
			8 => GameData.Serializer.Serializer.Serialize(instance.GetEquippedPower(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_Accessories(int objectId, ushort fieldId)
	{
		if (_accessories.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 9)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesAccessories.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesAccessories.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_Accessories(int objectId, ushort fieldId)
	{
		if (!_accessories.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 9)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesAccessories.IsModified(instance.DataStatesOffset, fieldId);
	}

	public Clothing GetElement_Clothing(int objectId)
	{
		return _clothing[objectId];
	}

	public bool TryGetElement_Clothing(int objectId, out Clothing element)
	{
		return _clothing.TryGetValue(objectId, out element);
	}

	private void AddElement_Clothing(int objectId, Clothing instance)
	{
		instance.CollectionHelperData = HelperDataClothing;
		instance.DataStatesOffset = _dataStatesClothing.Create();
		_clothing.Add(objectId, instance);
	}

	private void RemoveElement_Clothing(int objectId)
	{
		if (_clothing.TryGetValue(objectId, out var instance))
		{
			_dataStatesClothing.Remove(instance.DataStatesOffset);
			_clothing.Remove(objectId);
		}
	}

	private void ClearClothing()
	{
		_dataStatesClothing.Clear();
		_clothing.Clear();
	}

	public int GetElementField_Clothing(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_clothing.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_Clothing", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesClothing.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquipmentEffectId(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquippedCharId(), dataPool);
		case 7:
			return GameData.Serializer.Serializer.Serialize(instance.GetGender(), dataPool);
		case 8:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaterialResources(), dataPool);
		case 9:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquippedPower(), dataPool);
		default:
			if (fieldId >= 48)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_Clothing(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_clothing.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetEquipmentEffectId(value, context);
			return;
		}
		case 4:
		{
			short value6 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value6);
			instance.SetCurrDurability(value6, context);
			return;
		}
		case 5:
		{
			byte value5 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetModificationState(value5, context);
			return;
		}
		case 6:
		{
			int value4 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetEquippedCharId(value4, context);
			return;
		}
		case 7:
		{
			sbyte value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetGender(value3, context);
			return;
		}
		case 8:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		if (fieldId >= 48)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 10)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_Clothing(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_clothing.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 10)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesClothing.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesClothing.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetEquipmentEffectId(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetEquippedCharId(), dataPool), 
			7 => GameData.Serializer.Serializer.Serialize(instance.GetGender(), dataPool), 
			8 => GameData.Serializer.Serializer.Serialize(instance.GetMaterialResources(), dataPool), 
			9 => GameData.Serializer.Serializer.Serialize(instance.GetEquippedPower(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_Clothing(int objectId, ushort fieldId)
	{
		if (_clothing.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 10)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesClothing.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesClothing.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_Clothing(int objectId, ushort fieldId)
	{
		if (!_clothing.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 10)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesClothing.IsModified(instance.DataStatesOffset, fieldId);
	}

	public Carrier GetElement_Carriers(int objectId)
	{
		return _carriers[objectId];
	}

	public bool TryGetElement_Carriers(int objectId, out Carrier element)
	{
		return _carriers.TryGetValue(objectId, out element);
	}

	private void AddElement_Carriers(int objectId, Carrier instance)
	{
		instance.CollectionHelperData = HelperDataCarriers;
		instance.DataStatesOffset = _dataStatesCarriers.Create();
		_carriers.Add(objectId, instance);
	}

	private void RemoveElement_Carriers(int objectId)
	{
		if (_carriers.TryGetValue(objectId, out var instance))
		{
			_dataStatesCarriers.Remove(instance.DataStatesOffset);
			_carriers.Remove(objectId);
		}
	}

	private void ClearCarriers()
	{
		_dataStatesCarriers.Clear();
		_carriers.Clear();
	}

	public int GetElementField_Carriers(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_carriers.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_Carriers", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesCarriers.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquipmentEffectId(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquippedCharId(), dataPool);
		case 7:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaterialResources(), dataPool);
		case 8:
			return GameData.Serializer.Serializer.Serialize(instance.GetEquippedPower(), dataPool);
		default:
			if (fieldId >= 56)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_Carriers(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_carriers.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetEquipmentEffectId(value, context);
			return;
		}
		case 4:
		{
			short value5 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetCurrDurability(value5, context);
			return;
		}
		case 5:
		{
			byte value4 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetModificationState(value4, context);
			return;
		}
		case 6:
		{
			int value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetEquippedCharId(value3, context);
			return;
		}
		case 7:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		if (fieldId >= 56)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 9)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_Carriers(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_carriers.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 9)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesCarriers.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesCarriers.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetEquipmentEffectId(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetEquippedCharId(), dataPool), 
			7 => GameData.Serializer.Serializer.Serialize(instance.GetMaterialResources(), dataPool), 
			8 => GameData.Serializer.Serializer.Serialize(instance.GetEquippedPower(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_Carriers(int objectId, ushort fieldId)
	{
		if (_carriers.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 9)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesCarriers.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesCarriers.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_Carriers(int objectId, ushort fieldId)
	{
		if (!_carriers.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 9)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesCarriers.IsModified(instance.DataStatesOffset, fieldId);
	}

	public Material GetElement_Materials(int objectId)
	{
		return _materials[objectId];
	}

	public bool TryGetElement_Materials(int objectId, out Material element)
	{
		return _materials.TryGetValue(objectId, out element);
	}

	private void AddElement_Materials(int objectId, Material instance)
	{
		instance.CollectionHelperData = HelperDataMaterials;
		instance.DataStatesOffset = _dataStatesMaterials.Create();
		_materials.Add(objectId, instance);
	}

	private void RemoveElement_Materials(int objectId)
	{
		if (_materials.TryGetValue(objectId, out var instance))
		{
			_dataStatesMaterials.Remove(instance.DataStatesOffset);
			_materials.Remove(objectId);
		}
	}

	private void ClearMaterials()
	{
		_dataStatesMaterials.Clear();
		_materials.Clear();
	}

	public int GetElementField_Materials(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_materials.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_Materials", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesMaterials.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		default:
			if (fieldId >= 89)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_Materials(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_materials.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetCurrDurability(value, context);
			return;
		}
		case 4:
		{
			byte value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetModificationState(value3, context);
			return;
		}
		}
		if (fieldId >= 89)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_Materials(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_materials.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesMaterials.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesMaterials.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_Materials(int objectId, ushort fieldId)
	{
		if (_materials.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 5)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesMaterials.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesMaterials.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_Materials(int objectId, ushort fieldId)
	{
		if (!_materials.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesMaterials.IsModified(instance.DataStatesOffset, fieldId);
	}

	public CraftTool GetElement_CraftTools(int objectId)
	{
		return _craftTools[objectId];
	}

	public bool TryGetElement_CraftTools(int objectId, out CraftTool element)
	{
		return _craftTools.TryGetValue(objectId, out element);
	}

	private void AddElement_CraftTools(int objectId, CraftTool instance)
	{
		instance.CollectionHelperData = HelperDataCraftTools;
		instance.DataStatesOffset = _dataStatesCraftTools.Create();
		_craftTools.Add(objectId, instance);
	}

	private void RemoveElement_CraftTools(int objectId)
	{
		if (_craftTools.TryGetValue(objectId, out var instance))
		{
			_dataStatesCraftTools.Remove(instance.DataStatesOffset);
			_craftTools.Remove(objectId);
		}
	}

	private void ClearCraftTools()
	{
		_dataStatesCraftTools.Clear();
		_craftTools.Clear();
	}

	public int GetElementField_CraftTools(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_craftTools.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_CraftTools", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesCraftTools.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		default:
			if (fieldId >= 36)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_CraftTools(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_craftTools.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetCurrDurability(value, context);
			return;
		}
		case 4:
		{
			byte value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetModificationState(value3, context);
			return;
		}
		}
		if (fieldId >= 36)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_CraftTools(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_craftTools.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesCraftTools.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesCraftTools.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_CraftTools(int objectId, ushort fieldId)
	{
		if (_craftTools.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 5)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesCraftTools.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesCraftTools.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_CraftTools(int objectId, ushort fieldId)
	{
		if (!_craftTools.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesCraftTools.IsModified(instance.DataStatesOffset, fieldId);
	}

	public Food GetElement_Foods(int objectId)
	{
		return _foods[objectId];
	}

	public bool TryGetElement_Foods(int objectId, out Food element)
	{
		return _foods.TryGetValue(objectId, out element);
	}

	private void AddElement_Foods(int objectId, Food instance)
	{
		instance.CollectionHelperData = HelperDataFoods;
		instance.DataStatesOffset = _dataStatesFoods.Create();
		_foods.Add(objectId, instance);
	}

	private void RemoveElement_Foods(int objectId)
	{
		if (_foods.TryGetValue(objectId, out var instance))
		{
			_dataStatesFoods.Remove(instance.DataStatesOffset);
			_foods.Remove(objectId);
		}
	}

	private void ClearFoods()
	{
		_dataStatesFoods.Clear();
		_foods.Clear();
	}

	public int GetElementField_Foods(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_foods.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_Foods", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesFoods.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		default:
			if (fieldId >= 72)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_Foods(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_foods.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetCurrDurability(value, context);
			return;
		}
		case 4:
		{
			byte value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetModificationState(value3, context);
			return;
		}
		}
		if (fieldId >= 72)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_Foods(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_foods.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesFoods.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesFoods.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_Foods(int objectId, ushort fieldId)
	{
		if (_foods.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 5)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesFoods.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesFoods.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_Foods(int objectId, ushort fieldId)
	{
		if (!_foods.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesFoods.IsModified(instance.DataStatesOffset, fieldId);
	}

	public Medicine GetElement_Medicines(int objectId)
	{
		return _medicines[objectId];
	}

	public bool TryGetElement_Medicines(int objectId, out Medicine element)
	{
		return _medicines.TryGetValue(objectId, out element);
	}

	private void AddElement_Medicines(int objectId, Medicine instance)
	{
		instance.CollectionHelperData = HelperDataMedicines;
		instance.DataStatesOffset = _dataStatesMedicines.Create();
		_medicines.Add(objectId, instance);
	}

	private void RemoveElement_Medicines(int objectId)
	{
		if (_medicines.TryGetValue(objectId, out var instance))
		{
			_dataStatesMedicines.Remove(instance.DataStatesOffset);
			_medicines.Remove(objectId);
		}
	}

	private void ClearMedicines()
	{
		_dataStatesMedicines.Clear();
		_medicines.Clear();
	}

	public int GetElementField_Medicines(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_medicines.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_Medicines", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesMedicines.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		default:
			if (fieldId >= 86)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_Medicines(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_medicines.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetCurrDurability(value, context);
			return;
		}
		case 4:
		{
			byte value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetModificationState(value3, context);
			return;
		}
		}
		if (fieldId >= 86)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_Medicines(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_medicines.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesMedicines.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesMedicines.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_Medicines(int objectId, ushort fieldId)
	{
		if (_medicines.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 5)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesMedicines.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesMedicines.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_Medicines(int objectId, ushort fieldId)
	{
		if (!_medicines.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesMedicines.IsModified(instance.DataStatesOffset, fieldId);
	}

	public TeaWine GetElement_TeaWines(int objectId)
	{
		return _teaWines[objectId];
	}

	public bool TryGetElement_TeaWines(int objectId, out TeaWine element)
	{
		return _teaWines.TryGetValue(objectId, out element);
	}

	private void AddElement_TeaWines(int objectId, TeaWine instance)
	{
		instance.CollectionHelperData = HelperDataTeaWines;
		instance.DataStatesOffset = _dataStatesTeaWines.Create();
		_teaWines.Add(objectId, instance);
	}

	private void RemoveElement_TeaWines(int objectId)
	{
		if (_teaWines.TryGetValue(objectId, out var instance))
		{
			_dataStatesTeaWines.Remove(instance.DataStatesOffset);
			_teaWines.Remove(objectId);
		}
	}

	private void ClearTeaWines()
	{
		_dataStatesTeaWines.Clear();
		_teaWines.Clear();
	}

	public int GetElementField_TeaWines(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_teaWines.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_TeaWines", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesTeaWines.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		default:
			if (fieldId >= 55)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_TeaWines(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_teaWines.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetCurrDurability(value, context);
			return;
		}
		case 4:
		{
			byte value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetModificationState(value3, context);
			return;
		}
		}
		if (fieldId >= 55)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_TeaWines(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_teaWines.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesTeaWines.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesTeaWines.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_TeaWines(int objectId, ushort fieldId)
	{
		if (_teaWines.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 5)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesTeaWines.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesTeaWines.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_TeaWines(int objectId, ushort fieldId)
	{
		if (!_teaWines.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesTeaWines.IsModified(instance.DataStatesOffset, fieldId);
	}

	public SkillBook GetElement_SkillBooks(int objectId)
	{
		return _skillBooks[objectId];
	}

	public bool TryGetElement_SkillBooks(int objectId, out SkillBook element)
	{
		return _skillBooks.TryGetValue(objectId, out element);
	}

	private void AddElement_SkillBooks(int objectId, SkillBook instance)
	{
		instance.CollectionHelperData = HelperDataSkillBooks;
		instance.DataStatesOffset = _dataStatesSkillBooks.Create();
		_skillBooks.Add(objectId, instance);
	}

	private void RemoveElement_SkillBooks(int objectId)
	{
		if (_skillBooks.TryGetValue(objectId, out var instance))
		{
			_dataStatesSkillBooks.Remove(instance.DataStatesOffset);
			_skillBooks.Remove(objectId);
		}
	}

	private void ClearSkillBooks()
	{
		_dataStatesSkillBooks.Clear();
		_skillBooks.Clear();
	}

	public int GetElementField_SkillBooks(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_skillBooks.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_SkillBooks", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesSkillBooks.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetPageTypes(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetPageIncompleteState(), dataPool);
		default:
			if (fieldId >= 41)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_SkillBooks(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_skillBooks.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetCurrDurability(value, context);
			return;
		}
		case 4:
		{
			byte value5 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetModificationState(value5, context);
			return;
		}
		case 5:
		{
			byte value4 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetPageTypes(value4, context);
			return;
		}
		case 6:
		{
			ushort value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetPageIncompleteState(value3, context);
			return;
		}
		}
		if (fieldId >= 41)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 7)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_SkillBooks(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_skillBooks.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 7)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesSkillBooks.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesSkillBooks.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetPageTypes(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetPageIncompleteState(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_SkillBooks(int objectId, ushort fieldId)
	{
		if (_skillBooks.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 7)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesSkillBooks.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesSkillBooks.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_SkillBooks(int objectId, ushort fieldId)
	{
		if (!_skillBooks.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 7)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesSkillBooks.IsModified(instance.DataStatesOffset, fieldId);
	}

	public Cricket GetElement_Crickets(int objectId)
	{
		return _crickets[objectId];
	}

	public bool TryGetElement_Crickets(int objectId, out Cricket element)
	{
		return _crickets.TryGetValue(objectId, out element);
	}

	private void AddElement_Crickets(int objectId, Cricket instance)
	{
		instance.CollectionHelperData = HelperDataCrickets;
		instance.DataStatesOffset = _dataStatesCrickets.Create();
		_crickets.Add(objectId, instance);
	}

	private void RemoveElement_Crickets(int objectId)
	{
		if (_crickets.TryGetValue(objectId, out var instance))
		{
			_dataStatesCrickets.Remove(instance.DataStatesOffset);
			_crickets.Remove(objectId);
		}
	}

	private void ClearCrickets()
	{
		_dataStatesCrickets.Clear();
		_crickets.Clear();
	}

	public int GetElementField_Crickets(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_crickets.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_Crickets", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesCrickets.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetColorId(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetPartId(), dataPool);
		case 7:
			return GameData.Serializer.Serializer.Serialize(instance.GetInjuries(), dataPool);
		case 8:
			return GameData.Serializer.Serializer.Serialize(instance.GetWinsCount(), dataPool);
		case 9:
			return GameData.Serializer.Serializer.Serialize(instance.GetLossesCount(), dataPool);
		case 10:
			return GameData.Serializer.Serializer.Serialize(instance.GetBestEnemyColorId(), dataPool);
		case 11:
			return GameData.Serializer.Serializer.Serialize(instance.GetBestEnemyPartId(), dataPool);
		case 12:
			return GameData.Serializer.Serializer.Serialize(instance.GetAgeObsolete(), dataPool);
		case 13:
			return GameData.Serializer.Serializer.Serialize(instance.GetAgeProgress(), dataPool);
		case 14:
			return GameData.Serializer.Serializer.Serialize(instance.GetSpirit(), dataPool);
		case 15:
			return GameData.Serializer.Serializer.Serialize(instance.GetSpiritAddProperties(), dataPool);
		case 16:
			return GameData.Serializer.Serializer.Serialize(instance.GetOriginState(), dataPool);
		case 17:
			return GameData.Serializer.Serializer.Serialize(instance.GetPolymorphRateFix(), dataPool);
		case 18:
			return GameData.Serializer.Serializer.Serialize(instance.GetNameId(), dataPool);
		default:
			if (fieldId >= 45)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_Crickets(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_crickets.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetCurrDurability(value, context);
			return;
		}
		case 4:
		{
			byte value15 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value15);
			instance.SetModificationState(value15, context);
			return;
		}
		case 5:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 6:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 7:
		{
			short[] value14 = instance.GetInjuries();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value14);
			instance.SetInjuries(value14, context);
			return;
		}
		case 8:
		{
			short value13 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value13);
			instance.SetWinsCount(value13, context);
			return;
		}
		case 9:
		{
			short value12 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value12);
			instance.SetLossesCount(value12, context);
			return;
		}
		case 10:
		{
			short value11 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value11);
			instance.SetBestEnemyColorId(value11, context);
			return;
		}
		case 11:
		{
			short value10 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value10);
			instance.SetBestEnemyPartId(value10, context);
			return;
		}
		case 12:
		{
			sbyte value9 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value9);
			instance.SetAgeObsolete(value9, context);
			return;
		}
		case 13:
		{
			int value8 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value8);
			instance.SetAgeProgress(value8, context);
			return;
		}
		case 14:
		{
			int value7 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value7);
			instance.SetSpirit(value7, context);
			return;
		}
		case 15:
		{
			CricketSpiritProperty value6 = instance.GetSpiritAddProperties();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value6);
			instance.SetSpiritAddProperties(value6, context);
			return;
		}
		case 16:
		{
			sbyte value5 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetOriginState(value5, context);
			return;
		}
		case 17:
		{
			int value4 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetPolymorphRateFix(value4, context);
			return;
		}
		case 18:
		{
			int value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetNameId(value3, context);
			return;
		}
		}
		if (fieldId >= 45)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 19)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_Crickets(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_crickets.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 19)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesCrickets.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesCrickets.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetColorId(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetPartId(), dataPool), 
			7 => GameData.Serializer.Serializer.Serialize(instance.GetInjuries(), dataPool), 
			8 => GameData.Serializer.Serializer.Serialize(instance.GetWinsCount(), dataPool), 
			9 => GameData.Serializer.Serializer.Serialize(instance.GetLossesCount(), dataPool), 
			10 => GameData.Serializer.Serializer.Serialize(instance.GetBestEnemyColorId(), dataPool), 
			11 => GameData.Serializer.Serializer.Serialize(instance.GetBestEnemyPartId(), dataPool), 
			12 => GameData.Serializer.Serializer.Serialize(instance.GetAgeObsolete(), dataPool), 
			13 => GameData.Serializer.Serializer.Serialize(instance.GetAgeProgress(), dataPool), 
			14 => GameData.Serializer.Serializer.Serialize(instance.GetSpirit(), dataPool), 
			15 => GameData.Serializer.Serializer.Serialize(instance.GetSpiritAddProperties(), dataPool), 
			16 => GameData.Serializer.Serializer.Serialize(instance.GetOriginState(), dataPool), 
			17 => GameData.Serializer.Serializer.Serialize(instance.GetPolymorphRateFix(), dataPool), 
			18 => GameData.Serializer.Serializer.Serialize(instance.GetNameId(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_Crickets(int objectId, ushort fieldId)
	{
		if (_crickets.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 19)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesCrickets.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesCrickets.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_Crickets(int objectId, ushort fieldId)
	{
		if (!_crickets.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 19)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesCrickets.IsModified(instance.DataStatesOffset, fieldId);
	}

	public Misc GetElement_Misc(int objectId)
	{
		return _misc[objectId];
	}

	public bool TryGetElement_Misc(int objectId, out Misc element)
	{
		return _misc.TryGetValue(objectId, out element);
	}

	private void AddElement_Misc(int objectId, Misc instance)
	{
		instance.CollectionHelperData = HelperDataMisc;
		instance.DataStatesOffset = _dataStatesMisc.Create();
		_misc.Add(objectId, instance);
	}

	private void RemoveElement_Misc(int objectId)
	{
		if (_misc.TryGetValue(objectId, out var instance))
		{
			_dataStatesMisc.Remove(instance.DataStatesOffset);
			_misc.Remove(objectId);
		}
	}

	private void ClearMisc()
	{
		_dataStatesMisc.Clear();
		_misc.Clear();
	}

	public int GetElementField_Misc(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_misc.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_Misc", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesMisc.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool);
		default:
			if (fieldId >= 57)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_Misc(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_misc.TryGetValue(objectId, out var instance))
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
			instance.SetMaxDurability(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetCurrDurability(value, context);
			return;
		}
		case 4:
		{
			byte value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetModificationState(value3, context);
			return;
		}
		}
		if (fieldId >= 57)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_Misc(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_misc.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesMisc.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesMisc.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetTemplateId(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetMaxDurability(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetCurrDurability(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetModificationState(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_Misc(int objectId, ushort fieldId)
	{
		if (_misc.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 5)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesMisc.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesMisc.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_Misc(int objectId, ushort fieldId)
	{
		if (!_misc.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 5)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesMisc.IsModified(instance.DataStatesOffset, fieldId);
	}

	private int GetNextItemId()
	{
		return _nextItemId;
	}

	private void SetNextItemId(int value, DataContext context)
	{
		_nextItemId = value;
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	private int GetElement_StackableItems(TemplateKey elementId)
	{
		return _stackableItems[elementId];
	}

	private bool TryGetElement_StackableItems(TemplateKey elementId, out int value)
	{
		return _stackableItems.TryGetValue(elementId, out value);
	}

	private void AddElement_StackableItems(TemplateKey elementId, int value, DataContext context)
	{
		_stackableItems.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	private void SetElement_StackableItems(TemplateKey elementId, int value, DataContext context)
	{
		_stackableItems[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_StackableItems(TemplateKey elementId, DataContext context)
	{
		_stackableItems.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	private void ClearStackableItems(DataContext context)
	{
		_stackableItems.Clear();
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _poisonItems is no longer in use.")]
	private PoisonEffects GetElement_PoisonItems(int elementId)
	{
		return _poisonItems[elementId];
	}

	[Obsolete("DomainData _poisonItems is no longer in use.")]
	private bool TryGetElement_PoisonItems(int elementId, out PoisonEffects value)
	{
		return _poisonItems.TryGetValue(elementId, out value);
	}

	[Obsolete("DomainData _poisonItems is no longer in use.")]
	private void AddElement_PoisonItems(int elementId, ref PoisonEffects value, DataContext context)
	{
		_poisonItems.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _poisonItems is no longer in use.")]
	private void SetElement_PoisonItems(int elementId, ref PoisonEffects value, DataContext context)
	{
		_poisonItems[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _poisonItems is no longer in use.")]
	private void RemoveElement_PoisonItems(int elementId, DataContext context)
	{
		_poisonItems.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _poisonItems is no longer in use.")]
	private void ClearPoisonItems(DataContext context)
	{
		_poisonItems.Clear();
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	private RefiningEffects GetElement_RefinedItems(int elementId)
	{
		return _refinedItems[elementId];
	}

	private bool TryGetElement_RefinedItems(int elementId, out RefiningEffects value)
	{
		return _refinedItems.TryGetValue(elementId, out value);
	}

	private void AddElement_RefinedItems(int elementId, RefiningEffects value, DataContext context)
	{
		_refinedItems.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	private void SetElement_RefinedItems(int elementId, RefiningEffects value, DataContext context)
	{
		_refinedItems[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_RefinedItems(int elementId, DataContext context)
	{
		_refinedItems.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	private void ClearRefinedItems(DataContext context)
	{
		_refinedItems.Clear();
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	private ItemKey GetEmptyHandKey()
	{
		return _emptyHandKey;
	}

	private void SetEmptyHandKey(ItemKey value, DataContext context)
	{
		_emptyHandKey = value;
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	private ItemKey GetBranchKey()
	{
		return _branchKey;
	}

	private void SetBranchKey(ItemKey value, DataContext context)
	{
		_branchKey = value;
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
	}

	private ItemKey GetStoneKey()
	{
		return _stoneKey;
	}

	private void SetStoneKey(ItemKey value, DataContext context)
	{
		_stoneKey = value;
		SetModifiedAndInvalidateInfluencedCache(19, DataStates, CacheInfluences, context);
	}

	private GameData.Utilities.ShortList GetElement_ExternEquipmentEffects(int elementId)
	{
		return _externEquipmentEffects[elementId];
	}

	private bool TryGetElement_ExternEquipmentEffects(int elementId, out GameData.Utilities.ShortList value)
	{
		return _externEquipmentEffects.TryGetValue(elementId, out value);
	}

	private void AddElement_ExternEquipmentEffects(int elementId, GameData.Utilities.ShortList value, DataContext context)
	{
		_externEquipmentEffects.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(20, DataStates, CacheInfluences, context);
	}

	private void SetElement_ExternEquipmentEffects(int elementId, GameData.Utilities.ShortList value, DataContext context)
	{
		_externEquipmentEffects[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(20, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_ExternEquipmentEffects(int elementId, DataContext context)
	{
		_externEquipmentEffects.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(20, DataStates, CacheInfluences, context);
	}

	private void ClearExternEquipmentEffects(DataContext context)
	{
		_externEquipmentEffects.Clear();
		SetModifiedAndInvalidateInfluencedCache(20, DataStates, CacheInfluences, context);
	}

	public MysteryData GetElement_MysteryData(int elementId)
	{
		return _mysteryData[elementId];
	}

	public bool TryGetElement_MysteryData(int elementId, out MysteryData value)
	{
		return _mysteryData.TryGetValue(elementId, out value);
	}

	private void AddElement_MysteryData(int elementId, MysteryData value, DataContext context)
	{
		_mysteryData.Add(elementId, value);
		_modificationsMysteryData.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	private void SetElement_MysteryData(int elementId, MysteryData value, DataContext context)
	{
		_mysteryData[elementId] = value;
		_modificationsMysteryData.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_MysteryData(int elementId, DataContext context)
	{
		_mysteryData.Remove(elementId);
		_modificationsMysteryData.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	private void ClearMysteryData(DataContext context)
	{
		_mysteryData.Clear();
		_modificationsMysteryData.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	public int GetElement_MedicineExtraAddPercent(int elementId)
	{
		return _medicineExtraAddPercent[elementId];
	}

	public bool TryGetElement_MedicineExtraAddPercent(int elementId, out int value)
	{
		return _medicineExtraAddPercent.TryGetValue(elementId, out value);
	}

	private void AddElement_MedicineExtraAddPercent(int elementId, int value, DataContext context)
	{
		_medicineExtraAddPercent.Add(elementId, value);
		_modificationsMedicineExtraAddPercent.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	private void SetElement_MedicineExtraAddPercent(int elementId, int value, DataContext context)
	{
		_medicineExtraAddPercent[elementId] = value;
		_modificationsMedicineExtraAddPercent.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_MedicineExtraAddPercent(int elementId, DataContext context)
	{
		_medicineExtraAddPercent.Remove(elementId);
		_modificationsMedicineExtraAddPercent.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	private void ClearMedicineExtraAddPercent(DataContext context)
	{
		_medicineExtraAddPercent.Clear();
		_modificationsMedicineExtraAddPercent.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
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
		archive.WriteSingleValueUnmanaged((ushort)21);
		archive.WriteDomainDataMeta(0);
		archive.WriteObjectCollectionUnmanagedKey(_weapons);
		archive.WriteDomainDataMeta(1);
		archive.WriteObjectCollectionUnmanagedKey(_armors);
		archive.WriteDomainDataMeta(2);
		archive.WriteObjectCollectionUnmanagedKey(_accessories);
		archive.WriteDomainDataMeta(3);
		archive.WriteObjectCollectionUnmanagedKey(_clothing);
		archive.WriteDomainDataMeta(4);
		archive.WriteObjectCollectionUnmanagedKey(_carriers);
		archive.WriteDomainDataMeta(5);
		archive.WriteObjectCollectionUnmanagedKey(_materials);
		archive.WriteDomainDataMeta(6);
		archive.WriteObjectCollectionUnmanagedKey(_craftTools);
		archive.WriteDomainDataMeta(7);
		archive.WriteObjectCollectionUnmanagedKey(_foods);
		archive.WriteDomainDataMeta(8);
		archive.WriteObjectCollectionUnmanagedKey(_medicines);
		archive.WriteDomainDataMeta(9);
		archive.WriteObjectCollectionUnmanagedKey(_teaWines);
		archive.WriteDomainDataMeta(10);
		archive.WriteObjectCollectionUnmanagedKey(_skillBooks);
		archive.WriteDomainDataMeta(11);
		archive.WriteObjectCollectionUnmanagedKey(_crickets);
		archive.WriteDomainDataMeta(12);
		archive.WriteObjectCollectionUnmanagedKey(_misc);
		archive.WriteDomainDataMeta(13);
		archive.WriteSingleValueUnmanaged(_nextItemId);
		archive.WriteDomainDataMeta(14);
		archive.WriteSingleValueCollectionCustomKeyUnmanagedValue(_stackableItems);
		archive.WriteDomainDataMeta(16);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_refinedItems);
		archive.WriteDomainDataMeta(17);
		archive.WriteSingleValueCustom(_emptyHandKey);
		archive.WriteDomainDataMeta(18);
		archive.WriteSingleValueCustom(_branchKey);
		archive.WriteDomainDataMeta(19);
		archive.WriteSingleValueCustom(_stoneKey);
		archive.WriteDomainDataMeta(21);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_mysteryData);
		archive.WriteDomainDataMeta(22);
		archive.WriteSingleValueCollectionUnmanagedKeyValue(_medicineExtraAddPercent);
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
				archive.ReadObjectCollectionUnmanagedKey(_weapons);
				break;
			case 1:
				archive.ReadObjectCollectionUnmanagedKey(_armors);
				break;
			case 2:
				archive.ReadObjectCollectionUnmanagedKey(_accessories);
				break;
			case 3:
				archive.ReadObjectCollectionUnmanagedKey(_clothing);
				break;
			case 4:
				archive.ReadObjectCollectionUnmanagedKey(_carriers);
				break;
			case 5:
				archive.ReadObjectCollectionUnmanagedKey(_materials);
				break;
			case 6:
				archive.ReadObjectCollectionUnmanagedKey(_craftTools);
				break;
			case 7:
				archive.ReadObjectCollectionUnmanagedKey(_foods);
				break;
			case 8:
				archive.ReadObjectCollectionUnmanagedKey(_medicines);
				break;
			case 9:
				archive.ReadObjectCollectionUnmanagedKey(_teaWines);
				break;
			case 10:
				archive.ReadObjectCollectionUnmanagedKey(_skillBooks);
				break;
			case 11:
				archive.ReadObjectCollectionUnmanagedKey(_crickets);
				break;
			case 12:
				archive.ReadObjectCollectionUnmanagedKey(_misc);
				break;
			case 13:
				archive.ReadSingleValueUnmanaged(ref _nextItemId);
				break;
			case 14:
				archive.ReadSingleValueCollectionCustomKeyUnmanagedValue(_stackableItems);
				break;
			case 15:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_poisonItems);
				break;
			case 16:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_refinedItems);
				break;
			case 17:
				archive.ReadSingleValueCustom(ref _emptyHandKey);
				break;
			case 18:
				archive.ReadSingleValueCustom(ref _branchKey);
				break;
			case 19:
				archive.ReadSingleValueCustom(ref _stoneKey);
				break;
			case 21:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_mysteryData);
				break;
			case 22:
				archive.ReadSingleValueCollectionUnmanagedKeyValue(_medicineExtraAddPercent);
				break;
			default:
				throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
			}
			RecordLoadedDomainData(domainDataMeta.DataId);
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(6);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			return GetElementField_Weapons((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 1:
			return GetElementField_Armors((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 2:
			return GetElementField_Accessories((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 3:
			return GetElementField_Clothing((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 4:
			return GetElementField_Carriers((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 5:
			return GetElementField_Materials((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 6:
			return GetElementField_CraftTools((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 7:
			return GetElementField_Foods((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 8:
			return GetElementField_Medicines((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 9:
			return GetElementField_TeaWines((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 10:
			return GetElementField_SkillBooks((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 11:
			return GetElementField_Crickets((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 12:
			return GetElementField_Misc((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 13:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 14:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 15:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 16:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 17:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 18:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 19:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 20:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 21:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 21);
				_modificationsMysteryData.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_mysteryData, dataPool);
		case 22:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 22);
				_modificationsMedicineExtraAddPercent.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_medicineExtraAddPercent, dataPool);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void SetData(ushort dataId, ulong subId0, uint subId1, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		switch (dataId)
		{
		case 0:
			SetElementField_Weapons((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 1:
			SetElementField_Armors((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 2:
			SetElementField_Accessories((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 3:
			SetElementField_Clothing((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 4:
			SetElementField_Carriers((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 5:
			SetElementField_Materials((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 6:
			SetElementField_CraftTools((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 7:
			SetElementField_Foods((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 8:
			SetElementField_Medicines((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 9:
			SetElementField_TeaWines((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 10:
			SetElementField_SkillBooks((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 11:
			SetElementField_Crickets((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 12:
			SetElementField_Misc((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
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
			int argsCount26 = operation.ArgsCount;
			int num26 = argsCount26;
			if (num26 == 2)
			{
				int charId16 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId16);
				ItemDisplayData itemDisplayData = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemDisplayData);
				List<ItemDisplayData> returnValue31 = IdentifyPoisons(context, charId16, itemDisplayData);
				return GameData.Serializer.Serializer.Serialize(returnValue31, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 4)
			{
				short colorId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref colorId);
				short partId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref partId);
				short singLevel = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref singLevel);
				sbyte cricketPlaceId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref cricketPlaceId);
				List<ItemDisplayData> returnValue6 = CatchCricket(context, colorId, partId, singLevel, cricketPlaceId);
				return GameData.Serializer.Serializer.Serialize(returnValue6, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
		{
			int argsCount28 = operation.ArgsCount;
			int num28 = argsCount28;
			if (num28 == 1)
			{
				int itemId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemId3);
				CricketData returnValue37 = GetCricketData(itemId3);
				return GameData.Serializer.Serializer.Serialize(returnValue37, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 3:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 3)
			{
				int itemId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemId);
				bool win = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref win);
				int enemyItemId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref enemyItemId);
				SetCricketRecord(context, itemId, win, enemyItemId);
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
				int itemId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemId2);
				int index = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index);
				short value = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value);
				AddCricketInjury(context, itemId2, index, value);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 5:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 1)
			{
				ItemKey weaponKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref weaponKey);
				List<sbyte> returnValue = GetWeaponTricks(weaponKey);
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 6:
		{
			int argsCount22 = operation.ArgsCount;
			int num22 = argsCount22;
			if (num22 == 1)
			{
				ItemKey cricketKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref cricketKey);
				short[] returnValue28 = GetCricketCombatRecords(cricketKey);
				return GameData.Serializer.Serializer.Serialize(returnValue28, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 7:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				ItemKey itemKey11 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey11);
				ItemDisplayData returnValue20 = GetItemDisplayData(itemKey11);
				return GameData.Serializer.Serializer.Serialize(returnValue20, returnDataPool);
			}
			case 2:
			{
				ItemKey itemKey10 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey10);
				int charId11 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId11);
				ItemDisplayData returnValue19 = GetItemDisplayData(itemKey10, charId11);
				return GameData.Serializer.Serializer.Serialize(returnValue19, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 8:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				List<ItemKey> itemKeyList2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKeyList2);
				List<ItemDisplayData> returnValue12 = GetItemDisplayDataList(itemKeyList2);
				return GameData.Serializer.Serializer.Serialize(returnValue12, returnDataPool);
			}
			case 2:
			{
				List<ItemKey> itemKeyList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKeyList);
				int charId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId6);
				List<ItemDisplayData> returnValue11 = GetItemDisplayDataList(itemKeyList, charId6);
				return GameData.Serializer.Serializer.Serialize(returnValue11, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 9:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 1)
			{
				ItemKey itemKey2 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey2);
				SkillBookPageDisplayData returnValue4 = GetSkillBookPagesInfo(itemKey2);
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 10:
		{
			int argsCount30 = operation.ArgsCount;
			int num30 = argsCount30;
			if (num30 == 1)
			{
				ItemKey itemKey14 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey14);
				int returnValue39 = GetValue(itemKey14);
				return GameData.Serializer.Serializer.Serialize(returnValue39, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 11:
		{
			int argsCount25 = operation.ArgsCount;
			int num25 = argsCount25;
			if (num25 == 1)
			{
				ItemKey itemKey12 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey12);
				int returnValue30 = GetPrice(itemKey12);
				return GameData.Serializer.Serializer.Serialize(returnValue30, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
		{
			int argsCount19 = operation.ArgsCount;
			int num19 = argsCount19;
			if (num19 == 5)
			{
				int charId9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId9);
				ItemKey itemKey9 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey9);
				ItemKey toolKey3 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolKey3);
				sbyte itemSourceType4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSourceType4);
				sbyte toolSourceType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolSourceType);
				List<ItemDisplayData> returnValue15 = DisassembleItem(context, charId9, itemKey9, toolKey3, itemSourceType4, toolSourceType);
				return GameData.Serializer.Serializer.Serialize(returnValue15, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 13:
			switch (operation.ArgsCount)
			{
			case 3:
			{
				int charId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId8);
				ItemKey itemKey8 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey8);
				sbyte itemSourceType3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSourceType3);
				DiscardItem(context, charId8, itemKey8, itemSourceType3);
				return -1;
			}
			case 4:
			{
				int charId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId7);
				ItemKey itemKey7 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey7);
				sbyte itemSourceType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSourceType2);
				int count = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count);
				DiscardItem(context, charId7, itemKey7, itemSourceType2, count);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 14:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 2)
			{
				int charId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId4);
				ItemKey toolKey2 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolKey2);
				List<ItemKey> returnValue7 = GetRepairableItems(context, charId4, toolKey2);
				return GameData.Serializer.Serializer.Serialize(returnValue7, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 15:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 2)
			{
				int charId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId2);
				ItemKey toolKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolKey);
				List<ItemKey> returnValue3 = GetDisassemblableItems(context, charId2, toolKey);
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 16:
		{
			int argsCount31 = operation.ArgsCount;
			int num31 = argsCount31;
			if (num31 == 5)
			{
				int charId21 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId21);
				short changeValue = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref changeValue);
				sbyte itemType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemType);
				short startId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref startId);
				short endId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref endId);
				ChangeDurability(context, charId21, changeValue, itemType, startId, endId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 17:
		{
			int argsCount27 = operation.ArgsCount;
			int num27 = argsCount27;
			if (num27 == 2)
			{
				int charId20 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId20);
				bool isIdentified = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isIdentified);
				ChangePoisonIdentified(context, charId20, isIdentified);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 18:
		{
			int argsCount23 = operation.ArgsCount;
			int num23 = argsCount23;
			if (num23 == 3)
			{
				int charId15 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId15);
				List<ItemKey> keyList2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref keyList2);
				sbyte itemSourceType7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSourceType7);
				DiscardItemList(context, charId15, keyList2, itemSourceType7);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 19:
		{
			int argsCount21 = operation.ArgsCount;
			int num21 = argsCount21;
			if (num21 == 2)
			{
				int charId10 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId10);
				List<MultiplyOperation> operationList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref operationList);
				List<ItemDisplayData> returnValue18 = DisassembleItemList(context, charId10, operationList);
				return GameData.Serializer.Serializer.Serialize(returnValue18, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 20:
		{
			int argsCount17 = operation.ArgsCount;
			int num17 = argsCount17;
			if (num17 == 3)
			{
				sbyte minGrade = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref minGrade);
				sbyte maxGrade = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref maxGrade);
				bool onlyNoInjuryCricket = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref onlyNoInjuryCricket);
				SetCricketBattleConfig(minGrade, maxGrade, onlyNoInjuryCricket);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 21:
		{
			int argsCount14 = operation.ArgsCount;
			int num14 = argsCount14;
			if (num14 == 1)
			{
				List<ItemKey> itemList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemList);
				List<CricketData> returnValue9 = GetCricketDataList(itemList);
				return GameData.Serializer.Serializer.Serialize(returnValue9, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 22:
		{
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 2)
			{
				int charId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId3);
				ItemKey weaponKey2 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref weaponKey2);
				(int, int) returnValue5 = GetWeaponAttackRange(charId3, weaponKey2);
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 23:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 1)
			{
				List<ItemKey> keyList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref keyList);
				bool[] returnValue2 = GetCricketsAliveState(keyList);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 24:
		{
			int argsCount32 = operation.ArgsCount;
			int num32 = argsCount32;
			if (num32 == 3)
			{
				ItemKey itemKey15 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey15);
				List<byte> pageIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref pageIds);
				List<sbyte> directions2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref directions2);
				bool returnValue40 = ModifyCombatSkillBookPageNormal(context, itemKey15, pageIds, directions2);
				return GameData.Serializer.Serializer.Serialize(returnValue40, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 25:
		{
			int argsCount29 = operation.ArgsCount;
			int num29 = argsCount29;
			if (num29 == 2)
			{
				ItemKey itemKey13 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey13);
				sbyte behaviorType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref behaviorType2);
				bool returnValue38 = ModifyCombatSkillBookPageOutline(context, itemKey13, behaviorType2);
				return GameData.Serializer.Serializer.Serialize(returnValue38, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 26:
			if (operation.ArgsCount == 0)
			{
				List<SkillBookModifyDisplayData> returnValue36 = GetTaiwuInventoryCombatSkillBooks();
				return GameData.Serializer.Serializer.Serialize(returnValue36, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 27:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				List<ItemKey> itemKeyList7 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKeyList7);
				List<ItemDisplayData> returnValue35 = GetItemDisplayDataListOptional(itemKeyList7, -1, -1);
				return GameData.Serializer.Serializer.Serialize(returnValue35, returnDataPool);
			}
			case 2:
			{
				List<ItemKey> itemKeyList6 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKeyList6);
				int charId19 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId19);
				List<ItemDisplayData> returnValue34 = GetItemDisplayDataListOptional(itemKeyList6, charId19, -1);
				return GameData.Serializer.Serializer.Serialize(returnValue34, returnDataPool);
			}
			case 3:
			{
				List<ItemKey> itemKeyList5 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKeyList5);
				int charId18 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId18);
				sbyte itemSourceType9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSourceType9);
				List<ItemDisplayData> returnValue33 = GetItemDisplayDataListOptional(itemKeyList5, charId18, itemSourceType9);
				return GameData.Serializer.Serializer.Serialize(returnValue33, returnDataPool);
			}
			case 4:
			{
				List<ItemKey> itemKeyList4 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKeyList4);
				int charId17 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId17);
				sbyte itemSourceType8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSourceType8);
				bool merge2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merge2);
				List<ItemDisplayData> returnValue32 = GetItemDisplayDataListOptional(itemKeyList4, charId17, itemSourceType8, merge2);
				return GameData.Serializer.Serializer.Serialize(returnValue32, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 28:
		{
			int argsCount24 = operation.ArgsCount;
			int num24 = argsCount24;
			if (num24 == 1)
			{
				List<ItemKey> itemKeyList3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKeyList3);
				List<SkillBookPageDisplayData> returnValue29 = GetSkillBookPageDisplayDataList(itemKeyList3);
				return GameData.Serializer.Serializer.Serialize(returnValue29, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 29:
			if (operation.ArgsCount == 0)
			{
				ItemKey returnValue27 = GetEmptyToolKey(context);
				return GameData.Serializer.Serializer.Serialize(returnValue27, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 30:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				Inventory inventory5 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref inventory5);
				List<ItemDisplayData> returnValue26 = GetItemDisplayDataListOptionalFromInventory(inventory5, -1, -1);
				return GameData.Serializer.Serializer.Serialize(returnValue26, returnDataPool);
			}
			case 2:
			{
				Inventory inventory4 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref inventory4);
				int charId14 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId14);
				List<ItemDisplayData> returnValue25 = GetItemDisplayDataListOptionalFromInventory(inventory4, charId14, -1);
				return GameData.Serializer.Serializer.Serialize(returnValue25, returnDataPool);
			}
			case 3:
			{
				Inventory inventory3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref inventory3);
				int charId13 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId13);
				sbyte itemSourceType6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSourceType6);
				List<ItemDisplayData> returnValue24 = GetItemDisplayDataListOptionalFromInventory(inventory3, charId13, itemSourceType6);
				return GameData.Serializer.Serializer.Serialize(returnValue24, returnDataPool);
			}
			case 4:
			{
				Inventory inventory2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref inventory2);
				int charId12 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId12);
				sbyte itemSourceType5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSourceType5);
				bool merge = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merge);
				List<ItemDisplayData> returnValue23 = GetItemDisplayDataListOptionalFromInventory(inventory2, charId12, itemSourceType5, merge);
				return GameData.Serializer.Serializer.Serialize(returnValue23, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 31:
			switch (operation.ArgsCount)
			{
			case 3:
			{
				bool win5 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref win5);
				ItemKey[] taiwuCricketKeys2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref taiwuCricketKeys2);
				short[] durabilityList2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref durabilityList2);
				CricketSettlementResult returnValue22 = SettlementCricketWager(context, win5, taiwuCricketKeys2, durabilityList2);
				return GameData.Serializer.Serializer.Serialize(returnValue22, returnDataPool);
			}
			case 4:
			{
				bool win4 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref win4);
				ItemKey[] taiwuCricketKeys = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref taiwuCricketKeys);
				short[] durabilityList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref durabilityList);
				bool invokeExtraWager2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref invokeExtraWager2);
				CricketSettlementResult returnValue21 = SettlementCricketWager(context, win4, taiwuCricketKeys, durabilityList, invokeExtraWager2);
				return GameData.Serializer.Serializer.Serialize(returnValue21, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 32:
		{
			int argsCount20 = operation.ArgsCount;
			int num20 = argsCount20;
			if (num20 == 1)
			{
				int enemyId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref enemyId);
				GmCmd_StartCricketCombat(context, enemyId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 33:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				bool win3 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref win3);
				CricketSettlementResult returnValue17 = SettlementCricketWagerByGiveUp(context, win3);
				return GameData.Serializer.Serializer.Serialize(returnValue17, returnDataPool);
			}
			case 2:
			{
				bool win2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref win2);
				bool invokeExtraWager = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref invokeExtraWager);
				CricketSettlementResult returnValue16 = SettlementCricketWagerByGiveUp(context, win2, invokeExtraWager);
				return GameData.Serializer.Serializer.Serialize(returnValue16, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 34:
		{
			int argsCount18 = operation.ArgsCount;
			int num18 = argsCount18;
			if (num18 == 1)
			{
				ItemKey itemKey6 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey6);
				MakeCricketRebirth(context, itemKey6);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 35:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				ItemKey itemKey5 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey5);
				int returnValue14 = GetRepairItemNeedResourceCount(itemKey5, -1);
				return GameData.Serializer.Serializer.Serialize(returnValue14, returnDataPool);
			}
			case 2:
			{
				ItemKey itemKey4 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey4);
				short targetDurability = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetDurability);
				int returnValue13 = GetRepairItemNeedResourceCount(itemKey4, targetDurability);
				return GameData.Serializer.Serializer.Serialize(returnValue13, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 36:
		{
			int argsCount16 = operation.ArgsCount;
			int num16 = argsCount16;
			if (num16 == 3)
			{
				ItemKey itemKey3 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey3);
				sbyte behaviorType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref behaviorType);
				List<sbyte> directions = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref directions);
				bool returnValue10 = SetCombatSkillBookPage(context, itemKey3, behaviorType, directions);
				return GameData.Serializer.Serializer.Serialize(returnValue10, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 37:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 2)
			{
				int charId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId5);
				ItemKey weaponKey3 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref weaponKey3);
				int returnValue8 = GetWeaponPrepareFrame(charId5, weaponKey3);
				return GameData.Serializer.Serializer.Serialize(returnValue8, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 38:
		{
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 1)
			{
				int deltaValue = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref deltaValue);
				GmCmd_ChangeAllMysteryCompatibility(context, deltaValue);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 39:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 1)
			{
				int addValue = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref addValue);
				GmCmd_ChangeAllCricketSpirit(context, addValue);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 40:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 2)
			{
				ItemKey itemKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey);
				string name = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref name);
				SetCricketName(context, itemKey, name);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 41:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 3)
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				Inventory inventory = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref inventory);
				sbyte itemSourceType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemSourceType);
				DiscardItemInventory(context, charId, inventory, itemSourceType);
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
			_modificationsMysteryData.ChangeRecording(monitoring);
			break;
		case 22:
			_modificationsMedicineExtraAddPercent.ChangeRecording(monitoring);
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
			return CheckModified_Weapons((int)subId0, (ushort)subId1, dataPool);
		case 1:
			return CheckModified_Armors((int)subId0, (ushort)subId1, dataPool);
		case 2:
			return CheckModified_Accessories((int)subId0, (ushort)subId1, dataPool);
		case 3:
			return CheckModified_Clothing((int)subId0, (ushort)subId1, dataPool);
		case 4:
			return CheckModified_Carriers((int)subId0, (ushort)subId1, dataPool);
		case 5:
			return CheckModified_Materials((int)subId0, (ushort)subId1, dataPool);
		case 6:
			return CheckModified_CraftTools((int)subId0, (ushort)subId1, dataPool);
		case 7:
			return CheckModified_Foods((int)subId0, (ushort)subId1, dataPool);
		case 8:
			return CheckModified_Medicines((int)subId0, (ushort)subId1, dataPool);
		case 9:
			return CheckModified_TeaWines((int)subId0, (ushort)subId1, dataPool);
		case 10:
			return CheckModified_SkillBooks((int)subId0, (ushort)subId1, dataPool);
		case 11:
			return CheckModified_Crickets((int)subId0, (ushort)subId1, dataPool);
		case 12:
			return CheckModified_Misc((int)subId0, (ushort)subId1, dataPool);
		case 13:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 14:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 15:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 16:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 17:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 18:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 19:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 20:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 21:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 21))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 21);
			int offset2 = GameData.Serializer.Serializer.SerializeModifications(_mysteryData, dataPool, _modificationsMysteryData);
			_modificationsMysteryData.Reset();
			return offset2;
		}
		case 22:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 22))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 22);
			int offset = GameData.Serializer.Serializer.SerializeModifications(_medicineExtraAddPercent, dataPool, _modificationsMedicineExtraAddPercent);
			_modificationsMedicineExtraAddPercent.Reset();
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
			ResetModifiedWrapper_Weapons((int)subId0, (ushort)subId1);
			break;
		case 1:
			ResetModifiedWrapper_Armors((int)subId0, (ushort)subId1);
			break;
		case 2:
			ResetModifiedWrapper_Accessories((int)subId0, (ushort)subId1);
			break;
		case 3:
			ResetModifiedWrapper_Clothing((int)subId0, (ushort)subId1);
			break;
		case 4:
			ResetModifiedWrapper_Carriers((int)subId0, (ushort)subId1);
			break;
		case 5:
			ResetModifiedWrapper_Materials((int)subId0, (ushort)subId1);
			break;
		case 6:
			ResetModifiedWrapper_CraftTools((int)subId0, (ushort)subId1);
			break;
		case 7:
			ResetModifiedWrapper_Foods((int)subId0, (ushort)subId1);
			break;
		case 8:
			ResetModifiedWrapper_Medicines((int)subId0, (ushort)subId1);
			break;
		case 9:
			ResetModifiedWrapper_TeaWines((int)subId0, (ushort)subId1);
			break;
		case 10:
			ResetModifiedWrapper_SkillBooks((int)subId0, (ushort)subId1);
			break;
		case 11:
			ResetModifiedWrapper_Crickets((int)subId0, (ushort)subId1);
			break;
		case 12:
			ResetModifiedWrapper_Misc((int)subId0, (ushort)subId1);
			break;
		case 13:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 14:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 15:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 16:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 17:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 18:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 19:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 20:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 21:
			if (BaseGameDataDomain.IsModified(DataStates, 21))
			{
				BaseGameDataDomain.ResetModified(DataStates, 21);
				_modificationsMysteryData.Reset();
			}
			break;
		case 22:
			if (BaseGameDataDomain.IsModified(DataStates, 22))
			{
				BaseGameDataDomain.ResetModified(DataStates, 22);
				_modificationsMedicineExtraAddPercent.Reset();
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
			0 => IsModifiedWrapper_Weapons((int)subId0, (ushort)subId1), 
			1 => IsModifiedWrapper_Armors((int)subId0, (ushort)subId1), 
			2 => IsModifiedWrapper_Accessories((int)subId0, (ushort)subId1), 
			3 => IsModifiedWrapper_Clothing((int)subId0, (ushort)subId1), 
			4 => IsModifiedWrapper_Carriers((int)subId0, (ushort)subId1), 
			5 => IsModifiedWrapper_Materials((int)subId0, (ushort)subId1), 
			6 => IsModifiedWrapper_CraftTools((int)subId0, (ushort)subId1), 
			7 => IsModifiedWrapper_Foods((int)subId0, (ushort)subId1), 
			8 => IsModifiedWrapper_Medicines((int)subId0, (ushort)subId1), 
			9 => IsModifiedWrapper_TeaWines((int)subId0, (ushort)subId1), 
			10 => IsModifiedWrapper_SkillBooks((int)subId0, (ushort)subId1), 
			11 => IsModifiedWrapper_Crickets((int)subId0, (ushort)subId1), 
			12 => IsModifiedWrapper_Misc((int)subId0, (ushort)subId1), 
			13 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			14 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			15 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			16 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			17 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			18 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			19 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			20 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			21 => BaseGameDataDomain.IsModified(DataStates, 21), 
			22 => BaseGameDataDomain.IsModified(DataStates, 22), 
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
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _weapons, influencedObjects2))
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
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesWeapons, _dataStatesWeapons, influence, context);
				}
				influencedObjects2.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects2);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesWeapons, _dataStatesWeapons, influence, context);
			}
			break;
		case 1:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects4 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _armors, influencedObjects4))
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
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesArmors, _dataStatesArmors, influence, context);
				}
				influencedObjects4.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects4);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesArmors, _dataStatesArmors, influence, context);
			}
			break;
		case 2:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects9 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _accessories, influencedObjects9))
				{
					int influencedObjectsCount9 = influencedObjects9.Count;
					for (int num11 = 0; num11 < influencedObjectsCount9; num11++)
					{
						BaseGameDataObject targetObject9 = influencedObjects9[num11];
						List<DataUid> targetUids9 = influence.TargetUids;
						int targetUidsCount9 = targetUids9.Count;
						for (int num12 = 0; num12 < targetUidsCount9; num12++)
						{
							targetObject9.InvalidateSelfAndInfluencedCache((ushort)targetUids9[num12].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesAccessories, _dataStatesAccessories, influence, context);
				}
				influencedObjects9.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects9);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesAccessories, _dataStatesAccessories, influence, context);
			}
			break;
		case 3:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects5 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _clothing, influencedObjects5))
				{
					int influencedObjectsCount5 = influencedObjects5.Count;
					for (int num3 = 0; num3 < influencedObjectsCount5; num3++)
					{
						BaseGameDataObject targetObject5 = influencedObjects5[num3];
						List<DataUid> targetUids5 = influence.TargetUids;
						int targetUidsCount5 = targetUids5.Count;
						for (int num4 = 0; num4 < targetUidsCount5; num4++)
						{
							targetObject5.InvalidateSelfAndInfluencedCache((ushort)targetUids5[num4].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesClothing, _dataStatesClothing, influence, context);
				}
				influencedObjects5.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects5);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesClothing, _dataStatesClothing, influence, context);
			}
			break;
		case 4:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects12 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _carriers, influencedObjects12))
				{
					int influencedObjectsCount12 = influencedObjects12.Count;
					for (int num17 = 0; num17 < influencedObjectsCount12; num17++)
					{
						BaseGameDataObject targetObject12 = influencedObjects12[num17];
						List<DataUid> targetUids12 = influence.TargetUids;
						int targetUidsCount12 = targetUids12.Count;
						for (int num18 = 0; num18 < targetUidsCount12; num18++)
						{
							targetObject12.InvalidateSelfAndInfluencedCache((ushort)targetUids12[num18].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCarriers, _dataStatesCarriers, influence, context);
				}
				influencedObjects12.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects12);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCarriers, _dataStatesCarriers, influence, context);
			}
			break;
		case 5:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects11 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _materials, influencedObjects11))
				{
					int influencedObjectsCount11 = influencedObjects11.Count;
					for (int num15 = 0; num15 < influencedObjectsCount11; num15++)
					{
						BaseGameDataObject targetObject11 = influencedObjects11[num15];
						List<DataUid> targetUids11 = influence.TargetUids;
						int targetUidsCount11 = targetUids11.Count;
						for (int num16 = 0; num16 < targetUidsCount11; num16++)
						{
							targetObject11.InvalidateSelfAndInfluencedCache((ushort)targetUids11[num16].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesMaterials, _dataStatesMaterials, influence, context);
				}
				influencedObjects11.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects11);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesMaterials, _dataStatesMaterials, influence, context);
			}
			break;
		case 6:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects10 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _craftTools, influencedObjects10))
				{
					int influencedObjectsCount10 = influencedObjects10.Count;
					for (int num13 = 0; num13 < influencedObjectsCount10; num13++)
					{
						BaseGameDataObject targetObject10 = influencedObjects10[num13];
						List<DataUid> targetUids10 = influence.TargetUids;
						int targetUidsCount10 = targetUids10.Count;
						for (int num14 = 0; num14 < targetUidsCount10; num14++)
						{
							targetObject10.InvalidateSelfAndInfluencedCache((ushort)targetUids10[num14].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCraftTools, _dataStatesCraftTools, influence, context);
				}
				influencedObjects10.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects10);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCraftTools, _dataStatesCraftTools, influence, context);
			}
			break;
		case 7:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects6 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _foods, influencedObjects6))
				{
					int influencedObjectsCount6 = influencedObjects6.Count;
					for (int num5 = 0; num5 < influencedObjectsCount6; num5++)
					{
						BaseGameDataObject targetObject6 = influencedObjects6[num5];
						List<DataUid> targetUids6 = influence.TargetUids;
						int targetUidsCount6 = targetUids6.Count;
						for (int num6 = 0; num6 < targetUidsCount6; num6++)
						{
							targetObject6.InvalidateSelfAndInfluencedCache((ushort)targetUids6[num6].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesFoods, _dataStatesFoods, influence, context);
				}
				influencedObjects6.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects6);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesFoods, _dataStatesFoods, influence, context);
			}
			break;
		case 8:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects3 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _medicines, influencedObjects3))
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
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesMedicines, _dataStatesMedicines, influence, context);
				}
				influencedObjects3.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects3);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesMedicines, _dataStatesMedicines, influence, context);
			}
			break;
		case 9:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects13 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _teaWines, influencedObjects13))
				{
					int influencedObjectsCount13 = influencedObjects13.Count;
					for (int num19 = 0; num19 < influencedObjectsCount13; num19++)
					{
						BaseGameDataObject targetObject13 = influencedObjects13[num19];
						List<DataUid> targetUids13 = influence.TargetUids;
						int targetUidsCount13 = targetUids13.Count;
						for (int num20 = 0; num20 < targetUidsCount13; num20++)
						{
							targetObject13.InvalidateSelfAndInfluencedCache((ushort)targetUids13[num20].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesTeaWines, _dataStatesTeaWines, influence, context);
				}
				influencedObjects13.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects13);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesTeaWines, _dataStatesTeaWines, influence, context);
			}
			break;
		case 10:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects7 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _skillBooks, influencedObjects7))
				{
					int influencedObjectsCount7 = influencedObjects7.Count;
					for (int num7 = 0; num7 < influencedObjectsCount7; num7++)
					{
						BaseGameDataObject targetObject7 = influencedObjects7[num7];
						List<DataUid> targetUids7 = influence.TargetUids;
						int targetUidsCount7 = targetUids7.Count;
						for (int num8 = 0; num8 < targetUidsCount7; num8++)
						{
							targetObject7.InvalidateSelfAndInfluencedCache((ushort)targetUids7[num8].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesSkillBooks, _dataStatesSkillBooks, influence, context);
				}
				influencedObjects7.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects7);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesSkillBooks, _dataStatesSkillBooks, influence, context);
			}
			break;
		case 11:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects8 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _crickets, influencedObjects8))
				{
					int influencedObjectsCount8 = influencedObjects8.Count;
					for (int num9 = 0; num9 < influencedObjectsCount8; num9++)
					{
						BaseGameDataObject targetObject8 = influencedObjects8[num9];
						List<DataUid> targetUids8 = influence.TargetUids;
						int targetUidsCount8 = targetUids8.Count;
						for (int num10 = 0; num10 < targetUidsCount8; num10++)
						{
							targetObject8.InvalidateSelfAndInfluencedCache((ushort)targetUids8[num10].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCrickets, _dataStatesCrickets, influence, context);
				}
				influencedObjects8.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects8);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCrickets, _dataStatesCrickets, influence, context);
			}
			break;
		case 12:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _misc, influencedObjects))
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
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesMisc, _dataStatesMisc, influence, context);
				}
				influencedObjects.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesMisc, _dataStatesMisc, influence, context);
			}
			break;
		default:
			throw new Exception($"Unsupported dataId {influence.TargetIndicator.DataId}");
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
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
		foreach (KeyValuePair<int, Weapon> weapon in _weapons)
		{
			Weapon instance = weapon.Value;
			instance.CollectionHelperData = HelperDataWeapons;
			instance.DataStatesOffset = _dataStatesWeapons.Create();
		}
		foreach (KeyValuePair<int, Armor> armor in _armors)
		{
			Armor instance2 = armor.Value;
			instance2.CollectionHelperData = HelperDataArmors;
			instance2.DataStatesOffset = _dataStatesArmors.Create();
		}
		foreach (KeyValuePair<int, Accessory> accessory in _accessories)
		{
			Accessory instance3 = accessory.Value;
			instance3.CollectionHelperData = HelperDataAccessories;
			instance3.DataStatesOffset = _dataStatesAccessories.Create();
		}
		foreach (KeyValuePair<int, Clothing> item in _clothing)
		{
			Clothing instance4 = item.Value;
			instance4.CollectionHelperData = HelperDataClothing;
			instance4.DataStatesOffset = _dataStatesClothing.Create();
		}
		foreach (KeyValuePair<int, Carrier> carrier in _carriers)
		{
			Carrier instance5 = carrier.Value;
			instance5.CollectionHelperData = HelperDataCarriers;
			instance5.DataStatesOffset = _dataStatesCarriers.Create();
		}
		foreach (KeyValuePair<int, Material> material in _materials)
		{
			Material instance6 = material.Value;
			instance6.CollectionHelperData = HelperDataMaterials;
			instance6.DataStatesOffset = _dataStatesMaterials.Create();
		}
		foreach (KeyValuePair<int, CraftTool> craftTool in _craftTools)
		{
			CraftTool instance7 = craftTool.Value;
			instance7.CollectionHelperData = HelperDataCraftTools;
			instance7.DataStatesOffset = _dataStatesCraftTools.Create();
		}
		foreach (KeyValuePair<int, Food> food in _foods)
		{
			Food instance8 = food.Value;
			instance8.CollectionHelperData = HelperDataFoods;
			instance8.DataStatesOffset = _dataStatesFoods.Create();
		}
		foreach (KeyValuePair<int, Medicine> medicine in _medicines)
		{
			Medicine instance9 = medicine.Value;
			instance9.CollectionHelperData = HelperDataMedicines;
			instance9.DataStatesOffset = _dataStatesMedicines.Create();
		}
		foreach (KeyValuePair<int, TeaWine> teaWine in _teaWines)
		{
			TeaWine instance10 = teaWine.Value;
			instance10.CollectionHelperData = HelperDataTeaWines;
			instance10.DataStatesOffset = _dataStatesTeaWines.Create();
		}
		foreach (KeyValuePair<int, SkillBook> skillBook in _skillBooks)
		{
			SkillBook instance11 = skillBook.Value;
			instance11.CollectionHelperData = HelperDataSkillBooks;
			instance11.DataStatesOffset = _dataStatesSkillBooks.Create();
		}
		foreach (KeyValuePair<int, Cricket> cricket in _crickets)
		{
			Cricket instance12 = cricket.Value;
			instance12.CollectionHelperData = HelperDataCrickets;
			instance12.DataStatesOffset = _dataStatesCrickets.Create();
		}
		foreach (KeyValuePair<int, Misc> item2 in _misc)
		{
			Misc instance13 = item2.Value;
			instance13.CollectionHelperData = HelperDataMisc;
			instance13.DataStatesOffset = _dataStatesMisc.Create();
		}
	}
}
