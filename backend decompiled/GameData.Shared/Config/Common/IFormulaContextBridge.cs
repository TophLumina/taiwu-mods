using System;

namespace Config.Common;

/// <summary>
/// 公式与数据上下文的桥接，可用于自动获取公式参数进行计算
/// </summary>
/// <typeparam name="TArgType">公式参数类型的枚举</typeparam>
public interface IFormulaContextBridge<in TArgType> where TArgType : Enum
{
	/// <summary>
	/// 获取指定类型的参数
	/// </summary>
	/// <param name="argType">公式参数类型</param>
	/// <returns></returns>
	int GetArgument(TArgType argType);

	/// <summary>
	/// 计
	/// </summary>
	/// <param name="formula"></param>
	/// <param name="argTypes"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
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
