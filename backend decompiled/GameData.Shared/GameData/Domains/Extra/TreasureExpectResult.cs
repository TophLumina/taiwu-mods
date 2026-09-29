using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Extra;

[SerializableGameData(NotForArchive = true)]
public struct TreasureExpectResult : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte MaxGrade;

	[SerializableGameDataField]
	public int Chance;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public bool AnyMaterial;

	[SerializableGameDataField]
	public bool AnyNormalItem;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)MaxGrade;
		pCurrData++;
		*(int*)pCurrData = Chance;
		pCurrData += 4;
		pCurrData += Location.Serialize(pCurrData);
		*pCurrData = (AnyMaterial ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AnyNormalItem ? ((byte)1) : ((byte)0));
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
		MaxGrade = (sbyte)(*pCurrData);
		pCurrData++;
		Chance = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Location.Deserialize(pCurrData);
		AnyMaterial = *pCurrData != 0;
		pCurrData++;
		AnyNormalItem = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
