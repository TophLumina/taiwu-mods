namespace GameData.Combat.Cricket.SkillsImplement;

public class RoundStartAddProperty : CricketCombatSkillBase
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.RoundStartAddProperty;

	public RoundStartAddProperty(CricketCombatData owner)
		: base(owner)
	{
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.RoundStart || !context.Bridge.CheckPercentProb(66))
		{
			return false;
		}
		ShowEffectTips(context);
		return true;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		AddModifyPercent(context, ECricketCombatPropertyModifyLifeCycle.Round, context.Bridge.Next(3) switch
		{
			0 => ECricketCombatPropertyType.Vigor, 
			1 => ECricketCombatPropertyType.Strength, 
			2 => ECricketCombatPropertyType.Bite, 
			_ => ECricketCombatPropertyType.Invalid, 
		}, 100);
	}
}
