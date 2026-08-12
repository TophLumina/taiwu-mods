using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class GuardTreasuryAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public int PhaseCount => 1;

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		short settlementId = selfChar.GetOrganizationInfo().SettlementId;
		if (settlementId < 0)
		{
			return false;
		}
		if (!DomainManager.Organization.GetSettlement(settlementId).Treasuries.IsGuard(selfChar.GetId()))
		{
			return false;
		}
		if (DomainManager.LegendaryBook.IsCharacterLegendaryBookOwnerOrContest(selfChar.GetId()))
		{
			return false;
		}
		return true;
	}

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup())
		{
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			int charId = selfChar.GetId();
			int currDate = DomainManager.World.GetCurrDate();
			short settlementId = selfChar.GetOrganizationInfo().SettlementId;
			Location location = selfChar.GetLocation();
			lifeRecordCollection.AddDecideToGuardTreasury(charId, currDate, location, settlementId);
			if (selfChar.GetLeaderId() != selfChar.GetId())
			{
				DomainManager.Character.LeaveGroup(context, selfChar);
			}
		}
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = selfChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location targetLocation = actionData.GetActualTargetLocation();
		Location rootLocation = DomainManager.Map.GetBlock(targetLocation).GetRootBlock().GetLocation();
		Settlement settlement = DomainManager.Organization.GetSettlementByLocation(rootLocation);
		if (settlement == null)
		{
			settlement = DomainManager.Organization.GetSettlement(selfChar.GetOrganizationInfo().SettlementId);
		}
		Location location = selfChar.GetLocation();
		lifeRecordCollection.AddFinishGuardingTreasury(charId, currDate, location, settlement.GetId());
		selfChar.RemoveFeatureGroup(context, 691);
	}

	public bool OnExecutePhase(DataContext context, Character character, CharacterActionData actionData)
	{
		return false;
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
