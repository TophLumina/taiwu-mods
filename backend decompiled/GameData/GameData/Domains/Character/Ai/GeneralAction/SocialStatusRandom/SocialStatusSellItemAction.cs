using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.SocialStatusRandom;

public class SocialStatusSellItemAction : IGeneralAction
{
	public bool Succeed;

	public ItemKey ItemKey;

	public int Amount;

	public int Price;

	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return DomainManager.Merchant.MerchantHasTargetItem(selfChar.GetId(), ItemKey, Amount) && targetChar.GetResource(6) >= Price;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = targetChar.GetLocation();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		monthlyEventCollection.AddAdviseSales(selfCharId, location, targetCharId, (ulong)ItemKey, Price, Amount);
		CharacterDomain.AddLockMovementCharSet(selfChar.GetId());
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		sbyte behaviorType = selfChar.GetBehaviorType();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (Succeed)
		{
			selfChar.ChangeResource(context, 6, Price);
			targetChar.ChangeResource(context, 6, -Price);
			DomainManager.Merchant.RemoveExistingMerchantItem(context, selfCharId, ItemKey, Amount);
			targetChar.AddInventoryItem(context, ItemKey, Amount);
			short favorChange = AiHelper.GeneralActionConstants.GetBegSucceedFavorabilityChange(context.Random, behaviorType);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, favorChange);
			lifeRecordCollection.AddSellSucceed(selfCharId, currDate, targetCharId, location, ItemKey.ItemType, ItemKey.TemplateId);
		}
		else
		{
			short favorChange2 = AiHelper.GeneralActionConstants.GetBegFailFavorabilityChange(context.Random, behaviorType);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, favorChange2);
			lifeRecordCollection.AddSellFail(selfCharId, currDate, targetCharId, location, ItemKey.ItemType, ItemKey.TemplateId);
		}
	}
}
