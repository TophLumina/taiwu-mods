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

public class BreakingDemandAction : IGeneralAction
{
	public short CombatSkillTemplateId;

	public bool AgreeToRequest;

	public sbyte ActionEnergyType => 2;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		GameData.Domains.CombatSkill.CombatSkill combatSkill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(selfChar.GetId(), CombatSkillTemplateId));
		return !CombatSkillStateHelper.IsBrokenOut(combatSkill.GetActivationState()) && combatSkill.CanBreakout();
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = selfChar.GetId();
		Location location = targetChar.GetLocation();
		monthlyEventCollection.AddRequestInstructionOnBreakout(selfCharId, location, targetChar.GetId(), CombatSkillTemplateId);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		CombatSkillItem combatSkillCfg = Config.CombatSkill.Instance[CombatSkillTemplateId];
		if (combatSkillCfg.BookId >= 0)
		{
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			int currDate = DomainManager.World.GetCurrDate();
			Location location = selfChar.GetLocation();
			if (AgreeToRequest)
			{
				GameData.Domains.CombatSkill.CombatSkill combatSkill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(selfCharId, CombatSkillTemplateId));
				ushort readingState = combatSkill.GetReadingState();
				ushort activationState = CombatSkillStateHelper.GenerateRandomActivatedNormalPages(context.Random, readingState, 0);
				activationState = CombatSkillStateHelper.GenerateRandomActivatedOutlinePage(context.Random, readingState, activationState, selfChar.GetBehaviorType());
				sbyte availableStepsCount = selfChar.GetSkillBreakoutAvailableStepsCount(CombatSkillTemplateId);
				combatSkill.SetActivationState(activationState, context);
				combatSkill.SetBreakoutStepsCount(availableStepsCount, context);
				selfChar.ChangeHappiness(context, ItemTemplateHelper.GetBaseHappinessChange(10, combatSkillCfg.BookId) / 2);
				DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, ItemTemplateHelper.GetBaseFavorabilityChange(10, combatSkillCfg.BookId));
				lifeRecordCollection.AddRequestInstructionOnBreakoutSucceed(selfCharId, currDate, targetCharId, location, CombatSkillTemplateId);
				SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
				int secretInfoOffset = secretInformationCollection.AddAcceptRequestInstructionOnBreakout(targetCharId, selfCharId, CombatSkillTemplateId);
				SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			}
			else
			{
				selfChar.ChangeHappiness(context, -3);
				DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, -3000);
				lifeRecordCollection.AddRequestInstructionOnBreakoutFail(selfCharId, currDate, targetCharId, location, CombatSkillTemplateId);
				SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
				int secretInfoOffset2 = secretInformationCollection2.AddRefuseRequestInstructionOnBreakout(targetCharId, selfCharId, CombatSkillTemplateId);
				SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
			}
		}
	}
}
