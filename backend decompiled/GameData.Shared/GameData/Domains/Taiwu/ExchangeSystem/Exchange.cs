using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.DLC.FiveLoong;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.ExchangeSystem;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true, GenerateVirtualMethods = true)]
public class Exchange : ISerializableGameData
{
	[SerializableGameDataField]
	public int ExchangeType;

	[SerializableGameDataField]
	public int CharId = -1;

	[SerializableGameDataField]
	public int TaiwuCharId;

	[SerializableGameDataField]
	public bool CivilianSkill0Useful;

	[SerializableGameDataField]
	public bool MartialArtistSkill0Useful;

	[SerializableGameDataField]
	public int TaiwuInventoryCurLoad;

	[SerializableGameDataField]
	public int TaiwuInventoryMaxLoad;

	[SerializableGameDataField]
	public int TaiwuWarehouseCurLoad;

	[SerializableGameDataField]
	public int TaiwuWarehouseMaxLoad;

	[SerializableGameDataField]
	public int TargetCurLoad;

	[SerializableGameDataField]
	public int TargetMaxLoad;

	[SerializableGameDataField]
	public List<ExchangeItem> ExchangeItemList = new List<ExchangeItem>();

	[SerializableGameDataField]
	public sbyte LayerIndex;

	[SerializableGameDataField]
	public sbyte ToItemSourceType;

	[SerializableGameDataField]
	public long TaiwuValueBase;

	[SerializableGameDataField]
	public long TargetValueBase;

	[SerializableGameDataField]
	public int TradeAmount;

	[SerializableGameDataField]
	public ExchangeAdvantage AdvantageSummary;

	public int TaiwuInventoryCurWeightChange;

	public int TaiwuInventoryMaxWeightChange;

	public int TaiwuWarehouseCurWeightChange;

	public int TargetCurWeightChange;

	public int TargetMaxWeightChange;

	public EExchangeType EExchangeTypeEnum => (EExchangeType)ExchangeType;

	public virtual bool CanConfirmExchange
	{
		get
		{
			if (TaiwuValueBase - TotalValueWithAdvantage >= 0)
			{
				return ExchangeItemList.Count > 0;
			}
			return false;
		}
	}

	public long TotalValue => ExchangeItemList.Sum((ExchangeItem e) => e.TotalValue);

	public long TotalValueWithAdvantage => TargetTotalValueWithAdvantage - TaiwuTotalValueWithAdvantage;

	public virtual long TaiwuTotalValue => ExchangeItemList.Where((ExchangeItem e) => e.Count < 0).Sum((ExchangeItem e) => Math.Abs(e.TotalValue));

	public long TaiwuTotalValueWithAdvantage => CalcAdvantageValue(TaiwuTotalValue, isTaiwu: true);

	public virtual long TargetTotalValue => ExchangeItemList.Where((ExchangeItem e) => e.Count > 0).Sum((ExchangeItem e) => e.TotalValue);

	public long TargetTotalValueWithAdvantage => CalcAdvantageValue(TargetTotalValue, isTaiwu: false);

	public List<ITradeableContent> TaiwuContentList => (from e in ExchangeItemList
		where e.Count < 0
		select e.Content).ToList();

	public List<ITradeableContent> TargetContentList => (from e in ExchangeItemList
		where e.Count > 0
		select e.Content).ToList();

	public List<ItemDisplayData> TaiwuContentItemList => (from e in ExchangeItemList
		where e.Count < 0
		select e.Content as ItemDisplayData into x
		where x != null
		select x).ToList();

	public List<ItemDisplayData> TargetContentItemList => (from e in ExchangeItemList
		where e.Count > 0
		select e.Content as ItemDisplayData into x
		where x != null
		select x).ToList();

	public int AlertnessChange { get; private set; }

	public int TaiwuInventoryCurLoadPreview { get; private set; }

	public int TaiwuInventoryMaxLoadPreview { get; private set; }

	public int TaiwuWarehouseCurLoadPreview { get; private set; }

	public int TaiwuWarehouseMaxLoadPreview { get; private set; }

	public int TargetCurLoadPreview { get; private set; }

	public int TargetMaxLoadPreview { get; private set; }

	public ItemSourceType ToItemSourceTypeEnum => (ItemSourceType)ToItemSourceType;

