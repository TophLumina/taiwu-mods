using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.DLC.FiveLoong;

[SerializableGameData(NotForArchive = true)]
public struct LoongLocationData(LoongInfo loongInfo) : ISerializableGameData
{
	[SerializableGameDataField]
	public int TemplateId = loongInfo.CharacterTemplateId;

	[SerializableGameDataField]
	public Location Location = loongInfo.LoongCurrentLocation;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = TemplateId;
		pCurrData += 4;
		pCurrData += Location.Serialize(pCurrData);
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
		TemplateId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Location.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
