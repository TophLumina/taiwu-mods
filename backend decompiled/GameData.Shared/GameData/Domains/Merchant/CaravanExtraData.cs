using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Merchant;

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

	public const short InitialIncomeBonus = 1000;

	[SerializableGameDataField]
	public short IncomeCriticalRate;

	[SerializableGameDataField]
	public short IncomeBonus = 1000;

	[SerializableGameDataField]
	public short IncomeCriticalResult;

	[SerializableGameDataField]
	public short RobbedRate;

	[SerializableGameDataField]
	public sbyte State;

	[SerializableGameDataField]
	public bool IsInvested;

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

	public CaravanExtraData()
	{
	}

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

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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
