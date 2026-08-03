using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Item;

public abstract class ItemBase : BaseGameDataObject, IItemData
{
	[CollectionObjectField(false, true, false, true, false)]
	protected int Id;

	[CollectionObjectField(true, true, false, true, false)]
	protected short TemplateId;

	[CollectionObjectField(true, true, false, false, false)]
	protected short MaxDurability;

	[CollectionObjectField(false, true, false, false, false)]
	protected short CurrDurability;

	[CollectionObjectField(false, true, false, false, false)]
	protected byte ModificationState;

	private ItemOwnerKey _owner = ItemOwnerKey.None;

	private ItemOwnerKey _prevOwner = ItemOwnerKey.None;

	public TemplateKey TemplateKey => new TemplateKey(GetItemType(), TemplateId);

	ItemKey IItemData.Key => GetItemKey();

	int IItemData.Value => GetValue();

	short IItemData.Durability => GetCurrDurability();

	short IItemData.MaxDurability => GetMaxDurability();

	public ItemOwnerKey Owner => _owner;

	public ItemOwnerKey PrevOwner => _prevOwner;

	[CollectionObjectField(true, false, false, false, false)]
	public abstract string GetName();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract sbyte GetItemType();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract short GetItemSubType();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract sbyte GetGrade();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract string GetIcon();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract string GetDesc();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract bool GetTransferable();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract bool GetStackable();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract bool GetWagerable();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract bool GetRefinable();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract bool GetPoisonable();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract bool GetRepairable();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract int GetBaseWeight();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract int GetBaseValue();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract sbyte GetBaseHappinessChange();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract int GetBaseFavorabilityChange();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract sbyte GetDropRate();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract sbyte GetResourceType();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract short GetPreservationDuration();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract List<int> GetTaskLock();

	public virtual bool ChangeCurrDurability(DataContext context, int delta)
	{
		if (MaxDurability <= 0)
		{
			return false;
		}
		short currDurability = (short)Math.Clamp(CurrDurability + delta, 0, MaxDurability);
		if (currDurability == CurrDurability)
		{
			return false;
		}
		SetCurrDurability(currDurability, context);
		return true;
	}

	public abstract int GetCharacterPropertyBonus(ECharacterPropertyReferencedType type);

	public virtual int GetWeight()
	{
		return GetBaseWeight();
	}

	public virtual int GetValue()
	{
		int baseValue = GetBaseValue();
		return ApplyDurabilityEffect(baseValue);
	}

	public virtual int GetFavorabilityChange()
	{
		int baseValue = GetBaseFavorabilityChange();
		return ApplyDurabilityEffect(baseValue);
	}

	public virtual sbyte GetHappinessChange()
	{
		sbyte baseValue = GetBaseHappinessChange();
		return (sbyte)ApplyDurabilityEffect(baseValue);
	}

	public void OfflineSetId(int id)
	{
		Id = id;
	}

	public ItemKey GetItemKey()
	{
		return new ItemKey(GetItemType(), ModificationState, TemplateId, Id);
	}

	public static short GenerateMaxDurability(IRandomSource random, short value)
	{
		if (1 == 0)
		{
		}
		short result = ((value > 0) ? ((short)Math.Max(random.Next(value / 2, value + 1), 1)) : ((value >= 0) ? value : ((short)(-value))));
		if (1 == 0)
		{
		}
		return result;
	}

	protected int ApplyDurabilityEffect(int value)
	{
		return value * ItemFormula.FormulaCalcDurabilityEffect(CurrDurability, MaxDurability);
	}

	public static void OfflineRepairItem(CraftTool craftTool, ItemBase targetItem, short targetDurability, short durabilityCost)
	{
		Tester.Assert(targetItem.GetRepairable());
		Tester.Assert(targetItem.CurrDurability < targetItem.MaxDurability && targetItem.CurrDurability < targetDurability);
		Tester.Assert(targetDurability <= targetItem.MaxDurability);
		Tester.Assert(craftTool.CurrDurability >= durabilityCost);
		craftTool.CurrDurability -= durabilityCost;
		targetItem.CurrDurability = targetDurability;
	}

	public bool IsDurabilityRunningOut()
	{
		return GetMaxDurability() != 0 && GetCurrDurability() <= 0;
	}

	public void ResetOwner()
	{
		_prevOwner = _owner;
		_owner = ItemOwnerKey.None;
	}

	public void RemoveOwner(ItemOwnerType ownerType, int ownerId)
	{
		if (ItemDomain.IsPureStackable(this))
		{
			return;
		}
		if (_owner.OwnerType != ownerType || _owner.OwnerId != ownerId)
		{
			string itemKeyStr = GetItemKey().ToString();
			PredefinedLog.Show(21, itemKeyStr, new ItemOwnerKey(ownerType, ownerId).ToString());
			if (_owner.OwnerType != ItemOwnerType.None)
			{
				AdaptableLog.Warning($"{itemKeyStr} actual owner: {_owner}");
			}
		}
		_prevOwner = _owner;
		_owner = ItemOwnerKey.None;
	}

	public void SetOwner(ItemOwnerType ownerType, int ownerId)
	{
		ItemOwnerKey newOwner = new ItemOwnerKey
		{
			OwnerType = ownerType,
			OwnerId = ownerId
		};
		if (_owner.OwnerType != ItemOwnerType.None && _owner.OwnerType != ownerType && _owner.OwnerId != ownerId)
		{
			string itemKeyStr = GetItemKey().ToString();
			PredefinedLog.Show(20, itemKeyStr, newOwner.ToString(), _owner.ToString());
			if (_prevOwner.OwnerType != ItemOwnerType.None)
			{
				AdaptableLog.Warning($"{itemKeyStr} previous owner: {_prevOwner}");
			}
			_prevOwner = _owner;
		}
		else if (_owner.OwnerType != ItemOwnerType.None && (_owner.OwnerType != ownerType || _owner.OwnerId != ownerId))
		{
			string itemKeyStr2 = GetItemKey().ToString();
			AdaptableLog.Warning($"DuplicatedItemDetected {itemKeyStr2} {newOwner.ToString()} {_owner.ToString()}");
			if (_prevOwner.OwnerType != ItemOwnerType.None)
			{
				AdaptableLog.Warning($"{itemKeyStr2} previous owner: {_prevOwner}");
			}
			_prevOwner = _owner;
		}
		if (!ItemDomain.IsPureStackable(this))
		{
			_owner = newOwner;
		}
	}

	public int GetId()
	{
		return Id;
	}

	public short GetTemplateId()
	{
		return TemplateId;
	}

	public short GetMaxDurability()
	{
		return MaxDurability;
	}

	public abstract void SetMaxDurability(short maxDurability, DataContext context);

	public short GetCurrDurability()
	{
		return CurrDurability;
	}

	public abstract void SetCurrDurability(short currDurability, DataContext context);

	public byte GetModificationState()
	{
		return ModificationState;
	}

	public abstract void SetModificationState(byte modificationState, DataContext context);
}