	public bool HasBalanced { get; private set; } = true;

	public Exchange(EExchangeType eExchangeType, int targetId, ExchangeAdvantage summary)
	{
		ExchangeType = (int)eExchangeType;
		AdvantageSummary = summary ?? new ExchangeAdvantage();
		switch (EExchangeTypeEnum)
		{
		case EExchangeType.Person:
		case EExchangeType.BookSect:
		case EExchangeType.BookPriv:
		case EExchangeType.Shop:
		case EExchangeType.Warehouse:
			CharId = targetId;
			break;
		default:
			throw new ArgumentOutOfRangeException("ExchangeType", ExchangeType, null);
		case EExchangeType.Settlement:
			break;
		}
	}

	public Exchange()
	{
	}

	public void InitLoad(int taiwuInventoryCurLoad, int taiwuInventoryMaxLoad, int taiwuWarehouseCurLoad, int taiwuWarehouseMaxLoad, int targetCurLoad, int targetMaxLoad)
	{
		int taiwuInventoryCurLoad2 = (TaiwuInventoryCurLoadPreview = taiwuInventoryCurLoad);
		TaiwuInventoryCurLoad = taiwuInventoryCurLoad2;
		taiwuInventoryCurLoad2 = (TaiwuInventoryMaxLoadPreview = taiwuInventoryMaxLoad);
		TaiwuInventoryMaxLoad = taiwuInventoryCurLoad2;
		taiwuInventoryCurLoad2 = (TaiwuWarehouseCurLoadPreview = taiwuWarehouseCurLoad);
		TaiwuWarehouseCurLoad = taiwuInventoryCurLoad2;
		taiwuInventoryCurLoad2 = (TaiwuWarehouseMaxLoadPreview = taiwuWarehouseMaxLoad);
		TaiwuWarehouseMaxLoad = taiwuInventoryCurLoad2;
		taiwuInventoryCurLoad2 = (TargetCurLoadPreview = targetCurLoad);
		TargetCurLoad = taiwuInventoryCurLoad2;
		taiwuInventoryCurLoad2 = (TargetMaxLoadPreview = targetMaxLoad);
		TargetMaxLoad = taiwuInventoryCurLoad2;
	}

	public void SetItemSource(sbyte itemSourceType)
	{
		ToItemSourceType = itemSourceType;
		CalcLoadChange();
	}

	public void ChangeItem(ITradeableContent content, int count)
	{
		if (count == 0)
		{
			AdaptableLog.Error("exchange count can not be zero.");
			return;
		}
		bool isItem = content is ItemDisplayData;
		ItemDisplayData itemData = (isItem ? ((ItemDisplayData)content) : null);
		KidnapCharDisplayData charData = ((!isItem) ? ((KidnapCharDisplayData)content) : null);
		ExchangeItem exchangeItem = (isItem ? ExchangeItemList.Find((ExchangeItem e) => e.Content.StackKey == content.StackKey && e.Content.ItemSourceType == itemData.ItemSourceType && e.Content.OwnerCharId == itemData.OwnerCharId) : ExchangeItemList.Find((ExchangeItem e) => e.Content.CharacterId == charData.CharacterId));
		if (exchangeItem == null)
		{
			int amount = Math.Abs(count);
			exchangeItem = new ExchangeItem
			{
				Type = ((!isItem) ? 1 : 0),
				Count = count,
				ItemData = (isItem ? itemData.Clone(amount) : null),
				OriginItemData = (isItem ? itemData.Clone() : null),
				KidnapCharDisplayData = ((!isItem) ? (charData.Clone() as KidnapCharDisplayData) : null)
			};
			ExchangeItemList.Add(exchangeItem);
		}
		else
		{
			exchangeItem.Count += count;
			if (isItem)
			{
				exchangeItem.ItemData.Amount = Math.Abs(exchangeItem.Count);
			}
		}
		if (exchangeItem.Count == 0)
		{
			ExchangeItemList.Remove(exchangeItem);
		}
		else
		{
			exchangeItem.TotalValue = CalcTotalValue(exchangeItem);
			exchangeItem.Content.ExchangeValue = CalcDisplayValue(exchangeItem);
		}
		OnItemChange();
	}

