using GameData.Domains.SpecialEffect.MysteryEffect.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Good;

public class LiangYiZhenYuan : AddAndReduceDamage
{
	protected override short SpecialEffectId => 1756;

	protected override sbyte FiveElementsType => 3;

	protected override ushort MakeDamageFieldId => 69;

	protected override ushort AcceptDamageFieldId => 102;

	protected override bool IsAffect(AffectedDataKey dataKey)
	{
		return base.IsAffect(dataKey) && dataKey.CustomParam0 == 1;
	}

	public LiangYiZhenYuan()
	{
	}

	public LiangYiZhenYuan(int charId, int itemId)
		: base(charId, itemId, 50003)
	{
	}
}
