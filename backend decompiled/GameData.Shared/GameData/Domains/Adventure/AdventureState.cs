namespace GameData.Domains.Adventure;

/// <summary>
/// 当前奇遇中的状态
/// </summary>
public static class AdventureState
{
	public const sbyte Inactive = 0;

	public const sbyte EditPath = 1;

	public const sbyte Moving = 2;

	public const sbyte Finished = 3;

	public const sbyte SwitchingBranch = 4;
}
