using System;
using GameData;
using Redzen.Random;

namespace Config.Common;

/// <summary>
/// 公式接口
/// </summary>
public interface IConfigFormula
{
	/// <summary>
	/// 获取随机源
	/// </summary>
	static IRandomSource Random => ExternalDataBridge.Context.Random;

	/// <summary>
	/// 无参数计算公式
	/// </summary>
	int Calculate();

	/// <summary>
	/// 1参数计算公式
	/// </summary>
	int Calculate(int arg0);

	/// <summary>
	/// 2参数计算公式
	/// </summary>
	int Calculate(int arg0, int arg1);

	/// <summary>
	/// 3参数计算公式
	/// </summary>
	int Calculate(int arg0, int arg1, int arg2);

	/// <summary>
	/// 生成参数数量错误异常
	/// </summary>
	/// <param name="argCount">参数数量</param>
	/// <returns>异常对象</returns>
	ArgumentException ThrowArgCountException(int argCount);
}
/// <summary>
/// 以具体实现类型枚举为泛型参数的公式接口
/// </summary>
/// <typeparam name="TFormulaType"></typeparam>
public interface IConfigFormula<TFormulaType> : IConfigFormula where TFormulaType : Enum
{
	/// <summary>
	/// 实现类型
	/// </summary>
	TFormulaType ImplType { get; }

	/// <summary>
	/// 无参数计算公式
	/// </summary>
	int Calculate(TFormulaType type);

	/// <summary>
	/// 1参数计算公式
	/// </summary>
	int Calculate(TFormulaType type, int arg0);

	/// <summary>
	/// 2参数计算公式
	/// </summary>
	int Calculate(TFormulaType type, int arg0, int arg1);

	/// <summary>
	/// 3参数计算公式
	/// </summary>
	int Calculate(TFormulaType type, int arg0, int arg1, int arg2);

	/// <summary>
	/// 限制值的范围
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	int ClampValue(int value);

	int IConfigFormula.Calculate()
	{
		int value = Calculate(ImplType);
		return ClampValue(value);
	}

	int IConfigFormula.Calculate(int arg0)
	{
		int value = Calculate(ImplType, arg0);
		return ClampValue(value);
	}

	int IConfigFormula.Calculate(int arg0, int arg1)
	{
		int value = Calculate(ImplType, arg0, arg1);
		return ClampValue(value);
	}

	int IConfigFormula.Calculate(int arg0, int arg1, int arg2)
	{
		int value = Calculate(ImplType, arg0, arg1, arg2);
		return ClampValue(value);
	}
}
