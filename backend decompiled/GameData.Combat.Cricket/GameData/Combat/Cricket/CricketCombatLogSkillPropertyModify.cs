namespace GameData.Combat.Cricket;

public class CricketCombatLogSkillPropertyModify : CricketCombatLog
{
	public readonly CricketCombatSkillBase Skill;

	public readonly CricketCombatData Target;

	public readonly CricketCombatSkillPropertyModify Modify;

	public CricketCombatLogSkillPropertyModify(CricketCombatSkillBase skill, CricketCombatData target, CricketCombatSkillPropertyModify modify)
		: base(ECricketCombatLogEventType.SkillPropertyModify)
	{
		Skill = skill;
		Target = target;
		Modify = modify;
	}

	public override string ToString()
	{
		return base.ToString() + $"->{{{Skill}->{Target}->{Modify}}}";
	}
}
