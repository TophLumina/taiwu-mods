using System.Collections.Generic;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;
using GameData.Domains.Character.Ai.GeneralAction.WealthDemand;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class ContestForLegendaryBookAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort LegendaryBookType = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "LegendaryBookType" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte LegendaryBookType;

	public int PhaseCount => 1;

	public bool OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		LegendaryBookType = argGroup.CombatSkillType;
		return true;
	}

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		if (!DomainManager.Character.TryGetElement_Objects(actionData.TargetCharId, out var targetChar))
		{
			return false;
		}
		if (targetChar.GetKidnapperId() >= 0)
		{
			return false;
		}
		List<sbyte> ownedBookTypes = DomainManager.LegendaryBook.GetCharOwnedBookTypes(actionData.TargetCharId);
		if (ownedBookTypes == null || !ownedBookTypes.Contains(LegendaryBookType))
		{
			return false;
		}
		return true;
	}

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup())
		{
			int selfCharId = selfChar.GetId();
			DomainManager.LifeRecord.GetLifeRecordCollection().AddDecideToContestForLegendaryBook(date: DomainManager.World.GetCurrDate(), location: selfChar.GetLocation(), selfCharId: selfCharId, charId: actionData.TargetCharId, itemType: 12, itemTemplateId: (short)(240 + LegendaryBookType));
			selfChar.TryRetireTreasuryGuard(context);
			DomainManager.LegendaryBook.AddContestForLegendaryBookCharacter(context, selfCharId, LegendaryBookType);
		}
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location currLocation = selfChar.GetLocation();
		lifeRecordCollection.AddFinishContestForLegendaryBook(selfCharId, currDate, currLocation);
		DomainManager.LegendaryBook.RemoveContestForLegendaryBookCharacter(context, selfCharId, LegendaryBookType);
	}

	public void OnCharacterDead(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		DomainManager.LegendaryBook.RemoveContestForLegendaryBookCharacter(context, selfChar.GetId(), LegendaryBookType);
	}

	public unsafe bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		Character targetChar = DomainManager.Character.GetElement_Objects(actionData.TargetCharId);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		int selfCharId = selfChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		sbyte behaviorType = selfChar.GetBehaviorType();
		Personalities personalities = selfChar.GetPersonalities();
		ItemKey itemKey = DomainManager.LegendaryBook.GetLegendaryBookItem(LegendaryBookType);
		DomainManager.LegendaryBook.AddContestForLegendaryBookCharacter(context, selfCharId, LegendaryBookType);
		selfChar.TryRetireTreasuryGuard(context);
		if (context.Random.CheckPercentProb(AiHelper.LegendaryBookRelatedConstants.IdleDuringContestActionChance[behaviorType]))
		{
			return false;
		}
		int indirectContestChance = ((selfChar.GetCombatPower() > targetChar.GetCombatPower()) ? 25 : 75);
		if (context.Random.CheckPercentProb(indirectContestChance))
		{
			sbyte[] array = AiHelper.LegendaryBookContestActionType.IndirectActionPriorities[behaviorType];
			foreach (sbyte actionType in array)
			{
				sbyte personalityType = AiHelper.LegendaryBookContestActionType.ToPersonalityType[actionType];
				int chance = 60 + personalities.Items[personalityType];
				if (!context.Random.CheckPercentProb(chance))
				{
					continue;
				}
				switch (actionType)
				{
				case 0:
				{
					GainExpByCombatAction action2 = new GainExpByCombatAction
					{
						CombatType = CombatType.Play
					};
					if (action2.CheckValid(selfChar, targetChar))
					{
						if (actionData.TargetCharId == taiwuCharId)
						{
							action2.ApplyInitialChangesForTaiwu(context, selfChar, targetChar);
						}
						else
						{
							action2.ApplyChanges(context, selfChar, targetChar);
						}
					}
					return false;
				}
				case 1:
				{
					ItemBase selectedItem = selfChar.SelectSpareableItem(context, targetChar.GetInteractionGrade(selfChar), allowUsed: false);
					if (selectedItem == null)
					{
						return false;
					}
					ItemKey selectedItemKey = selectedItem.GetItemKey();
					GiveItemAction action = new GiveItemAction
					{
						TargetItem = selectedItemKey,
						Amount = 1,
						RefusePoisonousItem = targetChar.TryDetectAttachedPoisons(selectedItemKey)
					};
					if (action.CheckValid(selfChar, targetChar))
					{
						if (actionData.TargetCharId == taiwuCharId)
						{
							action.ApplyInitialChangesForTaiwu(context, selfChar, targetChar);
						}
						else
						{
							action.ApplyChanges(context, selfChar, targetChar);
						}
					}
					return false;
				}
				case 2:
					DomainManager.Character.HandlePoisonAction(context, selfChar, targetChar, ItemKey.Invalid, actionData.Template);
					return false;
				case 3:
					DomainManager.Character.HandlePlotHarmAction(context, selfChar, targetChar, ItemKey.Invalid, actionData.Template);
					return false;
				}
			}
		}
		else
		{
			int alertFactor = targetChar.GetItemAlertFactor(itemKey, 1);
			sbyte[] array;
			if (actionData.TargetCharId == taiwuCharId)
			{
				array = AiHelper.LegendaryBookContestActionType.DirectActionTaiwuTargetPriorities[behaviorType];
				foreach (sbyte actionType2 in array)
				{
					sbyte personalityType2 = AiHelper.LegendaryBookContestActionType.ToPersonalityType[actionType2];
					int chance2 = 60 + personalities.Items[personalityType2];
					if (!context.Random.CheckPercentProb(chance2))
					{
						continue;
					}
					CharacterDomain.AddLockMovementCharSet(selfChar.GetId());
					switch (actionType2)
					{
					case 4:
						if (!DomainManager.Character.IsAiActionInCooldown(selfCharId, 3, 3))
						{
							monthlyEventCollection.AddChallengeForLegendaryBook(selfCharId, location, actionData.TargetCharId, (ulong)itemKey);
							DomainManager.Character.AddAiActionCooldown(context, selfCharId, 3, 3, 12);
						}
						break;
					case 5:
						monthlyEventCollection.AddRequestLegendaryBook(selfCharId, location, actionData.TargetCharId, (ulong)itemKey);
						return false;
					case 6:
						AddTradeForBookMonthlyEvent(selfChar, targetChar, itemKey);
						return false;
					case 7:
						if (DomainManager.Taiwu.CanTaiwuBeSneakyHarmfulActionTarget())
						{
							StealItemAction stealItemAction2 = new StealItemAction();
							stealItemAction2.TargetItem = itemKey;
							stealItemAction2.Amount = 1;
							stealItemAction2.Phase = selfChar.GetStealActionPhase(context.Random, targetChar, alertFactor);
							stealItemAction2.ApplyInitialChangesForTaiwu(context, selfChar, targetChar);
							return false;
						}
						break;
					case 8:
						if (DomainManager.Taiwu.CanTaiwuBeSneakyHarmfulActionTarget())
						{
							StealItemAction stealItemAction = new StealItemAction();
							stealItemAction.TargetItem = itemKey;
							stealItemAction.Amount = 1;
							stealItemAction.Phase = selfChar.GetScamActionPhase(context.Random, targetChar, alertFactor);
							stealItemAction.ApplyInitialChangesForTaiwu(context, selfChar, targetChar);
							return false;
						}
						break;
					case 9:
						if (!DomainManager.Character.IsAiActionInCooldown(selfCharId, 3, 3))
						{
							RobItemAction robItemAction = new RobItemAction();
							robItemAction.TargetItem = itemKey;
							robItemAction.Amount = 1;
							robItemAction.Phase = selfChar.GetRobActionPhase(context.Random, targetChar, alertFactor);
							robItemAction.ApplyInitialChangesForTaiwu(context, selfChar, targetChar);
							DomainManager.Character.AddAiActionCooldown(context, selfCharId, 3, 3, 12);
							return false;
						}
						break;
					}
				}
				return false;
			}
			array = AiHelper.LegendaryBookContestActionType.DirectActionNpcTargetPriorities[behaviorType];
			foreach (sbyte actionType3 in array)
			{
				sbyte personalityType3 = AiHelper.LegendaryBookContestActionType.ToPersonalityType[actionType3];
				int chance3 = 60 + personalities.Items[personalityType3];
				if (!context.Random.CheckPercentProb(chance3))
				{
					continue;
				}
				switch (actionType3)
				{
				case 4:
				{
					AiHelper.NpcCombatResultType resultType = DomainManager.Character.SimulateCharacterCombat(context, selfChar, targetChar, CombatType.Beat, isGroupCombat: false);
					if (resultType == AiHelper.NpcCombatResultType.MajorVictory || resultType == AiHelper.NpcCombatResultType.MinorVictory)
					{
						DomainManager.Character.TransferInventoryItem(context, targetChar, selfChar, itemKey, 1);
						monthlyNotifications.AddChallengeForLegendaryBook(selfCharId, location, actionData.TargetCharId, itemKey.ItemType, itemKey.TemplateId);
						lifeRecordCollection.AddLegendaryBookChallengeWin(selfCharId, currDate, actionData.TargetCharId, location, itemKey.ItemType, itemKey.TemplateId);
					}
					else
					{
						lifeRecordCollection.AddLegendaryBookChallengeLose(selfCharId, currDate, actionData.TargetCharId, location, itemKey.ItemType, itemKey.TemplateId);
					}
					return false;
				}
				case 9:
				{
					RobItemAction action3 = new RobItemAction
					{
						TargetItem = itemKey,
						Amount = 1,
						Phase = selfChar.GetRobActionPhase(context.Random, targetChar, alertFactor)
					};
					if (action3.CheckValid(selfChar, targetChar))
					{
						action3.ApplyChanges(context, selfChar, targetChar);
					}
					if (selfChar.GetInventory().Items.ContainsKey(itemKey))
					{
						monthlyNotifications.AddRobLegendaryBook(selfCharId, location, actionData.TargetCharId, itemKey.ItemType, itemKey.TemplateId);
					}
					return false;
				}
				}
			}
		}
		return false;
	}

	private unsafe void AddTradeForBookMonthlyEvent(Character character, Character targetChar, ItemKey bookItemKey)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int charId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = character.GetLocation();
		ResourceInts resources = character.GetResources();
		int moneyWorth = resources.Items[6] * GlobalConfig.ResourcesWorth[6];
		int authorityWorth = resources.Items[7] * GlobalConfig.ResourcesWorth[7];
		int expWorth = character.GetExp() * 5;
		if (moneyWorth >= authorityWorth && moneyWorth >= expWorth)
		{
			monthlyEventCollection.AddExchangeLegendaryBookByMoney(charId, location, targetCharId, (ulong)bookItemKey);
		}
		else if (authorityWorth >= moneyWorth && authorityWorth >= expWorth)
		{
			monthlyEventCollection.AddExchangeLegendaryBookByAuthority(charId, location, targetCharId, (ulong)bookItemKey);
		}
		else
		{
			monthlyEventCollection.AddExchangeLegendaryBookByExperience(charId, location, targetCharId, (ulong)bookItemKey);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 1;
		byte* num = pData + 2;
		*num = (byte)LegendaryBookType;
		int totalSize = (int)(num + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			LegendaryBookType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
