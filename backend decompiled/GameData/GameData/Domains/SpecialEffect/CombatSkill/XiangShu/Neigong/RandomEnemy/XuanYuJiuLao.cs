using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.RandomEnemy;

public class XuanYuJiuLao : MinionBase
{
	private const sbyte NormalAttackValue = 1;

	private const sbyte SkillAttackValue = 5;

	private bool _affected;

	public XuanYuJiuLao()
	{
	}

	public XuanYuJiuLao(CombatSkillKey skillKey)
		: base(skillKey, 16008)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_affected = false;
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
		if (attackerId == base.CharacterId && (outerMarkCount > 0 || innerMarkCount > 0))
		{
			ChangeNeiliAllocation(context, combatSkillId);
		}
	}

	private void OnAddDirectFatalDamageMark(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, int outerMarkCount, int innerMarkCount, short combatSkillId)
	{
		if (attackerId == base.CharacterId && (outerMarkCount > 0 || innerMarkCount > 0))
		{
			ChangeNeiliAllocation(context, combatSkillId);
		}
	}

	private void ChangeNeiliAllocation(DataContext context, short combatSkillId)
	{
		if (!_affected && MinionBase.CanAffect)
		{
			int changeValue = ((combatSkillId < 0) ? 1 : 5);
			if (base.CombatChar.AbsorbNeiliAllocationRandom(context, base.CurrEnemyChar, changeValue))
			{
				ShowSpecialEffectTips(0);
				_affected = true;
				Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
			}
		}
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		_affected = false;
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}
}
