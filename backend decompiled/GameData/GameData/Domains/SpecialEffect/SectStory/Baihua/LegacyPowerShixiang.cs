namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerShixiang : LegacyPower
{
	protected override short CombatStateId => 231;

	protected override sbyte OrgTemplateId => 6;

	public LegacyPowerShixiang(int charId)
		: base(charId)
	{
	}
}
