using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class AppointmentAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public int PhaseCount => 1;

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = actionData.TargetCharId;
		if (!DomainManager.Character.IsCharacterAlive(targetCharId))
		{
			return false;
		}
		if (DomainManager.Taiwu.TryGetElement_Appointments(selfCharId, out var targetLocation) && !targetLocation.Equals(actionData.GetActualTargetLocation()))
		{
			return false;
		}
		return FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(selfChar.GetId(), targetCharId)) >= 2;
	}

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup())
		{
			int selfCharId = selfChar.GetId();
			int groupLeader = selfChar.GetLeaderId();
			if (groupLeader >= 0 && groupLeader != selfCharId)
			{
				DomainManager.Character.LeaveGroup(context, selfChar);
			}
			DomainManager.Taiwu.RemoveAppointment(context, selfCharId);
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			int currDate = DomainManager.World.GetCurrDate();
			Location targetLocation = actionData.GetActualTargetLocation();
			lifeRecordCollection.AddDecideToFullfillAppointment(selfCharId, currDate, targetLocation);
			DomainManager.World.GetMonthlyNotificationCollection().AddGoToAppointment(selfCharId, targetLocation);
		}
	}

	public void OnTraveling(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!DomainManager.Character.TryGetElement_CrossAreaMoveInfos(selfChar.GetId(), out var crossAreaMoveInfo))
		{
			return;
		}
		int totalDays = 0;
		foreach (short item in crossAreaMoveInfo.Route.CostList)
		{
			totalDays += item;
		}
		int remainDays = totalDays - crossAreaMoveInfo.CostedDays;
		DomainManager.World.GetMonthlyNotificationCollection().AddGoingToAppointment(selfChar.GetId(), (remainDays + 29) / 30, actionData.GetActualTargetLocation());
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		int selfCharId = selfChar.GetId();
		int targetCharId = actionData.TargetCharId;
		Location targetLocation = actionData.GetActualTargetLocation();
		lifeRecordCollection.AddCanNoLongerFullFillAppointment(selfCharId, currDate, targetLocation);
		if (DomainManager.Character.IsCharacterAlive(targetCharId))
		{
			DomainManager.World.GetMonthlyNotificationCollection().AddAppointmentCancelled(selfCharId, targetLocation, targetCharId);
			DomainManager.World.GetMonthlyEventCollection().AddAppointmentCancelled(selfCharId, targetLocation);
		}
	}

	public void PreExecute(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		DomainManager.LifeRecord.GetLifeRecordCollection().AddWaitForAppointment(date: DomainManager.World.GetCurrDate(), selfCharId: selfChar.GetId(), location: actionData.GetActualTargetLocation(), charId: actionData.TargetCharId);
	}

	public bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		int selfCharId = selfChar.GetId();
		Location targetLocation = actionData.GetActualTargetLocation();
		monthlyNotificationCollection.AddWaitingForAppointment(selfCharId, targetLocation, actionData.TargetCharId);
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
