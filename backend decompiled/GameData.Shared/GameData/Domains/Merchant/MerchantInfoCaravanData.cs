using System.Collections.Generic;
using Config;
using GameData.Domains.Organization.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Merchant;

[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class MerchantInfoCaravanData : ISerializableGameData
{
	[SerializableGameDataField]
	public int CaravanId;

	[SerializableGameDataField]
	public short MerchantTemplateId;

	[SerializableGameDataField]
	public short CurrentAreaTemplateId;

	[SerializableGameDataField]
	public short TargetAreaTemplateId;

	[SerializableGameDataField]
	public short StartAreaTemplateId;

	[SerializableGameDataField]
	public List<SettlementDisplayData> RemainSettlementInfoList;

	[SerializableGameDataField]
	public int RemainNodeCount;

	[SerializableGameDataField]
	public CaravanExtraData ExtraData;

	[SerializableGameDataField]
	public bool IsInBrokenArea;

	[SerializableGameDataField]
	public CaravanPath CaravanPath;

	public bool CanInvest
	{
		get
		{
			if (!ExtraData.IsInvested)
			{
				return IsInStartArea;
			}
			return false;
		}
	}

	public bool IsInStartArea => CurrentAreaTemplateId == StartAreaTemplateId;

	public MerchantItem MerchantConfig => Config.Merchant.Instance[MerchantTemplateId];

	public int RemainSettlementCount => RemainSettlementInfoList?.Count ?? 0;

	public int GetInvestIncome()
	{
		if (!ExtraData.IsInvested)
		{
			return 0;
		}
		MerchantItem merchantConfig = Config.Merchant.Instance[MerchantTemplateId];
		int num = GlobalConfig.Instance.InvestCaravanNeedMoney[merchantConfig.Level];
		short incomeBonus = ExtraData.IncomeBonus;
		return num * incomeBonus / 1000;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 17;
		if (RemainSettlementInfoList != null)
		{
			totalSize += 2;
			for (int i = 0; i < RemainSettlementInfoList.Count; i++)
			{
				totalSize += RemainSettlementInfoList[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((ExtraData == null) ? (totalSize + 2) : (totalSize + (2 + ExtraData.GetSerializedSize())));
		totalSize = ((CaravanPath == null) ? (totalSize + 2) : (totalSize + (2 + CaravanPath.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CaravanId;
		pCurrData += 4;
		*(short*)pCurrData = MerchantTemplateId;
		pCurrData += 2;
		*(short*)pCurrData = CurrentAreaTemplateId;
		pCurrData += 2;
		*(short*)pCurrData = TargetAreaTemplateId;
		pCurrData += 2;
		*(short*)pCurrData = StartAreaTemplateId;
		pCurrData += 2;
		if (RemainSettlementInfoList != null)
		{
			int elementsCount = RemainSettlementInfoList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int fieldSize = RemainSettlementInfoList[i].Serialize(pCurrData);
				pCurrData += fieldSize;
				Tester.Assert(fieldSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = RemainNodeCount;
		pCurrData += 4;
		if (ExtraData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize2 = ExtraData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsInBrokenArea ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (CaravanPath != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = CaravanPath.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize3;
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
		CaravanId = *(int*)pCurrData;
		pCurrData += 4;
		MerchantTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		CurrentAreaTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		TargetAreaTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		StartAreaTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (RemainSettlementInfoList == null)
			{
				RemainSettlementInfoList = new List<SettlementDisplayData>();
			}
			else
			{
				RemainSettlementInfoList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				SettlementDisplayData element = default(SettlementDisplayData);
				pCurrData += element.Deserialize(pCurrData);
				RemainSettlementInfoList.Add(element);
			}
		}
		else
		{
			RemainSettlementInfoList?.Clear();
		}
		RemainNodeCount = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ExtraData = new CaravanExtraData();
			pCurrData += ExtraData.Deserialize(pCurrData);
		}
		else
		{
			ExtraData = null;
		}
		IsInBrokenArea = *pCurrData != 0;
		pCurrData++;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			CaravanPath = new CaravanPath();
			pCurrData += CaravanPath.Deserialize(pCurrData);
		}
		else
		{
			CaravanPath = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
