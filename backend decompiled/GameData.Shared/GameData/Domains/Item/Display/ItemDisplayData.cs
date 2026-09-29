using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.ConfigCells.Character;
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

[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class ItemDisplayData : IItemData, ITradeableContent, ISerializableGameData
{
	public enum ItemUsingType
	{
		Invalid = -1,
		Reading,
		EquipmentPlaned,
		Equiped,
		Breeding,
		Referring
	}

	public enum ItemUsingOperationType
	{
		Default,
		Sell,
		Store,
		Present,
		Bet,
		Give
	}

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

	[SerializableGameDataField]
	private ItemKey _key;

	[SerializableGameDataField]
	private bool _isSpecialInteractItem;

	[SerializableGameDataField]
	public int Amount;

	[SerializableGameDataField]
	public short Durability;

	[SerializableGameDataField]
	public short MaxDurability;

	[SerializableGameDataField]
	public int Weight;

	[SerializableGameDataField]
	public long Value;

	[SerializableGameDataField]
	public long ExchangeValue;

	[SerializableGameDataField]
	public int SpecialArg;

	[SerializableGameDataField]
	public sbyte EquipmentSlot = -1;

	[SerializableGameDataField]
	public List<short> EquipmentEffectIds;

	[SerializableGameDataField]
	public ItemPowerInfo PowerInfo;

	[SerializableGameDataField]
	public List<(int type, int required, int actual)> Requirements;

	[SerializableGameDataField]
	public short EquipmentAttack;

	[SerializableGameDataField]
	public short EquipmentDefense;

	[SerializableGameDataField]
	public short WeavedClothingTemplateId;

	[SerializableGameDataField]
	public HitOrAvoidShorts HitAvoidFactor;

	[SerializableGameDataField]
	public (short, short) PenetrationInfo;

	[SerializableGameDataField]
	public OuterAndInnerShorts InjuryFactors;

	[SerializableGameDataField]
	public sbyte WeaponInnerRatio;

	[SerializableGameDataField]
	public List<sbyte> WeaponTrickList;

	[SerializableGameDataField]
	public Dictionary<int, int> EquipmentPropertyBonusDict;

	[SerializableGameDataField]
	public CricketData CricketData;

	[SerializableGameDataField]
	public RefiningEffects RefiningEffects;

	[SerializableGameDataField]
	public FullPoisonEffects PoisonEffects;

	[SerializableGameDataField]
	public MaterialResources MaterialResources;

	[SerializableGameDataField]
	public int AlertFactor;

	[SerializableGameDataField]
	public Dictionary<ItemKey, int> MergedPoisonItemDict;

	[SerializableGameDataField]
	public Dictionary<ItemKey, int> MergedExtraGoodsItemDict;

	[SerializableGameDataField]
	public sbyte ItemSourceType;

	[SerializableGameDataField]
	private sbyte _usingType = -1;

	[SerializableGameDataField]
	public int OwnerCharId;

	[SerializableGameDataField]
	public bool IsReadingFinished;

	[SerializableGameDataField]
	public sbyte[] BookPageStates;

	[SerializableGameDataField]
	public sbyte[] BookPageProgress;

	[SerializableGameDataField]
	public sbyte[] BookPageTypes;

	[SerializableGameDataField]
	public JiaoLoongDisplayData JiaoLoongDisplayData;

	[SerializableGameDataField]
	public sbyte TravelTimeReduction;

	[SerializableGameDataField]
	public short MaxInventoryLoadBonus;

	[SerializableGameDataField]
	public int CarrierTamePoint;

	[SerializableGameDataField]
	public bool IsThreeCorpseKeepingLegendaryBook;

	[SerializableGameDataField]
	public sbyte ExtraGoodsType;

	[SerializableGameDataField]
	private sbyte _unavailableType;

	[SerializableGameDataField]
	public int PricePercent;

	[SerializableGameDataField]
	public int MedicineEffectValue;

	[SerializableGameDataField]
	public bool IsLocked;

	[SerializableGameDataField]
	public bool IsInCurrentCricketPreset;

	[SerializableGameDataField]
	public List<WeaponEffectDisplayData> WeaponEffectDisplayDataList;

	[SerializableGameDataField]
	public bool ForceNotTransferable;

	[Obsolete]
	public ETreasuryOperation TreasuryOperation;

	[Obsolete]
	public EItemDebtState ItemDebtState;

	public int ItemShopLevel;

	public bool Interactable;

	public EItemPriceState ItemPriceState;

	public string DurabilityChange;

	public int MakeNeedAttainment;

	public int MakeNeedLifeSKillType = -1;

	public int MakeAvailableToolCount;

	public int MakeAvailableMaterialCount;

	public ItemDisplayData MakeRecommendMaterial;

	public ItemDisplayData MakeRecommendTool;

	public ProductionData ProductionData;

	public int SpecialBreakProgress;

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

	public ItemKey RealKey
	{
		get
		{
			if (Amount > 0)
			{
				while (true)
				{
					int amount = Amount;
					IEnumerable<int> enumerable = MergedExtraGoodsItemDict?.Values;
					IEnumerable<int> first = enumerable ?? Enumerable.Empty<int>();
					enumerable = MergedPoisonItemDict?.Values;
					if (amount > first.Concat(enumerable ?? Enumerable.Empty<int>()).Sum())
					{
						break;
					}
					_key = Key;
					MergedExtraGoodsItemDict?.Remove(_key);
					MergedPoisonItemDict?.Remove(_key);
				}
			}
			return _key;
		}
	}

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

	long ITradeableContent.ExchangeValue
	{
		get
		{
			return ExchangeValue;
		}
		set
		{
			ExchangeValue = value;
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

	bool ITradeableContent.ForceNotTransferable => ForceNotTransferable;

	int IItemData.Value => (int)Value;

	short IItemData.Durability => Durability;

	short IItemData.MaxDurability => MaxDurability;

	int ITradeableContent.AlertFactor => AlertFactor;

	public ItemSourceType ItemSourceTypeEnum => (ItemSourceType)ItemSourceType;

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

	public bool PoisonIsIdentified => PoisonEffects?.IsIdentified ?? false;

	public bool IsResource => ItemTemplateHelper.IsMiscResource(_key.ItemType, _key.TemplateId);

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

	public bool IsTransferable => ItemTemplateHelper.IsTransferable(_key.ItemType, _key.TemplateId);

	public MerchantExtraGoodsType ExtraGoodsTypeEnum => (MerchantExtraGoodsType)ExtraGoodsType;

	public sbyte Grade
	{
		get
		{
			if (!_key.HasTemplate)
			{
				return -1;
			}
			return ItemTemplateHelper.GetGrade(_key.ItemType, _key.TemplateId);
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

	public static Inventory GetInventoryFromPool()
	{
		return LocalObjectPool.Get();
	}

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

	public static void ReturnInventoryToPool(Inventory list)
	{
		list.Items.Clear();
		LocalObjectPool.Return(list);
	}

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
			ChangeAmount(allInventory, isAdd: false);
		}
		return allInventory;
	}

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
			MergedPoisonItemDict = ((MergedPoisonItemDict != null) ? new Dictionary<ItemKey, int>(MergedPoisonItemDict) : null),
			MergedExtraGoodsItemDict = ((MergedExtraGoodsItemDict != null) ? new Dictionary<ItemKey, int>(MergedExtraGoodsItemDict) : null),
			UsingType = UsingType,
			ItemSourceType = ItemSourceType,
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
			JiaoLoongDisplayData = JiaoLoongDisplayData,
			PricePercent = PricePercent
		};
		newData.Value = (IsResource ? (GlobalConfig.ResourcesWorth[ResourceType] * newData.Amount) : Value);
		newData.ExchangeValue = ExchangeValue;
		if (Requirements != null)
		{
			newData.Requirements = new List<(int, int, int)>();
			newData.Requirements.AddRange(Requirements);
		}
		return newData;
	}

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

	public ItemDisplayData Clone(List<ItemKey> keyList, sbyte itemSourceType)
	{
		ItemDisplayData newData = Clone(keyList.Count);
		newData.ItemSourceType = itemSourceType;
		newData.MergedPoisonItemDict = new Dictionary<ItemKey, int>();
		newData.MergedExtraGoodsItemDict = new Dictionary<ItemKey, int>();
		newData._key = keyList[Math.Max(0, keyList.FindIndex((ItemKey k) => !ModificationStateHelper.IsActive(k.ModificationState, 1)))];
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

	public void ChangeAmount(Inventory inventory, bool isAdd)
	{
		foreach (var (key, amount) in inventory.Items)
		{
			ChangeAmount(key, isAdd, amount);
		}
	}

	public void ChangeAmount(ItemKey itemKey, bool isAdd, int amount = 1)
	{
		if (MergedExtraGoodsItemDict == null)
		{
			MergedExtraGoodsItemDict = new Dictionary<ItemKey, int>();
		}
		if (MergedPoisonItemDict == null)
		{
			MergedPoisonItemDict = new Dictionary<ItemKey, int>();
		}
		int keyAmount = 0;
		if (itemKey != _key)
		{
			keyAmount = Amount - (from kv in MergedPoisonItemDict.Concat(MergedExtraGoodsItemDict)
				select kv.Value).Sum();
		}
		if (isAdd)
		{
			Amount += amount;
		}
		else
		{
			Amount -= amount;
		}
		if (itemKey == _key)
		{
			keyAmount = Amount - (from kv in MergedPoisonItemDict.Concat(MergedExtraGoodsItemDict)
				select kv.Value).Sum();
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
			if (keyAmount > 0)
			{
				MergedExtraGoodsItemDict[_key] = keyAmount;
			}
			_key = itemKey;
			keyAmount = Amount - (from kv in MergedPoisonItemDict.Concat(MergedExtraGoodsItemDict)
				select kv.Value).Sum();
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
			if (keyAmount > 0)
			{
				MergedPoisonItemDict[_key] = keyAmount;
			}
			_key = itemKey;
			keyAmount = Amount - (from kv in MergedPoisonItemDict.Concat(MergedExtraGoodsItemDict)
				select kv.Value).Sum();
		}
		if (keyAmount == 0)
		{
			_key = Key;
			MergedExtraGoodsItemDict.Remove(_key);
			MergedPoisonItemDict.Remove(_key);
		}
	}

	public ItemDisplayData(ItemKey itemKey, int amount)
	{
		_key = itemKey;
		Amount = amount;
		MaterialResources.Initialize();
		RefiningEffects.Initialize();
		EquipmentEffectIds = null;
	}

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
		OwnerCharId = -1;
	}

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

	public bool HaveEquipmentEffect()
	{
		List<short> equipmentEffectIds = EquipmentEffectIds;
		if (equipmentEffectIds != null)
		{
			return equipmentEffectIds.Count > 0;
		}
		return false;
	}

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

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 127;
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
		*(long*)pCurrData = ExchangeValue;
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
		*pCurrData = (ForceNotTransferable ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
		ExchangeValue = *(long*)pCurrData;
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
		ForceNotTransferable = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
