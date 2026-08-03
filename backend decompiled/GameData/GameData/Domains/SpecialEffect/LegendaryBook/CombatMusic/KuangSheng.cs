using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.CombatMusic;

public class KuangSheng : AddDamage
{
	private const short AddDamageUnit = 30;

	public KuangSheng()
	{
	}

	public KuangSheng(CombatSkillKey skillKey)
		: base(skillKey, 41302)
	{
	}

	protected override int GetAddDamagePercent()
	{
		return 30 * base.CombatChar.GetTrickCount(9);
	}
}
