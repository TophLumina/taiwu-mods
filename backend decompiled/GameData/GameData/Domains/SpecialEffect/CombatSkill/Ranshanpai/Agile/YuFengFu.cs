using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Agile;

public class YuFengFu : AgileSkillBase
{
	private const sbyte RequireMoveDistance = 10;

	private const sbyte StatePowerUnit = 50;

	private int _distanceAccumulator;

	public YuFengFu()
	{
	}

	public YuFengFu(CombatSkillKey skillKey)
		: base(skillKey, 7401)
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
		if (mover != base.CombatChar || !isMove || isForced)
		{
			return;
		}
		_distanceAccumulator += Math.Abs(distance);
		if (_distanceAccumulator >= 10)
		{
			_distanceAccumulator = 0;
			if (base.CanAffect)
			{
				DomainManager.Combat.AddCombatState(context, base.IsDirect ? base.CombatChar : base.CurrEnemyChar, (sbyte)(base.IsDirect ? 1 : 2), (short)(base.IsDirect ? 34 : 35), 50);
				ShowSpecialEffectTips(0);
			}
		}
	}
}
