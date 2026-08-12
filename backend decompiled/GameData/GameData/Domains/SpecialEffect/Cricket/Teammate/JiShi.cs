using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.SpecialEffect.Cricket.Common;

namespace GameData.Domains.SpecialEffect.Cricket.Teammate;

public class JiShi : NormalAttackAddOther
{
	private static CValuePercent AddMindDamage => 33;

	public JiShi(int charId)
		: base(charId)
	{
	}

	protected override void DoAddDamage(DataContext context, CombatCharacter defender, int damageValue)
	{
		defender.AddMindDamage(context, damageValue * AddMindDamage, -1);
	}
}
