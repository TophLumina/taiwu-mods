using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;

namespace GameData.Domains.Character.Ai.GeneralAction.WealthDemand;

public class RobResourceAction : IGeneralAction
{
	public sbyte ResourceType;

	public int Amount;

	public sbyte Phase;

	public sbyte ActionEnergyType => 1;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return targetChar.GetResource(ResourceType) >= Amount;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = selfChar.GetLocation();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		if (Phase <= 2)
		{
			monthlyNotificationCollection.AddRobResourceFailure(selfCharId, location, targetCharId, ResourceType);
			ApplyChanges(context, selfChar, targetChar);
		}
		else
		{
			monthlyEventCollection.AddRobResource(selfCharId, location, targetCharId, ResourceType, Amount);
			CharacterDomain.AddLockMovementCharSet(selfCharId);
		}
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (selfCharId != taiwuCharId)
		{
			selfChar.ChangeCurrMainAttribute(context, 0, -GlobalConfig.Instance.HarmfulActionCost);
		}
		if (Phase >= 4)
		{
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddRobResource(selfCharId, targetCharId, ResourceType);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		if (selfCharId == taiwuCharId)
		{
			EventHelper.ChangeAlertnessOnRobResource(targetCharId, ResourceType, Amount);
		}
		switch (Phase)
		{
		case 0:
			lifeRecordCollection.AddRobResourceFail1(selfCharId, currDate, targetCharId, location, ResourceType);
			break;
		case 1:
			lifeRecordCollection.AddRobResourceFail2(selfCharId, currDate, targetCharId, location, ResourceType);
			break;
		case 2:
			lifeRecordCollection.AddRobResourceFail3(selfCharId, currDate, targetCharId, location, ResourceType);
			break;
		case 3:
			lifeRecordCollection.AddRobResourceFail4(selfCharId, currDate, targetCharId, location, ResourceType);
			break;
		case 4:
			lifeRecordCollection.AddRobResourceSucceed(selfCharId, currDate, targetCharId, location, ResourceType, Amount);
			if (targetCharId != DomainManager.Taiwu.GetTaiwuCharId())
			{
				AiHelper.NpcCombatResultType combatResultType = DomainManager.Character.SimulateCharacterCombat(context, targetChar, selfChar, CombatType.Beat);
				if ((uint)(combatResultType - 2) <= 1u)
				{
					selfChar.ChangeResource(context, ResourceType, Amount);
					targetChar.ChangeResource(context, ResourceType, -Amount);
					int happinessChange2 = -AiHelper.GeneralActionConstants.GetResourceHappinessChange(ResourceType, Amount);
					targetChar.ChangeHappiness(context, happinessChange2);
					DomainManager.Character.SimulateCharacterCombatResult(context, selfChar, targetChar, -40, -20, 0);
				}
				else
				{
					lifeRecordCollection.AddRobResourceFailAndBeatenUp(selfCharId, currDate, targetCharId, location, ResourceType, Amount);
					DomainManager.Character.SimulateCharacterCombatResult(context, targetChar, selfChar, -40, -20, 0);
				}
			}
			break;
		default:
		{
			selfChar.ChangeResource(context, ResourceType, Amount);
			targetChar.ChangeResource(context, ResourceType, -Amount);
			int happinessChange = -AiHelper.GeneralActionConstants.GetResourceHappinessChange(ResourceType, Amount);
			targetChar.ChangeHappiness(context, happinessChange);
			lifeRecordCollection.AddRobResourceSucceedAndEscaped(selfCharId, currDate, targetCharId, location, ResourceType, Amount);
			break;
		}
		}
	}
}
