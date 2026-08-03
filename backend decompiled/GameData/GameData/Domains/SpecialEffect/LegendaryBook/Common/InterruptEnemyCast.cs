using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Common;

public class InterruptEnemyCast : CombatSkillEffectBase
{
	protected InterruptEnemyCast()
	{
		IsLegendaryBookEffect = true;
	}

	protected InterruptEnemyCast(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
		IsLegendaryBookEffect = true;
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
		if (!(context.SkillKey != SkillKey) && index == 3 && context.Attacker.GetAttackSkillPower() >= 100 && !base.CombatChar.GetAutoCastingSkill())
		{
			short enemyPreparingSkill = base.CurrEnemyChar.GetPreparingSkillId();
			if (enemyPreparingSkill >= 0 && Config.CombatSkill.Instance[enemyPreparingSkill].Type == Config.CombatSkill.Instance[base.SkillTemplateId].Type)
			{
				DomainManager.Combat.InterruptSkill(context, base.CurrEnemyChar);
			}
		}
	}
}
