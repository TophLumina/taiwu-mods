using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.ArchiveData;

public interface IGameDataTypeFormatter
{
	void WriteSingleValueUnmanaged<T>(T value) where T : unmanaged;

	void WriteSingleValueUnmanaged(string value);

	void WriteSingleValueUnmanagedArray<T>(T[] value) where T : unmanaged;

	void WriteSingleValueUnmanagedList<T>(IList<T> value) where T : unmanaged;

	void WriteSingleValueCustom<T>(T value) where T : ISerializableGameData;

	void WriteFixedSingleValueCustom<T>(T value) where T : unmanaged, ISerializableGameData;

	void WriteSingleValueCustomArray<T>(T[] value) where T : ISerializableGameData;

	void WriteSingleValueCustomList<T>(IList<T> value) where T : ISerializableGameData;

	void ReadSingleValueUnmanaged<T>(ref T value) where T : unmanaged;

	void ReadSingleValueUnmanaged(ref string value);

	void ReadSingleValueUnmanagedArray<T>(ref T[] value) where T : unmanaged;

	void ReadSingleValueUnmanagedList<T>(ref List<T> value) where T : unmanaged;

	void ReadSingleValueUnmanagedList<T>(List<T> value) where T : unmanaged;

	void ReadSingleValueCustom<T>(ref T value, bool skip = false) where T : ISerializableGameData, new();

	void ReadFixedSingleValueCustom<T>(ref T value, bool skip = false) where T : unmanaged, ISerializableGameData;

	void ReadSingleValueCustomArray<T>(ref T[] value, bool skip = false) where T : ISerializableGameData, new();

	void ReadSingleValueCustomList<T>(ref List<T> value, bool skip = false) where T : ISerializableGameData, new();

	void WriteElementListUnmanaged<T>(T[] value) where T : unmanaged;

	void WriteElementListCustom<T>(T[] value) where T : ISerializableGameData;

	void ReadElementListUnmanaged<T>(T[] value) where T : unmanaged;

	void ReadElementListCustom<T>(T[] value, bool skip = false) where T : ISerializableGameData, new();

	void WriteSingleValueCollectionUnmanagedKeyValue<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged where TValue : unmanaged;

	void WriteSingleValueCollectionUnmanagedKeyValue<TKey>(IDictionary<TKey, string> collection) where TKey : unmanaged;

	void WriteSingleValueCollectionUnmanagedKeyCustomValue<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged where TValue : ISerializableGameData;

	void WriteSingleValueCollectionCustomKeyUnmanagedValue<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged, ISerializableGameData where TValue : unmanaged;

	void WriteSingleValueCollectionCustomKeyValue<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged, ISerializableGameData where TValue : ISerializableGameData;

	void ReadSingleValueCollectionUnmanagedKeyValue<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged where TValue : unmanaged;

	void ReadSingleValueCollectionUnmanagedKeyValue<TKey>(IDictionary<TKey, string> collection) where TKey : unmanaged;

	void ReadSingleValueCollectionUnmanagedKeyCustomValue<TKey, TValue>(IDictionary<TKey, TValue> collection, bool skip = false) where TKey : unmanaged where TValue : ISerializableGameData, new();

	void ReadSingleValueCollectionCustomKeyUnmanagedValue<TKey, TValue>(IDictionary<TKey, TValue> collection, bool skip = false) where TKey : unmanaged, ISerializableGameData where TValue : unmanaged;

	void ReadSingleValueCollectionCustomKeyValue<TKey, TValue>(IDictionary<TKey, TValue> collection, bool skip = false) where TKey : unmanaged, ISerializableGameData where TValue : ISerializableGameData, new();

	void WriteObjectCollectionUnmanagedKey<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged where TValue : ArchiveFieldGroup, ISerializableGameData;

	void WriteObjectCollectionCustomKey<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged, ISerializableGameData where TValue : ArchiveFieldGroup, ISerializableGameData;

	void ReadObjectCollectionUnmanagedKey<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged where TValue : ArchiveFieldGroup, ISerializableGameData, new();

	void ReadObjectCollectionCustomKey<TKey, TValue>(IDictionary<TKey, TValue> collection) where TKey : unmanaged, ISerializableGameData where TValue : ArchiveFieldGroup, ISerializableGameData, new();

	void WriteBinary<T>(T value) where T : IBinary;

	void ReadBinary<T>(ref T value) where T : IBinary, new();

	void ReadBinary<T>(T value) where T : IBinary;
}
