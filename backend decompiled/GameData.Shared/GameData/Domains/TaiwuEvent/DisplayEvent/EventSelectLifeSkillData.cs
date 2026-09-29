using System.Collections.Generic;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

public class EventSelectLifeSkillData : ISerializableGameData
{
	[SerializableGameDataField]
	public string ResultSaveKey;

	[SerializableGameDataField]
	public string OptionKey;

	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public List<short> CanSelectLifeSkillIdList;

	public int SelectResultIndex;

	public EventSelectLifeSkillData()
	{
	}

	public EventSelectLifeSkillData(EventSelectLifeSkillData other)
	{
		ResultSaveKey = other.ResultSaveKey;
		OptionKey = other.OptionKey;
		CharId = other.CharId;
		CanSelectLifeSkillIdList = new List<short>(other.CanSelectLifeSkillIdList);
	}

	public void Assign(EventSelectLifeSkillData other)
	{
		ResultSaveKey = other.ResultSaveKey;
		OptionKey = other.OptionKey;
		CharId = other.CharId;
		CanSelectLifeSkillIdList = new List<short>(other.CanSelectLifeSkillIdList);
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
		totalSize = ((CanSelectLifeSkillIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CanSelectLifeSkillIdList.Count)));
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
		if (CanSelectLifeSkillIdList != null)
		{
			int elementsCount3 = CanSelectLifeSkillIdList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = CanSelectLifeSkillIdList[k];
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
			if (CanSelectLifeSkillIdList == null)
			{
				CanSelectLifeSkillIdList = new List<short>(elementsCount3);
			}
			else
			{
				CanSelectLifeSkillIdList.Clear();
			}
			for (int i = 0; i < elementsCount3; i++)
			{
				CanSelectLifeSkillIdList.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			CanSelectLifeSkillIdList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
