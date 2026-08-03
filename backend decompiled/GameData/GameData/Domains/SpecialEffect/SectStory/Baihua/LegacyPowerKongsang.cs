namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerKongsang : LegacyPower
{
	protected override short CombatStateId => 235;

	protected override sbyte OrgTemplateId => 10;

	public LegacyPowerKongsang(int charId)
		: base(charId)
	{
	}
}
