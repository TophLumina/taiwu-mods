using System.Collections.Generic;
using System.Linq;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 战败标记集合
/// </summary>
public class DefeatMarkCollection : ISerializableGameData
{
	/// <summary>
	/// 外伤标记数量
	/// </summary>
	[SerializableGameDataField]
	public byte[] OuterInjuryMarkList = new byte[7];

	/// <summary>
	/// 内伤标记数量
	/// </summary>
	[SerializableGameDataField]
	public byte[] InnerInjuryMarkList = new byte[7];

	/// <summary>
	/// 破绽标记列表
	/// </summary>
	[SerializableGameDataField]
	public ByteList[] FlawMarkList = new ByteList[7];

	/// <summary>
	/// 点穴标记列表
	/// </summary>
	[SerializableGameDataField]
	public ByteList[] AcupointMarkList = new ByteList[7];

	/// <summary>
	/// 中毒标记数量
	/// </summary>
	[SerializableGameDataField]
	public byte[] PoisonMarkList = new byte[6];

	/// <summary>
	/// 心神标记来源功法列表
	/// </summary>
	[SerializableGameDataField]
	public List<bool> MindMarkList = new List<bool>();

	/// <summary>
	/// 必死标记来源功法列表
	/// </summary>
	[SerializableGameDataField]
	public List<CombatSkillKey> DieMarkList = new List<CombatSkillKey>();

	/// <summary>
	/// 重创标记数量
	/// </summary>
	[SerializableGameDataField]
	public int FatalDamageMarkCount;

	/// <summary>
	/// 愈合标记数量
	/// </summary>
	[SerializableGameDataField]
	public int ScarMarkCount;

	/// <summary>
	/// 疲敝标记数量
	/// </summary>
	[SerializableGameDataField]
	public int TiredMarkCount;

	/// <summary>
	/// 蛊虫标记数量
	/// </summary>
	[SerializableGameDataField]
	public sbyte WugMarkCount;

	/// <summary>
	/// 内息标记数量
	/// </summary>
	[SerializableGameDataField]
	public sbyte QiDisorderMarkCount;

	/// <summary>
	/// 状态标记数量
	/// </summary>
	[SerializableGameDataField]
	public sbyte StateMarkCount;

	/// <summary>
	/// 真气标记数量
	/// </summary>
	[SerializableGameDataField]
	public (sbyte scatter, sbyte bulge) NeiliAllocationMarkCount = (scatter: 0, bulge: 0);

	/// <summary>
	/// 健康标记数量
	/// </summary>
	[SerializableGameDataField]
	public sbyte HealthMarkCount;

	private static short QiDisorderFirstExtra => GlobalConfig.Instance.DefeatMarkQiDisorderFirstExtra;

	private static short QiDisorderThreshold => GlobalConfig.Instance.DefeatMarkQiDisorderThreshold;

	/// <summary>
	/// 枚举所有战败标记键
	/// </summary>
	public IEnumerable<DefeatMarkKey> GetAllKeys(short oldDisorderOfQi, PoisonInts oldPoisons, Injuries oldInjuries)
	{
		for (int i = 0; i < TiredMarkCount; i++)
		{
			yield return EMarkType.Tired;
		}
		for (int i = 0; i < ScarMarkCount; i++)
		{
			yield return EMarkType.Scar;
		}
		for (int i = 0; i < DieMarkList.Count; i++)
		{
			yield return EMarkType.Die;
		}
		for (int i = 0; i < HealthMarkCount; i++)
		{
			yield return EMarkType.Health;
		}
		for (int i = 0; i < WugMarkCount; i++)
		{
			yield return EMarkType.Wug;
		}
		for (int i = 0; i < StateMarkCount; i++)
		{
			yield return EMarkType.State;
		}
		for (int i = 0; i < NeiliAllocationMarkCount.scatter; i++)
		{
			yield return EMarkType.NeiliAllocation;
		}
		for (int i = 0; i < NeiliAllocationMarkCount.bulge; i++)
		{
			yield return (markType: EMarkType.NeiliAllocation, subType: 1);
		}
		sbyte oldMarkCountQiDisorder = CalcQiDisorderMarkCount(oldDisorderOfQi);
		for (int i = 0; i < QiDisorderMarkCount; i++)
		{
			yield return (markType: EMarkType.QiDisorder, subType: 0, subType2: (i < oldMarkCountQiDisorder) ? 1 : 0);
		}
		for (sbyte order = 0; order < 6; order++)
		{
			sbyte type = PoisonType.GetTypeBySortingOrder(order);
			int i = PoisonsAndLevels.CalcPoisonedLevel(oldPoisons[type]);
			for (int j = 0; j < PoisonMarkList[type]; j++)
			{
				yield return (markType: EMarkType.Poison, subType: type, subType2: (j < i) ? 1 : 0);
			}
		}
		for (sbyte order = 0; order < 7; order++)
		{
			sbyte type = oldInjuries.Get(order, isInnerInjury: false);
			for (int i = 0; i < OuterInjuryMarkList[order]; i++)
			{
				yield return (markType: EMarkType.Outer, subType: order, subType2: (i < type) ? 1 : 0);
			}
		}
		for (sbyte order = 0; order < 7; order++)
		{
			sbyte type = oldInjuries.Get(order, isInnerInjury: true);
			for (int i = 0; i < InnerInjuryMarkList[order]; i++)
			{
				yield return (markType: EMarkType.Inner, subType: order, subType2: (i < type) ? 1 : 0);
			}
		}
		for (sbyte order = 0; order < 7; order++)
		{
			foreach (byte flaw in FlawMarkList[order])
			{
				yield return (markType: EMarkType.Flaw, subType: order, subType2: flaw);
			}
		}
		for (sbyte order = 0; order < 7; order++)
		{
			foreach (byte acupoint in AcupointMarkList[order])
			{
				yield return (markType: EMarkType.Acupoint, subType: order, subType2: acupoint);
			}
		}
		for (int i = 0; i < FatalDamageMarkCount; i++)
		{
			yield return EMarkType.Fatal;
		}
		for (int i = 0; i < MindMarkList.Count; i++)
		{
			yield return (markType: EMarkType.Mind, subType: 0, subType2: MindMarkList[i] ? 1 : 0);
		}
	}

