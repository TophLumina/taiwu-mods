using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Mod;

/// <summary>
/// 用于保存单个Mod中的所有可存档数据的类
/// </summary>
public class SerializableModData : ISerializableGameData
{
	/// <summary>
	/// 所有的 int 类型存档数据
	/// </summary>
	[SerializableGameDataField]
	private readonly Dictionary<string, int> _intValues;

	/// <summary>
	/// 所有的 float 类型存档数据
	/// </summary>
	[SerializableGameDataField]
	private readonly Dictionary<string, float> _floatValues;

	/// <summary>
	/// 所有的 bool 类型存档数据
	/// </summary>
	[SerializableGameDataField]
	private readonly Dictionary<string, bool> _boolValues;

	/// <summary>
	/// 所有的 string 类型存档数据
	/// </summary>
	[SerializableGameDataField]
	private readonly Dictionary<string, string> _stringValues;

	/// <summary>
	/// 所有继承 ISerializableGameData 的类型的存档数据
	/// </summary>
	private readonly Dictionary<Type, Dictionary<string, ISerializableGameData>> _serializableGameDataValues;

	/// <summary>
	/// 构造方法，初始化数据
	/// </summary>
	public SerializableModData()
	{
		_intValues = new Dictionary<string, int>();
		_floatValues = new Dictionary<string, float>();
		_boolValues = new Dictionary<string, bool>();
		_stringValues = new Dictionary<string, string>();
		_serializableGameDataValues = new Dictionary<Type, Dictionary<string, ISerializableGameData>>();
	}

