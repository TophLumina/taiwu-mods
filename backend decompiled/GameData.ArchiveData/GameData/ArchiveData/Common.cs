using System;
using System.Collections.Generic;
using System.IO;
using NLog;

namespace GameData.ArchiveData;

public static class Common
{
	public const sbyte ArchiveSlotsCount = 15;

	private const sbyte InvalidArchiveId = -1;

	private const string LocalSaveName = "local.sav";

	private const string OldLocalSaveName = "local.sav.old";

	private const string DreamBackLocalSaveName = "local.sav.sp";

	private const string DreamBackDatabaseSaveName = "db.sav.sp";

	private const string BackupLocalSavePrefix = "local.sav.bak.";

	private const string TmpSaveName = "tmp.sav";

	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	private static sbyte _currArchiveId = -1;

	public static string ArchiveBaseDir { get; private set; }

	public static string CurrArchivePath => GetArchiveDataPath(_currArchiveId);

	public static string CurrDreamBackArchivePath => GetDreamBackArchiveDataPath(_currArchiveId);

	public static void Initialize(string baseDataDir, bool isTestVersion)
	{
		ArchiveBaseDir = Path.Combine(baseDataDir, isTestVersion ? "SaveGames_test" : "SaveGames");
	}

	public static void SetArchiveId(sbyte archiveId)
	{
		if (!CheckArchiveId(archiveId))
		{
			throw new Exception($"Invalid archiveId: {archiveId}");
		}
		_currArchiveId = archiveId;
	}

	public static void ResetArchiveId()
	{
		_currArchiveId = -1;
	}

	public static sbyte GetCurrArchiveId()
	{
		return _currArchiveId;
	}

	public static bool CheckArchiveId(sbyte archiveId)
	{
		if (archiveId >= 0)
		{
			return archiveId < 15;
		}
		return false;
	}

	public static string GetArchiveDataDirectory(sbyte archiveId)
	{
		return Path.Combine(ArchiveBaseDir, $"world_{archiveId + 1}");
	}

	public static string GetArchiveDataPath(sbyte archiveId)
	{
		return Path.Combine(ArchiveBaseDir, $"world_{archiveId + 1}", "local.sav");
	}

	public static string GetTempSavePath(sbyte archiveId)
	{
		return Path.Combine(ArchiveBaseDir, $"world_{archiveId + 1}", "tmp.sav");
	}

	public static string GetArchiveDataPath(sbyte archiveId, long backupTimestamp)
	{
		return Path.Combine(ArchiveBaseDir, $"world_{archiveId + 1}", string.Format("{0}{1}", "local.sav.bak.", backupTimestamp));
	}

	public static string GetDreamBackArchiveDataPath(sbyte archiveId)
	{
		return Path.Combine(ArchiveBaseDir, $"world_{archiveId + 1}", "local.sav.sp");
	}

	public static string GetDreamBackArchiveDatabasePath(sbyte archiveId)
	{
		return Path.Combine(ArchiveBaseDir, $"world_{archiveId + 1}", "db.sav.sp");
	}

	public static void DeleteArchive(sbyte archiveId)
	{
		Directory.Delete(GetArchiveDataDirectory(archiveId), recursive: true);
	}

	public static void MakeBackup(sbyte archiveId)
	{
		string filePath = GetArchiveDataPath(archiveId);
		long timestamp = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
		string backupPath = GetArchiveDataPath(archiveId, timestamp);
		if (File.Exists(filePath))
		{
			File.Copy(filePath, backupPath, overwrite: true);
		}
	}

	public static void RemoveRedundantBackups(sbyte archiveId, int maxBackupCount)
	{
		List<long> backups = GetBackupTimestamps(archiveId);
		if (backups.Count > maxBackupCount)
		{
			int i = 0;
			for (int count = backups.Count - maxBackupCount; i < count; i++)
			{
				long timestamp = backups[i];
				File.Delete(GetArchiveDataPath(archiveId, timestamp));
			}
		}
	}

	public static List<long> GetBackupTimestamps(sbyte archiveId)
	{
		string[] files = Directory.GetFiles(GetArchiveDataDirectory(archiveId));
		List<long> backups = new List<long>();
		string[] array = files;
		for (int i = 0; i < array.Length; i++)
		{
			string filename = Path.GetFileName(array[i]);
			if (filename.StartsWith("local.sav.bak."))
			{
				if (!long.TryParse(filename.Substring("local.sav.bak.".Length), out var timestamp))
				{
					Logger.Warn("Invalid backup name: " + filename);
				}
				else
				{
					backups.Add(timestamp);
				}
			}
		}
		backups.Sort();
		return backups;
	}

	public static bool IsInWorld()
	{
		if (_currArchiveId >= 0)
		{
			return _currArchiveId < 15;
		}
		return false;
	}
}
