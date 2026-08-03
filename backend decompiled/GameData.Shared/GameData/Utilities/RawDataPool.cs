using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Config;
using GameData.GameDataBridge.VnPipe;

namespace GameData.Utilities;

/// <summary>
/// 二进制数据池, 通过偏移和长度来定位数据.
/// 数据长度暂时添加软限制 16 mb (特殊情况下可以超过此值).
/// 该限制主要作为一种数据验证和提醒，以防止因数据错误而申请巨量内存却没有即使抛出，以及设计层面上的无限制扩大一次性传输的数据。
/// 数据只能添加, 不能修改也不能移除, 因此只供一次性使用.
/// 原始数据存放空间会一直处于 pinned 状态.
/// </summary>
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

	/// <summary>
	/// 池中保存的原始数据的字节数 (小于等于原始数据数组长度)
	/// </summary>
	private int _size;

	private bool _disposed;

	/// <summary>
	/// [Stream 接口专用] 当前读取偏移
	/// </summary>
	private int _streamCurrReadingOffset;

	/// <summary>
	/// 池中保存的原始数据的字节数 (小于等于原始数据数组长度)
	/// </summary>
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

	/// <summary>
	/// 从 Socket 中读取原始数据, 并初始化此对象
	/// </summary>
	/// <param name="socket"></param>
	/// <param name="size"></param>
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

	/// <summary>
	/// 清除所有数据, 但不改变容量
	/// </summary>
	public void Clear()
	{
		_size = 0;
	}

	/// <summary>
	/// 设置当前的读取偏移.
	/// 调用 Stream 的相关读操作之前, 必须调用此方法.
	/// </summary>
	/// <param name="offset"></param>
	public void SetStreamReadingOffset(int offset)
	{
		_streamCurrReadingOffset = offset;
	}

	/// <summary>
	/// 获取当前的读取偏移.
	/// 调用 Stream 的相关读操作之后, 必须调用此方法.
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 获取要写入的数据的偏移
	/// </summary>
	/// <returns>当前数据偏移</returns>
	public int GetWritingOffset()
	{
		return _size;
	}

	/// <summary>
	/// 获取已写入的数据的长度
	/// </summary>
	/// <param name="offset">之前通过 GetWritingOffset 获得的数据偏移</param>
	/// <returns>写入的数据的长度</returns>
	public int GetWrittenDataSize(int offset)
	{
		return _size - offset;
	}

	/// <summary>
	/// 获取数据的地址
	/// </summary>
	/// <param name="offset"></param>
	/// <returns></returns>
	public unsafe byte* GetPointer(int offset)
	{
		return _rawDataPointer + offset;
	}

	/// <summary>
	/// 获取数据的地址, 跳过了数据头.
	/// 数据头固定 4 字节, 一般是元素个数, 或者数据长度.
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="pHeader"></param>
	/// <returns></returns>
	public unsafe byte* GetPointerWithHeader(int offset, uint* pHeader)
	{
		byte* pData = _rawDataPointer + offset;
		*pHeader = *(uint*)pData;
		return pData + 4;
	}

	/// <summary>
	/// 添加非托管类型的数据
	/// </summary>
	/// <param name="value"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public unsafe int AddUnmanaged<T>(T value) where T : unmanaged
	{
		int offset = _size;
		int newSize = _size + sizeof(T);
		EnsureCapacity(newSize);
		_size = newSize;
		*(T*)(_rawDataPointer + offset) = value;
		return offset;
	}

	/// <summary>
	/// 直接将非托管类型数据写入到已分配的地址
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="value"></param>
	/// <typeparam name="T"></typeparam>
	public unsafe void SetUnmanaged<T>(int offset, T value) where T : unmanaged
	{
		if (offset + sizeof(T) > _size)
		{
			throw new Exception(string.Format("Trying to write value of type {0} at offset {1}, which should not exceed the allocated size {2}.", "T", offset, _size));
		}
		*(T*)(_rawDataPointer + offset) = value;
	}

	/// <summary>
	/// 获取非托管类型的数据
	/// </summary>
	/// <param name="offset"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public unsafe T GetUnmanaged<T>(int offset) where T : unmanaged
	{
		return *(T*)(_rawDataPointer + offset);
	}

	/// <summary>
	/// 添加二进制数据
	/// </summary>
	/// <param name="pData"></param>
	/// <param name="dataSize"></param>
	/// <returns></returns>
	/// <exception cref="T:System.Exception"></exception>
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

	/// <summary>
	/// 添加二进制数据, 包括数据头.
	/// 数据头固定 4 字节, 一般是元素个数, 或者数据长度.
	/// </summary>
	/// <param name="pData"></param>
	/// <param name="dataSize"></param>
	/// <param name="header"></param>
	/// <param name="checkMaxSize"></param>
	/// <returns></returns>
	/// <exception cref="T:System.Exception"></exception>
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

	/// <summary>
	/// 在池中分配指定大小的数据内存, 由调用者写入值.
	/// 注意, 此方法设置的地址可能会在下次分配内存时失效.
	/// </summary>
	/// <remarks>
	/// 2023/11/27: 此方法设置的地址在内部扩容后也会失效, 因此应避免在后续逻辑分配了新的内存后继续对该地址进行操作, 而是应该改为通过 offset 修改、获取指定地址的数据.
	/// </remarks>
	/// <param name="dataSize"></param>
	/// <param name="ppData">存放 "分配的内存的起始地址" 数据的地址</param>
	/// <returns></returns>
	public unsafe int Allocate(int dataSize, byte** ppData)
	{
		int offset = _size;
		int newSize = _size + dataSize;
		EnsureCapacity(newSize);
		_size = newSize;
		*ppData = _rawDataPointer + offset;
		return offset;
	}

	/// <summary>
	/// 在池中分配指定大小的数据内存, 包括数据头.
	/// 数据头固定 4 字节, 一般是元素个数, 或者数据长度.
	/// 注意, 此方法设置的地址可能会在下次分配内存时失效.
	/// </summary>
	/// <remarks>
	/// 2023/11/27: 此方法设置的地址在内部扩容后也会失效, 因此应避免在后续逻辑分配了新的内存后继续对该地址进行操作, 而是应该改为通过 offset 修改、获取指定地址的数据.
	/// </remarks>
	/// <param name="dataSize"></param>
	/// <param name="ppData">存放 "分配的内存的起始地址" 数据的地址</param>
	/// <param name="header"></param>
	/// <param name="checkMaxSize"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 把所有有效数据用 Socket 发送出去
	/// </summary>
	/// <param name="socket"></param>
	/// <returns>已发送的字节数</returns>
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
