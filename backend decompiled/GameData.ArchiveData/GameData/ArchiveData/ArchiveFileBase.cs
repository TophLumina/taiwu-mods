using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Hashing;
using GameData.Domains.Global;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.ArchiveData;

public abstract class ArchiveFileBase : IDisposable, IGameDataTypeFormatter
{
	protected readonly string Path;

	protected readonly Crc32 Crc32;

	protected Stream InternalStream;

	protected PinnedMemoryBuffer Buffer;

	public abstract ArchiveFileVersion ArchiveFileVersion { get; }

	protected ArchiveFileBase(string path)
	{
		Path = path;
		Crc32 = new Crc32();
		Buffer = new PinnedMemoryBuffer(4096);
	}

	public void Save(CompressionAlgorithm algorithm, CompressionType compressionType)
	{
		DirectoryInfo directory = Directory.GetParent(Path);
		if (directory != null)
		{
			Directory.CreateDirectory(directory.FullName);
		}
		using FileStream fileStream = File.Open(Path, FileMode.OpenOrCreate, FileAccess.Write);
		WriteHeader(fileStream, algorithm, compressionType);
		WriteContent(fileStream, algorithm, compressionType);
		fileStream.Close();
	}

	public void Load()
	{
		if (!File.Exists(Path))
		{
			throw new FileNotFoundException("Archive file not found.", Path);
		}
		using FileStream fileStream = File.Open(Path, FileMode.Open, FileAccess.Read);
		ArchiveFileVersion fileVersion = ArchiveFileVersion.Invalid;
		ArchiveFileMeta fileMeta = null;
		WorldInfo worldInfo = null;
		try
		{
			ReadHeader(fileStream, ref fileVersion, ref fileMeta, ref worldInfo);
		}
		catch (Exception)
		{
			fileStream.Close();
			throw;
		}
		if (fileVersion != ArchiveFileVersion)
		{
			fileStream.Close();
			throw new ArchiveFileHeaderException(ArchiveFileVersion, fileVersion);
		}
		ReadContent(fileStream, fileMeta);
		fileStream.Close();
	}

	public bool TryGetArchiveInfo(out ArchiveInfo archiveInfo)
	{
		archiveInfo = null;
		if (!File.Exists(Path))
		{
			return false;
		}
		using FileStream fileStream = File.Open(Path, FileMode.Open, FileAccess.Read);
		InternalStream = fileStream;
		try
		{
			archiveInfo = ReadArchiveInfo(fileStream);
			return archiveInfo != null;
		}
		catch (Exception arg)
		{
			AdaptableLog.Warning($"Failed to read archive info at {Path}. \n{arg}");
			archiveInfo = null;
			return false;
		}
		finally
		{
			fileStream.Close();
			InternalStream = null;
		}
	}

	public void WriteDomainDataMeta(ushort dataId)
	{
		DomainDataMeta meta = new DomainDataMeta
		{
			DataId = dataId
		};
		WriteSingleValueCustom(meta);
	}

	public DomainDataMeta ReadDomainDataMeta()
	{
		DomainDataMeta meta = default(DomainDataMeta);
		ReadSingleValueCustom(ref meta);
		return meta;
	}

	protected abstract ArchiveInfo ReadArchiveInfo(FileStream fileStream);

	protected abstract void WriteHeader(FileStream stream, CompressionAlgorithm algorithm, CompressionType compressionType);

	protected abstract void ReadHeader(FileStream stream, ref ArchiveFileVersion fileVersion, ref ArchiveFileMeta fileMeta, ref WorldInfo worldInfo);

	protected abstract void WriteContent(FileStream fileStream, CompressionAlgorithm compressionAlgorithm, CompressionType compressionType);

	protected abstract void ReadContent(FileStream fileStream, ArchiveFileMeta fileMeta);

	public void Dispose()
	{
		InternalStream?.Dispose();
	}

	public unsafe void WriteSingleValueUnmanaged<T>(T value) where T : unmanaged
	{
		int size = sizeof(T);
		byte* ptr = Buffer.Allocate(size);
		*(T*)ptr = value;
		Write(ptr, size);
	}

	public void WriteSingleValueUnmanaged(string value)
	{
		WriteSingleValueUnmanaged(value.Length);
		for (int i = 0; i < value.Length; i++)
		{
			WriteSingleValueUnmanaged(value[i]);
		}
	}

