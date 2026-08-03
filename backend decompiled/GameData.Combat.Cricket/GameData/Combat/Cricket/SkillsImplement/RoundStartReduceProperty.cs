namespace GameData.Combat.Cricket.SkillsImplement;

public class RoundStartReduceProperty : CricketCombatSkillBase
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.RoundStartReduceProperty;

	public RoundStartReduceProperty(CricketCombatData owner)
		: base(owner)
	{
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.RoundStart || context.TopContext == null)
		{
			return false;
		}
		int odds = 0;
		CricketCombatData other = context.TopContext.GetOther(Owner);
		if (other.Vigor < Owner.Vigor)
		{
			odds += 20;
		}
		if (other.Strength < Owner.Strength)
		{
			odds += 20;
		}
		if (other.Bite < Owner.Bite)
		{
			odds += 20;
		}
		if (!context.Bridge.CheckPercentProb(odds))
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
			ECricketCombatPropertyType propertyType = context.Bridge.Next(3) switch
			{
				0 => ECricketCombatPropertyType.Deadliness, 
				1 => ECricketCombatPropertyType.Defense, 
				2 => ECricketCombatPropertyType.Counter, 
				_ => ECricketCombatPropertyType.Invalid, 
			};
			CricketCombatData enemy = context.TopContext.GetOther(Owner);
			AddModifyZero(context, ECricketCombatPropertyModifyLifeCycle.Round, enemy, propertyType);
		}
	}
}
