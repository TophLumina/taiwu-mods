using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public struct WeaponEffectDisplayData(WeaponEffectDisplayData other) : ISerializableGameData
{
	[SerializableGameDataField]
	public SkillEffectKey EffectKey = other.EffectKey;

	[SerializableGameDataField]
	public CombatSkillEffectDescriptionDisplayData EffectDescription = new CombatSkillEffectDescriptionDisplayData(other.EffectDescription);

	public void Assign(WeaponEffectDisplayData other)
	{
		EffectKey = other.EffectKey;
		EffectDescription = new CombatSkillEffectDescriptionDisplayData(other.EffectDescription);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize += EffectDescription.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += EffectKey.Serialize(pCurrData);
		int fieldSize = EffectDescription.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
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
		pCurrData += EffectKey.Deserialize(pCurrData);
		pCurrData += EffectDescription.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
