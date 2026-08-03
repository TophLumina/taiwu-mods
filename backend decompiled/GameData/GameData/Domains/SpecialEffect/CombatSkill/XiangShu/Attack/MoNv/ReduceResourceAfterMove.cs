using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.MoNv;

public class ReduceResourceAfterMove : CombatSkillEffectBase
{
	private const sbyte RequireMoveDistance = 20;

	private int _movedDistance;

	protected ReduceResourceAfterMove()
	{
	}

	protected ReduceResourceAfterMove(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			if (PowerMatchAffectRequire(power))
			{
				IsSrcSkillPerformed = true;
				AddMaxEffectCount();
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (!(!IsSrcSkillPerformed || mover.IsAlly == base.CombatChar.IsAlly || !isMove || isForced))
		{
			_movedDistance += Math.Abs(distance);
			if (_movedDistance >= 20)
			{
				_movedDistance -= 20;
				CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
				ChangeBreathValue(context, enemyChar, -30000);
				ChangeStanceValue(context, enemyChar, -4000);
				ChangeMobilityValue(context, enemyChar, -MoveSpecialConstants.MaxMobility);
				ClearAffectingAgileSkill(context, enemyChar);
				ShowSpecialEffectTips(0);
				ReduceEffectCount();
			}
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}
}
