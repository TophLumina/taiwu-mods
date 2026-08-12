using System;
using System.Collections.Generic;
using Config;
using Config.Common;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization.Display;
using GameData.Domains.Taiwu.Display;
using GameData.Domains.Taiwu.Display.VillagerRoleArrangement;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.VillagerRole;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class VillagerRoleHead : VillagerRoleBase, IVillagerRoleArrangementExecutor, IVillagerRoleSelectLocation
{
	public override short RoleTemplateId => 6;

	private int AutoActionAffectCount => VillagerRoleFormula.DefValue.VillageHeadAutoActionAffectCount.Calculate(base.Personality);

	private int AutoActionFavorChange => VillagerRoleFormula.DefValue.VillageHeadAutoActionFavorChange.Calculate(Character.GetLifeSkillAttainment(4));

	private int AutoActionFavorIncreaseRate => VillagerRoleFormula.DefValue.VillageHeadAutoActionFavorIncreaseRate.Calculate(Character.GetBehaviorType());

	public int ArrangementSpecialRuleCount => VillagerRoleFormula.DefValue.VillageHeadWorkSpecialRuleCount.Calculate(base.Personality);

	public int ArrangementSpecialRuleRange => VillagerRoleFormula.DefValue.VillageHeadWorkChangeRuleRange.Calculate(GlobalConfig.Instance.ModifySeverityDefaultRange);

	[Obsolete]
	public int VillagerFavorabilityChange => Character.GetPersonality(6) * 300;

	[Obsolete]
	public int PersonalityBonusPercent => SharedMethods.CalculateVillageHeadPersonalityBonusPercent(Character.GetPersonalities());

	[Obsolete]
	public int AttainmentBonusPercent => SharedMethods.CalculateVillageHeadAttainmentBonusPercent(Character.GetPersonalities());

	private int ChickenUpgradeTotalCount(DataContext context)
	{
		return (!base.HasChickenUpgradeEffect || !context.Random.CheckPercentProb(VillagerRoleFormula.DefValue.VillageHeadAutoActionFavorChange.Calculate(base.Personality))) ? 1 : 2;
	}

	public override void ExecuteFixedAction(DataContext context)
	{
		if (!base.AutoActionStates[8])
		{
			return;
		}
		int affectCount = AutoActionAffectCount;
		int favorChange = AutoActionFavorChange;
		int increaseRate = AutoActionFavorIncreaseRate;
		Location location = Character.GetLocation();
		List<MapBlockData> blocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		List<GameData.Domains.Character.Character> memberCharacters = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		memberCharacters.Clear();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, blocks, 2, includeCenter: true);
		foreach (MapBlockData block in blocks)
		{
			if (block.CharacterSet == null)
			{
				continue;
			}
			foreach (int charId in block.CharacterSet)
			{
				if (Character.GetId() != charId)
				{
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
					if (character.IsInteractableAsIntelligentCharacter())
					{
						memberCharacters.Add(character);
					}
				}
			}
		}
		context.AdvanceMonthRelatedData.Blocks.Release(ref blocks);
		LifeRecordCollection c = DomainManager.LifeRecord.GetLifeRecordCollection();
		int date = DomainManager.World.GetCurrDate();
		for (int i = ChickenUpgradeTotalCount(context); i > 0; i--)
		{
			int remainCount = affectCount;
			CollectionUtils.Shuffle(context.Random, memberCharacters);
			foreach (var (idA, idB) in RandomUtils.GetRandomUnrepeatedIntPair(context.Random, memberCharacters.Count))
			{
				if (--remainCount < 0)
				{
					break;
				}
				GameData.Domains.Character.Character charA = memberCharacters[idA];
				GameData.Domains.Character.Character charB = memberCharacters[idB];
				bool isIncrease = context.Random.CheckPercentProb(increaseRate);
				if (isIncrease)
				{
					DomainManager.Character.ChangeFavorabilityOptional(context, charA, charB, favorChange, 5);
					c.AddVillagerFavorabilityUp(Character.GetId(), date, charA.GetId(), charB.GetId());
					c.AddVillagerFavorabilityUpPerson(charA.GetId(), date, Character.GetId(), charB.GetId());
				}
				else
				{
					DomainManager.Character.ChangeFavorabilityOptional(context, charA, charB, -favorChange, 5);
					c.AddVillagerFavorabilityDown(Character.GetId(), date, charA.GetId(), charB.GetId());
					c.AddVillagerFavorabilityDownPerson(charA.GetId(), date, Character.GetId(), charB.GetId());
				}
				TryCreateRelations(context, charA, charB, isIncrease);
			}
		}
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(memberCharacters);
	}

	private bool TryCreateRelations(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character relatedChar, bool isIncrease)
	{
		return (isIncrease ? HandleMakeFriend(context, character, relatedChar) : HandleMakeEnemy(context, character, relatedChar)) || HandleAdore(context, character, relatedChar) || HandleMarriage(context, character, relatedChar) || HandleSwornBrotherAndSister(context, character, relatedChar) || HandleAdoption(context, character, relatedChar) || HandleAdoption(context, relatedChar, character);
	}

	private bool CheckRelationShouldStart(DataContext context, AiRelationsItem relationCfg, GameData.Domains.Character.Character character, GameData.Domains.Character.Character relatedChar, bool useMax = true)
	{
		RelatedCharacter relation = DomainManager.Character.GetRelation(character.GetId(), relatedChar.GetId());
		sbyte sectFavorability = DomainManager.Organization.GetSectFavorability(character.GetOrganizationInfo().OrgTemplateId, relatedChar.GetOrganizationInfo().OrgTemplateId);
		int prob = AiHelper.Relation.GetStartOrEndRelationChance(relationCfg, character, relatedChar, relation.RelationType, sectFavorability);
		relation = DomainManager.Character.GetRelation(relatedChar.GetId(), character.GetId());
		sectFavorability = DomainManager.Organization.GetSectFavorability(relatedChar.GetOrganizationInfo().OrgTemplateId, character.GetOrganizationInfo().OrgTemplateId);
		prob = (useMax ? new Func<int, int, int>(Math.Max) : new Func<int, int, int>(Math.Min))(prob, AiHelper.Relation.GetStartOrEndRelationChance(relationCfg, relatedChar, character, relation.RelationType, sectFavorability));
		return context.Random.CheckPercentProb(prob);
	}

	private bool HandleMakeFriend(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character relatedChar)
	{
		int currDate = DomainManager.World.GetCurrDate();
		Location location = Character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int villageHeadCharId = Character.GetId();
		int charId = character.GetId();
		int relatedCharId = relatedChar.GetId();
		if (!AiHelper.Relation.CanStartRelation(character, relatedChar, 8192) || !AiHelper.Relation.CanStartRelation(relatedChar, character, 8192))
		{
			return false;
		}
		if (!CheckRelationShouldStart(context, AiRelations.DefValue.StartFriendRelation, character, relatedChar))
		{
			return false;
		}
		sbyte behaviorType = character.GetBehaviorType();
		GameData.Domains.Character.Character.ApplyBecomeFriend(context, character, relatedChar, behaviorType, selfIsTaiwuPeople: true, targetIsTaiwuPeople: true);
		lifeRecordCollection.AddVillagerMakeFriends(villageHeadCharId, currDate, charId, relatedCharId, location);
		return true;
	}

	private bool HandleMakeEnemy(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character relatedChar)
	{
		int currDate = DomainManager.World.GetCurrDate();
		Location location = Character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int villageHeadCharId = Character.GetId();
		int charId = character.GetId();
		int relatedCharId = relatedChar.GetId();
		if (!AiHelper.Relation.CanStartRelation(character, relatedChar, 32768))
		{
			return false;
		}
		if (!CheckRelationShouldStart(context, AiRelations.DefValue.StartEnemyRelation, character, relatedChar))
		{
			return false;
		}
		GameData.Domains.Character.Character.ApplyAddRelation_Enemy(context, character, relatedChar, selfIsTaiwuPeople: true, 0);
		lifeRecordCollection.AddVillagerMakeEnemy(villageHeadCharId, currDate, charId, relatedCharId, location);
		return true;
	}

	private bool HandleAdore(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character relatedChar)
	{
		int currDate = DomainManager.World.GetCurrDate();
		Location location = Character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int villageHeadCharId = Character.GetId();
		sbyte behaviorType = character.GetBehaviorType();
		if (character.GetAgeGroup() != 2)
		{
			return false;
		}
		if (relatedChar.GetAgeGroup() != 2)
		{
			return false;
		}
		int charId = character.GetId();
		int relatedCharId = relatedChar.GetId();
		RelatedCharacter selfToTarget = DomainManager.Character.GetRelation(charId, relatedCharId);
		RelatedCharacter targetToSelf = DomainManager.Character.GetRelation(relatedCharId, charId);
		if (!CheckRelationShouldStart(context, AiRelations.DefValue.StartAdoredRelation, character, relatedChar, useMax: false))
		{
			return false;
		}
		bool selfToTargetHasRelation = RelationType.HasRelation(selfToTarget.RelationType, 16384);
		bool targetToSelfHasRelation = RelationType.HasRelation(targetToSelf.RelationType, 16384);
		if (selfToTargetHasRelation && targetToSelfHasRelation)
		{
			return false;
		}
		bool selfToTargetCanStartOrStartedRelation = selfToTargetHasRelation || AiHelper.Relation.CanStartRelation(character, relatedChar, 16384);
		bool targetToSelfCanStartOrStartedRelation = targetToSelfHasRelation || AiHelper.Relation.CanStartRelation(relatedChar, character, 16384);
		if (!(selfToTargetCanStartOrStartedRelation && targetToSelfCanStartOrStartedRelation))
		{
			return false;
		}
		int probToCheck = Math.Min(selfToTargetHasRelation ? 100 : AiHelper.Relation.GetStartRelationSuccessRate_Adored(character, relatedChar, selfToTarget, targetToSelf), targetToSelfHasRelation ? 100 : AiHelper.Relation.GetStartRelationSuccessRate_Adored(relatedChar, character, targetToSelf, selfToTarget));
		if (!context.Random.CheckPercentProb(probToCheck))
		{
			return false;
		}
		GameData.Domains.Character.Character.ApplyAddRelation_Adore(context, character, relatedChar, behaviorType, targetLovesBack: true, selfIsTaiwuPeople: true, targetIsTaiwuPeople: true);
		lifeRecordCollection.AddVillagerConfessLoveSucceed(villageHeadCharId, currDate, charId, relatedCharId, location);
		return true;
	}

	private bool HandleMarriage(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character relatedChar)
	{
		int currDate = DomainManager.World.GetCurrDate();
		Location location = Character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int villageHeadCharId = Character.GetId();
		sbyte behaviorType = character.GetBehaviorType();
		if (character.GetAgeGroup() != 2)
		{
			return false;
		}
		if (relatedChar.GetAgeGroup() != 2)
		{
			return false;
		}
		if (!character.OrgAndMonkTypeAllowMarriage())
		{
			return false;
		}
		if (!relatedChar.OrgAndMonkTypeAllowMarriage())
		{
			return false;
		}
		int charId = character.GetId();
		int relatedCharId = relatedChar.GetId();
		if (!AiHelper.Relation.CanStartRelation(character, relatedChar, 1024))
		{
			return false;
		}
		if (!CheckRelationShouldStart(context, AiRelations.DefValue.StartHusbandOrWifeRelation, character, relatedChar))
		{
			return false;
		}
		RelatedCharacter selfToTarget = DomainManager.Character.GetRelation(charId, relatedCharId);
		RelatedCharacter targetToSelf = DomainManager.Character.GetRelation(relatedCharId, charId);
		int probToCheck = Math.Max(AiHelper.Relation.GetStartRelationSuccessRate_HusbandOrWife(character, relatedChar, selfToTarget, targetToSelf), AiHelper.Relation.GetStartRelationSuccessRate_HusbandOrWife(relatedChar, character, targetToSelf, selfToTarget));
		if (!context.Random.CheckPercentProb(probToCheck))
		{
			return false;
		}
		GameData.Domains.Character.Character.ApplyBecomeHusbandOrWife(context, character, relatedChar, behaviorType, succeed: true, selfIsTaiwuPeople: true, targetIsTaiwuPeople: true);
		lifeRecordCollection.AddVillagerGetMarried(villageHeadCharId, currDate, charId, relatedCharId, location);
		return true;
	}

	private bool HandleSwornBrotherAndSister(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character relatedChar)
	{
		int currDate = DomainManager.World.GetCurrDate();
		Location location = Character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int villageHeadCharId = Character.GetId();
		int charId = character.GetId();
		int relatedCharId = relatedChar.GetId();
		if (!AiHelper.Relation.CanStartRelation(character, relatedChar, 512))
		{
			return false;
		}
		if (!CheckRelationShouldStart(context, AiRelations.DefValue.StartSwornBrotherOrSisterRelation, character, relatedChar))
		{
			return false;
		}
		RelatedCharacter selfToTarget = DomainManager.Character.GetRelation(charId, relatedCharId);
		RelatedCharacter targetToSelf = DomainManager.Character.GetRelation(relatedCharId, charId);
		bool selfToTargetHasRelation = RelationType.HasRelation(selfToTarget.RelationType, 16384);
		bool targetToSelfHasRelation = RelationType.HasRelation(targetToSelf.RelationType, 16384);
		if (selfToTargetHasRelation || targetToSelfHasRelation)
		{
			return false;
		}
		int probToCheck = Math.Max(AiHelper.Relation.GetStartRelationSuccessRate_HusbandOrWife(character, relatedChar, selfToTarget, targetToSelf), AiHelper.Relation.GetStartRelationSuccessRate_HusbandOrWife(relatedChar, character, targetToSelf, selfToTarget));
		if (!context.Random.CheckPercentProb(probToCheck))
		{
			return false;
		}
		sbyte behaviorType = character.GetBehaviorType();
		GameData.Domains.Character.Character.ApplyBecomeSwornBrotherOrSister(context, character, relatedChar, behaviorType, selfIsTaiwuPeople: true, targetIsTaiwuPeople: true);
		lifeRecordCollection.AddVillagerBecomeBrothers(villageHeadCharId, currDate, charId, relatedCharId, location);
		return true;
	}

	private bool HandleAdoption(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character relatedChar)
	{
		int currDate = DomainManager.World.GetCurrDate();
		Location location = Character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int villageHeadCharId = Character.GetId();
		int charId = character.GetId();
		int relatedCharId = relatedChar.GetId();
		if (!AiHelper.Relation.CanStartRelation(character, relatedChar, 128) && !AiHelper.Relation.CanStartRelation(relatedChar, character, 128))
		{
			return false;
		}
		if (!CheckRelationShouldStart(context, AiRelations.DefValue.AdoptingRelation, character, relatedChar))
		{
			return false;
		}
		sbyte behaviorType = character.GetBehaviorType();
		GameData.Domains.Character.Character.ApplyAddRelation_AdoptiveChild(context, character, relatedChar, behaviorType, selfIsTaiwuPeople: true, targetIsTaiwuPeople: true);
		lifeRecordCollection.AddVillagerAdopt(villageHeadCharId, currDate, charId, relatedCharId, location);
		return true;
	}

	void IVillagerRoleArrangementExecutor.ExecuteArrangementAction(DataContext context)
	{
		if (TryGetWorkingStateCustomizeKey(out var _))
		{
			GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
			bool removedAny;
			int authorityCost = GetAuthorityCost(removeExceeded: true, out removedAny);
			taiwuChar.ChangeResource(context, 7, -authorityCost);
		}
	}

	public int GetAuthorityCost(bool removeExceeded, out bool removedAny)
	{
		removedAny = false;
		if (!TryGetWorkingStateCustomizeKey(out var key))
		{
			return 0;
		}
		(sbyte stateTemplateId, bool isSect) tuple = PunishmentSeverityCustomizeData.DecodePunishmentSeverityCustomizeKey(key);
		sbyte stateTemplateId = tuple.stateTemplateId;
		bool isSect = tuple.isSect;
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		int totalAuthority = taiwuChar.GetResource(7);
		int authorityCost = 0;
		if (DomainManager.Organization.TryGetElement_CityPunishmentSeverityCustomizeDict(key, out var punishmentSeverityCustomize))
		{
			List<PunishmentSeverityCustomizeData> items = punishmentSeverityCustomize.Items;
			if (items != null && items.Count > 0)
			{
				for (int index = punishmentSeverityCustomize.Items.Count - 1; index >= 0; index--)
				{
					PunishmentSeverityCustomizeData customSeverityData = punishmentSeverityCustomize.Items[index];
					PunishmentTypeItem punishmentType = PunishmentType.Instance[customSeverityData.PunishmentTypeTemplateId];
					sbyte originalSeverity = punishmentType.GetSeverity(stateTemplateId, isSect);
					int diff = Math.Abs(originalSeverity - customSeverityData.CustomizedPunishmentSeverityTemplateId);
					if (diff > GlobalConfig.Instance.ModifySeverityDefaultRange)
					{
						int baseCost = (originalSeverity + 1) * GlobalConfig.Instance.ModifySeverityCostFactor;
						int currCost = CalcModificationAuthorityCost(baseCost);
						if (removeExceeded && currCost + authorityCost > totalAuthority)
						{
							punishmentSeverityCustomize.Items.RemoveAt(index);
							removedAny = true;
						}
						else
						{
							authorityCost += currCost;
						}
					}
				}
			}
		}
		return authorityCost;
	}

	public bool TryGetWorkingStateCustomizeKey(out short key)
	{
		key = 0;
		if (WorkData == null || WorkData.AreaId < 0)
		{
			return false;
		}
		short areaTemplateId = DomainManager.Map.GetElement_Areas(WorkData.AreaId).GetTemplateId();
		sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(WorkData.AreaId);
		MapStateItem stateConfig = MapState.Instance[stateTemplateId];
		if (stateConfig.MainAreaID == areaTemplateId)
		{
			key = PunishmentSeverityCustomizeData.GetPunishmentSeverityCustomizeKey(stateTemplateId, isSect: false);
			return true;
		}
		if (stateConfig.SectAreaID == areaTemplateId)
		{
			key = PunishmentSeverityCustomizeData.GetPunishmentSeverityCustomizeKey(stateTemplateId, isSect: true);
			return true;
		}
		return false;
	}

	public int CalcModificationAuthorityCost(int baseCost)
	{
		return Math.Max(0, VillagerRoleFormula.DefValue.VillageHeadWorkMonthlyAuthorityCost.Calculate(baseCost, Character.GetLifeSkillAttainment(4)));
	}

	public override IVillagerRoleArrangementDisplayData GetArrangementDisplayData()
	{
		return new TaiwuEnvoyDisplayData
		{
			SpecialRuleCount = ArrangementSpecialRuleCount,
			MonthlyAuthorityCost = CalcModificationAuthorityCost(100)
		};
	}
}
