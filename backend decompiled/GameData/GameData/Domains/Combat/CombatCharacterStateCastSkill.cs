using System;
using Config;
using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.Combat;

public class CombatCharacterStateCastSkill : CombatCharacterStateBase
{
	private short _prepareFinishAniFrame;

	private short _skillAniFrame;

	private readonly short[] _damageFrame = new short[4];

	private short _skillAniFrameCounter;

	private CombatSkillItem _configData;

	private bool _outOfRange;

	private short _attackEndWaitFrame;

	private int _translateStateDelayedFrame;

	public CombatCharacterStateCastSkill(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.CastSkill)
	{
		RequireDelayFallen = true;
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		_translateStateDelayedFrame = -1;
		DataContext context = CombatChar.GetDataContext();
		short skillId = CombatChar.GetPreparingSkillId();
		CombatCharacter enemyChar = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly, tryGetCoverCharacter: true);
		_configData = Config.CombatSkill.Instance[skillId];
		_attackEndWaitFrame = 6;
		if (_configData.EquipType == 1)
		{
			CombatChar.SkillAttackBodyPart = CurrentCombatDomain.GetAttackBodyPart(CombatChar, enemyChar, context.Random, _configData.TemplateId, -1, -1);
			DomainManager.Combat.ClearSkillDamage(context);
			DomainManager.Combat.SetSkillDamageIndex(0);
			SkillDamageData skillDamageData = DomainManager.Combat.GetSkillDamageData();
			skillDamageData.TargetBodyPart = CombatChar.SkillAttackBodyPart;
			skillDamageData.EquipmentSnapshot = CatchEquipmentSnapshot();
			DomainManager.Combat.SetSkillDamageData(skillDamageData, context);
		}
		Events.RaisePrepareSkillChangeDistance(context, CombatChar, enemyChar, skillId);
		Events.RaisePrepareSkillEnd(context, CombatChar.GetId(), CombatChar.IsAlly, skillId);
		if (_configData.EquipType == 1)
		{
			CurrentCombatDomain.CalcAttackSkillDataCompare(CombatContext.Create(CombatChar, null, -1, skillId));
			_outOfRange = !CurrentCombatDomain.InAttackRange(CombatChar);
			if (!_outOfRange)
			{
				short distance = ((_configData.PlayerCastBossSkillDistance == null || CombatChar.BossConfig != null) ? _configData.DistanceWhenFourStepAnimation[0] : _configData.PlayerCastBossSkillDistance[0]);
				CurrentCombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, CurrentCombatDomain.GetDisplayPosition(CombatChar.IsAlly, distance));
			}
			if (CurrentCombatDomain.IsPlayingMoveAni(enemyChar))
			{
				enemyChar.SetAnimationToLoop(enemyChar.GetIdleAni(), context);
			}
			PlayPrepareFinishAni();
			Events.RaiseCastAttackSkillBegin(context, CombatChar, enemyChar, skillId);
		}
		CombatChar.SetPreparingSkillId(-1, context);
	}

	public override void OnExit()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatChar.SetSkillPreparePercent(0, context);
		CombatChar.SetSkillSoundToPlay(string.Empty, context);
		CombatChar.SetParticleToPlay(string.Empty, context);
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		if (_configData.EquipType == 1)
		{
			if (_prepareFinishAniFrame > 0)
			{
				_prepareFinishAniFrame--;
				if (_prepareFinishAniFrame == 0)
				{
					DataContext context = CombatChar.GetDataContext();
					bool isBoss = CombatChar.BossConfig != null;
					string aniName = ((string.IsNullOrEmpty(_configData.PlayerCastBossSkillAni) || isBoss) ? _configData.CastAnimation : _configData.PlayerCastBossSkillAni);
					string musicWeaponFix = ((_configData.Type != 13 || isBoss) ? "" : CurrentCombatDomain.GetMusicWeaponNameFix(CombatChar.GetWeaponData()));
					aniName = ((!isBoss) ? (aniName + musicWeaponFix) : (CombatChar.BossConfig.AniPrefix[CombatChar.GetBossPhase()] + aniName));
					AnimData aniData = AnimDataCollection.Data[aniName];
					_skillAniFrame = (short)Math.Round(aniData.Duration * 60f);
					_skillAniFrame += _attackEndWaitFrame;
					for (int i = 0; i < 4; i++)
					{
						_damageFrame[i] = (short)Math.Round(aniData.Events[$"act{i + 1}"][0] * 60f);
					}
					_skillAniFrameCounter = 0;
					CombatChar.SetAnimationToPlayOnce((!isBoss) ? aniName : _configData.CastAnimation, context);
					if (!string.IsNullOrEmpty(_configData.CastParticle))
					{
						string castParticle = ((string.IsNullOrEmpty(_configData.PlayerCastBossSkillParticle) || isBoss) ? _configData.CastParticle : _configData.PlayerCastBossSkillParticle);
						CombatChar.SetParticleToPlay((!isBoss) ? (castParticle + musicWeaponFix) : _configData.CastParticle, context);
					}
					if (!string.IsNullOrEmpty(_configData.CastSoundEffect))
					{
						string castSound = ((string.IsNullOrEmpty(_configData.PlayerCastBossSkillSound) || isBoss) ? _configData.CastSoundEffect : _configData.PlayerCastBossSkillSound);
						CombatChar.SetSkillSoundToPlay(castSound + musicWeaponFix, context);
					}
					if (!string.IsNullOrEmpty(_configData.CastPetAnimation) && isBoss)
					{
						CombatChar.SetSkillPetAnimation(_configData.CastPetAnimation, context);
					}
					if (!string.IsNullOrEmpty(_configData.CastPetParticle) && isBoss)
					{
						CombatChar.SetPetParticle(_configData.CastPetParticle, context);
					}
					CombatChar.SetAnimationToLoop(CombatChar.GetIdleAni(), context);
				}
				return false;
			}
			_skillAniFrameCounter++;
			for (int j = 0; j < _damageFrame.Length; j++)
			{
				if (_damageFrame[j] != _skillAniFrameCounter)
				{
					continue;
				}
				DataContext context2 = CombatChar.GetDataContext();
				if (j == 3 || CombatChar.SkillHitType[j] >= 0)
				{
					if (_outOfRange)
					{
						CombatChar.SetAttackOutOfRange(attackOutOfRange: true, context2);
					}
					else
					{
						CurrentCombatDomain.CalcSkillAttack(CombatContext.Create(CombatChar, null, -1, -1), j);
					}
					if (j == 3 && _configData.WeaponDurableCost > 0)
					{
						CurrentCombatDomain.CostDurability(context2, CombatChar, CurrentCombatDomain.GetUsingWeaponKey(CombatChar), _configData.WeaponDurableCost);
					}
				}
				if (!_outOfRange)
				{
					short distance = ((_configData.PlayerCastBossSkillDistance == null || CombatChar.BossConfig != null) ? _configData.DistanceWhenFourStepAnimation[j + 1] : _configData.PlayerCastBossSkillDistance[j + 1]);
					CurrentCombatDomain.SetDisplayPosition(context2, !CombatChar.IsAlly, CurrentCombatDomain.GetDisplayPosition(!CombatChar.IsAlly, distance));
				}
				Events.RaiseAttackSkillAttackEndOfAll(context2, CombatChar, j);
				if (j < 3)
				{
					CombatChar.SetAttackSkillAttackIndex((byte)(j + 1), context2);
					CurrentCombatDomain.SetSkillDamageIndex(j + 1);
				}
				break;
			}
			if (_skillAniFrameCounter == _skillAniFrame - _attackEndWaitFrame)
			{
				DataContext context3 = CombatChar.GetDataContext();
				sbyte power = (sbyte)CombatChar.GetAttackSkillPower();
				CombatChar.SetPerformingSkillId(-1, context3);
				CombatChar.SetAttackSkillPower(0, context3);
				CombatChar.SetSkillPetAnimation(null, context3);
				CurrentCombatDomain.SetDisplayPosition(context3, CombatChar.IsAlly, int.MinValue);
				CurrentCombatDomain.SetDisplayPosition(context3, !CombatChar.IsAlly, int.MinValue);
				int finalCriticalOdds = CurrentCombatDomain.GetFinalCriticalOdds(CombatChar);
				CurrentCombatDomain.ClearDamageCompareData(context3);
				DomainManager.Combat.RaiseCastSkillEnd(context3, CombatChar.GetId(), CombatChar.IsAlly, _configData.TemplateId, power, interrupt: false, finalCriticalOdds);
				CombatCharacter character = CombatChar;
				CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!character.IsAlly, tryGetCoverCharacter: true);
				DomainManager.Combat.AddToCheckFallenSet(character.GetId());
				DomainManager.Combat.AddToCheckFallenSet(enemyChar.GetId());
				if (CombatChar.GetAutoCastingSkill() && CombatChar.NeedUseSkillFreeId < 0)
				{
					CombatChar.SetAutoCastingSkill(autoCastingSkill: false, context3);
				}
			}
			if (_skillAniFrameCounter >= _skillAniFrame)
			{
				DataContext context4 = CombatChar.GetDataContext();
				CombatCharacter enemyChar2 = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly, tryGetCoverCharacter: true);
				if (enemyChar2.GetAnimationToLoop() == enemyChar2.GetIdleAni())
				{
					CurrentCombatDomain.SetProperLoopAniAndParticle(context4, enemyChar2);
				}
				CombatChar.StateMachine.TranslateState();
			}
		}
		else if (_translateStateDelayedFrame < 0)
		{
			DataContext context5 = CombatChar.GetDataContext();
			CurrentCombatDomain.ApplyAgileOrDefenseSkill(CombatChar, _configData);
			CombatChar.SetPerformingSkillId(-1, context5);
			_translateStateDelayedFrame = ((_configData.EquipType == 2) ? 1 : 0);
			DomainManager.Combat.RaiseCastSkillEnd(context5, CombatChar.GetId(), CombatChar.IsAlly, _configData.TemplateId, 0);
		}
		if (_translateStateDelayedFrame < 0)
		{
			return false;
		}
		if (_translateStateDelayedFrame <= 0)
		{
			CombatChar.StateMachine.TranslateState();
		}
		_translateStateDelayedFrame--;
		return false;
	}

	private void PlayPrepareFinishAni()
	{
		DataContext context = CombatChar.GetDataContext();
		bool isBoss = CombatChar.BossConfig != null;
		string musicWeaponFix = ((_configData.Type != 13) ? "" : CurrentCombatDomain.GetMusicWeaponNameFix(CombatChar.GetWeaponData()));
		string prepareFinishAni = ((string.IsNullOrEmpty(_configData.PlayerCastBossSkillPrepareAni) || isBoss) ? (_configData.PrepareAnimation + musicWeaponFix + "_1_1") : (_configData.PlayerCastBossSkillPrepareAni + musicWeaponFix + "_1_1"));
		string prepareFinishAniName = ((!isBoss) ? prepareFinishAni : "C_007_1");
		float duration = AnimDataCollection.Data[(!isBoss) ? prepareFinishAniName : (CombatChar.BossConfig.AniPrefix[CombatChar.GetBossPhase()] + "C_007_1")].Duration;
		_prepareFinishAniFrame = (short)Math.Round(duration * 60f + 3f);
		CombatChar.SetAnimationToPlayOnce(prepareFinishAniName, context);
		CombatChar.SetSkillSoundToPlay("se_combat_preskill", context);
	}

	private SkillEquipmentSnapshot CatchEquipmentSnapshot()
	{
		CombatContext context = CombatContext.Create(CombatChar, null, -1, _configData.TemplateId);
		short durability = context.WeaponOrShoes?.GetCurrDurability() ?? 0;
		SkillEquipmentSnapshot result = new SkillEquipmentSnapshot();
		result.WeaponOrShoesKey = context.WeaponOrShoesKey;
		result.WeaponOrShoesStartDurability = durability;
		result.WeaponOrShoesEndDurability = durability;
		return result;
	}
}
