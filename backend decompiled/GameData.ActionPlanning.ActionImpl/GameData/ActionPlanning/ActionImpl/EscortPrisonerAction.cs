using System.Collections.Generic;
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
public class EscortPrisonerAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public int PhaseCount => 1;

	public bool OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		actionData.TargetLocation = DomainManager.Organization.GetSettlementByOrgTemplateId(argGroup.OrgTemplateId).GetLocation();
		return true;
	}

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsActiveExternalRelationState(2uL))
		{
			return false;
		}
		int selfCharId = selfChar.GetId();
		sbyte selfOrgTemplateId = selfChar.GetOrganizationInfo().OrgTemplateId;
		foreach (KidnappedCharacter kidnappedChar in DomainManager.Character.GetKidnappedCharacters(selfCharId).GetCollection())
		{
			sbyte bountySectTemplateId = DomainManager.Organization.GetFugitiveBountySect(kidnappedChar.CharId);
			if (bountySectTemplateId >= 0 && bountySectTemplateId == selfOrgTemplateId)
			{
				return true;
			}
		}
		return false;
	}

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup())
		{
			AdaptableLog.Info($"{selfChar} start escorting prisoner {DomainManager.Character.GetElement_Objects(actionData.TargetCharId)}.");
			int selfCharId = selfChar.GetId();
			int targetCharId = actionData.TargetCharId;
			int currDate = DomainManager.World.GetCurrDate();
			Location location = selfChar.GetLocation();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			short settlementId = selfChar.GetOrganizationInfo().SettlementId;
			lifeRecordCollection.AddDecideToEscortPrisoner(selfCharId, currDate, targetCharId, location, settlementId);
		}
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		AdaptableLog.Info(DomainManager.Character.TryGetElement_Objects(actionData.TargetCharId, out var targetChar) ? $"{selfChar} end escorting prisoner {targetChar}." : $"{selfChar} end escorting prisoner {actionData.TargetCharId}.");
	}

	public bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		sbyte selfOrgTemplateId = selfChar.GetOrganizationInfo().OrgTemplateId;
		KidnappedCharacterList kidnappedChars = DomainManager.Character.GetKidnappedCharacters(selfCharId);
		List<KidnappedCharacter> kidnappedCharList = kidnappedChars.GetCollection();
		for (int index = kidnappedCharList.Count - 1; index >= 0; index--)
		{
			KidnappedCharacter kidnappedChar = kidnappedCharList[index];
			sbyte bountySectTemplateId = DomainManager.Organization.GetFugitiveBountySect(kidnappedChar.CharId);
			if (bountySectTemplateId >= 0 && bountySectTemplateId == selfOrgTemplateId)
			{
				int currDate = DomainManager.World.GetCurrDate();
				Sect sect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(bountySectTemplateId);
				SettlementBounty bounty = sect.Prison.GetBounty(kidnappedChar.CharId);
				Character targetChar = DomainManager.Character.GetElement_Objects(kidnappedChar.CharId);
				DomainManager.Character.RemoveKidnappedCharacter(context, selfChar, kidnappedChars, index, isEscaped: false);
				DomainManager.Organization.PunishSectMember(context, sect, targetChar, bounty.PunishmentSeverity, bounty.PunishmentType, isArrested: true);
				AdaptableLog.Info($"{selfChar} successfully escorted {targetChar}.");
				int targetCharId = kidnappedChar.CharId;
				Location location = selfChar.GetLocation();
				DomainManager.LifeRecord.GetLifeRecordCollection().AddEscortPrisonerSucceed(selfCharId, currDate, targetCharId, location);
				selfChar.RecordFameAction(context, 83, targetCharId, bounty.CaptorFameActionMultiplier);
			}
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
