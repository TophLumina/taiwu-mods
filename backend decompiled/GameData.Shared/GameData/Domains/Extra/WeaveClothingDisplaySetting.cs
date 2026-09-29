using GameData.Serializer;

namespace GameData.Domains.Extra;

public struct WeaveClothingDisplaySetting : ISerializableGameData
{
	[SerializableGameDataField]
	public byte ClothingDisplayOriginSettingGender;

	[SerializableGameDataField]
	public byte ClothingDisplayOriginSettingBodyType;

	[SerializableGameDataField]
	public byte ClothingDisplayPreviewSettingGender;

	[SerializableGameDataField]
	public byte ClothingDisplayPreviewSettingBodyType;

	public void Init()
	{
		ClothingDisplayOriginSettingGender = 0;
		ClothingDisplayOriginSettingBodyType = 2;
		ClothingDisplayPreviewSettingGender = 0;
		ClothingDisplayPreviewSettingBodyType = 2;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = ClothingDisplayOriginSettingGender;
		byte* num = pData + 1;
		*num = ClothingDisplayOriginSettingBodyType;
		byte* num2 = num + 1;
		*num2 = ClothingDisplayPreviewSettingGender;
		byte* num3 = num2 + 1;
		*num3 = ClothingDisplayPreviewSettingBodyType;
		int totalSize = (int)(num3 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ClothingDisplayOriginSettingGender = *pCurrData;
		pCurrData++;
		ClothingDisplayOriginSettingBodyType = *pCurrData;
		pCurrData++;
		ClothingDisplayPreviewSettingGender = *pCurrData;
		pCurrData++;
		ClothingDisplayPreviewSettingBodyType = *pCurrData;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
