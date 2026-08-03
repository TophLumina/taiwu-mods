using System;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 各类标记的伤害阈值集合
/// </summary>
[Serializable]
public class DamageStepCollection : ISerializableGameData
{
	/// <summary>
	/// 外伤阈值集合
	/// </summary>
	public int[] OuterDamageSteps = new int[7];

	/// <summary>
	/// 内伤阈值集合
	/// </summary>
	public int[] InnerDamageSteps = new int[7];

	/// <summary>
	/// 重创阈值
	/// </summary>
	public int FatalDamageStep;

	/// <summary>
	/// 心神阈值
	/// </summary>
	public int MindDamageStep;

	/// <summary>
	/// 获取指定类型标记的伤害阈值
	/// </summary>
	public int GetDamageStep(DefeatMarkKey markKey)
	{
		return markKey.Type switch
		{
			EMarkType.Outer => OuterDamageSteps.GetOrDefault(markKey.BodyPart), 
			EMarkType.Inner => InnerDamageSteps.GetOrDefault(markKey.BodyPart), 
			EMarkType.Fatal => FatalDamageStep, 
			EMarkType.Mind => MindDamageStep, 
			_ => 0, 
		};
	}

	public DamageStepCollection()
	{
	}

	public DamageStepCollection(DamageStepCollection other)
	{
		for (sbyte part = 0; part < 7; part++)
		{
			OuterDamageSteps[part] = other.OuterDamageSteps[part];
			InnerDamageSteps[part] = other.InnerDamageSteps[part];
		}
		FatalDamageStep = other.FatalDamageStep;
		MindDamageStep = other.MindDamageStep;
	}

	/// <summary>
	/// 从配置表构造对象
	/// 配置格式: {胸背外伤,腰腹外伤,头颈外伤,左臂外伤,右臂外伤,左腿外伤,右腿外伤,
	///           胸背内伤,腰腹内伤,头颈内伤,左臂内伤,右臂内伤,左腿内伤,右腿内伤，
	///           重创,心神}
	/// </summary>
	public DamageStepCollection(params int[] stepValues)
	{
		for (int i = 0; i < 7; i++)
		{
			OuterDamageSteps[i] = stepValues[i];
			InnerDamageSteps[i] = stepValues[7 + i];
		}
		FatalDamageStep = stepValues[14];
		MindDamageStep = stepValues[15];
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 64;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		for (int i = 0; i < 7; i++)
		{
			*(int*)pCurrData = OuterDamageSteps[i];
			pCurrData += 4;
		}
		for (int j = 0; j < 7; j++)
		{
			*(int*)pCurrData = InnerDamageSteps[j];
			pCurrData += 4;
		}
		*(int*)pCurrData = FatalDamageStep;
		pCurrData += 4;
		*(int*)pCurrData = MindDamageStep;
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
		for (int i = 0; i < 7; i++)
		{
			OuterDamageSteps[i] = *(int*)pCurrData;
			pCurrData += 4;
		}
		for (int j = 0; j < 7; j++)
		{
			InnerDamageSteps[j] = *(int*)pCurrData;
			pCurrData += 4;
		}
		FatalDamageStep = *(int*)pCurrData;
		pCurrData += 4;
		MindDamageStep = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
