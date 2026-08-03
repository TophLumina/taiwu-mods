namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class HeadHurt : HeadBreakBase
{
	public HeadHurt()
	{
	}

	public HeadHurt(int charId)
		: base(charId, 15505)
	{
		IsInner = true;
		FeatureId = 199;
	}
}
