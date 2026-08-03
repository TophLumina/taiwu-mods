namespace GameData.Domains.Character;

/// <summary>
/// 角色的存活状态
/// </summary>
public class AliveState
{
	/// <summary>
	/// 存活
	/// </summary>
	public const sbyte Alive = 0;

	/// <summary>
	/// 死亡
	/// </summary>
	public const sbyte Dead = 1;

	/// <summary>
	/// 已移除
	/// </summary>
	public const sbyte Removed = 2;
}
