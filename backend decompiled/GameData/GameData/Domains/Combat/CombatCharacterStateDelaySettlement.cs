using System;
using GameData.Common;

namespace GameData.Domains.Combat;

public class CombatCharacterStateDelaySettlement : CombatCharacterStateBase
{
	private short _leftFrame;

	public CombatCharacterStateDelaySettlement(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.DelaySettlement)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		_leftFrame = (short)(Math.Ceiling(DomainManager.Combat.GetTimeScale()) + 1.0);
	}

	public override void OnExit()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatChar.NeedDelaySettlement = false;
		CurrentCombatDomain.SetShowMercyOption(context, EShowMercyOption.Invalid);
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		if (_leftFrame > 0)
		{
			_leftFrame--;
			if (_leftFrame == 0)
			{
				CurrentCombatDomain.CombatSettlement(CombatChar.GetDataContext(), (sbyte)(CombatChar.IsAlly ? 3 : 2));
				CombatChar.StateMachine.TranslateState();
			}
		}
		return false;
	}
}
