using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[SerializableGameData(IsExtensible = true)]
public class AristocratSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort InfluencePowerBonus = 0;

		public const ushort RecommendedCharIds = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "InfluencePowerBonus", "RecommendedCharIds" };
	}

	[SerializableGameDataField]
	private Dictionary<int, short> _influencePowerBonus;

	[SerializableGameDataField]
	private List<int> _recommendedCharIds;

	public void Initialize()
	{
		_influencePowerBonus?.Clear();
		_recommendedCharIds?.Clear();
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		if (!(sourceData is ObsoleteAristocratSkillsData skillsData))
		{
			return;
		}
		foreach (KeyValuePair<int, short> pair in skillsData._influencePowerBonus)
		{
			_influencePowerBonus.Add(pair.Key, pair.Value);
		}
	}

	public short OfflineSetInfluencePowerBonus(int targetCharId, short bonus)
	{
		if (!_influencePowerBonus.TryGetValue(targetCharId, out var previousBonus))
		{
			previousBonus = 0;
		}
		_influencePowerBonus[targetCharId] = bonus;
		return previousBonus;
	}

	public bool OfflineRemoveInfluencePowerBonus(int targetCharId)
	{
		return _influencePowerBonus.Remove(targetCharId);
	}

	public short GetPreviousInfluencePowerBonus(int targetCharId)
	{
		if (!_influencePowerBonus.TryGetValue(targetCharId, out var previousBonus))
		{
			return 0;
		}
		return previousBonus;
	}

	public void OfflineAddRecommendedCharId(int charId)
	{
		_recommendedCharIds.Add(charId);
	}

	public void OfflineRemoveRecommendedCharId(int charId)
	{
		_recommendedCharIds.Remove(charId);
	}

	public int GetRecommendedCharIdInList(List<int> charIds)
	{
		foreach (int charId in charIds)
		{
			if (_recommendedCharIds.Contains(charId))
			{
				return charId;
			}
		}
		return -1;
	}

	public bool IsCharacterRecommended(int charId)
	{
		return _influencePowerBonus.ContainsKey(charId);
	}

	public AristocratSkillsData()
	{
		_influencePowerBonus = new Dictionary<int, short>();
		_recommendedCharIds = new List<int>();
	}

	public AristocratSkillsData(AristocratSkillsData other)
	{
		_influencePowerBonus = ((other._influencePowerBonus == null) ? null : new Dictionary<int, short>(other._influencePowerBonus));
		_recommendedCharIds = ((other._recommendedCharIds == null) ? null : new List<int>(other._recommendedCharIds));
	}

	public void Assign(AristocratSkillsData other)
	{
		_influencePowerBonus = ((other._influencePowerBonus == null) ? null : new Dictionary<int, short>(other._influencePowerBonus));
		_recommendedCharIds = ((other._recommendedCharIds == null) ? null : new List<int>(other._recommendedCharIds));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(_influencePowerBonus);
		totalSize = ((_recommendedCharIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _recommendedCharIds.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref _influencePowerBonus);
		if (_recommendedCharIds != null)
		{
			int elementsCount = _recommendedCharIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _recommendedCharIds[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref _influencePowerBonus);
		}
		if (num > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (_recommendedCharIds == null)
				{
					_recommendedCharIds = new List<int>(elementsCount);
				}
				else
				{
					_recommendedCharIds.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					_recommendedCharIds.Add(((int*)pCurrData)[i]);
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				_recommendedCharIds?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
