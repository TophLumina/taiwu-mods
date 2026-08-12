namespace GameData.Domains.Combat;

/// <summary>
/// 终结技选项
/// </summary>
public enum EShowMercyOption : sbyte
{
	/// <summary>
	/// 不显示
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 玩家选择
	/// </summary>
	PlayerShowMercy,
	/// <summary>
	/// 敌人选择
	/// </summary>
	EnemyShowMercy,
	/// <summary>
	/// 伏虞剑柄
	/// </summary>
	FuyuSword
}
