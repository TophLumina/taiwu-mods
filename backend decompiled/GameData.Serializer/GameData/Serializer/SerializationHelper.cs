using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GameData.Serializer;

public static class SerializationHelper
{
	public static class CollectionOfUnmanaged
	{
		public unsafe static int GetSerializedSize<TCollection, TElement>(TCollection collection) where TCollection : ICollection<TElement> where TElement : unmanaged
		{
			return 4 + sizeof(TElement) * collection.Count;
		}

		public unsafe static int Serialize<TCollection, TElement>(byte* pData, ref TCollection collection) where TCollection : ICollection<TElement> where TElement : unmanaged
		{
			byte* pCurrData = pData;
			*(int*)pCurrData = collection.Count;
			pCurrData += 4;
			foreach (TElement value in collection)
			{
				*(TElement*)pCurrData = value;
				pCurrData += sizeof(TElement);
			}
			return (int)(pCurrData - pData);
		}

		public unsafe static int Deserialize<TCollection, TElement>(byte* pData, ref TCollection collection) where TCollection : ICollection<TElement> where TElement : unmanaged
		{
			collection.Clear();
			byte* pCurrData = pData;
			int count = *(int*)pCurrData;
			pCurrData += 4;
			for (int i = 0; i < count; i++)
			{
				TElement value = *(TElement*)pCurrData;
				pCurrData += sizeof(TElement);
				collection.Add(value);
			}
			return (int)(pCurrData - pData);
		}
	}

	public static class CollectionOfSerializableGameData
	{
		public static int GetSerializedSize<TCollection, TElement>(TCollection collection) where TCollection : ICollection<TElement> where TElement : ISerializableGameData
		{
			int size = 4;
			foreach (TElement item in collection)
			{
				size += item.GetSerializedSize();
			}
			return size;
		}

		public unsafe static int Serialize<TCollection, TElement>(byte* pData, ref TCollection collection) where TCollection : ICollection<TElement> where TElement : ISerializableGameData
		{
			byte* pCurrData = pData;
			*(int*)pCurrData = collection.Count;
			pCurrData += 4;
			foreach (TElement item in collection)
			{
				pCurrData += item.Serialize(pCurrData);
			}
			return (int)(pCurrData - pData);
		}

		public unsafe static int Deserialize<TCollection, TElement>(byte* pData, ref TCollection collection) where TCollection : ICollection<TElement> where TElement : ISerializableGameData, new()
		{
			collection.Clear();
			byte* pCurrData = pData;
			int count = *(int*)pCurrData;
			pCurrData += 4;
			for (int i = 0; i < count; i++)
			{
				TElement value = new TElement();
				pCurrData += value.Deserialize(pCurrData);
				TElement item = value;
				collection.Add(item);
			}
			return (int)(pCurrData - pData);
		}
	}

	public static class DictionaryOfBasicTypePair
	{
		public unsafe static int GetSerializedSize<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> dictionary) where TKey : unmanaged where TValue : unmanaged
		{
			if (dictionary == null)
			{
				return 4;
			}
			return 4 + dictionary.Count * (sizeof(TKey) + sizeof(TValue));
		}

		public unsafe static int Serialize<TKey, TValue>(byte* pData, ref Dictionary<TKey, TValue> dictionary) where TKey : unmanaged where TValue : unmanaged
		{
			return Serialize<TKey, TValue, Dictionary<TKey, TValue>>(pData, ref dictionary);
		}

		public unsafe static int Serialize<TKey, TValue, TDict>(byte* pData, ref TDict dictionary) where TKey : unmanaged where TValue : unmanaged where TDict : IDictionary<TKey, TValue>
		{
			byte* pCurrData = pData;
			if (dictionary != null)
			{
				*(int*)pCurrData = dictionary.Count;
				pCurrData += 4;
				foreach (KeyValuePair<TKey, TValue> pair in dictionary)
				{
					*(TKey*)pCurrData = pair.Key;
					pCurrData += sizeof(TKey);
					*(TValue*)pCurrData = pair.Value;
					pCurrData += sizeof(TValue);
				}
			}
			else
			{
				*(int*)pCurrData = 0;
				pCurrData += 4;
			}
			return (int)(pCurrData - pData);
		}

