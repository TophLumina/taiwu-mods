using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.DefenseAndAssist;

public class LuanQingZhang : DefenseSkillBase
{
	private const sbyte RequireDistance = 70;

	private const short AddQiDisorderFrame = 100;

	private const short AddQiDisorder = 100;

	private short _frameCounter;

	public LuanQingZhang()
	{
	}

	public LuanQingZhang(CombatSkillKey skillKey)
		: base(skillKey, 12701)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_frameCounter = 0;
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.IsAlly != base.CombatChar.IsAlly || DomainManager.Combat.Pause)
		{
			return;
		}
		_frameCounter++;
		if (_frameCounter < 100)
		{
			return;
		}
		_frameCounter = 0;
		short distance = DomainManager.Combat.GetCurrentDistance();
		if (!(base.IsDirect ? (distance > 70) : (distance < 70)) && base.CanAffect)
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			if (enemyChar.GetHitValue(3, -1, 0, -1) + enemyChar.GetAvoidValue(3, -1, -1) <= base.CombatChar.GetHitValue(3, -1, 0, -1) + base.CombatChar.GetAvoidValue(3, -1, -1))
			{
				DomainManager.Combat.ChangeDisorderOfQiRandomRecovery(context, DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly), 100);
				ShowSpecialEffectTips(0);
			}
		}
	}
}
