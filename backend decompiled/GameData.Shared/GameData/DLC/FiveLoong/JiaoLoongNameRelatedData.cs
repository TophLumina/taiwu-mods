using Config;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.DLC.FiveLoong;

/// <summary>
/// 蛟龙姓名关联信息
/// </summary>
public struct JiaoLoongNameRelatedData : ISerializableGameData
{
	/// <summary>
	/// 对应的物品类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte ItemType;

	/// <summary>
	/// 对应的道具模板 ID
	/// </summary>
	[SerializableGameDataField]
	public short ItemTemplateId;

	/// <summary>
	/// 对应的角色模板 ID
	/// </summary>
	[SerializableGameDataField]
	public short CharTemplateId;

	/// <summary>
	/// 名字自定义字符串的Id
	/// </summary>
	[SerializableGameDataField]
	public int NameId;

	/// <summary>
	/// 获取名称
	/// </summary>
	/// <returns></returns>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