	public void PrepareConfirmExchange()
	{
		foreach (ExchangeItem exchangeItem in ExchangeItemList)
		{
			if (exchangeItem.TypeEnum != ExchangeItem.EExchangeItemType.Item || exchangeItem.Content.IsResource)
			{
				continue;
			}
			ExchangeItem exchangeItem2 = exchangeItem;
			if (exchangeItem2.Inventory == null)
			{
				exchangeItem2.Inventory = new Inventory();
			}
			exchangeItem.Inventory.Items.Clear();
			int operationCount = Math.Abs(exchangeItem.Count);
			if (operationCount <= 0)
			{
				continue;
			}
			Inventory operationInventoryFromPool = exchangeItem.OriginItemData.GetOperationInventoryFromPool(operationCount, preview: true);
			foreach (var (key, value) in operationInventoryFromPool.Items)
			{
				exchangeItem.Inventory.OfflineAddUncheck(key, value);
			}
			ItemDisplayData.ReturnInventoryToPool(operationInventoryFromPool);
		}
	}

	public void SelectTaiwuItem(ITradeableContent content, int count)
	{
		ChangeItem(content, -count);
	}

	public void CancelTaiwuItem(ITradeableContent content, int count)
	{
		ChangeItem(content, count);
	}

	public void SelectTargetItem(ITradeableContent content, int count)
	{
		ChangeItem(content, count);
	}

	public void CancelTargetItem(ITradeableContent content, int count)
	{
		ChangeItem(content, -count);
	}

	public void SetSecret(SecretInformationDisplayData secretInformationDisplayData)
	{
		AdvantageSummary.SetSecret(secretInformationDisplayData);
		OnAdvantageChange();
	}

	public void SetApproveChar(int charId, int approveRate)
	{
		AdvantageSummary.SetApproving(charId, approveRate);
		OnAdvantageChange();
	}

	public void SetSettlementTreasury(SettlementTreasury settlementTreasury)
	{
		AdvantageSummary.NpcOrganization.Grade = (sbyte)GlobalConfig.Instance.ExchangeTreasuryLevelGrade[LayerIndex = settlementTreasury.LayerIndex];
		OnAdvantageChange();
	}

	public void SetDebtUsed(int debtUsed)
	{
		AdvantageSummary.DebtUsed = debtUsed;
		OnAdvantageChange();
	}

	public bool CanBalance(List<ItemDisplayData> curSelfItemList, out LanguageKey tipContent)
	{
		tipContent = LanguageKey.LK_Exchange_Balance_Done;
		if (HasBalanced || TotalValueWithAdvantage == 0L)
		{
			return false;
		}
		if (TotalValueWithAdvantage < 0 && TaiwuContentList.All((ITradeableContent c) => !c.IsResource))
		{
			return false;
		}
		long advantagePercentage = GetAdvantagePercentage(isTaiwu: true);
		long targetAdvantagePercentage = GetAdvantagePercentage(isTaiwu: false);
		if (advantagePercentage <= 0 || targetAdvantagePercentage <= 0)
		{
			tipContent = LanguageKey.LK_Exchange_Balance_AdvantageLack;
			return false;
		}
		if (curSelfItemList.Where((ItemDisplayData d) => d.IsResource && d.ResourceType != 7).Sum((Func<ItemDisplayData, long>)((ItemDisplayData d) => d.Amount)) == 0L)
		{
			tipContent = LanguageKey.LK_Exchange_Balance_ResourceLack;
			return false;
		}
		return true;
	}

	private long GetOffsetValue(long totalValue, long selfAdvantagePercentage)
	{
		long num = totalValue * 100 % selfAdvantagePercentage;
		long offsetValue = totalValue * 100 / selfAdvantagePercentage;
		if (num != 0L)
		{
			offsetValue++;
		}
		return offsetValue;
	}

