using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Throw;

public class YuanSha : AddDamage
{
	private const short MinDistance = 50;

	private const short BaseAddDamage = 40;

	private const short AddDamageUnit = 20;

	public YuanSha()
	{
	}

	public YuanSha(CombatSkillKey skillKey)
		: base(skillKey, 40602)
	{
	}

	protected override int GetAddDamagePercent()
	{
		short distance = DomainManager.Combat.GetCurrentDistance();
		return (distance >= 50) ? (40 + (distance - 50) / 10 * 20) : 0;
	}
}
