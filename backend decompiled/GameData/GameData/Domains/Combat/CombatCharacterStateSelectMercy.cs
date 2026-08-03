using System;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Item;

namespace GameData.Domains.Combat;

public class CombatCharacterStateSelectMercy : CombatCharacterStateBase
{
	private EShowMercyOption _optionType;

	private EShowMercySelect _selected;

	public CombatCharacterStateSelectMercy(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.SelectMercy)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		base.OnEnter();
		DataContext context = CombatChar.GetDataContext();
		CombatChar.NeedSelectMercyOption = false;
		_optionType = ((!CombatChar.IsAlly) ? EShowMercyOption.EnemyShowMercy : (CurrentCombatDomain.IsInfectedCombat() ? EShowMercyOption.FuyuSword : EShowMercyOption.PlayerShowMercy));
		CurrentCombatDomain.SetShowMercyOption(context, _optionType);
		_selected = EShowMercySelect.Unselected;
		CurrentCombatDomain.SetSelectedMercyOption(context, _selected);
	}

	public override void OnExit()
	{
		DataContext context = CombatChar.GetDataContext();
		CurrentCombatDomain.SetShowMercyOption(context, EShowMercyOption.Invalid);
		if (CurrentCombatDomain.IsInCombat())
		{
			CurrentCombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, int.MinValue);
		}
		base.OnExit();
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		DataContext context = CombatChar.GetDataContext();
		EShowMercySelect selected = (EShowMercySelect)CurrentCombatDomain.GetSelectedMercyOption();
		if (selected <= EShowMercySelect.Unselected || _selected > EShowMercySelect.Unselected)
		{
			return false;
		}
		_selected = selected;
		if (selected == EShowMercySelect.Cancel)
		{
			ApplyFailEffect();
		}
		else if (_optionType == EShowMercyOption.FuyuSword)
		{
			CombatItemUseItem fuyuConfig = CombatItemUse.DefValue.PrepareFuyuSword;
			CombatChar.SetAnimationToPlayOnce(fuyuConfig.Animation, context);
			CombatChar.SetParticleToPlay(fuyuConfig.Particle, context);
			CombatChar.SetSkillSoundToPlay(fuyuConfig.Sound, context);
			CombatChar.SetAnimationToLoop(null, context);
			DelayCall(OnPreparedFuyu, Config.Misc.DefValue.FuyuSwordFragment.UseFrame);
		}
		else
		{
			string flashAni = "C_007_1";
			DelayCall(OnFlash, AnimDataCollection.GetDurationFrame(flashAni));
			CombatChar.SetAnimationToPlayOnce(flashAni, context);
			CombatChar.SetAnimationToLoop(null, context);
			CombatChar.SetSkillSoundToPlay("se_combat_preskill", context);
		}
		return false;
	}

	private void OnFlash()
	{
		DataContext context = CurrentCombatDomain.Context;
		sbyte trickType = CombatChar.GetWeaponTricks()[CombatChar.GetWeaponTrickIndex()];
		GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetElement_Weapons(CurrentCombatDomain.GetUsingWeaponKey(CombatChar).Id);
		PrepareAttackEffect prepareAni = CombatChar.GetPrepareAttackAni(trickType, weapon.GetWeaponAction());
		DelayCall(OnPrepared, AnimDataCollection.GetDurationFrame(prepareAni.FullAniName));
		CombatChar.SetAnimationToPlayOnce(prepareAni.AniName, context);
	}

	private void OnPrepared()
	{
		DataContext context = CurrentCombatDomain.Context;
		sbyte trickType = CombatChar.GetWeaponTricks()[CombatChar.GetWeaponTrickIndex()];
		int weaponIndex = CombatChar.GetUsingWeaponIndex();
		BossItem bossConfig = CombatChar.BossConfig;
		sbyte displayDistance = ((bossConfig != null) ? bossConfig.AttackDistances[CombatChar.GetBossPhase()][weaponIndex] : (CombatChar.AnimalConfig?.AttackDistances[weaponIndex] ?? Config.TrickType.Instance[trickType].AttackDistance[0]));
		int delayFrame = 0;
		if (displayDistance > 0 && displayDistance != CurrentCombatDomain.GetCurrentDistance())
		{
			delayFrame = 9;
			CurrentCombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, CurrentCombatDomain.GetDisplayPosition(CombatChar.IsAlly, displayDistance));
		}
		DelayCall(PlayAttackAnimation, delayFrame);
	}

	private void PlayAttackAnimation()
	{
		DataContext context = CombatChar.GetDataContext();
		int weaponId = CurrentCombatDomain.GetUsingWeaponKey(CombatChar).Id;
		GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetElement_Weapons(weaponId);
		sbyte trickType = CombatChar.GetWeaponTricks()[CombatChar.GetWeaponTrickIndex()];
		AttackEffect attackEffect = CombatChar.GetAttackEffect(weapon, trickType);
		DelayCall(ApplyFailEffect, AnimDataCollection.GetEventFrame(attackEffect.FullAniName, "act0"));
		DelayCall(OnAttacked, AnimDataCollection.GetDurationFrame(attackEffect.FullAniName));
		CombatChar.SetAnimationToPlayOnce(attackEffect.AniName, context);
		CombatChar.SetParticleToPlay(attackEffect.Particle, context);
		CombatChar.SetAttackSoundToPlay(attackEffect.Sound, context);
	}

	private void OnAttacked()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatChar.SetAnimationToLoop(CombatChar.GetIdleAni(), context);
	}

	private void ApplyFailEffect()
	{
		if (_optionType != EShowMercyOption.FuyuSword || _selected == EShowMercySelect.Cancel)
		{
			SetFailAnimation();
		}
		DelayCall(OnSettlement, (short)(Math.Ceiling(DomainManager.Combat.GetTimeScale()) + 1.0));
	}

	private void SetFailAnimation()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatCharacter enemyChar = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly);
		bool kill = _selected != EShowMercySelect.Cancel;
		var (anim, particle, sound) = CurrentCombatDomain.GetFailAnimationAndSound(context, CombatChar, kill);
		if (kill)
		{
			int weaponId = CurrentCombatDomain.GetUsingWeaponKey(CombatChar).Id;
			GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetElement_Weapons(weaponId);
			WeaponItem configData = Config.Weapon.Instance[weapon.GetTemplateId()];
			CurrentCombatDomain.PlayHitSound(context, enemyChar, configData);
			CurrentCombatDomain.ClearBurstBodyPartFlawAndAcupoint(context, enemyChar, anim);
		}
		else
		{
			CombatChar.PlayWinAnimation(context);
		}
		enemyChar.SetAnimationToPlayOnce(anim, context);
		if (!string.IsNullOrEmpty(particle))
		{
			enemyChar.SetParticleToPlay(particle, context);
		}
		if (!string.IsNullOrEmpty(sound))
		{
			enemyChar.SetDieSoundToPlay(sound, context);
		}
	}

	private void OnSettlement()
	{
		DataContext context = CombatChar.GetDataContext();
		CurrentCombatDomain.CombatSettlement(context, (sbyte)(CombatChar.IsAlly ? 3 : 2));
		CombatChar.StateMachine.TranslateState();
	}

	private void OnPreparedFuyu()
	{
		DataContext context = CurrentCombatDomain.Context;
		CombatItemUseItem useConfig = CombatItemUse.DefValue.UseFuyuSword;
		int delayFrame = 0;
		short displayDistance = useConfig.Distance;
		if (displayDistance > 0 && displayDistance != CurrentCombatDomain.GetCurrentDistance())
		{
			delayFrame = 9;
			CurrentCombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, CurrentCombatDomain.GetDisplayPosition(CombatChar.IsAlly, displayDistance));
		}
		DelayCall(PlayUseFuyuAnim, delayFrame);
	}

	private void PlayUseFuyuAnim()
	{
		DataContext context = CurrentCombatDomain.Context;
		CombatItemUseItem useConfig = CombatItemUse.DefValue.UseFuyuSword;
		CombatChar.SetParticleToPlay(useConfig.Particle, context);
		CombatChar.SetSkillSoundToPlay(useConfig.Sound, context);
		CombatChar.SetAnimationToPlayOnce(useConfig.Animation, context);
		DelayCall(PlayFuyuHitAnim, AnimDataCollection.GetEventFrame(useConfig.Animation, "act0"));
		DelayCall(PlayFuyuCastAnim, AnimDataCollection.GetDurationFrame(useConfig.Animation));
	}

	private void PlayFuyuHitAnim()
	{
		DataContext context = CurrentCombatDomain.Context;
		CombatItemUseItem useConfig = CombatItemUse.DefValue.UseFuyuSword;
		CombatCharacter enemyChar = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly);
		if (!string.IsNullOrEmpty(useConfig.BeHitAnimation))
		{
			enemyChar.SetAnimationToPlayOnce(useConfig.BeHitAnimation, context);
		}
	}

	private void PlayFuyuCastAnim()
	{
		DataContext context = CurrentCombatDomain.Context;
		CombatCharacter enemyChar = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly);
		DomainManager.Combat.AppendGetChar(enemyChar.GetId());
		DomainManager.Combat.AppendEvaluation((sbyte)((CombatChar.GetCharacter().GetConsummateLevel() > enemyChar.GetCharacter().GetConsummateLevel()) ? 23 : 24));
		DomainManager.TaiwuEvent.SetListenerEventActionBoolArg("CombatOver", "UsedFuyuSwordInCombat", value: true);
		Events.RaiseUsedFuyuSword(context, CombatChar);
		CurrentCombatDomain.EndCombat(context, enemyChar, flee: false, playAni: false);
	}
}
