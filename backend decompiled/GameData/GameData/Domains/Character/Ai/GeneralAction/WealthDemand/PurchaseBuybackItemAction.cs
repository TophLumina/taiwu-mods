using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;

namespace GameData.Domains.Character.Ai.GeneralAction.WealthDemand;

public class PurchaseBuybackItemAction : IGeneralAction
{
	public ItemKey TargetItem;

	public sbyte ActionEnergyType => 1;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return true;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		if (DomainManager.Merchant.RemoveBuyBackItem(TargetItem))
		{
			selfChar.AddInventoryItem(context, TargetItem, 1);
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			int currDate = DomainManager.World.GetCurrDate();
			lifeRecordCollection.AddAcquisitionDiscard(selfChar.GetId(), currDate, TargetItem.ItemType, TargetItem.TemplateId);
		}
	}
}
