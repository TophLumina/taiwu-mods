using System;
using System.Linq;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.AvatarSystem.AvatarRes;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SocialStatusBarbAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Succeed = 0;

		public const ushort AttractionIncreased = 1;

		public const ushort TargetFrontHairId = 2;

		public const ushort TargetBackHairId = 3;

		public const ushort TargetBeard1Id = 4;

		public const ushort TargetBeard2Id = 5;

		public const ushort Count = 6;

		public static readonly string[] FieldId2FieldName = new string[6] { "Succeed", "AttractionIncreased", "TargetFrontHairId", "TargetBackHairId", "TargetBeard1Id", "TargetBeard2Id" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public bool Succeed;

	[SerializableGameDataField(FieldIndex = 1)]
	public bool AttractionIncreased;

	[SerializableGameDataField(FieldIndex = 2)]
	public short TargetFrontHairId;

	[SerializableGameDataField(FieldIndex = 3)]
	public short TargetBackHairId;

	[SerializableGameDataField(FieldIndex = 4)]
	public short TargetBeard1Id;

	[SerializableGameDataField(FieldIndex = 5)]
	public short TargetBeard2Id;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		int targetCharId = targetChar.GetId();
		if (targetChar.GetAgeGroup() != 2)
		{
			return false;
		}
		if (!DomainManager.Character.TryGetRelation(character.GetId(), targetCharId, out var relation) || relation.GetFavorabilityType() < 3)
		{
			return false;
		}
		if (!targetChar.GetAvatar().GetGrowableElementShowingState(0))
		{
			return false;
		}
		if (targetChar.GetGroupFeature(688) >= 0)
		{
			return false;
		}
		return true;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		short attainment = character.GetLifeSkillAttainment(5);
		int successRate = 80 + attainment / 10;
		int attractionIncreaseRate = 20 + attainment / 5;
		bool succeed = context.Random.CheckPercentProb(successRate);
		bool attractionIncreased = context.Random.CheckPercentProb(attractionIncreaseRate);
		AvatarData avatar = targetChar.GetAvatar();
		short frontHairId = avatar.FrontHairId;
		short backHairId = avatar.BackHairId;
		short beard1Id = avatar.Beard1Id;
		short beard2Id = avatar.Beard2Id;
		if (succeed)
		{
			AvatarGroup avatarGroup = AvatarManager.Instance.GetAvatarGroup(avatar.AvatarId);
			if (avatar.GetGrowableElementShowingState(1) && avatar.GetGrowableElementShowingAbility(1) && avatar.GetGrowableElementShowingState(2) && avatar.GetGrowableElementShowingAbility(2) && avatarGroup.Beard1Res.CheckIndex(0) && avatarGroup.Beard2Res.CheckIndex(0))
			{
				AvatarAsset currBeard1Res = avatarGroup.Beard1Res.First((AvatarAsset beardRes) => beardRes.Id == beard1Id);
				AvatarAsset currBeard2Res = avatarGroup.Beard2Res.First((AvatarAsset beardRes) => beardRes.Id == beard2Id);
				float beardCharmRate = Math.Min(currBeard1Res.Config.CharmExtraArg, currBeard2Res.Config.CharmExtraArg);
				if (attractionIncreased)
				{
					(beard1Id, beard2Id) = avatarGroup.GetRandomBeardsWithCondition(context.Random, (AvatarAsset beardRes) => beardRes.Config.CharmExtraArg > beardCharmRate);
				}
				else
				{
					(beard1Id, beard2Id) = avatarGroup.GetRandomBeardsWithCondition(context.Random, (AvatarAsset beardRes) => beardRes.Config.CharmExtraArg < beardCharmRate);
				}
				if (avatarGroup.IsBeardless(beard1Id, beard2Id))
				{
					short beard1Id2 = avatar.Beard1Id;
					short beard2Id2 = avatar.Beard2Id;
					beard2Id = beard2Id2;
					beard1Id = beard1Id2;
				}
			}
			if (avatar.GetGrowableElementShowingState(0) && avatar.GetGrowableElementShowingAbility(0) && avatarGroup.Hair1Res.CheckIndex(0) && avatarGroup.Hair2Res.CheckIndex(0))
			{
				HairRes currFrontHairRes = avatarGroup.Hair1Res.First((HairRes hairRes) => hairRes.Id == frontHairId);
				HairRes currBackHairRes = avatarGroup.Hair2Res.First((HairRes hairRes) => hairRes.Id == backHairId);
				float hairCharmRate = Math.Min(currFrontHairRes.Hair.Config.CharmExtraArg, currBackHairRes.Hair.Config.CharmExtraArg);
				if (attractionIncreased)
				{
					(frontHairId, backHairId) = avatarGroup.GetRandomHairsWithCondition(context.Random, (HairRes hairRes) => hairRes.Hair.Config.CharmExtraArg > hairCharmRate);
				}
				else
				{
					(frontHairId, backHairId) = avatarGroup.GetRandomHairsWithCondition(context.Random, (HairRes hairRes) => hairRes.Hair.Config.CharmExtraArg < hairCharmRate);
				}
				if (avatarGroup.IsHairless(frontHairId, backHairId))
				{
					short beard2Id2 = avatar.FrontHairId;
					short beard1Id2 = avatar.BackHairId;
					backHairId = beard1Id2;
					frontHairId = beard2Id2;
				}
			}
			if (avatar.FrontHairId == frontHairId && avatar.BackHairId == backHairId && avatar.Beard1Id == beard1Id && avatar.Beard2Id == beard2Id)
			{
				return false;
			}
		}
		AttractionIncreased = attractionIncreased;
		Succeed = succeed;
		TargetBeard1Id = beard1Id;
		TargetBeard2Id = beard2Id;
		TargetFrontHairId = frontHairId;
		TargetBackHairId = backHairId;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = character.GetId();
		Location location = actionData.TargetChar.GetLocation();
		monthlyEventCollection.AddAdviseBarb(selfCharId, location, actionData.TargetCharId);
		CharacterDomain.AddLockMovementCharSet(character.GetId());
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
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
				DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, character, 3000);
				lifeRecordCollection.AddBarbSucceed(selfCharId, currDate, targetCharId, location);
				int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddRehaircutSuccess(selfCharId, targetCharId);
				DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			}
			else
			{
				targetChar.AddFeature(context, 689, removeMutexFeature: true);
				DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, character, -1500);
				lifeRecordCollection.AddBarbMistake(selfCharId, currDate, targetCharId, location);
				int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRehaircutIncompleted(selfCharId, targetCharId);
				DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
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
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -3000);
			lifeRecordCollection.AddBarbFail(selfCharId, currDate, targetCharId, location);
			int secretInfoOffset3 = DomainManager.Information.GetSecretInformationCollection().AddRehaircutFail(selfCharId, targetCharId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset3);
		}
		targetChar.SetAvatar(avatar, context);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 6;
		byte* num = pData + 2;
		*num = (Succeed ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*num2 = (AttractionIncreased ? ((byte)1) : ((byte)0));
		byte* num3 = num2 + 1;
		*(short*)num3 = TargetFrontHairId;
		byte* num4 = num3 + 2;
		*(short*)num4 = TargetBackHairId;
		byte* num5 = num4 + 2;
		*(short*)num5 = TargetBeard1Id;
		byte* num6 = num5 + 2;
		*(short*)num6 = TargetBeard2Id;
		int totalSize = (int)(num6 + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Succeed = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 1)
		{
			AttractionIncreased = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 2)
		{
			TargetFrontHairId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 3)
		{
			TargetBackHairId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 4)
		{
			TargetBeard1Id = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 5)
		{
			TargetBeard2Id = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
