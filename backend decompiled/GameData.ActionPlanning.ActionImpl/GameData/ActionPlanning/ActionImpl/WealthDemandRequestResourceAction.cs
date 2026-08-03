using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class WealthDemandRequestResourceAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ResourceType = 0;

		public const ushort Amount = 1;

		public const ushort AgreeToRequest = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "ResourceType", "Amount", "AgreeToRequest" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte ResourceType;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool AgreeToRequest;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		return targetChar.GetResource(args.ResourceType) >= args.Amount;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte resourceType = argGroup.ResourceType;
		int amount = argGroup.Amount;
		Character targetChar = actionData.TargetChar;
		sbyte mainAttributeType = AiHelper.DemandActionType.ToMainAttributeType(0, isSkill: false);
		if (mainAttributeType >= 0 && character.GetCurrMainAttribute(mainAttributeType) < GlobalConfig.Instance.HarmfulActionCost)
		{
			return false;
		}
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(actionData.TargetCharId, character.GetId()));
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(targetChar.GetBehaviorType(), favorabilityType);
		AgreeToRequest = context.Random.CheckPercentProb(respondChance);
		ResourceType = resourceType;
		Amount = amount;
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
		DomainManager.World.GetMonthlyEventCollection().AddRequestResource(selfCharId, location, targetCharId, Amount, ResourceType);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location location = character.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		if (AgreeToRequest)
		{
			character.ChangeResource(context, ResourceType, Amount);
			targetChar.ChangeResource(context, ResourceType, -Amount);
			short deltaFavor = AiHelper.GeneralActionConstants.GetResourceFavorabilityChange(ResourceType, Amount);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, deltaFavor);
			sbyte happinessChange = AiHelper.GeneralActionConstants.GetResourceHappinessChange(ResourceType, Amount);
			character.ChangeHappiness(context, happinessChange);
			lifeRecordCollection.AddRequestResourceSucceed(selfCharId, currDate, targetCharId, location, ResourceType, Amount);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddAcceptRequestResource(targetCharId, selfCharId, ResourceType);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -3000);
			character.ChangeHappiness(context, -3);
			lifeRecordCollection.AddRequestResourceFail(selfCharId, currDate, targetCharId, location, ResourceType, Amount);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestResource(targetCharId, selfCharId, ResourceType);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
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
		*num3 = (AgreeToRequest ? ((byte)1) : ((byte)0));
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
			AgreeToRequest = *pCurrData != 0;
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
