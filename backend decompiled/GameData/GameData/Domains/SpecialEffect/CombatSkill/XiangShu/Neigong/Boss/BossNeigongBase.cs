using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class BossNeigongBase : CombatSkillEffectBase
{
	protected BossNeigongBase()
	{
	}

	protected BossNeigongBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatDomain.RegisterHandler_CombatCharAboutToFall(OnCharAboutToFall);
	}

	public override void OnDisable(DataContext context)
	{
		CombatDomain.UnRegisterHandler_CombatCharAboutToFall(OnCharAboutToFall);
	}

	private void OnCharAboutToFall(DataContext context, CombatCharacter combatChar, ECombatCharAboutToFallType type)
	{
		if (combatChar == base.CombatChar && type == ECombatCharAboutToFallType.AddPhase && base.CombatChar.GetBossPhase() <= 0 && (DomainManager.Combat.IsCharacterFallen(base.CombatChar) || DomainManager.Combat.CombatConfig.StartInSecondPhase) && !DomainManager.Combat.CombatConfig.SkipChangePhase && DomainManager.Combat.IsMainCharacter(base.CombatChar))
		{
			DomainManager.Combat.Reset(context, base.CombatChar);
			DomainManager.Combat.AddBossPhase(context, base.CombatChar, base.EffectId);
			ActivePhase2Effect(context);
		}
	}

	protected virtual void ActivePhase2Effect(DataContext context)
	{
	}
}
