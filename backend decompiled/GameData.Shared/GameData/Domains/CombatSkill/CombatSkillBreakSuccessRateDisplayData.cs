using GameData.Serializer;

namespace GameData.Domains.CombatSkill;

[SerializableGameData(NotForArchive = true)]
public class CombatSkillBreakSuccessRateDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public byte BaseSuccessRate;

	[SerializableGameDataField]
	public byte BaseBaseSuccessRate;

	[SerializableGameDataField]
	public byte OrganizationBonus;

	[SerializableGameDataField]
	public byte AttributesBonus;

	[SerializableGameDataField]
	public byte ConsummateLevelBonus;

	[SerializableGameDataField]
	public byte BuildingBonus;

	[SerializableGameDataField]
	public byte AdventureBonus;

	[SerializableGameDataField]
	public byte DifficultyBonus;

	public CombatSkillBreakSuccessRateDisplayData()
	{
	}

	public CombatSkillBreakSuccessRateDisplayData(CombatSkillBreakSuccessRateDisplayData other)
	{
		BaseSuccessRate = other.BaseSuccessRate;
		BaseBaseSuccessRate = other.BaseBaseSuccessRate;
		OrganizationBonus = other.OrganizationBonus;
		AttributesBonus = other.AttributesBonus;
		ConsummateLevelBonus = other.ConsummateLevelBonus;
		BuildingBonus = other.BuildingBonus;
		AdventureBonus = other.AdventureBonus;
		DifficultyBonus = other.DifficultyBonus;
	}

	public void Assign(CombatSkillBreakSuccessRateDisplayData other)
	{
		BaseSuccessRate = other.BaseSuccessRate;
		BaseBaseSuccessRate = other.BaseBaseSuccessRate;
		OrganizationBonus = other.OrganizationBonus;
		AttributesBonus = other.AttributesBonus;
		ConsummateLevelBonus = other.ConsummateLevelBonus;
		BuildingBonus = other.BuildingBonus;
		AdventureBonus = other.AdventureBonus;
		DifficultyBonus = other.DifficultyBonus;
	}

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
		*pData = BaseSuccessRate;
		byte* num = pData + 1;
		*num = BaseBaseSuccessRate;
		byte* num2 = num + 1;
		*num2 = OrganizationBonus;
		byte* num3 = num2 + 1;
		*num3 = AttributesBonus;
		byte* num4 = num3 + 1;
		*num4 = ConsummateLevelBonus;
		byte* num5 = num4 + 1;
		*num5 = BuildingBonus;
		byte* num6 = num5 + 1;
		*num6 = AdventureBonus;
		byte* num7 = num6 + 1;
		*num7 = DifficultyBonus;
		int totalSize = (int)(num7 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		BaseSuccessRate = *pCurrData;
		pCurrData++;
		BaseBaseSuccessRate = *pCurrData;
		pCurrData++;
		OrganizationBonus = *pCurrData;
		pCurrData++;
		AttributesBonus = *pCurrData;
		pCurrData++;
		ConsummateLevelBonus = *pCurrData;
		pCurrData++;
		BuildingBonus = *pCurrData;
		pCurrData++;
		AdventureBonus = *pCurrData;
		pCurrData++;
		DifficultyBonus = *pCurrData;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
