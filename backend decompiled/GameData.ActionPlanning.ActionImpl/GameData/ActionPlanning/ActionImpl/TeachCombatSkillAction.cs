using System.Collections.Generic;
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
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class TeachCombatSkillAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort SkillTemplateId = 0;

		public const ushort InternalIndex = 1;

		public const ushort GeneratedPageTypes = 2;

		public const ushort Succeed = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "SkillTemplateId", "InternalIndex", "GeneratedPageTypes", "Succeed" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short SkillTemplateId;

	[SerializableGameDataField(FieldIndex = 1)]
	public byte InternalIndex;

	[SerializableGameDataField(FieldIndex = 2)]
	public byte GeneratedPageTypes;

	[SerializableGameDataField(FieldIndex = 3)]
	public bool Succeed;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		return character.CanTeachCombatSkill(targetChar);
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		List<(short, short)> weightTable = context.AdvanceMonthRelatedData.WeightTable.Occupy();
		character.GetTeachableCombatSkillBookIds(targetChar, weightTable);
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
		ushort readingState = DomainManager.CombatSkill.GetCharCombatSkills(selfCharId)[bookCfg.CombatSkillTemplateId].GetReadingState();
		byte currInternalIndex = 0;
		while (currInternalIndex < 15 && !CombatSkillStateHelper.IsPageRead(readingState, currInternalIndex))
		{
			currInternalIndex++;
		}
		CombatSkillShorts combatSkillAttainments = targetChar.GetCombatSkillAttainments();
		CombatSkillShorts combatSkillQualifications = targetChar.GetCombatSkillQualifications();
		Personalities personalities = targetChar.GetPersonalities();
		int successRate = GameData.Domains.Character.Character.GetTaughtNewSkillSuccessRate(bookCfg.Grade, combatSkillQualifications[bookCfg.CombatSkillType], combatSkillAttainments[bookCfg.CombatSkillType], personalities[1]);
		SkillTemplateId = bookCfg.CombatSkillTemplateId;
		InternalIndex = currInternalIndex;
		GeneratedPageTypes = CombatSkillStateHelper.GeneratePageTypesFromReadingState(context.Random, readingState);
		Succeed = context.Random.CheckPercentProb(successRate);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return !actionData.TargetChar.GetLearnedCombatSkills().Contains(SkillTemplateId);
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		if (DomainManager.Taiwu.IsTaiwuAbleToGetTaught(character))
		{
			DomainManager.World.GetMonthlyEventCollection().AddTeachCombatSkill(character.GetId(), character.GetLocation(), actionData.TargetCharId, SkillTemplateId);
		}
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location location = character.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		int targetCharId = actionData.TargetCharId;
		int selfCharId = character.GetId();
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		short bookId = Config.CombatSkill.Instance[SkillTemplateId].BookId;
		SkillBookItem bookCfg = Config.SkillBook.Instance[bookId];
		byte pageId = CombatSkillStateHelper.GetPageId(InternalIndex);
		if (Succeed)
		{
			lifeRecordCollection.AddLearnCombatSkillWithInstructionSucceed(targetCharId, currDate, selfCharId, location, 10, bookId, pageId + 1);
			if (targetCharId == DomainManager.Taiwu.GetTaiwuCharId())
			{
				ItemKey itemKey = DomainManager.Item.CreateDemandedSkillBook(context, bookId, InternalIndex, GeneratedPageTypes);
				targetChar.AddInventoryItem(context, itemKey, 1);
			}
			targetChar.LearnNewCombatSkill(context, SkillTemplateId, (ushort)(1 << (int)InternalIndex));
			targetChar.ChangeHappiness(context, bookCfg.BaseHappinessChange);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, character, bookCfg.BaseFavorabilityChange);
		}
		else
		{
			lifeRecordCollection.AddLearnCombatSkillWithInstructionFail(targetCharId, currDate, selfCharId, location, 10, bookId, pageId + 1);
		}
		int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddInstructOnCombatSkill(selfCharId, targetCharId, SkillTemplateId);
		DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
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
		*(short*)num = SkillTemplateId;
		byte* num2 = num + 2;
		*num2 = InternalIndex;
		byte* num3 = num2 + 1;
		*num3 = GeneratedPageTypes;
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
			SkillTemplateId = *(short*)pCurrData;
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
