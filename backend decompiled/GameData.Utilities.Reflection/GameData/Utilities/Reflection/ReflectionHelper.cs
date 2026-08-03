using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace GameData.Utilities.Reflection;

public static class ReflectionHelper
{
	public const BindingFlags Instance = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	public const int MaxDepth = 10;

	private static readonly ConcurrentBag<HashSet<object>> SetEqualsCache = new ConcurrentBag<HashSet<object>>();

	public static void CopyFields<TSrc, TDst>(TSrc src, TDst dst) where TSrc : class where TDst : class
	{
		Type type = src.GetType();
		Type dstType = dst.GetType();
		FieldInfo[] srcFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		FieldInfo[] dstFields = dstType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (srcFields == null || srcFields.Length <= 0 || dstFields == null || dstFields.Length <= 0)
		{
			return;
		}
		FieldInfo[] array = srcFields;
		foreach (FieldInfo srcField in array)
		{
			FieldInfo[] array2 = dstFields;
			foreach (FieldInfo dstField in array2)
			{
				if (srcField.Name == dstField.Name && srcField.FieldType == dstField.FieldType)
				{
					dstField.SetValue(dst, srcField.GetValue(src));
				}
			}
		}
	}

	public static EDeepEqualsResult DeepEquals<T>(T val1, T val2, int depth = 0) where T : class
	{
		if (depth > 10)
		{
			return EDeepEqualsResult.DepthOverflow;
		}
		if (val1 == null && val2 == null)
		{
			return EDeepEqualsResult.Same;
		}
		if (val1 == null || val2 == null)
		{
			return DeepEqualsNull(val1, val2, depth + 1);
		}
		if (val1 == val2)
		{
			return EDeepEqualsResult.Same;
		}
		if (val1.GetType() != val2.GetType())
		{
			return EDeepEqualsResult.Different;
		}
		Type type = val1.GetType();
		if (type.IsValueType || type == typeof(string))
		{
			if (!val1.Equals(val2))
			{
				return EDeepEqualsResult.Different;
			}
			return EDeepEqualsResult.Same;
		}
		if (typeof(ISet<>).IsAssignableFrom(type))
		{
			return ShallowEqualsSet((IEnumerable)val1, (IEnumerable)val2);
		}
		if (val1 is IList list1 && val2 is IList list2)
		{
			return DeepEqualsList(list1, list2, depth);
		}
		if (val1 is IDictionary dict1 && val2 is IDictionary dict2)
		{
			return DeepEqualsDictionary(dict1, dict2, depth);
		}
		if (val1 is IEnumerable enumerable1 && val2 is IEnumerable enumerable2)
		{
			return DeepEqualsIterator(enumerable1, enumerable2, depth);
		}
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo field in fields)
		{
			EDeepEqualsResult result = DeepEquals(field.GetValue(val1), field.GetValue(val2), depth + 1);
			if ((uint)(result - 1) <= 1u)
			{
				return result;
			}
		}
		return EDeepEqualsResult.Same;
	}

	private static EDeepEqualsResult DeepEqualsNull<T>(T val1, T val2, int depth) where T : class
	{
		if (val1 is string s1 && val2 == null)
		{
			if (!string.IsNullOrEmpty(s1))
			{
				return EDeepEqualsResult.Different;
			}
			return EDeepEqualsResult.Same;
		}
		if (val2 is string s2 && val1 == null)
		{
			if (!string.IsNullOrEmpty(s2))
			{
				return EDeepEqualsResult.Different;
			}
			return EDeepEqualsResult.Same;
		}
		if (val1 is IDeepEqualsNull deepEqualsNull1)
		{
			return deepEqualsNull1.DeepEqualsNull(depth + 1);
		}
		if (val2 is IDeepEqualsNull deepEqualsNull2)
		{
			return deepEqualsNull2.DeepEqualsNull(depth + 1);
		}
		return EDeepEqualsResult.Different;
	}

	private static EDeepEqualsResult ShallowEqualsSet(IEnumerable val1, IEnumerable val2)
	{
		SetEqualsCache.TryTake(out var cache);
		if (cache == null)
		{
			cache = new HashSet<object>();
		}
		foreach (object o in val1)
		{
			cache.Add(o);
		}
		bool anyDifferent = false;
		foreach (object o2 in val2)
		{
			if (!cache.Contains(o2))
			{
				anyDifferent = true;
				break;
			}
		}
		cache.Clear();
		SetEqualsCache.Add(cache);
		if (!anyDifferent)
		{
			return EDeepEqualsResult.Same;
		}
		return EDeepEqualsResult.Different;
	}

	private static EDeepEqualsResult DeepEqualsList(IList arr1, IList arr2, int depth)
	{
		if (arr1.Count != arr2.Count)
		{
			return EDeepEqualsResult.Different;
		}
		for (int i = 0; i < arr1.Count; i++)
		{
			EDeepEqualsResult result = DeepEquals(arr1[i], arr2[i], depth + 1);
			if ((uint)(result - 1) <= 1u)
			{
				return result;
			}
		}
		return EDeepEqualsResult.Same;
	}

	private static EDeepEqualsResult DeepEqualsDictionary(IDictionary dict1, IDictionary dict2, int depth)
	{
		if (dict1.Count != dict2.Count)
		{
			return EDeepEqualsResult.Different;
		}
		foreach (object key in dict1.Keys)
		{
			if (!dict2.Contains(key))
			{
				return EDeepEqualsResult.Different;
			}
			EDeepEqualsResult result = DeepEquals(dict1[key], dict2[key], depth + 1);
			if ((uint)(result - 1) <= 1u)
			{
				return result;
			}
		}
		return EDeepEqualsResult.Same;
	}

	private static EDeepEqualsResult DeepEqualsIterator(IEnumerable iter1, IEnumerable iter2, int depth)
	{
		IEnumerator enumerator1 = iter1.GetEnumerator();
		IEnumerator enumerator2 = iter2.GetEnumerator();
		while (enumerator1.MoveNext())
		{
			if (!enumerator2.MoveNext())
			{
				return EDeepEqualsResult.Different;
			}
			EDeepEqualsResult result = DeepEquals(enumerator1.Current, enumerator2.Current, depth + 1);
			if ((uint)(result - 1) <= 1u)
			{
				return result;
			}
		}
		int result2 = (enumerator2.MoveNext() ? 1 : 0);
		if (enumerator1 is IDisposable disposable1)
		{
			disposable1.Dispose();
		}
		if (enumerator2 is IDisposable disposable2)
		{
			disposable2.Dispose();
		}
		return (EDeepEqualsResult)result2;
	}

	public static T DeepClone<T>(T obj, int depth = 0) where T : class
	{
		return (T)DeepClone((object)obj, depth);
	}

	public static object DeepClone(object obj, int depth = 0)
	{
		if (obj == null)
		{
			return null;
		}
		Type type = obj.GetType();
		if (depth > 10)
		{
			throw new DeepCopyDepthOverflowException(obj, type);
		}
		if (type.IsPrimitive || type.IsEnum || type == typeof(string) || type == typeof(decimal))
		{
			return obj;
		}
		if (type.IsArray)
		{
			Array array = (Array)obj;
			Array newArray = (Array)Activator.CreateInstance(type, array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				newArray.SetValue(DeepClone(array.GetValue(i), depth + 1), i);
			}
			return newArray;
		}
		if (typeof(IList).IsAssignableFrom(type))
		{
			IList obj2 = (IList)obj;
			IList newList = (IList)Activator.CreateInstance(type);
			{
				foreach (object item in obj2)
				{
					newList.Add(DeepClone(item, depth + 1));
				}
				return newList;
			}
		}
		if (typeof(IDictionary).IsAssignableFrom(type))
		{
			IDictionary dict = (IDictionary)obj;
			IDictionary newDict = (IDictionary)Activator.CreateInstance(type);
			{
				foreach (object key in dict.Keys)
				{
					newDict.Add(DeepClone(key, depth + 1), DeepClone(dict[key], depth + 1));
				}
				return newDict;
			}
		}
		object clone = Activator.CreateInstance(type, nonPublic: true);
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo obj3 in fields)
		{
			object clonedValue = DeepClone(obj3.GetValue(obj), depth + 1);
			obj3.SetValue(clone, clonedValue);
		}
		return clone;
	}
}
