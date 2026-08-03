using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Agile;

public class YuYiGong : AgileSkillBase
{
	private bool _affecting;

	private bool _moveInAttackRange;

	public YuYiGong()
	{
	}

	public YuYiGong(CombatSkillKey skillKey)
		: base(skillKey, 8408)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_MoveBegin(OnMoveBegin);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		_affecting = false;
		OnMoveSkillCanAffectChanged(context, default(DataUid));
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_MoveBegin(OnMoveBegin);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		if (base.CombatChar.GetJumpPreparedDistance() > 0)
		{
			AddFlawAndAcupoint(context, base.CombatChar.GetJumpPreparedDistance());
		}
		DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
	}

	private void OnMoveBegin(DataContext context, CombatCharacter mover, int distance, bool isJump)
	{
		if (mover == base.CombatChar)
		{
			_moveInAttackRange = DomainManager.Combat.InAttackRange(base.CurrEnemyChar);
		}
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (!(mover != base.CombatChar || !isMove || isForced) && (base.IsDirect ? (distance < 0) : (distance > 0)) && _affecting && _moveInAttackRange && !DomainManager.Combat.IsMovedByTeammate(base.CombatChar))
		{
			AddFlawAndAcupoint(context, distance);
		}
	}

	private void AddFlawAndAcupoint(DataContext context, int distance)
	{
		int addCount = Math.Abs(distance) / 10;
		if (addCount > 0)
		{
			DomainManager.Combat.AddFlaw(context, base.CurrEnemyChar, 2, SkillKey, -1, addCount);
			DomainManager.Combat.AddAcupoint(context, base.CurrEnemyChar, 2, SkillKey, -1, addCount);
			DomainManager.Combat.AddToCheckFallenSet(base.CurrEnemyChar.GetId());
			ShowSpecialEffectTips(0);
		}
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect;
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			if (canAffect)
			{
				DomainManager.Combat.EnableJumpMove(base.CombatChar, base.SkillTemplateId, base.IsDirect);
			}
			else
			{
				DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
			}
		}
	}
}
