using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 战斗预约数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct CombatReserveData : ISerializableGameData
{
	/// <summary>
	/// 用于序列化的类型
	/// </summary>
	[SerializableGameDataField]
	private sbyte _internalType;

	/// <summary>
	/// 用于序列化的数据一
	/// </summary>
	[SerializableGameDataField]
	private long _internalValue0;

	/// <summary>
	/// 无效值
	/// </summary>
	public static CombatReserveData Invalid => new CombatReserveData
	{
		_internalType = 0
	};

	/// <summary>
	/// 预约类型
	/// </summary>
	public ECombatReserveType Type => (ECombatReserveType)_internalType;

	/// <summary>
	/// 存在任意预约行为
	/// </summary>
	public bool AnyReserve => Type != ECombatReserveType.Invalid;

	/// <summary>
	/// 需要施展的功法ID
	/// </summary>
	public short NeedUseSkillId
	{
		get
		{
			if (Type != ECombatReserveType.Skill)
			{
				return -1;
			}
			return (short)_internalValue0;
		}
	}

	/// <summary>
	/// 需要显示变招界面
	/// </summary>
	public bool NeedShowChangeTrick => Type == ECombatReserveType.ChangeTrick;

	/// <summary>
	/// 需要切换到的武器
	/// </summary>
	public int NeedChangeWeaponIndex
	{
		get
		{
			if (Type != ECombatReserveType.ChangeWeapon)
			{
				return -1;
			}
			return (int)_internalValue0;
		}
	}

	/// <summary>
	/// 需要解封的武器
	/// </summary>
	public int NeedUnlockWeaponIndex
	{
		get
		{
			if (Type != ECombatReserveType.UnlockAttack)
			{
				return -1;
			}
			return (int)_internalValue0;
		}
	}

	/// <summary>
	/// 需要使用的道具
	/// </summary>
	public ItemKey NeedUseItem
	{
		get
		{
			if (Type != ECombatReserveType.UseItem)
			{
				return ItemKey.Invalid;
			}
			return (ItemKey)(ulong)_internalValue0;
		}
	}

	/// <summary>
	/// 需要进行的其它行为 <see cref="T:GameData.Domains.Combat.OtherActionType" />
	/// </summary>
	public sbyte NeedUseOtherAction
	{
		get
		{
			if (Type != ECombatReserveType.OtherAction)
			{
				return -1;
			}
			return (sbyte)_internalValue0;
		}
	}

	/// <summary>
	/// 同道角色 ID
	/// </summary>
	public int TeammateCharId
	{
		get
		{
			if (Type != ECombatReserveType.TeammateCommand)
			{
				return -1;
			}
			return (int)(_internalValue0 >> 32);
		}
	}

	/// <summary>
	/// 同道指令索引
	/// </summary>
	public int TeammateCmdIndex
	{
		get
		{
			if (Type != ECombatReserveType.TeammateCommand)
			{
				return -1;
			}
			return (int)_internalValue0;
		}
	}

	/// <summary>
	/// 基于功法创建预约数据
	/// </summary>
	public static CombatReserveData CreateSkill(short skillId)
	{
		if (skillId < 0)
		{
			return Invalid;
		}
		return new CombatReserveData
		{
			_internalType = 1,
			_internalValue0 = skillId
		};
	}

	/// <summary>
	/// 基于变招创建预约数据
	/// </summary>
	public static CombatReserveData CreateChangeTrick(bool valid)
	{
		if (!valid)
		{
			return Invalid;
		}
		return new CombatReserveData
		{
			_internalType = 2
		};
	}

	/// <summary>
	/// 基于切换武器创建预约数据
	/// </summary>
	public static CombatReserveData CreateChangeWeapon(int weaponIndex)
	{
		if (weaponIndex < 0)
		{
			return Invalid;
		}
		return new CombatReserveData
		{
			_internalType = 3,
			_internalValue0 = weaponIndex
		};
	}

	/// <summary>
	/// 基于解封创建预约数据
	/// </summary>
	public static CombatReserveData CreateUnlockAttack(int weaponIndex)
	{
		if (weaponIndex < 0)
		{
			return Invalid;
		}
		return new CombatReserveData
		{
			_internalType = 4,
			_internalValue0 = weaponIndex
		};
	}

	/// <summary>
	/// 基于道具创建预约数据
	/// </summary>
	public static CombatReserveData CreateUseItem(ItemKey itemKey)
	{
		if (!itemKey.IsValid())
		{
			return Invalid;
		}
		return new CombatReserveData
		{
			_internalType = 5,
			_internalValue0 = (long)(ulong)itemKey
		};
	}

	/// <summary>
	/// 基于其它行为创建预约数据
	/// </summary>
	public static CombatReserveData CreateOtherAction(sbyte otherActionType)
	{
		if (otherActionType < 0)
		{
			return Invalid;
		}
		return new CombatReserveData
		{
			_internalType = 6,
			_internalValue0 = otherActionType
		};
	}

	/// <summary>
	/// 基于同道指令创建预约数据
	/// </summary>
	public static CombatReserveData CreateTeammateCommand(int teammateCharId, int teammateCmdIndex)
	{
		if (teammateCharId < 0 || teammateCmdIndex < 0)
		{
			return Invalid;
		}
		return new CombatReserveData
		{
			_internalType = 7,
			_internalValue0 = (((long)teammateCharId << 32) | teammateCmdIndex)
		};
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	/// <param name="other"></param>
	public CombatReserveData(CombatReserveData other)
	{
		_internalType = other._internalType;
		_internalValue0 = other._internalValue0;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)_internalType;
		byte* num = pData + 1;
		*(long*)num = _internalValue0;
		int totalSize = (int)(num + 8 - pData);
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
		_internalValue0 = *(long*)pCurrData;
		pCurrData += 8;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
