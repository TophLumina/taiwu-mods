using System.Collections.Generic;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.Character.ParallelModifications;

public class PracticeAndBreakoutModification
{
	public Character Character;

	public List<CombatSkillInitialBreakoutData> BrokenOutCombatSkills;

	public List<GameData.Domains.CombatSkill.CombatSkill> FailedToBreakoutCombatSkills;

	public int NewExp;

	public Injuries NewInjuries;

	public short NewDisorderOfQi;

	public bool PersonalNeedsChanged;

	public PracticeAndBreakoutModification(Character character)
	{
		Character = character;
	}
}
