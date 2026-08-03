using System.Collections.Generic;
using GameData.DLC.CricketPolymorph;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class CricketCollectionDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<ItemDisplayData> Items;

	[SerializableGameDataField]
	public bool IsInVillage;

	[SerializableGameDataField]
	public ItemDisplayData[] CollectionJars;

	[SerializableGameDataField]
	public ItemDisplayData[] CollectionCrickets;

	[SerializableGameDataField]
	public int[] CollectionCricketRegen;

	[SerializableGameDataField]
	public int AuthorityGain;

	[SerializableGameDataField]
	public CricketCollectionBatchButtonStateDisplayData BatchModeButtonStateData;

	[SerializableGameDataField]
	public Dictionary<int, bool> AliveCrickets;

	[SerializableGameDataField]
	public CricketRoomData CricketRoomData;

	[SerializableGameDataField]
	public int CricketLuckPoint;

	[SerializableGameDataField]
	public List<ItemDisplayData> MaterialItems;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (Items != null)
		{
			totalSize += 2;
			for (int i = 0; i < Items.Count; i++)
			{
				totalSize = ((Items[i] == null) ? (totalSize + 2) : (totalSize + (2 + Items[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (CollectionJars != null)
		{
			totalSize += 2;
			for (int j = 0; j < CollectionJars.Length; j++)
			{
				totalSize = ((CollectionJars[j] == null) ? (totalSize + 2) : (totalSize + (2 + CollectionJars[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (CollectionCrickets != null)
		{
			totalSize += 2;
			for (int k = 0; k < CollectionCrickets.Length; k++)
			{
				totalSize = ((CollectionCrickets[k] == null) ? (totalSize + 2) : (totalSize + (2 + CollectionCrickets[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((CollectionCricketRegen == null) ? (totalSize + 2) : (totalSize + (2 + 4 * CollectionCricketRegen.Length)));
		totalSize = ((BatchModeButtonStateData == null) ? (totalSize + 2) : (totalSize + (2 + BatchModeButtonStateData.GetSerializedSize())));
		totalSize += 4;
		if (AliveCrickets != null)
		{
			foreach (KeyValuePair<int, bool> aliveCricket in AliveCrickets)
			{
				_ = aliveCricket;
				totalSize += 4;
				totalSize++;
			}
		}
		totalSize = ((CricketRoomData == null) ? (totalSize + 2) : (totalSize + (2 + CricketRoomData.GetSerializedSize())));
		if (MaterialItems != null)
		{
			totalSize += 2;
			for (int l = 0; l < MaterialItems.Count; l++)
			{
				totalSize = ((MaterialItems[l] == null) ? (totalSize + 2) : (totalSize + (2 + MaterialItems[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Items != null)
		{
			int elementsCount = Items.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (Items[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = Items[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsInVillage ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (CollectionJars != null)
		{
			int elementsCount2 = CollectionJars.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (CollectionJars[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = CollectionJars[j].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize2;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CollectionCrickets != null)
		{
			int elementsCount3 = CollectionCrickets.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (CollectionCrickets[k] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = CollectionCrickets[k].Serialize(pCurrData);
					pCurrData += fieldSize3;
					Tester.Assert(fieldSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)fieldSize3;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CollectionCricketRegen != null)
		{
			int elementsCount4 = CollectionCricketRegen.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				*(int*)pCurrData = CollectionCricketRegen[l];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = AuthorityGain;
		pCurrData += 4;
		pCurrData += BatchModeButtonStateData.Serialize(pCurrData);
		if (AliveCrickets != null)
		{
			*(int*)pCurrData = AliveCrickets.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, bool> pair in AliveCrickets)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				*pCurrData = (pair.Value ? ((byte)1) : ((byte)0));
				pCurrData++;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (CricketRoomData != null)
		{
			byte* intPtr4 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = CricketRoomData.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr4 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = CricketLuckPoint;
		pCurrData += 4;
		if (MaterialItems != null)
		{
			int elementsCount5 = MaterialItems.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				if (MaterialItems[m] != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 2;
					int fieldSize5 = MaterialItems[m].Serialize(pCurrData);
					pCurrData += fieldSize5;
					Tester.Assert(fieldSize5 <= 65535);
					*(ushort*)intPtr5 = (ushort)fieldSize5;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
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
			if (Items == null)
			{
				Items = new List<ItemDisplayData>();
			}
			else
			{
				Items.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element;
				if (num > 0)
				{
					element = new ItemDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				Items.Add(element);
			}
		}
		else
		{
			Items?.Clear();
		}
		IsInVillage = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CollectionJars == null || CollectionJars.Length != elementsCount2)
			{
				CollectionJars = new ItemDisplayData[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num2 > 0)
				{
					CollectionJars[j] = new ItemDisplayData();
					pCurrData += CollectionJars[j].Deserialize(pCurrData);
				}
				else
				{
					CollectionJars[j] = null;
				}
			}
		}
		else
		{
			CollectionJars = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (CollectionCrickets == null || CollectionCrickets.Length != elementsCount3)
			{
				CollectionCrickets = new ItemDisplayData[elementsCount3];
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num3 > 0)
				{
					CollectionCrickets[k] = new ItemDisplayData();
					pCurrData += CollectionCrickets[k].Deserialize(pCurrData);
				}
				else
				{
					CollectionCrickets[k] = null;
				}
			}
		}
		else
		{
			CollectionCrickets = null;
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (CollectionCricketRegen == null || CollectionCricketRegen.Length != elementsCount4)
			{
				CollectionCricketRegen = new int[elementsCount4];
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				CollectionCricketRegen[l] = *(int*)pCurrData;
				pCurrData += 4;
			}
		}
		else
		{
			CollectionCricketRegen = null;
		}
		AuthorityGain = *(int*)pCurrData;
		pCurrData += 4;
		BatchModeButtonStateData = new CricketCollectionBatchButtonStateDisplayData();
		pCurrData += BatchModeButtonStateData.Deserialize(pCurrData);
		int AliveCricketsElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (AliveCricketsElementsCount > 0)
		{
			if (AliveCrickets == null)
			{
				AliveCrickets = new Dictionary<int, bool>();
			}
			else
			{
				AliveCrickets.Clear();
			}
			for (int m = 0; m < AliveCricketsElementsCount; m++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				bool value = *pCurrData != 0;
				pCurrData++;
				AliveCrickets.Add(key, value);
			}
		}
		else
		{
			AliveCrickets?.Clear();
		}
		ushort num4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num4 > 0)
		{
			CricketRoomData = new CricketRoomData();
			pCurrData += CricketRoomData.Deserialize(pCurrData);
		}
		else
		{
			CricketRoomData = null;
		}
		CricketLuckPoint = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (MaterialItems == null)
			{
				MaterialItems = new List<ItemDisplayData>();
			}
			else
			{
				MaterialItems.Clear();
			}
			for (int n = 0; n < elementsCount5; n++)
			{
				ushort num5 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element2;
				if (num5 > 0)
				{
					element2 = new ItemDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				MaterialItems.Add(element2);
			}
		}
		else
		{
			MaterialItems?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
