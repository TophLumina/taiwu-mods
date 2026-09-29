using System;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteTravelingTaoistMonkSkillsData : IProfessionSkillsData, ISerializableGameData
{
	[SerializableGameDataField]
	public short BonusMaxHealth;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = BonusMaxHealth;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		BonusMaxHealth = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public void Initialize()
	{
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}
}
