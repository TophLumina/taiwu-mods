using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(IsExtensible = true)]
public class MakeItemData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ProductItemType = 0;

		public const ushort ProductItemIdList = 1;

		public const ushort LeftTime = 2;

		public const ushort MaterialResources = 3;

		public const ushort ToolKey = 4;

		public const ushort MaterialKey = 5;

		public const ushort EquipmentEffectId = 6;

		public const ushort Count = 7;

		public static readonly string[] FieldId2FieldName = new string[7] { "ProductItemType", "ProductItemIdList", "LeftTime", "MaterialResources", "ToolKey", "MaterialKey", "EquipmentEffectId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte ProductItemType;

	[SerializableGameDataField(FieldIndex = 1)]
	public List<short> ProductItemIdList;

	[SerializableGameDataField(FieldIndex = 2)]
	public short LeftTime;

	[SerializableGameDataField(FieldIndex = 3)]
	public MaterialResources MaterialResources;

	[SerializableGameDataField(FieldIndex = 4)]
	public ItemKey ToolKey;

	[SerializableGameDataField(FieldIndex = 5)]
	public ItemKey MaterialKey;

	/// <summary>
	/// 精益求精的目标装备特效
	/// </summary>
	[SerializableGameDataField(FieldIndex = 6)]
	public short EquipmentEffectId = -1;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public MakeItemData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public MakeItemData(MakeItemData other)
	{
		ProductItemType = other.ProductItemType;
		ProductItemIdList = ((other.ProductItemIdList == null) ? null : new List<short>(other.ProductItemIdList));
		LeftTime = other.LeftTime;
		MaterialResources = other.MaterialResources;
		ToolKey = other.ToolKey;
		MaterialKey = other.MaterialKey;
		EquipmentEffectId = other.EquipmentEffectId;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(MakeItemData other)
	{
		ProductItemType = other.ProductItemType;
		ProductItemIdList = ((other.ProductItemIdList == null) ? null : new List<short>(other.ProductItemIdList));
		LeftTime = other.LeftTime;
		MaterialResources = other.MaterialResources;
		ToolKey = other.ToolKey;
		MaterialKey = other.MaterialKey;
		EquipmentEffectId = other.EquipmentEffectId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		totalSize = ((ProductItemIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ProductItemIdList.Count)));
		totalSize += MaterialResources.GetSerializedSize();
		totalSize += ToolKey.GetSerializedSize();
		totalSize += MaterialKey.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 7;
		pCurrData += 2;
		*pCurrData = (byte)ProductItemType;
		pCurrData++;
		if (ProductItemIdList != null)
		{
			int elementsCount = ProductItemIdList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = ProductItemIdList[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = LeftTime;
		pCurrData += 2;
		pCurrData += MaterialResources.Serialize(pCurrData);
		pCurrData += ToolKey.Serialize(pCurrData);
		pCurrData += MaterialKey.Serialize(pCurrData);
		*(short*)pCurrData = EquipmentEffectId;
		pCurrData += 2;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ProductItemType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (ProductItemIdList == null)
				{
					ProductItemIdList = new List<short>();
				}
				else
				{
					ProductItemIdList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					short element = *(short*)pCurrData;
					pCurrData += 2;
					ProductItemIdList.Add(element);
				}
			}
			else
			{
				ProductItemIdList?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			LeftTime = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 3)
		{
			pCurrData += MaterialResources.Deserialize(pCurrData);
		}
		if (fieldCount > 4)
		{
			pCurrData += ToolKey.Deserialize(pCurrData);
		}
		if (fieldCount > 5)
		{
			pCurrData += MaterialKey.Deserialize(pCurrData);
		}
		if (fieldCount > 6)
		{
			EquipmentEffectId = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
