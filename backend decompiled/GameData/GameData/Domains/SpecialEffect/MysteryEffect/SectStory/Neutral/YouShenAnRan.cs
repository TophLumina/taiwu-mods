using GameData.Domains.SpecialEffect.MysteryEffect.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Neutral;

public class YouShenAnRan : AddAndReduceDamage
{
	protected override short SpecialEffectId => 1760;

	protected override sbyte FiveElementsType => 2;

	protected override ushort MakeDamageFieldId => 274;

	protected override ushort AcceptDamageFieldId => 275;

	public YouShenAnRan()
	{
	}

	public YouShenAnRan(int charId, int itemId)
		: base(charId, itemId, 50007)
	{
	}
}
