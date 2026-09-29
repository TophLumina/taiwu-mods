using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Config;
using GameData.GameDataBridge.VnPipe;

namespace GameData.Utilities;

public class RawDataPool : Stream
{
	public const int InvalidOffset = -1;

	public const int DataSizeLimit = 33554432;

	private const int DefaultCapacity = 16;

	private static readonly byte[] EmptyArray = Array.Empty<byte>();

	private byte[] _rawData;

	private GCHandle _rawDataHandle;

	private unsafe byte* _rawDataPointer;

	private readonly int _initialCapacity;

	private int _size;

	private bool _disposed;

	private int _streamCurrReadingOffset;

	public int RawDataSize => _size;

	public int Capacity => _rawData.Length;

	public override bool CanRead => true;

	public override bool CanSeek => false;

	public override bool CanWrite => true;

	public override long Length
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override long Position
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public RawDataPool(int initialCapacity)
	{
		_initialCapacity = initialCapacity;
		_rawData = EmptyArray;
	}

	public unsafe RawDataPool(Socket socket, int size)
	{
		if (size <= 0)
		{
			_initialCapacity = 16;
			_rawData = EmptyArray;
			return;
		}
		_rawData = new byte[size];
		int received;
		for (int totalReceived = 0; totalReceived < size; totalReceived += received)
		{
			received = socket.Receive(_rawData, totalReceived, size - totalReceived, SocketFlags.None);
			if (received == 0)
			{
				throw new Exception("The socket has been shut down.");
			}
		}
		_rawDataHandle = GCHandle.Alloc(_rawData, GCHandleType.Pinned);
		_rawDataPointer = (byte*)_rawDataHandle.AddrOfPinnedObject().ToPointer();
		_initialCapacity = size;
		_size = size;
	}

	public unsafe RawDataPool(IPipe pipe, int size)
	{
		if (size <= 0)
		{
			_initialCapacity = 16;
			_rawData = EmptyArray;
			return;
		}
		_rawData = new byte[size];
		int received;
		for (int totalReceived = 0; totalReceived < size; totalReceived += received)
		{
			received = pipe.Read(_rawData, totalReceived, size - totalReceived);
		}
		_rawDataHandle = GCHandle.Alloc(_rawData, GCHandleType.Pinned);
		_rawDataPointer = (byte*)_rawDataHandle.AddrOfPinnedObject().ToPointer();
		_initialCapacity = size;
		_size = size;
	}

	protected unsafe override void Dispose(bool disposingManaged)
	{
		if (!_disposed)
		{
			if (_rawDataPointer != null)
			{
				_rawDataHandle.Free();
				_rawDataPointer = null;
			}
			_disposed = true;
			base.Dispose(disposingManaged);
		}
	}

	~RawDataPool()
	{
		Dispose(false);
	}

	public unsafe void SetCapacity(int capacity)
	{
		if (capacity < _size)
		{
			throw new ArgumentOutOfRangeException("capacity", "New capacity cannot be less than the used size");
		}
		int oriCapacity = _rawData.Length;
		if (capacity == oriCapacity)
		{
			return;
		}
		if (capacity > 0)
		{
			byte[] newRawData = new byte[capacity];
			if (_size > 0)
			{
				GCHandle newHandle = GCHandle.Alloc(newRawData, GCHandleType.Pinned);
				byte* newPointer = (byte*)newHandle.AddrOfPinnedObject().ToPointer();
				Buffer.MemoryCopy(_rawDataPointer, newPointer, _size, _size);
				_rawData = newRawData;
				_rawDataHandle.Free();
				_rawDataHandle = newHandle;
				_rawDataPointer = newPointer;
			}
			else
			{
				_rawData = newRawData;
				if (oriCapacity > 0)
				{
					_rawDataHandle.Free();
				}
				_rawDataHandle = GCHandle.Alloc(_rawData, GCHandleType.Pinned);
				_rawDataPointer = (byte*)_rawDataHandle.AddrOfPinnedObject().ToPointer();
			}
		}
		else
		{
			_rawData = EmptyArray;
			if (oriCapacity > 0)
			{
				_rawDataHandle.Free();
			}
			_rawDataPointer = null;
		}
	}

	public void Clear()
	{
		_size = 0;
	}

	public void SetStreamReadingOffset(int offset)
	{
		_streamCurrReadingOffset = offset;
	}

	public int GetStreamReadingOffset()
	{
		return _streamCurrReadingOffset;
	}

	public override void Flush()
	{
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}

	public unsafe override int Read(byte[] buffer, int offset, int count)
	{
		if (_streamCurrReadingOffset + count > _size)
		{
			return 0;
		}
		fixed (byte* pBuffer = buffer)
		{
			Buffer.MemoryCopy(_rawDataPointer + _streamCurrReadingOffset, pBuffer + offset, count, count);
		}
		_streamCurrReadingOffset += count;
		return count;
	}

