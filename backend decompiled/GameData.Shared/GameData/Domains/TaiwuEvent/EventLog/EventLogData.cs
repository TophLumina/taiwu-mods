using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.TaiwuEvent.EventLog;

/// <summary>
/// 事件记录数据
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class EventLogData : ISerializableGameData
{
	/// <summary>
	/// 所有事件记录需要用到的角色列表
	/// </summary>
	[SerializableGameDataField]
	public List<CharacterDisplayData> CharacterList;

	/// <summary>
	/// 所有事件记录需要用到的秘闻列表
	/// </summary>
	[SerializableGameDataField]
	public List<SecretInformationDisplayData> SecretInformationList;

	/// <summary>
	/// 所有事件记录需要用到的物品列表
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> ItemList;

	/// <summary>
	/// 所有事件记录需要用到的功法列表
	/// </summary>
	[SerializableGameDataField]
	public List<CombatSkillDisplayData> CombatSkillList;

	/// <summary>
	/// 所有事件记录的列表
	/// </summary>
	[SerializableGameDataField]
	public List<EventLogResultData> ResultList;

	public EventLogData()
	{
		ResultList = new List<EventLogResultData>();
		SecretInformationList = new List<SecretInformationDisplayData>();
		ItemList = new List<ItemDisplayData>();
		CombatSkillList = new List<CombatSkillDisplayData>();
	}

	public EventLogData(List<CharacterDisplayData> characterList, List<EventLogResultData> resultList, List<SecretInformationDisplayData> secretInformationList, List<ItemDisplayData> itemList, List<CombatSkillDisplayData> combatSkillList)
	{
		ResultList = resultList;
		SecretInformationList = secretInformationList;
		ItemList = itemList;
		CombatSkillList = combatSkillList;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (CharacterList != null)
		{
			totalSize += 2;
			for (int i = 0; i < CharacterList.Count; i++)
			{
				totalSize = ((CharacterList[i] == null) ? (totalSize + 2) : (totalSize + (2 + CharacterList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (SecretInformationList != null)
		{
			totalSize += 2;
			for (int j = 0; j < SecretInformationList.Count; j++)
			{
				totalSize = ((SecretInformationList[j] == null) ? (totalSize + 2) : (totalSize + (2 + SecretInformationList[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (ItemList != null)
		{
			totalSize += 2;
			for (int k = 0; k < ItemList.Count; k++)
			{
				totalSize = ((ItemList[k] == null) ? (totalSize + 2) : (totalSize + (2 + ItemList[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (CombatSkillList != null)
		{
			totalSize += 2;
			for (int l = 0; l < CombatSkillList.Count; l++)
			{
				totalSize = ((CombatSkillList[l] == null) ? (totalSize + 2) : (totalSize + (2 + CombatSkillList[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (ResultList != null)
		{
			totalSize += 2;
			for (int m = 0; m < ResultList.Count; m++)
			{
				totalSize = ((ResultList[m] == null) ? (totalSize + 2) : (totalSize + (2 + ResultList[m].GetSerializedSize())));
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
		if (CharacterList != null)
		{
			int elementsCount = CharacterList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (CharacterList[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = CharacterList[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
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
		if (SecretInformationList != null)
		{
			int elementsCount2 = SecretInformationList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (SecretInformationList[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = SecretInformationList[j].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize2;
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
		if (ItemList != null)
		{
			int elementsCount3 = ItemList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (ItemList[k] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = ItemList[k].Serialize(pCurrData);
					pCurrData += fieldSize3;
					Tester.Assert(fieldSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)fieldSize3;
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
		if (CombatSkillList != null)
		{
			int elementsCount4 = CombatSkillList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (CombatSkillList[l] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int fieldSize4 = CombatSkillList[l].Serialize(pCurrData);
					pCurrData += fieldSize4;
					Tester.Assert(fieldSize4 <= 65535);
					*(ushort*)intPtr4 = (ushort)fieldSize4;
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
		if (ResultList != null)
		{
			int elementsCount5 = ResultList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				if (ResultList[m] != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 2;
					int fieldSize5 = ResultList[m].Serialize(pCurrData);
					pCurrData += fieldSize5;
					Tester.Assert(fieldSize5 <= 65535);
					*(ushort*)intPtr5 = (ushort)fieldSize5;
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
			if (CharacterList == null)
			{
				CharacterList = new List<CharacterDisplayData>();
			}
			else
			{
				CharacterList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterDisplayData element;
				if (num > 0)
				{
					element = new CharacterDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				CharacterList.Add(element);
			}
		}
		else
		{
			CharacterList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (SecretInformationList == null)
			{
				SecretInformationList = new List<SecretInformationDisplayData>();
			}
			else
			{
				SecretInformationList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				SecretInformationDisplayData element2;
				if (num2 > 0)
				{
					element2 = new SecretInformationDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				SecretInformationList.Add(element2);
			}
		}
		else
		{
			SecretInformationList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (ItemList == null)
			{
				ItemList = new List<ItemDisplayData>();
			}
			else
			{
				ItemList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element3;
				if (num3 > 0)
				{
					element3 = new ItemDisplayData();
					pCurrData += element3.Deserialize(pCurrData);
				}
				else
				{
					element3 = null;
				}
				ItemList.Add(element3);
			}
		}
		else
		{
			ItemList?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (CombatSkillList == null)
			{
				CombatSkillList = new List<CombatSkillDisplayData>();
			}
			else
			{
				CombatSkillList.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				ushort num4 = *(ushort*)pCurrData;
				pCurrData += 2;
				CombatSkillDisplayData element4;
				if (num4 > 0)
				{
					element4 = new CombatSkillDisplayData();
					pCurrData += element4.Deserialize(pCurrData);
				}
				else
				{
					element4 = null;
				}
				CombatSkillList.Add(element4);
			}
		}
		else
		{
			CombatSkillList?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (ResultList == null)
			{
				ResultList = new List<EventLogResultData>();
			}
			else
			{
				ResultList.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				ushort num5 = *(ushort*)pCurrData;
				pCurrData += 2;
				EventLogResultData element5;
				if (num5 > 0)
				{
					element5 = new EventLogResultData();
					pCurrData += element5.Deserialize(pCurrData);
				}
				else
				{
					element5 = null;
				}
				ResultList.Add(element5);
			}
		}
		else
		{
			ResultList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
