using GameData.Domains.SpecialEffect.MysteryEffect.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Neutral;

public class SuiGuFeiShi : ChangeMark
{
	protected override short SpecialEffectId => 1758;

	protected override ushort FieldId => 335;

	protected override bool IsTarget(AffectedDataKey dataKey)
	{
		return base.IsTarget(dataKey) && dataKey.CustomParam0 == 0;
	}

	public SuiGuFeiShi()
	{
	}

	public SuiGuFeiShi(int charId, int itemId)
		: base(charId, itemId, 50005)
	{
	}
}
