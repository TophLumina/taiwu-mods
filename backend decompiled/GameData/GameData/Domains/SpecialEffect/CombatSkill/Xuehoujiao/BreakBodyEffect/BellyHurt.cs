namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class BellyHurt : BellyBreakBase
{
	public BellyHurt()
	{
	}

	public BellyHurt(int charId)
		: base(charId, 15503)
	{
		IsInner = true;
		FeatureId = 203;
	}
}
