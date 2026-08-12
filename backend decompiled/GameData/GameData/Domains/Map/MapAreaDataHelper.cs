using GameData.Utilities;

namespace GameData.Domains.Map;

public static class MapAreaDataHelper
{
	public static (short index, sbyte direction) GetReferenceSettlementAndDirection(this MapAreaData data, short blockId)
	{
		short areaId = data.GetAreaId();
		byte mapSize = DomainManager.Map.GetAreaSize(areaId);
		ByteCoordinate coord = ByteCoordinate.IndexToCoordinate(blockId, mapSize);
		int selectedIndex = -1;
		ByteCoordinate selectedCoord = default(ByteCoordinate);
		int selectedDistance = int.MaxValue;
		int i = 0;
		for (int count = data.SettlementInfos.Length; i < count; i++)
		{
			short settlementBlockId = data.SettlementInfos[i].BlockId;
			if (settlementBlockId >= 0)
			{
				ByteCoordinate settlementCoord = ByteCoordinate.IndexToCoordinate(settlementBlockId, mapSize);
				int distance = coord.GetManhattanDistance(settlementCoord);
				if (distance < selectedDistance)
				{
					selectedIndex = i;
					selectedCoord = settlementCoord;
					selectedDistance = distance;
				}
			}
		}
		sbyte direction = ((selectedIndex >= 0) ? coord.GetDirectionRelatedTo(selectedCoord) : coord.GetDirectionIn(mapSize));
		return (index: (short)selectedIndex, direction: direction);
	}
}
