using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameData.Common;
using GameData.DLC.CricketPolymorph;
using GameData.DLC.EightYears;
using GameData.DLC.FiveLoong;
using GameData.DLC.GreenHillsRemain;
using GameData.DLC.HappyNewYear2024;
using GameData.DLC.HappyNewYear2025;
using GameData.DLC.HappyNewYear2026;
using GameData.Domains;
using GameData.Domains.Global;
using GameData.Domains.TaiwuEvent;
using NLog;

namespace GameData.DLC;

public static class DlcManager
{
	private static List<DlcInfo> _dlcInfoList;

	private static List<DlcId> _enabledDlcIds;

	private static Dictionary<ulong, DlcEntryWrapper> _dlcEntries;

	internal static void OnLoadedArchiveData(Dictionary<ulong, DlcEntryWrapper> dlcEntries)
	{
		_dlcEntries = dlcEntries;
		DataContext context = DataContextManager.GetCurrentThreadDataContext();
		foreach (DlcId dlcId in _enabledDlcIds)
		{
			DlcEntryWrapper entryWrapper;
			bool exist = _dlcEntries.TryGetValue(dlcId.AppId, out entryWrapper);
			IDlcEntry dlcEntry = (exist ? entryWrapper.GetDlcEntry() : CreateDlcEntry(dlcId));
			dlcEntry?.OnLoadedArchiveData(!exist);
			DomainManager.Extra.SetDlcEntry(context, dlcId, dlcEntry);
		}
	}

	internal static void InitializeOnEnterNewWorld(Dictionary<ulong, DlcEntryWrapper> dlcEntries)
	{
		_dlcEntries = dlcEntries;
		foreach (DlcId dlcId in _enabledDlcIds)
		{
			IDlcEntry entry = CreateDlcEntry(dlcId);
			entry?.OnEnterNewWorld();
			_dlcEntries.Add(dlcId.AppId, new DlcEntryWrapper(dlcId, entry));
		}
	}

	internal static void FixAbnormalArchiveData(DataContext context)
	{
		foreach (DlcId dlcId in _enabledDlcIds)
		{
			IDlcEntry entry = _dlcEntries[dlcId.AppId].GetDlcEntry();
			entry?.FixAbnormalArchiveData(context);
			DomainManager.Extra.SetDlcEntry(context, dlcId, entry);
		}
	}

	internal static void OnPostAdvanceMonth(DataContext context)
	{
		foreach (DlcId dlcId in _enabledDlcIds)
		{
			IDlcEntry entry = _dlcEntries[dlcId.AppId].GetDlcEntry();
			entry?.OnPostAdvanceMonth(context);
			DomainManager.Extra.SetDlcEntry(context, dlcId, entry);
		}
	}

	internal static void OnCrossArchive(DataContext context, CrossArchiveGameData crossArchiveGameData)
	{
		foreach (DlcId dlcId in _enabledDlcIds)
		{
			IDlcEntry entry = _dlcEntries[dlcId.AppId].GetDlcEntry();
			IDlcEntry entryBeforeCrossArchive = crossArchiveGameData.DlcEntries[dlcId.AppId].GetDlcEntry();
			entry?.OnCrossArchive(context, entryBeforeCrossArchive);
			DomainManager.Extra.SetDlcEntry(context, dlcId, entry);
		}
		crossArchiveGameData.DlcEntries = null;
	}

	public static IDlcEntry CreateDlcEntry(DlcId dlcId)
	{
		return dlcId.AppId switch
		{
			2764950uL => new FiveLoongDlcEntry(), 
			4395170uL => new HappyNewYear2026Entry(), 
			4528730uL => new CricketPolymorphEntry(), 
			3464590uL => new HappyNewYear2025Entry(), 
			2764960uL => new HappyNewYear2024Entry(), 
			2241120uL => new GiftFromConchShip1Entry(), 
			2172690uL => new GiftFromConchShip2Entry(), 
			4834440uL => new EightYearsEntry(), 
			4834450uL => new GreenHillsRemainEntry(), 
			_ => null, 
		};
	}

	public static bool CheckDlcEntryType(DlcId dlcId, Type type)
	{
		return true;
	}

	public static void SetDldInfoList(List<DlcInfo> dlcInfoList)
	{
		_dlcInfoList = new List<DlcInfo>();
		_enabledDlcIds = new List<DlcId>();
		foreach (DlcInfo dlcInfo in dlcInfoList)
		{
			_dlcInfoList.Add(new DlcInfo(dlcInfo.DlcId.AppId, dlcInfo.DlcId.Version, dlcInfo.IsInstalled, dlcInfo.EventDirectory));
			if (dlcInfo.IsInstalled)
			{
				_enabledDlcIds.Add(dlcInfo.DlcId);
			}
		}
	}

	public static bool IsDlcInstalled(ulong appId)
	{
		foreach (DlcInfo dlcInfo in _dlcInfoList)
		{
			if (dlcInfo.DlcId.AppId == appId && dlcInfo.IsInstalled)
			{
				return true;
			}
		}
		return false;
	}

	public static List<DlcId> GetAllInstalledDlcIds()
	{
		return _enabledDlcIds.ToList();
	}

	public static void LoadAllEventPackages()
	{
		LogManager.GetCurrentClassLogger().Info("Start loading Dlc Events:");
		foreach (DlcInfo dlcInfo in _dlcInfoList)
		{
			LogManager.GetCurrentClassLogger().Info($"DLC: {dlcInfo.DlcId}, Path: {dlcInfo.EventDirectory}");
			if (Directory.Exists(dlcInfo.EventDirectory))
			{
				EventPackagePathInfo pathInfo = new EventPackagePathInfo(dlcInfo.EventDirectory);
				string[] files = Directory.GetFiles(pathInfo.DllDirPath);
				foreach (string eventDll in files)
				{
					string packageName = Path.GetFileNameWithoutExtension(eventDll);
					DomainManager.TaiwuEvent.LoadEventPackageFromAssembly(packageName, pathInfo, dlcInfo.DlcId.ToString());
				}
			}
		}
	}
}
