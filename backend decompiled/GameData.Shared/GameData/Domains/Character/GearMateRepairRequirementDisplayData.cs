using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class GearMateRepairRequirementDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int GearMateId;

	[SerializableGameDataField]
	public sbyte RepairType;

	[SerializableGameDataField]
	public sbyte ResourceType;

	[SerializableGameDataField]
	public int ResourceCost;

	[SerializableGameDataField]
	public sbyte LifeSkillType;

	[SerializableGameDataField]
	public int AttainmentCount;

	[SerializableGameDataField]
	public sbyte ItemGrade;

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
		*(int*)pData = GearMateId;
		byte* num = pData + 4;
		*num = (byte)RepairType;
		byte* num2 = num + 1;
		*num2 = (byte)ResourceType;
		byte* num3 = num2 + 1;
		*(int*)num3 = ResourceCost;
		byte* num4 = num3 + 4;
		*num4 = (byte)LifeSkillType;
		byte* num5 = num4 + 1;
		*(int*)num5 = AttainmentCount;
		byte* num6 = num5 + 4;
		*num6 = (byte)ItemGrade;
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
		GearMateId = *(int*)pCurrData;
		pCurrData += 4;
		RepairType = (sbyte)(*pCurrData);
		pCurrData++;
		ResourceType = (sbyte)(*pCurrData);
		pCurrData++;
		ResourceCost = *(int*)pCurrData;
		pCurrData += 4;
		LifeSkillType = (sbyte)(*pCurrData);
		pCurrData++;
		AttainmentCount = *(int*)pCurrData;
		pCurrData += 4;
		ItemGrade = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
