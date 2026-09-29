using System;

namespace Config.Common;

public static class ConfigFormulaExtensions
{
	public static int Calculate<TFormula, TArgType>(this TFormula formula, IFormulaContextBridge<TArgType> bridge) where TFormula : class, IConfigFormula, IFormulaArgTypeSource<TArgType> where TArgType : Enum
	{
		return bridge.Calculate(formula, formula.ArgTypes);
	}

	public static int Calculate(this IConfigFormula formula)
	{
		return formula.Calculate();
	}

	public static int Calculate(this IConfigFormula formula, int arg0)
	{
		return formula.Calculate(arg0);
	}

	public static int Calculate(this IConfigFormula formula, int arg0, int arg1)
	{
		return formula.Calculate(arg0, arg1);
	}

	public static int Calculate(this IConfigFormula formula, int arg0, int arg1, int arg2)
	{
		return formula.Calculate(arg0, arg1, arg2);
	}
}
