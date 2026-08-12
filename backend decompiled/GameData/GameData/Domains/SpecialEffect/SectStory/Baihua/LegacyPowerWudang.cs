namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerWudang : LegacyPower
{
	protected override short CombatStateId => 229;

	protected override sbyte OrgTemplateId => 4;

	public LegacyPowerWudang(int charId)
		: base(charId)
	{
	}
}
