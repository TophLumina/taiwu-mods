using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Leg;

public class YunLongJiuXianTui : CombatSkillEffectBase
{
	private const sbyte AutoCastDistance = 2;

	private const sbyte AutoCastCostMobility = 10;

	private const sbyte PrepareProgressPercent = 50;

	private int _distanceAccumulator;

	public YunLongJiuXianTui()
	{
	}

	public YunLongJiuXianTui(CombatSkillKey skillKey)
		: base(skillKey, 5106, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && base.CombatChar.GetAutoCastingSkill())
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power) && !base.CombatChar.GetAutoCastingSkill())
		{
			AddMaxEffectCount();
		}
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (mover.GetId() != base.CharacterId || base.EffectCount <= 0 || !isMove || isForced || (base.IsDirect ? (distance > 0) : (distance < 0)) || base.CombatChar.GetPreparingSkillId() >= 0)
		{
			return;
		}
		_distanceAccumulator += Math.Abs(distance);
		if (_distanceAccumulator < 2)
		{
			return;
		}
		_distanceAccumulator = 0;
		ReduceEffectCount();
		int costMobility = MoveSpecialConstants.MaxMobility * 10 / 100;
		if ((base.CombatChar.GetMobilityValue() >= costMobility || base.SkillInstance.GetCostMobilityPercent() == 0) && DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true, checkRange: true))
		{
			if (base.SkillInstance.GetCostMobilityPercent() > 0)
			{
				ChangeMobilityValue(context, base.CombatChar, -costMobility);
			}
			DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
			ShowSpecialEffectTips(0);
		}
	}
}
