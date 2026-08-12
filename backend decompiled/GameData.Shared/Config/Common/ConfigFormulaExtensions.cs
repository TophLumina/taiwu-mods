using System;

namespace Config.Common;

/// <summary>
/// 通用的配置公式实现调用
/// </summary>
public static class ConfigFormulaExtensions
{
	/// <summary>
	/// 自动从桥接器中获取参数的公式计算
	/// </summary>
	/// <param name="formula"></param>
	/// <param name="bridge"></param>
	/// <typeparam name="TFormula"></typeparam>
	/// <typeparam name="TArgType"></typeparam>
	/// <returns></returns>
	public static int Calculate<TFormula, TArgType>(this TFormula formula, IFormulaContextBridge<TArgType> bridge) where TFormula : class, IConfigFormula, IFormulaArgTypeSource<TArgType> where TArgType : Enum
	{
		return bridge.Calculate(formula, formula.ArgTypes);
	}

	/// <summary>
	/// 无参数计算公式
	/// </summary>
	public static int Calculate(this IConfigFormula formula)
	{
		return formula.Calculate();
	}

	/// <summary>
	/// 1参数计算公式
	/// </summary>
	public static int Calculate(this IConfigFormula formula, int arg0)
	{
		return formula.Calculate(arg0);
	}

	/// <summary>
	/// 2参数计算公式
	/// </summary>
	public static int Calculate(this IConfigFormula formula, int arg0, int arg1)
	{
		return formula.Calculate(arg0, arg1);
	}

	/// <summary>
	/// 3参数计算公式
	/// </summary>
	public static int Calculate(this IConfigFormula formula, int arg0, int arg1, int arg2)
	{
		return formula.Calculate(arg0, arg1, arg2);
	}
}
