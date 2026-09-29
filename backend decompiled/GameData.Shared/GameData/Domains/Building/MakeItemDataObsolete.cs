using System;
using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

[Obsolete]
public class MakeItemDataObsolete : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte ProductItemType;

	[SerializableGameDataField]
	public List<short> ProductItemIdList;

	[SerializableGameDataField]
	public short LeftTime;

	[SerializableGameDataField]
	public MaterialResources MaterialResources;

	[SerializableGameDataField]
	public ItemKey ToolKey;

	[SerializableGameDataField]
	public ItemKey MaterialKey;

	[SerializableGameDataField]
	public bool IsPerfect;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 32;
		totalSize = ((ProductItemIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ProductItemIdList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
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
				((short*)pCurrData)[i] = ProductItemIdList[i];
			}
			pCurrData += 2 * elementsCount;
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
		*pCurrData = (IsPerfect ? ((byte)1) : ((byte)0));
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
		ProductItemType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ProductItemIdList == null)
			{
				ProductItemIdList = new List<short>(elementsCount);
			}
			else
			{
				ProductItemIdList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ProductItemIdList.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			ProductItemIdList?.Clear();
		}
		LeftTime = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += MaterialResources.Deserialize(pCurrData);
		pCurrData += ToolKey.Deserialize(pCurrData);
		pCurrData += MaterialKey.Deserialize(pCurrData);
		IsPerfect = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
