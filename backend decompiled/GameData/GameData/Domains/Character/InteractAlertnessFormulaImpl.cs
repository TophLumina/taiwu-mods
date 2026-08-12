using System;
using System.Runtime.CompilerServices;
using Config;

namespace GameData.Domains.Character;

public static class InteractAlertnessFormulaImpl
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Calculate(int templateId)
	{
		return InteractAlertnessFormula.Instance[templateId].Calculate();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Calculate(int templateId, int arg0)
	{
		return InteractAlertnessFormula.Instance[templateId].Calculate(arg0);
	}

	public static int Calculate(this InteractAlertnessFormulaItem formulaCfg)
	{
		EInteractAlertnessFormulaType type = formulaCfg.Type;
		if (1 == 0)
		{
		}
		if (type == EInteractAlertnessFormulaType.Formula0)
		{
			int num = SeniorityFormula0(formulaCfg.Constants);
			if (1 == 0)
			{
			}
			int value = num;
			return formulaCfg.ClampValue(value);
		}
		throw ThrowArgCountException(formulaCfg, 0);
	}

	public static int Calculate(this InteractAlertnessFormulaItem formulaCfg, int arg0)
	{
		EInteractAlertnessFormulaType type = formulaCfg.Type;
		if (1 == 0)
		{
		}
		int num = type switch
		{
			EInteractAlertnessFormulaType.Formula1 => SeniorityFormula1(formulaCfg.Constants, arg0), 
			EInteractAlertnessFormulaType.Formula2 => SeniorityFormula2(formulaCfg.Constants, arg0), 
			EInteractAlertnessFormulaType.Formula3 => SeniorityFormula3(formulaCfg.Constants, arg0), 
			_ => throw ThrowArgCountException(formulaCfg, 1), 
		};
		if (1 == 0)
		{
		}
		int value = num;
		return formulaCfg.ClampValue(value);
	}

	private static int ClampValue(this InteractAlertnessFormulaItem formulaCfg, int value)
	{
		return (formulaCfg.MaxValue > 0 && value > formulaCfg.MaxValue) ? formulaCfg.MaxValue : value;
	}

	private static ArgumentException ThrowArgCountException(InteractAlertnessFormulaItem formulaCfg, int argCount)
	{
		return new ArgumentException($"Formula {formulaCfg.TemplateId}'s type {formulaCfg.Type} doesn't match arg count {argCount}");
	}

	private static int SeniorityFormula0(int[] constants)
	{
		return constants[0];
	}

	private static int SeniorityFormula1(int[] constants, int arg0)
	{
		return constants[0] * arg0;
	}

	private static int SeniorityFormula2(int[] constants, int arg0)
	{
		return constants[0] * (arg0 + constants[1]) * constants[2] / constants[3];
	}

	private static int SeniorityFormula3(int[] constants, int arg0)
	{
		return arg0 * constants[0] * constants[1] / constants[2];
	}
}
