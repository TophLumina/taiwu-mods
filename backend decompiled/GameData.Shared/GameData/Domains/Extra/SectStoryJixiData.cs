using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

/// <summary>
/// 地区主线 姬穸数据
/// </summary>
[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class SectStoryJixiData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort JixiDrainNeili = 0;

		public const ushort JixiTargetCharIdByTaiwu = 1;

		public const ushort PreviousDrainTarget = 2;

		public const ushort DrainTargetNeiliAllocType = 3;

		public const ushort DrainTargetBasicNeiliAllocProgress = 4;

		public const ushort KillTargets = 5;

		public const ushort NeiliAllocProgressDrained = 6;

		public const ushort JixiTempNeiliAllocationProgressFromTaiwuAmount = 7;

		public const ushort JixiTempKillAmount = 8;

		public const ushort NeiliAllocProgressTransfer = 9;

		public const ushort NeiliAllocProgressDrainedTotal = 10;

		public const ushort TransferToTaiwuTotal = 11;

		public const ushort TransferFromTaiwuTotal = 12;

		public const ushort TempalteEnemyKilledTotal = 13;

		public const ushort KillTempalteEnemyGainTotal = 14;

		public const ushort ChangeFormTotal = 15;

		public const ushort RescueTaiwuTimes = 16;

		public const ushort CurrentTargetNeiliAllocProgressDrained = 17;

		public const ushort CurrentFormKillAmount = 18;

		public const ushort CurrentFormNeiliAllocProgressDrained = 19;

		public const ushort TaiwuTargetCharacterId = 20;

		public const ushort TaiwuTargetFiveElementsType = 21;

		public const ushort TaiwuTransformFiveElementsTotal = 22;

		public const ushort TaiwuTransformFiveElementsCurrent = 23;

		public const ushort CostedGrowthValue = 24;

		public const ushort NeiliAllocProgressTransferRemain = 25;

		public const ushort Count = 26;

		public static readonly string[] FieldId2FieldName = new string[26]
		{
			"JixiDrainNeili", "JixiTargetCharIdByTaiwu", "PreviousDrainTarget", "DrainTargetNeiliAllocType", "DrainTargetBasicNeiliAllocProgress", "KillTargets", "NeiliAllocProgressDrained", "JixiTempNeiliAllocationProgressFromTaiwuAmount", "JixiTempKillAmount", "NeiliAllocProgressTransfer",
			"NeiliAllocProgressDrainedTotal", "TransferToTaiwuTotal", "TransferFromTaiwuTotal", "TempalteEnemyKilledTotal", "KillTempalteEnemyGainTotal", "ChangeFormTotal", "RescueTaiwuTimes", "CurrentTargetNeiliAllocProgressDrained", "CurrentFormKillAmount", "CurrentFormNeiliAllocProgressDrained",
			"TaiwuTargetCharacterId", "TaiwuTargetFiveElementsType", "TaiwuTransformFiveElementsTotal", "TaiwuTransformFiveElementsCurrent", "CostedGrowthValue", "NeiliAllocProgressTransferRemain"
		};
	}

	/// <summary>
	/// 当前姬穸是否处于吸取内力形态
	/// </summary>
	[SerializableGameDataField]
	public bool JixiDrainNeili;

	/// <summary>
	/// 太吾指定的姬穸吃人/吸取目标角色ID
	/// </summary>
	[SerializableGameDataField]
	public int JixiTargetCharIdByTaiwu = -1;

	/// <summary>
	/// 上个吸取目标角色ID
	/// </summary>
	[SerializableGameDataField]
	public int PreviousDrainTarget = -1;

	/// <summary>
	/// 太吾指定的姬穸目标真气类型
	/// </summary>
	[SerializableGameDataField]
	public short DrainTargetNeiliAllocType = -1;

	/// <summary>
	/// 姬穸当前目标吸取真气进度，只在吸取基础真气时 记录已经吸取了多少即将吸取的真气进度
	/// </summary>
	[SerializableGameDataField]
	public int DrainTargetBasicNeiliAllocProgress;

	/// <summary>
	/// 杀死的角色ID列表,
	/// DeadCharacter的Id
	/// </summary>
	[SerializableGameDataField]
	public List<int> KillTargets = new List<int>();

	/// <summary>
	/// 吸取的真气
	/// </summary>
	[SerializableGameDataField]
	public IntList NeiliAllocProgressDrained;

	/// <summary>
	/// 临时真气进度，不计入NeiliAllocProgressDrained，因转给太吾而导致姬穸降级时重置
	/// </summary>
	[SerializableGameDataField]
	public int JixiTempNeiliAllocationProgressFromTaiwuAmount;

	/// <summary>
	/// 临时吃人数
	/// </summary>
	[SerializableGameDataField]
	public int JixiTempKillAmount;

	/// <summary>
	/// 向太吾转移的真气进度，每55点进度 使太吾+1点真气。
	/// 此处只记录遗留的进度，再次转移时加上该遗留进度之后 再计算实际使太吾增加几点真气
	/// </summary>
	[SerializableGameDataField]
	public IntList NeiliAllocProgressTransfer;

	/// <summary>
	/// 吸取的真气（总计）
	/// </summary>
	[SerializableGameDataField]
	public IntList NeiliAllocProgressDrainedTotal;

	/// <summary>
	/// 传给太吾的真气进度（总计）
	/// </summary>
	[SerializableGameDataField]
	public int TransferToTaiwuTotal;

	/// <summary>
	/// 从太吾获取的真气进度（总计）
	/// </summary>
	[SerializableGameDataField]
	public int TransferFromTaiwuTotal;

	/// <summary>
	/// 消灭的外道数量（总计）
	/// </summary>
	[SerializableGameDataField]
	public int TempalteEnemyKilledTotal;

	/// <summary>
	/// 消灭的外道获取的恩义（总计）
	/// </summary>
	[SerializableGameDataField]
	public int KillTempalteEnemyGainTotal;

	/// <summary>
	/// 形态变换次数（总计）
	/// </summary>
	[SerializableGameDataField]
	public int[] ChangeFormTotal = new int[3];

	/// <summary>
	/// 为太吾恢复健康次数（总计）
	/// </summary>
	[SerializableGameDataField]
	public int RescueTaiwuTimes;

	/// <summary>
	/// 吸取的真气（对当前目标的吸取进度）
	/// </summary>
	[SerializableGameDataField]
	public IntList CurrentTargetNeiliAllocProgressDrained;

	/// <summary>
	/// 当前形态 吃人数量
	/// </summary>
	[SerializableGameDataField]
	public int CurrentFormKillAmount;

	/// <summary>
	/// 当前形态 吸取的真气进度
	/// </summary>
	[SerializableGameDataField]
	public IntList CurrentFormNeiliAllocProgressDrained;

	/// <summary>
	/// 太吾转移五行的目标Id
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuTargetCharacterId = -1;

	/// <summary>
	/// 太吾转移五行的目标五行类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte TaiwuTargetFiveElementsType = -1;

	/// <summary>
	/// 太吾转移五行的总量
	/// </summary>
	[SerializableGameDataField]
	public int[] TaiwuTransformFiveElementsTotal;

	/// <summary>
	/// 太吾转移当前目标五行的总量
	/// </summary>
	[SerializableGameDataField]
	public int[] TaiwuTransformFiveElementsCurrent;

	/// <summary>
	/// 恢复健康等操作消耗的成长进度
	/// </summary>
	[SerializableGameDataField]
	public int CostedGrowthValue;

	/// <summary>
	/// 向太吾转移的真气进度，每55点进度 使太吾+1点真气。
	/// 此处只记录遗留的进度，再次转移时加上该遗留进度之后 再计算实际使太吾增加几点真气
	/// </summary>
	[SerializableGameDataField]
	public float[] NeiliAllocProgressTransferRemain;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 58;
		totalSize = ((KillTargets == null) ? (totalSize + 2) : (totalSize + (2 + 4 * KillTargets.Count)));
		totalSize += NeiliAllocProgressDrained.GetSerializedSize();
		totalSize += NeiliAllocProgressTransfer.GetSerializedSize();
		totalSize += NeiliAllocProgressDrainedTotal.GetSerializedSize();
		totalSize = ((ChangeFormTotal == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ChangeFormTotal.Length)));
		totalSize += CurrentTargetNeiliAllocProgressDrained.GetSerializedSize();
		totalSize += CurrentFormNeiliAllocProgressDrained.GetSerializedSize();
		totalSize = ((TaiwuTransformFiveElementsTotal == null) ? (totalSize + 2) : (totalSize + (2 + 4 * TaiwuTransformFiveElementsTotal.Length)));
		totalSize = ((TaiwuTransformFiveElementsCurrent == null) ? (totalSize + 2) : (totalSize + (2 + 4 * TaiwuTransformFiveElementsCurrent.Length)));
		totalSize = ((NeiliAllocProgressTransferRemain == null) ? (totalSize + 2) : (totalSize + (2 + 4 * NeiliAllocProgressTransferRemain.Length)));
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
		*(short*)pCurrData = 26;
		pCurrData += 2;
		*pCurrData = (JixiDrainNeili ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = JixiTargetCharIdByTaiwu;
		pCurrData += 4;
		*(int*)pCurrData = PreviousDrainTarget;
		pCurrData += 4;
		*(short*)pCurrData = DrainTargetNeiliAllocType;
		pCurrData += 2;
		*(int*)pCurrData = DrainTargetBasicNeiliAllocProgress;
		pCurrData += 4;
		if (KillTargets != null)
		{
			int elementsCount = KillTargets.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = KillTargets[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int fieldSize = NeiliAllocProgressDrained.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = JixiTempNeiliAllocationProgressFromTaiwuAmount;
		pCurrData += 4;
		*(int*)pCurrData = JixiTempKillAmount;
		pCurrData += 4;
		int fieldSize2 = NeiliAllocProgressTransfer.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		int fieldSize3 = NeiliAllocProgressDrainedTotal.Serialize(pCurrData);
		pCurrData += fieldSize3;
		Tester.Assert(fieldSize3 <= 65535);
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
			int elementsCount2 = ChangeFormTotal.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = ChangeFormTotal[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = RescueTaiwuTimes;
		pCurrData += 4;
		int fieldSize4 = CurrentTargetNeiliAllocProgressDrained.Serialize(pCurrData);
		pCurrData += fieldSize4;
		Tester.Assert(fieldSize4 <= 65535);
		*(int*)pCurrData = CurrentFormKillAmount;
		pCurrData += 4;
		int fieldSize5 = CurrentFormNeiliAllocProgressDrained.Serialize(pCurrData);
		pCurrData += fieldSize5;
		Tester.Assert(fieldSize5 <= 65535);
		*(int*)pCurrData = TaiwuTargetCharacterId;
		pCurrData += 4;
		*pCurrData = (byte)TaiwuTargetFiveElementsType;
		pCurrData++;
		if (TaiwuTransformFiveElementsTotal != null)
		{
			int elementsCount3 = TaiwuTransformFiveElementsTotal.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((int*)pCurrData)[k] = TaiwuTransformFiveElementsTotal[k];
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuTransformFiveElementsCurrent != null)
		{
			int elementsCount4 = TaiwuTransformFiveElementsCurrent.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				((int*)pCurrData)[l] = TaiwuTransformFiveElementsCurrent[l];
			}
			pCurrData += 4 * elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = CostedGrowthValue;
		pCurrData += 4;
		if (NeiliAllocProgressTransferRemain != null)
		{
			int elementsCount5 = NeiliAllocProgressTransferRemain.Length;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				((float*)pCurrData)[m] = NeiliAllocProgressTransferRemain[m];
			}
			pCurrData += 4 * elementsCount5;
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			JixiDrainNeili = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 1)
		{
			JixiTargetCharIdByTaiwu = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			PreviousDrainTarget = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			DrainTargetNeiliAllocType = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 4)
		{
			DrainTargetBasicNeiliAllocProgress = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 5)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (KillTargets == null)
				{
					KillTargets = new List<int>(elementsCount);
				}
				else
				{
					KillTargets.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					KillTargets.Add(((int*)pCurrData)[i]);
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				KillTargets?.Clear();
			}
		}
		if (fieldCount > 6)
		{
			pCurrData += NeiliAllocProgressDrained.Deserialize(pCurrData);
		}
		if (fieldCount > 7)
		{
			JixiTempNeiliAllocationProgressFromTaiwuAmount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 8)
		{
			JixiTempKillAmount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 9)
		{
			pCurrData += NeiliAllocProgressTransfer.Deserialize(pCurrData);
		}
		if (fieldCount > 10)
		{
			pCurrData += NeiliAllocProgressDrainedTotal.Deserialize(pCurrData);
		}
		if (fieldCount > 11)
		{
			TransferToTaiwuTotal = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 12)
		{
			TransferFromTaiwuTotal = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 13)
		{
			TempalteEnemyKilledTotal = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 14)
		{
			KillTempalteEnemyGainTotal = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 15)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (ChangeFormTotal == null || ChangeFormTotal.Length != elementsCount2)
				{
					ChangeFormTotal = new int[elementsCount2];
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					ChangeFormTotal[j] = ((int*)pCurrData)[j];
				}
				pCurrData += 4 * elementsCount2;
			}
			else
			{
				ChangeFormTotal = null;
			}
		}
		if (fieldCount > 16)
		{
			RescueTaiwuTimes = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 17)
		{
			pCurrData += CurrentTargetNeiliAllocProgressDrained.Deserialize(pCurrData);
		}
		if (fieldCount > 18)
		{
			CurrentFormKillAmount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 19)
		{
			pCurrData += CurrentFormNeiliAllocProgressDrained.Deserialize(pCurrData);
		}
		if (fieldCount > 20)
		{
			TaiwuTargetCharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 21)
		{
			TaiwuTargetFiveElementsType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 22)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (TaiwuTransformFiveElementsTotal == null || TaiwuTransformFiveElementsTotal.Length != elementsCount3)
				{
					TaiwuTransformFiveElementsTotal = new int[elementsCount3];
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					TaiwuTransformFiveElementsTotal[k] = ((int*)pCurrData)[k];
				}
				pCurrData += 4 * elementsCount3;
			}
			else
			{
				TaiwuTransformFiveElementsTotal = null;
			}
		}
		if (fieldCount > 23)
		{
			ushort elementsCount4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount4 > 0)
			{
				if (TaiwuTransformFiveElementsCurrent == null || TaiwuTransformFiveElementsCurrent.Length != elementsCount4)
				{
					TaiwuTransformFiveElementsCurrent = new int[elementsCount4];
				}
				for (int l = 0; l < elementsCount4; l++)
				{
					TaiwuTransformFiveElementsCurrent[l] = ((int*)pCurrData)[l];
				}
				pCurrData += 4 * elementsCount4;
			}
			else
			{
				TaiwuTransformFiveElementsCurrent = null;
			}
		}
		if (fieldCount > 24)
		{
			CostedGrowthValue = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 25)
		{
			ushort elementsCount5 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount5 > 0)
			{
				if (NeiliAllocProgressTransferRemain == null || NeiliAllocProgressTransferRemain.Length != elementsCount5)
				{
					NeiliAllocProgressTransferRemain = new float[elementsCount5];
				}
				for (int m = 0; m < elementsCount5; m++)
				{
					NeiliAllocProgressTransferRemain[m] = ((float*)pCurrData)[m];
				}
				pCurrData += 4 * elementsCount5;
			}
			else
			{
				NeiliAllocProgressTransferRemain = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
