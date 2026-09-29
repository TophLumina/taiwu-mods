using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Serializer;

namespace GameData.Domains.Organization.Display;

[SerializableGameData(NoCopyConstructors = true)]
public class SettlementBountyDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<int, CharacterDisplayDataForSettlementBounty> BountyCharacterDisplayDataDict;

	[SerializableGameDataField]
	public int OrgTemplateId;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(BountyCharacterDisplayDataDict);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* num = pData + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pData, ref BountyCharacterDisplayDataDict);
		*(int*)num = OrgTemplateId;
		int totalSize = (int)(num + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref BountyCharacterDisplayDataDict);
		OrgTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
