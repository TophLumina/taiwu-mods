namespace GameData.Combat.Cricket;

public class CricketCombatSkillContext
{
	public CricketCombatContext? TopContext;

	public CricketCombatData? Winner;

	public CricketCombatData? Attacker;

	public CricketCombatData? Defender;

	public ECricketCombatDamageType? DamageType;

	public ECricketCombatAttackStatus? Status;

	public CricketCombatDamage? Damage;

	public CricketCombatSkillBase? FirstSkill;

	public bool SecondSkillPrechecked;

	public bool CheckResult;

	public ICricketExternalBridge Bridge => TopContext?.Bridge ?? CricketExternalBridge.Bridge;
}
