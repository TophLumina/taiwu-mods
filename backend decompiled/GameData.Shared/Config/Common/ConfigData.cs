using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;

namespace Config.Common;

[Serializable]
public abstract class ConfigData<T, TKey> : IConfigData, IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T> where T : ConfigItem<T, TKey>
{
	protected readonly Dictionary<string, int> _refNameMap = new Dictionary<string, int>();

	protected List<T> _dataArray;

	private Dictionary<int, string> _refNameReverseMap;

	protected readonly Dictionary<int, T> _extraDataMap = new Dictionary<int, T>();

	public IReadOnlyDictionary<string, int> RefNameMap => _refNameMap;

	public T this[int index] => GetItem(ToTemplateId(index));

	public T this[TKey index] => GetItem(index);

	public T this[string refName] => GetItem(ToTemplateId(_refNameMap[refName]));

	public int Count => _dataArray?.Count ?? 0;

	public int CountWithExtra => Count + _extraDataMap.Count;

	internal abstract int ToInt(TKey value);

	internal abstract TKey ToTemplateId(int value);

	public virtual void Init()
	{
		_refNameMap.Clear();
		_refNameMap.Load(GetType().Name);
		_extraDataMap.Clear();
	}

	public int GetItemId(string refName)
	{
		if (_refNameMap.TryGetValue(refName, out var id))
		{
			return id;
		}
		throw new Exception(refName + " not found.");
	}

	public int AddExtraItem(string identifier, string refName, object configItem)
	{
		T item = (T)configItem;
		int id = item.GetTemplateId();
		if (id < _dataArray.Count)
		{
			throw new Exception($"CharacterFeature template id {id} created by {identifier} already exist.");
		}
		if (_extraDataMap.ContainsKey(id))
		{
			throw new Exception($"CharacterFeature extra template id {id} created by {identifier} already exist.");
		}
		if (_refNameMap.TryGetValue(refName, out var refId))
		{
			throw new Exception($"CharacterFeature template reference name {refName}(id = {id}) created by {identifier} already exist with templateId {refId}).");
		}
		_refNameMap.Add(refName, id);
		_extraDataMap.Add(id, item);
		return id;
	}

	public string GetRefName(int templateId)
	{
		if (_refNameReverseMap == null || _refNameReverseMap.Count != _refNameMap.Count)
		{
			_refNameReverseMap = new Dictionary<int, string>();
			foreach (KeyValuePair<string, int> pair in _refNameMap)
			{
				_refNameReverseMap.Add(pair.Value, pair.Key);
			}
		}
		return _refNameReverseMap[templateId];
	}

	public int AddOrModifyItem(T configItem)
	{
		int index = configItem.GetTemplateId();
		if (index < _dataArray.Count)
		{
			_dataArray[index] = configItem;
			return index;
		}
		if (index == -1)
		{
			_dataArray.Add(configItem.Duplicate(_dataArray.Count));
			return _dataArray.Count - 1;
		}
		throw new Exception($"template id {index} in {configItem} exceeds _dataArray.Count = {_dataArray.Count}, please use -1 instead.");
	}

	public T GetItem(TKey id)
	{
		int index = ToInt(id);
		if (index < 0)
		{
			return null;
		}
		if (index < _dataArray.Count)
		{
			return _dataArray[index];
		}
		if (_extraDataMap.TryGetValue(index, out var item))
		{
			return item;
		}
		AdaptableLog.TagWarning(GetType().FullName, $"index {id} is not in range [0, {_dataArray.Count}) and is not defined in _extraDataMap (count: {_extraDataMap.Count})");
		lock (_extraDataMap)
		{
			item = Activator.CreateInstance<T>().Duplicate(index);
			_extraDataMap.Add(index, item);
			return item;
		}
	}

	[return: MaybeNull]
	public T GetItemOrDefault(TKey id)
	{
		int index = ToInt(id);
		if (index < 0)
		{
			return null;
		}
		if (index >= _dataArray.Count)
		{
			return _extraDataMap.GetValueOrDefault(index);
		}
		return _dataArray[index];
	}

	public List<TKey> GetAllKeys()
	{
		return this.Select((T item) => ToTemplateId(item.GetTemplateId())).ToList();
	}

	public void ExportToFiles(string directory)
	{
		Directory.CreateDirectory(directory);
		foreach (var (refKey, templateId) in _refNameMap)
		{
			CommonObjectSerializer.Serialize(this[templateId], out var text2, CommonObjectSerializer.MarshalFormat.Json);
			File.WriteAllText(Path.Combine(directory, refKey + ".json"), text2);
		}
	}

	public void ImportFromFiles(string directory)
	{
		IEnumerable<string> enumerable = Directory.EnumerateFiles(directory, "*.json");
		Dictionary<int, T> dataDict = new Dictionary<int, T>();
		foreach (string file in enumerable)
		{
			CommonObjectSerializer.Deserialize<T>(File.ReadAllText(file), out var obj, CommonObjectSerializer.MarshalFormat.Json);
			int templateId = obj.GetTemplateId();
			if (templateId < 0)
			{
				throw new Exception($"Invalid template id {templateId} ({file}).");
			}
			dataDict.Add(obj.GetTemplateId(), obj);
		}
		_dataArray = new List<T>(dataDict.Count);
		int i = 0;
		while (_dataArray.Count < dataDict.Count)
		{
			T obj2 = dataDict.GetValueOrDefault(i);
			_dataArray.Add(obj2);
			i++;
		}
	}

	public void Iterate(Func<T, bool> iterateFunc)
	{
		if (iterateFunc == null)
		{
			return;
		}
		foreach (T item in (IEnumerable<T>)this)
		{
			if (!iterateFunc(item))
			{
				break;
			}
		}
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		foreach (T item in _dataArray)
		{
			yield return item;
		}
		foreach (T value in _extraDataMap.Values)
		{
			yield return value;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<T>)this).GetEnumerator();
	}
}
