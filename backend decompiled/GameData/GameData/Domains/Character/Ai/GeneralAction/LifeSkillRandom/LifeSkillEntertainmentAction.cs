using System;
using GameData.Common;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.Notification;

namespace GameData.Domains.Character.Ai.GeneralAction.LifeSkillRandom;

public class LifeSkillEntertainmentAction : IGeneralAction
{
	public sbyte LifeSkillType;

	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return true;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int targetCharId = targetChar.GetId();
		int selfCharId = selfChar.GetId();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		Location location = selfChar.GetLocation();
		switch (LifeSkillType)
		{
		case 0:
			monthlyNotifications.AddAmuseOthersByMusic(targetCharId, location, selfCharId);
			break;
		case 1:
			monthlyNotifications.AddAmuseOthersByChess(targetCharId, location, selfCharId);
			break;
		case 2:
			monthlyNotifications.AddAmuseOthersByPoem(targetCharId, location, selfCharId);
			break;
		case 3:
			monthlyNotifications.AddAmuseOthersByPainting(targetCharId, location, selfCharId);
			break;
		default:
			throw new Exception($"Invalid life skill type for entertainment {LifeSkillType}");
		}
		ApplyChanges(context, selfChar, targetChar);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		int targetCharId = targetChar.GetId();
		int selfCharId = selfChar.GetId();
		short selfAttainment = Math.Max((short)1, selfChar.GetLifeSkillAttainment(LifeSkillType));
		short targetAttainment = Math.Max((short)1, targetChar.GetLifeSkillAttainment(LifeSkillType));
		int selfHappinessChange = Math.Clamp(targetAttainment * 5 / selfAttainment - 5, -5, 10);
		int targetHappinessChange = Math.Clamp(selfAttainment * 5 / targetAttainment - 5, -5, 10);
		selfChar.ChangeHappiness(context, selfHappinessChange);
		targetChar.ChangeHappiness(context, targetHappinessChange);
		int selfFavorabilityChange = Math.Clamp(targetAttainment * 1500 / selfAttainment - 1500, -1500, 3000);
		int targetFavorabilityChange = Math.Clamp(selfAttainment * 1500 / targetAttainment - 1500, -1500, 3000);
		DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, selfFavorabilityChange);
		DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, selfChar, targetFavorabilityChange);
		switch (LifeSkillType)
		{
		case 0:
			lifeRecordCollection.AddEntertainWithMusic(selfCharId, currDate, targetCharId, location);
			break;
		case 1:
			lifeRecordCollection.AddEntertainWithChess(selfCharId, currDate, targetCharId, location);
			break;
		case 2:
			lifeRecordCollection.AddEntertainWithPoem(selfCharId, currDate, targetCharId, location);
			break;
		case 3:
			lifeRecordCollection.AddEntertainWithPainting(selfCharId, currDate, targetCharId, location);
			break;
		default:
			throw new Exception($"Invalid life skill type for entertainment {LifeSkillType}");
		}
	}
}
