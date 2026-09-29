using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdvancingMonthFormulaItem : ConfigItem<AdvancingMonthFormulaItem, int>, IConfigFormula<EAdvancingMonthFormulaType>, IConfigFormula
{
	public readonly int TemplateId;

	public readonly EAdvancingMonthFormulaType Type;

	public readonly int[] Constants;

	public readonly int MaxValue;

	EAdvancingMonthFormulaType IConfigFormula<EAdvancingMonthFormulaType>.ImplType => Type;

	public AdvancingMonthFormulaItem(int templateId, EAdvancingMonthFormulaType type, int[] constants, int maxValue)
	{
		TemplateId = templateId;
		Type = type;
		Constants = constants;
		MaxValue = maxValue;
	}

	public AdvancingMonthFormulaItem()
	{
		TemplateId = 0;
		Type = EAdvancingMonthFormulaType.Invalid;
		Constants = new int[0];
		MaxValue = -1;
	}

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
