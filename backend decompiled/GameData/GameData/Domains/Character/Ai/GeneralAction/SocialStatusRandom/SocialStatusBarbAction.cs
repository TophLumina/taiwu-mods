using GameData.Common;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.AvatarSystem.AvatarRes;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Utilities;

namespace GameData.Domains.Character.Ai.GeneralAction.SocialStatusRandom;

public class SocialStatusBarbAction : IGeneralAction
{
	public bool Succeed;

	public bool AttractionIncreased;

	public short TargetFrontHairId;

	public short TargetBackHairId;

	public short TargetBeard1Id;

	public short TargetBeard2Id;

	public sbyte ActionEnergyType => 4;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return true;
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = selfChar.GetId();
		Location location = targetChar.GetLocation();
		monthlyEventCollection.AddAdviseBarb(selfCharId, location, targetChar.GetId());
		CharacterDomain.AddLockMovementCharSet(selfChar.GetId());
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		AvatarData avatar = targetChar.GetAvatar();
		if (Succeed)
		{
			AvatarGroup avatarGroup = AvatarManager.Instance.GetAvatarGroup(avatar.AvatarId);
			if (avatarGroup.IsHairless(TargetFrontHairId, TargetBackHairId))
			{
				avatar.SetGrowableElementShowingState(0, show: false);
				DomainManager.Character.InitializeAvatarElementGrowthProgress(context, targetCharId, 0);
			}
			else
			{
				avatar.FrontHairId = TargetFrontHairId;
				avatar.BackHairId = TargetBackHairId;
			}
			if (avatarGroup.Beard1Res.CheckIndex(0) && TargetBeard1Id == avatarGroup.Beard1Res[0].Id)
			{
				avatar.SetGrowableElementShowingState(1, show: false);
				DomainManager.Character.InitializeAvatarElementGrowthProgress(context, targetCharId, 1);
			}
			else
			{
				avatar.Beard1Id = TargetBeard1Id;
			}
			if (avatarGroup.Beard2Res.CheckIndex(0) && TargetBeard2Id == avatarGroup.Beard2Res[0].Id)
			{
				avatar.SetGrowableElementShowingState(2, show: false);
				DomainManager.Character.InitializeAvatarElementGrowthProgress(context, targetCharId, 2);
			}
			else
			{
				avatar.Beard2Id = TargetBeard2Id;
			}
			if (AttractionIncreased)
			{
				targetChar.AddFeature(context, 688, removeMutexFeature: true);
				DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, selfChar, 3000);
				lifeRecordCollection.AddBarbSucceed(selfCharId, currDate, targetCharId, location);
				SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
				int secretInfoOffset = secretInformationCollection.AddRehaircutSuccess(selfCharId, targetCharId);
				SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			}
			else
			{
				targetChar.AddFeature(context, 689, removeMutexFeature: true);
				DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, selfChar, -1500);
				lifeRecordCollection.AddBarbMistake(selfCharId, currDate, targetCharId, location);
				SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
				int secretInfoOffset2 = secretInformationCollection2.AddRehaircutIncompleted(selfCharId, targetCharId);
				SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
			}
		}
		else
		{
			avatar.ResetGrowableElementShowingState(0);
			avatar.ResetGrowableElementShowingState(1);
			avatar.ResetGrowableElementShowingState(2);
			avatar.ResetGrowableElementShowingState(6);
			DomainManager.Character.InitializeAvatarElementGrowthProgress(context, targetCharId, 0);
			DomainManager.Character.InitializeAvatarElementGrowthProgress(context, targetCharId, 1);
			DomainManager.Character.InitializeAvatarElementGrowthProgress(context, targetCharId, 2);
			DomainManager.Character.InitializeAvatarElementGrowthProgress(context, targetCharId, 6);
			targetChar.AddFeature(context, 690, removeMutexFeature: true);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, -3000);
			lifeRecordCollection.AddBarbFail(selfCharId, currDate, targetCharId, location);
			SecretInformationCollection secretInformationCollection3 = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset3 = secretInformationCollection3.AddRehaircutFail(selfCharId, targetCharId);
			SecretInformationId secretInfoId3 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset3);
		}
		targetChar.SetAvatar(avatar, context);
	}
}
