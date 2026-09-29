using System;
using System.Collections.Generic;
using Redzen.Random;

namespace GameData.Utilities;

public static class CollectionUtils
{
	public unsafe static void SetMemoryToZero(byte* pDest, int count)
	{
		int i = 0;
		for (int blocksCount = count / 8; i < blocksCount; i++)
		{
			*(long*)pDest = 0L;
			pDest += 8;
		}
		int j = 0;
		for (int leftCount = count % 8; j < leftCount; j++)
		{
			pDest[j] = 0;
		}
	}

	public unsafe static void SetMemoryToMinusOne(byte* pDest, int count)
	{
		int i = 0;
		for (int blocksCount = count / 8; i < blocksCount; i++)
		{
			*(long*)pDest = -1L;
			pDest += 8;
		}
		int j = 0;
		for (int leftCount = count % 8; j < leftCount; j++)
		{
			pDest[j] = byte.MaxValue;
		}
	}

	public unsafe static bool Equals(byte* pLhs, byte* pRhs, int count)
	{
		int i = 0;
		for (int blocksCount = count / 8; i < blocksCount; i++)
		{
			if (*(long*)pLhs != *(long*)pRhs)
			{
				return false;
			}
			pLhs += 8;
			pRhs += 8;
		}
		int j = 0;
		for (int leftCount = count % 8; j < leftCount; j++)
		{
			if (pLhs[j] != pRhs[j])
			{
				return false;
			}
		}
		return true;
	}

	public static bool Equals<T>(T[] lhs, T[] rhs, int count) where T : IEquatable<T>
	{
		for (int i = 0; i < count; i++)
		{
			if (!lhs[i].Equals(rhs[i]))
			{
				return false;
			}
		}
		return true;
	}

	public unsafe static bool Contains<T>(T* pCollection, int count, T item) where T : unmanaged, IEquatable<T>
	{
		for (int i = 0; i < count; i++)
		{
			if (item.Equals(pCollection[i]))
			{
				return true;
			}
		}
		return false;
	}

	public static bool Contains<T>(T[] collection, T item) where T : IEquatable<T>
	{
		int i = 0;
		for (int count = collection.Length; i < count; i++)
		{
			if (item.Equals(collection[i]))
			{
				return true;
			}
		}
		return false;
	}

