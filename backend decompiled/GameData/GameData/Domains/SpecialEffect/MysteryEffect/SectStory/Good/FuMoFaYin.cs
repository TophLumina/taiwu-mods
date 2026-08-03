using GameData.Domains.SpecialEffect.MysteryEffect.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Good;

public class FuMoFaYin : AddAndReduceDamage
{
	protected override short SpecialEffectId => 1753;

	protected override sbyte FiveElementsType => 0;

	protected override ushort MakeDamageFieldId => 69;

	protected override ushort AcceptDamageFieldId => 102;

	protected override bool IsAffect(AffectedDataKey dataKey)
	{
		return base.IsAffect(dataKey) && dataKey.CustomParam0 == 0;
	}

	public FuMoFaYin()
	{
	}

	public FuMoFaYin(int charId, int itemId)
		: base(charId, itemId, 50000)
	{
	}
}
