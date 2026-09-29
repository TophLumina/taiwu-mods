using System.Collections.Generic;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Combat;

[AutoGenerateSerializableGameData(NotForArchive = true)]
public class DefeatMarksCountOutOfCombatData : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<short, int> DefeatMarksDict = new Dictionary<short, int>();

	public DefeatMarksCountOutOfCombatData()
	{
	}

	public DefeatMarksCountOutOfCombatData(DefeatMarksCountOutOfCombatData other)
	{
		DefeatMarksDict = ((other.DefeatMarksDict == null) ? null : new Dictionary<short, int>(other.DefeatMarksDict));
	}

	public void Assign(DefeatMarksCountOutOfCombatData other)
	{
		DefeatMarksDict = ((other.DefeatMarksDict == null) ? null : new Dictionary<short, int>(other.DefeatMarksDict));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += 4;
		if (DefeatMarksDict != null)
		{
			foreach (KeyValuePair<short, int> item in DefeatMarksDict)
			{
				_ = item;
				totalSize += 2;
				totalSize += 4;
			}
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
		if (DefeatMarksDict != null)
		{
			*(int*)pCurrData = DefeatMarksDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, int> pair in DefeatMarksDict)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
		int DefeatMarksDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (DefeatMarksDictElementsCount > 0)
		{
			if (DefeatMarksDict == null)
			{
				DefeatMarksDict = new Dictionary<short, int>();
			}
			else
			{
				DefeatMarksDict.Clear();
			}
			for (int i = 0; i < DefeatMarksDictElementsCount; i++)
			{
				short key = *(short*)pCurrData;
				pCurrData += 2;
				int value = *(int*)pCurrData;
				pCurrData += 4;
				DefeatMarksDict.Add(key, value);
			}
		}
		else
		{
			DefeatMarksDict?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
