using GameData.Domains.CombatSkill;
using GameData.Serializer;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 太吾功法数据中比 NPC 多出的部分
/// </summary>
public class TaiwuCombatSkill : ISerializableGameData, ITaiwuSkill
{
	/// <summary>
	/// 每次十成威力加成突破成功率
	/// </summary>
	public static readonly sbyte[] FullPowerAddBreakSuccessRate = new sbyte[3] { 12, 6, 2 };

	/// <summary>
	/// 每页的研读进度
	/// </summary>
	private readonly sbyte[] _readingProgress;

	/// <summary>
	/// 上次重修的日期（月数）
	/// </summary>
	public int LastClearBreakPlateTime;

	/// <summary>
	/// 对精纯相等或更高的敌人发挥十成威力的次数
	/// </summary>
	public sbyte FullPowerCastTimes;

	public TaiwuCombatSkill()
	{
		_readingProgress = new sbyte[15];
		LastClearBreakPlateTime = -1000;
		FullPowerCastTimes = 0;
	}

	/// <summary>
	/// 构造功法对象.
	/// 对于已读的书页, 研读进度会设置为100; 未读书页则设置为 0.
	/// </summary>
	/// <param name="readingState"></param>
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

	/// <summary>
	/// 根据研读状态将所有已读书页进度设为满值
	/// </summary>
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

	/// <summary>
	/// 获取指定书页的研读进度
	/// </summary>
	/// <param name="pageInternalIndex"><see cref="M:GameData.Domains.CombatSkill.CombatSkillStateHelper.GetPageInternalIndex(System.SByte,System.SByte,System.Byte)" /></param>
	/// <returns></returns>
	public sbyte GetBookPageReadingProgress(byte pageInternalIndex)
	{
		return _readingProgress[pageInternalIndex];
	}

	/// <summary>
	/// 设置指定书页的研读进度
	/// </summary>
	/// <param name="pageInternalIndex"><see cref="M:GameData.Domains.CombatSkill.CombatSkillStateHelper.GetPageInternalIndex(System.SByte,System.SByte,System.Byte)" /></param>
	/// <param name="progress"></param>
	/// <returns></returns>
	public void SetBookPageReadingProgress(byte pageInternalIndex, sbyte progress)
	{
		_readingProgress[pageInternalIndex] = progress;
	}

	/// <summary>
	/// 获取所有书页的研读进度
	/// </summary>
	public sbyte[] GetAllBookPageReadingProgress()
	{
		return _readingProgress;
	}
}