	public void Balance(List<ItemDisplayData> selfInventoryItemList)
	{
		if (!CanBalance(selfInventoryItemList, out var _))
		{
			return;
		}
		long totalValue = TotalValueWithAdvantage;
		long selfAdvantagePercentage = GetAdvantagePercentage(isTaiwu: true);
		long offsetValue = GetOffsetValue(totalValue, selfAdvantagePercentage);
		if (offsetValue > 0)
		{
			List<ItemDisplayData> selfResourceItemList = (from d in selfInventoryItemList
				where d.IsResource && d.ResourceType != 7
				orderby d.Amount descending
				select d).ToList();
			if (selfResourceItemList == null || selfResourceItemList.Count <= 0)
			{
				return;
			}
			foreach (ItemDisplayData selfResourceItem in selfResourceItemList)
			{
				sbyte resourceType = selfResourceItem.ResourceType;
				int maxCount = selfResourceItem.Amount;
				long targetAmount = 0L;
				long usedValue = 0L;
				if (selfResourceItem.Amount > 0 && offsetValue > 0)
				{
					targetAmount = CalcResourceAmount(resourceType, offsetValue, isPut: true);
					targetAmount = Math.Clamp(targetAmount, 1L, maxCount);
					usedValue = CalcResourceValue(resourceType, (int)targetAmount);
					if (usedValue == 0L)
					{
						continue;
					}
					offsetValue -= usedValue;
					ChangeItem(selfResourceItem, (int)(-targetAmount));
				}
				if (offsetValue == 0L)
				{
					break;
				}
			}
		}
		else if (offsetValue < 0)
		{
			offsetValue += 10;
			List<ItemDisplayData> exchangeResourceItemList = (from d in TaiwuContentItemList
				where d.IsResource
				orderby d.Amount descending
				select d).ToList();
			if (exchangeResourceItemList == null || exchangeResourceItemList.Count <= 0)
			{
				return;
			}
			foreach (ItemDisplayData exchangeResourceItem in exchangeResourceItemList)
			{
				sbyte resourceType2 = exchangeResourceItem.ResourceType;
				int maxCount2 = exchangeResourceItem.Amount;
				long offsetValueAbs = 0L;
				long targetAmount2 = 0L;
				long usedValue2 = 0L;
				if (exchangeResourceItem.Amount > 0 && offsetValue < 0)
				{
					offsetValueAbs = Math.Abs(offsetValue);
					targetAmount2 = CalcResourceAmount(resourceType2, offsetValueAbs, isPut: false);
					targetAmount2 = Math.Clamp(targetAmount2, 1L, maxCount2);
					usedValue2 = CalcResourceValue(resourceType2, (int)targetAmount2);
					if (usedValue2 == 0L)
					{
						continue;
					}
					offsetValue += usedValue2;
					selfInventoryItemList.Find((ItemDisplayData d) => d.ResourceType == resourceType2);
					ChangeItem(exchangeResourceItem, (int)targetAmount2);
				}
				if (offsetValue == 0L)
				{
					break;
				}
			}
		}
		HasBalanced = true;
	}

	public int GetBalanceResourceAmount(ItemDisplayData itemData, bool isSelected)
	{
		if (!itemData.IsResource)
		{
			return itemData.Amount;
		}
		long totalValue = TotalValueWithAdvantage;
		if (totalValue == 0L)
		{
			return 0;
		}
		long selfAdvantagePercentage = GetAdvantagePercentage(isTaiwu: true);
		if (selfAdvantagePercentage == 0L)
		{
			return 0;
		}
		sbyte resourceType = itemData.ResourceType;
		long offsetValue = GetOffsetValue(totalValue, selfAdvantagePercentage);
		long offsetValueAbs = Math.Abs(offsetValue);
		long targetAmount = 0L;
		if (!isSelected && offsetValue > 0)
		{
			targetAmount = CalcResourceAmount(resourceType, offsetValue, isPut: true);
		}
		else if (isSelected && offsetValue < 0)
		{
			targetAmount = CalcResourceAmount(resourceType, offsetValueAbs, isPut: false);
		}
		int maxCount = itemData.Amount;
		long offsetAmount = maxCount - targetAmount;
		if (offsetAmount > 0)
		{
			long tempValue = CalcResourceValue(resourceType, offsetAmount);
			if (CalcAdvantageValue(tempValue, isTaiwu: true) == 0L)
			{
				targetAmount = maxCount;
			}
		}
		return (int)Math.Clamp(targetAmount, 1L, maxCount);
	}

