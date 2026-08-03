using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Polearm;

public class KuangLongShiZiQiang : CombatSkillEffectBase
{
	private bool _reduceInjuryAffected;

	private bool _jumpMoveAffecting;

	private DataUid _moveSkillUid;

	public KuangLongShiZiQiang()
	{
	}

	public KuangLongShiZiQiang(CombatSkillKey skillKey)
		: base(skillKey, 6306, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_reduceInjuryAffected = false;
		_moveSkillUid = new DataUid(8, 10, (ulong)base.CharacterId, 62u);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 114, -1), EDataModifyType.Custom);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		DomainManager.Combat.DisableJumpMove(context, base.CombatChar);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		if (IsSrcSkillPerformed)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_moveSkillUid, base.DataHandlerKey);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			if (PowerMatchAffectRequire(power))
			{
				IsSrcSkillPerformed = true;
				AddMaxEffectCount();
				OnMoveSkillChanged(context, _moveSkillUid);
				GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_moveSkillUid, base.DataHandlerKey, OnMoveSkillChanged);
				if (_reduceInjuryAffected)
				{
					ShowSpecialEffectTips(0);
				}
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (!(mover.GetId() != base.CharacterId || !_jumpMoveAffecting || !isMove || isForced) && (base.IsDirect ? (distance < 0) : (distance > 0)))
		{
			ReduceEffectCount();
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	private void OnMoveSkillChanged(DataContext context, DataUid dataUid)
	{
		_jumpMoveAffecting = base.CombatChar.GetAffectingMoveSkillId() < 0;
		if (_jumpMoveAffecting)
		{
			DomainManager.Combat.EnableJumpMove(base.CombatChar, base.SkillTemplateId, base.IsDirect);
		}
		else
		{
			DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
		}
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (dataKey.CharId != base.CharacterId || IsSrcSkillPerformed || damageType != EDamageType.Bounce)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 114 && dataValue > 0)
		{
			_reduceInjuryAffected = true;
			bool isInner = dataKey.CustomParam1 == 1;
			sbyte bodyPart = (sbyte)dataKey.CustomParam2;
			int clampedDamageValue = (int)Math.Clamp(dataValue, 0L, 2147483647L);
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			DomainManager.Combat.AddInjuryDamageValue(enemyChar, enemyChar, bodyPart, (!isInner) ? clampedDamageValue : 0, isInner ? clampedDamageValue : 0, base.SkillTemplateId);
			return 0L;
		}
		return dataValue;
	}
}
