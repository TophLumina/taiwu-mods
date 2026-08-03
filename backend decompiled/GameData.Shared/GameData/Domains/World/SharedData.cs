namespace GameData.Domains.World;

public static class SharedData
{
	/// <summary>
	/// 神木影响范围
	/// </summary>
	public const short HeavenlyTreeInfluenceRange = 3;

	/// <summary>
	/// 神木触发过月事件的生长值阈值
	/// </summary>
	public const short WudangHeavenlyTreeGrowthPoisonThreshold = 900;

	/// <summary>
	/// 神木涤秽，给人物增加的年龄
	/// </summary>
	public const int WudangHeavenlyTreeClearEnemyIncreaseCharAge = 3;

	/// <summary>
	/// 神木培育消耗的精力
	/// </summary>
	public const int WudangHeavenlyTreeFeedCostActionPoint = 100;

	/// <summary>
	/// 神木培育消耗资源的最小值
	/// </summary>
	public const int WudangHeavenlyTreeFeedCostMinResource = 100;

	/// <summary>
	/// 读书增加神木的成长值
	/// </summary>
	public const short ReadBookAddHeavenlyTreeGrowPoint = 100;
}
