using System;
using System.Text;
using NLog;
using Steamworks;

namespace GameData.Steamworks;

internal static class SteamManager
{
	private static readonly AppId_t _appId = new AppId_t(838350u);

	private static bool _initialized = false;

	private static CSteamID _steamId;

	private static SteamAPIWarningMessageHook_t _steamApiWarningMessageHook;

	private static Logger _logger;

	private static bool _achievementDirty;

	public static void Initialize()
	{
		_logger = LogManager.GetCurrentClassLogger();
		if (!Packsize.Test())
		{
			_logger.Error("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.");
		}
		if (!DllCheck.Test())
		{
			_logger.Error("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.");
		}
		_initialized = SteamAPI.Init();
		if (!_initialized)
		{
			throw new Exception("Failed to initialize steam API.");
		}
		_steamApiWarningMessageHook = LogWarn;
		SteamClient.SetWarningMessageHook(_steamApiWarningMessageHook);
		_steamId = SteamUser.GetSteamID();
		EUserHasLicenseForAppResult hasLicense = SteamUser.UserHasLicenseForApp(_steamId, _appId);
		if (hasLicense == EUserHasLicenseForAppResult.k_EUserHasLicenseResultDoesNotHaveLicense)
		{
			throw new Exception($"Current user {_steamId} does not have license for appid {_appId}, license status: {hasLicense}.");
		}
		_logger.Info("Verifying steam user successful! steam id " + _steamId.ToString());
		_achievementDirty = false;
	}

	public static void Update()
	{
		if (_initialized)
		{
			if (_achievementDirty)
			{
				_achievementDirty = false;
				SteamUserStats.StoreStats();
			}
			SteamAPI.RunCallbacks();
		}
	}

	public static bool AddAchievement(string achievementName)
	{
		_achievementDirty = true;
		return SteamUserStats.SetAchievement(achievementName);
	}

	public static bool GetAchievement(string achievementName, out bool achieved)
	{
		return SteamUserStats.GetAchievement(achievementName, out achieved);
	}

	public static bool SetStat(string statName, int value)
	{
		_achievementDirty = true;
		return SteamUserStats.SetStat(statName, value);
	}

	public static void ResetStatsAndAchievements()
	{
		_achievementDirty = true;
		SteamUserStats.ResetAllStats(bAchievementsToo: true);
	}

	public static bool IsDlcInstalled(uint dlcAppId)
	{
		return _initialized && SteamApps.BIsDlcInstalled(new AppId_t(dlcAppId));
	}

	public static void LogWarn(int nSeverity, StringBuilder pchDebugText)
	{
		_logger.Warn(pchDebugText);
	}

	public static void UnInitialize()
	{
		if (_initialized)
		{
			SteamAPI.Shutdown();
		}
	}
}
