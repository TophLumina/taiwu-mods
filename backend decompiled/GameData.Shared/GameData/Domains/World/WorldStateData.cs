using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.World;

public struct WorldStateData : ISerializableGameData
{
	public enum EStorageType : sbyte
	{
		Invalid = -1,
		Warehouse,
		Trough,
		Count
	}

	public enum ELoopingType : sbyte
	{
		Invalid = -1,
		HasLoopingEvent,
		NoLoopingNeigongWithUnfinished,
		NoLoopingNeigongQiNotFull,
		LoopingNeigongFinishedWithUnfinished,
		LoopingNeigongCanFillAuxiliary,
		NeiliFiveElementsConflicting,
		Count
	}

	public enum EReadingType : sbyte
	{
		Invalid = -1,
		NoReadingBookWithReadable,
		NoReadingBookAllFinished,
		ReadingBookFinishedWithUnfinished,
		ReadingBookCanFillReference,
		HasReadingEvent,
		Count
	}

	[SerializableGameDataField]
	private ulong _worldStates;

	[SerializableGameDataField]
	private ushort _awakeningXiangshuAvatars;

	[SerializableGameDataField]
	private ushort _attackingXiangshuAvatars;

	[SerializableGameDataField]
	private byte _poisonTypes;

	[SerializableGameDataField]
	private byte _overloadingResourceTypes;

	[SerializableGameDataField]
	private byte _outerInjuryParts;

	[SerializableGameDataField]
	private byte _innerInjuryParts;

	[SerializableGameDataField]
	private byte _overloadStorageTypes;

	[SerializableGameDataField]
	private byte _loopingTypes;

	[SerializableGameDataField]
	private byte _readingTypes;

	[SerializableGameDataField]
	private short _minAwakeSwordTombRemainMonths;

	public void ClearWorldStates()
	{
		_worldStates = 0uL;
		_awakeningXiangshuAvatars = 0;
		_attackingXiangshuAvatars = 0;
		_poisonTypes = 0;
		_overloadingResourceTypes = 0;
		_outerInjuryParts = 0;
		_innerInjuryParts = 0;
		_loopingTypes = 0;
		_readingTypes = 0;
		_minAwakeSwordTombRemainMonths = 0;
	}

	public void SetWorldState(short templateId)
	{
		_worldStates = BitOperation.SetBit(_worldStates, templateId, bit: true);
	}

	public bool GetWorldState(short templateId)
	{
		return BitOperation.GetBit(_worldStates, templateId);
	}

	public void AddAwakeningXiangshuAvatar(sbyte xiangshuAvatarId)
	{
		_awakeningXiangshuAvatars = BitOperation.SetBit(_awakeningXiangshuAvatars, xiangshuAvatarId, bit: true);
	}

	public bool IsXiangshuAvatarAwakening(sbyte xiangshuAvatarId)
	{
		return BitOperation.GetBit(_awakeningXiangshuAvatars, xiangshuAvatarId);
	}

	public short GetMinAwakeSwordTombRemainMonths()
	{
		return _minAwakeSwordTombRemainMonths;
	}

	public void SetMinAwakeSwordTombRemainMonths(short value)
	{
		_minAwakeSwordTombRemainMonths = value;
	}

	public void AddAttackingXiangshuAvatar(sbyte xiangshuAvatarId)
	{
		_attackingXiangshuAvatars = BitOperation.SetBit(_attackingXiangshuAvatars, xiangshuAvatarId, bit: true);
	}

	public bool IsXiangshuAvatarAttacking(sbyte xiangshuAvatarId)
	{
		return BitOperation.GetBit(_attackingXiangshuAvatars, xiangshuAvatarId);
	}

	public void AddPoisonType(sbyte poisonType)
	{
		_poisonTypes = BitOperation.SetBit(_poisonTypes, poisonType, bit: true);
	}

	public bool IsPoisonedWithType(sbyte poisonType)
	{
		return BitOperation.GetBit(_poisonTypes, poisonType);
	}

	public void AddInnerInjuryBodyPart(sbyte bodyPart)
	{
		_innerInjuryParts = BitOperation.SetBit(_innerInjuryParts, bodyPart, bit: true);
	}

	public bool BodyPartHasInnerInjury(sbyte bodyPart)
	{
		return BitOperation.GetBit(_innerInjuryParts, bodyPart);
	}

	public void AddOuterInjuryBodyPart(sbyte bodyPart)
	{
		_outerInjuryParts = BitOperation.SetBit(_outerInjuryParts, bodyPart, bit: true);
	}