	public void WriteSingleValueUnmanagedArray<T>(T[] value) where T : unmanaged
	{
		WriteSingleValueUnmanaged(value.Length);
		for (int i = 0; i < value.Length; i++)
		{
			WriteSingleValueUnmanaged(value[i]);
		}
	}

	public void WriteSingleValueUnmanagedList<T>(IList<T> value) where T : unmanaged
	{
		WriteSingleValueUnmanaged(value.Count);
		for (int i = 0; i < value.Count; i++)
		{
			WriteSingleValueUnmanaged(value[i]);
		}
	}

	public unsafe void WriteSingleValueCustom<T>(T value) where T : ISerializableGameData
	{
		if (value == null)
		{
			WriteSingleValueUnmanaged(0);
			return;
		}
		int size = value.GetSerializedSize();
		WriteSingleValueUnmanaged(size);
		if (size != 0)
		{
			byte* ptr = Buffer.Allocate(size);
			int serializedSize = value.Serialize(ptr);
			if (size != serializedSize)
			{
				throw new SerializedSizeMismatchException(size, serializedSize);
			}
			Write(ptr, size);
		}
	}

	public unsafe void WriteFixedSingleValueCustom<T>(T value) where T : unmanaged, ISerializableGameData
	{
		int size = value.GetSerializedSize();
		byte* ptr = Buffer.Allocate(size);
		int serializedSize = value.Serialize(ptr);
		if (size != serializedSize)
		{
			throw new SerializedSizeMismatchException(size, serializedSize);
		}
		Write(ptr, size);
	}

	public void WriteSingleValueCustomArray<T>(T[] value) where T : ISerializableGameData
	{
		WriteSingleValueUnmanaged(value.Length);
		for (int i = 0; i < value.Length; i++)
		{
			WriteSingleValueCustom(value[i]);
		}
	}

	public void WriteSingleValueCustomList<T>(IList<T> value) where T : ISerializableGameData
	{
		int count = value.Count;
		WriteSingleValueUnmanaged(count);
		for (int i = 0; i < count; i++)
		{
			WriteSingleValueCustom(value[i]);
		}
	}

	public unsafe void ReadSingleValueUnmanaged<T>(ref T value) where T : unmanaged
	{
		int size = sizeof(T);
		byte* ptr = Buffer.Allocate(size);
		Read(ptr, size);
		value = *(T*)ptr;
	}

	public unsafe void ReadSingleValueUnmanaged(ref string value)
	{
		int length = 0;
		ReadSingleValueUnmanaged(ref length);
		char* charSpan = stackalloc char[length];
		for (int i = 0; i < length; i++)
		{
			ReadSingleValueUnmanaged(ref charSpan[i]);
		}
		value = new string(charSpan);
	}

	public unsafe void ReadFixedSingleValueCustom<T>(ref T value, bool skip = false) where T : unmanaged, ISerializableGameData
	{
		int size = value.GetSerializedSize();
		byte* ptr = Buffer.Allocate(size);
		Read(ptr, size);
		int serializedSize = value.Deserialize(ptr);
		if (size != serializedSize)
		{
			throw new SerializedSizeMismatchException(size, serializedSize);
		}
	}

	public void ReadSingleValueUnmanagedArray<T>(ref T[] value) where T : unmanaged
	{
		int length = 0;
		ReadSingleValueUnmanaged(ref length);
		if (value == null || value.Length != length)
		{
			value = new T[length];
		}
		for (int i = 0; i < length; i++)
		{
			ReadSingleValueUnmanaged(ref value[i]);
		}
	}

	public void ReadSingleValueUnmanagedList<T>(ref List<T> value) where T : unmanaged
	{
		int length = 0;
		ReadSingleValueUnmanaged(ref length);
		if (value == null && length > 0)
		{
			value = new List<T>();
		}
		value?.Clear();
		for (int i = 0; i < length; i++)
		{
			T element = default(T);
			ReadSingleValueUnmanaged(ref element);
			value.Add(element);
		}
	}

	public void ReadSingleValueUnmanagedList<T>(List<T> value) where T : unmanaged
	{
		value.Clear();
		int length = 0;
		ReadSingleValueUnmanaged(ref length);
		for (int i = 0; i < length; i++)
		{
			T element = default(T);
			ReadSingleValueUnmanaged(ref element);
			value.Add(element);
		}
	}

