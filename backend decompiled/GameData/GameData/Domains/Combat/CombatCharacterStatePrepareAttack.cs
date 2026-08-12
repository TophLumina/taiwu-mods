using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Item;

namespace GameData.Domains.Combat;

public class CombatCharacterStatePrepareAttack : CombatCharacterStateBase
{
	public enum EType
	{
		Normal,
		NoPrepare,
		Prefer
	}

	private int _leftPrepareFrame;

	public CombatCharacterStatePrepareAttack(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.PrepareAttack)
	{
	}

	public override void OnEnter()
	{
		DataContext context = CombatChar.GetDataContext();
		switch (OnEnterCheckAttackType(context))
		{
		case EType.Prefer:
			CombatChar.StateMachine.TranslateState();
			return;
		case EType.NoPrepare:
			Events.RaiseNormalAttackPrepareEnd(context, CombatChar.GetId(), CombatChar.IsAlly);
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.Attack);
			return;
		}
		_leftPrepareFrame = CombatChar.CalcNormalAttackStartupFrames();
		Weapon weapon = DomainManager.Item.GetElement_Weapons(CurrentCombatDomain.GetUsingWeaponKey(CombatChar).Id);
		sbyte aniIndex = weapon.GetWeaponAction();
		sbyte trickType = CombatChar.GetAttackingTrickType();
		PrepareAttackEffect prepareAni = CombatChar.GetPrepareAttackAni(trickType, aniIndex);
		float aniTime = AnimDataCollection.Data[prepareAni.FullAniName].Duration;
		float prepareTime = (float)_leftPrepareFrame / 60f;
		CombatChar.SetAnimationTimeScale(aniTime / prepareTime, context);
		CombatChar.SetAnimationToPlayOnce(prepareAni.AniName, context);
		CombatChar.SetAnimationToLoop(null, context);
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		_leftPrepareFrame--;
		if (_leftPrepareFrame <= 0)
		{
			DataContext context = CombatChar.GetDataContext();
			Events.RaiseNormalAttackPrepareEnd(context, CombatChar.GetId(), CombatChar.IsAlly);
			CombatChar.SetAnimationTimeScale(1f, context);
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.Attack);
		}
		return false;
	}

	private EType OnEnterCheckAttackType(DataContext context)
	{
		bool noPrepare = false;
		if (CombatChar.NeedNormalAttackSkipPrepare > 0)
		{
			CombatChar.NeedNormalAttackSkipPrepare--;
			CombatChar.IsAutoNormalAttacking = true;
			noPrepare = true;
		}
		else if (CombatChar.NeedChangeTrickAttack)
		{
			CombatChar.NeedChangeTrickAttack = false;
			CombatChar.SetChangeTrickAttack(changeTrickAttack: true, context);
			noPrepare = true;
		}
		else if (CombatChar.NeedFreeAttack)
		{
			CombatChar.NeedFreeAttack = false;
			CombatChar.IsAutoNormalAttacking = true;
		}
		else
		{
			if (TryChangeToUnlockAttack(context))
			{
				return EType.Prefer;
			}
			if (CombatChar.NeedNormalAttackImmediate)
			{
				CombatChar.NeedNormalAttackImmediate = false;
			}
			else
			{
				CombatChar.SetReserveNormalAttack(reserveNormalAttack: false, context);
			}
		}
		if (!noPrepare && CombatChar.NextAttackNoPrepare)
		{
			CombatChar.NextAttackNoPrepare = false;
			noPrepare = true;
		}
		sbyte trickType = (CombatChar.GetChangeTrickAttack() ? CombatChar.ChangeTrickType : CombatChar.GetWeaponTricks()[CombatChar.GetWeaponTrickIndex()]);
		trickType = (sbyte)DomainManager.SpecialEffect.ModifyData(CombatChar.GetId(), -1, 83, trickType);
		CombatChar.SetAttackingTrickType(trickType, context);
		return noPrepare ? EType.NoPrepare : EType.Normal;
	}

	private bool TryChangeToUnlockAttack(DataContext context)
	{
		int usingIndex = CombatChar.GetUsingWeaponIndex();
		if (!CombatChar.CanUnlockAttackByConfig(usingIndex))
		{
			return false;
		}
		if (!DomainManager.SpecialEffect.ModifyData(CombatChar.GetId(), -1, 305, dataValue: false))
		{
			return false;
		}
		CombatChar.NeedNormalAttackImmediate = false;
		CombatChar.SetReserveNormalAttack(reserveNormalAttack: false, context);
		CombatChar.NeedUnlockAttack = true;
		CombatChar.UnlockWeaponIndex = usingIndex;
		return true;
	}
}
