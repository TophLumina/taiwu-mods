using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.SocialStatusRandom;

public class SocialStatusRepairAction : IGeneralAction
{
	public sbyte ResourceType;

	public int Amount;

	public ItemKey ToolUsed;

	public ItemKey RepairedItem;

	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return selfChar.GetResource(ResourceType) >= Amount && selfChar.GetInventory().Items.ContainsKey(ToolUsed) && DomainManager.Item.GetBaseItem(ToolUsed).GetCurrDurability() > 0 && targetChar.GetInventory().Items.ContainsKey(RepairedItem);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = selfChar.GetId();
		Location location = targetChar.GetLocation();
		monthlyEventCollection.AddAdviseRepairItem(selfCharId, location, targetChar.GetId(), (ulong)RepairedItem, (ulong)ToolUsed, ResourceType, Amount);
		CharacterDomain.AddLockMovementCharSet(selfChar.GetId());
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		selfChar.ChangeResource(context, ResourceType, Amount);
		ItemBase item = DomainManager.Item.GetBaseItem(RepairedItem);
		item.SetCurrDurability(item.GetMaxDurability(), context);
		DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, selfChar, 3000);
		lifeRecordCollection.AddRepairItemSucceed(selfCharId, currDate, targetCharId, location);
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		int secretInfoOffset = secretInformationCollection.AddRepairItem(selfCharId, targetCharId, (ulong)RepairedItem);
		SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
	}
}
