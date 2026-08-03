using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Combat;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class WealthDemandRobResourceAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ResourceType = 0;

		public const ushort Amount = 1;

		public const ushort Phase = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "ResourceType", "Amount", "Phase" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte ResourceType;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte Phase;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		return targetChar.GetResource(args.ResourceType) >= args.Amount;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte resourceType = argGroup.ResourceType;
		int amount = argGroup.Amount;
		Character targetChar = actionData.TargetChar;
		sbyte mainAttributeType = AiHelper.DemandActionType.ToMainAttributeType(3, isSkill: false);
		if (mainAttributeType >= 0 && character.GetCurrMainAttribute(mainAttributeType) < GlobalConfig.Instance.HarmfulActionCost)
		{
			return false;
		}
		int alertFactor = targetChar.GetResourceAlertFactor(resourceType);
		ResourceType = resourceType;
		Amount = amount;
		Phase = character.GetRobActionPhase(context.Random, targetChar, alertFactor);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return actionData.TargetChar.GetResource(ResourceType) >= Amount;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = character.GetLocation();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		if (Phase <= 2)
		{
			monthlyNotificationCollection.AddRobResourceFailure(selfCharId, location, targetCharId, ResourceType);
			ApplyChanges(context, character, targetChar);
		}
		else
		{
			monthlyEventCollection.AddRobResource(selfCharId, location, targetCharId, ResourceType, Amount);
			CharacterDomain.AddLockMovementCharSet(selfCharId);
		}
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		ApplyChanges(context, character, actionData.TargetChar);
	}

	private void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (selfCharId != taiwuCharId)
		{
			selfChar.ChangeCurrMainAttribute(context, 0, -GlobalConfig.Instance.HarmfulActionCost);
		}
		if (Phase >= 4)
		{
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddRobResource(selfCharId, targetCharId, ResourceType);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		switch (Phase)
		{
		case 0:
			lifeRecordCollection.AddRobResourceFail1(selfCharId, currDate, targetCharId, location, ResourceType);
			break;
		case 1:
			lifeRecordCollection.AddRobResourceFail2(selfCharId, currDate, targetCharId, location, ResourceType);
			break;
		case 2:
			lifeRecordCollection.AddRobResourceFail3(selfCharId, currDate, targetCharId, location, ResourceType);
			break;
		case 3:
			lifeRecordCollection.AddRobResourceFail4(selfCharId, currDate, targetCharId, location, ResourceType);
			break;
		case 4:
			lifeRecordCollection.AddRobResourceSucceed(selfCharId, currDate, targetCharId, location, ResourceType, Amount);
			if (targetCharId != DomainManager.Taiwu.GetTaiwuCharId())
			{
				AiHelper.NpcCombatResultType combatResultType = DomainManager.Character.SimulateCharacterCombat(context, targetChar, selfChar, CombatType.Beat);
				if ((uint)(combatResultType - 2) <= 1u)
				{
					selfChar.ChangeResource(context, ResourceType, Amount);
					targetChar.ChangeResource(context, ResourceType, -Amount);
					int happinessChange2 = -AiHelper.GeneralActionConstants.GetResourceHappinessChange(ResourceType, Amount);
					targetChar.ChangeHappiness(context, happinessChange2);
					DomainManager.Character.SimulateCharacterCombatResult(context, selfChar, targetChar, -40, -20, 0);
				}
				else
				{
					lifeRecordCollection.AddRobResourceFailAndBeatenUp(selfCharId, currDate, targetCharId, location, ResourceType, Amount);
					DomainManager.Character.SimulateCharacterCombatResult(context, targetChar, selfChar, -40, -20, 0);
				}
			}
			break;
		default:
		{
			selfChar.ChangeResource(context, ResourceType, Amount);
			targetChar.ChangeResource(context, ResourceType, -Amount);
			int happinessChange = -AiHelper.GeneralActionConstants.GetResourceHappinessChange(ResourceType, Amount);
			targetChar.ChangeHappiness(context, happinessChange);
			lifeRecordCollection.AddRobResourceSucceedAndEscaped(selfCharId, currDate, targetCharId, location, ResourceType, Amount);
			break;
		}
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 3;
		byte* num = pData + 2;
		*num = (byte)ResourceType;
		byte* num2 = num + 1;
		*(int*)num2 = Amount;
		byte* num3 = num2 + 4;
		*num3 = (byte)Phase;
		int totalSize = (int)(num3 + 1 - pData);
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
		if (num > 2)
		{
			Phase = (sbyte)(*pCurrData);
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
