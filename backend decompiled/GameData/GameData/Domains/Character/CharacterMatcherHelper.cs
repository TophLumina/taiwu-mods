using System;
using Config;
using GameData.Domains.Character.Relation;
using GameData.Domains.Organization;

namespace GameData.Domains.Character;

public static class CharacterMatcherHelper
{
	public static bool Match(this CharacterMatcherItem matcherItem, Character character)
	{
		if (character.GetCreatingType() != 1)
		{
			return false;
		}
		if (!matcherItem.AgeType.Match(character))
		{
			return false;
		}
		if (!matcherItem.GenderType.Match(character))
		{
			return false;
		}
		if (!matcherItem.IdentityType.Match(character))
		{
			return false;
		}
		int[] favorRange = matcherItem.FavorRange;
		if (favorRange != null && favorRange.Length == 2 && !CheckFavorabilityToTaiwuInRange(character, matcherItem.FavorRange))
		{
			return false;
		}
		if (matcherItem.Organization >= 0 && character.GetOrganizationInfo().OrgTemplateId != matcherItem.Organization)
		{
			return false;
		}
		if (matcherItem.MerchantType >= 0 && (!DomainManager.Extra.TryGetMerchantCharToType(character.GetId(), out var merchantType) || matcherItem.MerchantType != merchantType))
		{
			return false;
		}
		ECharacterMatcherSubCondition[] subConditions = matcherItem.SubConditions;
		if (subConditions == null || subConditions.Length <= 0)
		{
			return true;
		}
		for (int i = 0; i < matcherItem.SubConditions.Length; i++)
		{
			if (!matcherItem.SubConditions[i].Match(character))
			{
				return false;
			}
		}
		return true;
	}

