using GameData.Serializer;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 人物列表所需的人物秘闻数量数据
/// </summary>
public class CharacterInfoCountData : ISerializableGameData
{
	/// <summary>
	/// Npc持有的秘闻数量
	/// </summary>
	[SerializableGameDataField]
	public int HoldInfoCount;

	/// <summary>
	/// 玩家未持有的的秘闻数量
	/// </summary>
	[SerializableGameDataField]
	public int HoldInfoTaiwuDontHoldCount;

	/// <summary>
	/// 与玩家相关的秘闻数量
	/// </summary>
	[SerializableGameDataField]
	public int HoldInfoTaiwuRelatedCount;

	public CharacterInfoCountData()
	{
	}

	public CharacterInfoCountData(CharacterInfoCountData other)
	{
		HoldInfoCount = other.HoldInfoCount;
		HoldInfoTaiwuDontHoldCount = other.HoldInfoTaiwuDontHoldCount;
		HoldInfoTaiwuRelatedCount = other.HoldInfoTaiwuRelatedCount;
	}

	public void Assign(CharacterInfoCountData other)
	{
		HoldInfoCount = other.HoldInfoCount;
		HoldInfoTaiwuDontHoldCount = other.HoldInfoTaiwuDontHoldCount;
		HoldInfoTaiwuRelatedCount = other.HoldInfoTaiwuRelatedCount;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = HoldInfoCount;
		byte* num = pData + 4;
		*(int*)num = HoldInfoTaiwuDontHoldCount;
		byte* num2 = num + 4;
		*(int*)num2 = HoldInfoTaiwuRelatedCount;
		int totalSize = (int)(num2 + 4 - pData);
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
		HoldInfoCount = *(int*)pCurrData;
		pCurrData += 4;
		HoldInfoTaiwuDontHoldCount = *(int*)pCurrData;
		pCurrData += 4;
		HoldInfoTaiwuRelatedCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
