using System;
using System.Collections.Generic;
using Config;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item;

[SerializableGameData(IsExtensible = true)]
public class PoisonSlot : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort MedicineTemplateId = 0;

		public const ushort CondensedMedicineTemplateIdList = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "MedicineTemplateId", "CondensedMedicineTemplateIdList" };
	}

	public static readonly int MaxMedicineCount = 3;

	[SerializableGameDataField]
	public short MedicineTemplateId = -1;

	[SerializableGameDataField]
	public List<short> CondensedMedicineTemplateIdList;

	public static int MaxCondensedMedicineCount => MaxMedicineCount - 1;

	public bool IsCondensed
	{
		get
		{
			if (IsValid)
			{
				List<short> condensedMedicineTemplateIdList = CondensedMedicineTemplateIdList;
				if (condensedMedicineTemplateIdList == null)
				{
					return false;
				}
				return condensedMedicineTemplateIdList.Count > 0;
			}
			return false;
		}
	}

	public int CurrentMedicineCount => (IsValid ? 1 : 0) + (CondensedMedicineTemplateIdList?.Count ?? 0);

	public bool MedicineCountIsMax => CurrentMedicineCount == MaxMedicineCount;

	public bool IsValid => MedicineTemplateId >= 0;

	public MedicineItem MedicineConfig
	{
		get
		{
			if (!IsValid)
			{
				return null;
			}
			return Medicine.Instance[MedicineTemplateId];
		}
	}

	public bool IsAddPoison
	{
		get
		{
			MedicineItem medicineConfig = MedicineConfig;
			if (medicineConfig == null)
			{
				return false;
			}
			return medicineConfig.EffectType == EMedicineEffectType.ApplyPoison;
		}
	}

	public unsafe PoisonsAndLevels GetPoisonsAndLevels()
	{
		PoisonsAndLevels poisons = default(PoisonsAndLevels);
		poisons.Initialize();
		if (IsValid && IsAddPoison)
		{
			poisons.Values[MedicineConfig.PoisonType] = GetPoisonValue();
			poisons.Levels[MedicineConfig.PoisonType] = (sbyte)MedicineConfig.EffectThresholdValue;
		}
		return poisons;
	}

	public short GetPoisonValue()
	{
		if (IsValid && IsAddPoison)
		{
			short value = MedicineConfig.EffectValue;
			if (IsCondensed && MedicineCountIsMax)
			{
				foreach (short templateId in CondensedMedicineTemplateIdList)
				{
					value += Medicine.Instance[templateId].EffectValue;
				}
				int bonus = GlobalConfig.Instance.CondensedPoisonValueBonus;
				value = Convert.ToInt16(value * (100 + bonus) / CurrentMedicineCount / 100);
			}
			return value;
		}
		return 0;
	}

	public void SetPoison(short materialTemplateId, IReadOnlyList<short> condensedMedicineTemplateIdList)
	{
		MedicineTemplateId = materialTemplateId;
		CondensedMedicineTemplateIdList?.Clear();
		if (condensedMedicineTemplateIdList == null || condensedMedicineTemplateIdList.Count <= 0)
		{
			return;
		}
		if (condensedMedicineTemplateIdList.Count != MaxCondensedMedicineCount)
		{
			throw new Exception("Condensed medicine count is wrong.");
		}
		foreach (short id in condensedMedicineTemplateIdList)
		{
			MedicineItem config = Medicine.Instance[id];
			if (MedicineConfig.PoisonType != config.PoisonType)
			{
				throw new Exception("Condensed medicine poison type is not same.");
			}
			if (MedicineConfig.EffectThresholdValue != config.EffectThresholdValue)
			{
				throw new Exception("Condensed medicine poison level is not same.");
			}
		}
		if (CondensedMedicineTemplateIdList == null)
		{
			CondensedMedicineTemplateIdList = new List<short>(2);
		}
		CondensedMedicineTemplateIdList.AddRange(condensedMedicineTemplateIdList);
	}

	public bool IsSameType(short templateId)
	{
		if (IsValid && templateId >= 0)
		{
			MedicineItem medicineItem = Medicine.Instance[MedicineTemplateId];
			MedicineItem targetConfig = Medicine.Instance[templateId];
			return medicineItem.PoisonType == targetConfig.PoisonType;
		}
		return false;
	}

	public sbyte GetPoisonType()
	{
		if (MedicineTemplateId < 0)
		{
			return -1;
		}
		return MedicineConfig.PoisonType;
	}

	public List<short> GetAllMedicineTemplateId(bool includeCondensed = false)
	{
		if (!IsValid)
		{
			return null;
		}
		List<short> list = new List<short>();
		list.Add(MedicineTemplateId);
		if (IsCondensed && includeCondensed)
		{
			list.AddRange(CondensedMedicineTemplateIdList);
		}
		return list;
	}

	public void Clear()
	{
		MedicineTemplateId = -1;
		CondensedMedicineTemplateIdList?.Clear();
	}

	public bool SameOf(PoisonSlot other)
	{
		if (this == other)
		{
			return true;
		}
		if (other == null)
		{
			if (!IsValid)
			{
				return !IsCondensed;
			}
			return false;
		}
		if (MedicineTemplateId != other.MedicineTemplateId)
		{
			return false;
		}
		int count = CondensedMedicineTemplateIdList?.Count ?? 0;
		int otherCount = other.CondensedMedicineTemplateIdList?.Count ?? 0;
		if (count != otherCount)
		{
			return false;
		}
		if (count == 0)
		{
			return true;
		}
		for (int i = 0; i < count; i++)
		{
			if (CondensedMedicineTemplateIdList[i] != other.CondensedMedicineTemplateIdList[i])
			{
				return false;
			}
		}
		return true;
	}

	public PoisonSlot()
	{
	}

	public PoisonSlot(PoisonSlot other)
	{
		MedicineTemplateId = other.MedicineTemplateId;
		CondensedMedicineTemplateIdList = ((other.CondensedMedicineTemplateIdList == null) ? null : new List<short>(other.CondensedMedicineTemplateIdList));
	}

	public void Assign(PoisonSlot other)
	{
		MedicineTemplateId = other.MedicineTemplateId;
		CondensedMedicineTemplateIdList = ((other.CondensedMedicineTemplateIdList == null) ? null : new List<short>(other.CondensedMedicineTemplateIdList));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((CondensedMedicineTemplateIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CondensedMedicineTemplateIdList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		*(short*)pCurrData = MedicineTemplateId;
		pCurrData += 2;
		if (CondensedMedicineTemplateIdList != null)
		{
			int elementsCount = CondensedMedicineTemplateIdList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = CondensedMedicineTemplateIdList[i];
			}
			pCurrData += 2 * elementsCount;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			MedicineTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (CondensedMedicineTemplateIdList == null)
				{
					CondensedMedicineTemplateIdList = new List<short>(elementsCount);
				}
				else
				{
					CondensedMedicineTemplateIdList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					CondensedMedicineTemplateIdList.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				CondensedMedicineTemplateIdList?.Clear();
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
