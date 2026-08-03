using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public class CombatCharacterStateTeammateCommand : CombatCharacterStateBase
{
	private static readonly List<string> NeedPostfixAnis = new List<string> { "M_018", "M_019", "M_023" };

	private CombatCharacter _teammateChar;

	private sbyte _commandType;

	private TeammateCommandItem _commandConfig;

	private ETeammateCommandImplement _commandImplement;

	private string _backCharAni;

	private string _foreCharAni;

	private string _foreCharParticle;

	private string _foreCharSound;

	private int _foreCharAniStartFrame;

	private int _applyLogicEffectFrame;

	private int _teammateFallBackFrame;

	private int _clearCmdFrame;

	private int _stateLeftFrame;

	private CValuePercentBonus CmdEffectPercent => DomainManager.SpecialEffect.GetModifyValue(CombatChar.GetId(), 184, EDataModifyType.Add, (int)_commandImplement);

	private bool Preparing => _teammateChar.TeammateCommandLeftPrepareFrame > 0;

	private bool NeedPrepare => _commandConfig.PrepareFrame > 0;

	private bool TeammateBeforeMainChar => _commandConfig.PosOffset > 0;

	private bool TeammateAfterMainChar => _commandConfig.PosOffset < 0;

	public CombatCharacterStateTeammateCommand(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.TeammateCommand)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		OnEnterInitFields();
		DataContext context = _teammateChar.GetDataContext();
		if (Preparing)
		{
			OnEnterPreparing(context);
		}
		else if (NeedPrepare)
		{
			OnEnterPrepare(context);
		}
		else
		{
			OnEnterNoPrepare(context);
		}
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		if (_foreCharAniStartFrame > 0)
		{
			_foreCharAniStartFrame--;
			if (_foreCharAniStartFrame == 0)
			{
				OnForeCharAniStart();
			}
		}
		if (_applyLogicEffectFrame > 0)
		{
			_applyLogicEffectFrame--;
			if (_applyLogicEffectFrame == 0)
			{
				ApplyLogicEffect();
			}
		}
		if (_teammateFallBackFrame > 0)
		{
			_teammateFallBackFrame--;
			if (_teammateFallBackFrame == 0)
			{
				OnTeammateFallBack();
			}
		}
		if (_clearCmdFrame > 0)
		{
			_clearCmdFrame--;
			if (_clearCmdFrame == 0)
			{
				OnClearCmd();
			}
		}
		if (_stateLeftFrame > 0)
		{
			_stateLeftFrame--;
			if (_stateLeftFrame == 0)
			{
				OnStateLeft();
			}
		}
		return false;
	}

	private void OnEnterInitFields()
	{
		_teammateChar = CombatChar.ActingTeammateCommandChar;
		_commandType = _teammateChar.GetExecutingTeammateCommand();
		_commandConfig = TeammateCommand.Instance[_commandType];
		_commandImplement = _commandConfig.Implement;
		_backCharAni = (Preparing ? _commandConfig.BackCharEnterAni : null);
		_foreCharAni = _commandConfig.ForeCharAni1;
		_foreCharParticle = _commandConfig.ForeCharParticle;
		_foreCharSound = null;
		_foreCharAniStartFrame = 0;
		_applyLogicEffectFrame = 0;
		_teammateFallBackFrame = 0;
		_clearCmdFrame = 0;
		_stateLeftFrame = (Preparing ? AnimDataCollection.GetDurationFrame(_commandConfig.BackCharEnterAni) : 48);
		if (NeedPostfixAnis.Contains(_foreCharAni))
		{
			CombatWeaponData weaponData = (TeammateBeforeMainChar ? _teammateChar : CombatChar).GetWeaponData();
			_foreCharAni += weaponData.Template.TeammateCmdAniPostfix;
		}
		if ((!NeedPrepare || Preparing) && !TeammateBeforeMainChar)
		{
			if (Preparing || _commandConfig.ForeCharAniUseHit)
			{
				_foreCharAniStartFrame = AnimDataCollection.GetEventFrame(_commandConfig.BackCharEnterAni, "hit");
			}
			if (!string.IsNullOrEmpty(_foreCharAni) && !NeedPrepare)
			{
				_teammateFallBackFrame = AnimDataCollection.GetEventFrame(_commandConfig.BackCharEnterAni, "move", 1);
			}
		}
	}

	private void OnEnterPreparing(DataContext context)
	{
		_teammateChar.SetAnimationToPlayOnce(TeammateBeforeMainChar ? _foreCharAni : _backCharAni, context);
		_teammateChar.SetAnimationToLoop(TeammateBeforeMainChar ? _commandConfig.ForeCharAni2 : _commandConfig.BackCharPrepareAni, context);
		if (TeammateBeforeMainChar)
		{
			if (!string.IsNullOrEmpty(_foreCharParticle))
			{
				_teammateChar.SetParticleToPlay(_foreCharParticle, context);
			}
			_teammateChar.SpecialAnimationLoop = _foreCharAni;
			CombatChar.SetAnimationToPlayOnce(_backCharAni, context);
			CombatChar.SetAnimationToLoop(_commandConfig.BackCharPrepareAni, context);
			CombatChar.SpecialAnimationLoop = _commandConfig.BackCharPrepareAni;
		}
	}

	private void OnEnterPrepare(DataContext context)
	{
		if (TeammateBeforeMainChar)
		{
			CombatChar.SpecialAnimationLoop = null;
			CombatChar.SetAnimationToPlayOnce(_commandConfig.BackCharExitAni, context);
			CombatChar.SetAnimationToLoop(CombatChar.GetIdleAni(), context);
			_teammateChar.SpecialAnimationLoop = null;
			_teammateChar.SetAnimationToPlayOnce(_commandConfig.ForeCharAni3, context);
			_teammateFallBackFrame = 1;
			_stateLeftFrame = (_clearCmdFrame = AnimDataCollection.GetDurationFrame(_commandConfig.ForeCharAni3));
		}
		else
		{
			_teammateChar.ClearTeammateCommand(context);
			_stateLeftFrame = 48;
		}
		ApplyLogicEffect();
	}

	private void OnEnterNoPrepare(DataContext context)
	{
		if (_commandImplement.IsPushOrPull())
		{
			OnEnterPushOrPull(context);
		}
		else if (_commandConfig.Type == ETeammateCommandType.Negative)
		{
			OnEnterNegative(context);
		}
		else if (_commandImplement.IsAttack())
		{
			OnEnterAttack(context);
		}
		else if (_commandImplement.IsDefend())
		{
			OnEnterDefend(context);
		}
	}

	private void OnEnterPushOrPull(DataContext context)
	{
		_teammateChar.SetAnimationToPlayOnce(_commandConfig.BackCharEnterAni, context);
		_teammateChar.SetParticleToPlay(_commandConfig.BackCharParticle, context);
		_applyLogicEffectFrame = _foreCharAniStartFrame + AnimDataCollection.GetEventFrame(_foreCharAni, "act0");
		_stateLeftFrame = AnimDataCollection.GetDurationFrame(_commandConfig.BackCharEnterAni);
		string sound = _commandConfig.BackCharEnterSound;
		if (_teammateChar.AnimalConfig?.TeammateCommandBackCharEnterSound != null)
		{
			sbyte cmdType = _teammateChar.GetExecutingTeammateCommand();
			int index = _teammateChar.GetCurrTeammateCommands().IndexOf(cmdType);
			if (index >= 0 && index < _teammateChar.AnimalConfig.TeammateCommandBackCharEnterSound.Count)
			{
				sound = _teammateChar.AnimalConfig.TeammateCommandBackCharEnterSound[index];
			}
		}
		_teammateChar.SetSkillSoundToPlay(sound, context);
	}

	private void OnEnterNegative(DataContext context)
	{
		_teammateChar.SetAnimationToPlayOnce(_commandConfig.BackCharEnterAni, context);
		_teammateChar.SetParticleToPlay(_commandConfig.BackCharParticle, context);
		_applyLogicEffectFrame = AnimDataCollection.GetEventFrame(_commandConfig.BackCharEnterAni, "act0");
		_stateLeftFrame = AnimDataCollection.GetDurationFrame(_commandConfig.BackCharEnterAni);
		_teammateChar.SetSkillSoundToPlay(_commandConfig.BackCharEnterSound, context);
	}

	private void OnEnterAttack(DataContext context)
	{
		sbyte trickType = _teammateChar.GetAttackCommandTrickType();
		int displayPos = CurrentCombatDomain.GetDisplayPosition(CombatChar.IsAlly, _teammateChar.GetNormalAttackPosition(trickType));
		_foreCharAni = _teammateChar.GetNormalAttackAnimation(trickType);
		_foreCharParticle = _teammateChar.GetNormalAttackParticle(trickType);
		_foreCharSound = _teammateChar.GetNormalAttackSound(trickType);
		_foreCharAniStartFrame = 34;
		string foreCharAniFull = _teammateChar.GetNormalAttackAnimationFull(_foreCharAni);
		_applyLogicEffectFrame = _foreCharAniStartFrame + AnimDataCollection.GetEventFrame(foreCharAniFull, "act0");
		_teammateFallBackFrame = 34 + AnimDataCollection.GetDurationFrame(foreCharAniFull);
		_stateLeftFrame = (_clearCmdFrame = _teammateFallBackFrame + 48);
		_teammateChar.SetDisplayPosition(displayPos, context);
		_teammateChar.SetAnimationToPlayOnce("M_003", context);
	}

	private void OnEnterDefend(DataContext context)
	{
		_applyLogicEffectFrame = (_stateLeftFrame = 34);
		_teammateChar.SetAnimationToPlayOnce("M_003", context);
	}

	private void ApplyLogicEffect()
	{
		DataContext context = CombatChar.GetDataContext();
		ETeammateCommandImplement implement = TeammateCommand.Instance[_commandType].Implement;
		if (TeammateAfterMainChar)
		{
			_teammateChar.SetParticleToLoop(null, context);
		}
		else
		{
			CombatChar.SetParticleToLoop(null, context);
		}
		_teammateChar.SetSoundToLoop(null, context);
		CombatChar.SetSoundToLoop(null, context);
		bool flag;
		switch (implement)
		{
		case ETeammateCommandImplement.AccelerateCast:
			ApplyAccelerateCast(context);
			return;
		case ETeammateCommandImplement.Push:
		case ETeammateCommandImplement.Pull:
			flag = true;
			break;
		default:
			flag = false;
			break;
		}
		if (flag)
		{
			ApplyPushOrPull(context);
			return;
		}
		if (implement == ETeammateCommandImplement.PushOrPullIntoDanger)
		{
			ApplyPushOrPullIntoDanger(context);
			return;
		}
		if (implement.IsAttack())
		{
			ApplyAttack();
			return;
		}
		if (implement.IsDefend())
		{
			ApplyDefend(context);
			return;
		}
		switch (implement)
		{
		case ETeammateCommandImplement.HealInjury:
			ApplyHealInjury(context);
			break;
		case ETeammateCommandImplement.HealPoison:
			ApplyHealPoison(context);
			break;
		case ETeammateCommandImplement.HealFlaw:
			ApplyHealFlaw(context);
			break;
		case ETeammateCommandImplement.HealAcupoint:
			ApplyHealAcupoint(context);
			break;
		case ETeammateCommandImplement.TransferNeiliAllocation:
			ApplyTransferNeiliAllocation(context);
			break;
		case ETeammateCommandImplement.TransferInjury:
			ApplyTransferInjury(context);
			break;
		case ETeammateCommandImplement.InterruptSkill:
			ApplyInterruptSkill(context);
			break;
		case ETeammateCommandImplement.AttackFlawAndAcupoint:
			ApplyAttackFlawAndAcupoint(context);
			break;
		case ETeammateCommandImplement.ClearAgileAndDefense:
			ApplyClearAgileAndDefense(context);
			break;
		case ETeammateCommandImplement.AddInjuryAndPoison:
			ApplyAddInjuryAndPoison(context);
			break;
		case ETeammateCommandImplement.InterruptOtherAction:
			ApplyInterruptOtherAction(context);
			break;
		case ETeammateCommandImplement.ReduceNeiliAllocation:
			ApplyReduceNeiliAllocation(context);
			break;
		case ETeammateCommandImplement.AddUnlockAttackValue:
			ApplyAddUnlockAttackValue(context);
			break;
		case ETeammateCommandImplement.TransferManyMark:
			ApplyTransferManyMark(context);
			break;
		case ETeammateCommandImplement.RepairItem:
			ApplyRepairItem(context);
			break;
		case ETeammateCommandImplement.GearMateF:
			ApplyGearMateF(context);
			break;
		case ETeammateCommandImplement.InterruptEnemySkill:
			ApplyInterruptEnemySkill(context);
			break;
		case ETeammateCommandImplement.IntoUpheaval:
			ApplyIntoUpheaval(context);
			break;
		case ETeammateCommandImplement.ExchangeMobility:
			ApplyExchangeMobility(context);
			break;
		case ETeammateCommandImplement.AddInjuryOnEmpty:
			ApplyAddInjuryOnEmpty(context);
			break;
		case ETeammateCommandImplement.AddFlawOrAcupoint:
			ApplyAddFlawOrAcupoint(context);
			break;
		case ETeammateCommandImplement.MergeFatalToDie:
			ApplyMergeFatalToDie(context);
			break;
		case ETeammateCommandImplement.RemoveState:
			ApplyRemoveState(context);
			break;
		case ETeammateCommandImplement.AbsorbNeiliAllocation:
			ApplyAbsorbNeiliAllocation(context);
			break;
		case ETeammateCommandImplement.AddPowerUntilCast:
			ApplyAddPowerUntilCast(context);
			break;
		}
	}

	private void ApplyAccelerateCast(DataContext context)
	{
		if (CombatChar.GetPreparingSkillId() >= 0)
		{
			int addValue = CombatChar.SkillPrepareTotalProgress * _commandConfig.IntArg / 100;
			addValue *= CmdEffectPercent;
			CombatChar.SkillPrepareCurrProgress = Math.Min(CombatChar.SkillPrepareCurrProgress + addValue, CombatChar.SkillPrepareTotalProgress);
			CombatChar.SetSkillPreparePercent((byte)(CombatChar.SkillPrepareCurrProgress * 100 / CombatChar.SkillPrepareTotalProgress), context);
		}
	}

	private void ApplyPushOrPull(DataContext context)
	{
		CurrentCombatDomain.ChangeDistance(context, CombatChar, _commandConfig.IntArg * CmdEffectPercent);
	}

	private void ApplyPushOrPullIntoDanger(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!CombatChar.IsAlly);
		short distance = DomainManager.Combat.GetCurrentDistance();
		int delta = ((distance > enemyChar.GetAttackRange().Inner) ? (-10) : 10);
		CurrentCombatDomain.ChangeDistance(context, CombatChar, delta);
	}

	private void ApplyAttack()
	{
		CombatCharacter enemyChar = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly, tryGetCoverCharacter: true);
		ApplyAttack(enemyChar);
	}

	private void ApplyAttack(CombatCharacter enemyChar)
	{
		CombatContext context = CombatContext.Create(_teammateChar, enemyChar, -1, -1);
		sbyte trickType = _teammateChar.GetAttackCommandTrickType();
		_teammateChar.NormalAttackHitType = CurrentCombatDomain.GetAttackHitType(_teammateChar, trickType);
		_teammateChar.NormalAttackBodyPart = CurrentCombatDomain.GetAttackBodyPart(_teammateChar, enemyChar, context.Random, -1, trickType, -1);
		CurrentCombatDomain.CalcNormalAttack(context, trickType);
		Events.RaiseNormalAttackAllEnd(context, _teammateChar, enemyChar);
		_teammateChar.FinishFreeAttack();
	}

	private void ApplyDefend(DataContext context)
	{
		short defendSkillId = _teammateChar.GetDefendCommandSkillId();
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills((charId: _teammateChar.GetId(), skillId: defendSkillId));
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[defendSkillId];
		_teammateChar.SetAffectingDefendSkillId(defendSkillId, context);
		_teammateChar.SetAnimationToLoop(skillConfig.DefendAnimation, context);
		short defendFrames = CombatSkillDomain.CalcContinuousFrames(skill);
		int defendFramesInt = (int)defendFrames * (CValuePercent)_commandConfig.DefendSkillDurationPercent;
		defendFrames = (short)Math.Clamp(defendFramesInt, 1, 32767);
		_teammateChar.TeammateCommandLeftFrame = (_teammateChar.TeammateCommandTotalFrame = defendFrames);
		CurrentCombatDomain.UpdateMaxSkillGrade(_teammateChar.IsAlly, defendSkillId);
		DomainManager.SpecialEffect.Add(context, _teammateChar.GetId(), defendSkillId, 0, -1);
	}

	private void ApplyHealInjury(DataContext context)
	{
		_teammateChar.SetHealInjuryCount((byte)Math.Max(_teammateChar.GetHealInjuryCount() - 1, 0), context);
		DomainManager.Character.UseCombatResources(context, _teammateChar.GetId(), EHealActionType.Healing, 1);
		CurrentCombatDomain.HealInjuryInCombat(context, CombatChar, _teammateChar);
	}

	private void ApplyHealPoison(DataContext context)
	{
		_teammateChar.SetHealPoisonCount((byte)Math.Max(_teammateChar.GetHealPoisonCount() - 1, 0), context);
		DomainManager.Character.UseCombatResources(context, _teammateChar.GetId(), EHealActionType.Detox, 1);
		CurrentCombatDomain.HealPoisonInCombat(context, CombatChar, _teammateChar);
	}

	private void ApplyHealFlaw(DataContext context)
	{
		CombatChar.RemoveRandomFlawOrAcupoint(context, isFlaw: true, _commandConfig.IntArg * CmdEffectPercent);
	}

	private void ApplyHealAcupoint(DataContext context)
	{
		CombatChar.RemoveRandomFlawOrAcupoint(context, isFlaw: false, _commandConfig.IntArg * CmdEffectPercent);
	}

	private unsafe void ApplyTransferNeiliAllocation(DataContext context)
	{
		NeiliAllocation teammateNeiliAllocation = _teammateChar.GetNeiliAllocation();
		CValuePercentBonus cmdEffectPercent = DomainManager.SpecialEffect.GetModifyValue(CombatChar.GetId(), 184, EDataModifyType.Add, (int)_commandImplement);
		for (byte type = 0; type < 4; type++)
		{
			if (teammateNeiliAllocation.Items[(int)type] > 0)
			{
				int transferValue = Math.Min(teammateNeiliAllocation.Items[(int)type], _commandConfig.IntArg * cmdEffectPercent);
				_teammateChar.ChangeNeiliAllocation(context, type, -transferValue, applySpecialEffect: false);
				CombatChar.ChangeNeiliAllocation(context, type, transferValue, applySpecialEffect: false);
			}
		}
	}

	private void ApplyTransferInjury(DataContext context)
	{
		Injuries mainCharInjuries = CombatChar.GetInjuries();
		Injuries newInjuries = mainCharInjuries.Subtract(CombatChar.GetOldInjuries());
		Injuries teammateInjuries = _teammateChar.GetInjuries();
		bool inner = CombatChar.TransferInjuryCommandIsInner;
		List<sbyte> bodyPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		bodyPartRandomPool.Clear();
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			int canTransferValue = Math.Min(newInjuries.Get(bodyPart, inner), 6 - teammateInjuries.Get(bodyPart, inner));
			for (int i = 0; i < canTransferValue; i++)
			{
				bodyPartRandomPool.Add(bodyPart);
			}
		}
		int transferCount = Math.Min(_commandConfig.IntArg, bodyPartRandomPool.Count);
		for (int j = 0; j < transferCount; j++)
		{
			sbyte bodyPart2 = bodyPartRandomPool[context.Random.Next(0, bodyPartRandomPool.Count)];
			bodyPartRandomPool.Remove(bodyPart2);
			mainCharInjuries.Change(bodyPart2, inner, -1);
			_teammateChar.AddInjury(context, bodyPart2, inner, 1);
		}
		ObjectPool<List<sbyte>>.Instance.Return(bodyPartRandomPool);
		CombatChar.SetInjuries(context, mainCharInjuries, updateDefeatMark: true, syncAutoHealProgress: true, byTransfer: true);
		CurrentCombatDomain.UpdateBodyDefeatMark(context, _teammateChar);
		CombatChar.TransferFatalMark(context, _teammateChar, _commandConfig.IntArg);
	}

	private void ApplyInterruptSkill(DataContext context)
	{
		DomainManager.Combat.InterruptSkill(context, CombatChar);
		DomainManager.Combat.SetProperLoopAniAndParticle(context, CombatChar);
	}

	private void ApplyAttackFlawAndAcupoint(DataContext context)
	{
		ApplyAttack(CombatChar);
		bool flaw = context.Random.CheckPercentProb(50);
		for (sbyte i = 0; i <= 2; i++)
		{
			if (flaw)
			{
				DomainManager.Combat.AddFlaw(context, CombatChar, i, CombatSkillKey.Invalid, -1);
			}
			else
			{
				DomainManager.Combat.AddAcupoint(context, CombatChar, i, CombatSkillKey.Invalid, -1);
			}
		}
	}

	private void ApplyClearAgileAndDefense(DataContext context)
	{
		DomainManager.Combat.ClearAffectingAgileSkill(context, CombatChar);
		DomainManager.Combat.ClearAffectingDefenseSkill(context, CombatChar);
	}

	private void ApplyAddInjuryAndPoison(DataContext context)
	{
		GameData.Domains.Character.Character selfChar = _teammateChar.GetCharacter();
		GameData.Domains.Character.Character targetChar = CombatChar.GetCharacter();
		sbyte poisonActionPhase = selfChar.GetPoisonActionPhase(context.Random, targetChar);
		if (poisonActionPhase > 3)
		{
			DomainManager.Character.ApplyPoisonActionEffect(context, selfChar, targetChar, ItemKey.Invalid);
		}
		sbyte plotHarmActionPhase = selfChar.GetPlotHarmActionPhase(context.Random, targetChar);
		if (plotHarmActionPhase > 3)
		{
			DomainManager.Character.ApplyPlotHarmActionEffect(context, selfChar, targetChar, ItemKey.Invalid);
		}
	}

	private void ApplyInterruptOtherAction(DataContext context)
	{
		DomainManager.Combat.InterruptOtherAction(context, CombatChar);
		CombatChar.SetPreparingItem(ItemKey.Invalid, context);
		DomainManager.Combat.SetProperLoopAniAndParticle(context, CombatChar);
	}

	private void ApplyReduceNeiliAllocation(DataContext context)
	{
		int value = _teammateChar.ExecutingTeammateCommandConfig.IntArg;
		for (byte i = 0; i < 4; i++)
		{
			CombatChar.ChangeNeiliAllocation(context, i, -value);
		}
	}

	private void ApplyAddUnlockAttackValue(DataContext context)
	{
		int addValue = GlobalConfig.Instance.UnlockAttackUnit * (CValuePercent)_commandConfig.IntArg;
		CombatChar.ChangeUnlockAttackValue(context, CombatChar.GetUsingWeaponIndex(), addValue);
	}

	private void ApplyTransferManyMark(DataContext context)
	{
		ApplyTransferManyMarkInjury(context);
		ApplyTransferManyMarkPoison(context);
		ApplyTransferManyMarkQiDisorder(context);
	}

	private int ApplyTransferManyMarkDiv(int value, int canTransfer)
	{
		int divisor = Math.Max(_commandConfig.IntArg, 1);
		int maxTransfer = value / divisor + ((value % divisor > 0) ? 1 : 0);
		return Math.Min(maxTransfer, canTransfer);
	}

	private void ApplyTransferManyMarkInjury(DataContext context)
	{
		Injuries mainCharInjuries = CombatChar.GetInjuries();
		Injuries mainCharNewInjuries = mainCharInjuries.Subtract(CombatChar.GetOldInjuries());
		Injuries teammateInjuries = _teammateChar.GetInjuries();
		bool anyInjuryChanged = false;
		sbyte i;
		for (i = 0; i < 7; i++)
		{
			anyInjuryChanged = TryChangeInjuries(inner: true) || anyInjuryChanged;
			anyInjuryChanged = TryChangeInjuries(inner: false) || anyInjuryChanged;
		}
		if (anyInjuryChanged)
		{
			CombatChar.SetInjuries(context, mainCharInjuries, updateDefeatMark: true, syncAutoHealProgress: true, byTransfer: true);
			CurrentCombatDomain.UpdateBodyDefeatMark(context, _teammateChar);
		}
		bool TryChangeInjuries(bool inner)
		{
			sbyte newInjury = mainCharNewInjuries.Get(i, inner);
			int canTransferInjury = 6 - teammateInjuries.Get(i, inner);
			sbyte transferInjuryCount = (sbyte)ApplyTransferManyMarkDiv(newInjury, canTransferInjury);
			if (transferInjuryCount <= 0)
			{
				return false;
			}
			mainCharInjuries.Change(i, inner, (sbyte)(-transferInjuryCount));
			mainCharNewInjuries.Change(i, inner, (sbyte)(-transferInjuryCount));
			_teammateChar.AddInjury(context, i, inner, transferInjuryCount);
			return true;
		}
	}

	private void ApplyTransferManyMarkPoison(DataContext context)
	{
		PoisonInts mainCharOldPoisons = CombatChar.GetOldPoison();
		PoisonInts mainCharPoisons = CombatChar.GetPoison();
		PoisonInts mainCharNewPoisons = mainCharPoisons.Subtract(ref mainCharOldPoisons);
		PoisonInts teammatePoisons = _teammateChar.GetPoison();
		bool anyPoisonChanged = false;
		for (int i = 0; i < 6; i++)
		{
			int newPoison = mainCharPoisons[i];
			int canTransferPoison = 25000 - teammatePoisons[i];
			int transferPoisonValue = ApplyTransferManyMarkDiv(newPoison, canTransferPoison);
			if (transferPoisonValue > 0)
			{
				mainCharPoisons[i] -= transferPoisonValue;
				mainCharNewPoisons[i] -= transferPoisonValue;
				teammatePoisons[i] += transferPoisonValue;
				anyPoisonChanged = true;
			}
		}
		if (anyPoisonChanged)
		{
			CurrentCombatDomain.SetPoisons(context, CombatChar, mainCharPoisons);
			CurrentCombatDomain.SetPoisons(context, _teammateChar, teammatePoisons);
		}
	}

	private void ApplyTransferManyMarkQiDisorder(DataContext context)
	{
		short mainCharQiDisorder = CombatChar.GetCharacter().GetDisorderOfQi();
		int mainCharNewQiDisorder = mainCharQiDisorder - CombatChar.GetOldDisorderOfQi();
		int canTransferQiDisorder = DisorderLevelOfQi.MaxValue - _teammateChar.GetCharacter().GetDisorderOfQi();
		int transferQiDisorder = ApplyTransferManyMarkDiv(mainCharNewQiDisorder, canTransferQiDisorder);
		if (transferQiDisorder > 0)
		{
			CurrentCombatDomain.TransferDisorderOfQi(context, CombatChar, _teammateChar, transferQiDisorder);
		}
	}

	private void ApplyRepairItem(DataContext context)
	{
		ItemKey[] equipment = CombatChar.GetCharacter().GetEquipment();
		foreach (ItemKey equipKey in equipment)
		{
			int repairValue = _teammateChar.CalcTeammateCommandRepairDurabilityValue(equipKey);
			if (repairValue > 0)
			{
				CurrentCombatDomain.ChangeDurability(context, CombatChar, equipKey, repairValue, EChangeDurabilitySourceType.Teammate);
			}
		}
	}

	private void ApplyGearMateF(DataContext context)
	{
		foreach (CombatCharacter teammateChar in DomainManager.Combat.GetTeammateCharacters(CombatChar.GetId()))
		{
			if (teammateChar == _teammateChar)
			{
				continue;
			}
			List<sbyte> cmdTypes = teammateChar.GetCurrTeammateCommands();
			for (int i = 0; i < cmdTypes.Count; i++)
			{
				if (i != teammateChar.ExecutingTeammateCommandIndex)
				{
					teammateChar.ChangeTeammateCommandCd(context, i, _commandConfig.IntArg);
				}
			}
		}
	}

	private void ApplyInterruptEnemySkill(DataContext context)
	{
		int reduceOdds = _teammateChar.InterruptEnemySkillReduceOdds;
		if (context.Random.CheckPercentProb(100 + reduceOdds))
		{
			DomainManager.Combat.InterruptSkillManual(context, !CombatChar.IsAlly);
			_teammateChar.InterruptEnemySkillReduceOdds = Math.Max(reduceOdds + _commandConfig.IntArg, _commandConfig.SubIntArg);
		}
	}

	private void ApplyIntoUpheaval(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!CombatChar.IsAlly);
		enemyChar.ForceUpheaval(context);
	}

	private void ApplyExchangeMobility(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!CombatChar.IsAlly);
		DomainManager.Combat.ExchangeMobilityValue(context, CombatChar, enemyChar);
	}

	private void ApplyAddInjuryOnEmpty(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!CombatChar.IsAlly);
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		CRandom.GenerateEmptyInjuryPool(enemyChar.GetInjuries(), pool, inner: false);
		if (pool.Count > 0)
		{
			enemyChar.AddInjury(context, pool.GetRandom(context.Random), isInner: false, 1);
		}
		CRandom.GenerateEmptyInjuryPool(enemyChar.GetInjuries(), pool, inner: true);
		if (pool.Count > 0)
		{
			enemyChar.AddInjury(context, pool.GetRandom(context.Random), isInner: true, 1);
		}
		DomainManager.Combat.UpdateBodyDefeatMark(context, enemyChar);
		ObjectPool<List<sbyte>>.Instance.Return(pool);
	}

	private void ApplyAddFlawOrAcupoint(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!CombatChar.IsAlly);
		List<sbyte> flawPool = ObjectPool<List<sbyte>>.Instance.Get();
		List<sbyte> acupointPool = ObjectPool<List<sbyte>>.Instance.Get();
		Dictionary<sbyte, sbyte> flawLevels = ObjectPool<Dictionary<sbyte, sbyte>>.Instance.Get();
		Dictionary<sbyte, sbyte> acupointLevels = ObjectPool<Dictionary<sbyte, sbyte>>.Instance.Get();
		ApplyAddFlawOrAcupointGeneratePool(flawPool, flawLevels, enemyChar.GetAcupointCollection());
		ApplyAddFlawOrAcupointGeneratePool(acupointPool, acupointLevels, enemyChar.GetFlawCollection());
		foreach (sbyte bodyPart in RandomUtils.GetRandomUnrepeated(context.Random, 2, acupointPool))
		{
			DomainManager.Combat.AddAcupoint(context, enemyChar, acupointLevels[bodyPart], CombatSkillKey.Invalid, bodyPart);
		}
		foreach (sbyte bodyPart2 in RandomUtils.GetRandomUnrepeated(context.Random, 2, flawPool))
		{
			DomainManager.Combat.AddFlaw(context, enemyChar, flawLevels[bodyPart2], CombatSkillKey.Invalid, bodyPart2);
		}
		ObjectPool<List<sbyte>>.Instance.Return(flawPool);
		ObjectPool<List<sbyte>>.Instance.Return(acupointPool);
		ObjectPool<Dictionary<sbyte, sbyte>>.Instance.Return(flawLevels);
		ObjectPool<Dictionary<sbyte, sbyte>>.Instance.Return(acupointLevels);
	}

	private static void ApplyAddFlawOrAcupointGeneratePool(List<sbyte> pool, Dictionary<sbyte, sbyte> levels, FlawOrAcupointCollection collection)
	{
		pool.Clear();
		levels.Clear();
		foreach (var (bodyPart, tuples) in collection.BodyPartDict)
		{
			if (tuples != null && tuples.Count > 0)
			{
				if (!pool.Contains(bodyPart))
				{
					pool.Add(bodyPart);
				}
				int maxLevel = tuples.Aggregate(-1, (int current, FlawOrAcupointEntry tuple) => Math.Max(current, tuple.Level));
				levels[bodyPart] = (sbyte)Math.Max(levels.GetOrDefault<sbyte, sbyte>(bodyPart, -1), maxLevel);
			}
		}
	}

	private void ApplyMergeFatalToDie(DataContext context)
	{
		CombatChar.RemoveHalfFatalMark(context);
		CombatChar.AddDieMark(context, 1);
	}

	private void ApplyRemoveState(DataContext context)
	{
		List<short> pool = ObjectPool<List<short>>.Instance.Get();
		CombatStateCollection debuffCollection = CombatChar.GetDebuffCombatStateCollection();
		pool.ClearAndAddRange(debuffCollection.StateDict.Keys);
		foreach (short stateId in RandomUtils.GetRandomUnrepeated(context.Random, 3, pool))
		{
			DomainManager.Combat.RemoveCombatState(context, CombatChar, 2, stateId);
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!CombatChar.IsAlly);
		CombatStateCollection buffCollection = enemyChar.GetBuffCombatStateCollection();
		pool.ClearAndAddRange(buffCollection.StateDict.Keys);
		foreach (short stateId2 in RandomUtils.GetRandomUnrepeated(context.Random, 3, pool))
		{
			DomainManager.Combat.RemoveCombatState(context, enemyChar, 1, stateId2);
		}
		ObjectPool<List<short>>.Instance.Return(pool);
	}

	private void ApplyAbsorbNeiliAllocation(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!CombatChar.IsAlly);
		NeiliAllocation neiliAllocation = enemyChar.GetNeiliAllocation();
		NeiliAllocation originNeiliAllocation = enemyChar.GetOriginNeiliAllocation();
		for (byte i = 0; i < 4; i++)
		{
			if (neiliAllocation[i] > originNeiliAllocation[i])
			{
				int absorbValue = CValuePercent.CeilMul(neiliAllocation[i] - originNeiliAllocation[i], 33);
				CombatChar.AbsorbNeiliAllocation(context, enemyChar, i, absorbValue);
			}
		}
	}

	private void ApplyAddPowerUntilCast(DataContext context)
	{
		CombatChar.ApplyAddPowerUntilCast(context, _commandConfig.IntArg);
	}

	private void OnForeCharAniStart()
	{
		DataContext context = CombatChar.GetDataContext();
		if (!string.IsNullOrEmpty(_foreCharAni))
		{
			CombatCharacter foreChar = (TeammateBeforeMainChar ? _teammateChar : CombatChar);
			foreChar.SetAnimationToPlayOnce(_foreCharAni, context);
			if (!string.IsNullOrEmpty(_foreCharParticle))
			{
				foreChar.SetParticleToPlay(_foreCharParticle, context);
			}
			if (!string.IsNullOrEmpty(_foreCharSound))
			{
				foreChar.SetAttackSoundToPlay(_foreCharSound, context);
			}
		}
		if (TeammateAfterMainChar)
		{
			_teammateChar.SetParticleToLoop(_commandConfig.BackCharParticle, context);
			if (!string.IsNullOrEmpty(_commandConfig.BackCharPrepareSound))
			{
				_teammateChar.SetSoundToLoop(_commandConfig.BackCharPrepareSound, context);
			}
		}
	}

	private void OnTeammateFallBack()
	{
		DataContext context = CombatChar.GetDataContext();
		bool teammateInFront = CombatChar.TeammateBeforeMainChar == _teammateChar.GetId();
		_teammateChar.SetDisplayPosition(int.MinValue, context);
		if (teammateInFront)
		{
			CombatChar.TeammateBeforeMainChar = -1;
		}
		else
		{
			CombatChar.TeammateAfterMainChar = -1;
		}
		CurrentCombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, int.MinValue);
		if (teammateInFront)
		{
			CombatChar.TeammateBeforeMainChar = _teammateChar.GetId();
		}
		else
		{
			CombatChar.TeammateAfterMainChar = _teammateChar.GetId();
		}
		if (_commandImplement.IsAttack())
		{
			_teammateChar.SetAnimationToPlayOnce("M_004", context);
		}
	}

	private void OnClearCmd()
	{
		if (_commandImplement == ETeammateCommandImplement.GearMateA)
		{
			_teammateChar.PartlyClearTeammateCommand(_teammateChar.GetDataContext());
		}
		else
		{
			_teammateChar.ClearTeammateCommand(_teammateChar.GetDataContext());
		}
	}

	private void OnStateLeft()
	{
		ETeammateCommandImplement commandImplement = _commandImplement;
		if ((uint)(commandImplement - 2) <= 1u)
		{
			_teammateChar.ClearTeammateCommand(_teammateChar.GetDataContext());
		}
		else if (TeammateBeforeMainChar && _teammateChar.TeammateCommandLeftPrepareFrame > 0)
		{
			DataContext context = CombatChar.GetDataContext();
			CombatChar.SetParticleToLoop(_commandConfig.BackCharParticle, CombatChar.GetDataContext());
			CombatChar.SetSoundToLoop(_commandConfig.BackCharPrepareSound, context);
		}
		CombatChar.StateMachine.TranslateState();
	}
}
