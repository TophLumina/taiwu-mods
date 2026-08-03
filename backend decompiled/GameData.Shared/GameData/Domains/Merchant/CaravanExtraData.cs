using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Merchant;

/// <summary>
/// 商队的额外数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class CaravanExtraData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort IncomeCriticalRate = 0;

		public const ushort IncomeBonus = 1;

		public const ushort IncomeCriticalResult = 2;

		public const ushort RobbedRate = 3;

		public const ushort State = 4;

		public const ushort IsInvested = 5;

		public const ushort SettlementIdList = 6;

		public const ushort Count = 7;

		public static readonly string[] FieldId2FieldName = new string[7] { "IncomeCriticalRate", "IncomeBonus", "IncomeCriticalResult", "RobbedRate", "State", "IsInvested", "SettlementIdList" };
	}

	/// <summary>
	/// 收益增幅的初始值
	/// </summary>
	public const short InitialIncomeBonus = 1000;

	/// <summary>
	/// 收益暴击率，千分制
	/// </summary>
	[SerializableGameDataField]
	public short IncomeCriticalRate;

	/// <summary>
	/// 收益增幅，千分制，初始1000
	/// </summary>
	[SerializableGameDataField]
	public short IncomeBonus = 1000;

	/// <summary>
	/// 收益暴击倍率，百分制
	/// </summary>
	[SerializableGameDataField]
	public short IncomeCriticalResult;

	/// <summary>
	/// 被抢劫概率，千分制
	/// </summary>
	[SerializableGameDataField]
	public short RobbedRate;

	/// <summary>
	/// 当前状态
	/// <see cref="T:GameData.Domains.Merchant.CaravanState" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte State;

	/// <summary>
	/// 是否被太吾投资
	/// </summary>
	[SerializableGameDataField]
	public bool IsInvested;

	/// <summary>
	/// 待经过的定居点列表，不重复，经过就从列表移除
	/// </summary>
	[SerializableGameDataField]
	public List<short> SettlementIdList;

	public CaravanState StateEnum => (CaravanState)State;

	public override string ToString()
	{
		string stateStr = StateEnum switch
		{
			CaravanState.Normal => "正常", 
			CaravanState.Robbed => "正在被抢", 
			CaravanState.RobEnd => "被抢结束", 
			_ => throw new ArgumentOutOfRangeException(), 
		};
		string investStr = (IsInvested ? "已经投资" : "未投资");
		return $"收益比例{IncomeBonus}‰，暴击概率{IncomeCriticalRate}‰，暴击倍率{IncomeCriticalResult}‰，遇劫概率{RobbedRate}‰，{investStr}，当前状态{stateStr}";
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CaravanExtraData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CaravanExtraData(CaravanExtraData other)
	{
		IncomeCriticalRate = other.IncomeCriticalRate;
		IncomeBonus = other.IncomeBonus;
		IncomeCriticalResult = other.IncomeCriticalResult;
		RobbedRate = other.RobbedRate;
		State = other.State;
		IsInvested = other.IsInvested;
		SettlementIdList = ((other.SettlementIdList == null) ? null : new List<short>(other.SettlementIdList));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CaravanExtraData other)
	{
		IncomeCriticalRate = other.IncomeCriticalRate;
		IncomeBonus = other.IncomeBonus;
		IncomeCriticalResult = other.IncomeCriticalResult;
		RobbedRate = other.RobbedRate;
		State = other.State;
		IsInvested = other.IsInvested;
		SettlementIdList = ((other.SettlementIdList == null) ? null : new List<short>(other.SettlementIdList));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize = ((SettlementIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * SettlementIdList.Count)));
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
		*(short*)pCurrData = 7;
		pCurrData += 2;
		*(short*)pCurrData = IncomeCriticalRate;
		pCurrData += 2;
		*(short*)pCurrData = IncomeBonus;
		pCurrData += 2;
		*(short*)pCurrData = IncomeCriticalResult;
		pCurrData += 2;
		*(short*)pCurrData = RobbedRate;
		pCurrData += 2;
		*pCurrData = (byte)State;
		pCurrData++;
		*pCurrData = (IsInvested ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (SettlementIdList != null)
		{
			int elementsCount = SettlementIdList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = SettlementIdList[i];
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			IncomeCriticalRate = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			IncomeBonus = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 2)
		{
			IncomeCriticalResult = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 3)
		{
			RobbedRate = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 4)
		{
			State = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 5)
		{
			IsInvested = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 6)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (SettlementIdList == null)
				{
					SettlementIdList = new List<short>(elementsCount);
				}
				else
				{
					SettlementIdList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					SettlementIdList.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				SettlementIdList?.Clear();
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
