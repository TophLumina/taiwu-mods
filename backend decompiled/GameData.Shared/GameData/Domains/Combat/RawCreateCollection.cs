using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public class RawCreateCollection : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<ItemKey, int> Effects = new Dictionary<ItemKey, int>();

	public readonly Dictionary<ItemKey, ItemKey> Sources = new Dictionary<ItemKey, ItemKey>();

	public readonly Dictionary<ItemKey, long> SpecialEffects = new Dictionary<ItemKey, long>();

	public RawCreateCollection()
	{
	}

	public RawCreateCollection(RawCreateCollection other)
	{
		Effects = ((other.Effects == null) ? null : new Dictionary<ItemKey, int>(other.Effects));
	}

	public void Assign(RawCreateCollection other)
	{
		Effects = ((other.Effects == null) ? null : new Dictionary<ItemKey, int>(other.Effects));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(Effects);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pData, ref Effects) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pData, ref Effects) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public int TryGetEffectId(ItemKey key)
	{
		if (!Effects.TryGetValue(key, out var effectId))
		{
			return -1;
		}
		return effectId;
	}

	public bool EffectEquals(ItemKey lhs, ItemKey rhs)
	{
		return TryGetEffectId(lhs) == TryGetEffectId(rhs);
	}

	public bool Any()
	{
		if (Effects.Count <= 0)
		{
			return Sources.Count > 0;
		}
		return true;
	}

	public bool Contains(ItemKey newKey)
	{
		return Effects.ContainsKey(newKey);
	}

	public void Add(ItemKey newKey, ItemKey oldKey, int effectId, long specialEffectId)
	{
		Effects.Add(newKey, effectId);
		Sources.Add(newKey, oldKey);
		SpecialEffects.Add(newKey, specialEffectId);
	}

	public void Remove(ItemKey newKey, out ItemKey oldKey)
	{
		oldKey = Sources[newKey];
		Effects.Remove(newKey);
		Sources.Remove(newKey);
		SpecialEffects.Remove(newKey);
	}

	public void Clear()
	{
		Effects.Clear();
		Sources.Clear();
		SpecialEffects.Clear();
	}
}
