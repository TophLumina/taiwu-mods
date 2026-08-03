namespace GameData.ActionPlanning.State;

public enum EStateCondition : sbyte
{
	Equal,
	NotEqual,
	GreaterThan,
	GreaterOrEqual,
	LessThan,
	LessOrEqual,
	Enabled,
	Disabled,
	GreaterThanPercent,
	GreaterOrEqualPercent,
	LessThanPercent,
	LessOrEqualPercent
}
