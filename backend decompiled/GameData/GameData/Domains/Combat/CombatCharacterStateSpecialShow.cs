using System;
using Config;
using GameData.Common;

namespace GameData.Domains.Combat;

public class CombatCharacterStateSpecialShow : CombatCharacterStateBase
{
	private CombatCharacter _specialShowChar;

	private short _enterFrame;

	private short _castAniFrame;

	private short _hitFrame;

	private short _leaveFrame;

	public CombatCharacterStateSpecialShow(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.SpecialShow)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatChar.NeedEnterSpecialShow = false;
		_specialShowChar = CurrentCombatDomain.GetElement_CombatCharacterDict(CurrentCombatDomain.GetSpecialShowCombatCharId());
		_enterFrame = 34;
		_castAniFrame = 0;
		_hitFrame = 0;
		_leaveFrame = 0;
		int displayPos = CurrentCombatDomain.GetDisplayPosition(CombatChar.IsAlly, CombatItemUse.DefValue.UseThrowPoison.Distance);
		_specialShowChar.SetVisible(visible: true, context);
		_specialShowChar.SetDisplayPosition(displayPos, context);
		_specialShowChar.SetAnimationToLoop(_specialShowChar.GetIdleAni(), context);
	}

	public override void OnExit()
	{
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		if (_enterFrame > 0)
		{
			_enterFrame--;
			if (_enterFrame == 0)
			{
				DataContext context = CombatChar.GetDataContext();
				CombatItemUseItem throwConfig = CombatItemUse.Instance[(short)10];
				_specialShowChar.SetAnimationToPlayOnce(throwConfig.Animation, context);
				_specialShowChar.SetParticleToPlay(throwConfig.Particle, context);
				_specialShowChar.SetAttackSoundToPlay(throwConfig.Sound, context);
				_castAniFrame = (short)Math.Round(AnimDataCollection.Data[throwConfig.Animation].Duration * 60f);
				_hitFrame = (short)Math.Round(AnimDataCollection.Data[throwConfig.Animation].Events["act0"][0] * 60f);
			}
			return false;
		}
		if (_hitFrame > 0)
		{
			_hitFrame--;
			if (_hitFrame == 0)
			{
				DataContext context2 = CombatChar.GetDataContext();
				CombatCharacter enemyChar = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly);
				short stateId = (short)(142 + CurrentCombatDomain.CombatConfig.TemplateId - 164);
				enemyChar.SetAnimationToPlayOnce(enemyChar.GetBeHitAni(2), context2);
				CurrentCombatDomain.AddCombatState(context2, enemyChar, 0, stateId);
			}
		}
		if (_castAniFrame > 0)
		{
			_castAniFrame--;
			if (_castAniFrame == 0)
			{
				_specialShowChar.SetDisplayPosition(int.MinValue, CombatChar.GetDataContext());
				_leaveFrame = 48;
			}
			return false;
		}
		if (_leaveFrame > 0)
		{
			_leaveFrame--;
			if (_leaveFrame == 0)
			{
				_specialShowChar.SetVisible(visible: false, CombatChar.GetDataContext());
				CombatChar.StateMachine.TranslateState();
			}
			return false;
		}
		return false;
	}
}
