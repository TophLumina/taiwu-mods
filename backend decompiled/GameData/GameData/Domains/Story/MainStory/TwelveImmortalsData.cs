using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Story.MainStory;

[SerializableGameData(NotForDisplayModule = true, IsExtensible = true)]
public class TwelveImmortalsData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort TwelveImmortalsImpactRangeMoveCost = 0;

		public const ushort TwelveImmortals3TaiwuMovedLocations = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "TwelveImmortalsImpactRangeMoveCost", "TwelveImmortals3TaiwuMovedLocations" };
	}

	[SerializableGameDataField]
	public Dictionary<sbyte, int> TwelveImmortalsImpactRangeMoveCost;

	[SerializableGameDataField]
	public Dictionary<Location, int> TwelveImmortals3TaiwuMovedLocations;

	public TwelveImmortalsData()
	{
	}

	public TwelveImmortalsData(TwelveImmortalsData other)
	{
		TwelveImmortalsImpactRangeMoveCost = ((other.TwelveImmortalsImpactRangeMoveCost == null) ? null : new Dictionary<sbyte, int>(other.TwelveImmortalsImpactRangeMoveCost));
		TwelveImmortals3TaiwuMovedLocations = ((other.TwelveImmortals3TaiwuMovedLocations == null) ? null : new Dictionary<Location, int>(other.TwelveImmortals3TaiwuMovedLocations));
	}

	public void Assign(TwelveImmortalsData other)
	{
		TwelveImmortalsImpactRangeMoveCost = ((other.TwelveImmortalsImpactRangeMoveCost == null) ? null : new Dictionary<sbyte, int>(other.TwelveImmortalsImpactRangeMoveCost));
		TwelveImmortals3TaiwuMovedLocations = ((other.TwelveImmortals3TaiwuMovedLocations == null) ? null : new Dictionary<Location, int>(other.TwelveImmortals3TaiwuMovedLocations));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(TwelveImmortalsImpactRangeMoveCost);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(TwelveImmortals3TaiwuMovedLocations);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref TwelveImmortalsImpactRangeMoveCost);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref TwelveImmortals3TaiwuMovedLocations);
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref TwelveImmortalsImpactRangeMoveCost);
		}
		if (fieldCount > 1)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref TwelveImmortals3TaiwuMovedLocations);
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
