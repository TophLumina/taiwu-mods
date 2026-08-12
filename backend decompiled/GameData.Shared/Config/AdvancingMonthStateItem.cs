using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdvancingMonthStateItem : ConfigItem<AdvancingMonthStateItem, int>
{
	/// <summary>
	/// 模板ID
	/// - 该表格的ID不存档，RefMap顺序无实际作用，实际由CodeGenerator按照表格中的排序直接生成代码在过月执行.
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 提示文本
	/// </summary>
	public readonly string HintText;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID - 该表格的ID不存档，RefMap顺序无实际作用，实际由CodeGenerator按照表格中的排序直接生成代码在过月执行.</param>
	/// <param name="hintText">提示文本</param>
	public AdvancingMonthStateItem(int templateId, string hintText)
	{
		TemplateId = templateId;
		HintText = hintText;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AdvancingMonthStateItem()
	{
		TemplateId = 0;
		HintText = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AdvancingMonthStateItem(int templateId, AdvancingMonthStateItem other)
	{
		TemplateId = templateId;
		HintText = other.HintText;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AdvancingMonthStateItem Duplicate(int templateId)
	{
		return new AdvancingMonthStateItem(templateId, this);
	}
}
