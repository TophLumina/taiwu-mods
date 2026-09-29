using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

[SerializableGameData(IsExtensible = true)]
public class CricketPlaceExtraData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort ExtraMapUnits = 0;

		public const ushort RegularCrickets = 1;

		public const ushort WishingCrickets = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "ExtraMapUnits", "RegularCrickets", "WishingCrickets" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public Dictionary<short, short> ExtraMapUnits;

	[SerializableGameDataField(FieldIndex = 1)]
	public List<short> RegularCrickets;

	[SerializableGameDataField(FieldIndex = 2)]
	public Dictionary<short, short> WishingCrickets;

	public bool IsRegularCricket(short blockId)
	{
		return RegularCrickets?.Contains(blockId) ?? false;
	}

	public CricketPlaceExtraData()
	{
	}

	public CricketPlaceExtraData(CricketPlaceExtraData other)
	{
		ExtraMapUnits = ((other.ExtraMapUnits == null) ? null : new Dictionary<short, short>(other.ExtraMapUnits));
		RegularCrickets = ((other.RegularCrickets == null) ? null : new List<short>(other.RegularCrickets));
		WishingCrickets = ((other.WishingCrickets == null) ? null : new Dictionary<short, short>(other.WishingCrickets));
	}

	public void Assign(CricketPlaceExtraData other)
	{
		ExtraMapUnits = ((other.ExtraMapUnits == null) ? null : new Dictionary<short, short>(other.ExtraMapUnits));
		RegularCrickets = ((other.RegularCrickets == null) ? null : new List<short>(other.RegularCrickets));
		WishingCrickets = ((other.WishingCrickets == null) ? null : new Dictionary<short, short>(other.WishingCrickets));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(ExtraMapUnits);
		totalSize = ((RegularCrickets == null) ? (totalSize + 2) : (totalSize + (2 + 2 * RegularCrickets.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(WishingCrickets);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref ExtraMapUnits);
		if (RegularCrickets != null)
		{
			int elementsCount = RegularCrickets.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = RegularCrickets[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref WishingCrickets);
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref ExtraMapUnits);
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (RegularCrickets == null)
				{
					RegularCrickets = new List<short>(elementsCount);
				}
				else
				{
					RegularCrickets.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					RegularCrickets.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				RegularCrickets?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref WishingCrickets);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
