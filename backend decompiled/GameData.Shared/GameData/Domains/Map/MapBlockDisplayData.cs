using GameData.Domains.Extra;
using GameData.Serializer;

namespace GameData.Domains.Map;

[SerializableGameData(NotForArchive = true)]
public struct MapBlockDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public TreasureExpectResult TreasureExpect;

	[SerializableGameDataField]
	public int ProfessionId;

	[SerializableGameDataField]
	public int Count0;

	[SerializableGameDataField]
	public int Count1;

	[SerializableGameDataField]
	public int Count2;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 28;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += TreasureExpect.Serialize(pCurrData);
		*(int*)pCurrData = ProfessionId;
		pCurrData += 4;
		*(int*)pCurrData = Count0;
		pCurrData += 4;
		*(int*)pCurrData = Count1;
		pCurrData += 4;
		*(int*)pCurrData = Count2;
		pCurrData += 4;
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
		pCurrData += TreasureExpect.Deserialize(pCurrData);
		ProfessionId = *(int*)pCurrData;
		pCurrData += 4;
		Count0 = *(int*)pCurrData;
		pCurrData += 4;
		Count1 = *(int*)pCurrData;
		pCurrData += 4;
		Count2 = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
