namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerWuxian : LegacyPower
{
	protected override short CombatStateId => 237;

	protected override sbyte OrgTemplateId => 12;

	public LegacyPowerWuxian(int charId)
		: base(charId)
	{
	}
}
