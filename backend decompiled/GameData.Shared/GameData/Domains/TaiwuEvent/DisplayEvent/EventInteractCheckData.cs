using System;
using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 事件交互判定动画数据
/// </summary>
[Serializable]
[SerializableGameData(NoCopyConstructors = true)]
public class EventInteractCheckData : ISerializableGameData
{
	/// <summary>
	/// InteractCheck 模板id
	/// </summary>
	[SerializableGameDataField]
	public short InteractCheckTemplateId;

	/// <summary>
	/// 每个阶段成功的概率
	/// </summary>
	[SerializableGameDataField]
	public List<int> PhaseProbList;

	/// <summary>
	/// 失败阶段
	/// </summary>
	[SerializableGameDataField]
	public sbyte FailPhase;

	/// <summary>
	/// 失败阶段在配置表中的Index
	/// </summary>
	[SerializableGameDataField]
	public sbyte FailPhaseIndex = -1;

	/// <summary>
	/// 是否是逃跑
	/// false使用配置表InteractCheck.ActionPhaseList；此时FailPhase=-1或&gt;=EscapePhaseList.Count表示成功
	/// true逃跑需要使用配置表InteractCheck.EscapePhaseList;此时FailPhase=HarmfulActionPhase.Count表示成功
	/// </summary>
	[SerializableGameDataField]
	public bool IsEscape;

	/// <summary>
	/// 我方姓名相关数据
	/// </summary>
	[SerializableGameDataField]
	public NameRelatedData SelfNameRelatedData;

	/// <summary>
	/// 发起方角色id
	/// </summary>
	[SerializableGameDataField]
	public int SelfCharacterId;

	/// <summary>
	/// 目标角色id
	/// </summary>
	[SerializableGameDataField]
	public int TargetCharacterId;

	/// <summary>
	/// 倾诉爱意各个修正因素-爱慕
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, int> ConfessionLovePureFixProbDict;

	/// <summary>
	/// 倾诉爱意各个修正因素-世俗
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, int> ConfessionLoveSecularFixProbDict;

	/// <summary>
	/// 战斗力是否高于目标
	/// </summary>
	[SerializableGameDataField]
	public bool CombatPowerHigher;

	/// <summary>
	/// 我方主要属性
	/// </summary>
	[SerializableGameDataField]
	public MainAttributes SelfMainAttributes;

	/// <summary>
	/// 我方武学造诣
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts SelfCombatSkillAttainments;

	/// <summary>
	/// 我方技艺造诣
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts SelfLifeSkillAttainments;

	/// <summary>
	/// 我方命中属性
	/// </summary>
	[SerializableGameDataField]
	public HitOrAvoidInts SelfHitValues;

	/// <summary>
	/// 我方化解属性
	/// </summary>
	[SerializableGameDataField]
	public HitOrAvoidInts SelfAvoidValues;

	/// <summary>
	/// 我方攻击属性-攻击
	/// </summary>
	[SerializableGameDataField]
	public OuterAndInnerInts SelfPenetrations;

	/// <summary>
	/// 我方防御属性 - 防御
	/// </summary>
	[SerializableGameDataField]
	public OuterAndInnerInts SelfPenetrationResists;

	/// <summary>
	/// 我方-次要属性-施展速度
	/// </summary>
	[SerializableGameDataField]
	public short SelfCastSpeed;

	/// <summary>
	/// 我方-次要属性-攻击速度
	/// </summary>
	[SerializableGameDataField]
	public short SelfAttackSpeed;

	/// <summary>
	/// 我方-次要属性-移动速度
	/// </summary>
	[SerializableGameDataField]
	public short SelfMoveSpeed;

	/// <summary>
	/// 目标姓名相关数据
	/// </summary>
	[SerializableGameDataField]
	public NameRelatedData TargetNameRelatedData;

	/// <summary>
	/// 目标武学造诣
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts TargetCombatSkillAttainments;

	/// <summary>
	/// 目标技艺造诣
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts TargetLifeSkillAttainments;

	/// <summary>
	/// 目标命中属性
	/// </summary>
	[SerializableGameDataField]
	public HitOrAvoidInts TargetHitValues;

	/// <summary>
	/// 目标化解属性
	/// </summary>
	[SerializableGameDataField]
	public HitOrAvoidInts TargetAvoidValues;

	/// <summary>
	/// 目标攻击属性-攻击
	/// </summary>
	[SerializableGameDataField]
	public OuterAndInnerInts TargetPenetrations;

	/// <summary>
	/// 目标防御属性 - 防御
	/// </summary>
	[SerializableGameDataField]
	public OuterAndInnerInts TargetPenetrationResists;

	/// <summary>
	/// 目标-次要属性-施展速度
	/// </summary>
	[SerializableGameDataField]
	public short TargetCastSpeed;

	/// <summary>
	/// 目标-次要属性-攻击速度
	/// </summary>
	[SerializableGameDataField]
	public short TargetAttackSpeed;

	/// <summary>
	/// 对方-次要属性-移动速度
	/// </summary>
	[SerializableGameDataField]
	public short TargetMoveSpeed;

	/// <summary>
	/// 目标警惕值
	/// </summary>
	[SerializableGameDataField]
	public int TargetAlertFactor;

	/// <summary>
	/// 我方技艺资质
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts SelfLifeSkillQualities;

	/// <summary>
	/// 我方武学资质
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts SelfCombatSkillQualities;

	/// <summary>
	/// 偷师的技艺功法等级
	/// </summary>
	[SerializableGameDataField]
	public sbyte StealSkillGrade;

	/// <summary>
	/// 偷师的技艺类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte StealLifeSkillType;

	/// <summary>
	/// 偷师的功法类型
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
