namespace Config.ConfigCells.Character;

/// <summary>
/// 特性增加功法威力
/// </summary>
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
