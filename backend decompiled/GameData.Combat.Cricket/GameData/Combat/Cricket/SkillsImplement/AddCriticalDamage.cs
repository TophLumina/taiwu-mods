namespace GameData.Combat.Cricket.SkillsImplement;

public class AddCriticalDamage : CricketCombatSkillBase
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.AddCriticalDamage;

	public AddCriticalDamage(CricketCombatData owner)
		: base(owner)
	{
	}

	public override ECricketCombatSkillPriority GetPriority(ECricketCombatSkillEvent @event)
	{
		return ECricketCombatSkillPriority.AddCriticalDamage;
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.CheckCritical || context.CheckResult || context.Attacker != Owner)
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
		AddModify(context, ECricketCombatPropertyModifyLifeCycle.Combat, ECricketCombatPropertyType.Damage, 10);
	}
}
