using System;
using Config;
using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.HealthDemand;

public class RequestHealInjuryAction : IGeneralAction
{
	public ItemKey ItemUsed;

	public bool IsInnerInjury;

	public bool AgreeToRequest;

	public sbyte ActionEnergyType => 0;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		if (!selfChar.GetInjuries().HasAnyInjury(IsInnerInjury))
		{
			return false;
		}
		if (!targetChar.GetInventory().Items.ContainsKey(ItemUsed))
		{
			return false;
		}
		MedicineItem medicineCfg = Config.Medicine.Instance[ItemUsed.TemplateId];
		if (medicineCfg.Duration == 0)
		{
			return medicineCfg.RequiredMainAttributeType < 0 || selfChar.GetCurrMainAttribute(medicineCfg.RequiredMainAttributeType) >= medicineCfg.RequiredMainAttributeValue;
		}
		return selfChar.GetEatingItems().GetAvailableEatingSlotsCount(selfChar.GetCurrMaxEatingSlotsCount()) > 0;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = targetChar.GetLocation();
		if (IsInnerInjury)
		{
			monthlyEventCollection.AddRequestHealInnerInjuryByItem(selfCharId, location, targetCharId, (ulong)ItemUsed, -1);
		}
		else
		{
			monthlyEventCollection.AddRequestHealOuterInjuryByItem(selfCharId, location, targetCharId, (ulong)ItemUsed, -1);
		}
		CharacterDomain.AddLockMovementCharSet(selfChar.GetId());
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		if (AgreeToRequest)
		{
			if (ItemUsed.ItemType != 8)
			{
				throw new Exception($"Invalid item type {ItemUsed} to heal injury for {selfChar.GetId()}");
			}
			ItemBase baseItem = DomainManager.Item.GetBaseItem(ItemUsed);
			targetChar.RemoveInventoryItem(context, ItemUsed, 1, deleteItem: false);
			MedicineItem medicineCfg = Config.Medicine.Instance[ItemUsed.TemplateId];
			if (medicineCfg.Duration == 0)
			{
				selfChar.ApplyTopicalMedicine(context, ItemUsed);
				DomainManager.Item.RemoveItem(context, ItemUsed);
			}
			else
			{
				selfChar.AddEatingItem(context, ItemUsed);
			}
			selfChar.ChangeHappiness(context, baseItem.GetHappinessChange());
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, baseItem.GetFavorabilityChange() * 5);
			if (IsInnerInjury)
			{
				lifeRecordCollection.AddRequestHealInnerInjurySucceed(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			}
			else
			{
				lifeRecordCollection.AddRequestHealOuterInjurySucceed(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			}
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestHealInjury(targetCharId, selfCharId);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			selfChar.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, -6000);
			if (IsInnerInjury)
			{
				lifeRecordCollection.AddRequestHealInnerInjuryFail(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			}
			else
			{
				lifeRecordCollection.AddRequestHealOuterInjuryFail(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			}
			int secretInfoOffset2 = secretInformationCollection.AddRefuseRequestHealInjury(targetCharId, selfCharId);
			SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}
}
