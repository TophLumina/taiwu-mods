using GameData.Utilities;

namespace GameData.Domains.Map;

public static class MapExtensions
{
	public static bool IsNearbyLocation(this Location location, Location targetLocation, int steps)
	{
		if (!targetLocation.IsValid())
		{
			return false;
		}
		if (targetLocation.AreaId != location.AreaId)
		{
			return false;
		}
		byte areaData = DomainManager.Map.GetAreaSize(location.AreaId);
		ByteCoordinate targetCoordinate = ByteCoordinate.IndexToCoordinate(targetLocation.BlockId, areaData);
		ByteCoordinate selfCoordinate = ByteCoordinate.IndexToCoordinate(location.BlockId, areaData);
		return targetCoordinate.GetManhattanDistance(selfCoordinate) <= steps;
	}
}
