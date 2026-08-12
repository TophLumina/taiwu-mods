namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerZhujian : LegacyPower
{
	protected override short CombatStateId => 234;

	protected override sbyte OrgTemplateId => 9;

	public LegacyPowerZhujian(int charId)
		: base(charId)
	{
	}
}
