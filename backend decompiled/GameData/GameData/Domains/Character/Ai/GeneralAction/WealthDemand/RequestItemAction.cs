using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Taiwu;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.WealthDemand;

public class RequestItemAction : IGeneralAction
{
	public ItemKey TargetItem;

	public int Amount;

	public bool AgreeToRequest;

	public ItemKey[] PoisonsToAdd;

	public sbyte ActionEnergyType => 1;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return targetChar.GetInventory().Items.ContainsKey(TargetItem);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = targetChar.GetLocation();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		monthlyEventCollection.AddRequestItem(selfCharId, location, targetCharId, (ulong)TargetItem, Amount);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location location = selfChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		if (AgreeToRequest)
		{
			if (PoisonsToAdd != null)
			{
				(TargetItem, _) = targetChar.AttachPoisonsToInventoryItem(context, TargetItem, PoisonsToAdd);
			}
			DomainManager.Character.TransferInventoryItem(context, targetChar, selfChar, TargetItem, Amount, EItemAutoOperationSource.Other, ignoreLocked: true);
			ItemBase itemBase = DomainManager.Item.GetBaseItem(TargetItem);
			int favorabilityChange = itemBase.GetFavorabilityChange() * 2;
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, favorabilityChange);
			selfChar.ChangeHappiness(context, itemBase.GetHappinessChange());
			lifeRecordCollection.AddRequestItemSucceed(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestItem(targetCharId, selfCharId, (ulong)TargetItem);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, -3000);
			selfChar.ChangeHappiness(context, -3);
			lifeRecordCollection.AddRequestItemFail(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset2 = secretInformationCollection2.AddRefuseRequestItem(targetCharId, selfCharId, (ulong)TargetItem);
			SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}
}
