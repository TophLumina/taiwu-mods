using System.Collections.Generic;
using GameData.DLC.FiveLoong;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Taiwu.ExchangeSystem;
using GameData.Serializer;

namespace GameData.Domains.Item.Display;

public interface ITradeableContent : ISerializableGameData
{
	bool Interactable { get; set; }

	long Value { get; set; }

	int Amount { get; set; }

	ItemKey Key { get; }

	ItemKey RealKey { get; }

	sbyte Grade { get; }

	sbyte Gender => -1;

	int CharacterId => -1;

	OrganizationInfo OrganizationInfo => default(OrganizationInfo);

	NameRelatedData NameRelatedData => default(NameRelatedData);

	AvatarRelatedData AvatarRelatedData => null;

	bool IsResource => false;

	bool IsReadingFinished => false;

	bool HasAnyPoison => false;

	bool PoisonIsIdentified => false;

	bool IsThreeCorpseKeepingLegendaryBook => false;

	sbyte ResourceType => -1;

	sbyte ExtraGoodsType => -1;

	sbyte WeaponInnerRatio => 50;

	List<sbyte> WeaponTrickList => null;

	sbyte ItemSourceType => -1;

	short CricketColorId => -1;

	short CricketPartId => -1;

	int CarrierTamePoint => 0;

	int Weight => 0;

	int Durability => 0;

	int MaxDurability => -1;

	int EquipmentAttack => 0;

	int EquipmentDefense => 0;

	int OwnerCharId => -1;

	int SpecialArg => -1;

	int MaxInventoryLoadBonus => -1;

	int TravelTimeReduction => -1;

	long ExchangeValue
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

	sbyte[] BookPageStates => null;

	sbyte[] BookPageProgress => null;

	sbyte[] BookPageTypes => null;

	bool IsCombatBook => false;

	string DurabilityChange => string.Empty;

	ItemPowerInfo PowerInfo => default(ItemPowerInfo);

	JiaoLoongDisplayData JiaoLoongDisplayData => null;

	ItemDisplayData.ItemUsingType UsingType => ItemDisplayData.ItemUsingType.Invalid;

	(short, short) PenetrationInfo => default((short, short));

	HitOrAvoidShorts HitAvoidFactor => default(HitOrAvoidShorts);

	OuterAndInnerShorts InjuryFactors => default(OuterAndInnerShorts);

	CricketData CricketData => null;

	FullPoisonEffects PoisonEffects => null;

	ItemDisplayData.ItemUnavailableType UnavailableType => ItemDisplayData.ItemUnavailableType.Valid;

	int MedicineEffectValue => 0;

	bool IsLocked => false;

	bool IsInCurrentCricketPreset => false;

	bool IsSpecialInteract => false;

	int AlertFactor => 0;

	bool ForceNotTransferable => false;

	ItemKey StackKey
	{
		get
		{
			if (!PoisonIsIdentified)
			{
				return GetStackKey();
			}
			return RealKey;
		}
	}

	ITradeableContent Clone(int amount = -1);

	sbyte GetContentType();

	void ChangeAmount(Inventory inventory, bool isAdd)
	{
	}

	void ChangeAmount(ItemKey itemKey, bool isAdd)
	{
	}

	bool ContainsItemKey(ItemKey key)
	{
		return false;
	}

	Inventory GetAllInventoryFromPool()
	{
		return ItemDisplayData.GetInventoryFromPool();
	}

	Inventory GetOperationInventoryFromPool(int amount, bool preview = false)
	{
		return GetAllInventoryFromPool();
	}

	int Advantage(Exchange exchange)
	{
		return exchange.CalcValueAdvantage(Grade);
	}

	IEnumerable<(ItemKey Key, int Amount)> Take(int amount, bool isPreview = true)
	{
		yield return (Key: Key, Amount: amount);
	}

	ItemKey GetStackKey()
	{
		ItemKey key = RealKey.StackKey;
		if (ExtraGoodsType != 0)
		{
			key.Id = ExtraGoodsType;
		}
		return key;
	}
}
