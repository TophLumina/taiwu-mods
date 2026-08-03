using System;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Item;
using GameData.Domains.Story.MainStory;

namespace GameData.Domains.Combat;

public class CombatCharacterStateAttack : CombatCharacterStateBase
{
	private bool _inAttackRange;

	private CombatCharacter _enemyChar;

	private sbyte _trickType;

	private bool _isFightBack;

	private bool _isCritical;

	private short _moveAniFrame;

	private short _attackAniFrame;

	private short _damageFrame;

	private short _pursueFrame;

	private short _attackEndWaitFrame;

	private int _weaponId;

	private int _aniIndex;

	private string _attackAniName;

	private string _attackParticleName;

	private string _attackSound;

	public CombatCharacterStateAttack(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.Attack)
	{
		IsUpdateOnPause = true;
		RequireDelayFallen = true;
	}

	public override void OnEnter()
	{
		DataContext context = CombatChar.GetDataContext();
		_inAttackRange = CurrentCombatDomain.InAttackRange(CombatChar);
		_enemyChar = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly, tryGetCoverCharacter: true);
		_trickType = (CombatChar.GetChangeTrickAttack() ? CombatChar.ChangeTrickType : CombatChar.GetAttackingTrickType());
		_isFightBack = CombatChar.GetIsFightBack();
		if (CombatChar.PursueAttackCount == 0)
		{
			CombatChar.NormalAttackHitType = CurrentCombatDomain.GetAttackHitType(CombatChar, _trickType);
		}
		CombatChar.NormalAttackHitType = (sbyte)DomainManager.SpecialEffect.ModifyData(CombatChar.GetId(), -1, 68, CombatChar.NormalAttackHitType);
		CombatChar.NormalAttackBodyPart = (sbyte)((!CombatChar.GetChangeTrickAttack()) ? CurrentCombatDomain.GetAttackBodyPart(CombatChar, _enemyChar, context.Random, -1, _trickType, CombatChar.NormalAttackHitType) : ((CombatChar.NormalAttackHitType != 3) ? CombatChar.ChangeTrickBodyPart : (-1)));
		if (CurrentCombatDomain.IsMainCharacter(CombatChar))
		{
			CurrentCombatDomain.ForceAllTeammateLeaveCombatField(context, CombatChar.IsAlly);
		}
		if (CurrentCombatDomain.IsPlayingMoveAni(_enemyChar))
		{
			_enemyChar.SetAnimationToLoop(_enemyChar.GetIdleAni(), context);
		}
		InitAttack(context);
	}

	public override void OnExit()
	{
		CombatChar.IsBreakAttacking = false;
		CombatChar.PursueAttackCount = 0;
		CombatChar.SetAnimationToLoop(CombatChar.GetIdleAni(), CombatChar.GetDataContext());
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		if (CurrentCombatDomain.IsCharacterFallen(CombatChar))
		{
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.Idle);
			return false;
		}
		if (_moveAniFrame > 0)
		{
			_moveAniFrame--;
			if (_moveAniFrame == 0)
			{
				PlayAttackAnimation();
			}
			return false;
		}
		if (_enemyChar.GetIsFightBack())
		{
			DataContext context = CombatChar.GetDataContext();
			sbyte fightBackTrickType = _enemyChar.GetWeaponTricks()[_enemyChar.GetWeaponTrickIndex()];
			if (_enemyChar.StateMachine.GetCurrentStateType() == CombatCharacterStateType.PrepareAttack)
			{
				_enemyChar.NormalAttackLeftRepeatTimes++;
			}
			else
			{
				_enemyChar.IsAutoNormalAttacking = true;
			}
			_enemyChar.SetAttackingTrickType(fightBackTrickType, context);
			_enemyChar.StateMachine.TranslateState(CombatCharacterStateType.Attack);
			if (!CombatChar.IsAutoNormalAttacking)
			{
				CombatChar.SetWeaponTrickIndex((byte)((CombatChar.GetWeaponTrickIndex() + 1) % 6), context);
			}
			CombatChar.NormalAttackLeftRepeatTimes = 0;
			CombatChar.NeedNormalAttackSkipPrepare = 0;
			CombatChar.NeedFreeAttack = false;
			Events.RaiseNormalAttackAllEnd(context, CombatChar, _enemyChar);
			CombatChar.NormalAttackRecovery(context);
			CombatChar.FinishFreeAttack();
			CombatChar.SetAttackingTrickType(-1, context);
			CombatChar.StateMachine.TranslateState();
			return false;
		}
		if (_damageFrame > 0)
		{
			_damageFrame--;
			if (_damageFrame == 0)
			{
				DataContext context2 = CombatChar.GetDataContext();
				if (_inAttackRange)
				{
					CombatContext combatContext = CombatContext.Create(CombatChar, null, -1, -1);
					_isCritical = combatContext.CheckCritical(CombatChar.NormalAttackHitType);
					CurrentCombatDomain.CalcNormalAttack(combatContext.Critical(_isCritical), _trickType);
				}
				else
				{
					CombatChar.SetAttackOutOfRange(attackOutOfRange: true, context2);
					Events.RaiseNormalAttackOutOfRange(context2, CombatChar.GetId(), CombatChar.IsAlly);
				}
			}
		}
		if (_pursueFrame > 0)
		{
			_pursueFrame--;
			if (_pursueFrame == 0 && !_isFightBack && CurrentCombatDomain.CanPursue(CombatChar, _isCritical) && _weaponId == CurrentCombatDomain.GetUsingWeaponKey(CombatChar).Id)
			{
				CombatChar.PursueAttackCount++;
				OnEnter();
			}
		}
		if (_attackAniFrame > 0)
		{
			_attackAniFrame--;
			if (_attackAniFrame == _attackEndWaitFrame)
			{
				DataContext context3 = CombatChar.GetDataContext();
				bool needRepeatAttack = CombatChar.NormalAttackLeftRepeatTimes > 0 && !CurrentCombatDomain.IsCharacterFallen(_enemyChar) && !CurrentCombatDomain.IsCharacterFallen(CombatChar);
				CombatChar.SetAttackingTrickType(-1, context3);
				if (CombatChar.GetIsFightBack())
				{
					CurrentCombatDomain.SetDisplayPosition(context3, !CombatChar.IsAlly, int.MinValue);
				}
				else if (!needRepeatAttack)
				{
					CurrentCombatDomain.SetDisplayPosition(context3, CombatChar.IsAlly, int.MinValue);
				}
			}
			if (_attackAniFrame == 0)
			{
				DataContext context4 = CombatChar.GetDataContext();
				CombatChar.SetAnimationTimeScale(1f, context4);
				if (!CombatChar.IsAutoNormalAttacking)
				{
					CombatChar.SetWeaponTrickIndex((byte)((CombatChar.GetWeaponTrickIndex() + 1) % 6), context4);
				}
				CurrentCombatDomain.ClearDamageCompareData(context4);
				Events.RaiseNormalAttackAllEnd(context4, CombatChar, _enemyChar);
				CombatChar.NormalAttackRecovery(context4);
				CombatChar.FinishFreeAttack();
				if (CombatChar.GetIsFightBack())
				{
					CombatChar.SetIsFightBack(isFightBack: false, context4);
					CombatChar.FightBackWithHit = false;
					CombatChar.FightBackHitType = -1;
					CombatChar.FightBackSourceBodyPart = -1;
				}
				if (CombatChar.GetChangeTrickAttack())
				{
					CombatChar.SetChangeTrickAttack(changeTrickAttack: false, context4);
				}
				if (CombatChar.AttackForceHitCount > 0)
				{
					CombatChar.AttackForceHitCount--;
				}
				if (CombatChar.AttackForceMissCount > 0)
				{
					CombatChar.AttackForceMissCount--;
				}
				if (CombatChar.NormalAttackLeftRepeatTimes > 0 && !CurrentCombatDomain.IsCharacterFallen(_enemyChar) && !CurrentCombatDomain.IsCharacterFallen(CombatChar))
				{
					sbyte trickType = CombatChar.GetWeaponTricks()[CombatChar.GetWeaponTrickIndex()];
					trickType = (sbyte)DomainManager.SpecialEffect.ModifyData(CombatChar.GetId(), -1, 83, trickType);
					CombatChar.SetAttackingTrickType(trickType, context4);
					if (CombatChar.NormalAttackRepeatIsFightBack)
					{
						CombatChar.SetIsFightBack(isFightBack: true, context4);
					}
					CombatChar.NormalAttackLeftRepeatTimes--;
					CombatChar.IsAutoNormalAttacking = true;
					CombatChar.PursueAttackCount = 0;
					OnEnter();
				}
				else
				{
					CombatChar.NormalAttackRepeatIsFightBack = false;
					CombatChar.StateMachine.TranslateState();
					if (_enemyChar.GetAnimationToLoop() == CombatChar.GetIdleAni())
					{
						CurrentCombatDomain.SetProperLoopAniAndParticle(context4, _enemyChar);
					}
				}
			}
		}
		return false;
	}

	private void InitAttack(DataContext context)
	{
		_weaponId = CurrentCombatDomain.GetUsingWeaponKey(CombatChar).Id;
		GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetElement_Weapons(_weaponId);
		CombatChar.GetAttackEffect(weapon, _trickType).Deconstruct(out var AniName, out var FullAniName, out var Particle, out var Sound);
		string aniName = AniName;
		string fullAniName = FullAniName;
		string particle = Particle;
		string sound = Sound;
		_aniIndex = weapon.GetWeaponAction();
		_attackAniName = aniName;
		_attackParticleName = particle;
		_attackSound = sound;
		float animTime = AnimDataCollection.Data[fullAniName].Duration;
		_attackAniFrame = CombatChar.CalcNormalAttackAnimationFrames(animTime);
		float frameTime = (float)_attackAniFrame / 60f;
		CombatChar.SetAnimationTimeScale(animTime / frameTime, context);
		_damageFrame = (short)Math.Max(Math.Round(AnimDataCollection.Data[fullAniName].Events["act0"][0] * 60f), 1.0);
		_pursueFrame = (short)((_inAttackRange && !CombatChar.GetIsFightBack() && CombatChar.PursueAttackCount < 5 && (CombatChar.AnimalConfig == null || CombatChar.GetCharacter().Template.IsChaiShanYuanZu())) ? ((short)Math.Round(AnimDataCollection.Data[fullAniName].Events["hit"][0] * 60f)) : (-1));
		StartAttack();
	}

	private void StartAttack()
	{
		DataContext context = CombatChar.GetDataContext();
		short distance = CurrentCombatDomain.GetCurrentDistance();
		TrickTypeItem trickData = Config.TrickType.Instance[_trickType];
		int weaponIndex = CombatChar.GetUsingWeaponIndex();
		BossItem bossConfig = CombatChar.BossConfig;
		sbyte displayDistance = ((bossConfig != null) ? bossConfig.AttackDistances[CombatChar.GetBossPhase()][weaponIndex] : (CombatChar.AnimalConfig?.AttackDistances[weaponIndex] ?? trickData.AttackDistance[_aniIndex]));
		if (_inAttackRange && CombatChar.PursueAttackCount == 0 && !CombatChar.GetIsFightBack() && displayDistance > 0 && displayDistance != distance)
		{
			_moveAniFrame = 9;
			CurrentCombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, CurrentCombatDomain.GetDisplayPosition(CombatChar.IsAlly, displayDistance));
		}
		else
		{
			_moveAniFrame = 0;
			PlayAttackAnimation();
		}
		_attackEndWaitFrame = 6;
		_attackAniFrame += _attackEndWaitFrame;
	}

	private void PlayAttackAnimation()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatChar.SetAnimationToPlayOnce(_attackAniName, context);
		CombatChar.SetParticleToPlay(_attackParticleName, context);
		CombatChar.SetAttackSoundToPlay(_attackSound, context);
	}
}
