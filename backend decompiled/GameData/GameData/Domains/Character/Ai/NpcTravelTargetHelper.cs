using GameData.Domains.Map;

namespace GameData.Domains.Character.Ai;

public static class NpcTravelTargetHelper
{
	public static Location GetRealTargetLocation(this NpcTravelTarget target)
	{
		if (target.TryGetFixedLocation(out var fixedLocation))
		{
			return fixedLocation;
		}
		if (DomainManager.Character.TryGetElement_Objects(target.TargetCharId, out var targetChar))
		{
			Location location = targetChar.GetLocation();
			if (location.IsValid())
			{
				return location;
			}
			int targetLeaderId = targetChar.GetLeaderId();
			if (DomainManager.Character.TryGetElement_CrossAreaMoveInfos((targetLeaderId >= 0) ? targetLeaderId : target.TargetCharId, out var moveInfo))
			{
				MapAreaData targetAreaData = DomainManager.Map.GetElement_Areas(moveInfo.ToAreaId);
				location = new Location(moveInfo.ToAreaId, targetAreaData.StationBlockId);
			}
			else
			{
				location = targetChar.GetValidLocation();
			}
			return location;
		}
		if (DomainManager.Character.TryGetElement_Graves(target.TargetCharId, out var targetGrave))
		{
			return targetGrave.GetLocation();
		}
		return Location.Invalid;
	}

	public static bool IsTargetInteractable(this NpcTravelTarget target)
	{
		if (target.TryGetFixedLocation(out var _))
		{
			return true;
		}
		if (!DomainManager.Character.TryGetElement_Objects(target.TargetCharId, out var character))
		{
			return true;
		}
		if (character.IsActiveExternalRelationState(188uL))
		{
			return false;
		}
		if (DomainManager.Taiwu.IsInGroup(target.TargetCharId) && TaiwuInSpecialState())
		{
			return false;
		}
		return !character.IsCrossAreaTraveling();
	}

	private static bool TaiwuInSpecialState()
	{
		return DomainManager.Map.IsTraveling || DomainManager.Adventure.GetAdventureTaiwu().InAdventure;
	}
}
