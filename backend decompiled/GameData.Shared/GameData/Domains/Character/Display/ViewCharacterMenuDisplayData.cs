using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class ViewCharacterMenuDisplayData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort CharacterDisplayDataList = 0;

		public const ushort IsTaiwuTeam = 1;

		public const ushort TaiwuTeamCharIds = 2;

		public const ushort TaiwuSpecialGroup = 3;

		public const ushort TaiwuGearMateGroup = 4;

		public const ushort NoNameInfantCharIds = 5;

		public const ushort TaiwuGroupMaxDisplayCount = 6;

		public const ushort GroupLeaderId = 7;

		public const ushort TaiwuCombatSpecialGroup = 8;

		public const ushort Count = 9;

		public static readonly string[] FieldId2FieldName = new string[9] { "CharacterDisplayDataList", "IsTaiwuTeam", "TaiwuTeamCharIds", "TaiwuSpecialGroup", "TaiwuGearMateGroup", "NoNameInfantCharIds", "TaiwuGroupMaxDisplayCount", "GroupLeaderId", "TaiwuCombatSpecialGroup" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public List<CharacterDisplayData> CharacterDisplayDataList;

	[SerializableGameDataField(FieldIndex = 1)]
	public bool IsTaiwuTeam;

	[SerializableGameDataField(FieldIndex = 2)]
	public List<int> TaiwuTeamCharIds;

	[SerializableGameDataField(FieldIndex = 3)]
	public List<int> TaiwuSpecialGroup;

	[SerializableGameDataField(FieldIndex = 4)]
	public List<int> TaiwuGearMateGroup;

	[SerializableGameDataField(FieldIndex = 8)]
	public List<int> TaiwuCombatSpecialGroup;

	[SerializableGameDataField(FieldIndex = 5)]
	public List<int> NoNameInfantCharIds;

	[SerializableGameDataField(FieldIndex = 6)]
	public int TaiwuGroupMaxDisplayCount;

	[SerializableGameDataField(FieldIndex = 7)]
	public int GroupLeaderId;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		if (CharacterDisplayDataList != null)
		{
			totalSize += 2;
			for (int i = 0; i < CharacterDisplayDataList.Count; i++)
			{
				totalSize = ((CharacterDisplayDataList[i] == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayDataList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((TaiwuTeamCharIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * TaiwuTeamCharIds.Count)));
		totalSize = ((TaiwuSpecialGroup == null) ? (totalSize + 2) : (totalSize + (2 + 4 * TaiwuSpecialGroup.Count)));
		totalSize = ((TaiwuGearMateGroup == null) ? (totalSize + 2) : (totalSize + (2 + 4 * TaiwuGearMateGroup.Count)));
		totalSize = ((NoNameInfantCharIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * NoNameInfantCharIds.Count)));
		totalSize = ((TaiwuCombatSpecialGroup == null) ? (totalSize + 2) : (totalSize + (2 + 4 * TaiwuCombatSpecialGroup.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 9;
		pCurrData += 2;
		if (CharacterDisplayDataList != null)
		{
			int elementsCount = CharacterDisplayDataList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (CharacterDisplayDataList[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = CharacterDisplayDataList[i].Serialize(pCurrData);
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
		*pCurrData = (IsTaiwuTeam ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (TaiwuTeamCharIds != null)
		{
			int elementsCount2 = TaiwuTeamCharIds.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(int*)pCurrData = TaiwuTeamCharIds[j];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuSpecialGroup != null)
		{
			int elementsCount3 = TaiwuSpecialGroup.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				*(int*)pCurrData = TaiwuSpecialGroup[k];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuGearMateGroup != null)
		{
			int elementsCount4 = TaiwuGearMateGroup.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				*(int*)pCurrData = TaiwuGearMateGroup[l];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (NoNameInfantCharIds != null)
		{
			int elementsCount5 = NoNameInfantCharIds.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				*(int*)pCurrData = NoNameInfantCharIds[m];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = TaiwuGroupMaxDisplayCount;
		pCurrData += 4;
		*(int*)pCurrData = GroupLeaderId;
		pCurrData += 4;
		if (TaiwuCombatSpecialGroup != null)
		{
			int elementsCount6 = TaiwuCombatSpecialGroup.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				*(int*)pCurrData = TaiwuCombatSpecialGroup[n];
				pCurrData += 4;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (CharacterDisplayDataList == null)
				{
					CharacterDisplayDataList = new List<CharacterDisplayData>();
				}
				else
				{
					CharacterDisplayDataList.Clear();
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
					CharacterDisplayDataList.Add(element);
				}
			}
			else
			{
				CharacterDisplayDataList?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			IsTaiwuTeam = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (TaiwuTeamCharIds == null)
				{
					TaiwuTeamCharIds = new List<int>();
				}
				else
				{
					TaiwuTeamCharIds.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					int element2 = *(int*)pCurrData;
					pCurrData += 4;
					TaiwuTeamCharIds.Add(element2);
				}
			}
			else
			{
				TaiwuTeamCharIds?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (TaiwuSpecialGroup == null)
				{
					TaiwuSpecialGroup = new List<int>();
				}
				else
				{
					TaiwuSpecialGroup.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					int element3 = *(int*)pCurrData;
					pCurrData += 4;
					TaiwuSpecialGroup.Add(element3);
				}
			}
			else
			{
				TaiwuSpecialGroup?.Clear();
			}
		}
		if (fieldCount > 4)
		{
			ushort elementsCount4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount4 > 0)
			{
				if (TaiwuGearMateGroup == null)
				{
					TaiwuGearMateGroup = new List<int>();
				}
				else
				{
					TaiwuGearMateGroup.Clear();
				}
				for (int l = 0; l < elementsCount4; l++)
				{
					int element4 = *(int*)pCurrData;
					pCurrData += 4;
					TaiwuGearMateGroup.Add(element4);
				}
			}
			else
			{
				TaiwuGearMateGroup?.Clear();
			}
		}
		if (fieldCount > 5)
		{
			ushort elementsCount5 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount5 > 0)
			{
				if (NoNameInfantCharIds == null)
				{
					NoNameInfantCharIds = new List<int>();
				}
				else
				{
					NoNameInfantCharIds.Clear();
				}
				for (int m = 0; m < elementsCount5; m++)
				{
					int element5 = *(int*)pCurrData;
					pCurrData += 4;
					NoNameInfantCharIds.Add(element5);
				}
			}
			else
			{
				NoNameInfantCharIds?.Clear();
			}
		}
		if (fieldCount > 6)
		{
			TaiwuGroupMaxDisplayCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 7)
		{
			GroupLeaderId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 8)
		{
			ushort elementsCount6 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount6 > 0)
			{
				if (TaiwuCombatSpecialGroup == null)
				{
					TaiwuCombatSpecialGroup = new List<int>();
				}
				else
				{
					TaiwuCombatSpecialGroup.Clear();
				}
				for (int n = 0; n < elementsCount6; n++)
				{
					int element6 = *(int*)pCurrData;
					pCurrData += 4;
					TaiwuCombatSpecialGroup.Add(element6);
				}
			}
			else
			{
				TaiwuCombatSpecialGroup?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
