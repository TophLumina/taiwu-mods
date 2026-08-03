using System;
using GameData.Serializer;

namespace GameData.Domains.Item;

/// <summary>
/// 物品模板的索引
/// </summary>
[Serializable]
public struct TemplateKey : ISerializableGameData, IEquatable<TemplateKey>
{
	/// <summary>
	/// 无效模板
	/// </summary>
	public static readonly TemplateKey Invalid;

	/// <summary>
	/// 物品类型. <see cref="T:GameData.Domains.Item.ItemType" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte ItemType;

	/// <summary>
	/// 物品模板 ID
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 物品模板的索引
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	public TemplateKey(sbyte itemType, short templateId)
	{
		ItemType = itemType;
		TemplateId = templateId;
	}

	/// <summary>
	/// 用于配置的构造
	/// </summary>
	public TemplateKey(string typeName, short templateId)
	{
		ItemType = GameData.Domains.Item.ItemType.TypeName2TypeId[typeName];
		TemplateId = templateId;
	}

	/// <summary>
	/// 是否有效
	/// </summary>
	/// <returns></returns>
	public bool IsValid()
	{
		if (ItemType >= 0)
		{
			return TemplateId >= 0;
		}
		return false;
	}

	public void Deconstruct(out sbyte itemType, out short templateId)
	{
		itemType = ItemType;
		templateId = TemplateId;
	}

	public static explicit operator uint(TemplateKey value)
	{
		return (uint)(((ushort)value.TemplateId << 16) + (byte)value.ItemType);
	}

	public static explicit operator TemplateKey(uint value)
	{
		return new TemplateKey((sbyte)value, (short)(value >> 16));
	}

	public bool Equals(TemplateKey other)
	{
		if (ItemType == other.ItemType)
		{
			return TemplateId == other.TemplateId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is TemplateKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (ItemType.GetHashCode() * 397) ^ TemplateId.GetHashCode();
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)ItemType;
		byte* num = pData + 1;
		*(short*)num = TemplateId;
		int totalSize = (int)(num + 2 - pData);
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
		ItemType = (sbyte)(*pCurrData);
		pCurrData++;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	static TemplateKey()
	{
		Invalid = new TemplateKey(-1, -1);
	}
}
