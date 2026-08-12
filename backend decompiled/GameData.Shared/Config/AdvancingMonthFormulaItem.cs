using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdvancingMonthFormulaItem : ConfigItem<AdvancingMonthFormulaItem, int>, IConfigFormula<EAdvancingMonthFormulaType>, IConfigFormula
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 公式类型
	/// - 类型定义在分表 t_Type 中，在代码中进行实现, 必须和常量列表同步修改, 且修改公式类型时必须通知程序.
	/// </summary>
	public readonly EAdvancingMonthFormulaType Type;

	/// <summary>
	/// 常量列表
	/// - 公式中用到的常量数值
	/// </summary>
	public readonly int[] Constants;

	/// <summary>
	/// 最大值
	/// - 值为-1表示无最大值
	/// </summary>
	public readonly int MaxValue;

	EAdvancingMonthFormulaType IConfigFormula<EAdvancingMonthFormulaType>.ImplType => Type;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="type">公式类型 - 类型定义在分表 t_Type 中，在代码中进行实现, 必须和常量列表同步修改, 且修改公式类型时必须通知程序.</param>
	/// <param name="constants">常量列表 - 公式中用到的常量数值</param>
	/// <param name="maxValue">最大值 - 值为-1表示无最大值</param>
	public AdvancingMonthFormulaItem(int templateId, EAdvancingMonthFormulaType type, int[] constants, int maxValue)
	{
		TemplateId = templateId;
		Type = type;
		Constants = constants;
		MaxValue = maxValue;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AdvancingMonthFormulaItem()
	{
		TemplateId = 0;
		Type = EAdvancingMonthFormulaType.Invalid;
		Constants = new int[0];
		MaxValue = -1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AdvancingMonthFormulaItem(int templateId, AdvancingMonthFormulaItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Constants = other.Constants;
		MaxValue = other.MaxValue;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AdvancingMonthFormulaItem Duplicate(int templateId)
	{
		return new AdvancingMonthFormulaItem(templateId, this);
	}

	int IConfigFormula<EAdvancingMonthFormulaType>.Calculate(EAdvancingMonthFormulaType type)
	{
		return type switch
		{
			EAdvancingMonthFormulaType.ConstantFunction => CommonFormulaImpl.ConstantFunction(Constants), 
			EAdvancingMonthFormulaType.ConstantRangeRandom => CommonFormulaImpl.ConstantRangeRandom(Constants), 
			_ => throw ThrowArgCountException(0), 
		};
	}

	int IConfigFormula<EAdvancingMonthFormulaType>.Calculate(EAdvancingMonthFormulaType type, int arg0)
	{
		return type switch
		{
			EAdvancingMonthFormulaType.IdentityFunction => CommonFormulaImpl.IdentityFunction(Constants, arg0), 
			EAdvancingMonthFormulaType.OffsetFunction => CommonFormulaImpl.OffsetFunction(Constants, arg0), 
			EAdvancingMonthFormulaType.ProportionalFunction => CommonFormulaImpl.ProportionalFunction(Constants, arg0), 
			EAdvancingMonthFormulaType.LinearFunction => CommonFormulaImpl.LinearFunction(Constants, arg0), 
			EAdvancingMonthFormulaType.InverseVariationFunction => CommonFormulaImpl.InverseVariationFunction(Constants, arg0), 
			EAdvancingMonthFormulaType.ModularFunction => CommonFormulaImpl.ModularFunction(Constants, arg0), 
			EAdvancingMonthFormulaType.ArrayElement => CommonFormulaImpl.ArrayElement(Constants, arg0), 
			EAdvancingMonthFormulaType.Formula0 => Formula0(Constants, arg0), 
			EAdvancingMonthFormulaType.Formula2 => Formula2(Constants, arg0), 
			_ => throw ThrowArgCountException(1), 
		};
	}

	int IConfigFormula<EAdvancingMonthFormulaType>.Calculate(EAdvancingMonthFormulaType type, int arg0, int arg1)
	{
		if (type == EAdvancingMonthFormulaType.Formula1)
		{
			return Formula1(Constants, arg0, arg1);
		}
		throw ThrowArgCountException(2);
	}

	int IConfigFormula<EAdvancingMonthFormulaType>.Calculate(EAdvancingMonthFormulaType type, int arg0, int arg1, int arg2)
	{
		throw ThrowArgCountException(3);
	}

	int IConfigFormula<EAdvancingMonthFormulaType>.ClampValue(int value)
	{
		if (MaxValue <= 0 || value <= MaxValue)
		{
			return value;
		}
		return MaxValue;
	}

	/// <inheritdoc />
	public ArgumentException ThrowArgCountException(int argCount)
	{
		return new ArgumentException($"Formula {TemplateId}'s type {Type} doesn't match arg count {argCount}");
	}

	private static int Formula0(int[] c, int arg0)
	{
		return arg0 / c[0];
	}

	private static int Formula1(int[] c, int arg0, int arg1)
	{
		return (arg0 - arg1) * c[0];
	}

	private static int Formula2(int[] c, int arg0)
	{
		return arg0 / c[0] + c[1];
	}
}
