using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.DefenseAndAssist;

public class BaWangJieJiaGong : DefenseSkillBase
{
	private const sbyte ChangeNeiliAllocationUnit = 5;

	public BaWangJieJiaGong()
	{
	}

	public BaWangJieJiaGong(CombatSkillKey skillKey)
		: base(skillKey, 6505)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
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
		if ((outerMarkCount > 0 || innerMarkCount > 0) && defenderId == base.CharacterId && DomainManager.Combat.GetElement_CombatCharacterDict(attackerId).IsAlly != base.CombatChar.IsAlly)
		{
			ChangeNeiliAllocation(context, outerMarkCount, innerMarkCount);
		}
	}

	private void OnAddDirectFatalDamageMark(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, int outerMarkCount, int innerMarkCount, short combatSkillId)
	{
		if ((outerMarkCount > 0 || innerMarkCount > 0) && defenderId == base.CharacterId && DomainManager.Combat.GetElement_CombatCharacterDict(attackerId).IsAlly != base.CombatChar.IsAlly)
		{
			ChangeNeiliAllocation(context, outerMarkCount, innerMarkCount);
		}
	}

	private unsafe void ChangeNeiliAllocation(DataContext context, int outerMarkCount, int innerMarkCount)
	{
		if (!base.CanAffect)
		{
			return;
		}
		int changeNeiliAllocation = 5 * (outerMarkCount + innerMarkCount);
		NeiliAllocation selfNeiliAllocation = base.CombatChar.GetNeiliAllocation();
		NeiliAllocation enemyNeiliAllocation = base.CurrEnemyChar.GetNeiliAllocation();
		byte reduceType = (byte)(base.IsDirect ? 2 : 0);
		byte addType = (byte)((!base.IsDirect) ? 2 : 0);
		int selfChange = Math.Min(changeNeiliAllocation, selfNeiliAllocation.Items[(int)reduceType]);
		int enemyChange = Math.Min(changeNeiliAllocation, enemyNeiliAllocation.Items[(int)reduceType]);
		if (selfChange != 0 || enemyChange != 0)
		{
			if (selfChange > 0)
			{
				base.CombatChar.ChangeNeiliAllocation(context, reduceType, -selfChange);
				base.CombatChar.ChangeNeiliAllocation(context, addType, selfChange);
			}
			if (enemyChange > 0)
			{
				base.CurrEnemyChar.ChangeNeiliAllocation(context, reduceType, -enemyChange);
			}
			ShowSpecialEffectTipsOnceInFrame(0);
		}
	}
}
