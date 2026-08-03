using System;
using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains.Adventure;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.Information;
using GameData.Domains.Information.Secret;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Taiwu.VillagerRole;
using GameData.Domains.TaiwuEvent;
using GameData.Utilities;
using GameData.Utilities.Information;

namespace GameData.Domains.Character;

public class PrioritizedGoalCreation
{
	private static bool JoinOrganization(DataContext context, Character selfChar)
	{
		OrganizationInfo orgInfo = selfChar.GetOrganizationInfo();
		OrganizationItem orgCfg = Config.Organization.Instance[orgInfo.OrgTemplateId];
		if (!orgCfg.IsCivilian)
		{
			return false;
		}
		sbyte idealSect = selfChar.GetIdealSect();
		if (idealSect < 0)
		{
			return false;
		}
		int chance = 0;
		int selfCharId = selfChar.GetId();
		HashSet<int> enemyIds = DomainManager.Character.GetRelatedCharIds(selfCharId, 32768);
		foreach (int enemyId in enemyIds)
		{
			if (DomainManager.Character.IsCharacterAlive(enemyId))
			{
				short favorability = DomainManager.Character.GetFavorability(selfCharId, enemyId);
				sbyte favorType = FavorabilityType.GetFavorabilityType(favorability);
				if (favorType < 0)
				{
					chance += 10 - favorType;
				}
			}
		}
		chance += AiHelper.PrioritizedActionConstants.CivilianGradeJoinSectChance[orgInfo.Grade];
		if (!context.Random.CheckPercentProb(chance))
		{
			return false;
		}
		return selfChar.OfflineAddGoal(261, idealSect);
	}

	private static bool Appointment(DataContext context, Character selfChar)
	{
		int selfCharId = selfChar.GetId();
		if (!DomainManager.Taiwu.TryGetElement_Appointments(selfCharId, out var targetLocation))
		{
			return false;
		}
		if (!CharacterMatcher.DefValue.CanMakeAppointment.Match(selfChar))
		{
			return false;
		}
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		return selfChar.OfflineAddGoal(254, taiwuId, targetLocation);
	}

