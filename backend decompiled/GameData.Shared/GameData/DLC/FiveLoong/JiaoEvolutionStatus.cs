namespace GameData.DLC.FiveLoong;

/// <summary>
/// 蛟模拟化形结果的状态
/// </summary>
public class JiaoEvolutionStatus
{
	/// <summary>
	/// 可继续随机
	/// </summary>
	public const sbyte Ok = 0;

	/// <summary>
	/// 仅有一个选择
	/// </summary>
	public const sbyte OnlyOneChoice = 1;

	/// <summary>
	/// 随机结果为此前未拥有过的龙子
	/// </summary>
	public const sbyte FirstTimeOwn = 2;

	/// <summary>
	/// 龙鳞不足
	/// </summary>
	public const sbyte NotEnoughLoongScale = 3;
}
