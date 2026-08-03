using System;
using Config.Common;

namespace Config;

[Serializable]
public class JiaoRecordItem : ConfigItem<JiaoRecordItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 参数
	/// - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.
	/// </summary>
	public readonly string[] Parameters;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="parameters">参数 - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.</param>
	public JiaoRecordItem(short templateId, string name, string desc, string[] parameters)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Parameters = parameters;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public JiaoRecordItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Parameters = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public JiaoRecordItem(short templateId, JiaoRecordItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Parameters = other.Parameters;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override JiaoRecordItem Duplicate(int templateId)
	{
		return new JiaoRecordItem((short)templateId, this);
	}
}
