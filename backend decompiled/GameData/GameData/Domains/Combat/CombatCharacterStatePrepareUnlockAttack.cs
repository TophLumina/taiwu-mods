using GameData.Common;

namespace GameData.Domains.Combat;

public class CombatCharacterStatePrepareUnlockAttack : CombatCharacterStateBase
{
	public CombatCharacterStatePrepareUnlockAttack(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.PrepareUnlockAttack)
	{
	}

	public override void OnEnter()
	{
		DataContext context = CurrentCombatDomain.Context;
		int needUnlockAttackWeaponIndex = CombatChar.GetCombatReserveData().NeedUnlockWeaponIndex;
		CombatChar.SetNeedUnlockWeaponIndex(context, -1);
		if (CombatChar.GetCanUnlockAttack()[needUnlockAttackWeaponIndex])
		{
			DomainManager.Combat.UnlockAttack(context, CombatChar, needUnlockAttackWeaponIndex);
		}
		CombatChar.StateMachine.TranslateState();
	}
}
