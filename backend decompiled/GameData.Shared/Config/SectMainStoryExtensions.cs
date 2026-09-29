namespace Config;

public static class SectMainStoryExtensions
{
	public static bool IsReady(this SectMainStoryItem config)
	{
		int[] taskChains = config.TaskChains;
		if (taskChains != null && taskChains.Length > 0)
		{
			return config.TaskReadyWorldState >= 0;
		}
		return false;
	}
}
