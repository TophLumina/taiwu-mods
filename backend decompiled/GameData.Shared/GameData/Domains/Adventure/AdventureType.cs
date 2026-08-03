using System;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇类型
/// </summary>
[Obsolete("Use Config.AdventureType instead.")]
public static class AdventureType
{
	/// <summary>
	/// 无类型
	/// </summary>
	public const sbyte None = 0;

	/// <summary>
	/// 外道巢穴
	/// </summary>
	public const sbyte EnemyNest = 1;

	/// <summary>
	/// 比武招亲
	/// </summary>
	public const sbyte ContestForBride = 2;

	/// <summary>
	/// 食材
	/// </summary>
	public const sbyte ResourceFood = 3;

	/// <summary>
	/// 木材
	/// </summary>
	public const sbyte ResourceWood = 4;

	/// <summary>
	/// 金铁
	/// </summary>
	public const sbyte ResourceMetal = 5;

	/// <summary>
	/// 玉石
	/// </summary>
	public const sbyte ResourceJade = 6;

	/// <summary>
	/// 织物
	/// </summary>
	public const sbyte ResourceFabric = 7;

	/// <summary>
	/// 药材
	/// </summary>
	public const sbyte ResourceHerb = 8;

	/// <summary>
	/// 主线
	/// </summary>
	public const sbyte MainStoryLine = 9;

	/// <summary>
	/// 地区主线
	/// </summary>
	public const sbyte RegionalMainStoryLine = 10;

	/// <summary>
	/// 剑冢
	/// </summary>
	public const sbyte SwordTomb = 11;

	/// <summary>
	/// 总数
	/// </summary>
	public const int Count = 12;

	/// <summary>
	/// 第一个天材地宝奇遇
	/// </summary>
	public const sbyte MaterialResourceAdventureBegin = 3;

	/// <summary>
	/// 最后一个天材地宝奇遇
	/// </summary>
	public const sbyte MaterialResourceAdventureEnd = 8;

	/// <summary>
	/// 是否为可被覆盖的非关键奇遇类型.
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	[Obsolete("Use AdventureTypeItem.IsTrivial instead.")]
	public static bool IsTrivial(short type)
	{
		if (type != 11 && type != 10)
		{
			return type != 9;
		}
		return false;
	}
}
