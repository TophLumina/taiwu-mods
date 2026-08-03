namespace GameData.Combat.Cricket.SkillsImplement;

public class CounterAddStrength : DamageAddProperty
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.CounterAddStrength;

	protected override ECricketCombatDamageType DamageType => ECricketCombatDamageType.Strength;

	protected override ECricketCombatPropertyType PropertyType => ECricketCombatPropertyType.Strength;

	public CounterAddStrength(CricketCombatData owner)
		: base(owner)
	{
	}
}
