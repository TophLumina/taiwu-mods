using GameData.Serializer;

namespace GameData.ArchiveData;

[SerializableGameData(IsExtensible = true)]
public class ArchiveFileMeta : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CompressionAlgorithm = 0;

		public const ushort CompressionType = 1;

		public const ushort GameVersion = 2;

		public const ushort GameBuildDate = 3;

		public const ushort IncompatibilityMarkVersion = 4;

		public const ushort InitGameVersion = 5;

		public const ushort InitGameBuildDate = 6;

		public const ushort Count = 7;

		public static readonly string[] FieldId2FieldName = new string[7] { "CompressionAlgorithm", "CompressionType", "GameVersion", "GameBuildDate", "IncompatibilityMarkVersion", "InitGameVersion", "InitGameBuildDate" };
	}

	[SerializableGameDataField]
	public ushort IncompatibilityMarkVersion;

	[SerializableGameDataField]
	private byte _compressionAlgorithm;

	[SerializableGameDataField]
	private byte _compressionType;

	[SerializableGameDataField]
	public ulong InitGameVersion;

	[SerializableGameDataField]
	public ulong InitGameBuildDate;

	[SerializableGameDataField]
	public ulong GameVersion;

	[SerializableGameDataField]
	public ulong GameBuildDate;

	public CompressionAlgorithm CompressionAlgorithm
	{
		get
		{
			return (CompressionAlgorithm)_compressionAlgorithm;
		}
		set
		{
			_compressionAlgorithm = (byte)value;
		}
	}

	public CompressionType CompressionType
	{
		get
		{
			return (CompressionType)_compressionType;
		}
		set
		{
			_compressionType = (byte)value;
		}
	}

	public ArchiveFileMeta()
	{
	}

	public ArchiveFileMeta(ArchiveFileMeta other)
	{
		_compressionAlgorithm = other._compressionAlgorithm;
		_compressionType = other._compressionType;
		GameVersion = other.GameVersion;
		GameBuildDate = other.GameBuildDate;
		IncompatibilityMarkVersion = other.IncompatibilityMarkVersion;
		InitGameVersion = other.InitGameVersion;
		InitGameBuildDate = other.InitGameBuildDate;
	}

	public void Assign(ArchiveFileMeta other)
	{
		_compressionAlgorithm = other._compressionAlgorithm;
		_compressionType = other._compressionType;
		GameVersion = other.GameVersion;
		GameBuildDate = other.GameBuildDate;
		IncompatibilityMarkVersion = other.IncompatibilityMarkVersion;
		InitGameVersion = other.InitGameVersion;
		InitGameBuildDate = other.InitGameBuildDate;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 38;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 7;
		byte* num = pData + 2;
		*num = _compressionAlgorithm;
		byte* num2 = num + 1;
		*num2 = _compressionType;
		byte* num3 = num2 + 1;
		*(ulong*)num3 = GameVersion;
		byte* num4 = num3 + 8;
		*(ulong*)num4 = GameBuildDate;
		byte* num5 = num4 + 8;
		*(ushort*)num5 = IncompatibilityMarkVersion;
		byte* num6 = num5 + 2;
		*(ulong*)num6 = InitGameVersion;
		byte* num7 = num6 + 8;
		*(ulong*)num7 = InitGameBuildDate;
		int totalSize = (int)(num7 + 8 - pData);
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
			_compressionAlgorithm = *pCurrData;
			pCurrData++;
		}
		if (num > 1)
		{
			_compressionType = *pCurrData;
			pCurrData++;
		}
		if (num > 2)
		{
			GameVersion = *(ulong*)pCurrData;
			pCurrData += 8;
		}
		if (num > 3)
		{
			GameBuildDate = *(ulong*)pCurrData;
			pCurrData += 8;
		}
		if (num > 4)
		{
			IncompatibilityMarkVersion = *(ushort*)pCurrData;
			pCurrData += 2;
		}
		if (num > 5)
		{
			InitGameVersion = *(ulong*)pCurrData;
			pCurrData += 8;
		}
		if (num > 6)
		{
			InitGameBuildDate = *(ulong*)pCurrData;
			pCurrData += 8;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
