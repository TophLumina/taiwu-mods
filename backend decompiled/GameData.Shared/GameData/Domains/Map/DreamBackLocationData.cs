using GameData.Serializer;

namespace GameData.Domains.Map;

[SerializableGameData(IsExtensible = true)]
public struct DreamBackLocationData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Location = 0;

		public const ushort InternalType = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Location", "InternalType" };
	}

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	private sbyte _internalType;

	public EDreamBackLocationType Type => (EDreamBackLocationType)_internalType;

	public static DreamBackLocationData Create(Location location, EDreamBackLocationType locationType)
	{
		return new DreamBackLocationData
		{
			Location = location,
			_internalType = (sbyte)locationType
		};
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
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
		pCurrData += Location.Serialize(pCurrData);
		*pCurrData = (byte)_internalType;
		pCurrData++;
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
			pCurrData += Location.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			_internalType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
