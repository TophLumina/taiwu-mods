using System;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item;

public struct ItemKey : ISerializableGameData, ITradeableContent, IEquatable<ItemKey>
{
	public static readonly ItemKey Invalid = new ItemKey(-1, byte.MaxValue, -1, -1);

	public sbyte ItemType;

	public byte ModificationState;

	public short TemplateId;

	public int Id;

	public TemplateKey TemplateKey => new TemplateKey(ItemType, TemplateId);

	public bool HasTemplate
	{
		get
		{
			if (TemplateId >= 0)
			{
				return ItemType >= 0;
			}
			return false;
		}
	}

	public ItemKey StackKey
	{
		get
		{
			if (!ItemTemplateHelper.IsStackable(ItemType, TemplateId))
			{
				return this;
			}
			return new ItemKey(ItemType, (byte)(ModificationState & -2), TemplateId, ((byte)(ModificationState & -2) != 0) ? Id : 0);
		}
	}

	bool ITradeableContent.Interactable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	long ITradeableContent.Value
	{
		get
		{
			return ItemTemplateHelper.GetBaseValue(ItemType, TemplateId);
		}
		set
		{
		}
	}

	int ITradeableContent.Amount
	{
		get
		{
			return 1;
		}
		set
		{
		}
	}

	ItemKey ITradeableContent.Key => this;

	ItemKey ITradeableContent.RealKey => this;

	sbyte ITradeableContent.Grade
	{
		get
		{
			if (ItemType != -1)
			{
				return ItemTemplateHelper.GetGrade(ItemType, TemplateId);
			}
			return 0;
		}
	}

	public ItemKey(sbyte itemType, byte modificationState, short templateId, int id)
	{
		ItemType = itemType;
		ModificationState = modificationState;
		TemplateId = templateId;
		Id = id;
	}

	public static explicit operator ulong(ItemKey value)
	{
		return ((ulong)(uint)value.Id << 32) + ((ulong)(ushort)value.TemplateId << 16) + ((ulong)value.ModificationState << 8) + (byte)value.ItemType;
	}

	public static explicit operator ItemKey(ulong value)
	{
		return new ItemKey((sbyte)value, (byte)(value >> 8), (short)(value >> 16), (int)(value >> 32));
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 8;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)ItemType;
		pData[1] = ModificationState;
		((short*)pData)[1] = TemplateId;
		((int*)pData)[1] = Id;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		ItemType = (sbyte)(*pData);
		ModificationState = pData[1];
		TemplateId = ((short*)pData)[1];
		Id = ((int*)pData)[1];
		return 8;
	}

	public bool IsValid()
	{
		return Id >= 0;
	}

	public bool IsPrisoner()
	{
		if (IsValid() && ItemType == 12)
		{
			return TemplateId == 475;
		}
		return false;
	}

	public static bool operator ==(ItemKey lhs, ItemKey rhs)
	{
		return (ulong)lhs == (ulong)rhs;
	}

	public static bool operator !=(ItemKey lhs, ItemKey rhs)
	{
		return (ulong)lhs != (ulong)rhs;
	}

	public bool Equals(ItemKey other)
	{
		if (ItemType == other.ItemType && ModificationState == other.ModificationState && TemplateId == other.TemplateId)
		{
			return Id == other.Id;
		}
		return false;
	}

	public bool TemplateEquals(ItemKey other)
	{
		if (ItemType == other.ItemType)
		{
			return TemplateId == other.TemplateId;
		}
		return false;
	}

	public bool TemplateEquals(sbyte itemType, short templateId)
	{
		if (ItemType == itemType)
		{
			return TemplateId == templateId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is ItemKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((((ItemType.GetHashCode() * 397) ^ ModificationState.GetHashCode()) * 397) ^ TemplateId.GetHashCode()) * 397) ^ Id;
	}

	public override string ToString()
	{
		string typeName = (GameData.Domains.Item.ItemType.TypeId2TypeName.CheckIndex(ItemType) ? GameData.Domains.Item.ItemType.TypeId2TypeName[ItemType] : ItemType.ToString());
		string name = ItemTemplateHelper.GetNameOrDefault(ItemType, TemplateId);
		string state = Convert.ToString(ModificationState, 2);
		if (name == null)
		{
			return $"{{{typeName}, {TemplateId}, {Id}, {state}}}";
		}
		return $"{{{typeName}, {name} ({TemplateId}), {Id}, {state}}}";
	}

	ITradeableContent ITradeableContent.Clone(int _)
	{
		return this;
	}

	sbyte ITradeableContent.GetContentType()
	{
		return 6;
	}
}
