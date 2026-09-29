using GameData.Domains.Character;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData]
public struct SamsaraPlatformBonusAttributes : ISerializableGameData
{
	[SerializableGameDataField]
	public MainAttributes MainAttributes;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillShorts;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillShorts;

	public override string ToString()
	{
		return $"MainAttributes 0:{MainAttributes[0]} 1:{MainAttributes[1]} 2:{MainAttributes[2]} 3:{MainAttributes[3]} 4:{MainAttributes[4]} 5:{MainAttributes[5]}\nCombatSkillShorts 0:{CombatSkillShorts[0]} 1:{CombatSkillShorts[1]} 2:{CombatSkillShorts[2]} 3:{CombatSkillShorts[3]} 4:{CombatSkillShorts[4]} 5:{CombatSkillShorts[5]} 6:{CombatSkillShorts[6]} 7:{CombatSkillShorts[7]} 8:{CombatSkillShorts[8]} 9:{CombatSkillShorts[9]} 10:{CombatSkillShorts[10]} 11:{CombatSkillShorts[11]} 12:{CombatSkillShorts[12]} 13:{CombatSkillShorts[13]}\nLifeSkillShorts 0:{LifeSkillShorts[0]} 1:{LifeSkillShorts[1]} 2:{LifeSkillShorts[2]} 3:{LifeSkillShorts[3]} 4:{LifeSkillShorts[4]} 5:{LifeSkillShorts[5]} 6:{LifeSkillShorts[6]} 7:{LifeSkillShorts[7]} 8:{LifeSkillShorts[8]} 9:{LifeSkillShorts[9]} 10:{LifeSkillShorts[10]} 11:{LifeSkillShorts[11]} 12:{LifeSkillShorts[12]} 13:{LifeSkillShorts[13]} 14:{LifeSkillShorts[14]} 15:{LifeSkillShorts[15]}";
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 72;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += MainAttributes.Serialize(pCurrData);
		pCurrData += CombatSkillShorts.Serialize(pCurrData);
		pCurrData += LifeSkillShorts.Serialize(pCurrData);
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
		pCurrData += MainAttributes.Deserialize(pCurrData);
		pCurrData += CombatSkillShorts.Deserialize(pCurrData);
		pCurrData += LifeSkillShorts.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
