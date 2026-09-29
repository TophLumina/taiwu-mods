using System;
using System.Collections.Generic;
using System.Linq;
using Config;

namespace GameData.Domains.Map;

public class TravelRouteHelper<T>
{
	private readonly Func<short, T> _indexer;

	private readonly Func<float[], T> _converter;

	public short FromId;

	public short ToId;

	public TravelRouteHelper(Func<short, T> indexer, Func<float[], T> converter)
	{
		_indexer = indexer;
		_converter = converter;
	}

	public IEnumerable<T> GetRoute(short fromId, short toId)
	{
		short fromId2 = fromId;
		short toId2 = toId;
		FromId = fromId2;
		ToId = toId2;
		if (TravelRouteHelperData.PathDictionary.TryGetValue((fromId, toId), out var routeId))
		{
			return MapRoute.Instance[routeId].Path.Select(_converter).Prepend(_indexer(fromId)).Append(_indexer(toId))
				.ToArray();
		}
		if (TravelRouteHelperData.PathDictionary.TryGetValue((toId, fromId), out routeId))
		{
			return MapRoute.Instance[routeId].Path.Select(_converter).Reverse().Prepend(_indexer(fromId))
				.Append(_indexer(toId))
				.ToArray();
		}
		return Enumerable.Empty<T>().Append(_indexer(fromId)).Append(_indexer(toId))
			.ToArray();
	}
}
