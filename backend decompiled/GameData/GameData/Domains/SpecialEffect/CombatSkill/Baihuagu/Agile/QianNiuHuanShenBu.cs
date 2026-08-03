using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Agile;

public class QianNiuHuanShenBu : AttackChangeMobility
{
	public QianNiuHuanShenBu()
	{
	}

	public QianNiuHuanShenBu(CombatSkillKey skillKey)
		: base(skillKey, 3401)
	{
		RequireWeaponSubType = 3;
	}
}
