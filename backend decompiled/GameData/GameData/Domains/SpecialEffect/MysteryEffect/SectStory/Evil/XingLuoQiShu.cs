using GameData.Domains.SpecialEffect.MysteryEffect.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Evil;

public class XingLuoQiShu : AddTrickAttackRange
{
	protected override short SpecialEffectId => 1765;

	public XingLuoQiShu()
	{
	}

	public XingLuoQiShu(int charId, int itemId)
		: base(charId, itemId, 50012)
	{
	}

	protected override bool IsAffectTrick(sbyte trickType)
	{
		if ((uint)trickType <= 2u)
		{
			return true;
		}
		return false;
	}
}
