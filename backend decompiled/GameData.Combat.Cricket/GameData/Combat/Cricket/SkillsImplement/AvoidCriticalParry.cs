namespace GameData.Combat.Cricket.SkillsImplement;

public class AvoidCriticalParry : CricketCombatSkillBase
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.AvoidCriticalParry;

	public AvoidCriticalParry(CricketCombatData owner)
		: base(owner)
	{
	}

	public override ECricketCombatSkillPriority GetPriority(ECricketCombatSkillEvent @event)
	{
		return ECricketCombatSkillPriority.AvoidCriticalParry;
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event switch
		{
			ECricketCombatSkillEvent.CheckCritical => context.Defender != Owner, 
			ECricketCombatSkillEvent.CheckParry => context.Attacker != Owner, 
			_ => true, 
		} || !context.CheckResult || !context.Bridge.CheckPercentProb(66))
		{
			return false;
		}
		ShowEffectTips(context);
		return true;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		context.CheckResult = false;
	}
}
