using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public class CombatReserveData : ISerializableGameData
{
	public static readonly CombatReserveData Invalid = new CombatReserveData
	{
		_internalType = 0
	};

	[SerializableGameDataField]
	private sbyte _internalType;

	[SerializableGameDataField]
	private long _internalValue0;

	[SerializableGameDataField]
	private List<int> _internalList;

	public ECombatReserveType Type => (ECombatReserveType)_internalType;

	public bool AnyReserve => Type != ECombatReserveType.Invalid;

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

	public bool NeedShowChangeTrick => Type == ECombatReserveType.ChangeTrick;

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

	public IReadOnlyList<int> SmarterChickenIds
	{
		get
		{
			if (Type != ECombatReserveType.SmarterChicken)
			{
				return null;
			}
			return _internalList;
		}
	}

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

	public static CombatReserveData CreateSmarterChicken(IReadOnlyList<int> ids)
	{
		if (ids == null || ids.Count <= 0)
		{
			return Invalid;
		}
		return new CombatReserveData
		{
			_internalType = 8,
			_internalList = new List<int>(ids)
		};
	}

	public CombatReserveData()
	{
	}

	public CombatReserveData(CombatReserveData other)
	{
		_internalType = other._internalType;
		_internalValue0 = other._internalValue0;
		_internalList = ((other._internalList == null) ? null : new List<int>(other._internalList));
	}

	public void Assign(CombatReserveData other)
	{
		_internalType = other._internalType;
		_internalValue0 = other._internalValue0;
		_internalList = ((other._internalList == null) ? null : new List<int>(other._internalList));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		totalSize = ((_internalList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _internalList.Count)));
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
		*(long*)pCurrData = _internalValue0;
		pCurrData += 8;
		if (_internalList != null)
		{
			int elementsCount = _internalList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _internalList[i];
			}
			pCurrData += 4 * elementsCount;
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
		_internalType = (sbyte)(*pCurrData);
		pCurrData++;
		_internalValue0 = *(long*)pCurrData;
		pCurrData += 8;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_internalList == null)
			{
				_internalList = new List<int>(elementsCount);
			}
			else
			{
				_internalList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				_internalList.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			_internalList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
