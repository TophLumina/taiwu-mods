using GameData.Combat.Cricket.SkillsImplement;

namespace GameData.Combat.Cricket;

public static class CricketCombatSkillFactory
{
	public static CricketCombatSkillBase? Create(CricketCombatData owner)
	{
		return owner.Skill switch
		{
			ECricketCombatSkillType.ExtraWager => new ExtraWager(owner), 
			ECricketCombatSkillType.HalfFallenCritical => new HalfFallenCritical(owner), 
			ECricketCombatSkillType.AdvanceParry => new AdvanceParry(owner), 
			ECricketCombatSkillType.NormalAttackAlwaysVigor => new NormalAttackAlwaysVigor(owner), 
			ECricketCombatSkillType.AvoidCriticalParry => new AvoidCriticalParry(owner), 
			ECricketCombatSkillType.AddCriticalDamage => new AddCriticalDamage(owner), 
			ECricketCombatSkillType.RoundStartMakeDamage => new RoundStartMakeDamage(owner), 
			ECricketCombatSkillType.CounterDoubleDamage => new CounterDoubleDamage(owner), 
			ECricketCombatSkillType.CombatStartMakeDamage => new CombatStartMakeDamage(owner), 
			ECricketCombatSkillType.AcceptDamageRecover => new AcceptDamageRecover(owner), 
			ECricketCombatSkillType.CounterAddStrength => new CounterAddStrength(owner), 
			ECricketCombatSkillType.MutualDamage => new MutualDamage(owner), 
			ECricketCombatSkillType.AttackAddBite => new AttackAddBite(owner), 
			ECricketCombatSkillType.ParryMakeDamage => new ParryMakeDamage(owner), 
			ECricketCombatSkillType.HalfFallenAddProperty => new HalfFallenAddProperty(owner), 
			ECricketCombatSkillType.RoundStartAddProperty => new RoundStartAddProperty(owner), 
			ECricketCombatSkillType.CriticalRecover => new CriticalRecover(owner), 
			ECricketCombatSkillType.VigorAddVigor => new VigorAddVigor(owner), 
			ECricketCombatSkillType.PreventSkill => new PreventSkill(owner), 
			ECricketCombatSkillType.RoundStartReduceProperty => new RoundStartReduceProperty(owner), 
			ECricketCombatSkillType.LoopCriticalParry => new LoopCriticalParry(owner), 
			ECricketCombatSkillType.BeHitAddProperty => new BeHitAddProperty(owner), 
			_ => null, 
		};
	}
}
