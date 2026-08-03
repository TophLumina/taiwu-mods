using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.Taiwu.VillagerRole;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class VillagerRoleArrangementAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public int PhaseCount => 1;

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(selfChar.GetId());
		if (villagerRole == null || villagerRole.ArrangementTemplateId < 0)
		{
			return false;
		}
		if (villagerRole.WorkData == null)
		{
			return false;
		}
		Location location = villagerRole.WorkData.Location;
		Location actualTargetLocation = actionData.GetActualTargetLocation();
		return IVillagerRoleSelectLocation.MatchWorkLocation(location, actualTargetLocation);
	}

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup())
		{
			int selfCharId = selfChar.GetId();
			Location location = DomainManager.Extra.GetVillagerRole(selfChar.GetId()).WorkData.Location;
			int currDate = DomainManager.World.GetCurrDate();
			DomainManager.LifeRecord.GetLifeRecordCollection().AddVillagerPrioritizedActions(selfCharId, currDate, location);
		}
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		Location location = selfChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		DomainManager.LifeRecord.GetLifeRecordCollection().AddVillagerPrioritizedActionsStop(selfCharId, currDate, location);
	}

	public bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(selfCharId);
		IVillagerRoleArrangementExecutor obj = (IVillagerRoleArrangementExecutor)villagerRole;
		obj.ExecuteArrangementAction(context);
		Location nextLocation = obj.SelectNextWorkLocation(context.Random, villagerRole.WorkData.Location);
		actionData.TargetLocation = nextLocation;
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