	public static T ElementAt<T>(HashSet<T> collection, int index)
	{
		using (HashSet<T>.Enumerator enumerator = collection.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (index <= 0)
				{
					return enumerator.Current;
				}
				index--;
			}
		}
		throw new ArgumentOutOfRangeException();
	}

	public static int BinarySearch(IList<long> list, int index, int count, long value)
	{
		int lo = index;
		int hi = index + count - 1;
		while (lo <= hi)
		{
			int mid = lo + (hi - lo >> 1);
			long cmp = list[mid] - value;
			if (cmp == 0L)
			{
				return mid;
			}
			if (cmp < 0)
			{
				lo = mid + 1;
			}
			else
			{
				hi = mid - 1;
			}
		}
		return ~lo;
	}

	public unsafe static int BinarySearch(short* pList, int index, int count, int value)
	{
		int lo = index;
		int hi = index + count - 1;
		while (lo <= hi)
		{
			int mid = lo + (hi - lo >> 1);
			int cmp = pList[mid] - value;
			if (cmp == 0)
			{
				return mid;
			}
			if (cmp < 0)
			{
				lo = mid + 1;
			}
			else
			{
				hi = mid - 1;
			}
		}
		return ~lo;
	}

	public unsafe static int BinarySearch(int* pList, int index, int count, int value)
	{
		int lo = index;
		int hi = index + count - 1;
		while (lo <= hi)
		{
			int mid = lo + (hi - lo >> 1);
			int cmp = pList[mid] - value;
			if (cmp == 0)
			{
				return mid;
			}
			if (cmp < 0)
			{
				lo = mid + 1;
			}
			else
			{
				hi = mid - 1;
			}
		}
		return ~lo;
	}

	public unsafe static int GetMaxIndex(int* pList, int count)
	{
		int maxIndex = 0;
		int maxVal = *pList;
		for (int i = 1; i < count; i++)
		{
			int val = pList[i];
			if (val > maxVal)
			{
				maxVal = val;
				maxIndex = i;
			}
		}
		return maxIndex;
	}

	public unsafe static int GetMaxIndex(short* pList, int count)
	{
		int maxIndex = 0;
		short maxVal = *pList;
		for (int i = 1; i < count; i++)
		{
			short val = pList[i];
			if (val > maxVal)
			{
				maxVal = val;
				maxIndex = i;
			}
		}
		return maxIndex;
	}

	public static int GetMaxIndex(Span<int> pList)
	{
		int maxIndex = 0;
		int maxVal = pList[0];
		for (int i = 1; i < pList.Length; i++)
		{
			int val = pList[i];
			if (val > maxVal)
			{
				maxVal = val;
				maxIndex = i;
			}
		}
		return maxIndex;
	}

	public unsafe static int GetMinIndex(int* pList, int count)
	{
		int minIndex = 0;
		int minVal = *pList;
		for (int i = 1; i < count; i++)
		{
			int val = pList[i];
			if (val < minVal)
			{
				minVal = val;
				minIndex = i;
			}
		}
		return minIndex;
	}

	public unsafe static int GetMinIndex(short* pList, int count)
	{
		int minIndex = 0;
		short minVal = *pList;
		for (int i = 1; i < count; i++)
		{
			short val = pList[i];
			if (val < minVal)
			{
				minVal = val;
				minIndex = i;
			}
		}
		return minIndex;
	}

	public unsafe static int GetSum(int* pList, int count)
	{
		int sum = 0;
		for (int i = 0; i < count; i++)
		{
			sum += pList[i];
		}
		return sum;
	}

	public unsafe static int GetSum(short* pList, int count)
	{
		int sum = 0;
		for (int i = 0; i < count; i++)
		{
			sum += pList[i];
		}
		return sum;
	}

	public unsafe static void Sort(long* pList, int count)
	{
		if (count <= 30)
		{
			BubbleSort(pList, count);
		}
		QuickSort(pList, 0, count - 1);
	}

	private unsafe static void BubbleSort(long* pList, int count)
	{
		for (int i = 0; i < count - 1; i++)
		{
			for (int j = 0; j < count - i - 1; j++)
			{
				if (pList[j] > pList[j + 1])
				{
					ref long reference = ref pList[j];
					long* num = pList + (j + 1);
					long num2 = pList[j + 1];
					long num3 = pList[j];
					reference = num2;
					*num = num3;
				}
			}
		}
	}

	private unsafe static void QuickSort(long* arr, int low, int high)
	{
		if (low < high)
		{
			int pi = Partition(arr, low, high);
			QuickSort(arr, low, pi - 1);
			QuickSort(arr, pi + 1, high);
		}
	}

	private unsafe static int Partition(long* arr, int low, int high)
	{
		long pivot = arr[high];
		int i = low - 1;
		ref long reference;
		long num3;
		long num2;
		for (int j = low; j <= high - 1; j++)
		{
			if (arr[j] < pivot)
			{
				i++;
				reference = ref arr[i];
				long* num = arr + j;
				num2 = arr[j];
				num3 = arr[i];
				reference = num2;
				*num = num3;
			}
		}
		reference = ref arr[i + 1];
		long* num4 = arr + high;
		num3 = arr[high];
		num2 = arr[i + 1];
		reference = num3;
		*num4 = num2;
		return i + 1;
	}

	public unsafe static void Sort(int* pList, int count)
	{
		if (count <= 30)
		{
			BubbleSort(pList, count);
		}
		QuickSort(pList, 0, count - 1);
	}

	private unsafe static void BubbleSort(int* pList, int count)
	{
		for (int i = 0; i < count - 1; i++)
		{
			for (int j = 0; j < count - i - 1; j++)
			{
				if (pList[j] > pList[j + 1])
				{
					ref int reference = ref pList[j];
					int* num = pList + (j + 1);
					int num2 = pList[j + 1];
					int num3 = pList[j];
					reference = num2;
					*num = num3;
				}
			}
		}
	}

	private unsafe static void QuickSort(int* arr, int low, int high)
	{
		if (low < high)
		{
			int pi = Partition(arr, low, high);
			QuickSort(arr, low, pi - 1);
			QuickSort(arr, pi + 1, high);
		}
	}

	private unsafe static int Partition(int* arr, int low, int high)
	{
		int pivot = arr[high];
		int i = low - 1;
		ref int reference;
		int num3;
		int num2;
		for (int j = low; j <= high - 1; j++)
		{
			if (arr[j] < pivot)
			{
				i++;
				reference = ref arr[i];
				int* num = arr + j;
				num2 = arr[j];
				num3 = arr[i];
				reference = num2;
				*num = num3;
			}
		}
		reference = ref arr[i + 1];
		int* num4 = arr + high;
		num3 = arr[high];
		num2 = arr[i + 1];
		reference = num3;
		*num4 = num2;
		return i + 1;
	}

	public static void Sort<T>(IList<T> pList, Func<T, T, int> compareTo)
	{
		if (pList.Count <= 30)
		{
			BubbleSort(pList, pList.Count, compareTo);
		}
		QuickSort(pList, 0, pList.Count - 1, compareTo);
	}

	private static void BubbleSort<T>(IList<T> pList, int count, Func<T, T, int> compareTo)
	{
		for (int i = 0; i < count - 1; i++)
		{
			for (int j = 0; j < count - i - 1; j++)
			{
				if (compareTo(pList[j], pList[j + 1]) > 0)
				{
					int index = j;
					int index2 = j + 1;
					T value = pList[j + 1];
					T value2 = pList[j];
					pList[index] = value;
					pList[index2] = value2;
				}
			}
		}
	}

	private static void QuickSort<T>(IList<T> arr, int low, int high, Func<T, T, int> compareTo)
	{
		if (low < high)
		{
			int pi = Partition(arr, low, high, compareTo);
			QuickSort(arr, low, pi - 1, compareTo);
			QuickSort(arr, pi + 1, high, compareTo);
		}
	}

	private static int Partition<T>(IList<T> arr, int low, int high, Func<T, T, int> compareTo)
	{
		T pivot = arr[high];
		int i = low - 1;
		IList<T> list;
		int index2;
		int index;
		T value2;
		T value;
		for (int j = low; j <= high - 1; j++)
		{
			if (compareTo(arr[j], pivot) < 0)
			{
				i++;
				list = arr;
				index = i;
				index2 = j;
				value = arr[j];
				value2 = arr[i];
				list[index] = value;
				arr[index2] = value2;
			}
		}
		list = arr;
		index2 = i + 1;
		index = high;
		value2 = arr[high];
		value = arr[i + 1];
		list[index2] = value2;
		arr[index] = value;
		return i + 1;
	}

	public unsafe static void Shuffle<T>(IRandomSource random, T* pArray, int arrayCount) where T : unmanaged
	{
		for (int i = arrayCount - 1; i > 0; i--)
		{
			int swapIdx = random.Next(i + 1);
			ref T reference = ref pArray[swapIdx];
			T* num = pArray + i;
			T val = pArray[i];
			T val2 = pArray[swapIdx];
			reference = val;
			*num = val2;
		}
	}

	public static void Shuffle<T>(IRandomSource random, Span<T> pArray, int arrayCount) where T : unmanaged
	{
		for (int i = arrayCount - 1; i > 0; i--)
		{
			int swapIdx = random.Next(i + 1);
			ref T reference = ref pArray[swapIdx];
			ref T reference2 = ref pArray[i];
			T val = pArray[i];
			T val2 = pArray[swapIdx];
			reference = val;
			reference2 = val2;
		}
	}

	public static void Shuffle<T>(IRandomSource random, T[] array)
	{
		for (int i = array.Length - 1; i > 0; i--)
		{
			int swapIdx = random.Next(i + 1);
			int num = swapIdx;
			int num2 = i;
			T val = array[i];
			T val2 = array[swapIdx];
			array[num] = val;
			array[num2] = val2;
		}
	}

	public static void Shuffle<T>(IRandomSource random, List<T> list)
	{
		for (int i = list.Count - 1; i > 0; i--)
		{
			int swapIdx = random.Next(i + 1);
			int index = swapIdx;
			int index2 = i;
			T value = list[i];
			T value2 = list[swapIdx];
			list[index] = value;
			list[index2] = value2;
		}
	}

	public static void Shuffle<T>(IRandomSource random, IList<T> list)
	{
		for (int i = list.Count - 1; i > 0; i--)
		{
			int swapIdx = random.Next(i + 1);
			int index = swapIdx;
			int index2 = i;
			T value = list[i];
			T value2 = list[swapIdx];
			list[index] = value;
			list[index2] = value2;
		}
	}

	public static void Shuffle<T>(IRandomSource random, SpanList<T> list) where T : unmanaged
	{
		for (int i = list.Count - 1; i > 0; i--)
		{
			int swapIdx = random.Next(i + 1);
			ref T reference = ref list[swapIdx];
			ref T reference2 = ref list[i];
			T val = list[i];
			T val2 = list[swapIdx];
			reference = val;
			reference2 = val2;
		}
	}

	public unsafe static T* Shuffle<T>(IRandomSource random, T* pArray, int arrayCount, int shuffleCount) where T : unmanaged
	{
		for (int i = arrayCount - 1; i > arrayCount - 1 - shuffleCount; i--)
		{
			int swapIdx = random.Next(i + 1);
			ref T reference = ref pArray[swapIdx];
			T* num = pArray + i;
			T val = pArray[i];
			T val2 = pArray[swapIdx];
			reference = val;
			*num = val2;
		}
		return pArray + arrayCount - shuffleCount;
	}

	public static int Shuffle<T>(IRandomSource random, T[] array, int shuffleCount)
	{
		int arrayCount = array.Length;
		for (int i = arrayCount - 1; i > arrayCount - 1 - shuffleCount; i--)
		{
			int swapIdx = random.Next(i + 1);
			int num = swapIdx;
			int num2 = i;
			T val = array[i];
			T val2 = array[swapIdx];
			array[num] = val;
			array[num2] = val2;
		}
		return arrayCount - shuffleCount;
	}

	public static int Shuffle<T>(IRandomSource random, List<T> list, int shuffleCount)
	{
		int listCount = list.Count;
		for (int i = listCount - 1; i > listCount - 1 - shuffleCount; i--)
		{
			int swapIdx = random.Next(i + 1);
			int index = swapIdx;
			int index2 = i;
			T value = list[i];
			T value2 = list[swapIdx];
			list[index] = value;
			list[index2] = value2;
		}
		return listCount - shuffleCount;
	}

	public unsafe static T GetRandomWeightedElement<T>(IRandomSource random, (T value, short weight)* weights, int elementCount) where T : unmanaged
	{
		int totalWeight = 0;
		for (int i = 0; i < elementCount; i++)
		{
			totalWeight += weights[i].Item2;
		}
		int targetValue = random.Next(totalWeight);
		for (int j = 0; j < elementCount; j++)
		{
			short weight = weights[j].Item2;
			if (targetValue < weight)
			{
				return weights[j].Item1;
			}
			targetValue -= weight;
		}
		return weights[elementCount - 1].Item1;
	}

	public unsafe static int GetRandomWeightedElement(IRandomSource random, sbyte* pWeightedElements, int elementsCount, int totalWeight)
	{
		int targetValue = random.Next(totalWeight);
		for (int i = 0; i < elementsCount; i++)
		{
			sbyte weight = pWeightedElements[i];
			if (targetValue < weight)
			{
				return i;
			}
			targetValue -= weight;
		}
		return elementsCount;
	}

	public static int GetRandomWeightedElement(IRandomSource random, Span<int> pWeightedElements)
	{
		if (pWeightedElements.Length <= 0)
		{
			return -1;
		}
		int totalWeight = 0;
		Span<int> span = pWeightedElements;
		for (int i = 0; i < span.Length; i++)
		{
			int t = span[i];
			totalWeight += t;
		}
		if (totalWeight == 0)
		{
			return random.Next(pWeightedElements.Length);
		}
		int targetValue = random.Next(totalWeight);
		for (int j = 0; j < pWeightedElements.Length; j++)
		{
			int weight = pWeightedElements[j];
			if (targetValue < weight)
			{
				return j;
			}
			targetValue -= weight;
		}
		return pWeightedElements.Length;
	}

	public unsafe static int GetRandomAccumulativeWeightedElement(IRandomSource random, int* pAccumulativeWeightedElements, int elementsCount)
	{
		int totalWeight = pAccumulativeWeightedElements[elementsCount - 1];
		int targetValue = 1 + random.Next(totalWeight);
		int index = BinarySearch(pAccumulativeWeightedElements, 0, elementsCount, targetValue);
		if (index < 0)
		{
			return ~index;
		}
		while (index - 1 >= 0 && pAccumulativeWeightedElements[index - 1] == targetValue)
		{
			index--;
		}
		return index;
	}

	public static void MoveIndexToFirst<T>(this IList<T> list, int index)
	{
		if (list == null)
		{
			throw new ArgumentNullException("list");
		}
		if (index < 0 || index >= list.Count)
		{
			throw new ArgumentOutOfRangeException("index", index, $"count={list.Count}");
		}
		if (index != 0)
		{
			T value = list[index];
			for (int i = index; i > 0; i--)
			{
				list[i] = list[i - 1];
			}
			list[0] = value;
		}
	}

	public static void MoveLastToFirst<T>(this IList<T> list, int count)
	{
		if (list == null)
		{
			throw new ArgumentNullException("list");
		}
		if (count < 0 || count > list.Count)
		{
			throw new ArgumentOutOfRangeException("count", count, $"count={list.Count}");
		}
		if (count != 0 && count != list.Count)
		{
			list.Reverse();
			list.Reverse(0, count);
			list.Reverse(count, list.Count - count);
		}
	}

	public static void Reverse<T>(this IList<T> list)
	{
		list.Reverse(0, list.Count);
	}

	public static void Reverse<T>(this IList<T> list, int startIndex, int count)
	{
		if (list == null)
		{
			throw new ArgumentNullException("list");
		}
		if (startIndex < 0 || startIndex >= list.Count)
		{
			throw new ArgumentOutOfRangeException("startIndex", startIndex, $"count={list.Count}");
		}
		if (count < 0 || startIndex + count > list.Count)
		{
			throw new ArgumentOutOfRangeException("count", count, $"count={list.Count} index={startIndex}");
		}
		for (int i = 0; i < count / 2; i++)
		{
			int index = startIndex + i;
			int index2 = startIndex + count - i - 1;
			T value = list[startIndex + count - i - 1];
			T value2 = list[startIndex + i];
			list[index] = value;
			list[index2] = value2;
		}
	}

	public static int TryInsertTopK<T>(this ref SpanList<(T, int worth)> topK, int k, T element, int worth) where T : unmanaged
	{
		if (topK.Count > 0)
		{
			if (topK.Count == k)
			{
				if (topK[topK.Count - 1].worth >= worth)
				{
					return -1;
				}
			}
			for (int i = topK.Count - 1; i >= 0; i--)
			{
				if (topK[i].worth >= worth)
				{
					if (topK.Count == k)
					{
						topK.RemoveAt(k - 1);
					}
					int index = i + 1;
					if (index < topK.Count)
					{
						topK.Insert(index, (element, worth));
					}
					else
					{
						topK.Add((element, worth));
					}
					return index;
				}
			}
			if (topK.Count == k)
			{
				topK.RemoveAt(k - 1);
			}
			if (topK.Count == 0)
			{
				topK.Add((element, worth));
			}
			else
			{
				topK.Insert(0, (element, worth));
			}
			return 0;
		}
		topK.Add((element, worth));
		return topK.Count - 1;
	}

	public static void SwapAndRemove<T>(IList<T> list, int index)
	{
		int lastIndex = list.Count - 1;
		list[index] = list[lastIndex];
		list.RemoveAt(lastIndex);
	}

	public static void RemoveAllKeys<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Func<TKey, bool> keySelector, IList<TKey> cache = null)
	{
		if (dictionary == null || dictionary.Count <= 0)
		{
			return;
		}
		if (cache == null)
		{
			cache = new List<TKey>();
		}
		cache.Clear();
		foreach (TKey key in dictionary.Keys)
		{
			if (keySelector(key))
			{
				cache.Add(key);
			}
		}
		foreach (TKey key2 in cache)
		{
			dictionary.Remove(key2);
		}
	}

	public static void RemoveDuplicateKeys<TKey, TValue1, TValue2>(this IDictionary<TKey, TValue1> destination, IReadOnlyDictionary<TKey, TValue2> source, IList<TKey> cache = null)
	{
		if (destination == null || destination.Count <= 0 || source == null || source.Count <= 0)
		{
			return;
		}
		if (cache == null)
		{
			cache = new List<TKey>();
		}
		cache.Clear();
		foreach (TKey key in destination.Keys)
		{
			if (source.ContainsKey(key))
			{
				cache.Add(key);
			}
		}
		foreach (TKey key2 in cache)
		{
			destination.Remove(key2);
		}
	}

	public static int Accumulate<TKey>(this IDictionary<TKey, int> dictionary, TKey key, int value = 1)
	{
		dictionary.TryGetValue(key, out var existValue);
		return dictionary[key] = value + existValue;
	}

	public unsafe static void CopyTo<T>(HashSet<T> collection, T* pMemory) where T : unmanaged
	{
		int i = 0;
		foreach (T element in collection)
		{
			pMemory[i++] = element;
		}
	}

	public static void AddRepeat<T>(this IList<T> list, T element, int count)
	{
		for (int i = 0; i < count; i++)
		{
			list.Add(element);
		}
	}

	public static bool AddUnique<T>(this IList<T> list, T element)
	{
		if (list == null)
		{
			throw new ArgumentNullException("list");
		}
		if (list.Contains(element))
		{
			return false;
		}
		list.Add(element);
		return true;
	}

	public static bool AddUniqueRange<T>(this IList<T> list, IEnumerable<T> elements)
	{
		if (list == null)
		{
			throw new ArgumentNullException("list");
		}
		if (elements == null)
		{
			throw new ArgumentNullException("elements");
		}
		if (list == elements)
		{
			throw new ArgumentException("Cannot add a unique range to itself.", "elements");
		}
		bool anyChanged = false;
		foreach (T element in elements)
		{
			anyChanged = list.AddUnique(element) || anyChanged;
		}
		return anyChanged;
	}

	public static IntList RemoveDuplicates(this IntList list)
	{
		List<int> items = list.Items;
		if (items == null || items.Count <= 1)
		{
			return list;
		}
		List<int> distinctItems = new List<int>(list.Items.Count);
		HashSet<int> seenItems = new HashSet<int>(list.Items.Count);
		foreach (int item in list.Items)
		{
			if (seenItems.Add(item))
			{
				distinctItems.Add(item);
			}
		}
		if (distinctItems.Count == list.Items.Count)
		{
			return list;
		}
		list.Items = distinctItems;
		return list;
	}

	public static TValue GetOrNew<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : class, new()
	{
		if (dictionary.TryGetValue(key, out var value))
		{
			return value;
		}
		return dictionary[key] = new TValue();
	}

	public static TValue GetOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
	{
		return dictionary.GetValueOrDefault(key);
	}

	public static TValue GetOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
	{
		return dictionary.GetValueOrDefault(key, defaultValue);
	}

	public static TValue? GetOrNull<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key) where TValue : struct
	{
		if (!dictionary.TryGetValue(key, out var value))
		{
			return null;
		}
		return value;
	}

	public static T GetOrDefault<T>(this IReadOnlyList<T> list, int index)
	{
		return list.GetOrDefault(index, default(T));
	}

	public static T GetOrDefault<T>(this IReadOnlyList<T> list, int index, T defaultValue)
	{
		if (index >= 0 && index < list.Count)
		{
			return list[index];
		}
		return defaultValue;
	}

	public static int GetClampedIndex<T>(this IReadOnlyList<T> list, int index)
	{
		if (list == null || list.Count <= 0)
		{
			throw new ArgumentException("The list is empty or null.");
		}
		return MathUtils.Clamp(index, 0, list.Count - 1);
	}

	public static T GetClampedIndexValue<T>(this IReadOnlyList<T> list, int index)
	{
		if (list == null || list.Count <= 0)
		{
			throw new ArgumentException("The list is empty or null.");
		}
		index = MathUtils.Clamp(index, 0, list.Count - 1);
		return list[index];
	}

	public static T GetClampedIndexValueWithWarning<T>(this IReadOnlyList<T> list, int index, string warningMessage)
	{
		T clampedIndexValue = list.GetClampedIndexValue(index);
		if (index < 0 || index >= list.Count)
		{
			AdaptableLog.Warning($"Index {index} out of range 0~{list.Count} by fallback {warningMessage}", appendWarningMessage: true);
		}
		return clampedIndexValue;
	}

	public static T GetOrLast<T>(this IReadOnlyList<T> list, int index)
	{
		if (list == null || list.Count == 0)
		{
			throw new ArgumentException("The list is empty or null.");
		}
		if (index >= list.Count)
		{
			return list[list.Count - 1];
		}
		return list[index];
	}

	public static bool All<T>(this IEnumerable<T> collection, T item) where T : IEquatable<T>
	{
		foreach (T item2 in collection)
		{
			if (!item2.Equals(item))
			{
				return false;
			}
		}
		return true;
	}

	public static void ClearAndAddRange<T>(this List<T> list, IEnumerable<T> append)
	{
		list.Clear();
		list.AddRange(append);
	}

	public static T SetOrAdd<T>(this IList<T> list, int index, T value, T defaultValue = default(T))
	{
		for (int i = list.Count; i < index; i++)
		{
			list.Add(defaultValue);
		}
		if (list.CheckIndex(index))
		{
			list[index] = value;
		}
		else
		{
			list.Add(value);
		}
		return value;
	}

	public static KeyValuePair<TKey, TValue> GetRandomItem<TKey, TValue>(this Dictionary<TKey, TValue> dict, Random random = null)
	{
		if (dict == null || dict.Count == 0)
		{
			throw new ArgumentException("字典不能为空");
		}
		if (random == null)
		{
			random = new Random();
		}
		int index = random.Next(dict.Count);
		foreach (KeyValuePair<TKey, TValue> kvp in dict)
		{
			if (index == 0)
			{
				return kvp;
			}
			index--;
		}
		throw new InvalidOperationException("无法获取随机内容");
	}

	public static TValue GetRandomValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, Random random = null)
	{
		return dict.GetRandomItem(random).Value;
	}

	public static TKey GetRandomKey<TKey, TValue>(this Dictionary<TKey, TValue> dict, Random random = null)
	{
		return dict.GetRandomItem(random).Key;
	}

	public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> items)
	{
		if (dictionary == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		if (items == null)
		{
			throw new ArgumentNullException("items");
		}
		if (items is ICollection<KeyValuePair<TKey, TValue>> collection)
		{
			dictionary.EnsureCapacity(dictionary.Count + collection.Count);
		}
		foreach (KeyValuePair<TKey, TValue> item in items)
		{
			dictionary.Add(item.Key, item.Value);
		}
	}
}
