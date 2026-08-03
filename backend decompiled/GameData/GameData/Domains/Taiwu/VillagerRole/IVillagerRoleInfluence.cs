using GameData.Common;
using GameData.Domains.Map;
using GameData.Domains.Organization;

namespace GameData.Domains.Taiwu.VillagerRole;

public interface IVillagerRoleInfluence
{
	int InfluenceSettlementValueChange { get; }

	void ApplyInfluenceAction(DataContext context);

	int GetSettlementInfluenceAuthorityGain(Settlement settlement);

	int GetAreaInfluenceAuthorityGain(short areaId)
	{
		if (areaId < 0)
		{
			return 0;
		}
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(areaId);
		SettlementInfo[] settlementInfos = areaData.SettlementInfos;
		if (settlementInfos == null || settlementInfos.Length <= 0)
		{
			return 0;
		}
		int authorityGain = 0;
		for (int i = 0; i < areaData.SettlementInfos.Length; i++)
		{
			SettlementInfo settlementInfo = areaData.SettlementInfos[i];
			if (settlementInfo.SettlementId >= 0)
			{
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementInfo.SettlementId);
				authorityGain += GetSettlementInfluenceAuthorityGain(settlement);
			}
		}
		return authorityGain;
	}
}