	public bool BodyPartHasOuterInjury(sbyte bodyPart)
	{
		return BitOperation.GetBit(_outerInjuryParts, bodyPart);
	}

	public bool AnyOuterInjury()
	{
		return _outerInjuryParts != 0;
	}

	public bool AnyInnerInjury()
	{
		return _innerInjuryParts != 0;
	}

	public void AddOverloadingResourceType(sbyte resourceType)
	{
		_overloadingResourceTypes = BitOperation.SetBit(_overloadingResourceTypes, resourceType, bit: true);
	}

	public bool IsResourceOverloaded(sbyte resourceType)
	{
		return BitOperation.GetBit(_overloadingResourceTypes, resourceType);
	}

	public void AddOverloadStorageType(EStorageType storageType)
	{
		if (storageType != EStorageType.Warehouse && storageType != EStorageType.Trough)
		{
			throw new ArgumentOutOfRangeException("storageType", "Storage type must be 0 or 1.");
		}
		_overloadStorageTypes = BitOperation.SetBit(_overloadStorageTypes, (int)storageType, bit: true);
	}

	public IEnumerable<EStorageType> IterateOverloadStorageTypes()
	{
		for (sbyte i = 0; i < 2; i++)
		{
			if (BitOperation.GetBit(_overloadStorageTypes, i))
			{
				yield return (EStorageType)i;
			}
		}
	}

	public void AddLoopingType(ELoopingType loopingType)
	{
		_loopingTypes = BitOperation.SetBit(_loopingTypes, (int)loopingType, bit: true);
	}

	public bool HasLoopingType(ELoopingType loopingType)
	{
		return BitOperation.GetBit(_loopingTypes, (int)loopingType);
	}

	public IEnumerable<ELoopingType> IterateLoopingTypes()
	{
		for (sbyte i = 0; i < 6; i++)
		{
			if (BitOperation.GetBit(_loopingTypes, i))
			{
				yield return (ELoopingType)i;
			}
		}
	}

	public bool HasLoopingTypes()
	{
		return _loopingTypes != 0;
	}

	public void AddReadingType(EReadingType readingType)
	{
		_readingTypes = BitOperation.SetBit(_readingTypes, (int)readingType, bit: true);
	}

	public bool HasReadingType(EReadingType readingType)
	{
		return BitOperation.GetBit(_readingTypes, (int)readingType);
	}

	public IEnumerable<EReadingType> IterateReadingTypes()
	{
		for (sbyte i = 0; i < 5; i++)
		{
			if (BitOperation.GetBit(_readingTypes, i))
			{
				yield return (EReadingType)i;
			}
		}
	}

	public bool HasReadingTypes()
	{
		return _readingTypes != 0;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 21;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(ulong*)pData = _worldStates;
		byte* num = pData + 8;
		*(ushort*)num = _awakeningXiangshuAvatars;
		byte* num2 = num + 2;
		*(ushort*)num2 = _attackingXiangshuAvatars;
		byte* num3 = num2 + 2;
		*num3 = _poisonTypes;
		byte* num4 = num3 + 1;
		*num4 = _overloadingResourceTypes;
		byte* num5 = num4 + 1;
		*num5 = _outerInjuryParts;
		byte* num6 = num5 + 1;
		*num6 = _innerInjuryParts;
		byte* num7 = num6 + 1;
		*num7 = _overloadStorageTypes;
		byte* num8 = num7 + 1;
		*num8 = _loopingTypes;
		byte* num9 = num8 + 1;
		*num9 = _readingTypes;
		byte* num10 = num9 + 1;
		*(short*)num10 = _minAwakeSwordTombRemainMonths;
		int totalSize = (int)(num10 + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		_worldStates = *(ulong*)pCurrData;
		pCurrData += 8;
		_awakeningXiangshuAvatars = *(ushort*)pCurrData;
		pCurrData += 2;
		_attackingXiangshuAvatars = *(ushort*)pCurrData;
		pCurrData += 2;
		_poisonTypes = *pCurrData;
		pCurrData++;
		_overloadingResourceTypes = *pCurrData;
		pCurrData++;
		_outerInjuryParts = *pCurrData;
		pCurrData++;
		_innerInjuryParts = *pCurrData;
		pCurrData++;
		_overloadStorageTypes = *pCurrData;
		pCurrData++;
		_loopingTypes = *pCurrData;
		pCurrData++;
		_readingTypes = *pCurrData;
		pCurrData++;
		_minAwakeSwordTombRemainMonths = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
