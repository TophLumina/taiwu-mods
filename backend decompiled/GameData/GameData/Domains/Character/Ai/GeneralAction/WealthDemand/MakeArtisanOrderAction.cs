using GameData.Common;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Utilities;

namespace GameData.Domains.Character.Ai.GeneralAction.WealthDemand;

public class MakeArtisanOrderAction : IGeneralAction
{
	public sbyte LifeSkillType;

	public short ItemSubType;

	public int GiftTargetCharId = -1;

	public sbyte ActionEnergyType => 1;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return OrganizationDomain.GetOrgMemberConfig(targetChar.GetOrganizationInfo()).CraftTypes.Exist(LifeSkillType) && DomainManager.Extra.IsArtisanIdle(targetChar.GetId());
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int currDate = DomainManager.World.GetCurrDate();
		Location location = targetChar.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (GiftTargetCharId >= 0 && DomainManager.Character.TryGetElement_Objects(GiftTargetCharId, out var giftTargetChar))
		{
			DomainManager.Extra.CreateArtisanOrderWithoutCost(context, targetChar, giftTargetChar, LifeSkillType, ItemSubType);
			lifeRecordCollection.AddOrderProductForOthers(selfChar.GetId(), currDate, targetChar.GetId(), GiftTargetCharId, location);
		}
		else
		{
			DomainManager.Extra.CreateArtisanOrderWithoutCost(context, targetChar, selfChar, LifeSkillType, ItemSubType);
			lifeRecordCollection.AddOrderProduct(selfChar.GetId(), currDate, targetChar.GetId(), location);
		}
	}
}
