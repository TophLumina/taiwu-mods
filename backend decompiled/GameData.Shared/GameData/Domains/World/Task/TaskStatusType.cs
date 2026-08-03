namespace GameData.Domains.World.Task;

public static class TaskStatusType
{
	/// <summary>
	/// 默认状态
	/// </summary>
	public const byte Default = 0;

	/// <summary>
	/// 受阻
	/// </summary>
	public const byte IsBlocked = 1;

	/// <summary>
	/// 已完成
	/// </summary>
	public const byte IsFinished = 2;

	/// <summary>
	/// 已过期（未完成消失）
	/// </summary>
	public const byte IsExpired = 4;
}
