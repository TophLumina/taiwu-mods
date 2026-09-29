using System;
using Config.Common;

namespace Config;

[Serializable]
public class ProfessionFormulaItem : ConfigItem<ProfessionFormulaItem, int>
{
	public readonly int TemplateId;

	public readonly EProfessionFormulaType Type;

	public readonly int[] Constants;

	public readonly int MaxValue;

	public ProfessionFormulaItem(int templateId, EProfessionFormulaType type, int[] constants, int maxValue)
	{
		TemplateId = templateId;
		Type = type;
		Constants = constants;
		MaxValue = maxValue;
	}

	public ProfessionFormulaItem()
	{
		TemplateId = 0;
		Type = EProfessionFormulaType.Invalid;
		Constants = new int[0];
		MaxValue = -1;
	}

	public ProfessionFormulaItem(int templateId, ProfessionFormulaItem other)
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

	public override ProfessionFormulaItem Duplicate(int templateId)
	{
		return new ProfessionFormulaItem(templateId, this);
	}
}
