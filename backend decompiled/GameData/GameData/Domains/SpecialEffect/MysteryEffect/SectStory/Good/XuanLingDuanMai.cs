using GameData.Domains.SpecialEffect.MysteryEffect.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Good;

public class XuanLingDuanMai : ChangeMark
{
	protected override short SpecialEffectId => 1755;

	protected override ushort FieldId => 335;

	protected override bool IsTarget(AffectedDataKey dataKey)
	{
		return base.IsTarget(dataKey) && dataKey.CustomParam0 == 1;
	}

	public XuanLingDuanMai()
	{
	}

	public XuanLingDuanMai(int charId, int itemId)
		: base(charId, itemId, 50002)
	{
	}
}
