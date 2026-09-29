using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public struct CombatSkillDamageStepBonusDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int OuterInjuryStepBonus;

	[SerializableGameDataField]
	public int InnerInjuryStepBonus;

	[SerializableGameDataField]
	public int FatalStepBonus;

	[SerializableGameDataField]
	public int MindStepBonus;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 16;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
