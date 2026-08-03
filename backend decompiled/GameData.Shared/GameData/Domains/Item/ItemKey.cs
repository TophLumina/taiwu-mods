using System;
using GameData.Domains.Item.Display;
using GameData.Serializer;

namespace GameData.Domains.Item;

/// <summary>
/// 物品的索引
/// </summary>
public struct ItemKey : ISerializableGameData, ITradeableContent, IEquatable<ItemKey>
{
	/// <summary>
	/// 无效的物品 Key
	/// </summary>
	public static readonly ItemKey Invalid = new ItemKey(-1, byte.MaxValue, -1, -1);

	/// <summary>
	/// 物品类型. <see cref="T:GameData.Domains.Item.ItemType" />
	/// </summary>
	public sbyte ItemType;

	/// <summary>
	/// 变动状态.
	/// 每个比特表示一种变动状态, 如被淬毒, 被精制等.
	/// </summary>
	public byte ModificationState;

	/// <summary>
	/// 物品模板 ID
	/// </summary>
	public short TemplateId;

	/// <summary>
	/// 物品实例 ID
	/// </summary>
	public int Id;

	/// <summary>
	/// 获取道具模板键
	/// </summary>
	public TemplateKey TemplateKey => new TemplateKey(ItemType, TemplateId);

	/// <summary>
	/// 检查物品是否有模板
	/// </summary>
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

	/// <summary>
	/// 物品的索引
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="modificationState"></param>
	/// <param name="templateId"></param>
	/// <param name="id"></param>
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

	/// <summary>
	/// 检查物品索引是否有效
	/// </summary>
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

	/// <summary>
	/// 检查物品模板是否一样
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public bool TemplateEquals(ItemKey other)
	{
		if (ItemType == other.ItemType)
		{
			return TemplateId == other.TemplateId;
		}
		return false;
	}

	/// <summary>
	/// 检查物品模板是否一样
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
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
		string typeName = ((ItemType >= 0) ? GameData.Domains.Item.ItemType.TypeId2TypeName[ItemType] : ItemType.ToString());
		string name = ((ItemType >= 0 && TemplateId >= 0) ? ItemTemplateHelper.GetName(ItemType, TemplateId) : null);
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
