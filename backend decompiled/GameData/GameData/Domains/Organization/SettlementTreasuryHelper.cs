using GameData.Domains.Character;
using GameData.Domains.Item;

namespace GameData.Domains.Organization;

public static class SettlementTreasuryHelper
{
	public static int CalcItemContribution(this SettlementTreasury treasury, ItemKey itemKey, int amount)
	{
		int contribution = ItemTemplateHelper.GetContribution(itemKey.ItemType, itemKey.TemplateId);
		if (contribution > 0)
		{
			return contribution * amount;
		}
		short itemSubType = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
		int value = DomainManager.Item.GetValue(itemKey);
		return treasury.CalcAdjustedWorth(itemSubType, value) * amount * GlobalConfig.Instance.ItemContributionPercent / 100;
	}

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
