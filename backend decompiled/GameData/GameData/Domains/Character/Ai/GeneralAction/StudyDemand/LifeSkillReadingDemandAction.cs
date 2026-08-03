using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.StudyDemand;

public class LifeSkillReadingDemandAction : IGeneralAction
{
	public ItemKey BookItemKey;

	public byte PageId;

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
		int lifeSkillIndex = selfChar.FindLearnedLifeSkillIndex(BookItemKey.TemplateId);
		List<LifeSkillItem> learnedLifeSkills = selfChar.GetLearnedLifeSkills();
		return lifeSkillIndex < 0 || !learnedLifeSkills[lifeSkillIndex].IsPageRead(PageId);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = selfChar.GetLocation();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		monthlyEventCollection.AddRequestInstructionOnReadingLifeSkill(selfCharId, location, targetCharId, (ulong)BookItemKey, PageId + 1);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		if (AgreeToRequest)
		{
			SkillBookItem bookCfg = Config.SkillBook.Instance[BookItemKey.TemplateId];
			List<LifeSkillItem> learnedLifeSkills = selfChar.GetLearnedLifeSkills();
			int index = selfChar.FindLearnedLifeSkillIndex(bookCfg.LifeSkillTemplateId);
			if (index < 0)
			{
				selfChar.LearnNewLifeSkill(context, bookCfg.LifeSkillTemplateId, (byte)(1 << (int)PageId));
			}
			else
			{
				selfChar.ReadLifeSkillPage(context, index, PageId);
			}
			selfChar.ChangeHappiness(context, DomainManager.Item.GetBaseItem(BookItemKey).GetHappinessChange() / 2);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, DomainManager.Item.GetBaseItem(BookItemKey).GetFavorabilityChange());
			lifeRecordCollection.AddRequestInstructionOnReadingSucceed(selfCharId, currDate, targetCharId, location, 10, BookItemKey.TemplateId, PageId + 1);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestInstructionOnReading(targetCharId, selfCharId, (ulong)BookItemKey);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			selfChar.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, -3000);
			lifeRecordCollection.AddRequestInstructionOnReadingFail(selfCharId, currDate, targetCharId, location, 10, BookItemKey.TemplateId, PageId + 1);
			SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset2 = secretInformationCollection2.AddRefuseRequestInstructionOnReading(targetCharId, selfCharId, (ulong)BookItemKey);
			SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}
}
