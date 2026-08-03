namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class HandCrash : HandBreakBase
{
	public HandCrash()
	{
	}

	public HandCrash(int charId)
		: base(charId, 15506)
	{
		IsInner = false;
		FeatureId = 206;
	}
}
