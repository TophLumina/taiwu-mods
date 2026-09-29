using Config;
using GameData.Common;

namespace GameData.Domains.Combat;

public class CombatCharacterStateSpecialShow : CombatCharacterStateBase
{
	private CombatCharacter _specialShowChar;

	public CombatCharacterStateSpecialShow(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.SpecialShow)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		base.OnEnter();
		DataContext context = CombatChar.GetDataContext();
		CombatChar.NeedEnterSpecialShow = false;
		_specialShowChar = CurrentCombatDomain.GetElement_CombatCharacterDict(CurrentCombatDomain.GetSpecialShowCombatCharId());
		int displayPos = CurrentCombatDomain.GetDisplayPosition(CombatChar.IsAlly, CombatItemUse.DefValue.UseThrowPoison.Distance);
		_specialShowChar.SetVisible(visible: true, context);
		_specialShowChar.SetDisplayPosition(displayPos, context);
		_specialShowChar.SetAnimationToLoop(_specialShowChar.GetIdleAni(), context);
		DelayCall(DelayedEnter, 34);
	}

	private void DelayedEnter()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatItemUseItem throwConfig = CombatItemUse.Instance[(short)10];
		_specialShowChar.SetAnimationToPlayOnce(throwConfig.Animation, context);
		_specialShowChar.SetParticleToPlay(throwConfig.Particle, context);
		_specialShowChar.SetAttackSoundToPlay(throwConfig.Sound, context);
		DelayCall(DelayedHit, AnimDataCollection.GetEventFrame(throwConfig.Animation, "act0"));
		DelayCall(DelayedCast, AnimDataCollection.GetDurationFrame(throwConfig.Animation));
	}

	private void DelayedHit()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatCharacter enemyChar = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly);
		short stateId = (short)(142 + CurrentCombatDomain.CombatConfig.TemplateId - 164);
		enemyChar.SetAnimationToPlayOnce(enemyChar.GetBeHitAni(2), context);
		CurrentCombatDomain.AddCombatState(context, enemyChar, 0, stateId);
	}

	private void DelayedCast()
	{
		_specialShowChar.SetDisplayPosition(int.MinValue, CombatChar.GetDataContext());
		DelayCall(DelayedLeave, 48);
	}

	private void DelayedLeave()
	{
		_specialShowChar.SetVisible(visible: false, CombatChar.GetDataContext());
		CombatChar.StateMachine.TranslateState();
	}
}
