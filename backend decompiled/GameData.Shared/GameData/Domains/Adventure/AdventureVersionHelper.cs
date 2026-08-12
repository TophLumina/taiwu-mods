using GameData.Utilities;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇版本号工具集
/// </summary>
public static class AdventureVersionHelper
{
	public const int NowMajor = 0;

	/// <summary>
	/// 初始化版本号
	/// </summary>
	public static void InitializeVersion(this AdventureRuntime runtime)
	{
		runtime.Version = new AdventureVersion(0, runtime.Core.MinorVersion);
	}

	/// <summary>
	/// 判断是否需要升级奇遇
	/// </summary>
	public static bool CheckUpgrade(this AdventureRuntime adventure, IAdventureContextBridge context, out AdventureRuntime newAdventure)
	{
		AdventureVersion nowVersion = new AdventureVersion(0, adventure.Core.MinorVersion);
		if (nowVersion > adventure.Version)
		{
			newAdventure = new AdventureRuntime(adventure.Id, adventure.MapLocation, adventure.Core);
			if (newAdventure.InheritByUpgrade(adventure))
			{
				adventure.ReleaseData(context);
			}
			else
			{
				newAdventure = null;
				AdaptableLog.Warning($"Inherit failed at {adventure} {adventure.Version} => {nowVersion}");
			}
			return true;
		}
		newAdventure = adventure;
		return false;
	}
}
