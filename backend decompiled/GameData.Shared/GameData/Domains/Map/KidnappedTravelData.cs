using GameData.Serializer;

namespace GameData.Domains.Map;

[SerializableGameData(IsExtensible = true)]
public class KidnappedTravelData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Target = 0;

		public const ushort HunterCharId = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Target", "HunterCharId" };
	}

	public static readonly KidnappedTravelData Invalid = new KidnappedTravelData();

	[SerializableGameDataField]
	public Location Target = Location.Invalid;

	[SerializableGameDataField]
	public int HunterCharId = -1;

	public bool Valid
	{
		get
		{
			if (Target.IsValid())
			{
				return HunterCharId >= 0;
			}
			return false;
		}
	}

	public KidnappedTravelData()
	{
	}

	public KidnappedTravelData(KidnappedTravelData other)
	{
		Target = other.Target;
		HunterCharId = other.HunterCharId;
	}

	public void Assign(KidnappedTravelData other)
	{
		Target = other.Target;
		HunterCharId = other.HunterCharId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
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
		pCurrData += Target.Serialize(pCurrData);
		*(int*)pCurrData = HunterCharId;
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
			pCurrData += Target.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			HunterCharId = *(int*)pCurrData;
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
