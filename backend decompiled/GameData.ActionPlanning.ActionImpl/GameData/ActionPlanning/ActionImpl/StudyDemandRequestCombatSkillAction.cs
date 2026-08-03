using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class StudyDemandRequestCombatSkillAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort BookTemplateId = 0;

		public const ushort InternalIndex = 1;

		public const ushort GeneratedPageTypes = 2;

		public const ushort AgreeToRequest = 3;

		public const ushort Succeed = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "BookTemplateId", "InternalIndex", "GeneratedPageTypes", "AgreeToRequest", "Succeed" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short BookTemplateId;

	[SerializableGameDataField(FieldIndex = 1)]
	public byte InternalIndex;

	[SerializableGameDataField(FieldIndex = 2)]
	public byte GeneratedPageTypes;

	[SerializableGameDataField(FieldIndex = 3)]
	public bool AgreeToRequest;

	[SerializableGameDataField(FieldIndex = 4)]
	public bool Succeed;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		return character.CanLearnCombatSkillFrom(targetChar, args.CombatSkillType);
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		sbyte mainAttributeType = AiHelper.DemandActionType.ToMainAttributeType(0, isSkill: true);
		if (mainAttributeType >= 0 && character.GetCurrMainAttribute(mainAttributeType) < GlobalConfig.Instance.HarmfulActionCost)
		{
			return false;
		}
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(actionData.TargetCharId, character.GetId()));
		(short skillId, byte internalIndex, byte pageTypes) tuple = character.CalcCombatSkillToLearnFromCharacter(context, actionData.TargetChar, argGroup.CombatSkillType);
		short skillTemplateId = tuple.skillId;
		byte currInternalIndex = tuple.internalIndex;
		byte pageTypes = tuple.pageTypes;
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillTemplateId];
		short bookTemplateId = skillConfig.BookId;
		int respondChance = AiHelper.GeneralActionConstants.GetAskToTeachSkillRespondChance(character, targetChar, favorabilityType, skillConfig.Grade);
		bool agreeToRequest = context.Random.CheckPercentProb(respondChance);
		bool succeed = false;
		if (agreeToRequest)
		{
			short qualification = character.GetCombatSkillQualification(skillConfig.Type);
			short attainment = character.GetCombatSkillAttainment(skillConfig.Type);
			sbyte personality = character.GetPersonality(1);
			int successRate = GameData.Domains.Character.Character.GetTaughtNewSkillSuccessRate(skillConfig.Grade, qualification, attainment, personality);
			succeed = context.Random.CheckPercentProb(successRate);
		}
		BookTemplateId = bookTemplateId;
		InternalIndex = currInternalIndex;
		GeneratedPageTypes = pageTypes;
		AgreeToRequest = agreeToRequest;
		Succeed = succeed;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return !character.GetLearnedCombatSkills().Contains(Config.SkillBook.Instance[BookTemplateId].CombatSkillTemplateId);
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = character.GetId();
		Location location = targetChar.GetLocation();
		monthlyEventCollection.AddRequestInstructionOnCombatSkill(selfCharId, location, targetChar.GetId(), 10, BookTemplateId, CombatSkillStateHelper.GetPageId(InternalIndex) + 1, InternalIndex, GeneratedPageTypes);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		SkillBookItem bookCfg = Config.SkillBook.Instance[BookTemplateId];
		short combatSkillTemplateId = bookCfg.CombatSkillTemplateId;
		byte pageId = CombatSkillStateHelper.GetPageId(InternalIndex);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (AgreeToRequest)
		{
			if (Succeed)
			{
				int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
				if (selfCharId == taiwuCharId)
				{
					ItemKey itemKey = DomainManager.Item.CreateDemandedSkillBook(context, BookTemplateId, InternalIndex, GeneratedPageTypes);
					character.AddInventoryItem(context, itemKey, 1);
					int addSeniority = ProfessionFormula.Instance[51].Calculate(Config.CombatSkill.Instance[combatSkillTemplateId].Grade);
					DomainManager.Extra.ChangeProfessionSeniority(context, 7, addSeniority);
				}
				else if (targetCharId == taiwuCharId)
				{
					int addSeniority2 = ProfessionFormula.Instance[54].Calculate(Config.CombatSkill.Instance[combatSkillTemplateId].Grade);
					DomainManager.Extra.ChangeProfessionSeniority(context, 7, addSeniority2);
				}
				character.LearnNewCombatSkill(context, combatSkillTemplateId, (ushort)(1 << (int)InternalIndex));
				character.ChangeHappiness(context, ItemTemplateHelper.GetBaseHappinessChange(10, BookTemplateId) / 2);
				DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, ItemTemplateHelper.GetBaseFavorabilityChange(10, BookTemplateId));
				lifeRecordCollection.AddRequestInstructionOnCombatSkillSucceed(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			}
			else
			{
				lifeRecordCollection.AddRequestInstructionOnCombatSkillFailToLearn(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			}
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddInstructOnCombatSkill(targetCharId, selfCharId, bookCfg.CombatSkillTemplateId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			secretInfoOffset = secretInformationCollection.AddAcceptRequestInstructionOnCombatSkill(targetCharId, selfCharId, bookCfg.CombatSkillTemplateId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			character.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -3000);
			lifeRecordCollection.AddRequestInstructionOnCombatSkillFail(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestInstructionOnCombatSkill(targetCharId, selfCharId, bookCfg.CombatSkillTemplateId);
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
		*(short*)pData = 5;
		byte* num = pData + 2;
		*(short*)num = BookTemplateId;
		byte* num2 = num + 2;
		*num2 = InternalIndex;
		byte* num3 = num2 + 1;
		*num3 = GeneratedPageTypes;
		byte* num4 = num3 + 1;
		*num4 = (AgreeToRequest ? ((byte)1) : ((byte)0));
		byte* num5 = num4 + 1;
		*num5 = (Succeed ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num5 + 1 - pData);
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
			BookTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			InternalIndex = *pCurrData;
			pCurrData++;
		}
		if (num > 2)
		{
			GeneratedPageTypes = *pCurrData;
			pCurrData++;
		}
		if (num > 3)
		{
			AgreeToRequest = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 4)
		{
			Succeed = *pCurrData != 0;
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
