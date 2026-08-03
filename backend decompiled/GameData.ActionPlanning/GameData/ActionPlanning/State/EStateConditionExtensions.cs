namespace GameData.ActionPlanning.State;

public static class EStateConditionExtensions
{
	public static bool IsPercent(this EStateCondition condition)
	{
		return condition >= EStateCondition.GreaterThanPercent;
	}
}
