using GameData.Domains.SpecialEffect.MysteryEffect.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Evil;

public class DieMuYinYi : AddAndReduceDamage
{
	protected override short SpecialEffectId => 1764;

	protected override sbyte FiveElementsType => 1;

	protected override ushort MakeDamageFieldId => 73;

	protected override ushort AcceptDamageFieldId => 106;

	protected override bool IsAffect(AffectedDataKey dataKey)
	{
		return base.IsAffect(dataKey) && dataKey.CustomParam1 == 1;
	}

	public DieMuYinYi()
	{
	}

	public DieMuYinYi(int charId, int itemId)
		: base(charId, itemId, 50011)
	{
	}
}
