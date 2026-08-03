using System.Linq;
using Config;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Taiwu;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Utilities;

namespace GameData.Domains.Character.Ai.GeneralAction.WealthDemand;

public class StealItemAction : IGeneralAction
{
	public ItemKey TargetItem;

	public int Amount;

	public sbyte Phase;

	public ItemKey[] PoisonsToAdd;

	public sbyte ActionEnergyType => 1;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		if (TargetItem.ItemType == 12 && TargetItem.TemplateId == 475)
		{
			KidnappedCharacterList kidnappedCharacterList = DomainManager.Character.GetKidnappedCharacters(targetChar.GetId());
			return kidnappedCharacterList.GetCollection().Count((KidnappedCharacter k) => k.CharId == TargetItem.Id) > 0;
		}
		return targetChar.GetInventory().Items.ContainsKey(TargetItem) || targetChar.GetEquipment().Contains(TargetItem);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = selfChar.GetLocation();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		if (Phase <= 3)
		{
			monthlyNotificationCollection.AddStealItemFailure(selfCharId, location, targetCharId, TargetItem.ItemType, TargetItem.TemplateId);
			ApplyChanges(context, selfChar, targetChar);
			return;
		}
		monthlyNotificationCollection.AddStealItemSuccess(selfCharId, location, targetCharId, TargetItem.ItemType, TargetItem.TemplateId);
		if (Phase == 4)
		{
			if (ItemTemplateHelper.GetItemSubType(TargetItem.ItemType, TargetItem.TemplateId) == 1202)
			{
				monthlyEventCollection.AddStealLegendaryBookGotCaught(selfCharId, location, targetCharId, (ulong)TargetItem, Phase);
			}
			else
			{
				monthlyEventCollection.AddStealItemButBeCaught(selfCharId, location, targetCharId, (ulong)TargetItem);
			}
		}
		else
		{
			ApplyChanges(context, selfChar, targetChar);
		}
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (selfCharId != taiwuCharId)
		{
			selfChar.ChangeCurrMainAttribute(context, 1, -GlobalConfig.Instance.HarmfulActionCost);
		}
		if (Phase >= 4)
		{
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddStealItem(selfCharId, targetCharId, (ulong)TargetItem);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		sbyte phase = Phase;
		if (phase > 0 && phase < 5 && selfCharId == taiwuCharId)
		{
			EventHelper.ChangeAlertnessOnStealItem(targetCharId, TargetItem);
		}
		switch (Phase)
		{
		case 0:
			lifeRecordCollection.AddStealItemFail1(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			return;
		case 1:
			lifeRecordCollection.AddStealItemFail2(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			return;
		case 2:
			lifeRecordCollection.AddStealItemFail3(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			return;
		case 3:
			lifeRecordCollection.AddStealItemFail4(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			return;
		case 4:
		{
			lifeRecordCollection.AddStealItemSucceed(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			if (targetCharId == taiwuCharId)
			{
				return;
			}
			AiHelper.NpcCombatResultType combatResultType = DomainManager.Character.SimulateCharacterCombat(context, targetChar, selfChar, CombatType.Beat);
			if ((uint)(combatResultType - 2) <= 1u)
			{
				int slotIndex = targetChar.GetEquipment().IndexOf(TargetItem);
				if (slotIndex >= 0)
				{
					targetChar.ChangeEquipment(context, (sbyte)slotIndex, -1, ItemKey.Invalid);
				}
				if (TargetItem.ItemType == 12 && TargetItem.TemplateId == 475)
				{
					KidnappedCharacterList kidnappedCharacterList = DomainManager.Character.GetKidnappedCharacters(targetCharId);
					KidnappedCharacter kidnappedCharacter = kidnappedCharacterList.GetCollection().Find((KidnappedCharacter k) => k.CharId == TargetItem.Id);
					DomainManager.Character.TransferKidnappedCharacter(context, selfCharId, targetCharId, kidnappedCharacter);
					targetChar.ChangeHappiness(context, Config.Misc.Instance[(short)475].BaseHappinessChange);
				}
				else
				{
					DomainManager.Character.TransferInventoryItem(context, targetChar, selfChar, TargetItem, Amount, EItemAutoOperationSource.Other, ignoreLocked: true);
					targetChar.ChangeHappiness(context, DomainManager.Item.GetBaseItem(TargetItem).GetHappinessChange());
				}
				DomainManager.Character.SimulateCharacterCombatResult(context, selfChar, targetChar, -40, -20, 0);
			}
			else
			{
				lifeRecordCollection.AddStealItemSucceedAndBeatenUp(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
				DomainManager.Character.SimulateCharacterCombatResult(context, targetChar, selfChar, -40, -20, 0);
			}
			return;
		}
		}
		if (PoisonsToAdd != null)
		{
			(TargetItem, _) = targetChar.AttachPoisonsToInventoryItem(context, TargetItem, PoisonsToAdd);
		}
		if (TargetItem.ItemType == 12 && TargetItem.TemplateId == 475)
		{
			KidnappedCharacterList kidnappedCharacterList2 = DomainManager.Character.GetKidnappedCharacters(targetCharId);
			KidnappedCharacter kidnappedCharacter2 = kidnappedCharacterList2.GetCollection().Find((KidnappedCharacter k) => k.CharId == TargetItem.Id);
			DomainManager.Character.TransferKidnappedCharacter(context, selfCharId, targetCharId, kidnappedCharacter2);
			targetChar.ChangeHappiness(context, Config.Misc.Instance[(short)475].BaseHappinessChange);
		}
		else
		{
			DomainManager.Character.TransferInventoryItem(context, targetChar, selfChar, TargetItem, Amount, EItemAutoOperationSource.Other, ignoreLocked: true);
			targetChar.ChangeHappiness(context, DomainManager.Item.GetBaseItem(TargetItem).GetHappinessChange());
		}
		lifeRecordCollection.AddStealItemSucceedAndEscaped(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
	}
}
