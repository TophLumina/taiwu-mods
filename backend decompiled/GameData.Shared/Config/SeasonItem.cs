using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SeasonItem : ConfigItem<SeasonItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 月份
	/// </summary>
	public readonly List<sbyte> Months;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="months">月份</param>
	public SeasonItem(sbyte templateId, List<sbyte> months)
	{
		TemplateId = templateId;
		Months = months;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SeasonItem()
	{
		TemplateId = 0;
		Months = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SeasonItem(sbyte templateId, SeasonItem other)
	{
		TemplateId = templateId;
		Months = other.Months;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SeasonItem Duplicate(int templateId)
	{
		return new SeasonItem((sbyte)templateId, this);
	}
}
