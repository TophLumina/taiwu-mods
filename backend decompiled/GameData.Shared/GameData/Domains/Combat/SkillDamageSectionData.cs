using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public class SkillDamageSectionData : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<DefeatMarkKey, int> Values = new Dictionary<DefeatMarkKey, int>();

	[SerializableGameDataField]
	public ESkillDamageSectionResult Result;

	public bool Hit => Result == ESkillDamageSectionResult.Hit;

	public bool Critical => Result == ESkillDamageSectionResult.Critical;

	public SkillDamageSectionData()
	{
	}

	public SkillDamageSectionData(SkillDamageSectionData other)
	{
		Values = ((other.Values == null) ? null : new Dictionary<DefeatMarkKey, int>(other.Values));
		Result = other.Result;
	}

	public void Assign(SkillDamageSectionData other)
	{
		Values = ((other.Values == null) ? null : new Dictionary<DefeatMarkKey, int>(other.Values));
		Result = other.Result;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 1;
		totalSize += SerializationHelper.DictionaryAsBasicTypePair.GetSerializedSize<DefeatMarkKey, int, int, int, Dictionary<DefeatMarkKey, int>>(Values);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* num = pData + SerializationHelper.DictionaryAsBasicTypePair.Serialize(pData, ref Values, (Func<DefeatMarkKey, int>)((DefeatMarkKey key) => key), (Func<int, int>)((int value) => value));
		*num = (byte)Result;
		int totalSize = (int)(num + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += SerializationHelper.DictionaryAsBasicTypePair.Deserialize(pCurrData, ref Values, (int key) => (DefeatMarkKey)key, (int value) => value);
		Result = (ESkillDamageSectionResult)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
