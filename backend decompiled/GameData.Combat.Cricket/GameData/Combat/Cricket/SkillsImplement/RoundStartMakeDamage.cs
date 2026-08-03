using GameData.Combat.Math;

namespace GameData.Combat.Cricket.SkillsImplement;

public class RoundStartMakeDamage(CricketCombatData owner) : CricketCombatSkillBase(owner)
{
	private readonly CValueFraction _fraction = new CValueFraction(150, 100, roundUp: true);

	public override ECricketCombatSkillType Type => ECricketCombatSkillType.RoundStartMakeDamage;

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.RoundStart)
		{
			return false;
		}
		ShowEffectTips(context);
		return true;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (context.TopContext != null)
		{
			CricketCombatDamage damage = CricketCombatDamage.Create(ECricketCombatDamageType.Skill);
			damage.Hp = context.TopContext.Round * _fraction;
			damage.Sp = context.TopContext.Round * _fraction;
			CricketCombatData enemy = context.TopContext.GetOther(Owner);
			context.TopContext.DoDamage(Owner, enemy, ECricketCombatDamageType.Skill, damage);
		}
	}
}
