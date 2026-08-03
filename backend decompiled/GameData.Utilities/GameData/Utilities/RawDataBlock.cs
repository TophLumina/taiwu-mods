using System;
using System.Runtime.CompilerServices;
using GameData.Serializer;

namespace GameData.Utilities;

public class RawDataBlock : IBinary, ISerializableGameData
{
	private const int DefaultInitialCapacity = 16;

	private static readonly byte[] EmptyArray = Array.Empty<byte>();

	public byte[] RawData;

	public int Size;

	private readonly int _initialCapacity;

	public RawDataBlock()
		: this(16)
	{
	}

	public RawDataBlock(int initialCapacity)
	{
		RawData = EmptyArray;
		Size = 0;
		_initialCapacity = ((initialCapacity > 0) ? initialCapacity : 16);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return (4 + RawData.Length + 4 + 3) / 4 * 4;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int elementsCount = (*(int*)pCurrData = RawData.Length);
		pCurrData += 4;
		if (elementsCount > 0)
		{
			fixed (byte* pRawData = RawData)
			{
				Buffer.MemoryCopy(pRawData, pCurrData, elementsCount, elementsCount);
			}
			pCurrData += elementsCount;
		}
		*(int*)pCurrData = Size;
		pCurrData += 4;
		return ((int)(pCurrData - pData) + 3) / 4 * 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int elementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (elementsCount > 0)
		{
			if (RawData.Length < elementsCount)
			{
				RawData = new byte[elementsCount];
			}
			fixed (byte* pRawData = RawData)
			{
				Buffer.MemoryCopy(pCurrData, pRawData, elementsCount, elementsCount);
			}
			pCurrData += elementsCount;
		}
		Size = *(int*)pCurrData;
		pCurrData += 4;
		return ((int)(pCurrData - pData) + 3) / 4 * 4;
	}

	public unsafe int AddUnmanaged<T>(T value) where T : unmanaged
	{
		int offset = Size;
		int newSize = Size + sizeof(T);
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			*(T*)(pRawData + offset) = value;
		}
		return offset;
	}

	public unsafe int AddSerializableGameData(ISerializableGameData value)
	{
		int offset = Size;
		int newSize = Size + value.GetSerializedSize();
		EnsureCapacity(newSize);
		Size = newSize;
		int num;
		fixed (byte* pRawData = RawData)
		{
			num = value.Serialize(pRawData + offset);
		}
		Tester.Assert(num == newSize - offset);
		return offset;
	}

	public unsafe T GetUnmanaged<T>(int offset) where T : unmanaged
	{
		fixed (byte* pRawData = RawData)
		{
			return *(T*)(pRawData + offset);
		}
	}

	public unsafe int GetSerializableGameData<T>(ref T data, int offset) where T : ISerializableGameData, new()
	{
		if (data == null)
		{
			data = new T();
		}
		fixed (byte* pRawData = RawData)
		{
			return data.Deserialize(pRawData + offset);
		}
	}

	public unsafe void Insert(byte* pSrc, int offset, int size)
	{
		Tester.Assert(offset >= 0 && offset <= Size);
		Tester.Assert(size >= 0);
		int size2 = Size;
		int newSize = size2 + size;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pDest = RawData)
		{
			int movingSize = size2 - offset;
			if (movingSize > 0)
			{
				Buffer.MemoryCopy(pDest + offset, pDest + (offset + size), movingSize, movingSize);
			}
			Buffer.MemoryCopy(pSrc, pDest + offset, size, size);
		}
	}

	public unsafe void Write(byte* pSrc, int offset, int size)
	{
		Tester.Assert(offset >= 0 && offset <= Size);
		Tester.Assert(size >= 0);
		int oriSize = Size;
		int newSize = Math.Max(offset + size, oriSize);
		if (newSize > Size)
		{
			EnsureCapacity(newSize);
			Size = newSize;
		}
		fixed (byte* pDest = RawData)
		{
			Buffer.MemoryCopy(pSrc, pDest + offset, size, size);
		}
	}

	public unsafe void Remove(int offset, int size)
	{
		Tester.Assert(offset >= 0);
		Tester.Assert(size >= 0);
		Tester.Assert(offset + size <= Size);
		int movingSize = Size - (offset + size);
		if (movingSize > 0)
		{
			fixed (byte* pDest = RawData)
			{
				Buffer.MemoryCopy(pDest + (offset + size), pDest + offset, movingSize, movingSize);
			}
		}
		Size -= size;
	}

	public unsafe void Move(int srcOffset, int destOffset, int size)
	{
		Tester.Assert(srcOffset >= 0);
		Tester.Assert(destOffset >= 0);
		Tester.Assert(size >= 0);
		Tester.Assert(srcOffset + size <= Size);
		Tester.Assert(destOffset + size <= Size);
		fixed (byte* pDest = RawData)
		{
			Buffer.MemoryCopy(pDest + srcOffset, pDest + destOffset, size, size);
		}
	}

	public int GetSize()
	{
		return Size;
	}

	public void Clear()
	{
		Size = 0;
	}

	public void EnsureCapacity(int desiredSize)
	{
		int oriCapacity = RawData.Length;
		if (oriCapacity < desiredSize)
		{
			EnsureCapacityInternal(oriCapacity, desiredSize);
		}
	}

	public byte[] GetRawData()
	{
		return RawData;
	}

	public void SetRawData(byte[] rawData)
	{
		RawData = rawData;
	}

	public unsafe void CopyTo(int offset, int size, byte* pDest)
	{
		Tester.Assert(offset >= 0);
		Tester.Assert(size >= 0);
		Tester.Assert(offset + size <= Size);
		fixed (byte* pSrc = RawData)
		{
			Buffer.MemoryCopy(pSrc + offset, pDest, size, size);
		}
	}

	public ushort GetSerializedFixedSizeOfMetadata()
	{
		return 4;
	}

	public unsafe int SerializeMetadata(byte* pData)
	{
		*(int*)pData = Size;
		return 4;
	}

	public unsafe int DeserializeMetadata(byte* pData)
	{
		Size = *(int*)pData;
		EnsureCapacity(Size);
		return 4;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnsureCapacityInternal(int oriCapacity, int desiredSize)
	{
		int newCapacity = ((oriCapacity == 0) ? _initialCapacity : (oriCapacity * 2));
		if ((uint)newCapacity > 2147483647u)
		{
			newCapacity = int.MaxValue;
		}
		if (newCapacity < desiredSize)
		{
			newCapacity = desiredSize;
		}
		byte[] newRawData = new byte[newCapacity];
		if (oriCapacity > 0)
		{
			Buffer.BlockCopy(RawData, 0, newRawData, 0, oriCapacity);
		}
		RawData = newRawData;
	}
}
