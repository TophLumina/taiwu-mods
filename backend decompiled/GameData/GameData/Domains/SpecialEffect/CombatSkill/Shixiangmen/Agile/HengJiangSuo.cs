using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Agile;

public class HengJiangSuo : AgileSkillBase
{
	private const sbyte RequireMoveDistance = 10;

	private int _distanceAccumulator;

	public HengJiangSuo()
	{
	}

	public HengJiangSuo(CombatSkillKey skillKey)
		: base(skillKey, 6402)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_distanceAccumulator = 0;
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (mover.IsAlly == base.CombatChar.IsAlly || !isMove || isForced || !(base.IsDirect ? (distance < 0) : (distance > 0)))
		{
			return;
		}
		_distanceAccumulator += Math.Abs(distance);
		if (_distanceAccumulator >= 10)
		{
			_distanceAccumulator = 0;
			if (DomainManager.Combat.InAttackRange(base.CombatChar) && base.CanAffect)
			{
				base.CombatChar.NeedNormalAttackSkipPrepare++;
				ShowSpecialEffectTips(0);
			}
		}
	}
}
