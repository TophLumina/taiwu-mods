namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class HandHurt : HandBreakBase
{
	public HandHurt()
	{
	}

	public HandHurt(int charId)
		: base(charId, 15507)
	{
		IsInner = true;
		FeatureId = 205;
	}
}
