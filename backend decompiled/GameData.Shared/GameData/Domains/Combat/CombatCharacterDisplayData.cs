using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 战斗人物显示数据。用于向前端返回战斗中打开人物界面显示所需数据，使前端不必监听战斗域数据
/// </summary>
public class CombatCharacterDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public DefeatMarkCollection DefeatMarks;

	[SerializableGameDataField]
	public Injuries OldInjuries;

	[SerializableGameDataField]
	public PoisonInts OldPoisons;

	[SerializableGameDataField]
	public short OldDisorderOfQi;

	[SerializableGameDataField]
	public sbyte Happiness;

	public CombatCharacterDisplayData()
	{
	}

	public CombatCharacterDisplayData(CombatCharacterDisplayData other)
	{
		DefeatMarks = new DefeatMarkCollection(other.DefeatMarks);
		OldInjuries = other.OldInjuries;
		OldPoisons = other.OldPoisons;
		OldDisorderOfQi = other.OldDisorderOfQi;
		Happiness = other.Happiness;
	}

	public void Assign(CombatCharacterDisplayData other)
	{
		DefeatMarks = new DefeatMarkCollection(other.DefeatMarks);
		OldInjuries = other.OldInjuries;
		OldPoisons = other.OldPoisons;
		OldDisorderOfQi = other.OldDisorderOfQi;
		Happiness = other.Happiness;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 43;
		totalSize = ((DefeatMarks == null) ? (totalSize + 2) : (totalSize + (2 + DefeatMarks.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (DefeatMarks != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = DefeatMarks.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += OldInjuries.Serialize(pCurrData);
		pCurrData += OldPoisons.Serialize(pCurrData);
		*(short*)pCurrData = OldDisorderOfQi;
		pCurrData += 2;
		*pCurrData = (byte)Happiness;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (DefeatMarks == null)
			{
				DefeatMarks = new DefeatMarkCollection();
			}
			pCurrData += DefeatMarks.Deserialize(pCurrData);
		}
		else
		{
			DefeatMarks = null;
		}
		pCurrData += OldInjuries.Deserialize(pCurrData);
		pCurrData += OldPoisons.Deserialize(pCurrData);
		OldDisorderOfQi = *(short*)pCurrData;
		pCurrData += 2;
		Happiness = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