	public static bool Match(this ECharacterMatcherAgeType ageType, Character character)
	{
		if (1 == 0)
		{
		}
		bool result = ageType switch
		{
			ECharacterMatcherAgeType.NotRestricted => true, 
			ECharacterMatcherAgeType.Baby => character.GetAgeGroup() == 0, 
			ECharacterMatcherAgeType.Child => character.GetAgeGroup() == 1, 
			ECharacterMatcherAgeType.Adult => character.GetAgeGroup() == 2, 
			ECharacterMatcherAgeType.NonBaby => character.GetAgeGroup() != 0, 
			_ => throw new ArgumentOutOfRangeException("ageType", ageType, null), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static bool Match(this ECharacterMatcherGenderType genderType, Character character)
	{
		if (1 == 0)
		{
		}
		bool result = genderType switch
		{
			ECharacterMatcherGenderType.NotRestricted => true, 
			ECharacterMatcherGenderType.Female => character.GetGender() == 0, 
			ECharacterMatcherGenderType.Male => character.GetGender() == 1, 
			ECharacterMatcherGenderType.DisplayFemale => character.GetDisplayingGender() == 0, 
			ECharacterMatcherGenderType.DisplayMale => character.GetDisplayingGender() == 1, 
			_ => throw new ArgumentOutOfRangeException("genderType", genderType, null), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static bool Match(this ECharacterMatcherIdentityType identityType, Character character)
	{
		if (1 == 0)
		{
		}
		bool result = identityType switch
		{
			ECharacterMatcherIdentityType.NotRestricted => true, 
			ECharacterMatcherIdentityType.Sect => OrganizationDomain.IsSect(character.GetOrganizationInfo().OrgTemplateId), 
			ECharacterMatcherIdentityType.CivilianSettlement => Config.Organization.Instance[character.GetOrganizationInfo().OrgTemplateId]?.IsCivilian ?? false, 
			ECharacterMatcherIdentityType.NotSect => !OrganizationDomain.IsSect(character.GetOrganizationInfo().OrgTemplateId), 
			ECharacterMatcherIdentityType.NotTaiwuVillage => character.GetOrganizationInfo().OrgTemplateId != 16, 
			ECharacterMatcherIdentityType.NoOrg => character.GetOrganizationInfo().OrgTemplateId == 0, 
			ECharacterMatcherIdentityType.XiangshuInfected => character.GetOrganizationInfo().OrgTemplateId == 20, 
			ECharacterMatcherIdentityType.NotXiangshuInfected => character.GetOrganizationInfo().OrgTemplateId != 20, 
			_ => throw new ArgumentOutOfRangeException("identityType", identityType, null), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static bool Match(this ECharacterMatcherSubCondition subCondition, Character character)
	{
		int result;
		switch (subCondition)
		{
		case ECharacterMatcherSubCondition.NotActingCrazy:
			return !DomainManager.LegendaryBook.IsCharacterActingCrazy(character) && !character.IsCompletelyInfected();
		case ECharacterMatcherSubCondition.CanBeLocated:
			return !character.IsActiveExternalRelationState(188uL) && character.GetKidnapperId() < 0 && (!character.IsInTaiwuGroup() || DomainManager.Adventure.GetAdventureTaiwu().NotInAdventure) && (character.GetLocation().IsValid() || character.IsCrossAreaTraveling());
		case ECharacterMatcherSubCondition.NotCrossAreaTraveling:
			return !character.IsCrossAreaTraveling();
		case ECharacterMatcherSubCondition.CanHaveChild:
			return character.OrgAndMonkTypeAllowMarriage();
		case ECharacterMatcherSubCondition.CanStroll:
			return OrganizationDomain.GetOrgMemberConfig(character.GetOrganizationInfo()).CanStroll;
		case ECharacterMatcherSubCondition.NotInOthersGroup:
		{
			int leaderId = character.GetLeaderId();
			return leaderId < 0 || leaderId == character.GetId();
		}
		case ECharacterMatcherSubCondition.NotAssignedWithWork:
			return !DomainManager.Taiwu.VillagerHasWork(character.GetId());
		case ECharacterMatcherSubCondition.NotTaiwu:
			return !character.IsTaiwu();
		case ECharacterMatcherSubCondition.NotInTaiwuGroup:
			return !DomainManager.Taiwu.IsInGroup(character.GetId());
		case ECharacterMatcherSubCondition.NotTaiwuFriendlyRelation:
			return !DomainManager.Character.IsCharacterRelationFriendly(DomainManager.Taiwu.GetTaiwuCharId(), character.GetId());
		case ECharacterMatcherSubCondition.NotHighestGrade:
			return character.GetInteractionGrade() != 8;
		case ECharacterMatcherSubCondition.NotLegendaryBookConsumed:
			return character.GetLegendaryBookOwnerState() != 3;
		case ECharacterMatcherSubCondition.NotInSettlementPrison:
			return !character.IsActiveExternalRelationState(32uL);
		case ECharacterMatcherSubCondition.CombatPowerTop30:
		{
			int topThousandCharacterRanking = DomainManager.Character.GetTopThousandCharacterRanking(character.GetId());
			return topThousandCharacterRanking >= 0 && topThousandCharacterRanking <= 30;
		}
		case ECharacterMatcherSubCondition.InSelfSettlement:
			if (character.GetKidnapperId() < 0 && !character.IsActiveExternalRelationState(188uL) && character.GetLocation().IsValid())
			{
				OrganizationInfo info = character.GetOrganizationInfo();
				if (info.SettlementId != -1)
				{
					result = (DomainManager.Map.IsLocationOnSettlementBlock(character.GetLocation(), info.SettlementId) ? 1 : 0);
					goto IL_024f;
				}
			}
			result = 0;
			goto IL_024f;
		case ECharacterMatcherSubCondition.NotAwakeJixiTaiwuRelated:
			return character.GetId() != DomainManager.Taiwu.GetTaiwuCharIdForJixi();
		case ECharacterMatcherSubCondition.HaveNeiliAllocation:
			return character.GetNeiliAllocation().GetTotal() > 0;
		case ECharacterMatcherSubCondition.NotSettlementGuard:
			return !character.IsTreasuryGuard();
		case ECharacterMatcherSubCondition.InSettlementInfluenceRange:
			return character.IsInRegularSettlementRange();
		case ECharacterMatcherSubCondition.NotTaiwuFamiliyRelation:
		{
			int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
			int relatedCharId = character.GetId();
			RelatedCharacter relation;
			return !DomainManager.Character.TryGetRelation(taiwuCharId, relatedCharId, out relation) || (!DomainManager.Character.HasNominalBloodRelation(taiwuCharId, relatedCharId, relation) && !RelationType.ContainBloodExclusionRelations(relation.RelationType));
		}
		case ECharacterMatcherSubCondition.CanBeTaiwu:
			return character.GetCanBeTaiwu();
		default:
			{
				throw new ArgumentOutOfRangeException("subCondition", subCondition, null);
			}
			IL_024f:
			return (byte)result != 0;
		}
	}

	private static bool CheckFavorabilityToTaiwuInRange(Character character, int[] range)
	{
		short favorability = DomainManager.Character.GetFavorability(character.GetId(), DomainManager.Taiwu.GetTaiwuCharId());
		return favorability >= range[0] && favorability < range[1];
	}

	public static bool Match(this CharacterMatcherItem matcherItem, Character character, CharacterMatcherArg arg)
	{
		if (!matcherItem.Match(character))
		{
			return false;
		}
		ECharacterMatcherTargetSubCondition[] targetSubConditions = matcherItem.TargetSubConditions;
		if (targetSubConditions == null || targetSubConditions.Length <= 0)
		{
			return true;
		}
		switch (matcherItem.TargetType)
		{
		case ECharacterMatcherTargetType.TaiwuCharacter:
			return MatchAll(matcherItem.TargetSubConditions, character, DomainManager.Taiwu.GetTaiwu());
		case ECharacterMatcherTargetType.AdventurePresetCharacter:
		{
			int targetCharId = DomainManager.Adventure.QueryAdventurePresetCharacter(arg.AdventureId, matcherItem.TargetKey);
			if (DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar))
			{
				return MatchAll(matcherItem.TargetSubConditions, character, targetChar);
			}
			return false;
		}
		default:
			return true;
		}
	}

	private static bool MatchAll(ECharacterMatcherTargetSubCondition[] targetSubConditions, Character character, Character targetChar)
	{
		foreach (ECharacterMatcherTargetSubCondition condition in targetSubConditions)
		{
			if (!condition.Match(character, targetChar))
			{
				return false;
			}
		}
		return true;
	}

	private static bool Match(this ECharacterMatcherTargetSubCondition targetSubCondition, Character character, Character targetChar)
	{
		if (1 == 0)
		{
		}
		bool result = default(bool);
		switch (targetSubCondition)
		{
		case ECharacterMatcherTargetSubCondition.TargetParent:
			result = DomainManager.Character.HasRelation(targetChar.GetId(), character.GetId(), 73);
			break;
		case ECharacterMatcherTargetSubCondition.TargetFriendOrFamily:
			result = DomainManager.Character.IsCharacterRelationFriendly(targetChar.GetId(), character.GetId());
			break;
		case ECharacterMatcherTargetSubCondition.TargetTwoWayAdored:
			result = DomainManager.Character.HasRelation(targetChar.GetId(), character.GetId(), 16384) && DomainManager.Character.HasRelation(character.GetId(), targetChar.GetId(), 16384);
			break;
		default:
			if (1 == 0)
			{
			}
			global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(targetSubCondition);
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}
}
