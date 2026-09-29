using System;
using Config.Common;

namespace Config;

[Serializable]
public class AiParamItem : ConfigItem<AiParamItem, int>
{
	public readonly int TemplateId;

	public readonly EAiParamType Type;

	public readonly string Name;

	public readonly string Desc;

	public readonly string[] PrintingAliases;

	public readonly string[] AnalysisAliases;

	public AiParamItem(int templateId, EAiParamType type, string name, string desc, string[] printingAliases, string[] analysisAliases)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Desc = desc;
		PrintingAliases = printingAliases;
		AnalysisAliases = analysisAliases;
	}

	public AiParamItem()
	{
		TemplateId = 0;
		Type = EAiParamType.Int;
		Name = null;
		Desc = null;
		PrintingAliases = new string[0];
		AnalysisAliases = new string[0];
	}

	public AiParamItem(int templateId, AiParamItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		Desc = other.Desc;
		PrintingAliases = other.PrintingAliases;
		AnalysisAliases = other.AnalysisAliases;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AiParamItem Duplicate(int templateId)
	{
		return new AiParamItem(templateId, this);
	}
}
