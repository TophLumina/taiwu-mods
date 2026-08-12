namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class HeadCrash : HeadBreakBase
{
	public HeadCrash()
	{
	}

	public HeadCrash(int charId)
		: base(charId, 15504)
	{
		IsInner = false;
		FeatureId = 200;
	}
}
