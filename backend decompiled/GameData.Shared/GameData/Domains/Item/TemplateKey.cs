using System;
using GameData.Serializer;

namespace GameData.Domains.Item;

[Serializable]
public struct TemplateKey : ISerializableGameData, IEquatable<TemplateKey>
{
	public static readonly TemplateKey Invalid;

	[SerializableGameDataField]
	public sbyte ItemType;

	[SerializableGameDataField]
	public short TemplateId;

	public TemplateKey(sbyte itemType, short templateId)
	{
		ItemType = itemType;
		TemplateId = templateId;
	}

	public TemplateKey(string typeName, short templateId)
	{
		ItemType = GameData.Domains.Item.ItemType.TypeName2TypeId[typeName];
		TemplateId = templateId;
	}

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

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
