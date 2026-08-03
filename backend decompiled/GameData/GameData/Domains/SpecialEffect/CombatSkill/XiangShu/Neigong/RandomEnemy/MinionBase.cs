using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.RandomEnemy;

public abstract class MinionBase : CombatSkillEffectBase
{
	protected static bool CanAffect => !DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(51);

	protected MinionBase()
	{
	}

	protected MinionBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}
}