	/// <summary>
	/// 枚举所有战败标记键
	/// </summary>
	public IEnumerable<DefeatMarkKey> GetAllKeys(ICombatCharacterBridge combatChar)
	{
		return GetAllKeys(combatChar.GetOldDisorderOfQi(), combatChar.GetOldPoison(), combatChar.GetOldInjuries());
	}

	/// <summary>
	/// 枚举所有战败标记键，不判断新旧
	/// </summary>
	public IEnumerable<DefeatMarkKey> GetAllKeysWithoutOld()
	{
		PoisonInts oldPoisons = default(PoisonInts);
		oldPoisons.Initialize();
		Injuries oldInjuries = default(Injuries);
		oldInjuries.Initialize();
		return GetAllKeys(0, oldPoisons, oldInjuries);
	}

	/// <summary>
	/// 计算内息标记数量
	/// </summary>
	public static sbyte CalcQiDisorderMarkCount(int disorderOfQi)
	{
		return (sbyte)MathUtils.Clamp((disorderOfQi - QiDisorderFirstExtra) / QiDisorderThreshold, 0, 6);
	}

	/// <summary>
	/// 计算内息标记阈值
	/// </summary>
	public static short CalcQiDisorderMarkThreshold(int disorderOfQi)
	{
		if (CalcQiDisorderMarkCount(disorderOfQi) != 0)
		{
			return QiDisorderThreshold;
		}
		return (short)(QiDisorderThreshold + QiDisorderFirstExtra);
	}

	/// <summary>
	/// 计算健康标记数量
	/// </summary>
	public static sbyte GetHealthMarkCount(EHealthType healthType)
	{
		return healthType switch
		{
			EHealthType.Dying => 8, 
			EHealthType.CriticallyIll => 6, 
			EHealthType.Weak => 4, 
			EHealthType.Sick => 2, 
			_ => 0, 
		};
	}

	/// <summary>
	/// 同步失神标记
	/// </summary>
	public bool SyncMindMark(IList<bool> newMindMark)
	{
		CollectionUtils.Sort(newMindMark, (bool a, bool b) => b.CompareTo(a));
		bool anyChanged;
		if (newMindMark.SequenceEqual(MindMarkList))
		{
			anyChanged = false;
		}
		else
		{
			anyChanged = true;
			MindMarkList.Clear();
			MindMarkList.AddRange(newMindMark);
		}
		return anyChanged;
	}

	/// <summary>
	/// 获取标记总数
	/// </summary>
	public int GetTotalCount()
	{
		return OuterInjuryMarkList.Sum() + InnerInjuryMarkList.Sum() + GetTotalFlawCount() + GetTotalAcupointCount() + PoisonMarkList.Sum() + MindMarkList.Count + DieMarkList.Count + FatalDamageMarkCount + ScarMarkCount + TiredMarkCount + WugMarkCount + QiDisorderMarkCount + StateMarkCount + NeiliAllocationMarkCount.scatter + NeiliAllocationMarkCount.bulge + HealthMarkCount;
	}

