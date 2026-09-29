using GameData.ActionPlanning.ActionImpl.Helper;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class WealthDemandTakeTreasuryItemAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort TargetItem = 0;

		public const ushort Amount = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "TargetItem", "Amount" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey TargetItem;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		if (!ActionHelper.CanInteractTreasury(character))
		{
			return false;
		}
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		Settlement settlement = DomainManager.Organization.GetSettlement(orgInfo.SettlementId);
		SettlementTreasury treasury = settlement.GetTreasury(orgInfo.Grade);
		ItemKey targetItemKey = treasury.Inventory.GetItemInSameGroup(argGroup.ItemType, argGroup.ItemTemplateId, -2);
		if (!targetItemKey.IsValid())
		{
			return false;
		}
		int requiredContribution = settlement.CalcItemContribution(targetItemKey, 1);
		if (orgInfo.OrgTemplateId != 16 && treasury.GetMemberContribution(character) < requiredContribution)
		{
			return false;
		}
		TargetItem = targetItemKey;
		Amount = 1;
		return true;
	}

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (orgInfo.SettlementId < 0)
		{
			return false;
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(orgInfo.SettlementId);
		SettlementTreasury treasury = settlement.GetTreasury(orgInfo.Grade);
		if (!treasury.Inventory.Items.TryGetValue(TargetItem, out var amount) || amount < Amount)
		{
			return false;
		}
		if (orgInfo.OrgTemplateId == 16)
		{
			return true;
		}
		int memberContribution = treasury.GetMemberContribution(character);
		int worth = settlement.CalcItemContribution(TargetItem, Amount);
		return memberContribution >= worth;
	}

	public void PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		short settlementId = character.GetOrganizationInfo().SettlementId;
		DomainManager.Organization.GetSettlement(settlementId).TakeItemFromTreasury(context, character, TargetItem, Amount);
		character.AddInventoryItem(context, TargetItem, Amount);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize += TargetItem.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		int fieldSize = TargetItem.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = Amount;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += TargetItem.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			Amount = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
