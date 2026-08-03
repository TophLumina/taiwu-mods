namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class BellyCrash : BellyBreakBase
{
	public BellyCrash()
	{
	}

	public BellyCrash(int charId)
		: base(charId, 15502)
	{
		IsInner = false;
		FeatureId = 204;
	}
}
