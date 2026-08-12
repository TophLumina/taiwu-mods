using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.Taiwu.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Extra;

/// <summary>
/// 周天演练界面显示数据 - 一次性获取所有前端所需数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class LoopingViewDisplayData : ISerializableGameData
{
	/// <summary>
	/// 当前悟性
	/// </summary>
	[SerializableGameDataField]
	public int CurConcentration;

	/// <summary>
	/// 最大悟性
	/// </summary>
	[SerializableGameDataField]
	public int MaxConcentration;

	/// <summary>
	/// 当前内力
	/// </summary>
	[SerializableGameDataField]
	public int CurrNeili;

	/// <summary>
	/// 当前演练内功ID (-1表示无)
	/// </summary>
	[SerializableGameDataField]
	public short LoopingNeigong = -1;

	/// <summary>
	/// 已学内功列表 (TemplateId列表)
	/// </summary>
	[SerializableGameDataField]
	public List<short> LearnedSkillList = new List<short>();

	/// <summary>
	/// 功法显示数据缓存
	/// </summary>
	[SerializableGameDataField]
	public List<CombatSkillDisplayDataCharacterMenuListItem> CombatSkillDisplayDataList = new List<CombatSkillDisplayDataCharacterMenuListItem>();

	/// <summary>
	/// 辅助功法列表（3个槽位，-1表示空）
	/// </summary>
	[SerializableGameDataField]
	public List<short> ReferenceSkillList = new List<short>();

	/// <summary>
	/// 槽位解锁状态（位掩码）
	/// </summary>
	[SerializableGameDataField]
	public byte ReferenceSkillSlotUnlockStates;

	/// <summary>
	/// 额外真气进度
	/// </summary>
	[SerializableGameDataField]
	public IntList TaiwuExtraNeiliAllocationProgress;

	/// <summary>
	/// 每轮真气增量最小值
	/// </summary>
	[SerializableGameDataField]
	public int ExtraNeiliPerLoopMin;

	/// <summary>
	/// 每轮真气增量最大值
	/// </summary>
	[SerializableGameDataField]
	public int ExtraNeiliPerLoopMax;

	/// <summary>
	/// 每轮真气分配增量
	/// </summary>
	[SerializableGameDataField]
	public IntList ExtraNeiliAllocationPerLoop;

	/// <summary>
	/// 当前策略列表
	/// </summary>
	[SerializableGameDataField]
	public List<QiArtStrategyDisplayData> TaiwuQiArtStrategyList = new List<QiArtStrategyDisplayData>();

	/// <summary>
	/// 可用策略列表
	/// </summary>
	[SerializableGameDataField]
	public SByteList AvailableStrategies;

	/// <summary>
	/// 有事件的功法ID列表
	/// </summary>
	[SerializableGameDataField]
	public List<short> LoopingEventSkillIdList = new List<short>();

	/// <summary>
	/// 生活技能战斗次数
	/// </summary>
	[SerializableGameDataField]
	public sbyte LoopInLifeSkillCombatCount;

	/// <summary>
	/// 战斗次数
	/// </summary>
	[SerializableGameDataField]
	public sbyte LoopInCombatCount;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 25;
		totalSize = ((LearnedSkillList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedSkillList.Count)));
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
		totalSize = ((ReferenceSkillList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ReferenceSkillList.Count)));
		totalSize += TaiwuExtraNeiliAllocationProgress.GetSerializedSize();
		totalSize += ExtraNeiliAllocationPerLoop.GetSerializedSize();
		if (TaiwuQiArtStrategyList != null)
		{
			QiArtStrategyDisplayData TaiwuQiArtStrategyListElement = new QiArtStrategyDisplayData();
			totalSize += 2 + TaiwuQiArtStrategyListElement.GetSerializedSize() * TaiwuQiArtStrategyList.Count;
		}
		else
		{
			totalSize += 2;
		}
		totalSize += AvailableStrategies.GetSerializedSize();
		totalSize = ((LoopingEventSkillIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LoopingEventSkillIdList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CurConcentration;
		pCurrData += 4;
		*(int*)pCurrData = MaxConcentration;
		pCurrData += 4;
		*(int*)pCurrData = CurrNeili;
		pCurrData += 4;
		*(short*)pCurrData = LoopingNeigong;
		pCurrData += 2;
		if (LearnedSkillList != null)
		{
			int elementsCount = LearnedSkillList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = LearnedSkillList[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CombatSkillDisplayDataList != null)
		{
			int elementsCount2 = CombatSkillDisplayDataList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (CombatSkillDisplayDataList[j] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = CombatSkillDisplayDataList[j].Serialize(pCurrData);
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
		if (ReferenceSkillList != null)
		{
			int elementsCount3 = ReferenceSkillList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				*(short*)pCurrData = ReferenceSkillList[k];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = ReferenceSkillSlotUnlockStates;
		pCurrData++;
		int fieldSize2 = TaiwuExtraNeiliAllocationProgress.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		*(int*)pCurrData = ExtraNeiliPerLoopMin;
		pCurrData += 4;
		*(int*)pCurrData = ExtraNeiliPerLoopMax;
		pCurrData += 4;
		int fieldSize3 = ExtraNeiliAllocationPerLoop.Serialize(pCurrData);
		pCurrData += fieldSize3;
		Tester.Assert(fieldSize3 <= 65535);
		if (TaiwuQiArtStrategyList != null)
		{
			int elementsCount4 = TaiwuQiArtStrategyList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData += TaiwuQiArtStrategyList[l].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int fieldSize4 = AvailableStrategies.Serialize(pCurrData);
		pCurrData += fieldSize4;
		Tester.Assert(fieldSize4 <= 65535);
		if (LoopingEventSkillIdList != null)
		{
			int elementsCount5 = LoopingEventSkillIdList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				*(short*)pCurrData = LoopingEventSkillIdList[m];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		CurConcentration = *(int*)pCurrData;
		pCurrData += 4;
		MaxConcentration = *(int*)pCurrData;
		pCurrData += 4;
		CurrNeili = *(int*)pCurrData;
		pCurrData += 4;
		LoopingNeigong = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (LearnedSkillList == null)
			{
				LearnedSkillList = new List<short>();
			}
			else
			{
				LearnedSkillList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				LearnedSkillList.Add(element);
			}
		}
		else
		{
			LearnedSkillList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CombatSkillDisplayDataList == null)
			{
				CombatSkillDisplayDataList = new List<CombatSkillDisplayDataCharacterMenuListItem>();
			}
			else
			{
				CombatSkillDisplayDataList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				CombatSkillDisplayDataCharacterMenuListItem element2;
				if (num > 0)
				{
					element2 = new CombatSkillDisplayDataCharacterMenuListItem();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				CombatSkillDisplayDataList.Add(element2);
			}
		}
		else
		{
			CombatSkillDisplayDataList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (ReferenceSkillList == null)
			{
				ReferenceSkillList = new List<short>();
			}
			else
			{
				ReferenceSkillList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				short element3 = *(short*)pCurrData;
				pCurrData += 2;
				ReferenceSkillList.Add(element3);
			}
		}
		else
		{
			ReferenceSkillList?.Clear();
		}
		ReferenceSkillSlotUnlockStates = *pCurrData;
		pCurrData++;
		pCurrData += TaiwuExtraNeiliAllocationProgress.Deserialize(pCurrData);
		ExtraNeiliPerLoopMin = *(int*)pCurrData;
		pCurrData += 4;
		ExtraNeiliPerLoopMax = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += ExtraNeiliAllocationPerLoop.Deserialize(pCurrData);
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (TaiwuQiArtStrategyList == null)
			{
				TaiwuQiArtStrategyList = new List<QiArtStrategyDisplayData>();
			}
			else
			{
				TaiwuQiArtStrategyList.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				QiArtStrategyDisplayData element4 = new QiArtStrategyDisplayData();
				pCurrData += element4.Deserialize(pCurrData);
				TaiwuQiArtStrategyList.Add(element4);
			}
		}
		else
		{
			TaiwuQiArtStrategyList?.Clear();
		}
		pCurrData += AvailableStrategies.Deserialize(pCurrData);
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (LoopingEventSkillIdList == null)
			{
				LoopingEventSkillIdList = new List<short>();
			}
			else
			{
				LoopingEventSkillIdList.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				short element5 = *(short*)pCurrData;
				pCurrData += 2;
				LoopingEventSkillIdList.Add(element5);
			}
		}
		else
		{
			LoopingEventSkillIdList?.Clear();
		}
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
