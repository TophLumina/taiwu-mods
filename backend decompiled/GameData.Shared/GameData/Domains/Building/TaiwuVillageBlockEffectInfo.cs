using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class TaiwuVillageBlockEffectInfo : ISerializableGameData
{
	[SerializableGameDataField]
	public List<BuildingBlockData> BlockDataList = new List<BuildingBlockData>();

	[SerializableGameDataField]
	public List<BuildingBlockKey> BlockKeyList = new List<BuildingBlockKey>();

	[SerializableGameDataField]
	public List<int> LevelList = new List<int>();

	[SerializableGameDataField]
	public int BlockRanking;

	[SerializableGameDataField]
	public BuildingFormulaContextBridge FormulaContextBridge;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (BlockDataList != null)
		{
			totalSize += 2;
			for (int i = 0; i < BlockDataList.Count; i++)
			{
				totalSize = ((BlockDataList[i] == null) ? (totalSize + 2) : (totalSize + (2 + BlockDataList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((BlockKeyList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * BlockKeyList.Count)));
		totalSize = ((LevelList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * LevelList.Count)));
		totalSize = ((FormulaContextBridge == null) ? (totalSize + 2) : (totalSize + (2 + FormulaContextBridge.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (BlockDataList != null)
		{
			int elementsCount = BlockDataList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (BlockDataList[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = BlockDataList[i].Serialize(pCurrData);
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
		if (BlockKeyList != null)
		{
			int elementsCount2 = BlockKeyList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += BlockKeyList[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LevelList != null)
		{
			int elementsCount3 = LevelList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				*(int*)pCurrData = LevelList[k];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = BlockRanking;
		pCurrData += 4;
		if (FormulaContextBridge != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = FormulaContextBridge.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
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
			if (BlockDataList == null)
			{
				BlockDataList = new List<BuildingBlockData>();
			}
			else
			{
				BlockDataList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				BuildingBlockData element;
				if (num > 0)
				{
					element = new BuildingBlockData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				BlockDataList.Add(element);
			}
		}
		else
		{
			BlockDataList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (BlockKeyList == null)
			{
				BlockKeyList = new List<BuildingBlockKey>();
			}
			else
			{
				BlockKeyList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				BuildingBlockKey element2 = default(BuildingBlockKey);
				pCurrData += element2.Deserialize(pCurrData);
				BlockKeyList.Add(element2);
			}
		}
		else
		{
			BlockKeyList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (LevelList == null)
			{
				LevelList = new List<int>();
			}
			else
			{
				LevelList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				int element3 = *(int*)pCurrData;
				pCurrData += 4;
				LevelList.Add(element3);
			}
		}
		else
		{
			LevelList?.Clear();
		}
		BlockRanking = *(int*)pCurrData;
		pCurrData += 4;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			FormulaContextBridge = new BuildingFormulaContextBridge();
			pCurrData += FormulaContextBridge.Deserialize(pCurrData);
		}
		else
		{
			FormulaContextBridge = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
