using System;
using Config.Common;

namespace Config;

[Serializable]
public class AiParamItem : ConfigItem<AiParamItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly EAiParamType Type;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 显示用别名
	/// - 显示时会将解析用别名转换为显示用别名，原始输入不为解析用别名时优先采用原始输入，有多个可对应别名时显示靠前的别名
	/// </summary>
	public readonly string[] PrintingAliases;

	/// <summary>
	/// 解析用别名
	/// - 解析时会将显示用别名转换为解析用别名
	/// </summary>
	public readonly string[] AnalysisAliases;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="type">类型</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="printingAliases">显示用别名 - 显示时会将解析用别名转换为显示用别名，原始输入不为解析用别名时优先采用原始输入，有多个可对应别名时显示靠前的别名</param>
	/// <param name="analysisAliases">解析用别名 - 解析时会将显示用别名转换为解析用别名</param>
	public AiParamItem(int templateId, EAiParamType type, string name, string desc, string[] printingAliases, string[] analysisAliases)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Desc = desc;
		PrintingAliases = printingAliases;
		AnalysisAliases = analysisAliases;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AiParamItem()
	{
		TemplateId = 0;
		Type = EAiParamType.Int;
		Name = null;
		Desc = null;
		PrintingAliases = new string[0];
		AnalysisAliases = new string[0];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AiParamItem Duplicate(int templateId)
	{
		return new AiParamItem(templateId, this);
	}
}
