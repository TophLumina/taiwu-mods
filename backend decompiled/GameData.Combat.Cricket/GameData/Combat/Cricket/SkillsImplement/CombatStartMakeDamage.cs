using GameData.Combat.Math;

namespace GameData.Combat.Cricket.SkillsImplement;

public class CombatStartMakeDamage(CricketCombatData owner) : CricketCombatSkillBase(owner)
{
	private readonly CValueFraction _fraction = new CValueFraction(1, 3, roundUp: true);

	public override ECricketCombatSkillType Type => ECricketCombatSkillType.CombatStartMakeDamage;

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.CombatStart)
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
			CricketCombatData enemy = context.TopContext.GetOther(Owner);
			CricketCombatDamage damage = CricketCombatDamage.Create(ECricketCombatDamageType.Skill);
			damage.Hp += enemy.MaxHp * _fraction;
			damage.Sp += enemy.MaxSp * _fraction;
			context.TopContext.DoDamage(Owner, enemy, ECricketCombatDamageType.Skill, damage);
		}
	}
}
