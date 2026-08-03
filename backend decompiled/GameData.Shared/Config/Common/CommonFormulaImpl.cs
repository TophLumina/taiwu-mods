using System.Runtime.CompilerServices;

namespace Config.Common;

/// <summary>
/// 通用公式实现
/// </summary>
public class CommonFormulaImpl
{
	/// <summary>
	/// 常函数
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ConstantFunction(int[] c)
	{
		return c[0];
	}

	/// <summary>
	/// 恒等函数
	/// </summary>
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

	/// <summary>
	/// 正比例函数
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ProportionalFunction(int[] c, int arg0)
	{
		return arg0;
	}

	/// <summary>
	/// 线性函数
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int LinearFunction(int[] c, int arg0)
	{
		return c[0] * arg0 + c[1];
	}

	/// <summary>
	/// 反比例函数
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int InverseVariationFunction(int[] c, int arg0)
	{
		return c[0] / arg0;
	}

	/// <summary>
	/// 模函数
	/// </summary>
	public static int ModularFunction(int[] c, int arg0)
	{
		return arg0 % c[0];
	}

	/// <summary>
	/// 常量范围随机
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ConstantRangeRandom(int[] c)
	{
		return IConfigFormula.Random.Next(c[0], c[1]);
	}

	/// <summary>
	/// 取数组元素
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ArrayElement(int[] c, int arg0)
	{
		return c[arg0];
	}
}
