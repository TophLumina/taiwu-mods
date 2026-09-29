using System;
using GameData.Common;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.HealthDemand;

public class RequestIncreaseHealthAction : IGeneralAction
{
	public ItemKey ItemUsed;

	public bool AgreeToRequest;

	public sbyte ActionEnergyType => 0;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return selfChar.GetHealth() < selfChar.GetLeftMaxHealth() && targetChar.GetInventory().Items.ContainsKey(ItemUsed) && selfChar.GetEatingItems().GetAvailableEatingSlotsCount(selfChar.GetCurrMaxEatingSlotsCount()) > 0;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = selfChar.GetId();
		Location location = targetChar.GetLocation();
		monthlyEventCollection.AddRequestHealth(selfCharId, location, targetChar.GetId(), (ulong)ItemUsed);
		CharacterDomain.AddLockMovementCharSet(selfChar.GetId());
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		if (AgreeToRequest)
		{
			if (ItemUsed.ItemType != 8)
			{
				throw new Exception($"Invalid item type {ItemUsed} to increase health for {selfChar.GetId()}");
			}
			ItemBase baseItem = DomainManager.Item.GetBaseItem(ItemUsed);
			targetChar.RemoveInventoryItem(context, ItemUsed, 1, deleteItem: false);
			selfChar.AddEatingItem(context, ItemUsed);
			selfChar.ChangeHappiness(context, baseItem.GetHappinessChange());
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, baseItem.GetFavorabilityChange() * 5);
			lifeRecordCollection.AddRequestHealthItemSucceed(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestIncreaseHealth(targetCharId, selfCharId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			selfChar.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, -6000);
			lifeRecordCollection.AddRequestHealthItemFail(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset2 = secretInformationCollection2.AddRefuseRequestIncreaseHealth(targetCharId, selfCharId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}
}
