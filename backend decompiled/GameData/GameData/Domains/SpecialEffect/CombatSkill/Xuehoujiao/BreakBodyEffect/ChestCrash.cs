namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class ChestCrash : ChestBreakBase
{
	public ChestCrash()
	{
	}

	public ChestCrash(int charId)
		: base(charId, 15500)
	{
		IsInner = false;
		FeatureId = 202;
	}
}
