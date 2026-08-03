namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerYuanshan : LegacyPower
{
	protected override short CombatStateId => 230;

	protected override sbyte OrgTemplateId => 5;

	public LegacyPowerYuanshan(int charId)
		: base(charId)
	{
	}
}
