using GameData.Domains.SpecialEffect.MysteryEffect.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Evil;

public class HuangXieGuiQi : AddAndReduceDamage
{
	protected override short SpecialEffectId => 1767;

	protected override sbyte FiveElementsType => 4;

	protected override ushort MakeDamageFieldId => 333;

	protected override ushort AcceptDamageFieldId => 334;

	public HuangXieGuiQi()
	{
	}

	public HuangXieGuiQi(int charId, int itemId)
		: base(charId, itemId, 50014)
	{
	}
}
