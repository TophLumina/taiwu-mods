using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.ControllableShot;

public class BianJie : AddDamage
{
	private const short AddDamageUnit = 15;

	public BianJie()
	{
	}

	public BianJie(CombatSkillKey skillKey)
		: base(skillKey, 41202)
	{
	}

	protected override int GetAddDamagePercent()
	{
		return 15 * base.CombatChar.GetChangeTrickCount();
	}
}
