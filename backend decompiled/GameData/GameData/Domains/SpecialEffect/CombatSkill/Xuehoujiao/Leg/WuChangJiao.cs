using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Leg;

public class WuChangJiao : CombatSkillEffectBase
{
	private const sbyte PowerRandomMin = -40;

	private const sbyte PowerRandomMax = 60;

	private int _distanceAccumulator;

	private int _changePower;

	public WuChangJiao()
	{
	}

	public WuChangJiao(CombatSkillKey skillKey)
		: base(skillKey, 15302, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 209, base.SkillTemplateId), EDataModifyType.Custom);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (!(mover.GetId() != base.CharacterId || !isMove || isForced) && (base.IsDirect ? (distance < 0) : (distance > 0)))
		{
			_distanceAccumulator += Math.Abs(distance);
			while (_distanceAccumulator >= 10)
			{
				_distanceAccumulator -= 10;
				_changePower = context.Random.Next(-40, 61);
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			ShowSpecialEffectTips(1);
			base.IsDirect = !base.IsDirect;
			_changePower = 0;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 209);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _changePower;
		}
		return 0;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 209)
		{
			return (!base.IsDirect) ? 1 : 0;
		}
		return dataValue;
	}
}
