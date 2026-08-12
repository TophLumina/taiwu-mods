using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Utilities;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class GainExpByLifeSkillBattleAction : IGeneralAction
{
	public bool Succeed;

	public int ExpGain;

	public sbyte ActionEnergyType => 3;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return true;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		Location location = targetChar.GetLocation();
		MonthlyEventCollection monthlyEvents = DomainManager.World.GetMonthlyEventCollection();
		monthlyEvents.AddRequestLifeSkillBattle(selfCharId, location, targetChar.GetId());
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		TempHashsetContainer<int> closeCharIds = context.AdvanceMonthRelatedData.RelatedCharIds;
		Character winner;
		if (Succeed)
		{
			lifeRecordCollection.AddLifeSkillBattleWin(selfCharId, currDate, targetCharId, location);
			winner = selfChar;
			Character loser = targetChar;
		}
		else
		{
			lifeRecordCollection.AddLifeSkillBattleLose(selfCharId, currDate, targetCharId, location);
			winner = targetChar;
			Character loser = selfChar;
		}
		winner.ChangeExp(context, ExpGain);
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		int secretInfoOffset = secretInformationCollection.AddLifeSkillBattleWin(selfCharId, targetCharId);
		SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
	}
}
