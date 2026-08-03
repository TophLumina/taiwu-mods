using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class PuppetPageDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<short> Puppets;

	[SerializableGameDataField]
	public List<short> Features;

	[SerializableGameDataField]
	public int LegendaryBookOwningState;

	[SerializableGameDataField]
	public bool IsAtSettlement;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		totalSize = ((Puppets == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Puppets.Count)));
		totalSize = ((Features == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Features.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Puppets != null)
		{
			int elementsCount = Puppets.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = Puppets[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Features != null)
		{
			int elementsCount2 = Features.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(short*)pCurrData = Features[j];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = LegendaryBookOwningState;
		pCurrData += 4;
		*pCurrData = (IsAtSettlement ? ((byte)1) : ((byte)0));
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Puppets == null)
			{
				Puppets = new List<short>();
			}
			else
			{
				Puppets.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				Puppets.Add(element);
			}
		}
		else
		{
			Puppets?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (Features == null)
			{
				Features = new List<short>();
			}
			else
			{
				Features.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				short element2 = *(short*)pCurrData;
				pCurrData += 2;
				Features.Add(element2);
			}
		}
		else
		{
			Features?.Clear();
		}
		LegendaryBookOwningState = *(int*)pCurrData;
		pCurrData += 4;
		IsAtSettlement = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
