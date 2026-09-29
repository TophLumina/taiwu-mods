using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Extra;

[SerializableGameData(IsExtensible = true)]
public class CricketCollectionData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CollectionCrickets = 0;

		public const ushort CollectionCricketJars = 1;

		public const ushort CollectionCricketRegen = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "Cricket", "CricketJar", "CricketRegen" };
	}

	public const int CricketCollectionCapacity = 17;

	[SerializableGameDataField]
	public ItemKey Cricket;

	[SerializableGameDataField]
	public ItemKey CricketJar;

	[SerializableGameDataField]
	public int CricketRegen;

	public CricketCollectionData(ItemKey crickets, ItemKey cricketJar, int cricketRegen)
	{
		Cricket = crickets;
		CricketJar = cricketJar;
		CricketRegen = cricketRegen;
	}

	public CricketCollectionData()
	{
	}

	public CricketCollectionData(CricketCollectionData other)
	{
		Cricket = other.Cricket;
		CricketJar = other.CricketJar;
		CricketRegen = other.CricketRegen;
	}

	public void Assign(CricketCollectionData other)
	{
		Cricket = other.Cricket;
		CricketJar = other.CricketJar;
		CricketRegen = other.CricketRegen;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 22;
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
		pCurrData += Cricket.Serialize(pCurrData);
		pCurrData += CricketJar.Serialize(pCurrData);
		*(int*)pCurrData = CricketRegen;
		pCurrData += 4;
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
			pCurrData += Cricket.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			pCurrData += CricketJar.Deserialize(pCurrData);
		}
		if (num > 2)
		{
			CricketRegen = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