	public void Clear()
	{
		foreach (ExchangeItem exchangeItem in ExchangeItemList)
		{
			exchangeItem.ItemData.TreasuryOperation = ETreasuryOperation.Invalid;
		}
		ExchangeItemList.Clear();
		OnItemChange();
		SetSecret(null);
		SetApproveChar(-1, 0);
	}

	public int CalcValueAdvantage(sbyte grade)
	{
		return grade;
	}

	public int GetTaiwuCurLoad(bool isInventory, bool isPreview)
	{
		if (!isPreview)
		{
			if (!isInventory)
			{
				return TaiwuWarehouseCurLoadPreview;
			}
			return TaiwuInventoryCurLoadPreview;
		}
		if (!isInventory)
		{
			return TaiwuWarehouseCurLoad;
		}
		return TaiwuInventoryCurLoad;
	}

	public int GetTaiwuMaxLoad(bool isInventory, bool isPreview)
	{
		if (!isPreview)
		{
			if (!isInventory)
			{
				return TaiwuWarehouseMaxLoadPreview;
			}
			return TaiwuInventoryMaxLoadPreview;
		}
		if (!isInventory)
		{
			return TaiwuWarehouseMaxLoad;
		}
		return TaiwuInventoryMaxLoad;
	}

	private long CalcItemBaseValue(ItemDisplayData itemData)
	{
		return CalcItemBaseValue(itemData, EExchangeTypeEnum);
	}

	private static long CalcItemBaseValue(ItemDisplayData itemData, EExchangeType exchangeType)
	{
		if (itemData == null)
		{
			return -1L;
		}
		if (itemData.CricketData != null)
		{
			return itemData.CricketData.CricketValue;
		}
		short itemSubType = ItemTemplateHelper.GetItemSubType(itemData.Key.ItemType, itemData.Key.TemplateId);
		switch (exchangeType)
		{
		case EExchangeType.Person:
			if (itemData.IsResource)
			{
				return ResourceTypeHelper.ResourceAmountToLongWorth(itemData.ResourceType, 1L);
			}
			return CalcPersonAdjustedWorth(itemSubType, itemData);
		case EExchangeType.BookSect:
		case EExchangeType.BookPriv:
			return itemData.ExchangeValue;
		case EExchangeType.Shop:
		case EExchangeType.Warehouse:
			return GetBasePrice(itemData);
		case EExchangeType.Settlement:
			if (itemData.IsResource)
			{
				return ResourceTypeHelper.ResourceAmountToLongWorth(itemData.ResourceType, 1L);
			}
			return GetBasePrice(itemData);
		default:
			throw new ArgumentOutOfRangeException("exchangeType", exchangeType, null);
		}
	}

	public void RefreshBookAuthority(ITradeableContent itemData, sbyte behaviorType, bool isBuy)
	{
		int behaviorPercentIndex = ((!isBuy) ? 1 : 0);
		int behaviorPercent = GlobalConfig.Instance.ExchangeBookBehaviorTypeToValuePercent[behaviorType][behaviorPercentIndex];
		int durabilityPercent = GlobalConfig.Instance.ExchangeBookValueDurabilityBasePercent + itemData.Durability * GlobalConfig.Instance.ExchangeBookValueDurabilityFactor / itemData.MaxDurability;
		itemData.ExchangeValue = (long)ItemTemplateHelper.GetBaseValue(itemData.Key.ItemType, itemData.Key.TemplateId) * (long)durabilityPercent * behaviorPercent / 10000 / GlobalConfig.ResourcesWorth[7];
	}

	public void RefreshBookAuthority(IReadOnlyList<ITradeableContent> itemData, sbyte behaviorType, bool isBuy)
	{
		int i = itemData.Count;
		while (i-- > 0)
		{
			RefreshBookAuthority(itemData[i], behaviorType, isBuy);
		}
	}

	public void SelectBookWithAuthority(ref List<ItemDisplayData> itemData, sbyte behaviorType, bool isBuy)
	{
		if (itemData != null)
		{
			itemData = itemData.Where((ItemDisplayData x) => x.Key.ItemType == 10).ToList();
			RefreshBookAuthority(itemData, behaviorType, isBuy);
		}
	}

	public virtual long CalcBaseValue(ITradeableContent content)
	{
		if (!(content is ItemDisplayData itemData))
		{
			return content.ExchangeValue;
		}
		return CalcItemBaseValue(itemData);
	}

