using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.Notification;

namespace GameData.Domains.Character.Ai.GeneralAction.LifeSkillRandom;

public class LifeSkillDivinationAction : IGeneralAction
{
	public int SecretId;

	public bool Succeed;

	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		if (selfChar.GetHealth() < selfChar.GetLeftMaxHealth() || selfChar.GetHealth() <= 12)
		{
			return false;
		}
		if (DomainManager.Information.CharacterHasSecretInformation(selfChar.GetId(), (SecretInformationId)SecretId))
		{
			return false;
		}
		return true;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		if (Succeed)
		{
			MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
			int selfCharId = selfChar.GetId();
			int targetCharId = targetChar.GetId();
			Location location = selfChar.GetLocation();
			monthlyNotifications.AddPractiseDivination(selfCharId, location, targetCharId);
		}
		ApplyChanges(context, selfChar, targetChar);
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
			short templateId = DomainManager.Information.QuerySecretOccurence((SecretInformationId)SecretId).TemplateId;
			lifeRecordCollection.AddDivinationSucceed(selfCharId, currDate, targetCharId, location, templateId);
			DomainManager.Information.ReceiveSecretInformation(context, (SecretInformationId)SecretId, selfCharId, targetCharId);
		}
		else
		{
			lifeRecordCollection.AddDivinationFail(selfCharId, currDate, location);
			selfChar.ChangeHealth(context, -12);
		}
	}
}
