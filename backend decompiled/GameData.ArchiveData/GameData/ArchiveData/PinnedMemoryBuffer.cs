using System;
using System.Runtime.InteropServices;

namespace GameData.ArchiveData;

public class PinnedMemoryBuffer : IDisposable
{
	private byte[] _buffer;

	private unsafe byte* _pointer;

	private GCHandle _handle;

	public readonly int MaxCapacity;

	public const int DataSizeLimit = 16777216;

	public unsafe PinnedMemoryBuffer(int initCapacity, int maxCapacity = 16777216)
	{
		_buffer = new byte[initCapacity];
		_handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
		_pointer = (byte*)_handle.AddrOfPinnedObject().ToPointer();
		MaxCapacity = maxCapacity;
	}

	public unsafe byte* Allocate(int size)
	{
		if (size > MaxCapacity || size < 0)
		{
			throw new ArgumentException($"Unable to allocate in buffer with size {size}. Valid range: [0, {MaxCapacity}].");
		}
		int currSize = _buffer.Length;
		if (size <= currSize)
		{
			return _pointer;
		}
		int newSize;
		for (newSize = currSize << 1; newSize < size; newSize <<= 1)
		{
		}
		if (newSize > MaxCapacity)
		{
			newSize = MaxCapacity;
		}
		Resize(newSize);
		return _pointer;
	}

	private unsafe void Resize(int size)
	{
		if (_pointer != null)
		{
			_handle.Free();
			_pointer = null;
		}
		_buffer = new byte[size];
		_handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
		_pointer = (byte*)_handle.AddrOfPinnedObject().ToPointer();
	}

	public unsafe void Dispose()
	{
		if (_pointer != null)
		{
			_handle.Free();
			_buffer = null;
			_pointer = null;
		}
	}

	~PinnedMemoryBuffer()
	{
		Dispose();
	}
}
