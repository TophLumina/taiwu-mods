namespace GameData.Domains.World;

/// <summary>
/// 紫竹化身的任务状态
/// </summary>
public static class JuniorXiangshuTaskStatus
{
	/// <summary>
	/// 未完成
	/// </summary>
	public const sbyte Unfinished = 0;

	/// <summary>
	/// 生之篇
	/// </summary>
	public const sbyte Chapter1 = 1;

	/// <summary>
	/// 缘之篇
	/// </summary>
	public const sbyte Chapter2 = 2;

	/// <summary>
	/// 执之篇
	/// </summary>
	public const sbyte Chapter3 = 3;

	/// <summary>
	/// 灭之篇
	/// </summary>
	public const sbyte Chapter4 = 4;

	/// <summary>
	/// 劫之篇 - 坏结局
	/// </summary>
	public const sbyte BadEnding = 5;

	/// <summary>
	/// 解之篇 - 好结局
	/// </summary>
	public const sbyte GoodEnding = 6;
}
