using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.DefenseAndAssist;

public class SuiSuoYu : AssistSkillBase
{
	private const sbyte AddNeiliAllocation = 5;

	private const sbyte ReduceNeiliAllocation = -3;

	private const sbyte BuffOdds = 66;

	private bool _affected;

	private bool _compensationAdd;

	public SuiSuoYu()
	{
	}

	public SuiSuoYu(CombatSkillKey skillKey)
		: base(skillKey, 11700)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_affected = false;
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.RegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.UnRegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if ((outerMarkCount <= 0 && innerMarkCount <= 0) || !base.CanAffect)
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
			DoEffect(context);
		}
	}

	private void OnAddDirectFatalDamageMark(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, int outerMarkCount, int innerMarkCount, short combatSkillId)
	{
		if ((outerMarkCount <= 0 && innerMarkCount <= 0) || !base.CanAffect)
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
			DoEffect(context);
		}
	}

	private void DoEffect(DataContext context)
	{
		if (!_affected)
		{
			bool addNeiliAllocation = _compensationAdd || context.Random.CheckPercentProb(66);
			_compensationAdd = !addNeiliAllocation;
			List<sbyte> trickRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
			sbyte addValue = (sbyte)(addNeiliAllocation ? 5 : (-3));
			if (base.CombatChar.ChangeNeiliAllocationRandom(context, addValue))
			{
				ShowSpecialEffectTips(0);
			}
			trickRandomPool.Clear();
			trickRandomPool.AddRange(base.CombatChar.GetTricks().Tricks.Values);
			trickRandomPool.RemoveAll(base.CombatChar.IsTrickUsable);
			if (trickRandomPool.Count > 0)
			{
				DomainManager.Combat.RemoveTrick(context, base.CombatChar, trickRandomPool.GetRandom(context.Random), 1);
				ShowSpecialEffectTips(1);
			}
			ObjectPool<List<sbyte>>.Instance.Return(trickRandomPool);
			ShowEffectTips(context);
			_affected = true;
			Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		}
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		_affected = false;
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}
}
