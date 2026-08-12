namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerJieqing : LegacyPower
{
	protected override short CombatStateId => 238;

	protected override sbyte OrgTemplateId => 13;

	public LegacyPowerJieqing(int charId)
		: base(charId)
	{
	}
}
