using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SeekAsylumAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort SettlementId = 0;

		public const ushort CurrChance = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "SettlementId", "CurrChance" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short SettlementId;

	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte CurrChance = 5;

	private const int BonusChancePerMonth = 5;

	public bool OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(argGroup.OrgTemplateId);
		SettlementId = settlement.GetId();
		actionData.TargetLocation = settlement.GetLocation();
		return true;
	}

	public bool CheckValid(GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		if (selfChar.GetOrganizationInfo().OrgTemplateId != 0)
		{
			return false;
		}
		if (DomainManager.Organization.GetFugitiveBountySect(selfChar.GetId()) < 0)
		{
			return false;
		}
		return true;
	}

	public void OnStart(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup())
		{
			if (selfChar.GetLeaderId() >= 0)
			{
				DomainManager.Character.LeaveGroup(context, selfChar);
			}
			string targetName = DomainManager.Organization.GetSettlement(SettlementId).GetNameRelatedData().GetName();
			AdaptableLog.Info($"{selfChar} 开始前往 {targetName} 寻求庇护.");
			int selfCharId = selfChar.GetId();
			sbyte sectOrgTemplateId = DomainManager.Organization.GetFugitiveBountySect(selfCharId);
			Sect sect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(sectOrgTemplateId);
			SettlementBounty bounty = sect.Prison.GetBounty(selfCharId);
			Location location = selfChar.GetLocation();
			int currDate = DomainManager.World.GetCurrDate();
			DomainManager.LifeRecord.GetLifeRecordCollection().AddDecideToSeekAsylum(selfCharId, currDate, location, bounty.PunishmentType, sect.GetId(), SettlementId);
		}
	}

	public void OnInterrupt(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		AdaptableLog.Info($"{selfChar} 终止寻求庇护.");
		int selfCharId = selfChar.GetId();
		Location location = selfChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		DomainManager.LifeRecord.GetLifeRecordCollection().AddFinishSeekAsylum(selfCharId, currDate, location, SettlementId);
	}

	public bool OnExecutePhase(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		OrganizationInfo selfOrgInfo = selfChar.GetOrganizationInfo();
		if (Organization.Instance[selfOrgInfo.OrgTemplateId].IsSect)
		{
			return true;
		}
		if (!context.Random.CheckPercentProb(CurrChance))
		{
			CurrChance += 5;
			return false;
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(SettlementId);
		sbyte orgTemplateId = settlement.GetOrgTemplateId();
		sbyte rejoinGrade = OrganizationDomain.GetOrgMemberConfig(orgTemplateId, selfOrgInfo.Grade).GetRejoinGrade();
		OrganizationInfo targetOrgInfo = new OrganizationInfo(orgTemplateId, rejoinGrade, principal: true, SettlementId);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		int selfCharId = selfChar.GetId();
		lifeRecordCollection.AddSeekAsylumSuccess(location: selfChar.GetLocation(), gender: selfChar.GetGender(), selfCharId: selfCharId, date: currDate, settlementId: SettlementId, orgTemplateId: targetOrgInfo.OrgTemplateId, orgGrade: targetOrgInfo.Grade, orgPrincipal: true);
		DomainManager.Organization.ChangeOrganization(context, selfChar, targetOrgInfo);
		if (DomainManager.Character.IsTaiwuPeople(selfCharId))
		{
			DomainManager.World.GetMonthlyNotificationCollection().AddJoinOrganization(selfCharId, SettlementId);
		}
		AdaptableLog.Info($"{selfChar} 成功获得 {settlement} 的庇护.");
		return true;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
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
		*(short*)num = SettlementId;
		byte* num2 = num + 2;
		*num2 = (byte)CurrChance;
		int totalSize = (int)(num2 + 1 - pData);
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
			SettlementId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			CurrChance = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
