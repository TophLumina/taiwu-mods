using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.ActionPlanning.MonthlyAI;

[SerializableGameData(NotForArchive = true)]
public class CharacterMissionDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int MissionTemplateId = -1;

	[SerializableGameDataField]
	public int EndDate = int.MinValue;

	[SerializableGameDataField]
	public int RemainMonth = int.MinValue;

	[SerializableGameDataField]
	public int RemainLingeringMonth = int.MinValue;

	[SerializableGameDataField]
	public List<CharacterGoalDisplayData> Goals = new List<CharacterGoalDisplayData>();

	[SerializableGameDataField]
	public bool IsComplete;

	[SerializableGameDataField]
	public bool IsTimeout;

	public CharacterMissionDisplayData()
	{
	}

	public CharacterMissionDisplayData(CharacterMissionDisplayData other)
	{
		MissionTemplateId = other.MissionTemplateId;
		EndDate = other.EndDate;
		RemainMonth = other.RemainMonth;
		RemainLingeringMonth = other.RemainLingeringMonth;
		if (other.Goals != null)
		{
			List<CharacterGoalDisplayData> item = other.Goals;
			int elementsCount = item.Count;
			Goals = new List<CharacterGoalDisplayData>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				Goals.Add(new CharacterGoalDisplayData(item[i]));
			}
		}
		else
		{
			Goals = null;
		}
		IsComplete = other.IsComplete;
		IsTimeout = other.IsTimeout;
	}

	public void Assign(CharacterMissionDisplayData other)
	{
		MissionTemplateId = other.MissionTemplateId;
		EndDate = other.EndDate;
		RemainMonth = other.RemainMonth;
		RemainLingeringMonth = other.RemainLingeringMonth;
		if (other.Goals != null)
		{
			List<CharacterGoalDisplayData> item = other.Goals;
			int elementsCount = item.Count;
			Goals = new List<CharacterGoalDisplayData>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				Goals.Add(new CharacterGoalDisplayData(item[i]));
			}
		}
		else
		{
			Goals = null;
		}
		IsComplete = other.IsComplete;
		IsTimeout = other.IsTimeout;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 18;
		if (Goals != null)
		{
			totalSize += 2;
			int elementsCount = Goals.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterGoalDisplayData element = Goals[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = MissionTemplateId;
		pCurrData += 4;
		*(int*)pCurrData = EndDate;
		pCurrData += 4;
		*(int*)pCurrData = RemainMonth;
		pCurrData += 4;
		*(int*)pCurrData = RemainLingeringMonth;
		pCurrData += 4;
		if (Goals != null)
		{
			int elementsCount = Goals.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterGoalDisplayData element = Goals[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsComplete ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsTimeout ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		MissionTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		EndDate = *(int*)pCurrData;
		pCurrData += 4;
		RemainMonth = *(int*)pCurrData;
		pCurrData += 4;
		RemainLingeringMonth = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Goals == null)
			{
				Goals = new List<CharacterGoalDisplayData>(elementsCount);
			}
			else
			{
				Goals.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					CharacterGoalDisplayData element = new CharacterGoalDisplayData();
					pCurrData += element.Deserialize(pCurrData);
					Goals.Add(element);
				}
				else
				{
					Goals.Add(null);
				}
			}
		}
		else
		{
			Goals?.Clear();
		}
		IsComplete = *pCurrData != 0;
		pCurrData++;
		IsTimeout = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
