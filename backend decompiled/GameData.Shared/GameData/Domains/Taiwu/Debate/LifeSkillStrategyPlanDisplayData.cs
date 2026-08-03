using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 较艺策略选择方案集合
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class LifeSkillStrategyPlanDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte SelectedLifeSkillStrategyPlanIndex;

	[SerializableGameDataField]
	public Dictionary<int, ShortList> LifeSkillStrategyPlans;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 1;
		totalSize += 4;
		if (LifeSkillStrategyPlans != null)
		{
			foreach (KeyValuePair<int, ShortList> pair in LifeSkillStrategyPlans)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
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
		*pCurrData = (byte)SelectedLifeSkillStrategyPlanIndex;
		pCurrData++;
		if (LifeSkillStrategyPlans != null)
		{
			*(int*)pCurrData = LifeSkillStrategyPlans.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, ShortList> pair in LifeSkillStrategyPlans)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
		SelectedLifeSkillStrategyPlanIndex = (sbyte)(*pCurrData);
		pCurrData++;
		int LifeSkillStrategyPlansElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (LifeSkillStrategyPlansElementsCount > 0)
		{
			if (LifeSkillStrategyPlans == null)
			{
				LifeSkillStrategyPlans = new Dictionary<int, ShortList>();
			}
			else
			{
				LifeSkillStrategyPlans.Clear();
			}
			for (int i = 0; i < LifeSkillStrategyPlansElementsCount; i++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				ShortList value = default(ShortList);
				pCurrData += value.Deserialize(pCurrData);
				LifeSkillStrategyPlans.Add(key, value);
			}
		}
		else
		{
			LifeSkillStrategyPlans?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
