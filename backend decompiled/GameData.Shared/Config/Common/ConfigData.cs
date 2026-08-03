using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;

namespace Config.Common;

/// <summary>
/// 配置数据类的泛型接口
/// </summary>
[Serializable]
public abstract class ConfigData<T, TKey> : IConfigData, IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T> where T : ConfigItem<T, TKey>
{
	/// <summary>
	/// 引用字典
	/// </summary>
	protected readonly Dictionary<string, int> _refNameMap = new Dictionary<string, int>();

	/// <summary>
	/// 游戏本体数据
	/// </summary>
	protected List<T> _dataArray;

	/// <summary>
	/// 引用字典反向映射
	/// </summary>
	private Dictionary<int, string> _refNameReverseMap;

	/// <summary>
	/// Mod数据
	/// </summary>
	protected readonly Dictionary<int, T> _extraDataMap = new Dictionary<int, T>();

	/// <summary>
	/// 引用字典
	/// </summary>
	public IReadOnlyDictionary<string, int> RefNameMap => _refNameMap;

	/// <summary>
	/// 使用int Id进行索引
	/// </summary>
	public T this[int index] => GetItem(ToTemplateId(index));

	/// <summary>
	/// 使用模板Id进行索引
	/// </summary>
	public T this[TKey index] => GetItem(index);

	/// <summary>
	/// 获取引用名对应的条目
	/// </summary>
	public T this[string refName] => GetItem(ToTemplateId(_refNameMap[refName]));

	/// <summary>
	/// 原生配置表条目总数
	/// </summary>
	public int Count => _dataArray?.Count ?? 0;

	/// <summary>
	/// 原生配置表条目与Mod条目总数
	/// </summary>
	public int CountWithExtra => Count + _extraDataMap.Count;

	internal abstract int ToInt(TKey value);

	internal abstract TKey ToTemplateId(int value);

	/// <summary>
	/// 基类初始化
	/// 仍需在各类初始化数据
	/// </summary>
	public virtual void Init()
	{
		_refNameMap.Clear();
		_refNameMap.Load(GetType().Name);
		_extraDataMap.Clear();
	}

	/// <summary>
	/// 获取refName 对应的TemplateId，以int返回
	/// </summary>
	/// <param name="refName"></param>
	/// <returns></returns>
	/// <exception cref="T:System.Exception"></exception>
	public int GetItemId(string refName)
	{
		if (_refNameMap.TryGetValue(refName, out var id))
		{
			return id;
		}
		throw new Exception(refName + " not found.");
	}

	/// <summary>
	/// 增加额外物品（老接口）
	/// </summary>
	/// <param name="identifier"></param>
	/// <param name="refName"></param>
	/// <param name="configItem"></param>
	/// <returns></returns>
	/// <exception cref="T:System.Exception"></exception>
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

	/// <summary>
	/// 添加或修改配置项
	/// </summary>
	/// <param name="configItem"></param>
	/// <returns>返回被修改/添加的物品的index</returns>
	/// <exception cref="T:System.Exception"></exception>
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

	/// <summary>
	/// 获取物品
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
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
		return null;
	}

	/// <summary>
	/// 获取全部配置表条目key
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 全配置表条目迭代器
	/// </summary>
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
