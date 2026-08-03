namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class LegHurt : LegBreakBase
{
	public LegHurt()
	{
	}

	public LegHurt(int charId)
		: base(charId, 15509)
	{
		IsInner = true;
		FeatureId = 207;
	}
}
