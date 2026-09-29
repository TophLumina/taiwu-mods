using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Map;

[AutoGenerateSerializableGameData(NotForArchive = true)]
public class TravelRouteElement : ISerializableGameData
{
	[SerializableGameDataField]
	public short AreaId;

	[SerializableGameDataField]
	public short Cost;

	[SerializableGameDataField]
	public bool StationUnlocked;

	public TravelRouteElement()
	{
	}

	public TravelRouteElement(TravelRouteElement other)
	{
		AreaId = other.AreaId;
		Cost = other.Cost;
		StationUnlocked = other.StationUnlocked;
	}

	public void Assign(TravelRouteElement other)
	{
		AreaId = other.AreaId;
		Cost = other.Cost;
		StationUnlocked = other.StationUnlocked;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = AreaId;
		byte* num = pData + 2;
		*(short*)num = Cost;
		byte* num2 = num + 2;
		*num2 = (StationUnlocked ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num2 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		AreaId = *(short*)pCurrData;
		pCurrData += 2;
		Cost = *(short*)pCurrData;
		pCurrData += 2;
		StationUnlocked = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
