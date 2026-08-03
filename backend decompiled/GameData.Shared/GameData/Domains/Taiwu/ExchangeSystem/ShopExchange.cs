using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.DLC.FiveLoong;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Extra;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.Merchant;
using GameData.Domains.World;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.ExchangeSystem;

/// <summary>
/// 对于引用类型字段, 构造函数中可以不创建对象, 保留默认的 null 值.
/// 在进行反序列化时, 允许所有引用类型字段都为 null.
/// 但是在序列化时, 要求所有是定长集合的引用字段都已经被创建, 且长度与定义一致. 集合中的引用类型元素若也为定长, 则也必须被创建; 变长的则可以为 null.
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true, NotRestrictCollectionSerializedSize = true)]
public class ShopExchange : Exchange
{
	[SerializableGameDataField]
	public bool IsGift;

	/// <summary>
	/// 商会好感
	/// </summary>
	[SerializableGameDataField]
	public int CumulativeMoney;

	/// <summary>
	/// 商会交易数据
	/// </summary>
	[SerializableGameDataField]
	public MerchantTradeArguments TradeArguments;

	[SerializableGameDataField]
	public MerchantExtraGoodsData ExtraGoodsData;

	[SerializableGameDataField]
	public CharacterDisplayData MerchantCharData;

	/// <summary>
	/// 原始商会超好感数据
	/// </summary>
	[SerializableGameDataField]
	public MerchantOverFavorData MerchantOverFavorData;

	/// <summary>
	/// 物品变化数据的字典
	/// </summary>
	public readonly Dictionary<ItemSourceType, ItemSourceChange> ItemChangeDict = new Dictionary<ItemSourceType, ItemSourceChange>
	{
		{
			ItemSourceType.Inventory,
			new ItemSourceChange(ItemSourceType.Inventory)
		},
		{
			ItemSourceType.Warehouse,
			new ItemSourceChange(ItemSourceType.Warehouse)
		},
		{
			ItemSourceType.Treasury,
			new ItemSourceChange(ItemSourceType.Treasury)
		},
		{
			ItemSourceType.Stock,
			new ItemSourceChange(ItemSourceType.Stock)
		},
		{
			ItemSourceType.Equipment,
			new ItemSourceChange(ItemSourceType.Equipment)
		},
		{
			ItemSourceType.Shop0,
			new ItemSourceChange(ItemSourceType.Shop0)
		},
		{
			ItemSourceType.Shop1,
			new ItemSourceChange(ItemSourceType.Shop1)
		},
		{
			ItemSourceType.Shop2,
			new ItemSourceChange(ItemSourceType.Shop2)
		},
		{
			ItemSourceType.Shop3,
			new ItemSourceChange(ItemSourceType.Shop3)
		},
		{
			ItemSourceType.Shop4,
			new ItemSourceChange(ItemSourceType.Shop4)
		},
		{
			ItemSourceType.Shop5,
			new ItemSourceChange(ItemSourceType.Shop5)
		},
		{
			ItemSourceType.Shop6,
			new ItemSourceChange(ItemSourceType.Shop6)
		},
		{
			ItemSourceType.BuyBack,
			new ItemSourceChange(ItemSourceType.BuyBack)
		}
	};

	private long _price;

	private bool _isShopItem;

	private bool _isBuyItem;

	private bool _isBuyBackItem;

	public MerchantData MerchantData => TradeArguments.MerchantData;

	public int MerchantFavor => GetFavorability(CumulativeMoney);

	public int FavorabilityWithDelta => GetFavorabilityWithDelta(CumulativeMoney, BuyMoney);

	public long BuyMoney
	{
		get
		{
			if (!IsGift)
			{
				return TradeArguments.BuyMoney;
			}
			return TaiwuTotalValue;
		}
	}

	public override bool CanConfirmExchange
	{
		get
		{
			if (base.CanConfirmExchange)
			{
				return DebtEnough;
			}
			return false;
		}
	}

