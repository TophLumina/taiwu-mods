using GameData.Utilities;

namespace GameData.Domains.Adventure;

public static class AdventureVersionHelper
{
	public const int NowMajor = 0;

	public static void InitializeVersion(this AdventureRuntime runtime)
	{
		runtime.Version = new AdventureVersion(0, runtime.Core.MinorVersion);
	}

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
