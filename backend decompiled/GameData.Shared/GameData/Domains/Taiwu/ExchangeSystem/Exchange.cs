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
	/// <summary>
	/// 交换类型
	/// </summary>
	[SerializableGameDataField]
	public int ExchangeType;

	/// <summary>
	/// 个人交换的人物ID
	/// </summary>
	[SerializableGameDataField]
	public int CharId = -1;

	/// <summary>
	/// 太吾Id，用于判定物品是否从属太吾
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuCharId;

	/// <summary>
	/// 志向 - 父老乡亲 是否有效
	/// </summary>
	[SerializableGameDataField]
	public bool CivilianSkill0Useful;

	/// <summary>
	/// 志向 - 江湖中人 是否有效
	/// </summary>
	[SerializableGameDataField]
	public bool MartialArtistSkill0Useful;

	/// <summary>
	/// 太吾行囊当前负重
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuInventoryCurLoad;

	/// <summary>
	/// 太吾行囊最大负重
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuInventoryMaxLoad;

	/// <summary>
	/// 太吾仓库当前负重
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuWarehouseCurLoad;

	/// <summary>
	/// 太吾仓库最大负重
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuWarehouseMaxLoad;

	/// <summary>
	/// 目标当前负重
	/// </summary>
	[SerializableGameDataField]
	public int TargetCurLoad;

	/// <summary>
	/// 目标最大负重
	/// </summary>
	[SerializableGameDataField]
	public int TargetMaxLoad;

	/// <summary>
	/// 交换的具体内容，一个物品只存一项，太吾增加就是对方减少，太吾减少就是对方增加
	/// </summary>
	[SerializableGameDataField]
	public List<ExchangeItem> ExchangeItemList = new List<ExchangeItem>();

	/// <summary>
	/// 库房层级
	/// </summary>
	[SerializableGameDataField]
	public sbyte LayerIndex;

	/// <summary>
	/// 己方要存入的物品源
	/// </summary>
	[SerializableGameDataField]
	public sbyte ToItemSourceType;

	/// <summary>
	/// 太吾等价物数量（等价物：金钱or威望or恩义）
	/// 按需赋值
	/// 交换模式下TaiwuValueBase为0，这意味着，TotalValueWithAdvantage小于等于0时不可交易
	/// </summary>
	[SerializableGameDataField]
	public long TaiwuValueBase;

	/// <summary>
	/// 目标等价物数量（等价物：金钱or威望or恩义）
	/// 按需赋值
	/// </summary>
	[SerializableGameDataField]
	public long TargetValueBase;

	/// <summary>
	/// 在商店消费的金额，只为正值，用于计算商会好感
	/// 按需赋值
	/// </summary>
	[SerializableGameDataField]
	public int TradeAmount;

	[SerializableGameDataField]
	public ExchangeAdvantage AdvantageSummary;

	/// <summary>
	/// 最大负重计算，将在CalcLoad之后更新，用于处理无法简单地使用TargetLaxLoad计算load的问题
	/// </summary>
	public int TaiwuInventoryCurWeightChange;

	/// <summary>
	/// 最大负重计算，将在CalcLoad之后更新，用于处理无法简单地使用TargetLaxLoad计算load的问题
	/// </summary>
	public int TaiwuInventoryMaxWeightChange;

	/// <summary>
	/// 最大负重计算，将在CalcLoad之后更新，用于处理无法简单地使用TargetLaxLoad计算load的问题
	/// </summary>
	public int TaiwuWarehouseCurWeightChange;

	/// <summary>
	/// 最大负重计算，将在CalcLoad之后更新，用于处理无法简单地使用TargetLaxLoad计算load的问题
	/// </summary>
	public int TargetCurWeightChange;

	/// <summary>
	/// 最大负重计算，将在CalcLoad之后更新，用于处理无法简单地使用TargetLaxLoad计算load的问题
	/// </summary>
	public int TargetMaxWeightChange;

	public EExchangeType EExchangeTypeEnum => (EExchangeType)ExchangeType;

	/// <summary>
	/// 能否确认交易，太吾不能占便宜，目标可以占便宜，所以要求TotalValue是非正数，且有交易项
	/// </summary>
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

	/// <summary>
	/// 未计算优势的总价值，可能为负数
	/// </summary>
	public long TotalValue => ExchangeItemList.Sum((ExchangeItem e) => e.TotalValue);

	/// <summary>
	/// 计算优势后的总价值，可能为负数
	/// </summary>
	public long TotalValueWithAdvantage => TargetTotalValueWithAdvantage - TaiwuTotalValueWithAdvantage;

	/// <summary>
	/// 未计算优势的太吾放入的总价值，必定非负
	/// </summary>
	public virtual long TaiwuTotalValue => ExchangeItemList.Where((ExchangeItem e) => e.Count < 0).Sum((ExchangeItem e) => Math.Abs(e.TotalValue));

	/// <summary>
	/// 计算优势后的太吾放入的总价值，必定非负
	/// </summary>
	public long TaiwuTotalValueWithAdvantage => CalcAdvantageValue(TaiwuTotalValue, isTaiwu: true);

	/// <summary>
	/// 未计算优势的目标放入的总价值，必定非负
	/// </summary>
	public virtual long TargetTotalValue => ExchangeItemList.Where((ExchangeItem e) => e.Count > 0).Sum((ExchangeItem e) => e.TotalValue);

	/// <summary>
	/// 计算优势后的目标放入的总价值，必定非负
	/// </summary>
	public long TargetTotalValueWithAdvantage => CalcAdvantageValue(TargetTotalValue, isTaiwu: false);

	/// <summary>
	/// 太吾交易区列表
	/// </summary>
	public List<ITradeableContent> TaiwuContentList => (from e in ExchangeItemList
		where e.Count < 0
		select e.Content).ToList();

	/// <summary>
	/// 目标交易区列表
	/// </summary>
	public List<ITradeableContent> TargetContentList => (from e in ExchangeItemList
		where e.Count > 0
		select e.Content).ToList();

	/// <summary>
	/// 太吾交易区ItemDisplayData列表，用于部分只接受ItemDisplayData的接口
	/// </summary>
	public List<ItemDisplayData> TaiwuContentItemList => (from e in ExchangeItemList
		where e.Count < 0
		select e.Content as ItemDisplayData into x
		where x != null
		select x).ToList();

	/// <summary>
	/// 目标交易区ItemDisplayData列表，用于部分只接受ItemDisplayData的接口
	/// </summary>
	public List<ItemDisplayData> TargetContentItemList => (from e in ExchangeItemList
		where e.Count > 0
		select e.Content as ItemDisplayData into x
		where x != null
		select x).ToList();

	/// <summary>
	/// 戒心变化，仅用于前端预览
	/// </summary>
	public int AlertnessChange { get; private set; }

	/// <summary>
	/// 太吾行囊当前负重的预览
	/// </summary>
	public int TaiwuInventoryCurLoadPreview { get; private set; }

	/// <summary>
	/// 太吾行囊最大负重的预览
	/// </summary>
	public int TaiwuInventoryMaxLoadPreview { get; private set; }

	/// <summary>
	/// 太吾仓库当前负重的预览
	/// </summary>
	public int TaiwuWarehouseCurLoadPreview { get; private set; }

	/// <summary>
	/// 太吾仓库最大负重的预览
	/// </summary>
	public int TaiwuWarehouseMaxLoadPreview { get; private set; }

	/// <summary>
	/// 目标当前负重的预览
	/// </summary>
	public int TargetCurLoadPreview { get; private set; }

	/// <summary>
	/// 目标最大负重的预览
	/// </summary>
	public int TargetMaxLoadPreview { get; private set; }

	public ItemSourceType ToItemSourceTypeEnum => (ItemSourceType)ToItemSourceType;

	/// <summary>
	/// 物品是否已经配平
	/// </summary>
	/// <remarks>最开始双方不存在物品，所以自然是配平的</remarks>
	public bool HasBalanced { get; private set; } = true;

	/// <summary>
	/// 构造
	/// </summary>
	/// <param name="eExchangeType"></param>
	/// <param name="targetId"></param>
	/// <param name="summary">可以为null，但不能没有</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
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

	/// <summary>
	/// 初始化负重
	/// </summary>
	/// <param name="taiwuInventoryCurLoad"></param>
	/// <param name="taiwuInventoryMaxLoad"></param>
	/// <param name="taiwuWarehouseMaxLoad"></param>
	/// <param name="targetCurLoad"></param>
	/// <param name="targetMaxLoad"></param>
	/// <param name="taiwuWarehouseCurLoad"></param>
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

	/// <summary>
	/// 切换页签时设置物品源
	/// </summary>
	/// <param name="itemSourceType"></param>
	public void SetItemSource(sbyte itemSourceType)
	{
		ToItemSourceType = itemSourceType;
		CalcLoadChange();
	}

	/// <summary>
	/// 太吾获得物品或失去物品，正数表示太吾增加，负数表示太吾减少。
	/// 取消也用这个，数量符号反向就行
	/// </summary>
	/// <param name="content"></param>
	/// <param name="count"></param>
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
		ExchangeItem exchangeItem = (isItem ? ExchangeItemList.Find((ExchangeItem e) => e.Content.ContainsItemKey(itemData.RealKey) && e.Content.ItemSourceType == itemData.ItemSourceType && e.Content.OwnerCharId == itemData.OwnerCharId) : ExchangeItemList.Find((ExchangeItem e) => e.Content.CharacterId == charData.CharacterId));
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
			exchangeItem.Content.Value = CalcDisplayValue(exchangeItem);
		}
		OnItemChange();
	}

	/// <summary>
	/// 准备确认交换，要在实际结算物品前调用
	/// </summary>
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

	/// <summary>
	/// 太吾放入交易区
	/// </summary>
	public void SelectTaiwuItem(ITradeableContent content, int count)
	{
		ChangeItem(content, -count);
	}

	/// <summary>
	/// 太吾取消交易区
	/// </summary>
	public void CancelTaiwuItem(ITradeableContent content, int count)
	{
		ChangeItem(content, count);
	}

	/// <summary>
	/// 目标放入交易区
	/// </summary>
	public void SelectTargetItem(ITradeableContent content, int count)
	{
		ChangeItem(content, count);
	}

	/// <summary>
	/// 目标取消交易区
	/// </summary>
	public void CancelTargetItem(ITradeableContent content, int count)
	{
		ChangeItem(content, -count);
	}

	/// <summary>
	/// 太吾使用秘闻
	/// </summary>
	public void SetSecret(SecretInformationDisplayData secretInformationDisplayData)
	{
		AdvantageSummary.SetSecret(secretInformationDisplayData);
		OnAdvantageChange();
	}

	/// <summary>
	/// 门派定居点可以选择已支持的角色，消耗其全部支持度换取优势
	/// </summary>
	/// <param name="charId"></param>
	/// <param name="approveRate"></param>
	public void SetApproveChar(int charId, int approveRate)
	{
		AdvantageSummary.SetApproving(charId, approveRate);
		OnAdvantageChange();
	}

	/// <summary>
	/// 设置当前的库房数据，更新库房喜好，计算物品价值，计算库房等级优势
	/// </summary>
	public void SetSettlementTreasury(SettlementTreasury settlementTreasury)
	{
		AdvantageSummary.NpcOrganization.Grade = (sbyte)GlobalConfig.Instance.ExchangeTreasuryLevelGrade[LayerIndex = settlementTreasury.LayerIndex];
		OnAdvantageChange();
	}

	/// <summary>
	/// 设置使用的恩义
	/// </summary>
	/// <param name="debtUsed"></param>
	public void SetDebtUsed(int debtUsed)
	{
		AdvantageSummary.DebtUsed = debtUsed;
		OnAdvantageChange();
	}

	/// <summary>
	/// 是否可以进行配平
	/// </summary>
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

	/// <summary>
	/// 获取对太吾的价值
	/// </summary>
	/// <param name="totalValue"></param>
	/// <param name="selfAdvantagePercentage"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 配平
	/// </summary>
	/// <param name="selfInventoryItemList"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取资源能配平的数量，对于行囊的是选择，对于交易区的是取消
	/// </summary>
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

	/// <summary>
	/// 清除选择
	/// </summary>
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

	/// <summary>
	/// 计算物品或人物的优势值
	/// </summary>
	/// <param name="grade"></param>
	/// <returns></returns>
	public int CalcValueAdvantage(sbyte grade)
	{
		return grade;
	}

	/// <summary>
	/// 获取太吾当前负重
	/// </summary>
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

	/// <summary>
	/// 获取太吾最大负重
	/// </summary>
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

	/// <summary>
	/// 计算基础价值
	/// 注意资源是总价
	/// </summary>
	/// <param name="itemData"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
	private long CalcItemBaseValue(ItemDisplayData itemData)
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
		switch (EExchangeTypeEnum)
		{
		case EExchangeType.Person:
			if (itemData.IsResource)
			{
				return ResourceTypeHelper.ResourceAmountToLongWorth(itemData.ResourceType, 1L);
			}
			return CalcPersonAdjustedWorth(itemSubType, itemData);
		case EExchangeType.BookSect:
		case EExchangeType.BookPriv:
			return itemData.Value;
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
			throw new ArgumentOutOfRangeException("EExchangeTypeEnum", EExchangeTypeEnum, null);
		}
	}

	/// <summary>
	/// 更新藏书所需威望值
	/// </summary>
	/// <param name="itemData"></param>
	/// <param name="isBuy"></param>
	/// <param name="behaviorType"></param>
	/// <returns></returns>
	public void RefreshBookAuthority(ITradeableContent itemData, sbyte behaviorType, bool isBuy)
	{
		int behaviorPercentIndex = ((!isBuy) ? 1 : 0);
		int behaviorPercent = GlobalConfig.Instance.ExchangeBookBehaviorTypeToValuePercent[behaviorType][behaviorPercentIndex];
		int durabilityPercent = GlobalConfig.Instance.ExchangeBookValueDurabilityBasePercent + itemData.Durability * GlobalConfig.Instance.ExchangeBookValueDurabilityFactor / itemData.MaxDurability;
		itemData.Value = (long)ItemTemplateHelper.GetBaseValue(itemData.Key.ItemType, itemData.Key.TemplateId) * (long)durabilityPercent * behaviorPercent / 10000 / GlobalConfig.ResourcesWorth[7];
	}

	/// <summary>
	/// 更新藏书所需威望值
	/// 需在藏书模式交换数据时执行
	/// </summary>
	/// <param name="itemData"></param>
	/// <param name="isBuy"></param>
	/// <param name="behaviorType"></param>
	/// <returns></returns>
	public void RefreshBookAuthority(IReadOnlyList<ITradeableContent> itemData, sbyte behaviorType, bool isBuy)
	{
		int i = itemData.Count;
		while (i-- > 0)
		{
			RefreshBookAuthority(itemData[i], behaviorType, isBuy);
		}
	}

	/// <summary>
	/// 在物品列表中选取书籍
	/// </summary>
	/// <param name="itemData"></param>
	/// <param name="behaviorType"></param>
	/// <param name="isBuy"></param>
	public void SelectBookWithAuthority(ref List<ItemDisplayData> itemData, sbyte behaviorType, bool isBuy)
	{
		if (itemData != null)
		{
			itemData = itemData.Where((ItemDisplayData x) => x.Key.ItemType == 10).ToList();
			RefreshBookAuthority(itemData, behaviorType, isBuy);
		}
	}

	/// <summary>
	/// 计算原始单个价值，必定非负
	/// 交换藏书时，要直接将最终价值写入itemData
	/// </summary>
	public virtual long CalcBaseValue(ITradeableContent content)
	{
		if (!(content is ItemDisplayData itemData))
		{
			return content.Value;
		}
		return CalcItemBaseValue(itemData);
	}

	/// <summary>
	/// 计算考虑优势后的价值，必定非负
	/// </summary>
	public long CalcAdvantageValue(long value, bool isTaiwu)
	{
		return value * GetAdvantagePercentage(isTaiwu) / 100;
	}

	public long GetAdvantagePercentage(bool isTaiwu)
	{
		return isTaiwu ? AdvantageSummary.TaiwuAdvantage : AdvantageSummary.TargetAdvantage;
	}

	/// <summary>
	/// 指定子类型和价值，计算根据喜好修正后的价值
	/// </summary>
	/// <param name="itemSubType">物品子类型 <see cref="T:GameData.Domains.Item.ItemSubType" /></param>
	/// <param name="worth">物品价值</param>
	/// <returns>修正后的价值</returns>
	public long CalcPersonAdjustedWorth(short itemSubType, ItemDisplayData data)
	{
		return GetBasePrice(data);
	}

	public long GetBasePrice(ItemDisplayData itemData)
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

	/// <summary>
	/// 指定子类型和价值，计算根据喜好修正后的价值
	/// </summary>
	/// <param name="itemSubType">物品子类型 <see cref="T:GameData.Domains.Item.ItemSubType" /></param>
	/// <param name="worth">物品价值</param>
	/// <returns>修正后的价值</returns>
	public long CalcSettlementAdjustedWorth(short itemSubType, long worth)
	{
		return worth;
	}

	/// <summary>
	/// 计算指定资源类型对应门派的贡献值 (也就是对于该门派的相对价值)
	/// </summary>
	/// <param name="resourceType">资源类型</param>
	/// <param name="amount">资源数量，可能为负</param>
	/// <returns></returns>
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

	/// <summary>
	/// 计算指定资源类型对应门派的数量
	/// </summary>
	/// <param name="resourceType">资源类型</param>
	/// <param name="value">价值，可能为负</param>
	/// <param name="isPut"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 计算负重变化
	/// </summary>
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

	/// <summary>
	/// 交换内容变化时
	/// </summary>
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
				exchangeItem.Content.Value = CalcDisplayValue(exchangeItem);
			}
			HasBalanced = false;
		}
	}

	/// <summary>
	/// 计算物品要显示的价值，已经考虑了交换优势，必定非负
	/// 资源是总价，其他是单价
	/// </summary>
	/// <param name="exchangeItem"></param>
	private long CalcDisplayValue(ExchangeItem exchangeItem)
	{
		bool num = exchangeItem.TypeEnum != ExchangeItem.EExchangeItemType.Item || (EExchangeTypeEnum == EExchangeType.Warehouse && !exchangeItem.ItemData.IsResource);
		bool isTaiwu = EExchangeTypeEnum == EExchangeType.Warehouse || TaiwuCharId == exchangeItem.Content.OwnerCharId;
		long totalValue = (num ? CalcBaseValue(exchangeItem.Content) : CalcTotalValue(exchangeItem));
		return CalcAdvantageValue(Math.Abs(totalValue), isTaiwu);
	}

	/// <summary>
	/// 计算物品总价值，未考虑交换优势，可能为负数
	/// </summary>
	/// <param name="exchangeItem"></param>
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
