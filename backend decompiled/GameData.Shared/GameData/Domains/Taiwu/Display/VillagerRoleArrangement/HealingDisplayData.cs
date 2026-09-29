using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class HealingDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	[SerializableGameDataField]
	public int InteractTargetGrade;

	[SerializableGameDataField]
	public int HealXiangshuInfectionAmount;

	[SerializableGameDataField]
	public int GainSpiritualDebt;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = InteractTargetGrade;
		byte* num = pData + 4;
		*(int*)num = HealXiangshuInfectionAmount;
		byte* num2 = num + 4;
		*(int*)num2 = GainSpiritualDebt;
		int totalSize = (int)(num2 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		InteractTargetGrade = *(int*)pCurrData;
		pCurrData += 4;
		HealXiangshuInfectionAmount = *(int*)pCurrData;
		pCurrData += 4;
		GainSpiritualDebt = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