	public long CalcAdvantageValue(long value, bool isTaiwu)
	{
		return value * GetAdvantagePercentage(isTaiwu) / 100;
	}

	public long GetAdvantagePercentage(bool isTaiwu)
	{
		return isTaiwu ? AdvantageSummary.TaiwuAdvantage : AdvantageSummary.TargetAdvantage;
	}

	public static long CalcPersonAdjustedWorth(short itemSubType, ItemDisplayData data)
	{
		return GetBasePrice(data);
	}

	public static long GetBasePrice(ItemDisplayData itemData)
	{
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
		return value * (100 + (itemData.EquipmentEffectIds?.Sum((short x) => EquipmentEffect.Instance[x].ValueChange) ?? 0)) / 100;
	}

	public long CalcSettlementAdjustedWorth(short itemSubType, long worth)
	{
		return worth;
	}

	private long CalcResourceValue(sbyte resourceType, long amount)
	{
		if (amount == 0L)
		{
			return 0L;
		}
		bool num = amount > 0;
		amount = Math.Abs(amount);
		short orgMemberId = Config.Organization.Instance[AdvantageSummary.NpcOrganization.OrgTemplateId].Members[8];
		long value = OrganizationMember.Instance[orgMemberId].AdjustResourceValue(resourceType, amount);
		long result = value;
		if (EExchangeTypeEnum == EExchangeType.Settlement)
		{
			result = Math.DivRem(value * GlobalConfig.Instance.ResourceContributionPercent, 100L, out var remainder);
			if (remainder > 0)
			{
				result++;
			}
		}
		if (!num)
		{
			return -result;
		}
		return result;
	}

	private long CalcResourceAmount(sbyte resourceType, long value, bool isPut)
	{
		if (value == 0L)
		{
			return 0L;
		}
		bool num = value > 0;
		value = Math.Abs(value);
		long tempValue = value;
		if (EExchangeTypeEnum == EExchangeType.Settlement && (double)value > Math.Ceiling((float)GlobalConfig.Instance.ResourceContributionPercent / 100f))
		{
			tempValue = Math.DivRem(value * 100, GlobalConfig.Instance.ResourceContributionPercent, out var remainder);
			if (remainder > 0)
			{
				tempValue++;
			}
		}
		short orgMemberId = Config.Organization.Instance[AdvantageSummary.NpcOrganization.OrgTemplateId].Members[8];
		long amount = OrganizationMember.Instance[orgMemberId].AdjustResourceAmount(resourceType, tempValue, isPut);
		if (!num)
		{
			return -amount;
		}
		return amount;
	}

	private void CalcLoadChange()
	{
		int taiwuInventoryCurWeightChange = 0;
		int taiwuInventoryMaxWeightChange = 0;
		int taiwuWarehouseCurWeightChange = 0;
		int targetCurWeightChange = 0;
		int targetMaxWeightChange = 0;
		foreach (ExchangeItem exchangeItem in ExchangeItemList)
		{
			if (exchangeItem.TypeEnum != ExchangeItem.EExchangeItemType.Item)
			{
				continue;
			}
			if (exchangeItem.ItemData.UsingType == ItemDisplayData.ItemUsingType.Equiped && exchangeItem.ItemData.RealKey.ItemType == 4 && exchangeItem.ItemData.EquipmentSlot != 13)
			{
				if (exchangeItem.Count < 0)
				{
					taiwuInventoryMaxWeightChange += exchangeItem.ItemData.MaxInventoryLoadBonus * exchangeItem.Count;
				}
				else if (exchangeItem.Count > 0)
				{
					targetMaxWeightChange -= exchangeItem.ItemData.MaxInventoryLoadBonus * exchangeItem.Count;
				}
				continue;
			}
			int change = exchangeItem.ItemData.Weight * exchangeItem.Count;
			if (exchangeItem.Count > 0)
			{
				if (ToItemSourceTypeEnum == ItemSourceType.Inventory)
				{
					taiwuInventoryCurWeightChange += change;
				}
				else
				{
					taiwuWarehouseCurWeightChange += change;
				}
			}
			else if (exchangeItem.Count < 0)
			{
				if (exchangeItem.ItemData.ItemSourceTypeEnum == ItemSourceType.Inventory)
				{
					taiwuInventoryCurWeightChange += change;
				}
				else if (exchangeItem.ItemData.ItemSourceTypeEnum == ItemSourceType.Warehouse)
				{
					taiwuWarehouseCurWeightChange += change;
				}
			}
			targetCurWeightChange -= change;
		}
		TaiwuInventoryCurLoadPreview = TaiwuInventoryCurLoad + taiwuInventoryCurWeightChange;
		TaiwuInventoryMaxLoadPreview = TaiwuInventoryMaxLoad + taiwuInventoryMaxWeightChange;
		TaiwuWarehouseCurLoadPreview = TaiwuWarehouseCurLoad + taiwuWarehouseCurWeightChange;
		TaiwuWarehouseMaxLoadPreview = TaiwuWarehouseMaxLoad;
		TargetCurLoadPreview = TargetCurLoad + targetCurWeightChange;
		TargetMaxLoadPreview = TargetMaxLoad + targetMaxWeightChange;
		TaiwuInventoryCurWeightChange = taiwuInventoryCurWeightChange;
		TaiwuInventoryMaxWeightChange = taiwuInventoryMaxWeightChange;
		TaiwuWarehouseCurWeightChange = taiwuWarehouseCurWeightChange;
		TargetCurWeightChange = targetCurWeightChange;
		TargetMaxWeightChange = targetMaxWeightChange;
	}

