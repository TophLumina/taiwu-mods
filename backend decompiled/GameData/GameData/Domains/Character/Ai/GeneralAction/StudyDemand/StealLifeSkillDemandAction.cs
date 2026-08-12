using Config;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;

namespace GameData.Domains.Character.Ai.GeneralAction.StudyDemand;

public class StealLifeSkillDemandAction : IGeneralAction
{
	public short BookTemplateId;

	public byte PageId;

	public sbyte Phase;

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
		SkillBookItem bookCfg = Config.SkillBook.Instance[BookTemplateId];
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		if (Phase <= 3)
		{
			monthlyNotificationCollection.AddStealLifeSkillFailure(selfCharId, location, targetCharId, bookCfg.LifeSkillTemplateId);
			ApplyChanges(context, selfChar, targetChar);
			return;
		}
		monthlyNotificationCollection.AddStealLifeSkillSuccess(selfCharId, location, targetCharId, bookCfg.LifeSkillTemplateId);
		if (Phase == 4)
		{
			monthlyEventCollection.AddStealLifeSkillButBeCaught(selfCharId, location, targetCharId, 10, BookTemplateId, PageId + 1);
		}
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		SkillBookItem bookCfg = Config.SkillBook.Instance[BookTemplateId];
		short lifeSkillTemplateId = bookCfg.LifeSkillTemplateId;
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		if (selfCharId != taiwuCharId)
		{
			selfChar.ChangeCurrMainAttribute(context, 5, -GlobalConfig.Instance.HarmfulActionCost);
		}
		if (Phase >= 4)
		{
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddStealLifeSkill(selfCharId, targetCharId, lifeSkillTemplateId);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		sbyte phase = Phase;
		if (phase > 0 && phase < 5 && selfCharId == taiwuCharId)
		{
			EventHelper.ChangeAlertnessOnStealLifeSkill(targetCharId, bookCfg.Grade, bookCfg.TemplateId);
		}
		switch (Phase)
		{
		case 0:
			lifeRecordCollection.AddStealLifeSkillFail1(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			break;
		case 1:
			lifeRecordCollection.AddStealLifeSkillFail2(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			break;
		case 2:
			lifeRecordCollection.AddStealLifeSkillFail3(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			break;
		case 3:
			lifeRecordCollection.AddStealLifeSkillFail4(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			break;
		case 4:
			if (selfCharId == taiwuCharId)
			{
				ItemKey itemKey2 = DomainManager.Item.CreateDemandedSkillBook(context, BookTemplateId, PageId, 0);
				selfChar.AddInventoryItem(context, itemKey2, 1);
			}
			selfChar.LearnNewLifeSkill(context, lifeSkillTemplateId, (byte)(1 << (int)PageId));
			lifeRecordCollection.AddStealLifeSkillSucceed(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
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
				ItemKey itemKey = DomainManager.Item.CreateDemandedSkillBook(context, BookTemplateId, PageId, 0);
				selfChar.AddInventoryItem(context, itemKey, 1);
			}
			selfChar.LearnNewLifeSkill(context, lifeSkillTemplateId, (byte)(1 << (int)PageId));
			lifeRecordCollection.AddStealLifeSkillSucceedAndEscaped(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			break;
		}
	}
}
