using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Building;

public class BuildingExceptionData : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<BuildingBlockKey, BuildingExceptionItem> BuildingExceptionDict = new Dictionary<BuildingBlockKey, BuildingExceptionItem>();

	public BuildingExceptionData()
	{
	}

	public BuildingExceptionData(BuildingExceptionData other)
	{
		if (other.BuildingExceptionDict != null)
		{
			Dictionary<BuildingBlockKey, BuildingExceptionItem> buildingExceptionDict = other.BuildingExceptionDict;
			int elementsCount = buildingExceptionDict.Count;
			BuildingExceptionDict = new Dictionary<BuildingBlockKey, BuildingExceptionItem>(elementsCount);
			{
				foreach (KeyValuePair<BuildingBlockKey, BuildingExceptionItem> pair in buildingExceptionDict)
				{
					BuildingExceptionDict.Add(pair.Key, new BuildingExceptionItem(pair.Value));
				}
				return;
			}
		}
		BuildingExceptionDict = null;
	}

	public void Assign(BuildingExceptionData other)
	{
		if (other.BuildingExceptionDict != null)
		{
			Dictionary<BuildingBlockKey, BuildingExceptionItem> buildingExceptionDict = other.BuildingExceptionDict;
			int elementsCount = buildingExceptionDict.Count;
			BuildingExceptionDict = new Dictionary<BuildingBlockKey, BuildingExceptionItem>(elementsCount);
			{
				foreach (KeyValuePair<BuildingBlockKey, BuildingExceptionItem> pair in buildingExceptionDict)
				{
					BuildingExceptionDict.Add(pair.Key, new BuildingExceptionItem(pair.Value));
				}
				return;
			}
		}
		BuildingExceptionDict = null;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += SerializationHelper.DictionaryOfCustomTypePair.GetSerializedSize(BuildingExceptionDict);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypePair.Serialize(pData, ref BuildingExceptionDict) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypePair.Deserialize(pData, ref BuildingExceptionDict) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
