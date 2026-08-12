using GameData.Utilities;

namespace GameData.Domains.Combat;

public static class CMath
{
	public static int ClampFatalMarkCount(int markCount)
	{
		return MathUtils.Clamp(markCount, 0, GlobalConfig.Instance.MaxFatalMarkCount);
	}

	public static (int markCount, int leftDamage) CalcMarkAndLeftDamage(int damage, int step, int maxMarkCount = -1)
	{
		step = MathUtils.Max(step, 1);
		int markCount = damage / step;
		markCount = ((maxMarkCount < 0) ? markCount : MathUtils.Min(markCount, maxMarkCount));
		int leftDamage = damage - markCount * step;
		return (markCount: markCount, leftDamage: leftDamage);
	}

	public static int SumPercentOdds(int baseOdds, int addOdds)
	{
		return (100 - baseOdds) * addOdds / 100;
	}
}
