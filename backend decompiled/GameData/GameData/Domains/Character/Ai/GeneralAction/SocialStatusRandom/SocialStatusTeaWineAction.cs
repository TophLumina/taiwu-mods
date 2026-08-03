using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.SocialStatusRandom;

public class SocialStatusTeaWineAction : IGeneralAction
{
	public bool Succeed;

	public ItemKey SelfTeaWineItem;

	public ItemKey TargetTeaWineItem;

	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		Inventory inventory = selfChar.GetInventory();
		return inventory.Items.ContainsKey(SelfTeaWineItem) && inventory.Items.ContainsKey(TargetTeaWineItem);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = selfChar.GetId();
		Location location = targetChar.GetLocation();
		monthlyEventCollection.AddAdviseTeaWine(selfCharId, location, targetChar.GetId(), (ulong)SelfTeaWineItem, (ulong)TargetTeaWineItem);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		sbyte behaviorType = selfChar.GetBehaviorType();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		if (Succeed)
		{
			selfChar.RemoveInventoryItem(context, SelfTeaWineItem, 1, deleteItem: false);
			if (SelfTeaWineItem.Id != TargetTeaWineItem.Id)
			{
				selfChar.RemoveInventoryItem(context, TargetTeaWineItem, 1, deleteItem: false);
			}
			selfChar.AddEatingItem(context, SelfTeaWineItem);
			targetChar.AddEatingItem(context, TargetTeaWineItem);
			short favorChange = AiHelper.GeneralActionConstants.GetBegSucceedFavorabilityChange(context.Random, behaviorType);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, favorChange);
			lifeRecordCollection.AddInviteToDrinkSucceed(selfCharId, currDate, targetCharId, location, SelfTeaWineItem.ItemType, SelfTeaWineItem.TemplateId);
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestDrinking(targetCharId, selfCharId);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			short favorChange2 = AiHelper.GeneralActionConstants.GetBegFailFavorabilityChange(context.Random, behaviorType);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, favorChange2);
			lifeRecordCollection.AddInviteToDrinkFail(selfCharId, currDate, targetCharId, location, SelfTeaWineItem.ItemType, SelfTeaWineItem.TemplateId);
			int secretInfoOffset2 = secretInformationCollection.AddRefuseRequestDrinking(targetCharId, selfCharId);
			SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}
}
