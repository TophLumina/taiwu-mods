using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class StudyDemandBreakingAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort CombatSkillTemplateId = 0;

		public const ushort AgreeToRequest = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "CombatSkillTemplateId", "AgreeToRequest" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short CombatSkillTemplateId;

	[SerializableGameDataField(FieldIndex = 1)]
	public bool AgreeToRequest;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		if (DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(targetChar.GetId(), args.CombatSkillTemplateId), out var targetCombatSkill))
		{
			return CombatSkillStateHelper.IsBrokenOut(targetCombatSkill.GetActivationState());
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetChar.GetId(), character.GetId()));
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(targetChar.GetBehaviorType(), favorabilityType);
		CombatSkillTemplateId = argGroup.CombatSkillTemplateId;
		AgreeToRequest = context.Random.CheckPercentProb(respondChance);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.CombatSkill.CombatSkill combatSkill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), CombatSkillTemplateId));
		if (!CombatSkillStateHelper.IsBrokenOut(combatSkill.GetActivationState()))
		{
			return combatSkill.CanBreakout();
		}
		return false;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = character.GetId();
		Location location = targetChar.GetLocation();
		monthlyEventCollection.AddRequestInstructionOnBreakout(selfCharId, location, targetChar.GetId(), CombatSkillTemplateId);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		CombatSkillItem combatSkillCfg = Config.CombatSkill.Instance[CombatSkillTemplateId];
		_ = Config.SkillBook.Instance[combatSkillCfg.BookId];
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (AgreeToRequest)
		{
			GameData.Domains.CombatSkill.CombatSkill element_CombatSkills = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(selfCharId, CombatSkillTemplateId));
			ushort readingState = element_CombatSkills.GetReadingState();
			ushort activationState = CombatSkillStateHelper.GenerateRandomActivatedOutlinePage(activationState: CombatSkillStateHelper.GenerateRandomActivatedNormalPages(context.Random, readingState, 0), random: context.Random, readingState: readingState, behaviorType: character.GetBehaviorType());
			sbyte availableStepsCount = character.GetSkillBreakoutAvailableStepsCount(CombatSkillTemplateId);
			element_CombatSkills.SetActivationState(activationState, context);
			element_CombatSkills.SetBreakoutStepsCount(availableStepsCount, context);
			character.ChangeHappiness(context, ItemTemplateHelper.GetBaseHappinessChange(10, combatSkillCfg.BookId) / 2);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, ItemTemplateHelper.GetBaseFavorabilityChange(10, combatSkillCfg.BookId));
			lifeRecordCollection.AddRequestInstructionOnBreakoutSucceed(selfCharId, currDate, targetCharId, location, CombatSkillTemplateId);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddAcceptRequestInstructionOnBreakout(targetCharId, selfCharId, CombatSkillTemplateId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			character.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -3000);
			lifeRecordCollection.AddRequestInstructionOnBreakoutFail(selfCharId, currDate, targetCharId, location, CombatSkillTemplateId);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestInstructionOnBreakout(targetCharId, selfCharId, CombatSkillTemplateId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
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
		*(short*)num = CombatSkillTemplateId;
		byte* num2 = num + 2;
		*num2 = (AgreeToRequest ? ((byte)1) : ((byte)0));
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
			CombatSkillTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
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
