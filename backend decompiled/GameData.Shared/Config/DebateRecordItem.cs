using System;
using Config.Common;

namespace Config;

[Serializable]
public class DebateRecordItem : ConfigItem<DebateRecordItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 文本描述
	/// - 如果使用了特定的参数，需要给此变量添加悬停UI效果，并且显示对应的Tips。Card：DebateStrategy；Comment：DebateComment；
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 参数
	/// - 此字段自动生成, 其数据来自 "参数0" 到 "参数5" 共 6 个字段.
	/// </summary>
	public readonly EDebateRecordParamType[] Parameters;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="desc">文本描述 - 如果使用了特定的参数，需要给此变量添加悬停UI效果，并且显示对应的Tips。Card：DebateStrategy；Comment：DebateComment；</param>
	/// <param name="parameters">参数 - 此字段自动生成, 其数据来自 "参数0" 到 "参数5" 共 6 个字段.</param>
	public DebateRecordItem(short templateId, string desc, EDebateRecordParamType[] parameters)
	{
		TemplateId = templateId;
		Desc = desc;
		Parameters = parameters;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public DebateRecordItem()
	{
		TemplateId = 0;
		Desc = null;
		Parameters = new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		};
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public DebateRecordItem(short templateId, DebateRecordItem other)
	{
		TemplateId = templateId;
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
	public override DebateRecordItem Duplicate(int templateId)
	{
		return new DebateRecordItem((short)templateId, this);
	}
}