	/// <summary>
	/// 获取伤势标记总数
	/// </summary>
	public int GetTotalInjuryCount()
	{
		return 0 + OuterInjuryMarkList.Sum() + InnerInjuryMarkList.Sum();
	}

	/// <summary>
	/// 获取毒素标记总数
	/// </summary>
	public int GetTotalPoisonCount()
	{
		int totalCount = 0;
		for (int i = 0; i < PoisonMarkList.Length; i++)
		{
			totalCount += PoisonMarkList[i];
		}
		return totalCount;
	}

	/// <summary>
	/// 获取破绽标记总数
	/// </summary>
	public int GetTotalFlawCount()
	{
		int totalCount = 0;
		for (sbyte part = 0; part < 7; part++)
		{
			totalCount += FlawMarkList[part].Count;
		}
		return totalCount;
	}

	/// <summary>
	/// 获取点穴标记总数
	/// </summary>
	public int GetTotalAcupointCount()
	{
		int totalCount = 0;
		for (sbyte part = 0; part < 7; part++)
		{
			totalCount += AcupointMarkList[part].Count;
		}
		return totalCount;
	}

	/// <summary>
	/// 清除所有标记
	/// </summary>
	public void Clear()
	{
		for (sbyte part = 0; part < 7; part++)
		{
			OuterInjuryMarkList[part] = 0;
			InnerInjuryMarkList[part] = 0;
			FlawMarkList[part].Clear();
			AcupointMarkList[part].Clear();
		}
		for (int i = 0; i < 6; i++)
		{
			PoisonMarkList[i] = 0;
		}
		MindMarkList.Clear();
		DieMarkList.Clear();
		FatalDamageMarkCount = 0;
		WugMarkCount = (QiDisorderMarkCount = (StateMarkCount = (HealthMarkCount = 0)));
		NeiliAllocationMarkCount = (scatter: 0, bulge: 0);
	}

