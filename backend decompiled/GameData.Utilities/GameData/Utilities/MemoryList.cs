using System;

namespace GameData.Utilities;

[Obsolete("Use SpanList instead.")]
public struct MemoryList<T> where T : unmanaged
{
	public unsafe readonly T* PData;

	public readonly short Capacity;

	public short Count;

	public unsafe MemoryList(T* pData, short capacity, short size = 0)
	{
		Tester.Assert(pData != null);
		Tester.Assert(capacity > 0);
		Tester.Assert(size >= 0);
		Tester.Assert(capacity >= size);
		PData = pData;
		Capacity = capacity;
		Count = size;
	}

	public unsafe void Add(T item)
	{
		Tester.Assert(Count < Capacity);
		PData[Count++] = item;
	}

	public unsafe void SwapAndRemove(int index)
	{
		Tester.Assert(Count > 0);
		PData[index] = PData[Count - 1];
		Count--;
	}

	public void Clear()
	{
		Count = 0;
	}
}
