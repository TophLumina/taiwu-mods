using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Agile;

public class TianYuanZong : AgileSkillBase
{
	private const sbyte StatePowerUnit = 50;

	private bool _affecting;

	public TianYuanZong()
	{
	}

	public TianYuanZong(CombatSkillKey skillKey)
		: base(skillKey, 13407)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		_affecting = false;
		OnMoveSkillCanAffectChanged(context, default(DataUid));
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		if (base.CombatChar.GetJumpPreparedDistance() > 0 && DomainManager.Combat.IsInCombat())
		{
			AddCombatState(context, base.CombatChar.GetJumpPreparedDistance());
		}
		DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (!(mover != base.CombatChar || !isMove || isForced) && (base.IsDirect ? (distance < 0) : (distance > 0)) && _affecting && !DomainManager.Combat.IsMovedByTeammate(base.CombatChar))
		{
			AddCombatState(context, distance);
		}
	}

	private void AddCombatState(DataContext context, short distance)
	{
		DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, 68, 50 * Math.Abs(distance) / 10);
		ShowSpecialEffectTips(0);
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
