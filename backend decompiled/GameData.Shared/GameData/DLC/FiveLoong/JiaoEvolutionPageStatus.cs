namespace GameData.DLC.FiveLoong;

/// <summary>
/// 蛟池化龙页面能否打开的状态
/// </summary>
public class JiaoEvolutionPageStatus
{
	/// <summary>
	/// 可打开页面
	/// </summary>
	public const sbyte Ok = 0;

	/// <summary>
	/// 太吾不在村里
	/// </summary>
	public const sbyte NotInTaiwuVillage = 1;

	/// <summary>
	/// 没有可进化的蛟
	/// </summary>
	public const sbyte NotEnoughJiao = 2;
}
