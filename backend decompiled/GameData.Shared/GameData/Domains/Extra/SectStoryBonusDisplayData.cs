using System.Collections.Generic;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

[SerializableGameData(NotForArchive = true)]
public class SectStoryBonusDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public short CombatSkillId;

	[SerializableGameDataField]
	public List<short> BreakBonusTemplateIds;

	[SerializableGameDataField]
	public SkillBreakBonusCollection ExtraBonus;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((BreakBonusTemplateIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * BreakBonusTemplateIds.Count)));
		totalSize = ((ExtraBonus == null) ? (totalSize + 2) : (totalSize + (2 + ExtraBonus.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = CombatSkillId;
		pCurrData += 2;
		if (BreakBonusTemplateIds != null)
		{
			int elementsCount = BreakBonusTemplateIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = BreakBonusTemplateIds[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ExtraBonus != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ExtraBonus.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
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
		CombatSkillId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (BreakBonusTemplateIds == null)
			{
				BreakBonusTemplateIds = new List<short>(elementsCount);
			}
			else
			{
				BreakBonusTemplateIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				BreakBonusTemplateIds.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			BreakBonusTemplateIds?.Clear();
		}
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (ExtraBonus == null)
			{
				ExtraBonus = new SkillBreakBonusCollection();
			}
			pCurrData += ExtraBonus.Deserialize(pCurrData);
		}
		else
		{
			ExtraBonus = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
