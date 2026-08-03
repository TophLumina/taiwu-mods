using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.World.Display;

/// <summary>
/// 机关人突破功法显示数据
/// </summary>
[AutoGenerateSerializableGameData]
public class SectZhujianGearMateBreakoutDisplayData : ISerializableGameData
{
	/// <summary>
	/// 太吾的技艺造诣
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	/// <summary>
	/// 历练
	/// </summary>
	[SerializableGameDataField]
	public int Exp;

	/// <summary>
	/// 功法显示数据列表
	/// </summary>
	[SerializableGameDataField]
	public List<CombatSkillDisplayData> CombatSkillDisplayDataList;

	/// <summary>
	/// 机关人突破功法禁止原因列表 (功法ID, 禁止原因)
	/// </summary>
	[SerializableGameDataField]
	public List<ShortPair> GearMateBreakoutCombatSkillBanReasonList;

	/// <summary>
	/// 机关人的技艺造诣
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts GearMateLifeSkillAttainments;

	/// <summary>
	/// 机关人功法研读进度 (功法模板ID -&gt; 每页研读进度数组)
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, SByteList> GearMateCombatSkillReadingProgress;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SectZhujianGearMateBreakoutDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SectZhujianGearMateBreakoutDisplayData(SectZhujianGearMateBreakoutDisplayData other)
	{
		LifeSkillAttainments = other.LifeSkillAttainments;
		Exp = other.Exp;
		if (other.CombatSkillDisplayDataList != null)
		{
			List<CombatSkillDisplayData> combatSkillDisplayDataList = other.CombatSkillDisplayDataList;
			int elementsCount = combatSkillDisplayDataList.Count;
			CombatSkillDisplayDataList = new List<CombatSkillDisplayData>(elementsCount);
			foreach (CombatSkillDisplayData element in combatSkillDisplayDataList)
			{
				CombatSkillDisplayDataList.Add(new CombatSkillDisplayData(element));
			}
		}
		else
		{
			CombatSkillDisplayDataList = null;
		}
		GearMateBreakoutCombatSkillBanReasonList = ((other.GearMateBreakoutCombatSkillBanReasonList == null) ? null : new List<ShortPair>(other.GearMateBreakoutCombatSkillBanReasonList));
		GearMateLifeSkillAttainments = other.GearMateLifeSkillAttainments;
		GearMateCombatSkillReadingProgress = ((other.GearMateCombatSkillReadingProgress == null) ? null : new Dictionary<short, SByteList>(other.GearMateCombatSkillReadingProgress));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SectZhujianGearMateBreakoutDisplayData other)
	{
		LifeSkillAttainments = other.LifeSkillAttainments;
		Exp = other.Exp;
		if (other.CombatSkillDisplayDataList != null)
		{
			List<CombatSkillDisplayData> combatSkillDisplayDataList = other.CombatSkillDisplayDataList;
			int elementsCount = combatSkillDisplayDataList.Count;
			CombatSkillDisplayDataList = new List<CombatSkillDisplayData>(elementsCount);
			foreach (CombatSkillDisplayData element in combatSkillDisplayDataList)
			{
				CombatSkillDisplayDataList.Add(new CombatSkillDisplayData(element));
			}
		}
		else
		{
			CombatSkillDisplayDataList = null;
		}
		GearMateBreakoutCombatSkillBanReasonList = ((other.GearMateBreakoutCombatSkillBanReasonList == null) ? null : new List<ShortPair>(other.GearMateBreakoutCombatSkillBanReasonList));
		GearMateLifeSkillAttainments = other.GearMateLifeSkillAttainments;
		GearMateCombatSkillReadingProgress = ((other.GearMateCombatSkillReadingProgress == null) ? null : new Dictionary<short, SByteList>(other.GearMateCombatSkillReadingProgress));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize += LifeSkillAttainments.GetSerializedSize();
		if (CombatSkillDisplayDataList != null)
		{
			totalSize += 2;
			for (int i = 0; i < CombatSkillDisplayDataList.Count; i++)
			{
				totalSize = ((CombatSkillDisplayDataList[i] == null) ? (totalSize + 2) : (totalSize + (2 + CombatSkillDisplayDataList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (GearMateBreakoutCombatSkillBanReasonList != null)
		{
			totalSize += 2;
			for (int j = 0; j < GearMateBreakoutCombatSkillBanReasonList.Count; j++)
			{
				totalSize += GearMateBreakoutCombatSkillBanReasonList[j].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += GearMateLifeSkillAttainments.GetSerializedSize();
		totalSize += 4;
		if (GearMateCombatSkillReadingProgress != null)
		{
			foreach (KeyValuePair<short, SByteList> pair in GearMateCombatSkillReadingProgress)
			{
				totalSize += 2;
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
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		*(int*)pCurrData = Exp;
		pCurrData += 4;
		if (CombatSkillDisplayDataList != null)
		{
			int elementsCount = CombatSkillDisplayDataList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (CombatSkillDisplayDataList[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = CombatSkillDisplayDataList[i].Serialize(pCurrData);
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
		if (GearMateBreakoutCombatSkillBanReasonList != null)
		{
			int elementsCount2 = GearMateBreakoutCombatSkillBanReasonList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				int fieldSize2 = GearMateBreakoutCombatSkillBanReasonList[j].Serialize(pCurrData);
				pCurrData += fieldSize2;
				Tester.Assert(fieldSize2 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += GearMateLifeSkillAttainments.Serialize(pCurrData);
		if (GearMateCombatSkillReadingProgress != null)
		{
			*(int*)pCurrData = GearMateCombatSkillReadingProgress.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, SByteList> pair in GearMateCombatSkillReadingProgress)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
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
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		Exp = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CombatSkillDisplayDataList == null)
			{
				CombatSkillDisplayDataList = new List<CombatSkillDisplayData>();
			}
			else
			{
				CombatSkillDisplayDataList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				CombatSkillDisplayData element;
				if (num > 0)
				{
					element = new CombatSkillDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				CombatSkillDisplayDataList.Add(element);
			}
		}
		else
		{
			CombatSkillDisplayDataList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (GearMateBreakoutCombatSkillBanReasonList == null)
			{
				GearMateBreakoutCombatSkillBanReasonList = new List<ShortPair>();
			}
			else
			{
				GearMateBreakoutCombatSkillBanReasonList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ShortPair element2 = default(ShortPair);
				pCurrData += element2.Deserialize(pCurrData);
				GearMateBreakoutCombatSkillBanReasonList.Add(element2);
			}
		}
		else
		{
			GearMateBreakoutCombatSkillBanReasonList?.Clear();
		}
		pCurrData += GearMateLifeSkillAttainments.Deserialize(pCurrData);
		int GearMateCombatSkillReadingProgressElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (GearMateCombatSkillReadingProgressElementsCount > 0)
		{
			if (GearMateCombatSkillReadingProgress == null)
			{
				GearMateCombatSkillReadingProgress = new Dictionary<short, SByteList>();
			}
			else
			{
				GearMateCombatSkillReadingProgress.Clear();
			}
			for (int k = 0; k < GearMateCombatSkillReadingProgressElementsCount; k++)
			{
				short key = *(short*)pCurrData;
				pCurrData += 2;
				SByteList value = default(SByteList);
				pCurrData += value.Deserialize(pCurrData);
				GearMateCombatSkillReadingProgress.Add(key, value);
			}
		}
		else
		{
			GearMateCombatSkillReadingProgress?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
