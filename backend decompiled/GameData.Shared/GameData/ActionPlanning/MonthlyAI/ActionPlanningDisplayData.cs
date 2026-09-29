using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.ActionPlanning.MonthlyAI;

[SerializableGameData(NotForArchive = true)]
public class ActionPlanningDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<CharacterGoalDisplayData> Goals;

	[SerializableGameDataField]
	public CharacterMissionDisplayData[] Missions = new CharacterMissionDisplayData[4];

	[SerializableGameDataField]
	public sbyte BehaviorType;

	public ActionPlanningDisplayData()
	{
	}

	public ActionPlanningDisplayData(ActionPlanningDisplayData other)
	{
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
		CharacterMissionDisplayData[] item2 = other.Missions;
		int elementsCount2 = item2.Length;
		Missions = new CharacterMissionDisplayData[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			Missions[j] = new CharacterMissionDisplayData(item2[j]);
		}
		BehaviorType = other.BehaviorType;
	}

	public void Assign(ActionPlanningDisplayData other)
	{
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
		CharacterMissionDisplayData[] item2 = other.Missions;
		int elementsCount2 = item2.Length;
		Missions = new CharacterMissionDisplayData[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			Missions[j] = new CharacterMissionDisplayData(item2[j]);
		}
		BehaviorType = other.BehaviorType;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 1;
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
		if (Missions != null)
		{
			totalSize += 2;
			int elementsCount2 = Missions.Length;
			for (int j = 0; j < elementsCount2; j++)
			{
				CharacterMissionDisplayData element2 = Missions[j];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + element2.GetSerializedSize())));
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
		if (Missions != null)
		{
			int elementsCount2 = Missions.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				CharacterMissionDisplayData element2 = Missions[j];
				if (element2 != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int subDataSize2 = element2.Serialize(pCurrData);
					pCurrData += subDataSize2;
					Tester.Assert(subDataSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)subDataSize2;
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
		*pCurrData = (byte)BehaviorType;
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
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (Missions == null || Missions.Length != elementsCount2)
			{
				Missions = new CharacterMissionDisplayData[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num2 > 0)
				{
					CharacterMissionDisplayData element2 = Missions[j] ?? new CharacterMissionDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
					Missions[j] = element2;
				}
				else
				{
					Missions[j] = null;
				}
			}
		}
		else
		{
			Missions = null;
		}
		BehaviorType = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
