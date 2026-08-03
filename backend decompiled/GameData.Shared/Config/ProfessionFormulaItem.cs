using System;
using Config.Common;

namespace Config;

[Serializable]
public class ProfessionFormulaItem : ConfigItem<ProfessionFormulaItem, int>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 公式类型
	/// - 类型定义在分表 t_Type 中，在代码中进行实现, 必须和常量列表同步修改, 且修改公式类型时必须通知程序.
	/// </summary>
	public readonly EProfessionFormulaType Type;

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

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="type">公式类型 - 类型定义在分表 t_Type 中，在代码中进行实现, 必须和常量列表同步修改, 且修改公式类型时必须通知程序.</param>
	/// <param name="constants">常量列表 - 公式中用到的常量数值</param>
	/// <param name="maxValue">最大值 - 值为-1表示无最大值</param>
	public ProfessionFormulaItem(int templateId, EProfessionFormulaType type, int[] constants, int maxValue)
	{
		TemplateId = templateId;
		Type = type;
		Constants = constants;
		MaxValue = maxValue;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ProfessionFormulaItem()
	{
		TemplateId = 0;
		Type = EProfessionFormulaType.Invalid;
		Constants = new int[0];
		MaxValue = -1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ProfessionFormulaItem Duplicate(int templateId)
	{
		return new ProfessionFormulaItem(templateId, this);
	}
}
