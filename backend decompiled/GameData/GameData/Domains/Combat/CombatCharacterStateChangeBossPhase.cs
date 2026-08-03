using System;
using System.Collections.Generic;
using Config;
using GameData.Common;

namespace GameData.Domains.Combat;

public class CombatCharacterStateChangeBossPhase : CombatCharacterStateBase
{
	private const float ChangePhaseEffectTime = 10f;

	private const string SceneRuptureSound = "ui_battle_rupture";

	private short _setDataFrame;

	private short _setIdleAniFrame;

	private short _effectFrame;

	public CombatCharacterStateChangeBossPhase(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.ChangeBossPhase)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		DataContext context = CombatChar.GetDataContext();
		int effectIndex = CombatChar.GetBossPhase();
		BossItem bossConfig = CombatChar.BossConfig;
		string fallAni = bossConfig.FailAnimation;
		string fullAniName = bossConfig.AniPrefix[effectIndex] + fallAni;
		bool isRanChenZi = bossConfig.TemplateId == 10;
		short aniFrame = (short)AnimDataCollection.GetDurationFrame(fullAniName);
		_setDataFrame = (short)(Math.Ceiling(DomainManager.Combat.GetTimeScale()) + 1.0);
		_setIdleAniFrame = ((isRanChenZi && effectIndex == 4) ? ((short)(_effectFrame - 240)) : aniFrame);
		_effectFrame = ((bossConfig.HasSceneChangeEffect && CurrentCombatDomain.CombatConfig.Scene >= 0 && !isRanChenZi) ? ((short)Math.Round(600.0)) : aniFrame);
		CombatChar.NeedChangeBossPhase = false;
		if (!CurrentCombatDomain.CombatConfig.StartInSecondPhase)
		{
			CombatChar.SetAnimationToPlayOnce(fallAni, context);
			CombatChar.SetAnimationToLoop(null, context);
			CombatChar.SetParticleToPlay(bossConfig.FailParticles[effectIndex], context);
			CombatChar.SetDieSoundToPlay(bossConfig.FailSounds[effectIndex], context);
			if (bossConfig.HasSceneChangeEffect && CurrentCombatDomain.CombatConfig.Scene >= 0 && !isRanChenZi && bossConfig.TemplateId != 9)
			{
				CombatChar.SetSkillSoundToPlay("ui_battle_rupture", context);
			}
		}
		else
		{
			_setDataFrame = 1;
			_setIdleAniFrame = 1;
			_effectFrame = 2;
		}
		List<string> failPlayerAni = bossConfig.FailPlayerAni;
		if (failPlayerAni != null && failPlayerAni.Count > effectIndex)
		{
			CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly).SetAnimationToPlayOnce(bossConfig.FailPlayerAni[effectIndex], context);
			CombatChar.SetDisplayPosition(CurrentCombatDomain.GetDisplayPosition(CombatChar.IsAlly, bossConfig.FailAniDistance[effectIndex]), context);
		}
	}

	public override void OnExit()
	{
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		if (_setDataFrame > 0)
		{
			_setDataFrame--;
			if (_setDataFrame == 0)
			{
				CombatChar.SetBossPhase((sbyte)(CombatChar.GetBossPhase() + 1), CombatChar.GetDataContext());
			}
		}
		if (_setIdleAniFrame > 0)
		{
			_setIdleAniFrame--;
			if (_setIdleAniFrame == 0)
			{
				CombatChar.SetAnimationToLoop(CombatChar.GetIdleAni(), CombatChar.GetDataContext());
			}
		}
		if (_effectFrame > 0)
		{
			_effectFrame--;
			if (_effectFrame == 0)
			{
				DataContext context = CombatChar.GetDataContext();
				if (CombatChar.ChangeBossPhaseEffectId >= 0)
				{
					DomainManager.Combat.ShowSpecialEffectTips(CombatChar.GetId(), CombatChar.ChangeBossPhaseEffectId, 0);
					CombatChar.SetXiangshuEffectId((short)CombatChar.ChangeBossPhaseEffectId, context);
					CombatChar.ChangeBossPhaseEffectId = -1;
				}
				CombatChar.SetDisplayPosition(int.MinValue, context);
				CombatChar.StateMachine.TranslateState();
			}
		}
		return false;
	}
}
