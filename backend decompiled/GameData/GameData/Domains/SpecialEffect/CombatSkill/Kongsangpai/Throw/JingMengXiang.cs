using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Throw;

public class JingMengXiang : CombatSkillEffectBase
{
	public JingMengXiang()
	{
	}

	public JingMengXiang(CombatSkillKey skillKey)
		: base(skillKey, 10402, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		OuterAndInnerShorts attackRange = base.CombatChar.GetAttackRange();
		short minDist = Math.Max(attackRange.Outer, (short)20);
		short maxDist = Math.Min(attackRange.Inner, (short)120);
		short currDist = DomainManager.Combat.GetCurrentDistance();
		int addProgress = base.CombatChar.SkillPrepareTotalProgress * (base.IsDirect ? (maxDist - currDist) : (currDist - minDist)) / (maxDist - minDist);
		if (addProgress > 0)
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, addProgress);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private unsafe void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.SkillKey != SkillKey || index != 3)
		{
			return;
		}
		if (CombatCharPowerMatchAffectRequire())
		{
			HitOrAvoidInts selfHit = CharObj.GetHitValues();
			HitOrAvoidInts enemyAvoid = base.CurrEnemyChar.GetCharacter().GetAvoidValues();
			if (selfHit.Items[3] > enemyAvoid.Items[3])
			{
				if (base.CurrEnemyChar.GetPreparingSkillId() >= 0)
				{
					DomainManager.Combat.InterruptSkill(context, base.CurrEnemyChar);
				}
				sbyte otherActionType = base.CurrEnemyChar.GetPreparingOtherAction();
				if (otherActionType >= 0 && otherActionType != 3)
				{
					DomainManager.Combat.InterruptOtherAction(context, base.CurrEnemyChar);
				}
				ShowSpecialEffectTips(1);
			}
		}
		RemoveSelf(context);
	}
}
