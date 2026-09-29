using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class GuardingSwordTombDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte SwordTombId;

	[SerializableGameDataField]
	public sbyte EscapeState;

	[SerializableGameDataField]
	public int InformationGatheringSuccessRate;

	[SerializableGameDataField]
	public int InjuryProbability;

	[SerializableGameDataField]
	public int FeatureGainRateA;

	[SerializableGameDataField]
	public int FeatureGainRateB;

	[SerializableGameDataField]
	public int InfectionDecreaseRate;

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
		*pData = (byte)SwordTombId;
		byte* num = pData + 1;
		*num = (byte)EscapeState;
		byte* num2 = num + 1;
		*(int*)num2 = InformationGatheringSuccessRate;
		byte* num3 = num2 + 4;
		*(int*)num3 = InjuryProbability;
		byte* num4 = num3 + 4;
		*(int*)num4 = FeatureGainRateA;
		byte* num5 = num4 + 4;
		*(int*)num5 = FeatureGainRateB;
		byte* num6 = num5 + 4;
		*(int*)num6 = InfectionDecreaseRate;
		int totalSize = (int)(num6 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		SwordTombId = (sbyte)(*pCurrData);
		pCurrData++;
		EscapeState = (sbyte)(*pCurrData);
		pCurrData++;
		InformationGatheringSuccessRate = *(int*)pCurrData;
		pCurrData += 4;
		InjuryProbability = *(int*)pCurrData;
		pCurrData += 4;
		FeatureGainRateA = *(int*)pCurrData;
		pCurrData += 4;
		FeatureGainRateB = *(int*)pCurrData;
		pCurrData += 4;
		InfectionDecreaseRate = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
