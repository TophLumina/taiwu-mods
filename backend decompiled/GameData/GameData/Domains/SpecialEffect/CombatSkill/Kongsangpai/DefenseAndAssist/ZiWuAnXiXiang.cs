using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.DefenseAndAssist;

public class ZiWuAnXiXiang : AssistSkillBase
{
	private const int ChangeNeiliAllocationValue = 5;

	private bool _affected;

	public ZiWuAnXiXiang()
	{
	}

	public ZiWuAnXiXiang(CombatSkillKey skillKey)
		: base(skillKey, 10704)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_affected = false;
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.RegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
		Events.RegisterHandler_AddDirectPoisonMark(AddDirectPoisonMark);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.UnRegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
		Events.UnRegisterHandler_AddDirectPoisonMark(AddDirectPoisonMark);
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (base.CanAffect && (outerMarkCount > 0 || innerMarkCount > 0) && attackerId == base.CharacterId && DomainManager.Combat.GetElement_CombatCharacterDict(defenderId).IsAlly != isAlly)
		{
			ChangeNeiliAllocation(context);
		}
	}

	private void OnAddDirectFatalDamageMark(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, int outerMarkCount, int innerMarkCount, short combatSkillId)
	{
		if (base.CanAffect && (outerMarkCount > 0 || innerMarkCount > 0) && attackerId == base.CharacterId && DomainManager.Combat.GetElement_CombatCharacterDict(defenderId).IsAlly != isAlly)
		{
			ChangeNeiliAllocation(context);
		}
	}

	private void AddDirectPoisonMark(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte poisonType, short skillId, int markCount)
	{
		if (base.CanAffect && markCount > 0 && attacker.GetId() == base.CharacterId)
		{
			ChangeNeiliAllocation(context);
		}
	}

	private void ChangeNeiliAllocation(DataContext context)
	{
		if (!_affected)
		{
			byte neiliAllocationType = (byte)context.Random.Next(0, 4);
			if (base.IsDirect)
			{
				base.CombatChar.ChangeNeiliAllocation(context, neiliAllocationType, 5);
			}
			else
			{
				DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).ChangeNeiliAllocation(context, neiliAllocationType, -5);
			}
			ShowSpecialEffectTips(0);
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
