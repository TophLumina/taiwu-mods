using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 功法禁用原因 
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct CombatSkillBanReasonData : ISerializableGameData
{
	/// <summary>
	/// 禁用原因类型，用于序列化传输
	/// </summary>
	[SerializableGameDataField]
	private sbyte _internalType;

	/// <summary>
	/// 禁用原因参数，用于序列化传输
	/// </summary>
	[SerializableGameDataField]
	private sbyte _internalParam0;

	/// <summary>
	/// 禁用原因参数，用于序列化传输
	/// </summary>
	[SerializableGameDataField]
	private sbyte _internalParam1;

	/// <summary>
	/// 禁用原因参数，用于序列化传输
	/// </summary>
	[SerializableGameDataField]
	private sbyte _internalParam2;

	/// <summary>
	/// 所需式
	/// </summary>
	[SerializableGameDataField]
	public List<NeedTrick> CostTricks;

	/// <summary>
	/// 拥有式
	/// </summary>
	[SerializableGameDataField]
	public List<NeedTrick> HasTricks;

	/// <summary>
	/// 禁用原因类型
	/// </summary>
	public ECombatSkillBanReasonType Type => (ECombatSkillBanReasonType)_internalType;

	/// <summary>
	/// 消耗脚力
	/// </summary>
	public int CostMobility
	{
		get
		{
			if (Type != ECombatSkillBanReasonType.MobilityNotEnough)
			{
				return 0;
			}
			return _internalParam0;
		}
	}

	/// <summary>
	/// 拥有脚力
	/// </summary>
	public int HasMobility
	{
		get
		{
			if (Type != ECombatSkillBanReasonType.MobilityNotEnough)
			{
				return 0;
			}
			return _internalParam1;
		}
	}

	/// <summary>
	/// 消耗提气
	/// </summary>
	public int CostBreath
	{
		get
		{
			if (Type != ECombatSkillBanReasonType.BreathNotEnough)
			{
				return 0;
			}
			return _internalParam0;
		}
	}

	/// <summary>
	/// 拥有提气
	/// </summary>
	public int HasBreath
	{
		get
		{
			if (Type != ECombatSkillBanReasonType.BreathNotEnough)
			{
				return 0;
			}
			return _internalParam1;
		}
	}

	/// <summary>
	/// 消耗架势
	/// </summary>
	public int CostStance
	{
		get
		{
			if (Type != ECombatSkillBanReasonType.StanceNotEnough)
			{
				return 0;
			}
			return _internalParam0;
		}
	}

	/// <summary>
	/// 拥有架势
	/// </summary>
	public int HasStance
	{
		get
		{
			if (Type != ECombatSkillBanReasonType.StanceNotEnough)
			{
				return 0;
			}
			return _internalParam1;
		}
	}

	/// <summary>
	/// 消耗蛊引
	/// </summary>
	public int CostWug
	{
		get
		{
			if (Type != ECombatSkillBanReasonType.WugNotEnough)
			{
				return 0;
			}
			return _internalParam0;
		}
	}

	/// <summary>
	/// 拥有蛊引
	/// </summary>
	public int HasWug
	{
		get
		{
			if (Type != ECombatSkillBanReasonType.WugNotEnough)
			{
				return 0;
			}
			return _internalParam1;
		}
	}

	/// <summary>
	/// 消耗真气类型
	/// </summary>
	public int CostNeiliAllocationType
	{
		get
		{
			if (Type != ECombatSkillBanReasonType.NeiliAllocationNotEnough)
			{
				return -1;
			}
			return _internalParam0;
		}
	}

	/// <summary>
	/// 消耗真气值
	/// </summary>
	public int CostNeiliAllocationValue
	{
		get
		{
			if (Type != ECombatSkillBanReasonType.NeiliAllocationNotEnough)
			{
				return 0;
			}
			return _internalParam1;
		}
	}

	/// <summary>
	/// 拥有真气值
	/// </summary>
	public int HasNeiliAllocationValue
	{
		get
		{
			if (Type != ECombatSkillBanReasonType.NeiliAllocationNotEnough)
			{
				return 0;
			}
			return _internalParam2;
		}
	}

	/// <summary>
	/// 基于类型的构造方法
	/// </summary>
	public CombatSkillBanReasonData(ECombatSkillBanReasonType type, ICombatSkillBridge combatSkill, ICombatCharacterBridge combatChar)
	{
		_internalType = (sbyte)type;
		_internalParam0 = (_internalParam1 = (_internalParam2 = 0));
		CostTricks = (HasTricks = null);
		CombatSkillItem configData = Config.CombatSkill.Instance[combatSkill.SkillTemplateId];
		switch (type)
		{
		case ECombatSkillBanReasonType.StanceNotEnough:
			_internalParam0 = (sbyte)combatSkill.CostBreathStance.Outer;
			_internalParam1 = (sbyte)Math.Clamp(combatChar.GetStanceValue() * 100 / 4000, 0, 100);
			break;
		case ECombatSkillBanReasonType.BreathNotEnough:
			_internalParam0 = (sbyte)combatSkill.CostBreathStance.Inner;
			_internalParam1 = (sbyte)Math.Clamp(combatChar.GetBreathValue() * 100 / 30000, 0, 100);
			break;
		case ECombatSkillBanReasonType.MobilityNotEnough:
			_internalParam0 = combatSkill.GetCostMobilityPercent();
			_internalParam1 = (sbyte)Math.Clamp(combatChar.GetMobilityValue() * 100 / MoveSpecialConstants.MaxMobility, 0, 100);
			break;
		case ECombatSkillBanReasonType.TrickNotEnough:
			CostTricks = new List<NeedTrick>();
			HasTricks = new List<NeedTrick>();
			combatSkill.GetCostTrick(CostTricks);
			{
				foreach (NeedTrick needTrick in CostTricks)
				{
					NeedTrick needTrick2 = needTrick;
					needTrick2.NeedCount = combatChar.GetTrickCount(needTrick.TrickType);
					NeedTrick hasTrick = needTrick2;
					HasTricks.Add(hasTrick);
				}
				break;
			}
		case ECombatSkillBanReasonType.WugNotEnough:
			_internalParam0 = configData.WugCost;
			_internalParam1 = (sbyte)Math.Clamp((int)combatChar.GetWugCount(), 0, 127);
			break;
		case ECombatSkillBanReasonType.NeiliAllocationNotEnough:
			SetNeiliAllocationParam(combatSkill, combatChar);
			break;
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		case ECombatSkillBanReasonType.None:
		case ECombatSkillBanReasonType.Undefined:
		case ECombatSkillBanReasonType.WeaponTrickMismatch:
		case ECombatSkillBanReasonType.WeaponDestroyed:
		case ECombatSkillBanReasonType.BodyPartBroken:
		case ECombatSkillBanReasonType.SpecialEffectBan:
		case ECombatSkillBanReasonType.CombatConfigBan:
		case ECombatSkillBanReasonType.Silencing:
			break;
		}
	}

	private unsafe void SetNeiliAllocationParam(ICombatSkillBridge combatSkill, ICombatCharacterBridge combatChar)
	{
		(sbyte, sbyte) costNeiliAllocation = combatSkill.GetCostNeiliAllocation();
		NeiliAllocation currNeiliAllocation = combatChar.GetNeiliAllocation();
		(_internalParam0, _) = costNeiliAllocation;
		if (_internalParam0 >= 0)
		{
			_internalParam1 = costNeiliAllocation.Item2;
			_internalParam2 = (sbyte)Math.Clamp((int)currNeiliAllocation.Items[_internalParam0], 0, 127);
		}
	}

	public CombatSkillBanReasonData(CombatSkillBanReasonData other)
	{
		_internalType = other._internalType;
		_internalParam0 = other._internalParam0;
		_internalParam1 = other._internalParam1;
		_internalParam2 = other._internalParam2;
		CostTricks = new List<NeedTrick>(other.CostTricks);
		HasTricks = new List<NeedTrick>(other.HasTricks);
	}

	public void Assign(CombatSkillBanReasonData other)
	{
		_internalType = other._internalType;
		_internalParam0 = other._internalParam0;
		_internalParam1 = other._internalParam1;
		_internalParam2 = other._internalParam2;
		CostTricks = new List<NeedTrick>(other.CostTricks);
		HasTricks = new List<NeedTrick>(other.HasTricks);
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((CostTricks == null) ? (totalSize + 2) : (totalSize + (2 + 4 * CostTricks.Count)));
		totalSize = ((HasTricks == null) ? (totalSize + 2) : (totalSize + (2 + 4 * HasTricks.Count)));
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
		*pCurrData = (byte)_internalType;
		pCurrData++;
		*pCurrData = (byte)_internalParam0;
		pCurrData++;
		*pCurrData = (byte)_internalParam1;
		pCurrData++;
		*pCurrData = (byte)_internalParam2;
		pCurrData++;
		if (CostTricks != null)
		{
			int elementsCount = CostTricks.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += CostTricks[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (HasTricks != null)
		{
			int elementsCount2 = HasTricks.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += HasTricks[j].Serialize(pCurrData);
			}
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
		_internalType = (sbyte)(*pCurrData);
		pCurrData++;
		_internalParam0 = (sbyte)(*pCurrData);
		pCurrData++;
		_internalParam1 = (sbyte)(*pCurrData);
		pCurrData++;
		_internalParam2 = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CostTricks == null)
			{
				CostTricks = new List<NeedTrick>(elementsCount);
			}
			else
			{
				CostTricks.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				NeedTrick element = default(NeedTrick);
				pCurrData += element.Deserialize(pCurrData);
				CostTricks.Add(element);
			}
		}
		else
		{
			CostTricks?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (HasTricks == null)
			{
				HasTricks = new List<NeedTrick>(elementsCount2);
			}
			else
			{
				HasTricks.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				NeedTrick element2 = default(NeedTrick);
				pCurrData += element2.Deserialize(pCurrData);
				HasTricks.Add(element2);
			}
		}
		else
		{
			HasTricks?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
