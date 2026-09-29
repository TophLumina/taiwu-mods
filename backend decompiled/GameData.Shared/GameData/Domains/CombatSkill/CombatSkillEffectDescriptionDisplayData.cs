using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.CombatSkill;

[SerializableGameData(NotForArchive = true)]
public struct CombatSkillEffectDescriptionDisplayData(CombatSkillEffectDescriptionDisplayData other) : ISerializableGameData
{
	public static readonly CombatSkillEffectDescriptionDisplayData Invalid = new CombatSkillEffectDescriptionDisplayData
	{
		EffectId = -1,
		AffectRequirePower = null
	};

	[SerializableGameDataField]
	public int EffectId = other.EffectId;

	[SerializableGameDataField]
	public List<int> AffectRequirePower = ((other.AffectRequirePower != null) ? new List<int>(other.AffectRequirePower) : null);

	public void Assign(CombatSkillEffectDescriptionDisplayData other)
	{
		EffectId = other.EffectId;
		AffectRequirePower = ((other.AffectRequirePower != null) ? new List<int>(other.AffectRequirePower) : null);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((AffectRequirePower == null) ? (totalSize + 2) : (totalSize + (2 + 4 * AffectRequirePower.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = EffectId;
		pCurrData += 4;
		if (AffectRequirePower != null)
		{
			int elementsCount = AffectRequirePower.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = AffectRequirePower[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		EffectId = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (AffectRequirePower == null)
			{
				AffectRequirePower = new List<int>(elementsCount);
			}
			else
			{
				AffectRequirePower.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				AffectRequirePower.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			AffectRequirePower?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
