using GameData.Common;

namespace GameData.Domains.Combat;

public class CombatCharacterStateSelectChangeTrick : CombatCharacterStateBase
{
	public CombatCharacterStateSelectChangeTrick(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.SelectChangeTrick)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		CombatChar.SetChangingTrick(changingTrick: true, CombatChar.GetDataContext());
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		if (!CombatChar.NeedShowChangeTrick || !CombatChar.GetCanChangeTrick())
		{
			DataContext context = CombatChar.GetDataContext();
			if (CombatChar.NeedShowChangeTrick)
			{
				CombatChar.SetNeedShowChangeTrick(context, needShowChangeTrick: false);
			}
			CombatChar.SetChangingTrick(changingTrick: false, context);
			CombatChar.StateMachine.TranslateState();
		}
		return false;
	}
}
