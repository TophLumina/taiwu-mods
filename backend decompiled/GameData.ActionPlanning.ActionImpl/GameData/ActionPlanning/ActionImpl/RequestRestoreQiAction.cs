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
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class RequestRestoreQiAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort HerbCost = 0;

		public const ushort AgreeToRequest = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "HerbCost", "AgreeToRequest" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	private int _herbCost;

	[SerializableGameDataField(FieldIndex = 1)]
	private bool _agreeToRequest;

	private const EHealActionType ActionType = EHealActionType.Breathing;

	private const sbyte ResourceType = 5;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		CombatResources usableCombatResources = DomainManager.Character.GetUsableCombatResources(targetChar.GetId());
		int herbAmount = targetChar.GetResource(5);
		if (targetChar.CalcHealAttainment(EHealActionType.Breathing) >= 200 && usableCombatResources.Get(EHealActionType.Breathing) > 0)
		{
			return character.CalcHealCostHerb(EHealActionType.Breathing) <= herbAmount;
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		if (!character.NeedHealAction(EHealActionType.Breathing))
		{
			return false;
		}
		Character targetChar = actionData.TargetChar;
		int resource = targetChar.GetResource(5);
		_herbCost = character.CalcHealCostHerb(EHealActionType.Breathing);
		if (resource < _herbCost)
		{
			return false;
		}
		sbyte behaviorType = targetChar.GetBehaviorType();
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetChar.GetId(), character.GetId()));
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(behaviorType, favorabilityType);
		_agreeToRequest = context.Random.CheckPercentProb(respondChance);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		if (actionData.TargetChar.GetResource(5) >= _herbCost)
		{
			return DomainManager.Character.GetUsableCombatResources(actionData.TargetCharId).Get(EHealActionType.Breathing) > 0;
		}
		return false;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		DomainManager.World.GetMonthlyEventCollection();
		character.GetId();
		targetChar.GetId();
		targetChar.GetLocation();
		CharacterDomain.AddLockMovementCharSet(character.GetId());
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int characterId = character.GetId();
		int targetCharId = targetChar.GetId();
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (_agreeToRequest)
		{
			targetChar.ChangeResource(context, 5, -_herbCost);
			DomainManager.Character.UseCombatResources(context, targetCharId, EHealActionType.Breathing, 1);
			targetChar.DoHealAction(context, EHealActionType.Breathing, character);
			short deltaFavor = AiHelper.GeneralActionConstants.GetResourceFavorabilityChange(5, _herbCost);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, deltaFavor);
			sbyte happinessChange = AiHelper.GeneralActionConstants.GetResourceHappinessChange(5, _herbCost);
			character.ChangeHappiness(context, happinessChange);
			lifeRecordCollection.AddRequestHealDisorderOfQiSucceedByRes(characterId, currDate, targetCharId, location, _herbCost, 5);
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestRestoreDisorderOfQi(targetCharId, characterId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			character.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -6000);
			lifeRecordCollection.AddRequestHealDisorderOfQiFailByRes(characterId, currDate, targetCharId, location, _herbCost, 5);
			int secretInfoOffset2 = secretInformationCollection.AddRefuseRequestRestoreDisorderOfQi(targetCharId, characterId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 2;
		byte* num = pData + 2;
		*(int*)num = _herbCost;
		byte* num2 = num + 4;
		*num2 = (_agreeToRequest ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num2 + 1 - pData);
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
			_herbCost = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			_agreeToRequest = *pCurrData != 0;
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
