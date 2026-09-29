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

[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class CombatResultDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte CombatStatus;

	[SerializableGameDataField]
	public bool SelectAllItem;

	[SerializableGameDataField]
	public CombatResultSnapshot SnapshotBeforeCombat;

	[SerializableGameDataField]
	public CombatResultSnapshot SnapshotAfterCombat;

	[SerializableGameDataField]
	public int Exp;

	[SerializableGameDataField]
	public ResourceInts Resource;

	[SerializableGameDataField]
	public int AreaSpiritualDebt;

	[SerializableGameDataField]
	public bool ShowReadingEvent;

	[SerializableGameDataField]
	public bool ShowLoopingEvent;

	[SerializableGameDataField]
	public List<sbyte> EvaluationList = new List<sbyte>();

	[SerializableGameDataField]
	public List<ItemDisplayData> ItemList = new List<ItemDisplayData>();

	[SerializableGameDataField]
	public List<CharacterDisplayData> CharList;

	[SerializableGameDataField]
	public List<short> LegacyTemplateIds;

	[SerializableGameDataField]
	public Dictionary<short, int> ChangedProficiencies;

	[SerializableGameDataField]
	public Dictionary<short, int> ChangedProficienciesDelta;

	public Dictionary<ItemKey, int> ItemSrcCharDict = new Dictionary<ItemKey, int>();

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

	public IEnumerable<CombatEvaluationItem> Evaluations => EvaluationList.Select(ParseEvaluation);

	public IEnumerable<T> SelectEvaluations<T>(Func<CombatEvaluationItem, T> selector)
	{
		return Evaluations.Select(selector);
	}

	private static CombatEvaluationItem ParseEvaluation(sbyte evaluationTemplateId)
	{
		return CombatEvaluation.Instance[evaluationTemplateId];
	}

	public int ModifyValue(int baseValue, Func<CombatEvaluationItem, int> selectorB, Func<CombatEvaluationItem, int> selectorC, int extraAddPercent = 0)
	{
		CValuePercentBonus percent = Math.Max(CalcEvaluationSum(selectorB) + extraAddPercent, -100);
		CValuePercentBonus totalPercent = Math.Max(CalcEvaluationTotal(selectorC), -100);
		return baseValue * percent * totalPercent;
	}

	public void GetExpBonusStats(out int addPercent, out int totalPercent)
	{
		addPercent = CalcEvaluationSum((CombatEvaluationItem cfg) => cfg.ExpAddPercent);
		totalPercent = Math.Max(CalcEvaluationTotal((CombatEvaluationItem cfg) => cfg.ExpTotalPercent), -100);
	}

	public void GetAuthorityBonusStats(out int addPercent, out int totalPercent)
	{
		addPercent = CalcEvaluationSum((CombatEvaluationItem cfg) => cfg.AuthorityAddPercent);
		totalPercent = Math.Max(CalcEvaluationTotal((CombatEvaluationItem cfg) => cfg.AuthorityTotalPercent), -100);
	}

	private int CalcEvaluationSum(Func<CombatEvaluationItem, int> selector)
	{
		return SelectEvaluations(selector).Sum();
	}

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

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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
