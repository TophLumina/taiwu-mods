using Config;
using GameData.Utilities;

namespace GameData.Domains.Organization;

public static class SettlementPrisonEventEffectHelper
{
	public static int CalcChangeFavorGuardCount(this SettlementPrisonEventEffectItem effectCfg, int totalCount)
	{
		int rate = effectCfg.ChangeFavorGuardBaseRate;
		return MathUtils.Clamp(totalCount * rate / 100, effectCfg.MinAffectedGuardCount, totalCount);
	}

	public static int CalcChangeFavorMemberCount(this SettlementPrisonEventEffectItem effectCfg, int totalCount)
	{
		int rate = effectCfg.ChangeFavorMemberBaseRate;
		return MathUtils.Clamp(totalCount * rate / 100, effectCfg.MinAffectedMemberCount, totalCount);
	}

	public static int CalcGuardDisapproveCount(this SettlementPrisonEventEffectItem effectCfg, int affectedCount)
	{
		return affectedCount * effectCfg.GuardDisapproveRate / 100;
	}

	public static int CalcGuardApproveCount(this SettlementPrisonEventEffectItem effectCfg, int affectedCount)
	{
		return affectedCount * effectCfg.GuardApproveRate / 100;
	}

	public static int CalcMemberDisapproveCount(this SettlementPrisonEventEffectItem effectCfg, int affectedCount)
	{
		return affectedCount * effectCfg.MemberDisapproveRate / 100;
	}

	public static int CalcMemberApproveCount(this SettlementPrisonEventEffectItem effectCfg, int affectedCount)
	{
		return affectedCount * effectCfg.MemberApproveRate / 100;
	}

	public static int CalcGuardBecomeEnemyCount(this SettlementPrisonEventEffectItem effectCfg, int affectedCount)
	{
		return affectedCount * effectCfg.GuardBecomeEnemyRate / 100;
	}

	public static int CalcMemberBecomeEnemyCount(this SettlementPrisonEventEffectItem effectCfg, int affectedCount)
	{
		return affectedCount * effectCfg.MemberBecomeEnemyRate / 100;
	}
}
