using System;
using GameData.Serializer;

namespace GameData.Domains.Mod;

/// <summary>
/// 由 Steam workshop 的 FileId 和 Mod 版本号组成的Id
/// </summary>
public struct ModId(ulong fileId, ulong version, byte source) : ISerializableGameData, IEquatable<ModId>
{
	/// <summary>
	/// Mod 发布时的文件Id
	/// </summary>
	[SerializableGameDataField]
	public ulong FileId = fileId;

	/// <summary>
	/// Mod 的版本
	/// </summary>
	[SerializableGameDataField]
	public ulong Version = version;

	/// <summary>
	/// Mod临时Id，用于本地Mod测试
	/// </summary>
	[SerializableGameDataField]
	public byte Source = source;

	public bool IsValid
	{
		get
		{
			if (FileId != 0)
			{
				return FileId < ulong.MaxValue;
			}
			return false;
		}
	}

	public bool Equals(ModId other)
	{
		if (FileId == other.FileId && Source == other.Source)
		{
			return Version == other.Version;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((FileId.GetHashCode() * 397) ^ Source.GetHashCode()) * 397) ^ Version.GetHashCode();
	}

	public override string ToString()
	{
		return $"{Source}_{FileId}";
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 17;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(ulong*)pData = FileId;
		byte* num = pData + 8;
		*(ulong*)num = Version;
		byte* num2 = num + 8;
		*num2 = Source;
		int totalSize = (int)(num2 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		FileId = *(ulong*)pCurrData;
		pCurrData += 8;
		Version = *(ulong*)pCurrData;
		pCurrData += 8;
		Source = *pCurrData;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
