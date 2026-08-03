using GameData.Domains.Character;

namespace GameData.Domains.Combat;

public readonly struct CombatProperty
{
	public int HitValue { get; init; }

	public int AvoidValue { get; init; }

	public OuterAndInnerInts AttackValue { get; init; }

	public OuterAndInnerInts DefendValue { get; init; }

	public int WeaponAttack { get; init; }

	public int WeaponDefend { get; init; }

	public int ArmorAttack { get; init; }

	public int ArmorDefend { get; init; }

	public bool IsValid => HitValue >= 0;

	public int HitOdds => CFormula.FormulaCalcHitOdds(HitValue, AvoidValue);

	public static CombatProperty Create(CombatContext context, sbyte hitType)
	{
		return new CombatProperty
		{
			HitValue = context.Attacker.GetHitValue(context, hitType),
			AvoidValue = context.Defender.GetAvoidValue(context, hitType),
			AttackValue = context.Attacker.GetPenetrate(context),
			DefendValue = context.Defender.GetPenetrateResist(context),
			WeaponAttack = CombatDomain.CalcWeaponAttack(context.Attacker, context.Weapon, context.SkillTemplateId),
			WeaponDefend = CombatDomain.CalcWeaponDefend(context.Attacker, context.Weapon, context.SkillTemplateId),
			ArmorAttack = CombatDomain.CalcArmorAttack(context.Defender, context.Armor),
			ArmorDefend = CombatDomain.CalcArmorDefend(context.Defender, context.Armor)
		};
	}
}
