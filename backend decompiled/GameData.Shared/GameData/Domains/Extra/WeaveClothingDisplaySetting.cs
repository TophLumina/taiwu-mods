using GameData.Serializer;

namespace GameData.Domains.Extra;

/// <summary>
/// 衣装改制的设置
/// </summary>
public struct WeaveClothingDisplaySetting : ISerializableGameData
{
	/// <summary>
	/// 衣装改制初始的性别设置
	/// </summary>
	[SerializableGameDataField]
	public byte ClothingDisplayOriginSettingGender;

	/// <summary>
	/// 衣装改制初始的体型设置
	/// </summary>
	[SerializableGameDataField]
	public byte ClothingDisplayOriginSettingBodyType;

	/// <summary>
	/// 衣装改制预览的性别设置
	/// </summary>
	[SerializableGameDataField]
	public byte ClothingDisplayPreviewSettingGender;

	/// <summary>
	/// 衣装改制预览的体型设置
	/// </summary>
	[SerializableGameDataField]
	public byte ClothingDisplayPreviewSettingBodyType;

	/// <summary>
	/// 初始化，默认是女性、中体型，性别见<see cref="T:GameData.Domains.Character.Gender" />，体型123，换算后见<see cref="F:GameData.Domains.Character.AvatarSystem.AvatarData.AvatarId" />
	/// </summary>
	public void Init()
	{
		ClothingDisplayOriginSettingGender = 0;
		ClothingDisplayOriginSettingBodyType = 2;
		ClothingDisplayPreviewSettingGender = 0;
		ClothingDisplayPreviewSettingBodyType = 2;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
