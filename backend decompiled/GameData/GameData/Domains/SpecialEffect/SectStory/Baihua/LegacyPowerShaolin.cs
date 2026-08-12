namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerShaolin : LegacyPower
{
	protected override short CombatStateId => 226;

	protected override sbyte OrgTemplateId => 1;

	public LegacyPowerShaolin(int charId)
		: base(charId)
	{
	}
}
