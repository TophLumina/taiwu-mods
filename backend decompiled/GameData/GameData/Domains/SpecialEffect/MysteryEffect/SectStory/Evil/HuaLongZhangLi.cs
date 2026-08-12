using GameData.Domains.SpecialEffect.MysteryEffect.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Evil;

public class HuaLongZhangLi : AddTrickAttackRange
{
	protected override short SpecialEffectId => 1766;

	public HuaLongZhangLi()
	{
	}

	public HuaLongZhangLi(int charId, int itemId)
		: base(charId, itemId, 50013)
	{
	}

	protected override bool IsAffectTrick(sbyte trickType)
	{
		if ((uint)(trickType - 6) <= 2u)
		{
			return true;
		}
		return false;
	}
}
