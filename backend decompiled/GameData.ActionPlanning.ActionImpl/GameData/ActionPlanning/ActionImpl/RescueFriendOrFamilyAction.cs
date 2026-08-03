using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.Combat;
using GameData.Domains.Information;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class RescueFriendOrFamilyAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		if (!DomainManager.Character.TryGetElement_Objects(actionData.TargetCharId, out var targetChar))
		{
			return false;
		}
		Location targetLocation = targetChar.GetLocation();
		Location selfLocation = selfChar.GetLocation();
		int kidnapperId = targetChar.GetKidnapperId();
		if (kidnapperId == selfChar.GetId())
		{
			return false;
		}
		if (kidnapperId < 0 && selfLocation.IsValid() && selfLocation.AreaId == targetLocation.AreaId)
		{
			byte areaSize = DomainManager.Map.GetAreaSize(selfLocation.AreaId);
			ByteCoordinate selfCoordinate = ByteCoordinate.IndexToCoordinate(selfLocation.BlockId, areaSize);
			ByteCoordinate targetCoordinate = ByteCoordinate.IndexToCoordinate(targetLocation.BlockId, areaSize);
			if (selfCoordinate.GetManhattanDistance(targetCoordinate) <= 3)
			{
				return false;
			}
		}
		return FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(selfChar.GetId(), actionData.TargetCharId)) >= 2;
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
			DomainManager.LifeRecord.GetLifeRecordCollection().AddDecideToRescue(date: DomainManager.World.GetCurrDate(), location: selfChar.GetLocation(), selfCharId: selfCharId, charId: actionData.TargetCharId);
			if (DomainManager.Character.IsTaiwuPeople(selfCharId) || DomainManager.Character.IsTaiwuPeople(actionData.TargetCharId))
			{
				DomainManager.World.GetMonthlyNotificationCollection().AddGoToRescue(charId2: DomainManager.Character.GetElement_Objects(actionData.TargetCharId).GetKidnapperId(), charId: selfCharId, charId1: actionData.TargetCharId);
			}
		}
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		DomainManager.LifeRecord.GetLifeRecordCollection().AddFinishRescue(date: DomainManager.World.GetCurrDate(), selfCharId: selfChar.GetId(), location: selfChar.GetLocation(), charId: actionData.TargetCharId);
	}

	public bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (CharacterDomain.IsLockMovementChar(actionData.TargetCharId))
		{
			return false;
		}
		sbyte behaviorType = selfChar.GetBehaviorType();
		sbyte[] obj = AiHelper.PrioritizedActionConstants.RescueFriendOrFamilyActionPriorities[behaviorType];
		sbyte selectedDemandActionType = -1;
		sbyte[] array = obj;
		foreach (sbyte actionType in array)
		{
			int chance = 60 + AiHelper.DemandActionType.ToPersonalityType[actionType];
			if (context.Random.CheckPercentProb(chance))
			{
				selectedDemandActionType = actionType;
				break;
			}
		}
		return selectedDemandActionType switch
		{
			1 => HandleSteal(context, selfChar, actionData.TargetChar), 
			2 => HandleScam(context, selfChar, actionData.TargetChar), 
			3 => HandleRob(context, selfChar, actionData.TargetChar), 
			_ => false, 
		};
	}

	private bool HandleSteal(DataContext context, Character selfChar, Character targetChar)
	{
		DomainManager.Taiwu.GetTaiwu();
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int kidnapperId = targetChar.GetKidnapperId();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		int alertFactor = targetChar.GetGradeAlertFactor(targetChar.GetOrganizationInfo().Grade, 1);
		switch (selfChar.GetStealActionPhase(context.Random, targetChar, alertFactor))
		{
		case 0:
			lifeRecordCollection.AddRescueKidnappedCharacterSecretlyFail1(selfCharId, currDate, kidnapperId, location, targetCharId);
			break;
		case 1:
			lifeRecordCollection.AddRescueKidnappedCharacterSecretlyFail2(selfCharId, currDate, kidnapperId, location, targetCharId);
			break;
		case 2:
			lifeRecordCollection.AddRescueKidnappedCharacterSecretlyFail3(selfCharId, currDate, kidnapperId, location, targetCharId);
			break;
		case 3:
			lifeRecordCollection.AddRescueKidnappedCharacterSecretlyFail4(selfCharId, currDate, kidnapperId, location, targetCharId);
			break;
		case 4:
		{
			lifeRecordCollection.AddRescueKidnappedCharacterSecretlySucceed(selfCharId, currDate, kidnapperId, location, targetCharId);
			RescueSucceed(context, selfCharId, targetCharId, kidnapperId);
			if (kidnapperId == taiwuCharId)
			{
				DomainManager.World.GetMonthlyEventCollection().AddRescueKidnappedCharacterSecretlyButBeCaught(selfCharId, location, kidnapperId, targetCharId);
				return false;
			}
			AiHelper.NpcCombatResultType result = DomainManager.Character.SimulateCharacterCombat(context, selfChar, targetChar, CombatType.Beat);
			if ((uint)result <= 1u)
			{
				DomainManager.Character.SimulateCharacterCombatResult(context, selfChar, targetChar, 20, 40, 60);
			}
			else
			{
				DomainManager.Character.SimulateCharacterCombatResult(context, targetChar, selfChar, 20, 40, 60);
			}
			break;
		}
		default:
			lifeRecordCollection.AddRescueKidnappedCharacterSecretlySucceedAndEscaped(selfCharId, currDate, kidnapperId, location, targetCharId);
			RescueSucceed(context, selfCharId, targetCharId, kidnapperId);
			if (kidnapperId == taiwuCharId)
			{
				return false;
			}
			break;
		}
		return targetChar.GetKidnapperId() < 0;
	}

	private bool HandleScam(DataContext context, Character selfChar, Character targetChar)
	{
		DomainManager.Taiwu.GetTaiwu();
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int kidnapperId = targetChar.GetKidnapperId();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		int alertFactor = targetChar.GetGradeAlertFactor(targetChar.GetOrganizationInfo().Grade, 1);
		sbyte actionPhase = selfChar.GetScamActionPhase(context.Random, targetChar, alertFactor);
		if (kidnapperId == taiwuCharId && actionPhase >= 3)
		{
			DomainManager.World.GetMonthlyEventCollection().AddRescueKidnappedCharacterWithWit(selfCharId, location, kidnapperId, targetCharId);
			return false;
		}
		switch (actionPhase)
		{
		case 0:
			lifeRecordCollection.AddRescueKidnappedCharacterWithWitFail1(selfCharId, currDate, kidnapperId, location, targetCharId);
			break;
		case 1:
			lifeRecordCollection.AddRescueKidnappedCharacterWithWitFail2(selfCharId, currDate, kidnapperId, location, targetCharId);
			break;
		case 2:
			lifeRecordCollection.AddRescueKidnappedCharacterWithWitFail3(selfCharId, currDate, kidnapperId, location, targetCharId);
			break;
		case 3:
			lifeRecordCollection.AddRescueKidnappedCharacterWithWitFail4(selfCharId, currDate, kidnapperId, location, targetCharId);
			break;
		case 4:
		{
			lifeRecordCollection.AddRescueKidnappedCharacterWithWitSucceed(selfCharId, currDate, kidnapperId, location, targetCharId);
			RescueSucceed(context, selfCharId, targetCharId, kidnapperId);
			AiHelper.NpcCombatResultType result = DomainManager.Character.SimulateCharacterCombat(context, selfChar, targetChar, CombatType.Beat);
			if ((uint)result <= 1u)
			{
				DomainManager.Character.SimulateCharacterCombatResult(context, selfChar, targetChar, 20, 40, 60);
			}
			else
			{
				DomainManager.Character.SimulateCharacterCombatResult(context, targetChar, selfChar, 20, 40, 60);
			}
			break;
		}
		default:
			lifeRecordCollection.AddRescueKidnappedCharacterWithWitSucceedAndEscaped(selfCharId, currDate, kidnapperId, location, targetCharId);
			RescueSucceed(context, selfCharId, targetCharId, kidnapperId);
			break;
		}
		return targetChar.GetKidnapperId() < 0;
	}

	private bool HandleRob(DataContext context, Character selfChar, Character targetChar)
	{
		DomainManager.Taiwu.GetTaiwu();
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int kidnapperId = targetChar.GetKidnapperId();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		int alertFactor = targetChar.GetGradeAlertFactor(targetChar.GetOrganizationInfo().Grade, 1);
		sbyte actionPhase = selfChar.GetRobActionPhase(context.Random, targetChar, alertFactor);
		if (kidnapperId == taiwuCharId && actionPhase >= 3)
		{
			DomainManager.World.GetMonthlyEventCollection().AddRescueKidnappedCharacterWithForce(selfCharId, location, kidnapperId, targetCharId);
			return false;
		}
		switch (actionPhase)
		{
		case 0:
			lifeRecordCollection.AddRescueKidnappedCharacterWithForceFail1(selfCharId, currDate, kidnapperId, location, targetCharId);
			break;
		case 1:
			lifeRecordCollection.AddRescueKidnappedCharacterWithForceFail2(selfCharId, currDate, kidnapperId, location, targetCharId);
			break;
		case 2:
			lifeRecordCollection.AddRescueKidnappedCharacterWithForceFail3(selfCharId, currDate, kidnapperId, location, targetCharId);
			break;
		case 3:
			lifeRecordCollection.AddRescueKidnappedCharacterWithForceFail4(selfCharId, currDate, kidnapperId, location, targetCharId);
			break;
		case 4:
		{
			lifeRecordCollection.AddRescueKidnappedCharacterWithForceSucceed(selfCharId, currDate, kidnapperId, location, targetCharId);
			RescueSucceed(context, selfCharId, targetCharId, kidnapperId);
			AiHelper.NpcCombatResultType result = DomainManager.Character.SimulateCharacterCombat(context, selfChar, targetChar, CombatType.Beat);
			if ((uint)result <= 1u)
			{
				DomainManager.Character.SimulateCharacterCombatResult(context, selfChar, targetChar, 20, 40, 60);
			}
			else
			{
				DomainManager.Character.SimulateCharacterCombatResult(context, targetChar, selfChar, 20, 40, 60);
			}
			break;
		}
		default:
			lifeRecordCollection.AddRescueKidnappedCharacterWithForceSucceedAndEscaped(selfCharId, currDate, kidnapperId, location, targetCharId);
			RescueSucceed(context, selfCharId, targetCharId, kidnapperId);
			break;
		}
		return targetChar.GetKidnapperId() < 0;
	}

	private void RescueSucceed(DataContext context, int selfCharId, int targetCharId, int kidnapperId)
	{
		DomainManager.Character.RemoveKidnappedCharacter(context, targetCharId, kidnapperId, isEscaped: true);
		int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddRescueKidnappedCharacter(selfCharId, targetCharId, kidnapperId);
		SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfCharId);
		bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetCharId);
		if (selfIsTaiwuPeople || targetIsTaiwuPeople)
		{
			DomainManager.World.GetMonthlyNotificationCollection().AddRescuePrisoner(selfCharId, targetCharId, kidnapperId);
			DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), selfIsTaiwuPeople ? selfCharId : targetCharId);
		}
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
