using GameData.Domains.Map;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class AdventureFunctions
{
	[EventFunction(145)]
	private static void CreateConfigMonthlyAction(EventScriptRuntime runtime, short monthlyActionId, short areaTemplateId)
	{
	}

	[EventFunction(67)]
	private static void CreateAdventureSite(EventScriptRuntime runtime, short adventureId, MapBlockData mapBlockData)
	{
	}

	[EventFunction(119)]
	private static void GenerateAdventureMap(EventScriptRuntime runtime, string startNodeKey)
	{
	}

	[EventFunction(124)]
	private static void ExitAdventure(EventScriptRuntime runtime, bool isAdventureCompleted, string postAdventureEvent = null)
	{
	}

	[EventFunction(125)]
	private static void FinishAdventureEvent(EventScriptRuntime runtime)
	{
	}

	[EventFunction(126)]
	private static void SelectAdventureBranch(EventScriptRuntime runtime, string branchKey)
	{
		DomainManager.Adventure.ChangeMajorEventNextNodes(runtime.Context, branchKey);
	}

	[EventFunction(144)]
	private static int GetAdventureCharacterCount(EventScriptRuntime runtime, bool isMajor, int groupId)
	{
		return isMajor ? runtime.Current.ArgBox.GetAdventureMajorCharacterCount(groupId) : runtime.Current.ArgBox.GetAdventureParticipateCharacterCount(groupId);
	}

	[EventFunction(143)]
	private static int GetAdventureCharacter(EventScriptRuntime runtime, bool isMajor, int groupId, int index)
	{
		return isMajor ? runtime.Current.ArgBox.GetAdventureMajorCharacter(groupId, index).GetId() : runtime.Current.ArgBox.GetAdventureParticipateCharacter(groupId, index).GetId();
	}
}