	public unsafe void ReadSingleValueCustom<T>(ref T value, bool skip = false) where T : ISerializableGameData, new()
	{
		int contentSize = 0;
		ReadSingleValueUnmanaged(ref contentSize);
		if (contentSize == 0)
		{
			value = default(T);
			return;
		}
		byte* ptr = Buffer.Allocate(contentSize);
		int readSize = Read(ptr, contentSize);
		if (contentSize != readSize)
		{
			throw new SerializedSizeMismatchException(contentSize, readSize);
		}
		if (!skip)
		{
			T val = value;
			if (val == null)
			{
				value = new T();
			}
			int actualSize = value.Deserialize(ptr);
			if (contentSize != actualSize)
			{
				throw new SerializedSizeMismatchException(contentSize, actualSize);
			}
		}
	}

	public void ReadSingleValueCustomArray<T>(ref T[] value, bool skip = false) where T : ISerializableGameData, new()
	{
		int length = 0;
		ReadSingleValueUnmanaged(ref length);
		if (value == null || value.Length != length)
		{
			value = new T[length];
		}
		for (int i = 0; i < value.Length; i++)
		{
			ReadSingleValueCustom(ref value[i], skip);
		}
	}

	public void ReadSingleValueCustomList<T>(ref List<T> value, bool skip = false) where T : ISerializableGameData, new()
	{
		int count = 0;
		ReadSingleValueUnmanaged(ref count);
		if (value == null && count > 0)
		{
			value = new List<T>();
		}
		value?.Clear();
		for (int i = 0; i < count; i++)
		{
			T element = default(T);
			ReadSingleValueCustom(ref element, skip);
			value.Add(element);
		}
	}

	public void WriteElementListUnmanaged<T>(T[] value) where T : unmanaged
	{
		WriteSingleValueUnmanagedArray(value);
	}

	public void WriteElementListCustom<T>(T[] value) where T : ISerializableGameData
	{
		WriteSingleValueCustomArray(value);
	}

	public void ReadElementListUnmanaged<T>(T[] value) where T : unmanaged
	{
		int length = 0;
		ReadSingleValueUnmanaged(ref length);
		if (length > value.Length)
		{
			for (int i = 0; i < value.Length; i++)
			{
				ReadSingleValueUnmanaged(ref value[i]);
			}
			for (int j = value.Length; j < length; j++)
			{
				T element = default(T);
				ReadSingleValueUnmanaged(ref element);
			}
		}
		else
		{
			for (int k = 0; k < length; k++)
			{
				ReadSingleValueUnmanaged(ref value[k]);
			}
		}
	}

	public void ReadElementListCustom<T>(T[] value, bool skip = false) where T : ISerializableGameData, new()
	{
		int length = 0;
		ReadSingleValueUnmanaged(ref length);
		if (length > value.Length)
		{
			for (int i = 0; i < value.Length; i++)
			{
				ReadSingleValueCustom(ref value[i], skip);
			}
			for (int j = value.Length; j < length; j++)
			{
				T element = new T();
				ReadSingleValueCustom(ref element, skip);
			}
		}
		else
		{
			for (int k = 0; k < length; k++)
			{
				ReadSingleValueCustom(ref value[k], skip);
			}
		}
	}

	public void WriteSingleValueCollectionUnmanagedKeyValue<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged where TValue : unmanaged
	{
		WriteSingleValueUnmanaged(collection.Count);
		foreach (KeyValuePair<TKey, TValue> item in collection)
		{
			WriteSingleValueUnmanaged(item.Key);
			WriteSingleValueUnmanaged(item.Value);
		}
	}

	public void WriteSingleValueCollectionUnmanagedKeyValue<TKey>(IDictionary<TKey, string> collection) where TKey : unmanaged
	{
		WriteSingleValueUnmanaged(collection.Count);
		foreach (KeyValuePair<TKey, string> item in collection)
		{
			WriteSingleValueUnmanaged(item.Key);
			WriteSingleValueUnmanaged(item.Value);
		}
	}

	public void WriteSingleValueCollectionUnmanagedKeyCustomValue<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged where TValue : ISerializableGameData
	{
		WriteSingleValueUnmanaged(collection.Count);
		foreach (KeyValuePair<TKey, TValue> item in collection)
		{
			WriteSingleValueUnmanaged(item.Key);
			WriteSingleValueCustom(item.Value);
		}
	}

