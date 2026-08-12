namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerXuannv : LegacyPower
{
	protected override short CombatStateId => 233;

	protected override sbyte OrgTemplateId => 8;

	public LegacyPowerXuannv(int charId)
		: base(charId)
	{
	}
}
