using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect;

[SerializableGameData(NotForArchive = true)]
public struct CastBoostEffectDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	private sbyte _internalType;

	[SerializableGameDataField]
	private int _internalParam0;

	[SerializableGameDataField]
	private int _internalParam1;

	[SerializableGameDataField]
	public CombatSkillEffectDescriptionDisplayData EffectDescription;

	public ECastBoostType Type => (ECastBoostType)_internalType;

	public int EffectId => EffectDescription.EffectId;

	public byte NeiliAllocationType => (byte)((Type == ECastBoostType.CostNeiliAllocation) ? ((uint)_internalParam0) : 4u);

	public int NeiliAllocationValue
	{
		get
		{
			if (Type != ECastBoostType.CostNeiliAllocation)
			{
				return -1;
			}
			return _internalParam1;
		}
	}

	public int AddQiDisorder
	{
		get
		{
			if (Type != ECastBoostType.CostClearDefend)
			{
				return -1;
			}
			return _internalParam0;
		}
	}

	public short WugMedicineTemplateId => (short)((Type == ECastBoostType.CostWugKing) ? _internalParam0 : (-1));

	public int WugKingCount
	{
		get
		{
			if (Type != ECastBoostType.CostWugKing)
			{
				return 0;
			}
			return _internalParam1;
		}
	}

	public static CastBoostEffectDisplayData GenerateNeiliAllocation(CombatSkillEffectDescriptionDisplayData desc, byte type, int value)
	{
		return new CastBoostEffectDisplayData
		{
			_internalType = 0,
			_internalParam0 = type,
			_internalParam1 = value,
			EffectDescription = desc
		};
	}

	public static CastBoostEffectDisplayData GenerateWugKing(CombatSkillEffectDescriptionDisplayData desc, short wugTemplateId, int count)
	{
		return new CastBoostEffectDisplayData
		{
			_internalType = 1,
			_internalParam0 = wugTemplateId,
			_internalParam1 = count,
			EffectDescription = desc
		};
	}

	public static CastBoostEffectDisplayData GenerateClearDefend(CombatSkillEffectDescriptionDisplayData desc, int value)
	{
		return new CastBoostEffectDisplayData
		{
			_internalType = 2,
			_internalParam0 = value,
			EffectDescription = desc
		};
	}

	public CastBoostEffectDisplayData(CastBoostEffectDisplayData other)
	{
		_internalType = other._internalType;
		_internalParam0 = other._internalParam0;
		_internalParam1 = other._internalParam1;
		EffectDescription = new CombatSkillEffectDescriptionDisplayData(other.EffectDescription);
	}

	public void Assign(CastBoostEffectDisplayData other)
	{
		_internalType = other._internalType;
		_internalParam0 = other._internalParam0;
		_internalParam1 = other._internalParam1;
		EffectDescription = new CombatSkillEffectDescriptionDisplayData(other.EffectDescription);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		totalSize += EffectDescription.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)_internalType;
		pCurrData++;
		*(int*)pCurrData = _internalParam0;
		pCurrData += 4;
		*(int*)pCurrData = _internalParam1;
		pCurrData += 4;
		int fieldSize = EffectDescription.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
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
		_internalType = (sbyte)(*pCurrData);
		pCurrData++;
		_internalParam0 = *(int*)pCurrData;
		pCurrData += 4;
		_internalParam1 = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += EffectDescription.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
