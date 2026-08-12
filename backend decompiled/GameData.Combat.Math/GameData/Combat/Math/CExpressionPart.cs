using System;

namespace GameData.Combat.Math;

public struct CExpressionPart
{
	public EExpressionPartType Type;

	public int Value;

	public bool IsNumber => Type != EExpressionPartType.Operator;

	public int ToNumber(IExpressionConverter converter)
	{
		return Type switch
		{
			EExpressionPartType.Number => Value, 
			EExpressionPartType.Personality => converter.GetPersonalityValue(Value), 
			EExpressionPartType.ConsummateLevel => converter.GetConsummateLevel(), 
			EExpressionPartType.BehaviorType => converter.GetBehaviorType(), 
			_ => throw new Exception($"Not support type {Type}"), 
		};
	}
}
