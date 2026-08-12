using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

/// <summary>
/// 挖掘道具结果
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct TreasureFindResult : ISerializableGameData
{
	/// <summary>
	/// 请求无效
	/// </summary>
	[SerializableGameDataField]
	public bool RequestInvalid;

	/// <summary>
	/// 挖掘地点
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 物品索引
	/// </summary>
	[SerializableGameDataField]
	public ItemKeyAndDate ItemKeyAndDate;

	/// <summary>
	/// 物品数量
	/// </summary>
	[SerializableGameDataField]
	public uint ItemCount;

	/// <summary>
	/// 心材模板 ID 
	/// </summary>
	[SerializableGameDataField]
	public short MaterialTemplateId;

	/// <summary>
	/// 挖掘心材失败时获得的资源类型
	/// <see cref="T:GameData.Domains.Character.ResourceType" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte ResourceType;

	/// <summary>
	/// 挖掘心材失败时获得的资源数量
	/// </summary>
	[SerializableGameDataField]
	public int ResourceCount;

	/// <summary>
	/// 额外物品
	/// </summary>
	[SerializableGameDataField]
	public List<ItemKey> ExtraItems;

	/// <summary>
	/// 额外物品类型
	/// </summary>
	[SerializableGameDataField]
	private int _extraItemTypeInternal;

	/// <summary>
	/// 无效结果
	/// </summary>
	public static TreasureFindResult Invalid
	{
		get
		{
			TreasureFindResult result = new TreasureFindResult();
			result.RequestInvalid = true;
			return result;
		}
	}

	/// <summary>
	/// 挖到的物品索引
	/// </summary>
	public ItemKey ItemKey => ItemKeyAndDate.ItemKey;

	/// <summary>
	/// 挖掘到任意物品
	/// </summary>
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

	/// <summary>
	/// 挖掘到任意心材
	/// </summary>
	public bool AnyMaterial => MaterialTemplateId >= 0;

	/// <summary>
	/// 挖掘到任意资源
	/// </summary>
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

	/// <summary>
	/// 挖掘到额外物品
	/// </summary>
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

	/// <summary>
	/// 额外物品类型
	/// </summary>
	public ETreasureExtraItemType ExtraItemType => (ETreasureExtraItemType)_extraItemTypeInternal;

	/// <summary>
	/// 成功挖掘到物品
	/// </summary>
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

	/// <summary>
	/// 默认构造方法，将数量与结构都设为无效值
	/// </summary>
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

	/// <summary>
	/// 设置额外物品类型
	/// </summary>
	public void SetExtraItemType(ETreasureExtraItemType extraItemType)
	{
		_extraItemTypeInternal = (int)extraItemType;
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
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

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
