using GameData.Domains.Map;
using GameData.Domains.Taiwu.VillagerRole;

namespace GameData.Domains.Taiwu;

public static class VillagerWorkDataHelper
{
	public static VillagerRoleBase GetVillagerRole(this VillagerWorkData workData)
	{
		return DomainManager.Extra.GetVillagerRole(workData.CharacterId);
	}

	public static int GetCollectResourceIncome(this VillagerWorkData workData)
	{
		Location blockKey = workData.Location;
		MapBlockData block = DomainManager.Map.GetBlock(blockKey);
		if (workData.GetVillagerRole() is VillagerRoleFarmer farmer)
		{
			return farmer.GetCollectResourceAmount(block, workData.ResourceType);
		}
		return block.GetCollectResourceAmount(workData.ResourceType);
	}
}
