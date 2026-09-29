using System.Collections.Generic;
using Config;

namespace GameData.Domains.Map;

public static class TravelRouteHelperData
{
	private static Dictionary<(short, short), short> _pathDictionary;

	public static IReadOnlyDictionary<(short, short), short> PathDictionary
	{
		get
		{
			if (_pathDictionary == null)
			{
				_pathDictionary = new Dictionary<(short, short), short>();
				foreach (MapRouteItem item in (IEnumerable<MapRouteItem>)MapRoute.Instance)
				{
					_pathDictionary[(item.FromId, item.ToId)] = item.TemplateId;
				}
			}
			return _pathDictionary;
		}
	}
}
