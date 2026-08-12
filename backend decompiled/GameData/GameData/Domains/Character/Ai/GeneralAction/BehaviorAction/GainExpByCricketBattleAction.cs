using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class GainExpByCricketBattleAction : IGeneralAction
{
	public Wager Wager;

	public bool Succeed;

	public int ExpGain;

	public sbyte ActionEnergyType => 3;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return DomainManager.Item.CheckCharacterHasWager(Succeed ? targetChar : selfChar, Wager);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = selfChar.GetId();
		Location location = targetChar.GetLocation();
		monthlyEventCollection.AddRequestCricketBattle(selfCharId, location, targetChar.GetId());
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		if (Succeed)
		{
			selfChar.ChangeExp(context, ExpGain);
			lifeRecordCollection.AddCricketBattleWin(selfCharId, currDate, targetCharId, location);
			DomainManager.Item.TransferWager(context, targetChar, selfChar, Wager);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddCricketBattleWin(selfCharId, targetCharId);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			targetChar.ChangeExp(context, ExpGain);
			lifeRecordCollection.AddCricketBattleLose(selfCharId, currDate, targetCharId, location);
			DomainManager.Item.TransferWager(context, selfChar, targetChar, Wager);
			SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset2 = secretInformationCollection2.AddCricketBattleWin(targetCharId, selfCharId);
			SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}
}
