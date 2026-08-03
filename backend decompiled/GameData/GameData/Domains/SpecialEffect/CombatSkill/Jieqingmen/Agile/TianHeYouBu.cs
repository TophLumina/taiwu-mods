using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Agile;

public class TianHeYouBu : AgileSkillBase
{
	private const sbyte RequireMoveDistance = 10;

	private const int AbsorbNeiliAllocationValue = 2;

	private int _distanceAccumulator;

	public TianHeYouBu()
	{
	}

	public TianHeYouBu(CombatSkillKey skillKey)
		: base(skillKey, 13403)
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
		if (mover != base.CombatChar || !isMove || isForced || !(base.IsDirect ? (distance < 0) : (distance > 0)))
		{
			return;
		}
		_distanceAccumulator += Math.Abs(distance);
		if (_distanceAccumulator < 10)
		{
			return;
		}
		_distanceAccumulator = 0;
		if (base.CanAffect)
		{
			byte type = (byte)((!base.IsDirect) ? 2 : 0);
			if (base.CombatChar.AbsorbNeiliAllocation(context, base.EnemyChar, type, 2))
			{
				ShowSpecialEffectTips(0);
			}
		}
	}
}
