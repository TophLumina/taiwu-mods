namespace GameData.Combat.Cricket.SkillsImplement;

public class ParryMakeDamage : CricketCombatSkillBase
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.ParryMakeDamage;

	public ParryMakeDamage(CricketCombatData owner)
		: base(owner)
	{
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.DoDamage || context.Defender != Owner)
		{
			return false;
		}
		if (!context.Status.HasValue || !context.Status.Value.Contains(ECricketCombatAttackStatus.Parry))
		{
			return false;
		}
		if (!context.Bridge.CheckPercentProb(50))
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
			damage.Hp = Owner.Bite;
			damage.Sp = Owner.Vigor;
			CricketCombatData enemy = context.TopContext.GetOther(Owner);
			context.TopContext.DoDamage(Owner, enemy, ECricketCombatDamageType.Skill, damage);
		}
	}
}
