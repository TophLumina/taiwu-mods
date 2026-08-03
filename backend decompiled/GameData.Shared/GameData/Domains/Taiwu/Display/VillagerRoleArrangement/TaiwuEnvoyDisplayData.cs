using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

/// <summary>
/// 使者显示数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class TaiwuEnvoyDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	/// <summary>
	/// 可修改的超常条例数目
	/// </summary>
	[SerializableGameDataField]
	public int SpecialRuleCount;

	/// <summary>
	/// 威望消耗
	/// </summary>
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
