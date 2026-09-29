using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public class CombatCharacterStatePrepareUseItem : CombatCharacterStateBase
{
	private sbyte _itemUseType;

	private List<sbyte> _itemTargetBodyParts;

	public CombatCharacterStatePrepareUseItem(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.PrepareUseItem)
	{
	}

	public override void OnEnter()
	{
		if (CombatChar.GetPreparingItem().IsValid())
		{
			return;
		}
		base.OnEnter();
		AutoUpdateDelayCall = false;
		DataContext context = CombatChar.GetDataContext();
		ItemKey itemKey = CombatChar.NeedUseItem;
		ItemKey repairItem = CombatChar.NeedRepairItem;
		_itemUseType = CombatChar.ItemUseType;
		_itemTargetBodyParts = CombatChar.ItemTargetBodyParts;
		CombatChar.SetNeedUseItem(context, ItemKey.Invalid);
		CombatChar.NeedRepairItem = ItemKey.Invalid;
		CombatChar.ItemUseType = -1;
		CombatChar.ItemTargetBodyParts = null;
		if (!CheckItemKeyIsValid(itemKey))
		{
			ClearStateAndTranslateState();
			return;
		}
		if (itemKey.ItemType == 12 && SharedConstValue.SwordFragment2BossId.ContainsKey(itemKey.TemplateId))
		{
			short skillId = DomainManager.Item.GetSwordFragmentCurrSkill(itemKey);
			List<short> learnedSkills = CombatChar.GetCharacter().GetLearnedCombatSkills();
			if (!learnedSkills.Contains(skillId))
			{
				sbyte outlineType = CombatChar.GetCharacter().GetBehaviorType();
				byte outlineIndex = CombatSkillStateHelper.GetPageInternalIndex(outlineType, 0, 0);
				ushort readingState = CombatSkillStateHelper.SetPageRead(0, outlineIndex);
				ushort activeState = CombatSkillStateHelper.SetPageActive(0, outlineIndex);
				for (byte page = 1; page <= 5; page++)
				{
					byte index = CombatSkillStateHelper.GetPageInternalIndex(outlineType, 0, page);
					readingState = CombatSkillStateHelper.SetPageRead(readingState, index);
					activeState = CombatSkillStateHelper.SetPageActive(activeState, index);
				}
				GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.CreateCombatSkill(CombatChar.GetId(), skillId, readingState);
				skill.SetActivationState(activeState, context);
				learnedSkills.Add(skillId);
				CombatChar.GetCharacter().SetLearnedCombatSkills(learnedSkills, context);
				CombatChar.ForgetAfterCombatSkills.Add(skillId);
				DomainManager.SpecialEffect.Add(context, CombatChar.GetId(), skillId, 1, -1);
			}
			CombatChar.GetCharacter().ChangeXiangshuInfection(context, GlobalConfig.Instance.UseSwordFragmentAddXiangshuInfection);
			CurrentCombatDomain.CastSkillFree(context, CombatChar, skillId, ECombatCastFreePriority.SwordFragment);
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.PrepareSkill);
			Events.RaiseUsedAvatarFragment(context, CombatChar);
			return;
		}
		int costWisdom = itemKey.GetConsumedFeatureMedals();
		if (CombatChar.GetUseItemCostNoWisdom())
		{
			costWisdom = 0;
		}
		if (!(CombatChar.IsAlly ? (CurrentCombatDomain.GetSelfTeamWisdomCount() >= costWisdom) : (CurrentCombatDomain.GetEnemyTeamWisdomCount() >= costWisdom)))
		{
			ClearStateAndTranslateState();
			return;
		}
		if (costWisdom > 0)
		{
			CurrentCombatDomain.CostWisdom(context, CombatChar.IsAlly, costWisdom);
		}
		int prepareFrames = itemKey.GetConfigAs<ICombatItemConfig>()?.UseFrame ?? 0;
		CombatChar.SetPreparingItem(itemKey, context);
		if (CombatChar.GetUseItemPreparePercent() != 0)
		{
			CombatChar.SetUseItemPreparePercent(0, context);
		}
		sbyte itemType = itemKey.ItemType;
		bool flag = ((itemType == 7 || itemType == 9) ? true : false);
		if (flag || (itemKey.ItemType == 8 && _itemUseType == 0))
		{
			goto IL_038e;
		}
		if (itemKey.ItemType == 12)
		{
			short templateId = itemKey.TemplateId;
			if (templateId >= 9 && templateId <= 17)
			{
				goto IL_038e;
			}
		}
		if (itemKey.ItemType == 8)
		{
			CombatItemUseItem throwConfig = CombatItemUse.DefValue.PrepareThrowPoison;
			CombatChar.SetAnimationToPlayOnce(throwConfig.Animation, context);
			CombatChar.SetParticleToPlay(throwConfig.Particle, context);
			CombatChar.SetSkillSoundToPlay(throwConfig.Sound, context);
		}
		else if (itemKey.ItemType == 6)
		{
			CombatChar.RepairingItem = repairItem;
			ItemBase targetItem = DomainManager.Item.GetBaseItem(repairItem);
			if (targetItem.GetMaxDurability() == targetItem.GetCurrDurability())
			{
				ClearStateAndTranslateState();
				return;
			}
			prepareFrames *= targetItem.GetMaxDurability() - targetItem.GetCurrDurability();
			prepareFrames *= ((targetItem.GetCurrDurability() > 0) ? 1 : 2);
			CombatItemUseItem repairConfig = CombatItemUse.Instance[(short)3];
			CombatChar.SpecialAnimationLoop = repairConfig.Animation;
			CombatChar.SetAnimationToLoop(repairConfig.Animation, context);
			CombatChar.SetParticleToLoop(repairConfig.Particle, context);
		}
		else
		{
			if (itemKey.ItemType == 12)
			{
				short templateId = itemKey.TemplateId;
				if (templateId >= 82 && templateId <= 90)
				{
					CombatItemUseItem ropeConfig = CombatItemUse.Instance[(short)4];
					CombatChar.SpecialAnimationLoop = ropeConfig.Animation;
					CombatChar.SetAnimationToLoop(ropeConfig.Animation, context);
					CombatChar.SetParticleToLoop(ropeConfig.Particle, context);
					CombatChar.SetSoundToLoop(ropeConfig.Sound, context);
					goto IL_063b;
				}
			}
			if (itemKey.ItemType == 12)
			{
				short templateId = itemKey.TemplateId;
				if (templateId >= 254 && templateId <= 263)
				{
					CombatItemUseItem useItemConfig = CombatItemUse.Instance[Config.Misc.Instance[itemKey.TemplateId].CombatPrepareUseEffect];
					CombatChar.SetAnimationToPlayOnce(useItemConfig.Animation, context);
					CombatChar.SetParticleToPlay(useItemConfig.Particle, context);
					goto IL_063b;
				}
			}
			CombatItemUseItem useXiangshuSwordConfig = CombatItemUse.Instance[(short)2];
			CombatChar.SetAnimationToPlayOnce(useXiangshuSwordConfig.Animation, context);
		}
		goto IL_063b;
		IL_038e:
		CombatItemUseItem eatConfig = CombatItemUse.DefValue.EatItem;
		CombatChar.SetAnimationToPlayOnce(eatConfig.Animation, context);
		CombatChar.SetParticleToPlay((CombatChar.BossConfig == null) ? eatConfig.Particle : CombatChar.BossConfig.EatParticles[CombatChar.GetBossPhase()], context);
		goto IL_063b;
		IL_063b:
		DomainManager.Combat.UpdateAllTeammateCommandUsable(context, CombatChar.IsAlly, ETeammateCommandImplement.InterruptOtherAction);
		DelayCall(OnPrepared, OnPrepareTickPercent, prepareFrames);
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
		if (CheckInterruptPrepare())
		{
			return false;
		}
		UpdateDelayCall();
		return false;
	}

	private bool CheckInterruptPrepare()
	{
		bool preparingItemInvalid = !CombatChar.GetValidItems().Contains(CombatChar.GetPreparingItem());
		bool repairingItemInvalid = CombatChar.GetPreparingItem().ItemType == 6 && DomainManager.Item.TryGetBaseItem(CombatChar.RepairingItem) == null;
		if (!preparingItemInvalid && !repairingItemInvalid)
		{
			return false;
		}
		ClearStateAndTranslateState();
		return true;
	}

	private void OnPrepareTickPercent(int preparePercent)
	{
		if (preparePercent != CombatChar.GetUseItemPreparePercent())
		{
			CombatChar.SetUseItemPreparePercent((byte)preparePercent, CombatChar.GetDataContext());
		}
	}

	private void OnPrepared()
	{
		DataContext context = CombatChar.GetDataContext();
		ItemKey itemKey = CombatChar.GetPreparingItem();
		bool enterUseItemState = false;
		Events.RaiseUsedItem(context, CombatChar);
		if (itemKey.ItemType != 7 && itemKey.ItemType != 9 && (itemKey.ItemType != 8 || _itemUseType != 0))
		{
			if (itemKey.ItemType == 12)
			{
				short templateId = itemKey.TemplateId;
				if (templateId >= 9 && templateId <= 17)
				{
					goto IL_009f;
				}
			}
			if (!ItemTemplateHelper.IsTianJieFuLu(itemKey.ItemType, itemKey.TemplateId) && (itemKey.ItemType != 5 || !DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(54)))
			{
				if (itemKey.ItemType == 6)
				{
					short newDurability = DomainManager.Building.RepairItemOptional(context, CombatChar.GetId(), itemKey, CombatChar.RepairingItem, 1).Durability;
					if (DomainManager.Combat.TryGetElement_WeaponDataDict(CombatChar.RepairingItem.Id, out var weaponData))
					{
						weaponData.SetDurability(newDurability, context);
					}
					DomainManager.Combat.EnsureOldDurability(CombatChar.RepairingItem);
					CombatChar.SetParticleToLoop(null, context);
				}
				else
				{
					if (itemKey.ItemType == 12)
					{
						short templateId = itemKey.TemplateId;
						if (templateId >= 229 && templateId <= 238)
						{
							goto IL_024e;
						}
					}
					enterUseItemState = true;
				}
				goto IL_024e;
			}
		}
		goto IL_009f;
		IL_009f:
		if (ItemTemplateHelper.IsTianJieFuLu(itemKey.ItemType, itemKey.TemplateId))
		{
			DomainManager.Extra.EatTianJieFuLu(context, CombatChar.GetId(), itemKey, ItemTemplateHelper.GetTianJieFuLuCountUnit());
		}
		else
		{
			DomainManager.Character.AddEatingItem(context, CombatChar.GetId(), itemKey, _itemTargetBodyParts);
		}
		SyncInjuryAndPoison();
		if (!EatingItems.IsWug(itemKey))
		{
			Events.RaiseUsedMedicine(context, CombatChar.GetId(), itemKey);
		}
		else
		{
			CurrentCombatDomain.ShowWugKingEffectTips(context, CombatChar.GetId(), CombatChar.GetId());
		}
		if (CombatChar.GetOldDisorderOfQi() > CombatChar.GetCharacter().GetDisorderOfQi())
		{
			CombatChar.SetOldDisorderOfQi(CombatChar.GetCharacter().GetDisorderOfQi(), context);
		}
		goto IL_024e;
		IL_024e:
		CombatChar.SpecialAnimationLoop = null;
		if (enterUseItemState)
		{
			CombatChar.UsingItem = CombatChar.GetPreparingItem();
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.UseItem);
		}
		else if (CombatChar.NeedUseItem.IsValid())
		{
			ClearState();
			OnEnter();
		}
		else
		{
			ClearStateAndTranslateState();
		}
	}

	private void ClearState()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatChar.SetPreparingItem(ItemKey.Invalid, context);
		CombatChar.RepairingItem = ItemKey.Invalid;
		CombatChar.SetParticleToLoop(null, context);
		CombatChar.SpecialAnimationLoop = null;
	}

	private void ClearStateAndTranslateState()
	{
		ClearState();
		CombatChar.StateMachine.TranslateState();
	}

	private unsafe void SyncInjuryAndPoison()
	{
		DataContext context = CombatChar.GetDataContext();
		PoisonInts poisons = CombatChar.GetCharacter().GetPoisoned();
		PoisonInts lastPoisons = CombatChar.GetPoison();
		DomainManager.Combat.SetPoisons(context, CombatChar, poisons);
		for (sbyte type = 0; type < 6; type++)
		{
			int addedPoison = poisons.Items[type] - lastPoisons.Items[type];
			if (addedPoison > 0)
			{
				Events.RaiseAddPoison(context, CombatChar.GetId(), CombatChar.GetId(), type, 0, addedPoison, -1, canBounce: false);
			}
		}
		CombatChar.SetInjuries(context, CombatChar.GetCharacter().GetInjuries());
	}

	private bool CheckItemKeyIsValid(ItemKey itemKey)
	{
		if (!itemKey.IsValid())
		{
			return false;
		}
		if (itemKey.GetConfig().IsEat() && _itemUseType == 0 && !CombatChar.GetCharacter().AnyAvailableEatingSlot)
		{
			return false;
		}
		sbyte itemType = itemKey.ItemType;
		if (1 == 0)
		{
		}
		GameData.Domains.Item.CraftTool craftTool;
		bool result = ((itemType != 6) ? CombatChar.GetValidItems().Contains(itemKey) : (DomainManager.Item.TryGetElement_CraftTools(itemKey.Id, out craftTool) && craftTool.GetCurrDurability() >= 0));
		if (1 == 0)
		{
		}
		return result;
	}
}
