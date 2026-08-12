namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerFulong : LegacyPower
{
	protected override short CombatStateId => 239;

	protected override sbyte OrgTemplateId => 14;

	public LegacyPowerFulong(int charId)
		: base(charId)
	{
	}
}
