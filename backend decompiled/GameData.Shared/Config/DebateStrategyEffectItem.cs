using System;
using Config.Common;

namespace Config;

[Serializable]
public class DebateStrategyEffectItem : ConfigItem<DebateStrategyEffectItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	public DebateStrategyEffectItem(short templateId)
	{
		TemplateId = templateId;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public DebateStrategyEffectItem()
	{
		TemplateId = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public DebateStrategyEffectItem(short templateId, DebateStrategyEffectItem other)
	{
		TemplateId = templateId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DebateStrategyEffectItem Duplicate(int templateId)
	{
		return new DebateStrategyEffectItem((short)templateId, this);
	}
}
