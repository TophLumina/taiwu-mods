using System.Collections.Generic;
using Config;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 功法列表显示数据。只保证列表显示时排序、筛选和技能卡显示可正常使用
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class CombatSkillDisplayDataForList : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public bool IsInAnyEquipPlans;

	[SerializableGameDataField]
	public bool BreakSuccess;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public short Power;

	[SerializableGameDataField]
	public short EmeiBonus1;

	[SerializableGameDataField]
	public short EmeiBonus2;

	[SerializableGameDataField]
	public ushort ReadingState;

	[SerializableGameDataField]
	public ushort ActivationState;

	[SerializableGameDataField]
	public sbyte LuohanId;

	[SerializableGameDataField]
	public List<sbyte> BreakBonusGrades;

	[SerializableGameDataField]
	public HitOrAvoidInts HitDistribution;

	[SerializableGameDataField]
	public List<NeedTrick> CostTricks;

	[SerializableGameDataField]
	public bool Revoked;

	[SerializableGameDataField]
	public int CombatSkillProficiency;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 24;
		totalSize = ((BreakBonusGrades == null) ? (totalSize + 2) : (totalSize + (2 + BreakBonusGrades.Count)));
		totalSize += HitDistribution.GetSerializedSize();
		totalSize = ((CostTricks == null) ? (totalSize + 2) : (totalSize + (2 + default(NeedTrick).GetSerializedSize() * CostTricks.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*pCurrData = (IsInAnyEquipPlans ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (BreakSuccess ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(short*)pCurrData = Power;
		pCurrData += 2;
		*(short*)pCurrData = EmeiBonus1;
		pCurrData += 2;
		*(short*)pCurrData = EmeiBonus2;
		pCurrData += 2;
		*(ushort*)pCurrData = ReadingState;
		pCurrData += 2;
		*(ushort*)pCurrData = ActivationState;
		pCurrData += 2;
		*pCurrData = (byte)LuohanId;
		pCurrData++;
		if (BreakBonusGrades != null)
		{
			int elementsCount = BreakBonusGrades.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = (byte)BreakBonusGrades[i];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += HitDistribution.Serialize(pCurrData);
		if (CostTricks != null)
		{
			int elementsCount2 = CostTricks.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += CostTricks[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (Revoked ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = CombatSkillProficiency;
		pCurrData += 4;
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		IsInAnyEquipPlans = *pCurrData != 0;
		pCurrData++;
		BreakSuccess = *pCurrData != 0;
		pCurrData++;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		Power = *(short*)pCurrData;
		pCurrData += 2;
		EmeiBonus1 = *(short*)pCurrData;
		pCurrData += 2;
		EmeiBonus2 = *(short*)pCurrData;
		pCurrData += 2;
		ReadingState = *(ushort*)pCurrData;
		pCurrData += 2;
		ActivationState = *(ushort*)pCurrData;
		pCurrData += 2;
		LuohanId = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (BreakBonusGrades == null)
			{
				BreakBonusGrades = new List<sbyte>();
			}
			else
			{
				BreakBonusGrades.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				sbyte element = (sbyte)(*pCurrData);
				pCurrData++;
				BreakBonusGrades.Add(element);
			}
		}
		else
		{
			BreakBonusGrades?.Clear();
		}
		pCurrData += HitDistribution.Deserialize(pCurrData);
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CostTricks == null)
			{
				CostTricks = new List<NeedTrick>();
			}
			else
			{
				CostTricks.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				NeedTrick element2 = default(NeedTrick);
				pCurrData += element2.Deserialize(pCurrData);
				CostTricks.Add(element2);
			}
		}
		else
		{
			CostTricks?.Clear();
		}
		Revoked = *pCurrData != 0;
		pCurrData++;
		CombatSkillProficiency = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
