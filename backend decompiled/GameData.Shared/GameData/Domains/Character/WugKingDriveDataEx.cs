using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 王蛊驱动数据（新版）
/// 记录某个王蛊的驱动状态和驱动时间
/// </summary>
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

	/// <summary>
	/// 驱动类型（None/Positive/Negative）
	/// </summary>
	[SerializableGameDataField]
	public sbyte DriveType;

	/// <summary>
	/// 驱动开始日期
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 7;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
