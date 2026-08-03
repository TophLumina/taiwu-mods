using System;
using GameData.Common;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class ExchangeResourceAction : IGeneralAction
{
	public sbyte SpentResourceType;

	public int SpentResourceAmount;

	public sbyte GainResourceType;

	public int GainResourceAmount;

	public sbyte ActionEnergyType => 3;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return selfChar.IsInRegularSettlementRange() && selfChar.GetResource(SpentResourceType) >= SpentResourceAmount;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		throw new Exception("Current action requires no targetChar.");
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		selfChar.ChangeResource(context, SpentResourceType, -SpentResourceAmount);
		selfChar.ChangeResource(context, GainResourceType, GainResourceAmount);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetValidLocation();
		Location settlementLocation = DomainManager.Map.GetBelongSettlementBlock(location).GetLocation();
		lifeRecordCollection.AddExchangeResource(selfChar.GetId(), currDate, -1, settlementLocation, SpentResourceType, SpentResourceAmount, GainResourceType, GainResourceAmount);
	}
}
