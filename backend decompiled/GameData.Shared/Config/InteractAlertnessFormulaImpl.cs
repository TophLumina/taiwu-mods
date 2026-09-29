using System.Runtime.CompilerServices;
using Config.Common;

namespace Config;

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

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Calculate(int templateId, int arg0, int arg1)
	{
		return InteractAlertnessFormula.Instance[templateId].Calculate(arg0, arg1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Calculate(int templateId, int arg0, int arg1, int arg2)
	{
		return InteractAlertnessFormula.Instance[templateId].Calculate(arg0, arg1, arg2);
	}
}
