using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public class CombatCharacterStateBase
{
	public delegate void CombatCharacterStateDelayCallRequest();

	public delegate void CombatCharacterStateDelayCallTickPercent(int percent);

	public struct DelayCallData
	{
		public int DelayedFrames;

		public int TotalDelayFrames;

		private readonly CombatCharacterStateDelayCallRequest _action;

		private readonly CombatCharacterStateDelayCallTickPercent _tickPercent;

		public int Percent => CValuePercent.ParseIntClamp01(DelayedFrames, TotalDelayFrames);

		public bool Ticked => DelayedFrames >= TotalDelayFrames;

		public DelayCallData(CombatCharacterStateDelayCallRequest action, CombatCharacterStateDelayCallTickPercent tickPercent, int frames)
		{
			DelayedFrames = 0;
			TotalDelayFrames = frames;
			_action = action;
			_tickPercent = tickPercent;
		}

		public bool Tick()
		{
			DelayedFrames++;
			_tickPercent?.Invoke(Percent);
			if (Ticked)
			{
				_action?.Invoke();
			}
			return Ticked;
		}
	}

	protected CombatDomain CurrentCombatDomain;

	protected CombatCharacter CombatChar;

	public CombatCharacterStateType StateType;

	public bool RequireDelayFallen;

	public bool IsUpdateOnPause;

	protected bool AutoUpdateDelayCall;

	private readonly Queue<DelayCallData> _delayCallList = new Queue<DelayCallData>();

	protected void DelayCall(CombatCharacterStateDelayCallRequest request, int frame)
	{
		DelayCall(request, null, frame);
	}

	protected void DelayCall(CombatCharacterStateDelayCallRequest request, CombatCharacterStateDelayCallTickPercent tickPercent, int frame)
	{
		if (frame <= 0)
		{
			request?.Invoke();
			tickPercent?.Invoke(100);
		}
		else
		{
			_delayCallList.Enqueue(new DelayCallData(request, tickPercent, frame));
		}
	}

	public CombatCharacterStateBase(CombatDomain combatDomain, CombatCharacter combatChar, CombatCharacterStateType type)
	{
		CurrentCombatDomain = combatDomain;
		CombatChar = combatChar;
		StateType = type;
		IsUpdateOnPause = false;
	}

	public virtual void OnEnter()
	{
		AutoUpdateDelayCall = true;
		_delayCallList.Clear();
	}

	public virtual void OnExit()
	{
	}

	public virtual bool OnUpdate()
	{
		if (CombatChar.ChangeCharId >= 0 && !CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly).NeedSelectMercyOption)
		{
			ChangeCurrChar();
			return false;
		}
		if (CheckCommonTranslateState())
		{
			CombatChar.StateMachine.TranslateState();
			return false;
		}
		if (!DomainManager.Combat.Pause)
		{
			DataContext context = CombatChar.GetDataContext();
			int[] charList = CurrentCombatDomain.GetCharacterList(CombatChar.IsAlly);
			int mainCharId = (CombatChar.IsAlly ? CurrentCombatDomain.GetSelfTeam() : CurrentCombatDomain.GetEnemyTeam())[0];
			TimeUpdate(context, CombatChar);
			if (CurrentCombatDomain.IsMainCharacter(CombatChar))
			{
				if (CombatChar.ExecuteReserveTeammateCommand(context) || CombatChar.UpdateTeammateCharStatus(context))
				{
					return false;
				}
			}
			else
			{
				CombatCharacter mainChar = CurrentCombatDomain.GetElement_CombatCharacterDict(mainCharId);
				TimeUpdate(context, mainChar);
				if (CombatChar.TeammateCommandLeftFrame > 0)
				{
					CombatChar.ReduceTeammateCommandLeftTime(context);
				}
				if ((CombatChar.TeammateCommandLeftFrame == 0 && CombatChar.GetPreparingSkillId() < 0) || CurrentCombatDomain.IsCharacterFallen(mainChar))
				{
					CombatChar.ResetTeammateCommandCd(context, CombatChar.ExecutingTeammateCommandIndex, -1, checkEvent: true, displayEvent: true);
					CombatChar.TeammateCommandLeftFrame = -1;
					CombatChar.ExecutingTeammateCommandIndex = -1;
					CombatChar.ChangeCharId = mainCharId;
				}
			}
			for (int i = 1; i < charList.Length; i++)
			{
				int charId = charList[i];
				if (charId >= 0 && charId != CombatChar.GetId() && charId != mainCharId)
				{
					CombatCharacter teammateChar = CurrentCombatDomain.GetElement_CombatCharacterDict(charId);
					if (!CurrentCombatDomain.IsCharacterFallen(teammateChar))
					{
						TimeUpdate(context, teammateChar, isMainOrCurrChar: false);
					}
				}
			}
			if (CombatChar.IsMoving)
			{
				CombatChar.MoveData.UpdateMove(context, CurrentCombatDomain);
			}
			else if (CombatChar.KeepMoving && CurrentCombatDomain.CanMove(CombatChar, CombatChar.MoveForward))
			{
				if (CombatChar.MoveData.IsJumpMove(CombatChar.MoveForward))
				{
					CombatChar.MoveData.UpdateJumpPrepare(context);
				}
				else
				{
					CombatChar.MoveData.StartMove(context);
				}
			}
			else if (!CombatChar.KeepMoving && (CombatChar.MoveData.JumpPreparedProgress > 0 || CombatChar.GetJumpPreparedDistance() > 0))
			{
				CombatChar.MoveData.ReduceJumpPrepare(context);
			}
		}
		if (AutoUpdateDelayCall)
		{
			UpdateDelayCall();
		}
		return true;
	}

	protected void UpdateDelayCall()
	{
		int count = _delayCallList.Count;
		while (count > 0)
		{
			count--;
			DelayCallData request = _delayCallList.Dequeue();
			if (!request.Tick())
			{
				_delayCallList.Enqueue(request);
			}
		}
	}

	private void ChangeCurrChar()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatCharacter newChar = CurrentCombatDomain.GetElement_CombatCharacterDict(CombatChar.ChangeCharId);
		CombatChar.ClearAllDoingOrReserveCommand(context);
		CombatChar.SetAffectingDefendSkillId(-1, context);
		CombatChar.SetAffectingMoveSkillId(-1, context);
		CombatChar.SetAnimationToLoop(null, context);
		CombatChar.SetParticleToLoop(null, context);
		if (CombatChar.ChangeCharFailAni != null)
		{
			CombatChar.SetAnimationToPlayOnce(CombatChar.ChangeCharFailAni, context);
			if (CombatChar.ChangeCharFailParticle != "")
			{
				CombatChar.SetParticleToPlay(CombatChar.ChangeCharFailParticle, context);
			}
			if (CombatChar.ChangeCharFailSound != "")
			{
				CombatChar.SetDieSoundToPlay(CombatChar.ChangeCharFailSound, context);
			}
		}
		else
		{
			CombatChar.SetAnimationToPlayOnce("M_004", context);
			CombatChar.SetParticleToPlay(null, context);
		}
		CurrentCombatDomain.SetCombatCharacter(context, CombatChar.IsAlly, CombatChar.ChangeCharId);
		if (!CurrentCombatDomain.IsMainCharacter(CombatChar))
		{
			newChar.TeammateHasCommand[CurrentCombatDomain.GetCharacterList(CombatChar.IsAlly).IndexOf(CombatChar.GetId()) - 1] = false;
		}
		if (CombatChar.ExecutingTeammateCommandChangeDistance != 0)
		{
			CurrentCombatDomain.ChangeDistance(context, CombatChar, CombatChar.ExecutingTeammateCommandChangeDistance);
			CombatChar.ExecutingTeammateCommandChangeDistance = 0;
		}
		CombatChar.SetExecutingTeammateCommand(-1, context);
		CombatChar.SetTeammateCommandTimePercent(0, context);
		CombatChar.StateMachine.TranslateState(CombatCharacterStateType.Idle);
		CombatChar.ChangeCharId = -1;
		CombatChar.ClearAllSound(context);
		newChar.SetCurrentPosition(CombatChar.GetCurrentPosition(), context);
		CurrentCombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, int.MinValue);
		newChar.StateMachine.TranslateState(CombatCharacterStateType.ChangeCharacter);
	}

	private bool CheckCommonTranslateState()
	{
		CombatCharacterStateType properState = CombatChar.StateMachine.GetProperState();
		if (StateType == CombatCharacterStateType.Idle)
		{
			if (!CombatChar.IsMoving && properState != StateType)
			{
				return true;
			}
			if (CombatChar.IsMoving && properState == CombatCharacterStateType.PrepareAttack)
			{
				return true;
			}
		}
		if (StateType == CombatCharacterStateType.PrepareAttack)
		{
			return properState == CombatCharacterStateType.ChangeBossPhase;
		}
		return false;
	}

	private void TimeUpdate(DataContext context, CombatCharacter combatChar, bool isMainOrCurrChar = true)
	{
		TimeUpdateRecoverStandard(context, combatChar, isMainOrCurrChar);
		TimeUpdateFlawAcupoint(context, combatChar);
		TimeUpdateMindMark(context, combatChar);
		combatChar.TickScarMark(context);
		TimeUpdateAutoHeal(context, combatChar);
		TimeUpdateNeiliAllocation(context, combatChar);
		TimeUpdateMain(context, combatChar, isMainOrCurrChar);
	}

	private static void TimeUpdateRecoverStandard(DataContext context, CombatCharacter combatChar, bool isMainOrCurrChar)
	{
		bool preparingSkill = combatChar.GetPreparingSkillId() >= 0;
		if (!isMainOrCurrChar || combatChar.GetPreparingOtherAction() != -1)
		{
			return;
		}
		CombatDomain combatDomain = DomainManager.Combat;
		if (combatChar.GetBreathValue() < combatChar.GetMaxBreathValue() && !preparingSkill)
		{
			combatDomain.RecoverBreathValue(context, combatChar);
			if (combatDomain.IsCurrentCombatCharacter(combatChar))
			{
				combatDomain.UpdateSkillCostBreathStanceCanUse(context, combatChar);
			}
		}
		if (combatChar.GetAffectingMoveSkillId() < 0 && (!preparingSkill || combatChar.MoveData.CanMoveForwardInSkillPrepareDist > 0 || combatChar.MoveData.CanMoveBackwardInSkillPrepareDist > 0))
		{
			combatDomain.RecoverMobilityValue(context, combatChar);
		}
		ItemKey[] weapons = combatChar.GetWeapons();
		for (int i = 0; i < 3; i++)
		{
			if (weapons[i].IsValid())
			{
				int addValue = combatChar.GetRecoverUnlockAttackValue(weapons[i]);
				if (addValue > 0)
				{
					combatChar.ChangeUnlockAttackValue(context, i, addValue);
				}
			}
		}
	}

	private static void TimeUpdateFlawAcupoint(DataContext context, CombatCharacter combatChar)
	{
		CombatDomain combatDomain = DomainManager.Combat;
		FlawOrAcupointCollection flaw = combatChar.GetFlawCollection();
		FlawOrAcupointCollection acupoint = combatChar.GetAcupointCollection();
		byte[] flawCount = combatChar.GetFlawCount();
		byte[] acupointCount = combatChar.GetAcupointCount();
		int flawSpeed = combatChar.GetRecoveryOfFlaw();
		int acupointSpeed = combatChar.GetRecoveryOfAcupoint();
		FlawOrAcupointCollection.ReduceKeepTimeResult flawRetValue = flaw.ReduceKeepTime(flawSpeed, flawCount);
		FlawOrAcupointCollection.ReduceKeepTimeResult acupointRetValue = acupoint.ReduceKeepTime(acupointSpeed, acupointCount);
		if (flawRetValue.DataChanged)
		{
			combatChar.SetFlawCollection(flaw, context);
		}
		if (acupointRetValue.DataChanged)
		{
			combatChar.SetAcupointCollection(acupoint, context);
		}
		if (flawRetValue.CountChanged || acupointRetValue.CountChanged)
		{
			if (flawRetValue.CountChanged)
			{
				combatChar.SetFlawCount(combatChar.GetFlawCount(), context);
				if (combatDomain.IsMainCharacter(combatChar))
				{
					combatDomain.UpdateAllTeammateCommandUsable(context, combatChar.IsAlly, ETeammateCommandImplement.HealFlaw);
				}
			}
			if (acupointRetValue.CountChanged)
			{
				combatChar.SetAcupointCount(combatChar.GetAcupointCount(), context);
				if (combatDomain.IsMainCharacter(combatChar))
				{
					combatDomain.UpdateAllTeammateCommandUsable(context, combatChar.IsAlly, ETeammateCommandImplement.HealFlaw);
				}
			}
			combatDomain.UpdateBodyDefeatMark(context, combatChar);
		}
		for (int i = 0; i < flawRetValue.RemovedList.Count; i++)
		{
			(sbyte, sbyte) removedFlaw = flawRetValue.RemovedList[i];
			Events.RaiseFlawRemoved(context, combatChar, removedFlaw.Item1, removedFlaw.Item2);
		}
		for (int j = 0; j < acupointRetValue.RemovedList.Count; j++)
		{
			(sbyte, sbyte) removedAcupoint = acupointRetValue.RemovedList[j];
			Events.RaiseAcuPointRemoved(context, combatChar, removedAcupoint.Item1, removedAcupoint.Item2);
		}
	}

	private static void TimeUpdateMindMark(DataContext context, CombatCharacter combatChar)
	{
		MindMarkList mindMarkList = combatChar.GetMindMarkTime();
		List<CountdownData> markList = mindMarkList.MarkList;
		if (markList != null && markList.Count > 0)
		{
			int mindRecoverSpeed = DomainManager.SpecialEffect.ModifyValue(combatChar.GetId(), 187, 1);
			for (int i = mindMarkList.MarkList.Count - 1; i >= 0; i--)
			{
				CountdownData mark = mindMarkList.MarkList[i];
				mark.Tick(mindRecoverSpeed);
				if (mark.On)
				{
					mindMarkList.MarkList[i] = mark;
				}
				else
				{
					mindMarkList.MarkList.RemoveAt(i);
				}
			}
			combatChar.SetMindMarkTime(mindMarkList, context);
			combatChar.UpdateMindMark(context);
		}
		combatChar.TickMindUpheaval(context);
	}

	private static void TimeUpdateAutoHeal(DataContext context, CombatCharacter combatChar)
	{
		Dictionary<sbyte, OuterAndInnerInts> bodyPart2Delta = ObjectPool<Dictionary<sbyte, OuterAndInnerInts>>.Instance.Get();
		Injuries injuries = combatChar.GetInjuries();
		Injuries oldInjuries = combatChar.GetOldInjuries();
		bool injuriesChanged = false;
		bool oldInjuriesChanged = false;
		int outerSpeed = combatChar.OuterInjuryAutoHealSpeeds.Max();
		int innerSpeed = combatChar.InnerInjuryAutoHealSpeeds.Max();
		outerSpeed = DomainManager.SpecialEffect.ModifyValue(combatChar.GetId(), 188, outerSpeed);
		innerSpeed = DomainManager.SpecialEffect.ModifyValue(combatChar.GetId(), 188, innerSpeed);
		InjuryAutoHealCollection autoHealCollection = combatChar.GetInjuryAutoHealCollection();
		if (autoHealCollection.UpdateProgress(bodyPart2Delta, outerSpeed, innerSpeed))
		{
			combatChar.SetInjuryAutoHealCollection(autoHealCollection, context);
			ApplyDeltas(changeOld: false);
		}
		short oldOuterSpeed = combatChar.OuterOldInjuryAutoHealSpeeds.Max();
		short oldInnerSpeed = combatChar.InnerOldInjuryAutoHealSpeeds.Max();
		InjuryAutoHealCollection oldAutoHealCollection = combatChar.GetOldInjuryAutoHealCollection();
		if (oldAutoHealCollection.UpdateProgress(bodyPart2Delta, oldOuterSpeed, oldInnerSpeed))
		{
			combatChar.SetOldInjuryAutoHealCollection(oldAutoHealCollection, context);
			ApplyDeltas(changeOld: true);
		}
		ObjectPool<Dictionary<sbyte, OuterAndInnerInts>>.Instance.Return(bodyPart2Delta);
		if (oldInjuriesChanged)
		{
			combatChar.SetOldInjuries(oldInjuries, context);
		}
		if (injuriesChanged)
		{
			combatChar.SetInjuries(context, injuries, updateDefeatMark: true, syncAutoHealProgress: false);
		}
		void ApplyDeltas(bool changeOld)
		{
			foreach (var (bodyPart, delta) in bodyPart2Delta)
			{
				if (delta.Outer > 0 || delta.Inner > 0)
				{
					injuriesChanged = true;
					injuries.Change(bodyPart, isInnerInjury: false, (sbyte)(-delta.Outer));
					injuries.Change(bodyPart, isInnerInjury: true, (sbyte)(-delta.Inner));
					if (changeOld)
					{
						oldInjuriesChanged = true;
						oldInjuries.Change(bodyPart, isInnerInjury: false, (sbyte)(-delta.Outer));
						oldInjuries.Change(bodyPart, isInnerInjury: true, (sbyte)(-delta.Inner));
					}
				}
			}
		}
	}

	private static void TimeUpdateNeiliAllocation(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.TickNeiliAllocationCd(context))
		{
			return;
		}
		NeiliAllocation neiliAllocation = combatChar.GetNeiliAllocation();
		NeiliAllocation originNeiliAllocation = combatChar.GetOriginNeiliAllocation();
		int recoveryOfQiDisorder = combatChar.GetCharacter().GetRecoveryOfQiDisorder();
		for (byte type = 0; type < 4; type++)
		{
			int currValue = neiliAllocation[type];
			int originValue = originNeiliAllocation[type];
			if (currValue == originValue)
			{
				continue;
			}
			GameData.Domains.Character.Character charObj = combatChar.GetCharacter();
			int costNeili = 0;
			if (currValue < originValue)
			{
				sbyte qiDisorderLevel = DisorderLevelOfQi.GetDisorderLevelOfQi(charObj.GetDisorderOfQi());
				costNeili = CombatHelper.CalcNeiliCostInCombat((short)currValue, qiDisorderLevel);
				if (charObj.GetCurrNeili() < costNeili)
				{
					combatChar.SetNeiliAllocationRecoverProgress(context, type, 0);
					continue;
				}
			}
			int totalProgress = ((currValue > originValue) ? GlobalConfig.Instance.CombatNeiliAllocationAutoReduceTotalProgress : GlobalConfig.Instance.CombatNeiliAllocationAutoAddTotalProgress);
			int addProgress = CFormula.CalcNeiliAllocationAutoRecoverProgress(recoveryOfQiDisorder, currValue, originValue);
			ECharacterPropertyReferencedType mysteryType = ((currValue > originValue) ? ECharacterPropertyReferencedType.NeiliAllocationReduceSpeed : ECharacterPropertyReferencedType.NeiliAllocationAddSpeed);
			addProgress *= combatChar.GetCharacter().CalcMysteryBonus(mysteryType);
			combatChar.NeiliAllocationAutoRecoverProgress[type] += addProgress;
			if (combatChar.NeiliAllocationAutoRecoverProgress[type] >= totalProgress)
			{
				combatChar.NeiliAllocationAutoRecoverProgress[type] = 0;
				combatChar.SetNeiliAllocationRecoverProgress(context, type, 0);
				if (currValue > originValue)
				{
					combatChar.ChangeNeiliAllocation(context, type, -1, applySpecialEffect: false, raiseEvent: true, applyChallengeModeQiDisorder: false);
					continue;
				}
				combatChar.ChangeNeiliAllocation(context, type, 1, applySpecialEffect: false, raiseEvent: true, applyChallengeModeQiDisorder: false);
				charObj.ChangeCurrNeili(context, -costNeili);
			}
			else
			{
				short recoverPercent = (short)((currValue > originValue) ? ((totalProgress - combatChar.NeiliAllocationAutoRecoverProgress[type]) * 100 / totalProgress) : (combatChar.NeiliAllocationAutoRecoverProgress[type] * 100 / totalProgress));
				combatChar.SetNeiliAllocationRecoverProgress(context, type, recoverPercent);
			}
		}
	}

	private static void TimeUpdateMain(DataContext context, CombatCharacter combatChar, bool isMainOrCurrChar)
	{
		if (isMainOrCurrChar)
		{
			TimeUpdateMainAgile(context, combatChar);
			TimeUpdateNormalAttackRecovery(context, combatChar);
			DomainManager.Combat.UpdateWeaponCd(context, combatChar);
			DomainManager.Combat.UpdateSkillCd(context, combatChar);
			TimeUpdateMainDefend(context, combatChar);
			TimeUpdateMainPoison(combatChar);
			TimeUpdateMainTeammateCommand(context, combatChar);
		}
	}

	private static void TimeUpdateMainAgile(DataContext context, CombatCharacter combatChar)
	{
		short moveSkillId = combatChar.GetAffectingMoveSkillId();
		if (moveSkillId >= 0)
		{
			int costMobility = DomainManager.Combat.GetSkillCostMobilityPerFrame(combatChar, moveSkillId);
			DomainManager.Combat.ChangeMobilityValue(context, combatChar, -costMobility);
			if (combatChar.GetMobilityValue() <= 0)
			{
				combatChar.SetAffectingMoveSkillId(-1, context);
				return;
			}
			int addMobility = Config.CombatSkill.Instance[moveSkillId].MobilityAddSpeed;
			DomainManager.Combat.ChangeMobilityValue(context, combatChar, addMobility);
		}
	}

	private static void TimeUpdateNormalAttackRecovery(DataContext context, CombatCharacter combatChar)
	{
		CountdownData recoveryData = combatChar.GetNormalAttackRecovery();
		if (recoveryData.Tick())
		{
			combatChar.SetNormalAttackRecovery(recoveryData, context);
		}
	}

	private static void TimeUpdateMainDefend(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.GetAffectingDefendSkillId() < 0)
		{
			return;
		}
		combatChar.DefendSkillLeftFrame--;
		if (combatChar.DefendSkillLeftFrame > 0)
		{
			byte percent = (byte)(combatChar.DefendSkillLeftFrame * 100 / combatChar.DefendSkillTotalFrame);
			if (percent != combatChar.GetDefendSkillTimePercent())
			{
				combatChar.SetDefendSkillTimePercent(percent, context);
			}
		}
		else
		{
			combatChar.SetAffectingDefendSkillId(-1, context);
			DomainManager.Combat.SetProperLoopAniAndParticle(context, combatChar);
			DomainManager.Combat.UpdateSkillCanUse(context, combatChar);
		}
	}

	private static void TimeUpdateMainPoison(CombatCharacter combatChar)
	{
		if (combatChar.PoisonOverflow(4))
		{
			combatChar.AddPoisonAffectValue(4, 1);
		}
		if (combatChar.PoisonOverflow(5))
		{
			combatChar.AddPoisonAffectValue(5, 1);
		}
	}

	private static void TimeUpdateMainTeammateCommand(DataContext context, CombatCharacter combatChar)
	{
		if (!DomainManager.Combat.IsMainCharacter(combatChar))
		{
			return;
		}
		foreach (CombatCharacter teammate in DomainManager.Combat.GetTeammateCharacters(combatChar.GetId()))
		{
			int teammateId = teammate.GetId();
			if (DomainManager.Combat.IsCharacterFallen(teammate))
			{
				continue;
			}
			List<sbyte> cmdList = teammate.GetCurrTeammateCommands();
			List<CountdownData> cdList = teammate.GetTeammateCommandCd();
			bool anyChanged = false;
			for (int i = 0; i < cmdList.Count; i++)
			{
				CountdownData cd = cdList[i];
				if (cmdList[i] >= 0 && !cd.Off && !cd.Infinite && !combatChar.IsBeforeOrAfterTeammate(teammateId))
				{
					anyChanged = true;
					int cdSpeed = teammate.GetTeammateCommandCdSpeed()[i];
					cd.Tick(cdSpeed);
					cdList[i] = cd;
					if (cd.Off)
					{
						DomainManager.Combat.UpdateTeammateCommandUsable(context, teammate, cmdList[i]);
					}
				}
			}
			if (anyChanged)
			{
				teammate.SetTeammateCommandCd(cdList, context);
			}
		}
	}
}
