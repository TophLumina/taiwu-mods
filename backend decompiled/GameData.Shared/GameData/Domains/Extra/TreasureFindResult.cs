using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

[SerializableGameData(NotForArchive = true)]
public struct TreasureFindResult : ISerializableGameData
{
	[SerializableGameDataField]
	public bool RequestInvalid;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public ItemKeyAndDate ItemKeyAndDate;

	[SerializableGameDataField]
	public uint ItemCount;

	[SerializableGameDataField]
	public short MaterialTemplateId;

	[SerializableGameDataField]
	public sbyte ResourceType;

	[SerializableGameDataField]
	public int ResourceCount;

	[SerializableGameDataField]
	public List<ItemKey> ExtraItems;

	[SerializableGameDataField]
	private int _extraItemTypeInternal;

	public static TreasureFindResult Invalid
	{
		get
		{
			TreasureFindResult result = new TreasureFindResult();
			result.RequestInvalid = true;
			return result;
		}
	}

	public ItemKey ItemKey => ItemKeyAndDate.ItemKey;

	public bool AnyItem
	{
		get
		{
			if (ItemKey.IsValid())
			{
				return ItemCount != 0;
			}
			return false;
		}
	}

	public bool AnyMaterial => MaterialTemplateId >= 0;

	public bool AnyResource
	{
		get
		{
			if (ResourceType != -1)
			{
				return ResourceCount > 0;
			}
			return false;
		}
	}

	public bool AnyExtraItem
	{
		get
		{
			if (ExtraItems != null)
			{
				return ExtraItems.Count > 0;
			}
			return false;
		}
	}

	public ETreasureExtraItemType ExtraItemType => (ETreasureExtraItemType)_extraItemTypeInternal;

	public bool Success
	{
		get
		{
			if (!AnyItem && !AnyMaterial)
			{
				return AnyExtraItem;
			}
			return true;
		}
	}

	public TreasureFindResult()
	{
		RequestInvalid = false;
		Location = Location.Invalid;
		ItemKeyAndDate = new ItemKeyAndDate(-1, ItemKey.Invalid);
		ItemCount = 0u;
		MaterialTemplateId = -1;
		ResourceType = -1;
		ResourceCount = 0;
		ExtraItems = null;
		_extraItemTypeInternal = 0;
	}

	public void SetExtraItemType(ETreasureExtraItemType extraItemType)
	{
		_extraItemTypeInternal = (int)extraItemType;
	}

	public TreasureFindResult(TreasureFindResult other)
	{
		RequestInvalid = other.RequestInvalid;
		Location = other.Location;
		ItemKeyAndDate = other.ItemKeyAndDate;
		ItemCount = other.ItemCount;
		MaterialTemplateId = other.MaterialTemplateId;
		ResourceType = other.ResourceType;
		ResourceCount = other.ResourceCount;
		ExtraItems = ((other.ExtraItems == null) ? null : new List<ItemKey>(other.ExtraItems));
		_extraItemTypeInternal = other._extraItemTypeInternal;
	}

	public void Assign(TreasureFindResult other)
	{
		RequestInvalid = other.RequestInvalid;
		Location = other.Location;
		ItemKeyAndDate = other.ItemKeyAndDate;
		ItemCount = other.ItemCount;
		MaterialTemplateId = other.MaterialTemplateId;
		ResourceType = other.ResourceType;
		ResourceCount = other.ResourceCount;
		ExtraItems = ((other.ExtraItems == null) ? null : new List<ItemKey>(other.ExtraItems));
		_extraItemTypeInternal = other._extraItemTypeInternal;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 32;
		totalSize = ((ExtraItems == null) ? (totalSize + 2) : (totalSize + (2 + 8 * ExtraItems.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (RequestInvalid ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += Location.Serialize(pCurrData);
		pCurrData += ItemKeyAndDate.Serialize(pCurrData);
		*(uint*)pCurrData = ItemCount;
		pCurrData += 4;
		*(short*)pCurrData = MaterialTemplateId;
		pCurrData += 2;
		*pCurrData = (byte)ResourceType;
		pCurrData++;
		*(int*)pCurrData = ResourceCount;
		pCurrData += 4;
		if (ExtraItems != null)
		{
			int elementsCount = ExtraItems.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += ExtraItems[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = _extraItemTypeInternal;
		pCurrData += 4;
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
		RequestInvalid = *pCurrData != 0;
		pCurrData++;
		pCurrData += Location.Deserialize(pCurrData);
		pCurrData += ItemKeyAndDate.Deserialize(pCurrData);
		ItemCount = *(uint*)pCurrData;
		pCurrData += 4;
		MaterialTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ResourceType = (sbyte)(*pCurrData);
		pCurrData++;
		ResourceCount = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ExtraItems == null)
			{
				ExtraItems = new List<ItemKey>(elementsCount);
			}
			else
			{
				ExtraItems.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ItemKey element = default(ItemKey);
				pCurrData += element.Deserialize(pCurrData);
				ExtraItems.Add(element);
			}
		}
		else
		{
			ExtraItems?.Clear();
		}
		_extraItemTypeInternal = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
