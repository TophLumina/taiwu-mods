namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerXuehou : LegacyPower
{
	protected override short CombatStateId => 240;

	protected override sbyte OrgTemplateId => 15;

	public LegacyPowerXuehou(int charId)
		: base(charId)
	{
	}
}
