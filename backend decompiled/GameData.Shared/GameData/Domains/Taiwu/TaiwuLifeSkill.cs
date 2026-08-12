using GameData.Domains.CombatSkill;
using GameData.Serializer;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 太吾技艺数据中比 NPC 多出的部分
/// </summary>
public class TaiwuLifeSkill : ISerializableGameData, ITaiwuSkill
{
	/// <summary>
	/// 每页的研读进度
	/// </summary>
	private readonly sbyte[] _readingProgress;

	public TaiwuLifeSkill()
	{
		_readingProgress = new sbyte[5];
	}

	/// <summary>
	/// 构造功法对象.
	/// 对于已读的书页, 研读进度会设置为100; 未读书页则设置为 0.
	/// </summary>
	/// <param name="readingState"></param>
	public TaiwuLifeSkill(byte readingState)
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
		return 5;
	}

	public unsafe int Serialize(byte* pData)
	{
		for (int i = 0; i < 5; i++)
		{
			pData[i] = (byte)_readingProgress[i];
		}
		return 5;
	}

	public unsafe int Deserialize(byte* pData)
	{
		for (int i = 0; i < 5; i++)
		{
			_readingProgress[i] = (sbyte)pData[i];
		}
		return 5;
	}

	/// <summary>
	/// 根据研读状态将所有已读书页进度设为满值
	/// </summary>
	public void ApplyBookPageReadingProgress(byte readingState)
	{
		for (byte i = 0; i < 5; i++)
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
	public sbyte GetBookPageReadingProgress(byte index)
	{
		return _readingProgress[index];
	}

	/// <summary>
	/// 设置指定书页的研读进度
	/// </summary>
	public void SetBookPageReadingProgress(byte index, sbyte progress)
	{
		_readingProgress[index] = progress;
	}

	/// <summary>
	/// 获取所有书页的研读进度
	/// </summary>
	public sbyte[] GetAllBookPageReadingProgress()
	{
		return _readingProgress;
	}
}
