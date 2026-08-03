using Config;
using GameData.Domains.Item;

namespace GameData.Domains.Combat;

public static class WugReplaceTypeHelper
{
	public static bool IsMatchWug(this EWugReplaceType replaceType, short wugTemplateId, short targetWugTemplateId = -1)
	{
		switch (replaceType)
		{
		case EWugReplaceType.All:
			return true;
		case EWugReplaceType.None:
			return false;
		default:
		{
			if ((replaceType & EWugReplaceType.Nonexistent) != EWugReplaceType.None && wugTemplateId == targetWugTemplateId)
			{
				return false;
			}
			sbyte existWugGrowthType = Config.Medicine.Instance[wugTemplateId].WugGrowthType;
			if ((replaceType & EWugReplaceType.CombatOnly) != EWugReplaceType.None && !WugGrowthType.IsWugGrowthTypeCombatOnly(existWugGrowthType))
			{
				return false;
			}
			return (replaceType & EWugReplaceType.Ungrown) == 0 || existWugGrowthType != 4;
		}
		}
	}
}
