using System.Collections.Generic;

namespace GameData.Domains.TaiwuEvent.Enum;

public static class ConfigMonthlyActionDefines
{
	public static readonly Dictionary<sbyte, short> OrgTemplateIdToContestForTaiwuBride = new Dictionary<sbyte, short>
	{
		{ 1, 31 },
		{ 2, 32 },
		{ 3, 33 },
		{ 4, 34 },
		{ 5, 35 },
		{ 6, 36 },
		{ 7, 37 },
		{ 8, 38 },
		{ 9, 39 },
		{ 10, 40 },
		{ 11, 41 },
		{ 12, 42 },
		{ 13, 43 },
		{ 14, 44 },
		{ 15, 45 }
	};

	public static readonly Dictionary<sbyte, short> CombatSkillTypeToMonthlyAction = new Dictionary<sbyte, short>
	{
		{ 3, 62 },
		{ 4, 63 },
		{ 5, 64 },
		{ 6, 65 },
		{ 7, 66 },
		{ 8, 67 },
		{ 9, 68 },
		{ 10, 69 },
		{ 11, 70 },
		{ 12, 71 },
		{ 13, 72 }
	};

	public static readonly Dictionary<short, sbyte> MonthlyActionToLifeSkillType = new Dictionary<short, sbyte>
	{
		{ 74, 6 },
		{ 75, 7 },
		{ 76, 10 },
		{ 77, 11 },
		{ 78, 8 },
		{ 79, 9 },
		{ 80, 14 }
	};
}
