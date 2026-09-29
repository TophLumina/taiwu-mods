using GameData.Domains.CombatSkill;
using GameData.Serializer;

namespace GameData.Domains.Taiwu;

public class TaiwuCombatSkill : ISerializableGameData, ITaiwuSkill
{
	public static readonly sbyte[] FullPowerAddBreakSuccessRate = new sbyte[3] { 12, 6, 2 };

	private readonly sbyte[] _readingProgress;

	public int LastClearBreakPlateTime;

	public sbyte FullPowerCastTimes;

	public TaiwuCombatSkill()
	{
		_readingProgress = new sbyte[15];
		LastClearBreakPlateTime = -1000;
		FullPowerCastTimes = 0;
	}

	public TaiwuCombatSkill(ushort readingState)
		: this()
	{
		ApplyBookPageReadingProgress(readingState);
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 20;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		for (int i = 0; i < 15; i++)
		{
			pCurrData[i] = (byte)_readingProgress[i];
		}
		pCurrData += 15;
		*(int*)pCurrData = LastClearBreakPlateTime;
		pCurrData += 4;
		*pCurrData = (byte)FullPowerCastTimes;
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
		for (int i = 0; i < 15; i++)
		{
			_readingProgress[i] = (sbyte)pCurrData[i];
		}
		pCurrData += 15;
		LastClearBreakPlateTime = *(int*)pCurrData;
		pCurrData += 4;
		FullPowerCastTimes = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public void ApplyBookPageReadingProgress(ushort readingState)
	{
		for (byte i = 0; i < 15; i++)
		{
			if (CombatSkillStateHelper.IsPageRead(readingState, i))
			{
				SetBookPageReadingProgress(i, 100);
			}
		}
	}

	public sbyte GetBookPageReadingProgress(byte pageInternalIndex)
	{
		return _readingProgress[pageInternalIndex];
	}

	public void SetBookPageReadingProgress(byte pageInternalIndex, sbyte progress)
	{
		_readingProgress[pageInternalIndex] = progress;
	}

	public sbyte[] GetAllBookPageReadingProgress()
	{
		return _readingProgress;
	}
}