	public void WriteSingleValueCollectionCustomKeyUnmanagedValue<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged, ISerializableGameData where TValue : unmanaged
	{
		WriteSingleValueUnmanaged(collection.Count);
		foreach (KeyValuePair<TKey, TValue> item in collection)
		{
			WriteFixedSingleValueCustom(item.Key);
			WriteSingleValueUnmanaged(item.Value);
		}
	}

	public void WriteSingleValueCollectionCustomKeyValue<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged, ISerializableGameData where TValue : ISerializableGameData
	{
		WriteSingleValueUnmanaged(collection.Count);
		foreach (KeyValuePair<TKey, TValue> item in collection)
		{
			WriteFixedSingleValueCustom(item.Key);
			WriteSingleValueCustom(item.Value);
		}
	}

	public void ReadSingleValueCollectionUnmanagedKeyValue<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged where TValue : unmanaged
	{
		collection.Clear();
		int count = 0;
		ReadSingleValueUnmanaged(ref count);
		for (int i = 0; i < count; i++)
		{
			TKey key = default(TKey);
			TValue value = default(TValue);
			ReadSingleValueUnmanaged(ref key);
			ReadSingleValueUnmanaged(ref value);
			collection.Add(key, value);
		}
	}

	public void ReadSingleValueCollectionUnmanagedKeyValue<TKey>(IDictionary<TKey, string> collection) where TKey : unmanaged
	{
		collection.Clear();
		int count = 0;
		ReadSingleValueUnmanaged(ref count);
		for (int i = 0; i < count; i++)
		{
			TKey key = default(TKey);
			string value = null;
			ReadSingleValueUnmanaged(ref key);
			ReadSingleValueUnmanaged(ref value);
			collection.Add(key, value);
		}
	}

	public void ReadSingleValueCollectionUnmanagedKeyCustomValue<TKey, TValue>(IDictionary<TKey, TValue> collection, bool skip = false) where TKey : unmanaged where TValue : ISerializableGameData, new()
	{
		collection.Clear();
		int count = 0;
		ReadSingleValueUnmanaged(ref count);
		if (skip)
		{
			for (int i = 0; i < count; i++)
			{
				TKey key = default(TKey);
				TValue value = default(TValue);
				ReadSingleValueUnmanaged(ref key);
				ReadSingleValueCustom(ref value, skip: true);
			}
			return;
		}
		for (int j = 0; j < count; j++)
		{
			TKey key2 = default(TKey);
			TValue value2 = default(TValue);
			ReadSingleValueUnmanaged(ref key2);
			ReadSingleValueCustom(ref value2);
			collection.Add(key2, value2);
		}
	}

	public void ReadSingleValueCollectionCustomKeyUnmanagedValue<TKey, TValue>(IDictionary<TKey, TValue> collection, bool skip = false) where TKey : unmanaged, ISerializableGameData where TValue : unmanaged
	{
		collection.Clear();
		int count = 0;
		ReadSingleValueUnmanaged(ref count);
		if (skip)
		{
			for (int i = 0; i < count; i++)
			{
				TKey key = default(TKey);
				TValue value = default(TValue);
				ReadFixedSingleValueCustom(ref key, skip: true);
				ReadSingleValueUnmanaged(ref value);
			}
			return;
		}
		for (int j = 0; j < count; j++)
		{
			TKey key2 = default(TKey);
			TValue value2 = default(TValue);
			ReadFixedSingleValueCustom(ref key2);
			ReadSingleValueUnmanaged(ref value2);
			collection.Add(key2, value2);
		}
	}

	public void ReadSingleValueCollectionCustomKeyValue<TKey, TValue>(IDictionary<TKey, TValue> collection, bool skip = false) where TKey : unmanaged, ISerializableGameData where TValue : ISerializableGameData, new()
	{
		collection.Clear();
		int count = 0;
		ReadSingleValueUnmanaged(ref count);
		if (skip)
		{
			for (int i = 0; i < count; i++)
			{
				TKey key = default(TKey);
				TValue value = default(TValue);
				ReadFixedSingleValueCustom(ref key, skip: true);
				ReadSingleValueCustom(ref value, skip: true);
			}
			return;
		}
		for (int j = 0; j < count; j++)
		{
			TKey key2 = default(TKey);
			TValue value2 = default(TValue);
			ReadFixedSingleValueCustom(ref key2);
			ReadSingleValueCustom(ref value2);
			collection.Add(key2, value2);
		}
	}

