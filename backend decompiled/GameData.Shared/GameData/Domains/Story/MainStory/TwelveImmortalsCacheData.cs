using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Story.MainStory;

[SerializableGameData(NotForArchive = true)]
public class TwelveImmortalsCacheData : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<Location, int> MoveCostMultiplier = new Dictionary<Location, int>();

	public TwelveImmortalsCacheData()
	{
	}

	public TwelveImmortalsCacheData(TwelveImmortalsCacheData other)
	{
		MoveCostMultiplier = ((other.MoveCostMultiplier == null) ? null : new Dictionary<Location, int>(other.MoveCostMultiplier));
	}

	public void Assign(TwelveImmortalsCacheData other)
	{
		MoveCostMultiplier = ((other.MoveCostMultiplier == null) ? null : new Dictionary<Location, int>(other.MoveCostMultiplier));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(MoveCostMultiplier);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pData, ref MoveCostMultiplier) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pData, ref MoveCostMultiplier) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
