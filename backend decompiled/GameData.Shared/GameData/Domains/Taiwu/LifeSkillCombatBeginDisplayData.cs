using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class LifeSkillCombatBeginDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<int> UnlockedCountList;

	[SerializableGameDataField]
	public LifeSkillShorts SelfAttainments;

	[SerializableGameDataField]
	public LifeSkillShorts EnemyAttainments;

	[SerializableGameDataField]
	public short LoopingNeigongId;

	[SerializableGameDataField]
	public ItemKey CurReadingBook;

	[SerializableGameDataField]
	public sbyte CurReadingBookProgress;

	[SerializableGameDataField]
	public sbyte TotalReadInLifeSkillCombatCount;

	[SerializableGameDataField]
	public sbyte ReadInLifeSkillCombatCount;

	[SerializableGameDataField]
	public sbyte ReadInCombatCount;

	[SerializableGameDataField]
	public sbyte TotalLoopInLifeSkillCombatCount;

	[SerializableGameDataField]
	public sbyte LoopInLifeSkillCombatCount;

	[SerializableGameDataField]
	public sbyte LoopInCombatCount;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 81;
		totalSize = ((UnlockedCountList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * UnlockedCountList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (UnlockedCountList != null)
		{
			int elementsCount = UnlockedCountList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(int*)pCurrData = UnlockedCountList[i];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SelfAttainments.Serialize(pCurrData);
		pCurrData += EnemyAttainments.Serialize(pCurrData);
		*(short*)pCurrData = LoopingNeigongId;
		pCurrData += 2;
		pCurrData += CurReadingBook.Serialize(pCurrData);
		*pCurrData = (byte)CurReadingBookProgress;
		pCurrData++;
		*pCurrData = (byte)TotalReadInLifeSkillCombatCount;
		pCurrData++;
		*pCurrData = (byte)ReadInLifeSkillCombatCount;
		pCurrData++;
		*pCurrData = (byte)ReadInCombatCount;
		pCurrData++;
		*pCurrData = (byte)TotalLoopInLifeSkillCombatCount;
		pCurrData++;
		*pCurrData = (byte)LoopInLifeSkillCombatCount;
		pCurrData++;
		*pCurrData = (byte)LoopInCombatCount;
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
			if (UnlockedCountList == null)
			{
				UnlockedCountList = new List<int>();
			}
			else
			{
				UnlockedCountList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int element = *(int*)pCurrData;
				pCurrData += 4;
				UnlockedCountList.Add(element);
			}
		}
		else
		{
			UnlockedCountList?.Clear();
		}
		pCurrData += SelfAttainments.Deserialize(pCurrData);
		pCurrData += EnemyAttainments.Deserialize(pCurrData);
		LoopingNeigongId = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += CurReadingBook.Deserialize(pCurrData);
		CurReadingBookProgress = (sbyte)(*pCurrData);
		pCurrData++;
		TotalReadInLifeSkillCombatCount = (sbyte)(*pCurrData);
		pCurrData++;
		ReadInLifeSkillCombatCount = (sbyte)(*pCurrData);
		pCurrData++;
		ReadInCombatCount = (sbyte)(*pCurrData);
		pCurrData++;
		TotalLoopInLifeSkillCombatCount = (sbyte)(*pCurrData);
		pCurrData++;
		LoopInLifeSkillCombatCount = (sbyte)(*pCurrData);
		pCurrData++;
		LoopInCombatCount = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
