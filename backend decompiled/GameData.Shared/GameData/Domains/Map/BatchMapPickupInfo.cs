using GameData.Serializer;

namespace GameData.Domains.Map;

[SerializableGameData(NotForArchive = true)]
public struct BatchMapPickupInfo : ISerializableGameData
{
	[SerializableGameDataField]
	public Location Location = Location.Invalid;

	[SerializableGameDataField]
	public bool PickAll = false;

	[SerializableGameDataField]
	public int PickupIndex = -1;

	public BatchMapPickupInfo()
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Location.Serialize(pCurrData);
		*pCurrData = (PickAll ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = PickupIndex;
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
		pCurrData += Location.Deserialize(pCurrData);
		PickAll = *pCurrData != 0;
		pCurrData++;
		PickupIndex = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
