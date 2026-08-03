using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 王蛊驱动数据（已废弃，序列化长度有误，请使用 WugKingDriveDataEx）
/// </summary>
[Obsolete("序列化长度有误，请使用 WugKingDriveDataEx")]
public struct WugKingDriveData(sbyte driveType, int startDate) : ISerializableGameData
{
	/// <summary>
	/// 驱动类型（None/Positive/Negative）
	/// </summary>
	public sbyte DriveType = driveType;

	/// <summary>
	/// 驱动开始日期
	/// </summary>
	public int StartDate = startDate;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
