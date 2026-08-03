namespace GameData.Domains.Character;

/// <summary>
/// 智能角色的生死状态
/// </summary>
public static class LifeState
{
	/// <summary>
	/// 无效值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 活着
	/// </summary>
	public const sbyte Alive = 0;

	/// <summary>
	/// 已死亡但还未被删除
	/// </summary>
	public const sbyte Dead = 1;

	/// <summary>
	/// 已死亡且已被删除
	/// </summary>
	public const sbyte DeadAndRemoved = 2;
}
