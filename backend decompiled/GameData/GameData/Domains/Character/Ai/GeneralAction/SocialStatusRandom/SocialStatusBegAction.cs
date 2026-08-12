using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.SocialStatusRandom;

public class SocialStatusBegAction : IGeneralAction
{
	public bool Succeed;

	public int MoneyAmount;

	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return targetChar.GetResource(6) >= MoneyAmount;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = selfChar.GetId();
		Location location = targetChar.GetLocation();
		monthlyEventCollection.AddAskForMoney(selfCharId, location, targetChar.GetId());
		CharacterDomain.AddLockMovementCharSet(selfCharId);
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		int secretInfoOffset = secretInformationCollection.AddBegMoney(selfCharId, targetChar.GetId());
		SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		sbyte behaviorType = selfChar.GetBehaviorType();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (Succeed)
		{
			selfChar.ChangeResource(context, 6, MoneyAmount);
			targetChar.ChangeResource(context, 6, -MoneyAmount);
			short favorChange = AiHelper.GeneralActionConstants.GetBegSucceedFavorabilityChange(context.Random, behaviorType);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, favorChange);
			lifeRecordCollection.AddAskForMoneySucceed(selfCharId, currDate, targetCharId, location, 6, MoneyAmount);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestGivingMoney(targetCharId, selfCharId, MoneyAmount);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			short favorChange2 = AiHelper.GeneralActionConstants.GetBegFailFavorabilityChange(context.Random, behaviorType);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, favorChange2);
			lifeRecordCollection.AddAskForMoneyFail(selfCharId, currDate, targetCharId, location, 6, MoneyAmount);
			SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset2 = secretInformationCollection2.AddRefuseRequestGivingMoney(targetCharId, selfCharId, MoneyAmount);
			SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}
}
