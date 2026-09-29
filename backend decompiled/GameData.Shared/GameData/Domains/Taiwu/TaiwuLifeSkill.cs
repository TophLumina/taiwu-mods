using GameData.Domains.CombatSkill;
using GameData.Serializer;

namespace GameData.Domains.Taiwu;

public class TaiwuLifeSkill : ISerializableGameData, ITaiwuSkill
{
	private readonly sbyte[] _readingProgress;

	public TaiwuLifeSkill()
	{
		_readingProgress = new sbyte[5];
	}

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

	public sbyte GetBookPageReadingProgress(byte index)
	{
		return _readingProgress[index];
	}

	public void SetBookPageReadingProgress(byte index, sbyte progress)
	{
		_readingProgress[index] = progress;
	}

	public sbyte[] GetAllBookPageReadingProgress()
	{
		return _readingProgress;
	}
}
