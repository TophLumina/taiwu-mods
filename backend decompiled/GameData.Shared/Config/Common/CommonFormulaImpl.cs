using System.Runtime.CompilerServices;

namespace Config.Common;

public class CommonFormulaImpl
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ConstantFunction(int[] c)
	{
		return c[0];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int IdentityFunction(int[] c, int arg0)
	{
		return arg0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int OffsetFunction(int[] c, int arg0)
	{
		return arg0 + c[0];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ProportionalFunction(int[] c, int arg0)
	{
		return arg0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int LinearFunction(int[] c, int arg0)
	{
		return c[0] * arg0 + c[1];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int InverseVariationFunction(int[] c, int arg0)
	{
		return c[0] / arg0;
	}

	public static int ModularFunction(int[] c, int arg0)
	{
		return arg0 % c[0];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ConstantRangeRandom(int[] c)
	{
		return IConfigFormula.Random.Next(c[0], c[1]);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ArrayElement(int[] c, int arg0)
	{
		return c[arg0];
	}
}
