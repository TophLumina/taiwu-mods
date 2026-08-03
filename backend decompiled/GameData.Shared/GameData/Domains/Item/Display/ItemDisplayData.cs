using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.ConfigCells.Character;
using GameData.DLC;
using GameData.DLC.FiveLoong;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Extra;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item.Display;

/// <summary>
/// 物品显示数据。用于向前端返回显示所需数据，使前端不必监听物品数据
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class ItemDisplayData : ISerializableGameData, IItemData, ITradeableContent
{
	/// <summary>
	/// 道具占用中状态类型
	/// </summary>
	public enum ItemUsingType
	{
		Invalid = -1,
		Reading,
		EquipmentPlaned,
		Equiped,
		Breeding,
		Referring
	}

	/// <summary>
	/// 占用中物品的操作类型
	/// </summary>
	public enum ItemUsingOperationType
	{
		Default,
		Sell,
		Store,
		Present,
		Bet,
		Give
	}

	/// <summary>
	/// 道具不可选状态类型
	/// </summary>
	public enum ItemUnavailableType
	{
		Valid,
		NoMeat,
		NoAlcohol,
		HighGrade,
		AttainmentNotMeet,
		ToolNotMeet,
		MaterialNotMeet,
		BuildingNotMeet
	}

	private static readonly LocalObjectPool<Inventory> LocalObjectPool = new LocalObjectPool<Inventory>(2, 4);

	/// <summary>
	/// 物品索引
	/// </summary>
	[SerializableGameDataField]
	private ItemKey _key;

	/// <summary>
	/// 特殊互动
	/// </summary>
	[SerializableGameDataField]
	private bool _isSpecialInteractItem;

	/// <summary>
	/// 数量
	/// </summary>
	[SerializableGameDataField]
	public int Amount;

	/// <summary>
	/// 当前耐久
	/// </summary>
	[SerializableGameDataField]
	public short Durability;

	/// <summary>
	/// 最大耐久
	/// </summary>
	[SerializableGameDataField]
	public short MaxDurability;

	/// <summary>
	/// 重量
	/// </summary>
	[SerializableGameDataField]
	public int Weight;

	/// <summary>
	/// 价值
	/// </summary>
	[SerializableGameDataField]
	public long Value;

	/// <summary>
	/// 特殊参数(促织的colorId,partID、相枢剑柄可施展功法封装于该字段)
	/// </summary>
	[SerializableGameDataField]
	public int SpecialArg;

	/// <summary>
	/// 装备使用槽位<see cref="T:GameData.Domains.Character.EquipmentSlot" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte EquipmentSlot = -1;

	/// <summary>
	/// 装备特效词条ID，仅用于装备
	/// </summary>
	[SerializableGameDataField]
	public List<short> EquipmentEffectIds;

	/// <summary>
	/// 威力值，仅用于武器和防具
	/// </summary>
	[SerializableGameDataField]
	public ItemPowerInfo PowerInfo;

	/// <summary>
	/// 使用需求，仅用于武器和防具
	/// </summary>
	[SerializableGameDataField]
	public List<(int type, int required, int actual)> Requirements;

	/// <summary>
	/// 破甲/破刃，仅用于武器和防具
	/// </summary>
	[SerializableGameDataField]
	public short EquipmentAttack;

	/// <summary>
	/// 坚韧，仅用于武器和防具
	/// </summary>
	[SerializableGameDataField]
	public short EquipmentDefense;

	/// <summary>
	/// 改制衣装目标的模板ID，拿来显示衣装外观
	/// </summary>
	[SerializableGameDataField]
	public short WeavedClothingTemplateId;

	/// <summary>
	/// 命中化解因子，仅用于武器和防具
	/// </summary>
	[SerializableGameDataField]
	public HitOrAvoidShorts HitAvoidFactor;

	/// <summary>
	/// 攻防值，仅用于武器（破体破气总值、无效值）和防具（御体、御气）
	/// </summary>
	[SerializableGameDataField]
	public (short, short) PenetrationInfo;

	/// <summary>
	/// 减伤因子，仅用于防具
	/// </summary>
	[SerializableGameDataField]
	public OuterAndInnerShorts InjuryFactors;

	/// <summary>
	/// 武器破气比例，仅用于武器，范围0-100
	/// 注意这里是实际值而非期待值
	/// </summary>
	[SerializableGameDataField]
	public sbyte WeaponInnerRatio;

	/// <summary>
	/// 武器的式
	/// </summary>
	[SerializableGameDataField]
	public List<sbyte> WeaponTrickList;

	/// <summary>
	/// 装备加的人物属性，key是ECharacterPropertyReferencedType
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, int> EquipmentPropertyBonusDict;

	/// <summary>
	/// 促织数据，仅用于促织类型物品
	/// </summary>
	[SerializableGameDataField]
	public CricketData CricketData;

	/// <summary>
	/// 精制信息，仅用于部分装备
	/// </summary>
	[SerializableGameDataField]
	public RefiningEffects RefiningEffects;

	/// <summary>
	/// 淬毒信息
	/// </summary>
	[SerializableGameDataField]
	public FullPoisonEffects PoisonEffects;

	/// <summary>
	/// 物品制造时花费的材料份数，用于修理
	/// </summary>
	[SerializableGameDataField]
	public MaterialResources MaterialResources;

	[SerializableGameDataField]
	public int AlertFactor;

	/// <summary>
	/// 合并显示的有毒物品，不包含自己，key是物品的key，value是数量
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<ItemKey, int> MergedPoisonItemDict;

	/// <summary>
	/// 合并显示的额外商品，不包含自己，key是物品的key，value是数量
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<ItemKey, int> MergedExtraGoodsItemDict;

	/// <summary>
	/// 物品来源 <see cref="T:GameData.Domains.Taiwu.ItemSourceType" /> 用于批量操作（拆解、修理、丢弃）的物品和工具
	/// </summary>
	[SerializableGameDataField]
	public sbyte ItemSourceType;

	/// <summary>
	/// 道具使用类型 <see cref="P:GameData.Domains.Item.Display.ItemDisplayData.UsingType" />
	/// </summary>
	[SerializableGameDataField]
	private sbyte _usingType = -1;

	/// <summary>
	/// 定情信物数据
	/// </summary>
	[SerializableGameDataField]
	public LoveTokenDataItem LoveTokenDataItem;

	/// <summary>
	/// 物品所有者的角色ID，构造时没传就会为无效值-1
	/// </summary>
	[SerializableGameDataField]
	public int OwnerCharId;

	/// <summary>
	/// 是否阅读完毕
	/// </summary>
	[SerializableGameDataField]
	public bool IsReadingFinished;

	/// <summary>
	/// 书页状态数组（0=完整，1=残缺，2=亡佚）
	/// </summary>
	[SerializableGameDataField]
	public sbyte[] BookPageStates;

	/// <summary>
	/// 书页研读进度数组（0-100）
	/// </summary>
	[SerializableGameDataField]
	public sbyte[] BookPageProgress;

	/// <summary>
	/// 书页类型数组（正读/逆读），仅功法书有效
	/// </summary>
	[SerializableGameDataField]
	public sbyte[] BookPageTypes;

	/// <summary>
	/// 蛟龙显示数据
	/// </summary>
	[SerializableGameDataField]
	public JiaoLoongDisplayData JiaoLoongDisplayData;

	/// <summary>
	/// 代步节省精力百分比
	/// </summary>
	[SerializableGameDataField]
	public sbyte TravelTimeReduction;

	/// <summary>
	/// 代步行囊大小
	/// </summary>
	[SerializableGameDataField]
	public short MaxInventoryLoadBonus;

	/// <summary>
	/// 野兽代步的驯服度
	/// </summary>
	[SerializableGameDataField]
	public int CarrierTamePoint;

	/// <summary>
	/// 是否已寄托的奇书
	/// </summary>
	[SerializableGameDataField]
	public bool IsThreeCorpseKeepingLegendaryBook;

	/// <summary>
	/// 额外商品类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte ExtraGoodsType;

	/// <summary>
	/// 道具不可用类型 <see cref="P:GameData.Domains.Item.Display.ItemDisplayData.UnavailableType" />
	/// </summary>
	[SerializableGameDataField]
	private sbyte _unavailableType;

	/// <summary>
	/// 商品价格变动百分比
	/// </summary>
	[SerializableGameDataField]
	public int PricePercent;

	/// <summary>
	/// 药物效果值，因有蛊虫等影响，故要从后端拿
	/// </summary>
	[SerializableGameDataField]
	public int MedicineEffectValue;

	/// <summary>
	/// 是否被太吾锁定
	/// </summary>
	[SerializableGameDataField]
	public bool IsLocked;

	/// <summary>
	/// 是否在当前促织预设中
	/// </summary>
	[SerializableGameDataField]
	public bool IsInCurrentCricketPreset;

	/// <summary>
	/// 武器特效显示数据列表
	/// </summary>
	[SerializableGameDataField]
	public List<WeaponEffectDisplayData> WeaponEffectDisplayDataList;

	/// <summary>
	/// 库房操作类型，仅前端用
	/// </summary>
	[Obsolete]
	public ETreasuryOperation TreasuryOperation;

	/// <summary>
	/// 商店物品的恩义状态，仅前端用
	/// </summary>
	[Obsolete]
	public EItemDebtState ItemDebtState;

	/// <summary>
	/// 商店物品的商店等级
	/// 在茶马帮UI中被用于存储物品的index以及各种信息
	/// </summary>
	public int ItemShopLevel;

	/// <summary>
	/// 是否可交互
	/// </summary>
	public bool Interactable;

	/// <summary>
	/// 商店物品的价格变化状态，仅前端用
	/// </summary>
	public EItemPriceState ItemPriceState;

	/// <summary>
	/// 耐久变化文本，用于批量操作消耗工具的列
	/// </summary>
	public string DurabilityChange;

	/// <summary>
	/// 制造所需造诣，排序用
	/// </summary>
	public int MakeNeedAttainment;

	/// <summary>
	/// 制造所需技艺类型
	/// </summary>
	public int MakeNeedLifeSKillType = -1;

	/// <summary>
	/// 制造可用工具数量，排序用
	/// </summary>
	public int MakeAvailableToolCount;

	/// <summary>
	/// 制造可用引子数量，排序用
	/// </summary>
	public int MakeAvailableMaterialCount;

	/// <summary>
	/// 制造推荐引子
	/// </summary>
	public ItemDisplayData MakeRecommendMaterial;

	/// <summary>
	/// 制造推荐工具
	/// </summary>
	public ItemDisplayData MakeRecommendTool;

	/// <summary>
	/// 代制数据
	/// </summary>
	public ProductionData ProductionData;

	/// <summary>
	/// 峨眉心法进度
	/// </summary>
	public int SpecialBreakProgress;

	/// <summary>
	/// 获取物品索引，
	/// 如果是可堆叠物品不能直接用于对比或选择，因为可能取到合并的淬毒物品，要用ContainsItemKey、GetAllItemKeysFromPool、GetOperationKeyListFromPool
	/// 如果需要提取部分Key，应考虑使用<see cref="M:GameData.Domains.Item.Display.ItemDisplayData.Take(System.Int32,System.Boolean)" />方法
	/// </summary>
	public ItemKey Key
	{
		get
		{
			Dictionary<ItemKey, int> mergedPoisonItemDict = MergedPoisonItemDict;
			if (mergedPoisonItemDict == null || mergedPoisonItemDict.Count <= 0)
			{
				mergedPoisonItemDict = MergedExtraGoodsItemDict;
				if (mergedPoisonItemDict == null || mergedPoisonItemDict.Count <= 0)
				{
					return _key;
				}
			}
			Inventory allInventoryFromPool = GetAllInventoryFromPool();
			ItemKey result = allInventoryFromPool.Items.GetRandomKey();
			ReturnInventoryToPool(allInventoryFromPool);
			return result;
		}
		set
		{
			_key = value;
		}
	}

	/// <summary>
	/// 物品真实key
	/// 如果需要对key做操作，应考虑使用<see cref="M:GameData.Domains.Item.Display.ItemDisplayData.Take(System.Int32,System.Boolean)" />方法
	/// </summary>
	public ItemKey RealKey => _key;

	bool ITradeableContent.Interactable
	{
		get
		{
			return Interactable;
		}
		set
		{
			Interactable = value;
		}
	}

	int ITradeableContent.Amount
	{
		get
		{
			return Amount;
		}
		set
		{
			Amount = value;
		}
	}

	long ITradeableContent.Value
	{
		get
		{
			return Value;
		}
		set
		{
			Value = value;
		}
	}

	bool ITradeableContent.IsResource => IsResource;

	bool ITradeableContent.IsReadingFinished => IsReadingFinished;

	bool ITradeableContent.HasAnyPoison => HasAnyPoison;

	bool ITradeableContent.PoisonIsIdentified => PoisonIsIdentified;

	bool ITradeableContent.IsThreeCorpseKeepingLegendaryBook => IsThreeCorpseKeepingLegendaryBook;

	sbyte ITradeableContent.ResourceType => ResourceType;

	sbyte ITradeableContent.ExtraGoodsType => ExtraGoodsType;

	sbyte ITradeableContent.WeaponInnerRatio => WeaponInnerRatio;

	List<sbyte> ITradeableContent.WeaponTrickList => WeaponTrickList;

	sbyte ITradeableContent.ItemSourceType => ItemSourceType;

	short ITradeableContent.CricketColorId => CricketColorId;

	short ITradeableContent.CricketPartId => CricketPartId;

	int ITradeableContent.CarrierTamePoint => CarrierTamePoint;

	int ITradeableContent.Weight => Weight;

	int ITradeableContent.Durability => Durability;

	int ITradeableContent.MaxDurability => MaxDurability;

	int ITradeableContent.EquipmentAttack => EquipmentAttack;

	int ITradeableContent.EquipmentDefense => EquipmentDefense;

	int ITradeableContent.OwnerCharId => OwnerCharId;

	int ITradeableContent.SpecialArg => SpecialArg;

	int ITradeableContent.MaxInventoryLoadBonus => MaxInventoryLoadBonus;

	int ITradeableContent.TravelTimeReduction => TravelTimeReduction;

	sbyte[] ITradeableContent.BookPageStates => BookPageStates;

	sbyte[] ITradeableContent.BookPageProgress => BookPageProgress;

	sbyte[] ITradeableContent.BookPageTypes => BookPageTypes;

	bool ITradeableContent.IsCombatBook => ItemTemplateHelper.GetItemSubType(_key.ItemType, _key.TemplateId) == 1001;

	string ITradeableContent.DurabilityChange => DurabilityChange;

	ItemPowerInfo ITradeableContent.PowerInfo => PowerInfo;

	JiaoLoongDisplayData ITradeableContent.JiaoLoongDisplayData => JiaoLoongDisplayData;

	ItemUsingType ITradeableContent.UsingType => UsingType;

	HitOrAvoidShorts ITradeableContent.HitAvoidFactor => HitAvoidFactor;

	OuterAndInnerShorts ITradeableContent.InjuryFactors => InjuryFactors;

	CricketData ITradeableContent.CricketData => CricketData;

	FullPoisonEffects ITradeableContent.PoisonEffects => PoisonEffects;

	ItemUnavailableType ITradeableContent.UnavailableType => UnavailableType;

	int ITradeableContent.MedicineEffectValue => MedicineEffectValue;

	bool ITradeableContent.IsLocked => IsLocked;

	bool ITradeableContent.IsInCurrentCricketPreset => IsInCurrentCricketPreset;

	public bool IsSpecialInteract
	{
		get
		{
			return _isSpecialInteractItem;
		}
		set
		{
			_isSpecialInteractItem = value;
		}
	}

	int IItemData.Value => (int)Value;

	short IItemData.Durability => Durability;

	short IItemData.MaxDurability => MaxDurability;

	int ITradeableContent.AlertFactor => AlertFactor;

	/// <summary>
	/// 物品来源
	/// </summary>
	public ItemSourceType ItemSourceTypeEnum => (ItemSourceType)ItemSourceType;

	/// <summary>
	/// 道具使用类型
	/// </summary>
	public ItemUsingType UsingType
	{
		get
		{
			return (ItemUsingType)_usingType;
		}
		set
		{
			_usingType = (sbyte)value;
		}
	}

	/// <summary>
	/// 道具不可用类型
	/// </summary>
	public ItemUnavailableType UnavailableType
	{
		get
		{
			return (ItemUnavailableType)_unavailableType;
		}
		set
		{
			_unavailableType = (sbyte)value;
		}
	}

	/// <summary>
	/// 是否经过改制
	/// </summary>
	public bool IsWeaved
	{
		get
		{
			if (_key.ItemType == 3 && WeavedClothingTemplateId >= 0)
			{
				return WeavedClothingTemplateId != _key.TemplateId;
			}
			return false;
		}
	}

	/// <summary>
	/// 判断此道具堆是否含有淬毒物品
	/// </summary>
	public bool HasAnyPoison
	{
		get
		{
			if (ModificationStateHelper.IsActive(_key.ModificationState, 1))
			{
				return true;
			}
			if (MergedPoisonItemDict != null && MergedPoisonItemDict.Count > 0)
			{
				return true;
			}
			return false;
		}
	}

	/// <summary>
	/// 判断此道具堆是否含有额外商品
	/// </summary>
	public bool HasAnyExtraGoods
	{
		get
		{
			if (ModificationStateHelper.IsActive(_key.ModificationState, 8))
			{
				return true;
			}
			if (MergedExtraGoodsItemDict != null && MergedExtraGoodsItemDict.Count > 0)
			{
				return true;
			}
			return false;
		}
	}

	/// <summary>
	/// 毒是否鉴定
	/// </summary>
	public bool PoisonIsIdentified => PoisonEffects?.IsIdentified ?? false;

	/// <summary>
	/// 是否为资源物品
	/// </summary>
	public bool IsResource => ItemTemplateHelper.IsMiscResource(_key.ItemType, _key.TemplateId);

	/// <summary>
	/// 资源类型
	/// </summary>
	public sbyte ResourceType
	{
		get
		{
			if (!IsResource)
			{
				return -1;
			}
			return ItemTemplateHelper.GetMiscResourceType(_key.ItemType, _key.TemplateId);
		}
	}

	/// <summary>
	/// 可让渡
	/// </summary>
	public bool IsTransferable => ItemTemplateHelper.IsTransferable(_key.ItemType, _key.TemplateId);

	/// <summary>
	/// 额外商品类型
	/// </summary>
	public MerchantExtraGoodsType ExtraGoodsTypeEnum => (MerchantExtraGoodsType)ExtraGoodsType;

	/// <summary>
	/// 品级
	/// </summary>
	public sbyte Grade
	{
		get
		{
			if (!RealKey.HasTemplate)
			{
				return -1;
			}
			return ItemTemplateHelper.GetGrade(RealKey.ItemType, RealKey.TemplateId);
		}
	}

	[Obsolete("This property is obsolete, use PowerInfo.Power instead.")]
	public short EquipCurrPower => PowerInfo.Power;

	[Obsolete("This property is obsolete, use PowerInfo.MaxPower instead.")]
	public short EquipMaxPower => PowerInfo.MaxPower;

	public short CricketColorId => (short)(SpecialArg >> 16);

	public short CricketPartId => (short)(SpecialArg & 0xFFFF);

	ITradeableContent ITradeableContent.Clone(int amount)
	{
		return Clone(amount);
	}

	void ITradeableContent.ChangeAmount(Inventory inventory, bool isAdd)
	{
		ChangeAmount(inventory, isAdd);
	}

	void ITradeableContent.ChangeAmount(ItemKey itemKey, bool isAdd)
	{
		ChangeAmount(itemKey, isAdd);
	}

	bool ITradeableContent.ContainsItemKey(ItemKey key)
	{
		return ContainsItemKey(key);
	}

	Inventory ITradeableContent.GetAllInventoryFromPool()
	{
		return GetAllInventoryFromPool();
	}

	Inventory ITradeableContent.GetOperationInventoryFromPool(int amount, bool preview)
	{
		return GetOperationInventoryFromPool(amount, preview);
	}

	/// <summary>
	/// 从对象池获取，必须归还
	/// </summary>
	/// <returns></returns>
	public static Inventory GetInventoryFromPool()
	{
		return LocalObjectPool.Get();
	}

	/// <summary>
	/// 获取若干物品key
	/// 物品真实数量少于amount个，或小于0时会报错（继承自GetOperationInventoryFromPool）
	/// 可能会以堆叠形式返回物品（即，amount &gt; 1）
	/// </summary>
	/// <param name="amount">可以为0，但不能为负数</param>
	/// <param name="isPreview"></param>
	/// <returns></returns>
	public IEnumerable<(ItemKey Key, int Amount)> Take(int amount, bool isPreview = true)
	{
		if (amount == 0)
		{
			yield break;
		}
		Inventory inventory = GetOperationInventoryFromPool(amount, isPreview);
		foreach (KeyValuePair<ItemKey, int> kv in inventory.Items)
		{
			yield return (Key: kv.Key, Amount: kv.Value);
		}
		ReturnInventoryToPool(inventory);
	}

	/// <summary>
	/// 归还到对象池
	/// </summary>
	/// <param name="list"></param>
	public static void ReturnInventoryToPool(Inventory list)
	{
		list.Items.Clear();
		LocalObjectPool.Return(list);
	}

	/// <summary>
	/// 获取所有的key，1个数量1个key，堆叠物品的key会重复，要归还
	/// 资源物品只有1个key
	/// </summary>
	/// <returns></returns>
	public Inventory GetAllInventoryFromPool()
	{
		Inventory inventory = GetInventoryFromPool();
		int remainCount = Amount;
		if (IsResource)
		{
			inventory.OfflineAddUncheck(_key, 1);
		}
		else
		{
			ItemKey key;
			int value;
			if (MergedPoisonItemDict != null && MergedPoisonItemDict.Count > 0)
			{
				foreach (KeyValuePair<ItemKey, int> item in MergedPoisonItemDict)
				{
					item.Deconstruct(out key, out value);
					ItemKey key2 = key;
					int count = value;
					inventory.OfflineAddUncheck(key2, count);
					remainCount -= count;
				}
			}
			if (MergedExtraGoodsItemDict != null && MergedExtraGoodsItemDict.Count > 0)
			{
				foreach (KeyValuePair<ItemKey, int> item2 in MergedExtraGoodsItemDict)
				{
					item2.Deconstruct(out key, out value);
					ItemKey key3 = key;
					int count2 = value;
					inventory.OfflineAddUncheck(key3, count2);
					remainCount -= count2;
				}
			}
			if (remainCount > 0)
			{
				inventory.OfflineAddUncheck(_key, remainCount);
			}
		}
		return inventory;
	}

	/// <summary>
	/// 根据数量获得Key的列表，并减少对应数量的合并的淬毒条目，要先于ChangeAmount调用。用于对物品的复数操作。list用过必须归还。
	/// 资源物品不应用此方法
	/// </summary>
	/// <param name="amount"></param>
	/// <param name="preview">预览模式不处理毒素，如需处理可后面手动调用ChangeAmount</param>
	/// <returns></returns>
	public Inventory GetOperationInventoryFromPool(int amount, bool preview = false)
	{
		Tester.Assert(amount <= Amount && amount > 0 && !IsResource);
		Inventory allInventory = GetAllInventoryFromPool();
		if (amount < Amount)
		{
			int count = amount;
			Inventory operationInventory = GetInventoryFromPool();
			while (count > 0)
			{
				allInventory.Items.GetRandomItem().Deconstruct(out var key, out var value);
				ItemKey key2 = key;
				int curCount = value;
				curCount = Math.Min(curCount, count);
				operationInventory.OfflineAddUncheck(key2, curCount);
				allInventory.OfflineRemove(key2, curCount);
				count -= curCount;
			}
			ReturnInventoryToPool(allInventory);
			allInventory = operationInventory;
		}
		if (!preview)
		{
			ChangePoisonData(allInventory);
			ChangeExtraGoodData(allInventory);
		}
		return allInventory;
	}

	/// <summary>
	/// 在同一界面的两个容器之间，对物品进行非全部数量的操作时，要处理淬毒数据，比如商店、仓库。其他时候是否处理无所谓，因为切换界面会刷新。
	/// </summary>
	/// <param name="inventory">来自GetOperationKeyListFromPool</param>
	private void ChangePoisonData(Inventory inventory)
	{
		if (MergedPoisonItemDict == null || MergedPoisonItemDict.Count <= 0)
		{
			return;
		}
		foreach (var (key, amount) in inventory.Items)
		{
			if (MergedPoisonItemDict.TryGetValue(key, out var count))
			{
				count -= amount;
				if (count <= 0)
				{
					MergedPoisonItemDict.Remove(key);
				}
				else
				{
					MergedPoisonItemDict[key] = count;
				}
			}
		}
	}

	/// <summary>
	/// 在同一界面的两个容器之间，对物品进行非全部数量的操作时，要处理额外商品数据，比如商店。其他时候是否处理无所谓，因为切换界面会刷新。
	/// </summary>
	/// <param name="inventory">来自GetOperationKeyListFromPool</param>
	private void ChangeExtraGoodData(Inventory inventory)
	{
		if (MergedExtraGoodsItemDict == null || MergedExtraGoodsItemDict.Count <= 0)
		{
			return;
		}
		foreach (var (key, amount) in inventory.Items)
		{
			if (MergedExtraGoodsItemDict.TryGetValue(key, out var count))
			{
				count -= amount;
				if (count <= 0)
				{
					MergedExtraGoodsItemDict.Remove(key);
				}
				else
				{
					MergedExtraGoodsItemDict[key] = count;
				}
			}
		}
	}

	public bool PoisonEquals(ItemDisplayData other)
	{
		if (_key.TemplateEquals(other._key))
		{
			return PoisonEffects == other.PoisonEffects;
		}
		return false;
	}

	/// <summary>
	/// 检查是否包含目标ItemKey
	/// </summary>
	/// <param name="targetKey"></param>
	/// <returns></returns>
	public bool ContainsItemKey(ItemKey targetKey)
	{
		if (_key.Equals(targetKey))
		{
			return true;
		}
		if (targetKey.IsValid() && (HasAnyPoison || HasAnyExtraGoods) && ItemTemplateHelper.IsStackable(targetKey.ItemType, targetKey.TemplateId))
		{
			Inventory allInventoryFromPool = GetAllInventoryFromPool();
			bool contain = allInventoryFromPool.Items.ContainsKey(targetKey);
			ReturnInventoryToPool(allInventoryFromPool);
			return contain;
		}
		return false;
	}

	/// <summary>
	/// 是否可合并
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public bool CanMerge(ItemDisplayData other)
	{
		if (!_key.TemplateEquals(other._key))
		{
			return false;
		}
		if (ItemTemplateHelper.IsMiscResource(_key.ItemType, _key.TemplateId))
		{
			return true;
		}
		if (!ItemTemplateHelper.IsStackable(other.Key.ItemType, other.Key.TemplateId))
		{
			return false;
		}
		if (ModificationStateHelper.IsActive(_key.ModificationState, 8) || ModificationStateHelper.IsActive(other._key.ModificationState, 8))
		{
			if (ExtraGoodsTypeEnum > MerchantExtraGoodsType.None)
			{
				return ExtraGoodsTypeEnum == other.ExtraGoodsTypeEnum;
			}
			return false;
		}
		if (PoisonIsIdentified && other.PoisonIsIdentified)
		{
			return PoisonEquals(other);
		}
		if (!PoisonIsIdentified && !other.PoisonIsIdentified)
		{
			return true;
		}
		return false;
	}

	public ItemDisplayData()
	{
		_key = ItemKey.Invalid;
		RefiningEffects.Initialize();
		UsingType = ItemUsingType.Invalid;
		LoveTokenDataItem = new LoveTokenDataItem();
		OwnerCharId = -1;
		WeavedClothingTemplateId = -1;
	}

	public ItemDisplayData Clone(int amount = -1)
	{
		ItemDisplayData newData = new ItemDisplayData
		{
			_key = _key,
			Amount = ((amount == -1) ? Amount : amount),
			Durability = Durability,
			MaxDurability = MaxDurability,
			Weight = Weight,
			SpecialArg = SpecialArg,
			EquipmentEffectIds = ((EquipmentEffectIds == null) ? null : new List<short>(EquipmentEffectIds)),
			EquipmentAttack = EquipmentAttack,
			EquipmentDefense = EquipmentDefense,
			WeavedClothingTemplateId = WeavedClothingTemplateId,
			HitAvoidFactor = HitAvoidFactor,
			PenetrationInfo = PenetrationInfo,
			InjuryFactors = InjuryFactors,
			EquipmentSlot = EquipmentSlot,
			PowerInfo = PowerInfo,
			WeaponTrickList = WeaponTrickList,
			RefiningEffects = RefiningEffects,
			PoisonEffects = PoisonEffects,
			MaterialResources = MaterialResources,
			MergedPoisonItemDict = MergedPoisonItemDict,
			MergedExtraGoodsItemDict = MergedExtraGoodsItemDict,
			UsingType = UsingType,
			ItemSourceType = ItemSourceType,
			LoveTokenDataItem = LoveTokenDataItem,
			OwnerCharId = OwnerCharId,
			IsReadingFinished = IsReadingFinished,
			CarrierTamePoint = CarrierTamePoint,
			ExtraGoodsType = ExtraGoodsType,
			WeaponInnerRatio = WeaponInnerRatio,
			CricketData = ((CricketData != null) ? new CricketData(CricketData) : null),
			MaxInventoryLoadBonus = MaxInventoryLoadBonus,
			TravelTimeReduction = TravelTimeReduction,
			IsThreeCorpseKeepingLegendaryBook = IsThreeCorpseKeepingLegendaryBook,
			BookPageStates = BookPageStates,
			BookPageProgress = BookPageProgress,
			BookPageTypes = BookPageTypes,
			MedicineEffectValue = MedicineEffectValue,
			IsLocked = IsLocked,
			IsInCurrentCricketPreset = IsInCurrentCricketPreset,
			EquipmentPropertyBonusDict = EquipmentPropertyBonusDict,
			JiaoLoongDisplayData = JiaoLoongDisplayData
		};
		newData.Value = (IsResource ? (GlobalConfig.ResourcesWorth[ResourceType] * newData.Amount) : Value);
		if (Requirements != null)
		{
			newData.Requirements = new List<(int, int, int)>();
			newData.Requirements.AddRange(Requirements);
		}
		return newData;
	}

	/// <summary>
	/// 复制
	/// </summary>
	public ItemDisplayData Clone(ItemKey itemKey, sbyte itemSourceType)
	{
		ItemDisplayData itemDisplayData = Clone(1);
		itemDisplayData._key = itemKey;
		itemDisplayData.ItemSourceType = itemSourceType;
		itemDisplayData.MergedPoisonItemDict = new Dictionary<ItemKey, int>();
		itemDisplayData.MergedExtraGoodsItemDict = new Dictionary<ItemKey, int>();
		itemDisplayData.PoisonEffects = ((PoisonEffects == null) ? null : new FullPoisonEffects(PoisonEffects));
		return itemDisplayData;
	}

	/// <summary>
	/// 附带合并信息的复制，操作复数物品时用此方法复制
	/// </summary>
	/// <param name="keyList">来自GetOperationKeyListFromPool</param>
	/// <param name="itemSourceType"></param>
	/// <returns></returns>
	public ItemDisplayData Clone(List<ItemKey> keyList, sbyte itemSourceType)
	{
		ItemDisplayData newData = Clone(keyList.Count);
		newData.ItemSourceType = itemSourceType;
		newData.MergedPoisonItemDict = new Dictionary<ItemKey, int>();
		newData.MergedExtraGoodsItemDict = new Dictionary<ItemKey, int>();
		int poisonKeyIndex = keyList.FindIndex((ItemKey k) => !ModificationStateHelper.IsActive(k.ModificationState, 1));
		newData._key = ((poisonKeyIndex >= 0) ? keyList[poisonKeyIndex] : keyList.First());
		if (keyList.Count > 1)
		{
			foreach (ItemKey key in keyList)
			{
				if (!newData._key.Equals(key))
				{
					if (ModificationStateHelper.IsActive(key.ModificationState, 1))
					{
						newData.MergedPoisonItemDict.TryGetValue(key, out var count);
						count++;
						newData.MergedPoisonItemDict[key] = count;
					}
					if (ModificationStateHelper.IsActive(key.ModificationState, 8))
					{
						newData.MergedExtraGoodsItemDict.TryGetValue(key, out var count2);
						count2++;
						newData.MergedExtraGoodsItemDict[key] = count2;
					}
				}
			}
		}
		newData.PoisonEffects = ((PoisonEffects == null) ? null : new FullPoisonEffects(PoisonEffects));
		return newData;
	}

	/// <summary>
	/// 已经克隆出物品后如果还需要合并、拆开，用此方法改变数量
	/// </summary>
	/// <param name="inventory">来自GetOperationKeyListFromPool</param>
	/// <param name="isAdd"></param>
	public void ChangeAmount(Inventory inventory, bool isAdd)
	{
		foreach (var (key, amount) in inventory.Items)
		{
			ChangeAmount(key, isAdd, amount);
		}
	}

	/// <summary>
	/// 已经克隆出物品后如果还需要合并、拆开，用此方法改变数量。
	/// 可能会交换_key和MergedPoisonItemDict，以保证_key尽可能是无毒的，而有毒的尽可能在MergedPoisonItemDict
	/// </summary>
	/// <param name="itemKey">来自GetOperationKeyListFromPool或者.Key</param>
	/// <param name="isAdd"></param>
	/// <param name="amount"></param>
	public void ChangeAmount(ItemKey itemKey, bool isAdd, int amount = 1)
	{
		if (isAdd)
		{
			Amount += amount;
		}
		else
		{
			Amount -= amount;
		}
		if (MergedExtraGoodsItemDict == null)
		{
			MergedExtraGoodsItemDict = new Dictionary<ItemKey, int>();
		}
		if (ModificationStateHelper.IsActive(itemKey.ModificationState, 8))
		{
			MergedExtraGoodsItemDict.TryGetValue(itemKey, out var count);
			count = ((!isAdd) ? (count - amount) : (count + amount));
			MergedExtraGoodsItemDict[itemKey] = count;
			if (count <= 0)
			{
				MergedExtraGoodsItemDict.Remove(itemKey);
			}
		}
		else if (ModificationStateHelper.IsActive(_key.ModificationState, 8))
		{
			MergedExtraGoodsItemDict[_key] = amount;
			_key = itemKey;
		}
		if (MergedPoisonItemDict == null)
		{
			MergedPoisonItemDict = new Dictionary<ItemKey, int>();
		}
		if (ModificationStateHelper.IsActive(itemKey.ModificationState, 1))
		{
			MergedPoisonItemDict.TryGetValue(itemKey, out var count2);
			count2 = ((!isAdd) ? (count2 - amount) : (count2 + amount));
			MergedPoisonItemDict[itemKey] = count2;
			if (count2 <= 0)
			{
				MergedPoisonItemDict.Remove(itemKey);
			}
		}
		else if (ModificationStateHelper.IsActive(_key.ModificationState, 1))
		{
			MergedPoisonItemDict[_key] = amount;
			_key = itemKey;
		}
	}

	public ItemDisplayData(ItemKey itemKey, int amount)
	{
		_key = itemKey;
		Amount = amount;
		MaterialResources.Initialize();
		RefiningEffects.Initialize();
		EquipmentEffectIds = null;
		LoveTokenDataItem = new LoveTokenDataItem(-1, -1, -1, -1, isTaiwuPresent: false);
	}

	/// <summary>
	/// 基于纯配置构建前端使用的 ItemDisplayData
	/// </summary>
	public ItemDisplayData(sbyte itemType, short templateId)
	{
		_key = new ItemKey(itemType, 0, templateId, -1);
		Amount = 1;
		Durability = (MaxDurability = ItemTemplateHelper.GetBaseMaxDurability(itemType, templateId));
		Weight = ItemTemplateHelper.GetBaseWeight(itemType, templateId);
		Value = ItemTemplateHelper.GetBaseValue(itemType, templateId);
		EquipmentEffectIds = null;
		MaterialResources.Initialize();
		WeavedClothingTemplateId = -1;
		switch (itemType)
		{
		case 0:
		{
			WeaponItem config2 = Weapon.Instance[templateId];
			EquipmentAttack = config2.BaseEquipmentAttack;
			EquipmentDefense = config2.BaseEquipmentDefense;
			HitAvoidFactor = config2.BaseHitFactors;
			PenetrationInfo.Item1 = config2.BasePenetrationFactor;
			break;
		}
		case 1:
		{
			ArmorItem config = Armor.Instance[templateId];
			EquipmentAttack = config.BaseEquipmentAttack;
			EquipmentDefense = config.BaseEquipmentDefense;
			HitAvoidFactor = config.BaseAvoidFactors;
			config.BasePenetrationResistFactors.Deconstruct(out PenetrationInfo.Item1, out PenetrationInfo.Item2);
			InjuryFactors = config.BaseInjuryFactors;
			break;
		}
		case 11:
			AdaptableLog.Warning("ItemDisplayData does not support cricket construction", appendWarningMessage: true);
			break;
		}
		RefiningEffects.Initialize();
		if ((uint)itemType <= 1u)
		{
			Requirements = new List<(int, int, int)>(((itemType == 0) ? Weapon.Instance[templateId].RequiredCharacterProperties : Armor.Instance[templateId].RequiredCharacterProperties).Select((PropertyAndValue x) => ((int, int, int))(x.PropertyId, x.Value, -1)));
			PowerInfo = ItemPowerInfo.Default;
		}
		ItemSourceType = -1;
		UsingType = ItemUsingType.Invalid;
		LoveTokenDataItem = new LoveTokenDataItem();
		OwnerCharId = -1;
	}

	/// <summary>
	/// 将资源转化为ItemDisplayData
	/// </summary>
	/// <param name="resourceType"></param>
	/// <param name="amount"></param>
	/// <param name="charId"></param>
	public static ItemDisplayData CreateResource(sbyte resourceType, int amount, int charId = -1)
	{
		return new ItemDisplayData
		{
			Key = new ItemKey(12, 0, Convert.ToInt16((int)resourceType), 0),
			Amount = amount,
			Value = amount * GlobalConfig.ResourcesWorth[resourceType],
			OwnerCharId = charId,
			ItemSourceType = 9
		};
	}

	/// <summary>
	/// 物品能否设置装备特效
	/// </summary>
	/// <returns></returns>
	public bool CanSetEquipmentEffect()
	{
		sbyte curType = Key.ItemType;
		if (!ItemType.IsEquipmentItemType(curType))
		{
			return false;
		}
		if (curType == 3 || curType == 4)
		{
			return false;
		}
		List<short> equipmentEffectIds = EquipmentEffectIds;
		if (equipmentEffectIds != null && equipmentEffectIds.Count > 0 && EquipmentEffect.Instance[EquipmentEffectIds[0]].Special)
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// 有装备特效词条
	/// </summary>
	/// <returns></returns>
	public bool HaveEquipmentEffect()
	{
		List<short> equipmentEffectIds = EquipmentEffectIds;
		if (equipmentEffectIds != null)
		{
			return equipmentEffectIds.Count > 0;
		}
		return false;
	}

	/// <summary>
	/// 清除物品的使用状态，前端用
	/// </summary>
	public static void ClearItemUsingState(ItemDisplayData itemData, List<ItemDisplayData> itemList)
	{
		ItemDisplayData item = itemList?.Find((ItemDisplayData data) => data.ContainsItemKey(itemData.Key));
		if (item != null)
		{
			item.UsingType = ItemUsingType.Invalid;
		}
	}

	public override string ToString()
	{
		return $"ItemDisplayData({Key}, {Amount}, {Durability}/{MaxDurability})";
	}

	public sbyte GetContentType()
	{
		return 0;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 138;
		totalSize = ((EquipmentEffectIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * EquipmentEffectIds.Count)));
		if (Requirements != null)
		{
			totalSize += 2;
			int elementsCount = Requirements.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				(int, int, int) element = Requirements[i];
				totalSize += SerializationHelper.GetSerializedSize(element);
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((WeaponTrickList == null) ? (totalSize + 2) : (totalSize + (2 + WeaponTrickList.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(EquipmentPropertyBonusDict);
		totalSize = ((CricketData == null) ? (totalSize + 2) : (totalSize + (2 + CricketData.GetSerializedSize())));
		totalSize = ((PoisonEffects == null) ? (totalSize + 2) : (totalSize + (2 + PoisonEffects.GetSerializedSize())));
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(MergedPoisonItemDict);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(MergedExtraGoodsItemDict);
		totalSize = ((BookPageStates == null) ? (totalSize + 2) : (totalSize + (2 + BookPageStates.Length)));
		totalSize = ((BookPageProgress == null) ? (totalSize + 2) : (totalSize + (2 + BookPageProgress.Length)));
		totalSize = ((BookPageTypes == null) ? (totalSize + 2) : (totalSize + (2 + BookPageTypes.Length)));
		totalSize = ((JiaoLoongDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + JiaoLoongDisplayData.GetSerializedSize())));
		if (WeaponEffectDisplayDataList != null)
		{
			totalSize += 2;
			int elementsCount2 = WeaponEffectDisplayDataList.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				totalSize += WeaponEffectDisplayDataList[j].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += _key.Serialize(pCurrData);
		*pCurrData = (_isSpecialInteractItem ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = Amount;
		pCurrData += 4;
		*(short*)pCurrData = Durability;
		pCurrData += 2;
		*(short*)pCurrData = MaxDurability;
		pCurrData += 2;
		*(int*)pCurrData = Weight;
		pCurrData += 4;
		*(long*)pCurrData = Value;
		pCurrData += 8;
		*(int*)pCurrData = SpecialArg;
		pCurrData += 4;
		*pCurrData = (byte)EquipmentSlot;
		pCurrData++;
		if (EquipmentEffectIds != null)
		{
			int elementsCount = EquipmentEffectIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = EquipmentEffectIds[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += PowerInfo.Serialize(pCurrData);
		if (Requirements != null)
		{
			int elementsCount2 = Requirements.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				(int, int, int) element = Requirements[j];
				pCurrData += SerializationHelper.Serialize(pCurrData, element);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = EquipmentAttack;
		pCurrData += 2;
		*(short*)pCurrData = EquipmentDefense;
		pCurrData += 2;
		*(short*)pCurrData = WeavedClothingTemplateId;
		pCurrData += 2;
		pCurrData += HitAvoidFactor.Serialize(pCurrData);
		pCurrData += SerializationHelper.Serialize(pCurrData, PenetrationInfo);
		pCurrData += InjuryFactors.Serialize(pCurrData);
		*pCurrData = (byte)WeaponInnerRatio;
		pCurrData++;
		if (WeaponTrickList != null)
		{
			int elementsCount3 = WeaponTrickList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData[k] = (byte)WeaponTrickList[k];
			}
			pCurrData += elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref EquipmentPropertyBonusDict);
		if (CricketData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CricketData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += RefiningEffects.Serialize(pCurrData);
		if (PoisonEffects != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = PoisonEffects.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += MaterialResources.Serialize(pCurrData);
		*(int*)pCurrData = AlertFactor;
		pCurrData += 4;
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref MergedPoisonItemDict);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref MergedExtraGoodsItemDict);
		*pCurrData = (byte)ItemSourceType;
		pCurrData++;
		*pCurrData = (byte)_usingType;
		pCurrData++;
		pCurrData += LoveTokenDataItem.Serialize(pCurrData);
		*(int*)pCurrData = OwnerCharId;
		pCurrData += 4;
		*pCurrData = (IsReadingFinished ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (BookPageStates != null)
		{
			int elementsCount4 = BookPageStates.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData[l] = (byte)BookPageStates[l];
			}
			pCurrData += elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BookPageProgress != null)
		{
			int elementsCount5 = BookPageProgress.Length;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				pCurrData[m] = (byte)BookPageProgress[m];
			}
			pCurrData += elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BookPageTypes != null)
		{
			int elementsCount6 = BookPageTypes.Length;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				pCurrData[n] = (byte)BookPageTypes[n];
			}
			pCurrData += elementsCount6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (JiaoLoongDisplayData != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = JiaoLoongDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)TravelTimeReduction;
		pCurrData++;
		*(short*)pCurrData = MaxInventoryLoadBonus;
		pCurrData += 2;
		*(int*)pCurrData = CarrierTamePoint;
		pCurrData += 4;
		*pCurrData = (IsThreeCorpseKeepingLegendaryBook ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)ExtraGoodsType;
		pCurrData++;
		*pCurrData = (byte)_unavailableType;
		pCurrData++;
		*(int*)pCurrData = PricePercent;
		pCurrData += 4;
		*(int*)pCurrData = MedicineEffectValue;
		pCurrData += 4;
		*pCurrData = (IsLocked ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsInCurrentCricketPreset ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (WeaponEffectDisplayDataList != null)
		{
			int elementsCount7 = WeaponEffectDisplayDataList.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				int subDataSize = WeaponEffectDisplayDataList[num].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
			}
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
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += _key.Deserialize(pCurrData);
		_isSpecialInteractItem = *pCurrData != 0;
		pCurrData++;
		Amount = *(int*)pCurrData;
		pCurrData += 4;
		Durability = *(short*)pCurrData;
		pCurrData += 2;
		MaxDurability = *(short*)pCurrData;
		pCurrData += 2;
		Weight = *(int*)pCurrData;
		pCurrData += 4;
		Value = *(long*)pCurrData;
		pCurrData += 8;
		SpecialArg = *(int*)pCurrData;
		pCurrData += 4;
		EquipmentSlot = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (EquipmentEffectIds == null)
			{
				EquipmentEffectIds = new List<short>(elementsCount);
			}
			else
			{
				EquipmentEffectIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				EquipmentEffectIds.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			EquipmentEffectIds?.Clear();
		}
		pCurrData += PowerInfo.Deserialize(pCurrData);
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (Requirements == null)
			{
				Requirements = new List<(int, int, int)>(elementsCount2);
			}
			else
			{
				Requirements.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += SerializationHelper.Deserialize(pCurrData, out (int, int, int) tuple);
				Requirements.Add(tuple);
			}
		}
		else
		{
			Requirements?.Clear();
		}
		EquipmentAttack = *(short*)pCurrData;
		pCurrData += 2;
		EquipmentDefense = *(short*)pCurrData;
		pCurrData += 2;
		WeavedClothingTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += HitAvoidFactor.Deserialize(pCurrData);
		pCurrData += SerializationHelper.Deserialize(pCurrData, out PenetrationInfo);
		pCurrData += InjuryFactors.Deserialize(pCurrData);
		WeaponInnerRatio = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (WeaponTrickList == null)
			{
				WeaponTrickList = new List<sbyte>(elementsCount3);
			}
			else
			{
				WeaponTrickList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				WeaponTrickList.Add((sbyte)pCurrData[k]);
			}
			pCurrData += (int)elementsCount3;
		}
		else
		{
			WeaponTrickList?.Clear();
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref EquipmentPropertyBonusDict);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (CricketData == null)
			{
				CricketData = new CricketData();
			}
			pCurrData += CricketData.Deserialize(pCurrData);
		}
		else
		{
			CricketData = null;
		}
		pCurrData += RefiningEffects.Deserialize(pCurrData);
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (PoisonEffects == null)
			{
				PoisonEffects = new FullPoisonEffects();
			}
			pCurrData += PoisonEffects.Deserialize(pCurrData);
		}
		else
		{
			PoisonEffects = null;
		}
		pCurrData += MaterialResources.Deserialize(pCurrData);
		AlertFactor = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref MergedPoisonItemDict);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref MergedExtraGoodsItemDict);
		ItemSourceType = (sbyte)(*pCurrData);
		pCurrData++;
		_usingType = (sbyte)(*pCurrData);
		pCurrData++;
		if (LoveTokenDataItem == null)
		{
			LoveTokenDataItem = new LoveTokenDataItem();
		}
		pCurrData += LoveTokenDataItem.Deserialize(pCurrData);
		OwnerCharId = *(int*)pCurrData;
		pCurrData += 4;
		IsReadingFinished = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (BookPageStates == null || BookPageStates.Length != elementsCount4)
			{
				BookPageStates = new sbyte[elementsCount4];
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				BookPageStates[l] = (sbyte)pCurrData[l];
			}
			pCurrData += (int)elementsCount4;
		}
		else
		{
			BookPageStates = null;
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (BookPageProgress == null || BookPageProgress.Length != elementsCount5)
			{
				BookPageProgress = new sbyte[elementsCount5];
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				BookPageProgress[m] = (sbyte)pCurrData[m];
			}
			pCurrData += (int)elementsCount5;
		}
		else
		{
			BookPageProgress = null;
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (BookPageTypes == null || BookPageTypes.Length != elementsCount6)
			{
				BookPageTypes = new sbyte[elementsCount6];
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				BookPageTypes[n] = (sbyte)pCurrData[n];
			}
			pCurrData += (int)elementsCount6;
		}
		else
		{
			BookPageTypes = null;
		}
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			if (JiaoLoongDisplayData == null)
			{
				JiaoLoongDisplayData = new JiaoLoongDisplayData();
			}
			pCurrData += JiaoLoongDisplayData.Deserialize(pCurrData);
		}
		else
		{
			JiaoLoongDisplayData = null;
		}
		TravelTimeReduction = (sbyte)(*pCurrData);
		pCurrData++;
		MaxInventoryLoadBonus = *(short*)pCurrData;
		pCurrData += 2;
		CarrierTamePoint = *(int*)pCurrData;
		pCurrData += 4;
		IsThreeCorpseKeepingLegendaryBook = *pCurrData != 0;
		pCurrData++;
		ExtraGoodsType = (sbyte)(*pCurrData);
		pCurrData++;
		_unavailableType = (sbyte)(*pCurrData);
		pCurrData++;
		PricePercent = *(int*)pCurrData;
		pCurrData += 4;
		MedicineEffectValue = *(int*)pCurrData;
		pCurrData += 4;
		IsLocked = *pCurrData != 0;
		pCurrData++;
		IsInCurrentCricketPreset = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (WeaponEffectDisplayDataList == null)
			{
				WeaponEffectDisplayDataList = new List<WeaponEffectDisplayData>(elementsCount7);
			}
			else
			{
				WeaponEffectDisplayDataList.Clear();
			}
			for (int num4 = 0; num4 < elementsCount7; num4++)
			{
				WeaponEffectDisplayData element = default(WeaponEffectDisplayData);
				pCurrData += element.Deserialize(pCurrData);
				WeaponEffectDisplayDataList.Add(element);
			}
		}
		else
		{
			WeaponEffectDisplayDataList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
