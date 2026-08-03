using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Common;

public class DataModificationHandlerGroup
{
	private readonly Dictionary<string, int> _indices;

	private readonly List<(string key, DataModificationHandler handler)> _handlers;

	private readonly List<DataModificationHandler> _executionQueue;

	public int Count => _handlers.Count;

	public DataModificationHandlerGroup()
	{
		_indices = new Dictionary<string, int>();
		_handlers = new List<(string, DataModificationHandler)>();
		_executionQueue = new List<DataModificationHandler>();
	}

	public void RegisterHandler(string key, DataModificationHandler handler)
	{
		int index = _handlers.Count;
		_indices.Add(key, index);
		_handlers.Add((key, handler));
	}

	public bool UnregisterHandler(string key)
	{
		if (!_indices.TryGetValue(key, out var index))
		{
			return false;
		}
		_indices.Remove(key);
		int lastIndex = _handlers.Count - 1;
		if (lastIndex != index)
		{
			string lastKey = _handlers[lastIndex].key;
			CollectionUtils.SwapAndRemove(_handlers, index);
			_indices[lastKey] = index;
		}
		else
		{
			_handlers.RemoveAt(index);
		}
		return true;
	}

	public void ExecuteAll(DataContext context, DataUid uid)
	{
		foreach (var (key, handler) in _handlers)
		{
			_executionQueue.Add(handler);
		}
		foreach (DataModificationHandler handler2 in _executionQueue)
		{
			handler2(context, uid);
		}
		_executionQueue.Clear();
	}
}
