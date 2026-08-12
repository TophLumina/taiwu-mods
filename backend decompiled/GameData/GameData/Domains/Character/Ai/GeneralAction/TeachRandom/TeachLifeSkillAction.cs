using Config;
using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;

namespace GameData.Domains.Character.Ai.GeneralAction.TeachRandom;

public class TeachLifeSkillAction : IGeneralAction
{
	public short SkillTemplateId;

	public byte PageId;

	public bool Succeed;

	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return targetChar.FindLearnedLifeSkillIndex(SkillTemplateId) < 0;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = selfChar.GetLocation();
		if (Succeed)
		{
			DomainManager.World.GetMonthlyNotificationCollection().AddTeachLifeSkillSuccess(selfCharId, location, targetCharId, SkillTemplateId);
		}
		else
		{
			DomainManager.World.GetMonthlyNotificationCollection().AddTeachLifeSkillFailure(selfCharId, location, targetCharId, SkillTemplateId);
		}
		ApplyChanges(context, selfChar, targetChar);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location location = selfChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		int targetCharId = targetChar.GetId();
		int selfCharId = selfChar.GetId();
		short bookId = LifeSkill.Instance[SkillTemplateId].SkillBookId;
		SkillBookItem bookCfg = Config.SkillBook.Instance[bookId];
		if (Succeed)
		{
			lifeRecordCollection.AddLearnLifeSkillWithInstructionSucceed(targetCharId, currDate, selfCharId, location, 10, bookId, PageId + 1);
			if (targetCharId == DomainManager.Taiwu.GetTaiwuCharId())
			{
				ItemKey itemKey = DomainManager.Item.CreateDemandedSkillBook(context, bookId, PageId, 0);
				targetChar.AddInventoryItem(context, itemKey, 1);
			}
			LifeSkillItem lifeSkillItem = targetChar.LearnNewLifeSkill(context, SkillTemplateId, (byte)(1 << (int)PageId));
			targetChar.ChangeHappiness(context, ItemTemplateHelper.GetBaseHappinessChange(10, SkillTemplateId));
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, selfChar, ItemTemplateHelper.GetBaseFavorabilityChange(10, SkillTemplateId));
		}
		else
		{
			lifeRecordCollection.AddLearnLifeSkillWithInstructionFail(targetCharId, currDate, selfCharId, location, 10, bookId, PageId + 1);
		}
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		int secretInfoOffset = secretInformationCollection.AddInstructOnLifeSkill(selfCharId, targetCharId, SkillTemplateId);
		SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
	}
}
