using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class BuildingRelationshipDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	[SerializableGameDataField]
	public int RelationshipChange;

	[SerializableGameDataField]
	public bool IsIncreaseRelationship;

	[SerializableGameDataField]
	public int AffectedPeopleCount;

	[SerializableGameDataField]
	public int SecretInformationGainChange;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 13;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = RelationshipChange;
		byte* num = pData + 4;
		*num = (IsIncreaseRelationship ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*(int*)num2 = AffectedPeopleCount;
		byte* num3 = num2 + 4;
		*(int*)num3 = SecretInformationGainChange;
		int totalSize = (int)(num3 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		RelationshipChange = *(int*)pCurrData;
		pCurrData += 4;
		IsIncreaseRelationship = *pCurrData != 0;
		pCurrData++;
		AffectedPeopleCount = *(int*)pCurrData;
		pCurrData += 4;
		SecretInformationGainChange = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