	/// <summary>
	/// 恩义足够交易
	/// </summary>
	public bool DebtEnough => TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.All((MerchantOverFavorLevelData x) => (x?.BuyCount ?? 0) >= 0);

	public int MinDebtLevel
	{
		get
		{
			IsMerchantFavorabilityReachProgressLimit(MerchantFavor, out var _, out var favor);
			return GameData.Domains.Merchant.SharedMethods.GetFavorLevel(Math.Min(MerchantFavor, favor));
		}
	}

	public int MaxDebtLevel
	{
		get
		{
			if (!IsGift)
			{
				return MerchantData.MerchantLevel;
			}
			return 6;
		}
	}

	public bool IsAreaDebtShop => TradeArguments.MerchantData?.MerchantType == 8;

	public ShopExchange()
	{
		AdvantageSummary = new ExchangeAdvantage();
	}

	public override long CalcBaseValue(ITradeableContent content)
	{
		if (!(content is ItemDisplayData itemData))
		{
			return content.Value;
		}
		return GetItemPrice(itemData, IsShopItem(content));
	}

	/// <summary>
	/// 检查当前页是否显示
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public bool IsPageShow(int index)
	{
		if (IsGift)
		{
			return true;
		}
		if (MerchantData == null)
		{
			return false;
		}
		MerchantItem merchantConfig = Config.Merchant.Instance[MerchantData.MerchantTemplateId];
		MerchantItem merchantItem = Config.Merchant.Instance[merchantConfig.GroupId];
		sbyte goodsLevelMax = merchantConfig.Level;
		sbyte goodLevelMin = merchantItem.Level;
		if (index >= goodLevelMin)
		{
			return index <= goodsLevelMax;
		}
		return false;
	}

	/// <summary>
	/// 获取基础偿还等级
	/// </summary>
	/// <param name="itemKey"></param>
	/// <returns></returns>
	public static int GetBaseRepayLevel(ItemKey itemKey)
	{
		if (ItemTemplateHelper.GetBaseFavorabilityChange(itemKey.ItemType, itemKey.TemplateId) * 10 <= 0 && (itemKey.ItemType != 12 || itemKey.TemplateId != 380))
		{
			return -1;
		}
		return ItemTemplateHelper.GetMerchantLevel(itemKey.ItemType, itemKey.TemplateId);
	}

	/// <summary>
	/// 获取偿还的等级
	/// </summary>
	private int GetRepayLevel(ItemKey itemKey)
	{
		for (int i = Math.Min(GetBaseRepayLevel(itemKey), Math.Min(MaxDebtLevel, TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.Length - 1)); i >= 0; i--)
		{
			short buyCount = TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray[i].BuyCount;
			short maxBuyCount = GetMaxBuyCount(i);
			if (IsPageShow(i) && buyCount < maxBuyCount && maxBuyCount < short.MaxValue)
			{
				return i;
			}
		}
		return -1;
	}

	/// <summary>
	/// 获取超限购买次数的上限
	/// </summary>
	/// <param name="merchantLevel"></param>
	/// <returns></returns>
	public static short GetMaxBuyCount(int merchantLevel)
	{
		short maxBuyCount = GlobalConfig.Instance.MerchantOverFavorBuyCount[merchantLevel];
		if (maxBuyCount < 0)
		{
			maxBuyCount = short.MaxValue;
		}
		return maxBuyCount;
	}

	/// <summary>
	/// 是否为七宝号印
	/// </summary>
	/// <param name="itemKey"></param>
	/// <returns></returns>
	public static bool IsSealOfMerchant(ItemKey itemKey)
	{
		return itemKey.TemplateEquals(12, 380);
	}

