namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerJingang : LegacyPower
{
	protected override short CombatStateId => 236;

	protected override sbyte OrgTemplateId => 11;

	public LegacyPowerJingang(int charId)
		: base(charId)
	{
	}
}
