using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 生铸数据集合
/// </summary>
/// <summary>
/// 生铸数据集合 - 后端专用数据方法
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class RawCreateCollection : ISerializableGameData
{
	/// <summary>
	/// 各个物品对应的特效 ID
	/// 此处为 SpecialEffect.TemplateId
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<ItemKey, int> Effects = new Dictionary<ItemKey, int>();

	/// <summary>
	/// 原始物品映射，用于在生铸物品损坏后恢复至原始物品
	/// 生铸物品键 -&gt; 原始物品键
	/// </summary>
	public readonly Dictionary<ItemKey, ItemKey> Sources = new Dictionary<ItemKey, ItemKey>();

	/// <summary>
	/// 战斗特效映射，用于在生铸物品损坏后移除
	/// </summary>
	public readonly Dictionary<ItemKey, long> SpecialEffects = new Dictionary<ItemKey, long>();

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public RawCreateCollection()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public RawCreateCollection(RawCreateCollection other)
	{
		Effects = ((other.Effects == null) ? null : new Dictionary<ItemKey, int>(other.Effects));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(RawCreateCollection other)
	{
		Effects = ((other.Effects == null) ? null : new Dictionary<ItemKey, int>(other.Effects));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pData, ref Effects) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pData, ref Effects) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <summary>
	/// 尝试获取指定物品的生铸特效 ID
	/// </summary>
	public int TryGetEffectId(ItemKey key)
	{
		if (!Effects.TryGetValue(key, out var effectId))
		{
			return -1;
		}
		return effectId;
	}

	/// <summary>
	/// 指定物品对应的生铸特效是否相同
	/// </summary>
	public bool EffectEquals(ItemKey lhs, ItemKey rhs)
	{
		return TryGetEffectId(lhs) == TryGetEffectId(rhs);
	}

	/// <summary>
	/// 是否有任意生铸过的物品
	/// </summary>
	public bool Any()
	{
		if (Effects.Count <= 0)
		{
			return Sources.Count > 0;
		}
		return true;
	}

	/// <summary>
	/// 某物品是否进行过生铸
	/// </summary>
	public bool Contains(ItemKey newKey)
	{
		return Effects.ContainsKey(newKey);
	}

	/// <summary>
	/// 添加某个生铸效果
	/// </summary>
	public void Add(ItemKey newKey, ItemKey oldKey, int effectId, long specialEffectId)
	{
		Effects.Add(newKey, effectId);
		Sources.Add(newKey, oldKey);
		SpecialEffects.Add(newKey, specialEffectId);
	}

	/// <summary>
	/// 移除某个生铸效果
	/// </summary>
	public void Remove(ItemKey newKey, out ItemKey oldKey)
	{
		oldKey = Sources[newKey];
		Effects.Remove(newKey);
		Sources.Remove(newKey);
		SpecialEffects.Remove(newKey);
	}

	/// <summary>
	/// 清空所有生铸效果
	/// </summary>
	public void Clear()
	{
		Effects.Clear();
		Sources.Clear();
		SpecialEffects.Clear();
	}
}
