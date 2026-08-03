using System.Linq;
using Config;
using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Utilities;

namespace GameData.Domains.Character.Ai.GeneralAction.WealthDemand;

public class RequestAddPoisonToItemAction : IGeneralAction
{
	public ItemKey TargetItem;

	public bool AgreeToRequest;

	public ItemKey PoisonUsed;

	public sbyte ActionEnergyType => 1;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return selfChar.GetEquipment().Contains(TargetItem) && targetChar.GetInventory().Items.ContainsKey(PoisonUsed);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = targetChar.GetLocation();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		monthlyEventCollection.AddRequestAddPoisonToItem(selfCharId, location, targetCharId, (ulong)TargetItem, (ulong)PoisonUsed);
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
			ItemBase itemToAddPoisonOn = DomainManager.Item.GetBaseItem(TargetItem);
			MedicineItem poisonConfig = Config.Medicine.Instance[PoisonUsed.TemplateId];
			Tester.Assert(poisonConfig.EffectType == EMedicineEffectType.ApplyPoison);
			var (newItemObj, keyChanged) = DomainManager.Item.SetAttachedPoisons(context, itemToAddPoisonOn, PoisonUsed.TemplateId, add: true);
			targetChar.RemoveInventoryItem(context, PoisonUsed, 1, deleteItem: true);
			if (keyChanged)
			{
				ItemKey[] equipment = selfChar.GetEquipment();
				for (int i = 0; i < equipment.Length; i++)
				{
					if (equipment[i].Equals(TargetItem))
					{
						equipment[i] = newItemObj.GetItemKey();
						selfChar.SetEquipment(equipment, context);
						break;
					}
				}
			}
			int favorabilityChange = itemToAddPoisonOn.GetFavorabilityChange() * 5;
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, favorabilityChange);
			selfChar.ChangeHappiness(context, DomainManager.Item.GetBaseItem(TargetItem).GetHappinessChange());
			lifeRecordCollection.AddRequestAddPoisonToItemSucceed(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestAddPoisonToItem(targetCharId, selfCharId, (ulong)TargetItem, (ulong)PoisonUsed);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, -3000);
			selfChar.ChangeHappiness(context, -3);
			lifeRecordCollection.AddRequestAddPoisonToItemFail(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset2 = secretInformationCollection2.AddRefuseRequestAddPoisonToItem(targetCharId, selfCharId, (ulong)TargetItem, (ulong)PoisonUsed);
			SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}
}
