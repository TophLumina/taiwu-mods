namespace GameData.Combat.Cricket.SkillsImplement;

public class PreventSkill : CricketCombatSkillBase
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.PreventSkill;

	public PreventSkill(CricketCombatData owner)
		: base(owner)
	{
	}

	public override ECricketCombatSkillPriority GetPriority(ECricketCombatSkillEvent @event)
	{
		return ECricketCombatSkillPriority.PreventSkill;
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (context.FirstSkill == this && context.SecondSkillPrechecked)
		{
			return context.Bridge.CheckPercentProb(50);
		}
		return false;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		context.SecondSkillPrechecked = false;
		ShowEffectTips(context);
	}
}
