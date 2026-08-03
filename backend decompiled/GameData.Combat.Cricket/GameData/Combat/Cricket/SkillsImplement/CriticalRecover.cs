namespace GameData.Combat.Cricket.SkillsImplement;

public class CriticalRecover : CricketCombatSkillBase
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.CriticalRecover;

	public CriticalRecover(CricketCombatData owner)
		: base(owner)
	{
	}

	public override ECricketCombatSkillPriority GetPriority(ECricketCombatSkillEvent @event)
	{
		return ECricketCombatSkillPriority.CriticalRecover;
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.CheckDamage || context.Attacker != Owner || !context.Damage.HasValue)
		{
			return false;
		}
		CricketCombatDamage? damage = context.Damage;
		if (damage.HasValue)
		{
			CricketCombatDamage valueOrDefault = damage.GetValueOrDefault();
			if (valueOrDefault.Hp <= 0 && valueOrDefault.Sp <= 0)
			{
				return false;
			}
		}
		if (!context.Status.HasValue || !context.Status.Value.Contains(ECricketCombatAttackStatus.Critical))
		{
			return false;
		}
		ShowEffectTips(context);
		return true;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (context.TopContext != null && context.Damage.HasValue)
		{
			CricketCombatDamage damage = CricketCombatDamage.Create(ECricketCombatDamageType.Skill);
			if (context.Damage.Value.Hp > 0)
			{
				damage.Hp -= context.Damage.Value.Hp;
			}
			if (context.Damage.Value.Sp > 0)
			{
				damage.Sp -= context.Damage.Value.Sp;
			}
			context.TopContext.DoDamage(Owner, Owner, ECricketCombatDamageType.Skill, damage);
		}
	}
}
