using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.WealthDemand;

public class RequestRepairItemAction : IGeneralAction
{
	public ItemKey TargetItem;

	public bool AgreeToRequest;

	public ItemKey ToolUsed;

	public sbyte ResourceType;

	public int ResourceAmount;

	public short ToolDurabilityCost;

	public sbyte ActionEnergyType => 1;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return selfChar.GetInventory().Items.ContainsKey(TargetItem) && targetChar.GetInventory().Items.ContainsKey(ToolUsed) && targetChar.GetResource(ResourceType) >= ResourceAmount;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = selfChar.GetLocation();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		monthlyEventCollection.AddRequestRepairItem(selfCharId, location, targetCharId, (ulong)TargetItem, (ulong)ToolUsed, ResourceAmount, ResourceType);
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
			CraftTool craftTool = DomainManager.Item.GetElement_CraftTools(ToolUsed.Id);
			ItemBase itemToRepair = DomainManager.Item.GetBaseItem(TargetItem);
			ItemBase.OfflineRepairItem(craftTool, itemToRepair, itemToRepair.GetMaxDurability(), ToolDurabilityCost);
			itemToRepair.SetCurrDurability(itemToRepair.GetCurrDurability(), context);
			craftTool.SetCurrDurability(craftTool.GetCurrDurability(), context);
			targetChar.ChangeResource(context, ResourceType, -ResourceAmount);
			int favorabilityChange = itemToRepair.GetFavorabilityChange();
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, favorabilityChange);
			selfChar.ChangeHappiness(context, DomainManager.Item.GetBaseItem(TargetItem).GetHappinessChange());
			lifeRecordCollection.AddRequestRepairItemSucceed(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestRepairItem(targetCharId, selfCharId, (ulong)TargetItem);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, -3000);
			selfChar.ChangeHappiness(context, -3);
			lifeRecordCollection.AddRequestRepairItemFail(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset2 = secretInformationCollection2.AddRefuseRequestRepairItem(targetCharId, selfCharId, (ulong)TargetItem);
			SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}
}
