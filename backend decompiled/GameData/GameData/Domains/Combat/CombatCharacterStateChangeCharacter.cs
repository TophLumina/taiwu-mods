using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public class CombatCharacterStateChangeCharacter : CombatCharacterStateBase
{
	private short _leftWaitFrame;

	public CombatCharacterStateChangeCharacter(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.ChangeCharacter)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		_leftWaitFrame = (short)Math.Round(90.0);
		DataContext context = CombatChar.GetDataContext();
		CombatChar.SetAnimationToPlayOnce("M_003", context);
		CombatChar.SetAnimationToLoop(CombatChar.GetIdleAni(), context);
		if (!CurrentCombatDomain.IsMainCharacter(CombatChar))
		{
			CombatChar.SetBreathValue(15000, context);
			CombatChar.SetStanceValue(2000, context);
			CombatChar.SetMobilityValue(MoveSpecialConstants.MaxMobility * 50 / 100, context);
			CombatChar.ClearAllDoingOrReserveCommand(context);
			CombatChar.ClearAllSound(context);
			CombatChar.ClearMindRhythmAndUpheaval(context);
			CombatChar.SetExecutingTeammateCommand(CombatChar.ExecutingTeammateCommandConfig.TemplateId, context);
			int teammateIndex = CurrentCombatDomain.GetCharacterList(CombatChar.IsAlly).IndexOf(CombatChar.GetId()) - 1;
			CurrentCombatDomain.GetMainCharacter(CombatChar.IsAlly).TeammateHasCommand[teammateIndex] = true;
		}
	}

	public override bool OnUpdate()
	{
		_leftWaitFrame--;
		if (_leftWaitFrame == 0)
		{
			DataContext context = CombatChar.GetDataContext();
			if (!CurrentCombatDomain.IsMainCharacter(CombatChar))
			{
				CombatChar.ResetTeammateCommandLeftTime(context);
			}
			else
			{
				bool selfFallen = CurrentCombatDomain.IsCharacterFallen(CombatChar);
				CombatCharacter enemyChar = CurrentCombatDomain.GetMainCharacter(!CombatChar.IsAlly);
				bool endCombat = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly).ChangeCharId < 0 && (selfFallen || CurrentCombatDomain.IsCharacterFallen(enemyChar));
				int[] charList = CurrentCombatDomain.GetCharacterList(CombatChar.IsAlly);
				for (int i = 1; i < charList.Length; i++)
				{
					if (charList[i] >= 0)
					{
						CurrentCombatDomain.GetElement_CombatCharacterDict(charList[i]).SetVisible(visible: false, context);
					}
				}
				if (endCombat)
				{
					CurrentCombatDomain.EndCombat(context, selfFallen ? CombatChar : enemyChar);
				}
			}
			CombatChar.StateMachine.TranslateState();
			Events.RaiseCombatCharChanged(context, CombatChar.IsAlly);
		}
		return false;
	}
}
