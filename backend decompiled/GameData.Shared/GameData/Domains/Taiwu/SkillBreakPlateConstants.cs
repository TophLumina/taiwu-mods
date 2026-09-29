using System.Collections.Generic;
using GameData.Domains.Item;

namespace GameData.Domains.Taiwu;

public static class SkillBreakPlateConstants
{
	public const int MaxProficiency = 999999999;

	public const int ProficiencyRequirement = 300;

	public static readonly int[] AvailableImpactRanges = new int[3] { 1, 2, 3 };

	public static IReadOnlyList<int> ExpLevelValues => GlobalConfig.BreakoutBonusExpLevelValues;

	public static IReadOnlyList<int> ExpEffectValues => GlobalConfig.BreakoutBonusExpEffectValues;

	public static IReadOnlyList<int> FriendLevelValues => GlobalConfig.BreakoutBonusFriendFavorabilityTypeValues;

	public static int FriendAddPowerBase => 1;

	public static int FriendAddPowerDivisor => 10000;

	public static int FriendAddPowerExtraMin => 0;

	public static int FriendAddPowerExtraMax => 9;

	public static int FriendGradeDivisor => 50;

	public static int FriendGradeMinus => 1;

	public static bool IsBonusItem(sbyte itemType, short templateId)
	{
		return ItemTemplateHelper.GetBreakBonusEffect(itemType, templateId) >= 0;
	}
}
