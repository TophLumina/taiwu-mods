using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Mission;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true, NotForDisplayModule = true)]
public class CharacterMissionData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort MissionTemplateId = 0;

		public const ushort EndDate = 1;

		public const ushort Goals = 2;

		public const ushort StartDate = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "MissionTemplateId", "EndDate", "Goals", "StartDate" };
	}

	[SerializableGameDataField]
	public int MissionTemplateId = -1;

	[SerializableGameDataField]
	public int StartDate = int.MinValue;

	[SerializableGameDataField]
	public int EndDate = int.MinValue;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<CharacterGoalData> Goals = new List<CharacterGoalData>();

	public CharacterMissionItem Template => CharacterMission.Instance[MissionTemplateId];

	public bool InKeepDuration => EndDate != int.MinValue;

	public bool IsComplete
	{
		get
		{
			List<CharacterGoalData> goals = Goals;
			if (goals == null || goals.Count <= 0)
			{
				return true;
			}
			foreach (CharacterGoalData goal in Goals)
			{
				if (goal.State != CharacterGoalData.EGoalState.Achieved)
				{
					return false;
				}
			}
			return true;
		}
	}

	public bool IsTimeout => StartDate + Template.Duration <= DomainManager.World.GetCurrDate();

	public bool CanRemove => EndDate + Template.KeepDuration <= DomainManager.World.GetCurrDate();

	public void Initialize(int missionTemplateId, int currDate)
	{
		MissionTemplateId = missionTemplateId;
		Goals.Clear();
		StartDate = currDate;
		EndDate = int.MinValue;
		if (missionTemplateId < 0)
		{
			return;
		}
		int[] goals = Template.Goals;
		if (goals == null || goals.Length <= 0)
		{
			return;
		}
		int[] goals2 = Template.Goals;
		foreach (int goalTemplateId in goals2)
		{
			CharacterGoalData goal = new CharacterGoalData(goalTemplateId, currDate);
			if (goal.CheckParameters())
			{
				Goals.Add(goal);
			}
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 14;
		if (Goals != null)
		{
			totalSize += 2;
			int elementsCount = Goals.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterGoalData element = Goals[i];
				totalSize = ((element == null) ? (totalSize + 4) : (totalSize + (4 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 4;
		pCurrData += 2;
		*(int*)pCurrData = MissionTemplateId;
		pCurrData += 4;
		*(int*)pCurrData = EndDate;
		pCurrData += 4;
		if (Goals != null)
		{
			int elementsCount = Goals.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterGoalData element = Goals[i];
				if (element != null)
				{
					byte* pSubDataCount = pCurrData;
					pCurrData += 4;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= int.MaxValue);
					*(int*)pSubDataCount = subDataSize;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = StartDate;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			MissionTemplateId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			EndDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (Goals == null)
				{
					Goals = new List<CharacterGoalData>(elementsCount);
				}
				else
				{
					Goals.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					int subDataCount = *(int*)pCurrData;
					pCurrData += 4;
					if (subDataCount > 0)
					{
						CharacterGoalData element = new CharacterGoalData();
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
		}
		if (fieldCount > 3)
		{
			StartDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
