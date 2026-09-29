using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData]
public struct Production(sbyte itemType, short templateId) : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte ItemType = itemType;

	[SerializableGameDataField]
	public short TemplateId = templateId;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)ItemType;
		byte* num = pData + 1;
		*(short*)num = TemplateId;
		int totalSize = (int)(num + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ItemType = (sbyte)(*pCurrData);
		pCurrData++;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
