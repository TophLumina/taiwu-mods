using System;
using GameData.Serializer;

namespace GameData.Utilities;

public interface IVariantCollection<in TKey> where TKey : IEquatable<TKey>
{
	bool Get(TKey key, ref int value);

	bool Get(TKey key, ref float value);

	bool Get(TKey key, ref bool value);

	bool Get(TKey key, ref string value);

	bool Get<T>(TKey key, out T value) where T : ISerializableGameData;

	void Set(TKey key, int value);

	void Set(TKey key, float value);

	void Set(TKey key, bool value);

	void Set(TKey key, string value);

	void Set(TKey key, ISerializableGameData value);
}
