namespace GameData.Combat.Cricket;

public class CricketCombatLogDamage : CricketCombatLog
{
	public readonly CricketCombatData Attacker;

	public readonly CricketCombatData Defender;

	public readonly CricketCombatDamage Damage;

	public readonly ECricketCombatDamageType DamageType;

	public readonly ECricketCombatAttackStatus AttackStatus;

	public CricketCombatLogDamage(CricketCombatData attacker, CricketCombatData defender, CricketCombatDamage damage, ECricketCombatDamageType damageType, ECricketCombatAttackStatus attackStatus)
		: base(ECricketCombatLogEventType.Damage)
	{
		Attacker = attacker;
		Defender = defender;
		DamageType = damageType;
		Damage = damage;
		AttackStatus = attackStatus;
	}

	public override string ToString()
	{
		return base.ToString() + $"->{{{Attacker}->{Defender}->{DamageType}->{AttackStatus}->{Damage}}}";
	}
}
