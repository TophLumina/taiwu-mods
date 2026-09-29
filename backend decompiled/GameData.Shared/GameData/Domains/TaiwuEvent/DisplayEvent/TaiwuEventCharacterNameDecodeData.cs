using GameData.Domains.Character.Display;
using GameData.Serializer;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

public struct TaiwuEventCharacterNameDecodeData : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public NameRelatedData NameRelatedData;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 36;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		pCurrData += NameRelatedData.Serialize(pCurrData);
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
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += NameRelatedData.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