	/// <summary>
	/// 判断相比于指定标记集合是否新增了任何标记
	/// </summary>
	public bool AnyMarkAdded(DefeatMarkCollection other)
	{
		for (sbyte part = 0; part < 7; part++)
		{
			if (OuterInjuryMarkList[part] > other.OuterInjuryMarkList[part] || InnerInjuryMarkList[part] > other.InnerInjuryMarkList[part] || FlawMarkList[part].Count > other.FlawMarkList[part].Count || AcupointMarkList[part].Count > other.AcupointMarkList[part].Count)
			{
				return true;
			}
		}
		for (sbyte type = 0; type < 6; type++)
		{
			if (PoisonMarkList[type] > other.PoisonMarkList[type])
			{
				return true;
			}
		}
		if (MindMarkList.Count > other.MindMarkList.Count || DieMarkList.Count > other.DieMarkList.Count)
		{
			return true;
		}
		if (FatalDamageMarkCount > other.FatalDamageMarkCount)
		{
			return true;
		}
		if (WugMarkCount > other.WugMarkCount)
		{
			return true;
		}
		if (QiDisorderMarkCount > other.QiDisorderMarkCount)
		{
			return true;
		}
		if (StateMarkCount > other.StateMarkCount)
		{
			return true;
		}
		if (NeiliAllocationMarkCount.scatter > other.NeiliAllocationMarkCount.scatter || NeiliAllocationMarkCount.bulge > other.NeiliAllocationMarkCount.bulge)
		{
			return true;
		}
		if (HealthMarkCount > other.HealthMarkCount)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public DefeatMarkCollection()
	{
		for (sbyte part = 0; part < 7; part++)
		{
			FlawMarkList[part] = new ByteList();
			AcupointMarkList[part] = new ByteList();
		}
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public DefeatMarkCollection(DefeatMarkCollection other)
	{
		byte[] item = other.OuterInjuryMarkList;
		int elementsCount = item.Length;
		OuterInjuryMarkList = new byte[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			OuterInjuryMarkList[i] = item[i];
		}
		byte[] item2 = other.InnerInjuryMarkList;
		int elementsCount2 = item2.Length;
		InnerInjuryMarkList = new byte[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			InnerInjuryMarkList[j] = item2[j];
		}
		ByteList[] item3 = other.FlawMarkList;
		int elementsCount3 = item3.Length;
		FlawMarkList = new ByteList[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			FlawMarkList[k] = new ByteList(item3[k]);
		}
		ByteList[] item4 = other.AcupointMarkList;
		int elementsCount4 = item4.Length;
		AcupointMarkList = new ByteList[elementsCount4];
		for (int l = 0; l < elementsCount4; l++)
		{
			AcupointMarkList[l] = new ByteList(item4[l]);
		}
		byte[] item5 = other.PoisonMarkList;
		int elementsCount5 = item5.Length;
		PoisonMarkList = new byte[elementsCount5];
		for (int m = 0; m < elementsCount5; m++)
		{
			PoisonMarkList[m] = item5[m];
		}
		MindMarkList = ((other.MindMarkList == null) ? null : new List<bool>(other.MindMarkList));
		DieMarkList = ((other.DieMarkList == null) ? null : new List<CombatSkillKey>(other.DieMarkList));
		FatalDamageMarkCount = other.FatalDamageMarkCount;
		ScarMarkCount = other.ScarMarkCount;
		TiredMarkCount = other.TiredMarkCount;
		WugMarkCount = other.WugMarkCount;
		QiDisorderMarkCount = other.QiDisorderMarkCount;
		StateMarkCount = other.StateMarkCount;
		NeiliAllocationMarkCount = other.NeiliAllocationMarkCount;
		HealthMarkCount = other.HealthMarkCount;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(DefeatMarkCollection other)
	{
		byte[] item = other.OuterInjuryMarkList;
		int elementsCount = item.Length;
		OuterInjuryMarkList = new byte[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			OuterInjuryMarkList[i] = item[i];
		}
		byte[] item2 = other.InnerInjuryMarkList;
		int elementsCount2 = item2.Length;
		InnerInjuryMarkList = new byte[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			InnerInjuryMarkList[j] = item2[j];
		}
		ByteList[] item3 = other.FlawMarkList;
		int elementsCount3 = item3.Length;
		FlawMarkList = new ByteList[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			FlawMarkList[k] = new ByteList(item3[k]);
		}
		ByteList[] item4 = other.AcupointMarkList;
		int elementsCount4 = item4.Length;
		AcupointMarkList = new ByteList[elementsCount4];
		for (int l = 0; l < elementsCount4; l++)
		{
			AcupointMarkList[l] = new ByteList(item4[l]);
		}
		byte[] item5 = other.PoisonMarkList;
		int elementsCount5 = item5.Length;
		PoisonMarkList = new byte[elementsCount5];
		for (int m = 0; m < elementsCount5; m++)
		{
			PoisonMarkList[m] = item5[m];
		}
		MindMarkList = ((other.MindMarkList == null) ? null : new List<bool>(other.MindMarkList));
		DieMarkList = ((other.DieMarkList == null) ? null : new List<CombatSkillKey>(other.DieMarkList));
		FatalDamageMarkCount = other.FatalDamageMarkCount;
		ScarMarkCount = other.ScarMarkCount;
		TiredMarkCount = other.TiredMarkCount;
		WugMarkCount = other.WugMarkCount;
		QiDisorderMarkCount = other.QiDisorderMarkCount;
		StateMarkCount = other.StateMarkCount;
		NeiliAllocationMarkCount = other.NeiliAllocationMarkCount;
		HealthMarkCount = other.HealthMarkCount;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 18;
		totalSize = ((OuterInjuryMarkList == null) ? (totalSize + 2) : (totalSize + (2 + OuterInjuryMarkList.Length)));
		totalSize = ((InnerInjuryMarkList == null) ? (totalSize + 2) : (totalSize + (2 + InnerInjuryMarkList.Length)));
		if (FlawMarkList != null)
		{
			totalSize += 2;
			int elementsCount = FlawMarkList.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				ByteList element = FlawMarkList[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (AcupointMarkList != null)
		{
			totalSize += 2;
			int elementsCount2 = AcupointMarkList.Length;
			for (int j = 0; j < elementsCount2; j++)
			{
				ByteList element2 = AcupointMarkList[j];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + element2.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((PoisonMarkList == null) ? (totalSize + 2) : (totalSize + (2 + PoisonMarkList.Length)));
		totalSize = ((MindMarkList == null) ? (totalSize + 2) : (totalSize + (2 + MindMarkList.Count)));
		totalSize = ((DieMarkList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * DieMarkList.Count)));
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
		if (OuterInjuryMarkList != null)
		{
			int elementsCount = OuterInjuryMarkList.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = OuterInjuryMarkList[i];
			}
			pCurrData += elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (InnerInjuryMarkList != null)
		{
			int elementsCount2 = InnerInjuryMarkList.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData[j] = InnerInjuryMarkList[j];
			}
			pCurrData += elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FlawMarkList != null)
		{
			int elementsCount3 = FlawMarkList.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				ByteList element = FlawMarkList[k];
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
		if (AcupointMarkList != null)
		{
			int elementsCount4 = AcupointMarkList.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				ByteList element2 = AcupointMarkList[l];
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
		if (PoisonMarkList != null)
		{
			int elementsCount5 = PoisonMarkList.Length;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				pCurrData[m] = PoisonMarkList[m];
			}
			pCurrData += elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (MindMarkList != null)
		{
			int elementsCount6 = MindMarkList.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				pCurrData[n] = (MindMarkList[n] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (DieMarkList != null)
		{
			int elementsCount7 = DieMarkList.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				pCurrData += DieMarkList[num].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = FatalDamageMarkCount;
		pCurrData += 4;
		*(int*)pCurrData = ScarMarkCount;
		pCurrData += 4;
		*(int*)pCurrData = TiredMarkCount;
		pCurrData += 4;
		*pCurrData = (byte)WugMarkCount;
		pCurrData++;
		*pCurrData = (byte)QiDisorderMarkCount;
		pCurrData++;
		*pCurrData = (byte)StateMarkCount;
		pCurrData++;
		pCurrData += SerializationHelper.Serialize(pCurrData, NeiliAllocationMarkCount);
		*pCurrData = (byte)HealthMarkCount;
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (OuterInjuryMarkList == null || OuterInjuryMarkList.Length != elementsCount)
			{
				OuterInjuryMarkList = new byte[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				OuterInjuryMarkList[i] = pCurrData[i];
			}
			pCurrData += (int)elementsCount;
		}
		else
		{
			OuterInjuryMarkList = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (InnerInjuryMarkList == null || InnerInjuryMarkList.Length != elementsCount2)
			{
				InnerInjuryMarkList = new byte[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				InnerInjuryMarkList[j] = pCurrData[j];
			}
			pCurrData += (int)elementsCount2;
		}
		else
		{
			InnerInjuryMarkList = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (FlawMarkList == null || FlawMarkList.Length != elementsCount3)
			{
				FlawMarkList = new ByteList[elementsCount3];
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					ByteList element = FlawMarkList[k] ?? new ByteList();
					pCurrData += element.Deserialize(pCurrData);
					FlawMarkList[k] = element;
				}
				else
				{
					FlawMarkList[k] = null;
				}
			}
		}
		else
		{
			FlawMarkList = null;
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (AcupointMarkList == null || AcupointMarkList.Length != elementsCount4)
			{
				AcupointMarkList = new ByteList[elementsCount4];
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num2 > 0)
				{
					ByteList element2 = AcupointMarkList[l] ?? new ByteList();
					pCurrData += element2.Deserialize(pCurrData);
					AcupointMarkList[l] = element2;
				}
				else
				{
					AcupointMarkList[l] = null;
				}
			}
		}
		else
		{
			AcupointMarkList = null;
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (PoisonMarkList == null || PoisonMarkList.Length != elementsCount5)
			{
				PoisonMarkList = new byte[elementsCount5];
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				PoisonMarkList[m] = pCurrData[m];
			}
			pCurrData += (int)elementsCount5;
		}
		else
		{
			PoisonMarkList = null;
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (MindMarkList == null)
			{
				MindMarkList = new List<bool>(elementsCount6);
			}
			else
			{
				MindMarkList.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				MindMarkList.Add(pCurrData[n] != 0);
			}
			pCurrData += (int)elementsCount6;
		}
		else
		{
			MindMarkList?.Clear();
		}
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (DieMarkList == null)
			{
				DieMarkList = new List<CombatSkillKey>(elementsCount7);
			}
			else
			{
				DieMarkList.Clear();
			}
			for (int num3 = 0; num3 < elementsCount7; num3++)
			{
				CombatSkillKey element3 = default(CombatSkillKey);
				pCurrData += element3.Deserialize(pCurrData);
				DieMarkList.Add(element3);
			}
		}
		else
		{
			DieMarkList?.Clear();
		}
		FatalDamageMarkCount = *(int*)pCurrData;
		pCurrData += 4;
		ScarMarkCount = *(int*)pCurrData;
		pCurrData += 4;
		TiredMarkCount = *(int*)pCurrData;
		pCurrData += 4;
		WugMarkCount = (sbyte)(*pCurrData);
		pCurrData++;
		QiDisorderMarkCount = (sbyte)(*pCurrData);
		pCurrData++;
		StateMarkCount = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += SerializationHelper.Deserialize(pCurrData, out NeiliAllocationMarkCount);
		HealthMarkCount = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
