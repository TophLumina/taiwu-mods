using System;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteTaoistMonkSkillsData : IProfessionSkillsData, ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte SurvivedTribulationCount;

	public void Initialize()
	{
		SurvivedTribulationCount = 0;
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}

	public bool HasSurvivedAllTribulation()
	{
		return SurvivedTribulationCount >= 4;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 1;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)SurvivedTribulationCount;
		int totalSize = (int)(pData + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		SurvivedTribulationCount = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
