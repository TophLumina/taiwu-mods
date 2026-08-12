using Config;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.StudyDemand;

public class CombatSkillReadingDemandAction : IGeneralAction
{
	public ItemKey BookItemKey;

	public byte InternalIndex;

	public bool AgreeToRequest;

	public sbyte ActionEnergyType => 2;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		bool hasItem = false;
		if (selfChar.GetOrganizationInfo().OrgTemplateId == 16)
		{
			hasItem = DomainManager.Taiwu.GetTaiwuTreasury().Inventory.Items.ContainsKey(BookItemKey);
		}
		if (!hasItem)
		{
			hasItem = selfChar.GetInventory().Items.ContainsKey(BookItemKey);
		}
		if (!hasItem)
		{
			return false;
		}
		CombatSkillKey combatSkillKey = new CombatSkillKey(selfChar.GetId(), Config.SkillBook.Instance[BookItemKey.TemplateId].CombatSkillTemplateId);
		GameData.Domains.CombatSkill.CombatSkill combatSkill;
		return !DomainManager.CombatSkill.TryGetElement_CombatSkills(combatSkillKey, out combatSkill) || !CombatSkillStateHelper.IsPageRead(combatSkill.GetReadingState(), InternalIndex);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = selfChar.GetLocation();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		monthlyEventCollection.AddRequestInstructionOnReadingCombatSkill(selfCharId, location, targetCharId, (ulong)BookItemKey, CombatSkillStateHelper.GetPageId(InternalIndex) + 1, InternalIndex);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		SkillBookItem bookCfg = Config.SkillBook.Instance[BookItemKey.TemplateId];
		short combatSkillTemplateId = bookCfg.CombatSkillTemplateId;
		byte pageId = CombatSkillStateHelper.GetPageId(InternalIndex);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		if (AgreeToRequest)
		{
			CombatSkillKey combatSkillKey = new CombatSkillKey(selfCharId, combatSkillTemplateId);
			if (!DomainManager.CombatSkill.TryGetElement_CombatSkills(combatSkillKey, out var combatSkill))
			{
				combatSkill = selfChar.LearnNewCombatSkill(context, combatSkillTemplateId, 0);
			}
			ushort readingState = CombatSkillStateHelper.SetPageRead(combatSkill.GetReadingState(), InternalIndex);
			DomainManager.CombatSkill.SetCombatSkillReadingState(context, combatSkill, readingState);
			DomainManager.CombatSkill.TryActivateCombatSkillBookPageWhenSetReadingState(context, selfCharId, combatSkillTemplateId, InternalIndex);
			selfChar.ChangeHappiness(context, DomainManager.Item.GetBaseItem(BookItemKey).GetHappinessChange() / 2);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, DomainManager.Item.GetBaseItem(BookItemKey).GetFavorabilityChange());
			lifeRecordCollection.AddRequestInstructionOnReadingSucceed(selfCharId, currDate, targetCharId, location, 10, BookItemKey.TemplateId, pageId + 1);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestInstructionOnReading(targetCharId, selfCharId, (ulong)BookItemKey);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			selfChar.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, -3000);
			lifeRecordCollection.AddRequestInstructionOnReadingFail(selfCharId, currDate, targetCharId, location, 10, BookItemKey.TemplateId, pageId + 1);
			SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset2 = secretInformationCollection2.AddRefuseRequestInstructionOnReading(targetCharId, selfCharId, (ulong)BookItemKey);
			SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}
}
