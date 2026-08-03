using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.SpecialEffect.Cricket.Common;

namespace GameData.Domains.SpecialEffect.Cricket.Teammate;

public class HuangJia : NormalAttackAddOther
{
	private static CValuePercent AddFatalDamage => 33;

	public HuangJia(int charId)
		: base(charId)
	{
	}

	protected override void DoAddDamage(DataContext context, CombatCharacter defender, int damageValue)
	{
		defender.AddFatalDamage(context, damageValue * AddFatalDamage, -1, -1, -1);
	}
}
