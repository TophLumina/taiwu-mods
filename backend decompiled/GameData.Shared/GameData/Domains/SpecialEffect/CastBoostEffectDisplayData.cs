using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect;

/// <summary>
/// 施展增幅效果数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct CastBoostEffectDisplayData : ISerializableGameData
{
	/// <summary>
	/// 序列化使用的类型
	/// </summary>
	[SerializableGameDataField]
	private sbyte _internalType;

	/// <summary>
	/// 序列化使用的参数 0
	/// </summary>
	[SerializableGameDataField]
	private int _internalParam0;

	/// <summary>
	/// 序列化使用的参数 1
	/// </summary>
	[SerializableGameDataField]
	private int _internalParam1;

	/// <summary>
	/// 特效描述数据
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillEffectDescriptionDisplayData EffectDescription;

	/// <summary>
	/// 施展增幅类型
	/// </summary>
	public ECastBoostType Type => (ECastBoostType)_internalType;

	/// <summary>
	/// 特效 ID
	/// </summary>
	public int EffectId => EffectDescription.EffectId;

	/// <summary>
	/// 消耗真气类型
	/// <see cref="T:GameData.Domains.Character.NeiliAllocationType" />
	/// </summary>
	public byte NeiliAllocationType => (byte)((Type == ECastBoostType.CostNeiliAllocation) ? ((uint)_internalParam0) : 4u);

	/// <summary>
	/// 消耗真气值
	/// </summary>
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

	/// <summary>
	/// 增加紊乱值
	/// </summary>
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

	/// <summary>
	/// 王蛊药毒表模板 ID
	/// </summary>
	public short WugMedicineTemplateId => (short)((Type == ECastBoostType.CostWugKing) ? _internalParam0 : (-1));

	/// <summary>
	/// 当前持有王蛊数量
	/// </summary>
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

	/// <summary>
	/// 创建消耗真气的施展增幅数据
	/// </summary>
	/// <param name="desc"></param>
	/// <param name="type">消耗真气类型</param>
	/// <param name="value">消耗真气值</param>
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

	/// <summary>
	/// 创建消耗王蛊的施展增幅数据
	/// </summary>
	/// <param name="desc"></param>
	/// <param name="wugTemplateId">王蛊模板 ID <see cref="T:Config.Medicine" /></param>
	/// <param name="count">当前持有数量</param>
	/// <returns></returns>
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

	/// <summary>
	/// 创建产生紊乱消除护体的施展增幅数据
	/// </summary>
	/// <param name="desc"></param>
	/// <param name="value">增加的紊乱值</param>
	/// <returns></returns>
	public static CastBoostEffectDisplayData GenerateClearDefend(CombatSkillEffectDescriptionDisplayData desc, int value)
	{
		return new CastBoostEffectDisplayData
		{
			_internalType = 2,
			_internalParam0 = value,
			EffectDescription = desc
		};
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CastBoostEffectDisplayData(CastBoostEffectDisplayData other)
	{
		_internalType = other._internalType;
		_internalParam0 = other._internalParam0;
		_internalParam1 = other._internalParam1;
		EffectDescription = new CombatSkillEffectDescriptionDisplayData(other.EffectDescription);
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CastBoostEffectDisplayData other)
	{
		_internalType = other._internalType;
		_internalParam0 = other._internalParam0;
		_internalParam1 = other._internalParam1;
		EffectDescription = new CombatSkillEffectDescriptionDisplayData(other.EffectDescription);
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
