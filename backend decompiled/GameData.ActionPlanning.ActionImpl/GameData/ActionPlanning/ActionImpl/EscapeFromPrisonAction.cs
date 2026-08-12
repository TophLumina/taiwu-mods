using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class EscapeFromPrisonAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public int PhaseCount => 1;

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
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

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup())
		{
			short targetAreaId = actionData.GetActualTargetLocation().AreaId;
			string srcArea = DomainManager.Map.GetElement_Areas(selfChar.GetLocation().AreaId).GetConfig().Name;
			string dstArea = DomainManager.Map.GetElement_Areas(targetAreaId).GetConfig().Name;
			AdaptableLog.Info($"{selfChar} 开始畏罪潜逃: {srcArea} => {dstArea}.");
			if (selfChar.GetLeaderId() >= 0)
			{
				DomainManager.Character.LeaveGroup(context, selfChar);
			}
			int selfCharId = selfChar.GetId();
			int currDate = DomainManager.World.GetCurrDate();
			Location location = selfChar.GetLocation();
			sbyte bountySectId = DomainManager.Organization.GetFugitiveBountySect(selfChar.GetId());
			Sect obj = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(bountySectId);
			short settlementId = obj.GetId();
			SettlementBounty bounty = obj.Prison.GetBounty(selfCharId);
			Location targetLocation = new Location(targetAreaId, -1);
			DomainManager.LifeRecord.GetLifeRecordCollection().AddDecideToEscapePunishment(selfCharId, currDate, location, bounty.PunishmentType, settlementId, targetLocation);
		}
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		AdaptableLog.Info($"{selfChar} 结束了畏罪潜逃.");
		int selfCharId = selfChar.GetId();
		Location location = selfChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		DomainManager.LifeRecord.GetLifeRecordCollection().AddFinishEscapePunishment(selfCharId, currDate, location);
		sbyte idealSectId = selfChar.GetIdealSect();
		if (idealSectId >= 0 && idealSectId != DomainManager.Organization.GetFugitiveBountySect(selfCharId))
		{
			selfChar.AddGoal(context, 261, idealSectId);
		}
	}

	public void PreExecute(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		AdaptableLog.Info($"{selfChar} 到达目的地: {DomainManager.Map.GetElement_Areas(selfChar.GetValidLocation().AreaId).GetConfig().Name}");
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
