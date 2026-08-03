namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇状态类型拓展方法集
/// </summary>
public static class AdventureStatusTypeExtensions
{
	/// <summary>
	/// 是否为激活状态
	/// </summary>
	public static bool IsActive(this EAdventureStatusType type)
	{
		if (type - 1 <= EAdventureStatusType.Ready)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 是否为休眠状态
	/// </summary>
	public static bool IsAsleep(this EAdventureStatusType type)
	{
		if (type == EAdventureStatusType.Preparing || type == EAdventureStatusType.Hide)
		{
			return true;
		}
		return false;
	}
}
