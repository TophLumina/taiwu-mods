using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Math;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 战斗结果显示数据
/// </summary>
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class CombatResultDisplayData : ISerializableGameData
{
	/// <summary>
	/// 战斗状态类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte CombatStatus;

	/// <summary>
	/// 是否全选掉落物
	/// </summary>
	[SerializableGameDataField]
	public bool SelectAllItem;

	/// <summary>
	/// 战斗结果快照-战前状态
	/// </summary>
	[SerializableGameDataField]
	public CombatResultSnapshot SnapshotBeforeCombat;

	/// <summary>
	/// 战斗结果快照-战斗状态
	/// </summary>
	[SerializableGameDataField]
	public CombatResultSnapshot SnapshotAfterCombat;

	/// <summary>
	/// 获得历练值
	/// </summary>
	[SerializableGameDataField]
	public int Exp;

	/// <summary>
	/// 获得资源值
	/// </summary>
	[SerializableGameDataField]
	public ResourceInts Resource;

	/// <summary>
	/// 获得地区恩义
	/// </summary>
	[SerializableGameDataField]
	public int AreaSpiritualDebt;

	/// <summary>
	/// 是否显示灵光一闪
	/// </summary>
	[SerializableGameDataField]
	public bool ShowReadingEvent;

	/// <summary>
	/// 是否显示天人感应
	/// </summary>
	[SerializableGameDataField]
	public bool ShowLoopingEvent;

	/// <summary>
	/// 评价列表
	/// </summary>
	[SerializableGameDataField]
	public List<sbyte> EvaluationList = new List<sbyte>();

	/// <summary>
	/// 掉落道具列表
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> ItemList = new List<ItemDisplayData>();

	/// <summary>
	/// 获得人物列表
	/// </summary>
	[SerializableGameDataField]
	public List<CharacterDisplayData> CharList;

	/// <summary>
	/// 遗惠卡列表
	/// </summary>
	[SerializableGameDataField]
	public List<short> LegacyTemplateIds;

	/// <summary>
	/// 有变化的功法实战度数据
	/// 功法 ID -&gt; 变化后的实战度
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, int> ChangedProficiencies;

	/// <summary>
	/// 有变化的功法实战度数据差值
	/// 功法 ID -&gt; 实战度差值
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, int> ChangedProficienciesDelta;

	/// <summary>
	/// 掉落道具来源人物，非序列化字段
	/// </summary>
	public Dictionary<ItemKey, int> ItemSrcCharDict = new Dictionary<ItemKey, int>();

	/// <summary>
	/// 是否主角胜利
	/// </summary>
	public bool IsWin
	{
		get
		{
			if (CombatStatus != 3)
			{
				return CombatStatus == 5;
			}
			return true;
		}
	}

	/// <summary>
	/// 战斗评价配置
	/// </summary>
	public IEnumerable<CombatEvaluationItem> Evaluations => EvaluationList.Select(ParseEvaluation);

	/// <summary>
	/// 选取战斗评价配置
	/// </summary>
	public IEnumerable<T> SelectEvaluations<T>(Func<CombatEvaluationItem, T> selector)
	{
		return Evaluations.Select(selector);
	}

	/// <summary>
	/// 转换战斗评价配置
	/// </summary>
	/// <param name="evaluationTemplateId"></param>
	/// <returns></returns>
	private static CombatEvaluationItem ParseEvaluation(sbyte evaluationTemplateId)
	{
		return CombatEvaluation.Instance[evaluationTemplateId];
	}

	/// <summary>
	/// 计算战斗评价加成值
	/// </summary>
	/// <param name="baseValue">基础值</param>
	/// <param name="selectorB">战斗评价 B 类加成值选取器</param>
	/// <param name="selectorC">战斗评价 C 类加成值选取器</param>
	/// <param name="extraAddPercent">额外 B 类加成值</param>
	/// <returns>加成后的值</returns>
	public int ModifyValue(int baseValue, Func<CombatEvaluationItem, int> selectorB, Func<CombatEvaluationItem, int> selectorC, int extraAddPercent = 0)
	{
		CValuePercentBonus percent = Math.Max(CalcEvaluationSum(selectorB) + extraAddPercent, -100);
		CValuePercentBonus totalPercent = Math.Max(CalcEvaluationTotal(selectorC), -100);
		return baseValue * percent * totalPercent;
	}

	/// <summary>
	/// 获取经验加成统计
	/// </summary>
	/// <param name="addPercent">B类加成总和（如 150 表示 +150%）</param>
	/// <param name="totalPercent">C类加成总和（如 50 表示 *150%）</param>
	public void GetExpBonusStats(out int addPercent, out int totalPercent)
	{
		addPercent = CalcEvaluationSum((CombatEvaluationItem cfg) => cfg.ExpAddPercent);
		totalPercent = Math.Max(CalcEvaluationTotal((CombatEvaluationItem cfg) => cfg.ExpTotalPercent), -100);
	}

	/// <summary>
	/// 获取威望加成统计
	/// </summary>
	/// <param name="addPercent">B类加成总和</param>
	/// <param name="totalPercent">C类加成总和</param>
	public void GetAuthorityBonusStats(out int addPercent, out int totalPercent)
	{
		addPercent = CalcEvaluationSum((CombatEvaluationItem cfg) => cfg.AuthorityAddPercent);
		totalPercent = Math.Max(CalcEvaluationTotal((CombatEvaluationItem cfg) => cfg.AuthorityTotalPercent), -100);
	}

	/// <summary>
	/// 计算累加类型加成（B类）
	/// </summary>
	private int CalcEvaluationSum(Func<CombatEvaluationItem, int> selector)
	{
		return SelectEvaluations(selector).Sum();
	}

	/// <summary>
	/// 计算最大最小类型加成（C类）
	/// </summary>
	private int CalcEvaluationTotal(Func<CombatEvaluationItem, int> selector)
	{
		int totalPercentAdd = 0;
		int totalPercentReduce = 0;
		foreach (int value in SelectEvaluations(selector))
		{
			if (totalPercentAdd < value)
			{
				totalPercentAdd = value;
			}
			if (totalPercentReduce > value)
			{
				totalPercentReduce = value;
			}
		}
		return totalPercentAdd + totalPercentReduce;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 500;
		totalSize = ((EvaluationList == null) ? (totalSize + 2) : (totalSize + (2 + EvaluationList.Count)));
		if (ItemList != null)
		{
			totalSize += 2;
			int elementsCount = ItemList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				ItemDisplayData element = ItemList[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (CharList != null)
		{
			totalSize += 2;
			int elementsCount2 = CharList.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				CharacterDisplayData element2 = CharList[j];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + element2.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((LegacyTemplateIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LegacyTemplateIds.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(ChangedProficiencies);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(ChangedProficienciesDelta);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)CombatStatus;
		pCurrData++;
		*pCurrData = (SelectAllItem ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += SnapshotBeforeCombat.Serialize(pCurrData);
		pCurrData += SnapshotAfterCombat.Serialize(pCurrData);
		*(int*)pCurrData = Exp;
		pCurrData += 4;
		pCurrData += Resource.Serialize(pCurrData);
		*(int*)pCurrData = AreaSpiritualDebt;
		pCurrData += 4;
		*pCurrData = (ShowReadingEvent ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (ShowLoopingEvent ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (EvaluationList != null)
		{
			int elementsCount = EvaluationList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = (byte)EvaluationList[i];
			}
			pCurrData += elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ItemList != null)
		{
			int elementsCount2 = ItemList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				ItemDisplayData element = ItemList[j];
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
		if (CharList != null)
		{
			int elementsCount3 = CharList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				CharacterDisplayData element2 = CharList[k];
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
		if (LegacyTemplateIds != null)
		{
			int elementsCount4 = LegacyTemplateIds.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				((short*)pCurrData)[l] = LegacyTemplateIds[l];
			}
			pCurrData += 2 * elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref ChangedProficiencies);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref ChangedProficienciesDelta);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		CombatStatus = (sbyte)(*pCurrData);
		pCurrData++;
		SelectAllItem = *pCurrData != 0;
		pCurrData++;
		pCurrData += SnapshotBeforeCombat.Deserialize(pCurrData);
		pCurrData += SnapshotAfterCombat.Deserialize(pCurrData);
		Exp = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Resource.Deserialize(pCurrData);
		AreaSpiritualDebt = *(int*)pCurrData;
		pCurrData += 4;
		ShowReadingEvent = *pCurrData != 0;
		pCurrData++;
		ShowLoopingEvent = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (EvaluationList == null)
			{
				EvaluationList = new List<sbyte>(elementsCount);
			}
			else
			{
				EvaluationList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				EvaluationList.Add((sbyte)pCurrData[i]);
			}
			pCurrData += (int)elementsCount;
		}
		else
		{
			EvaluationList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (ItemList == null)
			{
				ItemList = new List<ItemDisplayData>(elementsCount2);
			}
			else
			{
				ItemList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					ItemDisplayData element = new ItemDisplayData();
					pCurrData += element.Deserialize(pCurrData);
					ItemList.Add(element);
				}
				else
				{
					ItemList.Add(null);
				}
			}
		}
		else
		{
			ItemList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (CharList == null)
			{
				CharList = new List<CharacterDisplayData>(elementsCount3);
			}
			else
			{
				CharList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num2 > 0)
				{
					CharacterDisplayData element2 = new CharacterDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
					CharList.Add(element2);
				}
				else
				{
					CharList.Add(null);
				}
			}
		}
		else
		{
			CharList?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (LegacyTemplateIds == null)
			{
				LegacyTemplateIds = new List<short>(elementsCount4);
			}
			else
			{
				LegacyTemplateIds.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				LegacyTemplateIds.Add(((short*)pCurrData)[l]);
			}
			pCurrData += 2 * elementsCount4;
		}
		else
		{
			LegacyTemplateIds?.Clear();
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref ChangedProficiencies);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref ChangedProficienciesDelta);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
