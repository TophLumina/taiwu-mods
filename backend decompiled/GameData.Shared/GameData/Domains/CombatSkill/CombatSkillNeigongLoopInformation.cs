using System.Collections.Generic;
using GameData.Domains.Taiwu.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.CombatSkill;

[SerializableGameData(NotForArchive = true)]
public class CombatSkillNeigongLoopInformation : ISerializableGameData
{
	[SerializableGameDataField]
	public List<short> ReferenceSkillList;

	[SerializableGameDataField]
	public IntList ExtraNeiliAllocationProgress;

	[SerializableGameDataField]
	public List<QiArtStrategyDisplayData> TaiwuQiArtStrategyList;

	[SerializableGameDataField]
	public (int, int) ExtraNeiliTotalRange;

	[SerializableGameDataField]
	public IntList ExtraNeiliAllocationTotal;

	public CombatSkillNeigongLoopInformation()
	{
	}

	public CombatSkillNeigongLoopInformation(CombatSkillNeigongLoopInformation other)
	{
		ReferenceSkillList = ((other.ReferenceSkillList == null) ? null : new List<short>(other.ReferenceSkillList));
		ExtraNeiliAllocationProgress = new IntList(other.ExtraNeiliAllocationProgress);
		if (other.TaiwuQiArtStrategyList != null)
		{
			List<QiArtStrategyDisplayData> item = other.TaiwuQiArtStrategyList;
			int elementsCount = item.Count;
			TaiwuQiArtStrategyList = new List<QiArtStrategyDisplayData>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				TaiwuQiArtStrategyList.Add(new QiArtStrategyDisplayData(item[i]));
			}
		}
		else
		{
			TaiwuQiArtStrategyList = null;
		}
		ExtraNeiliTotalRange = other.ExtraNeiliTotalRange;
		ExtraNeiliAllocationTotal = new IntList(other.ExtraNeiliAllocationTotal);
	}

	public void Assign(CombatSkillNeigongLoopInformation other)
	{
		ReferenceSkillList = ((other.ReferenceSkillList == null) ? null : new List<short>(other.ReferenceSkillList));
		ExtraNeiliAllocationProgress = new IntList(other.ExtraNeiliAllocationProgress);
		if (other.TaiwuQiArtStrategyList != null)
		{
			List<QiArtStrategyDisplayData> item = other.TaiwuQiArtStrategyList;
			int elementsCount = item.Count;
			TaiwuQiArtStrategyList = new List<QiArtStrategyDisplayData>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				TaiwuQiArtStrategyList.Add(new QiArtStrategyDisplayData(item[i]));
			}
		}
		else
		{
			TaiwuQiArtStrategyList = null;
		}
		ExtraNeiliTotalRange = other.ExtraNeiliTotalRange;
		ExtraNeiliAllocationTotal = new IntList(other.ExtraNeiliAllocationTotal);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize = ((ReferenceSkillList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ReferenceSkillList.Count)));
		totalSize += ExtraNeiliAllocationProgress.GetSerializedSize();
		totalSize = ((TaiwuQiArtStrategyList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * TaiwuQiArtStrategyList.Count)));
		totalSize += ExtraNeiliAllocationTotal.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (ReferenceSkillList != null)
		{
			int elementsCount = ReferenceSkillList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = ReferenceSkillList[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int fieldSize = ExtraNeiliAllocationProgress.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		if (TaiwuQiArtStrategyList != null)
		{
			int elementsCount2 = TaiwuQiArtStrategyList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += TaiwuQiArtStrategyList[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.Serialize(pCurrData, ExtraNeiliTotalRange);
		int fieldSize2 = ExtraNeiliAllocationTotal.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
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
			if (ReferenceSkillList == null)
			{
				ReferenceSkillList = new List<short>(elementsCount);
			}
			else
			{
				ReferenceSkillList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ReferenceSkillList.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			ReferenceSkillList?.Clear();
		}
		pCurrData += ExtraNeiliAllocationProgress.Deserialize(pCurrData);
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (TaiwuQiArtStrategyList == null)
			{
				TaiwuQiArtStrategyList = new List<QiArtStrategyDisplayData>(elementsCount2);
			}
			else
			{
				TaiwuQiArtStrategyList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				QiArtStrategyDisplayData element = new QiArtStrategyDisplayData();
				pCurrData += element.Deserialize(pCurrData);
				TaiwuQiArtStrategyList.Add(element);
			}
		}
		else
		{
			TaiwuQiArtStrategyList?.Clear();
		}
		pCurrData += SerializationHelper.Deserialize(pCurrData, out ExtraNeiliTotalRange);
		pCurrData += ExtraNeiliAllocationTotal.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
