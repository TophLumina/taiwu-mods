using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class ZhenYuFuXie : BossNeigongBase
{
	public ZhenYuFuXie()
	{
	}

	public ZhenYuFuXie(CombatSkillKey skillKey)
		: base(skillKey, 16101)
	{
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (hit && pursueIndex == 0 && attacker == base.CombatChar && base.CurrEnemyChar.GetPreparingSkillId() >= 0 && DomainManager.Combat.InterruptSkill(context, base.CurrEnemyChar))
		{
			base.CurrEnemyChar.SetAnimationToPlayOnce(base.CurrEnemyChar.GetBeHitAni(2), context);
			DomainManager.Combat.SetProperLoopAniAndParticle(context, base.CurrEnemyChar);
			ShowSpecialEffectTips(1);
		}
	}
}
