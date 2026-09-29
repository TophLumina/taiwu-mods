using System;
using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

[Serializable]
[SerializableGameData(NoCopyConstructors = true)]
public class EventInteractCheckData : ISerializableGameData
{
	[SerializableGameDataField]
	public short InteractCheckTemplateId;

	[SerializableGameDataField]
	public List<int> PhaseProbList;

	[SerializableGameDataField]
	public sbyte FailPhase;

	[SerializableGameDataField]
	public sbyte FailPhaseIndex = -1;

	[SerializableGameDataField]
	public bool IsEscape;

	[SerializableGameDataField]
	public NameRelatedData SelfNameRelatedData;

	[SerializableGameDataField]
	public int SelfCharacterId;

	[SerializableGameDataField]
	public int TargetCharacterId;

	[SerializableGameDataField]
	public Dictionary<int, int> ConfessionLovePureFixProbDict;

	[SerializableGameDataField]
	public Dictionary<int, int> ConfessionLoveSecularFixProbDict;

	[SerializableGameDataField]
	public bool CombatPowerHigher;

	[SerializableGameDataField]
	public MainAttributes SelfMainAttributes;

	[SerializableGameDataField]
	public CombatSkillShorts SelfCombatSkillAttainments;

	[SerializableGameDataField]
	public LifeSkillShorts SelfLifeSkillAttainments;

	[SerializableGameDataField]
	public HitOrAvoidInts SelfHitValues;

	[SerializableGameDataField]
	public HitOrAvoidInts SelfAvoidValues;

	[SerializableGameDataField]
	public OuterAndInnerInts SelfPenetrations;

	[SerializableGameDataField]
	public OuterAndInnerInts SelfPenetrationResists;

	[SerializableGameDataField]
	public short SelfCastSpeed;

	[SerializableGameDataField]
	public short SelfAttackSpeed;

	[SerializableGameDataField]
	public short SelfMoveSpeed;

	[SerializableGameDataField]
	public NameRelatedData TargetNameRelatedData;

	[SerializableGameDataField]
	public CombatSkillShorts TargetCombatSkillAttainments;

	[SerializableGameDataField]
	public LifeSkillShorts TargetLifeSkillAttainments;

	[SerializableGameDataField]
	public HitOrAvoidInts TargetHitValues;

	[SerializableGameDataField]
	public HitOrAvoidInts TargetAvoidValues;

	[SerializableGameDataField]
	public OuterAndInnerInts TargetPenetrations;

	[SerializableGameDataField]
	public OuterAndInnerInts TargetPenetrationResists;

	[SerializableGameDataField]
	public short TargetCastSpeed;

	[SerializableGameDataField]
	public short TargetAttackSpeed;

	[SerializableGameDataField]
	public short TargetMoveSpeed;

	[SerializableGameDataField]
	public int TargetAlertFactor;

	[SerializableGameDataField]
	public LifeSkillShorts SelfLifeSkillQualities;

	[SerializableGameDataField]
	public CombatSkillShorts SelfCombatSkillQualities;

	[SerializableGameDataField]
	public sbyte StealSkillGrade;

	[SerializableGameDataField]
	public sbyte StealLifeSkillType;

	[SerializableGameDataField]
	public sbyte StealCombatSkillType;

	public EventInteractCheckData(short interactCheckTemplateId)
	{
		InteractCheckTemplateId = interactCheckTemplateId;
		PhaseProbList = new List<int>();
		FailPhase = 5;
	}

