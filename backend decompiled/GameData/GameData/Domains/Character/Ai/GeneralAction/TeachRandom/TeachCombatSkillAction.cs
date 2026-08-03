using Config;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;

namespace GameData.Domains.Character.Ai.GeneralAction.TeachRandom;

public class TeachCombatSkillAction : IGeneralAction
{
	public short SkillTemplateId;

	public byte InternalIndex;

	public byte GeneratedPageTypes;

	public bool Succeed;

	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return !targetChar.GetLearnedCombatSkills().Contains(SkillTemplateId);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		if (DomainManager.Taiwu.IsTaiwuAbleToGetTaught(selfChar))
		{
			DomainManager.World.GetMonthlyEventCollection().AddTeachCombatSkill(selfChar.GetId(), selfChar.GetLocation(), targetChar.GetId(), SkillTemplateId);
		}
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location location = selfChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		int targetCharId = targetChar.GetId();
		int selfCharId = selfChar.GetId();
		short bookId = Config.CombatSkill.Instance[SkillTemplateId].BookId;
		SkillBookItem bookCfg = Config.SkillBook.Instance[bookId];
		byte pageId = CombatSkillStateHelper.GetPageId(InternalIndex);
		if (Succeed)
		{
			lifeRecordCollection.AddLearnCombatSkillWithInstructionSucceed(targetCharId, currDate, selfCharId, location, 10, bookId, pageId + 1);
			if (targetCharId == DomainManager.Taiwu.GetTaiwuCharId())
			{
				ItemKey itemKey = DomainManager.Item.CreateDemandedSkillBook(context, bookId, InternalIndex, GeneratedPageTypes);
				targetChar.AddInventoryItem(context, itemKey, 1);
			}
			targetChar.LearnNewCombatSkill(context, SkillTemplateId, (ushort)(1 << (int)InternalIndex));
			targetChar.ChangeHappiness(context, bookCfg.BaseHappinessChange);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, selfChar, bookCfg.BaseFavorabilityChange);
		}
		else
		{
			lifeRecordCollection.AddLearnCombatSkillWithInstructionFail(targetCharId, currDate, selfCharId, location, 10, bookId, pageId + 1);
		}
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		int secretInfoOffset = secretInformationCollection.AddInstructOnCombatSkill(selfCharId, targetCharId, SkillTemplateId);
		SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
	}
}
