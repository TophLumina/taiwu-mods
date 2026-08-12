namespace GameData.Combat.Cricket;

public class CricketCombatLogSkill : CricketCombatLog
{
	public readonly CricketCombatSkillBase Skill;

	public CricketCombatLogSkill(CricketCombatSkillBase skill)
		: base(ECricketCombatLogEventType.Skill)
	{
		Skill = skill;
	}

	public override string ToString()
	{
		return base.ToString() + $"->{{{Skill}}}";
	}
}
