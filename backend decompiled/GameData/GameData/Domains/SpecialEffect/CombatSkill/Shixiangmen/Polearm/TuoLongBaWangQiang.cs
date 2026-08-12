using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Polearm;

public class TuoLongBaWangQiang : CombatSkillEffectBase
{
	private const int DamageFactor = 3;

	private const int EffectCountFactor = 3;

	private int _attackEnemyId;

	private sbyte _bodyPart;

	private OuterAndInnerInts _damageValue;

	private short _effectCount;

	public TuoLongBaWangQiang()
	{
	}

	public TuoLongBaWangQiang(CombatSkillKey skillKey)
		: base(skillKey, 6307, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_damageValue = new OuterAndInnerInts(0, 0);
		_effectCount = 0;
		if (AffectDatas == null)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		}
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 116, -1), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 249, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 192, -1), EDataModifyType.Custom);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.RegisterHandler_AddDirectInjury(AddDirectInjury);
		Events.RegisterHandler_AddDirectFatalDamageMark(AddDirectFatalDamageMark);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.UnRegisterHandler_AddDirectInjury(AddDirectInjury);
		Events.UnRegisterHandler_AddDirectFatalDamageMark(AddDirectFatalDamageMark);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (attackerId == base.CharacterId && combatSkillId == base.SkillTemplateId)
		{
			_attackEnemyId = defenderId;
			_bodyPart = bodyPart;
			if (isInner)
			{
				_damageValue.Inner += damageValue;
			}
			else
			{
				_damageValue.Outer += damageValue;
			}
		}
	}

	private void AddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (attackerId == base.CharacterId && combatSkillId == base.SkillTemplateId && !IsSrcSkillPerformed)
		{
			sbyte markCount = (base.IsDirect ? outerMarkCount : innerMarkCount);
			_effectCount += (short)(markCount * 3);
		}
	}

	private void AddDirectFatalDamageMark(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, int outerMarkCount, int innerMarkCount, short combatSkillId)
	{
		if (attackerId == base.CharacterId && combatSkillId == base.SkillTemplateId && !IsSrcSkillPerformed)
		{
			int markCount = (base.IsDirect ? outerMarkCount : innerMarkCount);
			_effectCount += (short)(markCount * 3);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId || !PowerMatchAffectRequire(power))
		{
			return;
		}
		OuterAndInnerInts damageValue = _damageValue;
		if (damageValue.Outer <= 0 && damageValue.Inner <= 0)
		{
			return;
		}
		if (IsSrcSkillPerformed)
		{
			RemoveSelf(context);
			return;
		}
		if (_effectCount > 0)
		{
			DomainManager.Combat.AddSkillEffect(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), _effectCount, _effectCount, autoRemoveOnNoCount: true);
		}
		IsSrcSkillPerformed = true;
		bool anyAdd = false;
		int[] enemyList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		foreach (int enemyId in enemyList)
		{
			if (enemyId >= 0 && enemyId != _attackEnemyId)
			{
				anyAdd = true;
				DomainManager.Combat.AddInjuryDamageValue(base.CombatChar, DomainManager.Combat.GetElement_CombatCharacterDict(enemyId), _bodyPart, _damageValue.Outer * 3, _damageValue.Inner * 3, skillId);
			}
		}
		if (anyAdd)
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 116 && dataKey.CustomParam1 == ((!base.IsDirect) ? 1 : 0))
		{
			int currInjury = dataKey.CustomParam2 + currModifyValue;
			if (currInjury > 0)
			{
				return GetReduceValue(currInjury);
			}
		}
		return 0;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		bool flag = ((fieldId == 192 || fieldId == 249) ? true : false);
		if (flag && dataValue > 0)
		{
			return dataValue + GetReduceValue(dataValue);
		}
		return dataValue;
	}

	private int GetReduceValue(int markCount)
	{
		int changeValue = Math.Min(base.EffectCount, markCount);
		ReduceEffectCount(changeValue);
		ShowSpecialEffectTips(1);
		return -changeValue;
	}
}