	/// <summary>
	/// 直接从EventArgBox中复制来的同名方法，用于从字节流中读取一个 String。
	/// </summary>
	/// <param name="pData"></param>
	/// <returns></returns>
	private unsafe string ReadString(ref byte* pData)
	{
		ushort elementsCount = *(ushort*)pData;
		pData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			string result = Encoding.Unicode.GetString(pData, fieldSize);
			pData += fieldSize;
			return result;
		}
		return string.Empty;
	}

	/// <summary>
	/// 直接从EventArgBox中复制来的同名方法，用于向字节流中写入一个 String。
	/// 由于这里的string长度是用ushort，出于所占空间大小考虑优先使用该方法而不是 Serializer 中的保存 string 的方法
	/// </summary>
	/// <param name="pData"></param>
	/// <param name="target"></param>
	/// <returns></returns>
	private unsafe int WriteString(byte* pData, string target)
	{
		byte* pCurrData = pData;
		if (!string.IsNullOrEmpty(target))
		{
			int elementsCount = target.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = target)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pData = 0;
			pCurrData += 2;
		}
		return (int)(pCurrData - pData);
	}

	/// <summary>
	/// 是否包含指定Key
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public bool ContainsKey(string key)
	{
		if (_intValues.ContainsKey(key) || _boolValues.ContainsKey(key) || _stringValues.ContainsKey(key) || _floatValues.ContainsKey(key))
		{
			return true;
		}
		foreach (KeyValuePair<Type, Dictionary<string, ISerializableGameData>> serializableGameDataValue in _serializableGameDataValues)
		{
			if (serializableGameDataValue.Value.ContainsKey(key))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 获取一个 int 数据
	/// </summary>
	/// <param name="key"></param>
	/// <param name="val"></param>
	/// <returns></returns>
	public bool Get(string key, out int val)
	{
		return _intValues.TryGetValue(key, out val);
	}

	/// <summary>
	/// 获取一个 float 数据
	/// </summary>
	/// <param name="key"></param>
	/// <param name="val"></param>
	/// <returns></returns>
	public bool Get(string key, out float val)
	{
		return _floatValues.TryGetValue(key, out val);
	}

	/// <summary>
	/// 获取一个 int 数据
	/// </summary>
	/// <param name="key"></param>
	/// <param name="val"></param>
	/// <returns></returns>
	public bool Get(string key, out bool val)
	{
		return _boolValues.TryGetValue(key, out val);
	}

	/// <summary>
	/// 获取一个 string 数据
	/// </summary>
	/// <param name="key"></param>
	/// <param name="val"></param>
	/// <returns></returns>
	public bool Get(string key, out string val)
	{
		return _stringValues.TryGetValue(key, out val);
	}

	/// <summary>
	/// 获取一个继承 ISerializableGameData 的自定义类的实例
	/// </summary>
	/// <param name="key"></param>
	/// <param name="serializableGameData"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public bool Get<T>(string key, out T serializableGameData) where T : ISerializableGameData
	{
		if (_serializableGameDataValues.TryGetValue(typeof(T), out var collection) && collection.TryGetValue(key, out var data))
		{
			serializableGameData = (T)data;
			return true;
		}
		serializableGameData = default(T);
		return false;
	}

	/// <summary>
	/// 设置一个 int 数据
	/// </summary>
	/// <param name="key"></param>
	/// <param name="val"></param>
	/// <returns></returns>
	public void Set(string key, int val)
	{
		_intValues[key] = val;
	}

	/// <summary>
	/// 设置一个 float 数据
	/// </summary>
	/// <param name="key"></param>
	/// <param name="val"></param>
	/// <returns></returns>
	public void Set(string key, float val)
	{
		_floatValues[key] = val;
	}

	/// <summary>
	/// 设置一个 bool 数据
	/// </summary>
	/// <param name="key"></param>
	/// <param name="val"></param>
	/// <returns></returns>
	public void Set(string key, bool val)
	{
		_boolValues[key] = val;
	}

	/// <summary>
	/// 设置一个 string 数据
	/// </summary>
	/// <param name="key"></param>
	/// <param name="val"></param>
	/// <returns></returns>
	public void Set(string key, string val)
	{
		_stringValues[key] = val;
	}

	/// <summary>
	/// 设置一个继承 ISerializableGameData 的自定义类的实例
	/// </summary>
	/// <param name="key"></param>
	/// <param name="serializableGameData"></param>
	/// <typeparam name="T"></typeparam>
	public void Set<T>(string key, T serializableGameData) where T : ISerializableGameData
	{
		Type type = typeof(T);
		if (!_serializableGameDataValues.TryGetValue(type, out var collection))
		{
			collection = new Dictionary<string, ISerializableGameData>();
			_serializableGameDataValues.Add(type, collection);
		}
		collection[key] = serializableGameData;
	}

	public void Remove(string key)
	{
		_intValues.Remove(key);
		_floatValues.Remove(key);
		_stringValues.Remove(key);
		_boolValues.Remove(key);
		foreach (KeyValuePair<Type, Dictionary<string, ISerializableGameData>> serializableGameDataValue in _serializableGameDataValues)
		{
			serializableGameDataValue.Value.Remove(key);
		}
	}

	public bool RemoveInt(string key)
	{
		return _intValues.Remove(key);
	}

	public bool RemoveFloat(string key)
	{
		return _floatValues.Remove(key);
	}

	public bool RemoveString(string key)
	{
		return _stringValues.Remove(key);
	}

	public bool RemoveBool(string key)
	{
		return _boolValues.Remove(key);
	}

	public bool RemoveObject(string key)
	{
		bool removedAny = false;
		foreach (KeyValuePair<Type, Dictionary<string, ISerializableGameData>> pair in _serializableGameDataValues)
		{
			removedAny = removedAny || pair.Value.Remove(key);
		}
		return removedAny;
	}

	public void Clear()
	{
		_intValues.Clear();
		_floatValues.Clear();
		_boolValues.Clear();
		_stringValues.Clear();
		_serializableGameDataValues.Clear();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		foreach (KeyValuePair<string, int> intValue in _intValues)
		{
			totalSize += 2 + 2 * intValue.Key.Length + 4;
		}
		foreach (KeyValuePair<string, float> floatValue in _floatValues)
		{
			totalSize += 2 + 2 * floatValue.Key.Length + 4;
		}
		foreach (KeyValuePair<string, bool> boolValue in _boolValues)
		{
			totalSize += 2 + 2 * boolValue.Key.Length + 1;
		}
		foreach (KeyValuePair<string, string> pair in _stringValues)
		{
			totalSize += 2 + 2 * pair.Key.Length + 2 + 2 * pair.Value.Length;
		}
		foreach (KeyValuePair<Type, Dictionary<string, ISerializableGameData>> pair2 in _serializableGameDataValues)
		{
			totalSize += 2 + 2 * pair2.Key.FullName.Length + 2;
			foreach (KeyValuePair<string, ISerializableGameData> innerPair in pair2.Value)
			{
				totalSize += 2 + 2 * innerPair.Key.Length + innerPair.Value.GetSerializedSize();
			}
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(ushort*)pCurrData = (ushort)_intValues.Count;
		pCurrData += 2;
		foreach (KeyValuePair<string, int> pair in _intValues)
		{
			pCurrData += WriteString(pCurrData, pair.Key);
			*(int*)pCurrData = pair.Value;
			pCurrData += 4;
		}
		*(ushort*)pCurrData = (ushort)_floatValues.Count;
		pCurrData += 2;
		foreach (KeyValuePair<string, float> pair2 in _floatValues)
		{
			pCurrData += WriteString(pCurrData, pair2.Key);
			*(float*)pCurrData = pair2.Value;
			pCurrData += 4;
		}
		*(ushort*)pCurrData = (ushort)_boolValues.Count;
		pCurrData += 2;
		foreach (KeyValuePair<string, bool> pair3 in _boolValues)
		{
			pCurrData += WriteString(pCurrData, pair3.Key);
			*pCurrData = (pair3.Value ? ((byte)1) : ((byte)0));
			pCurrData++;
		}
		*(ushort*)pCurrData = (ushort)_stringValues.Count;
		pCurrData += 2;
		foreach (KeyValuePair<string, string> pair4 in _stringValues)
		{
			pCurrData += WriteString(pCurrData, pair4.Key);
			pCurrData += WriteString(pCurrData, pair4.Value);
		}
		*(ushort*)pCurrData = (ushort)_serializableGameDataValues.Count;
		pCurrData += 2;
		foreach (KeyValuePair<Type, Dictionary<string, ISerializableGameData>> pair5 in _serializableGameDataValues)
		{
			pCurrData += WriteString(pCurrData, pair5.Key.FullName);
			*(ushort*)pCurrData = (ushort)pair5.Value.Count;
			pCurrData += 2;
			foreach (KeyValuePair<string, ISerializableGameData> innerPair in pair5.Value)
			{
				pCurrData += WriteString(pCurrData, innerPair.Key);
				pCurrData += innerPair.Value.Serialize(pCurrData);
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		_intValues.Clear();
		for (int i = 0; i < elementsCount; i++)
		{
			string key = ReadString(ref pCurrData);
			int value = *(int*)pCurrData;
			pCurrData += 4;
			_intValues.Add(key, value);
		}
		elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		_floatValues.Clear();
		for (int j = 0; j < elementsCount; j++)
		{
			string key2 = ReadString(ref pCurrData);
			float value2 = *(float*)pCurrData;
			pCurrData += 4;
			_floatValues.Add(key2, value2);
		}
		elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		_boolValues.Clear();
		for (int k = 0; k < elementsCount; k++)
		{
			string key3 = ReadString(ref pCurrData);
			bool value3 = *pCurrData != 0;
			pCurrData++;
			_boolValues.Add(key3, value3);
		}
		elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		_stringValues.Clear();
		for (int l = 0; l < elementsCount; l++)
		{
			string key4 = ReadString(ref pCurrData);
			string value4 = ReadString(ref pCurrData);
			_stringValues.Add(key4, value4);
		}
		elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		_serializableGameDataValues.Clear();
		for (int m = 0; m < elementsCount; m++)
		{
			string typeFullName = ReadString(ref pCurrData);
			Type type = GetTypeInAllAssemblies(typeFullName);
			if (type == null)
			{
				throw new Exception("Can't find type " + typeFullName + " in any of the loaded assemblies.");
			}
			Dictionary<string, ISerializableGameData> collection = new Dictionary<string, ISerializableGameData>();
			_serializableGameDataValues.Add(type, collection);
			ushort subElementCount = *(ushort*)pCurrData;
			pCurrData += 2;
			for (int n = 0; n < subElementCount; n++)
			{
				string key5 = ReadString(ref pCurrData);
				ISerializableGameData value5 = (ISerializableGameData)Activator.CreateInstance(type);
				if (value5 == null)
				{
					throw new Exception("Can't parse type " + typeFullName + " to ISerializableGameData.");
				}
				pCurrData += value5.Deserialize(pCurrData);
				collection.Add(key5, value5);
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	private static Type GetTypeInAllAssemblies(string typeFullName)
	{
		Type type = Type.GetType(typeFullName);
		if (type != null)
		{
			return type;
		}
		Assembly currAssembly = typeof(SerializableModData).Assembly;
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			if (!(assembly == currAssembly))
			{
				type = assembly.GetType(typeFullName);
				if (type != null)
				{
					return type;
				}
			}
		}
		return null;
	}
}
