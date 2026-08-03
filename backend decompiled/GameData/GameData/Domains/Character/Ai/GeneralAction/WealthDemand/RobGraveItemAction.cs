using System;
using GameData.Common;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.Notification;

namespace GameData.Domains.Character.Ai.GeneralAction.WealthDemand;

public class RobGraveItemAction : IGeneralAction
{
	public ItemKey TargetItem;

	public int Amount;

	public bool Succeed;

	public int TargetGraveId;

	public sbyte ActionEnergyType => 1;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		Grave grave;
		return DomainManager.Character.TryGetElement_Graves(TargetGraveId, out grave) && grave.GetInventory().Items.ContainsKey(TargetItem);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		throw new Exception("cannot be digging the current Taiwu's grave when he or she is still alive.");
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location location = selfChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (selfCharId != taiwuCharId)
		{
			selfChar.ChangeCurrMainAttribute(context, 3, -GlobalConfig.Instance.HarmfulActionCost);
		}
		if (DomainManager.Character.IsTaiwuPeople(TargetGraveId))
		{
			monthlyNotificationCollection.AddDigItem(selfCharId, location, TargetGraveId, TargetItem.ItemType, TargetItem.TemplateId);
		}
		if (Succeed)
		{
			Grave grave = DomainManager.Character.GetElement_Graves(TargetGraveId);
			grave.RemoveInventoryItem(context, TargetItem, Amount);
			selfChar.AddInventoryItem(context, TargetItem, Amount);
			lifeRecordCollection.AddRobItemFromGraveSucceed(selfCharId, currDate, TargetGraveId, location, TargetItem.ItemType, TargetItem.TemplateId);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddRobGraveItem(selfCharId, TargetGraveId, (ulong)TargetItem);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			lifeRecordCollection.AddRobItemFromGraveFail(selfCharId, currDate, TargetGraveId, location, TargetItem.ItemType, TargetItem.TemplateId);
		}
	}
}
