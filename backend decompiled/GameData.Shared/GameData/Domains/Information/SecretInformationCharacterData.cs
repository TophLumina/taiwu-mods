using GameData.Serializer;

namespace GameData.Domains.Information;

public class SecretInformationCharacterData : ISerializableGameData
{
	[SerializableGameDataField]
	public int SecretInformationMetaDataId;

	[SerializableGameDataField]
	public int SecretInformationDisseminationBranch;

	[SerializableGameDataField]
	public int SourceCharacterId;

	public SecretInformationCharacterData(int secretInformationMetaDataId, int secretInformationDisseminationBranch = -1)
	{
		SecretInformationMetaDataId = secretInformationMetaDataId;
		SecretInformationDisseminationBranch = secretInformationDisseminationBranch;
		SourceCharacterId = 0;
	}

	public SecretInformationCharacterData()
		: this(-1)
	{
	}

	public SecretInformationCharacterData(SecretInformationCharacterData other)
	{
		SecretInformationMetaDataId = other.SecretInformationMetaDataId;
		SecretInformationDisseminationBranch = other.SecretInformationDisseminationBranch;
		SourceCharacterId = other.SourceCharacterId;
	}

	public void Assign(SecretInformationCharacterData other)
	{
		SecretInformationMetaDataId = other.SecretInformationMetaDataId;
		SecretInformationDisseminationBranch = other.SecretInformationDisseminationBranch;
		SourceCharacterId = other.SourceCharacterId;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = SecretInformationMetaDataId;
		byte* num = pData + 4;
		*(int*)num = SecretInformationDisseminationBranch;
		byte* num2 = num + 4;
		*(int*)num2 = SourceCharacterId;
		int totalSize = (int)(num2 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		SecretInformationMetaDataId = *(int*)pCurrData;
		pCurrData += 4;
		SecretInformationDisseminationBranch = *(int*)pCurrData;
		pCurrData += 4;
		SourceCharacterId = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
