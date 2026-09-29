using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

[Obsolete("序列化长度有误，请使用 WugKingDriveDataEx")]
public struct WugKingDriveData(sbyte driveType, int startDate) : ISerializableGameData
{
	public sbyte DriveType = driveType;

	public int StartDate = startDate;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
