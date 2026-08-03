namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class LegCrash : LegBreakBase
{
	public LegCrash()
	{
	}

	public LegCrash(int charId)
		: base(charId, 15508)
	{
		IsInner = false;
		FeatureId = 208;
	}
}
