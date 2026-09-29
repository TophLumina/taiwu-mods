using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

public class BuildingEarningsData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<ItemKey> CollectionItemList;

	[SerializableGameDataField]
	public List<IntPair> CollectionResourceList;

	[SerializableGameDataField]
	public List<ItemKey> ShopSoldItemList;

	[SerializableGameDataField]
	public List<IntPair> ShopSoldItemEarnList;

	[SerializableGameDataField]
	public List<IntPair> RecruitLevelList;

	[SerializableGameDataField]
	public List<ItemKey> FixBookInfoList;

	public BuildingEarningsData()
	{
		CollectionItemList = new List<ItemKey>();
		CollectionResourceList = new List<IntPair>();
		ShopSoldItemList = new List<ItemKey>();
		ShopSoldItemEarnList = new List<IntPair>();
		RecruitLevelList = new List<IntPair>();
		FixBookInfoList = new List<ItemKey>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((CollectionItemList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * CollectionItemList.Count)));
		totalSize = ((CollectionResourceList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * CollectionResourceList.Count)));
		totalSize = ((ShopSoldItemList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * ShopSoldItemList.Count)));
		totalSize = ((ShopSoldItemEarnList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * ShopSoldItemEarnList.Count)));
		totalSize = ((RecruitLevelList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * RecruitLevelList.Count)));
		totalSize = ((FixBookInfoList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * FixBookInfoList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CollectionItemList != null)
		{
			int elementsCount = CollectionItemList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += CollectionItemList[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CollectionResourceList != null)
		{
			int elementsCount2 = CollectionResourceList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += CollectionResourceList[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ShopSoldItemList != null)
		{
			int elementsCount3 = ShopSoldItemList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData += ShopSoldItemList[k].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ShopSoldItemEarnList != null)
		{
			int elementsCount4 = ShopSoldItemEarnList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData += ShopSoldItemEarnList[l].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RecruitLevelList != null)
		{
			int elementsCount5 = RecruitLevelList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				pCurrData += RecruitLevelList[m].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FixBookInfoList != null)
		{
			int elementsCount6 = FixBookInfoList.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				pCurrData += FixBookInfoList[n].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CollectionItemList == null)
			{
				CollectionItemList = new List<ItemKey>(elementsCount);
			}
			else
			{
				CollectionItemList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ItemKey element = default(ItemKey);
				pCurrData += element.Deserialize(pCurrData);
				CollectionItemList.Add(element);
			}
		}
		else
		{
			CollectionItemList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CollectionResourceList == null)
			{
				CollectionResourceList = new List<IntPair>(elementsCount2);
			}
			else
			{
				CollectionResourceList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				IntPair element2 = default(IntPair);
				pCurrData += element2.Deserialize(pCurrData);
				CollectionResourceList.Add(element2);
			}
		}
		else
		{
			CollectionResourceList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (ShopSoldItemList == null)
			{
				ShopSoldItemList = new List<ItemKey>(elementsCount3);
			}
			else
			{
				ShopSoldItemList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ItemKey element3 = default(ItemKey);
				pCurrData += element3.Deserialize(pCurrData);
				ShopSoldItemList.Add(element3);
			}
		}
		else
		{
			ShopSoldItemList?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (ShopSoldItemEarnList == null)
			{
				ShopSoldItemEarnList = new List<IntPair>(elementsCount4);
			}
			else
			{
				ShopSoldItemEarnList.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				IntPair element4 = default(IntPair);
				pCurrData += element4.Deserialize(pCurrData);
				ShopSoldItemEarnList.Add(element4);
			}
		}
		else
		{
			ShopSoldItemEarnList?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (RecruitLevelList == null)
			{
				RecruitLevelList = new List<IntPair>(elementsCount5);
			}
			else
			{
				RecruitLevelList.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				IntPair element5 = default(IntPair);
				pCurrData += element5.Deserialize(pCurrData);
				RecruitLevelList.Add(element5);
			}
		}
		else
		{
			RecruitLevelList?.Clear();
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (FixBookInfoList == null)
			{
				FixBookInfoList = new List<ItemKey>(elementsCount6);
			}
			else
			{
				FixBookInfoList.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				ItemKey element6 = default(ItemKey);
				pCurrData += element6.Deserialize(pCurrData);
				FixBookInfoList.Add(element6);
			}
		}
		else
		{
			FixBookInfoList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
