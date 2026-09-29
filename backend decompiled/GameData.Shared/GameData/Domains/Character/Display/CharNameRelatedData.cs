using GameData.Serializer;

namespace GameData.Domains.Character.Display;

[SerializableGameData(NotForArchive = true)]
public struct CharNameRelatedData(int charId, NameRelatedData nameData) : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharId = charId;

	[SerializableGameDataField]
	public NameRelatedData NameData = nameData;

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
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		pCurrData += NameData.Serialize(pCurrData);
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += NameData.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
