using GameData.Serializer;

namespace GameData.Domains.World;

[SerializableGameData(NoCopyConstructors = true, IsExtensible = true)]
public class BigEventRecord : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort OccurDate = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "OccurDate" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int OccurDate;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
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
		*(int*)num = OccurDate;
		int totalSize = (int)(num + 4 - pData);
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
			OccurDate = *(int*)pCurrData;
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
