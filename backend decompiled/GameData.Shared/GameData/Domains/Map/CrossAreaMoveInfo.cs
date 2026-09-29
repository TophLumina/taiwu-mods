using GameData.Serializer;

namespace GameData.Domains.Map;

public class CrossAreaMoveInfo : ISerializableGameData
{
	public const int Invalid = -1;

	public short FromAreaId;

	public short FromBlockId;

	public short ToAreaId;

	public int MoneyCost;

	public int AuthorityCost;

	public int CostedDays;

	public TravelRoute Route;

	public bool Traveling => ToAreaId >= 0;

	public int RouteIndex => ParseRouteIndex();

	public short CurrentAreaId => ParseAreaId();

	public short LastAreaId => ParseLastAreaId();

	public short NextAreaId => ParseNextAreaId();

	public int NextCostDays => ParseNextCostDays();

	public CrossAreaMoveInfo()
	{
		ToAreaId = -1;
		Route = new TravelRoute();
	}

	public int ParseRouteIndex()
	{
		if (!Traveling)
		{
			return -1;
		}
		int costed = CostedDays;
		int index = -1;
		for (int i = 0; i < Route.CostList.Count; i++)
		{
			costed -= Route.CostList[i];
			if (costed < 0)
			{
				break;
			}
			index++;
		}
		return index;
	}

	public short ParseAreaId()
	{
		if (!Traveling)
		{
			return -1;
		}
		int routeIndex = RouteIndex;
		if (routeIndex >= 0)
		{
			return Route.AreaList[routeIndex];
		}
		return FromAreaId;
	}

	public short ParseLastAreaId()
	{
		if (!Traveling)
		{
			return -1;
		}
		int routeIndex = RouteIndex - 1;
		if (routeIndex >= 0)
		{
			return Route.AreaList[routeIndex];
		}
		return FromAreaId;
	}

	public short ParseNextAreaId()
	{
		if (!Traveling)
		{
			return -1;
		}
		int routeIndex = RouteIndex + 1;
		if (routeIndex < Route.AreaList.Count)
		{
			return Route.AreaList[routeIndex];
		}
		return ToAreaId;
	}

	public int ParseNextCostDays()
	{
		if (!Traveling || CurrentAreaId == ToAreaId)
		{
			return -1;
		}
		int nextRouteIndex = RouteIndex + 1;
		int costDays = 0;
		for (int i = 0; i <= nextRouteIndex; i++)
		{
			costDays += Route.CostList[i];
		}
		return costDays - CostedDays;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 18;
		totalSize += Route.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = FromAreaId;
		((short*)pData)[1] = FromBlockId;
		((short*)pData)[2] = ToAreaId;
		*(int*)(pData + 6) = MoneyCost;
		*(int*)(pData + 10) = AuthorityCost;
		*(int*)(pData + 14) = CostedDays;
		Route.Serialize(pData + 18);
		return GetSerializedSize();
	}

	public unsafe int Deserialize(byte* pData)
	{
		FromAreaId = *(short*)pData;
		FromBlockId = ((short*)pData)[1];
		ToAreaId = ((short*)pData)[2];
		MoneyCost = *(int*)(pData + 6);
		AuthorityCost = *(int*)(pData + 10);
		CostedDays = *(int*)(pData + 14);
		Route.Deserialize(pData + 18);
		return GetSerializedSize();
	}
}
