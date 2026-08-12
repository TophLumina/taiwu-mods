using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Agile;

public class ZhenShanBu : AgileSkillBase
{
	private const sbyte DirectAddCost = 50;

	private static readonly CValuePercent ReverseCost = 4;

	private bool _affected;

	public ZhenShanBu()
	{
	}

	public ZhenShanBu(CombatSkillKey skillKey)
		: base(skillKey, 6400)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_affected = false;
		if (base.IsDirect)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			int[] charList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
			for (int i = 0; i < charList.Length; i++)
			{
				if (charList[i] >= 0)
				{
					AffectDatas.Add(new AffectedDataKey(charList[i], 150, -1), EDataModifyType.TotalPercent);
				}
			}
			ShowSpecialEffectTips(0);
		}
		else
		{
			Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
			Events.RegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
		}
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (!base.IsDirect)
		{
			Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
			Events.UnRegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
		}
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (attackerId == base.CharacterId && DomainManager.Combat.GetElement_CombatCharacterDict(defenderId).IsAlly != isAlly && (outerMarkCount > 0 || innerMarkCount > 0) && base.CanAffect)
		{
			ReduceMobility(context);
		}
	}

	private void OnAddDirectFatalDamageMark(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, int outerMarkCount, int innerMarkCount, short combatSkillId)
	{
		if (attackerId == base.CharacterId && DomainManager.Combat.GetElement_CombatCharacterDict(defenderId).IsAlly != isAlly && (outerMarkCount > 0 || innerMarkCount > 0) && base.CanAffect)
		{
			ReduceMobility(context);
		}
	}

	private void ReduceMobility(DataContext context)
	{
		if (!_affected)
		{
			ChangeMobilityValue(context, base.CurrEnemyChar, -MoveSpecialConstants.MaxMobility * ReverseCost);
			ShowSpecialEffectTips(0);
			_affected = true;
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
		if (!base.CanAffect || dataKey.CustomParam0 != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 150)
		{
			return 50;
		}
		return 0;
	}
}
