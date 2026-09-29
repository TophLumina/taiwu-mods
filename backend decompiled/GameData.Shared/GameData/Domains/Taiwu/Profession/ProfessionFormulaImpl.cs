using System;
using System.Runtime.CompilerServices;
using Config;

namespace GameData.Domains.Taiwu.Profession;

public static class ProfessionFormulaImpl
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Calculate(int templateId)
	{
		return ProfessionFormula.Instance[templateId].Calculate();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Calculate(int templateId, int arg0)
	{
		return ProfessionFormula.Instance[templateId].Calculate(arg0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Calculate(int templateId, int arg0, int arg1)
	{
		return ProfessionFormula.Instance[templateId].Calculate(arg0, arg1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Calculate(int templateId, int arg0, int arg1, int arg2)
	{
		return ProfessionFormula.Instance[templateId].Calculate(arg0, arg1, arg2);
	}

	public static int Calculate(this ProfessionFormulaItem formulaCfg)
	{
		if (formulaCfg.Type == EProfessionFormulaType.SeniorityGainFormula9)
		{
			int num = SeniorityFormula9(formulaCfg.Constants);
			int value = num;
			return formulaCfg.ClampValue(value);
		}
		throw ThrowArgCountException(formulaCfg, 0);
	}

	public static int Calculate(this ProfessionFormulaItem formulaCfg, int arg0)
	{
		return formulaCfg.ClampValue(formulaCfg.Type switch
		{
			EProfessionFormulaType.SeniorityGainFormula0 => SeniorityFormula0(formulaCfg.Constants, arg0), 
			EProfessionFormulaType.SeniorityGainFormula1 => SeniorityFormula1(formulaCfg.Constants, arg0), 
			EProfessionFormulaType.SeniorityGainFormula3 => SeniorityFormula3(formulaCfg.Constants, arg0), 
			EProfessionFormulaType.SeniorityGainFormula6 => SeniorityFormula6(formulaCfg.Constants, arg0), 
			EProfessionFormulaType.SeniorityGainFormula7 => SeniorityFormula7(formulaCfg.Constants, arg0), 
			EProfessionFormulaType.SeniorityGainFormula8 => SeniorityFormula8(formulaCfg.Constants, arg0), 
			EProfessionFormulaType.SeniorityGainFormula10 => SeniorityFormula10(formulaCfg.Constants, arg0), 
			EProfessionFormulaType.SeniorityGainFormula12 => SeniorityFormula12(formulaCfg.Constants, arg0), 
			_ => throw ThrowArgCountException(formulaCfg, 1), 
		});
	}

	public static int Calculate(this ProfessionFormulaItem formulaCfg, int arg0, int arg1)
	{
		return formulaCfg.ClampValue(formulaCfg.Type switch
		{
			EProfessionFormulaType.SeniorityGainFormula2 => SeniorityFormula2(formulaCfg.Constants, arg0, arg1), 
			EProfessionFormulaType.SeniorityGainFormula4 => SeniorityFormula4(formulaCfg.Constants, arg0, arg1), 
			EProfessionFormulaType.SeniorityGainFormula11 => SeniorityFormula11(formulaCfg.Constants, arg0, arg1), 
			_ => throw ThrowArgCountException(formulaCfg, 2), 
		});
	}

	public static int Calculate(this ProfessionFormulaItem formulaCfg, int arg0, int arg1, int arg2)
	{
		if (formulaCfg.Type == EProfessionFormulaType.SeniorityGainFormula5)
		{
			int num = SeniorityFormula5(formulaCfg.Constants, arg0, arg1, arg2);
			int value = num;
			return formulaCfg.ClampValue(value);
		}
		throw ThrowArgCountException(formulaCfg, 3);
	}

	private static int ClampValue(this ProfessionFormulaItem formulaCfg, int value)
	{
		if (formulaCfg.MaxValue <= 0 || value <= formulaCfg.MaxValue)
		{
			return value;
		}
		return formulaCfg.MaxValue;
	}

	private static ArgumentException ThrowArgCountException(ProfessionFormulaItem formulaCfg, int argCount)
	{
		return new ArgumentException($"Formula {formulaCfg.TemplateId}'s type {formulaCfg.Type} doesn't match arg count {argCount}");
	}

	private static int SeniorityFormula0(int[] constants, int arg0)
	{
		return arg0;
	}

	private static int SeniorityFormula1(int[] constants, int arg0)
	{
		return constants[0] * arg0;
	}

	private static int SeniorityFormula2(int[] constants, int arg0, int arg1)
	{
		return constants[0] * arg0 * arg1;
	}

	private static int SeniorityFormula3(int[] constants, int arg0)
	{
		return constants[0] * (int)Math.Pow(arg0 + constants[1], constants[2]);
	}

	private static int SeniorityFormula4(int[] constants, int arg0, int arg1)
	{
		return constants[0] * arg0 * (int)Math.Pow(arg1 + constants[1], constants[2]);
	}

	private static int SeniorityFormula5(int[] constants, int arg0, int arg1, int arg2)
	{
		return constants[0] * (int)Math.Pow(arg0 + constants[1], constants[2]) * (constants[3] - constants[3] * arg1 / arg2) / constants[3];
	}

	private static int SeniorityFormula6(int[] constants, int arg0)
	{
		return arg0 / constants[0];
	}

	private static int SeniorityFormula7(int[] constants, int arg0)
	{
		return (int)Math.Pow(arg0 / constants[0], constants[1]);
	}

	private static int SeniorityFormula8(int[] constants, int arg0)
	{
		return constants[0] * (int)Math.Pow(constants[1] - arg0, constants[2]);
	}

	private static int SeniorityFormula9(int[] constants)
	{
		return constants[0];
	}

	private static int SeniorityFormula10(int[] constants, int arg0)
	{
		return constants[arg0];
	}

	private static int SeniorityFormula11(int[] constants, int arg0, int arg1)
	{
		return constants[0] * (arg0 * constants[1] / arg1) / constants[2];
	}

	private static int SeniorityFormula12(int[] constants, int arg0)
	{
		return arg0 * constants[0] / constants[1];
	}
}
