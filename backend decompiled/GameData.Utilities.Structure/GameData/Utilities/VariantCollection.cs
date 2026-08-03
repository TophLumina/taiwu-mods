using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

public abstract class VariantCollection<TKey> : ISerializableGameData, IVariantCollection<TKey> where TKey : IEquatable<TKey>, ISerializableGameData, new()
{
	private struct VariantWrapper : ISerializableGameData
	{
		public SimpleVariant Simple;

		public IVariant Complex;

		public bool UpdateComplexValue<T>(T value)
		{
			if (Complex is Variant<T> variant)
			{
				variant.Value = value;
				return true;
			}
			return false;
		}

		public VariantWrapper(int value)
		{
			Simple = (SimpleVariant)value;
			Complex = null;
		}

		public VariantWrapper(float value)
		{
			Simple = (SimpleVariant)value;
			Complex = null;
		}

		public VariantWrapper(bool value)
		{
			Simple = (SimpleVariant)value;
			Complex = null;
		}

		public VariantWrapper(string value)
		{
			Simple = (SimpleVariant)ComplexVariantTypeId.String;
			Complex = new StringValue(value);
		}

		public static VariantWrapper Create<T>(T obj) where T : ISerializableGameData
		{
			ComplexVariantTypeId typeId = ComplexVariantTypeId.VariantFactory.CreateTypeId(obj?.GetType() ?? typeof(T));
			IVariant variant = ComplexVariantTypeId.VariantFactory.CreateVariant(typeId.SubType, typeId.Id, obj);
			return new VariantWrapper
			{
				Simple = (SimpleVariant)typeId,
				Complex = variant
			};
		}

		public VariantWrapper Duplicate()
		{
			VariantWrapper wrapper = new VariantWrapper
			{
				Simple = Simple
			};
			if (Complex != null)
			{
				wrapper.Complex = Complex.Duplicate();
			}
			return wrapper;
		}

		public bool IsSerializedSizeFixed()
		{
			return false;
		}

		public int GetSerializedSize()
		{
			int totalSize = Simple.GetSerializedSize();
			if (Simple.Type == SimpleVariant.EType.Complex)
			{
				totalSize += Complex.GetSerializedSize();
			}
			if (totalSize > 4)
			{
				return (totalSize + 3) / 4 * 4;
			}
			return totalSize;
		}

		public unsafe int Serialize(byte* pData)
		{
			byte* pCurrData = pData;
			pCurrData += Simple.Serialize(pCurrData);
			if (Simple.Type == SimpleVariant.EType.Complex)
			{
				pCurrData += Complex.Serialize(pCurrData);
			}
			int totalSize = (int)(pCurrData - pData);
			if (totalSize > 4)
			{
				return (totalSize + 3) / 4 * 4;
			}
			return totalSize;
		}

		public unsafe int Deserialize(byte* pData)
		{
			byte* pCurrData = pData;
			pCurrData += Simple.Deserialize(pCurrData);
			if (Simple.Type == SimpleVariant.EType.Complex)
			{
				Complex = ((ComplexVariantTypeId)Simple).CreateVariantObject();
				pCurrData += Complex.Deserialize(pCurrData);
			}
			int totalSize = (int)(pCurrData - pData);
			if (totalSize > 4)
			{
				return (totalSize + 3) / 4 * 4;
			}
			return totalSize;
		}
	}

	[SerializableGameDataField]
	private Dictionary<TKey, VariantWrapper> _variants = new Dictionary<TKey, VariantWrapper>();

	public int Count => _variants.Count;

	public bool ContainsKey(TKey key)
	{
		return _variants.ContainsKey(key);
	}

	public void CopyTo(VariantCollection<TKey> other)
	{
		foreach (var (key, wrapper) in _variants)
		{
			other._variants[key] = wrapper.Duplicate();
		}
	}

	public bool Get(TKey key, ref int value)
	{
		return TryGet(key, out value);
	}

	public bool Get(TKey key, ref float value)
	{
		return TryGet(key, out value);
	}

	public bool Get(TKey key, ref bool value)
	{
		return TryGet(key, out value);
	}

	public bool Get(TKey key, ref string value)
	{
		return TryGet(key, out value);
	}

	public bool Get<T>(TKey key, out T value) where T : ISerializableGameData
	{
		return TryGet(key, out value);
	}

	public bool TryGet(TKey key, out int value)
	{
		value = 0;
		if (!_variants.TryGetValue(key, out var variant) || variant.Simple.Type != SimpleVariant.EType.Int)
		{
			return false;
		}
		value = (int)variant.Simple;
		return true;
	}

	public bool TryGet(TKey key, out float value)
	{
		value = 0f;
		if (!_variants.TryGetValue(key, out var variant) || variant.Simple.Type != SimpleVariant.EType.Float)
		{
			return false;
		}
		value = (float)variant.Simple;
		return true;
	}

	public bool TryGet(TKey key, out bool value)
	{
		value = false;
		if (!_variants.TryGetValue(key, out var variant) || variant.Simple.Type != SimpleVariant.EType.Bool)
		{
			return false;
		}
		value = (bool)variant.Simple;
		return true;
	}

	public bool TryGet(TKey key, out string value)
	{
		return TryGetComplex<string>(key, out value);
	}

	public bool TryGet(TKey key, out ISerializableGameData value)
	{
		return TryGetComplex<ISerializableGameData>(key, out value);
	}

	public bool TryGet<T>(TKey key, out T value) where T : ISerializableGameData
	{
		return TryGetComplex<T>(key, out value);
	}

	private bool TryGetComplex<T>(TKey key, out T value)
	{
		if (_variants.TryGetValue(key, out var variant) && variant.Complex is Variant<T> typedVariant)
		{
			value = typedVariant.Value;
			return true;
		}
		value = default(T);
		return false;
	}

	public void Set(TKey key, int value)
	{
		_variants[key] = new VariantWrapper(value);
	}

	public void Set(TKey key, float value)
	{
		_variants[key] = new VariantWrapper(value);
	}

	public void Set(TKey key, bool value)
	{
		_variants[key] = new VariantWrapper(value);
	}

	public void Set(TKey key, string value)
	{
		_variants[key] = new VariantWrapper(value);
	}

	public void Set<T>(TKey key, T value) where T : ISerializableGameData
	{
		if (!UpdateValue(key, value))
		{
			_variants[key] = VariantWrapper.Create(value);
		}
	}

	public void Set(TKey key, ISerializableGameData value)
	{
		this.Set<ISerializableGameData>(key, value);
	}

	private bool UpdateValue<T>(TKey key, T value)
	{
		if (!_variants.TryGetValue(key, out var wrapper))
		{
			return false;
		}
		return wrapper.UpdateComplexValue(value);
	}

	public bool Remove(TKey key)
	{
		return _variants.Remove(key);
	}

	public void Clear()
	{
		_variants.Clear();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return SerializationHelper.DictionaryOfCustomTypePair.GetSerializedSize(_variants);
	}

	public unsafe int Serialize(byte* pData)
	{
		return SerializationHelper.DictionaryOfCustomTypePair.Serialize(pData, ref _variants);
	}

	public unsafe int Deserialize(byte* pData)
	{
		return SerializationHelper.DictionaryOfCustomTypePair.Deserialize(pData, ref _variants);
	}
}
