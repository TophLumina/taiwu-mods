using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Taiwu.Profession;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class StudyDemandRequestLifeSkillAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort BookTemplateId = 0;

		public const ushort PageId = 1;

		public const ushort AgreeToRequest = 2;

		public const ushort Succeed = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "BookTemplateId", "PageId", "AgreeToRequest", "Succeed" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short BookTemplateId;

	[SerializableGameDataField(FieldIndex = 1)]
	public byte PageId;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool AgreeToRequest;

	[SerializableGameDataField(FieldIndex = 3)]
	public bool Succeed;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		return character.CanLearnLifeSkillFrom(targetChar, args.LifeSkillType);
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		sbyte lifeSkillType = argGroup.LifeSkillType;
		sbyte mainAttributeType = AiHelper.DemandActionType.ToMainAttributeType(0, isSkill: true);
		if (mainAttributeType >= 0 && character.GetCurrMainAttribute(mainAttributeType) < GlobalConfig.Instance.HarmfulActionCost)
		{
			return false;
		}
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(actionData.TargetCharId, character.GetId()));
		(short skillId, byte pageId) tuple = character.CalcLifeSkillToLearnFromCharacter(context, targetChar, lifeSkillType);
		short lifeSkillTemplateId = tuple.skillId;
		byte pageId = tuple.pageId;
		short bookTemplateId = LifeSkill.Instance[lifeSkillTemplateId].SkillBookId;
		sbyte grade = LifeSkill.Instance[lifeSkillTemplateId].Grade;
		int respondChance = AiHelper.GeneralActionConstants.GetAskToTeachSkillRespondChance(character, targetChar, favorabilityType, grade);
		bool agreeToRequest = context.Random.CheckPercentProb(respondChance);
		bool succeed = false;
		if (agreeToRequest)
		{
			short attainment = character.GetLifeSkillAttainment(lifeSkillType);
			short qualification = character.GetLifeSkillQualification(lifeSkillType);
			sbyte personality = character.GetPersonality(1);
			int successRate = GameData.Domains.Character.Character.GetTaughtNewSkillSuccessRate(grade, qualification, attainment, personality);
			succeed = context.Random.CheckPercentProb(successRate);
		}
		BookTemplateId = bookTemplateId;
		PageId = pageId;
		AgreeToRequest = agreeToRequest;
		Succeed = succeed;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return character.FindLearnedLifeSkillIndex(Config.SkillBook.Instance[BookTemplateId].LifeSkillTemplateId) < 0;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = character.GetLocation();
		DomainManager.World.GetMonthlyEventCollection().AddRequestInstructionOnLifeSkill(selfCharId, location, targetCharId, 10, BookTemplateId, PageId + 1);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		SkillBookItem bookCfg = Config.SkillBook.Instance[BookTemplateId];
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
					ItemKey itemKey = DomainManager.Item.CreateDemandedSkillBook(context, BookTemplateId, PageId, 0);
					character.AddInventoryItem(context, itemKey, 1);
					int addSeniority = ProfessionFormula.Instance[102].Calculate(LifeSkill.Instance[bookCfg.LifeSkillTemplateId].Grade);
					DomainManager.Extra.ChangeProfessionSeniority(context, 16, addSeniority);
				}
				else if (targetCharId == taiwuCharId)
				{
					int addSeniority2 = ProfessionFormula.Instance[105].Calculate(LifeSkill.Instance[bookCfg.LifeSkillTemplateId].Grade);
					DomainManager.Extra.ChangeProfessionSeniority(context, 16, addSeniority2);
				}
				character.LearnNewLifeSkill(context, bookCfg.LifeSkillTemplateId, (byte)(1 << (int)PageId));
				character.ChangeHappiness(context, ItemTemplateHelper.GetBaseHappinessChange(10, BookTemplateId) / 2);
				DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, ItemTemplateHelper.GetBaseFavorabilityChange(10, BookTemplateId));
				lifeRecordCollection.AddRequestInstructionOnLifeSkillSucceed(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			}
			else
			{
				lifeRecordCollection.AddRequestInstructionOnLifeSkillFailToLearn(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			}
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddInstructOnLifeSkill(targetCharId, selfCharId, bookCfg.LifeSkillTemplateId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			secretInfoOffset = secretInformationCollection.AddAcceptRequestInstructionOnLifeSkill(targetCharId, selfCharId, bookCfg.LifeSkillTemplateId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			character.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -3000);
			lifeRecordCollection.AddRequestInstructionOnLifeSkillFail(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestInstructionOnLifeSkill(targetCharId, selfCharId, bookCfg.LifeSkillTemplateId);
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
		*(short*)pData = 4;
		byte* num = pData + 2;
		*(short*)num = BookTemplateId;
		byte* num2 = num + 2;
		*num2 = PageId;
		byte* num3 = num2 + 1;
		*num3 = (AgreeToRequest ? ((byte)1) : ((byte)0));
		byte* num4 = num3 + 1;
		*num4 = (Succeed ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num4 + 1 - pData);
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
			PageId = *pCurrData;
			pCurrData++;
		}
		if (num > 2)
		{
			AgreeToRequest = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 3)
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
