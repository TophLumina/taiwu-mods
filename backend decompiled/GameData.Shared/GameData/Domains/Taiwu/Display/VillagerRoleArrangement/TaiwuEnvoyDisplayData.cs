using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class TaiwuEnvoyDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	[SerializableGameDataField]
	public int SpecialRuleCount;

	[SerializableGameDataField]
	public int MonthlyAuthorityCost;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = SpecialRuleCount;
		byte* num = pData + 4;
		*(int*)num = MonthlyAuthorityCost;
		int totalSize = (int)(num + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		SpecialRuleCount = *(int*)pCurrData;
		pCurrData += 4;
		MonthlyAuthorityCost = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
