using Config;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;

namespace GameData.Domains.Character.Ai.GeneralAction.StudyDemand;

public class StealCombatSkillDemandAction : IGeneralAction
{
	public short BookTemplateId;

	public byte InternalIndex;

	public byte GeneratedPageTypes;

	public sbyte Phase;

	public sbyte ActionEnergyType => 2;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return !selfChar.GetLearnedCombatSkills().Contains(Config.SkillBook.Instance[BookTemplateId].CombatSkillTemplateId);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = targetChar.GetLocation();
		SkillBookItem bookCfg = Config.SkillBook.Instance[BookTemplateId];
		short combatSkillTemplateId = bookCfg.CombatSkillTemplateId;
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		if (Phase <= 3)
		{
			monthlyNotificationCollection.AddStealCombatSkillFailure(selfCharId, location, targetCharId, combatSkillTemplateId);
			ApplyChanges(context, selfChar, targetChar);
			return;
		}
		monthlyNotificationCollection.AddStealCombatSkillSuccess(selfCharId, location, targetCharId, combatSkillTemplateId);
		if (Phase == 4)
		{
			monthlyEventCollection.AddStealCombatSkillButBeCaught(selfCharId, location, targetCharId, 10, BookTemplateId, CombatSkillStateHelper.GetPageId(InternalIndex) + 1, InternalIndex, GeneratedPageTypes);
		}
		else
		{
			ApplyChanges(context, selfChar, targetChar);
		}
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		SkillBookItem bookCfg = Config.SkillBook.Instance[BookTemplateId];
		short combatSkillTemplateId = bookCfg.CombatSkillTemplateId;
		byte pageId = CombatSkillStateHelper.GetPageId(InternalIndex);
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (selfCharId != taiwuCharId)
		{
			selfChar.ChangeCurrMainAttribute(context, 5, -GlobalConfig.Instance.HarmfulActionCost);
		}
		if (Phase >= 4)
		{
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddStealCombatSkill(selfCharId, targetCharId, combatSkillTemplateId);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		sbyte phase = Phase;
		if (phase > 0 && phase < 5 && selfCharId == taiwuCharId)
		{
			EventHelper.ChangeAlertnessOnStealCombatSkill(targetCharId, bookCfg.Grade, bookCfg.TemplateId);
		}
		switch (Phase)
		{
		case 0:
			lifeRecordCollection.AddStealCombatSkillFail1(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			break;
		case 1:
			lifeRecordCollection.AddStealCombatSkillFail2(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			break;
		case 2:
			lifeRecordCollection.AddStealCombatSkillFail3(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			break;
		case 3:
			lifeRecordCollection.AddStealCombatSkillFail4(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			break;
		case 4:
			if (selfCharId == taiwuCharId)
			{
				ItemKey itemKey2 = DomainManager.Item.CreateDemandedSkillBook(context, BookTemplateId, InternalIndex, GeneratedPageTypes);
				selfChar.AddInventoryItem(context, itemKey2, 1);
			}
			selfChar.LearnNewCombatSkill(context, combatSkillTemplateId, (ushort)(1 << (int)InternalIndex));
			lifeRecordCollection.AddStealCombatSkillSucceed(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			if (targetCharId != taiwuCharId)
			{
				AiHelper.NpcCombatResultType combatResultType = DomainManager.Character.SimulateCharacterCombat(context, targetChar, selfChar, CombatType.Beat);
				if ((uint)(combatResultType - 2) <= 1u)
				{
					DomainManager.Character.SimulateCharacterCombatResult(context, selfChar, targetChar, -40, -20, 0);
				}
				else
				{
					DomainManager.Character.SimulateCharacterCombatResult(context, targetChar, selfChar, -40, -20, 0);
				}
			}
			break;
		default:
			if (selfCharId == taiwuCharId)
			{
				ItemKey itemKey = DomainManager.Item.CreateDemandedSkillBook(context, BookTemplateId, InternalIndex, GeneratedPageTypes);
				selfChar.AddInventoryItem(context, itemKey, 1);
			}
			selfChar.LearnNewCombatSkill(context, combatSkillTemplateId, (ushort)(1 << (int)InternalIndex));
			lifeRecordCollection.AddStealCombatSkillSucceedAndEscaped(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			break;
		}
	}
}
