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
		/// <summary>
		/// 当前周天运转存在天人感应
		/// </summary>
		HasLoopingEvent,
		/// <summary>
		/// 当前没有运转的内功，且还有其他没运完内力的内功
		/// </summary>
		NoLoopingNeigongWithUnfinished,
		/// <summary>
		/// 当前没有运转的内功，内力运转完了，但是周天真气没满
		/// </summary>
		NoLoopingNeigongQiNotFull,
		/// <summary>
		/// 当前有运转的内功，但是运转完了，且还有其他没运转完内力的内功
		/// </summary>
		LoopingNeigongFinishedWithUnfinished,
		/// <summary>
		/// 当前运转的内功没运转完，且还有可以填辅助内功的空位，下月内力也不会运转满
		/// </summary>
		LoopingNeigongCanFillAuxiliary,
		/// <summary>
		/// 当前五行内力冲克了
		/// </summary>
		NeiliFiveElementsConflicting,
		Count
	}

	public enum EReadingType : sbyte
	{
		Invalid = -1,
		/// <summary>
		/// 没有在研读的书，且行囊内有可读的书
		/// </summary>
		NoReadingBookWithReadable,
		/// <summary>
		/// 没有在研读的书，但其他书也都读完了
		/// </summary>
		NoReadingBookAllFinished,
		/// <summary>
		/// 还有在研读的书，但是读完了，行囊有其他没读完的书
		/// </summary>
		ReadingBookFinishedWithUnfinished,
		/// <summary>
		/// 当前研读的书籍没读完，参考书没填满，下月研读进度也不会读满
		/// </summary>
		ReadingBookCanFillReference,
		/// <summary>
		/// 当前研读书籍存在灵光一闪
		/// </summary>
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

	/// <summary>
	/// 记录超过负重的存储类型，bit：<see cref="T:GameData.Domains.World.WorldStateData.EStorageType" />
	/// </summary>
	[SerializableGameDataField]
	private byte _overloadStorageTypes;

	/// <summary>
	/// 记录周天运转状态，bit：<see cref="T:GameData.Domains.World.WorldStateData.ELoopingType" />
	/// </summary>
	[SerializableGameDataField]
	private byte _loopingTypes;

	/// <summary>
	/// 记录研读状态，bit：<see cref="T:GameData.Domains.World.WorldStateData.EReadingType" />
	/// </summary>
	[SerializableGameDataField]
	private byte _readingTypes;

	/// <summary>
	/// 异动剑冢中最短的剩余月数
	/// </summary>
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

	/// <summary>
	/// 添加异动剑冢
	/// </summary>
	/// <param name="xiangshuAvatarId"><see cref="T:GameData.Domains.World.XiangshuAvatarIds" /></param>
	public void AddAwakeningXiangshuAvatar(sbyte xiangshuAvatarId)
	{
		_awakeningXiangshuAvatars = BitOperation.SetBit(_awakeningXiangshuAvatars, xiangshuAvatarId, bit: true);
	}

	/// <summary>
	/// 指定化身的剑冢是否异动
	/// </summary>
	/// <param name="xiangshuAvatarId"><see cref="T:GameData.Domains.World.XiangshuAvatarIds" /></param>
	public bool IsXiangshuAvatarAwakening(sbyte xiangshuAvatarId)
	{
		return BitOperation.GetBit(_awakeningXiangshuAvatars, xiangshuAvatarId);
	}

	/// <summary>
	/// 获取异动剑冢中最短的剩余月数
	/// </summary>
	public short GetMinAwakeSwordTombRemainMonths()
	{
		return _minAwakeSwordTombRemainMonths;
	}

	/// <summary>
	/// 设置异动剑冢中最短的剩余月数
	/// </summary>
	public void SetMinAwakeSwordTombRemainMonths(short value)
	{
		_minAwakeSwordTombRemainMonths = value;
	}

	/// <summary>
	/// 添加出冢化身
	/// </summary>
	/// <param name="xiangshuAvatarId"><see cref="T:GameData.Domains.World.XiangshuAvatarIds" /></param>
	public void AddAttackingXiangshuAvatar(sbyte xiangshuAvatarId)
	{
		_attackingXiangshuAvatars = BitOperation.SetBit(_attackingXiangshuAvatars, xiangshuAvatarId, bit: true);
	}

	/// <summary>
	/// 指定化身是否出冢
	/// </summary>
	/// <param name="xiangshuAvatarId"><see cref="T:GameData.Domains.World.XiangshuAvatarIds" /></param>
	public bool IsXiangshuAvatarAttacking(sbyte xiangshuAvatarId)
	{
		return BitOperation.GetBit(_attackingXiangshuAvatars, xiangshuAvatarId);
	}

	/// <summary>
	/// 添加毒素
	/// </summary>
	/// <param name="poisonType"><see cref="T:GameData.Domains.Combat.PoisonType" /></param>
	public void AddPoisonType(sbyte poisonType)
	{
		_poisonTypes = BitOperation.SetBit(_poisonTypes, poisonType, bit: true);
	}

	/// <summary>
	/// 太吾是否身中指定毒素
	/// </summary>
	/// <param name="poisonType"><see cref="T:GameData.Domains.Combat.PoisonType" /></param>
	public bool IsPoisonedWithType(sbyte poisonType)
	{
		return BitOperation.GetBit(_poisonTypes, poisonType);
	}

	/// <summary>
	/// 添加内伤部位
	/// </summary>
	/// <param name="bodyPart"><see cref="T:GameData.Domains.Combat.BodyPartType" /></param>
	public void AddInnerInjuryBodyPart(sbyte bodyPart)
	{
		_innerInjuryParts = BitOperation.SetBit(_innerInjuryParts, bodyPart, bit: true);
	}

	/// <summary>
	/// 太吾指定部位是否有内伤
	/// </summary>
	/// <param name="bodyPart"><see cref="T:GameData.Domains.Combat.BodyPartType" /></param>
	public bool BodyPartHasInnerInjury(sbyte bodyPart)
	{
		return BitOperation.GetBit(_innerInjuryParts, bodyPart);
	}

	/// <summary>
	/// 添加外伤部位
	/// </summary>
	/// <param name="bodyPart"><see cref="T:GameData.Domains.Combat.BodyPartType" /></param>
	public void AddOuterInjuryBodyPart(sbyte bodyPart)
	{
		_outerInjuryParts = BitOperation.SetBit(_outerInjuryParts, bodyPart, bit: true);
	}

	/// <summary>
	/// 太吾指定部位是否有外伤
	/// </summary>
	/// <param name="bodyPart"><see cref="T:GameData.Domains.Combat.BodyPartType" /></param>
	public bool BodyPartHasOuterInjury(sbyte bodyPart)
	{
		return BitOperation.GetBit(_outerInjuryParts, bodyPart);
	}

	/// <summary>
	/// 太吾是否有任何外伤
	/// </summary>
	/// <returns></returns>
	public bool AnyOuterInjury()
	{
		return _outerInjuryParts != 0;
	}

	/// <summary>
	/// 太吾是否有任何内伤
	/// </summary>
	/// <returns></returns>
	public bool AnyInnerInjury()
	{
		return _innerInjuryParts != 0;
	}

	/// <summary>
	/// 添加超重资源类型
	/// </summary>
	/// <param name="resourceType"><see cref="T:GameData.Domains.Character.ResourceType" /></param>
	public void AddOverloadingResourceType(sbyte resourceType)
	{
		_overloadingResourceTypes = BitOperation.SetBit(_overloadingResourceTypes, resourceType, bit: true);
	}

	/// <summary>
	/// 指定资源类型是否超重
	/// </summary>
	/// <param name="resourceType"><see cref="T:GameData.Domains.Character.ResourceType" /></param>
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

	/// <summary>
	/// 超负重的是哪个容器
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 添加周天运转状态
	/// </summary>
	public void AddLoopingType(ELoopingType loopingType)
	{
		_loopingTypes = BitOperation.SetBit(_loopingTypes, (int)loopingType, bit: true);
	}

	/// <summary>
	/// 是否存在指定的周天运转状态
	/// </summary>
	public bool HasLoopingType(ELoopingType loopingType)
	{
		return BitOperation.GetBit(_loopingTypes, (int)loopingType);
	}

	/// <summary>
	/// 遍历所有周天运转状态
	/// </summary>
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

	/// <summary>
	/// 是否存在任意周天运转状态
	/// </summary>
	public bool HasLoopingTypes()
	{
		return _loopingTypes != 0;
	}

	/// <summary>
	/// 添加研读状态
	/// </summary>
	public void AddReadingType(EReadingType readingType)
	{
		_readingTypes = BitOperation.SetBit(_readingTypes, (int)readingType, bit: true);
	}

	/// <summary>
	/// 是否存在指定的研读状态
	/// </summary>
	public bool HasReadingType(EReadingType readingType)
	{
		return BitOperation.GetBit(_readingTypes, (int)readingType);
	}

	/// <summary>
	/// 遍历所有研读状态
	/// </summary>
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

	/// <summary>
	/// 是否存在任意研读状态
	/// </summary>
	public bool HasReadingTypes()
	{
		return _readingTypes != 0;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 21;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
