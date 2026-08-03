using System;
using System.IO;
using System.Reflection;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Global;
using GameData.Domains.World;
using GameData.Utilities;

namespace GameData.ArchiveData;

public class LocalArchiveFile : ArchiveFileBase
{
	private static readonly byte[] FileTags = new byte[3] { 84, 49, 76 };

	private const ushort IncompatibilityMarkVersion = 4;

	public override ArchiveFileVersion ArchiveFileVersion => ArchiveFileVersion.ArchiveDataDotnetExperimental;

	public LocalArchiveFile(string path)
		: base(path)
	{
	}

	protected override ArchiveInfo ReadArchiveInfo(FileStream fileStream)
	{
		ArchiveFileVersion fileVersion = ArchiveFileVersion.Invalid;
		ArchiveFileMeta fileMeta = null;
		WorldInfo worldInfo = null;
		ReadHeader(fileStream, ref fileVersion, ref fileMeta, ref worldInfo);
		ArchiveFileVersion archiveFileVersion = fileVersion;
		ArchiveFileVersion archiveFileVersion2 = archiveFileVersion;
		if (archiveFileVersion2 == ArchiveFileVersion.ArchiveDataDotnetExperimental)
		{
			return new ArchiveInfo
			{
				Status = 1,
				WorldInfo = worldInfo
			};
		}
		return null;
	}

	protected override void WriteHeader(FileStream stream, CompressionAlgorithm compressionAlgorithm, CompressionType compressionType)
	{
		Crc32.Reset();
		InternalStream = stream;
		Write(FileTags, 0, FileTags.Length);
		Write((byte)ArchiveFileVersion);
		GameVersionInfo worldVersionInfo = DomainManager.World.GetWorldVersionInfo();
		string versionStr = DomainManager.Global.GetGameVersion();
		ulong version = VersionUtils.VersionStringToUlong(versionStr);
		ulong initVersion = VersionUtils.VersionStringToUlong(worldVersionInfo.GameVersionCreating);
		string buildDateStr = DomainManager.Global.GetGameBuildDate();
		ulong date;
		ulong buildDate = (ulong.TryParse(buildDateStr, out date) ? date : 0);
		ulong initBuildDate = (ulong.TryParse(worldVersionInfo.GameBuildDateCreating, out date) ? date : 0);
		ArchiveFileMeta archiveFileMeta = new ArchiveFileMeta
		{
			IncompatibilityMarkVersion = 4,
			CompressionAlgorithm = compressionAlgorithm,
			CompressionType = compressionType,
			GameVersion = version,
			GameBuildDate = buildDate,
			InitGameVersion = initVersion,
			InitGameBuildDate = initBuildDate
		};
		WriteSingleValueCustom(archiveFileMeta);
		WorldInfo worldInfo = DomainManager.World.GetWorldInfo();
		WriteSingleValueCustom(worldInfo);
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
		if (fileMeta.IncompatibilityMarkVersion != 4)
		{
			throw new ArchiveFileHeaderException(4, fileMeta.IncompatibilityMarkVersion);
		}
		ReadSingleValueCustom(ref worldInfo);
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
		BaseGameDataDomain[] domains = DomainManager.GetArchiveAttachedDomains();
		Write((ushort)domains.Length);
		BaseGameDataDomain[] array = domains;
		foreach (BaseGameDataDomain domain in array)
		{
			GameDataDomainAttribute domainAttribute = domain.GetType().GetCustomAttribute<GameDataDomainAttribute>();
			if (domainAttribute == null)
			{
				throw new Exception();
			}
			WriteDomainMeta(domainAttribute.Id);
			domain.OnSaveWorld(this);
		}
		string workingDbPath = DatabaseBridge.WorkingDbPath;
		DatabaseBridge.Disconnect(deleteWorkingDb: false);
		using (FileStream targetFile = File.OpenRead(workingDbPath))
		{
			Write(targetFile.Length);
			CopyFrom(targetFile, targetFile.Length);
		}
		DatabaseBridge.Connect();
		CompressionStreamFactory.EndCompression(InternalStream);
		InternalStream = fileStream;
		WriteCrcToEnd(Crc32.GetCurrentHashAsUInt32());
		InternalStream = null;
	}

	protected override void ReadContent(FileStream fileStream, ArchiveFileMeta fileMeta)
	{
		InternalStream = CompressionStreamFactory.StartDecompression(fileStream, fileMeta.CompressionAlgorithm);
		Crc32.Reset();
		DomainManager.ResetArchiveAttachedDomains();
		int domainCount = Read<ushort>();
		BoolArray32 domainInitStates = default(BoolArray32);
		for (int i = 0; i < domainCount; i++)
		{
			DomainMeta domainMeta = ReadDomainMeta();
			if (DomainManager.Domains.Length <= domainMeta.DomainId)
			{
				throw new Exception();
			}
			BaseGameDataDomain domain = DomainManager.Domains[domainMeta.DomainId];
			domain.OnLoadWorld(this);
			domainInitStates.Set(domainMeta.DomainId, value: true);
		}
		ushort[] archiveAttachedDomainIds = DomainManager.ArchiveAttachedDomainIds;
		foreach (ushort domainId in archiveAttachedDomainIds)
		{
			BaseGameDataDomain domain2 = DomainManager.Domains[domainId];
			if (domainInitStates[domainId])
			{
				domain2.InitNewDomainDataFields();
				continue;
			}
			domain2.OnEnterNewWorld();
			domain2.InitNewDomainDataFields();
			DomainManager.Global.CompleteLoading(domainId);
			AdaptableLog.TagInfo("LoadArchive", "Initializing new domain " + domain2.GetType().Name + ".");
		}
		string workingDbPath = DatabaseBridge.WorkingDbPath;
		DatabaseBridge.Disconnect(deleteWorkingDb: false);
		File.Delete(workingDbPath);
		using (FileStream targetFile = File.OpenWrite(workingDbPath))
		{
			long length = Read<long>();
			CopyTo(targetFile, length);
		}
		DatabaseBridge.Connect();
		CompressionStreamFactory.EndDecompression(InternalStream, fileMeta.CompressionAlgorithm);
		InternalStream = fileStream;
		uint actualCrc32 = Crc32.GetCurrentHashAsUInt32();
		uint savedCrc32 = ReadCrcFromEnd();
		if (actualCrc32 != savedCrc32)
		{
			throw new Exception($"Corrupted domain data detected by crc32. Read {savedCrc32}, {actualCrc32} calculated.");
		}
		DataUpgradeManager.Upgrade(DataContextManager.GetCurrentThreadDataContext(), fileMeta.GameVersion, fileMeta.GameBuildDate);
		InternalStream = null;
	}

	public void WriteDomainMeta(ushort domainId)
	{
		DomainMeta meta = new DomainMeta
		{
			DomainId = domainId
		};
		WriteSingleValueCustom(meta);
	}

	public DomainMeta ReadDomainMeta()
	{
		DomainMeta meta = default(DomainMeta);
		ReadSingleValueCustom(ref meta);
		return meta;
	}
}
