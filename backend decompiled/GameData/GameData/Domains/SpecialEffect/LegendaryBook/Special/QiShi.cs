using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Special;

public class QiShi : AddDamage
{
	public QiShi()
	{
	}

	public QiShi(CombatSkillKey skillKey)
		: base(skillKey, 41002)
	{
	}

	protected override int GetAddDamagePercent()
	{
		return 180 * (4000 - base.CurrEnemyChar.GetStanceValue()) / 4000;
	}
}
