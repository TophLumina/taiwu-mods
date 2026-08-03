using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Combat;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class HuntFugitiveAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public int PhaseCount => 1;

	public bool CheckValid(GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		OrganizationInfo orgInfo = selfChar.GetOrganizationInfo();
		if (!DomainManager.Organization.TryGetElement_Sects(orgInfo.SettlementId, out var sect))
		{
			return false;
		}
		SettlementBounty bounty = sect.Prison.GetBounty(actionData.TargetCharId);
		if (bounty == null)
		{
			return false;
		}
		if (bounty.CurrentHunterId >= 0 && bounty.CurrentHunterId != selfChar.GetId())
		{
			return false;
		}
		if (!DomainManager.Character.TryGetElement_Objects(bounty.CharId, out var targetChar))
		{
			return false;
		}
		if (OrganizationDomain.IsLargeSect(targetChar.GetOrganizationInfo().OrgTemplateId))
		{
			return false;
		}
		return true;
	}

	public void OnStart(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		if (selfChar.IsInTaiwuGroup())
		{
			return;
		}
		int selfCharId = selfChar.GetId();
		OrganizationInfo orgInfo = selfChar.GetOrganizationInfo();
		Sect sect = DomainManager.Organization.GetElement_Sects(orgInfo.SettlementId);
		SettlementBounty bounty = sect.Prison.GetBounty(actionData.TargetCharId);
		if (bounty.CurrentHunterId < 0)
		{
			bounty.CurrentHunterId = selfCharId;
			DomainManager.Organization.SetSettlementPrison(context, orgInfo.SettlementId, sect.Prison);
			int leaderId = selfChar.GetLeaderId();
			if (leaderId >= 0 && leaderId != selfCharId)
			{
				DomainManager.Character.LeaveGroup(context, selfChar);
			}
			AdaptableLog.Info($"{selfChar} 开始追捕逃犯 {DomainManager.Character.GetElement_Objects(bounty.CharId)}.");
			Location location = selfChar.GetLocation();
			int currDate = DomainManager.World.GetCurrDate();
			DomainManager.LifeRecord.GetLifeRecordCollection().AddDecideToHuntFugitive(selfCharId, currDate, actionData.TargetCharId, location);
		}
	}

	public void OnInterrupt(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		OrganizationInfo orgInfo = selfChar.GetOrganizationInfo();
		sbyte targetBountySect = DomainManager.Organization.GetFugitiveBountySect(actionData.TargetCharId);
		if (targetBountySect >= 0)
		{
			Sect sect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(targetBountySect);
			SettlementBounty bounty = sect.Prison.GetBounty(actionData.TargetCharId);
			if (bounty.CurrentHunterId == selfChar.GetId())
			{
				bounty.CurrentHunterId = -1;
				DomainManager.Organization.SetSettlementPrison(context, orgInfo.SettlementId, sect.Prison);
			}
		}
		int selfCharId = selfChar.GetId();
		Location location = selfChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		DomainManager.LifeRecord.GetLifeRecordCollection().AddFinishHuntFugitive(selfCharId, currDate, actionData.TargetCharId, location);
		AdaptableLog.Info($"{selfChar} 终止追捕逃犯.");
	}

	public bool OnExecutePhase(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		if (!DomainManager.Character.TryGetElement_Objects(actionData.TargetCharId, out var targetChar))
		{
			return true;
		}
		int selfCharId = selfChar.GetId();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (targetChar.GetId() == taiwuCharId)
		{
			if (DomainManager.World.GetWorldFunctionsStatus(4))
			{
				DomainManager.World.GetMonthlyEventCollection().AddHuntCriminalTaiwu(selfCharId, actionData.TargetCharId, selfChar.GetLocation());
				CharacterDomain.AddLockMovementCharSet(selfCharId);
			}
			return false;
		}
		if (targetChar.GetLeaderId() == taiwuCharId)
		{
			DomainManager.World.GetMonthlyEventCollection().AddHuntCriminal(taiwuCharId, selfCharId, actionData.TargetCharId);
			CharacterDomain.AddLockMovementCharSet(selfCharId);
			return false;
		}
		if (!targetChar.GetLocation().IsValid() || !targetChar.IsInteractableAsIntelligentCharacter())
		{
			return false;
		}
		OrganizationInfo orgInfo = selfChar.GetOrganizationInfo();
		Sect sect = DomainManager.Organization.GetElement_Sects(orgInfo.SettlementId);
		SettlementPrison prison = sect.Prison;
		SettlementBounty bounty = prison.GetBounty(actionData.TargetCharId);
		PunishmentSeverityItem punishSeverityCfg = PunishmentSeverity.Instance[bounty.PunishmentSeverity];
		Location location = selfChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		AiHelper.NpcCombatResultType resultType = DomainManager.Character.SimulateCharacterCombat(context, selfChar, targetChar, CombatType.Beat);
		if ((uint)resultType <= 1u)
		{
			AdaptableLog.Info($"{selfChar} 成功捕获逃犯 {targetChar}.");
			DomainManager.LifeRecord.GetLifeRecordCollection().AddArrestedSuccessfullyCaptor(selfCharId, currDate, actionData.TargetCharId, location, orgInfo.SettlementId, 889);
			if (punishSeverityCfg.PrisonTime > 0 || punishSeverityCfg.Expel)
			{
				DomainManager.Character.CombatResultHandle_KidnapEnemy(context, selfChar, targetChar, isInPublic: true);
			}
			else
			{
				DomainManager.Organization.PunishSectMember(context, sect, targetChar, bounty.PunishmentSeverity, bounty.PunishmentType, isArrested: true);
				sect.RemoveBounty(context, targetChar.GetId());
				selfChar.RecordFameAction(context, 83, targetChar.GetId(), bounty.CaptorFameActionMultiplier);
			}
		}
		else
		{
			DomainManager.LifeRecord.GetLifeRecordCollection().AddArrestFailedCaptor(selfCharId, currDate, actionData.TargetCharId, location, orgInfo.SettlementId, 886);
			bounty.CurrentHunterId = -1;
			if (bounty.RequiredConsummateLevel < 0)
			{
				bounty.RequiredConsummateLevel = targetChar.GetConsummateLevel();
			}
			bounty.RequiredConsummateLevel++;
			AdaptableLog.Info($"{selfChar} 未能战胜逃犯 {targetChar}.");
			DomainManager.Organization.SetSettlementPrison(context, orgInfo.SettlementId, prison);
		}
		return true;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 0;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		_ = *(ushort*)pData;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
