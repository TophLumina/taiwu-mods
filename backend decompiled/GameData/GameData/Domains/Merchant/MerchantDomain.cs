using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.ConfigCells;
using GameData.Achievement;
using GameData.ArchiveData;
using GameData.Common;
using GameData.DLC.FiveLoong;
using GameData.Dependencies;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.Extra;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Organization.Display;
using GameData.Domains.Taiwu.ExchangeSystem;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.Taiwu.VillagerRole;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.Notification;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using NLog;

namespace GameData.Domains.Merchant;

[GameDataDomain(14)]
public class MerchantDomain : BaseGameDataDomain
{
	private class SkillBookTradeInfo
	{
		public int CharId;

		public List<ItemKey> PrivateSkillBooks;

		public List<ItemKey> SectSkillBooks;

		public List<ItemKey> BoughtBooksFromTaiwu;

		public List<ItemKey> SoldBooksToTaiwu;

		public SkillBookTradeInfo(int charId)
		{
			CharId = charId;
			PrivateSkillBooks = new List<ItemKey>();
			SectSkillBooks = new List<ItemKey>();
			BoughtBooksFromTaiwu = new List<ItemKey>();
			SoldBooksToTaiwu = new List<ItemKey>();
		}
	}

	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<int, MerchantData> _merchantData;

	[DomainData(DomainDataType.SingleValue, true, false, true, true, ArrayElementsCount = 7)]
	private int[] _merchantFavorability;

	[DomainData(DomainDataType.SingleValue, true, false, true, true, ArrayElementsCount = 7)]
	private int[] _merchantMoney;

	[DomainData(DomainDataType.ElementList, true, false, true, true, ArrayElementsCount = 7)]
	private MerchantData[] _merchantMaxLevelData;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<int, MerchantExpData> _merchantExpData;

	public const int MaxFavorability = 100;

	private SkillBookTradeInfo _skillBookTradeInfo;

	private readonly Dictionary<int, MerchantBuyBackData> _merchantBuyBackData = new Dictionary<int, MerchantBuyBackData>();

	private readonly Dictionary<int, MerchantBuyBackData> _caravanBuyBackData = new Dictionary<int, MerchantBuyBackData>();

	private readonly MerchantBuyBackData[] _merchantMaxLevelBuyBackData = new MerchantBuyBackData[7];

	private readonly MerchantBuyBackData[] _branchMerchantBuyBackData = new MerchantBuyBackData[7];

	private MerchantBuyBackData _tempMerchantBuyBackData;

	private MerchantBuyBackData _sectStorySpecialMerchantBuyBackData;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private int _nextCaravanId;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<int, MerchantData> _caravanData;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<int, CaravanPath> _caravanDict;

	private const short CaravanStayDaysInTaiwuVillage = 90;

	private MerchantData _tempMerchantData;

	private int _totalBuyMoney;

	private int _totalSoldMoney;

	public const int TempCaravanId = -1;

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[8][];

	private static readonly DataInfluence[][] CacheInfluencesMerchantMaxLevelData = new DataInfluence[7][];

	private readonly byte[] _dataStatesMerchantMaxLevelData = new byte[2];

	private Queue<uint> _pendingLoadingOperationIds;

	private void OnInitializedDomainData()
	{
	}

	private void InitializeOnInitializeGameDataModule()
	{
	}

	private void InitializeOnEnterNewWorld()
	{
		DataContext context = DataContextManager.GetCurrentThreadDataContext();
		InitMerchantMoney(context);
	}

	private void OnLoadedArchiveData()
	{
	}

	public void OnPostAdvanceMonth(DataContext context)
	{
		DomainManager.Merchant.GenTradeCaravansOnAdvanceMonth(context);
		DomainManager.Merchant.CaravanMonthEvent(context);
		DomainManager.Merchant.UpdateCaravansMove(context);
	}

	public void SetMerchantData(int charId, MerchantData merchantData, DataContext context)
	{
		SetElement_MerchantData(charId, merchantData, context);
	}

