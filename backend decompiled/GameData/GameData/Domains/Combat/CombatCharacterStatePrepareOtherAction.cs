using System;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public class CombatCharacterStatePrepareOtherAction : CombatCharacterStateBase
{
	private short _totalPrepareFrame;

	private short _leftPrepareFrame;

	public CombatCharacterStatePrepareOtherAction(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.PrepareOtherAction)
	{
	}

	public override void OnEnter()
	{
		DataContext context = CombatChar.GetDataContext();
		if (CombatChar.GetPreparingOtherAction() < 0)
		{
			sbyte actionType = CombatChar.NeedUseOtherAction;
			if (CombatChar.NeedForceFlee)
			{
				actionType = 2;
			}
			else
			{
				CombatChar.SetNeedUseOtherAction(context, -1);
			}
			if (!CheckOtherActionUsable(actionType))
			{
				TranslateProperState();
				return;
			}
			DoOtherActionCost(context, actionType);
			short prepareFrame = CombatChar.GetOtherActionPrepareFrame(actionType);
			_leftPrepareFrame = (_totalPrepareFrame = prepareFrame);
			CombatChar.NeedInterruptSurrender = false;
			CombatChar.SetPreparingOtherAction(actionType, context);
			if (CombatChar.GetOtherActionPreparePercent() != 0)
			{
				CombatChar.SetOtherActionPreparePercent(0, context);
			}
			CombatChar.IsForceFlee = CombatChar.NeedForceFlee;
			CombatChar.NeedForceFlee = false;
		}
		CurrentCombatDomain.SetProperLoopAniAndParticle(context, CombatChar);
		CurrentCombatDomain.UpdateAllTeammateCommandUsable(context, CombatChar.IsAlly, ETeammateCommandImplement.InterruptOtherAction);
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		if (CombatChar.GetPreparingOtherAction() < 0)
		{
			TranslateProperState();
			return false;
		}
		if (CombatChar.GetPreparingOtherAction() == 4)
		{
			if (CombatChar.NeedInterruptSurrender)
			{
				TranslateProperState();
			}
			return false;
		}
		if (_leftPrepareFrame <= 0)
		{
			AdaptableLog.TagWarning("CombatCharacterStatePrepareOtherAction", PredefinedLog.Instance[(short)5].Info, appendWarningMessage: true);
			TranslateProperState();
			return false;
		}
		_leftPrepareFrame--;
		byte preparePercent = (byte)((_totalPrepareFrame - _leftPrepareFrame) * 100 / _totalPrepareFrame);
		if (preparePercent != CombatChar.GetOtherActionPreparePercent())
		{
			CombatChar.SetOtherActionPreparePercent(preparePercent, CombatChar.GetDataContext());
		}
		if (_leftPrepareFrame == 0)
		{
			DataContext context = CombatChar.GetDataContext();
			sbyte actionType = CombatChar.GetPreparingOtherAction();
			switch (actionType)
			{
			case 0:
				CurrentCombatDomain.HealInjuryInCombat(context, CombatChar, CombatChar);
				break;
			case 1:
				CurrentCombatDomain.HealPoisonInCombat(context, CombatChar, CombatChar);
				break;
			case 2:
				CurrentCombatDomain.Flee(context, CombatChar);
				break;
			case 3:
				CombatChar.NeedAnimalAttack = true;
				break;
			}
			if (actionType != 3 && CombatChar.NeedUseOtherAction != -1)
			{
				ReEnter(context);
			}
			else
			{
				TranslateProperState();
			}
			if (CombatDomain.OtherActionSpecialEffectId.Length > actionType)
			{
				CombatChar.GetShowEffectList().ShowEffectList.Add(CurrentCombatDomain.CalcEffectDisplayData(CombatChar.GetId(), CombatDomain.OtherActionSpecialEffectId[actionType], 0, ItemKey.Invalid));
			}
		}
		if (CombatChar.NeedUseSkillFreeId >= 0)
		{
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.PrepareSkill);
		}
		if (CombatChar.NeedNormalAttack)
		{
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.PrepareAttack);
		}
		return false;
	}

	private bool CheckOtherActionUsable(sbyte actionType)
	{
		if ((actionType < 0 || actionType >= 5) ? true : false)
		{
			return false;
		}
		if (actionType == 2 && CombatChar.NeedForceFlee)
		{
			return true;
		}
		if (1 == 0)
		{
		}
		bool flag = actionType switch
		{
			0 => CombatChar.GetHealInjuryCount() > 0, 
			1 => CombatChar.GetHealPoisonCount() > 0, 
			2 => CombatChar.GetOtherActionCanUse()[2], 
			3 => CombatChar.AnimalDurability >= 30, 
			_ => true, 
		};
		if (1 == 0)
		{
		}
		if (!flag)
		{
			return false;
		}
		return !CombatChar.IsAlly || CombatChar.GetOtherActionCanUse()[actionType];
	}

	private void DoOtherActionCost(DataContext context, sbyte actionType)
	{
		switch (actionType)
		{
		case 0:
			CombatChar.SetHealInjuryCount((byte)Math.Max(CombatChar.GetHealInjuryCount() - 1, 0), context);
			DomainManager.Character.UseCombatResources(context, CombatChar.GetId(), EHealActionType.Healing, 1);
			break;
		case 1:
			CombatChar.SetHealPoisonCount((byte)Math.Max(CombatChar.GetHealPoisonCount() - 1, 0), context);
			DomainManager.Character.UseCombatResources(context, CombatChar.GetId(), EHealActionType.Detox, 1);
			break;
		case 3:
			DomainManager.Combat.ChangeDurability(context, CombatChar, CombatChar.AnimalKey, -30, EChangeDurabilitySourceType.Hunter);
			break;
		case 2:
			break;
		}
	}

	private void ReEnter(DataContext context)
	{
		CombatChar.SetPreparingOtherAction(-1, context);
		OnEnter();
	}

	private void TranslateProperState()
	{
		DataContext context = CombatChar.GetDataContext();
		OtherActionTypeItem otherActionConfig = Config.OtherActionType.Instance[CombatChar.GetPreparingOtherAction()];
		CombatChar.SetPreparingOtherAction(-1, context);
		if (CombatChar.IsForceFlee)
		{
			CombatChar.IsForceFlee = false;
		}
		if (otherActionConfig != null)
		{
			if (CombatChar.IsActorSkeleton && !string.IsNullOrEmpty(otherActionConfig.PrepareEndAnim))
			{
				CombatChar.SetAnimationToPlayOnce(otherActionConfig.PrepareEndAnim, context);
			}
			if (CombatChar.IsActorSkeleton && !string.IsNullOrEmpty(otherActionConfig.PrepareEndParticle))
			{
				CombatChar.SetParticleToPlay(otherActionConfig.PrepareEndParticle, context);
			}
		}
		CombatCharacterStateType properState = CombatChar.StateMachine.GetProperState();
		if (properState != CombatCharacterStateType.PrepareOtherAction)
		{
			CombatChar.StateMachine.TranslateState();
		}
		else
		{
			OnEnter();
		}
	}
}
