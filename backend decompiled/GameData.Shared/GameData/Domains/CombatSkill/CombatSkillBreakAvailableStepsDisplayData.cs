using GameData.Serializer;

namespace GameData.Domains.CombatSkill;

[SerializableGameData(NotForArchive = true)]
public class CombatSkillBreakAvailableStepsDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte BaseAvailableSteps;

	[SerializableGameDataField]
	public sbyte BaseBaseAvailableSteps;

	[SerializableGameDataField]
	public sbyte BuildingBonus;

	[SerializableGameDataField]
	public sbyte ConsummateLevelBonus;

	[SerializableGameDataField]
	public sbyte InteractionGradeBonus;

	[SerializableGameDataField]
	public sbyte AdventureBonus;

	[SerializableGameDataField]
	public sbyte OrganizationBonus;

	public CombatSkillBreakAvailableStepsDisplayData()
	{
	}

	public CombatSkillBreakAvailableStepsDisplayData(CombatSkillBreakAvailableStepsDisplayData other)
	{
		BaseAvailableSteps = other.BaseAvailableSteps;
		BaseBaseAvailableSteps = other.BaseBaseAvailableSteps;
		BuildingBonus = other.BuildingBonus;
		ConsummateLevelBonus = other.ConsummateLevelBonus;
		InteractionGradeBonus = other.InteractionGradeBonus;
		AdventureBonus = other.AdventureBonus;
		OrganizationBonus = other.OrganizationBonus;
	}

	public void Assign(CombatSkillBreakAvailableStepsDisplayData other)
	{
		BaseAvailableSteps = other.BaseAvailableSteps;
		BaseBaseAvailableSteps = other.BaseBaseAvailableSteps;
		BuildingBonus = other.BuildingBonus;
		ConsummateLevelBonus = other.ConsummateLevelBonus;
		InteractionGradeBonus = other.InteractionGradeBonus;
		AdventureBonus = other.AdventureBonus;
		OrganizationBonus = other.OrganizationBonus;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)BaseAvailableSteps;
		byte* num = pData + 1;
		*num = (byte)BaseBaseAvailableSteps;
		byte* num2 = num + 1;
		*num2 = (byte)BuildingBonus;
		byte* num3 = num2 + 1;
		*num3 = (byte)ConsummateLevelBonus;
		byte* num4 = num3 + 1;
		*num4 = (byte)InteractionGradeBonus;
		byte* num5 = num4 + 1;
		*num5 = (byte)AdventureBonus;
		byte* num6 = num5 + 1;
		*num6 = (byte)OrganizationBonus;
		int totalSize = (int)(num6 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		BaseAvailableSteps = (sbyte)(*pCurrData);
		pCurrData++;
		BaseBaseAvailableSteps = (sbyte)(*pCurrData);
		pCurrData++;
		BuildingBonus = (sbyte)(*pCurrData);
		pCurrData++;
		ConsummateLevelBonus = (sbyte)(*pCurrData);
		pCurrData++;
		InteractionGradeBonus = (sbyte)(*pCurrData);
		pCurrData++;
		AdventureBonus = (sbyte)(*pCurrData);
		pCurrData++;
		OrganizationBonus = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
