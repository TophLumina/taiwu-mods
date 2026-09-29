using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class TravelerSkillsDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<TravelerPalaceData> Palaces;

	[SerializableGameDataField]
	public List<CharacterLocationDisplayData> DisplayData;

	[SerializableGameDataField]
	public short CurrHealth;

	[SerializableGameDataField]
	public short LeftMaxHealth;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (Palaces != null)
		{
			totalSize += 2;
			for (int i = 0; i < Palaces.Count; i++)
			{
				totalSize = ((Palaces[i] == null) ? (totalSize + 2) : (totalSize + (2 + Palaces[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (DisplayData != null)
		{
			totalSize += 2;
			for (int j = 0; j < DisplayData.Count; j++)
			{
				totalSize = ((DisplayData[j] == null) ? (totalSize + 2) : (totalSize + (2 + DisplayData[j].GetSerializedSize())));
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
		if (Palaces != null)
		{
			int elementsCount = Palaces.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (Palaces[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = Palaces[i].Serialize(pCurrData);
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
		if (DisplayData != null)
		{
			int elementsCount2 = DisplayData.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (DisplayData[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = DisplayData[j].Serialize(pCurrData);
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
		*(short*)pCurrData = CurrHealth;
		pCurrData += 2;
		*(short*)pCurrData = LeftMaxHealth;
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Palaces == null)
			{
				Palaces = new List<TravelerPalaceData>();
			}
			else
			{
				Palaces.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				TravelerPalaceData element;
				if (num > 0)
				{
					element = new TravelerPalaceData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				Palaces.Add(element);
			}
		}
		else
		{
			Palaces?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (DisplayData == null)
			{
				DisplayData = new List<CharacterLocationDisplayData>();
			}
			else
			{
				DisplayData.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterLocationDisplayData element2;
				if (num2 > 0)
				{
					element2 = new CharacterLocationDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				DisplayData.Add(element2);
			}
		}
		else
		{
			DisplayData?.Clear();
		}
		CurrHealth = *(short*)pCurrData;
		pCurrData += 2;
		LeftMaxHealth = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