	public void WriteObjectCollectionUnmanagedKey<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged where TValue : ArchiveFieldGroup, ISerializableGameData
	{
		ushort[] fieldIds = ArchiveFieldGroup.GetFieldIds<TValue>();
		int[] fixedFieldSizes = ArchiveFieldGroup.GetFixedArchiveFieldSizes<TValue>();
		WriteSingleValueUnmanagedArray(fieldIds);
		WriteSingleValueUnmanagedArray(fixedFieldSizes);
		WriteSingleValueUnmanaged(collection.Count);
		foreach (KeyValuePair<TKey, TValue> item in collection)
		{
			WriteSingleValueUnmanaged(item.Key);
			WriteCollectionObject(item.Value);
		}
	}

	public void WriteObjectCollectionCustomKey<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged, ISerializableGameData where TValue : ArchiveFieldGroup, ISerializableGameData
	{
		ushort[] fieldIds = ArchiveFieldGroup.GetFieldIds<TValue>();
		int[] fixedFieldSizes = ArchiveFieldGroup.GetFixedArchiveFieldSizes<TValue>();
		WriteSingleValueUnmanagedArray(fieldIds);
		WriteSingleValueUnmanagedArray(fixedFieldSizes);
		WriteSingleValueUnmanaged(collection.Count);
		foreach (KeyValuePair<TKey, TValue> item in collection)
		{
			WriteFixedSingleValueCustom(item.Key);
			WriteCollectionObject(item.Value);
		}
	}

	private unsafe void WriteCollectionObject<T>(T value) where T : ArchiveFieldGroup, ISerializableGameData
	{
		if (value == null)
		{
			WriteSingleValueUnmanaged(0);
			return;
		}
		int size = value.GetSerializedSizeWithoutHeader();
		WriteSingleValueUnmanaged(size);
		if (size != 0)
		{
			byte* ptr = Buffer.Allocate(size);
			int serializedSize = value.SerializeWithoutHeader(ptr);
			if (size != serializedSize)
			{
				throw new SerializedSizeMismatchException(size, serializedSize);
			}
			Write(ptr, size);
		}
	}

	public void ReadObjectCollectionUnmanagedKey<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged where TValue : ArchiveFieldGroup, ISerializableGameData, new()
	{
		ushort[] fieldIds = null;
		ReadSingleValueUnmanagedArray(ref fieldIds);
		int[] fixedFieldSizes = null;
		ReadSingleValueUnmanagedArray(ref fixedFieldSizes);
		collection.Clear();
		int count = 0;
		ReadSingleValueUnmanaged(ref count);
		for (int i = 0; i < count; i++)
		{
			TKey key = default(TKey);
			TValue value = null;
			ReadSingleValueUnmanaged(ref key);
			ReadCollectionObject(ref value, fieldIds, fixedFieldSizes);
			collection.Add(key, value);
		}
	}

	public void ReadObjectCollectionCustomKey<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged, ISerializableGameData where TValue : ArchiveFieldGroup, ISerializableGameData, new()
	{
		ushort[] fieldIds = null;
		ReadSingleValueUnmanagedArray(ref fieldIds);
		int[] fixedFieldSizes = null;
		ReadSingleValueUnmanagedArray(ref fixedFieldSizes);
		collection.Clear();
		int count = 0;
		ReadSingleValueUnmanaged(ref count);
		for (int i = 0; i < count; i++)
		{
			TKey key = default(TKey);
			TValue value = null;
			ReadFixedSingleValueCustom(ref key);
			ReadCollectionObject(ref value, fieldIds, fixedFieldSizes);
			collection.Add(key, value);
		}
	}

	private unsafe void ReadCollectionObject<T>(ref T collectionObj, ushort[] fieldIds, int[] fieldSizes) where T : ArchiveFieldGroup, ISerializableGameData, new()
	{
		int contentSize = 0;
		ReadSingleValueUnmanaged(ref contentSize);
		if (contentSize == 0)
		{
			collectionObj = null;
			return;
		}
		byte* ptr = Buffer.Allocate(contentSize);
		int readSize = Read(ptr, contentSize);
		if (contentSize != readSize)
		{
			throw new SerializedSizeMismatchException(contentSize, readSize);
		}
		if (collectionObj == null)
		{
			collectionObj = new T();
		}
		int actualSize = collectionObj.DeserializeWithFieldIds(ptr, fieldIds, fieldSizes);
		if (contentSize == actualSize)
		{
			return;
		}
		throw new SerializedSizeMismatchException(contentSize, actualSize);
	}