	public EventInteractCheckData()
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 385;
		totalSize = ((PhaseProbList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * PhaseProbList.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(ConfessionLovePureFixProbDict);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(ConfessionLoveSecularFixProbDict);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = InteractCheckTemplateId;
		pCurrData += 2;
		if (PhaseProbList != null)
		{
			int elementsCount = PhaseProbList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = PhaseProbList[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)FailPhase;
		pCurrData++;
		*pCurrData = (byte)FailPhaseIndex;
		pCurrData++;
		*pCurrData = (IsEscape ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += SelfNameRelatedData.Serialize(pCurrData);
		*(int*)pCurrData = SelfCharacterId;
		pCurrData += 4;
		*(int*)pCurrData = TargetCharacterId;
		pCurrData += 4;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref ConfessionLovePureFixProbDict);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref ConfessionLoveSecularFixProbDict);
		*pCurrData = (CombatPowerHigher ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += SelfMainAttributes.Serialize(pCurrData);
		pCurrData += SelfCombatSkillAttainments.Serialize(pCurrData);
		pCurrData += SelfLifeSkillAttainments.Serialize(pCurrData);
		pCurrData += SelfHitValues.Serialize(pCurrData);
		pCurrData += SelfAvoidValues.Serialize(pCurrData);
		pCurrData += SelfPenetrations.Serialize(pCurrData);
		pCurrData += SelfPenetrationResists.Serialize(pCurrData);
		*(short*)pCurrData = SelfCastSpeed;
		pCurrData += 2;
		*(short*)pCurrData = SelfAttackSpeed;
		pCurrData += 2;
		*(short*)pCurrData = SelfMoveSpeed;
		pCurrData += 2;
		pCurrData += TargetNameRelatedData.Serialize(pCurrData);
		pCurrData += TargetCombatSkillAttainments.Serialize(pCurrData);
		pCurrData += TargetLifeSkillAttainments.Serialize(pCurrData);
		pCurrData += TargetHitValues.Serialize(pCurrData);
		pCurrData += TargetAvoidValues.Serialize(pCurrData);
		pCurrData += TargetPenetrations.Serialize(pCurrData);
		pCurrData += TargetPenetrationResists.Serialize(pCurrData);
		*(short*)pCurrData = TargetCastSpeed;
		pCurrData += 2;
		*(short*)pCurrData = TargetAttackSpeed;
		pCurrData += 2;
		*(short*)pCurrData = TargetMoveSpeed;
		pCurrData += 2;
		*(int*)pCurrData = TargetAlertFactor;
		pCurrData += 4;
		pCurrData += SelfLifeSkillQualities.Serialize(pCurrData);
		pCurrData += SelfCombatSkillQualities.Serialize(pCurrData);
		*pCurrData = (byte)StealSkillGrade;
		pCurrData++;
		*pCurrData = (byte)StealLifeSkillType;
		pCurrData++;
		*pCurrData = (byte)StealCombatSkillType;
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
		InteractCheckTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (PhaseProbList == null)
			{
				PhaseProbList = new List<int>(elementsCount);
			}
			else
			{
				PhaseProbList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				PhaseProbList.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			PhaseProbList?.Clear();
		}
		FailPhase = (sbyte)(*pCurrData);
		pCurrData++;
		FailPhaseIndex = (sbyte)(*pCurrData);
		pCurrData++;
		IsEscape = *pCurrData != 0;
		pCurrData++;
		pCurrData += SelfNameRelatedData.Deserialize(pCurrData);
		SelfCharacterId = *(int*)pCurrData;
		pCurrData += 4;
		TargetCharacterId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref ConfessionLovePureFixProbDict);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref ConfessionLoveSecularFixProbDict);
		CombatPowerHigher = *pCurrData != 0;
		pCurrData++;
		pCurrData += SelfMainAttributes.Deserialize(pCurrData);
		pCurrData += SelfCombatSkillAttainments.Deserialize(pCurrData);
		pCurrData += SelfLifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += SelfHitValues.Deserialize(pCurrData);
		pCurrData += SelfAvoidValues.Deserialize(pCurrData);
		pCurrData += SelfPenetrations.Deserialize(pCurrData);
		pCurrData += SelfPenetrationResists.Deserialize(pCurrData);
		SelfCastSpeed = *(short*)pCurrData;
		pCurrData += 2;
		SelfAttackSpeed = *(short*)pCurrData;
		pCurrData += 2;
		SelfMoveSpeed = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += TargetNameRelatedData.Deserialize(pCurrData);
		pCurrData += TargetCombatSkillAttainments.Deserialize(pCurrData);
		pCurrData += TargetLifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += TargetHitValues.Deserialize(pCurrData);
		pCurrData += TargetAvoidValues.Deserialize(pCurrData);
		pCurrData += TargetPenetrations.Deserialize(pCurrData);
		pCurrData += TargetPenetrationResists.Deserialize(pCurrData);
		TargetCastSpeed = *(short*)pCurrData;
		pCurrData += 2;
		TargetAttackSpeed = *(short*)pCurrData;
		pCurrData += 2;
		TargetMoveSpeed = *(short*)pCurrData;
		pCurrData += 2;
		TargetAlertFactor = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += SelfLifeSkillQualities.Deserialize(pCurrData);
		pCurrData += SelfCombatSkillQualities.Deserialize(pCurrData);
		StealSkillGrade = (sbyte)(*pCurrData);
		pCurrData++;
		StealLifeSkillType = (sbyte)(*pCurrData);
		pCurrData++;
		StealCombatSkillType = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
