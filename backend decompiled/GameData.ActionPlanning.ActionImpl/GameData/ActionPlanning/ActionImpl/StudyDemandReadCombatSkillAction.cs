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
public class StudyDemandReadCombatSkillAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort BookItemKey = 0;

		public const ushort InternalIndex = 1;

		public const ushort AgreeToRequest = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "BookItemKey", "InternalIndex", "AgreeToRequest" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey BookItemKey;

	[SerializableGameDataField(FieldIndex = 1)]
	public byte InternalIndex;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool AgreeToRequest;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		GameData.Domains.Item.SkillBook book = DomainManager.Item.GetElement_SkillBooks(args.ItemId);
		short combatSkillTemplateId = book.GetCombatSkillTemplateId();
		byte needHelpPage = character.GetCombatSkillBookCurrReadingInfo(book).readingPage;
		if (needHelpPage >= 6)
		{
			return false;
		}
		byte bookPageTypes = book.GetPageTypes();
		sbyte bookBehaviorType = SkillBookStateHelper.GetOutlinePageType(bookPageTypes);
		sbyte pageType = ((needHelpPage == 0) ? bookBehaviorType : SkillBookStateHelper.GetNormalPageType(bookPageTypes, needHelpPage));
		byte pageInternalIndex = CombatSkillStateHelper.GetPageInternalIndex(bookBehaviorType, pageType, needHelpPage);
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(targetChar.GetId(), combatSkillTemplateId), out var combatSkill))
		{
			return false;
		}
		return CombatSkillStateHelper.IsPageRead(combatSkill.GetReadingState(), pageInternalIndex);
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		if (!DomainManager.Item.TryGetElement_SkillBooks(argGroup.ItemId, out var book))
		{
			return false;
		}
		byte needHelpPage = character.GetCombatSkillBookCurrReadingInfo(book).readingPage;
		if (needHelpPage >= 6)
		{
			return false;
		}
		byte bookPageTypes = book.GetPageTypes();
		sbyte bookBehaviorType = SkillBookStateHelper.GetOutlinePageType(bookPageTypes);
		sbyte pageType = ((needHelpPage == 0) ? bookBehaviorType : SkillBookStateHelper.GetNormalPageType(bookPageTypes, needHelpPage));
		byte pageInternalIndex = CombatSkillStateHelper.GetPageInternalIndex(bookBehaviorType, pageType, needHelpPage);
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(favorabilityType: FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(actionData.TargetCharId, character.GetId())), targetBehaviorType: targetChar.GetBehaviorType());
		BookItemKey = book.GetItemKey();
		InternalIndex = pageInternalIndex;
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
		CombatSkillKey combatSkillKey = new CombatSkillKey(character.GetId(), Config.SkillBook.Instance[BookItemKey.TemplateId].CombatSkillTemplateId);
		if (DomainManager.CombatSkill.TryGetElement_CombatSkills(combatSkillKey, out var combatSkill))
		{
			return !CombatSkillStateHelper.IsPageRead(combatSkill.GetReadingState(), InternalIndex);
		}
		return true;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = character.GetLocation();
		DomainManager.World.GetMonthlyEventCollection().AddRequestInstructionOnReadingCombatSkill(selfCharId, location, targetCharId, (ulong)BookItemKey, CombatSkillStateHelper.GetPageId(InternalIndex) + 1, InternalIndex);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		short combatSkillTemplateId = Config.SkillBook.Instance[BookItemKey.TemplateId].CombatSkillTemplateId;
		byte pageId = CombatSkillStateHelper.GetPageId(InternalIndex);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (AgreeToRequest)
		{
			CombatSkillKey combatSkillKey = new CombatSkillKey(selfCharId, combatSkillTemplateId);
			if (!DomainManager.CombatSkill.TryGetElement_CombatSkills(combatSkillKey, out var combatSkill))
			{
				combatSkill = character.LearnNewCombatSkill(context, combatSkillTemplateId, 0);
			}
			ushort readingState = CombatSkillStateHelper.SetPageRead(combatSkill.GetReadingState(), InternalIndex);
			DomainManager.CombatSkill.SetCombatSkillReadingState(context, combatSkill, readingState);
			character.ChangeHappiness(context, DomainManager.Item.GetBaseItem(BookItemKey).GetHappinessChange() / 2);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, DomainManager.Item.GetBaseItem(BookItemKey).GetFavorabilityChange());
			lifeRecordCollection.AddRequestInstructionOnReadingSucceed(selfCharId, currDate, targetCharId, location, 10, BookItemKey.TemplateId, pageId + 1);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddAcceptRequestInstructionOnReading(targetCharId, selfCharId, (ulong)BookItemKey);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			character.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -3000);
			lifeRecordCollection.AddRequestInstructionOnReadingFail(selfCharId, currDate, targetCharId, location, 10, BookItemKey.TemplateId, pageId + 1);
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
		*pCurrData = InternalIndex;
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
			InternalIndex = *pCurrData;
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
