using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 功法伤害阈值加成显示数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public struct CombatSkillDamageStepBonusDisplayData : ISerializableGameData
{
	/// <summary>
	/// 外伤伤势阈值加成系数
	/// </summary>
	[SerializableGameDataField]
	public int OuterInjuryStepBonus;

	/// <summary>
	/// 内伤伤势阈值加成系数
	/// </summary>
	[SerializableGameDataField]
	public int InnerInjuryStepBonus;

	/// <summary>
	/// 重创阈值加成系数
	/// </summary>
	[SerializableGameDataField]
	public int FatalStepBonus;

	/// <summary>
	/// 失神阈值加成系数
	/// </summary>
	[SerializableGameDataField]
	public int MindStepBonus;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 16;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = OuterInjuryStepBonus;
		byte* num = pData + 4;
		*(int*)num = InnerInjuryStepBonus;
		byte* num2 = num + 4;
		*(int*)num2 = FatalStepBonus;
		byte* num3 = num2 + 4;
		*(int*)num3 = MindStepBonus;
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
		OuterInjuryStepBonus = *(int*)pCurrData;
		pCurrData += 4;
		InnerInjuryStepBonus = *(int*)pCurrData;
		pCurrData += 4;
		FatalStepBonus = *(int*)pCurrData;
		pCurrData += 4;
		MindStepBonus = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
