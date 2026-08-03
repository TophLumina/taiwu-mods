using Config;
using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.Combat;

public class CombatCharacterStateUnlockAttack : CombatCharacterStateBase
{
	private const string ReadyAnimationName = "J_ready";

	private const string ReadyParticleName = "Particle_J_ready";

	private int _initWeaponIndex;

	public CombatCharacterStateUnlockAttack(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.UnlockAttack)
	{
		IsUpdateOnPause = true;
		RequireDelayFallen = true;
	}

	public override void OnEnter()
	{
		base.OnEnter();
		_initWeaponIndex = CombatChar.GetUsingWeaponIndex();
		InvokeAnimations();
	}

	public override void OnExit()
	{
		DataContext context = CurrentCombatDomain.Context;
		CombatChar.UnlockWeaponIndex = -1;
		CombatChar.SetUsingWeaponIndex(_initWeaponIndex, context);
		CurrentCombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, int.MinValue);
	}

	private void InvokeAnimations()
	{
		CombatChar.NeedUnlockAttack = false;
		if (CombatChar.UnlockEffectId < 0)
		{
			PredefinedLog.Show(8, $"{CombatChar} invoke unlock attack on {CombatChar.UnlockWeapon.GetName()}");
			CombatChar.StateMachine.TranslateState();
		}
		else
		{
			DataContext context = CurrentCombatDomain.Context;
			CombatChar.SetUsingWeaponIndex(CombatChar.UnlockWeaponIndex, context);
			CombatChar.SetAttackSoundToPlay(CombatChar.UnlockEffect.Sound, context);
			CombatChar.SetAnimationToPlayOnce("J_ready", context);
			CombatChar.SetParticleToPlay("Particle_J_ready", context);
			CurrentCombatDomain.ShowSpecialEffectTips(CombatChar.GetId(), CombatChar.UnlockEffect.EffectId, 0);
			DelayCall(OnReady, AnimDataCollection.GetDurationFrame("J_ready"));
		}
	}

	private void OnReady()
	{
		CalcUnlockEffect();
		DataContext context = CurrentCombatDomain.Context;
		WeaponUnlockEffectItem effect = CombatChar.UnlockEffect;
		Events.RaiseNormalAttackPrepareEnd(context, CombatChar.GetId(), CombatChar.IsAlly);
		CombatChar.SetAnimationToPlayOnce(effect.Animation, context);
		CombatChar.SetParticleToPlay(effect.Particle, context);
		CurrentCombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, CurrentCombatDomain.GetDisplayPosition(CombatChar.IsAlly, effect.DisplayPosition[0]));
		DelayCall(OnAct1, AnimDataCollection.GetEventFrame(effect.Animation, "act1"));
		DelayCall(OnAct2, AnimDataCollection.GetEventFrame(effect.Animation, "act2"));
		DelayCall(OnAct3, AnimDataCollection.GetEventFrame(effect.Animation, "act3"));
		DelayCall(FinishAttack, AnimDataCollection.GetDurationFrame(effect.Animation));
	}

	private void FinishAttack()
	{
		DataContext context = CurrentCombatDomain.Context;
		Events.RaiseUnlockAttackEnd(context, CombatChar);
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!CombatChar.IsAlly, tryGetCoverCharacter: true);
		Events.RaiseNormalAttackAllEnd(context, CombatChar, enemyChar);
		CombatCharacterStateType properState = CombatChar.StateMachine.GetProperState();
		if (properState == CombatCharacterStateType.UnlockAttack)
		{
			InvokeAnimations();
		}
		else
		{
			CombatChar.StateMachine.TranslateState(properState);
		}
	}

	private void CalcUnlockEffect()
	{
		DataContext context = CurrentCombatDomain.Context;
		CombatCharacter enemyChar = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly);
		if (CombatChar.UnlockEffect.ClearAgile)
		{
			CurrentCombatDomain.ClearAffectingAgileSkillByEffect(context, enemyChar, CombatChar);
		}
		if (CombatChar.UnlockEffect.ClearDefense)
		{
			CurrentCombatDomain.ClearAffectingDefenseSkill(context, enemyChar);
		}
	}

	private void OnAct1()
	{
		CalcAttackEffect(1);
	}

	private void OnAct2()
	{
		CalcAttackEffect(2);
	}

	private void OnAct3()
	{
		CalcAttackEffect(3);
	}

	private void CalcAttackEffect(int index)
	{
		CurrentCombatDomain.CalcUnlockAttack(CombatChar, index - 1);
		DataContext context = CurrentCombatDomain.Context;
		CurrentCombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, CurrentCombatDomain.GetDisplayPosition(CombatChar.IsAlly, CombatChar.UnlockEffect.DisplayPosition[index]));
	}
}
