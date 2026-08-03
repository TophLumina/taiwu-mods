using GameData.Domains.Character;

namespace GameData.Domains.Organization;

public static class SettlementTreasuryHelper
{
	public static int GetMemberContribution(this SettlementTreasury settlementTreasury, GameData.Domains.Character.Character character)
	{
		int charId = character.GetId();
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		return settlementTreasury.GetMemberContribution(charId, orgInfo);
	}

	public static void OfflineChangeContribution(this SettlementTreasury settlementTreasury, GameData.Domains.Character.Character character, int delta)
	{
		int charId = character.GetId();
		int presetContribution = character.GetContributionPerMonth();
		settlementTreasury.OfflineChangeContribution(charId, presetContribution, delta);
	}
}
