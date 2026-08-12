namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class LegacyPowerBaihua : LegacyPower
{
	protected override short CombatStateId => 228;

	protected override sbyte OrgTemplateId => 3;

	public LegacyPowerBaihua(int charId)
		: base(charId)
	{
	}
}
