using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Agile;

public class QianLiDuXing : AgileSkillBase
{
	private const sbyte RequireDistance = 10;

	private const sbyte AddMobilityPercent = 5;

	private int _distanceAccumulator;

	public QianLiDuXing()
	{
	}

	public QianLiDuXing(CombatSkillKey skillKey)
		: base(skillKey, 5402)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
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
		while (_distanceAccumulator >= 10)
		{
			_distanceAccumulator -= 10;
			if (base.CanAffect)
			{
				ChangeMobilityValue(context, base.CombatChar, MoveSpecialConstants.MaxMobility * 5 / 100);
				ShowSpecialEffectTips(0);
			}
		}
	}
}
