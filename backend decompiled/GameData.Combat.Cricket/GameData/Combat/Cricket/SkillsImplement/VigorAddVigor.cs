namespace GameData.Combat.Cricket.SkillsImplement;

public class VigorAddVigor : DamageAddProperty
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.VigorAddVigor;

	protected override ECricketCombatDamageType DamageType => ECricketCombatDamageType.Vigor;

	protected override ECricketCombatPropertyType PropertyType => ECricketCombatPropertyType.Vigor;

	public VigorAddVigor(CricketCombatData owner)
		: base(owner)
	{
	}
}
