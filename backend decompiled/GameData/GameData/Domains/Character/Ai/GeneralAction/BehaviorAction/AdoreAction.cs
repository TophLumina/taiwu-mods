using GameData.Common;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class AdoreAction : IGeneralAction
{
	public sbyte ActionEnergyType => 3;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		if (DomainManager.Character.HasRelation(selfChar.GetId(), targetChar.GetId(), 16384))
		{
			return false;
		}
		if (DomainManager.Character.HasRelation(selfChar.GetId(), targetChar.GetId(), 1024))
		{
			return false;
		}
		return true;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		ApplyChanges(context, selfChar, targetChar);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		DomainManager.Character.AddRelation(context, selfCharId, targetCharId, 16384, currDate);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		lifeRecordCollection.AddAdore(selfCharId, currDate, targetCharId, location);
	}
}
