using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

/// <summary>
/// 学习生活技能
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class LearningLifeSkillDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	/// <summary>
	/// 请教别人生活技能的成功率
	/// </summary>
	[SerializableGameDataField]
	public float LearningSuccessRate;

	/// <summary>
	/// 每月额外请教一次的概率
	/// </summary>
	[SerializableGameDataField]
	public float ExtraLearningChance;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(float*)pData = LearningSuccessRate;
		byte* num = pData + 4;
		*(float*)num = ExtraLearningChance;
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
		LearningSuccessRate = *(float*)pCurrData;
		pCurrData += 4;
		ExtraLearningChance = *(float*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
