using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public class SilenceData : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<short, CountdownData> CombatSkill = new Dictionary<short, CountdownData>();

	[SerializableGameDataField]
	public List<ItemKey> WeaponKeys = new List<ItemKey>();

	[SerializableGameDataField]
	public List<CountdownData> WeaponFrames = new List<CountdownData>();

	public SilenceData()
	{
	}

	public SilenceData(SilenceData other)
	{
		CombatSkill = ((other.CombatSkill == null) ? null : new Dictionary<short, CountdownData>(other.CombatSkill));
		WeaponKeys = ((other.WeaponKeys == null) ? null : new List<ItemKey>(other.WeaponKeys));
		WeaponFrames = ((other.WeaponFrames == null) ? null : new List<CountdownData>(other.WeaponFrames));
	}

	public void Assign(SilenceData other)
	{
		CombatSkill = ((other.CombatSkill == null) ? null : new Dictionary<short, CountdownData>(other.CombatSkill));
		WeaponKeys = ((other.WeaponKeys == null) ? null : new List<ItemKey>(other.WeaponKeys));
		WeaponFrames = ((other.WeaponFrames == null) ? null : new List<CountdownData>(other.WeaponFrames));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CombatSkill);
		totalSize = ((WeaponKeys == null) ? (totalSize + 2) : (totalSize + (2 + 8 * WeaponKeys.Count)));
		totalSize = ((WeaponFrames == null) ? (totalSize + 2) : (totalSize + (2 + 8 * WeaponFrames.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CombatSkill);
		if (WeaponKeys != null)
		{
			int elementsCount = WeaponKeys.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += WeaponKeys[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (WeaponFrames != null)
		{
			int elementsCount2 = WeaponFrames.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += WeaponFrames[j].Serialize(pCurrData);
			}
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
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CombatSkill);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (WeaponKeys == null)
			{
				WeaponKeys = new List<ItemKey>(elementsCount);
			}
			else
			{
				WeaponKeys.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ItemKey element = default(ItemKey);
				pCurrData += element.Deserialize(pCurrData);
				WeaponKeys.Add(element);
			}
		}
		else
		{
			WeaponKeys?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (WeaponFrames == null)
			{
				WeaponFrames = new List<CountdownData>(elementsCount2);
			}
			else
			{
				WeaponFrames.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				CountdownData element2 = default(CountdownData);
				pCurrData += element2.Deserialize(pCurrData);
				WeaponFrames.Add(element2);
			}
		}
		else
		{
			WeaponFrames?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
