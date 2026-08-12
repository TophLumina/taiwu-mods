using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

/// <summary>
/// 联络感情
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class BuildingRelationshipDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	/// <summary>
	/// 好感度变化
	/// </summary>
	[SerializableGameDataField]
	public int RelationshipChange;

	/// <summary>
	/// 当前工作设置的是提升还是降低好感度
	/// </summary>
	/// <returns></returns>
	[SerializableGameDataField]
	public bool IsIncreaseRelationship;

	/// <summary>
	/// 影响人数
	/// </summary>
	[SerializableGameDataField]
	public int AffectedPeopleCount;

	/// <summary>
	/// 秘闻获取概率，文人才有
	/// </summary>
	[SerializableGameDataField]
	public int SecretInformationGainChange;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 13;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
