using System;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class BuildingFormulaItem : ConfigItem<BuildingFormulaItem, int>, IConfigFormula<EBuildingFormulaType>, IConfigFormula, IFormulaArgTypeSource<EBuildingFormulaArgType>
{
	public readonly int TemplateId;

	public readonly EBuildingFormulaType Type;

	public readonly EBuildingFormulaArgType[] Arguments;

	public readonly int[] Constants;

	public readonly int MaxValue;

	EBuildingFormulaType IConfigFormula<EBuildingFormulaType>.ImplType => Type;

	public EBuildingFormulaArgType[] ArgTypes => Arguments;

	public BuildingFormulaItem(int templateId, EBuildingFormulaType type, EBuildingFormulaArgType[] arguments, int[] constants, int maxValue)
	{
		TemplateId = templateId;
		Type = type;
		Arguments = arguments;
		Constants = constants;
		MaxValue = maxValue;
	}

	public BuildingFormulaItem()
	{
		TemplateId = 0;
		Type = EBuildingFormulaType.Invalid;
		Arguments = null;
		Constants = new int[0];
		MaxValue = -1;
	}

	public BuildingFormulaItem(int templateId, BuildingFormulaItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Arguments = other.Arguments;
		Constants = other.Constants;
		MaxValue = other.MaxValue;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override BuildingFormulaItem Duplicate(int templateId)
	{
		return new BuildingFormulaItem(templateId, this);
	}

	int IConfigFormula<EBuildingFormulaType>.Calculate(EBuildingFormulaType type)
	{
		return type switch
		{
			EBuildingFormulaType.Formula0 => Formula0(Constants), 
			EBuildingFormulaType.Formula6 => Formula6(Constants), 
			EBuildingFormulaType.Formula7 => Formula7(Constants), 
			_ => throw ThrowArgCountException(0), 
		};
	}

	int IConfigFormula<EBuildingFormulaType>.Calculate(EBuildingFormulaType type, int arg0)
	{
		return type switch
		{
			EBuildingFormulaType.Formula1 => Formula1(Constants, arg0), 
			EBuildingFormulaType.Formula2 => Formula2(Constants, arg0), 
			EBuildingFormulaType.Formula3 => Formula3(Constants, arg0), 
			EBuildingFormulaType.Formula4 => Formula4(Constants, arg0), 
			EBuildingFormulaType.Formula8 => Formula8(Constants, arg0), 
			EBuildingFormulaType.Formula9 => Formula9(Constants, arg0), 
			_ => throw ThrowArgCountException(1), 
		};
	}

	int IConfigFormula<EBuildingFormulaType>.Calculate(EBuildingFormulaType type, int arg0, int arg1)
	{
		if (type == EBuildingFormulaType.Formula5)
		{
			return Formula5(Constants, arg0, arg1);
		}
		throw ThrowArgCountException(2);
	}

	int IConfigFormula<EBuildingFormulaType>.Calculate(EBuildingFormulaType type, int arg0, int arg1, int arg2)
	{
		throw ThrowArgCountException(3);
	}

	int IConfigFormula<EBuildingFormulaType>.ClampValue(int value)
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
		return arg0;
	}

	private static int Formula2(int[] c, int arg0)
	{
		return c[0] + arg0 / c[1];
	}

	private static int Formula3(int[] c, int arg0)
	{
		return c[0] * arg0 / c[1];
	}

	private static int Formula4(int[] c, int arg0)
	{
		return c[0] + c[1] * arg0 / c[2];
	}

	private static int Formula5(int[] c, int arg0, int arg1)
	{
		return (c[0] + c[1] * arg0) * arg1 / c[2];
	}

	private static int Formula6(int[] c)
	{
		return IConfigFormula.Random.Next(c[0], c[1]);
	}

	private static int Formula7(int[] c)
	{
		if (!IConfigFormula.Random.CheckPercentProb(c[0]))
		{
			return IConfigFormula.Random.Next(c[2], c[3]);
		}
		return c[1];
	}

	private static int Formula8(int[] c, int arg0)
	{
		return c[0] * arg0;
	}

	private static int Formula9(int[] c, int arg0)
	{
		return arg0 + IConfigFormula.Random.Next(c[0], c[1]);
	}
}
