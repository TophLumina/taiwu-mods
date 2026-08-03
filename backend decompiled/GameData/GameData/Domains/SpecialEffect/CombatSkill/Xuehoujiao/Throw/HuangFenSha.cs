using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Throw;

public class HuangFenSha : CombatSkillEffectBase
{
	private const sbyte CostMobilityAsLegSkill = 30;

	private const sbyte RequireMoveDistance = 10;

	private const sbyte PrepareProgressPercent = 50;

	private bool _isLegSkill;

	private int _movedDistance;

	public HuangFenSha()
	{
	}

	public HuangFenSha(CombatSkillKey skillKey)
		: base(skillKey, 15403, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_isLegSkill = true;
		CreateAffectedData(221, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(207, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(208, EDataModifyType.Custom, base.SkillTemplateId);
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.GetId() == base.CharacterId && DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			CheckIsLegSkill(context);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (base.CombatChar.GetAutoCastingSkill())
			{
				DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
			}
			else if (_isLegSkill)
			{
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power) && !base.CombatChar.GetAutoCastingSkill())
			{
				_movedDistance = 0;
				AddMaxEffectCount();
			}
			CheckIsLegSkill(context);
		}
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (base.EffectCount <= 0 || mover != base.CombatChar || !isMove || isForced || !(base.IsDirect ? (distance < 0) : (distance > 0)))
		{
			return;
		}
		_movedDistance += Math.Abs(distance);
		if (_movedDistance >= 10)
		{
			_movedDistance = 0;
			if (DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true))
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(1);
			}
			ReduceEffectCount();
		}
	}

	private void CheckIsLegSkill(DataContext context)
	{
		if (base.CombatChar.GetPreparingSkillId() != base.SkillTemplateId && base.CombatChar.NeedUseSkillId != base.SkillTemplateId)
		{
			bool cache = _isLegSkill;
			_isLegSkill = false;
			bool isLegSkill = !DomainManager.Combat.HasNeedTrick(base.CombatChar, base.SkillInstance);
			_isLegSkill = cache;
			if (_isLegSkill != isLegSkill)
			{
				_isLegSkill = isLegSkill;
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 221);
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 207);
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 208);
				DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar, base.SkillTemplateId);
			}
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.SkillKey != SkillKey || !_isLegSkill || base.CombatChar.GetAutoCastingSkill())
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = fieldId switch
		{
			221 => 5, 
			207 => 30, 
			_ => dataValue, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public override List<NeedTrick> GetModifiedValue(AffectedDataKey dataKey, List<NeedTrick> dataValue)
	{
		if (dataKey.SkillKey != SkillKey || !_isLegSkill || base.CombatChar.GetAutoCastingSkill())
		{
			return dataValue;
		}
		if (dataKey.FieldId == 208)
		{
			dataValue.Clear();
		}
		return dataValue;
	}
}
