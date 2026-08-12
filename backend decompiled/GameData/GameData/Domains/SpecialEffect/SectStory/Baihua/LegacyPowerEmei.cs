namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerEmei : LegacyPower
{
	protected override short CombatStateId => 227;

	protected override sbyte OrgTemplateId => 2;

	public LegacyPowerEmei(int charId)
		: base(charId)
	{
	}
}
