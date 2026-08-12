using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using GameData.Utilities;
using SQLite;

namespace GameData.ArchiveData;

public static class DatabaseBridge
{
	private const string WorkingDbName = "working.db";

	private static SQLiteConnection _liteConnection;

	private static readonly Stopwatch ExecuteTimer = new Stopwatch();

	private static readonly Stopwatch QueryTimer = new Stopwatch();

	private static readonly List<Type> RegisteredTables = new List<Type>();

	public static string WorkingDbPath => _liteConnection?.DatabasePath ?? Path.Combine(Common.ArchiveBaseDir, "working.db");

	public static void RegisterTable<T>()
	{
		RegisteredTables.Add(typeof(T));
	}

	public static void RegisterAllTables(Assembly assembly)
	{
		Type[] types = assembly.GetTypes();
		foreach (Type type in types)
		{
			if (type.GetCustomAttribute<DatabaseEntryAttribute>() != null)
			{
				RegisteredTables.Add(type);
			}
		}
	}

	public static void Connect()
	{
		_liteConnection?.Close();
		_liteConnection = new SQLiteConnection(new SQLiteConnectionString(Path.Combine(Common.ArchiveBaseDir, "working.db"), SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, storeDateTimeAsTicks: true));
		foreach (Type registeredTableType in RegisteredTables)
		{
			_liteConnection.CreateTable(registeredTableType);
		}
	}

	public static void Disconnect(bool deleteWorkingDb)
	{
		_liteConnection?.Close();
		_liteConnection = null;
		if (deleteWorkingDb)
		{
			string path = Path.Combine(Common.ArchiveBaseDir, "working.db");
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
	}

	public static void InsertAll<T>(IEnumerable<T> enumerable)
	{
		_liteConnection.InsertAll(enumerable, typeof(T));
	}

	public static void Execute(string sql, params object[] objects)
	{
		ExecuteTimer.Restart();
		_liteConnection.BeginTransaction();
		try
		{
			_liteConnection.Execute(sql, objects);
			_liteConnection.Commit();
		}
		catch (Exception arg)
		{
			_liteConnection.Rollback();
			AdaptableLog.TagWarning("DatabaseBridge", $"Failure to execute sql command, data is rolled back.\n{arg}\n\n{sql}", appendWarningMessage: true);
		}
		ExecuteTimer.Stop();
		AdaptableLog.TagInfo("DatabaseBridge", $"Sql command execution time: {ExecuteTimer.ElapsedMilliseconds}ms");
	}

	public static IEnumerable<T> Query<T>(Expression<Func<T, bool>> predicate) where T : new()
	{
		return _liteConnection.Table<T>().Where(predicate);
	}

	public static List<T> Query<T>(string query, params object[] objects) where T : new()
	{
		QueryTimer.Restart();
		List<T> result = null;
		try
		{
			result = _liteConnection.Query<T>(query, objects);
		}
		catch (Exception arg)
		{
			AdaptableLog.TagWarning("DB", $"Failure to execute sql query.\n{arg}\n\n{query}", appendWarningMessage: true);
		}
		QueryTimer.Stop();
		AdaptableLog.TagInfo("DB", $"Sql query execution time: {QueryTimer.ElapsedMilliseconds}ms");
		return result;
	}

	public static void Query<T>(List<T> container, string query, params object[] objects) where T : new()
	{
		QueryTimer.Restart();
		try
		{
			container.AddRange(_liteConnection.DeferredQuery<T>(query, objects));
		}
		catch (Exception arg)
		{
			AdaptableLog.TagWarning("DB", $"Failure to execute sql query.\n{arg}\n\n{query}", appendWarningMessage: true);
		}
		QueryTimer.Stop();
		AdaptableLog.TagInfo("DB", $"Sql query execution time: {QueryTimer.ElapsedMilliseconds}ms");
	}
}
