using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class VillagerRoleCharacterSlimDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public short RoleTemplateId;

	[SerializableGameDataField]
	public short ArrangementTemplateId;

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
		*(int*)pData = Id;
		byte* num = pData + 4;
		*(short*)num = RoleTemplateId;
		byte* num2 = num + 2;
		*(short*)num2 = ArrangementTemplateId;
		int totalSize = (int)(num2 + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		Id = *(int*)pCurrData;
		pCurrData += 4;
		RoleTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ArrangementTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
