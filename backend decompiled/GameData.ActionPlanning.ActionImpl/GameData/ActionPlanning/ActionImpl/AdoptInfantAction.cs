using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.Information.Collection;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class AdoptInfantAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public int PhaseCount => 1;

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		if (DomainManager.Character.InfantHasPotentialAdopter(actionData.TargetCharId) && !DomainManager.Character.IsCharacterPotentialInfantAdopter(actionData.TargetCharId, selfChar.GetId()))
		{
			return false;
		}
		if (!DomainManager.Character.TryGetElement_Objects(actionData.TargetCharId, out var target))
		{
			return false;
		}
		if (target.GetAgeGroup() != 0)
		{
			return false;
		}
		if (selfChar.GetLocation().AreaId != target.GetLocation().AreaId)
		{
			return false;
		}
		if (target.GetLeaderId() >= 0)
		{
			return target.GetLeaderId() == selfChar.GetLeaderId();
		}
		return true;
	}

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup())
		{
			if (selfChar.GetLeaderId() != selfChar.GetId())
			{
				DomainManager.Character.LeaveGroup(context, selfChar);
			}
			DomainManager.LifeRecord.GetLifeRecordCollection().AddDecideToAdoptFoundling(selfChar.GetId(), DomainManager.World.GetCurrDate(), actionData.TargetCharId, selfChar.GetLocation());
			DomainManager.Character.AddPotentialAdopterToInfant(actionData.TargetCharId, selfChar.GetId());
		}
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (DomainManager.Character.IsCharacterPotentialInfantAdopter(actionData.TargetCharId, selfChar.GetId()))
		{
			DomainManager.Character.RemovePotentialAdopterToInfant(actionData.TargetCharId);
		}
		DomainManager.LifeRecord.GetLifeRecordCollection().AddAdoptFoundlingFail(selfChar.GetId(), DomainManager.World.GetCurrDate(), actionData.TargetCharId, selfChar.GetLocation());
	}

	public bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int charId = selfChar.GetId();
		int targetCharId = actionData.TargetCharId;
		DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar);
		int leaderId = targetChar.GetLeaderId();
		if (leaderId >= 0 && leaderId == selfChar.GetLeaderId())
		{
			selfChar.DeactivateAdvanceMonthStatus(7);
			bool num = RelationTypeHelper.AllowAddingAdoptiveChildRelation(charId, targetCharId);
			int currDate = DomainManager.World.GetCurrDate();
			Location location = selfChar.GetLocation();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset;
			if (num)
			{
				int spouseId = DomainManager.Character.GetAliveSpouse(charId);
				DomainManager.Character.AddAdoptiveParentRelations(context, targetCharId, charId, currDate);
				if (spouseId >= 0 && RelationTypeHelper.AllowAddingAdoptiveChildRelation(spouseId, targetCharId))
				{
					DomainManager.Character.AddAdoptiveParentRelations(context, targetCharId, spouseId, currDate);
				}
				lifeRecordCollection.AddAdoptFoundlingSucceed(charId, currDate, targetCharId, location);
				secretInfoOffset = secretInformationCollection.AddAdoptChild(charId, targetCharId);
			}
			else
			{
				lifeRecordCollection.AddClaimFoundlingSucceed(charId, currDate, targetCharId, location);
				secretInfoOffset = secretInformationCollection.AddRetrieveChild(charId, targetCharId);
			}
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			DomainManager.Character.MarkInfantAsAdopted(targetCharId);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, 12000);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, selfChar, 12000);
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeSwornOrAdoptedFamilyHappinessChange[selfChar.GetBehaviorType()]);
			targetChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeSwornOrAdoptedFamilyHappinessChange[targetChar.GetBehaviorType()]);
			return true;
		}
		targetChar.SetHealth(targetChar.GetLeftMaxHealth(), context);
		DomainManager.Character.JoinGroup(context, targetChar, selfChar);
		selfChar.ActivateAdvanceMonthStatus(7);
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
