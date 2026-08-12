using Config;
using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.StudyDemand;

public class RequestLifeSkillDemandAction : IGeneralAction
{
	public short BookTemplateId;

	public byte PageId;

	public bool AgreeToRequest;

	public bool Succeed;

	public sbyte ActionEnergyType => 2;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return selfChar.FindLearnedLifeSkillIndex(Config.SkillBook.Instance[BookTemplateId].LifeSkillTemplateId) < 0;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = selfChar.GetLocation();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		monthlyEventCollection.AddRequestInstructionOnLifeSkill(selfCharId, location, targetCharId, 10, BookTemplateId, PageId + 1);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		SkillBookItem bookCfg = Config.SkillBook.Instance[BookTemplateId];
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		if (AgreeToRequest)
		{
			if (Succeed)
			{
				int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
				if (selfCharId == taiwuCharId)
				{
					ItemKey itemKey = DomainManager.Item.CreateDemandedSkillBook(context, BookTemplateId, PageId, 0);
					selfChar.AddInventoryItem(context, itemKey, 1);
					ProfessionFormulaItem seniorityFormula = ProfessionFormula.Instance[102];
					int addSeniority = seniorityFormula.Calculate(LifeSkill.Instance[bookCfg.LifeSkillTemplateId].Grade);
					DomainManager.Extra.ChangeProfessionSeniority(context, 16, addSeniority);
				}
				else if (targetCharId == taiwuCharId)
				{
					ProfessionFormulaItem seniorityFormula2 = ProfessionFormula.Instance[105];
					int addSeniority2 = seniorityFormula2.Calculate(LifeSkill.Instance[bookCfg.LifeSkillTemplateId].Grade);
					DomainManager.Extra.ChangeProfessionSeniority(context, 16, addSeniority2);
				}
				selfChar.LearnNewLifeSkill(context, bookCfg.LifeSkillTemplateId, (byte)(1 << (int)PageId));
				selfChar.ChangeHappiness(context, ItemTemplateHelper.GetBaseHappinessChange(10, BookTemplateId) / 2);
				DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, ItemTemplateHelper.GetBaseFavorabilityChange(10, BookTemplateId));
				lifeRecordCollection.AddRequestInstructionOnLifeSkillSucceed(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			}
			else
			{
				lifeRecordCollection.AddRequestInstructionOnLifeSkillFailToLearn(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			}
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddInstructOnLifeSkill(targetCharId, selfCharId, bookCfg.LifeSkillTemplateId);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			secretInfoOffset = secretInformationCollection.AddAcceptRequestInstructionOnLifeSkill(targetCharId, selfCharId, bookCfg.LifeSkillTemplateId);
			secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			selfChar.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, -3000);
			lifeRecordCollection.AddRequestInstructionOnLifeSkillFail(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset2 = secretInformationCollection2.AddRefuseRequestInstructionOnLifeSkill(targetCharId, selfCharId, bookCfg.LifeSkillTemplateId);
			SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}
}
