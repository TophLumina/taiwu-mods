using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat.MixPoison;

/// <summary>
/// 混毒发作次数集合
/// </summary>
[SerializableGameData]
public class MixPoisonAffectedCountCollection : ISerializableGameData
{
	/// <summary>
	/// 混合毒发生效次数
	/// 顺序与<see cref="T:Config.MixPoisonEffect" />一致
	/// </summary>
	[SerializableGameDataField]
	private Dictionary<sbyte, int> _mixPoisonAffectedCount;

	private Dictionary<sbyte, int> GetOrCreateCount()
	{
		return _mixPoisonAffectedCount ?? (_mixPoisonAffectedCount = new Dictionary<sbyte, int>());
	}

	/// <summary>
	/// 获取生效次数
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public int GetAffectedCount(sbyte templateId)
	{
		return GetOrCreateCount().GetOrDefault(templateId);
	}

	/// <summary>
	/// 设置生效次数
	/// </summary>
	public int SetAffectedCount(sbyte templateId, int count)
	{
		return GetOrCreateCount()[templateId] = count;
	}

	/// <summary>
	/// 离线增加某混毒生效次数，需要手动调用
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public MixPoisonAffectedCountCollection AddAffectedCount(sbyte templateId)
	{
		GetOrCreateCount()[templateId] = GetAffectedCount(templateId) + 1;
		return this;
	}

	/// <summary>
	/// 离线清空所有生效次数，需要手动调用
	/// </summary>
	/// <returns></returns>
	public MixPoisonAffectedCountCollection Clear()
	{
		GetOrCreateCount().Clear();
		return this;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public MixPoisonAffectedCountCollection()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public MixPoisonAffectedCountCollection(MixPoisonAffectedCountCollection other)
	{
		_mixPoisonAffectedCount = ((other._mixPoisonAffectedCount == null) ? null : new Dictionary<sbyte, int>(other._mixPoisonAffectedCount));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(MixPoisonAffectedCountCollection other)
	{
		_mixPoisonAffectedCount = ((other._mixPoisonAffectedCount == null) ? null : new Dictionary<sbyte, int>(other._mixPoisonAffectedCount));
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
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(_mixPoisonAffectedCount);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfBasicTypePair.Serialize(pData, ref _mixPoisonAffectedCount) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pData, ref _mixPoisonAffectedCount) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
