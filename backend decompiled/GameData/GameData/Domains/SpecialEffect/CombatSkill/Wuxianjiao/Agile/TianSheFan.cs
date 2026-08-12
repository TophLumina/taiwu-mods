using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Agile;

public class TianSheFan : AgileSkillBase
{
	private const sbyte StatePowerUnit = 50;

	private bool _affecting;

	public TianSheFan()
	{
	}

	public TianSheFan(CombatSkillKey skillKey)
		: base(skillKey, 12606)
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
		DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (!(mover != base.CombatChar || !isMove || isForced) && (base.IsDirect ? (distance < 0) : (distance > 0)) && _affecting && !DomainManager.Combat.IsMovedByTeammate(base.CombatChar))
		{
			int statePower = 50 * Math.Abs(distance / 10);
			if (statePower > 0)
			{
				DomainManager.Combat.AddCombatState(context, DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly), 2, 63, statePower);
				ShowSpecialEffectTips(0);
			}
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