	[DomainMethod]
	public MerchantData GetMerchantData(DataContext context, int charId)
	{
		if (!_merchantData.TryGetValue(charId, out var data))
		{
			data = CreateMerchantData(context, charId);
		}
		else
		{
			DomainManager.Extra.TryGetMerchantCharToType(charId, out var merchantType);
			sbyte merchantType2 = data.MerchantType;
			bool flag = (uint)(merchantType2 - 7) <= 1u;
			bool isSpecial = flag;
			if (isSpecial)
			{
				merchantType = data.MerchantType;
			}
			if (charId >= 0)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				short templateId = character.Template.TemplateId;
				if (templateId >= 959 && templateId <= 965)
				{
					merchantType = data.MerchantType;
				}
			}
			bool isTypeChanged = data.MerchantType != merchantType;
			MerchantExpData merchantExpData;
			bool isLevelChanged = !isSpecial && TryGetMerchantExpData(charId, out merchantExpData) && data.MerchantLevel != merchantExpData.GetMerchantLevel(merchantType);
			if (isTypeChanged || isLevelChanged)
			{
				RemoveMerchantData(context, charId);
				data = CreateMerchantData(context, charId);
			}
			else
			{
				data.Money = GetMerchantMoney(context, merchantType);
			}
			DomainManager.Extra.TryGetMerchantExtraGoods(charId, out var merchantExtraGoods);
			sbyte oldSeason = merchantExtraGoods?.SeasonTemplateId ?? (-1);
			if (oldSeason != EventHelper.GetCurrSeason())
			{
				data.RefreshSeasonExtraGoods(context, charId);
				SetMerchantData(charId, data, context);
			}
		}
		return data;
	}

	public int GetMerchantMoney(DataContext context, sbyte merchantType)
	{
		if (!_merchantMoney.CheckIndex(merchantType))
		{
			return 0;
		}
		int money = _merchantMoney[merchantType];
		if (money < 0)
		{
			money = 0;
			SetMerchantMoney(context, merchantType, money);
		}
		return money;
	}

	public int SetMerchantMoney(DataContext context, sbyte merchantType, int money)
	{
		if (!_merchantMoney.CheckIndex(merchantType))
		{
			return 0;
		}
		_merchantMoney[merchantType] = money;
		SetMerchantMoney(_merchantMoney, context);
		return money;
	}

	[DomainMethod]
	public void SettleTrade(DataContext context, MerchantTradeArguments merchantTradeArguments)
	{
		Dictionary<ItemKey, long> tradeMoneySources = merchantTradeArguments.TradeMoneySources;
		sbyte buildingMerchantType = merchantTradeArguments.OpenShopEventArguments.BuildingMerchantType;
		int buildingMerchantCaravanId = SharedMethods.GetBuildingMerchantCaravanId(buildingMerchantType, merchantTradeArguments.OpenShopEventArguments.IsHeadBuildingMerchant);
		long buyMoney = merchantTradeArguments.BuyMoney;
		long soldMoney = merchantTradeArguments.SoldMoney;
		List<ItemSourceChange> itemChangeList = merchantTradeArguments.ItemChangeList;
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int merchantId = merchantTradeArguments.OpenShopEventArguments.Id;
		MerchantData merchantData = merchantTradeArguments.MerchantData;
		MerchantExtraGoodsData extraGoods = DomainManager.Extra.GetMerchantExtraGoods(merchantId);
		bool isDebtAreaShop = merchantData.MerchantTemplateId == 53;
		foreach (ItemSourceChange change in itemChangeList)
		{
			foreach (ItemKeyAndCount item2 in change.Items)
			{
				item2.Deconstruct(out var itemKey, out var count);
				ItemKey itemKey2 = itemKey;
				int count2 = count;
				ItemBase item = DomainManager.Item.GetBaseItem(itemKey2);
				int priceChange = change.PriceChanges[itemKey2];
				if (count2 > 0)
				{
					if (merchantData.CharId >= 0)
					{
						item.RemoveOwner(ItemOwnerType.Merchant, merchantData.CharId);
					}
					else if (merchantTradeArguments.OpenShopEventArguments.IsFromBuilding)
					{
						item.RemoveOwner(ItemOwnerType.BuildingMerchant, buildingMerchantCaravanId);
					}
					else if (merchantTradeArguments.OpenShopEventArguments.IsSpecialBuilding)
					{
						item.RemoveOwner(ItemOwnerType.BuildingMerchant, -1);
					}
					else
					{
						item.RemoveOwner(ItemOwnerType.Caravan, merchantId);
					}
					if (ModificationStateHelper.IsActive(item.GetModificationState(), 8))
					{
						extraGoods?.Remove(itemKey2.Id);
						if (ItemTemplateHelper.IsStackable(itemKey2.ItemType, itemKey2.TemplateId))
						{
							DomainManager.Item.RemoveItem(context, itemKey2);
							ItemKey newItemKey = DomainManager.Item.CreateItem(context, itemKey2.ItemType, itemKey2.TemplateId);
							DomainManager.Taiwu.AddItem(context, newItemKey, count2, change.ItemSourceType);
						}
						else
						{
							DomainManager.Taiwu.AddItem(context, itemKey2, count2, change.ItemSourceType);
						}
					}
					else
					{
						DomainManager.Taiwu.AddItem(context, itemKey2, count2, change.ItemSourceType);
					}
					if (priceChange < 0)
					{
						int value = item.GetValue();
						int seniority = ProfessionFormulaImpl.Calculate(96, value) * Math.Abs(count2);
						DomainManager.Extra.ChangeProfessionSeniority(context, 15, seniority);
					}
				}
				else if (count2 < 0)
				{
					DomainManager.Taiwu.RemoveItem(context, itemKey2, -count2, change.ItemSourceType, deleteItem: false);
					if (merchantData.CharId >= 0)
					{
						item.SetOwner(ItemOwnerType.Merchant, merchantData.CharId);
					}
					else if (merchantTradeArguments.OpenShopEventArguments.IsFromBuilding)
					{
						item.SetOwner(ItemOwnerType.BuildingMerchant, buildingMerchantCaravanId);
					}
					else if (merchantTradeArguments.OpenShopEventArguments.IsSpecialBuilding)
					{
						item.SetOwner(ItemOwnerType.BuildingMerchant, -1);
					}
					else
					{
						item.SetOwner(ItemOwnerType.Caravan, merchantId);
					}
					if (priceChange > 0)
					{
						int value2 = item.GetValue();
						int seniority2 = ProfessionFormulaImpl.Calculate(97, value2) * Math.Abs(count2);
						DomainManager.Extra.ChangeProfessionSeniority(context, 15, seniority2);
					}
				}
			}
		}
		if (extraGoods != null)
		{
			DomainManager.Extra.SetMerchantExtraGoods(context, merchantId, extraGoods);
		}
		MerchantBuyBackData oldBuyBackData = GetMerchantBuyBackData(merchantTradeArguments.OpenShopEventArguments);
		SetMerchantBuyBackData(merchantTradeArguments.OpenShopEventArguments, merchantTradeArguments.MerchantBuyBackData);
		long handledValue = tradeMoneySources.Values.Sum();
		long merchantReduceMoney = ((handledValue > 0) ? Math.Min(handledValue, merchantData.Money) : handledValue);
		switch (merchantTradeArguments.OpenShopEventArguments.MerchantSourceTypeEnum)
		{
		case OpenShopEventArguments.EMerchantSourceType.NormalCharacter:
		case OpenShopEventArguments.EMerchantSourceType.SpecifiedOnBuildingMerchantType:
			if (merchantData.CharId >= 0)
			{
				int realMoney3 = HandleMerchantMoney();
				HandleHeadMoney(realMoney3);
				SetElement_MerchantData(merchantData.CharId, merchantData, context);
				_totalBuyMoney = (int)Math.Min(_totalBuyMoney + buyMoney, 2147483647L);
				_totalSoldMoney = (int)Math.Min(_totalSoldMoney + soldMoney, 2147483647L);
				DomainManager.TaiwuEvent.SetListenerEventActionIntArg("ShopActionComplete", "ConchShip_PresetKey_ShopBuyMoney", _totalBuyMoney);
				DomainManager.TaiwuEvent.SetListenerEventActionIntArg("ShopActionComplete", "ConchShip_PresetKey_ShopSoldMoney", _totalSoldMoney);
			}
			break;
		case OpenShopEventArguments.EMerchantSourceType.NormalCaravan:
		case OpenShopEventArguments.EMerchantSourceType.SingleAdventureCaravan:
		case OpenShopEventArguments.EMerchantSourceType.ProfessionSkillCaravan:
		{
			MerchantData value3;
			if (merchantId > -1)
			{
				handledValue = HandleMerchantMoney();
				SetElement_CaravanData(merchantId, merchantData, context);
			}
			else if (merchantId == -1 && TryGetElement_CaravanData(-1, out value3))
			{
				int realMoney4 = HandleMerchantMoney();
				HandleHeadMoney(realMoney4);
				SetElement_CaravanData(merchantId, merchantData, context);
				_totalBuyMoney = (int)Math.Min(_totalBuyMoney + buyMoney, 2147483647L);
				_totalSoldMoney = (int)Math.Min(_totalSoldMoney + soldMoney, 2147483647L);
				DomainManager.TaiwuEvent.SetListenerEventActionIntArg("ShopActionComplete", "ConchShip_PresetKey_ShopBuyMoney", _totalBuyMoney);
				DomainManager.TaiwuEvent.SetListenerEventActionIntArg("ShopActionComplete", "ConchShip_PresetKey_ShopSoldMoney", _totalSoldMoney);
			}
			break;
		}
		case OpenShopEventArguments.EMerchantSourceType.MerchantHeadBuilding:
		case OpenShopEventArguments.EMerchantSourceType.MerchantBranchBuilding:
			if (buildingMerchantType > -1)
			{
				int realMoney2 = HandleMerchantMoney();
				HandleHeadMoney(realMoney2);
				if (merchantTradeArguments.OpenShopEventArguments.IsHeadBuildingMerchant)
				{
					SetElement_MerchantMaxLevelData(buildingMerchantType, merchantData, context);
				}
				else
				{
					DomainManager.Extra.SetBranchMerchantData(context, buildingMerchantType, merchantData);
				}
			}
			break;
		case OpenShopEventArguments.EMerchantSourceType.SpecialBuilding:
		{
			int realMoney = HandleMerchantMoney();
			HandleHeadMoney(realMoney);
			SetSectStorySpecialMerchantData(context, merchantData);
			break;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
		DomainManager.TaiwuEvent.SetListenerEventActionBoolArg("ShopActionComplete", "ConchShip_PresetKey_ShopHasAnyTrade", value: true);
		DomainManager.TaiwuEvent.SetListenerEventActionBoolArg("MerchantShopClose", "ConchShip_PresetKey_ShopHasAnyTrade", value: true);
		if (isDebtAreaShop)
		{
			DomainManager.Extra.ChangeAreaSpiritualDebt(context, taiwu.GetLocation().AreaId, (int)Math.Min(2147483647L, handledValue));
		}
		else
		{
			taiwu.ChangeResource(context, 6, (int)Math.Min(2147483647L, merchantReduceMoney));
		}
		if (buyMoney > 0)
		{
			ChangeMerchantCumulativeMoney(context, merchantData.MerchantType, (int)Math.Min(2147483647L, buyMoney));
		}
		DomainManager.Extra.SetMerchantOverFavorData(context, merchantData.MerchantType, merchantTradeArguments.OverFavorData);
		void HandleHeadMoney(int argTradeMoney)
		{
			if (!isDebtAreaShop)
			{
				int money = GetMerchantMoney(context, merchantData.MerchantType);
				money -= argTradeMoney;
				SetMerchantMoney(context, merchantData.MerchantType, money);
			}
		}
		int HandleMerchantMoney()
		{
			if (isDebtAreaShop)
			{
				return (int)Math.Min(2147483647L, tradeMoneySources.Values.Sum());
			}
			if (merchantData.CharId >= 0)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(merchantData.CharId);
				int totalTradeMoney = 0;
				ICollection<ItemKey> collection2;
				if (oldBuyBackData?.BuyInGoodsList.Items == null)
				{
					ICollection<ItemKey> collection = Array.Empty<ItemKey>();
					collection2 = collection;
				}
				else
				{
					ICollection<ItemKey> collection = oldBuyBackData.BuyInGoodsList.Items.Keys;
					collection2 = collection;
				}
				ICollection<ItemKey> oldBuyBackList = collection2;
				ICollection<ItemKey> collection3;
				if (merchantTradeArguments.MerchantBuyBackData?.BuyInGoodsList.Items == null)
				{
					ICollection<ItemKey> collection = Array.Empty<ItemKey>();
					collection3 = collection;
				}
				else
				{
					ICollection<ItemKey> collection = merchantTradeArguments.MerchantBuyBackData.BuyInGoodsList.Items.Keys;
					collection3 = collection;
				}
				ICollection<ItemKey> currentBuyBackList = collection3;
				List<ItemKey> list = tradeMoneySources.Keys.OrderBy((ItemKey k) => tradeMoneySources[k]).ToList();
				foreach (ItemKey itemKey3 in list)
				{
					long tradeMoney = tradeMoneySources[itemKey3];
					bool isBuyBack = oldBuyBackList.Contains(itemKey3) && !currentBuyBackList.Contains(itemKey3);
					if (tradeMoney < 0 && !isBuyBack)
					{
						int personalMoney = -(int)tradeMoney * 20 / 100;
						int publicMoney = -(int)tradeMoney - personalMoney;
						character.ChangeResource(context, 6, personalMoney);
						merchantData.Money += publicMoney;
						totalTradeMoney -= publicMoney;
					}
					else
					{
						long realTradeMoney = merchantData.Money - Math.Max(merchantData.Money - tradeMoney, 0L);
						merchantData.Money -= (int)realTradeMoney;
						totalTradeMoney += (int)tradeMoney;
					}
				}
				return totalTradeMoney;
			}
			int tradeMoney2 = (int)Math.Min(tradeMoneySources.Values.Sum(), merchantData.Money);
			merchantData.Money -= tradeMoney2;
			return tradeMoney2;
		}
	}

	public void ChangeMerchantCumulativeMoney(DataContext context, sbyte merchantType, int delta)
	{
		int limitCumulativeMoney = GetCumulativeMoney(100);
		if (delta > 0)
		{
			delta = Math.Clamp(delta, 0, limitCumulativeMoney);
		}
		if (delta > 0 && DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(63))
		{
			delta *= 3;
		}
		int[] favorabilityList = DomainManager.Merchant.GetMerchantFavorability();
		if (!favorabilityList.CheckIndex(merchantType))
		{
			return;
		}
		int curCumulativeMoney = favorabilityList[merchantType] + delta;
		curCumulativeMoney = (favorabilityList[merchantType] = Math.Clamp(curCumulativeMoney, 0, limitCumulativeMoney));
		DomainManager.Merchant.SetMerchantFavorability(favorabilityList, context);
		if (curCumulativeMoney == limitCumulativeMoney)
		{
			if (1 == 0)
			{
			}
			short num = merchantType switch
			{
				0 => 17, 
				1 => 18, 
				2 => 19, 
				3 => 20, 
				4 => 21, 
				5 => 22, 
				6 => 23, 
				_ => throw new ArgumentOutOfRangeException("merchantType", merchantType, null), 
			};
			if (1 == 0)
			{
			}
			short key = num;
			AchievementManager.RequestSetStat(context, key, 1);
		}
	}

	[Obsolete]
	public void ChangeMerchantFavorability(DataContext context, sbyte merchantType, int delta)
	{
		int[] favorabilityList = DomainManager.Merchant.GetMerchantFavorability();
		int curFavorability = DomainManager.Merchant.GetFavorability(favorabilityList[merchantType]) + delta;
		curFavorability = Math.Clamp(curFavorability, 0, 100);
		int curMoney = DomainManager.Merchant.GetCumulativeMoney(curFavorability);
		int deltaMoney = curMoney - favorabilityList[merchantType];
		DomainManager.Merchant.ChangeMerchantCumulativeMoney(context, merchantType, deltaMoney);
	}

	public int GetCumulativeMoney(int favorability)
	{
		int length = GlobalConfig.Instance.MerchantFavorabilityMoneyRequirements.Length;
		int[] cumulativeMoneyStages = new int[length];
		for (int i = 0; i < length; i++)
		{
			int cumulative = 0;
			int j = i - 1;
			if (j >= 0 && j < length)
			{
				cumulative = cumulativeMoneyStages[j];
			}
			int diff = GlobalConfig.Instance.MerchantFavorabilityMoneyRequirements[i];
			cumulativeMoneyStages[i] = cumulative + diff;
		}
		int level = favorability / length - 1;
		int offset = favorability % length;
		int result = 0;
		if (level >= 0)
		{
			int tempLevel = Math.Clamp(level, 0, length - 1);
			result += cumulativeMoneyStages[tempLevel];
		}
		if (offset > 0)
		{
			int tempLevel2 = Math.Clamp(level + 1, 0, length - 1);
			result += (int)(1f * (float)offset / (float)length * (float)cumulativeMoneyStages[tempLevel2]);
		}
		return result;
	}

	public int GetFavorability(int cumulativeMoney)
	{
		return ShopExchange.GetFavorability(cumulativeMoney);
	}

	[DomainMethod]
	public int GetCurFavorability(sbyte merchantType)
	{
		return Math.Max(0, GetFavorabilityWithDelta(merchantType));
	}

	[DomainMethod]
	public int GetFavorabilityWithDelta(sbyte merchantType, int delta = 0)
	{
		int[] merchantFavorabilities = DomainManager.Merchant.GetMerchantFavorability();
		int money = (merchantFavorabilities.CheckIndex(merchantType) ? merchantFavorabilities[merchantType] : 0);
		if (money + delta < 0)
		{
			return -1;
		}
		return GetFavorability(money + delta);
	}

	[DomainMethod]
	public int[] GetAllFavorability()
	{
		int[] merchantFavorabilities = DomainManager.Merchant.GetMerchantFavorability();
		int[] favorability = new int[merchantFavorabilities.Length];
		for (int i = 0; i < merchantFavorabilities.Length; i++)
		{
			favorability[i] = GetFavorability(merchantFavorabilities[i]);
		}
		return favorability;
	}

	public bool TryGetMerchantData(int charId, out MerchantData value)
	{
		return TryGetElement_MerchantData(charId, out value);
	}

	public bool MerchantHasTargetItem(int charId, ItemKey itemKey, int amount)
	{
		if (!_merchantData.TryGetValue(charId, out var merchantData))
		{
			return false;
		}
		for (int i = 0; i < 7; i++)
		{
			Inventory goods = merchantData.GetGoodsList(i);
			if (goods.Items.TryGetValue(itemKey, out var hasAmount) && hasAmount >= amount)
			{
				return true;
			}
		}
		return false;
	}

	public void RemoveExistingMerchantItem(DataContext context, int charId, ItemKey itemKey, int amount)
	{
		if (!_merchantData.TryGetValue(charId, out var merchantData))
		{
			throw new Exception($"merchant {charId} has no item {itemKey}");
		}
		for (int i = 0; i < 7; i++)
		{
			Inventory goods = merchantData.GetGoodsList(i);
			if (goods.Items.TryGetValue(itemKey, out var hasAmount) && hasAmount >= amount)
			{
				DomainManager.Item.RemoveOwner(itemKey, ItemOwnerType.Merchant, charId);
				goods.OfflineRemove(itemKey, amount);
				SetElement_MerchantData(charId, merchantData, context);
				return;
			}
		}
		throw new Exception($"merchant {charId} has no item {itemKey}");
	}

	private MerchantData CreateMerchantData(DataContext context, int charId)
	{
		sbyte merchantTemplateId = GetOrCreateMerchantTemplateId(context, charId);
		MerchantData merchantData = new MerchantData(charId, merchantTemplateId);
		merchantData.GenerateGoods(context);
		merchantData.Money = GetMerchantMoney(context, merchantData.MerchantType);
		AddElement_MerchantData(charId, merchantData, context);
		if (!TryGetMerchantExpData(charId, out var _))
		{
			SetMerchantExpData(context, charId, new MerchantExpData(charId, merchantData.MerchantLevel));
		}
		return merchantData;
	}

	[DomainMethod]
	public sbyte GetMerchantTemplateId(int charId)
	{
		return GetOrCreateMerchantTemplateId(null, charId);
	}

	public sbyte GetOrCreateMerchantTemplateId(DataContext context, int charId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return -1;
		}
		if (!DomainManager.Extra.TryGetMerchantCharToType(charId, out var merchantType))
		{
			if (context == null)
			{
				return -1;
			}
			character.ChangeMerchantType(context, character.GetOrganizationInfo());
			if (!DomainManager.Extra.TryGetMerchantCharToType(charId, out merchantType))
			{
				return -1;
			}
		}
		sbyte merchantLevel = 0;
		short settlementId = character.GetOrganizationInfo().SettlementId;
		if (settlementId >= 0)
		{
			merchantLevel = GetMerchantLevel(merchantType, settlementId);
		}
		if (TryGetMerchantExpData(charId, out var merchantExpData))
		{
			merchantLevel = merchantExpData.GetMerchantLevel(merchantType);
		}
		return MerchantData.FindMerchantTemplateId(merchantType, merchantLevel);
	}

	public sbyte GetMerchantLevel(int charId)
	{
		sbyte id = GetMerchantTemplateId(charId);
		if (id >= 0)
		{
			MerchantItem config = Config.Merchant.Instance[id];
			return config.Level;
		}
		return -1;
	}

	public void RemoveMerchantData(DataContext context, int merchantId)
	{
		if (TryGetMerchantData(merchantId, out var merchantData))
		{
			merchantData.RemoveAllGoods(context);
			RemoveElement_MerchantData(merchantId, context);
		}
	}

	public void RemoveObsoleteMerchantData(DataContext context)
	{
		RemoveAllGoodsInMerchantBuyBackData(context);
		foreach (int merchantId in _merchantData.Keys)
		{
			MerchantData data = _merchantData[merchantId];
			data.RemoveAllGoods(context);
			RemoveElement_MerchantData(merchantId, context);
		}
		ClearBuildingMerchantData(context);
		ClearTempCaravan(context);
	}

	public void SetVillagerRoleMerchantType(DataContext context)
	{
		List<int> charIdList = new List<int>();
		DomainManager.Extra.GetVillagerRoleCharactersByTemplateId(3, ref charIdList);
		foreach (int charId in charIdList)
		{
			VillagerRoleBase role = DomainManager.Extra.GetVillagerRole(charId);
			if (role is VillagerRoleMerchant merchantRole)
			{
				DomainManager.Taiwu.SetMerchantType(context, charId, merchantRole.DesignatedMerchantType, immediate: true);
			}
		}
	}

	private void ClearBuildingMerchantData(DataContext context)
	{
		for (sbyte merchantTypeId = 0; merchantTypeId < 7; merchantTypeId++)
		{
			MerchantData data = GetElement_MerchantMaxLevelData(merchantTypeId);
			if (data != null)
			{
				data.RemoveAllGoods(context);
				data.GenerateGoods(context, SharedMethods.GetBuildingMerchantCaravanId(merchantTypeId, isHead: true));
				SetElement_MerchantMaxLevelData(merchantTypeId, data, context);
			}
		}
		for (sbyte merchantTypeId2 = 0; merchantTypeId2 < 7; merchantTypeId2++)
		{
			MerchantData data2 = DomainManager.Extra.BranchMerchantData[merchantTypeId2];
			if (data2 != null)
			{
				data2.RemoveAllGoods(context);
				data2.GenerateGoods(context, SharedMethods.GetBuildingMerchantCaravanId(merchantTypeId2, isHead: false));
				DomainManager.Extra.SetBranchMerchantData(context, merchantTypeId2, data2);
			}
		}
	}

	public void InitializeOwnedItems()
	{
		int key;
		MerchantData value;
		foreach (KeyValuePair<int, MerchantData> merchantDatum in _merchantData)
		{
			merchantDatum.Deconstruct(out key, out value);
			int merchantId = key;
			MerchantData merchant = value;
			InitializeOwnedItemsFromMerchant(ItemOwnerType.Merchant, merchantId, merchant);
		}
		foreach (KeyValuePair<int, MerchantData> caravanDatum in _caravanData)
		{
			caravanDatum.Deconstruct(out key, out value);
			int caravanId = key;
			MerchantData caravan = value;
			InitializeOwnedItemsFromMerchant(ItemOwnerType.Caravan, caravanId, caravan);
		}
		for (sbyte i = 0; i < _merchantMaxLevelData.Length; i++)
		{
			MerchantData merchantData = _merchantMaxLevelData[i];
			if (merchantData != null)
			{
				int caravanId2 = SharedMethods.GetBuildingMerchantCaravanId(i, isHead: true);
				InitializeOwnedItemsFromMerchant(ItemOwnerType.BuildingMerchant, caravanId2, merchantData);
			}
		}
		for (sbyte i2 = 0; i2 < DomainManager.Extra.BranchMerchantData.Length; i2++)
		{
			MerchantData merchantData2 = DomainManager.Extra.BranchMerchantData[i2];
			if (merchantData2 != null)
			{
				int caravanId3 = SharedMethods.GetBuildingMerchantCaravanId(i2, isHead: false);
				InitializeOwnedItemsFromMerchant(ItemOwnerType.BuildingMerchant, caravanId3, merchantData2);
			}
		}
		SectStorySpecialMerchant sectStorySpecialMerchant = DomainManager.Extra.GetSectStorySpecialMerchant();
		if (sectStorySpecialMerchant != null && sectStorySpecialMerchant.MerchantData != null)
		{
			InitializeOwnedItemsFromMerchant(ItemOwnerType.BuildingMerchant, -1, sectStorySpecialMerchant.MerchantData);
		}
		static void InitializeOwnedItemsFromMerchant(ItemOwnerType ownerType, int id, MerchantData merchantData3)
		{
			for (int j = 0; j < 7; j++)
			{
				Inventory goodsList = merchantData3.GetGoodsList(j);
				foreach (var (itemKey2, _) in goodsList.Items)
				{
					DomainManager.Item.SetOwner(itemKey2, ownerType, id);
				}
			}
		}
	}

	public bool HasNewGoods(GameData.Domains.Character.Character character)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		OrganizationItem orgConfig = Config.Organization.Instance[orgInfo.OrgTemplateId];
		OrganizationMemberItem orgMemberConfig = OrganizationDomain.GetOrgMemberConfig(orgInfo);
		return orgConfig.IsCivilian && orgInfo.OrgTemplateId != 0 && orgInfo.Grade == 4 && character.GetCurrAge() >= orgMemberConfig.IdentityActiveAge && !_merchantData.ContainsKey(character.GetId());
	}

	public sbyte GetMerchantLevel(sbyte merchantType, short settlementId)
	{
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		sbyte orgTemplateId = settlement.GetOrgTemplateId();
		OrganizationItem orgConfig = Config.Organization.Instance[orgTemplateId];
		MerchantTypeItem merchantTypeConfig = Config.MerchantType.Instance[merchantType];
		List<Settlement> civilianSettlements = new List<Settlement>();
		DomainManager.Organization.GetAllCivilianSettlements(civilianSettlements);
		foreach (Settlement civilianSettlement in civilianSettlements)
		{
			if (civilianSettlement.GetOrgTemplateId() == orgTemplateId)
			{
				settlement = civilianSettlement;
				break;
			}
		}
		short resource = ((merchantTypeConfig.CityAttributeType == EMerchantTypeCityAttributeType.Safety) ? settlement.GetSafety() : settlement.GetCulture());
		sbyte level = (sbyte)(orgConfig.MerchantLevel + ((resource >= 50) ? 1 : (-1)));
		return Math.Clamp(level, 0, 6);
	}

	[DomainMethod]
	public void GmCmd_AddItem(DataContext context, int charId, sbyte itemType, short templateId, int count, int level)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		if (character.IsMerchant(character.GetOrganizationInfo()))
		{
			MerchantData merchantData = GetMerchantData(context, charId);
			sbyte maxLevel = Math.Min(merchantData.MerchantConfig.Level, 6);
			level = Math.Clamp(level, 0, maxLevel);
			Inventory inventory = merchantData.GetGoodsList(level);
			ItemKey itemKey = DomainManager.Item.CreateItem(context, itemType, templateId);
			inventory.OfflineAdd(itemKey, count);
			DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Merchant, charId);
			SetElement_MerchantData(charId, merchantData, context);
		}
	}

	[DomainMethod]
	public MerchantOverFavorData GetMerchantOverFavorData(sbyte merchantType)
	{
		return DomainManager.Extra.GetMerchantOverFavorData(merchantType);
	}

	[DomainMethod]
	public List<MerchantInfoAreaData> GetMerchantInfoAreaDataList(sbyte merchantType)
	{
		List<MerchantInfoAreaData> merchantInfoAreaDataList = new List<MerchantInfoAreaData>();
		Dictionary<short, HashSet<int>> areaMerchantCharDict = DomainManager.Character.GetAreaMerchantCharDict(merchantType);
		foreach (KeyValuePair<short, HashSet<int>> item in areaMerchantCharDict)
		{
			item.Deconstruct(out var key, out var value);
			short areaTemplateId = key;
			HashSet<int> set = value;
			MerchantInfoAreaData merchantInfoAreaData = new MerchantInfoAreaData
			{
				AreaTemplateId = areaTemplateId,
				MerchantCount = set.Count
			};
			merchantInfoAreaDataList.Add(merchantInfoAreaData);
		}
		foreach (KeyValuePair<int, CaravanPath> item2 in _caravanDict)
		{
			item2.Deconstruct(out var key2, out var value2);
			int caravanId = key2;
			CaravanPath caravanPath = value2;
			if (merchantType <= 0 || _caravanData[caravanId].MerchantType == merchantType)
			{
				short areaId = caravanPath.GetCurrLocation().AreaId;
				MapAreaData areaData = DomainManager.Map.GetAreaByAreaId(areaId);
				short areaTemplateId2 = areaData.GetTemplateId();
				int index = merchantInfoAreaDataList.FindIndex((MerchantInfoAreaData d) => d.AreaTemplateId == areaTemplateId2);
				MerchantInfoAreaData merchantInfoAreaData2;
				if (index >= 0)
				{
					merchantInfoAreaData2 = merchantInfoAreaDataList[index];
				}
				else
				{
					merchantInfoAreaData2 = new MerchantInfoAreaData
					{
						AreaTemplateId = areaTemplateId2
					};
					merchantInfoAreaDataList.Add(merchantInfoAreaData2);
				}
				merchantInfoAreaData2.CaravanCount++;
			}
		}
		return merchantInfoAreaDataList;
	}

	[DomainMethod]
	public List<MerchantInfoCaravanData> GetMerchantInfoCaravanDataList(DataContext context, sbyte merchantType)
	{
		List<MerchantInfoCaravanData> merchantInfoCaravanDataList = new List<MerchantInfoCaravanData>();
		foreach (KeyValuePair<int, CaravanPath> item in _caravanDict)
		{
			item.Deconstruct(out var key, out var value);
			int caravanId = key;
			CaravanPath caravanPath = value;
			MerchantData merchantData = _caravanData[caravanId];
			if (merchantType >= 0 && merchantData.MerchantType != merchantType)
			{
				continue;
			}
			if (!DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var caravanExtraData))
			{
				caravanExtraData = CreateCaravanExtraData(context, caravanId);
			}
			MerchantInfoCaravanData merchantInfoAreaData = new MerchantInfoCaravanData
			{
				CaravanId = caravanId,
				MerchantTemplateId = merchantData.MerchantTemplateId,
				CurrentAreaTemplateId = DomainManager.Map.GetAreaByAreaId(caravanPath.GetCurrLocation().AreaId).GetTemplateId(),
				TargetAreaTemplateId = DomainManager.Map.GetAreaByAreaId(caravanPath.GetDestLocation().AreaId).GetTemplateId(),
				StartAreaTemplateId = DomainManager.Map.GetAreaByAreaId(caravanPath.GetSrcLocation().AreaId).GetTemplateId(),
				RemainSettlementInfoList = new List<SettlementDisplayData>(),
				RemainNodeCount = caravanPath.MoveNodes.Count - 1,
				ExtraData = caravanExtraData,
				IsInBrokenArea = MapAreaData.IsBrokenArea(caravanPath.GetCurrLocation().AreaId),
				CaravanPath = new CaravanPath(caravanPath)
			};
			if (caravanExtraData.SettlementIdList != null)
			{
				foreach (short id in caravanExtraData.SettlementIdList)
				{
					SettlementDisplayData displayData = DomainManager.Organization.GetDisplayData(id);
					merchantInfoAreaData.RemainSettlementInfoList.Add(displayData);
				}
			}
			merchantInfoCaravanDataList.Add(merchantInfoAreaData);
		}
		return merchantInfoCaravanDataList;
	}

	[DomainMethod]
	public List<MerchantInfoMerchantData> GetMerchantInfoMerchantDataList(sbyte merchantType)
	{
		List<MerchantInfoMerchantData> merchantInfoMerchantDataList = new List<MerchantInfoMerchantData>();
		Dictionary<short, HashSet<int>> areaMerchantCharDict = DomainManager.Character.GetAreaMerchantCharDict(merchantType);
		foreach (var (_, set) in areaMerchantCharDict)
		{
			foreach (int charId in set)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
				RelatedCharacter relatedCharacter;
				short favorability = (DomainManager.Character.TryGetRelation(charId, taiwuCharId, out relatedCharacter) ? relatedCharacter.Favorability : short.MinValue);
				short areaId = character.GetValidLocation().AreaId;
				MapAreaData areaData = DomainManager.Map.GetAreaByAreaId(areaId);
				short areaTemplateId = areaData.GetTemplateId();
				DomainManager.Organization.TryGetSettlementCharacter(charId, out var settlementChar);
				if (settlementChar != null)
				{
					Settlement settlement = DomainManager.Organization.GetSettlement(settlementChar.GetSettlementId());
					MerchantInfoMerchantData merchantInfoMerchantData = new MerchantInfoMerchantData
					{
						CharId = charId,
						BehaviorType = character.GetBehaviorType(),
						Favorability = favorability,
						NameRelatedData = DomainManager.Character.GetNameRelatedData(charId),
						MerchantTemplateId = DomainManager.Merchant.GetMerchantTemplateId(charId),
						CurrentAreaTemplateId = areaTemplateId,
						OrgTemplateId = settlementChar.GetOrgTemplateId(),
						FullBlockName = DomainManager.Map.GetBlockFullName(settlement.GetLocation()),
						AvatarData = character.GenerateAvatarRelatedData()
					};
					merchantInfoMerchantDataList.Add(merchantInfoMerchantData);
				}
			}
		}
		return merchantInfoMerchantDataList;
	}

	[DomainMethod]
	public MerchantInfoCaravanData GetMerchantInfoCaravanDataSingle(DataContext context, int targetCaravanId)
	{
		MerchantInfoCaravanData merchantInfoAreaData = new MerchantInfoCaravanData();
		_caravanDict.TryGetValue(targetCaravanId, out var caravanPath);
		if (caravanPath != null)
		{
			MerchantData merchantData = _caravanData[targetCaravanId];
			if (!DomainManager.Extra.TryGetCaravanExtraData(targetCaravanId, out var caravanExtraData))
			{
				caravanExtraData = CreateCaravanExtraData(context, targetCaravanId);
			}
			merchantInfoAreaData = new MerchantInfoCaravanData
			{
				CaravanId = targetCaravanId,
				MerchantTemplateId = merchantData.MerchantTemplateId,
				CurrentAreaTemplateId = DomainManager.Map.GetAreaByAreaId(caravanPath.GetCurrLocation().AreaId).GetTemplateId(),
				TargetAreaTemplateId = DomainManager.Map.GetAreaByAreaId(caravanPath.GetDestLocation().AreaId).GetTemplateId(),
				StartAreaTemplateId = DomainManager.Map.GetAreaByAreaId(caravanPath.GetSrcLocation().AreaId).GetTemplateId(),
				RemainSettlementInfoList = new List<SettlementDisplayData>(),
				RemainNodeCount = caravanPath.MoveNodes.Count - 1,
				ExtraData = caravanExtraData,
				IsInBrokenArea = MapAreaData.IsBrokenArea(caravanPath.GetCurrLocation().AreaId),
				CaravanPath = new CaravanPath(caravanPath)
			};
		}
		return merchantInfoAreaData;
	}

	[DomainMethod]
	public SectStorySpecialMerchant GetSectStorySpecialMerchantData(DataContext context)
	{
		int curData = DomainManager.World.GetCurrDate();
		SectStorySpecialMerchant sectStorySpecialMerchant = DomainManager.Extra.GetSectStorySpecialMerchant();
		MerchantItem merchantItem = Config.Merchant.Instance[(sbyte)51];
		if (sectStorySpecialMerchant?.MerchantData == null)
		{
			sectStorySpecialMerchant = new SectStorySpecialMerchant();
			sectStorySpecialMerchant.MerchantExtraGoodsData = new MerchantExtraGoodsData();
			MerchantData merchantData = new MerchantData(-1, merchantItem.TemplateId);
			merchantData.GenerateGoods(context, merchantItem.Level, -1, sectStorySpecialMerchant.MerchantExtraGoodsData);
			sectStorySpecialMerchant.MerchantExtraGoodsData.SeasonTemplateId = -1;
			sectStorySpecialMerchant.MerchantData = merchantData;
			sectStorySpecialMerchant.RefreshTime = curData;
			DomainManager.Extra.SetSectStorySpecialMerchant(sectStorySpecialMerchant, context);
		}
		else if (sectStorySpecialMerchant.RefreshTime + merchantItem.RefreshInterval <= curData)
		{
			sectStorySpecialMerchant.MerchantData.RemoveAllGoods(context);
			_sectStorySpecialMerchantBuyBackData?.RemoveAllGoods(context);
			MerchantData merchantData2 = new MerchantData(-1, merchantItem.TemplateId);
			sectStorySpecialMerchant.MerchantExtraGoodsData.Clear();
			merchantData2.GenerateGoods(context, merchantItem.Level, -1, sectStorySpecialMerchant.MerchantExtraGoodsData);
			sectStorySpecialMerchant.MerchantData = merchantData2;
			sectStorySpecialMerchant.RefreshTime = curData;
		}
		sectStorySpecialMerchant.MerchantData.Money = DomainManager.Merchant.GetMerchantMoney(context, merchantItem.MerchantType);
		DomainManager.Extra.SetSectStorySpecialMerchant(sectStorySpecialMerchant, context);
		return sectStorySpecialMerchant;
	}

	private void SetSectStorySpecialMerchantData(DataContext context, MerchantData merchantData)
	{
		SectStorySpecialMerchant sectStorySpecialMerchant = DomainManager.Extra.GetSectStorySpecialMerchant();
		sectStorySpecialMerchant.MerchantData = merchantData;
		DomainManager.Extra.SetSectStorySpecialMerchant(sectStorySpecialMerchant, context);
	}

	public ItemKey CreateMerchantRandomItem(DataContext context, short merchantTemplateId)
	{
		ItemKey itemKey = ItemKey.Invalid;
		MerchantItem config = Config.Merchant.Instance[merchantTemplateId];
		List<PresetItemTemplateIdGroup> allPresetList = new List<PresetItemTemplateIdGroup>();
		for (int i = 0; i <= 7; i++)
		{
			IList<PresetItemTemplateIdGroup> presetList = MerchantData.GetGoodsPreset(config, i);
			if (presetList != null && presetList.Count > 0)
			{
				allPresetList.AddRange(presetList);
			}
		}
		if (allPresetList.Count > 0)
		{
			PresetItemTemplateIdGroup preset = allPresetList.GetRandom(context.Random);
			itemKey = DomainManager.Item.CreateItem(context, preset.ItemType, preset.StartId);
		}
		return itemKey;
	}

	[DomainMethod]
	public bool CanRefreshMerchantGoods(DataContext context, bool consume = false)
	{
		if (DomainManager.Extra.GetTotalActionPointsRemaining() < GlobalConfig.Instance.RefreshItemApCost)
		{
			return false;
		}
		if (consume)
		{
			DomainManager.World.ConsumeActionPoint(context, GlobalConfig.Instance.RefreshItemApCost);
		}
		return true;
	}

	[DomainMethod]
	public bool RefreshMerchantGoods(DataContext context, int charOrCaravanId, bool isChar, sbyte level, bool isFromBuilding, bool isHeadBuildingMerchant, sbyte buildingMerchantType)
	{
		if (!CanRefreshMerchantGoods(context, consume: true))
		{
			return false;
		}
		GameData.Domains.Character.Character character = null;
		int caravanId = -1;
		MerchantData merchantData = null;
		if (isChar)
		{
			character = DomainManager.Character.GetElement_Objects(charOrCaravanId);
			merchantData = GetMerchantData(context, charOrCaravanId);
		}
		else if (isFromBuilding)
		{
			caravanId = SharedMethods.GetBuildingMerchantCaravanId(buildingMerchantType, isHeadBuildingMerchant);
			merchantData = GetBuildingMerchantData(context, buildingMerchantType, isHeadBuildingMerchant);
		}
		else
		{
			caravanId = charOrCaravanId;
			merchantData = GetCaravanMerchantData(context, charOrCaravanId);
		}
		DomainManager.Item.RemoveItems(context, merchantData.GetGoodsList(level).Items);
		if (isFromBuilding)
		{
			DomainManager.Extra.SetMerchantExtraGoods(context, SharedMethods.GetBuildingMerchantCaravanId(buildingMerchantType, isHeadBuildingMerchant), merchantData.OfflineRefreshGoods(context, level, character, caravanId));
		}
		else
		{
			DomainManager.Extra.SetMerchantExtraGoods(context, charOrCaravanId, merchantData.OfflineRefreshGoods(context, level, character, caravanId));
		}
		if (isChar)
		{
			SetMerchantData(charOrCaravanId, merchantData, context);
		}
		else if (isFromBuilding)
		{
			if (isHeadBuildingMerchant)
			{
				SetElement_MerchantMaxLevelData(buildingMerchantType, merchantData, context);
			}
			else
			{
				DomainManager.Extra.SetBranchMerchantData(context, buildingMerchantType, merchantData);
			}
		}
		else
		{
			SetCaravanData(charOrCaravanId, merchantData, context);
		}
		return true;
	}

	[DomainMethod]
	public void GmCmd_RemoveMerchantData(DataContext context, int merchantId)
	{
		if (TryGetMerchantData(merchantId, out var merchantData))
		{
			merchantData.RemoveAllGoods(context);
			RemoveElement_MerchantData(merchantId, context);
		}
	}

	[DomainMethod]
	public void GmCmd_SetMerchantCharToType(DataContext context, int charId, sbyte type)
	{
		DomainManager.Extra.SetMerchantCharToType(charId, type, context);
	}

	private static SkillBookTradeInfo CreateSkillBookTradeInfo(DataContext context, int charId)
	{
		SkillBookTradeInfo skillBookTradeInfo = new SkillBookTradeInfo(charId);
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		DomainManager.Character.GetSkillBookLibrary(context, character, skillBookTradeInfo.PrivateSkillBooks, skillBookTradeInfo.PrivateSkillBooks);
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (OrganizationDomain.IsSect(orgInfo.OrgTemplateId))
		{
			foreach (ItemKey itemKey in skillBookTradeInfo.PrivateSkillBooks)
			{
				SkillBookItem bookCfg = Config.SkillBook.Instance[itemKey.TemplateId];
				if (bookCfg.CombatSkillTemplateId < 0)
				{
					break;
				}
				CombatSkillItem skillCfg = Config.CombatSkill.Instance[bookCfg.CombatSkillTemplateId];
				if (skillCfg.SectId == orgInfo.OrgTemplateId)
				{
					skillBookTradeInfo.SectSkillBooks.Add(itemKey);
				}
			}
		}
		return skillBookTradeInfo;
	}

	[DomainMethod]
	public void FinishBookTrade(DataContext context, int charId, bool isFavor)
	{
		if (_skillBookTradeInfo == null)
		{
			return;
		}
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		if (_skillBookTradeInfo.BoughtBooksFromTaiwu.Count > 0)
		{
			foreach (ItemKey itemKey in _skillBookTradeInfo.BoughtBooksFromTaiwu)
			{
				ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
				item.RemoveOwner(ItemOwnerType.Library, charId);
			}
			character.AddInventoryItem(context, _skillBookTradeInfo.BoughtBooksFromTaiwu);
		}
		DomainManager.Character.DealWithSkillBookLibraryAfterTrading(context, character, _skillBookTradeInfo.SoldBooksToTaiwu, _skillBookTradeInfo.PrivateSkillBooks);
		_skillBookTradeInfo = null;
	}

	[DomainMethod]
	public void ExchangeBook(DataContext context, int npcId, List<ItemDisplayData> boughtItems, List<ItemDisplayData> soldItems, int selfAuthority, int npcAuthority)
	{
		if (boughtItems != null)
		{
			foreach (ItemDisplayData itemData in boughtItems)
			{
				ItemKey itemKey = itemData.Key;
				ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
				item.RemoveOwner(ItemOwnerType.Library, npcId);
				DomainManager.Taiwu.AddItem(context, itemKey, itemData.Amount, itemData.ItemSourceType);
				if (_skillBookTradeInfo.BoughtBooksFromTaiwu.Contains(itemKey))
				{
					_skillBookTradeInfo.BoughtBooksFromTaiwu.Remove(itemKey);
					continue;
				}
				_skillBookTradeInfo.PrivateSkillBooks.Remove(itemKey);
				_skillBookTradeInfo.SectSkillBooks.Remove(itemKey);
				_skillBookTradeInfo.SoldBooksToTaiwu.Add(itemKey);
				short itemSubType = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
				if (itemSubType == 1000)
				{
					int seniority = ProfessionFormulaImpl.Calculate(103, item.GetValue());
					DomainManager.Extra.ChangeProfessionSeniority(context, 16, seniority);
				}
				else
				{
					int seniority2 = ProfessionFormulaImpl.Calculate(52, item.GetValue());
					DomainManager.Extra.ChangeProfessionSeniority(context, 7, seniority2);
				}
			}
		}
		if (soldItems != null)
		{
			foreach (ItemDisplayData itemData2 in soldItems)
			{
				ItemKey itemKey2 = itemData2.Key;
				_skillBookTradeInfo.BoughtBooksFromTaiwu.Add(itemKey2);
				DomainManager.Taiwu.RemoveItem(context, itemKey2, itemData2.Amount, itemData2.ItemSourceType, deleteItem: false);
				ItemBase item2 = DomainManager.Item.GetBaseItem(itemKey2);
				item2.SetOwner(ItemOwnerType.Library, npcId);
			}
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		taiwu.SpecifyResource(context, 7, selfAuthority);
		GameData.Domains.Character.Character npc = DomainManager.Character.GetElement_Objects(npcId);
		npc.SpecifyResource(context, 7, npcAuthority);
		DomainManager.TaiwuEvent.CheckTaiwuStatusImmediately();
	}

	[DomainMethod]
	public List<ItemDisplayData> GetTradeBookDisplayData(DataContext context, int npcId, bool isFavor)
	{
		if (_skillBookTradeInfo == null || _skillBookTradeInfo.CharId != npcId)
		{
			_skillBookTradeInfo = CreateSkillBookTradeInfo(context, npcId);
		}
		return DomainManager.Item.GetItemDisplayDataListOptional(isFavor ? _skillBookTradeInfo.PrivateSkillBooks : _skillBookTradeInfo.SectSkillBooks, -1, -1);
	}

	[DomainMethod]
	public List<ItemDisplayData> GetTradeBackBookDisplayData()
	{
		return DomainManager.Item.GetItemDisplayDataListOptional(_skillBookTradeInfo.BoughtBooksFromTaiwu, -1, -1);
	}

	[DomainMethod]
	public MerchantBuyBackData GetMerchantBuyBackData(OpenShopEventArguments openShopEventArguments)
	{
		MerchantBuyBackData buyBackData;
		switch (openShopEventArguments.MerchantSourceTypeEnum)
		{
		case OpenShopEventArguments.EMerchantSourceType.NormalCharacter:
			return _merchantBuyBackData.TryGetValue(openShopEventArguments.Id, out buyBackData) ? buyBackData : null;
		case OpenShopEventArguments.EMerchantSourceType.MerchantHeadBuilding:
			return _merchantMaxLevelBuyBackData[openShopEventArguments.BuildingMerchantType];
		case OpenShopEventArguments.EMerchantSourceType.MerchantBranchBuilding:
			return _branchMerchantBuyBackData[openShopEventArguments.BuildingMerchantType];
		case OpenShopEventArguments.EMerchantSourceType.SpecialBuilding:
			return _sectStorySpecialMerchantBuyBackData;
		case OpenShopEventArguments.EMerchantSourceType.NormalCaravan:
			return _caravanBuyBackData.TryGetValue(openShopEventArguments.Id, out buyBackData) ? buyBackData : null;
		case OpenShopEventArguments.EMerchantSourceType.SingleAdventureCaravan:
			return _tempMerchantBuyBackData;
		case OpenShopEventArguments.EMerchantSourceType.ProfessionSkillCaravan:
			return _tempMerchantBuyBackData;
		case OpenShopEventArguments.EMerchantSourceType.SpecifiedOnBuildingMerchantType:
			return _merchantBuyBackData.TryGetValue(openShopEventArguments.Id, out buyBackData) ? buyBackData : null;
		default:
			throw new ArgumentOutOfRangeException();
		case OpenShopEventArguments.EMerchantSourceType.None:
		case OpenShopEventArguments.EMerchantSourceType.SettlementTreasury:
			return null;
		}
	}

	private void SetMerchantBuyBackData(OpenShopEventArguments openShopEventArguments, MerchantBuyBackData merchantBuyBackData)
	{
		switch (openShopEventArguments.MerchantSourceTypeEnum)
		{
		case OpenShopEventArguments.EMerchantSourceType.None:
			break;
		case OpenShopEventArguments.EMerchantSourceType.NormalCharacter:
			_merchantBuyBackData[openShopEventArguments.Id] = merchantBuyBackData;
			break;
		case OpenShopEventArguments.EMerchantSourceType.MerchantHeadBuilding:
			_merchantMaxLevelBuyBackData[openShopEventArguments.BuildingMerchantType] = merchantBuyBackData;
			break;
		case OpenShopEventArguments.EMerchantSourceType.MerchantBranchBuilding:
			_branchMerchantBuyBackData[openShopEventArguments.BuildingMerchantType] = merchantBuyBackData;
			break;
		case OpenShopEventArguments.EMerchantSourceType.SettlementTreasury:
			break;
		case OpenShopEventArguments.EMerchantSourceType.SpecialBuilding:
			_sectStorySpecialMerchantBuyBackData = merchantBuyBackData;
			break;
		case OpenShopEventArguments.EMerchantSourceType.NormalCaravan:
			_caravanBuyBackData[openShopEventArguments.Id] = merchantBuyBackData;
			break;
		case OpenShopEventArguments.EMerchantSourceType.SingleAdventureCaravan:
			_tempMerchantBuyBackData = merchantBuyBackData;
			break;
		case OpenShopEventArguments.EMerchantSourceType.ProfessionSkillCaravan:
			_tempMerchantBuyBackData = merchantBuyBackData;
			break;
		case OpenShopEventArguments.EMerchantSourceType.SpecifiedOnBuildingMerchantType:
			_merchantBuyBackData[openShopEventArguments.Id] = merchantBuyBackData;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public bool RemoveBuyBackItem(ItemKey itemKey)
	{
		if (RemoveButBackItemInInventory(_merchantBuyBackData.Values))
		{
			return true;
		}
		if (RemoveButBackItemInInventory(_caravanBuyBackData.Values))
		{
			return true;
		}
		if (RemoveButBackItemInInventory(_merchantMaxLevelBuyBackData))
		{
			return true;
		}
		if (RemoveButBackItemInInventory(_branchMerchantBuyBackData))
		{
			return true;
		}
		return false;
		bool RemoveButBackItemInInventory(IEnumerable<MerchantBuyBackData> buyBackDataCollection)
		{
			foreach (MerchantBuyBackData buyBackData in buyBackDataCollection)
			{
				if (buyBackData != null && buyBackData.BuyInGoodsList.Items.ContainsKey(itemKey))
				{
					buyBackData.BuyInGoodsList.OfflineRemove(itemKey, 1);
					ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
					item.RemoveOwner(item.Owner.OwnerType, item.Owner.OwnerId);
					return true;
				}
			}
			return false;
		}
	}

	public ItemKey TryGetBuyBackItemForPersonalNeed(DataContext context, GameData.Domains.Character.Ai.PersonalNeed personalNeed)
	{
		ItemKey itemKey = GetBuyBackItemInInventory(_merchantBuyBackData.Values);
		if (itemKey.IsValid())
		{
			return itemKey;
		}
		itemKey = GetBuyBackItemInInventory(_caravanBuyBackData.Values);
		if (itemKey.IsValid())
		{
			return itemKey;
		}
		itemKey = GetBuyBackItemInInventory(_merchantMaxLevelBuyBackData);
		if (itemKey.IsValid())
		{
			return itemKey;
		}
		itemKey = GetBuyBackItemInInventory(_branchMerchantBuyBackData);
		if (itemKey.IsValid())
		{
			return itemKey;
		}
		return ItemKey.Invalid;
		ItemKey GetBuyBackItemInInventory(IEnumerable<MerchantBuyBackData> buyBackDataCollection)
		{
			foreach (MerchantBuyBackData buyBackData in buyBackDataCollection)
			{
				if (buyBackData != null)
				{
					ItemKey selectedItemKey = buyBackData.TryGetGoodInSameGroup(context, personalNeed.ItemType, personalNeed.ItemTemplateId, -2);
					if (selectedItemKey.IsValid())
					{
						return selectedItemKey;
					}
				}
			}
			return ItemKey.Invalid;
		}
	}

	private void RemoveAllGoodsInMerchantBuyBackData(DataContext context)
	{
		RemoveAllGoods(_merchantBuyBackData.Values);
		RemoveAllGoods(_caravanBuyBackData.Values);
		RemoveAllGoods(_merchantMaxLevelBuyBackData);
		RemoveAllGoods(_branchMerchantBuyBackData);
		_tempMerchantData?.RemoveAllGoods(context);
		_sectStorySpecialMerchantBuyBackData?.RemoveAllGoods(context);
		_merchantBuyBackData.Clear();
		_caravanBuyBackData.Clear();
		void RemoveAllGoods(IEnumerable<MerchantBuyBackData> buyBackDataCollection)
		{
			foreach (MerchantBuyBackData item in buyBackDataCollection)
			{
				item?.RemoveAllGoods(context);
			}
		}
	}

	[DomainMethod]
	public void PullTradeCaravanLocations(DataContext context)
	{
		RefreshCaravanInTaiwuState(context);
	}

	[DomainMethod]
	public MerchantData GetCaravanMerchantData(DataContext context, int caravanId)
	{
		if (caravanId == -1 && _tempMerchantData != null)
		{
			return _tempMerchantData;
		}
		if (!TryGetElement_CaravanData(caravanId, out var merchantData))
		{
			return null;
		}
		if (caravanId >= 0)
		{
			DomainManager.Extra.TryGetMerchantExtraGoods(caravanId, out var merchantExtraGoods);
			sbyte oldSeason = merchantExtraGoods?.SeasonTemplateId ?? (-1);
			if (oldSeason != EventHelper.GetCurrSeason())
			{
				merchantData.RefreshSeasonExtraGoods(context, caravanId);
				SetCaravanData(caravanId, merchantData, context);
			}
		}
		return merchantData;
	}

	[DomainMethod]
	public MerchantData GetBuildingMerchantData(DataContext context, sbyte merchantType, bool isHead)
	{
		MerchantData[] dataArray = (isHead ? _merchantMaxLevelData : DomainManager.Extra.BranchMerchantData);
		MerchantBuyBackData[] buyBackDataArray = (isHead ? _merchantMaxLevelBuyBackData : _branchMerchantBuyBackData);
		MerchantTypeItem merchantTypeItem = Config.MerchantType.Instance[merchantType];
		sbyte targetLevel = (isHead ? merchantTypeItem.HeadLevel : merchantTypeItem.BranchLevel);
		MerchantData merchantData = dataArray[merchantType];
		if (merchantData != null && merchantData.MerchantLevel != targetLevel)
		{
			buyBackDataArray[merchantType]?.RemoveAllGoods(context);
			merchantData.RemoveAllGoods(context);
			merchantData = null;
		}
		int caravanId = SharedMethods.GetBuildingMerchantCaravanId(merchantType, isHead);
		if (merchantData == null)
		{
			MerchantItem merchantItem = Config.Merchant.Instance.FirstOrDefault((MerchantItem m) => m.Level == targetLevel && m.MerchantType == merchantType);
			Tester.Assert(merchantItem != null);
			dataArray[merchantType] = new MerchantData(-1, merchantItem.TemplateId);
			dataArray[merchantType].GenerateGoods(context, caravanId);
			merchantData = dataArray[merchantType];
			if (isHead)
			{
				SetElement_MerchantMaxLevelData(merchantType, merchantData, context);
			}
			else
			{
				DomainManager.Extra.SetBranchMerchantData(context, merchantType, merchantData);
			}
		}
		else
		{
			DomainManager.Extra.TryGetMerchantExtraGoods(caravanId, out var merchantExtraGoods);
			sbyte oldSeason = merchantExtraGoods?.SeasonTemplateId ?? (-1);
			if (oldSeason != EventHelper.GetCurrSeason())
			{
				merchantData.RefreshSeasonExtraGoods(context, caravanId);
				if (isHead)
				{
					SetElement_MerchantMaxLevelData(merchantType, merchantData, context);
				}
				else
				{
					DomainManager.Extra.SetBranchMerchantData(context, merchantType, merchantData);
				}
			}
		}
		merchantData.Money = GetMerchantMoney(context, merchantType);
		return merchantData;
	}

	private void InitMerchantMoney(DataContext context)
	{
		for (int i = 0; i < Config.Merchant.Instance.Count; i++)
		{
			MerchantItem configData = Config.Merchant.Instance[i];
			if (configData.Level == 6)
			{
				int money = configData.Money * context.Random.Next(80, 120) / 100;
				SetMerchantMoney(context, configData.MerchantType, money);
			}
		}
	}

	public void GenTradeCaravansOnAdvanceMonth(DataContext context)
	{
		if (!DomainManager.World.GetWorldFunctionsStatus(4))
		{
			return;
		}
		foreach (MerchantItem config in (IEnumerable<MerchantItem>)Config.Merchant.Instance)
		{
			if (config.Money <= 0 || config.Level == 6 || DomainManager.World.GetCurrDate() % config.GenerateInterval != 0)
			{
				continue;
			}
			int needMoney = config.Money * context.Random.Next(50, 150) / 100;
			int curMoney = GetMerchantMoney(context, config.MerchantType);
			if (needMoney > curMoney)
			{
				if (config.Level == 0)
				{
					curMoney += config.Money * context.Random.Next(80, 120) / 100;
					SetMerchantMoney(context, config.MerchantType, curMoney);
				}
				continue;
			}
			short srcAreaTemplateId = Config.MerchantType.Instance[config.MerchantType].HeadArea;
			short srcAreaId = DomainManager.Map.GetAreaIdByAreaTemplateId(srcAreaTemplateId);
			Location srcLocation = new Location(srcAreaId, DomainManager.Map.GetElement_Areas(srcAreaId).SettlementInfos[0].BlockId);
			short destAreaTemplateId;
			do
			{
				destAreaTemplateId = (short)context.Random.Next(1, 15);
			}
			while (destAreaTemplateId == srcAreaTemplateId);
			short destAreaId = DomainManager.Map.GetAreaIdByAreaTemplateId(destAreaTemplateId);
			Location destLocation = new Location(destAreaId, DomainManager.Map.GetElement_Areas(destAreaId).SettlementInfos[0].BlockId);
			CreateCaravan(context, config, srcLocation, destLocation, needMoney);
			curMoney -= needMoney;
			SetMerchantMoney(context, config.MerchantType, curMoney);
			bool needCreateExtra = true;
			List<int> keys = DomainManager.Extra.GetCaravanStayDaysKeys();
			foreach (int id in keys)
			{
				MerchantData merchant = _caravanData[id];
				if (merchant.MerchantType == config.MerchantType)
				{
					needCreateExtra = false;
					break;
				}
			}
			if (!(config.Level >= 3 && needCreateExtra))
			{
				continue;
			}
			int random = context.Random.Next(100);
			int targetLevel = 0;
			if (random <= 10)
			{
				targetLevel = 2;
			}
			else if (random <= 20)
			{
				targetLevel = 1;
			}
			MerchantItem targetConfig = null;
			foreach (MerchantItem tempConfig in (IEnumerable<MerchantItem>)Config.Merchant.Instance)
			{
				if (tempConfig.Level == targetLevel && tempConfig.MerchantType == config.MerchantType)
				{
					targetConfig = tempConfig;
					break;
				}
			}
			Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
			int caravanId = CreateCaravan(context, targetConfig, srcLocation, taiwuVillageLocation, needMoney);
			DomainManager.Extra.AddCaravanStayDays(caravanId, 90, context);
		}
	}

	private int CreateCaravan(DataContext context, MerchantItem config, Location srcLocation, Location destLocation, int needMoney)
	{
		int caravanId = GetNextCaravanId();
		MerchantData merchantData = new MerchantData(-1, config.TemplateId);
		SetNextCaravanId(caravanId + 1, context);
		merchantData.Money = needMoney;
		merchantData.GenerateGoods(context, caravanId);
		AddElement_CaravanData(caravanId, merchantData, context);
		List<(Location, short)> path = DomainManager.Map.CalcBlockTravelRoute(context.Random, srcLocation, destLocation);
		path.Insert(0, (srcLocation, 0));
		AddElement_CaravanDict(caravanId, CreateCaravanPath(path), context);
		CreateCaravanExtraData(context, caravanId);
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		Settlement settlement = DomainManager.Organization.GetSettlementByLocation(srcLocation);
		monthlyNotifications.AddMerchantGoTravelling(settlement.GetId(), config.MerchantType);
		return caravanId;
	}

	private CaravanPath CreateCaravanPath(List<(Location location, short cost)> path)
	{
		CaravanPath caravanPath = new CaravanPath();
		int leftDaysCounter = 15;
		Location lastLocation = path[0].location;
		caravanPath.FullPath.Add(path[0].location);
		caravanPath.MoveNodes.Add(0);
		for (int index = 1; index < path.Count; index++)
		{
			(Location, short) pathNode = path[index];
			short areaId = pathNode.Item1.AreaId;
			caravanPath.FullPath.Add(pathNode.Item1);
			MapBlockData mapBlockData = DomainManager.Map.GetBlock(pathNode.Item1);
			MapBlockData lastMapBlockData = DomainManager.Map.GetBlock(lastLocation);
			if (mapBlockData.IsCityTown() && !lastMapBlockData.IsCityTown())
			{
				leftDaysCounter = 15;
				caravanPath.MoveNodes.Add(index);
			}
			else
			{
				leftDaysCounter -= pathNode.Item2;
				while (leftDaysCounter <= 0)
				{
					leftDaysCounter += 15;
					caravanPath.MoveNodes.Add((leftDaysCounter > 0) ? index : ((areaId == lastLocation.AreaId) ? (index - 1) : (-1)));
				}
			}
			lastLocation = pathNode.Item1;
		}
		if (caravanPath.MoveNodes[caravanPath.MoveNodes.Count - 1] != path.Count - 1)
		{
			caravanPath.MoveNodes.Add(path.Count - 1);
		}
		caravanPath.MoveWaitDays = 30;
		return caravanPath;
	}

	private CaravanExtraData CreateCaravanExtraData(DataContext context, int caravanId)
	{
		if (DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var extraData))
		{
			return extraData;
		}
		extraData = new CaravanExtraData();
		short incomeCriticalResultMin = GlobalConfig.Instance.CaravanIncomeCriticalResultRange.First();
		short incomeCriticalResultMax = GlobalConfig.Instance.CaravanIncomeCriticalResultRange.Last();
		extraData.IncomeCriticalResult = (short)context.Random.Next(incomeCriticalResultMin, incomeCriticalResultMax);
		RefreshCaravanExtraDataSettlementIdList(caravanId, ref extraData.SettlementIdList);
		DomainManager.Extra.SetCaravanExtraData(context, caravanId, extraData);
		return extraData;
	}

	private void RefreshCaravanExtraDataSettlementIdList(int caravanId, ref List<short> settlementIdList)
	{
		CaravanPath caravanPath = _caravanDict[caravanId];
		if (settlementIdList == null)
		{
			settlementIdList = new List<short>();
		}
		settlementIdList.Clear();
		for (int i = 1; i < caravanPath.MoveNodes.Count; i++)
		{
			int index = caravanPath.MoveNodes[i];
			if (!caravanPath.FullPath.CheckIndex(index))
			{
				continue;
			}
			Location location = caravanPath.FullPath[index];
			MapBlockData blockData = DomainManager.Map.GetBelongSettlementBlock(location);
			if (blockData != null)
			{
				short id = DomainManager.Organization.GetSettlementByLocation(blockData.GetLocation())?.GetId() ?? (-1);
				if (id >= 0 && !settlementIdList.Contains(id))
				{
					settlementIdList.Add(id);
				}
			}
		}
	}

	public void CaravanMonthEvent(DataContext context)
	{
		if (DomainManager.Adventure.GetAdventureTaiwu().InAdventure)
		{
			return;
		}
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		if (!DomainManager.Map.GetElement_Areas(taiwuVillageLocation.AreaId).StationUnlocked || !DomainManager.World.GetWorldFunctionsStatus(4))
		{
			return;
		}
		EventArgBox globalEventArgBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		bool caravanVisitMonthEventTriggered = false;
		globalEventArgBox.Get("CS_PK_CaravanVisit", ref caravanVisitMonthEventTriggered);
		if (caravanVisitMonthEventTriggered)
		{
			return;
		}
		int taiwuVillageStationOpenDate = int.MaxValue;
		if (!globalEventArgBox.Get("CS_PK_StationOpenDate", ref taiwuVillageStationOpenDate))
		{
			return;
		}
		int currDate = DomainManager.World.GetCurrDate();
		if (currDate >= taiwuVillageStationOpenDate + 6)
		{
			int caravanId = GetMonthEventCaravanId(context);
			if (caravanId >= 0)
			{
				DomainManager.World.GetMonthlyEventCollection().AddMerchantVisit();
			}
		}
	}

	public int GetMonthEventCaravanId(DataContext context)
	{
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(taiwuVillageLocation.AreaId);
		sbyte mainAreaTemplateId = MapState.Instance[stateTemplateId].MainAreaID;
		int goodCount = 2;
		int goodIndex = 1;
		sbyte merchantType = -1;
		if (mainAreaTemplateId == 11)
		{
			merchantType = (sbyte)((context.Random.Next(0, 2) != 0) ? 1 : 0);
		}
		else
		{
			short mapBlockTemplateId = MapArea.Instance[mainAreaTemplateId].SettlementBlockCore[0];
			List<short> presetBuildingList = MapBlock.Instance[mapBlockTemplateId].PresetBuildingList;
			for (int i = 0; i < presetBuildingList.Count; i++)
			{
				if (presetBuildingList[i] >= 276 && presetBuildingList[i] <= 282)
				{
					BuildingBlockItem buildingBlockItem = BuildingBlock.Instance[presetBuildingList[i]];
					merchantType = buildingBlockItem.MerchantId;
					break;
				}
			}
		}
		int caravanId = DomainManager.Merchant.TryGetCaravanIdByTypeAndLevel(merchantType, 3, goodIndex, goodCount);
		if (caravanId < 0)
		{
			for (int index = 1; index < 6; index++)
			{
				for (sbyte level = 0; level <= 6; level++)
				{
					caravanId = DomainManager.Merchant.TryGetCaravanIdByTypeAndLevel(merchantType, level, index, goodCount);
					if (caravanId >= 0)
					{
						MerchantData caravanMerchantData = DomainManager.Merchant.GetCaravanMerchantData(context, caravanId);
						if (caravanMerchantData != null)
						{
							break;
						}
					}
				}
				if (caravanId >= 0)
				{
					break;
				}
			}
		}
		return caravanId;
	}

	public void UpdateCaravansMove(DataContext context)
	{
		bool anyCaravanAddedOrMoved = false;
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		int taiwuState = (taiwuLocation.IsValid() ? DomainManager.Map.GetStateIdByAreaId(taiwuLocation.AreaId) : (-1));
		foreach (int caravanId in _caravanDict.Keys)
		{
			if (!DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var extraData))
			{
				continue;
			}
			MerchantData merchantData = _caravanData[caravanId];
			CaravanPath path = _caravanDict[caravanId];
			switch ((CaravanState)extraData.State)
			{
			case CaravanState.Robbed:
				ApplyMerchantRobbedResult(context, caravanId, win: false);
				AddInvestedCaravanRobbedMonthlyNotification(path.GetCurrLocation(), extraData, merchantData, finished: true);
				continue;
			case CaravanState.RobEnd:
				extraData.State = 0;
				DomainManager.Extra.SetCaravanExtraData(context, caravanId, extraData);
				continue;
			}
			Location destLocation = path.GetDestLocation();
			MapBlockData destMapBlockData = DomainManager.Map.GetBlock(destLocation).GetRootBlock();
			Settlement targetSettlement = DomainManager.Organization.GetSettlementByLocation(destMapBlockData.GetLocation());
			if (DomainManager.Map.GetStateIdByAreaId(path.GetCurrLocation().AreaId) == taiwuState)
			{
				anyCaravanAddedOrMoved = true;
			}
			if (path.MoveNodes.Count > 0)
			{
				int pathIndex = path.MoveNodes.First();
				for (int i = 1; i < path.MoveNodes.Count; i++)
				{
					int curIndex = path.MoveNodes[i];
					if (curIndex >= 0)
					{
						if (pathIndex > curIndex)
						{
							Logger.Warn($"caravan {caravanId} path has error");
							break;
						}
						pathIndex = curIndex;
					}
				}
				path.MoveWaitDays -= 30;
				if (path.MoveNodes.Count == 1 && DomainManager.Extra.TryGetCaravanStayDays(caravanId, out var stayDays))
				{
					path.MoveWaitDays = Convert.ToInt16(stayDays - 30);
					DomainManager.Extra.SetCaravanStayDays(caravanId, path.MoveWaitDays, context);
				}
				if (path.MoveWaitDays > 0)
				{
					continue;
				}
				path.MoveWaitDays += 30;
				path.MoveNodes.RemoveAt(0);
				if (path.MoveNodes.Count > 0)
				{
					int arriveIndex = path.MoveNodes.First();
					if (!path.FullPath.CheckIndex(arriveIndex))
					{
						continue;
					}
					Location arriveLocation = path.FullPath[arriveIndex];
					MapBlockData mapBlockData = DomainManager.Map.GetBlock(arriveLocation).GetRootBlock();
					Location location = mapBlockData.GetLocation();
					if (mapBlockData.IsCityTown())
					{
						Settlement settlement = DomainManager.Organization.GetSettlementByLocation(location);
						short settlementId = settlement?.GetId() ?? (-1);
						if (settlementId >= 0 && extraData.SettlementIdList != null && extraData.SettlementIdList.Contains(settlementId))
						{
							extraData.SettlementIdList.Remove(settlementId);
							short culture = settlement.GetCulture();
							bool isHighCulture = culture > 50;
							bool isLowCulture = culture < 50;
							bool hasChangedIncomeBonus = false;
							bool hasChangedIncomeCriticalRate = false;
							if (isHighCulture)
							{
								short newIncomeBonus = (short)Math.Clamp(extraData.IncomeBonus + Convert.ToInt16(culture * 5 - 250), 0, 32767);
								if (extraData.IncomeBonus != newIncomeBonus)
								{
									hasChangedIncomeBonus = true;
									extraData.IncomeBonus = newIncomeBonus;
								}
							}
							else if (isLowCulture)
							{
								short newIncomeCriticalRate = (short)Math.Clamp(extraData.IncomeCriticalRate + Convert.ToInt16(200 - 4 * culture), 0, 1000);
								if (extraData.IncomeCriticalRate != newIncomeCriticalRate)
								{
									hasChangedIncomeCriticalRate = true;
									extraData.IncomeCriticalRate = newIncomeCriticalRate;
								}
							}
							short safety = settlement.GetSafety();
							bool isHighSafety = safety > 50;
							bool isLowSafety = safety < 50;
							bool hasChangedRobbedRate = false;
							short newRobbedRate = (short)Math.Clamp(extraData.RobbedRate + Convert.ToInt16(200 - 4 * safety), 0, 1000);
							if (extraData.RobbedRate != newRobbedRate)
							{
								hasChangedRobbedRate = true;
								extraData.RobbedRate = newRobbedRate;
							}
							DomainManager.Extra.SetCaravanExtraData(context, caravanId, extraData);
							AddInvestedCaravanPassSettlementMonthlyNotification(isLowSafety, isHighSafety, hasChangedRobbedRate, hasChangedIncomeBonus, hasChangedIncomeCriticalRate, settlementId, targetSettlement.GetId(), extraData, merchantData, path);
						}
					}
					else
					{
						int random = context.Random.Next(1000);
						int rate = SharedMethods.GetCaravanRobbedRate(extraData.RobbedRate, MapAreaData.IsBrokenArea(location.AreaId));
						if (random < rate)
						{
							extraData.State = 1;
							DomainManager.Extra.SetCaravanExtraData(context, caravanId, extraData);
							AddInvestedCaravanRobbedMonthlyNotification(location, extraData, merchantData, finished: false);
						}
					}
				}
			}
			if (path.MoveNodes.Count == 0)
			{
				OnCaravanArrive(context, caravanId, extraData, merchantData, targetSettlement.GetId());
			}
			else
			{
				SetElement_CaravanDict(caravanId, path, context);
			}
		}
		if (!DomainManager.Map.IsTraveling && anyCaravanAddedOrMoved)
		{
			RefreshCaravanInTaiwuState(context);
		}
	}

	private void AddInvestedCaravanPassSettlementMonthlyNotification(bool isLowSafety, bool isHighSafety, bool hasChangedRobbedRate, bool hasChangedIncomeBonus, bool hasChangedIncomeCriticalRate, short curSettlementId, short targetSettlementId, CaravanExtraData extraData, MerchantData merchantData, CaravanPath caravanPath)
	{
		if (!extraData.IsInvested)
		{
			return;
		}
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		int robbedRate = extraData.RobbedRate / 10;
		int incomeBonus = extraData.IncomeBonus / 10;
		int incomeCriticalRate = extraData.IncomeCriticalRate / 10;
		int costTime = caravanPath.MoveNodes.Count - 1;
		if (hasChangedRobbedRate)
		{
			if (isHighSafety)
			{
				if (hasChangedIncomeBonus)
				{
					monthlyNotificationCollection.AddInvestedCaravanPassHighSafetyHighCultureSettlement(merchantData.MerchantTemplateId, curSettlementId, costTime, targetSettlementId, robbedRate, incomeBonus);
				}
				else if (hasChangedIncomeCriticalRate)
				{
					monthlyNotificationCollection.AddInvestedCaravanPassHighSafetyLowCultureSettlement(merchantData.MerchantTemplateId, curSettlementId, costTime, targetSettlementId, robbedRate, incomeCriticalRate);
				}
				else
				{
					monthlyNotificationCollection.AddInvestedCaravanPassHighSafetySettlement(merchantData.MerchantTemplateId, curSettlementId, costTime, targetSettlementId, robbedRate);
				}
			}
			else if (isLowSafety)
			{
				if (hasChangedIncomeBonus)
				{
					monthlyNotificationCollection.AddInvestedCaravanPassLowSafetyHighCultureSettlement(merchantData.MerchantTemplateId, curSettlementId, costTime, targetSettlementId, robbedRate, incomeBonus);
				}
				else if (hasChangedIncomeCriticalRate)
				{
					monthlyNotificationCollection.AddInvestedCaravanPassLowSafetyLowCultureSettlement(merchantData.MerchantTemplateId, curSettlementId, costTime, targetSettlementId, robbedRate, incomeCriticalRate);
				}
				else
				{
					monthlyNotificationCollection.AddInvestedCaravanPassLowSafetySettlement(merchantData.MerchantTemplateId, curSettlementId, costTime, targetSettlementId, robbedRate);
				}
			}
		}
		else if (hasChangedIncomeBonus)
		{
			monthlyNotificationCollection.AddInvestedCaravanPassHighCultureSettlement(merchantData.MerchantTemplateId, curSettlementId, costTime, targetSettlementId, incomeBonus);
		}
		else if (hasChangedIncomeCriticalRate)
		{
			monthlyNotificationCollection.AddInvestedCaravanPassLowCultureSettlement(merchantData.MerchantTemplateId, curSettlementId, costTime, targetSettlementId, incomeCriticalRate);
		}
		else
		{
			monthlyNotificationCollection.AddInvestedCaravanPassSettlement(merchantData.MerchantTemplateId, curSettlementId, costTime, targetSettlementId);
		}
	}

	private void AddInvestedCaravanRobbedMonthlyNotification(Location location, CaravanExtraData extraData, MerchantData merchantData, bool finished)
	{
		if (extraData.IsInvested)
		{
			MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
			if (!finished)
			{
				monthlyNotificationCollection.AddInvestedCaravanIsRobbed(merchantData.MerchantTemplateId, location);
			}
			else
			{
				monthlyNotificationCollection.AddInvestedCaravanIsRobbedAndFailed(merchantData.MerchantTemplateId, location, extraData.IncomeBonus / 10);
			}
		}
	}

	public void ApplyMerchantRobbedResult(DataContext context, int caravanId, bool win, bool refresh = false)
	{
		if (DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var extraData))
		{
			if (win)
			{
				MerchantData merchantData = GetCaravanMerchantData(context, caravanId);
				int delta = GlobalConfig.Instance.CaravanRobbedEventWinAddMerchantFavorability[merchantData.MerchantLevel];
				ChangeMerchantCumulativeMoney(context, merchantData.MerchantType, delta);
			}
			else
			{
				short reduceIncomeBonus = GlobalConfig.Instance.CaravanRobbedEventLoseReduceIncomeBonus;
				extraData.IncomeBonus = Convert.ToInt16(extraData.IncomeBonus * (100 - reduceIncomeBonus) / 100);
			}
			sbyte reduceRobbedRate = GlobalConfig.Instance.CaravanRobbedEventEndReduceRobbedRate;
			extraData.RobbedRate = Convert.ToInt16(extraData.RobbedRate * (100 - reduceRobbedRate) / 100);
			extraData.State = 2;
			DomainManager.Extra.SetCaravanExtraData(context, caravanId, extraData);
			if (refresh)
			{
				RefreshCaravanInTaiwuState(context);
			}
		}
	}

	public void RefreshCaravanInTaiwuState(DataContext context)
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return;
		}
		sbyte taiwuState = DomainManager.Map.GetStateIdByAreaId(taiwuLocation.AreaId);
		List<CaravanDisplayData> caravanDataList = new List<CaravanDisplayData>();
		foreach (int caravanId in _caravanDict.Keys)
		{
			CaravanPath path = _caravanDict[caravanId];
			Location caravanLocation = path.GetCurrLocation();
			if (DomainManager.Map.GetStateIdByAreaId(caravanLocation.AreaId) == taiwuState)
			{
				CaravanDisplayData displayData = GetCaravanDisplayData(context, caravanId);
				caravanDataList.Add(displayData);
			}
		}
		caravanDataList = caravanDataList.OrderByDescending(delegate(CaravanDisplayData d)
		{
			CaravanState? caravanState = d.ExtraData?.StateEnum;
			return caravanState.HasValue && caravanState == CaravanState.Robbed;
		}).ToList();
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.RefreshCaravanData, caravanDataList);
	}

	public List<CaravanDisplayData> GetCaravanAtBlock(DataContext context, Location location)
	{
		return (from kv in _caravanDict
			where kv.Value.GetCurrLocation() == location
			select GetCaravanDisplayData(context, kv.Key)).OrderByDescending(delegate(CaravanDisplayData d)
		{
			CaravanState? caravanState = d.ExtraData?.StateEnum;
			return caravanState.HasValue && caravanState == CaravanState.Robbed;
		}).ToList();
	}

	public bool IsCaravanAtBlock(Location location)
	{
		return _caravanDict.Values.Any((CaravanPath x) => x.GetCurrLocation() == location);
	}

	[DomainMethod]
	public CaravanDisplayData GetCaravanDisplayData(DataContext context, int caravanId)
	{
		if (!_caravanDict.TryGetValue(caravanId, out var path))
		{
			return null;
		}
		short merchantTemplateId = _caravanData[caravanId].MerchantTemplateId;
		MerchantItem merchantConfig = Config.Merchant.Instance[merchantTemplateId];
		if (!DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var caravanExtraData))
		{
			caravanExtraData = CreateCaravanExtraData(context, caravanId);
		}
		CaravanDisplayData caravanDisplayData = new CaravanDisplayData
		{
			CaravanId = caravanId,
			MerchantTemplateId = merchantTemplateId,
			TargetArea = path.GetDestLocation().AreaId,
			Favorability = DomainManager.Merchant.GetCurFavorability(merchantConfig.MerchantType),
			PathInArea = path.GetRemainCaravanPathInCurrentArea(),
			ExtraData = caravanExtraData
		};
		List<short> settlementIdList = caravanExtraData.SettlementIdList;
		if (settlementIdList != null && settlementIdList.Count > 0)
		{
			caravanDisplayData.SettlementDisplayDataList = new List<SettlementDisplayData>();
			foreach (short settlementId in caravanExtraData.SettlementIdList)
			{
				SettlementDisplayData settlementDisplayData = DomainManager.Organization.GetDisplayData(settlementId);
				caravanDisplayData.SettlementDisplayDataList.Add(settlementDisplayData);
			}
		}
		return caravanDisplayData;
	}

	private void OnCaravanArrive(DataContext context, int caravanId, CaravanExtraData extraData, MerchantData merchantData, short targetSettlementId)
	{
		short incomeCriticalRate = extraData?.IncomeCriticalRate ?? 0;
		short incomeBonus = extraData?.IncomeBonus ?? 1000;
		short incomeCriticalResult = extraData?.IncomeCriticalResult ?? 100;
		int random = context.Random.Next(1000);
		bool critical = random < incomeCriticalRate;
		int income = merchantData.Money * incomeBonus / 1000;
		if (critical)
		{
			income = income * incomeCriticalResult / 100;
		}
		int money = GetMerchantMoney(context, merchantData.MerchantType);
		money += income;
		SetMerchantMoney(context, merchantData.MerchantType, money);
		if (extraData != null && extraData.IsInvested)
		{
			int investedMoney = GlobalConfig.Instance.InvestCaravanNeedMoney[merchantData.MerchantLevel];
			int taiwuIncome = investedMoney * incomeBonus / 1000;
			if (critical)
			{
				taiwuIncome = taiwuIncome * incomeCriticalResult / 100;
			}
			DomainManager.Taiwu.GetTaiwu().ChangeResource(context, 6, taiwuIncome);
			ChangeMerchantCumulativeMoney(context, merchantData.MerchantType, taiwuIncome);
			MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
			monthlyNotificationCollection.AddInvestedCaravanArrive(merchantData.MerchantTemplateId, targetSettlementId, taiwuIncome, merchantData.MerchantType);
			int seniority = ((taiwuIncome != 0) ? ProfessionFormulaImpl.Calculate(99, investedMoney, taiwuIncome) : 0);
			DomainManager.Extra.ChangeProfessionSeniority(context, 15, seniority);
		}
		merchantData.RemoveAllGoods(context);
		RemoveElement_CaravanData(caravanId, context);
		RemoveElement_CaravanDict(caravanId, context);
		if (extraData != null)
		{
			DomainManager.Extra.RemoveCaravanExtraData(context, caravanId);
		}
		if (DomainManager.Extra.TryGetCaravanStayDays(caravanId, out var _))
		{
			DomainManager.Extra.RemoveCaravanStayDays(caravanId, context);
		}
	}

	[DomainMethod]
	public void InvestCaravan(DataContext context, int caravanId)
	{
		_caravanData.TryGetValue(caravanId, out var merchantData);
		Tester.Assert(merchantData != null);
		CaravanPath caravanPath = _caravanDict[caravanId];
		Tester.Assert(caravanPath.FullPath.Count >= 1);
		DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var caravanExtraData);
		int needMoney = GlobalConfig.Instance.InvestCaravanNeedMoney[merchantData.MerchantLevel];
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int curMoney = taiwu.GetResource(6);
		Tester.Assert(needMoney <= curMoney);
		taiwu.ChangeResource(context, 6, -needMoney);
		caravanExtraData.IsInvested = true;
		DomainManager.Extra.SetCaravanExtraData(context, caravanId, caravanExtraData);
	}

	[DomainMethod]
	public void ProtectCaravan(DataContext context, int caravanId)
	{
		_caravanData.TryGetValue(caravanId, out var merchantData);
		Tester.Assert(merchantData != null);
		DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var caravanExtraData);
		int authorityFactor = GlobalConfig.Instance.InvestedCaravanAvoidRobbedNeedAuthorityFactor[merchantData.MerchantLevel];
		int costAuthority = authorityFactor * caravanExtraData.RobbedRate / 2;
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int curAuthority = taiwu.GetResource(7);
		Tester.Assert(costAuthority <= curAuthority);
		int time = DomainManager.World.GetCurrDate();
		taiwu.ChangeResource(context, 7, -costAuthority);
		caravanExtraData.RobbedRate /= 2;
		DomainManager.Extra.SetCaravanExtraData(context, caravanId, caravanExtraData);
		DomainManager.Extra.SetProtectCaravanTime(time, context);
	}

	private void CreateTempCaravan(DataContext context, sbyte merchantType, sbyte merchantLevel)
	{
		if (!TryGetElement_CaravanData(-1, out var merchantData))
		{
			AddElement_CaravanData(-1, merchantData, context);
		}
		_tempMerchantBuyBackData?.RemoveAllGoods(context);
		merchantData?.RemoveAllGoods(context);
		merchantData = new MerchantData(-1, MerchantData.FindMerchantTemplateId(merchantType, merchantLevel));
		_caravanData[-1] = merchantData;
		merchantData.GenerateGoods(context);
		merchantData.Money = GetMerchantMoney(context, merchantData.MerchantType);
		SetElement_CaravanData(-1, merchantData, context);
	}

	public void StartTempCaravanAction(sbyte merchantType, sbyte merchantLevel, bool refresh, bool ignoreWorldProgress, bool ignoreFavorability, bool isOpenedByProfessionSkill)
	{
		ResetTransactionData();
		if (TryGetElement_CaravanData(-1, out var merchantData))
		{
			MerchantItem config = Config.Merchant.Instance[merchantData.MerchantTemplateId];
			if (refresh || merchantData.MerchantType != merchantType || config.Level != merchantLevel)
			{
				CreateTempCaravan(DomainManager.TaiwuEvent.MainThreadDataContext, merchantType, merchantLevel);
			}
		}
		else
		{
			CreateTempCaravan(DomainManager.TaiwuEvent.MainThreadDataContext, merchantType, merchantLevel);
		}
		OpenShopEventArguments.EMerchantSourceType merchantSourceType = (isOpenedByProfessionSkill ? OpenShopEventArguments.EMerchantSourceType.ProfessionSkillCaravan : OpenShopEventArguments.EMerchantSourceType.SingleAdventureCaravan);
		OpenShopEventArguments openShopEventArguments = new OpenShopEventArguments
		{
			Id = -1,
			Refresh = refresh,
			IgnoreWorldProgress = ignoreWorldProgress,
			IgnoreFavorability = ignoreFavorability,
			BuildingMerchantType = -1,
			MerchantSourceType = (sbyte)merchantSourceType
		};
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenShop, openShopEventArguments);
	}

	public void StartSpecificCharIdAndMerchantTypeAction(int charId, sbyte merchantType, sbyte merchantLevel, bool refresh)
	{
		ResetTransactionData();
		DataContext ctx = DomainManager.TaiwuEvent.MainThreadDataContext;
		if (merchantType == 8)
		{
			MerchantData merchantData = _merchantData.Values.FirstOrDefault((MerchantData mct) => mct.MerchantType == merchantType);
			if (merchantData != null && merchantData.CharId != charId)
			{
				RemoveElement_MerchantData(merchantData.CharId, ctx);
				merchantData.CharId = charId;
				if (_merchantData.ContainsKey(charId))
				{
					SetElement_MerchantData(charId, merchantData, ctx);
				}
				else
				{
					AddElement_MerchantData(charId, merchantData, ctx);
				}
			}
			else if (merchantData == null)
			{
				bool existing = TryGetElement_MerchantData(charId, out merchantData);
				sbyte templateId = MerchantData.FindMerchantTemplateId(merchantType, merchantLevel);
				if (!existing)
				{
					merchantData = new MerchantData(charId, templateId);
				}
				else
				{
					merchantData.MerchantTemplateId = templateId;
				}
				merchantData.GenerateGoods(ctx);
				merchantData.Money = 0;
				if (existing)
				{
					SetElement_MerchantData(charId, merchantData, ctx);
				}
				else
				{
					AddElement_MerchantData(charId, merchantData, ctx);
				}
			}
		}
		else
		{
			MerchantData merchantData;
			bool existing2 = TryGetElement_MerchantData(charId, out merchantData);
			sbyte templateId2 = MerchantData.FindMerchantTemplateId(merchantType, merchantLevel);
			if (!existing2)
			{
				merchantData = new MerchantData(charId, templateId2);
				merchantData.GenerateGoods(ctx);
				merchantData.Money = 0;
			}
			else if (merchantData.MerchantTemplateId != templateId2)
			{
				merchantData.RemoveAllGoods(ctx);
				merchantData.MerchantTemplateId = templateId2;
				merchantData.GenerateGoods(ctx);
				merchantData.Money = 0;
			}
			if (existing2)
			{
				SetElement_MerchantData(charId, merchantData, ctx);
			}
			else
			{
				AddElement_MerchantData(charId, merchantData, ctx);
			}
		}
		short settlementId = DomainManager.Character.GetAliveOrgDeadCharacterOrgInfo(charId).SettlementId;
		bool favorabilityFull = false;
		if (DomainManager.Organization.TryGetElement_Sects(settlementId, out var sect))
		{
			favorabilityFull = sect.CalcApprovingRate() >= 800;
		}
		OpenShopEventArguments openShopEventArguments = new OpenShopEventArguments
		{
			Id = charId,
			Refresh = refresh,
			IgnoreWorldProgress = false,
			IgnoreFavorability = favorabilityFull,
			MerchantSourceType = 8,
			SettlementId = settlementId
		};
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenShop, openShopEventArguments);
	}

	public void ResetTransactionData()
	{
		_totalBuyMoney = 0;
		_totalSoldMoney = 0;
	}

	public void StartBuildingShopAction(OpenShopEventArguments.EMerchantSourceType merchantSourceType, sbyte merchantType)
	{
		OpenShopEventArguments openShopEventArguments = new OpenShopEventArguments
		{
			BuildingMerchantType = merchantType,
			MerchantSourceType = (sbyte)merchantSourceType
		};
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenShop, openShopEventArguments);
	}

	public void ClearTempCaravan(DataContext context)
	{
		if (TryGetElement_CaravanData(-1, out var merchantData))
		{
			merchantData.RemoveAllGoods(context);
			RemoveElement_CaravanData(-1, context);
		}
	}

	public void SetCaravanData(int caravanId, MerchantData merchantData, DataContext context)
	{
		SetElement_CaravanData(caravanId, merchantData, context);
	}

	[DomainMethod]
	public List<int> GetTaiwuLocationMaxLevelCaravanIdList()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return null;
		}
		List<int> caravanIdList = new List<int>();
		foreach (KeyValuePair<int, CaravanPath> item in _caravanDict)
		{
			item.Deconstruct(out var key, out var value);
			int id = key;
			CaravanPath path = value;
			Location caravanLocation = path.GetCurrLocation();
			if (!(caravanLocation != taiwuLocation))
			{
				caravanIdList.Add(id);
			}
		}
		return caravanIdList;
	}

	public bool TryGetFirstTaiwuLocationCaravanId(out int res)
	{
		res = -1;
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return false;
		}
		foreach (KeyValuePair<int, CaravanPath> item in _caravanDict)
		{
			item.Deconstruct(out var key, out var value);
			int id = key;
			CaravanPath path = value;
			Location caravanLocation = path.GetCurrLocation();
			if (caravanLocation == taiwuLocation)
			{
				res = id;
				return true;
			}
		}
		return false;
	}

	private void CorrectCaravanCurrentLocation(int caravanId)
	{
		CaravanPath path = _caravanDict[caravanId];
		int nodeIndex;
		for (nodeIndex = 0; path.MoveNodes[nodeIndex] < 0; nodeIndex++)
		{
		}
		Location currLocation = path.FullPath[path.MoveNodes[nodeIndex]];
		MapBlockData mapBlockData = DomainManager.Map.GetBlockData(currLocation.AreaId, currLocation.BlockId);
		if (!FiveLoongDlcEntry.IsBlockLoongBlock(mapBlockData))
		{
			return;
		}
		List<MapBlockData> neighborBlockList = ObjectPool<List<MapBlockData>>.Instance.Get();
		neighborBlockList.Clear();
		DomainManager.Map.GetNeighborBlocks(currLocation.AreaId, currLocation.BlockId, neighborBlockList, 4);
		foreach (MapBlockData neighbor in neighborBlockList)
		{
			if (FiveLoongDlcEntry.IsBlockLoongBlock(neighbor))
			{
				path.FullPath[path.MoveNodes[nodeIndex]] = new Location(neighbor.AreaId, neighbor.BlockId);
				break;
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlockList);
	}

	public int TryGetCaravanIdByTypeAndLevel(sbyte merchantType, sbyte level, int goodIndex, int goodCount)
	{
		foreach (KeyValuePair<int, MerchantData> pair in _caravanData)
		{
			if (pair.Value.MerchantType != merchantType || pair.Value.MerchantConfig.Level != level || pair.Value.GetGoodsList(goodIndex).Items.Keys.Count < goodCount)
			{
				continue;
			}
			return pair.Key;
		}
		return -1;
	}

	public void DeleteCaravanItem(DataContext context, int caravanId, int index, ItemKey itemKey)
	{
		MerchantData caravanMerchantData = DomainManager.Merchant.GetCaravanMerchantData(context, caravanId);
		Inventory inventory = caravanMerchantData.GetGoodsList(index);
		ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
		item.RemoveOwner(ItemOwnerType.Caravan, caravanId);
		inventory.OfflineRemove(itemKey, 1);
		SetCaravanData(caravanId, caravanMerchantData, context);
	}

	[DomainMethod]
	public void GmCmd_SetCaravanInvested(DataContext context, int caravanId, bool isInvested)
	{
		if (!DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var caravanExtraData))
		{
			caravanExtraData = CreateCaravanExtraData(context, caravanId);
		}
		caravanExtraData.IsInvested = isInvested;
		DomainManager.Extra.SetCaravanExtraData(context, caravanId, caravanExtraData);
	}

	[DomainMethod]
	public void GmCmd_SetAllCaravanInvested(DataContext context, bool isInvested)
	{
		foreach (int caravanId in _caravanData.Keys)
		{
			if (!DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var caravanExtraData))
			{
				caravanExtraData = CreateCaravanExtraData(context, caravanId);
			}
			caravanExtraData.IsInvested = isInvested;
			DomainManager.Extra.SetCaravanExtraData(context, caravanId, caravanExtraData);
		}
	}

	[DomainMethod]
	public void GmCmd_SetCaravanState(DataContext context, int caravanId, sbyte caravanState)
	{
		if (!DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var caravanExtraData))
		{
			caravanExtraData = CreateCaravanExtraData(context, caravanId);
		}
		caravanExtraData.State = caravanState;
		DomainManager.Extra.SetCaravanExtraData(context, caravanId, caravanExtraData);
		RefreshCaravanInTaiwuState(context);
	}

	[DomainMethod]
	public void GmCmd_SetCaravanRobbedRate(DataContext context, int caravanId, short robbedRate)
	{
		if (!DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var caravanExtraData))
		{
			caravanExtraData = CreateCaravanExtraData(context, caravanId);
		}
		caravanExtraData.RobbedRate = (short)Math.Clamp((int)robbedRate, 0, 1000);
		DomainManager.Extra.SetCaravanExtraData(context, caravanId, caravanExtraData);
	}

	[DomainMethod]
	public void GmCmd_SetCaravanIncomeData(DataContext context, int caravanId, short incomeBonus, short incomeCriticalRate, short incomeCriticalResult)
	{
		if (!DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var caravanExtraData))
		{
			caravanExtraData = CreateCaravanExtraData(context, caravanId);
		}
		caravanExtraData.IncomeBonus = (short)Math.Clamp((int)incomeBonus, 0, 1000);
		caravanExtraData.IncomeCriticalRate = (short)Math.Clamp((int)incomeCriticalRate, 0, 1000);
		short incomeCriticalResultMin = GlobalConfig.Instance.CaravanIncomeCriticalResultRange.First();
		short incomeCriticalResultMax = GlobalConfig.Instance.CaravanIncomeCriticalResultRange.Last();
		caravanExtraData.IncomeCriticalResult = (short)Math.Clamp((int)incomeCriticalResult, (int)incomeCriticalResultMin, (int)incomeCriticalResultMax);
		DomainManager.Extra.SetCaravanExtraData(context, caravanId, caravanExtraData);
	}

	[DomainMethod]
	public void GmCmd_ProtectCaravan(DataContext context, int caravanId)
	{
		if (DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var caravanExtraData) && caravanExtraData.RobbedRate != 0)
		{
			int time = DomainManager.World.GetCurrDate();
			caravanExtraData.RobbedRate /= 2;
			DomainManager.Extra.SetCaravanExtraData(context, caravanId, caravanExtraData);
			DomainManager.Extra.SetProtectCaravanTime(time, context);
		}
	}

	[DomainMethod]
	public void GmCmd_ProtectAllCaravan(DataContext context)
	{
		foreach (int caravanId in _caravanData.Keys)
		{
			if (DomainManager.Extra.TryGetCaravanExtraData(caravanId, out var caravanExtraData) && caravanExtraData.RobbedRate != 0)
			{
				caravanExtraData.RobbedRate /= 2;
				DomainManager.Extra.SetCaravanExtraData(context, caravanId, caravanExtraData);
			}
		}
		int time = DomainManager.World.GetCurrDate();
		DomainManager.Extra.SetProtectCaravanTime(time, context);
	}

	public bool TryGetMerchantExpData(int charId, out MerchantExpData merchantExpData)
	{
		return TryGetElement_MerchantExpData(charId, out merchantExpData);
	}

	public MerchantExpData GetMerchantExpData(DataContext context, int charId, bool allowCreate = false)
	{
		if (TryGetMerchantExpData(charId, out var data))
		{
			return data;
		}
		if (!allowCreate)
		{
			return null;
		}
		sbyte merchantLevel = GetMerchantLevel(charId);
		if (merchantLevel >= 0)
		{
			data = new MerchantExpData(charId, merchantLevel);
			SetMerchantExpData(context, charId, data);
			return data;
		}
		return null;
	}

	public void SetMerchantExpData(DataContext context, int charId, MerchantExpData merchantExpData)
	{
		if (TryGetElement_MerchantExpData(charId, out var _))
		{
			SetElement_MerchantExpData(charId, merchantExpData, context);
		}
		else
		{
			AddElement_MerchantExpData(charId, merchantExpData, context);
		}
	}

	public void RemoveMerchantExpData(DataContext context, int charId)
	{
		RemoveElement_MerchantExpData(charId, context);
	}

	public void ClearAllMerchantExpData(DataContext context)
	{
		ClearMerchantExpData(context);
	}

	[DomainMethod]
	public void GmCmd_SetMerchantExp(DataContext context, int charId, sbyte merchantType, int value)
	{
		sbyte merchantLevel = GetMerchantLevel(charId);
		if (!TryGetMerchantExpData(charId, out var data) && merchantLevel >= 0)
		{
			data = new MerchantExpData(charId, merchantLevel);
		}
		data.SetFavorability(merchantType, value);
		SetMerchantExpData(context, charId, data);
	}

	[DomainMethod]
	public int GmCmd_GetMerchantExp(int charId, sbyte merchantType)
	{
		if (!TryGetMerchantExpData(charId, out var data))
		{
			return 0;
		}
		return data.GetFavorability(merchantType);
	}

	[DomainMethod]
	public int GmCmd_GetMerchantLevel(int charId, sbyte merchantType)
	{
		if (!TryGetMerchantExpData(charId, out var data))
		{
			return 0;
		}
		return data.GetMerchantLevel(merchantType);
	}

	public MerchantDomain()
		: base(8)
	{
		_merchantData = new Dictionary<int, MerchantData>(0);
		_merchantFavorability = new int[7];
		_merchantMoney = new int[7];
		_merchantMaxLevelData = new MerchantData[7];
		_nextCaravanId = 0;
		_caravanData = new Dictionary<int, MerchantData>(0);
		_caravanDict = new Dictionary<int, CaravanPath>(0);
		_merchantExpData = new Dictionary<int, MerchantExpData>(0);
		OnInitializedDomainData();
	}

	private MerchantData GetElement_MerchantData(int elementId)
	{
		return _merchantData[elementId];
	}

	private bool TryGetElement_MerchantData(int elementId, out MerchantData value)
	{
		return _merchantData.TryGetValue(elementId, out value);
	}

	private void AddElement_MerchantData(int elementId, MerchantData value, DataContext context)
	{
		_merchantData.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void SetElement_MerchantData(int elementId, MerchantData value, DataContext context)
	{
		_merchantData[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_MerchantData(int elementId, DataContext context)
	{
		_merchantData.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void ClearMerchantData(DataContext context)
	{
		_merchantData.Clear();
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	public int[] GetMerchantFavorability()
	{
		return _merchantFavorability;
	}

	public void SetMerchantFavorability(int[] value, DataContext context)
	{
		_merchantFavorability = value;
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	public int[] GetMerchantMoney()
	{
		return _merchantMoney;
	}

	public void SetMerchantMoney(int[] value, DataContext context)
	{
		_merchantMoney = value;
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	public MerchantData GetElement_MerchantMaxLevelData(int index)
	{
		return _merchantMaxLevelData[index];
	}

	public void SetElement_MerchantMaxLevelData(int index, MerchantData value, DataContext context)
	{
		_merchantMaxLevelData[index] = value;
		SetModifiedAndInvalidateInfluencedCache(index, _dataStatesMerchantMaxLevelData, CacheInfluencesMerchantMaxLevelData, context);
	}

	private int GetNextCaravanId()
	{
		return _nextCaravanId;
	}

	private void SetNextCaravanId(int value, DataContext context)
	{
		_nextCaravanId = value;
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	private MerchantData GetElement_CaravanData(int elementId)
	{
		return _caravanData[elementId];
	}

	private bool TryGetElement_CaravanData(int elementId, out MerchantData value)
	{
		return _caravanData.TryGetValue(elementId, out value);
	}

	private void AddElement_CaravanData(int elementId, MerchantData value, DataContext context)
	{
		_caravanData.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void SetElement_CaravanData(int elementId, MerchantData value, DataContext context)
	{
		_caravanData[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_CaravanData(int elementId, DataContext context)
	{
		_caravanData.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void ClearCaravanData(DataContext context)
	{
		_caravanData.Clear();
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private CaravanPath GetElement_CaravanDict(int elementId)
	{
		return _caravanDict[elementId];
	}

	private bool TryGetElement_CaravanDict(int elementId, out CaravanPath value)
	{
		return _caravanDict.TryGetValue(elementId, out value);
	}

	private void AddElement_CaravanDict(int elementId, CaravanPath value, DataContext context)
	{
		_caravanDict.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private void SetElement_CaravanDict(int elementId, CaravanPath value, DataContext context)
	{
		_caravanDict[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_CaravanDict(int elementId, DataContext context)
	{
		_caravanDict.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private void ClearCaravanDict(DataContext context)
	{
		_caravanDict.Clear();
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private MerchantExpData GetElement_MerchantExpData(int elementId)
	{
		return _merchantExpData[elementId];
	}

	private bool TryGetElement_MerchantExpData(int elementId, out MerchantExpData value)
	{
		return _merchantExpData.TryGetValue(elementId, out value);
	}

	private void AddElement_MerchantExpData(int elementId, MerchantExpData value, DataContext context)
	{
		_merchantExpData.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void SetElement_MerchantExpData(int elementId, MerchantExpData value, DataContext context)
	{
		_merchantExpData[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_MerchantExpData(int elementId, DataContext context)
	{
		_merchantExpData.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void ClearMerchantExpData(DataContext context)
	{
		_merchantExpData.Clear();
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
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
		archive.WriteDomainDataMeta(0);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_merchantData);
		archive.WriteDomainDataMeta(1);
		archive.WriteSingleValueUnmanagedArray(_merchantFavorability);
		archive.WriteDomainDataMeta(2);
		archive.WriteSingleValueUnmanagedArray(_merchantMoney);
		archive.WriteDomainDataMeta(3);
		archive.WriteElementListCustom(_merchantMaxLevelData);
		archive.WriteDomainDataMeta(4);
		archive.WriteSingleValueUnmanaged(_nextCaravanId);
		archive.WriteDomainDataMeta(5);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_caravanData);
		archive.WriteDomainDataMeta(6);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_caravanDict);
		archive.WriteDomainDataMeta(7);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_merchantExpData);
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
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_merchantData);
				break;
			case 1:
				archive.ReadSingleValueUnmanagedArray(ref _merchantFavorability);
				break;
			case 2:
				archive.ReadSingleValueUnmanagedArray(ref _merchantMoney);
				break;
			case 3:
				archive.ReadElementListCustom(_merchantMaxLevelData);
				break;
			case 4:
				archive.ReadSingleValueUnmanaged(ref _nextCaravanId);
				break;
			case 5:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_caravanData);
				break;
			case 6:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_caravanDict);
				break;
			case 7:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_merchantExpData);
				break;
			default:
				throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
			}
			RecordLoadedDomainData(domainDataMeta.DataId);
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(14);
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
			return GameData.Serializer.Serializer.Serialize(_merchantFavorability, dataPool);
		case 2:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
			}
			return GameData.Serializer.Serializer.Serialize(_merchantMoney, dataPool);
		case 3:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(_dataStatesMerchantMaxLevelData, (int)subId0);
			}
			return GameData.Serializer.Serializer.Serialize(_merchantMaxLevelData[(uint)subId0], dataPool);
		case 4:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 5:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 6:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 7:
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
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _merchantFavorability);
			SetMerchantFavorability(_merchantFavorability, context);
			break;
		case 2:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _merchantMoney);
			SetMerchantMoney(_merchantMoney, context);
			break;
		case 3:
		{
			MerchantData value = _merchantMaxLevelData[(uint)subId0];
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			_merchantMaxLevelData[(uint)subId0] = value;
			SetElement_MerchantMaxLevelData((int)subId0, value, context);
			break;
		}
		case 4:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 5:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 6:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 7:
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
			int argsCount15 = operation.ArgsCount;
			int num15 = argsCount15;
			if (num15 == 1)
			{
				int charId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId7);
				MerchantData returnValue8 = GetMerchantData(context, charId7);
				return GameData.Serializer.Serializer.Serialize(returnValue8, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 1)
			{
				MerchantTradeArguments merchantTradeArguments = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantTradeArguments);
				SettleTrade(context, merchantTradeArguments);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
		{
			int argsCount19 = operation.ArgsCount;
			int num19 = argsCount19;
			if (num19 == 5)
			{
				int npcId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref npcId);
				List<ItemDisplayData> boughtItems = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref boughtItems);
				List<ItemDisplayData> soldItems = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref soldItems);
				int selfAuthority = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref selfAuthority);
				int npcAuthority = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref npcAuthority);
				ExchangeBook(context, npcId, boughtItems, soldItems, selfAuthority, npcAuthority);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 3:
			if (operation.ArgsCount == 0)
			{
				PullTradeCaravanLocations(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 4:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 1)
			{
				int caravanId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref caravanId2);
				MerchantData returnValue4 = GetCaravanMerchantData(context, caravanId2);
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 5:
		{
			int argsCount25 = operation.ArgsCount;
			int num25 = argsCount25;
			if (num25 == 2)
			{
				int npcId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref npcId2);
				bool isFavor2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isFavor2);
				List<ItemDisplayData> returnValue21 = GetTradeBookDisplayData(context, npcId2, isFavor2);
				return GameData.Serializer.Serializer.Serialize(returnValue21, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 6:
		{
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 5)
			{
				int charId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId4);
				sbyte itemType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemType);
				short templateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId);
				int count = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count);
				int level = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref level);
				GmCmd_AddItem(context, charId4, itemType, templateId, count, level);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 7:
			if (operation.ArgsCount == 0)
			{
				List<int> returnValue23 = GetTaiwuLocationMaxLevelCaravanIdList();
				return GameData.Serializer.Serializer.Serialize(returnValue23, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 8:
		{
			int argsCount22 = operation.ArgsCount;
			int num22 = argsCount22;
			if (num22 == 1)
			{
				sbyte merchantType9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantType9);
				int returnValue16 = GetCurFavorability(merchantType9);
				return GameData.Serializer.Serializer.Serialize(returnValue16, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 9:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 2)
			{
				int charId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId6);
				bool isFavor = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isFavor);
				FinishBookTrade(context, charId6, isFavor);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 10:
			if (operation.ArgsCount == 0)
			{
				List<ItemDisplayData> returnValue = GetTradeBackBookDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 11:
		{
			int argsCount28 = operation.ArgsCount;
			int num28 = argsCount28;
			if (num28 == 1)
			{
				sbyte merchantType11 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantType11);
				List<MerchantInfoCaravanData> returnValue22 = GetMerchantInfoCaravanDataList(context, merchantType11);
				return GameData.Serializer.Serializer.Serialize(returnValue22, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
		{
			int argsCount24 = operation.ArgsCount;
			int num24 = argsCount24;
			if (num24 == 1)
			{
				sbyte merchantType10 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantType10);
				List<MerchantInfoAreaData> returnValue18 = GetMerchantInfoAreaDataList(merchantType10);
				return GameData.Serializer.Serializer.Serialize(returnValue18, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 13:
		{
			int argsCount18 = operation.ArgsCount;
			int num18 = argsCount18;
			if (num18 == 1)
			{
				sbyte merchantType8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantType8);
				List<MerchantInfoMerchantData> returnValue14 = GetMerchantInfoMerchantDataList(merchantType8);
				return GameData.Serializer.Serializer.Serialize(returnValue14, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 14:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 1)
			{
				sbyte merchantType4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantType4);
				MerchantOverFavorData returnValue6 = GetMerchantOverFavorData(merchantType4);
				return GameData.Serializer.Serializer.Serialize(returnValue6, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 15:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 2)
			{
				sbyte merchantType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantType);
				bool isHead = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isHead);
				MerchantData returnValue2 = GetBuildingMerchantData(context, merchantType, isHead);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 16:
		{
			int argsCount30 = operation.ArgsCount;
			int num30 = argsCount30;
			if (num30 == 1)
			{
				int caravanId9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref caravanId9);
				CaravanDisplayData returnValue24 = GetCaravanDisplayData(context, caravanId9);
				return GameData.Serializer.Serializer.Serialize(returnValue24, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 17:
		{
			int argsCount27 = operation.ArgsCount;
			int num27 = argsCount27;
			if (num27 == 1)
			{
				int caravanId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref caravanId7);
				InvestCaravan(context, caravanId7);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 18:
			if (operation.ArgsCount == 0)
			{
				int[] returnValue19 = GetAllFavorability();
				return GameData.Serializer.Serializer.Serialize(returnValue19, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 19:
		{
			int argsCount21 = operation.ArgsCount;
			int num21 = argsCount21;
			if (num21 == 1)
			{
				int caravanId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref caravanId5);
				ProtectCaravan(context, caravanId5);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 20:
		{
			int argsCount16 = operation.ArgsCount;
			int num16 = argsCount16;
			if (num16 == 1)
			{
				int caravanId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref caravanId4);
				GmCmd_ProtectCaravan(context, caravanId4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 21:
			if (operation.ArgsCount == 0)
			{
				GmCmd_ProtectAllCaravan(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 22:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 2)
			{
				int caravanId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref caravanId3);
				short robbedRate = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref robbedRate);
				GmCmd_SetCaravanRobbedRate(context, caravanId3, robbedRate);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 23:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 2)
			{
				int caravanId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref caravanId);
				bool isInvested = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isInvested);
				GmCmd_SetCaravanInvested(context, caravanId, isInvested);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 24:
		{
			int argsCount31 = operation.ArgsCount;
			int num31 = argsCount31;
			if (num31 == 1)
			{
				bool isInvested2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isInvested2);
				GmCmd_SetAllCaravanInvested(context, isInvested2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 25:
		{
			int argsCount29 = operation.ArgsCount;
			int num29 = argsCount29;
			if (num29 == 2)
			{
				int caravanId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref caravanId8);
				sbyte caravanState = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref caravanState);
				GmCmd_SetCaravanState(context, caravanId8, caravanState);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 26:
		{
			int argsCount26 = operation.ArgsCount;
			int num26 = argsCount26;
			if (num26 == 4)
			{
				int caravanId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref caravanId6);
				short incomeBonus = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref incomeBonus);
				short incomeCriticalRate = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref incomeCriticalRate);
				short incomeCriticalResult = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref incomeCriticalResult);
				GmCmd_SetCaravanIncomeData(context, caravanId6, incomeBonus, incomeCriticalRate, incomeCriticalResult);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 27:
			if (operation.ArgsCount == 0)
			{
				SectStorySpecialMerchant returnValue20 = GetSectStorySpecialMerchantData(context);
				return GameData.Serializer.Serializer.Serialize(returnValue20, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 28:
		{
			int argsCount23 = operation.ArgsCount;
			int num23 = argsCount23;
			if (num23 == 1)
			{
				int charId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId8);
				sbyte returnValue17 = GetMerchantTemplateId(charId8);
				return GameData.Serializer.Serializer.Serialize(returnValue17, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 29:
		{
			int argsCount20 = operation.ArgsCount;
			int num20 = argsCount20;
			if (num20 == 1)
			{
				OpenShopEventArguments openShopEventArguments = new OpenShopEventArguments();
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref openShopEventArguments);
				MerchantBuyBackData returnValue15 = GetMerchantBuyBackData(openShopEventArguments);
				return GameData.Serializer.Serializer.Serialize(returnValue15, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 30:
		{
			int argsCount17 = operation.ArgsCount;
			int num17 = argsCount17;
			if (num17 == 6)
			{
				int charOrCaravanId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charOrCaravanId);
				bool isChar = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isChar);
				sbyte level2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref level2);
				bool isFromBuilding = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isFromBuilding);
				bool isHeadBuildingMerchant = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isHeadBuildingMerchant);
				sbyte buildingMerchantType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref buildingMerchantType);
				bool returnValue13 = RefreshMerchantGoods(context, charOrCaravanId, isChar, level2, isFromBuilding, isHeadBuildingMerchant, buildingMerchantType);
				return GameData.Serializer.Serializer.Serialize(returnValue13, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 31:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				sbyte merchantType7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantType7);
				int returnValue12 = GetFavorabilityWithDelta(merchantType7);
				return GameData.Serializer.Serializer.Serialize(returnValue12, returnDataPool);
			}
			case 2:
			{
				sbyte merchantType6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantType6);
				int delta = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref delta);
				int returnValue11 = GetFavorabilityWithDelta(merchantType6, delta);
				return GameData.Serializer.Serializer.Serialize(returnValue11, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 32:
			switch (operation.ArgsCount)
			{
			case 0:
			{
				bool returnValue10 = CanRefreshMerchantGoods(context);
				return GameData.Serializer.Serializer.Serialize(returnValue10, returnDataPool);
			}
			case 1:
			{
				bool consume = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref consume);
				bool returnValue9 = CanRefreshMerchantGoods(context, consume);
				return GameData.Serializer.Serializer.Serialize(returnValue9, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 33:
		{
			int argsCount14 = operation.ArgsCount;
			int num14 = argsCount14;
			if (num14 == 1)
			{
				int targetCaravanId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetCaravanId);
				MerchantInfoCaravanData returnValue7 = GetMerchantInfoCaravanDataSingle(context, targetCaravanId);
				return GameData.Serializer.Serializer.Serialize(returnValue7, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 34:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 3)
			{
				int charId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId5);
				sbyte merchantType5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantType5);
				int value = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value);
				GmCmd_SetMerchantExp(context, charId5, merchantType5, value);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 35:
		{
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 2)
			{
				int charId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId3);
				sbyte merchantType3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantType3);
				int returnValue5 = GmCmd_GetMerchantExp(charId3, merchantType3);
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 36:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 2)
			{
				int charId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId2);
				sbyte merchantType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantType2);
				int returnValue3 = GmCmd_GetMerchantLevel(charId2, merchantType2);
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 37:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 1)
			{
				int merchantId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref merchantId);
				GmCmd_RemoveMerchantData(context, merchantId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 38:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 2)
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				sbyte type = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref type);
				GmCmd_SetMerchantCharToType(context, charId, type);
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
			if (!BaseGameDataDomain.IsModified(DataStates, 1))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 1);
			return GameData.Serializer.Serializer.Serialize(_merchantFavorability, dataPool);
		case 2:
			if (!BaseGameDataDomain.IsModified(DataStates, 2))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 2);
			return GameData.Serializer.Serializer.Serialize(_merchantMoney, dataPool);
		case 3:
			if (!BaseGameDataDomain.IsModified(_dataStatesMerchantMaxLevelData, (int)subId0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(_dataStatesMerchantMaxLevelData, (int)subId0);
			return GameData.Serializer.Serializer.Serialize(_merchantMaxLevelData[(uint)subId0], dataPool);
		case 4:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 5:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 6:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 7:
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
			if (BaseGameDataDomain.IsModified(_dataStatesMerchantMaxLevelData, (int)subId0))
			{
				BaseGameDataDomain.ResetModified(_dataStatesMerchantMaxLevelData, (int)subId0);
			}
			break;
		case 4:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 5:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 6:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 7:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
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
			3 => BaseGameDataDomain.IsModified(_dataStatesMerchantMaxLevelData, (int)subId0), 
			4 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			5 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			6 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			7 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
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
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
	}
}
