using Config;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.DLC.FiveLoong;

public struct JiaoLoongNameRelatedData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte ItemType;

	[SerializableGameDataField]
	public short ItemTemplateId;

	[SerializableGameDataField]
	public short CharTemplateId;

	[SerializableGameDataField]
	public int NameId;

	public string GetName()
	{
		if (NameId >= 0 && ExternalDataBridge.Context.CustomTexts.TryGetValue(NameId, out var text))
		{
			return text;
		}
		if (CharTemplateId >= 0)
		{
			CharacterItem charTemplate = Character.Instance[CharTemplateId];
			return charTemplate.Surname + charTemplate.GivenName;
		}
		if (ItemType < 0)
		{
			return ExtraNameText.Instance[5].Content;
		}
		return ItemTemplateHelper.GetName(ItemType, ItemTemplateId);
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
		*pData = (byte)ItemType;
		byte* num = pData + 1;
		*(short*)num = ItemTemplateId;
		byte* num2 = num + 2;
		*(short*)num2 = CharTemplateId;
		byte* num3 = num2 + 2;
		*(int*)num3 = NameId;
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
		ItemType = (sbyte)(*pCurrData);
		pCurrData++;
		ItemTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		CharTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		NameId = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
