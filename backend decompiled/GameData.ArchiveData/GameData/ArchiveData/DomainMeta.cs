using GameData.Serializer;

namespace GameData.ArchiveData;

[SerializableGameData(IsExtensible = true)]
public struct DomainMeta : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort DomainId = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "DomainId" };
	}

	[SerializableGameDataField]
	public ushort DomainId;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 1;
		byte* num = pData + 2;
		*(ushort*)num = DomainId;
		int totalSize = (int)(num + 2 - pData);
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
			DomainId = *(ushort*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
