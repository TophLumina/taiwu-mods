using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Blade;

public class KuangDao : CombatSkillEffectBase
{
	private const sbyte AddHitOddsUnit = -3;

	private const int AddHitOddsUnitMaxCount = 30;

	private bool _affected;

	private int _affectingDefeatMarkCount;

	private int AddPowerUnit => base.IsDirect ? 5 : 10;

	public KuangDao()
	{
	}

	public KuangDao(CombatSkillKey skillKey)
		: base(skillKey, 6208, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_affected = false;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 220, base.SkillTemplateId), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 248, base.SkillTemplateId), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 74, base.SkillTemplateId), EDataModifyType.TotalPercent);
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.RegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.UnRegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (outerMarkCount <= 0 && innerMarkCount <= 0)
		{
			return;
		}
		bool num;
		if (!base.IsDirect)
		{
			if (defenderId != base.CharacterId)
			{
				return;
			}
			num = DomainManager.Combat.GetElement_CombatCharacterDict(attackerId).IsAlly != base.CombatChar.IsAlly;
		}
		else
		{
			if (attackerId != base.CharacterId)
			{
				return;
			}
			num = DomainManager.Combat.GetElement_CombatCharacterDict(defenderId).IsAlly != isAlly;
		}
		if (num)
		{
			AddPower(context, outerMarkCount + innerMarkCount);
		}
	}

	private void OnAddDirectFatalDamageMark(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, int outerMarkCount, int innerMarkCount, short combatSkillId)
	{
		if (outerMarkCount <= 0 && innerMarkCount <= 0)
		{
			return;
		}
		bool num;
		if (!base.IsDirect)
		{
			if (defenderId != base.CharacterId)
			{
				return;
			}
			num = DomainManager.Combat.GetElement_CombatCharacterDict(attackerId).IsAlly != base.CombatChar.IsAlly;
		}
		else
		{
			if (attackerId != base.CharacterId)
			{
				return;
			}
			num = DomainManager.Combat.GetElement_CombatCharacterDict(defenderId).IsAlly != isAlly;
		}
		if (num)
		{
			AddPower(context, outerMarkCount + innerMarkCount);
		}
	}

	private void AddPower(DataContext context, int defeatMarkCount)
	{
		_affectingDefeatMarkCount += defeatMarkCount;
		DomainManager.Combat.AddSkillPowerInCombat(context, SkillKey, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), AddPowerUnit * defeatMarkCount);
		if (!_affected)
		{
			_affected = true;
			ShowSpecialEffectTips(0);
			Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		}
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		_affected = false;
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 74 && _affectingDefeatMarkCount > 0)
		{
			ShowSpecialEffectTips(1);
			return Math.Min(30, _affectingDefeatMarkCount) * -3;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 220)
		{
			return false;
		}
		if (dataKey.FieldId == 248)
		{
			return true;
		}
		return dataValue;
	}
}
