using System;
using Config.Common;

namespace Config;

[Serializable]
public class InteractAlertnessFormulaItem : ConfigItem<InteractAlertnessFormulaItem, int>, IConfigFormula<EInteractAlertnessFormulaType>, IConfigFormula
{
	public readonly int TemplateId;

	public readonly EInteractAlertnessFormulaType Type;

	public readonly int[] Constants;

	public readonly int MaxValue;

	EInteractAlertnessFormulaType IConfigFormula<EInteractAlertnessFormulaType>.ImplType => Type;

	public InteractAlertnessFormulaItem(int templateId, EInteractAlertnessFormulaType type, int[] constants, int maxValue)
	{
		TemplateId = templateId;
		Type = type;
		Constants = constants;
		MaxValue = maxValue;
	}

	public InteractAlertnessFormulaItem()
	{
		TemplateId = 0;
		Type = EInteractAlertnessFormulaType.Invalid;
		Constants = new int[0];
		MaxValue = -1;
	}

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
