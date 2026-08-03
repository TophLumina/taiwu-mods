namespace GameData.Combat.Cricket.SkillsImplement;

public class CounterDoubleDamage : CricketCombatSkillBase
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.CounterDoubleDamage;

	public CounterDoubleDamage(CricketCombatData owner)
		: base(owner)
	{
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.CheckDamage || context.DamageType != ECricketCombatDamageType.Strength)
		{
			return false;
		}
		if (context.Attacker == Owner)
		{
			CricketCombatDamage? damage = context.Damage;
			if (damage.HasValue && damage.GetValueOrDefault().IsNonZeroExceptInjury)
			{
				if (!context.Bridge.CheckPercentProb(50))
				{
					return false;
				}
				ShowEffectTips(context);
				return true;
			}
		}
		return false;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (context.Damage.HasValue)
		{
			CricketCombatDamage damage = context.Damage.Value;
			damage.Hp *= 2;
			damage.Sp *= 2;
			damage.Durability *= 2;
			context.Damage = damage;
		}
	}
}
