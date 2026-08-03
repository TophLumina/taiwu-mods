namespace GameData.ActionPlanning.State;

public static class StateConditionHelper
{
	public static bool Check(EStateCondition condition, int currValue, int expectedValue)
	{
		return condition switch
		{
			EStateCondition.Equal => currValue == expectedValue, 
			EStateCondition.NotEqual => currValue != expectedValue, 
			EStateCondition.GreaterThan => currValue > expectedValue, 
			EStateCondition.GreaterOrEqual => currValue >= expectedValue, 
			EStateCondition.LessThan => currValue < expectedValue, 
			EStateCondition.LessOrEqual => currValue <= expectedValue, 
			EStateCondition.Enabled => currValue == 1, 
			EStateCondition.Disabled => currValue == 0, 
			EStateCondition.GreaterThanPercent => currValue > expectedValue, 
			EStateCondition.GreaterOrEqualPercent => currValue >= expectedValue, 
			EStateCondition.LessThanPercent => currValue < expectedValue, 
			EStateCondition.LessOrEqualPercent => currValue <= expectedValue, 
			_ => throw new ActionPlanningException($"Invalid condition type {condition}"), 
		};
	}
}
