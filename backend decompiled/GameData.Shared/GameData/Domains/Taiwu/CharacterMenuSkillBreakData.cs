using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class CharacterMenuSkillBreakData : ISerializableGameData
{
	[SerializableGameDataField]
	public int BaseCostExp;

	[SerializableGameDataField]
	public bool WudangUpgradeInteractionUnlocked;

	[SerializableGameDataField]
	public CombatSkillDisplayDataCharacterMenuListItem SkillDisplayDataSimple;

	[SerializableGameDataField]
	public int CurrQualification;

	[SerializableGameDataField]
	public int RequireQualification;

	[SerializableGameDataField]
	public bool IsCombatSkillQualification;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 14;
		totalSize = ((SkillDisplayDataSimple == null) ? (totalSize + 2) : (totalSize + (2 + SkillDisplayDataSimple.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = BaseCostExp;
		pCurrData += 4;
		*pCurrData = (WudangUpgradeInteractionUnlocked ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (SkillDisplayDataSimple != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = SkillDisplayDataSimple.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = CurrQualification;
		pCurrData += 4;
		*(int*)pCurrData = RequireQualification;
		pCurrData += 4;
		*pCurrData = (IsCombatSkillQualification ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		BaseCostExp = *(int*)pCurrData;
		pCurrData += 4;
		WudangUpgradeInteractionUnlocked = *pCurrData != 0;
		pCurrData++;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (SkillDisplayDataSimple == null)
			{
				SkillDisplayDataSimple = new CombatSkillDisplayDataCharacterMenuListItem();
			}
			pCurrData += SkillDisplayDataSimple.Deserialize(pCurrData);
		}
		else
		{
			SkillDisplayDataSimple = null;
		}
		CurrQualification = *(int*)pCurrData;
		pCurrData += 4;
		RequireQualification = *(int*)pCurrData;
		pCurrData += 4;
		IsCombatSkillQualification = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
