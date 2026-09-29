using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class JixiSpecialInteractDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int JixiCharId;

	[SerializableGameDataField]
	public int JixiCurrentTemplateId;

	[SerializableGameDataField]
	public int JixiTargetCharIdByTaiwu = -1;

	[SerializableGameDataField]
	public CharacterDisplayData JixiTargetCharacterDisplayData;

	[SerializableGameDataField]
	public short DrainTargetNeiliAllocType = -1;

	[SerializableGameDataField]
	public IntList NeiliAllocProgressDrained;

	[SerializableGameDataField]
	public int FixedNeiliProgressPerAllocation;

	[SerializableGameDataField]
	public int GrowthValue;

	[SerializableGameDataField]
	public int GrowthTotalYoung;

	[SerializableGameDataField]
	public int GrowthTotalAdult;

	[SerializableGameDataField]
	public int KillAmount;

	[SerializableGameDataField]
	public int NeiliAllocDrainedTotal;

	[SerializableGameDataField]
	public int TransferToTaiwuTotal;

	[SerializableGameDataField]
	public int TransferFromTaiwuTotal;

	[SerializableGameDataField]
	public int TempalteEnemyKilledTotal;

	[SerializableGameDataField]
	public int KillTempalteEnemyGainTotal;

	[SerializableGameDataField]
	public int[] ChangeFormTotal = new int[3];

	[SerializableGameDataField]
	public int RescueTaiwuTimes;

	[SerializableGameDataField]
	public IntList CurrentTargetNeiliAllocProgressDrained;

	[SerializableGameDataField]
	public int CurrentFormKillAmount;

	[SerializableGameDataField]
	public IntList CurrentFormNeiliAllocProgressDrained;

	[SerializableGameDataField]
	public int CurrentFormMonthlyProgress;

	[SerializableGameDataField]
	public List<int> KillTargets;

	[SerializableGameDataField]
	public bool JixiDrainNeili;

	[SerializableGameDataField]
	public short Favorability;

	[SerializableGameDataField]
	public NeiliAllocation BaseNeiliAllocation;

	[SerializableGameDataField]
	public NeiliAllocation ExtraNeiliAllocation;

	[SerializableGameDataField]
	public int CostedGrowthValue;

	[SerializableGameDataField]
	public float[] NeiliAllocProgressTransferRemain;

	[SerializableGameDataField]
	public int TaiwuTargetCharacterId;

	[SerializableGameDataField]
	public CharacterDisplayData TaiwuTargetCharacterDisplayData;

	[SerializableGameDataField]
	public sbyte TaiwuTargetFiveElementsType;

	[SerializableGameDataField]
	public sbyte[] TaiwuTargetCharacterFiveElements;

	[SerializableGameDataField]
	public int[] TaiwuTransformFiveElementsCurrent;

	[SerializableGameDataField]
	public int[] TaiwuTransformFiveElementsTotal;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 94;
		totalSize = ((JixiTargetCharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + JixiTargetCharacterDisplayData.GetSerializedSize())));
		totalSize += NeiliAllocProgressDrained.GetSerializedSize();
		totalSize = ((ChangeFormTotal == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ChangeFormTotal.Length)));
		totalSize += CurrentTargetNeiliAllocProgressDrained.GetSerializedSize();
		totalSize += CurrentFormNeiliAllocProgressDrained.GetSerializedSize();
		totalSize = ((KillTargets == null) ? (totalSize + 2) : (totalSize + (2 + 4 * KillTargets.Count)));
		totalSize = ((NeiliAllocProgressTransferRemain == null) ? (totalSize + 2) : (totalSize + (2 + 4 * NeiliAllocProgressTransferRemain.Length)));
		totalSize = ((TaiwuTargetCharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + TaiwuTargetCharacterDisplayData.GetSerializedSize())));
		totalSize = ((TaiwuTargetCharacterFiveElements == null) ? (totalSize + 2) : (totalSize + (2 + TaiwuTargetCharacterFiveElements.Length)));
		totalSize = ((TaiwuTransformFiveElementsCurrent == null) ? (totalSize + 2) : (totalSize + (2 + 4 * TaiwuTransformFiveElementsCurrent.Length)));
		totalSize = ((TaiwuTransformFiveElementsTotal == null) ? (totalSize + 2) : (totalSize + (2 + 4 * TaiwuTransformFiveElementsTotal.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = JixiCharId;
		pCurrData += 4;
		*(int*)pCurrData = JixiCurrentTemplateId;
		pCurrData += 4;
		*(int*)pCurrData = JixiTargetCharIdByTaiwu;
		pCurrData += 4;
		if (JixiTargetCharacterDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = JixiTargetCharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = DrainTargetNeiliAllocType;
		pCurrData += 2;
		int fieldSize2 = NeiliAllocProgressDrained.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		*(int*)pCurrData = FixedNeiliProgressPerAllocation;
		pCurrData += 4;
		*(int*)pCurrData = GrowthValue;
		pCurrData += 4;
		*(int*)pCurrData = GrowthTotalYoung;
		pCurrData += 4;
		*(int*)pCurrData = GrowthTotalAdult;
		pCurrData += 4;
		*(int*)pCurrData = KillAmount;
		pCurrData += 4;
		*(int*)pCurrData = NeiliAllocDrainedTotal;
		pCurrData += 4;
		*(int*)pCurrData = TransferToTaiwuTotal;
		pCurrData += 4;
		*(int*)pCurrData = TransferFromTaiwuTotal;
		pCurrData += 4;
		*(int*)pCurrData = TempalteEnemyKilledTotal;
		pCurrData += 4;
		*(int*)pCurrData = KillTempalteEnemyGainTotal;
		pCurrData += 4;
		if (ChangeFormTotal != null)
		{
			int elementsCount = ChangeFormTotal.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = ChangeFormTotal[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = RescueTaiwuTimes;
		pCurrData += 4;
		int fieldSize3 = CurrentTargetNeiliAllocProgressDrained.Serialize(pCurrData);
		pCurrData += fieldSize3;
		Tester.Assert(fieldSize3 <= 65535);
		*(int*)pCurrData = CurrentFormKillAmount;
		pCurrData += 4;
		int fieldSize4 = CurrentFormNeiliAllocProgressDrained.Serialize(pCurrData);
		pCurrData += fieldSize4;
		Tester.Assert(fieldSize4 <= 65535);
		*(int*)pCurrData = CurrentFormMonthlyProgress;
		pCurrData += 4;
		if (KillTargets != null)
		{
			int elementsCount2 = KillTargets.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = KillTargets[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (JixiDrainNeili ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = Favorability;
		pCurrData += 2;
		pCurrData += BaseNeiliAllocation.Serialize(pCurrData);
		pCurrData += ExtraNeiliAllocation.Serialize(pCurrData);
		*(int*)pCurrData = CostedGrowthValue;
		pCurrData += 4;
		if (NeiliAllocProgressTransferRemain != null)
		{
			int elementsCount3 = NeiliAllocProgressTransferRemain.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((float*)pCurrData)[k] = NeiliAllocProgressTransferRemain[k];
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = TaiwuTargetCharacterId;
		pCurrData += 4;
		if (TaiwuTargetCharacterDisplayData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize5 = TaiwuTargetCharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize5;
			Tester.Assert(fieldSize5 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)TaiwuTargetFiveElementsType;
		pCurrData++;
		if (TaiwuTargetCharacterFiveElements != null)
		{
			int elementsCount4 = TaiwuTargetCharacterFiveElements.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData[l] = (byte)TaiwuTargetCharacterFiveElements[l];
			}
			pCurrData += elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuTransformFiveElementsCurrent != null)
		{
			int elementsCount5 = TaiwuTransformFiveElementsCurrent.Length;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				((int*)pCurrData)[m] = TaiwuTransformFiveElementsCurrent[m];
			}
			pCurrData += 4 * elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuTransformFiveElementsTotal != null)
		{
			int elementsCount6 = TaiwuTransformFiveElementsTotal.Length;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				((int*)pCurrData)[n] = TaiwuTransformFiveElementsTotal[n];
			}
			pCurrData += 4 * elementsCount6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
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
		JixiCharId = *(int*)pCurrData;
		pCurrData += 4;
		JixiCurrentTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		JixiTargetCharIdByTaiwu = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (JixiTargetCharacterDisplayData == null)
			{
				JixiTargetCharacterDisplayData = new CharacterDisplayData();
			}
			pCurrData += JixiTargetCharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			JixiTargetCharacterDisplayData = null;
		}
		DrainTargetNeiliAllocType = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += NeiliAllocProgressDrained.Deserialize(pCurrData);
		FixedNeiliProgressPerAllocation = *(int*)pCurrData;
		pCurrData += 4;
		GrowthValue = *(int*)pCurrData;
		pCurrData += 4;
		GrowthTotalYoung = *(int*)pCurrData;
		pCurrData += 4;
		GrowthTotalAdult = *(int*)pCurrData;
		pCurrData += 4;
		KillAmount = *(int*)pCurrData;
		pCurrData += 4;
		NeiliAllocDrainedTotal = *(int*)pCurrData;
		pCurrData += 4;
		TransferToTaiwuTotal = *(int*)pCurrData;
		pCurrData += 4;
		TransferFromTaiwuTotal = *(int*)pCurrData;
		pCurrData += 4;
		TempalteEnemyKilledTotal = *(int*)pCurrData;
		pCurrData += 4;
		KillTempalteEnemyGainTotal = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ChangeFormTotal == null || ChangeFormTotal.Length != elementsCount)
			{
				ChangeFormTotal = new int[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ChangeFormTotal[i] = ((int*)pCurrData)[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			ChangeFormTotal = null;
		}
		RescueTaiwuTimes = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += CurrentTargetNeiliAllocProgressDrained.Deserialize(pCurrData);
		CurrentFormKillAmount = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += CurrentFormNeiliAllocProgressDrained.Deserialize(pCurrData);
		CurrentFormMonthlyProgress = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (KillTargets == null)
			{
				KillTargets = new List<int>(elementsCount2);
			}
			else
			{
				KillTargets.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				KillTargets.Add(((int*)pCurrData)[j]);
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			KillTargets?.Clear();
		}
		JixiDrainNeili = *pCurrData != 0;
		pCurrData++;
		Favorability = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += BaseNeiliAllocation.Deserialize(pCurrData);
		pCurrData += ExtraNeiliAllocation.Deserialize(pCurrData);
		CostedGrowthValue = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (NeiliAllocProgressTransferRemain == null || NeiliAllocProgressTransferRemain.Length != elementsCount3)
			{
				NeiliAllocProgressTransferRemain = new float[elementsCount3];
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				NeiliAllocProgressTransferRemain[k] = ((float*)pCurrData)[k];
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			NeiliAllocProgressTransferRemain = null;
		}
		TaiwuTargetCharacterId = *(int*)pCurrData;
		pCurrData += 4;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (TaiwuTargetCharacterDisplayData == null)
			{
				TaiwuTargetCharacterDisplayData = new CharacterDisplayData();
			}
			pCurrData += TaiwuTargetCharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			TaiwuTargetCharacterDisplayData = null;
		}
		TaiwuTargetFiveElementsType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (TaiwuTargetCharacterFiveElements == null || TaiwuTargetCharacterFiveElements.Length != elementsCount4)
			{
				TaiwuTargetCharacterFiveElements = new sbyte[elementsCount4];
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				TaiwuTargetCharacterFiveElements[l] = (sbyte)pCurrData[l];
			}
			pCurrData += (int)elementsCount4;
		}
		else
		{
			TaiwuTargetCharacterFiveElements = null;
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (TaiwuTransformFiveElementsCurrent == null || TaiwuTransformFiveElementsCurrent.Length != elementsCount5)
			{
				TaiwuTransformFiveElementsCurrent = new int[elementsCount5];
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				TaiwuTransformFiveElementsCurrent[m] = ((int*)pCurrData)[m];
			}
			pCurrData += 4 * elementsCount5;
		}
		else
		{
			TaiwuTransformFiveElementsCurrent = null;
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (TaiwuTransformFiveElementsTotal == null || TaiwuTransformFiveElementsTotal.Length != elementsCount6)
			{
				TaiwuTransformFiveElementsTotal = new int[elementsCount6];
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				TaiwuTransformFiveElementsTotal[n] = ((int*)pCurrData)[n];
			}
			pCurrData += 4 * elementsCount6;
		}
		else
		{
			TaiwuTransformFiveElementsTotal = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
