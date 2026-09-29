using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

[SerializableGameData(NoCopyConstructors = true)]
public class EventSelectNeigongLoopingCountData : ISerializableGameData
{
	[SerializableGameDataField]
	public CombatSkillDisplayData SelectedCombatSkill;

	[SerializableGameDataField]
	public int MaxLoopingCount;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((SelectedCombatSkill == null) ? (totalSize + 2) : (totalSize + (2 + SelectedCombatSkill.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (SelectedCombatSkill != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = SelectedCombatSkill.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = MaxLoopingCount;
		pCurrData += 4;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (SelectedCombatSkill == null)
			{
				SelectedCombatSkill = new CombatSkillDisplayData();
			}
			pCurrData += SelectedCombatSkill.Deserialize(pCurrData);
		}
		else
		{
			SelectedCombatSkill = null;
		}
		MaxLoopingCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
