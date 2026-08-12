using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.Combat;

public class CombatCharacterStateMachine
{
	private Dictionary<CombatCharacterStateType, CombatCharacterStateBase> _allStates = new Dictionary<CombatCharacterStateType, CombatCharacterStateBase>();

	private CombatCharacterStateBase _currentState;

	private CombatDomain _currentCombatDomain;

	private CombatCharacter _combatChar;

	private ulong _lastUpdateCombatFrame;

	public void Init(CombatDomain combatDomain, CombatCharacter combatChar)
	{
		_currentState = null;
		_lastUpdateCombatFrame = ulong.MaxValue;
		_currentCombatDomain = combatDomain;
		_combatChar = combatChar;
		_allStates.Clear();
		RegisterState(new CombatCharacterStateIdle(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateSelectChangeTrick(combatDomain, combatChar));
		RegisterState(new CombatCharacterStatePrepareAttack(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateBreakAttack(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateUnlockAttack(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateRawCreate(combatDomain, combatChar));
		RegisterState(new CombatCharacterStatePrepareUnlockAttack(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateAttack(combatDomain, combatChar));
		RegisterState(new CombatCharacterStatePrepareSkill(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateCastSkill(combatDomain, combatChar));
		RegisterState(new CombatCharacterStatePrepareOtherAction(combatDomain, combatChar));
		RegisterState(new CombatCharacterStatePrepareUseItem(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateUseItem(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateSelectMercy(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateDelaySettlement(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateChangeCharacter(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateTeammateCommand(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateChangeBossPhase(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateAnimalAttack(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateJumpMove(combatDomain, combatChar));
		RegisterState(new CombatCharacterStateSpecialShow(combatDomain, combatChar));
	}

	public void OnUpdate()
	{
		if (_currentState != null)
		{
			if (_currentState.IsUpdateOnPause)
			{
				_currentState.OnUpdate();
			}
			else if (_lastUpdateCombatFrame != _currentCombatDomain.GetCombatFrame())
			{
				_lastUpdateCombatFrame = _currentCombatDomain.GetCombatFrame();
				_currentState.OnUpdate();
			}
			Events.RaiseCombatStateMachineUpdateEnd(_currentCombatDomain.Context, _combatChar);
		}
	}

	public CombatCharacterStateBase GetCurrentState()
	{
		return _currentState;
	}

	public CombatCharacterStateType GetCurrentStateType()
	{
		return GetCurrentState().StateType;
	}

	public void TranslateState()
	{
		TranslateState(GetProperState());
	}

	public void TranslateState(CombatCharacterStateType stateType)
	{
		if (_allStates == null)
		{
			throw new Exception("State machine not inited");
		}
		if (!_allStates.ContainsKey(stateType))
		{
			return;
		}
		CombatCharacterStateBase currentState = _currentState;
		if (currentState != null && currentState.StateType == stateType)
		{
			return;
		}
		CombatCharacterStateBase lastState = _currentState;
		_combatChar.MoveData.Reset();
		_currentState?.OnExit();
		_currentState = _allStates[stateType];
		if (_currentCombatDomain.Pause != _currentState.IsUpdateOnPause)
		{
			DataContext context = _combatChar.GetDataContext();
			_currentCombatDomain.EnsurePauseState();
			if (_currentCombatDomain.IsInCombat())
			{
				_currentCombatDomain.UpdateAllTeammateCommandUsable(context, isAlly: true, -1);
				_currentCombatDomain.UpdateAllTeammateCommandUsable(context, isAlly: false, -1);
			}
		}
		_currentState.OnEnter();
		if (_currentCombatDomain.IsInCombat())
		{
			DataContext context2 = _combatChar.GetDataContext();
			if (lastState != null && lastState.StateType != CombatCharacterStateType.Idle && stateType == CombatCharacterStateType.Idle)
			{
				_currentCombatDomain.UpdateAllCommandAvailability(context2, _combatChar);
			}
			else if (stateType == CombatCharacterStateType.PrepareSkill)
			{
				_currentCombatDomain.UpdateAllTeammateCommandUsable(context2, _combatChar.IsAlly, -1);
			}
		}
	}

	public void RegisterState(CombatCharacterStateBase state)
	{
		if (state != null && !_allStates.ContainsKey(state.StateType))
		{
			_allStates.Add(state.StateType, state);
		}
	}

	public CombatCharacterStateType GetProperState()
	{
		if (!_currentCombatDomain.IsInCombat())
		{
			return CombatCharacterStateType.Invalid;
		}
		if (_combatChar.NeedChangeBossPhase && _currentCombatDomain.GetCombatCharacter(!_combatChar.IsAlly).ChangeCharId < 0)
		{
			return CombatCharacterStateType.ChangeBossPhase;
		}
		if (_combatChar.NeedSelectMercyOption)
		{
			return CombatCharacterStateType.SelectMercy;
		}
		if (_combatChar.NeedDelaySettlement)
		{
			return CombatCharacterStateType.DelaySettlement;
		}
		if (_combatChar.AnyRawCreate)
		{
			return CombatCharacterStateType.RawCreate;
		}
		if (_combatChar.NeedUnlockAttack)
		{
			return CombatCharacterStateType.UnlockAttack;
		}
		if (_combatChar.GetCombatReserveData().NeedUnlockWeaponIndex >= 0)
		{
			return CombatCharacterStateType.PrepareUnlockAttack;
		}
		if (_combatChar.NeedBreakAttack)
		{
			return CombatCharacterStateType.BreakAttack;
		}
		if (_combatChar.NeedNormalAttack)
		{
			return CombatCharacterStateType.PrepareAttack;
		}
		if (_combatChar.GetPreparingSkillId() >= 0 || _combatChar.NeedUseSkillFreeId >= 0 || (_combatChar.NeedUseSkillId >= 0 && (_combatChar.GetAffectingDefendSkillId() < 0 || DomainManager.SpecialEffect.ModifyData(_combatChar.GetId(), _combatChar.NeedUseSkillId, 223, dataValue: false))))
		{
			return CombatCharacterStateType.PrepareSkill;
		}
		if (_combatChar.NeedShowChangeTrick && !_combatChar.PreparingOrDoingTeammateCommand())
		{
			return CombatCharacterStateType.SelectChangeTrick;
		}
		if (_combatChar.NeedAnimalAttack)
		{
			return CombatCharacterStateType.AnimalAttack;
		}
		if (_combatChar.GetPreparingOtherAction() >= 0 || _combatChar.NeedUseOtherAction != -1 || _combatChar.NeedForceFlee)
		{
			return CombatCharacterStateType.PrepareOtherAction;
		}
		if (_combatChar.NeedUseItem.IsValid() || _combatChar.GetPreparingItem().IsValid())
		{
			return CombatCharacterStateType.PrepareUseItem;
		}
		if (_combatChar.NeedPauseJumpMove)
		{
			return CombatCharacterStateType.JumpMove;
		}
		if (_combatChar.NeedEnterSpecialShow)
		{
			return CombatCharacterStateType.SpecialShow;
		}
		return CombatCharacterStateType.Idle;
	}
}
