using GameData.Common;

namespace GameData.Domains.Combat;

public class CombatCharacterStateIdle : CombatCharacterStateBase
{
	public CombatCharacterStateIdle(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.Idle)
	{
	}

	public override void OnEnter()
	{
		DataContext context = CombatChar.GetDataContext();
		CurrentCombatDomain.SetProperLoopAniAndParticle(context, CombatChar);
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		DataContext context = CombatChar.GetDataContext();
		if (CombatChar.NeedChangeWeaponIndex >= 0 && !CombatChar.PreparingTeammateCommand())
		{
			CurrentCombatDomain.ChangeWeapon(context, CombatChar, CombatChar.NeedChangeWeaponIndex);
		}
		return false;
	}
}
