using GameData.Domains.Character;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class CombatSkillFunctions
{
	[EventFunction(64)]
	private static void SetCharCombatSkillPracticeLevel(EventScriptRuntime runtime, GameData.Domains.Character.Character character, short skillTemplateId, int practiceLevel)
	{
	}

	[EventFunction(601)]
	private static void AddTaiwuBreakoutStepBase(EventScriptRuntime runtime, int value)
	{
		DomainManager.Taiwu.AddNextBreakoutStepBaseBonus(runtime.Context, value);
	}

	[EventFunction(602)]
	private static void AddTaiwuBreakoutBaseSuccessRate(EventScriptRuntime runtime, int value)
	{
		DomainManager.Taiwu.AddNextBreakoutSuccessRateBonus(runtime.Context, value);
	}
}