		public unsafe static int Deserialize<TKey, TValue>(byte* pData, ref Dictionary<TKey, TValue> dictionary) where TKey : unmanaged where TValue : unmanaged
		{
			return Deserialize<TKey, TValue, Dictionary<TKey, TValue>>(pData, ref dictionary);
		}

		public unsafe static int Deserialize<TKey, TValue, TDict>(byte* pData, ref TDict dictionary) where TKey : unmanaged where TValue : unmanaged where TDict : IDictionary<TKey, TValue>, new()
		{
			byte* pCurrData = pData;
			int count = *(int*)pCurrData;
			pCurrData += 4;
			if (count > 0)
			{
				if (dictionary == null)
				{
					dictionary = new TDict();
				}
				else
				{
					dictionary.Clear();
				}
				for (int i = 0; i < count; i++)
				{
					TKey key = *(TKey*)pCurrData;
					pCurrData += sizeof(TKey);
					TValue value = *(TValue*)pCurrData;
					pCurrData += sizeof(TValue);
					dictionary.Add(key, value);
				}
			}
			else
			{
				ref TDict reference = ref dictionary;
				TDict val = default(TDict);
				if (val == null)
				{
					val = reference;
					reference = ref val;
					if (val == null)
					{
						goto IL_00a3;
					}
				}
				reference.Clear();
			}
			goto IL_00a3;
			IL_00a3:
			return (int)(pCurrData - pData);
		}
	}

	public static class DictionaryAsBasicTypePair
	{
		public unsafe static int GetSerializedSize<TKey, TValue, TKeyAs, TValueAs, TDict>(TDict dictionary) where TKeyAs : unmanaged where TValueAs : unmanaged where TDict : IReadOnlyDictionary<TKey, TValue>
		{
			if (dictionary == null)
			{
				return 4;
			}
			return 4 + dictionary.Count * (sizeof(TKeyAs) + sizeof(TValueAs));
		}

		public unsafe static int Serialize<TKey, TValue, TKeyAs, TValueAs, TDict>(byte* pData, ref TDict dictionary, Func<TKey, TKeyAs> keyAs, Func<TValue, TValueAs> valueAs) where TKeyAs : unmanaged where TValueAs : unmanaged where TDict : IDictionary<TKey, TValue>
		{
			byte* pCurrData = pData;
			if (dictionary != null)
			{
				*(int*)pCurrData = dictionary.Count;
				pCurrData += 4;
				foreach (KeyValuePair<TKey, TValue> pair in dictionary)
				{
					*(TKeyAs*)pCurrData = keyAs(pair.Key);
					pCurrData += sizeof(TKeyAs);
					*(TValueAs*)pCurrData = valueAs(pair.Value);
					pCurrData += sizeof(TValueAs);
				}
			}
			else
			{
				*(int*)pCurrData = 0;
				pCurrData += 4;
			}
			return (int)(pCurrData - pData);
		}

		public unsafe static int Deserialize<TKey, TValue, TKeyAs, TValueAs, TDict>(byte* pData, ref TDict dictionary, Func<TKeyAs, TKey> asKey, Func<TValueAs, TValue> asValue) where TKeyAs : unmanaged where TValueAs : unmanaged where TDict : IDictionary<TKey, TValue>, new()
		{
			byte* pCurrData = pData;
			int count = *(int*)pCurrData;
			pCurrData += 4;
			TDict val;
			if (count > 0)
			{
				if (dictionary == null)
				{
					dictionary = new TDict();
				}
				else
				{
					dictionary.Clear();
				}
				for (int i = 0; i < count; i++)
				{
					TKeyAs key = *(TKeyAs*)pCurrData;
					pCurrData += sizeof(TKeyAs);
					TValueAs value = *(TValueAs*)pCurrData;
					pCurrData += sizeof(TValueAs);
					ref TDict reference = ref dictionary;
					val = default(TDict);
					if (val == null)
					{
						val = reference;
						reference = ref val;
					}
					TKey key2 = asKey(key);
					TValue value2 = asValue(value);
					reference.Add(key2, value2);
				}
			}
			else
			{
				ref TDict reference2 = ref dictionary;
				val = default(TDict);
				if (val == null)
				{
					val = reference2;
					reference2 = ref val;
					if (val == null)
					{
						goto IL_00cc;
					}
				}
				reference2.Clear();
			}
			goto IL_00cc;
			IL_00cc:
			return (int)(pCurrData - pData);
		}
	}

	public static class DictionaryOfCustomTypePair
	{
		public static int GetSerializedSize<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : ISerializableGameData where TValue : ISerializableGameData
		{
			if (dictionary == null)
			{
				return 4;
			}
			int size = 4;
			foreach (KeyValuePair<TKey, TValue> pair in dictionary)
			{
				size += pair.Key.GetSerializedSize();
				size += pair.Value.GetSerializedSize();
			}
			return size;
		}

		public unsafe static int Serialize<TKey, TValue>(byte* pData, ref Dictionary<TKey, TValue> dictionary) where TKey : ISerializableGameData where TValue : ISerializableGameData
		{
			byte* pCurrData = pData;
			if (dictionary != null)
			{
				*(int*)pCurrData = dictionary.Count;
				pCurrData += 4;
				foreach (KeyValuePair<TKey, TValue> pair in dictionary)
				{
					pCurrData += pair.Key.Serialize(pCurrData);
					pCurrData += pair.Value.Serialize(pCurrData);
				}
			}
			else
			{
				*(int*)pCurrData = 0;
				pCurrData += 4;
			}
			return (int)(pCurrData - pData);
		}

		public unsafe static int Deserialize<TKey, TValue>(byte* pData, ref Dictionary<TKey, TValue> dictionary) where TKey : ISerializableGameData, new() where TValue : ISerializableGameData, new()
		{
			byte* pCurrData = pData;
			int count = *(int*)pCurrData;
			pCurrData += 4;
			if (count > 0)
			{
				if (dictionary == null)
				{
					dictionary = new Dictionary<TKey, TValue>();
				}
				else
				{
					dictionary.Clear();
				}
				for (int i = 0; i < count; i++)
				{
					TKey key = new TKey();
					pCurrData += key.Deserialize(pCurrData);
					TValue value = new TValue();
					pCurrData += value.Deserialize(pCurrData);
					dictionary.Add(key, value);
				}
			}
			else
			{
				dictionary?.Clear();
			}
			return (int)(pCurrData - pData);
		}
	}

	public static class DictionaryAsCustomTypePair
	{
		public static int GetSerializedSize<TKey, TValue, TKeyAs, TValueAs, TDict>(TDict dictionary, Func<TKey, TKeyAs> keyAs, Func<TValue, TValueAs> valueAs) where TKeyAs : ISerializableGameData where TValueAs : ISerializableGameData where TDict : IReadOnlyDictionary<TKey, TValue>
		{
			if (dictionary == null)
			{
				return 4;
			}
			int size = 4;
			foreach (KeyValuePair<TKey, TValue> pair in dictionary)
			{
				size += keyAs(pair.Key).GetSerializedSize();
				size += valueAs(pair.Value).GetSerializedSize();
			}
			return size;
		}

		public unsafe static int Serialize<TKey, TValue, TKeyAs, TValueAs, TDict>(byte* pData, ref TDict dictionary, Func<TKey, TKeyAs> keyAs, Func<TValue, TValueAs> valueAs) where TKeyAs : ISerializableGameData where TValueAs : ISerializableGameData where TDict : IReadOnlyDictionary<TKey, TValue>
		{
			byte* pCurrData = pData;
			if (dictionary != null)
			{
				*(int*)pCurrData = dictionary.Count;
				pCurrData += 4;
				foreach (KeyValuePair<TKey, TValue> pair in dictionary)
				{
					pCurrData += keyAs(pair.Key).Serialize(pCurrData);
					pCurrData += valueAs(pair.Value).Serialize(pCurrData);
				}
			}
			else
			{
				*(int*)pCurrData = 0;
				pCurrData += 4;
			}
			return (int)(pCurrData - pData);
		}

		public unsafe static int Deserialize<TKey, TValue, TKeyAs, TValueAs, TDict>(byte* pData, ref TDict dictionary, Func<TKeyAs, TKey> asKey, Func<TValueAs, TValue> asValue) where TKeyAs : ISerializableGameData, new() where TValueAs : ISerializableGameData, new() where TDict : IDictionary<TKey, TValue>, new()
		{
			byte* pCurrData = pData;
			int count = *(int*)pCurrData;
			pCurrData += 4;
			TDict val;
			if (count > 0)
			{
				if (dictionary == null)
				{
					dictionary = new TDict();
				}
				else
				{
					dictionary.Clear();
				}
				for (int i = 0; i < count; i++)
				{
					TKeyAs key = new TKeyAs();
					pCurrData += key.Deserialize(pCurrData);
					TValueAs value = new TValueAs();
					pCurrData += value.Deserialize(pCurrData);
					ref TDict reference = ref dictionary;
					val = default(TDict);
					if (val == null)
					{
						val = reference;
						reference = ref val;
					}
					TKey key2 = asKey(key);
					TValue value2 = asValue(value);
					reference.Add(key2, value2);
				}
			}
			else
			{
				ref TDict reference2 = ref dictionary;
				val = default(TDict);
				if (val == null)
				{
					val = reference2;
					reference2 = ref val;
					if (val == null)
					{
						goto IL_00da;
					}
				}
				reference2.Clear();
			}
			goto IL_00da;
			IL_00da:
			return (int)(pCurrData - pData);
		}
	}

	public static class DictionaryOfBasicTypeCustomTypePair
	{
		public unsafe static int GetSerializedSize<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : unmanaged where TValue : ISerializableGameData
		{
			if (dictionary == null)
			{
				return 4;
			}
			int size = 4;
			foreach (KeyValuePair<TKey, TValue> pair in dictionary)
			{
				size += sizeof(TKey);
				size += pair.Value.GetSerializedSize();
			}
			return size;
		}

		public unsafe static int Serialize<TKey, TValue>(byte* pData, ref Dictionary<TKey, TValue> dictionary) where TKey : unmanaged where TValue : ISerializableGameData
		{
			byte* pCurrData = pData;
			if (dictionary != null)
			{
				*(int*)pCurrData = dictionary.Count;
				pCurrData += 4;
				foreach (KeyValuePair<TKey, TValue> pair in dictionary)
				{
					*(TKey*)pCurrData = pair.Key;
					pCurrData += sizeof(TKey);
					pCurrData += pair.Value.Serialize(pCurrData);
				}
			}
			else
			{
				*(int*)pCurrData = 0;
				pCurrData += 4;
			}
			return (int)(pCurrData - pData);
		}

		public unsafe static int Deserialize<TKey, TValue>(byte* pData, ref Dictionary<TKey, TValue> dictionary) where TKey : unmanaged where TValue : ISerializableGameData, new()
		{
			byte* pCurrData = pData;
			int count = *(int*)pCurrData;
			pCurrData += 4;
			if (count > 0)
			{
				if (dictionary == null)
				{
					dictionary = new Dictionary<TKey, TValue>();
				}
				else
				{
					dictionary.Clear();
				}
				for (int i = 0; i < count; i++)
				{
					TKey key = *(TKey*)pCurrData;
					pCurrData += sizeof(TKey);
					TValue value = new TValue();
					pCurrData += value.Deserialize(pCurrData);
					dictionary.Add(key, value);
				}
			}
			else
			{
				dictionary?.Clear();
			}
			return (int)(pCurrData - pData);
		}
	}

	public static class DictionaryAsBasicTypeCustomTypePair
	{
		public unsafe static int GetSerializedSize<TKey, TValue, TKeyAs, TValueAs, TDict>(TDict dictionary, Func<TValue, TValueAs> valueAs) where TKeyAs : unmanaged where TValueAs : ISerializableGameData where TDict : IReadOnlyDictionary<TKey, TValue>
		{
			if (dictionary == null)
			{
				return 4;
			}
			int size = 4;
			foreach (KeyValuePair<TKey, TValue> pair in dictionary)
			{
				size += sizeof(TKeyAs);
				size += valueAs(pair.Value).GetSerializedSize();
			}
			return size;
		}

		public unsafe static int Serialize<TKey, TValue, TKeyAs, TValueAs, TDict>(byte* pData, ref TDict dictionary, Func<TKey, TKeyAs> keyAs, Func<TValue, TValueAs> valueAs) where TKeyAs : unmanaged where TValueAs : ISerializableGameData where TDict : IReadOnlyDictionary<TKey, TValue>
		{
			byte* pCurrData = pData;
			if (dictionary != null)
			{
				*(int*)pCurrData = dictionary.Count;
				pCurrData += 4;
				foreach (KeyValuePair<TKey, TValue> pair in dictionary)
				{
					*(TKeyAs*)pCurrData = keyAs(pair.Key);
					pCurrData += sizeof(TKeyAs);
					pCurrData += valueAs(pair.Value).Serialize(pCurrData);
				}
			}
			else
			{
				*(int*)pCurrData = 0;
				pCurrData += 4;
			}
			return (int)(pCurrData - pData);
		}

		public unsafe static int Deserialize<TKey, TValue, TKeyAs, TValueAs, TDict>(byte* pData, ref TDict dictionary, Func<TKeyAs, TKey> asKey, Func<TValueAs, TValue> asValue) where TKeyAs : unmanaged where TValueAs : ISerializableGameData, new() where TDict : IDictionary<TKey, TValue>, new()
		{
			byte* pCurrData = pData;
			int count = *(int*)pCurrData;
			pCurrData += 4;
			TDict val;
			if (count > 0)
			{
				if (dictionary == null)
				{
					dictionary = new TDict();
				}
				else
				{
					dictionary.Clear();
				}
				for (int i = 0; i < count; i++)
				{
					TKeyAs key = *(TKeyAs*)pCurrData;
					pCurrData += sizeof(TKeyAs);
					TValueAs value = new TValueAs();
					pCurrData += value.Deserialize(pCurrData);
					ref TDict reference = ref dictionary;
					val = default(TDict);
					if (val == null)
					{
						val = reference;
						reference = ref val;
					}
					TKey key2 = asKey(key);
					TValue value2 = asValue(value);
					reference.Add(key2, value2);
				}
			}
			else
			{
				ref TDict reference2 = ref dictionary;
				val = default(TDict);
				if (val == null)
				{
					val = reference2;
					reference2 = ref val;
					if (val == null)
					{
						goto IL_00d3;
					}
				}
				reference2.Clear();
			}
			goto IL_00d3;
			IL_00d3:
			return (int)(pCurrData - pData);
		}
	}

	public static class DictionaryOfCustomTypeBasicTypePair
	{
		public unsafe static int GetSerializedSize<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : ISerializableGameData where TValue : unmanaged
		{
			if (dictionary == null)
			{
				return 4;
			}
			int size = 4;
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				size += item.Key.GetSerializedSize();
				size += sizeof(TValue);
			}
			return size;
		}

		public unsafe static int Serialize<TKey, TValue>(byte* pData, ref Dictionary<TKey, TValue> dictionary) where TKey : ISerializableGameData where TValue : unmanaged
		{
			byte* pCurrData = pData;
			if (dictionary != null)
			{
				*(int*)pCurrData = dictionary.Count;
				pCurrData += 4;
				foreach (KeyValuePair<TKey, TValue> pair in dictionary)
				{
					pCurrData += pair.Key.Serialize(pCurrData);
					*(TValue*)pCurrData = pair.Value;
					pCurrData += sizeof(TValue);
				}
			}
			else
			{
				*(int*)pCurrData = 0;
				pCurrData += 4;
			}
			return (int)(pCurrData - pData);
		}

		public unsafe static int Deserialize<TKey, TValue>(byte* pData, ref Dictionary<TKey, TValue> dictionary) where TKey : ISerializableGameData, new() where TValue : unmanaged
		{
			byte* pCurrData = pData;
			int count = *(int*)pCurrData;
			pCurrData += 4;
			if (count > 0)
			{
				if (dictionary == null)
				{
					dictionary = new Dictionary<TKey, TValue>();
				}
				else
				{
					dictionary.Clear();
				}
				for (int i = 0; i < count; i++)
				{
					TKey key = new TKey();
					pCurrData += key.Deserialize(pCurrData);
					TValue value = *(TValue*)pCurrData;
					pCurrData += sizeof(TValue);
					dictionary.Add(key, value);
				}
			}
			else
			{
				dictionary?.Clear();
			}
			return (int)(pCurrData - pData);
		}
	}

	public static class DictionaryAsCustomTypeBasicTypePair
	{
		public unsafe static int GetSerializedSize<TKey, TValue, TKeyAs, TValueAs, TDict>(TDict dictionary, Func<TKey, TKeyAs> keyAs) where TKeyAs : ISerializableGameData where TValueAs : unmanaged where TDict : IReadOnlyDictionary<TKey, TValue>
		{
			if (dictionary == null)
			{
				return 4;
			}
			int size = 4;
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				size += keyAs(item.Key).GetSerializedSize();
				size += sizeof(TValueAs);
			}
			return size;
		}

		public unsafe static int Serialize<TKey, TValue, TKeyAs, TValueAs, TDict>(byte* pData, ref TDict dictionary, Func<TKey, TKeyAs> keyAs, Func<TValue, TValueAs> valueAs) where TKeyAs : ISerializableGameData where TValueAs : unmanaged where TDict : IReadOnlyDictionary<TKey, TValue>
		{
			byte* pCurrData = pData;
			if (dictionary != null)
			{
				*(int*)pCurrData = dictionary.Count;
				pCurrData += 4;
				foreach (KeyValuePair<TKey, TValue> pair in dictionary)
				{
					pCurrData += keyAs(pair.Key).Serialize(pCurrData);
					*(TValueAs*)pCurrData = valueAs(pair.Value);
					pCurrData += sizeof(TValueAs);
				}
			}
			else
			{
				*(int*)pCurrData = 0;
				pCurrData += 4;
			}
			return (int)(pCurrData - pData);
		}

		public unsafe static int Deserialize<TKey, TValue, TKeyAs, TValueAs, TDict>(byte* pData, ref TDict dictionary, Func<TKeyAs, TKey> asKey, Func<TValueAs, TValue> asValue) where TKeyAs : ISerializableGameData, new() where TValueAs : unmanaged where TDict : IDictionary<TKey, TValue>, new()
		{
			byte* pCurrData = pData;
			int count = *(int*)pCurrData;
			pCurrData += 4;
			TDict val;
			if (count > 0)
			{
				if (dictionary == null)
				{
					dictionary = new TDict();
				}
				else
				{
					dictionary.Clear();
				}
				for (int i = 0; i < count; i++)
				{
					TKeyAs key = new TKeyAs();
					pCurrData += key.Deserialize(pCurrData);
					TValueAs value = *(TValueAs*)pCurrData;
					pCurrData += sizeof(TValueAs);
					ref TDict reference = ref dictionary;
					val = default(TDict);
					if (val == null)
					{
						val = reference;
						reference = ref val;
					}
					TKey key2 = asKey(key);
					TValue value2 = asValue(value);
					reference.Add(key2, value2);
				}
			}
			else
			{
				ref TDict reference2 = ref dictionary;
				val = default(TDict);
				if (val == null)
				{
					val = reference2;
					reference2 = ref val;
					if (val == null)
					{
						goto IL_00d3;
					}
				}
				reference2.Clear();
			}
			goto IL_00d3;
			IL_00d3:
			return (int)(pCurrData - pData);
		}
	}

	public static class SelfTypeIdContained
	{
		public static int GetSerializedSize<T>(T self) where T : ISerializableGameData
		{
			return SerializationHelper.GetSerializedSize(self.GetType().FullName) + self.GetSerializedSize();
		}

		public unsafe static int Serialize<T>(byte* pData, ref T self) where T : ISerializableGameData
		{
			byte* pCurrData = pData + SerializationHelper.Serialize(pData, self.GetType().FullName);
			pCurrData += self.Serialize(pCurrData);
			return (int)(pCurrData - pData);
		}

		public unsafe static int Deserialize<T>(byte* pData, out T self) where T : ISerializableGameData
		{
			byte* pCurrData = pData + SerializationHelper.Deserialize(pData, out string typeId);
			self = (T)Activator.CreateInstance(Type.GetType(typeId) ?? typeof(T));
			pCurrData += self.Deserialize(pCurrData);
			return (int)(pCurrData - pData);
		}
	}

	public unsafe static int Serialize(byte* pData, HashSet<int> item)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = item.Count;
		pCurrData += 4;
		foreach (int element in item)
		{
			*(int*)pCurrData = element;
			pCurrData += 4;
		}
		return (int)(pCurrData - pData);
	}

	public unsafe static int Deserialize(byte* pData, HashSet<int> item)
	{
		item.Clear();
		byte* pCurrData = pData;
		int count = *(int*)pCurrData;
		pCurrData += 4;
		for (int i = 0; i < count; i++)
		{
			int element = *(int*)pCurrData;
			pCurrData += 4;
			item.Add(element);
		}
		return (int)(pCurrData - pData);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static int GetSerializedSize<T1, T2>(List<(T1, T2)> list) where T1 : unmanaged where T2 : unmanaged
	{
		if (list != null)
		{
			return list.Count * (sizeof(T1) + sizeof(T2));
		}
		return 4;
	}

	public unsafe static int Serialize<T1, T2>(byte* pData, List<(T1, T2)> list) where T1 : unmanaged where T2 : unmanaged
	{
		byte* pCurrData = pData;
		if (list != null)
		{
			*(int*)pCurrData = list.Count;
			pCurrData += 4;
			for (int i = 0; i < list.Count; i++)
			{
				(T1, T2) tuple = list[i];
				*(T1*)pCurrData = tuple.Item1;
				pCurrData += sizeof(T1);
				*(T2*)pCurrData = tuple.Item2;
				pCurrData += sizeof(T2);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		return (int)(pCurrData - pData);
	}

	public unsafe static int Deserialize<T1, T2>(byte* pData, ref List<(T1, T2)> list) where T1 : unmanaged where T2 : unmanaged
	{
		byte* pCurrData = pData;
		int count = *(int*)pCurrData;
		pCurrData += 4;
		if (count == 0)
		{
			list?.Clear();
			return (int)(pCurrData - pData);
		}
		if (list == null)
		{
			list = new List<(T1, T2)>();
		}
		else
		{
			list.Clear();
		}
		for (int i = 0; i < count; i++)
		{
			T1 item1 = *(T1*)pCurrData;
			pCurrData += sizeof(T1);
			T2 item2 = *(T2*)pCurrData;
			pCurrData += sizeof(T2);
			list.Add((item1, item2));
		}
		return (int)(pCurrData - pData);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static int GetSerializedSize<T1, T2, T3>(List<(T1, T2, T3)> list) where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged
	{
		if (list != null)
		{
			return list.Count * (sizeof(T1) + sizeof(T2) + sizeof(T3));
		}
		return 4;
	}

	public unsafe static int Serialize<T1, T2, T3>(byte* pData, List<(T1, T2, T3)> list) where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged
	{
		byte* pCurrData = pData;
		if (list != null)
		{
			*(int*)pCurrData = list.Count;
			pCurrData += 4;
			for (int i = 0; i < list.Count; i++)
			{
				(T1, T2, T3) tuple = list[i];
				*(T1*)pCurrData = tuple.Item1;
				pCurrData += sizeof(T1);
				*(T2*)pCurrData = tuple.Item2;
				pCurrData += sizeof(T2);
				*(T3*)pCurrData = tuple.Item3;
				pCurrData += sizeof(T3);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		return (int)(pCurrData - pData);
	}

	public unsafe static int Deserialize<T1, T2, T3>(byte* pData, ref List<(T1, T2, T3)> list) where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged
	{
		byte* pCurrData = pData;
		int count = *(int*)pCurrData;
		pCurrData += 4;
		if (count == 0)
		{
			list?.Clear();
			return (int)(pCurrData - pData);
		}
		if (list == null)
		{
			list = new List<(T1, T2, T3)>();
		}
		else
		{
			list.Clear();
		}
		for (int i = 0; i < count; i++)
		{
			T1 item1 = *(T1*)pCurrData;
			pCurrData += sizeof(T1);
			T2 item2 = *(T2*)pCurrData;
			pCurrData += sizeof(T2);
			T3 item3 = *(T3*)pCurrData;
			pCurrData += sizeof(T3);
			list.Add((item1, item2, item3));
		}
		return (int)(pCurrData - pData);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static int GetSerializedSize<T1, T2>((T1, T2) valueTuple) where T1 : unmanaged where T2 : unmanaged
	{
		return sizeof(T1) + sizeof(T2);
	}

	public unsafe static int Serialize<T1, T2>(byte* pData, (T1, T2) valueTuple) where T1 : unmanaged where T2 : unmanaged
	{
		*(T1*)pData = valueTuple.Item1;
		byte* num = pData + sizeof(T1);
		*(T2*)num = valueTuple.Item2;
		return (int)(num + sizeof(T2) - pData);
	}

	public unsafe static int Deserialize<T1, T2>(byte* pData, out (T1, T2) valueTuple) where T1 : unmanaged where T2 : unmanaged
	{
		byte* pCurrData = pData;
		valueTuple.Item1 = *(T1*)pCurrData;
		pCurrData += sizeof(T1);
		valueTuple.Item2 = *(T2*)pCurrData;
		pCurrData += sizeof(T2);
		return (int)(pCurrData - pData);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static int GetSerializedSize<T1, T2, T3>((T1, T2, T3) valueTuple) where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged
	{
		return sizeof(T1) + sizeof(T2) + sizeof(T3);
	}

	public unsafe static int Serialize<T1, T2, T3>(byte* pData, (T1, T2, T3) valueTuple) where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged
	{
		*(T1*)pData = valueTuple.Item1;
		byte* num = pData + sizeof(T1);
		*(T2*)num = valueTuple.Item2;
		byte* num2 = num + sizeof(T2);
		*(T3*)num2 = valueTuple.Item3;
		return (int)(num2 + sizeof(T3) - pData);
	}

	public unsafe static int Deserialize<T1, T2, T3>(byte* pData, out (T1, T2, T3) valueTuple) where T1 : unmanaged where T2 : unmanaged where T3 : unmanaged
	{
		byte* pCurrData = pData;
		valueTuple.Item1 = *(T1*)pCurrData;
		pCurrData += sizeof(T1);
		valueTuple.Item2 = *(T2*)pCurrData;
		pCurrData += sizeof(T2);
		valueTuple.Item3 = *(T3*)pCurrData;
		pCurrData += sizeof(T3);
		return (int)(pCurrData - pData);
	}

	public static int GetSerializedSize(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return 2;
		}
		return 2 + value.Length * 2;
	}

	public unsafe static int Serialize(byte* pData, string value)
	{
		byte* pCurrData = pData;
		if (value != null)
		{
			int elementsCount = value.Length;
			if (elementsCount > 65535)
			{
				throw new Exception("Assertion failure.");
			}
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = value)
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
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		return (int)(pCurrData - pData);
	}

	public unsafe static int Deserialize(byte* pData, out string value)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			value = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			value = string.Empty;
		}
		return (int)(pCurrData - pData);
	}
}
