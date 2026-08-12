namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class ChestHurt : ChestBreakBase
{
	public ChestHurt()
	{
	}

	public ChestHurt(int charId)
		: base(charId, 15501)
	{
		IsInner = true;
		FeatureId = 201;
	}
}
