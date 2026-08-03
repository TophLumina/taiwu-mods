namespace GameData.Combat.Cricket.SkillsImplement;

public class ExtraWager : CricketCombatSkillBase
{
	public bool Invoked;

	public override ECricketCombatSkillType Type => ECricketCombatSkillType.ExtraWager;

	public ExtraWager(CricketCombatData owner)
		: base(owner)
	{
	}

	public override ECricketCombatSkillPriority GetPriority(ECricketCombatSkillEvent @event)
	{
		return ECricketCombatSkillPriority.ExtraWager;
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event == ECricketCombatSkillEvent.CombatEnd)
		{
			return context.Winner != Owner;
		}
		return false;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		Invoked = true;
		ShowEffectTips(context);
	}
}
