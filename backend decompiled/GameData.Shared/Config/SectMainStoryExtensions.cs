namespace Config;

public static class SectMainStoryExtensions
{
	/// <summary>
	/// 是否包含可触发的地区主线
	/// </summary>
	/// <param name="config"></param>
	/// <returns></returns>
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
