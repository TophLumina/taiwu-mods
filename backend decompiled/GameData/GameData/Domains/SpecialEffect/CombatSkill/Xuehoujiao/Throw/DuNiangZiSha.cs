using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Throw;

public class DuNiangZiSha : CombatSkillEffectBase
{
	private const sbyte MoveDistance = 10;

	private int _movedDistance;

	private int _affectTimes;

	public DuNiangZiSha()
	{
	}

	public DuNiangZiSha(CombatSkillKey skillKey)
		: base(skillKey, 15405, -1)
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
				_movedDistance = 0;
				_affectTimes = 0;
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
		if (mover.GetId() != base.CharacterId || !isMove || isForced || !(base.IsDirect ? (distance < 0) : (distance > 0)) || base.CombatChar.GetTrickCount(14) <= 0)
		{
			return;
		}
		_movedDistance += Math.Abs(distance);
		while (_movedDistance >= 10 && base.EffectCount > 0)
		{
			_movedDistance -= 10;
			_affectTimes++;
			DomainManager.Combat.RemoveTrick(context, base.CombatChar, 14, 1);
			if (_affectTimes == 1)
			{
				Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
			}
			ReduceEffectCount();
		}
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.IsAlly == base.CombatChar.IsAlly)
		{
			return;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		for (int i = 0; i < _affectTimes; i++)
		{
			if (DomainManager.Combat.ChangeDistance(context, enemyChar, base.IsDirect ? (-10) : 10, isForced: true))
			{
				DomainManager.Combat.AddAcupoint(context, enemyChar, 0, new CombatSkillKey(-1, -1), -1);
			}
		}
		_affectTimes = 0;
		ShowSpecialEffectTips(0);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}
}
