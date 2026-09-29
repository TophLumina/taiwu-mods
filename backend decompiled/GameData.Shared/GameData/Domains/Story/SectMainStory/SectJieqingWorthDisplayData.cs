using System.Collections.Generic;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Story.SectMainStory;

[AutoGenerateSerializableGameData(NotForArchive = true)]
public class SectJieqingWorthDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<int, int> Value;

	public static implicit operator SectJieqingWorthDisplayData(Dictionary<int, int> value)
	{
		return new SectJieqingWorthDisplayData
		{
			Value = value
		};
	}

	public SectJieqingWorthDisplayData()
	{
	}

	public SectJieqingWorthDisplayData(SectJieqingWorthDisplayData other)
	{
		Value = ((other.Value == null) ? null : new Dictionary<int, int>(other.Value));
	}

	public void Assign(SectJieqingWorthDisplayData other)
	{
		Value = ((other.Value == null) ? null : new Dictionary<int, int>(other.Value));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += 4;
		if (Value != null)
		{
			foreach (KeyValuePair<int, int> item in Value)
			{
				_ = item;
				totalSize += 4;
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
		if (Value != null)
		{
			*(int*)pCurrData = Value.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, int> pair in Value)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
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
		int ValueElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (ValueElementsCount > 0)
		{
			if (Value == null)
			{
				Value = new Dictionary<int, int>();
			}
			else
			{
				Value.Clear();
			}
			for (int i = 0; i < ValueElementsCount; i++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				int value = *(int*)pCurrData;
				pCurrData += 4;
				Value.Add(key, value);
			}
		}
		else
		{
			Value?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
