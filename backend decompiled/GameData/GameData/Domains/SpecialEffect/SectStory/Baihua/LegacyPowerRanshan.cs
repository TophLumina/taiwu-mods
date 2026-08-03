namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerRanshan : LegacyPower
{
	protected override short CombatStateId => 232;

	protected override sbyte OrgTemplateId => 7;

	public LegacyPowerRanshan(int charId)
		: base(charId)
	{
	}
}
