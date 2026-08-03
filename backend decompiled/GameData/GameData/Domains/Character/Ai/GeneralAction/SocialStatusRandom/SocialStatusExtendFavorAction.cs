using System;
using GameData.Common;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.SocialStatusRandom;

public class SocialStatusExtendFavorAction : IGeneralAction
{
	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return true;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = selfChar.GetId();
		Location location = targetChar.GetLocation();
		monthlyEventCollection.AddAdviseExtendFavours(selfCharId, location, targetChar.GetId());
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		throw new Exception($"targetChar {targetChar.GetId()} has to be Taiwu {DomainManager.Taiwu.GetTaiwuCharId()}.");
	}
}
