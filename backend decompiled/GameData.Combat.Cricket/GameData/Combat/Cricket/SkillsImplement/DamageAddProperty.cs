namespace GameData.Combat.Cricket.SkillsImplement;

public abstract class DamageAddProperty : CricketCombatSkillBase
{
	protected abstract ECricketCombatDamageType DamageType { get; }

	protected abstract ECricketCombatPropertyType PropertyType { get; }

	protected DamageAddProperty(CricketCombatData owner)
		: base(owner)
	{
	}

	public sealed override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.DoDamage || context.DamageType != DamageType)
		{
			return false;
		}
		ShowEffectTips(context);
		return true;
	}

	public sealed override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		AddModify(context, ECricketCombatPropertyModifyLifeCycle.Combat, PropertyType, 6);
	}
}
