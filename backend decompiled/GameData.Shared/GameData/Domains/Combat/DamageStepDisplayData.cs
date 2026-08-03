using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 伤害阈值显示数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public struct DamageStepDisplayData : ISerializableGameData
{
	/// <summary>
	/// 非法值
	/// </summary>
	public static readonly DamageStepDisplayData Invalid = new DamageStepDisplayData
	{
		ActivateSkillTemplateId = -1
	};

	/// <summary>
	/// 当前生效的最大伤害阈值技能模板 ID
	/// </summary>
	[SerializableGameDataField]
	public short ActivateSkillTemplateId;

	/// <summary>
	/// 当前生效的功法伤害阈值加成数据
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillDamageStepBonusDisplayData ActivateSkillBonusData;

	/// <summary>
	/// 服食的伤害阈值加成数据
	/// </summary>
	[SerializableGameDataField]
	public int EatingBonusData;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 22;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = ActivateSkillTemplateId;
		pCurrData += 2;
		pCurrData += ActivateSkillBonusData.Serialize(pCurrData);
		*(int*)pCurrData = EatingBonusData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
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
		ActivateSkillTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += ActivateSkillBonusData.Deserialize(pCurrData);
		EatingBonusData = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
