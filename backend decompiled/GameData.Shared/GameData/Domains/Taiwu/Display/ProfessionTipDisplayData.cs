using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display;

[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class ProfessionTipDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int ProfessionId;

	[SerializableGameDataField]
	public sbyte WorkingSkillType;

	[SerializableGameDataField]
	public int AttainmentBonus;

	[SerializableGameDataField]
	public int ProfessionUpgrade;

	[SerializableGameDataField]
	public int ProfessionUpgradeBonus;

	[SerializableGameDataField]
	public bool IsWearingBonusClothing;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 18;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = ProfessionId;
		byte* num = pData + 4;
		*num = (byte)WorkingSkillType;
		byte* num2 = num + 1;
		*(int*)num2 = AttainmentBonus;
		byte* num3 = num2 + 4;
		*(int*)num3 = ProfessionUpgrade;
		byte* num4 = num3 + 4;
		*(int*)num4 = ProfessionUpgradeBonus;
		byte* num5 = num4 + 4;
		*num5 = (IsWearingBonusClothing ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num5 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ProfessionId = *(int*)pCurrData;
		pCurrData += 4;
		WorkingSkillType = (sbyte)(*pCurrData);
		pCurrData++;
		AttainmentBonus = *(int*)pCurrData;
		pCurrData += 4;
		ProfessionUpgrade = *(int*)pCurrData;
		pCurrData += 4;
		ProfessionUpgradeBonus = *(int*)pCurrData;
		pCurrData += 4;
		IsWearingBonusClothing = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
