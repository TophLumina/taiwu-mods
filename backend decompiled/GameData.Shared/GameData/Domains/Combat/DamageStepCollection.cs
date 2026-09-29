using System;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

[Serializable]
public class DamageStepCollection : ISerializableGameData
{
	public int[] OuterDamageSteps = new int[7];

	public int[] InnerDamageSteps = new int[7];

	public int FatalDamageStep;

	public int MindDamageStep;

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
