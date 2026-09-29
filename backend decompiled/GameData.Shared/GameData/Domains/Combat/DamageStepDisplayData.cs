using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public struct DamageStepDisplayData : ISerializableGameData
{
	public static readonly DamageStepDisplayData Invalid = new DamageStepDisplayData
	{
		ActivateSkillTemplateId = -1
	};

	[SerializableGameDataField]
	public short ActivateSkillTemplateId;

	[SerializableGameDataField]
	public CombatSkillDamageStepBonusDisplayData ActivateSkillBonusData;

	[SerializableGameDataField]
	public int EatingBonusData;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 22;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
