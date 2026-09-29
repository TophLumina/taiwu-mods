using System.Collections.Generic;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

public class EventSelectCombatSkillData : ISerializableGameData
{
	[SerializableGameDataField]
	public string ResultSaveKey;

	[SerializableGameDataField]
	public string OptionKey;

	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public List<short> CanSelectCombatSkillIdList;

	public int SelectResultIndex;

	public EventSelectCombatSkillData()
	{
	}

	public EventSelectCombatSkillData(EventSelectCombatSkillData other)
	{
		ResultSaveKey = other.ResultSaveKey;
		OptionKey = other.OptionKey;
		CharId = other.CharId;
		CanSelectCombatSkillIdList = new List<short>(other.CanSelectCombatSkillIdList);
	}

	public void Assign(EventSelectCombatSkillData other)
	{
		ResultSaveKey = other.ResultSaveKey;
		OptionKey = other.OptionKey;
		CharId = other.CharId;
		CanSelectCombatSkillIdList = new List<short>(other.CanSelectCombatSkillIdList);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((ResultSaveKey == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ResultSaveKey.Length)));
		totalSize = ((OptionKey == null) ? (totalSize + 2) : (totalSize + (2 + 2 * OptionKey.Length)));
		totalSize = ((CanSelectCombatSkillIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CanSelectCombatSkillIdList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (ResultSaveKey != null)
		{
			int elementsCount = ResultSaveKey.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = ResultSaveKey)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (OptionKey != null)
		{
			int elementsCount2 = OptionKey.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			fixed (char* pChar2 = OptionKey)
			{
				for (int j = 0; j < elementsCount2; j++)
				{
					((short*)pCurrData)[j] = (short)pChar2[j];
				}
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		if (CanSelectCombatSkillIdList != null)
		{
			int elementsCount3 = CanSelectCombatSkillIdList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = CanSelectCombatSkillIdList[k];
			}
			pCurrData += 2 * elementsCount3;
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			ResultSaveKey = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			ResultSaveKey = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			int fieldSize2 = 2 * elementsCount2;
			OptionKey = Encoding.Unicode.GetString(pCurrData, fieldSize2);
			pCurrData += fieldSize2;
		}
		else
		{
			OptionKey = null;
		}
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (CanSelectCombatSkillIdList == null)
			{
				CanSelectCombatSkillIdList = new List<short>(elementsCount3);
			}
			else
			{
				CanSelectCombatSkillIdList.Clear();
			}
			for (int i = 0; i < elementsCount3; i++)
			{
				CanSelectCombatSkillIdList.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			CanSelectCombatSkillIdList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
