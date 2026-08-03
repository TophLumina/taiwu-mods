namespace GameData.Combat.Cricket.SkillsImplement;

public class AttackAddBite : DamageAddProperty
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.AttackAddBite;

	protected override ECricketCombatDamageType DamageType => ECricketCombatDamageType.Bite;

	protected override ECricketCombatPropertyType PropertyType => ECricketCombatPropertyType.Bite;

	public AttackAddBite(CricketCombatData owner)
		: base(owner)
	{
	}
}
