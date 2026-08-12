using System.Collections.Generic;
using GameData.Domains.Organization.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Merchant;

/// <summary>
/// 用于在地图上显示商队图标的数据
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true)]
public class CaravanDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int CaravanId;

	[SerializableGameDataField]
	public short MerchantTemplateId;

	[SerializableGameDataField]
	public short TargetArea;

	[SerializableGameDataField]
	public int Favorability;

	[SerializableGameDataField]
	public CaravanPath PathInArea = new CaravanPath();

	[SerializableGameDataField]
	public CaravanExtraData ExtraData = new CaravanExtraData();

	[SerializableGameDataField]
	public List<SettlementDisplayData> SettlementDisplayDataList;

	public override string ToString()
	{
		return $"商队 ID{CaravanId}，{ExtraData?.ToString() ?? string.Empty}";
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CaravanDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CaravanDisplayData(CaravanDisplayData other)
	{
		CaravanId = other.CaravanId;
		MerchantTemplateId = other.MerchantTemplateId;
		TargetArea = other.TargetArea;
		Favorability = other.Favorability;
		PathInArea = new CaravanPath(other.PathInArea);
		ExtraData = new CaravanExtraData(other.ExtraData);
		SettlementDisplayDataList = ((other.SettlementDisplayDataList == null) ? null : new List<SettlementDisplayData>(other.SettlementDisplayDataList));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CaravanDisplayData other)
	{
		CaravanId = other.CaravanId;
		MerchantTemplateId = other.MerchantTemplateId;
		TargetArea = other.TargetArea;
		Favorability = other.Favorability;
		PathInArea = new CaravanPath(other.PathInArea);
		ExtraData = new CaravanExtraData(other.ExtraData);
		SettlementDisplayDataList = ((other.SettlementDisplayDataList == null) ? null : new List<SettlementDisplayData>(other.SettlementDisplayDataList));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize = ((PathInArea == null) ? (totalSize + 2) : (totalSize + (2 + PathInArea.GetSerializedSize())));
		totalSize = ((ExtraData == null) ? (totalSize + 2) : (totalSize + (2 + ExtraData.GetSerializedSize())));
		if (SettlementDisplayDataList != null)
		{
			totalSize += 2;
			for (int i = 0; i < SettlementDisplayDataList.Count; i++)
			{
				totalSize += SettlementDisplayDataList[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
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
		*(short*)pCurrData = TargetArea;
		pCurrData += 2;
		*(int*)pCurrData = Favorability;
		pCurrData += 4;
		if (PathInArea != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = PathInArea.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ExtraData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = ExtraData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SettlementDisplayDataList != null)
		{
			int elementsCount = SettlementDisplayDataList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int fieldSize3 = SettlementDisplayDataList[i].Serialize(pCurrData);
				pCurrData += fieldSize3;
				Tester.Assert(fieldSize3 <= 65535);
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

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		CaravanId = *(int*)pCurrData;
		pCurrData += 4;
		MerchantTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		TargetArea = *(short*)pCurrData;
		pCurrData += 2;
		Favorability = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			PathInArea = new CaravanPath();
			pCurrData += PathInArea.Deserialize(pCurrData);
		}
		else
		{
			PathInArea = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			ExtraData = new CaravanExtraData();
			pCurrData += ExtraData.Deserialize(pCurrData);
		}
		else
		{
			ExtraData = null;
		}
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (SettlementDisplayDataList == null)
			{
				SettlementDisplayDataList = new List<SettlementDisplayData>();
			}
			else
			{
				SettlementDisplayDataList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				SettlementDisplayData element = default(SettlementDisplayData);
				pCurrData += element.Deserialize(pCurrData);
				SettlementDisplayDataList.Add(element);
			}
		}
		else
		{
			SettlementDisplayDataList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