	public unsafe void WriteBinary<T>(T value) where T : IBinary
	{
		ushort metaSize = value.GetSerializedFixedSizeOfMetadata();
		byte* ptr = Buffer.Allocate(metaSize);
		int serializedSize = value.SerializeMetadata(ptr);
		if (metaSize != serializedSize)
		{
			throw new SerializedSizeMismatchException(metaSize, serializedSize);
		}
		Write(ptr, serializedSize);
		int dataSize = value.GetSize();
		if (dataSize > 0)
		{
			Write(value.GetRawData(), 0, dataSize);
		}
	}

	public void ReadBinary<T>(ref T value) where T : IBinary, new()
	{
		T val = value;
		if (val == null)
		{
			value = new T();
		}
		ReadBinary(value);
	}

	public unsafe void ReadBinary<T>(T value) where T : IBinary
	{
		ushort metaSize = value.GetSerializedFixedSizeOfMetadata();
		byte* ptr = Buffer.Allocate(metaSize);
		Read(ptr, metaSize);
		int deserializedSize = value.DeserializeMetadata(ptr);
		if (metaSize != deserializedSize)
		{
			throw new SerializedSizeMismatchException(metaSize, deserializedSize);
		}
		int dataSize = value.GetSize();
		if (dataSize > 0)
		{
			Read(value.GetRawData(), 0, dataSize);
		}
	}

	public unsafe void CopyTo(Stream stream, long length)
	{
		int actualSize;
		for (int readSize = 0; readSize < length; readSize += actualSize)
		{
			int currBufferSize = (int)Math.Min(length - readSize, 4096L);
			byte* pointer = Buffer.Allocate(currBufferSize);
			actualSize = Read(pointer, currBufferSize);
			Span<byte> span = new Span<byte>(pointer, actualSize);
			stream.Write(span);
		}
	}

	public unsafe void CopyFrom(Stream stream, long length)
	{
		int actualSize;
		for (int writeSize = 0; writeSize < length; writeSize += actualSize)
		{
			int currBufferSize = (int)Math.Min(length - writeSize, 4096L);
			byte* pointer = Buffer.Allocate(currBufferSize);
			Span<byte> span = new Span<byte>(pointer, currBufferSize);
			actualSize = stream.Read(span);
			Write(pointer, actualSize);
		}
	}

	protected void WriteCrcToEnd(uint crc32)
	{
		long prevPosition = InternalStream.Position;
		long position = Math.Max(InternalStream.Length - 4, prevPosition);
		if (position != prevPosition)
		{
			InternalStream.Position = position;
		}
		Write(crc32);
	}

	protected uint ReadCrcFromEnd()
	{
		InternalStream.Position = InternalStream.Length - 4;
		return Read<uint>();
	}

	protected void Write(byte[] buffer, int offset, int size)
	{
		Crc32.Append(new ReadOnlySpan<byte>(buffer, offset, size));
		InternalStream.Write(buffer, offset, size);
	}

	protected unsafe void Write(byte* ptr, int size)
	{
		ReadOnlySpan<byte> span = new ReadOnlySpan<byte>(ptr, size);
		Crc32.Append(span);
		InternalStream.Write(span);
	}

	protected unsafe void Write<T>(T value) where T : unmanaged
	{
		byte* ptr = stackalloc byte[(int)(uint)sizeof(T)];
		*(T*)ptr = value;
		Write(ptr, sizeof(T));
	}

	protected unsafe int Read(byte[] buffer, int offset, int size)
	{
		fixed (byte* ptr = buffer)
		{
			return Read(ptr + offset, size);
		}
	}

	protected unsafe int Read(byte* ptr, int size)
	{
		Span<byte> span = new Span<byte>(ptr, size);
		return Read(span);
	}

	private int Read(Span<byte> span)
	{
		int size = span.Length;
		int readSize = InternalStream.Read(span);
		int totalReadSize = readSize;
		while (readSize != 0 && totalReadSize < size)
		{
			readSize = InternalStream.Read(span.Slice(totalReadSize));
			totalReadSize += readSize;
		}
		Crc32.Append(span);
		return totalReadSize;
	}

	protected unsafe T Read<T>() where T : unmanaged
	{
		byte* ptr = stackalloc byte[(int)(uint)sizeof(T)];
		Tester.Assert(Read(ptr, sizeof(T)) == sizeof(T));
		return *(T*)ptr;
	}
}
