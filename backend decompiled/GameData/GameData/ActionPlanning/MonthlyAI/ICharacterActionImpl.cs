using Config;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.ActionPlanning.MonthlyAI;

public interface ICharacterActionImpl : ISerializableGameData
{
	int PhaseCount => 0;

	bool IgnoreConfigChanges => false;

	static bool CanCreate(GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup)
	{
		return true;
	}

	static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		return true;
	}

	static ICharacterActionImpl TryCreateActionImpl(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, PlanningActionItem actionTemplate)
	{
		return null;
	}

	static bool CheckLifeRecords(PlanningActionItem config)
	{
		return true;
	}

	bool OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		return true;
	}

	bool CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return true;
	}

	bool CheckAtTargetLocation(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		if (actionData.TargetLocation.IsValid())
		{
			return character.GetLocation() == actionData.TargetLocation;
		}
		if (actionData.TargetCharId >= 0)
		{
			GameData.Domains.Character.Character targetChar = actionData.TargetChar;
			if (targetChar == null)
			{
				return false;
			}
			if (character.GetLocation() != targetChar.GetLocation())
			{
				return false;
			}
		}
		return true;
	}

	bool MoveToTargetLocation(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		int charId = character.GetId();
		Location currLocation = character.GetLocation();
		if (!currLocation.IsValid())
		{
			return false;
		}
		Location targetLocation = actionData.GetActualTargetLocation();
		if (!targetLocation.IsValid())
		{
			return false;
		}
		int leaderId = character.GetLeaderId();
		if (leaderId >= 0 && leaderId != charId)
		{
			DomainManager.Character.LeaveGroup(context, character);
		}
		if (currLocation.AreaId != targetLocation.AreaId)
		{
			return false;
		}
		if (character.IsActiveExternalRelationState(64uL) || CharacterDomain.IsLockMovementChar(character.GetId()))
		{
			return false;
		}
		DomainManager.Character.GroupMove(context, character, targetLocation);
		return true;
	}

	void OnStart(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
	}

	void OnInterrupt(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
	}

	void OnTraveling(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
	}

	void OnCharacterDead(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
	}

	sealed bool Execute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		Tester.Assert(actionData.HasStarted);
		int phaseCount = PhaseCount;
		if (!actionData.HasArrived)
		{
			if (actionData.TargetIsTaiwu)
			{
				PreExecuteForTaiwuTarget(context, character, actionData);
			}
			else
			{
				PreExecute(context, character, actionData);
			}
			actionData.State = CharacterActionData.EActionState.Arrived;
		}
		while (actionData.CurrPhase < phaseCount)
		{
			if (!ExecutePhases(context, character, actionData))
			{
				return false;
			}
		}
		if (actionData.TargetIsTaiwu)
		{
			PostExecuteForTaiwuTarget(context, character, actionData);
		}
		else
		{
			PostExecute(context, character, actionData);
		}
		if (!IgnoreConfigChanges)
		{
			ApplyConfigChanges(context, character, actionData);
		}
		actionData.State = CharacterActionData.EActionState.Finished;
		return true;
	}

	private void ApplyConfigChanges(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		PlanningActionItem template = actionData.Template;
		int selfCharId = character.GetId();
		int[] targetCharIds = actionData.TargetCharIds;
		bool hasTarget = targetCharIds != null && targetCharIds.Length > 0;
		if (DomainManager.Character.IsCharacterAlive(selfCharId))
		{
			if (template.AuthorityChange != 0)
			{
				character.ChangeResource(context, 7, template.AuthorityChange);
			}
			if (template.ExpChange != 0)
			{
				character.ChangeExp(context, template.ExpChange);
			}
			if (!hasTarget)
			{
				if (template.HappinessChange != 0)
				{
					character.ChangeHappiness(context, template.HappinessChange);
				}
				if (template.XiangshuInfectionChange != 0)
				{
					character.ChangeXiangshuInfection(context, template.XiangshuInfectionChange);
				}
			}
		}
		if (!hasTarget)
		{
			return;
		}
		foreach (GameData.Domains.Character.Character targetChar in actionData.GetTargetCharacters())
		{
			if (template.FavorabilityChange != 0)
			{
				DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, character, template.FavorabilityChange);
			}
			if (template.HappinessChange != 0)
			{
				targetChar.ChangeHappiness(context, template.HappinessChange);
			}
			if (template.XiangshuInfectionChange != 0)
			{
				character.ChangeXiangshuInfection(context, template.XiangshuInfectionChange);
			}
		}
	}

	void PreExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
	}

	private bool ExecutePhases(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		int phaseCount = PhaseCount;
		while (actionData.CurrPhase < phaseCount)
		{
			if (!OnExecutePhase(context, character, actionData))
			{
				return false;
			}
			actionData.CurrPhase++;
		}
		return true;
	}

	bool OnExecutePhase(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return false;
	}

	protected void PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
	}

	protected void PreExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		PreExecute(context, selfChar, actionData);
	}

	protected void PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		PostExecute(context, selfChar, actionData);
	}
}