	private static bool ProtectFriendOrFamily(DataContext context, Character selfChar)
	{
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(selfChar.GetOrganizationInfo());
		int selfCharId = selfChar.GetId();
		Location selfLocation = selfChar.GetLocation();
		int leaderId = selfChar.GetLeaderId();
		List<int>[] prioritizedActionTargets = context.AdvanceMonthRelatedData.PrioritizedTargets.Get();
		int favorType = 0;
		int targetCharId = selfChar.SelectMaxPriorityActionTarget(prioritizedActionTargets, delegate(int charId)
		{
			if (!DomainManager.Character.IsTargetForVengeance(charId))
			{
				return false;
			}
			if (!DomainManager.Character.TryGetElement_Objects(charId, out var element) || element.GetKidnapperId() >= 0 || (leaderId >= 0 && leaderId == element.GetLeaderId()) || element.IsCompletelyInfected())
			{
				return false;
			}
			Location location = element.GetLocation();
			if (!location.IsValid())
			{
				location = element.GetValidLocation();
			}
			if (location.AreaId != selfLocation.AreaId && DomainManager.Map.GetTotalTimeCost(selfChar, selfLocation.AreaId, location.AreaId) > 90)
			{
				return false;
			}
			favorType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetRelation(selfCharId, charId).Favorability);
			if (!orgMemberCfg.CanStroll && favorType < 5)
			{
				return false;
			}
			int percentProb = favorType * 20 - 40;
			return context.Random.CheckPercentProb(percentProb);
		});
		if (targetCharId < 0)
		{
			return false;
		}
		return selfChar.OfflineAddGoal(262, targetCharId);
	}

	private static bool RescueFriendOrFamily(DataContext context, Character selfChar)
	{
		int selfCharId = selfChar.GetId();
		if (!DomainManager.Information.TryGetCharacterKnownSecret(selfChar.GetId(), out var secrets))
		{
			return false;
		}
		sbyte behaviorType = selfChar.GetBehaviorType();
		int targetCharId = -1;
		int maxPriority = int.MinValue;
		foreach (SecretInformationId secretInformationId in secrets.KnownSecrets)
		{
			SecretOccurence occurence = DomainManager.Information.QuerySecretOccurence(secretInformationId);
			if (occurence.TemplateId != 96 && occurence.TemplateId != 2 && occurence.TemplateId != 4)
			{
				continue;
			}
			int kidnapperId = -1;
			int kidnappedCharId = -1;
			SecretInformationItem secretCfg = Config.SecretInformation.Instance[occurence.TemplateId];
			occurence.PackedParameters.ExtractSecretParameters(secretCfg, delegate(int index, int charId)
			{
				switch (index)
				{
				case 0:
					kidnapperId = charId;
					break;
				case 1:
					kidnappedCharId = charId;
					break;
				}
			});
			if (kidnapperId == selfCharId || !DomainManager.Character.TryGetRelation(selfCharId, kidnappedCharId, out var relation))
			{
				continue;
			}
			sbyte targetType = AiHelper.ActionTargetType.GetActionTargetType(relation.RelationType);
			if (targetType >= 0)
			{
				sbyte priorityScore = AiHelper.ActionTargetType.PriorityScores[behaviorType][targetType];
				if (priorityScore >= maxPriority)
				{
					maxPriority = priorityScore;
					targetCharId = kidnappedCharId;
				}
			}
		}
		if (targetCharId < 0)
		{
			return false;
		}
		return selfChar.OfflineAddGoal(263, targetCharId);
	}

	private static bool MournForTheDead(DataContext context, Character selfChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = -1;
		Location location = selfChar.GetLocation();
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(selfChar.GetOrganizationInfo());
		StrictTempObjectContainer<List<int>[]> prioritizedActionTargets = context.AdvanceMonthRelatedData.PrioritizedTargets;
		targetCharId = selfChar.SelectMaxPriorityActionTarget(prioritizedActionTargets.Get(), delegate(int charId)
		{
			if (!DomainManager.Character.TryGetElement_Graves(charId, out var element))
			{
				return false;
			}
			Location location2 = element.GetLocation();
			if (location2.AreaId != location.AreaId && DomainManager.Map.GetTotalTimeCost(selfChar, location.AreaId, location2.AreaId) > 90)
			{
				return false;
			}
			if (!orgMemberCfg.CanStroll)
			{
				short favorability = DomainManager.Character.GetFavorability(selfCharId, charId);
				sbyte favorabilityType = FavorabilityType.GetFavorabilityType(favorability);
				if (favorabilityType < 5)
				{
					return false;
				}
			}
			return context.Random.CheckPercentProb(40);
		});
		if (targetCharId < 0)
		{
			return false;
		}
		return selfChar.OfflineAddGoal(264, targetCharId);
	}

	private static bool FindTreasure(DataContext context, Character selfChar)
	{
		Location targetLocation = Location.Invalid;
		if (DomainManager.Information.TryGetCharacterKnownSecret(selfChar.GetId(), out var secrets))
		{
			foreach (SecretInformationId secretInformationId in secrets.KnownSecrets)
			{
				SecretOccurence occurence = DomainManager.Information.QuerySecretOccurence(secretInformationId);
				if (occurence.TemplateId != 29 || !occurence.Location.IsValid())
				{
					continue;
				}
				targetLocation = occurence.Location;
				break;
			}
		}
		if (!targetLocation.IsValid())
		{
			return false;
		}
		sbyte behaviorType = selfChar.GetBehaviorType();
		sbyte chance = AiHelper.PrioritizedActionConstants.FindTreasureBaseChance[behaviorType];
		if (!context.Random.CheckPercentProb(chance))
		{
			return false;
		}
		return selfChar.OfflineAddGoal(265, targetLocation);
	}

	private static bool FindSpecialMaterial(DataContext context, Character selfChar)
	{
		sbyte behaviorType = selfChar.GetBehaviorType();
		sbyte chance = AiHelper.PrioritizedActionConstants.FindTreasureBaseChance[behaviorType];
		if (!context.Random.CheckPercentProb(chance))
		{
			return false;
		}
		Location selfLocation = selfChar.GetLocation();
		if (!selfLocation.IsValid())
		{
			return false;
		}
		Location targetLocation = Location.Invalid;
		int adventureId = -1;
		foreach (AdventureRuntime runtime in DomainManager.Adventure.QueryAdventuresInArea(selfLocation.AreaId))
		{
			if (!ResourceDisasterHelper.IsDisasterAdventure(runtime.CoreId) || !runtime.StatusType.IsActive())
			{
				continue;
			}
			targetLocation = runtime.MapLocation;
			break;
		}
		if (!targetLocation.IsValid())
		{
			return selfChar.ActionPlanningData.RemoveGoal(266) != null;
		}
		return selfChar.OfflineAddGoal(266, adventureId, targetLocation);
	}

	private static bool ContestForLegendaryBook(DataContext context, Character selfChar)
	{
		int selfCharId = selfChar.GetId();
		if (!DomainManager.Character.IsCharacterTryingToContestLegendaryBook(selfCharId))
		{
			return false;
		}
		sbyte happiness = selfChar.GetHappiness();
		sbyte behaviorType = selfChar.GetBehaviorType();
		int baseChance = Math.Abs(happiness) - 60 + AiHelper.LegendaryBookRelatedConstants.ContestForLegendaryBookChanceAdjust[behaviorType];
		List<sbyte> ownedBookTypes = DomainManager.LegendaryBook.GetCharOwnedBookTypes(selfCharId);
		int ownedBookCount = ownedBookTypes?.Count ?? 0;
		if (ownedBookTypes != null)
		{
			baseChance >>= ownedBookCount;
		}
		OrganizationInfo orgInfo = selfChar.GetOrganizationInfo();
		OrganizationItem orgCfg = Config.Organization.Instance[orgInfo.OrgTemplateId];
		if (orgInfo.Grade == 8 && orgInfo.Principal)
		{
			baseChance /= 5;
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		Span<sbyte> selectableBookTypes = stackalloc sbyte[14];
		int selectableCount = 0;
		for (sbyte combatSkillType = 0; combatSkillType < 14; combatSkillType++)
		{
			int ownerId = DomainManager.LegendaryBook.GetOwner(combatSkillType);
			if (ownerId >= 0 && ownerId != selfCharId && (ownerId != taiwuCharId || DomainManager.Taiwu.CanTaiwuBeSneakyHarmfulActionTarget()) && DomainManager.LegendaryBook.GetContestForLegendaryBookCharacterSet(combatSkillType).GetCount() < 2)
			{
				int chance = baseChance;
				if (orgCfg.LegendaryBookTendency == combatSkillType)
				{
					chance *= 2;
				}
				if (context.Random.CheckPercentProb(chance))
				{
					selectableBookTypes[selectableCount] = combatSkillType;
					selectableCount++;
				}
			}
		}
		if (selectableCount == 0)
		{
			return false;
		}
		sbyte selectedBookType = selectableBookTypes[context.Random.Next(selectableCount)];
		int targetCharId = DomainManager.LegendaryBook.GetOwner(selectedBookType);
		return selfChar.OfflineAddGoal(267, targetCharId, selectedBookType);
	}

	private static bool SectStoryShixiangToFightEnemy(DataContext context, Character selfChar)
	{
		Location location = DomainManager.Character.TryGetShiXiangEnemyLocation(context);
		if (!location.IsValid())
		{
			return false;
		}
		return selfChar.OfflineAddGoal(270, location);
	}

	private static bool AdoptInfant(DataContext context, Character selfChar)
	{
		int selfCharId = selfChar.GetId();
		if (!DomainManager.Character.TryGetBloodRelationInfant(selfCharId, out var infantId))
		{
			if (!DomainManager.Character.TryGetClosestInfant(selfCharId, out var infantData))
			{
				return false;
			}
			(infantId, _) = infantData;
		}
		if (DomainManager.Character.InfantHasPotentialAdopter(infantId))
		{
			if (!DomainManager.Character.IsCharacterPotentialInfantAdopter(infantId, selfCharId))
			{
				return false;
			}
			return true;
		}
		if (!DomainManager.Character.TryGetElement_Objects(infantId, out var _) || context.Random.CheckProb(50, 100))
		{
			return false;
		}
		return selfChar.OfflineAddGoal(268, infantId);
	}

	private static bool DejaVu(DataContext context, Character selfChar)
	{
		int selfCharId = selfChar.GetId();
		if (DomainManager.Extra.GetDejaVuEventCharacters().Contains(selfCharId))
		{
			return false;
		}
		short templateId;
		bool flag = !DomainManager.Extra.TryGetDreamBackLifeRecordByRelatedCharId(selfCharId, out templateId);
		bool flag2 = flag;
		if (flag2)
		{
			bool flag3;
			switch (DomainManager.Extra.GetDreamBackRelationTypeWithTaiwu(selfCharId).Item1)
			{
			case 0:
			case 2048:
			case 4096:
			case ushort.MaxValue:
				flag3 = true;
				break;
			default:
				flag3 = false;
				break;
			}
			flag2 = flag3;
		}
		if (flag2)
		{
			return false;
		}
		if (!selfChar.IsNearbyLocation(DomainManager.Taiwu.GetTaiwu().GetLocation(), 5))
		{
			return false;
		}
		return selfChar.OfflineAddGoal(253, DomainManager.Taiwu.GetTaiwuCharId());
	}

	private static bool GuardTreasury(DataContext context, Character selfChar)
	{
		int selfCharId = selfChar.GetId();
		OrganizationInfo orgInfo = selfChar.GetOrganizationInfo();
		if (orgInfo.SettlementId < 0 || !OrganizationDomain.IsSect(orgInfo.OrgTemplateId))
		{
			return false;
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(orgInfo.SettlementId);
		if (!settlement.Treasuries.IsGuard(selfCharId))
		{
			return false;
		}
		if (DomainManager.LegendaryBook.IsCharacterLegendaryBookOwnerOrContest(selfCharId))
		{
			return false;
		}
		return selfChar.OfflineAddGoal(255, orgInfo.OrgTemplateId, settlement.GetLocation());
	}

	private static bool SectStoryBaihuaToCureManic(DataContext context, Character selfChar)
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		int currDate = DomainManager.World.GetCurrDate();
		int animalDate = -1;
		if (!sectArgBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaAnimalsBackDate, ref animalDate) || currDate - animalDate < 6)
		{
			return false;
		}
		if (!DomainManager.Character.BaihuaManicCharIds.TryTake(out var targetCharId))
		{
			return false;
		}
		return selfChar.OfflineAddGoal(269, targetCharId);
	}

	private static bool EscapeFromPrison(DataContext context, Character selfChar)
	{
		sbyte bountySectTemplateId = DomainManager.Organization.GetFugitiveBountySect(selfChar.GetId());
		if (bountySectTemplateId < 0)
		{
			return false;
		}
		Sect sect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(bountySectTemplateId);
		SettlementBounty bounty = sect.Prison.GetBounty(selfChar.GetId());
		if (bounty == null)
		{
			return false;
		}
		PunishmentSeverityItem severityCfg = PunishmentSeverity.Instance[bounty.PunishmentSeverity];
		if (!severityCfg.EscapeActions.Exist(18))
		{
			return false;
		}
		Location destination = selfChar.CalcFurthestEscapeDestination(context.Random);
		return selfChar.OfflineAddGoal(257, destination);
	}

	private static bool HuntFugitive(DataContext context, Character selfChar)
	{
		OrganizationInfo orgInfo = selfChar.GetOrganizationInfo();
		if (!OrganizationDomain.IsSect(orgInfo.OrgTemplateId))
		{
			return false;
		}
		Sect sect = DomainManager.Organization.GetElement_Sects(orgInfo.SettlementId);
		List<SettlementBounty> bounties = sect.Prison.Bounties;
		if (bounties.Count == 0)
		{
			return false;
		}
		int selectedCharId = -1;
		sbyte consummateLevel = selfChar.GetConsummateLevel();
		foreach (SettlementBounty bounty in bounties)
		{
			if (!DomainManager.Character.TryGetElement_Objects(bounty.CharId, out var targetChar) || targetChar.GetCreatingType() != 1 || DomainManager.Character.IsTemporaryIntelligentCharacter(bounty.CharId) || (targetChar.GetOrganizationInfo().OrgTemplateId != 0 && targetChar.GetId() != DomainManager.Taiwu.GetTaiwuCharId()) || bounty.RequiredConsummateLevel > consummateLevel || targetChar.GetConsummateLevel() > consummateLevel || bounty.CurrentHunterId >= 0 || targetChar.GetKidnapperId() >= 0)
			{
				continue;
			}
			selectedCharId = bounty.CharId;
			break;
		}
		if (selectedCharId < 0)
		{
			return false;
		}
		return selfChar.OfflineAddGoal(256, selectedCharId);
	}

	private static bool SeekAsylum(DataContext context, Character selfChar)
	{
		sbyte bountySectTemplateId = DomainManager.Organization.GetFugitiveBountySect(selfChar.GetId());
		if (bountySectTemplateId < 0)
		{
			return false;
		}
		Sect sect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(bountySectTemplateId);
		SettlementBounty bounty = sect.Prison.GetBounty(selfChar.GetId());
		if (bounty == null)
		{
			return false;
		}
		PunishmentSeverityItem severityCfg = PunishmentSeverity.Instance[bounty.PunishmentSeverity];
		if (!severityCfg.EscapeActions.Exist(19))
		{
			return false;
		}
		Span<sbyte> span = stackalloc sbyte[14];
		SpanList<sbyte> hostileSectTemplateIds = span;
		DomainManager.Organization.GetSectTemplateIdsByFavorability(bountySectTemplateId, -1, ref hostileSectTemplateIds);
		if (hostileSectTemplateIds.Count == 0)
		{
			return false;
		}
		sbyte targetSectTemplateId = hostileSectTemplateIds.GetRandom(context.Random);
		Settlement targetSect = DomainManager.Organization.GetSettlementByOrgTemplateId(targetSectTemplateId);
		short targetSettlementId = targetSect.GetId();
		sbyte selfGender = selfChar.GetGender();
		if (!OrganizationDomain.MeetGenderRestriction(targetSectTemplateId, selfGender))
		{
			return false;
		}
		OrganizationInfo targetOrgInfo = new OrganizationInfo(targetSectTemplateId, 0, principal: true, targetSettlementId);
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(targetOrgInfo);
		if (orgMemberCfg.Gender >= 0 && orgMemberCfg.Gender != selfGender)
		{
			return false;
		}
		if (orgMemberCfg.ChildGrade < 0 && (DomainManager.Character.GetAliveSpouse(selfChar.GetId()) >= 0 || DomainManager.Character.GetAliveChild(selfChar.GetId()) >= 0))
		{
			return false;
		}
		return selfChar.OfflineAddGoal(258, targetSectTemplateId);
	}

	private static bool EscortPrisoner(DataContext context, Character selfChar)
	{
		if (!selfChar.IsActiveExternalRelationState(2uL))
		{
			return false;
		}
		int selfCharId = selfChar.GetId();
		sbyte selfOrgTemplateId = selfChar.GetOrganizationInfo().OrgTemplateId;
		List<KidnappedCharacter> kidnappedCharList = DomainManager.Character.GetKidnappedCharacters(selfCharId).GetCollection();
		foreach (KidnappedCharacter kidnappedChar in kidnappedCharList)
		{
			sbyte bountySectTemplateId = DomainManager.Organization.GetFugitiveBountySect(kidnappedChar.CharId);
			if (bountySectTemplateId < 0 || bountySectTemplateId != selfOrgTemplateId)
			{
				continue;
			}
			return selfChar.OfflineAddGoal(259, kidnappedChar.CharId, bountySectTemplateId);
		}
		return false;
	}

	private static bool VillagerRoleArrangement(DataContext context, Character selfChar)
	{
		int selfCharId = selfChar.GetId();
		if (selfChar.GetOrganizationInfo().OrgTemplateId != 16)
		{
			return false;
		}
		VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(selfCharId);
		if (villagerRole == null || villagerRole.ArrangementTemplateId < 0)
		{
			return false;
		}
		if (villagerRole.WorkData == null || villagerRole.WorkData.AreaId < 0)
		{
			return false;
		}
		if (!(villagerRole is IVillagerRoleSelectLocation roleSelectLocation))
		{
			return false;
		}
		CharacterGoalData prevGoal = selfChar.GetGoal(260);
		if (prevGoal != null && IVillagerRoleSelectLocation.MatchWorkLocation(villagerRole.WorkData.Location, prevGoal.Args.Location))
		{
			return true;
		}
		Location location = roleSelectLocation.SelectNextWorkLocation(context.Random, villagerRole.WorkData.Location);
		return selfChar.OfflineAddGoal(260, location);
	}

	private static bool HuntTaiwu(DataContext context, Character selfChar)
	{
		short jieqingSettlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(13);
		if (!DomainManager.Map.IsLocationInSettlementInfluenceRange(selfChar.GetLocation(), jieqingSettlementId))
		{
			return false;
		}
		if (selfChar.IsTreasuryGuard())
		{
			return false;
		}
		Character taiwu = DomainManager.Taiwu.GetTaiwu();
		List<short> featureIds = taiwu.GetFeatureIds();
		bool hasFeature = false;
		short maxJieqingPunish = 505;
		for (int i = 0; i < featureIds.Count; i++)
		{
			short featureId = featureIds[i];
			if (featureId >= 505 && featureId <= 509)
			{
				hasFeature = true;
				if (featureId >= maxJieqingPunish)
				{
					maxJieqingPunish = featureId;
				}
			}
		}
		if (!hasFeature)
		{
			return false;
		}
		if (DomainManager.Taiwu.GetJieqingHuntTaiwu())
		{
			return false;
		}
		if (selfChar.GetGoal(256) != null)
		{
			return false;
		}
		if (!CheckHuntTaiwuCondition(maxJieqingPunish, selfChar.GetConsummateLevel(), taiwu.GetConsummateLevel()))
		{
			return false;
		}
		return selfChar.OfflineAddGoal(271, DomainManager.Taiwu.GetTaiwuCharId());
	}

	private static bool GetRevenge(DataContext context, Character selfChar)
	{
		if (selfChar.GetOrganizationInfo().OrgTemplateId == 16)
		{
			return false;
		}
		int selfCharId = selfChar.GetId();
		sbyte behaviorType = selfChar.GetBehaviorType();
		Location selfLocation = selfChar.GetLocation();
		sbyte chance = AiHelper.PrioritizedActionConstants.TakeRevengeChance[behaviorType];
		OrganizationInfo orgInfo = selfChar.GetOrganizationInfo();
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(orgInfo);
		if (!orgMemberCfg.CanStroll)
		{
			chance /= 2;
		}
		chance = (sbyte)Math.Clamp(DomainManager.SpecialEffect.ModifyValue(selfCharId, 295, chance), 0, 127);
		if (!context.Random.CheckPercentProb(chance))
		{
			return false;
		}
		HashSet<int> enemyIds = DomainManager.Character.GetRelatedCharIds(selfCharId, 32768);
		int targetCharId = -1;
		foreach (int enemyId in enemyIds)
		{
			if (!DomainManager.Character.TryGetElement_Objects(enemyId, out var targetChar) || targetChar.GetKidnapperId() >= 0 || targetChar.GetAgeGroup() == 0)
			{
				continue;
			}
			short favorability = DomainManager.Character.GetFavorability(selfCharId, enemyId);
			sbyte favorType = FavorabilityType.GetFavorabilityType(favorability);
			if (favorType <= AiHelper.PrioritizedActionConstants.TakeRevengeMaxFavorType[behaviorType])
			{
				Location targetLocation = targetChar.GetLocation();
				if (!targetLocation.IsValid())
				{
					targetLocation = targetChar.GetValidLocation();
				}
				if (targetLocation.AreaId == selfLocation.AreaId || DomainManager.Map.GetTotalTimeCost(selfChar, selfLocation.AreaId, targetLocation.AreaId) <= 90)
				{
					targetCharId = enemyId;
					break;
				}
			}
		}
		if (targetCharId < 0)
		{
			return false;
		}
		return selfChar.OfflineAddGoal(274, targetCharId);
	}

	public static bool CheckHuntTaiwuCondition(short featureId, int killerConsummateLevel, int taiwuConsummateLevel)
	{
		Tester.Assert(featureId >= 505 && featureId <= 509);
		int consummateLevelGap = killerConsummateLevel - taiwuConsummateLevel;
		if (featureId == 509 && ((consummateLevelGap >= 5 && consummateLevelGap <= 6) || killerConsummateLevel == GlobalConfig.Instance.MaxConsummateLevel))
		{
			return true;
		}
		if (featureId == 508 && ((consummateLevelGap >= 3 && consummateLevelGap <= 4) || killerConsummateLevel == GlobalConfig.Instance.MaxConsummateLevel))
		{
			return true;
		}
		if (featureId == 507 && ((consummateLevelGap >= 1 && consummateLevelGap <= 2) || killerConsummateLevel == GlobalConfig.Instance.MaxConsummateLevel))
		{
			return true;
		}
		if (featureId == 506 && (consummateLevelGap == 0 || killerConsummateLevel == 0))
		{
			return true;
		}
		if (featureId == 505 && ((consummateLevelGap >= -2 && consummateLevelGap <= -1) || killerConsummateLevel == 0))
		{
			return true;
		}
		return false;
	}
}
