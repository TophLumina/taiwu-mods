using System;
using Config.Common;
using GameData;
using Redzen.Random;

namespace Config;

[Serializable]
public class VillagerRoleFormulaItem : ConfigItem<VillagerRoleFormulaItem, int>, IConfigFormula<EVillagerRoleFormulaType>, IConfigFormula
{
	public readonly int TemplateId;

	public readonly EVillagerRoleFormulaType Type;

	public readonly int[] Constants;

	public readonly int MaxValue;

	public readonly string DisplayName;

	public readonly string DisplayFormat;

	EVillagerRoleFormulaType IConfigFormula<EVillagerRoleFormulaType>.ImplType => Type;

	public VillagerRoleFormulaItem(int templateId, EVillagerRoleFormulaType type, int[] constants, int maxValue, string displayName, string displayFormat)
	{
		TemplateId = templateId;
		Type = type;
		Constants = constants;
		MaxValue = maxValue;
		DisplayName = displayName;
		DisplayFormat = displayFormat;
	}

	public VillagerRoleFormulaItem()
	{
		TemplateId = 0;
		Type = EVillagerRoleFormulaType.Invalid;
		Constants = new int[0];
		MaxValue = -1;
		DisplayName = null;
		DisplayFormat = null;
	}

	public VillagerRoleFormulaItem(int templateId, VillagerRoleFormulaItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Constants = other.Constants;
		MaxValue = other.MaxValue;
		DisplayName = other.DisplayName;
		DisplayFormat = other.DisplayFormat;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override VillagerRoleFormulaItem Duplicate(int templateId)
	{
		return new VillagerRoleFormulaItem(templateId, this);
	}

	int IConfigFormula<EVillagerRoleFormulaType>.Calculate(EVillagerRoleFormulaType type)
	{
		if (type == EVillagerRoleFormulaType.Formula0)
		{
			return Formula0(Constants);
		}
		throw ThrowArgCountException(0);
	}

	int IConfigFormula<EVillagerRoleFormulaType>.Calculate(EVillagerRoleFormulaType type, int arg0)
	{
		return type switch
		{
			EVillagerRoleFormulaType.Formula1 => Formula1(Constants, arg0), 
			EVillagerRoleFormulaType.Formula2 => Formula2(Constants, arg0), 
			EVillagerRoleFormulaType.Formula3 => Formula3(Constants, arg0), 
			EVillagerRoleFormulaType.Formula4 => Formula4(Constants, arg0), 
			EVillagerRoleFormulaType.Formula8 => Formula8(Constants, arg0), 
			EVillagerRoleFormulaType.Formula10 => Formula10(Constants, arg0), 
			_ => throw ThrowArgCountException(1), 
		};
	}

	int IConfigFormula<EVillagerRoleFormulaType>.Calculate(EVillagerRoleFormulaType type, int arg0, int arg1)
	{
		return type switch
		{
			EVillagerRoleFormulaType.Formula5 => Formula5(Constants, arg0, arg1), 
			EVillagerRoleFormulaType.Formula6 => Formula6(Constants, arg0, arg1), 
			EVillagerRoleFormulaType.Formula7 => Formula7(Constants, arg0, arg1), 
			EVillagerRoleFormulaType.Formula9 => Formula9(Constants, arg0, arg1), 
			EVillagerRoleFormulaType.Formula11 => Formula11(Constants, arg0, arg1), 
			EVillagerRoleFormulaType.Formula12 => Formula12(Constants, arg0, arg1), 
			EVillagerRoleFormulaType.Formula14 => Formula14(Constants, arg0, arg1), 
			_ => throw ThrowArgCountException(2), 
		};
	}

	int IConfigFormula<EVillagerRoleFormulaType>.Calculate(EVillagerRoleFormulaType type, int arg0, int arg1, int arg2)
	{
		if (type == EVillagerRoleFormulaType.Formula13)
		{
			return Formula13(Constants, arg0, arg1, arg2);
		}
		throw ThrowArgCountException(3);
	}

	int IConfigFormula<EVillagerRoleFormulaType>.ClampValue(int value)
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
		return c[0] + arg0;
	}

	private static int Formula2(int[] c, int arg0)
	{
		return c[0] * arg0;
	}

	private static int Formula3(int[] c, int arg0)
	{
		return arg0 / c[0];
	}

	private static int Formula4(int[] c, int arg0)
	{
		return c[0] + arg0 / c[1];
	}

	private static int Formula5(int[] c, int arg0, int arg1)
	{
		return arg0 / c[0] * arg1 / c[1];
	}

	private static int Formula6(int[] c, int arg0, int arg1)
	{
		return (c[0] + arg0) * arg1 / c[1];
	}

	private static int Formula7(int[] c, int arg0, int arg1)
	{
		return arg0 * arg1 / c[0] / c[1];
	}

	private static int Formula8(int[] c, int arg0)
	{
		IRandomSource random = ExternalDataBridge.Context.Random;
		return arg0 * random.Next(c[0], c[1]) / c[2];
	}

	private static int Formula9(int[] c, int arg0, int arg1)
	{
		return c[0] + arg0 / c[1] * arg1 / c[2];
	}

	private static int Formula10(int[] c, int arg0)
	{
		return c[arg0];
	}

	private static int Formula11(int[] c, int arg0, int arg1)
	{
		return arg0 * c[0] / 100 * (c[1] - arg1 / c[2]) / c[3];
	}

	private static int Formula12(int[] c, int arg0, int arg1)
	{
		return arg0 * (c[0] + arg1);
	}

	private static int Formula13(int[] c, int arg0, int arg1, int arg2)
	{
		return arg0 * (c[0] + arg1 / c[1] * arg2) / c[2];
	}

	private static int Formula14(int[] c, int arg0, int arg1)
	{
		return (c[0] + arg0 / c[1]) * arg1 / c[2];
	}
}
