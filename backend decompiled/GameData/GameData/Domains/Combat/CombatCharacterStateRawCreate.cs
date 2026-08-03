using GameData.Common;

namespace GameData.Domains.Combat;

public class CombatCharacterStateRawCreate : CombatCharacterStateBase
{
	public CombatCharacterStateRawCreate(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.RawCreate)
	{
		IsUpdateOnPause = true;
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		if (CombatChar.IsAlly && CombatChar.AnyRawCreate)
		{
			return false;
		}
		DataContext context = CurrentCombatDomain.Context;
		if (CombatChar.AnyRawCreate)
		{
			CombatChar.AutoAllRawCreate(context);
		}
		CombatChar.StateMachine.TranslateState();
		return false;
	}
}
