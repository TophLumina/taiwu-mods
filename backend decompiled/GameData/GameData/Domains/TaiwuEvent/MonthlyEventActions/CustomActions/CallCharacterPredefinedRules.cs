using System;
using GameData.Domains.Character;
using GameData.Domains.Character.Filters;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions.CustomActions;

[Obsolete]
public static class CallCharacterPredefinedRules
{
	[Obsolete]
	public static bool MatchParticipateCharacter_ContestForTaiwuBride(GameData.Domains.Character.Character character)
	{
		if (!CharacterMatchers.MatchNotCalledByAdventure(character))
		{
			return false;
		}
		if (!CharacterMatchers.MatchDisplayingAge(character, 16, 50))
		{
			return false;
		}
		if (!CharacterMatchers.MatchMaritalStatus(character, isMarried: false))
		{
			return false;
		}
		if (!CharacterMatchers.MatchOrganizationType(character, 0, 2))
		{
			return false;
		}
		if (!CharacterMatchers.MatchOrgMemberAllowMarriage(character))
		{
			return false;
		}
		if (CharacterMatchers.MatchIsMonk(character))
		{
			return false;
		}
		sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
		if (!CharacterMatchers.MatchGrade(character, 0, xiangshuLevel))
		{
			return false;
		}
		return true;
	}

	[Obsolete]
	public static bool MatchParticipateCharacter_SectMartialArtContest(GameData.Domains.Character.Character character, sbyte orgTemplateId)
	{
		if (!CharacterMatchers.MatchNotCalledByAdventure(character))
		{
			return false;
		}
		if (character.GetOrganizationInfo().OrgTemplateId != orgTemplateId)
		{
			return false;
		}
		sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
		sbyte minGrade = (sbyte)((xiangshuLevel > 6) ? 6 : 0);
		sbyte maxGrade = (sbyte)(minGrade + 1);
		if (!CharacterMatchers.MatchGrade(character, minGrade, maxGrade))
		{
			return false;
		}
		return true;
	}

	[Obsolete]
	public static bool MatchMajorCharacter_SectMartialArtContest(GameData.Domains.Character.Character character, sbyte orgTemplateId)
	{
		if (!CharacterMatchers.MatchNotCalledByAdventure(character))
		{
			return false;
		}
		if (!CharacterMatchers.MatchOrganization(character, orgTemplateId))
		{
			return false;
		}
		sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
		sbyte grade = (sbyte)(xiangshuLevel + 2);
		if (!CharacterMatchers.MatchGrade(character, grade, grade))
		{
			return false;
		}
		return true;
	}

	[Obsolete]
	public static bool MatchParticipateCharacter_CombatSkillTypeContest(GameData.Domains.Character.Character character, sbyte combatSkillType)
	{
		throw new NotImplementedException();
	}

	[Obsolete]
	public static bool MatchParticipateCharacter_LifeSkillTypeContest(GameData.Domains.Character.Character character, sbyte lifeSkillType)
	{
		throw new NotImplementedException();
	}
}
