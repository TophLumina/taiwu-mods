namespace GameData.Combat.Cricket.SkillsImplement;

public class NormalAttackAlwaysVigor : CricketCombatSkillBase
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.NormalAttackAlwaysVigor;

	public NormalAttackAlwaysVigor(CricketCombatData owner)
		: base(owner)
	{
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.ExtraVigor || context.DamageType != ECricketCombatDamageType.Bite)
		{
			return false;
		}
		if (context.CheckResult || context.Attacker != Owner)
		{
			return false;
		}
		ShowEffectTips(context);
		return true;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		context.CheckResult = true;
	}
}
