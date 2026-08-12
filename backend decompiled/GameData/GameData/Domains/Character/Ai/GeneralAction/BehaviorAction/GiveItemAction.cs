using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Taiwu;
using GameData.Domains.World.Notification;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class GiveItemAction : IGeneralAction
{
	public ItemKey TargetItem;

	public int Amount;

	public bool RefusePoisonousItem;

	public sbyte ActionEnergyType => 3;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		int amount;
		return selfChar.GetInventory().Items.TryGetValue(TargetItem, out amount) && amount >= Amount;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = selfChar.GetLocation();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		monthlyNotifications.AddGivePresentItem(selfCharId, location, TargetItem.ItemType, TargetItem.TemplateId, targetCharId);
		ApplyChanges(context, selfChar, targetChar);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (RefusePoisonousItem)
		{
			lifeRecordCollection.AddRefusePoisonousGift(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			return;
		}
		lifeRecordCollection.AddGiveItem(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
		DomainManager.Character.TransferInventoryItem(context, selfChar, targetChar, TargetItem, Amount, EItemAutoOperationSource.Other, ignoreLocked: true);
		ItemBase baseItem = DomainManager.Item.GetBaseItem(TargetItem);
		int favorChange = baseItem.GetFavorabilityChange();
		DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, selfChar, favorChange);
		targetChar.ChangeHappiness(context, baseItem.GetHappinessChange());
	}
}
