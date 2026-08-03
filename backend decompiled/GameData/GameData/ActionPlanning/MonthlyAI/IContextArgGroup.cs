namespace GameData.ActionPlanning.MonthlyAI;

public interface IContextArgGroup
{
	PlanningContextArg? GetArgOfType(EPlanningParameterType type);

	void SetArgOfType(EPlanningParameterType type, PlanningContextArg arg);

	void RemoveArgOfType(EPlanningParameterType type);
}