	protected void Summarize(ItemKey key, int count)
	{
		long money = _price * count;
		MerchantTradeArguments tradeArguments = TradeArguments;
		if (tradeArguments.TradeMoneySources == null)
		{
			tradeArguments.TradeMoneySources = new Dictionary<ItemKey, long>();
		}
		TradeArguments.TradeMoneySources[key] = TradeArguments.TradeMoneySources.GetValueOrDefault(key, 0L) - money;
		if (_isShopItem)
		{
			TradeArguments.BuyMoney += money;
		}
		if (_isBuyBackItem)
		{
			TradeArguments.SoldMoney -= money;
		}
		if (!_isBuyItem)
		{
			TradeArguments.SoldMoney -= money;
		}
	}

	public static bool IsShopItem(ITradeableContent content)
	{
		return IsShopItem((ItemSourceType)content.ItemSourceType);
	}

	public static bool IsShopItem(ItemSourceType itemSourceType)
	{
		if ((uint)(itemSourceType - 10) <= 6u)
		{
			return true;
		}
		return false;
	}

	public static bool IsBuyBackItem(ITradeableContent content)
	{
		return content.ItemSourceType == 17;
	}

	public static bool IsBuyItem(ITradeableContent content)
	{
		ItemSourceType itemSourceType = (ItemSourceType)content.ItemSourceType;
		if ((uint)(itemSourceType - 10) <= 7u)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 计算交易逻辑，在商店交易前调用，调用后必须直接settleTrade并弃用这个ShopExchange对象
	/// </summary>
	public void Deal()
	{
		ItemKey key;
		int value;
		foreach (ExchangeItem exchanged in ExchangeItemList)
		{
			_price = ((exchanged.Content is ItemDisplayData data) ? GetItemPrice(data, data.OwnerCharId != TaiwuCharId) : exchanged.Content.Value);
			_isShopItem = IsShopItem(exchanged.Content);
			_isBuyItem = IsBuyItem(exchanged.Content);
			_isBuyBackItem = IsBuyBackItem(exchanged.Content);
			foreach (KeyValuePair<ItemKey, int> item in exchanged.Inventory.Items)
			{
				item.Deconstruct(out key, out value);
				ItemKey key2 = key;
				int value2 = value;
				Summarize(key2, value2 * Math.Sign(exchanged.Count));
			}
		}
		foreach (ExchangeItem exchangeItem in ExchangeItemList)
		{
			ITradeableContent content = exchangeItem.Content;
			Inventory inventory = exchangeItem.Inventory;
			int priceChange = ((!IsBuyBackItem(content)) ? GetPriceChangePercentValue(content, IsBuyItem(content)) : 0);
			if (IsBuyItem(content))
			{
				ItemSourceChange change = ItemChangeDict[base.ToItemSourceTypeEnum];
				foreach (KeyValuePair<ItemKey, int> item2 in inventory.Items)
				{
					item2.Deconstruct(out key, out value);
					ItemKey key3 = key;
					int count = value;
					change.AddItem(key3, count, priceChange);
				}
				if (content.ItemSourceType == 17)
				{
					foreach (KeyValuePair<ItemKey, int> item3 in inventory.Items)
					{
						item3.Deconstruct(out key, out value);
						ItemKey key4 = key;
						int count2 = value;
						TradeArguments.MerchantBuyBackData.BuyInGoodsList.OfflineRemove(key4, count2);
						if (!TradeArguments.MerchantBuyBackData.BuyInGoodsList.Items.ContainsKey(key4))
						{
							TradeArguments.MerchantBuyBackData.BuyInPrice.Remove(key4);
						}
					}
				}
				else
				{
					TradeArguments.MerchantData.GetGoodsList(content.ItemSourceType - 10).OfflineRemove(inventory);
				}
				continue;
			}
			ItemSourceChange change2 = ItemChangeDict[(ItemSourceType)content.ItemSourceType];
			foreach (KeyValuePair<ItemKey, int> item4 in inventory.Items)
			{
				item4.Deconstruct(out key, out value);
				ItemKey key5 = key;
				int count3 = value;
				change2.RemoveItem(key5, count3, priceChange);
			}
			foreach (KeyValuePair<ItemKey, int> item5 in inventory.Items)
			{
				item5.Deconstruct(out key, out value);
				ItemKey key6 = key;
				int count4 = value;
				MerchantTradeArguments tradeArguments = TradeArguments;
				(tradeArguments.MerchantBuyBackData ?? (tradeArguments.MerchantBuyBackData = new MerchantBuyBackData())).BuyInGoodsList.OfflineAdd(key6, count4);
				if (!TradeArguments.MerchantBuyBackData.BuyInPrice.ContainsKey(key6))
				{
					TradeArguments.MerchantBuyBackData.BuyInPrice[key6] = Math.Abs(content.Value / content.Amount);
				}
			}
		}
		TradeArguments.ItemChangeList = ItemChangeDict.Values.ToList();
	}

	/// <summary>
	/// 商会好感是否达到精纯限制
	/// </summary>
	/// <param name="merchantFavorability">原始好感，仅影响返回值</param>
	/// <param name="worldProgressLimitedLevel">返回：好感等级阈值</param>
	/// <param name="worldProgressLimitedFavor">返回：好感阈值</param>
	/// <returns>原始好感是否达到限制</returns>
	public static bool IsMerchantFavorabilityReachProgressLimit(int merchantFavorability, out int worldProgressLimitedLevel, out int worldProgressLimitedFavor)
	{
		sbyte worldProgress = ExternalDataBridge.Context.XiangshuProgress;
		int length = GlobalConfig.Instance.MerchantFavorabilityXiangshuLevelRequirements.Length;
		int overIndex = length;
		for (int i = 0; i < length; i++)
		{
			if (GlobalConfig.Instance.MerchantFavorabilityXiangshuLevelRequirements[i] > worldProgress)
			{
				overIndex = i;
				break;
			}
		}
		worldProgressLimitedFavor = overIndex * 10;
		worldProgressLimitedLevel = GameData.Domains.Merchant.SharedMethods.GetFavorLevel(worldProgressLimitedFavor);
		return merchantFavorability >= worldProgressLimitedFavor;
	}

	/// <summary>
	/// 刷新恩义，返回需要显示恩义icon的最低等级
	/// </summary>
	/// <returns>需要显示恩义icon的最低等级</returns>
	public int RefreshDebt()
	{
		if (IsGift)
		{
			return RefreshGiftDebt();
		}
		int minLevel = MinDebtLevel;
		int maxLevel = MaxDebtLevel;
		int i;
		for (i = 0; i < Math.Min(TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.Length, minLevel); i++)
		{
			SetLevelValue(i, short.MaxValue);
		}
		for (; i < TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.Length; i++)
		{
			short defaultValue = GetMaxBuyCount(i);
			int level = i;
			MerchantOverFavorData merchantOverFavorData = MerchantOverFavorData;
			SetLevelValue(level, Math.Min(((merchantOverFavorData != null) ? merchantOverFavorData.MerchantOverFavorLevelDataArray[i]?.BuyCount : ((short?)null)) ?? defaultValue, defaultValue));
		}
		foreach (ITradeableContent item in base.TargetContentList)
		{
			ChangeLevelValue(IsShopItem(item) ? (item.ItemSourceType - 10) : (-1), (short)(-item.Amount));
		}
		int debtLevel;
		for (debtLevel = minLevel; debtLevel < TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.Length; debtLevel++)
		{
			MerchantOverFavorLevelData data = TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray[debtLevel];
			if (data != null && data.BuyCount < GetMaxBuyCount(debtLevel))
			{
				break;
			}
		}
		if (debtLevel != TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.Length)
		{
			return debtLevel;
		}
		return int.MaxValue;
		short ChangeLevelValue(int num, short delta)
		{
			num = Math.Min(maxLevel, num);
			if (num > minLevel && TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.CheckIndex(num))
			{
				MerchantOverFavorLevelData data2 = TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray[num];
				if (data2 != null && data2.BuyCount != short.MaxValue)
				{
					data2.BuyCount += delta;
					short maxBuyCount = GetMaxBuyCount(num);
					delta = (short)(data2.BuyCount - GetMaxBuyCount(num));
					if (delta >= 0)
					{
						data2.BuyCount = maxBuyCount;
						return delta;
					}
				}
			}
			return delta;
		}
		void SetLevelValue(int num, short value)
		{
			if (num > minLevel && TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.CheckIndex(num))
			{
				MerchantOverFavorLevelData data2 = TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray[num];
				if (data2 != null)
				{
					data2.BuyCount = value;
				}
				else
				{
					TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray[num] = new MerchantOverFavorLevelData
					{
						BuyCount = value
					};
				}
			}
		}
	}

	/// <summary>
	/// 刷新恩义，返回需要显示恩义icon的最低等级
	/// </summary>
	/// <returns>需要显示恩义icon的最低等级</returns>
	public int RefreshGiftDebt()
	{
		int minLevel = MinDebtLevel;
		int maxLevel = MaxDebtLevel;
		if (ExchangeItemList.Any((ExchangeItem x) => x.Count < 0 && IsSealOfMerchant(x.Content.Key)))
		{
			int idx = TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.Length;
			while (idx-- > 0)
			{
				SetLevelValue(idx, GetMaxBuyCount(idx));
			}
			return int.MaxValue;
		}
		int i;
		for (i = 0; i < Math.Min(TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.Length, minLevel); i++)
		{
			SetLevelValue(i, short.MaxValue);
		}
		for (; i < TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.Length; i++)
		{
			short defaultValue = GetMaxBuyCount(i);
			int level = i;
			MerchantOverFavorData merchantOverFavorData = MerchantOverFavorData;
			SetLevelValue(level, Math.Min(((merchantOverFavorData != null) ? merchantOverFavorData.MerchantOverFavorLevelDataArray[i]?.BuyCount : ((short?)null)) ?? defaultValue, defaultValue));
		}
		int debtLevel;
		for (debtLevel = minLevel; debtLevel < TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.Length; debtLevel++)
		{
			MerchantOverFavorLevelData data = TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray[debtLevel];
			if (data != null && data.BuyCount < GetMaxBuyCount(debtLevel))
			{
				break;
			}
		}
		foreach (ITradeableContent item in base.TaiwuContentList)
		{
			int currLevel = GetRepayLevel(item.Key);
			short remain = ChangeLevelValue(currLevel--, (short)item.Amount);
			while (remain > 0 && currLevel > minLevel)
			{
				remain = ChangeLevelValue(currLevel--, remain);
			}
		}
		if (debtLevel != TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.Length)
		{
			return debtLevel;
		}
		return int.MaxValue;
		short ChangeLevelValue(int num, short delta)
		{
			num = Math.Min(maxLevel, num);
			if (num > minLevel && TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.CheckIndex(num))
			{
				MerchantOverFavorLevelData data2 = TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray[num];
				if (data2 != null && data2.BuyCount != short.MaxValue)
				{
					data2.BuyCount += delta;
					short maxBuyCount = GetMaxBuyCount(num);
					delta = (short)(data2.BuyCount - GetMaxBuyCount(num));
					if (delta >= 0)
					{
						data2.BuyCount = maxBuyCount;
						return delta;
					}
				}
			}
			return delta;
		}
		void SetLevelValue(int num, short value)
		{
			if (num > minLevel && TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray.CheckIndex(num))
			{
				MerchantOverFavorLevelData data2 = TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray[num];
				if (data2 != null)
				{
					data2.BuyCount = value;
				}
				else
				{
					TradeArguments.OverFavorData.MerchantOverFavorLevelDataArray[num] = new MerchantOverFavorLevelData
					{
						BuyCount = value
					};
				}
			}
		}
	}

	public int GetItemPrice(ItemDisplayData itemData, bool isBuy, int percentValue = int.MinValue)
	{
		if (itemData.ItemSourceTypeEnum == ItemSourceType.BuyBack)
		{
			MerchantTradeArguments tradeArguments = TradeArguments;
			long value = default(long);
			if (tradeArguments != null && tradeArguments.MerchantBuyBackData?.BuyInPrice.TryGetValue(itemData.Key, out value) == true)
			{
				return (int)value;
			}
		}
		int itemBasePrice = GetItemBasePrice(itemData, isBuy);
		if (percentValue == int.MinValue)
		{
			percentValue = GetPriceChangePercentValue(itemData, isBuy);
		}
		return itemBasePrice + itemBasePrice * (itemData.PricePercent = percentValue) / 100;
	}

	/// <summary>
	/// 获取物品基础价格
	/// </summary>
	public int GetItemBasePrice(ItemDisplayData itemData, bool isBuy)
	{
		if (IsAreaDebtShop)
		{
			int price = ((ItemTemplateHelper.GetGrade(itemData.Key.ItemType, itemData.Key.TemplateId) == 6) ? 1000 : 400);
			if (!TradeArguments.OpenShopEventArguments.IgnoreFavorability)
			{
				return price;
			}
			return price / 2;
		}
		if (TradeArguments.OpenShopEventArguments.IsSettlementTreasury)
		{
			AdaptableLog.TagWarning("Shop", "SettlementTreasury is not shop.", appendWarningMessage: true);
			return 0;
		}
		int num = (isBuy ? 200 : 20);
		int worldRate = GetWorldDetailPriceRate(isBuy);
		long percentValue = (long)num * (long)worldRate / 100;
		percentValue = Math.Max(0L, percentValue);
		int value = itemData.CricketData?.CricketValue ?? ItemTemplateHelper.GetBaseValue(itemData.Key.ItemType, itemData.Key.TemplateId);
		JiaoLoongDisplayData data = itemData.JiaoLoongDisplayData;
		if (data != null)
		{
			ChildrenOfLoong loong = data.Loong;
			if (loong != null)
			{
				value = loong.Properties.Get(loong.JiaoTemplateId, loong.LoongTemplateId, 6);
			}
			else
			{
				GameData.DLC.FiveLoong.Jiao jiao = data.Jiao;
				if (jiao != null)
				{
					value = jiao.Properties.Get(jiao.TemplateId, 6);
				}
			}
		}
		return (int)(value * percentValue * (100 + (itemData.EquipmentEffectIds?.Sum((short x) => EquipmentEffect.Instance[x].ValueChange) ?? 0)) / 10000);
	}

	/// <summary>
	/// 获取世界细节对价格的影响
	/// </summary>
	/// <param name="isBuy"></param>
	/// <returns></returns>
	public int GetWorldDetailPriceRate(bool isBuy)
	{
		if (!isBuy)
		{
			return GameData.Domains.World.SharedMethods.GetGainResourcePercent(11);
		}
		return 100;
	}

	/// <summary>
	/// 检查是额外商品
	/// </summary>
	/// <returns></returns>
	public bool CheckIsExtra(int id, out MerchantExtraGoodsData.ExtraGoodsType extraGoodsType)
	{
		extraGoodsType = MerchantExtraGoodsData.ExtraGoodsType.None;
		if (TradeArguments.OpenShopEventArguments.IsSettlementTreasury)
		{
			return false;
		}
		return ExtraGoodsData?.Check(id, out extraGoodsType) ?? false;
	}

	/// <summary>
	/// 获取当前价格百分比，用的时候要除以100，注意结果可能为负值
	/// </summary>
	public int GetPricePercentValue(ITradeableContent itemData, bool isBuy)
	{
		if (IsAreaDebtShop)
		{
			return 100;
		}
		int challengeEffect = 0;
		if (isBuy && TradeArguments.MerchantData != null && itemData.ItemSourceType != 17)
		{
			int index = itemData.ItemSourceType - 10;
			challengeEffect = ExternalDataBridge.Context.ChallengeModeData.GetMerchantItemPriceBonus(index);
		}
		if (TradeArguments.OpenShopEventArguments.IsSettlementTreasury || IsAreaDebtShop)
		{
			return 100 + challengeEffect;
		}
		int createEffect = 0;
		int extraEffect = 0;
		if (isBuy)
		{
			if (itemData.ExtraGoodsType == 1)
			{
				extraEffect = 50;
			}
			else
			{
				createEffect = TradeArguments.MerchantData?.GetPriceChangePercent(itemData.Key) ?? 0;
			}
		}
		int favorabilityEffect = MerchantData.GetCharFavorabilityEffect(isBuy, MerchantCharData?.FavorabilityToTaiwu ?? 0);
		int result = (100 + createEffect + favorabilityEffect + extraEffect) * GetProfessionPriceRate(isBuy) / 100 + challengeEffect;
		if (itemData is ItemDisplayData itemDisplayData)
		{
			itemDisplayData.PricePercent = result - 100;
		}
		return result;
	}

	public int GetProfessionPriceRate(bool isBuy)
	{
		if (TradeArguments.OpenShopEventArguments.MerchantSourceTypeEnum != OpenShopEventArguments.EMerchantSourceType.ProfessionSkillCaravan)
		{
			return 100;
		}
		var (sell, buy) = ExternalDataBridge.Context.GetProfessionData(15).SeniorityToCaravanPrice();
		return (isBuy ? buy : sell) + 100;
	}

	public int GetPriceChangePercentValue(ITradeableContent itemData, bool isBuy)
	{
		return GetPricePercentValue(itemData, isBuy) - 100;
	}

	public static int GetFavorability(long cumulativeMoney)
	{
		int favorability = 0;
		int[] merchantFavorabilityMoneyRequirements = GlobalConfig.Instance.MerchantFavorabilityMoneyRequirements;
		foreach (int stage in merchantFavorabilityMoneyRequirements)
		{
			cumulativeMoney -= stage;
			if (cumulativeMoney <= 0)
			{
				favorability += (int)Math.Floor(10f * (float)(stage + cumulativeMoney) / (float)stage);
				break;
			}
			favorability += 10;
		}
		return favorability;
	}

	public static int GetFavorabilityWithDelta(long money, long delta = 0L)
	{
		long val = money + delta;
		if (val < 0)
		{
			return -1;
		}
		return GetFavorability(val);
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public override int GetSerializedSize()
	{
		int totalSize = 65;
		totalSize = ((TradeArguments == null) ? (totalSize + 2) : (totalSize + (2 + TradeArguments.GetSerializedSize())));
		totalSize = ((ExtraGoodsData == null) ? (totalSize + 2) : (totalSize + (2 + ExtraGoodsData.GetSerializedSize())));
		totalSize = ((MerchantCharData == null) ? (totalSize + 2) : (totalSize + (2 + MerchantCharData.GetSerializedSize())));
		totalSize = ((MerchantOverFavorData == null) ? (totalSize + 2) : (totalSize + (2 + MerchantOverFavorData.GetSerializedSize())));
		if (ExchangeItemList != null)
		{
			totalSize += 2;
			int elementsCount = ExchangeItemList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				ExchangeItem element = ExchangeItemList[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((AdvantageSummary == null) ? (totalSize + 2) : (totalSize + (2 + AdvantageSummary.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (IsGift ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = CumulativeMoney;
		pCurrData += 4;
		if (TradeArguments != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = TradeArguments.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ExtraGoodsData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = ExtraGoodsData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (MerchantCharData != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = MerchantCharData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (MerchantOverFavorData != null)
		{
			byte* intPtr4 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = MerchantOverFavorData.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr4 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = ExchangeType;
		pCurrData += 4;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuCharId;
		pCurrData += 4;
		*pCurrData = (CivilianSkill0Useful ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (MartialArtistSkill0Useful ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = TaiwuInventoryCurLoad;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuInventoryMaxLoad;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuWarehouseCurLoad;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuWarehouseMaxLoad;
		pCurrData += 4;
		*(int*)pCurrData = TargetCurLoad;
		pCurrData += 4;
		*(int*)pCurrData = TargetMaxLoad;
		pCurrData += 4;
		if (ExchangeItemList != null)
		{
			int elementsCount = ExchangeItemList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				ExchangeItem element = ExchangeItemList[i];
				if (element != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr5 = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)LayerIndex;
		pCurrData++;
		*pCurrData = (byte)ToItemSourceType;
		pCurrData++;
		*(long*)pCurrData = TaiwuValueBase;
		pCurrData += 8;
		*(long*)pCurrData = TargetValueBase;
		pCurrData += 8;
		*(int*)pCurrData = TradeAmount;
		pCurrData += 4;
		if (AdvantageSummary != null)
		{
			byte* intPtr6 = pCurrData;
			pCurrData += 2;
			int fieldSize5 = AdvantageSummary.Serialize(pCurrData);
			pCurrData += fieldSize5;
			Tester.Assert(fieldSize5 <= 65535);
			*(ushort*)intPtr6 = (ushort)fieldSize5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe override int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		IsGift = *pCurrData != 0;
		pCurrData++;
		CumulativeMoney = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (TradeArguments == null)
			{
				TradeArguments = new MerchantTradeArguments();
			}
			pCurrData += TradeArguments.Deserialize(pCurrData);
		}
		else
		{
			TradeArguments = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (ExtraGoodsData == null)
			{
				ExtraGoodsData = new MerchantExtraGoodsData();
			}
			pCurrData += ExtraGoodsData.Deserialize(pCurrData);
		}
		else
		{
			ExtraGoodsData = null;
		}
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			if (MerchantCharData == null)
			{
				MerchantCharData = new CharacterDisplayData();
			}
			pCurrData += MerchantCharData.Deserialize(pCurrData);
		}
		else
		{
			MerchantCharData = null;
		}
		ushort num4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num4 > 0)
		{
			if (MerchantOverFavorData == null)
			{
				MerchantOverFavorData = new MerchantOverFavorData();
			}
			pCurrData += MerchantOverFavorData.Deserialize(pCurrData);
		}
		else
		{
			MerchantOverFavorData = null;
		}
		ExchangeType = *(int*)pCurrData;
		pCurrData += 4;
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuCharId = *(int*)pCurrData;
		pCurrData += 4;
		CivilianSkill0Useful = *pCurrData != 0;
		pCurrData++;
		MartialArtistSkill0Useful = *pCurrData != 0;
		pCurrData++;
		TaiwuInventoryCurLoad = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuInventoryMaxLoad = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuWarehouseCurLoad = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuWarehouseMaxLoad = *(int*)pCurrData;
		pCurrData += 4;
		TargetCurLoad = *(int*)pCurrData;
		pCurrData += 4;
		TargetMaxLoad = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ExchangeItemList == null)
			{
				ExchangeItemList = new List<ExchangeItem>(elementsCount);
			}
			else
			{
				ExchangeItemList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num5 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num5 > 0)
				{
					ExchangeItem element = new ExchangeItem();
					pCurrData += element.Deserialize(pCurrData);
					ExchangeItemList.Add(element);
				}
				else
				{
					ExchangeItemList.Add(null);
				}
			}
		}
		else
		{
			ExchangeItemList?.Clear();
		}
		LayerIndex = (sbyte)(*pCurrData);
		pCurrData++;
		ToItemSourceType = (sbyte)(*pCurrData);
		pCurrData++;
		TaiwuValueBase = *(long*)pCurrData;
		pCurrData += 8;
		TargetValueBase = *(long*)pCurrData;
		pCurrData += 8;
		TradeAmount = *(int*)pCurrData;
		pCurrData += 4;
		ushort num6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num6 > 0)
		{
			if (AdvantageSummary == null)
			{
				AdvantageSummary = new ExchangeAdvantage();
			}
			pCurrData += AdvantageSummary.Deserialize(pCurrData);
		}
		else
		{
			AdvantageSummary = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
