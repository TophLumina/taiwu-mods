using System;
using GameData.Serializer;

namespace GameData.DLC;

public struct DlcId(ulong appId, ulong version) : ISerializableGameData, IEquatable<DlcId>
{
	/// <summary>
	/// Dlc 发布时的文件Id
	/// </summary>
	[SerializableGameDataField]
	public ulong AppId = appId;

	/// <summary>
	/// Dlc 的版本
	/// </summary>
	[SerializableGameDataField]
	public ulong Version = version;

	public bool Equals(DlcId other)
	{
		if (AppId == other.AppId)
		{
			return Version == other.Version;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (AppId.GetHashCode() * 397) ^ Version.GetHashCode();
	}

	public override string ToString()
	{
		return $"{AppId}_{Version}";
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 16;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(ulong*)pData = AppId;
		byte* num = pData + 8;
		*(ulong*)num = Version;
		int totalSize = (int)(num + 8 - pData);
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
		AppId = *(ulong*)pCurrData;
		pCurrData += 8;
		Version = *(ulong*)pCurrData;
		pCurrData += 8;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
