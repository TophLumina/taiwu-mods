using System;
using System.Collections.Generic;
using System.Reflection;
using GameData.Domains;
using GameData.Utilities;
using NLog;

namespace GameData.Common;

public static class DataUpgradeManager
{
	private struct UpgradeInfo : IComparable<UpgradeInfo>
	{
		public ulong Version;

		public ulong Date;

		public int DomainId;

		public MethodInfo Handler;

		public int CompareTo(UpgradeInfo other)
		{
			int versionComparison = Version.CompareTo(other.Version);
			if (versionComparison != 0)
			{
				return versionComparison;
			}
			int dateComparison = Date.CompareTo(other.Date);
			if (dateComparison != 0)
			{
				return dateComparison;
			}
			return DomainId.CompareTo(other.DomainId);
		}
	}

	private enum ESortType
	{
		Version,
		Date
	}

	private class UpgradeSortByVersion : IComparer<UpgradeInfo>
	{
		public int Compare(UpgradeInfo x, UpgradeInfo y)
		{
			int versionComparison = x.Version.CompareTo(y.Version);
			if (versionComparison != 0)
			{
				return versionComparison;
			}
			return x.DomainId.CompareTo(y.DomainId);
		}
	}

	private class UpgradeSortByDate : IComparer<UpgradeInfo>
	{
		public int Compare(UpgradeInfo x, UpgradeInfo y)
		{
			int dateComparison = x.Date.CompareTo(y.Date);
			if (dateComparison != 0)
			{
				return dateComparison;
			}
			return x.DomainId.CompareTo(y.DomainId);
		}
	}

	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	private static readonly List<UpgradeInfo> DataUpgrades = new List<UpgradeInfo>();

	private static readonly UpgradeSortByVersion SortByVersion = new UpgradeSortByVersion();

	private static readonly UpgradeSortByDate SortByDate = new UpgradeSortByDate();

	private static ESortType _sortType;

	public static void Initialize()
	{
		Assembly assembly = Assembly.GetExecutingAssembly();
		Type[] types = assembly.GetTypes();
		foreach (Type type in types)
		{
			int domainId = ((int?)type.GetCustomAttribute<GameDataDomainAttribute>()?.Id) ?? (-1);
			MethodInfo[] methods = type.GetMethods((BindingFlags)(-1));
			foreach (MethodInfo method in methods)
			{
				InitUpgraders(domainId, method);
			}
		}
		DataUpgrades.Sort();
		_sortType = ESortType.Version;
		Logger.Info("DataUpgradeManager initialized.");
	}

	private static void InitUpgraders(int domainId, MethodInfo method)
	{
		DataUpgraderAttribute attribute = method.GetCustomAttribute<DataUpgraderAttribute>();
		if (attribute != null)
		{
			ulong version = VersionUtils.VersionStringToUlong(attribute.Version);
			ulong dateValue = VersionUtils.DateTimeStringToUlong(attribute.Date);
			UpgradeInfo upgradeInfo = new UpgradeInfo
			{
				Version = version,
				Date = dateValue,
				Handler = method,
				DomainId = domainId
			};
			DataUpgrades.Add(upgradeInfo);
		}
	}

	public static void Upgrade(DataContext context, ulong archiveDataBuildVersion, ulong archiveDataBuildDate)
	{
		Sort((archiveDataBuildVersion == 0L) ? ESortType.Date : ESortType.Version);
		object[] args = new object[1] { context };
		if (_sortType == ESortType.Version)
		{
			foreach (UpgradeInfo upgradeInfo in DataUpgrades)
			{
				if (VersionUtils.CompareVersion(upgradeInfo.Version, archiveDataBuildVersion) > 0)
				{
					BaseGameDataDomain domain = ((upgradeInfo.DomainId >= 0) ? DomainManager.Domains[upgradeInfo.DomainId] : null);
					Logger.Info($"[{"DataUpgradeManager"}] Execute {upgradeInfo.Handler.DeclaringType}.{upgradeInfo.Handler.Name}");
					upgradeInfo.Handler.Invoke(domain, args);
				}
			}
			return;
		}
		foreach (UpgradeInfo upgradeInfo2 in DataUpgrades)
		{
			if (upgradeInfo2.Date > archiveDataBuildDate)
			{
				BaseGameDataDomain domain2 = ((upgradeInfo2.DomainId >= 0) ? DomainManager.Domains[upgradeInfo2.DomainId] : null);
				Logger.Info($"[{"DataUpgradeManager"}] Execute {upgradeInfo2.Handler.DeclaringType}.{upgradeInfo2.Handler.Name}");
				upgradeInfo2.Handler.Invoke(domain2, args);
			}
		}
	}

	private static void Sort(ESortType sortType)
	{
		if (sortType != _sortType)
		{
			_sortType = sortType;
			List<UpgradeInfo> dataUpgrades = DataUpgrades;
			IComparer<UpgradeInfo> comparer;
			if (sortType != ESortType.Version)
			{
				IComparer<UpgradeInfo> sortByDate = SortByDate;
				comparer = sortByDate;
			}
			else
			{
				IComparer<UpgradeInfo> sortByDate = SortByVersion;
				comparer = sortByDate;
			}
			dataUpgrades.Sort(comparer);
		}
	}
}
