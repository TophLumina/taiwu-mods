using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Agile;

public class LuoShenLingBo : AgileSkillBase
{
	private const sbyte RequireMoveDistance = 20;

	private const sbyte AddBreathStance = 30;

	private const int AttractionUnit = 360;

	private const int MaxMindMarkCount = 3;

	private int _distanceAccumulator;

	public LuoShenLingBo()
	{
	}

	public LuoShenLingBo(CombatSkillKey skillKey)
		: base(skillKey, 8407)
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
		if (_distanceAccumulator < 20)
		{
			return;
		}
		int affectCount = _distanceAccumulator / 20;
		_distanceAccumulator -= affectCount * 20;
		if (base.CanAffect)
		{
			ChangeBreathValue(context, base.CombatChar, 9000);
			ChangeStanceValue(context, base.CombatChar, 1200);
			DomainManager.Combat.UpdateSkillCostBreathStanceCanUse(context, base.CombatChar);
			ShowSpecialEffectTips(0);
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			if (DomainManager.Combat.InAttackRange(enemyChar))
			{
				int mindMarkCount = 1 + Math.Clamp(base.CombatChar.GetCharacter().GetAttraction() / 360, 0, 2);
				AddPowerDamageMind(context, enemyChar, mindMarkCount);
				ShowSpecialEffectTips(1);
			}
		}
	}
}
