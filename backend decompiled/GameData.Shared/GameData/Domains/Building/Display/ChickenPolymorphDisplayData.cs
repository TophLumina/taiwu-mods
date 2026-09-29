using System.Collections.Generic;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building.Display;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class ChickenPolymorphDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<Chicken> Chickens;

	[SerializableGameDataField]
	public List<string> ChickenNickNames;

	[SerializableGameDataField]
	public List<ChickenPolymorphInfoData> PolymorphInfos;

	[SerializableGameDataField]
	public Dictionary<int, ChickenPolymorphLocationData> ChickenLocations;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((Chickens == null) ? (totalSize + 2) : (totalSize + (2 + 12 * Chickens.Count)));
		if (ChickenNickNames != null)
		{
			totalSize += 2;
			for (int i = 0; i < ChickenNickNames.Count; i++)
			{
				totalSize = ((ChickenNickNames[i] == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ChickenNickNames[i].Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (PolymorphInfos != null)
		{
			totalSize += 2;
			for (int j = 0; j < PolymorphInfos.Count; j++)
			{
				totalSize = ((PolymorphInfos[j] == null) ? (totalSize + 2) : (totalSize + (2 + PolymorphInfos[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += 4;
		if (ChickenLocations != null)
		{
			foreach (KeyValuePair<int, ChickenPolymorphLocationData> pair in ChickenLocations)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
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
		if (Chickens != null)
		{
			int elementsCount = Chickens.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Chickens[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ChickenNickNames != null)
		{
			int elementsCount2 = ChickenNickNames.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (ChickenNickNames[j] != null)
				{
					int stringCount = ChickenNickNames[j].Length;
					Tester.Assert(stringCount <= 65535);
					*(ushort*)pCurrData = (ushort)stringCount;
					pCurrData += 2;
					fixed (char* pChar = ChickenNickNames[j])
					{
						for (int stringIndex = 0; stringIndex < stringCount; stringIndex++)
						{
							((short*)pCurrData)[stringIndex] = (short)pChar[stringIndex];
						}
					}
					pCurrData += 2 * stringCount;
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
		if (PolymorphInfos != null)
		{
			int elementsCount3 = PolymorphInfos.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (PolymorphInfos[k] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = PolymorphInfos[k].Serialize(pCurrData);
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
		if (ChickenLocations != null)
		{
			*(int*)pCurrData = ChickenLocations.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, ChickenPolymorphLocationData> pair in ChickenLocations)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
			if (Chickens == null)
			{
				Chickens = new List<Chicken>();
			}
			else
			{
				Chickens.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				Chicken element = default(Chicken);
				pCurrData += element.Deserialize(pCurrData);
				Chickens.Add(element);
			}
		}
		else
		{
			Chickens?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (ChickenNickNames == null)
			{
				ChickenNickNames = new List<string>();
			}
			else
			{
				ChickenNickNames.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort stringCount = *(ushort*)pCurrData;
				pCurrData += 2;
				string element2;
				if (stringCount > 0)
				{
					int fieldSize = 2 * stringCount;
					element2 = Encoding.Unicode.GetString(pCurrData, fieldSize);
					pCurrData += fieldSize;
				}
				else
				{
					element2 = null;
				}
				ChickenNickNames.Add(element2);
			}
		}
		else
		{
			ChickenNickNames?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (PolymorphInfos == null)
			{
				PolymorphInfos = new List<ChickenPolymorphInfoData>();
			}
			else
			{
				PolymorphInfos.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				ChickenPolymorphInfoData element3;
				if (num > 0)
				{
					element3 = new ChickenPolymorphInfoData();
					pCurrData += element3.Deserialize(pCurrData);
				}
				else
				{
					element3 = null;
				}
				PolymorphInfos.Add(element3);
			}
		}
		else
		{
			PolymorphInfos?.Clear();
		}
		int ChickenLocationsElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (ChickenLocationsElementsCount > 0)
		{
			if (ChickenLocations == null)
			{
				ChickenLocations = new Dictionary<int, ChickenPolymorphLocationData>();
			}
			else
			{
				ChickenLocations.Clear();
			}
			for (int l = 0; l < ChickenLocationsElementsCount; l++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				ChickenPolymorphLocationData value = new ChickenPolymorphLocationData();
				pCurrData += value.Deserialize(pCurrData);
				ChickenLocations.Add(key, value);
			}
		}
		else
		{
			ChickenLocations?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
