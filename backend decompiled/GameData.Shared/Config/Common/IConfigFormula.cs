using System;
using GameData;
using Redzen.Random;

namespace Config.Common;

public interface IConfigFormula
{
	static IRandomSource Random => ExternalDataBridge.Context.Random;

	int Calculate();

	int Calculate(int arg0);

	int Calculate(int arg0, int arg1);

	int Calculate(int arg0, int arg1, int arg2);

	ArgumentException ThrowArgCountException(int argCount);
}
public interface IConfigFormula<TFormulaType> : IConfigFormula where TFormulaType : Enum
{
	TFormulaType ImplType { get; }

	int Calculate(TFormulaType type);

	int Calculate(TFormulaType type, int arg0);

	int Calculate(TFormulaType type, int arg0, int arg1);

	int Calculate(TFormulaType type, int arg0, int arg1, int arg2);

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
