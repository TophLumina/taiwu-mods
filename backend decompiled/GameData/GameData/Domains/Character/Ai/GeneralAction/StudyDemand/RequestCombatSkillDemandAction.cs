using Config;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.StudyDemand;

public class RequestCombatSkillDemandAction : IGeneralAction
{
	public short BookTemplateId;

	public byte InternalIndex;

	public byte GeneratedPageTypes;

	public bool AgreeToRequest;

	public bool Succeed;

	public sbyte ActionEnergyType => 2;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return !selfChar.GetLearnedCombatSkills().Contains(Config.SkillBook.Instance[BookTemplateId].CombatSkillTemplateId);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = selfChar.GetId();
		Location location = targetChar.GetLocation();
		monthlyEventCollection.AddRequestInstructionOnCombatSkill(selfCharId, location, targetChar.GetId(), 10, BookTemplateId, CombatSkillStateHelper.GetPageId(InternalIndex) + 1, InternalIndex, GeneratedPageTypes);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		SkillBookItem bookCfg = Config.SkillBook.Instance[BookTemplateId];
		short combatSkillTemplateId = bookCfg.CombatSkillTemplateId;
		byte pageId = CombatSkillStateHelper.GetPageId(InternalIndex);
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
					ItemKey itemKey = DomainManager.Item.CreateDemandedSkillBook(context, BookTemplateId, InternalIndex, GeneratedPageTypes);
					selfChar.AddInventoryItem(context, itemKey, 1);
					ProfessionFormulaItem seniorityFormula = ProfessionFormula.Instance[51];
					int addSeniority = seniorityFormula.Calculate(Config.CombatSkill.Instance[combatSkillTemplateId].Grade);
					DomainManager.Extra.ChangeProfessionSeniority(context, 7, addSeniority);
				}
				else if (targetCharId == taiwuCharId)
				{
					ProfessionFormulaItem seniorityFormula2 = ProfessionFormula.Instance[54];
					int addSeniority2 = seniorityFormula2.Calculate(Config.CombatSkill.Instance[combatSkillTemplateId].Grade);
					DomainManager.Extra.ChangeProfessionSeniority(context, 7, addSeniority2);
				}
				selfChar.LearnNewCombatSkill(context, combatSkillTemplateId, (ushort)(1 << (int)InternalIndex));
				selfChar.ChangeHappiness(context, ItemTemplateHelper.GetBaseHappinessChange(10, BookTemplateId) / 2);
				DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, ItemTemplateHelper.GetBaseFavorabilityChange(10, BookTemplateId));
				lifeRecordCollection.AddRequestInstructionOnCombatSkillSucceed(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			}
			else
			{
				lifeRecordCollection.AddRequestInstructionOnCombatSkillFailToLearn(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			}
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddInstructOnCombatSkill(targetCharId, selfCharId, bookCfg.CombatSkillTemplateId);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			secretInfoOffset = secretInformationCollection.AddAcceptRequestInstructionOnCombatSkill(targetCharId, selfCharId, bookCfg.CombatSkillTemplateId);
			secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			selfChar.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, -3000);
			lifeRecordCollection.AddRequestInstructionOnCombatSkillFail(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset2 = secretInformationCollection2.AddRefuseRequestInstructionOnCombatSkill(targetCharId, selfCharId, bookCfg.CombatSkillTemplateId);
			SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}
}
