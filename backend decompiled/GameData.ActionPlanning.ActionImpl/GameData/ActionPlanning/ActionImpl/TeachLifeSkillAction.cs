using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class TeachLifeSkillAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort SkillTemplateId = 0;

		public const ushort PageId = 1;

		public const ushort Succeed = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "SkillTemplateId", "PageId", "Succeed" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short SkillTemplateId;

	[SerializableGameDataField(FieldIndex = 1)]
	public byte PageId;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool Succeed;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		return character.CanTeachLifeSkill(targetChar);
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		List<(short, short)> weightTable = context.AdvanceMonthRelatedData.WeightTable.Occupy();
		character.GetTeachableLifeSkillBookIds(targetChar, weightTable);
		if (weightTable.Count <= 0)
		{
			return false;
		}
		short skillBookTemplateId = RandomUtils.GetRandomResult(weightTable, context.Random);
		context.AdvanceMonthRelatedData.WeightTable.Release(ref weightTable);
		SkillBookItem bookCfg = Config.SkillBook.Instance[skillBookTemplateId];
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetChar.GetId(), selfCharId));
		int teachChance = AiHelper.GeneralActionConstants.GetAskToTeachSkillRespondChance(targetChar, character, favorabilityType, bookCfg.Grade);
		if (!context.Random.CheckPercentProb(teachChance))
		{
			return false;
		}
		int selectedIndex = character.FindLearnedLifeSkillIndex(bookCfg.LifeSkillTemplateId);
		GameData.Domains.Character.LifeSkillItem learnedLifeSkill = character.GetLearnedLifeSkills()[selectedIndex];
		byte pageId = 0;
		while (pageId < 5 && !learnedLifeSkill.IsPageRead(pageId))
		{
			pageId++;
		}
		LifeSkillShorts lifeSkillAttainments = targetChar.GetLifeSkillAttainments();
		LifeSkillShorts lifeSkillQualifications = targetChar.GetLifeSkillQualifications();
		Personalities personalities = targetChar.GetPersonalities();
		int successRate = GameData.Domains.Character.Character.GetTaughtNewSkillSuccessRate(bookCfg.Grade, lifeSkillQualifications[bookCfg.LifeSkillType], lifeSkillAttainments[bookCfg.LifeSkillType], personalities[1]);
		SkillTemplateId = bookCfg.LifeSkillTemplateId;
		PageId = pageId;
		Succeed = context.Random.CheckPercentProb(successRate);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return actionData.TargetChar.FindLearnedLifeSkillIndex(SkillTemplateId) < 0;
	}

	public void PreExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = actionData.TargetCharId;
		Location location = selfChar.GetLocation();
		if (Succeed)
		{
			DomainManager.World.GetMonthlyNotificationCollection().AddTeachLifeSkillSuccess(selfCharId, location, targetCharId, SkillTemplateId);
		}
		else
		{
			DomainManager.World.GetMonthlyNotificationCollection().AddTeachLifeSkillFailure(selfCharId, location, targetCharId, SkillTemplateId);
		}
		PostExecute(context, selfChar, actionData);
	}

	public void PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location location = character.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int targetCharId = targetChar.GetId();
		int selfCharId = character.GetId();
		short bookId = LifeSkill.Instance[SkillTemplateId].SkillBookId;
		_ = Config.SkillBook.Instance[bookId];
		if (Succeed)
		{
			lifeRecordCollection.AddLearnLifeSkillWithInstructionSucceed(targetCharId, currDate, selfCharId, location, 10, bookId, PageId + 1);
			if (targetCharId == DomainManager.Taiwu.GetTaiwuCharId())
			{
				ItemKey itemKey = DomainManager.Item.CreateDemandedSkillBook(context, bookId, PageId, 0);
				targetChar.AddInventoryItem(context, itemKey, 1);
			}
			targetChar.LearnNewLifeSkill(context, SkillTemplateId, (byte)(1 << (int)PageId));
			targetChar.ChangeHappiness(context, ItemTemplateHelper.GetBaseHappinessChange(10, SkillTemplateId));
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, character, ItemTemplateHelper.GetBaseFavorabilityChange(10, SkillTemplateId));
		}
		else
		{
			lifeRecordCollection.AddLearnLifeSkillWithInstructionFail(targetCharId, currDate, selfCharId, location, 10, bookId, PageId + 1);
		}
		int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddInstructOnLifeSkill(selfCharId, targetCharId, SkillTemplateId);
		DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
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
		*(short*)num = SkillTemplateId;
		byte* num2 = num + 2;
		*num2 = PageId;
		byte* num3 = num2 + 1;
		*num3 = (Succeed ? ((byte)1) : ((byte)0));
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
			SkillTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			PageId = *pCurrData;
			pCurrData++;
		}
		if (num > 2)
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
