using GameData.Common;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.Notification;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class GiveResourceAction : IGeneralAction
{
	public sbyte ResourceType;

	public int Amount;

	public sbyte ActionEnergyType => 3;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return selfChar.GetResource(ResourceType) >= Amount;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = selfChar.GetLocation();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		monthlyNotifications.AddGivePresentResource(selfCharId, location, ResourceType, targetCharId);
		ApplyChanges(context, selfChar, targetChar);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		selfChar.ChangeResource(context, ResourceType, -Amount);
		targetChar.ChangeResource(context, ResourceType, Amount);
		short favorChange = AiHelper.GeneralActionConstants.GetResourceFavorabilityChange(ResourceType, Amount);
		sbyte happinessChange = AiHelper.GeneralActionConstants.GetResourceHappinessChange(ResourceType, Amount);
		DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, selfChar, favorChange);
		targetChar.ChangeHappiness(context, happinessChange);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		lifeRecordCollection.AddGiveResource(selfCharId, currDate, targetCharId, location, ResourceType, Amount);
	}
}
