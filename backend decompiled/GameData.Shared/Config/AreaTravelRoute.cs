using System;
using GameData.Utilities;

namespace Config;

[Serializable]
public struct AreaTravelRoute
{
	public short DestAreaId;

	public short CostDays;

	public ByteCoordinate[] MapPosList;

	public AreaTravelRoute(short destAreaId, short costDays, int[] mapPosList)
	{
		if (mapPosList != null && mapPosList.Length % 2 != 0)
		{
			throw new Exception();
		}
		DestAreaId = destAreaId;
		CostDays = costDays;
		MapPosList = new ByteCoordinate[(mapPosList != null) ? (mapPosList.Length / 2) : 0];
		if (mapPosList != null)
		{
			for (int i = 0; i < mapPosList.Length / 2; i++)
			{
				MapPosList[i] = new ByteCoordinate((byte)mapPosList[i * 2], (byte)mapPosList[i * 2 + 1]);
			}
		}
	}
}