	private void OnItemChange()
	{
		HasBalanced = false;
		OnAdvantageChange();
		CalcLoadChange();
	}

	private void OnAdvantageChange()
	{
		if (AdvantageSummary.Enabled)
		{
			AdvantageSummary.OnItemChange(ExchangeItemList);
			for (int index = 0; index < ExchangeItemList.Count; index++)
			{
				ExchangeItem exchangeItem = ExchangeItemList[index];
				exchangeItem.Content.ExchangeValue = CalcDisplayValue(exchangeItem);
			}
			HasBalanced = false;
		}
	}

	private long CalcDisplayValue(ExchangeItem exchangeItem)
	{
		bool num = exchangeItem.TypeEnum != ExchangeItem.EExchangeItemType.Item || (EExchangeTypeEnum == EExchangeType.Warehouse && !exchangeItem.ItemData.IsResource);
		bool isTaiwu = EExchangeTypeEnum == EExchangeType.Warehouse || TaiwuCharId == exchangeItem.Content.OwnerCharId;
		long totalValue = (num ? CalcBaseValue(exchangeItem.Content) : CalcTotalValue(exchangeItem));
		return CalcAdvantageValue(Math.Abs(totalValue), isTaiwu);
	}

	private long CalcTotalValue(ExchangeItem exchangeItem)
	{
		bool isTaiwu = EExchangeTypeEnum == EExchangeType.Warehouse || TaiwuCharId == exchangeItem.Content.OwnerCharId;
		if (!(exchangeItem.TypeEnum == ExchangeItem.EExchangeItemType.Item && exchangeItem.ItemData.IsResource && isTaiwu))
		{
			return CalcBaseValue(exchangeItem.Content) * exchangeItem.Count;
		}
		return CalcResourceValue(exchangeItem.ItemData.ResourceType, exchangeItem.Count);
	}

	public virtual bool IsSerializedSizeFixed()
	{
		return false;
	}

	public virtual int GetSerializedSize()
	{
		int totalSize = 60;
		if (ExchangeItemList != null)
		{
			totalSize += 2;
			for (int i = 0; i < ExchangeItemList.Count; i++)
			{
				totalSize = ((ExchangeItemList[i] == null) ? (totalSize + 2) : (totalSize + (2 + ExchangeItemList[i].GetSerializedSize())));
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

	public unsafe virtual int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
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
				if (ExchangeItemList[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = ExchangeItemList[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
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
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = AdvantageSummary.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
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

	public unsafe virtual int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
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
				ExchangeItemList = new List<ExchangeItem>();
			}
			else
			{
				ExchangeItemList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				ExchangeItem element;
				if (num > 0)
				{
					element = new ExchangeItem();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				ExchangeItemList.Add(element);
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
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			AdvantageSummary = new ExchangeAdvantage();
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
