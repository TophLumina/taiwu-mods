using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Finger;

public class TaiSuJueShou : CombatSkillEffectBase
{
	private const sbyte InterruptOddsUnit = 8;

	private const sbyte ChangePowerPercent = 20;

	private const int SilenceFrame = 1200;

	public TaiSuJueShou()
	{
	}

	public TaiSuJueShou(CombatSkillKey skillKey)
		: base(skillKey, 13106, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.SkillKey != SkillKey || index != 3)
		{
			return;
		}
		int power = context.Attacker.GetAttackSkillPower();
		if (power > 0)
		{
			short enemySkillId = base.CurrEnemyChar.GetPreparingSkillId();
			if (enemySkillId >= 0 && DomainManager.Combat.InterruptSkill(context, base.CurrEnemyChar, 8 * power / 10))
			{
				CombatSkillKey enemySkillKey = new CombatSkillKey(base.CurrEnemyChar.GetId(), enemySkillId);
				SkillEffectKey effectKey = new SkillEffectKey(base.SkillTemplateId, base.IsDirect);
				if (base.IsDirect)
				{
					DomainManager.Combat.AddSkillPowerInCombat(context, SkillKey, effectKey, DomainManager.CombatSkill.GetElement_CombatSkills(enemySkillKey).GetPower() * 20 / 100);
				}
				else
				{
					DomainManager.Combat.ReduceSkillPowerInCombat(context, enemySkillKey, effectKey, -base.SkillInstance.GetPower() * 20 / 100);
				}
				base.CurrEnemyChar.SetAnimationToPlayOnce(base.CurrEnemyChar.GetBeHitAni(2), context);
				DomainManager.Combat.SetProperLoopAniAndParticle(context, base.CurrEnemyChar);
				DomainManager.Combat.SilenceSkill(context, base.CurrEnemyChar, enemySkillId, 1200);
				ShowSpecialEffectTips(0);
				ShowSpecialEffectTips(1);
			}
		}
		RemoveSelf(context);
	}

	public static int CalcInterruptOdds(CombatSkillKey selfSkill, bool isDirect, CombatSkillKey enemySkill)
	{
		return 80;
	}
}
