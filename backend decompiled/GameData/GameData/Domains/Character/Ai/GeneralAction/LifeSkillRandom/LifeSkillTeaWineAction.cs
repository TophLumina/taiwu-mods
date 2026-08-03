using System;
using GameData.Common;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;

namespace GameData.Domains.Character.Ai.GeneralAction.LifeSkillRandom;

public class LifeSkillTeaWineAction : IGeneralAction
{
	public short TeaWineTemplateId;

	public int Amount;

	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return true;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		throw new Exception("Current action requires no targetChar.");
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		if (TeaWineTemplateId >= 0)
		{
			selfChar.CreateInventoryItem(context, 9, TeaWineTemplateId, Amount);
			lifeRecordCollection.AddCollectTeaWineSucceed(selfCharId, currDate, location, 9, TeaWineTemplateId);
		}
		else
		{
			lifeRecordCollection.AddCollectTeaWineFail(selfCharId, currDate, location);
		}
	}
}
