using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Serializer;

namespace GameData.Domains.Organization.Display;

/// <summary>
/// 定居点悬赏界面显示数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true)]
public class SettlementBountyDisplayData : ISerializableGameData
{
	/// <summary>
	/// 人物数据，Key为charId
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, CharacterDisplayDataForSettlementBounty> BountyCharacterDisplayDataDict;

	/// <summary>
	/// 组织模板ID
	/// </summary>
	[SerializableGameDataField]
	public int OrgTemplateId;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
