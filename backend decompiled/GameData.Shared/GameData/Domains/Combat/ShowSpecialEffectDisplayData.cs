using Config;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public struct ShowSpecialEffectDisplayData : ISerializableGameData
{
	public static readonly ShowSpecialEffectDisplayData Invalid = new ShowSpecialEffectDisplayData
	{
		Index = -1,
		ItemData = ItemKey.Invalid,
		EffectDescription = CombatSkillEffectDescriptionDisplayData.Invalid
	};

	[SerializableGameDataField]
	public int Index;

	[SerializableGameDataField]
	public int EffectId;

	[SerializableGameDataField]
	public ItemKey ItemData;

	[SerializableGameDataField]
	public CombatSkillEffectDescriptionDisplayData EffectDescription;

	public static int CheckIndex(int effectId, byte index)
	{
		if (Config.SpecialEffect.Instance[effectId].ShortDesc.Length <= index)
		{
			return -1;
		}
		return index;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 16;
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
		*(int*)pCurrData = Index;
		pCurrData += 4;
		*(int*)pCurrData = EffectId;
		pCurrData += 4;
		pCurrData += ItemData.Serialize(pCurrData);
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
		Index = *(int*)pCurrData;
		pCurrData += 4;
		EffectId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += ItemData.Deserialize(pCurrData);
		pCurrData += EffectDescription.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
