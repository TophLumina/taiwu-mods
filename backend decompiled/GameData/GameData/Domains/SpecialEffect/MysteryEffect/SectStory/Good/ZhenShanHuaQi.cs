using GameData.Domains.SpecialEffect.MysteryEffect.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Good;

public class ZhenShanHuaQi : AddTrickAttackRange
{
	protected override short SpecialEffectId => 1757;

	public ZhenShanHuaQi()
	{
	}

	public ZhenShanHuaQi(int charId, int itemId)
		: base(charId, itemId, 50004)
	{
	}

	protected override bool IsAffectTrick(sbyte trickType)
	{
		if ((uint)(trickType - 3) <= 2u)
		{
			return true;
		}
		return false;
	}
}
