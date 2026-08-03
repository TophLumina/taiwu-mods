namespace GameData.Domains.Global;

/// <summary>
/// 梦回解锁状态标记类型
/// </summary>
public static class DreamBackUnlockStateType
{
	/// <summary>
	/// 基础数据
	/// </summary>
	public const sbyte Basic = 0;

	/// <summary>
	/// 物品数据
	/// </summary>
	public const sbyte Item = 1;

	/// <summary>
	/// 功法数据
	/// </summary>
	public const sbyte CombatSkill = 2;

	/// <summary>
	/// 技艺数据
	/// </summary>
	public const sbyte LifeSkill = 3;

	/// <summary>
	/// 产业数据
	/// </summary>
	public const sbyte Building = 4;

	/// <summary>
	/// 志向数据
	/// </summary>
	public const sbyte Profession = 5;

	/// <summary>
	/// 精纯数据
	/// </summary>
	public const sbyte ConsummateLevel = 6;

	/// <summary>
	/// 全部解锁
	/// </summary>
	public const ulong All = 17895697uL;
}
