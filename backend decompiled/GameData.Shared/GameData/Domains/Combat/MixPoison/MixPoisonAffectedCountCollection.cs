using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat.MixPoison;

[SerializableGameData]
public class MixPoisonAffectedCountCollection : ISerializableGameData
{
	[SerializableGameDataField]
	private Dictionary<sbyte, int> _mixPoisonAffectedCount;

	private Dictionary<sbyte, int> GetOrCreateCount()
	{
		return _mixPoisonAffectedCount ?? (_mixPoisonAffectedCount = new Dictionary<sbyte, int>());
	}

	public int GetAffectedCount(sbyte templateId)
	{
		return GetOrCreateCount().GetOrDefault(templateId);
	}

	public int SetAffectedCount(sbyte templateId, int count)
	{
		return GetOrCreateCount()[templateId] = count;
	}

	public MixPoisonAffectedCountCollection AddAffectedCount(sbyte templateId)
	{
		GetOrCreateCount()[templateId] = GetAffectedCount(templateId) + 1;
		return this;
	}

	public MixPoisonAffectedCountCollection Clear()
	{
		GetOrCreateCount().Clear();
		return this;
	}

	public MixPoisonAffectedCountCollection()
	{
	}

	public MixPoisonAffectedCountCollection(MixPoisonAffectedCountCollection other)
	{
		_mixPoisonAffectedCount = ((other._mixPoisonAffectedCount == null) ? null : new Dictionary<sbyte, int>(other._mixPoisonAffectedCount));
	}

	public void Assign(MixPoisonAffectedCountCollection other)
	{
		_mixPoisonAffectedCount = ((other._mixPoisonAffectedCount == null) ? null : new Dictionary<sbyte, int>(other._mixPoisonAffectedCount));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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

	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfBasicTypePair.Serialize(pData, ref _mixPoisonAffectedCount) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
