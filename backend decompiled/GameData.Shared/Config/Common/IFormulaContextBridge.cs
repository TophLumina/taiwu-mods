using System;

namespace Config.Common;

public interface IFormulaContextBridge<in TArgType> where TArgType : Enum
{
	int GetArgument(TArgType argType);

	int Calculate(IConfigFormula formula, TArgType[] argTypes)
	{
		Span<int> argValues = stackalloc int[argTypes.Length];
		for (int i = 0; i < argTypes.Length; i++)
		{
			argValues[i] = GetArgument(argTypes[i]);
		}
		return argTypes.Length switch
		{
			1 => formula.Calculate(argValues[0]), 
			2 => formula.Calculate(argValues[0], argValues[1]), 
			3 => formula.Calculate(argValues[0], argValues[1], argValues[2]), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}
}
