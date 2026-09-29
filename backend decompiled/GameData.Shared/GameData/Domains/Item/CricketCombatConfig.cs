using GameData.Serializer;

namespace GameData.Domains.Item;

[SerializableGameData(NotForArchive = true)]
public struct CricketCombatConfig : ISerializableGameData
{
	[SerializableGameDataField]
	public bool OnlyNoInjury = false;

	[SerializableGameDataField]
	public sbyte MinGrade = 0;

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

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
