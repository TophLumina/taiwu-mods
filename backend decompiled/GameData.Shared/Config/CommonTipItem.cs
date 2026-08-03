using System;
using Config.Common;

namespace Config;

[Serializable]
public class CommonTipItem : ConfigItem<CommonTipItem, int>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 主体配置资源位置
	/// </summary>
	public readonly string Path;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="path">主体配置资源位置</param>
	public CommonTipItem(int templateId, string path)
	{
		TemplateId = templateId;
		Path = path;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CommonTipItem()
	{
		TemplateId = 0;
		Path = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CommonTipItem(int templateId, CommonTipItem other)
	{
		TemplateId = templateId;
		Path = other.Path;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CommonTipItem Duplicate(int templateId)
	{
		return new CommonTipItem(templateId, this);
	}
}
