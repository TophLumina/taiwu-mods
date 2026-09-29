namespace Config.ConfigCells.Character;

public class FeatureAddSkillPower
{
	public sbyte CombatSkillType { get; }

	public int AddValue { get; }

	public FeatureAddSkillPower(sbyte combatSkillType, int addValue)
	{
		CombatSkillType = combatSkillType;
		AddValue = addValue;
	}
}
