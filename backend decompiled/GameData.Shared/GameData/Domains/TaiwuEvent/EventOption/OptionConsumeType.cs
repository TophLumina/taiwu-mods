using System;

namespace GameData.Domains.TaiwuEvent.EventOption;

/// <summary>
/// 条件对资源的消耗
/// </summary>
[Obsolete("Use Config.EventOptionConsumeType.DefKey instead.")]
public class OptionConsumeType
{
	/// <summary>
	/// 食材
	/// </summary>
	public const sbyte Food = 0;

	/// <summary>
	/// 木材
	/// </summary>
	public const sbyte Wood = 1;

	/// <summary>
	/// 金铁
	/// </summary>
	public const sbyte Metal = 2;

	/// <summary>
	/// 玉石
	/// </summary>
	public const sbyte Jade = 3;

	/// <summary>
	/// 织物
	/// </summary>
	public const sbyte Fabric = 4;

	/// <summary>
	/// 药材
	/// </summary>
	public const sbyte Herb = 5;

	/// <summary>
	/// 银钱
	/// </summary>
	public const sbyte Money = 6;

	/// <summary>
	/// 威望
	/// </summary>
	public const sbyte Authority = 7;

	/// <summary>
	/// 行动力
	/// </summary>
	public const int MovePoint = 8;

	/// <summary>
	/// 目标人物所属地区恩义
	/// </summary>
	public const sbyte SpiritualDebt = 9;

	/// <summary>
	/// 太吾当前所在地区的恩义
	/// </summary>
	public const sbyte SpiritualDebtInCurrentArea = 10;

	/// <summary>
	/// 总个数
	/// </summary>
	public const int Count = 11;
}
