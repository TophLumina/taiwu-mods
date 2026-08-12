using System.Runtime.CompilerServices;
using Config.Common;

namespace Config;

/// <summary>
/// 通过TemplateId调用公式进行计算. 后续实现DefKey直接引用配置后可移除
/// </summary>
public static class InteractAlertnessFormulaImpl
{
	/// <summary>
	/// 无参数计算公式
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Calculate(int templateId)
	{
		return InteractAlertnessFormula.Instance[templateId].Calculate();
	}

	/// <summary>
	/// 1参数计算公式
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Calculate(int templateId, int arg0)
	{
		return InteractAlertnessFormula.Instance[templateId].Calculate(arg0);
	}

	/// <summary>
	/// 2参数计算公式
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Calculate(int templateId, int arg0, int arg1)
	{
		return InteractAlertnessFormula.Instance[templateId].Calculate(arg0, arg1);
	}

	/// <summary>
	/// 3参数计算公式
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Calculate(int templateId, int arg0, int arg1, int arg2)
	{
		return InteractAlertnessFormula.Instance[templateId].Calculate(arg0, arg1, arg2);
	}
}
