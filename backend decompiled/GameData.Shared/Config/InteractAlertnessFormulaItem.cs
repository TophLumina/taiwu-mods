using System;
using Config.Common;

namespace Config;

[Serializable]
public class InteractAlertnessFormulaItem : ConfigItem<InteractAlertnessFormulaItem, int>, IConfigFormula<EInteractAlertnessFormulaType>, IConfigFormula
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 公式类型
	/// - 类型定义在分表 t_Type 中，在代码中进行实现, 必须和常量列表同步修改, 且修改公式类型时必须通知程序.
	/// </summary>
	public readonly EInteractAlertnessFormulaType Type;

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

	EInteractAlertnessFormulaType IConfigFormula<EInteractAlertnessFormulaType>.ImplType => Type;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="type">公式类型 - 类型定义在分表 t_Type 中，在代码中进行实现, 必须和常量列表同步修改, 且修改公式类型时必须通知程序.</param>
	/// <param name="constants">常量列表 - 公式中用到的常量数值</param>
	/// <param name="maxValue">最大值 - 值为-1表示无最大值</param>
	public InteractAlertnessFormulaItem(int templateId, EInteractAlertnessFormulaType type, int[] constants, int maxValue)
	{
		TemplateId = templateId;
		Type = type;
		Constants = constants;
		MaxValue = maxValue;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public InteractAlertnessFormulaItem()
	{
		TemplateId = 0;
		Type = EInteractAlertnessFormulaType.Invalid;
		Constants = new int[0];
		MaxValue = -1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public InteractAlertnessFormulaItem(int templateId, InteractAlertnessFormulaItem other)
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
	public override InteractAlertnessFormulaItem Duplicate(int templateId)
	{
		return new InteractAlertnessFormulaItem(templateId, this);
	}

	int IConfigFormula<EInteractAlertnessFormulaType>.Calculate(EInteractAlertnessFormulaType type)
	{
		if (type == EInteractAlertnessFormulaType.Formula0)
		{
			return Formula0(Constants);
		}
		throw ThrowArgCountException(0);
	}

	int IConfigFormula<EInteractAlertnessFormulaType>.Calculate(EInteractAlertnessFormulaType type, int arg0)
	{
		return type switch
		{
			EInteractAlertnessFormulaType.Formula1 => Formula1(Constants, arg0), 
			EInteractAlertnessFormulaType.Formula2 => Formula2(Constants, arg0), 
			EInteractAlertnessFormulaType.Formula3 => Formula3(Constants, arg0), 
			_ => throw ThrowArgCountException(1), 
		};
	}

	int IConfigFormula<EInteractAlertnessFormulaType>.Calculate(EInteractAlertnessFormulaType type, int arg0, int arg1)
	{
		throw new NotImplementedException();
	}

	int IConfigFormula<EInteractAlertnessFormulaType>.Calculate(EInteractAlertnessFormulaType type, int arg0, int arg1, int arg2)
	{
		throw new NotImplementedException();
	}

	int IConfigFormula<EInteractAlertnessFormulaType>.ClampValue(int value)
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

	private static int Formula0(int[] c)
	{
		return c[0];
	}

	private static int Formula1(int[] c, int arg0)
	{
		return c[0] * arg0;
	}

	private static int Formula2(int[] c, int arg0)
	{
		return c[0] * (arg0 + c[1]) * c[2] / c[3];
	}

	private static int Formula3(int[] c, int arg0)
	{
		return arg0 * c[0] * c[0] * c[1] / c[2];
	}
}
