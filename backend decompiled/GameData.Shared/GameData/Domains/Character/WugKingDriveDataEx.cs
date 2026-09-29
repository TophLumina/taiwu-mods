using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class WugKingDriveDataEx : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort DriveType = 0;

		public const ushort StartDate = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "DriveType", "StartDate" };
	}

	[SerializableGameDataField]
	public sbyte DriveType;

	[SerializableGameDataField]
	public int StartDate;

	public WugKingDriveDataEx()
	{
		DriveType = 0;
		StartDate = -1;
	}

	public WugKingDriveDataEx(sbyte driveType, int startDate)
	{
		DriveType = driveType;
		StartDate = startDate;
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
		*(short*)pData = 2;
		byte* num = pData + 2;
		*num = (byte)DriveType;
		byte* num2 = num + 1;
		*(int*)num2 = StartDate;
		int totalSize = (int)(num2 + 4 - pData);
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
			DriveType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			StartDate = *(int*)pCurrData;
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
