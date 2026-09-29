using System.Collections.Generic;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class AllocateNeiliPreviewDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<short, int> PropertyDeltas;

	public static readonly short[] PreviewPropertyKeys = new short[28]
	{
		6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
		16, 17, 18, 19, 20, 21, 22, 23, 24, 25,
		26, 27, 28, 29, 30, 31, 32, 33
	};

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += 4;
		if (PropertyDeltas != null)
		{
			foreach (KeyValuePair<short, int> propertyDelta in PropertyDeltas)
			{
				_ = propertyDelta;
				totalSize += 2;
				totalSize += 4;
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
		if (PropertyDeltas != null)
		{
			*(int*)pCurrData = PropertyDeltas.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, int> pair in PropertyDeltas)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
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
		int PropertyDeltasElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (PropertyDeltasElementsCount > 0)
		{
			if (PropertyDeltas == null)
			{
				PropertyDeltas = new Dictionary<short, int>();
			}
			else
			{
				PropertyDeltas.Clear();
			}
			for (int i = 0; i < PropertyDeltasElementsCount; i++)
			{
				short key = *(short*)pCurrData;
				pCurrData += 2;
				int value = *(int*)pCurrData;
				pCurrData += 4;
				PropertyDeltas.Add(key, value);
			}
		}
		else
		{
			PropertyDeltas?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