	public unsafe override int ReadByte()
	{
		if (_streamCurrReadingOffset >= _size)
		{
			return -1;
		}
		byte* num = _rawDataPointer + _streamCurrReadingOffset;
		_streamCurrReadingOffset++;
		return *num;
	}

	public unsafe override void Write(byte[] buffer, int offset, int count)
	{
		int destOffset = _size;
		int newSize = _size + count;
		EnsureCapacity(newSize);
		_size = newSize;
		fixed (byte* pBuffer = buffer)
		{
			Buffer.MemoryCopy(pBuffer + offset, _rawDataPointer + destOffset, count, count);
		}
	}

	public unsafe override void WriteByte(byte value)
	{
		int destOffset = _size;
		int newSize = _size + 1;
		EnsureCapacity(newSize);
		_size = newSize;
		_rawDataPointer[destOffset] = value;
	}

	public int GetWritingOffset()
	{
		return _size;
	}

	public int GetWrittenDataSize(int offset)
	{
		return _size - offset;
	}

	public unsafe byte* GetPointer(int offset)
	{
		return _rawDataPointer + offset;
	}

	public unsafe byte* GetPointerWithHeader(int offset, uint* pHeader)
	{
		byte* pData = _rawDataPointer + offset;
		*pHeader = *(uint*)pData;
		return pData + 4;
	}

	public unsafe int AddUnmanaged<T>(T value) where T : unmanaged
	{
		int offset = _size;
		int newSize = _size + sizeof(T);
		EnsureCapacity(newSize);
		_size = newSize;
		*(T*)(_rawDataPointer + offset) = value;
		return offset;
	}

	public unsafe void SetUnmanaged<T>(int offset, T value) where T : unmanaged
	{
		if (offset + sizeof(T) > _size)
		{
			throw new Exception(string.Format("Trying to write value of type {0} at offset {1}, which should not exceed the allocated size {2}.", "T", offset, _size));
		}
		*(T*)(_rawDataPointer + offset) = value;
	}

	public unsafe T GetUnmanaged<T>(int offset) where T : unmanaged
	{
		return *(T*)(_rawDataPointer + offset);
	}

	public unsafe int Add(byte* pData, int dataSize)
	{
		int offset = _size;
		int newSize = _size + dataSize;
		EnsureCapacity(newSize);
		_size = newSize;
		if (dataSize > 0)
		{
			Buffer.MemoryCopy(pData, _rawDataPointer + offset, dataSize, dataSize);
		}
		return offset;
	}

	public unsafe int AddWithHeader(byte* pData, int dataSize, uint header, bool checkMaxSize = true)
	{
		if (checkMaxSize && dataSize > 33554432)
		{
			PredefinedLog.DefValue.SerializedSizeExceedLimit.Log(dataSize / 1024, 32768);
		}
		int offset = _size;
		int newSize = _size + 4 + dataSize;
		EnsureCapacity(newSize);
		_size = newSize;
		byte* pDest = _rawDataPointer + offset;
		*(uint*)pDest = header;
		pDest += 4;
		if (dataSize > 0)
		{
			Buffer.MemoryCopy(pData, pDest, dataSize, dataSize);
		}
		return offset;
	}

	public unsafe int Allocate(int dataSize, byte** ppData)
	{
		int offset = _size;
		int newSize = _size + dataSize;
		EnsureCapacity(newSize);
		_size = newSize;
		*ppData = _rawDataPointer + offset;
		return offset;
	}

	public unsafe int AllocateWithHeader(int dataSize, byte** ppData, uint header, bool checkMaxSize = true)
	{
		if (checkMaxSize && dataSize > 33554432)
		{
			PredefinedLog.DefValue.SerializedSizeExceedLimit.Log(dataSize / 1024, 32768);
		}
		int offset = _size;
		int newSize = _size + 4 + dataSize;
		EnsureCapacity(newSize);
		_size = newSize;
		byte* pDest = _rawDataPointer + offset;
		*(uint*)pDest = header;
		*ppData = pDest + 4;
		return offset;
	}

	public int CopyTo(Socket socket)
	{
		if (_size <= 0)
		{
			return 0;
		}
		return socket.Send(_rawData, 0, _size, SocketFlags.None);
	}

	public int CopyTo(IPipe pipe)
	{
		if (_size <= 0)
		{
			return 0;
		}
		return pipe.Write(_rawData, 0, _size);
	}

	private void EnsureCapacity(int min)
	{
		int oriCapacity = _rawData.Length;
		if (oriCapacity < min)
		{
			int newCapacity = ((oriCapacity == 0) ? _initialCapacity : (oriCapacity * 2));
			if ((uint)newCapacity > 2147483647u)
			{
				newCapacity = int.MaxValue;
			}
			if (newCapacity < min)
			{
				newCapacity = min;
			}
			SetCapacity(newCapacity);
		}
	}
}
