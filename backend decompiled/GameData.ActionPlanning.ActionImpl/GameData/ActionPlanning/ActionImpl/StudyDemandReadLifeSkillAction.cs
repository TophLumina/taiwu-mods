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
public class StudyDemandReadLifeSkillAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort BookItemKey = 0;

		public const ushort PageId = 1;

		public const ushort AgreeToRequest = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "BookItemKey", "PageId", "AgreeToRequest" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey BookItemKey;

	[SerializableGameDataField(FieldIndex = 1)]
	public byte PageId;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool AgreeToRequest;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		GameData.Domains.Item.SkillBook book = DomainManager.Item.GetElement_SkillBooks(args.ItemId);
		short lifeSkillTemplateId = book.GetLifeSkillTemplateId();
		byte needHelpPage = character.GetLifeSkillBookCurrReadingInfo(book).readingPage;
		if (needHelpPage >= 5)
		{
			return false;
		}
		int index = targetChar.FindLearnedLifeSkillIndex(lifeSkillTemplateId);
		if (index >= 0)
		{
			return targetChar.GetLearnedLifeSkills()[index].IsPageRead(needHelpPage);
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		if (!DomainManager.Item.TryGetElement_SkillBooks(argGroup.ItemId, out var book))
		{
			return false;
		}
		book.GetLifeSkillTemplateId();
		byte needHelpPage = character.GetLifeSkillBookCurrReadingInfo(book).readingPage;
		if (needHelpPage >= 5)
		{
			return false;
		}
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetChar.GetId(), character.GetId()));
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(targetChar.GetBehaviorType(), favorabilityType);
		BookItemKey = book.GetItemKey();
		PageId = needHelpPage;
		AgreeToRequest = context.Random.CheckPercentProb(respondChance);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		bool hasItem = false;
		if (character.GetOrganizationInfo().OrgTemplateId == 16)
		{
			short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
			hasItem = DomainManager.Organization.GetSettlement(settlementId).GetTreasury(character.GetOrganizationInfo().Grade).Inventory.Items.ContainsKey(BookItemKey);
		}
		if (!hasItem)
		{
			hasItem = character.GetInventory().Items.ContainsKey(BookItemKey);
		}
		if (!hasItem)
		{
			return false;
		}
		int lifeSkillIndex = character.FindLearnedLifeSkillIndex(BookItemKey.TemplateId);
		List<GameData.Domains.Character.LifeSkillItem> learnedLifeSkills = character.GetLearnedLifeSkills();
		if (lifeSkillIndex >= 0)
		{
			return !learnedLifeSkills[lifeSkillIndex].IsPageRead(PageId);
		}
		return true;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = character.GetLocation();
		DomainManager.World.GetMonthlyEventCollection().AddRequestInstructionOnReadingLifeSkill(selfCharId, location, targetCharId, (ulong)BookItemKey, PageId + 1);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (AgreeToRequest)
		{
			SkillBookItem bookCfg = Config.SkillBook.Instance[BookItemKey.TemplateId];
			character.GetLearnedLifeSkills();
			int index = character.FindLearnedLifeSkillIndex(bookCfg.LifeSkillTemplateId);
			if (index < 0)
			{
				character.LearnNewLifeSkill(context, bookCfg.LifeSkillTemplateId, (byte)(1 << (int)PageId));
			}
			else
			{
				character.ReadLifeSkillPage(context, index, PageId);
			}
			character.ChangeHappiness(context, DomainManager.Item.GetBaseItem(BookItemKey).GetHappinessChange() / 2);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, DomainManager.Item.GetBaseItem(BookItemKey).GetFavorabilityChange());
			lifeRecordCollection.AddRequestInstructionOnReadingSucceed(selfCharId, currDate, targetCharId, location, 10, BookItemKey.TemplateId, PageId + 1);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddAcceptRequestInstructionOnReading(targetCharId, selfCharId, (ulong)BookItemKey);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			character.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -3000);
			lifeRecordCollection.AddRequestInstructionOnReadingFail(selfCharId, currDate, targetCharId, location, 10, BookItemKey.TemplateId, PageId + 1);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestInstructionOnReading(targetCharId, selfCharId, (ulong)BookItemKey);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize += BookItemKey.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		int fieldSize = BookItemKey.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*pCurrData = PageId;
		pCurrData++;
		*pCurrData = (AgreeToRequest ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
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
			pCurrData += BookItemKey.Deserialize(pCurrData);
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
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
