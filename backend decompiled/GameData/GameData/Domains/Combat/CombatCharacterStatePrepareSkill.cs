using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.Combat;

public class CombatCharacterStatePrepareSkill : CombatCharacterStateBase
{
	public CombatCharacterStatePrepareSkill(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.PrepareSkill)
	{
	}

	public override void OnEnter()
	{
		DataContext context = CombatChar.GetDataContext();
		short skillId;
		if (!CombatChar.NeedChangeSkill)
		{
			skillId = -1;
		}
		else if (CombatChar.NeedUseSkillFreeId >= 0)
		{
			skillId = CombatChar.NeedUseSkillFreeId;
			List<CastFreeData> castFreeDataList = CombatChar.CastFreeDataList;
			ECombatCastFreePriority priority = castFreeDataList[castFreeDataList.Count - 1].Priority;
			CombatChar.CastFreeDataList.RemoveAt(CombatChar.CastFreeDataList.Count - 1);
			CombatChar.SetAutoCastingSkill(autoCastingSkill: false, context);
			if (!CurrentCombatDomain.CanCastSkill(CombatChar, skillId, costFree: true) && priority != ECombatCastFreePriority.Gm)
			{
				CombatChar.StateMachine.TranslateState();
				return;
			}
			if (priority != ECombatCastFreePriority.Gm)
			{
				CombatChar.SetAutoCastingSkill(autoCastingSkill: true, context);
			}
			CombatChar.MoveData.ResetJumpState(context, calcPreparedMove: false);
		}
		else
		{
			skillId = CombatChar.NeedUseSkillId;
			CombatChar.SetNeedUseSkillId(context, -1);
			CombatChar.SetAutoCastingSkill(autoCastingSkill: false, context);
			if (skillId == CombatChar.NeedAddEffectAgileSkillId || skillId == CombatChar.GetAffectingMoveSkillId())
			{
				CombatChar.StateMachine.TranslateState();
				return;
			}
			if (!CurrentCombatDomain.CanCastSkill(CombatChar, skillId))
			{
				CombatChar.StateMachine.TranslateState();
				return;
			}
			CurrentCombatDomain.DoCombatSkillCost(context, CombatChar, skillId);
		}
		if (skillId >= 0)
		{
			if (CombatChar.GetAffectingMoveSkillId() >= 0 && DomainManager.CombatSkill.GetSkillType(CombatChar.GetId(), skillId) == 5)
			{
				Events.RaiseCastLegSkillWithAgile(context, CombatChar, skillId);
			}
			skillId = (short)DomainManager.SpecialEffect.ModifyData(CombatChar.GetId(), -1, 156, skillId);
			CombatSkillItem configData = Config.CombatSkill.Instance[skillId];
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(CombatChar.GetId(), skillId));
			int totalProgress = skill.GetPrepareTotalProgress();
			if (CurrentCombatDomain.SkillBodyPartHasHeavyInjury(CombatChar, skillId))
			{
				totalProgress *= 2;
			}
			CombatChar.SkillPrepareTotalProgress = totalProgress;
			CombatChar.SkillPrepareCurrProgress = 0;
			CombatChar.SetPreparingSkillId(skillId, context);
			DomainManager.Combat.UpdateAllTeammateCommandUsable(context, CombatChar.IsAlly, -1);
			DomainManager.Combat.UpdateAllTeammateCommandUsable(context, !CombatChar.IsAlly, ETeammateCommandImplement.InterruptEnemySkill);
			Events.RaisePrepareSkillEffectNotYetCreated(context, CombatChar, skillId);
			if (configData.EquipType == 1)
			{
				DomainManager.SpecialEffect.Add(context, CombatChar.GetId(), skillId, 0, -1);
			}
			Events.RaisePrepareSkillBegin(context, CombatChar.GetId(), CombatChar.IsAlly, skillId);
		}
		CurrentCombatDomain.SetProperLoopAniAndParticle(context, CombatChar);
		if (DomainManager.Combat.TryGetCombatSkillData(CombatChar.GetId(), CombatChar.GetPreparingSkillId(), out var skillData) && skillData.GetSilencing())
		{
			DomainManager.Combat.InterruptSkill(context, CombatChar);
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
		if (DomainManager.Combat.GetCombatCharacter(!CombatChar.IsAlly).NeedChangeBossPhase)
		{
			return false;
		}
		if (CombatChar.GetPreparingSkillId() < 0)
		{
			CombatCharacterStateType properState = CombatChar.StateMachine.GetProperState();
			CombatChar.MoveData.ClearSkillPrepareMoveDist();
			if (properState != CombatCharacterStateType.PrepareSkill)
			{
				CombatChar.StateMachine.TranslateState(properState);
			}
			else
			{
				OnEnter();
			}
			return false;
		}
		DataContext context = CombatChar.GetDataContext();
		int newProgress = CombatChar.SkillPrepareCurrProgress + CurrentCombatDomain.GetSkillPrepareSpeed(CombatChar);
		CombatChar.SkillPrepareCurrProgress = Math.Min(newProgress, CombatChar.SkillPrepareTotalProgress);
		byte preparePercent = (byte)CValuePercent.ParseInt(CombatChar.SkillPrepareCurrProgress, CombatChar.SkillPrepareTotalProgress);
		if (preparePercent != CombatChar.GetSkillPreparePercent())
		{
			CombatChar.SetSkillPreparePercent(preparePercent, CombatChar.GetDataContext());
			Events.RaisePrepareSkillProgressChange(CombatChar.GetDataContext(), CombatChar.GetId(), CombatChar.IsAlly, CombatChar.GetPreparingSkillId(), (sbyte)preparePercent);
		}
		if (CombatChar.SkillPrepareCurrProgress == CombatChar.SkillPrepareTotalProgress)
		{
			short skillId = CombatChar.GetPreparingSkillId();
			CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillId];
			CurrentCombatDomain.CalcSkillQiDisorderAndInjury(CombatChar, skillConfig);
			if (CurrentCombatDomain.IsMainCharacter(CombatChar))
			{
				CurrentCombatDomain.UpdateAllTeammateCommandUsable(context, CombatChar.IsAlly, -1);
			}
			if (skillConfig.EquipType == 1 && CurrentCombatDomain.IsMainCharacter(CombatChar))
			{
				CurrentCombatDomain.ForceAllTeammateLeaveCombatField(context, CombatChar.IsAlly);
			}
			CombatChar.MoveData.ClearSkillPrepareMoveDist();
			CombatChar.StateMachine.TranslateState((!CurrentCombatDomain.IsCharacterFallen(CombatChar)) ? CombatCharacterStateType.CastSkill : CombatCharacterStateType.Idle);
			return false;
		}
		if (CombatChar.NeedChangeSkill)
		{
			if (Config.CombatSkill.Instance[CombatChar.NeedUseSkillId].EquipType == 1)
			{
				Events.RaiseChangePreparingSkillBegin(context, CombatChar.GetId(), CombatChar.GetPreparingSkillId(), CombatChar.NeedUseSkillId);
				OnEnter();
			}
			else
			{
				CurrentCombatDomain.CastAgileOrDefenseWithoutPrepare(CombatChar, CombatChar.NeedUseSkillId);
				CombatChar.SetNeedUseSkillId(CombatChar.GetDataContext(), -1);
			}
		}
		if (CombatChar.NeedUseGoldenWire)
		{
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.UseGoldenWire);
		}
		if (CombatChar.NeedNormalAttack)
		{
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.PrepareAttack);
		}
		if (CombatChar.NeedUnlockAttack)
		{
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.UnlockAttack);
		}
		if (CombatChar.NeedShowChangeTrick)
		{
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.SelectChangeTrick);
		}
		return false;
	}
}
