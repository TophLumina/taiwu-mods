using GameData.Serializer;

namespace GameData.Domains.Item;

/// <summary>
/// 蛐蛐决斗配置
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct CricketCombatConfig : ISerializableGameData
{
	/// <summary>
	/// 仅限未受伤的蛐蛐
	/// </summary>
	[SerializableGameDataField]
	public bool OnlyNoInjury = false;

	/// <summary>
	/// 最低品级
	/// </summary>
	[SerializableGameDataField]
	public sbyte MinGrade = 0;

	/// <summary>
	/// 最高品级
	/// </summary>
	[SerializableGameDataField]
	public sbyte MaxGrade = 8;

	public CricketCombatConfig()
	{
	}

	public static implicit operator CricketCombatConfig((bool onlyNoInjury, sbyte minGrade, sbyte maxGrade) tp)
	{
		CricketCombatConfig result = new CricketCombatConfig();
		(result.OnlyNoInjury, result.MinGrade, result.MaxGrade) = tp;
		return result;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (OnlyNoInjury ? ((byte)1) : ((byte)0));
		byte* num = pData + 1;
		*num = (byte)MinGrade;
		byte* num2 = num + 1;
		*num2 = (byte)MaxGrade;
		int totalSize = (int)(num2 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		OnlyNoInjury = *pCurrData != 0;
		pCurrData++;
		MinGrade = (sbyte)(*pCurrData);
		pCurrData++;
		MaxGrade = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
