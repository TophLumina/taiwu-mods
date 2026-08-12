using System;
using System.IO;
using GameData.Domains;
using GameData.Domains.Global;
using GameData.Utilities;

namespace GameData.ArchiveData;

public class GlobalArchiveFile : ArchiveFileBase
{
	private static readonly byte[] FileTags = new byte[3] { 84, 49, 71 };

	private const ushort IncompatibilityMarkVersion = 2;

	public override ArchiveFileVersion ArchiveFileVersion => ArchiveFileVersion.ArchiveDataDotnetExperimental;

	public GlobalArchiveFile(string path)
		: base(path)
	{
	}

	protected override ArchiveInfo ReadArchiveInfo(FileStream fileStream)
	{
		throw new NotImplementedException();
	}

	protected override void WriteHeader(FileStream stream, CompressionAlgorithm compressionAlgorithm, CompressionType compressionType)
	{
		Crc32.Reset();
		InternalStream = stream;
		Write(FileTags, 0, FileTags.Length);
		Write((byte)ArchiveFileVersion);
		string versionStr = DomainManager.Global.GetGameVersion();
		ulong version = VersionUtils.VersionStringToUlong(versionStr);
		string buildDateStr = DomainManager.Global.GetGameBuildDate();
		ulong date;
		ulong buildDate = (ulong.TryParse(buildDateStr, out date) ? date : 0);
		ArchiveFileMeta archiveFileMeta = new ArchiveFileMeta
		{
			IncompatibilityMarkVersion = 2,
			CompressionAlgorithm = compressionAlgorithm,
			CompressionType = compressionType,
			GameVersion = version,
			GameBuildDate = buildDate
		};
		WriteSingleValueCustom(archiveFileMeta);
		Write(Crc32.GetCurrentHashAsUInt32());
		InternalStream = null;
	}

	protected override void ReadHeader(FileStream stream, ref ArchiveFileVersion fileVersion, ref ArchiveFileMeta fileMeta, ref WorldInfo worldInfo)
	{
		Crc32.Reset();
		InternalStream = stream;
		byte[] fileTags = new byte[FileTags.Length];
		Read(fileTags, 0, fileTags.Length);
		if (!Extensions.SequenceEqual(FileTags, fileTags))
		{
			throw new ArchiveFileHeaderException(FileTags, fileTags);
		}
		fileVersion = (ArchiveFileVersion)Read<byte>();
		if (fileVersion != ArchiveFileVersion)
		{
			throw new ArchiveFileHeaderException(ArchiveFileVersion, fileVersion);
		}
		ReadSingleValueCustom(ref fileMeta);
		if (fileMeta.IncompatibilityMarkVersion != 2)
		{
			throw new ArchiveFileHeaderException(2, fileMeta.IncompatibilityMarkVersion);
		}
		uint actualCrc32 = Crc32.GetCurrentHashAsUInt32();
		uint savedCrc32 = Read<uint>();
		if (actualCrc32 != savedCrc32)
		{
			throw new ArchiveFileHeaderException($"Corrupted header detected by crc32. Read {savedCrc32}, {actualCrc32} calculated.");
		}
		InternalStream = null;
	}

	protected override void WriteContent(FileStream fileStream, CompressionAlgorithm compressionAlgorithm, CompressionType compressionType)
	{
		InternalStream = CompressionStreamFactory.StartCompression(fileStream, compressionAlgorithm, compressionType);
		Crc32.Reset();
		DomainManager.Global.OnSaveWorld(this);
		CompressionStreamFactory.EndCompression(InternalStream);
		InternalStream = fileStream;
		WriteCrcToEnd(Crc32.GetCurrentHashAsUInt32());
		InternalStream = null;
	}

	protected override void ReadContent(FileStream fileStream, ArchiveFileMeta fileMeta)
	{
		InternalStream = CompressionStreamFactory.StartDecompression(fileStream, fileMeta.CompressionAlgorithm);
		Crc32.Reset();
		DomainManager.Global.OnLoadWorld(this);
		CompressionStreamFactory.EndDecompression(InternalStream, fileMeta.CompressionAlgorithm);
		InternalStream = fileStream;
		uint actualCrc32 = Crc32.GetCurrentHashAsUInt32();
		uint savedCrc32 = ReadCrcFromEnd();
		if (actualCrc32 != savedCrc32)
		{
			throw new Exception($"Corrupted domain data detected by crc32. Read {savedCrc32}, {actualCrc32} calculated.");
		}
		InternalStream = null;
	}
}
