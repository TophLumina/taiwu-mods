using System.Collections.Generic;
using GameData.Domains.Item;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 突破盘相关常量定义
/// </summary>
public static class SkillBreakPlateConstants
{
	/// <summary>
	/// 最大实战值
	/// </summary>
	public const int MaxProficiency = 999999999;

	/// <summary>
	/// 实战值需求
	/// </summary>
	public const int ProficiencyRequirement = 300;

	/// <summary>
	/// 有效的玄机格影响范围
	/// <see cref="P:GameData.Domains.Taiwu.SkillBreakPlateBonus.ImpactRange" /> 有调整时，需要同步修改此处定义
	/// </summary>
	public static readonly int[] AvailableImpactRanges = new int[3] { 1, 2, 3 };

	/// <summary>
	/// 索引为 ExpLevel，值为该档位的历练值
	/// </summary>
	public static IReadOnlyList<int> ExpLevelValues => GlobalConfig.BreakoutBonusExpLevelValues;

	/// <summary>
	/// 索引为 ExpLevel，值为该档位减少的使用需求
	/// </summary>
	public static IReadOnlyList<int> ExpEffectValues => GlobalConfig.BreakoutBonusExpEffectValues;

	/// <summary>
	/// 亲友类玄机各档位好感参数
	/// </summary>
	public static IReadOnlyList<int> FriendLevelValues => GlobalConfig.BreakoutBonusFriendFavorabilityTypeValues;

	/// <summary>
	/// 亲友类玄机基础威力加值
	/// </summary>
	public static int FriendAddPowerBase => 1;

	/// <summary>
	/// 亲友类玄机造诣威力加值除数
	/// </summary>
	public static int FriendAddPowerDivisor => 10000;

	/// <summary>
	/// 亲友类玄机造诣威力加值下限
	/// </summary>
	public static int FriendAddPowerExtraMin => 0;

	/// <summary>
	/// 亲友类玄机造诣威力加值上限
	/// </summary>
	public static int FriendAddPowerExtraMax => 9;

	/// <summary>
	/// 亲友类玄机造诣品级除数
	/// </summary>
	public static int FriendGradeDivisor => 50;

	/// <summary>
	/// 亲友类玄机造诣品级减数
	/// </summary>
	public static int FriendGradeMinus => 1;

	/// <summary>
	/// 是否为可放置于玄机格的道具
	/// </summary>
	public static bool IsBonusItem(sbyte itemType, short templateId)
	{
		return ItemTemplateHelper.GetBreakBonusEffect(itemType, templateId) >= 0;
	}
}
