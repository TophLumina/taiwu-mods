using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.World;

[AutoGenerateSerializableGameData(NotForArchive = true)]
public class AdvanceMonthConditionsDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public bool HasExtraMovePoints;

	[SerializableGameDataField]
	public bool CanLoopingNeigong;

	[SerializableGameDataField]
	public bool InventoryOverload;

	[SerializableGameDataField]
	public bool WarehouseOverload;

	[SerializableGameDataField]
	public int EnergyBonus;

	[SerializableGameDataField]
	public bool BuildingCollectAnyMax;

	public AdvanceMonthConditionsDisplayData()
	{
	}

	public AdvanceMonthConditionsDisplayData(AdvanceMonthConditionsDisplayData other)
	{
		HasExtraMovePoints = other.HasExtraMovePoints;
		CanLoopingNeigong = other.CanLoopingNeigong;
		InventoryOverload = other.InventoryOverload;
		WarehouseOverload = other.WarehouseOverload;
		EnergyBonus = other.EnergyBonus;
		BuildingCollectAnyMax = other.BuildingCollectAnyMax;
	}

	public void Assign(AdvanceMonthConditionsDisplayData other)
	{
		HasExtraMovePoints = other.HasExtraMovePoints;
		CanLoopingNeigong = other.CanLoopingNeigong;
		InventoryOverload = other.InventoryOverload;
		WarehouseOverload = other.WarehouseOverload;
		EnergyBonus = other.EnergyBonus;
		BuildingCollectAnyMax = other.BuildingCollectAnyMax;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (HasExtraMovePoints ? ((byte)1) : ((byte)0));
		byte* num = pData + 1;
		*num = (CanLoopingNeigong ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*num2 = (InventoryOverload ? ((byte)1) : ((byte)0));
		byte* num3 = num2 + 1;
		*num3 = (WarehouseOverload ? ((byte)1) : ((byte)0));
		byte* num4 = num3 + 1;
		*(int*)num4 = EnergyBonus;
		byte* num5 = num4 + 4;
		*num5 = (BuildingCollectAnyMax ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num5 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		HasExtraMovePoints = *pCurrData != 0;
		pCurrData++;
		CanLoopingNeigong = *pCurrData != 0;
		pCurrData++;
		InventoryOverload = *pCurrData != 0;
		pCurrData++;
		WarehouseOverload = *pCurrData != 0;
		pCurrData++;
		EnergyBonus = *(int*)pCurrData;
		pCurrData += 4;
		BuildingCollectAnyMax = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
