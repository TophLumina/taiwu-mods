using GameData.ActionPlanning.ActionImpl.Helper;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class WealthDemandTakeTreasuryResourceAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ResourceType = 0;

		public const ushort Amount = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "ResourceType", "Amount" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte ResourceType;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		if (!ActionHelper.CanInteractTreasury(character))
		{
			return false;
		}
		if (!context.Random.CheckPercentProb(AiHelper.GeneralActionConstants.TakeFromTreasuryChance[character.GetBehaviorType()]))
		{
			return false;
		}
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		Settlement settlement = DomainManager.Organization.GetSettlement(orgInfo.SettlementId);
		sbyte resourceType = argGroup.ResourceType;
		int amount = argGroup.Amount;
		SettlementTreasury treasury = settlement.GetTreasury(orgInfo.Grade);
		if (treasury.Resources[resourceType] < amount)
		{
			return false;
		}
		int requiredContribution = DomainManager.Organization.CalcResourceContribution(orgInfo.OrgTemplateId, resourceType, amount);
		if (treasury.GetMemberContribution(character) < requiredContribution)
		{
			return false;
		}
		ResourceType = resourceType;
		Amount = amount;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (orgInfo.SettlementId < 0)
		{
			return false;
		}
		SettlementTreasury treasury = DomainManager.Organization.GetSettlement(orgInfo.SettlementId).GetTreasury(orgInfo.Grade);
		int worth = DomainManager.Organization.CalcResourceContribution(orgInfo.OrgTemplateId, ResourceType, Amount);
		if (treasury.Resources[ResourceType] >= Amount)
		{
			return treasury.GetMemberContribution(character) >= worth;
		}
		return false;
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		short settlementId = character.GetOrganizationInfo().SettlementId;
		DomainManager.Organization.TakeResourceFromTreasury(context, settlementId, character, ResourceType, Amount, -1);
		character.ChangeResource(context, ResourceType, Amount);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 2;
		byte* num = pData + 2;
		*num = (byte)ResourceType;
		byte* num2 = num + 1;
		*(int*)num2 = Amount;
		int totalSize = (int)(num2 + 4 - pData);
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
			ResourceType = (sbyte)(*pCurrData);
			pCurrData++;
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
